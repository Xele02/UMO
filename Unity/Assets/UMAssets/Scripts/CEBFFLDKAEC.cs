
[System.Obsolete("Use CEBFFLDKAEC_SecureInt", true)]
public class CEBFFLDKAEC { }
public class CEBFFLDKAEC_SecureInt
{
	private int IPKONDLIDHC; // 0x8
	private int ENOBDCFHELD; // 0xC
	private int DLHDPLPLCAC; // 0x10
	private int FCEJCHGLFGN; // 0x14
	public FENCAJJBLBH.EIAPDOGALDK KGICDMIJGDF = FENCAJJBLBH.EIAPDOGALDK.PNLBHBFOECC/*4*/; // 0x18
	public FENCAJJBLBH NMNHBJIAPGG; // 0x1C

	public int DNJEJEANJGL_Value { get{
		// JADLONAJDAK 0x12B124C
        return ENOBDCFHELD ^ DLHDPLPLCAC;
	} set {
		// JFNEHIGOBHH 0x12B125C
        KPOCKNCJBPN_CheckSecure();
		DLHDPLPLCAC = ENOBDCFHELD ^ value;
		IPKONDLIDHC = FCEJCHGLFGN ^ value;
	} }   

	// // RVA: 0x12B1360 Offset: 0x12B1360 VA: 0x12B1360
	public CEBFFLDKAEC_SecureInt() 
	{
		IPKONDLIDHC = 0x5892df17; // can be inversed
		ENOBDCFHELD = 0x17854e73;
		DLHDPLPLCAC = 0x17854e73; // can be inversed
		FCEJCHGLFGN = 0x5892df17;
		NMNHBJIAPGG = null;
	}

	// // RVA: 0x12B13B0 Offset: 0x12B13B0 VA: 0x12B13B0
	// public void LHPDDGIJKNB_Reset(int HBDLKOBJHFP, int LMJDJEACHBC) { }

	// // RVA: 0x12B13CC Offset: 0x12B13CC VA: 0x12B13CC
	// public void DNBGDMBCLMI() { }

	// // RVA: 0x12B128C Offset: 0x12B128C VA: 0x12B128C
	public FENCAJJBLBH KPOCKNCJBPN_CheckSecure() 
	{ 
		if(NMNHBJIAPGG == null)
		{
			if((ENOBDCFHELD ^ DLHDPLPLCAC) != (FCEJCHGLFGN ^ IPKONDLIDHC))
			{
				NMNHBJIAPGG = new FENCAJJBLBH(KGICDMIJGDF, 0, 0, "NetSecureValue");
			}
		}
		return NMNHBJIAPGG;
	}
}
