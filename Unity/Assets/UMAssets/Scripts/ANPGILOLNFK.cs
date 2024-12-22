
public class ANPGILOLNFK
{
	public enum CDOGFBNLIPG
	{
		HJNNKCMLGFL_0 = 0,
		PHABJLGFJNI_1 = 1,
		OFADCIAGMDG = 2,
		DHGCJEOPEIE_3 = 3,
		CEIJKIOOIPE_4 = 4,
		LAOEGNLOJHC_5 = 5,
		NOBPFBOJLJD = 6,
		MKADAMIGMPO_7 = 7,
		KEBIIAMNKAJ = 8,
	}

	public static string[] POFDDFCGEGP = new string[9] {
		"", "regular", "continue", "comback1", "comback2", "start", "campaign", "total", "return"
	}; // 0x0
	public static int[] FENFHPPHCBE = new int[9] {
		100, 30, 40, 10, 20, 50, 60, 70, 0
	}; // 0x4

	//// RVA: 0xD573E0 Offset: 0xD573E0 VA: 0xD573E0
	public static CDOGFBNLIPG OLMFIANJBOB_GetType(string BPEAIOBHMFD)
	{
		for(int i = 1; i < POFDDFCGEGP.Length; i++)
		{
			if(BPEAIOBHMFD.Contains(POFDDFCGEGP[i]))
				return (CDOGFBNLIPG)(i);
		}
		return CDOGFBNLIPG.HJNNKCMLGFL_0;
	}

	//// RVA: 0xD57550 Offset: 0xD57550 VA: 0xD57550
	public static int AFMHNPCDAFI_GetBgId(string BPEAIOBHMFD)
	{
		int idx = BPEAIOBHMFD.IndexOf("_bg_");
		if(idx > -1)
		{
			string s = BPEAIOBHMFD.Substring(idx + 4);
			int id = 0;
			if(int.TryParse(s, out id))
				return id;
		}
		return 0;
	}
}
