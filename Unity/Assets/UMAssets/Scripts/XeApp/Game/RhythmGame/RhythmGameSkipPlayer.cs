using CriWare;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.uGUI;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameSkipPlayer : MonoBehaviour
	{
		public class Skip
		{
			public const int ADD_MSEC = 16;
			public const int LOOP_MAX = 100;
			public bool m_enable = true; // 0x8
			public bool m_enable_update; // 0x9
			public bool m_pause; // 0xA
			public int m_now_msec; // 0xC
			public int m_add_msec; // 0x10
			public ILDKBCLAFPB.MPHNGGECENI_Option m_save_option; // 0x14

			//// RVA: 0xC07B1C Offset: 0xC07B1C VA: 0xC07B1C
			//public void Start() { }

			//// RVA: 0xC089E8 Offset: 0xC089E8 VA: 0xC089E8
			//public void Stop() { }

			//// RVA: 0xC07B38 Offset: 0xC07B38 VA: 0xC07B38
			//public void Pause() { }

			//// RVA: 0xC07B44 Offset: 0xC07B44 VA: 0xC07B44
			//public void Resume() { }

			//// RVA: 0xC07B50 Offset: 0xC07B50 VA: 0xC07B50
			//public int UpdateMSEC() { }
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
			Num = 8,
		}

		public static readonly Color IntroEndFadeColor = new Color(0, 0, 0); // 0x0
		public static readonly Color ValkyrieStartFadeColor = new Color(0.7f, 0.8f, 0.8f); // 0x10
		public static readonly Color DivaModeEndFadeColor = new Color(0.9f, 0.9f, 0.9f); // 0x20
		public const float DivaModeEndFadeOutSec = 0.5f;
		public const float DivaModeEndFadeInSec = 0.5f;
		public CriAtomExPlayback bgmPlayback; // 0x10
		[SerializeField]
		private RhythmGameSkipScene scene; // 0x28
		[SerializeField]
		private RNoteOwner rNoteOwner; // 0x2C
		private RhythmGameConsts.NoteResultParam_Excellent m_NoteResultParam_Excellent = new RhythmGameConsts.NoteResultParam_Excellent(); // 0x30
		private RhythmGameConsts.NoteParam_CenterLiveSkill m_NoteParam_CLiveSkill = new RhythmGameConsts.NoteParam_CenterLiveSkill(); // 0x34
		private RhythmGameConsts.NoteParam_EventItem m_NoteParam_EventItem = new RhythmGameConsts.NoteParam_EventItem(); // 0x38
		private RhythmGameSpecialNotesAssigner.AssignInfo m_NoteAssingInfo = new RhythmGameSpecialNotesAssigner.AssignInfo(); // 0x3C
		private SkillOwner skillOwner = new SkillOwner(); // 0x44
		private BuffEffectOwner buffOwner = new BuffEffectOwner(); // 0x48
		private RhythmGameSkipFlow gameFlow; // 0x4C
		private bool isPauseRequest; // 0x50
		private bool isResetRequest; // 0x51
		private bool isChangeSequenceRequest; // 0x52
		private bool isVisiblePauseWindow; // 0x53
		private bool isIgnorePlayNotesSE; // 0x54
		private int totalComboNum; // 0x58
		public int noteOffsetMillisec; // 0x5C
		public int currentRawMusicMillisec; // 0x60
		public int continueCount; // 0x64
		private int tutorialPopupStartTime = -1; // 0x68
		[SerializeField] // RVA: 0x68E558 Offset: 0x68E558 VA: 0x68E558
		private CRIAtomMemoryPoolInfo memPoolInfo; // 0x6C
		[SerializeField] // RVA: 0x68E568 Offset: 0x68E568 VA: 0x68E568
		private UGUIFader uguiFader; // 0x70
		private List<int> dropItemList = new List<int>(); // 0x8C
		private int[] dropItemRarityCount = new int[2]; // 0x90
		private RhythmGameResource resource; // 0x94
		private Action updater; // 0x98
		private List<RNoteObject> preJudgeValkyrieNotes = new List<RNoteObject>(); // 0x9C
		private bool skillTouched; // 0xA0
		private bool touchedCenterLiveSkill; // 0xA1
		private bool touchedEventItem; // 0xA2
		private List<int> liveSkillActivateCountList = new List<int>(TeamConst.TeamSceneNum); // 0xA4
		private RhythmGamePlayLogger logger = new RhythmGamePlayLogger(); // 0xA8
		private int m_bit_note_result; // 0xAC
		public Skip m_skip = new Skip(); // 0xB0
		private int[] noteTouchSEIndex = new int[8] { 4, 5, 3, 2, 1, 0, 7, 6 }; // 0xB4
		private const int BattleEventVoiceNum = 3;
		public static bool IsLowQualityMode; // 0x30

		public RhythmGamePlayer.Setting setting { get; private set; } // 0xC
		public MusicData musicData { get { return resource.musicData; } private set { return; } } //0xBFF9CC 0xBFF9F0
		public BgmPlayer bgmPlayer { get { return SoundManager.Instance.bgmPlayer; } private set { return; } } //0xBFF9F4 0xBFFA28
		public int musicMillisecLength { get; private set; } // 0x14
		public int notesMillisec { get; private set; } // 0x18
		public int deviceMillisec { get; private set; } // 0x1C
		public float deviceSec { get; private set; } // 0x20
		public int musicRequestChangeMillisec { get; private set; } // 0x24
		public RhythmGameStatus status { get; private set; } // 0x40
		public RhythmGameScoreEvent introFadeEvent { get; private set; } // 0x74
		public RhythmGameScoreEvent normalModeEndEvent { get; private set; } // 0x78
		public RhythmGameScoreEvent valkyrieModeStartEvent { get; private set; } // 0x7C
		public RhythmGameScoreEvent valkyrieModeEndEvent { get; private set; } // 0x80
		public RhythmGameScoreEvent divaModeStartEvent { get; private set; } // 0x84
		public RhythmGameScoreEvent rhythmGameResultStartEvent { get; private set; } // 0x88

		// RVA: 0xBFFAEC Offset: 0xBFFAEC VA: 0xBFFAEC
		private void Awake()
		{
			resource = gameObject.AddComponent<RhythmGameResource>();
		}

		// RVA: 0xBFFB74 Offset: 0xBFFB74 VA: 0xBFFB74
		private void Start()
		{
			InitializeSetting();
			gameFlow = new RhythmGameSkipFlow(resource, LoadedRhythmGame, Database.Instance.gameSetup.musicInfo.difficultyType, StartRhythmGame, this, null, ClearEndRhythmGame, GameStartErrorToTitleAction);
			scene.onChangeScene = OnChangeScene;
			updater = InitializeTask;
		}

		// RVA: 0xBFFFCC Offset: 0xBFFFCC VA: 0xBFFFCC
		private void Update()
		{
			if (updater != null)
				updater();
			gameFlow.OnUpdate();
		}

		// RVA: 0xC00018 Offset: 0xC00018 VA: 0xC00018
		private void LateUpdate()
		{
			return;
		}

		// RVA: 0xC00030 Offset: 0xC00030 VA: 0xC00030
		private void OnDestroy()
		{
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
				return;
			GameManager.Instance.PopupCanvas.worldCamera.clearFlags = CameraClearFlags.Nothing;
		}

		//// RVA: 0xC001C4 Offset: 0xC001C4 VA: 0xC001C4
		private void InitializeTask()
		{
			if (!scene.isReady)
				return;
			InitializeMusicData();
			InitializeGameData();
			updater = UpdateTask_Skip;
		}

		//// RVA: 0xC00298 Offset: 0xC00298 VA: 0xC00298
		private void UpdateTask_Skip()
		{
			for(int i = 0; i < 100; i++)
			{
				UpdateTask();
				rNoteOwner.UpdateObjectPool();
			}
		}

		//// RVA: 0xC002DC Offset: 0xC002DC VA: 0xC002DC
		private void UpdateTask()
		{
			if(isPauseRequest)
			{
				isPauseRequest = false;
				rNoteOwner.Pause();
				m_skip.m_pause = true;
			}
			currentRawMusicMillisec = GetRawMusicMillisec();
			notesMillisec = currentRawMusicMillisec - noteOffsetMillisec;
			deviceMillisec = IncludeDeviceLatency(currentRawMusicMillisec);
			deviceSec = deviceMillisec / 1000.0f;
			if (!isResetRequest)
			{
				normalModeEndEvent.Update(notesMillisec);
				valkyrieModeStartEvent.Update(notesMillisec);
				valkyrieModeEndEvent.Update(notesMillisec);
				divaModeStartEvent.Update(notesMillisec);
				if (!isVisiblePauseWindow)
				{
					rhythmGameResultStartEvent.Update(notesMillisec);
				}
				introFadeEvent.Update(deviceMillisec);
				if (!isResetRequest)
				{
					rNoteOwner.OnUpdate(notesMillisec);
				}
			}
			status.Update();
			if(!isVisiblePauseWindow)
			{
				if(status.life.current < 1 && !isVisiblePauseWindow)
				{
					isPauseRequest = true;
					isVisiblePauseWindow = true;
				}
				UpdateSkill(notesMillisec);
				m_bit_note_result = 0;
			}
		}

		//// RVA: 0xC0002C Offset: 0xC0002C VA: 0xC0002C
		//private void LateUpdateTask() { }

		// RVA: 0xC00A50 Offset: 0xC00A50 VA: 0xC00A50
		private void OnApplicationPause(bool pauseStatus)
		{
			if(!pauseStatus)
			{
				if (isVisiblePauseWindow)
					return;
				rNoteOwner.Resume();
				m_skip.m_pause = false;
				return;
			}
			if (isVisiblePauseWindow)
				return;
			rNoteOwner.Pause();
			m_skip.m_pause = true;
		}

		//// RVA: 0xC0027C Offset: 0xC0027C VA: 0xC0027C
		//private void Initialize() { }

		//// RVA: 0xC01890 Offset: 0xC01890 VA: 0xC01890
		//private bool Lottery(float t_rate) { }

		//// RVA: 0xC00B24 Offset: 0xC00B24 VA: 0xC00B24
		private void InitializeMusicData()
		{
			totalComboNum = resource.musicData.musicScoreData.CalcComboLimit();
			bgmPlayer.RequestChangeCueSheet(resource.musicData.musicBase.KKPAHLMJKIH_WavId, null);
			bgmPlayer.ChangeMusicCue(resource.musicData.musicBase.KKPAHLMJKIH_WavId);
			musicMillisecLength = bgmPlayer.millisecLength;
			InitializeMusicScoreEvent();
			GameSetupData gs = Database.Instance.gameSetup;
			status = new RhythmGameStatus(new RhythmGameStatus.InitializeData()
			{
				musicData = resource.musicData,
				teamScoreValue = gs.teamInfo.teamStatus.soul + gs.teamInfo.teamStatus.vocal + gs.teamInfo.teamStatus.charm,
				teamEnergyValue = gs.teamInfo.teamStatus.fold,
				supportRate = gs.teamInfo.teamStatus.support * 1.0f / IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.MPAMBMKFCKK_BCoeff2 + 1,
				valkyrieId = gs.teamInfo.valkyrieId,
				maxLife = gs.teamInfo.teamStatus.life,
				isLiveSkip = m_skip.m_enable
			}, null);
			if(!setting.m_enable_cutin)
			{
				status.energy.DisableCallbackPilotVoice();
			}
			m_NoteResultParam_Excellent.m_note_judge_rate = gs.teamInfo.excellentRate / 100.0f;
			m_NoteResultParam_Excellent.m_score_rate = gs.teamInfo.excellentScoreAdd / 100.0f;
			m_NoteParam_CLiveSkill.m_assign_rate = gs.teamInfo.centerLiveSkillRate / 100.0f;
			m_NoteParam_EventItem.m_enable = JGEOBNENMAH.HHCJCDFCLOB.HIGJBGFJMMO;
			m_NoteAssingInfo.m_center_live_skill = UnityEngine.Random.Range(0, 100000) <= m_NoteParam_CLiveSkill.m_assign_rate * 100000.0f;
			m_NoteAssingInfo.m_center_live_skill_index = m_NoteParam_CLiveSkill.m_assign_index;
			m_NoteAssingInfo.m_event_item = m_NoteParam_EventItem.m_enable;
			m_NoteAssingInfo.m_event_item_index = m_NoteParam_EventItem.m_index;
			rNoteOwner.Initialize(resource.musicData, status.internalMode, buffOwner, m_NoteAssingInfo, false, false, m_skip.m_enable);
			rNoteOwner.RemoveAllDelegate();
			rNoteOwner.AddJudgeDelegate(RNoteJudgedResultDelegate);
			rNoteOwner.SetDelegateOverrideNoteJudge(RNoteOverwrideJudgedResultDelegate);
		}

		//// RVA: 0xC013B0 Offset: 0xC013B0 VA: 0xC013B0
		private void InitializeGameData()
		{
			rNoteOwner.SetLineAlphaCallback(null);
			InitializeSkill();
			noteOffsetMillisec = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OJAJHIMOIEC_NoteOffset * 10;
			bgmPlayer.source.player.SetStartTime(0);
			bgmPlayer.source.Stop();
			bgmPlayer.source.Pause(false);
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
			continueCount = 0;
		}

		//// RVA: 0xBFFDE0 Offset: 0xBFFDE0 VA: 0xBFFDE0
		private void InitializeSetting()
		{
			setting = new RhythmGamePlayer.Setting();
			setting.m_enable_cutin = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GLKGAOFHLPN_IsCutinEnabled();
			setting.m_visible_diva = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CJKKALFPMLA_IsNotDivaModeDivaVisible;
		}

		//// RVA: 0xC001C0 Offset: 0xC001C0 VA: 0xC001C0
		//private void FinalizeModeMV() { }

		//// RVA: 0xC018E0 Offset: 0xC018E0 VA: 0xC018E0
		private void InitializeMusicScoreEvent()
		{
			introFadeEvent = new RhythmGameScoreEvent();
			if(resource.musicData.introFadeMillisec > -1)
			{
				introFadeEvent.onFireEvent = StartIntroFade;
				introFadeEvent.millisec = resource.musicData.introFadeMillisec;
				resource.musicIntroResource.OverrideIntroEndTime(ref introFadeEvent.millisec);
			}
			normalModeEndEvent = new RhythmGameScoreEvent();
			if(resource.musicData.valkyrieModeJudgeMillisec > -1)
			{
				normalModeEndEvent.onFireEvent = EndNormalMode;
				normalModeEndEvent.millisec = resource.musicData.valkyrieModeJudgeMillisec;
			}
			valkyrieModeStartEvent = new RhythmGameScoreEvent();
			if(resource.musicData.valkyrieModeStartMillisec > -1)
			{
				valkyrieModeStartEvent.onFireEvent = StartValkyrieMode;
				valkyrieModeStartEvent.millisec = resource.musicData.valkyrieModeStartMillisec;
			}
			valkyrieModeEndEvent = new RhythmGameScoreEvent();
			if(resource.musicData.divaModeJudgeMillisec > -1)
			{
				valkyrieModeEndEvent.onFireEvent = EndValkyrieMode;
				valkyrieModeEndEvent.millisec = resource.musicData.divaModeJudgeMillisec;
			}
			divaModeStartEvent = new RhythmGameScoreEvent();
			if(resource.musicData.divaModeStartMillisec > -1)
			{
				divaModeStartEvent.onFireEvent = StartDivaMode;
				divaModeStartEvent.millisec = resource.musicData.divaModeStartMillisec;
			}
			rhythmGameResultStartEvent = new RhythmGameScoreEvent();
			rhythmGameResultStartEvent.onFireEvent = OnStartRhythmGameResult;
			if(resource.musicData.rhythmGameResultStartMillisec > -1)
			{
				rhythmGameResultStartEvent.millisec = resource.musicData.rhythmGameResultStartMillisec;
			}
			else
			{
				resource.musicData.rhythmGameResultStartMillisec = musicMillisecLength - 5000;
			}
		}

		//// RVA: 0xC022F8 Offset: 0xC022F8 VA: 0xC022F8
		private void InitializeSkill()
		{
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
			touchedEventItem = false;
			skillTouched = false;
			touchedCenterLiveSkill = false;
			skillOwner.CheckFirstTrigger();
		}

		//// RVA: 0xC02654 Offset: 0xC02654 VA: 0xC02654
		private void StartIntroFade()
		{
			uguiFader.Fade(0.5f, IntroEndFadeColor);
			this.StartCoroutineWatched(WaitIntroFade());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x745CA4 Offset: 0x745CA4 VA: 0x745CA4
		//// RVA: 0xC0274C Offset: 0xC0274C VA: 0xC0274C
		private IEnumerator WaitIntroFade()
		{
			//0xC088A8
			while (uguiFader.isFading)
				yield return null;
			uguiFader.Fade(1, 0);
		}

		//// RVA: 0xC027F8 Offset: 0xC027F8 VA: 0xC027F8
		private void EndNormalMode()
		{
			status.directionMode.type = RhythmGameMode.Type.None;
			if(status.energy.mode == 0)
			{
				status.internalMode.type = RhythmGameMode.Type.None;
			}
			else if(status.energy.mode > 0)
			{
				status.internalMode.type = RhythmGameMode.Type.Valkyrie;
			}
			if(setting.m_mode_vl == RhythmGamePlayer.Setting.VMode.Normal)
			{
				status.internalMode.type = RhythmGameMode.Type.None;
			}
			else if(setting.m_mode_vl == RhythmGamePlayer.Setting.VMode.Valkyrie)
			{
				status.internalMode.type = RhythmGameMode.Type.Valkyrie;
			}
			rNoteOwner.OnChangeGameMode();
		}

		//// RVA: 0xC029D0 Offset: 0xC029D0 VA: 0xC029D0
		private void StartValkyrieMode()
		{
			logger.SetValkyrieModeType(status.internalMode.type);
			if (!status.internalMode.IsValkyrie())
				return;
			status.directionMode.type = status.internalMode.type;
			ReJudgeValkyrieNotes();
		}

		//// RVA: 0xC02D28 Offset: 0xC02D28 VA: 0xC02D28
		private void EndValkyrieMode()
		{
			if(setting.m_mode_dv == RhythmGamePlayer.Setting.DMode.None)
			{
				if (!status.directionMode.isValkyriePlayed)
					return;
				status.directionMode.type = RhythmGameMode.Type.None;
				if(status.enemy.mode != RhythmGameEnemyStatus.Mode.Goal)
				{
					if(status.enemy.mode == RhythmGameEnemyStatus.Mode.Subgoal)
					{
						status.internalMode.type = RhythmGameMode.Type.Diva;
					}
					else if(status.enemy.mode == RhythmGameEnemyStatus.Mode.Normal)
					{
						status.internalMode.type = RhythmGameMode.Type.None;
					}
				}
				else
				{
					status.internalMode.type = RhythmGameMode.Type.AwakenDiva;
				}
			}
			else
			{
				status.directionMode.type = RhythmGameMode.Type.None;
				if(setting.m_mode_dv == RhythmGamePlayer.Setting.DMode.Normal)
				{
					status.internalMode.type = RhythmGameMode.Type.None;
				}
				else if(setting.m_mode_dv != RhythmGamePlayer.Setting.DMode.Diva)
				{
					if(setting.m_mode_dv == RhythmGamePlayer.Setting.DMode.DivaAwake)
					{
						status.internalMode.type = RhythmGameMode.Type.AwakenDiva;
					}
				}
				else
				{
					status.internalMode.type = RhythmGameMode.Type.Diva;
				}
			}
			rNoteOwner.OnChangeGameMode();
		}

		//// RVA: 0xC02F14 Offset: 0xC02F14 VA: 0xC02F14
		private void StartDivaMode()
		{
			logger.SetDivaModeType(status.internalMode.type);
			if (!status.internalMode.IsDiva())
				return;
			status.directionMode.type = status.internalMode.type;
		}

		//// RVA: 0xC03034 Offset: 0xC03034 VA: 0xC03034
		private void OnStartRhythmGameResult()
		{
			return;
		}

		//// RVA: 0xC006FC Offset: 0xC006FC VA: 0xC006FC
		private void UpdateSkill(int musicMillisec)
		{
			if (isResetRequest)
				return;
			if(isVisiblePauseWindow || rhythmGameResultStartEvent.active)
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
					touchedCenterLiveSkillNote = touchedCenterLiveSkill,
				}, buffOwner);
			}
			buffOwner.OnUpdate(new BuffDurationCheckParameter() { musicTime = musicMillisec / 1000.0f, isValkyrieMode = false, modeType = status.directionMode.type, bitNoteResult = m_bit_note_result });
		}

		//// RVA: 0xC03048 Offset: 0xC03048 VA: 0xC03048
		private void OnPosionSkillDamageCallback(BuffEffect buff)
		{
			float f = 1;
			if(buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ReduceDamage, -1))
			{
				f = 1 - Mathf.Min(buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ReduceDamage, -1, RhythmGameConsts.NoteResult.None) / 100.0f, 1);
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.NoDamage, -1))
				f = 0;
			status.life.DamageValue(Mathf.RoundToInt(f * buff.effectValue));
		}

		//// RVA: 0xC03274 Offset: 0xC03274 VA: 0xC03274
		private void OnFullfillLiveSkill(LiveSkill skill)
		{
			int idx = skill.ownerSlotPlaceIndex + skill.ownerDivaPlaceIndex * 3;
			if(skill.SkillIndex == 0)
			{
				liveSkillActivateCountList[idx]++;
			}
			AddSkillLog(skill, false);
			if (skill.durationType != SkillDuration.Type.Instant)
				return;
			ActivateInstantBuff(skill);
		}

		//// RVA: 0xC037F8 Offset: 0xC037F8 VA: 0xC037F8
		private void OnFullfillActiveSkill(ActiveSkill skill)
		{
			AddSkillLog(skill, true);
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KKBJCJNAGDB_CutInEnabled())
			{
				int sceneId = Database.Instance.gameSetup.teamInfo.divaList[0].sceneIdList[0];
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
				{
					//CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[sceneId - 1].JPIPENJGGDD_Mlt;
				}
			}
			if(Database.Instance.gameSetup.musicInfo.isTutorialTwo)
			{
				BasicTutorialManager.Instance.HideCursor();
			}
			if (skill.durationType == SkillDuration.Type.Instant)
				ActivateInstantBuff(skill);
		}

		//// RVA: 0xC03BA4 Offset: 0xC03BA4 VA: 0xC03BA4
		private void OnFullfillEnemySkill(EnemySkill skill)
		{
			if(skill.masterSkill.CPNAGMFCIJK_TriggerType == 8)
			{
				if (skill.buffEffectType != SkillBuffEffect.Type.EnemyLifeUp)
					return;
				status.enemy.SetupEnemyLife(skill);
				return;
			}
			if (skill.durationType == SkillDuration.Type.Instant)
				ActivateInstantBuff(skill);
		}

		//// RVA: 0xC03C84 Offset: 0xC03C84 VA: 0xC03C84
		private void OnActiveBuffEffect(BuffEffect buff)
		{
			if (buff.effectType != SkillBuffEffect.Type.AllItemNotes)
				return;
			status.internalMode.isAllItemMode = true;
			rNoteOwner.OnChangeGameMode();
		}

		//// RVA: 0xC03D0C Offset: 0xC03D0C VA: 0xC03D0C
		private void OnRemoveBuffEffect(BuffEffect buff, int ownerDivaPlaceIndex)
		{
			if (buff.effectType != SkillBuffEffect.Type.AllItemNotes)
				return;
			status.internalMode.isAllItemMode = false;
			rNoteOwner.OnChangeGameMode();
		}

		//// RVA: 0xC036B4 Offset: 0xC036B4 VA: 0xC036B4
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
			else if(skill.buffEffectType == SkillBuffEffect.Type.EffectValueUp)
			{
				skillOwner.LiveSkillEffectValueUp(skill);
			}
		}

		//// RVA: 0xC03410 Offset: 0xC03410 VA: 0xC03410
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

		//// RVA: 0xC03D94 Offset: 0xC03D94 VA: 0xC03D94
		private void LoadedRhythmGame()
		{
			scene.isReady = true;
		}

		//// RVA: 0xC03DBC Offset: 0xC03DBC VA: 0xC03DBC
		private void StartRhythmGame()
		{
			GameManager.Instance.GameUIIntro.DoIntro();
			GameManager.Instance.GameUIIntro.onAnimationEndCallback = () =>
			{
				//0xC07FB8
				GameManager.Instance.DeleteIntro();
			};
			Play();
		}

		//// RVA: 0xC006E4 Offset: 0xC006E4 VA: 0xC006E4
		//private void Failed() { }

		//// RVA: 0xC04064 Offset: 0xC04064 VA: 0xC04064
		//private void OnSuccessInPaidVCPurchase() { }

		//// RVA: 0xC04150 Offset: 0xC04150 VA: 0xC04150
		//private void OnCancelInPaidVCPurchase() { }

		//// RVA: 0xC04154 Offset: 0xC04154 VA: 0xC04154
		//private void OnErrorInPaidVCPurchase() { }

		//// RVA: 0xC0428C Offset: 0xC0428C VA: 0xC0428C
		//private void OnSuccessInGameContinueByPaidVC() { }

		//// RVA: 0xC04368 Offset: 0xC04368 VA: 0xC04368
		//private void OnErrorInGameContinueByPaidVC() { }

		//// RVA: 0xC03FFC Offset: 0xC03FFC VA: 0xC03FFC
		//private void PauseGame(bool isReserve = False) { }

		//// RVA: 0xC0436C Offset: 0xC0436C VA: 0xC0436C
		//private void ResumeGame() { }

		//// RVA: 0xC043AC Offset: 0xC043AC VA: 0xC043AC
		//private void MvModePauseRetry() { }

		//// RVA: 0xC04068 Offset: 0xC04068 VA: 0xC04068
		//private void ShowConfirmationWindow() { }

		//[IteratorStateMachineAttribute] // RVA: 0x745D1C Offset: 0x745D1C VA: 0x745D1C
		//// RVA: 0xC043B0 Offset: 0xC043B0 VA: 0xC043B0
		//private IEnumerator Co_ShowConfirmationWindow() { }

		//// RVA: 0xC0445C Offset: 0xC0445C VA: 0xC0445C
		private void OnChangeScene()
		{
			if (!Database.Instance.gameSetup.musicInfo.isTutorialTwo)
				return;
			BasicTutorialManager.Instance.HideCursor();
		}

		//// RVA: 0xC04548 Offset: 0xC04548 VA: 0xC04548
		private void GameStartErrorToTitleAction()
		{
			TodoLogger.Log(0, "GameStartErrorToTitleAction");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x745D94 Offset: 0x745D94 VA: 0x745D94
		//// RVA: 0xC045E8 Offset: 0xC045E8 VA: 0xC045E8
		//private IEnumerator Co_FadeOutAndExit() { }

		//// RVA: 0xC04694 Offset: 0xC04694 VA: 0xC04694
		//private void TutorialClearEndRhythmGame() { }

		//// RVA: 0xC04814 Offset: 0xC04814 VA: 0xC04814
		private void ClearEndRhythmGame()
		{
			this.StartCoroutineWatched(Co_WaitRhytmGameEnd(true));
		}

		//// RVA: 0xC04880 Offset: 0xC04880 VA: 0xC04880
		//private void FailedRhythmGame() { }

		//// RVA: 0xC0485C Offset: 0xC0485C VA: 0xC0485C
		//private void EndRhythmGame(bool isClear) { }

		//[IteratorStateMachineAttribute] // RVA: 0x745E0C Offset: 0x745E0C VA: 0x745E0C
		//// RVA: 0xC048C0 Offset: 0xC048C0 VA: 0xC048C0
		public IEnumerator Co_WaitRhytmGameEnd(bool isClear)
		{
			int[] noteResultCount; // 0x1C
			int noteResultCount_Excellent; // 0x20

			//0xC08388
			GameManager.FadeOut(0.4f);
			noteResultCount = new int[5];
			rNoteOwner.SetupNoteResultData(ref noteResultCount, logger);
			noteResultCount_Excellent = 0;
			noteResultCount_Excellent = rNoteOwner.GetExcellentResultNoteCount();
			JGEOBNENMAH.HAJIFNABIFF data;
			MakeClearSetupData(out data, noteResultCount, noteResultCount_Excellent, touchedEventItem ? 1 : 0);
			int t_next = 0;
			if(!isClear)
			{
				JGEOBNENMAH.HHCJCDFCLOB.EFHMAKNEGEA(data);
				t_next = 3;
			}
			else
			{
				JGEOBNENMAH.HHCJCDFCLOB.EFHPJGACNLK(data, () =>
				{
					//0xC0805C
					t_next = 2;
				}, () =>
				{
					//0xC08068
					t_next = 1;
				});
			}
			GameManager.Instance.SetTouchEffectVisible(false);
			GameManager.Instance.SetTouchEffectMode(false);
			while (t_next == 0)
				yield return null;
			if (t_next == 3)
				GotoMenuSceneInFailed();
			else if (t_next == 2)
				GotoMenuSceneInSuccess(noteResultCount, noteResultCount_Excellent);
			else if (t_next == 1)
				GotoTitleSceneInError();
		}

		//// RVA: 0xC04988 Offset: 0xC04988 VA: 0xC04988
		private void MakeClearSetupData(out JGEOBNENMAH.HAJIFNABIFF clearSetup, int[] noteResultCount, int noteResultCount_Excellent, int noteResultCount_EventItem)
		{
			CalcComboRank();
			status.combo.Reset();
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
			clearSetup.LCOHGOIDMDF_ComboRank = 0;
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
				clearSetup.HNHCIGMKPDC_DivaIds.Add(Database.Instance.gameSetup.teamInfo.divaList[i].divaId);
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
			clearSetup.PMCGHPOGLGM_IsSkip = Database.Instance.gameSetup.EnableLiveSkip;
			clearSetup.KAIPAEILJHO_TicketCount = Database.Instance.gameSetup.LiveSkipTicketCount;
			clearSetup.CEPCBJHNMJA_IsNotUpdateProfile = Database.Instance.gameSetup.IsNotUpdateProfile;
			if (status.score.CheckFalisification() != null)
				clearSetup.NMNHBJIAPGG_CheckFalsification = status.score.CheckFalisification();
			if (status.combo.CheckFalisification() != null)
				clearSetup.NMNHBJIAPGG_CheckFalsification = status.combo.CheckFalisification();
		}

		//// RVA: 0xC05B20 Offset: 0xC05B20 VA: 0xC05B20
		private void GotoMenuSceneInSuccess(int[] noteResultCount, int noteResultCount_Excellent)
		{
			Database.Instance.gameResult.Setup(true, false, noteResultCount, logger.log, noteResultCount_Excellent);
			scene.GotoMenuScene();
		}

		//// RVA: 0xC05CA0 Offset: 0xC05CA0 VA: 0xC05CA0
		private void GotoMenuSceneInFailed()
		{
			bool b = status.life.current == 0 && Database.Instance.gameSetup.musicInfo.freeMusicId != 0;
			if (b)
				TipsControl.SetSituationValue(TipsControl.SituationId.GameOver, 1);
			Database.Instance.gameResult.Setup(false, b, null, null, 0);
			scene.GotoMenuScene();
		}

		//// RVA: 0xC04158 Offset: 0xC04158 VA: 0xC04158
		private void GotoTitleSceneInError()
		{
			TodoLogger.Log(0, "GotoTitleSceneInError");
		}

		//// RVA: 0xC06190 Offset: 0xC06190 VA: 0xC06190
		//private void GotoTutorialGacha() { }

		//// RVA: 0xC06244 Offset: 0xC06244 VA: 0xC06244
		//private void GotoTutorialSkip() { }

		//// RVA: 0xC06340 Offset: 0xC06340 VA: 0xC06340
		//private void GotoStorySkip() { }

		//// RVA: 0xC05A98 Offset: 0xC05A98 VA: 0xC05A98
		public RhythmGameConsts.ResultComboType CalcComboRank()
		{
			if (rNoteOwner.IsAllPerfectResult())
				return RhythmGameConsts.ResultComboType.PerfectFullCombo;
			return status.combo.record == totalComboNum ? RhythmGameConsts.ResultComboType.FullCombo : RhythmGameConsts.ResultComboType.Complete;
		}

		//// RVA: 0xC06344 Offset: 0xC06344 VA: 0xC06344
		//private void AddInvincibleBuffEffect() { }

		//// RVA: 0xC064D4 Offset: 0xC064D4 VA: 0xC064D4
		private void RNoteOverwrideJudgedResultDelegate(RNoteObject a_note_obj, ref RhythmGameConsts.NoteResultEx a_result_ex)
		{
			if(buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.OverwritePerfect, a_note_obj.rNote.GetLineNo()))
			{
				if (a_result_ex.m_result == RhythmGameConsts.NoteResult.Bad || a_result_ex.m_result == RhythmGameConsts.NoteResult.Good || a_result_ex.m_result == RhythmGameConsts.NoteResult.Great)
					a_result_ex.m_result = RhythmGameConsts.NoteResult.Perfect;
			}
			if(a_result_ex.m_result == RhythmGameConsts.NoteResult.Perfect)
			{
				if (m_NoteResultParam_Excellent.m_note_judge_rate * 100000.0f < UnityEngine.Random.Range(0, 100000))
					return;
				a_result_ex.m_excellent = true;
			}
		}

		//// RVA: 0xC06684 Offset: 0xC06684 VA: 0xC06684
		private void RNoteJudgedResultDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex, RhythmGameConsts.NoteJudgeType a_judge_type)
		{
			JudgedNoteResult(noteObject, a_result_ex);
			status.life.isInvincibleGameEnd = rNoteOwner.CheckAllNotesEnd();
		}

		//// RVA: 0xC06754 Offset: 0xC06754 VA: 0xC06754
		private void JudgedNoteResult(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex)
		{
			RNote.ModeInfo info = noteObject.rNote.CurrentModeInfo(status.internalMode);
			bool b = false;
			if(status.directionMode.IsValkyrie())
			{
				if (noteObject.rNote.modeType == MusicData.NoteModeType.Valkyrie)
					b = true;
			}
			if (noteObject.rNote.noteInfo.swipe == MusicScoreData.TouchState.SwipeStart)
				return;
			if(buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.AutoCombo, noteObject.rNote.GetLineNo()) || (a_result_ex.m_result >= RhythmGameConsts.NoteResult.Great && a_result_ex.m_result < RhythmGameConsts.NoteResult.Num))
			{
				status.combo.IncreaseCombo();
				if(b)
				{
					status.comboValkyrie.IncreaseCombo();
				}
			}
			else
			{
				if(!buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ComboContinue, noteObject.rNote.GetLineNo()))
				{
					status.combo.Zero();
					if(b)
					{
						status.comboValkyrie.Zero();
					}
				}
			}
			float f = 1;
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ScoreUpPercentage, noteObject.rNote.GetLineNo()))
			{
				f = buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ScoreUpPercentage, noteObject.rNote.GetLineNo(), a_result_ex.m_result) / 100.0f + 1;
			}
			if(a_result_ex.m_result == RhythmGameConsts.NoteResult.Perfect)
			{
				if(buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.PerfectScoreUpPercentage, noteObject.rNote.GetLineNo()))
				{
					f += buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.PerfectScoreUpPercentage, noteObject.rNote.GetLineNo(), RhythmGameConsts.NoteResult.None) / 100.0f;
				}
			}
			if(buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ComboBonus, noteObject.rNote.GetLineNo()))
			{
				f += buffOwner.CalcComboBonus(status.combo.current, noteObject.rNote.GetLineNo());
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ScoreUpPercentage_FoldWave, noteObject.rNote.GetLineNo()))
			{
				f += buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ScoreUpPercentage_FoldWave, noteObject.rNote.GetLineNo(), a_result_ex.m_result) / 100.0f;
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ScoreUpPercentage_Intimacy, noteObject.rNote.GetLineNo()))
			{
				f += buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ScoreUpPercentage_Intimacy, noteObject.rNote.GetLineNo(), a_result_ex.m_result) / 100.0f;
			}
			int g = 0;
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ScoreUpValue, noteObject.rNote.GetLineNo()))
			{
				g = buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ScoreUpValue, noteObject.rNote.GetLineNo(), RhythmGameConsts.NoteResult.None);
			}
			status.score.IncreaseScore(a_result_ex, status.combo.current, f, g, info.specialNoteType, m_NoteResultParam_Excellent.m_score_rate, false);
			if(status.directionMode.IsNormal())
			{
				if(noteObject.rNote.modeType == MusicData.NoteModeType.Normal)
				{
					status.energy.ChangeValue(a_result_ex.m_result, 1, info.specialNoteType);
				}
			}
			if(b)
			{
				status.enemy.Damage(a_result_ex.m_result, noteObject.rNote.GetIndexInMode(MusicData.NoteModeType.Valkyrie), status.comboValkyrie.current, 1, 1, info.specialNoteType);
			}
			if(a_result_ex.m_result > RhythmGameConsts.NoteResult.Bad)
			{
				if(info.specialNoteType == RhythmGameConsts.SpecialNoteType.Heal)
				{
					status.life.HealNotes();
				}
				if (info.specialNoteType == RhythmGameConsts.SpecialNoteType.CenterLiveSkill)
				{
					touchedCenterLiveSkill = true;
				}
				if (info.specialNoteType == RhythmGameConsts.SpecialNoteType.EventItem)
				{
					touchedEventItem = true;
				}
				if(info.itemIndex > -1)
				{
					dropItemList.Add(info.itemIndex);
					dropItemRarityCount[~(info.itemIndex >> 30) & 1]++;
				}
			}
			f = 1;
			if(buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.DamegeUp, noteObject.rNote.GetLineNo()))
			{
				f = buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.DamegeUp, noteObject.rNote.GetLineNo(), RhythmGameConsts.NoteResult.None) / 100.0f + 1;
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.ReduceDamage, noteObject.rNote.GetLineNo()))
			{
				f *= (1 - Mathf.Min(buffOwner.effectiveBuffList.GetEffectValue(SkillBuffEffect.Type.ReduceDamage, noteObject.rNote.GetLineNo(), RhythmGameConsts.NoteResult.None) / 100.0f, 1));
			}
			if (buffOwner.effectiveBuffList.IsConatinEffectType(SkillBuffEffect.Type.NoDamage, noteObject.rNote.GetLineNo()))
			{
				f = 0;
			}
			if(Database.Instance.gameSetup.musicInfo.isTutorialOne || Database.Instance.gameSetup.musicInfo.isTutorialTwo)
			{
				f = 0;
			}
			if(a_result_ex.m_result == RhythmGameConsts.NoteResult.Miss)
			{
				if(noteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.Start)
				{
					if(noteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.Continue && noteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.End)
					{
						if(rNoteOwner.GetNote(noteObject.rNote.noteInfo.prevIndex).noteInfo.longTouch != MusicScoreData.TouchState.Continue)
						{
							status.life.DamageNotes(RhythmGameConsts.NoteResult.Miss, f);
						}
					}
					else
					{
						status.life.DamageNotes(RhythmGameConsts.NoteResult.Miss, f);
					}
				}
				else
				{
					if(noteObject.rNote.noteInfo.isSlide)
					{
						if(noteObject.rNote.noteInfo.nextIndex > -1)
						{
							if(rNoteOwner.GetNote(noteObject.rNote.noteInfo.nextIndex).noteInfo.longTouch != MusicScoreData.TouchState.Continue)
							{
								status.life.DamageNotes(RhythmGameConsts.NoteResult.Miss, f);
							}
						}
					}
				}
			}
			else if(a_result_ex.m_result == RhythmGameConsts.NoteResult.Bad)
			{
				status.life.DamageNotes(RhythmGameConsts.NoteResult.Bad, f);
			}
			if(status.directionMode.IsNormal())
			{
				if(noteObject.rNote.modeType == MusicData.NoteModeType.Valkyrie)
				{
					preJudgeValkyrieNotes.Add(noteObject);
				}
			}
			if(noteObject.rNote.noteInfo.isSlide)
			{
				if(noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.End && a_result_ex.m_result == RhythmGameConsts.NoteResult.Miss)
				{
					if(rNoteOwner.GetNote(noteObject.rNote.noteInfo.prevIndex).result == RhythmGameConsts.NoteResult.Miss)
					{
						if(rNoteOwner.GetNote(noteObject.rNote.noteInfo.prevIndex).noteInfo.longTouch != MusicScoreData.TouchState.Start)
						{
							if(rNoteOwner.GetNote(noteObject.rNote.noteInfo.prevIndex).noteInfo.longTouch != MusicScoreData.TouchState.Continue)
							{
								//
							}
						}
					}
				}
			}
			if (noteObject.rNote.noteInfo.isSlide)
			{
				if(noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Continue && a_result_ex.m_result == RhythmGameConsts.NoteResult.Miss)
				{
					if(noteObject.rNote.passingStatus == RNote.PassingStatus.Alive)
					{
						noteObject.rNote.ResetSlideNoteResult();
					}
				}
			}
			m_bit_note_result |= 1 << ((int)a_result_ex.m_result & 0x1f);
		}

		//// RVA: 0xC07B18 Offset: 0xC07B18 VA: 0xC07B18
		//private void EnterNoteResult(RhythmGameConsts.NoteResultEx a_result_ex, int trackID) { }

		//// RVA: 0xC02AF8 Offset: 0xC02AF8 VA: 0xC02AF8
		private void ReJudgeValkyrieNotes()
		{
			for(int i = 0; i < preJudgeValkyrieNotes.Count; i++)
			{
				preJudgeValkyrieNotes[i].rNote.CurrentModeInfo(status.internalMode);
				if(preJudgeValkyrieNotes[i].rNote.result == RhythmGameConsts.NoteResult.Great ||
					preJudgeValkyrieNotes[i].rNote.result == RhythmGameConsts.NoteResult.Perfect)
				{
					status.comboValkyrie.IncreaseCombo();
				}
				else
				{
					status.comboValkyrie.Zero();
				}
			}
		}

		//// RVA: 0xC03FA0 Offset: 0xC03FA0 VA: 0xC03FA0
		public void Play()
		{
			if (!m_skip.m_enable)
				return;
			m_skip.m_now_msec = 0;
			m_skip.m_add_msec = 16;
			m_skip.m_enable_update = true;
			m_skip.m_pause = false;
		}

		//// RVA: 0xC0058C Offset: 0xC0058C VA: 0xC0058C
		//public void Pause() { }

		//// RVA: 0xC00AFC Offset: 0xC00AFC VA: 0xC00AFC
		//public void Resume() { }

		//// RVA: 0xC00694 Offset: 0xC00694 VA: 0xC00694
		//public static float ToSecTime(int millisec) { }

		//// RVA: 0xC005B4 Offset: 0xC005B4 VA: 0xC005B4
		public int GetRawMusicMillisec()
		{
			if(m_skip.m_enable)
			{
				if(m_skip.m_enable_update && !m_skip.m_pause)
				{
					m_skip.m_now_msec += m_skip.m_add_msec;
				}
				return m_skip.m_now_msec;
			}
			if (tutorialPopupStartTime > -1)
				return tutorialPopupStartTime;
			if (bgmPlayback.timeSyncedWithAudio == 0)
				return musicRequestChangeMillisec;
			return (int)bgmPlayback.timeSyncedWithAudio;
		}

		//// RVA: 0xC00658 Offset: 0xC00658 VA: 0xC00658
		public int IncludeDeviceLatency(int rawMillisec)
		{
			return rawMillisec - SoundManager.Instance.estimatedLatencyMillisec;
		}

		//// RVA: 0xC0064C Offset: 0xC0064C VA: 0xC0064C
		//public int IncludeNotesOffsert(int rawMillisec) { }

		//// RVA: 0xBFF934 Offset: 0xBFF934 VA: 0xBFF934
		public bool IsRhythmGamePlayerEnd()
		{
			if (isVisiblePauseWindow)
				return false;
			return !rhythmGameResultStartEvent.active;
		}

		//// RVA: 0xC07B80 Offset: 0xC07B80 VA: 0xC07B80
		//private bool TutorialChecker(TutorialConditionId condition) { }
	}
}
