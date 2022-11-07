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
		// private readonly int UI_rhythm_Push_IN_HashCode = "UI_rhythm_Push_IN"; // 0x154
		// private readonly int UI_rhythm_Push_OUT_HashCode = "UI_rhythm_Push_OUT"; // 0x158
		// private readonly int UI_rhythm_Long_IN_HashCode = "UI_rhythm_Long_IN"; // 0x15C
		// private readonly int UI_rhythm_Long_Loop_HashCode = "UI_rhythm_Long_Loop"; // 0x160
		// private readonly int UI_rhythm_Long_OUT_HashCode = "UI_rhythm_Long_OUT"; // 0x164
		// private readonly int UI_rhythm_Delete_HashCode = "UI_rhythm_Delete"; // 0x168
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
		// private readonly int[] ResultAnimationStateTable = new int[6] {
		// 	"Miss", "Bad", "Good", "Great", "Perfect", "Excellent"
		// }; // 0x1C0
		private readonly float[] TouchEffectZOffsetTbl = new float[6] { -2, -1, -1, -2, -3, -3 }; // 0x1C4
		private static readonly int DivaModeSwitchSpModeAnimatorParam = Animator.StringToHash("IsSpMode"); // 0x0
		private static readonly int DivaModeSwitchNormalModeAnimatorParam = Animator.StringToHash("IsSpMode"); // 0x4
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
			TodoLogger.Log(0, "Hud Initialize");
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
			TodoLogger.Log(0, "Hud SetPlayerSideTexture");
		}

		// // RVA: 0xDCDCF8 Offset: 0xDCDCF8 VA: 0xDCDCF8 Slot: 19
		public void SetEnemySideTexture(UiEnemyPilotTexture pilotTexture, UiEnemyRobotTexture robotTexture)
		{
			TodoLogger.Log(0, "Hud SetEnemySideTexture");
		}

		// // RVA: 0xDCDD04 Offset: 0xDCDD04 VA: 0xDCDD04 Slot: 20
		public void SetEnemyLiveSkillEffect(GameObject effPrefab)
		{
			TodoLogger.Log(0, "Hud SetEnemyLiveSkillEffect");
		}

		// // RVA: 0xDCDF18 Offset: 0xDCDF18 VA: 0xDCDF18 Slot: 21
		// public void SetPoisonSkillEffect(int a_bit, bool a_enable) { }

		// // RVA: 0xDCE0E4 Offset: 0xDCE0E4 VA: 0xDCE0E4 Slot: 22
		public void Show(Action endAction)
		{
			TodoLogger.Log(0, "Hud Show");
		}

		// // RVA: 0xDCE44C Offset: 0xDCE44C VA: 0xDCE44C Slot: 23
		// public void Reset() { }

		// // RVA: 0xDCE89C Offset: 0xDCE89C VA: 0xDCE89C Slot: 24
		// public void PauseButtonClick() { }

		// // RVA: 0xDCE918 Offset: 0xDCE918 VA: 0xDCE918 Slot: 25
		public void ChangeHpGaugeFrame(int percent)
		{
			TodoLogger.Log(0, "Hud ChangeHpGaugeFrame");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x74422C Offset: 0x74422C VA: 0x74422C
		// // RVA: 0xDCEBF8 Offset: 0xDCEBF8 VA: 0xDCEBF8
		// private IEnumerator WaitRecoveryCoroutine() { }

		// // RVA: 0xDCEC80 Offset: 0xDCEC80 VA: 0xDCEC80 Slot: 26
		// public void SetContinue() { }

		// // RVA: 0xDCECD8 Offset: 0xDCECD8 VA: 0xDCECD8 Slot: 27
		public void ChangeRankGaugeFrame(ResultScoreRank.Type rankType, float ratio)
		{
			TodoLogger.Log(0, "Hud ChangeRankGaugeFrame");
		}

		// // RVA: 0xDCEDD4 Offset: 0xDCEDD4 VA: 0xDCEDD4 Slot: 28
		public void ChangeScore(int score, int type)
		{
			TodoLogger.Log(0, "Hud ChangeScore");
		}

		// // RVA: 0xDCE840 Offset: 0xDCE840 VA: 0xDCE840 Slot: 29
		public void SetFoldWaveGaugeValue(int value)
		{
			TodoLogger.Log(0, "Hud SetFoldWaveGaugeValue");
		}

		// // RVA: 0xDCEE10 Offset: 0xDCEE10 VA: 0xDCEE10 Slot: 30
		// public void HideFoldWaveGauge() { }

		// // RVA: 0xDCE894 Offset: 0xDCE894 VA: 0xDCE894 Slot: 31
		// public void UpdateCombo() { }

		// // RVA: 0xDCD4C0 Offset: 0xDCD4C0 VA: 0xDCD4C0 Slot: 32
		public void SetCombo(int combo)
		{
			TodoLogger.Log(0, "Hud SetCombo");
		}

		// // RVA: 0xDCEE3C Offset: 0xDCEE3C VA: 0xDCEE3C Slot: 33
		public void SetBattleCombo(int combo)
		{
			TodoLogger.Log(0, "Hud SetBattleCombo");
		}

		// // RVA: 0xDCEF54 Offset: 0xDCEF54 VA: 0xDCEF54 Slot: 34
		public void SetItemCount(int kind, int count)
		{
			TodoLogger.Log(0, "Hud SetItemCount");
		}

		// // RVA: 0xDCEF98 Offset: 0xDCEF98 VA: 0xDCEF98 Slot: 35
		public void ShowLowEnergy()
		{
			TodoLogger.Log(0, "Hud ShowLowEnergy");
		}

		// // RVA: 0xDCF09C Offset: 0xDCF09C VA: 0xDCF09C Slot: 36
		public void ShowValkyrie()
		{
			TodoLogger.Log(0, "Hud ShowValkyrie");
		}

		// // RVA: 0xDCF36C Offset: 0xDCF36C VA: 0xDCF36C Slot: 37
		public void ShowEnemyStatus()
		{
			TodoLogger.Log(0, "Hud ShowEnemyStatus");
		}

		// // RVA: 0xDCF454 Offset: 0xDCF454 VA: 0xDCF454 Slot: 38
		public void ShowTargetSight()
		{
			TodoLogger.Log(0, "Hud ShowTargetSight");
		}

		// // RVA: 0xDCF51C Offset: 0xDCF51C VA: 0xDCF51C Slot: 39
		public void ShowHitResult()
		{
			TodoLogger.Log(0, "Hud ShowHitResult");
		}

		// // RVA: 0xDCF5B8 Offset: 0xDCF5B8 VA: 0xDCF5B8 Slot: 40
		public void EnemyDamageResult(int result, Vector3 position)
		{
			TodoLogger.Log(0, "Hud EnemyDamageResult");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7442A4 Offset: 0x7442A4 VA: 0x7442A4
		// // RVA: 0xDCFAEC Offset: 0xDCFAEC VA: 0xDCFAEC
		// private IEnumerator WaitDamgeResultAnimeCoroutine(BattleEvaluateObject obj) { }

		// // RVA: 0xDCFB74 Offset: 0xDCFB74 VA: 0xDCFB74 Slot: 41
		public void UpdateTargetPosition(Vector3 position)
		{
			TodoLogger.Log(0, "Hud UpdateTargetPosition");
		}

		// // RVA: 0xDCF9D0 Offset: 0xDCF9D0 VA: 0xDCF9D0
		// private Vector3 AdjustUiCameraPosition(Vector3 normalizePosition) { }

		// // RVA: 0xDCFD7C Offset: 0xDCFD7C VA: 0xDCFD7C Slot: 42
		public void HideValkyrie(bool isFaild = false)
		{
			TodoLogger.Log(0, "Hud HideValkyrie");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x74431C Offset: 0x74431C VA: 0x74431C
		// // RVA: 0xDCFFEC Offset: 0xDCFFEC VA: 0xDCFFEC
		// private IEnumerator FaildValkyrieCoroutine() { }

		// // RVA: 0xDD0074 Offset: 0xDD0074 VA: 0xDD0074 Slot: 43
		public void ShowPilotCutin()
		{
			TodoLogger.Log(0, "Hud ShowPilotCutin");
		}

		// // RVA: 0xDD0188 Offset: 0xDD0188 VA: 0xDD0188 Slot: 44
		public void ShowDivaCutin()
		{
			TodoLogger.Log(0, "Hud ShowDivaCutin");
		}

		// // RVA: 0xDD029C Offset: 0xDD029C VA: 0xDD029C Slot: 45
		public void ShowDiva(bool isSpMode = false)
		{
			TodoLogger.Log(0, "Hud ShowDiva");
		}

		// // RVA: 0xDD0608 Offset: 0xDD0608 VA: 0xDD0608 Slot: 46
		// public void EntryLiveSkillCutin(LiveSkill liveSkill, Material skillDescription, Material divaIconMaterial) { }

		// // RVA: 0xDD0658 Offset: 0xDD0658 VA: 0xDD0658 Slot: 47
		// public void ShowLiveSkillCutin() { }

		// // RVA: 0xDD0684 Offset: 0xDD0684 VA: 0xDD0684 Slot: 48
		// public void ShowActiveSkillCutin(string skillname, RhythmGameResource.UITextureResource textureResource) { }

		// // RVA: 0xDD06D0 Offset: 0xDD06D0 VA: 0xDD06D0 Slot: 49
		public void CloseSkillCutin()
		{
			TodoLogger.Log(0, "Hud CloseSkillCutin");
		}

		// // RVA: 0xDD0728 Offset: 0xDD0728 VA: 0xDD0728 Slot: 50
		public void EndAcceptOfInput()
		{
			TodoLogger.Log(0, "Hud EndAcceptOfInput");
		}

		// // RVA: 0xDD077C Offset: 0xDD077C VA: 0xDD077C Slot: 51
		public bool IsInputAccept()
		{
			TodoLogger.Log(0, "Hud IsInputAccept");
			return true;
		}

		// // RVA: 0xDD07AC Offset: 0xDD07AC VA: 0xDD07AC Slot: 52
		public void ShowTouchEffect(int trackId, int fingerId)
		{
			TodoLogger.Log(0, "Hud ShowTouchEffect");
		}

		// // RVA: 0xDD08F8 Offset: 0xDD08F8 VA: 0xDD08F8 Slot: 53
		public void HideToucheEffect(int trackId, int fingerId)
		{
			TodoLogger.Log(0, "Hud HideToucheEffect");
		}

		// // RVA: 0xDD0A50 Offset: 0xDD0A50 VA: 0xDD0A50 Slot: 54
		public void HideAllToucheEffect()
		{
			TodoLogger.Log(0, "Hud HideAllToucheEffect");
		}

		// // RVA: 0xDD0BB8 Offset: 0xDD0BB8 VA: 0xDD0BB8 Slot: 55
		// public void ShowLongNotesTouchEffect(int trackId) { }

		// // RVA: 0xDD0CCC Offset: 0xDD0CCC VA: 0xDD0CCC Slot: 56
		// public void HideLongNotesTouchEffect(int trackId) { }

		// // RVA: 0xDD0DE4 Offset: 0xDD0DE4 VA: 0xDD0DE4 Slot: 57
		// public void ShowSlideNotesTouchEffect(int trackId) { }

		// // RVA: 0xDD0E68 Offset: 0xDD0E68 VA: 0xDD0E68 Slot: 58
		// public void HideSlideNotesTouchEffect(int trackId) { }

		// // RVA: 0xDD0EEC Offset: 0xDD0EEC VA: 0xDD0EEC Slot: 59
		// public void ShowSlideNotesTipEffect(int trackId, RNoteSlide noteSlide) { }

		// // RVA: 0xDD0F78 Offset: 0xDD0F78 VA: 0xDD0F78 Slot: 60
		// public void HideSlideNotesTipEffect(int trackId) { }

		// // RVA: 0xDD0FFC Offset: 0xDD0FFC VA: 0xDD0FFC Slot: 61
		// public void ShowWingNotesOpenREffect(int trackId) { }

		// // RVA: 0xDD1080 Offset: 0xDD1080 VA: 0xDD1080 Slot: 62
		// public void ShowWingNotesOpenLEffect(int trackId) { }

		// // RVA: 0xDD1104 Offset: 0xDD1104 VA: 0xDD1104 Slot: 63
		// public void ShowWingNotesCloseREffect(int trackId) { }

		// // RVA: 0xDD1188 Offset: 0xDD1188 VA: 0xDD1188 Slot: 64
		// public void ShowWingNotesCloseLEffect(int trackId) { }

		// // RVA: 0xDD120C Offset: 0xDD120C VA: 0xDD120C Slot: 65
		// public void ShowNotesHitEffect(int trackId) { }

		// // RVA: 0xDD12A0 Offset: 0xDD12A0 VA: 0xDD12A0 Slot: 66
		public void ShowResultEffect(int lineNumber, RhythmGameConsts.NoteResultEx a_result_ex)
		{
			TodoLogger.Log(0, "Hud ShowResultEffect");
		}

		// // RVA: 0xDD17BC Offset: 0xDD17BC VA: 0xDD17BC Slot: 67
		// public void OnSkillEffect(int lineNumber, int effectType, bool isTopPriority) { }

		// // RVA: 0xDD1850 Offset: 0xDD1850 VA: 0xDD1850 Slot: 68
		// public void OffSkillEffect(int lineNumber, int effectType) { }

		// // RVA: 0xDD18DC Offset: 0xDD18DC VA: 0xDD18DC Slot: 69
		// public void OffTopPrioritySkillEffect(int lineNumber, int effectType) { }

		// // RVA: 0xDD1968 Offset: 0xDD1968 VA: 0xDD1968 Slot: 70
		// public void DrawSkillEffectEnable(int lineNumber, bool flag) { }

		// // RVA: 0xDD19F4 Offset: 0xDD19F4 VA: 0xDD19F4 Slot: 71
		// public bool IsEnableActiveSkillButton() { }

		// // RVA: 0xDD1A20 Offset: 0xDD1A20 VA: 0xDD1A20 Slot: 72
		// public void DecideActiveSkillButton(SkillDuration.Type duration) { }

		// // RVA: 0xDD1A54 Offset: 0xDD1A54 VA: 0xDD1A54
		// private void ApplyActiveSkillButtonUv() { }

		// // RVA: 0xDD1DB4 Offset: 0xDD1DB4 VA: 0xDD1DB4 Slot: 73
		// public void EnableActiveSkillButton() { }

		// // RVA: 0xDD1FEC Offset: 0xDD1FEC VA: 0xDD1FEC Slot: 74
		// public void DisableActiveSkillButton() { }

		// // RVA: 0xDD2018 Offset: 0xDD2018 VA: 0xDD2018 Slot: 75
		// public void EndActiveSkill() { }

		// // RVA: 0xDD2044 Offset: 0xDD2044 VA: 0xDD2044 Slot: 76
		// public void RestartActiveSkillButton() { }

		// // RVA: 0xDD2070 Offset: 0xDD2070 VA: 0xDD2070 Slot: 77
		public bool IsActiveSkillButtonAcEnd()
		{
			TodoLogger.Log(0, "Hud IsActiveSkillButtonAcEnd");
			return false;
		}

		// // RVA: 0xDD209C Offset: 0xDD209C VA: 0xDD209C Slot: 78
		// public bool IsActiveSkillButtonAcOn() { }

		// [IteratorStateMachineAttribute] // RVA: 0x744394 Offset: 0x744394 VA: 0x744394
		// // RVA: 0xDCE3A8 Offset: 0xDCE3A8 VA: 0xDCE3A8
		// private IEnumerator WaitEnterAnimeCoroutine(Action end) { }

		// // RVA: 0xDD20C8 Offset: 0xDD20C8 VA: 0xDD20C8
		private void OnPushBackButton()
		{
			TodoLogger.Log(0, "Hud OnPushBackButton");
		}

		// // RVA: 0xDD22C4 Offset: 0xDD22C4 VA: 0xDD22C4
		// public void OnPauseButtonSelected() { }

		// // RVA: 0xDD21C8 Offset: 0xDD21C8 VA: 0xDD21C8 Slot: 79
		// public void OnPauseButtonSelected(bool a_suspend) { }

		// // RVA: 0xDD22CC Offset: 0xDD22CC VA: 0xDD22CC Slot: 80
		// public void ClearPauseButton() { }

		// // RVA: 0xDD22F8 Offset: 0xDD22F8 VA: 0xDD22F8 Slot: 81
		public void DisablePauseButton()
		{
			TodoLogger.Log(0, "Hud DisablePauseButton");
		}

		// // RVA: 0xDD2324 Offset: 0xDD2324 VA: 0xDD2324 Slot: 82
		public void EnablePauseButton()
		{
			TodoLogger.Log(0, "Hud EnablePauseButton");
		}

		// // RVA: 0xDD2360 Offset: 0xDD2360 VA: 0xDD2360 Slot: 83
		public void UpdateBattleLimitTime(int ms)
		{
			TodoLogger.Log(0, "Hud UpdateBattleLimitTime");
		}

		// // RVA: 0xDD23A0 Offset: 0xDD23A0 VA: 0xDD23A0 Slot: 84
		// public void UpdateEnemyFrameColor(int damage, int threshold1, int threshold2) { }

		// // RVA: 0xDD23A4 Offset: 0xDD23A4 VA: 0xDD23A4 Slot: 85
		public void UpdateEnemyStatus(int damage, int threshold1, int threshold2, UnityAction onChaseModeCallback)
		{
			TodoLogger.Log(0, "Hud UpdateEnemyStatus");
		}

		// // RVA: 0xDD248C Offset: 0xDD248C VA: 0xDD248C Slot: 86
		// public void ChangeEnemyLife(EnemyStatus.LifeType a_type) { }

		// // RVA: 0xDD24C0 Offset: 0xDD24C0 VA: 0xDD24C0 Slot: 87
		// public void ChangeFaildEnemyStatus() { }

		// // RVA: 0xDD2534 Offset: 0xDD2534 VA: 0xDD2534 Slot: 88
		public void ShowEnemyCutin()
		{
			TodoLogger.Log(0, "Hud ShowEnemyCutin");
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
			TodoLogger.Log(0, "Hud SetPlayerDivaId");
		}

		// // RVA: 0xDD267C Offset: 0xDD267C VA: 0xDD267C Slot: 90
		// public void SetRivalDivaId(int divaId) { }

		// // RVA: 0xDD26B0 Offset: 0xDD26B0 VA: 0xDD26B0 Slot: 91
		// public void ShowBattleResult(bool isPlayerWin) { }

		// // RVA: 0xDD26E4 Offset: 0xDD26E4 VA: 0xDD26E4 Slot: 92
		public bool IsWarmupEnd()
		{
			TodoLogger.Log(0, "Hud IsWarmupEnd");
			return true;
		}

		// // RVA: 0xDD2714 Offset: 0xDD2714 VA: 0xDD2714 Slot: 93
		public void SetLineAlpha(int lineNo, float alpha)
		{
			TodoLogger.Log(0, "Hud SetLineAlpha");
		}

		// // RVA: 0xDD2750 Offset: 0xDD2750 VA: 0xDD2750 Slot: 94
		public bool IsActiveLine(int lineNo)
		{
			TodoLogger.Log(0, "Hud IsActiveLine");
			return true;
		}
	}
}
