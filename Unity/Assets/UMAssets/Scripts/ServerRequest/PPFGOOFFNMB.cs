
using UnityEngine;

[System.Obsolete("Use PPFGOOFFNMB_GetTopRanks", true)]
public class PPFGOOFFNMB { }
public class PPFGOOFFNMB_GetTopRanks : CACGCMBKHDI_NetBaseAction
{
	public class NJAPFHHAOHE : NJNCENEFCEI
	{
		public int CJNNMLLEKEF_previous_page; // 0xC
		public int GPPOJHNNINK_current_page; // 0x10
		public int MDIBIIHAAPN_next_page; // 0x14

		//// RVA: 0xDF6BE8 Offset: 0xDF6BE8 VA: 0xDF6BE8 Slot: 4
		public new virtual void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			base.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data);
			CJNNMLLEKEF_previous_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			GPPOJHNNINK_current_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int EMPNJPMAKBF_Id; // 0x7C
	public int MJGOBEGONON_Type; // 0x80
	public int IGNIIEBMFIN_Page; // 0x84
	public int MLPLGFLKKLI_Ipp; // 0x88

	public NJAPFHHAOHE NFEAMMJIMPG_Result { get; private set; } // 0x8C OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0xDF691C Offset: 0xDF691C VA: 0xDF691C
	public PPFGOOFFNMB_GetTopRanks(bool KCOEDBOCPIK/* = false*/)
	{
		if (KCOEDBOCPIK)
			return;
		NBFDEFGFLPJ = JGJFFKPFMDB.NBDHKIGADLF_IsRankingError2;
	}

	//// RVA: 0xDF69F8 Offset: 0xDF69F8 VA: 0xDF69F8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoRanking.GetTopRanks(EMPNJPMAKBF_Id, MJGOBEGONON_Type, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	//// RVA: 0xDF6AFC Offset: 0xDF6AFC VA: 0xDF6AFC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new NJAPFHHAOHE();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
