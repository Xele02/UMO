// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class EDPJPHELMBH : Table {
  public static EDPJPHELMBH GetRootAsEDPJPHELMBH(ByteBuffer _bb) { return GetRootAsEDPJPHELMBH(_bb, new EDPJPHELMBH()); }
  public static EDPJPHELMBH GetRootAsEDPJPHELMBH(ByteBuffer _bb, EDPJPHELMBH obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public EDPJPHELMBH __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public DGKLGFOIGJB GetHEFLJHJEIJC(int j) { return GetHEFLJHJEIJC(new DGKLGFOIGJB(), j); }
  public DGKLGFOIGJB GetHEFLJHJEIJC(DGKLGFOIGJB obj, int j) { int o = __offset(6); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int HEFLJHJEIJCLength { get { int o = __offset(6); return o != 0 ? __vector_len(o) : 0; } }
  public DILKNNAKBII GetILBKJACHOHM(int j) { return GetILBKJACHOHM(new DILKNNAKBII(), j); }
  public DILKNNAKBII GetILBKJACHOHM(DILKNNAKBII obj, int j) { int o = __offset(8); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int ILBKJACHOHMLength { get { int o = __offset(8); return o != 0 ? __vector_len(o) : 0; } }
  public DMMAPNIMIIK GetDELLLBAKAAA(int j) { return GetDELLLBAKAAA(new DMMAPNIMIIK(), j); }
  public DMMAPNIMIIK GetDELLLBAKAAA(DMMAPNIMIIK obj, int j) { int o = __offset(10); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int DELLLBAKAAALength { get { int o = __offset(10); return o != 0 ? __vector_len(o) : 0; } }
  public CONJKLGMJJE GetGFEGLNILLEE(int j) { return GetGFEGLNILLEE(new CONJKLGMJJE(), j); }
  public CONJKLGMJJE GetGFEGLNILLEE(CONJKLGMJJE obj, int j) { int o = __offset(12); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int GFEGLNILLEELength { get { int o = __offset(12); return o != 0 ? __vector_len(o) : 0; } }
  public BHJMBLJJLNM GetBFINILLMFOM(int j) { return GetBFINILLMFOM(new BHJMBLJJLNM(), j); }
  public BHJMBLJJLNM GetBFINILLMFOM(BHJMBLJJLNM obj, int j) { int o = __offset(14); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int BFINILLMFOMLength { get { int o = __offset(14); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<EDPJPHELMBH> CreateEDPJPHELMBH(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      VectorOffset HEFLJHJEIJCOffset = default(VectorOffset),
      VectorOffset ILBKJACHOHMOffset = default(VectorOffset),
      VectorOffset DELLLBAKAAAOffset = default(VectorOffset),
      VectorOffset GFEGLNILLEEOffset = default(VectorOffset),
      VectorOffset BFINILLMFOMOffset = default(VectorOffset)) {
    builder.StartObject(6);
    EDPJPHELMBH.AddBFINILLMFOM(builder, BFINILLMFOMOffset);
    EDPJPHELMBH.AddGFEGLNILLEE(builder, GFEGLNILLEEOffset);
    EDPJPHELMBH.AddDELLLBAKAAA(builder, DELLLBAKAAAOffset);
    EDPJPHELMBH.AddILBKJACHOHM(builder, ILBKJACHOHMOffset);
    EDPJPHELMBH.AddHEFLJHJEIJC(builder, HEFLJHJEIJCOffset);
    EDPJPHELMBH.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return EDPJPHELMBH.EndEDPJPHELMBH(builder);
  }

  public static void StartEDPJPHELMBH(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddHEFLJHJEIJC(FlatBufferBuilder builder, VectorOffset HEFLJHJEIJCOffset) { builder.AddOffset(1, HEFLJHJEIJCOffset.Value, 0); }
  public static VectorOffset CreateHEFLJHJEIJCVector(FlatBufferBuilder builder, Offset<DGKLGFOIGJB>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartHEFLJHJEIJCVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddILBKJACHOHM(FlatBufferBuilder builder, VectorOffset ILBKJACHOHMOffset) { builder.AddOffset(2, ILBKJACHOHMOffset.Value, 0); }
  public static VectorOffset CreateILBKJACHOHMVector(FlatBufferBuilder builder, Offset<DILKNNAKBII>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartILBKJACHOHMVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddDELLLBAKAAA(FlatBufferBuilder builder, VectorOffset DELLLBAKAAAOffset) { builder.AddOffset(3, DELLLBAKAAAOffset.Value, 0); }
  public static VectorOffset CreateDELLLBAKAAAVector(FlatBufferBuilder builder, Offset<DMMAPNIMIIK>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartDELLLBAKAAAVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddGFEGLNILLEE(FlatBufferBuilder builder, VectorOffset GFEGLNILLEEOffset) { builder.AddOffset(4, GFEGLNILLEEOffset.Value, 0); }
  public static VectorOffset CreateGFEGLNILLEEVector(FlatBufferBuilder builder, Offset<CONJKLGMJJE>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartGFEGLNILLEEVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddBFINILLMFOM(FlatBufferBuilder builder, VectorOffset BFINILLMFOMOffset) { builder.AddOffset(5, BFINILLMFOMOffset.Value, 0); }
  public static VectorOffset CreateBFINILLMFOMVector(FlatBufferBuilder builder, Offset<BHJMBLJJLNM>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartBFINILLMFOMVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<EDPJPHELMBH> EndEDPJPHELMBH(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<EDPJPHELMBH>(o);
  }
};

