using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvResultLayout : LayoutUGUIScriptBase
	{
		public enum ScrollItemType
		{
			Header = 1,
			RankingHeader = 2,
			RankingRewardItem = 3,
			PointRewardItem = 4,
		}

		private LayoutUGUIRuntime m_Runtime; // 0x14
		private ScrollRect m_ScrollRect; // 0x18
		private Transform m_ScrollContent; // 0x1C
		private FlexibleItemScrollView m_fxScrollView; // 0x20
		private AbsoluteLayout m_PopupTypeAnim; // 0x24
		private AbsoluteLayout m_popupTitle01; // 0x28
		private AbsoluteLayout m_popupTitle02; // 0x2C
		private AbsoluteLayout m_leftTitleAnim; // 0x30
		private AbsoluteLayout m_rightTitleAnim; // 0x34
		private Text[] m_numTexts; // 0x38
		private Text[] m_unitTexts; // 0x3C
		private NumberBase m_EventHiScore; // 0x40
		private PopupRewardEvResult.Type m_SetType = PopupRewardEvResult.Type.NONE; // 0x44

		// public ScrollRect GetScrollRect { get; } 0x1144AAC
		// public Transform GetScrollContent { get; } 0x1144AB4
		public FlexibleItemScrollView FxScrollView { get { return m_fxScrollView; } } //0x1144ABC
		public PopupRewardEvResult.Type SetType { set { m_SetType = value; } } //0x1144AC4

		// RVA: 0x1144ACC Offset: 0x1144ACC VA: 0x1144ACC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Runtime = GetComponent<LayoutUGUIRuntime>();
			m_PopupTypeAnim = m_Runtime.Layout.FindViewByExId("root_pop_reward_ev_result_swtbl_pop_reward_ev_result") as AbsoluteLayout;
			AbsoluteLayout l = layout.FindViewByExId("swtbl_pop_reward_ev_result_pop_reward_ev_win_01") as AbsoluteLayout;
			m_leftTitleAnim = l.FindViewByExId("pop_reward_ev_win_swtbl_pop_reward_ev_fnt") as AbsoluteLayout;
			l = layout.FindViewByExId("swtbl_pop_reward_ev_result_pop_reward_ev_win_02") as AbsoluteLayout;
			m_rightTitleAnim = l.FindViewByExId("pop_reward_ev_win_swtbl_pop_reward_ev_fnt") as AbsoluteLayout;
			m_popupTitle01 = layout.FindViewByExId("swtbl_pop_reward_ev_result_sw_pop_reward_ev_title_01_anim") as AbsoluteLayout;
			m_popupTitle02 = layout.FindViewByExId("swtbl_pop_reward_ev_result_sw_pop_reward_ev_title_02_anim") as AbsoluteLayout;
			Text[] txts = m_Runtime.GetComponentsInChildren<Text>(true);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			txts.Where((Text _) =>
			{
				//0x1146678
				return _.name == "desc (TextView)";
			}).First().text = bk.GetMessageByLabel("event_reward_result_present_box");
			m_numTexts = txts.Where((Text _) =>
			{
				//0x11466F8
				return _.name == "num (TextView)";
			}).Reverse().ToArray();
			m_unitTexts = txts.Where((Text _) =>
			{
				//0x1146778
				return _.name == "unit (TextView)";
			}).Reverse().ToArray();
			NumberBase[] nbrs = m_Runtime.GetComponentsInChildren<NumberBase>(true);
			m_EventHiScore = nbrs.Where((NumberBase _) =>
			{
				//0x11467F8
				return _.name == "swnum_event_score (AbsoluteLayout)";
			}).First();
			m_ScrollRect = GetComponentInChildren<ScrollRect>(true);
			m_ScrollContent = m_ScrollRect.transform.Find("Content");
			m_ScrollRect.horizontal = false;
			m_ScrollRect.vertical = true;
			m_ScrollRect.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			m_ScrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			m_ScrollRect.gameObject.GetComponentInChildren<VerticalLayoutGroup>(true).enabled = false;
			m_ScrollRect.gameObject.GetComponentInChildren<ContentSizeFitter>(true).enabled = false;
			m_ScrollRect.gameObject.GetComponentInChildren<LayoutElement>(true).enabled = false;
			m_fxScrollView = new FlexibleItemScrollView();
			m_fxScrollView.Initialize(m_ScrollRect);
			Loaded();
			return true;
		}

		// // RVA: 0x11456A4 Offset: 0x11456A4 VA: 0x11456A4
		public void Setup(PopupRewardEvResult.Type type, PopupRewardEvResult.ViewRewardEvResultData view)
		{
			switch(type)
			{
				case PopupRewardEvResult.Type.CumulativePoint:
					m_numTexts[1].text = view.CurrentPoint.ToString();
					m_unitTexts[1].text = MessageManager.Instance.GetMessage("menu", "popup_event_reward_currentpoint_unit");
					break;
				case PopupRewardEvResult.Type.Rankings:
					m_numTexts[1].text = view.Rank.ToString();
					m_unitTexts[1].text = MessageManager.Instance.GetMessage("menu", "popup_event_reward_currentrank_unit");
					if(view.EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
					{
						m_numTexts[3].text = view.CurrentPoint.ToString();
						m_unitTexts[3].text = "";
					}
					else if(view.EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
					{
						m_numTexts[2].text = view.CurrentPoint.ToString();
						m_unitTexts[2].text = JpStringLiterals.StringLiteral_19538;
					}
					else
					{
						m_numTexts[3].text = view.CurrentPoint.ToString();
						m_unitTexts[3].text = MessageManager.Instance.GetMessage("menu", "popup_event_reward_currentpoint_unit");
					}
					break;
				case PopupRewardEvResult.Type.RankingsEventHiScore:
					m_EventHiScore.SetNumber(view.evHighScore);
					m_numTexts[1].text = view.evScoreRank.ToString();
					m_unitTexts[1].text = MessageManager.Instance.GetMessage("menu", "popup_event_reward_currentrank_unit");
					break;
				case PopupRewardEvResult.Type.RankingsEventBattleHiScore:
					m_EventHiScore.SetNumber((int)view.CurrentPoint);
					m_numTexts[1].text = view.Rank.ToString();
					m_unitTexts[1].text = MessageManager.Instance.GetMessage("menu", "popup_event_reward_currentrank_unit");
					break;
				case PopupRewardEvResult.Type.RankingGoDivaEvent:
					m_EventHiScore.SetNumber(view.evHighScore);
					m_numTexts[1].text = view.Rank.ToString();
					m_unitTexts[1].text = MessageManager.Instance.GetMessage("menu", "popup_event_reward_currentrank_unit");
					break;
			}
		}

		// // RVA: 0x1145FD8 Offset: 0x1145FD8 VA: 0x1145FD8
		public void SetPopupType(PopupRewardEvResult.Type type, PopupRewardEvResult.ViewRewardEvResultData view)
		{
			switch(type)
			{
				case PopupRewardEvResult.Type.CumulativePoint:
					m_PopupTypeAnim.StartChildrenAnimGoStop("01");
					m_leftTitleAnim.StartChildrenAnimGoStop("02");
					m_popupTitle01.StartAllAnimGoStop("go_in", "st_in");
					m_popupTitle02.StartAllAnimGoStop("sw_wait");
					break;
				case PopupRewardEvResult.Type.Rankings:
					m_PopupTypeAnim.StartChildrenAnimGoStop("02");
					m_leftTitleAnim.StartChildrenAnimGoStop("01");
					if(view.EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
					{
						m_rightTitleAnim.StartChildrenAnimGoStop("05");
					}
					else if(view.EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
					{
						m_rightTitleAnim.StartChildrenAnimGoStop("10");
					}
					else
					{
						m_rightTitleAnim.StartChildrenAnimGoStop("02");
					}
					m_popupTitle01.StartAllAnimGoStop("sw_wait");
					m_popupTitle02.StartAllAnimGoStop("go_in", "st_in");
					break;
				case PopupRewardEvResult.Type.RankingsEventHiScore:
					m_PopupTypeAnim.StartChildrenAnimGoStop("03");
					m_popupTitle01.StartAllAnimGoStop("sw_wait");
					m_popupTitle02.StartAllAnimGoStop("go_in", "st_in");
					break;
				case PopupRewardEvResult.Type.RankingsEventBattleHiScore:
					m_PopupTypeAnim.StartChildrenAnimGoStop("04");
					m_leftTitleAnim.StartChildrenAnimGoStop("01");
					m_rightTitleAnim.StartChildrenAnimGoStop("02");
					m_popupTitle01.StartAllAnimGoStop("sw_wait");
					m_popupTitle02.StartAllAnimGoStop("go_in", "st_in");
					break;
				case PopupRewardEvResult.Type.RankingGoDivaEvent:
					m_PopupTypeAnim.StartChildrenAnimGoStop("05");
					m_rightTitleAnim.StartChildrenAnimGoStop("12");
					m_popupTitle01.StartAllAnimGoStop("sw_wait");
					m_popupTitle02.StartAllAnimGoStop("go_in", "st_in");
					break;
			}
		}

		// // RVA: 0x11464C8 Offset: 0x11464C8 VA: 0x11464C8
		public bool IsPlayTitleAnime(PopupRewardEvResult.Type type)
		{
			if(type == PopupRewardEvResult.Type.CumulativePoint)
				return m_popupTitle01.IsPlayingAll();
			else if(type >= PopupRewardEvResult.Type.Rankings && type <= PopupRewardEvResult.Type.RankingGoDivaEvent)
				return m_popupTitle02.IsPlayingAll();
			return false;
		}

		// // RVA: 0x1146518 Offset: 0x1146518 VA: 0x1146518
		public void StartTitleLoop(PopupRewardEvResult.Type type)
		{
			if(type == PopupRewardEvResult.Type.CumulativePoint)
				m_popupTitle01.StartAllAnimLoop("logo_up", "loen_up");
			else if(type >= PopupRewardEvResult.Type.Rankings && type <= PopupRewardEvResult.Type.RankingGoDivaEvent)
				m_popupTitle02.StartAllAnimLoop("logo_up", "loen_up");
		}
	}
}
