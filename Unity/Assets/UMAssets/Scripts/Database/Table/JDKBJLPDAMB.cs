// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class JDKBJLPDAMB : Table {
  public static JDKBJLPDAMB GetRootAsJDKBJLPDAMB(ByteBuffer _bb) { return GetRootAsJDKBJLPDAMB(_bb, new JDKBJLPDAMB()); }
  public static JDKBJLPDAMB GetRootAsJDKBJLPDAMB(ByteBuffer _bb, JDKBJLPDAMB obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public JDKBJLPDAMB __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public LDOCPAKMACI GetPIIOHCJFHBD(int j) { return GetPIIOHCJFHBD(new LDOCPAKMACI(), j); }
  public LDOCPAKMACI GetPIIOHCJFHBD(LDOCPAKMACI obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int PIIOHCJFHBDLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<JDKBJLPDAMB> CreateJDKBJLPDAMB(FlatBufferBuilder builder,
      VectorOffset PIIOHCJFHBDOffset = default(VectorOffset)) {
    builder.StartObject(1);
    JDKBJLPDAMB.AddPIIOHCJFHBD(builder, PIIOHCJFHBDOffset);
    return JDKBJLPDAMB.EndJDKBJLPDAMB(builder);
  }

  public static void StartJDKBJLPDAMB(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddPIIOHCJFHBD(FlatBufferBuilder builder, VectorOffset PIIOHCJFHBDOffset) { builder.AddOffset(0, PIIOHCJFHBDOffset.Value, 0); }
  public static VectorOffset CreatePIIOHCJFHBDVector(FlatBufferBuilder builder, Offset<LDOCPAKMACI>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartPIIOHCJFHBDVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<JDKBJLPDAMB> EndJDKBJLPDAMB(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<JDKBJLPDAMB>(o);
  }
};

