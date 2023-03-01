
using System;
using System.Collections.Generic;
using XeSys;

public class FEAOOBFHMBL
{
	// RVA: 0xFCE76C Offset: 0xFCE76C VA: 0xFCE76C
	public static void DOMFHDPMCCO_CheckDailyQuest(OKGLGHCBCJP_Database LKMHPJKIFDN_Database, BBHNACPENDM_ServerSaveData LDEGEHAEALK_ServerData, long JHNMKKNEENE_Time, bool FBBNPFFEJBN_Force)
	{
		if(LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest != null)
		{
			if(LKMHPJKIFDN_Database.MHGPMMIDKMM_Quest != null)
			{
				DateTime questDate = Utility.GetLocalDateTime(LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.FANICHGKOML_InitDate);
				DateTime questDate2 = Utility.GetLocalDateTime(JHNMKKNEENE_Time);
				if(!FBBNPFFEJBN_Force)
				{
					if(questDate.Date == questDate2.Date)
					{
						return;
					}
				}
				LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.FANICHGKOML_InitDate = JHNMKKNEENE_Time;
				for(int i = 0; i < LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests.Count; i++)
				{
					LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[i].EALOBDHOCHP_Stat = 0;
					LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[i].BEBJKJKBOGH_Date = 0;
					LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[i].CADENLBDAEB_New = true;
				}
				List<int> l = new List<int>();
				int qIdx = -1; // 6c
				int numStarted = 0; // 68
				for(int i = 0; i < LKMHPJKIFDN_Database.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests.Count; i++)
				{
					CNLPPCFJEID_QuestInfo q = LKMHPJKIFDN_Database.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[i];
					if (q.INDDJNMPONH != 0)
					{
						if((q.KJBGCLPMLCG == 0 && q.GJFPFFBAKGK == 0) || (q.KJBGCLPMLCG < JHNMKKNEENE_Time && q.GJFPFFBAKGK > JHNMKKNEENE_Time))
						{
							/*if(q.GJFPFFBAKGK != 0)
							{
								LAB_00fcec84
							}*/
							//LAB_00fcecd4
							if(q.AKBHPFBDDOL_DayOfWeek < 10 || q.AKBHPFBDDOL_DayOfWeek > 16)
							{
								//LAB_00fced48
								if (q.AKBHPFBDDOL_DayOfWeek != 1)
								{
									l.Add(i);
									// goLAB_00fcee70
								}
								else
								{
									int a = i;
									if (q.INDDJNMPONH != 6)
										a = qIdx;
									if (qIdx < 0)
										qIdx = a;
								}
								LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[i].EALOBDHOCHP_Stat = 1;
								numStarted++;
							}
							else
							{
								/*if(q.AKBHPFBDDOL > 16)
								{
									LAB_00fced48
								}*/
								int dayOfWeek = (int)questDate2.DayOfWeek;
								int b = q.AKBHPFBDDOL_DayOfWeek;
								if (dayOfWeek + 10 != b)
								{
									// go LAB_00fcee70
								}
								else
								{
									if (q.INDDJNMPONH == 6)
									{
										if (qIdx < 0)
										{
											qIdx = i;
										}
										// go LAB_00fcee70
									}
									else
									{
										LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[i].EALOBDHOCHP_Stat = 1;
										numStarted++;
									}
								}
							}
						}
						else
						{
							//LAB_00fcec84
							/*if(q.KJBGCLPMLCG < JHNMKKNEENE_Time && q.GJFPFFBAKGK > JHNMKKNEENE_Time)
							{
								// go LAB_00fcecd4

							}*/
						}
					}
					//LAB_00fcee70
				}
				for(int i = 0; i < l.Count; i++)
				{
					int v = UnityEngine.Random.Range(0, l.Count);
					int a = l[i];
					int b = l[v];
					l[i] = b;
					l[i] = a;
				}
				int num = 0;
				if (qIdx < 0)
				{
					num = 3;
				}
				else
				{
					CNLPPCFJEID_QuestInfo q = LKMHPJKIFDN_Database.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[qIdx];
					num = q.FCDKJAKLGMB;
					NFPHOINMHKN_QuestInfo q2 = LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[qIdx];
					q2.EALOBDHOCHP_Stat = 1;
					q2.CADENLBDAEB_New = true;
				}
				if (num < numStarted)
					return;
				numStarted = num - numStarted;
				for(int i = 0; i < numStarted; i++)
				{
					if(l.Count > i)
					{
						int idx = l[i];
						NFPHOINMHKN_QuestInfo q2 = LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[idx];
						q2.EALOBDHOCHP_Stat = 1;
						q2.CADENLBDAEB_New = true;
					}
				}
			}
		}
	}
}
