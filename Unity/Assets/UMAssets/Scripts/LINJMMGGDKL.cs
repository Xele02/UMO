
[System.Obsolete("Use LINJMMGGDKL_SecureInt2", true)]
public class LINJMMGGDKL { }
public class LINJMMGGDKL_SecureInt2
{
	private int IPKONDLIDHC; // 0x8
	private int ENOBDCFHELD; // 0xC
	private int DLHDPLPLCAC; // 0x10
	private int FCEJCHGLFGN; // 0x14
	public FENCAJJBLBH.EIAPDOGALDK KGICDMIJGDF = /*4*/FENCAJJBLBH.EIAPDOGALDK.PNLBHBFOECC_4; // 0x18
	public FENCAJJBLBH NMNHBJIAPGG; // 0x1C

	public int DNJEJEANJGL_Value { get { return ENOBDCFHELD ^ DLHDPLPLCAC; } set { 
		KPOCKNCJBPN_CheckSecure();
		DLHDPLPLCAC = ENOBDCFHELD ^ value;
		IPKONDLIDHC = FCEJCHGLFGN ^ value;
	} } //  JADLONAJDAK 0x1805374  JFNEHIGOBHH 0x1805384

	// // RVA: 0x1805488 Offset: 0x1805488 VA: 0x1805488
	public LINJMMGGDKL_SecureInt2()
	{
		IPKONDLIDHC = 0x3842df11; // Inversed ?
		ENOBDCFHELD = 0x17458e77;
		DLHDPLPLCAC = 0x17458e77; // Inversed ?
		FCEJCHGLFGN = 0x3842df11;
		NMNHBJIAPGG = null;
	}

	// // RVA: 0x18054D8 Offset: 0x18054D8 VA: 0x18054D8
	// public void LHPDDGIJKNB_Reset(int HBDLKOBJHFP, int LMJDJEACHBC) { }

	// // RVA: 0x18054F4 Offset: 0x18054F4 VA: 0x18054F4
	// public void DNBGDMBCLMI() { }

	// // RVA: 0x18053B4 Offset: 0x18053B4 VA: 0x18053B4
	public FENCAJJBLBH KPOCKNCJBPN_CheckSecure()
	{
		if(NMNHBJIAPGG == null)
		{
			if((ENOBDCFHELD ^ DLHDPLPLCAC) != (FCEJCHGLFGN ^ IPKONDLIDHC))
			{
				NMNHBJIAPGG = new FENCAJJBLBH(KGICDMIJGDF, 0, 0, "NetSecureValue2");
			}
		}
		return NMNHBJIAPGG;
	}
}
