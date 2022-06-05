// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class APGAHFFLAPA : Table {
  public static APGAHFFLAPA GetRootAsAPGAHFFLAPA(ByteBuffer _bb) { return GetRootAsAPGAHFFLAPA(_bb, new APGAHFFLAPA()); }
  public static APGAHFFLAPA GetRootAsAPGAHFFLAPA(ByteBuffer _bb, APGAHFFLAPA obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public APGAHFFLAPA __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint NCIKNCJLFBI { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint COPFAKAHEMN { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint HLPHBGLMBIO { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint LPJPOOHJKAE { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GetCHGIONDFIKP(int j) { int o = __offset(12); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int CHGIONDFIKPLength { get { int o = __offset(12); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetCHGIONDFIKPBytes() { return __vector_as_arraysegment(12); }
  public int MGHHDHFMOPF { get { int o = __offset(14); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<APGAHFFLAPA> CreateAPGAHFFLAPA(FlatBufferBuilder builder,
      uint NCIKNCJLFBI = 0,
      uint COPFAKAHEMN = 0,
      uint HLPHBGLMBIO = 0,
      uint LPJPOOHJKAE = 0,
      VectorOffset CHGIONDFIKPOffset = default(VectorOffset),
      int MGHHDHFMOPF = 0) {
    builder.StartObject(6);
    APGAHFFLAPA.AddMGHHDHFMOPF(builder, MGHHDHFMOPF);
    APGAHFFLAPA.AddCHGIONDFIKP(builder, CHGIONDFIKPOffset);
    APGAHFFLAPA.AddLPJPOOHJKAE(builder, LPJPOOHJKAE);
    APGAHFFLAPA.AddHLPHBGLMBIO(builder, HLPHBGLMBIO);
    APGAHFFLAPA.AddCOPFAKAHEMN(builder, COPFAKAHEMN);
    APGAHFFLAPA.AddNCIKNCJLFBI(builder, NCIKNCJLFBI);
    return APGAHFFLAPA.EndAPGAHFFLAPA(builder);
  }

  public static void StartAPGAHFFLAPA(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddNCIKNCJLFBI(FlatBufferBuilder builder, uint NCIKNCJLFBI) { builder.AddUint(0, NCIKNCJLFBI, 0); }
  public static void AddCOPFAKAHEMN(FlatBufferBuilder builder, uint COPFAKAHEMN) { builder.AddUint(1, COPFAKAHEMN, 0); }
  public static void AddHLPHBGLMBIO(FlatBufferBuilder builder, uint HLPHBGLMBIO) { builder.AddUint(2, HLPHBGLMBIO, 0); }
  public static void AddLPJPOOHJKAE(FlatBufferBuilder builder, uint LPJPOOHJKAE) { builder.AddUint(3, LPJPOOHJKAE, 0); }
  public static void AddCHGIONDFIKP(FlatBufferBuilder builder, VectorOffset CHGIONDFIKPOffset) { builder.AddOffset(4, CHGIONDFIKPOffset.Value, 0); }
  public static VectorOffset CreateCHGIONDFIKPVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartCHGIONDFIKPVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddMGHHDHFMOPF(FlatBufferBuilder builder, int MGHHDHFMOPF) { builder.AddInt(5, MGHHDHFMOPF, 0); }
  public static Offset<APGAHFFLAPA> EndAPGAHFFLAPA(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<APGAHFFLAPA>(o);
  }
};
