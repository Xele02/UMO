using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaDivaDecideButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_costumeChangeButton; // 0x14
		[SerializeField]
		private ActionButton m_okButton; // 0x18
		private bool m_isShown; // 0x1C
		private AbsoluteLayout m_layoutMain; // 0x20
		public Action OnClickCostumeChangeListener; // 0x24
		public Action OnClickOKListener; // 0x28

		// // RVA: 0x18CA0B8 Offset: 0x18CA0B8 VA: 0x18CA0B8
		public void Enter()
		{
			m_isShown = true;
			m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x18CA14C Offset: 0x18CA14C VA: 0x18CA14C
		public void Leave()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x18CA1E0 Offset: 0x18CA1E0 VA: 0x18CA1E0
		public void TryEnter()
		{
			if(!m_isShown)
				Enter();
		}

		// // RVA: 0x18CA1F0 Offset: 0x18CA1F0 VA: 0x18CA1F0
		public void TryLeave()
		{
			if(m_isShown)
				Leave();
		}

		// // RVA: 0x18CA200 Offset: 0x18CA200 VA: 0x18CA200
		// public void Show() { }

		// // RVA: 0x18CA284 Offset: 0x18CA284 VA: 0x18CA284
		public void Hide()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x18CA308 Offset: 0x18CA308 VA: 0x18CA308
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}

		// // RVA: 0x18CA334 Offset: 0x18CA334 VA: 0x18CA334
		private void OnClickCostumeChange()
		{
			if(OnClickCostumeChangeListener != null)
				OnClickCostumeChangeListener();
		}

		// // RVA: 0x18CA348 Offset: 0x18CA348 VA: 0x18CA348
		private void OnClickOK()
		{
			if(OnClickOKListener != null)
				OnClickOKListener();
		}

		// RVA: 0x18CA35C Offset: 0x18CA35C VA: 0x18CA35C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_layoutMain = layout.FindViewById("sw_sel_me3_btn_sel_inout_anim") as AbsoluteLayout;
			m_costumeChangeButton.AddOnClickCallback(OnClickCostumeChange);
			m_okButton.AddOnClickCallback(OnClickOK);
			Loaded();
			return true;
		}
	}
}
