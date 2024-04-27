using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupCostumeComp : UIBehaviour, IPopupContent
	{
		private LFAFJCNKLML m_data; // 0x10
		private PopupWindowControl m_control; // 0x14
		private int m_add_point; // 0x18
		private bool m_is_restart; // 0x1C
		private int m_prev_offer_difficult; // 0x20
		private bool m_is_reshow; // 0x24
		private SimpleVoicePlayer voicePlayer; // 0x28

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x13413DC Offset: 0x13413DC VA: 0x13413DC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			CostumeCompPopupSetting s = setting as CostumeCompPopupSetting;
			m_control = control;
			Parent = setting.m_parent;
			m_data = s.data;
			m_add_point = s.add_point;
			m_is_restart = s.is_restart;
			m_prev_offer_difficult = s.prev_offer_difficult;
			m_is_reshow = s.is_reshow;
			voicePlayer = s.voicePlayer;
			CostumeCompWindow w = transform.GetComponent<CostumeCompWindow>();
			if(!m_is_reshow)
			{
				if(!m_is_restart)
				{
					gameObject.SetActive(true);
					transform.GetComponent<RectTransform>().sizeDelta = size;
					transform.localPosition = Vector3.zero;
					w.Initialize(m_data, m_add_point, m_prev_offer_difficult, voicePlayer);
				}
				else
				{
					w.InitializeRestart();
				}
			}
			else
			{
				gameObject.SetActive(true);
				transform.GetComponent<RectTransform>().sizeDelta = size;
				transform.localPosition = Vector3.zero;
				w.InitializeReShow(s.data, m_add_point);
			}
		}

		// RVA: 0x134184C Offset: 0x134184C VA: 0x134184C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1341854 Offset: 0x1341854 VA: 0x1341854 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x134188C Offset: 0x134188C VA: 0x134188C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x13418C4 Offset: 0x13418C4 VA: 0x13418C4 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// // RVA: 0x13418CC Offset: 0x13418CC VA: 0x13418CC
		public void Close()
		{
			SetInput(true, false);
			m_control.PushNegativeOtherButton();
		}

		// // RVA: 0x1341908 Offset: 0x1341908 VA: 0x1341908
		public void SetInput(bool enabled, bool isOtherCostumeSelect = false)
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>();
			for(int i = 0; i < btns.Length; i++)
			{
				if(!isOtherCostumeSelect || btns[i].Label != PopupButton.ButtonLabel.CostumeSelect)
				{
					btns[i].enabled = enabled;
				}
			}
		}

		// // RVA: 0x1341AB0 Offset: 0x1341AB0 VA: 0x1341AB0
		public void SetInputCostumeSelect(bool enabled)
		{
			PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>();
			for(int i = 0; i < btns.Length; i++)
			{
				if(btns[i].Label == PopupButton.ButtonLabel.CostumeSelect)
				{
					btns[i].enabled = enabled;
				}
			}
		}

		// RVA: 0x1341C4C Offset: 0x1341C4C VA: 0x1341C4C Slot: 22
		public void CallOpenEnd()
		{
			transform.GetComponent<CostumeCompWindow>().OpenEnd();
		}
	}
}
