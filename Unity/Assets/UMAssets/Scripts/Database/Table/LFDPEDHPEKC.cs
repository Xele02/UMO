// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class LFDPEDHPEKC : Table {
  public static LFDPEDHPEKC GetRootAsLFDPEDHPEKC(ByteBuffer _bb) { return GetRootAsLFDPEDHPEKC(_bb, new LFDPEDHPEKC()); }
  public static LFDPEDHPEKC GetRootAsLFDPEDHPEKC(ByteBuffer _bb, LFDPEDHPEKC obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public LFDPEDHPEKC __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int CFLMCGOJJJD { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public string NNKLANONDOM { get { int o = __offset(8); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetNNKLANONDOMBytes() { return __vector_as_arraysegment(8); }
  public int NJLJEKDBPCH { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int IPHMJNCEPIJ { get { int o = __offset(12); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int BNFLNMGOJCM { get { int o = __offset(14); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<LFDPEDHPEKC> CreateLFDPEDHPEKC(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int CFLMCGOJJJD = 0,
      StringOffset NNKLANONDOMOffset = default(StringOffset),
      int NJLJEKDBPCH = 0,
      int IPHMJNCEPIJ = 0,
      int BNFLNMGOJCM = 0) {
    builder.StartObject(6);
    LFDPEDHPEKC.AddBNFLNMGOJCM(builder, BNFLNMGOJCM);
    LFDPEDHPEKC.AddIPHMJNCEPIJ(builder, IPHMJNCEPIJ);
    LFDPEDHPEKC.AddNJLJEKDBPCH(builder, NJLJEKDBPCH);
    LFDPEDHPEKC.AddNNKLANONDOM(builder, NNKLANONDOMOffset);
    LFDPEDHPEKC.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    LFDPEDHPEKC.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return LFDPEDHPEKC.EndLFDPEDHPEKC(builder);
  }

  public static void StartLFDPEDHPEKC(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, int CFLMCGOJJJD) { builder.AddInt(1, CFLMCGOJJJD, 0); }
  public static void AddNNKLANONDOM(FlatBufferBuilder builder, StringOffset NNKLANONDOMOffset) { builder.AddOffset(2, NNKLANONDOMOffset.Value, 0); }
  public static void AddNJLJEKDBPCH(FlatBufferBuilder builder, int NJLJEKDBPCH) { builder.AddInt(3, NJLJEKDBPCH, 0); }
  public static void AddIPHMJNCEPIJ(FlatBufferBuilder builder, int IPHMJNCEPIJ) { builder.AddInt(4, IPHMJNCEPIJ, 0); }
  public static void AddBNFLNMGOJCM(FlatBufferBuilder builder, int BNFLNMGOJCM) { builder.AddInt(5, BNFLNMGOJCM, 0); }
  public static Offset<LFDPEDHPEKC> EndLFDPEDHPEKC(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<LFDPEDHPEKC>(o);
  }
};

