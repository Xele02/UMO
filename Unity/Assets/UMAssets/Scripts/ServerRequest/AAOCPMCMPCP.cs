
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use AAOCPMCMPCP_GetNormalLotItems", true)]
public class AAOCPMCMPCP { }
public class AAOCPMCMPCP_GetNormalLotItems : CACGCMBKHDI_Request
{
	public class KMFEEFFEHAD
	{
		public List<MFDJIFIIPJD> HBHMAKNGKFK_Items; // 0x8
		public int DJJGPACGEMM_ProductId; // 0xC
		public int BPNPBJALGHM_Quantity; // 0x10

		//// RVA: 0x15AFD38 Offset: 0x15AFD38 VA: 0x15AFD38
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			DJJGPACGEMM_ProductId = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.DJJGPACGEMM_product_id];
			BPNPBJALGHM_Quantity = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BPNPBJALGHM_quantity];
			EDOHBJAPLPF_JsonData d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items];
			HBHMAKNGKFK_Items = new List<MFDJIFIIPJD>(d.HNBFOAJIIAL_Count);
			for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
			{
				MFDJIFIIPJD m = new MFDJIFIIPJD();
				m.KHEKNNFCAOI(d[i]);
				HBHMAKNGKFK_Items.Add(m);
			}
		}
	}

	public int AFKAGFOFAHM; // 0x7C
	public int BPNPBJALGHM; // 0x80

	public KMFEEFFEHAD NFEAMMJIMPG { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x15AFB60 Offset: 0x15AFB60 VA: 0x15AFB60 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoNormalLotProduct.GetNormalLotItems(AFKAGFOFAHM, BPNPBJALGHM, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x15AFC58 Offset: 0x15AFC58 VA: 0x15AFC58 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new KMFEEFFEHAD();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
