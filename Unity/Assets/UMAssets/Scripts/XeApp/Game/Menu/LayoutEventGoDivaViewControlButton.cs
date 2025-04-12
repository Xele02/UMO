using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaViewControlButton : LayoutUGUIScriptBase
	{
		public enum ButtonType
		{
			Hide = 0,
			Show = 1,
		}

		[SerializeField]
		private ActionButton m_ctrlButton; // 0x14
		[SerializeField]
		private RawImageEx m_imageCtrlButton; // 0x18
		private bool m_isShown; // 0x1C
		private AbsoluteLayout m_layoutMain; // 0x20
		private TexUVListManager m_uvManager; // 0x24
		public Action OnClickControlListener; // 0x28

		// // RVA: 0x1996764 Offset: 0x1996764 VA: 0x1996764
		public void Enter()
		{
			m_isShown = true;
			m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x19967F8 Offset: 0x19967F8 VA: 0x19967F8
		public void Leave()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x199688C Offset: 0x199688C VA: 0x199688C
		public void TryEnter()
		{
			if(!m_isShown)
				Enter();
		}

		// // RVA: 0x199689C Offset: 0x199689C VA: 0x199689C
		public void TryLeave()
		{
			if(m_isShown)
				Leave();
		}

		// // RVA: 0x19968AC Offset: 0x19968AC VA: 0x19968AC
		// public void Show() { }

		// // RVA: 0x1996930 Offset: 0x1996930 VA: 0x1996930
		public void Hide()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x19969B4 Offset: 0x19969B4 VA: 0x19969B4
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}

		// // RVA: 0x19969E0 Offset: 0x19969E0 VA: 0x19969E0
		public void SetButtonType(ButtonType type)
		{
			if(type == ButtonType.Show)
			{
				m_imageCtrlButton.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData("sel_me3_font_btn_08"));
			}
			else if(type == ButtonType.Hide)
			{
				m_imageCtrlButton.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData("sel_me3_font_btn_07"));
			}
		}

		// // RVA: 0x1996B34 Offset: 0x1996B34 VA: 0x1996B34
		private void OnClickControl()
		{
			if(OnClickControlListener != null)
				OnClickControlListener();
		}

		// RVA: 0x1996B48 Offset: 0x1996B48 VA: 0x1996B48 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvManager = uvMan;
			m_layoutMain = layout.FindViewById("sw_sel_me3_btn_c_icon_inout_anim") as AbsoluteLayout;
			m_ctrlButton.AddOnClickCallback(OnClickControl);
			Loaded();
			return true;
		}
	}
}
