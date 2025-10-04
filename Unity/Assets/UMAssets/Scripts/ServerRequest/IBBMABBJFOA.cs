
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use IBBMABBJFOA_PaymentRecover", true)]
public class IBBMABBJFOA { }
public class IBBMABBJFOA_PaymentRecover : CACGCMBKHDI_Request
{
	public class EPJKBEHOMNJ
	{
		public int DJJGPACGEMM_product_id; // 0x8
		public BEAOCBFAHKF NFEAMMJIMPG_Result; // 0xC

		// RVA: 0x1210F60 Offset: 0x1210F60 VA: 0x1210F60
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			DJJGPACGEMM_product_id = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.DJJGPACGEMM_product_id];
			NFEAMMJIMPG_Result = new BEAOCBFAHKF();
			NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data);
		}
	}

	public class JMFPKNEMJBO
	{
		public int DJJGPACGEMM_product_id; // 0x8
		public string DJDFHJNNDGF_recovery_error_code; // 0xC

		// RVA: 0x12110A0 Offset: 0x12110A0 VA: 0x12110A0
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			DJJGPACGEMM_product_id = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.DJJGPACGEMM_product_id];
			DJDFHJNNDGF_recovery_error_code = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.DJDFHJNNDGF_recovery_error_code];
		}
	}

	public class MKNBKIFFDKK
	{
		public List<EPJKBEHOMNJ> FHANAFNKIFC_success; // 0x8
		public List<JMFPKNEMJBO> DOGDHKIEBJA_error; // 0xC

		// RVA: 0x1210B18 Offset: 0x1210B18 VA: 0x1210B18
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			FHANAFNKIFC_success = null;
			DOGDHKIEBJA_error = null;
			if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FHANAFNKIFC_success))
			{
				FHANAFNKIFC_success = new List<EPJKBEHOMNJ>(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.FHANAFNKIFC_success].HNBFOAJIIAL_Count);
				for(int i = 0; i < _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.FHANAFNKIFC_success].HNBFOAJIIAL_Count; i++)
				{
					EPJKBEHOMNJ data = new EPJKBEHOMNJ();
					data.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.FHANAFNKIFC_success][i]);
					FHANAFNKIFC_success.Add(data);
				}
			}
			if (_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.DOGDHKIEBJA_error))
			{
				DOGDHKIEBJA_error = new List<JMFPKNEMJBO>(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.DOGDHKIEBJA_error].HNBFOAJIIAL_Count);
				for (int i = 0; i < _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.DOGDHKIEBJA_error].HNBFOAJIIAL_Count; i++)
				{
					JMFPKNEMJBO data = new JMFPKNEMJBO();
					data.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.DOGDHKIEBJA_error][i]);
					DOGDHKIEBJA_error.Add(data);
				}
			}
		}
	}

	public MKNBKIFFDKK NFEAMMJIMPG_Result { get; private set; } // 0x7C OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

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
