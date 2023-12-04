using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvItemPopupContent : UIBehaviour, IPopupContent
	{
		private OfferAllRecvItemPopup layout; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1522884 Offset: 0x1522884 VA: 0x1522884 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			OfferGetAllItemPopupSetting s = setting as OfferGetAllItemPopupSetting;
			Parent = control.transform;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			gameObject.SetActive(true);
			if(setting.Content != null)
			{
				layout = setting.Content.GetComponent<OfferAllRecvItemPopup>();
				if(layout != null)
					layout.Setup(s.isItemLimit);
			}
		}

		// RVA: 0x1522B60 Offset: 0x1522B60 VA: 0x1522B60 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1522B68 Offset: 0x1522B68 VA: 0x1522B68 Slot: 19
		public void Show()
		{
			if(layout != null)
				layout.Show();
		}

		// RVA: 0x1522C18 Offset: 0x1522C18 VA: 0x1522C18 Slot: 20
		public void Hide()
		{
			if(layout != null)
				layout.Hide();
		}

		// RVA: 0x1522CC8 Offset: 0x1522CC8 VA: 0x1522CC8 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1522CD0 Offset: 0x1522CD0 VA: 0x1522CD0 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
