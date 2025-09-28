using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using XeApp.Game;

public class NMFABEKNBKJ
{
    public class CIDEHGHGPIO
    {
        public string JCOGNKFNDEB_token; // 0x8
        public long BIOGKIEECGN_created_at; // 0x10
        public long IFNLEKOILPM_updated_at; // 0x18
    }

    private enum LOICDBFAAJL
    {
        LNIKPHOMKHD = 0,
        AJDFIOCMNNG = 1,
        IHILJFJHIFN = 2,
        HCJOLEAHBCH = 3,
        HNHKFENEHOO = 4,
        KHDDAFOMDAO = 5,
        CBNMOLGJDJK = 6,
        IHOJFLFBJMF = 7,
        HFBDPCPAEOI = 8,
        OPDBHPKINCF = 9,
    }

	private const int HEAHMMNHIBN = 1;
	private const float FADOJDCEMEP = 4;
	private const float JAOKLGDHBLC = 4;
	private const int LHHNAPNICPD = 345600;
	public bool OAKCAEHGPFA; // 0x8
	private int EAABKFGHKBG_TryCount; // 0x14
	private List<NMFABEKNBKJ.CIDEHGHGPIO> NDPMMJINHNA_TokenList = new List<NMFABEKNBKJ.CIDEHGHGPIO>(); // 0x18

	public static NMFABEKNBKJ HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public int HBAFMHEBNDP { get; private set; } // 0xC DJEKENHJEOE DAJMGNFAEEG PPFBDNBNDDB
	public bool PLOOEECNHFB_IsDone { get; private set; } // 0x10 MGFBAEDOIDD JFOKBBLFMLD EDBGNGILAKA
	public bool ECCHBMAGKLF { get; private set; } // 0x11 EGAIOJDAHFM ODAMFOMFIPC ELGNDAPOEPK

	// // RVA: 0x1CAB7E0 Offset: 0x1CAB7E0 VA: 0x1CAB7E0
	// private void FCPBCDOKOPD(NMFABEKNBKJ.LOICDBFAAJL _PPFNGGCBJKC_id, string _IPBHCLIHAPG_Msg = "") { }

	// // RVA: 0x1CAB7E4 Offset: 0x1CAB7E4 VA: 0x1CAB7E4
	public void IJBGPAENLJA_OnAwake(MonoBehaviour _DANMJLOBLIE_mb)
    {
		HHCJCDFCLOB = this;
		HBAFMHEBNDP = -1;
		PLOOEECNHFB_IsDone = false;
		ECCHBMAGKLF = false;
    }

	// // RVA: 0x1CAB858 Offset: 0x1CAB858 VA: 0x1CAB858
	public void OJKIKODJJCD(IMCBBOAFION PONEMLJPAOE, IMCBBOAFION _CNJANCCFBIL_Cb)
    {
		N.a.StartCoroutineWatched(LAGOJPPLDOH_Corotuine_BootInitilaize_FCM(PONEMLJPAOE, _CNJANCCFBIL_Cb));
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BA83C Offset: 0x6BA83C VA: 0x6BA83C
	// // RVA: 0x1CAB8B8 Offset: 0x1CAB8B8 VA: 0x1CAB8B8
	private IEnumerator LAGOJPPLDOH_Corotuine_BootInitilaize_FCM(IMCBBOAFION PONEMLJPAOE, IMCBBOAFION _CNJANCCFBIL_Cb)
	{
		//0x1CADBC8
		MABFNKCMEDL_CreateNotification("energy", JpStringLiterals.StringLiteral_12692, 3);
		MABFNKCMEDL_CreateNotification("info", JpStringLiterals.StringLiteral_12693, 3);
		MABFNKCMEDL_CreateNotification("sns", JpStringLiterals.StringLiteral_10294, 3);
		MABFNKCMEDL_CreateNotification("vop", "VOP", 3);
		MABFNKCMEDL_CreateNotification(EAPDJLPDHEJ.JIMJHIDEHNM_ApCounter, JpStringLiterals.StringLiteral_10282, 3);
		MABFNKCMEDL_CreateNotification(EAPDJLPDHEJ.BGCAPDNMPOK_Deco, JpStringLiterals.StringLiteral_12695, 3);
		MABFNKCMEDL_CreateNotification(EAPDJLPDHEJ.BCFFEECIMJG_LimitedItem, JpStringLiterals.StringLiteral_12696, 3);
		while(!FCMTokenReceiver.isDpendencyChecked)
		{
			yield return null;
		}
		float FBFKMOECEIM = 0;
		while (string.IsNullOrEmpty(FCMTokenReceiver.fcmToken) && FBFKMOECEIM < 3)
		{
			FBFKMOECEIM += Time.deltaTime;
			yield return null;
		}
		bool KOMKKBDABJP_end = false;
		yield return N.a.StartCoroutineWatched(KGGHPICPOAA_Corotuine_GetFCMTokens(() =>
		{
			//0x1CACDE8
			KOMKKBDABJP_end = true;
		}));
		while(!KOMKKBDABJP_end)
		{
			yield return null;
		}
		if(!string.IsNullOrEmpty(FCMTokenReceiver.fcmToken))
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.ILNIHDCCOEO_EventReceive == 0)
			{
				N.a.StartCoroutineWatched(LODINIOCACA_Corotuine_Block_FCM(() =>
				{
					//0x1CACD2C
					return;
				}));
			}
			else
			{
				N.a.StartCoroutineWatched(PELPMECLNNB_Corotuine_Accept_FCM(() => 
				{
					//0x1CACD28
					return;
				}));
			}
		}
		PLOOEECNHFB_IsDone = true;
		if (PONEMLJPAOE != null)
			PONEMLJPAOE();
		if (_CNJANCCFBIL_Cb != null)
			_CNJANCCFBIL_Cb();
	}

	// // RVA: 0x1CAB998 Offset: 0x1CAB998 VA: 0x1CAB998
	public void FCDDHHKAGEP_Request(IMCBBOAFION _CNJANCCFBIL_Cb)
	{
		N.a.StartCoroutineWatched(KGGHPICPOAA_Corotuine_GetFCMTokens(() =>
		{
			//0x1CACDF4
			N.a.StartCoroutineWatched(PELPMECLNNB_Corotuine_Accept_FCM(_CNJANCCFBIL_Cb));
		}));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BA8B4 Offset: 0x6BA8B4 VA: 0x6BA8B4
	// // RVA: 0x1CABB58 Offset: 0x1CABB58 VA: 0x1CABB58
	private IEnumerator PELPMECLNNB_Corotuine_Accept_FCM(IMCBBOAFION _CNJANCCFBIL_Cb)
	{
		//0x1CAD29C
		if(!string.IsNullOrEmpty(FCMTokenReceiver.fcmToken))
		{
			int idx = NDPMMJINHNA_TokenList.FindIndex((CIDEHGHGPIO _GHPLINIACBB_x) =>
			{
				//0x1CACD30
				return _GHPLINIACBB_x.JCOGNKFNDEB_token == FCMTokenReceiver.fcmToken;
			});
			if(idx > 0)
			{
				bool BEKAMBBOLBO_Done = false;
				int ONBPFIMAAEJ_i = 0;
				for(; ONBPFIMAAEJ_i < 2; ONBPFIMAAEJ_i++)
				{
					BEKAMBBOLBO_Done = false;
					SakashoError MIIDBEIOBNK_Error = null;
					SakashoSystemCallback.OnSuccess BAHANNNJCGC = (string _IDLHJIOMJBK_data) =>
					{
						//0x1CACE60
						BEKAMBBOLBO_Done = true;
					};
					SakashoAPICallContext OIDFKCIECJN = SakashoFCMPushNotification.AcceptPushNotification(FCMTokenReceiver.fcmToken, BAHANNNJCGC, (SakashoError _DOGDHKIEBJA_error) =>
					{
						//0x1CACED0
						//DOGDHKIEBJA_error.ResponseBodyJSON;
						MIIDBEIOBNK_Error = _DOGDHKIEBJA_error;
						BEKAMBBOLBO_Done = true;
					});
					float CPOFOJKLNGH = 0;
					while(!BEKAMBBOLBO_Done)
					{
						yield return null;
						CPOFOJKLNGH += Time.deltaTime;
						if (CPOFOJKLNGH > 5)
						{
							OIDFKCIECJN.CancelAPICall();
							break;
						}
					}
					if (MIIDBEIOBNK_Error == null)
						break;
					OIDFKCIECJN = null;
				}
			}
		}
		_CNJANCCFBIL_Cb();
	}

	// // RVA: 0x1CABC20 Offset: 0x1CABC20 VA: 0x1CABC20
	public void MDJNLBOLPNJ_BlockFCM(IMCBBOAFION _CNJANCCFBIL_Cb)
	{
		N.a.StartCoroutineWatched(KGGHPICPOAA_Corotuine_GetFCMTokens(() =>
		{
			//0x1CACF48
			N.a.StartCoroutineWatched(LODINIOCACA_Corotuine_Block_FCM(_CNJANCCFBIL_Cb));
		}));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BA92C Offset: 0x6BA92C VA: 0x6BA92C
	// // RVA: 0x1CABD38 Offset: 0x1CABD38 VA: 0x1CABD38
	private IEnumerator LODINIOCACA_Corotuine_Block_FCM(IMCBBOAFION _CNJANCCFBIL_Cb)
	{
		//0x1CAD8A4
		yield return null;

		for (int i = 0; i < NDPMMJINHNA_TokenList.Count; i++)
		{
			bool BEKAMBBOLBO_Done = false;
			SakashoFCMPushNotification.BlockPushNotification(NDPMMJINHNA_TokenList[i].JCOGNKFNDEB_token, (string _IDLHJIOMJBK_data) =>
			{
				//0x1CACFB4
				BEKAMBBOLBO_Done = true;
			}, (SakashoError FMEMECBIDIB) =>
			{
				//0x1CACFC0
				BEKAMBBOLBO_Done = true;
			});
			while(!BEKAMBBOLBO_Done)
			{
				yield return null;
			}
		}
		_CNJANCCFBIL_Cb();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BA9A4 Offset: 0x6BA9A4 VA: 0x6BA9A4
	// // RVA: 0x1CABAB0 Offset: 0x1CABAB0 VA: 0x1CABAB0
	private IEnumerator KGGHPICPOAA_Corotuine_GetFCMTokens(IMCBBOAFION _CNJANCCFBIL_Cb)
	{
		//0x1CAE4BC
		for (int ONBPFIMAAEJ_i = 0; ONBPFIMAAEJ_i < 2; ONBPFIMAAEJ_i++)
		{
			NDPMMJINHNA_TokenList.Clear();
			SakashoError MIIDBEIOBNK_Error = null;
			float KPCGLMELHFG_time = 0;
			bool BEKAMBBOLBO_Done = false;
			SakashoAPICallContext IBLABDHABAJ = SakashoFCMPushNotification.GetFCMTokens((string _IDLHJIOMJBK_data) =>
			{
				//0x1CACFD4
				BEKAMBBOLBO_Done = true;
				EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(_IDLHJIOMJBK_data);
				EDOHBJAPLPF_JsonData block = data["fcm_tokens"];
				for(int i = 0; i < block.HNBFOAJIIAL_Count; i++)
				{
					CIDEHGHGPIO res = new CIDEHGHGPIO();
					res.JCOGNKFNDEB_token = CEDHHAGBIBA.BNCLNFJHEND_ReadString(block[i], "fcm_token");
					res.BIOGKIEECGN_created_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(block[i], "created_at");
					res.IFNLEKOILPM_updated_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(block[i], "updated_at");
					NDPMMJINHNA_TokenList.Add(res);
				}
			}, (SakashoError _CNAIDEAFAAM_Error) =>
			{
				//0x1CAD288
				MIIDBEIOBNK_Error = _CNAIDEAFAAM_Error;
				BEKAMBBOLBO_Done = true;
			});
			bool NHGLNPMINJG_Canceled = false;
			while (!BEKAMBBOLBO_Done)
			{
				yield return null;
				KPCGLMELHFG_time += Time.deltaTime;
				if (KPCGLMELHFG_time > 4)
				{
					if (!IBLABDHABAJ.IsCancellable())
						break;
					IBLABDHABAJ.CancelAPICall();
					NHGLNPMINJG_Canceled = true;
					break;
				}
			}
			if (NHGLNPMINJG_Canceled)
				break;
			if (MIIDBEIOBNK_Error == null)
				break;
			IBLABDHABAJ = null;
		}
		_CNJANCCFBIL_Cb();
	}

	// // RVA: 0x1CABE20 Offset: 0x1CABE20 VA: 0x1CABE20
	public void FGDBKOCCKOE(bool CKLGHFBPFPJ)
	{
		return;
	}

	// // RVA: 0x1CABE24 Offset: 0x1CABE24 VA: 0x1CABE24
	// private void IJLKOHNHIFO() { }

	// // RVA: 0x1CABE28 Offset: 0x1CABE28 VA: 0x1CABE28
	private void MABFNKCMEDL_CreateNotification(string _PPFNGGCBJKC_id, string _OPFGFINHFCE_name, int PDJFAPLAPAG/* = 3*/)
	{
		#if UNITY_ANDROID
		AndroidJavaClass c = new AndroidJavaClass("android.os.Build$VERSION");
		int sdk = c.GetStatic<int>("SDK_INT");
		c.Dispose();
		if(sdk > 25)
		{
			UnityEngine.Debug.LogError("Create notif channel " + _PPFNGGCBJKC_id + " " + _OPFGFINHFCE_name);
			AndroidJavaObject notif = new AndroidJavaObject("android.app.NotificationChannel", new object[3] { _PPFNGGCBJKC_id, _OPFGFINHFCE_name, PDJFAPLAPAG });
			AndroidJavaClass cl = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject activity = cl.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaObject systemService = activity.Call<AndroidJavaObject>("getSystemService", new object[1] { "notification" });
			systemService.Call("createNotificationChannel", new object[1] { notif });
			systemService.Dispose();
			activity.Dispose();
			cl.Dispose();
			notif.Dispose();
		}
		#endif
	}

	// // RVA: 0x1CAC854 Offset: 0x1CAC854 VA: 0x1CAC854
	// public static bool KNHFMCOIIGI() { }

	// // RVA: 0x1CAC8C0 Offset: 0x1CAC8C0 VA: 0x1CAC8C0
	// public static void NIGGIFGABHK() { }

	// // RVA: 0x1CAC92C Offset: 0x1CAC92C VA: 0x1CAC92C
	// public static void FINHCPLBHPC() { }

	// // RVA: 0x1CAC998 Offset: 0x1CAC998 VA: 0x1CAC998
	// private string MHBCOCDNHJI() { }

	// // RVA: 0x1CACA08 Offset: 0x1CACA08 VA: 0x1CACA08
	// private void MDGAOFGMNDE() { }

	// // RVA: 0x1CACAA8 Offset: 0x1CACAA8 VA: 0x1CACAA8
	// private long BNPJMJHAGGB() { }

	// // RVA: 0x1CACB5C Offset: 0x1CACB5C VA: 0x1CACB5C
	// private void PPHJLDPNKFO() { }
}
