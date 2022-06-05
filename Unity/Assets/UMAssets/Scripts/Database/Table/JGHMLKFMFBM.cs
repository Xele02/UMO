// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class JGHMLKFMFBM : Table {
  public static JGHMLKFMFBM GetRootAsJGHMLKFMFBM(ByteBuffer _bb) { return GetRootAsJGHMLKFMFBM(_bb, new JGHMLKFMFBM()); }
  public static JGHMLKFMFBM GetRootAsJGHMLKFMFBM(ByteBuffer _bb, JGHMLKFMFBM obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public JGHMLKFMFBM __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int IOEAHIGFCBN { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int GetNKHLDNPCMDK(int j) { int o = __offset(8); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int NKHLDNPCMDKLength { get { int o = __offset(8); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetNKHLDNPCMDKBytes() { return __vector_as_arraysegment(8); }
  public int GetJHLBDFAGELJ(int j) { int o = __offset(10); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int JHLBDFAGELJLength { get { int o = __offset(10); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetJHLBDFAGELJBytes() { return __vector_as_arraysegment(10); }
  public int GetAKLEGPKGNDI(int j) { int o = __offset(12); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int AKLEGPKGNDILength { get { int o = __offset(12); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetAKLEGPKGNDIBytes() { return __vector_as_arraysegment(12); }
  public int GetADCPHBKIAOB(int j) { int o = __offset(14); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int ADCPHBKIAOBLength { get { int o = __offset(14); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetADCPHBKIAOBBytes() { return __vector_as_arraysegment(14); }

  public static Offset<JGHMLKFMFBM> CreateJGHMLKFMFBM(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int IOEAHIGFCBN = 0,
      VectorOffset NKHLDNPCMDKOffset = default(VectorOffset),
      VectorOffset JHLBDFAGELJOffset = default(VectorOffset),
      VectorOffset AKLEGPKGNDIOffset = default(VectorOffset),
      VectorOffset ADCPHBKIAOBOffset = default(VectorOffset)) {
    builder.StartObject(6);
    JGHMLKFMFBM.AddADCPHBKIAOB(builder, ADCPHBKIAOBOffset);
    JGHMLKFMFBM.AddAKLEGPKGNDI(builder, AKLEGPKGNDIOffset);
    JGHMLKFMFBM.AddJHLBDFAGELJ(builder, JHLBDFAGELJOffset);
    JGHMLKFMFBM.AddNKHLDNPCMDK(builder, NKHLDNPCMDKOffset);
    JGHMLKFMFBM.AddIOEAHIGFCBN(builder, IOEAHIGFCBN);
    JGHMLKFMFBM.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return JGHMLKFMFBM.EndJGHMLKFMFBM(builder);
  }

  public static void StartJGHMLKFMFBM(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddIOEAHIGFCBN(FlatBufferBuilder builder, int IOEAHIGFCBN) { builder.AddInt(1, IOEAHIGFCBN, 0); }
  public static void AddNKHLDNPCMDK(FlatBufferBuilder builder, VectorOffset NKHLDNPCMDKOffset) { builder.AddOffset(2, NKHLDNPCMDKOffset.Value, 0); }
  public static VectorOffset CreateNKHLDNPCMDKVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartNKHLDNPCMDKVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddJHLBDFAGELJ(FlatBufferBuilder builder, VectorOffset JHLBDFAGELJOffset) { builder.AddOffset(3, JHLBDFAGELJOffset.Value, 0); }
  public static VectorOffset CreateJHLBDFAGELJVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartJHLBDFAGELJVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddAKLEGPKGNDI(FlatBufferBuilder builder, VectorOffset AKLEGPKGNDIOffset) { builder.AddOffset(4, AKLEGPKGNDIOffset.Value, 0); }
  public static VectorOffset CreateAKLEGPKGNDIVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartAKLEGPKGNDIVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddADCPHBKIAOB(FlatBufferBuilder builder, VectorOffset ADCPHBKIAOBOffset) { builder.AddOffset(5, ADCPHBKIAOBOffset.Value, 0); }
  public static VectorOffset CreateADCPHBKIAOBVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartADCPHBKIAOBVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<JGHMLKFMFBM> EndJGHMLKFMFBM(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<JGHMLKFMFBM>(o);
  }
};
