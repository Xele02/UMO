
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{ 
	public class PopupLoginBonusPackSetting : PopupSetting
	{
		public CAEDGOPBDNK Data { get; set; } // 0x34
		public List<MFDJIFIIPJD> SpItems { get; set; } // 0x38
		public bool IsTelop { get; set; } // 0x3C
		public override string PrefabPath { get { return ""; } } //0x168E3AC
		public override string BundleName { get { return "ly/001.xab"; } } //0x168E408
		public override string AssetName { get { return "root_login_pop_item2_layout_root"; } } //0x168E464
		public virtual string AssetContentName { get { return "root_login_pop_item_layout_root"; } } //0x168E4C0
		public override bool IsAssetBundle { get { return true; } } //0x168E51C
		public override bool IsPreload { get { return false; } } //0x168E524
		public override GameObject Content { get { return m_content; } } //0x168E52C

		//// RVA: 0x168E534 Offset: 0x168E534 VA: 0x168E534
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x705714 Offset: 0x705714 VA: 0x705714
		// RVA: 0x168E53C Offset: 0x168E53C VA: 0x168E53C Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			LayoutPopupLoginBonusPackList layout; // 0x1C
			Font systemFont; // 0x20
			int poolSize; // 0x24
			AssetBundleLoadLayoutOperationBase operation; // 0x28
			int i; // 0x2C

			//0x168E6F8
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			layout = m_content.GetComponent<LayoutPopupLoginBonusPackList>();
			layout.InitLayoutType(Data);
			layout.SetScrollResize(PopupWindowControl.GetContentSize(WindowSize, IsCaption));
			systemFont = GameManager.Instance.GetSystemFont();
			poolSize = layout.List.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, AssetContentName);
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			List<SwapScrollListContent> contentList = new List<SwapScrollListContent>();
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x168E61C
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				contentList.Add(instance.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(baseRuntime);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				contentList.Add(r.GetComponent<SwapScrollListContent>());
			}
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			while (!layout.IsLoaded())
				yield return null;
			for(i = 0; i < contentList.Count; i++)
			{
				while (!contentList[i].IsLoaded())
					yield return null;
				layout.List.AddScrollObject(contentList[i]);
			}
			layout.List.Apply();
			layout.List.SetContentEscapeMode(true);
		}

		//[DebuggerHiddenAttribute] // RVA: 0x70578C Offset: 0x70578C VA: 0x70578C
		//[CompilerGeneratedAttribute] // RVA: 0x70578C Offset: 0x70578C VA: 0x70578C
		//// RVA: 0x168E60C Offset: 0x168E60C VA: 0x168E60C
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
