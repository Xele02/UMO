using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutGachaTitle : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_imageTitle; // 0x14
		[SerializeField]
		private Text m_textPeriod; // 0x18
		[SerializeField]
		private Text m_textDesc; // 0x1C
		[SerializeField]
		private Text m_textEvTicket; // 0x20
		private AbsoluteLayout m_layoutInOut; // 0x24
		private AbsoluteLayout m_layoutPeriod; // 0x28
		private AbsoluteLayout m_layoutEvTicket; // 0x2C

		// RVA: 0x1D4F0AC Offset: 0x1D4F0AC VA: 0x1D4F0AC
		public void Setup(BEPHBEGDFFK view)
		{
			int v = view.DPBDFPPMIPH.FDEBLMKEMLF_TypeAndSeriesId;
			int.TryParse(view.DPBDFPPMIPH.IJADMGDHEIE, out v);
			m_imageTitle.enabled = false;
			view.CEPJKBFGKEN.LoadForGacha(v, (IiconTexture iconTex) =>
			{
				//0x1D4F8BC
				m_imageTitle.enabled = true;
				(iconTex as HomeBannerTexture).SetForGachaTitle(m_imageTitle);
			});
			int a = view.DPBDFPPMIPH.EDCAFNOBCOJ();
			if (a < 1)
			{
				m_layoutEvTicket.StartChildrenAnimGoStop("02");
			}
			else
			{
				PMDCIJMMNGK_GachaTicket.EJAKHFONNGN dbTicket = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(a);
				if (dbTicket == null)
				{
					m_layoutEvTicket.StartChildrenAnimGoStop("02");
				}
				else
				{
					m_textEvTicket.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, dbTicket.PPFNGGCBJKC_Id));
					m_layoutEvTicket.StartChildrenAnimGoStop("01");
				}
			}
			if(view.DPBDFPPMIPH.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.CCAPCGPIIPF_1)
			{
				m_layoutPeriod.StartChildrenAnimGoStop("02");
				m_textPeriod.text = view.IFLJEIDBBPP();
			}
			else if(view.DPBDFPPMIPH.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.DLOPEFGOAPD_10)
			{
				m_layoutPeriod.StartChildrenAnimGoStop("04");
				m_textDesc.text = view.DPBDFPPMIPH.KACECFNECON.KLMPFGOCBHC_Description;
			}
			else if(view.DPBDFPPMIPH.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.ANFKBNLLJFN_7)
			{
				m_layoutPeriod.StartChildrenAnimGoStop("03");
				return;
			}
			else
			{
				m_layoutPeriod.StartChildrenAnimGoStop(view.DPBDFPPMIPH.KNMLPAAHAOF_IsStartGacha ? "03" : "01");
				m_textPeriod.text = view.MJLAFJJOGEE();
			}
		}

		// RVA: 0x1D4F5A8 Offset: 0x1D4F5A8 VA: 0x1D4F5A8
		public void Enter()
		{
			m_layoutInOut.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x1D4F634 Offset: 0x1D4F634 VA: 0x1D4F634
		public void Leave()
		{
			m_layoutInOut.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x1D4F6C0 Offset: 0x1D4F6C0 VA: 0x1D4F6C0
		public bool IsPlaying()
		{
			return m_layoutInOut.IsPlayingChildren();
		}

		// RVA: 0x1D4F6EC Offset: 0x1D4F6EC VA: 0x1D4F6EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutInOut = layout.FindViewById("sw_gacha_title_inout_anim") as AbsoluteLayout;
			m_layoutPeriod = layout.FindViewById("sw_gacha_limit_onoff_anim") as AbsoluteLayout;
			m_layoutEvTicket = layout.FindViewById("sw_gacha_frm_ticket_eve_title_onoff_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
