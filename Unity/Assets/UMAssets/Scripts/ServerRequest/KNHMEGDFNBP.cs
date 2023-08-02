
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class PGCGJPPBOOA
{
	public int PPFNGGCBJKC_Id; // 0x8
	public int HEIPELEDAIK_RankingType; // 0xC
	public string OPFGFINHFCE_Name; // 0x10
	public string OCGFKMHNEOF_NameForApi; // 0x14
	public string KLMPFGOCBHC_Description; // 0x18
	public long KBFOIECIADN_OpenedAt; // 0x20
	public long HEOKKHAGEIE_BatchStartedAt; // 0x28
	public long ENMGMCHECGE_CompetitionCloseAt; // 0x30
	public long GKOAEJDMLED_RewardOpenedAt; // 0x38
	public long EGBOHDFBAPB_ClosedAt; // 0x40
	public long OFJFGMDBFPK_BatchIntervalTime; // 0x48
	public int DNBPICNPJNE_ScorePrecision; // 0x50
	public int ADKJLADBKKK_DefaultScore; // 0x54
	public bool KDIDMAMLBLO_AllowLowerScore; // 0x58
	public bool DNDNFAAOOBA_IsReverse; // 0x59
	public bool KBJAHKHGHAN_AllowTiedRank; // 0x5A
	public bool GFENIDOHDFP_AllowNegativeScore; // 0x5B

	// RVA: 0x16C8A88 Offset: 0x16C8A88 VA: 0x16C8A88
	public void DPKCOKLMFMK(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
    {
		PPFNGGCBJKC_Id = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id];
		HEIPELEDAIK_RankingType = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.HEIPELEDAIK_ranking_type];
		OPFGFINHFCE_Name = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		OCGFKMHNEOF_NameForApi = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OCGFKMHNEOF_name_for_api];
		KLMPFGOCBHC_Description = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		KBFOIECIADN_OpenedAt = JsonUtil.GetLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at, 0);
		HEOKKHAGEIE_BatchStartedAt = JsonUtil.GetLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.HEOKKHAGEIE_batch_started_at, 0);
		ENMGMCHECGE_CompetitionCloseAt = JsonUtil.GetLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.ENMGMCHECGE_competition_closed_at, 0);
		GKOAEJDMLED_RewardOpenedAt = JsonUtil.GetLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.GKOAEJDMLED_reward_opened_at, 0);
		EGBOHDFBAPB_ClosedAt = JsonUtil.GetLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at, 0);
		OFJFGMDBFPK_BatchIntervalTime = JsonUtil.GetLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.OFJFGMDBFPK_batch_interval_time, 0);
		DNBPICNPJNE_ScorePrecision = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.DNBPICNPJNE_score_precision];
		ADKJLADBKKK_DefaultScore = JsonUtil.GetInt(IDLHJIOMJBK, AFEHLCGHAEE_Strings.ADKJLADBKKK_default_score, 0);
		KDIDMAMLBLO_AllowLowerScore = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KDIDMAMLBLO_allow_lower_score];
		DNDNFAAOOBA_IsReverse = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.DNDNFAAOOBA_is_reverse];
		KBJAHKHGHAN_AllowTiedRank = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KBJAHKHGHAN_allow_tied_rank];
		GFENIDOHDFP_AllowNegativeScore = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.GFENIDOHDFP_allow_negative_score];
	}
}

[System.Obsolete("Use KNHMEGDFNBP_GetRankings", true)]
public class KNHMEGDFNBP {}
public class KNHMEGDFNBP_GetRankings : CACGCMBKHDI_Request
{
    public class HJANIHAJLFA
    {
        public List<PGCGJPPBOOA> JPDPFGFMKHK; // 0x8

        // // RVA: 0x1122950 Offset: 0x1122950 VA: 0x1122950
        public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
        {
            EDOHBJAPLPF_JsonData b = IDLHJIOMJBK[AFEHLCGHAEE_Strings.JPDPFGFMKHK_rankings];
            JPDPFGFMKHK = new List<PGCGJPPBOOA>(b.HNBFOAJIIAL_Count);
            for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
            {
                PGCGJPPBOOA data = new PGCGJPPBOOA();
                data.DPKCOKLMFMK(b[i]);
                JPDPFGFMKHK.Add(data);
            }
        }
    }

	public HJANIHAJLFA NFEAMMJIMPG; // 0x7C

	public override bool OIDCBBGLPHL { get { return true; } } // 0x112278C GINMIBJOABO
	
	// RVA: 0x1122794 Offset: 0x1122794 VA: 0x1122794 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoRanking.GetRankings(DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x1122870 Offset: 0x1122870 VA: 0x1122870 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = new HJANIHAJLFA();
        NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
