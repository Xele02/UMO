using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupShopItemContent : UIBehaviour, IPopupContent
	{
		private PopupShopItemSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private LayoutPopupShop layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1148038 Offset: 0x1148038 VA: 0x1148038 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			setup = setting as PopupShopItemSetting;
			this.control = control;
			Parent = setup.m_parent;
			RectTransform rt = transform.GetComponent<RectTransform>();
			rt.sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutPopupShop>();
			layout.SetStatus(setup.View, setup.IsBuy);
			gameObject.SetActive(true);
			layout.OnChangeCallback = OnChange;
			OnChange(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(setup.View.KIJAPOFAGPN_ItemFullId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem ? 1 : 0, false);
		}

		// RVA: 0x11483A4 Offset: 0x11483A4 VA: 0x11483A4
		private void OnChange(int num, bool isOver)
		{
			PopupButton btn = control.FindButton(PopupButton.ButtonLabel.Ok);
			if(btn != null)
			{
				btn.Disable = num < 1 || isOver;
			}
			if(setup.OnChangeCallback != null)
				setup.OnChangeCallback(num);
		}

		// RVA: 0x11484FC Offset: 0x11484FC VA: 0x11484FC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1148504 Offset: 0x1148504 VA: 0x1148504
		public void Update()
		{
			return;
		}

		// RVA: 0x1148508 Offset: 0x1148508 VA: 0x1148508 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1148540 Offset: 0x1148540 VA: 0x1148540 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1148578 Offset: 0x1148578 VA: 0x1148578 Slot: 21
		public bool IsReady()
		{
			return layout == null || !layout.IsLoading();
		}

		// RVA: 0x1148638 Offset: 0x1148638 VA: 0x1148638 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
