
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class PGCGJPPBOOA
{
	public int PPFNGGCBJKC_id; // 0x8
	public int HEIPELEDAIK_RankingType; // 0xC
	public string OPFGFINHFCE_name; // 0x10
	public string OCGFKMHNEOF_name_for_api; // 0x14
	public string KLMPFGOCBHC_description; // 0x18
	public long KBFOIECIADN_opened_at; // 0x20
	public long HEOKKHAGEIE_BatchStartedAt; // 0x28
	public long ENMGMCHECGE_CompetitionCloseAt; // 0x30
	public long GKOAEJDMLED_RewardOpenedAt; // 0x38
	public long EGBOHDFBAPB_ClosedAt; // 0x40
	public long OFJFGMDBFPK_batch_interval_time; // 0x48
	public int DNBPICNPJNE_ScorePrecision; // 0x50
	public int ADKJLADBKKK_DefaultScore; // 0x54
	public bool KDIDMAMLBLO_allow_lower_score; // 0x58
	public bool DNDNFAAOOBA_IsReverse; // 0x59
	public bool KBJAHKHGHAN_allow_tied_rank; // 0x5A
	public bool GFENIDOHDFP_AllowNegativeScore; // 0x5B

	// RVA: 0x16C8A88 Offset: 0x16C8A88 VA: 0x16C8A88
	public void DPKCOKLMFMK(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
    {
		PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
		HEIPELEDAIK_RankingType = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.HEIPELEDAIK_RankingType];
		OPFGFINHFCE_name = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		OCGFKMHNEOF_name_for_api = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.OCGFKMHNEOF_name_for_api];
		KLMPFGOCBHC_description = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		KBFOIECIADN_opened_at = JsonUtil.GetLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at, 0);
		HEOKKHAGEIE_BatchStartedAt = JsonUtil.GetLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.HEOKKHAGEIE_BatchStartedAt, 0);
		ENMGMCHECGE_CompetitionCloseAt = JsonUtil.GetLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.ENMGMCHECGE_CompetitionCloseAt, 0);
		GKOAEJDMLED_RewardOpenedAt = JsonUtil.GetLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.GKOAEJDMLED_RewardOpenedAt, 0);
		EGBOHDFBAPB_ClosedAt = JsonUtil.GetLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.EGBOHDFBAPB_CloseAt, 0);
		OFJFGMDBFPK_batch_interval_time = JsonUtil.GetLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.OFJFGMDBFPK_batch_interval_time, 0);
		DNBPICNPJNE_ScorePrecision = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.DNBPICNPJNE_ScorePrecision];
		ADKJLADBKKK_DefaultScore = JsonUtil.GetInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.ADKJLADBKKK_DefaultScore, 0);
		KDIDMAMLBLO_allow_lower_score = (bool)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KDIDMAMLBLO_allow_lower_score];
		DNDNFAAOOBA_IsReverse = (bool)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.DNDNFAAOOBA_IsReverse];
		KBJAHKHGHAN_allow_tied_rank = (bool)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KBJAHKHGHAN_allow_tied_rank];
		GFENIDOHDFP_AllowNegativeScore = (bool)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.GFENIDOHDFP_AllowNegativeScore];
	}
}

[System.Obsolete("Use KNHMEGDFNBP_GetRankings", true)]
public class KNHMEGDFNBP {}
public class KNHMEGDFNBP_GetRankings : CACGCMBKHDI_Request
{
    public class HJANIHAJLFA
    {
        public List<PGCGJPPBOOA> JPDPFGFMKHK_rankings; // 0x8

        // // RVA: 0x1122950 Offset: 0x1122950 VA: 0x1122950
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
        {
            EDOHBJAPLPF_JsonData b = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.JPDPFGFMKHK_rankings];
            JPDPFGFMKHK_rankings = new List<PGCGJPPBOOA>(b.HNBFOAJIIAL_Count);
            for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
            {
                PGCGJPPBOOA data = new PGCGJPPBOOA();
                data.DPKCOKLMFMK(b[i]);
                JPDPFGFMKHK_rankings.Add(data);
            }
        }
    }

	public HJANIHAJLFA NFEAMMJIMPG_Result; // 0x7C

	public override bool OIDCBBGLPHL { get { return true; } } // 0x112278C GINMIBJOABO
	
	// RVA: 0x1122794 Offset: 0x1122794 VA: 0x1122794 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoRanking.GetRankings(DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x1122870 Offset: 0x1122870 VA: 0x1122870 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        NFEAMMJIMPG_Result = new HJANIHAJLFA();
        NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
