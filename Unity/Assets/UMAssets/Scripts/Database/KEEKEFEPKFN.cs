
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use KEEKEFEPKFN_GrowItem", true)]
public class KEEKEFEPKFN { }
public class KEEKEFEPKFN_GrowItem : DIHHCBACKGG_DbSection
{
	public class MDFGLOIGAFE_GrowItemData
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int EAJCFBCHIFB_RarityCrypted; // 0xC
		public int MKENMKMJFKP; // 0x10
		public int FBGGEFFJJHB_xor = 0x5f40224; // 0x14
		public int PPEGAKEIEGM; // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xE87BD4 DEMEPMAEJOO 0xE87740 HIGKAIDMOKN
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0xE87BE4 OEEHBGECGKL 0xE87A90 GHLMHLJJBIG
		public int INDDJNMPONH { get { return MKENMKMJFKP ^ FBGGEFFJJHB_xor; } set { MKENMKMJFKP = value ^ FBGGEFFJJHB_xor; } } //0xE87BF4 GHAILOLPHPF 0xE87AA0 BACGOKIGMBC

		// RVA: 0xE87BB0 Offset: 0xE87BB0 VA: 0xE87BB0
		//public uint CAOGDCBPBAN() { }
	}

	public const int HAKIPFMCMGD = 27;
	public List<MDFGLOIGAFE_GrowItemData> CDENCMNHNGA_table = new List<MDFGLOIGAFE_GrowItemData>(27); // 0x20

	// RVA: 0xE874D0 Offset: 0xE874D0 VA: 0xE874D0
	public KEEKEFEPKFN_GrowItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 50;
	}

	// RVA: 0xE875C8 Offset: 0xE875C8 VA: 0xE875C8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA_table.Clear();
		int v = (int)Utility.GetCurrentUnixTime();
		v = v * 3 + 2;
		for(int i = 0; i < 27; i++)
		{
			MDFGLOIGAFE_GrowItemData data = new MDFGLOIGAFE_GrowItemData();
			data.FBGGEFFJJHB_xor = v;
			data.PPFNGGCBJKC = i + 1;
			CDENCMNHNGA_table.Add(data);
		}
	}

	// RVA: 0xE87750 Offset: 0xE87750 VA: 0xE87750 Slot: 9
	public override bool IIEMACPEEBJ(byte[] _DBBGALAPFGC_Data)
	{
		MDOBMPOHGJO parser = MDOBMPOHGJO.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		OMNECLCMFOL[] array = parser.KKOAFINEAAG;
		if (array.Length >= 28)
			return false;
		for(int i = 0; i < array.Length; i++)
		{
			MDFGLOIGAFE_GrowItemData data = CDENCMNHNGA_table[i];
			data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH;
			data.INDDJNMPONH = (int)array[i].GBJFNGCDKPM;
			data.PPEGAKEIEGM = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
		}
		return true;
	}

	// RVA: 0xE87AB0 Offset: 0xE87AB0 VA: 0xE87AB0 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0xE87AB8 Offset: 0xE87AB8 VA: 0xE87AB8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "KEEKEFEPKFN_GrowItem.CAOGDCBPBAN");
		return 0;
	}
}
