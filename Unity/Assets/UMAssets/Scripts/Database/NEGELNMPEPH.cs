
using System.Collections.Generic;

[System.Obsolete("Use NEGELNMPEPH_DecoSpSetting", true)]
public class NEGELNMPEPH { }
public class NEGELNMPEPH_DecoSpSetting : DIHHCBACKGG_DbSection
{
	public class DAGLEHBMBLF
	{
		private int FBGGEFFJJHB = 0; // 0x8
		private int OAKFKBJFHBJ = 0; // 0xC
		private int COLOLEGLONK = 0; // 0x10
		private int OHMGPDPKGLF = 0; // 0x14

		//public int BCGKLONODHO { get; set; } 0x1AE6688 KAINPELLHFF 0x1AE628C EJPIFOFOINA
		//public int KPBJHHHMOJE { get; set; } 0x1AE6698 NNBONJFLKFM 0x1AE629C FIOMMOICJLL
		//public int NANNGLGOFKH { get; set; } 0x1AE66A8 EDFAHCMGHKM 0x1AE62AC BKPDFNKGNHA

		// RVA: 0x1AE6630 Offset: 0x1AE6630 VA: 0x1AE6630
		//public uint CAOGDCBPBAN() { }
	}

	public class NDONMEAEGFF
	{
		private int FBGGEFFJJHB; // 0x8
		private int HAPFMIDIMCH; // 0xC
		private int HLMAFFLCCKD; // 0x10

		//public int JPMAHJJMMIA { get; set; } 0x1AE66B8 EEIHPMNJMKG 0x1AE62E4 MGAEEIHCOAL
		//public int HMFFHLPNMPH { get; set; } 0x1AE66C8 NJOGDDPICKG 0x1AE62F4 NBBGMMBICNA

		// RVA: 0x1AE62BC Offset: 0x1AE62BC VA: 0x1AE62BC
		public NDONMEAEGFF(int FBGGEFFJJHB)
		{
			this.FBGGEFFJJHB = FBGGEFFJJHB;
			HAPFMIDIMCH = FBGGEFFJJHB;
			HLMAFFLCCKD = FBGGEFFJJHB;
		}

		// RVA: 0x1AE6660 Offset: 0x1AE6660 VA: 0x1AE6660
		//public uint CAOGDCBPBAN() { }
	}

	public List<List<DAGLEHBMBLF>> ILCGCPIGAFP = new List<List<DAGLEHBMBLF>>(); // 0x20
	public List<List<NDONMEAEGFF>> JDLCJAILIME = new List<List<NDONMEAEGFF>>(); // 0x24
	private int FBGGEFFJJHB; // 0x28

	// RVA: 0x1AE5A1C Offset: 0x1AE5A1C VA: 0x1AE5A1C
	public NEGELNMPEPH_DecoSpSetting()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 17;
	}

	// RVA: 0x1AE5B44 Offset: 0x1AE5B44 VA: 0x1AE5B44 Slot: 8
	protected override void KMBPACJNEOF()
	{
		TodoLogger.Log(TodoLogger.Database, "NEGELNMPEPH_DecoSpSetting.KMBPACJNEOF");
	}

	// RVA: 0x1AE5C2C Offset: 0x1AE5C2C VA: 0x1AE5C2C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "NEGELNMPEPH_DecoSpSetting.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1AE6304 Offset: 0x1AE6304 VA: 0x1AE6304 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "NEGELNMPEPH_DecoSpSetting.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1AE630C Offset: 0x1AE630C VA: 0x1AE630C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "NEGELNMPEPH_DecoSpSetting.CAOGDCBPBAN");
		return 0;
	}
}
