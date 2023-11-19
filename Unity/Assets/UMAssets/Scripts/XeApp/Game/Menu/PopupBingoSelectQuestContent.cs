using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupBingoSelectQuestContent : UIBehaviour, IPopupContent
	{
		private PopupBingoSelectQuestSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutBingoSelectQuest layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x133B7B0 Offset: 0x133B7B0 VA: 0x133B7B0 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupBingoSelectQuestSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutBingoSelectQuest>();
			layout.Setting(setup.ItemId, setup.ItemDetailText, setup.QuestText);
			layout.SettingButton(setup.OnClickItemIcon);
		}

		// RVA: 0x133BA4C Offset: 0x133BA4C VA: 0x133BA4C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x133BA54 Offset: 0x133BA54 VA: 0x133BA54
		public void Update()
		{
			return;
		}

		// RVA: 0x133BA58 Offset: 0x133BA58 VA: 0x133BA58 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x133BA90 Offset: 0x133BA90 VA: 0x133BA90 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x133BAC8 Offset: 0x133BAC8 VA: 0x133BAC8 Slot: 21
		public bool IsReady()
		{
			return layout != null && layout.IsLoaded();
		}

		// RVA: 0x133BB80 Offset: 0x133BB80 VA: 0x133BB80 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
