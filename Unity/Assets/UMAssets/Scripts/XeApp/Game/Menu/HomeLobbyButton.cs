using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class HomeLobbyButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x670238 Offset: 0x670238 VA: 0x670238
		private ActionButton m_tabBtn; // 0x14
		private AbsoluteLayout m_typeAnim; // 0x18
		private AbsoluteLayout m_tabButtonsAnim; // 0x1C
		private AbsoluteLayout m_iconAnim; // 0x20
		private AbsoluteLayout m_iconEffAnim; // 0x24
		private NKOBMDPHNGP_EventRaidLobby m_evnetLobby; // 0x28
		private bool m_is_show; // 0x2C

		public ActionButton tabBtn { get { return m_tabBtn; } } //0x965EF8
		public Action onTabClickButton { private get; set; } // 0x30

		//// RVA: 0x965F10 Offset: 0x965F10 VA: 0x965F10
		public void Show(bool isEnd = false)
		{
			m_tabButtonsAnim.StartChildrenAnimGoStop(isEnd ? "st_in" : "go_in", "st_in");
			m_is_show = true;
		}

		//// RVA: 0x965FCC Offset: 0x965FCC VA: 0x965FCC
		public void Hide(bool isEnd = false)
		{
			if(m_is_show)
			{
				m_tabButtonsAnim.StartChildrenAnimGoStop(isEnd ? "st_out" : "go_out", "st_out");
				m_is_show = false;
			}
		}

		//// RVA: 0x966094 Offset: 0x966094 VA: 0x966094
		public void Wait()
		{
			m_tabButtonsAnim.StartChildrenAnimGoStop("st_wait");
			m_is_show = false;
		}

		//// RVA: 0x966118 Offset: 0x966118 VA: 0x966118
		//public bool IsShow() { }

		//// RVA: 0x966120 Offset: 0x966120 VA: 0x966120
		//public void SetType(HomeLobbyButtonController.Type a_type) { }

		//// RVA: 0x9661B8 Offset: 0x9661B8 VA: 0x9661B8
		public void SetNewIcon(bool a_enable, bool a_enable_efft)
		{
			if(a_enable)
			{
				IconEnable();
			}
			else
			{
				IconDisable();
			}
			TabEffectEnable(a_enable_efft);
		}

		//// RVA: 0x966260 Offset: 0x966260 VA: 0x966260
		public void IconDisable()
		{
			if(m_iconAnim != null)
				m_iconAnim.StartChildrenAnimGoStop("01", "01");
		}

		//// RVA: 0x9661EC Offset: 0x9661EC VA: 0x9661EC
		public void IconEnable()
		{
			if(m_iconAnim != null)
				m_iconAnim.StartChildrenAnimGoStop("02", "02");
		}

		//// RVA: 0x9662D4 Offset: 0x9662D4 VA: 0x9662D4
		public void TabEffectEnable(bool a_enable)
		{
			if(m_iconEffAnim != null)
			{
				m_iconEffAnim.StartChildrenAnimGoStop(a_enable ? "01" : "02");
			}
		}

		// RVA: 0x966360 Offset: 0x966360 VA: 0x966360 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB != null)
			{
				m_evnetLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_EventRaidLobby;
			}
			m_typeAnim = layout.FindViewById("swtbl_lobby_tb") as AbsoluteLayout;
			m_tabButtonsAnim = layout.FindViewById("sw_lobby_tb_anim_01") as AbsoluteLayout;
			m_iconAnim = layout.FindViewById("swtbl_new_icon_01") as AbsoluteLayout;
			m_iconEffAnim = layout.FindViewById("swtbl_lobby_tb_ef") as AbsoluteLayout;
			IconDisable();
			TabEffectEnable(false);
			m_tabBtn.AddOnClickCallback(() =>
			{
				//0x96670C
				if (onTabClickButton != null)
					onTabClickButton();
			});
			Loaded();
			return true;
		}
	}
}
