
using UnityEngine;

[System.Obsolete("Use PPFGOOFFNMB_GetTopRanks", true)]
public class PPFGOOFFNMB { }
public class PPFGOOFFNMB_GetTopRanks : CACGCMBKHDI_Request
{
	public class NJAPFHHAOHE : NJNCENEFCEI
	{
		public int CJNNMLLEKEF_PreviousPage; // 0xC
		public int GPPOJHNNINK_CurrentPage; // 0x10
		public int MDIBIIHAAPN_NextPage; // 0x14

		//// RVA: 0xDF6BE8 Offset: 0xDF6BE8 VA: 0xDF6BE8 Slot: 4
		public new virtual void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			base.KHEKNNFCAOI(IDLHJIOMJBK);
			CJNNMLLEKEF_PreviousPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			GPPOJHNNINK_CurrentPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			MDIBIIHAAPN_NextPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int EMPNJPMAKBF_Id; // 0x7C
	public int MJGOBEGONON_Type; // 0x80
	public int IGNIIEBMFIN_Page; // 0x84
	public int MLPLGFLKKLI_Ipp; // 0x88

	public NJAPFHHAOHE NFEAMMJIMPG { get; private set; } // 0x8C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0xDF691C Offset: 0xDF691C VA: 0xDF691C
	public PPFGOOFFNMB_GetTopRanks(bool KCOEDBOCPIK = false)
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
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new NJAPFHHAOHE();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
