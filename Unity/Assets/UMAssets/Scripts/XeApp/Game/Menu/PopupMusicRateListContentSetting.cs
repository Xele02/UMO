
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{ 
	public class PopupMusicRateListContentSetting : PopupSetting
	{
		public LayoutPopupMusicRateListWindow layout; // 0x38

		public GHLGEECLCMH View { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x1697434
		public override string BundleName { get { return "ly/111.xab"; } } //0x1697490
		public override string AssetName { get { return "root_pop_m_rate_window_layout_root"; } } //0x16974EC
		public override bool IsAssetBundle { get { return true; } } //0x1697548
		public override bool IsPreload { get { return false; } } //0x1697550
		public override GameObject Content { get { return m_content; } } //0x1697558

		//// RVA: 0x1697560 Offset: 0x1697560 VA: 0x1697560
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x706974 Offset: 0x706974 VA: 0x706974
		//// RVA: 0x1697568 Offset: 0x1697568 VA: 0x1697568 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			int loadCount; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24

			//0x1697664
			loadCount = 1;
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			m_content.gameObject.SetActive(true);
			yield return null;
			layout = m_content.GetComponent<LayoutPopupMusicRateListWindow>();
			while (!layout.IsLoaded())
				yield return null;
			loadCount++;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_pop_m_rate_layout_root");
			yield return operation;
			GameObject baseInstance = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x1697648
				baseInstance = instance;
			}));
			yield return null;
			layout.ScrollView.AddLayoutCache(2, baseInstance.GetComponent<LayoutUGUIRuntime>(), 8);
			operation = null;
			loadCount++;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_m_rate_grade_layout_root");
			yield return operation;
			baseInstance = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x1697658
				baseInstance = instance;
			}));
			yield return null;
			layout.ScrollView.AddLayoutCache(1, baseInstance.GetComponent<LayoutUGUIRuntime>(), 10);
			operation = null;
			yield return null;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
			}
			m_content.gameObject.SetActive(true);
		}

		//[DebuggerHiddenAttribute] // RVA: 0x7069EC Offset: 0x7069EC VA: 0x7069EC
		//[CompilerGeneratedAttribute] // RVA: 0x7069EC Offset: 0x7069EC VA: 0x7069EC
		//// RVA: 0x1697638 Offset: 0x1697638 VA: 0x1697638
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
