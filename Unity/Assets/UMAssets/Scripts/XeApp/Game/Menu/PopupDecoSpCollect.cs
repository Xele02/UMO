using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDecoSpCollect : UIBehaviour, IPopupContent
	{
		private LayoutDecorationSpCollectPopup m_layoutDecorationSpCollectPopup; // 0x10
		private bool m_isPositiveDisable; // 0x14
		private PopupWindowControl m_control; // 0x18
		private PopupDecoSpCollectSetting m_setting; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF78B58 Offset: 0xF78B58 VA: 0xF78B58 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as PopupDecoSpCollectSetting;
			Parent = m_setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_layoutDecorationSpCollectPopup = m_setting.Content.GetComponent<LayoutDecorationSpCollectPopup>();
			if(m_layoutDecorationSpCollectPopup != null)
			{
				m_layoutDecorationSpCollectPopup.Setting(m_setting.m_info);
			}
			m_control = control;
			Parent = setting.m_parent;
		}

		// RVA: 0xF78E64 Offset: 0xF78E64 VA: 0xF78E64 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF78E6C Offset: 0xF78E6C VA: 0xF78E6C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF78EA4 Offset: 0xF78EA4 VA: 0xF78EA4 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF78EDC Offset: 0xF78EDC VA: 0xF78EDC Slot: 21
		public bool IsReady()
		{
			return m_layoutDecorationSpCollectPopup == null || !m_layoutDecorationSpCollectPopup.IsLoading();
		}

		// RVA: 0xF78F9C Offset: 0xF78F9C VA: 0xF78F9C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
