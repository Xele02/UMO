using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUnitBonusContent : UIBehaviour, IPopupContent
	{
		private PopupUnitBonusContentSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private UnitBonusWindow layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1154D84 Offset: 0x1154D84 VA: 0x1154D84 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupUnitBonusContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = transform.GetComponent<UnitBonusWindow>();
			layout.Initialize(this);
			gameObject.SetActive(true);
		}

		// RVA: 0x1154F9C Offset: 0x1154F9C VA: 0x1154F9C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1154FA4 Offset: 0x1154FA4 VA: 0x1154FA4
		public void Update()
		{
			return;
		}

		// RVA: 0x1154FA8 Offset: 0x1154FA8 VA: 0x1154FA8 Slot: 19
		public void Show()
		{
			return;
		}

		// RVA: 0x1154FAC Offset: 0x1154FAC VA: 0x1154FAC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1154FE4 Offset: 0x1154FE4 VA: 0x1154FE4 Slot: 21
		public bool IsReady()
		{
			return layout == null || (layout.IsLoaded() && layout.IsLoadImage());
		}

		// RVA: 0x11550D0 Offset: 0x11550D0 VA: 0x11550D0 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
