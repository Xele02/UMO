
using System;
using System.Collections.Generic;
using UnityEngine;

public class PIKEPLLPNNH
{
	// Fields
	public List<OBGBKHKMDNF> DHDHHHOAIKF_regular_ranking_ranks; // 0x8

	// RVA: 0x92F268 Offset: 0x92F268 VA: 0x92F268
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		EDOHBJAPLPF_JsonData regular_ranking_ranks = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.DHDHHHOAIKF_regular_ranking_ranks];
		DHDHHHOAIKF_regular_ranking_ranks = new List<OBGBKHKMDNF>(regular_ranking_ranks.HNBFOAJIIAL_Count);
		for(int i = 0; i < regular_ranking_ranks.HNBFOAJIIAL_Count; i++)
		{
			OBGBKHKMDNF data = new OBGBKHKMDNF();
			data.KHEKNNFCAOI_Init(regular_ranking_ranks[i]);
			DHDHHHOAIKF_regular_ranking_ranks.Add(data);
		}
	}
}

[System.Obsolete("Use HNFBMAFPDLB_GetRegularRankingRanksAroundTarget", true)]
public class HNFBMAFPDLB { }
public class HNFBMAFPDLB_GetRegularRankingRanksAroundTarget : CACGCMBKHDI_NetBaseAction
{
	public string DEPGBBJMFED_CategoryId; // 0x7C
	public string HHNFHJCAPJO_Target; // 0x80
	public int NHPCKCOPKAM_from; // 0x84
	public int PJFKNNNDMIA_to; // 0x88
	public Nullable<int> MLPEHNBNOGD_PlayerId; // 0x8C

	public override bool OIDCBBGLPHL { get { return true; } } //0x15FAFC8 GINMIBJOABO_bgs
	public PIKEPLLPNNH NFEAMMJIMPG_Result { get; private set; } // 0x94 OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0x15FAFE0 Offset: 0x15FAFE0 VA: 0x15FAFE0 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoRegularRanking.GetRegularRankingRanksAroundTarget(DEPGBBJMFED_CategoryId, HHNFHJCAPJO_Target, NHPCKCOPKAM_from, PJFKNNNDMIA_to, MLPEHNBNOGD_PlayerId, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x15FB0FC Offset: 0x15FB0FC VA: 0x15FB0FC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new PIKEPLLPNNH();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
