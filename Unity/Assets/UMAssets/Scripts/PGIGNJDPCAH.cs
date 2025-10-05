
using System;
using System.Collections;
using XeApp.Game;
using XeSys;

public class PGIGNJDPCAH
{
    public enum IMOIPBMGIPN
    {
        HJNNKCMLGFL_0_None = 0,
        MGEFLLPGDDN = 1,
        OGFOHBGEAEC = 2,
        CKOMFNPGHOM = 3,
        PJPJEHEFMMJ = 4,
    }

    public enum FELLIEJEPIJ
    {
        JBAIEADLAGH_0 = 0,
        FFPANKMKAPD_1_Title = 1,
        NADCOIBMMJM = 2,
        ONHOCOBCINO_3 = 3,
        ANGNLABPOIH_4 = 4,
        LPBDIINNFEE_5 = 5,
    }

	private static FELLIEJEPIJ EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH_0; // 0x0
	private static bool LMGGIBJPGLE = true; // 0x4
	public static bool OGAIOKGEMDE = false; // 0x5
	private static bool LANLFCFBOHI = false; // 0x6
	private static int OANIGHDIKJH; // 0x8

	public static bool IPJMPBANBPP_Enabled { 
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
	private static int HIJBIPLMNEA { get { return OANIGHDIKJH ^ 0x3f587e47; } set { OANIGHDIKJH = value ^ 0x3f587e47; } } // IDLMAHADDKO_bgs 0x16CA0EC  PPDOPFGBPAM_bgs 0x16CA184

	// // RVA: 0x16C998C Offset: 0x16C998C VA: 0x16C998C
	public static void MLPMNKKNFCJ()
    {
        LANLFCFBOHI = false;
    }

	// // RVA: 0x16C9A1C Offset: 0x16C9A1C VA: 0x16C9A1C
	public static void NNOBACMJHDM(FELLIEJEPIJ _PPFNGGCBJKC_id)
    {
		EPDEBBDHFCH = _PPFNGGCBJKC_id;
		IPJMPBANBPP_Enabled = false;
    }

	// // RVA: 0x16C9AB4 Offset: 0x16C9AB4 VA: 0x16C9AB4
	public static void HIHIEBACIHJ(FELLIEJEPIJ _PPFNGGCBJKC_id)
	{
		switch(_PPFNGGCBJKC_id)
		{
			case FELLIEJEPIJ.JBAIEADLAGH_0/*0*/:
				EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH_0/*0*/;
				IPJMPBANBPP_Enabled = true;
				break;
			case FELLIEJEPIJ.FFPANKMKAPD_1_Title/*1*/:
				EPDEBBDHFCH = FELLIEJEPIJ.FFPANKMKAPD_1_Title/*1*/;
				IPJMPBANBPP_Enabled = false;
				return;
			case FELLIEJEPIJ.NADCOIBMMJM/*2*/:
				if (EPDEBBDHFCH != FELLIEJEPIJ.NADCOIBMMJM/*2*/)
					return;
				EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH_0/*0*/;
				IPJMPBANBPP_Enabled = true;
				break;
			case FELLIEJEPIJ.ONHOCOBCINO_3/*3*/:
				OGAIOKGEMDE = false;
				return;
			case FELLIEJEPIJ.ANGNLABPOIH_4/*4*/:
				if (EPDEBBDHFCH != FELLIEJEPIJ.ANGNLABPOIH_4/*4*/)
					return;
				EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH_0/*0*/;
				IPJMPBANBPP_Enabled = true;
				break;
			case FELLIEJEPIJ.LPBDIINNFEE_5/*5*/:
				if (EPDEBBDHFCH != FELLIEJEPIJ.LPBDIINNFEE_5/*5*/)
					return;
				EPDEBBDHFCH = FELLIEJEPIJ.JBAIEADLAGH_0/*0*/;
				IPJMPBANBPP_Enabled = true;
				break;
			default:
				return;
		}
	}

	// // RVA: 0x16C9D9C Offset: 0x16C9D9C VA: 0x16C9D9C
	public static IMOIPBMGIPN AIMFCMCMOIH()
	{
		if(IPJMPBANBPP_Enabled)
		{
			KPKEOIJHIMN.GIDACIOHFNN_UpdateState v = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.DAOHAKABAFG.PGBOFGNOBLD();
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			bool b = BBGDKLLEPIB.HHCJCDFCLOB.KHJHKNLEOAB(time);
			bool b2 = IMMAOANGPNK.HHCJCDFCLOB.MKINIELBKEK(time);
			bool b3 = IMMAOANGPNK.HHCJCDFCLOB.JMAMHEJDNNN_IsScheduledEvent(time);
			if(v != KPKEOIJHIMN.GIDACIOHFNN_UpdateState.GJCDHOAEIHP_2_NewDownloadData/*2*/ && !b && !b2 && !b3)
			{
				IMOIPBMGIPN a = IMOIPBMGIPN.HJNNKCMLGFL_0_None/*0*/;
				if(!OGAIOKGEMDE)
				{
					a = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.LOMEEJGIAHO.LNLCIMPFCEK(time) ? IMOIPBMGIPN.OGFOHBGEAEC/*2*/ : IMOIPBMGIPN.HJNNKCMLGFL_0_None/*0*/;
				}
				return a;
			}
			return IMOIPBMGIPN.MGEFLLPGDDN/*1*/;
		}
		return IMOIPBMGIPN.HJNNKCMLGFL_0_None/*0*/;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8B48 Offset: 0x6B8B48 VA: 0x6B8B48
	// // RVA: 0x16CA220 Offset: 0x16CA220 VA: 0x16CA220
	private static IEnumerator OOILBGOKHDC_Co_ReGetSeverTime(bool _FBBNPFFEJBN_Force, IMCBBOAFION _GIMKOLPGIAO_OnSuccess, IMCBBOAFION _MBIKIBHLAGE_OnError)
	{
		NADBPLMLIJA_GetToken PNLGHFCFPPK_Request;
		
		//0x16CA7E4
		GameManager.Instance.InputEnabled = false;
		PNLGHFCFPPK_Request = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NADBPLMLIJA_GetToken());
		PNLGHFCFPPK_Request.ALJHFFCKBDP = true;
		yield return PNLGHFCFPPK_Request.GDPDELLNOBO_WaitDone(N.a);
		GameManager.Instance.InputEnabled = true;
		bool error = PNLGHFCFPPK_Request.NPNNPNAIONN_IsError;
		PNLGHFCFPPK_Request = null;
		if(error)
		{
			_MBIKIBHLAGE_OnError();
		}
		else
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			DateTime date = Utility.GetLocalDateTime(time);
			if(!_FBBNPFFEJBN_Force)
			{
				if(HIJBIPLMNEA == date.Month * 100 + date.Year * 100000 + date.Day)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.KJJLCKFLIML_ShowDteLineErrorPopup(_MBIKIBHLAGE_OnError);
					yield break;
				}
			}
			NKGJPJPHLIF.HHCJCDFCLOB.EFPOACOOAFB(_FBBNPFFEJBN_Force);
			_GIMKOLPGIAO_OnSuccess();
		}
	}

	// // RVA: 0x16CA300 Offset: 0x16CA300 VA: 0x16CA300
	public static bool MNANNMDBHMP(IMCBBOAFION _GIMKOLPGIAO_OnSuccess, IMCBBOAFION _MBIKIBHLAGE_OnError)
	{
		if(!LANLFCFBOHI)
		{
			IMOIPBMGIPN EALOBDHOCHP_stat = AIMFCMCMOIH();
			switch(EALOBDHOCHP_stat)
			{
				case IMOIPBMGIPN.MGEFLLPGDDN:
				case IMOIPBMGIPN.CKOMFNPGHOM:
					NKGJPJPHLIF.HHCJCDFCLOB.NIJDPPHGHFD_ResetDates(EALOBDHOCHP_stat == IMOIPBMGIPN.CKOMFNPGHOM/*3*/);
					JHHBAFKMBDL.HHCJCDFCLOB.CIKMDHMMCIL_ShowErrorPopup(2, _MBIKIBHLAGE_OnError);
					LANLFCFBOHI = true;
					return true;
				case IMOIPBMGIPN.OGFOHBGEAEC:
				case IMOIPBMGIPN.PJPJEHEFMMJ:
					JHHBAFKMBDL.HHCJCDFCLOB.PNIJEKOHEII(() =>
					{
						//0x16CA6C8
						HIJBIPLMNEA = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
						N.a.StartCoroutineWatched(OOILBGOKHDC_Co_ReGetSeverTime(EALOBDHOCHP_stat == IMOIPBMGIPN.CKOMFNPGHOM, _GIMKOLPGIAO_OnSuccess, _MBIKIBHLAGE_OnError));
					});
					LANLFCFBOHI = true;
					return true;
			}
		}
		return false;
	}
}
