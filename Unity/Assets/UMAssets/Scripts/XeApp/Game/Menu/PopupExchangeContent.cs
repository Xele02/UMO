using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupExchangeContent : UIBehaviour, IPopupContent
	{
		private PopupExchangeSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private LayoutPopupExchange layout; // 0x1C
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF8E2B4 Offset: 0xF8E2B4 VA: 0xF8E2B4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupExchangeSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutPopupExchange>();
			layout.OnChangeCallback = CheckRemain;
			layout.SetStatus(setup.View);
			gameObject.SetActive(true);
		}

		// // RVA: 0xF8E570 Offset: 0xF8E570 VA: 0xF8E570
		private void CheckRemain(int remain)
		{
			control.FindButton(PopupButton.ButtonLabel.Exchange).Disable = remain == 0;
		}

		// RVA: 0xF8E5D0 Offset: 0xF8E5D0 VA: 0xF8E5D0 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF8E5D8 Offset: 0xF8E5D8 VA: 0xF8E5D8
		public void Update()
		{
			return;
		}

		// RVA: 0xF8E5DC Offset: 0xF8E5DC VA: 0xF8E5DC Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF8E614 Offset: 0xF8E614 VA: 0xF8E614 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF8E64C Offset: 0xF8E64C VA: 0xF8E64C Slot: 21
		public bool IsReady()
		{
			return layout == null || !layout.IsLoading();
		}

		// RVA: 0xF8E70C Offset: 0xF8E70C VA: 0xF8E70C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
