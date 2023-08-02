using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using XeApp.Game;

public class NMFABEKNBKJ
{
    public class CIDEHGHGPIO
    {
        public string JCOGNKFNDEB_Token; // 0x8
        public long BIOGKIEECGN_CreatedAt; // 0x10
        public long IFNLEKOILPM_UpdatedAt; // 0x18
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
	private int EAABKFGHKBG; // 0x14
	private List<NMFABEKNBKJ.CIDEHGHGPIO> NDPMMJINHNA_TokenList = new List<NMFABEKNBKJ.CIDEHGHGPIO>(); // 0x18

	public static NMFABEKNBKJ HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public int HBAFMHEBNDP { get; private set; } // 0xC DJEKENHJEOE DAJMGNFAEEG PPFBDNBNDDB
	public bool PLOOEECNHFB { get; private set; } // 0x10 MGFBAEDOIDD JFOKBBLFMLD EDBGNGILAKA
	public bool ECCHBMAGKLF { get; private set; } // 0x11 EGAIOJDAHFM ODAMFOMFIPC ELGNDAPOEPK

	// // RVA: 0x1CAB7E0 Offset: 0x1CAB7E0 VA: 0x1CAB7E0
	// private void FCPBCDOKOPD(NMFABEKNBKJ.LOICDBFAAJL PPFNGGCBJKC, string IPBHCLIHAPG = "") { }

	// // RVA: 0x1CAB7E4 Offset: 0x1CAB7E4 VA: 0x1CAB7E4
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
    {
		HHCJCDFCLOB = this;
		HBAFMHEBNDP = -1;
		PLOOEECNHFB = false;
		ECCHBMAGKLF = false;
    }

	// // RVA: 0x1CAB858 Offset: 0x1CAB858 VA: 0x1CAB858
	public void OJKIKODJJCD(IMCBBOAFION PONEMLJPAOE, IMCBBOAFION CNJANCCFBIL)
    {
		N.a.StartCoroutineWatched(LAGOJPPLDOH_Corotuine_BootInitilaize_FCM(PONEMLJPAOE, CNJANCCFBIL));
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BA83C Offset: 0x6BA83C VA: 0x6BA83C
	// // RVA: 0x1CAB8B8 Offset: 0x1CAB8B8 VA: 0x1CAB8B8
	private IEnumerator LAGOJPPLDOH_Corotuine_BootInitilaize_FCM(IMCBBOAFION PONEMLJPAOE, IMCBBOAFION CNJANCCFBIL)
	{
		//0x1CADBC8
		MABFNKCMEDL_CreateNotification("energy", JpStringLiterals.StringLiteral_12692, 3);
		MABFNKCMEDL_CreateNotification("info", JpStringLiterals.StringLiteral_12693, 3);
		MABFNKCMEDL_CreateNotification("sns", JpStringLiterals.StringLiteral_10294, 3);
		MABFNKCMEDL_CreateNotification("vop", "VOP", 3);
		MABFNKCMEDL_CreateNotification(EAPDJLPDHEJ.JIMJHIDEHNM, JpStringLiterals.StringLiteral_10282, 3);
		MABFNKCMEDL_CreateNotification(EAPDJLPDHEJ.BGCAPDNMPOK, JpStringLiterals.StringLiteral_12695, 3);
		MABFNKCMEDL_CreateNotification(EAPDJLPDHEJ.BCFFEECIMJG, JpStringLiterals.StringLiteral_12696, 3);
		while(!FCMTokenReceiver.isDpendencyChecked)
		{
			yield return null;
		}
		float FBFKMOECEIM = 0;
		if (string.IsNullOrEmpty(FCMTokenReceiver.fcmToken) && FBFKMOECEIM < 3)
		{
			FBFKMOECEIM += Time.deltaTime;
			yield return null;
		}
		bool KOMKKBDABJP = false;
		yield return N.a.StartCoroutineWatched(KGGHPICPOAA_Corotuine_GetFCMTokens(() =>
		{
			//0x1CACDE8
			KOMKKBDABJP = true;
		}));
		while(!KOMKKBDABJP)
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
		PLOOEECNHFB = true;
		if (PONEMLJPAOE != null)
			PONEMLJPAOE();
		if (CNJANCCFBIL != null)
			CNJANCCFBIL();
	}

	// // RVA: 0x1CAB998 Offset: 0x1CAB998 VA: 0x1CAB998
	public void FCDDHHKAGEP_AcceptFCM(IMCBBOAFION CNJANCCFBIL)
	{
		N.a.StartCoroutineWatched(KGGHPICPOAA_Corotuine_GetFCMTokens(() =>
		{
			//0x1CACDF4
			N.a.StartCoroutineWatched(PELPMECLNNB_Corotuine_Accept_FCM(CNJANCCFBIL));
		}));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BA8B4 Offset: 0x6BA8B4 VA: 0x6BA8B4
	// // RVA: 0x1CABB58 Offset: 0x1CABB58 VA: 0x1CABB58
	private IEnumerator PELPMECLNNB_Corotuine_Accept_FCM(IMCBBOAFION CNJANCCFBIL)
	{
		//0x1CAD29C
		if(!string.IsNullOrEmpty(FCMTokenReceiver.fcmToken))
		{
			int idx = NDPMMJINHNA_TokenList.FindIndex((CIDEHGHGPIO GHPLINIACBB) =>
			{
				//0x1CACD30
				return GHPLINIACBB.JCOGNKFNDEB_Token == FCMTokenReceiver.fcmToken;
			});
			if(idx > 0)
			{
				bool BEKAMBBOLBO = false;
				int ONBPFIMAAEJ = 0;
				for(; ONBPFIMAAEJ < 2; ONBPFIMAAEJ++)
				{
					BEKAMBBOLBO = false;
					SakashoError MIIDBEIOBNK = null;
					SakashoSystemCallback.OnSuccess BAHANNNJCGC = (string IDLHJIOMJBK) =>
					{
						//0x1CACE60
						BEKAMBBOLBO = true;
					};
					SakashoAPICallContext OIDFKCIECJN = SakashoFCMPushNotification.AcceptPushNotification(FCMTokenReceiver.fcmToken, BAHANNNJCGC, (SakashoError DOGDHKIEBJA) =>
					{
						//0x1CACED0
						//DOGDHKIEBJA.ResponseBodyJSON;
						MIIDBEIOBNK = DOGDHKIEBJA;
						BEKAMBBOLBO = true;
					});
					float CPOFOJKLNGH = 0;
					while(!BEKAMBBOLBO)
					{
						yield return null;
						CPOFOJKLNGH += Time.deltaTime;
						if (CPOFOJKLNGH > 5)
						{
							OIDFKCIECJN.CancelAPICall();
							break;
						}
					}
					if (MIIDBEIOBNK == null)
						break;
					OIDFKCIECJN = null;
				}
			}
		}
		CNJANCCFBIL();
	}

	// // RVA: 0x1CABC20 Offset: 0x1CABC20 VA: 0x1CABC20
	public void MDJNLBOLPNJ_BlockFCM(IMCBBOAFION CNJANCCFBIL)
	{
		N.a.StartCoroutineWatched(KGGHPICPOAA_Corotuine_GetFCMTokens(() =>
		{
			//0x1CACF48
			N.a.StartCoroutineWatched(LODINIOCACA_Corotuine_Block_FCM(CNJANCCFBIL));
		}));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BA92C Offset: 0x6BA92C VA: 0x6BA92C
	// // RVA: 0x1CABD38 Offset: 0x1CABD38 VA: 0x1CABD38
	private IEnumerator LODINIOCACA_Corotuine_Block_FCM(IMCBBOAFION CNJANCCFBIL)
	{
		//0x1CAD8A4
		yield return null;

		for (int i = 0; i < NDPMMJINHNA_TokenList.Count; i++)
		{
			bool BEKAMBBOLBO = false;
			SakashoFCMPushNotification.BlockPushNotification(NDPMMJINHNA_TokenList[i].JCOGNKFNDEB_Token, (string IDLHJIOMJBK) =>
			{
				//0x1CACFB4
				BEKAMBBOLBO = true;
			}, (SakashoError FMEMECBIDIB) =>
			{
				//0x1CACFC0
				BEKAMBBOLBO = true;
			});
			while(!BEKAMBBOLBO)
			{
				yield return null;
			}
		}
		CNJANCCFBIL();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BA9A4 Offset: 0x6BA9A4 VA: 0x6BA9A4
	// // RVA: 0x1CABAB0 Offset: 0x1CABAB0 VA: 0x1CABAB0
	private IEnumerator KGGHPICPOAA_Corotuine_GetFCMTokens(IMCBBOAFION CNJANCCFBIL)
	{
		//0x1CAE4BC
		for (int ONBPFIMAAEJ = 0; ONBPFIMAAEJ < 2; ONBPFIMAAEJ++)
		{
			NDPMMJINHNA_TokenList.Clear();
			SakashoError MIIDBEIOBNK_Error = null;
			float KPCGLMELHFG_time = 0;
			bool BEKAMBBOLBO_Done = false;
			SakashoAPICallContext IBLABDHABAJ = SakashoFCMPushNotification.GetFCMTokens((string IDLHJIOMJBK) =>
			{
				//0x1CACFD4
				BEKAMBBOLBO_Done = true;
				EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(IDLHJIOMJBK);
				EDOHBJAPLPF_JsonData block = data["fcm_tokens"];
				for(int i = 0; i < block.HNBFOAJIIAL_Count; i++)
				{
					CIDEHGHGPIO res = new CIDEHGHGPIO();
					res.JCOGNKFNDEB_Token = CEDHHAGBIBA.BNCLNFJHEND_ReadString(block[i], "fcm_token");
					res.BIOGKIEECGN_CreatedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(block[i], "created_at");
					res.IFNLEKOILPM_UpdatedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(block[i], "updated_at");
					NDPMMJINHNA_TokenList.Add(res);
				}
			}, (SakashoError CNAIDEAFAAM) =>
			{
				//0x1CAD288
				MIIDBEIOBNK_Error = CNAIDEAFAAM;
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
		CNJANCCFBIL();
	}

	// // RVA: 0x1CABE20 Offset: 0x1CABE20 VA: 0x1CABE20
	// public void FGDBKOCCKOE(bool CKLGHFBPFPJ) { }

	// // RVA: 0x1CABE24 Offset: 0x1CABE24 VA: 0x1CABE24
	// private void IJLKOHNHIFO() { }

	// // RVA: 0x1CABE28 Offset: 0x1CABE28 VA: 0x1CABE28
	private void MABFNKCMEDL_CreateNotification(string PPFNGGCBJKC, string OPFGFINHFCE, int PDJFAPLAPAG = 3)
	{
		#if UNITY_ANDROID
		TodoLogger.Log(TodoLogger.AndroidNotification, "NMFABEKNBKJ.createNotificationChannel");
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
