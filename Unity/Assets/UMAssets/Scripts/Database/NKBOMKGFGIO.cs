
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use NKBOMKGFGIO_EventRaidItem", true)]
public class NKBOMKGFGIO { }
public class NKBOMKGFGIO_EventRaidItem : DIHHCBACKGG_DbSection
{
	public class PDPBHLDICEJ
	{
		public int FBGGEFFJJHB_xor = 0xbf370; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int EAJCFBCHIFB_RarityCrypted; // 0x10
		private int ICKOHEDLEFP; // 0x14
		private int HHPFFPINGAA; // 0x18
		private int LCGJKAGIFGO; // 0x1C

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18AEBB8 DEMEPMAEJOO 0x18AE658 HIGKAIDMOKN
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18AEBC8 OEEHBGECGKL 0x18AE668 GHLMHLJJBIG
		public int JBGEEPFKIGG_Val { get { return ICKOHEDLEFP ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB_xor; } } //0x18AEBD8 OLOCMINKGON 0x18AE678 ABAFHIBFKCE
		public int EILKGEADKGH_Order{ get { return HHPFFPINGAA ^ FBGGEFFJJHB_xor; } set { HHPFFPINGAA = value ^ FBGGEFFJJHB_xor; } } //0x18AEBE8 NPDDACIHBKD 0x18AE688 BJJMCKHBPNH
		public int DOOGFEGEKLG_Max { get { return LCGJKAGIFGO ^ FBGGEFFJJHB_xor; } set { LCGJKAGIFGO = value ^ FBGGEFFJJHB_xor; } } //0x18AEBF8 AECMFIOFFJN 0x18AE698 NGOJJDOCIDG

		//// RVA: 0x18AEB70 Offset: 0x18AEB70 VA: 0x18AEB70
		//public uint CAOGDCBPBAN() { }
	}

	public List<PDPBHLDICEJ> CDENCMNHNGA_table = new List<PDPBHLDICEJ>(); // 0x20

	// RVA: 0x18AE214 Offset: 0x18AE214 VA: 0x18AE214
	public NKBOMKGFGIO_EventRaidItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 40;
	}

	// RVA: 0x18AE308 Offset: 0x18AE308 VA: 0x18AE308 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x18AE380 Offset: 0x18AE380 VA: 0x18AE380 Slot: 9
	public override bool IIEMACPEEBJ(byte[] _DBBGALAPFGC_Data)
	{
		CHIHOOMFLNA parser = CHIHOOMFLNA.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		DNNGNDOKKGA[] array = parser.KADBDHBKNMK;
		int k = (int)Utility.GetCurrentUnixTime();
		k *= 0x2014;
		for (int i = 0; i < array.Length; i++)
		{
			PDPBHLDICEJ data = new PDPBHLDICEJ();
			data.FBGGEFFJJHB_xor = k;
			data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH;
			data.JBGEEPFKIGG_Val = (int)array[i].JBGEEPFKIGG;
			data.EILKGEADKGH_Order = (int)array[i].FPOMEEJFBIG;
			data.DOOGFEGEKLG_Max = (int)array[i].DOOGFEGEKLG;
			k *= 0x356;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x18AE6A8 Offset: 0x18AE6A8 VA: 0x18AE6A8 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "NKBOMKGFGIO_EventRaidItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x18AEA60 Offset: 0x18AEA60 VA: 0x18AEA60 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "NKBOMKGFGIO_EventRaidItem.CAOGDCBPBAN");
		return 0;
	}
}
