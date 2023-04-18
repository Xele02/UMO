using System;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUnlockMusicContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupUnlockMusic m_music; // 0x10

		public Transform Parent { get; private set; } // 0xC
		public Action closeAction { get; set; } // 0x14

		// RVA: 0x115E4E4 Offset: 0x115E4E4 VA: 0x115E4E4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupUnlockMusicContentSetting ps = setting as PopupUnlockMusicContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = new Vector3(0, 0, 0);
			m_music = setting.Content.GetComponent<LayoutPopupUnlockMusic>();
			closeAction = ps.closeAction;
			if (m_music != null)
			{
				m_music.SetStatus(ps.UnlockInfo);
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x115E748 Offset: 0x115E748 VA: 0x115E748 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x115E750 Offset: 0x115E750 VA: 0x115E750
		public void Update()
		{
			return;
		}

		// RVA: 0x115E754 Offset: 0x115E754 VA: 0x115E754 Slot: 19
		public void Show()
		{
			if(m_music != null)
			{
				m_music.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x115E838 Offset: 0x115E838 VA: 0x115E838 Slot: 20
		public void Hide()
		{
			if (closeAction != null)
				closeAction();
			if(m_music != null)
			{
				m_music.Hide();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0x115E930 Offset: 0x115E930 VA: 0x115E930 Slot: 21
		public bool IsReady()
		{
			if(m_music != null)
			{
				return !m_music.IsLoading();
			}
			return true;
		}

		// RVA: 0x115E9F0 Offset: 0x115E9F0 VA: 0x115E9F0 Slot: 22
		public void CallOpenEnd()
		{
			if (m_music != null)
				m_music.StringAnimPlay();
		}
	}
}
