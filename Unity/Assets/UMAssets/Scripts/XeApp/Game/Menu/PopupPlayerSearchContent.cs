using UnityEngine.EventSystems;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupPlayerSearchContent : UIBehaviour, IPopupContent
	{
		[SerializeField]
		private PopupPlayerSearchRuntime m_popupUi; // 0xC
		private bool m_isInitialized; // 0x10
		private Transform m_parent; // 0x14

		public Transform Parent { get; private set; } // 0x18

		// RVA: 0x160AE84 Offset: 0x160AE84 VA: 0x160AE84
		private void Reset()
		{
			m_popupUi = GetComponent<PopupPlayerSearchRuntime>();
		}

		// RVA: 0x160AEEC Offset: 0x160AEEC VA: 0x160AEEC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PlayerSearchPopupSetting s = setting as PlayerSearchPopupSetting;
			Parent = s.m_parent;
			m_popupUi.SetMyId(s.myId);
			m_popupUi.SetFriendId(s.friendId);
			m_popupUi.SetFriendIdPlaceholder(s.friendIdPlaceholder);
			m_popupUi.onClickCopyButton = s.onClickCopyButton;
			m_popupUi.onClickSearchButton = s.onClickSearchButton;
			m_isInitialized = true;
			m_parent = s.m_parent;
		}

		// RVA: 0x160B238 Offset: 0x160B238 VA: 0x160B238 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x160B240 Offset: 0x160B240 VA: 0x160B240 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x160B278 Offset: 0x160B278 VA: 0x160B278 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			transform.SetParent(m_parent, false);
		}

		// RVA: 0x160B2EC Offset: 0x160B2EC VA: 0x160B2EC Slot: 21
		public bool IsReady()
		{
			return m_isInitialized;
		}

		// RVA: 0x160B2F4 Offset: 0x160B2F4 VA: 0x160B2F4 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
