
using System.Collections.Generic;

[System.Obsolete("Use HIHJGPDLNDN_EventScore", true)]
public class HIHJGPDLNDN { }
public class HIHJGPDLNDN_EventScore : DIHHCBACKGG_DbSection
{
	public class DKGDLFPELAB
	{
		public int OBGBAOLONDD; // 0x8
		public string OPFGFINHFCE; // 0xC
		public string HEDAGCNPHGD; // 0x10
		public string OCGFKMHNEOF; // 0x14
		public long BONDDBOFBND; // 0x18
		public long HPNOGLIFJOP; // 0x20
		public long LNFKGHNHJKE; // 0x28
		public long JGMDAOACOJF; // 0x30
		public long IDDBFFBPNGI; // 0x38
		public long KNLGKBBIBOH; // 0x40
		public int KHIKEGLBGAF; // 0x48
		public sbyte POGEFBMBPCB; // 0x4C
		public sbyte AHKNMANFILO; // 0x4D
		public sbyte MOEKELIIDEO; // 0x4E
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO = new NNJFKLBPBNK_SecureString(); // 0x50
		public sbyte AHKPNPNOAMO; // 0x54
		public sbyte HKKNEAGCIEB; // 0x55
		public List<int> CAPAPAABKDP = new List<int>(); // 0x58
		public List<int> JHPCPNJJHLI = new List<int>(); // 0x5C

		//public string OCDMGOGMHGE { get; set; } 0x18373A0 HBAAAKFHDBB 0x1836DF4 NHJLJOIPOFK

		//// RVA: 0x1835DA8 Offset: 0x1835DA8 VA: 0x1835DA8
		//public void LHPDDGIJKNB() { }

		//// RVA: 0x18371D4 Offset: 0x18371D4 VA: 0x18371D4
		//public uint CAOGDCBPBAN() { }
	}

	public class AAAPPIKNOKB
	{
		public int PPFNGGCBJKC; // 0x8
		public int KFCIJBLDHOK; // 0xC
		public int JLEIHOEGMOP; // 0x10
	}

	public DKGDLFPELAB NGHKJOEDLIP = new DKGDLFPELAB(); // 0x20
	public List<AAAPPIKNOKB> ADPFKHEMNBL = new List<AAAPPIKNOKB>(); // 0x2C

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x28 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x18358DC Offset: 0x18358DC VA: 0x18358DC
	//public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH) { }

	//// RVA: 0x18359C0 Offset: 0x18359C0 VA: 0x18359C0
	//public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH) { }

	// RVA: 0x1835AA4 Offset: 0x1835AA4 VA: 0x1835AA4
	public HIHJGPDLNDN_EventScore()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 41;
	}

	// RVA: 0x1835CE8 Offset: 0x1835CE8 VA: 0x1835CE8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		TodoLogger.Log(TodoLogger.Database, "HIHJGPDLNDN_EventScore.KMBPACJNEOF");
	}

	// RVA: 0x1835E9C Offset: 0x1835E9C VA: 0x1835E9C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "HIHJGPDLNDN_EventScore.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1836754 Offset: 0x1836754 VA: 0x1836754 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "HIHJGPDLNDN_EventScore.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x1836170 Offset: 0x1836170 VA: 0x1836170
	//private bool DGKKMKLCEDF(PMPDPNDJBLB JMHECKKKMLK) { }

	//// RVA: 0x18367DC Offset: 0x18367DC VA: 0x18367DC
	//private bool DGKKMKLCEDF(EDOHBJAPLPF IDLHJIOMJBK, int KAPMOPMDHJE) { }

	//// RVA: 0x1836FC4 Offset: 0x1836FC4 VA: 0x1836FC4
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF OBHAFLMHAKG, string OPFGFINHFCE, ref bool NGJDHLGMHMH) { }

	//// RVA: 0x1836E28 Offset: 0x1836E28 VA: 0x1836E28
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM) { }

	// RVA: 0x18371A4 Offset: 0x18371A4 VA: 0x18371A4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "HIHJGPDLNDN_EventScore.CAOGDCBPBAN");
		return 0;
	}

	//[CompilerGeneratedAttribute] // RVA: 0x6C0400 Offset: 0x6C0400 VA: 0x6C0400
	//// RVA: 0x1837304 Offset: 0x1837304 VA: 0x1837304
	//private void <DeserializeSetting>b__19_0(int OIPCCBHIKIA, int JBGEEPFKIGG) { }
}
