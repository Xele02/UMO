// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class JFGEKMJJBAO : Table {
  public static JFGEKMJJBAO GetRootAsJFGEKMJJBAO(ByteBuffer _bb) { return GetRootAsJFGEKMJJBAO(_bb, new JFGEKMJJBAO()); }
  public static JFGEKMJJBAO GetRootAsJFGEKMJJBAO(ByteBuffer _bb, JFGEKMJJBAO obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public JFGEKMJJBAO __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint AOLCNACKIBK { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint AECGHGOLNKL { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint KJFEBMBHKOC { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }

  public static Offset<JFGEKMJJBAO> CreateJFGEKMJJBAO(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      uint AOLCNACKIBK = 0,
      uint AECGHGOLNKL = 0,
      uint KJFEBMBHKOC = 0) {
    builder.StartObject(4);
    JFGEKMJJBAO.AddKJFEBMBHKOC(builder, KJFEBMBHKOC);
    JFGEKMJJBAO.AddAECGHGOLNKL(builder, AECGHGOLNKL);
    JFGEKMJJBAO.AddAOLCNACKIBK(builder, AOLCNACKIBK);
    JFGEKMJJBAO.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return JFGEKMJJBAO.EndJFGEKMJJBAO(builder);
  }

  public static void StartJFGEKMJJBAO(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddAOLCNACKIBK(FlatBufferBuilder builder, uint AOLCNACKIBK) { builder.AddUint(1, AOLCNACKIBK, 0); }
  public static void AddAECGHGOLNKL(FlatBufferBuilder builder, uint AECGHGOLNKL) { builder.AddUint(2, AECGHGOLNKL, 0); }
  public static void AddKJFEBMBHKOC(FlatBufferBuilder builder, uint KJFEBMBHKOC) { builder.AddUint(3, KJFEBMBHKOC, 0); }
  public static Offset<JFGEKMJJBAO> EndJFGEKMJJBAO(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<JFGEKMJJBAO>(o);
  }
};

