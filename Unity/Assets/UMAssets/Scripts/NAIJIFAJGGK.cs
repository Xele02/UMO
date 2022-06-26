using System.Collections.Generic;
using UnityEngine;
using System;
using XeSys;

public delegate bool LDDPADICHHB(List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData NMICBJDPLOH);

public class NAIJIFAJGGK : CACGCMBKHDI_Request
{
    public class PHAKFFBNNEI
    {
        public long BIOGKIEECGN_CreatedAt; // 0x8
        public long IFNLEKOILPM_UpdatedAt; // 0x10
        public int CEMEIPNMAAD; // 0x18
        public sbyte MLGKDBJLNBM_DataStatus; // 0x1C
        public bool PLEAGPCJICK; // 0x1D
    }

	public List<string> HHIHCJKLJFF { get; set; } // 0x7C OHINHCAEFDJ AOELBKNHIMG HGAICKPMCCB
	public LDDPADICHHB IJMPLDBGMHC { get; set; } // 0x80 LKIBOJLDBHM DCNBDAGBCPB LGLGACHHDGK
	public NAIJIFAJGGK.PHAKFFBNNEI NFEAMMJIMPG { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA { get {
        return NFEAMMJIMPG != null;
        } } // 0x17C031C HGPAELCGELL

	// // RVA: 0x17C0084 Offset: 0x17C0084 VA: 0x17C0084
	public NAIJIFAJGGK()
    {
        ICDEFIIADDO_Timeout = 30.0f;
    }

	// // RVA: 0x17C0114 Offset: 0x17C0114 VA: 0x17C0114 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA = SakashoPlayerData.LoadPlayerData(HHIHCJKLJFF.ToArray(), this.DCKLDDCAJAP, this.MEOCKCJBDAD);
    }

	// // RVA: 0x17C0260 Offset: 0x17C0260 VA: 0x17C0260 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = null;
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
        NFEAMMJIMPG = new NAIJIFAJGGK.PHAKFFBNNEI();
        EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
        NFEAMMJIMPG.BIOGKIEECGN_CreatedAt = JsonUtil.GetLong(jsonData["created_at"]);
        NFEAMMJIMPG.IFNLEKOILPM_UpdatedAt = JsonUtil.GetLong(jsonData["updated_at"]);
        NFEAMMJIMPG.MLGKDBJLNBM_DataStatus = (sbyte)JsonUtil.GetInt(jsonData["data_status"]);
        DLKLLHPLANH = false;
        if(IJMPLDBGMHC != null)
        {
            DLKLLHPLANH = !IJMPLDBGMHC(HHIHCJKLJFF, JsonUtil.GetObject(jsonData, "player"));
        }
        GC.Collect();
    }
}