using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{ 
	public class PopupAddMusicMultiSetting : PopupSetting
	{
		public PopupUnlock.UnlockInfo UnlockInfo { get; set; } // 0x34
		public override string BundleName { get { return "ly/047.xab"; } } //0x1331624
		public override string AssetName { get { return "root_pop_music_ul_window_layout_root"; } } //0x1331680
		public virtual string ListItemAssetName { get { return "root_pop_music_ul_list_layout_root"; } } //0x13316DC
		public override string PrefabPath { get { return ""; } } //0x1331738
		public override bool IsAssetBundle { get { return true; } } //0x1331794
		public override bool IsPreload { get { return false; } } //0x133179C
		public override GameObject Content { get { return m_content; } } //0x13317A4

		//// RVA: 0x13317AC Offset: 0x13317AC VA: 0x13317AC
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70FE3C Offset: 0x70FE3C VA: 0x70FE3C
		//// RVA: 0x13317B4 Offset: 0x13317B4 VA: 0x13317B4 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			AssetBundleLoadLayoutOperationBase layOp; // 0x1C
			LayoutPopAddMusicMulti window; // 0x20

			//0x133190C
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return base.LoadAssetBundlePrefab(parent);
			layOp = AssetBundleManager.LoadLayoutAsync(BundleName, ListItemAssetName);
			yield return layOp;
			LayoutUGUIRuntime runtime = null;
			yield return layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x133188C
				runtime = instance.GetComponent<LayoutUGUIRuntime>();
			});
			window = Content.GetComponent<LayoutPopAddMusicMulti>();
			for(int i = 3; i > 0; i--)
			{
				LayoutUGUIRuntime r = Object.Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.Layout = runtime.Layout.DeepClone();
				r.LoadLayout();
				window.AddScrollContent(r.GetComponent<SwapScrollListContent>());
			}
			window.AddScrollContent(runtime.GetComponent<SwapScrollListContent>());
			yield return null;
			window.ApplyScrollContent();
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
		}

		//[DebuggerHiddenAttribute] // RVA: 0x70FEB4 Offset: 0x70FEB4 VA: 0x70FEB4
		//[CompilerGeneratedAttribute] // RVA: 0x70FEB4 Offset: 0x70FEB4 VA: 0x70FEB4
		//// RVA: 0x133187C Offset: 0x133187C VA: 0x133187C
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
