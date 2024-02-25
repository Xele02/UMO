using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupCostumeRankUpUnlock : UIBehaviour, IPopupContent
	{
		private LFAFJCNKLML m_data; // 0x10
		private MOEALEGLGCH m_upgrade; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1343948 Offset: 0x1343948 VA: 0x1343948 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			CostumeRankUpUnlockPopupSetting s = setting as CostumeRankUpUnlockPopupSetting;
			Parent = s.m_parent;
			m_data = s.m_data;
			m_upgrade = s.m_upgrade;
			gameObject.SetActive(true);
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0x1343B6C Offset: 0x1343B6C VA: 0x1343B6C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1343B74 Offset: 0x1343B74 VA: 0x1343B74 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1343BAC Offset: 0x1343BAC VA: 0x1343BAC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1343BE4 Offset: 0x1343BE4 VA: 0x1343BE4 Slot: 21
		public bool IsReady()
		{
			transform.GetComponent<CostumeRankUpUnlockWindow>().Initialize(m_data, m_upgrade);
			return true;
		}

		// RVA: 0x1343C9C Offset: 0x1343C9C VA: 0x1343C9C
		public void InputOn()
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>();
			for(int i = 0; i < btns.Length; i++)
			{
				btns[i].IsInputOff = false;
			}
		}

		// RVA: 0x1343DF0 Offset: 0x1343DF0 VA: 0x1343DF0 Slot: 22
		public void CallOpenEnd()
		{
			InputOn();
		}
	}
}
