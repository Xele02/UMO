
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use LGJOOFGOGCD_RequestInventories", true)]
public class LGJOOFGOGCD { }
public class LGJOOFGOGCD_RequestInventories : CACGCMBKHDI_Request
{
	public class GIAIPIKNBBB
	{
		public List<GJDFHLBONOL> PJJFEAHIPGL; // 0x8
		public int CJNNMLLEKEF_PreviousPage; // 0xC
		public int GPPOJHNNINK_CurrentPage; // 0x10
		public int MDIBIIHAAPN_NextPage; // 0x14

		// RVA: 0x17F4420 Offset: 0x17F4420 VA: 0x17F4420
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EDOHBJAPLPF_JsonData b = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
			PJJFEAHIPGL = new List<GJDFHLBONOL>(b.HNBFOAJIIAL_Count);
			for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				GJDFHLBONOL data = new GJDFHLBONOL();
				data.DPKCOKLMFMK(b[i]);
				PJJFEAHIPGL.Add(data);
			}
			CJNNMLLEKEF_PreviousPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			GPPOJHNNINK_CurrentPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			MDIBIIHAAPN_NextPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int IGNIIEBMFIN_Page; // 0x7C
	public int MLPLGFLKKLI_Ipp; // 0x80

	public virtual SakashoInventoryCriteria IPKCADIAAPG_Criteria { get; set; } // 0x84 GOKPJIPOKCK FLHEFBEHCKK EIDLJIDFPFG
	public GIAIPIKNBBB NFEAMMJIMPG_ResultData { get; private set; } // 0x88 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x17F4230 Offset: 0x17F4230 VA: 0x17F4230 Slot: 12
	public override void DHLDNIEELHO()
    {
		EBGACDGNCAA_CallContext = SakashoInventory.GetInventories(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, IPKCADIAAPG_Criteria, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x17F4340 Offset: 0x17F4340 VA: 0x17F4340 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
		NFEAMMJIMPG_ResultData = new GIAIPIKNBBB();
		NFEAMMJIMPG_ResultData.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
