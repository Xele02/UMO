using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XeApp.Game.Common;
using SecureLib;

public class IMMAOANGPNK
{
	public class MPFFINOMILP
	{
		public int IJEKNCDIIAE; // 0x8
		public string OPFGFINHFCE; // 0xC
		public long PDBPFJJCADD; // 0x10
	}

	private static bool NAANHMNAHGI; // 0x4
	public int ENEBEGGOHFP; // 0x14
	public int HMHKGLENIOP; // 0x18
	public byte[] GCELJIDIGDG; // 0x20

	public static IMMAOANGPNK HHCJCDFCLOB { get; private set; }  // 0x0 LGMPACEDIJF // NKACBOEHELJ 0x9F4C94 OKPMHKNCNAL 0x9FB6B0
	public bool LNAHEIEIBOI_Initialized { get; set; }  // 0x8 INBPPDMFOAD  FHEAKKHAAPF 0x9FB740 GOEIEJFPLOG 0x9FB748
	public OKGLGHCBCJP_Database NKEBMCIMJND_Database { get; private set; }  // 0xC MFOHJHBKKBA // GBGACEBEHKM 0x9F4D20 CCMBFKBIMEE 0x9FB750
	public string NDHOBEEEKEM { get; private set; }  // 0x10 IKBMAEMKGMN JNAKONBIOKB 0x9FB758 PDOJAEDKBDJ 0x9FB760
	public List<GDIPLANPCEI> JOBKIDDLCPL_ScheduleEvent { get; private set; } // 0x1C MAFBBMCECAD AMJKGMNLEKE 0x9FB768 CMKNDEJMAIJ 0x9FB770
	public List<IMMAOANGPNK.MPFFINOMILP> MGFBEKNMJOA { get; private set; } // 0x24 MGMCACBHEGK FNFJPHEBELC 0x9FB778 MNINNHABPAA 0x9FB780

	// // RVA: 0x9FB788 Offset: 0x9FB788 VA: 0x9FB788
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		LNAHEIEIBOI_Initialized = false;
		NKEBMCIMJND_Database = new OKGLGHCBCJP_Database();
		ENEBEGGOHFP = 0;
		JOBKIDDLCPL_ScheduleEvent = new List<GDIPLANPCEI>();
		MGFBEKNMJOA = new List<IMMAOANGPNK.MPFFINOMILP>();
	}

	// // RVA: 0x9FB8A8 Offset: 0x9FB8A8 VA: 0x9FB8A8
	public void BAGMHFKPFIF()
	{
		return;
	}

	// // RVA: 0x9FB8AC Offset: 0x9FB8AC VA: 0x9FB8AC
	// public GDIPLANPCEI ACEFBFLFKFD(string FJMNHCBPKCJ, long JHNMKKNEENE) { }

	// // RVA: 0x9FB9FC Offset: 0x9FB9FC VA: 0x9FB9FC
	public void BAHKPIADOBI(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		N.a.StartCoroutine(MHEKMICKGDM_LoadFromStorage(BHFHGFKBOHH, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B75F8 Offset: 0x6B75F8 VA: 0x6B75F8
	// // RVA: 0x9FBB1C Offset: 0x9FBB1C VA: 0x9FBB1C
	// private IEnumerator CBIPJKFPJDH_DownloadSchedules(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7670 Offset: 0x6B7670 VA: 0x6B7670
	// // RVA: 0x9FBBFC Offset: 0x9FBBFC VA: 0x9FBBFC
	// private IEnumerator HPGEKNMPMEA_Download(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B76E8 Offset: 0x6B76E8 VA: 0x6B76E8
	// // RVA: 0x9FBA5C Offset: 0x9FBA5C VA: 0x9FBA5C
	private IEnumerator MHEKMICKGDM_LoadFromStorage(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
        UnityEngine.Debug.Log("Enter MHEKMICKGDM_LoadFromStorage");
		// private int GGPNEJDOELB; // 0x8
		// private object GMEFKDIEHCA; // 0xC
		// public IMMAOANGPNK KIGBLACMODG; // 0x10
		// private IMMAOANGPNK.<>c__DisplayClass35_1 OPLBFCEPDCH; // 0x14
		// public DJBHIFLHJLK MOBEEPPKFLG; // 0x18
		// private IMMAOANGPNK.<>c__DisplayClass35_0 LBLMCMHMNGC; // 0x1C
		// public IMCBBOAFION BHFHGFKBOHH; // 0x20
		// private string BLOMMALFLCM; // 0x24
		// private GNMBAOKGJDO HCNDEJCCIMA; // 0x28
		// 0x9FF020

		//lambda 1 : 0x9FE328 // lambda 2 : 0x9FE334

		bool KOMKKBDABJP = false;
		bool CNAIDEAFAAM = false;
		BBGDKLLEPIB.HHCJCDFCLOB.PAHGEEOFEPM(() => { KOMKKBDABJP = true; }, () => { KOMKKBDABJP = true; CNAIDEAFAAM = true; }); //?? 0x101
		while(!KOMKKBDABJP)
		{
			yield return null;
		}
		if(CNAIDEAFAAM)
		{
			MOBEEPPKFLG();
        	UnityEngine.Debug.LogError("Exit  Error MHEKMICKGDM_LoadFromStorage");
			yield break;
		}

		string str = BBGDKLLEPIB.OGCDNCDMLCA; // mx install dir
		if(!string.IsNullOrEmpty(str))
		{
			if(!string.IsNullOrEmpty(BBGDKLLEPIB.HHCJCDFCLOB.OCOGBOHOGGE))
			{
				bool BEKAMBBOLBO = false;
				IIEDOGCMCIE GBEGLNMFLIE = new IIEDOGCMCIE();
				GBEGLNMFLIE.MCDJJPAKBLH(str + BBGDKLLEPIB.HHCJCDFCLOB.OCOGBOHOGGE);
				while(GBEGLNMFLIE.PLOOEECNHFB == false)
				{
					yield return null;
				}
				if(GBEGLNMFLIE.NPNNPNAIONN == true)
				{
					yield return N.a.StartCoroutine(LGFPCADOCAA_ShowError());
					MOBEEPPKFLG();
					GBEGLNMFLIE = null;
        			UnityEngine.Debug.LogError("Exit  Error MHEKMICKGDM_LoadFromStorage");
					yield break;
				}
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				CMFCGGAKLFN(GBEGLNMFLIE, time); // Read versions
				BBHOKHCDBFI(GBEGLNMFLIE); // Read Schedules
				List<OKGLGHCBCJP_Database.BEOKNKGHFFE_Section> list = NKEBMCIMJND_Database.BPCKOIDILDK_GetSectionsValid(JOBKIDDLCPL_ScheduleEvent, time);
				NKEBMCIMJND_Database.LNAKMLCCEJG_AddSections(list, OKGLGHCBCJP_Database.GAAEFILMAED_BaseSectionList);
				NKEBMCIMJND_Database.KHEKNNFCAOI_Init(list);
				bool HBODCMLFDOB = false;
				NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
					List<string> listStr = NKEBMCIMJND_Database.PKOJMBICNHH_GetBlockNames();
					HBODCMLFDOB = NKEBMCIMJND_Database.IIEMACPEEBJ(listStr, GBEGLNMFLIE);
					if(HBODCMLFDOB)
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
					BEKAMBBOLBO = true;
				});
				while(!BEKAMBBOLBO)
					yield return null;
				
				if(!HBODCMLFDOB)
				{
					yield return N.a.StartCoroutine(LGFPCADOCAA_ShowError());
					MOBEEPPKFLG();
        			UnityEngine.Debug.LogError("Exit  Error MHEKMICKGDM_LoadFromStorage");
					yield break;
				}
				
				if(MessageLoader.Instance != null)
				{
					MessageLoader.Instance.Request(GBEGLNMFLIE, MessageLoader.eSheet.common, 0);
					MessageLoader.Instance.Request(GBEGLNMFLIE, MessageLoader.eSheet.menu, 0);
					MessageLoader.Instance.Request(GBEGLNMFLIE, MessageLoader.eSheet.master, 0);
					for(int i = 4; i < 14; i++)
					{
						MessageLoader.Instance.Request(GBEGLNMFLIE, (MessageLoader.eSheet)i, 0);
					}
					Database.Instance.musicText.LoadFromTAR(GBEGLNMFLIE);
					Database.Instance.roomText.LoadFromBinaryTAR(GBEGLNMFLIE);
				}
				
				AMAFAKNIHFO();
				NKEBMCIMJND_Database.IDBDAPPJOND();
				KPKEOIJHIMN f = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.DAOHAKABAFG;
				f.FFEJIGPPHOA(BBGDKLLEPIB.LHJNPJFNDNA);
				string BLOMMALFLCM = BBGDKLLEPIB.OGCDNCDMLCA;
				BLOMMALFLCM = BLOMMALFLCM + BBGDKLLEPIB.JNPHAJICDPN;
				//new XeApp.Game.Net.Security.SecureGZFile
				GNMBAOKGJDO HCNDEJCCIMA = new GNMBAOKGJDO();
				HCNDEJCCIMA.MCDJJPAKBLH(BLOMMALFLCM);
				while(!HCNDEJCCIMA.PLOOEECNHFB)
				{
					yield return null;
				}
				if(File.Exists(BLOMMALFLCM))
				{
					UnityEngine.Debug.Log("Delete File "+BLOMMALFLCM);
					File.Delete(BLOMMALFLCM);
				}
				GCELJIDIGDG = HCNDEJCCIMA.IAKPCFDLMKP;
				if(!HCNDEJCCIMA.NPNNPNAIONN)
				{
					BLOMMALFLCM = null;
					HCNDEJCCIMA = null;
					bool LAB_00a0006c = false;
					if(!NAANHMNAHGI)
					{
						if(GCELJIDIGDG == null)
						{
							BEKAMBBOLBO = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => { // 0x9FE2CC
								BEKAMBBOLBO = true;
							}, "");
							while(!BEKAMBBOLBO)
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
										BEKAMBBOLBO = false;
										JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2D8
											BEKAMBBOLBO = true;
										}, "");
										while(!BEKAMBBOLBO)
										{
											yield return null;
										}
									}
									else if(!a.QTHZDMBR())
									{
										BEKAMBBOLBO = false;
										JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2E4
											BEKAMBBOLBO = true;
										}, "");
										while(!BEKAMBBOLBO)
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
									BEKAMBBOLBO = false;
									JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2F0
										BEKAMBBOLBO = true;
									}, "");
									while(!BEKAMBBOLBO)
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
							BEKAMBBOLBO = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2FC
								BEKAMBBOLBO = true;
							}, "");
							while(!BEKAMBBOLBO)
							{
								yield return null;
							}
						}
						else if(SecureLibAPI.isDebuggerAttachedNative())
						{
							BEKAMBBOLBO = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE308
								BEKAMBBOLBO = true;
							}, "");
							while(!BEKAMBBOLBO)
							{
								yield return null;
							}
						}
						else 
						{
							if(!SecureLibAPI.isEmulator())
							{
								if(BHFHGFKBOHH != null)
								{
									BHFHGFKBOHH();
									LNAHEIEIBOI_Initialized = true;
        							UnityEngine.Debug.Log("Exit MHEKMICKGDM_LoadFromStorage");
									yield break;
								}
							}
							BEKAMBBOLBO = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE314
								BEKAMBBOLBO = true;
							}, "");
							while(!BEKAMBBOLBO)
							{
								yield return null;
							}
						}
					}
				}
				else
				{
					BEKAMBBOLBO = false;
					JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2C0
						BEKAMBBOLBO = true;
					}, "");
					while(!BEKAMBBOLBO)
					{
						yield return null;
					}
				}
				MOBEEPPKFLG();
        		UnityEngine.Debug.LogError("Exit  Error MHEKMICKGDM_LoadFromStorage");
				yield break;
			}
		}
		yield return N.a.StartCoroutine(LGFPCADOCAA_ShowError());
		MOBEEPPKFLG();
        UnityEngine.Debug.LogError("Exit  Error MHEKMICKGDM_LoadFromStorage");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7760 Offset: 0x6B7760 VA: 0x6B7760
	// // RVA: 0x9FBCFC Offset: 0x9FBCFC VA: 0x9FBCFC
	private IEnumerator LGFPCADOCAA_ShowError()
	{
        UnityEngine.Debug.Log("Enter LGFPCADOCAA_ShowError");
		TodoLogger.Log(0, "TODO");
        UnityEngine.Debug.Log("Exit LGFPCADOCAA_ShowError");
		yield break;
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
		
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.CEEAFKHANJB(NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.KHGJIGNHAGD, NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.JOIEHMBKJHI_RetryWaitMs);
		//L54
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.BLFILNOBHMM = 0 < NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("action_revert_show_error", 0);
		if(!NKEBMCIMJND_Database.GDEKCOOBLMA_System.OHJFBLFELNK.ContainsKey(AFEHLCGHAEE_Strings.JJHDDBLNOHA_delay_install_autowait/*delay_install_autowait*/))
		{
			return;
		}
		KDLPEDBKMID.HHCJCDFCLOB.OIKLOJMPBGA(NKEBMCIMJND_Database.GDEKCOOBLMA_System.OHJFBLFELNK[AFEHLCGHAEE_Strings.JJHDDBLNOHA_delay_install_autowait/*delay_install_autowait*/].DNJEJEANJGL_Value);
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
		JOBKIDDLCPL_ScheduleEvent.Clear();
		CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File item = GBEGLNMFLIE.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File GHPLINIACBB) => {
			//0x9FDD4C 
			return GHPLINIACBB.OPFGFINHFCE_Name.Contains("schedule");
		});
		if(item != null)
		{
			if(item.OPFGFINHFCE_Name.Contains(".bytes"))
			{
				IOBIKMEGCAL data = IOBIKMEGCAL.HEGEKFMJNCC(item.DBBGALAPFGC_Data);
				DMABOGLGILJ[] schedule_item = data.IHMCKPOIBDA;
				for(int i = 0; i < schedule_item.Length; i++)
				{
					GDIPLANPCEI info = new GDIPLANPCEI();
					info.OPFGFINHFCE_Name = schedule_item[i].OPFGFINHFCE;
					info.KBFOIECIADN_OpenedAt = schedule_item[i].KBFOIECIADN;
					info.EGBOHDFBAPB_ClosedAt = schedule_item[i].EGBOHDFBAPB;
					JOBKIDDLCPL_ScheduleEvent.Add(info);
				}
			}
			else if(item.OPFGFINHFCE_Name.Contains(".json"))
			{
				TodoLogger.Log(0, "TODO");
				//schedules
				//name
				//opened_at
				//closed_at
			}
		}
	}

	// // RVA: 0x9FCE3C Offset: 0x9FCE3C VA: 0x9FCE3C
	// public bool JMAMHEJDNNN(long JHNMKKNEENE) { }

	// // RVA: 0x9FCF88 Offset: 0x9FCF88 VA: 0x9FCF88
	private void CMFCGGAKLFN(CBBJHPBGBAJ_Archive GBEGLNMFLIE, long JHNMKKNEENE_Time)
	{
		
	// public static readonly IMMAOANGPNK.<>c <>9; // 0x0
	// public static Predicate<CBBJHPBGBAJ.JBCFNCNGLPM> <>9__42_0; // 0x4
	// public static Predicate<CBBJHPBGBAJ.JBCFNCNGLPM> <>9__44_0; // 0x8
	// public static Comparison<IMMAOANGPNK.MPFFINOMILP> <>9__44_1; // 0xC
		MGFBEKNMJOA.Clear();
		
		CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File res = GBEGLNMFLIE.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File GHPLINIACBB) => { return GHPLINIACBB.OPFGFINHFCE_Name.Contains("version.bytes"); }); // 0x9FDDD8
		if(res != null)
		{
			IDEELDJLDBN a = IDEELDJLDBN.HEGEKFMJNCC(res.DBBGALAPFGC_Data);
			JGIHJPPECBB[] b = a.MLOPDBGPLFI;
			IMMAOANGPNK.MPFFINOMILP obj = null;
			for(int i = 0; i < b.Length; i++)
			{
				int val = b[i].BEBJKJKBOGH;
				if(val < JHNMKKNEENE_Time)
				{
					if(obj != null)
					{
						if(val < obj.PDBPFJJCADD)
						{
							continue;
						}
					}
					obj = new IMMAOANGPNK.MPFFINOMILP();
					obj.OPFGFINHFCE = b[i].OPFGFINHFCE;
					obj.PDBPFJJCADD = val;
					obj.IJEKNCDIIAE = b[i].IJEKNCDIIAE;
				}
				else
				{
					IMMAOANGPNK.MPFFINOMILP obj2 = new IMMAOANGPNK.MPFFINOMILP();
					obj2.OPFGFINHFCE = b[i].OPFGFINHFCE;
					obj2.PDBPFJJCADD = val;
					obj2.IJEKNCDIIAE = b[i].IJEKNCDIIAE;
					MGFBEKNMJOA.Add(obj2);
				}
			}
			if(obj != null)
			{
				MGFBEKNMJOA.Add(obj);
			}
			
			MGFBEKNMJOA.Sort((IMMAOANGPNK.MPFFINOMILP HKICMNAACDA, IMMAOANGPNK.MPFFINOMILP BNKHBCBJBKI) => {
				//0x9FDE64 
				return HKICMNAACDA.PDBPFJJCADD.CompareTo(BNKHBCBJBKI.PDBPFJJCADD);
			});
			if(MGFBEKNMJOA.Count > 0)
			{
				IMMAOANGPNK.MPFFINOMILP item = MGFBEKNMJOA[0];
				if(item.PDBPFJJCADD < JHNMKKNEENE_Time)
				{
					DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion = item.IJEKNCDIIAE;
					object[] strData = new object[4];
					strData[0] = "mver= ";
					strData[1] = item.IJEKNCDIIAE;
					strData[2] = ",name=";
					strData[3] = item.OPFGFINHFCE;
					UnityEngine.Debug.Log(string.Concat(strData));
				}
			}
		}
	}

	// // RVA: 0x9FD930 Offset: 0x9FD930 VA: 0x9FD930
	// public bool MKINIELBKEK(long JHNMKKNEENE) { }
}
