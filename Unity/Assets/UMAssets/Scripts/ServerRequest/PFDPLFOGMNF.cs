
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use PFDPLFOGMNF_GetRegularRankingTopRank", true)]
public class PFDPLFOGMNF { }
public class PFDPLFOGMNF_GetRegularRankingTopRank : CACGCMBKHDI_Request
{
	public class NOEPOENCKJJ : NJNCENEFCEI
	{
		public int CJNNMLLEKEF_PreviousPage; // 0xC
		public int GPPOJHNNINK_CurrentPage; // 0x10
		public int MDIBIIHAAPN_next_page; // 0x14

		// RVA: 0x16C1E8C Offset: 0x16C1E8C VA: 0x16C1E8C
		new public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			CJNNMLLEKEF_PreviousPage = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.CJNNMLLEKEF_PreviousPage];
			GPPOJHNNINK_CurrentPage = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.GPPOJHNNINK_CurrentPage];
			MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
			EJDEDOJFOOK = new List<OBGBKHKMDNF>();
			EDOHBJAPLPF_JsonData b = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.DHDHHHOAIKF_regular_ranking_ranks];
			for (int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				OBGBKHKMDNF data = new OBGBKHKMDNF();
				data.KHEKNNFCAOI_Init(b[i]);
				EJDEDOJFOOK.Add(data);
			}
		}
	}

	public string DEPGBBJMFED_CategoryId; // 0x7C
	public string HHNFHJCAPJO_Target; // 0x80
	public int IGNIIEBMFIN_Page = 1; // 0x84
	public int MLPLGFLKKLI_Ipp = 10; // 0x88

	public override bool OIDCBBGLPHL { get { return true; } } //0x16C1C90 GINMIBJOABO
	public NOEPOENCKJJ NFEAMMJIMPG_Result { get; private set; } // 0x8C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x16C1CA8 Offset: 0x16C1CA8 VA: 0x16C1CA8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoRegularRanking.GetRegularRankingTopRanks(DEPGBBJMFED_CategoryId, HHNFHJCAPJO_Target, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x16C1DAC Offset: 0x16C1DAC VA: 0x16C1DAC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new NOEPOENCKJJ();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
