using System.Collections.Generic;
using UnityEngine;
using System;
using XeSys;

public delegate bool LDDPADICHHB(List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData NMICBJDPLOH);

public class NAIJIFAJGGK { }
public class NAIJIFAJGGK_RequestLoadPlayerData : CACGCMBKHDI_Request
{
    public class PHAKFFBNNEI_PlayerDataResult
    {
        public long BIOGKIEECGN_CreatedAt; // 0x8
        public long IFNLEKOILPM_UpdatedAt; // 0x10
        public int CEMEIPNMAAD; // 0x18
        public sbyte MLGKDBJLNBM_DataStatus; // 0x1C
        public bool PLEAGPCJICK; // 0x1D
    }

	public List<string> HHIHCJKLJFF_BlockToRequest { get; set; } // 0x7C OHINHCAEFDJ AOELBKNHIMG HGAICKPMCCB
	public LDDPADICHHB IJMPLDBGMHC_OnDataReceived { get; set; } // 0x80 LKIBOJLDBHM DCNBDAGBCPB LGLGACHHDGK
	public PHAKFFBNNEI_PlayerDataResult NFEAMMJIMPG_Result { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA_HasResult { get {
        return NFEAMMJIMPG_Result != null;
        } } // 0x17C031C HGPAELCGELL

	// // RVA: 0x17C0084 Offset: 0x17C0084 VA: 0x17C0084
	public NAIJIFAJGGK_RequestLoadPlayerData()
    {
        ICDEFIIADDO_Timeout = 30.0f;
    }

	// // RVA: 0x17C0114 Offset: 0x17C0114 VA: 0x17C0114 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoPlayerData.LoadPlayerData(HHIHCJKLJFF_BlockToRequest.ToArray(), this.DCKLDDCAJAP, this.MEOCKCJBDAD);
    }

	// // RVA: 0x17C0260 Offset: 0x17C0260 VA: 0x17C0260 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG_Result = null;
        BNJPAKLNOPA_WorkerThreadQueue.Add(this.DIAMDBHBKBH);
    }

	// // RVA: 0x17C032C Offset: 0x17C032C VA: 0x17C032C Slot: 15
	public override void NLDKLFODOJJ()
    {
        return;
    }

	// // RVA: 0x17C0330 Offset: 0x17C0330 VA: 0x17C0330
	private void DIAMDBHBKBH()
    {
        PHAKFFBNNEI_PlayerDataResult tmp = new PHAKFFBNNEI_PlayerDataResult();
        EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
        tmp.BIOGKIEECGN_CreatedAt = JsonUtil.GetLong(jsonData["created_at"]);
        tmp.IFNLEKOILPM_UpdatedAt = JsonUtil.GetLong(jsonData["updated_at"]);
        tmp.MLGKDBJLNBM_DataStatus = (sbyte)JsonUtil.GetInt(jsonData["data_status"]);
        DLKLLHPLANH = false;
        if(IJMPLDBGMHC_OnDataReceived != null)
        {
            DLKLLHPLANH = !IJMPLDBGMHC_OnDataReceived(HHIHCJKLJFF_BlockToRequest, JsonUtil.GetObject(jsonData, "player"));
        }
        GC.Collect();
        NFEAMMJIMPG_Result = tmp;
    }
}
