using XeApp.Game.Common;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using XeSys.Gfx;
using System.Text;

namespace XeApp.Game.Menu
{
	public class ScrollListButton : ActionButton
	{
		[SerializeField]
		private bool root_parent; // 0x80
		[SerializeField]
		private string parent_root_name; // 0x84
		[SerializeField]
		private string btn_root_name; // 0x88
		private Action m_updater; // 0x8C
		private bool m_click; // 0x90
		private ScrollRect m_scroll; // 0x94

		// RVA: 0xA65CA0 Offset: 0xA65CA0 VA: 0xA65CA0
		new private void Start()
		{
			base.Start();
		}

		//// RVA: 0xA65CA8 Offset: 0xA65CA8 VA: 0xA65CA8
		private void UpdateLoad()
		{
			LayoutUGUIHitOnly l = GetComponentInChildren<LayoutUGUIHitOnly>(true);
			if(l != null)
			{
				if(l.gameObject.activeSelf)
				{
					Button b = l.GetComponent<Button>();
					if(b != null)
					{
						m_updater = UpdateIdel;
						b.enabled = false;
					}
				}
			}
		}

		//// RVA: 0xA65E6C Offset: 0xA65E6C VA: 0xA65E6C
		private void UpdateIdel()
		{
			return;
		}

		// RVA: 0xA65E70 Offset: 0xA65E70 VA: 0xA65E70
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		// RVA: 0xA65E84 Offset: 0xA65E84 VA: 0xA65E84 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			if(root_parent)
			{
				StringBuilder str = new StringBuilder(transform.parent.name);
				str.Replace(" (AbsoluteLayout)", "");
				StringBuilder str2 = new StringBuilder(name);
				str2.Replace(" (AbsoluteLayout)", "");
				AbsoluteLayout a = layout.FindViewByExId(parent_root_name + "_" + str) as AbsoluteLayout;
				m_abs = a.FindViewByExId(btn_root_name + "_" + str2) as AbsoluteLayout;
			}
			m_updater = UpdateLoad;
			Loaded();
			return true;
		}

		//// RVA: 0xA66180 Offset: 0xA66180 VA: 0xA66180
		//public void Set_Scrollrect(ScrollRect scr) { }

		//// RVA: 0xA66188 Offset: 0xA66188 VA: 0xA66188
		//public bool IsBtnClick() { }

		// RVA: 0xA66190 Offset: 0xA66190 VA: 0xA66190 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			if(IsEventProcessed)
			{
				if (m_scroll != null)
					m_scroll.enabled = false;
			}
		}

		// RVA: 0xA66274 Offset: 0xA66274 VA: 0xA66274 Slot: 19
		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if (IsEventProcessed)
			{
				if (m_scroll != null)
					m_scroll.enabled = true;
			}
		}
	}
}
