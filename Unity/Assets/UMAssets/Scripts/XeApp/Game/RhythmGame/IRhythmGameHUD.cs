
public interface IRhythmGameHUD
{
	bool isReadyHUD { get; set; }
	int CurrentCombo { get; set; }
	int CurrentBattleCombo { get; set; }
	bool isBattleLimitTimeRunning { get; set; }
	bool isEnableCutin { get; set; }
	bool isShowNotes { get; set; }
	// public abstract RhythmGameHudPauseButtonEvent PauseButton { get; }

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
	// public abstract void Initialize();

	// // RVA: -1 Offset: -1 Slot: 14
	// public abstract void SetPlayerSideTexture(UiPilotTexture pilotTexture, UiDivaTexture divaTexture);

	// // RVA: -1 Offset: -1 Slot: 15
	// public abstract void SetEnemySideTexture(UiEnemyPilotTexture pilotTexture, UiEnemyRobotTexture robotTexture);

	// // RVA: -1 Offset: -1 Slot: 16
	// public abstract void SetEnemyLiveSkillEffect(GameObject effPrefab);

	// // RVA: -1 Offset: -1 Slot: 17
	// public abstract void SetPoisonSkillEffect(int a_bit, bool a_enable);

	// // RVA: -1 Offset: -1 Slot: 18
	// public abstract void Show(Action end);

	// // RVA: -1 Offset: -1 Slot: 19
	// public abstract void Reset();

	// // RVA: -1 Offset: -1 Slot: 20
	// public abstract void PauseButtonClick();

	// // RVA: -1 Offset: -1 Slot: 21
	// public abstract void ChangeHpGaugeFrame(int percent);

	// // RVA: -1 Offset: -1 Slot: 22
	// public abstract void SetContinue();

	// // RVA: -1 Offset: -1 Slot: 23
	// public abstract void ChangeRankGaugeFrame(ResultScoreRank.Type rankType, float ratio);

	// // RVA: -1 Offset: -1 Slot: 24
	// public abstract void ChangeScore(int score, int type);

	// // RVA: -1 Offset: -1 Slot: 25
	// public abstract void SetFoldWaveGaugeValue(int value);

	// // RVA: -1 Offset: -1 Slot: 26
	// public abstract void HideFoldWaveGauge();

	// // RVA: -1 Offset: -1 Slot: 27
	// public abstract void UpdateCombo();

	// // RVA: -1 Offset: -1 Slot: 28
	// public abstract void SetCombo(int combo);

	// // RVA: -1 Offset: -1 Slot: 29
	// public abstract void SetBattleCombo(int combo);

	// // RVA: -1 Offset: -1 Slot: 30
	// public abstract void SetItemCount(int kind, int count);

	// // RVA: -1 Offset: -1 Slot: 31
	// public abstract void ShowLowEnergy();

	// // RVA: -1 Offset: -1 Slot: 32
	// public abstract void ShowValkyrie();

	// // RVA: -1 Offset: -1 Slot: 33
	void ShowEnemyStatus();

	// // RVA: -1 Offset: -1 Slot: 34
	void ShowTargetSight();

	// // RVA: -1 Offset: -1 Slot: 35
	void ShowHitResult();

	// // RVA: -1 Offset: -1 Slot: 36
	// public abstract void EnemyDamageResult(int result, Vector3 position);

	// // RVA: -1 Offset: -1 Slot: 37
	// public abstract void UpdateTargetPosition(Vector3 position);

	// // RVA: -1 Offset: -1 Slot: 38
	void HideValkyrie(bool isFaild);

	// // RVA: -1 Offset: -1 Slot: 39
	void ShowPilotCutin();

	// // RVA: -1 Offset: -1 Slot: 40
	void ShowDivaCutin();

	// // RVA: -1 Offset: -1 Slot: 41
	void ShowDiva(bool isSpMode);

	// // RVA: -1 Offset: -1 Slot: 42
	// public abstract void EntryLiveSkillCutin(LiveSkill liveSkill, Material skillDescription, Material divaIconMaterial);

	// // RVA: -1 Offset: -1 Slot: 43
	// public abstract void ShowLiveSkillCutin();

	// // RVA: -1 Offset: -1 Slot: 44
	// public abstract void ShowActiveSkillCutin(string skillname, RhythmGameResource.UITextureResource textureResource);

	// // RVA: -1 Offset: -1 Slot: 45
	// public abstract void CloseSkillCutin();

	// // RVA: -1 Offset: -1 Slot: 46
	// public abstract void EndAcceptOfInput();

	// // RVA: -1 Offset: -1 Slot: 47
	// public abstract bool IsInputAccept();

	// // RVA: -1 Offset: -1 Slot: 48
	// public abstract void ShowTouchEffect(int trackId, int fingerId);

	// // RVA: -1 Offset: -1 Slot: 49
	// public abstract void HideToucheEffect(int trackId, int fingerId);

	// // RVA: -1 Offset: -1 Slot: 50
	// public abstract void HideAllToucheEffect();

	// // RVA: -1 Offset: -1 Slot: 51
	// public abstract void ShowLongNotesTouchEffect(int trackId);

	// // RVA: -1 Offset: -1 Slot: 52
	// public abstract void HideLongNotesTouchEffect(int trackId);

	// // RVA: -1 Offset: -1 Slot: 53
	// public abstract void ShowSlideNotesTouchEffect(int trackId);

	// // RVA: -1 Offset: -1 Slot: 54
	// public abstract void HideSlideNotesTouchEffect(int trackId);

	// // RVA: -1 Offset: -1 Slot: 55
	// public abstract void ShowSlideNotesTipEffect(int trackId, RNoteSlide noteSlide);

	// // RVA: -1 Offset: -1 Slot: 56
	// public abstract void HideSlideNotesTipEffect(int trackId);

	// // RVA: -1 Offset: -1 Slot: 57
	// public abstract void ShowWingNotesOpenREffect(int trackId);

	// // RVA: -1 Offset: -1 Slot: 58
	// public abstract void ShowWingNotesOpenLEffect(int trackId);

	// // RVA: -1 Offset: -1 Slot: 59
	// public abstract void ShowWingNotesCloseREffect(int trackId);

	// // RVA: -1 Offset: -1 Slot: 60
	// public abstract void ShowWingNotesCloseLEffect(int trackId);

	// // RVA: -1 Offset: -1 Slot: 61
	// public abstract void ShowNotesHitEffect(int trackId);

	// // RVA: -1 Offset: -1 Slot: 62
	// public abstract void ShowResultEffect(int lineNumber, RhythmGameConsts.NoteResultEx a_result_ex);

	// // RVA: -1 Offset: -1 Slot: 63
	// public abstract void OnSkillEffect(int lineNumber, int effectType, bool isTopPriority);

	// // RVA: -1 Offset: -1 Slot: 64
	// public abstract void OffSkillEffect(int lineNumber, int effectType);

	// // RVA: -1 Offset: -1 Slot: 65
	// public abstract void OffTopPrioritySkillEffect(int lineNumber, int effectType);

	// // RVA: -1 Offset: -1 Slot: 66
	// public abstract void DrawSkillEffectEnable(int lineNumber, bool flag);

	// // RVA: -1 Offset: -1 Slot: 67
	// public abstract bool IsEnableActiveSkillButton();

	// // RVA: -1 Offset: -1 Slot: 68
	// public abstract void DecideActiveSkillButton(SkillDuration.Type duration);

	// // RVA: -1 Offset: -1 Slot: 69
	// public abstract void EnableActiveSkillButton();

	// // RVA: -1 Offset: -1 Slot: 70
	// public abstract void DisableActiveSkillButton();

	// // RVA: -1 Offset: -1 Slot: 71
	// public abstract void EndActiveSkill();

	// // RVA: -1 Offset: -1 Slot: 72
	// public abstract void RestartActiveSkillButton();

	// // RVA: -1 Offset: -1 Slot: 73
	// public abstract bool IsActiveSkillButtonAcEnd();

	// // RVA: -1 Offset: -1 Slot: 74
	// public abstract bool IsActiveSkillButtonAcOn();

	// // RVA: -1 Offset: -1 Slot: 75
	// public abstract void OnPauseButtonSelected(bool a_syspend);

	// // RVA: -1 Offset: -1 Slot: 76
	// public abstract void ClearPauseButton();

	// // RVA: -1 Offset: -1 Slot: 77
	// public abstract void DisablePauseButton();

	// // RVA: -1 Offset: -1 Slot: 78
	void EnablePauseButton();

	// // RVA: -1 Offset: -1 Slot: 79
	// public abstract void UpdateBattleLimitTime(int ms);

	// // RVA: -1 Offset: -1 Slot: 80
	// public abstract void UpdateEnemyFrameColor(int damage, int threshold1, int threshold2);

	// // RVA: -1 Offset: -1 Slot: 81
	// public abstract void UpdateEnemyStatus(int damage, int threshold1, int threshold2, UnityAction onChaseModeCallback);

	// // RVA: -1 Offset: -1 Slot: 82
	// public abstract void ChangeEnemyLife(EnemyStatus.LifeType a_type);

	// // RVA: -1 Offset: -1 Slot: 83
	// public abstract void ChangeFaildEnemyStatus();

	// // RVA: -1 Offset: -1 Slot: 84
	void ShowEnemyCutin();

	// // RVA: -1 Offset: -1 Slot: 85
	// public abstract void SetPlayerDivaId(int divaId);

	// // RVA: -1 Offset: -1 Slot: 86
	// public abstract void SetRivalDivaId(int divaId);

	// // RVA: -1 Offset: -1 Slot: 87
	// public abstract void ShowBattleResult(bool isPlayerWin);

	// // RVA: -1 Offset: -1 Slot: 88
	bool IsWarmupEnd();

	// // RVA: -1 Offset: -1 Slot: 89
	// public abstract void SetLineAlpha(int lineNo, float alpha);

	// // RVA: -1 Offset: -1 Slot: 90
	// public abstract bool IsActiveLine(int lineNo);
}
