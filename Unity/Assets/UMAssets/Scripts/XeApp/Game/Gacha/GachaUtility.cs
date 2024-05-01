
using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Menu;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Gacha
{
	public class GachaUtility
	{
		public enum CountType
		{
			None = 0,
			Single = 1,
			Multi = 2,
		}

		public enum LotType
		{
			None = 0,
			PaidVC = 1,
			Ticket = 2,
		}

		public enum Timezone
		{
			Morning = 0,
			Noon = 1,
			Night = 2,
		}

		public enum CancelCause
		{
			ClickButton = 0,
			ToPurchase = 1,
			TimeLimit = 2,
		}

		private class IconInfo
		{
			public int ItemId { get; private set; } // 0x8
			public string UvName { get; private set; } // 0xC

			// RVA: 0x999330 Offset: 0x999330 VA: 0x999330
			public IconInfo(int itemId, string uvName)
			{
				ItemId = itemId;
				UvName = uvName;
			}
		}

		private static GCAHJLOGMCI.KNMMOMEHDON_GachaType m_selectCategory = GCAHJLOGMCI.KNMMOMEHDON_GachaType.HJNNKCMLGFL_0; // 0x0
		private static int m_typeAndSeriesId = -1; // 0x4
		private static Action<Action> m_onClickLegalDesc = null; // 0x10
		private static PopPassController m_pop_pass_ctrl = null; // 0x38
		public const int DirectionCardMax = 10;
		private static DirectionInfo s_directionInfo = null; // 0x3C

		public static GCAHJLOGMCI.KNMMOMEHDON_GachaType selectCategory { get { return m_selectCategory; } set { m_selectCategory = value; } } //0x9873E8 0x9902C8
		public static int typeAndSeriesId { get { return m_typeAndSeriesId; } set { m_typeAndSeriesId = value; } } //0x990C3C 0x990E78
		public static LotType selectedLotType { get; private set; } // 0x8
		public static CountType selectedCountType { get; set; } // 0xC
		private static long currentGachaLimitTime { get; set; } // 0x18
		private static int timezoneMorn { get; set; } // 0x20
		private static int timezoneNoon { get; set; } // 0x24
		private static int timezoneNight { get; set; } // 0x28
		private static int timezoneEnd { get; set; } // 0x2C
		public static GachaUtility.Timezone currentTimezone { get; private set; } // 0x30
		public static bool canLotCurrentTimezone { get; private set; } // 0x34
		// public static bool hasDirectionInfo { get; } 0x995C38
		public static DirectionInfo directionInfo { get { return s_directionInfo; } } //0x989904
		public static GCAHJLOGMCI.NFCAJPIJFAM_SummonType netGachaCount { get; set; } // 0x40
		public static GCAHJLOGMCI.NFCAJPIJFAM_SummonType netGachaCountForAppearRate { get; private set; } // 0x44
		private static int netGachaProductIndex { get; set; } // 0x48
		private static HPBDNNACBAK gpm { get { return NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI; } } //0x990CC8
		private static CIOECGOMILE pdm { get { return CIOECGOMILE.HHCJCDFCLOB; } } //0x995E58
		// public static List<LOBDIAABMKG> netGachaProducts { get; } 0x995ED4
		public static LOBDIAABMKG netGachaProductData { get
			{
				if (netGachaProductIndex > -1)
					return gpm.MHKCPJDNJKI_GatchaProducts[netGachaProductIndex];
				return null;
			} } //0x9872D8
		public static KBPDNHOKEKD_ProductId netGachaSingleProduct { get
			{
				if(selectedLotType == LotType.Ticket)
				{
					return netGachaProduct;
				}
				KBPDNHOKEKD_ProductId p = netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.ODDGKAKAGLE_3);
				if (p != null)
					return p;
				return netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1);
			} } //0x987CB8
		public static KBPDNHOKEKD_ProductId netGachaMultiProduct { get
			{
				if(selectedLotType == LotType.Ticket)
				{
					return netGachaProduct;
				}
				if(selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8)
				{
					return netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.OBLEFFEJGIJ_8);
				}
				else
				{
					KBPDNHOKEKD_ProductId p = netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AKHEAGMMIAM_4);
					if (p != null)
						return p;
					return netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2);
				}
			}
		} //0x9881C0
		public static KBPDNHOKEKD_ProductId netGachaProduct { get
			{
				return netGachaProductData.DBHIEABGKII_GetSummon(netGachaCount);
			}
		} //0x995F6C
		public static int currentHavePaidVC { get
			{
				return pdm.DEAPMEIDCGC_GetTotalPaidCurrency() + Database.Instance.tutorialPaidVC;
			} } //0x996010

		// // RVA: 0x990358 Offset: 0x990358 VA: 0x990358
		public static void UpdateGachaProductCategory()
		{
			selectedLotType = LotType.None;
			switch(selectCategory)
			{
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1:
					netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.ODDGKAKAGLE_3;
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.PHABJLGFJNI_2:
					selectedLotType = LotType.PaidVC;
					netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2;
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3:
					selectedLotType = LotType.PaidVC;
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.JGDEHOGIENP_4:
					selectedLotType = LotType.PaidVC;
					netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2;
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.GKDFKDLFNAJ_5:
					selectedLotType = LotType.Ticket;
					netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6;
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.BKNHBNINDOC_6:
					selectedLotType = LotType.Ticket;
					netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2;
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.ANFKBNLLJFN_7:
					selectedLotType = LotType.PaidVC;
					netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1;
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8:
					selectedLotType = LotType.PaidVC;
					netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.OBLEFFEJGIJ_8;
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9:
					selectedLotType = LotType.Ticket;
					netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5;
					break;
				case GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10:
					selectedLotType = LotType.Ticket;
					netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1;
					break;
				default:
					break;
			}
			int idx;
			if (typeAndSeriesId == -1)
			{
				idx = gpm.MHKCPJDNJKI_GatchaProducts.FindIndex((LOBDIAABMKG p) =>
				{
					//0x996CE4
					return p.INDDJNMPONH_Category == m_selectCategory;
				});
			}
			else
			{
				idx = gpm.MHKCPJDNJKI_GatchaProducts.FindIndex((LOBDIAABMKG p) =>
				{
					//0x996D94
					return p.FDEBLMKEMLF_TypeAndSeriesId == typeAndSeriesId;
				});
			}
			netGachaProductIndex = idx;
			LOBDIAABMKG d = null;
			if (netGachaProductIndex >= 0)
			{
				d = gpm.MHKCPJDNJKI_GatchaProducts[netGachaProductIndex];
			}
			if (selectCategory != GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3)
				return;
			if(d.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AKHEAGMMIAM_4) != null)
			{
				netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AKHEAGMMIAM_4;
				return;
			}
			if(d.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2) != null)
			{
				netGachaCountForAppearRate = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2;
			}
		}

		// // RVA: 0x990F98 Offset: 0x990F98 VA: 0x990F98
		public static void UpdateCountType(bool isTicket)
		{
			GCAHJLOGMCI.NFCAJPIJFAM_SummonType value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.HJNNKCMLGFL_0;
			if (selectCategory >= GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1 && selectCategory <= GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
			{
				value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.OBLEFFEJGIJ_8;
				switch(selectCategory)
				{
					default:
						value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.HJNNKCMLGFL_0;
						if(selectedCountType == CountType.Single)
						{
							value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5;
							KBPDNHOKEKD_ProductId k = netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5);
							if(k == null || !isTicket)
							{
								value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.ODDGKAKAGLE_3;
								if (netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.ODDGKAKAGLE_3) == null)
									value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1;
							}
						}
						if(selectedCountType == CountType.Multi)
						{
							value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6;
							if(netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6) == null || !isTicket)
							{
								value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AKHEAGMMIAM_4;
								if (netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AKHEAGMMIAM_4) == null)
									value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2;
							}
						}
						break;
					case GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3:
						value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AKHEAGMMIAM_4;
						if(netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AKHEAGMMIAM_4) == null)
						{
							value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.HJNNKCMLGFL_0;
							if (netGachaProductData.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2) != null)
								value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2;
						}
						break;
					case GCAHJLOGMCI.KNMMOMEHDON_GachaType.GKDFKDLFNAJ_5:
					case GCAHJLOGMCI.KNMMOMEHDON_GachaType.BKNHBNINDOC_6:
					case GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9:
						value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.HJNNKCMLGFL_0;
						if (selectedCountType == CountType.Single)
							value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5;
						if (selectedCountType == CountType.Multi)
							value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6;
						break;
					case GCAHJLOGMCI.KNMMOMEHDON_GachaType.ANFKBNLLJFN_7:
					case GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10:
						value = GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1;
						break;
					case GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8:
						break;
				}
			}
			netGachaCount = value;
		}

		// // RVA: 0x9913B8 Offset: 0x9913B8 VA: 0x9913B8
		public static int GetMenuSinglePrice(GCAHJLOGMCI.KNMMOMEHDON_GachaType type, LotType lotType)
		{
			if(type != GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1 && type != GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8)
			{
				if(lotType != LotType.PaidVC)
				{
					return lotType == LotType.Ticket ? 1 : 0;
				}
				if (netGachaSingleProduct != null)
					return netGachaSingleProduct.NPPGKNGIFGK_Price;
			}
			return 0;
		}

		// // RVA: 0x99146C Offset: 0x99146C VA: 0x99146C
		public static int GetMenuMultiPrice(GCAHJLOGMCI.KNMMOMEHDON_GachaType type, LotType lotType)
		{
			if(type != GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
			{
				if(type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
				{
					return netGachaMultiProduct.NPPGKNGIFGK_Price;
				}
				else if(type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8)
				{
					return netGachaProductData.CHNFEEOJJCO(netGachaProductData.NECDFDNBHFK.LKHAAGIJEPG_PlayerStatus.DBNAGGGJDAB_CurrentStepIndex).LCJPKJMMIAP_CurrencyAmmount;
				}
				if(lotType == LotType.Ticket)
				{
					if(netGachaMultiProduct == null || netGachaMultiProduct.NPPGKNGIFGK_Price < 2)
					{
						return Mathf.Clamp(GetCurrentHaveTicket(), 2, 10);
					}
				}
				else if(lotType == LotType.PaidVC)
				{
					if (netGachaMultiProduct != null)
						return netGachaMultiProduct.NPPGKNGIFGK_Price;
				}
			}
			return 0;
		}

		// // RVA: 0x9916F8 Offset: 0x9916F8 VA: 0x9916F8
		public static int GetMenuSingleLotCount(GCAHJLOGMCI.KNMMOMEHDON_GachaType type)
		{
			if(type < GCAHJLOGMCI.KNMMOMEHDON_GachaType.AEFCOHJBLPO_11 && ((1 << (int)type) & 0x482U) != 0) // 0100 1000 0010
			{
				return 1;
			}
			if(netGachaSingleProduct != null)
			{
				return netGachaSingleProduct.JHAIOJELFHI_GetNumLot;
			}
			return 0;
		}

		// // RVA: 0x9917F0 Offset: 0x9917F0 VA: 0x9917F0
		public static int GetMenuMultiLotCount(GCAHJLOGMCI.KNMMOMEHDON_GachaType type, LotType lotType)
		{
			if(type != GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9 && lotType == LotType.Ticket)
			{
				return GetMenuMultiPrice(type, LotType.Ticket);
			}
			if(type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8)
			{
				MMNNAPPLHFM m = netGachaProductData.CHNFEEOJJCO(netGachaProductData.NECDFDNBHFK.LKHAAGIJEPG_PlayerStatus.DBNAGGGJDAB_CurrentStepIndex);
				return m.MFFNDOEPJFO_NormalCount + m.EKOFPNGPCIP_RareCount;
			}
			if (netGachaMultiProduct == null)
				return 0;
			return netGachaMultiProduct.JHAIOJELFHI_GetNumLot;
		}

		// // RVA: 0x987618 Offset: 0x987618 VA: 0x987618
		public static int GetMenuPrice(GCAHJLOGMCI.KNMMOMEHDON_GachaType type, CountType countType, GachaUtility.LotType lotType)
		{
			if(countType != CountType.Multi)
			{
				if(countType == CountType.Single)
				{
					return GetMenuSinglePrice(type, lotType);
				}
				return 0;
			}
			return GetMenuMultiPrice(type, lotType);
		}

		// // RVA: 0x991A0C Offset: 0x991A0C VA: 0x991A0C
		public static int GetMenuLotCount(GCAHJLOGMCI.KNMMOMEHDON_GachaType type, CountType countType, LotType lotType)
		{
			if(countType != CountType.Multi)
			{
				if(countType == CountType.Single)
				{
					return GetMenuSingleLotCount(type);
				}
				return 0;
			}
			return GetMenuMultiLotCount(type, lotType);
		}

		// // RVA: 0x991AE8 Offset: 0x991AE8 VA: 0x991AE8
		public static string GetGachaDetailWebViewTemplate()
		{
			if(m_selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8)
			{
				if(netGachaProductData.NJLONELPNCD.KACECFNECON_Desc != null)
					return netGachaProductData.NJLONELPNCD.KACECFNECON_Desc.OKDLGFMLLFH_Templ;
			}
			else
			{
				if(netGachaProductData.KACECFNECON != null)
					return netGachaProductData.KACECFNECON.OKDLGFMLLFH_Templ;
			}
			return "";
		}

		// // RVA: 0x9855F4 Offset: 0x9855F4 VA: 0x9855F4
		public static void RegisterLegalDesc(Action<Action> onClickButton)
		{
			m_onClickLegalDesc = onClickButton;
		}

		// // RVA: 0x985C44 Offset: 0x985C44 VA: 0x985C44
		public static void UnregisterLegalDesc()
		{
			m_onClickLegalDesc = null;
		}

		// // RVA: 0x991C30 Offset: 0x991C30 VA: 0x991C30
		private static void OnClickLegalDesc(Action endAction)
		{
			if (m_onClickLegalDesc == null)
				return;
			m_onClickLegalDesc(endAction);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C45B8 Offset: 0x6C45B8 VA: 0x6C45B8
		// // RVA: 0x991D2C Offset: 0x991D2C VA: 0x991D2C
		public static IEnumerator OpenGachaTicketSelectPopupCoroutine(BEPHBEGDFFK view, DenominationManager denomControl, Action onOk, Action<GachaUtility.CancelCause> onCancel, DJBHIFLHJLK onNetError, OnDenomChangeDate onChangeDate)
		{
			//0x9985E8
			UpdateGachaProductCategory();
			BEPHBEGDFFK.DMBKENKBIJD d0 = null;
			BEPHBEGDFFK.DMBKENKBIJD d1 = null;
			BEPHBEGDFFK.DMBKENKBIJD d2 = null;
			if (selectedCountType == CountType.Multi)
			{
				d0 = view.IIPOPGHKHBA(true);
				d1 = view.LBEHCJMJBGC();
				d2 = view.NILCJCEOBME();
			}
			else if(selectedCountType == CountType.Single)
			{
				d0 = view.EIPFDJBIOKN(true);
				d1 = view.PANFEKFCCOA();
				d2 = view.CLPPBCBBNIB();
			}
			GachaScene.SelectProductInfo = d0;
			if(selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.PHABJLGFJNI_2 || selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3 || selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.JGDEHOGIENP_4)
			{
				//LAB_009988d8
				int v1 = 1;
				KBPDNHOKEKD_ProductId.KNEKLJHNHAK v2 = 0;
				int v3 = 0;
				if(d1 != null)
				{
					v3 = d1.CMHHHCAKPCD();
					v1 = d1.ILFAHJEJCMH_GetPrice();
					v2 = d1.MEANCEOIMGE_Summon.FJICMLBOJCH();
				}
				int v4 = 0;
				int v5 = 1;
				if(d2 != null)
				{
					v4 = d2.CMHHHCAKPCD();
					v5 = d2.ILFAHJEJCMH_GetPrice();
				}
				if(v2 > KBPDNHOKEKD_ProductId.KNEKLJHNHAK.AAPLMEGMNJA_4 || ((1 << (int)v2) & 0x16U) == 0) // 0001 0110
				{
					if(v3 >= v1 || v4 >= v5)
					{
						bool wait = true;
						bool cancel = false;
						PopupGachaLotSelectSetting s = new PopupGachaLotSelectSetting();
						List<BEPHBEGDFFK.DMBKENKBIJD> l = new List<BEPHBEGDFFK.DMBKENKBIJD>();
						l.Add(d0);
						int windowSize = 0;
						if(v1 <= v3 && d1 != null)
						{
							l.Add(d1);
							windowSize = 1;
						}
						if(v5 <= v4 && d2 != null)
						{
							l.Add(d2);
							windowSize++;
						}
						s.ProductInfos = l;
						s.TitleText = netGachaProductData.OPFGFINHFCE_Name;
						s.WindowSize = (SizeType)windowSize;
						s.Buttons = new ButtonInfo[1]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
						};
						PopupWindowControl cont = PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0x99705C
							wait = false;
							cancel = true;
						}, null, null, null);
						s.OnClickButton = (BEPHBEGDFFK.DMBKENKBIJD productInfo) =>
						{
							//0x997068
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
							if (productInfo.APHNELOFGAK_CurrencyId == 1001)
								selectedLotType = LotType.PaidVC;
							else
								selectedLotType = LotType.Ticket;
							GachaScene.SelectProductInfo = productInfo;
							SetupGachaLimitTime(view.JHNMKKNEENE_Time);
							cont.Close(() =>
							{
								//0x997278
								wait = false;
							}, null);
						};
						//LAB_00998760;
						while (wait)
							yield return null;
						if (cancel)
							yield break;
					}
				}
			}
			yield return Co.R(OpenGachaPopupCoroutine(GachaScene.SelectProductInfo, denomControl, onOk, onCancel, onNetError, onChangeDate));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C4630 Offset: 0x6C4630 VA: 0x6C4630
		// // RVA: 0x98DE00 Offset: 0x98DE00 VA: 0x98DE00
		public static IEnumerator OpenGachaPopupCoroutine(BEPHBEGDFFK.DMBKENKBIJD selectProductInfo, DenominationManager denomControl, Action onOk, Action<GachaUtility.CancelCause> onCancel, DJBHIFLHJLK onNetError, OnDenomChangeDate onChangeDate)
		{
			bool toPurchaseVC; // 0x30
			bool isChangeDate; // 0x31

			//0x99743C
			UpdateCountType(selectedLotType == LotType.Ticket);
			Action tutoAction = null;
			if(GameManager.Instance.IsTutorial)
			{
				tutoAction = () =>
				{
					//0x996E34
					BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.PopupPositiveButton, null, null);
				};
			}
			toPurchaseVC = false;
			int v3_price = GetMenuPrice(selectCategory, selectedCountType, selectedLotType);
			int v2_lotCount = GetMenuLotCount(selectCategory, selectedCountType, selectedLotType);
			int v1_have = GetCurrentHaveTicket();
			if(selectProductInfo != null)
			{
				if(selectProductInfo.BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.NGAHKKOBGPA_9 || selectProductInfo.BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.BPPLDIBMPKH_10)
				{
					v3_price = selectProductInfo.ILFAHJEJCMH_GetPrice();
					v2_lotCount = selectProductInfo.MEANCEOIMGE_Summon.JHAIOJELFHI_GetNumLot;
					v1_have = selectProductInfo.CMHHHCAKPCD();
					netGachaCount = selectProductInfo.BJLONGBNPCI_SummonType;
				}
			}
			PopupSetting s = null;
			if (selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
			{
				string ticketName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(netGachaProductData.MJNOAMAFNHA_CostItemId);
				if (v3_price <= v1_have)
				{
					//LAB_00997dfc
					s = MakePopupSettingForTicket(ticketName, v1_have, v3_price, v2_lotCount);
					//LAB_00998190;
				}
				else if (EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem, 1) != netGachaProductData.MJNOAMAFNHA_CostItemId)
				{
					//LAB_009980f0
					s = MakePopupSettingForFewLimitedItem(ticketName, v1_have, v3_price);
					//LAB_00998190;
				}
				else
				{
					s = MakePopupSettingForFewPassTicket(ticketName, v1_have, v3_price, NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ());
					//LAB_00997d04
					toPurchaseVC = true;
				}
			}
			else if (selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
			{
				string ticketName = netGachaProductData.KAGBOMEDOLJ(netGachaProductData.OMNAPCHLBHF(netGachaCount));
				if (v3_price <= v1_have)
				{
					//LAB_00997dfc;
					s = MakePopupSettingForTicket(ticketName, v1_have, v3_price, v2_lotCount);
					//LAB_00998190;
				}
				else
				{
					s = MakePopupSettingForFewBonusTicket(ticketName, v1_have, v3_price, netGachaProductData.ALPOJNBHNDK(netGachaProductData.OMNAPCHLBHF(netGachaCount), NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()));
					//LAB_00997d04
					toPurchaseVC = true;
				}
			}
			else if (selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
			{
				//LAB_0099793c
				s = MakePopupSettingForFree();
			}
			else
			{
				if (selectedLotType == LotType.PaidVC)
				{
					if (IsNextFree())
					{
						//LAB_0099793c;
						s = MakePopupSettingForFree();
					}
					else if (currentHavePaidVC < v3_price)
					{
						s = MakePopupSettingForFewPaid(currentHavePaidVC, v3_price);
						//LAB_00997d04
						toPurchaseVC = true;
					}
					else
					{
						s = MakePopupSettingForPaid(currentHavePaidVC, v3_price, v2_lotCount);
					}
				}
				else if(selectedLotType == LotType.Ticket)
				{
					string ticketName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(selectProductInfo.APHNELOFGAK_CurrencyId).PPFNGGCBJKC_Id);
					if (v1_have < v3_price)
					{
						//LAB_009980f0
						s = MakePopupSettingForFewLimitedItem(ticketName, v1_have, v3_price);
						//LAB_00998190;
					}
					else
					{
						//LAB_00997dfc;
						s = MakePopupSettingForTicket(ticketName, v1_have, v3_price, v2_lotCount);
						//LAB_00998190;
					}
				}
			}
			//LAB_00998190
			bool isWait = true;
			bool isPositive = false;
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x99728C
				isWait = false;
				isPositive = type == PopupButton.ButtonType.Positive;
			}, null, null, tutoAction);
			while (isWait)
				yield return null;
			if(!toPurchaseVC)
			{
				if(!isPositive)
				{
					if (onCancel != null)
						onCancel(CancelCause.ClickButton);
				}
				else
				{
					if(!CheckLimitTime())
					{
						if (onOk != null)
							onOk();
					}
					else
					{
						if (onCancel != null)
							onCancel(CancelCause.TimeLimit);
					}
				}
			}
			else
			{
				TransitionList.Type result = TransitionList.Type.UNDEFINED;
				isChangeDate = PGIGNJDPCAH.MNANNMDBHMP(() =>
				{
					//0x9972AC
					result = TransitionList.Type.LOGIN_BONUS;
				}, () =>
				{
					//0x9972B8
					result = TransitionList.Type.TITLE;
				});
				yield return null;
				if(isChangeDate)
				{ 
					yield return new WaitWhile(() =>
					{
						//0x9972C4
						return result == TransitionList.Type.UNDEFINED;
					});
					if(onChangeDate != null)
						onChangeDate(result);
					yield break;
				}
				if(isPositive)
				{
					if(selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
					{
						yield return Co.R(OpenPurchasePassWindow(null));
					}
					else if(selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
					{
						yield return Co.R(OpenPurchaseVCWindow(denomControl, onNetError, onChangeDate, (LGDNAJACFHI paidVCProductData) =>
						{
							//0x996ED0
							int a = netGachaProductData.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5);
							if (a == 0)
								a = netGachaProductData.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6);
							return paidVCProductData.LHENLPLKGLP_StuffId == netGachaProductData.LPPJMOMKPKA(a);
						}));
					}
					else
					{
						yield return Co.R(OpenPurchaseVCWindow(denomControl, onNetError, onChangeDate, null));
					}
					if (onCancel != null)
						onCancel(CancelCause.ToPurchase);
				}
			}
		}

		// // RVA: 0x986F80 Offset: 0x986F80 VA: 0x986F80
		public static void SetupGachaLimitTime(long unixTime)
		{
			DateTime t = Utility.GetLocalDateTime(unixTime);
			currentGachaLimitTime = -1;
			if (selectCategory != GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
				return;
			currentTimezone = GetTimezoneFor(unixTime);
			int h;
			if(currentTimezone == Timezone.Morning)
			{
				h = timezoneNoon;
			}
			else if(currentTimezone == Timezone.Noon)
			{
				h = timezoneNight;
			}
			else if(currentTimezone == Timezone.Night)
			{
				h = timezoneEnd;
			}
			else
			{
				h = 0;
			}
			if(h > 23)
			{
				t = t.AddDays(1);
				h -= 24;
			}
			currentGachaLimitTime = Utility.GetTargetUnixTime(t.Year, t.Month, t.Day, h, 0, 0);
			canLotCurrentTimezone = LKBGPLDLNIK.JPIMHNNGJGI(unixTime) == 0;
		}

		// // RVA: 0x992564 Offset: 0x992564 VA: 0x992564
		private static bool CheckLimitTime()
		{
			if (currentGachaLimitTime < 0)
				return false;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			return t >= currentGachaLimitTime;
		}

		// // RVA: 0x992A24 Offset: 0x992A24 VA: 0x992A24
		public static void SetupFreeTimezone()
		{
			timezoneMorn = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.FPBEBCIPEPI_GachaHour[0];
			timezoneNoon = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.FPBEBCIPEPI_GachaHour[1];
			timezoneNight = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.FPBEBCIPEPI_GachaHour[2];
			timezoneEnd = timezoneMorn + 24;
		}

		// // RVA: 0x991F98 Offset: 0x991F98 VA: 0x991F98
		public static Timezone GetTimezoneFor(long unixTime)
		{
			DateTime date = Utility.GetLocalDateTime(unixTime);
			if(date.Hour > -1)
			{
				if (date.Hour < timezoneMorn)
					return Timezone.Night;
			}
			if(timezoneMorn <= date.Hour)
			{
				if (date.Hour < timezoneNoon)
					return Timezone.Morning;
			}
			if(timezoneNoon <= date.Hour)
			{
				if (date.Hour < timezoneNight)
					return Timezone.Noon;
			}
			if (date.Hour < timezoneNight)
				return Timezone.Morning;
			else
			{
				if (timezoneEnd <= date.Hour)
					return Timezone.Morning;
				return Timezone.Night;
			}
		}

		// // RVA: 0x992C04 Offset: 0x992C04 VA: 0x992C04
		// public static string MakeTimezoneDesc() { }

		// // RVA: 0x9930E8 Offset: 0x9930E8 VA: 0x9930E8
		// private static string MakeTime(string fmt, int minutes) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C4788 Offset: 0x6C4788 VA: 0x6C4788
		// // RVA: 0x9931A0 Offset: 0x9931A0 VA: 0x9931A0
		public static IEnumerator OpenPurchaseVCWindow(DenominationManager denomControl, DJBHIFLHJLK onNetError, OnDenomChangeDate onChangeDate, ProductListFilter filter)
		{
			//0x9990CC
			bool isWait = true;
			denomControl.StartPurchaseSequence(() =>
			{
				//0x9972E0
				isWait = false;
			}, () =>
			{
				//0x997378
				isWait = false;
			}, onNetError, onChangeDate, filter);
			while (isWait)
				yield return null;
		}

		// // RVA: 0x993298 Offset: 0x993298 VA: 0x993298
		public static void OpenFewVCPopup(Action onClose)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = netGachaProductData.OPFGFINHFCE_Name;
			s.WindowSize = SizeType.Middle;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.Text = bk.GetMessageByLabel("popup_gacha_lot_paid_few_msg");
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x997410
				if(onClose != null)
					onClose();
			}, null, null, null);
		}

		// // RVA: 0x9935E4 Offset: 0x9935E4 VA: 0x9935E4
		public static void OpenTimeLimitPopup(Action onClose)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string msg = "";
			if(selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
			{
				msg = bk.GetMessageByLabel("popup_gacha_reject_free_timeout_msg");
			}
			else if(selectCategory >= GCAHJLOGMCI.KNMMOMEHDON_GachaType.GKDFKDLFNAJ_5 && selectCategory <= GCAHJLOGMCI.KNMMOMEHDON_GachaType.BKNHBNINDOC_6)
			{
				msg = bk.GetMessageByLabel("popup_gacha_reject_ticket_timeout_msg");
			}
            TextPopupSetting s = PopupWindowManager.CrateTextContent("", SizeType.Small, msg, new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true);
			s.IsCaption = !string.IsNullOrEmpty(s.TitleText);
            PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x997424
				if(onClose != null)
					onClose();
			}, null, null, null);
		}

		// // RVA: 0x993928 Offset: 0x993928 VA: 0x993928
		public static void InitPurchasePassWindow(Transform transform)
		{
			if(m_pop_pass_ctrl == null)
			{
				if (transform == null)
					return;
				m_pop_pass_ctrl = transform.gameObject.AddComponent<PopPassController>();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C4800 Offset: 0x6C4800 VA: 0x6C4800
		// // RVA: 0x993AD0 Offset: 0x993AD0 VA: 0x993AD0
		public static IEnumerator OpenPurchasePassWindow(Transform transform)
		{
			//0x998F40
			InitPurchasePassWindow(transform);
			yield return Co.R(m_pop_pass_ctrl.CoroutineOpen());
		}

		// // RVA: 0x993B7C Offset: 0x993B7C VA: 0x993B7C
		private static PopupSetting MakePopupSettingForPaid(int havePaidVC, int price, int lotCount)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			GachaLotPopupSetting s = new GachaLotPopupSetting();
			s.WindowSize = SizeType.Middle;
			s.TitleText = netGachaProductData.OPFGFINHFCE_Name;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.MessageText = MakePopupMessage(bk.GetMessageByLabel("popup_gacha_lot_paid_msg"), price, lotCount);
			s.HoldCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_paid_count"), havePaidVC);
			s.CurrencyIsTicket = false;
			s.OnClickLegalDescButton = OnClickLegalDesc;
			return s;
		}

		// // RVA: 0x994050 Offset: 0x994050 VA: 0x994050
		private static PopupSetting MakePopupSettingForFewPaid(int havePaidVC, int price)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			GachaLotFewPopupSetting s = new GachaLotFewPopupSetting();
			s.WindowSize = SizeType.Middle;
			s.TitleText = netGachaProductData.OPFGFINHFCE_Name;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Purchase, Type = PopupButton.ButtonType.Positive }
			};
			s.MessageText = bk.GetMessageByLabel("popup_gacha_lot_paid_few_msg");
			s.HoldCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_paid_count"), havePaidVC);
			s.NeedCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_paid_count"), price);
			s.CurrencyIsTicket = false;
			s.IsTicketPeriod = true;
			s.OnClickLegalDescButton = OnClickLegalDesc;
			return s;
		}

		// // RVA: 0x994438 Offset: 0x994438 VA: 0x994438
		private static PopupSetting MakePopupSettingForFree()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.WindowSize = SizeType.Small;
			s.TitleText = netGachaProductData.OPFGFINHFCE_Name;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.Text = MakePopupMessage(bk.GetMessageByLabel("popup_gacha_lot_free_msg"), GetMenuLotCount(selectCategory, selectedCountType, selectedLotType));
			return s;
		}

		// // RVA: 0x994804 Offset: 0x994804 VA: 0x994804
		private static PopupSetting MakePopupSettingForTicket(string ticketName, int haveTicket, int price, int lotCount)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int a = netGachaProductData.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5);
			if(a == 0)
			{
				netGachaProductData.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6);
			}
			GachaLotPopupSetting s = new GachaLotPopupSetting();
			s.WindowSize = SizeType.Middle;
			s.TitleText = netGachaProductData.OPFGFINHFCE_Name;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.MessageText = MakePopupMessage(bk.GetMessageByLabel("popup_gacha_lot_ticket_msg"), ticketName, price, lotCount);
			s.CurrencyIsTicket = true;
			s.HoldCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_count"), haveTicket);
			s.OnClickLegalDescButton = null;
			return s;
		}

		// // RVA: 0x994D58 Offset: 0x994D58 VA: 0x994D58
		private static PopupSetting MakePopupSettingForFewBonusTicket(string ticketName, int haveTicket, int price, bool isPeriod)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			GachaLotFewPopupSetting s = new GachaLotFewPopupSetting();
			s.WindowSize = SizeType.Middle;
			s.TitleText = netGachaProductData.OPFGFINHFCE_Name;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = isPeriod ? PopupButton.ButtonLabel.Purchase : PopupButton.ButtonLabel.Expired, Type = PopupButton.ButtonType.Positive }
			};
			s.MessageText = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_few_msg"), ticketName);
			s.HoldCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_count"), haveTicket);
			s.NeedCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_count"), price);
			s.CurrencyIsTicket = true;
			s.MessageCaution = string.Format(bk.GetMessageByLabel(isPeriod ? "popup_gacha_lot_ticket_few_caution_01" : "popup_gacha_lot_ticket_few_caution_02"), ticketName);
			s.IsTicketPeriod = isPeriod;
			s.OnClickLegalDescButton = null;
			return s;
		}

		// // RVA: 0x9951C4 Offset: 0x9951C4 VA: 0x9951C4
		private static PopupSetting MakePopupSettingForFewPassTicket(string ticketName, int haveTicket, int price, int status)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			GachaLotFewPopupSetting s = new GachaLotFewPopupSetting();
			if (status == 0 || status == -3)
			{
				s.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.PassPurchase, Type = PopupButton.ButtonType.Positive }
				};
				s.MessageCaution = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_few_caution_03"), ticketName);
			}
			else
			{
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				s.MessageCaution = "";
			}
			s.WindowSize = SizeType.Middle;
			s.TitleText = netGachaProductData.OPFGFINHFCE_Name;
			s.MessageText = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_few_msg"), ticketName);
			s.HoldCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_count"), haveTicket);
			s.NeedCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_count"), price);
			s.CurrencyIsTicket = true;
			s.IsTicketPeriod = false;
			s.OnClickLegalDescButton = null;
			return s;
		}

		// // RVA: 0x9956A8 Offset: 0x9956A8 VA: 0x9956A8
		private static PopupSetting MakePopupSettingForFewLimitedItem(string ticketName, int haveTicket, int price)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			GachaLotFewPopupSetting s = new GachaLotFewPopupSetting();
			s.WindowSize = SizeType.Middle;
			s.TitleText = netGachaProductData.OPFGFINHFCE_Name;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.MessageText = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_few_msg"), ticketName);
			s.HoldCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_count"), haveTicket);
			s.NeedCurrency = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_count"), price);
			s.CurrencyIsTicket = true;
			s.MessageCaution = string.Format(bk.GetMessageByLabel("popup_gacha_lot_ticket_few_caution_04"), ticketName);
			s.IsTicketPeriod = false;
			s.OnClickLegalDescButton = null;
			return s;
		}

		// // RVA: 0x994C30 Offset: 0x994C30 VA: 0x994C30
		private static string MakePopupMessage(string format, string name, int n0, int n1)
		{
			return string.Format(format, name, RichTextUtility.MakeColorTagString(n0.ToString(), SystemTextColor.ImportantColor), RichTextUtility.MakeColorTagString(n1.ToString(), SystemTextColor.ImportantColor));
		}

		// // RVA: 0x993F34 Offset: 0x993F34 VA: 0x993F34
		private static string MakePopupMessage(string format, int n0, int n1)
		{
			return string.Format(format, RichTextUtility.MakeColorTagString(n0.ToString(), SystemTextColor.ImportantColor), RichTextUtility.MakeColorTagString(n1.ToString(), SystemTextColor.ImportantColor));
		}

		// // RVA: 0x99470C Offset: 0x99470C VA: 0x99470C
		private static string MakePopupMessage(string format, int n0)
		{
			return string.Format(format, RichTextUtility.MakeColorTagString(n0.ToString(), SystemTextColor.ImportantColor));
		}

		// // RVA: 0x98AC48 Offset: 0x98AC48 VA: 0x98AC48
		public static void Register(List<MFDJIFIIPJD> items)
		{
			int id = GetDivaIdForCutin();
			bool byPaid = true;
			if(selectedLotType != LotType.PaidVC)
			{
				byPaid = false;
				if(selectedLotType == LotType.Ticket)
					byPaid = true;
			}
			s_directionInfo = new DirectionInfo(items, byPaid, id);
		}

		// // RVA: 0x988F00 Offset: 0x988F00 VA: 0x988F00
		public static void Unregister()
		{
			s_directionInfo = null;
		}

		// // RVA: 0x995CCC Offset: 0x995CCC VA: 0x995CCC
		public static int GetSeIdForMenuLeaving()
		{
			if(selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
			{
				if(!s_directionInfo.CheckContainsStarNum(4))
					return -1;
				return 22;
			}
			return -1;
		}

		// // RVA: 0x995AA0 Offset: 0x995AA0 VA: 0x995AA0
		private static int GetDivaIdForCutin()
		{
			int res = 10;
			if(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0] != null)
				res = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId;
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId > 0)
				res = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
			return res;
		}

		// // RVA: 0x9960DC Offset: 0x9960DC VA: 0x9960DC
		public static bool IsNextFree()
		{
			return netGachaProduct != null && netGachaProduct.JENBPPBNAHP_PlayerNormalLotFreeState != null && netGachaProduct.JENBPPBNAHP_PlayerNormalLotFreeState.LDBPAJKIPKD_IsNextFree;
		}

		// // RVA: 0x9876F8 Offset: 0x9876F8 VA: 0x9876F8
		public static int GetCurrentHaveTicket()
		{
			if(selectCategory != GCAHJLOGMCI.KNMMOMEHDON_GachaType.JGDEHOGIENP_4)
			{
				if(selectCategory == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
				{
					int itemId = netGachaProductData.MJNOAMAFNHA_CostItemId;
					return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId), null);
				}
				if (selectCategory != GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
					return 0;
			}
			return pdm.NBJOCMAJLPK_GetTotalCurrency(netGachaProductData.OMNAPCHLBHF(netGachaCount));
		}

		// // RVA: 0x996178 Offset: 0x996178 VA: 0x996178
		// public static long GetCurrentHaveTicketPeriod() { }

		// // RVA: 0x996394 Offset: 0x996394 VA: 0x996394
		public static void DrawLot(BEPHBEGDFFK.DMBKENKBIJD selectProductInfo, CDOPFBOHDEF onSuccess, DJBHIFLHJLK onFewVC, DJBHIFLHJLK onNetError)
		{
			if(selectCategory != GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
			{
				if((!GameManager.Instance.IsTutorial && selectedLotType == LotType.PaidVC) || selectedLotType == LotType.Ticket)
				{
					//LAB_009964e4
					pdm.DLFDPCDKHOB(netGachaProductData, netGachaCount, onSuccess, onFewVC, onNetError);
					return;
				}
			}
			pdm.JBOAMLIDAKF(netGachaProductData, netGachaCount, onSuccess, onFewVC, onNetError, GameManager.Instance.IsTutorial);
		}

		// // RVA: 0x98DF10 Offset: 0x98DF10 VA: 0x98DF10
		public static void DrawLotRetry(CDOPFBOHDEF onSuccess, DJBHIFLHJLK onFewVC, DJBHIFLHJLK onNetError)
		{
			if(selectCategory != GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
			{
				if(selectedLotType == LotType.PaidVC || selectedLotType == LotType.Ticket)
				{
					pdm.DLFDPCDKHOB(netGachaProductData, netGachaCount, onSuccess, onFewVC, onNetError);
					return;
				}
			}
			pdm.JBOAMLIDAKF(netGachaProductData, netGachaCount, onSuccess, onFewVC, onNetError, false);
		}

		// // RVA: 0x9965FC Offset: 0x9965FC VA: 0x9965FC
		// public static void ClearNetData() { }

		// // RVA: 0x996690 Offset: 0x996690 VA: 0x996690
		public static BadgeConstant.ID GetFooterMenuBadgeId(ref string badgeText)
		{
			HPBDNNACBAK h = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI;
			if (h == null)
				return 0;
			h.OKINLIEHCEC();
			h.ANGMDEPOBEE();
			if (h.PFLJNIANOHE)
				return BadgeConstant.ID.Gacha_Update;
			string s = "";
			KBPDNHOKEKD_ProductId.KNEKLJHNHAK v = h.FJICMLBOJCH(out s);
			if (v == 0)
			{
				if (!h.CPGNMGCIIKI())
					return 0;
				SetupFreeTimezone();
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				Timezone t = GetTimezoneFor(time);
				if ((int)t < 3)
					return (BadgeConstant.ID)(t + (int)BadgeConstant.ID.Gacha_FreeMorning);
				return 0;
			}
			if(string.IsNullOrEmpty(s))
			{
				switch(v)
				{
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.LCLLMJGIMHC_1/*1*/:
						badgeText = MessageManager.Instance.GetMessage("menu", "badge_label_gacha_oneday");
						break;
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.PBEMIDKNPNH_2/*2*/:
						badgeText = MessageManager.Instance.GetMessage("menu", "badge_label_gacha_firsttime");
						break;
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.DKIKNLEDDBK_3/*3*/:
						return 0;
					case KBPDNHOKEKD_ProductId.KNEKLJHNHAK.AAPLMEGMNJA_4/*4*/:
						badgeText = MessageManager.Instance.GetMessage("menu", "badge_label_gacha_thistime");
						break;
				}
			}
			else
			{
				badgeText = s;
			}
			return BadgeConstant.ID.Label;
		}

		// // RVA: 0x9969C8 Offset: 0x9969C8 VA: 0x9969C8
		public static long GetGachaProductOpenTime(LOBDIAABMKG product)
		{
			if(product.KACECFNECON != null && product.KACECFNECON.JOFAGCFNKIO_OpenTime != 0)
			{
				return product.KACECFNECON.JOFAGCFNKIO_OpenTime;
			}
			return product.KJBGCLPMLCG_OpenedAt;
		}

		// // RVA: 0x996A48 Offset: 0x996A48 VA: 0x996A48
		public static long GetGachaProductsLastOpenTime()
		{
			List<LOBDIAABMKG> l = gpm.MHKCPJDNJKI_GatchaProducts;
			if (l.Count < 1)
				return 0;
			long res = 0;
			for(int i = 0; i < l.Count; i++)
			{
				long t = GetGachaProductOpenTime(l[i]);
				if (res < t)
					res = t;
			}
			return res;
		}
	}
}
