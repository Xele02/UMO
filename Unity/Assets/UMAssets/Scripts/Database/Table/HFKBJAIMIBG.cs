// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class HFKBJAIMIBG : Table {
  public static HFKBJAIMIBG GetRootAsHFKBJAIMIBG(ByteBuffer _bb) { return GetRootAsHFKBJAIMIBG(_bb, new HFKBJAIMIBG()); }
  public static HFKBJAIMIBG GetRootAsHFKBJAIMIBG(ByteBuffer _bb, HFKBJAIMIBG obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public HFKBJAIMIBG __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int GJEJFAJHBME { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int COPFAKAHEMN { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<HFKBJAIMIBG> CreateHFKBJAIMIBG(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int GJEJFAJHBME = 0,
      int COPFAKAHEMN = 0) {
    builder.StartObject(3);
    HFKBJAIMIBG.AddCOPFAKAHEMN(builder, COPFAKAHEMN);
    HFKBJAIMIBG.AddGJEJFAJHBME(builder, GJEJFAJHBME);
    HFKBJAIMIBG.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return HFKBJAIMIBG.EndHFKBJAIMIBG(builder);
  }

  public static void StartHFKBJAIMIBG(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddGJEJFAJHBME(FlatBufferBuilder builder, int GJEJFAJHBME) { builder.AddInt(1, GJEJFAJHBME, 0); }
  public static void AddCOPFAKAHEMN(FlatBufferBuilder builder, int COPFAKAHEMN) { builder.AddInt(2, COPFAKAHEMN, 0); }
  public static Offset<HFKBJAIMIBG> EndHFKBJAIMIBG(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<HFKBJAIMIBG>(o);
  }
};

