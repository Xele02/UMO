using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using XeSys;
using System.Collections;
using XeApp.Game.Common.uGUI;

namespace XeApp.Game.Menu
{
	public class LayoutQuestEvent2MissionSelect : LayoutUGUIScriptBase
	{
		private const int MissionCardMax = 3;
		[SerializeField]
		private MusicSelectCDCursor m_cdCursor; // 0x14
		[SerializeField]
		private MusicSelectPlayButton m_playButton; // 0x18
		[SerializeField]
		private ActionButton m_musicChangeButton; // 0x1C
		[SerializeField]
		private ActionButton m_returnMissionButton; // 0x20
		[SerializeField]
		private ActionButton m_boxGachaButton; // 0x24
		[SerializeField]
		private NumberBase m_boxGachaItemNumber; // 0x28
		[SerializeField]
		private ActionButton m_eventInfoButton; // 0x2C
		[SerializeField]
		private RawImageEx m_jacketImage; // 0x30
		[SerializeField]
		private RawImageEx m_dropItemIconImage; // 0x34
		[SerializeField]
		private LayoutMissionCardButton[] m_cardlevel1Buttons; // 0x38
		[SerializeField]
		private LayoutMissionCardButton[] m_cardlevel2Buttons; // 0x3C
		[SerializeField]
		private LayoutMissionCardButton[] m_cardlevel3Buttons; // 0x40
		[SerializeField]
		private MusicSelectUnitButton m_unitButton; // 0x44
		private FPGEMAIAMBF_RewardData m_freeRewardData = new FPGEMAIAMBF_RewardData(); // 0x48
		private MusicRewardStat m_rewardStat = new MusicRewardStat(); // 0x4C
		private AbsoluteLayout m_curStyleAnim; // 0x50
		private AbsoluteLayout m_eventTagAnim; // 0x54
		private AbsoluteLayout m_eventItemTblAnim; // 0x58
		private AbsoluteLayout m_playButtonAnimeTbl; // 0x5C
		private AbsoluteLayout m_ticketLayout; // 0x60
		private AbsoluteLayout m_selectCardRootLayout; // 0x64
		private AbsoluteLayout[] m_selectCardAnimesLayout = new AbsoluteLayout[3]; // 0x68
		private AbsoluteLayout m_bonusAnimeLayout; // 0x6C
		private AbsoluteLayout m_limitedLabelLayout; // 0x70
		private AbsoluteLayout m_boxGachaButtonLayout; // 0x74
		private AbsoluteLayout m_unitLiveStyleLayout; // 0x78
		private LimitTimeWatcher m_musicTimeWatcher = new LimitTimeWatcher(); // 0x7C
		private LimitTimeWatcher m_bannerTimeWatcher = new LimitTimeWatcher(); // 0x80
		private List<int> m_itemIdList = new List<int>(3); // 0x84
		private AbsoluteLayout m_Anim; // 0x88
		private AbsoluteLayout m_CardSwitchAnim; // 0x8C
		private Text m_touchText; // 0x90
		private bool m_isPlaying; // 0x94
		//[CompilerGeneratedAttribute] // RVA: 0x672F94 Offset: 0x672F94 VA: 0x672F94
		public Action PushPlayButtonListener; // 0x98
		//[CompilerGeneratedAttribute] // RVA: 0x672FA4 Offset: 0x672FA4 VA: 0x672FA4
		public Action PushEventInfoButtonListner; // 0x9C
		//[CompilerGeneratedAttribute] // RVA: 0x672FB4 Offset: 0x672FB4 VA: 0x672FB4
		public Action PushMusicChangeButtonListner; // 0xA0
		//[CompilerGeneratedAttribute] // RVA: 0x672FC4 Offset: 0x672FC4 VA: 0x672FC4
		public Action<int> SelectedMissionListener; // 0xA4
		//[CompilerGeneratedAttribute] // RVA: 0x672FD4 Offset: 0x672FD4 VA: 0x672FD4
		public Action PushReturnMissionListner; // 0xA8
		//[CompilerGeneratedAttribute] // RVA: 0x672FE4 Offset: 0x672FE4 VA: 0x672FE4
		public Action PushBoxGachaListner; // 0xAC

		// RVA: 0x18727EC Offset: 0x18727EC VA: 0x18727EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Anim = layout.FindViewById("sw_sel_music_eve_anim") as AbsoluteLayout;
			m_CardSwitchAnim = layout.FindViewById("swtbl_sel_music_eve_select") as AbsoluteLayout;
			m_curStyleAnim = layout.FindViewByExId("sw_sel_music_cd_jakt_swtbl_sel_music_eve_week") as AbsoluteLayout;
			m_eventTagAnim = layout.FindViewByExId("sw_sel_music_cd_jakt_swtbl_sel_music_cd_eve_icn_01") as AbsoluteLayout;
			m_eventItemTblAnim = layout.FindViewByExId("swtbl_sel_music_eve_week_swtbl_sel_music_cd_jakt_fr_eve_item_01") as AbsoluteLayout;
			m_selectCardRootLayout = layout.FindViewByExId("sw_sel_music_eve_anim_swtbl_sel_music_eve_select") as AbsoluteLayout;
			m_playButtonAnimeTbl = layout.FindViewByExId("sw_sel_music_btn_play_anim_swtbl_set_deck_btn_play_en") as AbsoluteLayout;
			m_bonusAnimeLayout = layout.FindViewByExId("swtbl_s_m_bonus_icon_anim_sw_s_m_bonus_icon_anim") as AbsoluteLayout;
			m_ticketLayout = layout.FindViewByExId("swtbl_sel_music_eve_week_swtbl_s_m_cd_eve_tkt_rbn") as AbsoluteLayout;
			m_limitedLabelLayout = layout.FindViewByExId("swtbl_sel_music_eve_week_swtbl_sel_music_eve_limit") as AbsoluteLayout;
			m_boxGachaButtonLayout = layout.FindViewByExId("sw_sel_music_eve_anim_sw_s_m_e_a_btn_inout_anim") as AbsoluteLayout;
			m_unitLiveStyleLayout = layout.FindViewByExId("sw_sel_music_eve_anim_swtbl_unitlive_frm") as AbsoluteLayout;
			m_ticketLayout.StartChildrenAnimGoStop("02");
			((layout.FindViewByExId("cmn_win_01_ll_sw_s_m_e_w_btn_anim_2") as AbsoluteLayout).FindViewByExId("sw_s_m_e_w_btn_anim_swtbl_s_m_e_btn_w_fnt") as AbsoluteLayout).StartChildrenAnimGoStop("02");
			for(int i = 0; i < 3; i++)
			{
				m_selectCardAnimesLayout[i] = layout.FindViewByExId(string.Format("swtbl_sel_music_eve_select_sw_sel_music_eve_select_{0:D2}_anim", i + 1)) as AbsoluteLayout;
			}
			Array.ForEach(m_cardlevel1Buttons, (LayoutMissionCardButton x) =>
			{
				//0x1876000
				x.PushButtonListener += OnSelectedMission;
			});
			Array.ForEach(m_cardlevel2Buttons, (LayoutMissionCardButton x) =>
			{
				//0x18760B4
				x.PushButtonListener += OnSelectedMission;
			});
			Array.ForEach(m_cardlevel3Buttons, (LayoutMissionCardButton x) =>
			{
				//0x1876168
				x.PushButtonListener += OnSelectedMission;
			});
			m_playButton.AddOnClickCallback(OnPushPlayButton);
			m_eventInfoButton.AddOnClickCallback(OnPushEventInfoButton);
			m_musicChangeButton.AddOnClickCallback(OnPushMusicChangeButton);
			m_returnMissionButton.AddOnClickCallback(OnPushReturnMissionSelectButton);
			m_boxGachaButton.AddOnClickCallback(OnPushBoxGachaButton);
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_touchText = Array.Find(txts, (Text x) =>
			{
				//0x1876464
				return x.name == "touch (TextView)";
			});
			m_touchText.text = MessageManager.Instance.GetMessage("menu", "event_mission_message_001");
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F1B1C Offset: 0x6F1B1C VA: 0x6F1B1C
		// // RVA: 0x18735DC Offset: 0x18735DC VA: 0x18735DC
		// private IEnumerator Co_Initialize() { }

		// RVA: 0x1873688 Offset: 0x1873688 VA: 0x1873688
		public bool IsPlaying()
		{
			return m_isPlaying;
		}

		// RVA: 0x1873690 Offset: 0x1873690 VA: 0x1873690
		public void Enter()
		{
			SoundManager.Instance.sePlayerMenu.Play(24);
			this.StartCoroutineWatched(Co_Enter());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F1B94 Offset: 0x6F1B94 VA: 0x6F1B94
		// // RVA: 0x1873704 Offset: 0x1873704 VA: 0x1873704
		private IEnumerator Co_Enter()
		{
			//0x1876898
			m_isPlaying = true;
			m_Anim.StartChildrenAnimGoStop("go_in", "st_in");
			m_boxGachaButtonLayout.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			while(m_Anim.IsPlayingChildren())
				yield return null;
			m_isPlaying = false;
			m_Anim.StartChildrenAnimLoop("logo_act", "loen_act");
			m_boxGachaButtonLayout.StartChildrenAnimGoStop("logo_act", "loen_act");
		}

		// RVA: 0x18737B0 Offset: 0x18737B0 VA: 0x18737B0
		public void EnterMission()
		{
			this.StartCoroutineWatched(Co_EnterMission());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F1C0C Offset: 0x6F1C0C VA: 0x6F1C0C
		// // RVA: 0x18737D4 Offset: 0x18737D4 VA: 0x18737D4
		private IEnumerator Co_EnterMission()
		{
			//0x1876D14
			ShowDanger();
			m_isPlaying = true;
			m_Anim.StartChildrenAnimGoStop("go_in_card", "st_in_card");
			m_boxGachaButtonLayout.StartChildrenAnimGoStop("go_in_card", "st_in_card");
			yield return null;
			while(m_Anim.IsPlayingChildren())
				yield return null;
			m_isPlaying = false;
			m_Anim.StartChildrenAnimLoop("logo_act", "loen_act");
			m_boxGachaButtonLayout.StartChildrenAnimGoStop("logo_act", "loen_act");
			Array.ForEach(m_cardlevel1Buttons, (LayoutMissionCardButton x) =>
			{
				//0x18764E4
				x.ButtonReset();
			});
			Array.ForEach(m_cardlevel2Buttons, (LayoutMissionCardButton x) =>
			{
				//0x1876510
				x.ButtonReset();
			});
			Array.ForEach(m_cardlevel3Buttons, (LayoutMissionCardButton x) =>
			{
				//0x187653C
				x.ButtonReset();
			});
		}

		// // RVA: 0x1873880 Offset: 0x1873880 VA: 0x1873880
		// public void EnterInfo() { }

		// RVA: 0x18739B8 Offset: 0x18739B8 VA: 0x18739B8
		public void EnterGachaButton()
		{
			this.StartCoroutineWatched(Co_EnterGachaButton());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F1C84 Offset: 0x6F1C84 VA: 0x6F1C84
		// // RVA: 0x18739DC Offset: 0x18739DC VA: 0x18739DC
		private IEnumerator Co_EnterGachaButton()
		{
			//0x1876B38
			m_isPlaying = true;
			m_boxGachaButtonLayout.StartChildrenAnimGoStop("go_btn_in", "st_btn_in");
			yield return null;
			while(m_boxGachaButtonLayout.IsPlayingChildren())
				yield return null;
			m_isPlaying = false;
		}

		// // RVA: 0x1873A88 Offset: 0x1873A88 VA: 0x1873A88
		// public void Leave() { }

		// // RVA: 0x1873B0C Offset: 0x1873B0C VA: 0x1873B0C
		public void LeaveMission()
		{
			this.StartCoroutineWatched(Co_StartChildrenAnimGoStop("go_out_card", "st_out_card"));
		}

		// // RVA: 0x1873B90 Offset: 0x1873B90 VA: 0x1873B90
		public void LeaveGachaButton()
		{
			this.StartCoroutineWatched(Co_LeaveGachaButton());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F1CFC Offset: 0x6F1CFC VA: 0x6F1CFC
		// // RVA: 0x1873BB4 Offset: 0x1873BB4 VA: 0x1873BB4
		private IEnumerator Co_LeaveGachaButton()
		{
			//0x1877400
			m_isPlaying = true;
			m_boxGachaButtonLayout.StartChildrenAnimGoStop("go_btn_out", "st_btn_out");
			yield return null;
			while(m_boxGachaButtonLayout.IsPlayingChildren())
				yield return null;
			m_isPlaying = false;
		}

		// // RVA: 0x1873C60 Offset: 0x1873C60 VA: 0x1873C60
		public void Hide()
		{
			if(gameObject.activeSelf)
				this.StartCoroutineWatched(Co_StartChildrenAnimGoStop("st_out"));
			else
				m_Anim.StartChildrenAnimGoStop("st_out");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F1D74 Offset: 0x6F1D74 VA: 0x6F1D74
		// // RVA: 0x18738F8 Offset: 0x18738F8 VA: 0x18738F8
		private IEnumerator Co_StartChildrenAnimGoStop(string startLabel, string endLabel)
		{
			//0x18775DC
			m_isPlaying = true;
			m_Anim.StartChildrenAnimGoStop(startLabel, endLabel);
			m_boxGachaButtonLayout.StartChildrenAnimGoStop(startLabel, endLabel);
			yield return null;
			while(m_Anim.IsPlayingChildren())
				yield return null;
			m_isPlaying = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F1DEC Offset: 0x6F1DEC VA: 0x6F1DEC
		// // RVA: 0x1873D3C Offset: 0x1873D3C VA: 0x1873D3C
		private IEnumerator Co_StartChildrenAnimGoStop(string label)
		{
			//0x187779C
			m_isPlaying = true;
			m_Anim.StartChildrenAnimGoStop(label);
			m_boxGachaButtonLayout.StartChildrenAnimGoStop(label);
			yield return null;
			while(m_Anim.IsPlayingChildren())
				yield return null;
			m_isPlaying = false;
		}

		// RVA: 0x1873E24 Offset: 0x1873E24 VA: 0x1873E24
		public void GotoMissionConfirm(int selMissionIndex)
		{
			m_Anim.StartChildrenAnimGoStop("2btn_go_out", "2btn_go_out");
			m_boxGachaButtonLayout.StartChildrenAnimGoStop("2btn_go_out", "2btn_st_out");
			SelectMission(selMissionIndex, false);
		}

		// // RVA: 0x1873EF8 Offset: 0x1873EF8 VA: 0x1873EF8
		public void SelectMission(int selMissionIndex, bool isMoment)
		{
			string str = (selMissionIndex + 1).ToString("00");
			m_selectCardRootLayout.StartChildrenAnimGoStop(str);
			m_CardSwitchAnim.StartChildrenAnimGoStop(str);
			if(isMoment)
			{
				m_selectCardAnimesLayout[selMissionIndex].StartChildrenAnimGoStop("st_act");
			}
			else
			{
				m_selectCardAnimesLayout[selMissionIndex].StartChildrenAnimGoStop("go_act", "st_act");
			}
		}

		// RVA: 0x1874060 Offset: 0x1874060 VA: 0x1874060
		public void EnterMissionConfirm()
		{
			m_Anim.StartChildrenAnimGoStop("2btn_go_out", "6btn_st_in");
			m_boxGachaButtonLayout.StartChildrenAnimGoStop("2btn_go_out", "6btn_st_in");
		}

		// RVA: 0x187412C Offset: 0x187412C VA: 0x187412C
		public void EnterNormal(int selMisstionIndex)
		{
			m_Anim.StartChildrenAnimGoStop("go_in_02", "st_in_02");
			m_boxGachaButtonLayout.StartChildrenAnimGoStop("go_in_02", "st_in_02");
			SelectMission(selMisstionIndex, true);
		}

		// RVA: 0x187420C Offset: 0x187420C VA: 0x187420C
		public void LeaveMissionConfirm()
		{
			m_Anim.StartChildrenAnimGoStop("go_out", "st_out");
			m_boxGachaButtonLayout.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x18742D8 Offset: 0x18742D8 VA: 0x18742D8
		public void SetMissionSetData(IAFDICLEOPF data, IBJAKJJICBC musicData, bool is6Line, Difficulty.Type diffculty)
		{
			if(data.GAAHOOBMDEE_Missions != null)
			{
				for(int i = 0; i < data.GAAHOOBMDEE_Missions.Count; i++)
				{
					LayoutMissionCardButton[] l;
					if(data.GAAHOOBMDEE_Missions[i].CIEOBFIIPLD == 3)
					{
						l = m_cardlevel3Buttons;
					}
					else if(data.GAAHOOBMDEE_Missions[i].CIEOBFIIPLD == 2)
					{
						l = m_cardlevel2Buttons;
					}
					else if(data.GAAHOOBMDEE_Missions[i].CIEOBFIIPLD == 1)
					{
						l = m_cardlevel1Buttons;
					}
					else
					{
						l = new LayoutMissionCardButton[0];
					}
					for(int j = 0; j < l.Length; j++)
					{
						l[j].UpdateContent(data.GAAHOOBMDEE_Missions[i], i, j, musicData, is6Line, diffculty);
					}
				}
			}
		}

		// // RVA: 0x1874508 Offset: 0x1874508 VA: 0x1874508
		public void MakeCache()
		{
			m_cdCursor.MakeCache();
		}

		// // RVA: 0x1874534 Offset: 0x1874534 VA: 0x1874534
		public void ReleaseCache()
		{
			m_cdCursor.ReleaseCache();
		}

		// RVA: 0x1874560 Offset: 0x1874560 VA: 0x1874560
		public void SetMusicInfo(IBJAKJJICBC musicData, Difficulty.Type difficulty, MMOLNAHHDOM saveData, Action loadedCallback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			GameManager.Instance.MusicJacketTextureCache.Load(musicData.JNCPEGJGHOG_JacketId, (IiconTexture texture) =>
			{
				//0x1876568
				texture.Set(m_jacketImage);
				if(loadedCallback != null)
					loadedCallback();
			});
			m_freeRewardData.JMHCEMHPPCM(musicData.GHBPLHBNMBK_FreeMusicId, (int)difficulty, false, musicData.MNNHHJBBICA_GameEventType);
			m_rewardStat.Init(m_freeRewardData);
			m_cdCursor.ResetEventItem();
			m_cdCursor.ShowRewardMark(m_rewardStat.isScoreComplete, m_rewardStat.isComboComplete, m_rewardStat.isClearCountComplete);
			m_cdCursor.SetAttribute((GameAttribute.Type)musicData.FKDCCLPGKDK_JacketAttr);
			m_cdCursor.SetNew(musicData.LDGOHPAPBMM_IsNew);
			m_cdCursor.SetMusicRatio(musicData.AKAPOCOIECA_GetMusicRatio());
			m_cdCursor.SetMusicRatioVisibility(musicData.DEPGBBJMFED_CategoryId != 5);
			if(!musicData.LHONOILACFL_IsWeeklyEvent)
			{
				ApplyCursorEventType(musicData.OGHOPBAKEFE_IsEventSpecial ? MusicSelectCDSelect.EventType.Special : MusicSelectCDSelect.EventType.None);
				ApplyCursorEventStyle(musicData.NNJNNCGGKMC_IsLimited ? MusicSelectCDSelect.EventStyle.ExEvent : MusicSelectCDSelect.EventStyle.None);
				m_limitedLabelLayout.StartChildrenAnimGoStop(musicData.NNJNNCGGKMC_IsLimited ? "02" : "01");
				m_bonusAnimeLayout.StartChildrenAnimGoStop("02");
				m_playButton.Disable = false;
				if(musicData.NNJNNCGGKMC_IsLimited)
				{
					m_cdCursor.SetRemainTimePrefix(bk.GetMessageByLabel("music_event_remain_prefix"));
					m_musicTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
					{
						//0x18766BC
						ApplyEventRemainTime(remain, true);
					};
					m_musicTimeWatcher.onEndCallback = null;
					m_musicTimeWatcher.WatchStart(musicData.IHPCKOMBGKJ_End, true);
				}
			}
			else
			{
				ApplyCursorEventType(MusicSelectCDSelect.EventType.Weekly);
				m_limitedLabelLayout.StartChildrenAnimGoStop("01");
				if(musicData.JOJNGDPHOKG_WeeklyMax - musicData.BELHFPMBAPJ_WeekPlay < 1)
				{
					m_cdCursor.SetEndMessage(bk.GetMessageByLabel("music_week_play_count_limit"));
					ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.Disable);
					m_playButton.Disable = true;
				}
				else
				{
					ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.Weekly);
					m_musicTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
					{
						//0x1876674
						ApplyEventRemainTime(remain, true);
					};
					m_musicTimeWatcher.onEndCallback = null;
					m_musicTimeWatcher.WatchStart(musicData.NKEIFPPGNLH_WeeklyendTime, true);
					m_cdCursor.SetRemainTimePrefix(bk.GetMessageByLabel("music_event_remain_prefix"));
				}
				m_cdCursor.SetRemainPlayCount(musicData.JOJNGDPHOKG_WeeklyMax - musicData.BELHFPMBAPJ_WeekPlay);
				if(musicData.GDLNCHCPMCK_HasBoost)
				{
					m_bonusAnimeLayout.StartChildrenAnimGoStop("logo_act", "loen_act");
					m_bonusAnimeLayout.StartAnimGoStop("01", "01");
				}
				else
				{
					m_bonusAnimeLayout.StartChildrenAnimGoStop("st_non");
					m_bonusAnimeLayout.StartAnimGoStop("02", "02");
				}
				m_itemIdList.Clear();
				for(int i = 0; i < 3; i++)
				{
					int id = musicData.ICHJBDPJNMA_GetWeeklyItem(musicData.IHKFMJDOBAH_WeekDayAttr, i);
					if(id > 0)
					{
						m_itemIdList.Add(id);
					}
				}
				m_eventItemTblAnim.StartChildrenAnimGoStop(m_itemIdList.Count.ToString("00"));
				for(int i = 0; i < m_itemIdList.Count; i++)
				{
					int idx = i;
					GameManager.Instance.ItemTextureCache.Load(m_itemIdList[i], (IiconTexture image) =>
					{
						//0x187682C
						m_cdCursor.ApplyEventItem(idx, image);
					});
				}
			}
			m_cdCursor.SetEventBonusValue(musicData.DBJOBFIGGEE_EventBonusPercent);
			m_unitButton.Setup(musicData, saveData, (MusicSelectUnitButton.Style style) =>
			{
				//0x1876704
				if(m_unitButton.Hidden)
				{
					m_unitLiveStyleLayout.StartChildrenAnimGoStop("03");
				}
				else
				{
					m_unitLiveStyleLayout.StartChildrenAnimGoStop(style == MusicSelectUnitButton.Style.Unit ? "02" : "01");
				}
			});
			UpdatePlayButton(musicData, difficulty);
		}

		// // RVA: 0x1875744 Offset: 0x1875744 VA: 0x1875744
		public void SetupUnitLive(IBJAKJJICBC musicData, MMOLNAHHDOM saveData)
		{
			m_unitButton.Setup(musicData, saveData, (MusicSelectUnitButton.Style style) =>
			{
				//0x187621C
				if(m_unitButton.Hidden)
				{
					m_unitLiveStyleLayout.StartChildrenAnimGoStop("03");
				}
				else
				{
					m_unitLiveStyleLayout.StartChildrenAnimGoStop(style == MusicSelectUnitButton.Style.Unit ? "02": "01");
				}
			});
		}

		// // RVA: 0x1875814 Offset: 0x1875814 VA: 0x1875814
		public void SetDropItemIconType(int itemId)
		{
			if(itemId < 1)
			{
				m_ticketLayout.StartChildrenAnimGoStop("02");
			}
			else
			{
				GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
				{
					//0x1876308
					texture.Set(m_dropItemIconImage);
				});
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
				{
					m_ticketLayout.StartChildrenAnimGoStop("03");
				}
				else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
				{
					m_ticketLayout.StartChildrenAnimGoStop("01");
				}
			}
		}

		// // RVA: 0x18759EC Offset: 0x18759EC VA: 0x18759EC
		public int GetDanceDivaCount()
		{
			return m_unitButton.GetDivaCount();
		}

		// // RVA: 0x1875634 Offset: 0x1875634 VA: 0x1875634
		public void UpdatePlayButton(IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			SetNeedEnergy(musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].BPLOEAHOPFI_Energy);
			SetPlayBtn(musicData.IFNPBIJEPBO_IsDlded ? PlayButtonWrapper.Type.PlayEn : PlayButtonWrapper.Type.Download);
		}

		// // RVA: 0x1875364 Offset: 0x1875364 VA: 0x1875364
		public void ApplyCursorEventType(MusicSelectCDSelect.EventType type)
		{
			switch(type)
			{
				case MusicSelectCDSelect.EventType.Weekly:
					m_eventTagAnim.StartChildrenAnimGoStop("01");
					break;
				case MusicSelectCDSelect.EventType.Score:
					m_eventTagAnim.StartChildrenAnimGoStop("02");
					break;
				case MusicSelectCDSelect.EventType.Special:
					m_eventTagAnim.StartChildrenAnimGoStop("03");
					break;
				case MusicSelectCDSelect.EventType.Birthday:
					m_eventTagAnim.StartChildrenAnimGoStop("04");
					break;
				case MusicSelectCDSelect.EventType.None:
					m_eventTagAnim.StartChildrenAnimGoStop("05");
					break;
				default:
					break;
			}
			m_eventInfoButton.Hidden = type > MusicSelectCDSelect.EventType.Score;
		}

		// // RVA: 0x18754CC Offset: 0x18754CC VA: 0x18754CC
		public void ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle style)
		{
			bool d = false;
			switch(style)
			{
				case MusicSelectCDSelect.EventStyle.Weekly:
					m_curStyleAnim.StartChildrenAnimGoStop("01");
					break;
				case MusicSelectCDSelect.EventStyle.Disable:
					d = true;
					m_curStyleAnim.StartChildrenAnimGoStop("05");
					break;
				case MusicSelectCDSelect.EventStyle.None:
					m_curStyleAnim.StartChildrenAnimGoStop("05");
					break;
				case MusicSelectCDSelect.EventStyle.ExTicket:
					m_curStyleAnim.StartChildrenAnimGoStop("02");
					break;
				case MusicSelectCDSelect.EventStyle.ExEvent:
					m_curStyleAnim.StartChildrenAnimGoStop("04");
					break;
				case MusicSelectCDSelect.EventStyle.ScoreEvent:
					m_curStyleAnim.StartChildrenAnimGoStop("03");
					break;
				case MusicSelectCDSelect.EventStyle.SimulationLive:
					m_curStyleAnim.StartChildrenAnimGoStop("05");
					break;
				default:
					m_curStyleAnim.StartChildrenAnimGoStop("");
					break;
			}
			m_cdCursor.SetDisable(d, false);
		}

		// // RVA: 0x1875A4C Offset: 0x1875A4C VA: 0x1875A4C
		public void SetPlayBtn(PlayButtonWrapper.Type type)
		{
			bool v = false;
			switch(type)
			{
				case PlayButtonWrapper.Type.PlayEn:
					m_playButtonAnimeTbl.StartChildrenAnimGoStop("01");
					break;
				case PlayButtonWrapper.Type.Play:
					m_playButtonAnimeTbl.StartChildrenAnimGoStop("02");
					break;
				case PlayButtonWrapper.Type.Event:
					m_playButtonAnimeTbl.StartChildrenAnimGoStop("03");
					break;
				case PlayButtonWrapper.Type.Download:
					v = true;
					m_playButtonAnimeTbl.StartChildrenAnimGoStop("04");
					break;
				case PlayButtonWrapper.Type.Live:
					m_playButtonAnimeTbl.StartChildrenAnimGoStop("05");
					break;
				case PlayButtonWrapper.Type.Ok:
					m_playButtonAnimeTbl.StartChildrenAnimGoStop("05");
					break;
				default:
					m_playButtonAnimeTbl.StartChildrenAnimGoStop("");
					break;
			}
			m_playButton.SetDLMessage(v);
		}

		// // RVA: 0x1875A18 Offset: 0x1875A18 VA: 0x1875A18
		public void SetNeedEnergy(int stamina)
		{
			m_playButton.SetNeedEnergy(stamina);
		}

		// RVA: 0x1875B94 Offset: 0x1875B94 VA: 0x1875B94
		public void SetGahcaItemCount(int count)
		{
			m_boxGachaItemNumber.SetNumber(count, 0);
		}

		// // RVA: 0x1875BD4 Offset: 0x1875BD4 VA: 0x1875BD4
		protected void ApplyEventRemainTime(long remainSec, bool makeColor)
		{
			int d, h, m, s;
			MusicSelectSceneBase.ExtractRemainTime((int)remainSec, out d, out h, out m, out s);
			string str = MusicSelectSceneBase.MakeRemainTime(d, h, m, s);
			if(makeColor)
			{
				str = RichTextUtility.MakeColorTagString(str, SystemTextColor.ImportantColor);
			}
			m_cdCursor.SetRemainTimeValue(str);
		}

		// // RVA: 0x1875D2C Offset: 0x1875D2C VA: 0x1875D2C
		private void OnPushPlayButton()
		{
			if(PushPlayButtonListener != null)
				PushPlayButtonListener();
		}

		// // RVA: 0x1875D40 Offset: 0x1875D40 VA: 0x1875D40
		private void OnPushEventInfoButton()
		{
			if(PushEventInfoButtonListner != null)
				PushEventInfoButtonListner();
		}

		// // RVA: 0x1875D54 Offset: 0x1875D54 VA: 0x1875D54
		private void OnPushMusicChangeButton()
		{
			if(PushMusicChangeButtonListner != null)
				PushMusicChangeButtonListner();
		}

		// // RVA: 0x1875D68 Offset: 0x1875D68 VA: 0x1875D68
		private void OnPushReturnMissionSelectButton()
		{
			if(PushReturnMissionListner != null)
				PushReturnMissionListner();
		}

		// // RVA: 0x1875D7C Offset: 0x1875D7C VA: 0x1875D7C
		private void OnPushBoxGachaButton()
		{
			if(PushBoxGachaListner != null)
				PushBoxGachaListner();
		}

		// // RVA: 0x1875D90 Offset: 0x1875D90 VA: 0x1875D90
		private void OnSelectedMission(int missionIndex)
		{
			if(SelectedMissionListener != null)
				SelectedMissionListener(missionIndex);
		}

		// // RVA: 0x1875E04 Offset: 0x1875E04 VA: 0x1875E04
		private void ShowDanger()
		{
			ShowDanger(m_cardlevel1Buttons);
			ShowDanger(m_cardlevel2Buttons);
			ShowDanger(m_cardlevel3Buttons);
		}

		// // RVA: 0x1875E2C Offset: 0x1875E2C VA: 0x1875E2C
		private void ShowDanger(LayoutMissionCardButton[] buttons)
		{
			for(int i = 0; i < buttons.Length; i++)
			{
				buttons[i].ShowDanger(i);
			}
		}

		// RVA: 0x1875EA4 Offset: 0x1875EA4 VA: 0x1875EA4
		private void Update()
		{
			m_musicTimeWatcher.Update();
		}
	}
}
