using System;
using UnityEngine;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using XeSys.File;
using XeApp.Game;
using XeSys;
using XeApp.Game.Common;

public delegate bool OMIFMMJPMDJ(int INDDJNMPONH, float LNAHJANMJNM);
public delegate void OBHIGCFPKJN(string DOGDHKIEBJA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP);

public class KDLPEDBKMID
{
    public class EMEKAOMPFNC_LocalFileInfo
    {
        public string CJEKGLGBIHF_LocalPathRelativeToDataDir; // 0x8
        public string BLHCFFOHBNF_ServerPath; // 0xC
        public string NOCCPNGFFPF_FullLocalPath; // 0x10
        public int LGADCGFMLLD; // 0x14
    }

    public enum PHKOILLPHGG
    {
        LACMMENCAIF = 0,
        HGACHBEOOHD = 1,
        ODFDIFNIFPC = 2,
    }

	private StringBuilder JBBHNIACMFJ = new StringBuilder(256); // 0x8
	private List<KDLPEDBKMID.EMEKAOMPFNC_LocalFileInfo> JFEKDMEMKHE_FileToInstall = new List<KDLPEDBKMID.EMEKAOMPFNC_LocalFileInfo>(30); // 0xC
	public DJBHIFLHJLK FGGJNGCAFGK; // 0x18
	private Action LCIGLIDJILJ; // 0x1C
	private bool KOIGPANFBKP; // 0x20
	private bool LFPOPKJMGKA; // 0x21
	public float HANBBBBLLGP; // 0x24
	private bool PICLIFPDEOF; // 0x28
	private JEHIAIPJNJF_FileDownloader PMDNNKAPIKJ_FileDownloader; // 0x2C
	private float FGCMHIPPDFL; // 0x34
	private float LPHLENALMBE_InstallAutoWaitSec = 1.0f; // 0x38
	private WaitForEndOfFrame CGHFIPJFFKD = new WaitForEndOfFrame(); // 0x3C
	private static readonly string[] NFKOAFFBHOL = new string[13] {"snd/bgm/cs_bgm_tutorial.acb", 
																	"snd/bgm/cs_bgm_tutorial.awb",
																	"ct/dv/me/01/01_01.xab",
																	"ct/dv/me/01/02_01.xab",
																	"ct/dv/me/01/03_01.xab",
																	"ct/dv/me/01/04_01.xab",
																	"ct/dv/me/01/05_01.xab",
																	"ct/dv/me/01/06_01.xab",
																	"ct/dv/me/01/07_01.xab",
																	"ct/dv/me/01/10_01.xab",
																	"ly/083.xab",
																	"handmade/shader.xab",
																	"handmade/cmnparam.xab"}; // 0x4
	private static readonly string[] FJFFOIHEDID_SoundFilesFormat = new string[6] {"mc/{0}/bt001.xab",
																	"mc/{0}/ft.xab",
																	"mc/{0}/sc.xab",
																	"sc/{0:D4}.dat",
																	"snd/bgm/cs_w_{0:D4}.acb",
																	"snd/bgm/cs_w_{0:D4}.awb"}; // 0x8
	private static readonly string[] KJAAFBDBDOM_soundFilesFormat = new string[6] {"mc/{0}/bt001.xab",
																	"mc/{0}/ft.xab",
																	"mc/{0}/sc.xab",
																	"sc/{0:D4}.dat",
																	"snd/bgm/cs_w_{0:D4}.acb",
																	"snd/bgm/cs_w_{0:D4}_d.awb"}; // 0xC
	private static readonly string MFDEFIILPGM_StageFileFormat = "st/{0:D4}.xab"; // 0x10
	private static readonly string JOLFLDNELHO_VideoFileFormat = "mov/gm/dv/game_dv_{0:D4}_mv_{1}q{2:D1}.usm"; // 0x14
	private static readonly string NMFLPJMFPFN_MoveTrackFileFormat = "mc/{0}/bt002.xab"; // 0x18
	private static readonly string EMLADNPGDOG_VideoFileFormat = "mov/gm/dv/game_dv_{0:D4}_mv_{1}q{2:D1}.usm"; // 0x1C
	private static readonly string[] ABNBIJGFNBA_3dExtensionsFilesFormat = new string[6] {"mc/{0}/dr/cc/{1:D3}.xab",
																	"mc/{0}/dr/dc/{1:D3}.xab",
																	"mc/{0}/dr/dv/{1:D3}.xab",
																	"mc/{0}/dr/li/{1:D3}.xab",
																	"mc/{0}/dr/st/{1:D3}.xab",
																	"mc/{0}/dr/sc/{1:D3}.xab"}; // 0x20
	private static readonly string[] MOMNOGAGKHP = new string[2] {"snd/vo/diva/cs_diva_{0:D3}.acb", "snd/vo/diva/cs_diva_{0:D3}.awb"}; // 0x24
	private static readonly string[] BPKOEOEOBLD = new string[3] {"dv/cs/{0:D3}_{1:D3}.xab", "dv/bs/{0:D3}_{1:D3}.xab", "ct/dv/ps/{0:D2}_{1:D2}.xab"}; // 0x28
	private static readonly string[] EALKAGJANPD = new string[3] {"ct/dv/me/01/{0:D2}_{1:D2}.xab", "ct/dv/me/02/{0:D2}_{1:D2}.xab", "ct/dv/me/03/{0:D2}_{1:D2}.xab"}; // 0x2C
	private static readonly string[] ILINMFJBKAL = new string[3] {"vl/{0:D4}.xab", "ct/vl/01/{0:D2}_01.xab", "ct/vl/02/{0:D2}_01.xab"}; // 0x30
	private static readonly string[] KPBAICAFLPC = new string[3] {"snd/vo/pilot/cs_pilot_{0:D3}.acb", "snd/vo/pilot/cs_pilot_{0:D3}.awb", "ct/pl/{0:D3}.xab"}; // 0x34

	public static KDLPEDBKMID HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public OMIFMMJPMDJ OEPPEGHGNNO { get; set; } // 0x10 KPEKONPJHCL LKCDOGAFPNM NPJJMDFAIII
	public OBHIGCFPKJN MAIHLKPEHJN { get; set; } // 0x14 EAIFOAGPGGH KCLBNOKEPIG OCIMGEFKKLM
	public bool LNHFLJBGGJB_IsRunning { 
		get { // KOIPHFOBLOD 0xE7D688
			if(KOIGPANFBKP)
				return true;
			return JFEKDMEMKHE_FileToInstall.Count > 0;
		} 
	}
	public KDLPEDBKMID.PHKOILLPHGG CNDDKMJAIBG { get; set; } // 0x30 HMCLOEGDNBA HIGNHAEJKAH DFJLAMPMCMP

	// // RVA: 0xE7D730 Offset: 0xE7D730 VA: 0xE7D730
	public void OIKLOJMPBGA_SetInstallAutoWait(int COGJONKKALB_TimeMs)
	{
		if (COGJONKKALB_TimeMs < 1)
			COGJONKKALB_TimeMs = 0;
		else if (COGJONKKALB_TimeMs > 1999)
			COGJONKKALB_TimeMs = 2000;
		LPHLENALMBE_InstallAutoWaitSec = COGJONKKALB_TimeMs * 1.0f / 1000;
	}

	// // RVA: 0xE7D768 Offset: 0xE7D768 VA: 0xE7D768
	public void IJBGPAENLJA_OnAwake(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		LCIGLIDJILJ = this.LFKLIOKFGLP;
		CriFileRequestManager.HHCJCDFCLOB.GOEAHKDGBBH = () => {
			//0xE841D8
			return LNHFLJBGGJB_IsRunning;
		};
		CriFileRequestManager.HHCJCDFCLOB.JPNMBNEHBOC = this.BDOFDNICMLC_StartInstallIfNeeded;
	}

	// // RVA: 0xE7D90C Offset: 0xE7D90C VA: 0xE7D90C
	public void FFBCKMFKFME()
    {
        if(PMDNNKAPIKJ_FileDownloader != null)
		{
			PMDNNKAPIKJ_FileDownloader.Dispose();
			PMDNNKAPIKJ_FileDownloader = null;
		}
		CriFileRequestManager.HHCJCDFCLOB.GOEAHKDGBBH = null;
		CriFileRequestManager.HHCJCDFCLOB.JPNMBNEHBOC = null;
    }

	// // RVA: 0xE7D990 Offset: 0xE7D990 VA: 0xE7D990
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

	// // RVA: 0xE7DA9C Offset: 0xE7DA9C VA: 0xE7DA9C
	public void BAGMHFKPFIF()
    {
        LCIGLIDJILJ();
    }

	// // RVA: 0xE7DAC8 Offset: 0xE7DAC8 VA: 0xE7DAC8
	private void LFKLIOKFGLP()
	{
		if(JFEKDMEMKHE_FileToInstall.Count > 0)
		{
			if(KEHOJEJMGLJ.JNGKCPJBMBA_ServerPlatformUrl != null && CNDDKMJAIBG != KDLPEDBKMID.PHKOILLPHGG.HGACHBEOOHD/*1*/)
			{
				if(CNDDKMJAIBG != KDLPEDBKMID.PHKOILLPHGG.ODFDIFNIFPC/*2*/)
				{
					if(Time.realtimeSinceStartup - FGCMHIPPDFL < LPHLENALMBE_InstallAutoWaitSec)
						return;
				}
				LFPOPKJMGKA = true;
				N.a.StartCoroutineWatched(EOFJPNPFGDM_Coroutine_Install());
				LCIGLIDJILJ = this.OCGLHHHMILH;
			}
		}
	}

	// // RVA: 0xE7DD48 Offset: 0xE7DD48 VA: 0xE7DD48
	private void OCGLHHHMILH()
	{
		if(LFPOPKJMGKA)
			return;
		LCIGLIDJILJ = this.LFKLIOKFGLP;
	}

	// // RVA: 0xE7DDDC Offset: 0xE7DDDC VA: 0xE7DDDC
	public static bool ENEFCDLNAEF_IsFileExistsOnDisk(string KEIGHMAKAAC)
	{
		string path = "";
		if(KEIGHMAKAAC[0] == '/')
		{
			path = KEHOJEJMGLJ.CGAHFOBGHIM_PersistentPlatformDataPath + KEIGHMAKAAC;
		}
		else
		{
			path = KEHOJEJMGLJ.CGAHFOBGHIM_PersistentPlatformDataPath + AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash + KEIGHMAKAAC;
		}
		return FileSystemProxy.FileExists(path);
	}

	// // RVA: 0xE7E040 Offset: 0xE7E040 VA: 0xE7E040
	public bool BDOFDNICMLC_StartInstallIfNeeded(string KEIGHMAKAAC)
	{
		if(!ENEFCDLNAEF_IsFileExistsOnDisk(KEIGHMAKAAC))
		{
			string str = KPIAEBMBBPE_GetPathRelativeToDataDir(KEIGHMAKAAC);
			for(int i = 0; i < JFEKDMEMKHE_FileToInstall.Count; i++)
			{
				if(JFEKDMEMKHE_FileToInstall[i].CJEKGLGBIHF_LocalPathRelativeToDataDir == str)
				{
					TodoLogger.Log(TodoLogger.Filesystem, "Request need install for "+KEIGHMAKAAC+" : false, in dld list");
					return false;
				}
			}
			if(PMDNNKAPIKJ_FileDownloader != null)
			{
				if(PMDNNKAPIKJ_FileDownloader.MNAIIMMIMIO_IsFileDownloading(str))
				{
					TodoLogger.Log(TodoLogger.Filesystem, "Request need install for " + KEIGHMAKAAC+" : false, dlding");
					return false;
				}
			}
			EMEKAOMPFNC_LocalFileInfo d = new EMEKAOMPFNC_LocalFileInfo();
			d.CJEKGLGBIHF_LocalPathRelativeToDataDir = str;
			d.BLHCFFOHBNF_ServerPath = FAKFFDIFAAH_GetFullServerNameForLocalFile(str);
			d.NOCCPNGFFPF_FullLocalPath = FLBHKPMIJHP(str);
			JFEKDMEMKHE_FileToInstall.Add(d);
			FGCMHIPPDFL = Time.realtimeSinceStartup;
			TodoLogger.Log(TodoLogger.Filesystem, "Request need install for " + KEIGHMAKAAC+" : true");
			return true;
		}
		TodoLogger.Log(TodoLogger.Filesystem, "Request need install for " + KEIGHMAKAAC+" : false, already on disk");
		return false;
	}

	// // RVA: 0xE7E294 Offset: 0xE7E294 VA: 0xE7E294
	private string KPIAEBMBBPE_GetPathRelativeToDataDir(string KEIGHMAKAAC) // Platform path
	{
		JBBHNIACMFJ.Clear();
		JBBHNIACMFJ.Append(AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash);
		JBBHNIACMFJ.Append(KEHOJEJMGLJ.LBEPLOJBFCM_PlatformPrefix);
		if(KEIGHMAKAAC[0] != '/')
		{
			JBBHNIACMFJ.Append(AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash);
		}
		JBBHNIACMFJ.Append(KEIGHMAKAAC);
		return JBBHNIACMFJ.ToString();
	}

	// // RVA: 0xE7E4A8 Offset: 0xE7E4A8 VA: 0xE7E4A8
	private string FAKFFDIFAAH_GetFullServerNameForLocalFile(string CJEKGLGBIHF) // Download Path
	{
		string dir = Path.GetDirectoryName(CJEKGLGBIHF);
		dir = dir.Replace('\\','/');
		string fileName = Path.GetFileNameWithoutExtension(CJEKGLGBIHF);
		string ext = Path.GetExtension(CJEKGLGBIHF);
		
		uint val = BEEINMBNKNM_Encryption.DIKDKNIKPNJ((uint)IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.KBNGOBEAHIC_KeyPath, CJEKGLGBIHF);
		JBBHNIACMFJ.Clear();
		JBBHNIACMFJ.Append(KEHOJEJMGLJ.FLHOFIEOKDH_BaseUrl);
		JBBHNIACMFJ.Append(dir);
		JBBHNIACMFJ.Append(AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash);
		JBBHNIACMFJ.Append(fileName);
		JBBHNIACMFJ.Append("!s");
		JBBHNIACMFJ.AppendFormat("{0:x8}", val);
		JBBHNIACMFJ.Append("z!");
		JBBHNIACMFJ.Append(ext);
		return JBBHNIACMFJ.ToString();
	}

	// // RVA: 0xE7E870 Offset: 0xE7E870 VA: 0xE7E870
	private string FLBHKPMIJHP(string CJEKGLGBIHF) // Install Path
	{
		JBBHNIACMFJ.Clear();
		JBBHNIACMFJ.Append(KEHOJEJMGLJ.OGCDNCDMLCA_PersistentDataPath);
		JBBHNIACMFJ.Append(CJEKGLGBIHF);
		return JBBHNIACMFJ.ToString();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BB384 Offset: 0x6BB384 VA: 0x6BB384
	// // RVA: 0xE7DCBC Offset: 0xE7DCBC VA: 0xE7DCBC
	private IEnumerator EOFJPNPFGDM_Coroutine_Install()
	{
		// private KDLPEDBKMID.<>c__DisplayClass44_0 OPLBFCEPDCH; // 0x14			
			// public KDLPEDBKMID KIGBLACMODG; // 0x8
			// public PJKLMCGEJMK CPHFEPHDJIB; // 0xC
			// RVA: 0xE84268 Offset: 0xE84268 VA: 0xE84268
			// internal void EGDGJOPDNFF(JEHIAIPJNJF.HCJPJKCIBDL JGBPLIGAILE) { }
		// private KDLPEDBKMID.<>c__DisplayClass44_1 LBLMCMHMNGC; // 0x18
			// public int APGOAMNGFFF; // 0x8
			// RVA: 0xE849D8 Offset: 0xE849D8 VA: 0xE849D8
			//internal void FKJIINPOGKK() { }
			// RVA: 0xE849E4 Offset: 0xE849E4 VA: 0xE849E4
			//internal void BCMEPPIPGIB() { }
		// private KDLPEDBKMID.<>c__DisplayClass44_2 PHPPCOBECCA; // 0x1C
			//public int APGOAMNGFFF; // 0x8
			// RVA: 0xE849F8 Offset: 0xE849F8 VA: 0xE849F8
			//internal void EKHEBHFBKID() { }
			// RVA: 0xE84A04 Offset: 0xE84A04 VA: 0xE84A04
			//internal void OIIFKBGOJKO() { }
		// 0xE84A14
		int APGOAMNGFFF = 0;
		if(OEPPEGHGNNO == null)
		{
			OEPPEGHGNNO = (int INDDJNMPONH, float LNAHJANMJNM) => 
			{
				//0xE84258
				return true;
			};
		}
		if(MAIHLKPEHJN == null)
		{
			MAIHLKPEHJN = this.EEHMGCMAOAB;
		}
		GameManager.Instance.SetNeverSleep(true);
		OEPPEGHGNNO(1, 0.0f);
		while(!OEPPEGHGNNO(4, 0.0f))
		{
			yield return null;
		}
		PJKLMCGEJMK CPHFEPHDJIB = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		KOIGPANFBKP = true;
		HANBBBBLLGP = 0.0f;
		//LAB_00e84df8:
		while(true)
		{
			if(JFEKDMEMKHE_FileToInstall.Count == 0)
			{
				KOIGPANFBKP = false;
				KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.HJMKBCFJOOH();
				OEPPEGHGNNO(2, 100);
				GameManager.Instance.SetNeverSleep(false);
				LFPOPKJMGKA = false;
				yield break;
			}
			PMDNNKAPIKJ_FileDownloader = new JEHIAIPJNJF_FileDownloader(3);
			PMDNNKAPIKJ_FileDownloader.DOMFHDPMCCO_SetFilesToDownload(JFEKDMEMKHE_FileToInstall);
			JFEKDMEMKHE_FileToInstall.Clear();
			PMDNNKAPIKJ_FileDownloader.LBGNKOJFOFC = (JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo JGBPLIGAILE) => {
				//0xE84268
				GCGNICILKLD_AssetFileInfo fileinfo = DHBFAKEGDOG(JGBPLIGAILE.AJPIGKBIDDL_LocalFileName);
				if(fileinfo != null)
				{
					KEHOJEJMGLJ.GFOMKMANCPP(JGBPLIGAILE.ADHHKEMDOIK_LocalPath, fileinfo.CALJIGKCAAH_LastUpdated, fileinfo.HHPEMFKDHLK_FileHash, true);
					KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.OJCJPCHFPGO_DeleteFileInfo(JGBPLIGAILE.AJPIGKBIDDL_LocalFileName);
					PKKHIEAEDPC a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.NBHDIKJMLEN(JGBPLIGAILE.AJPIGKBIDDL_LocalFileName);
					if(a != null)
					{
						if(a.NKGJOAEDCPH.PAAPNEMBHGN_Day > 0)
						{
							FECDBKKBAHO.FHOPNIJCFKA_FileInfo b = KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.ANIJHEBLMGB(JGBPLIGAILE.AJPIGKBIDDL_LocalFileName, CPHFEPHDJIB.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), a.KKPAHLMJKIH_WavId);
							b.FNALNKKMKDC_ExpireTime = CPHFEPHDJIB.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() + a.NKGJOAEDCPH.PAAPNEMBHGN_Day * 24 * 60 * 60;
							b.GEJJEDDEPMI = a.NKGJOAEDCPH.PEOIMDCECDL;
						}
					}
				}
			};
			//LAB_00e85548:
			PMDNNKAPIKJ_FileDownloader.LAOEGNLOJHC();
			while(true)
			{
				yield return null;
				//2
				PMDNNKAPIKJ_FileDownloader.FBANBDCOEJL();
				if(PMDNNKAPIKJ_FileDownloader.CMCKNKKCNDK_Status == /*2*/JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.FEJIMBDPMKI_2_Success)
				{
					HANBBBBLLGP = 100.0f;
					OEPPEGHGNNO(3, 100);
					PMDNNKAPIKJ_FileDownloader.Dispose();
					PMDNNKAPIKJ_FileDownloader = null;
					// goto LAB_00e84df8
					break;
				}
				else
				{
					if(PMDNNKAPIKJ_FileDownloader.CMCKNKKCNDK_Status == /*4*/JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LPLEIJIFOKN_4_AllError)
					{
						string errorStr = "network";
						if(PMDNNKAPIKJ_FileDownloader.BHICPONFJKM_SpaceError)
							errorStr = "storage";
						if(StorageSupport.GetAvailableStorageSizeMB() > -1 && StorageSupport.GetAvailableStorageSizeMB() < 50)
							errorStr = "storage";
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
						if(errorStr == "storage")
						{
#endif
							APGOAMNGFFF = 0;
							MAIHLKPEHJN(errorStr, () => {
								//0xE849D8
								APGOAMNGFFF = 1;
							}, () => {
								//0xE849E4
								APGOAMNGFFF = -1;
							});
							//goto LAB_00e84f0c; // To 3
							//3
							//LAB_00e84f0c
							while(APGOAMNGFFF == 0)
							{
								yield return null;
							}
							// L 267
							PMDNNKAPIKJ_FileDownloader.PBIMGBKLDPP();
							if(APGOAMNGFFF != 1)
							{
								//goto LAB_00e85514;
								KOIGPANFBKP = false;
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
							PMDNNKAPIKJ_FileDownloader.PBIMGBKLDPP();
						}
#endif
						//goto LAB_00e84f9c;
						//4
						//LAB_00e84f9c;
						while(PMDNNKAPIKJ_FileDownloader.CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_0_None)
						{
							PMDNNKAPIKJ_FileDownloader.FBANBDCOEJL();
							yield return null;
						}
						//goto LAB_00e85548;
						PMDNNKAPIKJ_FileDownloader.LAOEGNLOJHC();
						continue;
					}
					HANBBBBLLGP = PMDNNKAPIKJ_FileDownloader.HCAJCKCOCHC();
					OEPPEGHGNNO(3, PMDNNKAPIKJ_FileDownloader.HCAJCKCOCHC());
					if(PMDNNKAPIKJ_FileDownloader.MNFGKBAEFFL_IsTimeout() || PMDNNKAPIKJ_FileDownloader.KAMPHNKAHAB_IsDiskFull)
					{
						//LAB_00e85288:
						PMDNNKAPIKJ_FileDownloader.PBIMGBKLDPP();
						//goto LAB_00e852c8;
						// To 5
						//5
						while(PMDNNKAPIKJ_FileDownloader.CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_0_None)
						{
							PMDNNKAPIKJ_FileDownloader.FBANBDCOEJL();
							yield return null;
						}
						APGOAMNGFFF = 0;
						string errorStr = "network";
						if(!PMDNNKAPIKJ_FileDownloader.KAMPHNKAHAB_IsDiskFull)
							errorStr = "storage";
						int avaiableSpace = StorageSupport.GetAvailableStorageSizeMB();
						if(avaiableSpace >= 0 && avaiableSpace < 50)
							errorStr = "storage";
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
						if(errorStr == "storage")
						{
#endif
							MAIHLKPEHJN(errorStr, () => {
								//0xE849F8
								APGOAMNGFFF = 1;
							}, () => {
								//0xE84A04
								APGOAMNGFFF = -1;
							});
							//goto LAB_00e85468;
							//6
							while(APGOAMNGFFF == 0)
								yield return null;
							PMDNNKAPIKJ_FileDownloader.PBIMGBKLDPP();
							if(APGOAMNGFFF != 1)
							{
								//LAB_00e85514:
								KOIGPANFBKP = false;
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
							PMDNNKAPIKJ_FileDownloader.PBIMGBKLDPP();
						}
#endif
						while(PMDNNKAPIKJ_FileDownloader.CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_0_None)
						{
							PMDNNKAPIKJ_FileDownloader.FBANBDCOEJL();
							yield return null;
							// goto 7
							//7
							//goto LAB_00e854dc;
						}
						//goto LAB_00e85548;
						PMDNNKAPIKJ_FileDownloader.LAOEGNLOJHC();
						continue;
					}
					else
					{
						//goto LAB_00e85550;
						// to 2
						continue;
					}
				}
			}
		}
	}

	// // RVA: 0xE7ECF4 Offset: 0xE7ECF4 VA: 0xE7ECF4
	private GCGNICILKLD_AssetFileInfo DHBFAKEGDOG(string CJEKGLGBIHF)
	{
		for(int i = 0; i < KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.KGHAJGGMPKL_Files.Count; i++)
		{
			if(KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.KGHAJGGMPKL_Files[i].OIEAICNAMNB_LocalFileName == CJEKGLGBIHF)
				return KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.KGHAJGGMPKL_Files[i];
		}
		return null;
	}

	// // RVA: 0xE7EEF8 Offset: 0xE7EEF8 VA: 0xE7EEF8
	public bool EGIFDIFALKK(string KEIGHMAKAAC)
	{
		return DHBFAKEGDOG(KPIAEBMBBPE_GetPathRelativeToDataDir(KEIGHMAKAAC)) != null;
	}

	// // RVA: 0xE7EF18 Offset: 0xE7EF18 VA: 0xE7EF18
	private void EEHMGCMAOAB(string DOGDHKIEBJA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP)
	{
		NEFKBBNKNPP();
	}

	public IEnumerator HFMOAJDHDHJ_Coroutine(int GHBPLHBNMBK, Action<bool> cb)
	{
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
		while(true)
		{
			List<string> files = new List<string>();
			StringBuilder str = new StringBuilder(128);
			for(int i = 0; i < NFKOAFFBHOL.Length; i++)
			{
				if(!FileSystemProxy.FileExists(Application.persistentDataPath + "/data" + KPIAEBMBBPE_GetPathRelativeToDataDir(NFKOAFFBHOL[i])))
				{
					files.Add(NFKOAFFBHOL[i]);
				}
			}
			KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[GHBPLHBNMBK - 1];
			str.SetFormat("mc/{0:D4}/sc.xab", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId);
			if(!FileSystemProxy.FileExists(Application.persistentDataPath + "/data" + KPIAEBMBBPE_GetPathRelativeToDataDir(str.ToString())))
				files.Add(str.ToString());

			if(files.Count == 0)
				break;

			bool retry = false;
			yield return Co.R(FileSystemProxy.WaitServerInfo("Missing \n"+files[0] + (files.Count > 1 ? "\n + " + (files.Count - 1)+" files" : "") + ".", true, true, (PopupButton.ButtonLabel btn) =>
			{
				if(btn == PopupButton.ButtonLabel.Retry)
					retry = true;
			}));
			if(retry)
				continue;
			BBGDKLLEPIB.FLHOFIEOKDH_BaseUrl = "http://"+FileSystemProxy.foundServer+":8000";

			bool res = HFMOAJDHDHJ(GHBPLHBNMBK);
			if(res)
			{
				while(LNHFLJBGGJB_IsRunning)
					yield return null;
			}
			else
				break;
		}
		cb(false);
#else
		bool res = HFMOAJDHDHJ(GHBPLHBNMBK);
		cb(res);
		yield break;
#endif
	}

	// // RVA: 0xE7EF44 Offset: 0xE7EF44 VA: 0xE7EF44
	public bool HFMOAJDHDHJ(int GHBPLHBNMBK)
	{
		StringBuilder str = new StringBuilder(128);
		bool b = false;
		for(int i = 0; i < NFKOAFFBHOL.Length; i++)
		{
			b |= BDOFDNICMLC_StartInstallIfNeeded(NFKOAFFBHOL[i]);
		}
		KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[GHBPLHBNMBK - 1];
		str.SetFormat("mc/{0:D4}/sc.xab", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId);
		b |= BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
		return b;
	}

	// // RVA: 0xE7F26C Offset: 0xE7F26C VA: 0xE7F26C
	private static string[] JAAOIKIALFJ(int ECOIBKOIPFP)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.DDGHBNLOBAJ_GetCueEncryptedKey("cs_w_"+ECOIBKOIPFP.ToString("D4")) != 0)
		{
			return KJAAFBDBDOM_soundFilesFormat;
		}
		else
		{
			return FJFFOIHEDID_SoundFilesFormat;
		}
	}

	// // RVA: 0xE7F44C Offset: 0xE7F44C VA: 0xE7F44C
	public bool OKJCGCOGDIA_DownloadSongDatas(int ECOIBKOIPFP_WavId, int DNHLEPCFPFC_SongId, int MOBOJNCPCGD_VidQuality, int HADONLEBKLD_OnStageDivaNum)
	{
		StringBuilder str = new StringBuilder(128);
		str.SetFormat(MFDEFIILPGM_StageFileFormat, DNHLEPCFPFC_SongId);
		bool res = BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
		if(MOBOJNCPCGD_VidQuality > 0)
		{
			str.SetFormat(JOLFLDNELHO_VideoFileFormat, ECOIBKOIPFP_WavId, "", MOBOJNCPCGD_VidQuality);
			res |= BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
		}
		string[] strs = JAAOIKIALFJ(ECOIBKOIPFP_WavId);
		for(int i = 0; i < strs.Length; i++)
		{
			if(strs[i].IndexOf("mc") == 0)
			{
				string waveName = GameManager.Instance.GetWavDirectoryName(ECOIBKOIPFP_WavId, strs[i], HADONLEBKLD_OnStageDivaNum, 1, 1, false);
				str.SetFormat(strs[i], waveName);
			}
			else
			{
				str.SetFormat(strs[i], ECOIBKOIPFP_WavId);
			}
			res |= BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
		}
		return res;
	}

	// // RVA: 0xE7F898 Offset: 0xE7F898 VA: 0xE7F898
	public void LIDGJKCOGFA(int ECOIBKOIPFP, int DNHLEPCFPFC, int MOBOJNCPCGD, List<string> NNDGIAEFMOG, int HADONLEBKLD)
	{
		StringBuilder str = new StringBuilder(124);
		string[] sounds = JAAOIKIALFJ(ECOIBKOIPFP);
		for(int i = 0; i < sounds.Length; i++)
		{
			if(sounds[i].IndexOf("mc", 0) == 0)
			{
				str.SetFormat(sounds[i], GameManager.Instance.GetWavDirectoryName(ECOIBKOIPFP, sounds[i], HADONLEBKLD, 1, 1, false));
			}
			else
			{
				str.SetFormat(sounds[i], ECOIBKOIPFP);
			}
			NNDGIAEFMOG.Add(str.ToString());
		}
		str.SetFormat(MFDEFIILPGM_StageFileFormat, DNHLEPCFPFC);
		NNDGIAEFMOG.Add(str.ToString());
		if(MOBOJNCPCGD > 0)
		{
			str.SetFormat(JOLFLDNELHO_VideoFileFormat, ECOIBKOIPFP, "", MOBOJNCPCGD);
			NNDGIAEFMOG.Add(str.ToString());
		}
	}

	// // RVA: 0xE7FD38 Offset: 0xE7FD38 VA: 0xE7FD38
	public bool KEILLGAJEPF_AddRhythmResources(int ECOIBKOIPFP_WavId, int IMPALJEMHJJ_OverridePrimeId, int DNHLEPCFPFC_SongId, List<int> KJAIAJIIOMA_MusicCameraCutinList, List<int> DJPOMCAOKKD_DivaCutinList, List<int> KBGIODFCIGN_DivaExtensionCutinList, List<int> LMIFMHACFID_StageLightingList, List<int> DDFCBCNPGHD_StageExtensionList, List<int> MEJEDAJBJKN_SpecialMovieResource, int MCFPOJBDIHP_VidQuality, List<int> HPDJEIFEADB_StageChangerList, int HADONLEBKLD_OnStageDivaNum)
	{
		bool res = OKJCGCOGDIA_DownloadSongDatas(ECOIBKOIPFP_WavId, DNHLEPCFPFC_SongId, MCFPOJBDIHP_VidQuality, HADONLEBKLD_OnStageDivaNum);
		if(IMPALJEMHJJ_OverridePrimeId == 2)
		{
			string waveName = GameManager.Instance.GetWavDirectoryName(ECOIBKOIPFP_WavId, NMFLPJMFPFN_MoveTrackFileFormat, HADONLEBKLD_OnStageDivaNum, 2, 1, true);
			res |= BDOFDNICMLC_StartInstallIfNeeded(string.Format(NMFLPJMFPFN_MoveTrackFileFormat, waveName));
		}
		List<int>[] l = new List<int>[6];
		l[0] = KJAIAJIIOMA_MusicCameraCutinList;
		l[1] = DJPOMCAOKKD_DivaCutinList;
		l[2] = KBGIODFCIGN_DivaExtensionCutinList;
		l[3] = LMIFMHACFID_StageLightingList;
		l[4] = DDFCBCNPGHD_StageExtensionList;
		l[5] = HPDJEIFEADB_StageChangerList;
		StringBuilder str = new StringBuilder(128);
		for(int i = 0; i < ABNBIJGFNBA_3dExtensionsFilesFormat.Length; i++)
		{
			foreach(int r in l[i])
			{
				if(r > 0)
				{
					string waveName = GameManager.Instance.GetWavDirectoryName(ECOIBKOIPFP_WavId, ABNBIJGFNBA_3dExtensionsFilesFormat[i], HADONLEBKLD_OnStageDivaNum, 1, r, false);
					str.SetFormat(ABNBIJGFNBA_3dExtensionsFilesFormat[i], waveName, r);
					res |= BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
				}
			}
		}
		if(MCFPOJBDIHP_VidQuality > 0 && MEJEDAJBJKN_SpecialMovieResource[0] > 0)
		{
			str.SetFormat("dr_{0:D3}_", MEJEDAJBJKN_SpecialMovieResource[0]);
			str.SetFormat(EMLADNPGDOG_VideoFileFormat, ECOIBKOIPFP_WavId, str.ToString(), MCFPOJBDIHP_VidQuality);
			res |= BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
		}
		return res;
	}

	// // RVA: 0xE806E8 Offset: 0xE806E8 VA: 0xE806E8
	public void IDCJNAFJLAA(int ECOIBKOIPFP, int IMPALJEMHJJ, int DNHLEPCFPFC, List<int> KJAIAJIIOMA, List<int> DJPOMCAOKKD, List<int> KBGIODFCIGN, List<int> LMIFMHACFID, List<int> DDFCBCNPGHD, List<int> MEJEDAJBJKN, int MCFPOJBDIHP, List<int> HPDJEIFEADB, List<string> NNDGIAEFMOG, int HADONLEBKLD)
	{
		StringBuilder str = new StringBuilder(128);
		LIDGJKCOGFA(ECOIBKOIPFP, DNHLEPCFPFC, MCFPOJBDIHP, NNDGIAEFMOG, HADONLEBKLD);
		if(IMPALJEMHJJ == 2)
		{
			str.SetFormat(NMFLPJMFPFN_MoveTrackFileFormat, GameManager.Instance.GetWavDirectoryName(ECOIBKOIPFP, NMFLPJMFPFN_MoveTrackFileFormat, HADONLEBKLD, 2, 1, true));
			NNDGIAEFMOG.Add(str.ToString());
		}
		List<int>[] l = new List<int>[6];
		l[0] = KJAIAJIIOMA;
		l[1] = DJPOMCAOKKD;
		l[2] = KBGIODFCIGN;
		l[3] = LMIFMHACFID;
		l[4] = DDFCBCNPGHD;
		l[5] = HPDJEIFEADB;
		for(int i = 0; i < ABNBIJGFNBA_3dExtensionsFilesFormat.Length; i++)
		{
			foreach(var l2 in l[i])
			{
				if(l2 > 0)
				{
					str.SetFormat(ABNBIJGFNBA_3dExtensionsFilesFormat[i], GameManager.Instance.GetWavDirectoryName(ECOIBKOIPFP, ABNBIJGFNBA_3dExtensionsFilesFormat[i], HADONLEBKLD, 1, l2, false), l2);
					NNDGIAEFMOG.Add(str.ToString());
				}
			}
		}
		if(MEJEDAJBJKN.Count > 0)
		{
			if(MCFPOJBDIHP > 0 && MEJEDAJBJKN[0] > 0)
			{
				StringBuilder str2 = new StringBuilder();
				str2.SetFormat("dr_{0:D3}_", MEJEDAJBJKN[0]);
				str.SetFormat(EMLADNPGDOG_VideoFileFormat, ECOIBKOIPFP, str2, MCFPOJBDIHP);
				NNDGIAEFMOG.Add(str.ToString());
			}
		}
	}

	// // RVA: 0xE81148 Offset: 0xE81148 VA: 0xE81148
	public bool NMFCNFFFMAC_InstallDivaCostume(int AHHJLDLAPAN, int EGNLGHDHDDH, bool MMNIIDPMDNP)
	{
		StringBuilder str = new StringBuilder();
		bool res = false;
		for(int i = 0; i < MOMNOGAGKHP.Length; i++)
		{
			str.SetFormat(MOMNOGAGKHP[i], AHHJLDLAPAN);
			res |= BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
		}
		for(int i = 0; i < BPKOEOEOBLD.Length; i++)
		{
			str.SetFormat(BPKOEOEOBLD[i], AHHJLDLAPAN, EGNLGHDHDDH);
			res |= BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
		}
		if(MMNIIDPMDNP)
		{
			for(int i = 0; i < EALKAGJANPD.Length; i++)
			{
				str.SetFormat(EALKAGJANPD[i], AHHJLDLAPAN, EGNLGHDHDDH);
				res |= BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
			}
		}
		return res;
	}

	// // RVA: 0xE8164C Offset: 0xE8164C VA: 0xE8164C
	// public void EINPFPOEPHP(int AHHJLDLAPAN, int EGNLGHDHDDH, bool MMNIIDPMDNP, List<string> NNDGIAEFMOG) { }

	// // RVA: 0xE81BB0 Offset: 0xE81BB0 VA: 0xE81BB0
	public bool FKIJBFJBIOC(int JBGIHPHNDKH, bool MMNIIDPMDNP)
	{
		LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[EKLNMHFCAOI.DEACAHNLMNI_getItemId(JBGIHPHNDKH) - 1];
		if (cos == null)
			return NMFCNFFFMAC_InstallDivaCostume(1, 1, MMNIIDPMDNP);
		else
			return NMFCNFFFMAC_InstallDivaCostume(cos.AHHJLDLAPAN_PrismDivaId, cos.DAJGPBLEEOB_PrismCostumeModelId, MMNIIDPMDNP);
	}

	// // RVA: 0xE81D54 Offset: 0xE81D54 VA: 0xE81D54
	// public void GJPDNBOCINF(int JBGIHPHNDKH, bool MMNIIDPMDNP, List<string> NNDGIAEFMOG) { }

	// // RVA: 0xE81EF8 Offset: 0xE81EF8 VA: 0xE81EF8
	public bool CKANBNPEIJD(int LLOBHDMHJIG, int PFGJJLGLPAC)
	{
		StringBuilder str = new StringBuilder();
		JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[LLOBHDMHJIG - 1];
		bool res = false;
		for(int i = 0; i < ILINMFJBKAL.Length; i++)
		{
			str.SetFormat(ILINMFJBKAL[i], valk.DAJGPBLEEOB_ModelId);
			res |= BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
		}
		for(int i = 0; i < KPBAICAFLPC.Length; i++)
		{
			str.SetFormat(KPBAICAFLPC[i], PFGJJLGLPAC);
			res |= BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
		}
		return res;
	}

	// // RVA: 0xE82324 Offset: 0xE82324 VA: 0xE82324
	// public void MKJABJDHKNO(int LLOBHDMHJIG, int PFGJJLGLPAC, List<string> NNDGIAEFMOG) { }

	// // RVA: 0xE82798 Offset: 0xE82798 VA: 0xE82798
	public bool OANDCKGGJIP(int JCNLIANKPAA)
	{
		JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[EKLNMHFCAOI.DEACAHNLMNI_getItemId(JCNLIANKPAA) - 1];
		return CKANBNPEIJD(valk.GPPEFLKGGGJ_Id, valk.PFGJJLGLPAC_PilotId);
	}

	// // RVA: 0xE82944 Offset: 0xE82944 VA: 0xE82944
	// public void HEBLFJFCCLF(int JCNLIANKPAA, List<string> NNDGIAEFMOG) { }
}
