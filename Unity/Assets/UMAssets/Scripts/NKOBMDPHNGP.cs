
using System;
using System.Collections.Generic;
using XeApp.Game.Common;

[System.Obsolete("Use NKOBMDPHNGP_EventRaidLobby", true)]
public class NKOBMDPHNGP { }
public class NKOBMDPHNGP_EventRaidLobby : IKDICBBFBMI_EventBase
{
	
	public enum FIPGKDJHKCH_Phase
	{
		HJNNKCMLGFL_0 = 0,
		KJNKFFJBPIH_1_Before = 1,
		ECAAJMPLIPG_2_Now = 2,
		OLCLJKOKJCD_3_End = 3,
	}

	public class ELKMKCNPDFO : IFICNCAHIGI
	{
		public bool HKAIJKGODHC; // 0x4D

		// public int AIBFGKBACCB { get; } 0xC20A28 NAFFGDLBDGJ
		// public int KDMPHHFADMC { get; } 0xC2DF38 PNGFNKNGGHI

		// // RVA: 0xC2DF7C Offset: 0xC2DF7C VA: 0xC2DF7C Slot: 4
		public override bool EDEDFDDIOKO(int PPFNGGCBJKC, long IFNLEKOILPM, bool MLEHCBKPNGK, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "EDEDFDDIOKO");
			return false;
		}
	}

	public enum FLHJEJGJJGE
	{
		GGCIMLDFDOC_0_Chat = 0,
		JAFEBKBFPBB_1_Battle = 1,
		CEMAJAOJBEO_2_Chapter = 2,
		AEFCOHJBLPO = 3,
		JFJDFBIKBGP = 0,
	}

	public class PEDPKDBKGIN
	{
		public int HALIDDHLNEG; // 0x8
		public int ADHMMMEOJMK; // 0xC
		public int AKNELONELJK; // 0x10
		public int MFMPCHIJINJ; // 0x14
		public string GJAOLNLFEBD; // 0x18
		public int EJGDHAENIDC; // 0x1C
		public int JPOIGNNOHJP; // 0x20
		public int PCPODOMOFDH; // 0x24
		public int JNBDLNBKDCO; // 0x28
		public bool GIKLNODJKFK; // 0x2C
		public bool IKICLMGFFPB; // 0x2D
		public bool IGNJCGMLBDA; // 0x2E
		public bool INLLJNOMNGF; // 0x2F
		public bool NANEGCHBEDN; // 0x30
		public PKNOKJNLPOE_EventRaid AIOGBKCJLHM; // 0x34
		public bool DKKJPLALNFD; // 0x38
	}

	public class KAGMKNANHBA
	{
		public ANPBHCNJIDI.NBHIMCACDHM HCAHCFGPJIF; // 0x8

		// public bool DNJGAJPIIPI { get; } 0xC25738 GALFPKKIGBH

		// // RVA: 0xC25B70 Offset: 0xC25B70 VA: 0xC25B70
		// public void LHPDDGIJKNB() { }
	}

	public delegate void BFFHCHKDHJM(KAGMKNANHBA PNNCCHGFCME);

	public class GDNGPJINPDK
	{
		public int FDBOPFEOENF_Id; // 0x8
		public int IJLLIGENJCI_Pic; // 0xC
		public string LJGOOOMOMMA_Message; // 0x10
	}

	public enum NGHEKBHLBAN
	{
		CFBJGAGBJEN_0 = 0,
		DMBDNIEEMCB = 1,
		BKLKNLDCJIO = 2,
	}

	// private const int GHJHJDIDCFA = 3;
	// private const int HDNDLJNKFFF = 100;
	// public const int ODALKFEBNNA = 1;
	// public const int LMCNAKBEBGI = 2147483647;
	// public const int HJLEHBHKDNC = 15;
	// private const int HIIDHBDPHJD = 1000;
	public int JGICMFAKGFO_SelectedChatType; // 0xE8
	public bool FJHLAKJBNFA; // 0xEC
	// private EECOJKDJIFG KBACNOCOANM; // 0xF0
	// private BBHNACPENDM FPPNANIIODA = new BBHNACPENDM(); // 0xF4
	public List<ELKMKCNPDFO> ACCNCHJBDHM_Users = new List<ELKMKCNPDFO>(100); // 0xF8
	// private const ulong PFNFFKJGBMI = 549755813893;
	// public const int BDNKGIAJANK = 3;
	// private KKLGJPAIHJN EGMBECGOHAE; // 0xFC
	// private KKLGJPAIHJN OKMNIPKLHHK; // 0x100
	// private OKLFOAPMJAA FCBCCOEBHJB; // 0x104
	// private OKLFOAPMJAA.BABPHOEGLPC[] KBMOEKMKGBL; // 0x108
	// private NKOBMDPHNGP.BFFHCHKDHJM CNCPFACLJHH; // 0x110
	// private static StringBuilder NIGIOKLMJIH = new StringBuilder(32); // 0x0
	// private List<int> OKGDAODFFBF = new List<int>(16); // 0x118

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby; } } //0xC1E3C0 DKHCGLCNKCD  Slot: 4
	// public bool IFGKKLPOONJ { get; }
	// public bool LLJAIPIDANN { get; }
	// public bool IPLBEGCODDC { get; }
	// public int AMICDJMOGMA { get; }
	// public bool BGKKGPNBPJJ { get; }
	// public bool NLNIDMNBMPO { get; }
	// public bool IHDHKJBMMJP { get; set; }
	// public bool OOCDOBAALCB { get; }
	// public bool CDCDLDIKIBE { get; }
	// public NKOBMDPHNGP.KAGMKNANHBA KPPHGAAOMDN { get; set; } // 0x10C JLCLGIBMKEK
	// public bool LDCEDHEKDPK { get; }
	// public bool IICNDOGFDLD { get; }
	// public int AMFIHIEMPND { get; }
	// public int FDGMLPLCALF { get; set; } // 0x114 KNKBBLLHNPF
	// public List<int> HOFEMNJNDCC { get; }
	// public static int EAIBKGDAMLE { get; }
	// public static string JKOGDCFELHF { get; }
	// public bool NLLFHIKOKLM { get; }
	// public bool FCLIMIPGPAB { get; }

	// // RVA: 0xC1E3C8 Offset: 0xC1E3C8 VA: 0xC1E3C8 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO = 0)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "DAKMIKNKHMF");
		return null;
	}

	// RVA: 0xC1E3D0 Offset: 0xC1E3D0 VA: 0xC1E3D0
	public NKOBMDPHNGP_EventRaidLobby(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
        if(FJLIDJJAGOM() == null)
            return;
        TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NKOBMDPHNGP_EventRaidLobby()");
        /*FPPNANIIODA.EBKCPELHDKN();
        MALEKMPDKKF()
        CNGIENBEHID();*/
    }

	// // RVA: 0xC1E560 Offset: 0xC1E560 VA: 0xC1E560
	public LDEBIBGHCGD_EventRaidLobby FJLIDJJAGOM()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId);
		if(db != null)
		{
			return db as LDEBIBGHCGD_EventRaidLobby;
		}
		return null;
	}

	// // RVA: 0xC1E85C Offset: 0xC1E85C VA: 0xC1E85C
	// private KBAGKBIBGPM.JAIFDODKMIA KNKJHNJFONJ(BBHNACPENDM KGPIPDHHNPK) { }

	// // RVA: 0xC1E87C Offset: 0xC1E87C VA: 0xC1E87C
	// private KBAGKBIBGPM.JAIFDODKMIA KNKJHNJFONJ(LDEBIBGHCGD NDFIEMPPMLF, BBHNACPENDM BGEPKJCKKGF) { }

	// // RVA: 0xC1E9B8 Offset: 0xC1E9B8 VA: 0xC1E9B8 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA = 0)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "HLOGNJNGDJO");
		return 0;
	}

	// // RVA: 0xC1EA28 Offset: 0xC1EA28 VA: 0xC1EA28 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
	{
		if(FJLIDJJAGOM() != null)
		{
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NKOBMDPHNGP_EventRaidLobby.JIHMLILFOPG");
		}
		return false;
	}

	// // RVA: 0xC1EB64 Offset: 0xC1EB64 VA: 0xC1EB64 Slot: 31
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NKOBMDPHNGP_EventRaidLobby.IMCMNOPNGHO");
		return false;
	}

	// // RVA: 0xC1EE14 Offset: 0xC1EE14 VA: 0xC1EE14 Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KKFLDCBHFJA");
	}

	// // RVA: 0xC1EFB4 Offset: 0xC1EFB4 VA: 0xC1EFB4 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PJDGDNJNCNM");
	}

	// // RVA: 0xC1F014 Offset: 0xC1F014 VA: 0xC1F014 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "FBGDBGKNKOD");
		return 0;
	}

	// // RVA: 0xC1F020 Offset: 0xC1F020 VA: 0xC1F020 Slot: 26
	public override bool KKFEDJNIAAG(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KKFEDJNIAAG");
		return false;
	}

	// // RVA: 0xC1F028 Offset: 0xC1F028 VA: 0xC1F028
	public JKOHBJPCAJL.CNNCBDKIPGE ILCPALOKKHC()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "ILCPALOKKHC");
		return 0;
	}

	// // RVA: 0xC1F058 Offset: 0xC1F058 VA: 0xC1F058
	// public void MPCPIMOACHJ(JKOHBJPCAJL.CNNCBDKIPGE LGADCGFMLLD) { }

	// // RVA: 0xC1F08C Offset: 0xC1F08C VA: 0xC1F08C Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "ADACMHAHHKC");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDB34 Offset: 0x6BDB34 VA: 0x6BDB34
	// // RVA: 0xC1F0E4 Offset: 0xC1F0E4 VA: 0xC1F0E4
	// private IEnumerator NJIEIJJMAHK(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0xC1F1C0 Offset: 0xC1F1C0 VA: 0xC1F1C0 Slot: 69
	// public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0xC1F2E8 Offset: 0xC1F2E8 VA: 0xC1F2E8 Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "BAEPGOAMBDK");
		return 0;
	}

	// // RVA: 0xC1F320 Offset: 0xC1F320 VA: 0xC1F320 Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MAICAKMIBEM");
		return MNCOAGOKNAO;
	}

	// // RVA: 0xC1F358 Offset: 0xC1F358 VA: 0xC1F358 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "FEKEBPKINIM");
		return "";
	}

	// // RVA: 0xC1F3D0 Offset: 0xC1F3D0 VA: 0xC1F3D0
	// public bool EMPOBKBHLAC(long JHNMKKNEENE) { }

	// // RVA: 0xC1F4DC Offset: 0xC1F4DC VA: 0xC1F4DC
	public FIPGKDJHKCH_Phase KINIOEOOCAA_GetPhase(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KINIOEOOCAA");
		return FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now;
	}

	// // RVA: 0xC1F5A8 Offset: 0xC1F5A8 VA: 0xC1F5A8
	// public void COBCHBMMFPB(out long PDBPFJJCADD, out long FDBNFFNFOND) { }

	// // RVA: 0xC1F618 Offset: 0xC1F618 VA: 0xC1F618
	// public void IICLCPIPENB(out long PDBPFJJCADD, out long FDBNFFNFOND) { }

	// // RVA: 0xC1F688 Offset: 0xC1F688 VA: 0xC1F688
	public int IICHMBONEIE_GetDayBefore(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "IICHMBONEIE");
		return 0;
	}

	// // RVA: 0xC1F8A8 Offset: 0xC1F8A8 VA: 0xC1F8A8
	public int MKACADAOPEI_GetDayNow(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MKACADAOPEI");
		return 0;
	}

	// // RVA: 0xC1FAC8 Offset: 0xC1FAC8 VA: 0xC1FAC8
	public int PIFFFLDOJKJ_GetDayAfter(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PIFFFLDOJKJ");
		return 0;
	}

	// // RVA: 0xC1FCE8 Offset: 0xC1FCE8 VA: 0xC1FCE8
	public FIPGKDJHKCH_Phase CHDNDNMHJHI_GetPhase()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PIFFFLDOJKJ");
		return 0;
	}

	// // RVA: 0xC1F45C Offset: 0xC1F45C VA: 0xC1F45C
	public bool ANOPCGFIMEJ()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "ANOPCGFIMEJ");
		return false;
	}

	// // RVA: 0xC1FD44 Offset: 0xC1FD44 VA: 0xC1FD44
	public void EGIHAHOCKPK()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "EGIHAHOCKPK");
	}

	// // RVA: 0xC1FDD4 Offset: 0xC1FDD4 VA: 0xC1FDD4
	// public bool MCJFAACGLCB() { }

	// // RVA: 0xC1FE14 Offset: 0xC1FE14 VA: 0xC1FE14
	// private int OKEOHFMGPNG(long HMFFHLPNMPH, int JGEEFPKHHCH, int IIJMIIBLDKJ) { }

	// // RVA: 0xC1FE54 Offset: 0xC1FE54 VA: 0xC1FE54
	// public int OKEOHFMGPNG(long FJOLNJLLJEJ, int JGEEFPKHHCH, List<int> IIJMIIBLDKJ) { }

	// // RVA: 0xC20004 Offset: 0xC20004 VA: 0xC20004
	public bool EHLFBIEGDDF()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "EHLFBIEGDDF");
		return true;
	}

	// // RVA: 0xC200EC Offset: 0xC200EC VA: 0xC200EC
	public void DEJFFGKLNHP(int FAEPBBLLANI, int DDFDEEAHCEP, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "DEJFFGKLNHP");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDBAC Offset: 0x6BDBAC VA: 0x6BDBAC
	// // RVA: 0xC20218 Offset: 0xC20218 VA: 0xC20218
	// private IEnumerator JNPBHMMILOP(int DDFDEEAHCEP, LDEBIBGHCGD.HDFAGGBJGAA KGICDMIJGDF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BDC24 Offset: 0x6BDC24 VA: 0x6BDC24
	// // RVA: 0xC20330 Offset: 0xC20330 VA: 0xC20330
	// private IEnumerator AEPPBBLPBPE(int DDFDEEAHCEP, LDEBIBGHCGD.HDFAGGBJGAA KGICDMIJGDF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xC20448 Offset: 0xC20448 VA: 0xC20448
	// private int CHPLIGDOMLI(int INHOGJODJFJ, int MALFHCHNEFN) { }

	// // RVA: 0xC20690 Offset: 0xC20690 VA: 0xC20690
	// public void OBBGPHPPCML(out int INHOGJODJFJ, out int MALFHCHNEFN) { }

	// // RVA: 0xC207CC Offset: 0xC207CC VA: 0xC207CC
	// private void OBBGPHPPCML(int AIBFGKBACCB, out int INHOGJODJFJ, out int MALFHCHNEFN) { }

	// // RVA: 0xC20900 Offset: 0xC20900 VA: 0xC20900
	// private static void OBBGPHPPCML(int AIBFGKBACCB, int BFBIEECIDIM, int IAEKNMNHCFH, out int INHOGJODJFJ, out int MALFHCHNEFN) { }

	// // RVA: 0xC20964 Offset: 0xC20964 VA: 0xC20964
	public int EEJNPNOADGC(ELKMKCNPDFO AHEFHIMGIBI)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "EEJNPNOADGC");
		return 0;
	}

	// // RVA: 0xC20A6C Offset: 0xC20A6C VA: 0xC20A6C
	public void LHIIGAMEABL(ELKMKCNPDFO AHEFHIMGIBI, out int KGICDMIJGDF, out int GCBDNOPCGNP)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LHIIGAMEABL");
		KGICDMIJGDF = 0;
		GCBDNOPCGNP = 0;
	}

	// // RVA: 0xC20B28 Offset: 0xC20B28 VA: 0xC20B28
	public int EDILJHGLMNG()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "EDILJHGLMNG");
		return 0;
	}

	// // RVA: 0xC20BB8 Offset: 0xC20BB8 VA: 0xC20BB8
	// public string NHACIJELHIB(int OIPCCBHIKIA) { }

	// // RVA: 0xC20C7C Offset: 0xC20C7C VA: 0xC20C7C
	public string OFAKIAJNPDF(int PPFNGGCBJKC)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "OFAKIAJNPDF");
		return "";
	}

	// // RVA: 0xC20D20 Offset: 0xC20D20 VA: 0xC20D20
	public int EPPBAFDEDCD(int OIPCCBHIKIA)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "EPPBAFDEDCD");
		return 0;
	}

	// // RVA: 0xC20DD0 Offset: 0xC20DD0 VA: 0xC20DD0
	// public int AMCHEACNLLG(int PPFNGGCBJKC) { }

	// // RVA: 0xC20E08 Offset: 0xC20E08 VA: 0xC20E08
	public int HJJBDFCMJJM()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "HJJBDFCMJJM");
		return 0;
	}

	// // RVA: 0xC20F4C Offset: 0xC20F4C VA: 0xC20F4C
	public int GAHICKBDHFO()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GAHICKBDHFO");
		return 0;
	}

	// // RVA: 0xC21090 Offset: 0xC21090 VA: 0xC21090
	public void NLIJCLIGIFC(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NLIJCLIGIFC");
	}

	// // RVA: 0xC21450 Offset: 0xC21450 VA: 0xC21450
	public void EJEIHOOOBLM(int PACBOPLFGCF, ELKMKCNPDFO EIMMNMFFBCD, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK BKLCMFMIIHF, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "EJEIHOOOBLM");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDC9C Offset: 0x6BDC9C VA: 0x6BDC9C
	// // RVA: 0xC214C4 Offset: 0xC214C4 VA: 0xC214C4
	// private IEnumerator DFKDDOGBOHE_JoinLobbyByPlayer(int PACBOPLFGCF, NKOBMDPHNGP.ELKMKCNPDFO EIMMNMFFBCD, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK BKLCMFMIIHF, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xC215F4 Offset: 0xC215F4 VA: 0xC215F4
	public bool NNNNJJADGMH()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NNNNJJADGMH");
		return true;
	}

	// // RVA: 0xC21630 Offset: 0xC21630 VA: 0xC21630
	public void NHPFMNGMMHG(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NHPFMNGMMHG");
	}

	// // RVA: 0xC2182C Offset: 0xC2182C VA: 0xC2182C
	public void IIBLJMMGMPD(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "IIBLJMMGMPD");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDD14 Offset: 0x6BDD14 VA: 0x6BDD14
	// // RVA: 0xC21884 Offset: 0xC21884 VA: 0xC21884
	// private IEnumerator FGKGCPICMDN_SearchLobbyMember(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xC21964 Offset: 0xC21964 VA: 0xC21964
	public void KCAJBLICFPJ(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KCAJBLICFPJ");
	}

	// // RVA: 0xC21EC0 Offset: 0xC21EC0 VA: 0xC21EC0
	public void NGKIBBIEAAD()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NGKIBBIEAAD");
	}

	// // RVA: 0xC21F38 Offset: 0xC21F38 VA: 0xC21F38
	public void LLLKDLPJHCF(int MLPEHNBNOGD, Action<int, int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LLLKDLPJHCF");
	}

	// // RVA: 0xC22240 Offset: 0xC22240 VA: 0xC22240
	// private void PLKPGEGNLFH(StringBuilder KOHNLDKIKPC, int AIBFGKBACCB, NKOBMDPHNGP.FLHJEJGJJGE KLMCILEDMEL) { }

	// // RVA: 0xC222EC Offset: 0xC222EC VA: 0xC222EC
	public bool AFBNKKAHFCI()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "AFBNKKAHFCI");
		return false;
	}

	// // RVA: 0xC222FC Offset: 0xC222FC VA: 0xC222FC
	public bool JHBLAGLBIAD()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "JHBLAGLBIAD");
		return false;
	}

	// // RVA: 0xC2231C Offset: 0xC2231C VA: 0xC2231C
	public bool CDCAJDEPMKN()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "CDCAJDEPMKN");
		return false;
	}

	// // RVA: 0xC2233C Offset: 0xC2233C VA: 0xC2233C
	public void NIIEJKGNEBH()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NIIEJKGNEBH");
	}

	// // RVA: 0xC2244C Offset: 0xC2244C VA: 0xC2244C
	public void NIIEJKGNEBH(int AIBFGKBACCB)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NIIEJKGNEBH");
	}

	// // RVA: 0xC22BD0 Offset: 0xC22BD0 VA: 0xC22BD0
	// private int KGGDENNDEAN() { }

	// // RVA: 0xC22D6C Offset: 0xC22D6C VA: 0xC22D6C
	// private void HDAOMKFAIPP(NKOBMDPHNGP.FLHJEJGJJGE KLMCILEDMEL) { }

	// // RVA: 0xC23040 Offset: 0xC23040 VA: 0xC23040
	public int JIDLPGHJOIE_GetCommentsCount(FLHJEJGJJGE KLMCILEDMEL)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "JIDLPGHJOIE");
		return 0;
	}

	// // RVA: 0xC230D0 Offset: 0xC230D0 VA: 0xC230D0
	public ANPBHCNJIDI.NNPGLGHDBKN GDGCADFCDCL_GetComment(FLHJEJGJJGE KLMCILEDMEL, int OIPCCBHIKIA)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GDGCADFCDCL");
		return null;
	}

	// // RVA: 0xC23168 Offset: 0xC23168 VA: 0xC23168
	// public int DLPCLKFKINM(NKOBMDPHNGP.FLHJEJGJJGE KLMCILEDMEL) { }

	// // RVA: 0xC231F8 Offset: 0xC231F8 VA: 0xC231F8
	public bool BJMPAPCDGIG_IsLogEnabled()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "BJMPAPCDGIG");
		return false;
	}

	// // RVA: 0xC232FC Offset: 0xC232FC VA: 0xC232FC
	public void NLGAFNOHLID_SetLogEnabled(bool NANNGLGOFKH)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NLGAFNOHLID");
	}

	// // RVA: 0xC23450 Offset: 0xC23450 VA: 0xC23450
	// public bool AAECCLGAMNO() { }

	// // RVA: 0xC2347C Offset: 0xC2347C VA: 0xC2347C
	public void MMMBGDHMJKC(int KPNKPGLPDHI, FLHJEJGJJGE KLMCILEDMEL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MMMBGDHMJKC");
	}

	// // RVA: 0xC234A0 Offset: 0xC234A0 VA: 0xC234A0
	// private void CLLMBGONMKE(int KPNKPGLPDHI, NKOBMDPHNGP.FLHJEJGJJGE KLMCILEDMEL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool BELNGJDDEIB) { }

	// // RVA: 0xC236A8 Offset: 0xC236A8 VA: 0xC236A8
	public void MICOCAOLCEJ(int KPNKPGLPDHI, FLHJEJGJJGE KLMCILEDMEL, Action<List<FLHJEJGJJGE>> OKLICHHNKEA, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MICOCAOLCEJ");
	}

	// // RVA: 0xC23884 Offset: 0xC23884 VA: 0xC23884
	public void PMCMAKBNJIL()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PMCMAKBNJIL");
	}

	// // RVA: 0xC238B0 Offset: 0xC238B0 VA: 0xC238B0
	public bool MIKMNNCEFBH(FLHJEJGJJGE KLMCILEDMEL)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MIKMNNCEFBH");
		return false;
	}

	// // RVA: 0xC23940 Offset: 0xC23940 VA: 0xC23940
	public void DJEEPILBAIH(FLHJEJGJJGE KLMCILEDMEL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "DJEEPILBAIH");
	}

	// // RVA: 0xC23B18 Offset: 0xC23B18 VA: 0xC23B18
	public bool CCIKMMPIMHD()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "CCIKMMPIMHD");
		return false;
	}

	// // RVA: 0xC23B44 Offset: 0xC23B44 VA: 0xC23B44
	public void HJNDLPNBBKF(FLHJEJGJJGE KLMCILEDMEL, ANPBHCNJIDI.NNPGLGHDBKN HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, DJBHIFLHJLK NKGHADCBGJO)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "HJNDLPNBBKF");
	}

	// // RVA: 0xC23D64 Offset: 0xC23D64 VA: 0xC23D64
	// public void CADBGOEBMEO(NKOBMDPHNGP.FLHJEJGJJGE KLMCILEDMEL, ANPBHCNJIDI.NNPGLGHDBKN HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xC23F40 Offset: 0xC23F40 VA: 0xC23F40
	// public void CKONNBGNAKG(NKOBMDPHNGP.FLHJEJGJJGE KLMCILEDMEL, ANPBHCNJIDI.NNPGLGHDBKN HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xC24114 Offset: 0xC24114 VA: 0xC24114
	public void NKLFDHJKIII(FLHJEJGJJGE KLMCILEDMEL, int MLPEHNBNOGD, int LCJEPKENHCE, Action<bool> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "HJNDLPNBBKF");
	}

	// // RVA: 0xC24328 Offset: 0xC24328 VA: 0xC24328
	// private int AIIPLCEICBM(ANPBHCNJIDI.NOJONDLAMOC INDDJNMPONH) { }

	// // RVA: 0xC24330 Offset: 0xC24330 VA: 0xC24330
	// public string ABGDJKLFBKL(ANPBHCNJIDI.PHICILDLHJP HCAHCFGPJIF, PKNOKJNLPOE AIOGBKCJLHM) { }

	// // RVA: 0xC24BEC Offset: 0xC24BEC VA: 0xC24BEC
	// public void EGBFCCFICIF(NKOBMDPHNGP.PEDPKDBKGIN PIBLLGLCJEO, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xC255D8 Offset: 0xC255D8 VA: 0xC255D8
	// private bool GOENGHBLHDB(ANPBHCNJIDI.NNPGLGHDBKN HCAHCFGPJIF) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BDD8C Offset: 0x6BDD8C VA: 0x6BDD8C
	// // RVA: 0xC25704 Offset: 0xC25704 VA: 0xC25704
	public KAGMKNANHBA CPJAANJHBFC()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "CPJAANJHBFC");
		return null;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BDD9C Offset: 0x6BDD9C VA: 0x6BDD9C
	// // RVA: 0xC22D64 Offset: 0xC22D64 VA: 0xC22D64
	// private void KELONCIDGHP(NKOBMDPHNGP.KAGMKNANHBA NANNGLGOFKH) { }

	// // RVA: 0xC2570C Offset: 0xC2570C VA: 0xC2570C
	// public bool APMIOHBDCPP() { }

	// // RVA: 0xC25748 Offset: 0xC25748 VA: 0xC25748
	public void MKIBMJCPHKI(BFFHCHKDHJM KBCBGIGOLHP)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MKIBMJCPHKI");
	}

	// // RVA: 0xC25750 Offset: 0xC25750 VA: 0xC25750
	public void BLDACFKPCGM()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "BLDACFKPCGM");
	}

	// // RVA: 0xC2575C Offset: 0xC2575C VA: 0xC2575C
	// private void ADENMOCKJGH() { }

	// // RVA: 0xC263A4 Offset: 0xC263A4 VA: 0xC263A4
	public void JCCAPHGLOJF(int LGPGAPNGBGG, Action<List<ANPBHCNJIDI.BNEIDPGIAFM>> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "JCCAPHGLOJF");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDDAC Offset: 0x6BDDAC VA: 0x6BDDAC
	// // RVA: 0xC2640C Offset: 0xC2640C VA: 0xC2640C
	// private IEnumerator GPBFKOMIAAG(int LGPGAPNGBGG, Action<List<ANPBHCNJIDI.BNEIDPGIAFM>> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xC253C8 Offset: 0xC253C8 VA: 0xC253C8
	// public static int NMMKHNDOEFB() { }

	// // RVA: 0xC26500 Offset: 0xC26500 VA: 0xC26500
	public bool ABNLPDNFHDN()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "ABNLPDNFHDN");
		return false;
	}

	// // RVA: 0xC2652C Offset: 0xC2652C VA: 0xC2652C
	public void CBOFAFKMIBE(ANPBHCNJIDI.PHICILDLHJP HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "CBOFAFKMIBE");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BDE24 Offset: 0x6BDE24 VA: 0x6BDE24
	// // RVA: 0xC26594 Offset: 0xC26594 VA: 0xC26594
	// private IEnumerator LKNPBAGDJDF_CopyBbsBattleLogCommentToMain(ANPBHCNJIDI.PHICILDLHJP HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xC2668C Offset: 0xC2668C VA: 0xC2668C Slot: 16
	protected override bool FHKCEPMCGCK()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "FHKCEPMCGCK");
		return true;
	}

	// // RVA: 0xC26690 Offset: 0xC26690 VA: 0xC26690 Slot: 15
	protected override int KFNINHEJCLF()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KFNINHEJCLF");
		return 0;
	}

	// // RVA: 0xC26794 Offset: 0xC26794 VA: 0xC26794
	// public bool JFIACOLOCBN() { }

	// // RVA: 0xC26A0C Offset: 0xC26A0C VA: 0xC26A0C
	public void PBPBEMJGIJK()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PBPBEMJGIJK");
	}

	// // RVA: 0xC26BCC Offset: 0xC26BCC VA: 0xC26BCC
	public List<AKIIJBEJOEP> MHGAHHPGGAE_GetMisions()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MHGAHHPGGAE");
		return null;
	}

	// // RVA: 0xC26F60 Offset: 0xC26F60 VA: 0xC26F60
	public bool PCLDCIAKCGO()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PCLDCIAKCGO");
		return false;
	}

	// // RVA: 0xC26F90 Offset: 0xC26F90 VA: 0xC26F90
	public void OBIDIBBDEKM(bool OAFPGJLCNFM)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "OBIDIBBDEKM");
	}

	// // RVA: 0xC26FC4 Offset: 0xC26FC4 VA: 0xC26FC4
	// public int IFDJALILEOF() { }

	// // RVA: 0xC26FF4 Offset: 0xC26FF4 VA: 0xC26FF4
	// public void MCPEJDANIAL(int IADNLGMIHDK) { }

	// // RVA: 0xC27028 Offset: 0xC27028 VA: 0xC27028
	public bool KLEEKOAFIIK(bool FBBNPFFEJBN)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NKOBMDPHNGP_EventRaidLobby.KLEEKOAFIIK");
		return false;
	}

	// // RVA: 0xC27304 Offset: 0xC27304 VA: 0xC27304
	public GDNGPJINPDK IBDNMIFLEKK(NGHEKBHLBAN INDDJNMPONH/* = 0*/)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NKOBMDPHNGP_EventRaidLobby.IBDNMIFLEKK");
		return null;
	}

	// // RVA: 0xC275F4 Offset: 0xC275F4 VA: 0xC275F4
	public int EHGKMLPCDBM(RaidItemConstants.Type INDDJNMPONH, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NKOBMDPHNGP_EventRaidLobby.EHGKMLPCDBM");
		return 0;
	}

	// // RVA: 0xC27634 Offset: 0xC27634 VA: 0xC27634
	public void NCBELAFIPDN(RaidItemConstants.Type INDDJNMPONH, int HMFFHLPNMPH, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NKOBMDPHNGP_EventRaidLobby.NCBELAFIPDN");
	}

	// // RVA: 0xC27674 Offset: 0xC27674 VA: 0xC27674
	public int ONKKHPKHCIA_GetNumTicket()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NKOBMDPHNGP_EventRaidLobby.ONKKHPKHCIA");
		return 0;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BDE9C Offset: 0x6BDE9C VA: 0x6BDE9C
	// // RVA: 0xC27680 Offset: 0xC27680 VA: 0xC27680
	public int JNCAEPBEEAH()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NKOBMDPHNGP_EventRaidLobby.JNCAEPBEEAH");
		return 0;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BDEAC Offset: 0x6BDEAC VA: 0x6BDEAC
	// // RVA: 0xC27688 Offset: 0xC27688 VA: 0xC27688
	// private void IHJMHGEAOFN(int NANNGLGOFKH) { }

	// // RVA: 0xC27690 Offset: 0xC27690 VA: 0xC27690
	// public List<int> ACNLOIIGPLL() { }

	// // RVA: 0xC27698 Offset: 0xC27698 VA: 0xC27698
	public static int ADPMLOEOAFD_GetTicketId()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "ADPMLOEOAFD (raid)");
		return 0;
	}

	// // RVA: 0xC276A4 Offset: 0xC276A4 VA: 0xC276A4
	public static string GPNELLFNPLA()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GPNELLFNPLA (raid)");
		return "";
	}

	// // RVA: 0xC1E674 Offset: 0xC1E674 VA: 0xC1E674
	// private void MALEKMPDKKF() { }

	// // RVA: 0xC27760 Offset: 0xC27760 VA: 0xC27760
	// public void KCEDMGFCOAE(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN, int FCLGIPFPIPH) { }

	// // RVA: 0xC27A58 Offset: 0xC27A58 VA: 0xC27A58
	// private int GGPLIBIPHLI(int AKNELONELJK = 0) { }

	// // RVA: 0xC27EE0 Offset: 0xC27EE0 VA: 0xC27EE0
	public bool AKNOOLKMEGJ()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "AKNOOLKMEGJ");
		return false;
	}

	// // RVA: 0xC27F04 Offset: 0xC27F04 VA: 0xC27F04
	// public void OMNKLDDHNNE() { }

	// // RVA: 0xC27F34 Offset: 0xC27F34 VA: 0xC27F34
	// public bool LDEPDKGNAPK() { }

	// // RVA: 0xC27F74 Offset: 0xC27F74 VA: 0xC27F74
	// public void DOCCMMJMJMP() { }

	// // RVA: 0xC27FA4 Offset: 0xC27FA4 VA: 0xC27FA4
	// public void IMBLLJAEMAI(int HMFFHLPNMPH) { }

	// // RVA: 0xC28010 Offset: 0xC28010 VA: 0xC28010
	// public void GFIJEBKPANK(int HMFFHLPNMPH) { }

	// // RVA: 0xC27BAC Offset: 0xC27BAC VA: 0xC27BAC
	// public void AKGAFHKMFOO(int HMFFHLPNMPH, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, string MDADLCOCEBN) { }

	// // RVA: 0xC28134 Offset: 0xC28134 VA: 0xC28134
	// public void KHGKJMODLDE(int HMFFHLPNMPH) { }

	// // RVA: 0xC20510 Offset: 0xC20510 VA: 0xC20510
	public int PDNFHDLNENO(int PPFNGGCBJKC)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PDNFHDLNENO");
		return 0;
	}

	// // RVA: 0xC282B0 Offset: 0xC282B0 VA: 0xC282B0
	public int DKNNNOIMMFN_GetClusterId()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "DKNNNOIMMFN");
		return 0;
	}

	// // RVA: 0xC207B8 Offset: 0xC207B8 VA: 0xC207B8
	public static int FAKHCOJIOBD(int PPFNGGCBJKC, int NEFEFHBHFFF/* = 1*/)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "FAKHCOJIOBD");
		return 0;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BDEBC Offset: 0x6BDEBC VA: 0x6BDEBC
	// // RVA: 0xC2852C Offset: 0xC2852C VA: 0xC2852C
	// private bool <InitializeBbs>b__93_0(ANPBHCNJIDI.NNPGLGHDBKN PIABJCEJIHC) { }
}
