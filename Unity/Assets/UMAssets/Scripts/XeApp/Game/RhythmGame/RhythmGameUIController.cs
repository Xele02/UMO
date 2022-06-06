using UnityEngine;
using System;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameUIController : MonoBehaviour
	{
		// Fields
		//[CompilerGeneratedAttribute] // RVA: 0x68E5E8 Offset: 0x68E5E8 VA: 0x68E5E8
		// private GameUIIntro <intro>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x68E5F8 Offset: 0x68E5F8 VA: 0x68E5F8
		// private GameUIComplete <complete>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x68E608 Offset: 0x68E608 VA: 0x68E608
		// private GameUIFailed <failed>k__BackingField; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x68E618 Offset: 0x68E618 VA: 0x68E618
		// private IRhythmGameHUD <Hud>k__BackingField; // 0x18
		// private List<Animator> m_list_anim; // 0x1C
		// private List<ParticleSystem> m_list_particle; // 0x20
		// private List<EffectBundleControllerSimple> m_list_effect; // 0x24

		// // Properties
		// public GameUIIntro intro { get; set; }
		// public GameUIComplete complete { get; set; }
		// public GameUIFailed failed { get; set; }
		public IRhythmGameHUD Hud { get; set; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x745FC4 Offset: 0x745FC4 VA: 0x745FC4
		// // RVA: 0xC0C4B8 Offset: 0xC0C4B8 VA: 0xC0C4B8
		// public GameUIIntro get_intro() { }

		// [CompilerGeneratedAttribute] // RVA: 0x745FD4 Offset: 0x745FD4 VA: 0x745FD4
		// // RVA: 0xC0C4C0 Offset: 0xC0C4C0 VA: 0xC0C4C0
		// private void set_intro(GameUIIntro value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x745FE4 Offset: 0x745FE4 VA: 0x745FE4
		// // RVA: 0xC0C4C8 Offset: 0xC0C4C8 VA: 0xC0C4C8
		// public GameUIComplete get_complete() { }

		// [CompilerGeneratedAttribute] // RVA: 0x745FF4 Offset: 0x745FF4 VA: 0x745FF4
		// // RVA: 0xC0C4D0 Offset: 0xC0C4D0 VA: 0xC0C4D0
		// private void set_complete(GameUIComplete value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x746004 Offset: 0x746004 VA: 0x746004
		// // RVA: 0xC0C4D8 Offset: 0xC0C4D8 VA: 0xC0C4D8
		// public GameUIFailed get_failed() { }

		// [CompilerGeneratedAttribute] // RVA: 0x746014 Offset: 0x746014 VA: 0x746014
		// // RVA: 0xC0C4E0 Offset: 0xC0C4E0 VA: 0xC0C4E0
		// private void set_failed(GameUIFailed value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x746024 Offset: 0x746024 VA: 0x746024
		// // RVA: 0xBF2694 Offset: 0xBF2694 VA: 0xBF2694
		// public IRhythmGameHUD get_Hud() { }

		// [CompilerGeneratedAttribute] // RVA: 0x746034 Offset: 0x746034 VA: 0x746034
		// // RVA: 0xC0C4E8 Offset: 0xC0C4E8 VA: 0xC0C4E8
		// private void set_Hud(IRhythmGameHUD value) { }

		// // RVA: 0xC0C4F0 Offset: 0xC0C4F0 VA: 0xC0C4F0
		// public void Pause() { }

		// // RVA: 0xC0C8C0 Offset: 0xC0C8C0 VA: 0xC0C8C0
		// public void Resume() { }

		// // RVA: 0xC0CC90 Offset: 0xC0CC90 VA: 0xC0CC90
		public void OnAwake()
		{
			UnityEngine.Debug.LogWarning("TODO RhythmGameUIController.Awake");
		}

		// // RVA: 0xC0CC94 Offset: 0xC0CC94 VA: 0xC0CC94
		public void OnStart()
		{
			UnityEngine.Debug.LogWarning("TODO RhythmGameUIController.OnStart");
		}

		// // RVA: 0xC0CC98 Offset: 0xC0CC98 VA: 0xC0CC98
		// public void OnUpdate() { }

		// // RVA: 0xC0CC9C Offset: 0xC0CC9C VA: 0xC0CC9C
		// public void Initialize(RhythmGameResource resource, RhythmGamePlayer.Setting setting, RhythmGamePlayer.SettingMV mvSetting) { }

		// // RVA: 0xC0D81C Offset: 0xC0D81C VA: 0xC0D81C
		public void BeginIntroAnim(Action callback)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xBF2A8C Offset: 0xBF2A8C VA: 0xBF2A8C
		public void DeleteIntro()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xC0D874 Offset: 0xC0D874 VA: 0xC0D874
		// public void BeginFailedAnim(Action callback) { }

		// // RVA: 0xC0D8EC Offset: 0xC0D8EC VA: 0xC0D8EC
		// public void BeginRetryAnim(Action callback) { }

		// // RVA: 0xC0D964 Offset: 0xC0D964 VA: 0xC0D964
		// public void BeginCompleteAnim(Action callback, RhythmGameConsts.ResultComboType comboRank, bool isMvMode = False) { }

		// // RVA: 0xC0DBE4 Offset: 0xC0DBE4 VA: 0xC0DBE4
		// public void EndCompleteAnim() { }

		// // RVA: 0xC0DC10 Offset: 0xC0DC10 VA: 0xC0DC10
		// public void UpdateEnergy(int energy) { }

		// // RVA: 0xC0DCF0 Offset: 0xC0DCF0 VA: 0xC0DCF0
		// public void UpdateEnemyLife(int damage, int threshold1, int threshold2, UnityAction onChaseModeCallback) { }

		// // RVA: 0xC0DDFC Offset: 0xC0DDFC VA: 0xC0DDFC
		// public void UpdateEnemyDamageResult(int result, Vector3 position) { }

		// // RVA: 0xC0DF08 Offset: 0xC0DF08 VA: 0xC0DF08
		// public void UpdateCombo(int newCombo) { }

		// // RVA: 0xC0DFE8 Offset: 0xC0DFE8 VA: 0xC0DFE8
		// public void UpdateBattleCombo(int battleCombo) { }

		// // RVA: 0xC0E0C8 Offset: 0xC0E0C8 VA: 0xC0E0C8
		// public void EnterLIVESkill(LiveSkill skill, Material skillDesc, Material material) { }

		// // RVA: 0xC0E1C4 Offset: 0xC0E1C4 VA: 0xC0E1C4
		// public void ShowLIVESkill() { }

		// // RVA: 0xC0E29C Offset: 0xC0E29C VA: 0xC0E29C
		// public void AddBuffEffect(BuffEffect buff, int line) { }

		// // RVA: 0xC0E3E0 Offset: 0xC0E3E0 VA: 0xC0E3E0
		// public void DeleteBuffEffect(BuffEffect buff, int line) { }

		// // RVA: 0xC0E4E8 Offset: 0xC0E4E8 VA: 0xC0E4E8
		// public void DeleteBuffEffectTopPriorityFlagOnly(BuffEffect buff, int line) { }

		// // RVA: 0xC0E5F0 Offset: 0xC0E5F0 VA: 0xC0E5F0
		// public void DrawBuffEffectEnable(int line, bool flag) { }

		// // RVA: 0xC0E6D8 Offset: 0xC0E6D8 VA: 0xC0E6D8
		// public void EndActiveSkill() { }

		// // RVA: 0xBF2FC4 Offset: 0xBF2FC4 VA: 0xBF2FC4
		// public void ShowConfirmationWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback, DJBHIFLHJLK errorGotoTitle) { }

		// // RVA: 0xBF2E70 Offset: 0xBF2E70 VA: 0xBF2E70
		// public void ShowContinueWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback) { }

		// // RVA: 0xC0F378 Offset: 0xC0F378 VA: 0xC0F378
		// public void ShowReconfirmationWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback) { }

		// // RVA: 0xC0FBD8 Offset: 0xC0FBD8 VA: 0xC0FBD8
		// public void ShowPauseWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback) { }

		// // RVA: 0xC104CC Offset: 0xC104CC VA: 0xC104CC
		// public void ShowRetireConfirmationWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback) { }

		// // RVA: 0xC10730 Offset: 0xC10730 VA: 0xC10730
		// public void ShowSkipConfirmationWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback) { }

		// // RVA: 0xC10E9C Offset: 0xC10E9C VA: 0xC10E9C
		// public void ShowMvModePauseWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback) { }

		// // RVA: 0xC11608 Offset: 0xC11608 VA: 0xC11608
		// public void ShowMvModeEndConfirmWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callback) { }

		// // RVA: 0xC119E0 Offset: 0xC119E0 VA: 0xC119E0
		// public void ShowEndTutorialWindow(Action callback, bool isRetry) { }

		// // RVA: 0xC11A78 Offset: 0xC11A78 VA: 0xC11A78
		// private bool PlayPopupOpenSe(PopupWindowControl.SeType type) { }

		// // RVA: 0xC11B30 Offset: 0xC11B30 VA: 0xC11B30
		// private bool PlayPopupButtonSe(PopupButton.ButtonLabel label, PopupButton.ButtonType type) { }

		// // RVA: 0xBF1884 Offset: 0xBF1884 VA: 0xBF1884
		// public void ShowNotesDescriptionTutorialWindow(Action callback) { }

		// // RVA: 0xBF391C Offset: 0xBF391C VA: 0xBF391C
		// public void ShowFWaveDescriptionTutorialWindow(Action callback) { }

		// // RVA: 0xC11BF0 Offset: 0xC11BF0 VA: 0xC11BF0
		// public void ShowModeDescriptionTutorialWindow(Action callback) { }

		// // RVA: 0xBF3A24 Offset: 0xBF3A24 VA: 0xBF3A24
		// public void Show6LineDescriptionTutorialWindow(Action callback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x746044 Offset: 0x746044 VA: 0x746044
		// // RVA: 0xC11CF8 Offset: 0xC11CF8 VA: 0xC11CF8
		// private IEnumerator Co_Show6LineDescriptionTutorialWindow(Action callback) { }

		// // RVA: 0xC0FD2C Offset: 0xC0FD2C VA: 0xC0FD2C
		// private PopupSetting CreatePausePopupsetting() { }

		// // RVA: 0xC0E7B0 Offset: 0xC0E7B0 VA: 0xC0E7B0
		// private PopupSetting CreateConfirmationSetting(DJBHIFLHJLK errorGotoTitle) { }

		// // RVA: 0xC0F0F4 Offset: 0xC0F0F4 VA: 0xC0F0F4
		// private PopupSetting CreateContinueSetting() { }

		// // RVA: 0xC0EE70 Offset: 0xC0EE70 VA: 0xC0EE70
		// private PopupSetting CreateConfirmationSettingForStory() { }

		// // RVA: 0xC0F5DC Offset: 0xC0F5DC VA: 0xC0F5DC
		// private PopupSetting CreateRetirePopupsetting() { }

		// // RVA: 0xC0F954 Offset: 0xC0F954 VA: 0xC0F954
		// private PopupSetting CreateRetirePopupsettingForStory() { }

		// // RVA: 0xC10994 Offset: 0xC10994 VA: 0xC10994
		// private PopupSetting CreateSkipPopupsettingForStory() { }

		// // RVA: 0xC10C18 Offset: 0xC10C18 VA: 0xC10C18
		// private PopupSetting CreateSkipPopupsettingForTutorial() { }

		// // RVA: 0xC10FF0 Offset: 0xC10FF0 VA: 0xC10FF0
		// private PopupSetting CreateMvModePausePopupSetting() { }

		// // RVA: 0xC1175C Offset: 0xC1175C VA: 0xC1175C
		// private PopupSetting CreateMvModeEndConfirmPopupSetting() { }

		// // RVA: 0xC11D80 Offset: 0xC11D80 VA: 0xC11D80
		// public void .ctor() { }
	}
}
