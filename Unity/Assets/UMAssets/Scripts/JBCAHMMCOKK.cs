
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XeSys;

public class JBCAHMMCOKK
{
    public enum ALEKHDPDOEA
    {
        HJNNKCMLGFL_0_None = 0,
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
        DMPMKBCPHMA_17_PresentCampaign = 17,
        KBAKCIJPCAL_18 = 18,
        KOLKHFLCBNP_19 = 19,
        JNFDONGNAGP_20 = 20,
        KJBGPOMJFBE_21_MonthlyPass = 21,
        CIGFHJNCKPE_22 = 22,
        BMHJMLDAPCE_23 = 23,
        GFFIILLPAMN = 24,
        OJEHIGOLJAL = 25,
        CADKONMJEDA_26_EventRaid = 26,
        KCOEIKAMLBD_27 = 27,
    }

    public enum CFBANNFILFK
    {
        HJNNKCMLGFL_0_None = 0,
        GFGNICKOBBD_1 = 1,
        GBAFHOOEKEA_2 = 2,
        KKFFEJEKFEG = 3,
    }

    public enum JPLHJHGBMON
    {
        HJNNKCMLGFL_0_None = 0,
        CJFFCDKMFFL = 1,
        HDHACKFJKGM_2 = 2,
        NFCADIPMKHK = 3,
        NEKOJOCFHKP_4 = 4,
    }

	public int JLPLLECHHLG; // 0x8
	public ALEKHDPDOEA NNHHNFFLCFO; // 0xC
	public string PIBLLGLCJEO_Param; // 0x10
	public string FEMMDNIELFC_Desc; // 0x14
	public long KJBGCLPMLCG_OpenedAt; // 0x18
	public long GJFPFFBAKGK_CloseAt; // 0x20
	public int KHLBPICICMN; // 0x28
	public int EAHPLCJMPHD_PId; // 0x2C EventId
	public bool BJIMIONBKDD_ShowPopup; // 0x30
	public bool LDLFAKLAMFG; // 0x31
	public bool AKGKKPGAJEM; // 0x32
	public bool OACANKMEKPB; // 0x33
	public CFBANNFILFK ICKKKEIFKJP; // 0x34
	public string PEDBFNIOCEN; // 0x38
	public string IAMFPLLOHFO; // 0x3C
	public int KGICDMIJGDF_Group; // 0x40
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

	// public string KJGDDCBFFLC { get; } 0x14165C8 JBJGCFCKPGF_bgs
	public string DMILLPJMDJI { get { return HDBPGEMDLDN; } } //0x14165D0 DIANNLBLEGL_bgs
	// public bool PKPMHFEIBBM { get; } 0x14165D8 OKEACOIMMLG_bgs
	public bool NMDLMMOGDML { get { return IPHOLOBDEIK; } } //0x14165E0 BCLJEOOEMNG_bgs

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
	private void ODGNHPFPBKA(long _KJBGCLPMLCG_OpenedAt, long _GJFPFFBAKGK_CloseAt, bool CCJLNAPGDPD, bool NHFJGBKIHIH)
	{
		if (CCJLNAPGDPD)
			KNNDNOKMAOI = INKBPPLCNFC(_KJBGCLPMLCG_OpenedAt, _GJFPFFBAKGK_CloseAt, false);
		if (NHFJGBKIHIH)
			HDBPGEMDLDN = INKBPPLCNFC(_KJBGCLPMLCG_OpenedAt, _GJFPFFBAKGK_CloseAt, true);
	}

	// // RVA: 0x1417164 Offset: 0x1417164 VA: 0x1417164
	// private void DOLLCJMIPJA(long _KJBGCLPMLCG_OpenedAt, long _GJFPFFBAKGK_CloseAt) { }

	// // RVA: 0x14171A0 Offset: 0x14171A0 VA: 0x14171A0
	// private void FBKJFKDNEAM(long _KJBGCLPMLCG_OpenedAt, long _GJFPFFBAKGK_CloseAt) { }

	// // RVA: 0x14171DC Offset: 0x14171DC VA: 0x14171DC
	// private void JBBJMPKIAOI(string _LJGOOOMOMMA_message, bool CCJLNAPGDPD, bool NHFJGBKIHIH) { }

	// // RVA: 0x14171F0 Offset: 0x14171F0 VA: 0x14171F0
	public void KHEKNNFCAOI_Init(int DMBENBAGDON)
	{
		JJCJKALEIAC_HomePickup.COBEFDFGLKA dbPickup = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NFDHMGGLEPN_HomePickup.CDENCMNHNGA_table[DMBENBAGDON - 1];
		JLPLLECHHLG = dbPickup.PPFNGGCBJKC_id;
		NNHHNFFLCFO = (ALEKHDPDOEA)dbPickup.GMELAKNFKMG;
		PIBLLGLCJEO_Param = dbPickup.PIBLLGLCJEO_Param;
		FEMMDNIELFC_Desc = dbPickup.FEMMDNIELFC_Desc;
		KJBGCLPMLCG_OpenedAt = dbPickup.PDBPFJJCADD_open_at;
		GJFPFFBAKGK_CloseAt = dbPickup.FDBNFFNFOND_close_at;
		KHLBPICICMN = dbPickup.DAPGDCPDCNA_Prio;
		EAHPLCJMPHD_PId = dbPickup.KNHOMNONOEB_AssetId;
		HCAIOHFNCPE = (JPLHJHGBMON)dbPickup.OFMECFHNCHA_Popup;
		BJIMIONBKDD_ShowPopup = dbPickup.OFMECFHNCHA_Popup != 0;
		LDLFAKLAMFG = dbPickup.JOPPFEHKNFO_Pickup != 0;
		ICKKKEIFKJP = 0;
		AKGKKPGAJEM = dbPickup.ODOAFNMJIMA != 0;
		IAMFPLLOHFO = dbPickup.AOBNHHIIJBO;
		OACANKMEKPB = dbPickup.ADHCKHFANAL != 0;
		KGICDMIJGDF_Group = dbPickup.KGICDMIJGDF_Group;
		FALOEOOOIHG = false;
		IPHOLOBDEIK = dbPickup.KLHGOPBIOCN != 0;
		AOPMODMAANL = dbPickup.KLHGOPBIOCN != 0;
		KNNDNOKMAOI = "";
		HDBPGEMDLDN = "";
		if(!AKGKKPGAJEM)
		{
			if (dbPickup.ADHCKHFANAL == 1)
				ICKKKEIFKJP = CFBANNFILFK.GFGNICKOBBD_1/*1*/;
			else if(dbPickup.ADHCKHFANAL == 2)
				ICKKKEIFKJP = CFBANNFILFK.GBAFHOOEKEA_2/*2*/;
			else if (dbPickup.ADHCKHFANAL == 3)
				ICKKKEIFKJP = CFBANNFILFK.KKFFEJEKFEG/*3*/;
		}
		else
		{
			if(dbPickup.ODOAFNMJIMA == 1)
				ICKKKEIFKJP = CFBANNFILFK.GFGNICKOBBD_1/*1*/;
			else if (dbPickup.ODOAFNMJIMA == 2)
				ICKKKEIFKJP = CFBANNFILFK.GBAFHOOEKEA_2/*2*/;
		}
	}

	// // RVA: 0x14176A8 Offset: 0x14176A8 VA: 0x14176A8
	public bool HLMIOEGBAKJ()
	{
		if(!CLDKMLONBHJ)
			CLDKMLONBHJ = true;
		return CLDKMLONBHJ;
	}

	// // RVA: 0x14176C4 Offset: 0x14176C4 VA: 0x14176C4
	public static List<JBCAHMMCOKK> FKDIMODKKJD_GetList(bool DKLOGCOPPKJ/* = false*/)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		DateTime date = Utility.GetLocalDateTime(time);
		List<JBCAHMMCOKK> res = new List<JBCAHMMCOKK>();
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NFDHMGGLEPN_HomePickup.CDENCMNHNGA_table.Count; i++)
		{
			HEGEKFMJNCC(res, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NFDHMGGLEPN_HomePickup.CDENCMNHNGA_table[i], time, (int)date.DayOfWeek);
		}
		res = HGBCHAIAKGC(res);
		AKIFCOIDAHD(res);
		Algorithms.InsertSort(res, (JBCAHMMCOKK _HKICMNAACDA_a, JBCAHMMCOKK _BNKHBCBJBKI_b) => {
			//0x14204EC
			if(_HKICMNAACDA_a.KHLBPICICMN == _BNKHBCBJBKI_b.KHLBPICICMN)
				return _BNKHBCBJBKI_b.KJBGCLPMLCG_OpenedAt.CompareTo(_HKICMNAACDA_a.KJBGCLPMLCG_OpenedAt);
			return _HKICMNAACDA_a.KHLBPICICMN.CompareTo(_BNKHBCBJBKI_b.KHLBPICICMN);
		});
		return res;
	}

	// // RVA: 0x1417AC4 Offset: 0x1417AC4 VA: 0x1417AC4
	private static void HEGEKFMJNCC(List<JBCAHMMCOKK> NNDGIAEFMOG, JJCJKALEIAC_HomePickup.COBEFDFGLKA _KOGBMDOONFA_Info, long _JHNMKKNEENE_Time, int DHABOCGMFLN)
	{
		if (_KOGBMDOONFA_Info.PPEGAKEIEGM_Enabled != 2)
			return;
		bool b = true;
		int level = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
		if (_KOGBMDOONFA_Info.JPKPDCCGGLA > 0)
			b = _KOGBMDOONFA_Info.JPKPDCCGGLA < level;
		bool c = true;
		if (_KOGBMDOONFA_Info.AMKJDECHIOF > 0)
			c = _KOGBMDOONFA_Info.AMKJDECHIOF < level;

		// UMO conditional activation froml context
		bool ignoreDate = false;
		switch(_KOGBMDOONFA_Info.GMELAKNFKMG)
		{
			case 17:
				CANAFALMGLI_EventPresentCampaign ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_9_PresentCampaign, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as CANAFALMGLI_EventPresentCampaign;
				if(ev != null)
					ignoreDate = true;
				break;
			default:
				break;
		}

		// END UMO

		if(!ignoreDate)
		{
			if(_KOGBMDOONFA_Info.PDBPFJJCADD_open_at != 0)
			{
				if(_KOGBMDOONFA_Info.FDBNFFNFOND_close_at != 0)
				{
					if (_JHNMKKNEENE_Time < _KOGBMDOONFA_Info.PDBPFJJCADD_open_at)
						return;
					if (_JHNMKKNEENE_Time >= _KOGBMDOONFA_Info.FDBNFFNFOND_close_at)
						return;
				}
			}
		}

		if (!c)
			return;
		switch(_KOGBMDOONFA_Info.GMELAKNFKMG)
		{
			case 0:
				{
					JBCAHMMCOKK d = new JBCAHMMCOKK();
					d.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
					d.ODGNHPFPBKA(_KOGBMDOONFA_Info.PDBPFJJCADD_open_at, _KOGBMDOONFA_Info.FDBNFFNFOND_close_at, d.AOPMODMAANL, d.IPHOLOBDEIK);
					NNDGIAEFMOG.Add(d);
				}
				break;
			case 1:
			case 2:
			case 3:
			case 15:
				{
					JBCAHMMCOKK d = new JBCAHMMCOKK();
					d.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
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
							ev.HCDGELDHFHB_UpdateStatus(_JHNMKKNEENE_Time);
							if(ev.HIDHLFCBIDE_EventType > OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby || 
								(((1 << (int)ev.HIDHLFCBIDE_EventType) & 0x2f90U) == 0)) // 4 7 8 9 10 11 13
							{
								if(ev.HJPNJBCJPNJ(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting/*6*/))
								{
									JBCAHMMCOKK data = new JBCAHMMCOKK();
									data.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
									data.EAHPLCJMPHD_PId = ev.PGIIDPEGGPI_EventId;
									data.PEDBFNIOCEN = ev.JOPOPMLFINI_QuestName;
									data.KJBGCLPMLCG_OpenedAt = ev.GLIMIGNNGGB_RankingStart;
									data.GJFPFFBAKGK_CloseAt = ev.DPJCPDKALGI_RankingEnd;
									data.KNNDNOKMAOI = data.INKBPPLCNFC(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, false);
									data.HDBPGEMDLDN = data.INKBPPLCNFC(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, true);
									if (!b)
										data.BJIMIONBKDD_ShowPopup = false;
									if (ev.NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting/*6*/)
										data.BJIMIONBKDD_ShowPopup = false;
									NNDGIAEFMOG.Add(data);
								}
							}
						}
					}
				}
				break;
			case 5:
				{
					int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NCEMAEDMJLO_GetBeginnerGachaVersion(_JHNMKKNEENE_Time);
					if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BKCJPIPJCCM_sta_lot_done == a)
						return;
					List<LOBDIAABMKG> l = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products;
					for (int i = 0; i < l.Count; i++)
					{
						if(l[i].KNMLPAAHAOF_IsStartGacha && l[i].INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3_Debut)
						{
							JBCAHMMCOKK data = new JBCAHMMCOKK();
							data.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
							if(!b)
								data.BJIMIONBKDD_ShowPopup = false;
							data.FEMMDNIELFC_Desc = l[i].KLMPFGOCBHC_description;
							data.EAHPLCJMPHD_PId = l[i].FDEBLMKEMLF_TypeAndSeriesId;
							NNDGIAEFMOG.Add(data);
						}
					}
				}
				break;
			case 6:
				{
					for(int i = 0; i < NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products.Count; i++)
					{
                        LOBDIAABMKG p = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products[i];
                        if (p.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.JGDEHOGIENP_4_Sphere_CostumeTicket)
						{
							JBCAHMMCOKK data = new JBCAHMMCOKK();
							data.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
							KBPDNHOKEKD_ProductId product = p.DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1);
							if(product != null)
							{
								if(!b)
									data.BJIMIONBKDD_ShowPopup = false;
								if(p.MEBKAHGMING_HasNewEpisode)
									data.BJIMIONBKDD_ShowPopup = false;
								data.KJBGCLPMLCG_OpenedAt = p.KJBGCLPMLCG_OpenedAt;
								data.GJFPFFBAKGK_CloseAt = p.GJFPFFBAKGK_CloseAt;
								if(p.KACECFNECON_extra != null)
								{
									if(p.KACECFNECON_extra.JOFAGCFNKIO_OpenTime != 0)
									{
										data.KJBGCLPMLCG_OpenedAt = p.KACECFNECON_extra.JOFAGCFNKIO_OpenTime;
									}
									data.IPHOLOBDEIK = !p.IMCNDJMDNJE_DisableCarousel;
								}
								data.ODGNHPFPBKA(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, true, data.IPHOLOBDEIK);
								data.EAHPLCJMPHD_PId = p.FDEBLMKEMLF_TypeAndSeriesId;
								data.FEMMDNIELFC_Desc = p.KLMPFGOCBHC_description;
								NNDGIAEFMOG.Add(data);
							}
						}
					}
				}
				break;
			case 7:
				{
					string s = _KOGBMDOONFA_Info.PIBLLGLCJEO_Param;
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
                    List<LGDNAJACFHI> l2 = EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI_products;
                    for(int i = 0; i < l2.Count; i++)
					{
						LGDNAJACFHI OHDPMGMGJBI = l2[i];
						int idx = l.FindIndex((int JPAEDJJFFOI) =>
						{
							//0x1420578
							return OHDPMGMGJBI.LHENLPLKGLP_StuffId == JPAEDJJFFOI;
						});
						if(idx > -1)
						{
							if(OHDPMGMGJBI.GCJMGMBNBCB_BuyLimit != 0)
							{
								if(OHDPMGMGJBI.GCJMGMBNBCB_BuyLimit != OHDPMGMGJBI.AJIFADGGAAJ_BoughtQuantity)
								{
									if(OHDPMGMGJBI.JLGHMCBLENL_IsBeginner)
									{
										JBCAHMMCOKK j = new JBCAHMMCOKK();
										j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
										if(!b)
										{
											j.BJIMIONBKDD_ShowPopup = false;
										}
										j.KJBGCLPMLCG_OpenedAt = OHDPMGMGJBI.EBEOPONDEKB_OpenedAt;
										j.GJFPFFBAKGK_CloseAt = OHDPMGMGJBI.EMEKFFHCHMH_RewardEnd2;
										j.KNNDNOKMAOI = j.INKBPPLCNFC(j.KJBGCLPMLCG_OpenedAt, j.GJFPFFBAKGK_CloseAt, false);
										j.HDBPGEMDLDN = j.INKBPPLCNFC(j.KJBGCLPMLCG_OpenedAt, j.GJFPFFBAKGK_CloseAt, true);
										break;
									}
									if(OHDPMGMGJBI.NIIIKPNBLNP)
									{
										JBCAHMMCOKK j = new JBCAHMMCOKK();
										j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
										if(!b)
										{
											j.BJIMIONBKDD_ShowPopup = false;
										}
										j.KJBGCLPMLCG_OpenedAt = OHDPMGMGJBI.EBEOPONDEKB_OpenedAt;
										j.GJFPFFBAKGK_CloseAt = OHDPMGMGJBI.EMEKFFHCHMH_RewardEnd2;
										j.KNNDNOKMAOI = j.INKBPPLCNFC(j.KJBGCLPMLCG_OpenedAt, j.GJFPFFBAKGK_CloseAt, false);
										j.HDBPGEMDLDN = j.INKBPPLCNFC(j.KJBGCLPMLCG_OpenedAt, j.GJFPFFBAKGK_CloseAt, true);
										break;
									}
								}
							}
						}
					}
				}
				break;
			case 8:
				{
					if (FKMOKDCJFEN.KFHCJLFAHAG() == null)
						return;
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
					if(!b)
					{
						j.BJIMIONBKDD_ShowPopup = false;
					}
					NNDGIAEFMOG.Add(j);
				}
				break;
			case 9:
				{
					IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting/*6*/);
					if (ev == null)
						return;
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
					j.EAHPLCJMPHD_PId = ev.PGIIDPEGGPI_EventId;
					j.PEDBFNIOCEN = ev.JOPOPMLFINI_QuestName;
					j.KJBGCLPMLCG_OpenedAt = ev.GLIMIGNNGGB_RankingStart;
					j.GJFPFFBAKGK_CloseAt = ev.DPJCPDKALGI_RankingEnd;
					j.KNNDNOKMAOI = j.INKBPPLCNFC(ev.GLIMIGNNGGB_RankingStart, ev.DPJCPDKALGI_RankingEnd, false);
					j.HDBPGEMDLDN = j.INKBPPLCNFC(ev.GLIMIGNNGGB_RankingStart, ev.DPJCPDKALGI_RankingEnd, true);
					if(!b)
						j.BJIMIONBKDD_ShowPopup = false;
					if(ev.NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
						j.BJIMIONBKDD_ShowPopup = false;
					NNDGIAEFMOG.Add(j);
				}
				break;
			case 10:
				{
					int a = 0;
					if (!int.TryParse(_KOGBMDOONFA_Info.PIBLLGLCJEO_Param, out a) || a != DHABOCGMFLN)
						return;
					List<IBJAKJJICBC> l = IBJAKJJICBC.FKDIMODKKJD_GetList(5, _JHNMKKNEENE_Time, true, false, false, false);
					for(int i = 0; i < l.Count; i++)
					{
						if(l[i].LHONOILACFL_IsWeeklyEvent)
						{
							if(l[i].BELHFPMBAPJ_WeekPlay < l[i].JOJNGDPHOKG_WeeklyMax)
							{
								JBCAHMMCOKK data = new JBCAHMMCOKK();
								data.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
								if(!b)
								{
									data.BJIMIONBKDD_ShowPopup = false;
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
					KNKDBNFMAKF_EventSp ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp/*7*/, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as KNKDBNFMAKF_EventSp;
					if (ev != null)
					{
						for(int i = 0; i < ev.BAEEGPJJHKD_GetNumSubSp(); i++)
						{
							int v = ev.NBLGLKGOKOD_GetSubSpId(i);
							IKDICBBFBMI_EventBase ev3 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(v);
							if(ev3 != null)
							{
								if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MLKAJEDCPLP(v))
								{
									JBCAHMMCOKK j = new JBCAHMMCOKK();
									j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
									if(!b)
									{
										j.BJIMIONBKDD_ShowPopup = false;
									}
									l3.Add(ev.PGIIDPEGGPI_EventId);
									j.EAHPLCJMPHD_PId = ev.PGIIDPEGGPI_EventId;
									j.PEDBFNIOCEN = ev.JOPOPMLFINI_QuestName;
									j.KJBGCLPMLCG_OpenedAt = ev.GLIMIGNNGGB_RankingStart;
									j.GJFPFFBAKGK_CloseAt = ev.DPJCPDKALGI_RankingEnd;
									j.HDBPGEMDLDN = MessageManager.Instance.GetMessage("menu", "home_event_epilogue");
									j.IPHOLOBDEIK = true;
									j.PIBLLGLCJEO_Param = ev3.CAKEOPLJDAF_EndAdventureId.ToString();
									NNDGIAEFMOG.Add(j);
								}
							}
						}
					}
					List<int> l2 = FNDEJKMGFFO("type", _KOGBMDOONFA_Info.PIBLLGLCJEO_Param);
					for(int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
					{
						IKDICBBFBMI_EventBase ev2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
						if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MLKAJEDCPLP(ev2.PGIIDPEGGPI_EventId))
						{
							int idx = l2.FindIndex((int _GHPLINIACBB_x) =>
							{
								//0x14205AC
								return (int)ev2.HIDHLFCBIDE_EventType == _GHPLINIACBB_x;
							});
							if(idx > -1)
							{
								int idx2 = l3.FindIndex((int _GHPLINIACBB_x) =>
								{
									//0x14205F4
									return ev2.PGIIDPEGGPI_EventId == _GHPLINIACBB_x;
								});
								if(idx2 < 0)
								{
									JBCAHMMCOKK data = new JBCAHMMCOKK();
									data.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
									if(!b)
									{
										data.BJIMIONBKDD_ShowPopup = false;
									}
									data.EAHPLCJMPHD_PId = ev2.PGIIDPEGGPI_EventId;
									data.PEDBFNIOCEN = ev2.JOPOPMLFINI_QuestName;
									data.KJBGCLPMLCG_OpenedAt = ev2.GLIMIGNNGGB_RankingStart;
									data.GJFPFFBAKGK_CloseAt = ev2.DPJCPDKALGI_RankingEnd;
									data.HDBPGEMDLDN = MessageManager.Instance.GetMessage("menu", "home_event_epilogue");
									data.IPHOLOBDEIK = true;
									data.PIBLLGLCJEO_Param = ev2.CAKEOPLJDAF_EndAdventureId.ToString();
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
					j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
					if(!b)
					{
						j.BJIMIONBKDD_ShowPopup = false;
					}
					j.NNHHNFFLCFO = ALEKHDPDOEA.HMGJAOOGHMM_2/*2*/;
					NNDGIAEFMOG.Add(j);
					return;
				}
			case 13: // 0xd
				{
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
					if (!b)
					{
						j.BJIMIONBKDD_ShowPopup = false;
					}
					j.NNHHNFFLCFO = ALEKHDPDOEA.HMGJAOOGHMM_2/*2*/;
					NNDGIAEFMOG.Add(j);
					return;
				}
			case 14: // 0xe
				{
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
					if (!b)
					{
						j.BJIMIONBKDD_ShowPopup = false;
					}
					j.NNHHNFFLCFO = ALEKHDPDOEA.HMGJAOOGHMM_2/*2*/;
					NNDGIAEFMOG.Add(j);
					return;
				}
			case 16://0x10
				{
					List<IKDICBBFBMI_EventBase> l = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN;
					for(int i = 0; i < l.Count; i++)
					{
						if(l[i] != null)
						{
							l[i].HCDGELDHFHB_UpdateStatus(_JHNMKKNEENE_Time);
							if(l[i].HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
							{
								//LAB_0141ccb8
								JBCAHMMCOKK j = new JBCAHMMCOKK();
								j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
								j.ODGNHPFPBKA(l[i].GLIMIGNNGGB_RankingStart, l[i].LJOHLEGGGMC_RewardEnd, j.AOPMODMAANL, j.IPHOLOBDEIK);
								NNDGIAEFMOG.Add(j);
								return;
							}
						}
					}
					return;
				}
			case 17: // 0x11
				{
					CANAFALMGLI_EventPresentCampaign ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_9_PresentCampaign, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as CANAFALMGLI_EventPresentCampaign;
					if(ev == null)
						return;
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
					if(!b)
					{
						j.BJIMIONBKDD_ShowPopup = false;
					}
					j.EAHPLCJMPHD_PId = ev.PGIIDPEGGPI_EventId;
					j.PEDBFNIOCEN = ev.JOPOPMLFINI_QuestName;
					j.KJBGCLPMLCG_OpenedAt = ev.GLIMIGNNGGB_RankingStart;
					j.GJFPFFBAKGK_CloseAt = ev.DPJCPDKALGI_RankingEnd;
					NNDGIAEFMOG.Add(j);
					return;
				}
			case 18: // 0x12
				{
					for (int i = 0; i < NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products.Count; i++)
					{
                        LOBDIAABMKG p = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products[i];
						if(!p.KNMLPAAHAOF_IsStartGacha)
						{
							if(p.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3_Debut)
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
                                    EGOLBAPFHHD_Common.PCHECKGDJDK cg = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BGDMJGDEKFJ_GetGachaDraw(p.FDEBLMKEMLF_TypeAndSeriesId);
									if(cg != null)
									{
										if(p.ABNMIDCBENB_OneDay <= cg.HMFFHLPNMPH_count)
											continue;
									}
                                }
								if(p.HHIBBHFHENH_LinkQuestId < 1)
								{
									//LAB_0141c22c
									JBCAHMMCOKK data = new JBCAHMMCOKK();
									data.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
									if(!b)
										data.BJIMIONBKDD_ShowPopup = false;
									if(p.MEBKAHGMING_HasNewEpisode)
										data.BJIMIONBKDD_ShowPopup = false;
									data.KJBGCLPMLCG_OpenedAt = p.KJBGCLPMLCG_OpenedAt;
									data.GJFPFFBAKGK_CloseAt = p.GJFPFFBAKGK_CloseAt;
									if(p.KACECFNECON_extra != null)
									{
										if(p.KACECFNECON_extra.JOFAGCFNKIO_OpenTime != 0)
										{
											data.KJBGCLPMLCG_OpenedAt = p.KACECFNECON_extra.JOFAGCFNKIO_OpenTime;
										}
										data.IPHOLOBDEIK = !p.IMCNDJMDNJE_DisableCarousel;
									}
									data.ODGNHPFPBKA(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, true, data.IPHOLOBDEIK);
									data.EAHPLCJMPHD_PId = p.FDEBLMKEMLF_TypeAndSeriesId;
									data.FEMMDNIELFC_Desc = p.KLMPFGOCBHC_description;
									NNDGIAEFMOG.Add(data);
								}
								else
								{
									if(LOBDIAABMKG.GPKPIGPDFNL(NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products, p.HHIBBHFHENH_LinkQuestId, p.GPDIDIJDKAG_LinkCount))
									{
										if(GIALIHIMGAJ(NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products, p.FDEBLMKEMLF_TypeAndSeriesId, p.HHIBBHFHENH_LinkQuestId))
										{
											//LAB_0141c22c
											JBCAHMMCOKK data = new JBCAHMMCOKK();
											data.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
											if(!b)
												data.BJIMIONBKDD_ShowPopup = false;
											if(p.MEBKAHGMING_HasNewEpisode)
												data.BJIMIONBKDD_ShowPopup = false;
											data.KJBGCLPMLCG_OpenedAt = p.KJBGCLPMLCG_OpenedAt;
											data.GJFPFFBAKGK_CloseAt = p.GJFPFFBAKGK_CloseAt;
											if(p.KACECFNECON_extra != null)
											{
												if(p.KACECFNECON_extra.JOFAGCFNKIO_OpenTime != 0)
												{
													data.KJBGCLPMLCG_OpenedAt = p.KACECFNECON_extra.JOFAGCFNKIO_OpenTime;
												}
												data.IPHOLOBDEIK = !p.IMCNDJMDNJE_DisableCarousel;
											}
											data.ODGNHPFPBKA(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, true, data.IPHOLOBDEIK);
											data.EAHPLCJMPHD_PId = p.FDEBLMKEMLF_TypeAndSeriesId;
											data.FEMMDNIELFC_Desc = p.KLMPFGOCBHC_description;
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
					for (int i = 0; i < NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products.Count; i++)
					{
                        LOBDIAABMKG p = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products[i];
						if(p.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8_StepUp)
						{
							JBCAHMMCOKK data = new JBCAHMMCOKK();
							data.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
							if(!b)
								data.BJIMIONBKDD_ShowPopup = false;
							if(p.MEBKAHGMING_HasNewEpisode)
								data.BJIMIONBKDD_ShowPopup = false;
							data.KJBGCLPMLCG_OpenedAt = p.KJBGCLPMLCG_OpenedAt;
							data.GJFPFFBAKGK_CloseAt = p.GJFPFFBAKGK_CloseAt;
							if(p.KACECFNECON_extra != null)
							{
								if(p.KACECFNECON_extra.JOFAGCFNKIO_OpenTime != 0)
								{
									data.KJBGCLPMLCG_OpenedAt = p.KACECFNECON_extra.JOFAGCFNKIO_OpenTime;
								}
								data.IPHOLOBDEIK = !p.IMCNDJMDNJE_DisableCarousel;
							}
							data.ODGNHPFPBKA(data.KJBGCLPMLCG_OpenedAt, data.GJFPFFBAKGK_CloseAt, true, data.IPHOLOBDEIK);
							data.EAHPLCJMPHD_PId = p.FDEBLMKEMLF_TypeAndSeriesId;
							data.FEMMDNIELFC_Desc = p.KLMPFGOCBHC_description;
							NNDGIAEFMOG.Add(data);
						}
                    }
				}
				break;
			case 20: //0x14
				{
					List<LOBDIAABMKG> l = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products;
					for(int i = 0; i < l.Count; i++)
					{
						if(l[i].INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
						{
							int a = l[i].OMNAPCHLBHF_GetPurchaseCurrencyId(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5);
							if(a == 0)
							{
								a = l[i].OMNAPCHLBHF_GetPurchaseCurrencyId(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6);
							}
							if(!l[i].IJJOGGEBBPF(a))
								return;
							if(l[i].HHIBBHFHENH_LinkQuestId < 1 || 
							(
								LOBDIAABMKG.GPKPIGPDFNL(l, l[i].HHIBBHFHENH_LinkQuestId, l[i].GPDIDIJDKAG_LinkCount) && GIALIHIMGAJ(l, l[i].FDEBLMKEMLF_TypeAndSeriesId, l[i].HHIBBHFHENH_LinkQuestId)
							))
							{
								//LAB_0141b55c
								JBCAHMMCOKK j = new JBCAHMMCOKK();
								j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
								if(!b)
									j.BJIMIONBKDD_ShowPopup = false;
								if(!l[i].MEBKAHGMING_HasNewEpisode)
									j.BJIMIONBKDD_ShowPopup = false;
								long a1 = l[i].KJBGCLPMLCG_OpenedAt;
								bool b1 = !j.IPHOLOBDEIK;
								if(l[i].KACECFNECON_extra != null)
								{
									if(l[i].KACECFNECON_extra.JOFAGCFNKIO_OpenTime != 0)
									{
										a1 = l[i].KACECFNECON_extra.JOFAGCFNKIO_OpenTime;
									}
									j.IPHOLOBDEIK = !l[i].IMCNDJMDNJE_DisableCarousel;
									b1 = l[i].IMCNDJMDNJE_DisableCarousel;
								}
								j.KJBGCLPMLCG_OpenedAt = a1;
								j.GJFPFFBAKGK_CloseAt = l[i].GJFPFFBAKGK_CloseAt;
								j.ODGNHPFPBKA(a1, j.GJFPFFBAKGK_CloseAt, true, !b1);
								j.EAHPLCJMPHD_PId = l[i].FDEBLMKEMLF_TypeAndSeriesId;
								j.FEMMDNIELFC_Desc = l[i].KLMPFGOCBHC_description;
								NNDGIAEFMOG.Add(j);
							}
						}
					}
					return;
				}
			case 21: // 0x15
				{
					if (NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ() == 0)
						return;
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
					NNDGIAEFMOG.Add(j);
				}
				break;
			case 22: // 0x16
				{
					if (!GNGMCIAIKMA.HHCJCDFCLOB.GBCPDBJEDHL())
						return;
					List<int> l = GNGMCIAIKMA.HHCJCDFCLOB.CNADOFDDNLO_GetActiveBingos(_JHNMKKNEENE_Time);
					for(int i = 0; i < l.Count; i++)
					{
						JKICPBIIHNE_Bingo.HNOGDJFJGPM dbBingo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FPOIPGFFAPE_Bingo.JJAICEAEGKF[l[i] - 1];
						if(dbBingo.FDBNFFNFOND_close_at == 0)
						{
							JBCAHMMCOKK j = new JBCAHMMCOKK();
							j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
							j.EAHPLCJMPHD_PId = OHCAABOMEOF.LDGFHMMAFOC(OHCAABOMEOF.KGOGMKMBCPP_EventType.DIDJLIPNCKO_12_Bingo, dbBingo.PPFNGGCBJKC_id);
							NNDGIAEFMOG.Add(j);
							return;
						}
					}
				}
				break;
			case 23: // 0x17
				{
					if(!GNGMCIAIKMA.HHCJCDFCLOB.GBCPDBJEDHL())
						return;
					List<int> l = GNGMCIAIKMA.HHCJCDFCLOB.CNADOFDDNLO_GetActiveBingos(_JHNMKKNEENE_Time);
					for(int i = 0; i < l.Count; i++)
					{
						JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FPOIPGFFAPE_Bingo.JJAICEAEGKF[l[i] - 1];
						if(bingo.FDBNFFNFOND_close_at == 0)
						{
							JBCAHMMCOKK j = new JBCAHMMCOKK();
							j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
							j.EAHPLCJMPHD_PId = OHCAABOMEOF.LDGFHMMAFOC(OHCAABOMEOF.KGOGMKMBCPP_EventType.DIDJLIPNCKO_12_Bingo, bingo.PPFNGGCBJKC_id);
							j.KJBGCLPMLCG_OpenedAt = bingo.PDBPFJJCADD_open_at;
							j.GJFPFFBAKGK_CloseAt = bingo.FDBNFFNFOND_close_at;
							j.KNNDNOKMAOI = j.INKBPPLCNFC(j.KJBGCLPMLCG_OpenedAt, j.GJFPFFBAKGK_CloseAt, false);
							j.HDBPGEMDLDN = j.INKBPPLCNFC(j.KJBGCLPMLCG_OpenedAt, j.GJFPFFBAKGK_CloseAt, true);
							NNDGIAEFMOG.Add(j);
							return;
						}
					}
					return;
				}
			case 24: // 0x18
				{
					List<JJCJKALEIAC_HomePickup.KOCBFBJBHLJ> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NFDHMGGLEPN_HomePickup.NOHBJAPCJJI(_JHNMKKNEENE_Time);
					for(int i = 0; i < l.Count; i++)
					{
						JBCAHMMCOKK data = new JBCAHMMCOKK();
						data.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
						JJCJKALEIAC_HomePickup.KOCBFBJBHLJ pickup = l[i];
						data.IAMFPLLOHFO = pickup.AOBNHHIIJBO;
						data.EAHPLCJMPHD_PId = pickup.KNHOMNONOEB_AssetId;
						if (!b)
							data.BJIMIONBKDD_ShowPopup = false;
						data.NNHHNFFLCFO = ALEKHDPDOEA.HMGJAOOGHMM_2/*2*/;
						NNDGIAEFMOG.Add(data);
					}
				}
				break;
			case 25: // 0x19
				{
					int a = 0;
					if (!int.TryParse(_KOGBMDOONFA_Info.PIBLLGLCJEO_Param, out a))
						return;
					JJCJKALEIAC_HomePickup.OHPHKIFMPEK d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NFDHMGGLEPN_HomePickup.OKMGCLFJDJI(a, _JHNMKKNEENE_Time);
					if (d == null)
						return;
					JBCAHMMCOKK j = new JBCAHMMCOKK();
					j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
					j.IAMFPLLOHFO = d.AOBNHHIIJBO;
					j.EAHPLCJMPHD_PId = d.KNHOMNONOEB_AssetId;
					if(!b)
					{
						j.BJIMIONBKDD_ShowPopup = false;
					}
					j.NNHHNFFLCFO = ALEKHDPDOEA.HMGJAOOGHMM_2;
					NNDGIAEFMOG.Add(j);
				}
				break;
			case 26: // 0x1a
				{
					for(int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
					{
						IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
						if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby)
						{
							ev.HCDGELDHFHB_UpdateStatus(_JHNMKKNEENE_Time);
							NKOBMDPHNGP_EventRaidLobby evLobby = ev as NKOBMDPHNGP_EventRaidLobby;
							if(evLobby == null)
								return;
							JBCAHMMCOKK j = new JBCAHMMCOKK();
							j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
							j.EAHPLCJMPHD_PId = ev.PGIIDPEGGPI_EventId;
							j.BJIMIONBKDD_ShowPopup = evLobby.EMPOBKBHLAC(_JHNMKKNEENE_Time);
                            NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase v = evLobby.KINIOEOOCAA_GetPhase(_JHNMKKNEENE_Time);
                            long l1, l2;
							evLobby.IICLCPIPENB_GetRaidTime(out l1, out l2);
							if(v == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End)
							{
								j.HDBPGEMDLDN = MessageManager.Instance.GetMessage("menu", "home_banner_raid_end");
							}
							else if(v == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now)
							{
								j.HDBPGEMDLDN = j.INKBPPLCNFC(l1, l2, true);
							}
							else if(v == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before)
							{
								j.HDBPGEMDLDN = MessageManager.Instance.GetMessage("menu", "home_banner_raid_lobby_open");
							}
							j.KNNDNOKMAOI = j.INKBPPLCNFC(l1, l2, false);
							NNDGIAEFMOG.Add(j);
							break;
						}
					}
				}
				break;
			case 27: // 0x1b
				{
					string[] strs = _KOGBMDOONFA_Info.PIBLLGLCJEO_Param.Split(new char[] { '-' });
					List<int> l = new List<int>();
					for(int i = 0; i< strs.Length; i++)
					{
						int v;
						if(int.TryParse(strs[1], out v))
						{
							l.Add(v);
						}
					}
					List<LOBDIAABMKG> l2 = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_products;
					for(int i = 0; i < l2.Count; i++)
					{
						if(l2[i].INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10_LimitedItem)
						{
							int a = l2[i].FDEBLMKEMLF_TypeAndSeriesId;
							if((l.Count == 1 && l.FindIndex((int _GHPLINIACBB_x) =>
								{
									//0x1420564
									return a == _GHPLINIACBB_x;
								}) > -1) || 
								(l.Count == 2 && l[0] <= l2[i].FDEBLMKEMLF_TypeAndSeriesId && l2[i].FDEBLMKEMLF_TypeAndSeriesId <= l[1]))
							{
								//LAB_01418890
								if(l2[i].HHIBBHFHENH_LinkQuestId < 1 || 
									(LOBDIAABMKG.GPKPIGPDFNL(l2, l2[i].HHIBBHFHENH_LinkQuestId, l2[i].GPDIDIJDKAG_LinkCount) && GIALIHIMGAJ(l2, l2[i].FDEBLMKEMLF_TypeAndSeriesId, l2[i].HHIBBHFHENH_LinkQuestId)))
								{
									//LAB_01418a40
									JBCAHMMCOKK j = new JBCAHMMCOKK();
									j.KHEKNNFCAOI_Init(_KOGBMDOONFA_Info.PPFNGGCBJKC_id);
									if(!b)
									{
										j.BJIMIONBKDD_ShowPopup = false;
									}
									if(l2[i].MEBKAHGMING_HasNewEpisode)
									{
										j.BJIMIONBKDD_ShowPopup = false;
									}
									long a1 = l2[i].KJBGCLPMLCG_OpenedAt;
									bool b1 = !j.IPHOLOBDEIK;
									if(l2[i].KACECFNECON_extra != null)
									{
										if(l2[i].KACECFNECON_extra.JOFAGCFNKIO_OpenTime != 0)
										{
											a1 = l2[i].KACECFNECON_extra.JOFAGCFNKIO_OpenTime;
										}
										b1 = l2[i].IMCNDJMDNJE_DisableCarousel;
										j.IPHOLOBDEIK = !l2[i].IMCNDJMDNJE_DisableCarousel;
									}
									j.KJBGCLPMLCG_OpenedAt = a1;
									j.GJFPFFBAKGK_CloseAt = l2[i].GJFPFFBAKGK_CloseAt;
									j.ODGNHPFPBKA(a1, j.GJFPFFBAKGK_CloseAt, true, !b1);
									j.EAHPLCJMPHD_PId = l2[i].FDEBLMKEMLF_TypeAndSeriesId;
									j.FEMMDNIELFC_Desc = l2[i].KLMPFGOCBHC_description;
									NNDGIAEFMOG.Add(j);
								}
							}
						}
					}
				}
				break;
			default:
				return;
		}
	}

	// // RVA: 0x141F600 Offset: 0x141F600 VA: 0x141F600
	private static List<int> FNDEJKMGFFO(string GDPKOJKDMNL, string _PIBLLGLCJEO_Param)
	{
		GAGIANMKDLN.Clear();
		if(!string.IsNullOrEmpty(_PIBLLGLCJEO_Param))
		{
			string[] strs = _PIBLLGLCJEO_Param.Split(new char[] { ':' });
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
	private static bool GIALIHIMGAJ(List<LOBDIAABMKG> NNDGIAEFMOG, int _FDEBLMKEMLF_TypeAndSeriesId, int _HHIBBHFHENH_LinkQuestId)
	{
		int a1 = _FDEBLMKEMLF_TypeAndSeriesId;
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].KACECFNECON_extra != null)
			{
				if(NNDGIAEFMOG[i].HHIBBHFHENH_LinkQuestId > 0)
				{
					if(NNDGIAEFMOG[i].HHIBBHFHENH_LinkQuestId == _HHIBBHFHENH_LinkQuestId)
					{
						if(NNDGIAEFMOG[i].FDEBLMKEMLF_TypeAndSeriesId < a1)
						{
							a1 = NNDGIAEFMOG[i].FDEBLMKEMLF_TypeAndSeriesId;
						}
					}
				}
			}
		}
		return a1 == _FDEBLMKEMLF_TypeAndSeriesId;
	}

	// // RVA: 0x141FA08 Offset: 0x141FA08 VA: 0x141FA08
	public static void CKGGMNGAMLC(List<JBCAHMMCOKK> NNDGIAEFMOG)
	{
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		int a = 0;
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			a += NNDGIAEFMOG[i].CLDKMLONBHJ ? 1 : 0;
		}
		string dir = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/sys";
		if(!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
		string file = dir + "/20";
		using(FileStream fs = new FileStream(file, FileMode.Create))
		{
			using(BinaryWriter bw = new BinaryWriter(fs))
			{
				bw.Write(0x14114144);
				bw.Write(a);
				bw.Write(t);
				for(int i = 0; i < NNDGIAEFMOG.Count; i++)
				{
					if(NNDGIAEFMOG[i].CLDKMLONBHJ)
					{
						bw.Write(NNDGIAEFMOG[i].JLPLLECHHLG);
						bw.Write(NNDGIAEFMOG[i].EAHPLCJMPHD_PId);
						bw.Write(NNDGIAEFMOG[i].KJBGCLPMLCG_OpenedAt);
						bw.Write(NNDGIAEFMOG[i].GJFPFFBAKGK_CloseAt);
					}
				}
				bw.Flush();
				bw.Close();
			}
		}
	}

	// // RVA: 0x141E328 Offset: 0x141E328 VA: 0x141E328
	private static void AKIFCOIDAHD(List<JBCAHMMCOKK> NNDGIAEFMOG)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		DateTime date = Utility.GetLocalDateTime(time);
		string persistPath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath;
		string path = persistPath + "/sys" + "/20";
		if(File.Exists(path))
		{
			using(FileStream fs = new FileStream(path, FileMode.Open))
			{
				using(BinaryReader br = new BinaryReader(fs))
				{
					int v = br.ReadInt32();
					if(v == 0x14114144)
					{
						int a1 = br.ReadInt32();
						long a2 = br.ReadInt64();
						DateTime date2 =Utility.GetLocalDateTime(a2);
						if(date.Date != date2.Date)
						{
							for(int i = 0; i < a1; i++)
							{
								int a3 = br.ReadInt32();
								int a4 = br.ReadInt32();
								long a5 = br.ReadInt64();
								long a6 = br.ReadInt64();
								for(int j = 0; j < NNDGIAEFMOG.Count; j++)
								{
									if(NNDGIAEFMOG[j].HCAIOHFNCPE == JPLHJHGBMON.HDHACKFJKGM_2 || NNDGIAEFMOG[j].HCAIOHFNCPE == JPLHJHGBMON.NEKOJOCFHKP_4)
									{
										if(NNDGIAEFMOG[j].JLPLLECHHLG == a3)
										{
											if(NNDGIAEFMOG[j].EAHPLCJMPHD_PId == a4)
											{
												if(NNDGIAEFMOG[j].KJBGCLPMLCG_OpenedAt == a5)
												{
													if(NNDGIAEFMOG[j].GJFPFFBAKGK_CloseAt == a6)
													{
														NNDGIAEFMOG[j].CLDKMLONBHJ = true;
													}
												}
											}
										}
									}
								}
							}
						}
						else
						{
							for(int i = 0; i < a1; i++)
							{
								int a3 = br.ReadInt32();
								int a4 = br.ReadInt32();
								long a5 = br.ReadInt64();
								long a6 = br.ReadInt64();
								for(int j = 0; j < NNDGIAEFMOG.Count; j++)
								{
									if(NNDGIAEFMOG[j].JLPLLECHHLG == a3)
									{
										if(NNDGIAEFMOG[j].EAHPLCJMPHD_PId == a4)
										{
											if(NNDGIAEFMOG[j].KJBGCLPMLCG_OpenedAt == a5)
											{
												if(NNDGIAEFMOG[j].GJFPFFBAKGK_CloseAt == a6)
												{
													NNDGIAEFMOG[j].CLDKMLONBHJ = true;
												}
											}
										}
									}
								}
							}
						}
					}
					br.Close();
				}
			}
		}
	}

	// // RVA: 0x142025C Offset: 0x142025C VA: 0x142025C
	private static List<int> JCGOHOJCNLE(List<JBCAHMMCOKK> NNDGIAEFMOG, int _KGICDMIJGDF_Group)
	{
		List<int> l = new List<int>();
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].KGICDMIJGDF_Group == _KGICDMIJGDF_Group)
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
			int a = NNDGIAEFMOG[i].KGICDMIJGDF_Group;
			if(a > 0)
			{
				int idx = l.FindIndex((int _GHPLINIACBB_x) =>
				{
					//0x1420628
					return a == _GHPLINIACBB_x;
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
							NNDGIAEFMOG[l2[j]].BJIMIONBKDD_ShowPopup = false;
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
							NNDGIAEFMOG[l2[j]].BJIMIONBKDD_ShowPopup = false;
							NNDGIAEFMOG[l2[j]].LDLFAKLAMFG = false;
						}
					}
				}
			}
		}
		List<JBCAHMMCOKK> res = new List<JBCAHMMCOKK>();
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].BJIMIONBKDD_ShowPopup || NNDGIAEFMOG[i].LDLFAKLAMFG)
			{
				res.Add(NNDGIAEFMOG[i]);
			}
		}
		return res;
	}
}
