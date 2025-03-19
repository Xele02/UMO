
using System.Collections.Generic;
using UnityEngine;

public class BBIIHPDBEHP : CACGCMBKHDI_Request
{
    public class OKMIPDIHKGO
    {
        public List<long> COGMPENEPBD; // 0x8

        // // RVA: 0xF2B0E0 Offset: 0xF2B0E0 VA: 0xF2B0E0
        public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
        {
            if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids))
            {
                EDOHBJAPLPF_JsonData l = IDLHJIOMJBK[AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids];
                COGMPENEPBD = new List<long>(l.HNBFOAJIIAL_Count);
                for(int i = 0; i < l.HNBFOAJIIAL_Count; i++)
                {
                    COGMPENEPBD.Add((long)l[i]);
                }
            }
        }
    }

	public int EMPNJPMAKBF; // 0x7C

	public override bool OIDCBBGLPHL { get { return true; } } //0xF2AF04 GINMIBJOABO
	public OKMIPDIHKGO NFEAMMJIMPG { get; set; } //OHEIOONIIKB 0xF2AF0C LFOJDJCNOHB 0xF2AF14 KMKEGMGKCBA  // 0x80

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
        EBGACDGNCAA_CallContext = SakashoRanking.ClaimRankingRewards(EMPNJPMAKBF, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// // RVA: 0xF2B000 Offset: 0xF2B000 VA: 0xF2B000 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        OKMIPDIHKGO data = new OKMIPDIHKGO();
        data.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
        NFEAMMJIMPG = data;
    }
}
