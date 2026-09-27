import sys
import io
import hashlib
import UnityPy

def main():
    # Force stream in binary
    input_stream = sys.stdin.buffer
    output_stream = sys.stdout.buffer

    try:
        # 1. Read the bundle data from Unity
        bundle_bytes = input_stream.read()
        if not bundle_bytes:
            return

        # 2. Load asset bundle
        env = UnityPy.load(io.BytesIO(bundle_bytes))
        
        changed = {}
        untouched = {}

        # 3. Convert textures
        for asset in env.assets:
            for obj in asset.objects.values():
                key = (asset.name, obj.path_id)
                if obj.type.name == "Texture2D":
                    texture = obj.read()
                    
                    # Formats Android ETC/EAC/PVRTC/ASTC (>= 30).
                    if int(texture.m_TextureFormat) >= 30:
                        decoded = texture.image.convert("RGBA")
                        changed[key] = (texture.m_Name, decoded.size, hashlib.sha256(decoded.tobytes()).hexdigest())
                        
                        mip_count = max(1, getattr(texture, "m_MipCount", 1) or 1)
                        texture.set_image(decoded, target_format=4, mipmap_count=mip_count)
                        texture.save()
                        continue
                        
                untouched[key] = hashlib.sha256(obj.get_raw_data()).hexdigest()

        if not changed:
            output_stream.write(bundle_bytes)
            output_stream.flush()
            return

        rebuilt = env.file.save(packer="lz4")

        verified = UnityPy.load(rebuilt)
        seen = set()
        for asset in verified.assets:
            for obj in asset.objects.values():
                key = (asset.name, obj.path_id)
                seen.add(key)
                if key in changed:
                    name, size, pixel_hash = changed[key]
                    texture = obj.read()
                    assert int(texture.m_TextureFormat) == 4
                    decoded = texture.image.convert("RGBA")
                    assert decoded.size == size and hashlib.sha256(decoded.tobytes()).hexdigest() == pixel_hash, name
                else:
                    assert hashlib.sha256(obj.get_raw_data()).hexdigest() == untouched[key], key

        # Send result to Unity
        output_stream.write(rebuilt)
        output_stream.flush()

    except AssertionError as ae:
        sys.stderr.write(f"Assertion error when doing checks : {str(ae)}\n")
        sys.stderr.flush()
        sys.exit(2)
    except Exception as e:
        sys.stderr.write(f"Erreur Python: {str(e)}\n")
        sys.stderr.flush()
        sys.exit(1)

if __name__ == "__main__":
    main()
