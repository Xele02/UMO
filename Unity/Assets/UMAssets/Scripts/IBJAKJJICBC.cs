
using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

public class IBJAKJJICBC : EEDKAACNBBG_MusicData
{
	public enum AAADDDFCKLF
	{
		ALNCPFNNBLH_0 = 0,
		IANFNICOEFE_1 = 1,
		OGGMDNKPFEB_2 = 2,
	}

	public class GFKEJIHPAOM
	{
		public long KINJOEIAHFK_StartTime; // 0x8
		public long PCCFAKEOBIC_EndTime; // 0x10
		public long EMEKFFHCHMH_RewardEnd2; // 0x18
		public string OPFGFINHFCE_name; // 0x20
		public string KLMPFGOCBHC_description; // 0x24
		public int GOAPADIHAHG_EventId; // 0x28
		public OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType; // 0x2C

		// RVA: 0x12204C0 Offset: 0x12204C0 VA: 0x12204C0
		//public long KJILFMNCDLC() { }
	}
	
	public class DLLJPHLOICN : GFKEJIHPAOM
	{
		public int OOCBPMNHLPM_MusicId; // 0x30
	}

	[System.Obsolete("Use ANJLFFPBAEF_DifficultyInfo", true)]
	public class ANJLFFPBAEF { }
	public class ANJLFFPBAEF_DifficultyInfo
	{
		private const int FBGGEFFJJHB_xor = 0x7daf3c5a;
		public int NLBLLLLBHOP_StatusCrypted = FBGGEFFJJHB_xor; // 0x8
		public int NBOLDNMPJFG_scoreCrypted = FBGGEFFJJHB_xor; // 0xC
		public int BCKCCHGMPBG_Crypted = FBGGEFFJJHB_xor; // 0x10
		public int COGALGDHDFE_ClearCrypted = FBGGEFFJJHB_xor; // 0x14
		public int FCOIEGJFOJI_Crypted = FBGGEFFJJHB_xor; // 0x18
		public int FDOFFBKDJKC_Crypted = FBGGEFFJJHB_xor; // 0x1C
		public int LOIHMDIJJOP_ComboRankCrypted = FBGGEFFJJHB_xor; // 0x20
		public int EINNKFIEIHJ_Crypted = FBGGEFFJJHB_xor; // 0x24
		public KLBKPANJCPL_Score HHMLMKAEJBJ_Score; // 0x28
		public ADDHLABEFKH BAKLKJLPLOJ_MusicLevel; // 0x2C
		public EJKBKMBJMGL_EnemyData HPBPDHPIBGN_enemy; // 0x30

		public int CMCKNKKCNDK_status { get { return NLBLLLLBHOP_StatusCrypted ^ FBGGEFFJJHB_xor; } set { NLBLLLLBHOP_StatusCrypted = value ^ FBGGEFFJJHB_xor; } } //0x12203C0 CNKGOPKANGF 0x1215B00 CHJGGLFGALP
		public int KNIFCANOHOC_score { get { return NBOLDNMPJFG_scoreCrypted ^ FBGGEFFJJHB_xor; } set { NBOLDNMPJFG_scoreCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1214AC0 EOJEPLIPOMJ 0x1215AB0 AEEMBPAEAAI
		public int NLKEBAOBJCM_combo { get { return BCKCCHGMPBG_Crypted ^ FBGGEFFJJHB_xor; } set { BCKCCHGMPBG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x12203D4 AECNKGBNKHH 0x1215AC4 ECHLKFHOJFP
		public int JNLKJCDFFMM_clear { get { return COGALGDHDFE_ClearCrypted ^ FBGGEFFJJHB_xor; } set { COGALGDHDFE_ClearCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1215B14 JLGNODHICKN 0x1215AD8 DLEGLBAGJOI
		public int EMHFDJEFIHG_play { get { return FCOIEGJFOJI_Crypted ^ FBGGEFFJJHB_xor; } set { FCOIEGJFOJI_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x12176A4 OBFCFPIDKGB 0x1217690 MJHGLINGBGJ
		public int BPLOEAHOPFI_stamina { get { return FDOFFBKDJKC_Crypted ^ FBGGEFFJJHB_xor; } set { FDOFFBKDJKC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x12203E8 IFLOIFCLBFJ 0x1215B28 NGMKCJOPEGH
		public int LCOHGOIDMDF_ComboRank { get { return LOIHMDIJJOP_ComboRankCrypted ^ FBGGEFFJJHB_xor; } set { LOIHMDIJJOP_ComboRankCrypted = value ^ FBGGEFFJJHB_xor; } } //0x12203FC LNDHFDDHOJP 0x1215AEC IMNCJLKPOAJ
		public int PPDPGKHKCNB { get { return EINNKFIEIHJ_Crypted ^ FBGGEFFJJHB_xor; } set { EINNKFIEIHJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1220410 BHNHLDKJLNJ 0x121C6A8 FLGAJBJBIII
		public int CIEOBFIIPLD_Level { get { return HHMLMKAEJBJ_Score.ANAJIAENLNB_lv; } } //0x1220424 OGKGFGMKPKB
		public bool POOMOBGPCNE_IsLocked { get { return CMCKNKKCNDK_status == 0; } } //0x1220450 PJPHEDJHLOO
		public bool CADENLBDAEB_IsNew { get { return CMCKNKKCNDK_status == 1; } } //0x122046C KJGFPPLHLAB
		public bool CHBNEEIIDDI_IsPlayed { get { return CMCKNKKCNDK_status == 2; } }// 0x1220488 PIGGFFEOODB
		public bool BCGLDMKODLC_IsClear { get { return CMCKNKKCNDK_status == 3; } } //0x12204A4 NNGALFPBDNA
	}


	private const int FBGGEFFJJHB_xor = 0x7daf3c5a;
	private const sbyte JFOFMKBJBBE_False = 19;
	private const sbyte CNECJGKECHK_True = 87;
	private int EPGOIGPKPPJ_FreeMusicIdCrypted = FBGGEFFJJHB_xor; // 0x40
	private int HNEHIJCAOJM_CategoryIdCrypted = FBGGEFFJJHB_xor; // 0x44
	private sbyte ACKPOCNHOOP_IsNewCrypted = JFOFMKBJBBE_False; // 0x48
	private sbyte IFLNGLECALJ_Crypted = JFOFMKBJBBE_False; // 0x49
	private sbyte MEPLEIEDBGE_UlNewCrypted = JFOFMKBJBBE_False; // 0x4A
	private int EGCMPELNLKP_EventIdCrypted = FBGGEFFJJHB_xor; // 0x4C
	private int CEMGANMAOML_GameEventTypeCrypted = FBGGEFFJJHB_xor; // 0x50
	private int NENONMAGGBP_OpenEventCrypted = FBGGEFFJJHB_xor; // 0x54
	private int MJLNDHPNFHE_PlayEventCrypted = FBGGEFFJJHB_xor; // 0x58
	private int PPDEOMLMEKC_Crypted = FBGGEFFJJHB_xor; // 0x5C
	private sbyte IKGGKOFGMNC_Crypted; // 0x60
	private sbyte CICKCGDKICN_Crypted = JFOFMKBJBBE_False; // 0x61
	public BKKMNPEEILG DACLONHOFLA; // 0x64
	private int KAEIHNCACOD_Crypted = FBGGEFFJJHB_xor; // 0x68
	private sbyte MPDBHMLFLLA_Crypted = JFOFMKBJBBE_False; // 0x6C
	private sbyte JMFIOFIBLFH_Crypted = JFOFMKBJBBE_False; // 0x6D
	public WeekdayEventAttr.Type IHKFMJDOBAH_WeekDayAttr; // 0x70
	private sbyte CHOLAKGHAEN_IsWeelkyEventCrypted = JFOFMKBJBBE_False; // 0x74
	private long PMEGFLFDDKH_WeeklyEndTimeCrypted = FBGGEFFJJHB_xor; // 0x78
	private sbyte NKKAIPDPEEI_HasBoostCrypted = JFOFMKBJBBE_False; // 0x80
	private sbyte AJGIBNAJPJD_Crypted = JFOFMKBJBBE_False; // 0x81
	private int AFDHDBMKLJL_CdSelectEvenTypeCrypted = FBGGEFFJJHB_xor; // 0x84
	private int KOOODCKJNJO_Crypted = FBGGEFFJJHB_xor; // 0x88
	private int NEBJMHHHDMO_Crypted = FBGGEFFJJHB_xor; // 0x8C
	private int PDLMMOJDBKM_Crypted = FBGGEFFJJHB_xor; // 0x90
	private int[] LHENMNBDFNM_WeeklyItem; // 0x94
	private string MJEPJCDOAML; // 0x98
	public IBJAKJJICBC.GFKEJIHPAOM AFCMIOIGAJN_EventInfo; // 0x9C
	public int LOFKFOCAJGB_TicketItemIdCrypted = FBGGEFFJJHB_xor; // 0xA0
	public int DANJGFKGLNN_EventBonusPercentCrypted = FBGGEFFJJHB_xor; // 0xA4
	public IBJAKJJICBC.DLLJPHLOICN NOKBLCDMLPP_MinigameEventInfo; // 0xA8
	public sbyte FBMAAGJAGGG_Crypted = JFOFMKBJBBE_False; // 0xAC
	public sbyte OFFDABPBFBA_Crypted = JFOFMKBJBBE_False; // 0xAD
	public sbyte POKBBJHFNPI_Crypted = JFOFMKBJBBE_False; // 0xAE
	public sbyte LKBOJPIFOFK_Crypted = JFOFMKBJBBE_False; // 0xAF
	public sbyte BCEHBCFLHNL_Crypted = JFOFMKBJBBE_False; // 0xB0
	public sbyte PHKCAIAKPLG_Crypted = JFOFMKBJBBE_False; // 0xB1
	public long APCJGOEEBEB_OtherEndTimeCrypted = FBGGEFFJJHB_xor; // 0xB8
	public sbyte FEBKEKCEODK_Crypted = JFOFMKBJBBE_False; // 0xC0
	private int GNIHKFDDCOO_Crypted = FBGGEFFJJHB_xor; // 0xC4
	public bool GBNOALJPOBM_IsLine6; // 0xC8
	public long NJDCMCDEAPK_Crypted; // 0xD0

	public int GHBPLHBNMBK_FreeMusicId { get { return EPGOIGPKPPJ_FreeMusicIdCrypted ^ FBGGEFFJJHB_xor; } set { EPGOIGPKPPJ_FreeMusicIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1213164 HKFCFPFPMBN 0x1213178 IFMPBFAAKNN
	public int DEPGBBJMFED_CategoryId { get { return HNEHIJCAOJM_CategoryIdCrypted ^ FBGGEFFJJHB_xor; } set { HNEHIJCAOJM_CategoryIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x121318C FNMFOBJIIIC 0x12131A0 OBEDPJLBBEG
	public bool CADENLBDAEB_IsNew { get { return ACKPOCNHOOP_IsNewCrypted == CNECJGKECHK_True; } set { ACKPOCNHOOP_IsNewCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12131B4 KJGFPPLHLAB 0x12131C8 ILJHLPMDHPO
	public bool LDGOHPAPBMM_IsNew { get { return IFLNGLECALJ_Crypted == CNECJGKECHK_True; } set { IFLNGLECALJ_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12131F8 GEBJMDIJNAH 0x121320C JBMMFDLGCMC
	public bool CPBDGAGKNGH_UlNew { get { return MEPLEIEDBGE_UlNewCrypted == CNECJGKECHK_True; } set { MEPLEIEDBGE_UlNewCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x121323C KJLPFJJHJPE 0x1213250 CLALHMCBPNF
	public int EKANGPODCEP_EventId { get { return EGCMPELNLKP_EventIdCrypted ^ FBGGEFFJJHB_xor; } set { EGCMPELNLKP_EventIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1213280 EBLAFEMDFGD 0x1213294 AHEFELNFBDM
	public int MNNHHJBBICA_GameEventType { get { return CEMGANMAOML_GameEventTypeCrypted ^ FBGGEFFJJHB_xor; } set { CEMGANMAOML_GameEventTypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x12132A8 FNEIPFMLBCB 0x12132BC IFKDECJEKGJ
	public int MFJKNCACBDG_OpenEventType { get { return NENONMAGGBP_OpenEventCrypted ^ FBGGEFFJJHB_xor; } set { NENONMAGGBP_OpenEventCrypted = value ^ FBGGEFFJJHB_xor; } } //0x12132D0 HLAFCPHCBED 0x12132E4 FMLMCHDKIPP
	public int OEILJHENAHN_PlayEventType { get { return MJLNDHPNFHE_PlayEventCrypted ^ FBGGEFFJJHB_xor; } set { MJLNDHPNFHE_PlayEventCrypted = value ^ FBGGEFFJJHB_xor; } } //0x12132F8 MGJDCGJMEKP 0x121330C IMJDLLMCMAH
	public int EEFLOOBOAGF_ViewOrder { get { return PPDEOMLMEKC_Crypted ^ FBGGEFFJJHB_xor; } set { PPDEOMLMEKC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1213320 NLDELFLNODF 0x1213334 PEHLMNDKOEE
	public bool BJANNALFGGA_HasRanking { get { return IKGGKOFGMNC_Crypted == CNECJGKECHK_True; } set { IKGGKOFGMNC_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1213348 EPFAPPFDMJH 0x121335C AFBCHDAJIFL
	public bool OGHOPBAKEFE_IsEventSpecial { get { return CICKCGDKICN_Crypted == CNECJGKECHK_True; } set { CICKCGDKICN_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x121338C LNICBELKODE 0x12133A0 MMOFHBDNIFJ  CICKCGDKICN_Crypted
	public int OPPBIOEJAND_EventMusicRank { get { return KAEIHNCACOD_Crypted ^ FBGGEFFJJHB_xor; } set { KAEIHNCACOD_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x12133D0 LPGPACOAGAM 0x12133E4 DFGJNJCLJKO
	public bool JOJPMFNJJPD_HasEventMusicRank { get { return MPDBHMLFLLA_Crypted == CNECJGKECHK_True; } set { MPDBHMLFLLA_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12133F8 MPMFLBPLMMN 0x121340C JDJIDAOAIB
	public bool JPOINGMJCGL { get { return JMFIOFIBLFH_Crypted == CNECJGKECHK_True; } set { JMFIOFIBLFH_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x121343C OOCNOAFIHIB 0x1213450 KKKFHLFKFCG   JMFIOFIBLFH_Crypted
	public bool LHONOILACFL_IsWeeklyEvent { get { return CHOLAKGHAEN_IsWeelkyEventCrypted == CNECJGKECHK_True; } set { CHOLAKGHAEN_IsWeelkyEventCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1213480 PGKDJOCOJMK 0x1213494 JLOKCBHGIPA
	public long NKEIFPPGNLH_WeeklyendTime { get { return PMEGFLFDDKH_WeeklyEndTimeCrypted ^ FBGGEFFJJHB_xor; } set { PMEGFLFDDKH_WeeklyEndTimeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x12134C4 GALMKGNOFDH 0x12134D8 AABJDLOOPOC
	public bool GDLNCHCPMCK_HasBoost { get { return NKKAIPDPEEI_HasBoostCrypted == CNECJGKECHK_True; } set { NKKAIPDPEEI_HasBoostCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12134F4 MGDNBNEHFAJ 0x1213508 CHLKHPGCIPB
	public bool NNJNNCGGKMC_IsLimited { get { return AJGIBNAJPJD_Crypted == CNECJGKECHK_True; } set { AJGIBNAJPJD_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1213538 IEIACJPPDOH 0x121354C APJCBPNGEHO
	public int KCKBOIDCPCK_CdSelectEvenType { get { return AFDHDBMKLJL_CdSelectEvenTypeCrypted ^ FBGGEFFJJHB_xor; } set { AFDHDBMKLJL_CdSelectEvenTypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x121357C LIKAGINKECG 0x1213590 DDLKEDBBGCB
	public int JJEFMIHJMHC_CursorStepCount { get { return KOOODCKJNJO_Crypted ^ FBGGEFFJJHB_xor; } set { KOOODCKJNJO_Crypted = value ^ FBGGEFFJJHB_xor;} } //0x12135A4 BAPFJJJLHCC 0x12135B8 OGMOOIOKJHG
	public int BELHFPMBAPJ_WeekPlay { get { return NEBJMHHHDMO_Crypted ^ FBGGEFFJJHB_xor; } set { NEBJMHHHDMO_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x12136F4 HJBNBOJBKPO 0x1213708 LJLMDPIGCFJ
	public int JOJNGDPHOKG_WeeklyMax { get { return PDLMMOJDBKM_Crypted ^ FBGGEFFJJHB_xor; } set { PDLMMOJDBKM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x121371C MBDGLMBPBEJ 0x1213730 JLIOGCHPNFJ
	public int MOJMEFIENDM_WeeklyEventCount { get { return (JOJNGDPHOKG_WeeklyMax) - (BELHFPMBAPJ_WeekPlay); } } //0x1213744 PBNIFHCLKNA
	public bool AJGCPCMLGKO_IsEvent { get { return AFCMIOIGAJN_EventInfo != null; } } //0x12141A8 LFBNCKMILGK
	public bool MNDFBBMNJGN_IsUsingTicket { get { return LOFKFOCAJGB_TicketItemIdCrypted != FBGGEFFJJHB_xor; } } //0x12141B8 KLMOKPHBBOC  LOFKFOCAJGB_TicketItemIdCrypted
	public int JKIADEKHGLC_TicketItemId { get { return LOFKFOCAJGB_TicketItemIdCrypted ^ FBGGEFFJJHB_xor; } set { LOFKFOCAJGB_TicketItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x12141D4 OMELGCEEHKD 0x12141E8 EJEGDHIDAHL  LOFKFOCAJGB_TicketItemIdCrypted
	public int DBJOBFIGGEE_EventBonusPercent { get { return DANJGFKGLNN_EventBonusPercentCrypted ^ FBGGEFFJJHB_xor; } set { DANJGFKGLNN_EventBonusPercentCrypted = value ^ FBGGEFFJJHB_xor; } } //0x12141FC OCAMIMMBCLG 0x1214210 EGDEICLAEBO   DANJGFKGLNN_EventBonusPercentCrypted
	public bool BNIAJAKIAJC_IsEventMinigame { get { return NOKBLCDMLPP_MinigameEventInfo != null; } } //0x1214224 ENAOGJDBGHC
	public bool KDAJEGNBOFJ { get {
			if (NOKBLCDMLPP_MinigameEventInfo != null)
				return true;
			return AFCMIOIGAJN_EventInfo != null;
		} } //0x1214234 HIODBIOCMAI
	public bool POEGGBGOKGI_IsInfoLiveEntrance { get { return FBMAAGJAGGG_Crypted == CNECJGKECHK_True; } set { FBMAAGJAGGG_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1214258 KODGDIIMPII 0x121426C GHDOJNEEOKO
	public bool PJLNJJIBFBN_HasExtremeDiff { get { return OFFDABPBFBA_Crypted == CNECJGKECHK_True; } set { OFFDABPBFBA_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x121429C GMGBFOAAHDD 0x12142B0 GHLFABPOFJK
	public bool LEBDMNIGOJB_IsScoreEvent { get { return POKBBJHFNPI_Crypted == CNECJGKECHK_True; } set { POKBBJHFNPI_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12142E0 HBEONMDJOOP 0x12142F4 FDGKGCJHPDA
	public bool HDPMAJKGIOI { get { return LKBOJPIFOFK_Crypted == CNECJGKECHK_True; } set { LKBOJPIFOFK_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1214324 CPGNHCPOKOB 0x1214338 AKHMGHGILEL   LKBOJPIFOFK_Crypted
	public bool LGIGMPBHJCI { get { return BCEHBCFLHNL_Crypted == CNECJGKECHK_True; } set { BCEHBCFLHNL_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1214368 EOAGNJADCPB 0x121437C NAEDALBFMPK   BCEHBCFLHNL_Crypted
	public bool FGKMJHKLGLD { get { return PHKCAIAKPLG_Crypted == CNECJGKECHK_True; } set { PHKCAIAKPLG_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12143AC IEPMIAMGFIJ 0x12143C0 GAAOGMPFCFN
	public long ALMOMLMCHNA_OtherEndTime { get { return APCJGOEEBEB_OtherEndTimeCrypted ^ FBGGEFFJJHB_xor; } set { APCJGOEEBEB_OtherEndTimeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x12143F0 BHKAHGNFCEN 0x1214404 LOJIKNJAGIO
	public bool EHNGOGBJMGL { get { return FEBKEKCEODK_Crypted == CNECJGKECHK_True; } set { FEBKEKCEODK_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1214550 FDIMEFOAOAP 0x1214564 HCNELALHKNN
	private int AAODIMMEFBI { get { return GNIHKFDDCOO_Crypted ^ FBGGEFFJJHB_xor; } set { GNIHKFDDCOO_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1214594 IHMBMOACINF 0x12145A8 OJLEJOKHKFP
	public long IHPCKOMBGKJ_End { get { return NJDCMCDEAPK_Crypted ^ FBGGEFFJJHB_xor; } set { NJDCMCDEAPK_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x12145FC KMCBIJLEDNH 0x1214610 GCEGLPAGDGI
	public List<ANJLFFPBAEF_DifficultyInfo> MGJKEJHEBPO_Blocks { get; set; } // 0xD8 DPHOPMPKAHK BNPJIIPJJLJ HOKDNOFCDHM DiffInfos

	// // RVA: 0x12135CC Offset: 0x12135CC VA: 0x12135CC
	// public int NOEIIMGDDKK() { }

	// // RVA: 0x1213764 Offset: 0x1213764 VA: 0x1213764
	public void IEBGBOBPJMB(int NGDGGPCLPKC)
	{
		BELHFPMBAPJ_WeekPlay = Mathf.Clamp(BELHFPMBAPJ_WeekPlay - NGDGGPCLPKC, 0, JOJNGDPHOKG_WeeklyMax);
	}

	// // RVA: 0x1213814 Offset: 0x1213814 VA: 0x1213814
	public int ICHJBDPJNMA_GetWeeklyItem(WeekdayEventAttr.Type _INDDJNMPONH_type, int _IKPIDCFOFEA_no)
	{
		if(_INDDJNMPONH_type != 0 && LHENMNBDFNM_WeeklyItem != null)
		{
			return LHENMNBDFNM_WeeklyItem[_IKPIDCFOFEA_no];
		}
		return 0;
	}

	// // RVA: 0x1213860 Offset: 0x1213860 VA: 0x1213860
	public int LMPNAPIGAEA(WeekdayEventAttr.Type _INDDJNMPONH_type)
	{
		if (_INDDJNMPONH_type == WeekdayEventAttr.Type.None || ICHJBDPJNMA_GetWeeklyItem(_INDDJNMPONH_type, 2) == 0)
			return 0;
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(ICHJBDPJNMA_GetWeeklyItem(_INDDJNMPONH_type, 2));
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
		{
			return OHCAABOMEOF.LDGFHMMAFOC(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENMHPBGOOII_Week, 6);
		}
		else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
		{
			int a = 1;
			int a2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NKDGLGCAPEI_GrowItem.CDENCMNHNGA_table[EKLNMHFCAOI.DEACAHNLMNI_getItemId(ICHJBDPJNMA_GetWeeklyItem(_INDDJNMPONH_type, 2)) - 1].INDDJNMPONH_type;
			if (a2 >= 2 && a2 < 6)
				a = new int[4] { 4, 3, 5, 2 }[a2 - 2];
			return OHCAABOMEOF.LDGFHMMAFOC(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENMHPBGOOII_Week, a);
		}
		return 0;
	}

	// // RVA: 0x1213A74 Offset: 0x1213A74 VA: 0x1213A74
	public string CIOCOOMCMKO(WeekdayEventAttr.Type _INDDJNMPONH_type)
	{
		int a = LMPNAPIGAEA(_INDDJNMPONH_type);
		if (a >= 5001 && a < 5007)
		{
			return MJEPJCDOAML + "_rule_" + (a % 5000);
		}
		return null;
	}

	// // RVA: 0x1213B4C Offset: 0x1213B4C VA: 0x1213B4C
	private void KDPFCMAALPO(int _GHBPLHBNMBK_FreeMusicId, bool _GIKLNODJKFK_IsLine6)
	{
		LHENMNBDFNM_WeeklyItem = new int[3];
		KEODKEGFDLD_FreeMusicInfo fminfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(_GHBPLHBNMBK_FreeMusicId);
		int a1 = fminfo.ONLFLGPMAAN_GetRareRateId(_GIKLNODJKFK_IsLine6);
		OPGDJANLKBM_RateInfo rarerate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.ABNFGCEDJIM_RareRate.Find((OPGDJANLKBM_RateInfo _GHPLINIACBB_x) =>
		{
			//0x122023C
			return _GHPLINIACBB_x.BFOLFCOBBJD_RateId == a1;
		});
		HNJKJCDDIMG_SetInfo rareset = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.LMILCGIFPGC_RareSet.Find((HNJKJCDDIMG_SetInfo _GHPLINIACBB_x) =>
		{
			//0x1220274
			return _GHPLINIACBB_x.LIHEBNPAIFI_SId == fminfo.JCDKMICANJO_RareSetId;
		});
		HNJKJCDDIMG_SetInfo set = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.KPEOJPKLJBH_Set.Find((HNJKJCDDIMG_SetInfo _GHPLINIACBB_x) =>
		{
			//0x12202D8
			return _GHPLINIACBB_x.LIHEBNPAIFI_SId == fminfo.MGLDIOILOFF_NormalSetId;
		});
		int a2 = fminfo.KDIKCKEEPDA_GetNormalRateId(_GIKLNODJKFK_IsLine6);
		OPGDJANLKBM_RateInfo rate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.FDCBLEDPHBM_Rate.Find((OPGDJANLKBM_RateInfo _GHPLINIACBB_x) =>
		{
			//0x122033C
			return _GHPLINIACBB_x.BFOLFCOBBJD_RateId == a2;
		});
		if(set == null || rate == null)
		{
			LHENMNBDFNM_WeeklyItem[0] = 0;
		}
		else
		{
			int a3 = 0;
			for(int i = 0; i < set.KAINPNMMAEK_GetItemsCount(); i++)
			{
				if(rate.ADKDHKMPMHP_rate[i] > 0)
				{
					if(rate.HMFFHLPNMPH_count[i] > 0)
					{
						int setId = set.FKNBLDPIPMC_GetItemId(i);
						if(((int)EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(setId) | 4) == 7)
						{
							if(a3 < LHENMNBDFNM_WeeklyItem.Length)
							{
								LHENMNBDFNM_WeeklyItem[a3] = setId;
								UnityEngine.Debug.LogError("Added item "+setId);
								a3++;
							}
						}
					}
				}
			}
		}
	}

	// RVA: 0x1214420 Offset: 0x1214420 VA: 0x1214420
	public long AHAEGEHKONB_GetOtherTimeLeft()
	{
		if(ALMOMLMCHNA_OtherEndTime != 0)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if ((ALMOMLMCHNA_OtherEndTime - time) != 0)
				return ALMOMLMCHNA_OtherEndTime - time;
		}
		return -1;
	}

	// // RVA: 0x12145BC Offset: 0x12145BC VA: 0x12145BC
	// public void OFAPIHAJDOH(int _GHBPLHBNMBK_FreeMusicId) { }

	// // RVA: 0x12145E8 Offset: 0x12145E8 VA: 0x12145E8
	public int AKAPOCOIECA_GetMusicRatio()
	{
		return AAODIMMEFBI;
	}

	// // RVA: 0x121462C Offset: 0x121462C VA: 0x121462C
	// public int FOHHGKEJMEL() { }

	// // RVA: 0x1214760 Offset: 0x1214760 VA: 0x1214760 Slot: 5
	public override bool DBIGDCOHOIC_IsMultiDanceUnlocked()
	{
		if ((!OGHOPBAKEFE_IsEventSpecial || MNNHHJBBICA_GameEventType - 1 > 10 || (1061 >> (((MNNHHJBBICA_GameEventType - 1) & 0xff) & 1) == 0)) && !JPOINGMJCGL)
			return base.DBIGDCOHOIC_IsMultiDanceUnlocked();
		return true;
	}

	// // RVA: 0x12147B8 Offset: 0x12147B8 VA: 0x12147B8
	public bool ICKDCAMABPD(int OGPKGGLJACK)
	{
		if(HAMPEDFMIAD_HasOnlyMultiDivaMode())
		{
			if(DBIGDCOHOIC_IsMultiDanceUnlocked())
			{
				return IOMLIADJJLD(false) < OGPKGGLJACK;
			}
		}
		else
			return true;
		return false;
	}

	// // RVA: 0x1214824 Offset: 0x1214824 VA: 0x1214824
	public bool PNKKJEABNFF(IBJAKJJICBC.AAADDDFCKLF IKENKJKOGNN)
	{
		// Will need to check tests
		bool res = DBIGDCOHOIC_IsMultiDanceUnlocked();
		if(HAMPEDFMIAD_HasOnlyMultiDivaMode())
		{
			if(((int)IKENKJKOGNN - 1) > 1)
			{
				if (IKENKJKOGNN != 0)
					return false;
				return true;
			}
		}
		else
		{
			if (KLOGLLFOAPL_HasMultiDivaMode())
			{
				res = true;
				if (((int)IKENKJKOGNN - 1) > 1)
				{
					if (IKENKJKOGNN != 0)
						return false;
					return DBIGDCOHOIC_IsMultiDanceUnlocked();
				}
			}
			else
			{
				res = false;
				if ((int)IKENKJKOGNN < 3)
					res = ((6 >> ((int)IKENKJKOGNN & 7)) & 1) != 0;
			}
		}
		return res;
	}

	// // RVA: 0x12148D4 Offset: 0x12148D4 VA: 0x12148D4
	public bool JHLDFOLFNGB(Difficulty.Type _AKNELONELJK_difficulty, bool NGKGFBLFEGH)
	{
		bool res = false;
		if((int)_AKNELONELJK_difficulty < MGJKEJHEBPO_Blocks.Count)
		{
			int score = MGJKEJHEBPO_Blocks[(int)_AKNELONELJK_difficulty].KNIFCANOHOC_score;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId).EMJCHPDJHEI(NGKGFBLFEGH, (int)_AKNELONELJK_difficulty).DLPBHJALHCK_GetScoreRank(score) == 4)
				return true;
		}
		return res;
	}

	// // RVA: 0x1214AE0 Offset: 0x1214AE0 VA: 0x1214AE0
	public void KHEKNNFCAOI_Init(int _GHBPLHBNMBK_FreeMusicId, bool HCIKDFECJGE/* = false*/, int NLKONOBBDJK/* = 0*/, int IOFOHHOJCBE/* = 0*/, long _JHNMKKNEENE_Time/* = 0*/, bool _PJLNJJIBFBN_HasExtremeDiff/* = false*/, bool LICNKMNIKBF/* = false*/, bool _GIKLNODJKFK_IsLine6/* = false*/)
	{
		GHBPLHBNMBK_FreeMusicId = _GHBPLHBNMBK_FreeMusicId;
		KEODKEGFDLD_FreeMusicInfo musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData[_GHBPLHBNMBK_FreeMusicId - 1];
		base.KHEKNNFCAOI_Init(musicInfo.DLAEJOBELBH_MusicId);
		EONOEHOKBEB_Music musicInfo2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[musicInfo.DLAEJOBELBH_MusicId - 1];
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo saveInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[_GHBPLHBNMBK_FreeMusicId - 1];
		DEPGBBJMFED_CategoryId = musicInfo.DEPGBBJMFED_CategoryId;
		EKANGPODCEP_EventId = 0;
		this.PJLNJJIBFBN_HasExtremeDiff = _PJLNJJIBFBN_HasExtremeDiff;
		if(!HCIKDFECJGE)
		{
			NKEIFPPGNLH_WeeklyendTime = 0;
			IHKFMJDOBAH_WeekDayAttr = WeekdayEventAttr.Type.None;
			LHONOILACFL_IsWeeklyEvent = false;
			BELHFPMBAPJ_WeekPlay = 0;
			JOJNGDPHOKG_WeeklyMax = 0;
			BJANNALFGGA_HasRanking = true;
		}
		else
		{
			KDPFCMAALPO(_GHBPLHBNMBK_FreeMusicId, _GIKLNODJKFK_IsLine6);
			IHKFMJDOBAH_WeekDayAttr = (WeekdayEventAttr.Type)(NLKONOBBDJK + 1);
			LHONOILACFL_IsWeeklyEvent = true;
			MJEPJCDOAML = "";
			DKCJADHKGAN_EventWeekDay.JFFPEKOEINE weekData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CLLPBOPLICM_EventWeekDay.PPIBJECKCEF(_JHNMKKNEENE_Time);
			if (weekData != null)
			{
				MJEPJCDOAML = weekData.CIOJJBOHEEJ;
			}
			DateTime date = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
			NKEIFPPGNLH_WeeklyendTime = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0) + 86400;
			BELHFPMBAPJ_WeekPlay = saveInfo.FECIGAOOFBE_Wply;
			JOJNGDPHOKG_WeeklyMax = IOFOHHOJCBE;
			EKANGPODCEP_EventId = LMPNAPIGAEA(IHKFMJDOBAH_WeekDayAttr);
		}
		EEFLOOBOAGF_ViewOrder = musicInfo.EEFLOOBOAGF_ViewOrder;
		LDGOHPAPBMM_IsNew = true;
		MGJKEJHEBPO_Blocks = new List<ANJLFFPBAEF_DifficultyInfo>();
		int count = _PJLNJJIBFBN_HasExtremeDiff ? 5 : 4;
		// if false weird L248, looks like do nothing
		// weird loop too here // L269
		bool hasValue2 = musicInfo.GBNOALJPOBM_IsLine6;
		bool hasValue = true;
		for (int i = 0; i < count; i++)
		{
			ANJLFFPBAEF_DifficultyInfo info = new ANJLFFPBAEF_DifficultyInfo();
			info.HPBPDHPIBGN_enemy = new EJKBKMBJMGL_EnemyData();
			int val = 0;
			if(!_GIKLNODJKFK_IsLine6)
			{
				info.KNIFCANOHOC_score = saveInfo.BDCAICINCKK_GetScoreForDiff(i);
				info.NLKEBAOBJCM_combo = saveInfo.NLKEBAOBJCM_combo[i];
				info.JNLKJCDFFMM_clear = saveInfo.JNLKJCDFFMM_clear[i];
				info.LCOHGOIDMDF_ComboRank = saveInfo.LAMCCNAKIOJ_ComboRank[i];
				info.HPBPDHPIBGN_enemy.KHEKNNFCAOI_Init(musicInfo.LHICAKGHIGF_EnemyIdByDiff[i], musicInfo.LJPKLMJPLAC_DIn[i]);
				val = saveInfo.EMHFDJEFIHG_play[i];
			}
			else
			{
				info.KNIFCANOHOC_score = saveInfo.AHDKMPFDKPE_GetScoreL6_ForDiff(i);
				info.NLKEBAOBJCM_combo = saveInfo.DNIGPFPHJAK_ComboL6[i];
				info.JNLKJCDFFMM_clear = saveInfo.DPPCFFFNBGA_ClearL6[i];
				info.LCOHGOIDMDF_ComboRank = saveInfo.EEECMKPLPNL_ComboRankL6[i];
				info.HPBPDHPIBGN_enemy.KHEKNNFCAOI_Init(musicInfo.PJNFOCDANCE_EnemyIdByDiffL6[i], musicInfo.ILCJOOPIILK[i]);
				val = saveInfo.FHFKOGIPAEH_PlayL6[i];
			}
			if((info.JNLKJCDFFMM_clear) < 1)
			{
				if(val > 0)
				{
					info.CMCKNKKCNDK_status = 2;
					LDGOHPAPBMM_IsNew = false;
				}
				else
				{
					info.CMCKNKKCNDK_status = 1;
				}
			}
			else
			{
				info.CMCKNKKCNDK_status = 3;
				LDGOHPAPBMM_IsNew = false;
			}
			info.HHMLMKAEJBJ_Score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(musicInfo2.KKPAHLMJKIH_WavId, musicInfo2.BKJGCEOEPFB_VariationId, i, _GIKLNODJKFK_IsLine6, true);
			if(info.HHMLMKAEJBJ_Score != null)
			{
				info.BAKLKJLPLOJ_MusicLevel = musicInfo.EMJCHPDJHEI(_GIKLNODJKFK_IsLine6, i);
				info.BPLOEAHOPFI_stamina = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.HHEEPBJNAKA_GetEnergy(info.HHMLMKAEJBJ_Score.ANAJIAENLNB_lv, _GIKLNODJKFK_IsLine6);
				MGJKEJHEBPO_Blocks.Add(info);
			}
			hasValue = hasValue & (saveInfo.EMHFDJEFIHG_play[i] < 1);
			hasValue2 = hasValue2 & (saveInfo.FHFKOGIPAEH_PlayL6[i] < 1);
		}
		OPPBIOEJAND_EventMusicRank = 0;
		JOJPMFNJJPD_HasEventMusicRank = false;
		CADENLBDAEB_IsNew = (hasValue || hasValue2);
		if(!musicInfo.BHJNFBDNFEJ)
		{
			BNCMJNMIDIN_AvaiableDivaModes = (byte)(BNCMJNMIDIN_AvaiableDivaModes & 1);
		}
		if(DBIGDCOHOIC_IsMultiDanceUnlocked() && KLOGLLFOAPL_HasMultiDivaMode())
		{
			CPBDGAGKNGH_UlNew = saveInfo.CPBDGAGKNGH_UlNew;
			if (saveInfo.CPBDGAGKNGH_UlNew)
			{
				CADENLBDAEB_IsNew = true;
				LDGOHPAPBMM_IsNew = true;
			}
		}
		else
		{
			CPBDGAGKNGH_UlNew = false;
		}
		AAODIMMEFBI = HighScoreRating.GetUtaRate(_GHBPLHBNMBK_FreeMusicId);
		KCKBOIDCPCK_CdSelectEvenType = 0;
		JJEFMIHJMHC_CursorStepCount = 0;
		GBNOALJPOBM_IsLine6 = musicInfo.GBNOALJPOBM_IsLine6;
	}

	// // RVA: 0x1215B3C Offset: 0x1215B3C VA: 0x1215B3C
	private void FAEBEJENNHD(IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		GHBPLHBNMBK_FreeMusicId = 0;
		MGJKEJHEBPO_Blocks = new List<ANJLFFPBAEF_DifficultyInfo>();
		AFCMIOIGAJN_EventInfo = new GFKEJIHPAOM();
		if(LIKDEHHKFEH != null)
		{
			AFCMIOIGAJN_EventInfo.KINJOEIAHFK_StartTime = LIKDEHHKFEH.GLIMIGNNGGB_RankingStart;
			AFCMIOIGAJN_EventInfo.PCCFAKEOBIC_EndTime = LIKDEHHKFEH.DPJCPDKALGI_RankingEnd;
			AFCMIOIGAJN_EventInfo.EMEKFFHCHMH_RewardEnd2 = LIKDEHHKFEH.EMEKFFHCHMH_RewardEnd2;
			AFCMIOIGAJN_EventInfo.OPFGFINHFCE_name = LIKDEHHKFEH.DGCOMDILAKM_EventName;
			AFCMIOIGAJN_EventInfo.KLMPFGOCBHC_description = LIKDEHHKFEH.FBHONHONKGD_MusicSelectDesc;
			AFCMIOIGAJN_EventInfo.GOAPADIHAHG_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventType = LIKDEHHKFEH.HIDHLFCBIDE_EventType;
			EKANGPODCEP_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			KKPAHLMJKIH_WavId = LIKDEHHKFEH.EDNMFMBLCGF_GetWavId();
			OBGKIMDIAJF_CheckIsDlded();
			if(LIKDEHHKFEH.MPMKJNJGFEF_IsEntry())
				CADENLBDAEB_IsNew = false;
		}
	}

	// // RVA: 0x1215D48 Offset: 0x1215D48 VA: 0x1215D48
	private void OKLGJBKAJGH(IKDICBBFBMI_EventBase LIKDEHHKFEH, int _OOCBPMNHLPM_MusicId)
	{
		GHBPLHBNMBK_FreeMusicId = 0;
		MGJKEJHEBPO_Blocks = new List<ANJLFFPBAEF_DifficultyInfo>();
		NOKBLCDMLPP_MinigameEventInfo = new DLLJPHLOICN();
		if(LIKDEHHKFEH != null)
		{
			NOKBLCDMLPP_MinigameEventInfo.KINJOEIAHFK_StartTime = LIKDEHHKFEH.GLIMIGNNGGB_RankingStart;
			NOKBLCDMLPP_MinigameEventInfo.PCCFAKEOBIC_EndTime = LIKDEHHKFEH.DPJCPDKALGI_RankingEnd;
			NOKBLCDMLPP_MinigameEventInfo.EMEKFFHCHMH_RewardEnd2 = LIKDEHHKFEH.EMEKFFHCHMH_RewardEnd2;
			NOKBLCDMLPP_MinigameEventInfo.OPFGFINHFCE_name = LIKDEHHKFEH.DGCOMDILAKM_EventName;
			NOKBLCDMLPP_MinigameEventInfo.KLMPFGOCBHC_description = LIKDEHHKFEH.FBHONHONKGD_MusicSelectDesc;
			NOKBLCDMLPP_MinigameEventInfo.GOAPADIHAHG_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			NOKBLCDMLPP_MinigameEventInfo.HIDHLFCBIDE_EventType = LIKDEHHKFEH.HIDHLFCBIDE_EventType;
			NOKBLCDMLPP_MinigameEventInfo.OOCBPMNHLPM_MusicId = _OOCBPMNHLPM_MusicId;
			EKANGPODCEP_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			KKPAHLMJKIH_WavId = LIKDEHHKFEH.EDNMFMBLCGF_GetWavId();
			OBGKIMDIAJF_CheckIsDlded();
			if (LIKDEHHKFEH.MPMKJNJGFEF_IsEntry())
				CADENLBDAEB_IsNew = false;
		}
	}

	// // RVA: 0x1215F78 Offset: 0x1215F78 VA: 0x1215F78
	public void PMKBMGNAJIL(HLEBAINCOME_EventScore LIKDEHHKFEH, bool _GIKLNODJKFK_IsLine6)
	{
		GHBPLHBNMBK_FreeMusicId = LIKDEHHKFEH.HEACCHAKMFG_GetMusicsList()[0];
        KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData[GHBPLHBNMBK_FreeMusicId - 1];
		base.KHEKNNFCAOI_Init(m.DLAEJOBELBH_MusicId);
		EONOEHOKBEB_Music m2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[m.DLAEJOBELBH_MusicId - 1];
		FEHINJKHDAP_EventScore.ALGDNCMJHGN data = LIKDEHHKFEH.JIPPHOKGLIH(false);
		DEPGBBJMFED_CategoryId = m.DEPGBBJMFED_CategoryId;
		EKANGPODCEP_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
		LEBDMNIGOJB_IsScoreEvent = true;
		MNNHHJBBICA_GameEventType = 4;
		OEILJHENAHN_PlayEventType = 4;
		BJANNALFGGA_HasRanking = false;
		LDGOHPAPBMM_IsNew = true;
		PJLNJJIBFBN_HasExtremeDiff = LIKDEHHKFEH.PJLNJJIBFBN_HasExtremeDiff;
		bool b2 = m.GBNOALJPOBM_IsLine6;
		MGJKEJHEBPO_Blocks = new List<ANJLFFPBAEF_DifficultyInfo>();
		int cnt = PJLNJJIBFBN_HasExtremeDiff ? 5 : 4;
		bool b = true;
		for(int diffIdx = 0; diffIdx < cnt; diffIdx++)
		{
			ANJLFFPBAEF_DifficultyInfo diff = new ANJLFFPBAEF_DifficultyInfo();
			diff.HPBPDHPIBGN_enemy = new EJKBKMBJMGL_EnemyData();
			int p;
			if(!_GIKLNODJKFK_IsLine6)
			{
				diff.KNIFCANOHOC_score = data.KNIFCANOHOC_score[diffIdx].DNJEJEANJGL_Value;
				diff.NLKEBAOBJCM_combo = data.NLKEBAOBJCM_combo[diffIdx].DNJEJEANJGL_Value;
				diff.JNLKJCDFFMM_clear = data.JNLKJCDFFMM_clear[diffIdx].DNJEJEANJGL_Value;
				diff.LCOHGOIDMDF_ComboRank = data.LAMCCNAKIOJ_ComboRank[diffIdx];
				diff.HPBPDHPIBGN_enemy.KHEKNNFCAOI_Init(m.LHICAKGHIGF_EnemyIdByDiff[diffIdx], m.LJPKLMJPLAC_DIn[diffIdx]);
				p = data.EMHFDJEFIHG_play[diffIdx].DNJEJEANJGL_Value;
			}
			else
			{
				diff.KNIFCANOHOC_score = data.HAFFCOKJHBN_ScoreL6[diffIdx].DNJEJEANJGL_Value;
				diff.NLKEBAOBJCM_combo = data.DNIGPFPHJAK_ComboL6[diffIdx].DNJEJEANJGL_Value;
				diff.JNLKJCDFFMM_clear = data.DPPCFFFNBGA_ClearL6[diffIdx].DNJEJEANJGL_Value;
				diff.LCOHGOIDMDF_ComboRank = data.EEECMKPLPNL_ComboRankL6[diffIdx];
				diff.HPBPDHPIBGN_enemy.KHEKNNFCAOI_Init(m.PJNFOCDANCE_EnemyIdByDiffL6[diffIdx], m.ILCJOOPIILK[diffIdx]);
				p = data.FHFKOGIPAEH_PlayL6[diffIdx].DNJEJEANJGL_Value;
			}
			if(diff.JNLKJCDFFMM_clear < 1)
			{
				if(diff.EMHFDJEFIHG_play > 0)
				{
					diff.CMCKNKKCNDK_status = 2;
					LDGOHPAPBMM_IsNew = false;
				}
				else
				{
					diff.CMCKNKKCNDK_status = 1;
				}
			}
			else
			{
				diff.CMCKNKKCNDK_status = 3;
				LDGOHPAPBMM_IsNew = false;
			}
			diff.HHMLMKAEJBJ_Score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(m2.KKPAHLMJKIH_WavId, m2.BKJGCEOEPFB_VariationId, diffIdx, _GIKLNODJKFK_IsLine6, true);
			diff.BAKLKJLPLOJ_MusicLevel = m.EMJCHPDJHEI(_GIKLNODJKFK_IsLine6, diffIdx);
			diff.BPLOEAHOPFI_stamina = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.HHEEPBJNAKA_GetEnergy(diff.HHMLMKAEJBJ_Score.ANAJIAENLNB_lv, _GIKLNODJKFK_IsLine6);
			MGJKEJHEBPO_Blocks.Add(diff);
			b &= data.EMHFDJEFIHG_play[diffIdx].DNJEJEANJGL_Value < 1;
			b2 &= data.FHFKOGIPAEH_PlayL6[diffIdx].DNJEJEANJGL_Value < 1;
		}
		CADENLBDAEB_IsNew = b || b2 || CPBDGAGKNGH_UlNew;
		LDGOHPAPBMM_IsNew = CPBDGAGKNGH_UlNew;
		GBNOALJPOBM_IsLine6 = m.GBNOALJPOBM_IsLine6;
    }

	// // RVA: 0x1216BB0 Offset: 0x1216BB0 VA: 0x1216BB0
	private void EAHJLJOMFMG(int EPLEIPFGGHP, HAEDCCLHEMN_EventBattle LIKDEHHKFEH, bool _GIKLNODJKFK_IsLine6)
	{
		GHBPLHBNMBK_FreeMusicId = LIKDEHHKFEH.PIPHAKNMIBL_Rivals[EPLEIPFGGHP].GOIKCKHMBDL_FreeMusicId;
		KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData[GHBPLHBNMBK_FreeMusicId - 1];
		base.KHEKNNFCAOI_Init(m.DLAEJOBELBH_MusicId);
		EONOEHOKBEB_Music m2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[m.DLAEJOBELBH_MusicId - 1];
        CCPKHBECNLH_EventBattle.AIFGBKMMJGL data = LIKDEHHKFEH.JIPPHOKGLIH_GetMusicSaveData(GHBPLHBNMBK_FreeMusicId, false);
        DEPGBBJMFED_CategoryId = m.DEPGBBJMFED_CategoryId;
		EKANGPODCEP_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
		LEBDMNIGOJB_IsScoreEvent = false;
		MNNHHJBBICA_GameEventType = 3;
		MFJKNCACBDG_OpenEventType = 3;
		OEILJHENAHN_PlayEventType = 3;
		BJANNALFGGA_HasRanking = false;
		LDGOHPAPBMM_IsNew = true;
		PJLNJJIBFBN_HasExtremeDiff = true;
		bool b2 = m.GBNOALJPOBM_IsLine6;
		MGJKEJHEBPO_Blocks = new List<ANJLFFPBAEF_DifficultyInfo>();
		DACLONHOFLA = new BKKMNPEEILG();
		int cnt = PJLNJJIBFBN_HasExtremeDiff ? 5 : 4; 
		DACLONHOFLA.KHEKNNFCAOI_Init(LIKDEHHKFEH, EPLEIPFGGHP);
		bool b = true;
		for(int diffIdx = 0; diffIdx < cnt; diffIdx++)
		{
			ANJLFFPBAEF_DifficultyInfo diff = new ANJLFFPBAEF_DifficultyInfo();
			diff.HPBPDHPIBGN_enemy = new EJKBKMBJMGL_EnemyData();
			if(!_GIKLNODJKFK_IsLine6)
			{
				if(data != null)
				{
					diff.KNIFCANOHOC_score = data.BDCAICINCKK_GetScoreForDiff(diffIdx);
					diff.NLKEBAOBJCM_combo = data.NLKEBAOBJCM_combo[diffIdx];
					diff.JNLKJCDFFMM_clear = data.JNLKJCDFFMM_clear[diffIdx];
					diff.EMHFDJEFIHG_play = data.EMHFDJEFIHG_play[diffIdx];
					diff.LCOHGOIDMDF_ComboRank = data.LAMCCNAKIOJ_ComboRank[diffIdx];
				}
				diff.HPBPDHPIBGN_enemy.KHEKNNFCAOI_Init(m.LHICAKGHIGF_EnemyIdByDiff[diffIdx], m.LJPKLMJPLAC_DIn[diffIdx]);
			}
			else
			{
				if(data != null)
				{
					diff.KNIFCANOHOC_score = data.AHDKMPFDKPE_GetScoreForDiffL6(diffIdx);
					diff.NLKEBAOBJCM_combo = data.DNIGPFPHJAK_ComboL6[diffIdx];
					diff.JNLKJCDFFMM_clear = data.DPPCFFFNBGA_ClearL6[diffIdx];
					diff.EMHFDJEFIHG_play = data.FHFKOGIPAEH_PlayL6[diffIdx];
					diff.LCOHGOIDMDF_ComboRank = data.EEECMKPLPNL_ComboRankL6[diffIdx];
				}
				diff.HPBPDHPIBGN_enemy.KHEKNNFCAOI_Init(m.PJNFOCDANCE_EnemyIdByDiffL6[diffIdx], m.ILCJOOPIILK[diffIdx]);
			}
			if(diff.JNLKJCDFFMM_clear < 1)
			{
				if(diff.EMHFDJEFIHG_play > 0)
				{
					diff.CMCKNKKCNDK_status = 2;
					LDGOHPAPBMM_IsNew = false;
				}
				else
				{
					diff.CMCKNKKCNDK_status = 1;
				}
			}
			else
			{
				diff.CMCKNKKCNDK_status = 3;
				LDGOHPAPBMM_IsNew = false;
			}
			diff.HHMLMKAEJBJ_Score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(m2.KKPAHLMJKIH_WavId, m2.BKJGCEOEPFB_VariationId, diffIdx, _GIKLNODJKFK_IsLine6, true);
			diff.BAKLKJLPLOJ_MusicLevel = m.EMJCHPDJHEI(_GIKLNODJKFK_IsLine6, diffIdx);
			diff.BPLOEAHOPFI_stamina = LIKDEHHKFEH.KGIIPFJIAGB_GetPlayCost(diffIdx, _GIKLNODJKFK_IsLine6);
			MGJKEJHEBPO_Blocks.Add(diff);
			b &= data.EMHFDJEFIHG_play[diffIdx] < 1;
			b2 &= data.FHFKOGIPAEH_PlayL6[diffIdx] < 1;
		}
		CADENLBDAEB_IsNew = b || b2 || CPBDGAGKNGH_UlNew;
		GBNOALJPOBM_IsLine6 = m.GBNOALJPOBM_IsLine6;
	}

	// // RVA: 0x12176B8 Offset: 0x12176B8 VA: 0x12176B8
	private void NIIMCBEJHDE(AMLGMLNGMFB_EventAprilFool LIKDEHHKFEH, int MNKCJGIGPJP, bool _GIKLNODJKFK_IsLine6)
	{
		GHBPLHBNMBK_FreeMusicId = MNKCJGIGPJP;
		KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData[MNKCJGIGPJP - 1];
		base.KHEKNNFCAOI_Init(m.DLAEJOBELBH_MusicId);
		EONOEHOKBEB_Music m2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.INJDLHAEPEK_GetMusicInfo(GHBPLHBNMBK_FreeMusicId, m.DLAEJOBELBH_MusicId);
		JNCPEGJGHOG_JacketId = m2.JNCPEGJGHOG_JacketId;
		BNCMJNMIDIN_AvaiableDivaModes = FFJPJEMCGKK(m2);
		DEPGBBJMFED_CategoryId = m.DEPGBBJMFED_CategoryId;
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo saveMusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_FreeMusicId - 1];
		EKANGPODCEP_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
		LEBDMNIGOJB_IsScoreEvent = false;
		FGKMJHKLGLD = true;
		OEILJHENAHN_PlayEventType = 10;
		BJANNALFGGA_HasRanking = false;
		KCKBOIDCPCK_CdSelectEvenType = 0;
		PJLNJJIBFBN_HasExtremeDiff = LIKDEHHKFEH.PJLNJJIBFBN_HasExtremeDiff;
		int jacketRibbonType = LIKDEHHKFEH.IBFAJICMLGF_GetJacketRibbonType();
		if (jacketRibbonType > 0)
		{
			KCKBOIDCPCK_CdSelectEvenType = (int)LIKDEHHKFEH.CFLLOAEALGN_GetMusicEventType(jacketRibbonType) + 1;
		}
		LDGOHPAPBMM_IsNew = true;
		MGJKEJHEBPO_Blocks = new List<ANJLFFPBAEF_DifficultyInfo>();
		int c = 4;
		if (PJLNJJIBFBN_HasExtremeDiff)
			c = 5;
		bool b1 = m.GBNOALJPOBM_IsLine6;
		bool b2 = true;
		for(int i = 0; i < c; i++)
		{
			ANJLFFPBAEF_DifficultyInfo data = new ANJLFFPBAEF_DifficultyInfo();
			data.HPBPDHPIBGN_enemy = new EJKBKMBJMGL_EnemyData();
			int numPlay = 0;
			if(!_GIKLNODJKFK_IsLine6)
			{
				if(saveMusic != null)
				{
					data.KNIFCANOHOC_score = saveMusic.BDCAICINCKK_GetScoreForDiff(i);
					data.NLKEBAOBJCM_combo = saveMusic.NLKEBAOBJCM_combo[i];
					data.JNLKJCDFFMM_clear = saveMusic.JNLKJCDFFMM_clear[i];
					data.LCOHGOIDMDF_ComboRank = saveMusic.LAMCCNAKIOJ_ComboRank[i];
					numPlay = saveMusic.EMHFDJEFIHG_play[i];
				}
				data.HPBPDHPIBGN_enemy.KHEKNNFCAOI_Init(m.LHICAKGHIGF_EnemyIdByDiff[i], m.LJPKLMJPLAC_DIn[i]);

			}
			else
			{
				if(saveMusic != null)
				{
					data.KNIFCANOHOC_score = saveMusic.AHDKMPFDKPE_GetScoreL6_ForDiff(i);
					data.NLKEBAOBJCM_combo = saveMusic.DNIGPFPHJAK_ComboL6[i];
					data.JNLKJCDFFMM_clear = saveMusic.DPPCFFFNBGA_ClearL6[i];
					data.LCOHGOIDMDF_ComboRank = saveMusic.EEECMKPLPNL_ComboRankL6[i];
					numPlay = saveMusic.FHFKOGIPAEH_PlayL6[i];
				}
				data.HPBPDHPIBGN_enemy.KHEKNNFCAOI_Init(m.PJNFOCDANCE_EnemyIdByDiffL6[i], m.ILCJOOPIILK[i]);
			}
			if(data.JNLKJCDFFMM_clear < 1)
			{
				if(numPlay > 0)
				{
					data.CMCKNKKCNDK_status = 2;
					LDGOHPAPBMM_IsNew = false;
				}
				else
				{
					data.CMCKNKKCNDK_status = 1;
				}
			}
			else
			{
				data.CMCKNKKCNDK_status = 3;
				LDGOHPAPBMM_IsNew = false;
			}
			data.HHMLMKAEJBJ_Score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(m2.KKPAHLMJKIH_WavId, m2.BKJGCEOEPFB_VariationId, i, _GIKLNODJKFK_IsLine6, true);
			data.BAKLKJLPLOJ_MusicLevel = m.EMJCHPDJHEI(_GIKLNODJKFK_IsLine6, i);
			data.BPLOEAHOPFI_stamina = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.HHEEPBJNAKA_GetEnergy(data.HHMLMKAEJBJ_Score.ANAJIAENLNB_lv, _GIKLNODJKFK_IsLine6);
			MGJKEJHEBPO_Blocks.Add(data);
			b1 &= saveMusic.EMHFDJEFIHG_play[i] == 0;
			b2 &= saveMusic.FHFKOGIPAEH_PlayL6[i] == 0;
		}
		CADENLBDAEB_IsNew = b1 || b2;
		if (CPBDGAGKNGH_UlNew)
		{
			CADENLBDAEB_IsNew = true;
			LDGOHPAPBMM_IsNew = true;
		}
		GBNOALJPOBM_IsLine6 = m.GBNOALJPOBM_IsLine6;
	}

	// // RVA: 0x1218364 Offset: 0x1218364 VA: 0x1218364
	private void FILJLEHKBJO(int KHCGNGEJLKC)
	{
		GHBPLHBNMBK_FreeMusicId = 0;
		MGJKEJHEBPO_Blocks = new List<ANJLFFPBAEF_DifficultyInfo>();
		POEGGBGOKGI_IsInfoLiveEntrance = true;
		JNCPEGJGHOG_JacketId = KHCGNGEJLKC;
	}

	// // RVA: 0x1218420 Offset: 0x1218420 VA: 0x1218420
	private void JBOHCKEIHKI(int _GHBPLHBNMBK_FreeMusicId, long JIHKOPIENAC, bool _PJLNJJIBFBN_HasExtremeDiff, int _PGIIDPEGGPI_EventId)
	{
		GHBPLHBNMBK_FreeMusicId = _GHBPLHBNMBK_FreeMusicId;
		KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData[GHBPLHBNMBK_FreeMusicId - 1];
		base.KHEKNNFCAOI_Init(m.DLAEJOBELBH_MusicId);
		EONOEHOKBEB_Music m2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[m.DLAEJOBELBH_MusicId - 1];
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_FreeMusicId - 1];
		DEPGBBJMFED_CategoryId = m.DEPGBBJMFED_CategoryId;
		EKANGPODCEP_EventId = _PGIIDPEGGPI_EventId;
		LHONOILACFL_IsWeeklyEvent = false;
		BJANNALFGGA_HasRanking = false;
		EHNGOGBJMGL = true;
		this.PJLNJJIBFBN_HasExtremeDiff = _PJLNJJIBFBN_HasExtremeDiff;
		EEFLOOBOAGF_ViewOrder = m.EEFLOOBOAGF_ViewOrder;
		CADENLBDAEB_IsNew = false;
		ALMOMLMCHNA_OtherEndTime = JIHKOPIENAC;
		MGJKEJHEBPO_Blocks = new List<ANJLFFPBAEF_DifficultyInfo>();
		int diffNum = 4;
		if (_PJLNJJIBFBN_HasExtremeDiff)
			diffNum = 5;
		for(int i = 0; i < diffNum; i++)
		{
			ANJLFFPBAEF_DifficultyInfo data = new ANJLFFPBAEF_DifficultyInfo();
			data.KNIFCANOHOC_score = save.BDCAICINCKK_GetScoreForDiff(i);
			data.NLKEBAOBJCM_combo = save.NLKEBAOBJCM_combo[i];
			data.JNLKJCDFFMM_clear = save.JNLKJCDFFMM_clear[i];
			data.LCOHGOIDMDF_ComboRank = save.LAMCCNAKIOJ_ComboRank[i];
			data.HPBPDHPIBGN_enemy = new EJKBKMBJMGL_EnemyData();
			data.HPBPDHPIBGN_enemy.KHEKNNFCAOI_Init(m.LHICAKGHIGF_EnemyIdByDiff[i], m.LJPKLMJPLAC_DIn[i]);
			data.CMCKNKKCNDK_status = 1;
			data.HHMLMKAEJBJ_Score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(m2.KKPAHLMJKIH_WavId, m2.BKJGCEOEPFB_VariationId, i, false, true);
			if(data.HHMLMKAEJBJ_Score != null)
			{
				data.BAKLKJLPLOJ_MusicLevel = m.EMJCHPDJHEI(false, i);
				data.BPLOEAHOPFI_stamina = 0;
				MGJKEJHEBPO_Blocks.Add(data);
			}
		}
		KCKBOIDCPCK_CdSelectEvenType = 0;
		IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(_PGIIDPEGGPI_EventId);
		if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
		{
			AMLGMLNGMFB_EventAprilFool af = ev as AMLGMLNGMFB_EventAprilFool;
			int a = af.IBFAJICMLGF_GetJacketRibbonType();
			if(a > 0)
			{
				KCKBOIDCPCK_CdSelectEvenType = (int)(af.CFLLOAEALGN_GetMusicEventType(a) + 1);
			}
		}
		GBNOALJPOBM_IsLine6 = m.GBNOALJPOBM_IsLine6;
	}

	// // RVA: 0x1218DB8 Offset: 0x1218DB8 VA: 0x1218DB8
	public static bool LBHPMGDNPHK_IsMusicOpen(int GHBPLHBNMBK_FreeMusicId, int DEPGBBJMFED_CategoryId)
	{
		KEODKEGFDLD_FreeMusicInfo musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId);
		if(musicInfo.PPEGAKEIEGM_Enabled == 2)
		{
			if(DEPGBBJMFED_CategoryId != -1)
			{
				if (musicInfo.DEPGBBJMFED_CategoryId != DEPGBBJMFED_CategoryId)
					return false;
			}
			int v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.JOHMIPPKPPM_GetStoryUnlockingMusic(GHBPLHBNMBK_FreeMusicId);
			if (v > 0)
			{
				return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[v - 1].HALOKFOJMLA_IsCompleted;
			}
			JPCKBFBCJKD data = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.LLJOPJMIGPD(GHBPLHBNMBK_FreeMusicId);
			if (data == null)
				return true;
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.EOHHFADHHBL_Complete)
			{
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAAMKEJKPPL(data, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level);
			}
		}

		return false;
	}

	// // RVA: 0x1219160 Offset: 0x1219160 VA: 0x1219160
	private void NPEKPHAFMGE_SetupEnemies(int _CPBFAMJEODF_c_skill, int _MGHPJNNDCIG_l_skill)
	{
		for(int i = 0; i < MGJKEJHEBPO_Blocks.Count; i++)
		{
			MGJKEJHEBPO_Blocks[i].HPBPDHPIBGN_enemy.NPEKPHAFMGE_OverrideSkill(_CPBFAMJEODF_c_skill, _MGHPJNNDCIG_l_skill);
		}
	}

	// // RVA: 0x1219268 Offset: 0x1219268 VA: 0x1219268
	public static List<int> CJHOOLJFGFB()
	{
		int cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData.Count;
		int cnt2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count;
		if (cnt2 < cnt)
			cnt = cnt2;
		List<int> l = new List<int>(cnt);
		for(int i = 0; i < cnt; i++)
		{
			KEODKEGFDLD_FreeMusicInfo fminfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(i + 1);
			if(LBHPMGDNPHK_IsMusicOpen(i + 1, fminfo.DEPGBBJMFED_CategoryId))
			{
				l.Add(i + 1);
			}
		}
		return l;
	}

	// // RVA: 0x12195BC Offset: 0x12195BC VA: 0x12195BC
	// private static bool OOGGDHGFBGG(OHCAABOMEOF.KGOGMKMBCPP _INDDJNMPONH_type) { }

	// // RVA: 0x12195D0 Offset: 0x12195D0 VA: 0x12195D0
	public static List<IBJAKJJICBC> FKDIMODKKJD(int _DEPGBBJMFED_CategoryId, long _JHNMKKNEENE_Time, bool OJEBNBLHPNP/* = true*/, bool EHBPHDPHPKF/* = false*/, bool JNBMBDFKEOI/* = false*/, bool _JCOJKAHFADL_Is6Line/* = false*/)
    {
		int saveMusicCount = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count;
		int numSongs = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData.Count;
		if(saveMusicCount < numSongs)
		{
			numSongs = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count;
		}
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
		OHCAABOMEOF.KGOGMKMBCPP_EventType type = 0;
		if (_DEPGBBJMFED_CategoryId != 5)
		{
			IKDICBBFBMI_EventBase data = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
			if (data != null)
			{
				type = data.HIDHLFCBIDE_EventType;
				if (type != OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
					type = 0;
			}
		}
		else
		{
			IKDICBBFBMI_EventBase eventData = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
			if (eventData != null && (eventData.HIDHLFCBIDE_EventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp || eventData.HIDHLFCBIDE_EventType > OHCAABOMEOF.KGOGMKMBCPP_EventType.OCCGDMDBCHK_EventGacha))
			{
				if(eventData.PDDKJENPOBL())
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.FAEBEJENNHD(eventData);
					if(EHBPHDPHPKF)
					{
						if(ib.CADENLBDAEB_IsNew)
						{
							//LAB_0121a784
							res.Add(ib);
							return res;
						}
					}
					else
					{
						res.Add(ib);
						type = eventData.HIDHLFCBIDE_EventType;
						if(type != OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
							type = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0_None;
					}
				}
			}
			HLEBAINCOME_EventScore eventScore = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) as HLEBAINCOME_EventScore;
			if (eventScore != null)
			{
				IBJAKJJICBC ib = new IBJAKJJICBC();
				ib.PMKBMGNAJIL(eventScore, _JCOJKAHFADL_Is6Line);
				if(EHBPHDPHPKF)
				{
					if(ib.CADENLBDAEB_IsNew)
					{
						//LAB_0121a784
						res.Add(ib);
						return res;
					}
				}
				else
				{
					if(!_JCOJKAHFADL_Is6Line || ib.GBNOALJPOBM_IsLine6)
					{
						res.Add(ib);
					}
				}
			}
			List<IKDICBBFBMI_EventBase> list2 = DJPFFHLCCNL(OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool, _JHNMKKNEENE_Time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6);
			for (int i = 0; i < list2.Count; i++)
			{
				AMLGMLNGMFB_EventAprilFool af = list2[i] as AMLGMLNGMFB_EventAprilFool;
				if (af.NDIILFIFCDL_GetMinigameId() < 1)
				{
					List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l = af.KOBMFPACBMB();
					for (int j = 0; j < l.Count; j++)
					{
						IBJAKJJICBC data = new IBJAKJJICBC();
						data.NIIMCBEJHDE(af, l[j].MPLGPBNJDJB_FreeMusicId, _JCOJKAHFADL_Is6Line);
						int enSkill = l[j].MLKFDMFDFCE_enemy_c_skill;
						if (enSkill < 1)
							enSkill = l[j].DKOPDNHDLIA_enemy_l_skill;
						if (enSkill > 0) // ?? not sure
						{
							data.NPEKPHAFMGE_SetupEnemies(l[j].MLKFDMFDFCE_enemy_c_skill, l[j].DKOPDNHDLIA_enemy_l_skill);
						}
						data.OGHOPBAKEFE_IsEventSpecial = true;
						data.JJEFMIHJMHC_CursorStepCount = l[j].LGADCGFMLLD_step;
						if (data.KLOGLLFOAPL_HasMultiDivaMode())
						{
							data.JPOINGMJCGL = true;
						}
						if (data.GHBPLHBNMBK_FreeMusicId > 0)
						{
							if (EHBPHDPHPKF)
							{
								if (data.CADENLBDAEB_IsNew)
								{
									//LAB_0121a784
									res.Add(data);
									return res;
								}
							}
							else
							{
								if (JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.KPMNPGKKFJG/*6*/) != null)
								{
									data.MFJKNCACBDG_OpenEventType = 1;
								}
								if (!_JCOJKAHFADL_Is6Line || data.GBNOALJPOBM_IsLine6)
								{
									res.Add(data);
								}
							}
						}
					}
				}
				else
				{
					IBJAKJJICBC data = new IBJAKJJICBC();
					data.OKLGJBKAJGH(af, af.NDIILFIFCDL_GetMinigameId());
					if (EHBPHDPHPKF)
					{
						if (data.CADENLBDAEB_IsNew)
						{
							//LAB_0121a784
							res.Add(data);
							return res;
						}
					}
					else
					{
						res.Add(data);
					}
				}
			}
		}
		//LAB_0121a02c:
		DKCJADHKGAN_EventWeekDay.JFFPEKOEINE ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CLLPBOPLICM_EventWeekDay.PPIBJECKCEF(_JHNMKKNEENE_Time);
		DateTime time = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
		for (int i = 0; i < numSongs; i++)
		{
			KEODKEGFDLD_FreeMusicInfo musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData[i];
			if (musicInfo.PPEGAKEIEGM_Enabled == 2)
			{
				if (musicInfo.GBNOALJPOBM_IsLine6 || !_JCOJKAHFADL_Is6Line)
				{
					if (_DEPGBBJMFED_CategoryId != -1)
					{
						if (musicInfo.DEPGBBJMFED_CategoryId != _DEPGBBJMFED_CategoryId)
						{
							continue;
						}
					}
					bool b = false;
					int val = 0;
					bool b2 = false;
					bool ok = false;
					if (_DEPGBBJMFED_CategoryId == 5)
					{
						if (ev != null && ev.FLPDCNBLOKL_IsSongForWeekDay((int)time.DayOfWeek, musicInfo.GHBPLHBNMBK_FreeMusicId))
						{
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[i].FKBPJCDBDAG_SetWeekEventServerDate(_JHNMKKNEENE_Time);
							//Setup vars
							//L311
							b = true;
							val = ev.AEHCKNNGAKF_BonusMaxCount + ev.ELEPHBOKIGK_Limit;
							b2 = ev.AEHCKNNGAKF_BonusMaxCount > 0;
							ok = true;
						}
					}
					else
					{
						ok = true;
						if (!OJEBNBLHPNP)
						{
							// set vars
							b = false;
							val = 0;
							if (!LBHPMGDNPHK_IsMusicOpen(musicInfo.GHBPLHBNMBK_FreeMusicId, _DEPGBBJMFED_CategoryId))
								continue;
						}
					}
					if (ok)
					{
						IBJAKJJICBC songInfo = new IBJAKJJICBC();
						songInfo.KHEKNNFCAOI_Init(musicInfo.GHBPLHBNMBK_FreeMusicId, b, (int)time.DayOfWeek, val, _JHNMKKNEENE_Time, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.FPGDAPAILAK_ExtremeUnlock == 2, false, _JCOJKAHFADL_Is6Line);
						songInfo.MFJKNCACBDG_OpenEventType = (int)type;
						songInfo.GDLNCHCPMCK_HasBoost = b2;
						if (EHBPHDPHPKF)
						{
							if (songInfo.CADENLBDAEB_IsNew)
							{
								res.Add(songInfo);
								return res;
							}
						}
						else
						{
							res.Add(songInfo);
						}
					}
				}
			}
		}
		if (_DEPGBBJMFED_CategoryId != 5)
		{
			res.Sort((IBJAKJJICBC _HKICMNAACDA_a, IBJAKJJICBC _BNKHBCBJBKI_b) =>
			{
				//0x1220084
				return _HKICMNAACDA_a.EEFLOOBOAGF_ViewOrder.CompareTo(_BNKHBCBJBKI_b.EEFLOOBOAGF_ViewOrder);
			});
			return res;
		}
		if (!JNBMBDFKEOI)
			return res;
		List<IBJAKJJICBC> list = LIENJMIJMIE(_JHNMKKNEENE_Time, _JCOJKAHFADL_Is6Line);
		for (int i = 0; i < list.Count; i++)
		{
			res.Add(list[i]);
		}
		return res;
    }

	// // RVA: 0x121AA58 Offset: 0x121AA58 VA: 0x121AA58
	private static List<IKDICBBFBMI_EventBase> DJPFFHLCCNL(OHCAABOMEOF.KGOGMKMBCPP_EventType _INDDJNMPONH_type, long _JHNMKKNEENE_Time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus BELFNAHNMDL/* = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived*/)
	{
		List<IKDICBBFBMI_EventBase> res = new List<IKDICBBFBMI_EventBase>();
		List<IKDICBBFBMI_EventBase> evts = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.FindAll((IKDICBBFBMI_EventBase JPAEDJJFFOI) =>
		{
			//0x1220374
			return JPAEDJJFFOI.HIDHLFCBIDE_EventType == _INDDJNMPONH_type;
		});
		for(int i = 0; i < evts.Count; i++)
		{
			evts[i].HCDGELDHFHB_UpdateStatus(_JHNMKKNEENE_Time);
			if (evts[i].NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1 && evts[i].NGOFCFJHOMI_Status <= BELFNAHNMDL)
				res.Add(evts[i]);
		}
		return res;
	}

	// // RVA: 0x121BE84 Offset: 0x121BE84 VA: 0x121BE84
	public static List<IBJAKJJICBC> ENHMHDALFDB(long _JHNMKKNEENE_Time, bool EHBPHDPHPKF/* = False*/, bool _JCOJKAHFADL_Is6Line/* = False*/)
	{
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
        IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
		if(ev != null)
		{
			if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection && ev.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
			{
				IBJAKJJICBC ib = new IBJAKJJICBC();
				ib.FILJLEHKBJO(ev.MNDFBBMNJGN_IsUsingTicket ? 999 : 998);
				ib.LEBDMNIGOJB_IsScoreEvent = false;
				res.Add(ib);
				List<int> lm = ev.HEACCHAKMFG_GetMusicsList();
				for(int i = 0; i < lm.Count; i++)
				{
					ib = new IBJAKJJICBC();
					ib.KHEKNNFCAOI_Init(lm[i], false, 0, 0, _JHNMKKNEENE_Time, ev.PJLNJJIBFBN_HasExtremeDiff, true, _JCOJKAHFADL_Is6Line);
					if(!_JCOJKAHFADL_Is6Line || ib.GBNOALJPOBM_IsLine6)
					{
						ib.MNNHHJBBICA_GameEventType = 1;
						ib.MFJKNCACBDG_OpenEventType = 1;
						ib.OEILJHENAHN_PlayEventType = 1;
						ib.BJANNALFGGA_HasRanking = false;
						ib.OGHOPBAKEFE_IsEventSpecial = true;
						ib.IHPCKOMBGKJ_End = ev.HOOBCIIOCJD_GetSongEndTime(lm[i]);
						ib.NNJNNCGGKMC_IsLimited = ev.GIDDKGMPIOK_IsLimited(lm[i]);
						if(ev.MNDFBBMNJGN_IsUsingTicket)
						{
							for(int j = 0; j < ib.MGJKEJHEBPO_Blocks.Count; j++)
							{
								ib.MGJKEJHEBPO_Blocks[j].PPDPGKHKCNB = ev.EAMODCHMCEL_GetTicketCost(j, _JCOJKAHFADL_Is6Line);
							}
							ib.JKIADEKHGLC_TicketItemId = ev.JKIADEKHGLC_TicketItemId;
						}
						ib.JOJPMFNJJPD_HasEventMusicRank = false;
						ib.OPPBIOEJAND_EventMusicRank = 0;
						if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection && ib.GHBPLHBNMBK_FreeMusicId == lm[0])
						{
							HJNNLPIGHLM_EventCollection evColl = ev as HJNNLPIGHLM_EventCollection;
							ib.JOJPMFNJJPD_HasEventMusicRank = true;
							ib.OPPBIOEJAND_EventMusicRank = evColl.CDINKAANIAA_Rank[1];
						}
						res.Add(ib);
					}
				}
			}
		}
		return res;
    }

	// // RVA: 0x121C6BC Offset: 0x121C6BC VA: 0x121C6BC
	public static List<IBJAKJJICBC> EHNABCEGAHO(long _JHNMKKNEENE_Time, bool EHBPHDPHPKF/* = False*/, bool _JCOJKAHFADL_Is6Line/* = False*/)
	{
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
        IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
        if (ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
		{
			HAEDCCLHEMN_EventBattle eventBattle = ev as HAEDCCLHEMN_EventBattle;
			bool isExRival = eventBattle.GKDFMEKOOBF_IsExRival();
			int c = eventBattle.KOELJHLJKDJ_GetRvMc();
			if(eventBattle.PIPHAKNMIBL_Rivals.Count < c)
				c = eventBattle.PIPHAKNMIBL_Rivals.Count;
			for(int i = 0; i < c; i++)
			{
				if(isExRival || eventBattle.PIPHAKNMIBL_Rivals[i].BHCIFFILAKJ_Strength < 3)
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.EAHJLJOMFMG(i, eventBattle, _JCOJKAHFADL_Is6Line);
					ib.OGHOPBAKEFE_IsEventSpecial = true;
					if(ib.GBNOALJPOBM_IsLine6 || !_JCOJKAHFADL_Is6Line)
					{
						res.Add(ib);
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x121ACC8 Offset: 0x121ACC8 VA: 0x121ACC8
	public static List<IBJAKJJICBC> LIENJMIJMIE(long _JHNMKKNEENE_Time, bool _GBNOALJPOBM_IsLine6/* = false*/)
    {
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData.Count)
		{
			//CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN.Count ??
		}
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
		IKDICBBFBMI_EventBase data = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
		if(data != null)
		{
			List<int> l = data.HEACCHAKMFG_GetMusicsList();
			for(int i = 0; i < l.Count; i++)
			{
				int a1 = l[i];
				IBJAKJJICBC ib = new IBJAKJJICBC();
				ib.JBOHCKEIHKI(a1, data.HOOBCIIOCJD_GetSongEndTime(a1), data.PJLNJJIBFBN_HasExtremeDiff, data.PGIIDPEGGPI_EventId);
				ib.LGIGMPBHJCI = true;
				ib.OGHOPBAKEFE_IsEventSpecial = true;
				ib.IHPCKOMBGKJ_End = data.HOOBCIIOCJD_GetSongEndTime(a1);
				ib.NNJNNCGGKMC_IsLimited = data.GIDDKGMPIOK_IsLimited(a1);
				res.Add(ib);
			}
		}
		data = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6);
		if(data != null)
		{
			List<int> l = data.HEACCHAKMFG_GetMusicsList();
			for(int i = 0; i < l.Count; i++)
			{
				int a1 = l[i];
				IBJAKJJICBC ib = new IBJAKJJICBC();
				ib.JBOHCKEIHKI(a1, data.HOOBCIIOCJD_GetSongEndTime(a1), data.PJLNJJIBFBN_HasExtremeDiff, 0);
				ib.OEILJHENAHN_PlayEventType = 4;
				ib.MNNHHJBBICA_GameEventType = 4;
				ib.LEBDMNIGOJB_IsScoreEvent = true;
				ib.OGHOPBAKEFE_IsEventSpecial = true;
				res.Add(ib);
			}
		}
		List<IKDICBBFBMI_EventBase> ldata = DJPFFHLCCNL(OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool, _JHNMKKNEENE_Time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6);
		for(int i = 0; i < ldata.Count; i++)
		{
			if(ldata[i] != null)
			{
				AMLGMLNGMFB_EventAprilFool af = ldata[i] as AMLGMLNGMFB_EventAprilFool;
				if(af.NDIILFIFCDL_GetMinigameId() < 1)
				{
					List<int> l = af.HEACCHAKMFG_GetMusicsList();
					if(l != null)
					{
						for(int j = 0; j < l.Count; j++)
						{
							IBJAKJJICBC data2 = new IBJAKJJICBC();
							data2.JBOHCKEIHKI(l[i], af.HOOBCIIOCJD_GetSongEndTime(l[i]), af.PJLNJJIBFBN_HasExtremeDiff, af.PGIIDPEGGPI_EventId);
							data2.OEILJHENAHN_PlayEventType = 10;
							data2.IHPCKOMBGKJ_End = af.HOOBCIIOCJD_GetSongEndTime(l[i]);
							data2.LEBDMNIGOJB_IsScoreEvent = false;
							data2.FGKMJHKLGLD = true;
							data2.NNJNNCGGKMC_IsLimited = af.GIDDKGMPIOK_IsLimited(l[i]);
							data2.OGHOPBAKEFE_IsEventSpecial = true;
							KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[i]);
							EONOEHOKBEB_Music m2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.INJDLHAEPEK_GetMusicInfo(l[i], m.DLAEJOBELBH_MusicId);
							data2.JNCPEGJGHOG_JacketId = m2.JNCPEGJGHOG_JacketId;
							data2.BNCMJNMIDIN_AvaiableDivaModes = FFJPJEMCGKK(m2);
							if (data2.KLOGLLFOAPL_HasMultiDivaMode())
								data2.JPOINGMJCGL = true;
							res.Add(data2);
						}
					}
				}
			}
		}
		DKCJADHKGAN_EventWeekDay.JFFPEKOEINE e = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CLLPBOPLICM_EventWeekDay.PPIBJECKCEF(_JHNMKKNEENE_Time);
		DateTime date = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
		if(e != null)
		{
			List<int> l = e.OPCBHOLFCHO_GetSongsForWeekDay((int)date.DayOfWeek);
			if(l != null)
			{
				for(int i = 0; i < l.Count; i++)
				{
					IBJAKJJICBC d = new IBJAKJJICBC();
					d.JBOHCKEIHKI(l[i], Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0) + 86400, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.FPGDAPAILAK_ExtremeUnlock == 2, 0);
					d.LHONOILACFL_IsWeeklyEvent = true;
					res.Add(d);
				}
			}
		}
		if(_GBNOALJPOBM_IsLine6)
		{
			res = res.FindAll((IBJAKJJICBC JPAEDJJFFOI) =>
			{
				//0x12200F0
				return JPAEDJJFFOI.GBNOALJPOBM_IsLine6;
			});
		}
        return res;
    }

	// // RVA: 0x121CBD4 Offset: 0x121CBD4 VA: 0x121CBD4
	public static void GNNIJFBOBAJ(List<IBJAKJJICBC> NNDGIAEFMOG)
	{
		int a = 0;
		int b = 0;
        IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
		if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventMission)
		{
			KPJHLACKGJF_EventMission evM = ev as KPJHLACKGJF_EventMission;
			ACBAHDMEFFL_EventMission.BIMNGKEMMJM d = evM.MLLAMHMJFLP();
			if(d != null)
			{
				if(evM.BHNEJEDEHJA_SelectedCardIdx() == 2)
				{
					a = evM.LOLJPCKNLGI(d.CFMIPHDGCAG_Mid3).MLKFDMFDFCE_enemy_c_skill;
					b = evM.LOLJPCKNLGI(d.CFMIPHDGCAG_Mid3).DKOPDNHDLIA_enemy_l_skill;
				}
				else if(evM.BHNEJEDEHJA_SelectedCardIdx() == 1)
				{
					a = evM.LOLJPCKNLGI(d.KEEHMNJCONJ_Mid2).MLKFDMFDFCE_enemy_c_skill;
					b = evM.LOLJPCKNLGI(d.KEEHMNJCONJ_Mid2).DKOPDNHDLIA_enemy_l_skill;
				}
				else if(evM.BHNEJEDEHJA_SelectedCardIdx() == 0)
				{
					a = evM.LOLJPCKNLGI(d.BGFPMGPHGJJ_Mid1).MLKFDMFDFCE_enemy_c_skill;
					b = evM.LOLJPCKNLGI(d.BGFPMGPHGJJ_Mid1).DKOPDNHDLIA_enemy_l_skill;
				}
			}
		}
		//LAB_0121cdd0
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			NNDGIAEFMOG[i].NPEKPHAFMGE_SetupEnemies(a, b);
		}
    }

	// // RVA: 0x121CE9C Offset: 0x121CE9C VA: 0x121CE9C
	public static void BDNIEPMOHDI(List<IBJAKJJICBC> NNDGIAEFMOG)
	{
        IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
		if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
		{
			for(int i = 0; i < NNDGIAEFMOG.Count; i++)
			{
				NNDGIAEFMOG[i].NPEKPHAFMGE_SetupEnemies(NNDGIAEFMOG[i].DACLONHOFLA.CPBFAMJEODF_c_skill, NNDGIAEFMOG[i].DACLONHOFLA.MGHPJNNDCIG_l_skill);
			}
		}
    }

	// // RVA: 0x121D0DC Offset: 0x121D0DC VA: 0x121D0DC
	public static List<IBJAKJJICBC> FMHFMIMDOCM(int _DEPGBBJMFED_CategoryId, long _JHNMKKNEENE_Time, bool _JCOJKAHFADL_Is6Line /*= False*/)
	{
		return MJAJPHIKGBF(_DEPGBBJMFED_CategoryId, _JHNMKKNEENE_Time, _JCOJKAHFADL_Is6Line, JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false), OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventMission);
	}

	// // RVA: 0x121DF50 Offset: 0x121DF50 VA: 0x121DF50
	public static List<IBJAKJJICBC> DHFHJBMKEHN(int _DEPGBBJMFED_CategoryId, long _JHNMKKNEENE_Time, bool _JCOJKAHFADL_Is6Line/* = False*/)
	{
		return MJAJPHIKGBF(_DEPGBBJMFED_CategoryId, _JHNMKKNEENE_Time, _JCOJKAHFADL_Is6Line, JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6), OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid);
	}

	// // RVA: 0x121E028 Offset: 0x121E028 VA: 0x121E028
	public static List<IBJAKJJICBC> ONHHIHBHKPK(int _DEPGBBJMFED_CategoryId, long _JHNMKKNEENE_Time, bool _JCOJKAHFADL_Is6Line/* = False*/)
	{
		List<IBJAKJJICBC> res = MJAJPHIKGBF(_DEPGBBJMFED_CategoryId, _JHNMKKNEENE_Time, _JCOJKAHFADL_Is6Line, JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6), OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva);
		res.RemoveAll((IBJAKJJICBC _GHPLINIACBB_x) =>
		{
			//0x1220114
			return _GHPLINIACBB_x.HAMPEDFMIAD_HasOnlyMultiDivaMode();
		});
		return res;
	}

	// // RVA: 0x121D1B4 Offset: 0x121D1B4 VA: 0x121D1B4
	private static List<IBJAKJJICBC> MJAJPHIKGBF(int _DEPGBBJMFED_CategoryId, long _JHNMKKNEENE_Time, bool _JCOJKAHFADL_Is6Line, IKDICBBFBMI_EventBase FBFNJMKPBBA, OHCAABOMEOF.KGOGMKMBCPP_EventType _HIDHLFCBIDE_EventType)
	{
		int cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData.Count;
		int cnt2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count;
		if(cnt2 < cnt)
			cnt = cnt2;
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
		if(FBFNJMKPBBA != null && _DEPGBBJMFED_CategoryId == 5 && FBFNJMKPBBA.HIDHLFCBIDE_EventType == _HIDHLFCBIDE_EventType)
		{
			List<int> musicList = FBFNJMKPBBA.HEACCHAKMFG_GetMusicsList();
			for(int i = 0; i < musicList.Count; i++)
			{
				IBJAKJJICBC ib = new IBJAKJJICBC();
				ib.KHEKNNFCAOI_Init(musicList[i], false, 0, 0, _JHNMKKNEENE_Time, FBFNJMKPBBA.PJLNJJIBFBN_HasExtremeDiff, true, _JCOJKAHFADL_Is6Line);
				ib.MNNHHJBBICA_GameEventType = (int)_HIDHLFCBIDE_EventType;
				ib.MFJKNCACBDG_OpenEventType = (int)_HIDHLFCBIDE_EventType;
				ib.OEILJHENAHN_PlayEventType = (int)_HIDHLFCBIDE_EventType;
				ib.BJANNALFGGA_HasRanking = false;
				ib.DBJOBFIGGEE_EventBonusPercent = FBFNJMKPBBA.OMJHBJPCFFC_GetEventBonusPercent(musicList[i]);
				ib.OGHOPBAKEFE_IsEventSpecial = true;
				ib.IHPCKOMBGKJ_End = FBFNJMKPBBA.HOOBCIIOCJD_GetSongEndTime(i);
				ib.NNJNNCGGKMC_IsLimited = FBFNJMKPBBA.GIDDKGMPIOK_IsLimited(i);
				if(!_JCOJKAHFADL_Is6Line || ib.GBNOALJPOBM_IsLine6)
				{
					res.Add(ib);
				}
			}
		}
        DKCJADHKGAN_EventWeekDay.JFFPEKOEINE evWeekDay = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CLLPBOPLICM_EventWeekDay.PPIBJECKCEF(_JHNMKKNEENE_Time);
        DayOfWeek dow = Utility.GetLocalDateTime(_JHNMKKNEENE_Time).DayOfWeek;
		for(int i = 0; i < cnt; i++)
		{
            KEODKEGFDLD_FreeMusicInfo song = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData[i];
            if (song.PPEGAKEIEGM_Enabled == 2)
			{
				if(_DEPGBBJMFED_CategoryId != -1 && _DEPGBBJMFED_CategoryId != song.DEPGBBJMFED_CategoryId)
				{
					//LAB_0121ddc0
					;
				}
				else if(_DEPGBBJMFED_CategoryId == 5)
				{
					if(evWeekDay != null)
					{
						if(evWeekDay.FLPDCNBLOKL_IsSongForWeekDay((int)dow, song.GHBPLHBNMBK_FreeMusicId))
						{
							JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo saveSong = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[i];
							saveSong.FKBPJCDBDAG_SetWeekEventServerDate(_JHNMKKNEENE_Time);
							//LAB_0121db68
							IBJAKJJICBC ib = new IBJAKJJICBC();
							ib.KHEKNNFCAOI_Init(song.GHBPLHBNMBK_FreeMusicId, true, (int)dow, evWeekDay.ELEPHBOKIGK_Limit + evWeekDay.AEHCKNNGAKF_BonusMaxCount, _JHNMKKNEENE_Time, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.FPGDAPAILAK_ExtremeUnlock == 2, false, _JCOJKAHFADL_Is6Line);
							ib.MNNHHJBBICA_GameEventType = (int)_HIDHLFCBIDE_EventType;
							ib.MFJKNCACBDG_OpenEventType = 0;
							ib.GDLNCHCPMCK_HasBoost = evWeekDay.AEHCKNNGAKF_BonusMaxCount > 0;
							ib.OEILJHENAHN_PlayEventType = (int)_HIDHLFCBIDE_EventType;
							ib.DBJOBFIGGEE_EventBonusPercent = FBFNJMKPBBA.OMJHBJPCFFC_GetEventBonusPercent(song.GHBPLHBNMBK_FreeMusicId);
							if(!_JCOJKAHFADL_Is6Line || ib.GBNOALJPOBM_IsLine6)
							{
								res.Add(ib);
							}
						}
					}
				}
				else
				{
					if(LBHPMGDNPHK_IsMusicOpen(song.GHBPLHBNMBK_FreeMusicId, _DEPGBBJMFED_CategoryId))
					{
						//LAB_0121db68
						IBJAKJJICBC ib = new IBJAKJJICBC();
						ib.KHEKNNFCAOI_Init(song.GHBPLHBNMBK_FreeMusicId, false, (int)dow, 0, _JHNMKKNEENE_Time, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.FPGDAPAILAK_ExtremeUnlock == 2, false, _JCOJKAHFADL_Is6Line);
						ib.MNNHHJBBICA_GameEventType = (int)_HIDHLFCBIDE_EventType;
						ib.MFJKNCACBDG_OpenEventType = 0;
						ib.GDLNCHCPMCK_HasBoost = false;
						ib.OEILJHENAHN_PlayEventType = (int)_HIDHLFCBIDE_EventType;
						ib.DBJOBFIGGEE_EventBonusPercent = FBFNJMKPBBA.OMJHBJPCFFC_GetEventBonusPercent(song.GHBPLHBNMBK_FreeMusicId);
						if(!_JCOJKAHFADL_Is6Line || ib.GBNOALJPOBM_IsLine6)
						{
							res.Add(ib);
						}
					}
				}
			}
		}
		if(_DEPGBBJMFED_CategoryId != 5)
		{
			res.Sort((IBJAKJJICBC _HKICMNAACDA_a, IBJAKJJICBC _BNKHBCBJBKI_b) =>
			{
				//0x1220140
				return _HKICMNAACDA_a.EEFLOOBOAGF_ViewOrder.CompareTo(_BNKHBCBJBKI_b.EEFLOOBOAGF_ViewOrder);
			});
		}
		return res;
	}

	// // RVA: 0x121E210 Offset: 0x121E210 VA: 0x121E210
	public static List<IBJAKJJICBC> GCCBCAKFJMF(int _DEPGBBJMFED_CategoryId, long _JHNMKKNEENE_Time, int _OAFJONPIFGM_EventId, bool _JCOJKAHFADL_Is6Line/* = False*/)
	{
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
		if(_DEPGBBJMFED_CategoryId == 5)
		{
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(_OAFJONPIFGM_EventId);
			if(ev.HIDHLFCBIDE_EventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
			{
				if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
				{
					List<int> l = ev.HEACCHAKMFG_GetMusicsList();
					for(int i = 0; i < l.Count && i <= 0; i++)
					{
						IBJAKJJICBC ib = new IBJAKJJICBC();
						ib.KHEKNNFCAOI_Init(l[i], false, 0, 0, _JHNMKKNEENE_Time, ev.PJLNJJIBFBN_HasExtremeDiff, true, false);
						ib.MNNHHJBBICA_GameEventType = 1;
						ib.MFJKNCACBDG_OpenEventType = 1;
						ib.OEILJHENAHN_PlayEventType = 1;
						ib.BJANNALFGGA_HasRanking = false;
						ib.OGHOPBAKEFE_IsEventSpecial = true;
						ib.IHPCKOMBGKJ_End = ev.HOOBCIIOCJD_GetSongEndTime(l[i]);
						ib.NNJNNCGGKMC_IsLimited = ev.GIDDKGMPIOK_IsLimited(l[i]);
						if(ev.MNDFBBMNJGN_IsUsingTicket)
						{
							for(int j = 0; j < ib.MGJKEJHEBPO_Blocks.Count; i++)
							{
								ib.MGJKEJHEBPO_Blocks[i].PPDPGKHKCNB = ev.EAMODCHMCEL_GetTicketCost(i, _JCOJKAHFADL_Is6Line);
							}
							ib.JKIADEKHGLC_TicketItemId = ev.JKIADEKHGLC_TicketItemId;
						}
						res.Add(ib);
					}
				}
				else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
				{
					HAEDCCLHEMN_EventBattle btEv = ev as HAEDCCLHEMN_EventBattle;
					List<int> l = btEv.HEACCHAKMFG_GetMusicsList();
					for(int i = 0; i <= 0 && i < l.Count; i++)
					{
						IBJAKJJICBC ib = new IBJAKJJICBC();
						ib.KHEKNNFCAOI_Init(l[i], false, 0, 0, _JHNMKKNEENE_Time, btEv.PJLNJJIBFBN_HasExtremeDiff, true, false);
						ib.OGHOPBAKEFE_IsEventSpecial = true;
						res.Add(ib);
					}
				}
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
			{
				MANPIONIGNO_EventGoDiva evGoDiva = ev as MANPIONIGNO_EventGoDiva;
				List<int> ls = evGoDiva.HEACCHAKMFG_GetMusicsList();
				for(int i = 0; i < 1 && i < ls.Count; i++)
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.KHEKNNFCAOI_Init(ls[i], false, 0, 0, _JHNMKKNEENE_Time, evGoDiva.PJLNJJIBFBN_HasExtremeDiff, true, false);
					ib.OGHOPBAKEFE_IsEventSpecial = true;
					res.Add(ib);
				}
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid || 
				ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventMission)
			{
				List<int> ls = ev.HEACCHAKMFG_GetMusicsList();
				for(int i = 0; i < 1 && i < ls.Count; i++)
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.KHEKNNFCAOI_Init(ls[i], false, 0, 0, _JHNMKKNEENE_Time, ev.PJLNJJIBFBN_HasExtremeDiff, true, false);
					ib.MFJKNCACBDG_OpenEventType = (int)ev.HIDHLFCBIDE_EventType;
					ib.MNNHHJBBICA_GameEventType = (int)ev.HIDHLFCBIDE_EventType;
					ib.OEILJHENAHN_PlayEventType = (int)ev.HIDHLFCBIDE_EventType;
					ib.BJANNALFGGA_HasRanking = false;
					ib.DBJOBFIGGEE_EventBonusPercent = ev.OMJHBJPCFFC_GetEventBonusPercent(ls[i]);
					ib.OGHOPBAKEFE_IsEventSpecial = true;
					ib.IHPCKOMBGKJ_End = ev.HOOBCIIOCJD_GetSongEndTime(ls[i]);
					ib.NNJNNCGGKMC_IsLimited = ev.GIDDKGMPIOK_IsLimited(ls[i]);
					ib.EKANGPODCEP_EventId = _OAFJONPIFGM_EventId;
					res.Add(ib);
				}
			}
        }
		else
		{
			res.Sort((IBJAKJJICBC _HKICMNAACDA_a, IBJAKJJICBC _BNKHBCBJBKI_b) =>
			{
				//0x12201AC
				return _HKICMNAACDA_a.EEFLOOBOAGF_ViewOrder.CompareTo(_BNKHBCBJBKI_b.EEFLOOBOAGF_ViewOrder);
			});
		}
		//LAB_0121e998
		if(_JCOJKAHFADL_Is6Line)
		{
			res = res.FindAll((IBJAKJJICBC JPAEDJJFFOI) =>
			{
				//0x1220218
				return JPAEDJJFFOI.GBNOALJPOBM_IsLine6;
			});
		}
		return res;
	}

	// // RVA: 0x121F428 Offset: 0x121F428 VA: 0x121F428
	public static IBJAKJJICBC MLMMPFACEKI_FindMusicInLists(int _GHBPLHBNMBK_FreeMusicId, List<IBJAKJJICBC> OEAJOJMOGMH, List<IBJAKJJICBC> FCCKCFEEOMN, List<IBJAKJJICBC> LCKJDADHOEB, List<IBJAKJJICBC> BAOEHOFNOOG, List<IBJAKJJICBC> EGLEKOHJBNA, List<IBJAKJJICBC> GEEODBLIDDB, ref int EIPGHNKPAOH, ref int _OIPCCBHIKIA_index)
	{
		EIPGHNKPAOH = 0;
		_OIPCCBHIKIA_index = 0;
		for(int i = 0; i < OEAJOJMOGMH.Count; i++)
		{
			if(OEAJOJMOGMH[i].GHBPLHBNMBK_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
			{
				EIPGHNKPAOH = 1;
				_OIPCCBHIKIA_index = i;
				return OEAJOJMOGMH[i];
			}
		}
		for(int i = 0; i < FCCKCFEEOMN.Count; i++)
		{
			if(FCCKCFEEOMN[i].GHBPLHBNMBK_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
			{
				EIPGHNKPAOH = 2;
				_OIPCCBHIKIA_index = i;
				return FCCKCFEEOMN[i];
			}
		}
		for(int i = 0; i < LCKJDADHOEB.Count; i++)
		{
			if(LCKJDADHOEB[i].GHBPLHBNMBK_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
			{
				EIPGHNKPAOH = 3;
				_OIPCCBHIKIA_index = i;
				return LCKJDADHOEB[i];
			}
		}
		for(int i = 0; i < BAOEHOFNOOG.Count; i++)
		{
			if(BAOEHOFNOOG[i].GHBPLHBNMBK_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
			{
				EIPGHNKPAOH = 4;
				_OIPCCBHIKIA_index = i;
				return BAOEHOFNOOG[i];
			}
		}
		for(int i = 0; i < EGLEKOHJBNA.Count; i++)
		{
			if(EGLEKOHJBNA[i].GHBPLHBNMBK_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
			{
				EIPGHNKPAOH = 5;
				_OIPCCBHIKIA_index = i;
				return EGLEKOHJBNA[i];
			}
		}
		for(int i = 0; i < GEEODBLIDDB.Count; i++)
		{
			if(GEEODBLIDDB[i].GHBPLHBNMBK_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
			{
				EIPGHNKPAOH = 6;
				_OIPCCBHIKIA_index = i;
				return GEEODBLIDDB[i];
			}
		}
		return null;
	}

	// // RVA: 0x121F99C Offset: 0x121F99C VA: 0x121F99C Slot: 3
	public override string ToString()
	{
		return string.Concat(new object[5]
		{
			"{f_id=",
			GHBPLHBNMBK_FreeMusicId,
			",name=",
			NEDBBJDAFBH_MusicName,
			"}"
		});
	}

	// // RVA: 0x121FC40 Offset: 0x121FC40 VA: 0x121FC40
	public static bool FPLIAMHMFJP()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		List<IBJAKJJICBC> l = FKDIMODKKJD(1, time, false, true, false, false);
		if(l.Count > 0)
			return true;
		l = FKDIMODKKJD(2, time, false, true, false, false);
		if (l.Count > 0)
			return true;
		l = FKDIMODKKJD(3, time, false, true, false, false);
		if (l.Count > 0)
			return true;
		l = FKDIMODKKJD(4, time, false, true, false, false);
		if (l.Count > 0)
			return true;
		l = FKDIMODKKJD(5, time, false, true, false, false);
		if (l.Count > 0)
			return true;
		return false;
	}


	// // RVA: 0x121FEF4 Offset: 0x121FEF4 VA: 0x121FEF4
	public static int POPLHDKHIIM()
    {
        return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("line6_unlock_uta_rate", 250);
    }

	// // RVA: 0x121FFE4 Offset: 0x121FFE4 VA: 0x121FFE4
	public static bool KGJJCAKCMLO(int AAODIMMEFBI)
	{
		return POPLHDKHIIM() <= AAODIMMEFBI;
	}

	// // RVA: 0x1215A78 Offset: 0x1215A78 VA: 0x1215A78
	public static bool KGJJCAKCMLO()
    {
        return true;
    }
}
