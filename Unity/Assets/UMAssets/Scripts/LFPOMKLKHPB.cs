using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class LFPOMKLKHPB
{
	private const int BIAOPOMKMJE = 325392159;
	private const int CEMEIPNMAAD_Version = 1;
	private const uint BEHBKIJEGMK = 40742721;
	public bool BIOFMLDLNKD; // 0x8
	public bool PLOOEECNHFB; // 0x9
	public bool AAAOKDDILCP; // 0xA
	private float CDMPNFPDBOO_DlSizeTimeout = 60.0f; // 0xC
	public List<uint> BHMMPMMLDBA = new List<uint>(); // 0x10
	public List<int> BLBOJAHOHEO = new List<int>(); // 0x14
	public Dictionary<uint, int> OHLLBNBMMDG = new Dictionary<uint, int>(); // 0x18

	// // RVA: 0xD6F134 Offset: 0xD6F134 VA: 0xD6F134
	public void LKLCOEJLBGG()
    {
        CDMPNFPDBOO_DlSizeTimeout = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("dlsize_timeout", 60);
		PLOOEECNHFB = false;
		AAAOKDDILCP = false;
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
			JHHBAFKMBDL.HHCJCDFCLOB.NIGGABHIFEE(true);
			JMNNBKPAAKF = new WWW(HJLDBEJOMIO + "?t=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
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
			JHHBAFKMBDL.HHCJCDFCLOB.NIGGABHIFEE(false);
			if(JMNNBKPAAKF.error == null)
			{
				if(!OLEKCNABLNH)
				{
					KHEKNNFCAOI(JMNNBKPAAKF.bytes);
					PLOOEECNHFB = true;
					yield break;
				}
			}
			else
			{
				OLEKCNABLNH = true;
			}
			bool BEKAMBBOLBO = false;
			JHHBAFKMBDL.HHCJCDFCLOB.AINKKHHAKLK(() => {
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
		res = !res;
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
						BHMMPMMLDBA = new List<uint>();
						BLBOJAHOHEO = new List<int>();
						OHLLBNBMMDG = new Dictionary<uint, int>();
						int idx = 16;
						for(int i = 0; i < cnt; i++)
						{
							uint a = BitConverter.ToUInt32(NIODCJLINJN, idx);
							int b = BitConverter.ToInt32(NIODCJLINJN, idx + 4);
							BLBOJAHOHEO.Add((int)a);
							BLBOJAHOHEO.Add(b);
							if(!OHLLBNBMMDG.ContainsKey(a))
							{
								OHLLBNBMMDG.Add(a, b);
							}
						}
						return true;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0xD6FB64 Offset: 0xD6FB64 VA: 0xD6FB64
	// public int DGGNHNCCGPL(uint IOIMHJAOKOO) { }

	// // RVA: 0xD6FC70 Offset: 0xD6FC70 VA: 0xD6FC70
	// public int IJPPHABNGJH(int OIPCCBHIKIA, uint IOIMHJAOKOO) { }

	// // RVA: 0xD6FD70 Offset: 0xD6FD70 VA: 0xD6FD70
	// public string OBDBAEOPJPL(List<GCGNICILKLD> KGHAJGGMPKL) { }

	// // RVA: 0xD6FF78 Offset: 0xD6FF78 VA: 0xD6FF78
	public void NKIKBOJOCNN(List<GCGNICILKLD_AssetFileInfo> KGHAJGGMPKL)
    {
        TodoLogger.Log(0, "!!!");
    }

	// [CompilerGeneratedAttribute] // RVA: 0x6BB4D4 Offset: 0x6BB4D4 VA: 0x6BB4D4
	// // RVA: 0xD70210 Offset: 0xD70210 VA: 0xD70210
	// private void <ShowInstallFileSize>b__17_0() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BB4E4 Offset: 0x6BB4E4 VA: 0x6BB4E4
	// // RVA: 0xD7021C Offset: 0xD7021C VA: 0xD7021C
	// private void <ShowInstallFileSize>b__17_1() { }
}
