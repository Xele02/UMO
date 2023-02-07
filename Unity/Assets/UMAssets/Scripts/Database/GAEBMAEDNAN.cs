
using System.Collections.Generic;

[System.Obsolete("Use GAEBMAEDNAN_DecoPoint", true)]
public class GAEBMAEDNAN { }
public class GAEBMAEDNAN_DecoPoint : DIHHCBACKGG_DbSection
{
	private static class GJKDBILDDME
	{
		public const string PPFNGGCBJKC = "id";
		public const string FBFLDFMFFOH = "rar";
		public const string JBGEEPFKIGG = "val";
	}

	public class KFFELNOEBPB
	{
		private int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH; // 0xC
		private int CBJIBLBAJLD; // 0x10
		private int ICKOHEDLEFP; // 0x14

		//public int PPFNGGCBJKC { get; set; } 0x13FDEC0 DEMEPMAEJOO 0x13FDB7C HIGKAIDMOKN
		//public int FBFLDFMFFOH { get; set; } 0x13FDED0 HNLMNIOMOLI 0x13FDB8C CHHJKABBIBL
		//public int JBGEEPFKIGG { get; set; } 0x13FDEE0 OLOCMINKGON 0x13FDB9C ABAFHIBFKCE

		// RVA: 0x13FDAD8 Offset: 0x13FDAD8 VA: 0x13FDAD8
		public KFFELNOEBPB()
		{
			TodoLogger.Log(TodoLogger.Database, "KFFELNOEBPB.KFFELNOEBPB()");
		}

		// RVA: 0x13FDE9C Offset: 0x13FDE9C VA: 0x13FDE9C
		//public uint CAOGDCBPBAN() { }
	}

	public const int KCKECKKJHCI = 1;
	public List<KFFELNOEBPB> CDENCMNHNGA = new List<KFFELNOEBPB>(); // 0x20

	// RVA: 0x13FD780 Offset: 0x13FD780 VA: 0x13FD780
	public GAEBMAEDNAN_DecoPoint()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 15;
	}

	// RVA: 0x13FD878 Offset: 0x13FD878 VA: 0x13FD878 Slot: 8
	protected override void KMBPACJNEOF()
	{
		TodoLogger.Log(TodoLogger.Database, "GAEBMAEDNAN_DecoPoint.KMBPACJNEOF");
	}

	// RVA: 0x13FD8F0 Offset: 0x13FD8F0 VA: 0x13FD8F0 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "GAEBMAEDNAN_DecoPoint.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x13FDBAC Offset: 0x13FDBAC VA: 0x13FDBAC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "GAEBMAEDNAN_DecoPoint.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x13FDDA4 Offset: 0x13FDDA4 VA: 0x13FDDA4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "GAEBMAEDNAN_DecoPoint.CAOGDCBPBAN");
		return 0;
	}
}
