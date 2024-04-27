using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUnlockDivaContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupUnlockDiva m_diva; // 0x10
		private PopupUnlock.UnlockInfo m_unlockInfo; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x115DED8 Offset: 0x115DED8 VA: 0x115DED8 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupUnlockDivaContentSetting s = setting as PopupUnlockDivaContentSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_unlockInfo = s.UnlockInfo;
			m_diva = setting.Content.GetComponent<LayoutPopupUnlockDiva>();
			if(m_diva != null)
				m_diva.SetStatus(m_unlockInfo);
			gameObject.SetActive(true);
		}

		// RVA: 0x115E13C Offset: 0x115E13C VA: 0x115E13C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x115E144 Offset: 0x115E144 VA: 0x115E144
		public void Update()
		{
			return;
		}

		// RVA: 0x115E148 Offset: 0x115E148 VA: 0x115E148 Slot: 19
		public void Show()
		{
			if(m_diva != null)
				m_diva.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x115E22C Offset: 0x115E22C VA: 0x115E22C Slot: 20
		public void Hide()
		{
			if(m_diva != null)
				m_diva.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x115E310 Offset: 0x115E310 VA: 0x115E310 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x115E318 Offset: 0x115E318 VA: 0x115E318 Slot: 22
		public void CallOpenEnd()
		{
			m_diva.PlayVoice(m_unlockInfo);
			m_diva.PlayJoinAnim();
		}
	}
}
