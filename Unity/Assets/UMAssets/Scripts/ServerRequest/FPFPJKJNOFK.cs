
using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use FPFPJKJNOFK_UpdateRankingScore", true)]
public class FPFPJKJNOFK { }
public class FPFPJKJNOFK_UpdateRankingScore : CACGCMBKHDI_NetBaseAction
{
	public class PIFKFGCKNPN
	{
		public double HOCPLDLAIGL_Score; // 0x8
		public long KNIFCANOHOC_score; // 0x10
		public long FJOLNJLLJEJ_rank; // 0x18
		public bool POOLBEALDMA_DroppedPlayer; // 0x20
		public List<long> COGMPENEPBD_InventoryIds; // 0x24

		// RVA: 0x13FA430 Offset: 0x13FA430 VA: 0x13FA430
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			BOAGCEOHJEO.IIEMACPEEBJ_Deserialize(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.KNIFCANOHOC_score], out HOCPLDLAIGL_Score, out KNIFCANOHOC_score);
			FJOLNJLLJEJ_rank = JsonUtil.GetLong(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.FJOLNJLLJEJ_rank, 0);
			POOLBEALDMA_DroppedPlayer = (bool)_IDLHJIOMJBK_data["ranking_dropped_player"];
		}
	}

	public int EMPNJPMAKBF_Id; // 0x7C
	public double HOCPLDLAIGL_Score; // 0x80

	public override bool OIDCBBGLPHL { get { return true; } } //0x13FA240 GINMIBJOABO_bgs
	public PIFKFGCKNPN NFEAMMJIMPG_Result { get; private set; } // 0x88 OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0x13FA258 Offset: 0x13FA258 VA: 0x13FA258 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoRanking.UpdateRankingScore(EMPNJPMAKBF_Id, HOCPLDLAIGL_Score, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x13FA350 Offset: 0x13FA350 VA: 0x13FA350 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new PIFKFGCKNPN();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
