
using System;
using System.Collections.Generic;
using System.Text;
using XeApp.Game.Menu;
using XeSys;

public class DKKPBBBDKMJ
{
	public class AGAAGMGKNCO
	{
		public int PGIIDPEGGPI_EventId; // 0x8
		public string LLNKMABDDEB_Period; // 0xC
		public byte CPKMLLNADLJ_Serie; // 0x10
		public bool CADENLBDAEB_IsNew; // 0x11
	}

	private StringBuilder FAEDHJHCEFJ = new StringBuilder(256); // 0x8
	private List<AGAAGMGKNCO> NNDGIAEFMOG = new List<AGAAGMGKNCO>(); // 0xC
	private List<int> AIAPGDMLIIE = new List<int>(); // 0x10
	private GCIJNCFDNON_SceneInfo HOMGKHBHDME = new GCIJNCFDNON_SceneInfo(); // 0x14

	public bool MHCPOIEDLJF { get; private set; } // 0x18 IPOIPOGEPKC GIOHLDELCNF DBKAOCENIHJ

	//// RVA: 0x1224E7C Offset: 0x1224E7C VA: 0x1224E7C
	public int KPEBMCLONHK()
	{
		return AIAPGDMLIIE.Count;
	}

	//// RVA: 0x1224EF4 Offset: 0x1224EF4 VA: 0x1224EF4
	public AGAAGMGKNCO NPIOEBNLBCI(int _OIPCCBHIKIA_index)
	{
		return NNDGIAEFMOG[AIAPGDMLIIE[_OIPCCBHIKIA_index]];
	}

	//// RVA: 0x1224FB8 Offset: 0x1224FB8 VA: 0x1224FB8
	public void KHEKNNFCAOI_Init()
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		MHCPOIEDLJF = false;
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.ILEJEJKNOBN_StoryList.Count; i++)
		{
			FBIOJHECAHB_EventStory.GIEHECAKIFC_StoryInfo storyEvent = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.ILEJEJKNOBN_StoryList[i];
			if(storyEvent.PPEGAKEIEGM_Enabled == 2)
			{
				bool hasNewAdv = false;
				bool b2 = false;
				bool b3 = false;
				for(int j = 0; j < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.JPIGOBGOMON_StoryPartsList.Count; j++)
				{
					FBIOJHECAHB_EventStory.ENDMMNNOAIL_StoryPartInfo storyEvent2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.JPIGOBGOMON_StoryPartsList[j];
					if(storyEvent.OAFJONPIFGM_EventId == storyEvent2.OAFJONPIFGM_EventId)
					{
						if(storyEvent2.JDJNNJEJDAJ_Type == FBIOJHECAHB_EventStory.NMIGMCJHAIE.MOPAEGFEGCB_5_EpisodeStory)
						{
							if(storyEvent2.CHOFDPDFPDC_ConfigValue == 4)
							{
								if(storyEvent.MGBDCFIKBPM_Serie == 5)
								{
									MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[CCAAJNJGNDO.FCMFPPALLOM(storyEvent.OAFJONPIFGM_EventId) - 1];
									MLIBEPGADJH_Scene.KKLDOOJBJMN scene2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[CCAAJNJGNDO.FCMFPPALLOM(storyEvent.OAFJONPIFGM_EventId) - 1];
									HOMGKHBHDME.KHEKNNFCAOI_Init(scene.PPFNGGCBJKC_id, scene.PDNIFBEGMHC_Mb, scene.EMOJHJGHJLN_Sb, scene.JPIPENJGGDD_NumBoard, scene.IELENGDJPHF_Ulk, scene.MJBODMOLOBC_luck, scene.LHMOAJAIJCO_is_new, scene.BEBJKJKBOGH_Date, scene.DMNIMMGGJJJ_Leaf);
									if(HOMGKHBHDME.CGKAEMGLHNK_IsUnlocked())
									{
										if(scene2.PPEGAKEIEGM_Enabled > 1)
										{
											if(HOMGKHBHDME.EKLIPGELKCL_Rarity > 5)
											{
												if(HOMGKHBHDME.FGMPFHOEPEL_GetNumUnlockedStory() != 0)
												{
													MHCPOIEDLJF = true;
													hasNewAdv |= !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(storyEvent2.LOHMKCPKBON_AdvId);
													b2 = true;
													continue;
												}
											}
										}
									}
								}
								b3 = true;
							}
							else if(storyEvent2.CHOFDPDFPDC_ConfigValue == 3)
							{
								if (!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(storyEvent2.LOHMKCPKBON_AdvId))
								{
									b3 = true;
								}
								else
								{
									if(storyEvent.MGBDCFIKBPM_Serie == 5)
									{
										b2 = true;
										MHCPOIEDLJF = true;
									}
								}
							}
						}
					}
				}
				if(!b3)
				{
					IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(storyEvent.OAFJONPIFGM_EventId);
					if(ev != null)
					{
						ev.HCDGELDHFHB_UpdateStatus(t);
						if (ev.EMEKFFHCHMH_RewardEnd2 >= t)
							continue;
					}
					AGAAGMGKNCO data = new AGAAGMGKNCO();
					data.PGIIDPEGGPI_EventId = storyEvent.OAFJONPIFGM_EventId;
					data.CADENLBDAEB_IsNew = hasNewAdv;
					data.CPKMLLNADLJ_Serie = storyEvent.MGBDCFIKBPM_Serie;
					DateTime dt = Utility.GetLocalDateTime(storyEvent.PDBPFJJCADD_open_at);
					DateTime dt2 = Utility.GetLocalDateTime(storyEvent.FDBNFFNFOND_CloseAt);
					FAEDHJHCEFJ.Clear();
					FAEDHJHCEFJ.AppendFormat(bk.GetMessageByLabel("event_story_list_period"), new object[6]
					{
						dt.Year, dt.Month, dt.Day, dt2.Year, dt2.Month, dt2.Day
					});
					data.LLNKMABDDEB_Period = "";
					if (!b2)
					{
						data.LLNKMABDDEB_Period = FAEDHJHCEFJ.ToString();
					}
					NNDGIAEFMOG.Add(data);
				}
			}
		}
		NFGLACBNEEN(0);
	}

	//// RVA: 0x12261E8 Offset: 0x12261E8 VA: 0x12261E8
	public void NFGLACBNEEN(int _CPKMLLNADLJ_Serie)
	{
		AIAPGDMLIIE.Clear();
		for(int i = NNDGIAEFMOG.Count - 1; i >= 0; i--)
		{
			if (NNDGIAEFMOG[i].CPKMLLNADLJ_Serie == _CPKMLLNADLJ_Serie)
				AIAPGDMLIIE.Add(i);
		}
	}

	//// RVA: 0x1226328 Offset: 0x1226328 VA: 0x1226328
	public void JPLNEJFDPHN(int _CPKMLLNADLJ_Serie)
	{
		foreach(var k in NNDGIAEFMOG)
		{
			if(k.CPKMLLNADLJ_Serie == 5)
			{
				int a1 = 0;
				bool hasViewed = false;
				foreach (var k2 in IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.JPIGOBGOMON_StoryPartsList)
				{
					if(k2.OAFJONPIFGM_EventId == k.PGIIDPEGGPI_EventId && k2.CHOFDPDFPDC_ConfigValue == 4)
					{
						MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[CCAAJNJGNDO.FCMFPPALLOM(k2.OAFJONPIFGM_EventId) - 1];
						MLIBEPGADJH_Scene.KKLDOOJBJMN scene2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[CCAAJNJGNDO.FCMFPPALLOM(k2.OAFJONPIFGM_EventId) - 1];
						HOMGKHBHDME.KHEKNNFCAOI_Init(scene.PPFNGGCBJKC_id, scene.PDNIFBEGMHC_Mb, scene.EMOJHJGHJLN_Sb, scene.JPIPENJGGDD_NumBoard, scene.IELENGDJPHF_Ulk, scene.MJBODMOLOBC_luck, scene.LHMOAJAIJCO_is_new, scene.BEBJKJKBOGH_Date, scene.DMNIMMGGJJJ_Leaf);
						a1++;
						if (HOMGKHBHDME.CGKAEMGLHNK_IsUnlocked())
						{
							if(scene2.PPEGAKEIEGM_Enabled > 1)
							{
								if(HOMGKHBHDME.EKLIPGELKCL_Rarity > 5)
								{
									if(HOMGKHBHDME.FGMPFHOEPEL_GetNumUnlockedStory() >= a1)
									{
										hasViewed |= !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(k2.LOHMKCPKBON_AdvId);
									}
								}
							}
						}
					}
				}
				k.CADENLBDAEB_IsNew = hasViewed;
			}
		}
	}

	//// RVA: 0x1226BD4 Offset: 0x1226BD4 VA: 0x1226BD4
	public bool ONIBJLOEMDF_IsNewInCategorie(int _CPKMLLNADLJ_Serie)
	{
		foreach(var k in NNDGIAEFMOG)
		{
			if (k.CPKMLLNADLJ_Serie == _CPKMLLNADLJ_Serie && k.CADENLBDAEB_IsNew)
				return true;
		}
		return false;
	}

	//// RVA: 0x1226D50 Offset: 0x1226D50 VA: 0x1226D50
	public static bool CADENLBDAEB_IsNew()
	{
		bool res = false;
		if(!QuestUtility.IsBeginnerQuest())
		{
			res = !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ADKJDHPEAJH(XeApp.Game.Common.GPFlagConstant.ID.IsNewEventStory);
		}
		return res;
	}

	//// RVA: 0x1226E78 Offset: 0x1226E78 VA: 0x1226E78
	public static void EMNNLEFCKHM(bool CNNHEENBECK)
	{
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BCLKCMDGDLD(XeApp.Game.Common.GPFlagConstant.ID.IsNewEventStory, CNNHEENBECK);
	}
}
