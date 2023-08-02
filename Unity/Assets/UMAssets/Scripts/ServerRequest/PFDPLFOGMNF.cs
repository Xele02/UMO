
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
		public int MDIBIIHAAPN_NextPage; // 0x14

		// RVA: 0x16C1E8C Offset: 0x16C1E8C VA: 0x16C1E8C
		new public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			CJNNMLLEKEF_PreviousPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			GPPOJHNNINK_CurrentPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			MDIBIIHAAPN_NextPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
			EJDEDOJFOOK = new List<OBGBKHKMDNF>();
			EDOHBJAPLPF_JsonData b = IDLHJIOMJBK[AFEHLCGHAEE_Strings.DHDHHHOAIKF_regular_ranking_ranks];
			for (int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				OBGBKHKMDNF data = new OBGBKHKMDNF();
				data.KHEKNNFCAOI(b[i]);
				EJDEDOJFOOK.Add(data);
			}
		}
	}

	public string DEPGBBJMFED_Category; // 0x7C
	public string HHNFHJCAPJO_Target; // 0x80
	public int IGNIIEBMFIN_Page = 1; // 0x84
	public int MLPLGFLKKLI_Ipp = 10; // 0x88

	public override bool OIDCBBGLPHL { get { return true; } } //0x16C1C90 GINMIBJOABO
	public NOEPOENCKJJ NFEAMMJIMPG { get; private set; } // 0x8C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x16C1CA8 Offset: 0x16C1CA8 VA: 0x16C1CA8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoRegularRanking.GetRegularRankingTopRanks(DEPGBBJMFED_Category, HHNFHJCAPJO_Target, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x16C1DAC Offset: 0x16C1DAC VA: 0x16C1DAC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new NOEPOENCKJJ();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
