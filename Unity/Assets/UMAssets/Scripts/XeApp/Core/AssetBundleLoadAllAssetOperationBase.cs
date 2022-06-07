using System;
using UnityEngine;

namespace XeApp.Core
{
    public abstract class AssetBundleLoadAllAssetOperationBase : AssetBundleLoadOperation
    {
        // RVA: -1 Offset: -1 Slot: 10
        public abstract T GetAsset<T>(string assetName);
        // /* GenericInstMethod :
        // |
        // |-RVA: -1 Offset: -1
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<object>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<AnimationClip>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<AnimatorOverrideController>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<GameObject>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<Material>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<RuntimeAnimatorController>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<Sprite>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<TextAsset>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<Texture2D>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<Texture>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<BoneSpringSuppressParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<DivaMenuParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<ParamValkyrieCommon>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<DivaParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<MenuDivaVoiceTable>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<MenuDivaVoiceTableCos>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<MusicCameraParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<MusicDirectionBoolParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<MusicDirectionParamBase>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<MusicExtensionPrefabMovieParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<MusicExtensionPrefabParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<MusicStageChangerParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<MusicVoiceChangerParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<StageParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<ValkyrieColorParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<ValkyrieIntroParam>
        // |-AssetBundleLoadAllAssetOperationBase.GetAsset<TexUVList>
        // */

        // // RVA: 0xE0F77C Offset: 0xE0F77C VA: 0xE0F77C Slot: 8
        public override bool IsError()
        {
            return false;
        }

        // // RVA: 0xE0F784 Offset: 0xE0F784 VA: 0xE0F784 Slot: 11
        public virtual void ForEach(Action<UnityEngine.Object> action)
        {
            return;
        }
    }
}