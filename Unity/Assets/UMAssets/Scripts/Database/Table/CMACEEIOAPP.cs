// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class CMACEEIOAPP : Table {
  public static CMACEEIOAPP GetRootAsCMACEEIOAPP(ByteBuffer _bb) { return GetRootAsCMACEEIOAPP(_bb, new CMACEEIOAPP()); }
  public static CMACEEIOAPP GetRootAsCMACEEIOAPP(ByteBuffer _bb, CMACEEIOAPP obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public CMACEEIOAPP __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int OFMGALJGDAO { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int CFLMCGOJJJD { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int EBPIAGLECII { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int NJLJEKDBPCH { get { int o = __offset(12); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int MAOAGDBDBIB { get { int o = __offset(14); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<CMACEEIOAPP> CreateCMACEEIOAPP(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int OFMGALJGDAO = 0,
      int CFLMCGOJJJD = 0,
      int EBPIAGLECII = 0,
      int NJLJEKDBPCH = 0,
      int MAOAGDBDBIB = 0) {
    builder.StartObject(6);
    CMACEEIOAPP.AddMAOAGDBDBIB(builder, MAOAGDBDBIB);
    CMACEEIOAPP.AddNJLJEKDBPCH(builder, NJLJEKDBPCH);
    CMACEEIOAPP.AddEBPIAGLECII(builder, EBPIAGLECII);
    CMACEEIOAPP.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    CMACEEIOAPP.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    CMACEEIOAPP.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return CMACEEIOAPP.EndCMACEEIOAPP(builder);
  }

  public static void StartCMACEEIOAPP(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(1, OFMGALJGDAO, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, int CFLMCGOJJJD) { builder.AddInt(2, CFLMCGOJJJD, 0); }
  public static void AddEBPIAGLECII(FlatBufferBuilder builder, int EBPIAGLECII) { builder.AddInt(3, EBPIAGLECII, 0); }
  public static void AddNJLJEKDBPCH(FlatBufferBuilder builder, int NJLJEKDBPCH) { builder.AddInt(4, NJLJEKDBPCH, 0); }
  public static void AddMAOAGDBDBIB(FlatBufferBuilder builder, int MAOAGDBDBIB) { builder.AddInt(5, MAOAGDBDBIB, 0); }
  public static Offset<CMACEEIOAPP> EndCMACEEIOAPP(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<CMACEEIOAPP>(o);
  }
};

