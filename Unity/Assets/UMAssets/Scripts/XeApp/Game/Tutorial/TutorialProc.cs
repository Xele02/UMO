using System.Collections;
using XeApp.Game.Common;

namespace XeApp.Game.Tutorial
{
	public class TutorialProc
	{
		public const int PlateGrowthBeginnerMissionId = 5;
		public const int BeginnerMissionMusicId = 4;
		private const int LiveClearBeginnerMissionId = 1;
		private const int BeginnerMissionDivaSelectMissionId = 4;
		private const int HavePlateCount = 3;

		//// RVA: 0xE49B54 Offset: 0xE49B54 VA: 0xE49B54
		//public static bool CanAutoSettingHelp() { }

		//// RVA: 0xE49E78 Offset: 0xE49E78 VA: 0xE49E78
		//public static bool CanAutoSettingNavi() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AEDA8 Offset: 0x6AEDA8 VA: 0x6AEDA8
		//// RVA: 0xE49F64 Offset: 0xE49F64 VA: 0xE49F64
		//public static IEnumerator Co_TutorialAutoUnitSetting(ButtonBase autoSettingButton, Func<bool> waitAutoSettingWindowFunc) { }

		//// RVA: 0xE4A008 Offset: 0xE4A008 VA: 0xE4A008
		//public static bool CanUnit5Help(GameSetupData.MusicInfo musicInfo) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AEE20 Offset: 0x6AEE20 VA: 0x6AEE20
		//// RVA: 0xE4A170 Offset: 0xE4A170 VA: 0xE4A170
		//public static IEnumerator Co_TutorialUnit5(ButtonBase unitInfoChangeButton) { }

		//// RVA: 0xE4A1F8 Offset: 0xE4A1F8 VA: 0xE4A1F8
		//public static bool CanBeginnerMissionLiveClearLiveHelp() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AEE98 Offset: 0x6AEE98 VA: 0x6AEE98
		//// RVA: 0xE4A4C0 Offset: 0xE4A4C0 VA: 0xE4A4C0
		//public static IEnumerator Co_BeginnerMissionLiveClear(MusicSelectCDSelect cdSelect, MusicScrollView musicScrollView) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AEF10 Offset: 0x6AEF10 VA: 0x6AEF10
		//// RVA: 0xE4A588 Offset: 0xE4A588 VA: 0xE4A588
		//public static IEnumerator Co_OffeReleaseTutorial(InputLimitButton inputLimitButton, ButtonBase button, Action act, BasicTutorialMessageId messageId, bool IsInputLimit = True, MusicSelectCDSelect cdSelect, MusicScrollView musicScrollView) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AEF88 Offset: 0x6AEF88 VA: 0x6AEF88
		//// RVA: 0xE4A6AC Offset: 0xE4A6AC VA: 0xE4A6AC
		//public static IEnumerator Co_CostumeUpgrade(EBFLJMOCLNA.NDOPBOCEPJO type, ButtonBase button, BasicTutorialMessageId messageId, InputLimitButton limitButton = -1, TutorialPointer.Direction direction = 1) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF000 Offset: 0x6AF000 VA: 0x6AF000
		//// RVA: 0xE4A7C4 Offset: 0xE4A7C4 VA: 0xE4A7C4
		//public static IEnumerator Co_ValkyrieUpgrade(ButtonBase button, BasicTutorialMessageId messageId, InputLimitButton limitButton = -1, TutorialPointer.Direction direction = 1, MusicSelectCDSelect cdSelect, MusicScrollView musicScrollView) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF078 Offset: 0x6AF078 VA: 0x6AF078
		//// RVA: 0xE4A8D0 Offset: 0xE4A8D0 VA: 0xE4A8D0
		//public static IEnumerator Co_McrsLobby(HomeLobbyButtonController lobbyCtrl, Action proc) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF0F0 Offset: 0x6AF0F0 VA: 0x6AF0F0
		//// RVA: 0xE4A974 Offset: 0xE4A974 VA: 0xE4A974
		//public static IEnumerator Co_RaidFromMcrsLobby(ButtonBase button) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF168 Offset: 0x6AF168 VA: 0x6AF168
		//// RVA: 0xE4A9FC Offset: 0xE4A9FC VA: 0xE4A9FC
		//public static IEnumerator Co_Decolture(ButtonBase button, Action proc) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF1E0 Offset: 0x6AF1E0 VA: 0x6AF1E0
		//// RVA: 0xE4AAC4 Offset: 0xE4AAC4 VA: 0xE4AAC4
		//public static IEnumerator Co_RaidUseFoldRadar(ButtonBase button, Func<bool> waitPopupWindowFunc, IEnumerator popupItemGetColoutine, Func<int> waitRaidBossEncountFunc) { }

		//// RVA: 0xE4AB98 Offset: 0xE4AB98 VA: 0xE4AB98
		//public static bool CanBeginnerMissionLiveClearMissionList(TransitionList.Type prevType) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF258 Offset: 0x6AF258 VA: 0x6AF258
		//// RVA: 0xE4AE24 Offset: 0xE4AE24 VA: 0xE4AE24
		//public static IEnumerator Co_BeginnerMissionLiveClearMissionList() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF2D0 Offset: 0x6AF2D0 VA: 0x6AF2D0
		//// RVA: 0xE4AEB8 Offset: 0xE4AEB8 VA: 0xE4AEB8
		//public static IEnumerator Co_MusicOpenMission() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF348 Offset: 0x6AF348 VA: 0x6AF348
		//// RVA: 0xE4AF28 Offset: 0xE4AF28 VA: 0xE4AF28
		//public static IEnumerator Co_MusicOpenMissionPollingHideCursor() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF3C0 Offset: 0x6AF3C0 VA: 0x6AF3C0
		//// RVA: 0xE4AF98 Offset: 0xE4AF98 VA: 0xE4AF98
		//public static IEnumerator Co_PlateGrowth(ActionButton button) { }

		//// RVA: 0xE4B020 Offset: 0xE4B020 VA: 0xE4B020
		//public static bool CanDivaSelect(int missionId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF438 Offset: 0x6AF438 VA: 0x6AF438
		//// RVA: 0xE4B22C Offset: 0xE4B22C VA: 0xE4B22C
		//public static IEnumerator Co_DivaSelect(StayButton button) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF4B0 Offset: 0x6AF4B0 VA: 0x6AF4B0
		//// RVA: 0xE4B2D8 Offset: 0xE4B2D8 VA: 0xE4B2D8
		//public static IEnumerator Co_DivaSelect(UGUIStayButton button) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF528 Offset: 0x6AF528 VA: 0x6AF528
		//// RVA: 0xE4B384 Offset: 0xE4B384 VA: 0xE4B384
		//private static IEnumerator Co_DivaSelectMain(ButtonBase button) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF5A0 Offset: 0x6AF5A0 VA: 0x6AF5A0
		//// RVA: 0xE4B430 Offset: 0xE4B430 VA: 0xE4B430
		//public static IEnumerator Co_DivaSelectList(StayButton button, Func<bool> waitFunc) { }

		//// RVA: 0xE4B4F8 Offset: 0xE4B4F8 VA: 0xE4B4F8
		//public static bool CanDivaSelectAfter(int missionId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF618 Offset: 0x6AF618 VA: 0x6AF618
		//// RVA: 0xE4B708 Offset: 0xE4B708 VA: 0xE4B708
		//public static IEnumerator Co_DivaSlectAfter() { }

		//// RVA: 0xE4B79C Offset: 0xE4B79C VA: 0xE4B79C
		public static bool CanBeginnerAssistSelect()
		{
			TodoLogger.Log(0, "Tutorial CanBeginnerAssistSelect");
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF690 Offset: 0x6AF690 VA: 0x6AF690
		//// RVA: 0xE4BBA8 Offset: 0xE4BBA8 VA: 0xE4BBA8
		public static IEnumerator Co_AssistSelect(ActionButton button)
		{
			TodoLogger.Log(0, "Tutorial Co_AssistSelect");
			yield break;
		}

		//// RVA: 0xE4BC54 Offset: 0xE4BC54 VA: 0xE4BC54
		//public static bool IsUnlockTutorialInRank() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF708 Offset: 0x6AF708 VA: 0x6AF708
		//// RVA: 0xE4BEEC Offset: 0xE4BEEC VA: 0xE4BEEC
		//public static IEnumerator Co_GuideToHomePopup() { }
	}
}
