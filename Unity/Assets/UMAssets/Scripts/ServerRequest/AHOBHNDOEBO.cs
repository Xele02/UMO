
using System.Collections.Generic;
using UnityEngine;

public class AHOBHNDOEBO : CACGCMBKHDI_Request
{
	public class LLIAJIBOCBB
	{
		public List<FHPFLAGNCAF> MHKCPJDNJKI_products = new List<FHPFLAGNCAF>(); // 0x8

		//// RVA: 0x15C92D0 Offset: 0x15C92D0 VA: 0x15C92D0
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			MHKCPJDNJKI_products.Clear();
			if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains("platform_products"))
			{
				EDOHBJAPLPF_JsonData block = _IDLHJIOMJBK_data["platform_products"];
				for(int i = 0; i < block.HNBFOAJIIAL_Count; i++)
				{
					FHPFLAGNCAF data = new FHPFLAGNCAF();
					data.KHEKNNFCAOI_Init(block[i]);
					MHKCPJDNJKI_products.Add(data);
				}
			}
		}
	}

	public LLIAJIBOCBB NFEAMMJIMPG_Result; // 0x7C

	// RVA: 0x15C9090 Offset: 0x15C9090 VA: 0x15C9090 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlatformPayment.GetProducts(null, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x15C9170 Offset: 0x15C9170 VA: 0x15C9170 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new LLIAJIBOCBB();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
