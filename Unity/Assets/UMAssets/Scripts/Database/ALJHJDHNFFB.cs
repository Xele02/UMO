
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

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xCDF86C DEMEPMAEJOO 0xCDE414 HIGKAIDMOKN
		public int GBJFNGCDKPM_Typ { get { return NOFECLGOLAI ^ FBGGEFFJJHB; } set { NOFECLGOLAI = value ^ FBGGEFFJJHB; } } //0xCDF970 CEJJMKODOGK 0xCDE4B0 HOHCEBMMACI
		public int OENPCNBFPDA_BgId { get { return BMMPCNHLGOA ^ FBGGEFFJJHB; } set { BMMPCNHLGOA = value ^ FBGGEFFJJHB; } } //0xCDFA08 BNLALNCFJPB 0xCDE54C KPJBLJCKBLF
		public int KFNDHKFLPPK_MusId { get { return HKCDOJFHMFC ^ FBGGEFFJJHB; } set { HKCDOJFHMFC = value ^ FBGGEFFJJHB; } } //0xCDFAA0 CCPAPHPPGOB 0xCDE5E8 ICBGFBNICOE
		public long PDBPFJJCADD_OpenAt { get { return PCLNFCNIECH ^ FBGGEFFJJHB; } set { PCLNFCNIECH = value ^ FBGGEFFJJHB; } } //0xCDF69C FOACOMBHPAC 0xCDE684 NBACOBCOJCA
		public long FDBNFFNFOND_CloseAt { get { return HHPIJHADAOB ^ FBGGEFFJJHB; } set { HHPIJHADAOB = value ^ FBGGEFFJJHB; } } //0xCDF7D0 BPJOGHJCLDJ 0xCDE728 NLJKMCHOCBK
		public int PLALNIIBLOF_En { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0xCDF738 JPCJNLHHIPE 0xCDE7CC JJFJNEJLBDG
		public int IJEKNCDIIAE_MVer { get { return GNGNIKNNCNH ^ FBGGEFFJJHB; } set { GNGNIKNNCNH = value ^ FBGGEFFJJHB; } } //0xCDFB38 KJIMMIBDCIL 0xCDE868 DMEGNOKIKCD
		public string OPFGFINHFCE_Name { get { return FINCFIGKHPA.DNJEJEANJGL_Value; } set { FINCFIGKHPA.DNJEJEANJGL_Value = value; } } //0xCDFBD0 DKJOHDGOIJE 0xCDE9A8 MJAMIGECMMF
		public int LEJOJFHKHIJ_Have { get { return GNGNIKNNCNH ^ FBGGEFFJJHB; } set { GNGNIKNNCNH = value ^ FBGGEFFJJHB; } } //0xCDFBFC PGCOGCIHNGG 0xCDE904 PJDCNPKFOBE
		public SeriesAttr.Type AIHCEGFANAM_Sa { get; set; } // 0x34 FJOGAAMLJMA ANEJPLENMAL HEHDOGFEIOL

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
		LEGLJNFOBGN parser = LEGLJNFOBGN.HEGEKFMJNCC(DBBGALAPFGC);
		BEHPCLGJNDE[] array = parser.AFNCMAJBLGO;
		for(int i = 0; i < array.Length; i++)
		{
			ADLLAFIDFAM data = new ADLLAFIDFAM();
			data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			data.GBJFNGCDKPM_Typ = (int)array[i].GBJFNGCDKPM;
			data.OENPCNBFPDA_BgId = array[i].OENPCNBFPDA;
			data.KFNDHKFLPPK_MusId = array[i].KFNDHKFLPPK;
			data.PDBPFJJCADD_OpenAt = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND_CloseAt = array[i].FDBNFFNFOND;
			data.PLALNIIBLOF_En = (int)array[i].PLALNIIBLOF;
			data.IJEKNCDIIAE_MVer = array[i].IJEKNCDIIAE;
			data.LEJOJFHKHIJ_Have = array[i].LEJOJFHKHIJ;
			data.AIHCEGFANAM_Sa = (SeriesAttr.Type)array[i].JPFMJHLCMJL;
			data.OPFGFINHFCE_Name = array[i].OPFGFINHFCE;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0xCDE9DC Offset: 0xCDE9DC VA: 0xCDE9DC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.Database, "ALJHJDHNFFB_HomeBg.KMBPACJNEOF");
		return true;
	}

	// RVA: 0xCDEF88 Offset: 0xCDEF88 VA: 0xCDEF88 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "ALJHJDHNFFB_HomeBg.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0xCDF0F0 Offset: 0xCDF0F0 VA: 0xCDF0F0
	public ADLLAFIDFAM NLPKHJDEDPI(int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC > 0)
		{
			if (PPFNGGCBJKC - 1 < CDENCMNHNGA.Count)
			{
				return CDENCMNHNGA[PPFNGGCBJKC - 1];
			}
		}
		return null;
	}

	//// RVA: 0xCDF1BC Offset: 0xCDF1BC VA: 0xCDF1BC
	private bool OFKCGMNFGKB_IsTimeValid(long KJBGCLPMLCG, long GJFPFFBAKGK, long JHNMKKNEENE = -1)
	{
		if(JHNMKKNEENE < 0)
			JHNMKKNEENE = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		return JHNMKKNEENE >= KJBGCLPMLCG && GJFPFFBAKGK >= JHNMKKNEENE;
	}

	//// RVA: 0xCDF2E8 Offset: 0xCDF2E8 VA: 0xCDF2E8
	public List<int> NIJNOFHBKEB_GetAvaiableBgs()
	{
		List<int> res = new List<int>();
		res.Clear();
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < CDENCMNHNGA.Count; i++)
		{
			if(CDENCMNHNGA[i].PDBPFJJCADD_OpenAt != 0)
			{
				if(CDENCMNHNGA[i].PLALNIIBLOF_En == 2)
				{
					if(OFKCGMNFGKB_IsTimeValid(CDENCMNHNGA[i].PDBPFJJCADD_OpenAt, CDENCMNHNGA[i].FDBNFFNFOND_CloseAt, time))
					{
						res.Add(CDENCMNHNGA[i].PPFNGGCBJKC_Id);
					}
				}
			}
		}
		return res;
	}
}
