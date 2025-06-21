using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Localization.SmartFormat;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EventMusicSelectScene : MusicSelectSceneBase
	{
		private const int EVENT_POINT_MAX = 99999999;
		private MusicSelectEventInfo m_eventInfo; // 0xF8
		private EventTimeLimitMessage m_timeLimitMessage; // 0xFC
		private MusicSelectLineButton m_lineButton; // 0x100
		private MusicDataList m_musicList; // 0x104
		private bool m_isEventChecked; // 0x108
		private bool m_isEventTimeLimit; // 0x109

		protected override int musicListCount { get { return 1; } } //0x13B12B0
		protected override MusicDataList currentMusicList { get { return m_musicList; } } //0x13B12C0

		// // RVA: 0x13B12B8 Offset: 0x13B12B8 VA: 0x13B12B8 Slot: 32
		protected override MusicDataList GetMusicList(int i)
		{
			return m_musicList;
		}

		// RVA: 0x13B12C8 Offset: 0x13B12C8 VA: 0x13B12C8 Slot: 16
		protected override void OnPreSetCanvas()
		{
			this.StartCoroutineWatched(Co_PreSetCanvas());
		}

		// RVA: 0x13B1378 Offset: 0x13B1378 VA: 0x13B1378 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(isBgChanging || !m_isEventChecked)
				return false;
			m_musicInfo.Hide();
			m_cdSelect.Hide();
			m_cdArrow.Hide();
			m_buttonSet.Hide();
			m_eventBanner.Hide();
			m_eventInfo.Hide();
			m_timeLimitMessage.Hide();
			m_lineButton.Hide();
			return base.IsEndPreSetCanvas();
		}

		// RVA: 0x13B14B8 Offset: 0x13B14B8 VA: 0x13B14B8 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(m_isEventTimeLimit)
				return;
			if(!IsEventEndChallengePeriod)
			{
				m_musicInfo.Enter();
				m_cdSelect.Enter();
				m_cdArrow.Enter();
				if(currentMusicList.GetCount(true, false) > 1)
				{
					m_lineButton.SetUnlock(IBJAKJJICBC.KGJJCAKCMLO());
					m_lineButton.SetUnlockNumber(IBJAKJJICBC.POPLHDKHIIM());
					m_lineButton.Enter(m_isLine6Mode);
				}
			}
			else
			{
				m_timeLimitMessage.Enter(IsEventCounting);
			}
			m_buttonSet.Enter();
			m_eventBanner.Enter();
			m_eventInfo.Enter();
		}

		// RVA: 0x13B16B4 Offset: 0x13B16B4 VA: 0x13B16B4 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_musicInfo.IsPlaying() && !m_cdSelect.IsPlaying() && !m_cdArrow.IsPlaying() && !m_buttonSet.IsPlaying() && !m_eventBanner.IsPlaying() && 
				!m_eventInfo.IsPlaying() && !m_timeLimitMessage.IsPlaying() && !m_lineButton.IsPlaying();
		}

		// RVA: 0x13B1808 Offset: 0x13B1808 VA: 0x13B1808 Slot: 12
		protected override void OnStartExitAnimation()
		{
			if(m_isEventTimeLimit)
				return;
			if(!IsEventEndChallengePeriod)
			{
				m_musicInfo.Leave();
				m_cdSelect.Leave();
				m_cdArrow.Leave();
			}
			else
			{
				m_timeLimitMessage.Leave();
			}
			m_buttonSet.Leave();
			m_eventBanner.Leave();
			m_eventInfo.Leave();
			m_lineButton.TryLeave();
		}

		// RVA: 0x13B193C Offset: 0x13B193C VA: 0x13B193C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_musicInfo.IsPlaying() && !m_cdSelect.IsPlaying() && !m_cdArrow.IsPlaying() && !m_buttonSet.IsPlaying() && 
				!m_eventBanner.IsPlaying() && !m_eventInfo.IsPlaying() && !m_timeLimitMessage.IsPlaying() && !m_lineButton.IsPlaying();
		}

		// RVA: 0x13B1A90 Offset: 0x13B1A90 VA: 0x13B1A90 Slot: 35
		protected override void CheckTryInstall()
		{
			if(!IsRequestGotoTitle)
			{
				StringBuilder str = new StringBuilder(32);
				str.SetFormat("ct/mc/{0:D3}.xab", 0);
				TryInstall(str);
				TryInstall(str, m_musicList);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EEDAC Offset: 0x6EEDAC VA: 0x6EEDAC
		// // RVA: 0x13B1B80 Offset: 0x13B1B80 VA: 0x13B1B80 Slot: 36
		protected override IEnumerator Co_Initialize()
		{
			//0x13B4CE8
			if(m_isEventTimeLimit || IsRequestGotoTitle)
			{
				m_isInitialized = true;
				yield break;
			}
			m_isInitialized = false;
			bool done = false;
			bool err = false;
			m_eventCtrl.ADACMHAHHKC_PreSetupEventHome(() =>
			{
				//0x13B44B8
				done = true;
			}, () =>
			{
				//0x13B44C4
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(!err)
			{
				done = false;
				err = false;
				JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LFOBIPKFOEF(OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection, 0, () =>
				{
					//0x13B44D0
					done = true;
				}, () =>
				{
					//0x13B44DC
					done = true;
					err = true;
				}, false);
				while(!done)
					yield return null;
				if(!err)
				{
					done = false;
					err = false;
					JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LFOBIPKFOEF(OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection, 1, () =>
					{
						//0x13B44E8
						done = true;
					}, () =>
					{
						//0x13B44F4
						done = true;
						err = true;
					}, false);
					while(!done)
						yield return null;
					if(!err)
					{
						done = false;
						err = false;
						CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
						{
							//0x13B4500
							done = true;
						}, () =>
						{
							//0x13B450C
							done = true;
							err = true;
						}, null);
						while(!done)
							yield return null;
						if(!err)
						{
							CrateQuestList();
							CreateSnsList();
							SetupHelp();
							m_cdSelect.transform.SetAsLastSibling();
							m_cdArrow.transform.SetAsLastSibling();
							m_musicInfo.transform.SetAsLastSibling();
							m_buttonSet.transform.SetAsLastSibling();
							m_eventInfo.transform.SetAsLastSibling();
							m_eventBanner.transform.SetAsLastSibling();
							m_timeLimitMessage.transform.SetAsLastSibling();
							m_lineButton.transform.SetAsLastSibling();
							m_musicInfo.onChangedDifficulty = OnSelectedDifficulty;
							m_cdSelect.onClickFlowButton = OnClickFlowButton;
							m_cdSelect.onSelectionChanged = OnSelectionChanged;
							m_cdSelect.onScrollRepeated = OnScrollRepeated;
							m_cdSelect.onScrollStarted = OnScrollStarted;
							m_cdSelect.onScrollUpdated = OnScrollUpdated;
							m_cdSelect.onScrollEnded = OnScrollEnded;
							m_cdSelect.onClickPlayButton = OnClickPlayButton;
							m_buttonSet.onClickRankingButton = OnClickRankingButton;
							m_buttonSet.onClickRewardButton = OnClickRewardButton;
							m_buttonSet.onClickDetailButton = OnClickDetailButton;
							m_buttonSet.onClickEventRankingButton = OnClickEventRankingButton;
							m_buttonSet.onClickEventRewardButton = OnClickEventRewardButton;
							m_buttonSet.onClickEnemyInfoButton = OnClickEnemyInfoButton;
							m_buttonSet.onClickStoryButton = OnClickStoryButton;
							m_buttonSet.onClickMissionButton = OnClickMissionButton;
							m_lineButton.onClickButton = OnChangeLineMode;
							m_musicInfo.MakeCache();
							m_cdSelect.MakeCache();
							MessageBank bk = MessageManager.Instance.GetBank("menu");
							m_musicInfo.SetNoInfoMessage(bk.GetMessageByLabel("music_not_exist_text_00"), bk.GetMessageByLabel("music_not_exist_line6_text_00"));
							m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N4, false, false);
							m_musicInfo.ChangeSelectedDiff(Difficulty.Type.Normal);
							m_eventInfo.SetStyle(MusicSelectEventInfo.Style.Ranking);
							m_eventInfo.SetTicketCountLabel(bk.GetMessageByLabel("music_event_collect_ticket_label"));
							m_eventInfo.SetCurrentValueLabel(bk.GetMessageByLabel("music_event_collect_current_point_label"));
							m_eventInfo.SetNextValueLabel(bk.GetMessageByLabel("music_event_collect_next_point_label"));
							m_eventInfo.SetValueUnitLabel(bk.GetMessageByLabel("music_event_collect_point_unit"));
							m_eventInfo.SetRewardLabel(bk.GetMessageByLabel("music_event_collect_reward_label"));
							m_eventInfo.SetRankUnitLabel(bk.GetMessageByLabel("music_event_collect_rank_unit"), 0);
							if(IsEventEndChallengePeriod)
							{
								m_eventInfo.SetRankLabel(bk.GetMessageByLabel("music_event_collect_rank_counting_label"), 0);
								m_overrideButtonStyle = MusicSelectButtonSet.OptionStyle.EndEventHome;
							}
							else
							{
								m_eventInfo.SetRankLabel(bk.GetMessageByLabel("music_event_collect_rank_label"), 0);
							}
                            ILDKBCLAFPB.APLMBKKCNKC_Select.IEFBBNFNKIJ_CollectEvent save = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.OCBIOMPAJFF_CollectEvent;
							save.FKEJBAHCMGC_CheckEvent(m_eventId);
							diff = save.FFACBDAJJJP_GetDifficulty();
							int mId = 0;
							FreeCategoryId.Type cat = FreeCategoryId.Type.None;
							if(!SelectUnitDanceFocus(out mId, out cat, ref m_isLine6Mode, false, OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection))
							{
								mId = save.BMBELGEDKEG_GetFreeMusicId();
							}
							int idx = m_musicList.FindIndex(mId, m_isLine6Mode, false);
							if(idx < 0)
							{
								if(!m_isLine6Mode)
									idx = 0;
								else
								{
									m_isLine6Mode = false;
									idx = m_musicList.FindIndex(mId, false, false);
									if(idx < 0)
										idx = 0;
								}
							}
							list_no = idx;
							ReviseDifficulty();
							ApplyBasicInfo();
							ApplyMusicListInfo();
							ApplyMusicInfo();
							ApplyEventInfo();
							m_isInitialized = true;
							Database.Instance.bonusData.SetEpisodeBonus(m_eventCtrl.LMDENICBIIB_GetEpisodesBonusList(0, 0));
							yield break;
                        }
					}
				}
			}
			m_isInitialized = true;
			GotoTitle();
		}

		// RVA: 0x13B1C2C Offset: 0x13B1C2C VA: 0x13B1C2C Slot: 39
		protected override void Release()
		{
			m_musicInfo.ReleaseCache();
			m_cdSelect.ReleaseCache();
		}

		// RVA: 0x13B1C7C Offset: 0x13B1C7C VA: 0x13B1C7C Slot: 40
		protected override void SetupViewMusicData()
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(m_eventCtrl == null)
			{
				//LAB_013b1de4
				m_musicList = new MusicDataList(new List<IBJAKJJICBC>());
			}
			else
			{
				if(IsEventEndChallengePeriod)
					m_musicList = new MusicDataList(IBJAKJJICBC.GCCBCAKFJMF(5, t, m_eventId, false), IBJAKJJICBC.GCCBCAKFJMF(5, t, m_eventId, true));
				else
					m_musicList = new MusicDataList(IBJAKJJICBC.ENHMHDALFDB(t, false, false), IBJAKJJICBC.ENHMHDALFDB(t, false, true));
			}
		}

		// RVA: 0x13B1EBC Offset: 0x13B1EBC VA: 0x13B1EBC Slot: 41
		protected override void ApplyBasicInfo()
		{
			base.ApplyBasicInfo();
		}

		// RVA: 0x13B1EC4 Offset: 0x13B1EC4 VA: 0x13B1EC4 Slot: 42
		protected override void ApplyMusicListInfo()
		{
			if(selectMusicData.POEGGBGOKGI_IsInfoLiveEntrance)
			{
				list_no++;
			}
			base.ApplyMusicListInfo();
		}

		// RVA: 0x13B1F2C Offset: 0x13B1F2C VA: 0x13B1F2C Slot: 44
		protected override void DelayedApplyMusicInfo()
		{
			if(m_isEventTimeLimit)
				return;
			base.DelayedApplyMusicInfo();
			if(!listIsEmpty)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.OCBIOMPAJFF_CollectEvent.HJHBGHMNGKL_SetDifficulty(diff);
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.OCBIOMPAJFF_CollectEvent.PDOLFONNGHB_SetFreeMusicId(freeMusicId);
			}
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// RVA: 0x13B20C0 Offset: 0x13B20C0 VA: 0x13B20C0 Slot: 45
		protected override string GetLiveEntranceMessage(IBJAKJJICBC musicData)
		{
			return MessageManager.Instance.GetMessage("menu", m_eventCtrl.MNDFBBMNJGN_IsUsingTicket ? "music_to_live_ticket_msg" : "music_to_live_stamina_msg");
		}

		// RVA: 0x13B21A8 Offset: 0x13B21A8 VA: 0x13B21A8 Slot: 46
		protected override void ApplyMusicInfoBasic(IBJAKJJICBC musicData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			//musicData.BJANNALFGGA_HasRanking;
			m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.None, false);
			m_cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.None);
			if(!m_eventCtrl.MNDFBBMNJGN_IsUsingTicket)
			{
				m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.ExEvent, false);
				m_cdSelect.SetPlayButtonType(musicData.IFNPBIJEPBO_IsDlded ? MusicSelectCDSelect.PlayButtonType.PlayEn : MusicSelectCDSelect.PlayButtonType.Download);
			}
			else
			{
				m_cdSelect.ApplyCursorEventStyle(musicData.NNJNNCGGKMC_IsLimited ? MusicSelectCDSelect.EventStyle.ExTicket : MusicSelectCDSelect.EventStyle.SimulationLive, false);
				m_cdSelect.ApplyEventTicketCount(m_eventCtrl.EAMODCHMCEL_GetTicketCost((int)diff, m_isLine6Mode));
				m_cdSelect.SetPlayButtonType(musicData.IFNPBIJEPBO_IsDlded ? MusicSelectCDSelect.PlayButtonType.Play : MusicSelectCDSelect.PlayButtonType.Download);
			}
			m_musicTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
			{
				//0x13B3B4C
				ApplyEventRemainTime(remain, true);
			};
			m_musicTimeWatcher.onEndCallback = null;
			m_musicTimeWatcher.WatchStart(m_eventCtrl.DPJCPDKALGI_End1, false);
		}

		// // RVA: 0x13B2524 Offset: 0x13B2524 VA: 0x13B2524
		private void ApplyEventInfo()
		{
			m_eventBanner.SetStyle(IsEventEndChallengePeriod ? MusicSelectEventBanner.Style.Enable : MusicSelectEventBanner.Style.Period);
			m_eventBanner.ChangeEventBanner(m_eventId);
			m_bannerTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
			{
				//0x13B3B78
				ApplyEventBannerRemainTime(remain, true);
			};
			m_bannerTimeWatcher.onEndCallback = null;
			m_bannerTimeWatcher.WatchStart(m_eventCtrl.DPJCPDKALGI_End1, true);
			if(m_eventCtrl.MNDFBBMNJGN_IsUsingTicket)
			{
				m_cdSelect.EventTicketEnable(false);
				GameManager.Instance.ItemTextureCache.Load(m_eventCtrl.JKIADEKHGLC_TicketItemId, (IiconTexture image) =>
				{
					//0x13B3BA4
					m_cdSelect.EventTicketEnable(true);
					m_cdSelect.SetEventItemIcon(image);
					m_eventBanner.SetEventTicket(image);
					m_eventInfo.SetTicketImage(image);
				});
			}
			m_eventInfo.SetTicketCount(m_eventCtrl.AELBIEDNPGB_GetTicketCount(null));
			if(IsEventCounting)
			{
				m_eventInfo.SetRankCouting(MessageManager.Instance.GetMessage("menu", "music_event_collect_rank_counting"), 0);
			}
			else
			{
				if(m_eventCtrl.CDINKAANIAA_Rank[0] < 1)
				{
					m_eventInfo.SetRankOrder(TextConstant.InvalidText, 0);
					m_eventInfo.SetRankUnitLabel(Smart.Format(MessageManager.Instance.GetMessage("menu", "music_event_collect_rank_unit"), 0), 0);
				}
				else
				{
					m_eventInfo.SetRankOrder(m_eventCtrl.CDINKAANIAA_Rank[0].ToString(), 0);
					m_eventInfo.SetRankUnitLabel(Smart.Format(MessageManager.Instance.GetMessage("menu", "music_event_collect_rank_unit"), m_eventCtrl.CDINKAANIAA_Rank[0]), 0);
				}
			}
			m_eventInfo.SetCurrentValue(EP_ToString(m_eventCtrl.FBGDBGKNKOD_GetCurrentPoint()));
            IHAEIOAKEMG rwd = m_eventCtrl.ILICNKILFKJ_GetNextReward();
            if (rwd == null || IsEventEndChallengePeriod)
			{
				m_eventInfo.SetRewardValid(false);
				m_eventInfo.SetNextValue(TextConstant.InvalidText);
				m_eventInfo.SetRewardEndLabel(TextConstant.InvalidText);
			}
			else
			{
				m_eventInfo.SetRewardValid(true);
				m_eventInfo.SetNextValue(EP_ToString(rwd.OJELCGDDAOM_MissingPoint));
				GameManager.Instance.ItemTextureCache.Load(rwd.HBHMAKNGKFK_Items[0].JJBGOIMEIPF_ItemId, (IiconTexture image) =>
				{
					//0x13B3C48
					m_eventInfo.SetRewardIcon(image);
				});
			}
		}

		// // RVA: 0x13B2D18 Offset: 0x13B2D18 VA: 0x13B2D18 Slot: 50
		protected override bool CurrentMusicDecisionCheck(Action cancelCallback, MKIKFJKPEHK viewBoostData, int selectIndex/* = 0*/)
		{
			if(viewBoostData == null)
			{
				if(!m_eventCtrl.MNDFBBMNJGN_IsUsingTicket)
				{
					viewBoostData = null;
					selectIndex = 0;
					//LAB_013b2f10
					return base.CurrentMusicDecisionCheck(cancelCallback, viewBoostData, selectIndex);
				}
				int haveTicket = m_eventCtrl.AELBIEDNPGB_GetTicketCount(null);
				int needTicket = m_eventCtrl.EAMODCHMCEL_GetTicketCost((int)diff, m_isLine6Mode);
				if(needTicket < haveTicket)
					return true;
				OpenTicketFewWindow(haveTicket, needTicket);
				if(cancelCallback != null)
					cancelCallback();
				return false;
			}
			else
			{
				if(viewBoostData.EFFBJDMGIGO(selectIndex) != MKIKFJKPEHK.IMIDFBNGHCG.FKLMPGJPDLL_2)
				{
					//LAB_013b2f10
					return base.CurrentMusicDecisionCheck(cancelCallback, viewBoostData, selectIndex);
				}
				OpenTicketFewWindow(m_eventCtrl.AELBIEDNPGB_GetTicketCount(null), viewBoostData.KLOOIJIDKGO_Cost[selectIndex]);
				if(cancelCallback != null)
					cancelCallback();
				return false;
			}
		}

		// RVA: 0x13B325C Offset: 0x13B325C VA: 0x13B325C Slot: 52
		protected override void LeaveForScrollStart()
		{
			base.LeaveForScrollStart();
			m_eventInfo.Leave();
		}

		// RVA: 0x13B3294 Offset: 0x13B3294 VA: 0x13B3294 Slot: 53
		protected override void EnterForScrollEnd()
		{
			base.EnterForScrollEnd();
			m_eventInfo.Enter();
		}

		// RVA: 0x13B32CC Offset: 0x13B32CC VA: 0x13B32CC Slot: 54
		protected override void OnChangedDifficulty()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.OCBIOMPAJFF_CollectEvent.HJHBGHMNGKL_SetDifficulty(diff);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// // RVA: 0x13B2CB8 Offset: 0x13B2CB8 VA: 0x13B2CB8
		private static string EP_ToString(long point)
		{
			if(point > 99999999)
				point = 99999999;
			return point.ToString();
		}

		// // RVA: 0x13B2F34 Offset: 0x13B2F34 VA: 0x13B2F34
		private void OpenTicketFewWindow(int currentTicket, int needTicket)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_event_collect_ticket_few_title"), SizeType.Small, Smart.Format(bk.GetMessageByLabel("popup_event_collect_ticket_few_msg"), needTicket, currentTicket), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Live, Type = PopupButton.ButtonType.Other }
			}, false, true), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13B3C7C
				if(label == PopupButton.ButtonLabel.Live)
					GotoRegularMusicSelect();
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x13B3404 Offset: 0x13B3404 VA: 0x13B3404
		protected void OnChangeLineMode(int style)
		{
			MenuScene.Instance.RaycastDisable();
			m_isLine6Mode = style == 1;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.HPDBEKAGKOD_SetIsLine6(m_isLine6Mode);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			this.StartCoroutineWatched(Co_ChangeLiveMode(() =>
			{
				//0x13B4410
				MenuScene.Instance.RaycastEnable();
			}));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EEE24 Offset: 0x6EEE24 VA: 0x6EEE24
		// // RVA: 0x13B36C8 Offset: 0x13B36C8 VA: 0x13B36C8
		private IEnumerator Co_ChangeLiveMode(Action callback)
		{
			bool isPlaying;

			//0x13B453C
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_musicInfo.TryLeave();
			m_buttonSet.TryLeave();
			m_eventInfo.TryLeave();
			m_eventBanner.TryLeave();
			MenuScene.Instance.HelpButton.TryLeave();
			isPlaying = true;
			while(isPlaying)
			{
				isPlaying = m_cdSelect.IsPlaying() || m_cdArrow.IsPlaying() || m_musicInfo.IsPlaying() || m_buttonSet.IsPlaying() || 
					m_eventInfo.IsPlaying() || m_eventBanner.IsPlaying();
				yield return null;
			}
			int idx = m_musicList.FindIndex(GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.OCBIOMPAJFF_CollectEvent.BMBELGEDKEG_GetFreeMusicId(), m_isLine6Mode, false);
			if(idx < 0)
				idx = 0;
			list_no = idx;
			ApplyMusicListInfo();
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
			ApplyBasicInfo();
			m_cdSelect.Enter();
			m_cdArrow.Enter();
			m_musicInfo.Enter();
			m_buttonSet.Enter();
			m_eventInfo.Enter();
			m_eventBanner.Enter();
			MenuScene.Instance.HelpButton.TryEnter();
			isPlaying = true;
			while(isPlaying)
			{
				isPlaying = m_cdSelect.IsPlaying() || m_cdArrow.IsPlaying() || m_musicInfo.IsPlaying() || m_buttonSet.IsPlaying() || 
					m_eventInfo.IsPlaying() || m_eventBanner.IsPlaying();
				yield return null;
			}
			if(callback != null)
				callback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EEE9C Offset: 0x6EEE9C VA: 0x6EEE9C
		// // RVA: 0x13B3790 Offset: 0x13B3790 VA: 0x13B3790
		private IEnumerator Co_RequestGetScoreRank(IKDICBBFBMI_EventBase eventCtrl)
		{
			//0x13B84B0
			HJNNLPIGHLM_EventCollection ev = eventCtrl as HJNNLPIGHLM_EventCollection;
			bool done = false;
			bool err = false;
			this.StartCoroutineWatched(ev.INOILCGFHIC_RequestGetScoreRank(() =>
			{
				//0x13B4520
				done = true;
			}, () =>
			{
				//0x13B452C
				done = true;
				err = true;
			}));
			while(!done)
				yield return null;
			if(err)
			{
				m_isInitialized = true;
				GotoTitle();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EEF14 Offset: 0x6EEF14 VA: 0x6EEF14
		// // RVA: 0x13B12EC Offset: 0x13B12EC VA: 0x13B12EC
		private IEnumerator Co_PreSetCanvas()
		{
			//0x13B7C38
			EventMusicSelectSceneArgs arg = Args as EventMusicSelectSceneArgs;
			EventMusicSelectSceneArgs argR = ArgsReturn as EventMusicSelectSceneArgs;
			m_isEventChecked = false;
			m_isEventTimeLimit = false;
			m_eventStatus = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0;
			m_eventCtrl = null;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(arg != null)
			{
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(arg.EventUniqueId);
				if(arg.isFromRhythmGame)
				{
					m_isLine6Mode = arg.isLine6Mode;
				}
			}
			else if(argR != null)
			{
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(argR.EventUniqueId);
				m_isLine6Mode = arg.isLine6Mode;
			}
			else
			{
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(m_eventId);
			}
			if(m_eventCtrl != null)
			{
				m_eventCtrl.HCDGELDHFHB_UpdateStatus(t);
				m_eventStatus = m_eventCtrl.NGOFCFJHOMI_Status;
			}
			if(!MenuScene.Instance.CheckEventLimit(m_eventCtrl, false, true))
			{
				m_eventId = m_eventCtrl.PGIIDPEGGPI_EventId;
				yield return Co.R(Co_Initialize_LoginBonusPopup(m_eventCtrl));
                BgType type = MenuScene.Instance.BgControl.GetCurrentType();
				if(type != BgType.MusicEvent)
				{
					this.StartCoroutineWatched(Co_ChangeBg(BgType.MusicEvent, m_eventId));
				}
				if(m_eventCtrl.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
					yield return Co.R(Co_RequestGetScoreRank(m_eventCtrl));
				SetupViewMusicData();
				m_isEventChecked = true;
				base.OnPreSetCanvas();
            }
			else
			{
				GameManager.Instance.fullscreenFader.Fade(0, Color.black);
				while(!PopupWindowManager.IsActivePopupWindow())
					yield return null;
				while(PopupWindowManager.IsActivePopupWindow())
					yield return null;
				AutoFadeFlag = false;
				m_isEventTimeLimit = true;
				m_isEventChecked = true;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EEF8C Offset: 0x6EEF8C VA: 0x6EEF8C
		// // RVA: 0x13B3878 Offset: 0x13B3878 VA: 0x13B3878 Slot: 55
		protected override IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x14
			FontInfo systemFont; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOp; // 0x20

			//0x13B64C8
			bundleName = new StringBuilder();
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/038.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicInfo");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x13B3C94
				instance.transform.SetParent(transform, false);
				m_musicInfo = instance.GetComponent<MusicSelectMusicInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicCD");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x13B3D64
				instance.transform.SetParent(transform, false);
				m_cdSelect = instance.GetComponent<MusicSelectCDSelect>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicCDArrow");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x13B3E34
				instance.transform.SetParent(transform, false);
				m_cdArrow = instance.GetComponent<MusicSelectCDArrow>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_ButtonSet");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x13B3F04
				instance.transform.SetParent(transform, false);
				m_buttonSet = instance.GetComponent<MusicSelectButtonSet>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventBanner");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x13B3FD4
				instance.transform.SetParent(transform, false);
				m_eventBanner = instance.GetComponent<MusicSelectEventBanner>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventInfo");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x13B40A4
				instance.transform.SetParent(transform, false);
				m_eventInfo = instance.GetComponent<MusicSelectEventInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventEnd");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x13B4174
				instance.transform.SetParent(transform, false);
				m_timeLimitMessage = instance.GetComponent<EventTimeLimitMessage>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_LineButton");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x13B4244
				instance.transform.SetParent(transform, false);
				m_lineButton = instance.GetComponent<MusicSelectLineButton>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			yield return Co.R(Co_LoadAssetBundle_LoginBonusPopup());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EF004 Offset: 0x6EF004 VA: 0x6EF004
		// // RVA: 0x13B3924 Offset: 0x13B3924 VA: 0x13B3924 Slot: 56
		protected override IEnumerator Co_WaitForLoaded()
		{
			//0x13B896C
			yield return Co.R(base.Co_WaitForLoaded());
			while(m_eventInfo == null || !m_eventInfo.IsLoaded())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EF07C Offset: 0x6EF07C VA: 0x6EF07C
		// // RVA: 0x13B39D0 Offset: 0x13B39D0 VA: 0x13B39D0 Slot: 57
		protected override IEnumerator Co_WaitForAnimEnd(Action onEnd)
		{
			//0x13B8830
			while(m_eventInfo.IsPlaying())
				yield return null;
			yield return Co.R(base.Co_WaitForAnimEnd(onEnd));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EF0F4 Offset: 0x6EF0F4 VA: 0x6EF0F4
		// // RVA: 0x13B3A98 Offset: 0x13B3A98 VA: 0x13B3A98 Slot: 37
		protected override IEnumerator Co_OnActivateScene()
		{
			//0x13B705C
			m_isEndActivateScene = false;
			if(m_isEventTimeLimit)
			{
				m_isEndActivateScene = true;
				yield break;
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_ShowReciveLoginAchievement());
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(m_isShowFirstHelp)
				{
					yield return Co.R(Co_ShowHelp());
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_Show_LoginBonusPopup(() =>
				{
					//0x13B4324
					m_eventInfo.SetTicketCount(m_eventCtrl.AELBIEDNPGB_GetTicketCount(null));
				}));
			}
			if(!MenuScene.Instance.DirtyChangeScene && TutorialProc.CanBeginnerMissionLiveClearLiveHelp())
			{
				yield return Co.R(TutorialProc.Co_BeginnerMissionLiveClear(m_cdSelect, null));
				MenuScene.SaveRequest();
				//LAB_013b75c8
				m_isEndActivateScene = true;
				yield break;
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MLBBKNLPBBD_HasShowTuto(BOPFPIHGJMD.PDLKAKEABDP.EILIAPKFCEO_0) && KDHGBOOECKC.HHCJCDFCLOB.LOCAIBNPKDL_IsPlayerLevelOk())
				{
					yield return Co.R(TutorialProc.Co_OffeReleaseTutorial(InputLimitButton.VOP, MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.VOP), () =>
					{
						//0x13B44AC
						return;
					}, BasicTutorialMessageId.Id_OfferRelease, true, m_cdSelect, null));
					//LAB_013b75c8
					m_isEndActivateScene = true;
					yield break;
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(SettingMenuPanel.IsValkyrieTuneUpUnlock() && !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsValkyrieUpgrade))
				{
					yield return Co.R(TutorialProc.Co_ValkyrieUpgrade(MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Setting), BasicTutorialMessageId.Id_ValkyrieUpgradeHome, InputLimitButton.Setting, TutorialPointer.Direction.Down, m_cdSelect, null));
					//LAB_013b75c8
					m_isEndActivateScene = true;
					yield break;
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(CanDoUnitDanceFocus(false))
				{
					yield return Co.R(TryShowUnitDanceTutorial());
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_CheckUnlock(null));
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				AddNotice(() =>
				{
					//0x13B4384
					CheckSnsNotice();
				});
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				AddNotice(() =>
				{
					//0x13B438C
					CheckOfferNotice();
				});
			}
			ShowNotice();
			m_isEndActivateScene = true;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6EF1BC Offset: 0x6EF1BC VA: 0x6EF1BC
		// [DebuggerHiddenAttribute] // RVA: 0x6EF1BC Offset: 0x6EF1BC VA: 0x6EF1BC
		// // RVA: 0x13B3C8C Offset: 0x13B3C8C VA: 0x13B3C8C
		// private void <>n__0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF26C Offset: 0x6EF26C VA: 0x6EF26C
		// [DebuggerHiddenAttribute] // RVA: 0x6EF26C Offset: 0x6EF26C VA: 0x6EF26C
		// // RVA: 0x13B4314 Offset: 0x13B4314 VA: 0x13B4314
		// private IEnumerator <>n__1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF29C Offset: 0x6EF29C VA: 0x6EF29C
		// [DebuggerHiddenAttribute] // RVA: 0x6EF29C Offset: 0x6EF29C VA: 0x6EF29C
		// // RVA: 0x13B431C Offset: 0x13B431C VA: 0x13B431C
		// private IEnumerator <>n__2(Action onEnd) { }
	}
}
