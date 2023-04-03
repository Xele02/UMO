
using System;
using System.Collections.Generic;
using System.Text;
using XeSys;

public class JBCAHMMCOKK
{
    public enum ALEKHDPDOEA
    {
        HJNNKCMLGFL = 0,
        NIGFMKCDCNP = 1,
        HMGJAOOGHMM = 2,
        CNCMFECBJHP = 3,
        BPCPDNGLNGO = 4,
        IDAIIJEMNMP = 5,
        NCBMILKEFCF = 6,
        OLJOBADEFGB = 7,
        NHANNKGPAHM = 8,
        KAEBCNOCLPJ = 9,
        FKGINHFBLJE = 10,
        AHJNOIGCCFC = 11,
        OJBBCGGNCKM = 12,
        CPKDCDBLDDG = 13,
        GNLFMDOELFC = 14,
        MGJDKBFHDML = 15,
        GINEDIDMAAO = 16,
        DMPMKBCPHMA = 17,
        KBAKCIJPCAL = 18,
        KOLKHFLCBNP = 19,
        JNFDONGNAGP = 20,
        KJBGPOMJFBE = 21,
        CIGFHJNCKPE = 22,
        BMHJMLDAPCE = 23,
        GFFIILLPAMN = 24,
        OJEHIGOLJAL = 25,
        CADKONMJEDA = 26,
        KCOEIKAMLBD = 27,
    }

    public enum CFBANNFILFK
    {
        HJNNKCMLGFL = 0,
        GFGNICKOBBD = 1,
        GBAFHOOEKEA = 2,
        KKFFEJEKFEG = 3,
    }

    public enum JPLHJHGBMON
    {
        HJNNKCMLGFL = 0,
        CJFFCDKMFFL = 1,
        HDHACKFJKGM = 2,
        NFCADIPMKHK = 3,
        NEKOJOCFHKP = 4,
    }

	public int JLPLLECHHLG; // 0x8
	public ALEKHDPDOEA NNHHNFFLCFO; // 0xC
	public string PIBLLGLCJEO; // 0x10
	public string FEMMDNIELFC; // 0x14
	public long KJBGCLPMLCG; // 0x18
	public long GJFPFFBAKGK; // 0x20
	public int KHLBPICICMN; // 0x28
	public int EAHPLCJMPHD; // 0x2C
	public bool BJIMIONBKDD; // 0x30
	public bool LDLFAKLAMFG; // 0x31
	public bool AKGKKPGAJEM; // 0x32
	public bool OACANKMEKPB; // 0x33
	public CFBANNFILFK ICKKKEIFKJP; // 0x34
	public string PEDBFNIOCEN; // 0x38
	public string IAMFPLLOHFO; // 0x3C
	public int KGICDMIJGDF; // 0x40
	public bool FALOEOOOIHG; // 0x44
	public bool CLDKMLONBHJ; // 0x45
	public JPLHJHGBMON HCAIOHFNCPE; // 0x48
	private bool AOPMODMAANL; // 0x4C
	private bool IPHOLOBDEIK; // 0x4D
	private string KNNDNOKMAOI; // 0x50
	private string HDBPGEMDLDN; // 0x54
	private static List<int> GAGIANMKDLN = new List<int>(32); // 0x0
	private static StringBuilder BEHFKGDKDIP = new StringBuilder(64); // 0x4
	private string[] HAOECMKEBCL = new string[7]
    {
        JpStringLiterals.StringLiteral_1378,
        JpStringLiterals.StringLiteral_1376,
        JpStringLiterals.StringLiteral_11845,
        JpStringLiterals.StringLiteral_11846,
        JpStringLiterals.StringLiteral_11847,
        JpStringLiterals.StringLiteral_11848,
		JpStringLiterals.StringLiteral_11849
    }; // 0x58
	private const int BIAOPOMKMJE = 336675140;

	// public string KJGDDCBFFLC { get; } 0x14165C8 JBJGCFCKPGF
	// public string DMILLPJMDJI { get; } 0x14165D0 DIANNLBLEGL
	// public bool PKPMHFEIBBM { get; } 0x14165D8 OKEACOIMMLG
	// public bool NMDLMMOGDML { get; } 0x14165E0 BCLJEOOEMNG

	// // RVA: 0x14165E8 Offset: 0x14165E8 VA: 0x14165E8
	public string INKBPPLCNFC(long GLMALPMKPGI, long BKLGDPCHDHA, bool ONCBNGJNHMB)
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		//int v = ??;
		DateTime date = Utility.GetLocalDateTime(GLMALPMKPGI);
		DateTime date2 = Utility.GetLocalDateTime(BKLGDPCHDHA);
		if(ONCBNGJNHMB)
		{
			string str = bk.GetMessageByLabel("home_banner_period");
			object o = new object[5] { date2.Year, date2.Month, date2.Day, date2.Hour, date2.Minute };
			return string.Format(str, o);
		}
		else
		{
			string str = bk.GetMessageByLabel("home_popup_event_period");
			object o = new object[12] { date.Year, date.Month, date.Day, HAOECMKEBCL[(int)date.DayOfWeek], date.Hour, date.Minute,
			date2.Year, date2.Month, date2.Day, HAOECMKEBCL[(int)date2.DayOfWeek], date2.Hour, date2.Minute};
			return string.Format(str, o);
		}
	}

	// // RVA: 0x14170DC Offset: 0x14170DC VA: 0x14170DC
	private void ODGNHPFPBKA(long KJBGCLPMLCG, long GJFPFFBAKGK, bool CCJLNAPGDPD, bool NHFJGBKIHIH)
	{
		if (CCJLNAPGDPD)
			KNNDNOKMAOI = INKBPPLCNFC(KJBGCLPMLCG, GJFPFFBAKGK, false);
		if (NHFJGBKIHIH)
			HDBPGEMDLDN = INKBPPLCNFC(KJBGCLPMLCG, GJFPFFBAKGK, true);
	}

	// // RVA: 0x1417164 Offset: 0x1417164 VA: 0x1417164
	// private void DOLLCJMIPJA(long KJBGCLPMLCG, long GJFPFFBAKGK) { }

	// // RVA: 0x14171A0 Offset: 0x14171A0 VA: 0x14171A0
	// private void FBKJFKDNEAM(long KJBGCLPMLCG, long GJFPFFBAKGK) { }

	// // RVA: 0x14171DC Offset: 0x14171DC VA: 0x14171DC
	// private void JBBJMPKIAOI(string LJGOOOMOMMA, bool CCJLNAPGDPD, bool NHFJGBKIHIH) { }

	// // RVA: 0x14171F0 Offset: 0x14171F0 VA: 0x14171F0
	public void KHEKNNFCAOI(int DMBENBAGDON)
	{
		JJCJKALEIAC_HomePickup.COBEFDFGLKA dbPickup = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NFDHMGGLEPN_HomePickup.CDENCMNHNGA[DMBENBAGDON - 1];
		JLPLLECHHLG = dbPickup.PPFNGGCBJKC;
		NNHHNFFLCFO = (ALEKHDPDOEA)dbPickup.GMELAKNFKMG;
		PIBLLGLCJEO = dbPickup.PIBLLGLCJEO;
		FEMMDNIELFC = dbPickup.FEMMDNIELFC;
		KJBGCLPMLCG = dbPickup.PDBPFJJCADD;
		GJFPFFBAKGK = dbPickup.FDBNFFNFOND;
		KHLBPICICMN = dbPickup.DAPGDCPDCNA;
		EAHPLCJMPHD = dbPickup.KNHOMNONOEB;
		HCAIOHFNCPE = (JPLHJHGBMON)dbPickup.OFMECFHNCHA;
		BJIMIONBKDD = dbPickup.OFMECFHNCHA != 0;
		LDLFAKLAMFG = dbPickup.JOPPFEHKNFO != 0;
		ICKKKEIFKJP = 0;
		AKGKKPGAJEM = dbPickup.ODOAFNMJIMA != 0;
		IAMFPLLOHFO = dbPickup.AOBNHHIIJBO;
		OACANKMEKPB = dbPickup.ADHCKHFANAL != 0;
		KGICDMIJGDF = dbPickup.KGICDMIJGDF;
		FALOEOOOIHG = false;
		IPHOLOBDEIK = dbPickup.KLHGOPBIOCN != 0;
		AOPMODMAANL = dbPickup.KLHGOPBIOCN != 0;
		KNNDNOKMAOI = "";
		HDBPGEMDLDN = "";
		if(!AKGKKPGAJEM)
		{
			if (dbPickup.ADHCKHFANAL == 1)
				ICKKKEIFKJP = CFBANNFILFK.GFGNICKOBBD/*1*/;
			else if(dbPickup.ADHCKHFANAL == 2)
				ICKKKEIFKJP = CFBANNFILFK.GBAFHOOEKEA/*2*/;
			else if (dbPickup.ADHCKHFANAL == 3)
				ICKKKEIFKJP = CFBANNFILFK.KKFFEJEKFEG/*3*/;
		}
		else
		{
			if(dbPickup.ODOAFNMJIMA == 1)
				ICKKKEIFKJP = CFBANNFILFK.GFGNICKOBBD/*1*/;
			else if (dbPickup.ODOAFNMJIMA == 2)
				ICKKKEIFKJP = CFBANNFILFK.GBAFHOOEKEA/*2*/;
		}
	}

	// // RVA: 0x14176A8 Offset: 0x14176A8 VA: 0x14176A8
	// public bool HLMIOEGBAKJ() { }

	// // RVA: 0x14176C4 Offset: 0x14176C4 VA: 0x14176C4
	public static List<JBCAHMMCOKK> FKDIMODKKJD(bool DKLOGCOPPKJ = false)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		DateTime date = Utility.GetLocalDateTime(time);
		List<JBCAHMMCOKK> res = new List<JBCAHMMCOKK>();
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NFDHMGGLEPN_HomePickup.CDENCMNHNGA.Count; i++)
		{
			HEGEKFMJNCC(res, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NFDHMGGLEPN_HomePickup.CDENCMNHNGA[i], time, (int)date.DayOfWeek);
		}
		res = HGBCHAIAKGC(res);
		AKIFCOIDAHD(res);
		Algorithms.InsertSort(res, (JBCAHMMCOKK HKICMNAACDA, JBCAHMMCOKK BNKHBCBJBKI) => {
			//0x14204EC
			if(HKICMNAACDA.KHLBPICICMN == BNKHBCBJBKI.KHLBPICICMN)
				return BNKHBCBJBKI.KJBGCLPMLCG.CompareTo(HKICMNAACDA.KJBGCLPMLCG);
			return HKICMNAACDA.KHLBPICICMN.CompareTo(BNKHBCBJBKI.KHLBPICICMN);
		});
		return res;
	}

	// // RVA: 0x1417AC4 Offset: 0x1417AC4 VA: 0x1417AC4
	private static void HEGEKFMJNCC(List<JBCAHMMCOKK> NNDGIAEFMOG, JJCJKALEIAC_HomePickup.COBEFDFGLKA KOGBMDOONFA, long JHNMKKNEENE, int DHABOCGMFLN)
	{
		if (KOGBMDOONFA.PPEGAKEIEGM_Enabled != 2)
			return;
		bool b = true;
		int level = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
		if (KOGBMDOONFA.JPKPDCCGGLA > 0)
			b = KOGBMDOONFA.JPKPDCCGGLA < level;
		bool c = true;
		if (KOGBMDOONFA.AMKJDECHIOF > 0)
			b = KOGBMDOONFA.AMKJDECHIOF < level;
		if(KOGBMDOONFA.PDBPFJJCADD != 0)
		{
			if(KOGBMDOONFA.FDBNFFNFOND != 0)
			{
				if (JHNMKKNEENE < KOGBMDOONFA.PDBPFJJCADD)
					return;
				if (JHNMKKNEENE >= KOGBMDOONFA.FDBNFFNFOND)
					return;
			}
		}
		if (!c)
			return;
		switch(KOGBMDOONFA.GMELAKNFKMG)
		{
			case 0:
				{
					JBCAHMMCOKK d = new JBCAHMMCOKK();
					d.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
					d.ODGNHPFPBKA(KOGBMDOONFA.PDBPFJJCADD, KOGBMDOONFA.FDBNFFNFOND, d.AOPMODMAANL, d.IPHOLOBDEIK);
					NNDGIAEFMOG.Add(d);
				}
				break;
			case 1:
			case 2:
			case 3:
			case 15:
				{
					JBCAHMMCOKK d = new JBCAHMMCOKK();
					d.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
					NNDGIAEFMOG.Add(d);
				}
				break;
			default:
				TodoLogger.Log(0, "HEGEKFMJNCC "+ KOGBMDOONFA.GMELAKNFKMG);
				break;
		}
	}

	// // RVA: 0x141F600 Offset: 0x141F600 VA: 0x141F600
	// private static List<int> FNDEJKMGFFO(string GDPKOJKDMNL, string PIBLLGLCJEO) { }

	// // RVA: 0x141F3AC Offset: 0x141F3AC VA: 0x141F3AC
	// private static bool GIALIHIMGAJ(List<LOBDIAABMKG> NNDGIAEFMOG, int FDEBLMKEMLF, int HHIBBHFHENH) { }

	// // RVA: 0x141FA08 Offset: 0x141FA08 VA: 0x141FA08
	// public static void CKGGMNGAMLC(List<JBCAHMMCOKK> NNDGIAEFMOG) { }

	// // RVA: 0x141E328 Offset: 0x141E328 VA: 0x141E328
	private static void AKIFCOIDAHD(List<JBCAHMMCOKK> NNDGIAEFMOG)
	{
		TodoLogger.Log(0, "AKIFCOIDAHD");
	}

	// // RVA: 0x142025C Offset: 0x142025C VA: 0x142025C
	private static List<int> JCGOHOJCNLE(List<JBCAHMMCOKK> NNDGIAEFMOG, int KGICDMIJGDF)
	{
		List<int> l = new List<int>();
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].KGICDMIJGDF == KGICDMIJGDF)
			{
				l.Add(i);
			}
		}
		return l;
	}

	// // RVA: 0x141DA84 Offset: 0x141DA84 VA: 0x141DA84
	private static List<JBCAHMMCOKK> HGBCHAIAKGC(List<JBCAHMMCOKK> NNDGIAEFMOG)
	{
		List<int> l = new List<int>();
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			int a = NNDGIAEFMOG[i].KGICDMIJGDF;
			if(a > 0)
			{
				int idx = l.FindIndex((int GHPLINIACBB) =>
				{
					//0x1420628
					return a == GHPLINIACBB;
				});
				if(idx < 0)
				{
					l.Add(a);
				}
			}
		}
		for(int i = 0; i < l.Count; i++)
		{
			List<int> l2 = JCGOHOJCNLE(NNDGIAEFMOG, l[i]);
			if (l2.Count > 0)
			{
				if (l[i] >= 1000 && ((l[i] - 1000) >> 3) < 125)
				{
					int a = 100000000;
					int b = -1;
					for(int j = 0; j < l2.Count; j++)
					{
						if(NNDGIAEFMOG[l2[j]].KHLBPICICMN < a)
						{
							a = NNDGIAEFMOG[l2[j]].KHLBPICICMN;
							b = j;
						}
					}
					for(int j = 0; j < l2.Count; j++)
					{
						if(j != b)
						{
							NNDGIAEFMOG[l2[j]].BJIMIONBKDD = false;
							NNDGIAEFMOG[l2[j]].LDLFAKLAMFG = false;
						}
					}
				}
				else if(l[i] > 2000 && ((l[i] - 2000) >> 3) < 125)
				{
					int a = UnityEngine.Random.Range(0, l2.Count);
					for(int j = 0; j < l2.Count; j++)
					{
						if(j != a)
						{
							NNDGIAEFMOG[l2[j]].BJIMIONBKDD = false;
							NNDGIAEFMOG[l2[j]].LDLFAKLAMFG = false;
						}
					}
				}
			}
		}
		List<JBCAHMMCOKK> res = new List<JBCAHMMCOKK>();
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].BJIMIONBKDD || NNDGIAEFMOG[i].LDLFAKLAMFG)
			{
				res.Add(NNDGIAEFMOG[i]);
			}
		}
		return res;
	}
}
