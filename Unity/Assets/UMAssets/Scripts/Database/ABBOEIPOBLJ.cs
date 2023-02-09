
using System.Collections.Generic;

[System.Obsolete("Use ABBOEIPOBLJ_EventTicket", true)]
public class ABBOEIPOBLJ { }
public class ABBOEIPOBLJ_EventTicket : DIHHCBACKGG_DbSection
{
	public class CBDACMFFHJC
	{
		public int FBGGEFFJJHB = 0x181b5; // 0x8
		public int EHOIENNDEDH; // 0xC
		public int EAJCFBCHIFB; // 0x10
		public int ICKOHEDLEFP; // 0x14
		public int MKENMKMJFKP; // 0x18

		//public int PPFNGGCBJKC { get; set; } 0x15B094C DEMEPMAEJOO 0x15B0464 HIGKAIDMOKN
		//public int EKLIPGELKCL { get; set; } 0x15B095C OEEHBGECGKL 0x15B0474 GHLMHLJJBIG
		//public int JBGEEPFKIGG { get; set; } 0x15B096C OLOCMINKGON 0x15B0484 ABAFHIBFKCE
		//public int INDDJNMPONH { get; set; } 0x15B097C GHAILOLPHPF 0x15B0494 BACGOKIGMBC

		//// RVA: 0x15B0920 Offset: 0x15B0920 VA: 0x15B0920
		//public uint CAOGDCBPBAN() { }
	}

	public List<CBDACMFFHJC> CDENCMNHNGA = new List<CBDACMFFHJC>(); // 0x20

	// RVA: 0x15B0048 Offset: 0x15B0048 VA: 0x15B0048
	public ABBOEIPOBLJ_EventTicket()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 44;
	}

	// RVA: 0x15B013C Offset: 0x15B013C VA: 0x15B013C Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x15B01B4 Offset: 0x15B01B4 VA: 0x15B01B4 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "ABBOEIPOBLJ_EventTicket.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x15B04A4 Offset: 0x15B04A4 VA: 0x15B04A4 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "ABBOEIPOBLJ_EventTicket.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x15B0820 Offset: 0x15B0820 VA: 0x15B0820 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "ABBOEIPOBLJ_EventTicket.CAOGDCBPBAN");
		return 0;
	}
}
