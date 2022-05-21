
using System;
using System.Text;

// https://github.com/google/flatbuffers/tree/18d67ed83bfd54de4d248f4650f5ff1900b1ed6b/net/FlatBuffers


/// <summary>
/// Responsible for building up and accessing a FlatBuffer formatted byte
/// array (via ByteBuffer).
/// </summary>
public class EJJNJDFCICC_FlatBufferBuilder
{
	private int JIOGLBHBGHD__space; // 0x8
	private JMPAJDKFFGL_ByteBuffer HJGJPEFJAEH__bb; // 0xC
	private int MLLCLLGLFIM__minAlign = 1; // 0x10

	// The vtable for the current table (if _vtableSize >= 0)
	private int[] LMHPDJLIDGL__vtable = new int[16]; // 0x14
	// The size of the vtable. -1 indicates no vtable
	private int MHBNJCBHCFH__vtableSize = -1; // 0x18
	// Starting offset of the current struct/table.
	private int OHOKDPJEEIB__objectStart; // 0x1C
	// List of offsets of all vtables.
	private int[] BCDIHMNCLML__vtables = new int[16]; // 0x20
	// Number of entries in `vtables` in use.
	private int HEKPDHJBMBK__numVtables = 0; // 0x24
	// For the current vector being built.
	private int LMCNBGBIFMA__vectorNumElems = 0; // 0x28

	/// <summary>
	/// Gets and sets a Boolean to disable the optimization when serializing
	/// default values to a Table.
	///
	/// In order to save space, fields that are set to their default value
	/// don't get serialized into the buffer.
	/// </summary>
	public bool POHDOOHAEEN_ForceDefaults { get; set; } // JALBCICMKPE // 0x2C // PMCLBDLCCBO // NDODALBDCHH

	public int NNLMLCOLJBA_Offset { get { return HJGJPEFJAEH__bb.FONPCFFGPBK_Length - JIOGLBHBGHD__space; } } // NCLMKEOJNHA

	/// <summary>
	/// Get the ByteBuffer representing the FlatBuffer.
	/// </summary>
	/// <remarks>
	/// This is typically only called after you call `Finish()`.
	/// The actual data starts at the ByteBuffer's current position,
	/// not necessarily at `0`.
	/// </remarks>
	/// <returns>
	/// Returns the ByteBuffer for this FlatBuffer.
	/// </returns>
	public JMPAJDKFFGL_ByteBuffer DPMMHOKADMB_DataBuffer { get { return HJGJPEFJAEH__bb; } } // EDGDEDAOAAL

	/// <summary>
	/// Create a FlatBufferBuilder with a given initial size.
	/// </summary>
	/// <param name="initialSize">
	/// The initial size to use for the internal buffer.
	/// </param>
	public EJJNJDFCICC_FlatBufferBuilder(int EFOCJMHKHIH_initialSize)
	{
		if (EFOCJMHKHIH_initialSize <= 0)
			throw new ArgumentOutOfRangeException("initialSize",
				EFOCJMHKHIH_initialSize, "Must be greater than zero");
		JIOGLBHBGHD__space = EFOCJMHKHIH_initialSize;
		HJGJPEFJAEH__bb = new JMPAJDKFFGL_ByteBuffer(new byte[EFOCJMHKHIH_initialSize]);
	}

	/// <summary>
	/// Reset the FlatBufferBuilder by purging all data that it holds.
	/// </summary>
	public void JCHLONCMPAJ_Clear()
	{
		JIOGLBHBGHD__space = HJGJPEFJAEH__bb.FONPCFFGPBK_Length;
		HJGJPEFJAEH__bb.LHPDDGIJKNB_Reset();
		MLLCLLGLFIM__minAlign = 1;
		while (MHBNJCBHCFH__vtableSize > 0) LMHPDJLIDGL__vtable[--MHBNJCBHCFH__vtableSize] = 0;
		MHBNJCBHCFH__vtableSize = -1;
		OHOKDPJEEIB__objectStart = 0;
		HEKPDHJBMBK__numVtables = 0;
		LMCNBGBIFMA__vectorNumElems = 0;
	}

	public void DBDNBJFKHAI_Pad(int NFHFALDMGGC_size)
	{
		HJGJPEFJAEH__bb.FNGDPJJMDHH_PutByte(JIOGLBHBGHD__space -= NFHFALDMGGC_size, 0, NFHFALDMGGC_size);
	}

	// Doubles the size of the ByteBuffer, and copies the old data towards
	// the end of the new buffer (since we build the buffer backwards).
	private void BBJKHNFNFPB_GrowBuffer()
	{
		var oldBuf = HJGJPEFJAEH__bb.KOJCDOJALDM_Data;
		var oldBufSize = oldBuf.Length;
		if ((oldBufSize & 0xC0000000) != 0)
			throw new Exception(
				"FlatBuffers: cannot grow buffer beyond 2 gigabytes.");

		var newBufSize = oldBufSize << 1;
		var newBuf = new byte[newBufSize];

		Buffer.BlockCopy(oldBuf, 0, newBuf, newBufSize - oldBufSize,
							oldBufSize);
		HJGJPEFJAEH__bb = new JMPAJDKFFGL_ByteBuffer(newBuf, newBufSize);
	}

	// Prepare to write an element of `size` after `additional_bytes`
	// have been written, e.g. if you write a string, you need to align
	// such the int length field is aligned to SIZEOF_INT, and the string
	// data follows it directly.
	// If all you need to do is align, `additional_bytes` will be 0.
	public void JMLDEJGMMCD_Prep(int NFHFALDMGGC_size, int OIIDANJINNJ_additionalBytes)
	{
		// Track the biggest thing we've ever aligned to.
		if (NFHFALDMGGC_size > MLLCLLGLFIM__minAlign)
			MLLCLLGLFIM__minAlign = NFHFALDMGGC_size;
		// Find the amount of alignment needed such that `size` is properly
		// aligned after `additional_bytes`
		var alignSize =
			((~((int)HJGJPEFJAEH__bb.FONPCFFGPBK_Length - JIOGLBHBGHD__space + OIIDANJINNJ_additionalBytes)) + 1) &
			(NFHFALDMGGC_size - 1);
		// Reallocate the buffer if needed.
		while (JIOGLBHBGHD__space < alignSize + NFHFALDMGGC_size + OIIDANJINNJ_additionalBytes)
		{
			var oldBufSize = (int)HJGJPEFJAEH__bb.FONPCFFGPBK_Length;
			BBJKHNFNFPB_GrowBuffer();
			JIOGLBHBGHD__space += (int)HJGJPEFJAEH__bb.FONPCFFGPBK_Length - oldBufSize;

		}
		if (alignSize > 0)
			DBDNBJFKHAI_Pad(alignSize);
	}

	public void GGCDLONKILG_PutBool(bool GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.FNGDPJJMDHH_PutByte(JIOGLBHBGHD__space -= sizeof(byte), (byte)(GHPLINIACBB_x ? 1 : 0));
	}

	public void FOJBKBDDNJB_PutSbyte(sbyte GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.FOJBKBDDNJB_PutSbyte(JIOGLBHBGHD__space -= sizeof(sbyte), GHPLINIACBB_x);
	}

	public void FNGDPJJMDHH_PutByte(byte GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.FNGDPJJMDHH_PutByte(JIOGLBHBGHD__space -= sizeof(byte), GHPLINIACBB_x);
	}

	public void LMOOMGJOAGA_PutShort(short GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.LMOOMGJOAGA_PutShort(JIOGLBHBGHD__space -= sizeof(short), GHPLINIACBB_x);
	}

	public void LLGCDOILPOE_PutUshort(ushort GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.LLGCDOILPOE_PutUshort(JIOGLBHBGHD__space -= sizeof(ushort), GHPLINIACBB_x);
	}

	public void IFHOMMKPAIE_PutInt(int GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.IFHOMMKPAIE_PutInt(JIOGLBHBGHD__space -= sizeof(int), GHPLINIACBB_x);
	}

	public void EEDJAOFJFKB_PutUint(uint GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.EEDJAOFJFKB_PutUint(JIOGLBHBGHD__space -= sizeof(uint), GHPLINIACBB_x);
	}

	public void LAHABNLFINP_PutLong(long GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.LAHABNLFINP_PutLong(JIOGLBHBGHD__space -= sizeof(long), GHPLINIACBB_x);
	}

	public void JLGNNCCEEEO_PutUlong(ulong GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.JLGNNCCEEEO_PutUlong(JIOGLBHBGHD__space -= sizeof(ulong), GHPLINIACBB_x);
	}

	public void HOPAHGDHCEG_PutFloat(float GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.HOPAHGDHCEG_PutFloat(JIOGLBHBGHD__space -= sizeof(float), GHPLINIACBB_x);
	}

	public void FLGPOMLGAOL_PutDouble(double GHPLINIACBB_x)
	{
        HJGJPEFJAEH__bb.FLGPOMLGAOL_PutDouble(JIOGLBHBGHD__space -= sizeof(double), GHPLINIACBB_x);
	}


	/// <summary>
	/// Add a `bool` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `bool` to add to the buffer.</param>
	public void MCOEIABLPKK_AddBool(bool GHPLINIACBB_x)
	{
		JMLDEJGMMCD_Prep(sizeof(byte), 0);
		GGCDLONKILG_PutBool(GHPLINIACBB_x);
	}

	/// <summary>
	/// Add a `sbyte` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `sbyte` to add to the buffer.</param>
	public void DALMBFKPFAA_AddSbyte(sbyte GHPLINIACBB_x)
	{ 
		JMLDEJGMMCD_Prep(sizeof(sbyte), 0); 
		FOJBKBDDNJB_PutSbyte(GHPLINIACBB_x);
	}

	/// <summary>
	/// Add a `byte` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `byte` to add to the buffer.</param>
	public void KAAFMBILFMO_AddByte(byte GHPLINIACBB_x)
	{
		JMLDEJGMMCD_Prep(sizeof(byte), 0);
		FNGDPJJMDHH_PutByte(GHPLINIACBB_x);
	}

	/// <summary>
	/// Add a `short` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `short` to add to the buffer.</param>
	public void BHJHBMDDOAA_AddShort(short GHPLINIACBB_x)
	{
		JMLDEJGMMCD_Prep(sizeof(short), 0);
		LMOOMGJOAGA_PutShort(GHPLINIACBB_x);
	}

	/// <summary>
	/// Add an `ushort` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `ushort` to add to the buffer.</param>
	public void FDFPPDCNJHB_AddUshort(ushort GHPLINIACBB_x)
	{
		JMLDEJGMMCD_Prep(sizeof(ushort), 0);
		LLGCDOILPOE_PutUshort(GHPLINIACBB_x);
	}

	/// <summary>
	/// Add an `int` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `int` to add to the buffer.</param>
	public void IICDBBHKPHM_AddInt(int GHPLINIACBB_x)
	{
		JMLDEJGMMCD_Prep(sizeof(int), 0);
		IFHOMMKPAIE_PutInt(GHPLINIACBB_x);
	}

	/// <summary>
	/// Add an `uint` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `uint` to add to the buffer.</param>
	public void NDIOMGDECIH_AddUint(uint GHPLINIACBB_x)
	{
		JMLDEJGMMCD_Prep(sizeof(uint), 0);
		EEDJAOFJFKB_PutUint(GHPLINIACBB_x);
	}

	/// <summary>
	/// Add a `long` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `long` to add to the buffer.</param>
	public void HLOPOFEGPMG_AddLong(long GHPLINIACBB_x)
	{
		JMLDEJGMMCD_Prep(sizeof(long), 0);
		LAHABNLFINP_PutLong(GHPLINIACBB_x);
	}

	/// <summary>
	/// Add an `ulong` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `ulong` to add to the buffer.</param>
	public void JPEBCMABKCE_AddUlong(ulong GHPLINIACBB_x)
	{
		JMLDEJGMMCD_Prep(sizeof(ulong), 0);
		JLGNNCCEEEO_PutUlong(GHPLINIACBB_x);
	}

	/// <summary>
	/// Add a `float` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `float` to add to the buffer.</param>
	public void EEEAHBJENGF_AddFloat(float GHPLINIACBB_x)
	{
		JMLDEJGMMCD_Prep(sizeof(float), 0);
		HOPAHGDHCEG_PutFloat(GHPLINIACBB_x);
	}

	/// <summary>
	/// Add a `double` to the buffer (aligns the data and grows if necessary).
	/// </summary>
	/// <param name="x">The `double` to add to the buffer.</param>
	public void JDJILMFCKLC_AddDouble(double GHPLINIACBB_x)
	{
		JMLDEJGMMCD_Prep(sizeof(double), 0);
		FLGPOMLGAOL_PutDouble(GHPLINIACBB_x);
	}

	/// <summary>
	/// Adds an offset, relative to where it will be written.
	/// </summary>
	/// <param name="off">The offset to add to the buffer.</param>
	public void GLKLNBAGDDC_AddOffset(int DNBPPOGHFGG_off)
	{
		JMLDEJGMMCD_Prep(sizeof(int), 0);  // Ensure alignment is already done.
		if (DNBPPOGHFGG_off > NNLMLCOLJBA_Offset)
			throw new ArgumentException();

		DNBPPOGHFGG_off = NNLMLCOLJBA_Offset - DNBPPOGHFGG_off + sizeof(int);
		IFHOMMKPAIE_PutInt(DNBPPOGHFGG_off);
	}

	public void MANDALFJNJB_StartVector(int LPGOPEEDOIG_elemSize, int HMFFHLPNMPH_count, int LLHCKLNBPAA_alignment)
	{
		NABDIDIBMJK_NotNested();
		LMCNBGBIFMA__vectorNumElems = HMFFHLPNMPH_count;
		JMLDEJGMMCD_Prep(sizeof(int), LPGOPEEDOIG_elemSize * HMFFHLPNMPH_count);
		JMLDEJGMMCD_Prep(LLHCKLNBPAA_alignment, LPGOPEEDOIG_elemSize * HMFFHLPNMPH_count); // Just in case alignment > int.
	}

	/// <summary>
	/// Writes data necessary to finish a vector construction.
	/// </summary>
	public EPIPFBNHFKI_VectorOffset DDCBNGBCIDN_EndVector()
	{
		IFHOMMKPAIE_PutInt(LMCNBGBIFMA__vectorNumElems);
		return new EPIPFBNHFKI_VectorOffset(NNLMLCOLJBA_Offset);
	}

	public void BIGEGDFOHNB_Nested(int LMNBBOIJBBL_obj)
	{
		// Structs are always stored inline, so need to be created right
		// where they are used. You'll get this assert if you created it
		// elsewhere.
		if (LMNBBOIJBBL_obj != NNLMLCOLJBA_Offset)
			throw new Exception(
				"FlatBuffers: struct must be serialized inline.");
	}

	public void NABDIDIBMJK_NotNested()
	{
		// You should not be creating any other objects or strings/vectors
		// while an object is being constructed
		if (MHBNJCBHCFH__vtableSize >= 0)
			throw new Exception(
				"FlatBuffers: object serialization must not be nested.");
	}

	public void JDNCFPMMHEP_StartObject(int AKOIMJHACBJ_numfields)
	{
		if (AKOIMJHACBJ_numfields < 0)
			throw new ArgumentOutOfRangeException("Flatbuffers: invalid numfields");

		NABDIDIBMJK_NotNested();

		if (LMHPDJLIDGL__vtable.Length < AKOIMJHACBJ_numfields)
			LMHPDJLIDGL__vtable = new int[AKOIMJHACBJ_numfields];

		MHBNJCBHCFH__vtableSize = AKOIMJHACBJ_numfields;
		OHOKDPJEEIB__objectStart = NNLMLCOLJBA_Offset;
	}

	// Set the current vtable at `voffset` to the current location in the
	// buffer.
	public void GHLLICMFMGC_Slot(int CHMAFBKMHNI_voffset)
	{
		if (CHMAFBKMHNI_voffset >= MHBNJCBHCFH__vtableSize)
			throw new IndexOutOfRangeException("Flatbuffers: invalid voffset");

		LMHPDJLIDGL__vtable[CHMAFBKMHNI_voffset] = NNLMLCOLJBA_Offset;
	}

	/// <summary>
	/// Adds a Boolean to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void MCOEIABLPKK_AddBool(int JKDKBCPFFEL_o, bool GHPLINIACBB_x, bool JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			MCOEIABLPKK_AddBool(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds a SByte to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void DALMBFKPFAA_AddSbyte(int JKDKBCPFFEL_o, sbyte GHPLINIACBB_x, sbyte JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			DALMBFKPFAA_AddSbyte(GHPLINIACBB_x); 
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds a Byte to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void KAAFMBILFMO_AddByte(int JKDKBCPFFEL_o, byte GHPLINIACBB_x, byte JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			KAAFMBILFMO_AddByte(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds a Int16 to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void BHJHBMDDOAA_AddShort(int JKDKBCPFFEL_o, short GHPLINIACBB_x, int JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			BHJHBMDDOAA_AddShort(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds a UInt16 to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void FDFPPDCNJHB_AddUshort(int JKDKBCPFFEL_o, ushort GHPLINIACBB_x, ushort JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			FDFPPDCNJHB_AddUshort(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds an Int32 to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void IICDBBHKPHM_AddInt(int JKDKBCPFFEL_o, int GHPLINIACBB_x, int JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			IICDBBHKPHM_AddInt(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds a UInt32 to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void NDIOMGDECIH_AddUint(int JKDKBCPFFEL_o, uint GHPLINIACBB_x, uint JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			NDIOMGDECIH_AddUint(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds an Int64 to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void HLOPOFEGPMG_AddLong(int JKDKBCPFFEL_o, long GHPLINIACBB_x, long JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			HLOPOFEGPMG_AddLong(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds a UInt64 to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void JPEBCMABKCE_AddUlong(int JKDKBCPFFEL_o, ulong GHPLINIACBB_x, ulong JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			JPEBCMABKCE_AddUlong(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds a Single to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void EEEAHBJENGF_AddFloat(int JKDKBCPFFEL_o, float GHPLINIACBB_x, double JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			EEEAHBJENGF_AddFloat(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds a Double to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void JDJILMFCKLC_AddDouble(int JKDKBCPFFEL_o, double GHPLINIACBB_x, double JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			JDJILMFCKLC_AddDouble(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Adds a buffer offset to the Table at index `o` in its vtable using the value `x` and default `d`
	/// </summary>
	/// <param name="o">The index into the vtable</param>
	/// <param name="x">The value to put into the buffer. If the value is equal to the default
	/// and <see cref="ForceDefaults"/> is false, the value will be skipped.</param>
	/// <param name="d">The default value to compare the value against</param>
	public void GLKLNBAGDDC_AddOffset(int JKDKBCPFFEL_o, int GHPLINIACBB_x, int JGNBPFCJLKI_d)
	{
		if (POHDOOHAEEN_ForceDefaults || GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			GLKLNBAGDDC_AddOffset(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(JKDKBCPFFEL_o);
		}
	}

	/// <summary>
	/// Encode the string `s` in the buffer using UTF-8.
	/// </summary>
	/// <param name="s">The string to encode.</param>
	/// <returns>
	/// The offset in the buffer where the encoded string starts.
	/// </returns>
	public EANEPBLOKJB_StringOffset OEOIBLLAGIB_CreateString(string IBDJFHFIIHN_s) 
	{
		NABDIDIBMJK_NotNested();
		KAAFMBILFMO_AddByte(0);
		var utf8StringLen = Encoding.UTF8.GetByteCount(IBDJFHFIIHN_s);
		MANDALFJNJB_StartVector(1, utf8StringLen, 1);
		Encoding.UTF8.GetBytes(IBDJFHFIIHN_s, 0, IBDJFHFIIHN_s.Length, HJGJPEFJAEH__bb.KOJCDOJALDM_Data, JIOGLBHBGHD__space -= utf8StringLen);
		return new EANEPBLOKJB_StringOffset(DDCBNGBCIDN_EndVector().BLNDFNMPILA_Value);
	}

	// Structs are stored inline, so nothing additional is being added.
	// `d` is always 0.
	public void OJKILNFBILH_AddStruct(int CHMAFBKMHNI_voffset, int GHPLINIACBB_x, int JGNBPFCJLKI_d)
	{
		if (GHPLINIACBB_x != JGNBPFCJLKI_d)
		{
			BIGEGDFOHNB_Nested(GHPLINIACBB_x);
			GHLLICMFMGC_Slot(CHMAFBKMHNI_voffset);
		}
	}

	public int DOEIFIEIIEH_EndObject()
	{
		if (MHBNJCBHCFH__vtableSize < 0)
			throw new InvalidOperationException(
				"Flatbuffers: calling endObject without a startObject");

		IICDBBHKPHM_AddInt((int)0);
		var vtableloc = NNLMLCOLJBA_Offset;
		// Write out the current vtable.
		for (int i = MHBNJCBHCFH__vtableSize - 1; i >= 0 ; i--) {
			// Offset relative to the start of the table.
			short off = (short)(LMHPDJLIDGL__vtable[i] != 0
									? vtableloc - LMHPDJLIDGL__vtable[i]
									: 0);
			BHJHBMDDOAA_AddShort(off);

			// clear out written entry
			LMHPDJLIDGL__vtable[i] = 0;
		}

		const int standardFields = 2; // The fields below:
		BHJHBMDDOAA_AddShort((short)(vtableloc - OHOKDPJEEIB__objectStart));
		BHJHBMDDOAA_AddShort((short)((MHBNJCBHCFH__vtableSize + standardFields) *
							sizeof(short)));

		// Search for an existing vtable that matches the current one.
		int existingVtable = 0;
		for (int i = 0; i < HEKPDHJBMBK__numVtables; i++) {
			int vt1 = HJGJPEFJAEH__bb.FONPCFFGPBK_Length - BCDIHMNCLML__vtables[i];
			int vt2 = JIOGLBHBGHD__space;
			short len = HJGJPEFJAEH__bb.IJIFMEMHIPA_GetShort(vt1);
			if (len == HJGJPEFJAEH__bb.IJIFMEMHIPA_GetShort(vt2)) {
				for (int j = sizeof(short); j < len; j += sizeof(short)) {
					if (HJGJPEFJAEH__bb.IJIFMEMHIPA_GetShort(vt1 + j) != HJGJPEFJAEH__bb.IJIFMEMHIPA_GetShort(vt2 + j)) {
						goto endLoop;
					}
				}
				existingVtable = BCDIHMNCLML__vtables[i];
				break;
			}

		endLoop: { }
		}

		if (existingVtable != 0) {
			// Found a match:
			// Remove the current vtable.
			JIOGLBHBGHD__space = HJGJPEFJAEH__bb.FONPCFFGPBK_Length - vtableloc;
			// Point table to existing vtable.
			HJGJPEFJAEH__bb.IFHOMMKPAIE_PutInt(JIOGLBHBGHD__space, existingVtable - vtableloc);
		} else {
			// No match:
			// Add the location of the current vtable to the list of
			// vtables.
			if (HEKPDHJBMBK__numVtables == BCDIHMNCLML__vtables.Length)
			{
				// Arrays.CopyOf(vtables num_vtables * 2);
				var newvtables = new int[ HEKPDHJBMBK__numVtables * 2];
				Array.Copy(BCDIHMNCLML__vtables, newvtables, BCDIHMNCLML__vtables.Length);

				BCDIHMNCLML__vtables = newvtables;
			};
			BCDIHMNCLML__vtables[HEKPDHJBMBK__numVtables++] = NNLMLCOLJBA_Offset;
			// Point table to current vtable.
			HJGJPEFJAEH__bb.IFHOMMKPAIE_PutInt(HJGJPEFJAEH__bb.FONPCFFGPBK_Length - vtableloc, NNLMLCOLJBA_Offset - vtableloc);
		}

		MHBNJCBHCFH__vtableSize = -1;
		return vtableloc;
	}

	// This checks a required field has been set in a given table that has
	// just been constructed.
	public void HAMKHNHKDDF_Required(int CDENCMNHNGA_table, int MLIOPKBGNOC_field)
	{
		int table_start = HJGJPEFJAEH__bb.FONPCFFGPBK_Length - CDENCMNHNGA_table;
		int vtable_start = table_start - HJGJPEFJAEH__bb.CJAENOMGPDA_GetInt(table_start);
		bool ok = HJGJPEFJAEH__bb.IJIFMEMHIPA_GetShort(vtable_start + MLIOPKBGNOC_field) != 0;
		// If this fails, the caller will show what field needs to be set.
		if (!ok)
			throw new InvalidOperationException("FlatBuffers: field " + MLIOPKBGNOC_field +
											" must be set");
	}

	/// <summary>
	/// Finalize a buffer, pointing to the given `root_table`.
	/// </summary>
	/// <param name="rootTable">
	/// An offset to be added to the buffer.
	/// </param>
	public void AAGCKDHEMFD_Finish(int KECFKOEEFDB_rootTable)
	{
		JMLDEJGMMCD_Prep(MLLCLLGLFIM__minAlign, sizeof(int));
		GLKLNBAGDDC_AddOffset(KECFKOEEFDB_rootTable);
		HJGJPEFJAEH__bb.MJANLLHCFBL_Position = JIOGLBHBGHD__space;
	}

	/// <summary>
	/// A utility function to copy and return the ByteBuffer data as a
	/// `byte[]`.
	/// </summary>
	/// <returns>
	/// A full copy of the FlatBuffer data.
	/// </returns>
	public byte[] PDCLKPGPHID_SizedByteArray()
	{
		var newArray = new byte[HJGJPEFJAEH__bb.KOJCDOJALDM_Data.Length - HJGJPEFJAEH__bb.MJANLLHCFBL_Position];
		Buffer.BlockCopy(HJGJPEFJAEH__bb.KOJCDOJALDM_Data, HJGJPEFJAEH__bb.MJANLLHCFBL_Position, newArray, 0,
							HJGJPEFJAEH__bb.KOJCDOJALDM_Data.Length - HJGJPEFJAEH__bb.MJANLLHCFBL_Position);
		return newArray;
	}

	/// <summary>
	/// Finalize a buffer, pointing to the given `rootTable`.
	/// </summary>
	/// <param name="rootTable">
	/// An offset to be added to the buffer.
	/// </param>
	/// <param name="fileIdentifier">
	/// A FlatBuffer file identifier to be added to the buffer before
	/// `root_table`.
	/// </param>
	public void AAGCKDHEMFD_Finish(int KECFKOEEFDB_rootTable, string KMEIBNJJLFO_fileIdentifier)
	{
		JMLDEJGMMCD_Prep(MLLCLLGLFIM__minAlign, sizeof(int) +
						FGODGFLJBCA_FlatBufferConstants.BOBEOIMEBAK_FileIdentifierLength);
		if (KMEIBNJJLFO_fileIdentifier.Length !=
			FGODGFLJBCA_FlatBufferConstants.BOBEOIMEBAK_FileIdentifierLength)
			throw new ArgumentException(
				"FlatBuffers: file identifier must be length " +
				FGODGFLJBCA_FlatBufferConstants.BOBEOIMEBAK_FileIdentifierLength,
				"fileIdentifier");
		for (int i = FGODGFLJBCA_FlatBufferConstants.BOBEOIMEBAK_FileIdentifierLength - 1; i >= 0;
			i--)
		{
			KAAFMBILFMO_AddByte((byte)KMEIBNJJLFO_fileIdentifier[i]);
		}
		AAGCKDHEMFD_Finish(KECFKOEEFDB_rootTable);
	}
}
