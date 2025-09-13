
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use IBBMABBJFOA_PaymentRecover", true)]
public class IBBMABBJFOA { }
public class IBBMABBJFOA_PaymentRecover : CACGCMBKHDI_Request
{
	public class EPJKBEHOMNJ
	{
		public int DJJGPACGEMM_ProductId; // 0x8
		public BEAOCBFAHKF NFEAMMJIMPG; // 0xC

		// RVA: 0x1210F60 Offset: 0x1210F60 VA: 0x1210F60
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			DJJGPACGEMM_ProductId = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.DJJGPACGEMM_ProductId];
			NFEAMMJIMPG = new BEAOCBFAHKF();
			NFEAMMJIMPG.KHEKNNFCAOI(IDLHJIOMJBK);
		}
	}

	public class JMFPKNEMJBO
	{
		public int DJJGPACGEMM_ProductId; // 0x8
		public string DJDFHJNNDGF_RecoveryErrorCode; // 0xC

		// RVA: 0x12110A0 Offset: 0x12110A0 VA: 0x12110A0
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			DJJGPACGEMM_ProductId = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.DJJGPACGEMM_ProductId];
			DJDFHJNNDGF_RecoveryErrorCode = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.DJDFHJNNDGF_RecoveryErrorCode];
		}
	}

	public class MKNBKIFFDKK
	{
		public List<EPJKBEHOMNJ> FHANAFNKIFC_Success; // 0x8
		public List<JMFPKNEMJBO> DOGDHKIEBJA_Error; // 0xC

		// RVA: 0x1210B18 Offset: 0x1210B18 VA: 0x1210B18
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			FHANAFNKIFC_Success = null;
			DOGDHKIEBJA_Error = null;
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FHANAFNKIFC_Success))
			{
				FHANAFNKIFC_Success = new List<EPJKBEHOMNJ>(IDLHJIOMJBK[AFEHLCGHAEE_Strings.FHANAFNKIFC_Success].HNBFOAJIIAL_Count);
				for(int i = 0; i < IDLHJIOMJBK[AFEHLCGHAEE_Strings.FHANAFNKIFC_Success].HNBFOAJIIAL_Count; i++)
				{
					EPJKBEHOMNJ data = new EPJKBEHOMNJ();
					data.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.FHANAFNKIFC_Success][i]);
					FHANAFNKIFC_Success.Add(data);
				}
			}
			if (IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.DOGDHKIEBJA_Error))
			{
				DOGDHKIEBJA_Error = new List<JMFPKNEMJBO>(IDLHJIOMJBK[AFEHLCGHAEE_Strings.DOGDHKIEBJA_Error].HNBFOAJIIAL_Count);
				for (int i = 0; i < IDLHJIOMJBK[AFEHLCGHAEE_Strings.DOGDHKIEBJA_Error].HNBFOAJIIAL_Count; i++)
				{
					JMFPKNEMJBO data = new JMFPKNEMJBO();
					data.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.DOGDHKIEBJA_Error][i]);
					DOGDHKIEBJA_Error.Add(data);
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
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG = new MKNBKIFFDKK();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
