import sys
import io
import hashlib
import struct
import UnityPy

def read_exact(stream, n):
    """Lit exactement n octets ou retourne None si le flux est fermé (Unity a crashé)."""
    data = bytearray()
    while len(data) < n:
        packet = stream.read(n - len(data))
        # Si packet est vide, cela signifie que le flux stdin est rompu (fermeture/crash du jeu)
        if not packet:
            return None
        data.extend(packet)
    return bytes(data)

def main():
    input_stream = sys.stdin.buffer
    output_stream = sys.stdout.buffer

    # Signale à Unity que le service Python est prêt
    sys.stderr.write("READY\n")
    sys.stderr.flush()

    while True:
        try:
            # 1. Tenter de lire la taille du prochain AssetBundle
            size_bytes = read_exact(input_stream, 4)
            
            # SÉCURITÉ CRASH : Si size_bytes est None, Unity s'est arrêté ou a crashé.
            # On coupe immédiatement le script Python pour éviter le processus zombie.
            if not size_bytes:
                sys.stderr.write("Unity déconnecté. Fermeture du service.\n")
                sys.stderr.flush()
                sys.exit(0)

            bundle_size = struct.unpack("<I", size_bytes)[0]

            # 2. Lire l'AssetBundle
            bundle_bytes = read_exact(input_stream, bundle_size)
            if not bundle_bytes:
                sys.exit(0)

            # 3. Logique de conversion UnityPy (Identique au script original)
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

            # Validation des assertions
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

            # 4. Envoi de la réponse à Unity
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
