using System.IO;
using System;
using System.Security.Cryptography;

public class BFGOCONGNDK
{
	private const int NEBFFKCGIMK = 741042;
	private const int OBHOPEGFNGN = 16;
	public string IOIMHJAOKOO; // 0x8
	public int OENPCNBFPDA; // 0xC
	public long PDBPFJJCADD; // 0x10
	public long FDBNFFNFOND; // 0x18
	public bool MBGHLLHFNHH; // 0x20

	// // RVA: 0xC79E1C Offset: 0xC79E1C VA: 0xC79E1C
	private string HIOMFHINAAH()
	{
		return CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/sys/" + KCOGAGGCPBP.OGIALGFMODF_File05; // 05
	}

	// // RVA: 0xC79EFC Offset: 0xC79EFC VA: 0xC79EFC
	public static string NLMBMNKEINP(int KEFGPJBKAOD)
    {
        return "ct/bg/tl/"+ KEFGPJBKAOD.ToString("D4") + ".xab";
    }

	// // RVA: 0xC79F98 Offset: 0xC79F98 VA: 0xC79F98
	public void PCODDPDFLHK()
    {
		// Checking something ?
		MBGHLLHFNHH = false;
		string s = HIOMFHINAAH();
		if(File.Exists(s))
		{
			byte[] data = File.ReadAllBytes(s);
			if(data != null && data.Length > 15)
			{
				int header = BitConverter.ToInt32(data, 0);
				if(header == 0xb4eb2)
				{
					int size = BitConverter.ToInt32(data, 8);
					if(size == data.Length - 16)
					{
						if(size > 16)
						{
        					TodoLogger.Log(5, "TODO");
						}
					}
				}
			}
		}

        TodoLogger.Log(TodoLogger._Todo, "BFGOCONGNDK.PCODDPDFLHK Implement when sys/05 is saved.");
		MBGHLLHFNHH = true;
    }

	// // RVA: 0xC7A53C Offset: 0xC7A53C VA: 0xC7A53C
	// public void HJMKBCFJOOH() { }

	// // RVA: 0xC7AF9C Offset: 0xC7AF9C VA: 0xC7AF9C
	public bool DAONJOOCPFP(int ODJPFMGNDML)
    {
        OENPCNBFPDA = ODJPFMGNDML; // Hack, force bg id since PCODDPDFLHK is not executed

		if(OENPCNBFPDA == ODJPFMGNDML)
		{
			string fileBg = FileSystemProxy.ConvertPath(CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/data/android/" + NLMBMNKEINP(ODJPFMGNDML));
			//if(File.Exists(fileBg))
			if(FileSystemProxy.FileExists(fileBg))
			{
				if(KEHOJEJMGLJ.HHCJCDFCLOB != null)
				{
					BEEINMBNKNM_Encryption decryptor = KEHOJEJMGLJ.HHCJCDFCLOB.GMLCCMEHNCI.MFHAOMELJKJ_FindDecryptor("/"+NLMBMNKEINP(ODJPFMGNDML));
					if(decryptor != null)
					{
						MD5 md5 = MD5.Create();
						FileStream f = File.OpenRead(fileBg);
						byte[] hash = md5.ComputeHash(f);
						TodoLogger.Log(0, "end BG check hash");
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
