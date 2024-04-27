
using System.Collections.Generic;
using UnityEngine;

public class MFDJIFIIPJD
{
	public string HAAJGNCFNJM_ItemName; // 0x8
	public int OCNINMIMHGC_ItemFullId; // 0xC
	public int MBJIFDBEDAC_Cnt; // 0x10
	public int MJBKGOJBPAD_Type; // 0x14
	public int JJBGOIMEIPF_ItemFullId; // 0x18
	public EKLNMHFCAOI.FKGCBLHOOCL_Category NPPNDDMPFJJ_ItemCategory; // 0x1C
	public int NNFNGLJOKKF_ItemId; // 0x20
	public bool LHMOAJAIJCO_New; // 0x24
	public int MJBODMOLOBC_SceneLuck; // 0x28
	public int JPIPENJGGDD_SceneMlt; // 0x2C
	public int CJEOENICNOC; // 0x30
	public bool HMGCLKNLMAL; // 0x34
	public OOOOCFAFGCP KACECFNECON; // 0x38
	public bool JOPPFEHKNFO; // 0x3C
	public bool ILMMOGBDIME; // 0x3D
	public bool AIFBJHNBPMH; // 0x3E
	public bool MBFGLMEECOO; // 0x3F

	//// RVA: 0x1312448 Offset: 0x1312448 VA: 0x1312448
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		HAAJGNCFNJM_ItemName = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.HAAJGNCFNJM_item_name];
		OCNINMIMHGC_ItemFullId = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value];
		MBJIFDBEDAC_Cnt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count];
		MJBKGOJBPAD_Type = 0;
		if (IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type))
		{
			MJBKGOJBPAD_Type = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type];
		}
		MCDEKMIABEN();
	}

	//// RVA: 0x131311C Offset: 0x131311C VA: 0x131311C
	public void KHEKNNFCAOI(string OPFGFINHFCE, int NANNGLGOFKH, int HMFFHLPNMPH, int INDDJNMPONH = 0)
	{
		HAAJGNCFNJM_ItemName = OPFGFINHFCE;
		OCNINMIMHGC_ItemFullId = NANNGLGOFKH;
		MBJIFDBEDAC_Cnt = HMFFHLPNMPH;
		MJBKGOJBPAD_Type = INDDJNMPONH;
		MCDEKMIABEN();
	}

	//// RVA: 0x1313134 Offset: 0x1313134 VA: 0x1313134
	public void KHEKNNFCAOI(EKLNMHFCAOI.FKGCBLHOOCL_Category NPPNDDMPFJJ, int NANNGLGOFKH, int HMFFHLPNMPH)
	{
		MJBKGOJBPAD_Type = 0;
		switch (NPPNDDMPFJJ)
		{
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC:
				MJBKGOJBPAD_Type = 1;
				HAAJGNCFNJM_ItemName = "vc";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket:
				HAAJGNCFNJM_ItemName = "gacha_ticket";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
				HAAJGNCFNJM_ItemName = AFEHLCGHAEE_Strings.PJPGBPACBFA_uc_item;
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene:
				HAAJGNCFNJM_ItemName = AFEHLCGHAEE_Strings.COIODGJDJEJ_scene;
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume:
				HAAJGNCFNJM_ItemName = "costume";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie:
				HAAJGNCFNJM_ItemName = "valkyrie";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
				HAAJGNCFNJM_ItemName = AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item;
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
				HAAJGNCFNJM_ItemName = AFEHLCGHAEE_Strings.GJODJNIHKKF_epi_item;
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
				HAAJGNCFNJM_ItemName = "emblem";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem:
				HAAJGNCFNJM_ItemName = "event_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket:
				HAAJGNCFNJM_ItemName = "event_ticket";
				break;
			default:
				HAAJGNCFNJM_ItemName = "";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem:
				HAAJGNCFNJM_ItemName = "compo";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem:
				HAAJGNCFNJM_ItemName = "sns_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
				HAAJGNCFNJM_ItemName = "energy_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
				HAAJGNCFNJM_ItemName = "mv_ticket";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
				HAAJGNCFNJM_ItemName = "medal";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
				HAAJGNCFNJM_ItemName = "event_gacha_ticket";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
				HAAJGNCFNJM_ItemName = "present_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
				HAAJGNCFNJM_ItemName = "sp_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem:
				HAAJGNCFNJM_ItemName = "cos_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem:
				HAAJGNCFNJM_ItemName = "rareup_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem:
				HAAJGNCFNJM_ItemName = "limited_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem:
				HAAJGNCFNJM_ItemName = "monthly_pass";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
				HAAJGNCFNJM_ItemName = "deco_bg";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
				HAAJGNCFNJM_ItemName = "deco_obj";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
				HAAJGNCFNJM_ItemName = "deco_chara";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
				HAAJGNCFNJM_ItemName = "deco_serif";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
				HAAJGNCFNJM_ItemName = "deco_sp";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
				HAAJGNCFNJM_ItemName = "val_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
				HAAJGNCFNJM_ItemName = "deco_poster";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
				HAAJGNCFNJM_ItemName = "raid_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
				HAAJGNCFNJM_ItemName = "deco_set_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem:
				HAAJGNCFNJM_ItemName = "limited_compo_item";
				break;
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg:
				HAAJGNCFNJM_ItemName = "home_bg_item";
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
		if(MJBKGOJBPAD_Type == 2)
		{
			NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_None;
			NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_ItemFullId);
			JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
		}
		else
		{
			if(MJBKGOJBPAD_Type != 1)
			{
				if(OCNINMIMHGC_ItemFullId > 9999)
				{
					JJBGOIMEIPF_ItemFullId = OCNINMIMHGC_ItemFullId;
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(OCNINMIMHGC_ItemFullId);
					NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_ItemFullId);
					//LAB_013127c0
					KACECFNECON = null;
					return;
				}
				EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_None;
				if (HAAJGNCFNJM_ItemName.Contains(AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem;
				}
				else if(HAAJGNCFNJM_ItemName.Contains(AFEHLCGHAEE_Strings.COIODGJDJEJ_scene))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
				}
				else if (HAAJGNCFNJM_ItemName.Contains(AFEHLCGHAEE_Strings.PJPGBPACBFA_uc_item))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
				}
				else if (HAAJGNCFNJM_ItemName.Contains(AFEHLCGHAEE_Strings.ACGLMKEBMDL_uc))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("gacha_ticket"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("event_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains(AFEHLCGHAEE_Strings.GJODJNIHKKF_epi_item))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("costume"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("diva_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.JHGPNDLNPFA_DivaItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("emblem"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("valkyrie"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("compo"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("sns_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("energy_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("event_ticket"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("medal"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("mv_ticket"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("event_gacha_ticket"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("present_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("sp_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("cos_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("rareup_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("limited_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("monthly_pass"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("deco_bg"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("deco_obj"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("deco_chara"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("deco_serif"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("deco_sp"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("deco_poster"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("val_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("deco_set_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("raid_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("event_raid_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("limited_compo_item"))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem;
				}
				else if (HAAJGNCFNJM_ItemName.Contains("home_bg_item"))
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
	public string LJNAKDMILMC_Key; // 0x8
	public string LJGOOOMOMMA_Message; // 0xC
	public bool OOIJCMLEAJP_IsReceived; // 0x10
	public List<MFDJIFIIPJD> HBHMAKNGKFK; // 0x14
	public long KBFOIECIADN_OpenAt; // 0x18
	public long EGBOHDFBAPB_ClosedAt; // 0x20

	// RVA: 0xFF1614 Offset: 0xFF1614 VA: 0xFF1614
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		LJNAKDMILMC_Key = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.LJNAKDMILMC_key];
		LJGOOOMOMMA_Message = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.LJGOOOMOMMA_message];
		OOIJCMLEAJP_IsReceived = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OOIJCMLEAJP_is_received];
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains("current_period"))
		{
			KBFOIECIADN_OpenAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK["current_period"], AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at);
			EGBOHDFBAPB_ClosedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK["current_period"], AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at);
		}
		EDOHBJAPLPF_JsonData items = IDLHJIOMJBK[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items];
		HBHMAKNGKFK = new List<MFDJIFIIPJD>(items.HNBFOAJIIAL_Count);
		for(int i = 0; i < items.HNBFOAJIIAL_Count; i++)
		{
			MFDJIFIIPJD data = new MFDJIFIIPJD();
			data.KHEKNNFCAOI(items[i]);
			HBHMAKNGKFK.Add(data);
		}
	}
}

public class IGPDIKDNFKD
{
	public List<PNFCNPCGKDM> CEDLLCCONJP; // 0x8

	// RVA: 0x11F702C Offset: 0x11F702C VA: 0x11F702C
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		EDOHBJAPLPF_JsonData prizes = IDLHJIOMJBK[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes];
		CEDLLCCONJP = new List<PNFCNPCGKDM>();
		for(int i = 0; i < prizes.HNBFOAJIIAL_Count; i++)
		{
			PNFCNPCGKDM data = new PNFCNPCGKDM();
			data.KHEKNNFCAOI(prizes[i]);
			CEDLLCCONJP.Add(data);
		}
	}
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
		if (!KMOBDLBKAAA)
			EBGACDGNCAA_CallContext = SakashoAchievement.GetAchievementRecords(MIDAMHNABAJ.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
		else
			EBGACDGNCAA_CallContext = SakashoRepeatedAchievement.GetAchievementRecords(MIDAMHNABAJ.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xB1B510 Offset: 0xB1B510 VA: 0xB1B510 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new IGPDIKDNFKD();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		CIOECGOMILE.HHCJCDFCLOB.KPFKKDDOHCN.ECFNAOCFKKN_Date = 0;
		NKGJPJPHLIF.HHCJCDFCLOB.OLDKENOLHLL = 0;
	}
}
