using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LobbyLiveSkipButton : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_animRoot; // 0x14
		[SerializeField]
		private ActionButton m_skipButton; // 0x18
		public Action OnClickSkip; // 0x1C

		// RVA: 0x12975A0 Offset: 0x12975A0 VA: 0x12975A0
		public void Enter()
		{
			m_animRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x129762C Offset: 0x129762C VA: 0x129762C
		public void Leave()
		{
			m_animRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x12976B8 Offset: 0x12976B8 VA: 0x12976B8
		public void Hide()
		{
			m_animRoot.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x1297734 Offset: 0x1297734 VA: 0x1297734
		// public bool IsPlaying() { }

		// RVA: 0x1297760 Offset: 0x1297760 VA: 0x1297760 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_animRoot = layout.FindViewByExId("root_sel_lobby_skip_sw_skip_inout_anim") as AbsoluteLayout;
			m_skipButton.AddOnClickCallback(() =>
			{
				//0x1297898
				if(OnClickSkip != null)
					OnClickSkip();
			});
			Hide();
			return true;
		}
	}
}
