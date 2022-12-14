using System;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class CostumeSelectViewOn : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_abs; // 0x14
		private ActionButton m_btn; // 0x18
		private Action m_updater; // 0x1C
		private bool m_isEntered; // 0x20

		// RVA: 0x16E7F14 Offset: 0x16E7F14 VA: 0x16E7F14 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_cos_view_btn_02") as AbsoluteLayout;
			m_btn = transform.Find("sw_cos_view_btn_02 (AbsoluteLayout)/sw_sel_cosl_view_btn_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			m_updater = UpdateLoad;
			return true;
		}

		// RVA: 0x16E8088 Offset: 0x16E8088 VA: 0x16E8088
		private void Start()
		{
			return;
		}

		// RVA: 0x16E808C Offset: 0x16E808C VA: 0x16E808C
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x16E80A0 Offset: 0x16E80A0 VA: 0x16E80A0
		private void UpdateLoad()
		{
			Loaded();
			m_updater = UpdateIdle;
		}

		//// RVA: 0x16E8134 Offset: 0x16E8134 VA: 0x16E8134
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0x16E8138 Offset: 0x16E8138 VA: 0x16E8138
		private void WaitAnim()
		{
			if (m_abs.IsPlayingChildren())
				return;
			m_updater = UpdateIdle;
		}

		//// RVA: 0x16DFEA4 Offset: 0x16DFEA4 VA: 0x16DFEA4
		public bool IsPlaying()
		{
			return m_updater != UpdateIdle;
		}

		//// RVA: 0x16DEDA4 Offset: 0x16DEDA4 VA: 0x16DEDA4
		public bool IsEntered()
		{
			return m_isEntered;
		}

		//// RVA: 0x16DEDAC Offset: 0x16DEDAC VA: 0x16DEDAC
		public void Enter()
		{
			if(!m_isEntered)
			{
				m_abs.StartChildrenAnimGoStop("go_in", "st_in");
				m_isEntered = true;
			}
			m_btn.enabled = true;
			m_updater = WaitAnim;
		}

		//// RVA: 0x16DEEAC Offset: 0x16DEEAC VA: 0x16DEEAC
		public void Leave()
		{
			if(m_isEntered)
			{
				m_abs.StartChildrenAnimGoStop("go_out", "st_out");
				m_isEntered = false;
			}
			m_btn.enabled = false;
			m_updater = WaitAnim;
		}

		//// RVA: 0x16E3708 Offset: 0x16E3708 VA: 0x16E3708
		public ActionButton GetButton()
		{
			return m_btn;
		}
	}
}
