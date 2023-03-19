
using System;
using System.Collections;
using XeApp.Game;
using XeSys;

public class PGIGNJDPCAH
{
    public enum IMOIPBMGIPN
    {
        HJNNKCMLGFL = 0,
        MGEFLLPGDDN = 1,
        OGFOHBGEAEC = 2,
        CKOMFNPGHOM = 3,
        PJPJEHEFMMJ = 4,
    }

    public enum FELLIEJEPIJ
    {
        JBAIEADLAGH = 0,
        FFPANKMKAPD = 1,
        NADCOIBMMJM = 2,
        ONHOCOBCINO = 3,
        ANGNLABPOIH = 4,
        LPBDIINNFEE = 5,
    }

	private static FELLIEJEPIJ EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH; // 0x0
	private static bool LMGGIBJPGLE = true; // 0x4
	public static bool OGAIOKGEMDE = false; // 0x5
	private static bool LANLFCFBOHI = false; // 0x6
	private static int OANIGHDIKJH; // 0x8

	public static bool IPJMPBANBPP { 
		get {
			// IJMCHOOIMBB 0x16C982C 
			return LMGGIBJPGLE;
		}
		set{
			//FLHLJFHILPO 0x16C98B8 
			if(value == LMGGIBJPGLE)
				return;
			LMGGIBJPGLE = value;
		}
	} 
	private static int HIJBIPLMNEA { get { return OANIGHDIKJH ^ 0x3f587e47; } set { OANIGHDIKJH = value ^ 0x3f587e47; } } // IDLMAHADDKO 0x16CA0EC  PPDOPFGBPAM 0x16CA184

	// // RVA: 0x16C998C Offset: 0x16C998C VA: 0x16C998C
	public static void MLPMNKKNFCJ()
    {
        LANLFCFBOHI = false;
    }

	// // RVA: 0x16C9A1C Offset: 0x16C9A1C VA: 0x16C9A1C
	public static void NNOBACMJHDM(FELLIEJEPIJ PPFNGGCBJKC)
    {
		EPDEBBDHFCH = PPFNGGCBJKC;
		IPJMPBANBPP = false;
    }

	// // RVA: 0x16C9AB4 Offset: 0x16C9AB4 VA: 0x16C9AB4
	public static void HIHIEBACIHJ(FELLIEJEPIJ PPFNGGCBJKC)
	{
		switch(PPFNGGCBJKC)
		{
			case FELLIEJEPIJ.JBAIEADLAGH/*0*/:
				EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH/*0*/;
				IPJMPBANBPP = true;
				break;
			case FELLIEJEPIJ.FFPANKMKAPD/*1*/:
				EPDEBBDHFCH = FELLIEJEPIJ.FFPANKMKAPD/*1*/;
				IPJMPBANBPP = false;
				return;
			case FELLIEJEPIJ.NADCOIBMMJM/*2*/:
				if (EPDEBBDHFCH != FELLIEJEPIJ.NADCOIBMMJM/*2*/)
					return;
				EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH/*0*/;
				IPJMPBANBPP = true;
				break;
			case FELLIEJEPIJ.ONHOCOBCINO/*3*/:
				OGAIOKGEMDE = false;
				return;
			case FELLIEJEPIJ.ANGNLABPOIH/*4*/:
				if (EPDEBBDHFCH != FELLIEJEPIJ.ANGNLABPOIH/*4*/)
					return;
				EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH/*0*/;
				IPJMPBANBPP = true;
				break;
			case FELLIEJEPIJ.LPBDIINNFEE/*5*/:
				if (EPDEBBDHFCH != FELLIEJEPIJ.LPBDIINNFEE/*5*/)
					return;
				EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH/*0*/;
				IPJMPBANBPP = true;
				break;
			default:
				return;
		}
	}

	// // RVA: 0x16C9D9C Offset: 0x16C9D9C VA: 0x16C9D9C
	public static IMOIPBMGIPN AIMFCMCMOIH()
	{
		if(IPJMPBANBPP)
		{
			KPKEOIJHIMN.GIDACIOHFNN v = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.DAOHAKABAFG.PGBOFGNOBLD();
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			bool b = BBGDKLLEPIB.HHCJCDFCLOB.KHJHKNLEOAB(time);
			bool b2 = IMMAOANGPNK.HHCJCDFCLOB.MKINIELBKEK(time);
			bool b3 = IMMAOANGPNK.HHCJCDFCLOB.JMAMHEJDNNN(time);
			if(v != KPKEOIJHIMN.GIDACIOHFNN.GJCDHOAEIHP/*2*/ && !b && !b2 && !b3)
			{
				IMOIPBMGIPN a = IMOIPBMGIPN.HJNNKCMLGFL/*0*/;
				if(!OGAIOKGEMDE)
				{
					a = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.LOMEEJGIAHO.LNLCIMPFCEK(time) ? IMOIPBMGIPN.OGFOHBGEAEC/*2*/ : IMOIPBMGIPN.HJNNKCMLGFL/*0*/;
				}
				return a;
			}
			return IMOIPBMGIPN.MGEFLLPGDDN/*1*/;
		}
		return IMOIPBMGIPN.HJNNKCMLGFL/*0*/;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8B48 Offset: 0x6B8B48 VA: 0x6B8B48
	// // RVA: 0x16CA220 Offset: 0x16CA220 VA: 0x16CA220
	private static IEnumerator OOILBGOKHDC_Co_ReGetSeverTime(bool FBBNPFFEJBN, IMCBBOAFION GIMKOLPGIAO, IMCBBOAFION MBIKIBHLAGE)
	{
		NADBPLMLIJA_GetToken PNLGHFCFPPK_GetToken;
		
		//0x16CA7E4
		GameManager.Instance.InputEnabled = false;
		PNLGHFCFPPK_GetToken = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NADBPLMLIJA_GetToken());
		PNLGHFCFPPK_GetToken.ALJHFFCKBDP = true;
		yield return PNLGHFCFPPK_GetToken.GDPDELLNOBO_WaitDone(N.a);
		GameManager.Instance.InputEnabled = true;
		bool error = PNLGHFCFPPK_GetToken.NPNNPNAIONN_IsError;
		PNLGHFCFPPK_GetToken = null;
		if(error)
		{
			MBIKIBHLAGE();
		}
		else
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			DateTime date = Utility.GetLocalDateTime(time);
			if(!FBBNPFFEJBN)
			{
				if(HIJBIPLMNEA == date.Month * 100 + date.Year * 100000 + date.Day)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.KJJLCKFLIML_ShowDteLineErrorPopup(MBIKIBHLAGE);
					yield break;
				}
			}
			NKGJPJPHLIF.HHCJCDFCLOB.EFPOACOOAFB(FBBNPFFEJBN);
			GIMKOLPGIAO();
		}
	}

	// // RVA: 0x16CA300 Offset: 0x16CA300 VA: 0x16CA300
	public static bool MNANNMDBHMP(IMCBBOAFION GIMKOLPGIAO_OnSuccess, IMCBBOAFION MBIKIBHLAGE_OnError)
	{
		if(!LANLFCFBOHI)
		{
			IMOIPBMGIPN EALOBDHOCHP = AIMFCMCMOIH();
			switch(EALOBDHOCHP)
			{
				case IMOIPBMGIPN.MGEFLLPGDDN:
				case IMOIPBMGIPN.CKOMFNPGHOM:
					NKGJPJPHLIF.HHCJCDFCLOB.NIJDPPHGHFD_ResetDates(EALOBDHOCHP == IMOIPBMGIPN.CKOMFNPGHOM/*3*/);
					JHHBAFKMBDL.HHCJCDFCLOB.CIKMDHMMCIL_ShowErrorPopup(2, MBIKIBHLAGE_OnError);
					LANLFCFBOHI = true;
					return true;
				break;
				case IMOIPBMGIPN.OGFOHBGEAEC:
				case IMOIPBMGIPN.PJPJEHEFMMJ:
					JHHBAFKMBDL.HHCJCDFCLOB.PNIJEKOHEII(() =>
					{
						//0x16CA6C8
						HIJBIPLMNEA = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
						N.a.StartCoroutineWatched(OOILBGOKHDC_Co_ReGetSeverTime(EALOBDHOCHP == IMOIPBMGIPN.CKOMFNPGHOM, GIMKOLPGIAO_OnSuccess, MBIKIBHLAGE_OnError));
					});
					LANLFCFBOHI = true;
					return true;
				break;
			}
		}
		return false;
	}
}
