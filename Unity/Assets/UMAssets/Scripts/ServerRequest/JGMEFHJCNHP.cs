
using System.Collections.Generic;
using UnityEngine;

public class MFDJIFIIPJD
{
	public string HAAJGNCFNJM_ItemName; // 0x8
	public int OCNINMIMHGC_item_value; // 0xC
	public int MBJIFDBEDAC_item_count; // 0x10
	public int MJBKGOJBPAD_item_type; // 0x14
	public int JJBGOIMEIPF_ItemId; // 0x18
	public EKLNMHFCAOI.FKGCBLHOOCL_Category NPPNDDMPFJJ_ItemCategory; // 0x1C
	public int NNFNGLJOKKF_ItemId; // 0x20
	public bool LHMOAJAIJCO_is_new; // 0x24
	public int MJBODMOLOBC_luck; // 0x28
	public int JPIPENJGGDD_NumBoard; // 0x2C SceneMlt
	public int CJEOENICNOC; // 0x30
	public bool HMGCLKNLMAL; // 0x34
	public OOOOCFAFGCP KACECFNECON_extra; // 0x38
	public bool JOPPFEHKNFO_Pickup; // 0x3C
	public bool ILMMOGBDIME; // 0x3D
	public bool AIFBJHNBPMH; // 0x3E
	public bool MBFGLMEECOO; // 0x3F

	//// RVA: 0x1312448 Offset: 0x1312448 VA: 0x1312448
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		HAAJGNCFNJM_ItemName = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.HAAJGNCFNJM_ItemName];
		OCNINMIMHGC_item_value = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value];
		MBJIFDBEDAC_item_count = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count];
		MJBKGOJBPAD_item_type = 0;
		if (_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type))
		{
			MJBKGOJBPAD_item_type = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type];
		}
		MCDEKMIABEN();
	}

	//// RVA: 0x131311C Offset: 0x131311C VA: 0x131311C
	public void KHEKNNFCAOI_Init(string _OPFGFINHFCE_name, int _NANNGLGOFKH_value, int _HMFFHLPNMPH_Count, int _INDDJNMPONH_type/* = 0*/)
	{
		HAAJGNCFNJM_ItemName = _OPFGFINHFCE_name;
		OCNINMIMHGC_item_value = _NANNGLGOFKH_value;
		MBJIFDBEDAC_item_count = _HMFFHLPNMPH_Count;
		MJBKGOJBPAD_item_type = _INDDJNMPONH_type;
		MCDEKMIABEN();
	}

	//// RVA: 0x1313134 Offset: 0x1313134 VA: 0x1313134
	public void KHEKNNFCAOI_Init(EKLNMHFCAOI.FKGCBLHOOCL_Category _NPPNDDMPFJJ_ItemCategory, int _NANNGLGOFKH_value, int _HMFFHLPNMPH_Count)
	{
		MJBKGOJBPAD_item_type = 0;
		switch (_NPPNDDMPFJJ_ItemCategory)
		{
			case EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC:
				MJBKGOJBPAD_item_type = 1;
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
				HAAJGNCFNJM_ItemName = AFEHLCGHAEE_Strings.GJODJNIHKKF_EpiItem;
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
		OCNINMIMHGC_item_value = _NANNGLGOFKH_value;
		MBJIFDBEDAC_item_count = _HMFFHLPNMPH_Count;
		MCDEKMIABEN();
	}

	//// RVA: 0x131358C Offset: 0x131358C VA: 0x131358C
	public void KHEKNNFCAOI_Init(int _JJBGOIMEIPF_ItemId, int _HMFFHLPNMPH_Count)
	{
		KHEKNNFCAOI_Init(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_JJBGOIMEIPF_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(_JJBGOIMEIPF_ItemId), _HMFFHLPNMPH_Count);
	}

	//// RVA: 0x13126B8 Offset: 0x13126B8 VA: 0x13126B8
	public void MCDEKMIABEN()
	{
		if(MJBKGOJBPAD_item_type == 2)
		{
			NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_0_None;
			NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_item_value);
			JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
		}
		else
		{
			if(MJBKGOJBPAD_item_type != 1)
			{
				if(OCNINMIMHGC_item_value > 9999)
				{
					JJBGOIMEIPF_ItemId = OCNINMIMHGC_item_value;
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(OCNINMIMHGC_item_value);
					NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_item_value);
					//LAB_013127c0
					KACECFNECON_extra = null;
					return;
				}
				EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_0_None;
				if (HAAJGNCFNJM_ItemName.Contains(AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem;
				}
				else if(HAAJGNCFNJM_ItemName.Contains(AFEHLCGHAEE_Strings.COIODGJDJEJ_scene))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
				}
				else if (HAAJGNCFNJM_ItemName == AFEHLCGHAEE_Strings.PJPGBPACBFA_uc_item)
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
				}
				else if (HAAJGNCFNJM_ItemName == AFEHLCGHAEE_Strings.ACGLMKEBMDL_Uc)
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
				}
				else if (HAAJGNCFNJM_ItemName == "gacha_ticket")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
				}
				else if (HAAJGNCFNJM_ItemName == "event_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem;
				}
				else if (HAAJGNCFNJM_ItemName == AFEHLCGHAEE_Strings.GJODJNIHKKF_EpiItem)
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem;
				}
				else if (HAAJGNCFNJM_ItemName == "costume")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume;
				}
				else if (HAAJGNCFNJM_ItemName == "diva_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.JHGPNDLNPFA_DivaItem;
				}
				else if (HAAJGNCFNJM_ItemName == "emblem")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem;
				}
				else if (HAAJGNCFNJM_ItemName == "valkyrie")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie;
				}
				else if (HAAJGNCFNJM_ItemName == "compo")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem;
				}
				else if (HAAJGNCFNJM_ItemName == "sns_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem;
				}
				else if (HAAJGNCFNJM_ItemName == "energy_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem;
				}
				else if (HAAJGNCFNJM_ItemName == "event_ticket")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket;
				}
				else if (HAAJGNCFNJM_ItemName == "medal")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal;
				}
				else if (HAAJGNCFNJM_ItemName == "mv_ticket")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket;
				}
				else if (HAAJGNCFNJM_ItemName == "event_gacha_ticket")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket;
				}
				else if (HAAJGNCFNJM_ItemName == "present_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem;
				}
				else if (HAAJGNCFNJM_ItemName == "sp_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem;
				}
				else if (HAAJGNCFNJM_ItemName == "cos_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem;
				}
				else if (HAAJGNCFNJM_ItemName == "rareup_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem;
				}
				else if (HAAJGNCFNJM_ItemName == "limited_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem;
				}
				else if (HAAJGNCFNJM_ItemName == "monthly_pass")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem;
				}
				else if (HAAJGNCFNJM_ItemName == "deco_bg")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg;
				}
				else if (HAAJGNCFNJM_ItemName == "deco_obj")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj;
				}
				else if (HAAJGNCFNJM_ItemName == "deco_chara")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara;
				}
				else if (HAAJGNCFNJM_ItemName == "deco_serif")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif;
				}
				else if (HAAJGNCFNJM_ItemName == "deco_sp")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp;
				}
				else if (HAAJGNCFNJM_ItemName == "deco_poster")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster;
				}
				else if (HAAJGNCFNJM_ItemName == "val_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem;
				}
				else if (HAAJGNCFNJM_ItemName == "deco_set_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem;
				}
				else if (HAAJGNCFNJM_ItemName == "raid_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem;
				}
				else if (HAAJGNCFNJM_ItemName == "event_raid_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem;
				}
				else if (HAAJGNCFNJM_ItemName == "limited_compo_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem;
				}
				else if (HAAJGNCFNJM_ItemName == "home_bg_item")
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg;
				}
				NPPNDDMPFJJ_ItemCategory = cat;
				NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_item_value);
				JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
				KACECFNECON_extra = null;
				return;
			}
			if((OCNINMIMHGC_item_value - 3001) < 999 && (OCNINMIMHGC_item_value - 3001) >= 0)
			{
				NNFNGLJOKKF_ItemId = OCNINMIMHGC_item_value - 3000;
				NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
				JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
			}
			else if ((OCNINMIMHGC_item_value - 2001) < 999 && (OCNINMIMHGC_item_value - 2001) >= 0)
			{
				if (!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH.Contains(OCNINMIMHGC_item_value))
				{
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
					NNFNGLJOKKF_ItemId = OCNINMIMHGC_item_value - 1996;
					JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
				}
				else
				{
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
					NNFNGLJOKKF_ItemId = OCNINMIMHGC_item_value - 2000;
					JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
				}
			}
			else
			{
				if(OCNINMIMHGC_item_value != 5001)
				{
					NNFNGLJOKKF_ItemId = 1;
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
					JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1);
					OCNINMIMHGC_item_value = 1;
					//LAB_013127c0
					KACECFNECON_extra = null;
					return;
				}
				NNFNGLJOKKF_ItemId = 9;
				NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
				JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
			}
		}
		//LAB_013127c0
		KACECFNECON_extra = null;
	}
}

public class PNFCNPCGKDM
{
	public string LJNAKDMILMC_key; // 0x8
	public string LJGOOOMOMMA_message; // 0xC
	public bool OOIJCMLEAJP_is_received; // 0x10
	public List<MFDJIFIIPJD> HBHMAKNGKFK_Items; // 0x14
	public long KBFOIECIADN_opened_at; // 0x18
	public long EGBOHDFBAPB_CloseAt; // 0x20

	// RVA: 0xFF1614 Offset: 0xFF1614 VA: 0xFF1614
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		LJNAKDMILMC_key = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.LJNAKDMILMC_key];
		LJGOOOMOMMA_message = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.LJGOOOMOMMA_message];
		OOIJCMLEAJP_is_received = (bool)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.OOIJCMLEAJP_is_received];
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("current_period"))
		{
			KBFOIECIADN_opened_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data["current_period"], AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at);
			EGBOHDFBAPB_CloseAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data["current_period"], AFEHLCGHAEE_Strings.EGBOHDFBAPB_CloseAt);
		}
		EDOHBJAPLPF_JsonData items = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.HBHMAKNGKFK_Items];
		HBHMAKNGKFK_Items = new List<MFDJIFIIPJD>(items.HNBFOAJIIAL_Count);
		for(int i = 0; i < items.HNBFOAJIIAL_Count; i++)
		{
			MFDJIFIIPJD data = new MFDJIFIIPJD();
			data.KHEKNNFCAOI_Init(items[i]);
			HBHMAKNGKFK_Items.Add(data);
		}
	}
}

public class IGPDIKDNFKD
{
	public List<PNFCNPCGKDM> CEDLLCCONJP_AchievementPrizes; // 0x8

	// RVA: 0x11F702C Offset: 0x11F702C VA: 0x11F702C
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		EDOHBJAPLPF_JsonData prizes = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.CEDLLCCONJP_AchievementPrizes];
		CEDLLCCONJP_AchievementPrizes = new List<PNFCNPCGKDM>();
		for(int i = 0; i < prizes.HNBFOAJIIAL_Count; i++)
		{
			PNFCNPCGKDM data = new PNFCNPCGKDM();
			data.KHEKNNFCAOI_Init(prizes[i]);
			CEDLLCCONJP_AchievementPrizes.Add(data);
		}
	}
}

[System.Obsolete("Use JGMEFHJCNHP_GetAchievementRecords", true)]
public class JGMEFHJCNHP { }
public class JGMEFHJCNHP_GetAchievementRecords : CACGCMBKHDI_Request
{
	public bool KMOBDLBKAAA_Repeatable; // 0x7C
	public List<string> MIDAMHNABAJ_Keys; // 0x80

	public IGPDIKDNFKD NFEAMMJIMPG_Result { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0xB1B3EC Offset: 0xB1B3EC VA: 0xB1B3EC Slot: 12
	public override void DHLDNIEELHO()
	{
		if (!KMOBDLBKAAA_Repeatable)
			EBGACDGNCAA_CallContext = SakashoAchievement.GetAchievementRecords(MIDAMHNABAJ_Keys.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
		else
			EBGACDGNCAA_CallContext = SakashoRepeatedAchievement.GetAchievementRecords(MIDAMHNABAJ_Keys.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xB1B510 Offset: 0xB1B510 VA: 0xB1B510 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new IGPDIKDNFKD();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		CIOECGOMILE.HHCJCDFCLOB.KPFKKDDOHCN.ECFNAOCFKKN_LastDate = 0;
		NKGJPJPHLIF.HHCJCDFCLOB.OLDKENOLHLL = 0;
	}
}
