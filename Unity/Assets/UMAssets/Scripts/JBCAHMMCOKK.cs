
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XeSys;

public class JBCAHMMCOKK
{
    public enum ALEKHDPDOEA
    {
        HJNNKCMLGFL = 0,
        NIGFMKCDCNP = 1,
        HMGJAOOGHMM_2 = 2,
        CNCMFECBJHP_3 = 3,
        BPCPDNGLNGO_4 = 4,
        IDAIIJEMNMP_5 = 5,
        NCBMILKEFCF_6 = 6,
        OLJOBADEFGB_7 = 7,
        NHANNKGPAHM_8 = 8,
        KAEBCNOCLPJ_9 = 9,
        FKGINHFBLJE_10 = 10,
        AHJNOIGCCFC_11 = 11,
        OJBBCGGNCKM = 12,
        CPKDCDBLDDG = 13,
        GNLFMDOELFC = 14,
        MGJDKBFHDML_15 = 15,
        GINEDIDMAAO_16 = 16,
        DMPMKBCPHMA_17 = 17,
        KBAKCIJPCAL_18 = 18,
        KOLKHFLCBNP_19 = 19,
        JNFDONGNAGP_20 = 20,
        KJBGPOMJFBE_21 = 21,
        CIGFHJNCKPE_22 = 22,
        BMHJMLDAPCE_23 = 23,
        GFFIILLPAMN = 24,
        OJEHIGOLJAL = 25,
        CADKONMJEDA_26 = 26,
        KCOEIKAMLBD_27 = 27,
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
	public long KJBGCLPMLCG_OpenedAt; // 0x18
	public long GJFPFFBAKGK_CloseAt; // 0x20
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
	public string DMILLPJMDJI { get { return HDBPGEMDLDN; } } //0x14165D0 DIANNLBLEGL
	// public bool PKPMHFEIBBM { get; } 0x14165D8 OKEACOIMMLG
	public bool NMDLMMOGDML { get { return IPHOLOBDEIK; } } //0x14165E0 BCLJEOOEMNG

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
			object[] o = new object[5] { date2.Year, date2.Month, date2.Day, date2.Hour, date2.Minute };
			return string.Format(str, o);
		}
		else
		{
			string str = bk.GetMessageByLabel("home_popup_event_period");
			object[] o = new object[12] { date.Year, date.Month, date.Day, HAOECMKEBCL[(int)date.DayOfWeek], date.Hour, date.Minute,
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
		KJBGCLPMLCG_OpenedAt = dbPickup.PDBPFJJCADD;
		GJFPFFBAKGK_CloseAt = dbPickup.FDBNFFNFOND;
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
				return BNKHBCBJBKI.KJBGCLPMLCG_OpenedAt.CompareTo(HKICMNAACDA.KJBGCLPMLCG_OpenedAt);
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
			c = KOGBMDOONFA.AMKJDECHIOF < level;
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
		bool doSp = false;
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
			case 4:
				{
					for(int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
					{
						IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
						if(ev != null)
						{
							ev.HCDGELDHFHB_UpdateStatus(JHNMKKNEENE);
							if(ev.HIDHLFCBIDE_EventType > OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby || 
								(((1 << (int)ev.HIDHLFCBIDE_EventType) & 0x2f90U) == 0))
							{
								if(ev.HJPNJBCJPNJ(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI/*6*/))
								{
									JBCAHMMCOKK data = new JBCAHMMCOKK();
									data.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
									data.EAHPLCJMPHD = ev.PGIIDPEGGPI_EventId;
									data.PEDBFNIOCEN = ev.JOPOPMLFINI;
									data.KJBGCLPMLCG_OpenedAt = ev.GLIMIGNNGGB_Start;
									data.GJFPFFBAKGK_CloseAt = ev.DPJCPDKALGI_End1;
									data.KNNDNOKMAOI = data.INKBPPLCNFC(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, false);
									data.HDBPGEMDLDN = data.INKBPPLCNFC(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, true);
									if (!b)
										data.BJIMIONBKDD = false;
									if (ev.NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI/*6*/)
										data.BJIMIONBKDD = false;
									NNDGIAEFMOG.Add(data);
								}
							}
						}
					}
				}
				break;
			case 5:
				{
					int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NCEMAEDMJLO_GetBeginnerGachaVersion(JHNMKKNEENE);
					if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BKCJPIPJCCM_StaminaLotDone == a)
						return;
					List<LOBDIAABMKG> l = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts;
					for (int i = 0; i < l.Count; i++)
					{
						if(l[i].KNMLPAAHAOF_IsStartGacha && l[i].INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3)
						{
							JBCAHMMCOKK data = new JBCAHMMCOKK();
							data.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
							if(!b)
								data.BJIMIONBKDD = false;
							data.FEMMDNIELFC = l[i].KLMPFGOCBHC_Description;
							data.EAHPLCJMPHD = l[i].FDEBLMKEMLF_TypeAndSeriesId;
							NNDGIAEFMOG.Add(data);
						}
					}
				}
				break;
			case 6:
				{
					for(int i = 0; i < NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts.Count; i++)
					{
                        LOBDIAABMKG p = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts[i];
                        if (p.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.JGDEHOGIENP_4)
						{
							JBCAHMMCOKK data = new JBCAHMMCOKK();
							data.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
							KBPDNHOKEKD_ProductId product = p.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1);
							if(product != null)
							{
								if(!b)
									data.BJIMIONBKDD = false;
								if(p.MEBKAHGMING_HasNewEpisode)
									data.BJIMIONBKDD = false;
								data.KJBGCLPMLCG_OpenedAt = p.KJBGCLPMLCG_OpenedAt;
								data.GJFPFFBAKGK_CloseAt = p.GJFPFFBAKGK_CloseAt;
								if(p.KACECFNECON != null)
								{
									if(p.KACECFNECON.JOFAGCFNKIO_OpenTime != 0)
									{
										data.KJBGCLPMLCG_OpenedAt = p.KACECFNECON.JOFAGCFNKIO_OpenTime;
									}
									data.IPHOLOBDEIK = !p.IMCNDJMDNJE_DisableCarousel;
								}
								data.ODGNHPFPBKA(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, true, data.IPHOLOBDEIK);
								data.EAHPLCJMPHD = p.FDEBLMKEMLF_TypeAndSeriesId;
								data.FEMMDNIELFC = p.KLMPFGOCBHC_Description;
								NNDGIAEFMOG.Add(data);
							}
						}
					}
				}
				break;
			case 7:
				{
					string s = KOGBMDOONFA.PIBLLGLCJEO;
					string[] ss = s.Split(new char[] { ',' });
					List<int> l = new List<int>();
					for(int i = 0; i < ss.Length; i++)
					{
						int a = 0;
						if(int.TryParse(ss[i], out a))
						{
							l.Add(a);
						}
					}
					if (EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI.Count < 1)
						return;
					TodoLogger.LogError(0, "HEGEKFMJNCC 7");
				}
				break;
			case 8:
				{
					if (FKMOKDCJFEN.KFHCJLFAHAG() == null)
						return;
					TodoLogger.LogError(0, "HEGEKFMJNCC 8");
				}
				break;
			case 9:
				{
					IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI/*6*/);
					if (ev == null)
						return;
					TodoLogger.LogError(0, "HEGEKFMJNCC 9 event");
				}
				break;
			case 10:
				{
					int a = 0;
					if (!int.TryParse(KOGBMDOONFA.PIBLLGLCJEO, out a) || a != DHABOCGMFLN)
						return;
					List<IBJAKJJICBC> l = IBJAKJJICBC.FKDIMODKKJD(5, JHNMKKNEENE, true, false, false, false);
					for(int i = 0; i < l.Count; i++)
					{
						if(l[i].LHONOILACFL_IsWeeklyEvent)
						{
							if(l[i].BELHFPMBAPJ_WeekPlay < l[i].JOJNGDPHOKG)
							{
								JBCAHMMCOKK data = new JBCAHMMCOKK();
								data.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
								if(!b)
								{
									data.BJIMIONBKDD = false;
								}
								NNDGIAEFMOG.Add(data);
								break;
							}
						}
					}
				}
				break;
			case 11:
				{
					List<int> l3 = new List<int>();
					l3.Clear();
					IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp/*7*/, KGCNCBOKCBA.GNENJEHKMHD.BCKENOKGLIJ_9/*9*/);
					if (ev != null)
					{
						TodoLogger.LogError(0, "HEGEKFMJNCC 11 event");
					}
					List<int> l2 = FNDEJKMGFFO("type", KOGBMDOONFA.PIBLLGLCJEO);
					for(int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
					{
						IKDICBBFBMI_EventBase ev2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
						if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MLKAJEDCPLP(ev2.PGIIDPEGGPI_EventId))
						{
							int idx = l2.FindIndex((int GHPLINIACBB) =>
							{
								//0x14205AC
								return (int)ev2.HIDHLFCBIDE_EventType == GHPLINIACBB;
							});
							if(idx > -1)
							{
								int idx2 = l3.FindIndex((int GHPLINIACBB) =>
								{
									//0x14205F4
									return ev2.PGIIDPEGGPI_EventId == GHPLINIACBB;
								});
								if(idx2 < 0)
								{
									JBCAHMMCOKK data = new JBCAHMMCOKK();
									data.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
									if(!b)
									{
										data.BJIMIONBKDD = false;
									}
									data.EAHPLCJMPHD = ev2.PGIIDPEGGPI_EventId;
									data.PEDBFNIOCEN = ev2.JOPOPMLFINI;
									data.KJBGCLPMLCG_OpenedAt = ev2.GLIMIGNNGGB_Start;
									data.GJFPFFBAKGK_CloseAt = ev2.DPJCPDKALGI_End1;
									data.HDBPGEMDLDN = MessageManager.Instance.GetMessage("menu", "home_event_epilogue");
									data.IPHOLOBDEIK = true;
									data.PIBLLGLCJEO = ev2.CAKEOPLJDAF.ToString();
									NNDGIAEFMOG.Add(data);
								}
							}
						}
					}
				}
				break;
			case 12: // 0xc
				{
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
					if(!b)
					{
						j.BJIMIONBKDD = false;
					}
					j.NNHHNFFLCFO = ALEKHDPDOEA.HMGJAOOGHMM_2/*2*/;
					NNDGIAEFMOG.Add(j);
					return;
				}
				break;
			case 13: // 0xd
				{
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
					if (!b)
					{
						j.BJIMIONBKDD = false;
					}
					j.NNHHNFFLCFO = ALEKHDPDOEA.HMGJAOOGHMM_2/*2*/;
					NNDGIAEFMOG.Add(j);
					return;
				}
			case 14: // 0xe
				{
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
					if (!b)
					{
						j.BJIMIONBKDD = false;
					}
					j.NNHHNFFLCFO = ALEKHDPDOEA.HMGJAOOGHMM_2/*2*/;
					NNDGIAEFMOG.Add(j);
					return;
				}
			case 18: // 0x12
				{
					for (int i = 0; i < NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts.Count; i++)
					{
                        LOBDIAABMKG p = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts[i];
						if(!p.KNMLPAAHAOF_IsStartGacha)
						{
							if(p.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3)
							{
								KBPDNHOKEKD_ProductId product = p.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AKHEAGMMIAM_4);
								if(product == null)
								{
									product = p.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2);
									if(product == null)
										continue;
								}
								if(p.FJAOAGNFABN_HasOneDay)
								{
                                    EGOLBAPFHHD_Common.PCHECKGDJDK cg = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BGDMJGDEKFJ_GetGachaDraw(p.FDEBLMKEMLF_TypeAndSeriesId);
									if(cg != null)
									{
										if(p.ABNMIDCBENB_OneDay <= cg.HMFFHLPNMPH)
											continue;
									}
                                }
								if(p.HHIBBHFHENH_LinkId < 1)
								{
									//LAB_0141c22c
									JBCAHMMCOKK data = new JBCAHMMCOKK();
									data.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
									if(!b)
										data.BJIMIONBKDD = false;
									if(p.MEBKAHGMING_HasNewEpisode)
										data.BJIMIONBKDD = false;
									data.KJBGCLPMLCG_OpenedAt = p.KJBGCLPMLCG_OpenedAt;
									data.GJFPFFBAKGK_CloseAt = p.GJFPFFBAKGK_CloseAt;
									if(p.KACECFNECON != null)
									{
										if(p.KACECFNECON.JOFAGCFNKIO_OpenTime != 0)
										{
											data.KJBGCLPMLCG_OpenedAt = p.KACECFNECON.JOFAGCFNKIO_OpenTime;
										}
										data.IPHOLOBDEIK = !p.IMCNDJMDNJE_DisableCarousel;
									}
									data.ODGNHPFPBKA(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, true, data.IPHOLOBDEIK);
									data.EAHPLCJMPHD = p.FDEBLMKEMLF_TypeAndSeriesId;
									data.FEMMDNIELFC = p.KLMPFGOCBHC_Description;
									NNDGIAEFMOG.Add(data);
								}
								else
								{
									if(LOBDIAABMKG.GPKPIGPDFNL(NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts, p.HHIBBHFHENH_LinkId, p.GPDIDIJDKAG_LinkCount))
									{
										if(GIALIHIMGAJ(NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts, p.FDEBLMKEMLF_TypeAndSeriesId, p.HHIBBHFHENH_LinkId))
										{
											//LAB_0141c22c
											JBCAHMMCOKK data = new JBCAHMMCOKK();
											data.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
											if(!b)
												data.BJIMIONBKDD = false;
											if(p.MEBKAHGMING_HasNewEpisode)
												data.BJIMIONBKDD = false;
											data.KJBGCLPMLCG_OpenedAt = p.KJBGCLPMLCG_OpenedAt;
											data.GJFPFFBAKGK_CloseAt = p.GJFPFFBAKGK_CloseAt;
											if(p.KACECFNECON != null)
											{
												if(p.KACECFNECON.JOFAGCFNKIO_OpenTime != 0)
												{
													data.KJBGCLPMLCG_OpenedAt = p.KACECFNECON.JOFAGCFNKIO_OpenTime;
												}
												data.IPHOLOBDEIK = !p.IMCNDJMDNJE_DisableCarousel;
											}
											data.ODGNHPFPBKA(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, true, data.IPHOLOBDEIK);
											data.EAHPLCJMPHD = p.FDEBLMKEMLF_TypeAndSeriesId;
											data.FEMMDNIELFC = p.KLMPFGOCBHC_Description;
											NNDGIAEFMOG.Add(data);
										}
									}
								}
							}
						}
                    }
				}
				break;
			case 19: // 0x13
				{
					for (int i = 0; i < NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts.Count; i++)
					{
                        LOBDIAABMKG p = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts[i];
						if(p.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8)
						{
							JBCAHMMCOKK data = new JBCAHMMCOKK();
							data.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
							if(!b)
								data.BJIMIONBKDD = false;
							if(p.MEBKAHGMING_HasNewEpisode)
								data.BJIMIONBKDD = false;
							data.KJBGCLPMLCG_OpenedAt = p.KJBGCLPMLCG_OpenedAt;
							data.GJFPFFBAKGK_CloseAt = p.GJFPFFBAKGK_CloseAt;
							if(p.KACECFNECON != null)
							{
								if(p.KACECFNECON.JOFAGCFNKIO_OpenTime != 0)
								{
									data.KJBGCLPMLCG_OpenedAt = p.KACECFNECON.JOFAGCFNKIO_OpenTime;
								}
								data.IPHOLOBDEIK = !p.IMCNDJMDNJE_DisableCarousel;
							}
							data.ODGNHPFPBKA(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, true, data.IPHOLOBDEIK);
							data.EAHPLCJMPHD = p.FDEBLMKEMLF_TypeAndSeriesId;
							data.FEMMDNIELFC = p.KLMPFGOCBHC_Description;
							NNDGIAEFMOG.Add(data);
						}
                    }
				}
				break;
			case 21: // 0x15
				{
					if (NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ() == 0)
						return;
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
					NNDGIAEFMOG.Add(j);
				}
				break;
			case 22: // 0x16
				{
					if (!GNGMCIAIKMA.HHCJCDFCLOB.GBCPDBJEDHL())
						return;
					List<int> l = GNGMCIAIKMA.HHCJCDFCLOB.CNADOFDDNLO_GetActiveBingos(JHNMKKNEENE);
					for(int i = 0; i < l.Count; i++)
					{
						JKICPBIIHNE_Bingo.HNOGDJFJGPM dbBingo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FPOIPGFFAPE_Bingo.JJAICEAEGKF[l[i] - 1];
						if(dbBingo.FDBNFFNFOND_EndTime == 0)
						{
							JBCAHMMCOKK j = new JBCAHMMCOKK();
							j.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
							j.EAHPLCJMPHD = OHCAABOMEOF.LDGFHMMAFOC(OHCAABOMEOF.KGOGMKMBCPP_EventType.DIDJLIPNCKO, dbBingo.PPFNGGCBJKC);
							NNDGIAEFMOG.Add(j);
							return;
						}
					}
				}
				break;
			case 24: // 0x18
				{
					List<JJCJKALEIAC_HomePickup.KOCBFBJBHLJ> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NFDHMGGLEPN_HomePickup.NOHBJAPCJJI(JHNMKKNEENE);
					for(int i = 0; i < l.Count; i++)
					{
						JBCAHMMCOKK data = new JBCAHMMCOKK();
						data.KHEKNNFCAOI(KOGBMDOONFA.PPFNGGCBJKC);
						JJCJKALEIAC_HomePickup.KOCBFBJBHLJ pickup = l[i];
						data.IAMFPLLOHFO = pickup.AOBNHHIIJBO;
						data.EAHPLCJMPHD = pickup.KNHOMNONOEB;
						if (!b)
							data.BJIMIONBKDD = false;
						data.NNHHNFFLCFO = ALEKHDPDOEA.HMGJAOOGHMM_2/*2*/;
						NNDGIAEFMOG.Add(data);
					}
				}
				break;
			case 25: // 0x19
				{
					int a = 0;
					if (!int.TryParse(KOGBMDOONFA.PIBLLGLCJEO, out a))
						return;
					JJCJKALEIAC_HomePickup.OHPHKIFMPEK d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NFDHMGGLEPN_HomePickup.OKMGCLFJDJI(a, JHNMKKNEENE);
					if (d == null)
						return;
					TodoLogger.LogError(0, "HEGEKFMJNCC 25");
				}
				break;
			case 26: // 0x1a
				{
					for(int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
					{
						IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
						if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby)
						{
							TodoLogger.LogError(0, "HEGEKFMJNCC 26");
						}
					}
				}
				break;
			default:
				TodoLogger.LogError(0, "HEGEKFMJNCC "+ KOGBMDOONFA.GMELAKNFKMG);
				break;
		}
	}

	// // RVA: 0x141F600 Offset: 0x141F600 VA: 0x141F600
	private static List<int> FNDEJKMGFFO(string GDPKOJKDMNL, string PIBLLGLCJEO)
	{
		GAGIANMKDLN.Clear();
		if(!string.IsNullOrEmpty(PIBLLGLCJEO))
		{
			string[] strs = PIBLLGLCJEO.Split(new char[] { ':' });
			for(int i = 0; i < strs.Length; i++)
			{
				string[] strs2 = strs[i].Split(new char[] { '=' });
				if(strs2[i] == GDPKOJKDMNL)
				{
					string[] strs3 = strs2[1].Split(new char[] { ',' });
					for(int j = 0; j < strs3.Length; j++)
					{
						GAGIANMKDLN.Add(int.Parse(strs3[j]));
					}
				}
			}
		}
		return GAGIANMKDLN;
	}

	// // RVA: 0x141F3AC Offset: 0x141F3AC VA: 0x141F3AC
	private static bool GIALIHIMGAJ(List<LOBDIAABMKG> NNDGIAEFMOG, int FDEBLMKEMLF, int HHIBBHFHENH)
	{
		int a1 = FDEBLMKEMLF;
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].KACECFNECON != null)
			{
				if(NNDGIAEFMOG[i].HHIBBHFHENH_LinkId > 0)
				{
					if(NNDGIAEFMOG[i].HHIBBHFHENH_LinkId == HHIBBHFHENH)
					{
						if(NNDGIAEFMOG[i].FDEBLMKEMLF_TypeAndSeriesId < a1)
						{
							a1 = NNDGIAEFMOG[i].FDEBLMKEMLF_TypeAndSeriesId;
						}
					}
				}
			}
		}
		return a1 == FDEBLMKEMLF;
	}

	// // RVA: 0x141FA08 Offset: 0x141FA08 VA: 0x141FA08
	// public static void CKGGMNGAMLC(List<JBCAHMMCOKK> NNDGIAEFMOG) { }

	// // RVA: 0x141E328 Offset: 0x141E328 VA: 0x141E328
	private static void AKIFCOIDAHD(List<JBCAHMMCOKK> NNDGIAEFMOG)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		DateTime date = Utility.GetLocalDateTime(time);
		string persistPath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath;
		string path = persistPath + "/sys" + "/20";
		if(File.Exists(path))
		{
			TodoLogger.LogError(0, "AKIFCOIDAHD");
		}
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
