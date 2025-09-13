
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HGLPLKKBBOL_EventItem", true)]
public class HGLPLKKBBOL { }
public class HGLPLKKBBOL_EventItem : DIHHCBACKGG_DbSection
{
	public class JMCDEDCMCJE
	{
		public int FBGGEFFJJHB_xor = 0x181b5; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int EAJCFBCHIFB_RarityCrypted; // 0x10
		public int ICKOHEDLEFP; // 0x14
		public int MKENMKMJFKP; // 0x18

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1751E94 DEMEPMAEJOO 0x17519AC HIGKAIDMOKN
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1751EA4 OEEHBGECGKL 0x17519BC GHLMHLJJBIG
		public int JBGEEPFKIGG_Val { get { return ICKOHEDLEFP ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB_xor; } } //0x1751EB4 OLOCMINKGON 0x17519CC ABAFHIBFKCE
		public int INDDJNMPONH_Typ { get { return MKENMKMJFKP ^ FBGGEFFJJHB_xor; } set { MKENMKMJFKP = value ^ FBGGEFFJJHB_xor; } } //0x1751EC4 GHAILOLPHPF 0x17519DC BACGOKIGMBC

		//// RVA: 0x1751E68 Offset: 0x1751E68 VA: 0x1751E68
		//public uint CAOGDCBPBAN() { }
	}

	public List<JMCDEDCMCJE> CDENCMNHNGA_table = new List<JMCDEDCMCJE>(); // 0x20

	// RVA: 0x1751590 Offset: 0x1751590 VA: 0x1751590
	public HGLPLKKBBOL_EventItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 34;
	}

	// RVA: 0x1751684 Offset: 0x1751684 VA: 0x1751684 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x17516FC Offset: 0x17516FC VA: 0x17516FC Slot: 9
	public override bool IIEMACPEEBJ(byte[] _DBBGALAPFGC_Data)
	{
		OOFJBDCPKBJ parser = OOFJBDCPKBJ.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		COGPJCIDIKA[] array = parser.LMNJDPMHNLB;
		int k = (int)Utility.GetCurrentUnixTime();
		k *= 0x181b5;
		for(int i = 0; i < array.Length; i++)
		{
			JMCDEDCMCJE data = new JMCDEDCMCJE();
			data.FBGGEFFJJHB_xor = k;
			data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH;
			data.JBGEEPFKIGG_Val = (int)array[i].JBGEEPFKIGG;
			data.INDDJNMPONH_Typ = (int)array[i].GBJFNGCDKPM;
			k *= 0x6cd;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x17519EC Offset: 0x17519EC VA: 0x17519EC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "HGLPLKKBBOL_EventItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1751D68 Offset: 0x1751D68 VA: 0x1751D68 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HGLPLKKBBOL_EventItem.CAOGDCBPBAN");
		return 0;
	}
}
