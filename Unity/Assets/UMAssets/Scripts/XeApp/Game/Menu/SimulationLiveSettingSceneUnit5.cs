using System.Collections;

namespace XeApp.Game.Menu
{
	public class SimulationLiveSettingSceneUnit5 : LiveBeforeSceneBaseUnit5
	{
		// private UGUIObject m_headButtonsObject; // 0x64
		// private UGUIObject m_prismSettingButtonsObject; // 0x68
		// private UGUIObject m_valkyrieButtonObject; // 0x6C
		// private UGUIObject m_musicInfoObject; // 0x70
		// private UGUIObject m_playButtonsObject; // 0x74
		// private UGUIObject m_prismUnitInfoObject; // 0x78
		// private SetDeckHeadButtons m_headButtons; // 0x7C
		// private SetDeckPrismSettingButtons m_prismSettingButtons; // 0x80
		// private SetDeckValkyrieButton m_valkyrieButton; // 0x84
		// private SetDeckMusicInfo m_musicInfo; // 0x88
		// private SetDeckPlayButtons m_playButtons; // 0x8C
		 //private SetDeckUnitInfoSLive m_prismUnitInfo; // 0x90
		 private ConfigMenu m_gameSettingMenu; // 0x94
		// private bool m_isWaitOnPostSetCanvas; // 0x98
		// private bool m_isWaitActivateScene; // 0x99
		// private bool m_isWaitExitAnimation; // 0x9A

		// // RVA: 0x12CD360 Offset: 0x12CD360 VA: 0x12CD360
		private void Awake()
		{
			SetupPrismPopupSetting();
			m_gameSettingMenu = ConfigMenu.Create(null);
			StartCoroutine(Co_LoadResource());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72743C Offset: 0x72743C VA: 0x72743C
		// // RVA: 0x12CD3A0 Offset: 0x12CD3A0 VA: 0x12CD3A0
		private IEnumerator Co_LoadResource()
		{
			//0x12D05EC
			yield return CreateUGUIObjectCache();
			IsReady = true;
		}

		// // RVA: 0x12CD44C Offset: 0x12CD44C VA: 0x12CD44C Slot: 16
		protected override void OnPreSetCanvas()
		{
			UnityEngine.Debug.LogError("TODO OnPreSetCanvas");
		}

		// // RVA: 0x12CE1A0 Offset: 0x12CE1A0 VA: 0x12CE1A0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			UnityEngine.Debug.LogError("TODO IsEndPreSetCanvas");
			return true;
		}

		// // RVA: 0x12CE228 Offset: 0x12CE228 VA: 0x12CE228 Slot: 18
		protected override void OnPostSetCanvas()
		{
			UnityEngine.Debug.LogError("TODO OnPostSetCanvas");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7274B4 Offset: 0x7274B4 VA: 0x7274B4
		// // RVA: 0x12CE24C Offset: 0x12CE24C VA: 0x12CE24C
		// private IEnumerator Co_OnPostSetCanvas() { }

		// // RVA: 0x12CE2F8 Offset: 0x12CE2F8 VA: 0x12CE2F8 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			UnityEngine.Debug.LogError("TODO IsEndPostSetCanvas");
			return true;
		}

		// // RVA: 0x12CE310 Offset: 0x12CE310 VA: 0x12CE310 Slot: 14
		protected override void OnDestoryScene()
		{
			UnityEngine.Debug.LogError("TODO OnDestoryScene");
		}

		// // RVA: 0x12CE610 Offset: 0x12CE610 VA: 0x12CE610 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			UnityEngine.Debug.LogError("TODO OnStartEnterAnimation");
		}

		// // RVA: 0x12CE7E8 Offset: 0x12CE7E8 VA: 0x12CE7E8 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			UnityEngine.Debug.LogError("TODO IsEndEnterAnimation");
			return true;
		}

		// // RVA: 0x12CE9BC Offset: 0x12CE9BC VA: 0x12CE9BC Slot: 12
		protected override void OnStartExitAnimation()
		{
			UnityEngine.Debug.LogError("TODO OnStartExitAnimation");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72752C Offset: 0x72752C VA: 0x72752C
		// // RVA: 0x12CE9E0 Offset: 0x12CE9E0 VA: 0x12CE9E0
		// private IEnumerator Co_ExitAnimation() { }

		// // RVA: 0x12CEA8C Offset: 0x12CEA8C VA: 0x12CEA8C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			UnityEngine.Debug.LogError("TODO IsEndExitAnimation");
			return true;
		}

		// // RVA: 0x12CEAA0 Offset: 0x12CEAA0 VA: 0x12CEAA0 Slot: 23
		protected override void OnActivateScene()
		{
			UnityEngine.Debug.LogError("TODO OnActivateScene");
		}

		// // RVA: 0x12CEB50 Offset: 0x12CEB50 VA: 0x12CEB50 Slot: 24
		protected override bool IsEndActivateScene()
		{
			UnityEngine.Debug.LogError("TODO IsEndActivateScene");
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7275A4 Offset: 0x7275A4 VA: 0x7275A4
		// // RVA: 0x12CEAC4 Offset: 0x12CEAC4 VA: 0x12CEAC4
		// private IEnumerator Co_ShowHelp() { }

		// // RVA: 0x12CD8A8 Offset: 0x12CD8A8 VA: 0x12CD8A8
		// private void InitializeUGUIObject() { }

		// // RVA: 0x12CE330 Offset: 0x12CE330 VA: 0x12CE330
		// private void FinalizeUGUIObject() { }

		// // RVA: 0x12CEB84 Offset: 0x12CEB84 VA: 0x12CEB84
		// private void ClearUGUIObjectListener() { }

		// // RVA: 0x12CECCC Offset: 0x12CECCC VA: 0x12CECCC
		// private void HideUGUIObject() { }

		// // RVA: 0x12CE1CC Offset: 0x12CE1CC VA: 0x12CE1CC
		// private bool IsApplyWait() { }

		// // RVA: 0x12CE7FC Offset: 0x12CE7FC VA: 0x12CE7FC
		// private bool IsPlaying() { }

		// // RVA: 0x12CEEB4 Offset: 0x12CEEB4 VA: 0x12CEEB4
		// private void OnClickGameSettingButton() { }

		// // RVA: 0x12CEF38 Offset: 0x12CEF38 VA: 0x12CEF38
		// private void OnClickOriginalSetting() { }

		// // RVA: 0x12CF0E8 Offset: 0x12CF0E8 VA: 0x12CF0E8
		// private void OnClickValkyrieButton() { }

		// // RVA: 0x12CF2A0 Offset: 0x12CF2A0 VA: 0x12CF2A0
		// private void OnClickPlayButton() { }

		// // RVA: 0x12CF308 Offset: 0x12CF308 VA: 0x12CF308
		// private void AdvanceGame() { }

		// // RVA: 0x12CF4F8 Offset: 0x12CF4F8 VA: 0x12CF4F8
		// private bool CheckSetAllDiva(AOJGDNFAIJL.AMIECPBIALP prismData) { }

		// // RVA: 0x12CF644 Offset: 0x12CF644 VA: 0x12CF644
		// private void NotSetAllDivaShow() { }

		// // RVA: 0x12CF9A8 Offset: 0x12CF9A8 VA: 0x12CF9A8
		// private void OnClickPrismIetms(PopupMvModeSelectListContent.SelectTarget target, int divaSlotNumber) { }

		// // RVA: 0x12CFB68 Offset: 0x12CFB68 VA: 0x12CFB68
		// private void StartApplyWait() { }

		// [IteratorStateMachineAttribute] // RVA: 0x72761C Offset: 0x72761C VA: 0x72761C
		// // RVA: 0x12CFB8C Offset: 0x12CFB8C VA: 0x12CFB8C
		// private IEnumerator Co_ApplyWait() { }

		// // RVA: 0x12CFC38 Offset: 0x12CFC38 VA: 0x12CFC38
		// private bool CheckTutorialCondition(TutorialConditionId conditionId) { }

		// [CompilerGeneratedAttribute] // RVA: 0x727694 Offset: 0x727694 VA: 0x727694
		// // RVA: 0x12CFD68 Offset: 0x12CFD68 VA: 0x12CFD68
		// private void <OnClickOriginalSetting>b__39_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7276A4 Offset: 0x7276A4 VA: 0x7276A4
		// // RVA: 0x12CFE44 Offset: 0x12CFE44 VA: 0x12CFE44
		// private void <OnClickValkyrieButton>b__40_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7276B4 Offset: 0x7276B4 VA: 0x7276B4
		// // RVA: 0x12CFE94 Offset: 0x12CFE94 VA: 0x12CFE94
		// private void <OnClickPrismIetms>b__45_0() { }
	}
}
