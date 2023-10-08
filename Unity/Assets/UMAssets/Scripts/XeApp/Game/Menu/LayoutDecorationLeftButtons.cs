using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Security.Cryptography;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationLeftButtons : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_deco_left_btn_01_layout_root"; // 0x0
		private AbsoluteLayout m_baseButtonsAnim; // 0x14
		private AbsoluteLayout m_changeDecoHomeAnim; // 0x18
		[SerializeField]
		private ActionButton m_returnHomeButton; // 0x1C
		[SerializeField]
		private ActionButton m_returnDecoButton; // 0x20
		[SerializeField]
		private ActionButton m_returnLobbyButton; // 0x24
		[SerializeField]
		private ActionButton m_visitButton; // 0x28
		[SerializeField]
		private ActionButton m_boardButton; // 0x2C
		[SerializeField]
		private ActionButton m_allGetButton; // 0x30
		public Action OnClickReturnHomeButton; // 0x34
		public Action OnClickReturnDecoButton; // 0x38
		public Action OnClickReturnLobbyButton; // 0x3C
		public Action OnClickVisitDecoButton; // 0x40
		public Action OnClickDecoBoardButton; // 0x44
		public Action OnClickAllGetButton; // 0x48
		private TexUVListManager m_uvManager; // 0x4C
		private bool m_isEnter; // 0x50

		// RVA: 0x18AF57C Offset: 0x18AF57C VA: 0x18AF57C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_baseButtonsAnim = layout.FindViewById("sw_deco_left_btn_anim") as AbsoluteLayout;
			m_changeDecoHomeAnim = layout.FindViewById("swtbl_deco_home_ch") as AbsoluteLayout;
			m_returnHomeButton.AddOnClickCallback(() =>
			{
				//0x18AFD84
				OnClickReturnHomeButton();
			});
			m_returnDecoButton.AddOnClickCallback(() =>
			{
				//0x18AFDB0
				OnClickReturnDecoButton();
			});
			m_returnLobbyButton.AddOnClickCallback(() =>
			{
				//0x18AFDDC
				if(OnClickReturnLobbyButton != null)
					OnClickReturnLobbyButton();
			});
			m_visitButton.AddOnClickCallback(() =>
			{
				//0x18AFDF0
				OnClickVisitDecoButton();
			});
			m_boardButton.AddOnClickCallback(() =>
			{
				//0x18AFE1C
				if(OnClickDecoBoardButton != null)
					OnClickDecoBoardButton();
			});
			m_allGetButton.AddOnClickCallback(() =>
			{
				//0x18AFE30
				if(OnClickAllGetButton != null)
					OnClickAllGetButton();
			});
			m_uvManager = uvMan;
			m_isEnter = false;
			return true;
		}

		// RVA: 0x18AF8F8 Offset: 0x18AF8F8 VA: 0x18AF8F8
		public bool IsPlaying()
		{
			return m_baseButtonsAnim.IsPlayingChildren();
		}

		// RVA: 0x18AF924 Offset: 0x18AF924 VA: 0x18AF924
		public void Enter()
		{
			if(m_isEnter)
				return;
			m_isEnter = true;
			m_baseButtonsAnim.StartChildrenAnimGoStop("go_in", "st_in");
			m_changeDecoHomeAnim.StartChildrenAnimGoStop(0, 0);
			m_allGetButton.Disable = false;
		}

		// RVA: 0x18AFA10 Offset: 0x18AFA10 VA: 0x18AFA10
		public void EnterVisit()
		{
			if(m_isEnter)
				return;
			m_isEnter = true;
			m_baseButtonsAnim.StartChildrenAnimGoStop("go_in", "st_in");
			m_changeDecoHomeAnim.StartChildrenAnimGoStop(1, 1);
			m_allGetButton.Hidden = true;
		}

		// RVA: 0x18AFAFC Offset: 0x18AFAFC VA: 0x18AFAFC
		public void EnterLobbyVisit()
		{
			if(m_isEnter)
				return;
			m_isEnter = true;
			m_baseButtonsAnim.StartChildrenAnimGoStop("go_in", "st_in");
			m_changeDecoHomeAnim.StartChildrenAnimGoStop(2, 2);
			m_allGetButton.Hidden = true;
		}

		// RVA: 0x18AFBE8 Offset: 0x18AFBE8 VA: 0x18AFBE8
		public void Leave()
		{
			if(!m_isEnter)
				return;
			m_isEnter = false;
			m_baseButtonsAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x18AFC88 Offset: 0x18AFC88 VA: 0x18AFC88
		public void Hide()
		{
			m_baseButtonsAnim.StartChildrenAnimGoStop("st_wait", "st_wait");
		}
	}
}
