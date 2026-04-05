using UnityEngine;
using System.Collections.Generic;

[System.Obsolete("Use CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt", true)]
public class CNABKDIKIOB { }
public class CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt : CACGCMBKHDI_NetBaseAction
{
	public class NDMAHKFPCAB
	{
		public class BNMFBONAKMG
		{
			public class KIDKCJGODNG
			{
				public int BBEMFICNDOG_Remaining; // 0x8
				public long HBKKLHCNCKE_ExpireAt; // 0x10

				// RVA: 0x175B248 Offset: 0x175B248 VA: 0x175B248
				public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
				{
					BBEMFICNDOG_Remaining = (int)_IDLHJIOMJBK_data["remainings"];
					HBKKLHCNCKE_ExpireAt = (long)_IDLHJIOMJBK_data["expired_at"];
				}
			}

			public int PPFNGGCBJKC_id; // 0x8
			public List<KIDKCJGODNG> FKIJMMGIDGG_Free; // 0xC
			public List<KIDKCJGODNG> GHOBKCKLCJE_Paid; // 0x10

			// RVA: 0x175AED4 Offset: 0x175AED4 VA: 0x175AED4
			public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
			{
				PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
				EDOHBJAPLPF_JsonData f = _IDLHJIOMJBK_data["free"];
				EDOHBJAPLPF_JsonData p = _IDLHJIOMJBK_data["paid"];
				FKIJMMGIDGG_Free = new List<KIDKCJGODNG>();
				for(int i = 0; i < f.HNBFOAJIIAL_Count; i++)
				{
					KIDKCJGODNG data = new KIDKCJGODNG();
					data.KHEKNNFCAOI_Init(f[i]);
					FKIJMMGIDGG_Free.Add(data);
				}
				GHOBKCKLCJE_Paid = new List<KIDKCJGODNG>();
				for (int i = 0; i < p.HNBFOAJIIAL_Count; i++)
				{
					KIDKCJGODNG data = new KIDKCJGODNG();
					data.KHEKNNFCAOI_Init(p[i]);
					GHOBKCKLCJE_Paid.Add(data);
				}
			}
		}

		public List<BNMFBONAKMG> OMDCENKJNKP_Balances = new List<BNMFBONAKMG>(); // 0x8

		// RVA: 0x175ACCC Offset: 0x175ACCC VA: 0x175ACCC
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			EDOHBJAPLPF_JsonData b = _IDLHJIOMJBK_data["balances"];
			OMDCENKJNKP_Balances = new List<BNMFBONAKMG>();
			for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				BNMFBONAKMG data = new BNMFBONAKMG();
				data.KHEKNNFCAOI_Init(b[i]);
				OMDCENKJNKP_Balances.Add(data);
			}
		}
	}

	public NDMAHKFPCAB NFEAMMJIMPG_Result; // 0x7C
	public List<int> CJNLEEEECOC; // 0x80

	// RVA: 0x175AA5C Offset: 0x175AA5C VA: 0x175AA5C Slot: 12
	public override void DHLDNIEELHO()
    {
		EBGACDGNCAA_CallContext = SakashoPayment.GetVirtualCurrencyBalancesWithExpiredAt(CJNLEEEECOC.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x175AB6C Offset: 0x175AB6C VA: 0x175AB6C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
		NFEAMMJIMPG_Result = new NDMAHKFPCAB();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
