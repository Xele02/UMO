using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupOfferUnlockPlatoon : UIBehaviour, IPopupContent
	{
		private PopupOfferUnclokPlattonSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutOfferUnlockPlatoon m_layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x169EC00 Offset: 0x169EC00 VA: 0x169EC00 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupOfferUnclokPlattonSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_layout = setup.Content.GetComponent<LayoutOfferUnlockPlatoon>();
			m_layout.Setup(setup.nextPlatoonNum, setup.ReleasePlatoonNum);
			gameObject.SetActive(true);
		}

		// RVA: 0x169EE64 Offset: 0x169EE64 VA: 0x169EE64 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x169EE6C Offset: 0x169EE6C VA: 0x169EE6C
		public void Update()
		{
			return;
		}

		// RVA: 0x169EE70 Offset: 0x169EE70 VA: 0x169EE70 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x169EEA8 Offset: 0x169EEA8 VA: 0x169EEA8 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x169EEE0 Offset: 0x169EEE0 VA: 0x169EEE0 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x169EEE8 Offset: 0x169EEE8 VA: 0x169EEE8 Slot: 22
		public void CallOpenEnd()
		{
			if(m_layout != null)
				m_layout.TitleEnter();
		}
	}
}
