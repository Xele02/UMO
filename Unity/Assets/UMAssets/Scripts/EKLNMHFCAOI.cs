using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.SmartFormat;
using XeSys;

[System.Obsolete()]
public class EKLNMHFCAOI {}
public class EKLNMHFCAOI_ItemManager
{
	public enum FKGCBLHOOCL_Category : byte
	{
		HJNNKCMLGFL_0_None = 0,
		PJDEOPMBGKJ_PaidVC = 1,
		OBHECJMAEIO_GachaTicket = 2,
		ACGHELNGNGK_UnionCredit = 3,
		MHKFDBLMOGF_Scene = 4,
		KBHGPMNGALJ_5_Costume = 5,
		PFIOMNHDHCO_6_Valkyrie = 6,
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
		DLOPEFGOAPD_24_LimitedItem = 24,
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
		AEFCOHJBLPO_45_Num = 45,
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
	// public static string OBIEJBLHHPD(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type) { }

	// // RVA: 0x12F5788 Offset: 0x12F5788 VA: 0x12F5788
	public static FKGCBLHOOCL_Category BKHFLDMOGBD_GetItemCategory(int _KIJAPOFAGPN_ItemId)
	{
		return (FKGCBLHOOCL_Category)(_KIJAPOFAGPN_ItemId / 10000);
	}

	// // RVA: 0x12F57A4 Offset: 0x12F57A4 VA: 0x12F57A4
	public static int DEACAHNLMNI_getItemId(int _KIJAPOFAGPN_ItemId)
	{
		return _KIJAPOFAGPN_ItemId % 10000;
	}

	// // RVA: 0x12F57C4 Offset: 0x12F57C4 VA: 0x12F57C4
	public static int GJEEGMCBGGM_GetItemFullId(FKGCBLHOOCL_Category _INDDJNMPONH_type, int _PPFNGGCBJKC_id)
	{
		return (int)_INDDJNMPONH_type * 10000 + _PPFNGGCBJKC_id;
	}

	// // RVA: 0x12F57D0 Offset: 0x12F57D0 VA: 0x12F57D0
	// public static int BGIBJJAFOBC(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int _DKMLEDJJFOI__CurrencyId) { }

	// // RVA: 0x12F57F8 Offset: 0x12F57F8 VA: 0x12F57F8
	public static int ADGMGNKCIGA(int _DKMLEDJJFOI__CurrencyId)
	{
		return _DKMLEDJJFOI__CurrencyId % 1000;
	}

	// // RVA: 0x12F5818 Offset: 0x12F5818 VA: 0x12F5818
	public static int LKBIIPBKNGJ_GetItemFileStatus(int _KIJAPOFAGPN_ItemId)
	{
		FKGCBLHOOCL_Category itemCat = (FKGCBLHOOCL_Category)((_KIJAPOFAGPN_ItemId / 10000) & 0xff);
		int itemId = _KIJAPOFAGPN_ItemId % 10000;
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
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_24_LimitedItem:
			case FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
			case FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				return 1;
			case FKGCBLHOOCL_Category.KBHGPMNGALJ_5_Costume:
				if(itemId > 0)
				{
					if(itemId <= IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_table.Count)
					{
						if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_table[itemId - 1].PPEGAKEIEGM_Enabled == 2)
						{
							return 1;
						}
						return 2;
					}
				}
				break;
			case FKGCBLHOOCL_Category.PFIOMNHDHCO_6_Valkyrie:
				if(itemId > 0)
				{
					if(itemId <= IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table.Count)
					{
						if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table[itemId - 1].PPEGAKEIEGM_Enabled == 2)
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
	// public static string ANIEBBILFKN(int _KIJAPOFAGPN_ItemId) { }

	// // RVA: 0x12F5CE8 Offset: 0x12F5CE8 VA: 0x12F5CE8
	public static string FKMCHHDOAAB(int _KIJAPOFAGPN_ItemId, bool useJp = false)
	{
		return FKMCHHDOAAB((FKGCBLHOOCL_Category)(_KIJAPOFAGPN_ItemId / 10000), _KIJAPOFAGPN_ItemId % 10000, useJp:useJp);
	}

	// // RVA: 0x12F5D84 Offset: 0x12F5D84 VA: 0x12F5D84
	public static string FKMCHHDOAAB(FKGCBLHOOCL_Category _INDDJNMPONH_type, int _JBGEEPFKIGG_val, bool useJp = false)
	{
		if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
		{
			return string.Format(BJIECJAOMDJ[(int)_INDDJNMPONH_type], _JBGEEPFKIGG_val) + (useJp ? "_jp" : "");
		}
		else
		{
			return string.Format(BJIECJAOMDJ[(int)_INDDJNMPONH_type], _JBGEEPFKIGG_val);
		}
	}

	// // RVA: 0x12F5E80 Offset: 0x12F5E80 VA: 0x12F5E80
	public static string GPMNHMLGDHO(FKGCBLHOOCL_Category _INDDJNMPONH_type, int _JBGEEPFKIGG_val)
	{
		return string.Format(IFDGOKENMLG[(int)_INDDJNMPONH_type], _JBGEEPFKIGG_val);
	}

	// // RVA: 0x12F5F7C Offset: 0x12F5F7C VA: 0x12F5F7C
	public static string GFFEIIALFBD(FKGCBLHOOCL_Category _INDDJNMPONH_type, int _JBGEEPFKIGG_val)
	{
		return string.Format(MMKIEBOGMJM[(int)_INDDJNMPONH_type], _JBGEEPFKIGG_val);
	}

	// // RVA: 0x12F6078 Offset: 0x12F6078 VA: 0x12F6078
	public static string INCKKODFJAP_GetItemName(int _KIJAPOFAGPN_ItemId, bool useJp = false)
	{
		return INCKKODFJAP_GetItemName((FKGCBLHOOCL_Category)(_KIJAPOFAGPN_ItemId / 10000), _KIJAPOFAGPN_ItemId % 10000, useJp:useJp);
	}

	// // RVA: 0x12F6114 Offset: 0x12F6114 VA: 0x12F6114
	public static string INCKKODFJAP_GetItemName(FKGCBLHOOCL_Category _INDDJNMPONH_type, int _JBGEEPFKIGG_val, bool useJp = false)
	{
		int id = _JBGEEPFKIGG_val;
		if (_INDDJNMPONH_type == FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit)
		{
			BIHCALIAJII_GachaLimit.AICPHCIFEJL g = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.OINLLHOMEAK_GachaLimit.CDENCMNHNGA_table.Find((BIHCALIAJII_GachaLimit.AICPHCIFEJL _GHPLINIACBB_x) =>
			{
				//0x1303AD8
				return _GHPLINIACBB_x.FEFDGBPFKBJ_gid % 10000 == _JBGEEPFKIGG_val;
			});
			if (g != null)
				id = g.PPFNGGCBJKC_id;
		}
		string str = MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(FKMCHHDOAAB(_INDDJNMPONH_type, id, useJp:useJp));
		if(RuntimeSettings.CurrentSettings.DisplayIdInName)
			str = "["+_JBGEEPFKIGG_val+"] "+str;
		if (_INDDJNMPONH_type != FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
			return str;
		return str.Replace("\n", "");
	}

	// // RVA: 0x12F63E8 Offset: 0x12F63E8 VA: 0x12F63E8
	public static string ILKGBGOCLAO_GetItemDesc(FKGCBLHOOCL_Category _INDDJNMPONH_type, int _JBGEEPFKIGG_val)
	{
		if(_INDDJNMPONH_type < FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
		{
			if(_INDDJNMPONH_type == FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem)
			{
				return string.Format(MessageManager.Instance.GetMessage("menu", "sns_item_description"), 
					MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(string.Format("rn_{0:D4}", IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_table[_JBGEEPFKIGG_val - 1].MALFHCHNEFN_RoomId)),
					MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem, _JBGEEPFKIGG_val)));
			}
			if(_INDDJNMPONH_type == FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
			{
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.LPHKLEJPKAN(MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, _JBGEEPFKIGG_val)), _JBGEEPFKIGG_val);
			}
			if(_INDDJNMPONH_type == FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem)
			{
				return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem, _JBGEEPFKIGG_val)) + "\n" + string.Format(MessageManager.Instance.GetMessage("menu", "present_item_rank_postfix"), IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("intimacy_player_level", 8));
			}
			return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(_INDDJNMPONH_type, _JBGEEPFKIGG_val));
		}
		else
		{
			if(_INDDJNMPONH_type < FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
			{
				if(_INDDJNMPONH_type == FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
				{
					return string.Format(MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif, _JBGEEPFKIGG_val)), NCPPAHHCCAO.EFNHFKLKNHJ(_JBGEEPFKIGG_val));
				}
				if(_INDDJNMPONH_type != FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef)
				{
					return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(_INDDJNMPONH_type, _JBGEEPFKIGG_val));
				}
				string str = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam("deco_poster_scene_before", "");
				if (str != "")
					return str;
				return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef, _JBGEEPFKIGG_val));
			}
			else if(_INDDJNMPONH_type == FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
			{
				string str = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam("deco_poster_scene_after", "");
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.OEEJKKFOBKD(_JBGEEPFKIGG_val))
				{
					string str2 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam("deco_poster_scene_single6", "");
					if (str2 != "")
						str = str2;
				}
				if (str != "")
					return str;
				return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft, _JBGEEPFKIGG_val));
			}
			else
			{
				if(_INDDJNMPONH_type != FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit)
				{
					return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(_INDDJNMPONH_type, _JBGEEPFKIGG_val));
				}
				BIHCALIAJII_GachaLimit.AICPHCIFEJL g = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.OINLLHOMEAK_GachaLimit.CDENCMNHNGA_table.Find((BIHCALIAJII_GachaLimit.AICPHCIFEJL _GHPLINIACBB_x) =>
				{
					//0x1303B38
					return _GHPLINIACBB_x.FEFDGBPFKBJ_gid % 10000 == _JBGEEPFKIGG_val;
				});
				if (g != null)
					_JBGEEPFKIGG_val = g.PPFNGGCBJKC_id;
				return MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(GPMNHMLGDHO(FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit, _JBGEEPFKIGG_val));
			}
		}
	}

	// // RVA: 0x12F734C Offset: 0x12F734C VA: 0x12F734C
	public static int FABCKNDLPDH_GetItemRarity(int _KIJAPOFAGPN_ItemId)
	{
		return FABCKNDLPDH_GetItemRarity((FKGCBLHOOCL_Category)(_KIJAPOFAGPN_ItemId/ 10000), _KIJAPOFAGPN_ItemId % 10000);
	}

	// // RVA: 0x12F73E8 Offset: 0x12F73E8 VA: 0x12F73E8
	public static int APDHLDGBENB(int _KIJAPOFAGPN_ItemId)
	{
		int a = FABCKNDLPDH_GetItemRarity(_KIJAPOFAGPN_ItemId);
		if (BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId) == FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
		{
			return a + (IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[_KIJAPOFAGPN_ItemId % 10000 - 1].FBJDHLGODPP_Sngl ? 1 : 0);
		}
		return a;
	}

	// // RVA: 0x12EC60C Offset: 0x12EC60C VA: 0x12EC60C
	public static int FABCKNDLPDH_GetItemRarity(FKGCBLHOOCL_Category _INDDJNMPONH_type, int _PPFNGGCBJKC_id)
	{
		switch(_INDDJNMPONH_type)
		{
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
				{
					if(_PPFNGGCBJKC_id != 0)
						_PPFNGGCBJKC_id--;
					return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NMJEDFNPIPL_UcItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id].EKLIPGELKCL_Rarity;
				}
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NKDGLGCAPEI_GrowItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NEGGMILDEEF_EpiItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ALFKMKICDPP_Compo.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NEGKEEAFKHP_MvTicket.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LPFEHNJEJFB_PresentItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.OOEPHOEFBNL_SpItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.EEOADCECNOM_GetCostume(_PPFNGGCBJKC_id).EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.KKIMFMKOHFH_RareUpItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_24_LimitedItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IHPFCIJKFIC_LimitedItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GJLHEJPHEDA_ItemsBg[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KHCACDIKJLG_Characters[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FBGKBGNIHGC_ValItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.COLIEKINOPB_ItemsPoster[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
				int a = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
				if(a > 3 && a < 6)
					a++;
				return a;
			case FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ONOJBMDKBLE_EventRaidItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.FHBIIONKIDI_Stamps[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[_PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
		}
		return 1;
	}

	// // RVA: 0x12F75BC Offset: 0x12F75BC VA: 0x12F75BC
	public static string NDBLEADIDLA(FKGCBLHOOCL_Category _INDDJNMPONH_type, int _JBGEEPFKIGG_val/* = 0*/, int cnt = 0)
	{
		if(_JBGEEPFKIGG_val > 0)
		{
			string str = GFFEIIALFBD(_INDDJNMPONH_type, _JBGEEPFKIGG_val);
			if(str != "")
			{
				str = Smart.Format(MessageManager.Instance.GetBank(AFEHLCGHAEE_Strings.NDFIEMPPMLF_master).GetMessageByLabel(str), cnt);
				if(str != "")
					return str;
			}
		}
		return Smart.Format(KBHKKMMINOD[(int)_INDDJNMPONH_type], cnt);
	}

	// // RVA: 0x12F77D0 Offset: 0x12F77D0 VA: 0x12F77D0
	public static bool KGANFNCODNG_IsValidCategory(FKGCBLHOOCL_Category _INDDJNMPONH_type)
	{
		switch(_INDDJNMPONH_type)
		{
			case FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC:
			case FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket:
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
			case FKGCBLHOOCL_Category.KBHGPMNGALJ_5_Costume:
			case FKGCBLHOOCL_Category.PFIOMNHDHCO_6_Valkyrie:
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
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_24_LimitedItem:
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
	public static int DLNFNHMPGLI_GetNumClamped(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, FKGCBLHOOCL_Category _INDDJNMPONH_type, int _NANNGLGOFKH_value, IKDICBBFBMI_NetEventBaseController JMFICAICKBC)
	{
		return Mathf.Clamp(ALHCGDMEMID_GetNumItems(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _INDDJNMPONH_type, _NANNGLGOFKH_value, JMFICAICKBC), 0, EEIFENNHAHF_GetMax(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _INDDJNMPONH_type, _NANNGLGOFKH_value, JMFICAICKBC));
	}

	// // RVA: 0x12F79B0 Offset: 0x12F79B0 VA: 0x12F79B0
	public static int ALHCGDMEMID_GetNumItems(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, FKGCBLHOOCL_Category _INDDJNMPONH_type, int _NANNGLGOFKH_value, IKDICBBFBMI_NetEventBaseController JMFICAICKBC)
	{
		switch(_INDDJNMPONH_type)
		{
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc;
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
				if(_LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date != 0)
				{
					return _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[_NANNGLGOFKH_value - 1].JPIPENJGGDD_NumBoard + (_LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1].FBJDHLGODPP_Sngl ? 0 : 1);
				}
				break;
			case FKGCBLHOOCL_Category.KBHGPMNGALJ_5_Costume:
				return _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList[_NANNGLGOFKH_value - 1].FJODMPGPDDD_Unlocked ? 1 : 0;
			case FKGCBLHOOCL_Category.PFIOMNHDHCO_6_Valkyrie:
				return _LDEGEHAEALK_ServerData.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[_NANNGLGOFKH_value - 1].FJODMPGPDDD_Unlocked ? 1 : 0;
			case FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.KBMDMEEMGLK_grow_item[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.GJODJNIHKKF_epi_item[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
				if(_LDEGEHAEALK_ServerData.OFAJDLJBMEM_Emblem.MDKOHOCONKE[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date != 0)
				{
					return _LDEGEHAEALK_ServerData.OFAJDLJBMEM_Emblem.MDKOHOCONKE[_NANNGLGOFKH_value - 1].FHCAFLCLGAA_em_cnt;
				}
				break;
			case FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket:
				MANPIONIGNO_NetEventGoDivaController evGoDiva = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as MANPIONIGNO_NetEventGoDivaController;
				if(evGoDiva != null)
				{
					return evGoDiva.AELBIEDNPGB_GetTicketCount(_LDEGEHAEALK_ServerData);
				}
				break;
			case FKGCBLHOOCL_Category.JHGPNDLNPFA_DivaItem:
				return _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[_NANNGLGOFKH_value - 1].CPGFPEDMDEH_have;
			case FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket;
			case FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC:
				return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.NOJDLFKKMDD_GetCurrencyTotal(_NANNGLGOFKH_value);
			case FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
				if(_LDEGEHAEALK_ServerData.MMAIJOCPJHP_EventBoxGacha != null)
				{
					JNGINLMOJKH_EventGachaTicket.JDNAAGCHCOH tkt = _LKMHPJKIFDN_md.NKOKFIMNCJM_EventGachaTicket.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1];
					return _LDEGEHAEALK_ServerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[tkt.EJPKFBHNDGI_ev_no - 1].BGCOKABBHNC_GachaTicketCnt;
				}
				break;
			case FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.DHJFHILPKLB_IntimacyPresent[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
				if(_NANNGLGOFKH_value == 13)
				{
					long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					return _LDEGEHAEALK_ServerData.GJCOJBDOOJG_LimitedCompoItem.HPPKOGKNKMH(1, time);
				}
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.BBFIGEOBOMB_SpItem[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.EFBKCNNFIPJ(_NANNGLGOFKH_value).BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
				{
					long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					return _LDEGEHAEALK_ServerData.DPNKPPBEAGJ_RareUpItem.LDLCGGACHGA(time);
				}
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_24_LimitedItem:
				{
					long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					return _LDEGEHAEALK_ServerData.AFHFIPLOKMN_LimitedItem.HPPKOGKNKMH(_NANNGLGOFKH_value, time);
				}
			case FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
				return _LDEGEHAEALK_ServerData.HMMNDKHKEBC_MonthlyPass.JAMCDEDFHHK_HotenCnt;
			case FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
				return _LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				return _LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				return _LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.PEBDEIKBCCM_Chars[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
				return _LDEGEHAEALK_ServerData.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
				return _LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.MJAIFKFOPPI_ValItem[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				return _LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.PFNNIMBMKDL_Posters[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
				return _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.HOLEDOLMJCB(_NANNGLGOFKH_value, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, 0);
			case FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
				return _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.HOLEDOLMJCB(_NANNGLGOFKH_value, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, 1);
			case FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
				{
					NKOBMDPHNGP_NetEventRaidLobbyController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_NetEventRaidLobbyController;
					if (ev != null)
					{
						return ev.EHGKMLPCDBM_GetItemCount((XeApp.Game.Common.RaidItemConstants.Type) _NANNGLGOFKH_value, null);
					}
				}
				break;
			case FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara:
				return _LDEGEHAEALK_ServerData.FJPOELGFPBP_DecoStamp.FHBIIONKIDI_Stamps[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				return _LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.NOAEDPJGBJK_Sets[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt;
			case FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
				return _LDEGEHAEALK_ServerData.JJFFBDLIOCF_Valkyrie.NBFPEPBFEHI(_NANNGLGOFKH_value, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie);
			case FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
				return _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.LMLGEDEJCJO(_NANNGLGOFKH_value, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, true);
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				{
					long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					return _LDEGEHAEALK_ServerData.GJCOJBDOOJG_LimitedCompoItem.HPPKOGKNKMH(_NANNGLGOFKH_value, time);
				}
			case FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit:
				return _LDEGEHAEALK_ServerData.APFILEMHEPG_GachaLimit.CFLDNJANAPI_GetNum(_NANNGLGOFKH_value + 40000);
		}
		return 0;
	}

	// // RVA: 0x12F92F4 Offset: 0x12F92F4 VA: 0x12F92F4
	public static void DPHGFMEPOCA_SetNumItems(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int _NANNGLGOFKH_value, int _HMFFHLPNMPH_count, IKDICBBFBMI_NetEventBaseController JMFICAICKBC)
	{
		if (_HMFFHLPNMPH_count < 1)
			_HMFFHLPNMPH_count = 0;

		int a = AFEONHCADEL_GetMaxAllowed(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _INDDJNMPONH_type, _NANNGLGOFKH_value, JMFICAICKBC);
		if (a < _HMFFHLPNMPH_count)
			_HMFFHLPNMPH_count = a;

		switch (_INDDJNMPONH_type)
		{
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
				_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc = _HMFFHLPNMPH_count;
				break;
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
				if (_HMFFHLPNMPH_count == 0)
				{
					_LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = 0;
					_LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[_NANNGLGOFKH_value - 1].JPIPENJGGDD_NumBoard = 0;
					_LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[_NANNGLGOFKH_value - 1].IELENGDJPHF_Ulk = 0;
				}
				else
				{
					if (_LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date == 0)
					{
						_LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					}

					MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1];
					_LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[_NANNGLGOFKH_value - 1].JPIPENJGGDD_NumBoard = _HMFFHLPNMPH_count - (dbScene.FBJDHLGODPP_Sngl ? 0 : 1);
					if(dbScene.KELFCMEOPPM_EpisodeId != 0 && dbScene.PPEGAKEIEGM_Enabled == 2)
					{
						if(_LDEGEHAEALK_ServerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[dbScene.KELFCMEOPPM_EpisodeId - 1].BEBJKJKBOGH_date == 0)
						{
							_LDEGEHAEALK_ServerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[dbScene.KELFCMEOPPM_EpisodeId - 1].BEBJKJKBOGH_date = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							_LDEGEHAEALK_ServerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[dbScene.KELFCMEOPPM_EpisodeId - 1].LHMOAJAIJCO_is_new = true;
						}
					}
				}
				break;
			case FKGCBLHOOCL_Category.KBHGPMNGALJ_5_Costume:
				if(_NANNGLGOFKH_value == 0)
				{
					_LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = 0;
				}
				else
				{
					_LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				}
				break;
			case FKGCBLHOOCL_Category.PFIOMNHDHCO_6_Valkyrie:
				if (_NANNGLGOFKH_value == 0)
					_LDEGEHAEALK_ServerData.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = 0;
				else
					_LDEGEHAEALK_ServerData.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				break;
			case FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
				_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.KBMDMEEMGLK_grow_item[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt = _HMFFHLPNMPH_count;
				break;
			case FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
				_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.GJODJNIHKKF_epi_item[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt = _HMFFHLPNMPH_count;
				break;
			case FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
				if (_NANNGLGOFKH_value == 1)
					_HMFFHLPNMPH_count = _NANNGLGOFKH_value;
				if (_HMFFHLPNMPH_count == 0)
				{
					_LDEGEHAEALK_ServerData.OFAJDLJBMEM_Emblem.MDKOHOCONKE[_NANNGLGOFKH_value - 1].FHCAFLCLGAA_em_cnt = 0;
				}
				else
				{
					if(_LDEGEHAEALK_ServerData.OFAJDLJBMEM_Emblem.MDKOHOCONKE[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date == 0)
					{
						_LDEGEHAEALK_ServerData.OFAJDLJBMEM_Emblem.MDKOHOCONKE[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					}
					_LDEGEHAEALK_ServerData.OFAJDLJBMEM_Emblem.MDKOHOCONKE[_NANNGLGOFKH_value - 1].FHCAFLCLGAA_em_cnt = _HMFFHLPNMPH_count - 1;
				}
				break;
			case FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket:
				MANPIONIGNO_NetEventGoDivaController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as MANPIONIGNO_NetEventGoDivaController;
				if (ev != null)
				{
					ev.HPENJEOAMBK_SetTicket((int)_INDDJNMPONH_type * 10000 + _NANNGLGOFKH_value, _HMFFHLPNMPH_count, _LDEGEHAEALK_ServerData);
				}
				break;
			case FKGCBLHOOCL_Category.JHGPNDLNPFA_DivaItem:
				_LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[_NANNGLGOFKH_value - 1].CPGFPEDMDEH_have = _HMFFHLPNMPH_count != 0 ? 1 : 0;
				break;
			case FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
				if(_HMFFHLPNMPH_count == 0)
				{
					_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt = 0;
					_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = 0;
				}
				else
				{
					_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt = _HMFFHLPNMPH_count;
					_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				}
				break;
			case FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
				_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket = _HMFFHLPNMPH_count;
				break;
			case FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
				if (_HMFFHLPNMPH_count == 0)
				{
					_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt = 0;
					_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = 0;
				}
				else
				{
					_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt = _HMFFHLPNMPH_count;
					_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[_NANNGLGOFKH_value - 1].BEBJKJKBOGH_date = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime(); ;
				}
				break;
			//case FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC:
			//	return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.NOJDLFKKMDD_GetCurrencyTotal(_NANNGLGOFKH_value);
			case FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
				if (_LDEGEHAEALK_ServerData.MMAIJOCPJHP_EventBoxGacha != null)
				{
					JNGINLMOJKH_EventGachaTicket.JDNAAGCHCOH tkt = _LKMHPJKIFDN_md.NKOKFIMNCJM_EventGachaTicket.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1];
					_LDEGEHAEALK_ServerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[tkt.EJPKFBHNDGI_ev_no - 1].BGCOKABBHNC_GachaTicketCnt = _HMFFHLPNMPH_count;
				}
				break;
			case FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
				_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.DHJFHILPKLB_IntimacyPresent[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt = _HMFFHLPNMPH_count;
				break;
			case FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
				if (_NANNGLGOFKH_value == 13)
				{
					CBHPGKACDAN(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, 0, 1, _HMFFHLPNMPH_count, JMFICAICKBC);
				}
				else
				{
					_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.BBFIGEOBOMB_SpItem[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt = _HMFFHLPNMPH_count;
				}
				break;
			case FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
				_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.EFBKCNNFIPJ(_NANNGLGOFKH_value).BFINGCJHOHI_cnt = _HMFFHLPNMPH_count;
				break;
			case FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
				{
					long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					int v = _LDEGEHAEALK_ServerData.DPNKPPBEAGJ_RareUpItem.LDLCGGACHGA(time);
					int v2 = _HMFFHLPNMPH_count - v;
					if (v2 < 0)
						v2 = -v2;
					if(v < _HMFFHLPNMPH_count)
					{
						for(int i = 0; i < v2; i++)
						{
							_LDEGEHAEALK_ServerData.DPNKPPBEAGJ_RareUpItem.APIEKGBMBPA(time, false);
						}
					}
					else if(_HMFFHLPNMPH_count < v)
					{
						List<int> l = _LDEGEHAEALK_ServerData.DPNKPPBEAGJ_RareUpItem.ALGMLEPBEGA(time);
						if (l.Count > 0)
						{
							if(l.Count < v2)
							{
								v2 = l.Count;
							}
							for(int i = 0; i < v2; i++)
							{
								_LDEGEHAEALK_ServerData.DPNKPPBEAGJ_RareUpItem.GKFMCICFEFI(l[i], time);
							}
						}
					}
				}
				break;
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_24_LimitedItem:
				{
					long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					int v = _LDEGEHAEALK_ServerData.AFHFIPLOKMN_LimitedItem.HPPKOGKNKMH(_NANNGLGOFKH_value, time);
					int v2 = _HMFFHLPNMPH_count - v;
					if (v2 < 0)
						v2 = -v2;
					if(v < _HMFFHLPNMPH_count)
					{
						for(int i = 0; i < v2; i++)
						{
							_LDEGEHAEALK_ServerData.AFHFIPLOKMN_LimitedItem.CPIICACGNBH_AddItem(_NANNGLGOFKH_value, time, false);
						}
					}
					else if(_HMFFHLPNMPH_count < v)
					{
						List<int> l = _LDEGEHAEALK_ServerData.AFHFIPLOKMN_LimitedItem.BHNDPHCBCKN(_NANNGLGOFKH_value, time);
						if(l.Count > 0)
						{
							if (l.Count < v2)
								v2 = l.Count;
							for(int i = 0; i < v2; i++)
							{
								_LDEGEHAEALK_ServerData.AFHFIPLOKMN_LimitedItem.LLOAMEOCJEO(_NANNGLGOFKH_value, l[i], time);
							}
						}
					}
				}
				break;
			case FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
				_LDEGEHAEALK_ServerData.HMMNDKHKEBC_MonthlyPass.JAMCDEDFHHK_HotenCnt = _HMFFHLPNMPH_count;
				break;
			case FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
				_LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.DJHBDDGEKGO_Bgs[_NANNGLGOFKH_value - 1].PPJAGFPBFHJ_SetItemCount(_HMFFHLPNMPH_count);
				break;
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				_LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.KPMFLNOELIN_Objs[_NANNGLGOFKH_value - 1].PPJAGFPBFHJ_SetItemCount(_HMFFHLPNMPH_count);
				break;
			case FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				_LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.PEBDEIKBCCM_Chars[_NANNGLGOFKH_value - 1].PPJAGFPBFHJ_SetItemCount(_HMFFHLPNMPH_count);
				break;
			case FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
				_LDEGEHAEALK_ServerData.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif[_NANNGLGOFKH_value - 1].PPJAGFPBFHJ_SetItemCount(_HMFFHLPNMPH_count);
				break;
			case FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
				_LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.NBKAMFFIOOG_Sp[_NANNGLGOFKH_value - 1].PPJAGFPBFHJ_SetItemCount(_HMFFHLPNMPH_count);
				break;
			case FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
				_LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.MJAIFKFOPPI_ValItem[_NANNGLGOFKH_value - 1].BFINGCJHOHI_cnt = _HMFFHLPNMPH_count;
				break;
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				_LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.PFNNIMBMKDL_Posters[_NANNGLGOFKH_value - 1].PPJAGFPBFHJ_SetItemCount(_HMFFHLPNMPH_count);
				break;
			//case FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
			//	return LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.HOLEDOLMJCB(_NANNGLGOFKH_value, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, 0);
			//case FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
			//	return LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.HOLEDOLMJCB(_NANNGLGOFKH_value, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, 1);
			//case FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
			//	if (JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) != null)
			//	{
			//		TodoLogger.Log(0, "ALHCGDMEMID_GetNumItems Event");
			//	}
			//	break;
			case FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara:
				_LDEGEHAEALK_ServerData.FJPOELGFPBP_DecoStamp.FHBIIONKIDI_Stamps[_NANNGLGOFKH_value - 1].PPJAGFPBFHJ_SetItemCount(_HMFFHLPNMPH_count);
				break;
			case FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				_LDEGEHAEALK_ServerData.OMMNKDEODJP_DecoItem.NOAEDPJGBJK_Sets[_NANNGLGOFKH_value - 1].PPJAGFPBFHJ_SetItemCount(_HMFFHLPNMPH_count);
				break;
			//case FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
			//	return LDEGEHAEALK_ServerData.JJFFBDLIOCF_Valkyrie.NBFPEPBFEHI(_NANNGLGOFKH_value, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie);
			//case FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
			//	return LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.LMLGEDEJCJO(_NANNGLGOFKH_value, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, true);
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				CBHPGKACDAN(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, 0, _NANNGLGOFKH_value, _HMFFHLPNMPH_count, JMFICAICKBC);
				break;
			case FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit:
				_LDEGEHAEALK_ServerData.APFILEMHEPG_GachaLimit.KHBNLBNPGPK(_NANNGLGOFKH_value + 40000, _HMFFHLPNMPH_count);
				break;
		}
	}

	// // RVA: 0x12FBFF0 Offset: 0x12FBFF0 VA: 0x12FBFF0
	public static void CBHPGKACDAN(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int _NANNGLGOFKH_value, int _HMFFHLPNMPH_count, IKDICBBFBMI_NetEventBaseController JMFICAICKBC)
	{
		long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		int v = _LDEGEHAEALK_ServerData.GJCOJBDOOJG_LimitedCompoItem.HPPKOGKNKMH(_NANNGLGOFKH_value, time);
		int v2 = _HMFFHLPNMPH_count - v;
		if (v2 < 0)
			v2 = -v2;
		if(v < _HMFFHLPNMPH_count)
		{
			for(int i = 0; i < v2; i++)
			{
				_LDEGEHAEALK_ServerData.GJCOJBDOOJG_LimitedCompoItem.CPIICACGNBH_AddItem(_NANNGLGOFKH_value, time, false);
			}
		}
		else if(_HMFFHLPNMPH_count < v)
		{
			List<int> l = _LDEGEHAEALK_ServerData.GJCOJBDOOJG_LimitedCompoItem.BHNDPHCBCKN(_NANNGLGOFKH_value, time);
			if(l.Count > 0)
			{
				if (l.Count < v2)
					v2 = l.Count;
				for(int i = 0; i < v2; i++)
				{
					_LDEGEHAEALK_ServerData.GJCOJBDOOJG_LimitedCompoItem.LLOAMEOCJEO(_NANNGLGOFKH_value, l[i], time);
				}
			}
		}
	}

	// // RVA: 0x12FC384 Offset: 0x12FC384 VA: 0x12FC384
	// public static void BAABHKHJBBH(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int _NANNGLGOFKH_value, IKDICBBFBMI_NetEventBaseController JMFICAICKBC) { }

	// // RVA: 0x12F91E0 Offset: 0x12F91E0 VA: 0x12F91E0
	public static int EEIFENNHAHF_GetMax(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int _NANNGLGOFKH_value, IKDICBBFBMI_NetEventBaseController JMFICAICKBC)
	{
		int v = AFEONHCADEL_GetMaxAllowed(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _INDDJNMPONH_type, _NANNGLGOFKH_value, JMFICAICKBC);
		if (_INDDJNMPONH_type != FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem && _INDDJNMPONH_type != FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
			return v;
		return Mathf.Clamp(v, 0, 99999);
	}

	// // RVA: 0x12FB71C Offset: 0x12FB71C VA: 0x12FB71C
	public static int AFEONHCADEL_GetMaxAllowed(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int _NANNGLGOFKH_value, IKDICBBFBMI_NetEventBaseController JMFICAICKBC)
	{
		int a = 99999999;
		switch(_INDDJNMPONH_type)
		{
			case FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket:
				a = 99;
				break;
			case FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
			case FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
				break;
			case FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1];
					int v = _LKMHPJKIFDN_md.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed);
					int v2 = 1;
					if (PPMJLBEOIPF)
						v2 = 10000;
					return v + v2 - (dbScene.FBJDHLGODPP_Sngl ? 1 : 0);
				}
			case FKGCBLHOOCL_Category.KBHGPMNGALJ_5_Costume:
			case FKGCBLHOOCL_Category.PFIOMNHDHCO_6_Valkyrie:
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
				MANPIONIGNO_NetEventGoDivaController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as MANPIONIGNO_NetEventGoDivaController;
				if(ev != null)
				{
					return 9999;
				}
				break;
			case FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
				return _LKMHPJKIFDN_md.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1].DOOGFEGEKLG_max;
			case FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
				return _LKMHPJKIFDN_md.NKOKFIMNCJM_EventGachaTicket.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1].DOOGFEGEKLG_max;
			case FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
				if(_NANNGLGOFKH_value != 13)
				{
					return _LKMHPJKIFDN_md.OOEPHOEFBNL_SpItem.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1].DOOGFEGEKLG_max;
				}
				else
				{
					return _LDEGEHAEALK_ServerData.GJCOJBDOOJG_LimitedCompoItem.OPCIHPEIFFE(1);
				}
			case FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
				a = 9;
				break;
			case FKGCBLHOOCL_Category.DLOPEFGOAPD_24_LimitedItem:
				return _LKMHPJKIFDN_md.IHPFCIJKFIC_LimitedItem.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1].DOOGFEGEKLG_max;
			case FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
				a = 31;
				break;
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				return _LKMHPJKIFDN_md.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj[_NANNGLGOFKH_value - 1].KEJMJPHFFOJ_Max;
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				return _LKMHPJKIFDN_md.EPAHOAKPAJJ_DecoItem.COLIEKINOPB_ItemsPoster[_NANNGLGOFKH_value - 1].KEJMJPHFFOJ_Max;
			case FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
			case FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
				return _LKMHPJKIFDN_md.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("poster_have_max", 50);
			case FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
				return _LKMHPJKIFDN_md.ONOJBMDKBLE_EventRaidItem.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1].DOOGFEGEKLG_max;
			case FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				return _LKMHPJKIFDN_md.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA_table[_NANNGLGOFKH_value - 1].KEJMJPHFFOJ_Max;
			case FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				return _LDEGEHAEALK_ServerData.GJCOJBDOOJG_LimitedCompoItem.OPCIHPEIFFE(_NANNGLGOFKH_value);
			case FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit:
				return _LKMHPJKIFDN_md.OINLLHOMEAK_GachaLimit.DDHDJNCFNOC(_NANNGLGOFKH_value + 40000);
		}
		return a;
	}

	// // RVA: 0x12FC440 Offset: 0x12FC440 VA: 0x12FC440
	public static int PJMJIKKJAAM_GetDecoItemSet(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, FKGCBLHOOCL_Category _INDDJNMPONH_type, int _MHFBCINOJEE_Num)
	{
		switch(_INDDJNMPONH_type)
		{
			case FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
				return _LKMHPJKIFDN_md.EPAHOAKPAJJ_DecoItem.GJLHEJPHEDA_ItemsBg[_MHFBCINOJEE_Num - 1].EBIMFANOGBK_SetId;
			case FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				return _LKMHPJKIFDN_md.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj[_MHFBCINOJEE_Num - 1].EBIMFANOGBK_SetId;
			case FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				return _LKMHPJKIFDN_md.EPAHOAKPAJJ_DecoItem.KHCACDIKJLG_Characters[_MHFBCINOJEE_Num - 1].EBIMFANOGBK_SetId;
			case FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				return _LKMHPJKIFDN_md.EPAHOAKPAJJ_DecoItem.COLIEKINOPB_ItemsPoster[_MHFBCINOJEE_Num - 1].EBIMFANOGBK_SetId;
		}
		return 0;
	}
}
