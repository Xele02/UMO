using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupNewYearEventSettingWindow : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x169D120
		public override string BundleName { get { return "ly/112.xab"; } } //0x169D17C
		public int bannerId { get; set; } // 0x34
		public override string AssetName { get { return "root_pop_event_01_layout_root"; } } //0x169D1E0
		public override bool IsAssetBundle { get { return true; } } //0x169D23C
		public override bool IsPreload { get { return true; } } //0x169D244
		public override GameObject Content { get { return m_content; } } //0x169D24C

		// RVA: 0x169D254 Offset: 0x169D254 VA: 0x169D254
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}

	public class PopupNewYearEventSetting : UIBehaviour, IPopupContent
	{
		private PopupWindowControl m_control; // 0x10
		private LayoutPopupNewYearEvent window; // 0x14
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x169CE3C Offset: 0x169CE3C VA: 0x169CE3C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_control = control;
			window = transform.GetComponent<LayoutPopupNewYearEvent>();
			window.Setup((setting as PopupNewYearEventSettingWindow).bannerId);
		}

		// RVA: 0x169D06C Offset: 0x169D06C VA: 0x169D06C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x169D074 Offset: 0x169D074 VA: 0x169D074 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x169D0AC Offset: 0x169D0AC VA: 0x169D0AC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x169D0E4 Offset: 0x169D0E4 VA: 0x169D0E4 Slot: 21
		public bool IsReady()
		{
			return !window.IsLoadImage();
		}

		// RVA: 0x169D114 Offset: 0x169D114 VA: 0x169D114 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
