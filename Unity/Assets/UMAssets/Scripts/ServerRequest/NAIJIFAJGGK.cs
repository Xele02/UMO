using System.Collections.Generic;
using UnityEngine;
using System;
using XeSys;

public delegate bool LDDPADICHHB(List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _NMICBJDPLOH_player);

[System.Obsolete("Use NAIJIFAJGGK_RequestLoadPlayerData", true)]
public class NAIJIFAJGGK { }
public class NAIJIFAJGGK_RequestLoadPlayerData : CACGCMBKHDI_Request
{
    public class PHAKFFBNNEI_PlayerDataResult
    {
        public long BIOGKIEECGN_created_at; // 0x8
        public long IFNLEKOILPM_updated_at; // 0x10
        public int CEMEIPNMAAD_Version; // 0x18
        public sbyte MLGKDBJLNBM_data_status; // 0x1C
        public bool PLEAGPCJICK; // 0x1D
    }

	public List<string> HHIHCJKLJFF_Names { get; set; } // 0x7C OHINHCAEFDJ_bgs AOELBKNHIMG_bgs HGAICKPMCCB_bgs
	public LDDPADICHHB IJMPLDBGMHC_OnDataReceived { get; set; } // 0x80 LKIBOJLDBHM_bgs DCNBDAGBCPB_bgs LGLGACHHDGK_bgs
	public PHAKFFBNNEI_PlayerDataResult NFEAMMJIMPG_Result { get; private set; } // 0x84 OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs
	public override bool EBPLLJGPFDA_HasResult { get {
        return NFEAMMJIMPG_Result != null;
        } } // 0x17C031C HGPAELCGELL_bgs

	// // RVA: 0x17C0084 Offset: 0x17C0084 VA: 0x17C0084
	public NAIJIFAJGGK_RequestLoadPlayerData()
    {
        ICDEFIIADDO_Timeout = 30.0f;
    }

	// // RVA: 0x17C0114 Offset: 0x17C0114 VA: 0x17C0114 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoPlayerData.LoadPlayerData(HHIHCJKLJFF_Names.ToArray(), this.DCKLDDCAJAP, this.MEOCKCJBDAD);
    }

	// // RVA: 0x17C0260 Offset: 0x17C0260 VA: 0x17C0260 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
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
        tmp.BIOGKIEECGN_created_at = JsonUtil.GetLong(jsonData["created_at"]);
        tmp.IFNLEKOILPM_updated_at = JsonUtil.GetLong(jsonData["updated_at"]);
        tmp.MLGKDBJLNBM_data_status = (sbyte)JsonUtil.GetInt(jsonData["data_status"]);
        DLKLLHPLANH = false;
        if(IJMPLDBGMHC_OnDataReceived != null)
        {
            DLKLLHPLANH = !IJMPLDBGMHC_OnDataReceived(HHIHCJKLJFF_Names, JsonUtil.GetObject(jsonData, "player"));
        }
        GC.Collect();
        NFEAMMJIMPG_Result = tmp;
    }
}
