// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class HACLELJLADO : Table {
  public static HACLELJLADO GetRootAsHACLELJLADO(ByteBuffer _bb) { return GetRootAsHACLELJLADO(_bb, new HACLELJLADO()); }
  public static HACLELJLADO GetRootAsHACLELJLADO(ByteBuffer _bb, HACLELJLADO obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public HACLELJLADO __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public DGBGJKKIACN GetDECLAPPHHLJ(int j) { return GetDECLAPPHHLJ(new DGBGJKKIACN(), j); }
  public DGBGJKKIACN GetDECLAPPHHLJ(DGBGJKKIACN obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int DECLAPPHHLJLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }
  public BKIKCJIAIIO GetCMMCFMNDNAG(int j) { return GetCMMCFMNDNAG(new BKIKCJIAIIO(), j); }
  public BKIKCJIAIIO GetCMMCFMNDNAG(BKIKCJIAIIO obj, int j) { int o = __offset(6); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int CMMCFMNDNAGLength { get { int o = __offset(6); return o != 0 ? __vector_len(o) : 0; } }
  public OJJCFKMBCCG GetNIIBHCNIBKJ(int j) { return GetNIIBHCNIBKJ(new OJJCFKMBCCG(), j); }
  public OJJCFKMBCCG GetNIIBHCNIBKJ(OJJCFKMBCCG obj, int j) { int o = __offset(8); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int NIIBHCNIBKJLength { get { int o = __offset(8); return o != 0 ? __vector_len(o) : 0; } }
  public EEJBHCCHCGC GetHKEKGDIIMHO(int j) { return GetHKEKGDIIMHO(new EEJBHCCHCGC(), j); }
  public EEJBHCCHCGC GetHKEKGDIIMHO(EEJBHCCHCGC obj, int j) { int o = __offset(10); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int HKEKGDIIMHOLength { get { int o = __offset(10); return o != 0 ? __vector_len(o) : 0; } }
  public HAPBICPAMDF GetNJJINHMIOHN(int j) { return GetNJJINHMIOHN(new HAPBICPAMDF(), j); }
  public HAPBICPAMDF GetNJJINHMIOHN(HAPBICPAMDF obj, int j) { int o = __offset(12); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int NJJINHMIOHNLength { get { int o = __offset(12); return o != 0 ? __vector_len(o) : 0; } }
  public MINCDLJOALM GetNPFBHGKLIOM(int j) { return GetNPFBHGKLIOM(new MINCDLJOALM(), j); }
  public MINCDLJOALM GetNPFBHGKLIOM(MINCDLJOALM obj, int j) { int o = __offset(14); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int NPFBHGKLIOMLength { get { int o = __offset(14); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<HACLELJLADO> CreateHACLELJLADO(FlatBufferBuilder builder,
      VectorOffset DECLAPPHHLJOffset = default(VectorOffset),
      VectorOffset CMMCFMNDNAGOffset = default(VectorOffset),
      VectorOffset NIIBHCNIBKJOffset = default(VectorOffset),
      VectorOffset HKEKGDIIMHOOffset = default(VectorOffset),
      VectorOffset NJJINHMIOHNOffset = default(VectorOffset),
      VectorOffset NPFBHGKLIOMOffset = default(VectorOffset)) {
    builder.StartObject(6);
    HACLELJLADO.AddNPFBHGKLIOM(builder, NPFBHGKLIOMOffset);
    HACLELJLADO.AddNJJINHMIOHN(builder, NJJINHMIOHNOffset);
    HACLELJLADO.AddHKEKGDIIMHO(builder, HKEKGDIIMHOOffset);
    HACLELJLADO.AddNIIBHCNIBKJ(builder, NIIBHCNIBKJOffset);
    HACLELJLADO.AddCMMCFMNDNAG(builder, CMMCFMNDNAGOffset);
    HACLELJLADO.AddDECLAPPHHLJ(builder, DECLAPPHHLJOffset);
    return HACLELJLADO.EndHACLELJLADO(builder);
  }

  public static void StartHACLELJLADO(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddDECLAPPHHLJ(FlatBufferBuilder builder, VectorOffset DECLAPPHHLJOffset) { builder.AddOffset(0, DECLAPPHHLJOffset.Value, 0); }
  public static VectorOffset CreateDECLAPPHHLJVector(FlatBufferBuilder builder, Offset<DGBGJKKIACN>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartDECLAPPHHLJVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddCMMCFMNDNAG(FlatBufferBuilder builder, VectorOffset CMMCFMNDNAGOffset) { builder.AddOffset(1, CMMCFMNDNAGOffset.Value, 0); }
  public static VectorOffset CreateCMMCFMNDNAGVector(FlatBufferBuilder builder, Offset<BKIKCJIAIIO>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartCMMCFMNDNAGVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNIIBHCNIBKJ(FlatBufferBuilder builder, VectorOffset NIIBHCNIBKJOffset) { builder.AddOffset(2, NIIBHCNIBKJOffset.Value, 0); }
  public static VectorOffset CreateNIIBHCNIBKJVector(FlatBufferBuilder builder, Offset<OJJCFKMBCCG>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartNIIBHCNIBKJVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddHKEKGDIIMHO(FlatBufferBuilder builder, VectorOffset HKEKGDIIMHOOffset) { builder.AddOffset(3, HKEKGDIIMHOOffset.Value, 0); }
  public static VectorOffset CreateHKEKGDIIMHOVector(FlatBufferBuilder builder, Offset<EEJBHCCHCGC>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartHKEKGDIIMHOVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNJJINHMIOHN(FlatBufferBuilder builder, VectorOffset NJJINHMIOHNOffset) { builder.AddOffset(4, NJJINHMIOHNOffset.Value, 0); }
  public static VectorOffset CreateNJJINHMIOHNVector(FlatBufferBuilder builder, Offset<HAPBICPAMDF>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartNJJINHMIOHNVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNPFBHGKLIOM(FlatBufferBuilder builder, VectorOffset NPFBHGKLIOMOffset) { builder.AddOffset(5, NPFBHGKLIOMOffset.Value, 0); }
  public static VectorOffset CreateNPFBHGKLIOMVector(FlatBufferBuilder builder, Offset<MINCDLJOALM>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartNPFBHGKLIOMVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HACLELJLADO> EndHACLELJLADO(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<HACLELJLADO>(o);
  }
};

