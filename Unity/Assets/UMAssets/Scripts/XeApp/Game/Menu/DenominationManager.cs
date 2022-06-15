using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	delegate void OnDenomChangeDate(TransitionList.Type type);
	delegate bool ProductListFilter(LGDNAJACFHI data);

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
			UnityEngine.Debug.LogWarning("TODO DenominationManager.Create");
			return null;
		}

		// // RVA: 0x17CF744 Offset: 0x17CF744 VA: 0x17CF744
		// public void OnDestroy() { }

		// // RVA: 0x17CF7DC Offset: 0x17CF7DC VA: 0x17CF7DC
		// public void StartPurchaseSequence(IMCBBOAFION onSuccess, JFDNPFFOACP onCancel, DJBHIFLHJLK onError, OnDenomChangeDate onChangeDate, ProductListFilter filter) { }

		// // RVA: 0x17CFC3C Offset: 0x17CFC3C VA: 0x17CFC3C
		// public void AddResponseHandler(DenominationManager.ResponseHandler handler) { }

		// // RVA: 0x17CFCBC Offset: 0x17CFCBC VA: 0x17CFCBC
		// public void RemoveResponseHandler(DenominationManager.ResponseHandler handler) { }

		// // RVA: 0x17CFD3C Offset: 0x17CFD3C VA: 0x17CFD3C
		// public void CallResponseHandler(DenominationManager.Response response) { }

		// // RVA: 0x17D026C Offset: 0x17D026C VA: 0x17D026C
		// private void OnOpenVCProducts(AMOCLPHDGBP p, ELBOJBBIBFM onPurchase, JFDNPFFOACP onCancel) { }

		// // RVA: 0x17D05C8 Offset: 0x17D05C8 VA: 0x17D05C8
		// private int GetProcuctListCount(AMOCLPHDGBP p, ProductListFilter filter) { }

		// // RVA: 0x17D079C Offset: 0x17D079C VA: 0x17D079C
		// private void OnOpenBirthdayRegistration(PJHHCHAKGKI onRegisterBirth, JFDNPFFOACP onCencel) { }

		// // RVA: 0x17D0860 Offset: 0x17D0860 VA: 0x17D0860
		// private void OnOpenBirthdayRegistrationConfirm(int year, int mon, IMCBBOAFION onEnter, JFDNPFFOACP onCancel, DJBHIFLHJLK onError) { }
	}
}
