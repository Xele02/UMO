using UnityEngine;
using XeApp.Game.RhythmGame.UI;
using XeApp.Game.Common;
using System.Collections;
using System.Collections.Generic;
using XeSys;
using System;
using UnityEngine.Events;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameHUD : MonoBehaviour, IRhythmGameHUD
	{
		public enum EnemySkillEffectUseBit
		{
			Poison = 0,
		}

		private class EnemySkillEffect
		{
			public SkillBuffEffect.Type effectType; // 0x8
			public uint bitUseFlag; // 0xC
			public Animator effectAnimator; // 0x10
		}

		private enum AnchorPosition
		{
			Top = 0,
			Center = 1,
			Bottom = 2,
			LeftTop = 3,
			RightTop = 4,
		}

		private enum EnHudResultAnim
		{
			HUD_RESULT_ANIM_MISS = 0,
			HUD_RESULT_ANIM_BAD = 1,
			HUD_RESULT_ANIM_GOOD = 2,
			HUD_RESULT_ANIM_GREAT = 3,
			HUD_RESULT_ANIM_PERFECT = 4,
			HUD_RESULT_ANIM_EXCELLENT = 5,
			HUD_RESULT_ANIM_MAX = 6,
		}

		private RhythmGameHudPauseButtonEvent m_pauseButtonEvent = new RhythmGameHudPauseButtonEvent(); // 0xC
		[SerializeField]
		private GameObject m_touchParent; // 0x10
		[SerializeField]
		private GameObject m_touchPrefab; // 0x14
		[SerializeField]
		private TouchArea[] m_touchAreas; // 0x18
		[SerializeField]
		private GameObject m_userStateObject; // 0x1C
		[SerializeField]
		private GameObject m_targetSightPrefab; // 0x20
		[SerializeField]
		private BattleEvaluateObject m_battleEvaluatePrefab; // 0x24
		[SerializeField]
		private GameObject[] anchorRoots; // 0x28
		[SerializeField]
		private GameObject leftTopPrefab; // 0x2C
		[SerializeField]
		private GameObject rightTopPrefab; // 0x30
		[SerializeField]
		private GameObject centerPrefab; // 0x34
		[SerializeField]
		private GameObject lowEnergyPrefab; // 0x38
		[SerializeField]
		private GameObject bottomPrefab; // 0x3C
		[SerializeField]
		private GameObject valkyrieTopPrefab; // 0x40
		[SerializeField]
		private GameObject valkyrieTop2dPrefab; // 0x44
		[SerializeField]
		private GameObject valkyrieCenterPrefab; // 0x48
		[SerializeField]
		private GameObject valkyrieBottomPrefab; // 0x4C
		[SerializeField]
		private GameObject valkyrieBottomWidePrefab; // 0x50
		[SerializeField]
		private GameObject valkyrieTimer; // 0x54
		[SerializeField]
		private GameObject divaBottomPrefab; // 0x58
		[SerializeField]
		private GameObject divaBottomWidePrefab; // 0x5C
		[SerializeField]
		private GameObject divaToptPrefab; // 0x60
		[SerializeField]
		private GameObject divaModeBeltPrefab; // 0x64
		[SerializeField]
		private SkillCutin[] skillCutin; // 0x68
		[SerializeField]
		private GameObject battleResultPrefab; // 0x6C
		private bool m_isLowSpec; // 0x70
		private bool m_is2dMode; // 0x71
		private bool m_isValkyrieOff; // 0x72
		private ComboNumber m_combo; // 0x74
		private BattleCombo m_battleCombo; // 0x78
		private ScoreNumber m_score; // 0x7C
		private DropItemNumber m_item; // 0x80
		private FoldWaveGauge m_foldWaveGauge; // 0x84
		private RankGauge m_rankGauge; // 0x88
		private LifeGauge m_lifeGauge; // 0x8C
		private PauseButton m_pauseButton; // 0x90
		private ActiveSkillButton m_activeSkillButton; // 0x94
		private SkillCutin m_liveSkillCutin; // 0x98
		private ActiveSkillCutin m_activeSkillCutin; // 0x9C
		private EnemyStatus m_enemyStatus; // 0xA0
		private BattleTimeCounter m_battleTimeCount; // 0xA4
		private GameObject m_valkyrieTopUi; // 0xA8
		private Animator m_valkyrieTopAnimator; // 0xAC
		private GameObject m_valkyrieCenterUi; // 0xB0
		private BattleCenterUiAnimeControl m_valkyrieCenterEffectAnimator; // 0xB4
		private GameObject m_valkyrieBottomUi; // 0xB8
		private GameObject m_valkyrieTimer; // 0xBC
		private EffectBundleController m_valkyeriBottomEffectController; // 0xC0
		private EnemyTargetSight m_targetSight; // 0xC4
		private GameObject m_divaBottomUi; // 0xC8
		private GameObject m_divaTopUi; // 0xCC
		private GameObject m_bottomGameObjectInstance; // 0xD0
		private Animator m_mainGaugeAnimator; // 0xD4
		private Animator m_divaBottomUiAnimator; // 0xD8
		private Animator m_divaTopUiAnimator; // 0xDC
		private Animator m_lifeWarningEffect; // 0xE0
		private Animator m_lifeRecoveryEffect; // 0xE4
		private Animator m_divaModeEffect; // 0xE8
		private Animator m_divaModeBeltAnimator; // 0xEC
		private Animator m_targetSightMark; // 0xF0
		private TouchPrefabInstance[] m_touchEffects; // 0xF4
		private TouchCircleController m_touchCircleController; // 0xF8
		private LaneController m_laneController; // 0xFC
		private BattleEvaluateObjectPool m_battleEvaluatePool = new BattleEvaluateObjectPool(); // 0x100
		private int m_prevLife = 100; // 0x104
		private bool m_isContinue; // 0x108
		private IEnumerator WaitRecoveryFunc; // 0x10C
		private Animator m_lowEnergyAnimator; // 0x110
		private FaceCutin[] m_faceCutin; // 0x114
		private UiPilotTexture m_PilotTexture; // 0x118
		private UiDivaTexture m_DivaTexture; // 0x11C
		private UiEnemyPilotTexture m_EnemyPilotTexture; // 0x120
		private UiEnemyRobotTexture m_EnemyRobotTexture; // 0x124
		private Canvas m_canvas; // 0x128
		private RectTransform m_cameraRectTransform; // 0x12C
		private Camera m_uiCamera; // 0x130
		private List<RhythmGameHUD.EnemySkillEffect> m_permanencyEnemySkillList = new List<EnemySkillEffect>(); // 0x134
		private BattleResult m_battleResult; // 0x138
		private int m_currentEnemyDmageIndex; // 0x148
		private readonly float[] ResultScoreRankAngleTbl = new float[5] { 0, 0.4f, 0.6f, 0.8f, 1 }; // 0x150
		private readonly int UI_rhythm_Push_IN_HashCode = "UI_rhythm_Push_IN".GetHashCode(); // 0x154
		private readonly int UI_rhythm_Push_OUT_HashCode = "UI_rhythm_Push_OUT".GetHashCode(); // 0x158
		private readonly int UI_rhythm_Long_IN_HashCode = "UI_rhythm_Long_IN".GetHashCode(); // 0x15C
		private readonly int UI_rhythm_Long_Loop_HashCode = "UI_rhythm_Long_Loop".GetHashCode(); // 0x160
		private readonly int UI_rhythm_Long_OUT_HashCode = "UI_rhythm_Long_OUT".GetHashCode(); // 0x164
		private readonly int UI_rhythm_Delete_HashCode = "UI_rhythm_Delete".GetHashCode(); // 0x168
		private readonly int C_under_UI_Hash = Animator.StringToHash("C_under_UI"); // 0x16C
		private readonly int C_top_UI_B_OUT_HASH = Animator.StringToHash("C_top_UI_B_OUT"); // 0x170
		private readonly int UI_D_loop_Hash = Animator.StringToHash("UI_D_loop"); // 0x174
		private readonly int change_diva_mode_Hash = Animator.StringToHash("change_diva_mode"); // 0x178
		private readonly int change_SPdiva_mode = Animator.StringToHash("change_SPdiva_mode");// 0x17C
		private readonly int recovery_IN_Hash = Animator.StringToHash("recovery_IN"); // 0x180
		private readonly int recovery_OUT_Hash = Animator.StringToHash("recovery_OUT"); // 0x184
		private readonly int cut_IN_Hash = Animator.StringToHash("cut_IN"); // 0x188
		private readonly int cut_IN_SP_Hash = Animator.StringToHash("cut_IN_SP"); // 0x18C
		private readonly int cut_wait_Hash = Animator.StringToHash("cut_wait"); // 0x190
		private readonly int LoopEnd_Hash = Animator.StringToHash("LoopEnd"); // 0x194
		private readonly int damage_IN_Hash = Animator.StringToHash("damage_IN"); // 0x198
		private readonly int damage_OUT_Hash = Animator.StringToHash("damage_OUT"); // 0x19C
		private readonly int OUT_Hash = Animator.StringToHash("OUT"); // 0x1A0
		private readonly int notes_button_Hash = Animator.StringToHash("notes_button"); // 0x1A4
		private readonly int target_site_IN_Hash = Animator.StringToHash("target_site_IN"); // 0x1A8
		private readonly int target_site_OUT_Hash = Animator.StringToHash("target_site_OUT"); // 0x1AC
		private readonly int diva_button_ON_Hash = Animator.StringToHash("diva_button_ON"); // 0x1B0
		private readonly int poison_loop_Hash = Animator.StringToHash("poison_loop"); // 0x1B4
		private readonly int[] EnemyFrameColorAnimeStateHash = new int[5] { 
			Animator.StringToHash("green_ON"), Animator.StringToHash("lightgreen_ON"), Animator.StringToHash("yellow_ON"),
			Animator.StringToHash("orange_ON"), Animator.StringToHash("red_ON")
		 }; // 0x1B8
		private readonly int[] EnemyFaildFrameColorAnimeStateHash = new int[5] {
			Animator.StringToHash("green_faild"), Animator.StringToHash("lightgreen_faild"), Animator.StringToHash("yellow_faild"),
			Animator.StringToHash("orange_faild"), Animator.StringToHash("red_faild")
		}; // 0x1BC
		private readonly int[] ResultAnimationStateTable = new int[6] {
			"Miss".GetHashCode(), "Bad".GetHashCode(), "Good".GetHashCode(), "Great".GetHashCode(), "Perfect".GetHashCode(), "Excellent".GetHashCode()
		}; // 0x1C0
		private readonly float[] TouchEffectZOffsetTbl = new float[6] { -2, -1, -1, -2, -3, -3 }; // 0x1C4
		private static readonly int DivaModeSwitchSpModeAnimatorParam = Animator.StringToHash("IsSpMode"); // 0x0
		private static readonly int DivaModeSwitchNormalModeAnimatorParam = Animator.StringToHash("IsNormalMode"); // 0x4
		private static readonly int MainGaugeGoBattleParamHash = Animator.StringToHash("GoBattle"); // 0x8
		private static readonly int MainGaugeIsMaxParamHash = Animator.StringToHash("IsMax"); // 0xC
		private static readonly int GameStartUiTrigger = Animator.StringToHash("Start"); // 0x10
		private const int LifeWarningLevel1 = 50;
		private const int LifeWarningLevel2 = 30;
		private const int COMBO_MAX = 999;

		public RhythmGameHudPauseButtonEvent PauseButton { get { return m_pauseButtonEvent; } } //0xDCA528
		public bool isReadyHUD { get; set; } // 0x13C
		public int CurrentCombo { get; set; } // 0x140
		public int CurrentBattleCombo { get; set; } // 0x144
		public bool isEnableCutin { get; set; } // 0x14C
		public bool isShowNotes { get; set; } // 0x14D
		public bool isBattleLimitTimeRunning { get; set; } // 0x1C8

		// // RVA: 0xDCA580 Offset: 0xDCA580 VA: 0xDCA580 Slot: 17
		public void Initialize()
		{
			GameSetupData.TeamInfo team = Database.Instance.gameSetup.teamInfo;
			GameSetupData.MusicInfo music = Database.Instance.gameSetup.musicInfo;
			m_isLowSpec = !GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.MIHFCOBBIPJ_GetQuality2d();
			m_is2dMode = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OOCKIFIHJJN_Is2DMode;
			m_isValkyrieOff = !GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.AOOKLMAPPLG_IsValkyrieModeEnabled();
			int pilotId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[team.prismValkyrieId - 1].PFGJJLGLPAC_PilotId;
			m_canvas = GetComponentInParent<Canvas>();
			m_cameraRectTransform = m_canvas.GetComponent<RectTransform>();
			m_uiCamera = m_canvas.worldCamera;
			m_touchEffects = new TouchPrefabInstance[RhythmGameConsts.LineNum];
			string noteLinesName = RhythmGameConsts.IsWideLine() ? "GameNoteLinesW" : "GameNoteLines";
			Transform lineT = System.Array.Find(transform.parent.GetComponentsInChildren<Transform>(), (Transform _) => {
				//0x9A1E40
				return _.name == noteLinesName;
			});
			for(int i = 0; i < m_touchEffects.Length; i++)
			{
				GameObject g = Instantiate(m_touchPrefab);
				g.transform.SetParent(m_touchParent.transform, false);
				m_touchEffects[i] = g.GetComponent<TouchPrefabInstance>();
				m_touchEffects[i].Instantiate();
				m_touchEffects[i].touchEffect.Play(UI_rhythm_Push_OUT_HashCode, 0);
				m_touchEffects[i].touchEffect.Play(UI_rhythm_Long_OUT_HashCode, 0);
				m_touchEffects[i].SkillEffect.Initialize();
				m_touchEffects[i].gameObject.transform.position = lineT.transform.GetChild(i).transform.position;
				m_touchEffects[i].gameObject.transform.localScale = Vector3.one;
				Vector3 p = m_touchEffects[i].gameObject.transform.localPosition;
				p.z += TouchEffectZOffsetTbl.Length > i ? TouchEffectZOffsetTbl[i] : 0;
				m_touchEffects[i].gameObject.transform.localPosition = p;
				m_touchEffects[i].slideEffect.transform.localRotation = lineT.transform.localRotation;
			}
			GameObject b = RhythmGameInstantiatePrefab(bottomPrefab);
			b.transform.SetParent(anchorRoots[2].transform, false);
			m_combo = b.GetComponentInChildren<ComboNumber>(true);
			m_score = b.GetComponentInChildren<ScoreNumber>(true);
			m_item = b.GetComponentInChildren<DropItemNumber>(true);
			m_lifeGauge = b.GetComponentInChildren<LifeGauge>(true);
			m_rankGauge = b.GetComponentInChildren<RankGauge>(true);
			m_activeSkillButton = b.GetComponentInChildren<ActiveSkillButton>(true);
			m_mainGaugeAnimator = b.GetComponent<Animator>();
			m_touchCircleController = b.GetComponent<TouchCircleController>();
			m_laneController = b.GetComponent<LaneController>();
			m_laneController.Instantiate(RhythmGameConsts.IsWideLine());
			m_bottomGameObjectInstance = b;
			
			GameObject rt = RhythmGameInstantiatePrefab(rightTopPrefab);
			rt.transform.SetParent(anchorRoots[4].transform, false);
			m_foldWaveGauge = rt.GetComponent<FoldWaveGauge>();
			m_pauseButton = rt.GetComponent<PauseButton>();

			GameObject lt = RhythmGameInstantiatePrefab(leftTopPrefab);
			lt.transform.SetParent(anchorRoots[3].transform, false);
			m_liveSkillCutin = lt.GetComponentInChildren<SkillCutin>(true);

			GameObject c = RhythmGameInstantiatePrefab(centerPrefab);
			c.transform.SetParent(anchorRoots[1].transform, false);
			m_activeSkillCutin = c.GetComponent<ActiveSkillCutin>();

			GameObject le = RhythmGameInstantiatePrefab(lowEnergyPrefab);
			m_lowEnergyAnimator = le.GetComponent<Animator>();
			le.transform.SetParent(anchorRoots[1].transform, false);
			m_lowEnergyAnimator.Play(OUT_Hash, 0, 1);

			m_valkyrieBottomUi = RhythmGameInstantiatePrefab(RhythmGameConsts.IsWideLine() ? valkyrieBottomWidePrefab : valkyrieBottomPrefab);
			m_valkyeriBottomEffectController = m_valkyrieBottomUi.GetComponent<EffectBundleController>();
			m_valkyrieBottomUi.transform.SetParent(anchorRoots[2].transform, false);
			m_battleCombo = m_valkyrieBottomUi.GetComponent<BattleCombo>();

			m_valkyrieTimer = RhythmGameInstantiatePrefab(valkyrieTimer);
			m_battleTimeCount = m_valkyrieTimer.GetComponent<BattleTimeCounter>();
			m_valkyrieTimer.SetActive(false);

			m_valkyrieCenterUi = RhythmGameInstantiatePrefab(valkyrieCenterPrefab);
			m_valkyrieCenterEffectAnimator = m_valkyrieCenterUi.GetComponent<BattleCenterUiAnimeControl>();
			m_valkyrieCenterUi.transform.SetParent(anchorRoots[1].transform, false);
			m_valkyrieCenterEffectAnimator.Initialize();

			if(!m_isValkyrieOff)
			{
				m_valkyrieTopUi = RhythmGameInstantiatePrefab(m_is2dMode ? valkyrieTop2dPrefab : valkyrieTopPrefab);
				m_valkyrieTimer.transform.SetParent(anchorRoots[2].transform, false);
				m_valkyrieTimer.transform.localPosition = new Vector3(0, 246.0257f, 0);
			}
			else
			{
				m_valkyrieTopUi = RhythmGameInstantiatePrefab(valkyrieTopPrefab);
				int[] vals = new int[3];
				vals[0] = "ringS_model".GetHashCode();
				vals[1] = "ringM_model".GetHashCode();
				vals[2] = "ringL_model".GetHashCode();
				MeshRendererDict dict = m_valkyrieCenterUi.GetComponent<MeshRendererDict>();
				for(int i = 0; i < 3; i++)
				{
					Renderer r = dict.GetRenderer(vals[i]);
					if(r != null)
					{
						r.enabled = false;
					}
				}
				m_valkyrieTimer.transform.SetParent(anchorRoots[0].transform, false);
				m_valkyrieTimer.transform.localPosition = new Vector3(-390, -48, 0);
				m_valkyrieTopUi.transform.localScale = new Vector3(0.9f, 0.9f, 1);
				m_valkyrieTopUi.transform.Find("L_partsC_root").gameObject.SetActive(false);
				m_valkyrieTopUi.transform.Find("R_partsC_root").gameObject.SetActive(false);
			}
			m_enemyStatus = m_valkyrieTopUi.GetComponent<EnemyStatus>();
			m_targetSight = m_valkyrieTopUi.GetComponent<EnemyTargetSight>();
			m_valkyrieTopAnimator = m_valkyrieTopUi.GetComponent<Animator>();
			m_valkyrieTopUi.transform.SetParent(anchorRoots[0].transform, false);

			GameObject ts = RhythmGameInstantiatePrefab(m_targetSightPrefab);
			ts.transform.SetParent(anchorRoots[1].transform, false);
			m_targetSightMark = ts.GetComponent<Animator>();

			m_battleEvaluatePool.Initialize(!m_is2dMode && !m_isValkyrieOff ? anchorRoots[1] : anchorRoots[0], m_battleEvaluatePrefab, m_isValkyrieOff);
			m_battleEvaluatePool.RootObject.SetActive(false);
			m_enemyStatus.Initialize(pilotId == 2 || pilotId == 12, false);
			m_targetSight.Initialize();
			m_valkyrieBottomUi.SetActive(false);
			m_valkyrieCenterUi.SetActive(false);
			m_valkyrieTopUi.SetActive(false);
			m_targetSightMark.gameObject.SetActive(false);
			m_faceCutin = GetComponents<FaceCutin>();
			m_faceCutin[0].Initialize(anchorRoots[3], 0);
			m_faceCutin[1].Initialize(anchorRoots[4], m_is2dMode ? 1 : 0);

			GameObject us = RhythmGameInstantiatePrefab(m_userStateObject);
			us.transform.SetParent(anchorRoots[1].transform, false);
			Animator[] ans = us.GetComponentsInChildren<Animator>(true);
			m_lifeWarningEffect = ans[0];
			m_lifeRecoveryEffect = ans[1];
			m_divaModeEffect = ans[2];
			m_lifeWarningEffect.Play(damage_OUT_Hash, 0, 1);
			m_lifeRecoveryEffect.Play(recovery_OUT_Hash, 0, 1);
			m_divaModeEffect.Play(cut_wait_Hash, 0, 0);

			m_divaBottomUi = RhythmGameInstantiatePrefab(RhythmGameConsts.IsWideLine() ? divaBottomWidePrefab : divaBottomPrefab);
			m_divaBottomUiAnimator = m_divaBottomUi.GetComponent<Animator>();
			m_divaBottomUi.transform.SetParent(anchorRoots[2].transform, false);
			m_divaBottomUi.SetActive(false);

			if(!m_is2dMode)
			{
				m_divaTopUi = RhythmGameInstantiatePrefab(divaToptPrefab);
				m_divaTopUiAnimator = m_divaTopUi.GetComponent<Animator>();
				m_divaTopUi.transform.SetParent(anchorRoots[0].transform, false);
				m_divaTopUi.SetActive(false);

				GameObject dmo = RhythmGameInstantiatePrefab(divaModeBeltPrefab);
				dmo.transform.SetParent(anchorRoots[0].transform, false);
				m_divaModeBeltAnimator = dmo.GetComponent<Animator>();
				dmo.SetActive(false);
			}
			GameObject br = RhythmGameInstantiatePrefab(battleResultPrefab);
			br.transform.SetParent(anchorRoots[2].transform, false);
			m_battleResult = br.GetComponent<BattleResult>();

			if(music.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				m_battleResult.SetWarmup();
			}
			m_liveSkillCutin.Initialize();
			m_activeSkillCutin.Initialize();
			m_lifeGauge.Initialize();
			m_lifeGauge.SetValue(1, false);
			m_rankGauge.Initialize();
			m_rankGauge.SetValue(0);
			m_foldWaveGauge.Initialize();
			m_foldWaveGauge.SetValue(0, false, m_isLowSpec);
			m_foldWaveGauge.gameObject.SetActive(false);
			m_battleCombo.Initialize();
			m_pauseButton.SetOff();
			m_pauseButton.IsDisable = true;
			isReadyHUD = false;
			CurrentCombo = -1;
			CurrentBattleCombo = -1;
			SetCombo(0);
			m_touchCircleController.gameObject.SetActive(false);
			m_bottomGameObjectInstance.SetActive(true);
			GameManager.Instance.AddPushBackButtonHandler(OnPushBackButton);
			m_laneController.SetVisibility(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.NFMEIILKACN_NotesRoute == 0);
			if(GameManager.Instance.IsTutorial)
			{
				TodoLogger.Log(0, "Tutorial");
			}
		}

		// // RVA: 0xDCD404 Offset: 0xDCD404 VA: 0xDCD404
		public static GameObject RhythmGameInstantiatePrefab(UnityEngine.Object prefab)
		{
			GameObject obj = Instantiate<GameObject>(prefab as GameObject);;
			BundleShaderInfo.Instance.FixMaterialShader(obj); // UMO fix
			return obj;
		}

		// // RVA: 0xDCD510 Offset: 0xDCD510 VA: 0xDCD510
		public void OnDestroy()
		{
			GameManager.Instance.RemovePushBackButtonHandler(this.OnPushBackButton);
		}

		// // RVA: 0xDCD5EC Offset: 0xDCD5EC VA: 0xDCD5EC
		private void Update()
		{
			for(int i = 0; i < m_touchAreas.Length; i++)
			{
				if(m_touchAreas[i].collider != null)
				{
					if (!m_touchAreas[i].isSelected)
					{
						for (int fingerId = 0; fingerId < InputManager.fingerCount; fingerId++)
						{
							TouchInfoRecord touchInfo = InputManager.Instance.GetTouchInfoRecord(fingerId);
							if (touchInfo != null)
							{
								if (!touchInfo.currentInfo.isIllegal)
								{
									if (touchInfo.currentInfo.isBegan)
									{
										Vector3 worldPos = m_uiCamera.ScreenToWorldPoint(touchInfo.currentInfo.nativePosition);
										if (m_touchAreas[i].collider.OverlapPoint(worldPos))
										{
											m_touchAreas[i].isSelected = true;
											m_touchAreas[i].selectedFingerId = fingerId;
											m_touchAreas[i].pusheEvent.Invoke();
											break;
										}
									}
								}
							}
						}
					}
					else
					{
						TouchInfoRecord infoRecord = InputManager.Instance.GetTouchInfoRecord(m_touchAreas[i].selectedFingerId);
						if (infoRecord.currentInfo.isEnded)
						{
							Vector3 worldPos = m_uiCamera.ScreenToWorldPoint(infoRecord.currentInfo.nativePosition);
							if (m_touchAreas[i].collider.OverlapPoint(worldPos))
							{
								if (m_touchAreas[i].selectedEvent != null)
									m_touchAreas[i].selectedEvent.Invoke();
							}
							else
							{
								if (m_touchAreas[i].exitEvent != null)
									m_touchAreas[i].exitEvent.Invoke();
							}
							m_touchAreas[i].isSelected = false;
						}
					}
				}
			}
		}

		// // RVA: 0xDCD5F0 Offset: 0xDCD5F0 VA: 0xDCD5F0
		// private void UpdateInput() { }

		// // RVA: 0xDCDCEC Offset: 0xDCDCEC VA: 0xDCDCEC Slot: 18
		public void SetPlayerSideTexture(UiPilotTexture pilotTexture, UiDivaTexture divaTexture)
		{
			m_PilotTexture = pilotTexture;
			m_DivaTexture = divaTexture;
		}

		// // RVA: 0xDCDCF8 Offset: 0xDCDCF8 VA: 0xDCDCF8 Slot: 19
		public void SetEnemySideTexture(UiEnemyPilotTexture pilotTexture, UiEnemyRobotTexture robotTexture)
		{
			m_EnemyPilotTexture = pilotTexture;
			m_EnemyRobotTexture = robotTexture;
		}

		// // RVA: 0xDCDD04 Offset: 0xDCDD04 VA: 0xDCDD04 Slot: 20
		public void SetEnemyLiveSkillEffect(GameObject effPrefab)
		{
			GameObject o = RhythmGameInstantiatePrefab(effPrefab);
			o.transform.SetParent(anchorRoots[2].transform, false);
			o.SetActive(false);
			m_permanencyEnemySkillList.Add(new EnemySkillEffect() { effectType = SkillBuffEffect.Type.Poison, bitUseFlag = 0, effectAnimator = o.GetComponent<Animator>() });
		}

		// // RVA: 0xDCDF18 Offset: 0xDCDF18 VA: 0xDCDF18 Slot: 21
		public void SetPoisonSkillEffect(int a_bit, bool a_enable)
		{
			for(int i = 0; i < m_permanencyEnemySkillList.Count; i++)
			{
				if(m_permanencyEnemySkillList[i].effectType == SkillBuffEffect.Type.Poison)
				{
					uint oldValue = m_permanencyEnemySkillList[i].bitUseFlag;
					if (a_enable)
						m_permanencyEnemySkillList[i].bitUseFlag |= (byte)(1 << a_bit);
					else
						m_permanencyEnemySkillList[i].bitUseFlag &= (byte)~(1 << a_bit);
					if((oldValue != 0) != (m_permanencyEnemySkillList[i].bitUseFlag != 0))
					{
						m_permanencyEnemySkillList[i].effectAnimator.gameObject.SetActive(m_permanencyEnemySkillList[i].bitUseFlag != 0);
						if(m_permanencyEnemySkillList[i].effectType == SkillBuffEffect.Type.Poison && isReadyHUD)
						{
							m_permanencyEnemySkillList[i].effectAnimator.Play(poison_loop_Hash);
						}
					}
				}
			}
		}

		// // RVA: 0xDCE0E4 Offset: 0xDCE0E4 VA: 0xDCE0E4 Slot: 22
		public void Show(Action endAction)
		{
			m_bottomGameObjectInstance.SetActive(false);
			m_foldWaveGauge.gameObject.SetActive(true);
			m_touchCircleController.gameObject.SetActive(true);
			m_foldWaveGauge.ShowGauge();
			m_activeSkillButton.Disable();
			for(int i = 0; i < m_permanencyEnemySkillList.Count; i++)
			{
				if(m_permanencyEnemySkillList[i].effectType == SkillBuffEffect.Type.Poison)
				{
					if((m_permanencyEnemySkillList[i].bitUseFlag & 1) != 0)
					{
						m_permanencyEnemySkillList[i].effectAnimator.gameObject.SetActive(true);
					}
				}
			}
			this.StartCoroutineWatched(WaitEnterAnimeCoroutine(endAction));
		}

		// // RVA: 0xDCE44C Offset: 0xDCE44C VA: 0xDCE44C Slot: 23
		// public void Reset() { }

		// // RVA: 0xDCE89C Offset: 0xDCE89C VA: 0xDCE89C Slot: 24
		// public void PauseButtonClick() { }

		// // RVA: 0xDCE918 Offset: 0xDCE918 VA: 0xDCE918 Slot: 25
		public void ChangeHpGaugeFrame(int percent)
		{
			m_lifeGauge.SetValue(percent / 100.0f, false);
			if(m_prevLife != percent)
			{
				if(m_prevLife < percent)
				{
					if(!m_isContinue)
					{
						if(m_lifeRecoveryEffect.GetCurrentAnimatorStateInfo(0).shortNameHash == recovery_OUT_Hash && 
							m_lifeRecoveryEffect.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
						{
							m_lifeRecoveryEffect.Play(recovery_IN_Hash);
							m_lifeRecoveryEffect.SetBool(LoopEnd_Hash, false);
						}
						if(WaitRecoveryFunc != null)
						{
							this.StopCoroutineWatched(WaitRecoveryFunc);
						}
						WaitRecoveryFunc = WaitRecoveryCoroutine();
						this.StartCoroutineWatched(WaitRecoveryFunc);
					}
				}
				if(!m_isContinue)
				{
					if(percent < 31)
					{
						if(m_lifeWarningEffect.GetBool(LoopEnd_Hash) || 
							m_lifeWarningEffect.GetCurrentAnimatorStateInfo(0).shortNameHash == damage_OUT_Hash)
						{
							m_lifeWarningEffect.Play(damage_IN_Hash);
							m_lifeWarningEffect.SetBool(LoopEnd_Hash, false);
							m_prevLife = percent;
							return;
						}
					}
					m_lifeWarningEffect.SetBool(LoopEnd_Hash, true);
				}
			}
			if(percent == 100 && m_isContinue)
				m_isContinue = false;
			m_prevLife = percent;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x74422C Offset: 0x74422C VA: 0x74422C
		// // RVA: 0xDCEBF8 Offset: 0xDCEBF8 VA: 0xDCEBF8
		private IEnumerator WaitRecoveryCoroutine()
		{
			//0x9A28FC
			yield return null;
			m_lifeRecoveryEffect.SetBool(LoopEnd_Hash, true);
		}

		// // RVA: 0xDCEC80 Offset: 0xDCEC80 VA: 0xDCEC80 Slot: 26
		// public void SetContinue() { }

		// // RVA: 0xDCECD8 Offset: 0xDCECD8 VA: 0xDCECD8 Slot: 27
		public void ChangeRankGaugeFrame(ResultScoreRank.Type rankType, float ratio)
		{
			float val = 1;
			if(rankType != ResultScoreRank.Type.SS)
			{
				val = ResultScoreRankAngleTbl[(int)rankType] + (ResultScoreRankAngleTbl[(int)rankType + 1] - ResultScoreRankAngleTbl[(int)rankType]) * ratio;
			}
			m_rankGauge.SetRunk(rankType);
			m_rankGauge.SetValue(val);
		}

		// // RVA: 0xDCEDD4 Offset: 0xDCEDD4 VA: 0xDCEDD4 Slot: 28
		public void ChangeScore(int score, int type)
		{
			m_score.SetValue(score, type);
		}

		// // RVA: 0xDCE840 Offset: 0xDCE840 VA: 0xDCE840 Slot: 29
		public void SetFoldWaveGaugeValue(int value)
		{
			m_foldWaveGauge.SetValue(value, false, m_isLowSpec);
		}

		// // RVA: 0xDCEE10 Offset: 0xDCEE10 VA: 0xDCEE10 Slot: 30
		// public void HideFoldWaveGauge() { }

		// // RVA: 0xDCE894 Offset: 0xDCE894 VA: 0xDCE894 Slot: 31
		// public void UpdateCombo() { }

		// // RVA: 0xDCD4C0 Offset: 0xDCD4C0 VA: 0xDCD4C0 Slot: 32
		public void SetCombo(int combo)
		{
			if(combo > 999)
				combo = 999;
			if(CurrentCombo == combo)
				return;
			CurrentCombo = combo;
			m_combo.SetValue(combo, 0);
		}

		// // RVA: 0xDCEE3C Offset: 0xDCEE3C VA: 0xDCEE3C Slot: 33
		public void SetBattleCombo(int combo)
		{
			if(CurrentBattleCombo == combo)
				return;
			CurrentBattleCombo = combo;
			bool max = m_battleCombo.UpdateCombo(combo);
			m_mainGaugeAnimator.SetBool(MainGaugeIsMaxParamHash, max);
			m_valkyrieCenterEffectAnimator.SetComboMax(max);
		}

		// // RVA: 0xDCEF54 Offset: 0xDCEF54 VA: 0xDCEF54 Slot: 34
		public void SetItemCount(int kind, int count)
		{
			m_item.SetValue(kind == 0 ? 1 : 0, count);
		}

		// // RVA: 0xDCEF98 Offset: 0xDCEF98 VA: 0xDCEF98 Slot: 35
		public void ShowLowEnergy()
		{
			if(!GameManager.Instance.IsTutorial)
			{
				m_lowEnergyAnimator.Play(OUT_Hash, 0, 0);
			}
			m_foldWaveGauge.Faild();
		}

		// // RVA: 0xDCF09C Offset: 0xDCF09C VA: 0xDCF09C Slot: 36
		public void ShowValkyrie()
		{
			m_valkyrieTopUi.SetActive(true);
			m_valkyrieCenterUi.SetActive(true);
			m_valkyrieCenterEffectAnimator.Show();
			m_valkyrieBottomUi.SetActive(true);
			m_mainGaugeAnimator.SetTrigger(MainGaugeGoBattleParamHash);
			m_mainGaugeAnimator.SetBool(MainGaugeIsMaxParamHash, false);
			m_foldWaveGauge.Success(m_isValkyrieOff);
			m_enemyStatus.Show();
			m_battleCombo.Show();
			m_battleTimeCount.gameObject.SetActive(true);
			m_battleTimeCount.Show();
			m_battleEvaluatePool.RootObject.SetActive(false);
			m_currentEnemyDmageIndex = EnemyFrameColorAnimeStateHash.Length - 1;
			SetCombo(CurrentCombo);
		}

		// // RVA: 0xDCF36C Offset: 0xDCF36C VA: 0xDCF36C Slot: 37
		public void ShowEnemyStatus()
		{
			m_enemyStatus.SetEnemyRobotTexture("enemy01_model", m_EnemyRobotTexture);
			m_enemyStatus.ShowEnemyIcon();
			m_targetSightMark.gameObject.SetActive(false);
		}

		// // RVA: 0xDCF454 Offset: 0xDCF454 VA: 0xDCF454 Slot: 38
		public void ShowTargetSight()
		{
			if(!m_is2dMode && !m_isValkyrieOff)
			{
				m_targetSight.Show();
				m_targetSightMark.gameObject.SetActive(true);
				m_targetSightMark.Play(target_site_IN_Hash, 0, 0);
			}
		}

		// // RVA: 0xDCF51C Offset: 0xDCF51C VA: 0xDCF51C Slot: 39
		public void ShowHitResult()
		{
			m_battleEvaluatePool.RootObject.SetActive(true);
		}

		// // RVA: 0xDCF5B8 Offset: 0xDCF5B8 VA: 0xDCF5B8 Slot: 40
		public void EnemyDamageResult(int result, Vector3 position)
		{
			if(m_battleEvaluatePool.RootObject.activeSelf)
			{
				BattleEvaluateObject o = m_battleEvaluatePool.Alloc();
				if(o != null)
				{
					o.gameObject.SetActive(true);
					o.Play(result);
					Vector3 v;
					if (m_isValkyrieOff)
					{
						if(!m_is2dMode)
						{
							v = AdjustUiCameraPosition(position);
						}
						else
						{
							v = m_valkyrieTopAnimator.transform.localPosition;
							v += new Vector3(74, -206, 0);
						}
					}
					else
					{
						v = m_valkyrieTopAnimator.transform.localPosition + new Vector3(400, -130, 0);
					}
					o.transform.localPosition = v;
					this.StartCoroutineWatched(WaitDamgeResultAnimeCoroutine(o));
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7442A4 Offset: 0x7442A4 VA: 0x7442A4
		// // RVA: 0xDCFAEC Offset: 0xDCFAEC VA: 0xDCFAEC
		private IEnumerator WaitDamgeResultAnimeCoroutine(BattleEvaluateObject obj)
		{
			//0x9A2448
			while (obj.IsPlaying())
				yield return null;
			obj.Free();
			obj.gameObject.SetActive(false);
		}

		// // RVA: 0xDCFB74 Offset: 0xDCFB74 VA: 0xDCFB74 Slot: 41
		public void UpdateTargetPosition(Vector3 position)
		{
			if(!m_is2dMode && !m_isValkyrieOff)
			{
				m_targetSight.UpdateTargetPosition(new Vector3(m_cameraRectTransform.sizeDelta.x * position.x * 0.5f, m_cameraRectTransform.sizeDelta.y * position.y * 0.5f - m_cameraRectTransform.sizeDelta.y * 0.5f, 0));
				m_targetSightMark.transform.localPosition = AdjustUiCameraPosition(position);
			}
		}

		// // RVA: 0xDCF9D0 Offset: 0xDCF9D0 VA: 0xDCF9D0
		private Vector3 AdjustUiCameraPosition(Vector3 normalizePosition)
		{
			return new Vector3(normalizePosition.x * m_cameraRectTransform.sizeDelta.x * 0.5f, normalizePosition.y * m_cameraRectTransform.sizeDelta.y * 0.5f, 0);
		}

		// // RVA: 0xDCFD7C Offset: 0xDCFD7C VA: 0xDCFD7C Slot: 42
		public void HideValkyrie(bool isFaild = false)
		{
			if(isFaild)
			{
				this.StartCoroutineWatched(FaildValkyrieCoroutine());
			}
			else
			{
				m_valkyrieTopUi.SetActive(false);
				m_valkyrieCenterUi.SetActive(false);
				m_targetSightMark.gameObject.SetActive(false);
				if(isEnableCutin)
				{
					m_faceCutin[0].Play(0);
				}
				m_valkyeriBottomEffectController.Play("Success_IN");
				m_mainGaugeAnimator.SetBool(MainGaugeIsMaxParamHash, true);
				m_battleCombo.Hide(false);
			}
			m_battleEvaluatePool.RootObject.SetActive(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x74431C Offset: 0x74431C VA: 0x74431C
		// // RVA: 0xDCFFEC Offset: 0xDCFFEC VA: 0xDCFFEC
		private IEnumerator FaildValkyrieCoroutine()
		{
			//0x9A1EA0
			m_valkyrieCenterEffectAnimator.TargetLost();
			if(isEnableCutin)
			{
				m_faceCutin[0].Play(1);
			}
			ChangeFaildEnemyStatus();
			m_targetSight.Hide();
			m_targetSightMark.Play(target_site_OUT_Hash, 0, 0);
			yield return null;
			while (m_valkyrieCenterEffectAnimator.IsPlayingTargetLost())
				yield return null;
			m_valkyrieCenterEffectAnimator.Hide();
			m_valkyeriBottomEffectController.Play("Faild");
			m_battleCombo.Hide(true);
			m_valkyrieTopAnimator.Play(C_top_UI_B_OUT_HASH, 0, 0);
			yield return null;
			while (m_valkyeriBottomEffectController.IsPlaying("Faild"))
				yield return null;
			m_valkyrieTopAnimator.gameObject.SetActive(false);
			m_valkyrieCenterEffectAnimator.gameObject.SetActive(false);
			m_valkyeriBottomEffectController.gameObject.SetActive(false);
			m_valkyrieTimer.SetActive(false);
			m_targetSight.gameObject.SetActive(false);
			m_targetSightMark.gameObject.SetActive(false);
			m_mainGaugeAnimator.SetBool(MainGaugeIsMaxParamHash, true);
		}

		// // RVA: 0xDD0074 Offset: 0xDD0074 VA: 0xDD0074 Slot: 43
		public void ShowPilotCutin()
		{
			if (!isEnableCutin)
				return;
			m_faceCutin[0].SetTexture("alt", m_PilotTexture);
			m_faceCutin[0].Play(0);
		}

		// // RVA: 0xDD0188 Offset: 0xDD0188 VA: 0xDD0188 Slot: 44
		public void ShowDivaCutin()
		{
			if (!isEnableCutin)
				return;
			m_faceCutin[0].SetTexture("alt", m_DivaTexture);
			m_faceCutin[0].Play(0);
		}

		// // RVA: 0xDD029C Offset: 0xDD029C VA: 0xDD029C Slot: 45
		public void ShowDiva(bool isSpMode = false)
		{
			m_divaBottomUi.SetActive(true);
			m_divaBottomUiAnimator.Play(isSpMode ? change_SPdiva_mode : change_diva_mode_Hash, 0, 0);
			m_touchCircleController.Play(diva_button_ON_Hash, 0);
			m_valkyeriBottomEffectController.gameObject.SetActive(false);
			if(!GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OOCKIFIHJJN_Is2DMode)
			{
				m_divaTopUi.SetActive(true);
				m_divaTopUiAnimator.Play(isSpMode ? change_SPdiva_mode : change_diva_mode_Hash, 0, 0);
				m_divaModeBeltAnimator.gameObject.SetActive(true);
				m_divaModeBeltAnimator.SetBool(DivaModeSwitchSpModeAnimatorParam, isSpMode);
				m_divaModeBeltAnimator.SetBool(DivaModeSwitchNormalModeAnimatorParam, !isSpMode);
			}
			if(!m_is2dMode)
			{
				m_divaModeEffect.Play(isSpMode ? cut_IN_SP_Hash : cut_IN_Hash, 0, 0);
			}
		}

		// // RVA: 0xDD0608 Offset: 0xDD0608 VA: 0xDD0608 Slot: 46
		public void EntryLiveSkillCutin(LiveSkill liveSkill, Material skillDescription, Material divaIconMaterial)
		{
			m_liveSkillCutin.Show(liveSkill, divaIconMaterial, skillDescription);
		}

		// // RVA: 0xDD0658 Offset: 0xDD0658 VA: 0xDD0658 Slot: 47
		public void ShowLiveSkillCutin()
		{
			m_liveSkillCutin.Show();
		}

		// // RVA: 0xDD0684 Offset: 0xDD0684 VA: 0xDD0684 Slot: 48
		public void ShowActiveSkillCutin(string skillname, RhythmGameResource.UITextureResource textureResource)
		{
			m_activeSkillCutin.Show(skillname, textureResource, null);
		}

		// // RVA: 0xDD06D0 Offset: 0xDD06D0 VA: 0xDD06D0 Slot: 49
		public void CloseSkillCutin()
		{
			m_liveSkillCutin.Close(null);
			m_activeSkillCutin.Close(null);
		}

		// // RVA: 0xDD0728 Offset: 0xDD0728 VA: 0xDD0728 Slot: 50
		public void EndAcceptOfInput()
		{
			m_pauseButton.IsDisable = true;
			m_activeSkillButton.Disable();
		}

		// // RVA: 0xDD077C Offset: 0xDD077C VA: 0xDD077C Slot: 51
		public bool IsInputAccept()
		{
			return !m_pauseButton.IsDisable;
		}

		// // RVA: 0xDD07AC Offset: 0xDD07AC VA: 0xDD07AC Slot: 52
		public void ShowTouchEffect(int trackId, int fingerId)
		{
			if (m_touchEffects[trackId].FingerId > -1)
				return;
			m_touchEffects[trackId].touchEffect.Play(UI_rhythm_Push_IN_HashCode, 0);
			m_touchEffects[trackId].FingerId = fingerId;
		}

		// // RVA: 0xDD08F8 Offset: 0xDD08F8 VA: 0xDD08F8 Slot: 53
		public void HideToucheEffect(int trackId, int fingerId)
		{
			if (trackId < 0)
				return;
			if (m_touchEffects[trackId].FingerId != fingerId)
				return;
			m_touchEffects[trackId].touchEffect.Play(UI_rhythm_Push_OUT_HashCode, 0);
			m_touchEffects[trackId].FingerId = -1;
		}

		// // RVA: 0xDD0A50 Offset: 0xDD0A50 VA: 0xDD0A50 Slot: 54
		public void HideAllToucheEffect()
		{
			for(int i = 0; i < m_touchEffects.Length; i++)
			{
				if(m_touchEffects[i].FingerId > -1)
				{
					m_touchEffects[i].touchEffect.Play(UI_rhythm_Push_OUT_HashCode, 0);
					m_touchEffects[i].FingerId = -1;
				}
			}
		}

		// // RVA: 0xDD0BB8 Offset: 0xDD0BB8 VA: 0xDD0BB8 Slot: 55
		public void ShowLongNotesTouchEffect(int trackId)
		{
			m_touchEffects[trackId].touchEffect.Play(UI_rhythm_Long_IN_HashCode, 0);
			m_touchEffects[trackId].touchEffect.Play(UI_rhythm_Long_Loop_HashCode, 0);
		}

		// // RVA: 0xDD0CCC Offset: 0xDD0CCC VA: 0xDD0CCC Slot: 56
		public void HideLongNotesTouchEffect(int trackId)
		{
			if (!m_touchEffects[trackId].touchEffect.IsSameState(UI_rhythm_Long_Loop_HashCode))
				return;
			m_touchEffects[trackId].touchEffect.Play(UI_rhythm_Long_OUT_HashCode, 0);
		}

		// // RVA: 0xDD0DE4 Offset: 0xDD0DE4 VA: 0xDD0DE4 Slot: 57
		public void ShowSlideNotesTouchEffect(int trackId)
		{
			m_touchEffects[trackId].slideEffect.Show();
		}

		// // RVA: 0xDD0E68 Offset: 0xDD0E68 VA: 0xDD0E68 Slot: 58
		public void HideSlideNotesTouchEffect(int trackId)
		{
			m_touchEffects[trackId].slideEffect.Hide();
		}

		// // RVA: 0xDD0EEC Offset: 0xDD0EEC VA: 0xDD0EEC Slot: 59
		public void ShowSlideNotesTipEffect(int trackId, RNoteSlide noteSlide)
		{
			m_touchEffects[trackId].slideTipEffect.Show(noteSlide);
		}

		// // RVA: 0xDD0F78 Offset: 0xDD0F78 VA: 0xDD0F78 Slot: 60
		public void HideSlideNotesTipEffect(int trackId)
		{
			m_touchEffects[trackId].slideTipEffect.Hide();
		}

		// // RVA: 0xDD0FFC Offset: 0xDD0FFC VA: 0xDD0FFC Slot: 61
		public void ShowWingNotesOpenREffect(int trackId)
		{
			m_touchEffects[trackId].slideEffect.ShowWingOpenR();
		}

		// // RVA: 0xDD1080 Offset: 0xDD1080 VA: 0xDD1080 Slot: 62
		public void ShowWingNotesOpenLEffect(int trackId)
		{
			m_touchEffects[trackId].slideEffect.ShowWingOpenL();
		}

		// // RVA: 0xDD1104 Offset: 0xDD1104 VA: 0xDD1104 Slot: 63
		public void ShowWingNotesCloseREffect(int trackId)
		{
			m_touchEffects[trackId].slideEffect.ShowWingCloseR();
		}

		// // RVA: 0xDD1188 Offset: 0xDD1188 VA: 0xDD1188 Slot: 64
		public void ShowWingNotesCloseLEffect(int trackId)
		{
			m_touchEffects[trackId].slideEffect.ShowWingCloseL();
		}

		// // RVA: 0xDD120C Offset: 0xDD120C VA: 0xDD120C Slot: 65
		public void ShowNotesHitEffect(int trackId)
		{
			m_touchEffects[trackId].touchEffect.Play(UI_rhythm_Delete_HashCode, 0);
		}

		// // RVA: 0xDD12A0 Offset: 0xDD12A0 VA: 0xDD12A0 Slot: 66
		public void ShowResultEffect(int lineNumber, RhythmGameConsts.NoteResultEx a_result_ex)
		{
			int idx = (int)a_result_ex.m_result;
			if(a_result_ex.m_excellent)
			{
				if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.EDDMJEMOAGM_IsNotExcellentDisplaySetting)
					idx = 5;
			}
			if(m_touchEffects[lineNumber].RandomRotate != null)
			{
				m_touchEffects[lineNumber].RandomRotate.Do();
			}
			if(m_touchEffects[lineNumber].resultEffectSimple != null)
			{
				m_touchEffects[lineNumber].resultEffectSimple.Play(ResultAnimationStateTable[idx], 0);
			}
			if(a_result_ex.m_result > RhythmGameConsts.NoteResult.Bad)
			{
				if(!m_isLowSpec)
				{
					m_foldWaveGauge.GaugeFlash();
				}
				m_foldWaveGauge.ShowEffect((int)a_result_ex.m_result);
			}
		}

		// // RVA: 0xDD17BC Offset: 0xDD17BC VA: 0xDD17BC Slot: 67
		public void OnSkillEffect(int lineNumber, int effectType, bool isTopPriority)
		{
			m_touchEffects[lineNumber].SkillEffect.OnSkillBit(effectType, isTopPriority);
		}

		// // RVA: 0xDD1850 Offset: 0xDD1850 VA: 0xDD1850 Slot: 68
		public void OffSkillEffect(int lineNumber, int effectType)
		{
			m_touchEffects[lineNumber].SkillEffect.OffSkillBit(effectType);
		}

		// // RVA: 0xDD18DC Offset: 0xDD18DC VA: 0xDD18DC Slot: 69
		public void OffTopPrioritySkillEffect(int lineNumber, int effectType)
		{
			m_touchEffects[lineNumber].SkillEffect.OffTopPrioritySkillBit(effectType);
		}

		// // RVA: 0xDD1968 Offset: 0xDD1968 VA: 0xDD1968 Slot: 70
		// public void DrawSkillEffectEnable(int lineNumber, bool flag) { }

		// // RVA: 0xDD19F4 Offset: 0xDD19F4 VA: 0xDD19F4 Slot: 71
		public bool IsEnableActiveSkillButton()
		{
			return m_activeSkillButton.IsEnable;
		}

		// // RVA: 0xDD1A20 Offset: 0xDD1A20 VA: 0xDD1A20 Slot: 72
		public void DecideActiveSkillButton(SkillDuration.Type duration)
		{
			m_activeSkillButton.SetDecide(duration);
		}

		// // RVA: 0xDD1A54 Offset: 0xDD1A54 VA: 0xDD1A54
		private void ApplyActiveSkillButtonUv()
		{
			if(Database.Instance.gameSetup.teamInfo.divaList != null)
			{
				if(Database.Instance.gameSetup.teamInfo.divaList[0] != null)
				{
					if(Database.Instance.gameSetup.teamInfo.divaList[0].activeSkillId < 1)
						return;
					m_activeSkillButton.ApplySkillUv(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[Database.Instance.gameSetup.teamInfo.divaList[0].activeSkillId - 1].EGLDFPILJLG_BuffEffectType[0]);
				}
			}
		}

		// // RVA: 0xDD1DB4 Offset: 0xDD1DB4 VA: 0xDD1DB4 Slot: 73
		public void EnableActiveSkillButton()
		{
			if(Database.Instance.gameSetup.teamInfo.divaList != null)
			{
				if(Database.Instance.gameSetup.teamInfo.divaList[0] != null)
				{
					if(Database.Instance.gameSetup.teamInfo.divaList[0].activeSkillId < 1)
						return;
					m_activeSkillButton.Enable();
				}
			}
		}

		// // RVA: 0xDD1FEC Offset: 0xDD1FEC VA: 0xDD1FEC Slot: 74
		public void DisableActiveSkillButton()
		{
			m_activeSkillButton.Disable();
		}

		// // RVA: 0xDD2018 Offset: 0xDD2018 VA: 0xDD2018 Slot: 75
		public void EndActiveSkill()
		{
			m_activeSkillButton.End();
		}

		// // RVA: 0xDD2044 Offset: 0xDD2044 VA: 0xDD2044 Slot: 76
		public void RestartActiveSkillButton()
		{
			m_activeSkillButton.Restart();
		}

		// // RVA: 0xDD2070 Offset: 0xDD2070 VA: 0xDD2070 Slot: 77
		public bool IsActiveSkillButtonAcEnd()
		{
			return m_activeSkillButton.IsStateAcEnd();
		}

		// // RVA: 0xDD209C Offset: 0xDD209C VA: 0xDD209C Slot: 78
		public bool IsActiveSkillButtonAcOn()
		{
			return m_activeSkillButton.IsStateAcOn();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x744394 Offset: 0x744394 VA: 0x744394
		// // RVA: 0xDCE3A8 Offset: 0xDCE3A8 VA: 0xDCE3A8
		private IEnumerator WaitEnterAnimeCoroutine(Action end)
		{
			Animator animator;

			//0x9A25DC
			animator = m_bottomGameObjectInstance.GetComponent<Animator>();
			animator.SetTrigger(GameStartUiTrigger);
			ApplyActiveSkillButtonUv();
			yield return null;
			while(animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
				yield return null;
			EnableActiveSkillButton();
			m_pauseButton.IsDisable = false;
			isReadyHUD = true;
			if(end != null)
				end();
		}

		// // RVA: 0xDD20C8 Offset: 0xDD20C8 VA: 0xDD20C8
		private void OnPushBackButton()
		{
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.OAKOJGPBAJF_BackKey > 0)
				return;
			OnPauseButtonSelected(false);
		}

		// // RVA: 0xDD22C4 Offset: 0xDD22C4 VA: 0xDD22C4
		// public void OnPauseButtonSelected() { }

		// // RVA: 0xDD21C8 Offset: 0xDD21C8 VA: 0xDD21C8 Slot: 79
		public void OnPauseButtonSelected(bool a_suspend)
		{
			if (m_pauseButton.IsOn)
				return;
			if (m_pauseButton.IsDisable)
				return;
			m_pauseButton.SetOn();
			m_pauseButtonEvent.Invoke(a_suspend);
			HideAllToucheEffect();
		}

		// // RVA: 0xDD22CC Offset: 0xDD22CC VA: 0xDD22CC Slot: 80
		public void ClearPauseButton()
		{
			m_pauseButton.SetOff();
		}

		// // RVA: 0xDD22F8 Offset: 0xDD22F8 VA: 0xDD22F8 Slot: 81
		public void DisablePauseButton()
		{
			m_pauseButton.SetDisable();
		}

		// // RVA: 0xDD2324 Offset: 0xDD2324 VA: 0xDD2324 Slot: 82
		public void EnablePauseButton()
		{
			m_pauseButton.SetEnable();
		}

		// // RVA: 0xDD2360 Offset: 0xDD2360 VA: 0xDD2360 Slot: 83
		public void UpdateBattleLimitTime(int ms)
		{
			if (!isBattleLimitTimeRunning)
				return;
			m_battleTimeCount.UpdateTime(ms);
		}

		// // RVA: 0xDD23A0 Offset: 0xDD23A0 VA: 0xDD23A0 Slot: 84
		// public void UpdateEnemyFrameColor(int damage, int threshold1, int threshold2) { }

		// // RVA: 0xDD23A4 Offset: 0xDD23A4 VA: 0xDD23A4 Slot: 85
		public void UpdateEnemyStatus(int damage, int threshold1, int threshold2, UnityAction onChaseModeCallback)
		{
			m_enemyStatus.UpdateEnemyLifeGauge(damage, threshold1, m_isLowSpec);
			m_enemyStatus.TryChaseMode(damage, threshold1, m_isLowSpec, onChaseModeCallback);
			if (!m_enemyStatus.IsChaseMode)
				return;
			m_battleTimeCount.Finish();
		}

		// // RVA: 0xDD248C Offset: 0xDD248C VA: 0xDD248C Slot: 86
		public void ChangeEnemyLife(EnemyStatus.LifeType a_type)
		{
			m_enemyStatus.SetupLifeType(a_type);
		}

		// // RVA: 0xDD24C0 Offset: 0xDD24C0 VA: 0xDD24C0 Slot: 87
		public void ChangeFaildEnemyStatus()
		{
			m_enemyStatus.ChangeFaild(EnemyFaildFrameColorAnimeStateHash[EnemyFaildFrameColorAnimeStateHash.Length - 1]);
		}

		// // RVA: 0xDD2534 Offset: 0xDD2534 VA: 0xDD2534 Slot: 88
		public void ShowEnemyCutin()
		{
			if (!isEnableCutin)
				return;
			m_faceCutin[1].SetTexture("vajura", m_EnemyPilotTexture);
			m_faceCutin[1].Play(0);
		}

		// // RVA: 0xDCD3E4 Offset: 0xDCD3E4 VA: 0xDCD3E4
		public static bool IsNotKillEnemyPilot(int pilotId)
		{
			if (pilotId != 2)
				return pilotId == 12;
			return true;
		}

		// // RVA: 0xDD2648 Offset: 0xDD2648 VA: 0xDD2648 Slot: 89
		public void SetPlayerDivaId(int divaId)
		{
			m_battleResult.SetPlayerDivaId(divaId);
		}

		// // RVA: 0xDD267C Offset: 0xDD267C VA: 0xDD267C Slot: 90
		// public void SetRivalDivaId(int divaId) { }

		// // RVA: 0xDD26B0 Offset: 0xDD26B0 VA: 0xDD26B0 Slot: 91
		// public void ShowBattleResult(bool isPlayerWin) { }

		// // RVA: 0xDD26E4 Offset: 0xDD26E4 VA: 0xDD26E4 Slot: 92
		public bool IsWarmupEnd()
		{
			return !m_battleResult.IsWaitWarmup;
		}

		// // RVA: 0xDD2714 Offset: 0xDD2714 VA: 0xDD2714 Slot: 93
		public void SetLineAlpha(int lineNo, float alpha)
		{
			m_laneController.SetLineAlpha(lineNo, alpha);
		}

		// // RVA: 0xDD2750 Offset: 0xDD2750 VA: 0xDD2750 Slot: 94
		public bool IsActiveLine(int lineNo)
		{
			return m_laneController.IsActiveLine(lineNo);
		}
	}
}
