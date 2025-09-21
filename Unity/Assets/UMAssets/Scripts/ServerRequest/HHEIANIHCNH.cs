using UnityEngine;

[System.Obsolete("Use HHEIANIHCNH_RequestPlayerStatus", true)]
public class HHEIANIHCNH { }
public class HHEIANIHCNH_RequestPlayerStatus : CACGCMBKHDI_Request
{
	public HEHLBMMFMPL_PlayerStatusInfo NFEAMMJIMPG_Result { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB x17574D0 KMKEGMGKCBA 0x17574D8

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
	public int EKFHOJIGHHH_IsCreated; // 0x8
	public int EHGBICNIBKE_PlayerId; // 0xC
	public int JFMEKPDHJPP_PlayerAccountStatus; // 0x10

	// public bool NNJKNHKFPBB { get; }

	// RVA: 0x1748038 Offset: 0x1748038 VA: 0x1748038
	public bool OGADPAILFBC_IsCreated()
    {
        return EKFHOJIGHHH_IsCreated == 1;
    }

	// // RVA: 0x1748048 Offset: 0x1748048 VA: 0x1748048
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
    {
        EKFHOJIGHHH_IsCreated = 1;
        if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EKFHOJIGHHH_IsCreated/*"is_created"*/))
        {
            EKFHOJIGHHH_IsCreated = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.EKFHOJIGHHH_IsCreated];
        }
        EHGBICNIBKE_PlayerId = 0;
        if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EHGBICNIBKE_PlayerId/*"player_id"*/))
        {
            EHGBICNIBKE_PlayerId = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.EHGBICNIBKE_PlayerId];
        }
        JFMEKPDHJPP_PlayerAccountStatus = 0;
        if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.JFMEKPDHJPP_PlayerAccountStatus/*"player_account_status"*/))
        {
            JFMEKPDHJPP_PlayerAccountStatus = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.JFMEKPDHJPP_PlayerAccountStatus];
        }
    }
}
