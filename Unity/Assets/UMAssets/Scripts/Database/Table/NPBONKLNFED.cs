// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class NPBONKLNFED : Table {
  public static NPBONKLNFED GetRootAsNPBONKLNFED(ByteBuffer _bb) { return GetRootAsNPBONKLNFED(_bb, new NPBONKLNFED()); }
  public static NPBONKLNFED GetRootAsNPBONKLNFED(ByteBuffer _bb, NPBONKLNFED obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public NPBONKLNFED __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int OFMGALJGDAO { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public uint CFLMCGOJJJD { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint LMLNKHMPOIG { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint ODBPKGJPLMD { get { int o = __offset(12); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public int HMNFFFLCANH { get { int o = __offset(14); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int JHAMBKOEJPL { get { int o = __offset(16); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int MJHPFNPCLBD { get { int o = __offset(18); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int JDKBBEIBJBD { get { int o = __offset(20); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<NPBONKLNFED> CreateNPBONKLNFED(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      int OFMGALJGDAO = 0,
      uint CFLMCGOJJJD = 0,
      uint LMLNKHMPOIG = 0,
      uint ODBPKGJPLMD = 0,
      int HMNFFFLCANH = 0,
      int JHAMBKOEJPL = 0,
      int MJHPFNPCLBD = 0,
      int JDKBBEIBJBD = 0) {
    builder.StartObject(9);
    NPBONKLNFED.AddJDKBBEIBJBD(builder, JDKBBEIBJBD);
    NPBONKLNFED.AddMJHPFNPCLBD(builder, MJHPFNPCLBD);
    NPBONKLNFED.AddJHAMBKOEJPL(builder, JHAMBKOEJPL);
    NPBONKLNFED.AddHMNFFFLCANH(builder, HMNFFFLCANH);
    NPBONKLNFED.AddODBPKGJPLMD(builder, ODBPKGJPLMD);
    NPBONKLNFED.AddLMLNKHMPOIG(builder, LMLNKHMPOIG);
    NPBONKLNFED.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    NPBONKLNFED.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    NPBONKLNFED.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return NPBONKLNFED.EndNPBONKLNFED(builder);
  }

  public static void StartNPBONKLNFED(FlatBufferBuilder builder) { builder.StartObject(9); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(1, OFMGALJGDAO, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, uint CFLMCGOJJJD) { builder.AddUint(2, CFLMCGOJJJD, 0); }
  public static void AddLMLNKHMPOIG(FlatBufferBuilder builder, uint LMLNKHMPOIG) { builder.AddUint(3, LMLNKHMPOIG, 0); }
  public static void AddODBPKGJPLMD(FlatBufferBuilder builder, uint ODBPKGJPLMD) { builder.AddUint(4, ODBPKGJPLMD, 0); }
  public static void AddHMNFFFLCANH(FlatBufferBuilder builder, int HMNFFFLCANH) { builder.AddInt(5, HMNFFFLCANH, 0); }
  public static void AddJHAMBKOEJPL(FlatBufferBuilder builder, int JHAMBKOEJPL) { builder.AddInt(6, JHAMBKOEJPL, 0); }
  public static void AddMJHPFNPCLBD(FlatBufferBuilder builder, int MJHPFNPCLBD) { builder.AddInt(7, MJHPFNPCLBD, 0); }
  public static void AddJDKBBEIBJBD(FlatBufferBuilder builder, int JDKBBEIBJBD) { builder.AddInt(8, JDKBBEIBJBD, 0); }
  public static Offset<NPBONKLNFED> EndNPBONKLNFED(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<NPBONKLNFED>(o);
  }
};
