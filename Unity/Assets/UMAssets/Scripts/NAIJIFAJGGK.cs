using System.Collections.Generic;
using UnityEngine;

public delegate bool LDDPADICHHB(List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData NMICBJDPLOH);

public class NAIJIFAJGGK : CACGCMBKHDI_Request
{
    public class PHAKFFBNNEI
    {
        public long BIOGKIEECGN; // 0x8
        public long IFNLEKOILPM; // 0x10
        public int CEMEIPNMAAD; // 0x18
        public sbyte MLGKDBJLNBM; // 0x1C
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
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0x17C0260 Offset: 0x17C0260 VA: 0x17C0260 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0x17C032C Offset: 0x17C032C VA: 0x17C032C Slot: 15
	public override void NLDKLFODOJJ()
    {
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0x17C0330 Offset: 0x17C0330 VA: 0x17C0330
	// private void DIAMDBHBKBH() { }
}