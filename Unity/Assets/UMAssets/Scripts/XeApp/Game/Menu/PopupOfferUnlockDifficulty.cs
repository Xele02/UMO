using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupOfferUnlockDifficulty : UIBehaviour, IPopupContent
	{
		private PopupOfferUnclokDiffSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private LayoutOfferUnlockDifficulty m_layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x169E820 Offset: 0x169E820 VA: 0x169E820 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupOfferUnclokDiffSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_layout = setup.Content.GetComponent<LayoutOfferUnlockDifficulty>();
			m_layout.Setup(setup.popupMsg, setup.preDiff, setup.nextDiff);
			gameObject.SetActive(true);
		}

		// RVA: 0x169EAB0 Offset: 0x169EAB0 VA: 0x169EAB0 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x169EAB8 Offset: 0x169EAB8 VA: 0x169EAB8
		public void Update()
		{
			return;
		}

		// RVA: 0x169EABC Offset: 0x169EABC VA: 0x169EABC Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x169EAF4 Offset: 0x169EAF4 VA: 0x169EAF4 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x169EB2C Offset: 0x169EB2C VA: 0x169EB2C Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x169EB34 Offset: 0x169EB34 VA: 0x169EB34 Slot: 22
		public void CallOpenEnd()
		{
			if (m_layout != null)
				m_layout.TitleEnter();
		}
	}
}
