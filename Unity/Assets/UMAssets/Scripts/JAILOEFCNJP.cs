
using System.Collections.Generic;

public class JAILOEFCNJP
{
	public enum BEBLECKOAPK
	{
		HJNNKCMLGFL_0_None = 0,
		GIDILNEPILF_1 = 1,
		KNBIMNIGANP_2 = 2,
	}

	public const long HEJACPECLEH = 9223372036854775807;
	public const int MBCILHCMGIO = 0;

	// RVA: 0x141479C Offset: 0x141479C VA: 0x141479C
	public static bool GEOMLGKCCNI(LGIDLHLBFFJ_MonthlyPass _HMMNDKHKEBC_MonthlyPass, List<BCEHKBJAEDM> IDOLJENFBPM, long _JHNMKKNEENE_Time, out string HACIJHPHFHH, out BEBLECKOAPK MKBOKLLDCFI)
	{
		HACIJHPHFHH = _HMMNDKHKEBC_MonthlyPass.POGHKGLHHFL();
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
					a = k.LKCCMBEOLLA.NKMNFPMMJND_expired_at;
				}
				long d = 0;
				if(k.PACPEOKLGCI_Google != null)
				{
					d = k.PACPEOKLGCI_Google.NKMNFPMMJND_expired_at;
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
				c2 = data.PACPEOKLGCI_Google;
				if(data.LKCCMBEOLLA != null)
				{
					c = data.LKCCMBEOLLA;
					t2 = c.FDFGEMODIIF_StartedAt;
					t = c.NKMNFPMMJND_expired_at;
					b = true;
				}
			}
		}
		bool b2 = false;
		if(_HMMNDKHKEBC_MonthlyPass.AOHBAOAPGDM_Raw[0].NKMNFPMMJND_expired_at != t)
		{
			_HMMNDKHKEBC_MonthlyPass.AOHBAOAPGDM_Raw[0].FDFGEMODIIF_StartedAt = t2;
			_HMMNDKHKEBC_MonthlyPass.AOHBAOAPGDM_Raw[0].NKMNFPMMJND_expired_at = t;
			_HMMNDKHKEBC_MonthlyPass.AOHBAOAPGDM_Raw[0].EMOHDABPCHD_CheckAt = _JHNMKKNEENE_Time;
			b2 = true;
		}
		long t3 = 0;
		long t4 = 0;
		if(b)
		{
			t3 = c.NKMNFPMMJND_expired_at;
			t4 = c.FDFGEMODIIF_StartedAt;
			if(c2 != null)
			{
				if(t3 < c2.NKMNFPMMJND_expired_at)
				{
					t3 = c2.NKMNFPMMJND_expired_at;
					HACIJHPHFHH = _HMMNDKHKEBC_MonthlyPass.KIHJLOGLAGI();
					MKBOKLLDCFI = BEBLECKOAPK.KNBIMNIGANP_2;
				}
			}
		}
		else
		{
			if(c2 != null)
			{
				t3 = c2.NKMNFPMMJND_expired_at;
				t4 = c2.FDFGEMODIIF_StartedAt;
				HACIJHPHFHH = _HMMNDKHKEBC_MonthlyPass.KIHJLOGLAGI();
				MKBOKLLDCFI = BEBLECKOAPK.KNBIMNIGANP_2;
			}
		}
		b = false;
		if(_HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].NKMNFPMMJND_expired_at != t3)
		{
			_HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt = t4;
			_HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].NKMNFPMMJND_expired_at = t3;
			_HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].EMOHDABPCHD_CheckAt = _JHNMKKNEENE_Time;
			b2 = true;
		}
		if(_HMMNDKHKEBC_MonthlyPass.DNKJAIHCDFN_First[0].NKMNFPMMJND_expired_at == 0 && t3 != 0)
		{
			if(_HMMNDKHKEBC_MonthlyPass.DNKJAIHCDFN_First[0].EMOHDABPCHD_CheckAt == 0)
			{
				_HMMNDKHKEBC_MonthlyPass.DNKJAIHCDFN_First[0].FDFGEMODIIF_StartedAt = t4;
				_HMMNDKHKEBC_MonthlyPass.DNKJAIHCDFN_First[0].NKMNFPMMJND_expired_at = t3;
				_HMMNDKHKEBC_MonthlyPass.DNKJAIHCDFN_First[0].EMOHDABPCHD_CheckAt = _JHNMKKNEENE_Time;
			}
		}
		return b2;
	}
}
