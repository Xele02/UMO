using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public delegate void OnDenomChangeDate(TransitionList.Type type);
	public delegate bool ProductListFilter(LGDNAJACFHI data);

	public class DenominationManager : MonoBehaviour
	{
		public enum Response
		{
			Success = 0,
			Cancel = 1,
			Error = 2,
		}

		public delegate void ResponseHandler(Response response);

		private static GameObject sm_GameObject; // 0x0
		private DJBHIFLHJLK errorHandler; // 0xC
		private OnDenomChangeDate m_OnChangeDate; // 0x10
		private ProductListFilter m_productListFilter; // 0x14
		private bool m_IsChangeDate; // 0x18
		private AMOCLPHDGBP m_paidVCPurchase; // 0x1C
		private List<ResponseHandler> m_responceHandlerList = new List<ResponseHandler>(); // 0x20

		// // RVA: 0x17CF4F0 Offset: 0x17CF4F0 VA: 0x17CF4F0
		public static DenominationManager Create(Transform parent)
		{
			if(sm_GameObject == null)
			{
				sm_GameObject = new GameObject("DenominationManager");
				sm_GameObject.AddComponent<DenominationManager>();
			}
			sm_GameObject.transform.SetParent(parent, false);
			return sm_GameObject.GetComponent<DenominationManager>();
		}

		// // RVA: 0x17CF744 Offset: 0x17CF744 VA: 0x17CF744
		public void OnDestroy()
		{
			sm_GameObject = null;
			m_paidVCPurchase = null;
		}

		// // RVA: 0x17CF7DC Offset: 0x17CF7DC VA: 0x17CF7DC
		public void StartPurchaseSequence(IMCBBOAFION onSuccess, JFDNPFFOACP onCancel, DJBHIFLHJLK onError, OnDenomChangeDate onChangeDate, ProductListFilter filter)
		{
			GameManager.Instance.CloseSnsNotice();
			m_paidVCPurchase = new AMOCLPHDGBP();
			m_paidVCPurchase.MKDKKDNBEEK = OnOpenVCProducts;
			m_paidVCPurchase.AJGKLIIDKHA = OnOpenBirthdayRegistration;
			m_paidVCPurchase.FIJMBKFJJIJ = OnOpenBirthdayRegistrationConfirm;
			errorHandler = onError;
			m_OnChangeDate = (TransitionList.Type type) =>
			{
				//0x17D0DE8
				m_IsChangeDate = true;
				onChangeDate(type);
			};
			m_productListFilter = filter;
			m_IsChangeDate = false;
			m_paidVCPurchase.DCDPMEPNKND(() =>
			{
				//0x17D0E3C
				this.StartCoroutineWatched(PopupDenomination.Co_ClosePopup(() =>
				{
					//0x17D0F4C
					if(onSuccess != null)
					{
						onSuccess();
					}
					CallResponseHandler(Response.Success);
				}));
				errorHandler = null;
			}, () =>
			{
				//0x17D0F90
				this.StartCoroutineWatched(PopupDenomination.Co_ClosePopup(() =>
				{
					//0x17D10A0
					if(!m_IsChangeDate && onCancel != null)
					{
						onCancel();
					}
					CallResponseHandler(Response.Cancel);
				}));
				errorHandler = null;
			}, () =>
			{
				//0x17D1104
				if (onError != null)
					onError();
				CallResponseHandler(Response.Error);
			}, () =>
			{
				//0x17D0D6C
				PopupDenomination.OnProcessingEnd();
			}, false, true);
		}

		// // RVA: 0x17CFC3C Offset: 0x17CFC3C VA: 0x17CFC3C
		public void AddResponseHandler(ResponseHandler handler)
		{
			m_responceHandlerList.Add(handler);
		}

		// // RVA: 0x17CFCBC Offset: 0x17CFCBC VA: 0x17CFCBC
		public void RemoveResponseHandler(ResponseHandler handler)
		{
			m_responceHandlerList.Remove(handler);
		}

		// // RVA: 0x17CFD3C Offset: 0x17CFD3C VA: 0x17CFD3C
		public void CallResponseHandler(Response response)
		{
			for(int i = 0; i < m_responceHandlerList.Count; i++)
			{
				if (m_responceHandlerList[i] != null)
					m_responceHandlerList[i](response);
			}
		}

		// // RVA: 0x17D026C Offset: 0x17D026C VA: 0x17D026C
		private void OnOpenVCProducts(AMOCLPHDGBP p, ELBOJBBIBFM onPurchase, JFDNPFFOACP onCancel)
		{
			if(GetProcuctListCount(p, m_productListFilter) == 0)
			{
				TextPopupSetting s = new TextPopupSetting();
				s.Text = MessageManager.Instance.GetMessage("common", "popup_purchase_error_not_product");
				s.IsCaption = false;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x17D1148
					if(onCancel != null)
						onCancel();
				}, null, null, null);
			}
			else
			{
				this.StartCoroutineWatched(PopupDenomination.Co_ShowPopup(transform, p, onPurchase, onCancel, errorHandler, m_OnChangeDate, m_productListFilter));
			}
		}

		// // RVA: 0x17D05C8 Offset: 0x17D05C8 VA: 0x17D05C8
		private int GetProcuctListCount(AMOCLPHDGBP p, ProductListFilter filter)
		{
			if(filter == null)
			{
				return p.HFCNOINEPLB.MHKCPJDNJKI.Count;
			}
			int a = 0;
			for(int i = 0; i < p.HFCNOINEPLB.MHKCPJDNJKI.Count; i++)
			{
				a += filter(p.HFCNOINEPLB.MHKCPJDNJKI[i]) ? 1 : 0;
			}
			return a;
		}

		// // RVA: 0x17D079C Offset: 0x17D079C VA: 0x17D079C
		private void OnOpenBirthdayRegistration(PJHHCHAKGKI onRegisterBirth, JFDNPFFOACP onCencel)
		{
			PopupRegistrationBirthday.ShowPopup(transform, onRegisterBirth, onCencel, errorHandler, m_OnChangeDate != null);
		}

		// // RVA: 0x17D0860 Offset: 0x17D0860 VA: 0x17D0860
		private void OnOpenBirthdayRegistrationConfirm(int year, int mon, IMCBBOAFION onEnter, JFDNPFFOACP onCancel, DJBHIFLHJLK onError)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_denom_check_birthday_title");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.Text = string.Format(bk.GetMessageByLabel("popup_denom_check_birthday_text"), year, mon);
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x17D115C
				if(label == PopupButton.ButtonLabel.Ok)
				{
					if(m_OnChangeDate != null)
					{
						if(PGIGNJDPCAH.MNANNMDBHMP(() =>
						{
							//0x17D12E0
							PopupDenomination.ChangeDate(TransitionList.Type.LOGIN_BONUS);
							if(onError != null)
								onError();
						}, () =>
						{
							//0x17D1378
							PopupDenomination.ChangeDate(TransitionList.Type.TITLE);
							if(onError != null)
								onError();
						}))
						{
							return;
						}
					}
					if(onEnter != null)
						onEnter();
				}
				else if(label == PopupButton.ButtonLabel.Cancel && onCancel != null)
				{
					onCancel();
				}
			}, null, null, null);
		}
	}
}
