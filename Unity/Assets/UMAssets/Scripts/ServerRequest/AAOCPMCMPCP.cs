
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use AAOCPMCMPCP_GetNormalLotItems", true)]
public class AAOCPMCMPCP { }
public class AAOCPMCMPCP_GetNormalLotItems : CACGCMBKHDI_Request
{
	public class KMFEEFFEHAD
	{
		public List<MFDJIFIIPJD> HBHMAKNGKFK_items; // 0x8
		public int DJJGPACGEMM_product_id; // 0xC
		public int BPNPBJALGHM_quantity; // 0x10

		//// RVA: 0x15AFD38 Offset: 0x15AFD38 VA: 0x15AFD38
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			DJJGPACGEMM_product_id = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.DJJGPACGEMM_product_id];
			BPNPBJALGHM_quantity = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BPNPBJALGHM_quantity];
			EDOHBJAPLPF_JsonData d = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items];
			HBHMAKNGKFK_items = new List<MFDJIFIIPJD>(d.HNBFOAJIIAL_Count);
			for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
			{
				MFDJIFIIPJD m = new MFDJIFIIPJD();
				m.KHEKNNFCAOI_Init(d[i]);
				HBHMAKNGKFK_items.Add(m);
			}
		}
	}

	public int AFKAGFOFAHM_ProductId; // 0x7C
	public int BPNPBJALGHM_quantity; // 0x80

	public KMFEEFFEHAD NFEAMMJIMPG_Result { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x15AFB60 Offset: 0x15AFB60 VA: 0x15AFB60 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoNormalLotProduct.GetNormalLotItems(AFKAGFOFAHM_ProductId, BPNPBJALGHM_quantity, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x15AFC58 Offset: 0x15AFC58 VA: 0x15AFC58 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new KMFEEFFEHAD();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
