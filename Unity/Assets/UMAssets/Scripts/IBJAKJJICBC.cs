
using System;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public class IBJAKJJICBC : EEDKAACNBBG_MusicData
{
	public enum AAADDDFCKLF
	{
		ALNCPFNNBLH = 0,
		IANFNICOEFE = 1,
		OGGMDNKPFEB = 2,
	}

	public class GFKEJIHPAOM
	{
		public long KINJOEIAHFK_OpenTime; // 0x8
		public long PCCFAKEOBIC_CloseTime; // 0x10
		public long EMEKFFHCHMH; // 0x18
		public string OPFGFINHFCE_EventName; // 0x20
		public string KLMPFGOCBHC_EventDesc; // 0x24
		public int GOAPADIHAHG; // 0x28
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

		public int CMCKNKKCNDK { get { return NLBLLLLBHOP ^ FBGGEFFJJHB_Key; } set { NLBLLLLBHOP = value ^ FBGGEFFJJHB_Key; } } //0x12203C0 CNKGOPKANGF 0x1215B00 CHJGGLFGALP
		public int KNIFCANOHOC_Score { get { return NBOLDNMPJFG ^ FBGGEFFJJHB_Key; } set { NBOLDNMPJFG = value ^ FBGGEFFJJHB_Key; } } //0x1214AC0 EOJEPLIPOMJ 0x1215AB0 AEEMBPAEAAI
		public int NLKEBAOBJCM_Combo { get { return BCKCCHGMPBG ^ FBGGEFFJJHB_Key; } set { BCKCCHGMPBG = value ^ FBGGEFFJJHB_Key; } } //0x12203D4 AECNKGBNKHH 0x1215AC4 ECHLKFHOJFP
		public int JNLKJCDFFMM_Clear { get { return COGALGDHDFE ^ FBGGEFFJJHB_Key; } set { COGALGDHDFE = value ^ FBGGEFFJJHB_Key; } } //0x1215B14 JLGNODHICKN 0x1215AD8 DLEGLBAGJOI
		public int EMHFDJEFIHG { get { return FCOIEGJFOJI ^ FBGGEFFJJHB_Key; } set { FCOIEGJFOJI = value ^ FBGGEFFJJHB_Key; } } //0x12176A4 OBFCFPIDKGB 0x1217690 MJHGLINGBGJ
		public int BPLOEAHOPFI_Energy { get { return FDOFFBKDJKC ^ FBGGEFFJJHB_Key; } set { FDOFFBKDJKC = value ^ FBGGEFFJJHB_Key; } } //0x12203E8 IFLOIFCLBFJ 0x1215B28 NGMKCJOPEGH
		public int LCOHGOIDMDF_ComboRank { get { return LOIHMDIJJOP_ComboRankCrypted ^ FBGGEFFJJHB_Key; } set { LOIHMDIJJOP_ComboRankCrypted = value ^ FBGGEFFJJHB_Key; } } //0x12203FC LNDHFDDHOJP 0x1215AEC IMNCJLKPOAJ
		public int PPDPGKHKCNB { get { return EINNKFIEIHJ ^ FBGGEFFJJHB_Key; } set { EINNKFIEIHJ = value ^ FBGGEFFJJHB_Key; } } //0x1220410 BHNHLDKJLNJ 0x121C6A8 FLGAJBJBIII
		//public int CIEOBFIIPLD { get; } 0x1220424 OGKGFGMKPKB
		public bool POOMOBGPCNE { get { return CMCKNKKCNDK == 0; } } //0x1220450 PJPHEDJHLOO
		public bool CADENLBDAEB_IsNew { get { return CMCKNKKCNDK == 1; } } //0x122046C KJGFPPLHLAB
		public bool CHBNEEIIDDI { get { return CMCKNKKCNDK == 2; } }// 0x1220488 PIGGFFEOODB
		public bool BCGLDMKODLC_IsClear { get { return CMCKNKKCNDK == 3; } } //0x12204A4 NNGALFPBDNA
	}


	private const int FBGGEFFJJHB_Key = 0x7daf3c5a;
	private const sbyte JFOFMKBJBBE_False = 19;
	private const sbyte CNECJGKECHK_True = 87;
	private int EPGOIGPKPPJ_FreeMusicIdCrypted = FBGGEFFJJHB_Key; // 0x40
	private int HNEHIJCAOJM_CategoryIdCrypted = FBGGEFFJJHB_Key; // 0x44
	private sbyte ACKPOCNHOOP = JFOFMKBJBBE_False; // 0x48
	private sbyte IFLNGLECALJ = JFOFMKBJBBE_False; // 0x49
	private sbyte MEPLEIEDBGE = JFOFMKBJBBE_False; // 0x4A
	private int EGCMPELNLKP = FBGGEFFJJHB_Key; // 0x4C
	private int CEMGANMAOML_EventTypeCrypted = FBGGEFFJJHB_Key; // 0x50
	private int NENONMAGGBP = FBGGEFFJJHB_Key; // 0x54
	private int MJLNDHPNFHE = FBGGEFFJJHB_Key; // 0x58
	private int PPDEOMLMEKC = FBGGEFFJJHB_Key; // 0x5C
	private sbyte IKGGKOFGMNC; // 0x60
	// private sbyte CICKCGDKICN = JFOFMKBJBBE; // 0x61
	// public BKKMNPEEILG DACLONHOFLA; // 0x64
	private int KAEIHNCACOD = FBGGEFFJJHB_Key; // 0x68
	private sbyte MPDBHMLFLLA = JFOFMKBJBBE_False; // 0x6C
	// private sbyte JMFIOFIBLFH = JFOFMKBJBBE; // 0x6D
	public WeekdayEventAttr.Type IHKFMJDOBAH; // 0x70
	private sbyte CHOLAKGHAEN_IsWeelkyEvent = JFOFMKBJBBE_False; // 0x74
	private long PMEGFLFDDKH_WeeklyEndTimeCrypted = FBGGEFFJJHB_Key; // 0x78
	private sbyte NKKAIPDPEEI_HasBoostCrypted = JFOFMKBJBBE_False; // 0x80
	private sbyte AJGIBNAJPJD = JFOFMKBJBBE_False; // 0x81
	private int AFDHDBMKLJL = FBGGEFFJJHB_Key; // 0x84
	private int KOOODCKJNJO = FBGGEFFJJHB_Key; // 0x88
	private int NEBJMHHHDMO = FBGGEFFJJHB_Key; // 0x8C
	private int PDLMMOJDBKM = FBGGEFFJJHB_Key; // 0x90
	private int[] LHENMNBDFNM; // 0x94
	// private string MJEPJCDOAML; // 0x98
	public IBJAKJJICBC.GFKEJIHPAOM AFCMIOIGAJN_EventInfo; // 0x9C
	public int LOFKFOCAJGB = FBGGEFFJJHB_Key; // 0xA0
	// public int DANJGFKGLNN = FBGGEFFJJHB; // 0xA4
	public IBJAKJJICBC.DLLJPHLOICN NOKBLCDMLPP_MinigameEventInfo; // 0xA8
	public sbyte FBMAAGJAGGG = JFOFMKBJBBE_False; // 0xAC
	public sbyte OFFDABPBFBA = JFOFMKBJBBE_False; // 0xAD
	public sbyte POKBBJHFNPI = JFOFMKBJBBE_False; // 0xAE
	// public sbyte LKBOJPIFOFK = JFOFMKBJBBE; // 0xAF
	// public sbyte BCEHBCFLHNL = JFOFMKBJBBE; // 0xB0
	public sbyte PHKCAIAKPLG = JFOFMKBJBBE_False; // 0xB1
	public long APCJGOEEBEB_OtherEndTimeCrypted = FBGGEFFJJHB_Key; // 0xB8
	public sbyte FEBKEKCEODK = JFOFMKBJBBE_False; // 0xC0
	private int GNIHKFDDCOO = FBGGEFFJJHB_Key; // 0xC4
	public bool GBNOALJPOBM; // 0xC8
	public long NJDCMCDEAPK; // 0xD0

	public int GHBPLHBNMBK_FreeMusicId { get { return EPGOIGPKPPJ_FreeMusicIdCrypted ^ FBGGEFFJJHB_Key; } set { EPGOIGPKPPJ_FreeMusicIdCrypted = value ^ FBGGEFFJJHB_Key; } } //0x1213164 HKFCFPFPMBN 0x1213178 IFMPBFAAKNN
	public int DEPGBBJMFED_CategoryId { get { return HNEHIJCAOJM_CategoryIdCrypted ^ FBGGEFFJJHB_Key; } set { HNEHIJCAOJM_CategoryIdCrypted = value ^ FBGGEFFJJHB_Key; } } //0x121318C FNMFOBJIIIC 0x12131A0 OBEDPJLBBEG
	public bool CADENLBDAEB { get { return ACKPOCNHOOP == CNECJGKECHK_True; } set { ACKPOCNHOOP = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12131B4 KJGFPPLHLAB 0x12131C8 ILJHLPMDHPO
	public bool LDGOHPAPBMM { get { return IFLNGLECALJ == CNECJGKECHK_True; } set { IFLNGLECALJ = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12131F8 GEBJMDIJNAH 0x121320C JBMMFDLGCMC
	public bool CPBDGAGKNGH { get { return MEPLEIEDBGE == CNECJGKECHK_True; } set { MEPLEIEDBGE = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x121323C KJLPFJJHJPE 0x1213250 CLALHMCBPNF
	public int EKANGPODCEP_EventId { get { return EGCMPELNLKP ^ FBGGEFFJJHB_Key; } set { EGCMPELNLKP = value ^ FBGGEFFJJHB_Key; } } //0x1213280 EBLAFEMDFGD 0x1213294 AHEFELNFBDM
	public int MNNHHJBBICA_EventType { get { return CEMGANMAOML_EventTypeCrypted ^ FBGGEFFJJHB_Key; } set { CEMGANMAOML_EventTypeCrypted = value ^ FBGGEFFJJHB_Key; } } //0x12132A8 FNEIPFMLBCB 0x12132BC IFKDECJEKGJ
	public int MFJKNCACBDG { get { return NENONMAGGBP ^ FBGGEFFJJHB_Key; } set { NENONMAGGBP = value ^ FBGGEFFJJHB_Key; } } //0x12132D0 HLAFCPHCBED 0x12132E4 FMLMCHDKIPP
	public int OEILJHENAHN { get { return MJLNDHPNFHE ^ FBGGEFFJJHB_Key; } set { MJLNDHPNFHE = value ^ FBGGEFFJJHB_Key; } } //0x12132F8 MGJDCGJMEKP 0x121330C IMJDLLMCMAH // MJLNDHPNFHE
	public int EEFLOOBOAGF { get { return PPDEOMLMEKC ^ FBGGEFFJJHB_Key; } set { PPDEOMLMEKC = value ^ FBGGEFFJJHB_Key; } } //0x1213320 NLDELFLNODF 0x1213334 PEHLMNDKOEE
	public bool BJANNALFGGA { get { return IKGGKOFGMNC == CNECJGKECHK_True; } set { IKGGKOFGMNC = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1213348 EPFAPPFDMJH 0x121335C AFBCHDAJIFL
	// public bool OGHOPBAKEFE { get; set; } 0x121338C LNICBELKODE 0x12133A0 MMOFHBDNIFJ  CICKCGDKICN
	public int OPPBIOEJAND { get { return KAEIHNCACOD ^ FBGGEFFJJHB_Key; } set { KAEIHNCACOD = value ^ FBGGEFFJJHB_Key; } } //0x12133D0 LPGPACOAGAM 0x12133E4 DFGJNJCLJKO
	public bool JOJPMFNJJPD { get { return MPDBHMLFLLA == CNECJGKECHK_True; } set { MPDBHMLFLLA = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12133F8 MPMFLBPLMMN 0x121340C JDJIDAOAIB
	// public bool JPOINGMJCGL { get; set; } 0x121343C OOCNOAFIHIB 0x1213450 KKKFHLFKFCG   JMFIOFIBLFH
	public bool LHONOILACFL_IsWeeklyEvent { get { return CHOLAKGHAEN_IsWeelkyEvent == CNECJGKECHK_True; } set { CHOLAKGHAEN_IsWeelkyEvent = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1213480 PGKDJOCOJMK 0x1213494 JLOKCBHGIPA
	public long NKEIFPPGNLH_WeeklyendTime { get { return PMEGFLFDDKH_WeeklyEndTimeCrypted ^ FBGGEFFJJHB_Key; } set { PMEGFLFDDKH_WeeklyEndTimeCrypted = value ^ FBGGEFFJJHB_Key; } } //0x12134C4 GALMKGNOFDH 0x12134D8 AABJDLOOPOC
	public bool GDLNCHCPMCK_HasBoost { get { return NKKAIPDPEEI_HasBoostCrypted == CNECJGKECHK_True; } set { NKKAIPDPEEI_HasBoostCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12134F4 MGDNBNEHFAJ 0x1213508 CHLKHPGCIPB
	public bool NNJNNCGGKMC { get { return AJGIBNAJPJD == CNECJGKECHK_True; } set { AJGIBNAJPJD = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1213538 IEIACJPPDOH 0x121354C APJCBPNGEHO
	public int KCKBOIDCPCK { get { return AFDHDBMKLJL ^ FBGGEFFJJHB_Key; } set { AFDHDBMKLJL = value ^ FBGGEFFJJHB_Key; } } //0x121357C LIKAGINKECG 0x1213590 DDLKEDBBGCB
	public int JJEFMIHJMHC { get { return KOOODCKJNJO ^ FBGGEFFJJHB_Key; } set { KOOODCKJNJO = value ^ FBGGEFFJJHB_Key;} } //0x12135A4 BAPFJJJLHCC 0x12135B8 OGMOOIOKJHG
	public int BELHFPMBAPJ { get { return NEBJMHHHDMO ^ FBGGEFFJJHB_Key; } set { NEBJMHHHDMO = value ^ FBGGEFFJJHB_Key; } } //0x12136F4 HJBNBOJBKPO 0x1213708 LJLMDPIGCFJ
	public int JOJNGDPHOKG { get { return PDLMMOJDBKM ^ FBGGEFFJJHB_Key; } set { PDLMMOJDBKM = value ^ FBGGEFFJJHB_Key; } } //0x121371C MBDGLMBPBEJ 0x1213730 JLIOGCHPNFJ
	public int MOJMEFIENDM_WeeklyEventCount { get { return (JOJNGDPHOKG) - (BELHFPMBAPJ); } } //0x1213744 PBNIFHCLKNA
	public bool AJGCPCMLGKO_IsEvent { get { return AFCMIOIGAJN_EventInfo != null; } } //0x12141A8 LFBNCKMILGK
	public bool MNDFBBMNJGN { get { return LOFKFOCAJGB != FBGGEFFJJHB_Key; } } //0x12141B8 KLMOKPHBBOC  LOFKFOCAJGB
	// public int JKIADEKHGLC { get; set; } 0x12141D4 OMELGCEEHKD 0x12141E8 EJEGDHIDAHL  LOFKFOCAJGB
	// public int DBJOBFIGGEE { get; set; } 0x12141FC OCAMIMMBCLG 0x1214210 EGDEICLAEBO   DANJGFKGLNN
	public bool BNIAJAKIAJC_IsEventMinigame { get { return NOKBLCDMLPP_MinigameEventInfo != null; } } //0x1214224 ENAOGJDBGHC
	public bool KDAJEGNBOFJ { get {
			if (NOKBLCDMLPP_MinigameEventInfo != null)
				return true;
			return AFCMIOIGAJN_EventInfo != null;
		} } //0x1214234 HIODBIOCMAI
	public bool POEGGBGOKGI { get { return FBMAAGJAGGG == CNECJGKECHK_True; } set { FBMAAGJAGGG = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1214258 KODGDIIMPII 0x121426C GHDOJNEEOKO
	public bool PJLNJJIBFBN { get { return OFFDABPBFBA == CNECJGKECHK_True; } set { OFFDABPBFBA = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x121429C GMGBFOAAHDD 0x12142B0 GHLFABPOFJK
	public bool LEBDMNIGOJB { get { return POKBBJHFNPI == CNECJGKECHK_True; } set { POKBBJHFNPI = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12142E0 HBEONMDJOOP 0x12142F4 FDGKGCJHPDA
	// public bool HDPMAJKGIOI { get; set; } 0x1214324 CPGNHCPOKOB 0x1214338 AKHMGHGILEL   LKBOJPIFOFK
	// public bool LGIGMPBHJCI { get; set; } 0x1214368 EOAGNJADCPB 0x121437C NAEDALBFMPK   BCEHBCFLHNL
	public bool FGKMJHKLGLD { get { return PHKCAIAKPLG == CNECJGKECHK_True; } set { PHKCAIAKPLG = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x12143AC IEPMIAMGFIJ 0x12143C0 GAAOGMPFCFN
	public long ALMOMLMCHNA_OtherEndTime { get { return APCJGOEEBEB_OtherEndTimeCrypted ^ FBGGEFFJJHB_Key; } set { APCJGOEEBEB_OtherEndTimeCrypted = value ^ FBGGEFFJJHB_Key; } } //0x12143F0 BHKAHGNFCEN 0x1214404 LOJIKNJAGIO
	public bool EHNGOGBJMGL { get { return FEBKEKCEODK == CNECJGKECHK_True; } set { FEBKEKCEODK = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1214550 FDIMEFOAOAP 0x1214564 HCNELALHKNN
	private int AAODIMMEFBI { get { return GNIHKFDDCOO ^ FBGGEFFJJHB_Key; } set { GNIHKFDDCOO = value ^ FBGGEFFJJHB_Key; } } //0x1214594 IHMBMOACINF 0x12145A8 OJLEJOKHKFP
	public long IHPCKOMBGKJ { get { return NJDCMCDEAPK ^ FBGGEFFJJHB_Key; } set { NJDCMCDEAPK = value ^ FBGGEFFJJHB_Key; } } //0x12145FC KMCBIJLEDNH 0x1214610 GCEGLPAGDGI
	public List<IBJAKJJICBC.ANJLFFPBAEF_DifficultyInfo> MGJKEJHEBPO_DiffInfos { get; set; } // 0xD8 DPHOPMPKAHK BNPJIIPJJLJ HOKDNOFCDHM

	// // RVA: 0x12135CC Offset: 0x12135CC VA: 0x12135CC
	// public int NOEIIMGDDKK() { }

	// // RVA: 0x1213764 Offset: 0x1213764 VA: 0x1213764
	// public void IEBGBOBPJMB(int NGDGGPCLPKC) { }

	// // RVA: 0x1213814 Offset: 0x1213814 VA: 0x1213814
	public int ICHJBDPJNMA(WeekdayEventAttr.Type INDDJNMPONH, int IKPIDCFOFEA)
	{
		if(INDDJNMPONH != 0 && LHENMNBDFNM != null)
		{
			return LHENMNBDFNM[IKPIDCFOFEA];
		}
		return 0;
	}

	// // RVA: 0x1213860 Offset: 0x1213860 VA: 0x1213860
	// public int LMPNAPIGAEA(WeekdayEventAttr.Type INDDJNMPONH) { }

	// // RVA: 0x1213A74 Offset: 0x1213A74 VA: 0x1213A74
	// public string CIOCOOMCMKO(WeekdayEventAttr.Type INDDJNMPONH) { }

	// // RVA: 0x1213B4C Offset: 0x1213B4C VA: 0x1213B4C
	// private void KDPFCMAALPO(int GHBPLHBNMBK, bool GIKLNODJKFK) { }

	// RVA: 0x1214420 Offset: 0x1214420 VA: 0x1214420
	public long AHAEGEHKONB_GetOtherTimeLeft()
	{
		if(ALMOMLMCHNA_OtherEndTime != 0)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if (ALMOMLMCHNA_OtherEndTime > time)
				return ALMOMLMCHNA_OtherEndTime - time;
		}
		return -1;
	}

	// // RVA: 0x12145BC Offset: 0x12145BC VA: 0x12145BC
	// public void OFAPIHAJDOH(int GHBPLHBNMBK) { }

	// // RVA: 0x12145E8 Offset: 0x12145E8 VA: 0x12145E8
	public int AKAPOCOIECA()
	{
		return AAODIMMEFBI;
	}

	// // RVA: 0x121462C Offset: 0x121462C VA: 0x121462C
	// public int FOHHGKEJMEL() { }

	// // RVA: 0x1214760 Offset: 0x1214760 VA: 0x1214760 Slot: 5
	public override bool DBIGDCOHOIC()
	{
		TodoLogger.Log(0, "DBIGDCOHOIC");
		return base.DBIGDCOHOIC();
	}

	// // RVA: 0x12147B8 Offset: 0x12147B8 VA: 0x12147B8
	// public bool ICKDCAMABPD(int OGPKGGLJACK) { }

	// // RVA: 0x1214824 Offset: 0x1214824 VA: 0x1214824
	public bool PNKKJEABNFF(IBJAKJJICBC.AAADDDFCKLF IKENKJKOGNN)
	{
		// Will need to check tests
		bool res = DBIGDCOHOIC();
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
					return DBIGDCOHOIC();
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
		this.PJLNJJIBFBN = PJLNJJIBFBN;
		if(!HCIKDFECJGE)
		{
			NKEIFPPGNLH_WeeklyendTime = 0;
			IHKFMJDOBAH = WeekdayEventAttr.Type.None;
			LHONOILACFL_IsWeeklyEvent = false;
			BELHFPMBAPJ = 0;
			JOJNGDPHOKG = 0;
			BJANNALFGGA = true;
		}
		else
		{
			TodoLogger.Log(0, "IBJAKJJCBC KHEKNNFCAOI Init weekly event");
		}
		EEFLOOBOAGF = musicInfo.EEFLOOBOAGF;
		LDGOHPAPBMM = true;
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
				info.KNIFCANOHOC_Score = saveInfo.BDCAICINCKK_GetScore(i);
				info.NLKEBAOBJCM_Combo = saveInfo.NLKEBAOBJCM_Combo[i];
				info.JNLKJCDFFMM_Clear = saveInfo.JNLKJCDFFMM_Clear[i];
				info.LCOHGOIDMDF_ComboRank = saveInfo.LAMCCNAKIOJ_CbRnk[i];
				info.HPBPDHPIBGN_EnemyData.KHEKNNFCAOI(musicInfo.LHICAKGHIGF[i], musicInfo.LJPKLMJPLAC[i]);
				val = saveInfo.EMHFDJEFIHG_Play[i];
			}
			else
			{
				info.KNIFCANOHOC_Score = saveInfo.AHDKMPFDKPE_GetScoreL6(i);
				info.NLKEBAOBJCM_Combo = saveInfo.DNIGPFPHJAK_ComboL6[i];
				info.JNLKJCDFFMM_Clear = saveInfo.DPPCFFFNBGA_ClearL6[i];
				info.LCOHGOIDMDF_ComboRank = saveInfo.EEECMKPLPNL_CbRnkL6[i];
				info.HPBPDHPIBGN_EnemyData.KHEKNNFCAOI(musicInfo.PJNFOCDANCE[i], musicInfo.ILCJOOPIILK[i]);
				val = saveInfo.FHFKOGIPAEH_PlayL6[i];
			}
			if((info.JNLKJCDFFMM_Clear) < 1)
			{
				if(val > 0)
				{
					info.CMCKNKKCNDK = 2;
					LDGOHPAPBMM = false;
				}
				else
				{
					info.CMCKNKKCNDK = 1;
				}
			}
			else
			{
				info.CMCKNKKCNDK = 3;
				LDGOHPAPBMM = true;
			}
			info.HHMLMKAEJBJ_Score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(musicInfo2.KKPAHLMJKIH_WavId, musicInfo2.BKJGCEOEPFB_VariationId, i, GIKLNODJKFK, true);
			if(info.HHMLMKAEJBJ_Score != null)
			{
				info.BAKLKJLPLOJ = musicInfo.EMJCHPDJHEI(GIKLNODJKFK, i);
				info.BPLOEAHOPFI_Energy = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.HHEEPBJNAKA_GetEnergy(info.HHMLMKAEJBJ_Score.ANAJIAENLNB_F_pt, GIKLNODJKFK);
				MGJKEJHEBPO_DiffInfos.Add(info);
			}
			hasValue = hasValue & (saveInfo.EMHFDJEFIHG_Play[i] < 1);
			hasValue2 = hasValue2 & (saveInfo.FHFKOGIPAEH_PlayL6[i] < 1);
		}
		OPPBIOEJAND = 0;
		JOJPMFNJJPD = false;
		CADENLBDAEB = (hasValue || hasValue2);
		if(!musicInfo.BHJNFBDNFEJ)
		{
			BNCMJNMIDIN_AvaiableDivaModes = (byte)(BNCMJNMIDIN_AvaiableDivaModes & 1);
		}
		if(DBIGDCOHOIC() && KLOGLLFOAPL_HasMultiDivaMode())
		{
			CPBDGAGKNGH = saveInfo.CPBDGAGKNGH_UlNew;
			if (saveInfo.CPBDGAGKNGH_UlNew)
			{
				CADENLBDAEB = true;
				LDGOHPAPBMM = true;
			}
		}
		else
		{
			CPBDGAGKNGH = false;
		}
		AAODIMMEFBI = HighScoreRating.GetUtaRate(GHBPLHBNMBK);
		KCKBOIDCPCK = 0;
		JJEFMIHJMHC = 0;
		GBNOALJPOBM = musicInfo.GBNOALJPOBM;
	}

	// // RVA: 0x1215B3C Offset: 0x1215B3C VA: 0x1215B3C
	// private void FAEBEJENNHD(IKDICBBFBMI LIKDEHHKFEH) { }

	// // RVA: 0x1215D48 Offset: 0x1215D48 VA: 0x1215D48
	// private void OKLGJBKAJGH(IKDICBBFBMI LIKDEHHKFEH, int OOCBPMNHLPM) { }

	// // RVA: 0x1215F78 Offset: 0x1215F78 VA: 0x1215F78
	// public void PMKBMGNAJIL(HLEBAINCOME LIKDEHHKFEH, bool GIKLNODJKFK) { }

	// // RVA: 0x1216BB0 Offset: 0x1216BB0 VA: 0x1216BB0
	// private void EAHJLJOMFMG(int EPLEIPFGGHP, HAEDCCLHEMN LIKDEHHKFEH, bool GIKLNODJKFK) { }

	// // RVA: 0x12176B8 Offset: 0x12176B8 VA: 0x12176B8
	// private void NIIMCBEJHDE(AMLGMLNGMFB LIKDEHHKFEH, int MNKCJGIGPJP, bool GIKLNODJKFK) { }

	// // RVA: 0x1218364 Offset: 0x1218364 VA: 0x1218364
	// private void FILJLEHKBJO(int KHCGNGEJLKC) { }

	// // RVA: 0x1218420 Offset: 0x1218420 VA: 0x1218420
	// private void JBOHCKEIHKI(int GHBPLHBNMBK, long JIHKOPIENAC, bool PJLNJJIBFBN, int PGIIDPEGGPI) { }

	// // RVA: 0x1218DB8 Offset: 0x1218DB8 VA: 0x1218DB8
	public static bool LBHPMGDNPHK(int GHBPLHBNMBK_FreeMusicId, int DEPGBBJMFED_CategoryId)
	{
		KEODKEGFDLD_FreeMusicInfo musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId);
		if(musicInfo.PPEGAKEIEGM_Enabled == 2)
		{
			if(DEPGBBJMFED_CategoryId != -1)
			{
				if (musicInfo.DEPGBBJMFED_CategoryId != DEPGBBJMFED_CategoryId)
					return false;
			}
			TodoLogger.Log(0, "Finish LBHPMGDNPHK");
			/*if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.JOHMIPPKPPM > 0)
			{

			}*/
			JPCKBFBCJKD data = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.LLJOPJMIGPD(GHBPLHBNMBK_FreeMusicId);
			if (data == null)
				return true;

			TodoLogger.Log(0, "Finish LBHPMGDNPHK");
		}

		return false;
	}

	// // RVA: 0x1219160 Offset: 0x1219160 VA: 0x1219160
	// private void NPEKPHAFMGE(int CPBFAMJEODF, int MGHPJNNDCIG) { }

	// // RVA: 0x1219268 Offset: 0x1219268 VA: 0x1219268
	// public static List<int> CJHOOLJFGFB() { }

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
		if(DEPGBBJMFED_Serie != 5)
		{
			OHCAABOMEOF.KGOGMKMBCPP_EventType type = 0;
			IKDICBBFBMI_EventBase data = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI, false);
			if(data != null)
			{
				type = data.HIDHLFCBIDE_EventType;
				if(type != OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
					type = 0;
			}
			//LAB_0121a02c:
			TodoLogger.Log(0, "finish FKDIMODKKJD (generate song list)");
			//event? = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.CLLPBOPLICM_EventWeekDay.PPIBJECKCEF(JHNMKKNEENE);
			DateTime time = Utility.GetLocalDateTime(JHNMKKNEENE_Date);
			for(int i = 0; i < numSongs; i++)
			{
				KEODKEGFDLD_FreeMusicInfo musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[i];
				if (musicInfo.PPEGAKEIEGM_Enabled == 2)
				{
					if (musicInfo.GBNOALJPOBM || !JCOJKAHFADL)
					{
						if (DEPGBBJMFED_Serie != -1)
						{
							if(musicInfo.DEPGBBJMFED_CategoryId != DEPGBBJMFED_Serie)
							{
								continue;
							}
						}
						bool b = false;
						int val = 0;
						bool b2 = false;
						if(DEPGBBJMFED_Serie == 5 && /*event.FLPDCNBLOKL(time.??, musicInfo.GHBPLHBNMBK)*/ false)
						{
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[i].FKBPJCDBDAG_SetWeekEventServerDate(JHNMKKNEENE_Date);
							//Setup vars
							//L311
							b = true;
							val = 0;//event.KKNJPEMGEBF + event.IIJFLONJAFL;
							b2 = false;//event.KKNJPEMGEBF > 0;
						}
						else
						{
							if(!OJEBNBLHPNP)
							{
								// set vars
								b = false;
								val = 0;
								if (!LBHPMGDNPHK(musicInfo.GHBPLHBNMBK_FreeMusicId, DEPGBBJMFED_Serie))
									continue;
							}
						}
						IBJAKJJICBC songInfo = new IBJAKJJICBC();
						songInfo.KHEKNNFCAOI(musicInfo.GHBPLHBNMBK_FreeMusicId, b, time.Millisecond/*??*/, val, JHNMKKNEENE_Date, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.FPGDAPAILAK_ExtremeUnlock == 2, false, JCOJKAHFADL);
						songInfo.MFJKNCACBDG = (int)type;
						songInfo.GDLNCHCPMCK_HasBoost = b2;
						if(EHBPHDPHPKF)
						{
							if(songInfo.CADENLBDAEB)
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
			if(DEPGBBJMFED_Serie != 5)
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
			for(int i = 0; i < list.Count; i++)
			{
				res.Add(list[i]);
			}
			return res;
		}

		if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI, false) != null)
		{
			TodoLogger.Log(0, "FKDIMODKKJD (generate song list event)");
		}
		if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI) != null)
		{
			TodoLogger.Log(0, "FKDIMODKKJD (generate song list event)");
		}
		List<IKDICBBFBMI_EventBase> list2 = DJPFFHLCCNL(OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB, JHNMKKNEENE_Date, KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI);
		for(int i = 0; i < list2.Count; i++)
		{
			TodoLogger.Log(0, "FKDIMODKKJD (generate song list event)");
		}

        return res;
    }

	// // RVA: 0x121AA58 Offset: 0x121AA58 VA: 0x121AA58
	private static List<IKDICBBFBMI_EventBase> DJPFFHLCCNL(OHCAABOMEOF.KGOGMKMBCPP_EventType INDDJNMPONH, long JHNMKKNEENE, KGCNCBOKCBA.GNENJEHKMHD BELFNAHNMDL = KGCNCBOKCBA.GNENJEHKMHD.BCKENOKGLIJ/*9*/)
	{
		TodoLogger.Log(0, "DJPFFHLCCNL");
		return new List<IKDICBBFBMI_EventBase>();
	}

	// // RVA: 0x121BE84 Offset: 0x121BE84 VA: 0x121BE84
	// public static List<IBJAKJJICBC> ENHMHDALFDB(long JHNMKKNEENE, bool EHBPHDPHPKF = False, bool JCOJKAHFADL = False) { }

	// // RVA: 0x121C6BC Offset: 0x121C6BC VA: 0x121C6BC
	// public static List<IBJAKJJICBC> EHNABCEGAHO(long JHNMKKNEENE, bool EHBPHDPHPKF = False, bool JCOJKAHFADL = False) { }

	// // RVA: 0x121ACC8 Offset: 0x121ACC8 VA: 0x121ACC8
	public static List<IBJAKJJICBC> LIENJMIJMIE(long JHNMKKNEENE, bool GBNOALJPOBM = false)
    {
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo.Count < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas.Count)
		{
			//CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_Save.LCKMBHDMPIP.FAMANJGJANN.Count ??
		}
		List<IBJAKJJICBC> res = new List<IBJAKJJICBC>();
		IKDICBBFBMI_EventBase data = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI, false);
		if(data != null && data.HEACCHAKMFG().Count > 0)
		{
			TodoLogger.Log(0, "FKDIMODKKJD event info");
		}
		data = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI);
		if(data != null)
		{
			TodoLogger.Log(0, "FKDIMODKKJD event info");
		}
		List<IKDICBBFBMI_EventBase> ldata = DJPFFHLCCNL(OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB, JHNMKKNEENE, KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI);
		for(int i = 0; i < ldata.Count; i++)
		{
			TodoLogger.Log(0, "FKDIMODKKJD event info");
		}
        return res;
    }

	// // RVA: 0x121CBD4 Offset: 0x121CBD4 VA: 0x121CBD4
	// public static void GNNIJFBOBAJ(List<IBJAKJJICBC> NNDGIAEFMOG) { }

	// // RVA: 0x121CE9C Offset: 0x121CE9C VA: 0x121CE9C
	// public static void BDNIEPMOHDI(List<IBJAKJJICBC> NNDGIAEFMOG) { }

	// // RVA: 0x121D0DC Offset: 0x121D0DC VA: 0x121D0DC
	// public static List<IBJAKJJICBC> FMHFMIMDOCM(int DEPGBBJMFED, long JHNMKKNEENE, bool JCOJKAHFADL = False) { }

	// // RVA: 0x121DF50 Offset: 0x121DF50 VA: 0x121DF50
	// public static List<IBJAKJJICBC> DHFHJBMKEHN(int DEPGBBJMFED, long JHNMKKNEENE, bool JCOJKAHFADL = False) { }

	// // RVA: 0x121E028 Offset: 0x121E028 VA: 0x121E028
	// public static List<IBJAKJJICBC> ONHHIHBHKPK(int DEPGBBJMFED, long JHNMKKNEENE, bool JCOJKAHFADL = False) { }

	// // RVA: 0x121D1B4 Offset: 0x121D1B4 VA: 0x121D1B4
	// private static List<IBJAKJJICBC> MJAJPHIKGBF(int DEPGBBJMFED, long JHNMKKNEENE, bool JCOJKAHFADL, IKDICBBFBMI FBFNJMKPBBA, OHCAABOMEOF.KGOGMKMBCPP HIDHLFCBIDE) { }

	// // RVA: 0x121E210 Offset: 0x121E210 VA: 0x121E210
	// public static List<IBJAKJJICBC> GCCBCAKFJMF(int DEPGBBJMFED, long JHNMKKNEENE, int OAFJONPIFGM, bool JCOJKAHFADL = False) { }

	// // RVA: 0x121F428 Offset: 0x121F428 VA: 0x121F428
	// public static IBJAKJJICBC MLMMPFACEKI(int GHBPLHBNMBK, List<IBJAKJJICBC> OEAJOJMOGMH, List<IBJAKJJICBC> FCCKCFEEOMN, List<IBJAKJJICBC> LCKJDADHOEB, List<IBJAKJJICBC> BAOEHOFNOOG, List<IBJAKJJICBC> EGLEKOHJBNA, List<IBJAKJJICBC> GEEODBLIDDB, ref int EIPGHNKPAOH, ref int OIPCCBHIKIA) { }

	// // RVA: 0x121F99C Offset: 0x121F99C VA: 0x121F99C Slot: 3
	// public override string ToString() { }

	// // RVA: 0x121FC40 Offset: 0x121FC40 VA: 0x121FC40
	// public static bool FPLIAMHMFJP() { }

	// // RVA: 0x121FEF4 Offset: 0x121FEF4 VA: 0x121FEF4
	public static int POPLHDKHIIM()
    {
        return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("line6_unlock_uta_rate", 250);
    }

	// // RVA: 0x121FFE4 Offset: 0x121FFE4 VA: 0x121FFE4
	// public static bool KGJJCAKCMLO(int AAODIMMEFBI) { }

	// // RVA: 0x1215A78 Offset: 0x1215A78 VA: 0x1215A78
	public static bool KGJJCAKCMLO()
    {
        return true;
    }
}
