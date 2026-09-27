import sys
import io
import hashlib
import struct
import UnityPy

def read_exact(stream, n):
    """Read exactly n bytes or return None if stream closed (Unity crashed)."""
    data = bytearray()
    while len(data) < n:
        packet = stream.read(n - len(data))
        # If packet is empty, mean stdin is closed (game closed or crashed)
        if not packet:
            return None
        data.extend(packet)
    return bytes(data)

def main():
    input_stream = sys.stdin.buffer
    output_stream = sys.stdout.buffer

    # Signal to Unity than python service is ready
    sys.stderr.write("READY\n")
    sys.stderr.flush()

    while True:
        try:
            # 1. Try to read the size of the next bundle
            size_bytes = read_exact(input_stream, 4)
            
            # CRASH SECURITY : if size_bytes is None, Unity stopped or crashed.
            # Kill the service.
            if not size_bytes:
                sys.stderr.write("Unity disconnected. Service end.\n")
                sys.stderr.flush()
                sys.exit(0)

            bundle_size = struct.unpack("<I", size_bytes)[0]

            # 2. Read asset bundle
            bundle_bytes = read_exact(input_stream, bundle_size)
            if not bundle_bytes:
                sys.exit(0)

            # 3. UnityPy texture conversion
            env = UnityPy.load(io.BytesIO(bundle_bytes))
            changed = {}
            untouched = {}

            for asset in env.assets:
                for obj in asset.objects.values():
                    key = (asset.name, obj.path_id)
                    if obj.type.name == "Texture2D":
                        texture = obj.read()
                        if int(texture.m_TextureFormat) >= 30:
                            decoded = texture.image.convert("RGBA")
                            changed[key] = (texture.m_Name, decoded.size, hashlib.sha256(decoded.tobytes()).hexdigest())
                            mip_count = max(1, getattr(texture, "m_MipCount", 1) or 1)
                            texture.set_image(decoded, target_format=4, mipmap_count=mip_count)
                            texture.save()
                            continue
                    untouched[key] = hashlib.sha256(obj.get_raw_data()).hexdigest()

            if not changed:
                output_stream.write(struct.pack("<I", len(bundle_bytes)))
                output_stream.write(bundle_bytes)
                output_stream.flush()
                continue

            rebuilt = env.file.save(packer="lz4")

            # Check conversion
            verified = UnityPy.load(rebuilt)
            for asset in verified.assets:
                for obj in asset.objects.values():
                    key = (asset.name, obj.path_id)
                    if key in changed:
                        name, size, pixel_hash = changed[key]
                        texture = obj.read()
                        assert int(texture.m_TextureFormat) == 4
                        decoded = texture.image.convert("RGBA")
                        assert decoded.size == size and hashlib.sha256(decoded.tobytes()).hexdigest() == pixel_hash, name
                    else:
                        assert hashlib.sha256(obj.get_raw_data()).hexdigest() == untouched[key], key

            # 4. Send result to Unity
            output_stream.write(struct.pack("<I", len(rebuilt)))
            output_stream.write(rebuilt)
            output_stream.flush()

        except AssertionError as ae:
            sys.stderr.write(f"ERROR:Assertion:{str(ae)}\n")
            sys.stderr.flush()
        except Exception as e:
            sys.stderr.write(f"ERROR:Exception:{str(e)}\n")
            sys.stderr.flush()

if __name__ == "__main__":
    main()
