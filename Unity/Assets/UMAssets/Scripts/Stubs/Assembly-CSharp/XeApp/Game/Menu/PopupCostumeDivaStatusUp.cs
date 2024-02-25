using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupCostumeDivaStatusUp : UIBehaviour, IPopupContent
	{
		public LFAFJCNKLML m_data; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x134266C Offset: 0x134266C VA: 0x134266C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			CostumeDivaStatusUpPopupSetting s = setting as CostumeDivaStatusUpPopupSetting;
			Parent = setting.m_parent;
			m_data = s.m_data;
			gameObject.SetActive(true);
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0x1342874 Offset: 0x1342874 VA: 0x1342874 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x134287C Offset: 0x134287C VA: 0x134287C Slot: 19
		public void Show()
		{
			transform.GetComponent<CostumeDivaStatusUpWindow>().Show();
		}

		// RVA: 0x1342920 Offset: 0x1342920 VA: 0x1342920 Slot: 20
		public void Hide()
		{
			transform.GetComponent<CostumeDivaStatusUpWindow>().Hide();
		}

		// RVA: 0x13429C4 Offset: 0x13429C4 VA: 0x13429C4 Slot: 21
		public bool IsReady()
		{
			transform.GetComponent<CostumeDivaStatusUpWindow>().Initialize(m_data);
			return true;
		}

		// RVA: 0x1342A74 Offset: 0x1342A74 VA: 0x1342A74
		public void InputOn()
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>();
			for(int i = 0; i < btns.Length; i++)
			{
				btns[i].IsInputOff = false;
			}
		}

		// RVA: 0x1342BC8 Offset: 0x1342BC8 VA: 0x1342BC8 Slot: 22
		public void CallOpenEnd()
		{
			InputOn();
		}
	}
}
