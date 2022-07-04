using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Core
{
	public class AssetBundleLoadUGUIOperation : AssetBundleLoadUGUIOperationBase
	{
		protected LoadedAssetBundle m_loadedAssetBundle; // 0x1C

		// RVA: 0xE119D4 Offset: 0xE119D4 VA: 0xE119D4
		public AssetBundleLoadUGUIOperation(string bundleName, string assetName) : base(bundleName, assetName)
		{
		}

		// RVA: 0xE119D8 Offset: 0xE119D8 VA: 0xE119D8 Slot: 7
		public override bool Update()
		{
			if (m_request != null)
				return !IsDone();
			m_loadedAssetBundle = AssetBundleManager.GetLoadedAssetBundle(m_AssetBundleName, out m_loadingError);
			if(m_loadedAssetBundle != null)
			{
				m_request = m_loadedAssetBundle.m_AssetBundle.LoadAssetAsync(m_AssetName, m_Type);
			}
			return !IsError();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x748138 Offset: 0x748138 VA: 0x748138
		// RVA: 0xE11AE4 Offset: 0xE11AE4 VA: 0xE11AE4 Slot: 11
		public override IEnumerator InitializeUGUICoroutine(Font font, Action<GameObject> finish)
		{
			//0xE11CA8
#if UNITY_EDITOR
            BundleShaderInfo.Instance.FixMaterialShader(m_request.asset);
#endif
			GameObject obj = UnityEngine.Object.Instantiate(m_request.asset as GameObject);
			Text[] texts  = obj.GetComponentsInChildren<Text>(true);
			Array.ForEach(texts, (Text text) => {
				//0xE11BCC
				if(text.font  != null)
					return;
				text.font = font;
			});
			if(finish != null)
				finish(obj);
			yield break;
		}
	}
}
