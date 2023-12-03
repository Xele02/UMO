using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupOfferItemDetail : UIBehaviour, IPopupContent
	{
		private PopupOfferItemDetailSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutOfferItemDetail m_layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x169DC28 Offset: 0x169DC28 VA: 0x169DC28 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupOfferItemDetailSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_layout = gameObject.GetComponent<LayoutOfferItemDetail>();
			m_layout.popSetUp(setup.ItemName, setup.ItemDetail, setup.ItemId, setup.IsSecret);
			gameObject.SetActive(true);
		}

		// RVA: 0x169DEC4 Offset: 0x169DEC4 VA: 0x169DEC4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x169DECC Offset: 0x169DECC VA: 0x169DECC
		public void Update()
		{
			return;
		}

		// RVA: 0x169DED0 Offset: 0x169DED0 VA: 0x169DED0 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x169DF08 Offset: 0x169DF08 VA: 0x169DF08 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x169DF40 Offset: 0x169DF40 VA: 0x169DF40 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x169DF48 Offset: 0x169DF48 VA: 0x169DF48 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
