
[System.Obsolete("Use FNBIIGJJGKA_Counter", true)]
public class FNBIIGJJGKA {}
public class FNBIIGJJGKA_Counter : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	private const int MKINOABMBGM = 20;
	private const int FOBFLHIIJOM = 100;
	private const int PNFLFNNAAPL = 5;
	private const long EBABKJBHKDF = 9999999999;
	private const long GKIALDDPKNF = 99999;
	private const int AFHHHFICNIN = 12;
	public OHDCBNFDHLA EJFAEKPGKNJ; // 0x24
	public NAKMCMEPAGH BDLNMOIOMHK; // 0x28
	public byte[] NONMPJBNBNN = new byte[300]; // 0x2C
	public byte[] CFHOMPIKIGK = new byte[300]; // 0x30
	public byte[] NDBEHBMEGGI = new byte[300]; // 0x34
	public byte[] DNKKDCHJJHF = new byte[300]; // 0x38
	public long[] NJIDHLPGBFO = new long[5]; // 0x3C
	public long PCBJHBCNNGD; // 0x40

	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x119E81C Offset: 0x119E81C VA: 0x119E81C
	// public void BEJONIOEGCI(int DLAEJOBELBH_Id, int AKNELONELJK, bool BCGLDMKODLC, bool NANEGCHBEDN, List<int> PGPBALKFBNK, bool PMCGHPOGLGM, bool GIKLNODJKFK = False) { }

	// // RVA: 0x119EAD0 Offset: 0x119EAD0 VA: 0x119EAD0
	// private int GMKMEENIJFK(byte[] IDLHJIOMJBK, int AKNELONELJK) { }

	// // RVA: 0x119EB44 Offset: 0x119EB44 VA: 0x119EB44
	// public int MOEJDCPHJOH(int AKNELONELJK) { }

	// // RVA: 0x119EB50 Offset: 0x119EB50 VA: 0x119EB50
	// public int DGKBOGGIAKD(int AKNELONELJK) { }

	// // RVA: 0x119EB5C Offset: 0x119EB5C VA: 0x119EB5C
	// public int AMIPHDGAMLI(int AKNELONELJK) { }

	// // RVA: 0x119EB68 Offset: 0x119EB68 VA: 0x119EB68
	// public int CEPBENFKMFF(int AKNELONELJK) { }

	// // RVA: 0x119EB74 Offset: 0x119EB74 VA: 0x119EB74
	public FNBIIGJJGKA_Counter()
	{
		EJFAEKPGKNJ = new OHDCBNFDHLA();
		BDLNMOIOMHK = new NAKMCMEPAGH();
		KMBPACJNEOF();
	}

	// // RVA: 0x119EC90 Offset: 0x119EC90 VA: 0x119EC90 Slot: 4
	public override void KMBPACJNEOF()
	{
		EJFAEKPGKNJ.LHPDDGIJKNB();
		BDLNMOIOMHK.LHPDDGIJKNB();
		for(int i = 0; i < 300; i++)
		{
			NONMPJBNBNN[i] = 0;
			CFHOMPIKIGK[i] = 0;
			NDBEHBMEGGI[i] = 0;
			DNKKDCHJJHF[i] = 0;
		}
		for(int i = 0; i < 5; i++)
		{
			NJIDHLPGBFO[i] = 0;
		}
		PCBJHBCNNGD = 0;
	}

	// // RVA: 0x119EE28 Offset: 0x119EE28 VA: 0x119EE28 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x11A05F4 Offset: 0x11A05F4 VA: 0x11A05F4 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName)) // counter
		{
			if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BDLNMOIOMHK_total/*total*/))
			{
				bool b = true;
				EDOHBJAPLPF_JsonData jsonData = OILEIIEIBHP[AFEHLCGHAEE_Strings.BDLNMOIOMHK_total/*total*/];
				BDLNMOIOMHK.EDLBLCGHECJ = CJAENOMGPDA_ReadInt(jsonData, "max", 0, ref b);
			}
		}
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0x11A1E0C Offset: 0x11A1E0C VA: 0x11A1E0C Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x11A21D0 Offset: 0x11A21D0 VA: 0x11A21D0 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x11A25E8 Offset: 0x11A25E8 VA: 0x11A25E8 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x11A3920 Offset: 0x11A3920 VA: 0x11A3920 Slot: 9
	// public override bool NFKFOODCJJB() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BED74 Offset: 0x6BED74 VA: 0x6BED74
	// // RVA: 0x11A3928 Offset: 0x11A3928 VA: 0x11A3928
	// private void <Deserialize>b__24_0(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BED84 Offset: 0x6BED84 VA: 0x6BED84
	// // RVA: 0x11A3988 Offset: 0x11A3988 VA: 0x11A3988
	// private void <Deserialize>b__24_1(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BED94 Offset: 0x6BED94 VA: 0x6BED94
	// // RVA: 0x11A39E8 Offset: 0x11A39E8 VA: 0x11A39E8
	// private void <Deserialize>b__24_2(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BEDA4 Offset: 0x6BEDA4 VA: 0x6BEDA4
	// // RVA: 0x11A3A48 Offset: 0x11A3A48 VA: 0x11A3A48
	// private void <Deserialize>b__24_3(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BEDB4 Offset: 0x6BEDB4 VA: 0x6BEDB4
	// // RVA: 0x11A3AA8 Offset: 0x11A3AA8 VA: 0x11A3AA8
	// private void <Deserialize>b__24_4(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BEDC4 Offset: 0x6BEDC4 VA: 0x6BEDC4
	// // RVA: 0x11A3B08 Offset: 0x11A3B08 VA: 0x11A3B08
	// private void <Deserialize>b__24_5(int OIPCCBHIKIA, int JBGEEPFKIGG) { }
}

public class OHDCBNFDHLA
{
	private const int MNHALNODIPI = 99999999;
	public long BEBJKJKBOGH; // 0x8
	public int MILCBLJDADN; // 0x10
	public int[] GEIONHDKGEB = new int[5]; // 0x14
	public int NDNHHGJKJGM; // 0x18
	public int GACBDCLPOCD; // 0x1C
	public int MPHFGEPJOGL; // 0x20

	//public long AAFMGJHLLCD { get; } 0x1DE0750 KMKOHJDPKGL

	//// RVA: 0x1DE0894 Offset: 0x1DE0894 VA: 0x1DE0894
	//public void FHPENOLOPKI(long JHNMKKNEENE, bool FBBNPFFEJBN) { }

	//// RVA: 0x1DE0948 Offset: 0x1DE0948 VA: 0x1DE0948
	//public void FBKAPLHEACL() { }

	//// RVA: 0x1DE0964 Offset: 0x1DE0964 VA: 0x1DE0964
	//public void DPKJNIPGGMJ(int FJOLNJLLJEJ) { }

	//// RVA: 0x1DE0A00 Offset: 0x1DE0A00 VA: 0x1DE0A00
	//public void BFAJMALBALG(int HMFFHLPNMPH) { }

	//// RVA: 0x1DE0A20 Offset: 0x1DE0A20 VA: 0x1DE0A20
	//public void MAFAKCMFHEE() { }

	//// RVA: 0x1DE0A40 Offset: 0x1DE0A40 VA: 0x1DE0A40
	//public void CIGILPOKMAN(int HMFFHLPNMPH) { }

	//// RVA: 0x1DE0A60 Offset: 0x1DE0A60 VA: 0x1DE0A60
	public void LHPDDGIJKNB()
	{
		BEBJKJKBOGH = 0;
		MILCBLJDADN = 0;
		for(int i = 0; i < GEIONHDKGEB.Length; i++)
		{
			GEIONHDKGEB[i] = 0;
		}
		NDNHHGJKJGM = 0;
		GACBDCLPOCD = 0;
		MPHFGEPJOGL = 0;
	}

	//// RVA: 0x1DE0AF4 Offset: 0x1DE0AF4 VA: 0x1DE0AF4
	//public bool AGBOGBEOFME(OHDCBNFDHLA OIKJFMGEICL) { }

	//// RVA: 0x1DE0CD4 Offset: 0x1DE0CD4 VA: 0x1DE0CD4
	//public void ODDIHGPONFL(OHDCBNFDHLA GPBJHKLFCEP) { }

	//// RVA: 0x1DE0E1C Offset: 0x1DE0E1C VA: 0x1DE0E1C
	//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, OHDCBNFDHLA OHMCIEMIKCE, bool EFOEPDLNLJG) { }
}
