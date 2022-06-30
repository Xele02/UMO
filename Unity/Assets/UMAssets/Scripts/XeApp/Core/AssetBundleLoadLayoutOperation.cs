
using System;
using System.Collections;
using UnityEngine;

namespace XeApp.Core
{
    public class AssetBundleLoadLayoutOperation : AssetBundleLoadLayoutOperationBase
    {
        protected LoadedAssetBundle m_loadedAssetBundle; // 0x1C

        // RVA: 0xE0FD2C Offset: 0xE0FD2C VA: 0xE0FD2C
        public AssetBundleLoadLayoutOperation(string bundleName, string assetName) : base(bundleName, assetName)
        {

        }

        // RVA: 0xE0FD30 Offset: 0xE0FD30 VA: 0xE0FD30 Slot: 7
        public override bool Update()
        { 
            if(m_request != null)
                return !IsDone();
            m_loadedAssetBundle = AssetBundleManager.GetLoadedAssetBundle(m_AssetBundleName, out m_loadingError);
            if(m_loadedAssetBundle != null)
            {
                m_request = m_loadedAssetBundle.m_AssetBundle.LoadAssetAsync(m_AssetName, m_Type);
            }
            return IsError();
        }

        // [IteratorStateMachineAttribute] // RVA: 0x747EE0 Offset: 0x747EE0 VA: 0x747EE0
        // RVA: 0xE0FE3C Offset: 0xE0FE3C VA: 0xE0FE3C Slot: 11
        public override IEnumerator InitializeLayoutCoroutine(Font font, Action<GameObject> finish)
        {
            //0xE110FC
            UnityEngine.Debug.LogError("TODO AssetBundleLoadLayoutOperation InitializeLayoutCoroutine");
            finish(null);
            yield break;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x747F58 Offset: 0x747F58 VA: 0x747F58
        // // RVA: 0xE0FF1C Offset: 0xE0FF1C VA: 0xE0FF1C Slot: 12
        // public override IEnumerator CreateLayoutCoroutine(LayoutUGUIRuntime runtime, Font font, Action<Layout, TexUVListManager> finish) { }
    }
}