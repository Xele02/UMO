using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.Menu;

namespace XeApp.Game.Title
{
	public class PopupContractContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupContract m_contract; // 0x10
		private PopupWindowControl m_popupControl; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xE3B30C Offset: 0xE3B30C VA: 0xE3B30C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_popupControl = control;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_contract = GetComponent<LayoutPopupContract>();
			if(m_contract != null)
			{
				m_contract.SetStatus();
				m_contract.CallbackButtonContract = () => {
					//0xE3B870
					this.StartCoroutineWatched(ShowPopupContract());
				};
			}
			gameObject.SetActive(true);
		}

		// RVA: 0xE3B5E0 Offset: 0xE3B5E0 VA: 0xE3B5E0 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xE3B5E8 Offset: 0xE3B5E8 VA: 0xE3B5E8 Slot: 19
		public void Show()
		{
			if(m_contract != null)
			{
				m_contract.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0xE3B6CC Offset: 0xE3B6CC VA: 0xE3B6CC Slot: 20
		public void Hide()
		{
			if(m_contract != null)
			{
				m_contract.Hide();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0xE3B7B0 Offset: 0xE3B7B0 VA: 0xE3B7B0 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0xE3B7B8 Offset: 0xE3B7B8 VA: 0xE3B7B8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B2B00 Offset: 0x6B2B00 VA: 0x6B2B00
		// // RVA: 0xE3B7BC Offset: 0xE3B7BC VA: 0xE3B7BC
		private IEnumerator ShowPopupContract()
		{
			//0xE3B8B8
			if(m_popupControl != null)
			{
				m_popupControl.InputDisable();
			}
			bool isWait = true;
			bool isGotoTitle = false;
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.GHDACOGLNLJ_Contract/*8*/, () => {
				//0x1BB52E0
				isWait = false;
			}, () => {
				//0x1BB52EC
				isWait = true;
				isGotoTitle = false;
			});
			while(isWait)
				yield return null;
			if(m_popupControl != null)
			{
				m_popupControl.InputEnable();
			}
			
		}
	}
}
