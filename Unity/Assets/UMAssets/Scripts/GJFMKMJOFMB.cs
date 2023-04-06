
using System.Collections.Generic;

public class GJFMKMJOFMB
{
	public class OJIMKCKABGE
	{
		public int BAOFEFFADPD; // 0x8
		public int MKPJBDFDHOL; // 0xC
		public int BOEJGNAHPII; // 0x10
		public bool LNACKEBEMOB; // 0x14
		public List<MFDJIFIIPJD> HBHMAKNGKFK; // 0x18
		public List<MFDJIFIIPJD> OBGHDLKKMLJ; // 0x1C
	}

	public List<OJIMKCKABGE> CKPIHCGOEDP = new List<OJIMKCKABGE>(); // 0x8
	public List<OJIMKCKABGE> NNBGGBOHLHI = new List<OJIMKCKABGE>(); // 0xC
	public bool LHLPHHBAHNO; // 0x10
	public int AKBNPKGJMDN; // 0x14
	public int PBBLOJPOLJG; // 0x18
	public int PCLCKJGCPEE; // 0x1C
	public int HONLONNHJBP; // 0x20
	public bool KLMNKBCDGPI; // 0x24
	public int BBDNDNHJEKJ; // 0x28
	public int CFNFKIIOOHC; // 0x2C
	public bool ENHGKPMEICN; // 0x30
	public int OOHJDAPDCMH; // 0x34
	public bool HNNAJBJCNEJ; // 0x38

	// RVA: 0xAAC434 Offset: 0xAAC434 VA: 0xAAC434
	public void KHEKNNFCAOI(bool JHOJAGMJABJ, bool IEABEILIGPO = false)
	{
		if(IEABEILIGPO)
		{
			HNNAJBJCNEJ = true;
			for(int i = 0; i < NHPDPKHMFEP.HHCJCDFCLOB.LKNKNKAALJO.Count; i++)
			{
				TodoLogger.Log(0, "KHEKNNFCAOI");
			}
			NHPDPKHMFEP.HHCJCDFCLOB.LKNKNKAALJO.Clear();
		}
		else
		{
			HNNAJBJCNEJ = NHPDPKHMFEP.HHCJCDFCLOB.ENAAHAPDMCO();
			if(HNNAJBJCNEJ)
			{
				HNNAJBJCNEJ = true;
				for (int i = 0; i < NHPDPKHMFEP.HHCJCDFCLOB.LKNKNKAALJO.Count; i++)
				{
					TodoLogger.Log(0, "KHEKNNFCAOI");
				}
				NHPDPKHMFEP.HHCJCDFCLOB.LKNKNKAALJO.Clear();
			}
		}
		LHLPHHBAHNO = false;
		CKPIHCGOEDP.Clear();
		NNBGGBOHLHI.Clear();
		OOHJDAPDCMH = 0;
		int a = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.FLBJKACKNOI_CurStamp;
		if (a == 0)
			a = 1;
		OOHJDAPDCMH = ELCNECGFGAO(CKPIHCGOEDP, a, HNNAJBJCNEJ) - 1;
		a = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.FLBJKACKNOI_CurStamp;
		if (a != 0)
			a--;
		if(a == 0)
		{
			a = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.EOHPPNNLBNH_Stamp.Count;
		}
		int b = ELCNECGFGAO(NNBGGBOHLHI, a, HNNAJBJCNEJ);
		if(OOHJDAPDCMH + 1 == 0 && b == 20 && JHOJAGMJABJ)
		{
			LHLPHHBAHNO = true;
			OOHJDAPDCMH = 19;
		}
		PCLCKJGCPEE = 0;
		PBBLOJPOLJG = 0;
		HONLONNHJBP = 0;
		AKBNPKGJMDN = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem, 1);
		KLMNKBCDGPI = false;
		if(JHOJAGMJABJ)
		{
			int rareup_1st_day = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("rareup_1st_day", 30);
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.HKABHJKHFKL_RareGetCnt != 1 || CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.FCPHDFKFDCK_LoginCnt != rareup_1st_day)
			{
				//LAB_00aaca34
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.HKABHJKHFKL_RareGetCnt >= 2 && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.FCPHDFKFDCK_LoginCnt == 0)
				{
					KLMNKBCDGPI = true;
					PBBLOJPOLJG = 1;
					PCLCKJGCPEE = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.HKABHJKHFKL_RareGetCnt;
				}
			}
			else
			{
				KLMNKBCDGPI = true;
				PBBLOJPOLJG = 1;
				PCLCKJGCPEE = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.HKABHJKHFKL_RareGetCnt;
			}
		}
		//LAB_00aacaa8
		int d = 0;
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.HKABHJKHFKL_RareGetCnt == 0)
		{
			d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("rareup_1st_day", 30);
		}
		else
		{
			d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("rareup_2nd_day", 90);
		}
		HONLONNHJBP = 0;
		if (d - CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.FCPHDFKFDCK_LoginCnt > 0)
		{
			HONLONNHJBP = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.FCPHDFKFDCK_LoginCnt;
		}
	}

	//// RVA: 0xAACBA0 Offset: 0xAACBA0 VA: 0xAACBA0
	private int ELCNECGFGAO(List<OJIMKCKABGE> NNDGIAEFMOG, int FDGBLNFGBPJ, bool HNNAJBJCNEJ)
	{
		LGIDLHLBFFJ_MonthlyPass.ODHIHCNALDL savePass = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.EOHPPNNLBNH_Stamp[FDGBLNFGBPJ - 1];
		int res = 0;
		for(int i = 0; i < 20; i++)
		{
			int tId = savePass.JJPDPNJFBHN_TableId;
			if (tId == 0)
			{
				tId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.IPAOPMEFJKD_StartTableId;
			}
			KBCCGHLCFNO_MonthlyPass.JKGFAIPDNDL dbPass = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.DHBEKJNJOMC(tId, i + 1);
			OJIMKCKABGE data = new OJIMKCKABGE();
			data.BAOFEFFADPD = i + 1;
			data.MKPJBDFDHOL = dbPass.HNHOGHMLFNL;
			data.BOEJGNAHPII = dbPass.PHHBIBOJAEI;
			data.LNACKEBEMOB = savePass.LPGIECKPBDK(i) != 0;
			data.HBHMAKNGKFK = new List<MFDJIFIIPJD>();
			data.OBGHDLKKMLJ = new List<MFDJIFIIPJD>();
			if (savePass.LPGIECKPBDK(i) != 0)
				res++;
			for(int k = 0; k < dbPass.DMNJMOBEGLM(); k++)
			{
				MFDJIFIIPJD data2 = new MFDJIFIIPJD();
				data2.KHEKNNFCAOI(dbPass.FKNBLDPIPMC(k), dbPass.KAINPNMMAEK(k));
				data.HBHMAKNGKFK.Add(data2);
			}
			if(HNNAJBJCNEJ)
			{
				for(int k = 0; k < dbPass.EGBJFDGDMLG(); k++)
				{
					int a = dbPass.CNJELJGBCKC(k);
					MFDJIFIIPJD data2 = data.HBHMAKNGKFK.Find((MFDJIFIIPJD GHPLINIACBB) =>
					{
						//0xAAD358
						return GHPLINIACBB.JJBGOIMEIPF_ItemFullId == a;
					});
					if(data2 == null)
					{
						data2 = new MFDJIFIIPJD();
						data2.KHEKNNFCAOI(dbPass.CNJELJGBCKC(k), dbPass.ACPIBCALPEH(k));
						data.OBGHDLKKMLJ.Add(data2);
					}
					else
					{
						data2.MBJIFDBEDAC_Cnt += dbPass.ACPIBCALPEH(k);
					}
				}
			}
			NNDGIAEFMOG.Add(data);
		}
		return res;
	}
}
