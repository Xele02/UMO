using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class HelpListScene : TransitionRoot
	{
		private HelpListWindow m_windowUi; // 0x48
		private List<HelpListElemShort> m_elems; // 0x4C
		private SwapScrollList m_scrollList; // 0x50
		private List<HelpListCategoryInfo> m_infoList; // 0x54

		// RVA: 0xE32890 Offset: 0xE32890 VA: 0xE32890 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0xE32948 Offset: 0xE32948 VA: 0xE32948 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_windowUi.Hide();
			Initialize();
		}

		// RVA: 0xE32E60 Offset: 0xE32E60 VA: 0xE32E60 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			m_windowUi.transform.SetAsLastSibling();
			return base.IsEndPostSetCanvas();
		}

		// RVA: 0xE32EBC Offset: 0xE32EBC VA: 0xE32EBC Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_windowUi.Enter();
		}

		// RVA: 0xE32EE8 Offset: 0xE32EE8 VA: 0xE32EE8 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_windowUi.IsPlaying();
		}

		// RVA: 0xE32F18 Offset: 0xE32F18 VA: 0xE32F18 Slot: 14
		protected override void OnDestoryScene()
		{
			return;
		}

		// RVA: 0xE32F20 Offset: 0xE32F20 VA: 0xE32F20 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_windowUi.Leave();
		}

		// RVA: 0xE32F4C Offset: 0xE32F4C VA: 0xE32F4C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_windowUi.IsPlaying();
		}

		//// RVA: 0xE32988 Offset: 0xE32988 VA: 0xE32988
		private void Initialize()
		{
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0xE33494
				OnUpdateListItem(index, content as HelpListContent, m_infoList[index]);
			});
			List<VeiwOptionHelpCategoryData> data = VeiwOptionHelpCategoryData.CreateList();
			m_infoList = new List<HelpListCategoryInfo>(data.Count);
			for(int i = 0; i < data.Count; i++)
			{
				m_infoList.Add(new HelpListCategoryInfo(data[i]));
			}
			m_scrollList.SetItemCount(m_infoList.Count);
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		//// RVA: 0xE32F1C Offset: 0xE32F1C VA: 0xE32F1C
		//private void Release() { }

		//// RVA: 0xE32F7C Offset: 0xE32F7C VA: 0xE32F7C
		private void OnUpdateListItem(int index, HelpListContent content, HelpListCategoryInfo info)
		{
			content.GetElemUI<HelpListElemShort>().SetLabel(info.name);
		}

		//// RVA: 0xE33048 Offset: 0xE33048 VA: 0xE33048
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			if (value != 0)
				return;
			OnClickCategoryButton(content.Index);
		}

		//// RVA: 0xE3308C Offset: 0xE3308C VA: 0xE3308C
		private void OnClickCategoryButton(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.HelpPopupWindowControl.Show(this, m_infoList[index].uniqueId, () =>
			{
				//0x952910
				MenuScene.Instance.InputEnable();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E1A8C Offset: 0x6E1A8C VA: 0x6E1A8C
		//// RVA: 0xE328C0 Offset: 0xE328C0 VA: 0xE328C0
		private IEnumerator Co_LoadResources()
		{
			//0x95378C
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E1B04 Offset: 0x6E1B04 VA: 0x6E1B04
		//// RVA: 0xE332F4 Offset: 0xE332F4 VA: 0xE332F4
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x18
			Font systemFont; // 0x1C
			int bundleLoadCount; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			int poolSize; // 0x28
			int i; // 0x2C

			//0x952CD8
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/090.xab");
			bundleLoadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_HelpListWindow");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x9529B4
				instance.transform.SetParent(transform, false);
				m_windowUi = instance.GetComponent<HelpListWindow>();
				m_scrollList = instance.GetComponentInChildren<SwapScrollList>();
			}));
			poolSize = 10;
			bundleLoadCount++;
			m_elems = new List<HelpListElemShort>(10);
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_HelpListElemShort");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x952AF8
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format("HelpListShortElem {0:D2}", 0);
				m_scrollList.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
				m_elems.Add(instance.GetComponent<HelpListElemShort>());
			}));
			bundleLoadCount++;
			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format("HelpListShortElem {0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_scrollList.AddScrollObject(r.GetComponent<SwapScrollListContent>());
				m_elems.Add(r.GetComponent<HelpListElemShort>());
			}
			for(i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_windowUi.ApplyForCategoryList(m_scrollList);
			yield return Co.R(Co_WaitUntil(m_windowUi.IsLoaded)); // ?
			for(i = 0; i < m_elems.Count; i++)
			{
				yield return Co.R(Co_WaitUntil(m_elems[i].IsLoaded));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E1B7C Offset: 0x6E1B7C VA: 0x6E1B7C
		//// RVA: 0xE3337C Offset: 0xE3337C VA: 0xE3337C
		//private IEnumerator Co_WaitWhile(Func<bool> condition) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E1BF4 Offset: 0x6E1BF4 VA: 0x6E1BF4
		//// RVA: 0xE33404 Offset: 0xE33404 VA: 0xE33404
		private IEnumerator Co_WaitUntil(Func<bool> condition)
		{
			//0x9538D8
			while (!condition())
				yield return null;
		}
	}
}
