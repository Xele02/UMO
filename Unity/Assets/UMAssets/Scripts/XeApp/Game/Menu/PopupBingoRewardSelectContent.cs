using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupBingoRewardSelectContent : UIBehaviour, IPopupContent
	{
		private PopupBingoRewardSelectSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutBingoRewardSelectPopup layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x133B2FC Offset: 0x133B2FC VA: 0x133B2FC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupBingoRewardSelectSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = GetComponent<LayoutBingoRewardSelectPopup>();
			layout.Setup(setup.sceneId, setup.rare, setup.select_msg);
		}

		// RVA: 0x133B520 Offset: 0x133B520 VA: 0x133B520
		private void Start()
		{
			return;
		}

		// RVA: 0x133B524 Offset: 0x133B524 VA: 0x133B524
		private void Update()
		{
			return;
		}

		// RVA: 0x133B528 Offset: 0x133B528 VA: 0x133B528 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x133B530 Offset: 0x133B530 VA: 0x133B530 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x133B568 Offset: 0x133B568 VA: 0x133B568 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x133B5A0 Offset: 0x133B5A0 VA: 0x133B5A0 Slot: 21
		public bool IsReady()
		{
			return layout != null && layout.IsLoaded();
		}

		// RVA: 0x133B658 Offset: 0x133B658 VA: 0x133B658 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
