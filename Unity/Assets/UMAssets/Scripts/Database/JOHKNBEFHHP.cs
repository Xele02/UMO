using System.Collections.Generic;

public class JOHKNBEFHHP { }
public class JOHKNBEFHHP_TitleBanner : DIHHCBACKGG
{
    public class NGKJHBDEELB
    {
        public int PPFNGGCBJKC_Id; // 0x8
        public sbyte PPEGAKEIEGM; // 0xC
        public long PDBPFJJCADD_StartDate; // 0x10
        public long FDBNFFNFOND_EndDate; // 0x18
        public int KNHOMNONOEB_AssetId; // 0x20

        // // RVA: 0x1BA4288 Offset: 0x1BA4288 VA: 0x1BA4288
        // public uint CAOGDCBPBAN() { }
    }
	public List<NGKJHBDEELB> CDENCMNHNGA_BannerList = new List<NGKJHBDEELB>(); // 0x20

	// // RVA: 0x1BA3D84 Offset: 0x1BA3D84 VA: 0x1BA3D84
	public JOHKNBEFHHP_TitleBanner()
    {
		JIKKNHIAEKG = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 81;
    }

	// // RVA: 0x1BA3E78 Offset: 0x1BA3E78 VA: 0x1BA3E78 Slot: 8
	protected override void KMBPACJNEOF()
    {
		CDENCMNHNGA_BannerList.Clear();
    }

	// // RVA: 0x1BA3EF0 Offset: 0x1BA3EF0 VA: 0x1BA3EF0 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		BENBFNLECGA reader = BENBFNLECGA.HEGEKFMJNCC(DBBGALAPFGC);
		MMBIHLNLPHB[] array = reader.KFKOALPLEGG;
		for(int i = 0; i < array.Length; i++)
		{
			NGKJHBDEELB data = new NGKJHBDEELB();
			data.PPFNGGCBJKC_Id = array[i].PPFNGGCBJKC;
			data.KNHOMNONOEB_AssetId = array[i].KNHOMNONOEB;
			data.PPEGAKEIEGM = (sbyte)JKAECBCNHAN(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.PDBPFJJCADD_StartDate = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND_EndDate = array[i].FDBNFFNFOND;
			CDENCMNHNGA_BannerList.Add(data);
		}
		return true;
    }

	// // RVA: 0x1BA4180 Offset: 0x1BA4180 VA: 0x1BA4180 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// // RVA: 0x1BA4188 Offset: 0x1BA4188 VA: 0x1BA4188 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(100, "CAOGDCBPBAN");
		return 0;
	}
}
