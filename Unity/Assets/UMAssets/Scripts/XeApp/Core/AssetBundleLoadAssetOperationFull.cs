using System;
using UnityEngine;

namespace XeApp.Core
{
    public class AssetBundleLoadAssetOperationFull : AssetBundleLoadAssetOperation
    {
        protected string m_AssetBundleName; // 0x8
        protected string m_AssetName; // 0xC
        protected string m_loadingError; // 0x10
        protected Type m_Type; // 0x14
        protected AssetBundleRequest m_request; // 0x18

        // // RVA: 0xE0F7B8 Offset: 0xE0F7B8 VA: 0xE0F7B8
        public AssetBundleLoadAssetOperationFull(string bundleName, string assetName, Type type)
        {
            m_AssetBundleName = bundleName;
            m_AssetName = assetName;
            m_Type = type;
        }

        // // RVA: -1 Offset: -1 Slot: 10
        public override T GetAsset<T>()
        {
            if(IsDone())
            {
#if UNITY_EDITOR
                BundleShaderInfo.Instance.FixMaterialShader(m_request.asset);
#endif
                return m_request.asset as T;
            }
            return null;
        }
        // /* GenericInstMethod :
        // |
        // |-RVA: 0x2091DB0 Offset: 0x2091DB0 VA: 0x2091DB0
        // |-AssetBundleLoadAssetOperationFull.GetAsset<object>
        // */

        // RVA: 0xE0F7E8 Offset: 0xE0F7E8 VA: 0xE0F7E8 Slot: 7
        public override bool Update()
        {
            if(m_request == null)
            {
                LoadedAssetBundle loadedBundle = AssetBundleManager.GetLoadedAssetBundle(m_AssetBundleName, out m_loadingError);
                if(loadedBundle != null)
                {
                    m_request = loadedBundle.m_AssetBundle.LoadAssetAsync(m_AssetName, m_Type);
                }
                return !IsError();
            }
            return !IsDone();
        }

        // RVA: 0xE0F8E4 Offset: 0xE0F8E4 VA: 0xE0F8E4 Slot: 9
        public override bool IsDone()
        {
            if(m_request == null)
            {
                if(IsError())
                    return true;
                return false;
            }
            return m_request.isDone;
        }

        // RVA: 0xE0F940 Offset: 0xE0F940 VA: 0xE0F940 Slot: 8
        public override bool IsError()
        {
            return !String.IsNullOrEmpty(m_loadingError);
        }
    }
}
