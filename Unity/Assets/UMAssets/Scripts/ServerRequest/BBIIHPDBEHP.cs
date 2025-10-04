
using System.Collections.Generic;
using UnityEngine;

public class BBIIHPDBEHP : CACGCMBKHDI_Request
{
    public class OKMIPDIHKGO
    {
        public List<long> COGMPENEPBD_InventoryIds; // 0x8

        // // RVA: 0xF2B0E0 Offset: 0xF2B0E0 VA: 0xF2B0E0
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
        {
            if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids))
            {
                EDOHBJAPLPF_JsonData l = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids];
                COGMPENEPBD_InventoryIds = new List<long>(l.HNBFOAJIIAL_Count);
                for(int i = 0; i < l.HNBFOAJIIAL_Count; i++)
                {
                    COGMPENEPBD_InventoryIds.Add((long)l[i]);
                }
            }
        }
    }

	public int EMPNJPMAKBF_Id; // 0x7C

	public override bool OIDCBBGLPHL { get { return true; } } //0xF2AF04 GINMIBJOABO_bgs
	public OKMIPDIHKGO NFEAMMJIMPG_Result { get; set; } //OHEIOONIIKB_bgs 0xF2AF0C LFOJDJCNOHB_bgs 0xF2AF14 KMKEGMGKCBA_bgs  // 0x80

	// RVA: 0xF2AE38 Offset: 0xF2AE38 VA: 0xF2AE38
	public BBIIHPDBEHP(bool KCOEDBOCPIK/* = False*/)
    {
        if(KCOEDBOCPIK)
        {
            NBFDEFGFLPJ = JGJFFKPFMDB.NBDHKIGADLF_IsRankingError2;
        }
    }

	// // RVA: 0xF2AF1C Offset: 0xF2AF1C VA: 0xF2AF1C Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoRanking.ClaimRankingRewards(EMPNJPMAKBF_Id, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// // RVA: 0xF2B000 Offset: 0xF2B000 VA: 0xF2B000 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        OKMIPDIHKGO data = new OKMIPDIHKGO();
        data.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
        NFEAMMJIMPG_Result = data;
    }
}
