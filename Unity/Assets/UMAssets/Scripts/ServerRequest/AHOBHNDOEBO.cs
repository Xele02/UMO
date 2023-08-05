
using System.Collections.Generic;
using UnityEngine;

public class AHOBHNDOEBO : CACGCMBKHDI_Request
{
	public class LLIAJIBOCBB
	{
		public List<FHPFLAGNCAF> MHKCPJDNJKI = new List<FHPFLAGNCAF>(); // 0x8

		//// RVA: 0x15C92D0 Offset: 0x15C92D0 VA: 0x15C92D0
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			MHKCPJDNJKI.Clear();
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains("platform_products"))
			{
				EDOHBJAPLPF_JsonData block = IDLHJIOMJBK["platform_products"];
				for(int i = 0; i < block.HNBFOAJIIAL_Count; i++)
				{
					FHPFLAGNCAF data = new FHPFLAGNCAF();
					data.KHEKNNFCAOI(block[i]);
					MHKCPJDNJKI.Add(data);
				}
			}
		}
	}

	public LLIAJIBOCBB NFEAMMJIMPG; // 0x7C

	// RVA: 0x15C9090 Offset: 0x15C9090 VA: 0x15C9090 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlatformPayment.GetProducts(null, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x15C9170 Offset: 0x15C9170 VA: 0x15C9170 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new LLIAJIBOCBB();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
