using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupGachaBoxDetailSetting : PopupSetting // TypeDefIndex: 14067
	{
		private LayoutGachaBoxListWindow layout; // 0x3C

		public HGFPAFPGIKG View { get; set; } // 0x34
		public Action<Transform, HGFPAFPGIKG.CMEDMHFOFAH> OnSelectCallback { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x179F40C
		public override string BundleName { get { return "ly/113.xab"; } } //0x179F468
		public override string AssetName { get { return "root_gacha_box_pop_01_layout_root"; } } //0x179F4C4
		public virtual string AssetContentName { get { return "root_gacha_box_pop_01_contents_layout_root"; } } //0x179F520
		public override bool IsAssetBundle { get { return true; } } //0x179F57C
		public override bool IsPreload { get { return false; } } //0x179F584
		public override GameObject Content { get { return m_content; } } //0x179F58C

		// // RVA: 0x179F594 Offset: 0x179F594 VA: 0x179F594
		// public void SetContent(GameObject obj) { }

		// [IteratorStateMachineAttribute] // RVA: 0x70381C Offset: 0x70381C VA: 0x70381C
		// // RVA: 0x179F59C Offset: 0x179F59C VA: 0x179F59C Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			FontInfo systemFont; // 0x1C
			int poolSize; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			List<SwapScrollListContent> contentList; // 0x28
			int i; // 0x2C

			//0x179F7FC
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			layout = m_content.GetComponent<LayoutGachaBoxListWindow>();
			systemFont = GameManager.Instance.GetSystemFont();
			poolSize = layout.List.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, AssetContentName);
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x179F674
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = baseRuntime.name.Replace("(Clone)", "_00");
				layout.List.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			contentList = new List<SwapScrollListContent>();
			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime l = UnityEngine.Object.Instantiate(baseRuntime);
				l.name = baseRuntime.name.Replace("00", i.ToString("D2"));
				l.IsLayoutAutoLoad = false;
				l.Layout = baseRuntime.Layout.DeepClone();
				l.UvMan = baseRuntime.UvMan;
				l.LoadLayout();
				contentList.Add(l.GetComponent<SwapScrollListContent>());
			}
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			while(!layout.IsLoaded())
				yield return null;
			for(i = 0; i < contentList.Count; i++)
			{
				while(!contentList[i].IsLoaded())
					yield return null;
				layout.List.AddScrollObject(contentList[i]);
			}
			layout.List.Apply();
			layout.List.SetContentEscapeMode(true);
			yield return null;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x703894 Offset: 0x703894 VA: 0x703894
		// [DebuggerHiddenAttribute] // RVA: 0x703894 Offset: 0x703894 VA: 0x703894
		// // RVA: 0x179F664 Offset: 0x179F664 VA: 0x179F664
		// private IEnumerator <>n__0(Transform parent) { }
	}

	public class PopupGachaBoxDetailContent : UIBehaviour, IPopupContent
	{
		private PopupGachaBoxDetailSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private LayoutGachaBoxListWindow layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x179EFC0 Offset: 0x179EFC0 VA: 0x179EFC0 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupGachaBoxDetailSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutGachaBoxListWindow>();
			layout.textTitle = control.m_titleText;
			gameObject.SetActive(true);
		}

		// RVA: 0x179F208 Offset: 0x179F208 VA: 0x179F208 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x179F210 Offset: 0x179F210 VA: 0x179F210 Slot: 19
		public void Show()
		{
			layout.SetStatus(control.transform, setup.View);
			layout.OnSelectEvent = setup.OnSelectCallback;
			gameObject.SetActive(true);
		}

		// RVA: 0x179F308 Offset: 0x179F308 VA: 0x179F308 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x179F340 Offset: 0x179F340 VA: 0x179F340 Slot: 21
		public bool IsReady()
		{
			return layout == null || layout.IsListReady();
		}

		// RVA: 0x179F3F8 Offset: 0x179F3F8 VA: 0x179F3F8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
