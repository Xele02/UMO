
using System.Collections.Generic;

[System.Obsolete("Use JEPMHCPBIGD_DecoItemInit", true)]
public class JEPMHCPBIGD { }
public class JEPMHCPBIGD_DecoItemInit : DIHHCBACKGG_DbSection
{
	public static class NHJIACCJLFJ
	{
		public const string GLCLFMGPMAN = "item_id";
		public const string FPLEBCKDCBE = "pos_x";
		public const string MDLMHEDHPHA = "pos_y";
		public const string NEGMFBPNJGK = "rvs";
		public const string DAPGDCPDCNA = "prio";
		public const string BEJGNPAAKNB = "word";
		public const string OPAHFDJPFJO = "placing";
	}

	public class MPIILICCLDD
	{
		private int FBGGEFFJJHB; // 0x8
		private int PIMKKONMBOG; // 0xC
		private int MKEEIHFCJBA; // 0x10
		private int ANDAEBIKMAM; // 0x14
		private int BJEIILIBOLB; // 0x18
		private int DGLIDLIIILE; // 0x1C
		private int MJDLLJGJKEI; // 0x20
		private int OFOBOGAAHGF; // 0x24

		//public int KIJAPOFAGPN { get; set; } 0x1C43318 GCKKKIDNACI 0x1C42CF0 OGBLMPODGBG
		//public int FBNCFENGOOD { get; set; } 0x1C43328 LECCAHAHAMP 0x1C42D00 FAAHKNDOEFN
		//public int LOEJKNILJKF { get; set; } 0x1C43338 BLDOOIODGOK 0x1C42D10 BICDPEHAJPN
		//public bool NEGMFBPNJGK { get; set; } 0x1C43348 AGBGLCMJIIL 0x1C42D20 PDPBJNLLAID
		//public int DAPGDCPDCNA { get; set; } 0x1C43364 GFAHOLGECII 0x1C42D58 KJKCIHEDEBB
		//public int BEJGNPAAKNB { get; set; } 0x1C43374 PPHPHCADCLJ 0x1C42D68 BPMLEPPPCKP
		//public bool OPAHFDJPFJO { get; set; } 0x1C43384 AFIMAHKLGJH 0x1C42D78 OELIAPKHFKE

		// RVA: 0x1C42C04 Offset: 0x1C42C04 VA: 0x1C42C04
		public MPIILICCLDD()
		{
			TodoLogger.Log(TodoLogger.Database, "MPIILICCLDD.MPIILICCLDD()");
		}

		//// RVA: 0x1C43258 Offset: 0x1C43258 VA: 0x1C43258
		//public uint CAOGDCBPBAN() { }
	}

	public const int KHKJIDJOLBG = 20;
	public List<MPIILICCLDD> CDENCMNHNGA = new List<MPIILICCLDD>(); // 0x20

	// RVA: 0x1C42820 Offset: 0x1C42820 VA: 0x1C42820
	public JEPMHCPBIGD_DecoItemInit()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 14;
	}

	// RVA: 0x1C42914 Offset: 0x1C42914 VA: 0x1C42914 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "JEPMHCPBIGD_DecoItemInit.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1C42DB0 Offset: 0x1C42DB0 VA: 0x1C42DB0 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "JEPMHCPBIGD_DecoItemInit.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1C43140 Offset: 0x1C43140 VA: 0x1C43140 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "JEPMHCPBIGD_DecoItemInit.IIEMACPEEBJ");
		return 0;
	}

	// RVA: 0x1C432A0 Offset: 0x1C432A0 VA: 0x1C432A0 Slot: 8
	protected override void KMBPACJNEOF()
	{
		TodoLogger.Log(TodoLogger.Database, "JEPMHCPBIGD_DecoItemInit.KMBPACJNEOF");
	}
}
