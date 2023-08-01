using System.IO;
using System;
using System.Security.Cryptography;
using XeApp.Game.AR;
using XeApp.Native;
using System.Text;

public class BFGOCONGNDK
{
	private const int NEBFFKCGIMK = 741042;
	private const int OBHOPEGFNGN = 16;
	public string IOIMHJAOKOO_FileHash; // 0x8
	public int OENPCNBFPDA_BgId; // 0xC
	public long PDBPFJJCADD_StartTime; // 0x10
	public long FDBNFFNFOND_EndTime; // 0x18
	public bool MBGHLLHFNHH; // 0x20

	// // RVA: 0xC79E1C Offset: 0xC79E1C VA: 0xC79E1C
	private string HIOMFHINAAH_GetFileName()
	{
		return CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/sys/" + KCOGAGGCPBP.OGIALGFMODF_File05; // 05
	}

	// // RVA: 0xC79EFC Offset: 0xC79EFC VA: 0xC79EFC
	public static string NLMBMNKEINP_GetBgFileName(int KEFGPJBKAOD)
    {
        return "ct/bg/tl/"+ KEFGPJBKAOD.ToString("D4") + ".xab";
    }

	// // RVA: 0xC79F98 Offset: 0xC79F98 VA: 0xC79F98
	public void PCODDPDFLHK_ReadStartBgInfo()
    {
		MBGHLLHFNHH = false;
		string s = HIOMFHINAAH_GetFileName();
		if(File.Exists(s))
		{
			byte[] data = File.ReadAllBytes(s);
			if(data != null && data.Length > 15)
			{
				int header = BitConverter.ToInt32(data, 0);
				if(header == NEBFFKCGIMK)
				{
					int size = BitConverter.ToInt32(data, 8);
					if(size == data.Length - 16)
					{
						if(size > 16)
						{
        					TodoLogger.LogError(5, "TODO");
						}
					}
				}
			}
		}

        TodoLogger.LogError(TodoLogger._Todo, "BFGOCONGNDK.PCODDPDFLHK Implement when sys/05 is saved.");
		MBGHLLHFNHH = true;
    }

	// // RVA: 0xC7A53C Offset: 0xC7A53C VA: 0xC7A53C
	public void HJMKBCFJOOH_SaveStartBgInfo()
	{
		if(AREventMasterData.Instance.IsReady())
		{
			AREventMasterData.Chenge_bg bg = AREventMasterData.Instance.FindChangeBG();
			if(bg != null)
			{
				string id = NLMBMNKEINP_GetBgFileName(bg.bgId);
				GCGNICILKLD_AssetFileInfo g = KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.BIKLNKNFFMK_GetAssetFileInfo(id);
				if (g != null)
				{
					string path = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/data/android/";
					if(File.Exists(path))
					{
						OENPCNBFPDA_BgId = bg.bgId;
						PDBPFJJCADD_StartTime = bg.startTime;
						FDBNFFNFOND_EndTime = bg.endTime;
						IOIMHJAOKOO_FileHash = g.POEGMFKLFJG_Hash;
						EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
						data["ver"] = AppInfo.appVersion;
						data["b"] = AppInfo.buildVersion;
						data["h"] = IOIMHJAOKOO_FileHash;
						data["bg"] = OENPCNBFPDA_BgId;
						data["s"] = PDBPFJJCADD_StartTime;
						data["e"] = FDBNFFNFOND_EndTime;
						KIJECNFNNDB_JsonWriter k = new KIJECNFNNDB_JsonWriter();
						IKPIMINCOPI_JsonMapper.EJCOJCGIBNG_ToJson(data, k);
						FileStream fs = new FileStream(HIOMFHINAAH_GetFileName(), FileMode.Create);
						BinaryWriter br = new BinaryWriter(fs);
						byte[] b = Encoding.UTF8.GetBytes(k.ToString());
						int c = 0;
						for(int i = 0; i < b.Length; i++)
						{
							c += b[i];
						}
						br.Write(NEBFFKCGIMK);
						br.Write(0);
						br.Write(b.Length);
						br.Write(c);
						br.Write(b);
						br.Flush();
						br.Close();
						br.Flush();
						fs.Flush();
					}
				}
			}
		}
	}

	// // RVA: 0xC7AF9C Offset: 0xC7AF9C VA: 0xC7AF9C
	public bool DAONJOOCPFP(int ODJPFMGNDML_Id)
    {
        OENPCNBFPDA_BgId = ODJPFMGNDML_Id; // Hack, force bg id since PCODDPDFLHK is not executed

		if(OENPCNBFPDA_BgId == ODJPFMGNDML_Id)
		{
			string fileBg = FileSystemProxy.ConvertPath(CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/data/android/" + NLMBMNKEINP_GetBgFileName(ODJPFMGNDML_Id));
			//if(File.Exists(fileBg))
			if(FileSystemProxy.FileExists(fileBg))
			{
				if(KEHOJEJMGLJ.HHCJCDFCLOB != null)
				{
					BEEINMBNKNM_Encryption decryptor = KEHOJEJMGLJ.HHCJCDFCLOB.GMLCCMEHNCI.MFHAOMELJKJ_FindDecryptor("/"+NLMBMNKEINP_GetBgFileName(ODJPFMGNDML_Id));
					if(decryptor != null)
					{
						MD5 md5 = MD5.Create();
						FileStream f = File.OpenRead(fileBg);
						byte[] hash = md5.ComputeHash(f);
						string strHash = "";
						for(int i = 0; i < hash.Length; i++)
						{
							strHash += string.Format("{0:x2}", hash[i]);
						}
						if(f != null)
						{
							f.Dispose();
						}
						TodoLogger.LogError(TodoLogger._Todo, "BFGOCONGNDK.DAONJOOCPFP Fix when PCODDPDFLHK works");
						//return strHash == IOIMHJAOKOO_FileHash;
						return true;
					}
				}
			}
			else
			{
				UnityEngine.Debug.LogError("File missing : " + fileBg);
			}
		}
		return false;
    }
}
