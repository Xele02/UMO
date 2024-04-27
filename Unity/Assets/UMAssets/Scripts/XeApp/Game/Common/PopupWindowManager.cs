using UnityEngine;
using System.Collections.Generic;
using System;
using XeApp.Game.Menu;
using XeSys;
using System.Collections;

namespace XeApp.Game.Common
{
	public class PopupWindowManager : MonoBehaviour
	{
		private static PopupWindowControl[] s_controls; // 0x0
		private static List<int> s_popupIndexStack = new List<int>(); // 0x4
		public static int starRank = 0; // 0x8

		// // RVA: 0x1BACEE4 Offset: 0x1BACEE4 VA: 0x1BACEE4
		public static PopupWindowControl Show(PopupSetting setting, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack, Action<IPopupContent, PopupTabButton.ButtonLabel> cotentUpdateCallBack, Action openStartCallBack, Action openEndCallBack, bool isButtonEnable = true, bool isShowBlack = true, bool isUnderFadePlane = false, Func<bool> closeWaitCallBack = null, Action endCallBaack = null, Func<PopupWindowControl.SeType, bool> playSeEvent = null, Func<PopupButton.ButtonLabel, PopupButton.ButtonType, bool> buttonSeEvent = null, Func<PopupButton.ButtonType, PopupButton.ButtonLabel, bool> closeStartWaitCallBack = null)
		{
			if(s_controls == null)
			{
				s_controls = FindObjectsOfType<PopupWindowControl>();
			}
			int popupIndex = SearchFreeIndex();
			PopupWindowControl ctrl = s_controls[popupIndex];
			GameManager.Instance.ChangePopupPriority(!isUnderFadePlane);
			ctrl.m_callBack = buttonCallBack;
			ctrl.m_contentUpdateCallBack = cotentUpdateCallBack;
			ctrl.m_openStartCallBack = openStartCallBack;
			ctrl.m_openEndCallBack = openEndCallBack;
			ctrl.m_preCloseEndCallBack = PreCloseEndCallBack;
			ctrl.m_postCloseEndCallBack = CloseEndCallBack;
			ctrl.m_closeEndCallBack = endCallBaack;
			ctrl.m_closeWaitCallBack += closeWaitCallBack;
			ctrl.m_closeStartWaitCallBack = closeStartWaitCallBack;
			ctrl.PlayWindowOpenHandler = playSeEvent;
			ctrl.PlayPopupButtonSeHandler = buttonSeEvent;
			ctrl.Show(setting, isShowBlack, isButtonEnable, false);
			if(s_popupIndexStack.Count == 0)
			{
				if(MenuScene.Instance != null)
				{
					MenuScene.Instance.InputDisable();
				}
			}
			else
			{
				s_controls[s_popupIndexStack[s_popupIndexStack.Count - 1]].InputDisable();
			}
			SetTopPriority(popupIndex);
			s_popupIndexStack.Add(popupIndex);
			return ctrl;
		}

		// // RVA: 0x1BBFD84 Offset: 0x1BBFD84 VA: 0x1BBFD84
		private static int SearchFreeIndex()
		{
			for(int i = 0; i < s_controls.Length; i++)
			{
				if(!s_popupIndexStack.Contains(i) && !s_controls[i].IsActive)
					return i;

			}
			return -1;
		}

		// // RVA: 0x1BBFF64 Offset: 0x1BBFF64 VA: 0x1BBFF64
		private static void SetTopPriority(int popupWindowIndex)
		{
			int idx = s_controls[popupWindowIndex].transform.GetSiblingIndex();
			for(int i = 0; i < s_controls.Length; i++)
			{
				if(idx < s_controls[i].transform.GetSiblingIndex())
				{
					idx = s_controls[i].transform.GetSiblingIndex();
				}
			}
			s_controls[popupWindowIndex].transform.SetSiblingIndex(idx);
		}

		// // RVA: 0x1BC031C Offset: 0x1BC031C VA: 0x1BC031C
		public static bool IsReady()
		{
			if (s_controls == null)
			{
				s_controls = FindObjectsOfType<PopupWindowControl>();
			}
			for (int i = 0; i < s_controls.Length; i++)
			{
				if (!s_controls[i].IsReady())
					return false;
			}
			return true;
		}

		// // RVA: 0x1BC0540 Offset: 0x1BC0540 VA: 0x1BC0540
		public void OnDestroy()
		{
			s_controls = null;
			s_popupIndexStack = null;
		}

		// // RVA: 0x1BC05E8 Offset: 0x1BC05E8 VA: 0x1BC05E8
		public static bool IsActivePopupWindow()
		{
			if (s_controls == null)
			{
				s_controls = FindObjectsOfType<PopupWindowControl>();
			}
			for (int i = 0; i < s_controls.Length; i++)
			{
				if (s_controls[i].IsActivePopupWindow())
					return true;
			}
			return false;
		}

		// // RVA: 0x1BC080C Offset: 0x1BC080C VA: 0x1BC080C
		public static bool IsOpenPopupWindow()
		{
			if(s_controls == null)
			{
				s_controls = FindObjectsOfType<PopupWindowControl>();
			}
			for(int i = 0; i < s_controls.Length; i++)
			{
				if (s_controls[i].IsOpenPopupWindow())
					return true;
			}
			return false;
		}

		// // RVA: 0x1BC0A30 Offset: 0x1BC0A30 VA: 0x1BC0A30
		public static void SetInputState(bool isEnable)
		{
			if (s_controls == null)
				return;
			if(isEnable)
			{
				s_controls[s_popupIndexStack[s_popupIndexStack.Count - 1]].InputEnable();
			}
			else
			{
				s_controls[s_popupIndexStack[s_popupIndexStack.Count - 1]].InputDisable();
			}
		}

		// // RVA: 0x1BC0C8C Offset: 0x1BC0C8C VA: 0x1BC0C8C
		public static void SetButtonState(bool isEnable)
		{
			if (s_controls == null)
				return;
			s_controls[s_popupIndexStack[s_popupIndexStack.Count - 1]].SetButtonHiddenEnable(isEnable);
		}

		// // RVA: 0x1BC0E34 Offset: 0x1BC0E34 VA: 0x1BC0E34
		// public static void TopPopupPushNegativeOtherButton() { }

		// // RVA: 0x1BC104C Offset: 0x1BC104C VA: 0x1BC104C
		public static ButtonBase FindTopPopupButton(PopupButton.ButtonType type)
		{
			if (s_controls != null)
			{
				if(s_popupIndexStack.Count != 0)
				{
					return s_controls[s_popupIndexStack[s_popupIndexStack.Count - 1]].FindButton(type);
				}
			}
			return null;
		}

		// // RVA: 0x1BC1274 Offset: 0x1BC1274 VA: 0x1BC1274
		public static string FormatTextBank(MessageBank bank, string label, object[] args)
		{
			return string.Format(bank.GetMessageByLabel(label), args);
		}

		// // RVA: 0x1BC12B8 Offset: 0x1BC12B8 VA: 0x1BC12B8
		private static int PreCloseEndCallBack()
		{
			s_popupIndexStack.RemoveAt(s_popupIndexStack.Count - 1);
			if(s_popupIndexStack.Count != 0)
			{
				return s_popupIndexStack[s_popupIndexStack.Count - 1];
			}
			return -1;
		}

		// // RVA: 0x1BC14B8 Offset: 0x1BC14B8 VA: 0x1BC14B8
		private static void CloseEndCallBack(int controlIndex)
		{
			if(controlIndex < 0)
			{
				if(MenuScene.Instance == null)
					return;
				MenuScene.Instance.InputEnable();
				return;
			}
			s_controls[controlIndex].InputEnable();
		}

		// // RVA: 0x1BC1670 Offset: 0x1BC1670 VA: 0x1BC1670
		public static void Close(PopupWindowControl ignoreControl, Action endCallBack)
		{
			for(int i = s_popupIndexStack.Count - 1; i >= 0; i--)
			{
				if(ignoreControl != s_controls[s_popupIndexStack[i]])
				{
					s_controls[s_popupIndexStack[i]].Close(i == 0 ? endCallBack : null, null);
				}
			}
		}

		// // RVA: 0x1BC190C Offset: 0x1BC190C VA: 0x1BC190C
		public static TextPopupSetting CreateMessageBankTextContent(string bankName, string titleLabel, string messageLabel, SizeType size, ButtonInfo[] buttons)
		{
			TextPopupSetting res = new TextPopupSetting();
			res.TitleText = string.IsNullOrEmpty(titleLabel) ? "" : MessageManager.Instance.GetBank(bankName).GetMessageByLabel(titleLabel);
			res.IsCaption = !string.IsNullOrEmpty(titleLabel);
			res.WindowSize = size;
			res.Buttons = buttons;
			res.Text = MessageManager.Instance.GetBank(bankName).GetMessageByLabel(messageLabel);
			return res;
		}

		// // RVA: 0x1BC1AB0 Offset: 0x1BC1AB0 VA: 0x1BC1AB0
		public static TextPopupSetting CrateTextContent(string title, SizeType size, string Message, ButtonInfo[] buttons, bool scrollable = false, bool isCaption = true)
		{
			TextPopupSetting res = new TextPopupSetting();
			res.TitleText = title;
			res.WindowSize = size;
			res.Buttons = buttons;
			res.Text = Message;
			res.Scrollable = scrollable;
			res.IsCaption = isCaption;
			return res;
		}

		// // RVA: 0x1BC1BF4 Offset: 0x1BC1BF4 VA: 0x1BC1BF4
		public static void OpenWeekRecoveryWindow(int freeMusicId, Action<int> recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack)
		{
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 3);
			string name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId);
			int a1 = JGEOBNENMAH.HHCJCDFCLOB.BHOAOPKAPGD(freeMusicId);
			TextPopupSetting s;
			int a2 = JGEOBNENMAH.HHCJCDFCLOB.MFMPOFABICK();
			if(a2 < 1)
			{
				s = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_title_week_recovery_01"), SizeType.Small, string.Format(bk.GetMessageByLabel("popup_text_week_recovery_02"), name), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				}, false, true);
			}
			else
			{
				s = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_title_week_recovery_01"), SizeType.Small, string.Format(bk.GetMessageByLabel("popup_text_week_recovery_01"), new object[5]
				{
					name, 1, a1, a2, a2 - 1
				}), new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.UsedItem, Type = PopupButton.ButtonType.Positive }
				}, false, true);
			}
			PopupWindowManager.Show(s,(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1BC79A4
				if(!PGIGNJDPCAH.MNANNMDBHMP(() =>
				{
					//0x1BC7C30
					changeDateCallBack(TransitionList.Type.LOGIN_BONUS);
				}, () =>
				{
					//0x1BC7C60
					changeDateCallBack(TransitionList.Type.TITLE);
				}))
				{
					if(type == PopupButton.ButtonType.Positive)
					{
						if(JGEOBNENMAH.HHCJCDFCLOB.KKKHEOCDFAL(freeMusicId))
						{
							OpenWeekRecoveryConfirmWindow(() =>
							{
								//0x1BC7C90
								ApplyWeekRecovery(freeMusicId, recoveryCallBack, errorCallBack);
							}, cancelCallBack, changeDateCallBack);
						}
						else
						{
							ApplyWeekRecovery(freeMusicId, recoveryCallBack, errorCallBack);
						}
					}
					else if(type == PopupButton.ButtonType.Negative)
					{
						if(cancelCallBack != null)
							cancelCallBack();
					}
				}
			}, null, null, null);
		}

		// // RVA: 0x1BC23A8 Offset: 0x1BC23A8 VA: 0x1BC23A8
		public static void OpenWeekRecoveryConfirmWindow(Action okCallBack, JFDNPFFOACP cancelCallBack, OnDenomChangeDate changeDateCallBack)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 3);
			string name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId);
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(string.Format(bk.GetMessageByLabel("popup_title_week_recovery_02"), name), SizeType.Small, string.Format(bk.GetMessageByLabel("popup_text_week_recovery_04"), name), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1BC7D24
				if(!PGIGNJDPCAH.MNANNMDBHMP(() =>
				{
					//0x1BC7E88
					changeDateCallBack(TransitionList.Type.LOGIN_BONUS);
				}, () =>
				{
					//0x1BC7EB8
					changeDateCallBack(TransitionList.Type.TITLE);
				}))
				{
					if(type == PopupButton.ButtonType.Negative)
					{
						if(cancelCallBack != null)
							cancelCallBack();
					}
					else if(type == PopupButton.ButtonType.Positive)
					{
						if(okCallBack != null)
							okCallBack();
					}
				}
			}, null, null, null);
		}

		// // RVA: 0x1BC272C Offset: 0x1BC272C VA: 0x1BC272C
		public static void ApplyWeekRecovery(int freeMusicId, Action<int> recoveryCallBack, DJBHIFLHJLK errorCallBack)
		{
			int recovery = JGEOBNENMAH.HHCJCDFCLOB.BHOAOPKAPGD(freeMusicId);
			if(JGEOBNENMAH.HHCJCDFCLOB.IGJJIDDOOJO(freeMusicId))
			{
				MenuScene.Save(() =>
				{
					//0x1BC7EE8
					ILCCJNDFFOB.HHCJCDFCLOB.PLEKHHPMELF(freeMusicId, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 3), recovery);
					OpenWeekRecoveryCompletionWindow(recovery, () =>
					{
						//0x1BC806C
						if(recoveryCallBack != null)
							recoveryCallBack(recovery);
					});
				}, errorCallBack);
			}
			else
			{
				if(errorCallBack != null)
					errorCallBack();
			}
		}

		// // RVA: 0x1BC2900 Offset: 0x1BC2900 VA: 0x1BC2900
		public static void OpenWeekRecoveryCompletionWindow(int recovery, Action closeCallBack)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_title_week_recovery_01"), SizeType.Small, string.Format(bk.GetMessageByLabel("popup_text_week_recovery_03"), recovery), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1BC80DC
				if(closeCallBack != null)
					closeCallBack();
			}, null, null, null);
		}

		// // RVA: 0x1BC2BC8 Offset: 0x1BC2BC8 VA: 0x1BC2BC8
		private static bool IsStaminaMax()
		{
			return CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCBENCMNOGO_MaxStamina <= CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCLKMNGMIKC_GetCurrent(); 
		}

		// // RVA: 0x1BC2CE8 Offset: 0x1BC2CE8 VA: 0x1BC2CE8
		public static void OpenStaminaWindow(DenominationManager denomControl, Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack)
		{
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
            List<ViewEnergyItemData> l2 = ViewEnergyItemData.CreateList();
            List<ViewEnergyItemData> l = new List<ViewEnergyItemData>();
			for(int i = 0; i < l2.Count; i++)
			{
				if(l2[i].haveCount > 0)
				{
					l.Add(l2[i]);
				}
			}
			if(l.Count > 0)
			{
				OpenStaminaWindowHaveItem(l, recoveryCallBack, cancelCallBack, errorCallBack, changeDateCallBack);
			}
			else
			{
				if(CIOECGOMILE.HHCJCDFCLOB.FDFDGEMMKKJ())
				{
					OpenStaminaWindowHaveStone(recoveryCallBack, cancelCallBack, errorCallBack);
				}
				else
				{
					OpenStaminaWindowNoneStone(denomControl, recoveryCallBack, cancelCallBack, errorCallBack, changeDateCallBack);
				}
			}
		}

		// // RVA: 0x1BC3048 Offset: 0x1BC3048 VA: 0x1BC3048
		private static void OpenStaminaWindowHaveItem(List<ViewEnergyItemData> list, Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack)
		{
			ViewEnergyItemData item = list.Find((ViewEnergyItemData x) =>
			{
				//0x1BC793C
				return x.id == 2;
			});
			if(item == null)
			{
				item = list.Find((ViewEnergyItemData x) =>
				{
					//0x1BC796C
					return x.id == 1;
				});
			}
			OpenStaminaWindowHaveItem(item, recoveryCallBack, cancelCallBack, errorCallBack, changeDateCallBack);
		}

		// // RVA: 0x1BC3DFC Offset: 0x1BC3DFC VA: 0x1BC3DFC
		private static void OpenStaminaWindowHaveItem(ViewEnergyItemData item, Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int v = item.healValue;
			if(item.healValue == 0)
			{
				v = CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCBENCMNOGO_MaxStamina;
			}
			string s = string.Format(bk.GetMessageByLabel("popup_text_stamina_05"), new object[5]
			{
				item.name, "1", v, item.haveCount, item.haveCount - 1
			});
			Show(CrateTextContent(bk.GetMessageByLabel("popup_title_stamina_01"), SizeType.Small, s, new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.UsedItem, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1BC80F0
				if(label == PopupButton.ButtonLabel.Cancel)
				{
					if(cancelCallBack != null)
						cancelCallBack();
				}
				else if(label == PopupButton.ButtonLabel.UsedItem)
				{
					if(IsStaminaMax())
					{
						OpenStaminaMaxWindow(() =>
						{
							//0x1BC83F0
							if(cancelCallBack != null)
								cancelCallBack();
						});
					}
					else
					{
						if(!PGIGNJDPCAH.MNANNMDBHMP(() =>
						{
							//0x1BC8404
							changeDateCallBack(TransitionList.Type.LOGIN_BONUS);
						}, () =>
						{
							//0x1BC8434
							changeDateCallBack(TransitionList.Type.TITLE);
						}))
						{
							CIOECGOMILE.HHCJCDFCLOB.GNNHEDHCJAE(EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem, item.id, () =>
							{
								//0x1BC8464
								OpenStaminaCompletionWindow(recoveryCallBack);
							}, cancelCallBack, cancelCallBack, errorCallBack, JpStringLiterals.StringLiteral_14401);
						}
					}
				}
			}, null, null, null);
		}

		// // RVA: 0x1BC3310 Offset: 0x1BC3310 VA: 0x1BC3310
		private static void OpenStaminaWindowHaveStone(Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupUseStoneSetting s = new PopupUseStoneSetting();
			s.TitleText = bk.GetMessageByLabel("popup_title_stamina_01");
			s.WindowSize = SizeType.Small;
			s.Text = string.Format(bk.GetMessageByLabel("popup_text_stamina_01"), new object[4]
			{
				CIOECGOMILE.HHCJCDFCLOB.CIPHAHDGGPH(),
				CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCBENCMNOGO_MaxStamina,
				CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency(),
				CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency() - CIOECGOMILE.HHCJCDFCLOB.CIPHAHDGGPH()
			});
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.UsedChargesItem, Type = PopupButton.ButtonType.Positive }
			};
			s.GotoTitleListener = errorCallBack;
			Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1BC84E8
				if(label == PopupButton.ButtonLabel.Cancel)
				{
					if(cancelCallBack != null)
						cancelCallBack();
				}
				else if(label == PopupButton.ButtonLabel.UsedChargesItem)
				{
					if(IsStaminaMax())
					{
						OpenStaminaMaxWindow(() =>
						{
							//0x1BC86FC
							if(cancelCallBack != null)
								cancelCallBack();
						});
					}
					else
					{
						CIOECGOMILE.HHCJCDFCLOB.GNNHEDHCJAE(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 0, () =>
						{
							//0x1BC8710
							OpenStaminaCompletionWindow(recoveryCallBack);
						}, cancelCallBack, cancelCallBack, errorCallBack, JpStringLiterals.StringLiteral_14401);
					}
				}
			}, null, null, null);
		}

		// // RVA: 0x1BC396C Offset: 0x1BC396C VA: 0x1BC396C
		private static void OpenStaminaWindowNoneStone(DenominationManager denomControl, Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_title_stamina_01");
			s.WindowSize = SizeType.Small;
			s.Text = string.Format(bk.GetMessageByLabel("popup_text_stamina_02"), CIOECGOMILE.HHCJCDFCLOB.CIPHAHDGGPH(), CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCBENCMNOGO_MaxStamina);
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Purchase, Type = PopupButton.ButtonType.Positive }
			};
			Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1BC8794
				if(label == PopupButton.ButtonLabel.Purchase)
				{
					control.StartCoroutineWatched(Co_PurchaseStaminaNoneItem(denomControl, recoveryCallBack, cancelCallBack, errorCallBack, changeDateCallBack));
				}
				else
				{
					if(cancelCallBack != null)
						cancelCallBack();
				}
			}, null, null, null);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73F3B4 Offset: 0x73F3B4 VA: 0x73F3B4
		// // RVA: 0x1BC4484 Offset: 0x1BC4484 VA: 0x1BC4484
		private static IEnumerator Co_PurchaseStaminaNoneItem(DenominationManager denomControl, Action recoveryCallBack, JFDNPFFOACP cancelCallBack, DJBHIFLHJLK errorCallBack, OnDenomChangeDate changeDateCallBack)
		{
			bool isChangeDate;

			//0x1389C14
			TransitionList.Type result = TransitionList.Type.UNDEFINED;
			isChangeDate = PGIGNJDPCAH.MNANNMDBHMP(() =>
			{
				//0x1BC8898
				result = TransitionList.Type.LOGIN_BONUS;
			}, () =>
			{
				//0x1BC88A4
				result = TransitionList.Type.TITLE;
			});
			yield return null;
			if(!isChangeDate)
			{
                DenominationManager cont = denomControl;
                if (cont != null)
				{
					cont.StartPurchaseSequence(() =>
					{
						//0x1BC88C4
						OpenStaminaWindowHaveStone(recoveryCallBack, cancelCallBack, errorCallBack);
					}, () =>
					{
						//0x1BC8958
						OpenStaminaWindowNoneStone(cont, recoveryCallBack, cancelCallBack, errorCallBack, changeDateCallBack);
					}, errorCallBack, changeDateCallBack, null);
				}
			}
			else
			{
				yield return new WaitWhile(() =>
				{
					//0x1BC88B0
					return result == TransitionList.Type.UNDEFINED;
				});
				if(changeDateCallBack != null)
					changeDateCallBack(result);
			}
		}

		// // RVA: 0x1BC4570 Offset: 0x1BC4570 VA: 0x1BC4570
		// public static void OpenNoneStaminaWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack) { }

		// // RVA: 0x1BC48D4 Offset: 0x1BC48D4 VA: 0x1BC48D4
		// public static void OpenUseAccountingItemWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack) { }

		// // RVA: 0x1BC4BD8 Offset: 0x1BC4BD8 VA: 0x1BC4BD8
		// public static void OpenUseGameItemWindow(Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack) { }

		// // RVA: 0x1BC4E84 Offset: 0x1BC4E84 VA: 0x1BC4E84
		public static void OpenStaminaCompletionWindow(Action recoveryCallBack)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			Show(CrateTextContent(bk.GetMessageByLabel("popup_title_stamina_01"), SizeType.Small, string.Format(bk.GetMessageByLabel("popup_text_stamina_03"), CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCLKMNGMIKC_GetCurrent()), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1BC8BD8
				recoveryCallBack();
			}, null, null, null);
		}

		// // RVA: 0x1BC51BC Offset: 0x1BC51BC VA: 0x1BC51BC
		public static void OpenStaminaMaxWindow(Action endCallBack)
		{
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			Show(CrateTextContent(bk.GetMessageByLabel("popup_title_stamina_01"), 
			SizeType.Small, bk.GetMessageByLabel("popup_text_stamina_04"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1BC8C04
				if(endCallBack != null)
					endCallBack();
			}, null, null, null);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73F42C Offset: 0x73F42C VA: 0x73F42C
		// // RVA: 0x1BC54E8 Offset: 0x1BC54E8 VA: 0x1BC54E8
		private static IEnumerator CacheClear(Action callback)
		{
			//0x1388544
			if(MenuScene.Instance != null)
			{
				SoundManager.Instance.bgmPlayer.Stop();
				SoundManager.Instance.voDiva.Stop();
				while (SoundManager.Instance.bgmPlayer.isPlaying)
					yield return null;
				while (SoundManager.Instance.voDiva.isPlaying)
					yield return null;
				SoundManager.Instance.bgmPlayer.RemoveCueSheet();
				SoundManager.Instance.voPilot.RemoveCueSheet();
				SoundManager.Instance.voDiva.RemoveCueSheet();
				SoundManager.Instance.voDivaCos.RemoveCueSheet();
				SoundManager.Instance.voSeasonEvent.RemoveCueSheet();
			}
			//LAB_01388a60
			KEHOJEJMGLJ.HHCJCDFCLOB.OANLHPBJIND();
			GameManager.Instance.StartCoroutineWatched(CacheClearPopupShow(callback));
		}

		// // RVA: 0x1BC5570 Offset: 0x1BC5570 VA: 0x1BC5570
		public static void OpenCacheClearWindow(Action callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			Show(CrateTextContent(bk.GetMessageByLabel("cache_clear_02"), SizeType.Middle, bk.GetMessageByLabel("cache_clear_00"), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.CacheClear, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1BC8C18
				if (type != PopupButton.ButtonType.Positive)
					return;
				OpenCacheClearCheckWindow(callback);
			}, null, null, null);
		}

		// // RVA: 0x1BC587C Offset: 0x1BC587C VA: 0x1BC587C
		private static void OpenCacheClearCheckWindow(Action callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			Show(CrateTextContent(bk.GetMessageByLabel("cache_clear_02"), SizeType.Middle, bk.GetMessageByLabel("cache_clear_05"), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1BC8CA8
				if (type != PopupButton.ButtonType.Positive)
					return;
				if(MenuScene.Instance != null)
				{
					MenuScene.Instance.InputDisable();
				}
				GameManager.Instance.StartCoroutineWatched(CacheClear(callback));
			}, null, null, null);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73F4A4 Offset: 0x73F4A4 VA: 0x73F4A4
		// // RVA: 0x1BC5B88 Offset: 0x1BC5B88 VA: 0x1BC5B88
		private static IEnumerator CacheClearPopupShow(Action callback)
		{
			//0x1388F60
			yield return null;
			MessageBank bk = MessageManager.Instance.GetBank("common");
			Show(CrateTextContent(bk.GetMessageByLabel("cache_clear_03"), SizeType.Middle, bk.GetMessageByLabel(MenuScene.Instance != null ? "cache_clear_04" : "cache_clear_01"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
			{
				//0x1387DB4
				if (callback != null)
					callback();
				callback = null;
			}, null, null, null);
		}

		// // RVA: 0x1BC5C10 Offset: 0x1BC5C10 VA: 0x1BC5C10
		public static void ApplicationQuitPopupShow(Action cancelAction)
		{
			Show(CreateMessageBankTextContent("menu", "pupup_app_exit_title", "popup_app_exit", SizeType.Small, new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1387DE8
				if(type == PopupButton.ButtonType.Positive)
					Application.Quit();
				else
				{
					if(cancelAction != null)
						cancelAction();
				}
			}, null, null, null);
		}

		// // RVA: 0x1BC5E74 Offset: 0x1BC5E74 VA: 0x1BC5E74
		public static void ReviewStarPopupShow(MonoBehaviour mb, Action closeWaitCallback, int divaId = 1, int voiceId = 0)
		{
			if(!KNHHNMFCJEN.AIGMIEKPPAD())
			{
				if(closeWaitCallback != null)
					closeWaitCallback();
			}
			else
			{
				TodoLogger.LogError(TodoLogger.UMOSkip, "ReviewStarPopupShow");
				if (closeWaitCallback != null)
					closeWaitCallback();
			}
		}

		// // RVA: 0x1BC6294 Offset: 0x1BC6294 VA: 0x1BC6294
		// public static void OpinionPopupShow(MonoBehaviour mb, Action closeWaitCallback, int divaId = 1, int voiceId = 0, int starRank = 0) { }

		// // RVA: 0x1BC6634 Offset: 0x1BC6634 VA: 0x1BC6634
		// public static void ReviewPopupShow(MonoBehaviour mb, Action closeWaitCallback, int divaId = 1, int voiceId = 0, int starRank = 0) { }

		// // RVA: 0x1BC69D4 Offset: 0x1BC69D4 VA: 0x1BC69D4
		public static void FanEntryConfirmPopupShow(string playerName, Action okCallback, Action cancelCallback, Action closeEndCallback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_lobby_member_fanregister_title");
			s.Text = string.Format(bk.GetMessageByLabel("pop_lobby_member_fanregister_desc"), playerName);
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0x13881C4
				if(t == PopupButton.ButtonType.Negative)
				{
					if(cancelCallback != null)
						cancelCallback();
				}
				else if(t == PopupButton.ButtonType.Positive)
				{
					if(okCallback != null)
						okCallback();
				}
			}, null, null, null, endCallBaack:closeEndCallback);
		}

		// // RVA: 0x1BC6D14 Offset: 0x1BC6D14 VA: 0x1BC6D14
		public static void FanReleaseConfirmPopupShow(string playerName, Action okCallback, Action cancelCallback, Action closeEndCallback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_lobby_member_fan_unregister_title");
			s.Text = string.Format(bk.GetMessageByLabel("pop_lobby_member_fan_unregister_desc"), playerName);
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0x13881FC
				if(t == PopupButton.ButtonType.Negative)
				{
					if(cancelCallback != null)
						cancelCallback();
				}
				else if(t == PopupButton.ButtonType.Positive)
				{
					if(okCallback != null)
						okCallback();
				}
			}, null, null, null, endCallBaack:closeEndCallback);
		}

		// // RVA: 0x1BC7054 Offset: 0x1BC7054 VA: 0x1BC7054
		public static void FanLimitPopupShow(Action closeEndCallback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_lobby_member_fan_capacityover_title");
			s.Text = bk.GetMessageByLabel("pop_lobby_member_capacityover_desc");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0x1BC79A0
				return;
			}, null, null, null, endCallBaack:closeEndCallback);
		}

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
		public static PopupTabSetting CreateTabContents(Action<PopupTabContents> callback)
		{
			PopupTabSetting res = new PopupTabSetting();
			GameManager.Instance.StartCoroutineWatched(TabContentsLoader(res, callback));
			return res;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73F684 Offset: 0x73F684 VA: 0x73F684
		// // RVA: 0x1BC7778 Offset: 0x1BC7778 VA: 0x1BC7778
		private static IEnumerator TabContentsLoader(PopupTabSetting tabSetting, Action<PopupTabContents> callback)
		{
			//0x138A144
			PopupTabContents tabContents = null;
			bool isLoading = false;
			ResourcesManager.Instance.Load(tabSetting.PrefabPath, (FileResultObject fro) =>
			{
				//0x13883F0
				GameObject g = Instantiate(fro.unityObject) as GameObject;
				tabSetting.SetContent(g);
				tabContents = g.GetComponent<PopupTabContents>();
				isLoading = true;
				return true;
			});
			while (!isLoading)
				yield return null;
			callback(tabContents);
		}
	}
}
