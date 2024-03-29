// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class LHNCOEINPJB : Table {
  public static LHNCOEINPJB GetRootAsLHNCOEINPJB(ByteBuffer _bb) { return GetRootAsLHNCOEINPJB(_bb, new LHNCOEINPJB()); }
  public static LHNCOEINPJB GetRootAsLHNCOEINPJB(ByteBuffer _bb, LHNCOEINPJB obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public LHNCOEINPJB __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint CFLMCGOJJJD { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GetGPELFPEHLMD(int j) { int o = __offset(8); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int GPELFPEHLMDLength { get { int o = __offset(8); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetGPELFPEHLMDBytes() { return __vector_as_arraysegment(8); }
  public uint GetEODLLIMCLLH(int j) { int o = __offset(10); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int EODLLIMCLLHLength { get { int o = __offset(10); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetEODLLIMCLLHBytes() { return __vector_as_arraysegment(10); }
  public uint NJLJEKDBPCH { get { int o = __offset(12); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint MAOAGDBDBIB { get { int o = __offset(14); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }

  public static Offset<LHNCOEINPJB> CreateLHNCOEINPJB(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      uint CFLMCGOJJJD = 0,
      VectorOffset GPELFPEHLMDOffset = default(VectorOffset),
      VectorOffset EODLLIMCLLHOffset = default(VectorOffset),
      uint NJLJEKDBPCH = 0,
      uint MAOAGDBDBIB = 0) {
    builder.StartObject(6);
    LHNCOEINPJB.AddMAOAGDBDBIB(builder, MAOAGDBDBIB);
    LHNCOEINPJB.AddNJLJEKDBPCH(builder, NJLJEKDBPCH);
    LHNCOEINPJB.AddEODLLIMCLLH(builder, EODLLIMCLLHOffset);
    LHNCOEINPJB.AddGPELFPEHLMD(builder, GPELFPEHLMDOffset);
    LHNCOEINPJB.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    LHNCOEINPJB.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return LHNCOEINPJB.EndLHNCOEINPJB(builder);
  }

  public static void StartLHNCOEINPJB(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, uint CFLMCGOJJJD) { builder.AddUint(1, CFLMCGOJJJD, 0); }
  public static void AddGPELFPEHLMD(FlatBufferBuilder builder, VectorOffset GPELFPEHLMDOffset) { builder.AddOffset(2, GPELFPEHLMDOffset.Value, 0); }
  public static VectorOffset CreateGPELFPEHLMDVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartGPELFPEHLMDVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddEODLLIMCLLH(FlatBufferBuilder builder, VectorOffset EODLLIMCLLHOffset) { builder.AddOffset(3, EODLLIMCLLHOffset.Value, 0); }
  public static VectorOffset CreateEODLLIMCLLHVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartEODLLIMCLLHVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNJLJEKDBPCH(FlatBufferBuilder builder, uint NJLJEKDBPCH) { builder.AddUint(4, NJLJEKDBPCH, 0); }
  public static void AddMAOAGDBDBIB(FlatBufferBuilder builder, uint MAOAGDBDBIB) { builder.AddUint(5, MAOAGDBDBIB, 0); }
  public static Offset<LHNCOEINPJB> EndLHNCOEINPJB(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<LHNCOEINPJB>(o);
  }
};

