using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;

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
			TodoLogger.LogError(0, "OnOpenVCProducts");
		}

		// // RVA: 0x17D05C8 Offset: 0x17D05C8 VA: 0x17D05C8
		// private int GetProcuctListCount(AMOCLPHDGBP p, ProductListFilter filter) { }

		// // RVA: 0x17D079C Offset: 0x17D079C VA: 0x17D079C
		private void OnOpenBirthdayRegistration(PJHHCHAKGKI onRegisterBirth, JFDNPFFOACP onCencel)
		{
			TodoLogger.LogError(0, "OnOpenBirthdayRegistration");
		}

		// // RVA: 0x17D0860 Offset: 0x17D0860 VA: 0x17D0860
		private void OnOpenBirthdayRegistrationConfirm(int year, int mon, IMCBBOAFION onEnter, JFDNPFFOACP onCancel, DJBHIFLHJLK onError)
		{
			TodoLogger.LogError(0, "OnOpenBirthdayRegistrationConfirm");
		}
	}
}
