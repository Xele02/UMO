using System;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class InheritingMenu : MonoBehaviour, IDisposable
	{
		private PopupSnsContent m_snsContent; // 0xC
		private PopupSnsInheritingContent m_snsInheritingContent; // 0x10
		private PopupWindowControl m_snsCoopControl; // 0x14
		private Action m_inheritingSuccess; // 0x18

		public bool IsOpen { get; private set; } // 0x1C

		// // RVA: 0x13DE1B8 Offset: 0x13DE1B8 VA: 0x13DE1B8
		public static InheritingMenu Create(Transform parent)
		{
			GameObject go = new GameObject("InheritingMenu");
			go.transform.SetParent(parent, false);
			return go.AddComponent<InheritingMenu>();
		}

		// // RVA: 0x13DE2A4 Offset: 0x13DE2A4 VA: 0x13DE2A4
		// public PopupWindowControl GetSnsCoopWindowControl() { }

		// // RVA: 0x13DE2BC Offset: 0x13DE2BC VA: 0x13DE2BC
		public void Awake()
		{
			return;
		}

		// // RVA: 0x13DE2C0 Offset: 0x13DE2C0 VA: 0x13DE2C0
		public void Start()
		{
			return;
		}

		// // RVA: 0x13DE2C4 Offset: 0x13DE2C4 VA: 0x13DE2C4
		// private void SetScreenOrientation(ConfigManager.eRotationType type) { }

		// // RVA: 0x13DE38C Offset: 0x13DE38C VA: 0x13DE38C
		// private void UndoScreenOrientation() { }

		// // RVA: 0x13DE478 Offset: 0x13DE478 VA: 0x13DE478
		// private void SetCurrentScreenOrientation() { }

		// // RVA: 0x13DE4B0 Offset: 0x13DE4B0 VA: 0x13DE4B0
		public void PopupShowMenu(bool isPreparation, Action inheritingSuccess, Action closeCallback, LayoutMonthlyPassTakeover monthlylayout)
		{
			TodoLogger.LogError(1, "PopupShowMenu");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E588C Offset: 0x6E588C VA: 0x6E588C
		// // RVA: 0x13DE4EC Offset: 0x13DE4EC VA: 0x13DE4EC
		// private IEnumerator Co_MainFlow(bool isPreparation, Action inheritingSuccess, Action closeCallback, LayoutMonthlyPassTakeover monthlylayout) { }

		// // RVA: 0x13DE5E4 Offset: 0x13DE5E4 VA: 0x13DE5E4
		// private void PopupShowInheritingMenu(bool isTitle = False, Action callback, LayoutMonthlyPassTakeover monthlylayout) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E5904 Offset: 0x6E5904 VA: 0x6E5904
		// // RVA: 0x13DE610 Offset: 0x13DE610 VA: 0x13DE610
		// private IEnumerator PopupShowInheritingMenuInner(bool isTitle, Action callback, LayoutMonthlyPassTakeover monthlylayout) { }

		// // RVA: 0x13DE708 Offset: 0x13DE708 VA: 0x13DE708
		// private void PopupShowPreparationMenu(bool isTitle = False, Action callback, Action errorToTitle) { }

		// // RVA: 0x13DECD4 Offset: 0x13DECD4 VA: 0x13DECD4
		public void PopupShowPreparationNotice(bool isTitle = false, Action callback = null, Action errorToTitle = null)
		{
			PopupSnsSetting setting = new PopupSnsSetting();
			setting.TitleText = MessageManager.Instance.GetBank("common").GetMessageByLabel("popup_inh_title_000");
			setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			setting.WindowSize = SizeType.Middle;
			setting.IsTitle = isTitle;
			setting.ButtonCallbackTwitter = () =>
			{
				//0x13E162C
				TodoLogger.LogNotImplemented("InheritingMenu.PopupShowPreparationNotice.ButtonCallbackTwitter");
			};
			setting.ButtonCallbackFacebook = () =>
			{
				//0x13E16A4
				TodoLogger.LogNotImplemented("InheritingMenu.PopupShowPreparationNotice.ButtonCallbackFacebook");
			};
			setting.ButtonCallbackLine = () =>
			{
				//0x13E171C
				TodoLogger.LogNotImplemented("InheritingMenu.PopupShowPreparationNotice.ButtonCallbackLine");
			};
			setting.ButtonCallbackShow = (bool status) =>
			{
				//0x13E0C20
				if(status)
				{
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().OFMECFHNCHA_Popup.PFCBKBFONJA_SetPopupNextShowTime(ILDKBCLAFPB.EHNBPANMAKA_Popup.FEGJEHDIEMM.HLFFEADNEHB_AccountBindPopup, Utility.GetCurrentUnixTime() + 2592000); // ??0x8d00  0x27
				}
				else
				{
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().OFMECFHNCHA_Popup.PFCBKBFONJA_SetPopupNextShowTime(ILDKBCLAFPB.EHNBPANMAKA_Popup.FEGJEHDIEMM.HLFFEADNEHB_AccountBindPopup, Utility.GetCurrentUnixTime());
				}
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			};
			m_snsCoopControl = PopupWindowManager.Show(setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13E1794
				if(callback != null)
					callback();
			}, null, () =>
			{
				//0x13E17A8
				m_snsContent = m_snsCoopControl.Content as PopupSnsContent;
				m_snsContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Twitter, HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line) ? LayoutPopupSnsSetting.eButtonStatus.Coop : LayoutPopupSnsSetting.eButtonStatus.NotCoop);
				m_snsContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Facebook, HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter) ? LayoutPopupSnsSetting.eButtonStatus.Coop : LayoutPopupSnsSetting.eButtonStatus.NotCoop);
				m_snsContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Line, HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook) ? LayoutPopupSnsSetting.eButtonStatus.Coop : LayoutPopupSnsSetting.eButtonStatus.NotCoop);
			}, null);
		}

		// // RVA: 0x13DF250 Offset: 0x13DF250 VA: 0x13DF250
		// private void SnsInheriting(HDEEBKIFLNI.DGNPPLKNCGH platform, LayoutMonthlyPassTakeover monthlylayout) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E597C Offset: 0x6E597C VA: 0x6E597C
		// // RVA: 0x13DF274 Offset: 0x13DF274 VA: 0x13DF274
		// private IEnumerator SnsInheritingConfirmInner(HDEEBKIFLNI.DGNPPLKNCGH platform, LayoutMonthlyPassTakeover monthlylayout) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E59F4 Offset: 0x6E59F4 VA: 0x6E59F4
		// // RVA: 0x13DF354 Offset: 0x13DF354 VA: 0x13DF354
		// private IEnumerator SubscriptionCautionWindow(LayoutMonthlyPassTakeover monthlylayout, Action PopupClose) { }

		// // RVA: 0x13DF434 Offset: 0x13DF434 VA: 0x13DF434
		// public void SubscriptionInheritancePopup(Action Close, Action OnClockButton) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E5A6C Offset: 0x6E5A6C VA: 0x6E5A6C
		// // RVA: 0x13DF804 Offset: 0x13DF804 VA: 0x13DF804
		// private IEnumerator SnsInheritingInner(HDEEBKIFLNI.DGNPPLKNCGH platform) { }

		// // RVA: 0x13DF8CC Offset: 0x13DF8CC VA: 0x13DF8CC
		// public void PopupShowCaution() { }

		// // RVA: 0x13DFC14 Offset: 0x13DFC14 VA: 0x13DFC14
		// public void PopupShowSuccess() { }

		// // RVA: 0x13DFE90 Offset: 0x13DFE90 VA: 0x13DFE90
		// public void PopupShowSnsSuccess(InheritingMenu.eSnsType snsType, bool isLink = False) { }

		// // RVA: 0x13E02A8 Offset: 0x13E02A8 VA: 0x13E02A8 Slot: 4
		public void Dispose()
		{
			TodoLogger.LogError(0, "Displose");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E5AE4 Offset: 0x6E5AE4 VA: 0x6E5AE4
		// // RVA: 0x13E034C Offset: 0x13E034C VA: 0x13E034C
		// private IEnumerator WaitSNSCallback(InheritingMenu menu, InheritingMenu.eSnsType snsType, Action errorToTitle) { }

		// // RVA: 0x13E0420 Offset: 0x13E0420 VA: 0x13E0420
		// private bool linkCheck(InheritingMenu.eSnsType snsType) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E5B5C Offset: 0x6E5B5C VA: 0x6E5B5C
		// // RVA: 0x13E04B8 Offset: 0x13E04B8 VA: 0x13E04B8
		// private IEnumerator OptionWaitSNSCallback(InheritingMenu menu, InheritingMenu.eSnsType snsType, Action errorToTitle) { }

		// // RVA: 0x13E05B0 Offset: 0x13E05B0 VA: 0x13E05B0
		// private PopupSetting LinkRelesePopup(InheritingMenu.eSnsType snsType, HDEEBKIFLNI.DGNPPLKNCGH[] platform) { }

		// // RVA: 0x13E0868 Offset: 0x13E0868 VA: 0x13E0868
		// private void GotoTitle() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6E5BD4 Offset: 0x6E5BD4 VA: 0x6E5BD4
		// // RVA: 0x13E0A0C Offset: 0x13E0A0C VA: 0x13E0A0C
		// private void <PopupShowSuccess>b__28_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }
	}
}
