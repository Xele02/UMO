// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class FDCDAOBKLBM : Table {
  public static FDCDAOBKLBM GetRootAsFDCDAOBKLBM(ByteBuffer _bb) { return GetRootAsFDCDAOBKLBM(_bb, new FDCDAOBKLBM()); }
  public static FDCDAOBKLBM GetRootAsFDCDAOBKLBM(ByteBuffer _bb, FDCDAOBKLBM obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public FDCDAOBKLBM __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int GFAJCKHBDHL { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int OFMGALJGDAO { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int CFLMCGOJJJD { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int ACHEDGADKFF { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<FDCDAOBKLBM> CreateFDCDAOBKLBM(FlatBufferBuilder builder,
      int GFAJCKHBDHL = 0,
      int OFMGALJGDAO = 0,
      int CFLMCGOJJJD = 0,
      int ACHEDGADKFF = 0) {
    builder.StartObject(4);
    FDCDAOBKLBM.AddACHEDGADKFF(builder, ACHEDGADKFF);
    FDCDAOBKLBM.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    FDCDAOBKLBM.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    FDCDAOBKLBM.AddGFAJCKHBDHL(builder, GFAJCKHBDHL);
    return FDCDAOBKLBM.EndFDCDAOBKLBM(builder);
  }

  public static void StartFDCDAOBKLBM(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddGFAJCKHBDHL(FlatBufferBuilder builder, int GFAJCKHBDHL) { builder.AddInt(0, GFAJCKHBDHL, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(1, OFMGALJGDAO, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, int CFLMCGOJJJD) { builder.AddInt(2, CFLMCGOJJJD, 0); }
  public static void AddACHEDGADKFF(FlatBufferBuilder builder, int ACHEDGADKFF) { builder.AddInt(3, ACHEDGADKFF, 0); }
  public static Offset<FDCDAOBKLBM> EndFDCDAOBKLBM(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FDCDAOBKLBM>(o);
  }
};

