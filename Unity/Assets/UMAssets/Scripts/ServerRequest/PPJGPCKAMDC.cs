
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use PPJGPCKAMDC_PlatformPaymentRecover", true)]
public class PPJGPCKAMDC { }
public class PPJGPCKAMDC_PlatformPaymentRecover : CACGCMBKHDI_Request
{
	public class DEGAKGMBJDF
	{
		public bool ONGLFBEGEMI_ExistUncompletedTransaction; // 0x8
		public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_balances = new List<MCKCJMLOAFP_CurrencyInfo>(); // 0xC
		
		// RVA: 0xDF7A24 Offset: 0xDF7A24 VA: 0xDF7A24
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			ONGLFBEGEMI_ExistUncompletedTransaction = false;
			if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains("exist_uncompleted_transactions"))
			{
				ONGLFBEGEMI_ExistUncompletedTransaction = (bool)_IDLHJIOMJBK_data["exist_uncompleted_transactions"];
			}
			if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains("balances"))
			{
				EDOHBJAPLPF_JsonData b = _IDLHJIOMJBK_data["balances"];
				for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
				{
					MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
					data.DPKCOKLMFMK(b[i]);
					BBEPLKNMICJ_balances.Add(data);
				}
			}
		}
	}

	public DEGAKGMBJDF NFEAMMJIMPG_Result; // 0x7C

	// RVA: 0xDF77E8 Offset: 0xDF77E8 VA: 0xDF77E8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlatformPayment.Recover(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xDF78C4 Offset: 0xDF78C4 VA: 0xDF78C4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new DEGAKGMBJDF();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
