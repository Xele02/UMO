
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use HDPDEAJGJEO_PaymentGetPurchasingStatus", true)]
public class HDPDEAJGJEO { }
public class HDPDEAJGJEO_PaymentGetPurchasingStatus : CACGCMBKHDI_Request
{
	public class FDECBLBCNIC
	{
		public int DJJGPACGEMM_DJJGPACGEMM_product_id; // 0x8

		// RVA: 0x1743180 Offset: 0x1743180 VA: 0x1743180
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			DJJGPACGEMM_DJJGPACGEMM_product_id = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.DJJGPACGEMM_product_id];
		}
	}

	public class NMEEMBOCCPA
	{
		public bool OIJLNFJALJP_aborted_transaction_exists; // 0x8
		public List<FDECBLBCNIC> HIAIAJJPCDE_recoverable_products; // 0xC

		// RVA: 0x1742EB8 Offset: 0x1742EB8 VA: 0x1742EB8
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			OIJLNFJALJP_aborted_transaction_exists = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OIJLNFJALJP_aborted_transaction_exists];
			EDOHBJAPLPF_JsonData l = IDLHJIOMJBK[AFEHLCGHAEE_Strings.HIAIAJJPCDE_recoverable_products];
			HIAIAJJPCDE_recoverable_products = new List<FDECBLBCNIC>(l.HNBFOAJIIAL_Count);
			for(int i = 0; i < l.HNBFOAJIIAL_Count; i++)
			{
				FDECBLBCNIC data = new FDECBLBCNIC();
				data.KHEKNNFCAOI(l[i]);
				HIAIAJJPCDE_recoverable_products.Add(data);
			}
		}
	}

	public NMEEMBOCCPA NFEAMMJIMPG; // 0x7C

	// RVA: 0x1742CFC Offset: 0x1742CFC VA: 0x1742CFC Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPayment.GetPurchasingStatus(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1742DD8 Offset: 0x1742DD8 VA: 0x1742DD8 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new NMEEMBOCCPA();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
