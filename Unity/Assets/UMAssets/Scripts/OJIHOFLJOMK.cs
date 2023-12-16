
using System;
using UnityEngine;

public class OJIHOFLJOMK
{
	public const int BEJOOFOKHHM = 0;
	public const int DKEDBBMCDFD = 101;
	public const int IJMKDNBINKO = 102;
	public const int NKCEDCIJFOA = 103;
	private int JHGGFNECJOH = -1; // 0x8
	private AndroidJavaObject MNAADDLICIB; // 0xC
	private bool PMDGOAEICPG; // 0x10
	private static string LJNAKDMILMC = "key"; // 0x0

	//public bool KHIPIEBAFFL { get; }

	//// RVA: 0x148D880 Offset: 0x148D880 VA: 0x148D880
	//public bool PIHFAMLNOOL() { }

	//// RVA: 0x148D888 Offset: 0x148D888 VA: 0x148D888
	//private static string CKFBNINKAPG(int IGHPMLOFGMO) { }

	//// RVA: 0x148D8E4 Offset: 0x148D8E4 VA: 0x148D8E4
	public void KHEKNNFCAOI()
	{
		#if UNITY_ANDROID
		MNAADDLICIB = new AndroidJavaObject("jp.co.xeen.xeapp.LocalNotification", Array.Empty<object>());
		#endif
	}

	//// RVA: 0x148D984 Offset: 0x148D984 VA: 0x148D984
	//private void BJOPNMIFIIM() { }

	//// RVA: 0x148DA08 Offset: 0x148DA08 VA: 0x148DA08
	//public void KNPBADBCOLO(string LEAIFBMIEIG, long PEJIPAFKHKM, int NNGBINEKMNO, string LBNFBJFBDDE, string ADCMNODJBGJ, string LJGOOOMOMMA) { }

	//// RVA: 0x148DD70 Offset: 0x148DD70 VA: 0x148DD70
	public void LKCPCCANJFB(string LEAIFBMIEIG, long PEJIPAFKHKM, int NNGBINEKMNO, string ADCMNODJBGJ, string LJGOOOMOMMA, int EAHPLCJMPHD, string JJCAHFAOPNI = "png")
	{
		if(MNAADDLICIB != null)
		{
			MNAADDLICIB.CallStatic("send", new object[7] {
				PEJIPAFKHKM, NNGBINEKMNO, "", ADCMNODJBGJ, LJGOOOMOMMA, "", LEAIFBMIEIG
			});
		}
	}

	//// RVA: 0x148E13C Offset: 0x148E13C VA: 0x148E13C
	public void JCHLONCMPAJ(int NNGBINEKMNO)
	{
		if(MNAADDLICIB != null)
		{
			MNAADDLICIB.CallStatic("clear", new object[1] { NNGBINEKMNO });
		}
	}

	//// RVA: 0x148E25C Offset: 0x148E25C VA: 0x148E25C
	//public void EMLBCNAHHLD() { }

	//// RVA: 0x148E260 Offset: 0x148E260 VA: 0x148E260
	public bool PLIGGNOHLJE()
	{
		if(MNAADDLICIB != null)
		{
			return MNAADDLICIB.CallStatic<bool>("isNotificationEnabled", Array.Empty<object>());
		}
		return false;
	}

	//// RVA: 0x148E300 Offset: 0x148E300 VA: 0x148E300
	//public void LCICDJDNPNA() { }

	//// RVA: 0x148E38C Offset: 0x148E38C VA: 0x148E38C
	//public static bool DCCNLMAODGN() { }

	//// RVA: 0x148E394 Offset: 0x148E394 VA: 0x148E394
	public static void JOAJCEDHKFP()
	{
		return;
	}
}
