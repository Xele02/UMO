
using UnityEngine;
using XeSys;

public class EBHIMFFJBIJ
{
	public int MCJEIDPDMLF_EffectId; // 0x8
	public int LHJMEJOJGKL_NumberOfTimes; // 0xC
	public long OJCCKOICMJK_CreatedAt; // 0x10
	public long LPJIIDJJKOE_UpdatedAt; // 0x18
	public long FFDEBPDJOIJ_ExpiredAt; // 0x20
	public int NMEGALKLMKH_LastUpdatedPlayerId; // 0x28

	// RVA: 0x14F6240 Offset: 0x14F6240 VA: 0x14F6240
	public EBHIMFFJBIJ(GIINMFDIIMD CDGMPGLAING)
    {
        MCJEIDPDMLF_EffectId = JsonUtil.GetInt(CDGMPGLAING.DLENPPIJNPA, "effect_id", 0);
        LHJMEJOJGKL_NumberOfTimes = JsonUtil.GetInt(CDGMPGLAING.DLENPPIJNPA, "number_of_times", 0);
        OJCCKOICMJK_CreatedAt = JsonUtil.GetLong(CDGMPGLAING.DLENPPIJNPA, "created_at", 0);
        LPJIIDJJKOE_UpdatedAt = JsonUtil.GetLong(CDGMPGLAING.DLENPPIJNPA, "updated_at", 0);
        FFDEBPDJOIJ_ExpiredAt = JsonUtil.GetLong(CDGMPGLAING.DLENPPIJNPA, "expired_at", 0);
        NMEGALKLMKH_LastUpdatedPlayerId = CDGMPGLAING.DLENPPIJNPA.LBDOLHGDIEB("last_updated_player_id", null).DOHALJMPAAN<int>((EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
        {
            //0x14FDF14
            return (int)IDLHJIOMJBK;
        }, 0);
    }
}

[System.Obsolete("Use KDMINIMGGLI_EncounterRaidboss", true)]
public class KDMINIMGGLI {}
public class KDMINIMGGLI_EncounterRaidboss : CACGCMBKHDI_Request
{
    public class MNOBFFCNDLL
    {
        public string MMEBLOIJBKE_UniqueKey; // 0x8
    }

    public class ODMFEOAPAAA : CMPLGKFJCIC<EBHIMFFJBIJ>
    {
        // RVA: 0xE85EF4 Offset: 0xE85EF4 VA: 0xE85EF4
        public ODMFEOAPAAA(EDOHBJAPLPF_JsonData DLENPPIJNPA)
            : base(new GIINMFDIIMD(DLENPPIJNPA), (GIINMFDIIMD IDLHJIOMJBK) =>
            {
                //0xE861A0
                return new EBHIMFFJBIJ(IDLHJIOMJBK);
            })
        {;
        }
    }

	public MNOBFFCNDLL BIHCCEHLAOD = new MNOBFFCNDLL(); // 0x7C
	public ODMFEOAPAAA NFEAMMJIMPG; // 0x80

	// RVA: 0xE85D40 Offset: 0xE85D40 VA: 0xE85D40 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoRaidboss.EncounterRaidboss(BIHCCEHLAOD.MMEBLOIJBKE_UniqueKey, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0xE85E38 Offset: 0xE85E38 VA: 0xE85E38 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = new ODMFEOAPAAA(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
