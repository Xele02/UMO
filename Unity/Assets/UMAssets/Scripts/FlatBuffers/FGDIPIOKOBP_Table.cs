
// using System;
// using System.Text;

// /// <summary>
// /// All tables in the generated code derive from this class, and add their own accessors.
// /// </summary>
public abstract class FGDIPIOKOBP//_Table
{}
// 	protected int LAOPOAKCOGK_bb_pos; // 0x8
// 	protected JMPAJDKFFGL_ByteBuffer CELAFKLADCP_bb; // 0xC

// 	public JMPAJDKFFGL_ByteBuffer ALHECKIHFMK_ByteBuffer { get { return CELAFKLADCP_bb; } } // PDKNELBLNHE

//     // Look up a field in the vtable, return an offset into the object, or 0 if the field is not
//     // present.
// 	protected int LPGLFFLLMNG____offset(int DNMMECIKCAL_vtableOffset)
//     {
//         // int vtable = LAOPOAKCOGK_bb_pos - CELAFKLADCP_bb.CJAENOMGPDA_GetInt(LAOPOAKCOGK_bb_pos);
//         return DNMMECIKCAL_vtableOffset < CELAFKLADCP_bb.IJIFMEMHIPA_GetShort(vtable) ? (int)CELAFKLADCP_bb.IJIFMEMHIPA_GetShort(vtable + DNMMECIKCAL_vtableOffset) : 0;
//     }

//     // Retrieve the relative offset stored at "offset"
// 	protected int AIHBMFDMLHA___indirect(int POMLAOPLMNA_offset)
//     {
//         return POMLAOPLMNA_offset + CELAFKLADCP_bb.CJAENOMGPDA_GetInt(POMLAOPLMNA_offset);
//     }

//     // Create a .NET String from UTF-8 data stored inside the flatbuffer.
// 	protected string AGODLOAOPML___string(int POMLAOPLMNA_offset)
//     {
//         POMLAOPLMNA_offset += CELAFKLADCP_bb.CJAENOMGPDA_GetInt(POMLAOPLMNA_offset);
//         var len = CELAFKLADCP_bb.CJAENOMGPDA_GetInt(POMLAOPLMNA_offset);
//         var startPos = POMLAOPLMNA_offset + sizeof(int);
//         return Encoding.UTF8.GetString(CELAFKLADCP_bb.KOJCDOJALDM_Data, startPos , len);
//     }

//     // Get the length of a vector whose offset is stored at "offset" in this object.
// 	protected int GPJPDFEMHML___vector_len(int POMLAOPLMNA_offset)
//     {
//         POMLAOPLMNA_offset += LAOPOAKCOGK_bb_pos;
//         POMLAOPLMNA_offset += CELAFKLADCP_bb.CJAENOMGPDA_GetInt(POMLAOPLMNA_offset);
//         return CELAFKLADCP_bb.CJAENOMGPDA_GetInt(POMLAOPLMNA_offset);
//     }

//     // Get the start of data of a vector whose offset is stored at "offset" in this object.
// 	protected int POLEPADIOIH___vector(int POMLAOPLMNA_offset)
//     {
//         POMLAOPLMNA_offset += LAOPOAKCOGK_bb_pos;
//         return POMLAOPLMNA_offset + CELAFKLADCP_bb.CJAENOMGPDA_GetInt(POMLAOPLMNA_offset) + sizeof(int);  // data starts after the length
//     }

//     // Get the data of a vector whoses offset is stored at "offset" in this object as an
//     // ArraySegment&lt;byte&gt;. If the vector is not present in the ByteBuffer,
//     // then a null value will be returned.
// 	protected ArraySegment<byte>? ELNBKKGMMEJ___vector_as_arraysegment(int POMLAOPLMNA_offset)
//     {
//         var o = this.LPGLFFLLMNG____offset(POMLAOPLMNA_offset);
//         if (0 == o)
//         {
//             return null;
//         }

//         var pos = this.POLEPADIOIH___vector(o);
//         var len = this.GPJPDFEMHML___vector_len(o);
//         return new ArraySegment<byte>(this.CELAFKLADCP_bb.KOJCDOJALDM_Data, pos, len);
//     }

//     // Initialize any Table-derived type to point to the union at the given offset.
// 	protected TTable HFFPDNPIOPI___union<TTable>(TTable OHMCIEMIKCE_t, int POMLAOPLMNA_offset) where TTable : FGDIPIOKOBP_Table
//     {
//         POMLAOPLMNA_offset += LAOPOAKCOGK_bb_pos;
//         OHMCIEMIKCE_t.LAOPOAKCOGK_bb_pos = POMLAOPLMNA_offset + CELAFKLADCP_bb.CJAENOMGPDA_GetInt(POMLAOPLMNA_offset);
//         OHMCIEMIKCE_t.CELAFKLADCP_bb = CELAFKLADCP_bb;
//         return OHMCIEMIKCE_t;
//     }

// 	protected static bool FPNOGBBGBAH___has_identifier(JMPAJDKFFGL_ByteBuffer CELAFKLADCP_bb, string HONBNNCCNIF_ident) 
//     {
//         if (HONBNNCCNIF_ident.Length != FGODGFLJBCA_FlatBufferConstants.BOBEOIMEBAK_FileIdentifierLength)
//             throw new ArgumentException("FlatBuffers: file identifier must be length " + FGODGFLJBCA_FlatBufferConstants.BOBEOIMEBAK_FileIdentifierLength, "ident");

//         for (var i = 0; i < FGODGFLJBCA_FlatBufferConstants.BOBEOIMEBAK_FileIdentifierLength; i++)
//         {
//             if (HONBNNCCNIF_ident[i] != (char)CELAFKLADCP_bb.GCINIJEMHFK_Get(CELAFKLADCP_bb.MJANLLHCFBL_Position + sizeof(int) + i)) return false;
//         }

//         return true;
//     }
// }
