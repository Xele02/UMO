// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class BEHBIEJAFJL : Table {
  public static BEHBIEJAFJL GetRootAsBEHBIEJAFJL(ByteBuffer _bb) { return GetRootAsBEHBIEJAFJL(_bb, new BEHBIEJAFJL()); }
  public static BEHBIEJAFJL GetRootAsBEHBIEJAFJL(ByteBuffer _bb, BEHBIEJAFJL obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public BEHBIEJAFJL __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string AGOIMGHMGOH { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetAGOIMGHMGOHBytes() { return __vector_as_arraysegment(4); }
  public string KJFEBMBHKOC { get { int o = __offset(6); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetKJFEBMBHKOCBytes() { return __vector_as_arraysegment(6); }

  public static Offset<BEHBIEJAFJL> CreateBEHBIEJAFJL(FlatBufferBuilder builder,
      StringOffset AGOIMGHMGOHOffset = default(StringOffset),
      StringOffset KJFEBMBHKOCOffset = default(StringOffset)) {
    builder.StartObject(2);
    BEHBIEJAFJL.AddKJFEBMBHKOC(builder, KJFEBMBHKOCOffset);
    BEHBIEJAFJL.AddAGOIMGHMGOH(builder, AGOIMGHMGOHOffset);
    return BEHBIEJAFJL.EndBEHBIEJAFJL(builder);
  }

  public static void StartBEHBIEJAFJL(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddAGOIMGHMGOH(FlatBufferBuilder builder, StringOffset AGOIMGHMGOHOffset) { builder.AddOffset(0, AGOIMGHMGOHOffset.Value, 0); }
  public static void AddKJFEBMBHKOC(FlatBufferBuilder builder, StringOffset KJFEBMBHKOCOffset) { builder.AddOffset(1, KJFEBMBHKOCOffset.Value, 0); }
  public static Offset<BEHBIEJAFJL> EndBEHBIEJAFJL(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<BEHBIEJAFJL>(o);
  }
};

