// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class NMOEOEOBDAD : Table {
  public static NMOEOEOBDAD GetRootAsNMOEOEOBDAD(ByteBuffer _bb) { return GetRootAsNMOEOEOBDAD(_bb, new NMOEOEOBDAD()); }
  public static NMOEOEOBDAD GetRootAsNMOEOEOBDAD(ByteBuffer _bb, NMOEOEOBDAD obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public NMOEOEOBDAD __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public DHEAKBKIDEA GetLLDMPBONLLM(int j) { return GetLLDMPBONLLM(new DHEAKBKIDEA(), j); }
  public DHEAKBKIDEA GetLLDMPBONLLM(DHEAKBKIDEA obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int LLDMPBONLLMLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<NMOEOEOBDAD> CreateNMOEOEOBDAD(FlatBufferBuilder builder,
      VectorOffset LLDMPBONLLMOffset = default(VectorOffset)) {
    builder.StartObject(1);
    NMOEOEOBDAD.AddLLDMPBONLLM(builder, LLDMPBONLLMOffset);
    return NMOEOEOBDAD.EndNMOEOEOBDAD(builder);
  }

  public static void StartNMOEOEOBDAD(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddLLDMPBONLLM(FlatBufferBuilder builder, VectorOffset LLDMPBONLLMOffset) { builder.AddOffset(0, LLDMPBONLLMOffset.Value, 0); }
  public static VectorOffset CreateLLDMPBONLLMVector(FlatBufferBuilder builder, Offset<DHEAKBKIDEA>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartLLDMPBONLLMVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<NMOEOEOBDAD> EndNMOEOEOBDAD(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<NMOEOEOBDAD>(o);
  }
};

