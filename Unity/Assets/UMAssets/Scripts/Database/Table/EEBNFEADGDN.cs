// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class EEBNFEADGDN : Table {
  public static EEBNFEADGDN GetRootAsEEBNFEADGDN(ByteBuffer _bb) { return GetRootAsEEBNFEADGDN(_bb, new EEBNFEADGDN()); }
  public static EEBNFEADGDN GetRootAsEEBNFEADGDN(ByteBuffer _bb, EEBNFEADGDN obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public EEBNFEADGDN __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int LPJPOOHJKAE { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int KJFEBMBHKOC { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int LAIEPFCPDLK { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<EEBNFEADGDN> CreateEEBNFEADGDN(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int LPJPOOHJKAE = 0,
      int KJFEBMBHKOC = 0,
      int LAIEPFCPDLK = 0) {
    builder.StartObject(4);
    EEBNFEADGDN.AddLAIEPFCPDLK(builder, LAIEPFCPDLK);
    EEBNFEADGDN.AddKJFEBMBHKOC(builder, KJFEBMBHKOC);
    EEBNFEADGDN.AddLPJPOOHJKAE(builder, LPJPOOHJKAE);
    EEBNFEADGDN.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return EEBNFEADGDN.EndEEBNFEADGDN(builder);
  }

  public static void StartEEBNFEADGDN(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddLPJPOOHJKAE(FlatBufferBuilder builder, int LPJPOOHJKAE) { builder.AddInt(1, LPJPOOHJKAE, 0); }
  public static void AddKJFEBMBHKOC(FlatBufferBuilder builder, int KJFEBMBHKOC) { builder.AddInt(2, KJFEBMBHKOC, 0); }
  public static void AddLAIEPFCPDLK(FlatBufferBuilder builder, int LAIEPFCPDLK) { builder.AddInt(3, LAIEPFCPDLK, 0); }
  public static Offset<EEBNFEADGDN> EndEEBNFEADGDN(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<EEBNFEADGDN>(o);
  }
};
