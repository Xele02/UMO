
using System.Collections.Generic;
using XeSys;

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

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x15B094C DEMEPMAEJOO 0x15B0464 HIGKAIDMOKN
		public int EKLIPGELKCL_Rar { get { return EAJCFBCHIFB ^ FBGGEFFJJHB; } set { EAJCFBCHIFB = value ^ FBGGEFFJJHB; } } //0x15B095C OEEHBGECGKL 0x15B0474 GHLMHLJJBIG
		public int JBGEEPFKIGG_Val { get { return ICKOHEDLEFP ^ FBGGEFFJJHB; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB; } } //0x15B096C OLOCMINKGON 0x15B0484 ABAFHIBFKCE
		public int INDDJNMPONH_Typ { get { return MKENMKMJFKP ^ FBGGEFFJJHB; } set { MKENMKMJFKP = value ^ FBGGEFFJJHB; } } //0x15B097C GHAILOLPHPF 0x15B0494 BACGOKIGMBC

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
		BELBAJBINBO parser = BELBAJBINBO.HEGEKFMJNCC(DBBGALAPFGC);
		EIIBKGHEGFI[] array = parser.GMDKFCMGHIK;
		int k = (int)Utility.GetCurrentUnixTime();
		k *= 0x3981;
		for (int i = 0; i < array.Length; i++)
		{
			CBDACMFFHJC data = new CBDACMFFHJC();
			data.FBGGEFFJJHB = k;
			data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			data.EKLIPGELKCL_Rar = (int)array[i].FBFLDFMFFOH;
			data.JBGEEPFKIGG_Val = (int)array[i].JBGEEPFKIGG;
			data.INDDJNMPONH_Typ = (int)array[i].GBJFNGCDKPM;
			k *= 0x6cd;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0x15B04A4 Offset: 0x15B04A4 VA: 0x15B04A4 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.Database, "ABBOEIPOBLJ_EventTicket.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x15B0820 Offset: 0x15B0820 VA: 0x15B0820 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "ABBOEIPOBLJ_EventTicket.CAOGDCBPBAN");
		return 0;
	}
}
