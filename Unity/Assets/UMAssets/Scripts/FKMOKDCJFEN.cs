
using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Menu;
using XeSys;

public class FKMOKDCJFEN
{
	public enum MEDJADCKPKH
	{
		HEFPAOLDHCK_Daily = 0,
		CCAPCGPIIPF_Normal = 1,
		CCDOBDNDPIL_2_Event = 2,
	}

	public enum ADCPCCNCOMD_Status
	{
		HJNNKCMLGFL_0_None = 0,
		HIDGJCIFFNJ_1 = 1,
		FJGFAPKLLCL_Achieved = 2,
		CADDNFIKDLG_Received = 3,
	}

	public IKDICBBFBMI_EventBase COAMJFMEIBF; // 0x8
	public MEDJADCKPKH JONPKLHMOBL_Category; // 0xC
	public ADCPCCNCOMD_Status CMCKNKKCNDK_status; // 0x10
	public int CMEJFJFOIIJ_QuestId; // 0x14
	public string KLMPFGOCBHC_description; // 0x18
	public string CJCGFKDMDMN_DescriptionB; // 0x1C
	public long BLHJBMPONHC; // 0x20
	public long PNHMDOHCBGK; // 0x28
	public int ABLHIAEDJAI_CurrentValue; // 0x30
	public int HLDGMMDFNHB_TargetValue; // 0x34
	public int EEFLOOBOAGF_ViewOrder; // 0x38
	public int HAMGPOIFBCD_Type; // 0x3C
	public bool OAPCHMHAJID; // 0x40
	public MFDJIFIIPJD GOOIIPFHOIG; // 0x44
	public string JOPOPMLFINI_QuestName; // 0x48
	public BKANGIKIEML.NODKLJHEAJB NNHHNFFLCFO; // 0x4C
	public int EEPNJFCNIEF_ClearType; // 0x50
	public int LMPPENOILPF; // 0x54
	public bool CADENLBDAEB_IsNew; // 0x58
	public bool PNFDMBHDPAJ_IsRewardOnly; // 0x59
	public bool EFJDHILLIEK_IsDaily; // 0x5A
	public long KJBGCLPMLCG_OpenedAt; // 0x60
	public long GJFPFFBAKGK_CloseAt; // 0x68
	public static long IHKAGLGBDEE; // 0x0
	public int DLAFBGPFEON; // 0x70

	//// RVA: 0x118827C Offset: 0x118827C VA: 0x118827C
	public void ADGHFCOKPOP_InitDailyQuest(int _CMEJFJFOIIJ_QuestId)
	{
		JONPKLHMOBL_Category = MEDJADCKPKH.HEFPAOLDHCK_Daily/*0*/;
		this.CMEJFJFOIIJ_QuestId = _CMEJFJFOIIJ_QuestId;
		OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		BBHNACPENDM_ServerSaveData serverSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		CNLPPCFJEID_QuestInfo NDFIEMPPMLF_master = db.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[_CMEJFJFOIIJ_QuestId - 1];
		NFPHOINMHKN_QuestInfo saveQuest = serverSave.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[_CMEJFJFOIIJ_QuestId - 1];
		MessageBank bk = MessageManager.Instance.GetBank("master");
		KLMPFGOCBHC_description = bk.GetMessageByLabel("qd_dsc_" + _CMEJFJFOIIJ_QuestId.ToString("D4"));
		if(RuntimeSettings.CurrentSettings.DisplayIdInName)
			KLMPFGOCBHC_description = "[" + _CMEJFJFOIIJ_QuestId.ToString() + "] " + KLMPFGOCBHC_description;
		CJCGFKDMDMN_DescriptionB = bk.GetMessageByLabel("qd_dscb_" + _CMEJFJFOIIJ_QuestId.ToString("D4"));
		ABLHIAEDJAI_CurrentValue = (int)ILLPDLODANB.DCLKMNGMIKC_GetCurrentValue(NDFIEMPPMLF_master, db, serverSave);
		HLDGMMDFNHB_TargetValue = NDFIEMPPMLF_master.FCDKJAKLGMB_TargetValue;
		if (HLDGMMDFNHB_TargetValue <= ABLHIAEDJAI_CurrentValue)
			ABLHIAEDJAI_CurrentValue = HLDGMMDFNHB_TargetValue;
		EEFLOOBOAGF_ViewOrder = NDFIEMPPMLF_master.EILKGEADKGH_Order;
		HAMGPOIFBCD_Type = NDFIEMPPMLF_master.INDDJNMPONH_type;
		EEPNJFCNIEF_ClearType = NDFIEMPPMLF_master.INDDJNMPONH_type;
		NNHHNFFLCFO = ILLPDLODANB.HNHNHHCBLDE((ILLPDLODANB.LOEGALDKHPL)NDFIEMPPMLF_master.INDDJNMPONH_type, NDFIEMPPMLF_master.CHOFDPDFPDC_ConfigValue);
		CADENLBDAEB_IsNew = saveQuest.CADENLBDAEB_IsNew;
		PNFDMBHDPAJ_IsRewardOnly = false;
		EFJDHILLIEK_IsDaily = false;
		KJBGCLPMLCG_OpenedAt = NDFIEMPPMLF_master.KJBGCLPMLCG_OpenedAt;
		GJFPFFBAKGK_CloseAt = NDFIEMPPMLF_master.GJFPFFBAKGK_CloseAt;
		LCKMNLOLDPD l = db.MHGPMMIDKMM_Quest.LFAAEPAAEMB.Find((LCKMNLOLDPD _GHPLINIACBB_x) =>
		{
			//0x118EA04
			return _GHPLINIACBB_x.PPFNGGCBJKC_id == NDFIEMPPMLF_master.EIHOBHDKCDB_RewardId;
		});
		GOOIIPFHOIG = new MFDJIFIIPJD();
		GOOIIPFHOIG.KHEKNNFCAOI_Init(l.GLCLFMGPMAN_ItemId, l.HMFFHLPNMPH_count);
		DLAFBGPFEON = 0;
		LMPPENOILPF = 0;
		HCDGELDHFHB();
	}

	//// RVA: 0x1188B44 Offset: 0x1188B44 VA: 0x1188B44
	public void PHGLNKFFEME_InitNormalQuest(int _CMEJFJFOIIJ_QuestId)
	{
		JONPKLHMOBL_Category = MEDJADCKPKH.CCAPCGPIIPF_Normal/*1*/;
		this.CMEJFJFOIIJ_QuestId = _CMEJFJFOIIJ_QuestId;
		OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		BBHNACPENDM_ServerSaveData serverSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		CNLPPCFJEID_QuestInfo NDFIEMPPMLF_master = db.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[_CMEJFJFOIIJ_QuestId - 1];
		NFPHOINMHKN_QuestInfo saveQuest = serverSave.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[_CMEJFJFOIIJ_QuestId - 1];
		MessageBank bk = MessageManager.Instance.GetBank("master");
		KLMPFGOCBHC_description = bk.GetMessageByLabel("qn_dsc_" + _CMEJFJFOIIJ_QuestId.ToString("D4"));
		if(RuntimeSettings.CurrentSettings.DisplayIdInName)
			KLMPFGOCBHC_description = "[" + _CMEJFJFOIIJ_QuestId.ToString() + "] " + KLMPFGOCBHC_description;
		CJCGFKDMDMN_DescriptionB = bk.GetMessageByLabel("qn_dscb_" + _CMEJFJFOIIJ_QuestId.ToString("D4"));
		ABLHIAEDJAI_CurrentValue = (int)ILLPDLODANB.DCLKMNGMIKC_GetCurrentValue(NDFIEMPPMLF_master, db, serverSave);
		HLDGMMDFNHB_TargetValue = NDFIEMPPMLF_master.FCDKJAKLGMB_TargetValue;
		if (HLDGMMDFNHB_TargetValue <= ABLHIAEDJAI_CurrentValue)
			ABLHIAEDJAI_CurrentValue = HLDGMMDFNHB_TargetValue;
		EEFLOOBOAGF_ViewOrder = NDFIEMPPMLF_master.EILKGEADKGH_Order;
		HAMGPOIFBCD_Type = NDFIEMPPMLF_master.DEPGBBJMFED_CategoryId;
		EEPNJFCNIEF_ClearType = NDFIEMPPMLF_master.INDDJNMPONH_type;
		LMPPENOILPF = NDFIEMPPMLF_master.LMPPENOILPF;
		CADENLBDAEB_IsNew = saveQuest.CADENLBDAEB_IsNew;
		PNFDMBHDPAJ_IsRewardOnly = false;
		EFJDHILLIEK_IsDaily = false;
		KJBGCLPMLCG_OpenedAt = NDFIEMPPMLF_master.KJBGCLPMLCG_OpenedAt;
		GJFPFFBAKGK_CloseAt = NDFIEMPPMLF_master.GJFPFFBAKGK_CloseAt;
		OAPCHMHAJID = NDFIEMPPMLF_master.OAPCHMHAJID;
		NNHHNFFLCFO = ILLPDLODANB.HNHNHHCBLDE((ILLPDLODANB.LOEGALDKHPL)NDFIEMPPMLF_master.INDDJNMPONH_type, NDFIEMPPMLF_master.CHOFDPDFPDC_ConfigValue);
		LCKMNLOLDPD l = db.MHGPMMIDKMM_Quest.LFAAEPAAEMB.Find((LCKMNLOLDPD _GHPLINIACBB_x) =>
		{
			//0x118EA68
			return _GHPLINIACBB_x.PPFNGGCBJKC_id == NDFIEMPPMLF_master.EIHOBHDKCDB_RewardId;
		});
		GOOIIPFHOIG = new MFDJIFIIPJD();
		GOOIIPFHOIG.KHEKNNFCAOI_Init(l.GLCLFMGPMAN_ItemId, l.HMFFHLPNMPH_count);
		DLAFBGPFEON = 0;
		HCDGELDHFHB();
	}

	//// RVA: 0x11891F8 Offset: 0x11891F8 VA: 0x11891F8
	public void KAFDDLPNOCF(int _CMEJFJFOIIJ_QuestId, long _JHNMKKNEENE_Time, IKDICBBFBMI_EventBase FBFNJMKPBBA, bool GEDMCDAPPNH/* = false*/)
	{
		DLAFBGPFEON = 0;
		CMEJFJFOIIJ_QuestId = _CMEJFJFOIIJ_QuestId;
		COAMJFMEIBF = FBFNJMKPBBA;
		JONPKLHMOBL_Category = MEDJADCKPKH.CCDOBDNDPIL_2_Event;
		long aa = 0;
		if(FBFNJMKPBBA == null)
		{
			KLMPFGOCBHC_description = string.Concat(JpStringLiterals.StringLiteral_10345, _CMEJFJFOIIJ_QuestId);
			ABLHIAEDJAI_CurrentValue = 0;
			HLDGMMDFNHB_TargetValue = 100;
			EEFLOOBOAGF_ViewOrder = 1;
			HAMGPOIFBCD_Type = 1;
			GOOIIPFHOIG = new MFDJIFIIPJD();
			GOOIIPFHOIG.KHEKNNFCAOI_Init(EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit, 1, 100);
		}
		else
		{
			bool b2 = false;
			JOPOPMLFINI_QuestName = FBFNJMKPBBA.JOPOPMLFINI_QuestName;
			KLMPFGOCBHC_description = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].FEMMDNIELFC_Desc;
			CJCGFKDMDMN_DescriptionB = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].BGBJPGEIEDE_DescBalloon;
			if(!(FBFNJMKPBBA is KNKDBNFMAKF_EventSp))
			{
				BLHJBMPONHC = FBFNJMKPBBA.DPJCPDKALGI_RankingEnd;
			}
			else
			{
				KNKDBNFMAKF_EventSp ev = FBFNJMKPBBA as KNKDBNFMAKF_EventSp;
				BLHJBMPONHC = ev.DPJCPDKALGI_RankingEnd;
				long v1, v2, v3;
				b2 = ev.NEMGJHBEJCP(FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].KGICDMIJGDF_Group, _JHNMKKNEENE_Time, out v1, out v2, out v3, out aa);
				if(b2)
				{
					BLHJBMPONHC = v2;
				}
			}
			KJBGCLPMLCG_OpenedAt = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].KJBGCLPMLCG_OpenedAt;
			GJFPFFBAKGK_CloseAt = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].GJFPFFBAKGK_CloseAt;
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			DateTime d1 = Utility.GetLocalDateTime(time);
			DateTime d2 = Utility.GetLocalDateTime(BLHJBMPONHC);
			long t1 = Utility.GetTargetUnixTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
			long t2 = Utility.GetTargetUnixTime(d2.Year, d2.Month, d2.Day, 0, 0, 0);
			if(t1 == t2)
			{
				if(FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].GBJFNGCDKPM_typ == 2)
				{
					DateTime d3 = Utility.GetLocalDateTime(GJFPFFBAKGK_CloseAt);
					long t3 = Utility.GetTargetUnixTime(d3.Year, d3.Month, d3.Day, 0, 0, 0);
					if(t1 == t3)
					{
						//LAB_011897a8
						GJFPFFBAKGK_CloseAt = BLHJBMPONHC;
					}
				}
			}
			else
			{
				if(time < BLHJBMPONHC && FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].GBJFNGCDKPM_typ == 2)
				{
					long t4 = Utility.GetTargetUnixTime(d1.Year, d1.Month, d1.Day, 23, 59, 59);
					if(FBFNJMKPBBA.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
					{
						KNKDBNFMAKF_EventSp ev = FBFNJMKPBBA as KNKDBNFMAKF_EventSp;
						List<int> l = ev.OKBLKNPJPKJ_GetSubIds();
						IKDICBBFBMI_EventBase ev2 = null;
						for(int i = 0; i < l.Count; i++)
						{
							//LAB_01189a60
                            ev2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(l[i]);
							if(ev2 == null || _JHNMKKNEENE_Time < ev2.GLIMIGNNGGB_RankingStart || ev2.DPJCPDKALGI_RankingEnd < _JHNMKKNEENE_Time)
							{
								continue;
							}
							break;
                        }
						if(ev2 != null)
						{
							//LAB_01189a90
							DateTime d3 = Utility.GetLocalDateTime(ev2.DPJCPDKALGI_RankingEnd);
							long t3 = Utility.GetTargetUnixTime(d3.Year, d3.Month, d3.Day, 0, 0, 0);
							if(t1 == t3)
							{
								if(FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].HBJJCDIMOPO_TargetMusicConditionId == 4)
								{
									BLHJBMPONHC = ev2.DPJCPDKALGI_RankingEnd;
									//LAB_01189d98
								}
								else if(FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].HBJJCDIMOPO_TargetMusicConditionId == 1)
								{
									int EHDDADDKMFI_f_id = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].HBJJCDIMOPO_TargetMusicConditionId;
									int idx = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.HEACCHAKMFG_GetMusicsList(ev2).FindIndex((int _GHPLINIACBB_x) =>
									{
										//0x118EACC
										return EHDDADDKMFI_f_id == _GHPLINIACBB_x;
									});
									if(idx > -1)
									{
										//LAB_011897a8
										BLHJBMPONHC = ev2.DPJCPDKALGI_RankingEnd;
									}
									else
									{
										//LAB_01189d88
										BLHJBMPONHC = t4;
									}
								}
								else
								{
									//LAB_01189d98
								}
							}
							else
							{
								//LAB_01189d88
								BLHJBMPONHC = t4;
							}
						}
						else
						{
							//LAB_01189d88
							BLHJBMPONHC = t4;
						}
					}
					else
					{
						//LAB_01189d88
						BLHJBMPONHC = t4;
					}
				}
			}
			//LAB_01189d98
			PNFDMBHDPAJ_IsRewardOnly = false;
			if(JONPKLHMOBL_Category == MEDJADCKPKH.CCDOBDNDPIL_2_Event)
			{
				if (NHNNGNACCNN() < 1)
					PNFDMBHDPAJ_IsRewardOnly = true;
			}
			EFJDHILLIEK_IsDaily = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].GBJFNGCDKPM_typ == 2;
			PNHMDOHCBGK = FBFNJMKPBBA.LJOHLEGGGMC_RewardEnd;
			if (b2)
				PNHMDOHCBGK = aa;
			if(FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].HDAMBOOCIAA_ClearType == 19)
			{
				ABLHIAEDJAI_CurrentValue = GBNDFCEDNMG.BJHFBOMILHG(FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1], FBFNJMKPBBA, time);
				HLDGMMDFNHB_TargetValue = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].JJECMJFDEEP_ClearConditionValue;
			}
			else
			{
				ABLHIAEDJAI_CurrentValue = FBFNJMKPBBA.GMFLMIHJAHB(FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].PPFNGGCBJKC_id);
				HLDGMMDFNHB_TargetValue = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].GLDIGCJNOBO_ClearCount;
			}
			if (HLDGMMDFNHB_TargetValue <= ABLHIAEDJAI_CurrentValue)
				ABLHIAEDJAI_CurrentValue = HLDGMMDFNHB_TargetValue;
			EEFLOOBOAGF_ViewOrder = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].EILKGEADKGH_Order;
			EEPNJFCNIEF_ClearType = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].HDAMBOOCIAA_ClearType;
			HAMGPOIFBCD_Type = 1;
			LMPPENOILPF = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].LMPPENOILPF;
			CADENLBDAEB_IsNew = FBFNJMKPBBA.OLDFFDMPEBM_Quests[_CMEJFJFOIIJ_QuestId - 1].CADENLBDAEB_IsNew;
			NNHHNFFLCFO = 0;
			if (!GEDMCDAPPNH)
				NNHHNFFLCFO = ILLPDLODANB.HNHNHHCBLDE(FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1], FBFNJMKPBBA);
			GOOIIPFHOIG = new MFDJIFIIPJD();
			GOOIIPFHOIG.KHEKNNFCAOI_Init(FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].KIJAPOFAGPN_ItemId, FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].JDLJPNMLFID_ItemCount);
			if(FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].HMOJCCPIPBP_TargetMusicType == 6)
			{
				DLAFBGPFEON = FBFNJMKPBBA.AGLILDLEFDK_Missions[_CMEJFJFOIIJ_QuestId - 1].HBJJCDIMOPO_TargetMusicConditionId;
			}
		}
		HCDGELDHFHB();
	}

	//// RVA: 0x11888FC Offset: 0x11888FC VA: 0x11888FC
	public void HCDGELDHFHB()
	{
		if(JONPKLHMOBL_Category == MEDJADCKPKH.CCDOBDNDPIL_2_Event)
		{
			if (string.IsNullOrEmpty(JOPOPMLFINI_QuestName))
				return;
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LKJGDCBCLKO(JOPOPMLFINI_QuestName);
			if (ev == null)
				return;
			CMCKNKKCNDK_status = (ADCPCCNCOMD_Status)ev.GBADILEHLGC_GetStatus(CMEJFJFOIIJ_QuestId);
		}
		else if(JONPKLHMOBL_Category == MEDJADCKPKH.CCAPCGPIIPF_Normal)
		{
			CMCKNKKCNDK_status = (ADCPCCNCOMD_Status)ILLPDLODANB.OBOJKHIJBGL_GetNormalQuestStatus(CMEJFJFOIIJ_QuestId, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, false);
		}
		else
		{
			if (JONPKLHMOBL_Category != MEDJADCKPKH.HEFPAOLDHCK_Daily)
				return;
			CMCKNKKCNDK_status = (ADCPCCNCOMD_Status)ILLPDLODANB.KPEDEPGGMEC_GetDailyQuestStatus(CMEJFJFOIIJ_QuestId, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
		}
	}

	//// RVA: 0x118A27C Offset: 0x118A27C VA: 0x118A27C
	public bool OFKCGMNFGKB(long LKCCMBEOLLA)
	{
		if (KJBGCLPMLCG_OpenedAt == 0 && GJFPFFBAKGK_CloseAt == 0)
			return true;
		if(KJBGCLPMLCG_OpenedAt < LKCCMBEOLLA)
		{
			return GJFPFFBAKGK_CloseAt >= LKCCMBEOLLA;
		}
		return false;
	}

	//// RVA: 0x118A174 Offset: 0x118A174 VA: 0x118A174
	public int NHNNGNACCNN()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		return (int)(BLHJBMPONHC - time);
	}

	//// RVA: 0x118A2D0 Offset: 0x118A2D0 VA: 0x118A2D0
	//public int EGLMBACDION() { }

	//// RVA: 0x118A3D8 Offset: 0x118A3D8 VA: 0x118A3D8
	public string ADFLDIBPJLP_GetDescription()
	{
		if (string.IsNullOrEmpty(CJCGFKDMDMN_DescriptionB))
			return KLMPFGOCBHC_description;
		return CJCGFKDMDMN_DescriptionB;
	}

	//// RVA: 0x118A400 Offset: 0x118A400 VA: 0x118A400
	//public static void LEHDLBJJBNC(List<FKMOKDCJFEN> NNDGIAEFMOG) { }

	//// RVA: 0x118A404 Offset: 0x118A404 VA: 0x118A404
	public static List<FKMOKDCJFEN> NNEHCMNOKFO_GetDailyQuests(bool _FBBNPFFEJBN_Force/* = false*/)
	{
		List<FKMOKDCJFEN> res = new List<FKMOKDCJFEN>();
		IHKAGLGBDEE = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.DFFFCPCHBBE_EndDate();
		List<NFPHOINMHKN_QuestInfo> dailyQuest = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests;
		for(int i = 0; i < dailyQuest.Count; i++)
		{
			if(dailyQuest[i].EALOBDHOCHP_stat == 0)
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
		res.Sort((FKMOKDCJFEN _HKICMNAACDA_a, FKMOKDCJFEN _BNKHBCBJBKI_b) =>
		{
			//0x118EAE0
			int r = NKIICMCKKMD[(int)_HKICMNAACDA_a.CMCKNKKCNDK_status] - NKIICMCKKMD[(int)_BNKHBCBJBKI_b.CMCKNKKCNDK_status];
			if(r == 0)
			{
				r = _HKICMNAACDA_a.EEFLOOBOAGF_ViewOrder - _BNKHBCBJBKI_b.EEFLOOBOAGF_ViewOrder;
			}
			return r;
		});
		return res;
	}

	//// RVA: 0x118A79C Offset: 0x118A79C VA: 0x118A79C
	public static FKMOKDCJFEN KFHCJLFAHAG()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		List<NFPHOINMHKN_QuestInfo> quests = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests;
		for(int i = 0; i < quests.Count; i++)
		{
			CNLPPCFJEID_QuestInfo dbQuest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[i];
			if(dbQuest.INDDJNMPONH_type != 0)
			{
				if(dbQuest.OAPCHMHAJID)
				{
					if((dbQuest.KJBGCLPMLCG_OpenedAt == 0 && dbQuest.GJFPFFBAKGK_CloseAt == 0) ||
						(time >= dbQuest.KJBGCLPMLCG_OpenedAt && dbQuest.GJFPFFBAKGK_CloseAt >= time))
					{
						if(dbQuest.HHIBBHFHENH_LinkQuestId == dbQuest.PPFNGGCBJKC_id)
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
									if (ILLPDLODANB.OBOJKHIJBGL_GetNormalQuestStatus(linkedQuest.HHIBBHFHENH_LinkQuestId, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, false) < 2)
									{
										isValid = false;
										break;
									}
									linkedQuest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[linkedQuest.HHIBBHFHENH_LinkQuestId - 1];
								}
								if (!isValid)
									continue;
							}
							int a = ILLPDLODANB.OBOJKHIJBGL_GetNormalQuestStatus(dbQuest.PPFNGGCBJKC_id, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, false);
							if (a > 0 && a < 3)
							{
								FKMOKDCJFEN data = new FKMOKDCJFEN();
								data.PHGLNKFFEME_InitNormalQuest(dbQuest.PPFNGGCBJKC_id);
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
	public static List<FKMOKDCJFEN> ABHPOFCEAEN_GetNormalQuests(bool _FBBNPFFEJBN_Force/* = false*/)
	{
		return CMLEFPDNBCB(_FBBNPFFEJBN_Force, 0, false);
	}

	//// RVA: 0x118B9C8 Offset: 0x118B9C8 VA: 0x118B9C8
	public static List<FKMOKDCJFEN> IHEMBPBBIEO_GetSnsQuest(bool _FBBNPFFEJBN_Force/* = false*/)
	{
		return CMLEFPDNBCB(_FBBNPFFEJBN_Force, 1, false);
	}

	//// RVA: 0x118B9D4 Offset: 0x118B9D4 VA: 0x118B9D4
	public static List<FKMOKDCJFEN> BAENBNLMPMO_GetBeginnerQuest(bool _FBBNPFFEJBN_Force/* = false*/)
	{
		return CMLEFPDNBCB(_FBBNPFFEJBN_Force, 2, false);
	}

	//// RVA: 0x118AD20 Offset: 0x118AD20 VA: 0x118AD20
	public static List<FKMOKDCJFEN> CMLEFPDNBCB(bool _FBBNPFFEJBN_Force/* = false*/, int EMJFHKHLHDB/* = 0*/, bool PLOBIFBCFMC/* = false*/)
	{
		OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		BBHNACPENDM_ServerSaveData serverSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		List<CNLPPCFJEID_QuestInfo> dbQuestsList = db.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests;
		List<NFPHOINMHKN_QuestInfo> saveQuestsList = serverSave.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests;
		List<FKMOKDCJFEN> res = new List<FKMOKDCJFEN>();
		for(int i = 0; i < saveQuestsList.Count; i++)
		{
			CNLPPCFJEID_QuestInfo MABBBOEAPAA_p = dbQuestsList[i];
			if (MABBBOEAPAA_p.INDDJNMPONH_type != 0)
			{
				if((MABBBOEAPAA_p.KJBGCLPMLCG_OpenedAt == 0 && MABBBOEAPAA_p.GJFPFFBAKGK_CloseAt == 0) ||
					(time >= MABBBOEAPAA_p.KJBGCLPMLCG_OpenedAt && MABBBOEAPAA_p.GJFPFFBAKGK_CloseAt >= time))
				{
					//LAB_0118b20c
					bool zz = false;
					if (!PLOBIFBCFMC)
					{
						if (EMJFHKHLHDB == 2)
						{
							if (ILLPDLODANB.HHMKDAIGMKC_IsDebutMission((ILLPDLODANB.LOEGALDKHPL)MABBBOEAPAA_p.INDDJNMPONH_type))
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
								b = ILLPDLODANB.FJFPHHEFMIB_IsSnsMission(MABBBOEAPAA_p);
							}
							else
							{
								if (EMJFHKHLHDB != 0)
								{
									//LAB_0118b218
									zz = true;
								}
								if (ILLPDLODANB.FJFPHHEFMIB_IsSnsMission(MABBBOEAPAA_p))
								{
									continue;
								}
								b = !ILLPDLODANB.HHMKDAIGMKC_IsDebutMission((ILLPDLODANB.LOEGALDKHPL)MABBBOEAPAA_p.INDDJNMPONH_type);
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
						if (ILLPDLODANB.HHMKDAIGMKC_IsDebutMission((ILLPDLODANB.LOEGALDKHPL)MABBBOEAPAA_p.INDDJNMPONH_type))
						{
							if(saveQuestsList[i].EALOBDHOCHP_stat > 2)
							{
								continue;
							}
						}
						int idx = res.FindIndex((FKMOKDCJFEN JPAEDJJFFOI) =>
						{
							//0x118EC60
							return JPAEDJJFFOI.HAMGPOIFBCD_Type == MABBBOEAPAA_p.DEPGBBJMFED_CategoryId;
						});
						if(idx != -1)
						{
							if(res[idx].CMCKNKKCNDK_status > 0 && res[idx].CMCKNKKCNDK_status <= ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved)
							{
								continue;
							}
						}
						if(!_FBBNPFFEJBN_Force)
						{
							if(MABBBOEAPAA_p.HHIBBHFHENH_LinkQuestId != 0)
							{
								if(saveQuestsList[i].EALOBDHOCHP_stat < 2)
								{
									int a = ILLPDLODANB.OBOJKHIJBGL_GetNormalQuestStatus(saveQuestsList[i].EALOBDHOCHP_stat, db, serverSave, false);
									CNLPPCFJEID_QuestInfo q2 = dbQuestsList[MABBBOEAPAA_p.HHIBBHFHENH_LinkQuestId - 1];
									bool d = ILLPDLODANB.HHMKDAIGMKC_IsDebutMission((ILLPDLODANB.LOEGALDKHPL)q2.INDDJNMPONH_type);
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
						if(ILLPDLODANB.OBOJKHIJBGL_GetNormalQuestStatus(MABBBOEAPAA_p.PPFNGGCBJKC_id, db, serverSave, false) != 0)
						{
							FKMOKDCJFEN data = new FKMOKDCJFEN();
							data.PHGLNKFFEME_InitNormalQuest(MABBBOEAPAA_p.PPFNGGCBJKC_id);
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
		res.Sort((FKMOKDCJFEN _HKICMNAACDA_a, FKMOKDCJFEN _BNKHBCBJBKI_b) =>
		{
			//0x118EBA0
			int r = NKIICMCKKMD[(int)_HKICMNAACDA_a.CMCKNKKCNDK_status] - NKIICMCKKMD[(int)_BNKHBCBJBKI_b.CMCKNKKCNDK_status];
			if (r == 0)
			{
				r = _HKICMNAACDA_a.EEFLOOBOAGF_ViewOrder - _BNKHBCBJBKI_b.EEFLOOBOAGF_ViewOrder;
			}
			return r;
		});
		return res;
	}

	//// RVA: 0x118B9F0 Offset: 0x118B9F0 VA: 0x118B9F0
	public static List<FKMOKDCJFEN> KJHKBBBDBAL(string _JOPOPMLFINI_QuestName, bool GEDMCDAPPNH/* = false*/, int PLLOPLOEGDC/* = -1*/)
	{
		List<FKMOKDCJFEN> res = new List<FKMOKDCJFEN>();
		IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LKJGDCBCLKO(_JOPOPMLFINI_QuestName);
		if(ev != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int c = ev.AGLILDLEFDK_Missions.Count;
			if (ev.OLDFFDMPEBM_Quests.Count < c)
				c = ev.OLDFFDMPEBM_Quests.Count;
			int group = PLLOPLOEGDC;
			if (PLLOPLOEGDC < 0)
			{
				group = 0;
				if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
				{
					group = (ev as KNKDBNFMAKF_EventSp).MEDEJHKNAFG_GetCurrentMissionGroup(time);
				}
			}
			for(int i = 0; i < c; i++)
			{
				int d = ev.GBADILEHLGC_GetStatus(i + 1);
				if (d != 0)
				{
					if(ev.AGLILDLEFDK_Missions[i].KGICDMIJGDF_Group == group)
					{
						int link = ev.AGLILDLEFDK_Missions[i].HHIBBHFHENH_LinkQuestId;
						if (link == ev.AGLILDLEFDK_Missions[i].PPFNGGCBJKC_id)
						{
							Debug.LogError(JpStringLiterals.StringLiteral_10346);
						}
						else
						{
							bool b = false;
							while(link != 0)
							{
								if(ev.GBADILEHLGC_GetStatus(link) < 2)
								{
									b = true;
									break;
								}
								link = ev.AGLILDLEFDK_Missions[link - 1].HHIBBHFHENH_LinkQuestId;
							}
							if (b)
								continue;
							FKMOKDCJFEN data = new FKMOKDCJFEN();
							data.KAFDDLPNOCF(i + 1, time, ev, GEDMCDAPPNH);
							if(d >= 2 || (time >= data.KJBGCLPMLCG_OpenedAt && data.GJFPFFBAKGK_CloseAt >= time) || (data.KJBGCLPMLCG_OpenedAt == 0 && data.GJFPFFBAKGK_CloseAt == 0))
							{
								res.Add(data);
							}
						}
					}
				}
			}
		}
		return res;
	}

	//// RVA: 0x118BF50 Offset: 0x118BF50 VA: 0x118BF50
	//public static int HDCCHOGIBKG() { }

	//// RVA: 0x118C068 Offset: 0x118C068 VA: 0x118C068
	public static int BDMMKMALOEN(MEDJADCKPKH _JONPKLHMOBL_Category, List<int> MBFCHNDGNDP, string _JOPOPMLFINI_QuestName)
	{
		if(MBFCHNDGNDP != null && MBFCHNDGNDP.Count != 0)
		{
			if(_JONPKLHMOBL_Category == MEDJADCKPKH.CCDOBDNDPIL_2_Event)
			{
				if(!string.IsNullOrEmpty(_JOPOPMLFINI_QuestName))
				{
					IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LKJGDCBCLKO(_JOPOPMLFINI_QuestName);
					if(ev != null)
					{
						for(int i = 0; i < MBFCHNDGNDP.Count; i++)
						{
							if(ev.GBADILEHLGC_GetStatus(MBFCHNDGNDP[i]) != 2)
								return 0;
						}
						return 1;
					}
				}
				return 0;
			}
			else if(_JONPKLHMOBL_Category == MEDJADCKPKH.CCAPCGPIIPF_Normal)
			{
				for(int i = 0; i < MBFCHNDGNDP.Count; i++)
				{
					if (ILLPDLODANB.OBOJKHIJBGL_GetNormalQuestStatus(MBFCHNDGNDP[i], IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, false) != 2)
					{
						return 0;
					}
				}
			}
			else if(_JONPKLHMOBL_Category == MEDJADCKPKH.HEFPAOLDHCK_Daily)
			{
				for (int i = 0; i < MBFCHNDGNDP.Count; i++)
				{
					if (ILLPDLODANB.KPEDEPGGMEC_GetDailyQuestStatus(MBFCHNDGNDP[i], IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData) != 2)
					{
						return 0;
					}
				}
			}
			return 1;
		}
		return 0;
	}

	//// RVA: 0x118C548 Offset: 0x118C548 VA: 0x118C548
	public static void JKBOOMAPOBL(MEDJADCKPKH _JONPKLHMOBL_Category, List<int> MBFCHNDGNDP, string _JOPOPMLFINI_QuestName, Action<List<int>, bool> _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, bool KPBMFAALBKC/* = false*/)
	{
		int a = BDMMKMALOEN(_JONPKLHMOBL_Category, MBFCHNDGNDP, _JOPOPMLFINI_QuestName);
		if (a < 0)
			return;
		if(a == 0)
		{
			//LAB_0118d080
			NIMPEHIECJH();
		}
		else
		{
			BBHNACPENDM_ServerSaveData newData = new BBHNACPENDM_ServerSaveData();
			newData.KHEKNNFCAOI_Init(0x1fdcffdffffff7);
			newData.ODDIHGPONFL_Copy(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
			int quest_lump_receive_max_num = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("quest_lump_receive_max_num", 30);
			bool GHEHKJFGOIE = false;
			List<int> LFDJPGLMHFI = new List<int>();
			int cnt = 0;
			ulong checkTarget = 0;
			if(_JONPKLHMOBL_Category == MEDJADCKPKH.HEFPAOLDHCK_Daily)
			{
				checkTarget = 4;
				for (int i = 0; i < MBFCHNDGNDP.Count; i++)
				{
					LCKMNLOLDPD data = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.LFAAEPAAEMB[IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[MBFCHNDGNDP[i] - 1].EIHOBHDKCDB_RewardId - 1];
					if (!CEHIEFPLPFM(newData, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, data.GLCLFMGPMAN_ItemId, data.HMFFHLPNMPH_count) || KPBMFAALBKC)
					{
						LFDJPGLMHFI.Add(MBFCHNDGNDP[i]);
						PKCIICBKEMG(newData, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, data.GLCLFMGPMAN_ItemId, data.HMFFHLPNMPH_count);
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[MBFCHNDGNDP[i] - 1].JIOMCDGKIAF = 1;
						cnt++;
						if(quest_lump_receive_max_num <= cnt)
						{
							GHEHKJFGOIE = false;
							break;
						}
					}
					else
						GHEHKJFGOIE = true;
				}
			}
			else
			{
				if(_JONPKLHMOBL_Category == MEDJADCKPKH.CCDOBDNDPIL_2_Event)
				{
					if(!string.IsNullOrEmpty(_JOPOPMLFINI_QuestName))
					{
						IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LKJGDCBCLKO(_JOPOPMLFINI_QuestName);
						if(ev != null)
						{
							cnt = 0;
							for(int i = 0; i < MBFCHNDGNDP.Count; i++)
							{
								if(!CEHIEFPLPFM(newData, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, ev.AGLILDLEFDK_Missions[MBFCHNDGNDP[i] - 1].KIJAPOFAGPN_ItemId, ev.AGLILDLEFDK_Missions[MBFCHNDGNDP[i] - 1].JDLJPNMLFID_ItemCount) || KPBMFAALBKC)
								{
									LFDJPGLMHFI.Add(MBFCHNDGNDP[i]);
									cnt++;
									if(quest_lump_receive_max_num <= cnt)
									{
										GHEHKJFGOIE = false;
										break;
									}
								}
								else
								{
									GHEHKJFGOIE = true;
								}
							}
							ev.FHGEJBKNBLP(LFDJPGLMHFI);
							if(_JOPOPMLFINI_QuestName == "event_quest_c")
							{
								checkTarget = 0x200;
							}
							else if(_JOPOPMLFINI_QuestName == "event_quest_b")
							{
								checkTarget = 0x100;
							}
							else if(_JOPOPMLFINI_QuestName == "event_quest_a")
							{
								checkTarget = 0x80;
							}
							else if(_JOPOPMLFINI_QuestName == "event_april_fool_h")
							{
								checkTarget = 0x20000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_april_fool_i")
							{
								checkTarget = 0x40000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_april_fool_f")
							{
								checkTarget = 0x8000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_april_fool_g")
							{
								checkTarget = 0x10000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_april_fool_d")
							{
								checkTarget = 0x2000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_april_fool_e")
							{
								checkTarget = 0x4000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_april_fool_b")
							{
								checkTarget = 0x800000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_april_fool_c")
							{
								checkTarget = 0x1000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_april_fool_a")
							{
								checkTarget = 0x400000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_sp_a")
							{
								checkTarget = 0x10000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_mission_c")
							{
								checkTarget = 0x8000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_mission_b")
							{
								checkTarget = 0x4000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_mission_a")
							{
								checkTarget = 0x2000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_raid_d")
							{
								checkTarget = 0x400000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_collection_a")
							{
								checkTarget = 0x10;
							}
							else if(_JOPOPMLFINI_QuestName == "event_raid_a")
							{
								checkTarget = 0x80000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_collection_c")
							{
								checkTarget = 0x40;
							}
							else if(_JOPOPMLFINI_QuestName == "event_collection_b")
							{
								checkTarget = 0x20;
							}
							else if(_JOPOPMLFINI_QuestName == "event_raid_c")
							{
								checkTarget = 0x200000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_raid_b")
							{
								checkTarget = 0x100000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_battle_c")
							{
								checkTarget = 0x1000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_battle_b")
							{
								checkTarget = 0x800;
							}
							else if(_JOPOPMLFINI_QuestName == "event_battle_a")
							{
								checkTarget = 0x400;
							}
							else if(_JOPOPMLFINI_QuestName == "event_godiva_a")
							{
								checkTarget = 0x4000000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_godiva_c")
							{
								checkTarget = 0x10000000000;
							}
							else if(_JOPOPMLFINI_QuestName == "event_godiva_b")
							{
								checkTarget = 0x8000000000;
							}

						}
					}
					else
					{
						NIMPEHIECJH();
					}
				}
				else if (_JONPKLHMOBL_Category == MEDJADCKPKH.CCAPCGPIIPF_Normal)
				{ 
					cnt = 0;
					checkTarget = 8;
					for (int i = 0; i < MBFCHNDGNDP.Count; i++)
					{
						LCKMNLOLDPD data = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.LFAAEPAAEMB[IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[MBFCHNDGNDP[i] - 1].EIHOBHDKCDB_RewardId - 1];
						if (!CEHIEFPLPFM(newData, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, data.GLCLFMGPMAN_ItemId, data.HMFFHLPNMPH_count) || KPBMFAALBKC)
						{
							LFDJPGLMHFI.Add(MBFCHNDGNDP[i]);
							PKCIICBKEMG(newData, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, data.GLCLFMGPMAN_ItemId, data.HMFFHLPNMPH_count);
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[MBFCHNDGNDP[i] - 1].JIOMCDGKIAF = 1;
							cnt++;
							if (quest_lump_receive_max_num <= cnt)
							{
								GHEHKJFGOIE = false;
								break;
							}
						}
						else
							GHEHKJFGOIE = true;
					}
				}
			}
			//LAB_0118d0b0
			JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
			if (_JONPKLHMOBL_Category == MEDJADCKPKH.HEFPAOLDHCK_Daily)
			{
				for (int i = 0; i < LFDJPGLMHFI.Count; i++)
				{
					ILCCJNDFFOB.HHCJCDFCLOB.GCCAFBHKAEG(LFDJPGLMHFI[i]);
				}
			}
			else if (_JONPKLHMOBL_Category == MEDJADCKPKH.CCDOBDNDPIL_2_Event)
			{
				IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LKJGDCBCLKO(_JOPOPMLFINI_QuestName);
				for(int i = 0; i < LFDJPGLMHFI.Count; i++)
				{
					ILCCJNDFFOB.HHCJCDFCLOB.APAJMNOBNLL(ev, LFDJPGLMHFI[i]);
				}
			}
			else if (_JONPKLHMOBL_Category == MEDJADCKPKH.CCAPCGPIIPF_Normal)
			{
				for(int i = 0; i < LFDJPGLMHFI.Count; i++)
				{
					ILCCJNDFFOB.HHCJCDFCLOB.MOCDNABNBAO(LFDJPGLMHFI[i]);
				}
			}
			MenuScene.SaveWithAchievement(checkTarget, () =>
			{
				//0x118ECB8
				_BHFHGFKBOHH_OnSuccess(LFDJPGLMHFI, GHEHKJFGOIE);
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
			}, null);
		}
	}

	//// RVA: 0x118DFAC Offset: 0x118DFAC VA: 0x118DFAC
	private static void PKCIICBKEMG(BBHNACPENDM_ServerSaveData LNEAHKALBHN, OKGLGHCBCJP_Database JLBMBKHBKBG, int MBBJMJAAODG, int ENHEJFPMPJH)
	{
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(MBBJMJAAODG);
		if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
		{
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(MBBJMJAAODG);
			int cnt = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(JLBMBKHBKBG, LNEAHKALBHN, cat, id, null);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem)
			{
				HHPEMHHCKBE_Compo.MLMDKHBFOJM dbCompo = JLBMBKHBKBG.ALFKMKICDPP_Compo.CDENCMNHNGA_table[id - 1];
				for(int i = 0; i < dbCompo.JCJGGHGIKIJ(); i++)
				{
					EKLNMHFCAOI.FKGCBLHOOCL_Category cat2 = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(dbCompo.CBLLFCGEJAI(i));
					int id2 = EKLNMHFCAOI.DEACAHNLMNI_getItemId(dbCompo.CBLLFCGEJAI(i));
					EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(JLBMBKHBKBG, LNEAHKALBHN, cat2, id2, dbCompo.HBJMCLGKLBA(i) * ENHEJFPMPJH + EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(JLBMBKHBKBG, LNEAHKALBHN, cat2, id2, null), null);
				}
			}
			else
			{
				EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(JLBMBKHBKBG, LNEAHKALBHN, cat, id, cnt + ENHEJFPMPJH, null);
			}
		}
	}

	//// RVA: 0x118DD9C Offset: 0x118DD9C VA: 0x118DD9C
	private static bool CEHIEFPLPFM(BBHNACPENDM_ServerSaveData LNEAHKALBHN, OKGLGHCBCJP_Database JLBMBKHBKBG, int MBBJMJAAODG, int ENHEJFPMPJH)
	{
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(MBBJMJAAODG);
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(MBBJMJAAODG);
		int cnt = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(JLBMBKHBKBG, LNEAHKALBHN, cat, id, null);
		if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC && cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
		{
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem)
			{
				HHPEMHHCKBE_Compo.MLMDKHBFOJM dbCompo = JLBMBKHBKBG.ALFKMKICDPP_Compo.CDENCMNHNGA_table[id - 1];
				for(int i = 0; i < dbCompo.JCJGGHGIKIJ(); i++)
				{
					if (CEHIEFPLPFM(LNEAHKALBHN, JLBMBKHBKBG, dbCompo.CBLLFCGEJAI(i), ENHEJFPMPJH))
						return true;
				}
				return false;
			}
			else
			{
				if (EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(JLBMBKHBKBG, LNEAHKALBHN, cat, id, null) < cnt + ENHEJFPMPJH)
					return true;
			}
		}
		return false;
	}

	//// RVA: 0x118E2AC Offset: 0x118E2AC VA: 0x118E2AC
	public void KKFFEJEKFEG(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH)
	{
		CNLPPCFJEID_QuestInfo q = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests.Find((CNLPPCFJEID_QuestInfo _GHPLINIACBB_x) =>
		{
			//0x118ED80
			return CMEJFJFOIIJ_QuestId == _GHPLINIACBB_x.PPFNGGCBJKC_id;
		});
		if(q != null && q.INDDJNMPONH_type == 25)
		{
			string key = "normal_quest_url_" + q.CHOFDPDFPDC_ConfigValue.ToString("00");
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE.ContainsKey(key))
			{
				string url = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE[key];
				NFPHOINMHKN_QuestInfo n = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[q.PPFNGGCBJKC_id - 1];
				if(n.EALOBDHOCHP_stat < 2)
				{
					n.EALOBDHOCHP_stat = 2;
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0x118EDDC
						NKGJPJPHLIF.HHCJCDFCLOB.NBLAOIPJFGL_OpenURL(url);
						_BHFHGFKBOHH_OnSuccess();
					}, () =>
					{
						//0x118E968
						MenuScene.Instance.GotoTitle();
					}, null);
					return;
				}
			}
		}
		NIMPEHIECJH();
	}
}
