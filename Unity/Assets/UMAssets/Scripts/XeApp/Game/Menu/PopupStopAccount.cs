using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupStopAccount : UIBehaviour, IPopupContent
	{
		private LayoutPopupStopAccount m_contract; // 0x10
		private PopupWindowControl m_popupControl; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x115181C Offset: 0x115181C VA: 0x115181C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_popupControl = control;
			PopupStopAccountSetting s = setting as PopupStopAccountSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_contract = GetComponent<LayoutPopupStopAccount>();
			if(m_contract != null)
			{
				m_contract.SetStatus(s.type);
				m_contract.CallbackButtonContract = () =>
				{
					//0x1151D90
					this.StartCoroutineWatched(ShowPopupContract());
				};
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x1151B00 Offset: 0x1151B00 VA: 0x1151B00 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1151B08 Offset: 0x1151B08 VA: 0x1151B08 Slot: 19
		public void Show()
		{
			if(m_contract != null)
				m_contract.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x1151BEC Offset: 0x1151BEC VA: 0x1151BEC Slot: 20
		public void Hide()
		{
			if(m_contract != null)
				m_contract.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x1151CD0 Offset: 0x1151CD0 VA: 0x1151CD0 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1151CD8 Offset: 0x1151CD8 VA: 0x1151CD8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70AB0C Offset: 0x70AB0C VA: 0x70AB0C
		// // RVA: 0x1151CDC Offset: 0x1151CDC VA: 0x1151CDC
		private IEnumerator ShowPopupContract()
		{
			//0x1151DB8
			if(m_popupControl != null)
				m_popupControl.InputDisable();
			yield return this.StartCoroutineWatched(MBCPNPNMFHB.HHCJCDFCLOB.EBIENHFDNNL_Coroutine_OpenRiyoukiyakuDirect());
			if(m_popupControl != null)
				m_popupControl.InputEnable();
		}
	}
}
