// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class EADNHFHCKIA : Table {
  public static EADNHFHCKIA GetRootAsEADNHFHCKIA(ByteBuffer _bb) { return GetRootAsEADNHFHCKIA(_bb, new EADNHFHCKIA()); }
  public static EADNHFHCKIA GetRootAsEADNHFHCKIA(ByteBuffer _bb, EADNHFHCKIA obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public EADNHFHCKIA __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public NGBNIMPLJEE GetEJNIGLEDAFJ(int j) { return GetEJNIGLEDAFJ(new NGBNIMPLJEE(), j); }
  public NGBNIMPLJEE GetEJNIGLEDAFJ(NGBNIMPLJEE obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int EJNIGLEDAFJLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<EADNHFHCKIA> CreateEADNHFHCKIA(FlatBufferBuilder builder,
      VectorOffset EJNIGLEDAFJOffset = default(VectorOffset)) {
    builder.StartObject(1);
    EADNHFHCKIA.AddEJNIGLEDAFJ(builder, EJNIGLEDAFJOffset);
    return EADNHFHCKIA.EndEADNHFHCKIA(builder);
  }

  public static void StartEADNHFHCKIA(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddEJNIGLEDAFJ(FlatBufferBuilder builder, VectorOffset EJNIGLEDAFJOffset) { builder.AddOffset(0, EJNIGLEDAFJOffset.Value, 0); }
  public static VectorOffset CreateEJNIGLEDAFJVector(FlatBufferBuilder builder, Offset<NGBNIMPLJEE>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartEJNIGLEDAFJVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<EADNHFHCKIA> EndEADNHFHCKIA(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<EADNHFHCKIA>(o);
  }
};

