
using System.Collections.Generic;


[System.Obsolete("Use GPMHOAKFALE_Adventure", true)]
public class GPMHOAKFALE { }
public class GPMHOAKFALE_Adventure : DIHHCBACKGG_DbSection
{
	public class NGDBKCKMDHE
	{
		public int FBGGEFFJJHB; // 0x8
		public int AOGEMIIMFLD; // 0xC
		public int OIFAFKDMEEJ_EnabledCrypted; // 0x10
		public int INAKHLKLFOK; // 0x14

		public int BPNKGDGBBFG { get { return AOGEMIIMFLD  ^ FBGGEFFJJHB; } set { AOGEMIIMFLD = value ^ FBGGEFFJJHB; } } //0x1E5F810 OPOKKOIDCLG 0x1E5F6B8 CKNHCODBIAG
		public int KKPPFAHFOJI { get { return INAKHLKLFOK ^ FBGGEFFJJHB; } set { INAKHLKLFOK = value ^ FBGGEFFJJHB; } } //0x1E5F820 JHDAICCKIOG 0x1E5F6D8 MCCPIGOELKB
		public int PPEGAKEIEGM_Enabled { get { return OIFAFKDMEEJ_EnabledCrypted ^ FBGGEFFJJHB; } set { OIFAFKDMEEJ_EnabledCrypted = value ^ FBGGEFFJJHB; } } //0x1E5F830 KPOEEPIMMJP 0x1E5F6C8 NCIEAFEDPBH

		// RVA: 0x1E5F7EC Offset: 0x1E5F7EC VA: 0x1E5F7EC
		//public uint CAOGDCBPBAN() { }
	}

	public List<NGDBKCKMDHE> CDENCMNHNGA { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x1E5F1EC Offset: 0x1E5F1EC VA: 0x1E5F1EC
	public NGDBKCKMDHE GCINIJEMHFK(int PPFNGGCBJKC)
	{
		if (PPFNGGCBJKC != 0 && PPFNGGCBJKC <= CDENCMNHNGA.Count)
		{
			return CDENCMNHNGA[PPFNGGCBJKC - 1];
		}
		return null;
	}

	// RVA: 0x1E5F2B4 Offset: 0x1E5F2B4 VA: 0x1E5F2B4
	public GPMHOAKFALE_Adventure()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 0;
		CDENCMNHNGA = new List<NGDBKCKMDHE>();
	}

	// RVA: 0x1E5F3AC Offset: 0x1E5F3AC VA: 0x1E5F3AC Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x1E5F424 Offset: 0x1E5F424 VA: 0x1E5F424 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		NJBPFPMDKHN parser = NJBPFPMDKHN.HEGEKFMJNCC(DBBGALAPFGC);
		MGEJEAENEEG(parser);
		return true;
	}

	// RVA: 0x1E5F6A8 Offset: 0x1E5F6A8 VA: 0x1E5F6A8 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	//// RVA: 0x1E5F450 Offset: 0x1E5F450 VA: 0x1E5F450
	private bool MGEJEAENEEG(NJBPFPMDKHN JMHECKKKMLK)
	{
		LLFEFBAPGCH[] array = JMHECKKKMLK.CEEPNGEADMG;
		int k = 0x110bba;
		for (int i = 0; i < array.Length; i++)
		{
			NGDBKCKMDHE data = new NGDBKCKMDHE();
			data.FBGGEFFJJHB = k;
			data.BPNKGDGBBFG = array[i].PPFNGGCBJKC;
			data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.KKPPFAHFOJI = array[i].CEHGGKDLAFA;
			CDENCMNHNGA.Add(data);
			k *= 0x8d;
		}
		return true;
	}

	//// RVA: 0x1E5F6E8 Offset: 0x1E5F6E8 VA: 0x1E5F6E8
	//private bool JANANCJMFPB(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// RVA: 0x1E5F6F0 Offset: 0x1E5F6F0 VA: 0x1E5F6F0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "GPMHOAKFALE_Adventure.CAOGDCBPBAN");
		return 0;
	}
}

