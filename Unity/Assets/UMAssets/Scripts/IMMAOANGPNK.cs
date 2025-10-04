using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XeApp.Game.Common;
using SecureLib;
using System;
using XeSys;
using System.Text;

public class IMMAOANGPNK
{
	public class MPFFINOMILP
	{
		public int IJEKNCDIIAE_mver; // 0x8
		public string OPFGFINHFCE_name; // 0xC
		public long PDBPFJJCADD_open_at; // 0x10
	}

	private static bool NAANHMNAHGI; // 0x4
	public int ENEBEGGOHFP; // 0x14
	public int HMHKGLENIOP; // 0x18
	public byte[] GCELJIDIGDG; // 0x20

	public static IMMAOANGPNK HHCJCDFCLOB { get; private set; }  // 0x0 LGMPACEDIJF_bgs // NKACBOEHELJ_bgs 0x9F4C94 OKPMHKNCNAL_bgs 0x9FB6B0
	public bool LNAHEIEIBOI_Initialized { get; set; }  // 0x8 INBPPDMFOAD_bgs  FHEAKKHAAPF_bgs 0x9FB740 GOEIEJFPLOG_bgs 0x9FB748
	public OKGLGHCBCJP_Database NKEBMCIMJND_Database { get; private set; }  // 0xC MFOHJHBKKBA_bgs // GBGACEBEHKM_bgs 0x9F4D20 CCMBFKBIMEE_bgs 0x9FB750
	public string NDHOBEEEKEM { get; private set; }  // 0x10 IKBMAEMKGMN_bgs JNAKONBIOKB_bgs 0x9FB758 PDOJAEDKBDJ_bgs 0x9FB760
	public List<GDIPLANPCEI> JOBKIDDLCPL_schedules { get; private set; } // 0x1C MAFBBMCECAD_bgs AMJKGMNLEKE_bgs 0x9FB768 CMKNDEJMAIJ_bgs 0x9FB770
	public List<MPFFINOMILP> MGFBEKNMJOA { get; private set; } // 0x24 MGMCACBHEGK_bgs FNFJPHEBELC_bgs 0x9FB778 MNINNHABPAA_bgs 0x9FB780

	// // RVA: 0x9FB788 Offset: 0x9FB788 VA: 0x9FB788
	public void IJBGPAENLJA_OnAwake(MonoBehaviour _DANMJLOBLIE_mb)
	{
		HHCJCDFCLOB = this;
		LNAHEIEIBOI_Initialized = false;
		NKEBMCIMJND_Database = new OKGLGHCBCJP_Database();
		ENEBEGGOHFP = 0;
		JOBKIDDLCPL_schedules = new List<GDIPLANPCEI>();
		MGFBEKNMJOA = new List<IMMAOANGPNK.MPFFINOMILP>();
	}

	// // RVA: 0x9FB8A8 Offset: 0x9FB8A8 VA: 0x9FB8A8
	public void BAGMHFKPFIF_Update()
	{
		return;
	}

	// // RVA: 0x9FB8AC Offset: 0x9FB8AC VA: 0x9FB8AC
	public GDIPLANPCEI ACEFBFLFKFD_GetScheduleEventData(string FJMNHCBPKCJ, long _JHNMKKNEENE_Time)
	{
		for(int i = 0; i < JOBKIDDLCPL_schedules.Count; i++)
		{
			if(_JHNMKKNEENE_Time >= JOBKIDDLCPL_schedules[i].KBFOIECIADN_opened_at && JOBKIDDLCPL_schedules[i].EGBOHDFBAPB_closed_at >= _JHNMKKNEENE_Time)
			{
				if (JOBKIDDLCPL_schedules[i].OPFGFINHFCE_name.Contains(FJMNHCBPKCJ))
					return JOBKIDDLCPL_schedules[i];
			}
		}
		return null;
	}

	// // RVA: 0x9FB9FC Offset: 0x9FB9FC VA: 0x9FB9FC
	public void BAHKPIADOBI_LoadFromStorage(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		N.a.StartCoroutineWatched(MHEKMICKGDM_LoadFromStorage(_BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B75F8 Offset: 0x6B75F8 VA: 0x6B75F8
	// // RVA: 0x9FBB1C Offset: 0x9FBB1C VA: 0x9FBB1C
	// private IEnumerator CBIPJKFPJDH_DownloadSchedules(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7670 Offset: 0x6B7670 VA: 0x6B7670
	// // RVA: 0x9FBBFC Offset: 0x9FBBFC VA: 0x9FBBFC
	// private IEnumerator HPGEKNMPMEA_Download(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B76E8 Offset: 0x6B76E8 VA: 0x6B76E8
	// // RVA: 0x9FBA5C Offset: 0x9FBA5C VA: 0x9FBA5C
	private IEnumerator MHEKMICKGDM_LoadFromStorage(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		// private int GGPNEJDOELB; // 0x8
		// private object GMEFKDIEHCA; // 0xC
		// public IMMAOANGPNK KIGBLACMODG; // 0x10
		// private IMMAOANGPNK.<>c__DisplayClass35_1 OPLBFCEPDCH; // 0x14
		// public DJBHIFLHJLK MOBEEPPKFLG_OnFail; // 0x18
		// private IMMAOANGPNK.<>c__DisplayClass35_0 LBLMCMHMNGC; // 0x1C
		// public IMCBBOAFION BHFHGFKBOHH_OnSuccess; // 0x20
		// private string BLOMMALFLCM; // 0x24
		// private GNMBAOKGJDO HCNDEJCCIMA; // 0x28
		// 0x9FF020

		//lambda 1 : 0x9FE328 // lambda 2 : 0x9FE334

		bool KOMKKBDABJP_end = false;
		bool CNAIDEAFAAM_Error = false;
		BBGDKLLEPIB.HHCJCDFCLOB.PAHGEEOFEPM_Install(() => { KOMKKBDABJP_end = true; }, () => { KOMKKBDABJP_end = true; CNAIDEAFAAM_Error = true; }); //?? 0x101
		while(!KOMKKBDABJP_end)
		{
			yield return null;
		}
		if(CNAIDEAFAAM_Error)
		{
			_MOBEEPPKFLG_OnFail();
        	TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error MHEKMICKGDM_LoadFromStorage");
			yield break;
		}

		yield return Co.R(DatabaseTextConverter.LoadAdditionalLanguageBank());

		string str = BBGDKLLEPIB.OGCDNCDMLCA_LocalPath; // mx install dir
		if(!string.IsNullOrEmpty(str))
		{
			if(!string.IsNullOrEmpty(BBGDKLLEPIB.HHCJCDFCLOB.OCOGBOHOGGE_DbFileName))
			{
				bool BEKAMBBOLBO_Done = false;
				IIEDOGCMCIE GBEGLNMFLIE = new IIEDOGCMCIE();
				GBEGLNMFLIE.MCDJJPAKBLH(str + BBGDKLLEPIB.HHCJCDFCLOB.OCOGBOHOGGE_DbFileName);
				while(GBEGLNMFLIE.PLOOEECNHFB_IsDone == false)
				{
					yield return null;
				}
				if(GBEGLNMFLIE.NPNNPNAIONN_IsError == true)
				{
					yield return N.a.StartCoroutineWatched(LGFPCADOCAA_Coroutine_ShowError());
					_MOBEEPPKFLG_OnFail();
					GBEGLNMFLIE = null;
        			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error MHEKMICKGDM_LoadFromStorage");
					yield break;
				}
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				CMFCGGAKLFN(GBEGLNMFLIE, time); // Read versions
				BBHOKHCDBFI(GBEGLNMFLIE); // Read Schedules
				List<OKGLGHCBCJP_Database.BEOKNKGHFFE_Section> list = NKEBMCIMJND_Database.BPCKOIDILDK_GetSectionsValid(JOBKIDDLCPL_schedules, time);
				NKEBMCIMJND_Database.LNAKMLCCEJG_AddSections(list, OKGLGHCBCJP_Database.GAAEFILMAED_BaseSectionList);
				NKEBMCIMJND_Database.KHEKNNFCAOI_Init(list);
				bool HBODCMLFDOB_result = false;
				NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
					List<string> listStr = NKEBMCIMJND_Database.PKOJMBICNHH_GetBlockNames();
					HBODCMLFDOB_result = NKEBMCIMJND_Database.IIEMACPEEBJ_Deserialize(listStr, GBEGLNMFLIE);
					if(HBODCMLFDOB_result)
					{
						MLIBEPGADJH_Scene a = NKEBMCIMJND_Database.ECNHDEHADGL_Scene;
						if(a != null)
						{
							KOGHKIODHPA_Board b = NKEBMCIMJND_Database.JEMMMJEJLNL_Board;
							if(b != null)
							{
								a.AMACEDAPNKJ(NKEBMCIMJND_Database.HNMMJINNHII_Game, b);
							}
						}
						BBLECJKKKLA_DecoSetItem c = NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem;
						if(c != null)
						{
							NDBFKHKMMCE_DecoItem d = NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem;
							if(d != null)
							{
								d.MFIAFCCJHOF(c);
							}
						}
					}
					BEKAMBBOLBO_Done = true;
				});
				while(!BEKAMBBOLBO_Done)
					yield return null;
				
				if(!HBODCMLFDOB_result)
				{
					yield return N.a.StartCoroutineWatched(LGFPCADOCAA_Coroutine_ShowError());
					_MOBEEPPKFLG_OnFail();
        			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error MHEKMICKGDM_LoadFromStorage");
					yield break;
				}
				
				if(MessageLoader.Instance != null)
				{
					MessageLoader.Instance.Request(GBEGLNMFLIE, MessageLoader.eSheet.common, 0);
					yield return MessageLoader.Instance.WaitForDone(N.a);
					MessageLoader.Instance.Request(GBEGLNMFLIE, MessageLoader.eSheet.menu, 0);
					yield return MessageLoader.Instance.WaitForDone(N.a);
					MessageLoader.Instance.Request(GBEGLNMFLIE, MessageLoader.eSheet.master, 0);
					yield return MessageLoader.Instance.WaitForDone(N.a);
					for(int i = 4; i < 14; i++)
					{
						MessageLoader.Instance.Request(GBEGLNMFLIE, (MessageLoader.eSheet)i, 0);
						yield return MessageLoader.Instance.WaitForDone(N.a);
					}
					Database.Instance.musicText.LoadFromTAR(GBEGLNMFLIE);
					Database.Instance.roomText.LoadFromBinaryTAR(GBEGLNMFLIE);
				}
				
				AMAFAKNIHFO();
				NKEBMCIMJND_Database.IDBDAPPJOND();
				KPKEOIJHIMN f = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.DAOHAKABAFG;
				f.FFEJIGPPHOA(BBGDKLLEPIB.LHJNPJFNDNA_Rev);
				string BLOMMALFLCM = BBGDKLLEPIB.OGCDNCDMLCA_LocalPath;
				BLOMMALFLCM = BLOMMALFLCM + BBGDKLLEPIB.JNPHAJICDPN_SdFileName;
				//new XeApp.Game.Net.Security.SecureGZFile
				GNMBAOKGJDO HCNDEJCCIMA = new GNMBAOKGJDO();
				HCNDEJCCIMA.MCDJJPAKBLH(BLOMMALFLCM);
				while(!HCNDEJCCIMA.PLOOEECNHFB_IsDone)
				{
					yield return null;
				}
				if(File.Exists(BLOMMALFLCM))
				{
					TodoLogger.Log(TodoLogger.Filesystem, "Delete File "+BLOMMALFLCM);
					//File.Delete(BLOMMALFLCM);
				}
				GCELJIDIGDG = HCNDEJCCIMA.IAKPCFDLMKP_db;
				if(!HCNDEJCCIMA.NPNNPNAIONN_IsError)
				{
					BLOMMALFLCM = null;
					HCNDEJCCIMA = null;
					bool LAB_00a0006c = false;
					if(!NAANHMNAHGI)
					{
						if(GCELJIDIGDG == null)
						{
							BEKAMBBOLBO_Done = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => { // 0x9FE2CC
								BEKAMBBOLBO_Done = true;
							}, "");
							while(!BEKAMBBOLBO_Done)
							{
								yield return null;
							}
						}
						else
						{
							CNGFKOJANNP.HHCJCDFCLOB.NOIKNDALDAC(GCELJIDIGDG);
							if(GCELJIDIGDG != null)
							{
								ATELIDAVAPK a = new ATELIDAVAPK();
								if(a.Init(GCELJIDIGDG))
								{
									if(!a.CCKHESGNI())
									{
										BEKAMBBOLBO_Done = false;
										JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2D8
											BEKAMBBOLBO_Done = true;
										}, "");
										while(!BEKAMBBOLBO_Done)
										{
											yield return null;
										}
									}
									else if(!a.QTHZDMBR())
									{
										BEKAMBBOLBO_Done = false;
										JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2E4
											BEKAMBBOLBO_Done = true;
										}, "");
										while(!BEKAMBBOLBO_Done)
										{
											yield return null;
										}
									}
									else // a.QTHZDMBR()
									{
										NAANHMNAHGI = true;
										LAB_00a0006c = true;
									}
								}
								else
								{
									BEKAMBBOLBO_Done = false;
									JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2F0
										BEKAMBBOLBO_Done = true;
									}, "");
									while(!BEKAMBBOLBO_Done)
									{
										yield return null;
									}
								}
							}
							else
							{
								LAB_00a0006c = true;
							}
						}
					}
					else
					{
						LAB_00a0006c = true;
					}
					if(LAB_00a0006c)
					{
						if(SecureLibAPI.isDebuggerAttachedJava())
						{
							BEKAMBBOLBO_Done = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2FC
								BEKAMBBOLBO_Done = true;
							}, "");
							while(!BEKAMBBOLBO_Done)
							{
								yield return null;
							}
						}
						else if(SecureLibAPI.isDebuggerAttachedNative())
						{
							BEKAMBBOLBO_Done = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE308
								BEKAMBBOLBO_Done = true;
							}, "");
							while(!BEKAMBBOLBO_Done)
							{
								yield return null;
							}
						}
						else 
						{
							if(!SecureLibAPI.isEmulator())
							{
								if(_BHFHGFKBOHH_OnSuccess != null)
								{
									_BHFHGFKBOHH_OnSuccess();
									LNAHEIEIBOI_Initialized = true;
									yield break;
								}
							}
							BEKAMBBOLBO_Done = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE314
								BEKAMBBOLBO_Done = true;
							}, "");
							while(!BEKAMBBOLBO_Done)
							{
								yield return null;
							}
						}
					}
				}
				else
				{
					BEKAMBBOLBO_Done = false;
					JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2C0
						BEKAMBBOLBO_Done = true;
					}, "");
					while(!BEKAMBBOLBO_Done)
					{
						yield return null;
					}
				}
				_MOBEEPPKFLG_OnFail();
        		TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error MHEKMICKGDM_LoadFromStorage");
				yield break;
			}
		}
		yield return N.a.StartCoroutineWatched(LGFPCADOCAA_Coroutine_ShowError());
		_MOBEEPPKFLG_OnFail();
        TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error MHEKMICKGDM_LoadFromStorage");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7760 Offset: 0x6B7760 VA: 0x6B7760
	// // RVA: 0x9FBCFC Offset: 0x9FBCFC VA: 0x9FBCFC
	private IEnumerator LGFPCADOCAA_Coroutine_ShowError()
	{
		//0xA0093C
		bool BEKAMBBOLBO_Done = false;
		JHHBAFKMBDL.HHCJCDFCLOB.LIBDGGBAINI(() =>
		{
			//0x9FE348
			BEKAMBBOLBO_Done = true;
		});
		while(!BEKAMBBOLBO_Done)
			yield return null;
	}

	// // RVA: 0x9FBD90 Offset: 0x9FBD90 VA: 0x9FBD90
	// public bool HFCOEBFNJPK() { }

	// // RVA: 0x9FBEAC Offset: 0x9FBEAC VA: 0x9FBEAC
	// public void OMHKOKKAMNO(IMCBBOAFION EDIIEFHAOGP) { }

	// // RVA: 0x9FC14C Offset: 0x9FC14C VA: 0x9FC14C
	private void AMAFAKNIHFO()
	{
		if(NKEBMCIMJND_Database == null || NKEBMCIMJND_Database.GDEKCOOBLMA_System == null)
		{
			return;
		}
		
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.CEEAFKHANJB(NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP_Settings.KHGJIGNHAGD_retry_try_cnt, NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP_Settings.JOIEHMBKJHI_retry_wait_ms);
		//L54
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.BLFILNOBHMM = 0 < NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("action_revert_show_error", 0);
		if(!NKEBMCIMJND_Database.GDEKCOOBLMA_System.OHJFBLFELNK_m_intParam.ContainsKey(AFEHLCGHAEE_Strings.JJHDDBLNOHA_delay_install_autowait/*delay_install_autowait*/))
		{
			return;
		}
		KDLPEDBKMID.HHCJCDFCLOB.OIKLOJMPBGA_SetInstallAutoWait(NKEBMCIMJND_Database.GDEKCOOBLMA_System.OHJFBLFELNK_m_intParam[AFEHLCGHAEE_Strings.JJHDDBLNOHA_delay_install_autowait/*delay_install_autowait*/].DNJEJEANJGL_Value);
	}

	// // RVA: 0x9FC460 Offset: 0x9FC460 VA: 0x9FC460
	// private void PDKNJAEGNIL() { }

	// // RVA: 0x9FC4CC Offset: 0x9FC4CC VA: 0x9FC4CC
	public void PFAKPFKJJKA()
	{
		if(LNAHEIEIBOI_Initialized)
		{
			if (ENEBEGGOHFP != 0)
				return;
			ENEBEGGOHFP = NKEBMCIMJND_Database.PFAKPFKJJKA();
		}
	}

	// // RVA: 0x9FC518 Offset: 0x9FC518 VA: 0x9FC518
	private void BBHOKHCDBFI(CBBJHPBGBAJ_Archive GBEGLNMFLIE)
	{
		JOBKIDDLCPL_schedules.Clear();
		CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File item = GBEGLNMFLIE.KGHAJGGMPKL_files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File _GHPLINIACBB_x) => {
			//0x9FDD4C 
			return _GHPLINIACBB_x.OPFGFINHFCE_name.Contains("schedule");
		});
		if(item != null)
		{
			UMOEventList.EventData currentEvent = UMOEventList.GetCurrentEvent();
			if(item.OPFGFINHFCE_name.Contains(".bytes"))
			{
				IOBIKMEGCAL data = IOBIKMEGCAL.HEGEKFMJNCC(item.DBBGALAPFGC_bytes);
				DMABOGLGILJ[] schedule_item = data.IHMCKPOIBDA;
				for (int i = 0; i < schedule_item.Length; i++)
				{
					GDIPLANPCEI info = new GDIPLANPCEI();
					info.OPFGFINHFCE_name = schedule_item[i].OPFGFINHFCE_name;
					info.KBFOIECIADN_opened_at = schedule_item[i].KBFOIECIADN_opened_at;
					info.EGBOHDFBAPB_closed_at = schedule_item[i].EGBOHDFBAPB_closed_at;
					// UMO Event
					if(currentEvent != null && currentEvent.EnableBlock(info.OPFGFINHFCE_name))
					//if(info.OPFGFINHFCE_name.Contains("april"))
					{
						DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
						date = date.Subtract(new TimeSpan(1, 0, 0, 0));
						info.KBFOIECIADN_opened_at = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
						date = date.AddDays(11);
						info.EGBOHDFBAPB_closed_at = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
					}
					// UMO Event End
					JOBKIDDLCPL_schedules.Add(info);
				}
				// Hack for UMO to add quest_a b & c
				if(currentEvent != null && currentEvent.EnableBlock("event_quest_a"))
					JOBKIDDLCPL_schedules.Add(new GDIPLANPCEI() { OPFGFINHFCE_name = "event_quest_a", KBFOIECIADN_opened_at = 0, EGBOHDFBAPB_closed_at = long.MaxValue });
				if(currentEvent != null && currentEvent.EnableBlock("event_quest_b"))
					JOBKIDDLCPL_schedules.Add(new GDIPLANPCEI() { OPFGFINHFCE_name = "event_quest_b", KBFOIECIADN_opened_at = 0, EGBOHDFBAPB_closed_at = long.MaxValue });
				if(currentEvent != null && currentEvent.EnableBlock("event_quest_c"))
					JOBKIDDLCPL_schedules.Add(new GDIPLANPCEI() { OPFGFINHFCE_name = "event_quest_c", KBFOIECIADN_opened_at = 0, EGBOHDFBAPB_closed_at = long.MaxValue });
				//
			}
			else if(item.OPFGFINHFCE_name.Contains(".json"))
			{
				string str = Encoding.UTF8.GetString(item.DBBGALAPFGC_bytes);
				EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(str);
				EDOHBJAPLPF_JsonData data = json[AFEHLCGHAEE_Strings.JOBKIDDLCPL_schedules];
				for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
				{
					GDIPLANPCEI info = new GDIPLANPCEI();
					info.OPFGFINHFCE_name = (string)data[i][AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
					info.KBFOIECIADN_opened_at = JsonUtil.GetLong(data[i], AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at);
					info.EGBOHDFBAPB_closed_at = JsonUtil.GetLong(data[i], AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at);
					// UMO Event
					if(currentEvent != null && currentEvent.EnableBlock(info.OPFGFINHFCE_name))
					//if(info.OPFGFINHFCE_name.Contains("april"))
					{
						DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
						date = date.Subtract(new TimeSpan(1, 0, 0, 0));
						info.KBFOIECIADN_opened_at = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
						date = date.AddDays(11);
						info.EGBOHDFBAPB_closed_at = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
					}
					// UMO Event End
					JOBKIDDLCPL_schedules.Add(info);
				}
			}
		}
	}

	// // RVA: 0x9FCE3C Offset: 0x9FCE3C VA: 0x9FCE3C
	public bool JMAMHEJDNNN_IsScheduledEvent(long _JHNMKKNEENE_Time)
	{
		for(int i = 0; i < JOBKIDDLCPL_schedules.Count; i++)
		{
			if (JOBKIDDLCPL_schedules[i].KBFOIECIADN_opened_at <= _JHNMKKNEENE_Time && JOBKIDDLCPL_schedules[i].EGBOHDFBAPB_closed_at >= _JHNMKKNEENE_Time)
			{
				if (NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOBKIDDLCPL_schedules[i].OPFGFINHFCE_name) == null)
					return true;
			}
		}
		return false;
	}

	// // RVA: 0x9FCF88 Offset: 0x9FCF88 VA: 0x9FCF88
	private void CMFCGGAKLFN(CBBJHPBGBAJ_Archive GBEGLNMFLIE, long _JHNMKKNEENE_Time)
	{
		
	// public static readonly IMMAOANGPNK.<>c <>9; // 0x0
	// public static Predicate<CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File> <>9__42_0; // 0x4
	// public static Predicate<CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File> <>9__44_0; // 0x8
	// public static Comparison<IMMAOANGPNK.MPFFINOMILP> <>9__44_1; // 0xC
		MGFBEKNMJOA.Clear();
		
		CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File res = GBEGLNMFLIE.KGHAJGGMPKL_files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File _GHPLINIACBB_x) =>
		{
			return _GHPLINIACBB_x.OPFGFINHFCE_name.Contains("version.bytes");
		}); // 0x9FDDD8
		if(res != null)
		{
			IDEELDJLDBN a = IDEELDJLDBN.HEGEKFMJNCC(res.DBBGALAPFGC_bytes);
			JGIHJPPECBB[] b = a.MLOPDBGPLFI;
			MPFFINOMILP obj = null;
			for(int i = 0; i < b.Length; i++)
			{
				int val = b[i].BEBJKJKBOGH_date;
				if(_JHNMKKNEENE_Time >= val)
				{
					if(obj != null)
					{
						if(obj.PDBPFJJCADD_open_at >= val)
						{
							continue;
						}
					}
					obj = new MPFFINOMILP();
					obj.OPFGFINHFCE_name = b[i].OPFGFINHFCE_name;
					obj.PDBPFJJCADD_open_at = val;
					obj.IJEKNCDIIAE_mver = b[i].IJEKNCDIIAE_mver;
				}
				else
				{
					MPFFINOMILP obj2 = new MPFFINOMILP();
					obj2.OPFGFINHFCE_name = b[i].OPFGFINHFCE_name;
					obj2.PDBPFJJCADD_open_at = val;
					obj2.IJEKNCDIIAE_mver = b[i].IJEKNCDIIAE_mver;
					MGFBEKNMJOA.Add(obj2);
				}
			}
			if(obj != null)
			{
				MGFBEKNMJOA.Add(obj);
			}
			
			MGFBEKNMJOA.Sort((IMMAOANGPNK.MPFFINOMILP _HKICMNAACDA_a, IMMAOANGPNK.MPFFINOMILP _BNKHBCBJBKI_b) => {
				//0x9FDE64 
				return _HKICMNAACDA_a.PDBPFJJCADD_open_at.CompareTo(_BNKHBCBJBKI_b.PDBPFJJCADD_open_at);
			});
			if(MGFBEKNMJOA.Count > 0)
			{
				IMMAOANGPNK.MPFFINOMILP item = MGFBEKNMJOA[0];
				if(_JHNMKKNEENE_Time >= item.PDBPFJJCADD_open_at)
				{
					DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion = item.IJEKNCDIIAE_mver;
					object[] strData = new object[4];
					strData[0] = "mver= ";
					strData[1] = item.IJEKNCDIIAE_mver;
					strData[2] = ",name=";
					strData[3] = item.OPFGFINHFCE_name;
					UnityEngine.Debug.Log(string.Concat(strData));
				}
			}
		}
	}

	// // RVA: 0x9FD930 Offset: 0x9FD930 VA: 0x9FD930
	public bool MKINIELBKEK(long _JHNMKKNEENE_Time)
	{
		for(int i = 0; i < MGFBEKNMJOA.Count; i++)
		{
			if (_JHNMKKNEENE_Time < MGFBEKNMJOA[i].PDBPFJJCADD_open_at)
			{
				object[] o = new object[4] { JpStringLiterals.StringLiteral_11781, MGFBEKNMJOA[i].IJEKNCDIIAE_mver, ",name=", MGFBEKNMJOA[i].OPFGFINHFCE_name };
				Debug.Log(string.Concat(o));
				return true;
			}
		}
		return false;
	}
}
