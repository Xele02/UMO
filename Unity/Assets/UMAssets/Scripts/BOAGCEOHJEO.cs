
using System;

public class BOAGCEOHJEO
{
	// Fields
	public const double EKKGJBPGLDN = 0.49f;

	//// RVA: 0x19CBBA8 Offset: 0x19CBBA8 VA: 0x19CBBA8
	//public static double LLPDMEJCMGA(long KINJOEIAHFK, long PCCFAKEOBIC, long KNIKOPJKPCI) { }

	//// RVA: 0x19CBC78 Offset: 0x19CBC78 VA: 0x19CBC78
	public static double GOAOBNBGDBJ(long KINJOEIAHFK, long PCCFAKEOBIC, long KNIKOPJKPCI, long DNBFMLBNAEE)
	{
		long pKNIKOPJKPCI = KNIKOPJKPCI;
		if (KNIKOPJKPCI == 0)
			KNIKOPJKPCI = PCCFAKEOBIC;
		double d = (PCCFAKEOBIC - KNIKOPJKPCI) * 0.49f / (PCCFAKEOBIC - pKNIKOPJKPCI);
		if (d < 0)
			d = 0;
		if (d >= 0.49f)
			d = 0.49f;
		return d + DNBFMLBNAEE;
	}

	//// RVA: 0x19CBD60 Offset: 0x19CBD60 VA: 0x19CBD60
	public static double CFLDNJANAPI_Truncate(double IGFLJCNGAML)
	{
		return Math.Truncate(IGFLJCNGAML);
	}

	//// RVA: 0x19CBDEC Offset: 0x19CBDEC VA: 0x19CBDEC
	public static void IIEMACPEEBJ(EDOHBJAPLPF_JsonData IDLHJIOMJBK, out double IGFLJCNGAML, out long DNBFMLBNAEE)
	{
		IGFLJCNGAML = 0;
		if (IDLHJIOMJBK.NFPOKKABOHN_IsDouble)
		{
			IGFLJCNGAML = (double)IDLHJIOMJBK;
		}
		else if(IDLHJIOMJBK.MDDJBLEDMBJ_IsInt)
		{
			IGFLJCNGAML = (int)IDLHJIOMJBK;
		}
		else if(IDLHJIOMJBK.DCPEFFOMOOK_IsLong)
		{
			IGFLJCNGAML = (long)IDLHJIOMJBK;
		}
		DNBFMLBNAEE = (long)CFLDNJANAPI_Truncate(IGFLJCNGAML);
	}
}
