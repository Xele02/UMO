using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use DOLDMCAMEOD_RequestRemainingForCurrencyIds", true)]
public class DOLDMCAMEOD { }
public class DOLDMCAMEOD_RequestRemainingForCurrencyIds : CACGCMBKHDI_Request
{
    public class LDADODICMLG_ResultData
    {
        public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_CurrenciesList; // 0x8

        // RVA: 0x1233554 Offset: 0x1233554 VA: 0x1233554
        public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EDOHBJAPLPF_JsonData b = IDLHJIOMJBK[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances];
			BBEPLKNMICJ_CurrenciesList = new List<MCKCJMLOAFP_CurrencyInfo>(b.HNBFOAJIIAL_Count);
			for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
				data.DPKCOKLMFMK(b[i]);
				BBEPLKNMICJ_CurrenciesList.Add(data);
			}
		}
    }
    
	public List<int> CGCFENMHJIM_Ids; // 0x7C

	public LDADODICMLG_ResultData NFEAMMJIMPG { get; private set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x1233364 Offset: 0x1233364 VA: 0x1233364 Slot: 12
	public override void DHLDNIEELHO()
    {
		EBGACDGNCAA_CallContext = SakashoPayment.GetRemainingForCurrencyIds(CGCFENMHJIM_Ids.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1233474 Offset: 0x1233474 VA: 0x1233474 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
		NFEAMMJIMPG = new LDADODICMLG_ResultData();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
