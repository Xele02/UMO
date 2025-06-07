using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class LobbyGroupSelectWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx[] m_bannerImage; // 0x14
		[SerializeField]
		private ActionButton m_groupSearchButton; // 0x18
		[SerializeField]
		private ActionButton[] m_Button; // 0x1C
		private bool[] m_isTexLoad; // 0x20
		private AbsoluteLayout m_windowBase; // 0x24
		private AbsoluteLayout m_bannerGroupAnim; // 0x28
		public Action onGroupSearchButton; // 0x2C
		public bool IsShow; // 0x30

		// RVA: 0x129287C Offset: 0x129287C VA: 0x129287C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowBase = layout.FindViewByExId("root_sel_lobby_group_01_sw_lb_group_01_anim") as AbsoluteLayout;
			m_bannerGroupAnim = layout.FindViewById("swtbl_group_banner") as AbsoluteLayout;
			m_groupSearchButton.ClearOnClickCallback();
			m_groupSearchButton.AddOnClickCallback(() =>
			{
				//0x1292B54
				if(m_groupSearchButton != null)
					onGroupSearchButton();
			});
			m_isTexLoad = new bool[m_Button.Length];
			for(int i = 0; i < m_bannerImage.Length; i++)
			{
				m_bannerImage[i].raycastTarget = false;
				m_isTexLoad[i] = false;
			}
			return true;
		}

		// RVA: 0x1289104 Offset: 0x1289104 VA: 0x1289104
		public void OnButtonCallBack(Action<int> _select)
		{
			for(int i = 0; i < m_Button.Length; i++)
			{
				int index = i;
				m_Button[i].AddOnClickCallback(() =>
				{
					//0x1292D80
					_select(index);
				});
			}
		}

		// // RVA: 0x128C7EC Offset: 0x128C7EC VA: 0x128C7EC
		public void SetBannerImage(int index, int texId)
		{
			Debug.Log("StringLiteral_18348 "+index+" "+texId);
			GameManager.Instance.LobbyTextureCache.LoadForLobbyGroupSelect(texId, (IiconTexture icon) =>
			{
				//0x1292C08
				if(icon != null)
				{
					icon.Set(m_bannerImage[index]);
					m_isTexLoad[index] = true;
				}
			});
		}

		// // RVA: 0x128C9F4 Offset: 0x128C9F4 VA: 0x128C9F4
		public bool IsSetTexture(int i)
		{
			return m_isTexLoad[i];
		}

		// // RVA: 0x128C6C4 Offset: 0x128C6C4 VA: 0x128C6C4
		public void BannerLayoutDataAnimation(int _animType)
		{
			if(_animType == 4)
			{
				m_bannerGroupAnim.StartAllAnimGoStop("03");
			}
			else if(_animType == 3)
			{
				m_bannerGroupAnim.StartAllAnimGoStop("02");
			}
			else if(_animType == 2)
			{
				m_bannerGroupAnim.StartAllAnimGoStop("01");
			}
			else
			{
				Debug.Log("StringLiteral_18349");
			}
		}

		// // RVA: 0x1287E20 Offset: 0x1287E20 VA: 0x1287E20
		public void Enter()
		{
			if(m_windowBase != null)
			{
				m_windowBase.StartChildrenAnimGoStop("go_in", "st_in");
				IsShow = true;
				for(int i = 0; i < m_Button.Length; i++)
				{
					m_Button[i].Disable = false;
				}
			}
		}

		// // RVA: 0x128A3D4 Offset: 0x128A3D4 VA: 0x128A3D4
		public void Hide()
		{
			if(m_windowBase != null)
			{
				m_windowBase.StartChildrenAnimGoStop("st_wait", "st_wait");
				IsShow = false;
			}
		}

		// // RVA: 0x1288188 Offset: 0x1288188 VA: 0x1288188
		public void Leave()
		{
			if(m_windowBase == null)
				return;
			m_windowBase.StartChildrenAnimGoStop("go_out", "st_out");
			IsShow = false;
			for(int i = 0; i < m_Button.Length; i++)
			{
				m_Button[i].Disable = true;
			}
		}

		// // RVA: 0x12882FC Offset: 0x12882FC VA: 0x12882FC
		public bool IsPlaying()
		{
			return m_windowBase != null && m_windowBase.IsPlaying();
		}
	}
}
