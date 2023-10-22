using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDecoSpItemLevelup : UIBehaviour, IPopupContent
	{
		private Transform m_parent; // 0xC

		public Transform Parent { get { return m_parent; } } //0xF794D0

		// RVA: 0xF791CC Offset: 0xF791CC VA: 0xF791CC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupDecoSpItemLevelupePopupSetting s = setting as PopupDecoSpItemLevelupePopupSetting;
			LayoutDecorationSpItemLevelupContent l = s.Content.GetComponent<LayoutDecorationSpItemLevelupContent>();
			l.GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize(setting.WindowSize, true);
			l.UpdateContent(s.currentLevel, s.itemId);
			m_parent = setting.m_parent;
		}

		// RVA: 0xF793B4 Offset: 0xF793B4 VA: 0xF793B4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF793BC Offset: 0xF793BC VA: 0xF793BC Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF793F4 Offset: 0xF793F4 VA: 0xF793F4 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF7942C Offset: 0xF7942C VA: 0xF7942C Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xF794CC Offset: 0xF794CC VA: 0xF794CC Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
