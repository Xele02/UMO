
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class KJKDAGGGJCO
{
	public int PPFNGGCBJKC_id; // 0x8
	public string BPEAIOBHMFD_NameForApis; // 0xC
	public bool ILLPEMPBDJG_CanReceiveNext; // 0x10
	public int HMFFHLPNMPH_Count; // 0x14
	public long HLMLHOFHIOK_LastReceivedAt; // 0x18
	public ANPGILOLNFK.CDOGFBNLIPG CKHOBDIKJFN_Type; // 0x20

	// RVA: 0x1A033B8 Offset: 0x1A033B8 VA: 0x1A033B8
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
    {
        PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
        BPEAIOBHMFD_NameForApis = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.BPEAIOBHMFD_NameForApis];
        ILLPEMPBDJG_CanReceiveNext = (bool)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.ILLPEMPBDJG_CanReceiveNext];
        HMFFHLPNMPH_Count = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.HMFFHLPNMPH_Count];
        HLMLHOFHIOK_LastReceivedAt = 0;
        CKHOBDIKJFN_Type = ANPGILOLNFK.OLMFIANJBOB_GetType(BPEAIOBHMFD_NameForApis);
        if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.HLMLHOFHIOK_LastReceivedAt) && _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.HLMLHOFHIOK_LastReceivedAt] != null)
            HLMLHOFHIOK_LastReceivedAt = JsonUtil.GetLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.HLMLHOFHIOK_LastReceivedAt);
    }
}

[System.Obsolete("Use NJJGODCKNAK_GetLoginBonusStatuses", true)]
public class NJJGODCKNAK {}
public class NJJGODCKNAK_GetLoginBonusStatuses : CACGCMBKHDI_Request
{
    public class OLNONCJIHBA
    {
        public List<KJKDAGGGJCO> CEBOHGGJBMN_LoginBonuses = new List<KJKDAGGGJCO>(); // 0x8

        // // RVA: 0x18ABA28 Offset: 0x18ABA28 VA: 0x18ABA28
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
        {
            EDOHBJAPLPF_JsonData list = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.CEBOHGGJBMN_LoginBonuses];
            CEBOHGGJBMN_LoginBonuses = new List<KJKDAGGGJCO>(list.HNBFOAJIIAL_Count);
            for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
            {
                KJKDAGGGJCO data = new KJKDAGGGJCO();
                data.KHEKNNFCAOI_Init(list[i]);
                CEBOHGGJBMN_LoginBonuses.Add(data);
            }
        }
    }

	public List<int> EAFEGCPEKDC_Ids; // 0x7C

	public OLNONCJIHBA NFEAMMJIMPG_Result { get; private set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG_Result != null; } } //0x18AB8B8 HGPAELCGELL

	// RVA: 0x18AB6EC Offset: 0x18AB6EC VA: 0x18AB6EC Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoLoginBonus.GetLoginBonusStatuses(EAFEGCPEKDC_Ids.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x18AB7FC Offset: 0x18AB7FC VA: 0x18AB7FC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        NFEAMMJIMPG_Result = null;
        BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
    }

	// RVA: 0x18AB8C8 Offset: 0x18AB8C8 VA: 0x18AB8C8
	private void DIAMDBHBKBH()
    {
        OLNONCJIHBA res = new OLNONCJIHBA();
        res.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
        NFEAMMJIMPG_Result = res;
    }
}
