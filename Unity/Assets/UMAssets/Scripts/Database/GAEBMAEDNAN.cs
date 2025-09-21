
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use GAEBMAEDNAN_DecoPoint", true)]
public class GAEBMAEDNAN { }
public class GAEBMAEDNAN_DecoPoint : DIHHCBACKGG_DbSection
{
	private static class GJKDBILDDME
	{
		public const string PPFNGGCBJKC_id = "id";
		public const string FBFLDFMFFOH = "rar";
		public const string JBGEEPFKIGG_Value = "val";
	}

	public class KFFELNOEBPB
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int CBJIBLBAJLD_Rarity; // 0x10
		private int ICKOHEDLEFP_ValueCrypted; // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } }// 0x13FDEC0 DEMEPMAEJOO 0x13FDB7C HIGKAIDMOKN
		public int FBFLDFMFFOH_Rarity { get { return CBJIBLBAJLD_Rarity ^ FBGGEFFJJHB_xor; } set { CBJIBLBAJLD_Rarity = value ^ FBGGEFFJJHB_xor; } }// 0x13FDED0 HNLMNIOMOLI 0x13FDB8C CHHJKABBIBL
		public int JBGEEPFKIGG_Value { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } }// 0x13FDEE0 OLOCMINKGON 0x13FDB9C ABAFHIBFKCE

		// RVA: 0x13FDAD8 Offset: 0x13FDAD8 VA: 0x13FDAD8
		public KFFELNOEBPB()
		{
			FBGGEFFJJHB_xor = (int)Utility.GetCurrentUnixTime();
			PPFNGGCBJKC_id = 0;
			FBFLDFMFFOH_Rarity = 0;
			JBGEEPFKIGG_Value = 0;
		}

		// RVA: 0x13FDE9C Offset: 0x13FDE9C VA: 0x13FDE9C
		//public uint CAOGDCBPBAN() { }
	}

	public const int KCKECKKJHCI = 1;
	public List<KFFELNOEBPB> CDENCMNHNGA_table = new List<KFFELNOEBPB>(); // 0x20

	// RVA: 0x13FD780 Offset: 0x13FD780 VA: 0x13FD780
	public GAEBMAEDNAN_DecoPoint()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 15;
	}

	// RVA: 0x13FD878 Offset: 0x13FD878 VA: 0x13FD878 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x13FD8F0 Offset: 0x13FD8F0 VA: 0x13FD8F0 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_Data)
	{
		ALFKCDIOOHC parser = ALFKCDIOOHC.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		NPMGLCODOBA[] array = parser.HKOCCOIGLIK;
		if(array.Length < 2)
		{
			if(array.Length == 1)
			{
				KFFELNOEBPB data = new KFFELNOEBPB();
				data.PPFNGGCBJKC_id = (int)array[0].PPFNGGCBJKC;
				data.FBFLDFMFFOH_Rarity = (int)array[0].FBFLDFMFFOH;
				data.JBGEEPFKIGG_Value = (int)array[0].JBGEEPFKIGG;
				CDENCMNHNGA_table.Add(data);
			}
			return true;
		}
		return false;
	}

	// RVA: 0x13FDBAC Offset: 0x13FDBAC VA: 0x13FDBAC Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "GAEBMAEDNAN_DecoPoint.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x13FDDA4 Offset: 0x13FDDA4 VA: 0x13FDDA4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "GAEBMAEDNAN_DecoPoint.CAOGDCBPBAN");
		return 0;
	}
}
