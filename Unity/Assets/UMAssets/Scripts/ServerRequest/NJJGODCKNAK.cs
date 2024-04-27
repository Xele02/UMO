
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class KJKDAGGGJCO
{
	public int PPFNGGCBJKC_Id; // 0x8
	public string BPEAIOBHMFD_NameForApis; // 0xC
	public bool ILLPEMPBDJG_CanReceiveNext; // 0x10
	public int HMFFHLPNMPH_Count; // 0x14
	public long HLMLHOFHIOK_LastReceivedAt; // 0x18
	public ANPGILOLNFK.CDOGFBNLIPG CKHOBDIKJFN_Type; // 0x20

	// RVA: 0x1A033B8 Offset: 0x1A033B8 VA: 0x1A033B8
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
    {
        PPFNGGCBJKC_Id = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id];
        BPEAIOBHMFD_NameForApis = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BPEAIOBHMFD_name_for_apis];
        ILLPEMPBDJG_CanReceiveNext = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.ILLPEMPBDJG_can_receive_next];
        HMFFHLPNMPH_Count = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.HMFFHLPNMPH_count];
        HLMLHOFHIOK_LastReceivedAt = 0;
        CKHOBDIKJFN_Type = ANPGILOLNFK.OLMFIANJBOB_GetType(BPEAIOBHMFD_NameForApis);
        if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.HLMLHOFHIOK_last_received_at) && IDLHJIOMJBK[AFEHLCGHAEE_Strings.HLMLHOFHIOK_last_received_at] != null)
            HLMLHOFHIOK_LastReceivedAt = JsonUtil.GetLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.HLMLHOFHIOK_last_received_at);
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
        public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
        {
            EDOHBJAPLPF_JsonData list = IDLHJIOMJBK[AFEHLCGHAEE_Strings.CEBOHGGJBMN_login_bonuses];
            CEBOHGGJBMN_LoginBonuses = new List<KJKDAGGGJCO>(list.HNBFOAJIIAL_Count);
            for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
            {
                KJKDAGGGJCO data = new KJKDAGGGJCO();
                data.KHEKNNFCAOI(list[i]);
                CEBOHGGJBMN_LoginBonuses.Add(data);
            }
        }
    }

	public List<int> EAFEGCPEKDC; // 0x7C

	public OLNONCJIHBA NFEAMMJIMPG { get; private set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG != null; } } //0x18AB8B8 HGPAELCGELL

	// RVA: 0x18AB6EC Offset: 0x18AB6EC VA: 0x18AB6EC Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoLoginBonus.GetLoginBonusStatuses(EAFEGCPEKDC.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x18AB7FC Offset: 0x18AB7FC VA: 0x18AB7FC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = null;
        BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
    }

	// RVA: 0x18AB8C8 Offset: 0x18AB8C8 VA: 0x18AB8C8
	private void DIAMDBHBKBH()
    {
        OLNONCJIHBA res = new OLNONCJIHBA();
        res.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
        NFEAMMJIMPG = res;
    }
}
