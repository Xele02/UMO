using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDecoOptionPopup : UIBehaviour, IPopupContent
	{
		private PopupDecoOptionSetting m_setting; // 0x10
		private Transform m_parent; // 0x14

		public LayoutPopupConfigDeco LayoutPopupConfigDeco { get; set; } // 0xC
		public Transform Parent { get { return m_parent; } } //0x1346E54

		// RVA: 0x1346AEC Offset: 0x1346AEC VA: 0x1346AEC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as PopupDecoOptionSetting;
			m_parent = m_setting.m_parent;
			LayoutPopupConfigDeco = m_setting.LayoutPopupConfigDeco;
			m_setting.LayoutPopupConfigDeco.SaveData = m_setting.DecorationLocalSaveData;
			LayoutPopupConfigDeco.SetLayoutHeight();
			LayoutPopupConfigDeco.SetSizeDelta(PopupWindowControl.GetContentSize(m_setting.WindowSize, true));
			LayoutPopupConfigDeco.SetStatus(null);
			gameObject.SetActive(true);
		}

		// RVA: 0x1346D38 Offset: 0x1346D38 VA: 0x1346D38 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1346D40 Offset: 0x1346D40 VA: 0x1346D40 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1346D78 Offset: 0x1346D78 VA: 0x1346D78 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1346DB0 Offset: 0x1346DB0 VA: 0x1346DB0 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x1346E50 Offset: 0x1346E50 VA: 0x1346E50 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
