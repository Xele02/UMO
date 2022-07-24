using System.IO;

public class MMOLNAHHDOM
{
	public const int OBLMMOLOFJB = 250;
	private static byte[] LAIIKHJABMP_MultiDiva = new byte[250]; // 0x0
	private static int JJJHKABCOIM = 0; // 0x4
	private static string ELLBAAFKDCH; // 0x8

	// RVA: 0x196824C Offset: 0x196824C VA: 0x196824C
	public MMOLNAHHDOM()
    {
        KHEKNNFCAOI();
    }

	// // RVA: 0x1968308 Offset: 0x1968308 VA: 0x1968308
	public void KHEKNNFCAOI(string CJEKGLGBIHF)
    {
        ELLBAAFKDCH = CJEKGLGBIHF;
    }

	// // RVA: 0x196826C Offset: 0x196826C VA: 0x196826C
	public void KHEKNNFCAOI()
    {
        KHEKNNFCAOI(CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/SaveData/ul0");
    }

	// // RVA: 0x1968398 Offset: 0x1968398 VA: 0x1968398
	// private int BGDCMGOPCGE(byte[] FIKCHOLCKNJ) { }

	// // RVA: 0x1968408 Offset: 0x1968408 VA: 0x1968408
	public bool PCODDPDFLHK()
    {
        UnityEngine.Debug.LogError("TODO MMOLNAHHDOM unitLiveLocalSaveData PCODDPDFLHK");
        return true;
    }

	// // RVA: 0x1968E50 Offset: 0x1968E50 VA: 0x1968E50
	public bool HJMKBCFJOOH(bool FBBNPFFEJBN = false)
    {
        UnityEngine.Debug.LogError("TODO MMOLNAHHDOM unitLiveLocalSaveData HJMKBCFJOOH");
        return false;
    }

	// // RVA: 0x1968CF4 Offset: 0x1968CF4 VA: 0x1968CF4
	// public void JCHLONCMPAJ(bool OGBEGDKPDGK) { }

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
