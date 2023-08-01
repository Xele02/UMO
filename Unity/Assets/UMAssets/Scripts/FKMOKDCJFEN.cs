
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class FKMOKDCJFEN
{
	public enum MEDJADCKPKH
	{
		HEFPAOLDHCK_Daily = 0,
		CCAPCGPIIPF_Normal = 1,
		CCDOBDNDPIL_Event = 2,
	}

	public enum ADCPCCNCOMD_Status
	{
		HJNNKCMLGFL = 0,
		HIDGJCIFFNJ = 1,
		FJGFAPKLLCL_Achieved = 2,
		CADDNFIKDLG = 3,
	}

	public IKDICBBFBMI_EventBase COAMJFMEIBF; // 0x8
	public MEDJADCKPKH JONPKLHMOBL; // 0xC
	public ADCPCCNCOMD_Status CMCKNKKCNDK_Status; // 0x10
	public int CMEJFJFOIIJ_QuestId; // 0x14
	public string KLMPFGOCBHC_Description; // 0x18
	public string CJCGFKDMDMN_DescriptionB; // 0x1C
	public long BLHJBMPONHC; // 0x20
	public long PNHMDOHCBGK; // 0x28
	public int ABLHIAEDJAI_CurrentValue; // 0x30
	public int HLDGMMDFNHB; // 0x34
	public int EEFLOOBOAGF; // 0x38
	public int HAMGPOIFBCD_Type; // 0x3C
	public bool OAPCHMHAJID; // 0x40
	public MFDJIFIIPJD GOOIIPFHOIG; // 0x44
	public string JOPOPMLFINI; // 0x48
	public BKANGIKIEML.NODKLJHEAJB NNHHNFFLCFO; // 0x4C
	public int EEPNJFCNIEF; // 0x50
	public int LMPPENOILPF; // 0x54
	public bool CADENLBDAEB_New; // 0x58
	public bool PNFDMBHDPAJ; // 0x59
	public bool EFJDHILLIEK; // 0x5A
	public long KJBGCLPMLCG; // 0x60
	public long GJFPFFBAKGK; // 0x68
	public static long IHKAGLGBDEE; // 0x0
	public int DLAFBGPFEON; // 0x70

	//// RVA: 0x118827C Offset: 0x118827C VA: 0x118827C
	public void ADGHFCOKPOP_InitDailyQuest(int CMEJFJFOIIJ)
	{
		JONPKLHMOBL = MEDJADCKPKH.HEFPAOLDHCK_Daily/*0*/;
		this.CMEJFJFOIIJ_QuestId = CMEJFJFOIIJ;
		OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		BBHNACPENDM_ServerSaveData serverSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		CNLPPCFJEID_QuestInfo NDFIEMPPMLF_dbQuest = db.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[CMEJFJFOIIJ - 1];
		NFPHOINMHKN_QuestInfo saveQuest = serverSave.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[CMEJFJFOIIJ - 1];
		MessageBank bk = MessageManager.Instance.GetBank("master");
		KLMPFGOCBHC_Description = bk.GetMessageByLabel("qd_dsc_" + CMEJFJFOIIJ.ToString("D4"));
		CJCGFKDMDMN_DescriptionB = bk.GetMessageByLabel("qd_dscb_" + CMEJFJFOIIJ.ToString("D4"));
		ABLHIAEDJAI_CurrentValue = (int)ILLPDLODANB.DCLKMNGMIKC_GetQuestCurrentValue(NDFIEMPPMLF_dbQuest, db, serverSave);
		HLDGMMDFNHB = NDFIEMPPMLF_dbQuest.FCDKJAKLGMB;
		if (HLDGMMDFNHB <= ABLHIAEDJAI_CurrentValue)
			ABLHIAEDJAI_CurrentValue = HLDGMMDFNHB;
		EEFLOOBOAGF = NDFIEMPPMLF_dbQuest.EILKGEADKGH;
		HAMGPOIFBCD_Type = NDFIEMPPMLF_dbQuest.INDDJNMPONH_Type;
		EEPNJFCNIEF = NDFIEMPPMLF_dbQuest.INDDJNMPONH_Type;
		NNHHNFFLCFO = ILLPDLODANB.HNHNHHCBLDE((ILLPDLODANB.LOEGALDKHPL)NDFIEMPPMLF_dbQuest.INDDJNMPONH_Type, NDFIEMPPMLF_dbQuest.CHOFDPDFPDC_ConfigValue);
		CADENLBDAEB_New = saveQuest.CADENLBDAEB_New;
		PNFDMBHDPAJ = false;
		EFJDHILLIEK = false;
		KJBGCLPMLCG = NDFIEMPPMLF_dbQuest.KJBGCLPMLCG;
		GJFPFFBAKGK = NDFIEMPPMLF_dbQuest.GJFPFFBAKGK;
		LCKMNLOLDPD l = db.MHGPMMIDKMM_Quest.LFAAEPAAEMB.Find((LCKMNLOLDPD GHPLINIACBB) =>
		{
			//0x118EA04
			return GHPLINIACBB.PPFNGGCBJKC == NDFIEMPPMLF_dbQuest.EIHOBHDKCDB;
		});
		GOOIIPFHOIG = new MFDJIFIIPJD();
		GOOIIPFHOIG.KHEKNNFCAOI(l.GLCLFMGPMAN, l.HMFFHLPNMPH);
		DLAFBGPFEON = 0;
		LMPPENOILPF = 0;
		HCDGELDHFHB();
	}

	//// RVA: 0x1188B44 Offset: 0x1188B44 VA: 0x1188B44
	public void PHGLNKFFEME_InitNormalQuest(int CMEJFJFOIIJ)
	{
		JONPKLHMOBL = MEDJADCKPKH.CCAPCGPIIPF_Normal/*1*/;
		this.CMEJFJFOIIJ_QuestId = CMEJFJFOIIJ;
		OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		BBHNACPENDM_ServerSaveData serverSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		CNLPPCFJEID_QuestInfo NDFIEMPPMLF_dbQuest = db.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[CMEJFJFOIIJ - 1];
		NFPHOINMHKN_QuestInfo saveQuest = serverSave.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[CMEJFJFOIIJ - 1];
		MessageBank bk = MessageManager.Instance.GetBank("master");
		KLMPFGOCBHC_Description = bk.GetMessageByLabel("qd_dsc_" + CMEJFJFOIIJ.ToString("D4"));
		CJCGFKDMDMN_DescriptionB = bk.GetMessageByLabel("qd_dscb_" + CMEJFJFOIIJ.ToString("D4"));
		ABLHIAEDJAI_CurrentValue = (int)ILLPDLODANB.DCLKMNGMIKC_GetQuestCurrentValue(NDFIEMPPMLF_dbQuest, db, serverSave);
		HLDGMMDFNHB = NDFIEMPPMLF_dbQuest.FCDKJAKLGMB;
		if (HLDGMMDFNHB <= ABLHIAEDJAI_CurrentValue)
			ABLHIAEDJAI_CurrentValue = HLDGMMDFNHB;
		EEFLOOBOAGF = NDFIEMPPMLF_dbQuest.EILKGEADKGH;
		HAMGPOIFBCD_Type = NDFIEMPPMLF_dbQuest.DEPGBBJMFED;
		EEPNJFCNIEF = NDFIEMPPMLF_dbQuest.INDDJNMPONH_Type;
		LMPPENOILPF = NDFIEMPPMLF_dbQuest.LMPPENOILPF;
		CADENLBDAEB_New = saveQuest.CADENLBDAEB_New;
		PNFDMBHDPAJ = false;
		EFJDHILLIEK = false;
		KJBGCLPMLCG = NDFIEMPPMLF_dbQuest.KJBGCLPMLCG;
		GJFPFFBAKGK = NDFIEMPPMLF_dbQuest.GJFPFFBAKGK;
		OAPCHMHAJID = NDFIEMPPMLF_dbQuest.OAPCHMHAJID;
		NNHHNFFLCFO = ILLPDLODANB.HNHNHHCBLDE((ILLPDLODANB.LOEGALDKHPL)NDFIEMPPMLF_dbQuest.INDDJNMPONH_Type, NDFIEMPPMLF_dbQuest.CHOFDPDFPDC_ConfigValue);
		LCKMNLOLDPD l = db.MHGPMMIDKMM_Quest.LFAAEPAAEMB.Find((LCKMNLOLDPD GHPLINIACBB) =>
		{
			//0x118EA68
			return GHPLINIACBB.PPFNGGCBJKC == NDFIEMPPMLF_dbQuest.EIHOBHDKCDB;
		});
		GOOIIPFHOIG = new MFDJIFIIPJD();
		GOOIIPFHOIG.KHEKNNFCAOI(l.GLCLFMGPMAN, l.HMFFHLPNMPH);
		DLAFBGPFEON = 0;
		HCDGELDHFHB();
	}

	//// RVA: 0x11891F8 Offset: 0x11891F8 VA: 0x11891F8
	//public void KAFDDLPNOCF(int CMEJFJFOIIJ, long JHNMKKNEENE, IKDICBBFBMI FBFNJMKPBBA, bool GEDMCDAPPNH = False) { }

	//// RVA: 0x11888FC Offset: 0x11888FC VA: 0x11888FC
	public void HCDGELDHFHB()
	{
		if(JONPKLHMOBL == MEDJADCKPKH.CCDOBDNDPIL_Event)
		{
			if (string.IsNullOrEmpty(JOPOPMLFINI))
				return;
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LKJGDCBCLKO(JOPOPMLFINI);
			if (ev == null)
				return;
			TodoLogger.LogError(0, "HCDGELDHFHB");
			//CMCKNKKCNDK_Status = ev.GBADILEHLGC(CMEJFJFOIIJ);
		}
		else
		{
			if (JONPKLHMOBL != MEDJADCKPKH.HEFPAOLDHCK_Daily)
				return;
			CMCKNKKCNDK_Status = (ADCPCCNCOMD_Status)ILLPDLODANB.KPEDEPGGMEC_GetDailyQuestStatus(CMEJFJFOIIJ_QuestId, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
		}
	}

	//// RVA: 0x118A27C Offset: 0x118A27C VA: 0x118A27C
	//public bool OFKCGMNFGKB(long LKCCMBEOLLA) { }

	//// RVA: 0x118A174 Offset: 0x118A174 VA: 0x118A174
	//public int NHNNGNACCNN() { }

	//// RVA: 0x118A2D0 Offset: 0x118A2D0 VA: 0x118A2D0
	//public int EGLMBACDION() { }

	//// RVA: 0x118A3D8 Offset: 0x118A3D8 VA: 0x118A3D8
	public string ADFLDIBPJLP()
	{
		if (string.IsNullOrEmpty(CJCGFKDMDMN_DescriptionB))
			return KLMPFGOCBHC_Description;
		return CJCGFKDMDMN_DescriptionB;
	}

	//// RVA: 0x118A400 Offset: 0x118A400 VA: 0x118A400
	//public static void LEHDLBJJBNC(List<FKMOKDCJFEN> NNDGIAEFMOG) { }

	//// RVA: 0x118A404 Offset: 0x118A404 VA: 0x118A404
	public static List<FKMOKDCJFEN> NNEHCMNOKFO_GetDailyQuests(bool FBBNPFFEJBN = false)
	{
		List<FKMOKDCJFEN> res = new List<FKMOKDCJFEN>();
		IHKAGLGBDEE = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GOACJBOCLHH_Quest.DFFFCPCHBBE_EndDate();
		List<NFPHOINMHKN_QuestInfo> dailyQuest = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests;
		for(int i = 0; i < dailyQuest.Count; i++)
		{
			if(dailyQuest[i].EALOBDHOCHP_Stat == 0)
			{
				;
			}
			else
			{
				FKMOKDCJFEN data = new FKMOKDCJFEN();
				data.ADGHFCOKPOP_InitDailyQuest(i + 1);
				res.Add(data);
			}
		}
		int[] NKIICMCKKMD = new int[4] { 4, 2, 1, 3 };
		res.Sort((FKMOKDCJFEN HKICMNAACDA, FKMOKDCJFEN BNKHBCBJBKI) =>
		{
			//0x118EAE0
			int r = NKIICMCKKMD[(int)HKICMNAACDA.CMCKNKKCNDK_Status] - NKIICMCKKMD[(int)BNKHBCBJBKI.CMCKNKKCNDK_Status];
			if(r == 0)
			{
				r = HKICMNAACDA.EEFLOOBOAGF - BNKHBCBJBKI.EEFLOOBOAGF;
			}
			return r;
		});
		return res;
	}

	//// RVA: 0x118A79C Offset: 0x118A79C VA: 0x118A79C
	public static FKMOKDCJFEN KFHCJLFAHAG()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		List<NFPHOINMHKN_QuestInfo> quests = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests;
		for(int i = 0; i < quests.Count; i++)
		{
			CNLPPCFJEID_QuestInfo dbQuest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[i];
			if(dbQuest.INDDJNMPONH_Type != 0)
			{
				if(dbQuest.OAPCHMHAJID)
				{
					if((dbQuest.KJBGCLPMLCG == 0 && dbQuest.GJFPFFBAKGK == 0) ||
						(time >= dbQuest.KJBGCLPMLCG && dbQuest.GJFPFFBAKGK >= time))
					{
						if(dbQuest.HHIBBHFHENH_LinkQuestId == dbQuest.PPFNGGCBJKC)
						{
							Debug.Log(JpStringLiterals.StringLiteral_10346);
						}
						else
						{
							bool isValid = true;
							if(dbQuest.HHIBBHFHENH_LinkQuestId != 0)
							{
								CNLPPCFJEID_QuestInfo linkedQuest = dbQuest;
								while(linkedQuest.HHIBBHFHENH_LinkQuestId != 0)
								{
									if (ILLPDLODANB.OBOJKHIJBGL(linkedQuest.HHIBBHFHENH_LinkQuestId, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, false) < 2)
									{
										isValid = false;
										break;
									}
									linkedQuest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[linkedQuest.HHIBBHFHENH_LinkQuestId - 1];
								}
								if (!isValid)
									continue;
							}
							int a = ILLPDLODANB.OBOJKHIJBGL(dbQuest.PPFNGGCBJKC, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, false);
							if (a > 0 && a < 3)
							{
								FKMOKDCJFEN data = new FKMOKDCJFEN();
								data.PHGLNKFFEME_InitNormalQuest(dbQuest.PPFNGGCBJKC);
								return data;
							}
						}
					}
				}
			}
		}
		return null;
	}

	//// RVA: 0x118AD14 Offset: 0x118AD14 VA: 0x118AD14
	public static List<FKMOKDCJFEN> ABHPOFCEAEN_GetNormalQuests(bool FBBNPFFEJBN = false)
	{
		return CMLEFPDNBCB(FBBNPFFEJBN, 0, false);
	}

	//// RVA: 0x118B9C8 Offset: 0x118B9C8 VA: 0x118B9C8
	public static List<FKMOKDCJFEN> IHEMBPBBIEO(bool FBBNPFFEJBN = false)
	{
		return CMLEFPDNBCB(FBBNPFFEJBN, 1, false);
	}

	//// RVA: 0x118B9D4 Offset: 0x118B9D4 VA: 0x118B9D4
	public static List<FKMOKDCJFEN> BAENBNLMPMO(bool FBBNPFFEJBN = false)
	{
		return CMLEFPDNBCB(FBBNPFFEJBN, 2, false);
	}

	//// RVA: 0x118AD20 Offset: 0x118AD20 VA: 0x118AD20
	public static List<FKMOKDCJFEN> CMLEFPDNBCB(bool FBBNPFFEJBN = false, int EMJFHKHLHDB = 0, bool PLOBIFBCFMC = false)
	{
		OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		BBHNACPENDM_ServerSaveData serverSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		List<CNLPPCFJEID_QuestInfo> dbQuestsList = db.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests;
		List<NFPHOINMHKN_QuestInfo> saveQuestsList = serverSave.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests;
		List<FKMOKDCJFEN> res = new List<FKMOKDCJFEN>();
		for(int i = 0; i < saveQuestsList.Count; i++)
		{
			CNLPPCFJEID_QuestInfo MABBBOEAPAA_dbQuest = dbQuestsList[i];
			if (MABBBOEAPAA_dbQuest.INDDJNMPONH_Type != 0)
			{
				if((MABBBOEAPAA_dbQuest.KJBGCLPMLCG == 0 && MABBBOEAPAA_dbQuest.GJFPFFBAKGK == 0) ||
					(time >= MABBBOEAPAA_dbQuest.KJBGCLPMLCG && MABBBOEAPAA_dbQuest.GJFPFFBAKGK >= time))
				{
					//LAB_0118b20c
					bool zz = false;
					if (!PLOBIFBCFMC)
					{
						if (EMJFHKHLHDB == 2)
						{
							if (ILLPDLODANB.HHMKDAIGMKC((ILLPDLODANB.LOEGALDKHPL)MABBBOEAPAA_dbQuest.INDDJNMPONH_Type))
							{
								//LAB_0118b218
								zz = true;
							}
						}
						else
						{
							bool b = false;
							if (EMJFHKHLHDB == 1)
							{
								b = ILLPDLODANB.FJFPHHEFMIB(MABBBOEAPAA_dbQuest);
							}
							else
							{
								if (EMJFHKHLHDB != 0)
								{
									//LAB_0118b218
									zz = true;
								}
								if (ILLPDLODANB.FJFPHHEFMIB(MABBBOEAPAA_dbQuest))
								{
									continue;
								}
								b = ILLPDLODANB.HHMKDAIGMKC((ILLPDLODANB.LOEGALDKHPL)MABBBOEAPAA_dbQuest.INDDJNMPONH_Type);
							}
							if (b)
							{
								//LAB_0118b218
								zz = true;
							}
						}
					}
					else
					{
						//LAB_0118b218
						zz = true;
					}
					if(zz)
					{ 
						if (ILLPDLODANB.HHMKDAIGMKC((ILLPDLODANB.LOEGALDKHPL)MABBBOEAPAA_dbQuest.INDDJNMPONH_Type))
						{
							if(saveQuestsList[i].EALOBDHOCHP_Stat > 2)
							{
								continue;
							}
						}
						int idx = res.FindIndex((FKMOKDCJFEN JPAEDJJFFOI) =>
						{
							//0x118EC60
							return JPAEDJJFFOI.HAMGPOIFBCD_Type == MABBBOEAPAA_dbQuest.DEPGBBJMFED;
						});
						if(idx != -1)
						{
							if(res[idx].CMCKNKKCNDK_Status > 0 && res[idx].CMCKNKKCNDK_Status <= ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved)
							{
								continue;
							}
						}
						if(!FBBNPFFEJBN)
						{
							if(MABBBOEAPAA_dbQuest.HHIBBHFHENH_LinkQuestId != 0)
							{
								if(saveQuestsList[i].EALOBDHOCHP_Stat < 2)
								{
									int a = ILLPDLODANB.OBOJKHIJBGL(saveQuestsList[i].EALOBDHOCHP_Stat, db, serverSave, false);
									CNLPPCFJEID_QuestInfo q2 = dbQuestsList[MABBBOEAPAA_dbQuest.HHIBBHFHENH_LinkQuestId - 1];
									bool d = ILLPDLODANB.HHMKDAIGMKC((ILLPDLODANB.LOEGALDKHPL)q2.INDDJNMPONH_Type);
									int e = 1;
									if (d)
										e = 2;
									if(a <= e)
									{
										continue;
									}
								}
							}
						}
						if(ILLPDLODANB.OBOJKHIJBGL(MABBBOEAPAA_dbQuest.PPFNGGCBJKC, db, serverSave, false) != 0)
						{
							FKMOKDCJFEN data = new FKMOKDCJFEN();
							data.PHGLNKFFEME_InitNormalQuest(MABBBOEAPAA_dbQuest.PPFNGGCBJKC);
							if(idx == -1)
							{
								res.Add(data);
							}
							else
							{
								res[idx] = data;
							}
						}
					}
				}
			}
			//LAB_0118b850
		}
		int[] NKIICMCKKMD = new int[4] { 4, 2, 1, 3 };
		res.Sort((FKMOKDCJFEN HKICMNAACDA, FKMOKDCJFEN BNKHBCBJBKI) =>
		{
			//0x118EBA0
			int r = NKIICMCKKMD[(int)HKICMNAACDA.CMCKNKKCNDK_Status] - NKIICMCKKMD[(int)BNKHBCBJBKI.CMCKNKKCNDK_Status];
			if (r == 0)
			{
				r = HKICMNAACDA.EEFLOOBOAGF - BNKHBCBJBKI.EEFLOOBOAGF;
			}
			return r;
		});
		return res;
	}

	//// RVA: 0x118B9F0 Offset: 0x118B9F0 VA: 0x118B9F0
	//public static List<FKMOKDCJFEN> KJHKBBBDBAL(string JOPOPMLFINI, bool GEDMCDAPPNH = False, int PLLOPLOEGDC = -1) { }

	//// RVA: 0x118BF50 Offset: 0x118BF50 VA: 0x118BF50
	//public static int HDCCHOGIBKG() { }

	//// RVA: 0x118C068 Offset: 0x118C068 VA: 0x118C068
	//public static int BDMMKMALOEN(FKMOKDCJFEN.MEDJADCKPKH JONPKLHMOBL, List<int> MBFCHNDGNDP, string JOPOPMLFINI) { }

	//// RVA: 0x118C548 Offset: 0x118C548 VA: 0x118C548
	//public static void JKBOOMAPOBL(FKMOKDCJFEN.MEDJADCKPKH JONPKLHMOBL, List<int> MBFCHNDGNDP, string JOPOPMLFINI, Action<List<int>, bool> BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, bool KPBMFAALBKC = False) { }

	//// RVA: 0x118DFAC Offset: 0x118DFAC VA: 0x118DFAC
	//private static void PKCIICBKEMG(BBHNACPENDM LNEAHKALBHN, OKGLGHCBCJP JLBMBKHBKBG, int MBBJMJAAODG, int ENHEJFPMPJH) { }

	//// RVA: 0x118DD9C Offset: 0x118DD9C VA: 0x118DD9C
	//private static bool CEHIEFPLPFM(BBHNACPENDM LNEAHKALBHN, OKGLGHCBCJP JLBMBKHBKBG, int MBBJMJAAODG, int ENHEJFPMPJH) { }

	//// RVA: 0x118E2AC Offset: 0x118E2AC VA: 0x118E2AC
	//public void KKFFEJEKFEG(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH) { }
}
