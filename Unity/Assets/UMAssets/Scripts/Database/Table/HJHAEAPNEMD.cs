// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class HJHAEAPNEMD : Table {
  public static HJHAEAPNEMD GetRootAsHJHAEAPNEMD(ByteBuffer _bb) { return GetRootAsHJHAEAPNEMD(_bb, new HJHAEAPNEMD()); }
  public static HJHAEAPNEMD GetRootAsHJHAEAPNEMD(ByteBuffer _bb, HJHAEAPNEMD obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public HJHAEAPNEMD __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int OFMGALJGDAO { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int CFLMCGOJJJD { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int NJLJEKDBPCH { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int IPHMJNCEPIJ { get { int o = __offset(12); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int JFJCBFNEOAB { get { int o = __offset(14); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int GPLJLPKJPAM { get { int o = __offset(16); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int DKMLEDJJFOI { get { int o = __offset(18); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int LPJPOOHJKAE { get { int o = __offset(20); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int KJFEBMBHKOC { get { int o = __offset(22); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<HJHAEAPNEMD> CreateHJHAEAPNEMD(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int OFMGALJGDAO = 0,
      int CFLMCGOJJJD = 0,
      int NJLJEKDBPCH = 0,
      int IPHMJNCEPIJ = 0,
      int JFJCBFNEOAB = 0,
      int GPLJLPKJPAM = 0,
      int DKMLEDJJFOI = 0,
      int LPJPOOHJKAE = 0,
      int KJFEBMBHKOC = 0) {
    builder.StartObject(10);
    HJHAEAPNEMD.AddKJFEBMBHKOC(builder, KJFEBMBHKOC);
    HJHAEAPNEMD.AddLPJPOOHJKAE(builder, LPJPOOHJKAE);
    HJHAEAPNEMD.AddDKMLEDJJFOI(builder, DKMLEDJJFOI);
    HJHAEAPNEMD.AddGPLJLPKJPAM(builder, GPLJLPKJPAM);
    HJHAEAPNEMD.AddJFJCBFNEOAB(builder, JFJCBFNEOAB);
    HJHAEAPNEMD.AddIPHMJNCEPIJ(builder, IPHMJNCEPIJ);
    HJHAEAPNEMD.AddNJLJEKDBPCH(builder, NJLJEKDBPCH);
    HJHAEAPNEMD.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    HJHAEAPNEMD.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    HJHAEAPNEMD.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return HJHAEAPNEMD.EndHJHAEAPNEMD(builder);
  }

  public static void StartHJHAEAPNEMD(FlatBufferBuilder builder) { builder.StartObject(10); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(1, OFMGALJGDAO, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, int CFLMCGOJJJD) { builder.AddInt(2, CFLMCGOJJJD, 0); }
  public static void AddNJLJEKDBPCH(FlatBufferBuilder builder, int NJLJEKDBPCH) { builder.AddInt(3, NJLJEKDBPCH, 0); }
  public static void AddIPHMJNCEPIJ(FlatBufferBuilder builder, int IPHMJNCEPIJ) { builder.AddInt(4, IPHMJNCEPIJ, 0); }
  public static void AddJFJCBFNEOAB(FlatBufferBuilder builder, int JFJCBFNEOAB) { builder.AddInt(5, JFJCBFNEOAB, 0); }
  public static void AddGPLJLPKJPAM(FlatBufferBuilder builder, int GPLJLPKJPAM) { builder.AddInt(6, GPLJLPKJPAM, 0); }
  public static void AddDKMLEDJJFOI(FlatBufferBuilder builder, int DKMLEDJJFOI) { builder.AddInt(7, DKMLEDJJFOI, 0); }
  public static void AddLPJPOOHJKAE(FlatBufferBuilder builder, int LPJPOOHJKAE) { builder.AddInt(8, LPJPOOHJKAE, 0); }
  public static void AddKJFEBMBHKOC(FlatBufferBuilder builder, int KJFEBMBHKOC) { builder.AddInt(9, KJFEBMBHKOC, 0); }
  public static Offset<HJHAEAPNEMD> EndHJHAEAPNEMD(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<HJHAEAPNEMD>(o);
  }
};

