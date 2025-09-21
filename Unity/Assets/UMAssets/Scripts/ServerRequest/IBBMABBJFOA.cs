
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use IBBMABBJFOA_PaymentRecover", true)]
public class IBBMABBJFOA { }
public class IBBMABBJFOA_PaymentRecover : CACGCMBKHDI_Request
{
	public class EPJKBEHOMNJ
	{
		public int DJJGPACGEMM_ProductId; // 0x8
		public BEAOCBFAHKF NFEAMMJIMPG_Result; // 0xC

		// RVA: 0x1210F60 Offset: 0x1210F60 VA: 0x1210F60
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			DJJGPACGEMM_ProductId = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.DJJGPACGEMM_ProductId];
			NFEAMMJIMPG_Result = new BEAOCBFAHKF();
			NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(_IDLHJIOMJBK_Data);
		}
	}

	public class JMFPKNEMJBO
	{
		public int DJJGPACGEMM_ProductId; // 0x8
		public string DJDFHJNNDGF_RecoveryErrorCode; // 0xC

		// RVA: 0x12110A0 Offset: 0x12110A0 VA: 0x12110A0
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			DJJGPACGEMM_ProductId = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.DJJGPACGEMM_ProductId];
			DJDFHJNNDGF_RecoveryErrorCode = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.DJDFHJNNDGF_RecoveryErrorCode];
		}
	}

	public class MKNBKIFFDKK
	{
		public List<EPJKBEHOMNJ> FHANAFNKIFC_Success; // 0x8
		public List<JMFPKNEMJBO> DOGDHKIEBJA_Error; // 0xC

		// RVA: 0x1210B18 Offset: 0x1210B18 VA: 0x1210B18
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			FHANAFNKIFC_Success = null;
			DOGDHKIEBJA_Error = null;
			if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FHANAFNKIFC_Success))
			{
				FHANAFNKIFC_Success = new List<EPJKBEHOMNJ>(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.FHANAFNKIFC_Success].HNBFOAJIIAL_Count);
				for(int i = 0; i < _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.FHANAFNKIFC_Success].HNBFOAJIIAL_Count; i++)
				{
					EPJKBEHOMNJ data = new EPJKBEHOMNJ();
					data.KHEKNNFCAOI_Init(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.FHANAFNKIFC_Success][i]);
					FHANAFNKIFC_Success.Add(data);
				}
			}
			if (_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.DOGDHKIEBJA_Error))
			{
				DOGDHKIEBJA_Error = new List<JMFPKNEMJBO>(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.DOGDHKIEBJA_Error].HNBFOAJIIAL_Count);
				for (int i = 0; i < _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.DOGDHKIEBJA_Error].HNBFOAJIIAL_Count; i++)
				{
					JMFPKNEMJBO data = new JMFPKNEMJBO();
					data.KHEKNNFCAOI_Init(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.DOGDHKIEBJA_Error][i]);
					DOGDHKIEBJA_Error.Add(data);
				}
			}
		}
	}

	public MKNBKIFFDKK NFEAMMJIMPG_Result { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x12108BC Offset: 0x12108BC VA: 0x12108BC
	public IBBMABBJFOA_PaymentRecover()
	{
		ICDEFIIADDO_Timeout = 8640000.0f;
	}

	// RVA: 0x121095C Offset: 0x121095C VA: 0x121095C Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPayment.Recover(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1210A38 Offset: 0x1210A38 VA: 0x1210A38 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new MKNBKIFFDKK();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
