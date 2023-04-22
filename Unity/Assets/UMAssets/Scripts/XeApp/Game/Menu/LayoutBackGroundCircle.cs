using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutBackGroundCircle : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_CircleAnim; // 0x14

		// RVA: 0x14BFE70 Offset: 0x14BFE70 VA: 0x14BFE70
		private void Start()
		{
			return;
		}

		// RVA: 0x14BFE74 Offset: 0x14BFE74 VA: 0x14BFE74
		private void Update()
		{
			return;
		}

		// // RVA: 0x14BFE78 Offset: 0x14BFE78 VA: 0x14BFE78
		public void Enter()
		{
			m_CircleAnim.StartChildrenAnimGoStop("go_on", "st_on");
		}

		// // RVA: 0x14BFF04 Offset: 0x14BFF04 VA: 0x14BFF04
		public void Leave()
		{
			m_CircleAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x14BFF90 Offset: 0x14BFF90 VA: 0x14BFF90
		public void loop()
		{
			m_CircleAnim.StartChildrenAnimLoop("logo_act_01", "st_stop");
		}

		// // RVA: 0x14C001C Offset: 0x14C001C VA: 0x14C001C
		public bool IsPlaying()
		{
			return m_CircleAnim.IsPlayingChildren();
		}

		// RVA: 0x14C0048 Offset: 0x14C0048 VA: 0x14C0048 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_CircleAnim = layout.FindViewByExId("root_sel_val_circle_sw_sel_val_circle") as AbsoluteLayout;
			return true;
		}
	}
}
