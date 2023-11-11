using UnityEngine.EventSystems;
using XeApp.Game.Menu;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using System.Collections;
using System;

namespace XeApp.Game.Gacha
{
	public class PopupGachaLotContent : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		[SerializeField]
		protected PopupGachaLotRuntime m_popupUi; // 0xC

		public Transform Parent { get { return null; } } //0x999358

		// RVA: 0x999360 Offset: 0x999360 VA: 0x999360 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			GachaLotPopupSetting setup = setting as GachaLotPopupSetting;
			bool isballoon = false;
			if(setup.CurrencyIsTicket)
				isballoon = setup.IsTicketPeriod;
			m_popupUi.SetMessage(setup.MessageText);
			m_popupUi.SetHoldCurrency(setup.HoldCurrency);
			m_popupUi.SetCurrencyType(setup.CurrencyIsTicket);
			m_popupUi.SetBalloon(isballoon);
			if(setup.OnClickLegalDescButton == null)
				m_popupUi.HideLegalDescButton();
			else
			{
				m_popupUi.ShowLegalDescButton();
				m_popupUi.onClickLegalDesc = () =>
				{
					//0x999904
					this.StartCoroutineWatched(Co_OpenLegalDesc(setup.OnClickLegalDescButton, control));
				};
			}
			OnInitialize(setting);
			PopupButton btn = control.FindButton(PopupButton.ButtonLabel.Expired);
			if(btn != null)
				btn.Disable = true;
			gameObject.SetActive(true);
		}

		// RVA: 0x999788 Offset: 0x999788 VA: 0x999788 Slot: 25
		public virtual void OnInitialize(PopupSetting setting)
		{
			return;
		}

		// RVA: 0x99978C Offset: 0x99978C VA: 0x99978C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x999794 Offset: 0x999794 VA: 0x999794 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x9997CC Offset: 0x9997CC VA: 0x9997CC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x999804 Offset: 0x999804 VA: 0x999804 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x99980C Offset: 0x99980C VA: 0x99980C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C54D0 Offset: 0x6C54D0 VA: 0x6C54D0
		// // RVA: 0x999810 Offset: 0x999810 VA: 0x999810
		private IEnumerator Co_OpenLegalDesc(Action<Action> action, PopupWindowControl control)
		{
			//0x999984
			bool isWait = true;
			control.InputDisable();
			if(action == null)
				isWait = false;
			else
			{
				action(() =>
				{
					//0x9998F8
					isWait = false;
				});
			}
			yield return new WaitWhile(() =>
			{
				//0x9998F0
				return isWait;
			});
			control.InputEnable();
		}

		// RVA: 0x9998D8 Offset: 0x9998D8 VA: 0x9998D8 Slot: 24
		bool ILayoutUGUIPaste.InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return true;
		}
	}
}
