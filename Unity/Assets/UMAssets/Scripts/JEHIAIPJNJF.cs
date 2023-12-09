using System.Collections.Generic;
using System;
using System.Text;
using XeSys;
using UnityEngine;
using System.Threading;
using System.IO;
using CriWare;
using System.Security.Cryptography;

public class BatchInstallerException : Exception
{
	// RVA: 0x18F06EC Offset: 0x18F06EC VA: 0x18F06EC
	public BatchInstallerException() : base() { }

	// RVA: 0x18F0770 Offset: 0x18F0770 VA: 0x18F0770
	public BatchInstallerException(string message) : base(message) { }

	// RVA: 0x18F07FC Offset: 0x18F07FC VA: 0x18F07FC
	public BatchInstallerException(string message, Exception inner) : base(message, inner) { }
}

[System.Obsolete("Use JEHIAIPJNJF_FileDownloader", true)]
public class JEHIAIPJNJF { }
public class JEHIAIPJNJF_FileDownloader : IDisposable
{
    public enum NKLKJEOKIFO_Status
    {
        PBIMGBKLDPP_None = 0,
        JGHMJIGGJHI = 1,
        FEJIMBDPMKI_2 = 2,
        LLGCBKEOHNP = 3,
        LPLEIJIFOKN_Error = 4,
        DNCJBLFALPA = 5,
    }


	public class HCJPJKCIBDL_DldFileInfo
    {
        public string AJPIGKBIDDL_LocalFileName; // 0x8
        public string NFCMNIEHJML_ServerPath; // 0xC
        public string ADHHKEMDOIK_LocalPath; // 0x10
        public int OIPCCBHIKIA_Idx; // 0x14
        public double KMABBBKJFCB_Percent; // 0x18
        public bool NEDNDAKLBMJ; // 0x20
        public bool IKBKLPNADJM; // 0x21
        public GCGNICILKLD_AssetFileInfo LAPFOLJGJMB_AssetFileInfo; // 0x24
    }

    public class AFGDFAJEBFA_DldInfo
    {
        public CriFsWebInstaller.StatusInfo IOKJFDPOEFP_InstallerStatusInfo; // 0x8
        public JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo ICKGJODOCBB; // 0x28
        public bool GGFGJEDLKNC; // 0x2C
        public float LBNOBJFOKMI; // 0x30 // timeout detector
        public long NPKGIPPJGEI; // 0x38 // current size received
        public int JBPJJGNGMFG; // 0x40
    }
 
    public delegate void FMOECHMCHPE(JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo KOGBMDOONFA);
    
	public static bool MLILLALMIPI_Initialized = false; // 0x0
	public const int AEFPOPCGGJJ = 3;
	public static int GOFLMGPGMKO_Timeout = 40; // 0x4
	public static float GCKDIGMAMND = 60.0f; // 0x8
	public static bool ANONIPNPMMA = false; // 0xC
	private static int GKJDDNOBIPM = 60; // 0x10
	private static List<CriFsWebInstaller> CICJCFPNCNO = new List<CriFsWebInstaller>(); // 0x14
	public JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status CMCKNKKCNDK_Status; // 0x8
	public bool BHICPONFJKM_SpaceError; // 0xC // disk space error ?
	private List<JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo> JOJMBFBGMGN_DldQueue; // 0x10
	public JEHIAIPJNJF_FileDownloader.FMOECHMCHPE LBGNKOJFOFC; // 0x14
	private Queue<CriFsWebInstaller> GBFHGDHNDIE_WebInstallerPool; // 0x18
	private List<CriFsWebInstaller> KJIGCCPJBFK_List; // 0x1C
	private JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo[] JLNFKNICIFD_DownloadsInfo; // 0x20
	private Dictionary<CriFsWebInstaller, JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo> PLDKOCEHDAL_DldInfoByInstaller; // 0x24
	private bool OILIGLGDNAD; // 0x28
	private bool BIBKLAMCKGN; // 0x29
	private int EMAEFFGBFIB; // 0x2C
	public bool KAMPHNKAHAB_IsDiskFull; // 0x30
	private int OEMNJCADFLL_AllowedFileOnDisk; // 0x34

	// // RVA: 0x1C34424 Offset: 0x1C34424 VA: 0x1C34424
	public static void BNGLMLOLPEL_Initialize()
	{
		if (!MLILLALMIPI_Initialized)
		{
			CriFsWebInstaller.ModuleConfig config = CriFsWebInstaller.defaultModuleConfig;
			config.numInstallers = 6;
			config.inactiveTimeoutSec = (uint)GOFLMGPGMKO_Timeout;
			CriFsWebInstaller.InitializeModule(config);
			MLILLALMIPI_Initialized = true;
		}
	}

	// // RVA: 0x1C34554 Offset: 0x1C34554 VA: 0x1C34554
	public static void IKPHNPJFNEG_Finalize()
	{
		CriFsWebInstaller.FinalizeModule();
		MLILLALMIPI_Initialized = false;
	}

	// // RVA: 0x1C34638 Offset: 0x1C34638 VA: 0x1C34638
	private int FCPPMGNCGNO()
	{
		int res = 0;
		for(int i = 0; i < JOJMBFBGMGN_DldQueue.Count; i++)
		{
			if(!JOJMBFBGMGN_DldQueue[i].IKBKLPNADJM)
			{
				if(JOJMBFBGMGN_DldQueue[i].NEDNDAKLBMJ)
				{
					res = res + 1;
				}
			}
			else
			{
				res = res + 1;
			}
		}
		
		return JOJMBFBGMGN_DldQueue.Count - res;
	}

	// // RVA: 0x1C34784 Offset: 0x1C34784 VA: 0x1C34784
	private int IOBFPLEDMOL()
	{
		for(int i = 0; i < JOJMBFBGMGN_DldQueue.Count; i++)
		{
			if(!JOJMBFBGMGN_DldQueue[i].IKBKLPNADJM)
			{
				if(!JOJMBFBGMGN_DldQueue[i].NEDNDAKLBMJ)
				{
					return i;
				}
			}
		}
		return -1;
	}

	// // RVA: 0x1C348D0 Offset: 0x1C348D0 VA: 0x1C348D0
	public float HCAJCKCOCHC()
	{
		double res = 0.0f;
		if(CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.FEJIMBDPMKI_2 && JOJMBFBGMGN_DldQueue != null)
		{
			for(int i = 0; i < JOJMBFBGMGN_DldQueue.Count; i++)
			{
				res += JOJMBFBGMGN_DldQueue[i].KMABBBKJFCB_Percent;
			}
			res = res * 100.0f / JOJMBFBGMGN_DldQueue.Count;
		}
		return (float)res;
	}

	// RVA: 0x1C34A10 Offset: 0x1C34A10 VA: 0x1C34A10
	public JEHIAIPJNJF_FileDownloader(int JAGOLJBNFMP_NumSimultDld = 3)
	{
		KAMPHNKAHAB_IsDiskFull = true;
		CMCKNKKCNDK_Status = JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_None;
		GBFHGDHNDIE_WebInstallerPool = new Queue<CriFsWebInstaller>();
		KJIGCCPJBFK_List = new List<CriFsWebInstaller>();
		JLNFKNICIFD_DownloadsInfo = new AFGDFAJEBFA_DldInfo[JAGOLJBNFMP_NumSimultDld];
		PLDKOCEHDAL_DldInfoByInstaller = new Dictionary<CriFsWebInstaller, JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo>(JAGOLJBNFMP_NumSimultDld);
		for(int i = 0; i < JAGOLJBNFMP_NumSimultDld; i++)
		{
			CriFsWebInstaller wi = new CriFsWebInstaller();
			JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo a = new JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo();
			a.IOKJFDPOEFP_InstallerStatusInfo = wi.GetStatusInfo();

			GBFHGDHNDIE_WebInstallerPool.Enqueue(wi);
			JLNFKNICIFD_DownloadsInfo[i] = a;
			PLDKOCEHDAL_DldInfoByInstaller[wi] = a;
		}
	}

	// // RVA: 0x1C34CE0 Offset: 0x1C34CE0 VA: 0x1C34CE0 Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0x1C34E78 Offset: 0x1C34E78 VA: 0x1C34E78 Slot: 4
	public void Dispose()
    {
		PEFNBFCMIBL(false);
		GC.SuppressFinalize(this);
    }

	// // RVA: 0x1C34F08 Offset: 0x1C34F08 VA: 0x1C34F08
	public void DOMFHDPMCCO_AddFiles(List<GCGNICILKLD_AssetFileInfo> IDJBKGBMDAJ, string JCILKDKNDLE_BaseUrl, string OGCDNCDMLCA_LocalPath)
	{
		StringBuilder str = new StringBuilder(256);
		BIBKLAMCKGN = false;
		
		JOJMBFBGMGN_DldQueue = new List<JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo>(IDJBKGBMDAJ.Count);
		for(int i = 0; i < IDJBKGBMDAJ.Count; i++)
		{
			HCJPJKCIBDL_DldFileInfo data = new HCJPJKCIBDL_DldFileInfo();
			data.AJPIGKBIDDL_LocalFileName = IDJBKGBMDAJ[i].OIEAICNAMNB_LocalFileName;
			str.Set(JCILKDKNDLE_BaseUrl);
			str.Append(IDJBKGBMDAJ[i].OIEAICNAMNB_LocalFileName);
			data.NFCMNIEHJML_ServerPath = FileSystemProxy.ConvertURL(JCILKDKNDLE_BaseUrl + IDJBKGBMDAJ[i].MFBMBPJAADA_FileName);
			str.Set(OGCDNCDMLCA_LocalPath);
			str.Append(IDJBKGBMDAJ[i].OIEAICNAMNB_LocalFileName);
			data.LAPFOLJGJMB_AssetFileInfo = IDJBKGBMDAJ[i];
			data.ADHHKEMDOIK_LocalPath = str.ToString();
			data.OIPCCBHIKIA_Idx = i;
			JOJMBFBGMGN_DldQueue.Add(data);
		}
		
		CMCKNKKCNDK_Status = JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_None;
	}

	// // RVA: 0x1C352A0 Offset: 0x1C352A0 VA: 0x1C352A0
	public void DOMFHDPMCCO_SetFilesToDownload(List<KDLPEDBKMID.EMEKAOMPFNC_LocalFileInfo> CEKHMLAEKIK)
	{
		JOJMBFBGMGN_DldQueue = new List<HCJPJKCIBDL_DldFileInfo>(CEKHMLAEKIK.Count);
		for(int i = 0; i < CEKHMLAEKIK.Count; i++)
		{
			HCJPJKCIBDL_DldFileInfo data = new HCJPJKCIBDL_DldFileInfo();
			data.AJPIGKBIDDL_LocalFileName = CEKHMLAEKIK[i].CJEKGLGBIHF_LocalPathRelativeToDataDir;
			data.NFCMNIEHJML_ServerPath = CEKHMLAEKIK[i].BLHCFFOHBNF_ServerPath;
			data.ADHHKEMDOIK_LocalPath = CEKHMLAEKIK[i].NOCCPNGFFPF_FullLocalPath;
			data.OIPCCBHIKIA_Idx = i;
			JOJMBFBGMGN_DldQueue.Add(data);
		}

		CMCKNKKCNDK_Status = NKLKJEOKIFO_Status.PBIMGBKLDPP_None;
	}

	// // RVA: 0x1C354B8 Offset: 0x1C354B8 VA: 0x1C354B8
	public bool MNAIIMMIMIO_IsFileDownloading(string CJEKGLGBIHF)
	{
		for(int i = 0; i < JOJMBFBGMGN_DldQueue.Count; i++)
		{
			if(JOJMBFBGMGN_DldQueue[i].AJPIGKBIDDL_LocalFileName == CJEKGLGBIHF)
				return true;
				
		}
		return false;
	}

	// // RVA: 0x1C355BC Offset: 0x1C355BC VA: 0x1C355BC
	public void LAOEGNLOJHC()
	{
		Debug.Log(string.Format(JpStringLiterals.StringLiteral_11855, CMCKNKKCNDK_Status.ToString()));
		IMDNPMAIJFO_UpdateStorageInfo();
		BHICPONFJKM_SpaceError = false;
		if(CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_None/*0*/)
			return;
		Debug.Log(JpStringLiterals.StringLiteral_11856);
		CMCKNKKCNDK_Status = JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.JGHMJIGGJHI/*1*/;
	}

	// // RVA: 0x1C3578C Offset: 0x1C3578C VA: 0x1C3578C
	public void PBIMGBKLDPP()
	{
		UnityEngine.Debug.Log(string.Format(JpStringLiterals.StringLiteral_11857, CMCKNKKCNDK_Status.ToString()));
		if(CMCKNKKCNDK_Status < JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LLGCBKEOHNP/*3*/ || CMCKNKKCNDK_Status > JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LPLEIJIFOKN_Error/*4*/)
		{
			if(CMCKNKKCNDK_Status == JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.FEJIMBDPMKI_2/*2*/)
			{
				CMCKNKKCNDK_Status = JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_None/*0*/;
				return;
			}
			if(CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.JGHMJIGGJHI/*1*/)
			{
				return;
			}
		}
		UnityEngine.Debug.Log(JpStringLiterals.StringLiteral_11858);
		for(int i = 0; i < KJIGCCPJBFK_List.Count; i++)
		{
			CriFsWebInstaller installer = KJIGCCPJBFK_List[i];
			JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo info = PLDKOCEHDAL_DldInfoByInstaller[installer];
			installer.Stop();
			if(info.ICKGJODOCBB != null)
			{
				info.ICKGJODOCBB.KMABBBKJFCB_Percent = 0;
				info.ICKGJODOCBB.NEDNDAKLBMJ = false;
				info.ICKGJODOCBB.IKBKLPNADJM = false;
				info.ICKGJODOCBB = null;
			}
		}
		CMCKNKKCNDK_Status = JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.DNCJBLFALPA/*5*/;
		EMAEFFGBFIB = 0;
	}

	// // RVA: 0x1C35A48 Offset: 0x1C35A48 VA: 0x1C35A48
	public void FBANBDCOEJL()
	{
		if(OEMNJCADFLL_AllowedFileOnDisk > -1)
		{
			OEMNJCADFLL_AllowedFileOnDisk = OEMNJCADFLL_AllowedFileOnDisk - 1;
			if(OEMNJCADFLL_AllowedFileOnDisk == 0)
			{
				IMDNPMAIJFO_UpdateStorageInfo();
			}
		}
		if(CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.JGHMJIGGJHI/*1*/)
		{
			if(CMCKNKKCNDK_Status == JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.DNCJBLFALPA/*5*/)
			{
				CriFsWebInstaller.ExecuteMain();
				PKDGOJNCLBK();
				string logTxt = "";
				if(KJIGCCPJBFK_List.Count == 0)
				{
					logTxt = JpStringLiterals.StringLiteral_11859;
				}
				else
				{
					Debug.Log(string.Format(JpStringLiterals.StringLiteral_11860, EMAEFFGBFIB));
					EMAEFFGBFIB = EMAEFFGBFIB + 1;
					if(EMAEFFGBFIB < GKJDDNOBIPM)
						return;
					Debug.Log(JpStringLiterals.StringLiteral_11861);
					int numInstaller = KJIGCCPJBFK_List.Count;
					Debug.Log(string.Format(JpStringLiterals.StringLiteral_11862, numInstaller));
					while(KJIGCCPJBFK_List.Count > 0)
					{
						CriFsWebInstaller wi = KJIGCCPJBFK_List[0];
						JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo info = PLDKOCEHDAL_DldInfoByInstaller[wi];
						KJIGCCPJBFK_List.RemoveAt(0);
						PLDKOCEHDAL_DldInfoByInstaller.Remove(wi);
						if(info.ICKGJODOCBB != null)
						{
							info.ICKGJODOCBB.IKBKLPNADJM = false;
							info.ICKGJODOCBB.NEDNDAKLBMJ = false;
							info.ICKGJODOCBB.KMABBBKJFCB_Percent = 0;
						}
						CICJCFPNCNO.Add(wi);
					}
					Debug.Log(string.Format(JpStringLiterals.StringLiteral_11863, numInstaller));
					for (int i = 0; i < numInstaller; i++)
					{
						CriFsWebInstaller installer = new CriFsWebInstaller();
						JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo info = new JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo();
						info.IOKJFDPOEFP_InstallerStatusInfo = installer.GetStatusInfo();
						GBFHGDHNDIE_WebInstallerPool.Enqueue(installer);
						JLNFKNICIFD_DownloadsInfo[i] = info;
						PLDKOCEHDAL_DldInfoByInstaller.Add(installer, info);
					}
					logTxt = string.Format(JpStringLiterals.StringLiteral_11865, KJIGCCPJBFK_List.Count, GBFHGDHNDIE_WebInstallerPool.Count);
				}
				Debug.Log(logTxt);
				CMCKNKKCNDK_Status = 0;
				EMAEFFGBFIB = 0;
				return;
			}
			if(CMCKNKKCNDK_Status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LLGCBKEOHNP/*3*/)
				return;
		}
		CriFsWebInstaller.ExecuteMain();
		int numFailed = PKDGOJNCLBK();
		if(numFailed < 1)
		{
			if(FCPPMGNCGNO() != 0)
			{
				HNKPDKKIPOH();
				return;
			}
			if(KJIGCCPJBFK_List.Count != 0)
				return;
			CMCKNKKCNDK_Status = JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.FEJIMBDPMKI_2/*2*/;
		}
		else
		{
			if(KJIGCCPJBFK_List.Count == numFailed)
			{
				CMCKNKKCNDK_Status = JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LPLEIJIFOKN_Error;
			}
			else
			{
				CMCKNKKCNDK_Status = JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LLGCBKEOHNP/*3*/;
			}
		}
	}

	// // RVA: 0x1C34D48 Offset: 0x1C34D48 VA: 0x1C34D48
	private void PEFNBFCMIBL(bool PGDOLHMCLIA)
	{
		if(OILIGLGDNAD)
			return;
		if(CMCKNKKCNDK_Status != 0)
		{
			PBIMGBKLDPP();
			while(CMCKNKKCNDK_Status != 0)
			{
				FBANBDCOEJL();
				Thread.Sleep(1);
			}
		}
		while(GBFHGDHNDIE_WebInstallerPool.Count != 0)
		{
			CriFsWebInstaller installer = GBFHGDHNDIE_WebInstallerPool.Dequeue();	
			installer.Dispose();
		}
		JOJMBFBGMGN_DldQueue = null;
		GBFHGDHNDIE_WebInstallerPool = null;
		JLNFKNICIFD_DownloadsInfo = null;
	}

	// // RVA: 0x1C36BC0 Offset: 0x1C36BC0 VA: 0x1C36BC0
	// public string LCKGFBCHOAJ() { }

	// // RVA: 0x1C363E4 Offset: 0x1C363E4 VA: 0x1C363E4
	private int PKDGOJNCLBK()
	{
		int index = 0;
		int res = 0;
		CriFsWebInstaller.Status status;
		JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo info = null;
		CriFsWebInstaller installer = null;
		while(true)
		{
			while(true)
			{
				while(true)
				{
					if(index >= KJIGCCPJBFK_List.Count)
						return res;
					installer = KJIGCCPJBFK_List[index];
					info = PLDKOCEHDAL_DldInfoByInstaller[installer];
					info.IOKJFDPOEFP_InstallerStatusInfo = installer.GetStatusInfo();
					status = info.IOKJFDPOEFP_InstallerStatusInfo.status;
					if(info.IOKJFDPOEFP_InstallerStatusInfo.status != CriFsWebInstaller.Status.Stop)
						break;
					if(info.ICKGJODOCBB != null)
					{
						info.ICKGJODOCBB.IKBKLPNADJM = false;
						info.ICKGJODOCBB.NEDNDAKLBMJ = false;
						info.ICKGJODOCBB.KMABBBKJFCB_Percent = 0;
					}
					KJIGCCPJBFK_List.RemoveAt(index);
					GBFHGDHNDIE_WebInstallerPool.Enqueue(installer);
				}
				if(status == CriFsWebInstaller.Status.Complete)
				{
					// UMO Add : check CRC
					if(KEHOJEJMGLJ.HHCJCDFCLOB != null && KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ != null)
					{
						GCGNICILKLD_AssetFileInfo g = KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.BIKLNKNFFMK_GetAssetFileInfo(info.ICKGJODOCBB.AJPIGKBIDDL_LocalFileName.Replace("/android/", ""));
						if(g != null)
						{
							MD5 md5 = MD5.Create();
							string h = KEHOJEJMGLJ.IFCHFDEDCGF_GetFileHash(md5, info.ICKGJODOCBB.ADHHKEMDOIK_LocalPath);
							if(h != g.POEGMFKLFJG_Hash)
							{
								UnityEngine.Debug.LogError("Wrong hash for "+info.ICKGJODOCBB.AJPIGKBIDDL_LocalFileName+" "+h+" != "+g.POEGMFKLFJG_Hash);
								status = CriFsWebInstaller.Status.Error;
								info.IOKJFDPOEFP_InstallerStatusInfo.status = status;
							}
						}
					}
					if(status == CriFsWebInstaller.Status.Complete)
						break;
				}
				if(status == CriFsWebInstaller.Status.Error)
				{
					DLHJNILCAGE(info);
					index = index + 1;
					CMCKNKKCNDK_Status = JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LLGCBKEOHNP;
					res = res + 1;
				}
				else
				{
					if(info.IOKJFDPOEFP_InstallerStatusInfo.contentsSize != 0)
					{
						if(info.ICKGJODOCBB != null)
						{
							info.ICKGJODOCBB.KMABBBKJFCB_Percent = 1.0f * info.IOKJFDPOEFP_InstallerStatusInfo.receivedSize / info.IOKJFDPOEFP_InstallerStatusInfo.contentsSize;
						}
						float f = 0.0f;
						if(info.IOKJFDPOEFP_InstallerStatusInfo.receivedSize == info.NPKGIPPJGEI)
						{
							f = info.LBNOBJFOKMI + Time.deltaTime;
						}
						info.LBNOBJFOKMI = f;
						info.NPKGIPPJGEI = info.IOKJFDPOEFP_InstallerStatusInfo.receivedSize;
					}
					else
					{
						info.LBNOBJFOKMI = info.LBNOBJFOKMI + Time.deltaTime;
					}
					index = index + 1;
				}
			}
			if(LBGNKOJFOFC != null)
				LBGNKOJFOFC(info.ICKGJODOCBB);
			info.ICKGJODOCBB.KMABBBKJFCB_Percent = 1.0;
			info.ICKGJODOCBB.IKBKLPNADJM = false;
			info.ICKGJODOCBB.NEDNDAKLBMJ = true;
			installer.Stop();
			KJIGCCPJBFK_List.RemoveAt(index);
			GBFHGDHNDIE_WebInstallerPool.Enqueue(installer);
			info.IOKJFDPOEFP_InstallerStatusInfo = installer.GetStatusInfo();
			info.ICKGJODOCBB = null;
		}
		return 0;
	}

	// // RVA: 0x1C380F0 Offset: 0x1C380F0 VA: 0x1C380F0
	public bool MNFGKBAEFFL()
	{
		for(int i = 0; i < KJIGCCPJBFK_List.Count; i++)
		{
			JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo info = PLDKOCEHDAL_DldInfoByInstaller[KJIGCCPJBFK_List[i]];
			info.IOKJFDPOEFP_InstallerStatusInfo = KJIGCCPJBFK_List[i].GetStatusInfo();
			if(GCKDIGMAMND <= info.LBNOBJFOKMI)
				return true;
		}
		return false;
	}

	// // RVA: 0x1C37140 Offset: 0x1C37140 VA: 0x1C37140
	private void DLHJNILCAGE(JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo PHKJOMLDNOB)
	{
		if(PHKJOMLDNOB.GGFGJEDLKNC)
			return;
		bool a = false;
		string str = "";
		switch(PHKJOMLDNOB.IOKJFDPOEFP_InstallerStatusInfo.error)
		{
			case CriFsWebInstaller.Error.None:
				str = "None";
				break;
			case CriFsWebInstaller.Error.Timeout:
				str = "Timeout";
				break;
			case CriFsWebInstaller.Error.Memory:
				str = "Memory";
				break;
			case CriFsWebInstaller.Error.LocalFs:
				a = true;
				BHICPONFJKM_SpaceError = true;
				str = "LocalFs";
				break;
			case CriFsWebInstaller.Error.DNS:
				str = "DNS";
				break;
			case CriFsWebInstaller.Error.Connection:
				str = "Connection";
				break;
			case CriFsWebInstaller.Error.SSL:
				str = "SSL";
				a = true;
				break;
			case CriFsWebInstaller.Error.HTTP:
				str = "HTTP";
				a = true;
				break;
			case CriFsWebInstaller.Error.Internal:
				str = "Internal";
				a = true;
				break;
		}
		UnityEngine.Debug.LogError(string.Concat(new string[5]
		{
			"Install Error = ",
			str,
			" [",
			PHKJOMLDNOB.ICKGJODOCBB.NFCMNIEHJML_ServerPath,
			"]"
		}));
		if(!(a && !BIBKLAMCKGN))
		{
			PHKJOMLDNOB.GGFGJEDLKNC = true;
			return;
		}
		BIBKLAMCKGN = true;
		throw new BatchInstallerException(string.Concat(new string[5]
		{
			"code=[",
			str,
			"],url=[",
			PHKJOMLDNOB.ICKGJODOCBB.NFCMNIEHJML_ServerPath,
			"]"
		}));
	}

	// // RVA: 0x1C35730 Offset: 0x1C35730 VA: 0x1C35730
	public void IMDNPMAIJFO_UpdateStorageInfo()
	{
		int avaiableSize = StorageSupport.GetAvailableStorageSizeMB();
		if(avaiableSize < 51)
		{
			KAMPHNKAHAB_IsDiskFull = true;
			OEMNJCADFLL_AllowedFileOnDisk = -1;
		}
		else
		{
			OEMNJCADFLL_AllowedFileOnDisk = 10;
			if(avaiableSize >= 200)
				OEMNJCADFLL_AllowedFileOnDisk = 30;
			if(avaiableSize >= 500)
				OEMNJCADFLL_AllowedFileOnDisk = 120;
			if(avaiableSize >= 1000)
				OEMNJCADFLL_AllowedFileOnDisk = 240;
			KAMPHNKAHAB_IsDiskFull = false;
		}
	}

	// // RVA: 0x1C363C4 Offset: 0x1C363C4 VA: 0x1C363C4
	// private void DEOEDMFDPGP() { }

	// // RVA: 0x1C36884 Offset: 0x1C36884 VA: 0x1C36884
	private void HNKPDKKIPOH()
	{
		while(true)
		{ 
			if(GBFHGDHNDIE_WebInstallerPool.Count == 0)
				return;
			int num = IOBFPLEDMOL();
			if(num < 0 || KAMPHNKAHAB_IsDiskFull)
			{
				return;
			}
			CriFsWebInstaller installer = GBFHGDHNDIE_WebInstallerPool.Dequeue();
			JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo info = JOJMBFBGMGN_DldQueue[num];
			JEHIAIPJNJF_FileDownloader.AFGDFAJEBFA_DldInfo info2 = PLDKOCEHDAL_DldInfoByInstaller[installer];
			string dirName = Path.GetDirectoryName(info.ADHHKEMDOIK_LocalPath);
			if(!Directory.Exists(dirName))
			{
				Directory.CreateDirectory(dirName);
			}
			if(File.Exists(info.ADHHKEMDOIK_LocalPath))
			{
				TodoLogger.Log(TodoLogger.Filesystem, "Delete File "+info.ADHHKEMDOIK_LocalPath);
				File.Delete(info.ADHHKEMDOIK_LocalPath);
			}
			installer.Copy(info.NFCMNIEHJML_ServerPath, info.ADHHKEMDOIK_LocalPath);
			info.KMABBBKJFCB_Percent = 0;
			info.NEDNDAKLBMJ = false;
			info.IKBKLPNADJM = true;
			KJIGCCPJBFK_List.Add(installer);
			info2.ICKGJODOCBB = info;
			info2.GGFGJEDLKNC = false;
			info2.IOKJFDPOEFP_InstallerStatusInfo = installer.GetStatusInfo();
			info2.LBNOBJFOKMI = 0.0f;
		}
	}
}
