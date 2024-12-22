using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupCostumeItemUse : UIBehaviour, IPopupContent
	{
		private LFAFJCNKLML m_data; // 0x10
		private int m_item_type; // 0x14
		private PopupButton[] m_buttons; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x13432F0 Offset: 0x13432F0 VA: 0x13432F0 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			CostumeItemUsePopupSetting s = setting as CostumeItemUsePopupSetting;
			Parent = s.m_parent;
			m_data = s.data;
			m_item_type = s.item_type;
			gameObject.SetActive(true);
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0x134352C Offset: 0x134352C VA: 0x134352C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1343534 Offset: 0x1343534 VA: 0x1343534 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			SetDisable(true);
			transform.GetComponent<CostumeItemUseWindow>().Enter();
		}

		// RVA: 0x13437B0 Offset: 0x13437B0 VA: 0x13437B0 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x13437E8 Offset: 0x13437E8 VA: 0x13437E8 Slot: 21
		public bool IsReady()
		{
			return transform.GetComponent<CostumeItemUseWindow>().IsLoaded();
		}

		// RVA: 0x1343614 Offset: 0x1343614 VA: 0x1343614
		public void SetDisable(bool disable)
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>();
			for(int i = 0; i < btns.Length; i++)
			{
				if(btns[i].Label == PopupButton.ButtonLabel.UsedItem)
				{
					btns[i].Disable = disable;
				}
			}
		}

		// RVA: 0x134388C Offset: 0x134388C VA: 0x134388C Slot: 22
		public void CallOpenEnd()
		{
			transform.GetComponent<CostumeItemUseWindow>().OpenEnd();
		}
	}
}
