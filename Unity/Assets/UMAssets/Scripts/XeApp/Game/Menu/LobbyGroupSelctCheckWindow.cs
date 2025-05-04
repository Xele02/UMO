using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class LobbyGroupSelctCheckWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x672118 Offset: 0x672118 VA: 0x672118
		private ActionButton m_okButton; // 0x14
		//[HeaderAttribute] // RVA: 0x672164 Offset: 0x672164 VA: 0x672164
		[SerializeField]
		private ActionButton m_cancelButton; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6721C0 Offset: 0x6721C0 VA: 0x6721C0
		private RawImageEx m_bannerImage; // 0x1C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x67221C Offset: 0x67221C VA: 0x67221C
		private Text m_upText; // 0x20
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x672270 Offset: 0x672270 VA: 0x672270
		private Text m_downText; // 0x24
		private int m_bannerTexId; // 0x28
		private AbsoluteLayout m_windowBase; // 0x2C
		public Action onOkClickButton; // 0x30
		public Action onCancelClickButton; // 0x34
		private bool m_isLoadedBanner = true; // 0x38

		public int Id { set { m_bannerTexId = value; } } //0x1287068

		// RVA: 0x1287070 Offset: 0x1287070 VA: 0x1287070 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowBase = layout.FindViewByExId("root_sel_lobby_belong_01_sw_lb_belong_anim") as AbsoluteLayout;
			m_okButton.ClearOnClickCallback();
			m_okButton.AddOnClickCallback(() =>
			{
				//0x1287678
				if(m_okButton != null)
					onOkClickButton();
			});
			m_cancelButton.ClearOnClickCallback();
			m_cancelButton.AddOnClickCallback(() =>
			{
				//0x128772C
				if(m_cancelButton != null)
					onCancelClickButton();
			});
			return true;
		}

		// RVA: 0x1287234 Offset: 0x1287234 VA: 0x1287234
		public void SetBannerImage(int _texId)
		{
			m_isLoadedBanner = false;
			GameManager.Instance.LobbyTextureCache.LoadForLobbyGroupSelect(_texId, (IiconTexture icon) =>
			{
				//0x12877E0
				if(icon == null)
					return;
				Debug.Log("StringLiteral_18325 "+icon);
				if(m_bannerImage != null)
				{
					m_isLoadedBanner = true;
					icon.Set(m_bannerImage);
				}
			});
		}

		// // RVA: 0x128734C Offset: 0x128734C VA: 0x128734C
		public bool IsLoadedBanner()
		{
			return m_isLoadedBanner;
		}

		// RVA: 0x1287354 Offset: 0x1287354 VA: 0x1287354
		public void SetUpCheckMessge(string _text)
		{
			if(m_upText != null)
				m_upText.text = _text;
		}

		// RVA: 0x1287418 Offset: 0x1287418 VA: 0x1287418
		public void SetDownCheckMessge(string _text)
		{
			if(m_upText != null)
				m_downText.text = _text;
		}

		// RVA: 0x12874DC Offset: 0x12874DC VA: 0x12874DC
		public void Enter()
		{
			if(m_windowBase != null)
				m_windowBase.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x128755C Offset: 0x128755C VA: 0x128755C
		public void Hide()
		{
			if(m_windowBase != null)
				m_windowBase.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// // RVA: 0x12875D0 Offset: 0x12875D0 VA: 0x12875D0
		public void Leave()
		{
			if(m_windowBase != null)
				m_windowBase.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x1287650 Offset: 0x1287650 VA: 0x1287650
		public bool IsPlaying()
		{
			return m_windowBase != null && m_windowBase.IsPlaying();
		}
	}
}
