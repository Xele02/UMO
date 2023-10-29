
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPKDHAODJOA
{
	public delegate void NNDKLLAIINK();

	public enum KJOKAECJKLE
	{
		NFFGMBBNNPH_0 = 0,
		HIHKPNBDNJC_1 = 1,
		OGBMKAILHMF = 2,
	}

	private List<CACGCMBKHDI_Request> FCICFIAOLAM = new List<CACGCMBKHDI_Request>(); // 0x8
	private NNDKLLAIINK LCIGLIDJILJ_Updater; // 0xC
	private int NLGJBBGAOLH = 1; // 0x10
	private int BLKIMNAILKK = 2; // 0x14
	private int NNODMPKKCJH; // 0x18

	public KJOKAECJKLE CMCKNKKCNDK { get; private set; } // 0x1C CLCJNFNMNBH CNKGOPKANGF CHJGGLFGALP

	//// RVA: -1 Offset: -1
	public T IFFNCAFNEAG_AddRequest<T>(T ADKIDBJCAJA) where T : CACGCMBKHDI_Request
	{
		ADKIDBJCAJA.BNJPAKLNOPA_WorkerThreadQueue = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.BNJPAKLNOPA_WorkerThreadQueue;
		ADKIDBJCAJA.PLOOEECNHFB_IsDone = false;
		ADKIDBJCAJA.KINJOEIAHFK_StartTime = Time.realtimeSinceStartup;
		ADKIDBJCAJA.DMOBOIOFPCM_EndTime = Time.realtimeSinceStartup;
		ADKIDBJCAJA.LHGPAJGIAME_ResultTime = Time.realtimeSinceStartup;
		ADKIDBJCAJA.CFICLNJACCD_NumRetry = NLGJBBGAOLH;
		ADKIDBJCAJA.GJAEJFLLKGC_RetryTime = BLKIMNAILKK;
		ADKIDBJCAJA.CKOOCBJGHBI_RequestId = NNODMPKKCJH;
		NNODMPKKCJH++;
		FCICFIAOLAM.Add(ADKIDBJCAJA);
		return ADKIDBJCAJA;
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x1AB6384 Offset: 0x1AB6384 VA: 0x1AB6384
	//|-OPKDHAODJOA.IFFNCAFNEAG<MMCLJMPEFEP>
	//|-OPKDHAODJOA.IFFNCAFNEAG<NFIMGIABIOI>
	//|-OPKDHAODJOA.IFFNCAFNEAG<object>
	//*/

	//// RVA: 0xCB7550 Offset: 0xCB7550 VA: 0xCB7550
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		CMCKNKKCNDK = KJOKAECJKLE.NFFGMBBNNPH_0;
		LCIGLIDJILJ_Updater = LFKLIOKFGLP;
		FCICFIAOLAM.Clear();
	}

	//// RVA: 0xCB761C Offset: 0xCB761C VA: 0xCB761C
	public void BAGMHFKPFIF()
	{
		LCIGLIDJILJ_Updater();
	}

	//// RVA: 0xCB7A80 Offset: 0xCB7A80 VA: 0xCB7A80
	private void LFKLIOKFGLP()
	{
		if (FCICFIAOLAM.Count < 1)
			return;
		CMCKNKKCNDK = KJOKAECJKLE.HIHKPNBDNJC_1;
		N.a.StartCoroutineWatched(NBCKHIAINIM_Coroutine_Execute(FCICFIAOLAM[0]));
		LCIGLIDJILJ_Updater = JADLLIFCGLG;
	}

	//// RVA: 0xCB7C54 Offset: 0xCB7C54 VA: 0xCB7C54
	private void JADLLIFCGLG()
	{
		if(FCICFIAOLAM.Count != 0)
		{
			if (!FCICFIAOLAM[0].PLOOEECNHFB_IsDone)
				return;
			if (FCICFIAOLAM.Count > 0)
				FCICFIAOLAM.RemoveAt(0);
			if (FCICFIAOLAM.Count > 0)
			{
				N.a.StartCoroutineWatched(NBCKHIAINIM_Coroutine_Execute(FCICFIAOLAM[0]));
				LCIGLIDJILJ_Updater = JADLLIFCGLG;
				return;
			}
		}
		CMCKNKKCNDK = KJOKAECJKLE.NFFGMBBNNPH_0;
		LCIGLIDJILJ_Updater = LFKLIOKFGLP;
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6C3A48 Offset: 0x6C3A48 VA: 0x6C3A48
	//// RVA: 0xCB7BAC Offset: 0xCB7BAC VA: 0xCB7BAC
	private IEnumerator NBCKHIAINIM_Coroutine_Execute(CACGCMBKHDI_Request ADKIDBJCAJA)
	{
		int AMDHPNLCJAH; // 0x18
		int MAFCEPHNGMP; // 0x1C
		bool FDMJDEHOMNI_IsError; // 0x20
		bool PKCGNDNMLKE; // 0x21
		float GKLKLNCOOAB; // 0x24
		SakashoAPICallContext HGFOIBHOFJL; // 0x28

		//0xCB8060
		yield return null;
		AMDHPNLCJAH = 0;
		MAFCEPHNGMP = 0;
		ADKIDBJCAJA.OGPFKGAKOFD();
		GKLKLNCOOAB = 0;
		PKCGNDNMLKE = false;
		HGFOIBHOFJL = ADKIDBJCAJA.EBGACDGNCAA_CallContext;
		while (true)
		{
			while (!ADKIDBJCAJA.EFGFPCBGDDK)
			{
				GKLKLNCOOAB += Time.deltaTime;
				if (ADKIDBJCAJA.ICDEFIIADDO_Timeout <= GKLKLNCOOAB && HGFOIBHOFJL != null)
				{
					if (HGFOIBHOFJL.CancelAPICall())
						PKCGNDNMLKE = true;
					break;
				}
				yield return null;
			}
			//LAB_00cb81fc
			HGFOIBHOFJL = null;
			ADKIDBJCAJA.CJMFJOMECKI_ErrorId = SakashoErrorId.UNKNOWN;
			FDMJDEHOMNI_IsError = false;
			if (ADKIDBJCAJA.ANMFDAGDMDE != null)
			{
				ADKIDBJCAJA.CJMFJOMECKI_ErrorId = ADKIDBJCAJA.ANMFDAGDMDE.getErrorId();
				FDMJDEHOMNI_IsError = true;
			}
			ADKIDBJCAJA.NPNNPNAIONN_IsError = FDMJDEHOMNI_IsError;
			if (!PKCGNDNMLKE)
			{
				if (!FDMJDEHOMNI_IsError)
				{
					ADKIDBJCAJA.DMOBOIOFPCM_EndTime = Time.realtimeSinceStartup;
					ADKIDBJCAJA.MGFNKDPHFGI(N.a);
					while (!ADKIDBJCAJA.EBPLLJGPFDA_HasResult)
						yield return null;
					ADKIDBJCAJA.NLDKLFODOJJ();
					ADKIDBJCAJA.LHGPAJGIAME_ResultTime = Time.realtimeSinceStartup;
				}
				else
				{
					if (EHLBPCGHLCL_CanRetry(ADKIDBJCAJA, ADKIDBJCAJA.CJMFJOMECKI_ErrorId, true))
					{
						AMDHPNLCJAH++;
						MAFCEPHNGMP++;
						if (AMDHPNLCJAH < ADKIDBJCAJA.CFICLNJACCD_NumRetry)
						{
							yield return new WaitForSeconds(ADKIDBJCAJA.GJAEJFLLKGC_RetryTime);
							ADKIDBJCAJA.OGPFKGAKOFD();
							GKLKLNCOOAB = 0;
							HGFOIBHOFJL = ADKIDBJCAJA.EBGACDGNCAA_CallContext;
							continue;
						}
					}
				}
			}
			else
			{
				ADKIDBJCAJA.NPNNPNAIONN_IsError = true;
				ADKIDBJCAJA.PDAPLCPOCMA = true;
				FDMJDEHOMNI_IsError = true;
			}
			ADKIDBJCAJA.PLOOEECNHFB_IsDone = true;
			if (!FDMJDEHOMNI_IsError)
			{
				if (ADKIDBJCAJA.BHFHGFKBOHH_OnSuccess != null)
					ADKIDBJCAJA.BHFHGFKBOHH_OnSuccess(ADKIDBJCAJA);
			}
			else
			{
				if (ADKIDBJCAJA.MOBEEPPKFLG_OnFail != null)
					ADKIDBJCAJA.MOBEEPPKFLG_OnFail(ADKIDBJCAJA);
			}
			break;
		}
	}

	//// RVA: 0xCB7EB4 Offset: 0xCB7EB4 VA: 0xCB7EB4
	private bool EHLBPCGHLCL_CanRetry(CACGCMBKHDI_Request ADKIDBJCAJA, SakashoErrorId KLCMLLLIANB, bool OHPAOJNLDJO)
	{
		if(!ADKIDBJCAJA.BNCFONNOHFO)
		{
			GOBDOEHKLHN a = JGJFFKPFMDB.BDPBNKPKAJJ(KLCMLLLIANB);
			if (a != GOBDOEHKLHN.KLPAIDGGGCN_5 && (a != GOBDOEHKLHN.FJGMPDJFELN_4 || !ADKIDBJCAJA.OIDCBBGLPHL))
			{
				return KLCMLLLIANB == SakashoErrorId.NETWORK_ERROR && !OHPAOJNLDJO;
			}
			return true;
		}
		return false;
	}
}
