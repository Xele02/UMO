// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class CDCEKBNNJLL : Table {
  public static CDCEKBNNJLL GetRootAsCDCEKBNNJLL(ByteBuffer _bb) { return GetRootAsCDCEKBNNJLL(_bb, new CDCEKBNNJLL()); }
  public static CDCEKBNNJLL GetRootAsCDCEKBNNJLL(ByteBuffer _bb, CDCEKBNNJLL obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public CDCEKBNNJLL __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint GetLEFPIGNDJNC(int j) { int o = __offset(4); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int LEFPIGNDJNCLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetLEFPIGNDJNCBytes() { return __vector_as_arraysegment(4); }
  public uint LNHODOPAJIL { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }

  public static Offset<CDCEKBNNJLL> CreateCDCEKBNNJLL(FlatBufferBuilder builder,
      VectorOffset LEFPIGNDJNCOffset = default(VectorOffset),
      uint LNHODOPAJIL = 0) {
    builder.StartObject(2);
    CDCEKBNNJLL.AddLNHODOPAJIL(builder, LNHODOPAJIL);
    CDCEKBNNJLL.AddLEFPIGNDJNC(builder, LEFPIGNDJNCOffset);
    return CDCEKBNNJLL.EndCDCEKBNNJLL(builder);
  }

  public static void StartCDCEKBNNJLL(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddLEFPIGNDJNC(FlatBufferBuilder builder, VectorOffset LEFPIGNDJNCOffset) { builder.AddOffset(0, LEFPIGNDJNCOffset.Value, 0); }
  public static VectorOffset CreateLEFPIGNDJNCVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartLEFPIGNDJNCVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddLNHODOPAJIL(FlatBufferBuilder builder, uint LNHODOPAJIL) { builder.AddUint(1, LNHODOPAJIL, 0); }
  public static Offset<CDCEKBNNJLL> EndCDCEKBNNJLL(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<CDCEKBNNJLL>(o);
  }
};
