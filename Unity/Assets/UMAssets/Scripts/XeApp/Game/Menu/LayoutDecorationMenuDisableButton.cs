using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationMenuDisableButton : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_deco_exchange_01_layout_root"; // 0x0
		[SerializeField]
		private ActionButton m_menuDisableButton; // 0x14
		private AbsoluteLayout m_base; // 0x18
		public Action OnClickMenuDisableButton; // 0x1C
		private bool m_isEnter; // 0x20

		// RVA: 0x18B0508 Offset: 0x18B0508 VA: 0x18B0508 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = layout.FindViewById("sw_ui_onoff_btn_inout_anim") as AbsoluteLayout;
			m_base.StartChildrenAnimGoStop("st_wait", "st_wait");
			m_menuDisableButton.AddOnClickCallback(() =>
			{
				//0x18B0904
				OnClickMenuDisableButton();
			});
			m_isEnter = false;
			return true;
		}

		// RVA: 0x18B0668 Offset: 0x18B0668 VA: 0x18B0668
		public void Enter()
		{
			if(m_isEnter)
				return;
			m_isEnter = true;
			m_base.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x18B0708 Offset: 0x18B0708 VA: 0x18B0708
		public void Leave()
		{
			if(!m_isEnter)
				return;
			m_isEnter = false;
			m_base.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x18B07A8 Offset: 0x18B07A8 VA: 0x18B07A8
		// public void Hide() { }

		// RVA: 0x18B0828 Offset: 0x18B0828 VA: 0x18B0828
		public void SetDisable(bool isDisable)
		{
			m_menuDisableButton.Disable = isDisable;
		}

		// RVA: 0x18B085C Offset: 0x18B085C VA: 0x18B085C
		public bool IsPlaying()
		{
			return m_base.IsPlayingChildren();
		}
	}
}
