
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use LGJOOFGOGCD_RequestInventories", true)]
public class LGJOOFGOGCD { }
public class LGJOOFGOGCD_RequestInventories : CACGCMBKHDI_Request
{
	public class GIAIPIKNBBB
	{
		public List<GJDFHLBONOL> PJJFEAHIPGL_inventories; // 0x8
		public int CJNNMLLEKEF_PreviousPage; // 0xC
		public int GPPOJHNNINK_CurrentPage; // 0x10
		public int MDIBIIHAAPN_next_page; // 0x14

		// RVA: 0x17F4420 Offset: 0x17F4420 VA: 0x17F4420
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			EDOHBJAPLPF_JsonData b = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
			PJJFEAHIPGL_inventories = new List<GJDFHLBONOL>(b.HNBFOAJIIAL_Count);
			for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				GJDFHLBONOL data = new GJDFHLBONOL();
				data.DPKCOKLMFMK(b[i]);
				PJJFEAHIPGL_inventories.Add(data);
			}
			CJNNMLLEKEF_PreviousPage = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.CJNNMLLEKEF_PreviousPage];
			GPPOJHNNINK_CurrentPage = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.GPPOJHNNINK_CurrentPage];
			MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int IGNIIEBMFIN_Page; // 0x7C
	public int MLPLGFLKKLI_Ipp; // 0x80

	public virtual SakashoInventoryCriteria IPKCADIAAPG_Criteria { get; set; } // 0x84 GOKPJIPOKCK FLHEFBEHCKK EIDLJIDFPFG
	public GIAIPIKNBBB NFEAMMJIMPG_Result { get; private set; } // 0x88 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x17F4230 Offset: 0x17F4230 VA: 0x17F4230 Slot: 12
	public override void DHLDNIEELHO()
    {
		EBGACDGNCAA_CallContext = SakashoInventory.GetInventories(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, IPKCADIAAPG_Criteria, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x17F4340 Offset: 0x17F4340 VA: 0x17F4340 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
		NFEAMMJIMPG_Result = new GIAIPIKNBBB();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
