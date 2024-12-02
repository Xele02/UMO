
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{ 
	public class PupupBingoRewardWindowSetting : PopupSetting
	{
		public int ItemId; // 0x34
		public string ItemDetailText; // 0x38
		public string QuestText; // 0x3C
		public Action<int> OnClickIcon; // 0x40
		public JJPEIELNEJB.JLHHGLANHGE[] ItemList = new JJPEIELNEJB.JLHHGLANHGE[8]; // 0x44
		public int ReceivedBingoCount; // 0x48
		public LayoutBingoRewardWindow layout; // 0x4C

		public override string PrefabPath { get { return ""; } } //0x9D4890
		public override string BundleName { get { return "ly/153.xab"; } } //0x9D48EC
		public override string AssetName { get { return "root_pop_bingo_rwd_btn_scr_layout_root"; } } //0x9D4948
		public override bool IsAssetBundle { get { return true; } } //0x9D49A4
		public override bool IsPreload { get { return false; } } //0x9D49AC
		public override GameObject Content { get { return m_content; } } //0x9D49B4

		//// RVA: 0x9D49BC Offset: 0x9D49BC VA: 0x9D49BC
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7004EC Offset: 0x7004EC VA: 0x7004EC
		// RVA: 0x9D49C4 Offset: 0x9D49C4 VA: 0x9D49C4 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			XeSys.FontInfo systemFont; // 0x1C
			int poolSize; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			List<LayoutBingoRewardContents> contentList; // 0x28
			int i; // 0x2C

			//0x9D4D54
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			layout = m_content.GetComponent<LayoutBingoRewardWindow>();
			systemFont = GameManager.Instance.GetSystemFont();
			poolSize = layout.List.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_pop_bingo_rwd_btn_layout_root");
			yield return operation;
			contentList = new List<LayoutBingoRewardContents>();
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x9D4B10
				instance.transform.SetParent(parent, false);
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name.Replace("(Clone)", "_000");
				baseRuntime.IsLayoutAutoLoad = false;
				baseRuntime.Layout = baseRuntime.Layout.DeepClone();
				baseRuntime.UvMan = baseRuntime.UvMan;
				baseRuntime.LoadLayout();
			}));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			for(i = 0; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(baseRuntime);
				r.name = baseRuntime.name.Replace("000", i.ToString("D2"));
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				contentList.Add(r.GetComponent<LayoutBingoRewardContents>());
			}
			for(i = 0; i < poolSize; i++)
			{
				while (!contentList[i].IsLoaded())
					yield return null;
				layout.List.AddScrollObject(contentList[i]);
			}
			UnityEngine.Object.Destroy(baseRuntime.gameObject);
			layout.List.Apply();
			layout.List.SetContentEscapeMode(true);
		}

		//[DebuggerHiddenAttribute] // RVA: 0x700564 Offset: 0x700564 VA: 0x700564
		//[CompilerGeneratedAttribute] // RVA: 0x700564 Offset: 0x700564 VA: 0x700564
		//// RVA: 0x9D4B00 Offset: 0x9D4B00 VA: 0x9D4B00
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
