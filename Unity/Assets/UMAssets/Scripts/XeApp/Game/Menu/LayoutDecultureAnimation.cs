using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutDecultureAnimation : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_layoutRoot; // 0x14

		// RVA: 0x18C8788 Offset: 0x18C8788 VA: 0x18C8788
		private void Update()
		{
			return;
		}

		// RVA: 0x18C878C Offset: 0x18C878C VA: 0x18C878C
		public void Enter()
		{
			m_layoutRoot.StartAllAnimGoStop("go_on", "st_on");
		}

		// RVA: 0x18C8818 Offset: 0x18C8818 VA: 0x18C8818
		public void Leave()
		{
			m_layoutRoot.StartAllAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x18C88A4 Offset: 0x18C88A4 VA: 0x18C88A4
		public void loop()
		{
			m_layoutRoot.StartAllAnimGoStop("logo_act_01", "st_stop");
		}

		// RVA: 0x18C8930 Offset: 0x18C8930 VA: 0x18C8930
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingChildren();
		}

		// RVA: 0x18C895C Offset: 0x18C895C VA: 0x18C895C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			m_layoutRoot = layout.FindViewByExId("sw_sel_val_abi_deculture_layout_root") as AbsoluteLayout;
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
