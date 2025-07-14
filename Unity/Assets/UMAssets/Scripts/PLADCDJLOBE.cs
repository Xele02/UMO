
using System.Collections.Generic;
using XeSys;

public class PLADCDJLOBE
{
	public enum PNLNGHNHCNI
	{
		NHANNKGPAHM = 0,
		KJHABBHBFPD = 1,
		PAAIHBHJJMM = 2,
		MOFPBMFPFHF = 3,
		IEGNGNLGLGN = 4,
		CCDOBDNDPIL_5 = 5,
	}

	public enum ENNOBKHBNCG
	{
		HJNNKCMLGFL = 0,
		ODBLGDGLEIO = 1,
		OLLIGIKNCMM = 2,
		OMNJOCHOGDG_3 = 3,
		PAMGIIDEEMC = 4,
		NHANNKGPAHM = 5,
		DIDJLIPNCKO_6 = 6,
	}

	public enum OCMHGKIFNHP
	{
		HJNNKCMLGFL = 0,
		JFEDIMKFDNH_1 = 1,
		OEDCONLFLHD_2 = 2,
	}

	public PNLNGHNHCNI MMMGMNAMGDF; // 0x8
	public string KLMPFGOCBHC_Desc; // 0xC
	public int PAAGIJHEIHK; // 0x10
	public int DEKECNIBBIB_ItemFullId; // 0x14
	public bool JDBLMAHMHJO_IsAchieved; // 0x18
	public ENNOBKHBNCG BGOCBNPGNKM; // 0x1C
	public int EKANGPODCEP; // 0x20
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
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				PLADCDJLOBE p = null;
				for (int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
				{
					IKDICBBFBMI_EventBase ev2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
					if(ev2 != null)
					{
						ev2.HCDGELDHFHB_UpdateStatus(time);
						if(ev2.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6/*6*/ && ev2.AGLILDLEFDK_Missions != null)
						{
							long time2 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
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
											if(data.OFKCGMNFGKB(time2))
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
							if (l[i].CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ_1/*1*/)
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
		return null;
	}

	//// RVA: 0xFE83E4 Offset: 0xFE83E4 VA: 0xFE83E4
	public void LJIFDOFIHEA(FKMOKDCJFEN GOACJBOCLHH)
	{
		MMMGMNAMGDF = PNLNGHNHCNI.NHANNKGPAHM/*0*/;
		KLMPFGOCBHC_Desc = GOACJBOCLHH.ADFLDIBPJLP_GetDescription();
		DEKECNIBBIB_ItemFullId = GOACJBOCLHH.GOOIIPFHOIG.JJBGOIMEIPF_ItemId;
		LMPPENOILPF = 10;
		BGOCBNPGNKM = ENNOBKHBNCG.NHANNKGPAHM/*5*/;
		JDBLMAHMHJO_IsAchieved = GOACJBOCLHH.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved;
	}

	//// RVA: 0xFE8EB8 Offset: 0xFE8EB8 VA: 0xFE8EB8
	//public void HJBGNOEIJOL(LIEJFHMGNIA OIFJPOMLKAH) { }

	//// RVA: 0xFE9020 Offset: 0xFE9020 VA: 0xFE9020
	//public void HDCOEJNNMKN() { }

	//// RVA: 0xFE8CD8 Offset: 0xFE8CD8 VA: 0xFE8CD8
	public void AODPJKPIHME(FKMOKDCJFEN GOACJBOCLHH)
	{
		MMMGMNAMGDF = PNLNGHNHCNI.KJHABBHBFPD/*1*/;
		KLMPFGOCBHC_Desc = GOACJBOCLHH.ADFLDIBPJLP_GetDescription();
		DEKECNIBBIB_ItemFullId = GOACJBOCLHH.GOOIIPFHOIG.JJBGOIMEIPF_ItemId;
		JDBLMAHMHJO_IsAchieved = GOACJBOCLHH.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved;
		LMPPENOILPF = GOACJBOCLHH.LMPPENOILPF;
		BGOCBNPGNKM = ILLPDLODANB.FJFPHHEFMIB_IsSnsMission(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[GOACJBOCLHH.CMEJFJFOIIJ_QuestId - 1]) ? ENNOBKHBNCG.OMNJOCHOGDG_3/*3*/ : ENNOBKHBNCG.OLLIGIKNCMM/*2*/;
	}

	//// RVA: 0xFE8C40 Offset: 0xFE8C40 VA: 0xFE8C40
	public void IFAOJAKAPHH(FKMOKDCJFEN GOACJBOCLHH)
	{
		MMMGMNAMGDF = PNLNGHNHCNI.KJHABBHBFPD/*1*/;
		KLMPFGOCBHC_Desc = GOACJBOCLHH.ADFLDIBPJLP_GetDescription();
		DEKECNIBBIB_ItemFullId = GOACJBOCLHH.GOOIIPFHOIG.JJBGOIMEIPF_ItemId;
		JDBLMAHMHJO_IsAchieved = GOACJBOCLHH.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved;
		BGOCBNPGNKM = ENNOBKHBNCG.PAMGIIDEEMC/*4*/;
		LMPPENOILPF = GOACJBOCLHH.LMPPENOILPF;
	}

	//// RVA: 0xFE88F4 Offset: 0xFE88F4 VA: 0xFE88F4
	private void OMAOEIOLKPH(IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		if(time >= LIKDEHHKFEH.LOLAANGCGDO)
		{
			DEKECNIBBIB_ItemFullId = 0;
			MMMGMNAMGDF = PNLNGHNHCNI.CCDOBDNDPIL_5;
			KLMPFGOCBHC_Desc = "";
			LMPPENOILPF = 10;
			EKANGPODCEP = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			if(time >= LIKDEHHKFEH.JDDFILGNGFH)
			{
				DEKECNIBBIB_ItemFullId = LIKDEHHKFEH.BAEPGOAMBDK("event_epilogue_achv_item_id", 0);
				if(DEKECNIBBIB_ItemFullId > 0)
				{
					KLMPFGOCBHC_Desc = string.Format(MessageManager.Instance.GetMessage("menu", "balloon_event_epilogue_loginbonus"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(DEKECNIBBIB_ItemFullId));
					CICPBBKEBNJ = OCMHGKIFNHP.OEDCONLFLHD_2;
				}
			}
		}
		else
		{
			DEKECNIBBIB_ItemFullId = LIKDEHHKFEH.BAEPGOAMBDK("event_prologue_achv_item_id", 0);
			MMMGMNAMGDF = PNLNGHNHCNI.CCDOBDNDPIL_5;
			KLMPFGOCBHC_Desc = "";
			LMPPENOILPF = 10;
			EKANGPODCEP = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
			if(DEKECNIBBIB_ItemFullId > 0)
			{
				KLMPFGOCBHC_Desc = string.Format(MessageManager.Instance.GetMessage("menu", "balloon_event_prologue_loginbonus"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(DEKECNIBBIB_ItemFullId));
				CICPBBKEBNJ = OCMHGKIFNHP.JFEDIMKFDNH_1;
			}
		}
	}

	//// RVA: 0xFE847C Offset: 0xFE847C VA: 0xFE847C
	private static IKDICBBFBMI_EventBase MCOABJIJFFN()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		IKDICBBFBMI_EventBase res = null;
		long t1 = 0;
		for (int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
		{
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i];
			if(ev.HIDHLFCBIDE_EventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp && ((1 << (int)ev.HIDHLFCBIDE_EventType) & 0x4aU) != 0) // 100 1010 AOPKACCDKPA_EventCollection / PFKOKHODEGL_EventBattle / NKDOEBONGNI_EventQuest
			{
				if(time >= ev.GLIMIGNNGGB_Start)
				{
					if(time < ev.LJOHLEGGGMC)
					{
						int advId;
						int itemId;
						if(time >= ev.DPJCPDKALGI_End1)
						{
							if(time < ev.JDDFILGNGFH)
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
							if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(advId))
							{
								if(t1 == 0 || ev.LJOHLEGGGMC < t1)
								{
									t1 = ev.LJOHLEGGGMC;
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
