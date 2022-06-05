using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class PopupWindowManager : MonoBehaviour
	{
		// Fields
		private static PopupWindowControl[] s_controls; // 0x0
		private static List<int> s_popupIndexStack; // 0x4
		public static int starRank; // 0x8

		// Methods

		// // RVA: 0x1BACEE4 Offset: 0x1BACEE4 VA: 0x1BACEE4
		// public static PopupWindowControl Show(PopupSetting setting, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack, Action<IPopupContent, PopupTabButton.ButtonLabel> cotentUpdateCallBack, Action openStartCallBack, Action openEndCallBack, bool isButtonEnable = True, bool isShowBlack = True, bool isUnderFadePlane = False, Func<bool> closeWaitCallBack, Action endCallBaack, Func<PopupWindowControl.SeType, bool> playSeEvent, Func<PopupButton.ButtonLabel, PopupButton.ButtonType, bool> buttonSeEvent, Func<PopupButton.ButtonType, PopupButton.ButtonLabel, bool> closeStartWaitCallBack) { }

		// // RVA: 0x1BBFD84 Offset: 0x1BBFD84 VA: 0x1BBFD84
		// private static int SearchFreeIndex() { }

		// // RVA: 0x1BBFF64 Offset: 0x1BBFF64 VA: 0x1BBFF64
		// private static void SetTopPriority(int popupWindowIndex) { }

		// // RVA: 0x1BC031C Offset: 0x1BC031C VA: 0x1BC031C
		public static bool IsReady()
		{
			UnityEngine.Debug.LogWarning("TODO");
			return true;
		}

		// // RVA: 0x1BC0540 Offset: 0x1BC0540 VA: 0x1BC0540
		// public void OnDestroy() { }

		// // RVA: 0x1BC05E8 Offset: 0x1BC05E8 VA: 0x1BC05E8
		// public static bool IsActivePopupWindow() { }

		// // RVA: 0x1BC080C Offset: 0x1BC080C VA: 0x1BC080C
		// public static bool IsOpenPopupWindow() { }

		// // RVA: 0x1BC0A30 Offset: 0x1BC0A30 VA: 0x1BC0A30
		// public static void SetInputState(bool isEnable) { }

		// // RVA: 0x1BC0C8C Offset: 0x1BC0C8C VA: 0x1BC0C8C
		// public static void SetButtonState(bool isEnable) { }

		// // RVA: 0x1BC0E34 Offset: 0x1BC0E34 VA: 0x1BC0E34
		// public static void TopPopupPushNegativeOtherButton() { }

		// // RVA: 0x1BC104C Offset: 0x1BC104C VA: 0x1BC104C
		// public static ButtonBase FindTopPopupButton(PopupButton.ButtonType type) { }

		// // RVA: 0x1BC1274 Offset: 0x1BC1274 VA: 0x1BC1274
		// public static string FormatTextBank(MessageBank bank, string label, object[] args) { }

		// // RVA: 0x1BC12B8 Offset: 0x1BC12B8 VA: 0x1BC12B8
		// private static int PreCloseEndCallBack() { }

		// // RVA: 0x1BC14B8 Offset: 0x1BC14B8 VA: 0x1BC14B8
		// private static void CloseEndCallBack(int controlIndex) { }

		// // RVA: 0x1BC1670 Offset: 0x1BC1670 VA: 0x1BC1670
		// public static void Close(PopupWindowControl ignoreControl, Action endCallBack) { }

		// // RVA: 0x1BC190C Offset: 0x1BC190C VA: 0x1BC190C
		// public static TextPopupSetting CreateMessageBankTextContent(string bankName, string titleLabel, string messageLabel, SizeType size, ButtonInfo[] buttons) { }

		// // RVA: 0x1BC1AB0 Offset: 0x1BC1AB0 VA: 0x1BC1AB0
		// public static TextPopupSetting CrateTextContent(string title, SizeType size, string Message, ButtonInfo[] buttons, bool scrollable = False, bool isCaption = True) { }

		// // RVA: 0x1BC1BF4 Offset: 0x1BC1BF4 VA: 0x1BC1BF4
		// public static void OpenWeekRecoveryWindow(int freeMusicId, Action<int> recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack) { }

		// // RVA: 0x1BC23A8 Offset: 0x1BC23A8 VA: 0x1BC23A8
		// public static void OpenWeekRecoveryConfirmWindow(Action okCallBack, JFDNPFFOACP cancelCallBack, OnDenomChangeDate changeDateCallBack) { }

		// // RVA: 0x1BC272C Offset: 0x1BC272C VA: 0x1BC272C
		// public static void ApplyWeekRecovery(int freeMusicId, Action<int> recoveryCallBack, DJBHIFLHJLK errorCallBack) { }

		// // RVA: 0x1BC2900 Offset: 0x1BC2900 VA: 0x1BC2900
		// public static void OpenWeekRecoveryCompletionWindow(int recovery, Action closeCallBack) { }

		// // RVA: 0x1BC2BC8 Offset: 0x1BC2BC8 VA: 0x1BC2BC8
		// private static bool IsStaminaMax() { }

		// // RVA: 0x1BC2CE8 Offset: 0x1BC2CE8 VA: 0x1BC2CE8
		// public static void OpenStaminaWindow(DenominationManager denomControl, Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack) { }

		// // RVA: 0x1BC3048 Offset: 0x1BC3048 VA: 0x1BC3048
		// private static void OpenStaminaWindowHaveItem(List<ViewEnergyItemData> list, Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack) { }

		// // RVA: 0x1BC3DFC Offset: 0x1BC3DFC VA: 0x1BC3DFC
		// private static void OpenStaminaWindowHaveItem(ViewEnergyItemData item, Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack) { }

		// // RVA: 0x1BC3310 Offset: 0x1BC3310 VA: 0x1BC3310
		// private static void OpenStaminaWindowHaveStone(Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack) { }

		// // RVA: 0x1BC396C Offset: 0x1BC396C VA: 0x1BC396C
		// private static void OpenStaminaWindowNoneStone(DenominationManager denomControl, Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73F3B4 Offset: 0x73F3B4 VA: 0x73F3B4
		// // RVA: 0x1BC4484 Offset: 0x1BC4484 VA: 0x1BC4484
		// private static IEnumerator Co_PurchaseStaminaNoneItem(DenominationManager denomControl, Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack) { }

		// // RVA: 0x1BC4570 Offset: 0x1BC4570 VA: 0x1BC4570
		// public static void OpenNoneStaminaWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack) { }

		// // RVA: 0x1BC48D4 Offset: 0x1BC48D4 VA: 0x1BC48D4
		// public static void OpenUseAccountingItemWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack) { }

		// // RVA: 0x1BC4BD8 Offset: 0x1BC4BD8 VA: 0x1BC4BD8
		// public static void OpenUseGameItemWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack) { }

		// // RVA: 0x1BC4E84 Offset: 0x1BC4E84 VA: 0x1BC4E84
		// public static void OpenStaminaCompletionWindow(Action recoveryCallBack) { }

		// // RVA: 0x1BC51BC Offset: 0x1BC51BC VA: 0x1BC51BC
		// public static void OpenStaminaMaxWindow(Action endCallBack) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73F42C Offset: 0x73F42C VA: 0x73F42C
		// // RVA: 0x1BC54E8 Offset: 0x1BC54E8 VA: 0x1BC54E8
		// private static IEnumerator CacheClear(Action callback) { }

		// // RVA: 0x1BC5570 Offset: 0x1BC5570 VA: 0x1BC5570
		// public static void OpenCacheClearWindow(Action callback) { }

		// // RVA: 0x1BC587C Offset: 0x1BC587C VA: 0x1BC587C
		// private static void OpenCacheClearCheckWindow(Action callback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73F4A4 Offset: 0x73F4A4 VA: 0x73F4A4
		// // RVA: 0x1BC5B88 Offset: 0x1BC5B88 VA: 0x1BC5B88
		// private static IEnumerator CacheClearPopupShow(Action callback) { }

		// // RVA: 0x1BC5C10 Offset: 0x1BC5C10 VA: 0x1BC5C10
		// public static void ApplicationQuitPopupShow(Action cancelAction) { }

		// // RVA: 0x1BC5E74 Offset: 0x1BC5E74 VA: 0x1BC5E74
		// public static void ReviewStarPopupShow(MonoBehaviour mb, Action closeWaitCallback, int divaId = 1, int voiceId = 0) { }

		// // RVA: 0x1BC6294 Offset: 0x1BC6294 VA: 0x1BC6294
		// public static void OpinionPopupShow(MonoBehaviour mb, Action closeWaitCallback, int divaId = 1, int voiceId = 0, int starRank = 0) { }

		// // RVA: 0x1BC6634 Offset: 0x1BC6634 VA: 0x1BC6634
		// public static void ReviewPopupShow(MonoBehaviour mb, Action closeWaitCallback, int divaId = 1, int voiceId = 0, int starRank = 0) { }

		// // RVA: 0x1BC69D4 Offset: 0x1BC69D4 VA: 0x1BC69D4
		// public static void FanEntryConfirmPopupShow(string playerName, Action okCallback, Action cancelCallback, Action closeEndCallback) { }

		// // RVA: 0x1BC6D14 Offset: 0x1BC6D14 VA: 0x1BC6D14
		// public static void FanReleaseConfirmPopupShow(string playerName, Action okCallback, Action cancelCallback, Action closeEndCallback) { }

		// // RVA: 0x1BC7054 Offset: 0x1BC7054 VA: 0x1BC7054
		// public static void FanLimitPopupShow(Action closeEndCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73F51C Offset: 0x73F51C VA: 0x73F51C
		// // RVA: 0x1BC736C Offset: 0x1BC736C VA: 0x1BC736C
		// private static IEnumerator Co_ChooseNoThanks(int starRank, Action endCallBack) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73F594 Offset: 0x73F594 VA: 0x73F594
		// // RVA: 0x1BC7410 Offset: 0x1BC7410 VA: 0x1BC7410
		// private static IEnumerator Co_DoReview(int starRank, Action endCallBack) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73F60C Offset: 0x73F60C VA: 0x73F60C
		// // RVA: 0x1BC74B4 Offset: 0x1BC74B4 VA: 0x1BC74B4
		// private static IEnumerator Co_BugReport(int starRank, Action endCallBack) { }

		// // RVA: 0x1BC7558 Offset: 0x1BC7558 VA: 0x1BC7558
		// private static bool PlayPopupButtonSe(PopupButton.ButtonLabel label, PopupButton.ButtonType type) { }

		// // RVA: 0x1BC760C Offset: 0x1BC760C VA: 0x1BC760C
		// private static bool PlayReviewPopupButtonSe(PopupButton.ButtonLabel label, PopupButton.ButtonType type) { }

		// // RVA: 0x1BC7674 Offset: 0x1BC7674 VA: 0x1BC7674
		// public static PopupTabSetting CreateTabContents(Action<PopupTabContents> callback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73F684 Offset: 0x73F684 VA: 0x73F684
		// // RVA: 0x1BC7778 Offset: 0x1BC7778 VA: 0x1BC7778
		// private static IEnumerator TabContentsLoader(PopupTabSetting tabSetting, Action<PopupTabContents> callback) { }

		// // RVA: 0x1BC781C Offset: 0x1BC781C VA: 0x1BC781C
		// public void .ctor() { }

		// // RVA: 0x1BC7824 Offset: 0x1BC7824 VA: 0x1BC7824
		// private static void .cctor() { }
	}
}
