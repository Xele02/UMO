// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class FJNOJOMGGKJ : Table {
  public static FJNOJOMGGKJ GetRootAsFJNOJOMGGKJ(ByteBuffer _bb) { return GetRootAsFJNOJOMGGKJ(_bb, new FJNOJOMGGKJ()); }
  public static FJNOJOMGGKJ GetRootAsFJNOJOMGGKJ(ByteBuffer _bb, FJNOJOMGGKJ obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public FJNOJOMGGKJ __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int OFMGALJGDAO { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int CFLMCGOJJJD { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int NJLJEKDBPCH { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int MAOAGDBDBIB { get { int o = __offset(12); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int BDGDHOAJDFM { get { int o = __offset(14); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int NCADHENBLDB { get { int o = __offset(16); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<FJNOJOMGGKJ> CreateFJNOJOMGGKJ(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int OFMGALJGDAO = 0,
      int CFLMCGOJJJD = 0,
      int NJLJEKDBPCH = 0,
      int MAOAGDBDBIB = 0,
      int BDGDHOAJDFM = 0,
      int NCADHENBLDB = 0) {
    builder.StartObject(7);
    FJNOJOMGGKJ.AddNCADHENBLDB(builder, NCADHENBLDB);
    FJNOJOMGGKJ.AddBDGDHOAJDFM(builder, BDGDHOAJDFM);
    FJNOJOMGGKJ.AddMAOAGDBDBIB(builder, MAOAGDBDBIB);
    FJNOJOMGGKJ.AddNJLJEKDBPCH(builder, NJLJEKDBPCH);
    FJNOJOMGGKJ.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    FJNOJOMGGKJ.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    FJNOJOMGGKJ.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return FJNOJOMGGKJ.EndFJNOJOMGGKJ(builder);
  }

  public static void StartFJNOJOMGGKJ(FlatBufferBuilder builder) { builder.StartObject(7); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(1, OFMGALJGDAO, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, int CFLMCGOJJJD) { builder.AddInt(2, CFLMCGOJJJD, 0); }
  public static void AddNJLJEKDBPCH(FlatBufferBuilder builder, int NJLJEKDBPCH) { builder.AddInt(3, NJLJEKDBPCH, 0); }
  public static void AddMAOAGDBDBIB(FlatBufferBuilder builder, int MAOAGDBDBIB) { builder.AddInt(4, MAOAGDBDBIB, 0); }
  public static void AddBDGDHOAJDFM(FlatBufferBuilder builder, int BDGDHOAJDFM) { builder.AddInt(5, BDGDHOAJDFM, 0); }
  public static void AddNCADHENBLDB(FlatBufferBuilder builder, int NCADHENBLDB) { builder.AddInt(6, NCADHENBLDB, 0); }
  public static Offset<FJNOJOMGGKJ> EndFJNOJOMGGKJ(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FJNOJOMGGKJ>(o);
  }
};
