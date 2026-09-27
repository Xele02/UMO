import sys
import io
import hashlib
import UnityPy

def main():
    # Force les flux standard en mode binaire
    input_stream = sys.stdin.buffer
    output_stream = sys.stdout.buffer

    try:
        # 1. Lire le buffer binaire de l'AssetBundle envoyé par Unity
        bundle_bytes = input_stream.read()
        if not bundle_bytes:
            return

        # 2. Charger l'AssetBundle directement depuis la RAM
        env = UnityPy.load(io.BytesIO(bundle_bytes))
        
        changed = {}
        untouched = {}

        # 3. Parcours strict selon la logique du script d'origine
        for asset in env.assets:
            for obj in asset.objects.values():
                key = (asset.name, obj.path_id)
                if obj.type.name == "Texture2D":
                    texture = obj.read()
                    
                    # Formats Android ETC/EAC/PVRTC/ASTC (>= 30).
                    if int(texture.m_TextureFormat) >= 30:
                        decoded = texture.image.convert("RGBA")
                        changed[key] = (texture.m_Name, decoded.size, hashlib.sha256(decoded.tobytes()).hexdigest())
                        
                        # Conversion au format target_format=4 (RGBA32) avec préservation des MipMaps
                        mip_count = max(1, getattr(texture, "m_MipCount", 1) or 1)
                        texture.set_image(decoded, target_format=4, mipmap_count=mip_count)
                        texture.save()
                        continue
                        
                untouched[key] = hashlib.sha256(obj.get_raw_data()).hexdigest()

        # Si aucune texture n'a été modifiée, on renvoie le bundle original tel quel
        if not changed:
            output_stream.write(bundle_bytes)
            output_stream.flush()
            return

        # 4. Reconstruction forcée avec le packer LZ4 (comme le script d'origine)
        rebuilt = env.file.save(packer="lz4")

        # 5. Étape de vérification et d'assertion stricte (reprise du script d'origine)
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

        # 6. Écriture du résultat final validé sur stdout
        output_stream.write(rebuilt)
        output_stream.flush()

    except AssertionError as ae:
        sys.stderr.write(f"Erreur d'assertion lors de la vérification : {str(ae)}\n")
        sys.stderr.flush()
        sys.exit(2)
    except Exception as e:
        sys.stderr.write(f"Erreur Python: {str(e)}\n")
        sys.stderr.flush()
        sys.exit(1)

if __name__ == "__main__":
    main()
