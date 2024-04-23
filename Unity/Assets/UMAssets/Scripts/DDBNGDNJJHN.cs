
using System;

[System.Obsolete("Use DDBNGDNJJHN_SecureFloat", true)]
public class DDBNGDNJJHN { }
public class DDBNGDNJJHN_SecureFloat
{
	private int FCEJCHGLFGN; // 0x8
	private byte[] IPKONDLIDHC = new byte[4]; // 0xC
	private byte[] DLHDPLPLCAC = new byte[4]; // 0x10
	private byte[] CKHLHOFMIPC_WorkBuffer = new byte[4]; // 0x14
	private int ENOBDCFHELD; // 0x18
	public FENCAJJBLBH.EIAPDOGALDK KGICDMIJGDF = FENCAJJBLBH.EIAPDOGALDK.PNLBHBFOECC_4/*4*/; // 0x1C
	public FENCAJJBLBH NMNHBJIAPGG; // 0x20

	public float DNJEJEANJGL_Value
	{
		get
		{
			CKHLHOFMIPC_WorkBuffer[0] = (byte)(ENOBDCFHELD ^ DLHDPLPLCAC[0]);
			CKHLHOFMIPC_WorkBuffer[1] = (byte)(ENOBDCFHELD ^ DLHDPLPLCAC[3]);
			CKHLHOFMIPC_WorkBuffer[2] = (byte)(ENOBDCFHELD ^ DLHDPLPLCAC[2]);
			CKHLHOFMIPC_WorkBuffer[3] = (byte)(ENOBDCFHELD ^ DLHDPLPLCAC[1]);
			return BitConverter.ToSingle(CKHLHOFMIPC_WorkBuffer, 0);
		} // 0x1770E20  JADLONAJDAK
		set
		{
			KPOCKNCJBPN_CheckSecure();
			byte[] b = BitConverter.GetBytes(value);
			DLHDPLPLCAC[0] = (byte)(ENOBDCFHELD ^ b[0]);
			DLHDPLPLCAC[1] = (byte)(ENOBDCFHELD ^ b[3]);
			DLHDPLPLCAC[2] = (byte)(ENOBDCFHELD ^ b[2]);
			DLHDPLPLCAC[3] = (byte)(ENOBDCFHELD ^ b[1]);
			IPKONDLIDHC[0] = (byte)(FCEJCHGLFGN ^ b[0]);
			IPKONDLIDHC[1] = (byte)(FCEJCHGLFGN ^ b[3]);
			IPKONDLIDHC[2] = (byte)(FCEJCHGLFGN ^ b[2]);
			IPKONDLIDHC[3] = (byte)(FCEJCHGLFGN ^ b[1]);
		} //0x177106C  JFNEHIGOBHH
	}

	//// RVA: 0x17716F4 Offset: 0x17716F4 VA: 0x17716F4
	public DDBNGDNJJHN_SecureFloat()
	{
		FCEJCHGLFGN = 0x17458e72;
		ENOBDCFHELD = 0x3842df11;
		byte[] b = BitConverter.GetBytes(0);
		DLHDPLPLCAC[0] = (byte)(ENOBDCFHELD ^ b[0]);
		DLHDPLPLCAC[1] = (byte)(ENOBDCFHELD ^ b[3]);
		DLHDPLPLCAC[2] = (byte)(ENOBDCFHELD ^ b[2]);
		DLHDPLPLCAC[3] = (byte)(ENOBDCFHELD ^ b[1]);
		IPKONDLIDHC[0] = (byte)(FCEJCHGLFGN ^ b[0]);
		IPKONDLIDHC[1] = (byte)(FCEJCHGLFGN ^ b[3]);
		IPKONDLIDHC[2] = (byte)(FCEJCHGLFGN ^ b[2]);
		IPKONDLIDHC[3] = (byte)(FCEJCHGLFGN ^ b[1]);
	}

	//// RVA: 0x1771AD4 Offset: 0x1771AD4 VA: 0x1771AD4
	//public void LHPDDGIJKNB(int HBDLKOBJHFP, int LMJDJEACHBC) { }

	//// RVA: 0x1771AFC Offset: 0x1771AFC VA: 0x1771AFC
	//public void DNBGDMBCLMI() { }

	//// RVA: 0x17713F0 Offset: 0x17713F0 VA: 0x17713F0
	public FENCAJJBLBH KPOCKNCJBPN_CheckSecure()
	{
		if(NMNHBJIAPGG == null)
		{
			if ((byte)(DLHDPLPLCAC[0] ^ ENOBDCFHELD) == (byte)(IPKONDLIDHC[0] ^ FCEJCHGLFGN) &&
				(byte)(DLHDPLPLCAC[1] ^ ENOBDCFHELD) == (byte)(IPKONDLIDHC[1] ^ FCEJCHGLFGN) &&
				(byte)(DLHDPLPLCAC[2] ^ ENOBDCFHELD) == (byte)(IPKONDLIDHC[2] ^ FCEJCHGLFGN) &&
				(byte)(DLHDPLPLCAC[3] ^ ENOBDCFHELD) == (byte)(IPKONDLIDHC[3] ^ FCEJCHGLFGN))
				return null;
			NMNHBJIAPGG = new FENCAJJBLBH(KGICDMIJGDF, 0, 0, "NetSecureFloat");
		}
		return NMNHBJIAPGG;
	}
}
