using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.SmartFormat;
using XeSys;

public class EKLNMHFCAOI
{
	public enum FKGCBLHOOCL_Category : byte
	{
		HJNNKCMLGFL_None = 0,
		PJDEOPMBGKJ_PaidVC = 1,
		OBHECJMAEIO_GachaTicket = 2,
		ACGHELNGNGK_UnionCredit = 3,
		MHKFDBLMOGF_Scene = 4,
		KBHGPMNGALJ_Costume = 5,
		PFIOMNHDHCO_Valkyrie = 6,
		HLCHKCJLEGK_GrowItem = 7,
		MEDAKGBKIMO_EpisodeItem = 8,
		MNCJMDDAFJB_EmblemItem = 9,
		EMOLGEDEEJP_EventItem = 10,
		CLMIJKACELE_EventTicket = 11,
		JHGPNDLNPFA_DivaItem = 12,
		GIMBFBNKPNO_CompoItem = 13,
		KNHFAHFCCBK_SnsItem = 14,
		DMMIIBCMCFG_EnergyItem = 15,
		IGIFMNJADEC_MvTicket = 16,
		ADCAAALBAIF_Medal = 17,
		IBBDMIFICCN_BonusVC = 18,
		LLFAAOHPMIC_EventGachaTicket = 19,
		DLBHNNOHLMM_PresentItem = 20,
		FMIIHMHKJDI_SpItem = 21,
		NEIIGCODGBA_CostumeItem = 22,
		CIOGEKJNMBB_RareUpItem = 23,
		DLOPEFGOAPD_LimitedItem = 24,
		PJCJEOECLBK_MonthlyPassItem = 25,
		GPMKJNDHDCP_DecoItemBg = 26,
		OKPAJOALDCG_DecoItemObj = 27,
		MCKHJLHKMJD_DecoItemChara = 28,
		ICIMCGOJEMD_StampItemSerif = 29,
		BMMBLLOKNPF_DecoItemSp = 30,
		MABCLBNIOFA_ValkyrieItem = 31,
		LEIMPDPCGNC_Reserve32 = 32,
		OOMMOOIIPJE_DecoItemPoster = 33,
		AEFGOANHNMG_DecoItemPosterSceneBef = 34,
		KKGHNKKGLCO_DecoItemPosterSceneAft = 35,
		CFLFPPDMFAE_RaidItem = 36,
		FEHJOHIMAIH_Reserve37 = 37,
		GGEFMAAOMFH_StampItemChara = 38,
		ICJOEDJECAP_DecoSetItem = 39,
		HEMGMACMGAB_DecoItemVFFigure = 40,
		NNBMEEPOBIO_DecoItemCostumeTorso = 41,
		CKCPFLDGILD_LimitedCompoItem = 42,
		HGDPIAFBCGA_HomeBg = 43,
		OCMIGPEOFEG_GachaLimit = 44,
		AEFCOHJBLPO = 45,
	}

	// public const int IODOECKINMN = 9999;
	// public const int NKMJHIAPPFL = 10000;
	// public const int PAMIHDJAADH = 1000;
	private static string[] KBHKKMMINOD = new string[45] {
		"",
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10090,
		"UC",
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10093,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10094,
		JpStringLiterals.StringLiteral_10095,
		"",
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10089, 
		"DP",
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10095,
		JpStringLiterals.StringLiteral_10089,
		JpStringLiterals.StringLiteral_10096,
		JpStringLiterals.StringLiteral_10090,
		JpStringLiterals.StringLiteral_10089,
		"pt"
	}; // 0x0
	private static string[] ABLJLBEPCHK = new string[45] {
		"None", "PaidVC", "GachaTicket", "UnionCredit", "Scene", "Costume", "Valkyrie", "GrowItem", "EpisodeItem", 
		"EmblemItem", "EventItem", "EventTicket", "DivaItem", "CompoItem", "SnsItem", "EnergyItem", "MvTicket", 
		"Medal", "BonusVC", "EventGachaTicket", "PresentItem", "SpItem", "CostumeItem", "RareUpItem", "LimitedItem", 
		"MonthlyPassItem", "DecoItemBg", "DecoItemObj", "DecoItemChara", "StampItemSerif", "DecoItemSp", "ValkyrieItem", 
		"Reserve32", "DecoItemPoster", "DecoItemPosterSceneBef", "DecoItemPosterSceneAft", "RaidItem", "Reserve37", 
		"StampItemChara", "DecoSetItem", "DecoItemVFFigure", "DecoItemCostumeTorso", "LimitedCompoItem", "HomeBg", 
		"GachaLimit"
	}; // 0x4
	public static string[] PNNKOIFOPMK = new string[45] {
		JpStringLiterals.StringLiteral_10136,
		JpStringLiterals.StringLiteral_10137,
		JpStringLiterals.StringLiteral_10138,
		"UC",
		JpStringLiterals.StringLiteral_10139,
		JpStringLiterals.StringLiteral_10140,
		JpStringLiterals.StringLiteral_10141,
		JpStringLiterals.StringLiteral_10142,
		JpStringLiterals.StringLiteral_10143,
		JpStringLiterals.StringLiteral_10144,
		JpStringLiterals.StringLiteral_10145,
		JpStringLiterals.StringLiteral_10146,
		JpStringLiterals.StringLiteral_10147,
		JpStringLiterals.StringLiteral_10148,
		JpStringLiterals.StringLiteral_10149,
		JpStringLiterals.StringLiteral_10150,
		JpStringLiterals.StringLiteral_10151,
		JpStringLiterals.StringLiteral_10152,
		JpStringLiterals.StringLiteral_10153,
		JpStringLiterals.StringLiteral_10154,
		JpStringLiterals.StringLiteral_10155,
		JpStringLiterals.StringLiteral_10156,
		JpStringLiterals.StringLiteral_10157,
		JpStringLiterals.StringLiteral_10158,
		JpStringLiterals.StringLiteral_10159,
		JpStringLiterals.StringLiteral_10160,
		JpStringLiterals.StringLiteral_10161,
		JpStringLiterals.StringLiteral_10162,
		JpStringLiterals.StringLiteral_10163,
		JpStringLiterals.StringLiteral_10164,
		JpStringLiterals.StringLiteral_10165,
		JpStringLiterals.StringLiteral_10166,
		JpStringLiterals.StringLiteral_10167,
		JpStringLiterals.StringLiteral_10168,
		JpStringLiterals.StringLiteral_10169,
		JpStringLiterals.StringLiteral_10170,
		JpStringLiterals.StringLiteral_10171,
		JpStringLiterals.StringLiteral_10167,
		JpStringLiterals.StringLiteral_10172,
		JpStringLiterals.StringLiteral_10173,
		JpStringLiterals.StringLiteral_10174,
		JpStringLiterals.StringLiteral_10175,
		JpStringLiterals.StringLiteral_10176,
		JpStringLiterals.StringLiteral_10177,
		JpStringLiterals.StringLiteral_10178
	}; // 0x8
	private static string[] BJIECJAOMDJ = new string[45] {
		"vc_0000", "vc_0001", "vc_gt_{0:D4}", "vc_0003", "sn_{0:D4}", "cos_{0:D4}", "vn_{0:D4}", "gn_{0:D4}", 
		"ep_i_nm_{0:D4}", "em_nm_{0:D4}", "evn_{0:D4}", "et_nm_{0:D4}", "diva_{0:D2}", "cmp_nm_{0:D4}", "sns_nm_{0:D4}", 
		"eng_nm_{0:D4}", "mvtk_nm_{0:D4}", "mdl_nm_{0:D4}", "bvc_nm_{0:D4}", "egt_nm_{0:D4}", "itp_nm_{0:D4}", 
		"spitm_nm_{0:D4}", "cs_i_nm_{0:D4}", "rup_nm_{0:D4}", "lmitm_nm_{0:D4}", "vc_0004", "dc_itm_nm_{0:D4}_bg", 
		"dc_itm_nm_{0:D4}_obj", "dc_itm_nm_{0:D4}_chr", "dc_itm_nm_{0:D4}_srf", "dc_itm_nm_{0:D4}_sp", "val_itm_nm_{0:D4}", 
		"dcpt_nm_{0:D4}", "dc_itm_nm_{0:D4}_pst", "sn_{0:D4}", "sn_{0:D4}", "rd_i_nm_{0:D4}", "rd_mdl_nm_{0:D4}", 
		"dc_stmp_nm_{0:D4}", "dc_set_nm_{0:D4}", "vff_nm_{0:D4}", "trs_nm_{0:D4}", "sk_nm_{0:D4}", "hm_bg_nm_{0:D4}", 
		"gc_lm_nm_{0:D4}"
	}; // 0xC
	private static string[] IFDGOKENMLG = new string[45] {
		"vc_0000", "vc_dsc_0001", "vc_gt_dsc_{0:D4}", "vc_dsc_0003", "sn_dsc_{0:D4}", "cos_{0:D4}", "vn_{0:D4}", 
		"gn_dsc_{0:D4}", "ep_i_dsc_{0:D4}", "em_dsc_{0:D4}", "evdsc_{0:D4}", "et_dsc_{0:D4}", "diva_{0:D2}", 
		"cmp_dsc_{0:D4}", "sns_nm_{0:D4}", "eng_dsc_{0:D4}", "mvtk_dsc_{0:D4}", "mdl_dsc_{0:D4}", "bvc_dsc_{0:D4}", 
		"egt_dsc_{0:D4}", "itp_dsc_{0:D4}", "spitm_dsc_{0:D4}", "cs_i_dsc_{0:D4}", "rup_dsc_{0:D4}", "lmitm_dsc_{0:D4}", 
		"vc_dsc_0004", "vc_dsc_0005", "dc_itm_dsc_{0:D4}_obj", "vc_dsc_0006", "vc_dsc_0007", "dc_itm_dsc_{0:D4}_sp", 
		"val_itm_dsc_{0:D4}", "dcpt_dsc_{0:D4}", "dc_itm_dsc_{0:D4}_pst", "sn_dsc_{0:D4}", "sn_dsc_{0:D4}", "rd_i_dsc_{0:D4}", 
		"rd_mdl_dsc_{0:D4}", "vc_dsc_0008", "dc_set_dsc_{0:D4}", "vff_dsc_{0:D4}", "trs_dsc_{0:D4}", "sk_dsc_{0:D4}", 
		"hm_bg_nm_{0:D4}", "gc_lm_dsc_{0:D4}"
	}; // 0x10
	private static string[] MMKIEBOGMJM = new string[45] {
		"", "", "vc_gt_uni_{0:D4}", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "bvc_qt_{0:D4}", "", 
		"itp_qt_{0:D4}", "spitm_qt_{0:D4}", "", "", "lmitm_qt_{0:D4}", "vc_uni_0004", "vc_uni_0005", "dc_itm_qt_{0:D4}_obj", 
		"vc_uni_0006", "vc_uni_0007", "dc_itm_qt_{0:D4}_sp", "", "", "", "", "", "", "", "vc_uni_0008", "", "vc_uni_0009", 
		"vc_uni_0010", "sk_qt_{0:D4}", "", ""
	}; // 0x14
	public static bool PPMJLBEOIPF = false; // 0x18

	// // RVA: 0x12F56C4 Offset: 0x12F56C4 VA: 0x12F56C4
	// public static string OBIEJBLHHPD(EKLNMHFCAOI.FKGCBLHOOCL INDDJNMPONH) { }

	// // RVA: 0x12F5788 Offset: 0x12F5788 VA: 0x12F5788
	public static FKGCBLHOOCL_Category BKHFLDMOGBD_GetItemCategory(int KIJAPOFAGPN)
	{
		return (FKGCBLHOOCL_Category)(KIJAPOFAGPN / 10000);
	}

	// // RVA: 0x12F57A4 Offset: 0x12F57A4 VA: 0x12F57A4
	public static int DEACAHNLMNI_getItemId(int KIJAPOFAGPN)
	{
		return KIJAPOFAGPN % 10000;
	}

	// // RVA: 0x12F57C4 Offset: 0x12F57C4 VA: 0x12F57C4
	public static int GJEEGMCBGGM_GetItemFullId(FKGCBLHOOCL_Category INDDJNMPONH_Category, int PPFNGGCBJKC_ItemId)
	{
		return (int)INDDJNMPONH_Category * 10000 + PPFNGGCBJKC_ItemId;
	}

	// // RVA: 0x12F57D0 Offset: 0x12F57D0 VA: 0x12F57D0
	// public static int BGIBJJAFOBC(EKLNMHFCAOI.FKGCBLHOOCL INDDJNMPONH, int DKMLEDJJFOI) { }

	// // RVA: 0x12F57F8 Offset: 0x12F57F8 VA: 0x12F57F8
	public static int ADGMGNKCIGA(int DKMLEDJJFOI)
	{
		return DKMLEDJJFOI % 1000;
	}

	// // RVA: 0x12F5818 Offset: 0x12F5818 VA: 0x12F5818
	public static int LKBIIPBKNGJ_GetItemFileStatus(int KIJAPOFAGPN)
	{
		FKGCBLHOOCL_Category itemCat = (FKGCBLHOOCL_Category)((KIJAPOFAGPN / 10000) & 0xff);
		int itemId = KIJAPOFAGPN % 10000;
		switch(itemCat)
		{
			case FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC:
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
			case FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
			case FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
			case FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem:
			case FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem:
			case FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
			case FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
			case FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
			case FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC:
			case FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
			case FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
			case FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
			case FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
			case FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem:
			case FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
			case FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				return 1;
			case FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume:
				if(itemId > 0)
				{
					if(itemId <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes.Count)
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[itemId - 1].PPEGAKEIEGM_Enabled == 2)
						{
							return 1;
						}
						return 2;
					}
				}
				break;
			case FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie:
				if(itemId > 0)
				{
					if(itemId <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList.Count)
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[itemId - 1].PPEGAKEIEGM_Enabled == 2)
						{
							return 1;
						}
						return 2;
					}
				}
				break;
		}
		return 2;
	}

	// // RVA: 0x12F5BF8 Offset: 0x12F5BF8 VA: 0x12F5BF8
	// public static string ANIEBBILFKN(int KIJAPOFAGPN) { }

	// // RVA: 0x12F5CE8 Offset: 0x12F5CE8 VA: 0x12F5CE8
	public static string FKMCHHDOAAB(int KIJAPOFAGPN, bool useJp = false)
	{
		return FKMCHHDOAAB((FKGCBLHOOCL_Category)(KIJAPOFAGPN / 10000), KIJAPOFAGPN % 10000, useJp:useJp);
	}

	// // RVA: 0x12F5D84 Offset: 0x12F5D84 VA: 0x12F5D84
	public static string FKMCHHDOAAB(FKGCBLHOOCL_Category INDDJNMPONH, int JBGEEPFKIGG, bool useJp = false)
	{
		if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
		{
			return string.Format(BJIECJAOMDJ[(int)INDDJNMPONH], JBGEEPFKIGG) + (useJp ? "_jp" : "");
		}
		else
		{
			return string.Format(BJIECJAOMDJ[(int)INDDJNMPONH], JBGEEPFKIGG);
		}
	}

	// // RVA: 0x12F5E80 Offset: 0x12F5E80 VA: 0x12F5E80
	public static string GPMNHMLGDHO(FKGCBLHOOCL_Category INDDJNMPONH, int JBGEEPFKIGG)
	{
		return string.Format(IFDGOKENMLG[(int)INDDJNMPONH], JBGEEPFKIGG);
	}

	// // RVA: 0x12F5F7C Offset: 0x12F5F7C VA: 0x12F5F7C
	public static string GFFEIIALFBD(FKGCBLHOOCL_Category INDDJNMPONH, int JBGEEPFKIGG)
	{
		return string.Format(MMKIEBOGMJM[(int)INDDJNMPONH], JBGEEPFKIGG);
	}

	// // RVA: 0x12F6078 Offset: 0x12F6078 VA: 0x12F6078
	public static string INCKKODFJAP_GetItemName(int KIJAPOFAGPN, bool useJp = false)
	{
		return INCKKODFJAP_GetItemName((FKGCBLHOOCL_Category)(KIJAPOFAGPN / 10000), KIJAPOFAGPN % 10000, useJp:useJp);
	}

	// // RVA: 0x12F6114 Offset: 0x12F6114 VA: 0x12F6114
	public static string INCKKODFJAP_GetItemName(FKGCBLHOOCL_Category INDDJNMPONH, int JBGEEPFKIGG, bool useJp = false)
	{
		int id = JBGEEPFKIGG;
		if (INDDJNMPONH == FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit)
		{
			BIHCALIAJII_GachaLimit.AICPHCIFEJL g = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OINLLHOMEAK_GachaLimit.CDENCMNHNGA.Find((BIHCALIAJII_GachaLimit.AICPHCIFEJL GHPLINIACBB) =>
			{
				//0x1303AD8
				return GHPLINIACBB.FEFDGBPFKBJ_GId % 10000 == JBGEEPFKIGG;
			});
			if (g != null)
				id = g.PPFNGGCBJKC_Id;
		}
		string str = MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(FKMCHHDOAAB(INDDJNMPONH, id, useJp:useJp));
		if(RuntimeSettings.CurrentSettings.DisplayIdInName)
			str = "["+JBGEEPFKIGG+"] "+str;
		if (INDDJNMPONH != FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
			return str;
		return str.Replace("\n", "");
	}

	// // RVA: 0x12F63E8 Offset: 0x12F63E8 VA: 0x12F63E8
	public static string ILKGBGOCLAO_GetItemDesc(FKGCBLHOOCL_Category INDDJNMPONH, int JBGEEPFKIGG)
	{
		if(INDDJNMPONH < FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
		{
			if(INDDJNMPONH == FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem)
			{
				return string.Format(MessageManager.Instance.GetMessage("menu", "sns_item_description"), 
					MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(string.Format("rn_{0:D4}", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_Talks[JBGEEPFKIGG - 1].MALFHCHNEFN_RoomId)),
					MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem, JBGEEPFKIGG)));
			}
			if(INDDJNMPONH == FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
			{
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.LPHKLEJPKAN(MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, JBGEEPFKIGG)), JBGEEPFKIGG);
			}
			if(INDDJNMPONH == FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem)
			{
				return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem, JBGEEPFKIGG)) + "\n" + string.Format(MessageManager.Instance.GetMessage("menu", "present_item_rank_postfix"), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("intimacy_player_level", 8));
			}
			return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(INDDJNMPONH, JBGEEPFKIGG));
		}
		else
		{
			if(INDDJNMPONH < FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
			{
				if(INDDJNMPONH == FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
				{
					return string.Format(MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif, JBGEEPFKIGG)), NCPPAHHCCAO.EFNHFKLKNHJ(JBGEEPFKIGG));
				}
				if(INDDJNMPONH != FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef)
				{
					return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(INDDJNMPONH, JBGEEPFKIGG));
				}
				string str = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_poster_scene_before", "");
				if (str != "")
					return str;
				return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef, JBGEEPFKIGG));
			}
			else if(INDDJNMPONH == FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
			{
				string str = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_poster_scene_after", "");
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.OEEJKKFOBKD(JBGEEPFKIGG))
				{
					string str2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_poster_scene_single6", "");
					if (str2 != "")
						str = str2;
				}
				if (str != "")
					return str;
				return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft, JBGEEPFKIGG));
			}
			else
			{
				if(INDDJNMPONH != FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit)
				{
					return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(INDDJNMPONH, JBGEEPFKIGG));
				}
				BIHCALIAJII_GachaLimit.AICPHCIFEJL g = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OINLLHOMEAK_GachaLimit.CDENCMNHNGA.Find((BIHCALIAJII_GachaLimit.AICPHCIFEJL GHPLINIACBB) =>
				{
					//0x1303B38
					return GHPLINIACBB.FEFDGBPFKBJ_GId % 10000 == JBGEEPFKIGG;
				});
				if (g != null)
					JBGEEPFKIGG = g.PPFNGGCBJKC_Id;
				return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit, JBGEEPFKIGG));
			}
		}
	}

	// // RVA: 0x12F734C Offset: 0x12F734C VA: 0x12F734C
	public static int FABCKNDLPDH_GetItemRarity(int KIJAPOFAGPN)
	{
		return FABCKNDLPDH_GetItemRarity((FKGCBLHOOCL_Category)(KIJAPOFAGPN/ 10000), KIJAPOFAGPN % 10000);
	}

	// // RVA: 0x12F73E8 Offset: 0x12F73E8 VA: 0x12F73E8
	public static int APDHLDGBENB(int KIJAPOFAGPN)
	{
		int a = FABCKNDLPDH_GetItemRarity(KIJAPOFAGPN);
		if (BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN) == FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
		{
			return a + (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[KIJAPOFAGPN % 10000 - 1].FBJDHLGODPP_Sngl ? 1 : 0);
		}
		return a;
	}

	// // RVA: 0x12EC60C Offset: 0x12EC60C VA: 0x12EC60C
	public static int FABCKNDLPDH_GetItemRarity(FKGCBLHOOCL_Category INDDJNMPONH, int PPFNGGCBJKC)
	{
		int res = 1;
		switch(INDDJNMPONH)
		{
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
				{
					if(PPFNGGCBJKC != 0)
						PPFNGGCBJKC--;
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NMJEDFNPIPL_UcItem.CDENCMNHNGA[PPFNGGCBJKC].EKLIPGELKCL_Rar;
				}
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[PPFNGGCBJKC - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NKDGLGCAPEI_GrowItem.CDENCMNHNGA_GrowItemList[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGGMILDEEF_EpiItem.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_EmblemList[PPFNGGCBJKC - 1].EKLIPGELKCL_Rar;
			case FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL_Rar;
			case FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ALFKMKICDPP_Compo.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGKEEAFKHP_MvTicket.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LPFEHNJEJFB_PresentItem.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OOEPHOEFBNL_SpItem.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.EEOADCECNOM_GetItemById(PPFNGGCBJKC).EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KKIMFMKOHFH_RareUpItem.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IHPFCIJKFIC_LimitedItem.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GJLHEJPHEDA_ItemsBg[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KHCACDIKJLG_ItemsChara[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FBGKBGNIHGC_ValItem.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL_Rar;
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.COLIEKINOPB_ItemsPoster[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[PPFNGGCBJKC - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
				int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[PPFNGGCBJKC - 1].EKLIPGELKCL_Rarity;
				if(a > 3 && a < 6)
					a++;
				return a;
			case FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ONOJBMDKBLE_EventRaidItem.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL_Rar;
			case FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.FHBIIONKIDI_Stamps[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA[PPFNGGCBJKC - 1].EKLIPGELKCL;
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[PPFNGGCBJKC - 1].EKLIPGELKCL;
		}
		return 1;
	}

	// // RVA: 0x12F75BC Offset: 0x12F75BC VA: 0x12F75BC
	public static string NDBLEADIDLA(FKGCBLHOOCL_Category INDDJNMPONH, int JBGEEPFKIGG = 0, int cnt = 0)
	{
		if(JBGEEPFKIGG > 0)
		{
			string str = GFFEIIALFBD(INDDJNMPONH, JBGEEPFKIGG);
			if(str != "")
			{
				str = Smart.Format(MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(str), cnt);
				if(str != "")
					return str;
			}
		}
		return Smart.Format(KBHKKMMINOD[(int)INDDJNMPONH], cnt);
	}

	// // RVA: 0x12F77D0 Offset: 0x12F77D0 VA: 0x12F77D0
	public static bool KGANFNCODNG_IsValidCategory(FKGCBLHOOCL_Category INDDJNMPONH)
	{
		switch(INDDJNMPONH)
		{
			case FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC:
			case FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket:
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
			case FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume:
			case FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie:
			case FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
			case FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
			case FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
			case FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem:
			case FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket:
			case FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem:
			case FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
			case FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
			case FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
			case FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC:
			case FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
			case FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
			case FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
			case FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
			case FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem:
			case FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
			case FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
			case FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
			case FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
			case FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
			case FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
			case FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
			case FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
			case FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
			case FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara:
			case FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
			case FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
			case FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
			case FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg:
			case FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit:
				return true;
			default:
				return false;
		}
	}

	// // RVA: 0x12F78AC Offset: 0x12F78AC VA: 0x12F78AC
	public static int DLNFNHMPGLI_GetNumClamped(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, FKGCBLHOOCL_Category INDDJNMPONH, int NANNGLGOFKH, IKDICBBFBMI_EventBase JMFICAICKBC)
	{
		return Mathf.Clamp(ALHCGDMEMID_GetNumItems(LKMHPJKIFDN, LDEGEHAEALK, INDDJNMPONH, NANNGLGOFKH, JMFICAICKBC), 0, EEIFENNHAHF_GetMax(LKMHPJKIFDN, LDEGEHAEALK, INDDJNMPONH, NANNGLGOFKH, JMFICAICKBC));
	}

	// // RVA: 0x12F79B0 Offset: 0x12F79B0 VA: 0x12F79B0
	public static int ALHCGDMEMID_GetNumItems(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, FKGCBLHOOCL_Category INDDJNMPONH, int NANNGLGOFKH, IKDICBBFBMI_EventBase JMFICAICKBC)
	{
		switch(INDDJNMPONH)
		{
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
				return LDEGEHAEALK.KCCLEHLLOFG_Common.NFHLDFJIBKI_HaveUc;
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
				if(LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[NANNGLGOFKH - 1].BEBJKJKBOGH_Date != 0)
				{
					return LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[NANNGLGOFKH - 1].JPIPENJGGDD_Mlt + (LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[NANNGLGOFKH - 1].FBJDHLGODPP_Sngl ? 0 : 1);
				}
				break;
			case FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume:
				return LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[NANNGLGOFKH - 1].CGKAEMGLHNK_Possessed() ? 1 : 0;
			case FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie:
				return LDEGEHAEALK.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[NANNGLGOFKH - 1].FJODMPGPDDD ? 1 : 0;
			case FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
				return LDEGEHAEALK.KCCLEHLLOFG_Common.KBMDMEEMGLK_GrowItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
				return LDEGEHAEALK.KCCLEHLLOFG_Common.GJODJNIHKKF_EpiItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
				if(LDEGEHAEALK.OFAJDLJBMEM_Emblem.MDKOHOCONKE[NANNGLGOFKH - 1].BEBJKJKBOGH_Date != 0)
				{
					return LDEGEHAEALK.OFAJDLJBMEM_Emblem.MDKOHOCONKE[NANNGLGOFKH - 1].FHCAFLCLGAA_Cnt;
				}
				break;
			case FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket:
				MANPIONIGNO_EventGoDiva evGoDiva = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as MANPIONIGNO_EventGoDiva;
				if(evGoDiva != null)
				{
					return evGoDiva.AELBIEDNPGB_GetTicketCount(LDEGEHAEALK);
				}
				break;
			case FKGCBLHOOCL_Category.JHGPNDLNPFA_DivaItem:
				return LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[NANNGLGOFKH - 1].CPGFPEDMDEH_Have;
			case FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
				return LDEGEHAEALK.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
				return LDEGEHAEALK.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket;
			case FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
				return LDEGEHAEALK.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC:
				return CIOECGOMILE.HHCJCDFCLOB.NOJDLFKKMDD_GetCurrencyTotal(NANNGLGOFKH);
			case FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
				if(LDEGEHAEALK.MMAIJOCPJHP_EventBoxGacha != null)
				{
					TodoLogger.LogError(TodoLogger.EventBoxGacha_8, "ALHCGDMEMID_GetNumItems Event");
				}
				break;
			case FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
				return LDEGEHAEALK.KCCLEHLLOFG_Common.DHJFHILPKLB_IntimacyPresent[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
				if(NANNGLGOFKH == 13)
				{
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					return LDEGEHAEALK.GJCOJBDOOJG_LimitedCompoItem.HPPKOGKNKMH(1, time);
				}
				return LDEGEHAEALK.KCCLEHLLOFG_Common.BBFIGEOBOMB_SpItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
				return LDEGEHAEALK.KCCLEHLLOFG_Common.EFBKCNNFIPJ(NANNGLGOFKH).BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
				{
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					return LDEGEHAEALK.DPNKPPBEAGJ_RareUpItem.LDLCGGACHGA(time);
				}
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem:
				{
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					return LDEGEHAEALK.AFHFIPLOKMN_LimitedItem.HPPKOGKNKMH(NANNGLGOFKH, time);
				}
			case FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
				return LDEGEHAEALK.HMMNDKHKEBC_MonthlyPass.JAMCDEDFHHK_HotenCnt;
			case FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
				return LDEGEHAEALK.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				return LDEGEHAEALK.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				return LDEGEHAEALK.OMMNKDEODJP_DecoItem.PEBDEIKBCCM_Chars[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
				return LDEGEHAEALK.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
				return LDEGEHAEALK.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
				return LDEGEHAEALK.KCCLEHLLOFG_Common.MJAIFKFOPPI_ValItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				return LDEGEHAEALK.OMMNKDEODJP_DecoItem.PFNNIMBMKDL_Posters[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
				return LDEGEHAEALK.PNLOINMCCKH_Scene.HOLEDOLMJCB(NANNGLGOFKH, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, 0);
			case FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
				return LDEGEHAEALK.PNLOINMCCKH_Scene.HOLEDOLMJCB(NANNGLGOFKH, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, 1);
			case FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
				if (JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) != null)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "ALHCGDMEMID_GetNumItems Event");
				}
				break;
			case FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara:
				return LDEGEHAEALK.FJPOELGFPBP_DecoStamp.FHBIIONKIDI_Stamps[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				return LDEGEHAEALK.OMMNKDEODJP_DecoItem.NOAEDPJGBJK_Sets[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt;
			case FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
				return LDEGEHAEALK.JJFFBDLIOCF_Valkyrie.NBFPEPBFEHI(NANNGLGOFKH, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie);
			case FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
				return LDEGEHAEALK.BEKHNNCGIEL_Costume.LMLGEDEJCJO(NANNGLGOFKH, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, true);
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				{
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					return LDEGEHAEALK.GJCOJBDOOJG_LimitedCompoItem.HPPKOGKNKMH(NANNGLGOFKH, time);
				}
			case FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit:
				return LDEGEHAEALK.APFILEMHEPG_GachaLimit.CFLDNJANAPI(NANNGLGOFKH + 40000);
		}
		return 0;
	}

	// // RVA: 0x12F92F4 Offset: 0x12F92F4 VA: 0x12F92F4
	public static void DPHGFMEPOCA_SetNumItems(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, EKLNMHFCAOI.FKGCBLHOOCL_Category INDDJNMPONH, int NANNGLGOFKH, int HMFFHLPNMPH, IKDICBBFBMI_EventBase JMFICAICKBC)
	{
		if (HMFFHLPNMPH < 1)
			HMFFHLPNMPH = 0;

		int a = AFEONHCADEL_GetMaxAllowed(LKMHPJKIFDN, LDEGEHAEALK, INDDJNMPONH, NANNGLGOFKH, JMFICAICKBC);
		if (a < HMFFHLPNMPH)
			HMFFHLPNMPH = a;

		switch (INDDJNMPONH)
		{
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
				LDEGEHAEALK.KCCLEHLLOFG_Common.NFHLDFJIBKI_HaveUc = HMFFHLPNMPH;
				break;
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
				if (HMFFHLPNMPH == 0)
				{
					LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = 0;
					LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[NANNGLGOFKH - 1].JPIPENJGGDD_Mlt = 0;
					LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[NANNGLGOFKH - 1].IELENGDJPHF_Ulk = 0;
				}
				else
				{
					if (LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[NANNGLGOFKH - 1].BEBJKJKBOGH_Date == 0)
					{
						LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					}

					MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[NANNGLGOFKH - 1];
					LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[NANNGLGOFKH - 1].JPIPENJGGDD_Mlt = HMFFHLPNMPH - (dbScene.FBJDHLGODPP_Sngl ? 0 : 1);
					if(dbScene.KELFCMEOPPM_Ep != 0 && dbScene.PPEGAKEIEGM_En == 2)
					{
						if(LDEGEHAEALK.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[dbScene.KELFCMEOPPM_Ep - 1].BEBJKJKBOGH_Date == 0)
						{
							LDEGEHAEALK.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[dbScene.KELFCMEOPPM_Ep - 1].BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
							LDEGEHAEALK.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[dbScene.KELFCMEOPPM_Ep - 1].LHMOAJAIJCO_IsNew = true;
						}
					}
				}
				break;
			case FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume:
				if(NANNGLGOFKH == 0)
				{
					LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = 0;
				}
				else
				{
					LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				}
				break;
			case FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie:
				if (NANNGLGOFKH == 0)
					LDEGEHAEALK.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = 0;
				else
					LDEGEHAEALK.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				break;
			case FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
				LDEGEHAEALK.KCCLEHLLOFG_Common.KBMDMEEMGLK_GrowItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt = HMFFHLPNMPH;
				break;
			case FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
				LDEGEHAEALK.KCCLEHLLOFG_Common.GJODJNIHKKF_EpiItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt = HMFFHLPNMPH;
				break;
			case FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
				if (NANNGLGOFKH == 1)
					HMFFHLPNMPH = NANNGLGOFKH;
				if (HMFFHLPNMPH == 0)
				{
					LDEGEHAEALK.OFAJDLJBMEM_Emblem.MDKOHOCONKE[NANNGLGOFKH - 1].FHCAFLCLGAA_Cnt = 0;
				}
				else
				{
					if(LDEGEHAEALK.OFAJDLJBMEM_Emblem.MDKOHOCONKE[NANNGLGOFKH - 1].BEBJKJKBOGH_Date == 0)
					{
						LDEGEHAEALK.OFAJDLJBMEM_Emblem.MDKOHOCONKE[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					}
					LDEGEHAEALK.OFAJDLJBMEM_Emblem.MDKOHOCONKE[NANNGLGOFKH - 1].FHCAFLCLGAA_Cnt = HMFFHLPNMPH - 1;
				}
				break;
			case FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket:
				MANPIONIGNO_EventGoDiva ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as MANPIONIGNO_EventGoDiva;
				if (ev != null)
				{
					ev.HPENJEOAMBK_SetTicket((int)INDDJNMPONH * 10000 + NANNGLGOFKH, HMFFHLPNMPH, LDEGEHAEALK);
				}
				break;
			case FKGCBLHOOCL_Category.JHGPNDLNPFA_DivaItem:
				LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[NANNGLGOFKH - 1].CPGFPEDMDEH_Have = HMFFHLPNMPH != 0 ? 1 : 0;
				break;
			case FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
				if(HMFFHLPNMPH == 0)
				{
					LDEGEHAEALK.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt = 0;
					LDEGEHAEALK.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = 0;
				}
				else
				{
					LDEGEHAEALK.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt = HMFFHLPNMPH;
					LDEGEHAEALK.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				}
				break;
			case FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
				LDEGEHAEALK.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket = HMFFHLPNMPH;
				break;
			case FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
				if (HMFFHLPNMPH == 0)
				{
					LDEGEHAEALK.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt = 0;
					LDEGEHAEALK.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = 0;
				}
				else
				{
					LDEGEHAEALK.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt = HMFFHLPNMPH;
					LDEGEHAEALK.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[NANNGLGOFKH - 1].BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(); ;
				}
				break;
			//case FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC:
			//	return CIOECGOMILE.HHCJCDFCLOB.NOJDLFKKMDD(NANNGLGOFKH);
			case FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
				if (LDEGEHAEALK.MMAIJOCPJHP_EventBoxGacha != null)
				{
					TodoLogger.LogError(TodoLogger.EventBoxGacha_8, "ALHCGDMEMID_SetNumItems Event");
				}
				break;
			case FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
				LDEGEHAEALK.KCCLEHLLOFG_Common.DHJFHILPKLB_IntimacyPresent[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt = HMFFHLPNMPH;
				break;
			case FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
				if (NANNGLGOFKH == 13)
				{
					CBHPGKACDAN(LKMHPJKIFDN, LDEGEHAEALK, 0, 1, HMFFHLPNMPH, JMFICAICKBC);
				}
				else
				{
					LDEGEHAEALK.KCCLEHLLOFG_Common.BBFIGEOBOMB_SpItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt = HMFFHLPNMPH;
				}
				break;
			case FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
				LDEGEHAEALK.KCCLEHLLOFG_Common.EFBKCNNFIPJ(NANNGLGOFKH).BFINGCJHOHI_Cnt = HMFFHLPNMPH;
				break;
			case FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
				{
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					int v = LDEGEHAEALK.DPNKPPBEAGJ_RareUpItem.LDLCGGACHGA(time);
					int v2 = HMFFHLPNMPH - v;
					if (v2 < 0)
						v2 = -v2;
					if(v < HMFFHLPNMPH)
					{
						for(int i = 0; i < v2; i++)
						{
							LDEGEHAEALK.DPNKPPBEAGJ_RareUpItem.APIEKGBMBPA(time, false);
						}
					}
					else if(HMFFHLPNMPH < v)
					{
						List<int> l = LDEGEHAEALK.DPNKPPBEAGJ_RareUpItem.ALGMLEPBEGA(time);
						if (l.Count > 0)
						{
							if(l.Count < v2)
							{
								v2 = l.Count;
							}
							for(int i = 0; i < v2; i++)
							{
								LDEGEHAEALK.DPNKPPBEAGJ_RareUpItem.GKFMCICFEFI(l[i], time);
							}
						}
					}
				}
				break;
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem:
				{
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					int v = LDEGEHAEALK.AFHFIPLOKMN_LimitedItem.HPPKOGKNKMH(NANNGLGOFKH, time);
					int v2 = HMFFHLPNMPH - v;
					if (v2 < 0)
						v2 = -v2;
					if(v < HMFFHLPNMPH)
					{
						for(int i = 0; i < v2; i++)
						{
							LDEGEHAEALK.AFHFIPLOKMN_LimitedItem.CPIICACGNBH(NANNGLGOFKH, time, false);
						}
					}
					else if(HMFFHLPNMPH < v)
					{
						List<int> l = LDEGEHAEALK.AFHFIPLOKMN_LimitedItem.BHNDPHCBCKN(NANNGLGOFKH, time);
						if(l.Count > 0)
						{
							if (l.Count < v2)
								v2 = l.Count;
							for(int i = 0; i < v2; i++)
							{
								LDEGEHAEALK.AFHFIPLOKMN_LimitedItem.LLOAMEOCJEO(NANNGLGOFKH, l[i], time);
							}
						}
					}
				}
				break;
			case FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
				LDEGEHAEALK.HMMNDKHKEBC_MonthlyPass.JAMCDEDFHHK_HotenCnt = HMFFHLPNMPH;
				break;
			case FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
				LDEGEHAEALK.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs[NANNGLGOFKH - 1].PPJAGFPBFHJ(HMFFHLPNMPH);
				break;
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				LDEGEHAEALK.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs[NANNGLGOFKH - 1].PPJAGFPBFHJ(HMFFHLPNMPH);
				break;
			case FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				LDEGEHAEALK.OMMNKDEODJP_DecoItem.PEBDEIKBCCM_Chars[NANNGLGOFKH - 1].PPJAGFPBFHJ(HMFFHLPNMPH);
				break;
			case FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
				LDEGEHAEALK.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif[NANNGLGOFKH - 1].PPJAGFPBFHJ(HMFFHLPNMPH);
				break;
			case FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
				LDEGEHAEALK.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[NANNGLGOFKH - 1].PPJAGFPBFHJ(HMFFHLPNMPH);
				break;
			case FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
				LDEGEHAEALK.KCCLEHLLOFG_Common.MJAIFKFOPPI_ValItem[NANNGLGOFKH - 1].BFINGCJHOHI_Cnt = HMFFHLPNMPH;
				break;
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				LDEGEHAEALK.OMMNKDEODJP_DecoItem.PFNNIMBMKDL_Posters[NANNGLGOFKH - 1].PPJAGFPBFHJ(HMFFHLPNMPH);
				break;
			//case FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
			//	return LDEGEHAEALK.PNLOINMCCKH_Scene.HOLEDOLMJCB(NANNGLGOFKH, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, 0);
			//case FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
			//	return LDEGEHAEALK.PNLOINMCCKH_Scene.HOLEDOLMJCB(NANNGLGOFKH, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, 1);
			//case FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
			//	if (JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD.BCKENOKGLIJ/*9*/) != null)
			//	{
			//		TodoLogger.Log(0, "ALHCGDMEMID_GetNumItems Event");
			//	}
			//	break;
			case FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara:
				LDEGEHAEALK.FJPOELGFPBP_DecoStamp.FHBIIONKIDI_Stamps[NANNGLGOFKH - 1].PPJAGFPBFHJ(HMFFHLPNMPH);
				break;
			case FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				LDEGEHAEALK.OMMNKDEODJP_DecoItem.NOAEDPJGBJK_Sets[NANNGLGOFKH - 1].PPJAGFPBFHJ(HMFFHLPNMPH);
				break;
			//case FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
			//	return LDEGEHAEALK.JJFFBDLIOCF_Valkyrie.NBFPEPBFEHI(NANNGLGOFKH, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie);
			//case FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
			//	return LDEGEHAEALK.BEKHNNCGIEL_Costume.LMLGEDEJCJO(NANNGLGOFKH, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, true);
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				CBHPGKACDAN(LKMHPJKIFDN, LDEGEHAEALK, 0, NANNGLGOFKH, HMFFHLPNMPH, JMFICAICKBC);
				break;
			case FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit:
				LDEGEHAEALK.APFILEMHEPG_GachaLimit.KHBNLBNPGPK(NANNGLGOFKH + 40000, HMFFHLPNMPH);
				break;
		}
	}

	// // RVA: 0x12FBFF0 Offset: 0x12FBFF0 VA: 0x12FBFF0
	public static void CBHPGKACDAN(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, EKLNMHFCAOI.FKGCBLHOOCL_Category INDDJNMPONH, int NANNGLGOFKH, int HMFFHLPNMPH, IKDICBBFBMI_EventBase JMFICAICKBC)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		int v = LDEGEHAEALK.GJCOJBDOOJG_LimitedCompoItem.HPPKOGKNKMH(NANNGLGOFKH, time);
		int v2 = HMFFHLPNMPH - v;
		if (v2 < 0)
			v2 = -v2;
		if(v < HMFFHLPNMPH)
		{
			for(int i = 0; i < v2; i++)
			{
				LDEGEHAEALK.GJCOJBDOOJG_LimitedCompoItem.CPIICACGNBH(NANNGLGOFKH, time, false);
			}
		}
		else if(HMFFHLPNMPH < v)
		{
			List<int> l = LDEGEHAEALK.GJCOJBDOOJG_LimitedCompoItem.BHNDPHCBCKN(NANNGLGOFKH, time);
			if(l.Count > 0)
			{
				if (l.Count < v2)
					v2 = l.Count;
				for(int i = 0; i < v2; i++)
				{
					LDEGEHAEALK.GJCOJBDOOJG_LimitedCompoItem.LLOAMEOCJEO(NANNGLGOFKH, l[i], time);
				}
			}
		}
	}

	// // RVA: 0x12FC384 Offset: 0x12FC384 VA: 0x12FC384
	// public static void BAABHKHJBBH(OKGLGHCBCJP LKMHPJKIFDN, BBHNACPENDM LDEGEHAEALK, EKLNMHFCAOI.FKGCBLHOOCL INDDJNMPONH, int NANNGLGOFKH, IKDICBBFBMI JMFICAICKBC) { }

	// // RVA: 0x12F91E0 Offset: 0x12F91E0 VA: 0x12F91E0
	public static int EEIFENNHAHF_GetMax(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, EKLNMHFCAOI.FKGCBLHOOCL_Category INDDJNMPONH, int NANNGLGOFKH, IKDICBBFBMI_EventBase JMFICAICKBC)
	{
		int v = AFEONHCADEL_GetMaxAllowed(LKMHPJKIFDN, LDEGEHAEALK, INDDJNMPONH, NANNGLGOFKH, JMFICAICKBC);
		if (INDDJNMPONH != FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem && INDDJNMPONH != FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
			return v;
		return Mathf.Clamp(v, 0, 99999);
	}

	// // RVA: 0x12FB71C Offset: 0x12FB71C VA: 0x12FB71C
	public static int AFEONHCADEL_GetMaxAllowed(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, EKLNMHFCAOI.FKGCBLHOOCL_Category INDDJNMPONH, int NANNGLGOFKH, IKDICBBFBMI_EventBase JMFICAICKBC)
	{
		int a = 99999999;
		switch(INDDJNMPONH)
		{
			case FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket:
				a = 99;
				break;
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
			case FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
				break;
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[NANNGLGOFKH - 1];
					int v = LKMHPJKIFDN.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed);
					int v2 = 1;
					if (PPMJLBEOIPF)
						v2 = 10000;
					return v + v2 - (dbScene.FBJDHLGODPP_Sngl ? 1 : 0);
				}
			case FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume:
			case FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie:
			case FKGCBLHOOCL_Category.JHGPNDLNPFA_DivaItem:
			case FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
			case FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
			case FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
			case FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
			case FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara:
			case FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
			case FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
				a = 1;
				break;
			case FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
			case FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
				a = 99999;
				break;
			case FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
			case FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
			case FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
			case FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
				a = 9999;
				break;
			case FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
				a = 100;
				break;
			default:
				a = 0;
				break;
			case FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket:
				MANPIONIGNO_EventGoDiva ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as MANPIONIGNO_EventGoDiva;
				if(ev != null)
				{
					return 9999;
				}
				break;
			case FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
				return LKMHPJKIFDN.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA[NANNGLGOFKH - 1].DOOGFEGEKLG_Max;
			case FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
				return LKMHPJKIFDN.NKOKFIMNCJM_EventGachaTicket.CDENCMNHNGA[NANNGLGOFKH - 1].DOOGFEGEKLG_Max;
			case FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
				if(NANNGLGOFKH != 13)
				{
					return LKMHPJKIFDN.OOEPHOEFBNL_SpItem.CDENCMNHNGA[NANNGLGOFKH - 1].DOOGFEGEKLG_Max;
				}
				else
				{
					return LDEGEHAEALK.GJCOJBDOOJG_LimitedCompoItem.OPCIHPEIFFE(1);
				}
			case FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
				a = 9;
				break;
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem:
				return LKMHPJKIFDN.IHPFCIJKFIC_LimitedItem.CDENCMNHNGA[NANNGLGOFKH - 1].DOOGFEGEKLG_Max;
			case FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
				a = 31;
				break;
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				return LKMHPJKIFDN.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj[NANNGLGOFKH - 1].KEJMJPHFFOJ_Max;
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				return LKMHPJKIFDN.EPAHOAKPAJJ_DecoItem.COLIEKINOPB_ItemsPoster[NANNGLGOFKH - 1].KEJMJPHFFOJ_Max;
			case FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
			case FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
				return LKMHPJKIFDN.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("poster_have_max", 50);
			case FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
				return LKMHPJKIFDN.ONOJBMDKBLE_EventRaidItem.CDENCMNHNGA[NANNGLGOFKH - 1].DOOGFEGEKLG_Max;
			case FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				return LKMHPJKIFDN.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA[NANNGLGOFKH - 1].KEJMJPHFFOJ_Max;
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				return LDEGEHAEALK.GJCOJBDOOJG_LimitedCompoItem.OPCIHPEIFFE(NANNGLGOFKH);
			case FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit:
				return LKMHPJKIFDN.OINLLHOMEAK_GachaLimit.DDHDJNCFNOC(NANNGLGOFKH + 40000);
		}
		return a;
	}

	// // RVA: 0x12FC440 Offset: 0x12FC440 VA: 0x12FC440
	public static int PJMJIKKJAAM_GetDecoItemSet(OKGLGHCBCJP_Database LKMHPJKIFDN, FKGCBLHOOCL_Category INDDJNMPONH, int MHFBCINOJEE)
	{
		switch(INDDJNMPONH)
		{
			case FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
				return LKMHPJKIFDN.EPAHOAKPAJJ_DecoItem.GJLHEJPHEDA_ItemsBg[MHFBCINOJEE - 1].EBIMFANOGBK_SetId;
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				return LKMHPJKIFDN.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj[MHFBCINOJEE - 1].EBIMFANOGBK_SetId;
			case FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				return LKMHPJKIFDN.EPAHOAKPAJJ_DecoItem.KHCACDIKJLG_ItemsChara[MHFBCINOJEE - 1].EBIMFANOGBK_SetId;
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				return LKMHPJKIFDN.EPAHOAKPAJJ_DecoItem.COLIEKINOPB_ItemsPoster[MHFBCINOJEE - 1].EBIMFANOGBK_SetId;
		}
		return 0;
	}
}
