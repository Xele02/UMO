// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class OEMMCAHOCEL : Table {
  public static OEMMCAHOCEL GetRootAsOEMMCAHOCEL(ByteBuffer _bb) { return GetRootAsOEMMCAHOCEL(_bb, new OEMMCAHOCEL()); }
  public static OEMMCAHOCEL GetRootAsOEMMCAHOCEL(ByteBuffer _bb, OEMMCAHOCEL obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public OEMMCAHOCEL __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public LPDFHGHGHPA GetNCMGOKNHGNL(int j) { return GetNCMGOKNHGNL(new LPDFHGHGHPA(), j); }
  public LPDFHGHGHPA GetNCMGOKNHGNL(LPDFHGHGHPA obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int NCMGOKNHGNLLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<OEMMCAHOCEL> CreateOEMMCAHOCEL(FlatBufferBuilder builder,
      VectorOffset NCMGOKNHGNLOffset = default(VectorOffset)) {
    builder.StartObject(1);
    OEMMCAHOCEL.AddNCMGOKNHGNL(builder, NCMGOKNHGNLOffset);
    return OEMMCAHOCEL.EndOEMMCAHOCEL(builder);
  }

  public static void StartOEMMCAHOCEL(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddNCMGOKNHGNL(FlatBufferBuilder builder, VectorOffset NCMGOKNHGNLOffset) { builder.AddOffset(0, NCMGOKNHGNLOffset.Value, 0); }
  public static VectorOffset CreateNCMGOKNHGNLVector(FlatBufferBuilder builder, Offset<LPDFHGHGHPA>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartNCMGOKNHGNLVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<OEMMCAHOCEL> EndOEMMCAHOCEL(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<OEMMCAHOCEL>(o);
  }
};
