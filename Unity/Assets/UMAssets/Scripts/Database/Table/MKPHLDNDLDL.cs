// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class MKPHLDNDLDL : Table {
  public static MKPHLDNDLDL GetRootAsMKPHLDNDLDL(ByteBuffer _bb) { return GetRootAsMKPHLDNDLDL(_bb, new MKPHLDNDLDL()); }
  public static MKPHLDNDLDL GetRootAsMKPHLDNDLDL(ByteBuffer _bb, MKPHLDNDLDL obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public MKPHLDNDLDL __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint ODBPKGJPLMD { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint KJFEBMBHKOC { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint LPJPOOHJKAE { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }

  public static Offset<MKPHLDNDLDL> CreateMKPHLDNDLDL(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      uint ODBPKGJPLMD = 0,
      uint KJFEBMBHKOC = 0,
      uint LPJPOOHJKAE = 0) {
    builder.StartObject(4);
    MKPHLDNDLDL.AddLPJPOOHJKAE(builder, LPJPOOHJKAE);
    MKPHLDNDLDL.AddKJFEBMBHKOC(builder, KJFEBMBHKOC);
    MKPHLDNDLDL.AddODBPKGJPLMD(builder, ODBPKGJPLMD);
    MKPHLDNDLDL.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return MKPHLDNDLDL.EndMKPHLDNDLDL(builder);
  }

  public static void StartMKPHLDNDLDL(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddODBPKGJPLMD(FlatBufferBuilder builder, uint ODBPKGJPLMD) { builder.AddUint(1, ODBPKGJPLMD, 0); }
  public static void AddKJFEBMBHKOC(FlatBufferBuilder builder, uint KJFEBMBHKOC) { builder.AddUint(2, KJFEBMBHKOC, 0); }
  public static void AddLPJPOOHJKAE(FlatBufferBuilder builder, uint LPJPOOHJKAE) { builder.AddUint(3, LPJPOOHJKAE, 0); }
  public static Offset<MKPHLDNDLDL> EndMKPHLDNDLDL(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<MKPHLDNDLDL>(o);
  }
};

