using System;
using System.Text;

[System.Obsolete("Use BEEINMBNKNM_Encryption", true)]
public class BEEINMBNKNM {}
public class BEEINMBNKNM_Encryption
{
	public byte[] GPGMEAPLJAI_Key = new byte[1024]; // 0x8
	private uint KNEFBLHBDBG = 0x15ab17a1; // 0xC
	private uint PMBEODGMMBB_y = 0x15ab17a1; // 0x10
	private int GELENHPBKFA = 0x10000000; // 0x14 // GELENHPBKFA = 0x100000007; inversed ?
	private int DLDLDGJEOJG = 0x7; // 0x18
	private int PLNOOFNMHAL = 1; // 0x1C

	// RVA: 0xC73B0C Offset: 0xC73B0C VA: 0xC73B0C
	//private uint _FBGGEFFJJHB_xor() { }

	// RVA: 0xC73B28 Offset: 0xC73B28 VA: 0xC73B28
	public void KHEKNNFCAOI_Init(uint KNEFBLHBDBG)
	{
			this.KNEFBLHBDBG = KNEFBLHBDBG;
			PMBEODGMMBB_y = KNEFBLHBDBG;
			int i = 0;
			while(true)
			{
					uint a = KNEFBLHBDBG ^ (KNEFBLHBDBG << 0xd);
					a = a ^ a >> 0x11;
					a = a ^ a << 5;
					PMBEODGMMBB_y = a;
					if(GPGMEAPLJAI_Key.Length <= i)
							break;
					GPGMEAPLJAI_Key[i] = (byte)(a >> 3);
					if(i == 1023)
							return;
					i++;
					KNEFBLHBDBG = PMBEODGMMBB_y;
			}
	}

	// RVA: 0xC73BA8 Offset: 0xC73BA8 VA: 0xC73BA8
	public void AAGCKDHEMFD_GenerateKey()
	{ 
			uint i = 0;
			while(true)
			{
					uint a = PMBEODGMMBB_y;
					a = a ^ a << 0xd;
					a = a ^ a >> 0x11;
					a = a ^ a << 5;
					PMBEODGMMBB_y = a;
					if(GPGMEAPLJAI_Key.Length <= i)
							break;
					GPGMEAPLJAI_Key[i] = (byte)(a >> 3);
					i++;
					if(i == 1024)
							return;
			}
	}

	// RVA: 0xC73C18 Offset: 0xC73C18 VA: 0xC73C18
	private static /*extern*/ void FFPAGMCDALB(byte[] _CDENCMNHNGA_table, byte[] _DBBGALAPFGC_Data, int NFHFALDMGGC)
	{
			//TODO extract to lib file
			// Decrypt xedec
			uint offset = (uint)_DBBGALAPFGC_Data.Length;
			for(int i = 0; i < _DBBGALAPFGC_Data.Length; i++)
			{
				uint val = (uint)((offset << 3)&0xffffffff);
				offset = (uint)(val - offset);
				offset++;
				_DBBGALAPFGC_Data[i] = (byte)(_DBBGALAPFGC_Data[i] ^ _CDENCMNHNGA_table[offset%1024]);
			}
	}

	// RVA: 0xC73D28 Offset: 0xC73D28 VA: 0xC73D28
	//private static extern void MFKJIGBFJEN(IntPtr _CDENCMNHNGA_table, IntPtr _DBBGALAPFGC_Data, int NFHFALDMGGC) { }

	// RVA: 0xC73E34 Offset: 0xC73E34 VA: 0xC73E34
	//public void DMDLDOAOIAJ(byte[] _DBBGALAPFGC_Data) { }

	// RVA: 0xC70A18 Offset: 0xC70A18 VA: 0xC70A18
	public void CLNHGLGOKPF_Decrypt(byte[] _DBBGALAPFGC_Data)
	{
			FFPAGMCDALB(GPGMEAPLJAI_Key, _DBBGALAPFGC_Data, _DBBGALAPFGC_Data.Length);
	}

	// RVA: 0xC73ECC Offset: 0xC73ECC VA: 0xC73ECC
	//private int NEKCJNMGNID(int PKLPKMLGFGK) { }

	// RVA: 0xC73ED8 Offset: 0xC73ED8 VA: 0xC73ED8
	//public string AGKMBDIJHID(int _INDDJNMPONH_type) { }

	// RVA: 0xC73F54 Offset: 0xC73F54 VA: 0xC73F54
	public static uint GKBODMNBFJM(uint _IOIMHJAOKOO_Hash, byte[] _DBBGALAPFGC_Data)
	{
		return ANMDMMBEJPB(_IOIMHJAOKOO_Hash, _DBBGALAPFGC_Data, _DBBGALAPFGC_Data.Length);
	}

	// RVA: 0xC73FC8 Offset: 0xC73FC8 VA: 0xC73FC8
	private static /*extern*/ uint ANMDMMBEJPB(uint _IOIMHJAOKOO_Hash, /*IntPtr */byte[] _DBBGALAPFGC_Data, int NFHFALDMGGC)
	{
		// return xedec_hash(_IOIMHJAOKOO_Hash, DBBGALAPFGC_Data, NFHFALDMGGC);
		TodoLogger.LogError(TodoLogger.Xedec, "BEEINMBNKNM_Encryption.ANMDMMBEJPB xedec_hash");
		return 0;
	}

	// RVA: 0xC740D4 Offset: 0xC740D4 VA: 0xC740D4
	public static uint DIKDKNIKPNJ(uint _IOIMHJAOKOO_Hash, string _CJEKGLGBIHF_path)
	{
		return GKBODMNBFJM(_IOIMHJAOKOO_Hash, Encoding.UTF8.GetBytes(_CJEKGLGBIHF_path));
	}

	// RVA: 0xC74128 Offset: 0xC74128 VA: 0xC74128
	public void DGBPHDMEDNP(int _DHIPGHBJLIL_Coef, int _POMLAOPLMNA_offset, int DFIDIEENJAE)
	{
			GELENHPBKFA = _DHIPGHBJLIL_Coef;
			DLDLDGJEOJG = _POMLAOPLMNA_offset;
			PLNOOFNMHAL = DFIDIEENJAE;
	}

	// RVA: 0xC74134 Offset: 0xC74134 VA: 0xC74134
	public void LBGGPBBOIEH(byte[] _DBBGALAPFGC_Data)
	{ 
		int size = _DBBGALAPFGC_Data.Length;
		PMBEODGMMBB_y = KNEFBLHBDBG;
		if (size > 0)
		{
			uint q = (uint)(size / PLNOOFNMHAL);
			for (int i = 0; i < size; i++)
			{
				q = (uint)(q * GELENHPBKFA + DLDLDGJEOJG);
				_DBBGALAPFGC_Data[i] = (byte)(GPGMEAPLJAI_Key[q & 0x3ff] ^ _DBBGALAPFGC_Data[i]);
			}
		}
	}

	// RVA: 0xC74230 Offset: 0xC74230 VA: 0xC74230
	public void FAEFDAJAMCE(byte[] _DBBGALAPFGC_Data)
	{
		uint size = (uint)_DBBGALAPFGC_Data.Length;
		PMBEODGMMBB_y = KNEFBLHBDBG;
		if (size > 0)
		{
			uint q = (uint)(size / PLNOOFNMHAL);
			for (int i = 0; i < size; i++)
			{
				q = (uint)(q * GELENHPBKFA + DLDLDGJEOJG);
				_DBBGALAPFGC_Data[i] = (byte)(GPGMEAPLJAI_Key[q & 0x3ff] ^ _DBBGALAPFGC_Data[i]);
			}
		}
	}
}
