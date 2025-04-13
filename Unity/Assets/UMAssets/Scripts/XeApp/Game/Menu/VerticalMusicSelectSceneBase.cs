using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Localization.SmartFormat;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;
using XeApp.Game.Tutorial;
using XeSys;
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
				initParam.returnTransitionUniqueId = 0;
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
		private MusicDecideInfo m_musicDecideInfo = MusicDecideInfo.Empty; // 0x68
		private PopupAchieveRewardSetting m_rewardPopupSetting = new PopupAchieveRewardSetting(); // 0x88
		private PopupUnitDanceWarning m_popupUnitDanceWarning = new PopupUnitDanceWarning(); // 0x8C
		private PopupMusicBookMarkSetting m_musicBookMarkSetting = new PopupMusicBookMarkSetting(); // 0x90
		private bool m_isConfirmedUnitDance; // 0x94
		private TeamSlectSceneArgs m_teamSelectSceneArgs = new TeamSlectSceneArgs(); // 0x98
		private const float BGM_FADE_OUT_SEC = 0.3f;
		private List<Action> NoticeActionList = new List<Action>(); // 0xAC

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
		protected abstract List<VerticalMusicDataList> originalMusicList { get; } //  Slot: 39
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
		protected int musicId { get {
				if (listIsEmpty)
					return 0;
				return selectMusicData.DLAEJOBELBH_MusicId;
			} } //0xAC8B58
		protected int freeMusicId { get {
			if(listIsEmpty)
				return 0;
			return selectMusicData.GHBPLHBNMBK_FreeMusicId;
		} } //0xAC8BAC
		protected int gameEventType { get {
				if (listIsEmpty)
					return 0;
				return selectMusicData.MNNHHJBBICA_GameEventType;
			} } //0xAC8C00
		protected int m_eventTicketId { get; set; } // 0x9C
		protected KGCNCBOKCBA.GNENJEHKMHD_EventStatus m_eventStatus { get; set; } // 0xA0
		protected bool m_isEventTimeLimit { get; set; } // 0xA4
		private bool m_muteSelectionSe { get; set; } // 0xA5
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
			this.StartCoroutineWatched(Co_Awake());
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
			this.StartCoroutineWatched(Co_OnPreSetCanvas());
		}

		// RVA: 0xAC8EA4 Offset: 0xAC8EA4 VA: 0xAC8EA4 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isEndPresetCanvas && !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xAC8F58 Offset: 0xAC8F58 VA: 0xAC8F58 Slot: 18
		protected override void OnPostSetCanvas()
		{
			this.StartCoroutineWatched(Co_OnPostSetCanvas());
		}

		// RVA: 0xAC8F8C Offset: 0xAC8F8C VA: 0xAC8F8C Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isEndPostSetCanvas;
		}

		// RVA: 0xAC8F94 Offset: 0xAC8F94 VA: 0xAC8F94 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_ActivateScene());
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
			m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
		}

		// RVA: 0xAC9038 Offset: 0xAC9038 VA: 0xAC9038 Slot: 15
		protected override void OnDeleteCache()
		{
			ReleaseCache();
			m_popupUnitDanceWarning.Release();
		}

		// RVA: 0xAC9070 Offset: 0xAC9070 VA: 0xAC9070 Slot: 30
		protected override void InputDisable()
		{
			base.InputDisable();
			OnInputDisable();
		}

		// RVA: 0xAC909C Offset: 0xAC909C VA: 0xAC909C Slot: 29
		protected override void InputEnable()
		{
			base.InputEnable();
			OnInputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6914 Offset: 0x6F6914 VA: 0x6F6914
		// // RVA: 0xAC8CE8 Offset: 0xAC8CE8 VA: 0xAC8CE8
		private IEnumerator Co_Awake()
		{
			//0xAD45C0
			yield return Co.R(Co_LoadResourceOnAwake());
			m_rewardPopupSetting.SetParent(transform);
			yield return Co.R(Co_WaitForLoaded());
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
		protected abstract void OnInputDisable();

		// // RVA: -1 Offset: -1 Slot: 51
		protected abstract void OnInputEnable();

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
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(bgType, bgId, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
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
			m_unitLiveLocalSaveData.PCODDPDFLHK_Read();
			m_isConfirmedUnitDance = false;
		}

		// // RVA: 0xAC9108 Offset: 0xAC9108 VA: 0xAC9108
		private void ApplyUnitLiveButtonSetting(bool isUnit)
		{
			m_unitLiveLocalSaveData.IAGAAOKODPM_SetMultiDiva(selectMusicData.GHBPLHBNMBK_FreeMusicId, isUnit);
			OnApplyUnitLiveButtonSetting(isUnit);
		}

		// // RVA: -1 Offset: -1 Slot: 56
		protected abstract void OnApplyUnitLiveButtonSetting(bool isUnit);

		// // RVA: 0xAC9194 Offset: 0xAC9194 VA: 0xAC9194
		private void UnitDanceOnlyBackButton()
		{
			m_popupUnitDanceWarning.WarningWindow.PerformClickOk();
		}

		// // RVA: 0xAC91E0 Offset: 0xAC91E0 VA: 0xAC91E0
		private void CheckUnitLive(Action endCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_CheckUnitLive(endCallback));
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
				int cnt = 0;
				for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
				{
					cnt += CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_Have;
				}
				if(cnt < danceDivaCount)
				{
					bool done = false;
					PopupWindowManager.Show(
						PopupWindowManager.CrateTextContent("", SizeType.Small, string.Format(MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_multi_dance_popup_03"), danceDivaCount), new ButtonInfo[1]{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
						}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0xAD2F50
							return;
						}, null, null, null);
					while (!done)
						yield return null;
					yield break;
				}
				else
				{
					ILDKBCLAFPB.JCFNHPMBPLJ_UnitDance saveData = GameManager.Instance.localSave.EPJOACOONAC_GetSave().EGNEDJLCMAI_UnitDance;
					if(!saveData.KBAMKMDJMJC_DisableWarning)
					{
						if(!m_isConfirmedUnitDance)
						{
							MenuScene.Instance.InputDisable();
							if(!m_popupUnitDanceWarning.IsLoaded)
							{
								yield return m_popupUnitDanceWarning.Co_Load(transform.parent);
								//2
							}
							//LAB_00ad6364;
							isUnitOnly = (selectMusicData.BNCMJNMIDIN_AvaiableDivaModes & 1) == 0;
							m_popupUnitDanceWarning.WarningWindow.Initialize(danceDivaCount, isUnitOnly);
							m_popupUnitDanceWarning.WarningWindow.transform.SetAsLastSibling();
							m_popupUnitDanceWarning.WarningWindow.Show();
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_000);
							while (m_popupUnitDanceWarning.WarningWindow.IsPlaying())
								yield return null;
							bool done = false;
							positiveAction = (bool isOn) =>
							{
								//0xAD37B0
								SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
								saveData.KBAMKMDJMJC_DisableWarning = isOn;
								done = true;
							};
							negativeAction = (bool isOn) =>
							{
								//0xAD3844
								SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
								ApplyUnitLiveButtonSetting(false);
								saveData.KBAMKMDJMJC_DisableWarning = isOn;
								done = true;
							};
							toggleAction = () =>
							{
								//0xAD2F54
								SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
							};
							m_popupUnitDanceWarning.WarningWindow.PositiveListener += positiveAction;
							m_popupUnitDanceWarning.WarningWindow.NegativeListener += negativeAction;
							m_popupUnitDanceWarning.WarningWindow.ToggleButtonListener += toggleAction;
							handler = () =>
							{
								//0xAD2FAC
								return;
							};
							if (isUnitOnly)
								handler = UnitDanceOnlyBackButton;
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
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
							while (m_popupUnitDanceWarning.WarningWindow.IsPlaying())
								yield return null;
							GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
							m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
							MenuScene.Instance.InputEnable();
							m_isConfirmedUnitDance = true;
							positiveAction = null;
							negativeAction = null;
						}
					}
				}
			}
			//LAB_00ad6ce0
			yield return null;
			if (endCallback != null)
				endCallback();
			yield return null;
		}

		// // RVA: -1 Offset: -1 Slot: 57
		protected abstract void OnClickDifficultyButton(int index);

		// // RVA: 0xAC9360 Offset: 0xAC9360 VA: 0xAC9360
		protected void DownloadCurrentMusic()
		{
			m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
			this.StartCoroutineWatched(Co_DownloadMusic(selectMusicData));
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
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PMGMMMGCEEI_Video == 0)
			{
				val = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CBLEFELBNDN_GetVideoQuality();
			}
			KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP = 0;
			lw = ILCCJNDFFOB.HHCJCDFCLOB;
			pre = 0;
			KDLPEDBKMID.HHCJCDFCLOB.OKJCGCOGDIA_DownloadSongDatas(musicData.KKPAHLMJKIH_WavId, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(musicData.GHBPLHBNMBK_FreeMusicId).KEFGPJBKAOD_WavId, val, GetDanceDivaCount());
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
			GameManager.Instance.StartCoroutineWatched(Co_CheckSimulationLive(endCallBack));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6AF4 Offset: 0x6F6AF4 VA: 0x6F6AF4
		// // RVA: 0xAC953C Offset: 0xAC953C VA: 0xAC953C
		private IEnumerator Co_CheckSimulationLive(Action<bool> endCallBack)
		{
			//0xAD5804
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket > 0)
			{
				if(endCallBack != null)
				{
					endCallBack(true);
				}
				yield break;
			}
			bool done = false;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("mvmode_check_popup_title"), SizeType.Small, Smart.Format(bk.GetMessageByLabel("mvmode_check_popup_text"), 1), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xAD2FB0
				return;
			}, null, null, null, endCallBaack:() =>
			{
				//0xAD3914
				done = true;
			});
			while(!done)
				yield return null;
		}

		// // RVA: 0xAC95E8 Offset: 0xAC95E8 VA: 0xAC95E8 Slot: 58
		protected virtual bool CurrentMusicDecisionCheck(bool isSimulation, Action cancelCallback, MKIKFJKPEHK viewBoostData, int selectIndex = 0)
		{
			if(viewBoostData == null)
			{
				if(selectMusicData.LHONOILACFL_IsWeeklyEvent)
				{
					if(selectMusicData.MOJMEFIENDM_WeeklyEventCount < 1)
					{
						OpenWeekRecoveryWindow((int recovery) =>
						{
							//0xAD3920
							selectMusicData.IEBGBOBPJMB(recovery);
							ApplyMusicInfo();
							VerticalMusicDataList.MusicListData m = currentMusicList.Find(selectMusicData.GHBPLHBNMBK_FreeMusicId, !isLine6Mode, isSimulation);
							if(m != null)
							{
								m.ViewMusic.IEBGBOBPJMB(recovery);
							}
						}, cancelCallback);
						return false;
					}
				}
				if (selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].BPLOEAHOPFI_Energy <= CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCLKMNGMIKC_GetCurrent())
					return true;
				OpenStaminaWindow(() =>
				{
					//0xAD3AC8
					OnClickPlayButton(isSimulation);
				}, cancelCallback);
				return false;
			}
			else
			{
				if (viewBoostData.EFFBJDMGIGO(selectIndex) != MKIKFJKPEHK.IMIDFBNGHCG.CNAMHABEOPF_1/*1*/)
					return true;
				OpenStaminaWindow(() => {
					//0xAD3B00
					DecideCurrentMusic(isSimulation);
				}, cancelCallback);
				return false;
			}
		}

		// // RVA: 0xAC9FF8 Offset: 0xAC9FF8 VA: 0xAC9FF8
		private void CheckBoostData(bool isSimulation, Action<bool> endCallback, Action cancelCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_CheckBoostData(isSimulation, endCallback, cancelCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6B6C Offset: 0x6F6B6C VA: 0x6F6B6C
		// // RVA: 0xACA0C8 Offset: 0xACA0C8 VA: 0xACA0C8
		private IEnumerator Co_CheckBoostData(bool isSimulation, Action<bool> endCallback, Action cancelCallback)
		{
			MKIKFJKPEHK viewBoostData;

			//0xAD49C0
			Database.Instance.gameSetup.ResetSelectedDashIndex();
			if (m_eventCtrl != null)
			{
				m_eventCtrl.OJGHCKMPJFP();
			}
			viewBoostData = new MKIKFJKPEHK();
			if(viewBoostData.DPICLLJJPAC(selectMusicData, (int)diff, isLine6Mode))
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				//selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].BPLOEAHOPFI_Energy
				PopupDashContentSetting.InitParam[] p = new PopupDashContentSetting.InitParam[viewBoostData.KLOOIJIDKGO_Cost.Count];
				for(int i = 0; i < viewBoostData.KLOOIJIDKGO_Cost.Count; i++)
				{
					p[i] = new PopupDashContentSetting.InitParam()
					{
						Rate = viewBoostData.BGIKOPLLDJB_Rate[i],
						Cost = viewBoostData.KLOOIJIDKGO_Cost[i]
					};
				}
				PopupDashContentSetting s = new PopupDashContentSetting();
				s.EventId = m_eventId;
				s.CostType = viewBoostData.NMKDLINPAFM_UseTicket ? LayoutPopupDash.CostType.Ticket : LayoutPopupDash.CostType.Energy;
				s.OwnValue = viewBoostData.DCLKMNGMIKC();
				s.Param = p;
				s.WindowSize = SizeType.Middle;
				s.TitleText = bk.GetMessageByLabel(viewBoostData.NMKDLINPAFM_UseTicket ? "popup_dash_ticket_title" : "popup_dash_energy_title");
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Play, Type = PopupButton.ButtonType.Live }
				};
				s.OnSelectCallback = (int index) =>
				{
					//0xAD2FB4
					Database.Instance.gameSetup.SetSelectedDashIndex(index);
				};
				bool cancel = false;
				bool done = false;
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xAD3B40
					if(type == PopupButton.ButtonType.Negative)
						cancel = true;
				}, null, null, null, endCallBaack:() =>
				{
					//0xAD3B50
					done = true;
				});
				while(!done)
					yield return null;
				if(cancel)
				{
					if(cancelCallback != null)
						cancelCallback();
					yield break;
				}
				MenuScene.Instance.InputDisable();
				viewBoostData.PPCLCOPGBBK(Database.Instance.gameSetup.SelectedDashIndex);
				if(!CurrentMusicDecisionCheck(isSimulation, cancelCallback, viewBoostData, Database.Instance.gameSetup.SelectedDashIndex))
				{
					//LAB_00ad4ff0
				}
				else
				{
					if(endCallback != null)
						endCallback(isSimulation);
				}
				while(MenuScene.Instance.DirtyChangeScene)
				{
					yield return null;
				}
				MenuScene.Instance.InputEnable();
			}
			else
			{
				if (!CurrentMusicDecisionCheck(isSimulation, cancelCallback, null, 0))
					yield break;
				if(endCallback != null)
					endCallback(isSimulation);
			}
		}

		// // RVA: 0xACA1C0 Offset: 0xACA1C0 VA: 0xACA1C0
		private void OnCancelDecideMusic()
		{
			m_isConfirmedUnitDance = false;
		}

		// // RVA: -1 Offset: -1 Slot: 59
		protected abstract void OnDecideCurrentMusic(ref MusicDecideInfo info);

		// // RVA: 0xACA1CC Offset: 0xACA1CC VA: 0xACA1CC
		private void DecideCurrentMusic(bool isSimulation)
		{
			m_musicDecideInfo = MusicDecideInfo.Empty;
			if(selectMusicData.OEILJHENAHN_PlayEventType == 10 || selectMusicData.OEILJHENAHN_PlayEventType == 4)
			{
				m_musicDecideInfo.overrideEnemyCenterSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.DCOALMMJDJK_OverrideCenterSkill;
				m_musicDecideInfo.overrideEnemyLiveSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.KKPLDFNDFDE_OverrideLiveSkill;
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(selectMusicData.EKANGPODCEP_EventId);
			}
			OnDecideCurrentMusic(ref m_musicDecideInfo);
			int onStageDivaNum = GetDanceDivaCount();
			Database.Instance.gameSetup.musicInfo.SetupInfoByFreeMusic(freeMusicId, diff, !selectMusicData.MNDFBBMNJGN_NoEnergy, m_musicDecideInfo.initParam, (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_GameEventType, (OHCAABOMEOF.KGOGMKMBCPP_EventType) selectMusicData.MFJKNCACBDG_OpenEventType, (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.OEILJHENAHN_PlayEventType, isSimulation, isLine6Mode, m_musicDecideInfo.missionText, m_musicDecideInfo.overrideEnemyCenterSkill, m_musicDecideInfo.overrideEnemyLiveSkill, selectMusicData.ALMOMLMCHNA_OtherEndTime, selectMusicData.IHPCKOMBGKJ_End, m_eventCtrl != null ? m_eventCtrl.PGIIDPEGGPI_EventId : 0, onStageDivaNum, m_musicDecideInfo.overrideCurrentTime);
			Database.Instance.selectedMusic.SetMusicData(selectMusicData);
			TransitionList.Type transition = TransitionList.Type.UNDEFINED;
			TransitionArgs args = null;
			if (selectMusicData.MNNHHJBBICA_GameEventType == 0)
			{
				//LAB_00aca904
				transition = TransitionList.Type.FRIEND_SELECT;
				if (isSimulation)
					transition = TransitionList.Type.SIMULATIONLIVE_SETTING;
			}
			else if(selectMusicData.MNNHHJBBICA_GameEventType == 1 || 
					selectMusicData.MNNHHJBBICA_GameEventType == 2)
			{
				transition = TransitionList.Type.FRIEND_SELECT;
			}
			else if(selectMusicData.MNNHHJBBICA_GameEventType == 3)
			{
				transition = TransitionList.Type.TEAM_SELECT;
				args = m_teamSelectSceneArgs;
			}
			else if(selectMusicData.MNNHHJBBICA_GameEventType == 14)
			{
				transition = TransitionList.Type.GODIVA_TEAM_SELECT;
				args = m_teamSelectSceneArgs;
			}
			else if(selectMusicData.MNNHHJBBICA_GameEventType == 11)
			{
				transition = TransitionList.Type.FRIEND_SELECT;
			}
			else
			{
				transition = TransitionList.Type.FRIEND_SELECT;
				if (isSimulation)
					transition = TransitionList.Type.SIMULATIONLIVE_SETTING;
			}
			MenuScene.Instance.Call(transition, args, true);
		}

		// // RVA: 0xACAA10 Offset: 0xACAA10 VA: 0xACAA10
		protected void OnClickPlayButton(bool isSimulation)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
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
				if(selectMusicData.POEGGBGOKGI_IsInfoLiveEntrance)
				{
					GotoRegularMusicSelect();
					return;
				}
				if(!openSimulationLive && isSimulation/* && !RuntimeSettings.CurrentSettings.ForceSimulationOpen*/)
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
					val = m_eventCtrl.PGIIDPEGGPI_EventId;
				if(!isSimulation)
				{
					if (!MenuScene.Instance.TryMusicPeriod(selectMusicData.IHPCKOMBGKJ_End, val, (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_GameEventType, isSimulation, MenuScene.MusicPeriodMess.MusicSelect))
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
					if(!MenuScene.Instance.TryMusicPeriod(selectMusicData.NNJNNCGGKMC_IsLimited ? selectMusicData.IHPCKOMBGKJ_End : selectMusicData.ALMOMLMCHNA_OtherEndTime, val, (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_GameEventType, isSimulation, MenuScene.MusicPeriodMess.MusicSelect))
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
			if (MenuScene.CheckDatelineAndAssetUpdate())
				return true;
			IBJAKJJICBC data = null;
			if (!listIsEmpty)
			{
				data = selectMusicData;
				VerticalMusicDataList.MusicListData data2 = selectMusicListData;
				bool b1 = true;
				if (!data2.IsSimulation || data.AHAEGEHKONB_GetOtherTimeLeft() != 0)
				{
					//LAB_00acb32c
					b1 = false;
					if(data.AJGCPCMLGKO_IsEvent && !m_isEventTimeLimit)
					{
						long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						b1 = data.AFCMIOIGAJN_EventInfo.PCCFAKEOBIC_CloseTime < time;
					}
				}
				if(data.LEBDMNIGOJB_IsScoreEvent)
				{
					IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.KPMNPGKKFJG/*6*/);
					if (ev != null && ev.FKKDIDMGLMI)
					{
						TodoLogger.LogError(TodoLogger.EventScore_4, "CheckEventLimit");
					}
				}
				if(b1)
				{
					TextPopupSetting setting = new TextPopupSetting();
					setting.TitleText = "";
					setting.IsCaption = false;
					setting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					setting.Text = MessageManager.Instance.GetMessage("menu", "popup_event_end_text_2");
					PopupWindowManager.Show(setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
					{
						//0xAD30E8
						MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}, null, null, null);
					return true;
				}
			}
			//LAB_00acb654
			return MenuScene.Instance.CheckEventLimit(data, true, true, m_eventStatus < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6/*6*/ ? KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5/*5*/ : KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/, m_eventId);
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
			int days, hours, minutes, seconds;
			MusicSelectSceneBase.ExtractRemainTime((int)remainSec, out days, out hours, out minutes, out seconds);
			musicDetail.SetEventTime(MusicSelectSceneBase.MakeRemainTime(days, hours, minutes, seconds), remainType);
		}

		// // RVA: 0xACE2F0 Offset: 0xACE2F0 VA: 0xACE2F0
		protected void ApplyEventBannerRemainTime(VerticalMusicSelectEventBanner eventBunner, long remainSec)
		{
			int days, hours, minutes, seconds;
			MusicSelectSceneBase.ExtractRemainTime((int)remainSec, out days, out hours, out minutes, out seconds);
			eventBunner.SetLimitTimeLabel(MusicSelectSceneBase.MakeRemainTime(days, hours, minutes, seconds));
		}

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
		private void OnWebViewClose()
		{
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xACED08 Offset: 0xACED08 VA: 0xACED08
		private void OnNetErrorToTitle()
		{
			MenuScene.Instance.GotoTitle();
		}

		// // RVA: 0xACEDA4 Offset: 0xACEDA4 VA: 0xACEDA4
		private MusicLockData GetLastStoryData()
		{
			MusicLockData data = new MusicLockData();
			List<LIEJFHMGNIA> l = LIEJFHMGNIA. FKDIMODKKJD(LIEJFHMGNIA.PJIJLMFBBCJ() - 1, true, true, false);
			if(l.Count > 0)
			{
				LIEJFHMGNIA data2 = l[l.Count - 1];
				if(!data2.MMEGDFPNONJ_HasDivaId)
				{
					for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA.Count; i++)
					{
                        LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA[i];
						if(dbStory.KLCIIHKFPPO_StoryMusicId == data2.KLCIIHKFPPO_StoryMusicId)
						{
							data.freeMusicId = dbStory.OMMEPCGNHFM_FreeMusicId2;
							data.lockDetail = data2.EJKPLJCMHMP_GetLockDetails();
							data.isLock = data2.HHBJAEOIGIH_IsLocked;
							return data;
						}
                    }
				}
			}
			return null;
		}

		// // RVA: 0xACF194 Offset: 0xACF194 VA: 0xACF194
		private bool CheckStoryMusic(int freeMusicId)
		{
			if(freeMusicId != 0)
			{
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA.Count; i++)
				{
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA[i].OMMEPCGNHFM_FreeMusicId2 == freeMusicId)
						return true;
				}
			}
			return false;
		}

		// // RVA: 0xACF30C Offset: 0xACF30C VA: 0xACF30C
		protected int GetLastStoryFreeMusicId()
		{
			//if (RuntimeSettings.CurrentSettings.ForceAllStoryMusicUnlock)
			//	return 9999;
			List<LAEGMENIEDB_Story.ALGOILKGAAH> storyList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA;
			int a = LIEJFHMGNIA.PJIJLMFBBCJ();
			List<LIEJFHMGNIA> list = LIEJFHMGNIA.FKDIMODKKJD(a - 1, true, true, false);
			if(list.Count > 0)
			{
				LIEJFHMGNIA data = list[list.Count - 1];
				if(!data.MMEGDFPNONJ_HasDivaId)
				{
					for(int i = 0; i < storyList.Count; i++)
					{
						LAEGMENIEDB_Story.ALGOILKGAAH story = storyList[i];
						if(story.KLCIIHKFPPO_StoryMusicId == data.KLCIIHKFPPO_StoryMusicId && !data.HHBJAEOIGIH_IsLocked)
						{
							return story.OMMEPCGNHFM_FreeMusicId2;
						}
					}
				}
			}
			return 0;
		}

		// // RVA: 0xACF5E8 Offset: 0xACF5E8 VA: 0xACF5E8
		protected void CheckSnsNotice()
		{
			if (!BIFNGFAIEIL.HHCJCDFCLOB.DNFPMBFNDCA())
				return;
			int snsId = BIFNGFAIEIL.HHCJCDFCLOB.FGGDEKAJCIF();
			if(snsId == 0)
				return;
			MenuScene.Instance.ShowSnsNotice(snsId, null);
			BIFNGFAIEIL.HHCJCDFCLOB.ALIANOFCAEI();
		}

		// // RVA: 0xACF730 Offset: 0xACF730 VA: 0xACF730
		protected void CheckOfferNotice()
		{
			if (KDHGBOOECKC.HHCJCDFCLOB.IOCBOGFFHFE.OAFPGJLCNFM_Cond == 0)
				return;
			MenuScene.Instance.ShowOfferNotice(null);
		}

		// // RVA: 0xAC3AA8 Offset: 0xAC3AA8 VA: 0xAC3AA8
		protected void AddNotice(Action action)
		{
			NoticeActionList.Add(action);
		}

		// // RVA: 0xAC3B28 Offset: 0xAC3B28 VA: 0xAC3B28
		protected void ShowNotice()
		{
			this.StartCoroutineWatched(Co_ShowNotice());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6BE4 Offset: 0x6F6BE4 VA: 0x6F6BE4
		// // RVA: 0xACF818 Offset: 0xACF818 VA: 0xACF818
		private IEnumerator Co_ShowNotice()
		{
			int i;

			//0x182F47C
			for(i = 0; i < NoticeActionList.Count; i++)
			{
				NoticeActionList[i]();
				GameManager.Instance.snsNotification.DirtyClose = false;
				while (GameManager.Instance.snsNotification.isActiveAndEnabled)
					yield return null;
				if (GameManager.Instance.snsNotification.DirtyClose)
					break;
			}
			NoticeActionList.Clear();
		}

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
		protected void OnClickEventDetailButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(!CheckEventLimit())
			{
				if(selectMusicData.LHONOILACFL_IsWeeklyEvent)
				{
					MenuScene.Instance.InputDisable();
					MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(selectMusicData.CIOCOOMCMKO(selectMusicData.IHKFMJDOBAH_WeekDayAttr), OnWebViewClose, OnNetErrorToTitle);
				}
				else
				{
					if (selectMusicData.LEBDMNIGOJB_IsScoreEvent)
					{
						MenuScene.Instance.InputDisable();
						//m_scoreEventCtrl.HAAEJDGMICH(0, OnWebViewClose, OnNetErrorToTitle);
					}
				}
			}
		}

		// // RVA: 0xAD012C Offset: 0xAD012C VA: 0xAD012C
		protected void OnClickRankingButton(IBJAKJJICBC musicData)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(musicData.LEBDMNIGOJB_IsScoreEvent)
			{
				OnClickEventRankingButton(musicData);
			}
			else
			{
				MenuScene.Instance.Call(TransitionList.Type.REGULAR_RANKING, new RegularRankingSceneArgs(musicData), true);
			}
		}

		// // RVA: 0xAD03FC Offset: 0xAD03FC VA: 0xAD03FC
		protected void OnClickRewardButton(Action openRewardWindowFunc)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if (openRewardWindowFunc != null)
				openRewardWindowFunc();
		}

		// // RVA: 0xAD0524 Offset: 0xAD0524 VA: 0xAD0524
		protected void OnClickEventRewardButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(CheckEventLimit())
				return;
            IKDICBBFBMI_EventBase ctrl = m_eventCtrl;
            if (selectMusicData.LEBDMNIGOJB_IsScoreEvent)
				ctrl = m_scoreEventCtrl;
			this.StartCoroutineWatched(PopupRewardEvCheck.Co_ShowPopup(ctrl, transform, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xAD31A0
				return;
			}));
		}

		// // RVA: 0xAD07C8 Offset: 0xAD07C8 VA: 0xAD07C8
		protected void OnClickDetailButton(VerticalMusicDataList.MusicListData musicData, Difficulty.Type difficulty)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			OpenMusicDetailWindow(musicData, difficulty);
		}

		// // RVA: 0xAD0AC0 Offset: 0xAD0AC0 VA: 0xAD0AC0
		protected void OnClickEnemyDetailButton(IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			OpenEnemyDetailWindow(musicData, difficulty);
		}

		// // RVA: 0xAD0290 Offset: 0xAD0290 VA: 0xAD0290
		private void OnClickEventRankingButton(IBJAKJJICBC musicData)
		{
			if(!CheckEventLimit())
			{
				EventRankingSceneArgs args;
				if(musicData.LEBDMNIGOJB_IsScoreEvent)
				{
					args = new EventRankingSceneArgs(m_scoreEventCtrl, false, 0, 0);
				}
				else
				{
					args = new EventRankingSceneArgs(m_eventCtrl, false, 0, 0);
				}
				MenuScene.Instance.Call(TransitionList.Type.EVENT_RANKING, args, true);
			}
		}

		// // RVA: 0xAD0D34 Offset: 0xAD0D34 VA: 0xAD0D34
		// protected void OnClickEventRankingButton(IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP eventType, KGCNCBOKCBA.GNENJEHKMHD eventStatus, int eventId, IKDICBBFBMI eventCtrl, int selectDiva = 0) { }

		// // RVA: 0xAD0E84 Offset: 0xAD0E84 VA: 0xAD0E84
		// protected void OnClickEventRewardButton(MonoBehaviour owner, IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP eventType, KGCNCBOKCBA.GNENJEHKMHD eventStatus, int eventId, IKDICBBFBMI eventCtrl) { }

		// // RVA: 0xAD1110 Offset: 0xAD1110 VA: 0xAD1110
		// protected void OnClickStoryButton(IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP eventType, KGCNCBOKCBA.GNENJEHKMHD eventStatus, int eventId, IKDICBBFBMI eventCtrl) { }

		// // RVA: 0xAD128C Offset: 0xAD128C VA: 0xAD128C
		// protected void OnClickMissionButton() { }

		// // RVA: 0xAD1410 Offset: 0xAD1410 VA: 0xAD1410
		protected void OnClickMusicRate()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseOfferNotice();
			MenuScene.Instance.Call(TransitionList.Type.MUSIC_RATE, null, true);
		}

		// // RVA: 0xAD158C Offset: 0xAD158C VA: 0xAD158C
		protected void OnClickMusicBookMark(Action okCallBack)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			OpenMusicBookMarkWindow(okCallBack, true);
		}

		// // RVA: 0xAD1ABC Offset: 0xAD1ABC VA: 0xAD1ABC
		// protected void OnClickEventDetailButton(IKDICBBFBMI scoreEventCtrl) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6C5C Offset: 0x6F6C5C VA: 0x6F6C5C
		// // RVA: 0xAC3990 Offset: 0xAC3990 VA: 0xAC3990
		protected IEnumerator Co_CheckUnlockAndAddMusic()
		{
			//0xAD70A0
			bool isShowed1 = false;
			MenuScene.Instance.InputDisable();
			yield return PopupUnlock.Show(PopupUnlock.eSceneType.FreeMusicSelect1, (int label) =>
			{
				//0xAD3D64
				isShowed1 = label != 0;
			}, true, null);
			MenuScene.Instance.InputEnable();
			yield return TryShow6LineModeTutorial();
			bool isShowed2 = false;
			MenuScene.Instance.InputDisable();
			yield return PopupUnlock.Show(PopupUnlock.eSceneType.FreeMusicSelect2, (int label) =>
			{
				//0xAD3D74
				isShowed2 = label != 0;
			}, true, null);
			MenuScene.Instance.InputEnable();
			if (!isShowed1 && !isShowed2)
				yield break;
			MenuScene.Instance.InputDisable();
			bool isWait = true;
			MenuScene.Save(() =>
			{
				//0xAD3D8C
				isWait = false;
			}, null);
			while (isWait)
				yield return null;
			BIFNGFAIEIL.HHCJCDFCLOB.DNKCCHCEPBH(false);
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xACD40C Offset: 0xACD40C VA: 0xACD40C
		protected void OpenLockSimulationLiveWindow()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			StringBuilder str = new StringBuilder(64);
			str.Append(bk.GetMessageByLabel("story_unlock_01"));
			str.Append("\n\n");
			str.AppendFormat(bk.GetMessageByLabel("popup_music_unlock_text05"), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("mv_player_level", 5));
			s.Text = str.ToString();
			s.WindowSize = SizeType.Small;
			s.IsCaption = false;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, null, null, null, null);
		}

		// // RVA: 0xACD850 Offset: 0xACD850 VA: 0xACD850
		protected void OpenLockMusicInfoWindow()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string title = bk.GetMessageByLabel("popup_music_unlock_title");
			StringBuilder str = new StringBuilder(200);
			JPCKBFBCJKD m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.LLJOPJMIGPD(freeMusicId);
			if(m == null)
			{
				MusicLockData lockData = GetLastStoryData();
				if(lockData != null && selectMusicData.GHBPLHBNMBK_FreeMusicId == lockData.freeMusicId)
				{
					if(!lockData.isLock)
					{
						GotoStorySelect();
					}
					else
					{
						str.Append(lockData.lockDetail);
					}
				}
				else
				{
					if(CheckStoryMusic(selectMusicData.GHBPLHBNMBK_FreeMusicId))
					{
						str.AppendFormat(bk.GetMessageByLabel("popup_music_unlock_text04"), selectMusicData.NEDBBJDAFBH_MusicName);
					}
					else
					{
						str.AppendFormat(bk.GetMessageByLabel("popup_music_unlock_text05"), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("multi_dance_player_level", 3));
					}
				}
			}
			else
			{
				str.Append(bk.GetMessageByLabel("popup_music_unlock_text01"));
				str.Append("\n\n");
				str.AppendFormat(bk.GetMessageByLabel("popup_music_unlock_text02"), m.ADBHJCDINFL);
				str.Append("\n\n");
				str.Append(bk.GetMessageByLabel("popup_music_unlock_text03"));
				str.Append("\n\n");
			}
			if(str.Length != 0)
			{
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = title;
				s.Text = str.ToString();
				s.WindowSize = SizeType.Middle;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xAD31A8
					return;
				}, null, null, null);
			}
		}

		// // RVA: 0xAD1F18 Offset: 0xAD1F18 VA: 0xAD1F18
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
			m_rewardPopupSetting.isLine6Mode = isLine6Mode;
			m_rewardPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_rewardPopupSetting, null, null, null, null);
		}

		// // RVA: 0xAD08F4 Offset: 0xAD08F4 VA: 0xAD08F4
		protected void OpenMusicDetailWindow(VerticalMusicDataList.MusicListData musicData, Difficulty.Type difficulty)
		{
			MenuScene.Instance.MusicPopupWindowControl.Show(this, MusicPopupWindowControl.CallType.MusicSelect, musicData.ViewMusic.DLAEJOBELBH_MusicId,
				musicData.ViewMusic.MGJKEJHEBPO_DiffInfos[(int)difficulty].HPBPDHPIBGN_EnemyData, null, musicData.IsSimulation);
		}

		// // RVA: 0xAD0BEC Offset: 0xAD0BEC VA: 0xAD0BEC
		protected void OpenEnemyDetailWindow(IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			MenuScene.Instance.MusicPopupWindowControl.ShowEnemyInfo(this, MusicPopupWindowControl.CallType.MusicSelect, musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].HPBPDHPIBGN_EnemyData,
				null);
		}

		// // RVA: 0xAC9928 Offset: 0xAC9928 VA: 0xAC9928
		protected void OpenWeekRecoveryWindow(Action<int> recoveryCallback, Action cancelCallback)
		{
			MenuScene.Instance.InputDisable();
			PopupWindowManager.OpenWeekRecoveryWindow(freeMusicId, (int recovery) =>
			{
				//0xAD3D98
				MenuScene.Instance.InputEnable();
				if(recoveryCallback != null)
					recoveryCallback(recovery);
			}, () =>
			{
				//0xAD3E60
				MenuScene.Instance.InputEnable();
				if(cancelCallback != null)
					cancelCallback();
			}, () =>
			{
				//0xAD31AC
				MenuScene.Instance.GotoTitle();
			}, (TransitionList.Type gotoSceneType) =>
			{
				//0xAD3248
				if(gotoSceneType == TransitionList.Type.TITLE)
				{
					MenuScene.Instance.GotoTitle();
				}
				else if(gotoSceneType == TransitionList.Type.LOGIN_BONUS)
				{
					MenuScene.Instance.GotoLoginBonus();
				}
				MenuScene.Instance.InputEnable();
			});
		}

		// // RVA: 0xAC9C88 Offset: 0xAC9C88 VA: 0xAC9C88
		protected void OpenStaminaWindow(Action recoveryCallback, Action cancelCallback)
		{
			MenuScene.Instance.InputDisable();
			PopupWindowManager.OpenStaminaWindow(MenuScene.Instance.DenomControl, () =>
			{
				//0xAD3F14
				MenuScene.Instance.InputEnable();
				if (recoveryCallback != null)
					recoveryCallback();
			}, () =>
			{
				//0xAD3FC8
				MenuScene.Instance.InputEnable();
				if (cancelCallback != null)
					cancelCallback();
			}, () =>
			{
				//0xAD33A4
				MenuScene.Instance.GotoTitle();
			}, (TransitionList.Type gotoSceneType) =>
			{
				//0xAD3440
				if(gotoSceneType == TransitionList.Type.TITLE)
				{
					MenuScene.Instance.GotoTitle();
				}
				else if(gotoSceneType == TransitionList.Type.LOGIN_BONUS)
				{
					MenuScene.Instance.GotoLoginBonus();
				}
				MenuScene.Instance.InputEnable();
			});
		}

		// // RVA: 0xAD16B4 Offset: 0xAD16B4 VA: 0xAD16B4
		protected void OpenMusicBookMarkWindow(Action okCallBack, bool initialze)
		{
			MessageBank msgBank = MessageManager.Instance.GetBank("menu");
			m_musicBookMarkSetting.WindowSize = SizeType.Middle;
			m_musicBookMarkSetting.SetParent(transform);
			m_musicBookMarkSetting.TitleText = msgBank.GetMessageByLabel("popup_music_bookmark_title");
			m_musicBookMarkSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_musicBookMarkSetting.SelectMusicData = selectMusicData;
			m_musicBookMarkSetting.VerticalMusicDataList = originalMusicList;
			m_musicBookMarkSetting.Initialize = initialze;
			PopupWindowManager.Show(m_musicBookMarkSetting, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xAD407C
				if(label == PopupButton.ButtonLabel.Cancel)
				{
					if(m_musicBookMarkSetting.IsChangeBookMark())
					{
						TextPopupSetting s = new TextPopupSetting();
						s.TitleText = msgBank.GetMessageByLabel("popup_music_input_bookmarkname_deletecheck_title");
						s.Text = msgBank.GetMessageByLabel("popup_music_input_bookmarkname_deletecheck_text_01");
						s.Buttons = new ButtonInfo[2]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
						};
						PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
						{
							//0xAD4580
							if (l != PopupButton.ButtonLabel.Cancel)
								return;
							OpenMusicBookMarkWindow(okCallBack, false);
						}, null, null, null);
					}
				}
				else if(label == PopupButton.ButtonLabel.Ok)
				{
					m_musicBookMarkSetting.SelectMusicSetMusicBookMark();
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0xAD456C
						if (okCallBack != null)
							okCallBack();
					}, () =>
					{
						//0xAD359C
						MenuScene.Instance.GotoTitle();
					}, null);
				}
			}, null, null, null);
		}

		// // RVA: 0xACD354 Offset: 0xACD354 VA: 0xACD354
		private void GotoRegularMusicSelect()
		{
			MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, 0);
		}

		// // RVA: 0xACD2B0 Offset: 0xACD2B0 VA: 0xACD2B0
		private void GotoEventMiniGame(int miniGameId)
		{
			MenuScene.Instance.GotoMiniGame(miniGameId);
		}

		// // RVA: 0xACBE10 Offset: 0xACBE10 VA: 0xACBE10
		protected void GotoEventMusicSelect(int eventId)
		{
			if(eventId > 0)
			{
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventId);
				if(ev != null && ev.FBLGGLDPFDF_CanShowStartAdventure())
				{
					GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData dbAdv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(ev.GFIBLLLHMPD_StartAdventureId);
					if(dbAdv != null)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(ev.GFIBLLLHMPD_StartAdventureId);
						ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(ev.GFIBLLLHMPD_StartAdventureId,  OAGBCBBHMPF.DKAMMIHBINF.IDINJDEBPKP_6);
						Database.Instance.advSetup.Setup(dbAdv.KKPPFAHFOJI_FileId);
						Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTMUSICSELECT, new AdvSetupParam());
						MenuScene.Instance.GotoAdventure();
						return;
					}
				}
            }
			MenuScene.Instance.Mount(TransitionUniqueId.EVENTMUSICSELECT, new EventMusicSelectSceneArgs(eventId, isLine6Mode, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0xACB9AC Offset: 0xACB9AC VA: 0xACB9AC
		protected void GotoEventQuest(int eventId)
		{
			TodoLogger.LogError(TodoLogger.EventQuest_6, "GotoEventQuest");
		}

		// // RVA: 0xACC274 Offset: 0xACC274 VA: 0xACC274
		protected void GotoEventBattle(int eventId)
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

		// // RVA: 0xACC6D8 Offset: 0xACC6D8 VA: 0xACC6D8
		protected void GotoEventRaid(int eventId)
		{
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GotoEventRaid");
		}

		// // RVA: 0xACCE4C Offset: 0xACCE4C VA: 0xACCE4C
		protected void GotoEventGoDiva(int eventId)
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

		// // RVA: 0xAD1E40 Offset: 0xAD1E40 VA: 0xAD1E40
		private void GotoStorySelect()
		{
			MenuScene.Instance.Mount(TransitionUniqueId.STORYSELECT, new StorySelectArgs(), true, 0);
		}

		// // RVA: 0xAD22C0 Offset: 0xAD22C0 VA: 0xAD22C0
		private bool IsEnableUnitDance(bool line6Mode = false)
		{
			if(TransitionName == TransitionList.Type.EVENT_QUEST)
			{
				if(m_eventCtrl != null && m_eventCtrl.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6/*6*/ && selectMusicData != null)
				{
					return selectMusicData.JAPLKHPLOOF(m_eventCtrl.HIDHLFCBIDE_EventType);
				}
			}
			else
			{
				OHCAABOMEOF.KGOGMKMBCPP_EventType b = 0;
				if (TransitionName == TransitionList.Type.EVENT_BATTLE)
				{
					b = OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle;
				}
				if (TransitionName == TransitionList.Type.EVENT_MUSIC_SELECT)
				{
					b = OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection;
				}
				if(b == 0 || m_eventCtrl == null || m_eventCtrl.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6/*6*/)
				{
					if(musicListCount > 0)
					{
						for(int i = 0; i < musicListCount; i++)
						{
							VerticalMusicDataList l = GetMusicList(i);
							List<VerticalMusicDataList.MusicListData> list = l.GetList(line6Mode, false);
							for(int j = 0; j < list.Count; j++)
							{
								if(list[j].ViewMusic.JAPLKHPLOOF(b))
								{
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// // RVA: 0xAC37D8 Offset: 0xAC37D8 VA: 0xAC37D8
		protected bool CanDoUnitDanceFocus(bool line6Mode = false)
		{
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.ODKIHPBEOEC_IsTrue(48))
				return false;
			return IsEnableUnitDance(line6Mode);
		}

		// // RVA: 0xAC7CC0 Offset: 0xAC7CC0 VA: 0xAC7CC0
		protected bool SelectUnitDanceFocus(out int freeMusicId, out FreeCategoryId.Type category, ref bool line6Mode, bool isSimulation, OHCAABOMEOF.KGOGMKMBCPP_EventType eventCategory)
		{
			freeMusicId = 0;
			category = FreeCategoryId.Type.None;
			bool isLine6 = line6Mode;
			if(!CanDoUnitDanceFocus(line6Mode))
			{
				if (!CanDoUnitDanceFocus(line6Mode))
					return false;
				line6Mode = !line6Mode;
			}
			for (int i = 0; i < musicListCount; i++)
			{
				VerticalMusicDataList l = GetMusicList(i);
				for (int j = 0; j < l.GetCount(line6Mode, isSimulation); j++)
				{
					VerticalMusicDataList.MusicListData data = l.Get(j, line6Mode, isSimulation);
					if (data.ViewMusic.JAPLKHPLOOF(eventCategory))
					{
						if (data.IsOpen)
						{
							if (freeMusicId == 0)
							{
								freeMusicId = data.ViewMusic.GHBPLHBNMBK_FreeMusicId;
							}
							else
							{
								if (freeMusicId <= data.ViewMusic.GHBPLHBNMBK_FreeMusicId)
								{
									;
								}
								else
								{
									freeMusicId = data.ViewMusic.GHBPLHBNMBK_FreeMusicId;
								}
							}
							if (i != 0)
								category = FreeCategoryId.Type.Event;
							else
								category = FreeCategoryId.Type.None;
							return true;
						}
					}
				}
			}
			
			return false;
		}

		// // RVA: 0xAD2568 Offset: 0xAD2568 VA: 0xAD2568
		// protected void SetupHelp(ref VerticalMusicSelectSceneBase.EventHelpInfo helpInfo, IKDICBBFBMI eventCtrl) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6CD4 Offset: 0x6F6CD4 VA: 0x6F6CD4
		// // RVA: 0xAD28EC Offset: 0xAD28EC VA: 0xAD28EC
		// protected IEnumerator Co_ShowHelp(MonoBehaviour owner, VerticalMusicSelectSceneBase.EventHelpInfo helpInfo) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6D4C Offset: 0x6F6D4C VA: 0x6F6D4C
		// // RVA: 0xAC3904 Offset: 0xAC3904 VA: 0xAC3904
		protected IEnumerator TryShowUnitDanceTutorial()
		{
			//0xAD8B8C
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_UnitDance));
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.RaycastEnable();
		}

		// // RVA: 0xAD29DC Offset: 0xAD29DC VA: 0xAD29DC
		protected bool CheckTutorialFunc_UnitDance(TutorialConditionId conditionId)
		{
			return !GameManager.Instance.IsTutorial && conditionId == TutorialConditionId.Condition60 && IsEnableUnitDance(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6DC4 Offset: 0x6F6DC4 VA: 0x6F6DC4
		// // RVA: 0xAD2AA0 Offset: 0xAD2AA0 VA: 0xAD2AA0
		protected IEnumerator TryShow6LineModeTutorial()
		{
			//0xAD88EC
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_6Line));
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.RaycastEnable();
		}

		// // RVA: 0xAD2B4C Offset: 0xAD2B4C VA: 0xAD2B4C
		protected bool CheckTutorialFunc_6Line(TutorialConditionId conditionId)
		{
			return !GameManager.Instance.IsTutorial && conditionId == TutorialConditionId.Condition69 && IBJAKJJICBC.KGJJCAKCMLO();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6E3C Offset: 0x6F6E3C VA: 0x6F6E3C
		// // RVA: 0xAC3A1C Offset: 0xAC3A1C VA: 0xAC3A1C
		protected IEnumerator TryShowUtaRateTutorial()
		{
			//0xAD8E2C
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_UtaRate));
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.RaycastEnable();
		}

		// // RVA: 0xAD2C28 Offset: 0xAD2C28 VA: 0xAD2C28
		protected bool CheckTutorialFunc_UtaRate(TutorialConditionId conditionId)
		{
			return !GameManager.Instance.IsTutorial && !QuestUtility.IsBeginnerQuest() && conditionId == TutorialConditionId.Condition85;
		}
	}
}
