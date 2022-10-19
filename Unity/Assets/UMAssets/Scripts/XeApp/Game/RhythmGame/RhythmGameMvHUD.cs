using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.RhythmGame.UI;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameMvHUD : MonoBehaviour, IRhythmGameHUD
	{
		private RhythmGameHudPauseButtonEvent m_pauseButtonEvent = new RhythmGameHudPauseButtonEvent(); // 0xC
		[SerializeField]
		private PrefabInstance[] touchPrefab; // 0x10
		[SerializeField]
		private PrefabInstance[] touchPrefabWide; // 0x14
		[SerializeField]
		private GameObject waterMark; // 0x18
		[SerializeField]
		private GameObject touchMark; // 0x1C
		[SerializeField]
		private GameObject touchMarkWide; // 0x20
		[SerializeField]
		private GameObject m_userStateObject; // 0x24
		[SerializeField]
		private GameObject valkyrieTopObject; // 0x28
		[SerializeField]
		private GameObject m_targetSightPrefab; // 0x2C
		[SerializeField]
		private GameObject pauseButton; // 0x30
		[SerializeField]
		private RectTransform leftTop; // 0x34
		[SerializeField]
		private RectTransform RightTop; // 0x38
		[SerializeField]
		private RectTransform leftBottom; // 0x3C
		[SerializeField]
		private RectTransform top; // 0x40
		[SerializeField]
		private RectTransform center; // 0x44
		[SerializeField]
		private RectTransform bottom; // 0x48
		[SerializeField]
		private RectTransform bottomWide; // 0x4C
		private UiPilotTexture m_PilotTexture; // 0x50
		private UiDivaTexture m_DivaTexture; // 0x54
		private UiEnemyPilotTexture m_EnemyPilotTexture; // 0x58
		private UiEnemyRobotTexture m_EnemyRobotTexture; // 0x5C
		private GameObject m_valkyrieTopUi; // 0x60
		private TouchPrefabInstance[] m_touchEffects; // 0x64
		private Button m_screenTouchArea; // 0x68
		private bool m_isSelectedPause; // 0x6C
		private FaceCutin[] m_faceCutin; // 0x70
		private Animator m_lifeWarningEffect; // 0x74
		private Animator m_lifeRecoveryEffect; // 0x78
		private Animator m_divaModeEffect; // 0x7C
		private Animator m_valkyrieTopAnimator; // 0x80
		private PauseButton m_pauseButton; // 0x84
		private EnemyStatus m_enemyStatus; // 0x88
		private EnemyTargetSight m_targetSight; // 0x8C
		private Animator m_targetSightMark; // 0x90
		private Canvas m_canvas; // 0x94
		private RectTransform m_cameraRectTransform; // 0x98
		private bool IsChaseMode; // 0xAB
		private bool m_isLowSpec; // 0xAC
		private bool m_is2dMode; // 0xAD
		private bool m_isValkyrieOff; // 0xAE
		private WaitForSeconds m_waitForSeconds = new WaitForSeconds(1.966f); // 0xB0
		private readonly int cut_IN_MV_Hash = Animator.StringToHash("cut_IN_MV"); // 0xB4
		private readonly int cut_wait_Hash = Animator.StringToHash("cut_wait"); // 0xB8
		private readonly int damage_OUT_Hash = Animator.StringToHash("damage_OUT"); // 0xBC
		private readonly int recovery_OUT_Hash = Animator.StringToHash("recovery_OUT"); // 0xC0
		private readonly int target_site_IN_Hash = Animator.StringToHash("target_site_IN"); // 0xC4
		//private readonly int UI_rhythm_Push_IN_HashCode = "UI_rhythm_Push_IN"; // 0xC8
		//private readonly int UI_rhythm_Push_OUT_HashCode = "UI_rhythm_Push_OUT"; // 0xCC
		//private readonly int UI_rhythm_Long_IN_HashCode = "UI_rhythm_Long_IN"; // 0xD0
		//private readonly int UI_rhythm_Long_Loop_HashCode = "UI_rhythm_Long_Loop"; // 0xD4
		//private readonly int UI_rhythm_Long_OUT_HashCode = "UI_rhythm_Long_OUT"; // 0xD8
		//private readonly int UI_rhythm_Delete_HashCode = "UI_rhythm_Delete"; // 0xDC
		//private readonly int PerfectResultHashCode = "Mv_Perfect"; // 0xE0

		public RhythmGameHudPauseButtonEvent PauseButton { get { return m_pauseButtonEvent; } } //0x9A9284
		public bool isReadyHUD { get; set; } // 0x9C
		public int CurrentCombo { get; set; } // 0xA0
		public int CurrentBattleCombo { get; set; } // 0xA4
		public bool isBattleLimitTimeRunning { get; set; } // 0xA8
		public bool isEnableCutin { get; set; } // 0xA9
		public bool isShowNotes { get; set; } // 0xAA

		//// RVA: 0x9A92EC Offset: 0x9A92EC VA: 0x9A92EC Slot: 17
		public void Initialize()
		{
			TodoLogger.Log(0, "Hud Initialize");
		}

		//// RVA: 0x9AABA8 Offset: 0x9AABA8 VA: 0x9AABA8
		public void OnDestroy()
		{
			TodoLogger.Log(0, "Hud OnDestroy");
		}

		//// RVA: 0x9AAC84 Offset: 0x9AAC84 VA: 0x9AAC84 Slot: 18
		public void SetPlayerSideTexture(UiPilotTexture pilotTexture, UiDivaTexture divaTexture)
		{
			TodoLogger.Log(0, "Hud SetPlayerSideTexture");
		}

		//// RVA: 0x9AAC90 Offset: 0x9AAC90 VA: 0x9AAC90 Slot: 19
		public void SetEnemySideTexture(UiEnemyPilotTexture pilotTexture, UiEnemyRobotTexture robotTexture)
		{
			TodoLogger.Log(0, "Hud SetEnemySideTexture");
		}

		//// RVA: 0x9AAC9C Offset: 0x9AAC9C VA: 0x9AAC9C Slot: 22
		//public void Show(Action end) { }

		//[IteratorStateMachineAttribute] // RVA: 0x74462C Offset: 0x74462C VA: 0x74462C
		//// RVA: 0x9AACC0 Offset: 0x9AACC0 VA: 0x9AACC0
		//private IEnumerator WaitPauseActiveCroutine(Action end) { }

		//// RVA: 0x9AAD88 Offset: 0x9AAD88 VA: 0x9AAD88 Slot: 23
		//public void Reset() { }

		//// RVA: 0x9AAE70 Offset: 0x9AAE70 VA: 0x9AAE70 Slot: 24
		//public void PauseButtonClick() { }

		//// RVA: 0x9AAF0C Offset: 0x9AAF0C VA: 0x9AAF0C
		private void OnPushBackButton()
		{
			TodoLogger.Log(0, "Hud OnPushBackButton");
		}

		//// RVA: 0x9AB0D4 Offset: 0x9AB0D4 VA: 0x9AB0D4 Slot: 20
		public void SetEnemyLiveSkillEffect(GameObject effPrefab)
		{
			TodoLogger.Log(0, "Hud SetEnemyLiveSkillEffect");
		}

		//// RVA: 0x9AB0D8 Offset: 0x9AB0D8 VA: 0x9AB0D8 Slot: 21
		//public void SetPoisonSkillEffect(int a_bit, bool a_enable) { }

		//// RVA: 0x9AB0DC Offset: 0x9AB0DC VA: 0x9AB0DC Slot: 25
		public void ChangeHpGaugeFrame(int percent)
		{
			TodoLogger.Log(0, "Hud ChangeHpGaugeFrame");
		}

		//// RVA: 0x9AB0E0 Offset: 0x9AB0E0 VA: 0x9AB0E0 Slot: 26
		//public void SetContinue() { }

		//// RVA: 0x9AB0E4 Offset: 0x9AB0E4 VA: 0x9AB0E4 Slot: 27
		public void ChangeRankGaugeFrame(ResultScoreRank.Type rankType, float ratio)
		{
			TodoLogger.Log(0, "Hud ChangeRankGaugeFrame");
		}

		//// RVA: 0x9AB0E8 Offset: 0x9AB0E8 VA: 0x9AB0E8 Slot: 28
		public void ChangeScore(int score, int type)
		{
			TodoLogger.Log(0, "Hud ChangeScore");
		}

		//// RVA: 0x9AB0EC Offset: 0x9AB0EC VA: 0x9AB0EC Slot: 29
		//public void SetFoldWaveGaugeValue(int value) { }

		//// RVA: 0x9AB0F0 Offset: 0x9AB0F0 VA: 0x9AB0F0 Slot: 30
		//public void HideFoldWaveGauge() { }

		//// RVA: 0x9AB0F4 Offset: 0x9AB0F4 VA: 0x9AB0F4 Slot: 31
		//public void UpdateCombo() { }

		//// RVA: 0x9AB0F8 Offset: 0x9AB0F8 VA: 0x9AB0F8 Slot: 32
		//public void SetCombo(int combo) { }

		//// RVA: 0x9AB0FC Offset: 0x9AB0FC VA: 0x9AB0FC Slot: 33
		//public void SetBattleCombo(int combo) { }

		//// RVA: 0x9AB100 Offset: 0x9AB100 VA: 0x9AB100 Slot: 34
		public void SetItemCount(int kind, int count)
		{
			TodoLogger.Log(0, "Hud SetItemCount");
		}

		//// RVA: 0x9AB104 Offset: 0x9AB104 VA: 0x9AB104 Slot: 35
		public void ShowLowEnergy()
		{
			TodoLogger.Log(0, "Hud ShowLowEnergy");
		}

		//// RVA: 0x9AB108 Offset: 0x9AB108 VA: 0x9AB108 Slot: 36
		public void ShowValkyrie()
		{
			TodoLogger.Log(0, "Hud ShowValkyrie");
		}

		//// RVA: 0x9AB15C Offset: 0x9AB15C VA: 0x9AB15C Slot: 37
		public void ShowEnemyStatus()
		{
			TodoLogger.Log(0, "Hud ShowEnemyStatus");
		}

		//// RVA: 0x9AB244 Offset: 0x9AB244 VA: 0x9AB244 Slot: 38
		public void ShowTargetSight()
		{
			TodoLogger.Log(0, "Hud ShowTargetSight");
		}

		//// RVA: 0x9AB300 Offset: 0x9AB300 VA: 0x9AB300 Slot: 39
		public void ShowHitResult()
		{
			TodoLogger.Log(0, "Hud ShowHitResult");
		}

		//// RVA: 0x9AB304 Offset: 0x9AB304 VA: 0x9AB304 Slot: 40
		//public void EnemyDamageResult(int result, Vector3 position) { }

		//// RVA: 0x9AB308 Offset: 0x9AB308 VA: 0x9AB308 Slot: 41
		public void UpdateTargetPosition(Vector3 position)
		{
			TodoLogger.Log(0, "Hud UpdateTargetPosition");
		}

		//// RVA: 0x9AB4FC Offset: 0x9AB4FC VA: 0x9AB4FC
		//private Vector3 AdjustUiCameraPosition(Vector3 normalizePosition) { }

		//// RVA: 0x9AB618 Offset: 0x9AB618 VA: 0x9AB618 Slot: 42
		public void HideValkyrie(bool isFaild = false)
		{
			TodoLogger.Log(0, "Hud HideValkyrie");
		}

		//// RVA: 0x9AB6F0 Offset: 0x9AB6F0 VA: 0x9AB6F0 Slot: 43
		public void ShowPilotCutin()
		{
			TodoLogger.Log(0, "Hud ShowPilotCutin");
		}

		//// RVA: 0x9AB804 Offset: 0x9AB804 VA: 0x9AB804 Slot: 44
		public void ShowDivaCutin()
		{
			TodoLogger.Log(0, "Hud ShowDivaCutin");
		}

		//// RVA: 0x9AB918 Offset: 0x9AB918 VA: 0x9AB918 Slot: 45
		public void ShowDiva(bool isSpMode = false)
		{
			TodoLogger.Log(0, "Hud ShowDiva");
		}

		//// RVA: 0x9AB960 Offset: 0x9AB960 VA: 0x9AB960 Slot: 46
		//public void EntryLiveSkillCutin(LiveSkill liveSkill, Material skillDescription, Material divaIconMaterial) { }

		//// RVA: 0x9AB964 Offset: 0x9AB964 VA: 0x9AB964 Slot: 47
		//public void ShowLiveSkillCutin() { }

		//// RVA: 0x9AB968 Offset: 0x9AB968 VA: 0x9AB968 Slot: 48
		//public void ShowActiveSkillCutin(string skillname, RhythmGameResource.UITextureResource textureResource) { }

		//// RVA: 0x9AB96C Offset: 0x9AB96C VA: 0x9AB96C Slot: 49
		//public void CloseSkillCutin() { }

		//// RVA: 0x9AB970 Offset: 0x9AB970 VA: 0x9AB970 Slot: 50
		//public void EndAcceptOfInput() { }

		//// RVA: 0x9AB9C8 Offset: 0x9AB9C8 VA: 0x9AB9C8 Slot: 51
		public bool IsInputAccept()
		{
			TodoLogger.Log(0, "Hud IsInputAccept");
			return true;
		}

		//// RVA: 0x9AB9F4 Offset: 0x9AB9F4 VA: 0x9AB9F4 Slot: 52
		public void ShowTouchEffect(int trackId, int fingerId)
		{
			TodoLogger.Log(0, "Hud ShowTouchEffect");
		}

		//// RVA: 0x9AB9F8 Offset: 0x9AB9F8 VA: 0x9AB9F8 Slot: 53
		public void HideToucheEffect(int trackId, int fingerId)
		{
			TodoLogger.Log(0, "Hud HideToucheEffect");
		}

		//// RVA: 0x9AB9FC Offset: 0x9AB9FC VA: 0x9AB9FC Slot: 54
		//public void HideAllToucheEffect() { }

		//// RVA: 0x9ABA00 Offset: 0x9ABA00 VA: 0x9ABA00 Slot: 55
		//public void ShowLongNotesTouchEffect(int trackId) { }

		//// RVA: 0x9ABB20 Offset: 0x9ABB20 VA: 0x9ABB20 Slot: 56
		//public void HideLongNotesTouchEffect(int trackId) { }

		//// RVA: 0x9ABC48 Offset: 0x9ABC48 VA: 0x9ABC48 Slot: 57
		//public void ShowSlideNotesTouchEffect(int trackId) { }

		//// RVA: 0x9ABCD8 Offset: 0x9ABCD8 VA: 0x9ABCD8 Slot: 58
		//public void HideSlideNotesTouchEffect(int trackId) { }

		//// RVA: 0x9ABD68 Offset: 0x9ABD68 VA: 0x9ABD68 Slot: 59
		//public void ShowSlideNotesTipEffect(int trackId, RNoteSlide noteSlide) { }

		//// RVA: 0x9ABE00 Offset: 0x9ABE00 VA: 0x9ABE00 Slot: 60
		//public void HideSlideNotesTipEffect(int trackId) { }

		//// RVA: 0x9ABE90 Offset: 0x9ABE90 VA: 0x9ABE90 Slot: 61
		//public void ShowWingNotesOpenREffect(int trackId) { }

		//// RVA: 0x9ABF20 Offset: 0x9ABF20 VA: 0x9ABF20 Slot: 62
		//public void ShowWingNotesOpenLEffect(int trackId) { }

		//// RVA: 0x9ABFB0 Offset: 0x9ABFB0 VA: 0x9ABFB0 Slot: 63
		//public void ShowWingNotesCloseREffect(int trackId) { }

		//// RVA: 0x9AC040 Offset: 0x9AC040 VA: 0x9AC040 Slot: 64
		//public void ShowWingNotesCloseLEffect(int trackId) { }

		//// RVA: 0x9AC0D0 Offset: 0x9AC0D0 VA: 0x9AC0D0 Slot: 65
		//public void ShowNotesHitEffect(int trackId) { }

		//// RVA: 0x9AC0D4 Offset: 0x9AC0D4 VA: 0x9AC0D4 Slot: 66
		public void ShowResultEffect(int lineNumber, RhythmGameConsts.NoteResultEx a_result_ex)
		{
			TodoLogger.Log(0, "Hud ShowResultEffect");
		}

		//// RVA: 0x9AC360 Offset: 0x9AC360 VA: 0x9AC360 Slot: 67
		//public void OnSkillEffect(int lineNumber, int effectType, bool isTopPriority) { }

		//// RVA: 0x9AC364 Offset: 0x9AC364 VA: 0x9AC364 Slot: 68
		//public void OffSkillEffect(int lineNumber, int effectType) { }

		//// RVA: 0x9AC368 Offset: 0x9AC368 VA: 0x9AC368 Slot: 69
		//public void OffTopPrioritySkillEffect(int lineNumber, int effectType) { }

		//// RVA: 0x9AC36C Offset: 0x9AC36C VA: 0x9AC36C Slot: 70
		//public void DrawSkillEffectEnable(int lineNumber, bool flag) { }

		//// RVA: 0x9AC370 Offset: 0x9AC370 VA: 0x9AC370 Slot: 71
		//public bool IsEnableActiveSkillButton() { }

		//// RVA: 0x9AC378 Offset: 0x9AC378 VA: 0x9AC378 Slot: 72
		//public void DecideActiveSkillButton(SkillDuration.Type duration) { }

		//// RVA: 0x9AC37C Offset: 0x9AC37C VA: 0x9AC37C Slot: 73
		//public void EnableActiveSkillButton() { }

		//// RVA: 0x9AC380 Offset: 0x9AC380 VA: 0x9AC380 Slot: 74
		//public void DisableActiveSkillButton() { }

		//// RVA: 0x9AC384 Offset: 0x9AC384 VA: 0x9AC384 Slot: 75
		//public void EndActiveSkill() { }

		//// RVA: 0x9AC388 Offset: 0x9AC388 VA: 0x9AC388 Slot: 76
		//public void RestartActiveSkillButton() { }

		//// RVA: 0x9AC38C Offset: 0x9AC38C VA: 0x9AC38C Slot: 77
		//public bool IsActiveSkillButtonAcEnd() { }

		//// RVA: 0x9AC394 Offset: 0x9AC394 VA: 0x9AC394 Slot: 78
		//public bool IsActiveSkillButtonAcOn() { }

		//// RVA: 0x9AB00C Offset: 0x9AB00C VA: 0x9AB00C Slot: 79
		//public void OnPauseButtonSelected(bool a_suspend) { }

		//// RVA: 0x9AC39C Offset: 0x9AC39C VA: 0x9AC39C Slot: 80
		//public void ClearPauseButton() { }

		//// RVA: 0x9AC3D0 Offset: 0x9AC3D0 VA: 0x9AC3D0 Slot: 81
		//public void DisablePauseButton() { }

		//// RVA: 0x9AC400 Offset: 0x9AC400 VA: 0x9AC400 Slot: 82
		public void EnablePauseButton()
		{
			TodoLogger.Log(0, "Hud EnablePauseButton");
		}

		//// RVA: 0x9AC458 Offset: 0x9AC458 VA: 0x9AC458 Slot: 83
		public void UpdateBattleLimitTime(int ms)
		{
			TodoLogger.Log(0, "Hud UpdateBattleLimitTime");
		}

		//// RVA: 0x9AC45C Offset: 0x9AC45C VA: 0x9AC45C Slot: 84
		//public void UpdateEnemyFrameColor(int damage, int threshold1, int threshold2) { }

		//// RVA: 0x9AC460 Offset: 0x9AC460 VA: 0x9AC460 Slot: 85
		//public void UpdateEnemyStatus(int damage, int threshold1, int threshold2, UnityAction onChaseModeCallback) { }

		//// RVA: 0x9AC548 Offset: 0x9AC548 VA: 0x9AC548 Slot: 86
		//public void ChangeEnemyLife(EnemyStatus.LifeType a_type) { }

		//// RVA: 0x9AC57C Offset: 0x9AC57C VA: 0x9AC57C Slot: 87
		//public void ChangeFaildEnemyStatus() { }

		//// RVA: 0x9AC580 Offset: 0x9AC580 VA: 0x9AC580 Slot: 88
		public void ShowEnemyCutin()
		{
			TodoLogger.Log(0, "Hud ShowEnemyCutin");
		}

		//// RVA: 0x9AC694 Offset: 0x9AC694 VA: 0x9AC694 Slot: 89
		public void SetPlayerDivaId(int divaId)
		{
			TodoLogger.Log(0, "Hud SetPlayerDivaId");
		}

		//// RVA: 0x9AC698 Offset: 0x9AC698 VA: 0x9AC698 Slot: 90
		//public void SetRivalDivaId(int divaId) { }

		//// RVA: 0x9AC69C Offset: 0x9AC69C VA: 0x9AC69C Slot: 91
		//public void ShowBattleResult(bool isPlayerWin) { }

		//// RVA: 0x9AC6A0 Offset: 0x9AC6A0 VA: 0x9AC6A0 Slot: 92
		public bool IsWarmupEnd()
		{
			TodoLogger.Log(0, "Hud IsWarmupEnd");
			return true;
		}

		//// RVA: 0x9AC6A8 Offset: 0x9AC6A8 VA: 0x9AC6A8 Slot: 93
		public void SetLineAlpha(int lineNo, float alpha)
		{
			TodoLogger.Log(0, "Hud SetLineAlpha");
		}

		//// RVA: 0x9AC6AC Offset: 0x9AC6AC VA: 0x9AC6AC Slot: 94
		public bool IsActiveLine(int lineNo)
		{
			TodoLogger.Log(0, "Hud IsActiveLine");
			return true;
		}
	}
}
