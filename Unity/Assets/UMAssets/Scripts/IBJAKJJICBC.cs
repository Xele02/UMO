
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
		public long KINJOEIAHFK_OpenTime; // 0x8
		public long PCCFAKEOBIC_CloseTime; // 0x10
		public long EMEKFFHCHMH_End; // 0x18
		public string OPFGFINHFCE_EventName; // 0x20
		public string KLMPFGOCBHC_EventDesc; // 0x24
		public int GOAPADIHAHG_EventId; // 0x28
		public OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventCategory; // 0x2C

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
		private const int FBGGEFFJJHB_Key = 0x7daf3c5a;
		public int NLBLLLLBHOP = FBGGEFFJJHB_Key; // 0x8
		public int NBOLDNMPJFG = FBGGEFFJJHB_Key; // 0xC
		public int BCKCCHGMPBG = FBGGEFFJJHB_Key; // 0x10
		public int COGALGDHDFE = FBGGEFFJJHB_Key; // 0x14
		public int FCOIEGJFOJI = FBGGEFFJJHB_Key; // 0x18
		public int FDOFFBKDJKC = FBGGEFFJJHB_Key; // 0x1C
		public int LOIHMDIJJOP_ComboRankCrypted = FBGGEFFJJHB_Key; // 0x20
		public int EINNKFIEIHJ = FBGGEFFJJHB_Key; // 0x24
		public KLBKPANJCPL_Score HHMLMKAEJBJ_Score; // 0x28
		public ADDHLABEFKH BAKLKJLPLOJ; // 0x2C
		public EJKBKMBJMGL_EnemyData HPBPDHPIBGN_EnemyData; // 0x30

		public int CMCKNKKCNDK_Status { get { return NLBLLLLBHOP ^ FBGGEFFJJHB_Key; } set { NLBLLLLBHOP = value ^ FBGGEFFJJHB_Key; } } //0x12203C0 CNKGOPKANGF 0x1215B00 CHJGGLFGALP
		public int KNIFCANOHOC_Score { get { return NBOLDNMPJFG ^ FBGGEFFJJHB_Key; } set { NBOLDNMPJFG = value ^ FBGGEFFJJHB_Key; } } //0x1214AC0 EOJEPLIPOMJ 0x1215AB0 AEEMBPAEAAI
		public int NLKEBAOBJCM_Combo { get { return BCKCCHGMPBG ^ FBGGEFFJJHB_Key; } set { BCKCCHGMPBG = value ^ FBGGEFFJJHB_Key; } } //0x12203D4 AECNKGBNKHH 0x1215AC4 ECHLKFHOJFP
		public int JNLKJCDFFMM_Clear { get { return COGALGDHDFE ^ FBGGEFFJJHB_Key; } set { COGALGDHDFE = value ^ FBGGEFFJJHB_Key; } } //0x1215B14 JLGNODHICKN 0x1215AD8 DLEGLBAGJOI
		public int EMHFDJEFIHG_Play { get { return FCOIEGJFOJI ^ FBGGEFFJJHB_Key; } set { FCOIEGJFOJI = value ^ FBGGEFFJJHB_Key; } } //0x12176A4 OBFCFPIDKGB 0x1217690 MJHGLINGBGJ
		public int BPLOEAHOPFI_Energy { get { return FDOFFBKDJKC ^ FBGGEFFJJHB_Key; } set { FDOFFBKDJKC = value ^ FBGGEFFJJHB_Key; } } //0x12203E8 IFLOIFCLBFJ 0x1215B28 NGMKCJOPEGH
		public int LCOHGOIDMDF_ComboRank { get { return LOIHMDIJJOP_ComboRankCrypted ^ FBGGEFFJJHB_Key; } set { LOIHMDIJJOP_ComboRankCrypted = value ^ FBGGEFFJJHB_Key; } } //0x12203FC LNDHFDDHOJP 0x1215AEC IMNCJLKPOAJ
		public int PPDPGKHKCNB { get { return EINNKFIEIHJ ^ FBGGEFFJJHB_Key; } set { EINNKFIEIHJ = value ^ FBGGEFFJJHB_Key; } } //0x1220410 BHNHLDKJLNJ 0x121C6A8 FLGAJBJBIII
		public int CIEOBFIIPLD { get { return HHMLMKAEJBJ_Score.ANAJIAENLNB_MusicLevel; } } //0x1220424 OGKGFGMKPKB
		public bool POOMOBGPCNE_IsLocked { get { return CMCKNKKCNDK_Status == 0; } } //0x1220450 PJPHEDJHLOO
		public bool CADENLBDAEB_IsNew { get { return CMCKNKKCNDK_Status == 1; } } //0x122046C KJGFPPLHLAB
		public bool CHBNEEIIDDI_IsPlayed { get { return CMCKNKKCNDK_Status == 2; } }// 0x1220488 PIGGFFEOODB
		public bool BCGLDMKODLC_IsClear { get { return CMCKNKKCNDK_Status == 3; } } //0x12204A4 NNGALFPBDNA
	}


	private const int FBGGEFFJJHB_Key = 0x7daf3c5a;
	private const sbyte JFOFMKBJBBE_False = 19;
	private const sbyte CNECJGKECHK_True = 87;
	private int EPGOIGPKPPJ_FreeMusicIdCrypted = FBGGEFFJJHB_Key; // 0x40
	private int HNEHIJCAOJM_CategoryIdCrypted = FBGGEFFJJHB_Key; // 0x44
	private sbyte ACKPOCNHOOP_Crypted = JFOFMKBJBBE_False; // 0x48
	private sbyte IFLNGLECALJ_Crypted = JFOFMKBJBBE_False; // 0x49
	private sbyte MEPLEIEDBGE_Crypted = JFOFMKBJBBE_False; // 0x4A
	private int EGCMPELNLKP_Crypted = FBGGEFFJJHB_Key; // 0x4C
	private int CEMGANMAOML_EventTypeCrypted = FBGGEFFJJHB_Key; // 0x50
	private int NENONMAGGBP_Crypted = FBGGEFFJJHB_Key; // 0x54
	private int MJLNDHPNFHE_Crypted = FBGGEFFJJHB_Key; // 0x58
	private int PPDEOMLMEKC_Crypted = FBGGEFFJJHB_Key; // 0x5C
	private sbyte IKGGKOFGMNC_Crypted; // 0x60
	private sbyte CICKCGDKICN_Crypted = JFOFMKBJBBE_False; // 0x61
	public BKKMNPEEILG DACLONHOFLA; // 0x64
	private int KAEIHNCACOD_Crypted = FBGGEFFJJHB_Key; // 0x68
	private sbyte MPDBHMLFLLA_Crypted = JFOFMKBJBBE_False; // 0x6C
	private sbyte JMFIOFIBLFH_Crypted = JFOFMKBJBBE_False; // 0x6D
	public WeekdayEventAttr.Type IHKFMJDOBAH_WeekDayAttr; // 0x70
	private sbyte CHOLAKGHAEN_IsWeelkyEventCrypted = JFOFMKBJBBE_False; // 0x74
	private long PMEGFLFDDKH_WeeklyEndTimeCrypted = FBGGEFFJJHB_Key; // 0x78
	private sbyte NKKAIPDPEEI_HasBoostCrypted = JFOFMKBJBBE_False; // 0x80
	private sbyte AJGIBNAJPJD_Crypted = JFOFMKBJBBE_False; // 0x81
	private int AFDHDBMKLJL_Crypted = FBGGEFFJJHB_Key; // 0x84
	private int KOOODCKJNJO_Crypted = FBGGEFFJJHB_Key; // 0x88
	private int NEBJMHHHDMO_Crypted = FBGGEFFJJHB_Key; // 0x8C
	private int PDLMMOJDBKM_Crypted = FBGGEFFJJHB_Key; // 0x90
	private int[] LHENMNBDFNM_WeeklyItem; // 0x94
	private string MJEPJCDOAML; // 0x98
	public IBJAKJJICBC.GFKEJIHPAOM AFCMIOIGAJN_EventInfo; // 0x9C
	public int LOFKFOCAJGB_Crypted = FBGGEFFJJHB_Key; // 0xA0
	public int DANJGFKGLNN_Crypted = FBGGEFFJJHB_Key; // 0xA4
	public IBJAKJJICBC.DLLJPHLOICN NOKBLCDMLPP_MinigameEventInfo; // 0xA8
	public sbyte FBMAAGJAGGG_Crypted = JFOFMKBJBBE_False; // 0xAC
	public sbyte OFFDABPBFBA_Crypted = JFOFMKBJBBE_False; // 0xAD
	public sbyte POKBBJHFNPI_Crypted = JFOFMKBJBBE_False; // 0xAE
	public sbyte LKBOJPIFOFK_Crypted = JFOFMKBJBBE_False; // 0xAF
	public sbyte BCEHBCFLHNL_Crypted = JFOFMKBJBBE_False; // 0xB0
	public sbyte PHKCAIAKPLG_Crypted = JFOFMKBJBBE_False; // 0xB1
	public long APCJGOEEBEB_OtherEndTimeCrypted = FBGGEFFJJHB_Key; // 0xB8
	public sbyte FEBKEKCEODK_Crypted = JFOFMKBJBBE_False; // 0xC0
	private int GNIHKFDDCOO_Crypted = FBGGEFFJJHB_Key; // 0xC4
	public bool GBNOALJPOBM; // 0xC8
	public long NJDCMCDEAPK_Crypted; // 0xD0

	public int GHBPLHBNMBK_FreeMusicId { get { return EPGOIGPKPPJ_FreeMusicIdCrypted ^ FBGGEFFJJHB_Key; } set { EPGOIGPKPPJ_FreeMusicIdCrypted = value ^ FBGGEFFJJHB_Key; } } //0x1213164 HKFCFPFPMBN 0x1213178 IFMPBFAAKNN
	public int DEPGBBJMFED_CategoryId { get { return HNEHIJCAOJM_CategoryIdCrypted ^ FBGGEFFJJHB_Key; } set { HNEHIJCAOJM_CategoryIdCrypted = value ^ FBGGEFFJJHB_Key; } } //0x121318C FNMFOBJIIIC 0x12131A0 OBEDPJLBBEG
	public bool CADENLBDAEB_IsNew { get { return ACKPOCNHOOP_Crypted == CNECJGKECHK_True; } set { ACKPOCNHOOP_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12131B4 KJGFPPLHLAB 0x12131C8 ILJHLPMDHPO
	public bool LDGOHPAPBMM_IsNew { get { return IFLNGLECALJ_Crypted == CNECJGKECHK_True; } set { IFLNGLECALJ_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12131F8 GEBJMDIJNAH 0x121320C JBMMFDLGCMC
	public bool CPBDGAGKNGH_UlNew { get { return MEPLEIEDBGE_Crypted == CNECJGKECHK_True; } set { MEPLEIEDBGE_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x121323C KJLPFJJHJPE 0x1213250 CLALHMCBPNF
	public int EKANGPODCEP_EventId { get { return EGCMPELNLKP_Crypted ^ FBGGEFFJJHB_Key; } set { EGCMPELNLKP_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x1213280 EBLAFEMDFGD 0x1213294 AHEFELNFBDM
	public int MNNHHJBBICA_GameEventType { get { return CEMGANMAOML_EventTypeCrypted ^ FBGGEFFJJHB_Key; } set { CEMGANMAOML_EventTypeCrypted = value ^ FBGGEFFJJHB_Key; } } //0x12132A8 FNEIPFMLBCB 0x12132BC IFKDECJEKGJ
	public int MFJKNCACBDG_OpenEventType { get { return NENONMAGGBP_Crypted ^ FBGGEFFJJHB_Key; } set { NENONMAGGBP_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x12132D0 HLAFCPHCBED 0x12132E4 FMLMCHDKIPP
	public int OEILJHENAHN_PlayEventType { get { return MJLNDHPNFHE_Crypted ^ FBGGEFFJJHB_Key; } set { MJLNDHPNFHE_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x12132F8 MGJDCGJMEKP 0x121330C IMJDLLMCMAH // MJLNDHPNFHE
	public int EEFLOOBOAGF { get { return PPDEOMLMEKC_Crypted ^ FBGGEFFJJHB_Key; } set { PPDEOMLMEKC_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x1213320 NLDELFLNODF 0x1213334 PEHLMNDKOEE
	public bool BJANNALFGGA_HasRanking { get { return IKGGKOFGMNC_Crypted == CNECJGKECHK_True; } set { IKGGKOFGMNC_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1213348 EPFAPPFDMJH 0x121335C AFBCHDAJIFL
	public bool OGHOPBAKEFE_IsEventSpecial { get { return CICKCGDKICN_Crypted == CNECJGKECHK_True; } set { CICKCGDKICN_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x121338C LNICBELKODE 0x12133A0 MMOFHBDNIFJ  CICKCGDKICN
	public int OPPBIOEJAND_EventMusicRank { get { return KAEIHNCACOD_Crypted ^ FBGGEFFJJHB_Key; } set { KAEIHNCACOD_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x12133D0 LPGPACOAGAM 0x12133E4 DFGJNJCLJKO
	public bool JOJPMFNJJPD_HasEventMusicRank { get { return MPDBHMLFLLA_Crypted == CNECJGKECHK_True; } set { MPDBHMLFLLA_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12133F8 MPMFLBPLMMN 0x121340C JDJIDAOAIB
	public bool JPOINGMJCGL { get { return JMFIOFIBLFH_Crypted == CNECJGKECHK_True; } set { JMFIOFIBLFH_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x121343C OOCNOAFIHIB 0x1213450 KKKFHLFKFCG   JMFIOFIBLFH
	public bool LHONOILACFL_IsWeeklyEvent { get { return CHOLAKGHAEN_IsWeelkyEventCrypted == CNECJGKECHK_True; } set { CHOLAKGHAEN_IsWeelkyEventCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1213480 PGKDJOCOJMK 0x1213494 JLOKCBHGIPA
	public long NKEIFPPGNLH_WeeklyendTime { get { return PMEGFLFDDKH_WeeklyEndTimeCrypted ^ FBGGEFFJJHB_Key; } set { PMEGFLFDDKH_WeeklyEndTimeCrypted = value ^ FBGGEFFJJHB_Key; } } //0x12134C4 GALMKGNOFDH 0x12134D8 AABJDLOOPOC
	public bool GDLNCHCPMCK_HasBoost { get { return NKKAIPDPEEI_HasBoostCrypted == CNECJGKECHK_True; } set { NKKAIPDPEEI_HasBoostCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12134F4 MGDNBNEHFAJ 0x1213508 CHLKHPGCIPB
	public bool NNJNNCGGKMC_IsLimited { get { return AJGIBNAJPJD_Crypted == CNECJGKECHK_True; } set { AJGIBNAJPJD_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1213538 IEIACJPPDOH 0x121354C APJCBPNGEHO
	public int KCKBOIDCPCK_CdSelectEvenType { get { return AFDHDBMKLJL_Crypted ^ FBGGEFFJJHB_Key; } set { AFDHDBMKLJL_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x121357C LIKAGINKECG 0x1213590 DDLKEDBBGCB
	public int JJEFMIHJMHC_CursorStepCount { get { return KOOODCKJNJO_Crypted ^ FBGGEFFJJHB_Key; } set { KOOODCKJNJO_Crypted = value ^ FBGGEFFJJHB_Key;} } //0x12135A4 BAPFJJJLHCC 0x12135B8 OGMOOIOKJHG
	public int BELHFPMBAPJ_WeekPlay { get { return NEBJMHHHDMO_Crypted ^ FBGGEFFJJHB_Key; } set { NEBJMHHHDMO_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x12136F4 HJBNBOJBKPO 0x1213708 LJLMDPIGCFJ
	public int JOJNGDPHOKG_WeeklyMax { get { return PDLMMOJDBKM_Crypted ^ FBGGEFFJJHB_Key; } set { PDLMMOJDBKM_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x121371C MBDGLMBPBEJ 0x1213730 JLIOGCHPNFJ
	public int MOJMEFIENDM_WeeklyEventCount { get { return (JOJNGDPHOKG_WeeklyMax) - (BELHFPMBAPJ_WeekPlay); } } //0x1213744 PBNIFHCLKNA
	public bool AJGCPCMLGKO_IsEvent { get { return AFCMIOIGAJN_EventInfo != null; } } //0x12141A8 LFBNCKMILGK
	public bool MNDFBBMNJGN_NoEnergy { get { return LOFKFOCAJGB_Crypted != FBGGEFFJJHB_Key; } } //0x12141B8 KLMOKPHBBOC  LOFKFOCAJGB
	// public int JKIADEKHGLC { get; set; } 0x12141D4 OMELGCEEHKD 0x12141E8 EJEGDHIDAHL  LOFKFOCAJGB
	public int DBJOBFIGGEE_EventBonusPercent { get { return DANJGFKGLNN_Crypted ^ FBGGEFFJJHB_Key; } set { DANJGFKGLNN_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x12141FC OCAMIMMBCLG 0x1214210 EGDEICLAEBO   DANJGFKGLNN
	public bool BNIAJAKIAJC_IsEventMinigame { get { return NOKBLCDMLPP_MinigameEventInfo != null; } } //0x1214224 ENAOGJDBGHC
	public bool KDAJEGNBOFJ { get {
			if (NOKBLCDMLPP_MinigameEventInfo != null)
				return true;
			return AFCMIOIGAJN_EventInfo != null;
		} } //0x1214234 HIODBIOCMAI
	public bool POEGGBGOKGI_IsInfoLiveEntrance { get { return FBMAAGJAGGG_Crypted == CNECJGKECHK_True; } set { FBMAAGJAGGG_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1214258 KODGDIIMPII 0x121426C GHDOJNEEOKO
	public bool PJLNJJIBFBN_HasExtremeDiff { get { return OFFDABPBFBA_Crypted == CNECJGKECHK_True; } set { OFFDABPBFBA_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x121429C GMGBFOAAHDD 0x12142B0 GHLFABPOFJK
	public bool LEBDMNIGOJB_IsScoreEvent { get { return POKBBJHFNPI_Crypted == CNECJGKECHK_True; } set { POKBBJHFNPI_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12142E0 HBEONMDJOOP 0x12142F4 FDGKGCJHPDA
	public bool HDPMAJKGIOI { get { return LKBOJPIFOFK_Crypted == CNECJGKECHK_True; } set { LKBOJPIFOFK_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1214324 CPGNHCPOKOB 0x1214338 AKHMGHGILEL   LKBOJPIFOFK
	public bool LGIGMPBHJCI { get { return BCEHBCFLHNL_Crypted == CNECJGKECHK_True; } set { BCEHBCFLHNL_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1214368 EOAGNJADCPB 0x121437C NAEDALBFMPK   BCEHBCFLHNL
	public bool FGKMJHKLGLD { get { return PHKCAIAKPLG_Crypted == CNECJGKECHK_True; } set { PHKCAIAKPLG_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12143AC IEPMIAMGFIJ 0x12143C0 GAAOGMPFCFN
	public long ALMOMLMCHNA_OtherEndTime { get { return APCJGOEEBEB_OtherEndTimeCrypted ^ FBGGEFFJJHB_Key; } set { APCJGOEEBEB_OtherEndTimeCrypted = value ^ FBGGEFFJJHB_Key; } } //0x12143F0 BHKAHGNFCEN 0x1214404 LOJIKNJAGIO
	public bool EHNGOGBJMGL { get { return FEBKEKCEODK_Crypted == CNECJGKECHK_True; } set { FEBKEKCEODK_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1214550 FDIMEFOAOAP 0x1214564 HCNELALHKNN
	private int AAODIMMEFBI { get { return GNIHKFDDCOO_Crypted ^ FBGGEFFJJHB_Key; } set { GNIHKFDDCOO_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x1214594 IHMBMOACINF 0x12145A8 OJLEJOKHKFP
	public long IHPCKOMBGKJ_End { get { return NJDCMCDEAPK_Crypted ^ FBGGEFFJJHB_Key; } set { NJDCMCDEAPK_Crypted = value ^ FBGGEFFJJHB_Key; } } //0x12145FC KMCBIJLEDNH 0x1214610 GCEGLPAGDGI
	public List<ANJLFFPBAEF_DifficultyInfo> MGJKEJHEBPO_DiffInfos { get; set; } // 0xD8 DPHOPMPKAHK BNPJIIPJJLJ HOKDNOFCDHM

	// // RVA: 0x12135CC Offset: 0x12135CC VA: 0x12135CC
	// public int NOEIIMGDDKK() { }

	// // RVA: 0x1213764 Offset: 0x1213764 VA: 0x1213764
	public void IEBGBOBPJMB(int NGDGGPCLPKC)
	{
		BELHFPMBAPJ_WeekPlay = Mathf.Clamp(BELHFPMBAPJ_WeekPlay - NGDGGPCLPKC, 0, JOJNGDPHOKG_WeeklyMax);
	}

	// // RVA: 0x1213814 Offset: 0x1213814 VA: 0x1213814
	public int ICHJBDPJNMA_GetWeeklyItem(WeekdayEventAttr.Type INDDJNMPONH, int IKPIDCFOFEA)
	{
		if(INDDJNMPONH != 0 && LHENMNBDFNM_WeeklyItem != null)
		{
			return LHENMNBDFNM_WeeklyItem[IKPIDCFOFEA];
		}
		return 0;
	}

	// // RVA: 0x1213860 Offset: 0x1213860 VA: 0x1213860
	public int LMPNAPIGAEA(WeekdayEventAttr.Type INDDJNMPONH)
	{
		if (INDDJNMPONH == WeekdayEventAttr.Type.None || ICHJBDPJNMA_GetWeeklyItem(INDDJNMPONH, 2) == 0)
			return 0;
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(ICHJBDPJNMA_GetWeeklyItem(INDDJNMPONH, 2));
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
		{
			return OHCAABOMEOF.LDGFHMMAFOC(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENMHPBGOOII_Week, 6);
		}
		else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
		{
			int a = 1;
			int a2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NKDGLGCAPEI_GrowItem.CDENCMNHNGA_GrowItemList[EKLNMHFCAOI.DEACAHNLMNI_getItemId(ICHJBDPJNMA_GetWeeklyItem(INDDJNMPONH, 2)) - 1].INDDJNMPONH;
			if (a2 >= 2 && a2 < 6)
				a = new int[4] { 4, 3, 5, 2 }[a2 - 2];
			return OHCAABOMEOF.LDGFHMMAFOC(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENMHPBGOOII_Week, a);
		}
		return 0;
	}

	// // RVA: 0x1213A74 Offset: 0x1213A74 VA: 0x1213A74
	public string CIOCOOMCMKO(WeekdayEventAttr.Type INDDJNMPONH)
	{
		int a = LMPNAPIGAEA(INDDJNMPONH);
		if (a >= 5001 && a < 5007)
		{
			return MJEPJCDOAML + "_rule_" + (a % 5000);
		}
		return null;
	}

	// // RVA: 0x1213B4C Offset: 0x1213B4C VA: 0x1213B4C
	private void KDPFCMAALPO(int GHBPLHBNMBK, bool GIKLNODJKFK)
	{
		LHENMNBDFNM_WeeklyItem = new int[3];
		KEODKEGFDLD_FreeMusicInfo fminfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK);
		int a1 = fminfo.ONLFLGPMAAN_GetRareRateId(GIKLNODJKFK);
		OPGDJANLKBM_RateInfo rarerate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.ABNFGCEDJIM_RareRate.Find((OPGDJANLKBM_RateInfo GHPLINIACBB) =>
		{
			//0x122023C
			return GHPLINIACBB.BFOLFCOBBJD_RId == a1;
		});
		HNJKJCDDIMG_SetInfo rareset = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.LMILCGIFPGC_RareSet.Find((HNJKJCDDIMG_SetInfo GHPLINIACBB) =>
		{
			//0x1220274
			return GHPLINIACBB.LIHEBNPAIFI_SId == fminfo.JCDKMICANJO_RareSetId;
		});
		HNJKJCDDIMG_SetInfo set = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.KPEOJPKLJBH_Set.Find((HNJKJCDDIMG_SetInfo GHPLINIACBB) =>
		{
			//0x12202D8
			return GHPLINIACBB.LIHEBNPAIFI_SId == fminfo.MGLDIOILOFF_NormalSetId;
		});
		int a2 = fminfo.KDIKCKEEPDA_GetNormalRateId(GIKLNODJKFK);
		OPGDJANLKBM_RateInfo rate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop.FDCBLEDPHBM_Rate.Find((OPGDJANLKBM_RateInfo GHPLINIACBB) =>
		{
			//0x122033C
			return GHPLINIACBB.BFOLFCOBBJD_RId == a2;
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
				if(rate.ADKDHKMPMHP_Rate[i] > 0)
				{
					if(rate.HMFFHLPNMPH_Cnt[i] > 0)
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
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if ((ALMOMLMCHNA_OtherEndTime - time) != 0)
				return ALMOMLMCHNA_OtherEndTime - time;
		}
		return -1;
	}

	// // RVA: 0x12145BC Offset: 0x12145BC VA: 0x12145BC
	// public void OFAPIHAJDOH(int GHBPLHBNMBK) { }

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
	// public bool ICKDCAMABPD(int OGPKGGLJACK) { }

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
	public bool JHLDFOLFNGB(Difficulty.Type AKNELONELJK, bool NGKGFBLFEGH)
	{
		bool res = false;
		if((int)AKNELONELJK < MGJKEJHEBPO_DiffInfos.Count)
		{
			int score = MGJKEJHEBPO_DiffInfos[(int)AKNELONELJK].KNIFCANOHOC_Score;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId).EMJCHPDJHEI(NGKGFBLFEGH, (int)AKNELONELJK).DLPBHJALHCK_GetScoreRank(score) == 4)
				return true;
		}
		return res;
	}

	// // RVA: 0x1214AE0 Offset: 0x1214AE0 VA: 0x1214AE0
	public void KHEKNNFCAOI(int GHBPLHBNMBK, bool HCIKDFECJGE = false, int NLKONOBBDJK = 0, int IOFOHHOJCBE = 0, long JHNMKKNEENE = 0, bool PJLNJJIBFBN = false, bool LICNKMNIKBF = false, bool GIKLNODJKFK = false)
	{
		GHBPLHBNMBK_FreeMusicId = GHBPLHBNMBK;
		KEODKEGFDLD_FreeMusicInfo musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[GHBPLHBNMBK - 1];
		base.KHEKNNFCAOI(musicInfo.DLAEJOBELBH_MusicId);
		EONOEHOKBEB_Music musicInfo2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[musicInfo.DLAEJOBELBH_MusicId - 1];
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo saveInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK - 1];
		DEPGBBJMFED_CategoryId = musicInfo.DEPGBBJMFED_CategoryId;
		EKANGPODCEP_EventId = 0;
		this.PJLNJJIBFBN_HasExtremeDiff = PJLNJJIBFBN;
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
			KDPFCMAALPO(GHBPLHBNMBK, GIKLNODJKFK);
			IHKFMJDOBAH_WeekDayAttr = (WeekdayEventAttr.Type)(NLKONOBBDJK + 1);
			LHONOILACFL_IsWeeklyEvent = true;
			MJEPJCDOAML = "";
			DKCJADHKGAN_EventWeekDay.JFFPEKOEINE weekData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CLLPBOPLICM_EventWeekDay.PPIBJECKCEF(JHNMKKNEENE);
			if (weekData != null)
			{
				MJEPJCDOAML = weekData.CIOJJBOHEEJ;
			}
			DateTime date = Utility.GetLocalDateTime(JHNMKKNEENE);
			NKEIFPPGNLH_WeeklyendTime = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0) + 86400;
			BELHFPMBAPJ_WeekPlay = saveInfo.FECIGAOOFBE_Wply;
			JOJNGDPHOKG_WeeklyMax = IOFOHHOJCBE;
			EKANGPODCEP_EventId = LMPNAPIGAEA(IHKFMJDOBAH_WeekDayAttr);
		}
		EEFLOOBOAGF = musicInfo.EEFLOOBOAGF;
		LDGOHPAPBMM_IsNew = true;
		MGJKEJHEBPO_DiffInfos = new List<ANJLFFPBAEF_DifficultyInfo>();
		int count = PJLNJJIBFBN ? 5 : 4;
		// if false weird L248, looks like do nothing
		// weird loop too here // L269
		bool hasValue2 = musicInfo.GBNOALJPOBM;
		bool hasValue = true;
		for (int i = 0; i < count; i++)
		{
			ANJLFFPBAEF_DifficultyInfo info = new ANJLFFPBAEF_DifficultyInfo();
			info.HPBPDHPIBGN_EnemyData = new EJKBKMBJMGL_EnemyData();
			int val = 0;
			if(!GIKLNODJKFK)
			{
				info.KNIFCANOHOC_Score = saveInfo.BDCAICINCKK_GetScoreForDiff(i);
				info.NLKEBAOBJCM_Combo = saveInfo.NLKEBAOBJCM_Combo[i];
				info.JNLKJCDFFMM_Clear = saveInfo.JNLKJCDFFMM_Clear[i];
				info.LCOHGOIDMDF_ComboRank = saveInfo.LAMCCNAKIOJ_CbRnk[i];
				info.HPBPDHPIBGN_EnemyData.KHEKNNFCAOI(musicInfo.LHICAKGHIGF_EnemyIdByDiff[i], musicInfo.LJPKLMJPLAC[i]);
				val = saveInfo.EMHFDJEFIHG_Play[i];
			}
			else
			{
				info.KNIFCANOHOC_Score = saveInfo.AHDKMPFDKPE_GetScoreL6_ForDiff(i);
				info.NLKEBAOBJCM_Combo = saveInfo.DNIGPFPHJAK_ComboL6[i];
				info.JNLKJCDFFMM_Clear = saveInfo.DPPCFFFNBGA_ClearL6[i];
				info.LCOHGOIDMDF_ComboRank = saveInfo.EEECMKPLPNL_CbRnkL6[i];
				info.HPBPDHPIBGN_EnemyData.KHEKNNFCAOI(musicInfo.PJNFOCDANCE_EnemyIdByDiffL6[i], musicInfo.ILCJOOPIILK[i]);
				val = saveInfo.FHFKOGIPAEH_PlayL6[i];
			}
			if((info.JNLKJCDFFMM_Clear) < 1)
			{
				if(val > 0)
				{
					info.CMCKNKKCNDK_Status = 2;
					LDGOHPAPBMM_IsNew = false;
				}
				else
				{
					info.CMCKNKKCNDK_Status = 1;
				}
			}
			else
			{
				info.CMCKNKKCNDK_Status = 3;
				LDGOHPAPBMM_IsNew = false;
			}
			info.HHMLMKAEJBJ_Score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(musicInfo2.KKPAHLMJKIH_WavId, musicInfo2.BKJGCEOEPFB_VariationId, i, GIKLNODJKFK, true);
			if(info.HHMLMKAEJBJ_Score != null)
			{
				info.BAKLKJLPLOJ = musicInfo.EMJCHPDJHEI(GIKLNODJKFK, i);
				info.BPLOEAHOPFI_Energy = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.HHEEPBJNAKA_GetEnergy(info.HHMLMKAEJBJ_Score.ANAJIAENLNB_MusicLevel, GIKLNODJKFK);
				MGJKEJHEBPO_DiffInfos.Add(info);
			}
			hasValue = hasValue & (saveInfo.EMHFDJEFIHG_Play[i] < 1);
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
		AAODIMMEFBI = HighScoreRating.GetUtaRate(GHBPLHBNMBK);
		KCKBOIDCPCK_CdSelectEvenType = 0;
		JJEFMIHJMHC_CursorStepCount = 0;
		GBNOALJPOBM = musicInfo.GBNOALJPOBM;
	}

	// // RVA: 0x1215B3C Offset: 0x1215B3C VA: 0x1215B3C
	private void FAEBEJENNHD(IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		GHBPLHBNMBK_FreeMusicId = 0;
		MGJKEJHEBPO_DiffInfos = new List<ANJLFFPBAEF_DifficultyInfo>();
		AFCMIOIGAJN_EventInfo = new GFKEJIHPAOM();
		if(LIKDEHHKFEH != null)
		{
			AFCMIOIGAJN_EventInfo.KINJOEIAHFK_OpenTime = LIKDEHHKFEH.GLIMIGNNGGB_Start;
			AFCMIOIGAJN_EventInfo.PCCFAKEOBIC_CloseTime = LIKDEHHKFEH.DPJCPDKALGI_End1;
			AFCMIOIGAJN_EventInfo.EMEKFFHCHMH_End = LIKDEHHKFEH.EMEKFFHCHMH_End;
			AFCMIOIGAJN_EventInfo.OPFGFINHFCE_EventName = LIKDEHHKFEH.DGCOMDILAKM_EventName;
			AFCMIOIGAJN_EventInfo.KLMPFGOCBHC_EventDesc = LIKDEHHKFEH.FBHONHONKGD_MusicSelectDesc;
			AFCMIOIGAJN_EventInfo.GOAPADIHAHG_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory = LIKDEHHKFEH.HIDHLFCBIDE_EventType;
			EKANGPODCEP_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			KKPAHLMJKIH_WavId = LIKDEHHKFEH.EDNMFMBLCGF_GetWavId();
			OBGKIMDIAJF_CheckIsDlded();
			if(LIKDEHHKFEH.MPMKJNJGFEF_IsEntry())
				CADENLBDAEB_IsNew = false;
		}
	}

	// // RVA: 0x1215D48 Offset: 0x1215D48 VA: 0x1215D48
	private void OKLGJBKAJGH(IKDICBBFBMI_EventBase LIKDEHHKFEH, int OOCBPMNHLPM)
	{
		GHBPLHBNMBK_FreeMusicId = 0;
		MGJKEJHEBPO_DiffInfos = new List<ANJLFFPBAEF_DifficultyInfo>();
		NOKBLCDMLPP_MinigameEventInfo = new DLLJPHLOICN();
		if(LIKDEHHKFEH != null)
		{
			NOKBLCDMLPP_MinigameEventInfo.KINJOEIAHFK_OpenTime = LIKDEHHKFEH.GLIMIGNNGGB_Start;
			NOKBLCDMLPP_MinigameEventInfo.PCCFAKEOBIC_CloseTime = LIKDEHHKFEH.DPJCPDKALGI_End1;
			NOKBLCDMLPP_MinigameEventInfo.EMEKFFHCHMH_End = LIKDEHHKFEH.EMEKFFHCHMH_End;
			NOKBLCDMLPP_MinigameEventInfo.OPFGFINHFCE_EventName = LIKDEHHKFEH.DGCOMDILAKM_EventName;
			NOKBLCDMLPP_MinigameEventInfo.KLMPFGOCBHC_EventDesc = LIKDEHHKFEH.FBHONHONKGD_MusicSelectDesc;
			NOKBLCDMLPP_MinigameEventInfo.GOAPADIHAHG_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			NOKBLCDMLPP_MinigameEventInfo.HIDHLFCBIDE_EventCategory = LIKDEHHKFEH.HIDHLFCBIDE_EventType;
			NOKBLCDMLPP_MinigameEventInfo.OOCBPMNHLPM_MusicId = OOCBPMNHLPM;
			EKANGPODCEP_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			KKPAHLMJKIH_WavId = LIKDEHHKFEH.EDNMFMBLCGF_GetWavId();
			OBGKIMDIAJF_CheckIsDlded();
			if (LIKDEHHKFEH.MPMKJNJGFEF_IsEntry())
				CADENLBDAEB_IsNew = false;
		}
	}

	// // RVA: 0x1215F78 Offset: 0x1215F78 VA: 0x1215F78
	public void PMKBMGNAJIL(HLEBAINCOME_EventScore LIKDEHHKFEH, bool GIKLNODJKFK)
	{
		TodoLogger.LogError(TodoLogger.EventScore_4, "Event Score");
	}

	// // RVA: 0x1216BB0 Offset: 0x1216BB0 VA: 0x1216BB0
	private void EAHJLJOMFMG(int EPLEIPFGGHP, HAEDCCLHEMN_EventBattle LIKDEHHKFEH, bool GIKLNODJKFK)
	{
		GHBPLHBNMBK_FreeMusicId = LIKDEHHKFEH.PIPHAKNMIBL_Rivals[EPLEIPFGGHP].GOIKCKHMBDL_FreeMusicId;
		KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[GHBPLHBNMBK_FreeMusicId - 1];
		base.KHEKNNFCAOI(m.DLAEJOBELBH_MusicId);
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
		bool b2 = m.GBNOALJPOBM;
		MGJKEJHEBPO_DiffInfos = new List<ANJLFFPBAEF_DifficultyInfo>();
		DACLONHOFLA = new BKKMNPEEILG();
		int cnt = PJLNJJIBFBN_HasExtremeDiff ? 5 : 4; 
		DACLONHOFLA.KHEKNNFCAOI(LIKDEHHKFEH, EPLEIPFGGHP);
		bool b = true;
		for(int diffIdx = 0; diffIdx < cnt; diffIdx++)
		{
			ANJLFFPBAEF_DifficultyInfo diff = new ANJLFFPBAEF_DifficultyInfo();
			diff.HPBPDHPIBGN_EnemyData = new EJKBKMBJMGL_EnemyData();
			if(!GIKLNODJKFK)
			{
				if(data != null)
				{
					diff.KNIFCANOHOC_Score = data.BDCAICINCKK_GetScoreForDiff(diffIdx);
					diff.NLKEBAOBJCM_Combo = data.NLKEBAOBJCM_ComboByDiff[diffIdx];
					diff.JNLKJCDFFMM_Clear = data.JNLKJCDFFMM_ClearByDiff[diffIdx];
					diff.EMHFDJEFIHG_Play = data.EMHFDJEFIHG_PlayByDiff[diffIdx];
					diff.LCOHGOIDMDF_ComboRank = data.LAMCCNAKIOJ_ComboRankByDiff[diffIdx];
				}
				diff.HPBPDHPIBGN_EnemyData.KHEKNNFCAOI(m.LHICAKGHIGF_EnemyIdByDiff[diffIdx], m.LJPKLMJPLAC[diffIdx]);
			}
			else
			{
				if(data != null)
				{
					diff.KNIFCANOHOC_Score = data.AHDKMPFDKPE_GetScoreForDiffL6(diffIdx);
					diff.NLKEBAOBJCM_Combo = data.DNIGPFPHJAK_ComboByDiffL6[diffIdx];
					diff.JNLKJCDFFMM_Clear = data.DPPCFFFNBGA_ClearByDiffL6[diffIdx];
					diff.EMHFDJEFIHG_Play = data.FHFKOGIPAEH_PlayByDiffL6[diffIdx];
					diff.LCOHGOIDMDF_ComboRank = data.EEECMKPLPNL_ComboRankByDiffL6[diffIdx];
				}
				diff.HPBPDHPIBGN_EnemyData.KHEKNNFCAOI(m.PJNFOCDANCE_EnemyIdByDiffL6[diffIdx], m.ILCJOOPIILK[diffIdx]);
			}
			if(diff.JNLKJCDFFMM_Clear < 1)
			{
				if(diff.EMHFDJEFIHG_Play > 0)
				{
					diff.CMCKNKKCNDK_Status = 2;
					LDGOHPAPBMM_IsNew = false;
				}
				else
				{
					diff.CMCKNKKCNDK_Status = 1;
				}
			}
			else
			{
				diff.CMCKNKKCNDK_Status = 3;
				LDGOHPAPBMM_IsNew = false;
			}
			diff.HHMLMKAEJBJ_Score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(m2.KKPAHLMJKIH_WavId, m2.BKJGCEOEPFB_VariationId, diffIdx, GIKLNODJKFK, true);
			diff.BAKLKJLPLOJ = m.EMJCHPDJHEI(GIKLNODJKFK, diffIdx);
			diff.BPLOEAHOPFI_Energy = LIKDEHHKFEH.KGIIPFJIAGB_GetPlayCost(diffIdx, GIKLNODJKFK);
			MGJKEJHEBPO_DiffInfos.Add(diff);
			b &= data.EMHFDJEFIHG_PlayByDiff[diffIdx] < 1;
			b2 &= data.FHFKOGIPAEH_PlayByDiffL6[diffIdx] < 1;
		}
		CADENLBDAEB_IsNew = b || b2 || CPBDGAGKNGH_UlNew;
		GBNOALJPOBM = m.GBNOALJPOBM;
	}

	// // RVA: 0x12176B8 Offset: 0x12176B8 VA: 0x12176B8
	private void NIIMCBEJHDE(AMLGMLNGMFB_EventAprilFool LIKDEHHKFEH, int MNKCJGIGPJP, bool GIKLNODJKFK_IsLine6)
	{
		GHBPLHBNMBK_FreeMusicId = MNKCJGIGPJP;
		KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[MNKCJGIGPJP - 1];
		base.KHEKNNFCAOI(m.DLAEJOBELBH_MusicId);
		EONOEHOKBEB_Music m2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.INJDLHAEPEK_GetMusicInfo(GHBPLHBNMBK_FreeMusicId, m.DLAEJOBELBH_MusicId);
		JNCPEGJGHOG_JacketId = m2.JNCPEGJGHOG_Cov;
		BNCMJNMIDIN_AvaiableDivaModes = FFJPJEMCGKK(m2);
		DEPGBBJMFED_CategoryId = m.DEPGBBJMFED_CategoryId;
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo saveMusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_FreeMusicId - 1];
		EKANGPODCEP_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
		LEBDMNIGOJB_IsScoreEvent = false;
		FGKMJHKLGLD = true;
		OEILJHENAHN_PlayEventType = 10;
		BJANNALFGGA_HasRanking = false;
		KCKBOIDCPCK_CdSelectEvenType = 0;
		PJLNJJIBFBN_HasExtremeDiff = LIKDEHHKFEH.PJLNJJIBFBN;
		int jacketRibbonType = LIKDEHHKFEH.IBFAJICMLGF_GetJacketRibbonType();
		if (jacketRibbonType > 0)
		{
			KCKBOIDCPCK_CdSelectEvenType = (int)LIKDEHHKFEH.CFLLOAEALGN_GetMusicEventType(jacketRibbonType) + 1;
		}
		LDGOHPAPBMM_IsNew = true;
		MGJKEJHEBPO_DiffInfos = new List<ANJLFFPBAEF_DifficultyInfo>();
		int c = 4;
		if (PJLNJJIBFBN_HasExtremeDiff)
			c = 5;
		bool b1 = m.GBNOALJPOBM;
		bool b2 = true;
		for(int i = 0; i < c; i++)
		{
			ANJLFFPBAEF_DifficultyInfo data = new ANJLFFPBAEF_DifficultyInfo();
			data.HPBPDHPIBGN_EnemyData = new EJKBKMBJMGL_EnemyData();
			int numPlay = 0;
			if(!GIKLNODJKFK_IsLine6)
			{
				if(saveMusic != null)
				{
					data.KNIFCANOHOC_Score = saveMusic.BDCAICINCKK_GetScoreForDiff(i);
					data.NLKEBAOBJCM_Combo = saveMusic.NLKEBAOBJCM_Combo[i];
					data.JNLKJCDFFMM_Clear = saveMusic.JNLKJCDFFMM_Clear[i];
					data.LCOHGOIDMDF_ComboRank = saveMusic.LAMCCNAKIOJ_CbRnk[i];
					numPlay = saveMusic.EMHFDJEFIHG_Play[i];
				}
				data.HPBPDHPIBGN_EnemyData.KHEKNNFCAOI(m.LHICAKGHIGF_EnemyIdByDiff[i], m.LJPKLMJPLAC[i]);

			}
			else
			{
				if(saveMusic != null)
				{
					data.KNIFCANOHOC_Score = saveMusic.AHDKMPFDKPE_GetScoreL6_ForDiff(i);
					data.NLKEBAOBJCM_Combo = saveMusic.DNIGPFPHJAK_ComboL6[i];
					data.JNLKJCDFFMM_Clear = saveMusic.DPPCFFFNBGA_ClearL6[i];
					data.LCOHGOIDMDF_ComboRank = saveMusic.EEECMKPLPNL_CbRnkL6[i];
					numPlay = saveMusic.FHFKOGIPAEH_PlayL6[i];
				}
				data.HPBPDHPIBGN_EnemyData.KHEKNNFCAOI(m.PJNFOCDANCE_EnemyIdByDiffL6[i], m.ILCJOOPIILK[i]);
			}
			if(data.JNLKJCDFFMM_Clear < 1)
			{
				if(numPlay > 0)
				{
					data.CMCKNKKCNDK_Status = 2;
					LDGOHPAPBMM_IsNew = false;
				}
				else
				{
					data.CMCKNKKCNDK_Status = 1;
				}
			}
			else
			{
				data.CMCKNKKCNDK_Status = 3;
				LDGOHPAPBMM_IsNew = false;
			}
			data.HHMLMKAEJBJ_Score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(m2.KKPAHLMJKIH_WavId, m2.BKJGCEOEPFB_VariationId, i, GIKLNODJKFK_IsLine6, true);
			data.BAKLKJLPLOJ = m.EMJCHPDJHEI(GIKLNODJKFK_IsLine6, i);
			data.BPLOEAHOPFI_Energy = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.HHEEPBJNAKA_GetEnergy(data.HHMLMKAEJBJ_Score.ANAJIAENLNB_MusicLevel, GIKLNODJKFK_IsLine6);
			MGJKEJHEBPO_DiffInfos.Add(data);
			b1 &= saveMusic.EMHFDJEFIHG_Play[i] == 0;
			b2 &= saveMusic.FHFKOGIPAEH_PlayL6[i] == 0;
		}
		CADENLBDAEB_IsNew = b1 || b2;
		if (CPBDGAGKNGH_UlNew)
		{
			CADENLBDAEB_IsNew = true;
			LDGOHPAPBMM_IsNew = true;
		}
		GBNOALJPOBM = m.GBNOALJPOBM;
	}

	// // RVA: 0x1218364 Offset: 0x1218364 VA: 0x1218364
	// private void FILJLEHKBJO(int KHCGNGEJLKC) { }

	// // RVA: 0x1218420 Offset: 0x1218420 VA: 0x1218420
	private void JBOHCKEIHKI(int GHBPLHBNMBK, long JIHKOPIENAC, bool PJLNJJIBFBN, int PGIIDPEGGPI)
	{
		GHBPLHBNMBK_FreeMusicId = GHBPLHBNMBK;
		KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[GHBPLHBNMBK_FreeMusicId - 1];
		base.KHEKNNFCAOI(m.DLAEJOBELBH_MusicId);
		EONOEHOKBEB_Music m2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[m.DLAEJOBELBH_MusicId - 1];
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_FreeMusicId - 1];
		DEPGBBJMFED_CategoryId = m.DEPGBBJMFED_CategoryId;
		EKANGPODCEP_EventId = PGIIDPEGGPI;
		LHONOILACFL_IsWeeklyEvent = false;
		BJANNALFGGA_HasRanking = false;
		EHNGOGBJMGL = true;
		this.PJLNJJIBFBN_HasExtremeDiff = PJLNJJIBFBN;
		EEFLOOBOAGF = m.EEFLOOBOAGF;
		CADENLBDAEB_IsNew = false;
		ALMOMLMCHNA_OtherEndTime = JIHKOPIENAC;
		MGJKEJHEBPO_DiffInfos = new List<ANJLFFPBAEF_DifficultyInfo>();
		int diffNum = 4;
		if (PJLNJJIBFBN)
			diffNum = 5;
		for(int i = 0; i < diffNum; i++)
		{
			ANJLFFPBAEF_DifficultyInfo data = new ANJLFFPBAEF_DifficultyInfo();
			data.KNIFCANOHOC_Score = save.BDCAICINCKK_GetScoreForDiff(i);
			data.NLKEBAOBJCM_Combo = save.NLKEBAOBJCM_Combo[i];
			data.JNLKJCDFFMM_Clear = save.JNLKJCDFFMM_Clear[i];
			data.LCOHGOIDMDF_ComboRank = save.LAMCCNAKIOJ_CbRnk[i];
			data.HPBPDHPIBGN_EnemyData = new EJKBKMBJMGL_EnemyData();
			data.HPBPDHPIBGN_EnemyData.KHEKNNFCAOI(m.LHICAKGHIGF_EnemyIdByDiff[i], m.LJPKLMJPLAC[i]);
			data.CMCKNKKCNDK_Status = 1;
			data.HHMLMKAEJBJ_Score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(m2.KKPAHLMJKIH_WavId, m2.BKJGCEOEPFB_VariationId, i, false, true);
			if(data.HHMLMKAEJBJ_Score != null)
			{
				data.BAKLKJLPLOJ = m.EMJCHPDJHEI(false, i);
				data.BPLOEAHOPFI_Energy = 0;
				MGJKEJHEBPO_DiffInfos.Add(data);
			}
		}
		KCKBOIDCPCK_CdSelectEvenType = 0;
		IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(PGIIDPEGGPI);
		if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
		{
			AMLGMLNGMFB_EventAprilFool af = ev as AMLGMLNGMFB_EventAprilFool;
			int a = af.IBFAJICMLGF_GetJacketRibbonType();
			if(a > 0)
			{
				KCKBOIDCPCK_CdSelectEvenType = (int)(af.CFLLOAEALGN_GetMusicEventType(a) + 1);
			}
		}
		GBNOALJPOBM = m.GBNOALJPOBM;
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
				return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[v - 1].HALOKFOJMLA_IsCompleted;
			}
			JPCKBFBCJKD data = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.LLJOPJMIGPD(GHBPLHBNMBK_FreeMusicId);
			if (data == null)
				return true;
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.EOHHFADHHBL_Complete)
			{
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAAMKEJKPPL(data, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level);
			}
		}

		return false;
	}

	// // RVA: 0x1219160 Offset: 0x1219160 VA: 0x1219160
	private void NPEKPHAFMGE_SetupEnemies(int CPBFAMJEODF, int MGHPJNNDCIG)
	{
		for(int i = 0; i < MGJKEJHEBPO_DiffInfos.Count; i++)
		{
			MGJKEJHEBPO_DiffInfos[i].HPBPDHPIBGN_EnemyData.NPEKPHAFMGE_OverrideSkill(CPBFAMJEODF, MGHPJNNDCIG);
		}
	}

	// // RVA: 0x1219268 Offset: 0x1219268 VA: 0x1219268
	public static List<int> CJHOOLJFGFB()
	{
		int cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas.Count;
		int cnt2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count;
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
	// private static bool OOGGDHGFBGG(OHCAABOMEOF.KGOGMKMBCPP INDDJNMPONH) { }

	// // RVA: 0x12195D0 Offset: 0x12195D0 VA: 0x12195D0
	public static List<IBJAKJJICBC> FKDIMODKKJD(int DEPGBBJMFED_Serie, long JHNMKKNEENE_Date, bool OJEBNBLHPNP = true, bool EHBPHDPHPKF = false, bool JNBMBDFKEOI = false, bool JCOJKAHFADL = false)
    {
		int saveMusicCount = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count;
		int numSongs = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas.Count;
		if(saveMusicCount < numSongs)
		{
			numSongs = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count;
		}
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
		OHCAABOMEOF.KGOGMKMBCPP_EventType type = 0;
		if (DEPGBBJMFED_Serie != 5)
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
							type = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0;
					}
				}
			}
			HLEBAINCOME_EventScore eventScore = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) as HLEBAINCOME_EventScore;
			if (eventScore != null)
			{
				TodoLogger.LogError(TodoLogger.EventScore_4, "FKDIMODKKJD (generate song list event)");
			}
			List<IKDICBBFBMI_EventBase> list2 = DJPFFHLCCNL(OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool, JHNMKKNEENE_Date, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6);
			for (int i = 0; i < list2.Count; i++)
			{
				AMLGMLNGMFB_EventAprilFool af = list2[i] as AMLGMLNGMFB_EventAprilFool;
				if (af.NDIILFIFCDL_GetMinigameId() < 1)
				{
					List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l = af.KOBMFPACBMB();
					for (int j = 0; j < l.Count; j++)
					{
						IBJAKJJICBC data = new IBJAKJJICBC();
						data.NIIMCBEJHDE(af, l[j].MPLGPBNJDJB_FreeMusicId, JCOJKAHFADL);
						int enSkill = l[j].MLKFDMFDFCE_EnemyCSkill;
						if (enSkill < 1)
							enSkill = l[j].DKOPDNHDLIA_EnemyLSkill;
						if (enSkill > 0) // ?? not sure
						{
							data.NPEKPHAFMGE_SetupEnemies(l[j].MLKFDMFDFCE_EnemyCSkill, l[j].DKOPDNHDLIA_EnemyLSkill);
						}
						data.OGHOPBAKEFE_IsEventSpecial = true;
						data.JJEFMIHJMHC_CursorStepCount = l[j].LGADCGFMLLD_Step;
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
								if (!JCOJKAHFADL || data.GBNOALJPOBM)
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
		DKCJADHKGAN_EventWeekDay.JFFPEKOEINE ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CLLPBOPLICM_EventWeekDay.PPIBJECKCEF(JHNMKKNEENE_Date);
		DateTime time = Utility.GetLocalDateTime(JHNMKKNEENE_Date);
		for (int i = 0; i < numSongs; i++)
		{
			KEODKEGFDLD_FreeMusicInfo musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[i];
			if (musicInfo.PPEGAKEIEGM_Enabled == 2)
			{
				if (musicInfo.GBNOALJPOBM || !JCOJKAHFADL)
				{
					if (DEPGBBJMFED_Serie != -1)
					{
						if (musicInfo.DEPGBBJMFED_CategoryId != DEPGBBJMFED_Serie)
						{
							continue;
						}
					}
					bool b = false;
					int val = 0;
					bool b2 = false;
					bool ok = false;
					if (DEPGBBJMFED_Serie == 5)
					{
						if (ev != null && ev.FLPDCNBLOKL_IsSongForWeekDay((int)time.DayOfWeek, musicInfo.GHBPLHBNMBK_FreeMusicId))
						{
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[i].FKBPJCDBDAG_SetWeekEventServerDate(JHNMKKNEENE_Date);
							//Setup vars
							//L311
							b = true;
							val = ev.AEHCKNNGAKF_BonusMaxCount + ev.ELEPHBOKIGK_MaxCount;
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
							if (!LBHPMGDNPHK_IsMusicOpen(musicInfo.GHBPLHBNMBK_FreeMusicId, DEPGBBJMFED_Serie))
								continue;
						}
					}
					if (ok)
					{
						IBJAKJJICBC songInfo = new IBJAKJJICBC();
						songInfo.KHEKNNFCAOI(musicInfo.GHBPLHBNMBK_FreeMusicId, b, (int)time.DayOfWeek, val, JHNMKKNEENE_Date, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.FPGDAPAILAK_ExtremeUnlock == 2, false, JCOJKAHFADL);
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
		if (DEPGBBJMFED_Serie != 5)
		{
			res.Sort((IBJAKJJICBC HKICMNAACDA, IBJAKJJICBC BNKHBCBJBKI) =>
			{
				//0x1220084
				return HKICMNAACDA.EEFLOOBOAGF.CompareTo(BNKHBCBJBKI.EEFLOOBOAGF);
			});
			return res;
		}
		if (!JNBMBDFKEOI)
			return res;
		List<IBJAKJJICBC> list = LIENJMIJMIE(JHNMKKNEENE_Date, JCOJKAHFADL);
		for (int i = 0; i < list.Count; i++)
		{
			res.Add(list[i]);
		}
		return res;
    }

	// // RVA: 0x121AA58 Offset: 0x121AA58 VA: 0x121AA58
	private static List<IKDICBBFBMI_EventBase> DJPFFHLCCNL(OHCAABOMEOF.KGOGMKMBCPP_EventType INDDJNMPONH, long JHNMKKNEENE, KGCNCBOKCBA.GNENJEHKMHD_EventStatus BELFNAHNMDL = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/)
	{
		List<IKDICBBFBMI_EventBase> res = new List<IKDICBBFBMI_EventBase>();
		List<IKDICBBFBMI_EventBase> evts = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.FindAll((IKDICBBFBMI_EventBase JPAEDJJFFOI) =>
		{
			//0x1220374
			return JPAEDJJFFOI.HIDHLFCBIDE_EventType == INDDJNMPONH;
		});
		for(int i = 0; i < evts.Count; i++)
		{
			evts[i].HCDGELDHFHB_UpdateStatus(JHNMKKNEENE);
			if (evts[i].NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1 && evts[i].NGOFCFJHOMI_Status <= BELFNAHNMDL)
				res.Add(evts[i]);
		}
		return res;
	}

	// // RVA: 0x121BE84 Offset: 0x121BE84 VA: 0x121BE84
	// public static List<IBJAKJJICBC> ENHMHDALFDB(long JHNMKKNEENE, bool EHBPHDPHPKF = False, bool JCOJKAHFADL = False) { }

	// // RVA: 0x121C6BC Offset: 0x121C6BC VA: 0x121C6BC
	public static List<IBJAKJJICBC> EHNABCEGAHO(long JHNMKKNEENE, bool EHBPHDPHPKF/* = False*/, bool JCOJKAHFADL/* = False*/)
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
				if(isExRival || eventBattle.PIPHAKNMIBL_Rivals[i].BHCIFFILAKJ_Str < 3)
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.EAHJLJOMFMG(i, eventBattle, JCOJKAHFADL);
					ib.OGHOPBAKEFE_IsEventSpecial = true;
					if(ib.GBNOALJPOBM || !JCOJKAHFADL)
					{
						res.Add(ib);
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x121ACC8 Offset: 0x121ACC8 VA: 0x121ACC8
	public static List<IBJAKJJICBC> LIENJMIJMIE(long JHNMKKNEENE, bool GBNOALJPOBM = false)
    {
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas.Count)
		{
			//CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_Save.LCKMBHDMPIP.FAMANJGJANN.Count ??
		}
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
		IKDICBBFBMI_EventBase data = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
		if(data != null)
		{
			for(int i = 0; i < data.HEACCHAKMFG_GetMusicsList().Count; i++)
			{
				int a1 = data.HEACCHAKMFG_GetMusicsList()[i];
				IBJAKJJICBC ib = new IBJAKJJICBC();
				ib.JBOHCKEIHKI(a1, data.HOOBCIIOCJD_GetSongEndTime(a1), data.PJLNJJIBFBN, data.PGIIDPEGGPI_EventId);
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
			TodoLogger.LogError(TodoLogger.EventScore_4, "FKDIMODKKJD event info");
		}
		List<IKDICBBFBMI_EventBase> ldata = DJPFFHLCCNL(OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool, JHNMKKNEENE, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6);
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
							data2.JBOHCKEIHKI(l[i], af.HOOBCIIOCJD_GetSongEndTime(l[i]), af.PJLNJJIBFBN, af.PGIIDPEGGPI_EventId);
							data2.OEILJHENAHN_PlayEventType = 10;
							data2.IHPCKOMBGKJ_End = af.HOOBCIIOCJD_GetSongEndTime(l[i]);
							data2.LEBDMNIGOJB_IsScoreEvent = false;
							data2.FGKMJHKLGLD = true;
							data2.NNJNNCGGKMC_IsLimited = af.GIDDKGMPIOK_IsLimited(l[i]);
							data2.OGHOPBAKEFE_IsEventSpecial = true;
							KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[i]);
							EONOEHOKBEB_Music m2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.INJDLHAEPEK_GetMusicInfo(l[i], m.DLAEJOBELBH_MusicId);
							data2.JNCPEGJGHOG_JacketId = m2.JNCPEGJGHOG_Cov;
							data2.BNCMJNMIDIN_AvaiableDivaModes = FFJPJEMCGKK(m2);
							if (data2.KLOGLLFOAPL_HasMultiDivaMode())
								data2.JPOINGMJCGL = true;
							res.Add(data2);
						}
					}
				}
			}
		}
		DKCJADHKGAN_EventWeekDay.JFFPEKOEINE e = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CLLPBOPLICM_EventWeekDay.PPIBJECKCEF(JHNMKKNEENE);
		DateTime date = Utility.GetLocalDateTime(JHNMKKNEENE);
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
		if(GBNOALJPOBM)
		{
			res = res.FindAll((IBJAKJJICBC JPAEDJJFFOI) =>
			{
				//0x12200F0
				return JPAEDJJFFOI.GBNOALJPOBM;
			});
		}
        return res;
    }

	// // RVA: 0x121CBD4 Offset: 0x121CBD4 VA: 0x121CBD4
	// public static void GNNIJFBOBAJ(List<IBJAKJJICBC> NNDGIAEFMOG) { }

	// // RVA: 0x121CE9C Offset: 0x121CE9C VA: 0x121CE9C
	public static void BDNIEPMOHDI(List<IBJAKJJICBC> NNDGIAEFMOG)
	{
        IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
		if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
		{
			for(int i = 0; i < NNDGIAEFMOG.Count; i++)
			{
				NNDGIAEFMOG[i].NPEKPHAFMGE_SetupEnemies(NNDGIAEFMOG[i].DACLONHOFLA.CPBFAMJEODF_CSkill, NNDGIAEFMOG[i].DACLONHOFLA.MGHPJNNDCIG_LSkill);
			}
		}
    }

	// // RVA: 0x121D0DC Offset: 0x121D0DC VA: 0x121D0DC
	// public static List<IBJAKJJICBC> FMHFMIMDOCM(int DEPGBBJMFED, long JHNMKKNEENE, bool JCOJKAHFADL = False) { }

	// // RVA: 0x121DF50 Offset: 0x121DF50 VA: 0x121DF50
	// public static List<IBJAKJJICBC> DHFHJBMKEHN(int DEPGBBJMFED, long JHNMKKNEENE, bool JCOJKAHFADL = False) { }

	// // RVA: 0x121E028 Offset: 0x121E028 VA: 0x121E028
	public static List<IBJAKJJICBC> ONHHIHBHKPK(int DEPGBBJMFED, long JHNMKKNEENE, bool JCOJKAHFADL/* = False*/)
	{
		List<IBJAKJJICBC> res = MJAJPHIKGBF(DEPGBBJMFED, JHNMKKNEENE, JCOJKAHFADL, JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6), OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva);
		res.RemoveAll((IBJAKJJICBC GHPLINIACBB) =>
		{
			//0x1220114
			return GHPLINIACBB.HAMPEDFMIAD_HasOnlyMultiDivaMode();
		});
		return res;
	}

	// // RVA: 0x121D1B4 Offset: 0x121D1B4 VA: 0x121D1B4
	private static List<IBJAKJJICBC> MJAJPHIKGBF(int DEPGBBJMFED, long JHNMKKNEENE, bool JCOJKAHFADL, IKDICBBFBMI_EventBase FBFNJMKPBBA, OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE)
	{
		int cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas.Count;
		int cnt2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count;
		if(cnt2 < cnt)
			cnt = cnt2;
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
		if(FBFNJMKPBBA != null && DEPGBBJMFED == 5 && FBFNJMKPBBA.HIDHLFCBIDE_EventType == HIDHLFCBIDE)
		{
			List<int> musicList = FBFNJMKPBBA.HEACCHAKMFG_GetMusicsList();
			for(int i = 0; i < musicList.Count; i++)
			{
				IBJAKJJICBC ib = new IBJAKJJICBC();
				ib.KHEKNNFCAOI(musicList[i], false, 0, 0, JHNMKKNEENE, FBFNJMKPBBA.PJLNJJIBFBN, true);
				ib.MNNHHJBBICA_GameEventType = (int)HIDHLFCBIDE;
				ib.MFJKNCACBDG_OpenEventType = (int)HIDHLFCBIDE;
				ib.OEILJHENAHN_PlayEventType = (int)HIDHLFCBIDE;
				ib.BJANNALFGGA_HasRanking = false;
				ib.DBJOBFIGGEE_EventBonusPercent = FBFNJMKPBBA.OMJHBJPCFFC_GetEventBonusPercent(musicList[i]);
				ib.OGHOPBAKEFE_IsEventSpecial = true;
				ib.IHPCKOMBGKJ_End = FBFNJMKPBBA.HOOBCIIOCJD_GetSongEndTime(i);
				ib.NNJNNCGGKMC_IsLimited = FBFNJMKPBBA.GIDDKGMPIOK_IsLimited(i);
				if(!JCOJKAHFADL || ib.GBNOALJPOBM)
				{
					res.Add(ib);
				}
			}
		}
        DKCJADHKGAN_EventWeekDay.JFFPEKOEINE evWeekDay = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CLLPBOPLICM_EventWeekDay.PPIBJECKCEF(JHNMKKNEENE);
        DayOfWeek dow = Utility.GetLocalDateTime(JHNMKKNEENE).DayOfWeek;
		for(int i = 0; i < cnt; i++)
		{
            KEODKEGFDLD_FreeMusicInfo song = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[i];
            if (song.PPEGAKEIEGM_Enabled == 2)
			{
				if(DEPGBBJMFED != -1 && DEPGBBJMFED != song.DEPGBBJMFED_CategoryId)
				{
					//LAB_0121ddc0
					;
				}
				else if(DEPGBBJMFED == 5)
				{
					if(evWeekDay != null)
					{
						if(evWeekDay.FLPDCNBLOKL_IsSongForWeekDay((int)dow, song.GHBPLHBNMBK_FreeMusicId))
						{
							JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo saveSong = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[i];
							saveSong.FKBPJCDBDAG_SetWeekEventServerDate(JHNMKKNEENE);
							//LAB_0121db68
							IBJAKJJICBC ib = new IBJAKJJICBC();
							ib.KHEKNNFCAOI(song.GHBPLHBNMBK_FreeMusicId, true, (int)dow, evWeekDay.ELEPHBOKIGK_MaxCount + evWeekDay.AEHCKNNGAKF_BonusMaxCount, JHNMKKNEENE, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.FPGDAPAILAK_ExtremeUnlock == 2, false, JCOJKAHFADL);
							ib.MNNHHJBBICA_GameEventType = (int)HIDHLFCBIDE;
							ib.MFJKNCACBDG_OpenEventType = 0;
							ib.GDLNCHCPMCK_HasBoost = evWeekDay.AEHCKNNGAKF_BonusMaxCount > 0;
							ib.OEILJHENAHN_PlayEventType = (int)HIDHLFCBIDE;
							ib.DBJOBFIGGEE_EventBonusPercent = FBFNJMKPBBA.OMJHBJPCFFC_GetEventBonusPercent(song.GHBPLHBNMBK_FreeMusicId);
							if(!JCOJKAHFADL || ib.GBNOALJPOBM)
							{
								res.Add(ib);
							}
						}
					}
				}
				else
				{
					if(LBHPMGDNPHK_IsMusicOpen(song.GHBPLHBNMBK_FreeMusicId, DEPGBBJMFED))
					{
						//LAB_0121db68
						IBJAKJJICBC ib = new IBJAKJJICBC();
						ib.KHEKNNFCAOI(song.GHBPLHBNMBK_FreeMusicId, false, (int)dow, 0, JHNMKKNEENE, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.FPGDAPAILAK_ExtremeUnlock == 2, false, JCOJKAHFADL);
						ib.MNNHHJBBICA_GameEventType = (int)HIDHLFCBIDE;
						ib.MFJKNCACBDG_OpenEventType = 0;
						ib.GDLNCHCPMCK_HasBoost = false;
						ib.OEILJHENAHN_PlayEventType = (int)HIDHLFCBIDE;
						ib.DBJOBFIGGEE_EventBonusPercent = FBFNJMKPBBA.OMJHBJPCFFC_GetEventBonusPercent(song.GHBPLHBNMBK_FreeMusicId);
						if(!JCOJKAHFADL || ib.GBNOALJPOBM)
						{
							res.Add(ib);
						}
					}
				}
			}
		}
		if(DEPGBBJMFED != 5)
		{
			res.Sort((IBJAKJJICBC HKICMNAACDA, IBJAKJJICBC BNKHBCBJBKI) =>
			{
				//0x1220140
				return HKICMNAACDA.EEFLOOBOAGF.CompareTo(BNKHBCBJBKI.EEFLOOBOAGF);
			});
		}
		return res;
	}

	// // RVA: 0x121E210 Offset: 0x121E210 VA: 0x121E210
	public static List<IBJAKJJICBC> GCCBCAKFJMF(int DEPGBBJMFED, long JHNMKKNEENE, int OAFJONPIFGM, bool JCOJKAHFADL/* = False*/)
	{
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
		if(DEPGBBJMFED == 5)
		{
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(OAFJONPIFGM);
			if(ev.HIDHLFCBIDE_EventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
			{
				if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
				{
					TodoLogger.LogError(TodoLogger.EventCollection_1, "GCCBCAKFJMF");
				}
				else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
				{
					HAEDCCLHEMN_EventBattle btEv = ev as HAEDCCLHEMN_EventBattle;
					List<int> l = btEv.HEACCHAKMFG_GetMusicsList();
					for(int i = 0; i <= 0 && i < l.Count; i++)
					{
						IBJAKJJICBC ib = new IBJAKJJICBC();
						ib.KHEKNNFCAOI(l[i], false, 0, 0, JHNMKKNEENE, btEv.PJLNJJIBFBN, true, false);
						ib.OGHOPBAKEFE_IsEventSpecial = true;
						res.Add(ib);
					}
				}
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
			{
				TodoLogger.LogError(TodoLogger.EventQuest_6, "GCCBCAKFJMF");
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
			{
				MANPIONIGNO_EventGoDiva evGoDiva = ev as MANPIONIGNO_EventGoDiva;
				List<int> ls = evGoDiva.HEACCHAKMFG_GetMusicsList();
				for(int i = 0; i < 1 && i < ls.Count; i++)
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.KHEKNNFCAOI(ls[i], false, 0, 0, JHNMKKNEENE, evGoDiva.PJLNJJIBFBN, true, false);
					ib.OGHOPBAKEFE_IsEventSpecial = true;
					res.Add(ib);
				}
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GCCBCAKFJMF");
			}
        }
		else
		{
			res.Sort((IBJAKJJICBC HKICMNAACDA, IBJAKJJICBC BNKHBCBJBKI) =>
			{
				//0x12201AC
				return HKICMNAACDA.EEFLOOBOAGF.CompareTo(BNKHBCBJBKI.EEFLOOBOAGF);
			});
		}
		//LAB_0121e998
		if(JCOJKAHFADL)
		{
			res = res.FindAll((IBJAKJJICBC JPAEDJJFFOI) =>
			{
				//0x1220218
				return JPAEDJJFFOI.GBNOALJPOBM;
			});
		}
		return res;
	}

	// // RVA: 0x121F428 Offset: 0x121F428 VA: 0x121F428
	// public static IBJAKJJICBC MLMMPFACEKI(int GHBPLHBNMBK, List<IBJAKJJICBC> OEAJOJMOGMH, List<IBJAKJJICBC> FCCKCFEEOMN, List<IBJAKJJICBC> LCKJDADHOEB, List<IBJAKJJICBC> BAOEHOFNOOG, List<IBJAKJJICBC> EGLEKOHJBNA, List<IBJAKJJICBC> GEEODBLIDDB, ref int EIPGHNKPAOH, ref int OIPCCBHIKIA) { }

	// // RVA: 0x121F99C Offset: 0x121F99C VA: 0x121F99C Slot: 3
	// public override string ToString() { }

	// // RVA: 0x121FC40 Offset: 0x121FC40 VA: 0x121FC40
	public static bool FPLIAMHMFJP()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
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
        return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("line6_unlock_uta_rate", 250);
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
