
using System;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Game.Common;
using XeApp.Game.RhythmGame.UI;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameHudPauseButtonEvent : UnityEvent<bool> { }

	public interface IRhythmGameHUD
	{
		bool isReadyHUD { get; set; }
		int CurrentCombo { get; set; }
		int CurrentBattleCombo { get; set; }
		bool isBattleLimitTimeRunning { get; set; }
		bool isEnableCutin { get; set; }
		bool isShowNotes { get; set; }
		RhythmGameHudPauseButtonEvent PauseButton { get; }

		// // RVA: -1 Offset: -1 Slot: 0
		// public abstract bool get_isReadyHUD();

		// // RVA: -1 Offset: -1 Slot: 1
		// public abstract void set_isReadyHUD(bool value);

		// // RVA: -1 Offset: -1 Slot: 2
		// public abstract int get_CurrentCombo();

		// // RVA: -1 Offset: -1 Slot: 3
		// public abstract void set_CurrentCombo(int value);

		// // RVA: -1 Offset: -1 Slot: 4
		// public abstract int get_CurrentBattleCombo();

		// // RVA: -1 Offset: -1 Slot: 5
		// public abstract void set_CurrentBattleCombo(int value);

		// // RVA: -1 Offset: -1 Slot: 6
		// public abstract bool get_isBattleLimitTimeRunning();

		// // RVA: -1 Offset: -1 Slot: 7
		// public abstract void set_isBattleLimitTimeRunning(bool value);

		// // RVA: -1 Offset: -1 Slot: 8
		// public abstract bool get_isEnableCutin();

		// // RVA: -1 Offset: -1 Slot: 9
		// public abstract void set_isEnableCutin(bool value);

		// // RVA: -1 Offset: -1 Slot: 10
		// public abstract bool get_isShowNotes();

		// // RVA: -1 Offset: -1 Slot: 11
		// public abstract void set_isShowNotes(bool value);

		// // RVA: -1 Offset: -1 Slot: 12
		// public abstract RhythmGameHudPauseButtonEvent get_PauseButton();

		// // RVA: -1 Offset: -1 Slot: 13
		void Initialize();

		// // RVA: -1 Offset: -1 Slot: 14
		void SetPlayerSideTexture(UiPilotTexture pilotTexture, UiDivaTexture divaTexture);

		// // RVA: -1 Offset: -1 Slot: 15
		void SetEnemySideTexture(UiEnemyPilotTexture pilotTexture, UiEnemyRobotTexture robotTexture);

		// // RVA: -1 Offset: -1 Slot: 16
		void SetEnemyLiveSkillEffect(GameObject effPrefab);

		// // RVA: -1 Offset: -1 Slot: 17
		void SetPoisonSkillEffect(int a_bit, bool a_enable);

		// // RVA: -1 Offset: -1 Slot: 18
		void Show(Action end);

		// // RVA: -1 Offset: -1 Slot: 19
		// public abstract void Reset();

		// // RVA: -1 Offset: -1 Slot: 20
		// public abstract void PauseButtonClick();

		// // RVA: -1 Offset: -1 Slot: 21
		void ChangeHpGaugeFrame(int percent);

		// // RVA: -1 Offset: -1 Slot: 22
		// public abstract void SetContinue();

		// // RVA: -1 Offset: -1 Slot: 23
		void ChangeRankGaugeFrame(ResultScoreRank.Type rankType, float ratio);

		// // RVA: -1 Offset: -1 Slot: 24
		void ChangeScore(int score, int type);

		// // RVA: -1 Offset: -1 Slot: 25
		void SetFoldWaveGaugeValue(int value);

		// // RVA: -1 Offset: -1 Slot: 26
		// public abstract void HideFoldWaveGauge();

		// // RVA: -1 Offset: -1 Slot: 27
		// public abstract void UpdateCombo();

		// // RVA: -1 Offset: -1 Slot: 28
		void SetCombo(int combo);

		// // RVA: -1 Offset: -1 Slot: 29
		void SetBattleCombo(int combo);

		// // RVA: -1 Offset: -1 Slot: 30
		void SetItemCount(int kind, int count);

		// // RVA: -1 Offset: -1 Slot: 31
		void ShowLowEnergy();

		// // RVA: -1 Offset: -1 Slot: 32
		void ShowValkyrie();

		// // RVA: -1 Offset: -1 Slot: 33
		void ShowEnemyStatus();

		// // RVA: -1 Offset: -1 Slot: 34
		void ShowTargetSight();

		// // RVA: -1 Offset: -1 Slot: 35
		void ShowHitResult();

		// // RVA: -1 Offset: -1 Slot: 36
		void EnemyDamageResult(int result, Vector3 position);

		// // RVA: -1 Offset: -1 Slot: 37
		void UpdateTargetPosition(Vector3 position);

		// // RVA: -1 Offset: -1 Slot: 38
		void HideValkyrie(bool isFaild);

		// // RVA: -1 Offset: -1 Slot: 39
		void ShowPilotCutin();

		// // RVA: -1 Offset: -1 Slot: 40
		void ShowDivaCutin();

		// // RVA: -1 Offset: -1 Slot: 41
		void ShowDiva(bool isSpMode);

		// // RVA: -1 Offset: -1 Slot: 42
		void EntryLiveSkillCutin(LiveSkill liveSkill, Material skillDescription, Material divaIconMaterial);

		// // RVA: -1 Offset: -1 Slot: 43
		void ShowLiveSkillCutin();

		// // RVA: -1 Offset: -1 Slot: 44
		void ShowActiveSkillCutin(string skillname, RhythmGameResource.UITextureResource textureResource);

		// // RVA: -1 Offset: -1 Slot: 45
		void CloseSkillCutin();

		// // RVA: -1 Offset: -1 Slot: 46
		void EndAcceptOfInput();

		// // RVA: -1 Offset: -1 Slot: 47
		bool IsInputAccept();

		// // RVA: -1 Offset: -1 Slot: 48
		void ShowTouchEffect(int trackId, int fingerId);

		// // RVA: -1 Offset: -1 Slot: 49
		void HideToucheEffect(int trackId, int fingerId);

		// // RVA: -1 Offset: -1 Slot: 50
		void HideAllToucheEffect();

		// // RVA: -1 Offset: -1 Slot: 51
		void ShowLongNotesTouchEffect(int trackId);

		// // RVA: -1 Offset: -1 Slot: 52
		void HideLongNotesTouchEffect(int trackId);

		// // RVA: -1 Offset: -1 Slot: 53
		void ShowSlideNotesTouchEffect(int trackId);

		// // RVA: -1 Offset: -1 Slot: 54
		void HideSlideNotesTouchEffect(int trackId);

		// // RVA: -1 Offset: -1 Slot: 55
		void ShowSlideNotesTipEffect(int trackId, RNoteSlide noteSlide);

		// // RVA: -1 Offset: -1 Slot: 56
		void HideSlideNotesTipEffect(int trackId);

		// // RVA: -1 Offset: -1 Slot: 57
		void ShowWingNotesOpenREffect(int trackId);

		// // RVA: -1 Offset: -1 Slot: 58
		void ShowWingNotesOpenLEffect(int trackId);

		// // RVA: -1 Offset: -1 Slot: 59
		void ShowWingNotesCloseREffect(int trackId);

		// // RVA: -1 Offset: -1 Slot: 60
		void ShowWingNotesCloseLEffect(int trackId);

		// // RVA: -1 Offset: -1 Slot: 61
		void ShowNotesHitEffect(int trackId);

		// // RVA: -1 Offset: -1 Slot: 62
		void ShowResultEffect(int lineNumber, RhythmGameConsts.NoteResultEx a_result_ex);

		// // RVA: -1 Offset: -1 Slot: 63
		void OnSkillEffect(int lineNumber, int effectType, bool isTopPriority);

		// // RVA: -1 Offset: -1 Slot: 64
		void OffSkillEffect(int lineNumber, int effectType);

		// // RVA: -1 Offset: -1 Slot: 65
		void OffTopPrioritySkillEffect(int lineNumber, int effectType);

		// // RVA: -1 Offset: -1 Slot: 66
		// public abstract void DrawSkillEffectEnable(int lineNumber, bool flag);

		// // RVA: -1 Offset: -1 Slot: 67
		bool IsEnableActiveSkillButton();

		// // RVA: -1 Offset: -1 Slot: 68
		void DecideActiveSkillButton(SkillDuration.Type duration);

		// // RVA: -1 Offset: -1 Slot: 69
		// public abstract void EnableActiveSkillButton();

		// // RVA: -1 Offset: -1 Slot: 70
		void DisableActiveSkillButton();

		// // RVA: -1 Offset: -1 Slot: 71
		void EndActiveSkill();

		// // RVA: -1 Offset: -1 Slot: 72
		void RestartActiveSkillButton();

		// // RVA: -1 Offset: -1 Slot: 73
		bool IsActiveSkillButtonAcEnd();

		// // RVA: -1 Offset: -1 Slot: 74
		bool IsActiveSkillButtonAcOn();

		// // RVA: -1 Offset: -1 Slot: 75
		void OnPauseButtonSelected(bool a_syspend);

		// // RVA: -1 Offset: -1 Slot: 76
		void ClearPauseButton();

		// // RVA: -1 Offset: -1 Slot: 77
		void DisablePauseButton();

		// // RVA: -1 Offset: -1 Slot: 78
		void EnablePauseButton();

		// // RVA: -1 Offset: -1 Slot: 79
		void UpdateBattleLimitTime(int ms);

		// // RVA: -1 Offset: -1 Slot: 80
		// public abstract void UpdateEnemyFrameColor(int damage, int threshold1, int threshold2);

		// // RVA: -1 Offset: -1 Slot: 81
		void UpdateEnemyStatus(int damage, int threshold1, int threshold2, UnityAction onChaseModeCallback);

		// // RVA: -1 Offset: -1 Slot: 82
		void ChangeEnemyLife(EnemyStatus.LifeType a_type);

		// // RVA: -1 Offset: -1 Slot: 83
		// public abstract void ChangeFaildEnemyStatus();

		// // RVA: -1 Offset: -1 Slot: 84
		void ShowEnemyCutin();

		// // RVA: -1 Offset: -1 Slot: 85
		void SetPlayerDivaId(int divaId);

		// // RVA: -1 Offset: -1 Slot: 86
		// public abstract void SetRivalDivaId(int divaId);

		// // RVA: -1 Offset: -1 Slot: 87
		// public abstract void ShowBattleResult(bool isPlayerWin);

		// // RVA: -1 Offset: -1 Slot: 88
		bool IsWarmupEnd();

		// // RVA: -1 Offset: -1 Slot: 89
		void SetLineAlpha(int lineNo, float alpha);

		// // RVA: -1 Offset: -1 Slot: 90
		bool IsActiveLine(int lineNo);
	}
}
