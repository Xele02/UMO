using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use DOLDMCAMEOD_RequestRemainingForCurrencyIds", true)]
public class DOLDMCAMEOD { }
public class DOLDMCAMEOD_RequestRemainingForCurrencyIds : CACGCMBKHDI_Request
{
    public class LDADODICMLG
    {
        public List<MCKCJMLOAFP> BBEPLKNMICJ; // 0x8

        // RVA: 0x1233554 Offset: 0x1233554 VA: 0x1233554
        // public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }
    }
    
	public List<int> CGCFENMHJIM; // 0x7C

	public LDADODICMLG NFEAMMJIMPG { get; private set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x1233364 Offset: 0x1233364 VA: 0x1233364 Slot: 12
	public override void DHLDNIEELHO()
    {
        TodoLogger.Log(0, "GetRemainingForCurrencyIds");
        DCKLDDCAJAP("{}");
        NFEAMMJIMPG = new LDADODICMLG();
        NFEAMMJIMPG.BBEPLKNMICJ = new List<MCKCJMLOAFP>();
    }

	// RVA: 0x1233474 Offset: 0x1233474 VA: 0x1233474 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        TodoLogger.Log(0, "GetRemainingForCurrencyIds response");
    }
}
