
using System.Collections.Generic;

public class JAILOEFCNJP
{
	public enum BEBLECKOAPK
	{
		HJNNKCMLGFL = 0,
		GIDILNEPILF_1 = 1,
		KNBIMNIGANP_2 = 2,
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
		bool b = false;
		if (IDOLJENFBPM.Count > 0)
		{
			BCEHKBJAEDM data = null;
			long dataL = 0;
			foreach(var k in IDOLJENFBPM)
			{
				long a = 0;
				if(k.LKCCMBEOLLA != null)
				{
					a = k.LKCCMBEOLLA.NKMNFPMMJND;
				}
				long d = 0;
				if(k.PACPEOKLGCI != null)
				{
					d = k.PACPEOKLGCI.NKMNFPMMJND;
				}
				if(a < d)
				{
					a = d;
				}
				if(dataL < a)
				{
					dataL = a;
					data = k;
				}
			}
			b = false;
			if(data != null)
			{
				c2 = data.PACPEOKLGCI;
				if(data.LKCCMBEOLLA != null)
				{
					c = data.LKCCMBEOLLA;
					t2 = c.FDFGEMODIIF;
					t = c.NKMNFPMMJND;
					b = true;
				}
			}
		}
		bool b2 = false;
		if(HMMNDKHKEBC.AOHBAOAPGDM_Raw[0].NKMNFPMMJND_ExpiredAt != t)
		{
			HMMNDKHKEBC.AOHBAOAPGDM_Raw[0].FDFGEMODIIF_StartedAt = t2;
			HMMNDKHKEBC.AOHBAOAPGDM_Raw[0].NKMNFPMMJND_ExpiredAt = t;
			HMMNDKHKEBC.AOHBAOAPGDM_Raw[0].EMOHDABPCHD_CheckAt = JHNMKKNEENE;
			b2 = true;
		}
		long t3 = 0;
		long t4 = 0;
		if(b)
		{
			t3 = c.NKMNFPMMJND;
			t4 = c.FDFGEMODIIF;
			if(c2 != null)
			{
				if(t3 < c2.NKMNFPMMJND)
				{
					t3 = c2.NKMNFPMMJND;
					HACIJHPHFHH = HMMNDKHKEBC.KIHJLOGLAGI();
					MKBOKLLDCFI = BEBLECKOAPK.KNBIMNIGANP_2;
				}
			}
		}
		else
		{
			if(c2 != null)
			{
				t3 = c2.NKMNFPMMJND;
				t4 = c2.FDFGEMODIIF;
				HACIJHPHFHH = HMMNDKHKEBC.KIHJLOGLAGI();
				MKBOKLLDCFI = BEBLECKOAPK.KNBIMNIGANP_2;
			}
		}
		b = false;
		if(HMMNDKHKEBC.FMPLMFLMJNE_Last[0].NKMNFPMMJND_ExpiredAt != t3)
		{
			HMMNDKHKEBC.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt = t4;
			HMMNDKHKEBC.FMPLMFLMJNE_Last[0].NKMNFPMMJND_ExpiredAt = t3;
			HMMNDKHKEBC.FMPLMFLMJNE_Last[0].EMOHDABPCHD_CheckAt = JHNMKKNEENE;
			b2 = true;
		}
		if(HMMNDKHKEBC.DNKJAIHCDFN_First[0].NKMNFPMMJND_ExpiredAt == 0 && t3 != 0)
		{
			if(HMMNDKHKEBC.DNKJAIHCDFN_First[0].EMOHDABPCHD_CheckAt == 0)
			{
				HMMNDKHKEBC.DNKJAIHCDFN_First[0].FDFGEMODIIF_StartedAt = t4;
				HMMNDKHKEBC.DNKJAIHCDFN_First[0].NKMNFPMMJND_ExpiredAt = t3;
				HMMNDKHKEBC.DNKJAIHCDFN_First[0].EMOHDABPCHD_CheckAt = JHNMKKNEENE;
			}
		}
		return b2;
	}
}
