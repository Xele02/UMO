using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PupupBingoRewardWindowContent : UIBehaviour, IPopupContent
	{
		private PupupBingoRewardWindowSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutBingoRewardWindow layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x9D43FC Offset: 0x9D43FC VA: 0x9D43FC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PupupBingoRewardWindowSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutBingoRewardWindow>();
			layout.SettingButton((int i) =>
			{
				//0x9D47FC
				setup.OnClickIcon(i);
			});
			layout.SettingItemList(setup.ItemList);
			layout.SetUp(setup.ReceivedBingoCount);
		}

		// RVA: 0x9D46BC Offset: 0x9D46BC VA: 0x9D46BC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x9D46C4 Offset: 0x9D46C4 VA: 0x9D46C4
		public void Update()
		{
			return;
		}

		// RVA: 0x9D46C8 Offset: 0x9D46C8 VA: 0x9D46C8 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x9D4700 Offset: 0x9D4700 VA: 0x9D4700 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x9D4738 Offset: 0x9D4738 VA: 0x9D4738 Slot: 21
		public bool IsReady()
		{
			return layout != null && layout.IsLoaded();
		}

		// RVA: 0x9D47F0 Offset: 0x9D47F0 VA: 0x9D47F0 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
