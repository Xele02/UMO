
using System.Collections.Generic;
using XeSys;

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
		private int PIMKKONMBOG_ItemIdCrypted; // 0xC
		private int MKEEIHFCJBA_PosXCrypted; // 0x10
		private int ANDAEBIKMAM_PosYCrypted; // 0x14
		private int BJEIILIBOLB_RvsCrypted; // 0x18
		private int DGLIDLIIILE_PrioCrypted; // 0x1C
		private int MJDLLJGJKEI_WordCrypted; // 0x20
		private int OFOBOGAAHGF_PlacingCrypted; // 0x24

		public int KIJAPOFAGPN_ItemId { get { return PIMKKONMBOG_ItemIdCrypted ^ FBGGEFFJJHB; } set { PIMKKONMBOG_ItemIdCrypted = value ^ FBGGEFFJJHB; } } //0x1C43318 GCKKKIDNACI 0x1C42CF0 OGBLMPODGBG
		public int FBNCFENGOOD_PosX { get { return MKEEIHFCJBA_PosXCrypted ^ FBGGEFFJJHB; } set { MKEEIHFCJBA_PosXCrypted = value ^ FBGGEFFJJHB; } } //0x1C43328 LECCAHAHAMP 0x1C42D00 FAAHKNDOEFN
		public int LOEJKNILJKF_PosY { get { return ANDAEBIKMAM_PosYCrypted ^ FBGGEFFJJHB; } set { ANDAEBIKMAM_PosYCrypted = value ^ FBGGEFFJJHB; } } //0x1C43338 BLDOOIODGOK 0x1C42D10 BICDPEHAJPN
		public bool NEGMFBPNJGK_Rvs { get { return (BJEIILIBOLB_RvsCrypted ^ FBGGEFFJJHB) == 140; } set { BJEIILIBOLB_RvsCrypted = (value ? 140 : 892) ^ FBGGEFFJJHB; } } //0x1C43348 AGBGLCMJIIL 0x1C42D20 PDPBJNLLAID
		public int DAPGDCPDCNA_Prio { get { return DGLIDLIIILE_PrioCrypted ^ FBGGEFFJJHB; } set { DGLIDLIIILE_PrioCrypted = value ^ FBGGEFFJJHB; } } //0x1C43364 GFAHOLGECII 0x1C42D58 KJKCIHEDEBB
		public int BEJGNPAAKNB_Word { get { return MJDLLJGJKEI_WordCrypted ^ FBGGEFFJJHB; } set { MJDLLJGJKEI_WordCrypted = value ^ FBGGEFFJJHB; } } //0x1C43374 PPHPHCADCLJ 0x1C42D68 BPMLEPPPCKP
		public bool OPAHFDJPFJO_Placing { get { return (OFOBOGAAHGF_PlacingCrypted ^ FBGGEFFJJHB) == 16469; } set { OFOBOGAAHGF_PlacingCrypted = (value ? 16469 : 4026) ^ FBGGEFFJJHB; } } // 0x1C43384 AFIMAHKLGJH 0x1C42D78 OELIAPKHFKE

		// RVA: 0x1C42C04 Offset: 0x1C42C04 VA: 0x1C42C04
		public MPIILICCLDD()
		{
			FBGGEFFJJHB = (int)Utility.GetCurrentUnixTime();
			KIJAPOFAGPN_ItemId = 0;
			FBNCFENGOOD_PosX = 0;
			LOEJKNILJKF_PosY = 0;
			NEGMFBPNJGK_Rvs = false;
			DAPGDCPDCNA_Prio = 0;
			BEJGNPAAKNB_Word = 0;
			OPAHFDJPFJO_Placing = false;
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
		FFHDKFPLLEN parser = FFHDKFPLLEN.HEGEKFMJNCC(DBBGALAPFGC);
		MPEFMPPMBGM[] array = parser.HMPJFEFCGHI;
		for(int i = 0; i < array.Length; i++)
		{
			MPIILICCLDD data = new MPIILICCLDD();
			data.KIJAPOFAGPN_ItemId = (int)array[i].GLCLFMGPMAN;
			data.FBNCFENGOOD_PosX = array[i].FPLEBCKDCBE;
			data.LOEJKNILJKF_PosY = array[i].MDLMHEDHPHA;
			data.NEGMFBPNJGK_Rvs = array[i].NEGMFBPNJGK == 1;
			data.DAPGDCPDCNA_Prio = (int)array[i].DAPGDCPDCNA;
			data.BEJGNPAAKNB_Word = (int)array[i].BEJGNPAAKNB;
			data.OPAHFDJPFJO_Placing = array[i].OPAHFDJPFJO == 1;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0x1C42DB0 Offset: 0x1C42DB0 VA: 0x1C42DB0 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.Database, "JEPMHCPBIGD_DecoItemInit.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1C43140 Offset: 0x1C43140 VA: 0x1C43140 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JEPMHCPBIGD_DecoItemInit.IIEMACPEEBJ");
		return 0;
	}

	// RVA: 0x1C432A0 Offset: 0x1C432A0 VA: 0x1C432A0 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}
}
