// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class HAGPHAGHHFA : Table {
  public static HAGPHAGHHFA GetRootAsHAGPHAGHHFA(ByteBuffer _bb) { return GetRootAsHAGPHAGHHFA(_bb, new HAGPHAGHHFA()); }
  public static HAGPHAGHHFA GetRootAsHAGPHAGHHFA(ByteBuffer _bb, HAGPHAGHHFA obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public HAGPHAGHHFA __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int GFAJCKHBDHL { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int FKGLOPMFMCP { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int NHJOOMBKDOD { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int NMAMEIMNOPA { get { int o = __offset(12); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int GetCGHIJPPACBC(int j) { int o = __offset(14); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int CGHIJPPACBCLength { get { int o = __offset(14); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetCGHIJPPACBCBytes() { return __vector_as_arraysegment(14); }
  public int GetBJHKKKPGPAA(int j) { int o = __offset(16); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int BJHKKKPGPAALength { get { int o = __offset(16); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetBJHKKKPGPAABytes() { return __vector_as_arraysegment(16); }

  public static Offset<HAGPHAGHHFA> CreateHAGPHAGHHFA(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int GFAJCKHBDHL = 0,
      int FKGLOPMFMCP = 0,
      int NHJOOMBKDOD = 0,
      int NMAMEIMNOPA = 0,
      VectorOffset CGHIJPPACBCOffset = default(VectorOffset),
      VectorOffset BJHKKKPGPAAOffset = default(VectorOffset)) {
    builder.StartObject(7);
    HAGPHAGHHFA.AddBJHKKKPGPAA(builder, BJHKKKPGPAAOffset);
    HAGPHAGHHFA.AddCGHIJPPACBC(builder, CGHIJPPACBCOffset);
    HAGPHAGHHFA.AddNMAMEIMNOPA(builder, NMAMEIMNOPA);
    HAGPHAGHHFA.AddNHJOOMBKDOD(builder, NHJOOMBKDOD);
    HAGPHAGHHFA.AddFKGLOPMFMCP(builder, FKGLOPMFMCP);
    HAGPHAGHHFA.AddGFAJCKHBDHL(builder, GFAJCKHBDHL);
    HAGPHAGHHFA.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return HAGPHAGHHFA.EndHAGPHAGHHFA(builder);
  }

  public static void StartHAGPHAGHHFA(FlatBufferBuilder builder) { builder.StartObject(7); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddGFAJCKHBDHL(FlatBufferBuilder builder, int GFAJCKHBDHL) { builder.AddInt(1, GFAJCKHBDHL, 0); }
  public static void AddFKGLOPMFMCP(FlatBufferBuilder builder, int FKGLOPMFMCP) { builder.AddInt(2, FKGLOPMFMCP, 0); }
  public static void AddNHJOOMBKDOD(FlatBufferBuilder builder, int NHJOOMBKDOD) { builder.AddInt(3, NHJOOMBKDOD, 0); }
  public static void AddNMAMEIMNOPA(FlatBufferBuilder builder, int NMAMEIMNOPA) { builder.AddInt(4, NMAMEIMNOPA, 0); }
  public static void AddCGHIJPPACBC(FlatBufferBuilder builder, VectorOffset CGHIJPPACBCOffset) { builder.AddOffset(5, CGHIJPPACBCOffset.Value, 0); }
  public static VectorOffset CreateCGHIJPPACBCVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartCGHIJPPACBCVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddBJHKKKPGPAA(FlatBufferBuilder builder, VectorOffset BJHKKKPGPAAOffset) { builder.AddOffset(6, BJHKKKPGPAAOffset.Value, 0); }
  public static VectorOffset CreateBJHKKKPGPAAVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartBJHKKKPGPAAVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HAGPHAGHHFA> EndHAGPHAGHHFA(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<HAGPHAGHHFA>(o);
  }
};
