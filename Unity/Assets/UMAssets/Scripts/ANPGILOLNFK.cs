
public class ANPGILOLNFK
{
	public enum CDOGFBNLIPG_LoginBonusType
	{
		HJNNKCMLGFL_0_None = 0,
		PHABJLGFJNI_1_Regular = 1,
		OFADCIAGMDG_2_Continue = 2,
		DHGCJEOPEIE_3_Comback1 = 3,
		CEIJKIOOIPE_4_Comback2 = 4,
		LAOEGNLOJHC_5_Start = 5,
		NOBPFBOJLJD_6_Campaign = 6,
		MKADAMIGMPO_7_Total = 7,
		KEBIIAMNKAJ_8_Return = 8,
	}

	public static string[] POFDDFCGEGP_Underscore = new string[9] {
		"", "regular", "continue", "comback1", "comback2", "start", "campaign", "total", "return"
	}; // 0x0
	public static int[] FENFHPPHCBE = new int[9] {
		100, 30, 40, 10, 20, 50, 60, 70, 0
	}; // 0x4

	//// RVA: 0xD573E0 Offset: 0xD573E0 VA: 0xD573E0
	public static CDOGFBNLIPG_LoginBonusType OLMFIANJBOB_GetType(string _BPEAIOBHMFD_name_for_apis)
	{
		for(int i = 1; i < POFDDFCGEGP_Underscore.Length; i++)
		{
			if(_BPEAIOBHMFD_name_for_apis.Contains(POFDDFCGEGP_Underscore[i]))
				return (CDOGFBNLIPG_LoginBonusType)(i);
		}
		return CDOGFBNLIPG_LoginBonusType.HJNNKCMLGFL_0_None;
	}

	//// RVA: 0xD57550 Offset: 0xD57550 VA: 0xD57550
	public static int AFMHNPCDAFI_GetBgId(string _BPEAIOBHMFD_name_for_apis)
	{
		int idx = _BPEAIOBHMFD_name_for_apis.IndexOf("_bg_");
		if(idx > -1)
		{
			string s = _BPEAIOBHMFD_name_for_apis.Substring(idx + 4);
			int id = 0;
			if(int.TryParse(s, out id))
				return id;
		}
		return 0;
	}
}
