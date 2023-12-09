using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XeApp.Game.Common;

public class LFPOMKLKHPB
{
	private const int BIAOPOMKMJE = 325392159;
	private const int CEMEIPNMAAD_Version = 1;
	private const uint BEHBKIJEGMK = 40742721;
	public bool BIOFMLDLNKD; // 0x8
	public bool PLOOEECNHFB_IsDone; // 0x9
	public bool AAAOKDDILCP_IsError; // 0xA
	private float CDMPNFPDBOO_DlSizeTimeout = 60.0f; // 0xC
	public List<uint> BHMMPMMLDBA_Hash = new List<uint>(); // 0x10
	public List<int> BLBOJAHOHEO_Size = new List<int>(); // 0x14
	public Dictionary<uint, int> OHLLBNBMMDG = new Dictionary<uint, int>(); // 0x18

	// // RVA: 0xD6F134 Offset: 0xD6F134 VA: 0xD6F134
	public void LKLCOEJLBGG()
    {
        CDMPNFPDBOO_DlSizeTimeout = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("dlsize_timeout", 60);
		PLOOEECNHFB_IsDone = false;
		AAAOKDDILCP_IsError = false;
		StringBuilder str = new StringBuilder();
		str.Append('/');
		str.Append(KEHOJEJMGLJ.LBEPLOJBFCM_PlatformPrefix);
		str.Append("/sz.dat");
		string fullPath = str.ToString();
		string dir = Path.GetDirectoryName(fullPath);
		dir = dir.Replace('\\','/');
		string file = Path.GetFileNameWithoutExtension(fullPath);
		string ext = Path.GetExtension(fullPath);
		int keyPath = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.KBNGOBEAHIC_KeyPath;
		uint v = BEEINMBNKNM_Encryption.DIKDKNIKPNJ((uint)keyPath, fullPath);
		str.Length = 0;
		str.Append(KEHOJEJMGLJ.FLHOFIEOKDH_BaseUrl);
		str.Append(dir);
		str.Append('/');
		str.Append(file);
		str.Append("!s");
		str.AppendFormat("{0:x8}", v);
		str.Append("z!");
		str.Append(ext);
		N.a.StartCoroutineWatched(JJONPJEMODE_Co_Download(str.ToString()));

    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BB45C Offset: 0x6BB45C VA: 0x6BB45C
	// // RVA: 0xD6F59C Offset: 0xD6F59C VA: 0xD6F59C
	private IEnumerator JJONPJEMODE_Co_Download(string HJLDBEJOMIO)
	{
		WWW JMNNBKPAAKF; // 0x1C
		float DFIEJHNOBOC; // 0x20
		bool OLEKCNABLNH; // 0x24

		//0xD70240
		do
		{
			JHHBAFKMBDL.HHCJCDFCLOB.NIGGABHIFEE_ShowTransmissionIcon(true);
			string url;
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
			if(!FileSystemProxy.FileExists(HJLDBEJOMIO))
			{
				bool retry = false;
				yield return Co.R(FileSystemProxy.WaitServerInfo("Missing file "+FileSystemProxy.ConvertPath(HJLDBEJOMIO), true, true, (PopupButton.ButtonLabel btn) =>
				{
					if(btn == PopupButton.ButtonLabel.Retry)
						retry = true;
				}));
				if(retry)
					continue;
				url = FileSystemProxy.ConvertURL(HJLDBEJOMIO + "?t=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
			}
			else
			{
				url = "file://"+FileSystemProxy.ConvertPath(HJLDBEJOMIO);
			}
#else
			if(!FileSystemProxy.FileExists(HJLDBEJOMIO))
			{
				url = FileSystemProxy.ConvertURL(HJLDBEJOMIO + "?t=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
			}
			else
			{
				url = "file://"+FileSystemProxy.ConvertPath(HJLDBEJOMIO);
			}
#endif
			JMNNBKPAAKF = new WWW(url);
			DFIEJHNOBOC = 0;
			OLEKCNABLNH = false;
			while(!JMNNBKPAAKF.isDone)
			{
				DFIEJHNOBOC += Time.deltaTime;
				if(DFIEJHNOBOC < CDMPNFPDBOO_DlSizeTimeout)
					yield return null;
				else
				{
					JMNNBKPAAKF = null;
					OLEKCNABLNH = true;
					break;
				}
			}
			JHHBAFKMBDL.HHCJCDFCLOB.NIGGABHIFEE_ShowTransmissionIcon(false);
			if(JMNNBKPAAKF.error == null)
			{
				if(!OLEKCNABLNH)
				{
					KHEKNNFCAOI(JMNNBKPAAKF.bytes);
					PLOOEECNHFB_IsDone = true;
					yield break;
				}
			}
			else
			{
				UnityEngine.Debug.LogError(JMNNBKPAAKF.error);
				OLEKCNABLNH = true;
			}
			bool BEKAMBBOLBO = false;
			JHHBAFKMBDL.HHCJCDFCLOB.AINKKHHAKLK_ShowDldSizeErrorPopup(() => {
				//0xD70230
				BEKAMBBOLBO = true;
			});
			while(!BEKAMBBOLBO)
				yield return null;
		} while(true);
	}

	// // RVA: 0xD6F664 Offset: 0xD6F664 VA: 0xD6F664
	private bool KHEKNNFCAOI(byte[] NIODCJLINJN)
	{
		BIOFMLDLNKD = false;
		BEEINMBNKNM_Encryption b = new BEEINMBNKNM_Encryption();
		b.KHEKNNFCAOI_Init(0x26daf41);
		b.CLNHGLGOKPF_Decrypt(NIODCJLINJN);
		bool res = HNENADILFBJ(NIODCJLINJN);
		if(res)
			BIOFMLDLNKD = true;
		return res;
	}

	// // RVA: 0xD6F7E8 Offset: 0xD6F7E8 VA: 0xD6F7E8
	private bool HNENADILFBJ(byte[] NIODCJLINJN)
	{
		if(NIODCJLINJN.Length > 15)
		{
			if(BitConverter.ToInt32(NIODCJLINJN, 0) == 0x1365171f)
			{
				if(BitConverter.ToInt32(NIODCJLINJN, 4) == 1)
				{
					int cnt = BitConverter.ToInt32(NIODCJLINJN, 8);
					if(cnt * 8 + 16 == NIODCJLINJN.Length)
					{
						BHMMPMMLDBA_Hash = new List<uint>();
						BLBOJAHOHEO_Size = new List<int>();
						OHLLBNBMMDG = new Dictionary<uint, int>();
						int idx = 16;
						for(int i = 0; i < cnt; i++)
						{
							uint a = BitConverter.ToUInt32(NIODCJLINJN, idx);
							int b = BitConverter.ToInt32(NIODCJLINJN, idx + 4);
							BHMMPMMLDBA_Hash.Add(a);
							BLBOJAHOHEO_Size.Add(b);
							if(!OHLLBNBMMDG.ContainsKey(a))
							{
								OHLLBNBMMDG.Add(a, b);
							}
							idx += 8;
						}
						return true;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0xD6FB64 Offset: 0xD6FB64 VA: 0xD6FB64
	public int DGGNHNCCGPL_GetSizeForHash(uint IOIMHJAOKOO)
	{
		return OHLLBNBMMDG[IOIMHJAOKOO];
	}

	// // RVA: 0xD6FC70 Offset: 0xD6FC70 VA: 0xD6FC70
	public int IJPPHABNGJH_GetCacheSize(int OIPCCBHIKIA, uint IOIMHJAOKOO)
	{
		if(OIPCCBHIKIA < BHMMPMMLDBA_Hash.Count)
		{
			if(BHMMPMMLDBA_Hash[OIPCCBHIKIA] == IOIMHJAOKOO)
			{
				return BLBOJAHOHEO_Size[OIPCCBHIKIA];
			}
		}
		return DGGNHNCCGPL_GetSizeForHash(IOIMHJAOKOO);
	}

	// // RVA: 0xD6FD70 Offset: 0xD6FD70 VA: 0xD6FD70
	public string OBDBAEOPJPL_GetDownloadSizeString(List<GCGNICILKLD_AssetFileInfo> KGHAJGGMPKL)
	{
		float size = 0;
		for(int i = 0; i < KGHAJGGMPKL.Count; i++)
		{
			int s = IJPPHABNGJH_GetCacheSize(KGHAJGGMPKL[i].LBALIFCJKON_Idx, KGHAJGGMPKL[i].HHPEMFKDHLK_FileHash);
			size += ((s + 4095) / 4096) * 4096;
		}
		size *= 10.0f / 1024 / 1024;
		int i_size = (int)Mathf.Ceil(size);
		return string.Format("{0}.{1} MB", i_size / 10, i_size % 10);
	}

	// // RVA: 0xD6FF78 Offset: 0xD6FF78 VA: 0xD6FF78
	public void NKIKBOJOCNN_ShowInstallFileSize(List<GCGNICILKLD_AssetFileInfo> KGHAJGGMPKL)
    {
		PLOOEECNHFB_IsDone = false;
		if (KGHAJGGMPKL.Count == 0 || !BIOFMLDLNKD)
		{
			PLOOEECNHFB_IsDone = true;
			return;
		}
		JHHBAFKMBDL.HHCJCDFCLOB.NKIKBOJOCNN_ShowDldSizePopup(() =>
		{
			//0xD70210
			PLOOEECNHFB_IsDone = true;
		}, () =>
		{
			//0xD7021C
			PLOOEECNHFB_IsDone = true;
			AAAOKDDILCP_IsError = true;
		}, OBDBAEOPJPL_GetDownloadSizeString(KGHAJGGMPKL));
	}
}
