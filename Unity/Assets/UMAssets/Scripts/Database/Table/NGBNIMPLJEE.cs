// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class NGBNIMPLJEE : Table {
  public static NGBNIMPLJEE GetRootAsNGBNIMPLJEE(ByteBuffer _bb) { return GetRootAsNGBNIMPLJEE(_bb, new NGBNIMPLJEE()); }
  public static NGBNIMPLJEE GetRootAsNGBNIMPLJEE(ByteBuffer _bb, NGBNIMPLJEE obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public NGBNIMPLJEE __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int OFMGALJGDAO { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int CFLMCGOJJJD { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int JCIIGMCDKAH { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<NGBNIMPLJEE> CreateNGBNIMPLJEE(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int OFMGALJGDAO = 0,
      int CFLMCGOJJJD = 0,
      int JCIIGMCDKAH = 0) {
    builder.StartObject(4);
    NGBNIMPLJEE.AddJCIIGMCDKAH(builder, JCIIGMCDKAH);
    NGBNIMPLJEE.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    NGBNIMPLJEE.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    NGBNIMPLJEE.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return NGBNIMPLJEE.EndNGBNIMPLJEE(builder);
  }

  public static void StartNGBNIMPLJEE(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(1, OFMGALJGDAO, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, int CFLMCGOJJJD) { builder.AddInt(2, CFLMCGOJJJD, 0); }
  public static void AddJCIIGMCDKAH(FlatBufferBuilder builder, int JCIIGMCDKAH) { builder.AddInt(3, JCIIGMCDKAH, 0); }
  public static Offset<NGBNIMPLJEE> EndNGBNIMPLJEE(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<NGBNIMPLJEE>(o);
  }
};

