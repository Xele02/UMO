using System.Collections.Generic;
using System.Linq;
using mcrs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.SmartFormat;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvCheckLayout : LayoutUGUIScriptBase
	{
		public class RewardIcon
		{
			public RawImageEx m_icon; // 0x8
			public Text m_remain; // 0xC
		}

		public enum ScrollItemType
		{
			RankingHeader = 1,
			RankingItem = 2,
			PointItem = 3,
			RaidItem = 4,
			RaidHeader = 5,
		}

		public enum RankingType
		{
			Default = 0,
			Total = 1,
			Music = 2,
			BattleTotal = 3,
			BattleScore = 4,
			GoDivaScore = 5,
		}

		private ScrollRect m_ScrollRect; // 0x14
		private Transform m_ScrollContent; // 0x18
		private FlexibleItemScrollView m_fxScrollView; // 0x1C
		private TexUVList m_texUv_02; // 0x20
		private Text m_unitText; // 0x24
		private Text m_numText; // 0x28
		private Text m_textEventHiScoreTitle; // 0x2C
		private Text m_textEventHiScoreValue; // 0x30
		private Text m_textEventRankingTitle; // 0x34
		private Text m_textEventRankingValue; // 0x38
		private Text m_textEventRankingValue2; // 0x3C
		private Text m_textRaidInfo; // 0x40
		private AbsoluteLayout m_titleLayout; // 0x44
		private AbsoluteLayout m_rewardLayout; // 0x48
		private ActionButton m_btnChangeRanking; // 0x4C
		private RawImageEx m_imageChangeRanking; // 0x50
		private RawImageEx m_imageCDJacket; // 0x54
		private PopupTabButton.ButtonLabel m_CurrentLabel = PopupTabButton.ButtonLabel.None; // 0x58
		private int m_CurrentPoint; // 0x5C
		private int m_CurrentRank; // 0x60
		private int m_EventMusicRank; // 0x64
		private int m_EventHiScore; // 0x68
		private bool m_isCounting; // 0x6C
		private List<RewardIcon> m_rewardIcon = new List<RewardIcon>(); // 0x70
		private RankingType m_RankingType; // 0x74
		private UnityAction<RankingType> m_CallbackChangeRankingType; // 0x78
		private OHCAABOMEOF.KGOGMKMBCPP_EventType m_eventType; // 0x7C

		public ScrollRect GetScrollRect { get { return m_ScrollRect; } } //0x1A6FE74
		public Transform GetScrollContent { get { return m_ScrollContent; } } //0x1A66EE0
		public FlexibleItemScrollView FxScrollView { get { return m_fxScrollView; } } //0x1A66E04

		// // RVA: 0x1A67B68 Offset: 0x1A67B68 VA: 0x1A67B68
		public RankingType GetRankingType()
		{
			return m_RankingType;
		}

		// // RVA: 0x1A66DFC Offset: 0x1A66DFC VA: 0x1A66DFC
		public void SetCallbackChangeRankingType(UnityAction<RankingType> a_cb)
		{
			m_CallbackChangeRankingType = a_cb;
		}

		// RVA: 0x1A6FE7C Offset: 0x1A6FE7C VA: 0x1A6FE7C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_texUv_02 = uvMan.GetTexUVList("pop_reward_ev2_02_pack");
			m_titleLayout = layout.FindViewByExId("sw_pop_reward_ev_check_swtbl_pop_reward_ev_fnt") as AbsoluteLayout;
			m_rewardLayout = layout.FindViewByExId("swtbl_pop_reward_ev_fnt_swtbl_pop_reward_ev_item") as AbsoluteLayout;
			LayoutUGUIRuntime lt = GetComponent<LayoutUGUIRuntime>();
			for(int i = 0; i < 3; i++)
			{
				RectTransform rt = lt.FindRectTransform(layout.FindViewById(string.Format("sw_pop_reward_ev_item_{0:00}", i + 1)));
				RewardIcon icon = new RewardIcon();
				icon.m_icon = rt.Find("swtexf_pop_reward_ev_item (ImageView)").GetComponent<RawImageEx>();
				icon.m_remain = rt.Find("item_num (TextView)").GetComponent<Text>();
				m_rewardIcon.Add(icon);
			}
			Text[] txts = lt.GetComponentsInChildren<Text>(true);
			IEnumerable<Text> txts2 = txts.Reverse();
			m_unitText = txts2.Where((Text _) =>
			{
				//0x1A72E70
				return _.name == "unit (TextView)";
			}).Last();
			m_numText = txts2.Where((Text _) =>
			{
				//0x1A72EF0
				return _.name == "num (TextView)";
			}).Last();
			m_textEventHiScoreTitle = txts2.Where((Text _) =>
			{
				//0x1A72F70
				return _.name == "eve_hiscore (TextView)";
			}).First();
			m_textEventHiScoreValue = txts2.Where((Text _) =>
			{
				//0x1A72FF0
				return _.name == "eve_hiscore_num (TextView)";
			}).First();
			m_textEventRankingTitle = txts2.Where((Text _) =>
			{
				//0x1A73070
				return _.name == "eve_mrank (TextView)";
			}).First();
			m_textEventRankingValue = txts2.Where((Text _) =>
			{
				//0x1A730F0
				return _.name == "eve_mrank_num (TextView)";
			}).First();
			m_textEventRankingValue2 = txts2.Where((Text _) =>
			{
				//0x1A73170
				return _.name == "i (TextView)";
			}).First();
			m_textRaidInfo = txts2.Where((Text _) =>
			{
				//0x1A731F0
				return _.transform.parent.name == "fnt_desc_2 (AbsoluteLayout)" && _.name == "desk2 (TextView)";
			}).First();
			ActionButton[] btns = lt.GetComponentsInChildren<ActionButton>(true);
			IEnumerable<ActionButton> btns2 = btns.Reverse();
			m_btnChangeRanking = btns2.Where((ActionButton _) =>
			{
				//0x1A732F0
				return _.name == "sw_p_r_e_toggle_btn (AbsoluteLayout)";
			}).First();
			m_btnChangeRanking.AddOnClickCallback(OnClick_ChangeRanking);
			RawImageEx[] imgs = lt.GetComponentsInChildren<RawImageEx>(true);
			IEnumerable<RawImageEx> imgs2 = imgs.Reverse();
			m_imageChangeRanking = imgs2.Where((RawImageEx _) =>
			{
				//0x1A73370
				return _.name == "swtexf_pop_reward_ev_toggle_btn_fnt_01 (ImageView)";
			}).First();
			m_imageCDJacket = imgs2.Where((RawImageEx _) =>
			{
				//0x1A733F0
				return _.name == "swtexc_cmn_cd_2 (ImageView)";
			}).First();
			m_ScrollRect = GetComponentInChildren<ScrollRect>(true);
			m_ScrollContent = m_ScrollRect.transform.Find("Content");
			m_ScrollRect.horizontal = false;
			m_ScrollRect.vertical = true;
			m_ScrollRect.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			m_ScrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			VerticalLayoutGroup v = m_ScrollRect.gameObject.GetComponentInChildren<VerticalLayoutGroup>(true);
			v.enabled = false;
			ContentSizeFitter c = m_ScrollRect.gameObject.GetComponentInChildren<ContentSizeFitter>(true);
			c.enabled = false;
			LayoutElement l = m_ScrollRect.gameObject.GetComponentInChildren<LayoutElement>(true);
			l.enabled = false;
			m_fxScrollView = new FlexibleItemScrollView();
			m_fxScrollView.Initialize(m_ScrollRect);
			Loaded();
			return true;
		}

		// RVA: 0x1A669F8 Offset: 0x1A669F8 VA: 0x1A669F8
		public void SetUp(PopupRewardEvCheck.ViewRewardEvCheckData data)
		{
			m_CurrentPoint = data.curr_point;
			m_CurrentRank = data.curr_rank;
			m_isCounting = data.is_counting;
			m_eventType = data.eventType;
			m_RankingType = RankingType.Default;
			if(m_eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
			{
				TodoLogger.LogError(TodoLogger.EventCollection_1, "Event Collcetion");
			}
			else if(m_eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				m_EventMusicRank = data.curr_score_rank;
				m_EventHiScore = data.curr_score;
				m_RankingType = RankingType.BattleScore;
			}
			else if(m_eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
			{
				m_EventMusicRank = data.curr_score_rank;
				m_EventHiScore = data.curr_score;
				MenuScene.Instance.MusicJacketTextureCache.Load(data.pickup_cover_id, (IiconTexture texture) =>
				{
					//0x1A72D14
					texture.Set(m_imageCDJacket);
				});
				m_RankingType = RankingType.GoDivaScore;
			}
			else if(m_eventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
			{
				m_EventMusicRank = 0;
				m_EventHiScore = 0;
			}
			SetRewardIcon(data);
			if(!data.is_rank_reward)
			{
				m_CurrentLabel = PopupTabButton.ButtonLabel.CumulativePoint;
			}
			else
			{
				m_CurrentLabel = PopupRewardEvCheck.DEFAULT_TAB;
			}
			if(!data.is_point_reward)
			{
				m_CurrentLabel = PopupTabButton.ButtonLabel.Rankings;
			}
			ApplyText();
		}

		// // RVA: 0x1A711AC Offset: 0x1A711AC VA: 0x1A711AC
		public void SetRewardIcon(PopupRewardEvCheck.ViewRewardEvCheckData data)
		{
			for(int i = 0; i < data.total_feature_list.Count;i++)
			{
				m_rewardIcon[i].m_icon.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUv_02.GetUVData(string.Format("pop_reward_ev_item_{0:00}", (int)data.total_feature_list[i].PEEAGFNOFFO_ItemId)));
				m_rewardIcon[i].m_remain.text = string.Format("{0}/{1}", data.total_feature_list[i].LIOEOPGDBJK_Received, (int)data.total_feature_list[i].MCJBEJBMJMF_Total);
			}
			m_rewardLayout.StartChildrenAnimGoStop(data.total_feature_list.Count > 3 ? "03" : data.total_feature_list.Count.ToString("D2"));
		}

		// // RVA: 0x1A67E28 Offset: 0x1A67E28 VA: 0x1A67E28
		public void ChangeTab(PopupTabButton.ButtonLabel label)
		{
			m_CurrentLabel = label;
			ApplyText();
		}

		// RVA: 0x1A71520 Offset: 0x1A71520 VA: 0x1A71520
		private void ApplyText()
		{
			if(m_CurrentLabel == PopupTabButton.ButtonLabel.RewardDisempowermentItems)
			{
				m_titleLayout.StartChildrenAnimGoStop("11");
				m_textRaidInfo.text = MessageManager.Instance.GetMessage("menu", "popup_event_reward_raid_info_lotcount");
			}
			else if(m_CurrentLabel == PopupTabButton.ButtonLabel.Rankings)
			{
				if(m_RankingType != 0)
				{
					ChangeRankingType(m_RankingType);
				}
				m_titleLayout.StartChildrenAnimGoStop("03");
				if(m_isCounting)
				{
					m_numText.text = MessageManager.Instance.GetMessage("menu", "music_event_end_attain_popup");
					m_unitText.text = "";
					RichTextUtility.ChangeColor(m_numText, SystemTextColor.NormalColor);
				}
				else
				{
					m_numText.text = m_CurrentRank < 1 ? TextConstant.InvalidText : m_CurrentRank.ToString();
					m_unitText.text = Smart.Format(MessageManager.Instance.GetMessage("menu", "popup_event_reward_currentrank_unit"), Mathf.Max(0, m_CurrentRank));
				}
			}
			else if(m_CurrentLabel == PopupTabButton.ButtonLabel.CumulativePoint)
			{
				m_titleLayout.StartChildrenAnimGoStop("04");
				m_numText.text = m_CurrentPoint.ToString();
				m_unitText.text = MessageManager.Instance.GetMessage("menu", "popup_event_reward_currentpoint_unit");
			}
		}

		// // RVA: 0x1A72B04 Offset: 0x1A72B04 VA: 0x1A72B04
		private void OnClick_ChangeRanking()
		{
			switch(m_RankingType)
			{
				case RankingType.Total:
				case RankingType.GoDivaScore:
				default:
					ChangeRankingType(RankingType.Music);
					break;
				case RankingType.Music:
					ChangeRankingType(RankingType.Total);
					break;
				case RankingType.BattleScore:
					ChangeRankingType(RankingType.BattleTotal);
					break;
				case RankingType.BattleTotal:
					ChangeRankingType(RankingType.BattleScore);
					break;
			}
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		// // RVA: 0x1A719A0 Offset: 0x1A719A0 VA: 0x1A719A0
		private void ChangeRankingType(RankingType a_type)
		{
			m_RankingType = a_type;
			switch(a_type)
			{
				case RankingType.Total:
				case RankingType.BattleTotal:
					m_titleLayout.StartChildrenAnimGoStop("06");
					if(!m_isCounting)
					{
						m_numText.text = m_CurrentRank < 1 ? TextConstant.InvalidText : m_CurrentRank.ToString();
						m_unitText.text = Smart.Format(MessageManager.Instance.GetMessage("menu", "popup_event_reward_currentrank_unit"), Mathf.Max(0, m_CurrentRank));
					}
					else
					{
						m_numText.text = MessageManager.Instance.GetMessage("menu", "music_event_end_attain_popup");
						m_unitText.text = "";
						RichTextUtility.ChangeColor(m_numText, SystemTextColor.NormalColor);
					}
					if(m_RankingType == RankingType.BattleTotal)
					{
						m_imageChangeRanking.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUv_02.GetUVData("pop_reward_ev_toggle_btn_fnt_03"));
					}
					else if(m_RankingType == RankingType.Total)
					{
						m_imageChangeRanking.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUv_02.GetUVData("pop_reward_ev_toggle_btn_fnt_01"));
					}
					break;
				case RankingType.Music:
					m_titleLayout.StartChildrenAnimGoStop("07");
					m_textEventHiScoreTitle.text = MessageManager.Instance.GetMessage("menu", "event_hi_score");
					m_textEventHiScoreValue.text = m_EventHiScore < 1 ? TextConstant.InvalidText : m_EventHiScore.ToString();
					m_textEventRankingTitle.text = MessageManager.Instance.GetMessage("menu", "event_music_ranking");
					if(!m_isCounting)
					{
						m_textEventRankingValue.text = m_EventMusicRank < 1 ? TextConstant.InvalidText : m_EventMusicRank.ToString();
						m_textEventRankingValue2.text = Smart.Format(MessageManager.Instance.GetMessage("menu", "event_music_ranking_unit"), m_EventMusicRank);
					}
					else
					{
						m_textEventRankingValue.text = MessageManager.Instance.GetMessage("menu", "music_event_end_attain_popup");
						m_textEventRankingValue2.text = "";
						RichTextUtility.ChangeColor(m_numText, SystemTextColor.NormalColor);
					}
					m_imageChangeRanking.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUv_02.GetUVData("pop_reward_ev_toggle_btn_fnt_02"));
					break;
				case RankingType.BattleScore:
					m_titleLayout.StartChildrenAnimGoStop("08");
					m_textEventHiScoreTitle.text = MessageManager.Instance.GetMessage("menu", "event_battle_reward_check_hi_score");
					m_textEventHiScoreValue.text = m_EventHiScore < 1 ? TextConstant.InvalidText : m_EventHiScore.ToString();
					m_textEventRankingTitle.text = MessageManager.Instance.GetMessage("menu", "event_battle_reward_check_ranking");
					if(!m_isCounting)
					{
						m_textEventRankingValue.text = m_EventMusicRank < 1 ? TextConstant.InvalidText : m_EventMusicRank.ToString();
						m_textEventRankingValue2.text = MessageManager.Instance.GetMessage("menu", "event_battle_reward_check_ranking_unit");
					}
					else
					{
						m_textEventRankingValue.text = MessageManager.Instance.GetMessage("menu", "music_event_end_attain_popup");
						m_textEventRankingValue2.text = "";
						RichTextUtility.ChangeColor(m_numText, SystemTextColor.NormalColor);
					}
					m_imageCDJacket.enabled = false;
					m_imageChangeRanking.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUv_02.GetUVData("pop_reward_ev_toggle_btn_fnt_02"));
					break;
				case RankingType.GoDivaScore:
					m_titleLayout.StartChildrenAnimGoStop("12");
					m_textEventHiScoreTitle.text = MessageManager.Instance.GetMessage("menu", "event_godiva_reward_check_hi_score");
					m_textEventHiScoreValue.text = m_EventHiScore < 1 ? TextConstant.InvalidText : m_EventHiScore.ToString();
					m_textEventRankingTitle.text = MessageManager.Instance.GetMessage("menu", "event_godiva_reward_check_ranking");
					if(!m_isCounting)
					{
						m_textEventRankingValue.text = m_EventMusicRank < 1 ? TextConstant.InvalidText : m_EventMusicRank.ToString();
						m_textEventRankingValue2.text = MessageManager.Instance.GetMessage("menu", "event_godiva_reward_check_ranking_unit");
					}
					else
					{
						m_textEventRankingValue.text = MessageManager.Instance.GetMessage("menu", "music_event_end_attain_popup");
						m_textEventRankingValue2.text = "";
						RichTextUtility.ChangeColor(m_numText, SystemTextColor.NormalColor);
					}
					break;
			}
			if(m_CallbackChangeRankingType != null)
				m_CallbackChangeRankingType(m_RankingType);
		}

		// [CompilerGeneratedAttribute] // RVA: 0x70E34C Offset: 0x70E34C VA: 0x70E34C
		// // RVA: 0x1A72C34 Offset: 0x1A72C34 VA: 0x1A72C34
		// private void <SetUp>b__39_0(IiconTexture texture) { }
	}
}
