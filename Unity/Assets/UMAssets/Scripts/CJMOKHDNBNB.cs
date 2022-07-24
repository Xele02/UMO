
public class CJMOKHDNBNB
{
	private static bool PCIIJLFIEFH; // 0x0
	private static bool MNBLHMNIGFE; // 0x1
	private static string OAFCIACBJNN; // 0x4
	private static string HMGCLBLBMKN; // 0x8

	public static string FIPFFELDIOG_PersistentPath { get { // MIGEKMKBPFM 0x107CD20
        if(!PCIIJLFIEFH)
        {
            if(!MNBLHMNIGFE)
                NLLNGLNEFOC();
            KHEKNNFCAOI_Init();
        }
        return OAFCIACBJNN;
    } } 
	// public static string NPDKPLJENOJ { get; }

	// // RVA: 0x107CFDC Offset: 0x107CFDC VA: 0x107CFDC
	// public static string KEPPNAKFDIF() { }

	// // RVA: 0x107CF18 Offset: 0x107CF18 VA: 0x107CF18
	public static void KHEKNNFCAOI_Init()
    {
        OAFCIACBJNN = UnityEngine.Application.persistentDataPath;
        HMGCLBLBMKN = UnityEngine.Application.persistentDataPath;
        PCIIJLFIEFH = true;
    }

	// // RVA: 0x107D0D4 Offset: 0x107D0D4 VA: 0x107D0D4
	// private static void KEBJPAEBMAI(string GPBJHKLFCEP, string CNHEPCPELGK, string OPFGFINHFCE, bool CCDFELBFMIE) { }

	// // RVA: 0x107D1C8 Offset: 0x107D1C8 VA: 0x107D1C8
	// public static void CHFFHOKMEMA() { }

	// // RVA: 0x107CE84 Offset: 0x107CE84 VA: 0x107CE84
	public static void NLLNGLNEFOC()
    {
        MNBLHMNIGFE = false;
        KHEKNNFCAOI_Init();
    }
}
