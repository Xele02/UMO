
using System;
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HHFFOACILKG_Medal", true)]
public class HHFFOACILKG { }
public class HHFFOACILKG_Medal : DIHHCBACKGG_DbSection
{
	public class HCFJGDFMHOJ
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int NOFECLGOLAI_TypeCrypted; // 0xC
		public int MKHGNAKFPBE; // 0x10
		public int ICKOHEDLEFP_ValueCrypted; // 0x14
		public int HNJHPNPFAAN_EnabledCrypted; // 0x18
		public int GNGNIKNNCNH_MVerCrypted; // 0x1C
		public long DBKJDLJJLLI; // 0x20
		public long OJHEAICHHCI; // 0x28
		public int EAJCFBCHIFB_RarityCrypted; // 0x30

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1757E94 DEMEPMAEJOO_get_id 0x1758FD4 HIGKAIDMOKN_set_id
		// Type
		public int GBJFNGCDKPM_typ { get { return NOFECLGOLAI_TypeCrypted ^ FBGGEFFJJHB_xor; } set { NOFECLGOLAI_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1757CC4 CEJJMKODOGK_get_typ 0x1759070 HOHCEBMMACI_set_typ
		public int IBAKPKKEDJM_month { get { return MKHGNAKFPBE ^ FBGGEFFJJHB_xor; } set { MKHGNAKFPBE = value ^ FBGGEFFJJHB_xor; } } //0x1757F2C IJHAHFOOJKH_get_month 0x175910C LNKIOJGIKMB_set_month
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1759730 OLOCMINKGON_get_val 0x17591A8 ABAFHIBFKCE_set_val
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1757C2C JPCJNLHHIPE_get_en 0x1759244 JJFJNEJLBDG_set_en
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x17597C8 KJIMMIBDCIL_get_mver 0x17592E0 DMEGNOKIKCD_set_mver
		public long AHILKBKLFJM { get { return DBKJDLJJLLI ^ FBGGEFFJJHB_xor; } set { DBKJDLJJLLI = value ^ FBGGEFFJJHB_xor; } } //0x1757D5C BOKMCIGOLOP_get_ 0x175937C HIFMNLCEDCB_set_
		public long ODPMNBBBBIM { get { return OJHEAICHHCI ^ FBGGEFFJJHB_xor; } set { OJHEAICHHCI = value ^ FBGGEFFJJHB_xor; } } //0x1757DF8 GEEHPMGPKOJ_get_ 0x1759420 FAKGBMJFGMM_set_
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1759860 OEEHBGECGKL_get_Rarity 0x17594C4 GHLMHLJJBIG_set_Rarity

		//// RVA: 0x175964C Offset: 0x175964C VA: 0x175964C
		//public uint CAOGDCBPBAN() { }
	}

	public const int PGCIONNCLBI = 16;
	public static int FBGGEFFJJHB_xor = 0xb516d; // 0x0
	public List<HCFJGDFMHOJ> CDENCMNHNGA_table = new List<HCFJGDFMHOJ>(16); // 0x20

	//// RVA: 0x1757718 Offset: 0x1757718 VA: 0x1757718
	public int DNEKJCKEOHL_GetMonthlyItemFullId(long _JHNMKKNEENE_Time)
	{
		DateTime date = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
		for(int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if(CDENCMNHNGA_table[i].PLALNIIBLOF_en == 2)
			{
				if(CDENCMNHNGA_table[i].GBJFNGCDKPM_typ == 1)
				{
					if(CDENCMNHNGA_table[i].AHILKBKLFJM != 0)
					{
						if(CDENCMNHNGA_table[i].ODPMNBBBBIM != 0)
						{
							if(_JHNMKKNEENE_Time >= CDENCMNHNGA_table[i].AHILKBKLFJM)
							{
								if(CDENCMNHNGA_table[i].ODPMNBBBBIM >= _JHNMKKNEENE_Time)
								{
									return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, CDENCMNHNGA_table[i].PPFNGGCBJKC_id);
								}
							}
						}
					}
				}
			}
		}
		for (int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if (CDENCMNHNGA_table[i].PLALNIIBLOF_en == 2)
			{
				if(CDENCMNHNGA_table[i].IBAKPKKEDJM_month == date.Month)
				{
					return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, CDENCMNHNGA_table[i].PPFNGGCBJKC_id);
				}
			}
		}
		return 0;
	}

	//// RVA: 0x1757FC4 Offset: 0x1757FC4 VA: 0x1757FC4
	public long OEMKKJBNIFA(int _PPFNGGCBJKC_id)
	{
		if (_PPFNGGCBJKC_id < 1)
			return 0;
		if(CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].ODPMNBBBBIM == 0)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			DateTime date = Utility.GetLocalDateTime(time);

			return Utility.GetTargetUnixTime(date.Year, CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].IBAKPKKEDJM_month, DateTime.DaysInMonth(date.Year, CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].IBAKPKKEDJM_month), 23, 59, 59);
		}
		return CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].ODPMNBBBBIM;
	}

	//// RVA: 0x17582A4 Offset: 0x17582A4 VA: 0x17582A4
	public string LPHKLEJPKAN(string _FEMMDNIELFC_Desc, int _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id - 1 < CDENCMNHNGA_table.Count)
		{
			if(CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].PLALNIIBLOF_en == 2)
			{
				if(CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].GBJFNGCDKPM_typ == 1)
				{
					DateTime dt = Utility.GetLocalDateTime(OEMKKJBNIFA(_PPFNGGCBJKC_id));
					HCFJGDFMHOJ medal = CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1];
					DateTime dt2 = Utility.GetLocalDateTime(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.LELDGMBGEAO(medal.IBAKPKKEDJM_month));
					string str1 = string.Concat(new string[]
					{
						dt.Year.ToString(),
						"/",
						dt.Month.ToString(),
						"/",
						dt.Day.ToString()
					});
					string str2 = string.Concat(new string[]
					{
						dt2.Year.ToString(),
						"/",
						dt2.Month.ToString(),
						"/",
						dt2.Day.ToString()
					});
					return _FEMMDNIELFC_Desc.Replace("YYYY/MM/DD", str1).Replace("yyyy/mm/dd", str2);
				}
			}
		}
		return "";
	}

	// RVA: 0x1758AD0 Offset: 0x1758AD0 VA: 0x1758AD0
	public HHFFOACILKG_Medal()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 60;
	}

	// RVA: 0x1758BC8 Offset: 0x1758BC8 VA: 0x1758BC8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x1758C40 Offset: 0x1758C40 VA: 0x1758C40 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		CFJBIGCPCAK parser = CFJBIGCPCAK.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		LKGEMHKEBDJ[] array = parser.IKIEMCADPMB;
		for(int i = 0; i < array.Length; i++)
		{
			HCFJGDFMHOJ data = new HCFJGDFMHOJ();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.GBJFNGCDKPM_typ = (int)array[i].GBJFNGCDKPM_typ;
			data.IBAKPKKEDJM_month = (int)array[i].IBAKPKKEDJM_month;
			data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG_val;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.AHILKBKLFJM = array[i].AHILKBKLFJM;
			data.ODPMNBBBBIM = array[i].ODPMNBBBBIM;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x1759560 Offset: 0x1759560 VA: 0x1759560 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0x1759568 Offset: 0x1759568 VA: 0x1759568 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HHFFOACILKG_Medal.CAOGDCBPBAN");
		return 0;
	}
}
