using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game;
using XeSys.uGUI;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGamePlayer : MonoBehaviour
	{
		private enum TrackLineType
		{
			LeftOut = 0,
			LeftIn = 2,
			RightIn = 2,
			RightOut = 3,
			Line1 = 0,
			Line2 = 2,
			Line3 = 2,
			Line4 = 3,
			LineCount = 4,
			LineGroupLeft = 0,
			LineGroupRight = 1,
			LineGroupCount = 2
		}

		private enum EventFireType
		{
			Val_PlayerCutInStart = 0,
			Val_EnemyCutInStart = 1,
			Val_EnemyLockOnStart = 2,
			Num = 3
		}
 
		public class Setting
		{
			public enum VMode
			{
				None = 0,
				Normal = 1,
				Valkyrie = 2
			}

			public enum DMode
			{
				None = 0,
				Normal = 1,
				Diva = 2,
				DivaAwake = 3
			}

			public VMode m_mode_vl; // 0x8
			public DMode m_mode_dv; // 0xC
			public bool m_enable_cutin; // 0x10
			public bool m_visible_diva; // 0x11

			// RVA: 0xBF4724 Offset: 0xBF4724 VA: 0xBF4724
			public Setting()
			{
				m_enable_cutin = true;
				m_visible_diva = false; // ??
				//.m_enable_cutin = 0x101;
			}
		}

		public class SettingMV
		{
			public bool m_enable; // 0x8
			public bool m_mode_valkyrie; // 0x9
			public bool m_mode_diva; // 0xA
			public bool m_show_notes; // 0xB

			// RVA: 0xBF4734 Offset: 0xBF4734 VA: 0xBF4734
			public SettingMV()
			{
				m_show_notes = true;
			}
		}

		public class BackupSaveData
		{
			public bool m_enable; // 0x8
			public ILDKBCLAFPB.MPHNGGECENI m_option; // 0xC
		}
 
		private enum NoteSEType
		{
			Exempt = 0,
			LongLoop = 1,
			Bad = 2,
			Good = 3,
			Great = 4,
			Perfect = 5,
			FlickGreat = 6,
			FlickPerfect = 7,
			Num = 8
		}

		private class ActiveSkillRestartTimer
		{
			public enum Step
			{
				None = 0,
				WaitEnd = 1,
				WaitTime = 2,
				WaitRestart = 3
			}

			public RhythmGamePlayer.ActiveSkillRestartTimer.Step m_step; // 0x8
			public int m_msec_st; // 0xC
			public int m_msec_max; // 0x10
		}
		
		public static readonly Color IntroEndFadeColor; // 0x0
		public static readonly Color ValkyrieStartFadeColor; // 0x10
		public static readonly Color DivaModeEndFadeColor; // 0x20
		public const float DivaModeEndFadeOutSec = 0,5;
		public const float DivaModeEndFadeInSec = 0,5;
		[SerializeField]
		private GameDivaObject gameDivaObject; // 0x18
		[SerializeField]
		public GameDivaObject[] subDivaObject; // 0x1C
		[SerializeField]
		private RhythmGamePerformer gamePerformer; // 0x20
		[SerializeField]
		private RhythmGameUIController uiController; // 0x24
		public CriAtomExPlayback bgmPlayback; // 0x28
		private CriAtomExPlayback voicePlayback; // 0x2C
		private CriAtomExPlayback[] loopSEPlayback; // 0x44
		private NotesSoundPlayer notesSoundPlayer; // 0x48
		[SerializeField]
		private RhythmGameScene scene; // 0x4C
		[SerializeField]
		private RNoteOwner rNoteOwner; // 0x50
		private RhythmGameConsts.NoteResultParam_Excellent m_NoteResultParam_Excellent; // 0x54
		private RhythmGameConsts.NoteParam_CenterLiveSkill m_NoteParam_CLiveSkill; // 0x58
		private RhythmGameConsts.NoteParam_EventItem m_NoteParam_EventItem; // 0x5C
		private RhythmGameSpecialNotesAssigner.AssignInfo m_NoteAssingInfo; // 0x60
		private SkillOwner skillOwner; // 0x68
		private BuffEffectOwner buffOwner; // 0x6C
		private RhythmGameFlow gameFlow; // 0x70
		private bool isPauseRequest; // 0x74
		private bool isResetRequest; // 0x75
		private bool isChangeSequenceRequest; // 0x76
		private bool isVisiblePauseWindow; // 0x77
		private bool isIgnorePlayNotesSE; // 0x78
		private int totalComboNum; // 0x7C
		public int noteOffsetMillisec; // 0x80
		public int currentRawMusicMillisec; // 0x84
		public int continueCount; // 0x88
		private int tutorialPopupStartTime; // 0x8C
		[SerializeField]
		private CRIAtomMemoryPoolInfo memPoolInfo; // 0x90
		[SerializeField]
		private MusicCameraObject musicCameraObject; // 0x94
		[SerializeField]
		private StageObject stageObject; // 0x98
		[SerializeField]
		private GameValkyrieObject valkyrieObject; // 0x9C
		[SerializeField]
		private MusicIntroObject musicIntroObject; // 0xA0
		[SerializeField]
		private ValkyrieModeObject valkyrieModeObject; // 0xA4
		[SerializeField]
		private DivaModeObject divaModeObject; // 0xA8
		private List<StageLightingObject> stageLightingObjectList; // 0xAC
		private List<StageLightingAddObject> stageLightingAddObjectList; // 0xB0
		private List<StageExtensionObject> stageExtensionObjectList; // 0xB4
		private List<DivaExtensionObject> divaExtensionObjectList; // 0xB8
		private List<DivaCutinObject> divaCutinObjectList; // 0xBC
		private List<MusicCameraCutinObject> musicCameraCutinObjectList; // 0xC0
		[SerializeField]
		private LowModeBackgroundObject lowModeBackgroundObject; // 0xC4
		[SerializeField]
		private Camera mode3dCamera; // 0xC8
		[SerializeField]
		private Camera mode2dCamera; // 0xCC
		[SerializeField]
		private GameObject objectRoot3dLayer; // 0xD0
		[SerializeField]
		private GameObject objectRoot2dLayer; // 0xD4
		[SerializeField]
		private UGUIFader uguiFader; // 0xD8
		[SerializeField]
		private MeshRenderer dimmer3dMesh; // 0xDC
		private BattleEventResultVoice battleEventResultVoice; // 0x138
		private BitArray eventFireFlags; // 0x13C
		private List<int> dropItemList; // 0x140
		private int[] dropItemRarityCount; // 0x144
		private RhythmGameResource resource; // 0x148
		private Action updater; // 0x14C
		private List<RNoteObject> preJudgeValkyrieNotes; // 0x150
		private bool skillTouched; // 0x154
		private bool touchedCenterLiveSkill; // 0x155
		private bool touchedEventItem; // 0x156
		private List<int> liveSkillActivateCountList; // 0x158
		private RhythmGamePlayLogger logger; // 0x15C
		private int m_bit_note_result; // 0x160
		private int[] noteTouchSEIndex; // 0x164
		private const int BattleEventVoiceNum = 3;
		private ActiveSkillRestartTimer activeSkillRestartTimer; // 0x168
		public static bool IsLowQualityMode; // 0x30

		public Setting setting { get; set; }  // 0xC
		public SettingMV setting_mv { get; set; } // 0x10
		public BackupSaveData backupSaveData { get; set; } // 0x14
		public MusicData musicData { get; set; } // get_musicData 0x9AF428 // set_musicData 0x9AF44C 
		public BgmPlayer bgmPlayer { get; set; } // get_bgmPlayer 0x9AF450 // set_bgmPlayer 0x9AF484 
		public int musicMillisecLength { get; set; } // 0x30
		public int notesMillisec { get; set; } // 0x34
		public int deviceMillisec { get; set; } // 0x38
		public float deviceSec { get; set; } // 0x3C
		public int musicRequestChangeMillisec { get; set; } // 0x40
		public RhythmGameStatus status { get; set; } // 0x64
		public RhythmGameScoreEvent introFadeEvent { get; set; } // 0xE0
		public RhythmGameScoreEvent normalModeEndEvent { get; set; } // 0xE4
		public RhythmGameScoreEvent valkyrieStartHUDEvent { get; set; } // 0xE8
		public RhythmGameScoreEvent valkyriePreFadeEvent { get; set; } // 0xEC
		public RhythmGameScoreEvent valkyrieCutsceneStartEvent { get; set; } // 0xF0
		public RhythmGameScoreEvent valkyrieModeStartEvent { get; set; } // 0xF4
		public RhythmGameScoreEvent valkyrieCutsceneEndEvent { get; set; } // 0xF8
		public RhythmGameScoreEvent valkyrieModeEndEvent { get; set; } // 0xFC
		public RhythmGameScoreEvent divaCutsceneStartEvent { get; set; } // 0x100
		public RhythmGameScoreEvent divaModeStartEvent { get; set; } // 0x104
		public RhythmGameScoreEvent rhythmGameResultStartEvent { get; set; } // 0x108
		public RhythmGameScoreEvent tutorialOneEndEvent { get; set; } // 0x10C
		public RhythmGameScoreEvent tutorialTwoFoceFWaveMaxEvent { get; set; } // 0x110
		public RhythmGameScoreEvent tutorialTwoFoceEnemyDefeatEvent { get; set; } // 0x114
		public RhythmGameScoreEvent tutorialTwoModeDescriptionEvent { get; set; } // 0x118
		public RhythmGameScoreEvent tutorialTwoActiveSkillGuideEvent { get; set; } // 0x11C
		public RhythmGameScoreEvent battleEventResult01 { get; set; } // 0x120
		public RhythmGameScoreEvent battleEventResult02 { get; set; } // 0x124
		public RhythmGameScoreEvent mvPilotCutinFirstEvent { get; set; } // 0x128
		public RhythmGameScoreEvent mvPilotCutinSecondEvent { get; set; } // 0x12C
		public RhythmGameCheerSoundOrderer soundCheerOrderer { get; set; } // 0x130
		public RhythmGameVoicePlayer voicePlayer { get; set; } // 0x134
		public BattleEventResultVoice BattleEventResultVoide { get; } // get_BattleEventResultVoide 0x9AF640 

		// RVA: 0x9AF648 Offset: 0x9AF648 VA: 0x9AF648
		private void Awake()
		{
			resource = gameObject.AddComponent<RhythmGameResource>();
			uiController.OnAwake();
			dimmer3dMesh.gameObject.SetActive(false);
		}

		// RVA: 0x9AF734 Offset: 0x9AF734 VA: 0x9AF734
		private void Start()
		{
			InitializeSetting();
			Action endAction = XeApp.Game.RhythmGame.RhythmGamePlayer.ClearEndRhythmGame;
			if(XeApp.Game.GameManager.Instance.IsTutorial)
			{
				endAction = XeApp.Game.RhythmGame.RhythmGamePlayer.TutorialClearEndRhythmGame;
			}
			int difficulty = XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo.difficultyType;
			Action loadedAction = XeApp.Game.RhythmGame.RhythmGamePlayer.LoadedRhythmGame;
			Action beginAction = XeApp.Game.RhythmGame.RhythmGamePlayer.StartRhythmGame;
			Action errorAction = XeApp.Game.RhythmGame.RhythmGamePlayer.GameStartErrorToTitleAction;
			gameFlow = new RhythmGameFlow(resource, loadedAction, difficulty, beginAction, this, uiController, endAction, errorAction);
			scene.onChangeScene = XeApp.Game.RhythmGame.RhythmGamePlayer.OnChangeScene;
			uiController.OnStart();
			updater = InitializeTask;
		}

		// // RVA: 0x9B0660 Offset: 0x9B0660 VA: 0x9B0660
		private void Update()
		{
			if(updater != null)
				updater();
			gameFlow.OnUpdate();
		}

		// // RVA: 0x9B06A4 Offset: 0x9B06A4 VA: 0x9B06A4
		private void LateUpdate()
		{
			if(!scene.isReady)
				return;
			
			LateUpdateTask();
		}

		// // RVA: 0x9B07B8 Offset: 0x9B07B8 VA: 0x9B07B8
		private void OnDestroy()
		{
			if(!XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.MNJOLLGPMPI())
			{
				XeApp.Game.GameManager.Instance.PopupCanvas.worldCamera.clearFlags(4);
			}
			RestoreSave();
		}

		// // RVA: 0x9B0958 Offset: 0x9B0958 VA: 0x9B0958
		private void InitializeTask()
		{
			if(!scene.isReady)
				return;
			Initialize();
			updater = UpdateTask;
		}

		// // RVA: 0x9B0AE4 Offset: 0x9B0AE4 VA: 0x9B0AE4
		private void UpdateTask()
		{
			//!!!
		}

		// // RVA: 0x9B06DC Offset: 0x9B06DC VA: 0x9B06DC
		private void LateUpdateTask()
		{
			bool isVolumeZero = isIgnorePlayNotesSE;
			if(NotesSoundPlayer.isNewNoteSoundEnable)
			{
				notesSoundPlayer.PostSetup(bgmPlayer, isVolumeZero);
			}
			ApplyChangeMusicSequenceTime();
		}

		// // RVA: 0x9B3334 Offset: 0x9B3334 VA: 0x9B3334
		// private void OnApplicationPause(bool pauseStatus) { }

		// // RVA: 0x9B0A08 Offset: 0x9B0A08 VA: 0x9B0A08
		private void Initialize()
		{
			battleEventResultVoice = new BattleEventResultVoice(XeApp.Game.Common.SoundManager.Instance.voDiva.get_source());
			InitializeCheatOption();
			InitializeMusicData();
			InitializeGameData();
		}

		// // RVA: 0x9B3F80 Offset: 0x9B3F80 VA: 0x9B3F80
		private void InitializeCheatOption()
		{
			XeSys.SingletonBehaviour<CheatFunction>.Instance.Disable();
		}

		// // RVA: 0x9B7A4C Offset: 0x9B7A4C VA: 0x9B7A4C
		// private bool Lottery(float t_rate) { }

		// // RVA: 0x9B3FFC Offset: 0x9B3FFC VA: 0x9B3FFC
		private void InitializeMusicData()
		{
			totalComboNum = resource.musicData.musicScoreData;
			bgmPlayer.RequestChangeCueSheet(resource.musicData.musicBase.ENODDPDBIPA(), null);
			bgmPlayer.ChangeMusicCue(resource.musicData.musicBase.ENODDPDBIPA());
			musicMillisecLength = bgmPlayer.millisecLength;
			InitializeMusicScoreEvent();
			
			TeamInfo t = XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.teamInfo;
			StatusData s = XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.teamStatus;
			RhythmGameStatus.InitializeData initData;
			initData.musicData = resource.musicData;
			initData.teamScoreValue = s.soul + s.vocal + s.charm;
			initData.teamEnergyValue = s.support;
			initData.supportRate = s.support / (IMMAOANGPNK.NKACBOEHELJ().GBGACEBEHKM().NNKOOANMMJN().MPAMBMKFCKK) + 1;
			initData.valkyrieId = t.valkyrieId;
			initData.maxLife = t.life;
			initData.isLiveSkip = false;
			status = new RhythmGameStatus(initData, OnPlayPilotVoice);
			
			if(!setting_mv.m_enable)
			{
				if(!setting.m_enable_cutin)
				{
					status.energy.DisableCallbackPilotVoice();
				}
			}
			else
			{
				status.energy.DisableCallbackPilotVoice();
				AOJGDNFAIJL.AMIECPBIALP a = new AOJGDNFAIJL.AMIECPBIALP();				
				a.OBKGEDCKHHE(XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo.prismMusicId, 1 < XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo.onStageDivaNum);
				/*int[] difficulties = a.CEMKPBIBOCG(XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo.IsLine6Mode);
				XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo.difficultyType
				int a = a.FGCCCMAFCNH();
				float b = aGPGPOBJCMFB();
				status.enemy.SetFixDamageParamter();*/
				Debug.LogError("TODO");
			}
			//!!!
		}

		// // RVA: 0x9B4D20 Offset: 0x9B4D20 VA: 0x9B4D20
		private void InitializeGameData()
		{
			//!!!
		}

		// // RVA: 0x9B9258 Offset: 0x9B9258 VA: 0x9B9258
		// private void InitializeExtension() { }

		// // RVA: 0x9AFA54 Offset: 0x9AFA54 VA: 0x9AFA54
		private void InitializeSetting()
		{
			backupSaveData = new BackupSaveData();
			setting_mv = new SettingMV();
			GameSetupData d = XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo;
			if(d.IsMvMode)
			{
				BackupSave();
				ILDKBCLAFPB.MPHNGGECENI saveInfo = XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB;
				BEJIKEOAJHN b = XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().MHHPDGJLJGE;
				saveInfo.PBCBJAPONBF();
				saveInfo.LMDACNNJDOE = b.LMDACNNJDOE;
				saveInfo.ICGAOAFIHFD = b.ICGAOAFIHFD;
				saveInfo.FCKEDCKCEFC = b.FCKEDCKCEFC;
				saveInfo.IBEINHHMHAC = b.IBEINHHMHAC;
				saveInfo.DDHCLNFPNGK = b.DDHCLNFPNGK;
				saveInfo.HHMCIGLCBNG = b.HHMCIGLCBNG;
				saveInfo.AHLFOHJMGAI = b.AHLFOHJMGAI;
				saveInfo.DADIPGPHLDD = b.DADIPGPHLDD;
				saveInfo.DCHMOFLEFMI = backupSaveData.m_option.DCHMOFLEFMI;
				saveInfo.MBOEPFLNDOD = backupSaveData.m_option.MBOEPFLNDOD;
				saveInfo.MGOOLKHAPAF = backupSaveData.m_option.MGOOLKHAPAF;
				saveInfo.AIKDLBAANLG = backupSaveData.m_option.AIKDLBAANLG;
				saveInfo.KOKDGGOFPPI = backupSaveData.m_option.KOKDGGOFPPI;
				saveInfo.LIPAPGABJOA = backupSaveData.m_option.LIPAPGABJOA;
				saveInfo.JDJBFBPBLDC = backupSaveData.m_option.JDJBFBPBLDC;
				saveInfo.FJKNAHGFAPP = backupSaveData.m_option.FJKNAHGFAPP;
				saveInfo.OJAJHIMOIEC = backupSaveData.m_option.OJAJHIMOIEC;
				saveInfo.OAKOJGPBAJF = backupSaveData.m_option.OAKOJGPBAJF;
				saveInfo.IHEPCAHBECA = backupSaveData.m_option.IHEPCAHBECA;
				saveInfo.NFMEIILKACN = backupSaveData.m_option.NFMEIILKACN;
				saveInfo.KDNKCOAJGCM = backupSaveData.m_option.KDNKCOAJGCM;
				saveInfo.MJHEPGIEDDL = backupSaveData.m_option.MJHEPGIEDDL;
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(5, saveInfo.ICGAOAFIHFD, true);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(3, ??, true);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(6, saveInfo.IBEINHHMHAC, true);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(4, saveInfo.FCKEDCKCEFC, true);
				setting_mv.enable = true;
				setting_mv.m_mode_diva = d.mvInfo.isModeDiva;
				setting_mv.m_mode_valkyrie = d.mvInfo.isModeValkyrie;
				setting_mv.m_show_notes = d.mvInfo.isShowNotes;
			}
			else
			{
				isIgnorePlayNotesSE = XeApp.Game.Common.SoundManager.Instance.GetCategoryVolume(6) <= 0.0f;
			}
			
			if(d.ForceCutin() > 0)
			{
				BackupSave();
				XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.DADIPGPHLDD = d.ForceCutin() != 1;
			}
			if(d.ForceDivaMode() > 0)
			{
				BackupSave();
				XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.PMGMMMGCEEI = d.ForceDivaMode() != 1;
			}
			if(d.ForceValkyrieMode() > 0)
			{
				BackupSave();
				XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.AFMDGKBANPH(d.ForceValkyrieMode() != 1); // ??
			}
			
			setting = new Setting();
			setting.m_enable_cutin = XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.GLKGAOFHLPN();
			setting.m_visible_diva = XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.CJKKALFPMLA;
			if(setting_mv.m_enable)
			{
				int a = 1;
				if(setting_mv.m_mode_diva)
					a = 3;
				setting.m_mode_dv = a;
				int b = 1;
				if(setting_mv.m_mode_valkyrie)
					b = 2;
				setting.m_mode_vl = b;
			}
		}

		// // RVA: 0x9B0954 Offset: 0x9B0954 VA: 0x9B0954
		// private void FinalizeSetting() { }

		// // RVA: 0x9BAE64 Offset: 0x9BAE64 VA: 0x9BAE64
		// private void BackupSave() { }

		// // RVA: 0x9BAFE8 Offset: 0x9BAFE8 VA: 0x9BAFE8
		private void RestoreSave()
		{
			if(backupSaveData.m_enable)
			{
				XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB = backupSaveData.m_option;
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(5, backupSaveData.m_option.ICGAOAFIHFD, false);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(3, backupSaveData.m_option.LMDACNNJDOE, false);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(6, backupSaveData.m_option.IBEINHHMHAC, false);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(4, backupSaveData.m_option.FCKEDCKCEFC, false);
				backupSaveData.m_enable = false;
				backupSaveData.m_option = null;
			}
		}

		// // RVA: 0x9BA7BC Offset: 0x9BA7BC VA: 0x9BA7BC
		// private void ApplyDimmer() { }

		// // RVA: 0x9B7A9C Offset: 0x9B7A9C VA: 0x9B7A9C
		// private void InitializeMusicScoreEvent() { }

		// // RVA: 0x9BAA40 Offset: 0x9BAA40 VA: 0x9BAA40
		// private void InitializeSkill() { }

		// // RVA: 0x9BB22C Offset: 0x9BB22C VA: 0x9BB22C
		// private void StartIntroFade() { }

		// [IteratorStateMachineAttribute] // RVA: 0x744AD4 Offset: 0x744AD4 VA: 0x744AD4
		// // RVA: 0x9BB324 Offset: 0x9BB324 VA: 0x9BB324
		// private IEnumerator WaitIntroFade() { }

		// // RVA: 0x9BB3AC Offset: 0x9BB3AC VA: 0x9BB3AC
		// private void OnPlayPilotVoice(int playVoiceId) { }

		// // RVA: 0x9BB5F0 Offset: 0x9BB5F0 VA: 0x9BB5F0
		// private void OnPlayPilotVoice0_FromMV() { }

		// // RVA: 0x9BB5F8 Offset: 0x9BB5F8 VA: 0x9BB5F8
		// private void OnPlayPilotVoice1_FromMV() { }

		// // RVA: 0x9BB600 Offset: 0x9BB600 VA: 0x9BB600
		// private void EndNormalMode() { }

		// // RVA: 0x9BB81C Offset: 0x9BB81C VA: 0x9BB81C
		// private void StartValkyrieHUD() { }

		// // RVA: 0x9BB820 Offset: 0x9BB820 VA: 0x9BB820
		// private void ShowValkyrieHUD() { }

		// // RVA: 0x9BBA08 Offset: 0x9BBA08 VA: 0x9BBA08
		// private void StartValkyriePreFade() { }

		// // RVA: 0x9BBC4C Offset: 0x9BBC4C VA: 0x9BBC4C
		// private void StartValkyrieMode() { }

		// // RVA: 0x9BC4A0 Offset: 0x9BC4A0 VA: 0x9BC4A0
		// private void StartValkyrieCutscene() { }

		// [IteratorStateMachineAttribute] // RVA: 0x744B4C Offset: 0x744B4C VA: 0x744B4C
		// // RVA: 0x9BC85C Offset: 0x9BC85C VA: 0x9BC85C
		// private IEnumerator Co_2DModeEnemyUIAnim(int startRawMusicMillisec) { }

		// // RVA: 0x9BC900 Offset: 0x9BC900 VA: 0x9BC900
		// private void EndValkyrieMode() { }

		// // RVA: 0x9BCB28 Offset: 0x9BCB28 VA: 0x9BCB28
		// private void EndValkyrieCutscene() { }

		// [IteratorStateMachineAttribute] // RVA: 0x744BC4 Offset: 0x744BC4 VA: 0x744BC4
		// // RVA: 0x9BD058 Offset: 0x9BD058 VA: 0x9BD058
		// private IEnumerator Co_2DModeChangeBg(int startRawMusicMillisec) { }

		// // RVA: 0x9BD0FC Offset: 0x9BD0FC VA: 0x9BD0FC
		// private void StartDivaMode() { }

		// // RVA: 0x9BD384 Offset: 0x9BD384 VA: 0x9BD384
		// private void StartDivaCutscene() { }

		// // RVA: 0x9BDAA0 Offset: 0x9BDAA0 VA: 0x9BDAA0
		// private void EndDivaPreFade() { }

		// // RVA: 0x9BDC24 Offset: 0x9BDC24 VA: 0x9BDC24
		// private void EndDivaCutscene() { }

		// // RVA: 0x9BDF60 Offset: 0x9BDF60 VA: 0x9BDF60
		// private void OnStartRhythmGameResult() { }

		// // RVA: 0x9B2BA0 Offset: 0x9B2BA0 VA: 0x9B2BA0
		// private void UpdateSkill(int musicMillisec) { }

		// // RVA: 0x9BE618 Offset: 0x9BE618 VA: 0x9BE618
		// private void OnPosionSkillDamageCallback(BuffEffect buff) { }

		// // RVA: 0x9BE84C Offset: 0x9BE84C VA: 0x9BE84C
		private void MusicIntroStartPlayerCutInCallback()
		{
			if(!setting.m_enable_cutin)
				return;
			
			int res = voicePlayer.ChangePlayVoice(0);
			if(res == 2)
			{
				uiController.Hud.ShowDivaCutin();
			}
			else if(res == 1)
			{
				Debug.LogError("TODO");
			}
			else if(res == 0)
			{
				if(resource.isTakeoffDivaVoice)
				{
					XeApp.Game.Common.SoundManager.Instance.voDiva.Play(9, resource.takeoffVoiceId);
					uiController.Hud.uiController.Hud.ShowDivaCutin();
				}
				else
				{
					int voiceId = resource.takeoffVoiceId;
					int categoryId = 0;
					if(voiceId < 0)
					{
						categoryId = 0;
						voiceId = 0;
					}
					else
					{
						categoryId = 3;
					}
					XeApp.Game.Common.SoundManager.Instance.voPilot.Play(categoryId, voiceId);
					uiController.Hud.ShowPilotCutin();
				}
			}
		}

		// // RVA: 0x9BEC9C Offset: 0x9BEC9C VA: 0x9BEC9C
		// private void MusicIntroStartPlayerCutInCallbackFor3DMode() { }

		// // RVA: 0x9BECA0 Offset: 0x9BECA0 VA: 0x9BECA0
		// private void MusicIntroStartPlayerCutInCallbackFor2DMode() { }

		// [IteratorStateMachineAttribute] // RVA: 0x744C3C Offset: 0x744C3C VA: 0x744C3C
		// // RVA: 0x9BECC8 Offset: 0x9BECC8 VA: 0x9BECC8
		// private IEnumerator Co_2DModeMusicIntroStartPlayerCutIn(int startRawMusicMillisec) { }

		// // RVA: 0x9BED6C Offset: 0x9BED6C VA: 0x9BED6C
		// private void ValkyrieModeBeginShootingCallback() { }

		// // RVA: 0x9BEE64 Offset: 0x9BEE64 VA: 0x9BEE64
		// private void ValkyrieModeEndAnimationCallback() { }

		// // RVA: 0x9BEE90 Offset: 0x9BEE90 VA: 0x9BEE90
		// private void ValkyrieModeStartPlayerCutInCallback() { }

		// // RVA: 0x9BF138 Offset: 0x9BF138 VA: 0x9BF138
		// private void ValkyrieModeStartEnemyCutInCallback() { }

		// // RVA: 0x9BF2F4 Offset: 0x9BF2F4 VA: 0x9BF2F4
		// private void ValkyrieModeStartEnemyLockOnCallback() { }

		// // RVA: 0x9BF538 Offset: 0x9BF538 VA: 0x9BF538
		// private void OnFullfillLiveSkill(LiveSkill skill) { }

		// // RVA: 0x9BFCCC Offset: 0x9BFCCC VA: 0x9BFCCC
		// private void OnFullfillActiveSkill(ActiveSkill skill) { }

		// // RVA: 0x9C0468 Offset: 0x9C0468 VA: 0x9C0468
		// private void OnFullfillEnemySkill(EnemySkill skill) { }

		// // RVA: 0x9C03D8 Offset: 0x9C03D8 VA: 0x9C03D8
		// private void OnActiveSkill_End() { }

		// // RVA: 0x9BE160 Offset: 0x9BE160 VA: 0x9BE160
		// private void OnActiveSkill_Update(int a_notes_msec) { }

		// // RVA: 0x9C0648 Offset: 0x9C0648 VA: 0x9C0648
		// private void OnActiveBuffEffect(BuffEffect buff) { }

		// // RVA: 0x9C07AC Offset: 0x9C07AC VA: 0x9C07AC
		// private void OnRemoveBuffEffect(BuffEffect buff, int ownerDivaPlaceIndex) { }

		// // RVA: 0x9C0A20 Offset: 0x9C0A20 VA: 0x9C0A20
		// private bool MiddleScoreJudge(int idx, int score) { }

		// // RVA: 0x9C0C30 Offset: 0x9C0C30 VA: 0x9C0C30
		// private void ShowBattleResult01() { }

		// // RVA: 0x9C0E8C Offset: 0x9C0E8C VA: 0x9C0E8C
		// private void ShowBattleResult02() { }

		// // RVA: 0x9C0E58 Offset: 0x9C0E58 VA: 0x9C0E58
		// private int GetBattleResultVoiceCueId(BattleEventResultVoice.ResultVoiceIndex index) { }

		// // RVA: 0x9BFB50 Offset: 0x9BFB50 VA: 0x9BFB50
		// private void ActivateInstantBuff(SkillBase skill) { }

		// // RVA: 0x9BF8B4 Offset: 0x9BF8B4 VA: 0x9BF8B4
		// private void AddSkillLog(SkillBase skill, bool isActiveSkill) { }

		// // RVA: 0x9C10B4 Offset: 0x9C10B4 VA: 0x9C10B4
		private void LoadedRhythmGame()
		{
			scene.isReady = true;
		}

		// // RVA: 0x9C10DC Offset: 0x9C10DC VA: 0x9C10DC
		private void StartRhythmGame()
		{
			if(XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.MNJOLLGPMPI())
			{
				musicIntroObject.Begin();
				Color col = resource.musicIntroResource.paramColor;
				valkyrieObject.SetIBLColor(col);
			}
			else
			{
				lowModeBackgroundObject.ChangeIntroBg();
			}
			
			// // RVA: 0x9CCB30 Offset: 0x9CCB30 VA: 0x9CCB30
			// private void <StartRhythmGame>b__274_0() { }
			uiController.BeginIntroAnim(() => {
				StartCoroutine(Co_StartMusic());
				uiController.DeleteIntro();
			});
		}

		// // RVA: 0x9C12D4 Offset: 0x9C12D4 VA: 0x9C12D4
		// private void OnEndMusicTitleIntroAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x744CB4 Offset: 0x744CB4 VA: 0x744CB4
		// // RVA: 0x9C12F8 Offset: 0x9C12F8 VA: 0x9C12F8
		private IEnumerator Co_StartMusic()
		{
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public RhythmGamePlayer <>4__this; // 0x10
			// 0xBF32EC
			
			
			// // Namespace: 
			// [CompilerGeneratedAttribute] // RVA: 0x650AA8 Offset: 0x650AA8 VA: 0x650AA8
			// private sealed class RhythmGamePlayer.<>c__DisplayClass276_0 // TypeDefIndex: 18178
			// {
				// // Fields
				// public RhythmGamePlayer <>4__this; // 0x8
				// public bool isShowingDescription; // 0xC
				// public Action <>9__5; // 0x10

				// // Methods

				// // RVA: 0xBF176C Offset: 0xBF176C VA: 0xBF176C
				// public void .ctor() { }

				// // RVA: 0xBF1774 Offset: 0xBF1774 VA: 0xBF1774
				// internal void <Co_StartMusic>b__5() { }

				// // RVA: 0xBF1780 Offset: 0xBF1780 VA: 0xBF1780
				// internal void <Co_StartMusic>b__0() { }

				// // RVA: 0xBF178C Offset: 0xBF178C VA: 0xBF178C
				// internal void <Co_StartMusic>b__1() { }

				// // RVA: 0xBF1798 Offset: 0xBF1798 VA: 0xBF1798
				// internal bool <Co_StartMusic>b__2() { }
			// }

			// // Namespace: 
			// [CompilerGeneratedAttribute] // RVA: 0x650AB8 Offset: 0x650AB8 VA: 0x650AB8
			// private sealed class RhythmGamePlayer.<>c__DisplayClass276_1 // TypeDefIndex: 18179
			// {
				// // Fields
				// public BasicTutorialManager mrg; // 0x8
				// public RhythmGamePlayer.<>c__DisplayClass276_0 CS$<>8__locals1; // 0xC
				// public Action <>9__4; // 0x10

				// // Methods

				// // RVA: 0xBF17A0 Offset: 0xBF17A0 VA: 0xBF17A0
				// public void .ctor() { }

				// // RVA: 0xBF17A8 Offset: 0xBF17A8 VA: 0xBF17A8
				// internal void <Co_StartMusic>b__3() { }

				// // RVA: 0xBF198C Offset: 0xBF198C VA: 0xBF198C
				// internal void <Co_StartMusic>b__4() { }
			// }
			
			//__this00 = c__DisplayClass276_0
			if(XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo.isTutorialOne)
			{
				//__this_03 = c__DisplayClass276_1
				Debug.LogError("TODO tuto");
			}
			else if(XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo.isTutorialTwo)
			{
				Debug.LogError("TODO tuto");
			}
			else
			{
				bool IsLine6Mode = XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo.IsLine6Mode;
				bool IsMvMode = XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo.IsMvMode;
				if(IsLine6Mode && !IsMvMode)
				{
					Debug.LogError("TODO tuto");
				}
			}
			yield return null; // wait end tuto
			
			if(XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.MNJOLLGPMPI())
			{
				musicIntroObject.Takeoff();
			}
			else
			{
				MusicIntroStartPlayerCutInCallback();
			}
			Play();
		}

		// // RVA: 0x9B2AE0 Offset: 0x9B2AE0 VA: 0x9B2AE0
		// private void Failed() { }

		// // RVA: 0x9C14C8 Offset: 0x9C14C8 VA: 0x9C14C8
		// private void ShowEndTutorialWindow() { }

		// // RVA: 0x9C16F0 Offset: 0x9C16F0 VA: 0x9C16F0
		// private void ForceChangePercentage100ForTutorial() { }

		// // RVA: 0x9C1854 Offset: 0x9C1854 VA: 0x9C1854
		// private void ForceDefeatEnemyForTutorial() { }

		// // RVA: 0x9C1B60 Offset: 0x9C1B60 VA: 0x9C1B60
		// private void ShowModeDescriptionTutorialWindow() { }

		// // RVA: 0x9C1C84 Offset: 0x9C1C84 VA: 0x9C1C84
		// private void ShowTutorialActiveSkillGuide() { }

		// // RVA: 0x9C1D84 Offset: 0x9C1D84 VA: 0x9C1D84
		// private void ConfirmationWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x9C24B0 Offset: 0x9C24B0 VA: 0x9C24B0
		// private void ContinueWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x9C25FC Offset: 0x9C25FC VA: 0x9C25FC
		// private void ReconfirmationWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x9C27B4 Offset: 0x9C27B4 VA: 0x9C27B4
		// private void PauseWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x9C2A9C Offset: 0x9C2A9C VA: 0x9C2A9C
		// private void PauseRetireConfirmationWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x9C2B68 Offset: 0x9C2B68 VA: 0x9C2B68
		// private void SkipTutorialWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x9C2D30 Offset: 0x9C2D30 VA: 0x9C2D30
		// private void EndTutorialWindowCallBack() { }

		// // RVA: 0x9C2DEC Offset: 0x9C2DEC VA: 0x9C2DEC
		// private void SkipStoryWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x9C2E00 Offset: 0x9C2E00 VA: 0x9C2E00
		// private void SkipStoryPauseWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x9C2ECC Offset: 0x9C2ECC VA: 0x9C2ECC
		// private void MvModePauseWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x9C3414 Offset: 0x9C3414 VA: 0x9C3414
		// private void MvModeEndConfirmWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x9C34E0 Offset: 0x9C34E0 VA: 0x9C34E0
		// private void OnSuccessInPaidVCPurchase() { }

		// // RVA: 0x9C34E4 Offset: 0x9C34E4 VA: 0x9C34E4
		// private void OnCancelInPaidVCPurchase() { }

		// // RVA: 0x9C34E8 Offset: 0x9C34E8 VA: 0x9C34E8
		// private void OnErrorInPaidVCPurchase() { }

		// // RVA: 0x9C2290 Offset: 0x9C2290 VA: 0x9C2290
		// private void OnSuccessInGameContinueByPaidVC() { }

		// // RVA: 0x9C3624 Offset: 0x9C3624 VA: 0x9C3624
		// private void OnErrorInGameContinueByPaidVC() { }

		// // RVA: 0x9C1380 Offset: 0x9C1380 VA: 0x9C1380
		// private void PauseGame(bool isReserve = False) { }

		// // RVA: 0x9C3628 Offset: 0x9C3628 VA: 0x9C3628
		// private void ResumeGame() { }

		// // RVA: 0x9C3A48 Offset: 0x9C3A48 VA: 0x9C3A48
		// private void PauseButtonCallback(bool a_suspend) { }

		// // RVA: 0x9C3BCC Offset: 0x9C3BCC VA: 0x9C3BCC
		// private void MvPauseButtonCallback(bool a_suspend) { }

		// // RVA: 0x9C4154 Offset: 0x9C4154 VA: 0x9C4154
		// private void PauseRetryAnimCompletedCallBack() { }

		// // RVA: 0x9C309C Offset: 0x9C309C VA: 0x9C309C
		// private void MvModePauseRetry() { }

		// // RVA: 0x9C4254 Offset: 0x9C4254 VA: 0x9C4254
		// private void FailedAnimCompletedCallback() { }

		// // RVA: 0x9C42AC Offset: 0x9C42AC VA: 0x9C42AC
		// private void RetryAnimCompletedCallback() { }

		// // RVA: 0x9C23C8 Offset: 0x9C23C8 VA: 0x9C23C8
		// private void ShowConfirmationWindow() { }

		// [IteratorStateMachineAttribute] // RVA: 0x744D2C Offset: 0x744D2C VA: 0x744D2C
		// // RVA: 0x9C4654 Offset: 0x9C4654 VA: 0x9C4654
		// private IEnumerator Co_ShowConfirmationWindow() { }

		// // RVA: 0x9C46DC Offset: 0x9C46DC VA: 0x9C46DC
		private void OnChangeScene()
		{
			if(!XeSys.SingletonBehaviour<Database>.Instance.m_tutorialSetInstance.musicInfo.isTutorialTwo)
				return;
			XeSys.SingletonBehaviour<BasicTutorialManager>.Instance.HideCursor();
		}

		// // RVA: 0x9C47C8 Offset: 0x9C47C8 VA: 0x9C47C8
		private void GameStartErrorToTitleAction()
		{
			XeApp.Game.GameManager.FadeOut();
			StartCoroutine(Co_FadeOutAndExit());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x744DA4 Offset: 0x744DA4 VA: 0x744DA4
		// // RVA: 0x9C4868 Offset: 0x9C4868 VA: 0x9C4868
		private IEnumerator Co_FadeOutAndExit()
		{
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public RhythmGamePlayer <>4__this; // 0x10
			// 0xBF2980
			while(XeApp.Game.GameManager.IsFading())
			{
				yield return null;
			}
			GotoTitleSceneInError();
			uiController.DeleteIntro();
		}

		// // RVA: 0x9C48F0 Offset: 0x9C48F0 VA: 0x9C48F0
		private void TutorialClearEndRhythmGame()
		{
			Debug.LogError("TODO");
			///!!!
		}

		// // RVA: 0x9C4A70 Offset: 0x9C4A70 VA: 0x9C4A70
		private void ClearEndRhythmGame()
		{
			if(!scene.IsEnableTransionResult())
				return;
			StartCoroutine(Co_WaitRhytmGameEnd(true));
		}

		// // RVA: 0x9C260C Offset: 0x9C260C VA: 0x9C260C
		// private void FailedRhythmGame() { }

		// // RVA: 0x9C4AC4 Offset: 0x9C4AC4 VA: 0x9C4AC4
		// private void EndRhythmGame(bool isClear) { }

		// [IteratorStateMachineAttribute] // RVA: 0x744E1C Offset: 0x744E1C VA: 0x744E1C
		// // RVA: 0x9C4AE8 Offset: 0x9C4AE8 VA: 0x9C4AE8
		public IEnumerator Co_WaitRhytmGameEnd(bool isClear)
		{
			yield return null;
			Debug.LogError("TODO");
			//!!!
		}

		// // RVA: 0x9C4B8C Offset: 0x9C4B8C VA: 0x9C4B8C
		// private void MakeClearSetupData(out JGEOBNENMAH.HAJIFNABIFF clearSetup, int[] noteResultCount, int noteResultCount_Excellent, int noteResultCount_EventItem) { }

		// // RVA: 0x9C5C78 Offset: 0x9C5C78 VA: 0x9C5C78
		// private void GotoMenuSceneInSuccess(int[] noteResultCount, int noteResultCount_Excellent) { }

		// // RVA: 0x9C5D68 Offset: 0x9C5D68 VA: 0x9C5D68
		// private void GotoMenuSceneInFailed() { }

		// // RVA: 0x9C34EC Offset: 0x9C34EC VA: 0x9C34EC
		private void GotoTitleSceneInError()
		{
			Debug.LogError("TODO");
			//!!!
		}

		// // RVA: 0x9C5F68 Offset: 0x9C5F68 VA: 0x9C5F68
		// private void GotoTutorialRetry() { }

		// // RVA: 0x9C2D34 Offset: 0x9C2D34 VA: 0x9C2D34
		// private void GotoTutorialGacha() { }

		// // RVA: 0x9C2C34 Offset: 0x9C2C34 VA: 0x9C2C34
		// private void GotoTutorialSkip() { }

		// // RVA: 0x9C2DFC Offset: 0x9C2DFC VA: 0x9C2DFC
		// private void GotoStorySkip() { }

		// // RVA: 0x9C5BE4 Offset: 0x9C5BE4 VA: 0x9C5BE4
		// public RhythmGameConsts.ResultComboType CalcComboRank() { }

		// // RVA: 0x9C44C4 Offset: 0x9C44C4 VA: 0x9C44C4
		// private void AddInvincibleBuffEffect() { }

		// // RVA: 0x9C16E8 Offset: 0x9C16E8 VA: 0x9C16E8
		// private bool IsEnableRetryTutorialPopup() { }

		// // RVA: 0x9C6020 Offset: 0x9C6020 VA: 0x9C6020
		// public bool IsActiveLine(int lineNo) { }

		// // RVA: 0x9C6120 Offset: 0x9C6120 VA: 0x9C6120
		// public void BeganTouchEventCallback(int lineNo, int fingerId) { }

		// // RVA: 0x9C651C Offset: 0x9C651C VA: 0x9C651C
		// public void EndedTouchEventCallback(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss) { }

		// // RVA: 0x9C6730 Offset: 0x9C6730 VA: 0x9C6730
		// public void ReleaseLineEventCallback(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss) { }

		// // RVA: 0x9C6940 Offset: 0x9C6940 VA: 0x9C6940
		// public void NextLineEventCallback(int lineNo0, int lineNo1, int fingerId, bool forceMiss) { }

		// // RVA: 0x9C6B50 Offset: 0x9C6B50 VA: 0x9C6B50
		// public void SwipedTouchEventCallback(int lineNo, int fingerId, bool isRight, bool isDown, bool isLeft, bool isUp) { }

		// // RVA: 0x9C6D18 Offset: 0x9C6D18 VA: 0x9C6D18
		// public void NeutralTouchEventCallback(int lineNo, int fingerId) { }

		// // RVA: 0x9C6EE0 Offset: 0x9C6EE0 VA: 0x9C6EE0
		// public void CheckInputCallback(RhythmGameInputPerformer.InputSaver a_saver) { }

		// // RVA: 0x9C7008 Offset: 0x9C7008 VA: 0x9C7008
		// private void RNoteOverwrideJudgedResultDelegate(RNoteObject a_note_obj, ref RhythmGameConsts.NoteResultEx a_result_ex) { }

		// // RVA: 0x9C71D8 Offset: 0x9C71D8 VA: 0x9C71D8
		// private void RNoteJudgedResultDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex, RhythmGameConsts.NoteJudgeType a_judge_type) { }

		// // RVA: 0x9CA2CC Offset: 0x9CA2CC VA: 0x9CA2CC
		// public void SkillTouchEventCallback(TouchSwipeDirection swipeDir) { }

		// // RVA: 0x9C73F8 Offset: 0x9C73F8 VA: 0x9C73F8
		// private void JudgedNoteResult(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex) { }

		// // RVA: 0x9C8D08 Offset: 0x9C8D08 VA: 0x9C8D08
		// private void JudgedNoteEffect(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex) { }

		// // RVA: 0x9C9CC4 Offset: 0x9C9CC4 VA: 0x9C9CC4
		// private void JudgedNoteSound(RNoteObject noteObject, RhythmGameConsts.NoteResult result) { }

		// // RVA: 0x9CA658 Offset: 0x9CA658 VA: 0x9CA658
		// private void PlayNoteSEByResult(RhythmGameConsts.NoteResult result, bool isFlick) { }

		// // RVA: 0x9C6474 Offset: 0x9C6474 VA: 0x9C6474
		// private CriAtomExPlayback PlayNotesSE(RhythmGamePlayer.NoteSEType type) { }

		// // RVA: 0x9CA550 Offset: 0x9CA550 VA: 0x9CA550
		// private void EnterNoteResult(RhythmGameConsts.NoteResultEx a_result_ex, int trackID) { }

		// // RVA: 0x9BBDAC Offset: 0x9BBDAC VA: 0x9BBDAC
		// private void ReJudgeValkyrieNotes() { }

		// // RVA: 0x9CA6EC Offset: 0x9CA6EC VA: 0x9CA6EC
		private void StartPlayMusic(int startTime)
		{
			//!!!
		}

		// [IteratorStateMachineAttribute] // RVA: 0x744E94 Offset: 0x744E94 VA: 0x744E94
		// // RVA: 0x9CB194 Offset: 0x9CB194 VA: 0x9CB194
		private IEnumerator WaitMusicPlayCoroutine(float a_sec_wait)
		{
			//!!!
		}

		// // RVA: 0x9C3750 Offset: 0x9C3750 VA: 0x9C3750
		public void Play()
		{
			//??XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.MNJOLLGPMPI()
			if(bgmPlayer.get_source().get_status() == 0)
			{
				resource.musicIntroResource.OverrideMusicStartTime(resource.musicData.musicParam.stateOffsetSec);
				if(resource.musicData.musicParam.stateOffsetSec < 0.0f)
				{
					StartPlayMusic((int)(resource.musicData.musicParam.stateOffsetSec * -1000));
				}
				else
				{
					StartCoroutine(WaitMusicPlayCoroutine(resource.musicData.musicParam.stateOffsetSec));
				}
			}
			else
			{
				if(bgmPlayer.get_source().IsPaused())
					Resume();
				else
					Pause();
			}
		}

		// // RVA: 0x9B1FE8 Offset: 0x9B1FE8 VA: 0x9B1FE8
		public void Pause()
		{
			//!!!
		}

		// // RVA: 0x9B351C Offset: 0x9B351C VA: 0x9B351C
		public void Resume()
		{
			//!!!
		}

		// // RVA: 0x9CB244 Offset: 0x9CB244 VA: 0x9CB244
		// public void Stop() { }

		// // RVA: 0x9CC364 Offset: 0x9CC364 VA: 0x9CC364
		// public void RequestChangeMusicSequenceTime(int millisec) { }

		// // RVA: 0x9B30C4 Offset: 0x9B30C4 VA: 0x9B30C4
		private bool ApplyChangeMusicSequenceTime()
		{
			///!!!
		}

		// // RVA: 0x9B2AC4 Offset: 0x9B2AC4 VA: 0x9B2AC4
		// public static float ToSecTime(int millisec) { }

		// // RVA: 0x9CC3D4 Offset: 0x9CC3D4 VA: 0x9CC3D4
		// public static int ToMillisecTime(float sec) { }

		// // RVA: 0x9CC3F0 Offset: 0x9CC3F0 VA: 0x9CC3F0
		// private bool IsPlayingMusic() { }

		// // RVA: 0x9B1F80 Offset: 0x9B1F80 VA: 0x9B1F80
		// private bool IsStopMusic() { }

		// // RVA: 0x9CC458 Offset: 0x9CC458 VA: 0x9CC458
		// public int GetMusicMillisecLength() { }

		// // RVA: 0x9B2A48 Offset: 0x9B2A48 VA: 0x9B2A48
		// public int GetRawMusicMillisec() { }

		// // RVA: 0x9B2A88 Offset: 0x9B2A88 VA: 0x9B2A88
		// public int IncludeDeviceLatency(int rawMillisec) { }

		// // RVA: 0x9B2A7C Offset: 0x9B2A7C VA: 0x9B2A7C
		// public int IncludeNotesOffsert(int rawMillisec) { }

		// // RVA: 0x9B9168 Offset: 0x9B9168 VA: 0x9B9168
		// private bool IsEnableMovie() { }

		// // RVA: 0x9BE120 Offset: 0x9BE120 VA: 0x9BE120
		// public bool IsRhythmGamePlayerEnd() { }

		// // RVA: 0x9CC460 Offset: 0x9CC460 VA: 0x9CC460
		// public void OnCallback_PlayVoice_GameFailed() { }

		// // RVA: 0x9CC4E8 Offset: 0x9CC4E8 VA: 0x9CC4E8
		// public void OnCallback_PlayVoice_GameClear_PerfectFullCombo() { }

		// // RVA: 0x9CC570 Offset: 0x9CC570 VA: 0x9CC570
		// public void OnCallback_PlayVoice_GameClear_FullCombo() { }

		// // RVA: 0x9CC5F8 Offset: 0x9CC5F8 VA: 0x9CC5F8
		// private bool TutorialChecker(TutorialConditionId condition) { }

		// // RVA: 0x9CC608 Offset: 0x9CC608 VA: 0x9CC608
		public RhythmGamePlayer()
		{
			loopSEPlayback = new CriAtomExPlayback[2];
			notesSoundPlayer = new NotesSoundPlayer();
			m_NoteResultParam_Excellent = new RhythmGameConsts.NoteResultParam_Excellent();
			m_NoteParam_CLiveSkill = new RhythmGameConsts.NoteParam_CenterLiveSkill();
			m_NoteParam_EventItem = new RhythmGameConsts.NoteParam_EventItem();
			m_NoteAssingInfo = new RhythmGameSpecialNotesAssigner.AssignInfo();
			skillOwner = new SkillOwner();
			tutorialPopupStartTime = -1;
			buffOwner = new BuffEffectOwner();
			stageLightingObjectList = new List<StageLightingObject>();
			stageLightingAddObjectList = new List<StageLightingAddObject>();
			stageExtensionObjectList = new List<StageExtensionObject>();
			divaExtensionObjectList = new List<DivaExtensionObject>();
			divaCutinObjectList = new List<DivaCutinObject>();
			musicCameraCutinObjectList = new List<MusicCameraCutinObject>();
			eventFireFlags = new BitArray(3);
			dropItemList = new List<int>();
			dropItemRarityCount = new int[2];
			preJudgeValkyrieNotes = new List<RNoteObject>();
			liveSkillActivateCountList = new List<int>(XeApp.Game.Common.TeamConst.TeamSceneNum);
			logger = new RhythmGamePlayLogger();
			noteTouchSEIndex = new int[8] {}; // Field$<PrivateImplementationDetails>.B97719DD67FEBE5083885CEEA340284B07BE6023
			activeSkillRestartTimer = new ActiveSkillRestartTimer();
		}

		// // RVA: 0x9CCA14 Offset: 0x9CCA14 VA: 0x9CCA14
		static RhythmGamePlayer()
		{
			IntroEndFadeColor = new Color(0, 0, 0, 0);
			ValkyrieStartFadeColor = new Color(0x3f333333,0x3f4ccccd,0x3f4ccccd,0);
			DivaModeEndFadeColor = new Color(0x3f666666,0x3f666666,0x3f666666,0);
		}

	}
}
