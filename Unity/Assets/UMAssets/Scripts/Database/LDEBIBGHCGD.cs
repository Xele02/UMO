
using System.Collections.Generic;

[System.Obsolete("Use LDEBIBGHCGD_EventRaidLobby", true)]
public class LDEBIBGHCGD { }
public class LDEBIBGHCGD_EventRaidLobby : DIHHCBACKGG_DbSection
{
	public class NBGDKOACGLM
	{
		public int OBGBAOLONDD; // 0x8
		public string OPFGFINHFCE; // 0xC
		public long CJPMLAIFCDL; // 0x10
		public long COIHIAKHFNF; // 0x18
		public long NIMLIMFPNJP; // 0x20
		public long KCBGBFMGHPA; // 0x28
		public int MJBKGOJBPAD; // 0x30
		public sbyte MOEKELIIDEO; // 0x34
		public int[] EJBGHLOOLBC; // 0x38

		//// RVA: 0xD65AB4 Offset: 0xD65AB4 VA: 0xD65AB4
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD66A20 Offset: 0xD66A20 VA: 0xD66A20
		//public uint CAOGDCBPBAN() { }
	}

	public class HDFAGGBJGAA
	{
		public int PPFNGGCBJKC; // 0x8
		public int AACHOBAAALA; // 0xC
		public string OPFGFINHFCE; // 0x10
		public string HEDAGCNPHGD; // 0x14
		public List<int> OCDBMHBNLEF; // 0x18

		// RVA: 0xD664B0 Offset: 0xD664B0 VA: 0xD664B0
		//public void .ctor(int OIPCCBHIKIA, BFOKFIJNCJJ IDLHJIOMJBK) { }

		//// RVA: 0xD66ADC Offset: 0xD66ADC VA: 0xD66ADC
		//public uint CAOGDCBPBAN() { }
	}

	public class LNECBHIKKHK
	{
		public int PPFNGGCBJKC; // 0x8
		public int GJNIPHMPMIC; // 0xC
		public int INDDJNMPONH; // 0x10
		public int FDBOPFEOENF; // 0x14
		public int MJMPANIBFED; // 0x18
		public string LICPCDCLOIO; // 0x1C

		//// RVA: 0xD666C8 Offset: 0xD666C8 VA: 0xD666C8
		//public void .ctor(PALCPDPGOPC IDLHJIOMJBK) { }

		//// RVA: 0xD66BB8 Offset: 0xD66BB8 VA: 0xD66BB8
		//public uint CAOGDCBPBAN() { }
	}

	public NBGDKOACGLM NGHKJOEDLIP = new NBGDKOACGLM(); // 0x20
	public List<HDFAGGBJGAA> OJGPPOKENLG = new List<HDFAGGBJGAA>(); // 0x24
	public List<LNECBHIKKHK> OIIMJFCBFFG = new List<LNECBHIKKHK>(); // 0x28
	public List<AKIIJBEJOEP> NNMPGOAGEOL = new List<AKIIJBEJOEP>(); // 0x2C

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x30 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x34 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0xD65550 Offset: 0xD65550 VA: 0xD65550
	//public LDEBIBGHCGD.HDFAGGBJGAA HMHGPIEBKPO(int PPFNGGCBJKC) { }

	//// RVA: 0xD65610 Offset: 0xD65610 VA: 0xD65610
	//public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH) { }

	//// RVA: 0xD656F4 Offset: 0xD656F4 VA: 0xD656F4
	//public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH) { }

	// RVA: 0xD657D8 Offset: 0xD657D8 VA: 0xD657D8
	public LDEBIBGHCGD_EventRaidLobby()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 39;
	}

	// RVA: 0xD659C8 Offset: 0xD659C8 VA: 0xD659C8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LDEBIBGHCGD_EventRaidLobby.KMBPACJNEOF");
	}

	// RVA: 0xD65B3C Offset: 0xD65B3C VA: 0xD65B3C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LDEBIBGHCGD_EventRaidLobby.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0xD65E34 Offset: 0xD65E34 VA: 0xD65E34
	//private bool DGKKMKLCEDF(MAGFOKIIPPD KNOEHKKNIJA) { }

	//// RVA: 0xD66084 Offset: 0xD66084 VA: 0xD66084
	//private bool FOPPFILCLDJ(MAGFOKIIPPD KNOEHKKNIJA) { }

	//// RVA: 0xD661D0 Offset: 0xD661D0 VA: 0xD661D0
	//private bool JIBKOEFOAPG(MAGFOKIIPPD KNOEHKKNIJA) { }

	//// RVA: 0xD66318 Offset: 0xD66318 VA: 0xD66318
	//private bool CFOFJPLEDEA(MAGFOKIIPPD KNOEHKKNIJA) { }

	// RVA: 0xD667D0 Offset: 0xD667D0 VA: 0xD667D0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "LDEBIBGHCGD_EventRaidLobby.CAOGDCBPBAN");
		return 0;
	}
}
