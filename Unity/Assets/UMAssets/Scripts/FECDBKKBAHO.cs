using System.IO;
using System;
using System.Collections.Generic;

public class FECDBKKBAHO
{
	public class FHOPNIJCFKA_FileInfo
	{
		public long DGGFLBJBLLN; // 0x8
		public long FNALNKKMKDC_ExpireTime; // 0x10
		public int IOIMHJAOKOO; // 0x18
		public short KKPAHLMJKIH; // 0x1C
		public bool GEJJEDDEPMI; // 0x1E
		public bool GOAEFAAIOEK_Missing; // 0x1F
	}
	
	private const int MPLGOGILHHF = 0x2713;
	private const int KENEAGNAKAF = 24;
	private Dictionary<int, FHOPNIJCFKA_FileInfo> MLHACNBJAGM_FilesInfoByHash = new Dictionary<int, FHOPNIJCFKA_FileInfo>(); // 0x8
	private string JHJMNLMNPGO_PersistentDirSys; // 0xC
	public bool GCKONHLCMFL; // 0x10
	private int IHEPCAHBECA = -1; // 0x14
	// private Regex OOLIMFMEJGP; // 0x18
	private string KDFJMKLNOJH; // 0x1C
	private string HKHMCIEINKB_BgmDir; // 0x20
	private string OGCDNCDMLCA_PersistentDataPath; // 0x24
	private long JHNMKKNEENE_Time; // 0x28

	// // RVA: 0xFCF300 Offset: 0xFCF300 VA: 0xFCF300
	public void KHEKNNFCAOI_Init()
	{
		JHJMNLMNPGO_PersistentDirSys = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + KCOGAGGCPBP.HAFLEFNJAKD_DirSys;
		PCODDPDFLHK();
	}

	// // RVA: 0xFCF7E8 Offset: 0xFCF7E8 VA: 0xFCF7E8
	// public void JCHLONCMPAJ() { }

	// // RVA: 0xFCF860 Offset: 0xFCF860 VA: 0xFCF860
	public FHOPNIJCFKA_FileInfo LBDOLHGDIEB_GetFileInfo(string CJEKGLGBIHF)
	{
		if(MLHACNBJAGM_FilesInfoByHash.ContainsKey(CJEKGLGBIHF.GetHashCode()))
		{
			return MLHACNBJAGM_FilesInfoByHash[CJEKGLGBIHF.GetHashCode()];
		}
		return null;
	}

	// // RVA: 0xFCF948 Offset: 0xFCF948 VA: 0xFCF948
	public void OJCJPCHFPGO_DeleteFileInfo(string CJEKGLGBIHF)
	{
		if(!MLHACNBJAGM_FilesInfoByHash.ContainsKey(CJEKGLGBIHF.GetHashCode()))
			return;
		MLHACNBJAGM_FilesInfoByHash.Remove(CJEKGLGBIHF.GetHashCode());
	}

	// // RVA: 0xFCFA28 Offset: 0xFCFA28 VA: 0xFCFA28
	public void KMHCHILJPIG()
	{
		FHOPNIJCFKA_FileInfo[] filesInfo = new FHOPNIJCFKA_FileInfo[MLHACNBJAGM_FilesInfoByHash.Values.Count];
		MLHACNBJAGM_FilesInfoByHash.Values.CopyTo(filesInfo, 0);
		for(int i = 0; i < filesInfo.Length; i++)
		{
			filesInfo[i].GOAEFAAIOEK_Missing = true;
		}
	}

	// // RVA: 0xFCFBB8 Offset: 0xFCFBB8 VA: 0xFCFBB8
	public FECDBKKBAHO.FHOPNIJCFKA_FileInfo ANIJHEBLMGB(string CJEKGLGBIHF, long DGGFLBJBLLN, int KKPAHLMJKIH)
	{
		TodoLogger.Log(0, "TODO");
		return null;
	}

	// // RVA: 0xFCF3E0 Offset: 0xFCF3E0 VA: 0xFCF3E0
	public void PCODDPDFLHK()
	{
		if(!Directory.Exists(JHJMNLMNPGO_PersistentDirSys))
		{
			Directory.CreateDirectory(JHJMNLMNPGO_PersistentDirSys);
		}
		MLHACNBJAGM_FilesInfoByHash.Clear();
		string file = JHJMNLMNPGO_PersistentDirSys + "/" + KCOGAGGCPBP.PFJKALCPNHG_File00;
		if(File.Exists(file))
		{
			byte[] data = File.ReadAllBytes(file);
			if(data != null)
			{
				int header = BitConverter.ToInt32(data, 0);
				if(header == MPLGOGILHHF)
				{
					int val = BitConverter.ToInt32(data, 4);
					int offset = 8;
					for(int i = 0; i < val; i++)
					{
						FHOPNIJCFKA_FileInfo d = new FHOPNIJCFKA_FileInfo();
						d.DGGFLBJBLLN = BitConverter.ToInt64(data, offset);
						d.FNALNKKMKDC_ExpireTime = BitConverter.ToInt64(data, offset + 8);
						d.IOIMHJAOKOO = BitConverter.ToInt32(data, offset + 16);
						d.KKPAHLMJKIH = BitConverter.ToInt16(data, offset + 20);
						d.GEJJEDDEPMI = data[22] != 0;
						MLHACNBJAGM_FilesInfoByHash.Add(d.IOIMHJAOKOO, d);
						offset += 24;
					}
				}
				else
				{
					UnityEngine.Debug.LogError("Wrong signature for "+JHJMNLMNPGO_PersistentDirSys);
				}
			}
		}
	}

	// // RVA: 0xFCFEAC Offset: 0xFCFEAC VA: 0xFCFEAC
	public void HJMKBCFJOOH()
    {
        if(!Directory.Exists(JHJMNLMNPGO_PersistentDirSys))
		{
			Directory.CreateDirectory(JHJMNLMNPGO_PersistentDirSys);
		}
		int cnt = 0;
		int[] array = null;
		if (MLHACNBJAGM_FilesInfoByHash.Count > 0)
		{
			array = new int[MLHACNBJAGM_FilesInfoByHash.Keys.Count];
			MLHACNBJAGM_FilesInfoByHash.Keys.CopyTo(array, 0);
			for(int i = 0; i < array.Length; i++)
			{
				cnt += MLHACNBJAGM_FilesInfoByHash[array[i]].GOAEFAAIOEK_Missing ? 0 : 1;
			}
		}
		string p = JHJMNLMNPGO_PersistentDirSys + "/" + KCOGAGGCPBP.PFJKALCPNHG_File00;
		byte[] bytes = new byte[cnt * 24 + 8];
		Buffer.BlockCopy(BitConverter.GetBytes(MPLGOGILHHF), 0, bytes, 0, 4);
		Buffer.BlockCopy(BitConverter.GetBytes(cnt), 0, bytes, 4, 4);
		if(array != null && array.Length > 0)
		{
			int off = 8;
			for(int i = 0; i < cnt; i++)
			{
				FHOPNIJCFKA_FileInfo data = MLHACNBJAGM_FilesInfoByHash[array[i]];
				if (!data.GOAEFAAIOEK_Missing)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(data.DGGFLBJBLLN), 0, bytes, off, 8);
					Buffer.BlockCopy(BitConverter.GetBytes(data.FNALNKKMKDC_ExpireTime), 0, bytes, off + 8, 8);
					Buffer.BlockCopy(BitConverter.GetBytes(array[i]), 0, bytes, off + 16, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(data.KKPAHLMJKIH), 0, bytes, off + 20, 2);
					bytes[off + 22] = (byte)(data.GEJJEDDEPMI ? 1 : 0);
					off += 24;
				}
			}
		}
		File.WriteAllBytes(p, bytes);
	}

	// // RVA: 0xFD0494 Offset: 0xFD0494 VA: 0xFD0494
	public bool JCENJHBMDIP(int KKPAHLMJKIH, long JHNMKKNEENE, long CKPIHCGOEDP)
	{
		long t = CKPIHCGOEDP * 86400;
		Dictionary<int, FHOPNIJCFKA_FileInfo>.KeyCollection k = MLHACNBJAGM_FilesInfoByHash.Keys;
		if(k.Count > 0)
		{
			int[] lk = new int[k.Count];
			k.CopyTo(lk, 0);
			for(int i = 0; i < lk.Length; i++)
			{
				if(MLHACNBJAGM_FilesInfoByHash[lk[i]].GEJJEDDEPMI && MLHACNBJAGM_FilesInfoByHash[lk[i]].KKPAHLMJKIH == KKPAHLMJKIH)
				{
					MLHACNBJAGM_FilesInfoByHash[lk[i]].DGGFLBJBLLN = JHNMKKNEENE;
					MLHACNBJAGM_FilesInfoByHash[lk[i]].FNALNKKMKDC_ExpireTime = JHNMKKNEENE + t;
				}
			}
		}
		return true;
	}

	// // RVA: 0xFD0724 Offset: 0xFD0724 VA: 0xFD0724
	// public void IKOFAKDLDJE() { }

	// // RVA: 0xFD099C Offset: 0xFD099C VA: 0xFD099C
	// private void BNPFBOIFDAG() { }

	// // RVA: 0xFD0C1C Offset: 0xFD0C1C VA: 0xFD0C1C
	public void EBCAKALIAHH_RemoveExpiredSongs()
    {
        GCKONHLCMFL = true;
		HKHMCIEINKB_BgmDir = KEHOJEJMGLJ.CGAHFOBGHIM_PersistentPlatformDataPath + "/snd/bgm";
		OGCDNCDMLCA_PersistentDataPath = KEHOJEJMGLJ.OGCDNCDMLCA_PersistentDataPath;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		JHNMKKNEENE_Time = time;
		PJNOMDMINDA_RemoveExpiredFiles(HKHMCIEINKB_BgmDir);
		GCKONHLCMFL = false;
		HKHMCIEINKB_BgmDir = null;
    }

	// // RVA: 0xFD09C8 Offset: 0xFD09C8 VA: 0xFD09C8
	// private void PMHECMICPGN(string CJJJPKJHOGM) { }

	// // RVA: 0xFD0D84 Offset: 0xFD0D84 VA: 0xFD0D84
	private void PJNOMDMINDA_RemoveExpiredFiles(string CJJJPKJHOGM)
	{
		if(Directory.Exists(CJJJPKJHOGM))
		{
            string[] files = Directory.GetFiles(CJJJPKJHOGM);
            int len = OGCDNCDMLCA_PersistentDataPath.Length;
			for(int i = 0; i < files.Length; i++)
			{
				string str = files[i].Substring(len);
				str = str.Replace('\\','/');
				FHOPNIJCFKA_FileInfo finfo = LBDOLHGDIEB_GetFileInfo(str);
				if(finfo != null && finfo.GEJJEDDEPMI)
				{
					if(finfo.FNALNKKMKDC_ExpireTime != 0)
					{
						if(finfo.FNALNKKMKDC_ExpireTime <= JHNMKKNEENE_Time)
						{
							//File.Delete(files[i]);
							UnityEngine.Debug.Log("delete " + files[i]);
							//finfo.GOAEFAAIOEK_Deleted = true;
						}
					}
				}
			}
			string[] dirs = Directory.GetDirectories(CJJJPKJHOGM);
			for(int i = 0; i < dirs.Length; i++)
			{
				PJNOMDMINDA_RemoveExpiredFiles(dirs[i]);
			}
        }
	}

	// // RVA: 0xFD1000 Offset: 0xFD1000 VA: 0xFD1000
	// public void FMCLFMGBAJJ() { }
}
