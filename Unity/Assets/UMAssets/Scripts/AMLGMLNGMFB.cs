
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use AMLGMLNGMFB_EventAprilFool", true)]
public class AMLGMLNGMFB { }
public class AMLGMLNGMFB_EventAprilFool : IKDICBBFBMI_EventBase
{
	private enum IGIPPPLKDJP
	{
		HJNNKCMLGFL = 0,
		KEBIIAMNKAJ = 1,
	}

	private enum HODGPGLCPKM
	{
		HJNNKCMLGFL = 0,
		EBKLKECECIF = 1,
	}

	public enum MMKMPKEBLBF
	{
		HJNNKCMLGFL = 0,
		DMPOKMFNPKP = 1,
	}

	public enum ANFKADJMHPO
	{
		LOFOEPLBMID = 0,
		LGMPDPNEPGD = 1,
		BPJBNFNKGOJ = 2,
	}

	public class FOFMLBPMIIC
	{
		public int JJJNKGBCFMI = 0; // 0x8
		public int AGKIABJHDDG = 0; // 0xC
		public string FEMMDNIELFC = ""; // 0x10
		public int JNCPEGJGHOG = 0; // 0x14
		public string NEDBBJDAFBH = ""; // 0x18
	}

	public class OLDLIIKHDKD
	{
		public int CMJEGIEJNMD { get; private set; } // 0x8 IDFDLCAMDJH AGEDDPBMIKH LOLNKOKFIIE
		public MMKMPKEBLBF GODBCGAFMBE { get; private set; } // 0xC JLPCLKOHCAH GJHPPLPNIIF BLONDJKOIOG
		public int DDIOHHEGANL { get; private set; } // 0x10 GHPIIFOKMPM IIFKOIEJFKF DGIPAMDIKPD
		public int ELIFBFLFAFC { get; private set; } // 0x14 IGMJIGLNICF FIIPNJGPEFL EAPCKJIHFEA

		// RVA: 0xCE6E2C Offset: 0xCE6E2C VA: 0xCE6E2C
		public OLDLIIKHDKD(int IGHPMLOFGMO, int AGEGAHMDMPH, int KKFMFGPBHKM, int LGCKAMEEDGC)
		{
			CMJEGIEJNMD = IGHPMLOFGMO;
			GODBCGAFMBE = (MMKMPKEBLBF)AGEGAHMDMPH;
			DDIOHHEGANL = LGCKAMEEDGC;
			ELIFBFLFAFC = KKFMFGPBHKM;
		}
	}

	public class JPGMKBANFGF
	{
		private int FBGGEFFJJHB = 0x13c7dd4; // 0x8
		private sbyte ALPDMEILILP; // 0xC
		private int NBOLDNMPJFG; // 0x10
		private sbyte JAFNIDLINKN; // 0x14

		//public bool BCGLDMKODLC { get; set; } 0xCE7DC8 NNGALFPBDNA 0xCE8E40 JJBMOHCMALD
		//public int KNIFCANOHOC { get; set; } 0xCE7D00 EOJEPLIPOMJ 0xCE8E70 AEEMBPAEAAI
		//public bool CHPIFIEEEEC { get; set; } 0xCE7D20 FLHPOBEBLBH 0xCE8E80 LIJEMJDBNPD
	}

	public class IMFNPKNPDDP
	{
		private int FBGGEFFJJHB; // 0x8
		private sbyte ALPDMEILILP; // 0xC
		private int NBOLDNMPJFG; // 0x10
		private sbyte NLKIOJKEKNM; // 0x14
		private int KGNDGJAOFJG; // 0x18
		private sbyte MNOIODAMMCC; // 0x1C

		//public bool BCGLDMKODLC { get; set; } 0xCE7E0C NNGALFPBDNA 0xCE7DDC JJBMOHCMALD
		//public int KNIFCANOHOC { get; set; }  0xCE8DE4 EOJEPLIPOMJ 0xCE7D10 AEEMBPAEAAI
		//public bool PIBCFBBLHBB { get; set; } 0xCE8DF4 BLHCJKNODGF 0xCE7D34 ILCPMIBDKPB
		//public int LGDLEHHOIEL { get; set; } 0xCE7DA4 OMFCCEBAODD 0xCE7D64 JGIJCMFGKEP
		//public bool LNDLJBINJDE { get; set; } 0xCE7DB4 HHNJLPDNDPN 0xCE7D74 CCOMADGCMEG

		// RVA: 0xCE1F20 Offset: 0xCE1F20 VA: 0xCE1F20
		public IMFNPKNPDDP()
		{
			FBGGEFFJJHB = (int)(Utility.GetCurrentUnixTime() ^ 0x346293);
			NBOLDNMPJFG = FBGGEFFJJHB;
			ALPDMEILILP = 0x33;
			KGNDGJAOFJG = FBGGEFFJJHB;
		}

		// RVA: 0xCE8E08 Offset: 0xCE8E08 VA: 0xCE8E08
		//private void KHEKNNFCAOI(int KNEFBLHBDBG) { }
	}

	// private const int GHJHJDIDCFA = 3;
	// private List<KCGOMAFPGDD.EIEGCBJHGCP> NFMDLCBJOIB = new List<KCGOMAFPGDD.EIEGCBJHGCP>(); // 0xE8
	// private EECOJKDJIFG KBACNOCOANM; // 0xEC
	// public AMLGMLNGMFB.IMFNPKNPDDP MMICFFPMHIC = new AMLGMLNGMFB.IMFNPKNPDDP(); // 0xF0

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB;} }// 0xCE1CB0 DKHCGLCNKCD  Slot: 4

	// // RVA: 0xCE1CB8 Offset: 0xCE1CB8 VA: 0xCE1CB8 Slot: 5
	// public override string IFKKBHPMALH() { }

	// RVA: 0xCE1E40 Offset: 0xCE1E40 VA: 0xCE1E40
	public AMLGMLNGMFB_EventAprilFool(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
        return;
    }

	// // RVA: 0xCE1FE0 Offset: 0xCE1FE0 VA: 0xCE1FE0
	// private List<int> DAFEPLPDCJD(long JHNMKKNEENE) { }

	// // RVA: 0xCE224C Offset: 0xCE224C VA: 0xCE224C
	// public int BMBELGEDKEG(int PPFNGGCBJKC_Id) { }

	// // RVA: 0xCE24AC Offset: 0xCE24AC VA: 0xCE24AC
	// public int GOHABONFBDM(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0xCE266C Offset: 0xCE266C VA: 0xCE266C
	// private List<KCGOMAFPGDD.EIEGCBJHGCP> LEAGIGKFMPE(bool DHNFPAGENLN, long JHNMKKNEENE = -1) { }

	// // RVA: 0xCE2BC4 Offset: 0xCE2BC4 VA: 0xCE2BC4
	// public List<KCGOMAFPGDD.EIEGCBJHGCP> KOBMFPACBMB() { }

	// // RVA: 0xCE2C68 Offset: 0xCE2C68 VA: 0xCE2C68
	// public void BEFJOAGGAJD() { }

	// // RVA: 0xCE2CE0 Offset: 0xCE2CE0 VA: 0xCE2CE0 Slot: 7
	public override List<int> HEACCHAKMFG()
	{
		TodoLogger.Log(0, "HEACCHAKMFG");
		return base.HEACCHAKMFG();
	}

	// // RVA: 0xCE2E54 Offset: 0xCE2E54 VA: 0xCE2E54 Slot: 9
	// public override long HOOBCIIOCJD(int GHBPLHBNMBK) { }

	// // RVA: 0xCE3154 Offset: 0xCE3154 VA: 0xCE3154 Slot: 10
	// public override bool GIDDKGMPIOK(int GHBPLHBNMBK) { }

	// // RVA: 0xCE3474 Offset: 0xCE3474 VA: 0xCE3474 Slot: 28
	// public override long FBGDBGKNKOD() { }

	// // RVA: 0xCE3480 Offset: 0xCE3480 VA: 0xCE3480 Slot: 30
	protected override bool JIHMLILFOPG(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if(db != null)
		{
			TodoLogger.Log(0, "AMLGMLNGMFB_EventAprilFool.JIHMLILFOPG");
		}
		return false;
	}

	// // RVA: 0xCE368C Offset: 0xCE368C VA: 0xCE368C Slot: 31
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
		TodoLogger.Log(0, "AMLGMLNGMFB_EventAprilFool.IMCMNOPNGHO");
		return false;
	}

	// // RVA: 0xCE3B0C Offset: 0xCE3B0C VA: 0xCE3B0C Slot: 40
	// protected override void KKFLDCBHFJA(long JHNMKKNEENE) { }

	// // RVA: 0xCE3ED0 Offset: 0xCE3ED0 VA: 0xCE3ED0 Slot: 46
	protected override void PJDGDNJNCNM(long JHNMKKNEENE)
	{
		TodoLogger.Log(0, "PJDGDNJNCNM");
	}

	// // RVA: 0xCE40BC Offset: 0xCE40BC VA: 0xCE40BC Slot: 27
	// public override int HLOGNJNGDJO(int OIPCCBHIKIA = 0) { }

	// // RVA: 0xCE4258 Offset: 0xCE4258 VA: 0xCE4258 Slot: 70
	// public override void ADACMHAHHKC(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BB91C Offset: 0x6BB91C VA: 0x6BB91C
	// // RVA: 0xCE42B0 Offset: 0xCE42B0 VA: 0xCE42B0
	// private IEnumerator NJIEIJJMAHK(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0xCE4390 Offset: 0xCE4390 VA: 0xCE4390
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int PPFNGGCBJKC_Id) { }

	// // RVA: 0xCE4488 Offset: 0xCE4488 VA: 0xCE4488 Slot: 33
	// public override bool MPMKJNJGFEF() { }

	// // RVA: 0xCE4490 Offset: 0xCE4490 VA: 0xCE4490 Slot: 69
	// public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0xCE45B8 Offset: 0xCE45B8 VA: 0xCE45B8 Slot: 71
	// public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO) { }

	// // RVA: 0xCE4738 Offset: 0xCE4738 VA: 0xCE4738 Slot: 72
	// public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO) { }

	// // RVA: 0xCE48B8 Offset: 0xCE48B8 VA: 0xCE48B8 Slot: 38
	// public override void EMEPJNLHJHJ(int GJEADBKFAPA, int AKNELONELJK, bool GIKLNODJKFK, ref int APMGOLOPLFP, ref int FBBDNLAMPMH) { }

	// // RVA: 0xCE4B1C Offset: 0xCE4B1C VA: 0xCE4B1C Slot: 60
	// public override bool PIBDBIKJKLD() { }

	// // RVA: 0xCE4D44 Offset: 0xCE4D44 VA: 0xCE4D44 Slot: 61
	// public override bool EMNKNFNKPAD(bool JKDJCFEBDHC) { }

	// // RVA: 0xCE4FB0 Offset: 0xCE4FB0 VA: 0xCE4FB0 Slot: 62
	// public override bool MPJIJMMOHDM() { }

	// // RVA: 0xCE520C Offset: 0xCE520C VA: 0xCE520C Slot: 64
	// public override int IBFAJICMLGF() { }

	// // RVA: 0xCE5280 Offset: 0xCE5280 VA: 0xCE5280
	// public int HLPEBPOPCPI() { }

	// // RVA: 0xCE52F4 Offset: 0xCE52F4 VA: 0xCE52F4 Slot: 26
	// public override bool KKFEDJNIAAG(long JHNMKKNEENE) { }

	// // RVA: 0xCE5598 Offset: 0xCE5598 VA: 0xCE5598
	// public void LEGMNFOCKGE(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BB994 Offset: 0x6BB994 VA: 0x6BB994
	// // RVA: 0xCE55F0 Offset: 0xCE55F0 VA: 0xCE55F0
	// private IEnumerator JCEFGGHMAGK(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0xCE56D0 Offset: 0xCE56D0 VA: 0xCE56D0
	// public List<CEBFFLDKAEC> LANDONNJDEA() { }

	// // RVA: 0xCE5928 Offset: 0xCE5928 VA: 0xCE5928
	// public void ALEPIOKNOCL() { }

	// // RVA: 0xCE39F0 Offset: 0xCE39F0 VA: 0xCE39F0
	// public void OAFLKGCGEOA(bool NLNNKIKIPBJ) { }

	// // RVA: 0xCE59C0 Offset: 0xCE59C0 VA: 0xCE59C0 Slot: 21
	// public override void CNPHACDBLMD(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0xCE6138 Offset: 0xCE6138 VA: 0xCE6138
	// public List<AMLGMLNGMFB.FOFMLBPMIIC> KLJKKJLFPDF() { }

	// // RVA: 0xCE68E8 Offset: 0xCE68E8 VA: 0xCE68E8
	// public AMLGMLNGMFB.OLDLIIKHDKD PBPJDMGEMAO(long JHNMKKNEENE) { }

	// // RVA: 0xCE6E64 Offset: 0xCE6E64 VA: 0xCE6E64
	// public FMFBNHLMHPL.LCFOEDLCCON NDNDIAFEBFJ() { }

	// // RVA: 0xCE70A8 Offset: 0xCE70A8 VA: 0xCE70A8 Slot: 73
	public override List<string> IJCPBPFEGDM(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI);
		if(dbSection == null)
			return null;
		TodoLogger.Log(0, "AMLGMLNGMFB_EventAprilFool.IJCPBPFEGDM");
		return null;
	}

	// // RVA: 0xCE746C Offset: 0xCE746C VA: 0xCE746C Slot: 74
	// public override int EDNMFMBLCGF() { }

	// // RVA: 0xCE73F8 Offset: 0xCE73F8 VA: 0xCE73F8
	// public int NDIILFIFCDL() { }

	// // RVA: 0xCE7634 Offset: 0xCE7634 VA: 0xCE7634
	// public void LPFLADBKPNL(AMLGMLNGMFB.JPGMKBANFGF OMNOFMEBLAD, bool IKGLAFOHGDO) { }
}
