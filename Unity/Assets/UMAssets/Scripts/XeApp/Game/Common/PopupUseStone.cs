using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class PopupUseStone : UIBehaviour, IPopupContent
	{
		private LayoutPopUseStone m_contract; // 0x10
		private PopupWindowControl m_popupControl; // 0x14
		private DJBHIFLHJLK GoToTitleListener; // 0x18
		private PopupUseStoneSetting m_setup; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1BB4B20 Offset: 0x1BB4B20 VA: 0x1BB4B20 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_popupControl = control;
			m_setup = setting as PopupUseStoneSetting;
			Parent = setting.m_parent;
			GoToTitleListener = m_setup.GotoTitleListener;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_contract = GetComponent<LayoutPopUseStone>();
			if(m_contract != null)
			{
				m_contract.SetStatus(m_setup.Text, m_setup.LimitText, m_setup.IsLegalButton);
				m_contract.CallbackButtonContract = () =>
				{
					//0x1BB52B4
					this.StartCoroutineWatched(ShowPopupContract());
				};
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x1BB4E78 Offset: 0x1BB4E78 VA: 0x1BB4E78
		public void Update()
		{
			if(m_contract != null && m_setup.ContentUpdata != null)
			{
				m_setup.ContentUpdata(m_contract);
			}
		}

		// RVA: 0x1BB4F74 Offset: 0x1BB4F74 VA: 0x1BB4F74 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1BB4F7C Offset: 0x1BB4F7C VA: 0x1BB4F7C Slot: 19
		public void Show()
		{
			if(m_contract != null)
				m_contract.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x1BB5060 Offset: 0x1BB5060 VA: 0x1BB5060 Slot: 20
		public void Hide()
		{
			if(m_contract != null)
				m_contract.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x1BB5144 Offset: 0x1BB5144 VA: 0x1BB5144 Slot: 21
		public bool IsReady()
		{
			return m_contract != null && m_contract.IsReady();
		}

		// RVA: 0x1BB51FC Offset: 0x1BB51FC VA: 0x1BB51FC Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73EABC Offset: 0x73EABC VA: 0x73EABC
		// // RVA: 0x1BB5200 Offset: 0x1BB5200 VA: 0x1BB5200
		private IEnumerator ShowPopupContract()
		{
			//0x1BB52FC
			if(m_popupControl != null)
			{
				m_popupControl.InputDisable();
			}
			bool isWait = true;
			bool isGotoTitle = false;
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.LCCLAEBKMLD_6, () =>
			{
				//0x1BB52E0
				isWait = false;
			}, () =>
			{
				//0x1BB52EC
				isWait = false;
				isGotoTitle = true;
			});
			while(isWait)
				yield return null;
			if(isGotoTitle)
			{
				if(GoToTitleListener != null)
				{
					GoToTitleListener();
					yield break;
				}
			}
			if(m_popupControl != null)
				m_popupControl.InputEnable();

		}
	}
}
