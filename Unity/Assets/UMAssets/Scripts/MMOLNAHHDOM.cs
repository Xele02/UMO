using System;
using System.IO;

public class MMOLNAHHDOM
{
	public const int OBLMMOLOFJB = 250;
	private static byte[] LAIIKHJABMP_MultiDiva = new byte[250]; // 0x0
	private static int JJJHKABCOIM_Hash = 0; // 0x4
	private static string ELLBAAFKDCH_Path; // 0x8

	// RVA: 0x196824C Offset: 0x196824C VA: 0x196824C
	public MMOLNAHHDOM()
    {
        KHEKNNFCAOI();
    }

	// // RVA: 0x1968308 Offset: 0x1968308 VA: 0x1968308
	public void KHEKNNFCAOI(string CJEKGLGBIHF)
    {
        ELLBAAFKDCH_Path = CJEKGLGBIHF;
    }

	// // RVA: 0x196826C Offset: 0x196826C VA: 0x196826C
	public void KHEKNNFCAOI()
    {
        KHEKNNFCAOI(CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/SaveData/ul0");
    }

	// // RVA: 0x1968398 Offset: 0x1968398 VA: 0x1968398
	private int BGDCMGOPCGE_GetHash(byte[] FIKCHOLCKNJ)
	{
		int res = 0x7af3c835;
		for(int i = 0; i < FIKCHOLCKNJ.Length; i++)
		{
			res = (i + 0x1000) * FIKCHOLCKNJ[i] + res & 0x7fffffff;
		}
		return res;
	}

	// // RVA: 0x1968408 Offset: 0x1968408 VA: 0x1968408
	public bool PCODDPDFLHK_Read()
    {
		bool res = false;
		JCHLONCMPAJ_Reset(false);
		if(File.Exists(ELLBAAFKDCH_Path))
		{
			FileStream fs = new FileStream(ELLBAAFKDCH_Path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			int a = br.ReadInt32();
			int size = br.ReadInt32();
			byte[] data = br.ReadBytes(size);
			br.Close();
			int r = BGDCMGOPCGE_GetHash(data);
			if(r == a)
			{
				if(size == LAIIKHJABMP_MultiDiva.Length)
				{
					LAIIKHJABMP_MultiDiva = data;
				}
				else
				{
					int s = Math.Min(size, LAIIKHJABMP_MultiDiva.Length);
					for(int i = 0; i < s; i++)
					{
						LAIIKHJABMP_MultiDiva[i] = data[i];
					}
				}
				res = true;
			}
			br.Dispose();
			fs.Dispose();
		}
		JJJHKABCOIM_Hash = BGDCMGOPCGE_GetHash(LAIIKHJABMP_MultiDiva);
		return res;
    }

	// // RVA: 0x1968E50 Offset: 0x1968E50 VA: 0x1968E50
	public bool HJMKBCFJOOH_Write(bool FBBNPFFEJBN_Force = false)
    {
		int a = BGDCMGOPCGE_GetHash(LAIIKHJABMP_MultiDiva);
		if(!FBBNPFFEJBN_Force)
		{
			if (JJJHKABCOIM_Hash == a)
				return false;
		}
		string dirName = Path.GetDirectoryName(ELLBAAFKDCH_Path);
		if (!Directory.Exists(dirName))
		{
			Directory.CreateDirectory(dirName);
		}
		FileStream fs = new FileStream(ELLBAAFKDCH_Path, FileMode.Create);
		BinaryWriter bw = new BinaryWriter(fs);
		bw.Write(a);
		bw.Write(LAIIKHJABMP_MultiDiva.Length);
		bw.Write(LAIIKHJABMP_MultiDiva);
		bw.Flush();
		bw.Close();
		JJJHKABCOIM_Hash = a;
		bw.Dispose();
		fs.Dispose();
		return true;
	}

	// // RVA: 0x1968CF4 Offset: 0x1968CF4 VA: 0x1968CF4
	public void JCHLONCMPAJ_Reset(bool OGBEGDKPDGK_NeedSave)
	{
		for(int i = 0; i < LAIIKHJABMP_MultiDiva.Length; i++)
		{
			LAIIKHJABMP_MultiDiva[i] = 0xff;
		}
		if(OGBEGDKPDGK_NeedSave)
		{
			HJMKBCFJOOH_Write(false);
		}
	}

	// // RVA: 0x19695D0 Offset: 0x19695D0 VA: 0x19695D0
	public bool IAGAAOKODPM_SetMultiDiva(int EHDDADDKMFI, bool JKDJCFEBDHC)
	{
		int idx = EHDDADDKMFI - 1;
		if ((idx >> 4) > 124)
			return false;
		int offset = (idx >> 3);
		if (LAIIKHJABMP_MultiDiva.Length <= offset)
			return true;
		if(JKDJCFEBDHC)
		{
			LAIIKHJABMP_MultiDiva[offset] |= (byte)(1 << (idx & 7));
		}
		else
		{
			LAIIKHJABMP_MultiDiva[offset] &= (byte)~(1 << (idx & 7));
		}
		return true;
	}

	// // RVA: 0x19697A4 Offset: 0x19697A4 VA: 0x19697A4
	public bool NMBAHHJLGPP_IsMultiDiva(int EHDDADDKMFI)
	{
		int idx = EHDDADDKMFI - 1;
		if((idx >> 4) > 124)	
			return false;
		int offset = (idx >> 3);
		if (LAIIKHJABMP_MultiDiva.Length <= offset)
			return false;
		return (LAIIKHJABMP_MultiDiva[offset] & (1 << (idx & 7))) != 0;
	}
}
