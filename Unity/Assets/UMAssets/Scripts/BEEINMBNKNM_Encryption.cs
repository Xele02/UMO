using System;
using System.Text;

[System.Obsolete("Use BEEINMBNKNM_Encryption", true)]
public class BEEINMBNKNM {}
public class BEEINMBNKNM_Encryption
{
	public byte[] GPGMEAPLJAI_Key = new byte[1024]; // 0x8
	private uint KNEFBLHBDBG = 0x15ab17a1; // 0xC
	private uint PMBEODGMMBB = 0x15ab17a1; // 0x10
	private int GELENHPBKFA = 0x10000000; // 0x14 // GELENHPBKFA = 0x100000007; inversed ?
	private int DLDLDGJEOJG = 0x7; // 0x18
	private int PLNOOFNMHAL = 1; // 0x1C

	// RVA: 0xC73B0C Offset: 0xC73B0C VA: 0xC73B0C
	//private uint FBGGEFFJJHB() { }

	// RVA: 0xC73B28 Offset: 0xC73B28 VA: 0xC73B28
	public void KHEKNNFCAOI_Init(uint KNEFBLHBDBG)
	{
			this.KNEFBLHBDBG = KNEFBLHBDBG;
			PMBEODGMMBB = KNEFBLHBDBG;
			int i = 0;
			while(true)
			{
					uint a = KNEFBLHBDBG ^ (KNEFBLHBDBG << 0xd);
					a = a ^ a >> 0x11;
					a = a ^ a << 5;
					PMBEODGMMBB = a;
					if(GPGMEAPLJAI_Key.Length <= i)
							break;
					GPGMEAPLJAI_Key[i] = (byte)(a >> 3);
					if(i == 1023)
							return;
					i++;
					KNEFBLHBDBG = PMBEODGMMBB;
			}
	}

	// RVA: 0xC73BA8 Offset: 0xC73BA8 VA: 0xC73BA8
	public void AAGCKDHEMFD_GenerateKey()
	{ 
			uint i = 0;
			while(true)
			{
					uint a = PMBEODGMMBB;
					a = a ^ a << 0xd;
					a = a ^ a >> 0x11;
					a = a ^ a << 5;
					PMBEODGMMBB = a;
					if(GPGMEAPLJAI_Key.Length <= i)
							break;
					GPGMEAPLJAI_Key[i] = (byte)(a >> 3);
					i++;
					if(i == 1024)
							return;
			}
	}

	// RVA: 0xC73C18 Offset: 0xC73C18 VA: 0xC73C18
	private static /*extern*/ void FFPAGMCDALB(byte[] CDENCMNHNGA, byte[] DBBGALAPFGC, int NFHFALDMGGC)
	{
			//TODO extract to lib file
			// Decrypt xedec
			uint offset = (uint)DBBGALAPFGC.Length;
			for(int i = 0; i < DBBGALAPFGC.Length; i++)
			{
				uint val = (uint)((offset << 3)&0xffffffff);
				offset = (uint)(val - offset);
				offset++;
				DBBGALAPFGC[i] = (byte)(DBBGALAPFGC[i] ^ CDENCMNHNGA[offset%1024]);
			}
	}

	// RVA: 0xC73D28 Offset: 0xC73D28 VA: 0xC73D28
	//private static extern void MFKJIGBFJEN(IntPtr CDENCMNHNGA, IntPtr DBBGALAPFGC, int NFHFALDMGGC) { }

	// RVA: 0xC73E34 Offset: 0xC73E34 VA: 0xC73E34
	//public void DMDLDOAOIAJ(byte[] DBBGALAPFGC) { }

	// RVA: 0xC70A18 Offset: 0xC70A18 VA: 0xC70A18
	public void CLNHGLGOKPF_Decrypt(byte[] DBBGALAPFGC)
	{
			FFPAGMCDALB(GPGMEAPLJAI_Key, DBBGALAPFGC, DBBGALAPFGC.Length);
	}

	// RVA: 0xC73ECC Offset: 0xC73ECC VA: 0xC73ECC
	//private int NEKCJNMGNID(int PKLPKMLGFGK) { }

	// RVA: 0xC73ED8 Offset: 0xC73ED8 VA: 0xC73ED8
	//public string AGKMBDIJHID(int INDDJNMPONH) { }

	// RVA: 0xC73F54 Offset: 0xC73F54 VA: 0xC73F54
	public static uint GKBODMNBFJM(uint IOIMHJAOKOO, byte[] DBBGALAPFGC)
	{
		return ANMDMMBEJPB(IOIMHJAOKOO, DBBGALAPFGC, DBBGALAPFGC.Length);
	}

	// RVA: 0xC73FC8 Offset: 0xC73FC8 VA: 0xC73FC8
	private static /*extern*/ uint ANMDMMBEJPB(uint IOIMHJAOKOO, /*IntPtr */byte[] DBBGALAPFGC, int NFHFALDMGGC)
	{
		// return xedec_hash(IOIMHJAOKOO, DBBGALAPFGC, NFHFALDMGGC);
		TodoLogger.Log(TodoLogger.Xedec, "BEEINMBNKNM_Encryption.ANMDMMBEJPB xedec_hash");
		return 0;
	}

	// RVA: 0xC740D4 Offset: 0xC740D4 VA: 0xC740D4
	public static uint DIKDKNIKPNJ(uint IOIMHJAOKOO, string CJEKGLGBIHF_path)
	{
		return GKBODMNBFJM(IOIMHJAOKOO, Encoding.UTF8.GetBytes(CJEKGLGBIHF_path));
	}

	// RVA: 0xC74128 Offset: 0xC74128 VA: 0xC74128
	public void DGBPHDMEDNP(int DHIPGHBJLIL, int POMLAOPLMNA, int DFIDIEENJAE)
	{
			GELENHPBKFA = DHIPGHBJLIL;
			DLDLDGJEOJG = POMLAOPLMNA;
			PLNOOFNMHAL = DFIDIEENJAE;
	}

	// RVA: 0xC74134 Offset: 0xC74134 VA: 0xC74134
	public void LBGGPBBOIEH(byte[] DBBGALAPFGC)
	{ 
		int size = DBBGALAPFGC.Length;
		PMBEODGMMBB = KNEFBLHBDBG;
		if (size > 0)
		{
			uint q = (uint)(size / PLNOOFNMHAL);
			for (int i = 0; i < size; i++)
			{
				q = (uint)(q * GELENHPBKFA + DLDLDGJEOJG);
				DBBGALAPFGC[i] = (byte)(GPGMEAPLJAI_Key[q & 0x3ff] ^ DBBGALAPFGC[i]);
			}
		}
	}

	// RVA: 0xC74230 Offset: 0xC74230 VA: 0xC74230
	public void FAEFDAJAMCE(byte[] DBBGALAPFGC)
	{
		uint size = (uint)DBBGALAPFGC.Length;
		PMBEODGMMBB = KNEFBLHBDBG;
		if (size > 0)
		{
			uint q = (uint)(size / PLNOOFNMHAL);
			for (int i = 0; i < size; i++)
			{
				q = (uint)(q * GELENHPBKFA + DLDLDGJEOJG);
				DBBGALAPFGC[i] = (byte)(GPGMEAPLJAI_Key[q & 0x3ff] ^ DBBGALAPFGC[i]);
			}
		}
	}
}
