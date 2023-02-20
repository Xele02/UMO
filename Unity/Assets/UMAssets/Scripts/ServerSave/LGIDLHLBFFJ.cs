
using System.Collections.Generic;

[System.Obsolete("Use LGIDLHLBFFJ_MonthlyPass", true)]
public class LGIDLHLBFFJ { }
public class LGIDLHLBFFJ_MonthlyPass : KLFDBFMNLBL_ServerSaveBlock
{
	public class LCDJCBAPAML
	{
		public long OILIPGICBIK; // 0x8
		public long NJKMDELFJGE; // 0x10
		public long AOMKDIEDDHH; // 0x18
		public long LFCBBOPEGDP; // 0x20
		public long GDKODEGAAPA; // 0x28
		public long CBGEGLCNOLB; // 0x30
		public int EHOIENNDEDH; // 0x38
		public int INCHFKJOIEK; // 0x3C

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; INCHFKJOIEK = value; } } //0x17F12D0 DEMEPMAEJOO 0x17F1368 HIGKAIDMOKN
		public long FDFGEMODIIF { get { return OILIPGICBIK ^ BBEGLBMOBOF; } set { OILIPGICBIK = value ^ BBEGLBMOBOF; LFCBBOPEGDP = value; } } //0x17F1408 CBDHPDMLJKB 0x17F14A4 OPBOAMBLLDF
		public long NKMNFPMMJND { get { return NJKMDELFJGE ^ BBEGLBMOBOF; } set { NJKMDELFJGE = value ^ BBEGLBMOBOF; GDKODEGAAPA = value; } } //0x17F154C JCDIJBHKGMA 0x17F15E8 FDMBGEAJNPK
		public long EMOHDABPCHD { get { return AOMKDIEDDHH ^ BBEGLBMOBOF; } set { AOMKDIEDDHH = value ^ BBEGLBMOBOF; CBGEGLCNOLB = value; } } //0x17F1690 KNPJCIBDBJC 0x17F172C BDFIIDDKKCE

		//// RVA: 0x17F17D4 Offset: 0x17F17D4 VA: 0x17F17D4
		public void LHPDDGIJKNB(int PPFNGGCBJKC)
		{
			this.PPFNGGCBJKC = PPFNGGCBJKC;
			FDFGEMODIIF = 0;
			NKMNFPMMJND = 0;
			EMOHDABPCHD = 0;
		}

		//// RVA: 0x17F1820 Offset: 0x17F1820 VA: 0x17F1820
		//public bool AGBOGBEOFME(LGIDLHLBFFJ.LCDJCBAPAML OIKJFMGEICL) { }

		//// RVA: 0x17F1940 Offset: 0x17F1940 VA: 0x17F1940
		//public void ODDIHGPONFL(LGIDLHLBFFJ.LCDJCBAPAML GPBJHKLFCEP) { }

		//// RVA: 0x17F1A20 Offset: 0x17F1A20 VA: 0x17F1A20
		//public bool CHFOOMPEABN() { }

		//// RVA: 0x17F1A64 Offset: 0x17F1A64 VA: 0x17F1A64
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, LGIDLHLBFFJ.LCDJCBAPAML OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}
	
	public class ODHIHCNALDL
	{
		private List<long> GIJFDNOIHCL = new List<long>(20); // 0x8
		public int JJPDPNJFBHN; // 0xC
		public long MMPCPKODGKI; // 0x10

		// RVA: 0x17F2BF0 Offset: 0x17F2BF0 VA: 0x17F2BF0
		public void LHPDDGIJKNB()
		{
			GIJFDNOIHCL.Clear();
			for(int i = 0; i < 20; i++)
			{
				GIJFDNOIHCL.Add(BBEGLBMOBOF);
			}
			JJPDPNJFBHN = 0;
			MMPCPKODGKI = 0;
		}

		// RVA: 0x17F2D10 Offset: 0x17F2D10 VA: 0x17F2D10
		//public long LPGIECKPBDK(int OIPCCBHIKIA) { }

		// RVA: 0x17F11F0 Offset: 0x17F11F0 VA: 0x17F11F0
		//public void ACCIBAABEPN(int OIPCCBHIKIA, long JGNBPFCJLKI) { }

		// RVA: 0x17F2DE4 Offset: 0x17F2DE4 VA: 0x17F2DE4
		//public bool AGBOGBEOFME(LGIDLHLBFFJ.ODHIHCNALDL OIKJFMGEICL) { }

		// RVA: 0x17F2E68 Offset: 0x17F2E68 VA: 0x17F2E68
		//public void ODDIHGPONFL(LGIDLHLBFFJ.ODHIHCNALDL GPBJHKLFCEP) { }

		// RVA: 0x17F2EE8 Offset: 0x17F2EE8 VA: 0x17F2EE8
		//public bool CHFOOMPEABN() { }

		// RVA: 0x17F2FA0 Offset: 0x17F2FA0 VA: 0x17F2FA0
		//public int KNIOACKGGHI() { }

		// RVA: 0x17F3048 Offset: 0x17F3048 VA: 0x17F3048
		//public bool NFOKMHEIMBI() { }

		// RVA: 0x17F30F0 Offset: 0x17F30F0 VA: 0x17F30F0
		//public void DOMFHDPMCCO(int BIHELPHMCCA, long EOLFJGMAJAB) { }

		// RVA: 0x17F31B0 Offset: 0x17F31B0 VA: 0x17F31B0
		//public EDOHBJAPLPF OKJPIBHMKMJ() { }

		// RVA: 0x17F33A0 Offset: 0x17F33A0 VA: 0x17F33A0
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, LGIDLHLBFFJ.ODHIHCNALDL OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int KCFBAOJKKHH = 2;
	public const int JOMJMHGMGFO = 20;
	public const int GIDIDCDCDEM = 2;
	public static string POFDDFCGEGP = "_"; // 0x0
	public static int FBGGEFFJJHB = 0x1741f74; // 0x4
	public static long BBEGLBMOBOF = 0x725731f; // 0x8
	public const int BNLBENOIHAO = 31;
	public const int HMAMANIPLCD = 99;
	private int HCPMMDELCDC; // 0x24
	private int CDKBOHDFJKG; // 0x28
	private int AFMHNALKGNC; // 0x2C
	private int PLPIEGNDIGG; // 0x30
	private int KJDIBKHGMKO; // 0x34
	private int POAGOKLJCNF; // 0x38
	private int PHJODLGIEJA; // 0x3C
	private int JJCMEHFOCED; // 0x40
	private int CEFBCMKNPKB; // 0x44
	private long FLMJPPIPMGP; // 0x48
	private long FDGICFBLMKO; // 0x50
	public int KJBOIGIDKIF; // 0x58
	public int PMCKOEGANFB; // 0x5C
	public int MPLPHLAHJOC; // 0x60
	public List<LCDJCBAPAML> FMPLMFLMJNE; // 0x64
	public List<LCDJCBAPAML> DNKJAIHCDFN; // 0x68
	public List<LCDJCBAPAML> AOHBAOAPGDM; // 0x6C
	public NNJFKLBPBNK_SecureString CPENFPEPDFC; // 0x70
	public NNJFKLBPBNK_SecureString BPMLNLPDCAJ; // 0x74
	public List<ODHIHCNALDL> EOHPPNNLBNH; // 0x78

	public int PCBLFLDMCJA { get { return HCPMMDELCDC ^ FBGGEFFJJHB; } set { HCPMMDELCDC = value ^ FBGGEFFJJHB; } } // CJPCEIPEIOB 0xD8403C GIJHJLEGKPG 0xD840D4
	public int FADAJDBCBJK { get { return CDKBOHDFJKG ^ FBGGEFFJJHB; } set { CDKBOHDFJKG = value ^ FBGGEFFJJHB; } } // FHNELMGCLLA 0xD84170 AKFPDEMMBKM 0xD84208
	public int FLBJKACKNOI { get { return AFMHNALKGNC ^ FBGGEFFJJHB; } set { AFMHNALKGNC = value ^ FBGGEFFJJHB; } } //CPKDPLPJIMI 0xD842A4 NBMJIIHOMHH 0xD8433C
	public int FCPHDFKFDCK { get { return PLPIEGNDIGG ^ FBGGEFFJJHB; } set { PLPIEGNDIGG = value ^ FBGGEFFJJHB; KJDIBKHGMKO = value; } } // EKJKOALHDAH 0xD843D8  BLKCKIEOFOH 0xD84470
	public int HKABHJKHFKL { get { return POAGOKLJCNF ^ FBGGEFFJJHB; } set { POAGOKLJCNF = value ^ FBGGEFFJJHB; PHJODLGIEJA = value; } } //IDKLGKKOHII 0xD84510 LHCMKDALNEE 0xD845A8
	public int JAMCDEDFHHK { get { return JJCMEHFOCED ^ FBGGEFFJJHB; } set { JJCMEHFOCED = value ^ FBGGEFFJJHB; CEFBCMKNPKB = value; } } //CHGOJFDDCEG 0xD84648 ABJLDAFNEOJ 0xD846E0
	public long BKONHFNBHKL { get { return FLMJPPIPMGP ^ BBEGLBMOBOF; } set { FLMJPPIPMGP = value ^ BBEGLBMOBOF; FDGICFBLMKO = value; } } //ADJIEHKCCCN 0xD84780 CPDDIJHNBCJ 0xD8481C
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0xD848C8 Offset: 0xD848C8 VA: 0xD848C8
	// public KBCCGHLCFNO.JKGFAIPDNDL LOGJJALCFPF() { }

	// // RVA: 0xD84C84 Offset: 0xD84C84 VA: 0xD84C84
	// public int PKGCIBGBAOO() { }

	// // RVA: 0xD84E34 Offset: 0xD84E34 VA: 0xD84E34
	// public int HGEJHKCHBNB() { }

	// // RVA: 0xD84F68 Offset: 0xD84F68 VA: 0xD84F68
	// public int HEOIMMMJKIP() { }

	// // RVA: 0xD85094 Offset: 0xD85094 VA: 0xD85094
	// public KBCCGHLCFNO.JKGFAIPDNDL ECBMDDGPKGN() { }

	// // RVA: 0xD8528C Offset: 0xD8528C VA: 0xD8528C
	// public void AFGLHGNKOFC() { }

	// // RVA: 0xD85444 Offset: 0xD85444 VA: 0xD85444
	// public int AIGKHDMFFMO() { }

	// // RVA: 0xD8547C Offset: 0xD8547C VA: 0xD8547C
	// public int ACPKOAAPHJM() { }

	// // RVA: 0xD855BC Offset: 0xD855BC VA: 0xD855BC
	// public bool HMAHFMHPBBC() { }

	// // RVA: 0xD85708 Offset: 0xD85708 VA: 0xD85708
	// public KBCCGHLCFNO.JKGFAIPDNDL BGANHMCJIIC() { }

	// // RVA: 0xD85AA4 Offset: 0xD85AA4 VA: 0xD85AA4
	// public bool MBPPILOJOBK(int LJACHJCFMJH) { }

	// // RVA: 0xD85AC4 Offset: 0xD85AC4 VA: 0xD85AC4
	// public void HAEOIGABDDM(int LJACHJCFMJH) { }

	// // RVA: 0xD85B00 Offset: 0xD85B00 VA: 0xD85B00
	// public void DGIBOADNFOI(int ADPPAIPFHML) { }

	// // RVA: 0xD85B2C Offset: 0xD85B2C VA: 0xD85B2C
	public LGIDLHLBFFJ_MonthlyPass()
	{
		FMPLMFLMJNE = new List<LCDJCBAPAML>();
		DNKJAIHCDFN = new List<LCDJCBAPAML>();
		AOHBAOAPGDM = new List<LCDJCBAPAML>();
		CPENFPEPDFC = new NNJFKLBPBNK_SecureString();
		BPMLNLPDCAJ = new NNJFKLBPBNK_SecureString();
		EOHPPNNLBNH = new List<ODHIHCNALDL>(2);
		KMBPACJNEOF();
	}

	// // RVA: 0xD85C70 Offset: 0xD85C70 VA: 0xD85C70 Slot: 4
	public override void KMBPACJNEOF()
	{
		PCBLFLDMCJA = 0;
		FADAJDBCBJK = 0;
		FLBJKACKNOI = 0;
		FCPHDFKFDCK = 0;
		HKABHJKHFKL = 0;
		JAMCDEDFHHK = 0;
		KJBOIGIDKIF = 0;
		PMCKOEGANFB = 0;
		MPLPHLAHJOC = 0;
		BKONHFNBHKL = 0;
		BPMLNLPDCAJ.DNJEJEANJGL_Value = "";
		CPENFPEPDFC.DNJEJEANJGL_Value = "";
		FMPLMFLMJNE.Clear();
		DNKJAIHCDFN.Clear();
		for(int i = 0; i < 2; i++)
		{
			LCDJCBAPAML data = new LCDJCBAPAML();
			data.LHPDDGIJKNB(i + 1);
			FMPLMFLMJNE.Add(data);
		}
		for(int i = 0; i < 2; i++)
		{
			LCDJCBAPAML data = new LCDJCBAPAML();
			data.LHPDDGIJKNB(i + 1);
			DNKJAIHCDFN.Add(data);
		}
		for(int i = 0; i < 2; i++)
		{
			LCDJCBAPAML data = new LCDJCBAPAML();
			data.LHPDDGIJKNB(i + 1);
			AOHBAOAPGDM.Add(data);
		}
		EOHPPNNLBNH.Clear();
		for(int i = 0; i < 2; i++)
		{
			ODHIHCNALDL data = new ODHIHCNALDL();
			data.LHPDDGIJKNB();
			EOHPPNNLBNH.Add(data);
		}
	}

	// // RVA: 0xD86020 Offset: 0xD86020 VA: 0xD86020 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0xD87544 Offset: 0xD87544 VA: 0xD87544 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0xD88AD4 Offset: 0xD88AD4 VA: 0xD88AD4 Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0xD89128 Offset: 0xD89128 VA: 0xD89128 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0xD897EC Offset: 0xD897EC VA: 0xD897EC Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0xD8A954 Offset: 0xD8A954 VA: 0xD8A954 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(0, "TODO");
		return null;
	}

	// // RVA: 0xD8AC0C Offset: 0xD8AC0C VA: 0xD8AC0C Slot: 9
	// public override bool NFKFOODCJJB() { }

	// // RVA: 0xD8AC14 Offset: 0xD8AC14 VA: 0xD8AC14
	// public string POGHKGLHHFL() { }

	// // RVA: 0xD8AC40 Offset: 0xD8AC40 VA: 0xD8AC40
	// public string KIHJLOGLAGI() { }
}
