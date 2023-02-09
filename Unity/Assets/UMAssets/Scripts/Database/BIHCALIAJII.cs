
using System.Collections.Generic;

[System.Obsolete("Use BIHCALIAJII_GachaLimit", true)]
public class BIHCALIAJII { }
public class BIHCALIAJII_GachaLimit : DIHHCBACKGG_DbSection
{
	public class AICPHCIFEJL
	{
		public int EHOIENNDEDH; // 0x8
		public int GNGNIKNNCNH; // 0xC
		public int HNJHPNPFAAN; // 0x10
		public int AFOHGNGFDEB; // 0x14
		public int OFDPFGGKIKM; // 0x18
		public int BAMCNPNLEEN; // 0x1C
		public List<CEBFFLDKAEC_SecureInt> ADDCEJNOJLG = new List<CEBFFLDKAEC_SecureInt>(); // 0x20

		//public int PPFNGGCBJKC { get; set; } 0xC85150 DEMEPMAEJOO 0xC8406C HIGKAIDMOKN
		//public int IJEKNCDIIAE { get; set; } 0xC851E8 KJIMMIBDCIL 0xC841A4 DMEGNOKIKCD
		//public int PLALNIIBLOF { get; set; } 0xC83330 JPCJNLHHIPE 0xC84108 JJFJNEJLBDG
		//public int FEFDGBPFKBJ { get; set; } 0xC85038 BFIENFNOPIH 0xC84240 INLGKGJPBCP
		//public int KOMKKBDABJP { get; set; } 0xC85280 MOMCBDJIGKO 0xC842DC NECMHGINPDE
		//public int FOILNHKHHDF { get; set; } 0xC833C8 FOFBHPJDHFO 0xC84378 LHPMDDKPJDP

		//// RVA: 0xC84E5C Offset: 0xC84E5C VA: 0xC84E5C
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB = 0x274549; // 0x0
	public const int NJJBNDKIPEK = 100;
	public List<AICPHCIFEJL> CDENCMNHNGA; // 0x20
	private List<NNJFKLBPBNK_SecureString> IFBBNEGGCIH; // 0x28
	private List<CEBFFLDKAEC_SecureInt> JNJAOACIGOC; // 0x30

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x2C KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0xC82F38 Offset: 0xC82F38 VA: 0xC82F38
	//public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH) { }

	//// RVA: 0xC8301C Offset: 0xC8301C VA: 0xC8301C
	//public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH) { }

	//// RVA: 0xC83100 Offset: 0xC83100 VA: 0xC83100
	//public BIHCALIAJII.AICPHCIFEJL IEOBBIBCNPH(int HHGMPEEGFMA) { }

	//// RVA: 0xC83200 Offset: 0xC83200 VA: 0xC83200
	//public int DDHDJNCFNOC(int HHGMPEEGFMA) { }

	//// RVA: 0xC83460 Offset: 0xC83460 VA: 0xC83460
	//public bool PJPDOCNJNGJ(int HHGMPEEGFMA, int DNBFMLBNAEE) { }

	// RVA: 0xC8359C Offset: 0xC8359C VA: 0xC8359C
	public BIHCALIAJII_GachaLimit()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA = new List<AICPHCIFEJL>();
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		JNJAOACIGOC = new List<CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		IFBBNEGGCIH = new List<NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 47;
	}

	// RVA: 0xC83760 Offset: 0xC83760 VA: 0xC83760 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
		JNJAOACIGOC.Clear();
		IFBBNEGGCIH.Clear();
		OHJFBLFELNK.Clear();
		FJOEBCMGDMI.Clear();
	}

	// RVA: 0xC83888 Offset: 0xC83888 VA: 0xC83888 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "BIHCALIAJII_GachaLimit.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0xC84414 Offset: 0xC84414 VA: 0xC84414 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "BIHCALIAJII_GachaLimit.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0xC84D78 Offset: 0xC84D78 VA: 0xC84D78 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "BIHCALIAJII_GachaLimit.CAOGDCBPBAN");
		return 0;
	}
}
