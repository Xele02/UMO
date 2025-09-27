
using System.Collections.Generic;

[System.Obsolete("Use JKMLBONMAHD_RichBanner", true)]
public class JKMLBONMAHD { }
public class JKMLBONMAHD_RichBanner : DIHHCBACKGG_DbSection
{
	public class OIDOINPHPOE
	{
		public int PPFNGGCBJKC_id; // 0x8
		public sbyte PPEGAKEIEGM_Enabled; // 0xC
		public long PDBPFJJCADD_open_at; // 0x10
		public long FDBNFFNFOND_close_at; // 0x18
		public int FJOLNJLLJEJ_rank; // 0x20
		public int KNHOMNONOEB_AssetId; // 0x24

		// RVA: 0x1469C34 Offset: 0x1469C34 VA: 0x1469C34
		//public uint CAOGDCBPBAN() { }
	}

	public List<OIDOINPHPOE> CDENCMNHNGA_table = new List<OIDOINPHPOE>(); // 0x20

	// RVA: 0x1469700 Offset: 0x1469700 VA: 0x1469700
	public JKMLBONMAHD_RichBanner()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 69;
	}

	// RVA: 0x14697F4 Offset: 0x14697F4 VA: 0x14697F4 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x146986C Offset: 0x146986C VA: 0x146986C Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		MLAEPADJOJH parser = MLAEPADJOJH.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		CDHIKHMHMPC[] array = parser.MJBONPHHNKG;
		for(int i = 0; i < array.Length; i++)
		{
			OIDOINPHPOE data = new OIDOINPHPOE();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.KNHOMNONOEB_AssetId = array[i].KNHOMNONOEB_AssetId;
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, array[i].PLALNIIBLOF_en, 0);
			data.PDBPFJJCADD_open_at = array[i].PDBPFJJCADD_open_at;
			data.FDBNFFNFOND_close_at = array[i].FDBNFFNFOND_close_at;
			data.FJOLNJLLJEJ_rank = array[i].FJOLNJLLJEJ_rank;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x1469B1C Offset: 0x1469B1C VA: 0x1469B1C Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0x1469B24 Offset: 0x1469B24 VA: 0x1469B24 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JKMLBONMAHD_RichBanner.CAOGDCBPBAN");
		return 0;
	}
}
