using System;
using System.Collections;
using XeSys;

namespace XeApp.Game.Tutorial
{
	public class TutorialManager : SingletonBehaviour<TutorialManager>
	{
		// private GameObject m_tutorialSetInstance; // 0xC
		// private bool m_isWait; // 0x10
		// private TutorialWindow m_window; // 0x14
		// private UnityAction m_closeCallBack; // 0x18
		// public static int forceShowTipsId; // 0x0

		// // RVA: 0xE4604C Offset: 0xE4604C VA: 0xE4604C
		// public static void Initialize() { }

		// // RVA: 0xE461F8 Offset: 0xE461F8 VA: 0xE461F8
		// public void PreLoadResource(UnityAction finishCb, bool isAppendLayout = False) { }

		// // RVA: 0xE462C8 Offset: 0xE462C8 VA: 0xE462C8 Slot: 6
		// public virtual void Release() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE758 Offset: 0x6AE758 VA: 0x6AE758
		// // RVA: 0xE463C4 Offset: 0xE463C4 VA: 0xE463C4
		public static IEnumerator TryShowTutorialCoroutine(Func<TutorialConditionId, bool> checker)
		{
			UnityEngine.Debug.LogError("TODO TryShowTutorialCoroutine");
			yield return null;
		}

		// // RVA: 0xE46470 Offset: 0xE46470 VA: 0xE46470
		// private static bool TutorialIdToSaveBitIndex(int id, int share, out int saveBitIndex) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE7D0 Offset: 0x6AE7D0 VA: 0x6AE7D0
		// // RVA: 0xE464B0 Offset: 0xE464B0 VA: 0xE464B0
		// public static IEnumerator ShowTutorial(int id, UnityAction endAction) { }

		// // RVA: 0xE46578 Offset: 0xE46578 VA: 0xE46578
		// private static void OnDummyBackButton() { }

		// // RVA: 0xE4657C Offset: 0xE4657C VA: 0xE4657C
		// public static bool IsAlreadyTutorial(TutorialConditionId conditionId) { }

		// // RVA: 0xE46958 Offset: 0xE46958 VA: 0xE46958
		// public static bool IsAlreadyTutorial(int tutorialId) { }

		// // RVA: 0xE46B6C Offset: 0xE46B6C VA: 0xE46B6C
		// private bool CheckTutorialCondition(TutorialConditionId condition, Func<TutorialConditionId, bool> checker) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE848 Offset: 0x6AE848 VA: 0x6AE848
		// // RVA: 0xE46BE8 Offset: 0xE46BE8 VA: 0xE46BE8
		// public IEnumerator ShowTutorialCoroutine(PJANOOPJIDE.HNHHGJCPMEA messData) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE8C0 Offset: 0x6AE8C0 VA: 0x6AE8C0
		// // RVA: 0xE46220 Offset: 0xE46220 VA: 0xE46220
		// private IEnumerator PreLoadLayoutCoroutine(UnityAction finishCb, bool isAppendLayout = False) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AE938 Offset: 0x6AE938 VA: 0x6AE938
		// // RVA: 0xE46CD0 Offset: 0xE46CD0 VA: 0xE46CD0
		// private IEnumerator LoadBaseLayoutCoroutine() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6AE9B0 Offset: 0x6AE9B0 VA: 0x6AE9B0
		// // RVA: 0xE46DE4 Offset: 0xE46DE4 VA: 0xE46DE4
		// private void <LoadBaseLayoutCoroutine>b__17_0(GameObject instance) { }
	}

	public enum TutorialConditionId
	{
		None = 0,
		Condition1 = 1,
		Condition2 = 2,
		Condition3 = 3,
		Condition4 = 4,
		Condition5 = 5,
		Condition6 = 6,
		Condition7 = 7,
		Condition8 = 8,
		Condition9 = 9,
		Condition10 = 10,
		Condition11 = 11,
		Condition12 = 12,
		Condition13 = 13,
		Condition14 = 14,
		Condition15 = 15,
		Condition16 = 16,
		Condition17 = 17,
		Condition18 = 18,
		Condition19 = 19,
		Condition20 = 20,
		Condition21 = 21,
		Condition22 = 22,
		Condition23 = 23,
		Condition24 = 24,
		Condition25 = 25,
		Condition26 = 26,
		Condition27 = 27,
		Condition28 = 28,
		Condition29 = 29,
		Condition30 = 30,
		Condition31 = 31,
		Condition32 = 32,
		Condition33 = 33,
		Condition34 = 34,
		Condition35 = 35,
		Condition36 = 36,
		Condition37 = 37,
		Condition38 = 38,
		Condition39 = 39,
		Condition40 = 40,
		Condition41 = 41,
		Condition42 = 42,
		Condition43 = 43,
		Condition44 = 44,
		Condition45 = 45,
		Condition46 = 46,
		Condition47 = 47,
		Condition48 = 48,
		Condition49 = 49,
		Condition50 = 50,
		Condition51 = 51,
		Condition52 = 52,
		Condition53 = 53,
		Condition54 = 54,
		Condition55 = 55,
		Condition56 = 56,
		Condition57 = 57,
		Condition58 = 58,
		Condition59 = 59,
		Condition60 = 60,
		Condition61 = 61,
		Condition62 = 62,
		Condition63 = 63,
		Condition64 = 64,
		Condition65 = 65,
		Condition66 = 66,
		Condition67 = 67,
		Condition68 = 68,
		Condition69 = 69,
		Condition70 = 70,
		Condition71 = 71,
		Condition72 = 72,
		Condition73 = 73,
		Condition74 = 74,
		Condition75 = 75,
		Condition76 = 76,
		Condition77 = 77,
		Condition78 = 78,
		Condition79 = 79,
		Condition80 = 80,
		Condition81 = 81,
		Condition82 = 82,
		Condition83 = 83,
		Condition84 = 84,
		Condition85 = 85,
		Condition86 = 86,
		Condition87 = 87,
		Condition88 = 88,
		Condition89 = 89,
		Condition90 = 90,
		Condition91 = 91,
		Condition92 = 92,
		Condition93 = 93,
		Condition94 = 94,
		SaveDataBitArrayPrevSize = 64,
		SaveDataBitArrayAddedSize = 64,
		SaveDataBitArraySize = 128,
		TutorialIdSaveOffset = 501,
		Condition95 = 95,
		Condition96 = 96,
	}

}
