using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Title
{
	public class TitlePopupSupportContents : UIBehaviour, IPopupContent
	{
		private LayoutPopupTitleSupport m_support; // 0x10
		private PopupWindowControl m_control; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xE3BEA4 Offset: 0xE3BEA4 VA: 0xE3BEA4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_control = control;
			PopupTitlePopupSupportSetting s = setting as PopupTitlePopupSupportSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_support = GetComponent<LayoutPopupTitleSupport>();
			if(m_support != null)
			{
				m_support.popupControl = control;
				m_support.SetStatus();
				m_support.ButtonCallbackPaid = () =>
				{
					//0xE3C3FC
					this.StartCoroutineWatched(PaidRecoverPopupShowInner(null));
				};
			}
			gameObject.SetActive(true);
		}

		// RVA: 0xE3C134 Offset: 0xE3C134 VA: 0xE3C134 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xE3C13C Offset: 0xE3C13C VA: 0xE3C13C Slot: 19
		public void Show()
		{
			if (m_support != null)
				m_support.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0xE3C21C Offset: 0xE3C21C VA: 0xE3C21C Slot: 20
		public void Hide()
		{
			if (m_support != null)
				m_support.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0xE3C2FC Offset: 0xE3C2FC VA: 0xE3C2FC Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0xE3C304 Offset: 0xE3C304 VA: 0xE3C304 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0xE3C308 Offset: 0xE3C308 VA: 0xE3C308
		//public void PaidRecoverPopupShow(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6B3BD0 Offset: 0x6B3BD0 VA: 0x6B3BD0
		//// RVA: 0xE3C32C Offset: 0xE3C32C VA: 0xE3C32C
		private IEnumerator PaidRecoverPopupShowInner(Action callback)
		{
			//0xE3C4E0
			MessageBank bk = MessageManager.Instance.GetBank("common");
			bool isWait = true;
			bool isOk = false;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_purchase_recover_title"), SizeType.Middle, bk.GetMessageByLabel("popup_purchase_recover_manual"), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl control2, PopupButton.ButtonType type2, PopupButton.ButtonLabel label2) =>
			{
				//0xE3C4AC
				if (label2 == PopupButton.ButtonLabel.Ok)
					isOk = true;
				isWait = false;
			}, null, null, null);
			while (isWait)
				yield return null;
			if(!isOk)
			{
				if (callback != null)
					callback();
				yield break;
			}
			bool done = false;
			bool error = false;
			AMOCLPHDGBP d = new AMOCLPHDGBP();
			m_control.InputDisable();
			d.CGPFMPHAAJK(() =>
			{
				//0xE3C4C4
				done = true;
			}, () =>
			{
				//0xE3C4D0
				done = true;
				error = true;
			});
			while (!done)
				yield return null;
			m_control.InputEnable();
			if(error)
			{
				m_control.Close(() =>
				{
					//0xE3C4A0
					return;
				}, null);
			}
			if (callback != null)
				callback();
		}
	}
}
