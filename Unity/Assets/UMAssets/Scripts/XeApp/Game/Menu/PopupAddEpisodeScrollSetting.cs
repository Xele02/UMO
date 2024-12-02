
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupAddEpisodeScrollSetting : PopupSetting
	{
		public PopupAddEpisodeContentSetting m_setting; // 0x3C

		public List<int> EpisodeIds { get; set; } // 0x34
		public LayoutPopupAddEpisode.Type Type { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x132F954
		public override string BundleName { get { return "ly/057.xab"; } } //0x132F9B0
		public override string AssetName { get { return "root_pop_ep2_layout_root"; } } //0x132FA0C
		public virtual string ListItemAssetName { get { return "root_pop_ep2_cont_layout_root"; } } //0x132FA68
		public virtual string PopupItemAssetName { get { return "root_pop_ep_layout_root"; } } //0x132FAC4
		public override bool IsAssetBundle { get { return true; } } //0x132FB20
		public override bool IsPreload { get { return true; } } //0x132FB28
		public override GameObject Content { get { return m_content; } } //0x132FB30

		//// RVA: 0x132FB38 Offset: 0x132FB38 VA: 0x132FB38
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70CE84 Offset: 0x70CE84 VA: 0x70CE84
		//								// RVA: 0x132FB40 Offset: 0x132FB40 VA: 0x132FB40 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			XeSys.FontInfo font; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20
			LayoutPopupAddEpisodeScrollItemList window; // 0x24
			int i; // 0x28

			//0x132FE88
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			LayoutUGUIRuntime runtime = null;
			font = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, PopupItemAssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x132FC20
				PopupAddEpisodeContentSetting s = new PopupAddEpisodeContentSetting();
				instance.transform.SetParent(m_parent.transform, false);
				s.m_parent = parent;
				s.IsCaption = false;
				s.WindowSize = SizeType.Middle;
				s.SetContent(instance);
				m_setting = s;
			}));
			List<SwapScrollListContent> scrollObjects = new List<SwapScrollListContent>();
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, ListItemAssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x132FDA8
				runtime = instance.GetComponent<LayoutUGUIRuntime>();
				scrollObjects.Add(runtime.GetComponent<SwapScrollListContent>());
			}));
			window = Content.GetComponent<LayoutPopupAddEpisodeScrollItemList>();
			for(i = 1; i < window.ScrollList.ScrollObjectCount; i++)
			{
				LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.UvMan = runtime.UvMan;
				r.Layout = runtime.Layout.DeepClone();
				r.LoadLayout();
				scrollObjects.Add(r.GetComponent<SwapScrollListContent>());
			}
			for(i = 0; i < scrollObjects.Count; i++)
			{
				while(!scrollObjects[i].IsLoaded())
					yield return null;
				window.ScrollList.AddScrollObject(scrollObjects[i]);
			}
			window.ScrollList.Apply();
			yield return null;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x70CEFC Offset: 0x70CEFC VA: 0x70CEFC
		//[DebuggerHiddenAttribute] // RVA: 0x70CEFC Offset: 0x70CEFC VA: 0x70CEFC
		//						  // RVA: 0x132FC10 Offset: 0x132FC10 VA: 0x132FC10
		//private IEnumerator<> n__0(Transform parent) { }
	}
}
