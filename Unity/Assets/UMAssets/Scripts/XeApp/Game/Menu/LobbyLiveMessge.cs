using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LobbyLiveMessge : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_animRoot; // 0x14
		[SerializeField]
		private Text m_nameText; // 0x18

		// RVA: 0x12972C8 Offset: 0x12972C8 VA: 0x12972C8
		public void SetNmae(string name)
		{
			m_nameText.text = name;
		}

		// // RVA: 0x1297304 Offset: 0x1297304 VA: 0x1297304
		public void Enter()
		{
			m_animRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x1297390 Offset: 0x1297390 VA: 0x1297390
		public void Leave()
		{
			m_animRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x129741C Offset: 0x129741C VA: 0x129741C
		public void Hide()
		{
			m_animRoot.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x1297498 Offset: 0x1297498 VA: 0x1297498
		// public bool IsPlaying() { }

		// RVA: 0x12974C4 Offset: 0x12974C4 VA: 0x12974C4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_animRoot = layout.FindViewByExId("root_sel_lobby_live_02_sw_lb_live_fnt_01_anim") as AbsoluteLayout;
			Hide();
			return true;
		}
	}
}
