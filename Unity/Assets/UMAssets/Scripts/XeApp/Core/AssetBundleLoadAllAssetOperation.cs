using System;
using UnityEngine;

namespace XeApp.Core
{
    public class AssetBundleLoadAllAssetOperation : AssetBundleLoadAllAssetOperationBase
    {
        // Fields
        protected string m_AssetBundleName; // 0x8
        protected string m_loadingError; // 0xC
        private AssetBundleRequest m_request; // 0x10

        // // Methods

        // // RVA: 0xE0F1D4 Offset: 0xE0F1D4 VA: 0xE0F1D4
        public AssetBundleLoadAllAssetOperation(string bundleName)
        {
            m_AssetBundleName = bundleName;
        }

        // // RVA: 0xE0F1F4 Offset: 0xE0F1F4 VA: 0xE0F1F4 Slot: 7
        public override bool Update()
        {
			UnityEngine.Debug.LogError("TODO");
            return false;
        }

        // // RVA: 0xE0F64C Offset: 0xE0F64C VA: 0xE0F64C Slot: 9
        public override bool IsDone()
        {
			if(IsError())
                return true;
            if(m_request != null)
                return m_request.isDone;
            return false;
        }

        // // RVA: -1 Offset: -1 Slot: 10
        public override T GetAsset<T>(string assetName)
        {
			UnityEngine.Debug.LogError("TODO");
            return default(T);
        }
        // /* GenericInstMethod :
        // |
        // |-RVA: 0x2091AC4 Offset: 0x2091AC4 VA: 0x2091AC4
        // |-AssetBundleLoadAllAssetOperation.GetAsset<object>
        // */

        // // RVA: 0xE0F69C Offset: 0xE0F69C VA: 0xE0F69C Slot: 8
        public override bool IsError()
        {
            return !string.IsNullOrEmpty(m_loadingError);
        }

        // // RVA: 0xE0F6B8 Offset: 0xE0F6B8 VA: 0xE0F6B8 Slot: 11
        public override void ForEach(Action<UnityEngine.Object> action)
        {
			UnityEngine.Debug.LogError("TODO");
        }
    }
}