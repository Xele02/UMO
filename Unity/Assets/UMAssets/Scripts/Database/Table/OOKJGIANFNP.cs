// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class OOKJGIANFNP : Table {
  public static OOKJGIANFNP GetRootAsOOKJGIANFNP(ByteBuffer _bb) { return GetRootAsOOKJGIANFNP(_bb, new OOKJGIANFNP()); }
  public static OOKJGIANFNP GetRootAsOOKJGIANFNP(ByteBuffer _bb, OOKJGIANFNP obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public OOKJGIANFNP __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public LLGKOAFFEJF GetLJOPIBIJHNA(int j) { return GetLJOPIBIJHNA(new LLGKOAFFEJF(), j); }
  public LLGKOAFFEJF GetLJOPIBIJHNA(LLGKOAFFEJF obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int LJOPIBIJHNALength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<OOKJGIANFNP> CreateOOKJGIANFNP(FlatBufferBuilder builder,
      VectorOffset LJOPIBIJHNAOffset = default(VectorOffset)) {
    builder.StartObject(1);
    OOKJGIANFNP.AddLJOPIBIJHNA(builder, LJOPIBIJHNAOffset);
    return OOKJGIANFNP.EndOOKJGIANFNP(builder);
  }

  public static void StartOOKJGIANFNP(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddLJOPIBIJHNA(FlatBufferBuilder builder, VectorOffset LJOPIBIJHNAOffset) { builder.AddOffset(0, LJOPIBIJHNAOffset.Value, 0); }
  public static VectorOffset CreateLJOPIBIJHNAVector(FlatBufferBuilder builder, Offset<LLGKOAFFEJF>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartLJOPIBIJHNAVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<OOKJGIANFNP> EndOOKJGIANFNP(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<OOKJGIANFNP>(o);
  }
};

