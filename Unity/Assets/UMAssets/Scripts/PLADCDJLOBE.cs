
using System.Collections.Generic;
using XeSys;

public class PLADCDJLOBE
{
	public enum PNLNGHNHCNI
	{
		NHANNKGPAHM = 0,
		KJHABBHBFPD_1_Other = 1,
		PAAIHBHJJMM = 2,
		MOFPBMFPFHF = 3,
		IEGNGNLGLGN = 4,
		CCDOBDNDPIL_5_Event = 5,
	}

	public enum ENNOBKHBNCG
	{
		HJNNKCMLGFL_0_None = 0,
		ODBLGDGLEIO = 1,
		OLLIGIKNCMM = 2,
		OMNJOCHOGDG_3 = 3,
		PAMGIIDEEMC = 4,
		NHANNKGPAHM = 5,
		DIDJLIPNCKO_6_Bingo = 6,
	}

	public enum OCMHGKIFNHP
	{
		HJNNKCMLGFL_0_None = 0,
		JFEDIMKFDNH_1_Prologue = 1,
		OEDCONLFLHD_2_Epilogue = 2,
	}

	public PNLNGHNHCNI MMMGMNAMGDF; // 0x8
	public string KLMPFGOCBHC_description; // 0xC
	public int PAAGIJHEIHK; // 0x10
	public int DEKECNIBBIB_ItemFullId; // 0x14
	public bool JDBLMAHMHJO_IsAchieved; // 0x18
	public ENNOBKHBNCG BGOCBNPGNKM; // 0x1C
	public int EKANGPODCEP_EventId; // 0x20
	public OCMHGKIFNHP CICPBBKEBNJ; // 0x24
	public int LMPPENOILPF; // 0x28
	
	//// RVA: 0xFE7B80 Offset: 0xFE7B80 VA: 0xFE7B80
	public static PLADCDJLOBE HEGEKFMJNCC()
	{
		FKMOKDCJFEN f = FKMOKDCJFEN.KFHCJLFAHAG();
		if (f == null)
		{
			IKDICBBFBMI_EventBase ev = MCOABJIJFFN();
			if (ev == null)
			{
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				PLADCDJLOBE p = null;
				for (int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
				{
					IKDICBBFBMI_EventBase ev2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
					if(ev2 != null)
					{
						ev2.HCDGELDHFHB_UpdateStatus(time);
						if(ev2.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting/*6*/ && ev2.AGLILDLEFDK_Missions != null)
						{
							long time2 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							int group = 0;
							if(ev2.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
							{
								group = (ev2 as KNKDBNFMAKF_EventSp).MEDEJHKNAFG_GetCurrentMissionGroup(time2);
							}
							for(int j = 0; j < ev2.AGLILDLEFDK_Missions.Count; j++)
							{
								if(ev2.GBADILEHLGC_GetStatus(j + 1) == 1)
								{
									if(ev2.AGLILDLEFDK_Missions[j].KGICDMIJGDF_Group == group)
									{
										if(ev2.AGLILDLEFDK_Missions[j].LMPPENOILPF != 0)
										{
											FKMOKDCJFEN data = new FKMOKDCJFEN();
											data.KAFDDLPNOCF(j + 1, time, ev2, false);
											if(data.OFKCGMNFGKB_IsTimeValid(time2))
											{
												PLADCDJLOBE data2 = new PLADCDJLOBE();
												data2.IFAOJAKAPHH(data);
												if(p == null || p.LMPPENOILPF > data2.LMPPENOILPF)
												{
													p = data2;
												}
											}
										}
									}
								}
							}
						}
					}
				}
				List<FKMOKDCJFEN> l = FKMOKDCJFEN.CMLEFPDNBCB(false, 0, true);
				if (l != null && l.Count > 0)
				{
					int idx = -1;
					for (int i = 0; i < l.Count; i++)
					{
						if (l[i].LMPPENOILPF != 0)
						{
							if (l[i].CMCKNKKCNDK_status == FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ_1/*1*/)
							{
								if (idx != -1)
								{
									if (l[i].LMPPENOILPF < l[idx].LMPPENOILPF)
										idx = i;
								}
								else
								{
									idx = i;
								}
							}
						}
					}
					if (idx > -1)
					{
						PLADCDJLOBE data = new PLADCDJLOBE();
						data.AODPJKPIHME(l[idx]);
						if (p != null)
						{
							if (p.LMPPENOILPF <= data.LMPPENOILPF)
								return p;
						}
						return data;
					}
				}
				return p;
			}
			else
			{
				PLADCDJLOBE data = new PLADCDJLOBE();
				data.OMAOEIOLKPH(ev);
				return data;
			}
		}
		else
		{
			PLADCDJLOBE data = new PLADCDJLOBE();
			data.LJIFDOFIHEA(f);
			return data;
		}
	}

	//// RVA: 0xFE83E4 Offset: 0xFE83E4 VA: 0xFE83E4
	public void LJIFDOFIHEA(FKMOKDCJFEN _GOACJBOCLHH_Quest)
	{
		MMMGMNAMGDF = PNLNGHNHCNI.NHANNKGPAHM/*0*/;
		KLMPFGOCBHC_description = _GOACJBOCLHH_Quest.ADFLDIBPJLP_GetDescription();
		DEKECNIBBIB_ItemFullId = _GOACJBOCLHH_Quest.GOOIIPFHOIG.JJBGOIMEIPF_ItemId;
		LMPPENOILPF = 10;
		BGOCBNPGNKM = ENNOBKHBNCG.NHANNKGPAHM/*5*/;
		JDBLMAHMHJO_IsAchieved = _GOACJBOCLHH_Quest.CMCKNKKCNDK_status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_2_Achieved;
	}

	//// RVA: 0xFE8EB8 Offset: 0xFE8EB8 VA: 0xFE8EB8
	//public void HJBGNOEIJOL(LIEJFHMGNIA OIFJPOMLKAH) { }

	//// RVA: 0xFE9020 Offset: 0xFE9020 VA: 0xFE9020
	//public void HDCOEJNNMKN() { }

	//// RVA: 0xFE8CD8 Offset: 0xFE8CD8 VA: 0xFE8CD8
	public void AODPJKPIHME(FKMOKDCJFEN _GOACJBOCLHH_Quest)
	{
		MMMGMNAMGDF = PNLNGHNHCNI.KJHABBHBFPD_1_Other/*1*/;
		KLMPFGOCBHC_description = _GOACJBOCLHH_Quest.ADFLDIBPJLP_GetDescription();
		DEKECNIBBIB_ItemFullId = _GOACJBOCLHH_Quest.GOOIIPFHOIG.JJBGOIMEIPF_ItemId;
		JDBLMAHMHJO_IsAchieved = _GOACJBOCLHH_Quest.CMCKNKKCNDK_status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_2_Achieved;
		LMPPENOILPF = _GOACJBOCLHH_Quest.LMPPENOILPF;
		BGOCBNPGNKM = ILLPDLODANB.FJFPHHEFMIB_IsSnsMission(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[_GOACJBOCLHH_Quest.CMEJFJFOIIJ_QuestId - 1]) ? ENNOBKHBNCG.OMNJOCHOGDG_3/*3*/ : ENNOBKHBNCG.OLLIGIKNCMM/*2*/;
	}

	//// RVA: 0xFE8C40 Offset: 0xFE8C40 VA: 0xFE8C40
	public void IFAOJAKAPHH(FKMOKDCJFEN _GOACJBOCLHH_Quest)
	{
		MMMGMNAMGDF = PNLNGHNHCNI.KJHABBHBFPD_1_Other/*1*/;
		KLMPFGOCBHC_description = _GOACJBOCLHH_Quest.ADFLDIBPJLP_GetDescription();
		DEKECNIBBIB_ItemFullId = _GOACJBOCLHH_Quest.GOOIIPFHOIG.JJBGOIMEIPF_ItemId;
		JDBLMAHMHJO_IsAchieved = _GOACJBOCLHH_Quest.CMCKNKKCNDK_status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_2_Achieved;
		BGOCBNPGNKM = ENNOBKHBNCG.PAMGIIDEEMC/*4*/;
		LMPPENOILPF = _GOACJBOCLHH_Quest.LMPPENOILPF;
	}

	//// RVA: 0xFE88F4 Offset: 0xFE88F4 VA: 0xFE88F4
	private void OMAOEIOLKPH(IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		if(time >= LIKDEHHKFEH.LOLAANGCGDO_RankingEnd2)
		{
			DEKECNIBBIB_ItemFullId = 0;
			MMMGMNAMGDF = PNLNGHNHCNI.CCDOBDNDPIL_5_Event;
			KLMPFGOCBHC_description = "";
			LMPPENOILPF = 10;
			EKANGPODCEP_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			if(time >= LIKDEHHKFEH.JDDFILGNGFH_RewardStart)
			{
				DEKECNIBBIB_ItemFullId = LIKDEHHKFEH.BAEPGOAMBDK("event_epilogue_achv_item_id", 0);
				if(DEKECNIBBIB_ItemFullId > 0)
				{
					KLMPFGOCBHC_description = string.Format(MessageManager.Instance.GetMessage("menu", "balloon_event_epilogue_loginbonus"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(DEKECNIBBIB_ItemFullId));
					CICPBBKEBNJ = OCMHGKIFNHP.OEDCONLFLHD_2_Epilogue;
				}
			}
		}
		else
		{
			DEKECNIBBIB_ItemFullId = LIKDEHHKFEH.BAEPGOAMBDK("event_prologue_achv_item_id", 0);
			MMMGMNAMGDF = PNLNGHNHCNI.CCDOBDNDPIL_5_Event;
			KLMPFGOCBHC_description = "";
			LMPPENOILPF = 10;
			EKANGPODCEP_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			if(DEKECNIBBIB_ItemFullId > 0)
			{
				KLMPFGOCBHC_description = string.Format(MessageManager.Instance.GetMessage("menu", "balloon_event_prologue_loginbonus"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(DEKECNIBBIB_ItemFullId));
				CICPBBKEBNJ = OCMHGKIFNHP.JFEDIMKFDNH_1_Prologue;
			}
		}
	}

	//// RVA: 0xFE847C Offset: 0xFE847C VA: 0xFE847C
	private static IKDICBBFBMI_EventBase MCOABJIJFFN()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		IKDICBBFBMI_EventBase res = null;
		long t1 = 0;
		for (int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
		{
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
			if(ev.HIDHLFCBIDE_EventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp && ((1 << (int)ev.HIDHLFCBIDE_EventType) & 0x4aU) != 0) // 100 1010 AOPKACCDKPA_EventCollection / PFKOKHODEGL_EventBattle / NKDOEBONGNI_EventMission
			{
				if(time >= ev.GLIMIGNNGGB_RankingStart)
				{
					if(time < ev.LJOHLEGGGMC_RewardEnd)
					{
						int advId;
						int itemId;
						if(time >= ev.DPJCPDKALGI_RankingEnd)
						{
							if(time < ev.JDDFILGNGFH_RewardStart)
							{
								continue;
							}
							advId = ev.CAKEOPLJDAF_EndAdventureId;
							itemId = ev.BAEPGOAMBDK("event_epilogue_achv_item_id", 0);
						}
						else
						{
							advId = ev.GFIBLLLHMPD_StartAdventureId;
							itemId = ev.BAEPGOAMBDK("event_prologue_achv_item_id", 0);
						}
						if(advId > -1 && itemId != 0)
						{
							if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(advId))
							{
								if(t1 == 0 || ev.LJOHLEGGGMC_RewardEnd < t1)
								{
									t1 = ev.LJOHLEGGGMC_RewardEnd;
									res = ev;
								}
							}
						}
					}
				}
			}
		}
		return res;
	}
}
