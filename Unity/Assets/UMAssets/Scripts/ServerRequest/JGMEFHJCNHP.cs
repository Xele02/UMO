
using System.Collections.Generic;
using UnityEngine;

public class MFDJIFIIPJD
{
	public string HAAJGNCFNJM; // 0x8
	public int OCNINMIMHGC_ItemFullId; // 0xC
	public int MBJIFDBEDAC_Cnt; // 0x10
	public int MJBKGOJBPAD; // 0x14
	public int JJBGOIMEIPF_ItemFullId; // 0x18
	public EKLNMHFCAOI.FKGCBLHOOCL_Category NPPNDDMPFJJ_ItemCategory; // 0x1C
	public int NNFNGLJOKKF_ItemId; // 0x20
	public bool LHMOAJAIJCO; // 0x24
	public int MJBODMOLOBC; // 0x28
	public int JPIPENJGGDD; // 0x2C
	public int CJEOENICNOC; // 0x30
	public bool HMGCLKNLMAL; // 0x34
	public OOOOCFAFGCP KACECFNECON; // 0x38
	public bool JOPPFEHKNFO; // 0x3C
	public bool ILMMOGBDIME; // 0x3D
	public bool AIFBJHNBPMH; // 0x3E
	public bool MBFGLMEECOO; // 0x3F

	//// RVA: 0x1312448 Offset: 0x1312448 VA: 0x1312448
	//public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }

	//// RVA: 0x131311C Offset: 0x131311C VA: 0x131311C
	//public void KHEKNNFCAOI(string OPFGFINHFCE, int NANNGLGOFKH, int HMFFHLPNMPH, int INDDJNMPONH = 0) { }

	//// RVA: 0x1313134 Offset: 0x1313134 VA: 0x1313134
	public void KHEKNNFCAOI(EKLNMHFCAOI.FKGCBLHOOCL_Category NPPNDDMPFJJ, int NANNGLGOFKH, int HMFFHLPNMPH)
	{
		MJBKGOJBPAD = 0;
		switch (NPPNDDMPFJJ)
		{
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC:
				MJBKGOJBPAD = 1;
				HAAJGNCFNJM = "vc";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket:
				HAAJGNCFNJM = "gacha_ticket";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
				HAAJGNCFNJM = AFEHLCGHAEE_Strings.PJPGBPACBFA_uc_item;
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
				HAAJGNCFNJM = AFEHLCGHAEE_Strings.COIODGJDJEJ_scene;
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume:
				HAAJGNCFNJM = "costume";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie:
				HAAJGNCFNJM = "valkyrie";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
				HAAJGNCFNJM = AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item;
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
				HAAJGNCFNJM = AFEHLCGHAEE_Strings.GJODJNIHKKF_epi_item;
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
				HAAJGNCFNJM = "emblem";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem:
				HAAJGNCFNJM = "event_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket:
				HAAJGNCFNJM = "event_ticket";
				break;
			default:
				HAAJGNCFNJM = "";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem:
				HAAJGNCFNJM = "compo";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem:
				HAAJGNCFNJM = "sns_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
				HAAJGNCFNJM = "energy_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
				HAAJGNCFNJM = "mv_ticket";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
				HAAJGNCFNJM = "medal";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
				HAAJGNCFNJM = "event_gacha_ticket";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
				HAAJGNCFNJM = "present_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
				HAAJGNCFNJM = "sp_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
				HAAJGNCFNJM = "cos_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
				HAAJGNCFNJM = "rareup_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem:
				HAAJGNCFNJM = "limited_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
				HAAJGNCFNJM = "monthly_pass";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
				HAAJGNCFNJM = "deco_bg";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				HAAJGNCFNJM = "deco_obj";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				HAAJGNCFNJM = "deco_chara";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
				HAAJGNCFNJM = "deco_serif";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
				HAAJGNCFNJM = "deco_sp";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
				HAAJGNCFNJM = "val_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				HAAJGNCFNJM = "deco_poster";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
				HAAJGNCFNJM = "raid_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				HAAJGNCFNJM = "deco_set_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				HAAJGNCFNJM = "limited_compo_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg:
				HAAJGNCFNJM = "home_bg_item";
				break;
		}
		OCNINMIMHGC_ItemFullId = NANNGLGOFKH;
		MBJIFDBEDAC_Cnt = HMFFHLPNMPH;
		MCDEKMIABEN();
	}

	//// RVA: 0x131358C Offset: 0x131358C VA: 0x131358C
	public void KHEKNNFCAOI(int JJBGOIMEIPF, int HMFFHLPNMPH)
	{
		KHEKNNFCAOI(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JJBGOIMEIPF), EKLNMHFCAOI.DEACAHNLMNI_getItemId(JJBGOIMEIPF), HMFFHLPNMPH);
	}

	//// RVA: 0x13126B8 Offset: 0x13126B8 VA: 0x13126B8
	public void MCDEKMIABEN()
	{
		if(MJBKGOJBPAD == 2)
		{
			NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_None;
			NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_ItemFullId);
			JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
		}
		else
		{
			if(MJBKGOJBPAD != 1)
			{
				if(OCNINMIMHGC_ItemFullId > 999)
				{
					JJBGOIMEIPF_ItemFullId = OCNINMIMHGC_ItemFullId;
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(OCNINMIMHGC_ItemFullId);
					NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_ItemFullId);
					//LAB_013127c0
					KACECFNECON = null;
					return;
				}
				EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_None;
				if (HAAJGNCFNJM.Contains(AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem;
				}
				else if(HAAJGNCFNJM.Contains(AFEHLCGHAEE_Strings.COIODGJDJEJ_scene))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
				}
				else if (HAAJGNCFNJM.Contains(AFEHLCGHAEE_Strings.PJPGBPACBFA_uc_item))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
				}
				else if (HAAJGNCFNJM.Contains(AFEHLCGHAEE_Strings.ACGLMKEBMDL_uc))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
				}
				else if (HAAJGNCFNJM.Contains("gacha_ticket"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
				}
				else if (HAAJGNCFNJM.Contains("event_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem;
				}
				else if (HAAJGNCFNJM.Contains(AFEHLCGHAEE_Strings.GJODJNIHKKF_epi_item))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem;
				}
				else if (HAAJGNCFNJM.Contains("costume"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume;
				}
				else if (HAAJGNCFNJM.Contains("diva_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.JHGPNDLNPFA_DivaItem;
				}
				else if (HAAJGNCFNJM.Contains("emblem"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem;
				}
				else if (HAAJGNCFNJM.Contains("valkyrie"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie;
				}
				else if (HAAJGNCFNJM.Contains("compo"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem;
				}
				else if (HAAJGNCFNJM.Contains("sns_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem;
				}
				else if (HAAJGNCFNJM.Contains("energy_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem;
				}
				else if (HAAJGNCFNJM.Contains("event_ticket"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket;
				}
				else if (HAAJGNCFNJM.Contains("medal"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal;
				}
				else if (HAAJGNCFNJM.Contains("mv_ticket"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket;
				}
				else if (HAAJGNCFNJM.Contains("event_gacha_ticket"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket;
				}
				else if (HAAJGNCFNJM.Contains("present_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem;
				}
				else if (HAAJGNCFNJM.Contains("sp_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem;
				}
				else if (HAAJGNCFNJM.Contains("cos_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem;
				}
				else if (HAAJGNCFNJM.Contains("rareup_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem;
				}
				else if (HAAJGNCFNJM.Contains("limited_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem;
				}
				else if (HAAJGNCFNJM.Contains("monthly_pass"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem;
				}
				else if (HAAJGNCFNJM.Contains("deco_bg"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg;
				}
				else if (HAAJGNCFNJM.Contains("deco_obj"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj;
				}
				else if (HAAJGNCFNJM.Contains("deco_chara"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara;
				}
				else if (HAAJGNCFNJM.Contains("deco_serif"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif;
				}
				else if (HAAJGNCFNJM.Contains("deco_sp"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp;
				}
				else if (HAAJGNCFNJM.Contains("deco_poster"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster;
				}
				else if (HAAJGNCFNJM.Contains("val_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem;
				}
				else if (HAAJGNCFNJM.Contains("deco_set_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem;
				}
				else if (HAAJGNCFNJM.Contains("raid_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem;
				}
				else if (HAAJGNCFNJM.Contains("event_raid_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem;
				}
				else if (HAAJGNCFNJM.Contains("limited_compo_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem;
				}
				else if (HAAJGNCFNJM.Contains("home_bg_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg;
				}
				NPPNDDMPFJJ_ItemCategory = cat;
				NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_ItemFullId);
				JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
				KACECFNECON = null;
				return;
			}
			if((OCNINMIMHGC_ItemFullId - 3001) < 999 && (OCNINMIMHGC_ItemFullId - 3001) >= 0)
			{
				NNFNGLJOKKF_ItemId = OCNINMIMHGC_ItemFullId - 3000;
				NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
				JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
			}
			else if ((OCNINMIMHGC_ItemFullId - 2001) < 999 && (OCNINMIMHGC_ItemFullId - 2001) >= 0)
			{
				if (!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH.Contains(OCNINMIMHGC_ItemFullId))
				{
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
					NNFNGLJOKKF_ItemId = OCNINMIMHGC_ItemFullId - 1996;
					JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
				}
				else
				{
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
					NNFNGLJOKKF_ItemId = OCNINMIMHGC_ItemFullId - 2000;
					JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
				}
			}
			else
			{
				if(OCNINMIMHGC_ItemFullId != 5001)
				{
					NNFNGLJOKKF_ItemId = 1;
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
					JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1);
					OCNINMIMHGC_ItemFullId = 1;
					//LAB_013127c0
					KACECFNECON = null;
					return;
				}
				NNFNGLJOKKF_ItemId = 9;
				NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
				JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
			}
		}
		//LAB_013127c0
		KACECFNECON = null;
	}
}

public class PNFCNPCGKDM
{
	public string LJNAKDMILMC; // 0x8
	public string LJGOOOMOMMA; // 0xC
	public bool OOIJCMLEAJP; // 0x10
	public List<MFDJIFIIPJD> HBHMAKNGKFK; // 0x14
	public long KBFOIECIADN; // 0x18
	public long EGBOHDFBAPB; // 0x20

	// RVA: 0xFF1614 Offset: 0xFF1614 VA: 0xFF1614
	//public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }
}

public class IGPDIKDNFKD
{
	public List<PNFCNPCGKDM> CEDLLCCONJP; // 0x8

	// RVA: 0x11F702C Offset: 0x11F702C VA: 0x11F702C
	//public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }
}

[System.Obsolete("Use JGMEFHJCNHP_GetAchievementRecords", true)]
public class JGMEFHJCNHP { }
public class JGMEFHJCNHP_GetAchievementRecords : CACGCMBKHDI_Request
{
	public bool KMOBDLBKAAA; // 0x7C
	public List<string> MIDAMHNABAJ; // 0x80

	public IGPDIKDNFKD NFEAMMJIMPG { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0xB1B3EC Offset: 0xB1B3EC VA: 0xB1B3EC Slot: 12
	public override void DHLDNIEELHO()
	{
		TodoLogger.Log(0, "JGMEFHJCNHP_GetAchievementRecords.DHLDNIEELHO()");
	}

	// RVA: 0xB1B510 Offset: 0xB1B510 VA: 0xB1B510 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		TodoLogger.Log(0, "JGMEFHJCNHP_GetAchievementRecords.MGFNKDPHFGI()");
	}
}
