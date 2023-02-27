
using System.Collections.Generic;
using UnityEngine;


[System.Obsolete("Use MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory", true)]
public class MEBJLFMDGEH { }
public class MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory : CACGCMBKHDI_Request
{
	public class NPBEINILKFE
	{
		public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ; // 0x8

		// RVA: 0x1310B4C Offset: 0x1310B4C VA: 0x1310B4C
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EDOHBJAPLPF_JsonData b = IDLHJIOMJBK[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances];
			BBEPLKNMICJ = new List<MCKCJMLOAFP_CurrencyInfo>(b.HNBFOAJIIAL_Count);
			for(int i = 0; i < BBEPLKNMICJ.Count; i++)
			{
				MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
				data.DPKCOKLMFMK(b[i]);
				BBEPLKNMICJ.Add(data);
			}
		}
	}

	public List<long> AMOMNBEAHBF_Ids; // 0x7C

	public NPBEINILKFE NFEAMMJIMPG { get; set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x131095C Offset: 0x131095C VA: 0x131095C Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoInventory.ReceiveVirtualCurrencyFromInventory(AMOMNBEAHBF_Ids.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1310A6C Offset: 0x1310A6C VA: 0x1310A6C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new NPBEINILKFE();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
