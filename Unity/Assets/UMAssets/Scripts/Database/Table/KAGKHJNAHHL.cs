// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class KAGKHJNAHHL : Table {
  public static KAGKHJNAHHL GetRootAsKAGKHJNAHHL(ByteBuffer _bb) { return GetRootAsKAGKHJNAHHL(_bb, new KAGKHJNAHHL()); }
  public static KAGKHJNAHHL GetRootAsKAGKHJNAHHL(ByteBuffer _bb, KAGKHJNAHHL obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public KAGKHJNAHHL __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int MCJNHPMBPIJ { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int MGJKFKDICGC { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<KAGKHJNAHHL> CreateKAGKHJNAHHL(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int MCJNHPMBPIJ = 0,
      int MGJKFKDICGC = 0) {
    builder.StartObject(3);
    KAGKHJNAHHL.AddMGJKFKDICGC(builder, MGJKFKDICGC);
    KAGKHJNAHHL.AddMCJNHPMBPIJ(builder, MCJNHPMBPIJ);
    KAGKHJNAHHL.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return KAGKHJNAHHL.EndKAGKHJNAHHL(builder);
  }

  public static void StartKAGKHJNAHHL(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddMCJNHPMBPIJ(FlatBufferBuilder builder, int MCJNHPMBPIJ) { builder.AddInt(1, MCJNHPMBPIJ, 0); }
  public static void AddMGJKFKDICGC(FlatBufferBuilder builder, int MGJKFKDICGC) { builder.AddInt(2, MGJKFKDICGC, 0); }
  public static Offset<KAGKHJNAHHL> EndKAGKHJNAHHL(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<KAGKHJNAHHL>(o);
  }
};

