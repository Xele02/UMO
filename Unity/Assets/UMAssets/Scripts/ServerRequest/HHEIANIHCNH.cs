using UnityEngine;

[System.Obsolete("Use HHEIANIHCNH_RequestPlayerStatus", true)]
public class HHEIANIHCNH { }
public class HHEIANIHCNH_RequestPlayerStatus : CACGCMBKHDI_NetBaseAction
{
	public HEHLBMMFMPL_PlayerStatusInfo NFEAMMJIMPG_Result { get; private set; } // 0x7C OHEIOONIIKB_bgs LFOJDJCNOHB_bgs x17574D0 KMKEGMGKCBA_bgs 0x17574D8

	// // RVA: 0x17574E0 Offset: 0x17574E0 VA: 0x17574E0 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoUserToken.GetPlayerStatus(this.DCKLDDCAJAP, this.MEOCKCJBDAD);
    }

	// // RVA: 0x17575BC Offset: 0x17575BC VA: 0x17575BC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
        NFEAMMJIMPG_Result = new HEHLBMMFMPL_PlayerStatusInfo();
        NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(json);
    }
}

[System.Obsolete("Use HEHLBMMFMPL_PlayerStatusInfo", true)]
public class HEHLBMMFMPL {}
public class HEHLBMMFMPL_PlayerStatusInfo
{
	public int EKFHOJIGHHH_is_created; // 0x8
	public int EHGBICNIBKE_player_id; // 0xC
	public int JFMEKPDHJPP_player_account_status; // 0x10

	// public bool NNJKNHKFPBB { get; }

	// RVA: 0x1748038 Offset: 0x1748038 VA: 0x1748038
	public bool OGADPAILFBC_IsCreated()
    {
        return EKFHOJIGHHH_is_created == 1;
    }

	// // RVA: 0x1748048 Offset: 0x1748048 VA: 0x1748048
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
    {
        EKFHOJIGHHH_is_created = 1;
        if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EKFHOJIGHHH_is_created/*"is_created"*/))
        {
            EKFHOJIGHHH_is_created = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.EKFHOJIGHHH_is_created];
        }
        EHGBICNIBKE_player_id = 0;
        if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EHGBICNIBKE_player_id/*"player_id"*/))
        {
            EHGBICNIBKE_player_id = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.EHGBICNIBKE_player_id];
        }
        JFMEKPDHJPP_player_account_status = 0;
        if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.JFMEKPDHJPP_player_account_status/*"player_account_status"*/))
        {
            JFMEKPDHJPP_player_account_status = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.JFMEKPDHJPP_player_account_status];
        }
    }
}
