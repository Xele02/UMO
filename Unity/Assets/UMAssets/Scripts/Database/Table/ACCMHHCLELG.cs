// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class ACCMHHCLELG : Table {
  public static ACCMHHCLELG GetRootAsACCMHHCLELG(ByteBuffer _bb) { return GetRootAsACCMHHCLELG(_bb, new ACCMHHCLELG()); }
  public static ACCMHHCLELG GetRootAsACCMHHCLELG(ByteBuffer _bb, ACCMHHCLELG obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public ACCMHHCLELG __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public JLIDEAHFDEA GetODLAFHPCDEC(int j) { return GetODLAFHPCDEC(new JLIDEAHFDEA(), j); }
  public JLIDEAHFDEA GetODLAFHPCDEC(JLIDEAHFDEA obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int ODLAFHPCDECLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }
  public CKMEIOAPABF GetNJJINHMIOHN(int j) { return GetNJJINHMIOHN(new CKMEIOAPABF(), j); }
  public CKMEIOAPABF GetNJJINHMIOHN(CKMEIOAPABF obj, int j) { int o = __offset(6); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int NJJINHMIOHNLength { get { int o = __offset(6); return o != 0 ? __vector_len(o) : 0; } }
  public BEHBIEJAFJL GetNPFBHGKLIOM(int j) { return GetNPFBHGKLIOM(new BEHBIEJAFJL(), j); }
  public BEHBIEJAFJL GetNPFBHGKLIOM(BEHBIEJAFJL obj, int j) { int o = __offset(8); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int NPFBHGKLIOMLength { get { int o = __offset(8); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<ACCMHHCLELG> CreateACCMHHCLELG(FlatBufferBuilder builder,
      VectorOffset ODLAFHPCDECOffset = default(VectorOffset),
      VectorOffset NJJINHMIOHNOffset = default(VectorOffset),
      VectorOffset NPFBHGKLIOMOffset = default(VectorOffset)) {
    builder.StartObject(3);
    ACCMHHCLELG.AddNPFBHGKLIOM(builder, NPFBHGKLIOMOffset);
    ACCMHHCLELG.AddNJJINHMIOHN(builder, NJJINHMIOHNOffset);
    ACCMHHCLELG.AddODLAFHPCDEC(builder, ODLAFHPCDECOffset);
    return ACCMHHCLELG.EndACCMHHCLELG(builder);
  }

  public static void StartACCMHHCLELG(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddODLAFHPCDEC(FlatBufferBuilder builder, VectorOffset ODLAFHPCDECOffset) { builder.AddOffset(0, ODLAFHPCDECOffset.Value, 0); }
  public static VectorOffset CreateODLAFHPCDECVector(FlatBufferBuilder builder, Offset<JLIDEAHFDEA>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartODLAFHPCDECVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNJJINHMIOHN(FlatBufferBuilder builder, VectorOffset NJJINHMIOHNOffset) { builder.AddOffset(1, NJJINHMIOHNOffset.Value, 0); }
  public static VectorOffset CreateNJJINHMIOHNVector(FlatBufferBuilder builder, Offset<CKMEIOAPABF>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartNJJINHMIOHNVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNPFBHGKLIOM(FlatBufferBuilder builder, VectorOffset NPFBHGKLIOMOffset) { builder.AddOffset(2, NPFBHGKLIOMOffset.Value, 0); }
  public static VectorOffset CreateNPFBHGKLIOMVector(FlatBufferBuilder builder, Offset<BEHBIEJAFJL>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartNPFBHGKLIOMVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<ACCMHHCLELG> EndACCMHHCLELG(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ACCMHHCLELG>(o);
  }
};
