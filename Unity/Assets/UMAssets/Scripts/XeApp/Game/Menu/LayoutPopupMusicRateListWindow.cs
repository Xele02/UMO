using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using XeSys;
using System.Text;

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
			return m_scrollView.IsCacheLoaded();
		}

		//// RVA: 0x1736E00 Offset: 0x1736E00 VA: 0x1736E00
		public void SetStatus(PopupWindowControl control, GHLGEECLCMH view, bool a_tab = true)
		{
			m_view = view;
			m_control = control;
			m_enable_tab = a_tab;
			m_list_musicrate = view.BGMPAMNAKHN_GetMusicRateList(0);
			SetupListMusicrate(m_list_musicrate);
			SetTotalGrade(m_view.DEMOACDDPHM_PrevUtaRateTotal, m_view.ECMFBEHEGEH_UtaRateTotal);
			if(m_enable_tab)
			{
				m_list_musicgrade = view.IEPGAGBLHBN_GetMusicGradeList();
				SetupListMusicgrade(m_list_musicgrade);
			}
			SetNextGrade(m_view);
			HighScoreRatingRank.Type ratingRank = m_view.LLNHMMBFPMA_ScoreRatingRanking;
			m_textGrade.text = HighScoreRatingRank.GetRankName(ratingRank);
			GameManager.Instance.MusicRatioTextureCache.Load(ratingRank, (IiconTexture texture) =>
			{
				//0x1738D34
				if (texture != null)
				{
					MusicRatioTextureCache.MusicRatioTexture t = texture as MusicRatioTextureCache.MusicRatioTexture;
					if (t != null)
					{
						t.Set(m_imageGrade, ratingRank);
					}
				}
			});
		}

		//// RVA: 0x1737B70 Offset: 0x1737B70 VA: 0x1737B70
		public void UpdateListMusicGrade(GHLGEECLCMH view)
		{
			if (!m_enable_tab)
				return;
			m_list_musicgrade = m_view.IEPGAGBLHBN_GetMusicGradeList();
			SetupListMusicgrade(m_list_musicgrade);
		}

		//// RVA: 0x1737354 Offset: 0x1737354 VA: 0x1737354
		public void SetTotalGrade(int total0, int total)
		{
			m_textTotalNum[0].text = total0.ToString();
			m_textTotalNum[1].text = total.ToString();
			m_layoutTotal.StartChildrenAnimGoStop(total0 < total ? "02" : "01");
		}

		//// RVA: 0x1737834 Offset: 0x1737834 VA: 0x1737834
		public void SetNextGrade(GHLGEECLCMH a_view)
		{
			if(a_view == null)
			{
				m_layoutNextRate.StartChildrenAnimGoStop("03");
			}
			else
			{
				if((int)a_view.LLNHMMBFPMA_ScoreRatingRanking < HighScoreRatingRank.GetRankIDMax())
				{
					m_layoutNextRate.StartChildrenAnimGoStop("01");
					HighScoreRating.UtaGradeData utaGrade = a_view.CMANMLGFJMM_GetNextUtaGradeInfo();
					HighScoreRatingRank.Type grade = (HighScoreRatingRank.Type)utaGrade.grade;
					StringBuilder str = new StringBuilder();
					str.SetFormat("{0}", utaGrade.rate);
					m_textNextRate_02.text = str.ToString();
					m_textNextRate_04.text = HighScoreRatingRank.GetRankName(grade);
					GameManager.Instance.MusicRatioTextureCache.Load(grade, (IiconTexture texture) =>
					{
						//0x1738E0C
						if(texture != null)
						{
							MusicRatioTextureCache.MusicRatioTexture t = texture as MusicRatioTextureCache.MusicRatioTexture;
							if(t != null)
							{
								t.Set(m_imageNextGrade, grade);
							}
						}
					});
					return;
				}
				m_layoutNextRate.StartChildrenAnimGoStop("02");
			}
		}

		//// RVA: 0x1737BC4 Offset: 0x1737BC4 VA: 0x1737BC4
		public void ChangeTab(PopupTabButton.ButtonLabel a_label)
		{
			if (a_label == PopupTabButton.ButtonLabel.MusicRateDetail)
			{
				if (m_listItem_MusicRate == null)
					return;
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_control.m_titleText.text = bk.GetMessageByLabel("popup_music_rate_title");
				m_scrollView.SetupListItem(m_listItem_MusicRate);
				m_scrollView.SetlistTop(0);
				m_scrollView.SetZeroVelocity();
				m_scrollView.VisibleRangeUpdate();
				m_textScroll.enabled = m_listItem_MusicRate.Count < 1;
			}
			else if (a_label == PopupTabButton.ButtonLabel.MusicGradeView)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_control.m_titleText.text = bk.GetMessageByLabel("popup_music_grade_title");
				m_scrollView.SetupListItem(m_listItem_MusicGrade);
				m_scrollView.SetlistBottom(Mathf.Min(m_now_grade_index + 3, m_listItem_MusicGrade.Count - 1));
				m_scrollView.SetZeroVelocity();
				m_scrollView.VisibleRangeUpdate();
				m_textScroll.enabled = m_listItem_MusicGrade.Count < 1;
			}
		}

		//// RVA: 0x1737098 Offset: 0x1737098 VA: 0x1737098
		private void SetupListMusicrate(List<ECEPJHGMGBJ> a_list)
		{
			m_listItem_MusicRate = new List<IFlexibleListItem>();
			for (int i = 0; i < a_list.Count; i++)
			{
				LayoutMusicRateList.FlexibleListItem_Rate item = new LayoutMusicRateList.FlexibleListItem_Rate();
				item.Index = i;
				item.Top = new Vector2(0, -(i * 116 + 10));
				item.Height = 116;
				item.ResourceType = 2;
				item.ViewData = a_list[i];
				m_listItem_MusicRate.Add(item);
			}
		}

		//// RVA: 0x17374C4 Offset: 0x17374C4 VA: 0x17374C4
		private void SetupListMusicgrade(List<HighScoreRating.UtaGradeData> a_list)
		{
			m_listItem_MusicGrade = new List<IFlexibleListItem>();
			for(int i = 0; i < a_list.Count; i++)
			{
				if(a_list[i].isNow)
				{
					m_now_grade_index = i;
				}
				LayoutMusicRateList.FlexibleListItem_Grade data = new LayoutMusicRateList.FlexibleListItem_Grade();
				data.Top = new Vector2(0, -(i * 62 + 10));
				data.Height = 62;
				data.ResourceType = 1;
				data.MusicGrade = (HighScoreRatingRank.Type)a_list[i].grade;
				data.MusicGradeName = HighScoreRatingRank.GetRankName(data.MusicGrade);
				data.MusicMustRate = string.Format("{0}", a_list[i].rate);
				data.MySelf = a_list[i].isNow;
				m_listItem_MusicGrade.Add(data);
			}
		}

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
