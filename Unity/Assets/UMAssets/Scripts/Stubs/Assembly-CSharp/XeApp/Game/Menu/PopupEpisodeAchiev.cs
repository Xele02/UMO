using System;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeAchiev : UIBehaviour, IPopupContent
	{
		private MFDJIFIIPJD m_data; // 0x10
		private Action openEvent; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF84148 Offset: 0xF84148 VA: 0xF84148 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			EpisodeAchievPopupSetting s = setting as EpisodeAchievPopupSetting;
			Parent = setting.m_parent;
			m_data = s.data;
			openEvent = s.openEvent;
			gameObject.SetActive(true);
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0xF84314 Offset: 0xF84314 VA: 0xF84314 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF8431C Offset: 0xF8431C VA: 0xF8431C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF84354 Offset: 0xF84354 VA: 0xF84354 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF8438C Offset: 0xF8438C VA: 0xF8438C Slot: 21
		public bool IsReady()
		{ 
			transform.GetComponent<EpisodeAchievWindow>().Init(m_data);
			return true;
		}

		// RVA: 0xF8443C Offset: 0xF8443C VA: 0xF8443C
		public void InputOn()
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>(true);
			for(int i = 0; i < btns.Length; i++)
			{
				btns[i].IsInputOff = false;
			}
		}

		// RVA: 0xF84590 Offset: 0xF84590 VA: 0xF84590 Slot: 22
		public void CallOpenEnd()
		{
			InputOn();
			openEvent();
		}
	}
}
