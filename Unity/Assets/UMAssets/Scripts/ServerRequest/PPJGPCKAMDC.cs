
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use PPJGPCKAMDC_PlatformPaymentRecover", true)]
public class PPJGPCKAMDC { }
public class PPJGPCKAMDC_PlatformPaymentRecover : CACGCMBKHDI_Request
{
	public class DEGAKGMBJDF
	{
		public bool ONGLFBEGEMI_ExistUncompletedTransaction; // 0x8
		public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_Currencies = new List<MCKCJMLOAFP_CurrencyInfo>(); // 0xC
		
		// RVA: 0xDF7A24 Offset: 0xDF7A24 VA: 0xDF7A24
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			ONGLFBEGEMI_ExistUncompletedTransaction = false;
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains("exist_uncompleted_transactions"))
			{
				ONGLFBEGEMI_ExistUncompletedTransaction = (bool)IDLHJIOMJBK["exist_uncompleted_transactions"];
			}
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains("balances"))
			{
				EDOHBJAPLPF_JsonData b = IDLHJIOMJBK["balances"];
				for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
				{
					MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
					data.DPKCOKLMFMK(b[i]);
					BBEPLKNMICJ_Currencies.Add(data);
				}
			}
		}
	}

	public DEGAKGMBJDF NFEAMMJIMPG; // 0x7C

	// RVA: 0xDF77E8 Offset: 0xDF77E8 VA: 0xDF77E8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlatformPayment.Recover(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xDF78C4 Offset: 0xDF78C4 VA: 0xDF78C4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new DEGAKGMBJDF();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
