
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use IBBMABBJFOA_PaymentRecover", true)]
public class IBBMABBJFOA { }
public class IBBMABBJFOA_PaymentRecover : CACGCMBKHDI_Request
{
	public class EPJKBEHOMNJ
	{
		public int DJJGPACGEMM; // 0x8
		//public BEAOCBFAHKF NFEAMMJIMPG; // 0xC

		// RVA: 0x1210F60 Offset: 0x1210F60 VA: 0x1210F60
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			TodoLogger.LogError(0, "IBBMABBJFOA_PaymentRecover.EPJKBEHOMNJ.KHEKNNFCAOI");
		}
	}

	public class JMFPKNEMJBO
	{
		public int DJJGPACGEMM_ProductId; // 0x8
		public string DJDFHJNNDGF_RecoveryErrorCode; // 0xC

		// RVA: 0x12110A0 Offset: 0x12110A0 VA: 0x12110A0
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			DJJGPACGEMM_ProductId = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.DJJGPACGEMM_product_id];
			DJDFHJNNDGF_RecoveryErrorCode = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.DJDFHJNNDGF_recovery_error_code];
		}
	}

	public class MKNBKIFFDKK
	{
		public List<EPJKBEHOMNJ> FHANAFNKIFC_Success; // 0x8
		public List<JMFPKNEMJBO> DOGDHKIEBJA_Errors; // 0xC

		// RVA: 0x1210B18 Offset: 0x1210B18 VA: 0x1210B18
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			FHANAFNKIFC_Success = null;
			DOGDHKIEBJA_Errors = null;
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FHANAFNKIFC_success))
			{
				FHANAFNKIFC_Success = new List<EPJKBEHOMNJ>(IDLHJIOMJBK[AFEHLCGHAEE_Strings.FHANAFNKIFC_success].HNBFOAJIIAL_Count);
				for(int i = 0; i < IDLHJIOMJBK[AFEHLCGHAEE_Strings.FHANAFNKIFC_success].HNBFOAJIIAL_Count; i++)
				{
					EPJKBEHOMNJ data = new EPJKBEHOMNJ();
					data.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.FHANAFNKIFC_success][i]);
					FHANAFNKIFC_Success.Add(data);
				}
			}
			if (IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.DOGDHKIEBJA_error))
			{
				DOGDHKIEBJA_Errors = new List<JMFPKNEMJBO>(IDLHJIOMJBK[AFEHLCGHAEE_Strings.DOGDHKIEBJA_error].HNBFOAJIIAL_Count);
				for (int i = 0; i < IDLHJIOMJBK[AFEHLCGHAEE_Strings.DOGDHKIEBJA_error].HNBFOAJIIAL_Count; i++)
				{
					JMFPKNEMJBO data = new JMFPKNEMJBO();
					data.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.DOGDHKIEBJA_error][i]);
					DOGDHKIEBJA_Errors.Add(data);
				}
			}
		}
	}

	public MKNBKIFFDKK NFEAMMJIMPG { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

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
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new MKNBKIFFDKK();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
