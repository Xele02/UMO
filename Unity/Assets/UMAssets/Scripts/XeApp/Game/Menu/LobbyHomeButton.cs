using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LobbyHomeButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton HomeButton; // 0x14
		private AbsoluteLayout m_root; // 0x18

		public Action OnClickHomeButton { get; set; } // 0x1C

		// RVA: 0x1292E24 Offset: 0x1292E24 VA: 0x1292E24
		private void Start()
		{
			return;
		}

		// RVA: 0x1292E28 Offset: 0x1292E28 VA: 0x1292E28
		private void Update()
		{
			return;
		}

		// RVA: 0x1292E2C Offset: 0x1292E2C VA: 0x1292E2C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewByExId("root_sel_lobby_home_btn_01_sw_deco_left_btn_anim") as AbsoluteLayout;
			HomeButton.AddOnClickCallback(() =>
			{
				//0x129317C
				if(OnClickHomeButton != null)
					OnClickHomeButton();
			});
			Hide();
			Loaded();
			return true;
		}

		// // RVA: 0x1292FD8 Offset: 0x1292FD8 VA: 0x1292FD8
		public void Enter()
		{
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x1293058 Offset: 0x1293058 VA: 0x1293058
		public void Leave()
		{
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x12930D8 Offset: 0x12930D8 VA: 0x12930D8
		// public void Show() { }

		// // RVA: 0x1292F68 Offset: 0x1292F68 VA: 0x1292F68
		public void Hide()
		{
			m_root.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x1293148 Offset: 0x1293148 VA: 0x1293148
		public bool IsPlayingChild()
		{
			return m_root.IsPlayingChildren();
		}
	}
}
