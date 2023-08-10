using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutTuneUpBgCircle : LayoutUGUIScriptBase
	{
		private LayoutUGUIRuntime m_UGUIRuntime; // 0x14
		private AbsoluteLayout m_CircleAnim; // 0x18

		// RVA: 0x1536A88 Offset: 0x1536A88 VA: 0x1536A88
		private void Start()
		{
			m_UGUIRuntime = GetComponent<LayoutUGUIRuntime>();
		}

		// RVA: 0x1536AF0 Offset: 0x1536AF0 VA: 0x1536AF0
		private void Update()
		{
			return;
		}

		// RVA: 0x1536AF4 Offset: 0x1536AF4 VA: 0x1536AF4
		public void AnimationSpeedUp()
		{
			m_UGUIRuntime.TimeScale = 7.5f;
		}

		// RVA: 0x1536B28 Offset: 0x1536B28 VA: 0x1536B28
		public void DefaoultSpeed()
		{
			m_UGUIRuntime.TimeScale = 1;
		}

		// RVA: 0x1536B58 Offset: 0x1536B58 VA: 0x1536B58
		public void Enter()
		{
			m_CircleAnim.StartChildrenAnimGoStop("go_on", "st_on");
		}

		// RVA: 0x1536BE4 Offset: 0x1536BE4 VA: 0x1536BE4
		public void Leave()
		{
			m_CircleAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x1536C70 Offset: 0x1536C70 VA: 0x1536C70
		public void loop()
		{
			m_CircleAnim.StartChildrenAnimLoop("logo_act_01", "st_stop");
		}

		// RVA: 0x1536CFC Offset: 0x1536CFC VA: 0x1536CFC
		public bool IsPlaying()
		{
			return m_CircleAnim.IsPlayingChildren();
		}

		// RVA: 0x1536D28 Offset: 0x1536D28 VA: 0x1536D28 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			m_CircleAnim = layout.FindViewByExId("root_sel_val_circle_abi_sw_sel_val_circle_abi_anim") as AbsoluteLayout;
			return true;
		}
	}
}
