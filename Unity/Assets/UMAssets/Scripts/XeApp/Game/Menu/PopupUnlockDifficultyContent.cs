using System;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUnlockDifficultyContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupUnlockDifficulty m_difficulty; // 0x10

		public Transform Parent { get; private set; } // 0xC
		public Action closeAction { private get; set; } // 0x14

		// RVA: 0x115D7C4 Offset: 0x115D7C4 VA: 0x115D7C4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupUnlockDifficultySetting s = setting as PopupUnlockDifficultySetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_difficulty = setting.Content.GetComponent<LayoutPopupUnlockDifficulty>();
			closeAction = s.closeAction;
			if(m_difficulty != null)
			{
				m_difficulty.SetStatus(s.UnlockInfo);
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x115DA30 Offset: 0x115DA30 VA: 0x115DA30 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x115DA38 Offset: 0x115DA38 VA: 0x115DA38
		public void Update()
		{
			return;
		}

		// RVA: 0x115DA3C Offset: 0x115DA3C VA: 0x115DA3C Slot: 19
		public void Show()
		{
			if (m_difficulty != null)
				m_difficulty.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x115DB20 Offset: 0x115DB20 VA: 0x115DB20 Slot: 20
		public void Hide()
		{
			if (closeAction != null)
				closeAction();
			if (m_difficulty != null)
				m_difficulty.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x115DC18 Offset: 0x115DC18 VA: 0x115DC18 Slot: 21
		public bool IsReady()
		{
			return m_difficulty == null || !m_difficulty.IsLoading();
		}

		// RVA: 0x115DCD8 Offset: 0x115DCD8 VA: 0x115DCD8 Slot: 22
		public void CallOpenEnd()
		{
			if(m_difficulty != null)
			{
				m_difficulty.TitleAnimPlay();
			}
		}
	}
}
