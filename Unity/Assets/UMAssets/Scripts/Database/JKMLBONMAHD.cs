
using System.Collections.Generic;

[System.Obsolete("Use JKMLBONMAHD_RichBanner", true)]
public class JKMLBONMAHD { }
public class JKMLBONMAHD_RichBanner : DIHHCBACKGG_DbSection
{
	public class OIDOINPHPOE
	{
		public int PPFNGGCBJKC; // 0x8
		public sbyte PPEGAKEIEGM_Enabled; // 0xC
		public long PDBPFJJCADD; // 0x10
		public long FDBNFFNFOND; // 0x18
		public int FJOLNJLLJEJ; // 0x20
		public int KNHOMNONOEB; // 0x24

		// RVA: 0x1469C34 Offset: 0x1469C34 VA: 0x1469C34
		//public uint CAOGDCBPBAN() { }
	}

	public List<OIDOINPHPOE> CDENCMNHNGA = new List<OIDOINPHPOE>(); // 0x20

	// RVA: 0x1469700 Offset: 0x1469700 VA: 0x1469700
	public JKMLBONMAHD_RichBanner()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 69;
	}

	// RVA: 0x14697F4 Offset: 0x14697F4 VA: 0x14697F4 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x146986C Offset: 0x146986C VA: 0x146986C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		MLAEPADJOJH parser = MLAEPADJOJH.HEGEKFMJNCC(DBBGALAPFGC);
		CDHIKHMHMPC[] array = parser.MJBONPHHNKG;
		for(int i = 0; i < array.Length; i++)
		{
			OIDOINPHPOE data = new OIDOINPHPOE();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.KNHOMNONOEB = array[i].KNHOMNONOEB;
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.PDBPFJJCADD = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND = array[i].FDBNFFNFOND;
			data.FJOLNJLLJEJ = array[i].FJOLNJLLJEJ;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0x1469B1C Offset: 0x1469B1C VA: 0x1469B1C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
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
