using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupOfferProgressContent : UIBehaviour, IPopupContent
	{
		private PopupOfferProgressSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private LayoutOfferProgress layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x169E0A0 Offset: 0x169E0A0 VA: 0x169E0A0 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupOfferProgressSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutOfferProgress>();
			layout.SetView(setup.m_view);
			layout.PopupSetting();
			gameObject.SetActive(true);
		}

		// RVA: 0x169E30C Offset: 0x169E30C VA: 0x169E30C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x169E314 Offset: 0x169E314 VA: 0x169E314
		public void Update()
		{
			return;
		}

		// RVA: 0x169E318 Offset: 0x169E318 VA: 0x169E318 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x169E350 Offset: 0x169E350 VA: 0x169E350 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x169E388 Offset: 0x169E388 VA: 0x169E388 Slot: 21
		public bool IsReady()
		{
			return layout == null || !layout.IsImageLoding();
		}

		// RVA: 0x169E448 Offset: 0x169E448 VA: 0x169E448 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
