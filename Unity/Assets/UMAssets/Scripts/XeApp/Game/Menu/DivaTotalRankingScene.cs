using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Localization.SmartFormat;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DivaTotalRankingScene : RankingSceneBase
	{
		private const int s_rankingOrderMax = 100;
		private int m_select_diva_id; // 0x78
		private List<int> m_rankRangeList; // 0x7C
		private List<string> m_rankRangeLabelList; // 0x80
		private int m_currentRankRange; // 0x84
		private int m_nextRankRange; // 0x88
		private RankRangePopupSetting m_rankRangePopupSetting = new RankRangePopupSetting(); // 0x8C

		// RVA: 0x1271884 Offset: 0x1271884 VA: 0x1271884 Slot: 31
		protected override void Initialize()
		{
			HomeDivaViewCamera.Instance.Leave();
			if (Args != null && Args is DivaTotalRankingSceneArgs)
				m_select_diva_id = (Args as DivaTotalRankingSceneArgs).DivaId;
			InitializeDecos();
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetStyle(RankingListElemBase.StyleType.DivaTotalRanking);
			}
			m_windowUi.ChangePreset(GeneralListWindow.Preset.GoDivaTotalRanking, false);
			m_windowUi.onClickTotalRankButton = OnClickTotalButton;
			m_windowUi.onClickFriendRankButton = OnClickFriendButton;
			m_windowUi.onClickRankRangeButton = OnClickRankRangeButton;
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			if(CheckTransitByReturn())
			{
				m_scrollList.VisibleRegionUpdate();
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				StringBuilder str = new StringBuilder(8);
				List<int> l = LAMCONGFONF.HHCJCDFCLOB.IFHPGJGLPPF();
				m_rankRangeList = new List<int>(l.Count + 1);
				m_rankRangeList.Add(0);
				m_rankRangeList.AddRange(l);
				m_rankRangeLabelList = new List<string>(m_rankRangeList.Count);
				for(int i = 0; i < m_rankRangeList.Count; i++)
				{
					if(m_rankRangeList[i] == 0)
					{
						m_rankRangeLabelList.Add(bk.GetMessageByLabel("popup_rank_range_myself"));
					}
					else
					{
						str.SetFormatSmart(bk.GetMessageByLabel("popup_rank_range_place"), m_rankRangeList[i]);
						m_rankRangeLabelList.Add(str.ToString());
					}
				}
				m_currentRankRange = 0;
				m_windowUi.SetRankButtonLabel(m_rankRangeLabelList[0]);
				m_windowUi.SelectTotalRankingTab();
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
				ResetReceivedFlag();
				SetupTotalRanking();
			}
		}

		// RVA: 0x127219C Offset: 0x127219C VA: 0x127219C Slot: 32
		protected override void Release()
		{
			ReleaseDecos();
		}

		// RVA: 0x12721A4 Offset: 0x12721A4 VA: 0x12721A4 Slot: 34
		protected override void GetRankingList(int baseRank, int rankingIdx)
		{
			m_windowUi.SetMessageVisible(false);
			LAMCONGFONF.HHCJCDFCLOB.FAMFKPBPIAA(m_select_diva_id - 1, isFriendList, baseRank, () =>
			{
				//0x1272B6C
				OnReceivedRankingList(LAMCONGFONF.HHCJCDFCLOB.HGGPIBNLALJ);
			}, OnRankingError, OnNetError);
		}

		// RVA: 0x1272310 Offset: 0x1272310 VA: 0x1272310 Slot: 35
		protected override void GetRankingListAdditive(bool isUpper)
		{
			int a = 1;
			if (isUpper)
				a = -1;
			LAMCONGFONF.HHCJCDFCLOB.JPNACOLKHLB(GetListEdgeRank(isUpper), a, GetCurrentBaseRank(), () =>
			{
				//0x1272EF8
				OnReceivedRankingListAdditive(a, LAMCONGFONF.HHCJCDFCLOB.BMKBAMFBAPJ);
			}, OnRankingError, OnNetError);
		}

		// RVA: 0x12724D0 Offset: 0x12724D0 VA: 0x12724D0 Slot: 36
		protected override string GetRankingNotFoundMessage()
		{
			if(!isFriendList)
			{
				if (GetCurrentBaseRank() == 0)
					return MessageManager.Instance.GetMessage("menu", "ranking_ev_no_entry");
				else
					return MessageManager.Instance.GetMessage("menu", "ranking_ev_range_not_found");
			}
			else
				return MessageManager.Instance.GetMessage("menu", "ranking_ev_no_entry");
		}

		// RVA: 0x12725BC Offset: 0x12725BC VA: 0x12725BC Slot: 33
		protected override int GetCurrentBaseRank()
		{
			if(!isFriendList)
			{
				return m_rankRangeList[m_currentRankRange];
			}
			return 1;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E1284 Offset: 0x6E1284 VA: 0x6E1284
		// RVA: 0x1272654 Offset: 0x1272654 VA: 0x1272654 Slot: 39
		protected override IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x18
			XeSys.FontInfo systemFont; // 0x1C
			int bundleLoadCount; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			int i; // 0x28

			//0x1273014
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/039.xab");
			bundleLoadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GeneralListWindow");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1272BA8
				instance.transform.SetParent(transform, false);
				m_windowUi = instance.GetComponent<GeneralListWindow>();
				m_scrollList = instance.GetComponentInChildren<SwapScrollList>(true);
			}));
			bundleLoadCount++;
			yield return Co.R(Co_LoadListElem(bundleName.ToString(), "UI_DivaTotalRankingElem", systemFont, m_scrollList.ScrollObjectCount, "RankingListElem {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0x1272CC0
				m_scrollList.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
				m_elems.Add(instance.GetComponent<DivaTotalRankingListElem>());
			}));
			bundleLoadCount++;
			PopupRankRangeContent popupContent = null;
			operation = AssetBundleManager.LoadLayoutAsync(m_rankRangePopupSetting.BundleName, m_rankRangePopupSetting.AssetName);
			bundleLoadCount++;
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1272F5C
				m_rankRangePopupSetting.SetContent(instance);
				popupContent = instance.GetComponent<PopupRankRangeContent>();
			}));
			yield return Co.R(popupContent.Co_LoadElements(m_rankRangePopupSetting.BundleName));
			m_rankRangePopupSetting.SetParent(transform);
			for(i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			while (!m_windowUi.IsLoaded())
				yield return null;
			for(i = 0; i < m_elems.Count; i++)
			{
				while (!m_elems[i].IsLoaded())
					yield return null;
			}
		}

		// RVA: 0x1272700 Offset: 0x1272700 VA: 0x1272700 Slot: 37
		protected override void OnSetupTotalRanking()
		{
			m_windowUi.ChangePreset(GeneralListWindow.Preset.GoDivaTotalRanking, false);
		}

		// RVA: 0x1272734 Offset: 0x1272734 VA: 0x1272734 Slot: 38
		protected override void OnSetupFriendRanking()
		{
			m_windowUi.ChangePreset(GeneralListWindow.Preset.GoDivaTotalRankingFriend, false);
		}

		//// RVA: 0x1272768 Offset: 0x1272768 VA: 0x1272768
		private void OnClickRankRangeButton()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_rankRangePopupSetting.TitleText = bk.GetMessageByLabel("popup_rank_range_title");
			m_rankRangePopupSetting.SetParent(transform);
			m_rankRangePopupSetting.WindowSize = SizeType.Small;
			m_rankRangePopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_rankRangePopupSetting.itemLabels = m_rankRangeLabelList;
			m_rankRangePopupSetting.initialLabelIndex = m_currentRankRange;
			m_rankRangePopupSetting.onDecideIndex = OnChangedRankRange;
			m_nextRankRange = m_currentRankRange;
			PopupWindowManager.Show(m_rankRangePopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1272DBC
				if (m_currentRankRange == m_nextRankRange)
					return;
				m_currentRankRange = m_nextRankRange;
				m_windowUi.SetRankButtonLabel(m_rankRangeLabelList[m_nextRankRange]);
				MenuScene.Instance.RaycastDisable();
				GetRankingList(GetCurrentBaseRank(), 0);
			}, null, null, null);
		}

		//// RVA: 0x1272AE8 Offset: 0x1272AE8 VA: 0x1272AE8
		private void OnChangedRankRange(int rangeIndex)
		{
			m_nextRankRange = rangeIndex;
		}
	}
}
