using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBannerItem : SelectScrollViewContent
	{
		[SerializeField]
		private RawImageEx m_imageBanner; // 0x14
		[SerializeField]
		private RawImageEx[] m_imageBadge; // 0x18
		[SerializeField]
		private RawImageEx m_imageEvTicket; // 0x1C
		[SerializeField]
		private ButtonBase m_button; // 0x20
		private TexUVListManager m_uvMan; // 0x24
		private AbsoluteLayout m_layoutSelect; // 0x28
		private AbsoluteLayout m_layoutBadge; // 0x2C
		private AbsoluteLayout m_layoutEvTicket; // 0x30
		private readonly string[] m_imageUvLabels = new string[3]
			{
				"gacha_main_icon_01", "gacha_main_icon_02", "gacha_main_icon_03"
			}; // 0x34

		public LOBDIAABMKG GachaProduct { get; private set; } // 0x38
		public Action<LayoutGachaBannerItem> OnClickButton { private get; set; } // 0x3C

		// RVA: 0x1996E54 Offset: 0x1996E54 VA: 0x1996E54
		public void Setup(LOBDIAABMKG product, HomeBannerTextureCache bannerTexCache, BEPHBEGDFFK.ABBPGMEDDHD timeZone, long currentTime)
		{
			GachaProduct = product;
			int v = product.FDEBLMKEMLF_TypeAndSeriesId;
			int.TryParse(product.IJADMGDHEIE, out v);
			m_imageBanner.enabled = false;
			bannerTexCache.LoadForGacha(v, (IiconTexture iconTex) =>
			{
				//0x1997A38
				m_imageBanner.enabled = true;
				(iconTex as HomeBannerTexture).SetForGachaListIcon(m_imageBanner);
			});
			if(product.EDCAFNOBCOJ() < 1)
			{
				m_layoutEvTicket.StartChildrenAnimGoStop("02");
			}
			else
			{
				PMDCIJMMNGK_GachaTicket.EJAKHFONNGN tckt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(product.EDCAFNOBCOJ());
				if (tckt == null)
				{
					m_layoutEvTicket.StartChildrenAnimGoStop("02");
				}
				else
				{
					m_imageEvTicket.enabled = false;
					GameManager.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, tckt.PPFNGGCBJKC_Id), (IiconTexture texture) =>
					{
						//0x1997B58
						m_imageEvTicket.enabled = true;
						texture.Set(m_imageEvTicket);
					});
					m_layoutEvTicket.StartChildrenAnimGoStop("01");
				}
			}
			if(product.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.DLOPEFGOAPD_10)
			{
				m_layoutBadge.StartChildrenAnimGoStop("02");
			}
			else if(product.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.CCAPCGPIIPF_1)
			{
				TexUVData data = m_uvMan.GetUVData(m_imageUvLabels[(int)timeZone]);
				for(int i = 0; i < m_imageBadge.Length; i++)
				{
					m_imageBadge[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(data);
				}
				m_layoutBadge.StartChildrenAnimGoStop(LKBGPLDLNIK.JPIMHNNGJGI(currentTime) == 0 ? "01" : "02");
			}
			else
			{
				TexUVData data = m_uvMan.GetUVData("gacha_main_icon_04");
				for (int i = 0; i < m_imageBadge.Length; i++)
				{
					m_imageBadge[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(data);
				}
				m_layoutBadge.StartChildrenAnimGoStop(GachaProduct.CADENLBDAEB ? "01" : "02");
			}
		}

		// RVA: 0x1997528 Offset: 0x1997528 VA: 0x1997528
		public void SetFocus(bool isSelect)
		{
			m_layoutSelect.StartChildrenAnimGoStop(isSelect ? "01" : "02");
		}

		// RVA: 0x19975BC Offset: 0x19975BC VA: 0x19975BC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_layoutSelect = layout.FindViewById("sw_bannar_onoff_anim") as AbsoluteLayout;
			m_layoutSelect.StartChildrenAnimGoStop("02");
			m_layoutBadge = layout.FindViewById("sw_gacha_main_icon_onoff") as AbsoluteLayout;
			m_layoutBadge.StartChildrenAnimGoStop("02");
			m_layoutEvTicket = layout.FindViewById("gacha_frm_ticket_icon_onoff_anim") as AbsoluteLayout;
			m_layoutEvTicket.StartChildrenAnimGoStop("02");
			m_button.AddOnClickCallback(() =>
			{
				//0x1997C5C
				if (OnClickButton != null)
					OnClickButton(this);
			});
			Loaded();
			return true;
		}
	}
}
