// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class GGCGMFLDFMA : Table {
  public static GGCGMFLDFMA GetRootAsGGCGMFLDFMA(ByteBuffer _bb) { return GetRootAsGGCGMFLDFMA(_bb, new GGCGMFLDFMA()); }
  public static GGCGMFLDFMA GetRootAsGGCGMFLDFMA(ByteBuffer _bb, GGCGMFLDFMA obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public GGCGMFLDFMA __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public string IIDCFMHCPLJ { get { int o = __offset(6); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetIIDCFMHCPLJBytes() { return __vector_as_arraysegment(6); }
  public int IBDFJIDNDJH { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int OFMGALJGDAO { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<GGCGMFLDFMA> CreateGGCGMFLDFMA(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      StringOffset IIDCFMHCPLJOffset = default(StringOffset),
      int IBDFJIDNDJH = 0,
      int OFMGALJGDAO = 0) {
    builder.StartObject(4);
    GGCGMFLDFMA.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    GGCGMFLDFMA.AddIBDFJIDNDJH(builder, IBDFJIDNDJH);
    GGCGMFLDFMA.AddIIDCFMHCPLJ(builder, IIDCFMHCPLJOffset);
    GGCGMFLDFMA.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return GGCGMFLDFMA.EndGGCGMFLDFMA(builder);
  }

  public static void StartGGCGMFLDFMA(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddIIDCFMHCPLJ(FlatBufferBuilder builder, StringOffset IIDCFMHCPLJOffset) { builder.AddOffset(1, IIDCFMHCPLJOffset.Value, 0); }
  public static void AddIBDFJIDNDJH(FlatBufferBuilder builder, int IBDFJIDNDJH) { builder.AddInt(2, IBDFJIDNDJH, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(3, OFMGALJGDAO, 0); }
  public static Offset<GGCGMFLDFMA> EndGGCGMFLDFMA(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GGCGMFLDFMA>(o);
  }
};

