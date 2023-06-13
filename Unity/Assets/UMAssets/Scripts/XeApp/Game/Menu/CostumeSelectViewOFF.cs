using System;

namespace XeApp.Game.Menu
{
	public class CostumeSelectViewOFF : LayoutModelViewModeBase
	{
		private Action m_updater; // 0x24

		// RVA: 0x16E73C8 Offset: 0x16E73C8 VA: 0x16E73C8
		private void Start()
		{
			m_updater = UpdateLoad;
		}

		// RVA: 0x16E7450 Offset: 0x16E7450 VA: 0x16E7450
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		// RVA: 0x16E7464 Offset: 0x16E7464 VA: 0x16E7464
		private void UpdateLoad()
		{
			if (!IsReady())
				return;
			Initialize("root_sel_cos_btn_viewoff_sw_cos_viewoff_btn_02");
			m_updater = UpdateIdle;
		}

		//// RVA: 0x16E7524 Offset: 0x16E7524 VA: 0x16E7524
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0x16E7528 Offset: 0x16E7528 VA: 0x16E7528
		private void WaitAnim()
		{
			if (base.IsPlaying())
				return;
			m_updater = UpdateIdle;
		}

		// RVA: 0x16E75C4 Offset: 0x16E75C4 VA: 0x16E75C4 Slot: 8
		public override bool IsPlaying()
		{
			return m_updater != UpdateIdle;
		}

		// RVA: 0x16E765C Offset: 0x16E765C VA: 0x16E765C Slot: 9
		public override void Enter()
		{
			base.Enter();
			m_updater = WaitAnim;
		}

		// RVA: 0x16E76F0 Offset: 0x16E76F0 VA: 0x16E76F0 Slot: 10
		public override void Leave()
		{
			base.Leave();
			m_updater = WaitAnim;
		}
	}
}
