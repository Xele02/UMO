using System;

namespace XeApp.Game.Menu
{
	public class CostumeSelectViewOFF_Vertical_02 : LayoutModelViewModeBase
	{
		private Action m_updater; // 0x24

		// RVA: 0x16E7B50 Offset: 0x16E7B50 VA: 0x16E7B50
		private void Start()
		{
			m_updater = UpdateLoad;
		}

		// RVA: 0x16E7BD8 Offset: 0x16E7BD8 VA: 0x16E7BD8
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		// RVA: 0x16E7BEC Offset: 0x16E7BEC VA: 0x16E7BEC
		private void UpdateLoad()
		{
			if (!IsReady())
				return;
			Initialize("root_sel_cos_btn_viewoff_vertical_02_sw_cos_viewoff_btn_vertical_02_anim");
			m_updater = UpdateIdle;
		}

		// RVA: 0x16E7CAC Offset: 0x16E7CAC VA: 0x16E7CAC
		private void UpdateIdle()
		{
			return;
		}

		// RVA: 0x16E7CB0 Offset: 0x16E7CB0 VA: 0x16E7CB0
		private void WaitAnim()
		{
			if (base.IsPlaying())
				return;
			m_updater = UpdateIdle;
		}

		// RVA: 0x16E7D4C Offset: 0x16E7D4C VA: 0x16E7D4C Slot: 8
		public override bool IsPlaying()
		{
			return m_updater != UpdateIdle;
		}

		// RVA: 0x16E7DE4 Offset: 0x16E7DE4 VA: 0x16E7DE4 Slot: 9
		public override void Enter()
		{
			base.Enter();
			m_updater = WaitAnim;
		}

		// RVA: 0x16E7E78 Offset: 0x16E7E78 VA: 0x16E7E78 Slot: 10
		public override void Leave()
		{
			base.Leave();
			m_updater = WaitAnim;
		}
	}
}
