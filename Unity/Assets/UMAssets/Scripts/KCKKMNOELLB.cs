
[System.Obsolete("Use KCKKMNOELLB_SecureLong", true)]
public class KCKKMNOELLB {}
public class KCKKMNOELLB_SecureLong
{
	private long IPKONDLIDHC; // 0x8
	private int ENOBDCFHELD; // 0x10
	private long DLHDPLPLCAC; // 0x18
	private int FCEJCHGLFGN; // 0x20
	public FENCAJJBLBH.EIAPDOGALDK KGICDMIJGDF = FENCAJJBLBH.EIAPDOGALDK.PNLBHBFOECC_4; // 0x24
	public FENCAJJBLBH NMNHBJIAPGG; // 0x28

	public long DNJEJEANJGL { get; set; }

	// RVA: 0x1021F40 Offset: 0x1021F40 VA: 0x1021F40
	public long JADLONAJDAK_GetValue()
    {
        return DLHDPLPLCAC ^ ENOBDCFHELD;
    }

	// // RVA: 0x1021F58 Offset: 0x1021F58 VA: 0x1021F58
	public void JFNEHIGOBHH_SetValue(long NANNGLGOFKH)
    {
        KPOCKNCJBPN();
        DLHDPLPLCAC = ENOBDCFHELD ^ NANNGLGOFKH;
        IPKONDLIDHC = FCEJCHGLFGN ^ NANNGLGOFKH;
    }

	// RVA: 0x1022080 Offset: 0x1022080 VA: 0x1022080
	public KCKKMNOELLB_SecureLong()
    {
        FCEJCHGLFGN = 0x17854e73;
        ENOBDCFHELD = 0x5892df17;
        DLHDPLPLCAC = 0x5892df17;
        IPKONDLIDHC = 0x17854e73;
        NMNHBJIAPGG = null;
    }

	// // RVA: 0x10220D4 Offset: 0x10220D4 VA: 0x10220D4
	public void LHPDDGIJKNB_Reset(int HBDLKOBJHFP, int LMJDJEACHBC)
    {
        NMNHBJIAPGG = null;
        DLHDPLPLCAC = HBDLKOBJHFP;
        FCEJCHGLFGN = LMJDJEACHBC;
        IPKONDLIDHC = LMJDJEACHBC;
        ENOBDCFHELD = HBDLKOBJHFP;
    }

	// // RVA: 0x1022100 Offset: 0x1022100 VA: 0x1022100
	// public void DNBGDMBCLMI() { }

	// // RVA: 0x1021F94 Offset: 0x1021F94 VA: 0x1021F94
	public FENCAJJBLBH KPOCKNCJBPN()
    {
        if(NMNHBJIAPGG == null)
        {
            if((DLHDPLPLCAC ^ ENOBDCFHELD) != (IPKONDLIDHC ^ FCEJCHGLFGN))
            {
                NMNHBJIAPGG = new FENCAJJBLBH(KGICDMIJGDF, 0, 0, "NetSecureLong");
            }
        }
        return NMNHBJIAPGG;
    }
}
