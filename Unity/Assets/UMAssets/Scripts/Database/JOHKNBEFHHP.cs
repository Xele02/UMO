using System.Collections.Generic;

[System.Obsolete("Use JOHKNBEFHHP_TitleBanner", true)]
public class JOHKNBEFHHP { }
public class JOHKNBEFHHP_TitleBanner : DIHHCBACKGG_DbSection
{
    public class NGKJHBDEELB
    {
        public int PPFNGGCBJKC_id; // 0x8
        public sbyte PPEGAKEIEGM_Enabled; // 0xC
        public long PDBPFJJCADD_open_at; // 0x10
        public long FDBNFFNFOND_close_at; // 0x18
        public int KNHOMNONOEB_AssetId; // 0x20

        // // RVA: 0x1BA4288 Offset: 0x1BA4288 VA: 0x1BA4288
        // public uint CAOGDCBPBAN() { }
    }
	public List<NGKJHBDEELB> CDENCMNHNGA_table = new List<NGKJHBDEELB>(); // 0x20

	// // RVA: 0x1BA3D84 Offset: 0x1BA3D84 VA: 0x1BA3D84
	public JOHKNBEFHHP_TitleBanner()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 81;
    }

	// // RVA: 0x1BA3E78 Offset: 0x1BA3E78 VA: 0x1BA3E78 Slot: 8
	protected override void KMBPACJNEOF_Reset()
    {
		CDENCMNHNGA_table.Clear();
    }

	// // RVA: 0x1BA3EF0 Offset: 0x1BA3EF0 VA: 0x1BA3EF0 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
    {
		BENBFNLECGA reader = BENBFNLECGA.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		MMBIHLNLPHB[] array = reader.KFKOALPLEGG;
		for(int i = 0; i < array.Length; i++)
		{
			NGKJHBDEELB data = new NGKJHBDEELB();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC;
			data.KNHOMNONOEB_AssetId = array[i].KNHOMNONOEB;
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.PDBPFJJCADD_open_at = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND_close_at = array[i].FDBNFFNFOND;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
    }

	// // RVA: 0x1BA4180 Offset: 0x1BA4180 VA: 0x1BA4180 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// // RVA: 0x1BA4188 Offset: 0x1BA4188 VA: 0x1BA4188 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JOHKNBEFHHP_TitleBanner.CAOGDCBPBAN");
		return 0;
	}
}
