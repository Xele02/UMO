
using System;
using System.Collections.Generic;
using System.Linq;
using XeSys;

[System.Obsolete("Use DKJMDIFAKKD_VcItem", true)]
public class DKJMDIFAKKD { }
public class DKJMDIFAKKD_VcItem : DIHHCBACKGG_DbSection
{
	public class EBGPAPPHBAH
	{
		public string[] GLHKICCPGKJ_PlatformProductIds; // 0x8
		public string OPFGFINHFCE_Name; // 0xC
		public int INDDJNMPONH_Category; // 0x10
		public int HEOLEHDFLJO; // 0x14
		public int EILKGEADKGH; // 0x18
		public bool HPGNBPIBAOM; // 0x1C
		public bool AFHPLBPHEGA; // 0x1D
		public long PDBPFJJCADD_StartDate; // 0x20
		public long EGBOHDFBAPB_EndDate; // 0x28
		public string KLMPFGOCBHC_Desc; // 0x30
		public int EHOIENNDEDH; // 0x34
		public int HLMAFFLCCKD; // 0x38
		public int OJPMOABFGMA; // 0x3C
		public int IJEKNCDIIAE; // 0x40
		public int DLCGAMHADEN_Label; // 0x44
		public int[] KGOFMDMDFCJ_BonusId; // 0x48
		public int[] NNIIINKFDBG_BonusCount; // 0x4C
		public int IHCLFMKAJND; // 0x50

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1224AA8 DEMEPMAEJOO 0x1224B40 HIGKAIDMOKN
		public int HMFFHLPNMPH_Count { get { return HLMAFFLCCKD ^ FBGGEFFJJHB; } set { HLMAFFLCCKD = value ^ FBGGEFFJJHB; } } //0x1224BDC NJOGDDPICKG 0x1224C74 NBBGMMBICNA
		public int CPGFOBNKKBF_Currency { get { return OJPMOABFGMA ^ FBGGEFFJJHB; } set { OJPMOABFGMA = value ^ FBGGEFFJJHB; } } //0x1224D10 AMNKHCIJHJD 0x1224DA8 INJMDACNFOL

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
		if (CDENCMNHNGA.Count > 0 && !string.IsNullOrEmpty(PGODOPKCHBD))
		{
			for (int i = 0; i < CDENCMNHNGA.Count; i++)
			{
				if (CDENCMNHNGA[i].INDDJNMPONH_Category == 1 && CDENCMNHNGA[i].CPGFOBNKKBF_Currency == 1001 && CDENCMNHNGA[i].DLCGAMHADEN_Label == KAPMOPMDHJE)
				{
					for (int j = 0; j < CDENCMNHNGA[i].GLHKICCPGKJ_PlatformProductIds.Length; j++)
					{
						if (!string.IsNullOrEmpty(CDENCMNHNGA[i].GLHKICCPGKJ_PlatformProductIds[j]))
						{
							if (CDENCMNHNGA[i].GLHKICCPGKJ_PlatformProductIds[j] == PGODOPKCHBD)
							{
								if (CDENCMNHNGA[i].EGBOHDFBAPB_EndDate == 0)
									return CDENCMNHNGA[i];
								if (JHNMKKNEENE >= CDENCMNHNGA[i].PDBPFJJCADD_StartDate)
									return CDENCMNHNGA[i];
								if (CDENCMNHNGA[i].EGBOHDFBAPB_EndDate >= JHNMKKNEENE)
									return CDENCMNHNGA[i];
							}
						}
					}
				}
			}
		}
		for (int i = 0; i < CDENCMNHNGA.Count; i++)
		{
			if (CDENCMNHNGA[i].INDDJNMPONH_Category == 1 && CDENCMNHNGA[i].CPGFOBNKKBF_Currency == 1001 && CDENCMNHNGA[i].DLCGAMHADEN_Label == KAPMOPMDHJE && !string.IsNullOrEmpty(CDENCMNHNGA[i].OPFGFINHFCE_Name))
			{
				if(OPFGFINHFCE.Contains(CDENCMNHNGA[i].OPFGFINHFCE_Name))
				{
					if (CDENCMNHNGA[i].EGBOHDFBAPB_EndDate == 0)
						return CDENCMNHNGA[i];
					if (JHNMKKNEENE < CDENCMNHNGA[i].PDBPFJJCADD_StartDate)
						return CDENCMNHNGA[i];
					if (CDENCMNHNGA[i].EGBOHDFBAPB_EndDate < JHNMKKNEENE)
						return CDENCMNHNGA[i];
				}
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
				data.PPFNGGCBJKC_Id = array[i].PPFNGGCBJKC;
				data.OPFGFINHFCE_Name = array[i].OPFGFINHFCE;
				data.CPGFOBNKKBF_Currency = array[i].CPGFOBNKKBF;
				data.GLHKICCPGKJ_PlatformProductIds = array[i].PDHGIGPAEBG.Split(new char[1] { ',' });
				data.HMFFHLPNMPH_Count = array[i].BFINGCJHOHI;
				data.INDDJNMPONH_Category = array[i].GBJFNGCDKPM;
				data.PDBPFJJCADD_StartDate = array[i].PDBPFJJCADD;
				data.EGBOHDFBAPB_EndDate = array[i].EGBOHDFBAPB;
				data.HPGNBPIBAOM = array[i].HPGNBPIBAOM != 0;
				data.AFHPLBPHEGA = array[i].AFHPLBPHEGA != 0;
				data.HEOLEHDFLJO = array[i].HEOLEHDFLJO;
				data.KLMPFGOCBHC_Desc = array[i].KLMPFGOCBHC;
				data.KGOFMDMDFCJ_BonusId = array[i].KGOFMDMDFCJ;
				data.NNIIINKFDBG_BonusCount = array[i].NNIIINKFDBG;
				data.IHCLFMKAJND = array[i].IHCLFMKAJND;
				data.DLCGAMHADEN_Label = array[i].DLCGAMHADEN;
				data.EILKGEADKGH = array[i].EILKGEADKGH;
				//UnityEngine.Debug.LogError("1 "+data.OPFGFINHFCE_Name+" "+data.DLCGAMHADEN_Label+" "+string.Join(" ", data.KGOFMDMDFCJ_BonusId.ToList()));
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
				//UnityEngine.Debug.LogError("2 "+data.PPFNGGCBJKC_Id+" "+data.PPEGAKEIEGM_Enabled+" "+data.KAPMOPMDHJE_Label+" "+Utility.GetLocalDateTime(data.PDBPFJJCADD_OpenAt).ToLongDateString()+" "+Utility.GetLocalDateTime(data.EGBOHDFBAPB_CloseAt).ToLongDateString());
				DateTime now = DateTime.Now;
				if(data.PPFNGGCBJKC_Id == 2)
				{
					data.PDBPFJJCADD_OpenAt = Utility.GetTargetUnixTime(now.Year, 2, DateTime.DaysInMonth(now.Year, 2), 0, 0, 0);
					data.EGBOHDFBAPB_CloseAt = Utility.GetTargetUnixTime(now.Year, 6, 7, 0, 0, 0);
				}
				else if(data.PPFNGGCBJKC_Id == 3)
				{
					data.PDBPFJJCADD_OpenAt = Utility.GetTargetUnixTime(now.Year, 5, DateTime.DaysInMonth(now.Year, 5), 0, 0, 0);
					data.EGBOHDFBAPB_CloseAt = Utility.GetTargetUnixTime(now.Year, 9, 7, 0, 0, 0);
				}
				else if(data.PPFNGGCBJKC_Id == 4)
				{
					data.PDBPFJJCADD_OpenAt = Utility.GetTargetUnixTime(now.Year, 8, DateTime.DaysInMonth(now.Year, 8), 0, 0, 0);
					data.EGBOHDFBAPB_CloseAt = Utility.GetTargetUnixTime(now.Year, 12, 7, 0, 0, 0);
				}
				else if(data.PPFNGGCBJKC_Id == 5)
				{
					if(now.Month < 4)
					{
						data.PDBPFJJCADD_OpenAt = Utility.GetTargetUnixTime(now.Year, 11, DateTime.DaysInMonth(now.Year, 11), 0, 0, 0);
						data.EGBOHDFBAPB_CloseAt = Utility.GetTargetUnixTime(now.Year + 1, 3, 7, 0, 0, 0);
					}
					else
					{
						data.PDBPFJJCADD_OpenAt = Utility.GetTargetUnixTime(now.Year - 1, 11, DateTime.DaysInMonth(now.Year - 1, 11), 0, 0, 0);
						data.EGBOHDFBAPB_CloseAt = Utility.GetTargetUnixTime(now.Year, 3, 7, 0, 0, 0);
					}
				}
				else if(data.PPFNGGCBJKC_Id == 6 || 
						data.PPFNGGCBJKC_Id == 7 || 
						data.PPFNGGCBJKC_Id == 8 || 
						data.PPFNGGCBJKC_Id == 9 || 
						data.PPFNGGCBJKC_Id == 10 || 
						data.PPFNGGCBJKC_Id == 14 /*New Year*/ ) // Don't enable
				{

				}
				else // 1 (all) & 15 (costume ticket)
				{
					// unlock shop for umo
					data.EGBOHDFBAPB_CloseAt = Utility.GetCurrentUnixTime() + 3600 * 24 * 360;
				}
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
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "DKJMDIFAKKD_VcItem.CAOGDCBPBAN");
		return 0;
	}
}
