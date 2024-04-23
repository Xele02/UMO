
using System;
using System.Collections.Generic;
using UnityEngine;

public class PIKEPLLPNNH
{
	// Fields
	public List<OBGBKHKMDNF> DHDHHHOAIKF; // 0x8

	// RVA: 0x92F268 Offset: 0x92F268 VA: 0x92F268
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		EDOHBJAPLPF_JsonData regular_ranking_ranks = IDLHJIOMJBK[AFEHLCGHAEE_Strings.DHDHHHOAIKF_regular_ranking_ranks];
		DHDHHHOAIKF = new List<OBGBKHKMDNF>(regular_ranking_ranks.HNBFOAJIIAL_Count);
		for(int i = 0; i < regular_ranking_ranks.HNBFOAJIIAL_Count; i++)
		{
			OBGBKHKMDNF data = new OBGBKHKMDNF();
			data.KHEKNNFCAOI(regular_ranking_ranks[i]);
			DHDHHHOAIKF.Add(data);
		}
	}
}

[System.Obsolete("Use HNFBMAFPDLB_GetRegularRankingRanksAroundTarget", true)]
public class HNFBMAFPDLB { }
public class HNFBMAFPDLB_GetRegularRankingRanksAroundTarget : CACGCMBKHDI_Request
{
	public string DEPGBBJMFED; // 0x7C
	public string HHNFHJCAPJO; // 0x80
	public int NHPCKCOPKAM; // 0x84
	public int PJFKNNNDMIA; // 0x88
	public Nullable<int> MLPEHNBNOGD; // 0x8C

	public override bool OIDCBBGLPHL { get { return true; } } //0x15FAFC8 GINMIBJOABO
	public PIKEPLLPNNH NFEAMMJIMPG { get; private set; } // 0x94 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x15FAFE0 Offset: 0x15FAFE0 VA: 0x15FAFE0 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoRegularRanking.GetRegularRankingRanksAroundTarget(DEPGBBJMFED, HHNFHJCAPJO, NHPCKCOPKAM, PJFKNNNDMIA, MLPEHNBNOGD, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x15FB0FC Offset: 0x15FB0FC VA: 0x15FB0FC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new PIKEPLLPNNH();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
