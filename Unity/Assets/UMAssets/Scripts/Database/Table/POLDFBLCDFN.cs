// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class POLDFBLCDFN : Table {
  public static POLDFBLCDFN GetRootAsPOLDFBLCDFN(ByteBuffer _bb) { return GetRootAsPOLDFBLCDFN(_bb, new POLDFBLCDFN()); }
  public static POLDFBLCDFN GetRootAsPOLDFBLCDFN(ByteBuffer _bb, POLDFBLCDFN obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public POLDFBLCDFN __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int DNIDLBOLLGH { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int GetKMKKKKNNFGB(int j) { int o = __offset(6); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int KMKKKKNNFGBLength { get { int o = __offset(6); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetKMKKKKNNFGBBytes() { return __vector_as_arraysegment(6); }
  public int GetNDOLMCLBIBF(int j) { int o = __offset(8); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int NDOLMCLBIBFLength { get { int o = __offset(8); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetNDOLMCLBIBFBytes() { return __vector_as_arraysegment(8); }

  public static Offset<POLDFBLCDFN> CreatePOLDFBLCDFN(FlatBufferBuilder builder,
      int DNIDLBOLLGH = 0,
      VectorOffset KMKKKKNNFGBOffset = default(VectorOffset),
      VectorOffset NDOLMCLBIBFOffset = default(VectorOffset)) {
    builder.StartObject(3);
    POLDFBLCDFN.AddNDOLMCLBIBF(builder, NDOLMCLBIBFOffset);
    POLDFBLCDFN.AddKMKKKKNNFGB(builder, KMKKKKNNFGBOffset);
    POLDFBLCDFN.AddDNIDLBOLLGH(builder, DNIDLBOLLGH);
    return POLDFBLCDFN.EndPOLDFBLCDFN(builder);
  }

  public static void StartPOLDFBLCDFN(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddDNIDLBOLLGH(FlatBufferBuilder builder, int DNIDLBOLLGH) { builder.AddInt(0, DNIDLBOLLGH, 0); }
  public static void AddKMKKKKNNFGB(FlatBufferBuilder builder, VectorOffset KMKKKKNNFGBOffset) { builder.AddOffset(1, KMKKKKNNFGBOffset.Value, 0); }
  public static VectorOffset CreateKMKKKKNNFGBVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartKMKKKKNNFGBVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNDOLMCLBIBF(FlatBufferBuilder builder, VectorOffset NDOLMCLBIBFOffset) { builder.AddOffset(2, NDOLMCLBIBFOffset.Value, 0); }
  public static VectorOffset CreateNDOLMCLBIBFVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartNDOLMCLBIBFVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<POLDFBLCDFN> EndPOLDFBLCDFN(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<POLDFBLCDFN>(o);
  }
};
