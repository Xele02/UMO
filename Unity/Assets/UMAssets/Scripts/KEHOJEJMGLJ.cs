using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using XeSys;
using System.IO;
using XeApp.Game;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using XeApp.Game.Common;
using System.Collections.Specialized;

//namespace XeApp.Game.Net.Install
[System.Obsolete()]
public class KEHOJEJMGLJ {}
public class KEHOJEJMGLJ_NetInstallManager
{

	private enum LIFANPDHNHE
	{
		FKPEAGGKNLC_0_Start = 0,
		MJKPBANHCOE = 1,
		KBMHDBKJKEO = 2,
		KHLKPDFNABB = 3,
		FCIFGLGBCEO = 4,
		FFBGDIFGJJF = 5,
		CIIBCAIHOBG = 6,
		OPPCNLGJDBJ = 7,
		PBGLLFHFFLF = 8,
		CEAKNCGBLGO = 9,
		HGLCABLHPAP = 10,
		KOKOCMNDHBB = 11,
		HIMAJCDOMFG = 12,
		OFFIEHJKEOO = 13,
		IMMACKJJDOM = 14,
		CDGFOMPKJON = 15,
		KPGBOHOHFCI = 16,
		KIIGNCNANOH = 17,
		DIPMILDNFJJ = 18,
		BBBLDKGNCLH = 19,
		KEJKHGHFBLH = 20,
		JFILOMCKGKA = 21,
		EPMDKGPMOFN = 22,
		DCECAAAFEDP = 23,
		EOELNFLLEDJ = 24,
	}

	public enum ACGGHEIMPHC
	{
		ANFKBNLLJFN_0 = 0,
		GGCIMLDFDOC = 1,
		DEKNOKPEIHO_2 = 2,
	}
	
	public class FDICFBNIPAJ
	{
		public int KKPAHLMJKIH_WavId; // 0x8
		public long DGGFLBJBLLN; // 0x10
		public List<string> IBGNDNLAHOE = new List<string>(2); // 0x18
	}

	private float NDEJCDBHPLB = 180.0f; // 0x8
	private const bool LFNLMBBPMPJ = false;
	public FECDBKKBAHO KLIJFOBEKBE = new FECDBKKBAHO(); // 0xC
	public OAFCKDDEBFN GMLCCMEHNCI = new OAFCKDDEBFN(); // 0x10
	private static IGJHFKELHKJ MLPDBGFBAAC; // 0x4
	public static bool HBCEEIOHENM = true; // 0x8
	public KEHOJEJMGLJ_NetInstallManager.ACGGHEIMPHC EMJFHKHLHDB = KEHOJEJMGLJ_NetInstallManager.ACGGHEIMPHC.GGCIMLDFDOC/*1*/; // 0x14
	// private static string[] EENNDMBAGNC = new string[1] {"android"}; // 0xC
	private static string IMABJMPEPGE_PlatformPrefix; // 0x18
	private static string JCMJBMBMJAK_PersistentDataPath = null; // 0x1C
	private static string PMHFLOLDHAO_PersistentPlatformDataPath = null; // 0x20
	public DJBHIFLHJLK FGGJNGCAFGK; // 0x24
	public List<string> FBGNDKKDOIE = null; // 0x28
	private JEHIAIPJNJF_FileDownloader PMDNNKAPIKJ_FileDownloader; // 0x2C
	public static bool FJDOHLADGFI; // 0x28 // Set for now to force CRC recheck
	public IKAHKDKIGNA IDJBKGBMDAJ; // 0x30
	private List<GCGNICILKLD_AssetFileInfo> ICCMKHKNAMJ_ToDldList; // 0x34
	private static DateTime CBHCDLLOBBK = new DateTime(1970, 1, 1, 0, 0, 0, 1, 0); // 0x30
	private const int AJCPBLIKDGB = 1;
	private const int FAHBCEJNLJD = 2;
	private const int KBBOBCJFFGI = 3;
	private const int ICACBMLDEAG = 4;
	private const int HEDNPEJAEBH = 2;
	private long DMPNAEEIANJ; // 0x38
	private bool PICLIFPDEOF; // 0x40
	private int HGOIEGFBABK = 5; // 0x44
	private int PAIGMDNFNDJ; // 0x48
	private int NFIDKHELFDK; // 0x4C
	private int INAEAAJIJMF; // 0x50
	private long GCLPIJNJFAE_ElapsedTime; // 0x58
	private int KIEBFLDPBPA; // 0x60
	private bool DLAEPJPPEKI; // 0x64
	public bool PBAHJENPLFM; // 0x65

	public static KEHOJEJMGLJ_NetInstallManager HHCJCDFCLOB_Instance { get; private set; } // 0x0 LGMPACEDIJF_bgs NKACBOEHELJ_bgs OKPMHKNCNAL_bgs
	// public static bool ONMPNMJCAAD { get; } // KFHIFNBPANF_bgs 0xE87C94
	public static string FLHOFIEOKDH_BaseUrl { get; set; } // 0x10 PGOHBLKDJOM_bgs ODMAEKMPAGP_bgs BBPOAGDNMOJ_bgs
	public static string JNGKCPJBMBA_ServerPlatformUrl { get; set; } // 0x14 BMIJOIFPCCE_bgs KEOJOEFBBJE_bgs FMEBBKPCEPK_bgs
	public string FPCIBJLJOFI_Type { get; set; } // 0x18 LCFILOOJABA_bgs NOJDHDJNPAL_bgs IHJLOEIKMDI_bgs
	public static string LBEPLOJBFCM_PlatformPrefix { 
		get { // KHCOOFHPKGE_bgs 0xE7E984
			if(IMABJMPEPGE_PlatformPrefix == null)
			{
				IMABJMPEPGE_PlatformPrefix = "android";
			}
			return IMABJMPEPGE_PlatformPrefix;
		}
	} 
	public static string OGCDNCDMLCA_LocalPath { get {
		// FHOCCNDOAPJ_bgs 0xE7EB1C
		if(JCMJBMBMJAK_PersistentDataPath == null)
		{
			string path = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath;
			if(string.IsNullOrEmpty(path))
				TodoLogger.LogError(TodoLogger.Filesystem, "Install.InstallPathManager.CriWare_installTargetPath is null");
			JCMJBMBMJAK_PersistentDataPath = path + "/data";
		}
        return JCMJBMBMJAK_PersistentDataPath;
	}}
	public static string CGAHFOBGHIM_PersistentPlatformDataPath { 
		get { // AMBIPPMFFCJ_bgs 0xE7DF14
			if(PMHFLOLDHAO_PersistentPlatformDataPath == null)
			{
				PMHFLOLDHAO_PersistentPlatformDataPath = OGCDNCDMLCA_LocalPath + "/" + LBEPLOJBFCM_PlatformPrefix;
			}
			return PMHFLOLDHAO_PersistentPlatformDataPath;
		}
	}
	public static string LHJNPJFNDNA_Rev { get; private set; } // 0x24 HCGGEEMOKFN_bgs JBIPCECPFGN_bgs ONAJIIACAEB_bgs
	public OMIFMMJPMDJ OEPPEGHGNNO { get; set; } // 0x1C KPEKONPJHCL_bgs LKCDOGAFPNM_bgs NPJJMDFAIII_bgs
	public OBHIGCFPKJN MAIHLKPEHJN { get; set; } // 0x20 EAIFOAGPGGH_bgs KCLBNOKEPIG_bgs OCIMGEFKKLM_bgs

	public bool Unused() { return NDEJCDBHPLB == 0; }

	// // RVA: 0xE87F08 Offset: 0xE87F08 VA: 0xE87F08
	public void IJBGPAENLJA_OnAwake(MonoBehaviour _DANMJLOBLIE_mb)
	{
		HHCJCDFCLOB_Instance = this;
		KLIJFOBEKBE.KHEKNNFCAOI_Init();
		FileLoader.Instance.findDecryptor = GMLCCMEHNCI.MFHAOMELJKJ_FindDecryptor;
		GMLCCMEHNCI.ALLGKHCNKDN();
		MLPDBGFBAAC = new IGJHFKELHKJ();
		OMPMGDHJJPG();
	}

	// // RVA: 0xE882B8 Offset: 0xE882B8 VA: 0xE882B8 Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0xE88334 Offset: 0xE88334 VA: 0xE88334
	/*private void FCPBCDOKOPD(LIFANPDHNHE _PPFNGGCBJKC_id, string _IPBHCLIHAPG_Msg)
	{
	}*/

	// // RVA: 0xE883AC Offset: 0xE883AC VA: 0xE883AC
	public void OFLDICKPNFD(bool CJPFICKPJPP, DJBHIFLHJLK FGGJNGCAFGK)
	{
		if(CJPFICKPJPP)
		{
			MAIHLKPEHJN = JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.DOHNKJKOGFJ;
		}
		else
		{
			MAIHLKPEHJN = this.EEHMGCMAOAB;
		}
		this.FGGJNGCAFGK = FGGJNGCAFGK;
	}

	// // RVA: 0xE884B4 Offset: 0xE884B4 VA: 0xE884B4
	public void PAHGEEOFEPM_Install(KEHOJEJMGLJ_NetInstallManager.ACGGHEIMPHC _INDDJNMPONH_type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, int INAEAAJIJMF/* = 0*/, long _GCLPIJNJFAE_ElapsedTime/* = 0*/)
	{
		GMLCCMEHNCI.PGLANLKJBLI_Init();
		this.GCLPIJNJFAE_ElapsedTime = _GCLPIJNJFAE_ElapsedTime;
		this.INAEAAJIJMF = INAEAAJIJMF;
		KIEBFLDPBPA = 0;
		if(MLPDBGFBAAC == null)
		{
			MLPDBGFBAAC = new IGJHFKELHKJ();
		}
		if(MLPDBGFBAAC != null)
		{
			MLPDBGFBAAC.PCODDPDFLHK_Load();
			if(_INDDJNMPONH_type == /*2*/KEHOJEJMGLJ_NetInstallManager.ACGGHEIMPHC.DEKNOKPEIHO_2)
			{
				MLPDBGFBAAC.PNMIOGBPDFN();
			}
		}
		LHJNPJFNDNA_Rev = null;
		if(EMJFHKHLHDB == _INDDJNMPONH_type && _INDDJNMPONH_type != 0)
		{
			if(_INDDJNMPONH_type == KEHOJEJMGLJ_NetInstallManager.ACGGHEIMPHC.GGCIMLDFDOC/*1*/)
			{
				GBCDHECMDMC();
			}
		}
		else
		{
			LHJNPJFNDNA_Rev = null;
		}
		EMJFHKHLHDB = _INDDJNMPONH_type;
		FPCIBJLJOFI_Type = "android";
		JCMJBMBMJAK_PersistentDataPath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/data";
		//FCPBCDOKOPD(,null); ???
		N.a.StartCoroutineWatched(EOFJPNPFGDM_Coroutine_Install(_BHFHGFKBOHH_OnSuccess,_MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BB624 Offset: 0x6BB624 VA: 0x6BB624
	// // RVA: 0xE88C70 Offset: 0xE88C70 VA: 0xE88C70
	private IEnumerator EOFJPNPFGDM_Coroutine_Install(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		// public DJBHIFLHJLK MOBEEPPKFLG_OnFail; // 0x1C
		// public IMCBBOAFION BHFHGFKBOHH_OnSuccess; // 0x20
		// private bool NGDBJIAFCKE; // 0x2C
		// private PJKLMCGEJMK_NetActionManager JFAIABBIPEO; // 0x30
		// private LFPOMKLKHPB_InstallFileSize NOAMCCLDODN; // 0x34
		// private int NJDHMNBBCLK; // 0x38
		//0xE8DA10

		int NJDHMNBBCLK = 0;
		// private KEHOJEJMGLJ_NetInstallManager.<>c__DisplayClass75_0 OPLBFCEPDCH; // 0x14
			// public KEHOJEJMGLJ_NetInstallManager KIGBLACMODG; // 0x8
			// public bool KOMKKBDABJP_end; // 0xC
		if(OEPPEGHGNNO == null)
		{
			OEPPEGHGNNO = this.ALDMHFCFECK;
		}
		if(MAIHLKPEHJN == null)
		{
			MAIHLKPEHJN = this.EEHMGCMAOAB;
		}
		//FCPBCDOKOPD?
		KLIJFOBEKBE.PCODDPDFLHK_Load();
		DMPNAEEIANJ = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		if(GCLPIJNJFAE_ElapsedTime == 0)
		{
			GCLPIJNJFAE_ElapsedTime = DMPNAEEIANJ;
		}
		DLAEPJPPEKI = true;
		bool NGDBJIAFCKE = false;
		FFHCCIOCPAD();
		PJKLMCGEJMK_NetActionManager JFAIABBIPEO = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		//goto LAB_00e8e258;
		while(true)
		{

			// private KEHOJEJMGLJ_NetInstallManager.<>c__DisplayClass75_1 LBLMCMHMNGC; // 0x18
				// public Dictionary<string, int> FAOOOLDDBBB_LocalFilesStatus; // 0x8
				// public JPAPJLIPNOK_RequestAssetList COJNCNGHIJC_Req; // 0xC
				// public KEHOJEJMGLJ_NetInstallManager.<>c__DisplayClass75_0 PGFMIBMJBHD; // 0x10
				// RVA: 0xE8CE74 Offset: 0xE8CE74 VA: 0xE8CE74
				// internal void IPGJJANJOMJ() { }
				// // RVA: 0xE8D3C0 Offset: 0xE8D3C0 VA: 0xE8D3C0
				// internal void EGDGJOPDNFF() { }
				// // RVA: 0xE8D424 Offset: 0xE8D424 VA: 0xE8D424
				// internal void FKJIINPOGKK(JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo JGBPLIGAILE) { }
				// // RVA: 0xE8D8B0 Offset: 0xE8D8B0 VA: 0xE8D8B0
				// internal void BCMEPPIPGIB() { }

			//FCPBCDOKOPD?
			JPAPJLIPNOK_RequestAssetList COJNCNGHIJC_Req = JFAIABBIPEO.IFFNCAFNEAG_AddRequest<JPAPJLIPNOK_RequestAssetList>(new JPAPJLIPNOK_RequestAssetList());
			COJNCNGHIJC_Req.FPCIBJLJOFI_Type = FPCIBJLJOFI_Type;
			yield return COJNCNGHIJC_Req.GDPDELLNOBO_WaitDone(N.a);
			//1

			if(COJNCNGHIJC_Req.NPNNPNAIONN_IsError)
			{
				if(_MOBEEPPKFLG_OnFail != null)
				{
					_MOBEEPPKFLG_OnFail();
				}
				//FCPBCDOKOPD?
				TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error EOFJPNPFGDM_Coroutine_Install");
				yield break;
			}

			IDJBKGBMDAJ = COJNCNGHIJC_Req.NFEAMMJIMPG_Result;
			FLHOFIEOKDH_BaseUrl = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.GLMGHMCOMEC_base_url;
			JNGKCPJBMBA_ServerPlatformUrl = FLHOFIEOKDH_BaseUrl + AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash + LBEPLOJBFCM_PlatformPrefix + AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash;

			DMPNAEEIANJ = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			//FCPBCDOKOPD()?
			if(EMJFHKHLHDB == KEHOJEJMGLJ_NetInstallManager.ACGGHEIMPHC.DEKNOKPEIHO_2/*2*/)
			{
				if(_BHFHGFKBOHH_OnSuccess != null)
				{
					_BHFHGFKBOHH_OnSuccess();
				}
				//FCPBCDOKOPD?
			}
			else
			{
				if(LHJNPJFNDNA_Rev != COJNCNGHIJC_Req.HOHOBEOJPBK_ServerInfo.AJBPBEALBOB_SakashoCurrentAssetRevision)
				{
					Dictionary<string, int> FAOOOLDDBBB_LocalFilesStatus;
					bool KOMKKBDABJP_end;
					List<GCGNICILKLD_AssetFileInfo> listToCheck = null;
					LFPOMKLKHPB_InstallFileSize NOAMCCLDODN;
					while(true)
					{
						ICCMKHKNAMJ_ToDldList = new List<GCGNICILKLD_AssetFileInfo>();
						FAOOOLDDBBB_LocalFilesStatus = new Dictionary<string, int>();
						KOMKKBDABJP_end = false;
						GameManager.Instance.NowLoading.Show();

						TextContent content = null;
						PopupWindowControl control = null;
						if(listToCheck == null)
						{
							listToCheck = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.KGHAJGGMPKL_files;
						}
						if(FJDOHLADGFI)
						{
							bool shown = false;
							control = PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Integrity Check", SizeType.Small, "Checking files : 0/"+listToCheck.Count, new ButtonInfo[0], false, true), null, null, null, () =>
							{
								shown = true;
							}, true, true, false, null, null, null, null, null);
							while(!shown)
								yield return null;
							content = control.Content as TextContent;
						}
						float t = Time.realtimeSinceStartup;
						int cnt = 0;

						JFAIABBIPEO.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
							//0xE8CE74
							//FCPBCDOKOPD?
							KLIJFOBEKBE.EBCAKALIAHH_RemoveExpiredSongs();
							PAIGMDNFNDJ = 0;
							DIDACHONHJA_ListExistingFiles(ref FAOOOLDDBBB_LocalFilesStatus, JCMJBMBMJAK_PersistentDataPath);
							string[] str = new string[5];
							str[0] = ""+listToCheck.Count;
							str[1] = ",installed=";
							str[2] = ""+PAIGMDNFNDJ;
							str[3] = ",timestamp=";
							str[4] = ""+0;
							UnityEngine.Debug.Log(string.Concat(str));
							//FCPBCDOKOPD
							NFIDKHELFDK = 0;
							IAPEABPJPOE(listToCheck, ref FAOOOLDDBBB_LocalFilesStatus, ref cnt);
							BEINKAGIHJB_CheckMediaFile();
							KOMKKBDABJP_end = true;
						});
						//goto LAB_00e8dd6c;
						//2
						while(KOMKKBDABJP_end == false)
						{
							yield return null;
							if(FJDOHLADGFI && Time.realtimeSinceStartup - t > 1 && COJNCNGHIJC_Req.NFEAMMJIMPG_Result != null && COJNCNGHIJC_Req.NFEAMMJIMPG_Result.KGHAJGGMPKL_files != null)
							{
								t = Time.realtimeSinceStartup;
								content.SetText(string.Format("Checking files : {0}/{1}\nFiles to fix : {2}", cnt, listToCheck.Count, ICCMKHKNAMJ_ToDldList.Count));
							}
						}
						GameManager.Instance.NowLoading.Hide();
						if(FJDOHLADGFI)
						{
							control.Close(null, null);
						}

						//FCPBCDOKOPD?
						DLAEPJPPEKI = false;
						// L 482
						//*************
						TodoLogger.LogError(TodoLogger._Todo, "Todo File on disk check");
	#if !UNITY_ANDROID && !DEBUG_ANDROID_FILESYSTEM
						ICCMKHKNAMJ_ToDldList.Clear();// UMO hack, not file check for now on editor, all files are here.
	#endif
						//*************
						if (ICCMKHKNAMJ_ToDldList.Count == 0)
						{
							KOMKKBDABJP_end = false;
							JFAIABBIPEO.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
								//0xE8D3C0
								TodoLogger.LogError(TodoLogger._Todo, "Disabled file deletion");
								//CIDPPOGCODB(FAOOOLDDBBB_LocalFilesStatus);
								KOMKKBDABJP_end = true;
							});
							//goto LAB_00e8eab0;
							//3
							//LAB_00e8eab0:
							while(!KOMKKBDABJP_end)
							{
								yield return null;
							}
							LHJNPJFNDNA_Rev = COJNCNGHIJC_Req.HOHOBEOJPBK_ServerInfo.AJBPBEALBOB_SakashoCurrentAssetRevision;
							if(MLPDBGFBAAC != null)
							{
								MLPDBGFBAAC.HJMKBCFJOOH_Save();
							}
							if(EMJFHKHLHDB == KEHOJEJMGLJ_NetInstallManager.ACGGHEIMPHC.GGCIMLDFDOC/*1*/)
							{
								PKLPEIBEGNO();
							}
							ICCMKHKNAMJ_ToDldList.Clear();
							KLIJFOBEKBE.HJMKBCFJOOH_Save();
							KDHNLDOIOAL();
							GC.Collect();
							GameManager.Instance.SetNeverSleep(false);
							if(OEPPEGHGNNO(4, 0))
								OEPPEGHGNNO(2, 100);
							//FCPBCDOKOPD
							if(_BHFHGFKBOHH_OnSuccess != null)
							{
								_BHFHGFKBOHH_OnSuccess();
							}
							//goto LAB_00e8f334;
							FBGNDKKDOIE = null;
							yield break;
						}
						listToCheck = ICCMKHKNAMJ_ToDldList;
						// L518
						GameManager.Instance.SetNeverSleep(true);
						NOAMCCLDODN = new LFPOMKLKHPB_InstallFileSize();
						NOAMCCLDODN.LKLCOEJLBGG();
						//break;
						while (!NOAMCCLDODN.PLOOEECNHFB_IsDone)
						{
							yield return null;
						}

						NOAMCCLDODN.NKIKBOJOCNN_ShowInstallFileSize(ICCMKHKNAMJ_ToDldList);
						//LAB_00e8e7d8
						while(!NOAMCCLDODN.PLOOEECNHFB_IsDone)
						{
							yield return null;
							// To 5
							//5
						}

						if(NOAMCCLDODN.AAAOKDDILCP_IsError)
						{
							if(_MOBEEPPKFLG_OnFail != null)
							{
								_MOBEEPPKFLG_OnFail();
							}
							TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error EOFJPNPFGDM_Coroutine_Install");
							yield break;
						}

#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
						bool retry = false;
						FJDOHLADGFI = true;
						yield return Co.R(FileSystemProxy.WaitServerInfo("Missing "+ICCMKHKNAMJ_ToDldList[0].OIEAICNAMNB_LocalFileName+(ICCMKHKNAMJ_ToDldList.Count > 1 ? " + "+(ICCMKHKNAMJ_ToDldList.Count - 1)+" files" : "") + " in "+JCMJBMBMJAK_PersistentDataPath, true, true, (PopupButton.ButtonLabel btn) =>
						{
							if(btn == PopupButton.ButtonLabel.Retry)
								retry = true;
						}));
						if(retry)
							continue;
#endif

						OEPPEGHGNNO(1, 0);
						//LAB_00e8e87c:
						while(!OEPPEGHGNNO(4, 0))
						{
							yield return null;
							// to 6
							//6
						}
						PMDNNKAPIKJ_FileDownloader = new JEHIAIPJNJF_FileDownloader(3);
						PMDNNKAPIKJ_FileDownloader.DOMFHDPMCCO_Init(ICCMKHKNAMJ_ToDldList, FLHOFIEOKDH_BaseUrl, JCMJBMBMJAK_PersistentDataPath);
						PMDNNKAPIKJ_FileDownloader.LBGNKOJFOFC = (JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo JGBPLIGAILE) => {
							//0xE8D424
							GFOMKMANCPP(JGBPLIGAILE.ADHHKEMDOIK_LocalPath, JGBPLIGAILE.LAPFOLJGJMB_AssetFileInfo.CALJIGKCAAH_last_updated_at, JGBPLIGAILE.LAPFOLJGJMB_AssetFileInfo.HHPEMFKDHLK_Hash, true);
							FAOOOLDDBBB_LocalFilesStatus[JGBPLIGAILE.LAPFOLJGJMB_AssetFileInfo.OIEAICNAMNB_LocalFileName] = 2;
							DMPNAEEIANJ = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							PKKHIEAEDPC p = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.NBHDIKJMLEN(JGBPLIGAILE.AJPIGKBIDDL_LocalFileName);
							if(p != null)
							{
								if(p.NKGJOAEDCPH_rule.PAAPNEMBHGN_Day > 0)
								{
									KLIJFOBEKBE.OJCJPCHFPGO_Delete(JGBPLIGAILE.AJPIGKBIDDL_LocalFileName);
									FECDBKKBAHO.FHOPNIJCFKA_FileInfo f = KLIJFOBEKBE.ANIJHEBLMGB_SetValue(JGBPLIGAILE.AJPIGKBIDDL_LocalFileName, DMPNAEEIANJ, p.KKPAHLMJKIH_WavId);
									f.FNALNKKMKDC_ExpireTime = DMPNAEEIANJ + 86400 * p.NKGJOAEDCPH_rule.PAAPNEMBHGN_Day;
									f.GEJJEDDEPMI = p.NKGJOAEDCPH_rule.PEOIMDCECDL;
								}
							}
						};
						NJDHMNBBCLK = 60;
						// goto LAB_00e8f360
						//LAB_00e8f360:
						PMDNNKAPIKJ_FileDownloader.LAOEGNLOJHC_Start();
						bool isretry = false;
						while(true)
						{
							if(isretry)
								break;
							//LAB_00e8f368
							yield return null;
							//To 7
							//7
							PMDNNKAPIKJ_FileDownloader.FBANBDCOEJL_Update();
							if(PMDNNKAPIKJ_FileDownloader.CMCKNKKCNDK_status == JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.FEJIMBDPMKI_2_Success/*2*/)
							{
								OEPPEGHGNNO(3, 100);
								PMDNNKAPIKJ_FileDownloader.Dispose();
								PMDNNKAPIKJ_FileDownloader = null;
								BDGGNOAIIFK(100);
								OEPPEGHGNNO(3, 100);
								GameManager.Instance.SetNeverSleep(false);
								KOMKKBDABJP_end = false;
								JFAIABBIPEO.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
									//0xE8D8B0
									CIDPPOGCODB(FAOOOLDDBBB_LocalFilesStatus);
									KOMKKBDABJP_end = true;
								});
								//goto LAB_00e8e0f8;
								//0xd
								//LAB_00e8e0f8
								while(!KOMKKBDABJP_end)
									yield return null;
								KLIJFOBEKBE.HJMKBCFJOOH_Save();
								GC.Collect();
								NGDBJIAFCKE = true;
								LHJNPJFNDNA_Rev = COJNCNGHIJC_Req.HOHOBEOJPBK_ServerInfo.AJBPBEALBOB_SakashoCurrentAssetRevision;
								if(EMJFHKHLHDB == KEHOJEJMGLJ_NetInstallManager.ACGGHEIMPHC.GGCIMLDFDOC/*1*/)
								{
									PKLPEIBEGNO();
								}
								NOAMCCLDODN = null;
								//LAB_00e8e258:
								isretry = true; // Force a recheck on downloaded files directly
								break;
							}
							//L731
							if(PMDNNKAPIKJ_FileDownloader.CMCKNKKCNDK_status == JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LPLEIJIFOKN_4_AllError/*4*/)
							{
								// private KEHOJEJMGLJ_NetInstallManager.<>c__DisplayClass75_2 PHPPCOBECCA; // 0x24
									// public int APGOAMNGFFF; // 0x8
									// // RVA: 0xE8D91C Offset: 0xE8D91C VA: 0xE8D91C
									// internal void EKHEBHFBKID() { }
									// // RVA: 0xE8D928 Offset: 0xE8D928 VA: 0xE8D928
									// internal void OIIFKBGOJKO() { }
								int APGOAMNGFFF = 0;
								string errorStr = "network";
								if(PMDNNKAPIKJ_FileDownloader.BHICPONFJKM_SpaceError)
									errorStr = "storage";
								int avaiable = StorageSupport.GetAvailableStorageSizeMB();
								if(avaiable > -1 && avaiable < 50)
									errorStr = "storage";
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
								if(errorStr == "storage")
								{
#endif
									MAIHLKPEHJN(errorStr, () => {
										//0xE8D91C
										APGOAMNGFFF = 1;
									}, () => {
										//0xE8D928
										APGOAMNGFFF = -1;
									});
									//goto LAB_00e8dffc;
									// 8
									while(APGOAMNGFFF == 0)
										yield return null;
									if(APGOAMNGFFF != 1)
									{
										// LAB_00e8f30c;
										PMDNNKAPIKJ_FileDownloader.Dispose();
										PMDNNKAPIKJ_FileDownloader = null;
										if(FGGJNGCAFGK != null)
											FGGJNGCAFGK();
										//LAB_00e8f334
										FBGNDKKDOIE = null;
										TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error EOFJPNPFGDM_Coroutine_Install");
										yield break;
									}
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
								}
								else
								{
									yield return Co.R(FileSystemProxy.WaitServerInfo("Missing files.", false, true, (PopupButton.ButtonLabel btn) =>
									{
									}));
								}
#endif
								PMDNNKAPIKJ_FileDownloader.PBIMGBKLDPP_Reset();
								//goto LAB_00e8e088;
								//9
								while(PMDNNKAPIKJ_FileDownloader.CMCKNKKCNDK_status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_0_Reset)
								{
									PMDNNKAPIKJ_FileDownloader.FBANBDCOEJL_Update();
									yield return null;
								}
								//goto LAB_00e8f360;
								PMDNNKAPIKJ_FileDownloader.LAOEGNLOJHC_Start();
								continue;
							}
							// L.780
							OEPPEGHGNNO(3, PMDNNKAPIKJ_FileDownloader.HCAJCKCOCHC());
							BDGGNOAIIFK(PMDNNKAPIKJ_FileDownloader.HCAJCKCOCHC());
							if(PMDNNKAPIKJ_FileDownloader.MNFGKBAEFFL_IsTimeout() || PMDNNKAPIKJ_FileDownloader.KAMPHNKAHAB_IsDiskFull)
							{
								//LAB_00e8f064:
								PMDNNKAPIKJ_FileDownloader.PBIMGBKLDPP_Reset();
								//goto LAB_00e8f0a4;
								//LAB_00e8f0a4:
								while(PMDNNKAPIKJ_FileDownloader.CMCKNKKCNDK_status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_0_Reset/*0*/)
								{
									PMDNNKAPIKJ_FileDownloader.FBANBDCOEJL_Update();
									yield return null;
								}
								int APGOAMNGFFF = 0;
								string errorStr = "network";
								if(PMDNNKAPIKJ_FileDownloader.KAMPHNKAHAB_IsDiskFull)
								{
									errorStr = "storage";
								}
								int avaiable = StorageSupport.GetAvailableStorageSizeMB();
								if(avaiable > -1 && avaiable < 50)
									errorStr = "storage";
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
								if(errorStr == "storage")
								{
#endif
									MAIHLKPEHJN(errorStr, () => {
										//0xE8D93C
										APGOAMNGFFF = 1;
									}, () => {
										//0xE8D948
										APGOAMNGFFF = -1;
									});
									//goto LAB_00e8f260;
									//0xb
									while(APGOAMNGFFF == 0)
										yield return null;
									if(APGOAMNGFFF != 1)
									{
										//LAB_00e8f30c:
										PMDNNKAPIKJ_FileDownloader.Dispose();
										PMDNNKAPIKJ_FileDownloader = null;
										if(FGGJNGCAFGK != null)
											FGGJNGCAFGK();
										//LAB_00e8f334
										FBGNDKKDOIE = null;
										TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error EOFJPNPFGDM_Coroutine_Install");
										yield break;
									}
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
								}
								else
								{
									yield return Co.R(FileSystemProxy.WaitServerInfo("Missing files.", false, true, (PopupButton.ButtonLabel btn) =>
									{
									}));
								}
#endif
								PMDNNKAPIKJ_FileDownloader.PBIMGBKLDPP_Reset();
								//LAB_00e8f2d0:
								while(PMDNNKAPIKJ_FileDownloader.CMCKNKKCNDK_status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_0_Reset/*0*/)
								{
									PMDNNKAPIKJ_FileDownloader.FBANBDCOEJL_Update();
									//LAB_00e8f2fc:
									yield return null;
									// 0xc
									//goto LAB_00e8f2d0
								}
								//goto LAB_00e8f360;
								PMDNNKAPIKJ_FileDownloader.LAOEGNLOJHC_Start();
								continue;
							}
							NJDHMNBBCLK = NJDHMNBBCLK - 1;
							if(NJDHMNBBCLK < 0)
							{
								GC.Collect();
								NJDHMNBBCLK = 60;
							}
							//goto LAB_00e8f368;
							continue;
						}
						if(isretry)
							continue;
						//L 380
						if(NGDBJIAFCKE)
						{
							OEPPEGHGNNO(2, 100);
						}
						GC.Collect();
						if(_BHFHGFKBOHH_OnSuccess != null)
						{
							_BHFHGFKBOHH_OnSuccess();
						}
						//FCPBCDOKOPD
						if(MLPDBGFBAAC != null)
						{
							if(DLAEPJPPEKI)
							{
								MLPDBGFBAAC.PNMIOGBPDFN();
							}
							MLPDBGFBAAC.HJMKBCFJOOH_Save();
						}
						if(ICCMKHKNAMJ_ToDldList != null)
						{
							ICCMKHKNAMJ_ToDldList.Clear();
							ICCMKHKNAMJ_ToDldList = null;
						}
						KLIJFOBEKBE.HJMKBCFJOOH_Save();
						KDHNLDOIOAL();
						break;
					}
				}
			}
			GameManager.Instance.SetNeverSleep(false);
			// goto LAB_00e8f334;
			FBGNDKKDOIE = null;
			break;
		}
	}

	// // RVA: 0xE88D50 Offset: 0xE88D50 VA: 0xE88D50
	private void DIDACHONHJA_ListExistingFiles(ref Dictionary<string, int> _FAOOOLDDBBB_LocalFilesStatus, string CJJJPKJHOGM)
	{
		KLIJFOBEKBE.KMHCHILJPIG();
		if(Directory.Exists(CJJJPKJHOGM))
		{
			string dataPath = KEHOJEJMGLJ_NetInstallManager.JCMJBMBMJAK_PersistentDataPath;
			int len = dataPath.Length;
			string[] files = Directory.GetFiles(CJJJPKJHOGM, "*", SearchOption.AllDirectories);
			for(int i = 0; i < files.Length; i++)
			{
				string str = files[i].Substring(len);
				str = str.Replace('\\', '/');
				_FAOOOLDDBBB_LocalFilesStatus[str] = 1;
				PAIGMDNFNDJ++;
                FECDBKKBAHO.FHOPNIJCFKA_FileInfo finfo = KLIJFOBEKBE.LBDOLHGDIEB_Find(str);
				if(finfo != null)
				{
					finfo.GOAEFAAIOEK_Missing = false;
				}
            }
		}
	}

	// // RVA: 0xE88F88 Offset: 0xE88F88 VA: 0xE88F88
	public void CIDPPOGCODB(Dictionary<string, int> _FAOOOLDDBBB_LocalFilesStatus)
	{
		//FCPBCDOKOPD(FAOOOLDDBBB_LocalFilesStatus, ) ??
		Dictionary<int, FDICFBNIPAJ> d = new Dictionary<int, FDICFBNIPAJ>();
		Dictionary<int, FDICFBNIPAJ> d2 = new Dictionary<int, FDICFBNIPAJ>();
		string[] strs = new string[_FAOOOLDDBBB_LocalFilesStatus.Keys.Count];
		_FAOOOLDDBBB_LocalFilesStatus.Keys.CopyTo(strs, 0);
		for (int i = 0; i < strs.Length; i++)
		{
			if (_FAOOOLDDBBB_LocalFilesStatus[strs[i]] == 4)
			{
				FECDBKKBAHO.FHOPNIJCFKA_FileInfo fileInfo = KLIJFOBEKBE.LBDOLHGDIEB_Find(strs[i]);
				if (fileInfo != null && fileInfo.KKPAHLMJKIH_WavId > 0)
				{
					if (!d.ContainsKey(fileInfo.KKPAHLMJKIH_WavId))
					{
						FDICFBNIPAJ data = new FDICFBNIPAJ();
						data.KKPAHLMJKIH_WavId = fileInfo.KKPAHLMJKIH_WavId;
						data.DGGFLBJBLLN = fileInfo.DGGFLBJBLLN;
						d.Add(data.KKPAHLMJKIH_WavId, data);
					}
					d[fileInfo.KKPAHLMJKIH_WavId].IBGNDNLAHOE.Add(strs[i]);
				}
			}
			else if (_FAOOOLDDBBB_LocalFilesStatus[strs[i]] == 3)
			{
				FECDBKKBAHO.FHOPNIJCFKA_FileInfo fileInfo = KLIJFOBEKBE.LBDOLHGDIEB_Find(strs[i]);
				if (fileInfo != null && fileInfo.KKPAHLMJKIH_WavId > 0)
				{
					if (!d2.ContainsKey(fileInfo.KKPAHLMJKIH_WavId))
					{
						FDICFBNIPAJ data = new FDICFBNIPAJ();
						data.KKPAHLMJKIH_WavId = fileInfo.KKPAHLMJKIH_WavId;
						data.DGGFLBJBLLN = fileInfo.DGGFLBJBLLN;
						d2.Add(data.KKPAHLMJKIH_WavId, data);
					}
					d2[fileInfo.KKPAHLMJKIH_WavId].IBGNDNLAHOE.Add(strs[i]);
				}
			}
			else if (_FAOOOLDDBBB_LocalFilesStatus[strs[i]] == 1)
			{
				string path = JCMJBMBMJAK_PersistentDataPath + strs[i];
				//File.SetAttributes(path, FileAttributes.Normal);
				TodoLogger.Log(TodoLogger.Filesystem, "Would delete " + path);
				//INLICKMJHHK_DeleteFile(path);
			}
		}
		//FCPBCDOKOPD
		if(d.Count != 0)
		{
			int a = d.Count;
			if(d2.Count <= HGOIEGFBABK)
			{
				int b = d2.Count + a;
				a = d2.Count - HGOIEGFBABK;
				if (a == 0 || b < HGOIEGFBABK)
					a = 0;
			}
			List<FDICFBNIPAJ> l = new List<FDICFBNIPAJ>();
			FDICFBNIPAJ[] l2 = new FDICFBNIPAJ[d.Values.Count];
			d.Values.CopyTo(l2, 0);
			for(int i = 0; i < l2.Length; i++)
			{
				l.Add(l2[i]);
			}
			l.Sort((FDICFBNIPAJ _HKICMNAACDA_a, FDICFBNIPAJ _BNKHBCBJBKI_b) =>
			{
				//0xE8CD9C
				return (int)_HKICMNAACDA_a.DGGFLBJBLLN - (int)_BNKHBCBJBKI_b.DGGFLBJBLLN;
			});
			for(int i = 0; i < a; i++)
			{
				if (l.Count <= i)
					break;
				for(int j = 0; j < l[i].IBGNDNLAHOE.Count; j++)
				{
					string path = JCMJBMBMJAK_PersistentDataPath + l[i].IBGNDNLAHOE[j];
					//File.SetAttributes(path, FileAttributes.Normal);
					TodoLogger.Log(TodoLogger.Filesystem, "Would delete " + path);
					//INLICKMJHHK_DeleteFile(path);
					KLIJFOBEKBE.OJCJPCHFPGO_Delete(l[i].IBGNDNLAHOE[j]);
				}
			}
		}
		//FCPBCDOKOPD
	}

	// // RVA: 0xE89EA0 Offset: 0xE89EA0 VA: 0xE89EA0
	public static bool NHIIAHGHOMH(string _KLICLHJAMMD_LocalPath, long _KPBJHHHMOJE_Time, uint _HHPEMFKDHLK_Hash)
	{
		IGJHFKELHKJ.HPJEDLPEJLF d = MLPDBGFBAAC.LBDOLHGDIEB_Find(_HHPEMFKDHLK_Hash);
		if(d != null && _KPBJHHHMOJE_Time == d.LGEGIKJGCCA)
		{
			DateTime d3 = File.GetLastWriteTime(_KLICLHJAMMD_LocalPath);
			d3 = TimeZoneInfo.ConvertTimeToUtc(d3); 
			DateTime d2 = CBHCDLLOBBK.AddSeconds(d.JMGLAOBOAHM);
			double val = (d3 - d2).TotalSeconds;
			if(val < 0)
				val = -val;
			return val >= 2;
		}
		return true;
	}

	// // RVA: 0xE8A170 Offset: 0xE8A170 VA: 0xE8A170
	private void DDJGHFCIDML(FECDBKKBAHO.FHOPNIJCFKA_FileInfo CFMIMNHLHJJ, PKKHIEAEDPC CEJDIAECJKD, string _CJEKGLGBIHF_path)
	{
		if(CEJDIAECJKD.NKGJOAEDCPH_rule.PAAPNEMBHGN_Day > 0)
		{
			if(CFMIMNHLHJJ == null)
			{
				KLIJFOBEKBE.ANIJHEBLMGB_SetValue(_CJEKGLGBIHF_path, DMPNAEEIANJ, CEJDIAECJKD.KKPAHLMJKIH_WavId);
				CFMIMNHLHJJ = KLIJFOBEKBE.LBDOLHGDIEB_Find(_CJEKGLGBIHF_path);
			}
			if(CFMIMNHLHJJ.FNALNKKMKDC_ExpireTime == 0)
			{
				CFMIMNHLHJJ.FNALNKKMKDC_ExpireTime = CEJDIAECJKD.NKGJOAEDCPH_rule.PAAPNEMBHGN_Day * 86400 + DMPNAEEIANJ;
			}
			CFMIMNHLHJJ.GEJJEDDEPMI = CEJDIAECJKD.NKGJOAEDCPH_rule.PEOIMDCECDL;
		}
	}

	// // RVA: 0xE8A2C4 Offset: 0xE8A2C4 VA: 0xE8A2C4
	private void IAPEABPJPOE(/*IKAHKDKIGNA CBLEBKOJJDB*/List<GCGNICILKLD_AssetFileInfo> _KGHAJGGMPKL_files, ref Dictionary<string, int> _FAOOOLDDBBB_LocalFilesStatus, ref int cnt)
	{
		MD5 md5 = MD5.Create();
		for(int i = 0; i < _KGHAJGGMPKL_files.Count; i++)
		{
			cnt = i;
			GCGNICILKLD_AssetFileInfo afinfo = _KGHAJGGMPKL_files[i];
			bool b = false;
			if(FBGNDKKDOIE != null && FBGNDKKDOIE.Count > 0)
			{
				for(int j = 0; j < FBGNDKKDOIE.Count; j++)
				{
					if(afinfo.OIEAICNAMNB_LocalFileName.Contains(FBGNDKKDOIE[j]))
					{
						b = true;
						break;
					}
				}
			}
			if(!b)
			{
				if(EMJFHKHLHDB == ACGGHEIMPHC.GGCIMLDFDOC/*1*/)
				{
					b = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.AJHAKFLPNHF.ContainsKey(afinfo.OIEAICNAMNB_LocalFileName);
				}
				else
				{
					b = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.ALMGDPAGHMJ.ContainsKey(afinfo.OIEAICNAMNB_LocalFileName);
				}
				string localPath = KEHOJEJMGLJ_NetInstallManager.JCMJBMBMJAK_PersistentDataPath + afinfo.OIEAICNAMNB_LocalFileName;
				if(_FAOOOLDDBBB_LocalFilesStatus.ContainsKey(afinfo.OIEAICNAMNB_LocalFileName))
				{
#if !UNITY_ANDROID && !DEBUG_ANDROID_FILESYSTEM // don't check date or hash on android, we keep everything
                    PKKHIEAEDPC dbAsset = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.NBHDIKJMLEN(afinfo.OIEAICNAMNB_LocalFileName);
                    HODOGPOKOOJ.KMBJEEFHJOH_FileStatus fileKeepStatus = HODOGPOKOOJ.FABLNMEEKKF_GetFileKeepStatus(dbAsset, EMJFHKHLHDB != ACGGHEIMPHC.GGCIMLDFDOC ? HODOGPOKOOJ.KNNLDAHADJB.ANFKBNLLJFN_1 : HODOGPOKOOJ.KNNLDAHADJB.CCAPCGPIIPF_0_Normal);
					if(b)
					{
						fileKeepStatus = HODOGPOKOOJ.KMBJEEFHJOH_FileStatus.CCAPCGPIIPF_1_Normal/*1*/;
					}
                    FECDBKKBAHO.FHOPNIJCFKA_FileInfo finfo = KLIJFOBEKBE.LBDOLHGDIEB_Find(afinfo.OIEAICNAMNB_LocalFileName);
					if(finfo != null && finfo.FNALNKKMKDC_ExpireTime != 0 && DMPNAEEIANJ >= finfo.FNALNKKMKDC_ExpireTime)
					{
						if(!finfo.GEJJEDDEPMI)
							continue;
						_FAOOOLDDBBB_LocalFilesStatus[afinfo.OIEAICNAMNB_LocalFileName] = 4;
					}
					if(fileKeepStatus != HODOGPOKOOJ.KMBJEEFHJOH_FileStatus.PHCMJBCLALL/*0*/ && fileKeepStatus != HODOGPOKOOJ.KMBJEEFHJOH_FileStatus.JFAGADLHIED/*3*/)
					{
						long lastUpdate = afinfo.CALJIGKCAAH_last_updated_at;
						uint fHash = afinfo.HHPEMFKDHLK_Hash;
						bool c = NHIIAHGHOMH(localPath, lastUpdate, fHash);
						if(c)
						{
							if(fileKeepStatus != HODOGPOKOOJ.KMBJEEFHJOH_FileStatus.MCDCNJCJCAB/*2*/ && fileKeepStatus != HODOGPOKOOJ.KMBJEEFHJOH_FileStatus.EOMIACEPHGA/*4*/)
							{
								if(FJDOHLADGFI)
								{
									NFIDKHELFDK++;
									string h = IFCHFDEDCGF_GetFileHash(md5, localPath);
									//if(h == afinfo.POEGMFKLFJG_hash_value)
									TodoLogger.LogError(TodoLogger._Todo, "hash check disabled");
									if(true) // UMO
									{
										_FAOOOLDDBBB_LocalFilesStatus[afinfo.OIEAICNAMNB_LocalFileName] = 2;
										//LAB_00e8aed4
										MLPDBGFBAAC.IDJJFHFPNFG(afinfo.HHPEMFKDHLK_Hash);
										continue;
									}
								}
								ICCMKHKNAMJ_ToDldList.Add(afinfo);
								//LAB_00e8a99c
								continue;
							}
						}
						else
						{
							if(FJDOHLADGFI)
							{
								NFIDKHELFDK++;
								string h = IFCHFDEDCGF_GetFileHash(md5, localPath);
								TodoLogger.LogError(TodoLogger._Todo, "hash check disabled");
								//if(h != afinfo.POEGMFKLFJG_hash_value)
								/*if(false) // UMO, disable file timeout
								{
									if(fileKeepStatus != HODOGPOKOOJ.KMBJEEFHJOH.MCDCNJCJCAB)
									{
										ICCMKHKNAMJ_ToDldList.Add(afinfo);
										//LAB_00e8a99c
										continue;
									}
									//LAB_00e8a9ac
									continue;
								}*/
							}
							if(dbAsset != null)
							{
								DDJGHFCIDML(finfo, dbAsset, afinfo.OIEAICNAMNB_LocalFileName);
								if(dbAsset.NKGJOAEDCPH_rule.PEOIMDCECDL)
								{
									if(_FAOOOLDDBBB_LocalFilesStatus[afinfo.OIEAICNAMNB_LocalFileName] == 1)
									{
										_FAOOOLDDBBB_LocalFilesStatus[afinfo.OIEAICNAMNB_LocalFileName] = 3;
										MLPDBGFBAAC.IDJJFHFPNFG(afinfo.HHPEMFKDHLK_Hash);
									}
								}
							}
							if(_FAOOOLDDBBB_LocalFilesStatus.ContainsKey(afinfo.OIEAICNAMNB_LocalFileName))
							{
								if(_FAOOOLDDBBB_LocalFilesStatus[afinfo.OIEAICNAMNB_LocalFileName] == 1)
								{
									_FAOOOLDDBBB_LocalFilesStatus[afinfo.OIEAICNAMNB_LocalFileName] = 2;
									//LAB_00e8aed4
									MLPDBGFBAAC.IDJJFHFPNFG(afinfo.HHPEMFKDHLK_Hash);
								}
							}
						}
					}
#else
					if(FJDOHLADGFI)
					{
						string h = IFCHFDEDCGF_GetFileHash(md5, localPath);
						if(h != afinfo.POEGMFKLFJG_hash_value)
						{
							UnityEngine.Debug.Log("Wrong hash for "+localPath+" "+h+" != "+afinfo.POEGMFKLFJG_hash_value);
							ICCMKHKNAMJ_ToDldList.Add(afinfo);
						}
					}
#endif
                }
				else
				{
					KLIJFOBEKBE.OJCJPCHFPGO_Delete(afinfo.OIEAICNAMNB_LocalFileName);
#if !UNITY_ANDROID && !DEBUG_ANDROID_FILESYSTEM // Dld all on android
					HODOGPOKOOJ.KMBJEEFHJOH_FileStatus a = HODOGPOKOOJ.FABLNMEEKKF_GetFileKeepStatus(afinfo.OIEAICNAMNB_LocalFileName, EMJFHKHLHDB != ACGGHEIMPHC.GGCIMLDFDOC ? HODOGPOKOOJ.KNNLDAHADJB.ANFKBNLLJFN_1 : HODOGPOKOOJ.KNNLDAHADJB.CCAPCGPIIPF_0_Normal);
					if(b || a == HODOGPOKOOJ.KMBJEEFHJOH_FileStatus.CCAPCGPIIPF_1_Normal/*2*/)
#endif
					{
						ICCMKHKNAMJ_ToDldList.Add(afinfo);
					}
				}
			}
		}
	}

	// // RVA: 0xE8B240 Offset: 0xE8B240 VA: 0xE8B240
	private bool ALDMHFCFECK(int _INDDJNMPONH_type, float LNAHJANMJNM)
	{
		return true;
	}

	// // RVA: 0xE8B248 Offset: 0xE8B248 VA: 0xE8B248
	private void EEHMGCMAOAB(string _DOGDHKIEBJA_error, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, JFDNPFFOACP NEFKBBNKNPP)
	{
		NEFKBBNKNPP();
	}

	// // RVA: 0xE845B8 Offset: 0xE845B8 VA: 0xE845B8
	public static void GFOMKMANCPP(string _CJEKGLGBIHF_path, long KMNPPIKCPNG, uint _HHPEMFKDHLK_Hash, bool FLJBOOPPGDM/* = false*/)
	{
		DateTime fileDate = File.GetLastWriteTime(_CJEKGLGBIHF_path);
		fileDate = TimeZoneInfo.ConvertTimeToUtc(fileDate);
		TimeSpan diff = fileDate - CBHCDLLOBBK;
		if(MLPDBGFBAAC != null)
		{
			IGJHFKELHKJ.HPJEDLPEJLF a = MLPDBGFBAAC.LBDOLHGDIEB_Find(_HHPEMFKDHLK_Hash);
			if(a == null)
			{
				IGJHFKELHKJ.HPJEDLPEJLF data = new IGJHFKELHKJ.HPJEDLPEJLF();
				data.JMGLAOBOAHM = (long)diff.TotalSeconds;
				data.LGEGIKJGCCA = KMNPPIKCPNG;
				data.IOIMHJAOKOO_Hash = _HHPEMFKDHLK_Hash;
				data.CPBPOIMHIML = true;
				MLPDBGFBAAC.LBBOGOBBAAD(data);
			}
			else
			{
				a.CPBPOIMHIML = true;
				a.JMGLAOBOAHM = (long)diff.TotalSeconds;
				a.LGEGIKJGCCA = KMNPPIKCPNG;
			}
			if(FLJBOOPPGDM)
			{
				MLPDBGFBAAC.HJMKBCFJOOH_Save();
			}
		}
	}

	// // RVA: 0xE8B274 Offset: 0xE8B274 VA: 0xE8B274
	public static void JKIBGMKGMCK(bool CPBPOIMHIML)
	{
		if (MLPDBGFBAAC == null)
			return;
		if(CPBPOIMHIML)
		{
			MLPDBGFBAAC.PNMIOGBPDFN();
		}
		MLPDBGFBAAC.HJMKBCFJOOH_Save();
	}

	// // RVA: 0xE8AFF8 Offset: 0xE8AFF8 VA: 0xE8AFF8
	public static string IFCHFDEDCGF_GetFileHash(MD5 DMIPFEIICDP, string _CJEKGLGBIHF_path)
	{
		FileStream f = File.OpenRead(_CJEKGLGBIHF_path);
        byte[] data = DMIPFEIICDP.ComputeHash(f);
		string s = "";
		for(int i = 0; i < data.Length; i++)
		{
			s += string.Format("{0:x2}",data[i]);
		}
		if(f != null)
			f.Dispose();
		return s;
	}

	// // RVA: 0xE8B3C8 Offset: 0xE8B3C8 VA: 0xE8B3C8
	public void OANLHPBJIND()
	{
		KLIJFOBEKBE.JCHLONCMPAJ_Clear();
		PBAHJENPLFM = false;
		if(string.IsNullOrEmpty(CJMOKHDNBNB.FIPFFELDIOG_PersistentPath))
		{
			Debug.LogError("Install.InstallPathManager.CriWare_installTargetPath is empty");
			PBAHJENPLFM = true;
		}
		else
		{
			//string HPOCPGLJHME = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/data";
			string OOOEIAFOJKF = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/sys";
			string DKGFGHCBJEG = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/tmp";
			string LDAHMAIDPCM = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/mx";
			NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.BNJPAKLNOPA_WorkerThreadQueue.Add(() =>
			{
				//0xE8D954
				ALKHIONADIP(OOOEIAFOJKF);
				ALKHIONADIP(DKGFGHCBJEG);
				//ALKHIONADIP(HPOCPGLJHME);
				ALKHIONADIP(LDAHMAIDPCM);
				PBAHJENPLFM = true;
			});
		}
	}

	// // RVA: 0xE89CF8 Offset: 0xE89CF8 VA: 0xE89CF8
	public static void INLICKMJHHK_DeleteFile(string _CJEKGLGBIHF_path)
	{
		TodoLogger.Log(TodoLogger.Filesystem, "Delete File " + _CJEKGLGBIHF_path);
		File.Delete(_CJEKGLGBIHF_path);
	}

	// // RVA: 0xE8B6B0 Offset: 0xE8B6B0 VA: 0xE8B6B0
	public static void IOCKEBLNODI(string NEFEFHBHFFF)
	{
		Directory.Delete(NEFEFHBHFFF);
	}

	// // RVA: 0xE8806C Offset: 0xE8806C VA: 0xE8806C
	public void OMPMGDHJJPG()
	{
		if(string.IsNullOrEmpty(CJMOKHDNBNB.FIPFFELDIOG_PersistentPath))
		{
			UnityEngine.Debug.LogError("Install.InstallPathManager.CriWare_installTargetPath is empty");
			return;
		}
		string tmpDir = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/tmp";
		if(Directory.Exists(tmpDir))
		{
			string[] files = Directory.GetFiles(tmpDir);
			for(int i = 0; i < files.Length; i++)
			{
				INLICKMJHHK_DeleteFile(files[i]);
			}
			string[] dirs = Directory.GetDirectories(tmpDir);
			for(int i = 0; i < dirs.Length; i++)
			{
				ALKHIONADIP(dirs[i]);
			}
		}
	}

	// // RVA: 0xE8B7C8 Offset: 0xE8B7C8 VA: 0xE8B7C8
	private static void ALKHIONADIP(string CJJJPKJHOGM)
	{
		if(!Directory.Exists(CJJJPKJHOGM))
		{
			return;
		}
		string[] files = Directory.GetFiles(CJJJPKJHOGM);
		for(int i = 0; i < files.Length; i++)
		{
			INLICKMJHHK_DeleteFile(files[i]);
		}
		string[] dirs = Directory.GetDirectories(CJJJPKJHOGM);
		for(int i = 0; i < dirs.Length; i++)
		{
			ALKHIONADIP(dirs[i]);
		}
		IOCKEBLNODI(CJJJPKJHOGM);
	}

	// // RVA: 0xE8B9A4 Offset: 0xE8B9A4 VA: 0xE8B9A4
	private static void PKLPEIBEGNO()
	{
		string basePath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/sys";
		if(!Directory.Exists(basePath))
		{
			Directory.CreateDirectory(basePath);
		}
		if (string.IsNullOrEmpty(LHJNPJFNDNA_Rev))
			return;
		string p = LHJNPJFNDNA_Rev + "," + BBGDKLLEPIB_NetInstallMaster.HHCJCDFCLOB_Instance.OCOGBOHOGGE_DbFileName;
		byte[] bytes = Encoding.UTF8.GetBytes(p);
		for(int i = 0; i < bytes.Length; i++)
		{
			bytes[i] ^= (byte)i;
		}
		File.WriteAllBytes(basePath + "/03", bytes);
	}

	// // RVA: 0xE888B8 Offset: 0xE888B8 VA: 0xE888B8
	private static void GBCDHECMDMC()
	{
		string dir = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/sys";
		if(!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
		string file = dir + "/03";
		if(File.Exists(file))
		{
			byte[] bs = File.ReadAllBytes(file);
			for(int i = 0; i < bs.Length; i++)
			{
				bs[i] ^= (byte)i;
			}
			string data = Encoding.UTF8.GetString(bs);
			string[] strs = data.Split(new char[] { ',' });
			if(strs.Length > 1)
			{
				LHJNPJFNDNA_Rev = strs[0];
				if(BBGDKLLEPIB_NetInstallMaster.HHCJCDFCLOB_Instance.OCOGBOHOGGE_DbFileName == strs[1])
					return;
				LHJNPJFNDNA_Rev = null;
			}
		}
	}

	// // RVA: 0xE8BC98 Offset: 0xE8BC98 VA: 0xE8BC98
	public static void AFKGMCBJBJA()
	{
		string dir = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/sys";
		if(!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
		string file = dir + "/03";
		if(!File.Exists(file))
			return;
		ALKHIONADIP(file);
	}

	// // RVA: 0xE8BDB0 Offset: 0xE8BDB0 VA: 0xE8BDB0
	private void BDGGNOAIIFK(float _OLDAGCNLJOI_progress)
	{
		if(INAEAAJIJMF != 1)
			return;
		OAGBCBBHMPF.OGBCFNIKAFI_LoadStep LGADCGFMLLD_step = 0;
		if(EMJFHKHLHDB == ACGGHEIMPHC.GGCIMLDFDOC/*1*/)
		{
			if(_OLDAGCNLJOI_progress < KIEBFLDPBPA * 10)
				return;
			LGADCGFMLLD_step = (OAGBCBBHMPF.OGBCFNIKAFI_LoadStep)(KIEBFLDPBPA + 36);
		}
		else
		{
			if(EMJFHKHLHDB != ACGGHEIMPHC.ANFKBNLLJFN_0/*0*/)
				return;
			if(_OLDAGCNLJOI_progress < KIEBFLDPBPA * 10)
				return;
			LGADCGFMLLD_step = (OAGBCBBHMPF.OGBCFNIKAFI_LoadStep)(KIEBFLDPBPA + 2);
		}
		ILCCJNDFFOB.HHCJCDFCLOB_Instance.ALABPEPENHH_Tutorial(LGADCGFMLLD_step, GCLPIJNJFAE_ElapsedTime);
		KIEBFLDPBPA++;
	}

	// // RVA: 0xE8BF18 Offset: 0xE8BF18 VA: 0xE8BF18
	private void FFHCCIOCPAD()
	{
		string path = CGAHFOBGHIM_PersistentPlatformDataPath + "/snd/bgm";
		if(Directory.Exists(path))
		{
			long serverTime = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int idx = JCMJBMBMJAK_PersistentDataPath.Length;
			string[] files = Directory.GetFiles(path);
			for(int i = 0; i < files.Length; i++)
			{
				string name = files[i].Substring(idx);
				name.Replace('\\', '/');
				FECDBKKBAHO.FHOPNIJCFKA_FileInfo info = KLIJFOBEKBE.LBDOLHGDIEB_Find(name);
				if(info != null && info.GEJJEDDEPMI && serverTime >= info.FNALNKKMKDC_ExpireTime)
				{
					Debug.Log(JpStringLiterals.StringLiteral_12223 + files[i] + "</color>");
					//INLICKMJHHK_DeleteFile(files[i]);
				}
			}
		}
	}

	// // RVA: 0xE8C288 Offset: 0xE8C288 VA: 0xE8C288
	private void KDHNLDOIOAL()
	{
		new BFGOCONGNDK().HJMKBCFJOOH_Save();
	}

	// // RVA: 0xE8C30C Offset: 0xE8C30C VA: 0xE8C30C
	private int JGNEKCNFFDE()
	{
		List<string> l = new List<string>();
		for(int i = 0; i < IDJBKGBMDAJ.KGHAJGGMPKL_files.Count; i++)
		{
			string path = FileSystemProxy.ConvertPath(JCMJBMBMJAK_PersistentDataPath + IDJBKGBMDAJ.KGHAJGGMPKL_files[i].OIEAICNAMNB_LocalFileName);
			if (FileSystemProxy.FileExists(path))
			{
				if(NHIIAHGHOMH(path, IDJBKGBMDAJ.KGHAJGGMPKL_files[i].CALJIGKCAAH_last_updated_at, IDJBKGBMDAJ.KGHAJGGMPKL_files[i].HHPEMFKDHLK_Hash))
				{
					l.Add(path);
				}
			}
		}
		for(int i = 0; i < l.Count; i++)
		{
			//File.Delete(l[i]);
			Debug.Log("Would have deleted " + l[i]);
		}
		return l.Count;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BB69C Offset: 0x6BB69C VA: 0x6BB69C
	// // RVA: 0xE8C6D0 Offset: 0xE8C6D0 VA: 0xE8C6D0
	private IEnumerator POMGAIOAGNC_Coroutine_RemoveOldFiles(IMCBBOAFION _BHFHGFKBOHH_OnSuccess)
	{
		//0xE8F728
		// UMO disable
		/*
		bool BEKAMBBOLBO_Done = false;
		int EPEDIIFEIGB = 0;
		NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.BNJPAKLNOPA_WorkerThreadQueue.Add(() =>
		{
			//0xE8CE2C
			EPEDIIFEIGB = JGNEKCNFFDE();
			BEKAMBBOLBO_Done = true;
		});
		while (!BEKAMBBOLBO_Done)
			yield return null;
		Debug.Log("StringLiteral_12227" + EPEDIIFEIGB + "StringLiteral_10089");
		*/
		yield return null;
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0xE8C798 Offset: 0xE8C798 VA: 0xE8C798
	public void KPMCJMIEMMB(IMCBBOAFION _BHFHGFKBOHH_OnSuccess)
	{
		N.a.StartCoroutineWatched(POMGAIOAGNC_Coroutine_RemoveOldFiles(_BHFHGFKBOHH_OnSuccess));
	}

	// // RVA: 0xE8C7E8 Offset: 0xE8C7E8 VA: 0xE8C7E8
	private void BEINKAGIHJB_CheckMediaFile()
	{
		if(ICCMKHKNAMJ_ToDldList.Count == 0)
			return;
		Regex r = new Regex(".+(usm|acb|awb)$");
		for(int i = 0; i < ICCMKHKNAMJ_ToDldList.Count; i++)
		{
			Match m = r.Match(ICCMKHKNAMJ_ToDldList[i].OIEAICNAMNB_LocalFileName);
			ICCMKHKNAMJ_ToDldList[i].FDDDLPAJIEJ_IsMediaFile = m.Success ? 1 : 0;
		}
	}
}
