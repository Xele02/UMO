
[System.Obsolete("Use KCKKMNOELLB_SecureLong", true)]
public class KCKKMNOELLB {}
public class KCKKMNOELLB_SecureLong
{
	private long IPKONDLIDHC; // 0x8
	private int ENOBDCFHELD; // 0x10
	private long DLHDPLPLCAC; // 0x18
	private int FCEJCHGLFGN; // 0x20
	public FENCAJJBLBH.EIAPDOGALDK KGICDMIJGDF_Group = FENCAJJBLBH.EIAPDOGALDK.PNLBHBFOECC_4; // 0x24
	public FENCAJJBLBH NMNHBJIAPGG_CheckFalsification; // 0x28

	public long DNJEJEANJGL_Value { get { return DLHDPLPLCAC ^ ENOBDCFHELD; } set
    {
        KPOCKNCJBPN();
        DLHDPLPLCAC = ENOBDCFHELD ^ value;
        IPKONDLIDHC = FCEJCHGLFGN ^ value;
    } } //0x1021F40 JADLONAJDAK 0x1021F58 JFNEHIGOBHH

	// RVA: 0x1022080 Offset: 0x1022080 VA: 0x1022080
	public KCKKMNOELLB_SecureLong()
    {
        FCEJCHGLFGN = 0x17854e73;
        ENOBDCFHELD = 0x5892df17;
        DLHDPLPLCAC = 0x5892df17;
        IPKONDLIDHC = 0x17854e73;
        NMNHBJIAPGG_CheckFalsification = null;
    }

	// // RVA: 0x10220D4 Offset: 0x10220D4 VA: 0x10220D4
	public void LHPDDGIJKNB_Reset(int HBDLKOBJHFP, int LMJDJEACHBC)
    {
        NMNHBJIAPGG_CheckFalsification = null;
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
        if(NMNHBJIAPGG_CheckFalsification == null)
        {
            if((DLHDPLPLCAC ^ ENOBDCFHELD) != (IPKONDLIDHC ^ FCEJCHGLFGN))
            {
                NMNHBJIAPGG_CheckFalsification = new FENCAJJBLBH(KGICDMIJGDF_Group, 0, 0, "NetSecureLong");
            }
        }
        return NMNHBJIAPGG_CheckFalsification;
    }
}
