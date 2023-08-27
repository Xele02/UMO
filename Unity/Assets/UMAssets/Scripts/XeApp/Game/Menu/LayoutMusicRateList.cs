using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using System.Collections.Generic;
using XeSys;
using System.Collections;
using mcrs;
using System.Text;

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

		public FlexibleItemScrollView FxScrollView { get { return m_scrollView; } } //0x15C9B08
		public Content SelectTab { get; set; } // 0x6C
		public Action OnClickRankingButton { get; set; } // 0x70
		public Action<RankingListInfo> OnClickRankingUserButton { get; set; } // 0x74
		public Action<Content> OnClickTabsButton { get; set; } // 0x78
		public Action<Content, Action> OnPreChangeTab { get; set; } // 0x7C
		public Action<Content, FlexibleItemScrollView, List<IFlexibleListItem>> OnUpdateScrollList { get; set; } // 0x80

		//// RVA: 0x15C9B70 Offset: 0x15C9B70 VA: 0x15C9B70
		public void Enter()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x15C9BFC Offset: 0x15C9BFC VA: 0x15C9BFC
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x15C9C88 Offset: 0x15C9C88 VA: 0x15C9C88
		//public void Show() { }

		//// RVA: 0x15C9D08 Offset: 0x15C9D08 VA: 0x15C9D08
		public void Hide()
		{
			m_layoutRoot.StartChildrenAnimGoStop("st_out", "st_out");
		}

		//// RVA: 0x15C9D88 Offset: 0x15C9D88 VA: 0x15C9D88
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingChildren();
		}

		//// RVA: 0x15C9DB4 Offset: 0x15C9DB4 VA: 0x15C9DB4
		//public bool IsListReady() { }

		//// RVA: 0x15C9DE0 Offset: 0x15C9DE0 VA: 0x15C9DE0
		public void SetStatus(GHLGEECLCMH view, Content tab, bool posReset = true)
		{
			m_view = view;
			MakeList_Rate(view.BGMPAMNAKHN_GetMusicRateList(0));
			MakeList_Grade(m_view.IEPGAGBLHBN_GetMusicGradeList());
			MakeList_Reward(m_view.LLNHMMBFPMA_ScoreRatingRanking, m_view.IEPGAGBLHBN_GetMusicGradeList());
			m_listRanking = OEGIPPCADNA.HHCJCDFCLOB.HGGPIBNLALJ;
			MakeList_Ranking(1000);
			SetTotalGrade(m_view.DEMOACDDPHM_PrevUtaRateTotal, m_view.ECMFBEHEGEH_UtaRateTotal);
			m_textGrade.text = HighScoreRatingRank.GetRankName(m_view.LLNHMMBFPMA_ScoreRatingRanking);
			HighScoreRatingRank.Type grade = m_view.LLNHMMBFPMA_ScoreRatingRanking;
			GameManager.Instance.MusicRatioTextureCache.Load(m_view.LLNHMMBFPMA_ScoreRatingRanking, (IiconTexture texture) =>
			{
				//0x15CD01C
				if(texture != null && texture is MusicRatioTextureCache.MusicRatioTexture)
				{
					(texture as MusicRatioTextureCache.MusicRatioTexture).Set(m_imageGrade, grade);
				}
			});
			m_buttonTabsGroup.SelectGroupButton((int)tab);
			m_buttonTabsGroup.OnSelectToggleButtonEvent.RemoveAllListeners();
			m_buttonTabsGroup.OnSelectToggleButtonEvent.AddListener((int tabIndex) =>
			{
				//0x15CD0F4
				this.StartCoroutineWatched(Co_ChangeTab((Content)tabIndex));
			});
			ChangeTab(tab, posReset);
		}

		//// RVA: 0x15CACAC Offset: 0x15CACAC VA: 0x15CACAC
		public void SetTotalGrade(int total0, int total)
		{
			m_textTotalNum[1].text = total.ToString();
			m_textTotalNum[0].text = total.ToString();
			m_layoutTotal.StartChildrenAnimGoStop(total0 < total ? "02" : "01");
		}

		//// RVA: 0x15CB188 Offset: 0x15CB188 VA: 0x15CB188
		public void SetNextGrade(Content tab, GHLGEECLCMH view)
		{
			if(view == null)
			{
				m_layoutNextRate.StartChildrenAnimGoStop("03");
			}
			else
			{
				if((int)view.LLNHMMBFPMA_ScoreRatingRanking < HighScoreRatingRank.GetRankIDMax())
				{
					if(tab != Content.MusicRanking)
					{
						m_layoutNextRate.StartChildrenAnimGoStop("01");
						StringBuilder str = new StringBuilder();
						HighScoreRating.UtaGradeData info = view.CMANMLGFJMM_GetNextUtaGradeInfo();
						str.SetFormat("{0}", info.rate);
						m_textNextRate_02.text = str.ToString();
						HighScoreRatingRank.Type grade_next = (HighScoreRatingRank.Type)info.grade;
						m_textNextRate_04.text = HighScoreRatingRank.GetRankName(grade_next);
						GameManager.Instance.MusicRatioTextureCache.Load(grade_next, (IiconTexture texture) =>
						{
							//0x15CD154
							if(texture != null && texture is MusicRatioTextureCache.MusicRatioTexture)
							{
								(texture as MusicRatioTextureCache.MusicRatioTexture).Set(m_imageNextGrade, grade_next);
							}
						});
					}
					else
					{
						m_layoutNextRate.StartChildrenAnimGoStop("04");
					}
				}
				else
				{
					m_layoutNextRate.StartChildrenAnimGoStop("02");
				}
			}
			m_buttonRanking.Hidden = tab != Content.MusicRanking;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6ED414 Offset: 0x6ED414 VA: 0x6ED414
		//// RVA: 0x15CB524 Offset: 0x15CB524 VA: 0x15CB524
		private IEnumerator Co_ChangeTab(Content tab)
		{
			//0x15CD244
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(OnPreChangeTab != null)
			{
				bool done = false;
				OnPreChangeTab(tab, () =>
				{
					//0x15CD234
					done = true;
				});
				while (!done)
					yield return null;
			}
			ChangeTab(tab, true);
			if (OnClickTabsButton != null)
				OnClickTabsButton(tab);
		}

		//// RVA: 0x15CAE1C Offset: 0x15CAE1C VA: 0x15CAE1C
		public void ChangeTab(Content tab, bool posReset = true)
		{
			List<IFlexibleListItem> l = null;
			string txt = "";
			switch(tab)
			{
				case Content.MusicReward:
					m_textDesc.enabled = false;
					l = m_listItem_MusicReward;
					txt = "popup_music_rate_not_found";
					break;
				case Content.MusicGrade:
					m_textDesc.enabled = false;
					l = m_listItem_MusicGrade;
					txt = "popup_music_rate_not_found";
					break;
				case Content.MusicRate:
					m_textDesc.enabled = true;
					l = m_listItem_MusicRate;
					txt = "popup_music_rate_not_found";
					break;
				case Content.MusicRanking:
					l = m_listItem_MusicRanking.FindAll((IFlexibleListItem x) =>
					{
						//0x15CCD18
						return (x as FlexibleListItem_Ranking).Index < m_listRanking.Count;
					});
					m_textDesc.enabled = false;
					txt = "popup_music_rate_ranking_not_found";
					break;
				default:
					break;
			}
			if(l != null)
			{
				m_textScroll.enabled = l.Count < 1;
				m_textScroll.text = MessageManager.Instance.GetMessage("menu", txt);
				if(posReset && OnUpdateScrollList != null)
				{
					OnUpdateScrollList(tab, m_scrollView, l);
				}
				m_scrollView.VisibleRangeUpdate();
			}
			for(int i = 0; i < m_layoutToggleButtons.Length; i++)
			{
				m_layoutToggleButtons[i].StartChildrenAnimGoStop((int)tab == i ? "02" : "01");
				SelectTab = tab;
				SetNextGrade(tab, m_view);
			}
		}

		//// RVA: 0x15CB5EC Offset: 0x15CB5EC VA: 0x15CB5EC
		public void UpdateRankingList(List<RankingListInfo> infoList, Action<FlexibleItemScrollView, List<IFlexibleListItem>> onUpdateScrollList)
		{
			m_listRanking = infoList;
			List<IFlexibleListItem> l = m_listItem_MusicRanking.FindAll((IFlexibleListItem x) =>
			{
				//0x15CCE20
				return (x as FlexibleListItem_Ranking).Index < m_listRanking.Count;
			});
			if(onUpdateScrollList != null)
				onUpdateScrollList(m_scrollView, l);
			m_textScroll.enabled = l.Count < 1;
			m_textScroll.text = MessageManager.Instance.GetMessage("menu", "popup_music_rate_ranking_not_found");
		}

		//// RVA: 0x15CB7C0 Offset: 0x15CB7C0 VA: 0x15CB7C0
		//public void SetNextRewardListPos(int nowPos) { }

		//// RVA: 0x15CB95C Offset: 0x15CB95C VA: 0x15CB95C
		public void SetRankRange(string text)
		{
			m_textRanking.text = text;
		}

		//// RVA: 0x15CA1D8 Offset: 0x15CA1D8 VA: 0x15CA1D8
		private void MakeList_Rate(List<ECEPJHGMGBJ> list)
		{
			m_listItem_MusicRate = new List<IFlexibleListItem>();
			for(int i = 0; i < list.Count; i++)
			{
				FlexibleListItem_Rate r = new FlexibleListItem_Rate();
				r.Top = new Vector2(0, -(i * 116 + 10));
				r.Height = 116;
				r.ResourceType = 2;
				r.ViewData = list[i];
				m_listItem_MusicRate.Add(r);
			}
		}

		//// RVA: 0x15CA3F0 Offset: 0x15CA3F0 VA: 0x15CA3F0
		private void MakeList_Grade(List<HighScoreRating.UtaGradeData> list)
		{
			m_listItem_MusicGrade = new List<IFlexibleListItem>();
			for(int i = 0; i < list.Count; i++)
			{
				if(list[i].isNow)
				{
					m_nowGradeIndex = i;
				}
				FlexibleListItem_Grade r = new FlexibleListItem_Grade();
				r.Top = new Vector2(0, -(i * 62 + 10));
				r.Height = 62;
				r.ResourceType = 1;
				r.MusicGrade = (HighScoreRatingRank.Type)list[i].grade;
				r.MusicGradeName = HighScoreRatingRank.GetRankName(r.MusicGrade);
				r.MusicMustRate = string.Format("{0}", list[i].rate);
				r.MySelf = list[i].isNow;
				m_listItem_MusicGrade.Add(r);
			}
		}

		//// RVA: 0x15CA710 Offset: 0x15CA710 VA: 0x15CA710
		private void MakeList_Reward(HighScoreRatingRank.Type grade, List<HighScoreRating.UtaGradeData> list)
		{
			m_listItem_MusicReward = new List<IFlexibleListItem>();
			for(int i = 0, cnt = 0; i < list.Count; i++)
			{
				for(int j = 0; j < list[i].items.Count; j++, cnt++)
				{
					FlexibleListItem_Reward r = new FlexibleListItem_Reward();
					r.Top = new Vector2(0, -(cnt * 105 + 10));
					r.Height = 105;
					r.ResourceType = 0;
					r.MusicGrade = (HighScoreRatingRank.Type)list[i].grade;
					r.MusicGradeName = HighScoreRatingRank.GetRankName(r.MusicGrade);
					r.MusicMustRate = string.Format("{0}", list[i].rate);
					r.Index = j;
					r.Item = list[i].items[j];
					r.Pickup = j == list[i].pickup;
					r.Get = list[i].grade < (int)grade;
					m_listItem_MusicReward.Add(r);
				}
			}
		}

		//// RVA: 0x15CAAD8 Offset: 0x15CAAD8 VA: 0x15CAAD8
		private void MakeList_Ranking(int count)
		{
			m_listItem_MusicRanking = new List<IFlexibleListItem>();
			for(int i = 0; i < count; i++)
			{
				FlexibleListItem_Ranking r = new FlexibleListItem_Ranking();
				r.Top = new Vector2(0, -(i * 132 + 10));
				r.Height = 132;
				r.ResourceType = 3;
				r.Index = i;
				m_listItem_MusicRanking.Add(r);
			}
		}

		//// RVA: 0x15CBA5C Offset: 0x15CBA5C VA: 0x15CBA5C
		private void OnUpdateListItem(IFlexibleListItem item)
		{
			if(item != null)
			{
				if(item is FlexibleListItem_Rate)
				{
					FlexibleListItem_Rate it = item as FlexibleListItem_Rate;
					if(it.Layout != null && it.Layout is LayoutPopupMusicRateListItem)
					{
						LayoutPopupMusicRateListItem l = it.Layout as LayoutPopupMusicRateListItem;
						l.SetStatus(it.Index, it.ViewData);
					}
				}
				if(item is FlexibleListItem_Grade)
				{
					FlexibleListItem_Grade it = item as FlexibleListItem_Grade;
					if(it.Layout != null && it.Layout is LayoutPopupMusicGradeListItem)
					{
						LayoutPopupMusicGradeListItem l = it.Layout as LayoutPopupMusicGradeListItem;
						l.SetStatus(it);
					}
				}
				if(item is FlexibleListItem_Reward)
				{
					FlexibleListItem_Reward it = item as FlexibleListItem_Reward;
					if(it.Layout != null && it.Layout is LayoutPopupMusicGradeRewardListItem)
					{
						LayoutPopupMusicGradeRewardListItem l = it.Layout as LayoutPopupMusicGradeRewardListItem;
						l.SetStatus(it);
						l.OnClickButton = (int itemId, int itemNum) =>
						{
							//0x15CCF28
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
							OnShowItemDetails(itemId, itemNum);
						};
					}
				}
				else if(item is FlexibleListItem_Ranking)
				{
					FlexibleListItem_Ranking it = item as FlexibleListItem_Ranking;
					if(it.Layout != null && it.Layout is LayoutPopupMusicRateRankingListItem)
					{
						LayoutPopupMusicRateRankingListItem l = it.Layout as LayoutPopupMusicRateRankingListItem;
						l.SetStatus(m_listRanking[it.Index]);
						l.OnClickButton = (RankingListInfo info) =>
						{
							//0x15CCF94
							if (OnClickRankingUserButton != null)
								OnClickRankingUserButton(info);
						};
						l.UpdateLayoutDisplay();
					}
				}
			}
		}

		//// RVA: 0x15CBFC4 Offset: 0x15CBFC4 VA: 0x15CBFC4
		public void OnShowItemDetails(int itemId, int itemNum)
		{
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				GCIJNCFDNON_SceneInfo s = new GCIJNCFDNON_SceneInfo();
				s.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId), null, null, 0, 0, 0, false, 0, 0);
				MenuScene.Instance.ShowSceneStatusPopupWindow(s, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, true, true, 0, false);
			}
			else
			{
				MenuScene.Instance.ShowItemDetail(itemId, itemNum, null);
			}
		}

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
	}
}
