using UnityEngine.EventSystems;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupTicketGainedContent : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		[SerializeField]
		private PopupTicketGainedRuntime m_popupUi; // 0xC
		private TicketGainedPopupSetting m_setting; // 0x10
		private bool m_isInitialized; // 0x14

		public Transform Parent { get; private set; } // 0x18

		// RVA: 0x1154554 Offset: 0x1154554 VA: 0x1154554 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as TicketGainedPopupSetting;
			Parent = setting.m_parent;
			GameManager.Instance.ItemTextureCache.Load(m_setting.itemId, (IiconTexture image) =>
			{
				//0x11547D0
				m_popupUi.SetItem(image);
				m_popupUi.SetText(m_setting.title, m_setting.label01, m_setting.label02, m_setting.layoutType);
				m_isInitialized = true;
			});
		}

		// RVA: 0x115473C Offset: 0x115473C VA: 0x115473C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1154744 Offset: 0x1154744 VA: 0x1154744 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x115477C Offset: 0x115477C VA: 0x115477C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x11547B4 Offset: 0x11547B4 VA: 0x11547B4 Slot: 21
		public bool IsReady()
		{
			return m_isInitialized;
		}

		// RVA: 0x11547BC Offset: 0x11547BC VA: 0x11547BC Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// RVA: 0x11547C0 Offset: 0x11547C0 VA: 0x11547C0 Slot: 24
		bool ILayoutUGUIPaste.InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return true;
		}
	}
}
