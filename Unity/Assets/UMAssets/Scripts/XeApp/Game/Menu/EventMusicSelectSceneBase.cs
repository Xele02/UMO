using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.uGUI;

namespace XeApp.Game.Menu
{
	public abstract class EventMusicSelectSceneBase : TransitionRoot
	{
		protected struct RankingRequestInfo
		{
			public OHCAABOMEOF.KGOGMKMBCPP_EventType type; // 0x0
			public int index; // 0x4

			// RVA: 0x7FAE6C Offset: 0x7FAE6C VA: 0x7FAE6C
			public RankingRequestInfo(OHCAABOMEOF.KGOGMKMBCPP_EventType type, int index)
			{
				this.type = type;
				this.index = index;
			}
		}

		protected struct NetProcessSetting
		{
			public List<RankingRequestInfo> rankingRequestInfos; // 0x0

			// RVA: 0x7FAE64 Offset: 0x7FAE64 VA: 0x7FAE64
			public void AddRankingRequest(OHCAABOMEOF.KGOGMKMBCPP_EventType type, int index)
			{
				if(rankingRequestInfos == null)
					rankingRequestInfos = new List<RankingRequestInfo>();
				rankingRequestInfos.Add(new RankingRequestInfo(type, index));
			}
		}

		protected struct MusicDecideInfo
		{
			public long overrideCurrentTime; // 0x0
			public string missionText; // 0x8
			public int overrideEnemyCenterSkill; // 0xC
			public int overrideEnemyLiveSkill; // 0x10
			public GameSetupData.MusicInfo.InitFreeMusicParam initParam; // 0x14
			public static MusicDecideInfo Empty = new MusicDecideInfo(0, "", 0, 0); // 0x0

			// RVA: 0x7FADD0 Offset: 0x7FADD0 VA: 0x7FADD0
			public MusicDecideInfo(long overrideCurrentTime, string missionText, int overrideEnemyCenterSkill, int overrideEnemyLiveSkill)
			{
				this.overrideCurrentTime = overrideCurrentTime;
				this.missionText = missionText;
				this.overrideEnemyCenterSkill = overrideEnemyCenterSkill;
				this.overrideEnemyLiveSkill = overrideEnemyLiveSkill;
				initParam.returnTransitionUniqueId = 0;
				initParam.isDisableBattleEventIntermediateResult = false;
			}
		}

		protected struct EventHelpInfo
		{
			public List<int> helpIds; // 0x0
			public bool isShowFirstHelp; // 0x4
		}

		private class PlayButton : PlayButtonWrapper
		{
			public override MusicSelectCDSelect baseUI { get; protected set; } // 0x8

			// RVA: 0xB8AE20 Offset: 0xB8AE20 VA: 0xB8AE20
			public PlayButton(MusicSelectCDSelect ui)
			{
				baseUI = ui;
			}

			// RVA: 0xB8AE54 Offset: 0xB8AE54 VA: 0xB8AE54 Slot: 6
			public override void Enter(bool immediate/* = False*/)
			{
				baseUI.EnterPlayButton(immediate);
			}

			// RVA: 0xB8AE98 Offset: 0xB8AE98 VA: 0xB8AE98 Slot: 7
			public override void Leave(bool immediate/* = False*/)
			{
				baseUI.LeavePlayButton(immediate);
			}

			// RVA: 0xB8AEDC Offset: 0xB8AEDC VA: 0xB8AEDC Slot: 8
			public override void SetDisable(bool disable)
			{
				baseUI.SetPlayButtonDisable(disable);
			}

			// RVA: 0xB8AF20 Offset: 0xB8AF20 VA: 0xB8AF20 Slot: 9
			public override void SetType(Type type)
			{
				switch(type)
				{
					case Type.PlayEn:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.PlayEn);
						break;
					case Type.Play:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Play);
						break;
					case Type.Event:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Event);
						break;
					case Type.Download:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Download);
						break;
					case Type.Live:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Live);
						break;
					case Type.Ok:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Ok);
						break;
				}
			}

			// RVA: 0xB8B080 Offset: 0xB8B080 VA: 0xB8B080 Slot: 10
			public override void SetNeedEnergy(int en)
			{
				baseUI.SetNeedEnergy(en);
			}
		}

		private PopupAchieveRewardSetting m_rewardPopupSetting = new PopupAchieveRewardSetting(); // 0x64
		private bool m_isConfirmedUnitDance; // 0x68
		private MusicDecideInfo m_musicDecideInfo = MusicDecideInfo.Empty; // 0x70
		private PopupUnitDanceWarning m_popupUnitDanceWarning = new PopupUnitDanceWarning(); // 0x90
		private bool m_showTicketGainedPopup; // 0x94
		private bool m_loadingTicketGainedPopup; // 0x95
		private TicketGainedPopupSetting m_ticketGainedPopupSetting; // 0x98
		private TeamSlectSceneArgs m_teamSelectSceneArgs = new TeamSlectSceneArgs(); // 0x9C
		private List<Action> NoticeActionList = new List<Action>(); // 0xA0

		protected abstract int list_no { get; } //Slot: 31
		protected abstract Difficulty.Type diff { get; } // Slot: 32
		protected abstract int musicListCount { get; } // Slot: 33
		protected abstract MusicDataList currentMusicList { get; } // Slot: 35
		protected abstract bool isLine6ModeFlag { get; } // Slot: 36
		protected bool m_isEndPreSetCanvas { get; private set; } = true; // 0x45 0x13B8B94 0x13B8B9C
		protected bool m_isEndPostSetCanvas { get; private set; } = true; // 0x46 0x13B8BA4 0x13B8BAC
		protected bool m_isEndActivateScene { get; private set; } = true; // 0x47 0x13B8BB4 0x13B8BBC
		protected MMOLNAHHDOM m_unitLiveLocalSaveData { get; private set; } // 0x48 0x13AD7B8 0x13B8BC4
		protected LimitTimeWatcher m_bannerTimeWatcher { get; private set; } = new LimitTimeWatcher(); // 0x4C 0x13B8BCC 0x13B8BD4
		protected IKDICBBFBMI_EventBase m_eventCtrl { get; private set; } // 0x50 0x13AA058 0x13B8BDC
		protected int m_eventId { get; private set; } // 0x54 0x13AAFDC 0x13B8BE4
		protected KGCNCBOKCBA.GNENJEHKMHD_EventStatus m_eventStatus { get; private set; } // 0x58 0x13AAFD4 0x13B8BEC
		protected bool m_isEventTimeLimit { get; private set; } // 0x5C 0x13B8BF4 0x13B8BFC
		protected int m_eventTicketId { get; private set; } // 0x60 0x13AD7C0 0x13B8C04
		protected IBJAKJJICBC selectMusicData { get
		{
			return list_no < currentMusicList.GetCount(isLine6ModeFlag, false) ? currentMusicList.Get(list_no, isLine6ModeFlag, false) : null;
		} } //0x13AAEC8
		protected bool listIsEmpty { get { return currentMusicList.GetCount(isLine6ModeFlag, false) < 1; } } //0x13B0674
		protected bool isExistSelectMusicData { get { return list_no >= 0 && list_no < currentMusicList.GetCount(isLine6ModeFlag, false); } } //0x13B8C0C
		protected int musicId { get { return listIsEmpty ? 0 : selectMusicData.DLAEJOBELBH_MusicId; } } //0x13B8CBC
		protected int freeMusicId { get { return listIsEmpty ? 0 : selectMusicData.GHBPLHBNMBK_FreeMusicId; } } //0x13B8D04
		protected int gameEventType { get { return listIsEmpty ? 0 : selectMusicData.MNNHHJBBICA_GameEventType; } } //0x13B8D4C

		// // RVA: -1 Offset: -1 Slot: 34
		protected abstract MusicDataList GetMusicList(int index);

		// RVA: 0x13B8D94 Offset: 0x13B8D94 VA: 0x13B8D94 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_Awake());
		}

		// RVA: 0x13B8E50 Offset: 0x13B8E50 VA: 0x13B8E50 Slot: 16
		protected override void OnPreSetCanvas()
		{
			this.StartCoroutineWatched(Co_OnPreSetCanvasInternal());
		}

		// RVA: 0x13B8F00 Offset: 0x13B8F00 VA: 0x13B8F00 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && m_isEndPreSetCanvas;
		}

		// RVA: 0x13B8FBC Offset: 0x13B8FBC VA: 0x13B8FBC Slot: 18
		protected override void OnPostSetCanvas()
		{
			this.StartCoroutineWatched(Co_OnPostSetCanvasInternal());
		}

		// RVA: 0x13B906C Offset: 0x13B906C VA: 0x13B906C Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isEndPostSetCanvas;
		}

		// RVA: 0x13B9074 Offset: 0x13B9074 VA: 0x13B9074 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnActivateSceneInternal());
		}

		// RVA: 0x13B9124 Offset: 0x13B9124 VA: 0x13B9124 Slot: 24
		protected override bool IsEndActivateScene()
		{
			return m_isEndActivateScene;
		}

		// RVA: 0x13B912C Offset: 0x13B912C VA: 0x13B912C Slot: 20
		protected override bool OnBgmStart()
		{
			DelayedApplyMusicInfo();
			return true;
		}

		// RVA: 0x13B914C Offset: 0x13B914C VA: 0x13B914C
		private void Update()
		{
			m_bannerTimeWatcher.Update();
			OnUpdate();
		}

		// RVA: 0x13B9190 Offset: 0x13B9190 VA: 0x13B9190 Slot: 14
		protected override void OnDestoryScene()
		{
			ReleaseScene();
			m_unitLiveLocalSaveData.HJMKBCFJOOH_Write();
		}

		// RVA: 0x13B91D8 Offset: 0x13B91D8 VA: 0x13B91D8 Slot: 15
		protected override void OnDeleteCache()
		{
			ReleaseCache();
			if(m_popupUnitDanceWarning != null)
				m_popupUnitDanceWarning.Release();
		}

		// RVA: 0x13B9210 Offset: 0x13B9210 VA: 0x13B9210 Slot: 30
		protected override void InputDisable()
		{
			OnInputDisable();
		}

		// RVA: 0x13B923C Offset: 0x13B923C VA: 0x13B923C Slot: 29
		protected override void InputEnable()
		{
			OnInputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EF6BC Offset: 0x6EF6BC VA: 0x6EF6BC
		// // RVA: 0x13B8DC4 Offset: 0x13B8DC4 VA: 0x13B8DC4
		private IEnumerator Co_Awake()
		{
			//0x13C015C
			SetupEventTicket();
			yield return Co.R(Co_LoadLayoutOnAwake());
			yield return Co.R(Co_LoadAssetBundle_LoginBonusPopup());
			m_rewardPopupSetting.SetParent(transform);
			while(m_loadingTicketGainedPopup)
				yield return null;
			yield return Co.R(Co_WaitForLoaded());
			IsReady = true;
		}

		// // RVA: -1 Offset: -1 Slot: 37
		protected abstract IEnumerator Co_LoadLayoutOnAwake();

		// // RVA: -1 Offset: -1 Slot: 38
		protected abstract IEnumerator Co_WaitForLoaded();

		// [IteratorStateMachineAttribute] // RVA: 0x6EF734 Offset: 0x6EF734 VA: 0x6EF734
		// // RVA: 0x13B8E74 Offset: 0x13B8E74 VA: 0x13B8E74
		protected IEnumerator Co_OnPreSetCanvasInternal()
		{
			//0x13C4128
			m_isEndPreSetCanvas = false;
			LoadUnitLiveSaveData();
			this.StartCoroutineWatched(Co_SetupEventControler());
			if(!m_isEventTimeLimit)
			{
				yield return Co.R(Co_OnPreSetCanvas());
			}
			m_isEndPreSetCanvas = true;
		}

		// // RVA: -1 Offset: -1 Slot: 39
		protected abstract IEnumerator Co_OnPreSetCanvas();

		// [IteratorStateMachineAttribute] // RVA: 0x6EF7AC Offset: 0x6EF7AC VA: 0x6EF7AC
		// // RVA: 0x13B8FE0 Offset: 0x13B8FE0 VA: 0x13B8FE0
		protected IEnumerator Co_OnPostSetCanvasInternal()
		{
			//0x13C3FBC
			m_isEndPostSetCanvas = false;
			if(!m_isEventTimeLimit && !IsRequestGotoTitle)
			{
				yield return Co.R(Co_OnPostSetCanvas());
			}
			m_isEndPostSetCanvas = true;
		}

		// // RVA: -1 Offset: -1 Slot: 40
		protected abstract IEnumerator Co_OnPostSetCanvas();

		// [IteratorStateMachineAttribute] // RVA: 0x6EF824 Offset: 0x6EF824 VA: 0x6EF824
		// // RVA: 0x13B9098 Offset: 0x13B9098 VA: 0x13B9098
		private IEnumerator Co_OnActivateSceneInternal()
		{
			//0x13C3E64
			m_isEndActivateScene = false;
			if(!m_isEventTimeLimit)
			{
				yield return Co.R(Co_OnActivateScene());
			}
			m_isEndActivateScene = true;
		}

		// // RVA: -1 Offset: -1 Slot: 41
		protected abstract IEnumerator Co_OnActivateScene();

		// // RVA: -1 Offset: -1 Slot: 42
		protected abstract void OnUpdate();

		// // RVA: -1 Offset: -1 Slot: 43
		protected abstract void ReleaseScene();

		// // RVA: -1 Offset: -1 Slot: 44
		protected abstract void ReleaseCache();

		// // RVA: -1 Offset: -1 Slot: 45
		protected abstract void OnInputDisable();

		// // RVA: -1 Offset: -1 Slot: 46
		protected abstract void OnInputEnable();

		// // RVA: 0x13B92E8 Offset: 0x13B92E8 VA: 0x13B92E8
		private void SetupEventTicket()
		{
			NKOBMDPHNGP_EventRaidLobby raidEv = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			if(raidEv != null)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "SetupEventTicket");
			}
		}

		// // RVA: 0x13B9438 Offset: 0x13B9438 VA: 0x13B9438
		private void LoadUnitLiveSaveData()
		{
			m_unitLiveLocalSaveData = new MMOLNAHHDOM();
			m_unitLiveLocalSaveData.PCODDPDFLHK_Read();
			m_isConfirmedUnitDance = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EF89C Offset: 0x6EF89C VA: 0x6EF89C
		// // RVA: 0x13B94CC Offset: 0x13B94CC VA: 0x13B94CC
		private IEnumerator Co_SetupEventControler()
		{
			//0x13C42E8
			EventMusicSelectSceneArgs Arg = Args as EventMusicSelectSceneArgs;
			EventMusicSelectSceneArgs ArgRet = ArgsReturn as EventMusicSelectSceneArgs;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_eventCtrl = null;
			if(Arg != null)
			{
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(Arg.EventUniqueId);
			}
			else if(ArgRet != null)
			{
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(ArgRet.EventUniqueId);
			}
			else
			{
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(m_eventId);
			}
			if(m_eventCtrl != null)
			{
				m_eventCtrl.HCDGELDHFHB_UpdateStatus(t);
				m_eventId = m_eventCtrl.PGIIDPEGGPI_EventId;
				m_eventStatus = m_eventCtrl.NGOFCFJHOMI_Status;
			}
			if(MenuScene.Instance.CheckEventLimit(m_eventCtrl, false, true))
			{
				GameManager.Instance.fullscreenFader.Fade(0, Color.black);
				while(!PopupWindowManager.IsActivePopupWindow())
					yield return null;
				while(PopupWindowManager.IsActivePopupWindow())
					yield return null;
				AutoFadeFlag = false;
				m_isEventTimeLimit = true;
			}
			if(m_eventCtrl != null)
			{
				OnEventControlerSetuped(m_eventCtrl, m_eventId, m_eventStatus, m_isEventTimeLimit);
			}
		}

		// // RVA: -1 Offset: -1 Slot: 47
		protected abstract void OnEventControlerSetuped(IKDICBBFBMI_EventBase eventCtrl, int eventId, KGCNCBOKCBA.GNENJEHKMHD_EventStatus eventStatus, bool isEventTimeLimit);

		// [IteratorStateMachineAttribute] // RVA: 0x6EF914 Offset: 0x6EF914 VA: 0x6EF914
		// // RVA: 0x13AD374 Offset: 0x13AD374 VA: 0x13AD374
		protected IEnumerator PreEnterNetProcess(NetProcessSetting setting, Action onError)
		{
			//0x13C5A60
			bool done = false;
			bool err = false;
			m_eventCtrl.ADACMHAHHKC_PreSetupEventHome(() =>
			{
				//0x13BFB78
				done = true;
			}, () =>
			{
				//0x13BFB84
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(!err)
			{
				if(setting.rankingRequestInfos != null)
				{
					foreach(var r in setting.rankingRequestInfos)
					{
						done = false;
						err = false;
						JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LFOBIPKFOEF(r.type, r.index, () =>
						{
							//0x13BFB90
							done = true;
						}, () =>
						{
							//0x13BFB9C
							done = true;
							err = true;
						}, false);
						while(!done)
							yield return null;
						if(err)
						{
							if(onError != null)
								onError();
							yield break;
						}
					}
				}
				//LAB_013c5fa0
				done = false;
				err = false;
				CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
				{
					//0x13BFBA8
					done = true;
				}, () =>
				{
					//0x13BFBB4
					done = true;
					err = true;
				}, null);
				while(!done)
					yield return null;
				if(!err)
				{
					yield break;
				}
			}
			if(onError != null)
				onError();
		}

		// // RVA: 0x13AD434 Offset: 0x13AD434 VA: 0x13AD434
		protected static void SetupEventHelpInfo(ref EventHelpInfo helpInfo, IKDICBBFBMI_EventBase eventCtrl)
		{
			helpInfo.helpIds = new List<int>(2);
			if(!eventCtrl.BELBNINIOIE)
			{
				if(eventCtrl.CMPEJEHCOEI)
				{
					int id = eventCtrl.HLOGNJNGDJO_GetHelpId(eventCtrl.NJHPPOFBCMA() ? 1 : 0);
					if(id > 0)
						helpInfo.helpIds.Add(id);
				}
			}
			else
			{
				if(eventCtrl.CMPEJEHCOEI)
				{
					int id = eventCtrl.HLOGNJNGDJO_GetHelpId(eventCtrl.NJHPPOFBCMA() ? 1 : 0);
					if(id > 0)
						helpInfo.helpIds.Add(id);
				}
				if(eventCtrl.LPFJADHHLHG)
				{
					int id = eventCtrl.HLOGNJNGDJO_GetHelpId(2);
					if(id > 0)
						helpInfo.helpIds.Add(id);
				}
			}
			if(eventCtrl.GHAFMPBPJME())
			{
				if(eventCtrl.OGPMLMDPGJA > 0)
				{
					helpInfo.helpIds.Add(eventCtrl.OGPMLMDPGJA);
				}
			}
			helpInfo.isShowFirstHelp = true;
			if(!eventCtrl.CMPEJEHCOEI)
			{
				if(!eventCtrl.LPFJADHHLHG)
				{
					helpInfo.isShowFirstHelp = eventCtrl.GHAFMPBPJME();
				}
			}
			eventCtrl.LPFJADHHLHG = false;
			eventCtrl.CMPEJEHCOEI = false;
			eventCtrl.MMIMJPNLKBK();
		}

		// // RVA: 0x13B9598 Offset: 0x13B9598 VA: 0x13B9598
		// protected static PlayButtonWrapper CreatePlayButtonWrapper(MusicSelectCDSelect cdSelect) { }

		// // RVA: 0x13AED40 Offset: 0x13AED40 VA: 0x13AED40
		protected static void TryInstallMusicPict(StringBuilder bundleName, MusicDataList musicList, bool isLine6Mode)
		{
			for(int i = 0; i < musicList.GetCount(isLine6Mode, false); i++)
			{
				IBJAKJJICBC ib = musicList.Get(i, isLine6Mode, false);
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
				TryInstall(bundleName);
			}
		}

		// // RVA: 0x13AEC74 Offset: 0x13AEC74 VA: 0x13AEC74
		protected static void TryInstall(StringBuilder bundleName)
		{
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(bundleName.ToString());
		}

		// // RVA: 0x13B960C Offset: 0x13B960C VA: 0x13B960C
		// protected static void ChangeLineMode(int style, out bool outIsLine6Mode) { }

		// // RVA: 0x13B977C Offset: 0x13B977C VA: 0x13B977C
		protected static void ApplyBasicInfo(MusicSelectCDSelect cdSelect, MusicSelectCDArrow cdArrow, MusicSelectEventBanner eventBanner, MusicSelectMusicRate musicRate)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(eventBanner != null)
			{
				eventBanner.SetMusicEventRemainPrefix(bk.GetMessageByLabel("music_event_remain_prefix"));
			}
			cdSelect.ApplyEventRemainTimePrefix(bk.GetMessageByLabel("music_event_remain_prefix"));
			cdArrow.SetStyle(MusicSelectCDArrow.Style.Default);
			GHLGEECLCMH g = new GHLGEECLCMH();
			g.KHEKNNFCAOI(null, null);
			if(musicRate != null)
			{
				musicRate.ApplyHighScoreRating(g.LLNHMMBFPMA_ScoreRatingRanking, g.ECMFBEHEGEH_UtaRateTotal);
				musicRate.onClickButton = () =>
				{
					//0x13BF318
					GameManager.Instance.CloseSnsNotice();
					GameManager.Instance.CloseOfferNotice();
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					MenuScene.Instance.Call(TransitionList.Type.MUSIC_RATE, null, true);
				};
			}
		}

		// // RVA: -1 Offset: -1 Slot: 48
		protected abstract void ApplyMusicListInfo();

		// // RVA: -1 Offset: -1 Slot: 49
		protected abstract void ApplyMusicInfo();

		// // RVA: -1 Offset: -1 Slot: 50
		protected abstract void DelayedApplyMusicInfo();

		// // RVA: 0x13B9AD8 Offset: 0x13B9AD8 VA: 0x13B9AD8
		private void ApplyUnitLiveButtonSetting(bool isUnit)
		{
			m_unitLiveLocalSaveData.IAGAAOKODPM_SetMultiDiva(selectMusicData.GHBPLHBNMBK_FreeMusicId, isUnit);
			OnApplyUnitLiveButtonSetting(isUnit);
		}

		// // RVA: -1 Offset: -1 Slot: 51
		protected abstract void OnApplyUnitLiveButtonSetting(bool isUnit);

		// // RVA: 0x13B9B54 Offset: 0x13B9B54 VA: 0x13B9B54
		protected static void ApplyEventBannerRemainTime(MusicSelectEventBanner eventBanner, long remainSec, bool makeColor)
		{
			int d, h, m, s;
			MusicSelectSceneBase.ExtractRemainTime((int)remainSec, out d, out h, out m, out s);
			string str = MusicSelectSceneBase.MakeRemainTime(d, h, m, s);
			if(makeColor)
				str = RichTextUtility.MakeColorTagString(str, SystemTextColor.ImportantColor);
			eventBanner.SetLimitTimeLabel(str);
		}

		// // RVA: 0x13AB324 Offset: 0x13AB324 VA: 0x13AB324
		protected void DownloadCurrentMusic()
		{
			m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
			this.StartCoroutineWatched(Co_DownloadMusic(selectMusicData));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EF98C Offset: 0x6EF98C VA: 0x6EF98C
		// // RVA: 0x13B9CA8 Offset: 0x13B9CA8 VA: 0x13B9CA8
		private IEnumerator Co_DownloadMusic(IBJAKJJICBC musicData)
		{
			UGUIFader fader; // 0x18
			TipsControl tipsCtrl; // 0x1C
			int musicId; // 0x20
			ILCCJNDFFOB lw; // 0x24
			float pre; // 0x28

			//0x13C28AC
			fader = GameManager.Instance.fullscreenFader;
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
			int vQual = 0;
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PMGMMMGCEEI_Video == 0)
			{
				vQual = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CBLEFELBNDN_GetVideoQuality();
			}
			KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP = 0;
			lw = ILCCJNDFFOB.HHCJCDFCLOB;
			pre = 0;
			KDLPEDBKMID.HHCJCDFCLOB.OKJCGCOGDIA_DownloadSongDatas(musicData.KKPAHLMJKIH_WavId, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(musicId).KEFGPJBKAOD_WavId, 
				vQual, GetDanceDivaCount());
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
			{
				if(pre < 50)
				{
					if(KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP >= 50)
					{
						lw.OJOLFJGNEMO(1, musicId);
					}
				}
				pre = KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP;
				yield return null;
			}
			lw.OJOLFJGNEMO(2, musicId);
			for(int i = 0; i < musicListCount; i++)
			{
				GetMusicList(i).UpdateDownloadState(musicId);
			}
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
			fader.Fade(0.5f, 0);
			tipsCtrl.Close();
			while(fader.isFading)
				yield return null;
			while(tipsCtrl.isPlayingAnime())
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x13B9D70 Offset: 0x13B9D70 VA: 0x13B9D70
		protected static void CheckSnsNotice()
		{
			if(!BIFNGFAIEIL.HHCJCDFCLOB.DNFPMBFNDCA())
				return;
			int id = BIFNGFAIEIL.HHCJCDFCLOB.FGGDEKAJCIF();
			if(id == 0)
				return;
			MenuScene.Instance.ShowSnsNotice(id, null);
			BIFNGFAIEIL.HHCJCDFCLOB.ALIANOFCAEI();
		}

		// // RVA: 0x13B9EB8 Offset: 0x13B9EB8 VA: 0x13B9EB8
		protected static void CheckOfferNotice()
		{
			if(KDHGBOOECKC.HHCJCDFCLOB.IOCBOGFFHFE.OAFPGJLCNFM_Cond == BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0)
				return;
			MenuScene.Instance.ShowOfferNotice(null);
		}

		// // RVA: 0x13AA228 Offset: 0x13AA228 VA: 0x13AA228
		protected void AddNotice(Action action)
		{ 
			NoticeActionList.Add(action);
		}

		// // RVA: 0x13AA2A8 Offset: 0x13AA2A8 VA: 0x13AA2A8
		protected void ShowNotice()
		{
			this.StartCoroutineWatched(Co_ShowNotice());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EFA04 Offset: 0x6EFA04 VA: 0x6EFA04
		// // RVA: 0x13B9FA0 Offset: 0x13B9FA0 VA: 0x13B9FA0
		private IEnumerator Co_ShowNotice()
		{
			int i;

			//0x13C4CBC
			for(i = 0; i < NoticeActionList.Count; i++)
			{
				NoticeActionList[i]();
				GameManager.Instance.snsNotification.DirtyClose = false;
				while(GameManager.Instance.snsNotification.isActiveAndEnabled)
					yield return null;
				if(GameManager.Instance.snsNotification.DirtyClose)
					break;
			}
			NoticeActionList.Clear();
		}

		// // RVA: 0x13BA04C Offset: 0x13BA04C VA: 0x13BA04C
		private void CheckBoostData(Action endCallback, Action cancelCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_CheckBoostData(endCallback, cancelCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EFA7C Offset: 0x6EFA7C VA: 0x6EFA7C
		// // RVA: 0x13BA10C Offset: 0x13BA10C VA: 0x13BA10C
		private IEnumerator Co_CheckBoostData(Action endCallback, Action cancelCallback)
		{
			MKIKFJKPEHK viewBoostData;

			//0x13C05C0
			Database.Instance.gameSetup.ResetSelectedDashIndex();
			if(m_eventCtrl != null)
				m_eventCtrl.OJGHCKMPJFP();
			viewBoostData = new MKIKFJKPEHK();
			if(viewBoostData.DPICLLJJPAC(selectMusicData, (int)diff, isLine6ModeFlag))
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				//selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].BPLOEAHOPFI_Energy;
				string str1 = "popup_dash_energy_title";
				if(viewBoostData.NMKDLINPAFM_UseTicket)
				{
					str1 = "popup_dash_ticket_title";
				}
				PopupDashContentSetting.InitParam[] p = new PopupDashContentSetting.InitParam[viewBoostData.KLOOIJIDKGO_Cost.Count];
				for(int i = 0; i < viewBoostData.KLOOIJIDKGO_Cost.Count; i++)
				{
					p[i] = new PopupDashContentSetting.InitParam();
					p[i].Rate = viewBoostData.BGIKOPLLDJB_Rate[i];
					p[i].Cost = viewBoostData.KLOOIJIDKGO_Cost[i];
				}
				PopupDashContentSetting s = new PopupDashContentSetting();
				s.EventId = m_eventId;
				s.CostType = viewBoostData.NMKDLINPAFM_UseTicket ? LayoutPopupDash.CostType.Ticket : LayoutPopupDash.CostType.Energy;
				s.OwnValue = viewBoostData.DCLKMNGMIKC();
				s.Param = p;
				s.WindowSize = SizeType.Middle;
				s.TitleText = bk.GetMessageByLabel(str1);
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Play, Type = PopupButton.ButtonType.Live }
				};
				s.OnSelectCallback = (int index) =>
				{
					//0x13BF494
					Database.Instance.gameSetup.SetSelectedDashIndex(index);
				};
				bool cancel = false;
				bool done = false;
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x13BFBC8
					if(type == PopupButton.ButtonType.Negative)
						cancel = true;
				}, null, null, null, true, true, false, null, () =>
				{
					//0x13BFBD8
					done = true;
				});
				//LAB_013c1090
				while(!done)
					yield return null;
				if(cancel)
				{
					if(cancelCallback != null)	
						cancelCallback();
					yield break;
				}
				MenuScene.Instance.InputEnable();
				viewBoostData.PPCLCOPGBBK(Database.Instance.gameSetup.SelectedDashIndex);
				if(CurrentMusicDecideProcess(cancelCallback, viewBoostData, Database.Instance.gameSetup.SelectedDashIndex))
				{
					if(endCallback != null)
						endCallback();
				}
				while(MenuScene.Instance.DirtyChangeScene)
					yield return null;
				MenuScene.Instance.InputEnable();
			}
			else
			{
				if(!CurrentMusicDecideProcess(cancelCallback, null, 0))
					yield break;
				if(endCallback != null)
					endCallback();
			}
		}

		// // RVA: -1 Offset: -1 Slot: 52
		protected abstract int GetDanceDivaCount();

		// // RVA: -1 Offset: -1 Slot: 53
		protected abstract IEnumerator OnPreDecideMusicCheck(IBJAKJJICBC musicData, Action onDecideCancel);

		// // RVA: 0x13BA1EC Offset: 0x13BA1EC VA: 0x13BA1EC
		private void CheckUnitLive(Action endCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_CheckUnitLive(endCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EFAF4 Offset: 0x6EFAF4 VA: 0x6EFAF4
		// // RVA: 0x13BA2A4 Offset: 0x13BA2A4 VA: 0x13BA2A4
		private IEnumerator Co_CheckUnitLive(Action endCallback)
		{
			int danceDivaCount; // 0x24
			bool isUnitOnly; // 0x28
			UnityAction<bool> positiveAction; // 0x2C
			UnityAction<bool> negativeAction; // 0x30
			UnityAction toggleAction; // 0x34
			GameManager.PushBackButtonHandler handler; // 0x38

			//0x13C13B4
			bool isCancel = false;
			yield return Co.R(OnPreDecideMusicCheck(selectMusicData, () =>
			{
				//0x13BFBEC
				isCancel = true;
			}));
			if(isCancel)
				yield break;
			danceDivaCount = GetDanceDivaCount();
			if(danceDivaCount > 1)
			{
				int v = 0;
				for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
				{
					v += CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_Have;
				}
				if(v < danceDivaCount)
				{
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					bool done = false;
					PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, string.Format(bk.GetMessageByLabel("unit_multi_dance_popup_03"), danceDivaCount), new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x13BF52C
						return;
					}, null, null, null, true, true, false, null, () =>
					{
						//0x13BFC08
						done = true;
					});
					//LAB_013c1a0c
					while(!done)
						yield return null;
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
					isUnitOnly = (selectMusicData.BNCMJNMIDIN_AvaiableDivaModes & 1) == 0;
					m_popupUnitDanceWarning.WarningWindow.Initialize(danceDivaCount, isUnitOnly);
					m_popupUnitDanceWarning.WarningWindow.transform.SetAsLastSibling();
					m_popupUnitDanceWarning.WarningWindow.Show();
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_000);
					//LAB_013c1bf0
					while(m_popupUnitDanceWarning.WarningWindow.IsPlaying())
						yield return null;
					bool done = false;
					positiveAction = (bool isOn) =>
					{
						//0x13BFC1C
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
						saveData.KBAMKMDJMJC_DisableWarning = isOn;
						done = true;
					};
					negativeAction = (bool isOn) =>
					{
						//0x13BFCB0
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
						ApplyUnitLiveButtonSetting(false);
						saveData.KBAMKMDJMJC_DisableWarning = isOn;
						done = true;
					};
					toggleAction = () =>
					{
						//0x13BF530
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					};
					m_popupUnitDanceWarning.WarningWindow.PositiveListener += positiveAction;
					m_popupUnitDanceWarning.WarningWindow.NegativeListener += negativeAction;
					m_popupUnitDanceWarning.WarningWindow.ToggleButtonListener += toggleAction;
					handler = () =>
					{
						//0x13BF588
						return;
					};
					if(isUnitOnly)
					{
						handler = UnitDanceOnlyBackButton;
					}
					GameManager.Instance.AddPushBackButtonHandler(handler);
					MenuScene.Instance.InputEnable();
					//LAB_013c2024
					while(!done)
						yield return null;
					MenuScene.Instance.InputDisable();
					m_popupUnitDanceWarning.WarningWindow.PositiveListener -= positiveAction;
					m_popupUnitDanceWarning.WarningWindow.NegativeListener -= negativeAction;
					m_popupUnitDanceWarning.WarningWindow.ToggleButtonListener -= toggleAction;
					GameManager.Instance.RemovePushBackButtonHandler(handler);
					m_popupUnitDanceWarning.WarningWindow.Close();
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_001);
					//LAB_013c227c
					while(m_popupUnitDanceWarning.WarningWindow.IsPlaying())
						yield return null;
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
					m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
					MenuScene.Instance.InputEnable();
					m_isConfirmedUnitDance = true;
				}
            }
			//LAB_013c23e8
			if(endCallback != null)
				endCallback();
		}

		// // RVA: 0x13BA36C Offset: 0x13BA36C VA: 0x13BA36C
		private void UnitDanceOnlyBackButton()
		{
			m_popupUnitDanceWarning.WarningWindow.PerformClickOk();
		}

		// // RVA: 0x13BA3B8 Offset: 0x13BA3B8 VA: 0x13BA3B8
		protected void DecideCurrentMusic()
		{
			m_musicDecideInfo = MusicDecideInfo.Empty;
			if(selectMusicData.OEILJHENAHN_PlayEventType == 10)
			{
				m_musicDecideInfo.overrideEnemyCenterSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.DCOALMMJDJK_OverrideCenterSkill;
				m_musicDecideInfo.overrideEnemyLiveSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.KKPLDFNDFDE_OverrideLiveSkill;
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(selectMusicData.EKANGPODCEP_EventId);
			}
			OnDecideCurrentMusic(ref m_musicDecideInfo);
			Database.Instance.gameSetup.musicInfo.SetupInfoByFreeMusic(freeMusicId, diff, !selectMusicData.MNDFBBMNJGN_NoEnergy, m_musicDecideInfo.initParam, (OHCAABOMEOF.KGOGMKMBCPP_EventType) selectMusicData.MNNHHJBBICA_GameEventType, 
				(OHCAABOMEOF.KGOGMKMBCPP_EventType) selectMusicData.MFJKNCACBDG_OpenEventType, (OHCAABOMEOF.KGOGMKMBCPP_EventType) selectMusicData.OEILJHENAHN_PlayEventType, false, isLine6ModeFlag, m_musicDecideInfo.missionText, m_musicDecideInfo.overrideEnemyCenterSkill, 
				m_musicDecideInfo.overrideEnemyLiveSkill, selectMusicData.ALMOMLMCHNA_OtherEndTime, selectMusicData.IHPCKOMBGKJ_End, m_eventCtrl != null ? m_eventCtrl.PGIIDPEGGPI_EventId : 0, 
				GetDanceDivaCount(), m_musicDecideInfo.overrideCurrentTime);
			Database.Instance.selectedMusic.SetMusicData(selectMusicData);
			if(selectMusicData.MNNHHJBBICA_GameEventType == 3)
			{
				MenuScene.Instance.Call(TransitionList.Type.TEAM_SELECT, m_teamSelectSceneArgs, true);
			}
			else if(selectMusicData.MNNHHJBBICA_GameEventType == 14)
			{
				MenuScene.Instance.Call(TransitionList.Type.GODIVA_TEAM_SELECT, m_teamSelectSceneArgs, true);
			}
			else
			{
				MenuScene.Instance.Call(TransitionList.Type.FRIEND_SELECT, null, true);
			}
		}

		// // RVA: -1 Offset: -1 Slot: 54
		protected abstract bool CurrentMusicDecideProcess(Action cancelCallback, MKIKFJKPEHK viewBoostData, int selectIndex/* = 0*/);

		// // RVA: -1 Offset: -1 Slot: 55
		protected abstract void OnDecideCurrentMusic(ref MusicDecideInfo info);

		// // RVA: 0x13BAB00 Offset: 0x13BAB00 VA: 0x13BAB00
		private void OnCancelDecideMusic()
		{
			m_isConfirmedUnitDance = false;
		}

		// // RVA: 0x13BAB0C Offset: 0x13BAB0C VA: 0x13BAB0C
		protected static void GotoEventMusicSelect(int eventId, bool isLine6Mode)
		{
			if(eventId > 0)
			{
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventId);
				if(ev != null && ev.FBLGGLDPFDF_CanShowStartAdventure())
				{
					GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(ev.GFIBLLLHMPD_StartAdventureId);
					if(adv != null)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(ev.GFIBLLLHMPD_StartAdventureId);
						ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(ev.GFIBLLLHMPD_StartAdventureId, OAGBCBBHMPF.DKAMMIHBINF.IDINJDEBPKP_6);
						Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
						Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTMUSICSELECT, new AdvSetupParam() { eventUniqueId = eventId });
						MenuScene.Instance.GotoAdventure(false);
						return;
					}
				}
            }
			MenuScene.Instance.Mount(TransitionUniqueId.EVENTMUSICSELECT, new EventMusicSelectSceneArgs(eventId, isLine6Mode, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x13BAF64 Offset: 0x13BAF64 VA: 0x13BAF64
		protected void GotoMiniGame(int miniGameId)
		{
			MenuScene.Instance.GotoMiniGame(miniGameId);
		}

		// // RVA: 0x13BB008 Offset: 0x13BB008 VA: 0x13BB008
		protected static void GotoEventQuest(int eventId, bool isLine6Mode)
		{
			if(eventId > 0)
			{
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventId);
				if(ev != null && ev.FBLGGLDPFDF_CanShowStartAdventure())
				{
					GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(ev.GFIBLLLHMPD_StartAdventureId);
					if(adv != null)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(ev.GFIBLLLHMPD_StartAdventureId);
						ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(ev.GFIBLLLHMPD_StartAdventureId, OAGBCBBHMPF.DKAMMIHBINF.IDINJDEBPKP_6);
						Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
						Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTQUEST, new AdvSetupParam() { eventUniqueId = eventId });
						MenuScene.Instance.GotoAdventure(false);
						return;
					}
				}
            }
			MenuScene.Instance.Mount(TransitionUniqueId.EVENTQUEST, new EventMusicSelectSceneArgs(eventId, isLine6Mode, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x13BB460 Offset: 0x13BB460 VA: 0x13BB460
		protected static void GotoEventBattle(int eventId, bool isLine6Mode)
		{
			if(eventId > 0)
			{
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventId);
				if(ev != null && ev.FBLGGLDPFDF_CanShowStartAdventure())
				{
					GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(ev.GFIBLLLHMPD_StartAdventureId);
					if(adv != null)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(ev.GFIBLLLHMPD_StartAdventureId);
						ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(ev.GFIBLLLHMPD_StartAdventureId, OAGBCBBHMPF.DKAMMIHBINF.IDINJDEBPKP_6);
						Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
						Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTBATTLE, new AdvSetupParam() { eventUniqueId = eventId });
						MenuScene.Instance.GotoAdventure(false);
						return;
					}
				}
            }
			MenuScene.Instance.Mount(TransitionUniqueId.EVENTBATTLE, new EventMusicSelectSceneArgs(eventId, isLine6Mode, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x13BB8B8 Offset: 0x13BB8B8 VA: 0x13BB8B8
		protected static void GotoEventRaid(int eventId, bool isLine6Mode)
		{
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GotoEventRaid");
		}

		// // RVA: 0x13BC020 Offset: 0x13BC020 VA: 0x13BC020
		protected static void GotoEventGoDiva(int eventId, bool isLine6Mode)
		{
			if(eventId > 0)
			{
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventId);
				if(ev != null && ev.FBLGGLDPFDF_CanShowStartAdventure())
				{
					GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(ev.GFIBLLLHMPD_StartAdventureId);
					if(adv != null)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(ev.GFIBLLLHMPD_StartAdventureId);
						ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(ev.GFIBLLLHMPD_StartAdventureId, OAGBCBBHMPF.DKAMMIHBINF.IDINJDEBPKP_6);
						Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
						Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTGODIVA, new AdvSetupParam() { eventUniqueId = eventId });
						MenuScene.Instance.GotoAdventure(false);
						return;
					}
				}
            }
			MenuScene.Instance.Mount(TransitionUniqueId.EVENTGODIVA, new EventMusicSelectSceneArgs(eventId, isLine6Mode, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x13BC478 Offset: 0x13BC478 VA: 0x13BC478
		protected static void GotoRegularMusicSelect()
		{
			MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x13BC530 Offset: 0x13BC530 VA: 0x13BC530
		// protected static bool IsEventMissionSupport(IKDICBBFBMI eventCtrl) { }

		// // RVA: 0x13BC5C8 Offset: 0x13BC5C8 VA: 0x13BC5C8
		// protected static bool CheckCurrentEventLimit(KGCNCBOKCBA.GNENJEHKMHD term = 5) { }

		// // RVA: 0x13BC6E0 Offset: 0x13BC6E0 VA: 0x13BC6E0
		// protected bool SelectUnitDanceFocus(out int freeMusicId, out FreeCategoryId.Type category, ref bool line6Mode, OHCAABOMEOF.KGOGMKMBCPP eventCategory) { }

		// // RVA: 0x13BC8DC Offset: 0x13BC8DC VA: 0x13BC8DC
		// protected bool CanDoUnitDanceFocus(bool isLine6Mode) { }

		// // RVA: 0x13BCA08 Offset: 0x13BCA08 VA: 0x13BCA08
		// private bool IsEnableUnitDance(bool isLine6Mode) { }

		// // RVA: 0x13AAFE4 Offset: 0x13AAFE4 VA: 0x13AAFE4
		public static bool CheckEventLimit(IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP_EventType eventType, KGCNCBOKCBA.GNENJEHKMHD_EventStatus eventStatus, int eventId)
		{
			if(MenuScene.CheckDatelineAndAssetUpdate())
				return true;
			if(musicData != null && musicData.LEBDMNIGOJB_IsScoreEvent)
			{
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6);
                if (ev != null && ev.FKKDIDMGLMI)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(() =>
					{
						//0x13BF644
						MenuScene.Instance.GotoTitle();
					});
					return true;
				}
			}
			if(musicData != null)
			{
				return MenuScene.Instance.CheckEventLimit(musicData, true, true, eventStatus < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6 ? KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 : KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, eventId);
			}
			return MenuScene.Instance.CheckEventLimit(eventType, true, true, eventStatus < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6 ? KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 : KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, eventId);
		}

		// // RVA: 0x13BCC8C Offset: 0x13BCC8C VA: 0x13BCC8C
		protected static void OnClickRankingButton(IBJAKJJICBC musicData)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.Call(TransitionList.Type.REGULAR_RANKING, new RegularRankingSceneArgs(musicData), true);
		}

		// // RVA: 0x13BCDB4 Offset: 0x13BCDB4 VA: 0x13BCDB4
		protected static void OnClickRewardButton(Action OpenRewardWindowFunc)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			OpenRewardWindowFunc();
		}

		// // RVA: 0x13BCEE4 Offset: 0x13BCEE4 VA: 0x13BCEE4
		protected static void OnClickDetailButton(MonoBehaviour owner, IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			OpenMusicDetailWindow(owner, musicData, difficulty);
		}

		// // RVA: 0x13BD180 Offset: 0x13BD180 VA: 0x13BD180
		// protected static void OnClickEnemyDetailButton(MonoBehaviour owner, IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0x13BD3F4 Offset: 0x13BD3F4 VA: 0x13BD3F4
		protected static void OnClickEventRankingButton(IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP_EventType eventType, KGCNCBOKCBA.GNENJEHKMHD_EventStatus eventStatus, int eventId, IKDICBBFBMI_EventBase eventCtrl, int selectDiva/* = 0*/)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!CheckEventLimit(musicData, eventType, eventStatus, eventId))
			{
				MenuScene.Instance.Call(TransitionList.Type.EVENT_RANKING, new EventRankingSceneArgs(eventCtrl, false, 0, selectDiva), true);
			}
		}

		// // RVA: 0x13BD558 Offset: 0x13BD558 VA: 0x13BD558
		protected static void OnClickEventRewardButton(MonoBehaviour owner, IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP_EventType eventType, KGCNCBOKCBA.GNENJEHKMHD_EventStatus eventStatus, int eventId, IKDICBBFBMI_EventBase eventCtrl)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(!CheckEventLimit(musicData, eventType, eventStatus, eventId))
			{
				owner.StartCoroutineWatched(PopupRewardEvCheck.Co_ShowPopup(eventCtrl, owner.transform, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x13BF6E0
					return;
				}));
			}
		}

		// // RVA: 0x13BD80C Offset: 0x13BD80C VA: 0x13BD80C
		protected static void OnClickEnemyInfoButton(MonoBehaviour owner, IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			MenuScene.Instance.MusicPopupWindowControl.ShowEnemyInfo(owner, MusicPopupWindowControl.CallType.MusicSelect, musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].HPBPDHPIBGN_EnemyData, null);
		}

		// // RVA: 0x13BDA1C Offset: 0x13BDA1C VA: 0x13BDA1C
		protected static void OnClickStoryButton(IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP_EventType eventType, KGCNCBOKCBA.GNENJEHKMHD_EventStatus eventStatus, int eventId, IKDICBBFBMI_EventBase eventCtrl)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!CheckEventLimit(musicData, eventType, eventStatus, eventId))
			{
				CCAAJNJGNDO c = new CCAAJNJGNDO();
				c.KHEKNNFCAOI_InitFromCurrentEvent(eventCtrl);
				MenuScene.Instance.Call(TransitionList.Type.EVENT_STORY, new EventStoryArgs(c), true);
			}
		}

		// // RVA: 0x13BDBB0 Offset: 0x13BDBB0 VA: 0x13BDBB0
		protected static void OnClickMissionButton(IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP_EventType eventType, KGCNCBOKCBA.GNENJEHKMHD_EventStatus eventStatus, int eventId, IKDICBBFBMI_EventBase eventCtrl)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!CheckEventLimit(musicData, eventType, eventStatus, eventId))
			{
				CGJKNOCAPII c = new CGJKNOCAPII();
				c = c.BJKJLDPDEFA(eventCtrl, true);
				MenuScene.Instance.Call(TransitionList.Type.QUEST_SELECT, new QuestTopFormQuestListArgs(c), true);
			}
		}

		// // RVA: 0x13BDD4C Offset: 0x13BDD4C VA: 0x13BDD4C
		protected void OnClickPlayButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(!CheckEventLimit(selectMusicData, m_eventCtrl.HIDHLFCBIDE_EventType, m_eventStatus, m_eventId))
			{
				if(selectMusicData.AJGCPCMLGKO_IsEvent)
				{
					if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
					{
						GotoEventBattle(selectMusicData.EKANGPODCEP_EventId, isLine6ModeFlag);
					}
					else if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					{
						GotoEventGoDiva(selectMusicData.EKANGPODCEP_EventId, isLine6ModeFlag);
					}
					else if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
					{
						GotoEventRaid(selectMusicData.EKANGPODCEP_EventId, isLine6ModeFlag);
					}
					else if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
					{
						GotoEventQuest(selectMusicData.EKANGPODCEP_EventId, isLine6ModeFlag);
					}
					else
					{
						GotoEventMusicSelect(selectMusicData.EKANGPODCEP_EventId, isLine6ModeFlag);
					}
				}
				else if(selectMusicData.BNIAJAKIAJC_IsEventMinigame)
				{
					GotoMiniGame(selectMusicData.NOKBLCDMLPP_MinigameEventInfo.OOCBPMNHLPM_MusicId);
				}
				else if(selectMusicData.POEGGBGOKGI_IsInfoLiveEntrance)
				{
					GotoRegularMusicSelect();
				}
				else if(!selectMusicData.IFNPBIJEPBO_IsDlded)
				{
					DownloadCurrentMusic();
				}
				else if(!MenuScene.Instance.TryMusicPeriod(selectMusicData.IHPCKOMBGKJ_End, m_eventCtrl != null ? m_eventCtrl.PGIIDPEGGPI_EventId : 0, (OHCAABOMEOF.KGOGMKMBCPP_EventType) selectMusicData.MNNHHJBBICA_GameEventType, false, MenuScene.MusicPeriodMess.MusicSelect))
				{
					CheckUnitLive(() =>
					{
						//0x13BF1A8
						CheckBoostData(DecideCurrentMusic, OnCancelDecideMusic);
					});
				}
			}
		}

		// // RVA: 0x13BE2D8 Offset: 0x13BE2D8 VA: 0x13BE2D8
		protected void OpenRewardWindow()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_rewardPopupSetting.TitleText = bk.GetMessageByLabel("popup_music_select_02");
			m_rewardPopupSetting.SetParent(transform);
			m_rewardPopupSetting.WindowSize = SizeType.Large;
			m_rewardPopupSetting.diff = diff;
			m_rewardPopupSetting.mode = LayoutPopupAchieveReward.eMode.MusicSelect;
			m_rewardPopupSetting.selectMusicId = musicId;
			m_rewardPopupSetting.selectFreeMusicId = freeMusicId;
			m_rewardPopupSetting.gameEventType = gameEventType;
			m_rewardPopupSetting.isLine6Mode = isLine6ModeFlag;
			m_rewardPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_rewardPopupSetting, null, null, null, null, true, true, false);
		}

		// // RVA: 0x13BD010 Offset: 0x13BD010 VA: 0x13BD010
		private static void OpenMusicDetailWindow(MonoBehaviour owner, IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			MenuScene.Instance.MusicPopupWindowControl.Show(owner, MusicPopupWindowControl.CallType.MusicSelect, musicData.DLAEJOBELBH_MusicId, musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].HPBPDHPIBGN_EnemyData, null, false);
		}

		// // RVA: 0x13BD2AC Offset: 0x13BD2AC VA: 0x13BD2AC
		// private static void OpenEnemyDetailWindow(MonoBehaviour owner, IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0x13BE668 Offset: 0x13BE668 VA: 0x13BE668
		public static void OpenStaminaWindow(Action recoveryCallback, Action cancelCallback)
		{
			MenuScene.Instance.InputDisable();
			PopupWindowManager.OpenStaminaWindow(MenuScene.Instance.DenomControl, () =>
			{
				//0x13BFD8C
				MenuScene.Instance.InputEnable();
				if(recoveryCallback != null)
					recoveryCallback();
			}, () =>
			{
				//0x13BFE40
				MenuScene.Instance.InputEnable();
				if(cancelCallback != null)
					cancelCallback();
			}, () =>
			{
				//0x13BF6E4
				MenuScene.Instance.GotoTitle();
			}, (TransitionList.Type gotoSceneType) =>
			{
				//0x13BF780
				if(gotoSceneType == TransitionList.Type.TITLE)
					MenuScene.Instance.GotoTitle();
				else if(gotoSceneType == TransitionList.Type.LOGIN_BONUS)
					MenuScene.Instance.GotoLoginBonus();
				MenuScene.Instance.InputEnable();
			});
		}

		// // RVA: 0x13AB37C Offset: 0x13AB37C VA: 0x13AB37C
		public static void OpenWeekRecoveryWindow(IBJAKJJICBC musicData, Action<int> recoveryCallback, Action cancelCallback)
		{
			MenuScene.Instance.InputDisable();
			PopupWindowManager.OpenWeekRecoveryWindow(musicData.GHBPLHBNMBK_FreeMusicId, (int recovery) =>
			{
				//0x13BFEF4
				MenuScene.Instance.InputEnable();
				if(recoveryCallback != null)
					recoveryCallback(recovery);
			}, () =>
			{
				//0x13BFFBC
				MenuScene.Instance.InputEnable();
				if(cancelCallback != null)
					cancelCallback();
			}, () =>
			{
				//0x13BF8DC
				MenuScene.Instance.GotoTitle();
			}, (TransitionList.Type gotoSceneType) =>
			{
				//0x13BF978
				if(gotoSceneType == TransitionList.Type.TITLE)
					MenuScene.Instance.GotoTitle();
				else if(gotoSceneType == TransitionList.Type.LOGIN_BONUS)
					MenuScene.Instance.GotoLoginBonus();
				MenuScene.Instance.InputEnable();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EFB6C Offset: 0x6EFB6C VA: 0x6EFB6C
		// // RVA: 0x13AA19C Offset: 0x13AA19C VA: 0x13AA19C
		protected static IEnumerator Co_CheckUnlock(Action<int> callback)
		{
			//0x13C27A4
			yield return Co.R(PopupUnlock.Show(PopupUnlock.eSceneType.MusicSelect, callback, true, null));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EFBE4 Offset: 0x6EFBE4 VA: 0x6EFBE4
		// // RVA: 0x13AEBB4 Offset: 0x13AEBB4 VA: 0x13AEBB4
		protected static IEnumerator Co_ChangeBg(BgType bgType, int bgId, Action OnEnd)
		{
			BgControl bgControl;

			//0x13C03B8
			bgControl = MenuScene.Instance.BgControl;
			yield return Co.R(bgControl.ChangeBgCoroutine(bgType, bgId, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			bgControl.ChangeTilingType(BgBehaviour.TilingType.Dot);
			if(OnEnd != null)
				OnEnd();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EFC5C Offset: 0x6EFC5C VA: 0x6EFC5C
		// // RVA: 0x13AA0EC Offset: 0x13AA0EC VA: 0x13AA0EC
		protected static IEnumerator Co_ShowHelp(MonoBehaviour owner, EventMusicSelectSceneBase.EventHelpInfo helpInfo)
		{
			int i;

			//0x13C4908
			if(helpInfo.helpIds.Count != 0)
			{
				for(i = 0; i < helpInfo.helpIds.Count; i++)
				{
					if(helpInfo.helpIds[i] != 0)
					{
						MenuScene.Instance.InputDisable();
						yield return owner.StartCoroutineWatched(TutorialManager.ShowTutorial(helpInfo.helpIds[i], () =>
						{
							//0x13BFAD4
							MenuScene.Instance.InputEnable();
						}));
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EFCD4 Offset: 0x6EFCD4 VA: 0x6EFCD4
		// // RVA: 0x13BEA48 Offset: 0x13BEA48 VA: 0x13BEA48
		protected IEnumerator Co_LoadAssetBundle_LoginBonusPopup()
		{
			FontInfo systemFont; // 0x14
			AssetBundleLoadLayoutOperationBase lytOp; // 0x18

			//0x13C3A78
			m_loadingTicketGainedPopup = true;
			m_ticketGainedPopupSetting = new TicketGainedPopupSetting();
			systemFont = GameManager.Instance.GetSystemFont();
			lytOp = AssetBundleManager.LoadLayoutAsync(m_ticketGainedPopupSetting.BundleName, m_ticketGainedPopupSetting.AssetName);
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x13BF268
				m_ticketGainedPopupSetting.SetContent(instance);
			}));
			m_ticketGainedPopupSetting.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_ticketGainedPopupSetting.BundleName, false);
			m_loadingTicketGainedPopup = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EFD4C Offset: 0x6EFD4C VA: 0x6EFD4C
		// // RVA: 0x13B0EFC Offset: 0x13B0EFC VA: 0x13B0EFC
		protected IEnumerator Co_Initialize_LoginBonusPopup(IKDICBBFBMI_EventBase a_controller, Action GotoTitleFunc)
		{
			int itemId; // 0x20
			int itemCount; // 0x24

			//0x13C33BC
			if(m_ticketGainedPopupSetting == null || a_controller == null)
				yield break;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_showTicketGainedPopup = false;
			itemId = 0;
			itemCount = 0;
			if(a_controller.GJMGKBDGMOP(t) && a_controller.BHABCGJCGNO != null)
			{
				m_showTicketGainedPopup = true;
				itemId = a_controller.BHABCGJCGNO.JJBGOIMEIPF_ItemId;
				itemCount = a_controller.BHABCGJCGNO.MBJIFDBEDAC_Cnt;
				bool done = false;
				CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
				{
					//0x13C0080
					done = true;
				}, () =>
				{
					//0x13C008C
					done = true;
					if(GotoTitleFunc != null)
						GotoTitleFunc();
					else
					{
						GotoTitle();
					}
				}, null);
				while(!done)
					yield return null;
			}
			//LAB_013c378c
			if(m_showTicketGainedPopup)
			{
				m_showTicketGainedPopup = OnInitializeLoginBonusPopup(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId), itemCount, m_ticketGainedPopupSetting);
				if(!m_showTicketGainedPopup)
				{
					m_showTicketGainedPopup = SetupLoginBonusPopupSetting(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId), itemCount, m_ticketGainedPopupSetting);
					if(!m_showTicketGainedPopup)
						yield break;
				}
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

		// // RVA: 0x13BEB14 Offset: 0x13BEB14 VA: 0x13BEB14
		protected static bool SetupLoginBonusPopupSetting(EKLNMHFCAOI.FKGCBLHOOCL_Category itemType, int itemCount, TicketGainedPopupSetting popupSetting)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
			{
				popupSetting.title = string.Format(bk.GetMessageByLabel("popup_event_login_item01_title_msg"), itemCount);
				popupSetting.label01 = bk.GetMessageByLabel("popup_event_login_item01_label00_msg");
				popupSetting.label02 = bk.GetMessageByLabel("popup_event_login_item01_label01_msg");
				popupSetting.layoutType = 0;
				return true;
			}
			else if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
			{
				popupSetting.title = string.Format(bk.GetMessageByLabel("popup_event_login_item00_title_msg"), itemCount);
				popupSetting.label01 = bk.GetMessageByLabel("popup_event_login_item00_label00_msg");
				popupSetting.label02 = bk.GetMessageByLabel("popup_event_login_item00_label01_msg");
				popupSetting.layoutType = 1;
				return true;
			}
			return false;
		}

		// // RVA: -1 Offset: -1 Slot: 56
		protected abstract bool OnInitializeLoginBonusPopup(EKLNMHFCAOI.FKGCBLHOOCL_Category itemType, int itemCount, TicketGainedPopupSetting popupSetting);

		// [IteratorStateMachineAttribute] // RVA: 0x6EFDC4 Offset: 0x6EFDC4 VA: 0x6EFDC4
		// // RVA: 0x13AA060 Offset: 0x13AA060 VA: 0x13AA060
		protected static IEnumerator Co_ShowReciveLoginAchievement(IKDICBBFBMI_EventBase eventCtrl)
		{
			PopupItemGetSetting itemReceivePopupSetting; // 0x18
			int i; // 0x1C

			//0x13C5054
			if(eventCtrl.JBPPMMMFGCA_HasRewardItems())
			{
				bool isWait = false;
				itemReceivePopupSetting = new PopupItemGetSetting();
				for(i = 0; i < eventCtrl.KGBCKPKLKHM_RewardItems.Count; i++)
				{
					itemReceivePopupSetting.TitleText = MessageManager.Instance.GetMessage("menu", eventCtrl.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6 ? "popup_event_login_prologue_title" : "popup_event_login_epilogue_title");
					itemReceivePopupSetting.ItemId = eventCtrl.KGBCKPKLKHM_RewardItems[i].JJBGOIMEIPF_ItemId;
					itemReceivePopupSetting.Count = eventCtrl.KGBCKPKLKHM_RewardItems[i].MBJIFDBEDAC_Cnt;
					itemReceivePopupSetting.IsPresentBox = true;
					itemReceivePopupSetting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					isWait = true;
					PopupWindowManager.Show(itemReceivePopupSetting, (PopupWindowControl type, PopupButton.ButtonType label, PopupButton.ButtonLabel control) =>
					{
						//0x13C0138
						isWait = false;
					}, null, null, null, true, true, false);
					while(isWait)
						yield return null;
				}
				eventCtrl.KGBCKPKLKHM_RewardItems.Clear();
				itemReceivePopupSetting = null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EFE3C Offset: 0x6EFE3C VA: 0x6EFE3C
		// // RVA: 0x13B05CC Offset: 0x13B05CC VA: 0x13B05CC
		protected IEnumerator Co_Show_LoginBonusPopup(Action onEnd)
		{
			//0x13C5688
			if(m_ticketGainedPopupSetting == null || !m_showTicketGainedPopup)
				yield break;
			MenuScene.Instance.InputDisable();
			bool isClosed = false;
			PopupWindowManager.Show(m_ticketGainedPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13C014C
				isClosed = true;
			}, null, null, null, true, true, false);
			while(!isClosed)
				yield return null;
			if(onEnd != null)
				onEnd();
			m_showTicketGainedPopup = false;
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EFEB4 Offset: 0x6EFEB4 VA: 0x6EFEB4
		// // RVA: 0x13BEEB4 Offset: 0x13BEEB4 VA: 0x13BEEB4
		// protected IEnumerator TryShowUnitDanceTutorial() { }

		// // RVA: 0x13BEF60 Offset: 0x13BEF60 VA: 0x13BEF60
		// private bool CheckUnitDanceTutorialFunc(TutorialConditionId conditionId) { }
	}
}
