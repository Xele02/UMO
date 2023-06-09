using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutMusicRateList : LayoutUGUIScriptBase
	{
		public enum Content
		{
			MusicReward = 0,
			MusicGrade = 1,
			MusicRate = 2,
			MusicRanking = 3,
		}

		public class FlexibleListItem_Rate : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public int Index { get; set; } // 0x18
			public FlexibleListItemLayout Layout { get; set; } // 0x1C
			public ECEPJHGMGBJ ViewData { get; set; } // 0x20
		}

		public class FlexibleListItem_Grade : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public HighScoreRatingRank.Type MusicGrade { get; set; } // 0x1C
			public string MusicGradeName { get; set; } // 0x20
			public string MusicMustRate { get; set; } // 0x24
			public bool MySelf { get; set; } // 0x28
		}

		public class FlexibleListItem_Reward : FlexibleListItem_Grade
		{
			public int Index { get; set; } // 0x2C
			public MFDJIFIIPJD Item { get; set; } // 0x30
			public bool Pickup { get; set; } // 0x34
			public bool Get { get; set; } // 0x35
		}

		public class FlexibleListItem_Ranking : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public int Index { get; set; } // 0x1C
		}

		[SerializeField]
		private Text[] m_textTotalNum = new Text[3]; // 0x14
		[SerializeField]
		private Text m_textGrade; // 0x18
		[SerializeField]
		private Text m_textScroll; // 0x1C
		[SerializeField]
		private Text m_textNextRate_01; // 0x20
		[SerializeField]
		private Text m_textNextRate_02; // 0x24
		[SerializeField]
		private Text m_textNextRate_03; // 0x28
		[SerializeField]
		private Text m_textNextRate_04; // 0x2C
		[SerializeField]
		private Text m_textHyphen; // 0x30
		[SerializeField]
		private Text m_textDesc; // 0x34
		[SerializeField]
		private Text m_textRanking; // 0x38
		[SerializeField]
		private RawImageEx m_imageGrade; // 0x3C
		[SerializeField]
		private RawImageEx m_imageNextGrade; // 0x40
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x44
		[SerializeField]
		private ActionButton m_buttonRanking; // 0x48
		[SerializeField]
		private ToggleButton[] m_buttonTabs; // 0x4C
		[SerializeField]
		private ToggleButtonGroup m_buttonTabsGroup; // 0x50
		private AbsoluteLayout m_layoutRoot; // 0x54
		private AbsoluteLayout m_layoutTotal; // 0x58
		private AbsoluteLayout m_layoutNextRate; // 0x5C
		private AbsoluteLayout[] m_layoutToggleButtons; // 0x60
		private GHLGEECLCMH m_view; // 0x64
		private FlexibleItemScrollView m_scrollView; // 0x68
		private List<IFlexibleListItem> m_listItem_MusicRate; // 0x84
		private List<IFlexibleListItem> m_listItem_MusicGrade; // 0x88
		private List<IFlexibleListItem> m_listItem_MusicReward; // 0x8C
		private List<IFlexibleListItem> m_listItem_MusicRanking; // 0x90
		private List<RankingListInfo> m_listRanking; // 0x94
		private int m_nowGradeIndex; // 0x98

		//public FlexibleItemScrollView FxScrollView { get; } 0x15C9B08
		public Content SelectTab { get; set; } // 0x6C
		public Action OnClickRankingButton { get; set; } // 0x70
		public Action<RankingListInfo> OnClickRankingUserButton { get; set; } // 0x74
		public Action<Content> OnClickTabsButton { get; set; } // 0x78
		public Action<Content, Action> OnPreChangeTab { get; set; } // 0x7C
		public Action<Content, FlexibleItemScrollView, List<IFlexibleListItem>> OnUpdateScrollList { get; set; } // 0x80

		//// RVA: 0x15C9B70 Offset: 0x15C9B70 VA: 0x15C9B70
		//public void Enter() { }

		//// RVA: 0x15C9BFC Offset: 0x15C9BFC VA: 0x15C9BFC
		//public void Leave() { }

		//// RVA: 0x15C9C88 Offset: 0x15C9C88 VA: 0x15C9C88
		//public void Show() { }

		//// RVA: 0x15C9D08 Offset: 0x15C9D08 VA: 0x15C9D08
		//public void Hide() { }

		//// RVA: 0x15C9D88 Offset: 0x15C9D88 VA: 0x15C9D88
		//public bool IsPlaying() { }

		//// RVA: 0x15C9DB4 Offset: 0x15C9DB4 VA: 0x15C9DB4
		//public bool IsListReady() { }

		//// RVA: 0x15C9DE0 Offset: 0x15C9DE0 VA: 0x15C9DE0
		//public void SetStatus(GHLGEECLCMH view, LayoutMusicRateList.Content tab, bool posReset = True) { }

		//// RVA: 0x15CACAC Offset: 0x15CACAC VA: 0x15CACAC
		//public void SetTotalGrade(int total0, int total) { }

		//// RVA: 0x15CB188 Offset: 0x15CB188 VA: 0x15CB188
		//public void SetNextGrade(LayoutMusicRateList.Content tab, GHLGEECLCMH view) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6ED414 Offset: 0x6ED414 VA: 0x6ED414
		//// RVA: 0x15CB524 Offset: 0x15CB524 VA: 0x15CB524
		//private IEnumerator Co_ChangeTab(LayoutMusicRateList.Content tab) { }

		//// RVA: 0x15CAE1C Offset: 0x15CAE1C VA: 0x15CAE1C
		//public void ChangeTab(LayoutMusicRateList.Content tab, bool posReset = True) { }

		//// RVA: 0x15CB5EC Offset: 0x15CB5EC VA: 0x15CB5EC
		//public void UpdateRankingList(List<RankingListInfo> infoList, Action<FlexibleItemScrollView, List<IFlexibleListItem>> onUpdateScrollList) { }

		//// RVA: 0x15CB7C0 Offset: 0x15CB7C0 VA: 0x15CB7C0
		//public void SetNextRewardListPos(int nowPos) { }

		//// RVA: 0x15CB95C Offset: 0x15CB95C VA: 0x15CB95C
		//public void SetRankRange(string text) { }

		//// RVA: 0x15CA1D8 Offset: 0x15CA1D8 VA: 0x15CA1D8
		//private void MakeList_Rate(List<ECEPJHGMGBJ> list) { }

		//// RVA: 0x15CA3F0 Offset: 0x15CA3F0 VA: 0x15CA3F0
		//private void MakeList_Grade(List<HighScoreRating.UtaGradeData> list) { }

		//// RVA: 0x15CA710 Offset: 0x15CA710 VA: 0x15CA710
		//private void MakeList_Reward(HighScoreRatingRank.Type grade, List<HighScoreRating.UtaGradeData> list) { }

		//// RVA: 0x15CAAD8 Offset: 0x15CAAD8 VA: 0x15CAAD8
		//private void MakeList_Ranking(int count) { }

		//// RVA: 0x15CBA5C Offset: 0x15CBA5C VA: 0x15CBA5C
		private void OnUpdateListItem(IFlexibleListItem item)
		{
			TodoLogger.Log(0, "OnUpdateListItem");
		}

		//// RVA: 0x15CBFC4 Offset: 0x15CBFC4 VA: 0x15CBFC4
		//public void OnShowItemDetails(int itemId, int itemNum) { }

		// RVA: 0x15CC244 Offset: 0x15CC244 VA: 0x15CC244 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textTotalNum[0].text = "";
			m_textTotalNum[1].text = "";
			m_textTotalNum[2].text = "";
			m_textScroll.text = bk.GetMessageByLabel("popup_music_rate_not_found");
			m_textNextRate_01.text = bk.GetMessageByLabel("popup_music_rate_next_01");
			m_textNextRate_02.text = "---";
			m_textNextRate_03.text = bk.GetMessageByLabel("popup_music_rate_next_02");
			m_textNextRate_04.text = "---";
			m_textHyphen.text = "---";
			m_textDesc.text = bk.GetMessageByLabel("popup_music_rate_desc");

			m_layoutRoot = layout.FindViewById("sw_pop_m_rate_seane") as AbsoluteLayout;
			m_layoutTotal = layout.FindViewById("swtbl_rate_txt") as AbsoluteLayout;
			m_layoutNextRate = layout.FindViewById("swtbl_next_rate") as AbsoluteLayout;
			m_layoutToggleButtons = new AbsoluteLayout[m_buttonTabs.Length];
			for(int i = 0; i < m_layoutToggleButtons.Length; i++)
			{
				m_layoutToggleButtons[i] = layout.FindViewById(string.Format("swtbl_tab_{0:00}", i + 1)) as AbsoluteLayout;
			}
			m_buttonRanking.AddOnClickCallback(() =>
			{
				//0x15CD008
				if (OnClickRankingButton != null)
					OnClickRankingButton();
			});
			m_scrollRect.horizontal = false;
			m_scrollRect.vertical = true;
			m_scrollRect.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			m_scrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			m_scrollRect.gameObject.GetComponentInChildren<VerticalLayoutGroup>(true).enabled = false;
			m_scrollRect.gameObject.GetComponentInChildren<ContentSizeFitter>(true).enabled = false;
			m_scrollRect.gameObject.GetComponentInChildren<LayoutElement>(true).enabled = false;
			m_scrollView = new FlexibleItemScrollView();
			m_scrollView.Initialize(m_scrollRect);
			m_scrollView.UpdateItemListener += OnUpdateListItem;
			Loaded();
			return true;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6ED48C Offset: 0x6ED48C VA: 0x6ED48C
		//// RVA: 0x15CCD18 Offset: 0x15CCD18 VA: 0x15CCD18
		//private bool <ChangeTab>b__69_0(IFlexibleListItem x) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6ED49C Offset: 0x6ED49C VA: 0x6ED49C
		//// RVA: 0x15CCE20 Offset: 0x15CCE20 VA: 0x15CCE20
		//private bool <UpdateRankingList>b__70_0(IFlexibleListItem x) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6ED4AC Offset: 0x6ED4AC VA: 0x6ED4AC
		//// RVA: 0x15CCF28 Offset: 0x15CCF28 VA: 0x15CCF28
		//private void <OnUpdateListItem>b__77_0(int itemId, int itemNum) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6ED4BC Offset: 0x6ED4BC VA: 0x6ED4BC
		//// RVA: 0x15CCF94 Offset: 0x15CCF94 VA: 0x15CCF94
		//private void <OnUpdateListItem>b__77_1(RankingListInfo info) { }
	}
}
