using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game;
using XeSys.uGUI;
using System.Collections;
using System.Collections.Generic;
using System;
using XeApp.Game.Tutorial;
using XeSys;
using CriWare;
using mcrs;
using XeApp.Game.Menu;

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
				m_visible_diva = true;
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
			public ILDKBCLAFPB.MPHNGGECENI_Option m_option; // 0xC
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
		
		public static readonly Color IntroEndFadeColor = new Color(0, 0, 0); // 0x0
		public static readonly Color ValkyrieStartFadeColor = new Color(0.7f,0.8f,0.8f); // 0x10
		public static readonly Color DivaModeEndFadeColor = new Color(0.9f,0.9f,0.9f); // 0x20
		public const float DivaModeEndFadeOutSec = 0.5f;
		public const float DivaModeEndFadeInSec = 0.5f;
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
		private CriAtomExPlayback[] loopSEPlayback = new CriAtomExPlayback[2]; // 0x44
		private NotesSoundPlayer notesSoundPlayer = new NotesSoundPlayer(); // 0x48
		[SerializeField]
		private RhythmGameScene scene; // 0x4C
		[SerializeField]
		private RNoteOwner rNoteOwner; // 0x50
		private RhythmGameConsts.NoteResultParam_Excellent m_NoteResultParam_Excellent = new RhythmGameConsts.NoteResultParam_Excellent(); // 0x54
		private RhythmGameConsts.NoteParam_CenterLiveSkill m_NoteParam_CLiveSkill = new RhythmGameConsts.NoteParam_CenterLiveSkill(); // 0x58
		private RhythmGameConsts.NoteParam_EventItem m_NoteParam_EventItem = new RhythmGameConsts.NoteParam_EventItem(); // 0x5C
		private RhythmGameSpecialNotesAssigner.AssignInfo m_NoteAssingInfo = new RhythmGameSpecialNotesAssigner.AssignInfo(); // 0x60
		private SkillOwner skillOwner = new SkillOwner(); // 0x68
		private BuffEffectOwner buffOwner = new BuffEffectOwner(); // 0x6C
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
		private int tutorialPopupStartTime = -1; // 0x8C
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
		private List<StageLightingObject> stageLightingObjectList = new List<StageLightingObject>(); // 0xAC
		private List<StageLightingAddObject> stageLightingAddObjectList = new List<StageLightingAddObject>(); // 0xB0
		private List<StageExtensionObject> stageExtensionObjectList = new List<StageExtensionObject>(); // 0xB4
		private List<DivaExtensionObject> divaExtensionObjectList = new List<DivaExtensionObject>(); // 0xB8
		private List<DivaCutinObject> divaCutinObjectList = new List<DivaCutinObject>(); // 0xBC
		private List<MusicCameraCutinObject> musicCameraCutinObjectList = new List<MusicCameraCutinObject>(); // 0xC0
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
		private BitArray eventFireFlags = new BitArray(3); // 0x13C
		private List<int> dropItemList = new List<int>(); // 0x140
		private int[] dropItemRarityCount = new int[2]; // 0x144
		private RhythmGameResource resource; // 0x148
		private Action updater; // 0x14C
		private List<RNoteObject> preJudgeValkyrieNotes = new List<RNoteObject>(); // 0x150
		private bool skillTouched; // 0x154
		private bool touchedCenterLiveSkill; // 0x155
		private bool touchedEventItem; // 0x156
		private List<int> liveSkillActivateCountList = new List<int>(XeApp.Game.Common.TeamConst.TeamSceneNum); // 0x158
		private RhythmGamePlayLogger logger = new RhythmGamePlayLogger(); // 0x15C
		private int m_bit_note_result; // 0x160
		private int[] noteTouchSEIndex = new int[8] 
		{
			(int)cs_se_notes.SE_NOTES_004,
			(int)cs_se_notes.SE_NOTES_005,
			(int)cs_se_notes.SE_NOTES_003,
			(int)cs_se_notes.SE_NOTES_002,
			(int)cs_se_notes.SE_NOTES_001,
			(int)cs_se_notes.SE_NOTES_000,
			(int)cs_se_notes.SE_NOTES_007,
			(int)cs_se_notes.SE_NOTES_006
		}; // Field$<PrivateImplementationDetails>.B97719DD67FEBE5083885CEEA340284B07BE6023; // 0x164
		private const int BattleEventVoiceNum = 3;
		private ActiveSkillRestartTimer activeSkillRestartTimer = new ActiveSkillRestartTimer(); // 0x168
		public static bool IsLowQualityMode; // 0x30

		public Setting setting { get; private set; }  // 0xC
		public SettingMV setting_mv { get; private set; } // 0x10
		public BackupSaveData backupSaveData { get; private set; } // 0x14
		// public MusicData musicData { get; private set; } // get_musicData 0x9AF428 // set_musicData 0x9AF44C 
		public BgmPlayer bgmPlayer { get { return SoundManager.Instance.bgmPlayer; } private set { return; } } // get_bgmPlayer 0x9AF450 // set_bgmPlayer 0x9AF484 
		public int musicMillisecLength { get; private set; } // 0x30
		public int notesMillisec { get; private set; } // 0x34
		public int deviceMillisec { get; private set; } // 0x38
		public float deviceSec { get; private set; } // 0x3C
		public int musicRequestChangeMillisec { get; private set; } // 0x40
		public RhythmGameStatus status { get; private set; } // 0x64
		public RhythmGameScoreEvent introFadeEvent { get; private set; } // 0xE0
		public RhythmGameScoreEvent normalModeEndEvent { get; private set; } // 0xE4
		public RhythmGameScoreEvent valkyrieStartHUDEvent { get; private set; } // 0xE8
		public RhythmGameScoreEvent valkyriePreFadeEvent { get; private set; } // 0xEC
		public RhythmGameScoreEvent valkyrieCutsceneStartEvent { get; private set; } // 0xF0
		public RhythmGameScoreEvent valkyrieModeStartEvent { get; private set; } // 0xF4
		public RhythmGameScoreEvent valkyrieCutsceneEndEvent { get; private set; } // 0xF8
		public RhythmGameScoreEvent valkyrieModeEndEvent { get; private set; } // 0xFC
		public RhythmGameScoreEvent divaCutsceneStartEvent { get; private set; } // 0x100
		public RhythmGameScoreEvent divaModeStartEvent { get; private set; } // 0x104
		public RhythmGameScoreEvent rhythmGameResultStartEvent { get; private set; } // 0x108
		public RhythmGameScoreEvent tutorialOneEndEvent { get; private set; } // 0x10C
		public RhythmGameScoreEvent tutorialTwoFoceFWaveMaxEvent { get; private set; } // 0x110
		public RhythmGameScoreEvent tutorialTwoFoceEnemyDefeatEvent { get; private set; } // 0x114
		public RhythmGameScoreEvent tutorialTwoModeDescriptionEvent { get; private set; } // 0x118
		public RhythmGameScoreEvent tutorialTwoActiveSkillGuideEvent { get; private set; } // 0x11C
		public RhythmGameScoreEvent battleEventResult01 { get; private set; } // 0x120
		public RhythmGameScoreEvent battleEventResult02 { get; private set; } // 0x124
		public RhythmGameScoreEvent mvPilotCutinFirstEvent { get; private set; } // 0x128
		public RhythmGameScoreEvent mvPilotCutinSecondEvent { get; private set; } // 0x12C
		public RhythmGameCheerSoundOrderer soundCheerOrderer { get; private set; } // 0x130
		public RhythmGameVoicePlayer voicePlayer { get; private set; } // 0x134
		// public BattleEventResultVoice BattleEventResultVoide { get; } // get_BattleEventResultVoide 0x9AF640 

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
			Action endAction = this.ClearEndRhythmGame;
			if(XeApp.Game.GameManager.Instance.IsTutorial)
			{
				endAction = this.TutorialClearEndRhythmGame;
			}
			Difficulty.Type difficulty = Database.Instance.gameSetup.musicInfo.difficultyType;
			Action loadedAction = this.LoadedRhythmGame;
			Action beginAction = this.StartRhythmGame;
			Action errorAction = this.GameStartErrorToTitleAction;
			gameFlow = new RhythmGameFlow(resource, loadedAction, difficulty, beginAction, this, uiController, endAction, errorAction);
			scene.onChangeScene = this.OnChangeScene;
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
			if(!XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				XeApp.Game.GameManager.Instance.PopupCanvas.worldCamera.clearFlags = UnityEngine.CameraClearFlags.Nothing;
			}
			ExternLib.LibCriWare.checkUncached = false;
			SoundManager.Instance.SetInGame(false);
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
			if(IsStopMusic())
			{
				isResetRequest = false;
			}
			if(isPauseRequest)
			{
				isPauseRequest = false;
				rNoteOwner.Pause();
				Pause();
			}
			currentRawMusicMillisec = GetRawMusicMillisec();
			notesMillisec = currentRawMusicMillisec - noteOffsetMillisec;
			deviceMillisec = IncludeDeviceLatency(currentRawMusicMillisec);
			deviceSec = deviceMillisec / 1000.0f;
			UMODebugger.Instance.UpdateSongTime(deviceSec);
			if(!isResetRequest)
			{
				normalModeEndEvent.Update(notesMillisec);
				valkyrieModeStartEvent.Update(notesMillisec);
				valkyrieModeEndEvent.Update(notesMillisec);
				divaModeStartEvent.Update(notesMillisec);
				if(!isVisiblePauseWindow)
				{
					rhythmGameResultStartEvent.Update(notesMillisec);
				}
				tutorialOneEndEvent.Update(notesMillisec);
				tutorialTwoFoceFWaveMaxEvent.Update(notesMillisec);
				tutorialTwoFoceEnemyDefeatEvent.Update(notesMillisec);
				tutorialTwoActiveSkillGuideEvent.Update(notesMillisec);
				if(battleEventResult01 != null)
					battleEventResult01.Update(deviceMillisec);
				if(battleEventResult02 != null)
					battleEventResult02.Update(deviceMillisec);
				introFadeEvent.Update(deviceMillisec);
				valkyrieStartHUDEvent.Update(deviceMillisec);
				valkyriePreFadeEvent.Update(deviceMillisec);
				valkyrieCutsceneStartEvent.Update(deviceMillisec);
				valkyrieCutsceneEndEvent.Update(deviceMillisec);
				divaCutsceneStartEvent.Update(deviceMillisec);
				tutorialTwoModeDescriptionEvent.Update(deviceMillisec);
				if(mvPilotCutinFirstEvent != null)
					mvPilotCutinFirstEvent.Update(deviceMillisec);
				if (mvPilotCutinSecondEvent != null)
					mvPilotCutinSecondEvent.Update(deviceMillisec);
				if (soundCheerOrderer != null)
					soundCheerOrderer.Update(deviceMillisec);
			}
			if(NotesSoundPlayer.isNewNoteSoundEnable)
			{
				notesSoundPlayer.PreSetup();
			}
			if(!isResetRequest)
			{
				rNoteOwner.OnUpdate(notesMillisec);
			}
			gameDivaObject.ChangeAnimationTime(deviceSec);
			for(int i = 0; i < subDivaObject.Length; i++)
			{
				if(subDivaObject[i] != null)
					subDivaObject[i].ChangeAnimationTime(deviceSec);
			}
			musicCameraObject.ChangeAnimationTime(deviceSec);
			stageObject.ChangeAnimationTime(deviceSec);
			musicIntroObject.ChangeAnimationTime(deviceSec);
			valkyrieModeObject.ChangeAnimationTime(deviceSec);
			for(int i = 0; i < stageLightingObjectList.Count; i++)
			{
				stageLightingObjectList[i].ChangeAnimationTime(deviceSec);
			}
			for (int i = 0; i < stageLightingAddObjectList.Count; i++)
			{
				stageLightingAddObjectList[i].ChangeAnimationTime(deviceSec);
			}
			for (int i = 0; i < stageExtensionObjectList.Count; i++)
			{
				stageExtensionObjectList[i].ChangeAnimationTime(deviceSec);
			}
			for (int i = 0; i < divaExtensionObjectList.Count; i++)
			{
				divaExtensionObjectList[i].ChangeAnimationTime(deviceSec);
			}
			for (int i = 0; i < divaCutinObjectList.Count; i++)
			{
				divaCutinObjectList[i].ChangeAnimationTime(deviceSec);
			}
			for (int i = 0; i < musicCameraCutinObjectList.Count; i++)
			{
				musicCameraCutinObjectList[i].ChangeAnimationTime(deviceSec);
			}
			status.Update();
			if(!isVisiblePauseWindow)
			{
				if(status != null)
				{
					uiController.UpdateCombo(status.combo.current);
					uiController.UpdateBattleCombo(status.comboValkyrie.current);
					uiController.Hud.ChangeScore(status.score.currentScore, 0);
					ResultScoreRank.Type rank = status.score.CalcCurrentRank();
					uiController.Hud.ChangeRankGaugeFrame(rank, status.score.CalcRatioBetweenUpToNextRank(rank));
					uiController.Hud.ChangeHpGaugeFrame((int)(status.life.view * 100.0f / status.life.max));
					if(uiController.Hud.isBattleLimitTimeRunning)
					{
						Vector3 pos = Vector3.zero;
						if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D && GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.AOOKLMAPPLG_IsValkyrieModeEnabled())
						{							
							valkyrieModeObject.GetLockOnTargetPos(out pos);
							valkyrieModeObject.SetShootLock(!status.IsEnableValkyrieAttack());
						}
						uiController.Hud.UpdateBattleLimitTime(resource.musicData.divaModeJudgeMillisec - notesMillisec);
						uiController.Hud.UpdateTargetPosition(pos);
					}
					if(status.life.current < 1)
					{
						Failed();
					}
					for(int i = 0; i < dropItemRarityCount.Length; i++)
					{
						uiController.Hud.SetItemCount(i, dropItemRarityCount[i]);
					}
				}
				uiController.OnUpdate();
				UpdateSkill(notesMillisec);
				m_bit_note_result = 0;
			}
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
			battleEventResultVoice = new BattleEventResultVoice(XeApp.Game.Common.SoundManager.Instance.voDiva.source);
			InitializeCheatOption();
			InitializeMusicData();
			InitializeGameData();


#if UNITY_STANDALONE
			//UMO
			// Preload note sounds
			for (int i = 0; i < noteTouchSEIndex.Length; i++)
			{
				SoundManager.Instance.sePlayerNotes.Preload(noteTouchSEIndex[i]);
			}
			// From valkyrie event, not sure if dynamic by valkyrie / ground
			SoundManager.Instance.sePlayerGame.Preload("se_game_006");
			SoundManager.Instance.sePlayerGame.Preload("se_game_012");
			SoundManager.Instance.sePlayerGame.Preload("se_valkyrie_000");
			SoundManager.Instance.sePlayerGame.Preload("se_valkyrie_001");
			SoundManager.Instance.sePlayerGame.Preload("se_valkyrie_002");
			SoundManager.Instance.sePlayerGame.Preload("se_valkyrie_005");
			SoundManager.Instance.sePlayerGame.Preload("se_valkyrie_003");
			SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_GAME_009);
			SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_GAME_018);
			SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_GAME_019);
			// Preload pilot voice
			if (setting.m_enable_cutin)
			{
				RhythmGameVoicePlayer.Result res = voicePlayer.PreloadPlayVoice(RhythmGameVoicePlayer.Voice.TakeOff);
				if (RhythmGameVoicePlayer.Result.None == res)
				{
					if (resource.isTakeoffDivaVoice)
					{
						SoundManager.Instance.voDiva.Preload(DivaVoicePlayer.VoiceCategory.GameSpecial, resource.takeoffVoiceId);
					}
					else
					{
						int voiceId = resource.takeoffVoiceId;
						PilotVoicePlayer.VoiceCategory categoryId = PilotVoicePlayer.VoiceCategory.Start;
						if (voiceId < 0)
						{
							categoryId = PilotVoicePlayer.VoiceCategory.Start;
							voiceId = 0;
						}
						else
						{
							categoryId = PilotVoicePlayer.VoiceCategory.Special;
						}
						SoundManager.Instance.voPilot.Preload(categoryId, voiceId);
					}
				}
			}
			//Preload active skill sounds
			SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_VALKYRIE_001);
			if (gameFlow.IsRareBreak)
			{
				SoundManager.Instance.voDivaCos.Preload(DivaCosVoicePlayer.Category.ActiveSkill, 0);
			}
			else
			{
				if (voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.ActiveSkill) == 0)
				{
					SoundManager.Instance.voDiva.Preload(DivaVoicePlayer.VoiceCategory.GameActiveSkill, 0);
				}
			}
			// Preload skill cutin
			SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_VALKYRIE_000);
			// Preload voice pilot
			for (int playVoiceId = 0; playVoiceId <= 1; playVoiceId++)
			{
				RhythmGameVoicePlayer.Result res = voicePlayer.PreloadPlayVoice(playVoiceId != 0 ? RhythmGameVoicePlayer.Voice.Wave_100 : RhythmGameVoicePlayer.Voice.Wave_50);
				if (res == RhythmGameVoicePlayer.Result.None)
				{
					PilotVoicePlayer.VoiceCategory catId = PilotVoicePlayer.VoiceCategory.Fwave;
					if (playVoiceId == 0)
					{
						if (resource.enterFoldWaveId_50 > -1)
						{
							playVoiceId = resource.enterFoldWaveId_50;
							catId = PilotVoicePlayer.VoiceCategory.Special;
						}
						else
						{
							catId = PilotVoicePlayer.VoiceCategory.Fwave;
						}
					}
					else
					{
						catId = PilotVoicePlayer.VoiceCategory.Fwave;
						if (playVoiceId == 1)
						{
							if (resource.enterFoldWaveId_100 < 0)
							{
								playVoiceId = 1;
								catId = PilotVoicePlayer.VoiceCategory.Fwave;
							}
							else
							{
								playVoiceId = resource.enterFoldWaveId_100;
								catId = PilotVoicePlayer.VoiceCategory.Special;
							}
						}
					}
					SoundManager.Instance.voPilot.Preload(catId, playVoiceId);
				}
			}
			// valkyriemode start
			SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_GAME_008);
			if (voicePlayer.PreloadPlayVoice(RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Start) == RhythmGameVoicePlayer.Result.None)
			{
				if (resource.enteredValkyrieModeVoiceId < 0)
				{
					SoundManager.Instance.voPilot.Preload(PilotVoicePlayer.VoiceCategory.Valkyrie, 0);
				}
				else
				{
					SoundManager.Instance.voPilot.Preload(PilotVoicePlayer.VoiceCategory.Special, resource.enteredValkyrieModeVoiceId);
				}
			}
			// enemy lock
			SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_GAME_013);
			// shoot
			SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_GAME_016);
			// valkyrie mode end
			if (setting.m_enable_cutin)
			{
				// fail
				if (voicePlayer.PreloadPlayVoice(RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Failed) == RhythmGameVoicePlayer.Result.None)
				{
					SoundManager.Instance.voPilot.Preload(PilotVoicePlayer.VoiceCategory.Valkyrie, 3);
				}
				// awaken
				if (voicePlayer.PreloadPlayVoice(RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Success2) == RhythmGameVoicePlayer.Result.None)
				{
					SoundManager.Instance.voPilot.Preload(PilotVoicePlayer.VoiceCategory.Valkyrie, 2);
				}
				// diva
				if (voicePlayer.PreloadPlayVoice(RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Success1) == RhythmGameVoicePlayer.Result.None)
				{
					SoundManager.Instance.voPilot.Preload(PilotVoicePlayer.VoiceCategory.Valkyrie, 1);
				}
			}
			// start diva cutscene
			// awaken
			{
				SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_GAME_017);
				if (voicePlayer.PreloadPlayVoice(RhythmGameVoicePlayer.Voice.Mode_Diva_Awake) == RhythmGameVoicePlayer.Result.None)
				{
					DivaVoicePlayer.VoiceCategory cat = DivaVoicePlayer.VoiceCategory.None;
					int voice = 0;
					if (resource.enterdAwakenDivaModeVoiceId < 0)
					{
						cat = DivaVoicePlayer.VoiceCategory.GameClear;
						voice = 1;
					}
					else
					{
						voice = resource.enterdAwakenDivaModeVoiceId;
						cat = DivaVoicePlayer.VoiceCategory.GameSpecial;
					}
					SoundManager.Instance.voDiva.Preload(cat, voice);
				}
			}
			// normal
			{
				SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_GAME_011);
				if (voicePlayer.PreloadPlayVoice(RhythmGameVoicePlayer.Voice.Mode_Diva) == RhythmGameVoicePlayer.Result.None)
				{
					DivaVoicePlayer.VoiceCategory cat = DivaVoicePlayer.VoiceCategory.None;
					int voice = 0;
					if (resource.enterdDivaModeVoiceId < 0)
					{
						cat = DivaVoicePlayer.VoiceCategory.GameClear;
						voice = 0;
					}
					else
					{
						voice = resource.enterdDivaModeVoiceId;
						cat = DivaVoicePlayer.VoiceCategory.GameSpecial;
					}
					SoundManager.Instance.voDiva.Preload(cat, voice);
				}
			}
			SoundManager.Instance.sePlayerGame.Preload((int)cs_se_game.SE_GAME_022);
			//
#endif
		}

		// // RVA: 0x9B3F80 Offset: 0x9B3F80 VA: 0x9B3F80
		private void InitializeCheatOption()
		{
			CheatFunction.Instance.Disable();
		}

		// // RVA: 0x9B7A4C Offset: 0x9B7A4C VA: 0x9B7A4C
		// private bool Lottery(float t_rate) { }

		// // RVA: 0x9B3FFC Offset: 0x9B3FFC VA: 0x9B3FFC
		private void InitializeMusicData()
		{
			totalComboNum = resource.musicData.musicScoreData.CalcComboLimit();
			bgmPlayer.RequestChangeCueSheet(resource.musicData.musicBase.KKPAHLMJKIH_WavId, null);
			bgmPlayer.ChangeMusicCue(resource.musicData.musicBase.KKPAHLMJKIH_WavId);
			musicMillisecLength = bgmPlayer.millisecLength;
			InitializeMusicScoreEvent();

			GameSetupData.TeamInfo t = Database.Instance.gameSetup.teamInfo;
			StatusData s = t.teamStatus;
			RhythmGameStatus.InitializeData initData;
			initData.musicData = resource.musicData;
			initData.teamScoreValue = s.soul + s.vocal + s.charm;
			initData.teamEnergyValue = s.fold;
			initData.supportRate = s.support * 1.0f / (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.MPAMBMKFCKK_BCoeff2) + 1;
			initData.valkyrieId = t.valkyrieId;
			initData.maxLife = s.life;
			initData.isLiveSkip = false;
			status = new RhythmGameStatus(initData, this.OnPlayPilotVoice);

			if (!setting_mv.m_enable)
			{
				if (!setting.m_enable_cutin)
				{
					status.energy.DisableCallbackPilotVoice();
				}
			}
			else
			{
				status.energy.DisableCallbackPilotVoice();
				AOJGDNFAIJL_PrismData.AMIECPBIALP a = new AOJGDNFAIJL_PrismData.AMIECPBIALP();
				a.OBKGEDCKHHE(Database.Instance.gameSetup.musicInfo.prismMusicId, 1 < Database.Instance.gameSetup.musicInfo.onStageDivaNum);
				int[] difficulties = a.CEMKPBIBOCG(Database.Instance.gameSetup.musicInfo.IsLine6Mode);
				float diff = difficulties[(int)Database.Instance.gameSetup.musicInfo.difficultyType] * 1.0f / IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.MPAMBMKFCKK_BCoeff2 + 1;
				status.enemy.SetFixDamageParamter(diff * a.FGCCCMAFCNH_GetMvValkAtk(), diff * a.GPGPOBJCMFB_GetMvValkAccuracy());
				status.life.isInvincibleModeMV = true;
			}
			m_NoteResultParam_Excellent.m_note_judge_rate = t.excellentRate / 100.0f;
			m_NoteResultParam_Excellent.m_score_rate = t.excellentScoreAdd / 100.0f;
			m_NoteParam_CLiveSkill.m_assign_rate = t.centerLiveSkillRate / 100.0f;
			m_NoteParam_EventItem.m_enable = JGEOBNENMAH.HHCJCDFCLOB.HIGJBGFJMMO;
			m_NoteAssingInfo.m_center_live_skill = UnityEngine.Random.Range(0, 100000) <= m_NoteParam_CLiveSkill.m_assign_rate * 100000.0f;
			m_NoteAssingInfo.m_center_live_skill_index = m_NoteParam_CLiveSkill.m_assign_index;
			m_NoteAssingInfo.m_event_item = m_NoteParam_EventItem.m_enable;
			m_NoteAssingInfo.m_event_item_index = m_NoteParam_EventItem.m_index;
			rNoteOwner.Initialize(resource.musicData, status.internalMode, buffOwner, m_NoteAssingInfo, setting_mv.m_enable, setting_mv.m_show_notes, false);
			rNoteOwner.RemoveAllDelegate();
			rNoteOwner.AddJudgeDelegate(this.RNoteJudgedResultDelegate);
			rNoteOwner.SetDelegateOverrideNoteJudge(this.RNoteOverwrideJudgedResultDelegate);
			if (!setting_mv.m_enable)
				return;
			soundCheerOrderer = new RhythmGameCheerSoundOrderer();
			soundCheerOrderer.Initialize(resource.musicData.cheerScoreData);
			soundCheerOrderer.Stop();
			soundCheerOrderer.Resume();
		}

		// // RVA: 0x9B4D20 Offset: 0x9B4D20 VA: 0x9B4D20
		private void InitializeGameData()
		{
			List<int> listDiva = new List<int>();
			int prismDivaId = Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId;
			listDiva.Add(prismDivaId);
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				int prismCostumeId = Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismCostumeModelId;
				gameDivaObject.Initialize(resource.divaResource, prismDivaId,
						resource.musicData.musicParam.IsUseCommonMike(prismDivaId, prismCostumeId));
				int subDivaNum = Database.Instance.gameSetup.musicInfo.onStageDivaNum - 1;
				GameDivaObject[] gdo = FindObjectsOfType<GameDivaObject>();
				for (int i = 0; i < 4; i++)
				{
					if (i < subDivaNum)
					{
						prismDivaId = Database.Instance.gameSetup.teamInfo.danceDivaList[i + 1].prismDivaId;
						if (prismDivaId == 0)
						{
							subDivaObject[i] = null;
						}
						else
						{
							prismCostumeId = Database.Instance.gameSetup.teamInfo.danceDivaList[i + 1].prismCostumeModelId;
							subDivaObject[i].Initialize(resource.subDivaResource[i], prismDivaId, resource.musicData.musicParam.IsUseCommonMike(prismDivaId, prismCostumeId));
							listDiva.Add(prismDivaId);
						}
					}
					else
					{
						for (int j = 0; j < gdo.Length; j++)
						{
							if (gdo[j].gameObject.name == "SubDivaGameObject"+(i+1))
							{
								gdo[j].gameObject.SetActive(false);
								break;
							}
						}
					}
				}
				List<int> orderedDivaList = new List<int>(listDiva);
				if(subDivaNum > 0)
				{
					orderedDivaList.Clear();
					int currentPos = 1;
					for(int i = 0; i < Database.Instance.gameSetup.teamInfo.danceDivaList.Length; )
					{
						if(Database.Instance.gameSetup.teamInfo.danceDivaList[i].positionId == currentPos)
						{
							orderedDivaList.Add(Database.Instance.gameSetup.teamInfo.danceDivaList[i].prismDivaId);
							i = 0;
							currentPos++;
						}
						else
						{
							i++;
						}
					}
				}
				musicCameraObject.Initialize(resource.cameraResource, orderedDivaList, resource.musicData.musicParam.IsEnabledDirection(MusicDirectionBoolParam.DirectionType.DivaAdjustXZ));
				stageObject.Initialize(resource.stageResources, resource.musicData.musicBase.KNMGEEFGDNI_Nam);
				valkyrieObject.Initialize(resource.valkyrieResource);
				valkyrieObject.SetOverrideAnimationIntro(resource.musicIntroResource);
				valkyrieObject.SetEnableAwakeEffect(resource.paramResource.m_paramValkyrieAwake.Check(Database.Instance.gameSetup));
				valkyrieObject.SetChangeExplosionEffect(resource.paramResource.m_paramValkyrieChangeExplosion.Check(Database.Instance.gameSetup));
				musicIntroObject.Initialize(resource.musicIntroResource);
				valkyrieModeObject.Initialize(resource.valkyrieModeResource, false);
				if(IsEnableMovie())
				{
					divaModeObject.Initialize(resource.divaModeResource.moviePlayer);
					divaModeObject.VisibleDiva = setting.m_visible_diva;
				}
				InitializeExtension();
				musicIntroObject.onPlayerCutInStart = this.MusicIntroStartPlayerCutInCallbackFor3DMode;
				valkyrieModeObject.onBeginShooting = this.ValkyrieModeBeginShootingCallback;
				valkyrieModeObject.onEndAnimationCallback = this.ValkyrieModeEndAnimationCallback;
				valkyrieModeObject.onPlayerCutInStart = this.ValkyrieModeStartPlayerCutInCallback;
				valkyrieModeObject.onEnemyCutInStart = this.ValkyrieModeStartEnemyCutInCallback;
				valkyrieModeObject.onEnemyLockOnStart = this.ValkyrieModeStartEnemyLockOnCallback;
				stageObject.SetupPsylliumColor(resource.musicData.musicParam, resource.divaResource.divaParam, resource.subDivaResource, subDivaNum);
				gameDivaObject.SetupDefaultMaterialColor(stageObject.param.mainColor, stageObject.param.rimColor, stageObject.param.rimPower, stageObject.param.shadowColor);
				gameDivaObject.AdjustHight(resource.musicData.musicParam.mikeStandOffsetRate);
				foreach(var ext in divaExtensionObjectList)
				{
					ext.SetupDefaultMaterialColor(stageObject.param.mainColor, stageObject.param.rimColor, stageObject.param.rimPower);
				}
				for(int i = 0; i < subDivaNum; i++)
				{
					if(subDivaObject[i] != null)
					{
						subDivaObject[i].SetupDefaultMaterialColor(stageObject.param.mainColor, stageObject.param.rimColor, stageObject.param.rimPower, stageObject.param.shadowColor);
						subDivaObject[i].AdjustHight(resource.musicData.musicParam.mikeStandOffsetRate);
						subDivaObject[i].SetupBoneSpring(resource, i + 1);
					}
				}
				gameDivaObject.SetupBoneSpring(resource, 0);
				musicCameraObject.AttachCameraBillboard();
				List<GameDivaObject> divaObjects = new List<GameDivaObject>();
				divaObjects.Add(gameDivaObject);
				divaObjects.AddRange(subDivaObject);
				musicCameraObject.AttachCameraDvaBillboard(divaObjects);
				objectRoot2dLayer.SetActive(false);
				ApplyDimmer();
				// L 1161
			}
			else
			{
				objectRoot3dLayer.SetActive(false);
				GameManager.Instance.PopupCanvas.worldCamera.clearFlags = CameraClearFlags.Depth;
				lowModeBackgroundObject.Initialize(resource.lowModeBackgroundResource);
			}

			uiController.Initialize(resource, setting, setting_mv);
			uiController.complete.SetCallback_PlayVoice_FullCombo(this.OnCallback_PlayVoice_GameClear_FullCombo);
			uiController.complete.SetCallback_PlayVoice_PerfectFullCombo(this.OnCallback_PlayVoice_GameClear_PerfectFullCombo);
			uiController.failed.SetCallback_PlayVoice_GameFailed(this.OnCallback_PlayVoice_GameFailed);
			rNoteOwner.SetLineAlphaCallback(uiController.Hud.SetLineAlpha);
			InitializeSkill();
			gamePerformer.InitializeTouch();
			gamePerformer.RemoveAllTouchEvents();
			gamePerformer.AddTouchEvents(this.BeganTouchEventCallback, this.EndedTouchEventCallback, this.ReleaseLineEventCallback, this.NextLineEventCallback,
										this.SwipedTouchEventCallback, this.NeutralTouchEventCallback, this.SkillTouchEventCallback);
			gamePerformer.SetActiveLineCallback(this.IsActiveLine);
			if(setting_mv.m_enable)
			{
				gamePerformer.isEnableTouch = false;
			}
			RhythmGameInputPerformer r = gamePerformer.GetComponent<RhythmGameInputPerformer>();
			r.InitializeGame(this, rNoteOwner, uiController.Hud, GameManager.Instance.GetSystemCanvasCamera());
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("cs_support_check_touch_fingerid", 0) > 0)
			{
				r.delegateCheckInput = this.CheckInputCallback;
			}

			noteOffsetMillisec = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OJAJHIMOIEC_NoteOffset * 10;

			bgmPlayer.source.player.SetStartTime(0);
			bgmPlayer.source.Stop();
			bgmPlayer.source.Pause(false);

			if(setting_mv.m_enable)
				uiController.Hud.PauseButton.AddListener(this.MvPauseButtonCallback);
			else
				uiController.Hud.PauseButton.AddListener(this.PauseButtonCallback);

			logger.Initialize(new RhythmGamePlayLog());
			logger.SetValkyrieModeTime(resource.musicData.valkyrieModeStartMillisec, resource.musicData.valkyrieModeLeaveMillisec);
			logger.SetDivaModeTime(resource.musicData.divaModeStartMillisec, resource.musicData.rhythmGameResultStartMillisec);
			logger.log.isImpossibleValkyrieMode = !status.energy.CalcPossiblityNextMode();
			logger.log.isImpossibleDivaMode = !status.enemy.CalcPossiblityNextMode();

			liveSkillActivateCountList.Clear();
			for(int i = 0; i < TeamConst.TeamSceneNum; i++)
			{
				liveSkillActivateCountList.Add(0);
			}

			if(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				uiController.Hud.SetPlayerDivaId(Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId);
				TodoLogger.LogError(0, "InitializeGameData BattleEvent");
				//L1814
			}

			voicePlayer = new RhythmGameVoicePlayer();
			voicePlayer.Initialize(resource.TryGetMusicVoiceChangerParam());
			continueCount = 0;
		}

		// // RVA: 0x9B9258 Offset: 0x9B9258 VA: 0x9B9258
		private void InitializeExtension()
		{
			int onStageDivaNum = Database.Instance.gameSetup.musicInfo.onStageDivaNum;
			List<GameDivaObject> divas = RhythmGameExtension.GetDivaListOnPositionId(gameDivaObject, subDivaObject, onStageDivaNum);
			RhythmGameExtension.DestroyExtensionList<StageExtensionObject>(ref stageExtensionObjectList);
			int subDivaCount = onStageDivaNum - 1;
			foreach(var ser in resource.stageExtensionResource)
			{
				StageExtensionObject obj = Resources.Load<StageExtensionObject>("MusicGame/ExtensionPrefabs/StageExtensionObject");
				StageExtensionObject instanceObj = Instantiate(obj);
				instanceObj.Initialize(ser, stageObject, musicCameraObject, divas);
				instanceObj.SetupPsylliumColor(resource.musicData.musicParam, resource.divaResource.divaParam, resource.subDivaResource);
				RhythmGameExtension.SettingHierarchy<StageExtensionObject>(ref instanceObj, "SceneRoot/Layer-3D/StageExtension");
				stageExtensionObjectList.Add(instanceObj);
			}
			RhythmGameExtension.DestroyExtensionList<DivaExtensionObject>(ref divaExtensionObjectList);
			foreach(var der in resource.divaExtensionResource)
			{
				GameDivaObject diva = RhythmGameExtension.GetDiva(gameDivaObject, subDivaObject, subDivaCount, der.divaId);
				DivaExtensionObject obj = Resources.Load<DivaExtensionObject>("MusicGame/ExtensionPrefabs/DivaExtensionObject");
				DivaExtensionObject instanceObj = Instantiate(obj);
				instanceObj.Initialize(der, diva, musicCameraObject, divas);
				RhythmGameExtension.SettingHierarchy<DivaExtensionObject>(ref instanceObj, "SceneRoot/Layer-3D/DivaExtension");
				divaExtensionObjectList.Add(instanceObj);
			}
			foreach(var seo in stageExtensionObjectList)
			{
				seo.AddExtentionSetupWind(divaExtensionObjectList);
			}
			RhythmGameExtension.DestroyExtensionList<StageLightingObject>(ref stageLightingObjectList);
			RhythmGameExtension.DestroyExtensionList<StageLightingAddObject>(ref stageLightingAddObjectList);
			foreach(var slr in resource.stageLightingResource)
			{
				StageLightingObject obj = Resources.Load<StageLightingObject>("MusicGame/ExtensionPrefabs/StageLightingObject");
				StageLightingObject instanceObj = Instantiate(obj);
				instanceObj.Initialize(slr, stageObject, gameDivaObject, stageExtensionObjectList, divaExtensionObjectList, subDivaObject, subDivaCount);
				RhythmGameExtension.SettingHierarchy<StageLightingObject>(ref instanceObj, "StageLighting");
				stageLightingObjectList.Add(instanceObj);
				for(int i = 0; i < slr.clip_add.Length; i++)
				{
					if(slr.clip_add[i] != null)
					{
						int position = Database.Instance.gameSetup.teamInfo.danceDivaList[i].positionId;
						GameDivaObject diva = gameDivaObject;
						if(position > 1)
						{
							diva = subDivaObject[position - 2];
						}
						StageLightingAddObject obj2 = Resources.Load<StageLightingAddObject>("MusicGame/ExtensionPrefabs/StageLightingAddObject");
						StageLightingAddObject instanceObj2 = Instantiate(obj2);
						instanceObj2.name = "StageLightingAddObject"+(i+1)+ "(Clone)";
						instanceObj2.Initialize(i, slr, diva, divaExtensionObjectList);
						RhythmGameExtension.SettingHierarchy<StageLightingAddObject>(ref instanceObj2, "StageLighting");
						stageLightingAddObjectList.Add(instanceObj2);
					}
				}
			}
			RhythmGameExtension.DestroyExtensionList<DivaCutinObject>(ref divaCutinObjectList);
			foreach(var dcr in resource.divaCutinResource)
			{
				GameDivaObject diva = RhythmGameExtension.GetDiva(gameDivaObject, subDivaObject, subDivaCount, dcr.divaId);
				DivaCutinObject obj = Resources.Load<DivaCutinObject>("MusicGame/ExtensionPrefabs/DivaCutinObject");
				DivaCutinObject instanceObj = Instantiate(obj);
				instanceObj.Initialize(dcr, diva);
				RhythmGameExtension.SettingHierarchy<DivaCutinObject>(ref instanceObj, "DivaCutin");
				divaCutinObjectList.Add(instanceObj);
			}
			RhythmGameExtension.DestroyExtensionList<MusicCameraCutinObject>(ref musicCameraCutinObjectList);
			int cnt = 0;
			foreach(var mccr in resource.musicCameraCutinResource)
			{
				MusicCameraCutinObject obj = Resources.Load<MusicCameraCutinObject>("MusicGame/ExtensionPrefabs/MusicCameraCutinObject");
				MusicCameraCutinObject instanceObj = Instantiate(obj);
				instanceObj.Initialize(mccr, musicCameraObject, cnt);
				RhythmGameExtension.SettingHierarchy<MusicCameraCutinObject>(ref instanceObj, "MusicCameraCutin");
				musicCameraCutinObjectList.Add(instanceObj);
				cnt++;
			}
		}

		// // RVA: 0x9AFA54 Offset: 0x9AFA54 VA: 0x9AFA54
		private void InitializeSetting()
		{
			backupSaveData = new BackupSaveData();
			setting_mv = new SettingMV();
			GameSetupData d = Database.Instance.gameSetup;
			if(d.musicInfo.IsMvMode)
			{
				BackupSave();
				ILDKBCLAFPB.MPHNGGECENI_Option saveInfo = XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options;
				BEJIKEOAJHN_OptionSLive b = XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive;
				saveInfo.PBCBJAPONBF();
				saveInfo.LMDACNNJDOE_VolSeRhythm = b.LMDACNNJDOE_VolSeRhythm;
				saveInfo.ICGAOAFIHFD_VolBgmRhythm = b.ICGAOAFIHFD_VolBgmRhythm;
				saveInfo.FCKEDCKCEFC_VolVoiceRhythm = b.FCKEDCKCEFC_VolVoiceRhythm;
				saveInfo.IBEINHHMHAC_VolNotesRhythm = b.IBEINHHMHAC_VolNotesRhythm;
				saveInfo.DDHCLNFPNGK_RenderQuality = b.DDHCLNFPNGK_RenderQuality;
				saveInfo.HHMCIGLCBNG_QualityCustomDiva3D = b.HHMCIGLCBNG_QualityCustomDiva3D;
				saveInfo.AHLFOHJMGAI_QualityCustomOther3D = b.AHLFOHJMGAI_QualityCustomOther3D;
				saveInfo.DADIPGPHLDD_EffectCutin = b.DADIPGPHLDD_EffectCutin;
				saveInfo.DCHMOFLEFMI_NotesSpeedEasy = backupSaveData.m_option.DCHMOFLEFMI_NotesSpeedEasy;
				saveInfo.MBOEPFLNDOD_NotesSpeedNormal = backupSaveData.m_option.MBOEPFLNDOD_NotesSpeedNormal;
				saveInfo.MGOOLKHAPAF_NotesSpeedHard = backupSaveData.m_option.MGOOLKHAPAF_NotesSpeedHard;
				saveInfo.AIKDLBAANLG_NotesSpeedVeryHard = backupSaveData.m_option.AIKDLBAANLG_NotesSpeedVeryHard;
				saveInfo.KOKDGGOFPPI_NotesSpeedExtreme = backupSaveData.m_option.KOKDGGOFPPI_NotesSpeedExtreme;
				saveInfo.LIPAPGABJOA_NotesSpeedHardPlus = backupSaveData.m_option.LIPAPGABJOA_NotesSpeedHardPlus;
				saveInfo.JDJBFBPBLDC_NotesSpeedVeryHardPlus = backupSaveData.m_option.JDJBFBPBLDC_NotesSpeedVeryHardPlus;
				saveInfo.FJKNAHGFAPP_NotesSpeedExtremePlus = backupSaveData.m_option.FJKNAHGFAPP_NotesSpeedExtremePlus;
				saveInfo.OJAJHIMOIEC_NoteOffset = backupSaveData.m_option.OJAJHIMOIEC_NoteOffset;
				saveInfo.OAKOJGPBAJF_BackKey = backupSaveData.m_option.OAKOJGPBAJF_BackKey;
				saveInfo.IHEPCAHBECA_VideoMode = backupSaveData.m_option.IHEPCAHBECA_VideoMode;
				saveInfo.NFMEIILKACN_NotesRoute = backupSaveData.m_option.NFMEIILKACN_NotesRoute;
				saveInfo.KDNKCOAJGCM_NotesType = backupSaveData.m_option.KDNKCOAJGCM_NotesType;
				saveInfo.MJHEPGIEDDL_IsSlideNoteEffect = backupSaveData.m_option.MJHEPGIEDDL_IsSlideNoteEffect;
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_BGM, saveInfo.ICGAOAFIHFD_VolBgmRhythm, true);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_SE, saveInfo.LMDACNNJDOE_VolSeRhythm, true);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_NOTES, saveInfo.IBEINHHMHAC_VolNotesRhythm, true);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_VOICE, saveInfo.FCKEDCKCEFC_VolVoiceRhythm, true);
				setting_mv.m_enable = true;
				setting_mv.m_mode_diva = d.mvInfo.isModeDiva;
				setting_mv.m_mode_valkyrie = d.mvInfo.isModeValkyrie;
				setting_mv.m_show_notes = d.mvInfo.isShowNotes;
				if (RuntimeSettings.CurrentSettings.DisableNoteSound)
					isIgnorePlayNotesSE = true;
			}
			else
			{
				isIgnorePlayNotesSE = XeApp.Game.Common.SoundManager.Instance.GetCategoryVolume(SoundManager.CategoryId.GAME_NOTES) <= 0.0f;
			}
			
			if(d.ForceCutin() > 0)
			{
				BackupSave();
				XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DADIPGPHLDD_EffectCutin = d.ForceCutin() != 1 ? 1 : 0;
			}
			if(d.ForceDivaMode() > 0)
			{
				BackupSave();
				XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PMGMMMGCEEI_Video = d.ForceDivaMode() != 1 ? 1 : 0;
			}
			if(d.ForceValkyrieMode() > 0)
			{
				BackupSave();
				XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.AFMDGKBANPH_SetValkyrieMode(d.ForceValkyrieMode() != 1); // ??
			}
			
			setting = new Setting();
			setting.m_enable_cutin = XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GLKGAOFHLPN_IsCutinEnabled();
			setting.m_visible_diva = XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CJKKALFPMLA_IsNotDivaModeDivaVisible;
			if(setting_mv.m_enable)
			{
				Setting.DMode a = Setting.DMode.Normal;
				if(setting_mv.m_mode_diva)
					a = Setting.DMode.DivaAwake;
				setting.m_mode_dv = a;
				Setting.VMode b = Setting.VMode.Normal;
				if(setting_mv.m_mode_valkyrie)
					b = Setting.VMode.Valkyrie;
				setting.m_mode_vl = b;
			}
		}

		// // RVA: 0x9B0954 Offset: 0x9B0954 VA: 0x9B0954
		// private void FinalizeSetting() { }

		// // RVA: 0x9BAE64 Offset: 0x9BAE64 VA: 0x9BAE64
		private void BackupSave()
		{
			if (backupSaveData.m_enable)
				return;
			backupSaveData.m_enable = true;
			backupSaveData.m_option = new ILDKBCLAFPB.MPHNGGECENI_Option();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.ODDIHGPONFL_Copy(backupSaveData.m_option);
		}

		// // RVA: 0x9BAFE8 Offset: 0x9BAFE8 VA: 0x9BAFE8
		private void RestoreSave()
		{
			if(backupSaveData.m_enable)
			{
				XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options = backupSaveData.m_option;
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_BGM, backupSaveData.m_option.ICGAOAFIHFD_VolBgmRhythm, false);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_SE, backupSaveData.m_option.LMDACNNJDOE_VolSeRhythm, false);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_NOTES, backupSaveData.m_option.IBEINHHMHAC_VolNotesRhythm, false);
				XeApp.Game.Common.SoundManager.Instance.SetCategoryVolumeFromMark(SoundManager.CategoryId.GAME_VOICE, backupSaveData.m_option.FCKEDCKCEFC_VolVoiceRhythm, false);
				backupSaveData.m_enable = false;
				backupSaveData.m_option = null;
			}
		}

		// // RVA: 0x9BA7BC Offset: 0x9BA7BC VA: 0x9BA7BC
		private void ApplyDimmer()
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OLALFDCEHKJ_Dimmer3d > 9)
			{
				dimmer3dMesh.gameObject.SetActive(false);
			}
			else
			{
				dimmer3dMesh.gameObject.SetActive(true);
				dimmer3dMesh.sharedMaterial = new Material(dimmer3dMesh.sharedMaterial);
				dimmer3dMesh.sharedMaterial.color = new Color(0, 0, 0, (10 - GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OLALFDCEHKJ_Dimmer3d) * 180.0f / 10.0f / 255.0f );
			}
		}

		// // RVA: 0x9B7A9C Offset: 0x9B7A9C VA: 0x9B7A9C
		private void InitializeMusicScoreEvent()
		{
			introFadeEvent = new RhythmGameScoreEvent();
			if(resource.musicData.introFadeMillisec > -1)
			{
				introFadeEvent.onFireEvent = this.StartIntroFade;
				introFadeEvent.millisec = resource.musicData.introFadeMillisec;
				resource.musicIntroResource.OverrideIntroEndTime(ref introFadeEvent.millisec);
			}
			normalModeEndEvent = new RhythmGameScoreEvent();
			if(resource.musicData.valkyrieModeJudgeMillisec > -1)
			{
				normalModeEndEvent.onFireEvent = this.EndNormalMode;
				normalModeEndEvent.millisec = resource.musicData.valkyrieModeJudgeMillisec;
			}
			valkyrieStartHUDEvent = new RhythmGameScoreEvent();
			if (resource.musicData.valkyrieModeStartHUDMillisec > -1)
			{
				valkyrieStartHUDEvent.onFireEvent = this.StartValkyrieHUD;
				valkyrieStartHUDEvent.millisec = resource.musicData.valkyrieModeStartHUDMillisec;
			}
			valkyriePreFadeEvent = new RhythmGameScoreEvent();
			if (resource.musicData.valkyrieModeStartFadeMillisec > -1)
			{
				valkyriePreFadeEvent.onFireEvent = this.StartValkyriePreFade;
				valkyriePreFadeEvent.millisec = resource.musicData.valkyrieModeStartFadeMillisec;
			}
			valkyrieModeStartEvent = new RhythmGameScoreEvent();
			if (resource.musicData.valkyrieModeStartMillisec > -1)
			{
				valkyrieModeStartEvent.onFireEvent = this.StartValkyrieMode;
				valkyrieModeStartEvent.millisec = resource.musicData.valkyrieModeStartMillisec;
			}
			valkyrieModeEndEvent = new RhythmGameScoreEvent();
			if (resource.musicData.divaModeJudgeMillisec > -1)
			{
				valkyrieModeEndEvent.onFireEvent = this.EndValkyrieMode;
				valkyrieModeEndEvent.millisec = resource.musicData.divaModeJudgeMillisec;
			}
			valkyrieCutsceneStartEvent = new RhythmGameScoreEvent();
			if (resource.musicData.valkyrieModeStartMillisec > -1)
			{
				valkyrieCutsceneStartEvent.onFireEvent = this.StartValkyrieCutscene;
				valkyrieCutsceneStartEvent.millisec = resource.musicData.valkyrieModeStartMillisec;
			}
			valkyrieCutsceneEndEvent = new RhythmGameScoreEvent();
			if (resource.musicData.valkyrieModeLeaveMillisec > -1)
			{
				valkyrieCutsceneEndEvent.onFireEvent = this.EndValkyrieCutscene;
				valkyrieCutsceneEndEvent.millisec = resource.musicData.valkyrieModeLeaveMillisec;
			}
			divaModeStartEvent = new RhythmGameScoreEvent();
			if (resource.musicData.divaModeStartMillisec > -1)
			{
				divaModeStartEvent.onFireEvent = this.StartDivaMode;
				divaModeStartEvent.millisec = resource.musicData.divaModeStartMillisec;
			}
			divaCutsceneStartEvent = new RhythmGameScoreEvent();
			if (resource.musicData.divaModeStartMillisec > -1)
			{
				divaCutsceneStartEvent.onFireEvent = this.StartDivaCutscene;
				divaCutsceneStartEvent.millisec = resource.musicData.divaModeStartMillisec;
			}
			rhythmGameResultStartEvent = new RhythmGameScoreEvent();
			rhythmGameResultStartEvent.onFireEvent = OnStartRhythmGameResult;
			if (resource.musicData.rhythmGameResultStartMillisec < 0)
			{
				resource.musicData.rhythmGameResultStartMillisec = musicMillisecLength - 5000;
				TodoLogger.LogError(0, "Shouldn't pass here");
			}
			else
			{
				rhythmGameResultStartEvent.millisec = resource.musicData.rhythmGameResultStartMillisec;
			}
			tutorialOneEndEvent = new RhythmGameScoreEvent();
			if (resource.musicData.tutorialOneEndGameStartMillisec > -1)
			{
				tutorialOneEndEvent.onFireEvent = () =>
				{
					//0xBF1658
					TodoLogger.LogError(0, "TutorialOnEndEvent");
				};
				tutorialOneEndEvent.millisec = resource.musicData.tutorialOneEndGameStartMillisec;
			}
			tutorialTwoFoceFWaveMaxEvent = new RhythmGameScoreEvent();
			if (resource.musicData.tutorialTwoForceFwaveMaxStartMillisec > -1)
			{
				tutorialTwoFoceFWaveMaxEvent.onFireEvent = this.ForceChangePercentage100ForTutorial;
				tutorialTwoFoceFWaveMaxEvent.millisec = resource.musicData.tutorialTwoForceFwaveMaxStartMillisec;
			}
			tutorialTwoFoceEnemyDefeatEvent = new RhythmGameScoreEvent();
			if (resource.musicData.tutorialTwoForceDefeatEnemyStartMillisec > -1)
			{
				tutorialTwoFoceEnemyDefeatEvent.onFireEvent = this.ForceDefeatEnemyForTutorial;
				tutorialTwoFoceEnemyDefeatEvent.millisec = resource.musicData.tutorialTwoForceDefeatEnemyStartMillisec;
			}
			tutorialTwoModeDescriptionEvent = new RhythmGameScoreEvent();
			if (resource.musicData.tutorialTwoModeDescriptionlStartMillisec > -1)
			{
				tutorialTwoModeDescriptionEvent.onFireEvent = () =>
				{
					//Method$XeApp.Game.RhythmGame.RhythmGamePlayer.<>c.<InitializeMusicScoreEvent>b__227_1()
				};
				tutorialTwoModeDescriptionEvent.millisec = resource.musicData.tutorialTwoModeDescriptionlStartMillisec;
			}
			tutorialTwoActiveSkillGuideEvent = new RhythmGameScoreEvent();
			if (resource.musicData.tutorialTwoModeDescriptionlStartMillisec > -1)
			{
				tutorialTwoActiveSkillGuideEvent.onFireEvent = this.ShowTutorialActiveSkillGuide;
				tutorialTwoActiveSkillGuideEvent.millisec = 17000;
			}
			if(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				TodoLogger.LogError(0, "InitializeMusicScoreEvent Event Type 3");
				//L744
			}
			if(setting.m_enable_cutin)
			{
				if(setting_mv.m_enable)
				{
					if(setting_mv.m_mode_valkyrie)
					{
						if(resource.musicData.cheerScoreData != null)
						{
							for(int i = 0; i < resource.musicData.cheerScoreData.eventTrack10.Count; i++)
							{
								if(resource.musicData.cheerScoreData.eventTrack10[i].value == 2)
								{
									mvPilotCutinSecondEvent = new RhythmGameScoreEvent();
									if(resource.musicData.cheerScoreData.eventTrack10[i].time > -1)
									{
										mvPilotCutinSecondEvent.onFireEvent = this.OnPlayPilotVoice1_FromMV;
										mvPilotCutinSecondEvent.millisec = resource.musicData.cheerScoreData.eventTrack10[i].time;
									}
								}
								if (resource.musicData.cheerScoreData.eventTrack10[i].value == 1)
								{
									mvPilotCutinFirstEvent = new RhythmGameScoreEvent();
									if (resource.musicData.cheerScoreData.eventTrack10[i].time > -1)
									{
										mvPilotCutinFirstEvent.onFireEvent = this.OnPlayPilotVoice0_FromMV;
										mvPilotCutinFirstEvent.millisec = resource.musicData.cheerScoreData.eventTrack10[i].time;
									}
								}
							}
						}
					}
				}
			}
		}

		// // RVA: 0x9BAA40 Offset: 0x9BAA40 VA: 0x9BAA40
		private void InitializeSkill()
		{
			if (setting_mv.m_enable)
				return;
			skillOwner.status = status;
			skillOwner.CreateList();
			skillOwner.onFullfillLiveSkill = OnFullfillLiveSkill;
			skillOwner.onFullfillEnemySkill = OnFullfillEnemySkill;
			skillOwner.onFullfillActiveSkill = OnFullfillActiveSkill;
			buffOwner.ClearAll();
			buffOwner.Initialize();
			buffOwner.AddActiveEvent(OnActiveBuffEffect);
			buffOwner.AddRemoveEvent(OnRemoveBuffEffect);
			buffOwner.poisonEvent.AddListener(OnPosionSkillDamageCallback);
			uiController.Hud.DisableActiveSkillButton();
			skillTouched = false;
			touchedCenterLiveSkill = false;
			touchedEventItem = false;
			skillOwner.CheckFirstTrigger();
		}

		// // RVA: 0x9BB22C Offset: 0x9BB22C VA: 0x9BB22C
		private void StartIntroFade()
		{
			uguiFader.Fade(0.5f, new Color(IntroEndFadeColor.r, IntroEndFadeColor.g, IntroEndFadeColor.b, 0), IntroEndFadeColor);
			this.StartCoroutineWatched(WaitIntroFade());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x744AD4 Offset: 0x744AD4 VA: 0x744AD4
		// // RVA: 0x9BB324 Offset: 0x9BB324 VA: 0x9BB324
		private IEnumerator WaitIntroFade()
		{
			//0xBF41C0
			while (uguiFader.isFading)
				yield return null;
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				musicIntroObject.End();
			}
			else
			{
				lowModeBackgroundObject.ChangeCardBg();
			}
			uguiFader.Fade(1.0f, 0.0f);
			if (!setting_mv.m_enable)
				yield break;
			while (uguiFader.isFading)
				yield return null;
			uiController.Hud.EnablePauseButton();
		}

		// // RVA: 0x9BB3AC Offset: 0x9BB3AC VA: 0x9BB3AC
		private void OnPlayPilotVoice(int playVoiceId)
		{
			RhythmGameVoicePlayer.Result res = voicePlayer.ChangePlayVoice(playVoiceId != 0 ? RhythmGameVoicePlayer.Voice.Wave_100 : RhythmGameVoicePlayer.Voice.Wave_50);
			if(res == RhythmGameVoicePlayer.Result.None)
			{
				PilotVoicePlayer.VoiceCategory catId = PilotVoicePlayer.VoiceCategory.Fwave;
				if(playVoiceId == 0)
				{
					if(resource.enterFoldWaveId_50 > -1)
					{
						playVoiceId = resource.enterFoldWaveId_50;
						catId = PilotVoicePlayer.VoiceCategory.Special;
					}
					else
					{
						catId = PilotVoicePlayer.VoiceCategory.Fwave;
					}
				}
				else
				{
					catId = PilotVoicePlayer.VoiceCategory.Fwave;
					if(playVoiceId == 1)
					{
						if(resource.enterFoldWaveId_100 < 0)
						{
							playVoiceId = 1;
							catId = PilotVoicePlayer.VoiceCategory.Fwave;
						}
						else
						{
							playVoiceId = resource.enterFoldWaveId_100;
							catId = PilotVoicePlayer.VoiceCategory.Special;
						}
					}
				}
				SoundManager.Instance.voPilot.Play(catId, playVoiceId);
			}
			uiController.Hud.ShowPilotCutin();
		}

		// // RVA: 0x9BB5F0 Offset: 0x9BB5F0 VA: 0x9BB5F0
		private void OnPlayPilotVoice0_FromMV()
		{
			OnPlayPilotVoice(0);
		}

		// // RVA: 0x9BB5F8 Offset: 0x9BB5F8 VA: 0x9BB5F8
		private void OnPlayPilotVoice1_FromMV()
		{
			OnPlayPilotVoice(1);
		}

		// // RVA: 0x9BB600 Offset: 0x9BB600 VA: 0x9BB600
		private void EndNormalMode()
		{
			status.directionMode.type = 0;
			if (status.energy.mode == 0)
			{
				status.internalMode.type = 0;
			}
			else if (status.energy.mode > 0)
			{
				status.internalMode.isValkyriePlayed = true;
				status.internalMode.type = RhythmGameMode.Type.Valkyrie;
			}
			if (setting.m_mode_vl == Setting.VMode.Normal)
			{
				status.internalMode.type = 0;
			}
			else if (setting.m_mode_vl == Setting.VMode.Valkyrie)
			{
				status.internalMode.isValkyriePlayed = true;
				status.internalMode.type = RhythmGameMode.Type.Valkyrie;
			}
			rNoteOwner.OnChangeGameMode();
		}

		// // RVA: 0x9BB81C Offset: 0x9BB81C VA: 0x9BB81C
		private void StartValkyrieHUD()
		{
			if(status.internalMode.type != RhythmGameMode.Type.Valkyrie)
			{
				uiController.Hud.ShowLowEnergy();
				return;
			}
			uiController.Hud.ShowValkyrie();
			SoundManager.Instance.sePlayerGame.Play((int)cs_se_game.SE_GAME_009);
		}

		// // RVA: 0x9BB820 Offset: 0x9BB820 VA: 0x9BB820
		// private void ShowValkyrieHUD() { }

		// // RVA: 0x9BBA08 Offset: 0x9BBA08 VA: 0x9BBA08
		private void StartValkyriePreFade()
		{
			if(status.internalMode.type == RhythmGameMode.Type.Valkyrie)
			{
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.AOOKLMAPPLG_IsValkyrieModeEnabled())
				{
					uguiFader.Fade(0.05f, new Color(ValkyrieStartFadeColor.r, ValkyrieStartFadeColor.g, ValkyrieStartFadeColor.b, 0), ValkyrieStartFadeColor);
				}
			}
		}

		// // RVA: 0x9BBC4C Offset: 0x9BBC4C VA: 0x9BBC4C
		private void StartValkyrieMode()
		{
			logger.log.valkyrieModeData.type = status.internalMode.type;
			if(status.internalMode.type != RhythmGameMode.Type.Valkyrie)
			{
				return;
			}
			status.directionMode.type = status.internalMode.type;
			ReJudgeValkyrieNotes();
		}

		// // RVA: 0x9BC4A0 Offset: 0x9BC4A0 VA: 0x9BC4A0
		private void StartValkyrieCutscene()
		{
			if (status.internalMode.type != RhythmGameMode.Type.Valkyrie)
				return;
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.AOOKLMAPPLG_IsValkyrieModeEnabled())
			{
				uguiFader.Fade(0.05f, ValkyrieStartFadeColor, new Color(ValkyrieStartFadeColor.r, ValkyrieStartFadeColor.g, ValkyrieStartFadeColor.b, 0));
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
				{
					valkyrieModeObject.Begin(false);
					valkyrieObject.SetIBLColor(resource.valkyrieModeResource.paramColor);
				}
				else
				{
					this.StartCoroutineWatched(Co_2DModeEnemyUIAnim(currentRawMusicMillisec));
				}
			}
			else
			{
				this.StartCoroutineWatched(Co_2DModeEnemyUIAnim(currentRawMusicMillisec));
			}
			uiController.Hud.isBattleLimitTimeRunning = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x744B4C Offset: 0x744B4C VA: 0x744B4C
		// // RVA: 0x9BC85C Offset: 0x9BC85C VA: 0x9BC85C
		private IEnumerator Co_2DModeEnemyUIAnim(int startRawMusicMillisec)
		{
			//0xBF1E14
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.AOOKLMAPPLG_IsValkyrieModeEnabled())
			{
				lowModeBackgroundObject.ChangeBattleBg();
			}
			yield return new WaitWhile(() =>
			{
				//0xBF1668
				return currentRawMusicMillisec - startRawMusicMillisec < 300;
			});
			if(setting.m_enable_cutin)
			{
				RhythmGameVoicePlayer.Result r = voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Start);
				if(r == RhythmGameVoicePlayer.Result.None)
				{
					if(resource.enteredValkyrieModeVoiceId < 0)
					{
						SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Valkyrie, 0);
					}
					else
					{
						SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Special, resource.enteredValkyrieModeVoiceId);
					}
				}
				uiController.Hud.ShowPilotCutin();
				uiController.Hud.ShowEnemyCutin();
			}
			yield return new WaitWhile(() =>
			{
				//0xBF16A4
				return currentRawMusicMillisec - startRawMusicMillisec < 1750;
			});
			SoundManager.Instance.sePlayerGame.Play((int)cs_se_game.SE_GAME_013);
			uiController.Hud.ShowEnemyStatus();
			uiController.Hud.ShowHitResult();
			uiController.Hud.ShowTargetSight();
		}

		// // RVA: 0x9BC900 Offset: 0x9BC900 VA: 0x9BC900
		private void EndValkyrieMode()
		{
			if(setting.m_mode_dv == Setting.DMode.None)
			{
				if (!status.directionMode.isValkyriePlayed)
					return;
				status.directionMode.type = RhythmGameMode.Type.None;
				if(status.enemy.mode == RhythmGameEnemyStatus.Mode.Goal)
				{
					status.internalMode.isAwakenDivaPlayed = true;
					status.internalMode.type = RhythmGameMode.Type.AwakenDiva;
				}
				else if(status.enemy.mode == RhythmGameEnemyStatus.Mode.Normal)
				{
					status.internalMode.type = RhythmGameMode.Type.None;
				}
				else if(status.enemy.mode == RhythmGameEnemyStatus.Mode.Subgoal)
				{
					status.internalMode.isDivaPlayed = true;
					status.internalMode.type = RhythmGameMode.Type.Diva;
				}
			}
			else
			{
				status.directionMode.type = RhythmGameMode.Type.None;
				if(setting.m_mode_dv == Setting.DMode.Normal)
				{
					status.internalMode.type = RhythmGameMode.Type.Normal;
				}
				else if(setting.m_mode_dv == Setting.DMode.Diva)
				{
					status.internalMode.isDivaPlayed = true;
					status.internalMode.type = RhythmGameMode.Type.Diva;
				}
				else if(setting.m_mode_dv == Setting.DMode.DivaAwake)
				{
					status.internalMode.isAwakenDivaPlayed = true;
					status.internalMode.type = RhythmGameMode.Type.AwakenDiva;
				}
			}
			rNoteOwner.OnChangeGameMode();
		}

		// // RVA: 0x9BCB28 Offset: 0x9BCB28 VA: 0x9BCB28
		private void EndValkyrieCutscene()
		{
			if (!status.directionMode.isValkyriePlayed)
				return;
			bool failed = status.internalMode.type < RhythmGameMode.Type.Diva && !setting_mv.m_enable;
			uiController.Hud.HideValkyrie(failed);
			if(setting.m_enable_cutin)
			{
				if(failed)
				{
					if(voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Failed) == RhythmGameVoicePlayer.Result.None)
					{
						SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Valkyrie, 3);
					}
				}
				else
				{
					if(status.internalMode.type == RhythmGameMode.Type.AwakenDiva)
					{
						if(voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Success2) == RhythmGameVoicePlayer.Result.None)
						{
							SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Valkyrie, 2);
						}
					}
					else
					{
						if (voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Success1) == RhythmGameVoicePlayer.Result.None)
						{
							SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Valkyrie, 1);
						}
					}
				}
			}
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				valkyrieModeObject.SetFailed(failed);
				valkyrieModeObject.Leave();
			}
			else
			{
				this.StartCoroutineWatched(Co_2DModeChangeBg(currentRawMusicMillisec));
			}
			uiController.Hud.isBattleLimitTimeRunning = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x744BC4 Offset: 0x744BC4 VA: 0x744BC4
		// // RVA: 0x9BD058 Offset: 0x9BD058 VA: 0x9BD058
		private IEnumerator Co_2DModeChangeBg(int startRawMusicMillisec)
		{
			//0xBF1BD8
			yield return new WaitWhile(() =>
			{
				//0xBF16EC
				return currentRawMusicMillisec - startRawMusicMillisec < 2000;
			});
			lowModeBackgroundObject.ChangeCardBg();
		}

		// // RVA: 0x9BD0FC Offset: 0x9BD0FC VA: 0x9BD0FC
		private void StartDivaMode()
		{
			logger.log.divaModeData.type = status.internalMode.type;
			if (status.internalMode.type < RhythmGameMode.Type.Diva)
				return;
			status.directionMode.type = status.internalMode.type;
			uiController.Hud.ShowDiva(status.internalMode.type == RhythmGameMode.Type.AwakenDiva);
		}

		// // RVA: 0x9BD384 Offset: 0x9BD384 VA: 0x9BD384
		private void StartDivaCutscene()
		{
			if (status.internalMode.type >= RhythmGameMode.Type.Diva)
			{
				bool is3D = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D;
				if(status.internalMode.type == RhythmGameMode.Type.AwakenDiva)
				{
					SoundManager.Instance.sePlayerGame.Play((int)cs_se_game.SE_GAME_017);
					if(voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.Mode_Diva_Awake) == RhythmGameVoicePlayer.Result.None)
					{
						DivaVoicePlayer.VoiceCategory cat = DivaVoicePlayer.VoiceCategory.None;
						int voice = 0;
						if(resource.enterdAwakenDivaModeVoiceId < 0)
						{
							cat = DivaVoicePlayer.VoiceCategory.GameClear;
							voice = 1;
						}
						else
						{
							voice = resource.enterdAwakenDivaModeVoiceId;
							cat = DivaVoicePlayer.VoiceCategory.GameSpecial;
						}
						SoundManager.Instance.voDiva.Play(cat, voice);
					}
					if(is3D)
					{
						gameDivaObject.AwakenAuraOn();
					}
				}
				else
				{
					SoundManager.Instance.sePlayerGame.Play((int)cs_se_game.SE_GAME_011);
					if(voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.Mode_Diva) == RhythmGameVoicePlayer.Result.None)
					{
						DivaVoicePlayer.VoiceCategory cat = DivaVoicePlayer.VoiceCategory.None;
						int voice = 0;
						if (resource.enterdDivaModeVoiceId < 0)
						{
							cat = DivaVoicePlayer.VoiceCategory.GameClear;
							voice = 0;
						}
						else
						{
							voice = resource.enterdDivaModeVoiceId;
							cat = DivaVoicePlayer.VoiceCategory.GameSpecial;
						}
						SoundManager.Instance.voDiva.Play(cat, voice);
					}
					if(is3D)
					{
						gameDivaObject.AwakenAuraOff();
					}
				}
				if(IsEnableMovie())
				{
					divaModeObject.Begin();
					divaModeObject.SetPreEndMovieCallback(this.EndDivaPreFade, 0.5f);
					divaModeObject.onEndMovieCallback = this.EndDivaCutscene;
					gameDivaObject.ChangeMovieMaterialColor(true);
					for (int i = 0; i < subDivaObject.Length; i++)
					{
						if(subDivaObject[i] != null)
						{
							subDivaObject[i].ChangeMovieMaterialColor(true);
						}
					}
					foreach(var d in divaExtensionObjectList)
					{
						d.ChangeMovieMaterialColor(true);
					}
				}
			}
		}

		// // RVA: 0x9BDAA0 Offset: 0x9BDAA0 VA: 0x9BDAA0
		private void EndDivaPreFade()
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				uguiFader.Fade(0.5f, new Color(DivaModeEndFadeColor.r, DivaModeEndFadeColor.g, DivaModeEndFadeColor.b, 0), DivaModeEndFadeColor);
			}
		}

		// // RVA: 0x9BDC24 Offset: 0x9BDC24 VA: 0x9BDC24
		private void EndDivaCutscene()
		{
			if(IsEnableMovie())
			{
				divaModeObject.End();
				gameDivaObject.ChangeMovieMaterialColor(false);
				foreach(var d in divaExtensionObjectList)
				{
					d.ChangeMovieMaterialColor(false);
				}
				for(int i = 0; i < subDivaObject.Length; i++)
				{
					if(subDivaObject[i] != null)
						subDivaObject[i].ChangeMovieMaterialColor(false);
				}
				uguiFader.Fade(0.5f, DivaModeEndFadeColor, new Color(DivaModeEndFadeColor.r, DivaModeEndFadeColor.g, DivaModeEndFadeColor.b, 0));
			}
		}

		// // RVA: 0x9BDF60 Offset: 0x9BDF60 VA: 0x9BDF60
		private void OnStartRhythmGameResult()
		{
			if (Database.Instance.gameSetup.musicInfo.isTutorialOne || Database.Instance.gameSetup.musicInfo.isTutorialTwo)
				BasicTutorialManager.Instance.HideCursor();
			uiController.Hud.DisablePauseButton();
		}

		// // RVA: 0x9B2BA0 Offset: 0x9B2BA0 VA: 0x9B2BA0
		private void UpdateSkill(int musicMillisec)
		{
			if (isResetRequest)
				return;
			if(!isVisiblePauseWindow && !rhythmGameResultStartEvent.active)
			{
				// Nothing
			}
			else
			{
				skillOwner.CheckTrigger(new SkillTriggerParameter()
				{
					musicTime = musicMillisec / 1000.0f,
					currentLifeRate = status.life.current * 1.0f / status.life.max,
					currentCombo = status.combo.current,
					currentScore = status.score.currentScore,
					valkyeriModeEndTimeMs = resource.musicData.valkyrieModeLeaveMillisec,
					modeType = status.directionMode.type,
					touchedSkill = skillTouched,
					touchedCenterLiveSkillNote = touchedCenterLiveSkill
				}, buffOwner);
				OnActiveSkill_Update(musicMillisec);
			}
			buffOwner.OnUpdate(new BuffDurationCheckParameter()
			{
				musicTime = musicMillisec / 1000.0f,
				isValkyrieMode = false,
				modeType = status.directionMode.type,
				bitNoteResult = m_bit_note_result
			});
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.Poison, -1))
			{
				uiController.Hud.SetPoisonSkillEffect(0, true);
			}
			else
			{
				uiController.Hud.SetPoisonSkillEffect(0, false);
			}
			uiController.ShowLIVESkill();
		}

		// // RVA: 0x9BE618 Offset: 0x9BE618 VA: 0x9BE618
		private void OnPosionSkillDamageCallback(BuffEffect buff)
		{
			float f = 1;
			if(buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ReduceDamage, -1))
			{
				f = 1 - Mathf.Min(buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ReduceDamage, -1, RhythmGameConsts.NoteResult.None) / 100.0f, 1);
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.NoDamage, -1))
			{
				f = 0;
			}
			status.life.DamageValue(Mathf.RoundToInt(f * buff.effectValue));
		}

		// // RVA: 0x9BE84C Offset: 0x9BE84C VA: 0x9BE84C
		private void MusicIntroStartPlayerCutInCallback()
		{
			if(!setting.m_enable_cutin)
				return;
			
			RhythmGameVoicePlayer.Result res = voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.TakeOff);
			if(RhythmGameVoicePlayer.Result.Diva == res)
			{
				uiController.Hud.ShowDivaCutin();
			}
			else if(RhythmGameVoicePlayer.Result.Pilot == res)
			{
				uiController.Hud.ShowPilotCutin();
			}
			else if(RhythmGameVoicePlayer.Result.None == res)
			{
				if(resource.isTakeoffDivaVoice)
				{
					XeApp.Game.Common.SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.GameSpecial, resource.takeoffVoiceId);
					uiController.Hud.ShowDivaCutin();
				}
				else
				{
					int voiceId = resource.takeoffVoiceId;
					PilotVoicePlayer.VoiceCategory categoryId = PilotVoicePlayer.VoiceCategory.Start;
					if(voiceId < 0)
					{
						categoryId = PilotVoicePlayer.VoiceCategory.Start;
						voiceId = 0;
					}
					else
					{
						categoryId = PilotVoicePlayer.VoiceCategory.Special;
					}
					XeApp.Game.Common.SoundManager.Instance.voPilot.Play(categoryId, voiceId);
					uiController.Hud.ShowPilotCutin();
				}
			}
		}

		// // RVA: 0x9BEC9C Offset: 0x9BEC9C VA: 0x9BEC9C
		private void MusicIntroStartPlayerCutInCallbackFor3DMode()
		{
			MusicIntroStartPlayerCutInCallback();
		}

		// // RVA: 0x9BECA0 Offset: 0x9BECA0 VA: 0x9BECA0
		// private void MusicIntroStartPlayerCutInCallbackFor2DMode() { }

		// [IteratorStateMachineAttribute] // RVA: 0x744C3C Offset: 0x744C3C VA: 0x744C3C
		// // RVA: 0x9BECC8 Offset: 0x9BECC8 VA: 0x9BECC8
		// private IEnumerator Co_2DModeMusicIntroStartPlayerCutIn(int startRawMusicMillisec) { }

		// // RVA: 0x9BED6C Offset: 0x9BED6C VA: 0x9BED6C
		private void ValkyrieModeBeginShootingCallback()
		{
			uiController.Hud.ShowHitResult();
		}

		// // RVA: 0x9BEE64 Offset: 0x9BEE64 VA: 0x9BEE64
		private void ValkyrieModeEndAnimationCallback()
		{
			valkyrieModeObject.End();
		}

		// // RVA: 0x9BEE90 Offset: 0x9BEE90 VA: 0x9BEE90
		private void ValkyrieModeStartPlayerCutInCallback()
		{
			if (eventFireFlags[0])
				return;
			eventFireFlags[0] = true;
			if (!setting.m_enable_cutin)
				return;
			SoundManager.Instance.sePlayerGame.Play((int)cs_se_game.SE_GAME_008);
			if(voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Start) == RhythmGameVoicePlayer.Result.None)
			{
				if(resource.enteredValkyrieModeVoiceId < 0)
				{
					SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Valkyrie, 0);
				}
				else
				{
					SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Special, resource.enteredValkyrieModeVoiceId);
				}
			}
			uiController.Hud.ShowPilotCutin();
		}

		// // RVA: 0x9BF138 Offset: 0x9BF138 VA: 0x9BF138
		private void ValkyrieModeStartEnemyCutInCallback()
		{
			if (eventFireFlags[1])
				return;
			eventFireFlags[1] = true;
			if (!setting.m_enable_cutin)
				return;
			SoundManager.Instance.sePlayerGame.Play((int)cs_se_game.SE_GAME_008);
			uiController.Hud.ShowEnemyCutin();
		}

		// // RVA: 0x9BF2F4 Offset: 0x9BF2F4 VA: 0x9BF2F4
		private void ValkyrieModeStartEnemyLockOnCallback()
		{
			if (eventFireFlags[2])
				return;
			eventFireFlags[2] = true;
			SoundManager.Instance.sePlayerGame.Play((int)cs_se_game.SE_GAME_013);
			uiController.Hud.ShowEnemyStatus();
			uiController.Hud.ShowTargetSight();
		}

		// // RVA: 0x9BF538 Offset: 0x9BF538 VA: 0x9BF538
		private void OnFullfillLiveSkill(LiveSkill skill)
		{
			if(skill.SkillIndex == 0)
			{
				liveSkillActivateCountList[skill.ownerSlotPlaceIndex + skill.ownerDivaPlaceIndex * 3]++;
			}
			AddSkillLog(skill, false);
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KKBJCJNAGDB_CutInEnabled())
			{
				uiController.EnterLIVESkill(skill, resource.uiTextureResources.skillEffectMaterials[(int)skill.buffEffectType], resource.uiTextureResources.divaSkillCutinMaterials[skill.ownerDivaPlaceIndex]);
			}
			if (skill.durationType == SkillDuration.Type.Instant)
				ActivateInstantBuff(skill);
		}

		// // RVA: 0x9BFCCC Offset: 0x9BFCCC VA: 0x9BFCCC
		private void OnFullfillActiveSkill(ActiveSkill skill)
		{
			AddSkillLog(skill, true);
			SoundManager.Instance.sePlayerGame.Play((int)cs_se_game.SE_VALKYRIE_001);
			if(gameFlow.IsRareBreak)
			{
				SoundManager.Instance.voDivaCos.Play(DivaCosVoicePlayer.Category.ActiveSkill, 0);
			}
			else
			{
				if(voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.ActiveSkill) == 0)
				{
					SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.GameActiveSkill, 0);
				}
			}
			uiController.Hud.DecideActiveSkillButton(skill.durationType);
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KKBJCJNAGDB_CutInEnabled())
			{
				int a = 0;
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
				{
					a = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[Database.Instance.gameSetup.teamInfo.danceDivaList[0].sceneIdList[0] - 1].JPIPENJGGDD_Mlt;
				}
				uiController.Hud.ShowActiveSkillCutin(GameMessageManager.GetSceneCardName(Database.Instance.gameSetup.teamInfo.danceDivaList[0].sceneIdList[0], a, ""), resource.uiTextureResources);
			}
			if(Database.Instance.gameSetup.musicInfo.isTutorialTwo)
			{
				BasicTutorialManager.Instance.HideCursor();
			}
			if(skill.durationType == SkillDuration.Type.Instant)
			{
				ActivateInstantBuff(skill);
				OnActiveSkill_End();
			}
		}

		// // RVA: 0x9C0468 Offset: 0x9C0468 VA: 0x9C0468
		private void OnFullfillEnemySkill(EnemySkill skill)
		{
			if(skill.masterSkill.CPNAGMFCIJK_TriggerType == (int)SkillTrigger.Type.FirstCheck)
			{
				if(skill.buffEffectType == SkillBuffEffect.Type.EnemyLifeUp)
				{
					if (!status.enemy.SetupEnemyLife(skill))
						return;
					uiController.Hud.ChangeEnemyLife(UI.EnemyStatus.LifeType.Double);
				}
			}
			else if(skill.durationType == SkillDuration.Type.Instant)
			{
				ActivateInstantBuff(skill);
			}
		}

		// // RVA: 0x9C03D8 Offset: 0x9C03D8 VA: 0x9C03D8
		private void OnActiveSkill_End()
		{
			if (!skillOwner.activeSkill.IsRestart())
				return;
			activeSkillRestartTimer.m_step = ActiveSkillRestartTimer.Step.WaitEnd;
			activeSkillRestartTimer.m_msec_st = notesMillisec;
		}

		// // RVA: 0x9BE160 Offset: 0x9BE160 VA: 0x9BE160
		private void OnActiveSkill_Update(int a_notes_msec)
		{
			if(activeSkillRestartTimer.m_step == ActiveSkillRestartTimer.Step.WaitEnd)
			{
				if(uiController.Hud.IsActiveSkillButtonAcEnd())
				{
					activeSkillRestartTimer.m_step = ActiveSkillRestartTimer.Step.WaitTime;
					activeSkillRestartTimer.m_msec_st = a_notes_msec;
					activeSkillRestartTimer.m_msec_max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("activeskill_cool_time", 0);
					return;
				}
			}
			else
			{
				if(activeSkillRestartTimer.m_step == ActiveSkillRestartTimer.Step.WaitTime)
				{
					if(Mathf.Abs(a_notes_msec - activeSkillRestartTimer.m_msec_st) > activeSkillRestartTimer.m_msec_max)
					{
						uiController.Hud.RestartActiveSkillButton();
						activeSkillRestartTimer.m_step = ActiveSkillRestartTimer.Step.WaitRestart;
						return;
					}
				}
				else if(activeSkillRestartTimer.m_step == ActiveSkillRestartTimer.Step.WaitRestart)
				{
					if(uiController.Hud.IsActiveSkillButtonAcOn())
					{
						skillOwner.activeSkill.Restart();
						skillTouched = false;
						activeSkillRestartTimer.m_step = ActiveSkillRestartTimer.Step.None;
					}
				}
			}
		}

		// // RVA: 0x9C0648 Offset: 0x9C0648 VA: 0x9C0648
		private void OnActiveBuffEffect(BuffEffect buff)
		{
			for(int i = 0; i < RhythmGameConsts.LineNum; i++)
			{
				if((buff.lineTarget & (1 << i)) > 0)
				{
					uiController.AddBuffEffect(buff, i);
				}
			}
			if (buff.effectType != SkillBuffEffect.Type.AllItemNotes)
				return;
			status.internalMode.isAllItemMode = true;
			rNoteOwner.OnChangeGameMode();
		}

		// // RVA: 0x9C07AC Offset: 0x9C07AC VA: 0x9C07AC
		private void OnRemoveBuffEffect(BuffEffect buff, int ownerDivaPlaceIndex)
		{
			for(int i = 0; i < RhythmGameConsts.LineNum; i++)
			{
				if((buff.lineTarget & (1 << i)) > 0)
				{
					if(!buffOwner.effectiveBuffList.IsConatinEffectType(buff.effectType, i))
					{
						uiController.DeleteBuffEffect(buff, i);
					}
					if(buff.isTopPriorityDisplay)
					{
						uiController.DeleteBuffEffectTopPriorityFlagOnly(buff, i);
					}
				}
			}
			if(buff.skillType == SkillType.Type.ActiveSkill)
			{
				uiController.EndActiveSkill();
				OnActiveSkill_End();
			}
			if(buff.effectType == SkillBuffEffect.Type.AllItemNotes)
			{
				status.internalMode.isAllItemMode = false;
				rNoteOwner.OnChangeGameMode();
			}
		}

		// // RVA: 0x9C0A20 Offset: 0x9C0A20 VA: 0x9C0A20
		// private bool MiddleScoreJudge(int idx, int score) { }

		// // RVA: 0x9C0C30 Offset: 0x9C0C30 VA: 0x9C0C30
		// private void ShowBattleResult01() { }

		// // RVA: 0x9C0E8C Offset: 0x9C0E8C VA: 0x9C0E8C
		// private void ShowBattleResult02() { }

		// // RVA: 0x9C0E58 Offset: 0x9C0E58 VA: 0x9C0E58
		// private int GetBattleResultVoiceCueId(BattleEventResultVoice.ResultVoiceIndex index) { }

		// // RVA: 0x9BFB50 Offset: 0x9BFB50 VA: 0x9BFB50
		private void ActivateInstantBuff(SkillBase skill)
		{
			if(skill.buffEffectType == SkillBuffEffect.Type.HealLifePercentage)
			{
				status.life.HealPercentage(skill.buffEffectValue);
			}
			else if(skill.buffEffectType == SkillBuffEffect.Type.HealLifeValue)
			{
				status.life.HealValue(skill.buffEffectValue);
			}
			else if (skill.buffEffectType == SkillBuffEffect.Type.EffectValueUp)
			{
				skillOwner.LiveSkillEffectValueUp(skill);
			}
		}

		// // RVA: 0x9BF8B4 Offset: 0x9BF8B4 VA: 0x9BF8B4
		private void AddSkillLog(SkillBase skill, bool isActiveSkill)
		{
			RhythmGamePlayLog.SkillData data = new RhythmGamePlayLog.SkillData();
			data.skillId = skill.skillId;
			data.skillLevel = skill.skillLevel;
			data.skillType = skill.buffEffectType;
			data.sceneId = -1;
			if(skill.ownerDivaIndex > -1)
			{
				if(skill.ownerSlotIndex > -1)
				{
					data.sceneId = Database.Instance.gameSetup.teamInfo.divaList[skill.ownerDivaIndex].sceneIdList[skill.ownerSlotIndex];
				}
			}
			data.isActive = isActiveSkill;
			data.millisec = currentRawMusicMillisec - noteOffsetMillisec;
			logger.AddSkillData(data);
		}

		// // RVA: 0x9C10B4 Offset: 0x9C10B4 VA: 0x9C10B4
		private void LoadedRhythmGame()
		{
			scene.isReady = true;
		}

		// // RVA: 0x9C10DC Offset: 0x9C10DC VA: 0x9C10DC
		private void StartRhythmGame()
		{
			UMODebugger.Instance.StartSong();
			if (XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				musicIntroObject.Begin();
				ValkyrieColorParam col = resource.musicIntroResource.paramColor;
				valkyrieObject.SetIBLColor(col);
			}
			else
			{
				lowModeBackgroundObject.ChangeIntroBg();
			}
			
			// // RVA: 0x9CCB30 Offset: 0x9CCB30 VA: 0x9CCB30
			// private void <StartRhythmGame>b__274_0() { }
			uiController.BeginIntroAnim(() => {
				this.StartCoroutineWatched(Co_StartMusic());
				uiController.DeleteIntro();
			});
		}

		// // RVA: 0x9C12D4 Offset: 0x9C12D4 VA: 0x9C12D4
		// private void OnEndMusicTitleIntroAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x744CB4 Offset: 0x744CB4 VA: 0x744CB4
		// // RVA: 0x9C12F8 Offset: 0x9C12F8 VA: 0x9C12F8
		private IEnumerator Co_StartMusic()
		{
			// 0xBF32EC

			//__this00 = c__DisplayClass276_0
			bool isShowingDescription = false;
			if (Database.Instance.gameSetup.musicInfo.isTutorialOne)
			{
				//__this_03 = c__DisplayClass276_1
				TodoLogger.LogError(0, "TODO tuto");
			}
			else if(Database.Instance.gameSetup.musicInfo.isTutorialTwo)
			{
				TodoLogger.LogError(0, "TODO tuto");
			}
			else
			{
				bool IsLine6Mode = Database.Instance.gameSetup.musicInfo.IsLine6Mode;
				bool IsMvMode = Database.Instance.gameSetup.musicInfo.IsMvMode;
				if(IsLine6Mode && !IsMvMode)
				{
					isShowingDescription = true;
					uiController.Show6LineDescriptionTutorialWindow(() =>
					{
						//0xBF178C
						isShowingDescription = false;
					});
				}
			}
			yield return new WaitWhile(() =>
			{
				//0xBF1798
				return isShowingDescription;
			}); // wait end tuto
			
			if(XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
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
		private void Failed()
		{
			if (isVisiblePauseWindow)
				return;
			PauseGame(true);
			uiController.BeginFailedAnim(this.FailedAnimCompletedCallback);
		}

		// // RVA: 0x9C14C8 Offset: 0x9C14C8 VA: 0x9C14C8
		// private void ShowEndTutorialWindow() { }

		// // RVA: 0x9C16F0 Offset: 0x9C16F0 VA: 0x9C16F0
		private void ForceChangePercentage100ForTutorial()
		{
			TodoLogger.LogError(0, "ForceChangePercentage100ForTutorial");
		}

		// // RVA: 0x9C1854 Offset: 0x9C1854 VA: 0x9C1854
		private void ForceDefeatEnemyForTutorial()
		{
			TodoLogger.LogError(0, "ForceDefeatEnemyForTutorial");
		}

		// // RVA: 0x9C1B60 Offset: 0x9C1B60 VA: 0x9C1B60
		// private void ShowModeDescriptionTutorialWindow() { }

		// // RVA: 0x9C1C84 Offset: 0x9C1C84 VA: 0x9C1C84
		private void ShowTutorialActiveSkillGuide()
		{
			if(Database.Instance.gameSetup.musicInfo.isTutorialTwo)
			{
				TodoLogger.LogError(0, "ShowTutorialActiveSkillGuide");
			}
		}

		// // RVA: 0x9C1D84 Offset: 0x9C1D84 VA: 0x9C1D84
		private void ConfirmationWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if (label < PopupButton.ButtonLabel.Cancel)
			{
				if (label == PopupButton.ButtonLabel.UsedChargesItem || label == PopupButton.ButtonLabel.Continue)
				{
					if (Database.Instance.gameSetup.musicInfo.isStoryMode)
					{
						OnSuccessInGameContinueByPaidVC();
					}
					else
					{
						CIOECGOMILE.HHCJCDFCLOB.OKGLDKFLGGK(OnSuccessInGameContinueByPaidVC, null, OnErrorInGameContinueByPaidVC, Database.Instance.gameSetup.musicInfo.freeMusicId, (int)Database.Instance.gameSetup.musicInfo.difficultyType);
					}
				}
			}
			else if (label == PopupButton.ButtonLabel.Cancel)
			{
				ShowConfirmationWindow();
			}
			else if (label == PopupButton.ButtonLabel.Skip)
			{
				uiController.ShowSkipConfirmationWindow(SkipStoryWindowCallBack);
			}
			else if (label == PopupButton.ButtonLabel.Purchase)
			{
				if (scene.DenomControl != null)
				{
					scene.DenomControl.StartPurchaseSequence(OnSuccessInPaidVCPurchase, OnCancelInPaidVCPurchase, OnErrorInPaidVCPurchase, null, null);
				}
			}
			else
			{
				uiController.ShowReconfirmationWindow(ReconfirmationWindowCallBack);
			}
		}

		// // RVA: 0x9C24B0 Offset: 0x9C24B0 VA: 0x9C24B0
		private void ContinueWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(label == PopupButton.ButtonLabel.Continue)
			{
				uiController.ShowConfirmationWindow(ConfirmationWindowCallBack, GotoTitleSceneInError);
			}
			else
			{
				uiController.ShowReconfirmationWindow(ReconfirmationWindowCallBack);
			}
		}

		// // RVA: 0x9C25FC Offset: 0x9C25FC VA: 0x9C25FC
		private void ReconfirmationWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(label == PopupButton.ButtonLabel.Retire)
			{
				FailedRhythmGame();
			}
			else
			{
				ShowConfirmationWindow();
			}
		}

		// // RVA: 0x9C27B4 Offset: 0x9C27B4 VA: 0x9C27B4
		private void PauseWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(type != PopupButton.ButtonType.Negative)
			{
				GameManager.Instance.SetTouchEffectVisible(false);
				GameManager.Instance.SetTouchEffectMode(false);
				uiController.BeginRetryAnim(PauseRetryAnimCompletedCallBack);
			}
			else
			{
				if(!Database.Instance.gameSetup.musicInfo.isTutorialOne && 
					!Database.Instance.gameSetup.musicInfo.isTutorialTwo)
				{
					if (!Database.Instance.gameSetup.musicInfo.isStoryMode)
					{
						uiController.ShowRetireConfirmationWindow(PauseRetireConfirmationWindowCallBack);
						return;
					}
					uiController.ShowSkipConfirmationWindow(SkipStoryPauseWindowCallBack);
					return;
				}
				uiController.ShowSkipConfirmationWindow(SkipTutorialWindowCallBack);
			}
		}

		// // RVA: 0x9C2A9C Offset: 0x9C2A9C VA: 0x9C2A9C
		private void PauseRetireConfirmationWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(type == PopupButton.ButtonType.Negative)
			{
				uiController.ShowPauseWindow(PauseWindowCallBack);
			}
			else
			{
				FailedRhythmGame();
			}
		}

		// // RVA: 0x9C2B68 Offset: 0x9C2B68 VA: 0x9C2B68
		private void SkipTutorialWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			TodoLogger.LogError(0, "SkipTutorialWindowCallBack");
		}

		// // RVA: 0x9C2D30 Offset: 0x9C2D30 VA: 0x9C2D30
		// private void EndTutorialWindowCallBack() { }

		// // RVA: 0x9C2DEC Offset: 0x9C2DEC VA: 0x9C2DEC
		private void SkipStoryWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			TodoLogger.LogError(0, "SkipStoryWindowCallBack");
		}

		// // RVA: 0x9C2E00 Offset: 0x9C2E00 VA: 0x9C2E00
		private void SkipStoryPauseWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			TodoLogger.LogError(0, "SkipStoryPauseWindowCallBack");
		}

		// // RVA: 0x9C2ECC Offset: 0x9C2ECC VA: 0x9C2ECC
		private void MvModePauseWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(type == PopupButton.ButtonType.Negative)
			{
				uiController.ShowMvModeEndConfirmWindow(this.MvModeEndConfirmWindowCallBack);
				return;
			}
			GameManager.Instance.SetTouchEffectVisible(false);
			GameManager.Instance.SetTouchEffectMode(false);
			if(!setting_mv.m_show_notes)
			{
				MvModePauseRetry();
			}
			else
			{
				uiController.BeginRetryAnim(this.MvModePauseRetry);
			}
		}

		// // RVA: 0x9C3414 Offset: 0x9C3414 VA: 0x9C3414
		private void MvModeEndConfirmWindowCallBack(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label)
		{
			if(type == PopupButton.ButtonType.Negative)
			{
				uiController.ShowMvModePauseWindow(this.MvModePauseWindowCallBack);
			}
			else
			{
				FailedRhythmGame();
			}
		}

		// // RVA: 0x9C34E0 Offset: 0x9C34E0 VA: 0x9C34E0
		private void OnSuccessInPaidVCPurchase()
		{
			TodoLogger.LogError(0, "OnSuccessInPaidVCPurchase");
		}

		// // RVA: 0x9C34E4 Offset: 0x9C34E4 VA: 0x9C34E4
		private void OnCancelInPaidVCPurchase()
		{
			TodoLogger.LogError(0, "OnCancelInPaidVCPurchase");
		}

		// // RVA: 0x9C34E8 Offset: 0x9C34E8 VA: 0x9C34E8
		private void OnErrorInPaidVCPurchase()
		{
			TodoLogger.LogError(0, "OnErrorInPaidVCPurchase");
		}

		// // RVA: 0x9C2290 Offset: 0x9C2290 VA: 0x9C2290
		private void OnSuccessInGameContinueByPaidVC()
		{
			TodoLogger.LogError(0, "OnSuccessInGameContinueByPaidVC");
		}

		// // RVA: 0x9C3624 Offset: 0x9C3624 VA: 0x9C3624
		private void OnErrorInGameContinueByPaidVC()
		{
			TodoLogger.LogError(0, "OnErrorInGameContinueByPaidVC");
		}

		// // RVA: 0x9C1380 Offset: 0x9C1380 VA: 0x9C1380
		private void PauseGame(bool isReserve = false)
		{
			isVisiblePauseWindow = true;
			uiController.Hud.DisablePauseButton();
			if (isReserve)
				isPauseRequest = true;
			else
			{
				isPauseRequest = false;
				rNoteOwner.Pause();
				Pause();
			}
		}

		// // RVA: 0x9C3628 Offset: 0x9C3628 VA: 0x9C3628
		private void ResumeGame()
		{
			isVisiblePauseWindow = false;
			uiController.Hud.EnablePauseButton();
			rNoteOwner.Resume();
			Play();
		}

		// // RVA: 0x9C3A48 Offset: 0x9C3A48 VA: 0x9C3A48
		private void PauseButtonCallback(bool a_suspend)
		{
			PauseGame(true);
			GameManager.Instance.SetTouchEffectVisible(true);
			GameManager.Instance.SetTouchEffectMode(true);
			uiController.failed.ShowBlackCurtainOnly();
			uiController.ShowPauseWindow(PauseWindowCallBack);
		}

		// // RVA: 0x9C3BCC Offset: 0x9C3BCC VA: 0x9C3BCC
		private void MvPauseButtonCallback(bool a_suspend)
		{
			if(!setting_mv.m_show_notes)
			{
				if(!a_suspend)
				{
					if(!bgmPlayer.source.IsPaused())
					{
						gameDivaObject.WaitLockBoneSpring(0, 0.05f);
						for(int i = 0; i < subDivaObject.Length; i++)
						{
							if(subDivaObject[i] != null)
							{
								subDivaObject[i].WaitLockBoneSpring(0, 0.05f);
							}
						}
						foreach(var d in divaExtensionObjectList)
						{
							d.LockBoneSpring(0, 0.05f);
						}
						rNoteOwner.Pause();
						Pause();
						return;
					}
				}
				PauseGame(true);
				GameManager.Instance.SetTouchEffectVisible(true);
				GameManager.Instance.SetTouchEffectMode(true);
				uiController.failed.ShowBlackCurtainOnly();
				uiController.ShowMvModePauseWindow(this.MvModePauseWindowCallBack);
			}
			else
			{
				PauseGame(true);
				GameManager.Instance.SetTouchEffectVisible(true);
				GameManager.Instance.SetTouchEffectMode(true);
				uiController.failed.ShowBlackCurtainOnly();
				uiController.ShowMvModePauseWindow(this.MvModePauseWindowCallBack);
			}
		}

		// // RVA: 0x9C4154 Offset: 0x9C4154 VA: 0x9C4154
		private void PauseRetryAnimCompletedCallBack()
		{
			ResumeGame();
			uiController.Hud.ClearPauseButton();
		}

		// // RVA: 0x9C309C Offset: 0x9C309C VA: 0x9C309C
		private void MvModePauseRetry()
		{
			ResumeGame();
			uiController.Hud.ClearPauseButton();
			uiController.failed.HideAll();
			gameDivaObject.UnlockBoneSpring(true, 0);
			for(int i = 0; i < subDivaObject.Length; i++)
			{
				if(subDivaObject[i] != null)
				{
					subDivaObject[i].UnlockBoneSpring(true, 0);
				}
			}
			foreach(var d in divaExtensionObjectList)
			{
				d.UnlockBoneSpring();
			}
		}

		// // RVA: 0x9C4254 Offset: 0x9C4254 VA: 0x9C4254
		private void FailedAnimCompletedCallback()
		{
			uiController.failed.ShowBlackCurtainOnly();
			ShowConfirmationWindow();
		}

		// // RVA: 0x9C42AC Offset: 0x9C42AC VA: 0x9C42AC
		// private void RetryAnimCompletedCallback() { }

		// // RVA: 0x9C23C8 Offset: 0x9C23C8 VA: 0x9C23C8
		private void ShowConfirmationWindow()
		{
			GameManager.Instance.SetTouchEffectVisible(true);
			GameManager.Instance.SetTouchEffectMode(true);
			this.StartCoroutineWatched(Co_ShowConfirmationWindow());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x744D2C Offset: 0x744D2C VA: 0x744D2C
		// // RVA: 0x9C4654 Offset: 0x9C4654 VA: 0x9C4654
		private IEnumerator Co_ShowConfirmationWindow()
		{
			//0xBF2BF0
			yield return TutorialManager.TryShowTutorialCoroutine(TutorialChecker);
			if(Database.Instance.gameSetup.musicInfo.isFreeMode)
			{
				uiController.ShowContinueWindow(ContinueWindowCallBack);
			}
			else
			{
				uiController.ShowConfirmationWindow(ConfirmationWindowCallBack, GotoTitleSceneInError);
			}
		}

		// // RVA: 0x9C46DC Offset: 0x9C46DC VA: 0x9C46DC
		private void OnChangeScene()
		{
			if(!Database.Instance.gameSetup.musicInfo.isTutorialTwo)
				return;
			BasicTutorialManager.Instance.HideCursor();
		}

		// // RVA: 0x9C47C8 Offset: 0x9C47C8 VA: 0x9C47C8
		private void GameStartErrorToTitleAction()
		{
			XeApp.Game.GameManager.FadeOut();
			this.StartCoroutineWatched(Co_FadeOutAndExit());
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
			TodoLogger.LogError(0, "TutorialClearEndRhythmGame");
		}

		// // RVA: 0x9C4A70 Offset: 0x9C4A70 VA: 0x9C4A70
		private void ClearEndRhythmGame()
		{
			if(!scene.IsEnableTransionResult())
				return;
			this.StartCoroutineWatched(Co_WaitRhytmGameEnd(true));
		}

		// // RVA: 0x9C260C Offset: 0x9C260C VA: 0x9C260C
		private void FailedRhythmGame()
		{
			if(scene.IsEnableTransionResult())
			{
				this.StartCoroutineWatched(Co_WaitRhytmGameEnd(false));
				return;
			}
			uiController.failed.HideAll();
			isVisiblePauseWindow = false;
			rNoteOwner.Resume();
			uiController.Hud.EnablePauseButton();
		}

		// // RVA: 0x9C4AC4 Offset: 0x9C4AC4 VA: 0x9C4AC4
		// private void EndRhythmGame(bool isClear) { }

		// [IteratorStateMachineAttribute] // RVA: 0x744E1C Offset: 0x744E1C VA: 0x744E1C
		// // RVA: 0x9C4AE8 Offset: 0x9C4AE8 VA: 0x9C4AE8
		public IEnumerator Co_WaitRhytmGameEnd(bool isClear)
		{
			int[] noteResultCount;
			int noteResultCount_Excellent;
			//0xBF3B04

			ExternLib.LibCriWare.checkUncached = false;

			GameManager.FadeOut(0.4f);
			if(soundCheerOrderer != null)
			{
				SoundManager.Instance.sePlayerCheer.FadeOut(1.0f);
			}
			noteResultCount = new int[5];
			rNoteOwner.SetupNoteResultData(ref noteResultCount, logger);
			noteResultCount_Excellent = rNoteOwner.GetExcellentResultNoteCount();
			JGEOBNENMAH.HAJIFNABIFF data;
			MakeClearSetupData(out data, noteResultCount, noteResultCount_Excellent, touchedEventItem ? 1 : 0);
			int t_next = 0;
			if (!isClear)
			{
				JGEOBNENMAH.HHCJCDFCLOB.EFHMAKNEGEA(data);
				t_next = 3;
			}
			else
			{
				JGEOBNENMAH.HHCJCDFCLOB.EFHPJGACNLK(data, () =>
				{
					//0xBF1ADC
					t_next = 2;
				}, () =>
				{
					//0xBF1AE8
					t_next = 1;
				});
			}
			GameManager.Instance.SetTouchEffectVisible(false);
			GameManager.Instance.SetTouchEffectMode(false);

			while (t_next == 0)
				yield return null;

			if(soundCheerOrderer != null)
			{
				while (SoundManager.Instance.sePlayerCheer.IsPlaying())
					yield return null;
				while(SoundManager.Instance.sePlayerCheer.IsFading())
					yield return null;
			}
			if(t_next == 3)
			{
				GotoMenuSceneInFailed();
			}
			else if(t_next == 2)
			{
				GotoMenuSceneInSuccess(noteResultCount, noteResultCount_Excellent);
			}
			else if(t_next == 1)
			{
				GotoTitleSceneInError();
			}

			//TodoLogger.MinLog = -9999;

			yield break;
		}

		// // RVA: 0x9C4B8C Offset: 0x9C4B8C VA: 0x9C4B8C
		private void MakeClearSetupData(out JGEOBNENMAH.HAJIFNABIFF clearSetup, int[] noteResultCount, int noteResultCount_Excellent, int noteResultCount_EventItem)
		{
			RhythmGameConsts.ResultComboType comboRank = CalcComboRank();
			clearSetup = new JGEOBNENMAH.HAJIFNABIFF();
			clearSetup.KLCIIHKFPPO_StoryMusicId = Database.Instance.gameSetup.musicInfo.storyMusicId;
			clearSetup.GHBPLHBNMBK_FreeMusicId = Database.Instance.gameSetup.musicInfo.freeMusicId;
			clearSetup.AKNELONELJK_Difficulty = (int)Database.Instance.gameSetup.musicInfo.difficultyType;
			clearSetup.LFGNLKKFOCD_IsLine6 = Database.Instance.gameSetup.musicInfo.IsLine6Mode;
			clearSetup.MNNHHJBBICA_GameEventType = (int)Database.Instance.gameSetup.musicInfo.gameEventType;
			clearSetup.MFJKNCACBDG_OpenEventType = (int)Database.Instance.gameSetup.musicInfo.openEventType;
			clearSetup.OEILJHENAHN_PlayEventType = (int)Database.Instance.gameSetup.musicInfo.playEventType;
			clearSetup.KNIFCANOHOC_Score = status.score.currentScore;
			clearSetup.EACPIDGGPPO_ExcellentScore = status.score.currentScore - status.score.nonExcellentScore;
			clearSetup.NLKEBAOBJCM_MaxCombo = status.combo.record;
			clearSetup.LCOHGOIDMDF_ComboRank = (int)comboRank;
			clearSetup.MJBODMOLOBC_TeamLuck = Database.Instance.gameSetup.teamInfo.teamLuck;
			clearSetup.DGMPBPMDBEC_DropItemList = new List<int>(dropItemList);
			clearSetup.JNNDFGPMEDA_EnergyLeft = status.energy.GetGaugeValue();
			clearSetup.JKPPKAHPPKH_LifeLeft = status.life.current;
			clearSetup.IPEKDLNEOFI_TeamLife = Database.Instance.gameSetup.teamInfo.teamStatus.life;
			clearSetup.HBKBKHACHHI_TeamSoul = Database.Instance.gameSetup.teamInfo.teamStatus.soul;
			clearSetup.GMECIBOJCFF_TeamVocal = Database.Instance.gameSetup.teamInfo.teamStatus.vocal;
			clearSetup.MIMLMJGGNJH_TeamCharm = Database.Instance.gameSetup.teamInfo.teamStatus.charm;
			clearSetup.BFHPKJEKJNN_TeamSupport = Database.Instance.gameSetup.teamInfo.teamStatus.support;
			clearSetup.DDBEJNGJIPF_Fold = Database.Instance.gameSetup.teamInfo.teamStatus.fold;
			clearSetup.JBCKLEMCEBD_LiveSkillActivateCount = new List<int>(liveSkillActivateCountList);
			clearSetup.CPNOKMINILL_SkillDataList = new List<RhythmGamePlayLog.SkillData>(logger.log.skillDataList);
			clearSetup.JEKDIEFPEON_RareItemRandomSeed = rNoteOwner.GetRareItemRandomSeed();
			clearSetup.OOOGNIPJMDE_HadDivaMode = logger.log.divaModeData.type == RhythmGameMode.Type.Diva;
			clearSetup.HGEKDNNJAAC_HadAwakenDivaMode = logger.log.divaModeData.type == RhythmGameMode.Type.AwakenDiva;
			clearSetup.KNCBNGCDMII_HadValkyrieMode = logger.log.valkyrieModeData.type == RhythmGameMode.Type.Valkyrie;
			clearSetup.EHCFOHAABDA_EnemyLeft = status.enemy.currentValue;
			clearSetup.HNHCIGMKPDC_DivaIds = new List<int>();
			clearSetup.OJDDNGGBJOG_AverageFPS = (int)DebugFPS.Instance.avgFPS;
			clearSetup.BIIGPMLBOOD_MinFPS = (int)DebugFPS.Instance.minFPS;
			clearSetup.FJCIPNCOBNA_SerializedNoteResultInfo = rNoteOwner.SerializeForNotesLog();
			clearSetup.FDNEPIEMMFN_AssignedCenterLiveSkillNote = rNoteOwner.assignedCenterLiveSkillNote ? 1 : 0;
			clearSetup.HJIECNDECNO_TouchedCenterLiveSkill = touchedCenterLiveSkill ? 1 : 0;
			clearSetup.OBOPMHBPCFE_MvMode = Database.Instance.gameSetup.musicInfo.IsMvMode;
			for(int i = 0; i < 3; i++)
			{
				clearSetup.HNHCIGMKPDC_DivaIds.Add(Database.Instance.gameSetup.teamInfo.danceDivaList[i].divaId);
			}
			for(int i = 0; i < logger.log.skillDataList.Count; i++)
			{
				if(logger.log.skillDataList[i].isActive)
				{
					clearSetup.BCGBODDEFKP_NumSkillActive++;
					clearSetup.IHDIJODHCGD_LastSkillMillisec = logger.log.skillDataList[i].millisec;
				}
			}
			clearSetup.GLGLFDAPNIF_ContinueCount = continueCount;
			clearSetup.OJFNDOIFOOE_NoteResultCount = new List<int>(noteResultCount);
			clearSetup.FEGLNPOFDJC_ExcellentCount = noteResultCount_Excellent;
			clearSetup.OOPEJLMNIAH_EventItemCount = noteResultCount_EventItem;
			clearSetup.JPJMALBLKDI_Tutorial = (int)Database.Instance.gameSetup.musicInfo.tutorial;
			clearSetup.NFFDIGEJHGL_ServerTime = JGEOBNENMAH.HHCJCDFCLOB.GJIICCJMDIF_GetServerTime();
			clearSetup.PMCGHPOGLGM_IsSkip = false;
			clearSetup.KAIPAEILJHO_TicketCount = 0;
			if(status.score.CheckFalisification() != null)
				clearSetup.NMNHBJIAPGG_CheckFalsification = status.score.CheckFalisification();
			if(status.combo.CheckFalisification() != null)
				clearSetup.NMNHBJIAPGG_CheckFalsification = status.combo.CheckFalisification();
		}

		// // RVA: 0x9C5C78 Offset: 0x9C5C78 VA: 0x9C5C78
		private void GotoMenuSceneInSuccess(int[] noteResultCount, int noteResultCount_Excellent)
		{
			Database.Instance.gameResult.Setup(true, false, noteResultCount, logger.log, noteResultCount_Excellent);
			scene.GotoMenuScene();
		}

		// // RVA: 0x9C5D68 Offset: 0x9C5D68 VA: 0x9C5D68
		private void GotoMenuSceneInFailed()
		{
			bool b = status.life.current == 0 && Database.Instance.gameSetup.musicInfo.freeMusicId != 0;
			if (b)
			{
				TipsControl.SetSituationValue(TipsControl.SituationId.GameOver, 1);
			}
			Database.Instance.gameResult.Setup(false, b, null, null, 0);
			if(scene.IsDebugFlow())
			{
				scene.GotoPrevScene();
			}
			else
			{
				scene.GotoMenuScene();
			}
		}

		// // RVA: 0x9C34EC Offset: 0x9C34EC VA: 0x9C34EC
		private void GotoTitleSceneInError()
		{
			TodoLogger.LogError(0, "GotoTitleSceneInError");
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
		public RhythmGameConsts.ResultComboType CalcComboRank()
		{
			if (rNoteOwner.IsAllPerfectResult())
				return RhythmGameConsts.ResultComboType.PerfectFullCombo;
			return status.combo.record == totalComboNum ? RhythmGameConsts.ResultComboType.FullCombo : RhythmGameConsts.ResultComboType.Complete;
		}

		// // RVA: 0x9C44C4 Offset: 0x9C44C4 VA: 0x9C44C4
		// private void AddInvincibleBuffEffect() { }

		// // RVA: 0x9C16E8 Offset: 0x9C16E8 VA: 0x9C16E8
		// private bool IsEnableRetryTutorialPopup() { }

		// // RVA: 0x9C6020 Offset: 0x9C6020 VA: 0x9C6020
		public bool IsActiveLine(int lineNo)
		{
			return uiController.Hud.IsActiveLine(lineNo);
		}

		// // RVA: 0x9C6120 Offset: 0x9C6120 VA: 0x9C6120
		public void BeganTouchEventCallback(int lineNo, int fingerId)
		{
			if (!uiController.Hud.isReadyHUD)
				return;
			if(!uiController.Hud.IsInputAccept())
				return;
			if (!rNoteOwner.BeganTouch(lineNo, fingerId) && !isVisiblePauseWindow)
				PlayNotesSE(NoteSEType.Exempt);
			if(rNoteOwner.IsLongBeganTouched(lineNo) || rNoteOwner.IsSlideBeganTouched(fingerId))
			{
				gamePerformer.BeginTouchSave(lineNo);
			}
			if (isVisiblePauseWindow)
				return;
			uiController.Hud.ShowTouchEffect(lineNo, fingerId);
		}

		// // RVA: 0x9C651C Offset: 0x9C651C VA: 0x9C651C
		public void EndedTouchEventCallback(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss)
		{
			if (!uiController.Hud.isReadyHUD)
				return;
			rNoteOwner.EndedTouch(lineNo, lineNo_Begin, fingerId, forceMiss, true);
			uiController.Hud.HideToucheEffect(lineNo, fingerId);
		}

		// // RVA: 0x9C6730 Offset: 0x9C6730 VA: 0x9C6730
		public void ReleaseLineEventCallback(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss)
		{
			if (!uiController.Hud.isReadyHUD)
				return;
			rNoteOwner.ReleaseLine(lineNo, lineNo_Begin, fingerId, forceMiss, false);
			uiController.Hud.HideToucheEffect(lineNo, fingerId);
		}

		// // RVA: 0x9C6940 Offset: 0x9C6940 VA: 0x9C6940
		public void NextLineEventCallback(int lineNo0, int lineNo1, int fingerId, bool forceMiss)
		{
			if (!uiController.Hud.isReadyHUD)
				return;
			rNoteOwner.NextLine(lineNo0, lineNo1, fingerId, forceMiss, false);
			uiController.Hud.HideToucheEffect(lineNo0, fingerId);
		}

		// // RVA: 0x9C6B50 Offset: 0x9C6B50 VA: 0x9C6B50
		public void SwipedTouchEventCallback(int lineNo, int fingerId, bool isRight, bool isDown, bool isLeft, bool isUp)
		{
			if (!uiController.Hud.isReadyHUD)
				return;
			rNoteOwner.SwipedTouch(lineNo, fingerId, isRight, isDown, isLeft, isUp);
			if(rNoteOwner.IsSlideBeganTouched(fingerId))
			{
				rNoteOwner.NeutralTouch(lineNo, fingerId);
			}
		}

		// // RVA: 0x9C6D18 Offset: 0x9C6D18 VA: 0x9C6D18
		public void NeutralTouchEventCallback(int lineNo, int fingerId)
		{
			if (!uiController.Hud.isReadyHUD)
				return;
			rNoteOwner.NeutralTouch(lineNo, fingerId);
			if(!rNoteOwner.IsLongLastEvaluation(lineNo))
			{
				if (!rNoteOwner.IsSlideLastEvaluation(fingerId))
					return;
			}
			gamePerformer.EndTouchSave(lineNo, false);
		}

		// // RVA: 0x9C6EE0 Offset: 0x9C6EE0 VA: 0x9C6EE0
		public void CheckInputCallback(RhythmGameInputPerformer.InputSaver a_saver)
		{
			if (!uiController.Hud.isReadyHUD)
				return;
			rNoteOwner.CheckInputCallback(a_saver);
		}

		// // RVA: 0x9C7008 Offset: 0x9C7008 VA: 0x9C7008
		private void RNoteOverwrideJudgedResultDelegate(RNoteObject a_note_obj, ref RhythmGameConsts.NoteResultEx a_result_ex)
		{
			if (setting_mv.m_enable)
				return;
			if (RuntimeSettings.CurrentSettings.ForcePerfectNote)
				a_result_ex.m_result = RhythmGameConsts.NoteResult.Perfect;
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.OverwritePerfect, a_note_obj.rNote.GetLineNo()))
			{
				if (a_result_ex.m_result == RhythmGameConsts.NoteResult.Bad || a_result_ex.m_result == RhythmGameConsts.NoteResult.Good || a_result_ex.m_result == RhythmGameConsts.NoteResult.Great)
				{
					a_result_ex.m_result = RhythmGameConsts.NoteResult.Perfect;
				}
			}
			if(a_result_ex.m_result == RhythmGameConsts.NoteResult.Perfect)
			{
				if(m_NoteResultParam_Excellent.m_note_judge_rate * 100000.0f < UnityEngine.Random.Range(0, 100000))
				{
					return;
				}
				a_result_ex.m_excellent = true;
			}
		}

		// // RVA: 0x9C71D8 Offset: 0x9C71D8 VA: 0x9C71D8
		private void RNoteJudgedResultDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex, RhythmGameConsts.NoteJudgeType a_judge_type)
		{
			if (!uiController.Hud.isReadyHUD)
				return;
			JudgedNoteResult(noteObject, a_result_ex);
			JudgedNoteEffect(noteObject, a_result_ex);
			JudgedNoteSound(noteObject, a_result_ex.m_result);
			UMODebugger.Instance.AddNoteInfo(noteObject.rNote, a_result_ex.m_result);
			gamePerformer.EndTouchSave(noteObject.rNote.GetLineNo(), true);
			status.life.isInvincibleGameEnd = rNoteOwner.CheckAllNotesEnd();
		}

		// // RVA: 0x9CA2CC Offset: 0x9CA2CC VA: 0x9CA2CC
		public void SkillTouchEventCallback(TouchSwipeDirection swipeDir)
		{
			if(!isVisiblePauseWindow && !skillTouched)
			{
				if(uiController.Hud.isReadyHUD)
				{
					if(uiController.Hud.IsInputAccept())
					{
						if (uiController.Hud.IsEnableActiveSkillButton())
							skillTouched = true;
					}
				}
			}
		}

		// // RVA: 0x9C73F8 Offset: 0x9C73F8 VA: 0x9C73F8
		private void JudgedNoteResult(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex)
		{
			bool isValk = status.directionMode.type == RhythmGameMode.Type.Valkyrie && noteObject.rNote.modeType == MusicData.NoteModeType.Valkyrie;
			if (noteObject.rNote.noteInfo.swipe == MusicScoreData.TouchState.SwipeStart)
				return;
			if ((a_result_ex.m_result >= RhythmGameConsts.NoteResult.Great && a_result_ex.m_result < RhythmGameConsts.NoteResult.Num) || buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.AutoCombo, noteObject.rNote.GetLineNo()))
			{
				status.combo.IncreaseCombo();
				if (isValk)
					status.comboValkyrie.IncreaseCombo();
			}
			else
			{
				if (!buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ComboContinue, noteObject.rNote.GetLineNo()))
				{
					status.combo.Zero();
					if (isValk)
					{
						status.comboValkyrie.Zero();
						if (valkyrieModeObject.isRunning)
						{
							valkyrieModeObject.NotifyDamage();
						}
					}
				}
			}
			float f = 1.0f;
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ScoreUpPercentage, noteObject.rNote.GetLineNo()))
			{
				f = buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ScoreUpPercentage, noteObject.rNote.GetLineNo(), a_result_ex.m_result) / 100.0f + 1;
			}
			if (a_result_ex.m_result == RhythmGameConsts.NoteResult.Perfect)
			{
				if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.PerfectScoreUpPercentage, noteObject.rNote.GetLineNo()))
				{
					f = buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.PerfectScoreUpPercentage, noteObject.rNote.GetLineNo(), RhythmGameConsts.NoteResult.None) / 100.0f;
				}
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ComboBonus, noteObject.rNote.GetLineNo()))
			{
				f += buffOwner.CalcComboBonus(status.combo.current, noteObject.rNote.GetLineNo());
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ScoreUpPercentage_FoldWave, noteObject.rNote.GetLineNo()))
			{
				f += buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ScoreUpPercentage_FoldWave, noteObject.rNote.GetLineNo(), a_result_ex.m_result);
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ScoreUpPercentage_Intimacy, noteObject.rNote.GetLineNo()))
			{
				f += buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ScoreUpPercentage_Intimacy, noteObject.rNote.GetLineNo(), a_result_ex.m_result);
			}
			int a = 0;
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ScoreUpValue, noteObject.rNote.GetLineNo()))
			{
				a = buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ScoreUpValue, noteObject.rNote.GetLineNo(), RhythmGameConsts.NoteResult.None);
			}
			status.score.IncreaseScore(a_result_ex, status.combo.current, f, a, noteObject.rNote.CurrentModeInfo(status.internalMode).specialNoteType, m_NoteResultParam_Excellent.m_score_rate, true);
			if (status.directionMode.type == RhythmGameMode.Type.Normal)
			{
				if (noteObject.rNote.modeType == MusicData.NoteModeType.Normal)
				{
					status.energy.ChangeValue(a_result_ex.m_result, 1.0f, noteObject.rNote.CurrentModeInfo(status.internalMode).specialNoteType);
					uiController.UpdateEnergy(status.energy.GetGaugeValue());
				}
			}
			if (isValk)
			{
				int damage = status.enemy.Damage(a_result_ex.m_result, noteObject.rNote.GetIndexInMode(MusicData.NoteModeType.Valkyrie), status.comboValkyrie.current, 1.0f, 1.0f, noteObject.rNote.CurrentModeInfo(status.internalMode).specialNoteType);
				bool is3DMode = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D;
				bool showValkyrie = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.AOOKLMAPPLG_IsValkyrieModeEnabled();
				uiController.UpdateEnemyLife(status.enemy.currentValue, status.enemy.subgoalValue, status.enemy.goalValue, () =>
				{
					//0xBF1AFC
					if (!is3DMode || !showValkyrie)
						return;
					valkyrieObject.StartTransformAnimation();
				});
				Vector3 pos = new Vector3();
				if (is3DMode)
				{
					valkyrieModeObject.GetLockOnTargetPos(out pos);
				}
				uiController.UpdateEnemyDamageResult(damage, pos);
				if (damage > 0)
				{
					valkyrieModeObject.NotifyHit();
				}
			}
			if (a_result_ex.m_result > RhythmGameConsts.NoteResult.Bad)
			{
				if (noteObject.rNote.CurrentModeInfo(status.internalMode).specialNoteType == RhythmGameConsts.SpecialNoteType.Heal)
				{
					status.life.HealNotes();
				}
				if (noteObject.rNote.CurrentModeInfo(status.internalMode).specialNoteType == RhythmGameConsts.SpecialNoteType.CenterLiveSkill)
				{
					touchedCenterLiveSkill = true;
				}
				if (noteObject.rNote.CurrentModeInfo(status.internalMode).specialNoteType == RhythmGameConsts.SpecialNoteType.EventItem)
				{
					touchedEventItem = true;
				}
				int itemIdx = noteObject.rNote.CurrentModeInfo(status.internalMode).itemIndex;
				if (itemIdx > -1)
				{
					dropItemList.Add(itemIdx);
					dropItemRarityCount[~(itemIdx >> 30) & 1]++;
				}
			}
			float f_damage = 1;
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.DamegeUp, noteObject.rNote.GetLineNo()))
			{
				f_damage = buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.DamegeUp, noteObject.rNote.GetLineNo(), RhythmGameConsts.NoteResult.None) / 100.0f + 1;
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ReduceDamage, noteObject.rNote.GetLineNo()))
			{
				f = Mathf.Min(buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ReduceDamage, noteObject.rNote.GetLineNo(), RhythmGameConsts.NoteResult.None) / 100.0f, 1);
				f_damage = f_damage * (1 - f);
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.NoDamage, noteObject.rNote.GetLineNo()))
			{
				f_damage = 0;
			}
			if (Database.Instance.gameSetup.musicInfo.isTutorialOne || Database.Instance.gameSetup.musicInfo.isTutorialTwo)
				f_damage = 0;
			if(a_result_ex.m_result == RhythmGameConsts.NoteResult.Miss)
			{
				if(noteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.Start)
				{
					if (noteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.Continue)
					{
						if (noteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.End)
						{
							if (rNoteOwner.GetNote(noteObject.rNote.noteInfo.prevIndex).noteInfo.longTouch != MusicScoreData.TouchState.Continue)
							{
								status.life.DamageNotes(RhythmGameConsts.NoteResult.Miss, f_damage);
							}
						}
					}
					else
					{
						//LAB_009c88f0
						status.life.DamageNotes(RhythmGameConsts.NoteResult.Miss, f_damage);
					}
				}
				else
				{
					if(noteObject.rNote.noteInfo.isSlide)
					{
						if(noteObject.rNote.noteInfo.nextIndex > -1)
						{
							if (rNoteOwner.GetNote(noteObject.rNote.noteInfo.nextIndex).noteInfo.longTouch != MusicScoreData.TouchState.Continue)
							{
								status.life.DamageNotes(RhythmGameConsts.NoteResult.Miss, f_damage);
							}
						}
					}
				}
			}
			else if(a_result_ex.m_result == RhythmGameConsts.NoteResult.Bad)
			{
				status.life.DamageNotes(RhythmGameConsts.NoteResult.Bad, f_damage);
			}
			if(status.directionMode.type == RhythmGameMode.Type.Normal)
			{
				if(noteObject.rNote.modeType == MusicData.NoteModeType.Valkyrie)
				{
					preJudgeValkyrieNotes.Add(noteObject);
				}
			}
			if(noteObject.rNote.noteInfo.isSlide &&
				a_result_ex.m_result == RhythmGameConsts.NoteResult.Miss && noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.End && 
				rNoteOwner.GetNote(noteObject.rNote.noteInfo.prevIndex).result == 0 && 
				(rNoteOwner.GetNote(noteObject.rNote.noteInfo.prevIndex).noteInfo.longTouch == MusicScoreData.TouchState.None || rNoteOwner.GetNote(noteObject.rNote.noteInfo.prevIndex).noteInfo.longTouch == MusicScoreData.TouchState.Continue))
			{
				//
			}
			else
			{
				EnterNoteResult(a_result_ex, noteObject.rNote.noteInfo.trackID);
			}
			if(noteObject.rNote.noteInfo.isSlide &&
				a_result_ex.m_result == RhythmGameConsts.NoteResult.Miss && noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.End &&
				noteObject.rNote.passingStatus == RNote.PassingStatus.Alive)
			{
				noteObject.rNote.ResetSlideNoteResult();
			}
			m_bit_note_result = m_bit_note_result | 1 << ((int)a_result_ex.m_result & 0x1f);
		}

		// // RVA: 0x9C8D08 Offset: 0x9C8D08 VA: 0x9C8D08
		private void JudgedNoteEffect(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex)
		{
			bool a = true;
			if(noteObject.rNote.noteInfo.swipe != MusicScoreData.TouchState.Start)
			{
				if(noteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.Start)
				{
					a = false;
					if (noteObject.rNote.noteInfo.swipe == MusicScoreData.TouchState.SwipeEnd)
						a = true;
				}
			}
			bool b = true;
			if(noteObject.rNote.noteInfo.swipe != MusicScoreData.TouchState.End)
			{
				b = false;
				if (noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.End)
				{
					b = true;
				}
			}
			if(noteObject.rNote.noteInfo.isWing && a_result_ex.m_result != RhythmGameConsts.NoteResult.Miss)
			{
				if(!RhythmGameConsts.IsLeftLine(noteObject.rNote.noteInfo.wingTrackID))
				{
					if(!RhythmGameConsts.IsWingLine(noteObject.rNote.noteInfo.trackID))
					{
						uiController.Hud.ShowWingNotesOpenREffect(noteObject.rNote.noteInfo.wingTrackID);
					}
					else
					{
						uiController.Hud.ShowWingNotesCloseREffect(noteObject.rNote.noteInfo.wingTrackID);
					}
				}
				else if (!RhythmGameConsts.IsWingLine(noteObject.rNote.noteInfo.trackID))
				{
					uiController.Hud.ShowWingNotesOpenLEffect(noteObject.rNote.noteInfo.wingTrackID);
				}
				else
				{
					uiController.Hud.ShowWingNotesCloseLEffect(noteObject.rNote.noteInfo.wingTrackID);
				}
			}
			if (a || noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Continue)
			{
				if (a_result_ex.m_result != RhythmGameConsts.NoteResult.Miss)
				{
					if (noteObject.rNote.noteInfo.isSlide)
					{
						if (rNoteOwner.GetNote(noteObject.rNote.noteInfo.nextIndex).result == RhythmGameConsts.NoteResult.None)
						{
							uiController.Hud.ShowSlideNotesTouchEffect(rNoteOwner.GetNote(noteObject.rNote.noteInfo.nextIndex).noteInfo.trackID);
							uiController.Hud.ShowSlideNotesTipEffect(rNoteOwner.GetNote(noteObject.rNote.noteInfo.nextIndex).noteInfo.trackID, rNoteOwner.GetRNoteSlide(noteObject));
						}
					}
					else
					{
						uiController.Hud.ShowLongNotesTouchEffect(noteObject.rNote.noteInfo.trackID);
					}
					uiController.Hud.ShowNotesHitEffect(noteObject.rNote.noteInfo.trackID);
				}
				else
				{
					if (noteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.Continue)
						return;
					uiController.Hud.HideSlideNotesTouchEffect(noteObject.rNote.noteInfo.trackID);
					uiController.Hud.HideSlideNotesTipEffect(noteObject.rNote.noteInfo.trackID);
					return;
				}
			}
			//LAB_009c97b0
			if (b || noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Continue)
			{
				if (noteObject.rNote.noteInfo.isSlide)
				{
					if (noteObject.rNote.noteInfo.trackID != rNoteOwner.GetNote(noteObject.rNote.noteInfo.nextIndex).noteInfo.trackID)
					{
						b = true;
					}
					if (b)
					{
						uiController.Hud.HideSlideNotesTouchEffect(noteObject.rNote.noteInfo.trackID);
						uiController.Hud.HideSlideNotesTipEffect(noteObject.rNote.noteInfo.trackID);
					}
				}
				else
				{
					uiController.Hud.HideLongNotesTouchEffect(noteObject.rNote.noteInfo.trackID);
				}
				if (a_result_ex.m_result == RhythmGameConsts.NoteResult.Miss)
					return;
			}
			else
			{
				if (!(noteObject.rNote.noteInfo.swipe != MusicScoreData.TouchState.SwipeStart && a_result_ex.m_result != RhythmGameConsts.NoteResult.Miss))
					return;
			}
			uiController.Hud.ShowNotesHitEffect(noteObject.rNote.noteInfo.trackID);
		}

		// // RVA: 0x9C9CC4 Offset: 0x9C9CC4 VA: 0x9C9CC4
		private void JudgedNoteSound(RNoteObject noteObject, RhythmGameConsts.NoteResult result)
		{
			bool isLongBegin = true;
			if (noteObject.rNote.noteInfo.swipe != MusicScoreData.TouchState.Start)
			{
				isLongBegin = noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Start;
			}
			bool isLongEnd = true;
			if (noteObject.rNote.noteInfo.swipe != MusicScoreData.TouchState.End)
			{
				isLongEnd = noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.End;
			}
			if(NotesSoundPlayer.isNewNoteSoundEnable)
			{
				notesSoundPlayer.OnJudge(noteObject.rNote.noteInfo.trackID, (int)result, isLongBegin, isLongEnd, noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Continue, noteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.None, result == RhythmGameConsts.NoteResult.Miss);
				return;
			}
			if (noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Continue)
				isLongBegin = true;
			if(result != RhythmGameConsts.NoteResult.Miss && isLongBegin)
			{
				if(loopSEPlayback[NotesSoundPlayer.LineIDToLineGroup(noteObject.rNote.noteInfo.trackID)].GetStatus() != CriAtomExPlayback.Status.Removed)
				{
					loopSEPlayback[NotesSoundPlayer.LineIDToLineGroup(noteObject.rNote.noteInfo.trackID)].Stop();
				}
				loopSEPlayback[NotesSoundPlayer.LineIDToLineGroup(noteObject.rNote.noteInfo.trackID)] = PlayNotesSE(NoteSEType.LongLoop);
				loopSEPlayback[NotesSoundPlayer.LineIDToLineGroup(noteObject.rNote.noteInfo.trackID)].Pause(bgmPlayer.source.IsPaused());
			}
			if(result == RhythmGameConsts.NoteResult.Miss || ((int)noteObject.rNote.noteInfo.longTouch ^ 3) == 0 || isLongEnd)
			{
				loopSEPlayback[NotesSoundPlayer.LineIDToLineGroup(noteObject.rNote.noteInfo.trackID)].Stop();
			}
			PlayNoteSEByResult(result, noteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.None);
		}

		// // RVA: 0x9CA658 Offset: 0x9CA658 VA: 0x9CA658
		private void PlayNoteSEByResult(RhythmGameConsts.NoteResult result, bool isFlick)
		{
			switch(result)
			{
				case RhythmGameConsts.NoteResult.Bad:
					PlayNotesSE(NoteSEType.Bad);
					break;
				case RhythmGameConsts.NoteResult.Good:
					PlayNotesSE(NoteSEType.Good);
					break;
				case RhythmGameConsts.NoteResult.Great:
					PlayNotesSE(isFlick ? NoteSEType.FlickGreat : NoteSEType.Great);
					break;
				case RhythmGameConsts.NoteResult.Perfect:
					PlayNotesSE(isFlick ? NoteSEType.FlickPerfect : NoteSEType.Perfect);
					break;
				default:
					break;
			}
		}

		// // RVA: 0x9C6474 Offset: 0x9C6474 VA: 0x9C6474
		private CriAtomExPlayback PlayNotesSE(NoteSEType type)
		{
			if (isIgnorePlayNotesSE)
				return new CriAtomExPlayback(CriAtomExPlayback.invalidId);
			return SoundManager.Instance.sePlayerNotes.Play(noteTouchSEIndex[(int)type]);
		}

		// // RVA: 0x9CA550 Offset: 0x9CA550 VA: 0x9CA550
		private void EnterNoteResult(RhythmGameConsts.NoteResultEx a_result_ex, int trackID)
		{
			uiController.Hud.ShowResultEffect(trackID, a_result_ex);
		}

		// // RVA: 0x9BBDAC Offset: 0x9BBDAC VA: 0x9BBDAC
		private void ReJudgeValkyrieNotes()
		{
			for(int i = 0; i < preJudgeValkyrieNotes.Count; i++)
			{
				RNote.ModeInfo info = preJudgeValkyrieNotes[i].rNote.CurrentModeInfo(status.internalMode);
				if(preJudgeValkyrieNotes[i].rNote.result == RhythmGameConsts.NoteResult.Great || preJudgeValkyrieNotes[i].rNote.result == RhythmGameConsts.NoteResult.Perfect)
				{
					status.comboValkyrie.IncreaseCombo();
				}
				else
				{
					status.comboValkyrie.Zero();
				}
				if(status.IsEnableValkyrieAttack())
				{
					bool is3DMode = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D;
					bool showValkyrie = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.AOOKLMAPPLG_IsValkyrieModeEnabled();
					int dmg = status.enemy.Damage(preJudgeValkyrieNotes[i].rNote.result, preJudgeValkyrieNotes[i].rNote.GetIndexInMode(MusicData.NoteModeType.Valkyrie), status.comboValkyrie.current, 1.0f, 1.0f, info.specialNoteType);
					uiController.UpdateEnemyLife(status.enemy.currentValue, status.enemy.subgoalValue, status.enemy.goalValue, () =>
					{
						//0xBF1B5C
						if (is3DMode && !showValkyrie)
							return;
						valkyrieObject.StartTransformAnimation();
					});
					Vector3 pos = new Vector3(0, 0, 0);
					if(is3DMode && showValkyrie)
					{
						valkyrieModeObject.GetLockOnTargetPos(out pos);
					}
					uiController.UpdateEnemyDamageResult(dmg, pos);
				}
			}
			preJudgeValkyrieNotes.Clear();
		}

		// // RVA: 0x9CA6EC Offset: 0x9CA6EC VA: 0x9CA6EC
		private void StartPlayMusic(int startTime)
		{
			SoundManager.Instance.SetInGame(true);
			bgmPlayer.source.player.SetStartTime(startTime);
			bgmPlayback = bgmPlayer.source.Play();
			ExternLib.LibCriWare.checkUncached = true; // Wait for bgm to be started
			gameDivaObject.PlayMusicAnimation(0);
			for(int i = 0; i < subDivaObject.Length; i++)
			{
				if(subDivaObject[i] != null)
				{
					subDivaObject[i].PlayMusicAnimation(0);
				}
			}
			musicCameraObject.PlayMusicAnimation(0);
			foreach(var slo in stageLightingObjectList)
			{
				slo.PlayMusicAnimation();
			}
			foreach(var slao in stageLightingAddObjectList)
			{
				slao.PlayMusicAnimation();
			}
			foreach(var seo in stageExtensionObjectList)
			{
				seo.PlayMusicAnimation();
			}
			foreach(var deo in divaExtensionObjectList)
			{
				deo.PlayMusicAnimation();
			}
			foreach(var dco in divaCutinObjectList)
			{
				dco.PlayMusicAnimation();
			}
			foreach(var mcco in musicCameraCutinObjectList)
			{
				mcco.PlayMusicAnimation();
			}
			uiController.Hud.Show(null);
			DebugFPS.Instance.StartMeasureAvg();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x744E94 Offset: 0x744E94 VA: 0x744E94
		// // RVA: 0x9CB194 Offset: 0x9CB194 VA: 0x9CB194
		private IEnumerator WaitMusicPlayCoroutine(float a_sec_wait)
		{
			float waittime;
			float startTime;
			//0xBF4584
			waittime = a_sec_wait;
			startTime = TimeWrapper.time;
			while (TimeWrapper.time - startTime < waittime)
				yield return null;
			StartPlayMusic(Mathf.RoundToInt((TimeWrapper.time - startTime - waittime) * 1000));
		}

		// // RVA: 0x9C3750 Offset: 0x9C3750 VA: 0x9C3750
		public void Play()
		{
			//XeApp.Game.GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D
			if(bgmPlayer.source.status == CriAtomSource.Status.Stop)
			{
				float val = resource.musicData.musicParam.stateOffsetSec;
				resource.musicIntroResource.OverrideMusicStartTime(ref val);
				if(val < 0.0f)
				{
					StartPlayMusic((int)(resource.musicData.musicParam.stateOffsetSec * -1000));
				}
				else
				{
					this.StartCoroutineWatched(WaitMusicPlayCoroutine(val));
				}
			}
			else
			{
				if(bgmPlayer.source.IsPaused())
					Resume();
				else
					Pause();
			}
		}

		// // RVA: 0x9B1FE8 Offset: 0x9B1FE8 VA: 0x9B1FE8
		public void Pause()
		{
			bgmPlayer.source.Pause(true);
			for(int i = 0; i < loopSEPlayback.Length; i++)
			{
				loopSEPlayback[i].Pause();
			}
			if(NotesSoundPlayer.isNewNoteSoundEnable)
			{
				notesSoundPlayer.Pause();
			}
			uiController.Pause();
			gameDivaObject.Pause();
			for(int i = 0; i < subDivaObject.Length; i++)
			{
				if(subDivaObject[i] != null)
					subDivaObject[i].Pause();
			}
			musicCameraObject.Pause();
			valkyrieObject.Pause();
			musicIntroObject.Pause();
			valkyrieModeObject.Pause();
			divaModeObject.Pause();
			foreach(var s in stageLightingObjectList)
			{
				s.Pause();
			}
			foreach(var s in stageLightingAddObjectList)
			{
				s.Pause();
			}
			foreach(var s in stageExtensionObjectList)
			{
				s.Pause();
			}
			foreach(var d in divaExtensionObjectList)
			{
				d.Pause();
			}
			foreach(var d in divaCutinObjectList)
			{
				d.Pause();
			}
			foreach(var m in musicCameraCutinObjectList)
			{
				m.Pause();
			}
			if(soundCheerOrderer != null)
				soundCheerOrderer.Pause();
		}

		// // RVA: 0x9B351C Offset: 0x9B351C VA: 0x9B351C
		public void Resume()
		{
			bgmPlayer.source.Pause(false);
			for(int i = 0; i < loopSEPlayback.Length; i++)
			{
				loopSEPlayback[i].Pause(false);
			}
			if(NotesSoundPlayer.isNewNoteSoundEnable)
			{
				notesSoundPlayer.Resume();
			}
			uiController.Resume();
			gameDivaObject.Resume();
			for(int i = 0; i < subDivaObject.Length; i++)
			{
				if(subDivaObject[i] != null)
				{
					subDivaObject[i].Resume();
				}
			}
			musicCameraObject.Resume();
			valkyrieObject.Resume();
			musicIntroObject.Resume();
			valkyrieModeObject.Resume();
			divaModeObject.Resume();
			foreach(var s in stageLightingObjectList)
			{
				s.Resume();
			}
			foreach(var s in stageLightingAddObjectList)
			{
				s.Resume();
			}
			foreach(var s in stageExtensionObjectList)
			{
				s.Resume();
			}
			foreach(var d in divaExtensionObjectList)
			{
				d.Resume();
			}
			foreach(var d in divaCutinObjectList)
			{
				d.Resume();
			}
			foreach(var m in musicCameraCutinObjectList)
			{
				m.Resume();
			}
			if (soundCheerOrderer != null)
				soundCheerOrderer.Resume();
		}

		// // RVA: 0x9CB244 Offset: 0x9CB244 VA: 0x9CB244
		// public void Stop() { }

		// // RVA: 0x9CC364 Offset: 0x9CC364 VA: 0x9CC364
		// public void RequestChangeMusicSequenceTime(int millisec) { }

		// // RVA: 0x9B30C4 Offset: 0x9B30C4 VA: 0x9B30C4
		private bool ApplyChangeMusicSequenceTime()
		{
			if(!isChangeSequenceRequest)
				return false;
			if(bgmPlayer.source.status == CriAtomSource.Status.Playing)
			{
				bgmPlayer.source.player.SetStartTime(Mathf.Clamp(musicRequestChangeMillisec, 0, musicMillisecLength));
				#if UNITY_ANDROID
				bgmPlayer.source.player.Stop();
				bgmPlayback = bgmPlayer.source.player.Start();
				#endif
				TodoLogger.LogError(0, "Check ApplyChangeMusicSequenceTime");
				isChangeSequenceRequest = false;
				return true;
			}
			return false;
		}

		// // RVA: 0x9B2AC4 Offset: 0x9B2AC4 VA: 0x9B2AC4
		public static float ToSecTime(int millisec)
		{
			return millisec / 1000.0f;
		}

		// // RVA: 0x9CC3D4 Offset: 0x9CC3D4 VA: 0x9CC3D4
		// public static int ToMillisecTime(float sec) { }

		// // RVA: 0x9CC3F0 Offset: 0x9CC3F0 VA: 0x9CC3F0
		// private bool IsPlayingMusic() { }

		// // RVA: 0x9B1F80 Offset: 0x9B1F80 VA: 0x9B1F80
		private bool IsStopMusic()
		{
			return bgmPlayer.source.status == CriAtomSource.Status.Stop;
		}

		// // RVA: 0x9CC458 Offset: 0x9CC458 VA: 0x9CC458
		// public int GetMusicMillisecLength() { }

		// // RVA: 0x9B2A48 Offset: 0x9B2A48 VA: 0x9B2A48
		public int GetRawMusicMillisec()
		{
			int res = tutorialPopupStartTime;
			if(tutorialPopupStartTime < 0)
			{
				res = (int)bgmPlayback.timeSyncedWithAudio;
				if(currentRawMusicMillisec < -1)
					res = musicRequestChangeMillisec;
			}
			return res;
		}

		// // RVA: 0x9B2A88 Offset: 0x9B2A88 VA: 0x9B2A88
		public int IncludeDeviceLatency(int rawMillisec)
		{
			return rawMillisec - SoundManager.Instance.estimatedLatencyMillisec;
		}

		// // RVA: 0x9B2A7C Offset: 0x9B2A7C VA: 0x9B2A7C
		// public int IncludeNotesOffsert(int rawMillisec) { }

		// // RVA: 0x9B9168 Offset: 0x9B9168 VA: 0x9B9168
		private bool IsEnableMovie()
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GPKILPOLNKO();
		}

		// // RVA: 0x9BE120 Offset: 0x9BE120 VA: 0x9BE120
		public bool IsRhythmGamePlayerEnd()
		{
			if(isVisiblePauseWindow)
				return false;
			return !rhythmGameResultStartEvent.active;
		}

		// // RVA: 0x9CC460 Offset: 0x9CC460 VA: 0x9CC460
		public void OnCallback_PlayVoice_GameFailed()
		{
			RhythmGameVoicePlayer.Result voice = voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.GameOver);
			if (voice == RhythmGameVoicePlayer.Result.None)
			{
				SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.GameFailed, 0);
			}
		}

		// // RVA: 0x9CC4E8 Offset: 0x9CC4E8 VA: 0x9CC4E8
		public void OnCallback_PlayVoice_GameClear_PerfectFullCombo()
		{
			RhythmGameVoicePlayer.Result voice = voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.GameClear_PerfectFullCombo);
			if(voice == RhythmGameVoicePlayer.Result.None)
			{
				SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.GameClear, 1);
			}
		}

		// // RVA: 0x9CC570 Offset: 0x9CC570 VA: 0x9CC570
		public void OnCallback_PlayVoice_GameClear_FullCombo()
		{
			RhythmGameVoicePlayer.Result voice = voicePlayer.ChangePlayVoice(RhythmGameVoicePlayer.Voice.GameClear_FullCombo);
			if (voice == RhythmGameVoicePlayer.Result.None)
			{
				SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.GameClear, 0);
			}
		}

		// // RVA: 0x9CC5F8 Offset: 0x9CC5F8 VA: 0x9CC5F8
		private bool TutorialChecker(TutorialConditionId condition)
		{
			return condition == TutorialConditionId.Condition59;
		}

	}
}
