// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class INFGGLDJAIF : Table {
  public static INFGGLDJAIF GetRootAsINFGGLDJAIF(ByteBuffer _bb) { return GetRootAsINFGGLDJAIF(_bb, new INFGGLDJAIF()); }
  public static INFGGLDJAIF GetRootAsINFGGLDJAIF(ByteBuffer _bb, INFGGLDJAIF obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public INFGGLDJAIF __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint ONGGCPLNOFG { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint BMACFCLAHFD { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint KJFEBMBHKOC { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GEJGMBBCFEE { get { int o = __offset(12); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint HHGNAFHNHEK { get { int o = __offset(14); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint CFLMCGOJJJD { get { int o = __offset(16); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public int OFMGALJGDAO { get { int o = __offset(18); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<INFGGLDJAIF> CreateINFGGLDJAIF(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      uint ONGGCPLNOFG = 0,
      uint BMACFCLAHFD = 0,
      uint KJFEBMBHKOC = 0,
      uint GEJGMBBCFEE = 0,
      uint HHGNAFHNHEK = 0,
      uint CFLMCGOJJJD = 0,
      int OFMGALJGDAO = 0) {
    builder.StartObject(8);
    INFGGLDJAIF.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    INFGGLDJAIF.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    INFGGLDJAIF.AddHHGNAFHNHEK(builder, HHGNAFHNHEK);
    INFGGLDJAIF.AddGEJGMBBCFEE(builder, GEJGMBBCFEE);
    INFGGLDJAIF.AddKJFEBMBHKOC(builder, KJFEBMBHKOC);
    INFGGLDJAIF.AddBMACFCLAHFD(builder, BMACFCLAHFD);
    INFGGLDJAIF.AddONGGCPLNOFG(builder, ONGGCPLNOFG);
    INFGGLDJAIF.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return INFGGLDJAIF.EndINFGGLDJAIF(builder);
  }

  public static void StartINFGGLDJAIF(FlatBufferBuilder builder) { builder.StartObject(8); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddONGGCPLNOFG(FlatBufferBuilder builder, uint ONGGCPLNOFG) { builder.AddUint(1, ONGGCPLNOFG, 0); }
  public static void AddBMACFCLAHFD(FlatBufferBuilder builder, uint BMACFCLAHFD) { builder.AddUint(2, BMACFCLAHFD, 0); }
  public static void AddKJFEBMBHKOC(FlatBufferBuilder builder, uint KJFEBMBHKOC) { builder.AddUint(3, KJFEBMBHKOC, 0); }
  public static void AddGEJGMBBCFEE(FlatBufferBuilder builder, uint GEJGMBBCFEE) { builder.AddUint(4, GEJGMBBCFEE, 0); }
  public static void AddHHGNAFHNHEK(FlatBufferBuilder builder, uint HHGNAFHNHEK) { builder.AddUint(5, HHGNAFHNHEK, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, uint CFLMCGOJJJD) { builder.AddUint(6, CFLMCGOJJJD, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(7, OFMGALJGDAO, 0); }
  public static Offset<INFGGLDJAIF> EndINFGGLDJAIF(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<INFGGLDJAIF>(o);
  }
};
