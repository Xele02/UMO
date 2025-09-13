
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
		public int NOFECLGOLAI; // 0xC
		public int MKHGNAKFPBE; // 0x10
		public int ICKOHEDLEFP; // 0x14
		public int HNJHPNPFAAN; // 0x18
		public int GNGNIKNNCNH_MVerCrypted; // 0x1C
		public long DBKJDLJJLLI; // 0x20
		public long OJHEAICHHCI; // 0x28
		public int EAJCFBCHIFB_RarityCrypted; // 0x30

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1757E94 DEMEPMAEJOO 0x1758FD4 HIGKAIDMOKN
		public int GBJFNGCDKPM_Type { get { return NOFECLGOLAI ^ FBGGEFFJJHB_xor; } set { NOFECLGOLAI = value ^ FBGGEFFJJHB_xor; } } //0x1757CC4 CEJJMKODOGK 0x1759070 HOHCEBMMACI
		public int IBAKPKKEDJM_Month { get { return MKHGNAKFPBE ^ FBGGEFFJJHB_xor; } set { MKHGNAKFPBE = value ^ FBGGEFFJJHB_xor; } } //0x1757F2C IJHAHFOOJKH 0x175910C LNKIOJGIKMB
		public int JBGEEPFKIGG { get { return ICKOHEDLEFP ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB_xor; } } //0x1759730 OLOCMINKGON 0x17591A8 ABAFHIBFKCE
		public int PLALNIIBLOF_Enabled { get { return HNJHPNPFAAN ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB_xor; } } //0x1757C2C JPCJNLHHIPE 0x1759244 JJFJNEJLBDG
		public int IJEKNCDIIAE { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x17597C8 KJIMMIBDCIL 0x17592E0 DMEGNOKIKCD
		public long AHILKBKLFJM { get { return DBKJDLJJLLI ^ FBGGEFFJJHB_xor; } set { DBKJDLJJLLI = value ^ FBGGEFFJJHB_xor; } } //0x1757D5C BOKMCIGOLOP 0x175937C HIFMNLCEDCB
		public long ODPMNBBBBIM { get { return OJHEAICHHCI ^ FBGGEFFJJHB_xor; } set { OJHEAICHHCI = value ^ FBGGEFFJJHB_xor; } } //0x1757DF8 GEEHPMGPKOJ 0x1759420 FAKGBMJFGMM
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1759860 OEEHBGECGKL 0x17594C4 GHLMHLJJBIG

		//// RVA: 0x175964C Offset: 0x175964C VA: 0x175964C
		//public uint CAOGDCBPBAN() { }
	}

	public const int PGCIONNCLBI = 16;
	public static int FBGGEFFJJHB_xor = 0xb516d; // 0x0
	public List<HCFJGDFMHOJ> CDENCMNHNGA_table = new List<HCFJGDFMHOJ>(16); // 0x20

	//// RVA: 0x1757718 Offset: 0x1757718 VA: 0x1757718
	public int DNEKJCKEOHL_GetMonthlyItemFullId(long JHNMKKNEENE)
	{
		DateTime date = Utility.GetLocalDateTime(JHNMKKNEENE);
		for(int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if(CDENCMNHNGA_table[i].PLALNIIBLOF_Enabled == 2)
			{
				if(CDENCMNHNGA_table[i].GBJFNGCDKPM_Type == 1)
				{
					if(CDENCMNHNGA_table[i].AHILKBKLFJM != 0)
					{
						if(CDENCMNHNGA_table[i].ODPMNBBBBIM != 0)
						{
							if(JHNMKKNEENE >= CDENCMNHNGA_table[i].AHILKBKLFJM)
							{
								if(CDENCMNHNGA_table[i].ODPMNBBBBIM >= JHNMKKNEENE)
								{
									return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, CDENCMNHNGA_table[i].PPFNGGCBJKC);
								}
							}
						}
					}
				}
			}
		}
		for (int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if (CDENCMNHNGA_table[i].PLALNIIBLOF_Enabled == 2)
			{
				if(CDENCMNHNGA_table[i].IBAKPKKEDJM_Month == date.Month)
				{
					return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, CDENCMNHNGA_table[i].PPFNGGCBJKC);
				}
			}
		}
		return 0;
	}

	//// RVA: 0x1757FC4 Offset: 0x1757FC4 VA: 0x1757FC4
	public long OEMKKJBNIFA(int PPFNGGCBJKC)
	{
		if (PPFNGGCBJKC < 1)
			return 0;
		if(CDENCMNHNGA_table[PPFNGGCBJKC - 1].ODPMNBBBBIM == 0)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			DateTime date = Utility.GetLocalDateTime(time);

			return Utility.GetTargetUnixTime(date.Year, CDENCMNHNGA_table[PPFNGGCBJKC - 1].IBAKPKKEDJM_Month, DateTime.DaysInMonth(date.Year, CDENCMNHNGA_table[PPFNGGCBJKC - 1].IBAKPKKEDJM_Month), 23, 59, 59);
		}
		return CDENCMNHNGA_table[PPFNGGCBJKC - 1].ODPMNBBBBIM;
	}

	//// RVA: 0x17582A4 Offset: 0x17582A4 VA: 0x17582A4
	public string LPHKLEJPKAN(string _FEMMDNIELFC_Desc, int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC - 1 < CDENCMNHNGA_table.Count)
		{
			if(CDENCMNHNGA_table[PPFNGGCBJKC - 1].PLALNIIBLOF_Enabled == 2)
			{
				if(CDENCMNHNGA_table[PPFNGGCBJKC - 1].GBJFNGCDKPM_Type == 1)
				{
					DateTime dt = Utility.GetLocalDateTime(OEMKKJBNIFA(PPFNGGCBJKC));
					HCFJGDFMHOJ medal = CDENCMNHNGA_table[PPFNGGCBJKC - 1];
					DateTime dt2 = Utility.GetLocalDateTime(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.LELDGMBGEAO(medal.IBAKPKKEDJM_Month));
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
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x1758C40 Offset: 0x1758C40 VA: 0x1758C40 Slot: 9
	public override bool IIEMACPEEBJ(byte[] _DBBGALAPFGC_Data)
	{
		CFJBIGCPCAK parser = CFJBIGCPCAK.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		LKGEMHKEBDJ[] array = parser.IKIEMCADPMB;
		for(int i = 0; i < array.Length; i++)
		{
			HCFJGDFMHOJ data = new HCFJGDFMHOJ();
			data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
			data.GBJFNGCDKPM_Type = (int)array[i].GBJFNGCDKPM;
			data.IBAKPKKEDJM_Month = (int)array[i].IBAKPKKEDJM;
			data.JBGEEPFKIGG = (int)array[i].JBGEEPFKIGG;
			data.PLALNIIBLOF_Enabled = (int)array[i].PLALNIIBLOF;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.AHILKBKLFJM = array[i].AHILKBKLFJM;
			data.ODPMNBBBBIM = array[i].ODPMNBBBBIM;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x1759560 Offset: 0x1759560 VA: 0x1759560 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
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
