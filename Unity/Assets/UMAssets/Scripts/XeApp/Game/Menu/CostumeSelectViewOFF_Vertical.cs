using System;

namespace XeApp.Game.Menu
{
	public class CostumeSelectViewOFF_Vertical : LayoutModelViewModeBase
	{
		private Action m_updater; // 0x24

		// RVA: 0x16E778C Offset: 0x16E778C VA: 0x16E778C
		private void Start()
		{
			m_updater = UpdateLoad;
		}

		// RVA: 0x16E7814 Offset: 0x16E7814 VA: 0x16E7814
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		// RVA: 0x16E7828 Offset: 0x16E7828 VA: 0x16E7828
		private void UpdateLoad()
		{
			if (!IsReady())
				return;
			Initialize("root_sel_cos_btn_viewoff_vertical_sw_cos_viewoff_btn_vertical_anim");
			m_updater = UpdateIdle;
		}

		// RVA: 0x16E78E8 Offset: 0x16E78E8 VA: 0x16E78E8
		private void UpdateIdle()
		{
			return;
		}

		// RVA: 0x16E78EC Offset: 0x16E78EC VA: 0x16E78EC
		private void WaitAnim()
		{
			if (base.IsPlaying())
				return;
			m_updater = UpdateIdle;
		}

		// RVA: 0x16E7988 Offset: 0x16E7988 VA: 0x16E7988 Slot: 8
		public override bool IsPlaying()
		{
			return m_updater != UpdateIdle;
		}

		// RVA: 0x16E7A20 Offset: 0x16E7A20 VA: 0x16E7A20 Slot: 9
		public override void Enter()
		{
			base.Enter();
			m_updater = WaitAnim;
		}

		// RVA: 0x16E7AB4 Offset: 0x16E7AB4 VA: 0x16E7AB4 Slot: 10
		public override void Leave()
		{
			base.Leave();
			m_updater = WaitAnim;
		}
	}
}
