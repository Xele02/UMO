using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LobbyStampMakerButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton StampMakerButton; // 0x14
		private AbsoluteLayout m_root; // 0x18

		public Action OnClickStampButton { get; set; } // 0x1C

		// RVA: 0xD213F4 Offset: 0xD213F4 VA: 0xD213F4
		private void Start()
		{
			return;
		}

		// RVA: 0xD213F8 Offset: 0xD213F8 VA: 0xD213F8
		private void Update()
		{
			return;
		}

		// RVA: 0xD213FC Offset: 0xD213FC VA: 0xD213FC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewByExId("root_sel_lobby_btn_stmp_01_sw_deco_left_btn_anim") as AbsoluteLayout;
			StampMakerButton.AddOnClickCallback(() =>
			{
				//0xD2174C
				if (OnClickStampButton != null)
					OnClickStampButton();
			});
			Hide();
			Loaded();
			return true;
		}

		// RVA: 0xD215A8 Offset: 0xD215A8 VA: 0xD215A8
		public void Enter()
		{
			if (m_root != null)
				m_root.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0xD21628 Offset: 0xD21628 VA: 0xD21628
		public void Leave()
		{
			if(m_root != null)
				m_root.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0xD216A8 Offset: 0xD216A8 VA: 0xD216A8
		//public void Show() { }

		//// RVA: 0xD21538 Offset: 0xD21538 VA: 0xD21538
		public void Hide()
		{
			if (m_root != null)
				m_root.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0xD21718 Offset: 0xD21718 VA: 0xD21718
		public bool IsPlaying()
		{
			return m_root.IsPlaying();
		}
	}
}
