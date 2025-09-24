
using System;

public class BOAGCEOHJEO
{
	// Fields
	public const double EKKGJBPGLDN = 0.49f;

	//// RVA: 0x19CBBA8 Offset: 0x19CBBA8 VA: 0x19CBBA8
	//public static double LLPDMEJCMGA(long _KINJOEIAHFK_StartTime, long _PCCFAKEOBIC_EndTime, long _KNIKOPJKPCI_GetTime) { }

	//// RVA: 0x19CBC78 Offset: 0x19CBC78 VA: 0x19CBC78
	public static double GOAOBNBGDBJ(long _KINJOEIAHFK_StartTime, long _PCCFAKEOBIC_EndTime, long _KNIKOPJKPCI_GetTime, long _DNBFMLBNAEE_point)
	{
		long pKNIKOPJKPCI_GetTime = _KNIKOPJKPCI_GetTime;
		if (_KNIKOPJKPCI_GetTime == 0)
			_KNIKOPJKPCI_GetTime = _PCCFAKEOBIC_EndTime;
		double d = (_PCCFAKEOBIC_EndTime - _KNIKOPJKPCI_GetTime) * 0.49f / (_PCCFAKEOBIC_EndTime - pKNIKOPJKPCI_GetTime);
		if (d < 0)
			d = 0;
		if (d >= 0.49f)
			d = 0.49f;
		return d + _DNBFMLBNAEE_point;
	}

	//// RVA: 0x19CBD60 Offset: 0x19CBD60 VA: 0x19CBD60
	public static double CFLDNJANAPI_Truncate(double IGFLJCNGAML)
	{
		return Math.Truncate(IGFLJCNGAML);
	}

	//// RVA: 0x19CBDEC Offset: 0x19CBDEC VA: 0x19CBDEC
	public static void IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, out double IGFLJCNGAML, out long _DNBFMLBNAEE_point)
	{
		IGFLJCNGAML = 0;
		if (_IDLHJIOMJBK_data.NFPOKKABOHN_IsDouble)
		{
			IGFLJCNGAML = (double)_IDLHJIOMJBK_data;
		}
		else if(_IDLHJIOMJBK_data.MDDJBLEDMBJ_IsInt)
		{
			IGFLJCNGAML = (int)_IDLHJIOMJBK_data;
		}
		else if(_IDLHJIOMJBK_data.DCPEFFOMOOK_IsLong)
		{
			IGFLJCNGAML = (long)_IDLHJIOMJBK_data;
		}
		_DNBFMLBNAEE_point = (long)CFLDNJANAPI_Truncate(IGFLJCNGAML);
	}
}
