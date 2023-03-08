
using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use FPFPJKJNOFK_UpdateRankingScore", true)]
public class FPFPJKJNOFK { }
public class FPFPJKJNOFK_UpdateRankingScore : CACGCMBKHDI_Request
{
	public class PIFKFGCKNPN
	{
		public double HOCPLDLAIGL_Score; // 0x8
		public long KNIFCANOHOC_ScoreTrunc; // 0x10
		public long FJOLNJLLJEJ_Rank; // 0x18
		public bool POOLBEALDMA_DroppedPlayer; // 0x20
		public List<long> COGMPENEPBD; // 0x24

		// RVA: 0x13FA430 Offset: 0x13FA430 VA: 0x13FA430
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			BOAGCEOHJEO.IIEMACPEEBJ(IDLHJIOMJBK[AFEHLCGHAEE_Strings.KNIFCANOHOC_score], out HOCPLDLAIGL_Score, out KNIFCANOHOC_ScoreTrunc);
			FJOLNJLLJEJ_Rank = JsonUtil.GetLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.FJOLNJLLJEJ_rank, 0);
			POOLBEALDMA_DroppedPlayer = (bool)IDLHJIOMJBK["ranking_dropped_player"];
		}
	}

	public int EMPNJPMAKBF_Id; // 0x7C
	public double HOCPLDLAIGL_Score; // 0x80

	//public override bool OIDCBBGLPHL { get; }
	public PIFKFGCKNPN NFEAMMJIMPG { get; private set; } // 0x88 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x13FA240 Offset: 0x13FA240 VA: 0x13FA240 Slot: 7
	//public override bool GINMIBJOABO() { }

	// RVA: 0x13FA258 Offset: 0x13FA258 VA: 0x13FA258 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoRanking.UpdateRankingScore(EMPNJPMAKBF_Id, HOCPLDLAIGL_Score, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x13FA350 Offset: 0x13FA350 VA: 0x13FA350 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new PIFKFGCKNPN();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
