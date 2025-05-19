using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidScene : TransitionRoot
	{
		private PopupRaidBossEncountContentSetting m_popRaidBossEncountSetting = new PopupRaidBossEncountContentSetting(); // 0x48
		private PopupRaidBossHelpContentSetting m_popRaidBossHelpSetting = new PopupRaidBossHelpContentSetting(); // 0x4C
		private PopupRaidBossSortContentSetting m_popRaidBossSortSetting = new PopupRaidBossSortContentSetting(); // 0x50
		private PopupRaidPlateContentSetting m_popRaidPlateSetting = new PopupRaidPlateContentSetting(); // 0x54
		private PopupRaidHelpCompletionListContentSetting m_popRaidHelpCompletionListSetting = new PopupRaidHelpCompletionListContentSetting(); // 0x58
		private TextPopupSetting m_popRaidDefeatedSetting = new TextPopupSetting(); // 0x5C
		private TextPopupSetting m_popRaidEscapedSetting = new TextPopupSetting(); // 0x60
		private PopupItemGetSetting m_itemReceivePopupSetting = new PopupItemGetSetting(); // 0x64
		private RaidTopGauge m_topGauge; // 0x68
		private RaidBossSelectListLayout m_bossSelectListLayout; // 0x6C
		private RaidBossSelectImageLayout m_bossImageLayout; // 0x70
		private RaidMacrossCannonButton m_macrossCannonButton; // 0x74
		private RaidBottomButtonLayout m_bottomButtonLayout; // 0x78
		private RaidBossInfoLayout m_bossInfoLayout; // 0x7C
		private RaidBossSortLayout m_bossSortLayout; // 0x80
		private RaidBossNoneLayout m_bossNoneLayout; // 0x84
		private RaidEventEndLayout m_endEventLayout; // 0x88
		private RaidBossPop m_raidBossPop; // 0x8C
		private RaidBossSelectAnnounce m_announceLayout; // 0x90
		private RaidMccEffectLayout m_mccEffectLayout; // 0x94
		private RaidEventBanner m_eventBanner; // 0x98
		private RaidBossButtonsLayout m_buttonsLayout; // 0x9C
		private bool m_isEventTimeLimit; // 0xA0
		private List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> m_bossInfoList = new List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ>(); // 0xA4
		private List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> m_bossInfoViewList = new List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ>(); // 0xA8
		private List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> m_deadBossList = new List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ>(); // 0xAC
		private bool m_showitemReceivePopup; // 0xB0
		private bool m_showTicketGainedPopup; // 0xB1
		private bool m_loadingTicketGainedPopup; // 0xB2
		private TicketGainedPopupSetting m_ticketGainedPopupSetting; // 0xB4
		private IKDICBBFBMI_EventBase m_eventCtrl; // 0xB8
		private bool m_isEventChecked; // 0xBC
		private bool m_isEndActivateScene; // 0xBD
		private KGCNCBOKCBA.GNENJEHKMHD_EventStatus m_eventStatus; // 0xC0
		private bool m_isShowFirstHelp; // 0xC4
		private List<int> m_eventHelpId = new List<int>(2); // 0xC8
		private const float s_cdScrollSec = 0.2f;
		protected bool m_isInitialized; // 0xCC
		private List<FKMOKDCJFEN> m_questList; // 0xD0
		private bool isCallActSelect; // 0xD4
		private EventMusicSelectSceneArgs m_eventMusicSelectArgs; // 0xD8
		private PKNOKJNLPOE_EventRaid m_raidController; // 0xDC
		private bool m_isOpenEndUseFoldRadar; // 0xE0
		private int m_isRaidBossEncount; // 0xE4
		private List<Action> NoticeActionList = new List<Action>(); // 0xE8

		private bool IsBossNotExist { get { return m_bossInfoList.Count == 0; } } //0x181B590
		// public bool IsEventEndChallengePeriod { get; } 0x181B618
		private PKNOKJNLPOE_EventRaid RaidController { get
		{
			if(m_raidController == null)
				m_raidController = m_eventCtrl as PKNOKJNLPOE_EventRaid;
			return m_raidController;
		} } //0x181B62C

		// RVA: 0x181B6D4 Offset: 0x181B6D4 VA: 0x181B6D4 Slot: 29
		protected override void InputEnable()
		{
			base.InputEnable();
			if(InputStateCount > 0)
				return;
			m_bossSelectListLayout.InputEnable();
		}

		// RVA: 0x181B720 Offset: 0x181B720 VA: 0x181B720 Slot: 30
		protected override void InputDisable()
		{
			base.InputDisable();
			if(InputStateCount < 1)
				return;
			m_bossSelectListLayout.InputDisable();
		}

		// RVA: 0x181B76C Offset: 0x181B76C VA: 0x181B76C
		private void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0x181B828 Offset: 0x181B828 VA: 0x181B828
		private void Update()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712584 Offset: 0x712584 VA: 0x712584
		// // RVA: 0x181B82C Offset: 0x181B82C VA: 0x181B82C
		private IEnumerator Co_Initialize()
		{
			//0x1829290
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
				//0x1826498
				done = true;
			}, () =>
			{
				//0x18264A4
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(!err)
			{
				done = false;
				err = false;
				JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LFOBIPKFOEF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, 0, () =>
				{
					//0x18264B0
					done = true;
				}, () =>
				{
					//0x18264BC
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
						//0x18264C8
						done = true;
					}, () =>
					{
						//0x18264D4
						done = true;
						err = true;
					}, null);
					while(!done)
						yield return null;
					if(!err)
					{
						SetupHelp();
						CrateQuestList();
						m_bossNoneLayout.transform.SetAsLastSibling();
						m_endEventLayout.transform.SetAsLastSibling();
						m_bossImageLayout.transform.SetAsLastSibling();
						m_macrossCannonButton.transform.SetAsLastSibling();
						m_bossSelectListLayout.transform.SetAsLastSibling();
						m_bottomButtonLayout.transform.SetAsLastSibling();
						m_bossInfoLayout.transform.SetAsLastSibling();
						m_buttonsLayout.transform.SetAsLastSibling();
						m_bossSortLayout.transform.SetAsLastSibling();
						m_eventBanner.transform.SetAsLastSibling();
						m_topGauge.transform.SetAsLastSibling();
						m_mccEffectLayout.transform.SetAsLastSibling();
						m_raidBossPop.transform.SetAsLastSibling();
						m_bossSelectListLayout.UpdatePanelListner += UpdatePanel;
						m_bossSelectListLayout.ScrollStartListner += ScrollStartPanel;
						m_bossSelectListLayout.ScrollEndListner += ScrollEndPanel;
						m_bossSelectListLayout.PushAttackButtonListner += PushBossSelectAttackButton;
						m_bossSelectListLayout.PushProfileButtonListner += PushProfileButton;
						m_bossSelectListLayout.OnClickFlowButton += OnClickFlowButton;
						m_macrossCannonButton.OnClickMcrsButton += OnClickMcrsButton;
						m_bossSortLayout.PushUpdateButtonListner += PushBossInfoUpdateButton;
						m_bossSortLayout.PushSortInfoButtonListner += PushSortInfoButton;
						m_bossSortLayout.PushSortOrderButtonListner += PushSortOrderButton;
						m_buttonsLayout.PushRankingButtonListner += OnClickEventRankingButton;
						m_buttonsLayout.PushRewardListButtonListner += OnClickEventRewardButton;
						m_buttonsLayout.PushMissionButtonListner += OnClickMissionButton;
						m_bottomButtonLayout.PushEncounterBossButtonListner += OnPushEncounterBossBtn;
						m_bottomButtonLayout.PushRequestHelpButtonListner += OnPushRequestBossHelpButton;
						m_bottomButtonLayout.PushItemButtonListner += OnPushEncountItemButton;
						m_eventBanner.onClickBanner = OnClickEventBanner;
						m_topGauge.UpdateMacrossGaugeListner += UpdateMacrossGauge;
						m_topGauge.OnUseItemChargeMacrossCannon = () =>
						{
							//0x18264E0
							return m_bossInfoList.Count == 0;
						};
						m_topGauge.Initialize();
						m_macrossCannonButton.Initialize();
						m_eventBanner.ChangeEventBanner(m_eventCtrl.PGIIDPEGGPI_EventId);
						if(m_eventStatus < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
						{
							m_bossSortLayout.UpdateSortText();
							m_bossSortLayout.RefreshUpdateButton();
							m_announceLayout.SetText("");
							m_buttonsLayout.SetMissionBadge(IsReceiveMission());
							InitPopupSettings();
							m_isInitialized = true;
							isCallActSelect = false;
							Database.Instance.bonusData.SetEpisodeBonus(m_eventCtrl.LMDENICBIIB_GetEpisodesBonusList(0, 0));
						}
						else
						{
							m_bossSortLayout.DisableSortButtons(true);
							m_bossSortLayout.DisableUpdateButton(true);
							m_buttonsLayout.DisableRankingButton(true);
							m_bottomButtonLayout.SetButtonType(RaidBottomButtonLayout.RaidBottomBtn.EventEnd);
							m_bottomButtonLayout.SetItemImage(NKOBMDPHNGP_EventRaidLobby.ADPMLOEOAFD_GetTicketId());
							m_bottomButtonLayout.SetItemNum(RaidController.NPICFLFAIJK_GetNumTicket());
							yield return this.StartCoroutineWatched(Co_GetDeadBossList());
							if(m_deadBossList.Count == 0)
							{
								m_isInitialized = true;
							}
							else
							{
								MenuScene.Instance.InputEnable();
								MenuScene.Instance.Call(TransitionList.Type.RAID_REWARD, new RaidRewardArgs(GetTransitionUniqueId(), m_deadBossList), true);
								m_isInitialized = true;
							}
						}
						yield break;
					}
				}
			}
			m_isInitialized = true;
			GotoTitle();
		}

		// RVA: 0x181B8D8 Offset: 0x181B8D8 VA: 0x181B8D8
		private void Release()
		{
			m_bossSelectListLayout.UpdatePanelListner -= UpdatePanel;
			m_bossSelectListLayout.ScrollStartListner -= ScrollStartPanel;
			m_bossSelectListLayout.ScrollEndListner -= ScrollEndPanel;
			m_bossSelectListLayout.PushAttackButtonListner -= PushBossSelectAttackButton;
			m_bossSelectListLayout.PushProfileButtonListner -= PushProfileButton;
			m_bossSelectListLayout.OnClickFlowButton -= OnClickFlowButton;
			m_macrossCannonButton.OnClickMcrsButton -= OnClickMcrsButton;
			m_bossSortLayout.PushUpdateButtonListner -= PushBossInfoUpdateButton;
			m_bossSortLayout.PushSortInfoButtonListner -= PushSortInfoButton;
			m_bossSortLayout.PushSortOrderButtonListner -= PushSortOrderButton;
			m_buttonsLayout.PushRankingButtonListner -= OnClickEventRankingButton;
			m_buttonsLayout.PushRewardListButtonListner -= OnClickEventRewardButton;
			m_buttonsLayout.PushMissionButtonListner -= OnClickMissionButton;
			m_bottomButtonLayout.PushEncounterBossButtonListner -= OnPushEncounterBossBtn;
			m_bottomButtonLayout.PushRequestHelpButtonListner -= OnPushRequestBossHelpButton;
			m_bottomButtonLayout.PushItemButtonListner -= OnPushEncountItemButton;
			m_topGauge.UpdateMacrossGaugeListner -= UpdateMacrossGauge;
			m_topGauge.OnUseItemChargeMacrossCannon = null;
			m_eventBanner.Release();
			m_bossSelectListLayout.Release();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7125FC Offset: 0x7125FC VA: 0x7125FC
		// // RVA: 0x181B79C Offset: 0x181B79C VA: 0x181B79C
		private IEnumerator Co_LoadResources()
		{
			//0x182C7B8
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712674 Offset: 0x712674 VA: 0x712674
		// // RVA: 0x181BFF8 Offset: 0x181BFF8 VA: 0x181BFF8
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x14
			FontInfo systemFont; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOp; // 0x20

			//0x182B520
			bundleName = new StringBuilder();
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/200.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_apbar_tr_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1823E04
				instance.transform.SetParent(transform, false);
				m_topGauge = instance.GetComponent<RaidTopGauge>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_boss_select_cc_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1823ED4
				instance.transform.SetParent(transform, false);
				m_bossImageLayout = instance.GetComponent<RaidBossSelectImageLayout>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_boss_select_cr_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1823FA4
				instance.transform.SetParent(transform, false);
				m_bossSelectListLayout = instance.GetComponent<RaidBossSelectListLayout>();
			}));
			m_bossSelectListLayout.Initialize();
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_boss_select_bc_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1824074
				instance.transform.SetParent(transform, false);
				m_macrossCannonButton = instance.GetComponent<RaidMacrossCannonButton>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_boss_select_bl_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1824144
				instance.transform.SetParent(transform, false);
				m_bottomButtonLayout = instance.GetComponent<RaidBottomButtonLayout>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_boss_select_tl_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1824214
				instance.transform.SetParent(transform, false);
				m_bossInfoLayout = instance.GetComponent<RaidBossInfoLayout>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_boss_btn_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x18242E4
				instance.transform.SetParent(transform, false);
				m_buttonsLayout = instance.GetComponent<RaidBossButtonsLayout>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_boss_select_tr_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x18243B4
				instance.transform.SetParent(transform, false);
				m_bossSortLayout = instance.GetComponent<RaidBossSortLayout>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_info_banner_01_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1824484
				instance.transform.SetParent(transform, false);
				m_eventBanner = instance.GetComponent<RaidEventBanner>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_boss_none_cc_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1824554
				instance.transform.SetParent(transform, false);
				m_bossNoneLayout = instance.GetComponent<RaidBossNoneLayout>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_boss_end_cc_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1824624
				instance.transform.SetParent(transform, false);
				m_endEventLayout = instance.GetComponent<RaidEventEndLayout>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "RaidBossPop");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x18246F4
				instance.transform.SetParent(transform, false);
				m_raidBossPop = instance.GetComponent<RaidBossPop>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_announce_bc_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x18247C4
				instance.transform.SetParent(transform, false);
				m_announceLayout = instance.GetComponent<RaidBossSelectAnnounce>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_mcc_ef_bc_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1824894
				instance.transform.SetParent(transform, false);
				m_mccEffectLayout = instance.GetComponent<RaidMccEffectLayout>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			yield return Co.R(Co_LoadAssetBundle_LoginBonusPopup());
		}

		// RVA: 0x181C0A4 Offset: 0x181C0A4 VA: 0x181C0A4 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isInitialized;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7126EC Offset: 0x7126EC VA: 0x7126EC
		// // RVA: 0x181C0AC Offset: 0x181C0AC VA: 0x181C0AC
		private IEnumerator Co_UpdateBossInfoList(bool isSortSet/* = False*/, Action<bool> onEndCallback)
		{
			MessageBank msgBank;

			//0xCEB978
			if(IsEndRaidEvent())
			{
				if(onEndCallback != null)
					onEndCallback(false);
			}
			else
			{
				MenuScene.Instance.InputDisable();
				msgBank = MessageManager.Instance.GetBank("menu");
				bool done = false;
				RaidController.AIMIFGFHBCE(() =>
				{
					//0x1826584
					done = true;
				}, () =>
				{
					//0x1826590
					if(onEndCallback != null)
						onEndCallback(false);
					MenuScene.Instance.InputEnable();
					MenuScene.Instance.GotoTitle();
				});
				while(!done)
					yield return null;
				m_bossInfoList.Clear();
				m_deadBossList.Clear();
				if(RaidController.PMIIMELDPAJ_GetMyBoss().CMCKNKKCNDK_Status == NHCDBBBMFFG.NFDONDKDHPK_3_Escaped)
				{
					//LAB_00cec080
					RaidController.PMIIMELDPAJ_GetMyBoss().LHPDDGIJKNB();
				}
				else if(RaidController.PMIIMELDPAJ_GetMyBoss().CMCKNKKCNDK_Status == NHCDBBBMFFG.OPNEOJEGDJB_2_Dead)
				{
					if(!RaidController.PMIIMELDPAJ_GetMyBoss().ICCOOAAJEIN_CanReceiveReward)
					{
						RaidController.PMIIMELDPAJ_GetMyBoss().LHPDDGIJKNB();
					}
					else
					{
						m_deadBossList.Add(RaidController.PMIIMELDPAJ_GetMyBoss());
					}
				}
				else if(RaidController.PMIIMELDPAJ_GetMyBoss().CMCKNKKCNDK_Status == NHCDBBBMFFG.MBFHILFLPJL_1_Alive)
				{
					m_bossInfoList.Add(RaidController.PMIIMELDPAJ_GetMyBoss());
				}
				for(int i = 0; i < RaidController.EHJOBALDPBG(); i++)
				{
					if(!RaidController.HCFDHLNNDAN(i).ICCOOAAJEIN_CanReceiveReward)
					{
						m_bossInfoList.Add(RaidController.HCFDHLNNDAN(i));
					}
					else
					{
						m_deadBossList.Add(RaidController.HCFDHLNNDAN(i));
					}
				}
				m_bossInfoViewList = FilterBossInfoList(m_bossInfoList);
				if(m_bossInfoViewList.Count == 0)
				{
					if(!IsDefaultFilter())
					{
						bool popWindow = true;
						InitSortFilter();
						m_bossInfoViewList = FilterBossInfoList(m_bossInfoList);
						TextPopupSetting s = new TextPopupSetting();
						s.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
						};
						s.Text = msgBank.GetMessageByLabel(isSortSet ? "pop_raid_warning_sort_text" : "pop_raid_init_sort_text");
						s.IsCaption = false;
						PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0x1826684
							popWindow = false;
						}, null, null, null, true, true, false);
						while(popWindow)
							yield return null;
					}
				}
				SortBossInfoList(ref m_bossInfoViewList);
				m_bossSelectListLayout.InitPanel(m_bossInfoViewList.Count, m_bossInfoViewList.IndexOf(RaidController.PMIIMELDPAJ_GetMyBoss()));
				yield return this.StartCoroutineWatched(Co_UpdateBossSelectLayout());
				if(m_deadBossList.Count != 0)
				{
					if(onEndCallback != null)
						onEndCallback(true);
					MenuScene.Instance.InputEnable();
					MenuScene.Instance.Call(TransitionList.Type.RAID_REWARD, new RaidRewardArgs(GetTransitionUniqueId(), m_deadBossList), true);
					this.StartCoroutineWatched(Co_TapGuardForSceneChange());
				}
				else
				{
					List<PKNOKJNLPOE_EventRaid.KMFKFGEDPGJ> l = RaidController.DIFIHMCHDJF();
					if(l.Count != 0)
					{
						int helpCount = 0;
						List<PKNOKJNLPOE_EventRaid.KMFKFGEDPGJ> l5 = new List<PKNOKJNLPOE_EventRaid.KMFKFGEDPGJ>();
						List<PKNOKJNLPOE_EventRaid.KMFKFGEDPGJ> l6 = new List<PKNOKJNLPOE_EventRaid.KMFKFGEDPGJ>();
						for(int i = 0; i < l.Count; i++)
						{
							if(l[i].INDDJNMPONH == PKNOKJNLPOE_EventRaid.BKKPEJEABJN.AOFLHCJEDOA_0)
							{
								l5.Add(l[i]);
							}
							else
							{
								l6.Add(l[i]);
							}
						}
						int i4c = 0;
						int i50 = 0;
						for(int i = 0; i < l5.Count; i++)
						{
							i50 = l5[i].GBJFCGOBHDO_RawAddedDamage;
							i4c = l5[i].IOMHJCBMADB_AddedDamage;
						}
						for(int i = 0; i < l6.Count; i++)
						{
							helpCount = l6[i].GBJFCGOBHDO_RawAddedDamage;
						}
						string s17 = "";
						if(l5.Count != 0)
						{
							if(i50 < 2)
							{
								s17 = string.Format(msgBank.GetMessageByLabel("raid_announce_text"), l5[0].LBODHBDOMGK_PlayerName, i4c);
							}
							else if(l5.Count == 1)
							{
								s17 = string.Format(msgBank.GetMessageByLabel("raid_announce_text03"), l5[0].LBODHBDOMGK_PlayerName, i4c, i50);
							}
							else
							{
								s17 = string.Format(msgBank.GetMessageByLabel("raid_announce_text02"), l5[l5.Count - 1].LBODHBDOMGK_PlayerName, i4c, i50);
							}
						}
						if(i4c == 0)
						{
							this.StartCoroutineWatched(Co_StartHelpAnnounceAnim(helpCount));
						}
						else
						{
							int i34, i38;
							bool b39;
							RaidController.HAPDLPAKMLF(out i34, out i38, out b39);
							m_announceLayout.SetText(s17);
							if(!b39)
							{
								m_topGauge.SetBalloonText(string.Format(msgBank.GetMessageByLabel("raid_top_gauge_text"), i4c));
							}
							else
							{
								m_topGauge.SetBalloonText(msgBank.GetMessageByLabel("raid_top_gauge_max_text"));
							}
							this.StartCoroutineWatched(Co_StartAddGaugeAnim(() =>
							{
								//0x1826698
								if(helpCount == 0)
									return;
								this.StartCoroutineWatched(Co_StartHelpAnnounceAnim(helpCount));
							}));
						}
						RaidController.DIFIHMCHDJF().Clear();
					}
					if(onEndCallback != null)
						onEndCallback(true);
					MenuScene.Instance.InputEnable();
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712764 Offset: 0x712764 VA: 0x712764
		// // RVA: 0x181C168 Offset: 0x181C168 VA: 0x181C168
		private IEnumerator Co_GetDeadBossList()
		{
			//0x1828D7C
			bool done = false;
			RaidController.AIMIFGFHBCE(() =>
			{
				//0x1826738
				done = true;
			}, () =>
			{
				//0x182576C
				MenuScene.Instance.InputEnable();
				MenuScene.Instance.GotoTitle();
			});
			while(!done)
				yield return null;
			m_bossInfoList.Clear();
			m_deadBossList.Clear();
			if(RaidController.PMIIMELDPAJ_GetMyBoss().CMCKNKKCNDK_Status == NHCDBBBMFFG.OPNEOJEGDJB_2_Dead && RaidController.PMIIMELDPAJ_GetMyBoss().ICCOOAAJEIN_CanReceiveReward)
			{
				m_deadBossList.Add(RaidController.PMIIMELDPAJ_GetMyBoss());
			}
			for(int i = 0; i < RaidController.EHJOBALDPBG(); i++)
			{
				if(RaidController.HCFDHLNNDAN(i).ICCOOAAJEIN_CanReceiveReward)
				{
					m_deadBossList.Add(RaidController.HCFDHLNNDAN(i));
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7127DC Offset: 0x7127DC VA: 0x7127DC
		// // RVA: 0x181C214 Offset: 0x181C214 VA: 0x181C214
		private IEnumerator Co_StartAddGaugeAnim(Action endCallback)
		{
			float waitTime; // 0x1C

			//0x182FEC8
			bool endTextScroll = false;
			bool endTopGauge = false;
			bool endMccEffect = false;
			bool endBalloon = false;
			m_announceLayout.TextShow();
			m_announceLayout.TextScrollIn(() =>
			{
				//0x182674C
				endTextScroll = true;
			});
			while(!endTextScroll)
				yield return null;
			waitTime = 0.5f;
			while(waitTime >= 0)
			{
				waitTime -= Time.deltaTime;
				if(MenuScene.Instance.IsTransition())
				{
					m_announceLayout.TextHide();
					yield break;
				}
				yield return null;
			}
			this.StartCoroutineWatched(m_topGauge.Co_StartAddGaugeAnim(() =>
			{
				//0x1826758
				endTopGauge = true;
			}));
			this.StartCoroutineWatched(m_mccEffectLayout.Co_StartAddGaugeAnim(() =>
			{
				//0x1826764
				endMccEffect = true;
			}));
			while(!endTopGauge || !endMccEffect)
			{
				if(MenuScene.Instance.IsTransition())
				{
					m_topGauge.HideAddGaugeAnim();
					m_mccEffectLayout.Hide();
					yield break;
				}
				yield return null;
			}
			this.StartCoroutineWatched(m_topGauge.Co_StartBalloonAnim(() =>
			{
				//0x1826770
				endBalloon = true;
			}));
			while(!endBalloon)
			{
				if(MenuScene.Instance.IsTransition())
				{
					m_topGauge.HideBalloonAnim();
					yield break;
				}
				yield return null;
			}
			waitTime = 0.5f;
			while(waitTime >= 0)
			{
				waitTime -= 0.5f;
				if(MenuScene.Instance.IsTransition())
				{
					yield break;
				}
				yield return null;
			}
			m_announceLayout.TextScrollOut();
			endCallback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712854 Offset: 0x712854 VA: 0x712854
		// // RVA: 0x181C2DC Offset: 0x181C2DC VA: 0x181C2DC
		private IEnumerator Co_StartHelpAnnounceAnim(int helpCount)
		{
			//0xCEAC40
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_announceLayout.SetText(string.Format(bk.GetMessageByLabel("raid_new_announce_text"), helpCount));
			bool endTextScroll = false;
			m_announceLayout.TextShow();
			m_announceLayout.TextScrollIn(() =>
			{
				//0x1826784
				endTextScroll = true;
			});
			while(!endTextScroll)
				yield return null;
			yield return new WaitForSeconds(3);
			m_announceLayout.TextScrollOut();
		}

		// // RVA: 0x181C380 Offset: 0x181C380 VA: 0x181C380
		private List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> FilterBossInfoList(List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> bossInfoList)
		{
			List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> res = new List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ>();
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.PFONKAHHKJK_Raid raidSave = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid;
			for(int i = 0; i < bossInfoList.Count; i++)
			{
				if(CheckBossFilter(bossInfoList[i], (uint)raidSave.AOKFAJOMCKK_bossFilter))
				{
					if(CheckRankFilter(bossInfoList[i], (uint)raidSave.MOAJJHLGILP_rankFilter))
					{
						if(CheckJoinFilter(bossInfoList[i], (uint)raidSave.COIKKDHMGID_joinFilter))
						{
							res.Add(bossInfoList[i]);
						}
					}
				}
			}
			return res;
        }

		// // RVA: 0x181C990 Offset: 0x181C990 VA: 0x181C990
		private void SortBossInfoList(ref List<PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ> bossInfoList)
		{
            int sort = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.LHPDCGNKPHD_sortItem;
            int order = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.EILKGEADKGH_order;
			bossInfoList.Sort((PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ a, PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ b) =>
			{
				//0x1825830
				return a.PPFNGGCBJKC_Id - b.PPFNGGCBJKC_Id;
			});
			switch(sort)
			{
				case 0:
					Algorithms.InsertSort(bossInfoList, (PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ a, PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ b) =>
					{
						//0x1825870
						return a.FJOLNJLLJEJ_Rank - b.FJOLNJLLJEJ_Rank;
					});
					break;
				case 1:
					Algorithms.InsertSort(bossInfoList, (PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ a, PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ b) =>
					{
						//0x18258B0
						return (int)((a.BCCOMAODPJI_HpCurrent * 1.0f / a.PIKKHCGNGNN_HpMax - b.BCCOMAODPJI_HpCurrent * 1.0f / b.PIKKHCGNGNN_HpMax) * 1000000);
					});
					break;
				case 2:
					Algorithms.InsertSort(bossInfoList, (PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ a, PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ b) =>
					{
						//0x1825958
						return a.BCCOMAODPJI_HpCurrent - b.BCCOMAODPJI_HpCurrent;
					});
					break;
				case 3:
					Algorithms.InsertSort(bossInfoList, (PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ a, PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ b) =>
					{
						//0x1825998
						return (int)(a.OCFJGNPMJBA_GetTime() - b.OCFJGNPMJBA_GetTime());
					});
					break;
				case 4:
					Algorithms.InsertSort(bossInfoList, (PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ a, PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ b) =>
					{
						//0x18259EC
						return a.MHABJOMJCFI_JoinedMember - b.MHABJOMJCFI_JoinedMember;
					});
					break;
				default:
					break;
			}
			if(order != 0)
			{
				bossInfoList.Reverse();
			}
        }

		// // RVA: 0x181D144 Offset: 0x181D144 VA: 0x181D144
		private void InitSortFilter()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.AOKFAJOMCKK_bossFilter = 0;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.MOAJJHLGILP_rankFilter = 0;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.COIKKDHMGID_joinFilter = 0;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// // RVA: 0x181D3A4 Offset: 0x181D3A4 VA: 0x181D3A4
		private bool IsDefaultFilter()
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.AOKFAJOMCKK_bossFilter == 0 && 
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.MOAJJHLGILP_rankFilter == 0 && 
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.COIKKDHMGID_joinFilter == 0;
		}

		// // RVA: 0x181C768 Offset: 0x181C768 VA: 0x181C768
		private bool CheckBossFilter(PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ bossInfo, uint bit)
		{
			if(bit != 0)
			{
				if((bit & 2) != 0)
				{
					if(!bossInfo.IKICLMGFFPB_IsSpecial)
						return true;
				}
				if((bit & 4) != 0)
				{
					if(bossInfo.IKICLMGFFPB_IsSpecial)
						return true;
				}
				return false;
			}
			return true;
		}

		// // RVA: 0x181C7DC Offset: 0x181C7DC VA: 0x181C7DC
		private bool CheckRankFilter(PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ bossInfo, uint bit)
		{
			if(bit != 0)
			{
				if((bit & 2) != 0)
				{
					if(bossInfo.FJOLNJLLJEJ_Rank >= 18 && bossInfo.FJOLNJLLJEJ_Rank < 21)
						return true;
				}
				if((bit & 4) != 0)
				{
					if(bossInfo.FJOLNJLLJEJ_Rank >= 15 && bossInfo.FJOLNJLLJEJ_Rank < 18)
						return true;
				}
				if((bit & 8) != 0)
				{
					if(bossInfo.FJOLNJLLJEJ_Rank >= 12 && bossInfo.FJOLNJLLJEJ_Rank < 15)
						return true;
				}
				if((bit & 16) != 0)
				{
					if(bossInfo.FJOLNJLLJEJ_Rank >= 9 && bossInfo.FJOLNJLLJEJ_Rank < 12)
						return true;
				}
				if((bit & 32) != 0)
				{
					if(bossInfo.FJOLNJLLJEJ_Rank >= 6 && bossInfo.FJOLNJLLJEJ_Rank < 9)
						return true;
				}
				if((bit & 64) != 0)
				{
					if(bossInfo.FJOLNJLLJEJ_Rank >= 3 && bossInfo.FJOLNJLLJEJ_Rank < 6)
						return true;
				}
				if((bit & 128) != 0)
				{
					if(bossInfo.FJOLNJLLJEJ_Rank >= 0 && bossInfo.FJOLNJLLJEJ_Rank < 3)
						return true;
				}
				return false;
			}
			return true;
		}

		// // RVA: 0x181D4C8 Offset: 0x181D4C8 VA: 0x181D4C8
		// public bool IsRange(int a, int from, int to) { }

		// // RVA: 0x181C91C Offset: 0x181C91C VA: 0x181C91C
		private bool CheckJoinFilter(PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ bossInfo, uint bit)
		{
			if(bit != 0)
			{
				if((bit & 2) != 0)
				{
					if(bossInfo.DLMNFENNCJG_IsEntry)
						return true;
				}
				if((bit & 4) != 0)
				{
					if(!bossInfo.DLMNFENNCJG_IsEntry)
						return true;
				}
				return false;
			}
			return true;
		}

		// // RVA: 0x181D4E8 Offset: 0x181D4E8 VA: 0x181D4E8
		private void OnClickMcrsButton()
		{
			SoundManager.Instance.sePlayerRaid.Play((int)mcrs.cs_se_raid.SE_RAID_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(!IsEndRaidEvent())
			{
				if(!MenuScene.CheckDatelineAndAssetUpdate())
				{
					if(RaidController.IOGPHNLODAF_IsMcGaugeMax(true))
					{
						if(m_bossSelectListLayout.CurrentIndex < m_bossInfoViewList.Count)
						{
							MenuScene.Instance.InputDisable();
							MenuScene.Instance.RaycastDisable();
							RaidController.KMDELKHBDNN(m_bossInfoViewList[m_bossSelectListLayout.CurrentIndex]);
							RaidController.EMEAEENFOOM();
							PopupWindowManager.Show(m_popRaidPlateSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
							{
								//0x1824964
								MenuScene.Instance.InputEnable();
								if(MenuScene.CheckDatelineAndAssetUpdate() || IsEndRaidEvent() || type != PopupButton.ButtonType.Positive)
								{
									MenuScene.Instance.RaycastEnable();
								}
								else
								{
									RaidController.FDNIODNLDAI(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.EKIGHDLEBAH_4);
									RaidController.JDGCABLBFLH(() =>
									{
										//0x1824C4C
										MenuScene.Instance.RaycastEnable();
										if(SoundManager.Instance.bgmPlayer.isPlaying)
										{
											SoundManager.Instance.bgmPlayer.FadeOut(0.3f, null);
										}
										CallMacrossCannon();
									}, () =>
									{
										//0x1824D6C
										MenuScene.Instance.RaycastEnable();
										if(RaidController.JIBMOEHKMGB.CMCKNKKCNDK_Status == NHCDBBBMFFG.OPNEOJEGDJB_2_Dead)
										{
											PopupWindowManager.Show(m_popRaidDefeatedSetting, (PopupWindowControl control2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
											{
												//0x182500C
												this.StartCoroutineWatched(Co_UpdateBossInfoList(false, null));
											}, null, null, null, true, true, false);
										}
										if(RaidController.JIBMOEHKMGB.CMCKNKKCNDK_Status == NHCDBBBMFFG.NFDONDKDHPK_3_Escaped)
										{
											PopupWindowManager.Show(m_popRaidEscapedSetting, (PopupWindowControl control2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
											{
												//0x1825038
												this.StartCoroutineWatched(Co_UpdateBossInfoList(false, null));
											}, null, null, null, true, true, false);
										}
									}, () =>
									{
										//0x1825A2C
										MenuScene.Instance.RaycastEnable();
										MenuScene.Instance.GotoTitle();
									});
								}
							}, null, null, null, true, true, false);
						}
					}
				}
			}
		}

		// // RVA: 0x181DB48 Offset: 0x181DB48 VA: 0x181DB48
		private void CallMacrossCannon()
		{
			RaidRewardArgs arg = new RaidRewardArgs(GetTransitionUniqueId(), null);
			MenuScene.Instance.Call(TransitionList.Type.RAID_REWARD, arg, true);
		}

		// // RVA: 0x181DCB0 Offset: 0x181DCB0 VA: 0x181DCB0
		private void SetBossHelpButtonType(int index)
		{
			if(index < 0)
				index = 0;
			if(!RaidController.PMIIMELDPAJ_GetMyBoss().DNJGAJPIIPI)
			{
				m_bottomButtonLayout.SetButtonType(RaidBottomButtonLayout.RaidBottomBtn.EncounterBoss);
			}
			else
			{
				if(m_bossInfoViewList.Count != 0)
				{
					if(m_bossInfoViewList[index].PPFNGGCBJKC_Id == RaidController.PMIIMELDPAJ_GetMyBoss().PPFNGGCBJKC_Id)
					{
						if(RaidController.LMIFOCDCNAI())
						{
							m_bottomButtonLayout.SetButtonType(RaidBottomButtonLayout.RaidBottomBtn.RequestHelp);
							m_bottomButtonLayout.SetBossHelpCount(RaidController.HEMEDMMBIBH_GetBossHelpCountLeft(RaidController.PMIIMELDPAJ_GetMyBoss().PPFNGGCBJKC_Id));
							return;
						}
						if(!RaidController.KIHAEAEEFJE_IsOverLimitHelp(RaidController.PMIIMELDPAJ_GetMyBoss().PPFNGGCBJKC_Id))
						{
							m_bottomButtonLayout.SetButtonType(RaidBottomButtonLayout.RaidBottomBtn.RequestHelpDone);
							m_bottomButtonLayout.SetBossHelpCount(RaidController.HEMEDMMBIBH_GetBossHelpCountLeft(RaidController.PMIIMELDPAJ_GetMyBoss().PPFNGGCBJKC_Id));
							m_bottomButtonLayout.SetBossHelpWatcher(RaidController.GCDHLLHHIHA_GetNextRequestTime(RaidController.PMIIMELDPAJ_GetMyBoss().PPFNGGCBJKC_Id), RaidController.HEMEDMMBIBH_GetBossHelpCountLeft(RaidController.PMIIMELDPAJ_GetMyBoss().PPFNGGCBJKC_Id) != 0, false);
							return;
						}
					}
				}
				m_bottomButtonLayout.SetButtonType(RaidBottomButtonLayout.RaidBottomBtn.RequestHelpDone);
				m_bottomButtonLayout.HiddenBossHelpCount();
				m_bottomButtonLayout.HiddenBossHelpWatcher();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7128CC Offset: 0x7128CC VA: 0x7128CC
		// // RVA: 0x181E118 Offset: 0x181E118 VA: 0x181E118
		private IEnumerator Co_UpdateBossSelectLayout()
		{
			//0xCED1C4
			int idx = m_bossInfoViewList.IndexOf(RaidController.PMIIMELDPAJ_GetMyBoss());
			if(idx < 0)
				idx = 0;
			SetBossHelpButtonType(idx);
			m_bottomButtonLayout.SetItemImage(NKOBMDPHNGP_EventRaidLobby.ADPMLOEOAFD_GetTicketId());
			m_bottomButtonLayout.SetItemNum(RaidController.NPICFLFAIJK_GetNumTicket());
			if(m_bossInfoList.Count == 0)
			{
				m_bossInfoLayout.Leave();
				m_bossSelectListLayout.Leave();
				m_bossImageLayout.Leave();
				m_macrossCannonButton.Leave();
			}
			else
			{
				bool waitBossImage = false;
				m_bossImageLayout.SetBossImage(m_bossInfoList[idx].HPPDFBKEJCG_BgId, () =>
				{
					//0x1826798
					waitBossImage = true;
				});
				m_bossInfoLayout.SetBossName(m_bossInfoList[idx].INDDJNMPONH_Type);
				m_bossInfoLayout.SetSeries(RaidController.NNDFMCHDJOH_GetBossSerie(m_bossInfoList[idx].INDDJNMPONH_Type));
				m_bossInfoLayout.SetSongBonus(m_bossInfoList[idx].NFOOOBMJINC_MissionBonusNum);
				m_bossInfoLayout.SetMissionInfoText(m_bossInfoList[idx].CJLHLKKNMEE_MissionText);
				m_bossInfoLayout.SetSp(m_bossInfoList[idx].IKICLMGFFPB_IsSpecial);
				m_bossInfoLayout.SetAssistPlay(!RaidController.LIAJFGCJJIM_HasAssist(m_bossInfoList[idx].PPFNGGCBJKC_Id));
				while(!waitBossImage)
					yield return null;
				m_bossSelectListLayout.gameObject.SetActive(true);
				m_bossImageLayout.gameObject.SetActive(true);
				m_bossInfoLayout.Enter();
				m_bossSelectListLayout.Enter();
				m_bossImageLayout.Enter(() =>
				{
					//0x1825064
					CheckMacrossCannnon();
				});
			}
			//LAB_00ced99c
			if(m_bossInfoList.Count == 0)
			{
				if(RaidController.FJBIJAGCGKC_IsEncounterTimeOk())
				{
					m_bossNoneLayout.Enter();
				}
			}
			else
			{
				m_bossNoneLayout.Hide();
			}
			m_bossInfoLayout.SetBossNum(m_bossInfoList.Count);
			m_bossSortLayout.UpdateSortText();
			m_bossSortLayout.DisableSortButtons(IsBossNotExist);
		}

		// // RVA: 0x181E1A0 Offset: 0x181E1A0 VA: 0x181E1A0
		private void UpdatePanel(int index, RaidBossSelectListLayout.BossPanelController controller)
		{
			if(m_bossInfoViewList.Count < index)
				return;
			controller.SetPlayerName(m_bossInfoViewList[index].LBODHBDOMGK_Name);
			controller.SetTime(m_bossInfoViewList[index].OCFJGNPMJBA_GetTime());
			controller.SetJoinMember(m_bossInfoViewList[index].MHABJOMJCFI_JoinedMember);
			controller.SetPlayerIcon(m_bossInfoViewList[index]);
			controller.SetPlayerIconDeco(m_bossInfoViewList[index]);
			controller.SetRate(m_bossInfoViewList[index].HIMMCGKKOOL_Rate);
			controller.SetSp(m_bossInfoViewList[index].IKICLMGFFPB_IsSpecial);
			controller.SetEntry(m_bossInfoViewList[index].DLMNFENNCJG_IsEntry);
			controller.SetGauge((int)(m_bossInfoViewList[index].BCCOMAODPJI_HpCurrent * 100.0f / m_bossInfoViewList[index].PIKKHCGNGNN_HpMax));
			controller.SetRank(m_bossInfoViewList[index].FJOLNJLLJEJ_Rank);
			controller.SetHp(m_bossInfoViewList[index].BCCOMAODPJI_HpCurrent);
			controller.SetRemainTimeAct(m_bossInfoViewList[index].OCFJGNPMJBA_GetTime);
		}

		// // RVA: 0x181E7C0 Offset: 0x181E7C0 VA: 0x181E7C0
		private void ScrollStartPanel()
		{
			m_macrossCannonButton.DisableMcrsCannonLine(true);
		}

		// // RVA: 0x181E7F0 Offset: 0x181E7F0 VA: 0x181E7F0
		private void ScrollEndPanel(int index)
		{
			if(m_bossInfoViewList.Count < index)
				return;
			m_bossImageLayout.SetBossImage(m_bossInfoViewList[index].HPPDFBKEJCG_BgId, null);
			m_bossInfoLayout.SetBossName(RaidController.AGEJGHGEGFF_GetBossName(m_bossInfoViewList[index].INDDJNMPONH_Type));
			m_bossInfoLayout.SetSeries(RaidController.NNDFMCHDJOH_GetBossSerie(m_bossInfoViewList[index].INDDJNMPONH_Type));
			m_bossInfoLayout.SetSongBonus(m_bossInfoViewList[index].NFOOOBMJINC_MissionBonusNum);
			m_bossInfoLayout.SetMissionInfoText(m_bossInfoViewList[index].CJLHLKKNMEE_MissionText);
			m_bossInfoLayout.SetSp(m_bossInfoViewList[index].IKICLMGFFPB_IsSpecial);
			m_bossInfoLayout.SetAssistPlay(!RaidController.LIAJFGCJJIM_HasAssist(m_bossInfoViewList[index].PPFNGGCBJKC_Id));
			m_macrossCannonButton.DisableMcrsCannonLine(false);
			SetBossHelpButtonType(index);
		}

		// // RVA: 0x181EC34 Offset: 0x181EC34 VA: 0x181EC34
		private void PushBossInfoUpdateButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_UpdateBossInfoList(false, null));
		}

		// // RVA: 0x181ECB0 Offset: 0x181ECB0 VA: 0x181ECB0
		private void PushSortInfoButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			PopupWindowManager.Show(m_popRaidBossSortSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1825068
				if(type != PopupButton.ButtonType.Positive)
					return;
				(control.Content as PopupRaidBossSortContent).GetComponent<RaidBossSortWindow>().ApplyLocalSaveData(ref GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty);
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				this.StartCoroutineWatched(Co_UpdateBossInfoList(true, null));
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x181EE84 Offset: 0x181EE84 VA: 0x181EE84
		private void PushSortOrderButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.EILKGEADKGH_order == 0)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.EILKGEADKGH_order = 1;
			}
			else
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.EILKGEADKGH_order = 0;
			}
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			m_bossSortLayout.UpdateOrderText();
			SortBossInfoList(ref m_bossInfoViewList);
			m_bossSelectListLayout.InitPanel(m_bossInfoViewList.Count, m_bossInfoViewList.IndexOf(RaidController.PMIIMELDPAJ_GetMyBoss()));
			int idx = Mathf.Max(0, m_bossInfoViewList.IndexOf(RaidController.PMIIMELDPAJ_GetMyBoss()));
			m_bossImageLayout.SetBossImage(m_bossInfoViewList[idx].HPPDFBKEJCG_BgId, null);
			m_bossInfoLayout.SetBossName(RaidController.AGEJGHGEGFF_GetBossName(m_bossInfoViewList[idx].INDDJNMPONH_Type));
			m_bossInfoLayout.SetSeries(RaidController.NNDFMCHDJOH_GetBossSerie(m_bossInfoViewList[idx].INDDJNMPONH_Type));
			m_bossInfoLayout.SetSongBonus(m_bossInfoViewList[idx].NFOOOBMJINC_MissionBonusNum);
			m_bossInfoLayout.SetMissionInfoText(m_bossInfoViewList[idx].CJLHLKKNMEE_MissionText);
			m_bossInfoLayout.SetSp(m_bossInfoViewList[idx].IKICLMGFFPB_IsSpecial);
			m_bossInfoLayout.SetAssistPlay(!RaidController.LIAJFGCJJIM_HasAssist(m_bossInfoViewList[idx].PPFNGGCBJKC_Id));
			SetBossHelpButtonType(idx);
		}

		// // RVA: 0x181F684 Offset: 0x181F684 VA: 0x181F684
		private void OnPushRequestBossHelpButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(!RaidController.LMIFOCDCNAI())
				return;
			MenuScene.Instance.InputDisable();
			this.StartCoroutineWatched(Co_RequestBossHelp());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712944 Offset: 0x712944 VA: 0x712944
		// // RVA: 0x181F7B8 Offset: 0x181F7B8 VA: 0x181F7B8
		private IEnumerator Co_RequestBossHelp()
		{
			//0x182E438
			MessageBank msgBank = MessageManager.Instance.GetBank("menu");
			bool showPop = false;
			bool requestHelp = true;
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(!RaidController.PMIIMELDPAJ_GetMyBoss().DLMNFENNCJG_IsEntry)
			{
				showPop = true;
				requestHelp = false;
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = msgBank.GetMessageByLabel("pop_raid_helprequest_confirmed_title");
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				s.Text = msgBank.GetMessageByLabel("pop_raid_helprequest_confirmed_text");
				PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x18267AC
					showPop = false;
					requestHelp = type == PopupButton.ButtonType.Positive;
				}, null, null, null, true, true, false);
			}
			while(showPop)
				yield return null;
			if(requestHelp)
			{
				RaidBossHelpWindow.SelectType selectType = RaidBossHelpWindow.SelectType.All;
				m_popRaidBossHelpSetting.OnSelectType = (RaidBossHelpWindow.SelectType type) =>
				{
					//0x18267E4
					selectType = type;
				};
				showPop = true;
				requestHelp = false;
				PopupWindowManager.Show(m_popRaidBossHelpSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x18267C4
					showPop = false;
					requestHelp = type == PopupButton.ButtonType.Positive;
				}, null, null, null, true, true, false);
				while(showPop)
					yield return null;
				if(requestHelp)
				{
					bool done = false;
					bool isResetList = false;
					RaidController.MCKDAPPELKJ_RequestBossHelp(selectType == RaidBossHelpWindow.SelectType.Loby || selectType == RaidBossHelpWindow.SelectType.LobyPrioFriend, selectType == RaidBossHelpWindow.SelectType.LobyPrioFriend, (List<PKNOKJNLPOE_EventRaid.ECICDAPCMJG> helper) =>
					{
						//0x18267F4
						done = true;
						m_bottomButtonLayout.SetButtonType(RaidBottomButtonLayout.RaidBottomBtn.RequestHelpDone);
						int helpCount = RaidController.HEMEDMMBIBH_GetBossHelpCountLeft(RaidController.PMIIMELDPAJ_GetMyBoss().PPFNGGCBJKC_Id);
						m_bottomButtonLayout.SetBossHelpCount(helpCount);
						m_bottomButtonLayout.SetBossHelpWatcher(RaidController.GCDHLLHHIHA_GetNextRequestTime(RaidController.PMIIMELDPAJ_GetMyBoss().PPFNGGCBJKC_Id), helpCount != 0, RaidController.KIHAEAEEFJE_IsOverLimitHelp(RaidController.PMIIMELDPAJ_GetMyBoss().PPFNGGCBJKC_Id));
						m_popRaidHelpCompletionListSetting.helperList = helper;
						if(helper.Count < 1)
						{
							TextPopupSetting s = new TextPopupSetting();
							s.TitleText = msgBank.GetMessageByLabel("pop_raid_helprequest_confirmed_title");
							s.Buttons = new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							};
							s.Text = msgBank.GetMessageByLabel("pop_raid_helprequest_failed_text02");
							PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
							{
								//0x1825AF4
								return;
							}, null, null, null, true, true, false);
						}
						else
						{
							PopupWindowManager.Show(m_popRaidHelpCompletionListSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
							{
								//0x1825AF0
								return;
							}, null, null, null, true, true, false);
						}
					}, () =>
					{
						//0x1827080
						done = true;
						MenuScene.Instance.InputEnable();
						MenuScene.Instance.GotoTitle();
					}, () =>
					{
						//0x1827150
						done = true;
						TextPopupSetting s = new TextPopupSetting();
						s.TitleText = msgBank.GetMessageByLabel("pop_raid_helprequest_confirmed_title");
						s.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
						};
						s.Text = msgBank.GetMessageByLabel("pop_raid_helprequest_failed_text01");
						PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0x1825AF8
							return;
						}, null, null, null, true, true, false);
					}, () =>
					{
						//0x18274C0
						TextPopupSetting s = new TextPopupSetting();
						s.TitleText = msgBank.GetMessageByLabel("pop_raid_enemy_escape_title");
						s.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
						};
						s.Text = msgBank.GetMessageByLabel("pop_raid_enemy_escape_enemyselect_text");
						PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0x18277A0
							done = true;
							isResetList = true;
							return;
						}, null, null, null, true, true, false);
					}, () =>
					{
						//0x18277AC
						TextPopupSetting s = new TextPopupSetting();
						s.TitleText = msgBank.GetMessageByLabel("pop_raid_enemy_requested_title");
						s.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
						};
						s.Text = msgBank.GetMessageByLabel("pop_raid_enemy_requested_text");
						PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0x1827A8C
							done = true;
							isResetList = true;
							return;
						}, null, null, null, true, true, false);
					}, () => 
					{
						//0x1827A98
						TextPopupSetting s = new TextPopupSetting();
						s.TitleText = msgBank.GetMessageByLabel("pop_raid_enemy_requested_title");
						s.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
						};
						s.Text = msgBank.GetMessageByLabel("pop_raid_help_defeated_text");
						PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0x1827D78
							done = true;
							isResetList = true;
							return;
						}, null, null, null, true, true, false);
					}, () =>
					{
						//0x1827D84
						TextPopupSetting s = new TextPopupSetting();
						s.TitleText = msgBank.GetMessageByLabel("pop_raid_enemy_requested_title");
						s.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
						};
						s.Text = msgBank.GetMessageByLabel("pop_raid_help_player_count_limit_over_text");
						PopupWindowManager.Show(s, (PopupWindowControl content, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0x1828064
							done = true;
							isResetList = true;
							return;
						}, null, null, null, true, true, false);
					});
					while(!done)
						yield return null;
					if(isResetList)
					{
						this.StartCoroutineWatched(Co_UpdateBossInfoList(false, null));
					}
				}
			}
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x181F864 Offset: 0x181F864 VA: 0x181F864
		private void OnPushEncountItemButton()
		{
			MenuScene.Instance.ShowItemDetail(NKOBMDPHNGP_EventRaidLobby.ADPMLOEOAFD_GetTicketId(), 0, null);
		}

		// // RVA: 0x181F950 Offset: 0x181F950 VA: 0x181F950
		private void OnClickFlowButton(int offset)
		{
			return;
		}

		// // RVA: 0x181F954 Offset: 0x181F954 VA: 0x181F954
		private void PushBossSelectAttackButton(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			RaidController.KMDELKHBDNN(m_bossInfoViewList[index]);
			MenuScene.Instance.InputDisable();
			RaidController.GKCEHODEPMJ(false, () =>
			{
				//0x18252AC
				if(!IsEndRaidEvent())
				{
					if(RaidController.JIBMOEHKMGB.CMCKNKKCNDK_Status == NHCDBBBMFFG.OPNEOJEGDJB_2_Dead)
					{
						PopupWindowManager.Show(m_popRaidDefeatedSetting, (PopupWindowControl control2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
						{
							//0x182565C
							this.StartCoroutineWatched(Co_UpdateBossInfoList(false, null));
						}, null, null, null, true, true, false);
					}
					else if(RaidController.JIBMOEHKMGB.CMCKNKKCNDK_Status != NHCDBBBMFFG.NFDONDKDHPK_3_Escaped)
					{
						isCallActSelect = true;
						TransitionUniqueId t = TransitionUniqueId.HOME_LOBBYMAIN_RAID;
						if(ParentTransition == TransitionList.Type.HOME)
							t = TransitionUniqueId.HOME_RAID;
						else if(ParentTransition == TransitionList.Type.MUSIC_SELECT)
							t = TransitionUniqueId.MUSICSELECT_RAID;
						else if(ParentTransition != TransitionList.Type.LOBBY_MAIN)
							t = TransitionUniqueId.HOME_RAID;
						MenuScene.Instance.Call(TransitionList.Type.RAID_ACT_SELECT, new RaidActSelectArgs(t, m_eventMusicSelectArgs), true);
						return;
					}
					else
					{
						PopupWindowManager.Show(m_popRaidEscapedSetting, (PopupWindowControl control2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
						{
							//0x1825688
							this.StartCoroutineWatched(Co_UpdateBossInfoList(false, null));
						}, null, null, null, true, true, false);
					}
				}
				MenuScene.Instance.InputEnable();
			}, () =>
			{
				//0x1825AFC
				MenuScene.Instance.InputEnable();
				MenuScene.Instance.GotoTitle();
			});
		}

		// // RVA: 0x181FBEC Offset: 0x181FBEC VA: 0x181FBEC
		private void PushProfileButton(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			EAJCBFGKKFA_FriendInfo f = new EAJCBFGKKFA_FriendInfo();
			f.KHEKNNFCAOI(m_bossInfoViewList[index]);
			ProfilDateArgs arg = new ProfilDateArgs();
			arg.data = f;
			arg.infoType = ProfilMenuLayout.InfoType.PLAYER;
			arg.isFavorite = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(f.MLPEHNBNOGD_Id);
			arg.btnType = NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId() == f.MLPEHNBNOGD_Id ? ProfilMenuLayout.ButtonType.None : ProfilMenuLayout.ButtonType.Raid;
			MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
		}

		// // RVA: 0x181FED0 Offset: 0x181FED0 VA: 0x181FED0
		private void OnPushEncounterBossBtn()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(RaidController.KBFCALJDLPH())
			{
				m_popRaidBossEncountSetting.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.UsedItem, Type = PopupButton.ButtonType.Positive }
				};
				m_isOpenEndUseFoldRadar = false;
				PopupWindowManager.Show(m_popRaidBossEncountSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1828070
					if(type == PopupButton.ButtonType.Positive)
					{
						MenuScene.Instance.InputDisable();
						MenuScene.Instance.LobbyButtonControl.Hide(false);
						PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
						ev.KECLCFBKMOA_EncounterBoss(() =>
						{
							//0x1828928
							MenuScene.Instance.InputEnable();
							transform.SetAsLastSibling();
							MenuScene.Instance.LobbyButtonControl.SetAsLastSibling();
							m_bossNoneLayout.Leave();
							m_isRaidBossEncount = 0;
							m_raidBossPop.StartAnim(ev.PMIIMELDPAJ_GetMyBoss(), () =>
							{
								//0x18283D0
								MenuScene.Instance.LobbyButtonControl.Show(false);
								transform.SetAsFirstSibling();
								this.StartCoroutineWatched(Co_UpdateBossInfoList(false, (bool success) =>
								{
									//0x1828580
									if(success)
									{
										m_isRaidBossEncount = 1;
									}
								}));
							});
							CrateQuestList();
							m_buttonsLayout.SetMissionBadge(IsReceiveMission());
						}, () =>
						{
							//0x1825BC0
							MenuScene.Instance.LobbyButtonControl.Show(false);
							MenuScene.Instance.InputEnable();
							MenuScene.Instance.GotoTitle();
						}, () =>
						{
							//0x18285B4
							TextPopupSetting s = new TextPopupSetting();
							s.TitleText = bk.GetMessageByLabel("pop_raid_radar_failed_title");
							s.Buttons = new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							};
							s.Text = bk.GetMessageByLabel("pop_raid_rader_failed_text");
							PopupWindowManager.Show(s, (PopupWindowControl control2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
							{
								//0x1828844
								m_isRaidBossEncount = -1;
								MenuScene.Instance.InputEnable();
							}, null, null, null, true, true, false);
						});
					}
				}, null, null, () =>
				{
					//0x1828900
					m_isOpenEndUseFoldRadar = true;
				}, true, true, false);
			}
			else
			{
				m_popRaidBossEncountSetting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				m_isOpenEndUseFoldRadar = false;
				PopupWindowManager.Show(m_popRaidBossEncountSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1825CD0
					return;
				}, null, null, null, true, true, false);
			}
		}

		// // RVA: 0x1820484 Offset: 0x1820484 VA: 0x1820484
		private void OnClickEventRankingButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(m_eventStatus < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
			{
				MenuScene.Instance.Call(TransitionList.Type.EVENT_RANKING, new EventRankingSceneArgs(m_eventCtrl, false, 0, 0), true);
			}
		}

		// // RVA: 0x1820648 Offset: 0x1820648 VA: 0x1820648
		private void OnClickEventRewardButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			this.StartCoroutineWatched(PopupRewardEvCheck.Co_ShowPopupRaidEvent(m_eventCtrl, true, transform, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1825CD4
				return;
			}));
		}

		// // RVA: 0x18208AC Offset: 0x18208AC VA: 0x18208AC
		private void OnClickMissionButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			CGJKNOCAPII data = new CGJKNOCAPII();
			QuestTopFormQuestListArgs arg = new QuestTopFormQuestListArgs(data.BJKJLDPDEFA(RaidController, true));
			MenuScene.Instance.Call(TransitionList.Type.QUEST_SELECT, arg, true);
		}

		// // RVA: 0x1820A28 Offset: 0x1820A28 VA: 0x1820A28
		private void UpdateMacrossGauge()
		{
			CheckMacrossCannnon();
		}

		// // RVA: 0x1820BA8 Offset: 0x1820BA8 VA: 0x1820BA8
		private void OnClickEventBanner()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(!MenuScene.CheckDatelineAndAssetUpdate())
			{
				AODFBGCCBPE data = AODFBGCCBPE.FKDIMODKKJD(false).Find((AODFBGCCBPE _) =>
				{
					//0x1825CD8
					return _.INDDJNMPONH_Type == AODFBGCCBPE.NJMPLEENNPO.FNJAOJBICJD_6_SuperGalaxyMedal;
				});
				if(data != null)
				{
					data.NBJNKFPEFGC();
					ShopProductScene.ShopProductArgs arg = new ShopProductScene.ShopProductArgs();
					arg.view = data;
					MenuScene.Instance.Call(TransitionList.Type.SHOP_PRODUCT, arg, false);
				}
			}
		}

		// // RVA: 0x1820A2C Offset: 0x1820A2C VA: 0x1820A2C
		private void CheckMacrossCannnon()
		{
			int a, b;
			bool c;
			RaidController.HAPDLPAKMLF(out a, out b, out c);
			if(a != 0)
			{
				if(m_bossInfoList.Count != 0)
				{
					m_macrossCannonButton.MCannonEnter();
					m_bossSelectListLayout.SetPanelEffect(true);
					this.StartCoroutineWatched(TryShowTutorial_77());
					return;
				}
			}
			m_macrossCannonButton.MCannonLeave();
			m_bossSelectListLayout.SetPanelEffect(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7129BC Offset: 0x7129BC VA: 0x7129BC
		// // RVA: 0x1820E54 Offset: 0x1820E54 VA: 0x1820E54
		protected IEnumerator TryShowTutorial_77()
		{
			//0xCEDC04
			while(!m_isEndActivateScene)
				yield return null;
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine((TutorialConditionId conditionId) =>
			{
				//0x1825D08
				return conditionId == TutorialConditionId.Condition77;
			}));
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.RaycastEnable();
		}

		// RVA: 0x1820EDC Offset: 0x1820EDC VA: 0x1820EDC Slot: 16
		protected override void OnPreSetCanvas()
		{
			GameManager.Instance.SelectedGuestData = null;
			m_bossSelectListLayout.InitializeDecoration();
			base.OnPreSetCanvas();
			NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			if(evLobby != null && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer != null)
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId = NKOBMDPHNGP_EventRaidLobby.FAKHCOJIOBD(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId, 1);
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId = evLobby.DKNNNOIMMFN_GetClusterId();
			}
			this.StartCoroutineWatched(Co_OnPresetCanvas());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712A34 Offset: 0x712A34 VA: 0x712A34
		// // RVA: 0x1821284 Offset: 0x1821284 VA: 0x1821284
		private IEnumerator Co_OnPresetCanvas()
		{
			//0x182DAD0
			m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			m_eventMusicSelectArgs = Args as EventMusicSelectSceneArgs;
			if(m_eventMusicSelectArgs == null)
				m_eventMusicSelectArgs = ArgsReturn as EventMusicSelectSceneArgs;
			if(m_eventMusicSelectArgs == null)
				m_eventMusicSelectArgs = new EventMusicSelectSceneArgs(m_eventCtrl.PGIIDPEGGPI_EventId, false, false);
			m_isEventTimeLimit = false;
			m_isEventChecked = false;
			m_eventStatus = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0;
			if(m_eventCtrl != null)
			{
				m_eventCtrl.HCDGELDHFHB_UpdateStatus(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
				m_eventStatus = m_eventCtrl.NGOFCFJHOMI_Status;
			}
			if(!MenuScene.Instance.CheckEventLimit(m_eventCtrl, false, true))
			{
				yield return Co.R(Co_Initialize_LoginBonusPopup(m_eventCtrl));
				yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.LobbyMain, 3, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
				m_topGauge.Hide();
				m_bossSelectListLayout.Hide();
				m_bossImageLayout.Hide();
				m_macrossCannonButton.Hide();
				m_bottomButtonLayout.Hide();
				m_bossInfoLayout.Hide();
				m_buttonsLayout.Hide();
				m_bossSortLayout.Hide();
				m_endEventLayout.Hide();
				m_announceLayout.Hide();
				m_mccEffectLayout.Hide();
				m_raidBossPop.Hide();
				while(IsPlayingLayout())
					yield return null;
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

		// RVA: 0x1821330 Offset: 0x1821330 VA: 0x1821330 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(m_isEventTimeLimit)
				return;
			m_eventBanner.Enter();
			base.OnStartEnterAnimation();
		}

		// RVA: 0x1821378 Offset: 0x1821378 VA: 0x1821378 Slot: 12
		protected override void OnStartExitAnimation()
		{
			if(m_isEventTimeLimit)
				return;
			m_topGauge.Leave();
			m_bossSelectListLayout.Leave();
			m_bossImageLayout.Leave();
			m_macrossCannonButton.Leave();
			m_bottomButtonLayout.Leave();
			m_bossInfoLayout.Leave();
			m_buttonsLayout.Leave();
			m_bossSortLayout.Leave();
			m_bossNoneLayout.Leave();
			m_announceLayout.Leave();
			m_eventBanner.Leave();
			m_endEventLayout.Leave();
			MenuScene.Instance.LobbyButtonControl.Hide(false);
		}

		// RVA: 0x18215C8 Offset: 0x18215C8 VA: 0x18215C8 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !IsPlayingLayout();
		}

		// RVA: 0x1821C84 Offset: 0x1821C84 VA: 0x1821C84 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnActivateScene());
		}

		// RVA: 0x1821DB8 Offset: 0x1821DB8 VA: 0x1821DB8 Slot: 24
		protected override bool IsEndActivateScene()
		{
			return m_isEndActivateScene;
		}

		// RVA: 0x1821DC0 Offset: 0x1821DC0 VA: 0x1821DC0 Slot: 15
		protected override void OnDeleteCache()
		{
			base.OnDeleteCache();
		}

		// RVA: 0x1821DC8 Offset: 0x1821DC8 VA: 0x1821DC8 Slot: 18
		protected override void OnPostSetCanvas()
		{
			transform.SetAsFirstSibling();
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0x1821E9C Offset: 0x1821E9C VA: 0x1821E9C Slot: 20
		protected override bool OnBgmStart()
		{
			if(RaidController != null)
			{
				ChangeTrialMusic(RaidController.EDNMFMBLCGF_GetWavId());
			}
			return true;
		}

		// RVA: 0x18220C0 Offset: 0x18220C0 VA: 0x18220C0 Slot: 14
		protected override void OnDestoryScene()
		{
			if(isCallActSelect)
			{
				MenuScene.Instance.InputEnable();
			}
			Release();
		}

		// RVA: 0x18215DC Offset: 0x18215DC VA: 0x18215DC
		private bool IsPlayingLayout()
		{
			if(m_topGauge.gameObject.activeSelf && m_topGauge.IsPlaying())
				return true;
			if(m_bossSelectListLayout.gameObject.activeSelf && m_bossSelectListLayout.IsPlaying())
				return true;
			if(m_bossImageLayout.gameObject.activeSelf && m_bossImageLayout.IsPlaying())
				return true;
			if(m_macrossCannonButton.gameObject.activeSelf && m_macrossCannonButton.IsPlaying())
				return true;
			if(m_bottomButtonLayout.gameObject.activeSelf && m_bottomButtonLayout.IsPlaying())
				return true;
			if(m_bossInfoLayout.gameObject.activeSelf && m_bossInfoLayout.IsPlaying())
				return true;
			if(m_buttonsLayout.gameObject.activeSelf && m_buttonsLayout.IsPlaying())
				return true;
			if(m_bossSortLayout.gameObject.activeSelf && m_bossSortLayout.IsPlaying())
				return true;
			if(m_bossNoneLayout.gameObject.activeSelf && m_bossNoneLayout.IsPlaying())
				return true;
			if(m_endEventLayout.gameObject.activeSelf && m_endEventLayout.IsPlaying())
				return true;
			if(m_announceLayout.gameObject.activeSelf && m_announceLayout.IsPlaying())
				return true;
			if(m_mccEffectLayout.gameObject.activeSelf && m_mccEffectLayout.IsPlaying())
				return true;
			if(m_eventBanner.gameObject.activeSelf && m_eventBanner.IsPlaying())
				return true;
			if(m_raidBossPop.gameObject.activeSelf && m_raidBossPop.IsPlaying())
				return true;
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712AAC Offset: 0x712AAC VA: 0x712AAC
		// // RVA: 0x1821D2C Offset: 0x1821D2C VA: 0x1821D2C
		private IEnumerator Co_OnActivateScene()
		{
			//0x182C8E0
			m_isEndActivateScene = false;
			if(m_isEventTimeLimit)
			{
				m_isEndActivateScene = true;
				yield break;
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				MenuScene.Instance.InputDisable();
				yield return Co.R(MenuScene.Instance.LobbyButtonControl.Co_CheckNewMark(null));
				MenuScene.Instance.InputEnable();
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(m_isShowFirstHelp)
				{
					yield return Co.R(Co_ShowHelp());
				}
			}
			//LAB_0182caac
			if(!MenuScene.Instance.DirtyChangeScene && TutorialProc.IsUnlockTutorialInRank())
			{
				this.StartCoroutineWatched(TutorialProc.Co_GuideToHomePopup());
				MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				m_isEndActivateScene = true;
				yield break;
			}
			else
			{
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					MenuScene.Instance.InputDisable();
					yield return Co.R(Co_CheckUnlock(null));
					MenuScene.Instance.InputEnable();
				}
				//LAB_0182ccd0
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					AddNotice(() =>
					{
						//0x1825F3C
						CheckSnsNotice();
					});
				}
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					AddNotice(() =>
					{
						//0x1825F64
						CheckOfferNotice();
					});
				}
				MenuScene.Instance.InputDisable();
				//LAB_0182ce7c
				while(IsPlayingLayout())
					yield return null;
				if(m_eventStatus < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
				{
					yield return this.StartCoroutineWatched(Co_UpdateBossInfoList(false, null));
				}
				else
				{
					m_endEventLayout.Enter();
					m_bossInfoLayout.Hide();
					m_bossSelectListLayout.Leave();
					m_bossImageLayout.Leave();
					m_macrossCannonButton.Leave();
				}
				//LAB_0182d084
				m_topGauge.gameObject.SetActive(false);
				m_bottomButtonLayout.gameObject.SetActive(true);
				m_bossSortLayout.gameObject.SetActive(true);
				m_topGauge.Enter();
				m_bottomButtonLayout.Enter();
				m_bossSortLayout.Enter();
				m_announceLayout.Enter();
				m_buttonsLayout.Enter();
				MenuScene.Instance.LobbyButtonControl.Setup(HomeLobbyButtonController.Type.UP);
				ChangeTrialMusic(m_eventCtrl.EDNMFMBLCGF_GetWavId());
				//LAB_0182d298
				while(IsPlayingLayout())
					yield return null;
				MenuScene.Instance.InputEnable();
				this.StartCoroutineWatched(Co_ShowNotice());
				MenuScene.Instance.InputDisable();
				bool isWait = true;
				bool isErr = false;
				MenuScene.Save(() =>
				{
					//0x1825F8C
					isWait = false;
					isErr = false;
				}, () =>
				{
					//0x1825F98
					isWait = false;
					isErr = true;
				});
				while(isWait)
					yield return null;
				if(isErr)
				{
					MenuScene.Instance.GotoTitle();
					yield break;
				}
				MenuScene.Instance.InputEnable();
				if(m_eventCtrl == null || m_eventCtrl.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
				{
					//LAB_0182cfb8
				}
				else
				{
					if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsRaidUseFoldRadar))
					{
						if(!RaidController.PMIIMELDPAJ_GetMyBoss().DNJGAJPIIPI)
						{
							List<ActionButton> btns = new List<ActionButton>(m_bottomButtonLayout.GetComponentsInChildren<ActionButton>(true));
							ActionButton b = btns.Find((ActionButton _) =>
							{
								//0x1825D18
								return _.name.Contains("sw_raid_btn_b_05_anim");
							});
							yield return Co.R(TutorialProc.Co_RaidUseFoldRadar(b, () =>
							{
								//0x1825FA4
								return m_isOpenEndUseFoldRadar;
							}, Co_TutorialItemGetPopup(), () =>
							{
								//0x1825FC8
								return m_isRaidBossEncount;
							}));
						}
					}
					//LAB_0182cf28
					if(!MenuScene.Instance.DirtyChangeScene)
					{
						yield return Co.R(Co_ShowReciveLoginReward());
					}
					//LAB_0182cfa8
				}
				//LAB_0182cfb8
				m_isEndActivateScene = true;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712B24 Offset: 0x712B24 VA: 0x712B24
		// // RVA: 0x1822194 Offset: 0x1822194 VA: 0x1822194
		private IEnumerator Co_TutorialItemGetPopup()
		{
			//0xCEB234
			int addCount = 1;
			int itemId = RaidItemConstants.MakeItemId(RaidItemConstants.Type.FoldRadar);
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId);
            int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
			m_ticketGainedPopupSetting.title = string.Concat(new object[4]
			{
				EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId),
				JpStringLiterals.StringLiteral_367,
				addCount,
				EKLNMHFCAOI.NDBLEADIDLA(cat, id, addCount)
			});
			m_ticketGainedPopupSetting.label01 = EKLNMHFCAOI.ILKGBGOCLAO_GetItemDesc(cat, id);
			m_ticketGainedPopupSetting.layoutType = 2;
			m_ticketGainedPopupSetting.TitleText = "";
			m_ticketGainedPopupSetting.IsCaption = false;
			m_ticketGainedPopupSetting.WindowSize = SizeType.Small;
			m_ticketGainedPopupSetting.itemId = itemId;
			m_ticketGainedPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			bool isWait = true;
			PopupWindowManager.Show(m_ticketGainedPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1825FF4
				NKOBMDPHNGP_EventRaidLobby ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
				NKBOMKGFGIO_EventRaidItem.PDPBHLDICEJ d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ONOJBMDKBLE_EventRaidItem.CDENCMNHNGA[0];
				int num = Mathf.Clamp(addCount + RaidController.NPICFLFAIJK_GetNumTicket(), 0, d.DOOGFEGEKLG_Max);
				ev.NCBELAFIPDN_SetItemCount(RaidItemConstants.Type.FoldRadar, num, null);
				m_bottomButtonLayout.SetItemNum(RaidController.NPICFLFAIJK_GetNumTicket());
				ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(RaidItemConstants.MakeItemId(RaidItemConstants.Type.FoldRadar), OAGBCBBHMPF.COIIJOEKBDH.PJPBCFKEGBC_38, ev.PGIIDPEGGPI_EventId.ToString(), addCount, num, 1);
			}, null, null, null, true, true, false, null, () =>
			{
				//0x18263A4
				isWait = false;
			});
			while(isWait)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712B9C Offset: 0x712B9C VA: 0x712B9C
		// // RVA: 0x182221C Offset: 0x182221C VA: 0x182221C
		private IEnumerator Co_Initialize_LoginBonusPopup(IKDICBBFBMI_EventBase a_controller)
		{
			int itemId; // 0x1C
			int itemCount; // 0x20

			//0x182A818
			if(m_ticketGainedPopupSetting == null || a_controller == null)
				yield break;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_showTicketGainedPopup = false;
			itemId = 0;
			itemCount = 0;
			if(a_controller.GJMGKBDGMOP(t))
			{
				m_showTicketGainedPopup = true;
				itemId = a_controller.BHABCGJCGNO.JJBGOIMEIPF_ItemId;
				itemCount = a_controller.BHABCGJCGNO.MBJIFDBEDAC_Cnt;
				bool done = false;
				CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
				{
					//0x18263B8
					done = true;
				}, () =>
				{
					//0x18263C4
					done = true;
					GotoTitle();
				}, null);
				while(!done)
					yield return null;
			}
			if(m_showTicketGainedPopup)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
				{
					m_ticketGainedPopupSetting.title = string.Format(bk.GetMessageByLabel("popup_event_login_item01_title_msg"), itemCount);
					m_ticketGainedPopupSetting.label01 = bk.GetMessageByLabel("popup_event_login_item01_label00_msg");
					m_ticketGainedPopupSetting.label02 = bk.GetMessageByLabel("popup_event_login_item01_label01_msg");
					m_ticketGainedPopupSetting.layoutType = 0;
				}
				else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
				{
					m_ticketGainedPopupSetting.title = string.Format(bk.GetMessageByLabel("popup_event_login_item00_title_msg"), itemCount);
					m_ticketGainedPopupSetting.label01 = bk.GetMessageByLabel("popup_event_login_item00_label00_msg");
					m_ticketGainedPopupSetting.label02 = bk.GetMessageByLabel("popup_event_login_item00_label01_msg");
					m_ticketGainedPopupSetting.layoutType = 1;
				}
				else
				{
					m_showTicketGainedPopup = false;
				}
				if(m_showTicketGainedPopup)
				{
					m_ticketGainedPopupSetting.TitleText = "";
					m_ticketGainedPopupSetting.IsCaption = false;
					m_ticketGainedPopupSetting.WindowSize = SizeType.Small;
					m_ticketGainedPopupSetting.itemId = itemId;
					m_ticketGainedPopupSetting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
				}
			}
			if(a_controller.JBPPMMMFGCA_HasRewardItems())
				m_showitemReceivePopup = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712C14 Offset: 0x712C14 VA: 0x712C14
		// // RVA: 0x18222E4 Offset: 0x18222E4 VA: 0x18222E4
		private IEnumerator Co_ShowReciveLoginReward()
		{
			int itemId; // 0x1C
			int itemNum; // 0x20

			//0x182F814
			if(RaidController.LDMOBKMEKMD())
			{
				//LAB_0182fcfc
				yield break;
			}
			MenuScene.Instance.InputDisable();
			if(!RaidController.PPPEFGFIGMH_GetStartBonusItemIdAndCount(out itemId, out itemNum))
			{
				yield break;
			}
			bool done = false;
			bool success = false;
			RaidController.PMAMHBOGPNJ(() =>
			{
				//0x1826400
				done = true;
				success = true;
			}, () =>
			{
				//0x182640C
				done = true;
			});
			while(!done)
				yield return null;
			if(success)
			{
				bool isWait = true;
				m_itemReceivePopupSetting.ItemId = itemId;
				m_itemReceivePopupSetting.Count = itemNum;
				PopupWindowManager.Show(m_itemReceivePopupSetting, (PopupWindowControl type, PopupButton.ButtonType label, PopupButton.ButtonLabel control) =>
				{
					//0x1826420
					isWait = false;
				}, null, null, null, true, true, false);
				while(isWait)
					yield return null;
				m_bottomButtonLayout.SetItemNum(RaidController.NPICFLFAIJK_GetNumTicket());
			}
			//LAB_0182fd7c
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712C8C Offset: 0x712C8C VA: 0x712C8C
		// // RVA: 0x1822390 Offset: 0x1822390 VA: 0x1822390
		protected IEnumerator Co_LoadAssetBundle_LoginBonusPopup()
		{
			FontInfo systemFont; // 0x14
			AssetBundleLoadLayoutOperationBase lytOp; // 0x18

			//0x182B134
			m_loadingTicketGainedPopup = true;
			m_ticketGainedPopupSetting = new TicketGainedPopupSetting();
			systemFont = GameManager.Instance.GetSystemFont();
			lytOp = AssetBundleManager.LoadLayoutAsync(m_ticketGainedPopupSetting.BundleName, m_ticketGainedPopupSetting.AssetName);
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x18256BC
				m_ticketGainedPopupSetting.SetContent(instance);
			}));
			m_ticketGainedPopupSetting.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_ticketGainedPopupSetting.BundleName);
			m_loadingTicketGainedPopup = false;
		}

		// // RVA: 0x182243C Offset: 0x182243C VA: 0x182243C
		protected void SetupHelp()
		{
			m_eventHelpId.Clear();
			if(!m_eventCtrl.BELBNINIOIE)
			{
				if(!m_eventCtrl.CMPEJEHCOEI)
				{
					int id = m_eventCtrl.HLOGNJNGDJO_GetHelpId(m_eventCtrl.NJHPPOFBCMA() ? 1 : 0);
					if(id > 0)
						m_eventHelpId.Add(id);
				}
			}
			else
			{
				if(m_eventCtrl.CMPEJEHCOEI)
				{
					int id = m_eventCtrl.HLOGNJNGDJO_GetHelpId(m_eventCtrl.NJHPPOFBCMA() ? 1 : 0);
					if(id > 0)
						m_eventHelpId.Add(id);
				}
				if(m_eventCtrl.LPFJADHHLHG)
				{
					int id = m_eventCtrl.HLOGNJNGDJO_GetHelpId(2);
					if(id > 0)
						m_eventHelpId.Add(id);
				}
			}
			if(m_eventCtrl.GHAFMPBPJME())
			{
				if(m_eventCtrl.OGPMLMDPGJA > 0)
				{
					m_eventHelpId.Add(m_eventCtrl.OGPMLMDPGJA);
				}
			}
			m_isShowFirstHelp = true;
			if(!m_eventCtrl.CMPEJEHCOEI)
			{
				if(!m_eventCtrl.LPFJADHHLHG)
				{
					m_isShowFirstHelp = m_eventCtrl.GHAFMPBPJME();
				}
			}
			m_eventCtrl.CMPEJEHCOEI = false;
			m_eventCtrl.LPFJADHHLHG = false;
			m_eventCtrl.MMIMJPNLKBK();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712D04 Offset: 0x712D04 VA: 0x712D04
		// // RVA: 0x1822800 Offset: 0x1822800 VA: 0x1822800
		private IEnumerator Co_ShowHelp()
		{
			int i;

			//0x182F0B0
			for(i = 0; i < m_eventHelpId.Count; i++)
			{
				if(m_eventHelpId[i] != 0)
				{
					MenuScene.Instance.InputDisable();
					yield return this.StartCoroutineWatched(TutorialManager.ShowTutorial(m_eventHelpId[i], () =>
					{
						//0x1825DB0
						MenuScene.Instance.InputEnable();
					}));
				}
			}
		}

		// // RVA: 0x18228AC Offset: 0x18228AC VA: 0x18228AC
		private void CheckSnsNotice()
		{
			if(!BIFNGFAIEIL.HHCJCDFCLOB.DNFPMBFNDCA())
				return;
			int snsId = BIFNGFAIEIL.HHCJCDFCLOB.FGGDEKAJCIF();
			if(snsId == 0)
				return;
			MenuScene.Instance.ShowSnsNotice(snsId, null);
			BIFNGFAIEIL.HHCJCDFCLOB.ALIANOFCAEI();
		}

		// // RVA: 0x18229F4 Offset: 0x18229F4 VA: 0x18229F4
		private void CheckOfferNotice()
		{
			if(KDHGBOOECKC.HHCJCDFCLOB.IOCBOGFFHFE.OAFPGJLCNFM_Cond == 0)
				return;
			MenuScene.Instance.ShowOfferNotice(null);
		}

		// // RVA: 0x1822ADC Offset: 0x1822ADC VA: 0x1822ADC
		private void AddNotice(Action action)
		{
			NoticeActionList.Add(action);
		}

		// // RVA: 0x1822B5C Offset: 0x1822B5C VA: 0x1822B5C
		// private void ShowNotice() { }

		// [IteratorStateMachineAttribute] // RVA: 0x712D7C Offset: 0x712D7C VA: 0x712D7C
		// // RVA: 0x1822B80 Offset: 0x1822B80 VA: 0x1822B80
		private IEnumerator Co_ShowNotice()
		{
			int i;

			//0x182F47C
			for(i = 0; i < NoticeActionList.Count; i++)
			{
				NoticeActionList[i]();
				GameManager.Instance.snsNotification.DirtyClose = false;
				while(GameManager.Instance.snsNotification.isActiveAndEnabled)
					yield return null;
				if(GameManager.Instance.snsNotification.DirtyClose)
					yield break;
			}
			NoticeActionList.Clear();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712DF4 Offset: 0x712DF4 VA: 0x712DF4
		// // RVA: 0x1822C2C Offset: 0x1822C2C VA: 0x1822C2C
		protected IEnumerator Co_CheckUnlock(Action<int> callback)
		{
			//0x1828C74
			yield return Co.R(PopupUnlock.Show(PopupUnlock.eSceneType.MusicSelect, callback, true, null));
		}

		// // RVA: 0x1821EF4 Offset: 0x1821EF4 VA: 0x1821EF4
		private void ChangeTrialMusic(int wavId)
		{
			int bgmId = BgmPlayer.MENU_TRIAL_ID_BASE + wavId;
			if(SoundManager.Instance.bgmPlayer.isPlaying)
			{
				if(bgmId == SoundManager.Instance.bgmPlayer.currentBgmId)
				{
					return;
				}
				SoundManager.Instance.bgmPlayer.FadeOut(0.3f, () =>
				{
					//0x182642C
					SoundManager.Instance.bgmPlayer.Play(bgmId, 1);
				});
			}
			else
			{
				SoundManager.Instance.bgmPlayer.Play(bgmId, 1);
			}
		}

		// // RVA: 0x1822CE0 Offset: 0x1822CE0 VA: 0x1822CE0
		private void CrateQuestList()
		{
			if(RaidController == null)
			{
				m_questList = new List<FKMOKDCJFEN>();
			}
			else
			{
				m_questList = FKMOKDCJFEN.KJHKBBBDBAL(RaidController.JOPOPMLFINI_QuestId, false, -1);
			}
		}

		// // RVA: 0x1822DA8 Offset: 0x1822DA8 VA: 0x1822DA8
		private bool IsReceiveMission()
		{
			if(m_questList != null)
			{
				return m_questList.FindIndex((FKMOKDCJFEN x) =>
				{
					//0x1825E4C
					return x.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved;
				}) > -1;
			}
			return false;
		}

		// // RVA: 0x181D8BC Offset: 0x181D8BC VA: 0x181D8BC
		private bool IsEndRaidEvent()
		{
			RaidController.HCDGELDHFHB_UpdateStatus(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			if(RaidController.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.DNABPEOICIJ(() =>
				{
					//0x1825E7C
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}, false);
				return true;
			}
			return false;
		}

		// // RVA: 0x181DC6C Offset: 0x181DC6C VA: 0x181DC6C
		private TransitionUniqueId GetTransitionUniqueId()
		{
			TransitionUniqueId t = TransitionUniqueId.HOME_LOBBYMAIN_RAID;
			if(ParentTransition == TransitionList.Type.HOME)
				t = TransitionUniqueId.HOME_RAID;
			else if(ParentTransition == TransitionList.Type.MUSIC_SELECT)
				t = TransitionUniqueId.MUSICSELECT_RAID;
			else if(ParentTransition != TransitionList.Type.LOBBY_MAIN)
				t = TransitionUniqueId.HOME_RAID;
			return t;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x712E6C Offset: 0x712E6C VA: 0x712E6C
		// // RVA: 0x1822F10 Offset: 0x1822F10 VA: 0x1822F10
		private IEnumerator Co_TapGuardForSceneChange()
		{
			//0xCEAFE0
			MenuScene.Instance.InputDisable();
			while(MenuScene.Instance.DirtyChangeScene)
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x1822F80 Offset: 0x1822F80 VA: 0x1822F80
		private void InitPopupSettings()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_popRaidBossEncountSetting.SetParent(transform);
			m_popRaidBossEncountSetting.WindowSize = SizeType.Small;
			m_popRaidBossEncountSetting.TitleText = bk.GetMessageByLabel("pop_raid_bosspop_title");
			m_popRaidBossHelpSetting.SetParent(transform);
			m_popRaidBossHelpSetting.WindowSize = SizeType.Middle;
			m_popRaidBossHelpSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_popRaidBossHelpSetting.TitleText = bk.GetMessageByLabel("pop_raid_helprequest_title");
			m_popRaidBossSortSetting.SetParent(transform);
			m_popRaidBossSortSetting.WindowSize = SizeType.Large;
			m_popRaidBossSortSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_popRaidBossSortSetting.TitleText = bk.GetMessageByLabel("pop_raid_boss_sort_title");
			m_popRaidPlateSetting.SetParent(transform);
			m_popRaidPlateSetting.WindowSize = SizeType.Large;
			m_popRaidPlateSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_popRaidPlateSetting.TitleText = bk.GetMessageByLabel("pop_raid_cannon_plate_title");
			m_popRaidDefeatedSetting.SetParent(transform);
			m_popRaidDefeatedSetting.WindowSize = SizeType.Small;
			m_popRaidDefeatedSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_popRaidDefeatedSetting.TitleText = bk.GetMessageByLabel("pop_raid_defeated_title");
			m_popRaidDefeatedSetting.Text = bk.GetMessageByLabel("pop_raid_defeated_text");
			m_popRaidEscapedSetting.SetParent(transform);
			m_popRaidEscapedSetting.WindowSize = SizeType.Small;
			m_popRaidEscapedSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_popRaidEscapedSetting.TitleText = bk.GetMessageByLabel("pop_raid_escaped01_title");
			m_popRaidEscapedSetting.Text = bk.GetMessageByLabel("pop_raid_escaped01_text");
			m_popRaidHelpCompletionListSetting.SetParent(transform);
			m_popRaidHelpCompletionListSetting.WindowSize = SizeType.Middle;
			m_popRaidHelpCompletionListSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_popRaidHelpCompletionListSetting.TitleText = bk.GetMessageByLabel("pop_raid_helprequest_completion_title");
			m_itemReceivePopupSetting.TitleText = bk.GetMessageByLabel("popup_raid_login_reward_title");
			m_itemReceivePopupSetting.IsPresentBox = false;
			m_itemReceivePopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
		}

		// [DebuggerHiddenAttribute] // RVA: 0x713064 Offset: 0x713064 VA: 0x713064
		// [CompilerGeneratedAttribute] // RVA: 0x713064 Offset: 0x713064 VA: 0x713064
		// // RVA: 0x18256B4 Offset: 0x18256B4 VA: 0x18256B4
		// private void <>n__0() { }
	}
}
