using System;
using System.Collections;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Core
{
    public abstract class AssetBundleLoadLayoutOperationBase : AssetBundleLoadAssetOperationFull
    {
        // RVA: 0xE0F9CC Offset: 0xE0F9CC VA: 0xE0F9CC
        public AssetBundleLoadLayoutOperationBase(string bundleName, string prefabName) : base (bundleName, prefabName, typeof(GameObject))
        {
			return;
        }

        // RVA: -1 Offset: -1 Slot: 11
        public abstract IEnumerator InitializeLayoutCoroutine(Font font, Action<GameObject> finish);

        // RVA: -1 Offset: -1 Slot: 12
        public abstract IEnumerator CreateLayoutCoroutine(LayoutUGUIRuntime runtime, Font font, Action<Layout, TexUVListManager> finish);
    }
}
