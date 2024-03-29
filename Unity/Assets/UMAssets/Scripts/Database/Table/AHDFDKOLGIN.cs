// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class AHDFDKOLGIN : Table {
  public static AHDFDKOLGIN GetRootAsAHDFDKOLGIN(ByteBuffer _bb) { return GetRootAsAHDFDKOLGIN(_bb, new AHDFDKOLGIN()); }
  public static AHDFDKOLGIN GetRootAsAHDFDKOLGIN(ByteBuffer _bb, AHDFDKOLGIN obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public AHDFDKOLGIN __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GetLEFPIGNDJNC(int j) { int o = __offset(6); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int LEFPIGNDJNCLength { get { int o = __offset(6); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetLEFPIGNDJNCBytes() { return __vector_as_arraysegment(6); }
  public uint GetBNCIPLKECMC(int j) { int o = __offset(8); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int BNCIPLKECMCLength { get { int o = __offset(8); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetBNCIPLKECMCBytes() { return __vector_as_arraysegment(8); }
  public uint GetNGGAJCBPGFI(int j) { int o = __offset(10); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int NGGAJCBPGFILength { get { int o = __offset(10); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetNGGAJCBPGFIBytes() { return __vector_as_arraysegment(10); }
  public uint GetNMEEJNHKPCN(int j) { int o = __offset(12); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int NMEEJNHKPCNLength { get { int o = __offset(12); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetNMEEJNHKPCNBytes() { return __vector_as_arraysegment(12); }
  public uint GetDOLNFDOMJBC(int j) { int o = __offset(14); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int DOLNFDOMJBCLength { get { int o = __offset(14); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetDOLNFDOMJBCBytes() { return __vector_as_arraysegment(14); }

  public static Offset<AHDFDKOLGIN> CreateAHDFDKOLGIN(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      VectorOffset LEFPIGNDJNCOffset = default(VectorOffset),
      VectorOffset BNCIPLKECMCOffset = default(VectorOffset),
      VectorOffset NGGAJCBPGFIOffset = default(VectorOffset),
      VectorOffset NMEEJNHKPCNOffset = default(VectorOffset),
      VectorOffset DOLNFDOMJBCOffset = default(VectorOffset)) {
    builder.StartObject(6);
    AHDFDKOLGIN.AddDOLNFDOMJBC(builder, DOLNFDOMJBCOffset);
    AHDFDKOLGIN.AddNMEEJNHKPCN(builder, NMEEJNHKPCNOffset);
    AHDFDKOLGIN.AddNGGAJCBPGFI(builder, NGGAJCBPGFIOffset);
    AHDFDKOLGIN.AddBNCIPLKECMC(builder, BNCIPLKECMCOffset);
    AHDFDKOLGIN.AddLEFPIGNDJNC(builder, LEFPIGNDJNCOffset);
    AHDFDKOLGIN.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return AHDFDKOLGIN.EndAHDFDKOLGIN(builder);
  }

  public static void StartAHDFDKOLGIN(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddLEFPIGNDJNC(FlatBufferBuilder builder, VectorOffset LEFPIGNDJNCOffset) { builder.AddOffset(1, LEFPIGNDJNCOffset.Value, 0); }
  public static VectorOffset CreateLEFPIGNDJNCVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartLEFPIGNDJNCVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddBNCIPLKECMC(FlatBufferBuilder builder, VectorOffset BNCIPLKECMCOffset) { builder.AddOffset(2, BNCIPLKECMCOffset.Value, 0); }
  public static VectorOffset CreateBNCIPLKECMCVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartBNCIPLKECMCVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNGGAJCBPGFI(FlatBufferBuilder builder, VectorOffset NGGAJCBPGFIOffset) { builder.AddOffset(3, NGGAJCBPGFIOffset.Value, 0); }
  public static VectorOffset CreateNGGAJCBPGFIVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartNGGAJCBPGFIVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNMEEJNHKPCN(FlatBufferBuilder builder, VectorOffset NMEEJNHKPCNOffset) { builder.AddOffset(4, NMEEJNHKPCNOffset.Value, 0); }
  public static VectorOffset CreateNMEEJNHKPCNVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartNMEEJNHKPCNVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddDOLNFDOMJBC(FlatBufferBuilder builder, VectorOffset DOLNFDOMJBCOffset) { builder.AddOffset(5, DOLNFDOMJBCOffset.Value, 0); }
  public static VectorOffset CreateDOLNFDOMJBCVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartDOLNFDOMJBCVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<AHDFDKOLGIN> EndAHDFDKOLGIN(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<AHDFDKOLGIN>(o);
  }
};

