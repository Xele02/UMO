using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupConfigBattleEventContent : UIBehaviour, IPopupContent
	{
		private PopupConfigBattleEventSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private LayoutPopupConfigBattleEvent layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x133F238 Offset: 0x133F238 VA: 0x133F238 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupConfigBattleEventSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = new Vector3(0, 0, 0);
			layout = setup.Content.GetComponent<LayoutPopupConfigBattleEvent>();
			layout.SetStatus(null);
			layout.OnClickClassSelect = setup.OnClickClassSelect;
			layout.OnClickBattleInfo = setup.OnClickBattleInfo;
		}

		// RVA: 0x133F4A4 Offset: 0x133F4A4 VA: 0x133F4A4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x133F4AC Offset: 0x133F4AC VA: 0x133F4AC
		public void Update()
		{
			return;
		}

		// RVA: 0x133F4B0 Offset: 0x133F4B0 VA: 0x133F4B0 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x133F4E8 Offset: 0x133F4E8 VA: 0x133F4E8 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x133F520 Offset: 0x133F520 VA: 0x133F520 Slot: 21
		public bool IsReady()
		{
			return layout == null || layout.IsLoaded();
		}

		// RVA: 0x133F5D8 Offset: 0x133F5D8 VA: 0x133F5D8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
