// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class ACFFNDFGCHL : Table {
  public static ACFFNDFGCHL GetRootAsACFFNDFGCHL(ByteBuffer _bb) { return GetRootAsACFFNDFGCHL(_bb, new ACFFNDFGCHL()); }
  public static ACFFNDFGCHL GetRootAsACFFNDFGCHL(ByteBuffer _bb, ACFFNDFGCHL obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public ACFFNDFGCHL __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint CFLMCGOJJJD { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GLIIHLOLPEF { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint BNDAHALMIPE { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public string GetBKLDFCFKFOM(int j) { int o = __offset(12); return o != 0 ? __string(__vector(o) + j * 4) : null; }
  public int BKLDFCFKFOMLength { get { int o = __offset(12); return o != 0 ? __vector_len(o) : 0; } }
  public string IOKCFIHFBHG { get { int o = __offset(14); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetIOKCFIHFBHGBytes() { return __vector_as_arraysegment(14); }
  public int CLEEFGNMCEL { get { int o = __offset(16); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int GKMDCGBFHPM { get { int o = __offset(18); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<ACFFNDFGCHL> CreateACFFNDFGCHL(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      uint CFLMCGOJJJD = 0,
      uint GLIIHLOLPEF = 0,
      uint BNDAHALMIPE = 0,
      VectorOffset BKLDFCFKFOMOffset = default(VectorOffset),
      StringOffset IOKCFIHFBHGOffset = default(StringOffset),
      int CLEEFGNMCEL = 0,
      int GKMDCGBFHPM = 0) {
    builder.StartObject(8);
    ACFFNDFGCHL.AddGKMDCGBFHPM(builder, GKMDCGBFHPM);
    ACFFNDFGCHL.AddCLEEFGNMCEL(builder, CLEEFGNMCEL);
    ACFFNDFGCHL.AddIOKCFIHFBHG(builder, IOKCFIHFBHGOffset);
    ACFFNDFGCHL.AddBKLDFCFKFOM(builder, BKLDFCFKFOMOffset);
    ACFFNDFGCHL.AddBNDAHALMIPE(builder, BNDAHALMIPE);
    ACFFNDFGCHL.AddGLIIHLOLPEF(builder, GLIIHLOLPEF);
    ACFFNDFGCHL.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    ACFFNDFGCHL.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return ACFFNDFGCHL.EndACFFNDFGCHL(builder);
  }

  public static void StartACFFNDFGCHL(FlatBufferBuilder builder) { builder.StartObject(8); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, uint CFLMCGOJJJD) { builder.AddUint(1, CFLMCGOJJJD, 0); }
  public static void AddGLIIHLOLPEF(FlatBufferBuilder builder, uint GLIIHLOLPEF) { builder.AddUint(2, GLIIHLOLPEF, 0); }
  public static void AddBNDAHALMIPE(FlatBufferBuilder builder, uint BNDAHALMIPE) { builder.AddUint(3, BNDAHALMIPE, 0); }
  public static void AddBKLDFCFKFOM(FlatBufferBuilder builder, VectorOffset BKLDFCFKFOMOffset) { builder.AddOffset(4, BKLDFCFKFOMOffset.Value, 0); }
  public static VectorOffset CreateBKLDFCFKFOMVector(FlatBufferBuilder builder, StringOffset[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartBKLDFCFKFOMVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddIOKCFIHFBHG(FlatBufferBuilder builder, StringOffset IOKCFIHFBHGOffset) { builder.AddOffset(5, IOKCFIHFBHGOffset.Value, 0); }
  public static void AddCLEEFGNMCEL(FlatBufferBuilder builder, int CLEEFGNMCEL) { builder.AddInt(6, CLEEFGNMCEL, 0); }
  public static void AddGKMDCGBFHPM(FlatBufferBuilder builder, int GKMDCGBFHPM) { builder.AddInt(7, GKMDCGBFHPM, 0); }
  public static Offset<ACFFNDFGCHL> EndACFFNDFGCHL(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ACFFNDFGCHL>(o);
  }
};

