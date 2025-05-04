using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LobbySignalWindow : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_windowBase; // 0x14
		public bool IsShow; // 0x18

		// RVA: 0xD203FC Offset: 0xD203FC VA: 0xD203FC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowBase = layout.FindViewByExId("root_sel_lobby_signal_01_lb_signal_anim_01") as AbsoluteLayout;
			return true;
		}

		// RVA: 0xD204C8 Offset: 0xD204C8 VA: 0xD204C8
		public void Enter()
		{
			if(m_windowBase != null)
			{
				m_windowBase.StartChildrenAnimGoStop("go_on", "st_on");
				IsShow = true;
			}
		}

		// // RVA: 0xD20550 Offset: 0xD20550 VA: 0xD20550
		// public void Hide() { }

		// // RVA: 0xD205CC Offset: 0xD205CC VA: 0xD205CC
		public void Leave()
		{
			if(m_windowBase != null)
			{
				m_windowBase.StartChildrenAnimGoStop("go_out", "st_out");
				IsShow = false;
			}
		}

		// RVA: 0xD20654 Offset: 0xD20654 VA: 0xD20654
		public void LoopAnim()
		{
			m_windowBase.StartChildrenAnimGoStop("logo_act_01");
			IsShow = true;
		}

		// RVA: 0xD206D8 Offset: 0xD206D8 VA: 0xD206D8
		public bool IsPlaying()
		{
			return m_windowBase.IsPlaying();
		}

		// // RVA: 0xD20704 Offset: 0xD20704 VA: 0xD20704
		// public void EnterToLoop() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EBA44 Offset: 0x6EBA44 VA: 0x6EBA44
		// // RVA: 0xD20728 Offset: 0xD20728 VA: 0xD20728
		// private IEnumerator Co_EnterToLoop() { }

		// // RVA: 0xD207D4 Offset: 0xD207D4 VA: 0xD207D4
		// public bool IsPlayingAnim() { }
	}
}
