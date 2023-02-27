using UnityEngine;
using System.Collections.Generic;

[System.Obsolete("Use CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt", true)]
public class CNABKDIKIOB { }
public class CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt : CACGCMBKHDI_Request
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
				public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
				{
					BBEMFICNDOG_Remaining = (int)IDLHJIOMJBK["remainings"];
					HBKKLHCNCKE_ExpireAt = (long)IDLHJIOMJBK["expired_at"];
				}
			}

			public int PPFNGGCBJKC_Id; // 0x8
			public List<KIDKCJGODNG> FKIJMMGIDGG_Free; // 0xC
			public List<KIDKCJGODNG> GHOBKCKLCJE_Paid; // 0x10

			// RVA: 0x175AED4 Offset: 0x175AED4 VA: 0x175AED4
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
			{
				PPFNGGCBJKC_Id = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id];
				EDOHBJAPLPF_JsonData f = IDLHJIOMJBK["free"];
				EDOHBJAPLPF_JsonData p = IDLHJIOMJBK["paid"];
				FKIJMMGIDGG_Free = new List<KIDKCJGODNG>();
				for(int i = 0; i < f.HNBFOAJIIAL_Count; i++)
				{
					KIDKCJGODNG data = new KIDKCJGODNG();
					data.KHEKNNFCAOI(f[i]);
					FKIJMMGIDGG_Free.Add(data);
				}
				GHOBKCKLCJE_Paid = new List<KIDKCJGODNG>();
				for (int i = 0; i < p.HNBFOAJIIAL_Count; i++)
				{
					KIDKCJGODNG data = new KIDKCJGODNG();
					data.KHEKNNFCAOI(p[i]);
					GHOBKCKLCJE_Paid.Add(data);
				}
			}
		}

		public List<BNMFBONAKMG> OMDCENKJNKP = new List<BNMFBONAKMG>(); // 0x8

		// RVA: 0x175ACCC Offset: 0x175ACCC VA: 0x175ACCC
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EDOHBJAPLPF_JsonData b = IDLHJIOMJBK["balances"];
			OMDCENKJNKP = new List<BNMFBONAKMG>();
			for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				BNMFBONAKMG data = new BNMFBONAKMG();
				data.KHEKNNFCAOI(b[i]);
				OMDCENKJNKP.Add(data);
			}
		}
	}

	public NDMAHKFPCAB NFEAMMJIMPG; // 0x7C
	public List<int> CJNLEEEECOC; // 0x80

	// RVA: 0x175AA5C Offset: 0x175AA5C VA: 0x175AA5C Slot: 12
	public override void DHLDNIEELHO()
    {
		EBGACDGNCAA_CallContext = SakashoPayment.GetVirtualCurrencyBalancesWithExpiredAt(CJNLEEEECOC.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x175AB6C Offset: 0x175AB6C VA: 0x175AB6C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
		NFEAMMJIMPG = new NDMAHKFPCAB();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
