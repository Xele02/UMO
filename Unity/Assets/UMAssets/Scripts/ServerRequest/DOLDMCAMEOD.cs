using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use DOLDMCAMEOD_RequestRemainingForCurrencyIds", true)]
public class DOLDMCAMEOD { }
public class DOLDMCAMEOD_RequestRemainingForCurrencyIds : CACGCMBKHDI_Request
{
    public class LDADODICMLG_ResultData
    {
        public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_Balances; // 0x8

        // RVA: 0x1233554 Offset: 0x1233554 VA: 0x1233554
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			EDOHBJAPLPF_JsonData b = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.BBEPLKNMICJ_Balances];
			BBEPLKNMICJ_Balances = new List<MCKCJMLOAFP_CurrencyInfo>(b.HNBFOAJIIAL_Count);
			for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
				data.DPKCOKLMFMK(b[i]);
				BBEPLKNMICJ_Balances.Add(data);
			}
		}
    }
    
	public List<int> CGCFENMHJIM_Ids; // 0x7C

	public LDADODICMLG_ResultData NFEAMMJIMPG_Result { get; private set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x1233364 Offset: 0x1233364 VA: 0x1233364 Slot: 12
	public override void DHLDNIEELHO()
    {
		EBGACDGNCAA_CallContext = SakashoPayment.GetRemainingForCurrencyIds(CGCFENMHJIM_Ids.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1233474 Offset: 0x1233474 VA: 0x1233474 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
		NFEAMMJIMPG_Result = new LDADODICMLG_ResultData();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
