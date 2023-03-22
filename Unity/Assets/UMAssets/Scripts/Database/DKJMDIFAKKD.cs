
using System.Collections.Generic;

[System.Obsolete("Use DKJMDIFAKKD_VcItem", true)]
public class DKJMDIFAKKD { }
public class DKJMDIFAKKD_VcItem : DIHHCBACKGG_DbSection
{
	public class EBGPAPPHBAH
	{
		public string[] GLHKICCPGKJ; // 0x8
		public string OPFGFINHFCE; // 0xC
		public int INDDJNMPONH; // 0x10
		public int HEOLEHDFLJO; // 0x14
		public int EILKGEADKGH; // 0x18
		public bool HPGNBPIBAOM; // 0x1C
		public bool AFHPLBPHEGA; // 0x1D
		public long PDBPFJJCADD; // 0x20
		public long EGBOHDFBAPB; // 0x28
		public string KLMPFGOCBHC; // 0x30
		public int EHOIENNDEDH; // 0x34
		public int HLMAFFLCCKD; // 0x38
		public int OJPMOABFGMA; // 0x3C
		public int IJEKNCDIIAE; // 0x40
		public int DLCGAMHADEN; // 0x44
		public int[] KGOFMDMDFCJ; // 0x48
		public int[] NNIIINKFDBG; // 0x4C
		public int IHCLFMKAJND; // 0x50

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1224AA8 DEMEPMAEJOO 0x1224B40 HIGKAIDMOKN
		public int HMFFHLPNMPH { get { return HLMAFFLCCKD ^ FBGGEFFJJHB; } set { HLMAFFLCCKD = value ^ FBGGEFFJJHB; } } //0x1224BDC NJOGDDPICKG 0x1224C74 NBBGMMBICNA
		public int CPGFOBNKKBF { get { return OJPMOABFGMA ^ FBGGEFFJJHB; } set { OJPMOABFGMA = value ^ FBGGEFFJJHB; } } //0x1224D10 AMNKHCIJHJD 0x1224DA8 INJMDACNFOL

		//// RVA: 0x1224E44 Offset: 0x1224E44 VA: 0x1224E44
		//public uint CAOGDCBPBAN() { }
	}

	public class BCEMHEAKBCC
	{
		public int PPEGAKEIEGM_Enabled; // 0x8
		public int PPFNGGCBJKC_Id; // 0xC
		public int KAPMOPMDHJE_Label; // 0x10
		public long PDBPFJJCADD_OpenAt; // 0x18
		public long EGBOHDFBAPB_CloseAt; // 0x20
	}

	public const int FLKAGOFMBLI = 15;
	public static int FBGGEFFJJHB = 0xb516d; // 0x0
	public List<EBGPAPPHBAH> CDENCMNHNGA = new List<EBGPAPPHBAH>(15); // 0x20
	public List<BCEMHEAKBCC> JOBKIDDLCPL = new List<BCEMHEAKBCC>(); // 0x24

	//// RVA: 0x198FA84 Offset: 0x198FA84 VA: 0x198FA84
	public EBGPAPPHBAH ICGHMMOCJBA(string PGODOPKCHBD, string OPFGFINHFCE, long JHNMKKNEENE, int KAPMOPMDHJE)
	{
		if (CDENCMNHNGA.Count > 0 && string.IsNullOrEmpty(PGODOPKCHBD))
		{
			for (int i = 0; i < CDENCMNHNGA.Count; i++)
			{
				if (CDENCMNHNGA[i].INDDJNMPONH == 1 && CDENCMNHNGA[i].CPGFOBNKKBF == 1001 && CDENCMNHNGA[i].DLCGAMHADEN == KAPMOPMDHJE)
				{
					for (int j = 0; j < CDENCMNHNGA[i].GLHKICCPGKJ.Length; j++)
					{
						if (!string.IsNullOrEmpty(CDENCMNHNGA[i].GLHKICCPGKJ[j]))
						{
							if (CDENCMNHNGA[i].GLHKICCPGKJ[j] == PGODOPKCHBD)
							{
								if (CDENCMNHNGA[i].EGBOHDFBAPB == 0)
									return CDENCMNHNGA[i];
								if (JHNMKKNEENE >= CDENCMNHNGA[i].PDBPFJJCADD)
									return CDENCMNHNGA[i];
								if (CDENCMNHNGA[i].EGBOHDFBAPB >= JHNMKKNEENE)
									return CDENCMNHNGA[i];
							}
						}
					}
				}
			}
		}
		for (int i = 0; i < CDENCMNHNGA.Count; i++)
		{
			if (CDENCMNHNGA[i].INDDJNMPONH == 1 && CDENCMNHNGA[i].CPGFOBNKKBF == 1001 && CDENCMNHNGA[i].DLCGAMHADEN == KAPMOPMDHJE && !string.IsNullOrEmpty(CDENCMNHNGA[i].OPFGFINHFCE))
			{
				if(OPFGFINHFCE.Contains(CDENCMNHNGA[i].OPFGFINHFCE))
				if (CDENCMNHNGA[i].EGBOHDFBAPB == 0)
					return CDENCMNHNGA[i];
				if (JHNMKKNEENE >= CDENCMNHNGA[i].PDBPFJJCADD)
					return CDENCMNHNGA[i];
				if (CDENCMNHNGA[i].EGBOHDFBAPB >= JHNMKKNEENE)
					return CDENCMNHNGA[i];
			}
		}
		return null;
	}

	//// RVA: 0x198FDE0 Offset: 0x198FDE0 VA: 0x198FDE0
	//public DKJMDIFAKKD.EBGPAPPHBAH NHJNPOEKDKK(string OPFGFINHFCE, long JHNMKKNEENE, int KAPMOPMDHJE) { }

	// RVA: 0x198FF90 Offset: 0x198FF90 VA: 0x198FF90
	public DKJMDIFAKKD_VcItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 88;
	}

	// RVA: 0x19900B0 Offset: 0x19900B0 VA: 0x19900B0 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
		JOBKIDDLCPL.Clear();
	}

	// RVA: 0x1990154 Offset: 0x1990154 VA: 0x1990154 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		MDFCHKPOMAJ parser = MDFCHKPOMAJ.HEGEKFMJNCC(DBBGALAPFGC);
		{
			PLCJIGFCOIK[] array = parser.GKBBBINCAGN;
			for(int i = 0; i < array.Length; i++)
			{
				EBGPAPPHBAH data = new EBGPAPPHBAH();
				data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
				data.OPFGFINHFCE = array[i].OPFGFINHFCE;
				data.CPGFOBNKKBF = array[i].CPGFOBNKKBF;
				data.GLHKICCPGKJ = array[i].PDHGIGPAEBG.Split(new char[1] { ',' });
				data.HMFFHLPNMPH = array[i].BFINGCJHOHI;
				data.INDDJNMPONH = array[i].GBJFNGCDKPM;
				data.PDBPFJJCADD = array[i].PDBPFJJCADD;
				data.EGBOHDFBAPB = array[i].EGBOHDFBAPB;
				data.HPGNBPIBAOM = array[i].HPGNBPIBAOM != 0;
				data.AFHPLBPHEGA = array[i].AFHPLBPHEGA != 0;
				data.HEOLEHDFLJO = array[i].HEOLEHDFLJO;
				data.KLMPFGOCBHC = array[i].KLMPFGOCBHC;
				data.KGOFMDMDFCJ = array[i].KGOFMDMDFCJ;
				data.NNIIINKFDBG = array[i].NNIIINKFDBG;
				data.IHCLFMKAJND = array[i].IHCLFMKAJND;
				data.DLCGAMHADEN = array[i].DLCGAMHADEN;
				data.EILKGEADKGH = array[i].EILKGEADKGH;
				CDENCMNHNGA.Add(data);
			}
		}
		{
			EGHGEIALECF[] array = parser.CMFJFBJHKPE;
			for(int i = 0; i < array.Length; i++)
			{
				BCEMHEAKBCC data = new BCEMHEAKBCC();
				data.PPFNGGCBJKC_Id = array[i].PPFNGGCBJKC;
				data.PPEGAKEIEGM_Enabled = array[i].PLALNIIBLOF;
				data.KAPMOPMDHJE_Label = array[i].KAPMOPMDHJE;
				data.PDBPFJJCADD_OpenAt = array[i].PDBPFJJCADD;
				data.EGBOHDFBAPB_CloseAt = array[i].EGBOHDFBAPB;
				JOBKIDDLCPL.Add(data);
			}
		}
		return true;
	}

	// RVA: 0x199081C Offset: 0x199081C VA: 0x199081C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	// RVA: 0x1990824 Offset: 0x1990824 VA: 0x1990824 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "DKJMDIFAKKD_VcItem.CAOGDCBPBAN");
		return 0;
	}
}
