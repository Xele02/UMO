using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;
using XeSys.uGUI;

namespace XeApp.Game.Menu
{
	public abstract class VerticalMusicSelectSceneBase : TransitionRoot
	{

		protected struct MusicDecideInfo
		{
			public long overrideCurrentTime; // 0x0
			public string missionText; // 0x8
			public int overrideEnemyCenterSkill; // 0xC
			public int overrideEnemyLiveSkill; // 0x10
			public GameSetupData.MusicInfo.InitFreeMusicParam initParam; // 0x14
			public static MusicDecideInfo Empty = new MusicDecideInfo(0, string.Empty, 0, 0); // 0x0

			// RVA: 0x7FAA44 Offset: 0x7FAA44 VA: 0x7FAA44
			public MusicDecideInfo(long overrideCurrentTime, string missionText, int overrideEnemyCenterSkill, int overrideEnemyLiveSkill)
			{
				this.overrideCurrentTime = overrideCurrentTime;
				this.missionText = missionText;
				this.overrideEnemyCenterSkill = overrideEnemyCenterSkill;
				this.overrideEnemyLiveSkill = overrideEnemyLiveSkill;
				initParam.isDisableBattleEventIntermediateResult = false;
			}
		}

		protected class MusicLockData
		{
			public string lockDetail = ""; // 0x8
			public int freeMusicId = 0; // 0xC
			public bool isLock = false; // 0x10
		}

		protected struct EventHelpInfo
		{
			public List<int> helpIds; // 0x0
			public bool isShowFirstHelp; // 0x4
		}

		public delegate bool CheckMatchMusicFilterFunc(VerticalMusicDataList.MusicListData musicData, int series, long currentTime);

		protected IKDICBBFBMI_EventBase m_scoreEventCtrl; // 0x50
		// private VerticalMusicSelectSceneBase.MusicDecideInfo m_musicDecideInfo = MusicDevideInfo.Empty; // 0x68
		private PopupAchieveRewardSetting m_rewardPopupSetting = new PopupAchieveRewardSetting(); // 0x88
		private PopupUnitDanceWarning m_popupUnitDanceWarning = new PopupUnitDanceWarning(); // 0x8C
		// private PopupMusicBookMarkSetting m_musicBookMarkSetting = new PopupMusicBookMarkSetting(); // 0x90
		private bool m_isConfirmedUnitDance; // 0x94
		// private TeamSlectSceneArgs m_teamSelectSceneArgs = new TeamSlectSceneArgs(); // 0x98
		// private const float BGM_FADE_OUT_SEC = 0,3;
		// private List<Action> NoticeActionList = new List<Action>(); // 0xAC

		protected bool m_isEndPresetCanvas { get; set; } // 0x45
		protected bool m_isEndPostSetCanvas { get; set; } // 0x46
		protected bool m_isEndActivateScene { get; set; } // 0x47
		protected abstract Difficulty.Type diff { get; }  //Slot: 31
		protected abstract MusicSelectConsts.SeriesType series { get; } //Slot: 32
		protected abstract int list_no { get; set; } //Slot: 34 Slot: 33
		protected bool openSimulationLive { get; set; } // 0x48
		protected abstract bool isLine6Mode { get; } // Slot: 35
		protected abstract int musicListCount { get; } // Slot: 36
		protected abstract VerticalMusicDataList currentMusicList { get; } //  Slot: 38
		// protected abstract List<VerticalMusicDataList> originalMusicList { get; } //  Slot: 39
		protected IKDICBBFBMI_EventBase m_eventCtrl { get; set; } // 0x4C
		protected int m_eventId { get; set; } // 0x54
		protected MMOLNAHHDOM m_unitLiveLocalSaveData { get; private set; } // 0x58
		protected LimitTimeWatcher m_musicTimeWatcher { get; private set; } = new LimitTimeWatcher(); // 0x5C
		protected LimitTimeWatcher m_bannerTimeWatcher { get; private set; } = new LimitTimeWatcher(); // 0x60
		protected abstract IBJAKJJICBC selectMusicData { get; } // Slot: 40
		protected abstract VerticalMusicDataList.MusicListData selectMusicListData { get; } // Slot: 41
		protected bool listIsEmpty { get {
			return currentMusicList.GetCount(isLine6Mode, false) < 1;
		} } //0xAC8AD4
		// protected bool listIsEmptyByFilter { get; } 0xAC8B48
		// protected bool isExistSelectMusicData { get; } 0xAC8B50
		// protected int musicId { get; } 0xAC8B58
		protected int freeMusicId { get {
			if(listIsEmpty)
				return 0;
			return selectMusicData.GHBPLHBNMBK_FreeMusicId;
		} } //0xAC8BAC
		// protected int gameEventType { get; } 0xAC8C00
		// protected int m_eventTicketId { get; set; } // 0x9C
		protected KGCNCBOKCBA.GNENJEHKMHD m_eventStatus { get; set; } // 0xA0
		protected bool m_isEventTimeLimit { get; set; } // 0xA4
		// private bool m_muteSelectionSe { get; set; } // 0xA5
		private bool m_requestFadeOutBgm { get; set; } // 0xA6
		private int m_changeToTrialBgmId { get; set; } // 0xA8
		// private float bgmFadeOutSec { get; } 0xAC8CAC
		// public bool IsEventCounting { get; } 0xACFD7C
		// public bool IsEventEndChallengePeriod { get; } 0xACFD90
		// public bool IsEventRankingEnd { get; } 0xACFDA4

		// // RVA: -1 Offset: -1 Slot: 37
		protected abstract VerticalMusicDataList GetMusicList(int index);

		// // RVA: 0xAC8CB8 Offset: 0xAC8CB8 VA: 0xAC8CB8 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			StartCoroutine(Co_Awake());
		}

		// // RVA: 0xAC8D74 Offset: 0xAC8D74 VA: 0xAC8D74
		protected void Update()
		{
			m_bannerTimeWatcher.Update();
			m_musicTimeWatcher.Update();
			OnUpdate();
		}

		// RVA: 0xAC8DD8 Offset: 0xAC8DD8 VA: 0xAC8DD8 Slot: 16
		protected override void OnPreSetCanvas()
		{
			LoadUnitLiveSaveData();
			StartCoroutine(Co_OnPreSetCanvas());
		}

		// RVA: 0xAC8EA4 Offset: 0xAC8EA4 VA: 0xAC8EA4 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isEndPresetCanvas && !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB;
		}

		// RVA: 0xAC8F58 Offset: 0xAC8F58 VA: 0xAC8F58 Slot: 18
		protected override void OnPostSetCanvas()
		{
			StartCoroutine(Co_OnPostSetCanvas());
		}

		// RVA: 0xAC8F8C Offset: 0xAC8F8C VA: 0xAC8F8C Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isEndPostSetCanvas;
		}

		// RVA: 0xAC8F94 Offset: 0xAC8F94 VA: 0xAC8F94 Slot: 23
		protected override void OnActivateScene()
		{
			StartCoroutine(Co_ActivateScene());
		}

		// RVA: 0xAC8FC8 Offset: 0xAC8FC8 VA: 0xAC8FC8 Slot: 24
		protected override bool IsEndActivateScene()
		{
			return m_isEndActivateScene;
		}

		// RVA: 0xAC8FD0 Offset: 0xAC8FD0 VA: 0xAC8FD0 Slot: 20
		protected override bool OnBgmStart()
		{
			DelayedApplyMusicInfo();
			return true;
		}

		// RVA: 0xAC8FF0 Offset: 0xAC8FF0 VA: 0xAC8FF0 Slot: 14
		protected override void OnDestoryScene()
		{
			ReleaseScene();
			m_unitLiveLocalSaveData.HJMKBCFJOOH(false);
		}

		// RVA: 0xAC9038 Offset: 0xAC9038 VA: 0xAC9038 Slot: 15
		protected override void OnDeleteCache()
		{
			ReleaseCache();
			m_popupUnitDanceWarning.Release();
		}

		// RVA: 0xAC9070 Offset: 0xAC9070 VA: 0xAC9070 Slot: 30
		//protected override void InputDisable()
		//{
		//	TodoLogger.Log(0, "!!!");
		//}

		// RVA: 0xAC909C Offset: 0xAC909C VA: 0xAC909C Slot: 29
		//protected override void InputEnable()
		//{
		//	TodoLogger.Log(0, "!!!");
		//}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6914 Offset: 0x6F6914 VA: 0x6F6914
		// // RVA: 0xAC8CE8 Offset: 0xAC8CE8 VA: 0xAC8CE8
		private IEnumerator Co_Awake()
		{
			//0xAD45C0
			yield return Co_LoadResourceOnAwake();
			m_rewardPopupSetting.SetParent(transform);
			yield return Co_WaitForLoaded();
			IsReady = true;
		}

		// // RVA: -1 Offset: -1 Slot: 42
		protected abstract IEnumerator Co_OnPreSetCanvas();

		// // RVA: -1 Offset: -1 Slot: 43
		protected abstract IEnumerator Co_OnPostSetCanvas();

		// // RVA: -1 Offset: -1 Slot: 44
		protected abstract IEnumerator Co_ActivateScene();

		// // RVA: -1 Offset: -1 Slot: 45
		protected abstract IEnumerator Co_LoadResourceOnAwake();

		// // RVA: -1 Offset: -1 Slot: 46
		protected abstract IEnumerator Co_WaitForLoaded();

		// // RVA: -1 Offset: -1 Slot: 47
		protected abstract void OnUpdate();

		// // RVA: -1 Offset: -1 Slot: 48
		protected abstract void ReleaseScene();

		// // RVA: -1 Offset: -1 Slot: 49
		protected abstract void ReleaseCache();

		// // RVA: -1 Offset: -1 Slot: 50
		// protected abstract void OnInputDisable();

		// // RVA: -1 Offset: -1 Slot: 51
		// protected abstract void OnInputEnable();

		// // RVA: -1 Offset: -1 Slot: 52
		protected abstract void ApplyCommonInfo();

		// // RVA: -1 Offset: -1 Slot: 53
		protected abstract void ApplyMusicInfo();

		// // RVA: -1 Offset: -1 Slot: 54
		protected abstract void DelayedApplyMusicInfo();

		// [IteratorStateMachineAttribute] // RVA: 0x6F698C Offset: 0x6F698C VA: 0x6F698C
		// // RVA: 0xAC83B4 Offset: 0xAC83B4 VA: 0xAC83B4
		protected IEnumerator Co_ChangeBg(BgType bgType, int bgId, Action endCallBack, bool isFade)
		{
			//0xAD4790
			if (isFade)
			{
				MenuScene.Instance.BgControl.ReserveFade(0.2f, Color.black);
			}
			yield return MenuScene.Instance.BgControl.ChangeBgCoroutine(bgType, bgId, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1);
			if(endCallBack != null)
			{
				endCallBack();
			}
		}

		// // RVA: -1 Offset: -1 Slot: 55
		protected abstract int GetDanceDivaCount();

		// // RVA: 0xAC8E10 Offset: 0xAC8E10 VA: 0xAC8E10
		private void LoadUnitLiveSaveData()
		{
			m_unitLiveLocalSaveData = new MMOLNAHHDOM();
			m_unitLiveLocalSaveData.PCODDPDFLHK();
			m_isConfirmedUnitDance = false;
		}

		// // RVA: 0xAC9108 Offset: 0xAC9108 VA: 0xAC9108
		// private void ApplyUnitLiveButtonSetting(bool isUnit) { }

		// // RVA: -1 Offset: -1 Slot: 56
		// protected abstract void OnApplyUnitLiveButtonSetting(bool isUnit);

		// // RVA: 0xAC9194 Offset: 0xAC9194 VA: 0xAC9194
		// private void UnitDanceOnlyBackButton() { }

		// // RVA: 0xAC91E0 Offset: 0xAC91E0 VA: 0xAC91E0
		private void CheckUnitLive(Action endCallback)
		{
			GameManager.Instance.StartCoroutine(Co_CheckUnitLive(endCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6A04 Offset: 0x6F6A04 VA: 0x6F6A04
		// // RVA: 0xAC9298 Offset: 0xAC9298 VA: 0xAC9298
		private IEnumerator Co_CheckUnitLive(Action endCallback)
		{
			int danceDivaCount;
			bool isUnitOnly;
			UnityAction<bool> positiveAction;
			UnityAction<bool> negativeAction;
			UnityAction toggleAction;
			GameManager.PushBackButtonHandler handler;
			//0xAD5DD0
			danceDivaCount = GetDanceDivaCount();
			if(danceDivaCount > 1)
			{
				TodoLogger.Log(0, "Finish CheckUnitLive");
			}
			yield return null;
			if (endCallback != null)
				endCallback();
		}

		// // RVA: -1 Offset: -1 Slot: 57
		// protected abstract void OnClickDifficultyButton(int index);

		// // RVA: 0xAC9360 Offset: 0xAC9360 VA: 0xAC9360
		protected void DownloadCurrentMusic()
		{
			m_unitLiveLocalSaveData.HJMKBCFJOOH(false);
			StartCoroutine(Co_DownloadMusic(selectMusicData));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6A7C Offset: 0x6F6A7C VA: 0x6F6A7C
		// // RVA: 0xAC93C4 Offset: 0xAC93C4 VA: 0xAC93C4
		private IEnumerator Co_DownloadMusic(IBJAKJJICBC musicData)
		{
			UGUIFader fader;
			TipsControl tipsCtrl;
			int musicId;
			ILCCJNDFFOB lw;
			float pre;
			//0xAD76D0
			fader = GameManager.Instance.fullscreenFader;
			tipsCtrl = TipsControl.Instance;
			MenuScene.Instance.InputDisable();
			fader.Fade(0.5f, new Color(0, 0, 0, 1));
			tipsCtrl.Show(musicData);
			while (fader.isFading)
				yield return null;
			yield return tipsCtrl.WaitLoadingYield;
			while (tipsCtrl.isPlayingAnime())
				yield return null;
			int val = 0;
			musicId = musicData.DLAEJOBELBH_MusicId;
			if (GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.PMGMMMGCEEI_Video == 0)
			{
				val = GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.CBLEFELBNDN_GetQuality();
			}
			KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP = 0;
			lw = ILCCJNDFFOB.HHCJCDFCLOB;
			pre = 0;
			KDLPEDBKMID.HHCJCDFCLOB.OKJCGCOGDIA(musicData.KKPAHLMJKIH_WavId, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(musicData.GHBPLHBNMBK_FreeMusicId).KEFGPJBKAOD_WavId, val, GetDanceDivaCount());
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB)
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
			ApplyMusic();
			fader.Fade(0.5f, 0);
			tipsCtrl.Close();
			while (fader.isFading)
				yield return null;
			while (tipsCtrl.isPlayingAnime())
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xAC948C Offset: 0xAC948C VA: 0xAC948C
		private void CheckSimulationLive(Action<bool> endCallBack)
		{
			GameManager.Instance.StartCoroutine(Co_CheckSimulationLive(endCallBack));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6AF4 Offset: 0x6F6AF4 VA: 0x6F6AF4
		// // RVA: 0xAC953C Offset: 0xAC953C VA: 0xAC953C
		private IEnumerator Co_CheckSimulationLive(Action<bool> endCallBack)
		{
			//0xAD5804
			TodoLogger.Log(0, "Co_CheckSimulationLive");
			yield return null;
			if (endCallBack != null)
				endCallBack(true);
		}

		// // RVA: 0xAC95E8 Offset: 0xAC95E8 VA: 0xAC95E8 Slot: 58
		protected virtual bool CurrentMusicDecisionCheck(bool isSimulation, Action cancelCallback, MKIKFJKPEHK viewBoostData, int selectIndex = 0)
		{
			/*if(viewBoostData == null)
			{
				if(selectMusicData.LHONOILACFL)
				{
					if(selectMusicData.MOJMEFIENDM < 1)
					{
						OpenWeekRecoveryWindow((int recovery) =>
						{
							//0xAD3920
							TodoLogger.Log(0, "OpenWeekRecoveryWindow");
						}, cancelCallback);
						return false;
					}
				}
				CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI.DCLKMNGMIKC
			}*/
			TodoLogger.Log(0, "CurrentMusicDecisionCheck");
			OpenStaminaWindow(() => {
				DecideCurrentMusic(isSimulation);
			}, null);
			return false;
		}

		// // RVA: 0xAC9FF8 Offset: 0xAC9FF8 VA: 0xAC9FF8
		private void CheckBoostData(bool isSimulation, Action<bool> endCallback, Action cancelCallback)
		{
			TodoLogger.Log(0, "CheckBoostData");
			StartCoroutine(Co_CheckBoostData(isSimulation, endCallback, cancelCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6B6C Offset: 0x6F6B6C VA: 0x6F6B6C
		// // RVA: 0xACA0C8 Offset: 0xACA0C8 VA: 0xACA0C8
		private IEnumerator Co_CheckBoostData(bool isSimulation, Action<bool> endCallback, Action cancelCallback)
		{
			//0xAD49C0
			TodoLogger.Log(0, "Co_CheckBoostData");
			CurrentMusicDecisionCheck(true, null, null, 0);
			yield break;
		}

		// // RVA: 0xACA1C0 Offset: 0xACA1C0 VA: 0xACA1C0
		private void OnCancelDecideMusic()
		{
			TodoLogger.Log(0, "OnCancelDecideMusic");
		}

		// // RVA: -1 Offset: -1 Slot: 59
		// protected abstract void OnDecideCurrentMusic(ref VerticalMusicSelectSceneBase.MusicDecideInfo info);

		// // RVA: 0xACA1CC Offset: 0xACA1CC VA: 0xACA1CC
		private void DecideCurrentMusic(bool isSimulation)
		{
			TodoLogger.Log(0, "DecideCurrentMusic");
			int onStageDivaNum = GetDanceDivaCount();
			Database.Instance.gameSetup.musicInfo.SetupInfoByFreeMusic(freeMusicId, 0/*difficulty*/, false, new GameSetupData.MusicInfo.InitFreeMusicParam(), OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL, OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL, OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL, false, false, "", 0, 0, -1, 0, 0, onStageDivaNum);
			Database.Instance.selectedMusic.SetMusicData(selectMusicData);
			MenuScene.Instance.Call(TransitionList.Type.SIMULATIONLIVE_SETTING, null, true);
		}

		// // RVA: 0xACAA10 Offset: 0xACAA10 VA: 0xACAA10
		protected void OnClickPlayButton(bool isSimulation)
		{
			SoundManager.Instance.sePlayerBoot.Play(1);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(!CheckEventLimit())
			{
				if(selectMusicData.AJGCPCMLGKO_IsEvent)
				{
					if((int)selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory < 4)
					{
						if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
						{
							GotoEventBattle(selectMusicData.EKANGPODCEP_EventId);
							return;
						}
					}
					else
					{
						if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
						{
							GotoEventGoDiva(selectMusicData.EKANGPODCEP_EventId);
							return;
						}
						if (selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
						{
							GotoEventRaid(selectMusicData.EKANGPODCEP_EventId);
							return;
						}
						if (selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
						{
							GotoEventQuest(selectMusicData.EKANGPODCEP_EventId);
							return;
						}
					}
					GotoEventMusicSelect(selectMusicData.EKANGPODCEP_EventId);
					return;
				}
				if (selectMusicData.BNIAJAKIAJC_IsEventMinigame)
				{
					GotoEventMiniGame(selectMusicData.NOKBLCDMLPP_MinigameEventInfo.OOCBPMNHLPM_MusicId);
					return;
				}
				if(selectMusicData.POEGGBGOKGI)
				{
					GotoRegularMusicSelect();
					return;
				}
				if(!openSimulationLive && isSimulation && !RuntimeSettings.CurrentSettings.ForceSimulationOpen)
				{
					OpenLockSimulationLiveWindow();
					return;
				}
				if(!selectMusicListData.IsOpen)
				{
					OpenLockMusicInfoWindow();
					return;
				}
				if(!selectMusicData.IFNPBIJEPBO_IsDlded)
				{
					DownloadCurrentMusic();
					return;
				}
				int val = 0;
				if (m_eventCtrl != null)
					val = m_eventCtrl.PGIIDPEGGPI;
				if(!isSimulation)
				{
					if (!MenuScene.Instance.TryMusicPeriod(selectMusicData.IHPCKOMBGKJ, val, (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_EventType, isSimulation, MenuScene.MusicPeriodMess.MusicSelect))
					{
						CheckUnitLive(() =>
						{
							//0xAD3C0C
							CheckBoostData(isSimulation, this.DecideCurrentMusic, this.OnCancelDecideMusic);
						});
						return;
					}
				}
				else
				{
					if(!MenuScene.Instance.TryMusicPeriod(selectMusicData.NNJNNCGGKMC ? selectMusicData.IHPCKOMBGKJ : selectMusicData.ALMOMLMCHNA_OtherEndTime, val, (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_EventType, isSimulation, MenuScene.MusicPeriodMess.MusicSelect))
					{
						CheckUnitLive(() =>
						{
							//0xAD3B5C
							CheckSimulationLive(this.DecideCurrentMusic);
						});
						return;
					}
				}
			}
		}

		// // RVA: 0xACB214 Offset: 0xACB214 VA: 0xACB214
		protected bool CheckEventLimit()
		{
			TodoLogger.Log(0, "CheckEventLimit");
			return false;
		}

		// // RVA: 0xACE0E0 Offset: 0xACE0E0 VA: 0xACE0E0
		protected void ApplyRemainTime(VerticalMusicSelectMusicDetail musicDetail, long endTime, VerticalMusicSelectMusicDetail.MusicRemainTimeType remainType, LimitTimeWatcher.OnEndCallback endCallback)
		{
			m_musicTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
			{
				//0xAD3D14
				ApplyEventRemainTime(musicDetail, remain, remainType);
			};
			m_musicTimeWatcher.onEndCallback = endCallback;
			m_musicTimeWatcher.WatchStart(endTime, true);
		}

		// // RVA: 0xACE260 Offset: 0xACE260 VA: 0xACE260
		protected void ApplyEventRemainTime(VerticalMusicSelectMusicDetail musicDetail, long remainSec, VerticalMusicSelectMusicDetail.MusicRemainTimeType remainType)
		{
			TodoLogger.Log(0, "ApplyEventRemainTime");
		}

		// // RVA: 0xACE2F0 Offset: 0xACE2F0 VA: 0xACE2F0
		// protected void ApplyEventBannerRemainTime(VerticalMusicSelectEventBanner eventBunner, long remainSec) { }

		// // RVA: 0xAC72BC Offset: 0xAC72BC VA: 0xAC72BC
		public static void CrateFilterDataList(VerticalMusicDataList filterMusicList, List<VerticalMusicDataList> originalMusicList, int series, long currentTime, VerticalMusicSelectSceneBase.CheckMatchMusicFilterFunc checkFunc)
		{
			filterMusicList.Clear();
			for(int i = 0; i < originalMusicList.Count; i++)
			{
				VerticalMusicDataList item = originalMusicList[i];
				List<VerticalMusicDataList.MusicListData> l1 = new List<VerticalMusicDataList.MusicListData>();
				List<VerticalMusicDataList.MusicListData> l2 = new List<VerticalMusicDataList.MusicListData>();
				List<VerticalMusicDataList.MusicListData> l3 = new List<VerticalMusicDataList.MusicListData>();
				List<VerticalMusicDataList.MusicListData> l4 = new List<VerticalMusicDataList.MusicListData>();

				List<VerticalMusicDataList.MusicListData> a1 = item.GetList(false, false);
				List<VerticalMusicDataList.MusicListData> a2 = item.GetList(true, false);
				List<VerticalMusicDataList.MusicListData> a3 = item.GetList(false, true);
				List<VerticalMusicDataList.MusicListData> a4 = item.GetList(true, true);

				for(int j = 0; j < a1.Count; j++)
				{
					if(checkFunc(a1[j], series, currentTime))
					{
						l1.Add(a1[j]);
					}
				}
				for(int j = 0; j < a2.Count; j++)
				{
					if(checkFunc(a2[j], series, currentTime))
					{
						l2.Add(a2[j]);
					}
				}
				for(int j = 0; j < a3.Count; j++)
				{
					if(checkFunc(a3[j], series, currentTime))
					{
						l3.Add(a3[j]);
					}
				}
				for(int j = 0; j < a4.Count; j++)
				{
					if(checkFunc(a4[j], series, currentTime))
					{
						l4.Add(a4[j]);
					}
				}
				filterMusicList.AddList(l1, false, false);
				filterMusicList.AddList(l2, true, false);
				filterMusicList.AddList(l3, false, true);
				filterMusicList.AddList(l4, true, true);
			}
		}

		// // RVA: 0xACEC6C Offset: 0xACEC6C VA: 0xACEC6C
		// private void OnWebViewClose() { }

		// // RVA: 0xACED08 Offset: 0xACED08 VA: 0xACED08
		// private void OnNetErrorToTitle() { }

		// // RVA: 0xACEDA4 Offset: 0xACEDA4 VA: 0xACEDA4
		// private VerticalMusicSelectSceneBase.MusicLockData GetLastStoryData() { }

		// // RVA: 0xACF194 Offset: 0xACF194 VA: 0xACF194
		// private bool CheckStoryMusic(int freeMusicId) { }

		// // RVA: 0xACF30C Offset: 0xACF30C VA: 0xACF30C
		protected int GetLastStoryFreeMusicId()
		{
			TodoLogger.Log(0, "GetLastStoryFreeMusicId");
			return 99999;
		}

		// // RVA: 0xACF5E8 Offset: 0xACF5E8 VA: 0xACF5E8
		// protected void CheckSnsNotice() { }

		// // RVA: 0xACF730 Offset: 0xACF730 VA: 0xACF730
		// protected void CheckOfferNotice() { }

		// // RVA: 0xAC3AA8 Offset: 0xAC3AA8 VA: 0xAC3AA8
		// protected void AddNotice(Action action) { }

		// // RVA: 0xAC3B28 Offset: 0xAC3B28 VA: 0xAC3B28
		// protected void ShowNotice() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6BE4 Offset: 0x6F6BE4 VA: 0x6F6BE4
		// // RVA: 0xACF818 Offset: 0xACF818 VA: 0xACF818
		// private IEnumerator Co_ShowNotice() { }

		// // RVA: 0xACF8C4 Offset: 0xACF8C4 VA: 0xACF8C4
		private void OnEndFadeOutBGM()
		{
			m_requestFadeOutBgm = false;
			if (m_changeToTrialBgmId < 0)
				return;
			SoundManager.Instance.bgmPlayer.Play(m_changeToTrialBgmId, 1);
			m_changeToTrialBgmId = -1;
		}

		// // RVA: 0xACF944 Offset: 0xACF944 VA: 0xACF944
		protected void FadeOutBGM()
		{
			m_changeToTrialBgmId = -1;
			if(SoundManager.Instance.bgmPlayer.isPlaying && !m_requestFadeOutBgm)
			{
				m_requestFadeOutBgm = true;
				SoundManager.Instance.bgmPlayer.FadeOut(0.3f, this.OnEndFadeOutBGM);
			}
		}

		// // RVA: 0xACFA5C Offset: 0xACFA5C VA: 0xACFA5C
		protected void ChangeTrialMusic(int wavId)
		{
			if(!SoundManager.Instance.bgmPlayer.isPlaying)
			{
				SoundManager.Instance.bgmPlayer.Play(BgmPlayer.MENU_TRIAL_ID_BASE + wavId);
				m_changeToTrialBgmId = -1;
				return;
			}
			if(!m_requestFadeOutBgm)
			{
				if(SoundManager.Instance.bgmPlayer.currentBgmId != BgmPlayer.MENU_TRIAL_ID_BASE + wavId)
				{
					m_changeToTrialBgmId = BgmPlayer.MENU_TRIAL_ID_BASE + wavId;
					m_requestFadeOutBgm = true;
					SoundManager.Instance.bgmPlayer.FadeOut(0.3f, this.OnEndFadeOutBGM);
					return;
				}
			}
			m_changeToTrialBgmId = BgmPlayer.MENU_TRIAL_ID_BASE + wavId;
		}

		// // RVA: 0xACFC14 Offset: 0xACFC14 VA: 0xACFC14
		protected void ApplyMusic()
		{
			if(!listIsEmpty)
			{
				if(!selectMusicData.AJGCPCMLGKO_IsEvent && !selectMusicData.BNIAJAKIAJC_IsEventMinigame)
				{
					if (!selectMusicData.IFNPBIJEPBO_IsDlded)
						FadeOutBGM();
					else
						ChangeTrialMusic(selectMusicData.KKPAHLMJKIH_WavId);
					return;
				}
				if(selectMusicData.KKPAHLMJKIH_WavId > 0)
				{
					ChangeTrialMusic(selectMusicData.KKPAHLMJKIH_WavId);
					return;
				}
			}
			FadeOutBGM();
		}

		// // RVA: 0xACFD6C Offset: 0xACFD6C VA: 0xACFD6C
		// protected void OnScrollEnded() { }

		// // RVA: 0xACFDB8 Offset: 0xACFDB8 VA: 0xACFDB8
		// protected void OnClickEventDetailButton() { }

		// // RVA: 0xAD012C Offset: 0xAD012C VA: 0xAD012C
		// protected void OnClickRankingButton(IBJAKJJICBC musicData) { }

		// // RVA: 0xAD03FC Offset: 0xAD03FC VA: 0xAD03FC
		protected void OnClickRewardButton(Action openRewardWindowFunc)
		{
			TodoLogger.Log(0, "OnClickRewardButton");
		}

		// // RVA: 0xAD0524 Offset: 0xAD0524 VA: 0xAD0524
		// protected void OnClickEventRewardButton() { }

		// // RVA: 0xAD07C8 Offset: 0xAD07C8 VA: 0xAD07C8
		// protected void OnClickDetailButton(VerticalMusicDataList.MusicListData musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xAD0AC0 Offset: 0xAD0AC0 VA: 0xAD0AC0
		// protected void OnClickEnemyDetailButton(IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xAD0290 Offset: 0xAD0290 VA: 0xAD0290
		// private void OnClickEventRankingButton(IBJAKJJICBC musicData) { }

		// // RVA: 0xAD0D34 Offset: 0xAD0D34 VA: 0xAD0D34
		// protected void OnClickEventRankingButton(IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP eventType, KGCNCBOKCBA.GNENJEHKMHD eventStatus, int eventId, IKDICBBFBMI eventCtrl, int selectDiva = 0) { }

		// // RVA: 0xAD0E84 Offset: 0xAD0E84 VA: 0xAD0E84
		// protected void OnClickEventRewardButton(MonoBehaviour owner, IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP eventType, KGCNCBOKCBA.GNENJEHKMHD eventStatus, int eventId, IKDICBBFBMI eventCtrl) { }

		// // RVA: 0xAD1110 Offset: 0xAD1110 VA: 0xAD1110
		// protected void OnClickStoryButton(IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP eventType, KGCNCBOKCBA.GNENJEHKMHD eventStatus, int eventId, IKDICBBFBMI eventCtrl) { }

		// // RVA: 0xAD128C Offset: 0xAD128C VA: 0xAD128C
		// protected void OnClickMissionButton() { }

		// // RVA: 0xAD1410 Offset: 0xAD1410 VA: 0xAD1410
		// protected void OnClickMusicRate() { }

		// // RVA: 0xAD158C Offset: 0xAD158C VA: 0xAD158C
		// protected void OnClickMusicBookMark(Action okCallBack) { }

		// // RVA: 0xAD1ABC Offset: 0xAD1ABC VA: 0xAD1ABC
		// protected void OnClickEventDetailButton(IKDICBBFBMI scoreEventCtrl) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6C5C Offset: 0x6F6C5C VA: 0x6F6C5C
		// // RVA: 0xAC3990 Offset: 0xAC3990 VA: 0xAC3990
		// protected IEnumerator Co_CheckUnlockAndAddMusic() { }

		// // RVA: 0xACD40C Offset: 0xACD40C VA: 0xACD40C
		protected void OpenLockSimulationLiveWindow()
		{
			TodoLogger.Log(0, "OpenLockSimulationLiveWindow");
		}

		// // RVA: 0xACD850 Offset: 0xACD850 VA: 0xACD850
		protected void OpenLockMusicInfoWindow()
		{
			TodoLogger.Log(0, "OpenLockMusicInfoWindow");
		}

		// // RVA: 0xAD1F18 Offset: 0xAD1F18 VA: 0xAD1F18
		protected void OpenRewardWindow()
		{
			TodoLogger.Log(0, "OpenRewardWindow");
		}

		// // RVA: 0xAD08F4 Offset: 0xAD08F4 VA: 0xAD08F4
		// protected void OpenMusicDetailWindow(VerticalMusicDataList.MusicListData musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xAD0BEC Offset: 0xAD0BEC VA: 0xAD0BEC
		// protected void OpenEnemyDetailWindow(IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xAC9928 Offset: 0xAC9928 VA: 0xAC9928
		// protected void OpenWeekRecoveryWindow(Action<int> recoveryCallback, Action cancelCallback) { }

		// // RVA: 0xAC9C88 Offset: 0xAC9C88 VA: 0xAC9C88
		protected void OpenStaminaWindow(Action recoveryCallback, Action cancelCallback)
		{
			TodoLogger.Log(0, "OpenStaminaWindow");
			recoveryCallback();
		}

		// // RVA: 0xAD16B4 Offset: 0xAD16B4 VA: 0xAD16B4
		// protected void OpenMusicBookMarkWindow(Action okCallBack, bool initialze) { }

		// // RVA: 0xACD354 Offset: 0xACD354 VA: 0xACD354
		private void GotoRegularMusicSelect()
		{
			TodoLogger.Log(0, "GotoRegularMusicSelect");
			MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, 0);
		}

		// // RVA: 0xACD2B0 Offset: 0xACD2B0 VA: 0xACD2B0
		private void GotoEventMiniGame(int miniGameId)
		{
			TodoLogger.Log(0, "GotoEventMiniGame");
		}

		// // RVA: 0xACBE10 Offset: 0xACBE10 VA: 0xACBE10
		protected void GotoEventMusicSelect(int eventId)
		{
			TodoLogger.Log(0, "GotoEventMusicSelect");
		}

		// // RVA: 0xACB9AC Offset: 0xACB9AC VA: 0xACB9AC
		protected void GotoEventQuest(int eventId)
		{
			TodoLogger.Log(0, "GotoEventQuest");
		}

		// // RVA: 0xACC274 Offset: 0xACC274 VA: 0xACC274
		protected void GotoEventBattle(int eventId)
		{
			TodoLogger.Log(0, "GotoEventBattle");
		}

		// // RVA: 0xACC6D8 Offset: 0xACC6D8 VA: 0xACC6D8
		protected void GotoEventRaid(int eventId)
		{
			TodoLogger.Log(0, "GotoEventRaid");
		}

		// // RVA: 0xACCE4C Offset: 0xACCE4C VA: 0xACCE4C
		protected void GotoEventGoDiva(int eventId)
		{
			TodoLogger.Log(0, "GotoEventGoDiva");
		}

		// // RVA: 0xAD1E40 Offset: 0xAD1E40 VA: 0xAD1E40
		// private void GotoStorySelect() { }

		// // RVA: 0xAD22C0 Offset: 0xAD22C0 VA: 0xAD22C0
		// private bool IsEnableUnitDance(bool line6Mode = False) { }

		// // RVA: 0xAC37D8 Offset: 0xAC37D8 VA: 0xAC37D8
		// protected bool CanDoUnitDanceFocus(bool line6Mode = False) { }

		// // RVA: 0xAC7CC0 Offset: 0xAC7CC0 VA: 0xAC7CC0
		protected bool SelectUnitDanceFocus(out int freeMusicId, out FreeCategoryId.Type category, ref bool line6Mode, bool isSimulation, OHCAABOMEOF.KGOGMKMBCPP_EventType eventCategory)
		{
			TodoLogger.Log(0, "SelectUnitDanceFocus");
			freeMusicId = 0;
			category = FreeCategoryId.Type.Macross;
			line6Mode = false;
			isSimulation = true;
			return true;
		}

		// // RVA: 0xAD2568 Offset: 0xAD2568 VA: 0xAD2568
		// protected void SetupHelp(ref VerticalMusicSelectSceneBase.EventHelpInfo helpInfo, IKDICBBFBMI eventCtrl) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6CD4 Offset: 0x6F6CD4 VA: 0x6F6CD4
		// // RVA: 0xAD28EC Offset: 0xAD28EC VA: 0xAD28EC
		// protected IEnumerator Co_ShowHelp(MonoBehaviour owner, VerticalMusicSelectSceneBase.EventHelpInfo helpInfo) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6D4C Offset: 0x6F6D4C VA: 0x6F6D4C
		// // RVA: 0xAC3904 Offset: 0xAC3904 VA: 0xAC3904
		// protected IEnumerator TryShowUnitDanceTutorial() { }

		// // RVA: 0xAD29DC Offset: 0xAD29DC VA: 0xAD29DC
		// protected bool CheckTutorialFunc_UnitDance(TutorialConditionId conditionId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6DC4 Offset: 0x6F6DC4 VA: 0x6F6DC4
		// // RVA: 0xAD2AA0 Offset: 0xAD2AA0 VA: 0xAD2AA0
		// protected IEnumerator TryShow6LineModeTutorial() { }

		// // RVA: 0xAD2B4C Offset: 0xAD2B4C VA: 0xAD2B4C
		// protected bool CheckTutorialFunc_6Line(TutorialConditionId conditionId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6E3C Offset: 0x6F6E3C VA: 0x6F6E3C
		// // RVA: 0xAC3A1C Offset: 0xAC3A1C VA: 0xAC3A1C
		// protected IEnumerator TryShowUtaRateTutorial() { }

		// // RVA: 0xAD2C28 Offset: 0xAD2C28 VA: 0xAD2C28
		// protected bool CheckTutorialFunc_UtaRate(TutorialConditionId conditionId) { }
	}
}
