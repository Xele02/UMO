using mcrs;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupCostumeCostumeStatusUp : UIBehaviour, IPopupContent
	{
		public LFAFJCNKLML m_data; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1341D08 Offset: 0x1341D08 VA: 0x1341D08 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			CostumeCostumeStatusUpPopupSetting s = setting as CostumeCostumeStatusUpPopupSetting;
			Parent = setting.m_parent;
			m_data = s.m_data;
			gameObject.SetActive(true);
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0x1341F10 Offset: 0x1341F10 VA: 0x1341F10 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1341F18 Offset: 0x1341F18 VA: 0x1341F18 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
		}

		// RVA: 0x1341F9C Offset: 0x1341F9C VA: 0x1341F9C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1341FD4 Offset: 0x1341FD4 VA: 0x1341FD4 Slot: 21
		public bool IsReady()
		{
			transform.GetComponent<CostumeCostumeStatusUpWindow>().Initialize(m_data);
			return true;
		}

		// RVA: 0x1342084 Offset: 0x1342084 VA: 0x1342084
		public void InputOn()
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>();
			for(int i = 0; i < btns.Length; i++)
			{
				btns[i].IsInputOff = false;
			}
		}

		// RVA: 0x13421D8 Offset: 0x13421D8 VA: 0x13421D8 Slot: 22
		public void CallOpenEnd()
		{
			InputOn();
			transform.GetComponent<CostumeCostumeStatusUpWindow>().Start();
		}
	}
}
