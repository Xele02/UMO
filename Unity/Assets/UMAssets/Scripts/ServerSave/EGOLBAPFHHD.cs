using System;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

[System.Obsolete("Use EGOLBAPFHHD_Common", true)]
public class EGOLBAPFHHD { }
public class EGOLBAPFHHD_Common : KLFDBFMNLBL_ServerSaveBlock
{
	public class OFAPDOKONML
	{
		public int EHOIENNDEDH; // 0x8
		public int IFEHKNJONPL; // 0xC
		public int ONFJFGFNGGD; // 0x10
		public int FBGGEFFJJHB; // 0x14

		public int PPFNGGCBJKC_Id { get { return FBGGEFFJJHB ^ EHOIENNDEDH; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value;} } //0x12E8E34 DEMEPMAEJOO 0x12E8E44 HIGKAIDMOKN
		public int BFINGCJHOHI_Cnt { get { return FBGGEFFJJHB ^ IFEHKNJONPL; } set {
			int val = 99999;
			if(value < 99999)
				val = value;
			IFEHKNJONPL = FBGGEFFJJHB ^ val;
			ONFJFGFNGGD = value;
		} } //0x12E8E54 LFMCLIDAPHB 0x12E8E64 EDAEPDGGFJJ

		// // RVA: 0x12E8E88 Offset: 0x12E8E88 VA: 0x12E8E88
		// public bool PFAKPFKJJKA() { }
	}

	public class AMCANGCIBEG
	{
		public int EHOIENNDEDH; // 0x8
		public int IFEHKNJONPL; // 0xC
		public int ONFJFGFNGGD; // 0x10
		public int FBGGEFFJJHB; // 0x14

		public int PPFNGGCBJKC_Id { get { return FBGGEFFJJHB ^ EHOIENNDEDH; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value; } } //0x12E8B68 DEMEPMAEJOO 0x12E8B78 HIGKAIDMOKN
		public int BFINGCJHOHI_Cnt { get { return FBGGEFFJJHB ^ IFEHKNJONPL; } set { 
			int val = 9999;
			if(value < 9999)
				val = value;
			IFEHKNJONPL = FBGGEFFJJHB ^ val;
			ONFJFGFNGGD = value;
		 } } //0x12E8B88 LFMCLIDAPHB 0x12E8B98 EDAEPDGGFJJ

		// RVA: 0x12E8BB8 Offset: 0x12E8BB8 VA: 0x12E8BB8
		// public bool PFAKPFKJJKA() { }
	}

	public class FKLHGOGJOHH
	{
		public int FBGGEFFJJHB; // 0x8
		public int EHOIENNDEDH; // 0xC
		public int IFEHKNJONPL; // 0x10
		public int ONFJFGFNGGD; // 0x14
		public long KLAPHOKNEDG; // 0x18

		public int PPFNGGCBJKC_Id { get { return FBGGEFFJJHB ^ EHOIENNDEDH; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value; } } //0x12E8C2C DEMEPMAEJOO 0x12E8C38 HIGKAIDMOKN
		public int BFINGCJHOHI_Cnt { get { return FBGGEFFJJHB ^ IFEHKNJONPL; } set { 
			IFEHKNJONPL = FBGGEFFJJHB ^ value;
			ONFJFGFNGGD = value;
		 } } //0x12E8C48 LFMCLIDAPHB 0x12E8C58 EDAEPDGGFJJ
		public long BEBJKJKBOGH_Date { get { return KLAPHOKNEDG ^ FBGGEFFJJHB; } set { KLAPHOKNEDG = FBGGEFFJJHB ^ value; } } //0x12E8C6C DIAPHCJBPFD 0x12E8C84 IHAIKPNEEJE
	}

	public class MCOEBJCAMKO
	{
		public int FBGGEFFJJHB; // 0x8
		public int EHOIENNDEDH; // 0xC
		public long KLAPHOKNEDG; // 0x10
		public long JMFGGKLPKOM; // 0x18

		public int PPFNGGCBJKC_Id { get { return FBGGEFFJJHB ^ EHOIENNDEDH; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value; } } //0x12E8DDC DEMEPMAEJOO 0x12E8DE8 HIGKAIDMOKN
		public long BEBJKJKBOGH_Date { get { return FBGGEFFJJHB ^ KLAPHOKNEDG; } set { 
			KLAPHOKNEDG = FBGGEFFJJHB ^ value;
			JMFGGKLPKOM = value;
		 } } //0x12E8DF8 DIAPHCJBPFD 0x12E8E10 IHAIKPNEEJE
	}

	public class DEEGPPKGGLK
	{
		public int FBGGEFFJJHB; // 0x8
		public int EHOIENNDEDH; // 0xC
		public int IFEHKNJONPL; // 0x10
		public int ONFJFGFNGGD; // 0x14

		public int PPFNGGCBJKC_Id { get { return FBGGEFFJJHB ^ EHOIENNDEDH; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value; } } //0x12E8BE0 DEMEPMAEJOO 0x12E8BF0 HIGKAIDMOKN
		public int BFINGCJHOHI_Cnt { get { return FBGGEFFJJHB ^ IFEHKNJONPL; } set { 
			IFEHKNJONPL = FBGGEFFJJHB ^ value;
			ONFJFGFNGGD = value;
		 } } //0x12E8C00 LFMCLIDAPHB 0x12E8C10 EDAEPDGGFJJ
	}

	public class GLBBNDKGEOC
	{
		public int FBGGEFFJJHB; // 0x8
		public int EHOIENNDEDH; // 0xC
		public int IFEHKNJONPL; // 0x10
		public int ONFJFGFNGGD; // 0x14
		public long KLAPHOKNEDG; // 0x18

		public int PPFNGGCBJKC_Id { get { return FBGGEFFJJHB ^ EHOIENNDEDH; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value; } } //0x12E8D1C DEMEPMAEJOO 0x12E8D28 HIGKAIDMOKN
		public int BFINGCJHOHI_Cnt { get { return FBGGEFFJJHB ^ IFEHKNJONPL; } set { 
			IFEHKNJONPL = FBGGEFFJJHB ^ value;
			ONFJFGFNGGD = value;
		 } } //0x12E8D38 LFMCLIDAPHB 0x12E8D48 EDAEPDGGFJJ
		public long BEBJKJKBOGH_Date { get; set; } //0x12E8D5C DIAPHCJBPFD 0x12E8D74 IHAIKPNEEJE
	}

	public class KPMNLAHNDAI
	{
		public int FBGGEFFJJHB; // 0x8
		public int EHOIENNDEDH; // 0xC
		public int INCHFKJOIEK; // 0x10
		public int IFEHKNJONPL; // 0x14
		public int ONFJFGFNGGD; // 0x18

		public int PPFNGGCBJKC_Id { get { return FBGGEFFJJHB ^ EHOIENNDEDH; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value; } } //0x12E8D90 DEMEPMAEJOO 0x12E8DA0 HIGKAIDMOKN
		public int BFINGCJHOHI_Cnt { get { return FBGGEFFJJHB ^ IFEHKNJONPL; } set { 
			IFEHKNJONPL = FBGGEFFJJHB ^ value;
			ONFJFGFNGGD = value;
		 } } //0x12E8DB0 LFMCLIDAPHB 0x12E8DC0 EDAEPDGGFJJ
	}

	public class PGENIOHDCDI
	{
		public int EHOIENNDEDH; // 0x8
		public int IFEHKNJONPL; // 0xC
		public int ONFJFGFNGGD; // 0x10
		public int FBGGEFFJJHB; // 0x14

		public int PPFNGGCBJKC_Id { get { return FBGGEFFJJHB ^ EHOIENNDEDH; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value; } } //0x12E8F44 DEMEPMAEJOO 0x12E8F54 HIGKAIDMOKN
		public int BFINGCJHOHI_Cnt { get { return FBGGEFFJJHB ^ IFEHKNJONPL; } set { 
			int val = 9999;
			if(value < 9999)
				val = value;
			IFEHKNJONPL = FBGGEFFJJHB ^ val;
			ONFJFGFNGGD = value;
		 } } //0x12E8F64 LFMCLIDAPHB 0x12E8F74 EDAEPDGGFJJ

		// RVA: 0x12E8F94 Offset: 0x12E8F94 VA: 0x12E8F94
		// public bool PFAKPFKJJKA() { }
	}

	public class PCHECKGDJDK
	{
		public int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH; // 0xC
		private int INCHFKJOIEK; // 0x10
		private int HLMAFFLCCKD; // 0x14
		private int IMKEAJDJANE; // 0x18
		private int GEBFFOCPJBK; // 0x1C
		private int PPNJFMANPEP; // 0x20

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; INCHFKJOIEK = value ^ FBGGEFFJJHB;  } } //0x12E89C8 DEMEPMAEJOO 0x12E8EB0 HIGKAIDMOKN
		public int HMFFHLPNMPH { get { return HLMAFFLCCKD ^ FBGGEFFJJHB; } set { IMKEAJDJANE = value; HLMAFFLCCKD = value ^ FBGGEFFJJHB; } } //0x12E8EC4 NJOGDDPICKG 0x12E8ED4 NBBGMMBICNA
		public int JJKGPMFJJNE { get { return GEBFFOCPJBK ^ FBGGEFFJJHB; } set { PPNJFMANPEP = value; GEBFFOCPJBK = value ^ FBGGEFFJJHB; } } //0x12E8A68 FBJHKIFIMCG 0x12E8EE8 ONLFECLGCKF

		// RVA: 0x12E8EFC Offset: 0x12E8EFC VA: 0x12E8EFC
		// public bool PFAKPFKJJKA() { }
	}

	public class GHOADMJCPFK
	{
		public int EHOIENNDEDH; // 0x8
		public int IFEHKNJONPL; // 0xC
		public int ONFJFGFNGGD; // 0x10
		public int FBGGEFFJJHB; // 0x14

		public int PPFNGGCBJKC_Id { get { return FBGGEFFJJHB ^ EHOIENNDEDH; } set { EHOIENNDEDH = FBGGEFFJJHB ^ value; } } //0x12E8CA0 DEMEPMAEJOO 0x12E8CB0 HIGKAIDMOKN
		public int BFINGCJHOHI_Cnt { get { return FBGGEFFJJHB ^ IFEHKNJONPL; } set { 
			int val = 99999;
			if(value < 99999)
				val = value;
			IFEHKNJONPL = FBGGEFFJJHB ^ value;
			ONFJFGFNGGD = value;
		 } } //0x12E8CC0 LFMCLIDAPHB 0x12E8CD0 EDAEPDGGFJJ

		// RVA: 0x12E8CF4 Offset: 0x12E8CF4 VA: 0x12E8CF4
		// public bool PFAKPFKJJKA() { }
	}

	// private const int ECFEMKGFDCE = 4;
	// private const int OKDLBLFMBGJ = 27;
	// private const int NGLFGHMFKMO = 3;
	// private const int GKEPHHJHENI = 5;
	// private const int DFGNIIOIGNA = 16;
	// private const int LEOEGBOLMBG = 40;
	// private const int OEKFMMNFDOE = 16;
	// private const int JBCJEIOBAPO = 23;
	// private const int LAKOAMCCDEJ = 31;
	// private const int LBDKDGJDEHF = 1;
	// private const int GCGMFEBAEBK = 23;
	// private const int HPFICBIIPMH = 5;
	// private const int GHGNOHPLBPF = 100;
	// public const int GNAOICCFPDG = 99999;
	// public const int KMKNHHDAHCP = 99999;
	// public const int JLKODLKNLFP = 9999;
	// public const int HBNMHMEEDEM = 9999;
	// public const int GMDCDEIEBGN = 99999;
	// public const int FDDCKGPMEFN = 99999;
	// public const int EPONHPIBJDM = 99999;
	// public const int FBOFDPLBHCP = 99999;
	// public const int KLNIPDAEFLC = 9999999;
	// public const int GLDFODJIEAM = 99999999;
	// public const int MOFMCDOPKMH = 99999;
	// public const int LEBBFBNHHJP = 9999;
	// public const int AMLNCABEDNC = 99999999;
	// public const int KOBMAJDPKOG = 2160;
	// public const int CABCGDEBACO = 9999;
	// public const int GEFOPNDKDBL = 128;
	// public const int BNDEHIAIMGM = 16;
	// public const int GHMNJCBHOCG = 128;
	// public const int HFMBDHEFCGM = 16;
	// public const int DIONOGEJFIC = 64;
	// public const int MBFKHNKJEPD = 8;
	// public const int PCHMBHIAHBC = 3;
	// public const int KDKNCMFHMNI = 2000;
	// public const int DNDHCKFLAIO = 500;
	// public const int HEMOONBNMLK = 2000;
	// public const int HKJKONOKBLN = 250;
	// public const int HHIJCJHHLIB = 3;
	// public const int HPFCEFJFNIE = 300;
	// public const int GACHAOJLMEB = 38;
	// public const int PKJOCFEOHMO = 99999999;
	// public const int HDNKNGJHPJJ = 3;
	// public const int FDPBFCGEIJK = 4;
	// public const int MBCKPJJPMOH = 4;
	private int LEDNHIFBCON_StaminaCrypted; // 0x24
	private long DABADKNMNCA_StaminaSaveTimeCrypted; // 0x28
	private int MDJGIOGOGAO_HaveUcCrypted; // 0x30
	private int HMJBBNEACOA_LevelCrypted; // 0x34
	private int PAHPNGJFKMO_ExpCrypted; // 0x38
	private int BECMBCHHHHA_StaminaCheck; // 0x3C
	private long BCKIGFDMGBO_StaminaSaveTimeCheck; // 0x40
	public int HIGJEJKADDP_HaveUcCheck; // 0x48
	private int FEDJFDMAPMA_LevelCheck; // 0x4C
	private int CAPBCOFKBHL_ExpCheck; // 0x50
	private int PJKDBODIGPG_Cont; // 0x54
	private int FBGGEFFJJHB; // 0x58
	private long GEDGKCOBBDC_LastLotTimeCheck; // 0x60
	private long LPIGOJLAHPH_LastLotTimeCrypted; // 0x68
	private long AEJAEPMONML_FChkTimeCheck; // 0x70
	private long CFOJKIILILI_FChkTimeCrypted; // 0x78
	private int HIDCMICKMLC_StaminaLotDoneCrypted; // 0x80
	private int EPOBDCLKKEL_StaminaLotDoneCheck; // 0x84
	private int OPFECLMNEIJ_DivaFirstCheck; // 0x88
	private long ICJJIHEKJMM_StamineLotTimeCrypted; // 0x90
	private long FBLJNJNBGHD_StamineLotTimeCheck; // 0x98
	private int CDONLFHFPCE_NumTicketCheck; // 0xA0
	private int NAIKJMLIMKH_NumTicketCrypted; // 0xA4
	private int JMDEFOPGKPD_EvGachaTicketCheck; // 0xA8
	private int IANFKMGHBCE_EvGachaTicketCrypted; // 0xAC
	private int EHFKDKCHMFP_DivaFirstCrypted; // 0xB0
	private int OFDGAHPFPIF_AddRegularMusicMVerCheck; // 0xB4
	private int LNHFHAGMAEL_AddRegularMusicMVerCrypted; // 0xB8
	private int IGHKJBCODBP_IntimacyCntValCrypted; // 0xBC
	private int ADFDMJKMGHH_IntimacyCntValCheck; // 0xC0
	private long NPMEFDAPCJA_IntimacyCntSaveTimeCrypted; // 0xC8
	private long FJFOJEHNCJE_IntimacyCntSaveTimeCheck; // 0xD0
	private long KIBFFJFBLDM_IntimacyTensionSaveTimeCrypted; // 0xD8
	private long GJACOCPOODC_IntimacyTensionSaveTimeCheck; // 0xE0
	private long CNLNBAFAKJB_IntimacyTouchSaveTimeCrypted; // 0xE8
	private long DCIDLBGNPOC_IntimacyTouchSaveTimeCheck; // 0xF0
	private int DPOFEICCHFG_IntimacyPresentSaveDateCrypted; // 0xF8
	private int LIGPENECNLA_IntimacyPresentSaveDateCheck; // 0xFC
	private int CHBFLALKKON_EvBtlClsuCrypted; // 0x100
	private int NNADNBDMJEC_EvBtlClsuCheck; // 0x104
	private long LNOAFOOIJEF_GachaLastShowTimeCrypted; // 0x108
	private long MGMHKPBGDDP_GachaLastShowTimeCheck; // 0x110
	private long AKHADFNHCBJ_EpisodeLastShowTimeCrypted; // 0x118
	private long JHLMNABIFLC_EpisodeLastShowTimeCheck; // 0x120
	private long ELILELKGALC_RichbannerLastShowTimeCrypted; // 0x128
	private long PAMGCEIDHEM_RichbannerLastShowTimeCheck; // 0x130
	private int HKHJMINFNPM_LastFmCrypted; // 0x138
	private int LFBBBAMEAHA_LastFmCheck; // 0x13C
	private int BEHGDBOFFDD_LastDfCrypted; // 0x140
	private int JPANEGCAJJM_LastDfCheck; // 0x144
	private int LNEAGENPAGD_ClStCrypted; // 0x148
	private int LMFFCFKMNFI_ClStCheck; // 0x14C
	private int KKCFKKJPKFK_LastStoryCrypted; // 0x150
	private int PIKKLHHJMHG_LastStoryCheck; // 0x154
	private int NKDGNNCEFKG_HaveDecoPointCrypted; // 0x158
	private int AOBKHNIEOJN_HaveDecoPointCheck; // 0x15C
	private int CHMMENJAELL_TotalUtaRateCrypted; // 0x160
	private int KMPPPIMMAIO_TotalUtaRateCheck; // 0x164
	private int CLJCIKDHFGC_McGaugeCrypted; // 0x168
	private int BPFJBAGFOCJ_McGaugeCheck; // 0x16C
	private int KJFPHEOKMKF_LsCntCrypted; // 0x170
	private int HGKJPCJNIOI_LsCntCheck; // 0x174
	private int JKPEIHMEAOL_SlsCntCrypted; // 0x178
	private int CFMGODELIJG_SlsCntCheck; // 0x17C
	private int LJOGKKMMMIK_LsDateCrypted; // 0x180
	private int HEEJIOKPNPE_LsDateCheck; // 0x184
	private int MHJMKFCIIJK_LsGetDataCrypted; // 0x188
	private int LKENFBHINJB_LsGetDataCheck; // 0x18C
	// private int MAOFLDDLCEL; // 0x190
	// private int KNPGEACDKAN; // 0x194
	private int BEPHNLLHMNK_RetRewRecGraCrypted; // 0x198
	private int MICPOFPGEPJ_RetRewRecGraCheck; // 0x19C
	private int MGBNGLLLKEG_HomeSceneIdCrypted; // 0x1A0
	private int HKEILPBFDKO_HomeSceneIdCheck; // 0x1A4
	private int JODNOFABBPB_HomeSceneEvolveIdCrypted; // 0x1A8
	private int JKOKFDJOOJC_HomeSceneEvolveIdCheck; // 0x1AC
	private int ECPIHFNFPBI_HomeShowDivaCrypted; // 0x1B0
	private int BOCFHLKBAJH_HomeShowDivaCheck; // 0x1B4
	private int EMFNMLIDDEB_HomeBgDarkCrypted; // 0x1B8
	private int OOCCCOODFMD_HomeBgDarkCheck; // 0x1BC
	// public long LEJCFDCGDIH; // 0x1C8
	// public long MFFDLIKPBNC; // 0x1D0
	private int GDFLEEOFHAE_PstVerCrypted; // 0x1EC
	private int HLDNLILBPNF_PstVerCheck; // 0x1F0
	private int HMBADEDLHPE_DvfVerCrypted; // 0x1F4
	private int NFDADDLHKHO_DvfVerCheck; // 0x1F8
	private int FEBIENOBKPP_TrsVerCrypted; // 0x1FC
	private int ECAEFPKEADC_TrsVerCheck; // 0x200
	private int KONGEMOMHLN_DMasVerCrypted; // 0x204
	private int FMCFFBNMCDH_DMasVerCheck; // 0x208
	public long GDMNOMIEIMP_RvDate; // 0x218
	public int JOKHEHFGDOP_RvStep; // 0x220
	public int INAECNHELAM_ShowSnsBal; // 0x224
	public int JLJJHDGEHLK_RecvSns; // 0x228
	private byte[] FNMNMILHIGN_ShowTips = new byte[16]; // 0x22C
	private byte[] IGEFEGIFPID_ShowTipsSub = new byte[16]; // 0x230
	private byte[] KEIIOKGGEOJ_ShowAnketo = new byte[8]; // 0x234
	private byte[] NOMENBABPBK_ShowUnitLiveAdd = new byte[500]; // 0x238
	private byte[] DJEBJLIHDJH_ShowLine6Add = new byte[250]; // 0x23C
	public static string PMOJBGHJALI = JpStringLiterals.StringLiteral_10040; // 0x0
	public static string ILDBPMEIMFP = JpStringLiterals.StringLiteral_10041; // 0x4
	public static string EIIGCNIGEMI = JpStringLiterals.StringLiteral_10042; // 0x8
	private string LKLIDCMCCCG_MusicBookmarkName1 = PMOJBGHJALI; // 0x240
	private string CHNPJHGCAOP_MusicBookmarkName2 = ILDBPMEIMFP; // 0x244
	private string JMIHCFPDPFP_MusicBookmarkName3 = EIIGCNIGEMI; // 0x248
	private byte[] JKFFMINPPNN_MusicBookmark1 = new byte[38]; // 0x24C
	private byte[] DEOHDPMNFEF_MusicBookmark2 = new byte[38]; // 0x250
	private byte[] JNPCHIGAIAF_MusicBookmark3 = new byte[38]; // 0x254
	public int ACNNFJJMEEO_StoryEnd; // 0x25C
	private List<EGOLBAPFHHD_Common.PCHECKGDJDK> KKPNGCNBJHO_GachaDraw = new List<EGOLBAPFHHD_Common.PCHECKGDJDK>(); // 0x260
	private int[] CKDPJCLINAB_GpFlg = new int[1]; // 0x264
	private const int JHHLBIHEPDJ_True = 358;
	private const int DFMOPCKCCHF_False = 935;
	private int GJGGADEPCKF = DFMOPCKCCHF_False; // 0x26C
	private const int IMADHFOIHKL_True = 745;
	private const int DBCCJBLMKEK_False = 359;
	private int BGNMKGDHJFI = DBCCJBLMKEK_False; // 0x270
	private const int CHDIBMHLHCN_True = 495; // 0x1ef
	private const int BBCALMHCGGF_False = 869; // 0x365
	private int JCOMMCBJDPK = BBCALMHCGGF_False; // 0x274

	public int DLBLONNCCCE_MainTeamId { get; set; } // 0x1C0 PEOLEKNCNEB GNLBMENIPLF OKNPIBCFOMA
	public int NIKCFOALFJC_DivaFirst { get { return EHFKDKCHMFP_DivaFirstCrypted ^ FBGGEFFJJHB; } set { OPFECLMNEIJ_DivaFirstCheck = value; EHFKDKCHMFP_DivaFirstCrypted = value ^ FBGGEFFJJHB; } } //HMDBHOEGALL 0x1C512E4 IIIKHGOCIGF 0x1C512F4
	public int BCFPEJODJPP_Stamina { get { return LEDNHIFBCON_StaminaCrypted ^ FBGGEFFJJHB; } set { BECMBCHHHHA_StaminaCheck = value; LEDNHIFBCON_StaminaCrypted = value ^ FBGGEFFJJHB; } } //JNIDNCEICCE 0x1C51308 CPIJOEDODBG 0x1C51318
	public long FOKNAMPDPFP_StaminaSaveTime { get { return DABADKNMNCA_StaminaSaveTimeCrypted ^ FBGGEFFJJHB; } set { BCKIGFDMGBO_StaminaSaveTimeCheck = value; DABADKNMNCA_StaminaSaveTimeCrypted = value ^ FBGGEFFJJHB; }  } //EMONLIDLFEC 0x1C5132C  AICIKGMHEBE 0x1C51340
	public int NFHLDFJIBKI_HaveUc { get { return MDJGIOGOGAO_HaveUcCrypted ^ FBGGEFFJJHB; } set { HIGJEJKADDP_HaveUcCheck = value; MDJGIOGOGAO_HaveUcCrypted = value ^ FBGGEFFJJHB; } } //DDLMHIAOLMM 0x1C51360 MJBPIJKNPHD 0x1C51370
	public int KIECDDFNCAN_Level { get {
			if (RuntimeSettings.CurrentSettings.ForcePlayerLevel > -1)
				return RuntimeSettings.CurrentSettings.ForcePlayerLevel;
			return (int)(HMJBBNEACOA_LevelCrypted ^ FBGGEFFJJHB);
	} set {
		FEDJFDMAPMA_LevelCheck = value;
		HMJBBNEACOA_LevelCrypted = value ^ FBGGEFFJJHB;
	 } } //LNOBPNDNEAK 0x1C49114  BNGHHNPKLNB 0x1C513D8
	public int EOHDMCMHBKJ_Exp { get { return PAHPNGJFKMO_ExpCrypted ^ FBGGEFFJJHB; } set { CAPBCOFKBHL_ExpCheck = value; PAHPNGJFKMO_ExpCrypted = value ^ FBGGEFFJJHB; } } //BJCPOLILHAK 0x1C513EC  HHCEHNHHKFM 0x1C513FC
	public List<EGOLBAPFHHD_Common.OFAPDOKONML> KBMDMEEMGLK_GrowItem { get; private set; } // 0x1D8 HFAPPMPFOGA BDOKMMIIEPK ECDKAGIGFBN
	public List<EGOLBAPFHHD_Common.AMCANGCIBEG> GJODJNIHKKF_EpiItem { get; private set; } // 0x1DC GCEBOGKOJPL AHGCJELKMEN IAJJEALILHI
	public List<EGOLBAPFHHD_Common.FKLHGOGJOHH> KFEBOFKAHAJ_EngItem { get; private set; } // 0x1E0 LDJGFDAGENC KGMMJPIPCHF DKPIHJOMECC
	public List<EGOLBAPFHHD_Common.MCOEBJCAMKO> POCPLFJCHDD_HomeBg { get; private set; } // 0x1E4 MEKDBAGFMIM KCMIGNMDIEI CODNAMHIJHJ
	public int GKKDNOFMJJN_NumTicket { get { return NAIKJMLIMKH_NumTicketCrypted ^ FBGGEFFJJHB; } set { 
		CDONLFHFPCE_NumTicketCheck = value;
		NAIKJMLIMKH_NumTicketCrypted = FBGGEFFJJHB ^ value;
	 } } //DHIKNMLCBBN 0x1C516B0  IPBOHCBCGPA 0x1C516C0 // slive item count
	public int MMPPEHPKGLI_AddRegularMusicMVer { get { return LNHFHAGMAEL_AddRegularMusicMVerCrypted ^ FBGGEFFJJHB; } set { OFDGAHPFPIF_AddRegularMusicMVerCheck = value; LNHFHAGMAEL_AddRegularMusicMVerCrypted = value ^ FBGGEFFJJHB; } } //EPPMGOBBNMK 0x1C516D4  HCKEHADGEBB 0x1C516E4
	public int MEMHJKEONBB_EvGachaTicket { get { return IANFKMGHBCE_EvGachaTicketCrypted ^ FBGGEFFJJHB; } set { JMDEFOPGKPD_EvGachaTicketCheck = value; IANFKMGHBCE_EvGachaTicketCrypted = value ^ FBGGEFFJJHB; } } //JKBGMACMDPK 0x1C516F8  GFKEAKDDHAM 0x1C51708
	public int BGEGFMKGNHN_IntimacyCntVal { get { return IGHKJBCODBP_IntimacyCntValCrypted ^ FBGGEFFJJHB; } set { ADFDMJKMGHH_IntimacyCntValCheck = value; IGHKJBCODBP_IntimacyCntValCrypted = value ^ FBGGEFFJJHB; } } //LBHHIDIHMIE 0x1C5171C NAHEGCNNAFJ 0x1C5172C
	public long ANOCNJABDJO_IntimacyCntSaveTime { get { return NPMEFDAPCJA_IntimacyCntSaveTimeCrypted ^ FBGGEFFJJHB; } set { FJFOJEHNCJE_IntimacyCntSaveTimeCheck = value; NPMEFDAPCJA_IntimacyCntSaveTimeCrypted = value ^ FBGGEFFJJHB; } } //OIIGNPKLMEE 0x1C51740 EOFMHCGNAFF 0x1C51758
	public List<EGOLBAPFHHD_Common.DEEGPPKGGLK> DHJFHILPKLB_IntimacyPresent { get; private set; } // 0x1E8 KOAOIBOJPJH BFLNGPACKNK GNEKEMEOPPB
	public long FGDNHEABLBN_IntimacyTensionSaveTime { get { return KIBFFJFBLDM_IntimacyTensionSaveTimeCrypted ^ FBGGEFFJJHB; } set { GJACOCPOODC_IntimacyTensionSaveTimeCheck = value; KIBFFJFBLDM_IntimacyTensionSaveTimeCrypted = value ^ FBGGEFFJJHB; } } //OBIHDBIFJEJ 0x1C51784  JHBGMOBJMFF 0x1C5179C
	public long MJDMEKMGFJA_IntimacyTouchSaveTime { get { return CNLNBAFAKJB_IntimacyTouchSaveTimeCrypted ^ FBGGEFFJJHB; } set { DCIDLBGNPOC_IntimacyTouchSaveTimeCheck = value; CNLNBAFAKJB_IntimacyTouchSaveTimeCrypted = value ^ FBGGEFFJJHB; } } //NOKLKJAIPNH 0x1C517B8  JBBNKHICLIE 0x1C517D0
	public int ANNIPKMMIAC_IntimacyPresentSaveDate { get { return DPOFEICCHFG_IntimacyPresentSaveDateCrypted ^ FBGGEFFJJHB; } set { LIGPENECNLA_IntimacyPresentSaveDateCheck = value; DPOFEICCHFG_IntimacyPresentSaveDateCrypted = value ^ FBGGEFFJJHB; } }  //BMDNGGCBHEJ 0x1C517EC MFIDNMFGJNM 0x1C517FC
	public int CPAGIICKKNN_EvBtlClsu { get { return CHBFLALKKON_EvBtlClsuCrypted ^ FBGGEFFJJHB; } set { if (value < 2) value = 1; NNADNBDMJEC_EvBtlClsuCheck = value; CHBFLALKKON_EvBtlClsuCrypted = value ^ FBGGEFFJJHB; } } //ABHCOAHNCKE 0x1C51810 BCDHGJNIDIN 0x1C51820
	public long AGJINOICNJP_GachaLastShowTime { get { return LNOAFOOIJEF_GachaLastShowTimeCrypted ^ FBGGEFFJJHB; } set { MGMHKPBGDDP_GachaLastShowTimeCheck = value; LNOAFOOIJEF_GachaLastShowTimeCrypted = value ^ FBGGEFFJJHB; } } //GDBEDJCAGCI 0x1C5183C JFHIKLPDMFM 0x1C51854
	public long MOBHLLDIMMN_EpisodeLastShowTime { get { return AKHADFNHCBJ_EpisodeLastShowTimeCrypted ^ FBGGEFFJJHB; } set { JHLMNABIFLC_EpisodeLastShowTimeCheck = value; AKHADFNHCBJ_EpisodeLastShowTimeCrypted = value ^ FBGGEFFJJHB; } } //KAFHGBHOHBM 0x1C51870 DKHPNKJALPP 0x1C51888
	public long FMBNOBGLMKB_RichbannerLastShowTime { get { return ELILELKGALC_RichbannerLastShowTimeCrypted ^ FBGGEFFJJHB; } set { PAMGCEIDHEM_RichbannerLastShowTimeCheck = value; ELILELKGALC_RichbannerLastShowTimeCrypted = value ^ FBGGEFFJJHB; } } //DKHDOHKNFBA 0x1C518A4 NDKIPIFKHOO 0x1C518BC
	public int LFCCCLPFJMB_LastFm { get { return HKHJMINFNPM_LastFmCrypted ^ FBGGEFFJJHB; } set { LFBBBAMEAHA_LastFmCheck = value; HKHJMINFNPM_LastFmCrypted = value ^ FBGGEFFJJHB; } } //IPHBDPOBGNL 0x1C518D8 NBIPEOLNKAD 0x1C518E8
	public int KMIJDPFIFII_LastDf { get { return BEHGDBOFFDD_LastDfCrypted ^ FBGGEFFJJHB; } set { JPANEGCAJJM_LastDfCheck = value; BEHGDBOFFDD_LastDfCrypted = value ^ FBGGEFFJJHB; } } //JAODPPLJLDM 0x1C518FC LKOEGANGJMH 0x1C5190C
	public int HCIFHBIHHKK_ClSt { get { return LNEAGENPAGD_ClStCrypted ^ FBGGEFFJJHB; } set { LMFFCFKMNFI_ClStCheck = value; LNEAGENPAGD_ClStCrypted = value ^ FBGGEFFJJHB; } } //OHPLDNFOPDJ 0x1C51920 INBOIJKMCMB 0x1C51930
	public int EAHPKPADCPL_TotalUtaRate { get { return CHMMENJAELL_TotalUtaRateCrypted ^ FBGGEFFJJHB; } set { KMPPPIMMAIO_TotalUtaRateCheck = value; CHMMENJAELL_TotalUtaRateCrypted = value ^ FBGGEFFJJHB; } } //KFCNNEELJJH 0x1C51944 JINLIBGLHJN 0x1C51954
	public int IKLFJPAGHJG_McGauge { get { return CLJCIKDHFGC_McGaugeCrypted ^ FBGGEFFJJHB; } set { BPFJBAGFOCJ_McGaugeCheck = value; CLJCIKDHFGC_McGaugeCrypted = value ^ FBGGEFFJJHB; } } //FEGJOIIJDBN 0x1C51968 EMOOENGDHFO 0x1C51978
	public int KBFFLGOBLAF_LsCnt { get { return KJFPHEOKMKF_LsCntCrypted ^ FBGGEFFJJHB; } set { HGKJPCJNIOI_LsCntCheck = value; KJFPHEOKMKF_LsCntCrypted = value ^ FBGGEFFJJHB; } } //PCHKPJPEJON 0x1C5198C DKOKPMBBBGK 0x1C5199C
	public int CBHANJJJDBN_SlsCnt { get { return JKPEIHMEAOL_SlsCntCrypted ^ FBGGEFFJJHB; } set { CFMGODELIJG_SlsCntCheck = value; JKPEIHMEAOL_SlsCntCrypted = value ^ FBGGEFFJJHB; } } //KFMKFGDEFOF 0x1C519B0 LNEMMJHJEDF 0x1C519C0
	public int EMINMIPNAEG_LsDate { get { return LJOGKKMMMIK_LsDateCrypted ^ FBGGEFFJJHB; } set { HEEJIOKPNPE_LsDateCheck = value; LJOGKKMMMIK_LsDateCrypted = value ^ FBGGEFFJJHB; } } //AMIIHOJPFPF 0x1C519D4 PJFFFDFKBAC 0x1C519E4
	public int CHINCCDPPIN_LsGetData { get { return MHJMKFCIIJK_LsGetDataCrypted ^ FBGGEFFJJHB; } set { LKENFBHINJB_LsGetDataCheck = value; MHJMKFCIIJK_LsGetDataCrypted = value ^ FBGGEFFJJHB; } } //JOJBGCGMJIA 0x1C519F8 PEBOKCDFKHK 0x1C51A08
	public int EAFLCGCIOND_RetRewRecGra { get { return BEPHNLLHMNK_RetRewRecGraCrypted ^ FBGGEFFJJHB; } set { MICPOFPGEPJ_RetRewRecGraCheck = value; BEPHNLLHMNK_RetRewRecGraCrypted = value ^ FBGGEFFJJHB; } } //MJODJCEOFHN 0x1C51A1C LNJFNCJENNC 0x1C51A2C
	public int GPHPNEGGGBG_HomeSceneId { get { return MGBNGLLLKEG_HomeSceneIdCrypted ^ FBGGEFFJJHB; } set { HKEILPBFDKO_HomeSceneIdCheck = value; MGBNGLLLKEG_HomeSceneIdCrypted = value ^ FBGGEFFJJHB; } } //DMGODAAOLKE 0x1C51A40 JPAEDAABAGF 0x1C51A50
	public int MDKELFPNCDB_HomeSceneEvolveId { get { return JODNOFABBPB_HomeSceneEvolveIdCrypted ^ FBGGEFFJJHB; } set { JKOKFDJOOJC_HomeSceneEvolveIdCheck = value; JODNOFABBPB_HomeSceneEvolveIdCrypted = value ^ FBGGEFFJJHB; } } //HOMMHLHLCBM 0x1C51A64 EDIMPHBEOJH 0x1C51A74
	public int HLLEEFLLFPD_HomeShowDiva { get { return ECPIHFNFPBI_HomeShowDivaCrypted ^ FBGGEFFJJHB; } set { BOCFHLKBAJH_HomeShowDivaCheck = value; ECPIHFNFPBI_HomeShowDivaCrypted = value ^ FBGGEFFJJHB; } } //BLEODGANNMK 0x1C51A88 IGDEJEBBHKH 0x1C51A98
	public int KFOCBNDNHDJ_HomeBgDark { get { return EMFNMLIDDEB_HomeBgDarkCrypted ^ FBGGEFFJJHB; } set { OOCCCOODFMD_HomeBgDarkCheck = value; EMFNMLIDDEB_HomeBgDarkCrypted = value ^ FBGGEFFJJHB; } } //PBCMDDKADEK 0x1C51AAC DCLNEAGFAEK 0x1C51ABC
	private int NGDOMLLBIJE_PstVer { get { return GDFLEEOFHAE_PstVerCrypted ^ FBGGEFFJJHB; } set { HLDNLILBPNF_PstVerCheck = value; GDFLEEOFHAE_PstVerCrypted = value ^ FBGGEFFJJHB; } } //CGAALEHLLCM 0x1C51AD0 DPCLEADCLKI 0x1C51AE0
	private int HDNPGDLKCIL_DvfVer { get { return HMBADEDLHPE_DvfVerCrypted ^ FBGGEFFJJHB; } set { NFDADDLHKHO_DvfVerCheck = value; HMBADEDLHPE_DvfVerCrypted = value ^ FBGGEFFJJHB; } } //ONLHLBHJCEF 0x1C51B34 BNOCCKGGNKK 0x1C51B44
	private int CKOGMFKAPDB_TrsVer { get { return FEBIENOBKPP_TrsVerCrypted ^ FBGGEFFJJHB; } set { ECAEFPKEADC_TrsVerCheck = value; FEBIENOBKPP_TrsVerCrypted = value ^ FBGGEFFJJHB; } } //CMACLFEJHHN 0x1C51B98 HNFONMCBMDA 0x1C51BA8
	private int CDJDKAMIJDG_DMasVer { get { return KONGEMOMHLN_DMasVerCrypted ^ FBGGEFFJJHB; } set { FMCFFBNMCDH_DMasVerCheck = value; KONGEMOMHLN_DMasVerCrypted = value ^ FBGGEFFJJHB; } } //HEHPGMDBOMP 0x1C51BFC IJBFGLMGKCO 0x1C51C0C
	public int ENIPGFLGJHH_LastStory { get { return KKCFKKJPKFK_LastStoryCrypted ^ FBGGEFFJJHB; } set { PIKKLHHJMHG_LastStoryCheck = value; KKCFKKJPKFK_LastStoryCrypted = value ^ FBGGEFFJJHB; } } //HIHEGDKMEOA 0x1C52004 HNMDBKHACAI 0x1C52014
	public List<EGOLBAPFHHD_Common.GLBBNDKGEOC> MHKJEBNOPIM_Medal { get; private set; } // 0x20C NENNALHAPPP OHFOJCKMBIH FBKIJJANPPH
	public List<EGOLBAPFHHD_Common.KPMNLAHNDAI> BBFIGEOBOMB_SpItem { get; private set; } // 0x210 MGFFFGBBFOO JMKPCDOCGJJ DDCAENFDIOB
	public long NKIGFPJPALK_LastLotTime { get { return LPIGOJLAHPH_LastLotTimeCrypted ^ FBGGEFFJJHB; } set { GEDGKCOBBDC_LastLotTimeCheck = value; LPIGOJLAHPH_LastLotTimeCrypted = value ^ FBGGEFFJJHB; } } //EAHAILKINNI 0x1C52CC8 BJNHIJCOCAK 0x1C52CE0
	public int BKCJPIPJCCM_StaminaLotDone { get { return HIDCMICKMLC_StaminaLotDoneCrypted ^ FBGGEFFJJHB; } set { EPOBDCLKKEL_StaminaLotDoneCheck = value; HIDCMICKMLC_StaminaLotDoneCrypted = value ^ FBGGEFFJJHB; } } //HNMIDOMBBFN 0x1C52D00 DNLAPBJEGOF 0x1C52D10
	public long MNLAJEDKLCI_StamineLotTime { get { return ICJJIHEKJMM_StamineLotTimeCrypted ^ FBGGEFFJJHB; } set { FBLJNJNBGHD_StamineLotTimeCheck = value; ICJJIHEKJMM_StamineLotTimeCrypted = value ^ FBGGEFFJJHB; } } //CFKEMGCCCLB 0x1C52D24 DGEHOEGIGNH 0x1C52D3C
	public long FFJHJGFKMJB_FChkTime { get { return CFOJKIILILI_FChkTimeCrypted ^ FBGGEFFJJHB; } set { AEJAEPMONML_FChkTimeCheck = value; CFOJKIILILI_FChkTimeCrypted = value ^ FBGGEFFJJHB; } } //CKKIIFEGCDO 0x1C52D78 CNCOIELDMIE 0x1C52D90
	private List<EGOLBAPFHHD_Common.PGENIOHDCDI> KIEAKGLEDMK_CosItem { get; set; } // 0x258 JMFEACLHKIK LHLPOEAFLDM FJJBHLNAJAB
	public List<EGOLBAPFHHD_Common.GHOADMJCPFK> MJAIFKFOPPI_ValItem { get; private set; } // 0x268 BFHHEHDPLLC JJOLBGDIIKL OIFFEKGPPKF
	public int ELHKIPIDPIK_HaveDecoPoint { get { return NKDGNNCEFKG_HaveDecoPointCrypted ^ FBGGEFFJJHB; } set { AOBKHNIEOJN_HaveDecoPointCheck = value; NKDGNNCEFKG_HaveDecoPointCrypted = value ^ FBGGEFFJJHB; } } //AHOCGAMDNDI 0x1C53CE0 FJEJKCOKLAP 0x1C53CF0
	public bool PCBHHJHLOLN { get { return GJGGADEPCKF == JHHLBIHEPDJ_True; } set { GJGGADEPCKF = value ? JHHLBIHEPDJ_True : DFMOPCKCCHF_False; } } //IHBNBJMHMGP 0x1C53D18 OPAGBJPOAGH 0x1C53D04
	public bool KOGNMHLAOMB { get { return BGNMKGDHJFI == IMADHFOIHKL_True; } set { BGNMKGDHJFI = value ? IMADHFOIHKL_True : DBCCJBLMKEK_False; } } //JOHPNHFFNLC 0x1C53D44 NJEDPDDPLMG 0x1C53D30
	public bool HCAHHCIGLLH { get { return JCOMMCBJDPK == CHDIBMHLHCN_True; } set { JCOMMCBJDPK = value ? CHDIBMHLHCN_True : BBCALMHCGGF_False; }  } //LFOPOCENJIK 0x1C53D70 NMFEMJMOKMB 0x1C53D5C
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x1C51384 Offset: 0x1C51384 VA: 0x1C51384
	public void ENEMPFLFEHP_AddUc(int OEOIHIIIMCK)
	{
		NFHLDFJIBKI_HaveUc = NFHLDFJIBKI_HaveUc + OEOIHIIIMCK < 99999999 ? NFHLDFJIBKI_HaveUc + OEOIHIIIMCK : 99999999;
	}

	// // RVA: 0x1C513B4 Offset: 0x1C513B4 VA: 0x1C513B4
	// public void LLEGCIMFPGD(int CHIHFGDIBJM) { }

	// // RVA: 0x1C51410 Offset: 0x1C51410 VA: 0x1C51410
	public int ANGGCMBPKKC_AddExp(int OEOIHIIIMCK_Exp, JJOPEDJCCJK_Exp FMPEMFPLPDA_dbExp, PEBFNABDJDI_System GDEKCOOBLMA_dbSystem)
	{
		if(FMPEMFPLPDA_dbExp != null && GDEKCOOBLMA_dbSystem != null)
		{
			CHBDMJBEENG c = GDEKCOOBLMA_dbSystem.NGHKJOEDLIP;
			if(c != null)
			{
				int cplvl = c.PIAMMJNADJH_PlayerMaxLevel;
				int exp = EOHDMCMHBKJ_Exp;
				int expPrev = exp;
				int level = KIECDDFNCAN_Level;
				int levelPrev = level;
				while (OEOIHIIIMCK_Exp > 0)
				{
					if(cplvl <= level)
					{
						exp = 0;
						level = cplvl;
						break;
					}
					int d = FMPEMFPLPDA_dbExp.NDFGMMKGBAA_GetExpForPlayerLevel(level);
					exp = OEOIHIIIMCK_Exp + expPrev;
					if (exp < d)
						break;
					level++;
					exp = 0;
					if ((d - expPrev) > 0)
						OEOIHIIIMCK_Exp -= (d - expPrev);
					expPrev = exp;
				}
				EOHDMCMHBKJ_Exp = exp;
				KIECDDFNCAN_Level = level;
				return level - levelPrev;
			}
		}
		return 0;
	}

	// // RVA: 0x1C51560 Offset: 0x1C51560 VA: 0x1C51560
	public void IGGDICEACIK()
	{
		POCPLFJCHDD_HomeBg.Clear();
		for(int i = 0; i < 100; i++)
		{
			MCOEBJCAMKO data = new MCOEBJCAMKO();
			data.FBGGEFFJJHB = FBGGEFFJJHB;
			data.PPFNGGCBJKC_Id = i + 1;
			data.BEBJKJKBOGH_Date = 0;
			POCPLFJCHDD_HomeBg.Add(data);
		}
	}

	// // RVA: 0x1C51AF4 Offset: 0x1C51AF4 VA: 0x1C51AF4
	// public int JGMBAIMPGBK() { }

	// // RVA: 0x1C51B04 Offset: 0x1C51B04 VA: 0x1C51B04
	// public void HHCMHDKKFNF(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51B18 Offset: 0x1C51B18 VA: 0x1C51B18
	// public bool FCBBIEPBDBA(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51B58 Offset: 0x1C51B58 VA: 0x1C51B58
	// public int CPJHIHMCLMN() { }

	// // RVA: 0x1C51B68 Offset: 0x1C51B68 VA: 0x1C51B68
	// public void HKAMGHBKNBH(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51B7C Offset: 0x1C51B7C VA: 0x1C51B7C
	// public bool CDDLPADLJNG(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51BBC Offset: 0x1C51BBC VA: 0x1C51BBC
	// public int NLAPKFFNEOC() { }

	// // RVA: 0x1C51BCC Offset: 0x1C51BCC VA: 0x1C51BCC
	// public void GCCOOJJHIAM(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51BE0 Offset: 0x1C51BE0 VA: 0x1C51BE0
	// public bool HOGBPAGEJKO(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51C20 Offset: 0x1C51C20 VA: 0x1C51C20
	// public int PBHMDEJPLMJ() { }

	// // RVA: 0x1C51C30 Offset: 0x1C51C30 VA: 0x1C51C30
	// public void JAHBNIMDNHJ(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51C44 Offset: 0x1C51C44 VA: 0x1C51C44
	// public bool GAFDKEENNJO(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51C60 Offset: 0x1C51C60 VA: 0x1C51C60
	// public void GHKOOOHLHDC(LastGameUnlockStatus.TypeBit BJMJKILHLDF) { }

	// // RVA: 0x1C51C80 Offset: 0x1C51C80 VA: 0x1C51C80
	// public bool KJDDGIMIEDO(LastGameUnlockStatus.TypeBit BJMJKILHLDF) { }

	// // RVA: 0x1C51C98 Offset: 0x1C51C98 VA: 0x1C51C98
	// public void OMNKFKFJJJM(LastGameUnlockStatus.TypeBit BJMJKILHLDF) { }

	// // RVA: 0x1C51CB8 Offset: 0x1C51CB8 VA: 0x1C51CB8
	// public void PACHOCGKCDB() { }

	// // RVA: 0x1C51CCC Offset: 0x1C51CCC VA: 0x1C51CCC
	// public void MKIKFKBMIPE(int KINEDIKNCNM, int EEFIEGHMKBN) { }

	// // RVA: 0x1C51CEC Offset: 0x1C51CEC VA: 0x1C51CEC
	// public void LOBOPFFFPGP() { }

	// // RVA: 0x1C51D14 Offset: 0x1C51D14 VA: 0x1C51D14
	// public void EMHMCOBNMLI() { }

	// // RVA: 0x1C51D34 Offset: 0x1C51D34 VA: 0x1C51D34
	// public void CCNGJHIBPMP() { }

	// // RVA: 0x1C51E00 Offset: 0x1C51E00 VA: 0x1C51E00
	// public bool KCIPEJCFJMD() { }

	// // RVA: 0x1C52038 Offset: 0x1C52038 VA: 0x1C52038
	public List<int> LPFFDGNDLKG(bool ANLBEIOFIGB = true, int CPNEKIDCAMF = 2160)
	{
		TodoLogger.Log(0, "TODO");
		return null;
	}

	// // RVA: 0x1C5261C Offset: 0x1C5261C VA: 0x1C5261C
	// private PPNFHHPJOKK.JBBIPIAABOJ FOECFMNNNMP(int PPFNGGCBJKC) { }

	// // RVA: 0x1C5277C Offset: 0x1C5277C VA: 0x1C5277C
	// public bool POOOHJIJLNN(int PPFNGGCBJKC, int HMFFHLPNMPH) { }

	// // RVA: 0x1C528D0 Offset: 0x1C528D0 VA: 0x1C528D0
	// public bool NLOGLGKPMNI(int PPFNGGCBJKC, int HMFFHLPNMPH) { }

	// // RVA: 0x1C52A08 Offset: 0x1C52A08 VA: 0x1C52A08
	// public int JJKEDPHDEDO(int PPFNGGCBJKC) { }

	// // RVA: 0x1C52ACC Offset: 0x1C52ACC VA: 0x1C52ACC
	// public bool LKNGEAKLFPG(int PPFNGGCBJKC, int HMFFHLPNMPH) { }

	// // RVA: 0x1C52BA4 Offset: 0x1C52BA4 VA: 0x1C52BA4
	// public int LCDLKPOLHHJ() { }

	// // RVA: 0x1C52D58 Offset: 0x1C52D58 VA: 0x1C52D58
	// public void AFBCPAGPLNB() { }

	// // RVA: 0x1C52DC0 Offset: 0x1C52DC0 VA: 0x1C52DC0
	// public EGOLBAPFHHD.PGENIOHDCDI EFBKCNNFIPJ(int PPFNGGCBJKC) { }

	// // RVA: 0x1C52E40 Offset: 0x1C52E40 VA: 0x1C52E40
	// public void NIFJAPKCPOK(int HHGMPEEGFMA, int IOCPEOBPBKB) { }

	// // RVA: 0x1C53030 Offset: 0x1C53030 VA: 0x1C53030
	// public EGOLBAPFHHD.PCHECKGDJDK BGDMJGDEKFJ(int HHGMPEEGFMA) { }

	// // RVA: 0x1C53128 Offset: 0x1C53128 VA: 0x1C53128
	// public void NDLADIBEHAM() { }

	// // RVA: 0x1C531A0 Offset: 0x1C531A0 VA: 0x1C531A0
	// public void INJFPFAJGPK(int BHBHMFCMLHN) { }

	// // RVA: 0x1C532E8 Offset: 0x1C532E8 VA: 0x1C532E8
	// public void KFFFMJDEJOP(int OIPCCBHIKIA, bool JKDJCFEBDHC) { }

	// // RVA: 0x1C53358 Offset: 0x1C53358 VA: 0x1C53358
	// public bool KPPMKBEHKLK(int OIPCCBHIKIA) { }

	// // RVA: 0x1C533C8 Offset: 0x1C533C8 VA: 0x1C533C8
	// public void DMNGICGDFAO(int OIPCCBHIKIA, bool JKDJCFEBDHC) { }

	// // RVA: 0x1C53438 Offset: 0x1C53438 VA: 0x1C53438
	// public bool PBKPEGCIPME(int OIPCCBHIKIA) { }

	// // RVA: 0x1C534A8 Offset: 0x1C534A8 VA: 0x1C534A8
	// public void BDMJHCCGIED(int OIPCCBHIKIA, bool JKDJCFEBDHC) { }

	// // RVA: 0x1C53518 Offset: 0x1C53518 VA: 0x1C53518
	// public bool JPIDBKDPFLM(int OIPCCBHIKIA) { }

	// // RVA: 0x1C53588 Offset: 0x1C53588 VA: 0x1C53588
	// public void DDCBGCODHHN(int EHDDADDKMFI, int HPNLNIFICNI, bool JKDJCFEBDHC) { }

	// // RVA: 0x1C5361C Offset: 0x1C5361C VA: 0x1C5361C
	// public bool CGEPJMFFLLJ(int EHDDADDKMFI, int HPNLNIFICNI) { }

	// // RVA: 0x1C536B8 Offset: 0x1C536B8 VA: 0x1C536B8
	// public void CHIBEJJCPGI(bool OAFPGJLCNFM) { }

	// // RVA: 0x1C53714 Offset: 0x1C53714 VA: 0x1C53714
	// public void LIPHECJKIDD(int EHDDADDKMFI, bool JKDJCFEBDHC) { }

	// // RVA: 0x1C5378C Offset: 0x1C5378C VA: 0x1C5378C
	// public bool NHKPKOPAMNB(int EHDDADDKMFI) { }

	// // RVA: 0x1C537FC Offset: 0x1C537FC VA: 0x1C537FC
	// public void CCAMHFBFEBB(bool OAFPGJLCNFM) { }

	// // RVA: 0x1C53858 Offset: 0x1C53858 VA: 0x1C53858
	// public void DOGPMKIKKDA(int KLMIFEKNBLL, int MFCNKPHPJBH, bool JKDJCFEBDHC) { }

	// // RVA: 0x1C539A8 Offset: 0x1C539A8 VA: 0x1C539A8
	public bool KNKGEALPDGF_GetBookmark(int KLMIFEKNBLL, int MFCNKPHPJBH)
	{
		TodoLogger.Log(0, "KNKGEALPDGF");
		return false;
	}

	// // RVA: 0x1C53A8C Offset: 0x1C53A8C VA: 0x1C53A8C
	// public void BAAGCGEGIMK(int MFCNKPHPJBH, string OPFGFINHFCE) { }

	// // RVA: 0x1C53AB8 Offset: 0x1C53AB8 VA: 0x1C53AB8
	// public string NPGGEAJMFCB(int MFCNKPHPJBH) { }

	// // RVA: 0x1C53B48 Offset: 0x1C53B48 VA: 0x1C53B48
	// public bool ADKJDHPEAJH(GPFlagConstant.ID PPFNGGCBJKC) { }

	// // RVA: 0x1C53BE8 Offset: 0x1C53BE8 VA: 0x1C53BE8
	public void BCLKCMDGDLD(GPFlagConstant.ID PPFNGGCBJKC, bool JKDJCFEBDHC)
	{
		UnityEngine.Debug.LogWarning("Not sure ?");
		if(JKDJCFEBDHC)
			CKDPJCLINAB_GpFlg[0] &= 1 << (int)PPFNGGCBJKC;
		else
			CKDPJCLINAB_GpFlg[0] |= ~(1 << (int)PPFNGGCBJKC);
	}

	// // RVA: 0x1C53CC4 Offset: 0x1C53CC4 VA: 0x1C53CC4
	// public void AABHAHFCEMF() { }

	// // RVA: 0x1C53D88 Offset: 0x1C53D88 VA: 0x1C53D88
	public EGOLBAPFHHD_Common()
	{
		KBMDMEEMGLK_GrowItem = new List<EGOLBAPFHHD_Common.OFAPDOKONML>();
		GJODJNIHKKF_EpiItem = new List<EGOLBAPFHHD_Common.AMCANGCIBEG>();
		KFEBOFKAHAJ_EngItem = new List<EGOLBAPFHHD_Common.FKLHGOGJOHH>();
		POCPLFJCHDD_HomeBg = new List<EGOLBAPFHHD_Common.MCOEBJCAMKO>();
		MHKJEBNOPIM_Medal = new List<EGOLBAPFHHD_Common.GLBBNDKGEOC>();
		DHJFHILPKLB_IntimacyPresent = new List<EGOLBAPFHHD_Common.DEEGPPKGGLK>();
		BBFIGEOBOMB_SpItem = new List<EGOLBAPFHHD_Common.KPMNLAHNDAI>();
		KIEAKGLEDMK_CosItem = new List<EGOLBAPFHHD_Common.PGENIOHDCDI>();
		MJAIFKFOPPI_ValItem = new List<EGOLBAPFHHD_Common.GHOADMJCPFK>();
		KKPNGCNBJHO_GachaDraw = new List<EGOLBAPFHHD_Common.PCHECKGDJDK>();
		KMBPACJNEOF();
	}

	// // RVA: 0x1C54140 Offset: 0x1C54140 VA: 0x1C54140 Slot: 4
	public override void KMBPACJNEOF()
	{
		long time = Utility.GetCurrentUnixTime();
		FBGGEFFJJHB = (int)(time ^ 0x24361223);
		FOKNAMPDPFP_StaminaSaveTime = 0;
		MNLAJEDKLCI_StamineLotTime = 0;
		DLBLONNCCCE_MainTeamId = 0;
		BCFPEJODJPP_Stamina = 0;
		NFHLDFJIBKI_HaveUc = 0;
		KIECDDFNCAN_Level = 1;
		PJKDBODIGPG_Cont = 0;
		EOHDMCMHBKJ_Exp = 0;
		BKCJPIPJCCM_StaminaLotDone = 0;
		NKIGFPJPALK_LastLotTime = 0;
		FFJHJGFKMJB_FChkTime = 0;
		GDMNOMIEIMP_RvDate = 0;
		ANOCNJABDJO_IntimacyCntSaveTime = 0;
		FGDNHEABLBN_IntimacyTensionSaveTime = 0;
		NIKCFOALFJC_DivaFirst = 0;
		JOKHEHFGDOP_RvStep = 0;
		ACNNFJJMEEO_StoryEnd = 0;
		GKKDNOFMJJN_NumTicket = 0;
		MEMHJKEONBB_EvGachaTicket = 0;
		MMPPEHPKGLI_AddRegularMusicMVer = 0;
		BGEGFMKGNHN_IntimacyCntVal = 0;
		MJDMEKMGFJA_IntimacyTouchSaveTime = 0;
		AGJINOICNJP_GachaLastShowTime = 0;
		MOBHLLDIMMN_EpisodeLastShowTime = 0;
		ANNIPKMMIAC_IntimacyPresentSaveDate = 0;
		CPAGIICKKNN_EvBtlClsu = 1;
		FMBNOBGLMKB_RichbannerLastShowTime = 0;
		LFCCCLPFJMB_LastFm = 0;
		KMIJDPFIFII_LastDf = 0;
		HCIFHBIHHKK_ClSt = 0;
		ENIPGFLGJHH_LastStory = 0;
		EAHPKPADCPL_TotalUtaRate = 0;
		IKLFJPAGHJG_McGauge = 0;
		KBFFLGOBLAF_LsCnt = 0;
		CBHANJJJDBN_SlsCnt = 0;
		EMINMIPNAEG_LsDate = 0;
		CHINCCDPPIN_LsGetData = 0;
		EAFLCGCIOND_RetRewRecGra = 1;
		GPHPNEGGGBG_HomeSceneId = 0;
		MDKELFPNCDB_HomeSceneEvolveId = 0;
		HLLEEFLLFPD_HomeShowDiva = 1;
		KFOCBNDNHDJ_HomeBgDark = 0;
		NGDOMLLBIJE_PstVer = 0;
		HDNPGDLKCIL_DvfVer = 0;
		CKOGMFKAPDB_TrsVer = 0;
		CDJDKAMIJDG_DMasVer = 0;
		INAECNHELAM_ShowSnsBal = 0;
		JLJJHDGEHLK_RecvSns = 0;


		KBMDMEEMGLK_GrowItem.Clear();
		for(int i = 0; i < 27; i++)
		{
			EGOLBAPFHHD_Common.OFAPDOKONML data = new EGOLBAPFHHD_Common.OFAPDOKONML();
			data.FBGGEFFJJHB = HMJBBNEACOA_LevelCrypted;
			data.PPFNGGCBJKC_Id = i + 1;
			data.BFINGCJHOHI_Cnt = 0;
			KBMDMEEMGLK_GrowItem.Add(data);
		}
		GJODJNIHKKF_EpiItem.Clear();
		for(int i = 0; i < 3; i++)
		{
			EGOLBAPFHHD_Common.AMCANGCIBEG data = new EGOLBAPFHHD_Common.AMCANGCIBEG();
			data.FBGGEFFJJHB = HMJBBNEACOA_LevelCrypted;
			data.PPFNGGCBJKC_Id = i + 1;
			data.BFINGCJHOHI_Cnt = 0;
			GJODJNIHKKF_EpiItem.Add(data);
		}
		KFEBOFKAHAJ_EngItem.Clear();
		for(int i = 0; i < 5; i++)
		{
			EGOLBAPFHHD_Common.FKLHGOGJOHH data = new EGOLBAPFHHD_Common.FKLHGOGJOHH();
			data.FBGGEFFJJHB = HMJBBNEACOA_LevelCrypted;
			data.PPFNGGCBJKC_Id = i + 1;
			data.BFINGCJHOHI_Cnt = 0;
			data.BEBJKJKBOGH_Date = 0;
			KFEBOFKAHAJ_EngItem.Add(data);
		}
		POCPLFJCHDD_HomeBg.Clear();
		for(int i = 0; i < 100; i++)
		{
			EGOLBAPFHHD_Common.MCOEBJCAMKO data = new EGOLBAPFHHD_Common.MCOEBJCAMKO();
			data.FBGGEFFJJHB = HMJBBNEACOA_LevelCrypted;
			data.PPFNGGCBJKC_Id = i + 1;
			data.BEBJKJKBOGH_Date = 0;
			POCPLFJCHDD_HomeBg.Add(data);
		}
		MHKJEBNOPIM_Medal.Clear();
		for(int i = 0; i < 16; i++)
		{
			EGOLBAPFHHD_Common.GLBBNDKGEOC data = new EGOLBAPFHHD_Common.GLBBNDKGEOC();
			data.FBGGEFFJJHB = HMJBBNEACOA_LevelCrypted;
			data.PPFNGGCBJKC_Id = i + 1;
			data.BFINGCJHOHI_Cnt = 0;
			data.BEBJKJKBOGH_Date = 0;
			MHKJEBNOPIM_Medal.Add(data);
		}
		DHJFHILPKLB_IntimacyPresent.Clear();
		for(int i = 0; i < 40; i++)
		{
			EGOLBAPFHHD_Common.DEEGPPKGGLK data = new EGOLBAPFHHD_Common.DEEGPPKGGLK();
			data.FBGGEFFJJHB = HMJBBNEACOA_LevelCrypted;
			data.PPFNGGCBJKC_Id = i + 1;
			data.BFINGCJHOHI_Cnt = 0;
			DHJFHILPKLB_IntimacyPresent.Add(data);
		}
		BBFIGEOBOMB_SpItem.Clear();
		for(int i = 0; i < 16; i++)
		{
			EGOLBAPFHHD_Common.KPMNLAHNDAI data = new EGOLBAPFHHD_Common.KPMNLAHNDAI();
			data.FBGGEFFJJHB = HMJBBNEACOA_LevelCrypted;
			data.PPFNGGCBJKC_Id = i + 1;
			data.BFINGCJHOHI_Cnt = 0;
			BBFIGEOBOMB_SpItem.Add(data);
		}
		KIEAKGLEDMK_CosItem.Clear();
		for(int i = 0; i < 23; i++)
		{
			EGOLBAPFHHD_Common.PGENIOHDCDI data = new EGOLBAPFHHD_Common.PGENIOHDCDI();
			data.FBGGEFFJJHB = HMJBBNEACOA_LevelCrypted;
			data.PPFNGGCBJKC_Id = i + 1;
			data.BFINGCJHOHI_Cnt = 0;
			KIEAKGLEDMK_CosItem.Add(data);
		}
		for(int i = 0; i < 16; i++)
		{
			FNMNMILHIGN_ShowTips[i] = 0;
		}
		for(int i = 0; i < 23; i++)
		{
			BCLKCMDGDLD((GPFlagConstant.ID)i, false);
		}
		KKPNGCNBJHO_GachaDraw.Clear();
		MJAIFKFOPPI_ValItem.Clear();
		for(int i = 0; i < 5; i++)
		{
			EGOLBAPFHHD_Common.GHOADMJCPFK data = new EGOLBAPFHHD_Common.GHOADMJCPFK();
			data.FBGGEFFJJHB = HMJBBNEACOA_LevelCrypted;
			data.PPFNGGCBJKC_Id = i + 1;
			data.BFINGCJHOHI_Cnt = 0;
			MJAIFKFOPPI_ValItem.Add(data);
		}
		ELHKIPIDPIK_HaveDecoPoint = 0;
	}

	// // RVA: 0x1C54D20 Offset: 0x1C54D20 VA: 0x1C54D20 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1C58130 Offset: 0x1C58130 VA: 0x1C58130 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool isInvalid = false;
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata))
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		if(!OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			if(EMBGIDLFKGM)
			{
				isInvalid = true;
				KFKDMBPNLJK_BlockInvalid = true;
				return true;
			}
			return false;
		}
		EDOHBJAPLPF_JsonData data = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
		PCBHHJHLOLN = false;
		KOGNMHLAOMB = false;
		HCAHHCIGLLH = false;
		if(!EMBGIDLFKGM)
		{
			if (!data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
				isInvalid = true;
			else
			{
				if((int)data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != 4)
				{
					isInvalid = true;
					if((int)data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] < 3)
					{
						PCBHHJHLOLN = true;
					}
					if ((int)data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] < 4)
					{
						KOGNMHLAOMB = true;
						HCAHHCIGLLH = true;
					}
				}
			}
		}
		DLBLONNCCCE_MainTeamId = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.DLBLONNCCCE_main_team_id, 0, ref isInvalid);
		BCFPEJODJPP_Stamina = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.LEMIEPGGAME_sta_val, 0, ref isInvalid);
		FOKNAMPDPFP_StaminaSaveTime = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.BHFBDOGBOKL_sta_save_time, 0, ref isInvalid);
		NFHLDFJIBKI_HaveUc = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.NFHLDFJIBKI_have_uc, 0, ref isInvalid);
		NIKCFOALFJC_DivaFirst = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.NIKCFOALFJC_diva_1st, 0, ref isInvalid);
		BKCJPIPJCCM_StaminaLotDone = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.BKCJPIPJCCM_sta_lot_done, 0, ref isInvalid);
		MNLAJEDKLCI_StamineLotTime = DKMPHAPBDLH_ReadLong(data, AFEHLCGHAEE_Strings.MNLAJEDKLCI_sta_lot_time, 0, ref isInvalid);
		FFJHJGFKMJB_FChkTime = DKMPHAPBDLH_ReadLong(data, AFEHLCGHAEE_Strings.FDHHPHPCKOE_f_chktime, 0, ref isInvalid);
		KIECDDFNCAN_Level = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.PIJNJBJMFHL_plv, 1, ref isInvalid);
		if (KIECDDFNCAN_Level < 0)
			KIECDDFNCAN_Level = 1;
		EOHDMCMHBKJ_Exp = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.LNADEEECINK_pexp, 0, ref isInvalid);
		NKIGFPJPALK_LastLotTime = DKMPHAPBDLH_ReadLong(data, AFEHLCGHAEE_Strings.NKIGFPJPALK_last_lot_time, 0, ref isInvalid);
		PJKDBODIGPG_Cont = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.MOHDLLIJELH_cont, 0, ref isInvalid);
		GDMNOMIEIMP_RvDate = DKMPHAPBDLH_ReadLong(data, AFEHLCGHAEE_Strings.PAMBKEPLBCC_rv_date, 0, ref isInvalid);
		JOKHEHFGDOP_RvStep = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.NNAACLEBIGE_rv_step, 0, ref isInvalid);
		INAECNHELAM_ShowSnsBal = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.INAECNHELAM_show_sns_bal, 0, ref isInvalid);
		JLJJHDGEHLK_RecvSns = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.JLJJHDGEHLK_recv_sns, 0, ref isInvalid);
		ACNNFJJMEEO_StoryEnd = CJAENOMGPDA_ReadInt(data, "story_end", 0, ref isInvalid);
		GKKDNOFMJJN_NumTicket = CJAENOMGPDA_ReadInt(data, "mv_ticket", 0, ref isInvalid);
		MMPPEHPKGLI_AddRegularMusicMVer = CJAENOMGPDA_ReadInt(data, "add_regular_music_mver", 0, ref isInvalid);
		MEMHJKEONBB_EvGachaTicket = CJAENOMGPDA_ReadInt(data, "ev_gacha_ticket", 0, ref isInvalid);
		BGEGFMKGNHN_IntimacyCntVal = CJAENOMGPDA_ReadInt(data, "intm_cnt_val", 0, ref isInvalid);
		ANOCNJABDJO_IntimacyCntSaveTime = DKMPHAPBDLH_ReadLong(data, "intm_cnt_save_time", 0, ref isInvalid);
		FGDNHEABLBN_IntimacyTensionSaveTime = DKMPHAPBDLH_ReadLong(data, "intm_tension_save_time", 0, ref isInvalid);
		MJDMEKMGFJA_IntimacyTouchSaveTime = DKMPHAPBDLH_ReadLong(data, "intm_touch_save_time", 0, ref isInvalid);
		ANNIPKMMIAC_IntimacyPresentSaveDate = CJAENOMGPDA_ReadInt(data, "intm_present_save_date", 0, ref isInvalid);
		CPAGIICKKNN_EvBtlClsu = CJAENOMGPDA_ReadInt(data, "ev_btl_clsu", 1, ref isInvalid);
		AGJINOICNJP_GachaLastShowTime = DKMPHAPBDLH_ReadLong(data, "gacha_last_show_time", 0, ref isInvalid);
		MOBHLLDIMMN_EpisodeLastShowTime = DKMPHAPBDLH_ReadLong(data, "episode_last_show_time", 0, ref isInvalid);
		FMBNOBGLMKB_RichbannerLastShowTime = DKMPHAPBDLH_ReadLong(data, "richbanner_last_show_time", 0, ref isInvalid);
		LFCCCLPFJMB_LastFm = CJAENOMGPDA_ReadInt(data, "last_fm", 0, ref isInvalid);
		KMIJDPFIFII_LastDf = CJAENOMGPDA_ReadInt(data, "last_df", 0, ref isInvalid);
		HCIFHBIHHKK_ClSt = CJAENOMGPDA_ReadInt(data, "cl_st", 0, ref isInvalid);
		ENIPGFLGJHH_LastStory = CJAENOMGPDA_ReadInt(data, "last_stry", 0, ref isInvalid);
		EAHPKPADCPL_TotalUtaRate = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.EAHPKPADCPL_total_uta_rate, 0, ref isInvalid);
		IKLFJPAGHJG_McGauge = CJAENOMGPDA_ReadInt(data, "mc_gauge", 0, ref isInvalid);
		KBFFLGOBLAF_LsCnt = CJAENOMGPDA_ReadInt(data, "lscnt", 0, ref isInvalid);
		CBHANJJJDBN_SlsCnt = CJAENOMGPDA_ReadInt(data, "slscnt", 0, ref isInvalid);
		EMINMIPNAEG_LsDate = CJAENOMGPDA_ReadInt(data, "lsdate", 0, ref isInvalid);
		CHINCCDPPIN_LsGetData = CJAENOMGPDA_ReadInt(data, "lsgetdata", 0, ref isInvalid);
		EAFLCGCIOND_RetRewRecGra = CJAENOMGPDA_ReadInt(data, "ret_rew_rec_gra", 1, ref isInvalid);
		GPHPNEGGGBG_HomeSceneId = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.GPHPNEGGGBG_home_scene_id, 0, ref isInvalid);
		MDKELFPNCDB_HomeSceneEvolveId = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.MDKELFPNCDB_home_scene_evolveid, 0, ref isInvalid);
		HLLEEFLLFPD_HomeShowDiva = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.HLLEEFLLFPD_home_show_diva, 1, ref isInvalid);
		KFOCBNDNHDJ_HomeBgDark = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.KFOCBNDNHDJ_home_bg_dark, 0, ref isInvalid);
		NGDOMLLBIJE_PstVer = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.MKBCAPPIKMM_pst_ver, 0, ref isInvalid);
		HDNPGDLKCIL_DvfVer = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.JBLAANIMKKH_dvf_ver, 0, ref isInvalid);
		CKOGMFKAPDB_TrsVer = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.POEPEIKKIEA_trs_ver, 0, ref isInvalid);
		CDJDKAMIJDG_DMasVer = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.EIDAEIIGKLB_dmas_ver, 0, ref isInvalid);
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(FNMNMILHIGN_ShowTips, FGCNMLBACGO_ReadString(data, AFEHLCGHAEE_Strings.CIAGPPFPMCL_show_tips, "", ref isInvalid));
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(IGEFEGIFPID_ShowTipsSub, FGCNMLBACGO_ReadString(data, AFEHLCGHAEE_Strings.DHGEFEAMAPJ_show_tips_sub, "", ref isInvalid));
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(KEIIOKGGEOJ_ShowAnketo, FGCNMLBACGO_ReadString(data, AFEHLCGHAEE_Strings.CALPJOGCDGL_show_anketo, "", ref isInvalid));
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(NOMENBABPBK_ShowUnitLiveAdd, FGCNMLBACGO_ReadString(data, AFEHLCGHAEE_Strings.PINEFBCMNKP_show_unitlive_add, "", ref isInvalid));
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(DJEBJLIHDJH_ShowLine6Add, FGCNMLBACGO_ReadString(data, "show_line6_add", "", ref isInvalid));
		LKLIDCMCCCG_MusicBookmarkName1 = FGCNMLBACGO_ReadString(data, "music_bookmark_name1", PMOJBGHJALI, ref isInvalid);
		CHNPJHGCAOP_MusicBookmarkName2 = FGCNMLBACGO_ReadString(data, "music_bookmark_name2", ILDBPMEIMFP, ref isInvalid);
		JMIHCFPDPFP_MusicBookmarkName3 = FGCNMLBACGO_ReadString(data, "music_bookmark_name3", EIIGCNIGEMI, ref isInvalid);
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(JKFFMINPPNN_MusicBookmark1, FGCNMLBACGO_ReadString(data, "music_bookmark1", "", ref isInvalid));
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(DEOHDPMNFEF_MusicBookmark2, FGCNMLBACGO_ReadString(data, "music_bookmark2", "", ref isInvalid));
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(JNPCHIGAIAF_MusicBookmark3, FGCNMLBACGO_ReadString(data, "music_bookmark3", "", ref isInvalid));
		if(data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item))
		{
			int num = data[AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item].HNBFOAJIIAL_Count;
			if (KBMDMEEMGLK_GrowItem.Count < num)
			{
				num = KBMDMEEMGLK_GrowItem.Count;
				isInvalid = true;
			}
			for(int i = 0; i < num; i++)
			{
				EDOHBJAPLPF_JsonData subData = data[AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item][i];
				OFAPDOKONML info = KBMDMEEMGLK_GrowItem[i];
				info.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
				info.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
			}
		}
		else
		{
			isInvalid = true;
		}
		if(data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.GJODJNIHKKF_epi_item))
		{
			int num = data[AFEHLCGHAEE_Strings.GJODJNIHKKF_epi_item].HNBFOAJIIAL_Count;
			if (GJODJNIHKKF_EpiItem.Count < num)
			{
				num = GJODJNIHKKF_EpiItem.Count;
				isInvalid = true;
			}
			for (int i = 0; i < num; i++)
			{
				EDOHBJAPLPF_JsonData subData = data[AFEHLCGHAEE_Strings.GJODJNIHKKF_epi_item][i];
				AMCANGCIBEG info = GJODJNIHKKF_EpiItem[i];
				info.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
				info.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
			}
		}
		else
		{
			isInvalid = true;
		}
		if (data.BBAJPINMOEP_Contains("eng_item"))
		{
			int num = data["eng_item"].HNBFOAJIIAL_Count;
			if (KFEBOFKAHAJ_EngItem.Count < num)
			{
				num = KFEBOFKAHAJ_EngItem.Count;
				isInvalid = true;
			}
			for (int i = 0; i < num; i++)
			{
				EDOHBJAPLPF_JsonData subData = data["eng_item"][i];
				FKLHGOGJOHH info = KFEBOFKAHAJ_EngItem[i];
				info.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
				info.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
				info.BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
			}
		}
		else
		{
			isInvalid = true;
		}
		if (data.BBAJPINMOEP_Contains("home_bg"))
		{
			int num = data["home_bg"].HNBFOAJIIAL_Count;
			if (POCPLFJCHDD_HomeBg.Count < num)
			{
				num = POCPLFJCHDD_HomeBg.Count;
				isInvalid = true;
			}
			for (int i = 0; i < num; i++)
			{
				EDOHBJAPLPF_JsonData subData = data["home_bg"][i];
				MCOEBJCAMKO info = POCPLFJCHDD_HomeBg[i];
				info.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
				info.BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
			}
		}
		else
		{
			isInvalid = true;
		}
		if (data.BBAJPINMOEP_Contains("medal"))
		{
			int num = data["medal"].HNBFOAJIIAL_Count;
			if (MHKJEBNOPIM_Medal.Count < num)
			{
				num = MHKJEBNOPIM_Medal.Count;
				isInvalid = true;
			}
			for (int i = 0; i < num; i++)
			{
				EDOHBJAPLPF_JsonData subData = data["medal"][i];
				GLBBNDKGEOC info = MHKJEBNOPIM_Medal[i];
				info.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
				info.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
				info.BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
			}
		}
		else
		{
			isInvalid = true;
		}
		if (data.BBAJPINMOEP_Contains("intm_present"))
		{
			int num = data["intm_present"].HNBFOAJIIAL_Count;
			if (DHJFHILPKLB_IntimacyPresent.Count < num)
			{
				num = DHJFHILPKLB_IntimacyPresent.Count;
				isInvalid = true;
			}
			for (int i = 0; i < num; i++)
			{
				EDOHBJAPLPF_JsonData subData = data["intm_present"][i];
				DEEGPPKGGLK info = DHJFHILPKLB_IntimacyPresent[i];
				info.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
				info.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
			}
		}
		else
		{
			isInvalid = true;
		}
		if (data.BBAJPINMOEP_Contains("sp_item"))
		{
			int num = data["sp_item"].HNBFOAJIIAL_Count;
			if (BBFIGEOBOMB_SpItem.Count < num)
			{
				num = BBFIGEOBOMB_SpItem.Count;
				isInvalid = true;
			}
			for (int i = 0; i < num; i++)
			{
				EDOHBJAPLPF_JsonData subData = data["sp_item"][i];
				KPMNLAHNDAI info = BBFIGEOBOMB_SpItem[i];
				info.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
				info.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
			}
		}
		else
		{
			isInvalid = true;
		}
		if (data.BBAJPINMOEP_Contains("gp_flg"))
		{
			int num = data["gp_flg"].HNBFOAJIIAL_Count;
			if (num > 1)
			{
				num = 1;
				isInvalid = true;
			}
			IBCGPBOGOGP_ReadIntArray(data, "gp_flg", 0, num, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
			{
				//0x1C6A1EC
				CKDPJCLINAB_GpFlg[OIPCCBHIKIA] = JBGEEPFKIGG;
			}, ref isInvalid);
		}
		else
		{
			isInvalid = true;
		}
		if (data.BBAJPINMOEP_Contains("cos_item"))
		{
			int num = data["cos_item"].HNBFOAJIIAL_Count;
			if (KIEAKGLEDMK_CosItem.Count < num)
			{
				num = KIEAKGLEDMK_CosItem.Count;
				isInvalid = true;
			}
			for (int i = 0; i < num; i++)
			{
				EDOHBJAPLPF_JsonData subData = data["cos_item"][i];
				PGENIOHDCDI info = KIEAKGLEDMK_CosItem[i];
				info.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
				info.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
			}
		}
		else
		{
			isInvalid = true;
		}
		if (data.BBAJPINMOEP_Contains("gacha_draw"))
		{
			AGKEIFMKLNE(FGCNMLBACGO_ReadString(data, "gacha_draw", "", ref isInvalid));
		}
		else
		{
			isInvalid = true;
		}
		if (data.BBAJPINMOEP_Contains("val_item"))
		{
			int num = data["val_item"].HNBFOAJIIAL_Count;
			if (MJAIFKFOPPI_ValItem.Count < num)
			{
				num = MJAIFKFOPPI_ValItem.Count;
				isInvalid = true;
			}
			for (int i = 0; i < num; i++)
			{
				EDOHBJAPLPF_JsonData subData = data["val_item"][i];
				GHOADMJCPFK info = MJAIFKFOPPI_ValItem[i];
				info.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
				info.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
			}
		}
		else
		{
			isInvalid = true;
		}
		ELHKIPIDPIK_HaveDecoPoint = CJAENOMGPDA_ReadInt(data, "have_deco_point", 0, ref isInvalid);
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0x1C5B460 Offset: 0x1C5B460 VA: 0x1C5B460 Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1C5DAB8 Offset: 0x1C5DAB8 VA: 0x1C5DAB8 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1C6043C Offset: 0x1C6043C VA: 0x1C6043C Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x1C69388 Offset: 0x1C69388 VA: 0x1C69388 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(0, "TODO");
		return null;
	}

	// // RVA: 0x1C60040 Offset: 0x1C60040 VA: 0x1C60040
	// private bool EGONOIKAOPE(List<EGOLBAPFHHD.PCHECKGDJDK> HKICMNAACDA, List<EGOLBAPFHHD.PCHECKGDJDK> BNKHBCBJBKI) { }

	// // RVA: 0x1C5B140 Offset: 0x1C5B140 VA: 0x1C5B140
	private void AGKEIFMKLNE(string JEHFDJPOEFF)
	{
		char[] sep = new char[1] { ':' };
		string[] str = JEHFDJPOEFF.Split(sep);
		KKPNGCNBJHO_GachaDraw.Clear();
		for(int i = 0; i < str.Length; i++)
		{
			char[] sep2 = new char[1] { ',' };
			string[] str2 = str[i].Split(sep2);
			if(str2.Length > 2)
			{
				PCHECKGDJDK data = new PCHECKGDJDK();
				data.PPFNGGCBJKC_Id = Int32.Parse(str2[0]);
				data.HMFFHLPNMPH = Int32.Parse(str2[1]);
				data.JJKGPMFJJNE = Int32.Parse(str2[2]);
				KKPNGCNBJHO_GachaDraw.Add(data);
			}
		}
	}

	// // RVA: 0x1C57E54 Offset: 0x1C57E54 VA: 0x1C57E54
	// private string FOMALPAGKJE(List<EGOLBAPFHHD.PCHECKGDJDK> NNDGIAEFMOG) { }

	// // RVA: 0x1C6A13C Offset: 0x1C6A13C VA: 0x1C6A13C Slot: 9
	// public override bool NFKFOODCJJB() { }
}
