using System;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupCostumeAchieve : UIBehaviour, IPopupContent
	{
		private LFAFJCNKLML m_data; // 0x10
		private PopupWindowControl m_control; // 0x14
		private Action openEvent; // 0x18
		private SimpleVoicePlayer m_voicePlayer; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1340F0C Offset: 0x1340F0C VA: 0x1340F0C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			CostumeAchievePopupSetting s = setting as CostumeAchievePopupSetting;
			m_control = control;
			Parent = setting.m_parent;
			m_data = s.data;
			m_voicePlayer = s.voicePlayer;
			gameObject.SetActive(true);
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0x134113C Offset: 0x134113C VA: 0x134113C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1341144 Offset: 0x1341144 VA: 0x1341144 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x134117C Offset: 0x134117C VA: 0x134117C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x13411B4 Offset: 0x13411B4 VA: 0x13411B4 Slot: 21
		public bool IsReady()
		{
			transform.GetComponent<CostumeAchieveWindow>().Initialize(m_data, m_voicePlayer);
			return true;
		}

		// RVA: 0x134126C Offset: 0x134126C VA: 0x134126C
		public void InputOn()
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>();
			for(int i = 0; i < btns.Length; i++)
			{
				btns[i].IsInputOff = false;
			}
		}

		// RVA: 0x13413C0 Offset: 0x13413C0 VA: 0x13413C0 Slot: 22
		public void CallOpenEnd()
		{
			InputOn();
		}
	}
}
