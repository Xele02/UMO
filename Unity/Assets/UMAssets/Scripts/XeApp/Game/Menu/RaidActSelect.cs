using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.uGUI;

namespace XeApp.Game.Menu
{
	public class RaidActSelect : TransitionRoot
	{
		private MusicDataList m_eventMusicData; // 0x48
		private IBJAKJJICBC m_selectMusicData; // 0x4C
		private int m_currentSelectIndex; // 0x50
		private int m_currentSelectIndex6; // 0x54
		private RaidTopGauge m_topGauge; // 0x58
		private RaidActSelectBossInfoLayout m_bossInfoLayout; // 0x5C
		private RaidActSelectRootPanel m_rootPanel; // 0x60
		private RaidActSelectMusicInfo m_musicInfo; // 0x64
		private RaidActSelectButtonSet m_buttonSet; // 0x68
		private RaidActSelectLaneButton m_laneButton; // 0x6C
		private PopupUnitDanceWarning m_popupUnitDanceWarning = new PopupUnitDanceWarning(); // 0x70
		private TextPopupSetting m_popRaidDefeatedSetting = new TextPopupSetting(); // 0x74
		private TextPopupSetting m_popRaidEscapedSetting = new TextPopupSetting(); // 0x78
		private MMOLNAHHDOM m_unitLiveLocalSaveData; // 0x7C
		private bool m_isLine6Mode; // 0x80
		public Difficulty.Type diff; // 0x84
		private bool m_isInitialized; // 0x88
		private bool m_isConfirmedUnitDance; // 0x89
		private bool isCallFriendSelect; // 0x8A
		private List<FKMOKDCJFEN> m_questList; // 0x8C
		private TransitionUniqueId m_returnUniqueId; // 0x90
		private const float s_bgmFadeOutSec = 0.3f;
		private bool m_requestFadeOutBgm; // 0x94
		private int m_changeToTrialBgmId = -1; // 0x98
		private PKNOKJNLPOE_EventRaid raidController; // 0x9C

		// RVA: 0x9EBC28 Offset: 0x9EBC28 VA: 0x9EBC28
		private void Start()
		{
			m_isInitialized = false;
			this.StartCoroutineWatched(Co_LoadLayout());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71132C Offset: 0x71132C VA: 0x71132C
		// // RVA: 0x9EBCE0 Offset: 0x9EBCE0 VA: 0x9EBCE0
		private IEnumerator Co_Initialize()
		{
			//0x1448334
			raidController = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			m_buttonSet.onClickMvpButton = OnClickMvpButton;
			m_buttonSet.onClickEventRewardButton = OnClickEventRewardButton;
			m_buttonSet.onClickMissionButton = OnClickMissionButton;
			m_buttonSet.onClickDetailButton = OnClickDetailButton;
			m_buttonSet.onClickEnemyInfoButton = OnClickEnemyInfoButton;
			m_musicInfo.onChangedDifficulty = OnChangedDifficulty;
			m_musicInfo.onChangedMusic = OnClickMusicSelectArrow;
			m_rootPanel.Left.OnClickPanelListner += OnClickLeftPanel;
			m_rootPanel.Left.OnClickPlayButtonListner += OnClickPlayButton;
			m_rootPanel.Right.OnClickPanelListner += OnClickRightPanel;
			m_rootPanel.Right.OnClickPlayButtonListner += OnClickPlayButton;
			m_laneButton.onClickButton = OnChangeLineMode;
			yield return this.StartCoroutineWatched(Co_MusicRelatedInit());
			if(m_isLine6Mode)
			{
				if(m_eventMusicData.GetCount(true, false) == 0)
					m_isLine6Mode = false;
			}
			if(TransitionType != MenuTransitionControl.TransitionType.Return)
			{
				m_currentSelectIndex6 = UnityEngine.Random.Range(0, m_eventMusicData.GetCount(true, false));
				m_currentSelectIndex = UnityEngine.Random.Range(0, m_eventMusicData.GetCount(false, false));
				m_rootPanel.SetFreePlay(raidController.ACDLEBPMEIH(raidController.JIBMOEHKMGB_SelectedBoss));
				bool assisted = raidController.LIAJFGCJJIM_HasAssist();
				m_rootPanel.SetAssisted(assisted);
				if(assisted)
				{
					m_rootPanel.Right.Open(false);
					m_rootPanel.Left.Close(false);
				}
				else
				{
					m_rootPanel.Right.Close(false);
					m_rootPanel.Left.Open(false);
				}
			}
			IBJAKJJICBC ib = m_eventMusicData.Get(m_isLine6Mode ? m_currentSelectIndex6 : m_currentSelectIndex, m_isLine6Mode, false);
			SetViewMusicData(ib.GHBPLHBNMBK_FreeMusicId);
			m_bossInfoLayout.InitLayout(raidController.JIBMOEHKMGB_SelectedBoss, raidController.AGEJGHGEGFF_GetBossName(raidController.JIBMOEHKMGB_SelectedBoss.INDDJNMPONH_Type), raidController.MCBGNPBECCI_SupportBonusMax());
			m_rootPanel.Left.SetActType(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.CCAPCGPIIPF_1_Support, raidController.CBDMCDKKFBE_GetNeedAp(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.CCAPCGPIIPF_1_Support));
			m_rootPanel.Right.SetActType(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.OOEHFFBHCIC_3_FullPower, raidController.CBDMCDKKFBE_GetNeedAp(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.OOEHFFBHCIC_3_FullPower));
			m_rootPanel.Left.SetBonusNum(raidController.AFODCOIFHKO_GetSupportBonus(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.CCAPCGPIIPF_1_Support));
			m_rootPanel.Right.SetBonusNum(raidController.EMJEBMMMDBE_GetPointBonus(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.OOEHFFBHCIC_3_FullPower));
			UpdatePanelOkButton();
			m_musicInfo.MakeCache();
			CrateQuestList();
			ApplyMusicInfoNormal();
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.Raid, raidController.JIBMOEHKMGB_SelectedBoss.HPPDFBKEJCG_BgId, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			InitPopupSettings();
			if(m_selectMusicData.IFNPBIJEPBO_IsDlded)
			{
				ChangeTrialMusic(m_selectMusicData.KKPAHLMJKIH_WavId);
			}
			else
			{
				FadeOutBGM();
			}
			m_topGauge.Initialize();
			m_isInitialized = true;
			isCallFriendSelect = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7113A4 Offset: 0x7113A4 VA: 0x7113A4
		// // RVA: 0x9EBD68 Offset: 0x9EBD68 VA: 0x9EBD68
		private IEnumerator Co_MusicRelatedInit()
		{
			//0x144A4A8
			RaidActSelectArgs arg = Args as RaidActSelectArgs;
			if(arg == null)
			{
				arg = ArgsReturn as RaidActSelectArgs;
				if(arg == null)
				{
					m_isLine6Mode = false;
				}
				else
				{
					m_isLine6Mode = arg.EventMusicSelectSceneArgs != null && arg.EventMusicSelectSceneArgs.isLine6Mode;
					m_returnUniqueId = arg.ReturnTransitionUniqueId;
				}
			}
			else
			{
				m_isLine6Mode = arg.EventMusicSelectSceneArgs != null && arg.EventMusicSelectSceneArgs.isLine6Mode;
				m_returnUniqueId = arg.ReturnTransitionUniqueId; 
			}
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
            List<IBJAKJJICBC> l1 = IBJAKJJICBC.DHFHJBMKEHN(5, t, false);
            List<IBJAKJJICBC> l2 = IBJAKJJICBC.DHFHJBMKEHN(5, t, true);
            List<IBJAKJJICBC> viewList = new List<IBJAKJJICBC>();
			List<IBJAKJJICBC> view6List = new List<IBJAKJJICBC>();
            List<int> freeMusicIds = raidController.HEACCHAKMFG_GetMusicsList(raidController.JIBMOEHKMGB_SelectedBoss.INDDJNMPONH_Type);
			for(int i = 0; i < freeMusicIds.Count; i++)
			{
				IBJAKJJICBC ib = l1.Find((IBJAKJJICBC a) =>
				{
					//0x14457E4
					return a.GHBPLHBNMBK_FreeMusicId == freeMusicIds[i];
				});
				if(ib != null)
				{
					viewList.Add(ib);
				}
				ib = l2.Find((IBJAKJJICBC a) =>
				{
					//0x14458AC
					return a.GHBPLHBNMBK_FreeMusicId == freeMusicIds[i];
				});
				if(ib != null)
				{
					view6List.Add(ib);
				}
			}
			m_eventMusicData = new MusicDataList(viewList, view6List);
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("ct/mc/{0:D3}.xab", 0);
			TryInstall(str);
			TryInstall(str, m_eventMusicData);
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			bool b = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.JGAFBCMOGLP_Raid.FKEJBAHCMGC(raidController.PGIIDPEGGPI_EventId);
			diff = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.JGAFBCMOGLP_Raid.FFACBDAJJJP_GetDifficulty();
			if(b)
			{
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			}
        }

		// // RVA: 0x9EBDF0 Offset: 0x9EBDF0 VA: 0x9EBDF0
		private void ClickPlayButton()
		{
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(!m_selectMusicData.IFNPBIJEPBO_IsDlded)
			{
				DownloadCurrentMusic();
			}
			else
			{
				if(!MenuScene.Instance.TryMusicPeriod(m_selectMusicData.IHPCKOMBGKJ_End, raidController != null ? raidController.PGIIDPEGGPI_EventId : 0, (OHCAABOMEOF.KGOGMKMBCPP_EventType)m_selectMusicData.MNNHHJBBICA_GameEventType, false, MenuScene.MusicPeriodMess.MusicSelect))
				{
					CheckUnitLive(() =>
					{
						//0x9F120C
						Database.Instance.gameSetup.ResetSelectedDashIndex();
						DecideCurrentMusic();
					});
					return;
				}
			}
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71141C Offset: 0x71141C VA: 0x71141C
		// // RVA: 0x9EBC58 Offset: 0x9EBC58 VA: 0x9EBC58
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x14
			FontInfo systemFont; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOp; // 0x20

			//0x1449B34
			bundleName = new StringBuilder();
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/200.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_act_tl_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x9F12A8
				instance.transform.SetParent(transform, false);
				m_bossInfoLayout = instance.GetComponent<RaidActSelectBossInfoLayout>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_act_b_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x9F1378
				instance.transform.SetParent(transform, false);
				m_rootPanel = instance.GetComponent<RaidActSelectRootPanel>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_info_win_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x9F1448
				instance.transform.SetParent(transform, false);
				m_musicInfo = instance.GetComponent<RaidActSelectMusicInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_btn_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x9F1518
				instance.transform.SetParent(transform, false);
				m_buttonSet = instance.GetComponent<RaidActSelectButtonSet>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_raid_apbar_tr_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x9F15E8
				instance.transform.SetParent(transform, false);
				m_topGauge = instance.GetComponent<RaidTopGauge>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_btn_line_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x9F16B8
				instance.transform.SetParent(transform, false);
				m_laneButton = instance.GetComponent<RaidActSelectLaneButton>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			IsReady = true;
		}

		// // RVA: 0x9EC178 Offset: 0x9EC178 VA: 0x9EC178
		private void Release()
		{
			m_musicInfo.ReleaseCache();
			m_rootPanel.Left.OnClickPanelListner -= OnClickLeftPanel;
			m_rootPanel.Left.OnClickPlayButtonListner -= OnClickPlayButton;
			m_rootPanel.Right.OnClickPanelListner -= OnClickRightPanel;
			m_rootPanel.Right.OnClickPlayButtonListner -= OnClickPlayButton;
		}

		// // RVA: 0x9EC3EC Offset: 0x9EC3EC VA: 0x9EC3EC
		public void OnClickLeftPanel()
		{
			if(m_rootPanel.Left.IsOpen)
				return;
			SoundManager.Instance.sePlayerRaid.Play((int)mcrs.cs_se_raid.SE_RAID_001);
			m_rootPanel.Left.Open(true);
			m_rootPanel.Right.Close(true);
		}

		// // RVA: 0x9EC518 Offset: 0x9EC518 VA: 0x9EC518
		public void OnClickRightPanel()
		{
			if(m_rootPanel.Right.IsOpen)
				return;
			SoundManager.Instance.sePlayerRaid.Play((int)mcrs.cs_se_raid.SE_RAID_001);
			m_rootPanel.Left.Close(true);
			m_rootPanel.Right.Open(true);
		}

		// // RVA: 0x9EC644 Offset: 0x9EC644 VA: 0x9EC644
		public void OnClickPlayButton(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH attackType)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			CheckBossAlive(() =>
			{
				//0x144597C
				if(m_selectMusicData.IFNPBIJEPBO_IsDlded)
				{
					if(!raidController.MACJBPDFCAI_ConsumeAp(raidController.CBDMCDKKFBE_GetNeedAp(attackType), true))
					{
						m_topGauge.ShowApHealPopup(null);
						MenuScene.Instance.InputEnable();
						return;
					}
					raidController.FDNIODNLDAI(attackType);
					if(attackType >= JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.CCAPCGPIIPF_1_Support && attackType < JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.OOEHFFBHCIC_3_FullPower)
					{
						if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsShowRaidAssistHelp))
						{
							MessageBank bk = MessageManager.Instance.GetBank("menu");
							PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("pop_raid_assist_attack_skip_title"), SizeType.Middle, bk.GetMessageByLabel("pop_raid_assist_attack_skip_desc_01"), new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
							{
								//0x1445E98
								CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsShowRaidAssistHelp, true);
								ClickPlayButton();
							}, null, null, null, true, true, false);
							return;
						}
					}
				}
				ClickPlayButton();
			});
		}

		// RVA: 0x9EC9B0 Offset: 0x9EC9B0 VA: 0x9EC9B0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_isInitialized = false;
			m_unitLiveLocalSaveData = new MMOLNAHHDOM();
			m_unitLiveLocalSaveData.PCODDPDFLHK_Read();
			m_isConfirmedUnitDance = false;
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0x9ECA60 Offset: 0x9ECA60 VA: 0x9ECA60 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return true;
		}

		// RVA: 0x9ECA68 Offset: 0x9ECA68 VA: 0x9ECA68 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_bossInfoLayout != null && m_bossInfoLayout.IsLoaded() && 
				m_rootPanel.Left != null && m_rootPanel.Left.IsLoaded() && 
				m_rootPanel.Right != null && m_rootPanel.Right.IsLoaded() && 
				m_musicInfo != null && m_musicInfo.IsLoaded() && 
				m_buttonSet != null && m_buttonSet.IsLoaded() && 
				m_topGauge != null && m_topGauge.IsLoaded() && 
				m_laneButton != null && m_laneButton.IsLoaded() && 
				m_isInitialized;
		}

		// RVA: 0x9ECE8C Offset: 0x9ECE8C VA: 0x9ECE8C Slot: 23
		protected override void OnActivateScene()
		{
			transform.SetAsFirstSibling();
			this.StartCoroutineWatched(Co_OnActivateScene());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x711494 Offset: 0x711494 VA: 0x711494
		// // RVA: 0x9ECEDC Offset: 0x9ECEDC VA: 0x9ECEDC
		private IEnumerator Co_OnActivateScene()
		{
			//0x144AE88
			yield return Co.R(TryShowTutorial());
		}

		// RVA: 0x9ECF64 Offset: 0x9ECF64 VA: 0x9ECF64 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			transform.SetAsFirstSibling();
			m_bossInfoLayout.Enter();
			m_rootPanel.Enter();
			m_musicInfo.Enter();
			m_buttonSet.Enter();
			m_topGauge.Enter();
			if(m_eventMusicData.GetCount(true, false) > 0)
			{
				m_laneButton.SetUnlock(IBJAKJJICBC.KGJJCAKCMLO());
				m_laneButton.SetUnlockNumber(IBJAKJJICBC.POPLHDKHIIM());
				m_laneButton.Enter(m_isLine6Mode);
			}
			else
			{
				m_laneButton.Hide();
			}
		}

		// RVA: 0x9ED11C Offset: 0x9ED11C VA: 0x9ED11C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_musicInfo.IsPlaying() && !m_buttonSet.IsPlaying() && !m_topGauge.IsPlaying();
		}

		// RVA: 0x9ED1A8 Offset: 0x9ED1A8 VA: 0x9ED1A8 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_bossInfoLayout.Leave();
			m_rootPanel.Leave();
			m_musicInfo.Leave();
			m_buttonSet.Leave();
			m_topGauge.Leave();
			m_laneButton.Leave();
		}

		// RVA: 0x9ED278 Offset: 0x9ED278 VA: 0x9ED278 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_musicInfo.IsPlaying() && !m_buttonSet.IsPlaying() && !m_topGauge.IsPlaying();
		}

		// RVA: 0x9ED304 Offset: 0x9ED304 VA: 0x9ED304 Slot: 14
		protected override void OnDestoryScene()
		{
			Release();
			m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
			if(isCallFriendSelect)
			{
				MenuScene.Instance.InputEnable();
			}
		}

		// RVA: 0x9ED3DC Offset: 0x9ED3DC VA: 0x9ED3DC Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_popupUnitDanceWarning != null)
				m_popupUnitDanceWarning.Release();
		}

		// RVA: 0x9ED3F0 Offset: 0x9ED3F0 VA: 0x9ED3F0 Slot: 29
		protected override void InputEnable()
		{
			base.InputEnable();
			if(InputStateCount == 0)
			{
				m_musicInfo.InputEnable();
			}
		}

		// RVA: 0x9ED43C Offset: 0x9ED43C VA: 0x9ED43C Slot: 30
		protected override void InputDisable()
		{
			base.InputDisable();
			if(InputStateCount > 0)
			{
				m_musicInfo.InputDisable();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71150C Offset: 0x71150C VA: 0x71150C
		// // RVA: 0x9ED488 Offset: 0x9ED488 VA: 0x9ED488
		protected IEnumerator TryShowTutorial()
		{
			//0x144AFAC
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_76));
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_60));
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.RaycastEnable();
		}

		// // RVA: 0x9ED510 Offset: 0x9ED510 VA: 0x9ED510
		protected bool CheckTutorialFunc_60(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition60;
		}

		// // RVA: 0x9ED8A4 Offset: 0x9ED8A4 VA: 0x9ED8A4
		protected bool CheckTutorialFunc_76(TutorialConditionId conditionId)
		{
			if(conditionId == TutorialConditionId.Condition76 && !GameManager.Instance.IsTutorial)
			{
				if(!MenuScene.Instance.DirtyChangeScene && CanDoUnitDanceFocus(false))
					return IsEnableUnitDance(false);
			}
			return false;
		}

		// // RVA: 0x9ED644 Offset: 0x9ED644 VA: 0x9ED644
		protected bool CanDoUnitDanceFocus(bool line6Mode/* = False*/)
		{
			return !GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.ODKIHPBEOEC_IsTrue(48) && IsEnableUnitDance(line6Mode);
		}

		// // RVA: 0x9ED770 Offset: 0x9ED770 VA: 0x9ED770
		private bool IsEnableUnitDance(bool line6Mode/* = False*/)
		{
			if(raidController != null && raidController.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
			{
                List<IBJAKJJICBC> l = m_eventMusicData.GetList(line6Mode, false);
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].JAPLKHPLOOF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid))
					{
						return true;
					}
				}
            }
			return false;
		}

		// // RVA: 0x9ED8B4 Offset: 0x9ED8B4 VA: 0x9ED8B4
		private void ApplyUnitLiveButtonSetting(bool isUnit)
		{
			m_unitLiveLocalSaveData.IAGAAOKODPM_SetMultiDiva(m_selectMusicData.GHBPLHBNMBK_FreeMusicId, isUnit);
			m_musicInfo.SetupUnitLive(m_selectMusicData, m_unitLiveLocalSaveData);
		}

		// // RVA: 0x9ED944 Offset: 0x9ED944 VA: 0x9ED944
		private void ApplyMusicInfoNormal()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_musicInfo.SetRaidMusicInfoStyle(m_isLine6Mode);
			m_musicInfo.SetArrow(m_eventMusicData.GetCount(m_isLine6Mode, false) > 1);
			m_buttonSet.SetOptionStyle(RaidActSelectButtonSet.OptionStyle.RaidEvent, false, false, false, false);
			if(!m_isLine6Mode)
			{
				if(m_selectMusicData.PJLNJJIBFBN_HasExtremeDiff)
				{
					m_musicInfo.SetDiffTabStyle(RaidActSelectMusicInfo.DiffTabStyle.N5, m_isLine6Mode, false);
				}
				else
				{
					m_musicInfo.SetDiffTabStyle(RaidActSelectMusicInfo.DiffTabStyle.N4, m_isLine6Mode, false);
					if(diff > Difficulty.Type.VeryHard)
						diff = Difficulty.Type.VeryHard;
				}
			}
			else
			{
				m_musicInfo.SetDiffTabStyle(RaidActSelectMusicInfo.DiffTabStyle.N3, true, false);
				if(diff < Difficulty.Type.Hard)
					diff = Difficulty.Type.Hard;
			}
			for(int i = m_selectMusicData.MGJKEJHEBPO_DiffInfos.Count - 1; i >= 0; i--)
			{
				if(m_selectMusicData.MGJKEJHEBPO_DiffInfos[i].POOMOBGPCNE_IsLocked && diff >= (Difficulty.Type)i)
					diff = (Difficulty.Type)(i - 1);
			}
			m_rootPanel.Left.SetNeedAp(raidController.CBDMCDKKFBE_GetNeedAp(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.CCAPCGPIIPF_1_Support));
			m_rootPanel.Right.SetNeedAp(raidController.CBDMCDKKFBE_GetNeedAp(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.OOEHFFBHCIC_3_FullPower));
			m_buttonSet.SetEnemyHasSkill(m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.CDEFLIHHNAB_HasSkills);
			m_buttonSet.SetBadge(RaidActSelectOptionButton.OptionType.EvMission, IsReceiveMission());
			m_musicInfo.ChangeSelectedDiff(diff);
			m_musicInfo.SetMusicTitle(m_selectMusicData.NEDBBJDAFBH_MusicName, GameAttributeTextColor.Colors[m_selectMusicData.FKDCCLPGKDK_JacketAttr - 1], false);
			m_musicInfo.SetSingerName(m_selectMusicData.LJCEDBBNPBB_VocalName, false);
			m_musicInfo.SetCdJacket(m_selectMusicData.JNCPEGJGHOG_JacketId, (GameAttribute.Type)m_selectMusicData.FKDCCLPGKDK_JacketAttr);
			m_musicInfo.SetMusicAttr((GameAttribute.Type)m_selectMusicData.FKDCCLPGKDK_JacketAttr);
			if(m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HHMLMKAEJBJ_Score != null)
			{
				StringBuilder str = new StringBuilder(8);
				str.Set(m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HHMLMKAEJBJ_Score.ANAJIAENLNB_MusicLevel.ToString());
				if(m_isLine6Mode)
				{
					str.Append("+");
				}
				m_musicInfo.SetMusicLevel(str.ToString());
			}
			for(int i = 0; i < m_selectMusicData.MGJKEJHEBPO_DiffInfos.Count; i++)
			{
				m_musicInfo.SetDiffLock((Difficulty.Type)i, m_selectMusicData.MGJKEJHEBPO_DiffInfos[i].POOMOBGPCNE_IsLocked, true);
				m_musicInfo.SetDiffStatus((Difficulty.Type)i, m_selectMusicData.MGJKEJHEBPO_DiffInfos[i].CADENLBDAEB_IsNew, 
					m_selectMusicData.MGJKEJHEBPO_DiffInfos[i].BCGLDMKODLC_IsClear, 
					(RhythmGameConsts.ResultComboType)m_selectMusicData.MGJKEJHEBPO_DiffInfos[i].LCOHGOIDMDF_ComboRank);
			}
			if(m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].BCGLDMKODLC_IsClear && 
				m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].KNIFCANOHOC_Score > 0)
			{
				m_musicInfo.SetHighscore(m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].KNIFCANOHOC_Score);
				m_musicInfo.SetMusicScoreRank((ResultScoreRank.Type)m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].BAKLKJLPLOJ.DLPBHJALHCK_GetScoreRank(m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].KNIFCANOHOC_Score));
			}
			else
			{
				m_musicInfo.SetHighscore(0);
				m_musicInfo.SetMusicScoreRank(ResultScoreRank.Type.Illegal);
			}
			m_musicInfo.SetupUnitLive(m_selectMusicData, m_unitLiveLocalSaveData);
		}

		// // RVA: 0x9EE664 Offset: 0x9EE664 VA: 0x9EE664
		private void UpdatePanelOkButton()
		{
			if(m_selectMusicData.IFNPBIJEPBO_IsDlded)
			{
				m_rootPanel.Right.SetPlayButtonType(RaidActSelectPanel.PlayButtonType.Ok);
				m_rootPanel.Left.SetPlayButtonType(RaidActSelectPanel.PlayButtonType.Ok);
			}
			else
			{
				m_rootPanel.Right.SetPlayButtonType(RaidActSelectPanel.PlayButtonType.Download);
				m_rootPanel.Left.SetPlayButtonType(RaidActSelectPanel.PlayButtonType.Download);
			}
		}

		// // RVA: 0x9EE774 Offset: 0x9EE774 VA: 0x9EE774
		private void TryInstall(StringBuilder bundleName)
		{
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(bundleName.ToString());
		}

		// // RVA: 0x9EE840 Offset: 0x9EE840 VA: 0x9EE840
		private void TryInstall(StringBuilder bundleName, MusicDataList musicList)
		{
			for(int i = 0; i < musicList.GetCount(m_isLine6Mode, false); i++)
			{
                IBJAKJJICBC ib = musicList.Get(i, m_isLine6Mode, false);
				if(!ib.AJGCPCMLGKO_IsEvent)
				{
					if(!ib.BNIAJAKIAJC_IsEventMinigame)
					{
						bundleName.SetFormat("ct/mc/{0:D3}.xab", ib.JNCPEGJGHOG_JacketId);
					}
					else
					{
						bundleName.SetFormat("ct/ev/mc/{0:D4}.xab", ib.NOKBLCDMLPP_MinigameEventInfo.GOAPADIHAHG_EventId);
					}
				}
				else
				{
					bundleName.SetFormat("ct/ev/mc/{0:D4}.xab", ib.AFCMIOIGAJN_EventInfo.GOAPADIHAHG_EventId);
				}
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(bundleName.ToString());
            }
		}

		// // RVA: 0x9EEB30 Offset: 0x9EEB30 VA: 0x9EEB30
		private void SetViewMusicData(int freeMusicId)
		{
			int idx = m_eventMusicData.FindIndex(freeMusicId, m_isLine6Mode, false);
			if(idx < 0)
			{
				m_isLine6Mode = false;
				idx = m_eventMusicData.FindIndex(freeMusicId, false, false);
				if(idx < 0)
				{
					if(m_eventMusicData.GetCount(m_isLine6Mode, false) == 0)
					{
						Debug.LogError("StringLiteral_19745");
						return;
					}
					idx = 0;
				}
			}
			m_selectMusicData = m_eventMusicData.Get(idx, m_isLine6Mode, false);
		}

		// // RVA: 0x9EC070 Offset: 0x9EC070 VA: 0x9EC070
		private void DownloadCurrentMusic()
		{
			m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
			this.StartCoroutineWatched(Co_DownloadMusic(m_selectMusicData));
		}

		// // RVA: 0x9EEDCC Offset: 0x9EEDCC VA: 0x9EEDCC
		private void DecideCurrentMusic()
		{
			Database.Instance.gameSetup.musicInfo.SetupInfoByFreeMusic(
				m_selectMusicData.GHBPLHBNMBK_FreeMusicId, diff, true, new GameSetupData.MusicInfo.InitFreeMusicParam()
				{
					returnTransitionUniqueId = m_returnUniqueId,
				},
				(OHCAABOMEOF.KGOGMKMBCPP_EventType)m_selectMusicData.MNNHHJBBICA_GameEventType,
				(OHCAABOMEOF.KGOGMKMBCPP_EventType)m_selectMusicData.MFJKNCACBDG_OpenEventType,
				(OHCAABOMEOF.KGOGMKMBCPP_EventType)m_selectMusicData.OEILJHENAHN_PlayEventType,
				false, m_isLine6Mode,
				raidController.JIBMOEHKMGB_SelectedBoss.CJLHLKKNMEE_MissionText,
				m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.DCOALMMJDJK_OverrideCenterSkill,
				m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.KKPLDFNDFDE_OverrideLiveSkill,
				m_selectMusicData.ALMOMLMCHNA_OtherEndTime,
				m_selectMusicData.IHPCKOMBGKJ_End,
				raidController != null ? raidController.PGIIDPEGGPI_EventId : 0, GetDanceDivaCount(), 0);
			Database.Instance.selectedMusic.SetMusicData(m_selectMusicData);
			MenuScene.Instance.Call(TransitionList.Type.FRIEND_SELECT, null, true);
			isCallFriendSelect = true;
		}

		// // RVA: 0x9EF220 Offset: 0x9EF220 VA: 0x9EF220
		private int GetDanceDivaCount()
		{
			return m_musicInfo.GetDivaCount();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x711584 Offset: 0x711584 VA: 0x711584
		// // RVA: 0x9EED28 Offset: 0x9EED28 VA: 0x9EED28
		private IEnumerator Co_DownloadMusic(IBJAKJJICBC musicData)
		{
			UGUIFader fader; // 0x18
			TipsControl tipsCtrl; // 0x1C
			int musicId; // 0x20
			ILCCJNDFFOB lw; // 0x24
			float pre; // 0x28

			//0x1447814
			fader = GameManager.Instance.fullscreenFader;
			//GameManager.Instance.DownloadBar;
			tipsCtrl = TipsControl.Instance;
			MenuScene.Instance.InputDisable();
			fader.Fade(0.5f, new Color(0, 0, 0, 0.5f));
			tipsCtrl.Show(musicData);
			while(fader.isFading)
				yield return null;
			yield return tipsCtrl.WaitLoadingYield;
			while(tipsCtrl.isPlayingAnime())
				yield return null;
			musicId = musicData.DLAEJOBELBH_MusicId;
			int a = 0;
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PMGMMMGCEEI_Video == 0)
			{
				a = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CBLEFELBNDN_GetVideoQuality();
			}
			KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP = 0;
			lw = ILCCJNDFFOB.HHCJCDFCLOB;
			lw.OJOLFJGNEMO(0, musicId);
			pre = 0;
			KDLPEDBKMID.HHCJCDFCLOB.OKJCGCOGDIA_DownloadSongDatas(musicData.KKPAHLMJKIH_WavId, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(musicData.GHBPLHBNMBK_FreeMusicId).KEFGPJBKAOD_WavId, a, GetDanceDivaCount());
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
			{
				if(pre < 50 && KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP >= 50)
				{
					lw.OJOLFJGNEMO(1, musicId);
				}
				pre = KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP;
			}
			lw.OJOLFJGNEMO(2, musicId);
			m_eventMusicData.UpdateDownloadState(musicData.DLAEJOBELBH_MusicId);
			UpdatePanelOkButton();
			fader.Fade(0.5f, 0);
			tipsCtrl.Close();
			while(fader.isFading)
				yield return null;
			while(tipsCtrl.isPlayingAnime())
				yield return null;
			ChangeTrialMusic(musicData.KKPAHLMJKIH_WavId);
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x9EF24C Offset: 0x9EF24C VA: 0x9EF24C
		private void FadeOutBGM()
		{
			m_changeToTrialBgmId = -1;
			if(SoundManager.Instance.bgmPlayer.isPlaying && !m_requestFadeOutBgm)
			{
				m_requestFadeOutBgm = true;
				SoundManager.Instance.bgmPlayer.FadeOut(0.3f, OnEndFadeOutBGM);
			}
		}

		// // RVA: 0x9EF364 Offset: 0x9EF364 VA: 0x9EF364
		private void ChangeTrialMusic(int wavId)
		{
			int bgmId = BgmPlayer.MENU_TRIAL_ID_BASE + wavId;
			if(!SoundManager.Instance.bgmPlayer.isPlaying)
			{
				SoundManager.Instance.bgmPlayer.Play(bgmId, 1);
				m_changeToTrialBgmId = -1;
			}
			else if(!m_requestFadeOutBgm)
			{
				if(SoundManager.Instance.bgmPlayer.currentBgmId != bgmId)
				{
					m_changeToTrialBgmId = bgmId;
					m_requestFadeOutBgm = true;
					SoundManager.Instance.bgmPlayer.FadeOut(0.3f, OnEndFadeOutBGM);
				}
			}
			else
				m_changeToTrialBgmId = bgmId;
		}

		// RVA: 0x9EF51C Offset: 0x9EF51C VA: 0x9EF51C
		private void OnEndFadeOutBGM()
		{
			m_requestFadeOutBgm = false;
			if(m_changeToTrialBgmId < 0)
				return;
			SoundManager.Instance.bgmPlayer.Play(m_changeToTrialBgmId, 1);
			m_changeToTrialBgmId = -1;
		}

		// // RVA: 0x9EF59C Offset: 0x9EF59C VA: 0x9EF59C
		// private void ClearUnitDanceConfirm() { }

		// // RVA: 0x9EC0C0 Offset: 0x9EC0C0 VA: 0x9EC0C0
		private void CheckUnitLive(Action endCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_CheckUnitLive(endCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7115FC Offset: 0x7115FC VA: 0x7115FC
		// // RVA: 0x9EF5A8 Offset: 0x9EF5A8 VA: 0x9EF5A8
		private IEnumerator Co_CheckUnitLive(Action endCallback)
		{
			int danceDivaCount; // 0x20
			bool isUnitOnly; // 0x24
			UnityAction<bool> positiveAction; // 0x28
			UnityAction<bool> negativeAction; // 0x2C
			UnityAction toggleAction; // 0x30
			GameManager.PushBackButtonHandler handler; // 0x34

			//0x1446584
			danceDivaCount = GetDanceDivaCount();
			if(danceDivaCount >= 2)
			{
				int cnt = 0;
				for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
				{
					cnt += CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_Have;
				}
				if(cnt < danceDivaCount)
				{
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					bool done = false;
					PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, string.Format(bk.GetMessageByLabel("unit_multi_dance_popup_03"), danceDivaCount), new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x14453EC
						return;
					}, null, null, null, true, true, false, null, () =>
					{
						//0x1445FB0
						done = true;
					});
					while(!done)
						yield return null;
					MenuScene.Instance.InputEnable();
					yield break;
				}
                ILDKBCLAFPB.JCFNHPMBPLJ_UnitDance saveData = GameManager.Instance.localSave.EPJOACOONAC_GetSave().EGNEDJLCMAI_UnitDance;
                if(!saveData.KBAMKMDJMJC_DisableWarning && !m_isConfirmedUnitDance)
				{
					MenuScene.Instance.InputDisable();
					if(!m_popupUnitDanceWarning.IsLoaded)
					{
						yield return Co.R(m_popupUnitDanceWarning.Co_Load(transform.parent));
					}
					isUnitOnly = (m_selectMusicData.BNCMJNMIDIN_AvaiableDivaModes & 1) != 0;
					m_popupUnitDanceWarning.WarningWindow.Initialize(danceDivaCount, isUnitOnly);
					m_popupUnitDanceWarning.WarningWindow.transform.SetAsLastSibling();
					m_popupUnitDanceWarning.WarningWindow.Show();
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_000);
					while(m_popupUnitDanceWarning.WarningWindow.IsPlaying())
						yield return null;
					bool done = false;
					positiveAction = (bool isOn) =>
					{
						//0x1445FC4
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
						saveData.KBAMKMDJMJC_DisableWarning = isOn;
						done = true;
					};
					negativeAction = (bool isOn) =>
					{
						//0x1446058
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
						ApplyUnitLiveButtonSetting(false);
						saveData.KBAMKMDJMJC_DisableWarning = isOn;
						done = true;
					};
					toggleAction = () =>
					{
						//0x14453F0
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					};
					m_popupUnitDanceWarning.WarningWindow.PositiveListener += positiveAction;
					m_popupUnitDanceWarning.WarningWindow.NegativeListener += negativeAction;
					m_popupUnitDanceWarning.WarningWindow.ToggleButtonListener += toggleAction;
					handler = DummyBackButton;
					if(isUnitOnly)
					{
						handler = UnitDanceOnlyBackButton;
					}
					GameManager.Instance.AddPushBackButtonHandler(handler);
					MenuScene.Instance.InputEnable();
					while(!done)
						yield return null;
					MenuScene.Instance.InputDisable();
					m_popupUnitDanceWarning.WarningWindow.PositiveListener -= positiveAction;
					m_popupUnitDanceWarning.WarningWindow.NegativeListener -= negativeAction;
					m_popupUnitDanceWarning.WarningWindow.ToggleButtonListener -= toggleAction;
					GameManager.Instance.RemovePushBackButtonHandler(handler);
					m_popupUnitDanceWarning.WarningWindow.Close();
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_001);
					while(m_popupUnitDanceWarning.WarningWindow.IsPlaying())
						yield return null;
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
					m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
					MenuScene.Instance.InputEnable();
					m_isConfirmedUnitDance = true;
					positiveAction = null;
					negativeAction = null;
					toggleAction = null;
				}
				//LAB_01447438
			}
			//LAB_01447438
			if(endCallback != null)
				endCallback();
		}

		// // RVA: 0x9EF64C Offset: 0x9EF64C VA: 0x9EF64C
		private void DummyBackButton()
		{
			return;
		}

		// // RVA: 0x9EF650 Offset: 0x9EF650 VA: 0x9EF650
		private void UnitDanceOnlyBackButton()
		{
			m_popupUnitDanceWarning.WarningWindow.PerformClickOk();
		}

		// // RVA: 0x9EC770 Offset: 0x9EC770 VA: 0x9EC770
		private void CheckBossAlive(Action endCallback)
		{
			if(!IsEndRaidEvent())
			{
				MenuScene.Instance.InputDisable();
				raidController.GKCEHODEPMJ_GetBosses_WithOptionalPlayersNames(false, () =>
				{
					//0x144612C
					if(raidController.JIBMOEHKMGB_SelectedBoss.CMCKNKKCNDK_Status == NHCDBBBMFFG.OPNEOJEGDJB_2_Dead)
					{
						PopupWindowManager.Show(m_popRaidDefeatedSetting, (PopupWindowControl control2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
						{
							//0x1445448
							MenuScene.Instance.Return(true);
						}, null, null, null, true, true, false);
					}
					else if(raidController.JIBMOEHKMGB_SelectedBoss.CMCKNKKCNDK_Status != NHCDBBBMFFG.NFDONDKDHPK_3_Escaped)
					{
						endCallback();
						return;
					}
					else
					{
						PopupWindowManager.Show(m_popRaidEscapedSetting, (PopupWindowControl control2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
						{
							//0x14454E8
							MenuScene.Instance.Return(true);
						}, null, null, null, true, true, false);
					}
					MenuScene.Instance.InputEnable();
				}, () =>
				{
					//0x1445588
					MenuScene.Instance.InputEnable();
					MenuScene.Instance.GotoTitle();
				});
			}
		}

		// // RVA: 0x9EF918 Offset: 0x9EF918 VA: 0x9EF918
		private void OnChangeLineMode(int style)
		{
			m_isLine6Mode = style == 1;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.HPDBEKAGKOD_SetIsLine6(m_isLine6Mode);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			ChangedMusic(m_eventMusicData.Get(m_isLine6Mode ? m_currentSelectIndex6 : m_currentSelectIndex, m_isLine6Mode, false).GHBPLHBNMBK_FreeMusicId);
		}

		// // RVA: 0x9EFBC0 Offset: 0x9EFBC0 VA: 0x9EFBC0
		private void OnClickMvpButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!IsEndRaidEvent())
			{
				if(raidController == null || raidController.JIBMOEHKMGB_SelectedBoss == null)
				{
					MenuScene.Instance.Call(TransitionList.Type.RAID_MVP, null, true);
				}
				else
				{
					MenuScene.Instance.Call(TransitionList.Type.RAID_MVP, new RaidMvpCandidatesArgs(raidController.JIBMOEHKMGB_SelectedBoss), true);
				}
			}
		}

		// // RVA: 0x9EFD98 Offset: 0x9EFD98 VA: 0x9EFD98
		private void OnClickEventRewardButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(!IsEndRaidEvent())
			{
				this.StartCoroutineWatched(PopupRewardEvCheck.Co_ShowPopupRaidEvent(raidController, false, transform, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x144564C
					return;
				}));
			}
		}

		// // RVA: 0x9F0014 Offset: 0x9F0014 VA: 0x9F0014
		private void OnClickMissionButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!IsEndRaidEvent())
			{
				CGJKNOCAPII c = new CGJKNOCAPII();
				MenuScene.Instance.Call(TransitionList.Type.QUEST_SELECT, new QuestTopFormQuestListArgs(c.BJKJLDPDEFA(raidController, true)), true);
			}
		}

		// // RVA: 0x9F0198 Offset: 0x9F0198 VA: 0x9F0198
		private void OnClickDetailButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			OpenMusicDetailWindow();
		}

		// // RVA: 0x9F0428 Offset: 0x9F0428 VA: 0x9F0428
		private void OnClickEnemyInfoButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(!IsEndRaidEvent())
			{
				GameManager.Instance.CloseSnsNotice();
				GameManager.Instance.CloseOfferNotice();
				MenuScene.Instance.MusicPopupWindowControl.ShowEnemyInfo(this, MusicPopupWindowControl.CallType.MusicSelect, m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData, null);
			}
		}

		// // RVA: 0x9F0648 Offset: 0x9F0648 VA: 0x9F0648
		// private bool CheckEventLimit() { }

		// // RVA: 0x9F02B4 Offset: 0x9F02B4 VA: 0x9F02B4
		private void OpenMusicDetailWindow()
		{
			MenuScene.Instance.MusicPopupWindowControl.Show(this, MusicPopupWindowControl.CallType.MusicSelect, m_selectMusicData.DLAEJOBELBH_MusicId, 
				m_selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData, null, false);
		}

		// // RVA: 0x9F0930 Offset: 0x9F0930 VA: 0x9F0930
		private void OnChangedDifficulty(Difficulty.Type difficulty)
		{
			diff = difficulty;
			ApplyMusicInfoNormal();
			SaveDifficulty();
		}

		// // RVA: 0x9F0A7C Offset: 0x9F0A7C VA: 0x9F0A7C
		private void CrateQuestList()
		{
			if(raidController == null)
			{
				m_questList = new List<FKMOKDCJFEN>();
			}
			else
			{
				m_questList = FKMOKDCJFEN.KJHKBBBDBAL(raidController.JOPOPMLFINI_QuestId, false, -1);
			}
		}

		// // RVA: 0x9EE4FC Offset: 0x9EE4FC VA: 0x9EE4FC
		private bool IsReceiveMission()
		{
			if(m_questList != null)
			{
				return m_questList.FindIndex((FKMOKDCJFEN x) =>
				{
					//0x14456EC
					return x.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved;
				}) > -1;
			}
			return false;
		}

		// // RVA: 0x9F0B24 Offset: 0x9F0B24 VA: 0x9F0B24
		private void OnClickMusicSelectArrow(int offset)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_004);
			if(!m_isLine6Mode)
			{
				m_currentSelectIndex = XeSys.Math.Repeat(m_currentSelectIndex + offset, 0, m_eventMusicData.GetCount(false, false) - 1);
			}
			else
			{
				m_currentSelectIndex6 = XeSys.Math.Repeat(m_currentSelectIndex6 + offset, 0, m_eventMusicData.GetCount(true, false) - 1);
			}
			ChangedMusic(m_eventMusicData.Get(m_isLine6Mode ? m_currentSelectIndex6 : m_currentSelectIndex, m_isLine6Mode, false).GHBPLHBNMBK_FreeMusicId);
		}

		// // RVA: 0x9EFB3C Offset: 0x9EFB3C VA: 0x9EFB3C
		private void ChangedMusic(int freeMusicId)
		{
			SetViewMusicData(freeMusicId);
			UpdatePanelOkButton();
			ApplyMusicInfoNormal();
			if(m_selectMusicData.IFNPBIJEPBO_IsDlded)
			{
				ChangeTrialMusic(m_selectMusicData.KKPAHLMJKIH_WavId);
			}
			else
			{
				FadeOutBGM();
			}
		}

		// // RVA: 0x9F0950 Offset: 0x9F0950 VA: 0x9F0950
		private void SaveDifficulty()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.JGAFBCMOGLP_Raid.HJHBGHMNGKL_SetDifficulty(diff);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// // RVA: 0x9EF69C Offset: 0x9EF69C VA: 0x9EF69C
		private bool IsEndRaidEvent()
		{
			raidController.HCDGELDHFHB_UpdateStatus(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			if(raidController.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.DNABPEOICIJ(() =>
				{
					//0x144571C
					MenuScene.Instance.MountWithFade(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}, false);
				return true;
			}
			return false;
		}

		// // RVA: 0x9F0CA8 Offset: 0x9F0CA8 VA: 0x9F0CA8
		private void InitPopupSettings()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
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
		}

		// RVA: 0x9F10A4 Offset: 0x9F10A4 VA: 0x9F10A4 Slot: 28
		protected override TransitionArgs GetCallArgsReturn()
		{
			return new EventMusicSelectSceneArgs(raidController.PGIIDPEGGPI_EventId, m_isLine6Mode, false);
		}
	}
}
