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

public class KEHOJEJMGLJ
{

	private enum LIFANPDHNHE
	{
		FKPEAGGKNLC = 0,
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
		ANFKBNLLJFN = 0,
		GGCIMLDFDOC = 1,
		DEKNOKPEIHO = 2,
	}
	
	public class FDICFBNIPAJ
	{
		public int KKPAHLMJKIH; // 0x8
		public long DGGFLBJBLLN; // 0x10
		public List<string> IBGNDNLAHOE = new List<string>(2); // 0x18
	}

	private float NDEJCDBHPLB = 180.0f; // 0x8
	private const bool LFNLMBBPMPJ = false;
	public FECDBKKBAHO KLIJFOBEKBE = new FECDBKKBAHO(); // 0xC
	public OAFCKDDEBFN GMLCCMEHNCI = new OAFCKDDEBFN(); // 0x10
	private static IGJHFKELHKJ MLPDBGFBAAC; // 0x4
	public static bool HBCEEIOHENM = true; // 0x8
	public KEHOJEJMGLJ.ACGGHEIMPHC EMJFHKHLHDB = KEHOJEJMGLJ.ACGGHEIMPHC.GGCIMLDFDOC/*1*/; // 0x14
	// private static string[] EENNDMBAGNC = new string[1] {"android"}; // 0xC
	private static string IMABJMPEPGE_PlatformPrefix; // 0x18
	private static string JCMJBMBMJAK_PersistentDataPath = null; // 0x1C
	private static string PMHFLOLDHAO_PersistentPlatformDataPath = null; // 0x20
	public DJBHIFLHJLK FGGJNGCAFGK; // 0x24
	public List<string> FBGNDKKDOIE = null; // 0x28
	private JEHIAIPJNJF_FileDownloader PMDNNKAPIKJ; // 0x2C
	public static bool FJDOHLADGFI; // 0x28
	public IKAHKDKIGNA IDJBKGBMDAJ; // 0x30
	private List<GCGNICILKLD_AssetFileInfo> ICCMKHKNAMJ; // 0x34
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
	private long GCLPIJNJFAE; // 0x58
	private int KIEBFLDPBPA; // 0x60
	private bool DLAEPJPPEKI; // 0x64
	public bool PBAHJENPLFM; // 0x65

	public static KEHOJEJMGLJ HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	// public static bool ONMPNMJCAAD { get; } // KFHIFNBPANF 0xE87C94
	public static string FLHOFIEOKDH_BaseUrl { get; set; } // 0x10 PGOHBLKDJOM ODMAEKMPAGP BBPOAGDNMOJ
	public static string JNGKCPJBMBA_ServerPlatformUrl { get; set; } // 0x14 BMIJOIFPCCE KEOJOEFBBJE FMEBBKPCEPK
	public string FPCIBJLJOFI_PlatformName { get; set; } // 0x18 LCFILOOJABA NOJDHDJNPAL IHJLOEIKMDI
	public static string LBEPLOJBFCM_PlatformPrefix { 
		get { // KHCOOFHPKGE 0xE7E984
			if(IMABJMPEPGE_PlatformPrefix == null)
			{
				IMABJMPEPGE_PlatformPrefix = "android";
			}
			return IMABJMPEPGE_PlatformPrefix;
		}
	} 
	public static string OGCDNCDMLCA_PersistentDataPath { get {
		// FHOCCNDOAPJ 0xE7EB1C
		if(JCMJBMBMJAK_PersistentDataPath == null)
		{
			string path = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath;
			if(string.IsNullOrEmpty(path))
				UnityEngine.Debug.LogError("Install.InstallPathManager.CriWare_installTargetPath is null");
			JCMJBMBMJAK_PersistentDataPath = path + "/data";
		}
        return JCMJBMBMJAK_PersistentDataPath;
	}}
	public static string CGAHFOBGHIM_PersistentPlatformDataPath { 
		get { // AMBIPPMFFCJ 0xE7DF14
			if(PMHFLOLDHAO_PersistentPlatformDataPath == null)
			{
				PMHFLOLDHAO_PersistentPlatformDataPath = OGCDNCDMLCA_PersistentDataPath + "/" + LBEPLOJBFCM_PlatformPrefix;
			}
			return PMHFLOLDHAO_PersistentPlatformDataPath;
		}
	}
	public static string LHJNPJFNDNA { get; private set; } // 0x24 HCGGEEMOKFN JBIPCECPFGN ONAJIIACAEB
	public OMIFMMJPMDJ OEPPEGHGNNO { get; set; } // 0x1C KPEKONPJHCL LKCDOGAFPNM NPJJMDFAIII
	public OBHIGCFPKJN MAIHLKPEHJN { get; set; } // 0x20 EAIFOAGPGGH KCLBNOKEPIG OCIMGEFKKLM

	// // RVA: 0xE87F08 Offset: 0xE87F08 VA: 0xE87F08
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		KLIJFOBEKBE.KHEKNNFCAOI_Init();
		FileLoader.Instance.findDecryptor = GMLCCMEHNCI.MFHAOMELJKJ_FindDecryptor;
		GMLCCMEHNCI.ALLGKHCNKDN();
		MLPDBGFBAAC = new IGJHFKELHKJ();
		OMPMGDHJJPG();
	}

	// // RVA: 0xE882B8 Offset: 0xE882B8 VA: 0xE882B8 Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0xE88334 Offset: 0xE88334 VA: 0xE88334
	private void FCPBCDOKOPD(KEHOJEJMGLJ.LIFANPDHNHE PPFNGGCBJKC, string IPBHCLIHAPG)
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0xE883AC Offset: 0xE883AC VA: 0xE883AC
	public void OFLDICKPNFD(bool CJPFICKPJPP, DJBHIFLHJLK FGGJNGCAFGK)
	{
		if(CJPFICKPJPP)
		{
			MAIHLKPEHJN = JHHBAFKMBDL.HHCJCDFCLOB.DOHNKJKOGFJ;
		}
		else
		{
			MAIHLKPEHJN = this.EEHMGCMAOAB;
		}
		this.FGGJNGCAFGK = FGGJNGCAFGK;
	}

	// // RVA: 0xE884B4 Offset: 0xE884B4 VA: 0xE884B4
	public void PAHGEEOFEPM_Install(KEHOJEJMGLJ.ACGGHEIMPHC INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, int INAEAAJIJMF = 0, long GCLPIJNJFAE = 0)
	{
		GMLCCMEHNCI.PGLANLKJBLI_Init();
		this.GCLPIJNJFAE = GCLPIJNJFAE;
		this.INAEAAJIJMF = INAEAAJIJMF;
		KIEBFLDPBPA = 0;
		if(MLPDBGFBAAC == null)
		{
			MLPDBGFBAAC = new IGJHFKELHKJ();
		}
		if(MLPDBGFBAAC != null)
		{
			MLPDBGFBAAC.PCODDPDFLHK();
			if(INDDJNMPONH == /*2*/KEHOJEJMGLJ.ACGGHEIMPHC.DEKNOKPEIHO)
			{
				MLPDBGFBAAC.PNMIOGBPDFN();
			}
		}
		LHJNPJFNDNA = null;
		if(EMJFHKHLHDB == INDDJNMPONH && INDDJNMPONH != 0)
		{
			if(INDDJNMPONH == KEHOJEJMGLJ.ACGGHEIMPHC.GGCIMLDFDOC/*1*/)
			{
				GBCDHECMDMC();
			}
		}
		else
		{
			LHJNPJFNDNA = null;
		}
		EMJFHKHLHDB = INDDJNMPONH;
		FPCIBJLJOFI_PlatformName = "android";
		JCMJBMBMJAK_PersistentDataPath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/data";
		//FCPBCDOKOPD(,null); ???
		N.a.StartCoroutineWatched(EOFJPNPFGDM_Coroutine_Install(BHFHGFKBOHH,MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BB624 Offset: 0x6BB624 VA: 0x6BB624
	// // RVA: 0xE88C70 Offset: 0xE88C70 VA: 0xE88C70
	private IEnumerator EOFJPNPFGDM_Coroutine_Install(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		// public DJBHIFLHJLK MOBEEPPKFLG; // 0x1C
		// public IMCBBOAFION BHFHGFKBOHH; // 0x20
		// private bool NGDBJIAFCKE; // 0x2C
		// private PJKLMCGEJMK JFAIABBIPEO; // 0x30
		// private LFPOMKLKHPB NOAMCCLDODN; // 0x34
		// private int NJDHMNBBCLK; // 0x38
		//0xE8DA10
		//UnityEngine.Debug.Log("Enter EOFJPNPFGDM_Coroutine_Install");

		int NJDHMNBBCLK = 0;
		// private KEHOJEJMGLJ.<>c__DisplayClass75_0 OPLBFCEPDCH; // 0x14
			// public KEHOJEJMGLJ KIGBLACMODG; // 0x8
			// public bool KOMKKBDABJP; // 0xC
		if(OEPPEGHGNNO == null)
		{
			OEPPEGHGNNO = this.ALDMHFCFECK;
		}
		if(MAIHLKPEHJN == null)
		{
			MAIHLKPEHJN = this.EEHMGCMAOAB;
		}
		//FCPBCDOKOPD?
		KLIJFOBEKBE.PCODDPDFLHK();
		DMPNAEEIANJ = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		if(GCLPIJNJFAE == 0)
		{
			GCLPIJNJFAE = DMPNAEEIANJ;
		}
		DLAEPJPPEKI = true;
		bool NGDBJIAFCKE = false;
		FFHCCIOCPAD();
		PJKLMCGEJMK JFAIABBIPEO = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		//goto LAB_00e8e258;
		while(true)
		{

			// private KEHOJEJMGLJ.<>c__DisplayClass75_1 LBLMCMHMNGC; // 0x18
				// public Dictionary<string, int> FAOOOLDDBBB; // 0x8
				// public JPAPJLIPNOK COJNCNGHIJC; // 0xC
				// public KEHOJEJMGLJ.<>c__DisplayClass75_0 PGFMIBMJBHD; // 0x10
				// RVA: 0xE8CE74 Offset: 0xE8CE74 VA: 0xE8CE74
				// internal void IPGJJANJOMJ() { }
				// // RVA: 0xE8D3C0 Offset: 0xE8D3C0 VA: 0xE8D3C0
				// internal void EGDGJOPDNFF() { }
				// // RVA: 0xE8D424 Offset: 0xE8D424 VA: 0xE8D424
				// internal void FKJIINPOGKK(JEHIAIPJNJF.HCJPJKCIBDL JGBPLIGAILE) { }
				// // RVA: 0xE8D8B0 Offset: 0xE8D8B0 VA: 0xE8D8B0
				// internal void BCMEPPIPGIB() { }

			//FCPBCDOKOPD?
			JPAPJLIPNOK_RequestAssetList COJNCNGHIJC = JFAIABBIPEO.IFFNCAFNEAG_AddRequest<JPAPJLIPNOK_RequestAssetList>(new JPAPJLIPNOK_RequestAssetList());
			COJNCNGHIJC.FPCIBJLJOFI_Type = FPCIBJLJOFI_PlatformName;
			yield return COJNCNGHIJC.GDPDELLNOBO_WaitDone(N.a);
			//1

			if(COJNCNGHIJC.NPNNPNAIONN_IsError)
			{
				if(MOBEEPPKFLG != null)
				{
					MOBEEPPKFLG();
				}
				//FCPBCDOKOPD?
				UnityEngine.Debug.LogError("Exit Error EOFJPNPFGDM_Coroutine_Install");
				yield break;
			}

			IDJBKGBMDAJ = COJNCNGHIJC.NFEAMMJIMPG;
			FLHOFIEOKDH_BaseUrl = COJNCNGHIJC.NFEAMMJIMPG.GLMGHMCOMEC_BaseUrl;
			JNGKCPJBMBA_ServerPlatformUrl = FLHOFIEOKDH_BaseUrl + AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash + LBEPLOJBFCM_PlatformPrefix + AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash;

			DMPNAEEIANJ = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			//FCPBCDOKOPD()?
			if(EMJFHKHLHDB == KEHOJEJMGLJ.ACGGHEIMPHC.DEKNOKPEIHO/*2*/)
			{
				if(BHFHGFKBOHH != null)
				{
					BHFHGFKBOHH();
				}
				//FCPBCDOKOPD?
			}
			else
			{
				if(LHJNPJFNDNA != COJNCNGHIJC.HOHOBEOJPBK_ServerInfo.AJBPBEALBOB_ServerCurrentAssetRevision)
				{
					ICCMKHKNAMJ = new List<GCGNICILKLD_AssetFileInfo>();
					Dictionary<string, int> FAOOOLDDBBB = new Dictionary<string, int>();
					bool KOMKKBDABJP = false;
					JFAIABBIPEO.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
						//0xE8CE74
						//FCPBCDOKOPD?
						KLIJFOBEKBE.EBCAKALIAHH_RemoveExpiredSongs();
						PAIGMDNFNDJ = 0;
						DIDACHONHJA_ListExistingFiles(ref FAOOOLDDBBB, JCMJBMBMJAK_PersistentDataPath);
						string[] str = new string[5];
						str[0] = ""+COJNCNGHIJC.NFEAMMJIMPG.KGHAJGGMPKL_Files.Count;
						str[1] = ",installed=";
						str[2] = ""+PAIGMDNFNDJ;
						str[3] = ",timestamp=";
						str[4] = ""+0;
						UnityEngine.Debug.Log(string.Concat(str));
						//FCPBCDOKOPD
						NFIDKHELFDK = 0;
						IAPEABPJPOE(COJNCNGHIJC.NFEAMMJIMPG, ref FAOOOLDDBBB);
						BEINKAGIHJB_CheckMediaFile();
						KOMKKBDABJP = true;
					});
					//goto LAB_00e8dd6c;
					//2
					while(KOMKKBDABJP == false)
						yield return null;

					//FCPBCDOKOPD?
					DLAEPJPPEKI = false;
					// L 482
					//*************
					TodoLogger.Log(TodoLogger._Todo, "Todo File on disk check");
					ICCMKHKNAMJ.Clear();// UMO hack, not file check for now
					//*************
					if (ICCMKHKNAMJ.Count == 0)
					{
						KOMKKBDABJP = false;
						JFAIABBIPEO.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
							//0xE8D3C0
							TodoLogger.Log(TodoLogger._Todo, "Disabled file deletion");
							//CIDPPOGCODB(FAOOOLDDBBB);
							KOMKKBDABJP = true;
						});
						//goto LAB_00e8eab0;
						//3
						//LAB_00e8eab0:
						while(!KOMKKBDABJP)
						{
							yield return null;
						}
						LHJNPJFNDNA = COJNCNGHIJC.HOHOBEOJPBK_ServerInfo.AJBPBEALBOB_ServerCurrentAssetRevision;
						if(MLPDBGFBAAC != null)
						{
							MLPDBGFBAAC.HJMKBCFJOOH();
						}
						if(EMJFHKHLHDB == KEHOJEJMGLJ.ACGGHEIMPHC.GGCIMLDFDOC/*1*/)
						{
							PKLPEIBEGNO();
						}
						ICCMKHKNAMJ.Clear();
						KLIJFOBEKBE.HJMKBCFJOOH();
						KDHNLDOIOAL();
						GC.Collect();
						GameManager.Instance.SetNeverSleep(false);
						//FCPBCDOKOPD
						if(BHFHGFKBOHH != null)
						{
							BHFHGFKBOHH();
						}
						//goto LAB_00e8f334;
						FBGNDKKDOIE = null;
						//UnityEngine.Debug.Log("Exit EOFJPNPFGDM_Coroutine_Install");
						yield break;
					}
					// L518
					GameManager.Instance.SetNeverSleep(true);
					LFPOMKLKHPB NOAMCCLDODN = new LFPOMKLKHPB();
					NOAMCCLDODN.LKLCOEJLBGG();
					//break;
					while (!NOAMCCLDODN.PLOOEECNHFB_IsDone)
					{
						yield return null;
					}

					NOAMCCLDODN.NKIKBOJOCNN_ShowInstallFileSize(ICCMKHKNAMJ);
					//LAB_00e8e7d8
					while(!NOAMCCLDODN.PLOOEECNHFB_IsDone)
					{
						yield return null;
						// To 5
						//5
					}

					if(NOAMCCLDODN.AAAOKDDILCP_IsError)
					{
						if(MOBEEPPKFLG != null)
						{
							MOBEEPPKFLG();
						}
						UnityEngine.Debug.LogError("Exit Error EOFJPNPFGDM_Coroutine_Install");
						yield break;
					}
					OEPPEGHGNNO(1, 0);
					//LAB_00e8e87c:
					while(!OEPPEGHGNNO(4, 0))
					{
						yield return null;
						// to 6
						//6
					}
					PMDNNKAPIKJ = new JEHIAIPJNJF_FileDownloader(3);
					PMDNNKAPIKJ.DOMFHDPMCCO_AddFiles(ICCMKHKNAMJ, FLHOFIEOKDH_BaseUrl, JCMJBMBMJAK_PersistentDataPath);
					PMDNNKAPIKJ.LBGNKOJFOFC = (JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo JGBPLIGAILE) => {
						//0xE8D424
						TodoLogger.Log(0, "TODO");
					};
					NJDHMNBBCLK = 60;
					// goto LAB_00e8f360
					//LAB_00e8f360:
					PMDNNKAPIKJ.LAOEGNLOJHC();
					while(true)
					{
						//LAB_00e8f368
						yield return null;
						//To 7
						//7
						PMDNNKAPIKJ.FBANBDCOEJL();
						if(PMDNNKAPIKJ.CMCKNKKCNDK_Status == JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.FEJIMBDPMKI/*2*/)
						{
							OEPPEGHGNNO(3, 100);
							PMDNNKAPIKJ.Dispose();
							PMDNNKAPIKJ = null;
							BDGGNOAIIFK(100);
							OEPPEGHGNNO(3, 100);
							GameManager.Instance.SetNeverSleep(false);
							KOMKKBDABJP = false;
							JFAIABBIPEO.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
								//0xE8D8B0
								TodoLogger.Log(0, "TODO");
							});
							//goto LAB_00e8e0f8;
							//0xd
							//LAB_00e8e0f8
							while(!KOMKKBDABJP)
								yield return null;
							KLIJFOBEKBE.HJMKBCFJOOH();
							GC.Collect();
							NGDBJIAFCKE = true;
							LHJNPJFNDNA = COJNCNGHIJC.HOHOBEOJPBK_ServerInfo.AJBPBEALBOB_ServerCurrentAssetRevision;
							if(EMJFHKHLHDB == KEHOJEJMGLJ.ACGGHEIMPHC.GGCIMLDFDOC/*1*/)
							{
								PKLPEIBEGNO();
							}
							NOAMCCLDODN = null;
							//LAB_00e8e258:
							break;
						}
						//L731
						if(PMDNNKAPIKJ.CMCKNKKCNDK_Status == JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LPLEIJIFOKN/*4*/)
						{
							// private KEHOJEJMGLJ.<>c__DisplayClass75_2 PHPPCOBECCA; // 0x24
								// public int APGOAMNGFFF; // 0x8
								// // RVA: 0xE8D91C Offset: 0xE8D91C VA: 0xE8D91C
								// internal void EKHEBHFBKID() { }
								// // RVA: 0xE8D928 Offset: 0xE8D928 VA: 0xE8D928
								// internal void OIIFKBGOJKO() { }
							int APGOAMNGFFF = 0;
							string errorStr = "network";
							if(PMDNNKAPIKJ.BHICPONFJKM)
								errorStr = "storage";
							int avaiable = StorageSupport.GetAvailableStorageSizeMB();
							if(avaiable > -1 && avaiable < 50)
								errorStr = "storage";
							MAIHLKPEHJN(errorStr, () => {
								//0xE8D91C
								TodoLogger.Log(0, "TODO");
							}, () => {
								//0xE8D928
								TodoLogger.Log(0, "TODO");
							});
							//goto LAB_00e8dffc;
							// 8
							while(APGOAMNGFFF == 0)
								yield return null;
							if(APGOAMNGFFF == 1)
							{
								PMDNNKAPIKJ.PBIMGBKLDPP();
								//goto LAB_00e8e088;
								//9
								while(PMDNNKAPIKJ.CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_None/*0*/)
								{
									PMDNNKAPIKJ.FBANBDCOEJL();
									yield return null;
								}
								//goto LAB_00e8f360;
								PMDNNKAPIKJ.LAOEGNLOJHC();
								continue;
							}
							// LAB_00e8f30c;
							PMDNNKAPIKJ.Dispose();
							PMDNNKAPIKJ = null;
							if(FGGJNGCAFGK != null)
								FGGJNGCAFGK();
							//LAB_00e8f334
							FBGNDKKDOIE = null;
							UnityEngine.Debug.LogError("Exit Error EOFJPNPFGDM_Coroutine_Install");
							yield break;
						}
						// L.780
						OEPPEGHGNNO(3, PMDNNKAPIKJ.HCAJCKCOCHC());
						BDGGNOAIIFK(PMDNNKAPIKJ.HCAJCKCOCHC());
						if(PMDNNKAPIKJ.MNFGKBAEFFL() || PMDNNKAPIKJ.KAMPHNKAHAB_IsDiskFull)
						{
							//LAB_00e8f064:
							// private KEHOJEJMGLJ.<>c__DisplayClass75_3 OGEABHOODHB; // 0x28
								// public int APGOAMNGFFF; // 0x8
								// // RVA: 0xE8D93C Offset: 0xE8D93C VA: 0xE8D93C
								// internal void NNGKGAGFFBE() { }
								// // RVA: 0xE8D948 Offset: 0xE8D948 VA: 0xE8D948
								// internal void CAPIELNEBFB() { }
							PMDNNKAPIKJ.PBIMGBKLDPP();
							//goto LAB_00e8f0a4;
							//LAB_00e8f0a4:
							while(PMDNNKAPIKJ.CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_None/*0*/)
							{
								PMDNNKAPIKJ.FBANBDCOEJL();
								yield return null;
							}
							int APGOAMNGFFF = 0;
							string errorStr = "network";
							if(PMDNNKAPIKJ.KAMPHNKAHAB_IsDiskFull)
							{
								errorStr = "storage";
							}
							int avaiable = StorageSupport.GetAvailableStorageSizeMB();
							if(avaiable > -1 && avaiable < 50)
								errorStr = "storage";
							MAIHLKPEHJN(errorStr, () => {
								//0xE8D93C
								TodoLogger.Log(0, "TODO");
							}, () => {
								//0xE8D948
								TodoLogger.Log(0, "TODO");
							});
							//goto LAB_00e8f260;
							//0xb
							while(APGOAMNGFFF == 0)
								yield return null;
							if(APGOAMNGFFF != 1)
							{
								//LAB_00e8f30c:
								PMDNNKAPIKJ.Dispose();
								PMDNNKAPIKJ = null;
								if(FGGJNGCAFGK != null)
									FGGJNGCAFGK();
								//LAB_00e8f334
								FBGNDKKDOIE = null;
								UnityEngine.Debug.LogError("Exit Error EOFJPNPFGDM_Coroutine_Install");
								yield break;
							}
							PMDNNKAPIKJ.PBIMGBKLDPP();
							//LAB_00e8f2d0:
							while(PMDNNKAPIKJ.CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_None/*0*/)
							{
								PMDNNKAPIKJ.FBANBDCOEJL();
								//LAB_00e8f2fc:
								yield return null;
								// 0xc
								//goto LAB_00e8f2d0
							}
							//goto LAB_00e8f360;
							PMDNNKAPIKJ.LAOEGNLOJHC();
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
					//L 380
					if(NGDBJIAFCKE)
					{
						OEPPEGHGNNO(2, 100);
					}
					GC.Collect();
					if(BHFHGFKBOHH != null)
					{
						BHFHGFKBOHH();
					}
					//FCPBCDOKOPD
					if(MLPDBGFBAAC != null)
					{
						if(DLAEPJPPEKI)
						{
							MLPDBGFBAAC.PNMIOGBPDFN();
						}
						MLPDBGFBAAC.HJMKBCFJOOH();
					}
					if(ICCMKHKNAMJ != null)
					{
						ICCMKHKNAMJ.Clear();
						ICCMKHKNAMJ = null;
					}
					KLIJFOBEKBE.HJMKBCFJOOH();
					KDHNLDOIOAL();
					break;
				}
			}
			GameManager.Instance.SetNeverSleep(false);
			// goto LAB_00e8f334;
			FBGNDKKDOIE = null;

			//UnityEngine.Debug.Log("Exit EOFJPNPFGDM_Coroutine_Install");
			break;
		}
	}

	// // RVA: 0xE88D50 Offset: 0xE88D50 VA: 0xE88D50
	private void DIDACHONHJA_ListExistingFiles(ref Dictionary<string, int> FAOOOLDDBBB, string CJJJPKJHOGM)
	{
		KLIJFOBEKBE.KMHCHILJPIG();
		if(Directory.Exists(CJJJPKJHOGM))
		{
			string dataPath = KEHOJEJMGLJ.JCMJBMBMJAK_PersistentDataPath;
			int len = dataPath.Length;
			string[] files = Directory.GetFiles(CJJJPKJHOGM, "*", SearchOption.AllDirectories);
			for(int i = 0; i < files.Length; i++)
			{
				string str = files[i].Substring(len);
				str = str.Replace('\\', '/');
				FAOOOLDDBBB[str] = 1;
				PAIGMDNFNDJ++;
                FECDBKKBAHO.FHOPNIJCFKA_FileInfo finfo = KLIJFOBEKBE.LBDOLHGDIEB_GetFileInfo(str);
				if(finfo != null)
				{
					finfo.GOAEFAAIOEK_Missing = false;
				}
            }
		}
	}

	// // RVA: 0xE88F88 Offset: 0xE88F88 VA: 0xE88F88
	public void CIDPPOGCODB(Dictionary<string, int> FAOOOLDDBBB)
	{
		//FCPBCDOKOPD(FAOOOLDDBBB, ) ??
		Dictionary<int, FDICFBNIPAJ> d = new Dictionary<int, FDICFBNIPAJ>();
		Dictionary<int, FDICFBNIPAJ> d2 = new Dictionary<int, FDICFBNIPAJ>();
		string[] strs = new string[FAOOOLDDBBB.Keys.Count];
		FAOOOLDDBBB.Keys.CopyTo(strs, 0);
		for (int i = 0; i < strs.Length; i++)
		{
			if (FAOOOLDDBBB[strs[i]] == 4)
			{
				FECDBKKBAHO.FHOPNIJCFKA_FileInfo fileInfo = KLIJFOBEKBE.LBDOLHGDIEB_GetFileInfo(strs[i]);
				if (fileInfo != null && fileInfo.KKPAHLMJKIH > 0)
				{
					if (!d.ContainsKey(fileInfo.KKPAHLMJKIH))
					{
						FDICFBNIPAJ data = new FDICFBNIPAJ();
						data.KKPAHLMJKIH = fileInfo.KKPAHLMJKIH;
						data.DGGFLBJBLLN = fileInfo.DGGFLBJBLLN;
						d.Add(data.KKPAHLMJKIH, data);
					}
					d[fileInfo.KKPAHLMJKIH].IBGNDNLAHOE.Add(strs[i]);
				}
			}
			else if (FAOOOLDDBBB[strs[i]] == 3)
			{
				FECDBKKBAHO.FHOPNIJCFKA_FileInfo fileInfo = KLIJFOBEKBE.LBDOLHGDIEB_GetFileInfo(strs[i]);
				if (fileInfo != null && fileInfo.KKPAHLMJKIH > 0)
				{
					if (!d2.ContainsKey(fileInfo.KKPAHLMJKIH))
					{
						FDICFBNIPAJ data = new FDICFBNIPAJ();
						data.KKPAHLMJKIH = fileInfo.KKPAHLMJKIH;
						data.DGGFLBJBLLN = fileInfo.DGGFLBJBLLN;
						d2.Add(data.KKPAHLMJKIH, data);
					}
					d2[fileInfo.KKPAHLMJKIH].IBGNDNLAHOE.Add(strs[i]);
				}
			}
			else if (FAOOOLDDBBB[strs[i]] == 1)
			{
				string path = JCMJBMBMJAK_PersistentDataPath + strs[i];
				File.SetAttributes(path, FileAttributes.Normal);
				UnityEngine.Debug.Log("Would delete " + path);
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
			l.Sort((FDICFBNIPAJ HKICMNAACDA, FDICFBNIPAJ BNKHBCBJBKI) =>
			{
				//0xE8CD9C
				return (int)HKICMNAACDA.DGGFLBJBLLN - (int)BNKHBCBJBKI.DGGFLBJBLLN;
			});
			for(int i = 0; i < a; i++)
			{
				if (l.Count <= i)
					break;
				for(int j = 0; j < l[i].IBGNDNLAHOE.Count; j++)
				{
					string path = JCMJBMBMJAK_PersistentDataPath + l[i].IBGNDNLAHOE[j];
					File.SetAttributes(path, FileAttributes.Normal);
					UnityEngine.Debug.Log("Would delete " + path);
					//INLICKMJHHK_DeleteFile(path);
					KLIJFOBEKBE.OJCJPCHFPGO_DeleteFileInfo(l[i].IBGNDNLAHOE[j]);
				}
			}
		}
		//FCPBCDOKOPD
	}

	// // RVA: 0xE89EA0 Offset: 0xE89EA0 VA: 0xE89EA0
	public static bool NHIIAHGHOMH(string KLICLHJAMMD_LocalPath, long KPBJHHHMOJE_LastUpdate, uint HHPEMFKDHLK_Hash)
	{
		IGJHFKELHKJ.HPJEDLPEJLF d = MLPDBGFBAAC.LBDOLHGDIEB(HHPEMFKDHLK_Hash);
		if(d != null && KPBJHHHMOJE_LastUpdate == d.LGEGIKJGCCA)
		{
			DateTime d3 = File.GetLastWriteTime(KLICLHJAMMD_LocalPath);
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
	private void DDJGHFCIDML(FECDBKKBAHO.FHOPNIJCFKA_FileInfo CFMIMNHLHJJ, PKKHIEAEDPC CEJDIAECJKD, string CJEKGLGBIHF_path)
	{
		if(CEJDIAECJKD.NKGJOAEDCPH.PAAPNEMBHGN_Day > 0)
		{
			if(CFMIMNHLHJJ == null)
			{
				KLIJFOBEKBE.ANIJHEBLMGB(CJEKGLGBIHF_path, DMPNAEEIANJ, CEJDIAECJKD.KKPAHLMJKIH_WavId);
				CFMIMNHLHJJ = KLIJFOBEKBE.LBDOLHGDIEB_GetFileInfo(CJEKGLGBIHF_path);
			}
			if(CFMIMNHLHJJ.FNALNKKMKDC_ExpireTime == 0)
			{
				CFMIMNHLHJJ.FNALNKKMKDC_ExpireTime = CEJDIAECJKD.NKGJOAEDCPH.PAAPNEMBHGN_Day * 86400 + DMPNAEEIANJ;
			}
			CFMIMNHLHJJ.GEJJEDDEPMI = CEJDIAECJKD.NKGJOAEDCPH.PEOIMDCECDL;
		}
	}

	// // RVA: 0xE8A2C4 Offset: 0xE8A2C4 VA: 0xE8A2C4
	private void IAPEABPJPOE(IKAHKDKIGNA CBLEBKOJJDB, ref Dictionary<string, int> FAOOOLDDBBB)
	{
		MD5 md5 = MD5.Create();
		for(int i = 0; i < CBLEBKOJJDB.KGHAJGGMPKL_Files.Count; i++)
		{
			GCGNICILKLD_AssetFileInfo afinfo = CBLEBKOJJDB.KGHAJGGMPKL_Files[i];
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
					b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.AJHAKFLPNHF.ContainsKey(afinfo.OIEAICNAMNB_LocalFileName);
				}
				else
				{
					b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.ALMGDPAGHMJ.ContainsKey(afinfo.OIEAICNAMNB_LocalFileName);
				}
				string localPath = KEHOJEJMGLJ.JCMJBMBMJAK_PersistentDataPath + afinfo.OIEAICNAMNB_LocalFileName;
				if(FAOOOLDDBBB.ContainsKey(afinfo.OIEAICNAMNB_LocalFileName))
				{
                    PKKHIEAEDPC dbAsset = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.NBHDIKJMLEN(afinfo.OIEAICNAMNB_LocalFileName);
                    HODOGPOKOOJ.KMBJEEFHJOH fileKeepStatus = HODOGPOKOOJ.FABLNMEEKKF_GetFileKeepStatus(dbAsset, EMJFHKHLHDB != ACGGHEIMPHC.GGCIMLDFDOC ? HODOGPOKOOJ.KNNLDAHADJB.ANFKBNLLJFN : HODOGPOKOOJ.KNNLDAHADJB.CCAPCGPIIPF);
					if(b)
					{
						fileKeepStatus = HODOGPOKOOJ.KMBJEEFHJOH.CCAPCGPIIPF/*1*/;
					}
                    FECDBKKBAHO.FHOPNIJCFKA_FileInfo finfo = KLIJFOBEKBE.LBDOLHGDIEB_GetFileInfo(afinfo.OIEAICNAMNB_LocalFileName);
					if(finfo != null && finfo.FNALNKKMKDC_ExpireTime != 0 && DMPNAEEIANJ >= finfo.FNALNKKMKDC_ExpireTime)
					{
						if(!finfo.GEJJEDDEPMI)
							continue;
						FAOOOLDDBBB[afinfo.OIEAICNAMNB_LocalFileName] = 4;
					}
					if(fileKeepStatus != HODOGPOKOOJ.KMBJEEFHJOH.PHCMJBCLALL/*0*/ && fileKeepStatus != HODOGPOKOOJ.KMBJEEFHJOH.JFAGADLHIED/*3*/)
					{
						long lastUpdate = afinfo.CALJIGKCAAH_LastUpdated;
						uint fHash = afinfo.HHPEMFKDHLK_FileHash;
						bool c = NHIIAHGHOMH(localPath, lastUpdate, fHash);
						if(c)
						{
							if(fileKeepStatus != HODOGPOKOOJ.KMBJEEFHJOH.MCDCNJCJCAB/*2*/ && fileKeepStatus != HODOGPOKOOJ.KMBJEEFHJOH.EOMIACEPHGA/*4*/)
							{
								if(FJDOHLADGFI)
								{
									NFIDKHELFDK++;
									string h = IFCHFDEDCGF_GetFileHash(md5, localPath);
									//if(h == afinfo.POEGMFKLFJG_Hash)
									TodoLogger.Log(TodoLogger._Todo, "hash check disabled");
									if(true) // UMO
									{
										FAOOOLDDBBB[afinfo.OIEAICNAMNB_LocalFileName] = 2;
										//LAB_00e8aed4
										MLPDBGFBAAC.IDJJFHFPNFG(afinfo.HHPEMFKDHLK_FileHash);
										continue;
									}
								}
								ICCMKHKNAMJ.Add(afinfo);
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
								TodoLogger.Log(TodoLogger._Todo, "hash check disabled");
								//if(h != afinfo.POEGMFKLFJG_Hash)
								if(false) // UMO
								{
									if(fileKeepStatus != HODOGPOKOOJ.KMBJEEFHJOH.MCDCNJCJCAB/*2*/)
									{
										ICCMKHKNAMJ.Add(afinfo);
										//LAB_00e8a99c
										continue;
									}
									//LAB_00e8a9ac
									continue;
								}
							}
							if(dbAsset != null)
							{
								DDJGHFCIDML(finfo, dbAsset, afinfo.OIEAICNAMNB_LocalFileName);
								if(dbAsset.NKGJOAEDCPH.PEOIMDCECDL)
								{
									if(FAOOOLDDBBB[afinfo.OIEAICNAMNB_LocalFileName] == 1)
									{
										FAOOOLDDBBB[afinfo.OIEAICNAMNB_LocalFileName] = 3;
										MLPDBGFBAAC.IDJJFHFPNFG(afinfo.HHPEMFKDHLK_FileHash);
									}
								}
							}
							if(FAOOOLDDBBB.ContainsKey(afinfo.OIEAICNAMNB_LocalFileName))
							{
								if(FAOOOLDDBBB[afinfo.OIEAICNAMNB_LocalFileName] == 1)
								{
									FAOOOLDDBBB[afinfo.OIEAICNAMNB_LocalFileName] = 2;
									//LAB_00e8aed4
									MLPDBGFBAAC.IDJJFHFPNFG(afinfo.HHPEMFKDHLK_FileHash);
								}
							}
						}
					}
                }
				else
				{
					KLIJFOBEKBE.OJCJPCHFPGO_DeleteFileInfo(afinfo.OIEAICNAMNB_LocalFileName);
					HODOGPOKOOJ.KMBJEEFHJOH a = HODOGPOKOOJ.FABLNMEEKKF_GetFileKeepStatus(afinfo.OIEAICNAMNB_LocalFileName, EMJFHKHLHDB != ACGGHEIMPHC.GGCIMLDFDOC ? HODOGPOKOOJ.KNNLDAHADJB.ANFKBNLLJFN : HODOGPOKOOJ.KNNLDAHADJB.CCAPCGPIIPF);
					if(b || a == HODOGPOKOOJ.KMBJEEFHJOH.CCAPCGPIIPF/*2*/)
					{
						ICCMKHKNAMJ.Add(afinfo);
					}
				}
			}
		}
	}

	// // RVA: 0xE8B240 Offset: 0xE8B240 VA: 0xE8B240
	private bool ALDMHFCFECK(int INDDJNMPONH, float LNAHJANMJNM)
	{
		TodoLogger.Log(0, "TODO");
		return false;
	}

	// // RVA: 0xE8B248 Offset: 0xE8B248 VA: 0xE8B248
	private void EEHMGCMAOAB(string DOGDHKIEBJA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP)
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0xE845B8 Offset: 0xE845B8 VA: 0xE845B8
	public static void GFOMKMANCPP(string CJEKGLGBIHF_path, long KMNPPIKCPNG, uint HHPEMFKDHLK, bool FLJBOOPPGDM = false)
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0xE8B274 Offset: 0xE8B274 VA: 0xE8B274
	// public static void JKIBGMKGMCK(bool CPBPOIMHIML) { }

	// // RVA: 0xE8AFF8 Offset: 0xE8AFF8 VA: 0xE8AFF8
	private static string IFCHFDEDCGF_GetFileHash(MD5 DMIPFEIICDP, string CJEKGLGBIHF_path)
	{
		TodoLogger.Log(TodoLogger.HashCheck, "IFCHFDEDCGF");
		return "";
	}

	// // RVA: 0xE8B3C8 Offset: 0xE8B3C8 VA: 0xE8B3C8
	// public void OANLHPBJIND() { }

	// // RVA: 0xE89CF8 Offset: 0xE89CF8 VA: 0xE89CF8
	public static void INLICKMJHHK_DeleteFile(string CJEKGLGBIHF_path)
	{
		UnityEngine.Debug.Log("Delete File "+CJEKGLGBIHF_path);
		File.Delete(CJEKGLGBIHF_path);
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
		if (string.IsNullOrEmpty(LHJNPJFNDNA))
			return;
		string p = LHJNPJFNDNA + "," + BBGDKLLEPIB.HHCJCDFCLOB.OCOGBOHOGGE_DbFileName;
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
		TodoLogger.Log(0, "!!!");
	}

	// // RVA: 0xE8BC98 Offset: 0xE8BC98 VA: 0xE8BC98
	public static void AFKGMCBJBJA()
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0xE8BDB0 Offset: 0xE8BDB0 VA: 0xE8BDB0
	private void BDGGNOAIIFK(float OLDAGCNLJOI_Progress)
	{
		TodoLogger.Log(0, "!!!");
	}

	// // RVA: 0xE8BF18 Offset: 0xE8BF18 VA: 0xE8BF18
	private void FFHCCIOCPAD()
	{
		string path = CGAHFOBGHIM_PersistentPlatformDataPath + "/snd/bgm";
		if(Directory.Exists(path))
		{
			long serverTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int idx = JCMJBMBMJAK_PersistentDataPath.Length;
			string[] files = Directory.GetFiles(path);
			for(int i = 0; i < files.Length; i++)
			{
				string name = files[i].Substring(idx);
				name.Replace('\\', '/');
				FECDBKKBAHO.FHOPNIJCFKA_FileInfo info = KLIJFOBEKBE.LBDOLHGDIEB_GetFileInfo(name);
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
		new BFGOCONGNDK().HJMKBCFJOOH_SaveStartBgInfo();
	}

	// // RVA: 0xE8C30C Offset: 0xE8C30C VA: 0xE8C30C
	// private int JGNEKCNFFDE() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BB69C Offset: 0x6BB69C VA: 0x6BB69C
	// // RVA: 0xE8C6D0 Offset: 0xE8C6D0 VA: 0xE8C6D0
	// private IEnumerator POMGAIOAGNC_RemoveOldFiles(IMCBBOAFION BHFHGFKBOHH) { }

	// // RVA: 0xE8C798 Offset: 0xE8C798 VA: 0xE8C798
	// public void KPMCJMIEMMB(IMCBBOAFION BHFHGFKBOHH) { }

	// // RVA: 0xE8C7E8 Offset: 0xE8C7E8 VA: 0xE8C7E8
	private void BEINKAGIHJB_CheckMediaFile()
	{
		if(ICCMKHKNAMJ.Count == 0)
			return;
		Regex r = new Regex(".+(usm|acb|awb)$");
		for(int i = 0; i < ICCMKHKNAMJ.Count; i++)
		{
			Match m = r.Match(ICCMKHKNAMJ[i].OIEAICNAMNB_LocalFileName);
			ICCMKHKNAMJ[i].FDDDLPAJIEJ_IsMediaFile = m.Success ? 1 : 0;
		}
	}
}
