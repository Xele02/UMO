// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class LBAGNFKGHIB : Table {
  public static LBAGNFKGHIB GetRootAsLBAGNFKGHIB(ByteBuffer _bb) { return GetRootAsLBAGNFKGHIB(_bb, new LBAGNFKGHIB()); }
  public static LBAGNFKGHIB GetRootAsLBAGNFKGHIB(ByteBuffer _bb, LBAGNFKGHIB obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public LBAGNFKGHIB __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public AAHHDFJLDIO GetCNOBKOPJGPL(int j) { return GetCNOBKOPJGPL(new AAHHDFJLDIO(), j); }
  public AAHHDFJLDIO GetCNOBKOPJGPL(AAHHDFJLDIO obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int CNOBKOPJGPLLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }
  public LFDPEDHPEKC GetMDOIDBIGFJI(int j) { return GetMDOIDBIGFJI(new LFDPEDHPEKC(), j); }
  public LFDPEDHPEKC GetMDOIDBIGFJI(LFDPEDHPEKC obj, int j) { int o = __offset(6); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int MDOIDBIGFJILength { get { int o = __offset(6); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<LBAGNFKGHIB> CreateLBAGNFKGHIB(FlatBufferBuilder builder,
      VectorOffset CNOBKOPJGPLOffset = default(VectorOffset),
      VectorOffset MDOIDBIGFJIOffset = default(VectorOffset)) {
    builder.StartObject(2);
    LBAGNFKGHIB.AddMDOIDBIGFJI(builder, MDOIDBIGFJIOffset);
    LBAGNFKGHIB.AddCNOBKOPJGPL(builder, CNOBKOPJGPLOffset);
    return LBAGNFKGHIB.EndLBAGNFKGHIB(builder);
  }

  public static void StartLBAGNFKGHIB(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddCNOBKOPJGPL(FlatBufferBuilder builder, VectorOffset CNOBKOPJGPLOffset) { builder.AddOffset(0, CNOBKOPJGPLOffset.Value, 0); }
  public static VectorOffset CreateCNOBKOPJGPLVector(FlatBufferBuilder builder, Offset<AAHHDFJLDIO>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartCNOBKOPJGPLVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddMDOIDBIGFJI(FlatBufferBuilder builder, VectorOffset MDOIDBIGFJIOffset) { builder.AddOffset(1, MDOIDBIGFJIOffset.Value, 0); }
  public static VectorOffset CreateMDOIDBIGFJIVector(FlatBufferBuilder builder, Offset<LFDPEDHPEKC>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartMDOIDBIGFJIVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<LBAGNFKGHIB> EndLBAGNFKGHIB(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<LBAGNFKGHIB>(o);
  }
};

