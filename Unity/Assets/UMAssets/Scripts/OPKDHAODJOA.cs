
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

	private List<CACGCMBKHDI_Request> FCICFIAOLAM_RequestList = new List<CACGCMBKHDI_Request>(); // 0x8
	private NNDKLLAIINK LCIGLIDJILJ_Updater; // 0xC
	private int NLGJBBGAOLH = 1; // 0x10
	private int BLKIMNAILKK = 2; // 0x14
	private int NNODMPKKCJH_RequestId; // 0x18

	public KJOKAECJKLE CMCKNKKCNDK_Status { get; private set; } // 0x1C CLCJNFNMNBH CNKGOPKANGF CHJGGLFGALP

	//// RVA: -1 Offset: -1
	public T IFFNCAFNEAG_AddRequest<T>(T _ADKIDBJCAJA_action) where T : CACGCMBKHDI_Request
	{
		_ADKIDBJCAJA_action.BNJPAKLNOPA_WorkerThreadQueue = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.BNJPAKLNOPA_WorkerThreadQueue;
		_ADKIDBJCAJA_action.PLOOEECNHFB_IsDone = false;
		_ADKIDBJCAJA_action.KINJOEIAHFK_StartTime = Time.realtimeSinceStartup;
		_ADKIDBJCAJA_action.DMOBOIOFPCM_EndTime = Time.realtimeSinceStartup;
		_ADKIDBJCAJA_action.LHGPAJGIAME_ResultTime = Time.realtimeSinceStartup;
		_ADKIDBJCAJA_action.CFICLNJACCD_NumRetry = NLGJBBGAOLH;
		_ADKIDBJCAJA_action.GJAEJFLLKGC_RetryTime = BLKIMNAILKK;
		_ADKIDBJCAJA_action.CKOOCBJGHBI_RequestId = NNODMPKKCJH_RequestId;
		NNODMPKKCJH_RequestId++;
		FCICFIAOLAM_RequestList.Add(_ADKIDBJCAJA_action);
		return _ADKIDBJCAJA_action;
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x1AB6384 Offset: 0x1AB6384 VA: 0x1AB6384
	//|-OPKDHAODJOA.IFFNCAFNEAG<MMCLJMPEFEP>
	//|-OPKDHAODJOA.IFFNCAFNEAG<NFIMGIABIOI_GetBbsThreadComments>
	//|-OPKDHAODJOA.IFFNCAFNEAG<object>
	//*/

	//// RVA: 0xCB7550 Offset: 0xCB7550 VA: 0xCB7550
	public void IJBGPAENLJA(MonoBehaviour _DANMJLOBLIE_mb)
	{
		CMCKNKKCNDK_Status = KJOKAECJKLE.NFFGMBBNNPH_0;
		LCIGLIDJILJ_Updater = LFKLIOKFGLP;
		FCICFIAOLAM_RequestList.Clear();
	}

	//// RVA: 0xCB761C Offset: 0xCB761C VA: 0xCB761C
	public void BAGMHFKPFIF()
	{
		LCIGLIDJILJ_Updater();
	}

	//// RVA: 0xCB7A80 Offset: 0xCB7A80 VA: 0xCB7A80
	private void LFKLIOKFGLP()
	{
		if (FCICFIAOLAM_RequestList.Count < 1)
			return;
		CMCKNKKCNDK_Status = KJOKAECJKLE.HIHKPNBDNJC_1;
		N.a.StartCoroutineWatched(NBCKHIAINIM_Coroutine_Execute(FCICFIAOLAM_RequestList[0]));
		LCIGLIDJILJ_Updater = JADLLIFCGLG;
	}

	//// RVA: 0xCB7C54 Offset: 0xCB7C54 VA: 0xCB7C54
	private void JADLLIFCGLG()
	{
		if(FCICFIAOLAM_RequestList.Count != 0)
		{
			if (!FCICFIAOLAM_RequestList[0].PLOOEECNHFB_IsDone)
				return;
			if (FCICFIAOLAM_RequestList.Count > 0)
				FCICFIAOLAM_RequestList.RemoveAt(0);
			if (FCICFIAOLAM_RequestList.Count > 0)
			{
				N.a.StartCoroutineWatched(NBCKHIAINIM_Coroutine_Execute(FCICFIAOLAM_RequestList[0]));
				LCIGLIDJILJ_Updater = JADLLIFCGLG;
				return;
			}
		}
		CMCKNKKCNDK_Status = KJOKAECJKLE.NFFGMBBNNPH_0;
		LCIGLIDJILJ_Updater = LFKLIOKFGLP;
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6C3A48 Offset: 0x6C3A48 VA: 0x6C3A48
	//// RVA: 0xCB7BAC Offset: 0xCB7BAC VA: 0xCB7BAC
	private IEnumerator NBCKHIAINIM_Coroutine_Execute(CACGCMBKHDI_Request _ADKIDBJCAJA_action)
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
		_ADKIDBJCAJA_action.OGPFKGAKOFD();
		GKLKLNCOOAB = 0;
		PKCGNDNMLKE = false;
		HGFOIBHOFJL = _ADKIDBJCAJA_action.EBGACDGNCAA_CallContext;
		while (true)
		{
			while (!_ADKIDBJCAJA_action.EFGFPCBGDDK)
			{
				GKLKLNCOOAB += Time.deltaTime;
				if (_ADKIDBJCAJA_action.ICDEFIIADDO_Timeout <= GKLKLNCOOAB && HGFOIBHOFJL != null)
				{
					if (HGFOIBHOFJL.CancelAPICall())
						PKCGNDNMLKE = true;
					break;
				}
				yield return null;
			}
			//LAB_00cb81fc
			HGFOIBHOFJL = null;
			_ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId = SakashoErrorId.UNKNOWN;
			FDMJDEHOMNI_IsError = false;
			if (_ADKIDBJCAJA_action.ANMFDAGDMDE_Error != null)
			{
				_ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId = _ADKIDBJCAJA_action.ANMFDAGDMDE_Error.getErrorId();
				FDMJDEHOMNI_IsError = true;
			}
			_ADKIDBJCAJA_action.NPNNPNAIONN_IsError = FDMJDEHOMNI_IsError;
			if (!PKCGNDNMLKE)
			{
				if (!FDMJDEHOMNI_IsError)
				{
					_ADKIDBJCAJA_action.DMOBOIOFPCM_EndTime = Time.realtimeSinceStartup;
					_ADKIDBJCAJA_action.MGFNKDPHFGI(N.a);
					while (!_ADKIDBJCAJA_action.EBPLLJGPFDA_HasResult)
						yield return null;
					_ADKIDBJCAJA_action.NLDKLFODOJJ();
					_ADKIDBJCAJA_action.LHGPAJGIAME_ResultTime = Time.realtimeSinceStartup;
				}
				else
				{
					if (EHLBPCGHLCL_CanRetry(_ADKIDBJCAJA_action, _ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId, true))
					{
						AMDHPNLCJAH++;
						MAFCEPHNGMP++;
						if (AMDHPNLCJAH < _ADKIDBJCAJA_action.CFICLNJACCD_NumRetry)
						{
							yield return new WaitForSeconds(_ADKIDBJCAJA_action.GJAEJFLLKGC_RetryTime);
							_ADKIDBJCAJA_action.OGPFKGAKOFD();
							GKLKLNCOOAB = 0;
							HGFOIBHOFJL = _ADKIDBJCAJA_action.EBGACDGNCAA_CallContext;
							continue;
						}
					}
				}
			}
			else
			{
				_ADKIDBJCAJA_action.NPNNPNAIONN_IsError = true;
				_ADKIDBJCAJA_action.PDAPLCPOCMA = true;
				FDMJDEHOMNI_IsError = true;
			}
			_ADKIDBJCAJA_action.PLOOEECNHFB_IsDone = true;
			if (!FDMJDEHOMNI_IsError)
			{
				if (_ADKIDBJCAJA_action.BHFHGFKBOHH_OnSuccess != null)
					_ADKIDBJCAJA_action.BHFHGFKBOHH_OnSuccess(_ADKIDBJCAJA_action);
			}
			else
			{
				if (_ADKIDBJCAJA_action.MOBEEPPKFLG_OnFail != null)
					_ADKIDBJCAJA_action.MOBEEPPKFLG_OnFail(_ADKIDBJCAJA_action);
			}
			break;
		}
	}

	//// RVA: 0xCB7EB4 Offset: 0xCB7EB4 VA: 0xCB7EB4
	private bool EHLBPCGHLCL_CanRetry(CACGCMBKHDI_Request _ADKIDBJCAJA_action, SakashoErrorId KLCMLLLIANB, bool OHPAOJNLDJO)
	{
		if(!_ADKIDBJCAJA_action.BNCFONNOHFO)
		{
			GOBDOEHKLHN a = JGJFFKPFMDB.BDPBNKPKAJJ(KLCMLLLIANB);
			if (a != GOBDOEHKLHN.KLPAIDGGGCN_5 && (a != GOBDOEHKLHN.FJGMPDJFELN_4 || !_ADKIDBJCAJA_action.OIDCBBGLPHL))
			{
				return KLCMLLLIANB == SakashoErrorId.NETWORK_ERROR && !OHPAOJNLDJO;
			}
			return true;
		}
		return false;
	}
}
