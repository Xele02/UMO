
using System.Collections.Generic;

public class JAILOEFCNJP
{
	public enum BEBLECKOAPK
	{
		HJNNKCMLGFL = 0,
		GIDILNEPILF_1 = 1,
		KNBIMNIGANP = 2,
	}

	public const long HEJACPECLEH = 9223372036854775807;
	public const int MBCILHCMGIO = 0;

	// RVA: 0x141479C Offset: 0x141479C VA: 0x141479C
	public static bool GEOMLGKCCNI(LGIDLHLBFFJ_MonthlyPass HMMNDKHKEBC, List<BCEHKBJAEDM> IDOLJENFBPM, long JHNMKKNEENE, out string HACIJHPHFHH, out BEBLECKOAPK MKBOKLLDCFI)
	{
		HACIJHPHFHH = HMMNDKHKEBC.POGHKGLHHFL();
		MKBOKLLDCFI = BEBLECKOAPK.GIDILNEPILF_1/*1*/;
		long t = 0;
		long t2 = 0;
		CLHMBMLOAOE c = null;
		CLHMBMLOAOE c2 = null;
		if (IDOLJENFBPM.Count > 0)
		{
			TodoLogger.LogError(0, "GEOMLGKCCNI");
		}
		bool b = false;
		if(HMMNDKHKEBC.AOHBAOAPGDM_Raw[0].NKMNFPMMJND_ExpiredAt != t)
		{
			HMMNDKHKEBC.AOHBAOAPGDM_Raw[0].FDFGEMODIIF_StartedAt = t2;
			HMMNDKHKEBC.AOHBAOAPGDM_Raw[0].NKMNFPMMJND_ExpiredAt = t;
			HMMNDKHKEBC.AOHBAOAPGDM_Raw[0].EMOHDABPCHD_CheckAt = JHNMKKNEENE;
			b = true;
		}
		long t3 = 0;
		if(b)
		{
			TodoLogger.LogError(0, "GEOMLGKCCNI");
		}
		else
		{
			if(c2 == null)
			{
				;
			}
			else
			{
				TodoLogger.LogError(0, "GEOMLGKCCNI");
			}
		}
		b = false;
		if(HMMNDKHKEBC.FMPLMFLMJNE_Last[0].NKMNFPMMJND_ExpiredAt != t3)
		{
			HMMNDKHKEBC.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt = t2;
			HMMNDKHKEBC.FMPLMFLMJNE_Last[0].NKMNFPMMJND_ExpiredAt = t;
			HMMNDKHKEBC.FMPLMFLMJNE_Last[0].EMOHDABPCHD_CheckAt = JHNMKKNEENE;
			b = true;
		}
		if(HMMNDKHKEBC.DNKJAIHCDFN_First[0].NKMNFPMMJND_ExpiredAt == 0 && t3 != 0)
		{
			TodoLogger.LogError(0, "GEOMLGKCCNI");
		}
		return b;
	}
}
