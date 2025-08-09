using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using XeSys;
using System.Collections;
using XeApp.Core;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class PopupMissionBonusListSetting : PopupSetting
	{
		public List<KPJHLACKGJF_EventMission.HLMINENBCKO> List { get; set; } // 0x34
		public override bool IsPreload { get { return true; } } //0x1BB0E14
		public override bool IsAssetBundle { get { return true; } } //0x1BB0E1C
		public override string PrefabPath { get { return ""; } } //0x1BB0E24
		public override string BundleName { get { return "ly/132.xab"; } } //0x1BB0E80
		public override string AssetName { get { return "root_pop_eve_bonus_area_layout_root"; } } //0x1BB0EDC
		public override GameObject Content { get { return m_content; } } //0x1BB0F38
	}

	public class PopupMissionBonusListContent : LayoutUGUIScriptBase, IPopupContent
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x18
		[SerializeField]
		private Text m_textDesc; // 0x1C
		private PopupMissionBonusListSetting m_setting; // 0x20
		private Coroutine m_loading; // 0x24

		public Transform Parent { get; private set; } // 0x14

		// RVA: 0x1BAFB4C Offset: 0x1BAFB4C VA: 0x1BAFB4C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}

		// RVA: 0x1BAFB64 Offset: 0x1BAFB64 VA: 0x1BAFB64 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
			m_setting = setting as PopupMissionBonusListSetting;
			m_textDesc.text = MessageManager.Instance.GetMessage("menu", "missionevent_bonus_popup_desc");
			m_loading = GameManager.Instance.StartCoroutineWatched(Co_LoadLayout());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73E504 Offset: 0x73E504 VA: 0x73E504
		// // RVA: 0x1BAFDCC Offset: 0x1BAFDCC VA: 0x1BAFDCC
		private IEnumerator Co_LoadLayout()
		{
			FontInfo systemFont; // 0x18
			string bundleName; // 0x1C
			int bundleLoadCount; // 0x20
			AssetBundleLoadLayoutOperationBase lytOp; // 0x24

			//0x1BB0688
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName = m_setting.BundleName;
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName, "root_pop_eve_bonus_layout_root");
			yield return lytOp;
			string nameFormat = "";
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1BB0504
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				nameFormat = baseRuntime.name + "_{0:D2}";
				baseRuntime.name = string.Format(nameFormat, 0);
				m_scrollList.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
			}));
			bundleLoadCount++;
			for(int i = 1; i < m_scrollList.ScrollObjectCount; i++)
			{
				LayoutUGUIRuntime l = Instantiate(baseRuntime);
				l.name = string.Format(nameFormat, i);
				l.IsLayoutAutoLoad = false;
				l.Layout = baseRuntime.Layout.DeepClone();
				l.UvMan = baseRuntime.UvMan;
				l.LoadLayout();
				m_scrollList.AddScrollObject(l.GetComponent<SwapScrollListContent>());
			}
			yield return null;
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
			SetupList(m_setting.List.Count);
			m_loading = null;
		}

		// // RVA: 0x1BAFE78 Offset: 0x1BAFE78 VA: 0x1BAFE78
		private void SetupList(int count)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
		}

		// // RVA: 0x1BAFFE0 Offset: 0x1BAFFE0 VA: 0x1BAFFE0
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutPopupMissionBonusListItem it = content as LayoutPopupMissionBonusListItem;
			if(it != null)
			{
				it.SetStatus(m_setting.List[index]);
			}
		}

		// RVA: 0x1BB014C Offset: 0x1BB014C VA: 0x1BB014C Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1BB0154 Offset: 0x1BB0154 VA: 0x1BB0154 Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
			int a = Mathf.Max(0, m_setting.List.Count - 3);
			int idx = m_setting.List.FindIndex((KPJHLACKGJF_EventMission.HLMINENBCKO _) =>
			{
				//0x1BB04EC
				return _.IPJMPBANBPP;
			});
			m_scrollList.SetPosition(Mathf.Clamp(idx, 0, a));
			m_scrollList.VisibleRegionUpdate();
		}

		// RVA: 0x1BB0418 Offset: 0x1BB0418 VA: 0x1BB0418 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1BB0450 Offset: 0x1BB0450 VA: 0x1BB0450 Slot: 10
		public bool IsReady()
		{
			return m_loading == null;
		}

		// RVA: 0x1BB0464 Offset: 0x1BB0464 VA: 0x1BB0464 Slot: 11
		public void CallOpenEnd()
		{
			return;
		}
	}
}
