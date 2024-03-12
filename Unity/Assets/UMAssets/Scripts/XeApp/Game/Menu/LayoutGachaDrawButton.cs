using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using XeSys;
using System.Text.RegularExpressions;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutGachaDrawButton : ActionButton
	{
		[SerializeField]
		private RawImageEx m_imageCostIcon; // 0x80
		[SerializeField]
		private RawImageEx m_imageKakuteiInfo; // 0x84
		[SerializeField]
		private RawImageEx[] m_imageButton; // 0x88
		[SerializeField]
		private Font m_fontKakutei; // 0x8C
		[SerializeField]
		private Text m_textKakutei; // 0x90
		[SerializeField]
		private List<Text> m_textLotCost; // 0x94
		[SerializeField]
		private NumberBase m_numberLotCount; // 0x98
		[SerializeField]
		private NumberBase m_numberLotCost; // 0x9C
		private TexUVListManager m_uvMan; // 0xA0
		private AbsoluteLayout m_layoutCostIcon; // 0xA4
		private AbsoluteLayout m_layoutLotCost; // 0xA8
		private AbsoluteLayout m_layoutKakuteiInfo; // 0xAC
		private AbsoluteLayout m_layoutFirstSale; // 0xB0
		private readonly string[,] m_buttonUvLabels = new string[2, 3]
			{
				{ "gacha_button_buy01a", "gacha_button_buy01b", "gacha_button_buy01c" },
				{ "gacha_button_buy00a", "gacha_button_buy00b", "gacha_button_buy00c" }
			}; // 0xB4

		public int LotCount { get; private set; } // 0xB8

		// RVA: 0x19AB854 Offset: 0x19AB854 VA: 0x19AB854
		public void Setup(BEPHBEGDFFK.DMBKENKBIJD info, BEPHBEGDFFK.ABBPGMEDDHD zone = 0)
		{
			int ticketCount = info.CMHHHCAKPCD();
			if(info.BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.NGAHKKOBGPA_9 || info.BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.BPPLDIBMPKH_10)
			{
				ticketCount = info.CMHHHCAKPCD();
			}
			Setup(info.DPBDFPPMIPH_Gacha, info.APHNELOFGAK_CurrencyId, info.KPIHBPMOGKL_LotCount, info.ILFAHJEJCMH_GetPrice(), info.MDEIKCBEHHC_Kakutei, info.JNMMPPILMBC, ticketCount, zone, info.JHNMKKNEENE_Time);
		}

		// RVA: 0x19ABD00 Offset: 0x19ABD00 VA: 0x19ABD00
		public void Setup(KOPCFBCDBPC stepUpRecord, BEPHBEGDFFK view)
		{
			int step = stepUpRecord.LKHAAGIJEPG_PlayerStatus.DBNAGGGJDAB_CurrentStepIndex;
			MMNNAPPLHFM m = stepUpRecord.BMFEGOMNECF_Step.Find((MMNNAPPLHFM x) =>
			{
				//0x19AD67C
				return step == x.AGBCJMMMLON_StepIndex;
			});
			Setup(view.DPBDFPPMIPH_Gacha, stepUpRecord.LKPHIGAFJKD_VirtualCurrency.PPFNGGCBJKC_Id, m.EKOFPNGPCIP_RareCount + m.MFFNDOEPJFO_NormalCount, m.LCJPKJMMIAP_CurrencyAmmount, m.KACECFNECON != null ? m.KACECFNECON.MDEIKCBEHHC : "", false, 0, view.MFMBCIKGCFC(), view.JHNMKKNEENE_Time);
		}

		// RVA: 0x19ABA40 Offset: 0x19ABA40 VA: 0x19ABA40
		public void Setup(LOBDIAABMKG gachaProduct, int currencyId, int lotCount, int price, string kakutei = "", bool isFirstSale = false, int ticketCount = 0, BEPHBEGDFFK.ABBPGMEDDHD zone = 0, long currentTime = 0)
		{
			SetCurrencyType(gachaProduct, currencyId, price, zone);
			LotCount = lotCount;
			m_numberLotCount.SetNumber(lotCount, 0);
			m_numberLotCost.SetNumber(price, 0);
			SetKakuteiType(kakutei);
			m_layoutFirstSale.StartChildrenAnimGoStop(isFirstSale ? "01" : "02");
			PMDCIJMMNGK_GachaTicket.EJAKHFONNGN tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(currencyId);
			SetButtonColor(isFirstSale, tkt != null);
			if (gachaProduct.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
			{
				Disable = LKBGPLDLNIK.JPIMHNNGJGI(currentTime) != 0;
			}
			else if (ticketCount < 1 || tkt == null)
			{
				Disable = false;
			}
			else
			{
				Disable = ticketCount < lotCount;
			}
		}

		//// RVA: 0x19ABFC0 Offset: 0x19ABFC0 VA: 0x19ABFC0
		public void SetCurrencyType(LOBDIAABMKG gachaProduct, int currencyId, int price, BEPHBEGDFFK.ABBPGMEDDHD zone)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string str = "";
			PMDCIJMMNGK_GachaTicket.EJAKHFONNGN tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(currencyId);
			int a = 4;
			if (tkt == null)
				a = (int)gachaProduct.INDDJNMPONH_Category - 1;
			switch(a)
			{
				case 0:
					m_layoutCostIcon.StartChildrenAnimGoStop("02");
					m_layoutLotCost.StartChildrenAnimGoStop("03");
					if(zone == BEPHBEGDFFK.ABBPGMEDDHD.KHLPAOENONH_2_Evening)
					{
						str = bk.GetMessageByLabel("gacha_cost_05");
					}
					else if(zone == BEPHBEGDFFK.ABBPGMEDDHD.HCBFMFONIOE_1_Afternoon)
					{
						str = bk.GetMessageByLabel("gacha_cost_04");
					}
					else if(zone == BEPHBEGDFFK.ABBPGMEDDHD.HNOJIKHAPHA_0_Morning)
					{
						str = bk.GetMessageByLabel("gacha_cost_03");
					}
					str = string.Format(str, 1);
					break;
				case 1:
				case 2:
				case 3:
				case 6:
				case 7:
					if(price < 1)
					{
						m_layoutCostIcon.StartChildrenAnimGoStop("02");
						m_layoutLotCost.StartChildrenAnimGoStop("03");
						str = bk.GetMessageByLabel("gacha_cost_06");
					}
					else
					{
						m_layoutCostIcon.StartChildrenAnimGoStop("01");
						m_layoutLotCost.StartChildrenAnimGoStop("01");
						str = EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 0) + bk.GetMessageByLabel("gacha_cost_01");
					}
					break;
				case 4:
				case 5:
					m_layoutCostIcon.StartChildrenAnimGoStop("01");
					m_layoutLotCost.StartChildrenAnimGoStop("01");
					str = EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, tkt.PPFNGGCBJKC_Id) + bk.GetMessageByLabel("gacha_cost_01");
					break;
				case 8:
					m_layoutCostIcon.StartChildrenAnimGoStop("01");
					m_layoutLotCost.StartChildrenAnimGoStop("02");
					str = bk.GetMessageByLabel("gacha_cost_02");
					break;
				case 9:
					m_layoutCostIcon.StartChildrenAnimGoStop("01");
					m_layoutLotCost.StartChildrenAnimGoStop("01");
					str = EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem, 1) + bk.GetMessageByLabel("gacha_cost_01");
					break;
				default:
					break;
			}
			for(int i = 0; i < m_textLotCost.Count; i++)
			{
				m_textLotCost[i].text = str;
			}
			int c = gachaProduct.FKKCFICCGMM(currencyId);
			if(c > 0)
			{
				GameManager.Instance.ItemTextureCache.Load(c, (IiconTexture icon) =>
				{
					//0x19AD42C
					m_imageCostIcon.enabled = true;
					m_imageCostIcon.uvRect = new Rect(0, 0, 1, 1);
					icon.Set(m_imageCostIcon);
				});
			}
		}

		//// RVA: 0x19AC820 Offset: 0x19AC820 VA: 0x19AC820
		public void SetKakuteiType(string kakutei)
		{
			if(kakutei == "")
			{
				m_layoutKakuteiInfo.StartChildrenAnimGoStop("02");
			}
			else
			{
				int v = 0;
				string s = "";
				if(Regex.IsMatch(kakutei, JpStringLiterals.StringLiteral_14844))
				{
					Match match = Regex.Match(kakutei, JpStringLiterals.StringLiteral_14845);
					int.TryParse(Regex.Replace(match.Value, JpStringLiterals.StringLiteral_14845, (Match p) =>
					{
						//0x19AD608
						return Convert.ToChar((p.Value[0] + 288) % 0xffff).ToString();
					}), out v);
					if (v < 5)
						s = "gacha_button_ribbon_b";
					else
						s = "gacha_button_ribbon_p";
				}
				else
				{
					s = "gacha_button_ribbon_b";
				}
				m_textKakutei.text = kakutei;
				TexUVData uvData = m_uvMan.GetUVData(s);
				if (uvData != null)
				{
					m_imageKakuteiInfo.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvData);
				}
				m_layoutKakuteiInfo.StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x19ACBD8 Offset: 0x19ACBD8 VA: 0x19ACBD8
		public void SetButtonColor(bool isFirstSale, bool isTicket)
		{
			for(int i = 0; i < m_imageButton.Length; i++)
			{
				m_imageButton[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_buttonUvLabels[!(isFirstSale || isTicket) ? 1 : 0, i]));
			}
		}

		// RVA: 0x19ACDA4 Offset: 0x19ACDA4 VA: 0x19ACDA4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			m_textKakutei.font = m_fontKakutei;
			m_textKakutei.material = m_fontKakutei.material;
#if UNITY_EDITOR || UNITY_STANDALONE
			BundleShaderInfo.Instance.FixMaterialShader(m_textKakutei.material);
#endif
			m_textKakutei.verticalOverflow = VerticalWrapMode.Overflow;
			m_textKakutei.horizontalOverflow = HorizontalWrapMode.Overflow;
			LayoutUGUIRuntime r = GetComponentInParent<LayoutUGUIRuntime>();
			AbsoluteLayout abs = r.FindViewBase(transform as RectTransform) as AbsoluteLayout;
			m_layoutCostIcon = abs.FindViewById("sw_icon_onoff_anim") as AbsoluteLayout;
			m_layoutLotCost = abs.FindViewById("swtbl_gacha_btn_fnt") as AbsoluteLayout;
			m_layoutKakuteiInfo = abs.FindViewById("swtbl_but_fnt_01") as AbsoluteLayout;
			m_layoutFirstSale = abs.FindViewById("sw_gacha_sale_onoff_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
