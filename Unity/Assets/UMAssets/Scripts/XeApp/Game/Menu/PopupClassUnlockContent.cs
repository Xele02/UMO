using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupClassUnlockContent : UIBehaviour, IPopupContent
	{
		private PopupClassUnlockSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private LayoutPopupClassUnlock layout; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x133E704 Offset: 0x133E704 VA: 0x133E704 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupClassUnlockSetting;
			Parent = setting.m_parent;
			RectTransform rt = transform.GetComponent<RectTransform>();
			rt.sizeDelta = size;
			rt.localPosition = new Vector3(0, 0, 0);
			layout = setting.Content.GetComponent<LayoutPopupClassUnlock>();
			layout.Setup(setup.View);
		}

		// RVA: 0x133E928 Offset: 0x133E928 VA: 0x133E928 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x133E930 Offset: 0x133E930 VA: 0x133E930
		public void Update()
		{
			return;
		}

		// RVA: 0x133E934 Offset: 0x133E934 VA: 0x133E934 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x133E96C Offset: 0x133E96C VA: 0x133E96C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x133E9A4 Offset: 0x133E9A4 VA: 0x133E9A4 Slot: 21
		public bool IsReady()
		{
			return layout == null || (!KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && layout.IsLoaded());
		}

		// RVA: 0x133EAC4 Offset: 0x133EAC4 VA: 0x133EAC4 Slot: 22
		public void CallOpenEnd()
		{
			layout.StartAnim();
		}
	}
}
