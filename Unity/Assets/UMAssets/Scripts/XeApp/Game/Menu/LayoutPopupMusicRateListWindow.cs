using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicRateListWindow : LayoutUGUIScriptBase
	{
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
		private RawImageEx m_imageGrade; // 0x34
		[SerializeField]
		private RawImageEx m_imageNextGrade; // 0x38
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x3C
		[SerializeField]
		private ActionButton m_btnHelp; // 0x40
		private FlexibleItemScrollView m_scrollView; // 0x44
		private AbsoluteLayout m_layoutTotal; // 0x48
		private AbsoluteLayout m_layoutNextRate; // 0x4C
		private GHLGEECLCMH m_view; // 0x50
		private List<ECEPJHGMGBJ> m_list_musicrate; // 0x54
		private List<HighScoreRating.UtaGradeData> m_list_musicgrade; // 0x58
		private List<IFlexibleListItem> m_listItem_MusicRate; // 0x5C
		private List<IFlexibleListItem> m_listItem_MusicGrade; // 0x60
		private int m_now_grade_index; // 0x64
		private bool m_enable_tab = true; // 0x68
		private PopupWindowControl m_control; // 0x6C

		public FlexibleItemScrollView ScrollView { get { return m_scrollView; } } //0x1736DBC
		public bool EnableTab { get { return m_enable_tab; } private set { m_enable_tab = value; } } //0x1736DC4 0x1736DCC

		//// RVA: 0x1736DD4 Offset: 0x1736DD4 VA: 0x1736DD4
		public bool IsListReady()
		{
			TodoLogger.Log(0, "IsListReady");
			return true;
		}

		//// RVA: 0x1736E00 Offset: 0x1736E00 VA: 0x1736E00
		public void SetStatus(PopupWindowControl control, GHLGEECLCMH view, bool a_tab = true)
		{
			TodoLogger.Log(0, "SetStatus");
		}

		//// RVA: 0x1737B70 Offset: 0x1737B70 VA: 0x1737B70
		public void UpdateListMusicGrade(GHLGEECLCMH view)
		{
			TodoLogger.Log(0, "UpdateListMusicGrade");
		}

		//// RVA: 0x1737354 Offset: 0x1737354 VA: 0x1737354
		//public void SetTotalGrade(int total0, int total) { }

		//// RVA: 0x1737834 Offset: 0x1737834 VA: 0x1737834
		//public void SetNextGrade(GHLGEECLCMH a_view) { }

		//// RVA: 0x1737BC4 Offset: 0x1737BC4 VA: 0x1737BC4
		public void ChangeTab(PopupTabButton.ButtonLabel a_label)
		{
			TodoLogger.Log(0, "ChangeTab");
		}

		//// RVA: 0x1737098 Offset: 0x1737098 VA: 0x1737098
		//private void SetupListMusicrate(List<ECEPJHGMGBJ> a_list) { }

		//// RVA: 0x17374C4 Offset: 0x17374C4 VA: 0x17374C4
		//private void SetupListMusicgrade(List<HighScoreRating.UtaGradeData> a_list) { }

		//// RVA: 0x1737FB4 Offset: 0x1737FB4 VA: 0x1737FB4
		private void OnUpdateListItem(IFlexibleListItem a_item)
		{
			if(a_item != null)
			{
				if (a_item is LayoutMusicRateList.FlexibleListItem_Rate)
				{
					LayoutMusicRateList.FlexibleListItem_Rate item = a_item as LayoutMusicRateList.FlexibleListItem_Rate;
					LayoutPopupMusicRateListItem itemLayout = item.Layout as LayoutPopupMusicRateListItem;
					if (itemLayout != null)
					{
						itemLayout.SetStatus(item.Index, item.ViewData);
					}
				}
				else if(a_item is LayoutMusicRateList.FlexibleListItem_Grade)
				{
					LayoutMusicRateList.FlexibleListItem_Grade item = a_item as LayoutMusicRateList.FlexibleListItem_Grade;
					LayoutPopupMusicGradeListItem itemLayout = item.Layout as LayoutPopupMusicGradeListItem;
					if (itemLayout != null)
					{
						itemLayout.SetStatus(item);
					}
				}
			}
		}

		//// RVA: 0x1738214 Offset: 0x1738214 VA: 0x1738214
		private void OnHelpButton()
		{
			TodoLogger.LogNotImplemented("OnHelpButton");
		}

		// RVA: 0x1738430 Offset: 0x1738430 VA: 0x1738430 Slot: 5
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
			m_layoutTotal = layout.FindViewByExId("sw_pop_m_rate_window_swtbl_rate_txt") as AbsoluteLayout;
			m_layoutNextRate = layout.FindViewByExId("sw_pop_m_rate_window_swtbl_next_rate") as AbsoluteLayout;
			m_scrollRect = GetComponentInChildren<ScrollRect>(true);
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
			m_btnHelp.AddOnClickCallback(OnHelpButton);
			Loaded();
			return true;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x706544 Offset: 0x706544 VA: 0x706544
		//// RVA: 0x1738C74 Offset: 0x1738C74 VA: 0x1738C74
		//private void <OnHelpButton>b__37_0() { }
	}
}
