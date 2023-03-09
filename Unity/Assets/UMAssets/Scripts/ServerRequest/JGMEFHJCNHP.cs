
using System.Collections.Generic;
using UnityEngine;

public class MFDJIFIIPJD
{
	public string HAAJGNCFNJM; // 0x8
	public int OCNINMIMHGC_ItemId; // 0xC
	public int MBJIFDBEDAC_Cnt; // 0x10
	public int MJBKGOJBPAD; // 0x14
	public int JJBGOIMEIPF; // 0x18
	public EKLNMHFCAOI.FKGCBLHOOCL_Category NPPNDDMPFJJ; // 0x1C
	public int NNFNGLJOKKF; // 0x20
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
		OCNINMIMHGC_ItemId = NANNGLGOFKH;
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
			NPPNDDMPFJJ = 0;
			NNFNGLJOKKF = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_ItemId);
		}
		!!!!
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
