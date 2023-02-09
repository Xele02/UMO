
using System.Collections.Generic;
using XeApp.Game.Common;

[System.Obsolete("Use ALJHJDHNFFB_HomeBg", true)]
public class ALJHJDHNFFB { }
public class ALJHJDHNFFB_HomeBg : DIHHCBACKGG_DbSection
{
	public class ADLLAFIDFAM
	{
		public int EHOIENNDEDH; // 0x8
		public int NOFECLGOLAI; // 0xC
		public int BMMPCNHLGOA; // 0x10
		public int HKCDOJFHMFC; // 0x14
		public long PCLNFCNIECH; // 0x18
		public long HHPIJHADAOB; // 0x20
		public int HNJHPNPFAAN; // 0x28
		public int GNGNIKNNCNH; // 0x2C
		public int NJPJGPGNAOG; // 0x30
		public NNJFKLBPBNK_SecureString FINCFIGKHPA = new NNJFKLBPBNK_SecureString(); // 0x38

		//public int PPFNGGCBJKC { get; set; } 0xCDF86C DEMEPMAEJOO 0xCDE414 HIGKAIDMOKN
		//public int GBJFNGCDKPM { get; set; } 0xCDF970 CEJJMKODOGK 0xCDE4B0 HOHCEBMMACI
		//public int OENPCNBFPDA { get; set; } 0xCDFA08 BNLALNCFJPB 0xCDE54C KPJBLJCKBLF
		//public int KFNDHKFLPPK { get; set; } 0xCDFAA0 CCPAPHPPGOB 0xCDE5E8 ICBGFBNICOE
		//public long PDBPFJJCADD { get; set; } 0xCDF69C FOACOMBHPAC 0xCDE684 NBACOBCOJCA
		//public long FDBNFFNFOND { get; set; } 0xCDF7D0 BPJOGHJCLDJ 0xCDE728 NLJKMCHOCBK
		//public int PLALNIIBLOF { get; set; } 0xCDF738 JPCJNLHHIPE 0xCDE7CC JJFJNEJLBDG
		//public int IJEKNCDIIAE { get; set; } 0xCDFB38 KJIMMIBDCIL 0xCDE868 DMEGNOKIKCD
		//public string OPFGFINHFCE { get; set; } 0xCDFBD0 DKJOHDGOIJE 0xCDE9A8 MJAMIGECMMF
		//public int LEJOJFHKHIJ { get; set; } 0xCDFBFC PGCOGCIHNGG 0xCDE904 PJDCNPKFOBE
		public SeriesAttr.Type AIHCEGFANAM { get; set; } // 0x34 FJOGAAMLJMA ANEJPLENMAL HEHDOGFEIOL

		//// RVA: 0xCDF06C Offset: 0xCDF06C VA: 0xCDF06C
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB = 0x609d5; // 0x0
	public const int GHGNOHPLBPF = 100;
	public List<ADLLAFIDFAM> CDENCMNHNGA = new List<ADLLAFIDFAM>(); // 0x20

	// RVA: 0xCDDD80 Offset: 0xCDDD80 VA: 0xCDDD80
	public ALJHJDHNFFB_HomeBg()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 53;
	}

	//// RVA: 0xCDDE74 Offset: 0xCDDE74 VA: 0xCDDE74
	//public ALJHJDHNFFB.ADLLAFIDFAM GCINIJEMHFK(int PPFNGGCBJKC) { }

	// RVA: 0xCDDF3C Offset: 0xCDDF3C VA: 0xCDDF3C Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0xCDDFB4 Offset: 0xCDDFB4 VA: 0xCDDFB4 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "ALJHJDHNFFB_HomeBg.KMBPACJNEOF");
		return true;
	}

	// RVA: 0xCDE9DC Offset: 0xCDE9DC VA: 0xCDE9DC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "ALJHJDHNFFB_HomeBg.KMBPACJNEOF");
		return true;
	}

	// RVA: 0xCDEF88 Offset: 0xCDEF88 VA: 0xCDEF88 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "ALJHJDHNFFB_HomeBg.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0xCDF0F0 Offset: 0xCDF0F0 VA: 0xCDF0F0
	//public ALJHJDHNFFB.ADLLAFIDFAM NLPKHJDEDPI(int PPFNGGCBJKC) { }

	//// RVA: 0xCDF1BC Offset: 0xCDF1BC VA: 0xCDF1BC
	//private bool OFKCGMNFGKB(long KJBGCLPMLCG, long GJFPFFBAKGK, long JHNMKKNEENE = -1) { }

	//// RVA: 0xCDF2E8 Offset: 0xCDF2E8 VA: 0xCDF2E8
	//public List<int> NIJNOFHBKEB() { }
}
