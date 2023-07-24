using System;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DegreeSelectNoneBtn : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_abs; // 0x14
		private ActionButton m_btn; // 0x18
		private Action m_updater; // 0x1C

		// RVA: 0x17CE4B8 Offset: 0x17CE4B8 VA: 0x17CE4B8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewByExId("root_sel_deg_none_sw_sel_degree_none_frame") as AbsoluteLayout;
			m_btn = transform.Find("sw_sel_degree_none_frame (AbsoluteLayout)").GetComponent<ActionButton>();
			m_updater = UpdateLoad;
			return true;
		}

		// RVA: 0x17CE62C Offset: 0x17CE62C VA: 0x17CE62C
		private void Start()
		{
			return;
		}

		// RVA: 0x17CE630 Offset: 0x17CE630 VA: 0x17CE630
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x17CE644 Offset: 0x17CE644 VA: 0x17CE644
		private void UpdateLoad()
		{
			Loaded();
			m_updater = UpdateIdle;
		}

		//// RVA: 0x17CE6D8 Offset: 0x17CE6D8 VA: 0x17CE6D8
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0x17CE6DC Offset: 0x17CE6DC VA: 0x17CE6DC
		public void ActiveSelectAnim(bool enable)
		{
			if (enable)
				m_abs.StartAllAnimLoop("logo_on", "loen_on");
			else
				m_abs.StartAllAnimLoop("st_wait");
		}

		//// RVA: 0x17CE794 Offset: 0x17CE794 VA: 0x17CE794
		public ActionButton GetBtn()
		{
			return m_btn;
		}
	}
}
