using System;

/// <summary>
/// Class to mimic Java's ByteBuffer which is used heavily in Flatbuffers.
/// If your execution environment allows unsafe code, you should enable
/// unsafe code in your project and #define UNSAFE_BYTEBUFFER to use a
/// MUCH faster version of ByteBuffer.
/// </summary>
public class JMPAJDKFFGL_ByteBuffer
{
	private readonly byte[] LDALAFIJKKM__buffer; // 0x8
	private int LGEDAJAFHGG__pos; // 0xC   // Must track start of the buffer.
    
	// Pre-allocated helper arrays for convertion.
	private float[] IDLHFHDIDEI_floathelper = new[] { 0.0f }; // 0x10
	private int[] GNMCIEKCKCA_inthelper = new[] { 0 }; // 0x14
	private double[] KHCECGMODOC_doublehelper = new[] { 0.0 }; // 0x18
	private ulong[] MFAJHCGLKBI_ulonghelper = new[] { 0UL }; // 0x1C

	public int FONPCFFGPBK_Length { get { return LDALAFIJKKM__buffer.Length; } } // MAOEJMHCFIK
	public byte[] KOJCDOJALDM_Data { get { return LDALAFIJKKM__buffer; } } // ODKCGOOJDJF
	public int MJANLLHCFBL_Position 
	{
		get { return LGEDAJAFHGG__pos; }
		set { LGEDAJAFHGG__pos = value; }
	} // PJKENMHKHCM // GGFHFCCNGOC

	public JMPAJDKFFGL_ByteBuffer(byte[] KNOAHOEKBPN_buffer) : this(KNOAHOEKBPN_buffer, 0)
	{
		
	}
	
	public JMPAJDKFFGL_ByteBuffer(byte[] KNOAHOEKBPN_buffer, int NDFOAINJPIN_pos)
	{
		LDALAFIJKKM__buffer = KNOAHOEKBPN_buffer;
		LGEDAJAFHGG__pos = NDFOAINJPIN_pos;
	}

	public void LHPDDGIJKNB_Reset()
	{
		LGEDAJAFHGG__pos = 0;
	}
	
	// Helper functions for the unsafe version.
	public static ushort IEOBOLDMIOM_ReverseBytes(ushort BJKEOACPMHB_input)
	{
		return (ushort)(((BJKEOACPMHB_input & 0x00FFU) << 8) |
						((BJKEOACPMHB_input & 0xFF00U) >> 8));
	}
	public static uint IEOBOLDMIOM_ReverseBytes(uint BJKEOACPMHB_input)
	{
		return ((BJKEOACPMHB_input & 0x000000FFU) << 24) |
				((BJKEOACPMHB_input & 0x0000FF00U) <<  8) |
				((BJKEOACPMHB_input & 0x00FF0000U) >>  8) |
				((BJKEOACPMHB_input & 0xFF000000U) >> 24);
	}
	public static ulong IEOBOLDMIOM_ReverseBytes(ulong BJKEOACPMHB_input)
	{
		return (((BJKEOACPMHB_input & 0x00000000000000FFUL) << 56) |
				((BJKEOACPMHB_input & 0x000000000000FF00UL) << 40) |
				((BJKEOACPMHB_input & 0x0000000000FF0000UL) << 24) |
				((BJKEOACPMHB_input & 0x00000000FF000000UL) <<  8) |
				((BJKEOACPMHB_input & 0x000000FF00000000UL) >>  8) |
				((BJKEOACPMHB_input & 0x0000FF0000000000UL) >> 24) |
				((BJKEOACPMHB_input & 0x00FF000000000000UL) >> 40) |
				((BJKEOACPMHB_input & 0xFF00000000000000UL) >> 56));
	}

	// Helper functions for the safe (but slower) version.
	protected void PLIFKACFGJF_WriteLittleEndian(int POMLAOPLMNA_offset, int HMFFHLPNMPH_count, ulong IDLHJIOMJBK_data)
	{
		if (BitConverter.IsLittleEndian)
		{
			for (int i = 0; i < HMFFHLPNMPH_count; i++)
			{
				LDALAFIJKKM__buffer[POMLAOPLMNA_offset + i] = (byte)(IDLHJIOMJBK_data >> i * 8);
			}
		}
		else
		{
			for (int i = 0; i < HMFFHLPNMPH_count; i++)
			{
				LDALAFIJKKM__buffer[POMLAOPLMNA_offset + HMFFHLPNMPH_count - 1 - i] = (byte)(IDLHJIOMJBK_data >> i * 8);
			}
		}
	}

	protected ulong KCFGIBGNPLO_ReadLittleEndian(int POMLAOPLMNA_offset, int HMFFHLPNMPH_count)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, HMFFHLPNMPH_count);
		ulong r = 0;
		if (BitConverter.IsLittleEndian)
		{
			for (int i = 0; i < HMFFHLPNMPH_count; i++)
			{
				r |= (ulong)LDALAFIJKKM__buffer[POMLAOPLMNA_offset + i] << i * 8;
			}
		}
		else
		{
			for (int i = 0; i < HMFFHLPNMPH_count; i++)
			{
			r |= (ulong)LDALAFIJKKM__buffer[POMLAOPLMNA_offset + HMFFHLPNMPH_count - 1 - i] << i * 8;
			}
		}
		return r;
	}

	private void EPMMKJFEMOB_AssertOffsetAndLength(int POMLAOPLMNA_offset, int MCMIPODICAN_length)
	{
		if (POMLAOPLMNA_offset < 0 ||
			POMLAOPLMNA_offset > LDALAFIJKKM__buffer.Length - MCMIPODICAN_length)
			throw new ArgumentOutOfRangeException();
	}

	public void FOJBKBDDNJB_PutSbyte(int POMLAOPLMNA_offset, sbyte NANNGLGOFKH_value)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(sbyte));
		LDALAFIJKKM__buffer[POMLAOPLMNA_offset] = (byte)NANNGLGOFKH_value;
	}

	public void FNGDPJJMDHH_PutByte(int POMLAOPLMNA_offset, byte NANNGLGOFKH_value)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(byte));
		LDALAFIJKKM__buffer[POMLAOPLMNA_offset] = NANNGLGOFKH_value;
	}

	public void FNGDPJJMDHH_PutByte(int POMLAOPLMNA_offset, byte NANNGLGOFKH_value, int HMFFHLPNMPH_count)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(byte) * HMFFHLPNMPH_count);
		for (var i = 0; i < HMFFHLPNMPH_count; ++i)
			LDALAFIJKKM__buffer[POMLAOPLMNA_offset + i] = NANNGLGOFKH_value;
	}

    // this method exists in order to conform with Java ByteBuffer standards
	public void LECLCEJCMIK_Put(int POMLAOPLMNA_offset, byte NANNGLGOFKH_value)
	{
		FNGDPJJMDHH_PutByte(POMLAOPLMNA_offset, NANNGLGOFKH_value);
	}

    // Slower versions of Put* for when unsafe code is not allowed.
	public void LMOOMGJOAGA_PutShort(int POMLAOPLMNA_offset, short NANNGLGOFKH_value)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(short));
		PLIFKACFGJF_WriteLittleEndian(POMLAOPLMNA_offset, sizeof(short), (ulong)NANNGLGOFKH_value);
	}
	
	public void LLGCDOILPOE_PutUshort(int POMLAOPLMNA_offset, ushort NANNGLGOFKH_value)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(ushort));
		PLIFKACFGJF_WriteLittleEndian(POMLAOPLMNA_offset, sizeof(ushort), (ulong)NANNGLGOFKH_value);
	}

	public void IFHOMMKPAIE_PutInt(int POMLAOPLMNA_offset, int NANNGLGOFKH_value)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(int));
		PLIFKACFGJF_WriteLittleEndian(POMLAOPLMNA_offset, sizeof(int), (ulong)NANNGLGOFKH_value);
	}

	public void EEDJAOFJFKB_PutUint(int POMLAOPLMNA_offset, uint NANNGLGOFKH_value)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(uint));
		PLIFKACFGJF_WriteLittleEndian(POMLAOPLMNA_offset, sizeof(uint), (ulong)NANNGLGOFKH_value);
	}
	
	public void LAHABNLFINP_PutLong(int POMLAOPLMNA_offset, long NANNGLGOFKH_value)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(long));
		PLIFKACFGJF_WriteLittleEndian(POMLAOPLMNA_offset, sizeof(long), (ulong)NANNGLGOFKH_value);
	}

	public void JLGNNCCEEEO_PutUlong(int POMLAOPLMNA_offset, ulong NANNGLGOFKH_value)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(ulong));
		PLIFKACFGJF_WriteLittleEndian(POMLAOPLMNA_offset, sizeof(ulong), NANNGLGOFKH_value);
	}

	public void HOPAHGDHCEG_PutFloat(int POMLAOPLMNA_offset, float NANNGLGOFKH_value)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(float));
		IDLHFHDIDEI_floathelper[0] = NANNGLGOFKH_value;
		Buffer.BlockCopy(IDLHFHDIDEI_floathelper, 0, GNMCIEKCKCA_inthelper, 0, sizeof(float));
		PLIFKACFGJF_WriteLittleEndian(POMLAOPLMNA_offset, sizeof(float), (ulong)GNMCIEKCKCA_inthelper[0]);
	}

	public void FLGPOMLGAOL_PutDouble(int POMLAOPLMNA_offset, double NANNGLGOFKH_value)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(POMLAOPLMNA_offset, sizeof(double));
		KHCECGMODOC_doublehelper[0] = NANNGLGOFKH_value;
		Buffer.BlockCopy(KHCECGMODOC_doublehelper, 0, MFAJHCGLKBI_ulonghelper, 0, sizeof(double));
		PLIFKACFGJF_WriteLittleEndian(POMLAOPLMNA_offset, sizeof(double), MFAJHCGLKBI_ulonghelper[0]);
	}

	public sbyte NEALHNAHHKM_GetSbyte(int OIPCCBHIKIA_index)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(OIPCCBHIKIA_index, sizeof(sbyte));
		return (sbyte)LDALAFIJKKM__buffer[OIPCCBHIKIA_index];
	}
	
	public byte GCINIJEMHFK_Get(int OIPCCBHIKIA_index)
	{
		EPMMKJFEMOB_AssertOffsetAndLength(OIPCCBHIKIA_index, sizeof(byte));
		return LDALAFIJKKM__buffer[OIPCCBHIKIA_index];
	}
	
	// Slower versions of Get* for when unsafe code is not allowed.
	public short IJIFMEMHIPA_GetShort(int OIPCCBHIKIA_index)
	{
		return (short)KCFGIBGNPLO_ReadLittleEndian(OIPCCBHIKIA_index, sizeof(short));
	}

	public ushort LLONMBIPALI_GetUshort(int OIPCCBHIKIA_index)
	{
		return (ushort)KCFGIBGNPLO_ReadLittleEndian(OIPCCBHIKIA_index, sizeof(ushort));
	}
	
	public int CJAENOMGPDA_GetInt(int OIPCCBHIKIA_index)
	{
		return (int)KCFGIBGNPLO_ReadLittleEndian(OIPCCBHIKIA_index, sizeof(int));
	}
	
	public uint NIACHBNBJMG_GetUint(int OIPCCBHIKIA_index)
	{
		return (uint)KCFGIBGNPLO_ReadLittleEndian(OIPCCBHIKIA_index, sizeof(uint));
	}
	
	public long DKMPHAPBDLH_GetLong(int OIPCCBHIKIA_index)
	{
		return (long)KCFGIBGNPLO_ReadLittleEndian(OIPCCBHIKIA_index, sizeof(long));
	}
	
	public ulong HLGOMGKMOLI_GetUlong(int OIPCCBHIKIA_index)
	{
		return KCFGIBGNPLO_ReadLittleEndian(OIPCCBHIKIA_index, sizeof(ulong));
	}

	public float GEMKJBPOLGK_GetFloat(int OIPCCBHIKIA_index)
	{
		int i = (int)KCFGIBGNPLO_ReadLittleEndian(OIPCCBHIKIA_index, sizeof(float));
		GNMCIEKCKCA_inthelper[0] = i;
		Buffer.BlockCopy(GNMCIEKCKCA_inthelper, 0, IDLHFHDIDEI_floathelper, 0, sizeof(float));
		return IDLHFHDIDEI_floathelper[0];
	}

	public double BLDINLMJHAF_GetDouble(int OIPCCBHIKIA_index)
	{
		ulong i = KCFGIBGNPLO_ReadLittleEndian(OIPCCBHIKIA_index, sizeof(double));
		// There's Int64BitsToDouble but it uses unsafe code internally.
		MFAJHCGLKBI_ulonghelper[0] = i;
		Buffer.BlockCopy(MFAJHCGLKBI_ulonghelper, 0, KHCECGMODOC_doublehelper, 0, sizeof(double));
		return KHCECGMODOC_doublehelper[0];
	}
}
