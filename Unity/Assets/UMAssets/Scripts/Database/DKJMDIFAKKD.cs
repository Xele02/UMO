
using System;
using System.Collections.Generic;
using System.Linq;
using XeSys;

[System.Obsolete("Use DKJMDIFAKKD_VcItem", true)]
public class DKJMDIFAKKD { }
[UMOClass()]
public class DKJMDIFAKKD_VcItem : DIHHCBACKGG_DbSection
{
	[UMOClass()]
	public class EBGPAPPHBAH
	{
		[UMOMember()]
		public string[] GLHKICCPGKJ_platform_product_id; // 0x8
		[UMOMember()]
		public string OPFGFINHFCE_name; // 0xC
		[UMOMember()]
		public string OriginalName;
		[UMOMember()]
		public int INDDJNMPONH_type; // 0x10
		[UMOMember()]
		public int HEOLEHDFLJO_ico; // 0x14
		[UMOMember()]
		public int EILKGEADKGH_Order; // 0x18
		[UMOMember()]
		public bool HPGNBPIBAOM_IsBeginner; // 0x1C
		[UMOMember()]
		public bool AFHPLBPHEGA; // 0x1D
		[UMOMember()]
		public long PDBPFJJCADD_open_at; // 0x20
		[UMOMember()]
		public long EGBOHDFBAPB_closed_at; // 0x28
		[UMOMember()]
		public string KLMPFGOCBHC_description; // 0x30
		public int EHOIENNDEDH_IdCrypted; // 0x34
		public int HLMAFFLCCKD_CountCrypted; // 0x38
		public int OJPMOABFGMA; // 0x3C
		[UMOMember()]
		public int IJEKNCDIIAE_mver; // 0x40
		[UMOMember()]
		public int DLCGAMHADEN_Label; // 0x44
		[UMOMember()]
		public int[] KGOFMDMDFCJ_BonusId; // 0x48
		[UMOMember()]
		public int[] NNIIINKFDBG_BonusCount; // 0x4C
		[UMOMember()]
		public int IHCLFMKAJND; // 0x50

		[UMOMember()]
		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1224AA8 DEMEPMAEJOO_get_id 0x1224B40 HIGKAIDMOKN_set_id
		[UMOMember()]
		public int HMFFHLPNMPH_count { get { return HLMAFFLCCKD_CountCrypted ^ FBGGEFFJJHB_xor; } set { HLMAFFLCCKD_CountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1224BDC NJOGDDPICKG_get_count 0x1224C74 NBBGMMBICNA_set_count
		[UMOMember()]
		public int CPGFOBNKKBF_CurrencyId { get { return OJPMOABFGMA ^ FBGGEFFJJHB_xor; } set { OJPMOABFGMA = value ^ FBGGEFFJJHB_xor; } } //0x1224D10 AMNKHCIJHJD_get_CurrencyId 0x1224DA8 INJMDACNFOL_set_CurrencyId

		//// RVA: 0x1224E44 Offset: 0x1224E44 VA: 0x1224E44
		//public uint CAOGDCBPBAN() { }
	}

	[UMOClass()]
	public class BCEMHEAKBCC
	{
		[UMOMember()]
		public int PPEGAKEIEGM_Enabled; // 0x8
		[UMOMember()]
		public int PPFNGGCBJKC_id; // 0xC
		[UMOMember()]
		public int KAPMOPMDHJE_label; // 0x10
		[UMOMember()]
		public long PDBPFJJCADD_open_at; // 0x18
		[UMOMember()]
		public long EGBOHDFBAPB_closed_at; // 0x20
	}

	public const int FLKAGOFMBLI = 15;
	public static int FBGGEFFJJHB_xor = 0xb516d; // 0x0
	[UMOMember()]
	public List<EBGPAPPHBAH> CDENCMNHNGA_table = new List<EBGPAPPHBAH>(15); // 0x20
	[UMOMember()]
	public List<BCEMHEAKBCC> JOBKIDDLCPL_schedules = new List<BCEMHEAKBCC>(); // 0x24

	//// RVA: 0x198FA84 Offset: 0x198FA84 VA: 0x198FA84
	public EBGPAPPHBAH ICGHMMOCJBA(string _PGODOPKCHBD_PlatformProductId, string _OPFGFINHFCE_name, long _JHNMKKNEENE_Time, int _KAPMOPMDHJE_label)
	{
		if (CDENCMNHNGA_table.Count > 0 && !string.IsNullOrEmpty(_PGODOPKCHBD_PlatformProductId))
		{
			for (int i = 0; i < CDENCMNHNGA_table.Count; i++)
			{
				if (CDENCMNHNGA_table[i].INDDJNMPONH_type == 1 && CDENCMNHNGA_table[i].CPGFOBNKKBF_CurrencyId == 1001 && CDENCMNHNGA_table[i].DLCGAMHADEN_Label == _KAPMOPMDHJE_label)
				{
					for (int j = 0; j < CDENCMNHNGA_table[i].GLHKICCPGKJ_platform_product_id.Length; j++)
					{
						if (!string.IsNullOrEmpty(CDENCMNHNGA_table[i].GLHKICCPGKJ_platform_product_id[j]))
						{
							if (CDENCMNHNGA_table[i].GLHKICCPGKJ_platform_product_id[j] == _PGODOPKCHBD_PlatformProductId)
							{
								if (CDENCMNHNGA_table[i].EGBOHDFBAPB_closed_at == 0)
									return CDENCMNHNGA_table[i];
								if (_JHNMKKNEENE_Time >= CDENCMNHNGA_table[i].PDBPFJJCADD_open_at)
									return CDENCMNHNGA_table[i];
								if (CDENCMNHNGA_table[i].EGBOHDFBAPB_closed_at >= _JHNMKKNEENE_Time)
									return CDENCMNHNGA_table[i];
							}
						}
					}
				}
			}
		}
		for (int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if (CDENCMNHNGA_table[i].INDDJNMPONH_type == 1 && CDENCMNHNGA_table[i].CPGFOBNKKBF_CurrencyId == 1001 && CDENCMNHNGA_table[i].DLCGAMHADEN_Label == _KAPMOPMDHJE_label && !string.IsNullOrEmpty(CDENCMNHNGA_table[i].OPFGFINHFCE_name))
			{
				if(_OPFGFINHFCE_name.Contains(CDENCMNHNGA_table[i].OPFGFINHFCE_name))
				{
					if (CDENCMNHNGA_table[i].EGBOHDFBAPB_closed_at == 0)
						return CDENCMNHNGA_table[i];
					if (_JHNMKKNEENE_Time < CDENCMNHNGA_table[i].PDBPFJJCADD_open_at)
						return CDENCMNHNGA_table[i];
					if (CDENCMNHNGA_table[i].EGBOHDFBAPB_closed_at < _JHNMKKNEENE_Time)
						return CDENCMNHNGA_table[i];
				}
			}
		}
		return null;
	}

	//// RVA: 0x198FDE0 Offset: 0x198FDE0 VA: 0x198FDE0
	//public DKJMDIFAKKD_VcItem.EBGPAPPHBAH NHJNPOEKDKK(string _OPFGFINHFCE_name, long _JHNMKKNEENE_Time, int _KAPMOPMDHJE_label) { }

	// RVA: 0x198FF90 Offset: 0x198FF90 VA: 0x198FF90
	public DKJMDIFAKKD_VcItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 88;
	}

	// RVA: 0x19900B0 Offset: 0x19900B0 VA: 0x19900B0 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
		JOBKIDDLCPL_schedules.Clear();
	}

	// RVA: 0x1990154 Offset: 0x1990154 VA: 0x1990154 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		MDFCHKPOMAJ parser = MDFCHKPOMAJ.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		{
			PLCJIGFCOIK[] array = parser.GKBBBINCAGN;
			for(int i = 0; i < array.Length; i++)
			{
				EBGPAPPHBAH data = new EBGPAPPHBAH();
				data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
				data.OPFGFINHFCE_name = DatabaseTextConverter.TranslateVcItemName(i, array[i].OPFGFINHFCE_name);
				data.OriginalName = array[i].OPFGFINHFCE_name;
				data.CPGFOBNKKBF_CurrencyId = array[i].CPGFOBNKKBF_CurrencyId;
				data.GLHKICCPGKJ_platform_product_id = array[i].PDHGIGPAEBG.Split(new char[1] { ',' });
				data.HMFFHLPNMPH_count = array[i].BFINGCJHOHI_cnt;
				data.INDDJNMPONH_type = array[i].GBJFNGCDKPM_typ;
				data.PDBPFJJCADD_open_at = array[i].PDBPFJJCADD_open_at;
				data.EGBOHDFBAPB_closed_at = array[i].EGBOHDFBAPB_closed_at;
				data.HPGNBPIBAOM_IsBeginner = array[i].HPGNBPIBAOM_IsBeginner != 0;
				data.AFHPLBPHEGA = array[i].AFHPLBPHEGA != 0;
				data.HEOLEHDFLJO_ico = array[i].HEOLEHDFLJO_ico;
				data.KLMPFGOCBHC_description = DatabaseTextConverter.TranslateVcItemDesc(i, array[i].KLMPFGOCBHC_description);
				data.KGOFMDMDFCJ_BonusId = array[i].KGOFMDMDFCJ_BonusId;
				data.NNIIINKFDBG_BonusCount = array[i].NNIIINKFDBG_BonusCount;
				data.IHCLFMKAJND = array[i].IHCLFMKAJND;
				data.DLCGAMHADEN_Label = array[i].DLCGAMHADEN_Label;
				data.EILKGEADKGH_Order = array[i].EILKGEADKGH_Order;
				//UnityEngine.Debug.LogError("1 "+data.OPFGFINHFCE_name+" "+data.DLCGAMHADEN_Label+" "+string.Join(" ", data.KGOFMDMDFCJ_BonusId.ToList()));
				CDENCMNHNGA_table.Add(data);
			}
		}
		{
			EGHGEIALECF[] array = parser.CMFJFBJHKPE;
			for(int i = 0; i < array.Length; i++)
			{
				BCEMHEAKBCC data = new BCEMHEAKBCC();
				data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
				data.PPEGAKEIEGM_Enabled = array[i].PLALNIIBLOF_en;
				data.KAPMOPMDHJE_label = array[i].KAPMOPMDHJE_label;
				data.PDBPFJJCADD_open_at = array[i].PDBPFJJCADD_open_at;
				data.EGBOHDFBAPB_closed_at = array[i].EGBOHDFBAPB_closed_at;
				//UnityEngine.Debug.LogError("2 "+data.PPFNGGCBJKC_id+" "+data.PPEGAKEIEGM_Enabled+" "+data.KAPMOPMDHJE_label+" "+Utility.GetLocalDateTime(data.PDBPFJJCADD_open_at).ToLongDateString()+" "+Utility.GetLocalDateTime(data.EGBOHDFBAPB_closed_at).ToLongDateString());

				if(!RuntimeSettings.CurrentSettings.LoadRawDatabase)
				{
					DateTime now = DateTime.Now;
					if(data.PPFNGGCBJKC_id == 2)
					{
						data.PDBPFJJCADD_open_at = Utility.GetTargetUnixTime(now.Year, 2, DateTime.DaysInMonth(now.Year, 2), 0, 0, 0);
						data.EGBOHDFBAPB_closed_at = Utility.GetTargetUnixTime(now.Year, 6, 7, 0, 0, 0);
					}
					else if(data.PPFNGGCBJKC_id == 3)
					{
						data.PDBPFJJCADD_open_at = Utility.GetTargetUnixTime(now.Year, 5, DateTime.DaysInMonth(now.Year, 5), 0, 0, 0);
						data.EGBOHDFBAPB_closed_at = Utility.GetTargetUnixTime(now.Year, 9, 7, 0, 0, 0);
					}
					else if(data.PPFNGGCBJKC_id == 4)
					{
						data.PDBPFJJCADD_open_at = Utility.GetTargetUnixTime(now.Year, 8, DateTime.DaysInMonth(now.Year, 8), 0, 0, 0);
						data.EGBOHDFBAPB_closed_at = Utility.GetTargetUnixTime(now.Year, 12, 7, 0, 0, 0);
					}
					else if(data.PPFNGGCBJKC_id == 5)
					{
						if(now.Month < 4)
						{
							data.PDBPFJJCADD_open_at = Utility.GetTargetUnixTime(now.Year, 11, DateTime.DaysInMonth(now.Year, 11), 0, 0, 0);
							data.EGBOHDFBAPB_closed_at = Utility.GetTargetUnixTime(now.Year + 1, 3, 7, 0, 0, 0);
						}
						else
						{
							data.PDBPFJJCADD_open_at = Utility.GetTargetUnixTime(now.Year - 1, 11, DateTime.DaysInMonth(now.Year - 1, 11), 0, 0, 0);
							data.EGBOHDFBAPB_closed_at = Utility.GetTargetUnixTime(now.Year, 3, 7, 0, 0, 0);
						}
					}
					else if(data.PPFNGGCBJKC_id == 6) //4004 / 4002
					{
						// 6 Kuji Ticket 	2 6 2 5 Tuesday, 13 July 2021 Monday, 30 August 2021
						if(UMOEventList.GetCurrentEvent() != null)
						{
							if(UMOEventList.GetCurrentEvent().EnableBlock("event_box_gacha_a") || UMOEventList.GetCurrentEvent().EnableBlock("event_box_gacha_b") || UMOEventList.GetCurrentEvent().EnableBlock("event_box_gacha_c"))
							{
								data.EGBOHDFBAPB_closed_at = Utility.GetCurrentUnixTime() + 3600 * 24 * 360;
							}
						}
					}
					else if(data.PPFNGGCBJKC_id == 8) //4004 / 4002
					{
						// 8 :				2 8 2 5 Sunday, 26 December 2021 Saturday, 29 January 2022
						if(UMOEventList.GetCurrentEvent() != null)
						{
							if(UMOEventList.GetCurrentEvent().EnableBlock("event_box_gacha_d"))
							{
								data.EGBOHDFBAPB_closed_at = Utility.GetCurrentUnixTime() + 3600 * 24 * 360;
							}
						}
					}
					else if(data.PPFNGGCBJKC_id == 9) //4003
					{
						// 9 : 				2 9 2 7 Friday, 30 July 2021 Monday, 30 August 2021 // 4eme anniversary
						if(UMOEventList.GetCurrentEvent() != null)
						{
							if(UMOEventList.GetCurrentEvent().EnableBlock("event_box_gacha_e") || UMOEventList.GetCurrentEvent().EnableBlock("event_box_gacha_f"))
							{
								data.EGBOHDFBAPB_closed_at = Utility.GetCurrentUnixTime() + 3600 * 24 * 360;
							}
						}
					}
					else if(data.PPFNGGCBJKC_id == 7 || //5002
							data.PPFNGGCBJKC_id == 10 || //2004
							data.PPFNGGCBJKC_id == 14 /*New Year*/ ) // 5001 // Don't enable
					{
						
						// 7 : 				2 7 2 6 Wednesday, 10 November 2021 Saturday, 04 December 2021
						//10 : 44/74 New year SP set 				2 10 2 10 Thursday, 31 December 2020 Sunday, 31 January 2021
						//14 :	45 46 47 New Year Gift					2 14 2 11 Friday, 31 December 2021 Friday, 28 January 2022
					}
					else // 1 (all) & 15 (costume ticket)
					{
						// unlock shop for umo
						data.EGBOHDFBAPB_closed_at = Utility.GetCurrentUnixTime() + 3600 * 24 * 360;
					}
				}
				JOBKIDDLCPL_schedules.Add(data);
			}
		}
		return true;
	}

	// RVA: 0x199081C Offset: 0x199081C VA: 0x199081C Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
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
