
namespace XeApp.Core
{
    public abstract class AssetBundleLoadAssetOperation : AssetBundleLoadOperation
    {
        // Methods

        // RVA: -1 Offset: -1 Slot: 10
        public abstract T GetAsset<T>();
        /* GenericInstMethod :
        |
        |-RVA: -1 Offset: -1
        |-AssetBundleLoadAssetOperation.GetAsset<object>
        |-AssetBundleLoadAssetOperation.GetAsset<AnimationClip>
        |-AssetBundleLoadAssetOperation.GetAsset<GameObject>
        |-AssetBundleLoadAssetOperation.GetAsset<Material>
        |-AssetBundleLoadAssetOperation.GetAsset<RenderTexture>
        |-AssetBundleLoadAssetOperation.GetAsset<RuntimeAnimatorController>
        |-AssetBundleLoadAssetOperation.GetAsset<TextAsset>
        |-AssetBundleLoadAssetOperation.GetAsset<Texture2D>
        |-AssetBundleLoadAssetOperation.GetAsset<Texture>
        |-AssetBundleLoadAssetOperation.GetAsset<AdvCharacterData>
        |-AssetBundleLoadAssetOperation.GetAsset<DivaMenuParam>
        |-AssetBundleLoadAssetOperation.GetAsset<DivaParam>
        |-AssetBundleLoadAssetOperation.GetAsset<ShootingStageData>
        |-AssetBundleLoadAssetOperation.GetAsset<MusicDirectionBoolParam>
        |-AssetBundleLoadAssetOperation.GetAsset<MusicDirectionParamBase>
        */

        // RVA: 0xE0F7B0 Offset: 0xE0F7B0 VA: 0xE0F7B0
        // protected void .ctor() { }
    }
}