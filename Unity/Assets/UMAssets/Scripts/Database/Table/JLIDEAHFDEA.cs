// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class JLIDEAHFDEA : Table {
  public static JLIDEAHFDEA GetRootAsJLIDEAHFDEA(ByteBuffer _bb) { return GetRootAsJLIDEAHFDEA(_bb, new JLIDEAHFDEA()); }
  public static JLIDEAHFDEA GetRootAsJLIDEAHFDEA(ByteBuffer _bb, JLIDEAHFDEA obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public JLIDEAHFDEA __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public int OFMGALJGDAO { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public uint CFLMCGOJJJD { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint PBMIJLINDCG { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint BNDAHALMIPE { get { int o = __offset(12); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint HJNPKHJJDBB { get { int o = __offset(14); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GetPJLIIABPNFJ(int j) { int o = __offset(16); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int PJLIIABPNFJLength { get { int o = __offset(16); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetPJLIIABPNFJBytes() { return __vector_as_arraysegment(16); }

  public static Offset<JLIDEAHFDEA> CreateJLIDEAHFDEA(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      int OFMGALJGDAO = 0,
      uint CFLMCGOJJJD = 0,
      uint PBMIJLINDCG = 0,
      uint BNDAHALMIPE = 0,
      uint HJNPKHJJDBB = 0,
      VectorOffset PJLIIABPNFJOffset = default(VectorOffset)) {
    builder.StartObject(7);
    JLIDEAHFDEA.AddPJLIIABPNFJ(builder, PJLIIABPNFJOffset);
    JLIDEAHFDEA.AddHJNPKHJJDBB(builder, HJNPKHJJDBB);
    JLIDEAHFDEA.AddBNDAHALMIPE(builder, BNDAHALMIPE);
    JLIDEAHFDEA.AddPBMIJLINDCG(builder, PBMIJLINDCG);
    JLIDEAHFDEA.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    JLIDEAHFDEA.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    JLIDEAHFDEA.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return JLIDEAHFDEA.EndJLIDEAHFDEA(builder);
  }

  public static void StartJLIDEAHFDEA(FlatBufferBuilder builder) { builder.StartObject(7); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(1, OFMGALJGDAO, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, uint CFLMCGOJJJD) { builder.AddUint(2, CFLMCGOJJJD, 0); }
  public static void AddPBMIJLINDCG(FlatBufferBuilder builder, uint PBMIJLINDCG) { builder.AddUint(3, PBMIJLINDCG, 0); }
  public static void AddBNDAHALMIPE(FlatBufferBuilder builder, uint BNDAHALMIPE) { builder.AddUint(4, BNDAHALMIPE, 0); }
  public static void AddHJNPKHJJDBB(FlatBufferBuilder builder, uint HJNPKHJJDBB) { builder.AddUint(5, HJNPKHJJDBB, 0); }
  public static void AddPJLIIABPNFJ(FlatBufferBuilder builder, VectorOffset PJLIIABPNFJOffset) { builder.AddOffset(6, PJLIIABPNFJOffset.Value, 0); }
  public static VectorOffset CreatePJLIIABPNFJVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartPJLIIABPNFJVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<JLIDEAHFDEA> EndJLIDEAHFDEA(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<JLIDEAHFDEA>(o);
  }
};

