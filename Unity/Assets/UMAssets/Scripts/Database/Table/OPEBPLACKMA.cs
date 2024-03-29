// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class OPEBPLACKMA : Table {
  public static OPEBPLACKMA GetRootAsOPEBPLACKMA(ByteBuffer _bb) { return GetRootAsOPEBPLACKMA(_bb, new OPEBPLACKMA()); }
  public static OPEBPLACKMA GetRootAsOPEBPLACKMA(ByteBuffer _bb, OPEBPLACKMA obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public OPEBPLACKMA __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint CFLMCGOJJJD { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint PJPIKBPCCMD { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public int HKGPNPMBJCP { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int MBBJMJAAODG { get { int o = __offset(12); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int KJFEBMBHKOC { get { int o = __offset(14); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public uint LFFMNLEJJMH { get { int o = __offset(16); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }

  public static Offset<OPEBPLACKMA> CreateOPEBPLACKMA(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      uint CFLMCGOJJJD = 0,
      uint PJPIKBPCCMD = 0,
      int HKGPNPMBJCP = 0,
      int MBBJMJAAODG = 0,
      int KJFEBMBHKOC = 0,
      uint LFFMNLEJJMH = 0) {
    builder.StartObject(7);
    OPEBPLACKMA.AddLFFMNLEJJMH(builder, LFFMNLEJJMH);
    OPEBPLACKMA.AddKJFEBMBHKOC(builder, KJFEBMBHKOC);
    OPEBPLACKMA.AddMBBJMJAAODG(builder, MBBJMJAAODG);
    OPEBPLACKMA.AddHKGPNPMBJCP(builder, HKGPNPMBJCP);
    OPEBPLACKMA.AddPJPIKBPCCMD(builder, PJPIKBPCCMD);
    OPEBPLACKMA.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    OPEBPLACKMA.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return OPEBPLACKMA.EndOPEBPLACKMA(builder);
  }

  public static void StartOPEBPLACKMA(FlatBufferBuilder builder) { builder.StartObject(7); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, uint CFLMCGOJJJD) { builder.AddUint(1, CFLMCGOJJJD, 0); }
  public static void AddPJPIKBPCCMD(FlatBufferBuilder builder, uint PJPIKBPCCMD) { builder.AddUint(2, PJPIKBPCCMD, 0); }
  public static void AddHKGPNPMBJCP(FlatBufferBuilder builder, int HKGPNPMBJCP) { builder.AddInt(3, HKGPNPMBJCP, 0); }
  public static void AddMBBJMJAAODG(FlatBufferBuilder builder, int MBBJMJAAODG) { builder.AddInt(4, MBBJMJAAODG, 0); }
  public static void AddKJFEBMBHKOC(FlatBufferBuilder builder, int KJFEBMBHKOC) { builder.AddInt(5, KJFEBMBHKOC, 0); }
  public static void AddLFFMNLEJJMH(FlatBufferBuilder builder, uint LFFMNLEJJMH) { builder.AddUint(6, LFFMNLEJJMH, 0); }
  public static Offset<OPEBPLACKMA> EndOPEBPLACKMA(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<OPEBPLACKMA>(o);
  }
};

