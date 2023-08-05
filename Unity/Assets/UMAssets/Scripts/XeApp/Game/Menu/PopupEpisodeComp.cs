using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeComp : UIBehaviour, IPopupContent
	{
		private PIGBBNDPPJC m_data; // 0x10
		private int m_add_episode_point; // 0x14
		private PopupWindowControl m_control; // 0x18
		private bool is_restart; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF89B38 Offset: 0xF89B38 VA: 0xF89B38 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			EpisodeCompPopupSetting s = setting as EpisodeCompPopupSetting;
			m_control = control;
			Parent = setting.m_parent;
			is_restart = s.is_restart;
			if(!is_restart)
			{
				gameObject.SetActive(true);
				transform.localPosition = Vector3.zero;
				m_data = s.data;
				m_add_episode_point = s.add_episode_point;
				transform.GetComponent<EpisodeCompWindow>().Initialize(m_data, s.ItemList, m_add_episode_point);
			}
			else
			{
				transform.GetComponent<EpisodeCompWindow>().InitializeRestart();
			}
		}

		// RVA: 0xF89E44 Offset: 0xF89E44 VA: 0xF89E44 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF89E4C Offset: 0xF89E4C VA: 0xF89E4C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF89E84 Offset: 0xF89E84 VA: 0xF89E84 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF89EBC Offset: 0xF89EBC VA: 0xF89EBC Slot: 21
		public bool IsReady()
		{
			return true;
		}

		//// RVA: 0xF89EC4 Offset: 0xF89EC4 VA: 0xF89EC4
		public void Close()
		{
			SetInput(true);
			m_control.PushNegativeOtherButton();
		}

		//// RVA: 0xF89EFC Offset: 0xF89EFC VA: 0xF89EFC
		public void SetInput(bool enabled)
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>(true);
			for(int i = 0; i < btns.Length; i++)
			{
				btns[i].enabled = enabled;
			}
		}

		// RVA: 0xF8A054 Offset: 0xF8A054 VA: 0xF8A054 Slot: 22
		public void CallOpenEnd()
		{
			transform.GetComponent<EpisodeCompWindow>().OpenEnd();
		}
	}
}
