// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class CFFBOCDCDCJ : Table {
  public static CFFBOCDCDCJ GetRootAsCFFBOCDCDCJ(ByteBuffer _bb) { return GetRootAsCFFBOCDCDCJ(_bb, new CFFBOCDCDCJ()); }
  public static CFFBOCDCDCJ GetRootAsCFFBOCDCDCJ(ByteBuffer _bb, CFFBOCDCDCJ obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public CFFBOCDCDCJ __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public ACFFNDFGCHL GetCGHMONDBJAI(int j) { return GetCGHMONDBJAI(new ACFFNDFGCHL(), j); }
  public ACFFNDFGCHL GetCGHMONDBJAI(ACFFNDFGCHL obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int CGHMONDBJAILength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<CFFBOCDCDCJ> CreateCFFBOCDCDCJ(FlatBufferBuilder builder,
      VectorOffset CGHMONDBJAIOffset = default(VectorOffset)) {
    builder.StartObject(1);
    CFFBOCDCDCJ.AddCGHMONDBJAI(builder, CGHMONDBJAIOffset);
    return CFFBOCDCDCJ.EndCFFBOCDCDCJ(builder);
  }

  public static void StartCFFBOCDCDCJ(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddCGHMONDBJAI(FlatBufferBuilder builder, VectorOffset CGHMONDBJAIOffset) { builder.AddOffset(0, CGHMONDBJAIOffset.Value, 0); }
  public static VectorOffset CreateCGHMONDBJAIVector(FlatBufferBuilder builder, Offset<ACFFNDFGCHL>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartCGHMONDBJAIVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<CFFBOCDCDCJ> EndCFFBOCDCDCJ(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<CFFBOCDCDCJ>(o);
  }
};

