using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupBingoMissionRewardWindowContent : UIBehaviour, IPopupContent
	{
		private PopupBingoMissionRewardWindowSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutBingoMissionRewardWindow layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1339F04 Offset: 0x1339F04 VA: 0x1339F04 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			setup = setting as PopupBingoMissionRewardWindowSetting;
			this.control = control;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutBingoMissionRewardWindow>();
			layout.SetItemInfo(setup.ItemInfoList, setup.MissionTextList);
			layout.SetUp();
		}

		// RVA: 0x133A158 Offset: 0x133A158 VA: 0x133A158
		private void Start()
		{
			return;
		}

		// RVA: 0x133A15C Offset: 0x133A15C VA: 0x133A15C
		private void Update()
		{
			return;
		}

		// RVA: 0x133A160 Offset: 0x133A160 VA: 0x133A160 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x133A168 Offset: 0x133A168 VA: 0x133A168 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x133A1A0 Offset: 0x133A1A0 VA: 0x133A1A0 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x133A1D8 Offset: 0x133A1D8 VA: 0x133A1D8 Slot: 21
		public bool IsReady()
		{
			return layout != null && layout.IsLoaded();
		}

		// RVA: 0x133A290 Offset: 0x133A290 VA: 0x133A290 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
