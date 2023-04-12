using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
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
	private List<PCHECKGDJDK> KKPNGCNBJHO_GachaDraw = new List<PCHECKGDJDK>(); // 0x260
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
	public List<OFAPDOKONML> KBMDMEEMGLK_GrowItem { get; private set; } // 0x1D8 HFAPPMPFOGA BDOKMMIIEPK ECDKAGIGFBN
	public List<AMCANGCIBEG> GJODJNIHKKF_EpiItem { get; private set; } // 0x1DC GCEBOGKOJPL AHGCJELKMEN IAJJEALILHI
	public List<FKLHGOGJOHH> KFEBOFKAHAJ_EngItem { get; private set; } // 0x1E0 LDJGFDAGENC KGMMJPIPCHF DKPIHJOMECC
	public List<MCOEBJCAMKO> POCPLFJCHDD_HomeBg { get; private set; } // 0x1E4 MEKDBAGFMIM KCMIGNMDIEI CODNAMHIJHJ
	public int GKKDNOFMJJN_NumTicket { get { return NAIKJMLIMKH_NumTicketCrypted ^ FBGGEFFJJHB; } set { 
		CDONLFHFPCE_NumTicketCheck = value;
		NAIKJMLIMKH_NumTicketCrypted = FBGGEFFJJHB ^ value;
	 } } //DHIKNMLCBBN 0x1C516B0  IPBOHCBCGPA 0x1C516C0 // slive item count
	public int MMPPEHPKGLI_AddRegularMusicMVer { get { return LNHFHAGMAEL_AddRegularMusicMVerCrypted ^ FBGGEFFJJHB; } set { OFDGAHPFPIF_AddRegularMusicMVerCheck = value; LNHFHAGMAEL_AddRegularMusicMVerCrypted = value ^ FBGGEFFJJHB; } } //EPPMGOBBNMK 0x1C516D4  HCKEHADGEBB 0x1C516E4
	public int MEMHJKEONBB_EvGachaTicket { get { return IANFKMGHBCE_EvGachaTicketCrypted ^ FBGGEFFJJHB; } set { JMDEFOPGKPD_EvGachaTicketCheck = value; IANFKMGHBCE_EvGachaTicketCrypted = value ^ FBGGEFFJJHB; } } //JKBGMACMDPK 0x1C516F8  GFKEAKDDHAM 0x1C51708
	public int BGEGFMKGNHN_IntimacyCntVal { get { return IGHKJBCODBP_IntimacyCntValCrypted ^ FBGGEFFJJHB; } set { ADFDMJKMGHH_IntimacyCntValCheck = value; IGHKJBCODBP_IntimacyCntValCrypted = value ^ FBGGEFFJJHB; } } //LBHHIDIHMIE 0x1C5171C NAHEGCNNAFJ 0x1C5172C
	public long ANOCNJABDJO_IntimacyCntSaveTime { get { return NPMEFDAPCJA_IntimacyCntSaveTimeCrypted ^ FBGGEFFJJHB; } set { FJFOJEHNCJE_IntimacyCntSaveTimeCheck = value; NPMEFDAPCJA_IntimacyCntSaveTimeCrypted = value ^ FBGGEFFJJHB; } } //OIIGNPKLMEE 0x1C51740 EOFMHCGNAFF 0x1C51758
	public List<DEEGPPKGGLK> DHJFHILPKLB_IntimacyPresent { get; private set; } // 0x1E8 KOAOIBOJPJH BFLNGPACKNK GNEKEMEOPPB
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
	public List<GLBBNDKGEOC> MHKJEBNOPIM_Medal { get; private set; } // 0x20C NENNALHAPPP OHFOJCKMBIH FBKIJJANPPH
	public List<KPMNLAHNDAI> BBFIGEOBOMB_SpItem { get; private set; } // 0x210 MGFFFGBBFOO JMKPCDOCGJJ DDCAENFDIOB
	public long NKIGFPJPALK_LastLotTime { get { return LPIGOJLAHPH_LastLotTimeCrypted ^ FBGGEFFJJHB; } set { GEDGKCOBBDC_LastLotTimeCheck = value; LPIGOJLAHPH_LastLotTimeCrypted = value ^ FBGGEFFJJHB; } } //EAHAILKINNI 0x1C52CC8 BJNHIJCOCAK 0x1C52CE0
	public int BKCJPIPJCCM_StaminaLotDone { get { return HIDCMICKMLC_StaminaLotDoneCrypted ^ FBGGEFFJJHB; } set { EPOBDCLKKEL_StaminaLotDoneCheck = value; HIDCMICKMLC_StaminaLotDoneCrypted = value ^ FBGGEFFJJHB; } } //HNMIDOMBBFN 0x1C52D00 DNLAPBJEGOF 0x1C52D10
	public long MNLAJEDKLCI_StamineLotTime { get { return ICJJIHEKJMM_StamineLotTimeCrypted ^ FBGGEFFJJHB; } set { FBLJNJNBGHD_StamineLotTimeCheck = value; ICJJIHEKJMM_StamineLotTimeCrypted = value ^ FBGGEFFJJHB; } } //CFKEMGCCCLB 0x1C52D24 DGEHOEGIGNH 0x1C52D3C
	public long FFJHJGFKMJB_FriendCheckTime { get { return CFOJKIILILI_FChkTimeCrypted ^ FBGGEFFJJHB; } set { AEJAEPMONML_FChkTimeCheck = value; CFOJKIILILI_FChkTimeCrypted = value ^ FBGGEFFJJHB; } } //CKKIIFEGCDO 0x1C52D78 CNCOIELDMIE 0x1C52D90
	private List<PGENIOHDCDI> KIEAKGLEDMK_CosItem { get; set; } // 0x258 JMFEACLHKIK LHLPOEAFLDM FJJBHLNAJAB
	public List<GHOADMJCPFK> MJAIFKFOPPI_ValItem { get; private set; } // 0x268 BFHHEHDPLLC JJOLBGDIIKL OIFFEKGPPKF
	public int ELHKIPIDPIK_HaveDecoPoint { get { return NKDGNNCEFKG_HaveDecoPointCrypted ^ FBGGEFFJJHB; } set { AOBKHNIEOJN_HaveDecoPointCheck = value; NKDGNNCEFKG_HaveDecoPointCrypted = value ^ FBGGEFFJJHB; } } //AHOCGAMDNDI 0x1C53CE0 FJEJKCOKLAP 0x1C53CF0
	public bool PCBHHJHLOLN { get { return GJGGADEPCKF == JHHLBIHEPDJ_True; } set { GJGGADEPCKF = value ? JHHLBIHEPDJ_True : DFMOPCKCCHF_False; } } //IHBNBJMHMGP 0x1C53D18 OPAGBJPOAGH 0x1C53D04
	public bool KOGNMHLAOMB { get { return BGNMKGDHJFI == IMADHFOIHKL_True; } set { BGNMKGDHJFI = value ? IMADHFOIHKL_True : DBCCJBLMKEK_False; } } //JOHPNHFFNLC 0x1C53D44 NJEDPDDPLMG 0x1C53D30
	public bool HCAHHCIGLLH { get { return JCOMMCBJDPK == CHDIBMHLHCN_True; } set { JCOMMCBJDPK = value ? CHDIBMHLHCN_True : BBCALMHCGGF_False; }  } //LFOPOCENJIK 0x1C53D70 NMFEMJMOKMB 0x1C53D5C
	public override bool DMICHEJIAJL { get { return true; } } // 0x1C6A13C NFKFOODCJJB

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
	public int JGMBAIMPGBK_GetPstVer()
	{
		return NGDOMLLBIJE_PstVer;
	}

	// // RVA: 0x1C51B04 Offset: 0x1C51B04 VA: 0x1C51B04
	public void HHCMHDKKFNF_SetPstVer(int IJEKNCDIIAE)
	{
		NGDOMLLBIJE_PstVer = IJEKNCDIIAE;
	}

	// // RVA: 0x1C51B18 Offset: 0x1C51B18 VA: 0x1C51B18
	// public bool FCBBIEPBDBA(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51B58 Offset: 0x1C51B58 VA: 0x1C51B58
	public int CPJHIHMCLMN_GetDvfVer()
	{
		return HDNPGDLKCIL_DvfVer;
	}

	// // RVA: 0x1C51B68 Offset: 0x1C51B68 VA: 0x1C51B68
	public void HKAMGHBKNBH_SetDvfVer(int IJEKNCDIIAE)
	{
		HDNPGDLKCIL_DvfVer = IJEKNCDIIAE;
	}

	// // RVA: 0x1C51B7C Offset: 0x1C51B7C VA: 0x1C51B7C
	// public bool CDDLPADLJNG(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51BBC Offset: 0x1C51BBC VA: 0x1C51BBC
	public int NLAPKFFNEOC_GetTrsVer()
	{
		return CKOGMFKAPDB_TrsVer;
	}

	// // RVA: 0x1C51BCC Offset: 0x1C51BCC VA: 0x1C51BCC
	public void GCCOOJJHIAM_SetTrsVer(int IJEKNCDIIAE)
	{
		CKOGMFKAPDB_TrsVer = IJEKNCDIIAE;
	}

	// // RVA: 0x1C51BE0 Offset: 0x1C51BE0 VA: 0x1C51BE0
	// public bool HOGBPAGEJKO(int IJEKNCDIIAE) { }

	// // RVA: 0x1C51C20 Offset: 0x1C51C20 VA: 0x1C51C20
	public int PBHMDEJPLMJ_GetDMasVer()
	{
		return CDJDKAMIJDG_DMasVer;
	}

	// // RVA: 0x1C51C30 Offset: 0x1C51C30 VA: 0x1C51C30
	public void JAHBNIMDNHJ_DMasVer(int IJEKNCDIIAE)
	{
		CDJDKAMIJDG_DMasVer = IJEKNCDIIAE;
	}

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
	public List<int> LPFFDGNDLKG_UpdateMedals(bool ANLBEIOFIGB = true, int CPNEKIDCAMF = 2160)
	{
		List<int> l = new List<int>();
		l.Clear();
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		int t = CPNEKIDCAMF * 3600;
		for(int i = 0; i < MHKJEBNOPIM_Medal.Count; i++)
		{
			GLBBNDKGEOC m = MHKJEBNOPIM_Medal[i];
			if(m.PPFNGGCBJKC_Id == 12 && m.BEBJKJKBOGH_Date == 0 && m.BFINGCJHOHI_Cnt > 0)
			{
				m.BEBJKJKBOGH_Date = Utility.GetTargetUnixTime(2017, 12, 2, 0, 0, 0);
			}
			if(m.BEBJKJKBOGH_Date != 0)
			{
				if(time >= m.BEBJKJKBOGH_Date + t)
				{
					if(ANLBEIOFIGB)
					{
						m.BFINGCJHOHI_Cnt = 0;
						m.BEBJKJKBOGH_Date = 0;
					}
					l.Add(m.PPFNGGCBJKC_Id);
				}
			}
		}
		return l;
	}

	// // RVA: 0x1C5261C Offset: 0x1C5261C VA: 0x1C5261C
	private PPNFHHPJOKK_SpItem.JBBIPIAABOJ FOECFMNNNMP_GetEnabledSpItem(int PPFNGGCBJKC)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB != null)
		{
			PPNFHHPJOKK_SpItem spDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OOEPHOEFBNL_SpItem;
			if(PPFNGGCBJKC > 0 && spDb != null)
			{
				if(PPFNGGCBJKC <= spDb.CDENCMNHNGA.Count)
				{
					if (spDb.CDENCMNHNGA[PPFNGGCBJKC - 1].PLALNIIBLOF_Enabled == 2)
						return spDb.CDENCMNHNGA[PPFNGGCBJKC - 1];
				}
			}
		}
		return null;
	}

	// // RVA: 0x1C5277C Offset: 0x1C5277C VA: 0x1C5277C
	// public bool POOOHJIJLNN(int PPFNGGCBJKC, int HMFFHLPNMPH) { }

	// // RVA: 0x1C528D0 Offset: 0x1C528D0 VA: 0x1C528D0
	// public bool NLOGLGKPMNI(int PPFNGGCBJKC, int HMFFHLPNMPH) { }

	// // RVA: 0x1C52A08 Offset: 0x1C52A08 VA: 0x1C52A08
	public int JJKEDPHDEDO_GetSpItemCount(int PPFNGGCBJKC)
	{
		if (PPFNGGCBJKC <= 0 || PPFNGGCBJKC - 1 > 15 || FOECFMNNNMP_GetEnabledSpItem(PPFNGGCBJKC) == null)
			return 0;
		return BBFIGEOBOMB_SpItem[PPFNGGCBJKC - 1].BFINGCJHOHI_Cnt;
	}

	// // RVA: 0x1C52ACC Offset: 0x1C52ACC VA: 0x1C52ACC
	public bool LKNGEAKLFPG_SetSpItemCount(int PPFNGGCBJKC, int HMFFHLPNMPH)
	{
		if(PPFNGGCBJKC > 0 || PPFNGGCBJKC - 1 < 16 && FOECFMNNNMP_GetEnabledSpItem(PPFNGGCBJKC) != null && HMFFHLPNMPH > -1)
		{
			BBFIGEOBOMB_SpItem[PPFNGGCBJKC - 1].BFINGCJHOHI_Cnt = HMFFHLPNMPH;
		}
		return false;
	}

	// // RVA: 0x1C52BA4 Offset: 0x1C52BA4 VA: 0x1C52BA4
	// public int LCDLKPOLHHJ() { }

	// // RVA: 0x1C52D58 Offset: 0x1C52D58 VA: 0x1C52D58
	// public void AFBCPAGPLNB() { }

	// // RVA: 0x1C52DC0 Offset: 0x1C52DC0 VA: 0x1C52DC0
	public PGENIOHDCDI EFBKCNNFIPJ(int PPFNGGCBJKC)
	{
		return KIEAKGLEDMK_CosItem[PPFNGGCBJKC - 1];
	}

	// // RVA: 0x1C52E40 Offset: 0x1C52E40 VA: 0x1C52E40
	public void NIFJAPKCPOK_SetGachaValue(int HHGMPEEGFMA, int IOCPEOBPBKB)
	{
		PCHECKGDJDK d = KKPNGCNBJHO_GachaDraw.Find((PCHECKGDJDK GHPLINIACBB) =>
		{
			//0x12E8988
			return GHPLINIACBB.PPFNGGCBJKC_Id == HHGMPEEGFMA;
		});
		if (d == null)
		{
			d = new PCHECKGDJDK();
			d.PPFNGGCBJKC_Id = HHGMPEEGFMA;
			KKPNGCNBJHO_GachaDraw.Add(d);
		}

		d.JJKGPMFJJNE = IOCPEOBPBKB;
		d.HMFFHLPNMPH++;
	}

	// // RVA: 0x1C53030 Offset: 0x1C53030 VA: 0x1C53030
	public PCHECKGDJDK BGDMJGDEKFJ_GetGachaDraw(int HHGMPEEGFMA)
	{
		return KKPNGCNBJHO_GachaDraw.Find((PCHECKGDJDK GHPLINIACBB) =>
		{
			//0x12E89E0
			return GHPLINIACBB.PPFNGGCBJKC_Id == HHGMPEEGFMA;
		});
	}

	// // RVA: 0x1C53128 Offset: 0x1C53128 VA: 0x1C53128
	public void NDLADIBEHAM_ClearGachaDrawList()
	{
		KKPNGCNBJHO_GachaDraw.Clear();
	}

	// // RVA: 0x1C531A0 Offset: 0x1C531A0 VA: 0x1C531A0
	public void INJFPFAJGPK_KeepGachaDraw(int BHBHMFCMLHN)
	{
		while(true)
		{
			int idx = KKPNGCNBJHO_GachaDraw.FindIndex((PCHECKGDJDK GHPLINIACBB) =>
			{
				//0x12E8A28
				return GHPLINIACBB.JJKGPMFJJNE != BHBHMFCMLHN;
			});
			if (idx < 0)
				break;
			KKPNGCNBJHO_GachaDraw.RemoveAt(idx);
		}
	}

	// // RVA: 0x1C532E8 Offset: 0x1C532E8 VA: 0x1C532E8
	public void KFFFMJDEJOP_SetShowTipsFlag(int OIPCCBHIKIA, bool JKDJCFEBDHC)
	{
		int idx = OIPCCBHIKIA >> 3;
		if (idx > 15)
			return;
		if (JKDJCFEBDHC)
			FNMNMILHIGN_ShowTips[idx] |= (byte)(1 << (OIPCCBHIKIA & 0x7));
		else
			FNMNMILHIGN_ShowTips[idx] &= (byte)~(1 << (OIPCCBHIKIA & 0x7));
	}

	// // RVA: 0x1C53358 Offset: 0x1C53358 VA: 0x1C53358
	public bool KPPMKBEHKLK_IsShowTipsFlag(int OIPCCBHIKIA)
	{
		int idx = OIPCCBHIKIA >> 3;
		if (idx > 15)
			return false;
		return (FNMNMILHIGN_ShowTips[idx] & (1 << (OIPCCBHIKIA & 0x7))) != 0;
	}

	// // RVA: 0x1C533C8 Offset: 0x1C533C8 VA: 0x1C533C8
	public void DMNGICGDFAO_SetShowTipsSubFlag(int OIPCCBHIKIA, bool JKDJCFEBDHC)
	{
		int idx = OIPCCBHIKIA >> 3;
		if (idx > 15)
			return;
		if (JKDJCFEBDHC)
			IGEFEGIFPID_ShowTipsSub[idx] |= (byte)(1 << (OIPCCBHIKIA & 0x7));
		else
			IGEFEGIFPID_ShowTipsSub[idx] &= (byte)~(1 << (OIPCCBHIKIA & 0x7));
	}

	// // RVA: 0x1C53438 Offset: 0x1C53438 VA: 0x1C53438
	public bool PBKPEGCIPME_IsShowTipsSubFlag(int OIPCCBHIKIA)
	{
		int idx = OIPCCBHIKIA >> 3;
		if (idx > 15)
			return false;
		return (IGEFEGIFPID_ShowTipsSub[idx] & (1 << (OIPCCBHIKIA & 0x7))) != 0;
	}

	// // RVA: 0x1C534A8 Offset: 0x1C534A8 VA: 0x1C534A8
	public void BDMJHCCGIED_SetShowAnketoFlag(int OIPCCBHIKIA, bool JKDJCFEBDHC)
	{
		int idx = OIPCCBHIKIA >> 3;
		if (idx > 7)
			return;
		if (JKDJCFEBDHC)
			KEIIOKGGEOJ_ShowAnketo[idx] |= (byte)(1 << (OIPCCBHIKIA & 0x7));
		else
			KEIIOKGGEOJ_ShowAnketo[idx] &= (byte)~(1 << (OIPCCBHIKIA & 0x7));
	}

	// // RVA: 0x1C53518 Offset: 0x1C53518 VA: 0x1C53518
	public bool JPIDBKDPFLM_IsShowAnketoFlag(int OIPCCBHIKIA)
	{
		int idx = OIPCCBHIKIA >> 3;
		if (idx > 7)
			return false;
		return (KEIIOKGGEOJ_ShowAnketo[idx] & (1 << (OIPCCBHIKIA & 0x7))) != 0;
	}

	// // RVA: 0x1C53588 Offset: 0x1C53588 VA: 0x1C53588
	// public void DDCBGCODHHN(int EHDDADDKMFI, int HPNLNIFICNI, bool JKDJCFEBDHC) { }

	// // RVA: 0x1C5361C Offset: 0x1C5361C VA: 0x1C5361C
	public bool CGEPJMFFLLJ_IsShowUnitLiveAdd(int EHDDADDKMFI, int HPNLNIFICNI)
	{
		if((HPNLNIFICNI & 0xfffffffeU) != 2 || ((EHDDADDKMFI - 1) >> 4) > 124 || (HPNLNIFICNI - 1) * ((EHDDADDKMFI - 1) >> 3) > 499)
		{
			return false;
		}
		return ((1 << ((EHDDADDKMFI - 1) & 7)) & NOMENBABPBK_ShowUnitLiveAdd[HPNLNIFICNI - 1]) != 0;
	}

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
	public bool ADKJDHPEAJH(GPFlagConstant.ID PPFNGGCBJKC)
	{
		TodoLogger.Log(TodoLogger._Todo, "EGOLBAPFHHD_Common.BCLKCMDGDLD Todo with calc office");
		if ((int)PPFNGGCBJKC > 32)
			return false;
		return (CKDPJCLINAB_GpFlg[0] & (1 << ((int)PPFNGGCBJKC))) != 0;
	}

	// // RVA: 0x1C53BE8 Offset: 0x1C53BE8 VA: 0x1C53BE8
	public void BCLKCMDGDLD(GPFlagConstant.ID PPFNGGCBJKC, bool JKDJCFEBDHC)
	{
		TodoLogger.Log(TodoLogger._Todo, "EGOLBAPFHHD_Common.BCLKCMDGDLD Todo with calc office");
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
		FFJHJGFKMJB_FriendCheckTime = 0;
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
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		if(!EMBGIDLFKGM)
		{
			data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 4;
		}
		data[AFEHLCGHAEE_Strings.DLBLONNCCCE_main_team_id] = DLBLONNCCCE_MainTeamId;
		data[AFEHLCGHAEE_Strings.LEMIEPGGAME_sta_val] = BCFPEJODJPP_Stamina;
		data[AFEHLCGHAEE_Strings.BHFBDOGBOKL_sta_save_time] = FOKNAMPDPFP_StaminaSaveTime;
		data[AFEHLCGHAEE_Strings.NFHLDFJIBKI_have_uc] = NFHLDFJIBKI_HaveUc;
		data[AFEHLCGHAEE_Strings.PIJNJBJMFHL_plv] = KIECDDFNCAN_Level;
		data[AFEHLCGHAEE_Strings.LNADEEECINK_pexp] = EOHDMCMHBKJ_Exp;
		data[AFEHLCGHAEE_Strings.NKIGFPJPALK_last_lot_time] = NKIGFPJPALK_LastLotTime;
		data[AFEHLCGHAEE_Strings.MOHDLLIJELH_cont] = PJKDBODIGPG_Cont;
		data[AFEHLCGHAEE_Strings.NIKCFOALFJC_diva_1st] = NIKCFOALFJC_DivaFirst;
		data[AFEHLCGHAEE_Strings.BKCJPIPJCCM_sta_lot_done] = BKCJPIPJCCM_StaminaLotDone;
		data[AFEHLCGHAEE_Strings.MNLAJEDKLCI_sta_lot_time] = MNLAJEDKLCI_StamineLotTime;
		data[AFEHLCGHAEE_Strings.FDHHPHPCKOE_f_chktime] = FFJHJGFKMJB_FriendCheckTime;
		data[AFEHLCGHAEE_Strings.NNAACLEBIGE_rv_step] = JOKHEHFGDOP_RvStep;
		data[AFEHLCGHAEE_Strings.PAMBKEPLBCC_rv_date] = GDMNOMIEIMP_RvDate;
		data[AFEHLCGHAEE_Strings.INAECNHELAM_show_sns_bal] = INAECNHELAM_ShowSnsBal;
		data[AFEHLCGHAEE_Strings.JLJJHDGEHLK_recv_sns] = JLJJHDGEHLK_RecvSns;
		data[AFEHLCGHAEE_Strings.CIAGPPFPMCL_show_tips] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(FNMNMILHIGN_ShowTips);
		data[AFEHLCGHAEE_Strings.DHGEFEAMAPJ_show_tips_sub] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(IGEFEGIFPID_ShowTipsSub);
		data[AFEHLCGHAEE_Strings.CALPJOGCDGL_show_anketo] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(KEIIOKGGEOJ_ShowAnketo);
		data[AFEHLCGHAEE_Strings.PINEFBCMNKP_show_unitlive_add] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(NOMENBABPBK_ShowUnitLiveAdd);
		data["show_line6_add"] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(DJEBJLIHDJH_ShowLine6Add);
		data["music_bookmark_name1"] = LKLIDCMCCCG_MusicBookmarkName1;
		data["music_bookmark_name2"] = CHNPJHGCAOP_MusicBookmarkName2;
		data["music_bookmark_name3"] = JMIHCFPDPFP_MusicBookmarkName3;
		data["music_bookmark1"] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(JKFFMINPPNN_MusicBookmark1);
		data["music_bookmark2"] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(DEOHDPMNFEF_MusicBookmark2);
		data["music_bookmark3"] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(JNPCHIGAIAF_MusicBookmark3);
		data["story_end"] = ACNNFJJMEEO_StoryEnd;
		data[AFEHLCGHAEE_Strings.EAHPKPADCPL_total_uta_rate] = EAHPKPADCPL_TotalUtaRate;
		data["mc_gauge"] = IKLFJPAGHJG_McGauge;
		data["lscnt"] = KBFFLGOBLAF_LsCnt;
		data["slscnt"] = CBHANJJJDBN_SlsCnt;
		data["lsdate"] = EMINMIPNAEG_LsDate;
		data["lsgetdata"] = CHINCCDPPIN_LsGetData;
		data["ret_rew_rec_gra"] = EAFLCGCIOND_RetRewRecGra;
		data[AFEHLCGHAEE_Strings.GPHPNEGGGBG_home_scene_id] = GPHPNEGGGBG_HomeSceneId;
		data[AFEHLCGHAEE_Strings.MDKELFPNCDB_home_scene_evolveid] = MDKELFPNCDB_HomeSceneEvolveId;
		data[AFEHLCGHAEE_Strings.HLLEEFLLFPD_home_show_diva] = HLLEEFLLFPD_HomeShowDiva;
		data[AFEHLCGHAEE_Strings.KFOCBNDNHDJ_home_bg_dark] = KFOCBNDNHDJ_HomeBgDark;
		data[AFEHLCGHAEE_Strings.MKBCAPPIKMM_pst_ver] = NGDOMLLBIJE_PstVer;
		data[AFEHLCGHAEE_Strings.JBLAANIMKKH_dvf_ver] = HDNPGDLKCIL_DvfVer;
		data[AFEHLCGHAEE_Strings.POEPEIKKIEA_trs_ver] = CKOGMFKAPDB_TrsVer;
		data[AFEHLCGHAEE_Strings.EIDAEIIGKLB_dmas_ver] = CDJDKAMIJDG_DMasVer;
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < KBMDMEEMGLK_GrowItem.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = KBMDMEEMGLK_GrowItem[i].PPFNGGCBJKC_Id;
				data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = KBMDMEEMGLK_GrowItem[i].BFINGCJHOHI_Cnt;
				data2.Add(data3);
			}
			data[AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < GJODJNIHKKF_EpiItem.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = GJODJNIHKKF_EpiItem[i].PPFNGGCBJKC_Id;
				data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = GJODJNIHKKF_EpiItem[i].BFINGCJHOHI_Cnt;
				data2.Add(data3);
			}
			data[AFEHLCGHAEE_Strings.GJODJNIHKKF_epi_item] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < KFEBOFKAHAJ_EngItem.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = KFEBOFKAHAJ_EngItem[i].PPFNGGCBJKC_Id;
				data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = KFEBOFKAHAJ_EngItem[i].BFINGCJHOHI_Cnt;
				data3[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = KFEBOFKAHAJ_EngItem[i].BEBJKJKBOGH_Date;
				data2.Add(data3);
			}
			data["eng_item"] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < MHKJEBNOPIM_Medal.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = MHKJEBNOPIM_Medal[i].PPFNGGCBJKC_Id;
				data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = MHKJEBNOPIM_Medal[i].BFINGCJHOHI_Cnt;
				data3[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = MHKJEBNOPIM_Medal[i].BEBJKJKBOGH_Date;
				data2.Add(data3);
			}
			data["medal"] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < DHJFHILPKLB_IntimacyPresent.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = DHJFHILPKLB_IntimacyPresent[i].PPFNGGCBJKC_Id;
				data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = DHJFHILPKLB_IntimacyPresent[i].BFINGCJHOHI_Cnt;
				data2.Add(data3);
			}
			data["intm_present"] = data2;
		}
		data["intm_cnt_val"] = BGEGFMKGNHN_IntimacyCntVal;
		data["intm_cnt_save_time"] = ANOCNJABDJO_IntimacyCntSaveTime;
		data["intm_tension_save_time"] = FGDNHEABLBN_IntimacyTensionSaveTime;
		data["intm_touch_save_time"] = MJDMEKMGFJA_IntimacyTouchSaveTime;
		data["intm_present_save_date"] = ANNIPKMMIAC_IntimacyPresentSaveDate;
		data["mv_ticket"] = GKKDNOFMJJN_NumTicket;
		data["add_regular_music_mver"] = MMPPEHPKGLI_AddRegularMusicMVer;
		data["ev_gacha_ticket"] = MEMHJKEONBB_EvGachaTicket;
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < BBFIGEOBOMB_SpItem.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = BBFIGEOBOMB_SpItem[i].PPFNGGCBJKC_Id;
				data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = BBFIGEOBOMB_SpItem[i].BFINGCJHOHI_Cnt;
				data2.Add(data3);
			}
			data["sp_item"] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data2.Add(CKDPJCLINAB_GpFlg[0]);
			data["gp_flg"] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < KIEAKGLEDMK_CosItem.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = KIEAKGLEDMK_CosItem[i].PPFNGGCBJKC_Id;
				data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = KIEAKGLEDMK_CosItem[i].BFINGCJHOHI_Cnt;
				data2.Add(data3);
			}
			data["cos_item"] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < MJAIFKFOPPI_ValItem.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = MJAIFKFOPPI_ValItem[i].PPFNGGCBJKC_Id;
				data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = MJAIFKFOPPI_ValItem[i].BFINGCJHOHI_Cnt;
				data2.Add(data3);
			}
			data["val_item"] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < POCPLFJCHDD_HomeBg.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = POCPLFJCHDD_HomeBg[i].PPFNGGCBJKC_Id;
				data3[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = POCPLFJCHDD_HomeBg[i].BEBJKJKBOGH_Date;
				data2.Add(data3);
			}
			data["home_bg"] = data2;
		}
		data["have_deco_point"] = ELHKIPIDPIK_HaveDecoPoint;
		if(!EMBGIDLFKGM)
		{
			;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
		data["ev_btl_clsu"] = CPAGIICKKNN_EvBtlClsu;
		data["gacha_last_show_time"] = AGJINOICNJP_GachaLastShowTime;
		data["episode_last_show_time"] = MOBHLLDIMMN_EpisodeLastShowTime;
		data["richbanner_last_show_time"] = FMBNOBGLMKB_RichbannerLastShowTime;
		data["last_fm"] = LFCCCLPFJMB_LastFm;
		data["last_df"] = KMIJDPFIFII_LastDf;
		data["cl_st"] = HCIFHBIHHKK_ClSt;
		data["last_stry"] = ENIPGFLGJHH_LastStory;
		data["gacha_draw"] = FOMALPAGKJE(KKPNGCNBJHO_GachaDraw);
	}

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
		FFJHJGFKMJB_FriendCheckTime = DKMPHAPBDLH_ReadLong(data, AFEHLCGHAEE_Strings.FDHHPHPCKOE_f_chktime, 0, ref isInvalid);
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
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		EGOLBAPFHHD_Common c = GPBJHKLFCEP as EGOLBAPFHHD_Common;
		DLBLONNCCCE_MainTeamId = c.DLBLONNCCCE_MainTeamId;
		FOKNAMPDPFP_StaminaSaveTime = c.FOKNAMPDPFP_StaminaSaveTime;
		BCFPEJODJPP_Stamina = c.BCFPEJODJPP_Stamina;
		NFHLDFJIBKI_HaveUc = c.NFHLDFJIBKI_HaveUc;
		KIECDDFNCAN_Level = c.KIECDDFNCAN_Level;
		EOHDMCMHBKJ_Exp = c.EOHDMCMHBKJ_Exp;
		NKIGFPJPALK_LastLotTime = c.NKIGFPJPALK_LastLotTime;
		FFJHJGFKMJB_FriendCheckTime = c.FFJHJGFKMJB_FriendCheckTime;
		PJKDBODIGPG_Cont = c.PJKDBODIGPG_Cont;
		BKCJPIPJCCM_StaminaLotDone = c.BKCJPIPJCCM_StaminaLotDone;
		MNLAJEDKLCI_StamineLotTime = c.MNLAJEDKLCI_StamineLotTime;
		JOKHEHFGDOP_RvStep = c.JOKHEHFGDOP_RvStep;
		INAECNHELAM_ShowSnsBal = c.INAECNHELAM_ShowSnsBal;
		JLJJHDGEHLK_RecvSns = c.JLJJHDGEHLK_RecvSns;
		NIKCFOALFJC_DivaFirst = c.NIKCFOALFJC_DivaFirst;
		ACNNFJJMEEO_StoryEnd = c.ACNNFJJMEEO_StoryEnd;
		GKKDNOFMJJN_NumTicket = c.GKKDNOFMJJN_NumTicket;
		MMPPEHPKGLI_AddRegularMusicMVer = c.MMPPEHPKGLI_AddRegularMusicMVer;
		MEMHJKEONBB_EvGachaTicket = c.MEMHJKEONBB_EvGachaTicket;
		ANOCNJABDJO_IntimacyCntSaveTime = c.ANOCNJABDJO_IntimacyCntSaveTime;
		BGEGFMKGNHN_IntimacyCntVal = c.BGEGFMKGNHN_IntimacyCntVal;
		FGDNHEABLBN_IntimacyTensionSaveTime = c.FGDNHEABLBN_IntimacyTensionSaveTime;
		MJDMEKMGFJA_IntimacyTouchSaveTime = c.MJDMEKMGFJA_IntimacyTouchSaveTime;
		ANNIPKMMIAC_IntimacyPresentSaveDate = c.ANNIPKMMIAC_IntimacyPresentSaveDate;
		CPAGIICKKNN_EvBtlClsu = c.CPAGIICKKNN_EvBtlClsu;
		AGJINOICNJP_GachaLastShowTime = c.AGJINOICNJP_GachaLastShowTime;
		MOBHLLDIMMN_EpisodeLastShowTime = c.MOBHLLDIMMN_EpisodeLastShowTime;
		FMBNOBGLMKB_RichbannerLastShowTime = c.FMBNOBGLMKB_RichbannerLastShowTime;
		LFCCCLPFJMB_LastFm = c.LFCCCLPFJMB_LastFm;
		KMIJDPFIFII_LastDf = c.KMIJDPFIFII_LastDf;
		HCIFHBIHHKK_ClSt = c.HCIFHBIHHKK_ClSt;
		ENIPGFLGJHH_LastStory = c.ENIPGFLGJHH_LastStory;
		EAHPKPADCPL_TotalUtaRate = c.EAHPKPADCPL_TotalUtaRate;
		IKLFJPAGHJG_McGauge = c.IKLFJPAGHJG_McGauge;
		KBFFLGOBLAF_LsCnt = c.KBFFLGOBLAF_LsCnt;
		CBHANJJJDBN_SlsCnt = c.CBHANJJJDBN_SlsCnt;
		EMINMIPNAEG_LsDate = c.EMINMIPNAEG_LsDate;
		CHINCCDPPIN_LsGetData = c.CHINCCDPPIN_LsGetData;
		EAFLCGCIOND_RetRewRecGra = c.EAFLCGCIOND_RetRewRecGra;
		GPHPNEGGGBG_HomeSceneId = c.GPHPNEGGGBG_HomeSceneId;
		MDKELFPNCDB_HomeSceneEvolveId = c.MDKELFPNCDB_HomeSceneEvolveId;
		HLLEEFLLFPD_HomeShowDiva = c.HLLEEFLLFPD_HomeShowDiva;
		KFOCBNDNHDJ_HomeBgDark = c.KFOCBNDNHDJ_HomeBgDark;
		NGDOMLLBIJE_PstVer = c.NGDOMLLBIJE_PstVer;
		HDNPGDLKCIL_DvfVer = c.HDNPGDLKCIL_DvfVer;
		CKOGMFKAPDB_TrsVer = c.CKOGMFKAPDB_TrsVer;
		CDJDKAMIJDG_DMasVer = c.CDJDKAMIJDG_DMasVer;
		for(int i = 0; i < FNMNMILHIGN_ShowTips.Length; i++)
		{
			FNMNMILHIGN_ShowTips[i] = c.FNMNMILHIGN_ShowTips[i];
		}
		for(int i = 0; i < IGEFEGIFPID_ShowTipsSub.Length; i++)
		{
			IGEFEGIFPID_ShowTipsSub[i] = c.IGEFEGIFPID_ShowTipsSub[i];
		}
		for(int i = 0; i < KEIIOKGGEOJ_ShowAnketo.Length; i++)
		{
			KEIIOKGGEOJ_ShowAnketo[i] = c.KEIIOKGGEOJ_ShowAnketo[i];
		}
		for(int i = 0; i < NOMENBABPBK_ShowUnitLiveAdd.Length; i++)
		{
			NOMENBABPBK_ShowUnitLiveAdd[i] = c.NOMENBABPBK_ShowUnitLiveAdd[i];
		}
		for(int i = 0; i < DJEBJLIHDJH_ShowLine6Add.Length; i++)
		{
			DJEBJLIHDJH_ShowLine6Add[i] = c.DJEBJLIHDJH_ShowLine6Add[i];
		}
		LKLIDCMCCCG_MusicBookmarkName1 = c.LKLIDCMCCCG_MusicBookmarkName1;
		CHNPJHGCAOP_MusicBookmarkName2 = c.CHNPJHGCAOP_MusicBookmarkName2;
		JMIHCFPDPFP_MusicBookmarkName3 = c.JMIHCFPDPFP_MusicBookmarkName3;
		for(int i = 0; i < JKFFMINPPNN_MusicBookmark1.Length; i++)
		{
			JKFFMINPPNN_MusicBookmark1[i] = c.JKFFMINPPNN_MusicBookmark1[i];
		}
		for(int i = 0; i < DEOHDPMNFEF_MusicBookmark2.Length; i++)
		{
			DEOHDPMNFEF_MusicBookmark2[i] = c.DEOHDPMNFEF_MusicBookmark2[i];
		}
		for(int i = 0; i < JNPCHIGAIAF_MusicBookmark3.Length; i++)
		{
			JNPCHIGAIAF_MusicBookmark3[i] = c.JNPCHIGAIAF_MusicBookmark3[i];
		}
		for(int i = 0; i < KBMDMEEMGLK_GrowItem.Count; i++)
		{
			KBMDMEEMGLK_GrowItem[i].PPFNGGCBJKC_Id = c.KBMDMEEMGLK_GrowItem[i].PPFNGGCBJKC_Id;
			KBMDMEEMGLK_GrowItem[i].BFINGCJHOHI_Cnt = c.KBMDMEEMGLK_GrowItem[i].BFINGCJHOHI_Cnt;
		}
		for(int i = 0; i < GJODJNIHKKF_EpiItem.Count; i++)
		{
			GJODJNIHKKF_EpiItem[i].PPFNGGCBJKC_Id = c.GJODJNIHKKF_EpiItem[i].PPFNGGCBJKC_Id;
			GJODJNIHKKF_EpiItem[i].BFINGCJHOHI_Cnt = c.GJODJNIHKKF_EpiItem[i].BFINGCJHOHI_Cnt;
		}
		for(int i = 0; i < KFEBOFKAHAJ_EngItem.Count; i++)
		{
			KFEBOFKAHAJ_EngItem[i].PPFNGGCBJKC_Id = c.KFEBOFKAHAJ_EngItem[i].PPFNGGCBJKC_Id;
			KFEBOFKAHAJ_EngItem[i].BFINGCJHOHI_Cnt = c.KFEBOFKAHAJ_EngItem[i].BFINGCJHOHI_Cnt;
			KFEBOFKAHAJ_EngItem[i].BEBJKJKBOGH_Date = c.KFEBOFKAHAJ_EngItem[i].BEBJKJKBOGH_Date;
		}
		for(int i = 0; i < POCPLFJCHDD_HomeBg.Count; i++)
		{
			POCPLFJCHDD_HomeBg[i].PPFNGGCBJKC_Id = c.POCPLFJCHDD_HomeBg[i].PPFNGGCBJKC_Id;
			POCPLFJCHDD_HomeBg[i].BEBJKJKBOGH_Date = c.POCPLFJCHDD_HomeBg[i].BEBJKJKBOGH_Date;
		}
		for(int i = 0; i < MHKJEBNOPIM_Medal.Count; i++)
		{
			MHKJEBNOPIM_Medal[i].PPFNGGCBJKC_Id = c.MHKJEBNOPIM_Medal[i].PPFNGGCBJKC_Id;
			MHKJEBNOPIM_Medal[i].BFINGCJHOHI_Cnt = c.MHKJEBNOPIM_Medal[i].BFINGCJHOHI_Cnt;
			MHKJEBNOPIM_Medal[i].BEBJKJKBOGH_Date = c.MHKJEBNOPIM_Medal[i].BEBJKJKBOGH_Date;
		}
		for(int i = 0; i < DHJFHILPKLB_IntimacyPresent.Count; i++)
		{
			DHJFHILPKLB_IntimacyPresent[i].PPFNGGCBJKC_Id = c.DHJFHILPKLB_IntimacyPresent[i].PPFNGGCBJKC_Id;
			DHJFHILPKLB_IntimacyPresent[i].BFINGCJHOHI_Cnt = c.DHJFHILPKLB_IntimacyPresent[i].BFINGCJHOHI_Cnt;
		}
		for(int i = 0; i < BBFIGEOBOMB_SpItem.Count; i++)
		{
			BBFIGEOBOMB_SpItem[i].PPFNGGCBJKC_Id = c.BBFIGEOBOMB_SpItem[i].PPFNGGCBJKC_Id;
			BBFIGEOBOMB_SpItem[i].BFINGCJHOHI_Cnt = c.BBFIGEOBOMB_SpItem[i].BFINGCJHOHI_Cnt;
		}
		CKDPJCLINAB_GpFlg[0] = c.CKDPJCLINAB_GpFlg[0];
		for(int i = 0; i < KIEAKGLEDMK_CosItem.Count; i++)
		{
			KIEAKGLEDMK_CosItem[i].PPFNGGCBJKC_Id = c.KIEAKGLEDMK_CosItem[i].PPFNGGCBJKC_Id;
			KIEAKGLEDMK_CosItem[i].BFINGCJHOHI_Cnt = c.KIEAKGLEDMK_CosItem[i].BFINGCJHOHI_Cnt;
		}
		int cnt = 0;
		for(; cnt < KKPNGCNBJHO_GachaDraw.Count && cnt < c.KKPNGCNBJHO_GachaDraw.Count; cnt++)
		{
			KKPNGCNBJHO_GachaDraw[cnt].PPFNGGCBJKC_Id = c.KKPNGCNBJHO_GachaDraw[cnt].PPFNGGCBJKC_Id;
			KKPNGCNBJHO_GachaDraw[cnt].HMFFHLPNMPH = c.KKPNGCNBJHO_GachaDraw[cnt].HMFFHLPNMPH;
			KKPNGCNBJHO_GachaDraw[cnt].JJKGPMFJJNE = c.KKPNGCNBJHO_GachaDraw[cnt].JJKGPMFJJNE;
		}
		for(; cnt < c.KKPNGCNBJHO_GachaDraw.Count; cnt++)
		{
			PCHECKGDJDK data = new PCHECKGDJDK();
			data.PPFNGGCBJKC_Id = c.KKPNGCNBJHO_GachaDraw[cnt].PPFNGGCBJKC_Id;
			data.HMFFHLPNMPH = c.KKPNGCNBJHO_GachaDraw[cnt].HMFFHLPNMPH;
			data.JJKGPMFJJNE = c.KKPNGCNBJHO_GachaDraw[cnt].JJKGPMFJJNE;
			KKPNGCNBJHO_GachaDraw.Add(data);
		}
		int val = Mathf.Abs(KKPNGCNBJHO_GachaDraw.Count - c.KKPNGCNBJHO_GachaDraw.Count);
		if(val > 0)
		{
			KKPNGCNBJHO_GachaDraw.RemoveRange(KKPNGCNBJHO_GachaDraw.Count - val, val);
		}
		for(int i = 0; i < MJAIFKFOPPI_ValItem.Count; i++)
		{
			MJAIFKFOPPI_ValItem[i].PPFNGGCBJKC_Id = c.MJAIFKFOPPI_ValItem[i].PPFNGGCBJKC_Id;
			MJAIFKFOPPI_ValItem[i].BFINGCJHOHI_Cnt = c.MJAIFKFOPPI_ValItem[i].BFINGCJHOHI_Cnt;
		}
		ELHKIPIDPIK_HaveDecoPoint = c.ELHKIPIDPIK_HaveDecoPoint;
	}

	// // RVA: 0x1C5DAB8 Offset: 0x1C5DAB8 VA: 0x1C5DAB8 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		EGOLBAPFHHD_Common other = GPBJHKLFCEP as EGOLBAPFHHD_Common;
		if(DLBLONNCCCE_MainTeamId != other.DLBLONNCCCE_MainTeamId ||
			FOKNAMPDPFP_StaminaSaveTime != other.FOKNAMPDPFP_StaminaSaveTime ||
			NKIGFPJPALK_LastLotTime != other.NKIGFPJPALK_LastLotTime ||
			MNLAJEDKLCI_StamineLotTime != other.MNLAJEDKLCI_StamineLotTime ||
			FFJHJGFKMJB_FriendCheckTime != other.FFJHJGFKMJB_FriendCheckTime ||
			GDMNOMIEIMP_RvDate != other.GDMNOMIEIMP_RvDate ||
			ANOCNJABDJO_IntimacyCntSaveTime != other.ANOCNJABDJO_IntimacyCntSaveTime ||
			FGDNHEABLBN_IntimacyTensionSaveTime != other.FGDNHEABLBN_IntimacyTensionSaveTime ||
			MJDMEKMGFJA_IntimacyTouchSaveTime != other.MJDMEKMGFJA_IntimacyTouchSaveTime ||
			AGJINOICNJP_GachaLastShowTime != other.AGJINOICNJP_GachaLastShowTime ||
			MOBHLLDIMMN_EpisodeLastShowTime != other.MOBHLLDIMMN_EpisodeLastShowTime ||
			FMBNOBGLMKB_RichbannerLastShowTime != other.FMBNOBGLMKB_RichbannerLastShowTime ||
			BCFPEJODJPP_Stamina != other.BCFPEJODJPP_Stamina ||
			NFHLDFJIBKI_HaveUc != other.NFHLDFJIBKI_HaveUc ||
			KIECDDFNCAN_Level != other.KIECDDFNCAN_Level ||
			EOHDMCMHBKJ_Exp != other.EOHDMCMHBKJ_Exp ||
			PJKDBODIGPG_Cont != other.PJKDBODIGPG_Cont ||
			BKCJPIPJCCM_StaminaLotDone != other.BKCJPIPJCCM_StaminaLotDone ||
			JOKHEHFGDOP_RvStep != other.JOKHEHFGDOP_RvStep ||
			INAECNHELAM_ShowSnsBal != other.INAECNHELAM_ShowSnsBal ||
			JLJJHDGEHLK_RecvSns != other.JLJJHDGEHLK_RecvSns ||
			NIKCFOALFJC_DivaFirst != other.NIKCFOALFJC_DivaFirst ||
			ACNNFJJMEEO_StoryEnd != other.ACNNFJJMEEO_StoryEnd ||
			GKKDNOFMJJN_NumTicket != other.GKKDNOFMJJN_NumTicket ||
			MMPPEHPKGLI_AddRegularMusicMVer != other.MMPPEHPKGLI_AddRegularMusicMVer ||
			MEMHJKEONBB_EvGachaTicket != other.MEMHJKEONBB_EvGachaTicket ||
			BGEGFMKGNHN_IntimacyCntVal != other.BGEGFMKGNHN_IntimacyCntVal ||
			ANNIPKMMIAC_IntimacyPresentSaveDate != other.ANNIPKMMIAC_IntimacyPresentSaveDate ||
			CPAGIICKKNN_EvBtlClsu != other.CPAGIICKKNN_EvBtlClsu ||
			LFCCCLPFJMB_LastFm != other.LFCCCLPFJMB_LastFm ||
			KMIJDPFIFII_LastDf != other.KMIJDPFIFII_LastDf ||
			HCIFHBIHHKK_ClSt != other.HCIFHBIHHKK_ClSt ||
			ENIPGFLGJHH_LastStory != other.ENIPGFLGJHH_LastStory ||
			ELHKIPIDPIK_HaveDecoPoint != other.ELHKIPIDPIK_HaveDecoPoint ||
			EAHPKPADCPL_TotalUtaRate != other.EAHPKPADCPL_TotalUtaRate ||
			IKLFJPAGHJG_McGauge != other.IKLFJPAGHJG_McGauge ||
			KBFFLGOBLAF_LsCnt != other.KBFFLGOBLAF_LsCnt ||
			CBHANJJJDBN_SlsCnt != other.CBHANJJJDBN_SlsCnt ||
			EMINMIPNAEG_LsDate != other.EMINMIPNAEG_LsDate ||
			CHINCCDPPIN_LsGetData != other.CHINCCDPPIN_LsGetData ||
			EAFLCGCIOND_RetRewRecGra != other.EAFLCGCIOND_RetRewRecGra ||
			GPHPNEGGGBG_HomeSceneId != other.GPHPNEGGGBG_HomeSceneId ||
			MDKELFPNCDB_HomeSceneEvolveId != other.MDKELFPNCDB_HomeSceneEvolveId ||
			HLLEEFLLFPD_HomeShowDiva != other.HLLEEFLLFPD_HomeShowDiva ||
			KFOCBNDNHDJ_HomeBgDark != other.KFOCBNDNHDJ_HomeBgDark ||
			NGDOMLLBIJE_PstVer != other.NGDOMLLBIJE_PstVer ||
			HDNPGDLKCIL_DvfVer != other.HDNPGDLKCIL_DvfVer ||
			CKOGMFKAPDB_TrsVer != other.CKOGMFKAPDB_TrsVer ||
			CDJDKAMIJDG_DMasVer != other.CDJDKAMIJDG_DMasVer)
			return false;
		for(int i = 0; i < KBMDMEEMGLK_GrowItem.Count; i++)
		{
			if(KBMDMEEMGLK_GrowItem[i].PPFNGGCBJKC_Id != other.KBMDMEEMGLK_GrowItem[i].PPFNGGCBJKC_Id ||
				KBMDMEEMGLK_GrowItem[i].BFINGCJHOHI_Cnt != other.KBMDMEEMGLK_GrowItem[i].BFINGCJHOHI_Cnt)
				return false;
		}
		for(int i = 0; i < GJODJNIHKKF_EpiItem.Count; i++)
		{
			if(GJODJNIHKKF_EpiItem[i].PPFNGGCBJKC_Id != other.GJODJNIHKKF_EpiItem[i].PPFNGGCBJKC_Id ||
				GJODJNIHKKF_EpiItem[i].BFINGCJHOHI_Cnt != other.GJODJNIHKKF_EpiItem[i].BFINGCJHOHI_Cnt)
				return false;
		}
		for(int i = 0; i < KFEBOFKAHAJ_EngItem.Count; i++)
		{
			if(KFEBOFKAHAJ_EngItem[i].PPFNGGCBJKC_Id != other.KFEBOFKAHAJ_EngItem[i].PPFNGGCBJKC_Id ||
				KFEBOFKAHAJ_EngItem[i].BFINGCJHOHI_Cnt != other.KFEBOFKAHAJ_EngItem[i].BFINGCJHOHI_Cnt ||
				KFEBOFKAHAJ_EngItem[i].BEBJKJKBOGH_Date != other.KFEBOFKAHAJ_EngItem[i].BEBJKJKBOGH_Date)
				return false;
		}
		for(int i = 0; i < POCPLFJCHDD_HomeBg.Count; i++)
		{
			if(POCPLFJCHDD_HomeBg[i].PPFNGGCBJKC_Id != other.POCPLFJCHDD_HomeBg[i].PPFNGGCBJKC_Id ||
				POCPLFJCHDD_HomeBg[i].BEBJKJKBOGH_Date != other.POCPLFJCHDD_HomeBg[i].BEBJKJKBOGH_Date)
				return false;
		}
		for(int i = 0; i < MHKJEBNOPIM_Medal.Count; i++)
		{
			if(MHKJEBNOPIM_Medal[i].PPFNGGCBJKC_Id != other.MHKJEBNOPIM_Medal[i].PPFNGGCBJKC_Id ||
				MHKJEBNOPIM_Medal[i].BFINGCJHOHI_Cnt != other.MHKJEBNOPIM_Medal[i].BFINGCJHOHI_Cnt ||
				MHKJEBNOPIM_Medal[i].BEBJKJKBOGH_Date != other.MHKJEBNOPIM_Medal[i].BEBJKJKBOGH_Date)
				return false;
		}
		for(int i = 0; i < DHJFHILPKLB_IntimacyPresent.Count; i++)
		{
			if(DHJFHILPKLB_IntimacyPresent[i].PPFNGGCBJKC_Id != other.DHJFHILPKLB_IntimacyPresent[i].PPFNGGCBJKC_Id ||
				DHJFHILPKLB_IntimacyPresent[i].BFINGCJHOHI_Cnt != other.DHJFHILPKLB_IntimacyPresent[i].BFINGCJHOHI_Cnt)
				return false;
		}
		for(int i = 0; i < BBFIGEOBOMB_SpItem.Count; i++)
		{
			if(BBFIGEOBOMB_SpItem[i].PPFNGGCBJKC_Id != other.BBFIGEOBOMB_SpItem[i].PPFNGGCBJKC_Id ||
				BBFIGEOBOMB_SpItem[i].BFINGCJHOHI_Cnt != other.BBFIGEOBOMB_SpItem[i].BFINGCJHOHI_Cnt)
				return false;
		}
		if(CKDPJCLINAB_GpFlg[0] != other.CKDPJCLINAB_GpFlg[0])
			return false;
		for(int i = 0; i < KIEAKGLEDMK_CosItem.Count; i++)
		{
			if(KIEAKGLEDMK_CosItem[i].PPFNGGCBJKC_Id != other.KIEAKGLEDMK_CosItem[i].PPFNGGCBJKC_Id ||
				KIEAKGLEDMK_CosItem[i].BFINGCJHOHI_Cnt != other.KIEAKGLEDMK_CosItem[i].BFINGCJHOHI_Cnt)
				return false;
		}
		for(int i = 0; i < FNMNMILHIGN_ShowTips.Length; i++)
		{
			if(FNMNMILHIGN_ShowTips[i] != other.FNMNMILHIGN_ShowTips[i])
				return false;
		}
		for(int i = 0; i < IGEFEGIFPID_ShowTipsSub.Length; i++)
		{
			if(IGEFEGIFPID_ShowTipsSub[i] != other.IGEFEGIFPID_ShowTipsSub[i])
				return false;
		}
		for(int i = 0; i < KEIIOKGGEOJ_ShowAnketo.Length; i++)
		{
			if(KEIIOKGGEOJ_ShowAnketo[i] != other.KEIIOKGGEOJ_ShowAnketo[i])
				return false;
		}
		for(int i = 0; i < NOMENBABPBK_ShowUnitLiveAdd.Length; i++)
		{
			if(NOMENBABPBK_ShowUnitLiveAdd[i] != other.NOMENBABPBK_ShowUnitLiveAdd[i])
				return false;
		}
		for(int i = 0; i < DJEBJLIHDJH_ShowLine6Add.Length; i++)
		{
			if(DJEBJLIHDJH_ShowLine6Add[i] != other.DJEBJLIHDJH_ShowLine6Add[i])
				return false;
		}
		if(LKLIDCMCCCG_MusicBookmarkName1 != other.LKLIDCMCCCG_MusicBookmarkName1 ||
			CHNPJHGCAOP_MusicBookmarkName2 != other.CHNPJHGCAOP_MusicBookmarkName2 ||
			JMIHCFPDPFP_MusicBookmarkName3 != other.JMIHCFPDPFP_MusicBookmarkName3)
			return false;
		for(int i = 0; i < JKFFMINPPNN_MusicBookmark1.Length; i++)
		{
			if(JKFFMINPPNN_MusicBookmark1[i] != other.JKFFMINPPNN_MusicBookmark1[i])
				return false;
		}
		for(int i = 0; i < DEOHDPMNFEF_MusicBookmark2.Length; i++)
		{
			if(DEOHDPMNFEF_MusicBookmark2[i] != other.DEOHDPMNFEF_MusicBookmark2[i])
				return false;
		}
		for(int i = 0; i < JNPCHIGAIAF_MusicBookmark3.Length; i++)
		{
			if(JNPCHIGAIAF_MusicBookmark3[i] != other.JNPCHIGAIAF_MusicBookmark3[i])
				return false;
		}
		if(!EGONOIKAOPE(KKPNGCNBJHO_GachaDraw, other.KKPNGCNBJHO_GachaDraw))
			return false;
		for(int i = 0; i < MJAIFKFOPPI_ValItem.Count; i++)
		{
			if(MJAIFKFOPPI_ValItem[i].PPFNGGCBJKC_Id != other.MJAIFKFOPPI_ValItem[i].PPFNGGCBJKC_Id ||
				MJAIFKFOPPI_ValItem[i].BFINGCJHOHI_Cnt != other.MJAIFKFOPPI_ValItem[i].BFINGCJHOHI_Cnt)
				return false;
		}
		return true;
	}

	// // RVA: 0x1C6043C Offset: 0x1C6043C VA: 0x1C6043C Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "AGHKODFKOJI");
	}

	// // RVA: 0x1C69388 Offset: 0x1C69388 VA: 0x1C69388 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}

	// // RVA: 0x1C60040 Offset: 0x1C60040 VA: 0x1C60040
	private bool EGONOIKAOPE(List<PCHECKGDJDK> HKICMNAACDA, List<PCHECKGDJDK> BNKHBCBJBKI)
	{
		if(HKICMNAACDA.Count != BNKHBCBJBKI.Count)
			return false;
		for(int i = 0; i < HKICMNAACDA.Count; i++)
		{
			PCHECKGDJDK d = BNKHBCBJBKI.Find((PCHECKGDJDK GHPLINIACBB) =>
			{
				//0x12E8A88
				return HKICMNAACDA[i].PPFNGGCBJKC_Id == GHPLINIACBB.PPFNGGCBJKC_Id;
			});
			if( d == null)
				return false;
			if(d.PPFNGGCBJKC_Id != HKICMNAACDA[i].PPFNGGCBJKC_Id ||
				d.HMFFHLPNMPH != HKICMNAACDA[i].HMFFHLPNMPH ||
				d.JJKGPMFJJNE != HKICMNAACDA[i].JJKGPMFJJNE)
				return false;
		}
		return true;
	}

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
	private string FOMALPAGKJE(List<PCHECKGDJDK> NNDGIAEFMOG)
	{
		StringBuilder str = new StringBuilder();
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if (i > 0)
				str.Append(":");
			str.AppendFormat("{0},{1},{2}", NNDGIAEFMOG[i].PPFNGGCBJKC_Id, NNDGIAEFMOG[i].HMFFHLPNMPH, NNDGIAEFMOG[i].JJKGPMFJJNE);
		}
		return str.ToString();
	}
}
