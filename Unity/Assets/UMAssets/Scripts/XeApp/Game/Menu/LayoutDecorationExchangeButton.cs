using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationExchangeButton : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_deco_exchange_02_layout_root"; // 0x0
		[SerializeField]
		private ActionButton m_exchangeButton; // 0x14
		private AbsoluteLayout m_base; // 0x18
		public Action OnClickExchangeButton; // 0x1C
		private bool m_isEnter; // 0x20

		// RVA: 0x19F0264 Offset: 0x19F0264 VA: 0x19F0264 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = layout.FindViewById("sw_exchange_btn_anim") as AbsoluteLayout;
			m_base.StartChildrenAnimGoStop("st_wait", "st_wait");
			m_exchangeButton.AddOnClickCallback(() =>
			{
				//0x19F0630
				OnClickExchangeButton();
			});
			m_isEnter = false;
			return true;
		}

		// RVA: 0x19F03C4 Offset: 0x19F03C4 VA: 0x19F03C4
		public void Enter()
		{
			if(m_isEnter)
				return;
			m_isEnter = true;
			m_base.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x19F0464 Offset: 0x19F0464 VA: 0x19F0464
		public void Leave()
		{
			if(!m_isEnter)
				return;
			m_isEnter = false;
			m_base.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x19F0504 Offset: 0x19F0504 VA: 0x19F0504
		public void Hide()
		{
			m_base.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// RVA: 0x19F0584 Offset: 0x19F0584 VA: 0x19F0584
		public bool IsPlayingEnd()
		{
			return !m_base.IsPlaying();
		}
	}
}
