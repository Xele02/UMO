using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutGachaDrawButtonGroup : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textTelop; // 0x14
		[SerializeField]
		private Text m_textDesc; // 0x18
		[SerializeField]
		private Text m_textSetSale; // 0x1C
		[SerializeField]
		private Text m_textTicketName; // 0x20
		[SerializeField]
		private Text m_textTicketNum; // 0x24
		[SerializeField]
		private Text m_textTicketPeriod; // 0x28
		[SerializeField]
		private Text m_textEvTicketName; // 0x2C
		[SerializeField]
		private Text m_textEvTicketNum; // 0x30
		[SerializeField]
		private LayoutGachaDrawButton[] m_button; // 0x34
		[SerializeField]
		private RawImageEx m_imageTicketIcon; // 0x38
		[SerializeField]
		private RawImageEx m_imageEvTicketIcon; // 0x3C
		[SerializeField]
		private NumberBase m_numberStepNum; // 0x40
		[SerializeField]
		private NumberBase m_numberStepMax; // 0x44
		[SerializeField]
		private ActionButton m_buttonSetSale; // 0x48
		[SerializeField]
		private ActionButton m_buttonPeriod; // 0x4C
		private TexUVListManager m_uvMan; // 0x50
		private AbsoluteLayout m_layoutInOut; // 0x54
		private AbsoluteLayout m_layoutTelop; // 0x58
		private AbsoluteLayout m_layoutTicket; // 0x5C
		private AbsoluteLayout m_layoutStepOnOff; // 0x60
		private AbsoluteLayout m_layoutStepNum; // 0x64
		private AbsoluteLayout m_layoutEvTicket; // 0x68
		private BEPHBEGDFFK m_view; // 0x6C

		private LayoutGachaDrawButton ButtonL { get { return m_button[1]; } } //0x19AD6C0
		private LayoutGachaDrawButton ButtonR { get { return m_button[0]; } } //0x19AD700
		public Action<int> OnClickButton { private get; set; } // 0x70
		public Action OnClickSetSaleButton { private get; set; } // 0x74
		public Action OnClickPeriodButton { private get; set; } // 0x78

		// RVA: 0x19AD770 Offset: 0x19AD770 VA: 0x19AD770
		public void Setup(BEPHBEGDFFK view)
		{
			m_view = view;
			SetButtonType(view);
			SetGachaType(m_view);
			SetTicketInfo(m_view);
			SetTelopType(m_view);
		}

		//// RVA: 0x19AD7AC Offset: 0x19AD7AC VA: 0x19AD7AC
		public void SetButtonType(BEPHBEGDFFK view)
		{
			KOPCFBCDBPC stepRecord = view.DPBDFPPMIPH_Gacha.NECDFDNBHFK;
			if(stepRecord == null)
			{
				if(view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
				{
					BEPHBEGDFFK.DMBKENKBIJD d = view.EIPFDJBIOKN(false);
					if(d == null)
					{
						d = view.IIPOPGHKHBA(false);
					}
					if(view.DPBDFPPMIPH_Gacha.KACECFNECON.CICLLABDFFK_SaleButtonVisible)
					{
						ButtonL.Setup(view.DPBDFPPMIPH_Gacha, d.APHNELOFGAK_CurrencyId, d.KPIHBPMOGKL_LotCount, d.MEANCEOIMGE_Summon.NPPGKNGIFGK_Price, d.MDEIKCBEHHC_Kakutei, false, 0, 0, 0);
						ButtonR.Hidden = true;
						ButtonL.Hidden = false;
					}
					else
					{
						ButtonR.Setup(view.DPBDFPPMIPH_Gacha, d.APHNELOFGAK_CurrencyId, d.KPIHBPMOGKL_LotCount, d.MEANCEOIMGE_Summon.NPPGKNGIFGK_Price, d.MDEIKCBEHHC_Kakutei, false, 0, 0, 0);
						ButtonR.Disable = d.CMHHHCAKPCD() < 1;
						ButtonR.Hidden = false;
						ButtonL.Hidden = true;
					}
				}
				else if(view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
				{
					BEPHBEGDFFK.DMBKENKBIJD d = view.EIPFDJBIOKN(true);
					if(d == null)
					{
						d = view.IIPOPGHKHBA(true);
					}
					if(d.KPIHBPMOGKL_LotCount > 1)
					{
						ButtonR.Setup(view.DPBDFPPMIPH_Gacha, d.APHNELOFGAK_CurrencyId, d.KPIHBPMOGKL_LotCount, d.KPIHBPMOGKL_LotCount, d.MDEIKCBEHHC_Kakutei, false, 0, 0, 0);
						ButtonL.Setup(view.DPBDFPPMIPH_Gacha, d.APHNELOFGAK_CurrencyId, 1, 1, d.MDEIKCBEHHC_Kakutei, false, 0, 0, 0);
						ButtonR.Hidden = false;
						ButtonL.Hidden = false;
					}
					else
					{
						ButtonR.Setup(view.DPBDFPPMIPH_Gacha, d.APHNELOFGAK_CurrencyId, 1, 1, d.MDEIKCBEHHC_Kakutei, false, 0, 0, 0);
						ButtonR.Hidden = false;
						ButtonL.Hidden = true;
					}
				}
				else
				{
					BEPHBEGDFFK.DMBKENKBIJD d = view.EIPFDJBIOKN(true);
					if(view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category != GCAHJLOGMCI.KNMMOMEHDON_GachaType.ANFKBNLLJFN_7)
					{
						BEPHBEGDFFK.DMBKENKBIJD d2 = view.IIPOPGHKHBA(true);
						if(d != null && d2 != null)
						{
							ButtonR.Setup(d2, view.MFMBCIKGCFC());
							ButtonL.Setup(d, view.MFMBCIKGCFC());
							ButtonR.Hidden = false;
							ButtonL.Hidden = false;
							return;
						}
						d = view.EIPFDJBIOKN(true);
					}
					if(d == null)
						d = view.IIPOPGHKHBA(true);
					ButtonR.Setup(d, view.MFMBCIKGCFC());
					ButtonR.Hidden = false;
					ButtonL.Hidden = true;
				}
			}
			else
			{
				ButtonR.Setup(stepRecord, view);
				ButtonR.Hidden = false;
				ButtonL.Hidden = true;
			}
		}

		//// RVA: 0x19ADF9C Offset: 0x19ADF9C VA: 0x19ADF9C
		public void SetGachaType(BEPHBEGDFFK view)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string str = "";
			bool b1 = false;
			bool b2 = true;
			switch(view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category)
			{
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.PHABJLGFJNI_2:
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3:
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.JGDEHOGIENP_4:
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8:
					b1 = false;
					if (view.DPBDFPPMIPH_Gacha.KACECFNECON == null)
						break;
					if (string.IsNullOrEmpty(view.DPBDFPPMIPH_Gacha.KACECFNECON.KLMPFGOCBHC_Description))
					{
						if(view.DPBDFPPMIPH_Gacha.KACECFNECON.FLADABCFDFA_Pickup.Count < 1)
						{
							b1 = false;
							break;
						}
						b1 = false;
						str = bk.GetMessageByLabel("gacha_main_pickup_caution");
					}
					else
					{
						b1 = false;
						str = bk.GetMessageByLabel(view.DPBDFPPMIPH_Gacha.KLMPFGOCBHC_Description);
					}
					break;
				default:
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9:
					b1 = false;
					b2 = !view.DPBDFPPMIPH_Gacha.KACECFNECON.CICLLABDFFK_SaleButtonVisible;
					if(!b2)
					{
						int a = view.DPBDFPPMIPH_Gacha.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5);
						if (a == 0)
						{
							a = view.DPBDFPPMIPH_Gacha.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6);
						}
						string s = bk.GetMessageByLabel("gacha_main_ticket_sale_period");
						DateTime d = Utility.GetLocalDateTime(view.DPBDFPPMIPH_Gacha.HIPBEKBFNBG(a));
						str = string.Format(s, new object[4]
						{
							d.Month,
							d.Day,
							d.Hour,
							d.Minute
						});
						if(view.ALPOJNBHNDK())
						{
							if(!view.GPKAMGNBGAB())
							{
								b1 = false;
								str = bk.GetMessageByLabel("gacha_set_sale_desc_01");
								m_textSetSale.text = str;
							}
							else
							{
								str = bk.GetMessageByLabel("gacha_set_sale_desc_02");
								m_textSetSale.text = str;
								b1 = true;
							}
						}
						else
						{
							str = bk.GetMessageByLabel("gacha_set_sale_desc_03");
							m_textSetSale.text = str;
							b1 = true;
						}
					}
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10:
					str = bk.GetMessageByLabel("gacha_desc_03");
					b1 = false;
					break;
			}
			m_buttonSetSale.Disable = b1;
			m_buttonSetSale.Hidden = b2;
			m_textDesc.text = str;
		}

		//// RVA: 0x19AE82C Offset: 0x19AE82C VA: 0x19AE82C
		public void SetTicketInfo(BEPHBEGDFFK view)
		{
			long t = 0;
			int a = 0;
			BEPHBEGDFFK.DMBKENKBIJD d = view.PANFEKFCCOA();
			if(d == null)
			{
				d = view.LBEHCJMJBGC();
			}
			if(d != null)
			{
				a = d.CMHHHCAKPCD();
				t = view.ENDIPBKOIOL();
			}
			bool b1 = false;
			bool b2;
			string str;
			if(view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
			{
				b2 = true;
				str = "02";
			}
			else if(view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
			{
				b2 = true;
				b1 = true;
				str = "01";
			}
			else
			{
				str = "03";
				if (a > 0)
					str = "01";
				b2 = false;
				if (a > 0)
					b2 = true;
				b1 = true;
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(b1)
			{
				string str2 = bk.GetMessageByLabel("gacha_main_mpass_period");
				if(t != 0)
				{
					DateTime date = Utility.GetLocalDateTime(t);
					m_textTicketPeriod.text = string.Format(str2, new object[5]
					{
						date.Year, date.Month, date.Day, date.Hour, date.Minute
					});
					m_buttonPeriod.Disable = false;
				}
				else
				{
					m_textTicketPeriod.text = string.Format(str2, new object[5]
					{
						"--", "--", "--", "--", "--"
					});
					m_buttonPeriod.Disable = true;
				}
			}
			if(b2)
			{
				m_imageTicketIcon.enabled = false;
				int id = view.DPBDFPPMIPH_Gacha.FKKCFICCGMM(d.APHNELOFGAK_CurrencyId);
				if(id > 0)
				{
					GameManager.Instance.ItemTextureCache.Load(id, (IiconTexture icon) =>
					{
						//0x19B051C
						m_imageTicketIcon.enabled = true;
						m_imageTicketIcon.uvRect = new Rect(0, 0, 1, 1);
						icon.Set(m_imageTicketIcon);
					});
				}
				m_textTicketName.text = bk.GetMessageByLabel("gacha_ticket_name");
				m_textTicketNum.text = string.Format(JpStringLiterals.StringLiteral_14007, a);
			}
			m_layoutTicket.StartChildrenAnimGoStop(str);
			int c = view.DPBDFPPMIPH_Gacha.EDCAFNOBCOJ();
			if (c < 1)
			{
				m_layoutEvTicket.StartChildrenAnimGoStop("02");
			}
			else
			{
				m_textEvTicketNum.text = string.Format(JpStringLiterals.StringLiteral_14007, CIOECGOMILE.HHCJCDFCLOB.NBJOCMAJLPK_GetTotalCurrency(c));
				m_textEvTicketName.text = bk.GetMessageByLabel("gacha_ticket_ev_name");
				PMDCIJMMNGK_GachaTicket.EJAKHFONNGN tckt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(c);
				if(tckt == null)
				{
					m_layoutEvTicket.StartChildrenAnimGoStop("02");
				}
				else
				{
					m_imageEvTicketIcon.enabled = false;
					GameManager.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, c), (IiconTexture icon) =>
					{
						//0x19B067C
						m_imageEvTicketIcon.enabled = true;
						icon.Set(m_imageEvTicketIcon);
					});
					m_layoutEvTicket.StartChildrenAnimGoStop("01");
				}
			}
		}

		//// RVA: 0x19AF684 Offset: 0x19AF684 VA: 0x19AF684
		public void SetTelopType(BEPHBEGDFFK view)
		{
			string str = null;
			if(view.DPBDFPPMIPH_Gacha.NECDFDNBHFK == null)
			{
				m_layoutStepOnOff.StartChildrenAnimGoStop("01");
				if(view.DPBDFPPMIPH_Gacha.KACECFNECON != null)
				{
					str = view.DPBDFPPMIPH_Gacha.KACECFNECON.MKJPDIHLGBF_FreeMulti;
				}
			}
			else
			{
				m_layoutStepOnOff.StartChildrenAnimGoStop("02");
				int stepNum = view.DPBDFPPMIPH_Gacha.NECDFDNBHFK.LKHAAGIJEPG_PlayerStatus.DBNAGGGJDAB_CurrentStepIndex;
				m_numberStepNum.SetNumber(stepNum, 0);
				m_numberStepMax.SetNumber(view.DPBDFPPMIPH_Gacha.NECDFDNBHFK.BMFEGOMNECF_Step.Count);
				m_layoutStepNum.StartChildrenAnimGoStop(view.DPBDFPPMIPH_Gacha.NECDFDNBHFK.LKHAAGIJEPG_PlayerStatus.NMNLJFIDFJE_CurrentStepRestCount < 0 ? "02" : "01");
				MMNNAPPLHFM m = view.DPBDFPPMIPH_Gacha.NECDFDNBHFK.BMFEGOMNECF_Step[stepNum - 1];
				if(m != null)
				{
					str = m.KACECFNECON.KLMPFGOCBHC_Description;
				}
			}
			if(!string.IsNullOrEmpty(str))
			{
				m_layoutTelop.StartChildrenAnimGoStop("01");
				m_textTelop.text = str;
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				BEPHBEGDFFK.DMBKENKBIJD d = view.IIPOPGHKHBA(true);
				if(d != null && d.NCIBIAJJBFF > 0)
				{
					if (d.GLBEAENLHKC_MaxLimit < 2)
						m_textTelop.text = bk.GetMessageByLabel("gacha_telop_01");
					else
					{
						m_textTelop.text = string.Format(bk.GetMessageByLabel("gacha_telop_02"), d.NCIBIAJJBFF);
					}
					m_layoutTelop.StartChildrenAnimGoStop("01");
					return;
				}
				switch (view.DPBDFPPMIPH_Gacha.FJICMLBOJCH())
				{
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.HJNNKCMLGFL_0:
						m_layoutTelop.StartChildrenAnimGoStop("02");
						break;
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.LCLLMJGIMHC_1:
						m_layoutTelop.StartChildrenAnimGoStop("01");
						m_textTelop.text = bk.GetMessageByLabel("gacha_telop_06");
						break;
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.PBEMIDKNPNH_2:
						m_layoutTelop.StartChildrenAnimGoStop("01");
						m_textTelop.text = bk.GetMessageByLabel("gacha_telop_03");
						break;
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.DKIKNLEDDBK_3:
						m_layoutTelop.StartChildrenAnimGoStop("01");
						m_textTelop.text = string.Format(bk.GetMessageByLabel("gacha_telop_04"), d.MEANCEOIMGE_Summon.HCMGHDNNJOM());
						break;
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.AAPLMEGMNJA_4:
						m_layoutTelop.StartChildrenAnimGoStop("01");
						m_textTelop.text = bk.GetMessageByLabel("gacha_telop_05");
						break;
					default:
						break;
				}
			}
		}

		// RVA: 0x19AFEC4 Offset: 0x19AFEC4 VA: 0x19AFEC4
		public void Enter()
		{
			m_layoutInOut.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x19AFF50 Offset: 0x19AFF50 VA: 0x19AFF50
		public void Leave()
		{
			m_layoutInOut.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x19AFFDC Offset: 0x19AFFDC VA: 0x19AFFDC
		public bool IsPlaying()
		{
			return m_layoutInOut.IsPlayingChildren();
		}

		// RVA: 0x19B0008 Offset: 0x19B0008 VA: 0x19B0008 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_layoutInOut = layout.FindViewById("sw_gacha_btn") as AbsoluteLayout;
			m_layoutTelop = layout.FindViewById("sw_gacha_btn_cou_frm_onoff_anim") as AbsoluteLayout;
			m_layoutTicket = layout.FindViewById("swtbl_gacha_tikcet") as AbsoluteLayout;
			m_layoutStepOnOff = layout.FindViewById("gacha_btn_cou_frm") as AbsoluteLayout;
			m_layoutStepNum = layout.FindViewById("swtbl_stp_s") as AbsoluteLayout;
			m_layoutEvTicket = layout.FindViewById("sw_gacha_frm_ticket_eve_onoff_anim") as AbsoluteLayout;
			for(int i = 0; i < m_button.Length; i++)
			{
				int index = i;
				m_button[i].AddOnClickCallback(() =>
				{
					//0x19B07A8
					LayoutGachaDrawButton button = m_button[index];
					if (OnClickButton != null)
						OnClickButton(button.LotCount);
				});
			}
			m_buttonSetSale.AddOnClickCallback(() =>
			{
				//0x19B0780
				if (OnClickSetSaleButton != null)
					OnClickSetSaleButton();
			});
			m_buttonPeriod.AddOnClickCallback(() =>
			{
				//0x19B0794
				if (OnClickPeriodButton != null)
					OnClickPeriodButton();
			});
			Loaded();
			return true;
		}
	}
}
