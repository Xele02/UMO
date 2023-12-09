using mcrs;
using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.AR;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class InheritingMenu : MonoBehaviour, IDisposable
	{
		public enum eSnsType
		{
			Facebook = 0,
			Twitter = 1,
			Line = 2,
		}

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
			m_inheritingSuccess = inheritingSuccess;
			this.StartCoroutineWatched(Co_MainFlow(isPreparation, inheritingSuccess, closeCallback, monthlylayout));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E588C Offset: 0x6E588C VA: 0x6E588C
		// // RVA: 0x13DE4EC Offset: 0x13DE4EC VA: 0x13DE4EC
		private IEnumerator Co_MainFlow(bool isPreparation, Action inheritingSuccess, Action closeCallback, LayoutMonthlyPassTakeover monthlylayout)
		{
			//0x13E1ECC
			bool done = false;
			bool cancel = false;
			bool error = false;
			HDEEBKIFLNI.HHCJCDFCLOB.NLCBOJBAJFB_GetLinkageStatuses(() =>
			{
				//0x13E0EE0
				done = true;
			}, () =>
			{
				//0x13E0EEC
				done = true;
				cancel = true;
			}, () =>
			{
				//0x13E0EF8
				error = true;
				done = true;
			});
			while (!done)
				yield return null;
			if(!error && !cancel)
			{
				done = false;
				error = false;
				if(!isPreparation)
				{
					this.StartCoroutineWatched(PopupShowInheritingMenuInner(false, () =>
					{
						//0x13E0F24
						done = true;
					}, monthlylayout));
					while(!done)
						yield return null;
				}
				else
				{
					PopupShowPreparationMenu(false, () =>
					{
						//0x13E0F08
						done = true;
					}, () =>
					{
						//0x13E0F14
						done = true;
						error = true;
					});
					while(!done)
						yield return null;
				}
			}
			if(error)
			{
				GotoTitle();
			}
			if (closeCallback != null)
				closeCallback();
		}

		// // RVA: 0x13DE5E4 Offset: 0x13DE5E4 VA: 0x13DE5E4
		// private void PopupShowInheritingMenu(bool isTitle = False, Action callback, LayoutMonthlyPassTakeover monthlylayout) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E5904 Offset: 0x6E5904 VA: 0x6E5904
		// // RVA: 0x13DE610 Offset: 0x13DE610 VA: 0x13DE610
		private IEnumerator PopupShowInheritingMenuInner(bool isTitle, Action callback, LayoutMonthlyPassTakeover monthlylayout)
		{
			//0x13E2CDC
			MessageBank bk = MessageManager.Instance.GetBank("common");
			PopupSnsInheritingSetting s = new PopupSnsInheritingSetting();
			s.TitleText = bk.GetMessageByLabel("popup_window_inh_title");
			s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } };
			s.WindowSize = SizeType.Large;
			s.IsTitle = isTitle;
			s.IsPreparation = false;
			s.ButtonCallbackTwitter = () =>
			{
				//0x13E0F38
				this.StartCoroutineWatched(SnsInheritingConfirmInner(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter, monthlylayout));
			};
			s.ButtonCallbackFacebook = () =>
			{
				//0x13E0F7C
				this.StartCoroutineWatched(SnsInheritingConfirmInner(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook, monthlylayout));
			};
			s.ButtonCallbackLine = () =>
			{
				//0x13E0FC0
				this.StartCoroutineWatched(SnsInheritingConfirmInner(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line, monthlylayout));
			};
			s.ButtonCallbackCaution = () =>
			{
				//0x13E1004
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				PopupShowCaution();
			};
			bool isPopupWait = true;
			m_snsCoopControl = PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13E0C1C
				return;
			}, null, () =>
			{
				//0x13E1078
				m_snsInheritingContent = m_snsCoopControl.Content as PopupSnsInheritingContent;
				m_snsInheritingContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Twitter, LayoutPopupSnsSetting.eButtonStatus.NotCoop);
				m_snsInheritingContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Facebook, LayoutPopupSnsSetting.eButtonStatus.NotCoop);
				m_snsInheritingContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Line, LayoutPopupSnsSetting.eButtonStatus.NotCoop);
				m_snsInheritingContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Apple, LayoutPopupSnsSetting.eButtonStatus.NotCoop);
			}, null, closeWaitCallBack:() =>
			{
				//0x13E1234
				isPopupWait = false;
				return true;
			});
			while (isPopupWait)
				yield return null;
			if (callback != null)
				callback();
		}

		// // RVA: 0x13DE708 Offset: 0x13DE708 VA: 0x13DE708
		private void PopupShowPreparationMenu(bool isTitle = false, Action callback = null, Action errorToTitle = null)
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			bool isTwitter = HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter);
			bool isFacebook = HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook);
			bool isLine = HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line);
			bool isApple = false;
			PopupSnsInheritingSetting s = new PopupSnsInheritingSetting();
			s.TitleText = bk.GetMessageByLabel("popup_inh_pre_title");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.WindowSize = SizeType.Large;
			s.IsTitle = isTitle;
			s.IsPreparation = true;
			s.ButtonCallbackTwitter = () =>
			{
				//0x13E1244
				this.StartCoroutineWatched(OptionWaitSNSCallback(this, eSnsType.Twitter, errorToTitle));
			};
			s.ButtonCallbackFacebook = () =>
			{
				//0x13E12BC
				this.StartCoroutineWatched(OptionWaitSNSCallback(this, eSnsType.Facebook, errorToTitle));
			};
			s.ButtonCallbackLine = () =>
			{
				//0x13E1334
				this.StartCoroutineWatched(OptionWaitSNSCallback(this, eSnsType.Line, errorToTitle));
			};
			s.ButtonCallbackCaution = () =>
			{
				//0x13E13AC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				PopupShowCaution();
			};
			m_snsCoopControl = PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13E1420
				if (callback != null)
					callback();
			}, null, () =>
			{
				//0x13E1434
				m_snsInheritingContent = (m_snsCoopControl.Content as PopupSnsInheritingContent);
				m_snsInheritingContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Twitter, isTwitter ? LayoutPopupSnsSetting.eButtonStatus.Release : LayoutPopupSnsSetting.eButtonStatus.NotCoop);
				m_snsInheritingContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Facebook, isFacebook ? LayoutPopupSnsSetting.eButtonStatus.Release : LayoutPopupSnsSetting.eButtonStatus.NotCoop);
				m_snsInheritingContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Line, isLine ? LayoutPopupSnsSetting.eButtonStatus.Release : LayoutPopupSnsSetting.eButtonStatus.NotCoop);
				m_snsInheritingContent.SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType.Apple, isApple ? LayoutPopupSnsSetting.eButtonStatus.Release : LayoutPopupSnsSetting.eButtonStatus.NotCoop);
			}, null);
		}

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
		private IEnumerator SnsInheritingConfirmInner(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink platform, LayoutMonthlyPassTakeover monthlylayout)
		{
			MessageBank msgBank; // 0x24
			bool isTwitter; // 0x28
			bool isFacebook; // 0x29
			bool isLine; // 0x2A
			bool isApple; // 0x2B

			//0x13E342C
			msgBank = MessageManager.Instance.GetBank("common");
			bool done = true;
			bool cancel = false;
			isTwitter = HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter);
			isFacebook = HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook);
			isLine = HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line);
			isApple = false;
			if(AREventMasterData.Instance != null && AREventMasterData.Instance.GetIntParam("master_sw", 0) == 1)
			{
				if(monthlylayout != null)
				{
					bool IsClose = false;
					yield return Co.R(SubscriptionCautionWindow(monthlylayout, () =>
					{
						//0x13E1A88
						IsClose = true;
					}));
					if (IsClose)
						yield break;
				}
			}
			if(!isFacebook && !isTwitter && !isLine && !isApple)
			{
				done = false;
				PopupWindowManager.Show(PopupWindowManager.CrateTextContent(msgBank.GetMessageByLabel("popup_inh_confirm_title"), SizeType.Small, msgBank.GetMessageByLabel("popup_inh_confirm_content_02"), new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, true, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x13E19FC
					if (label == PopupButton.ButtonLabel.Cancel)
						cancel = true;
				}, null, null, null, endCallBaack: () =>
				{
					//0x13E1A0C
					done = true;
				});
			}
			while (!done)
				yield return null;
			if(!cancel)
			{
				PopupWindowManager.Show(PopupWindowManager.CrateTextContent(msgBank.GetMessageByLabel("popup_inh_confirm_title"), SizeType.Small, msgBank.GetMessageByLabel("popup_inh_confirm_content_01"), new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, true, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x13E1A18
					if (label != PopupButton.ButtonLabel.Ok)
						return;
					this.StartCoroutineWatched(SnsInheritingInner(platform));
				}, null, null, null);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E59F4 Offset: 0x6E59F4 VA: 0x6E59F4
		// // RVA: 0x13DF354 Offset: 0x13DF354 VA: 0x13DF354
		private IEnumerator SubscriptionCautionWindow(LayoutMonthlyPassTakeover monthlylayout, Action PopupClose)
		{
			//0x13E412C
			bool IsOnClickButton = false;
			bool IsContracted = false;
			monthlylayout.transform.SetParent(GameManager.Instance.PopupCanvas.rootCanvas.transform);
			yield return null;
			monthlylayout.transform.localPosition = Vector3.zero;
			monthlylayout.SettingLayout(() =>
			{
				//0x13E1A9C
				IsOnClickButton = true;
				IsContracted = true;
				monthlylayout.Leave();
			}, () =>
			{
				//0x13E1AD0
				IsOnClickButton = true;
				IsContracted = false;
				monthlylayout.Leave();
			});
			monthlylayout.Enter();
			while (!IsOnClickButton)
				yield return null;
			yield return null;
			while (monthlylayout.IsPlaying())
				yield return null;
			yield return null;
			monthlylayout.transform.SetParent(transform);
			if (!IsContracted)
				yield break;
			IsOnClickButton = false;
			SubscriptionInheritancePopup(PopupClose, () =>
			{
				//0x13E1B04
				IsOnClickButton = true;
			});
			while (!IsOnClickButton)
				yield return null;
		}

		// // RVA: 0x13DF434 Offset: 0x13DF434 VA: 0x13DF434
		public void SubscriptionInheritancePopup(Action Close, Action OnClockButton)
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_inh_confirm_title");
			s.WindowSize = SizeType.Large;
			s.Text = bk.GetMessageByLabel("pop_subscription_data_confirmation_android_text");
			s.IsCaption = true;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13E1B10
				OnClockButton();
				if (label != PopupButton.ButtonLabel.Cancel)
					return;
				Close();
			}, null, null, null);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E5A6C Offset: 0x6E5A6C VA: 0x6E5A6C
		// // RVA: 0x13DF804 Offset: 0x13DF804 VA: 0x13DF804
		private IEnumerator SnsInheritingInner(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink platform)
		{
			//0x13E3D98
			m_snsCoopControl.InputDisable();
			bool done = false;
			bool error = false;
			bool cancel = false;
			HDEEBKIFLNI.HHCJCDFCLOB.AFOLPGDADKI(platform, () =>
			{
				//0x13E1B74
				done = true;
			}, () =>
			{
				//0x13E1B80
				done = true;
				cancel = true;
			}, () =>
			{
				//0x13E1B8C
				done = true;
				error = true;
			});
			while(!done)
				yield return null;
			m_snsCoopControl.InputEnable();
			if (!error)
			{
				if (!cancel)
					PopupShowSuccess();
			}
			else
				GotoTitle();
		}

		// // RVA: 0x13DF8CC Offset: 0x13DF8CC VA: 0x13DF8CC
		public void PopupShowCaution()
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_inh_caution_title"), SizeType.Large, bk.GetMessageByLabel("popup_inh_caution_content"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			}, true, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13E0ED0
				return;
			}, null, null, null);
		}

		// // RVA: 0x13DFC14 Offset: 0x13DFC14 VA: 0x13DFC14
		public void PopupShowSuccess()
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_inh_title_004"), SizeType.Middle, bk.GetMessageByLabel("popup_inh_pass_success"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13E0A0C
				if(label == PopupButton.ButtonLabel.Close)
				{
					if(MenuScene.Instance != null)
					{
						MenuScene.Instance.InputDisable();
						MenuScene.Instance.GotoTitle();
					}
				}
				IsOpen = false;
				if (m_inheritingSuccess != null)
					m_inheritingSuccess();
				m_snsCoopControl.Close(null, null);
			}, null, null, null);
		}

		// // RVA: 0x13DFE90 Offset: 0x13DFE90 VA: 0x13DFE90
		public void PopupShowSnsSuccess(eSnsType snsType, bool isLink = false)
		{
			string title = "";
			string msg = "";
			if(snsType == eSnsType.Facebook)
			{
				if(isLink)
				{
					title = "popup_facebook_release_success_title";
					msg = "popup_facebook_release_success";
				}
				else
				{
					title = "popup_facebook_title";
					msg = "popup_facebook_success";
				}
			}
			else if(snsType == eSnsType.Line)
			{
				if (isLink)
				{
					title = "popup_line_release_success_title";
					msg = "popup_line_release_success";
				}
				else
				{
					title = "popup_line_title";
					msg = "popup_line_success";
				}
			}
			else if (snsType == eSnsType.Twitter)
			{
				if (isLink)
				{
					title = "popup_twitter_release_success_title";
					msg = "popup_twitter_release_success";
				}
				else
				{
					title = "popup_twitter_title";
					msg = "popup_twitter_success";
				}
			}
			MessageBank bk = MessageManager.Instance.GetBank("common");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel(title), SizeType.Middle, bk.GetMessageByLabel(msg), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x13E0ED4
				return;
			}, null, null, null);
			
		}

		// // RVA: 0x13E02A8 Offset: 0x13E02A8 VA: 0x13E02A8 Slot: 4
		public void Dispose()
		{
			m_snsContent = null;
			m_snsInheritingContent = null;
			m_snsCoopControl = null;
			Destroy(gameObject);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E5AE4 Offset: 0x6E5AE4 VA: 0x6E5AE4
		// // RVA: 0x13E034C Offset: 0x13E034C VA: 0x13E034C
		// private IEnumerator WaitSNSCallback(InheritingMenu menu, InheritingMenu.eSnsType snsType, Action errorToTitle) { }

		// // RVA: 0x13E0420 Offset: 0x13E0420 VA: 0x13E0420
		private bool linkCheck(eSnsType snsType)
		{
			if(snsType == eSnsType.Facebook)
			{
				return HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook);
			}
			else if(snsType == eSnsType.Line)
			{
				return HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line);
			}
			else if(snsType == eSnsType.Twitter)
			{
				return HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked(HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter);
			}
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E5B5C Offset: 0x6E5B5C VA: 0x6E5B5C
		// // RVA: 0x13E04B8 Offset: 0x13E04B8 VA: 0x13E04B8
		private IEnumerator OptionWaitSNSCallback(InheritingMenu menu, eSnsType snsType, Action errorToTitle)
		{
			bool isLink;

			//0x13E2404
			menu.m_snsCoopControl.InputDisable();
			HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink[] platform = new HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink[3]
			{
				HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook,
				HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line,
				HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter
			};
			bool done = false;
			bool cancel = false;
			bool error = false;
			bool popCancel = false;
			isLink = linkCheck(snsType);
			LayoutPopupSnsSetting.eButtonStatus st;
			if (isLink)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				PopupSetting s = LinkRelesePopup(snsType, null);
				PopupButton.ButtonLabel butLabel = PopupButton.ButtonLabel.None;
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x13E1C2C
					butLabel = label;
					if(label == PopupButton.ButtonLabel.Cancel)
					{
						done = true;
						popCancel = true;
					}
					else if(label == PopupButton.ButtonLabel.Ok)
					{
						HDEEBKIFLNI.HHCJCDFCLOB.LEDGNMBOGJN(platform[(int)snsType], () =>
						{
							//0x13E1BFC
							done = true;
						}, () =>
						{
							//0x13E1C08
							done = true;
							cancel = true;
						}, () =>
						{
							//0x13E1C14
							done = true;
							error = true;
						});
					}
				}, null, null, null);
				while (!done)
					yield return null;
				st = LayoutPopupSnsSetting.eButtonStatus.NotCoop;
			}
			else
			{
				HDEEBKIFLNI.HHCJCDFCLOB.IEIDONOJCOB(platform[(int)snsType], () =>
				{
					//0x13E1BD4
					done = true;
				}, () =>
				{
					//0x13E1BE0
					done = true;
					cancel = true;
				}, () =>
				{
					//0x13E1BEC
					done = true;
					error = true;
				});
				while (!done)
					yield return null;
				st = LayoutPopupSnsSetting.eButtonStatus.Release;
			}
			menu.m_snsCoopControl.InputEnable();
			if(!popCancel)
			{
				if(!error && !cancel)
				{
					if(m_snsContent != null)
					{
						m_snsContent.SetButtonSnsStatus((LayoutPopupSnsSetting.eButtonType)snsType, st);
					}
					if(m_snsInheritingContent != null)
					{
						m_snsInheritingContent.SetButtonSnsStatus((LayoutPopupSnsSetting.eButtonType)snsType, st);
					}
					PopupShowSnsSuccess(snsType, isLink);
				}
				else
				{
					menu.m_snsCoopControl.Close(null, null);
					if (errorToTitle != null)
						errorToTitle();
				}
			}
		}

		// // RVA: 0x13E05B0 Offset: 0x13E05B0 VA: 0x13E05B0
		private PopupSetting LinkRelesePopup(eSnsType snsType, HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink[] platform)
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			switch(snsType)
			{
				case eSnsType.Facebook:
					return PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_facebook_release_check_title"), SizeType.Middle, bk.GetMessageByLabel("popup_facebook_release_check"), new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, true);
				case eSnsType.Twitter:
					return PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_twitter_release_check_title"), SizeType.Middle, bk.GetMessageByLabel("popup_twitter_release_check"), new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, true);
				case eSnsType.Line:
					return PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_line_release_check_title"), SizeType.Middle, bk.GetMessageByLabel("popup_line_release_check"), new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, true);
				default:
					return PopupWindowManager.CrateTextContent("", SizeType.Middle, "", new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, true);
			}
			
		}

		// // RVA: 0x13E0868 Offset: 0x13E0868 VA: 0x13E0868
		private void GotoTitle()
		{
			if(PopupWindowManager.IsOpenPopupWindow())
			{
				PopupWindowManager.Close(null, null);
			}
			if (MenuScene.Instance != null)
				MenuScene.Instance.GotoTitle();
			IsOpen = false;
		}
	}
}
