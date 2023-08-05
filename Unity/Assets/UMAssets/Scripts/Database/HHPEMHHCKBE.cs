
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HHPEMHHCKBE_Compo", true)]
public class HHPEMHHCKBE { }
public class HHPEMHHCKBE_Compo : DIHHCBACKGG_DbSection
{
	public class MLMDKHBFOJM
	{
		public int FBGGEFFJJHB = 0x3fb377; // 0x8
		private int EHOIENNDEDH; // 0xC
		public int[] OGEBLOHMGAM; // 0x10
		public int[] AHGCGHAAHOO; // 0x14
		public int EAJCFBCHIFB; // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x18337DC DEMEPMAEJOO 0x1833654 HIGKAIDMOKN
		public int EKLIPGELKCL { get { return EAJCFBCHIFB ^ FBGGEFFJJHB; } set { EAJCFBCHIFB = value ^ FBGGEFFJJHB; } } //0x18337EC OEEHBGECGKL 0x1833664 GHLMHLJJBIG

		//// RVA: 0x18337FC Offset: 0x18337FC VA: 0x18337FC
		public int JCJGGHGIKIJ()
		{
			if(AHGCGHAAHOO != null)
				return AHGCGHAAHOO.Length;
			return 0;
		}

		//// RVA: 0x1833810 Offset: 0x1833810 VA: 0x1833810
		public int CBLLFCGEJAI(int OIPCCBHIKIA)
		{
			return AHGCGHAAHOO[OIPCCBHIKIA] ^ FBGGEFFJJHB;
		}

		//// RVA: 0x1833864 Offset: 0x1833864 VA: 0x1833864
		public int HBJMCLGKLBA(int OIPCCBHIKIA)
		{
			return OGEBLOHMGAM[OIPCCBHIKIA] ^ FBGGEFFJJHB;
		}

		//// RVA: 0x1833760 Offset: 0x1833760 VA: 0x1833760
		//public uint CAOGDCBPBAN() { }
	}

	public List<MLMDKHBFOJM> CDENCMNHNGA = new List<MLMDKHBFOJM>(); // 0x20

	// RVA: 0x18330C0 Offset: 0x18330C0 VA: 0x18330C0
	public HHPEMHHCKBE_Compo()
	{
		JIKKNHIAEKG_BlockName = "compo";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 10;
	}

	// RVA: 0x18331B8 Offset: 0x18331B8 VA: 0x18331B8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x1833230 Offset: 0x1833230 VA: 0x1833230 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		FPDHPIEBAHD parser = FPDHPIEBAHD.HEGEKFMJNCC(DBBGALAPFGC);
		AKJNKDNCCCC[] array = parser.LIFDACJBDBA;
		int k = (int)Utility.GetCurrentUnixTime();
		k = k * 0x761fed + 5;
		for (int i = 0; i < array.Length; i++)
		{
			MLMDKHBFOJM data = new MLMDKHBFOJM();
			data.FBGGEFFJJHB = k;
			data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
			data.EKLIPGELKCL = array[i].EKLIPGELKCL;
			int[] l1 = array[i].AIHOJKFNEEN;
			uint[] l2 = array[i].BFINGCJHOHI;
			data.AHGCGHAAHOO = new int[l1.Length];
			data.OGEBLOHMGAM = new int[l2.Length];
			for(int j = 0; j < l1.Length; j++)
			{
				data.AHGCGHAAHOO[j] = data.FBGGEFFJJHB ^ l1[j];
				data.OGEBLOHMGAM[j] = data.FBGGEFFJJHB ^ (int)l2[j];
			}
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0x1833674 Offset: 0x1833674 VA: 0x1833674 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0x183367C Offset: 0x183367C VA: 0x183367C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HHPEMHHCKBE_Compo.IIEMACPEEBJ");
		return 0;
	}
}
