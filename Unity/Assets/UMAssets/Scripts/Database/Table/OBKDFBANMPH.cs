// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class OBKDFBANMPH : Table {
  public static OBKDFBANMPH GetRootAsOBKDFBANMPH(ByteBuffer _bb) { return GetRootAsOBKDFBANMPH(_bb, new OBKDFBANMPH()); }
  public static OBKDFBANMPH GetRootAsOBKDFBANMPH(ByteBuffer _bb, OBKDFBANMPH obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public OBKDFBANMPH __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public int OFMGALJGDAO { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public uint CFLMCGOJJJD { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public int ADCLAGBHDBC { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int AEAKMMJLLDK { get { int o = __offset(12); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int ODBPKGJPLMD { get { int o = __offset(14); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int KJFEBMBHKOC { get { int o = __offset(16); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int HHGNAFHNHEK { get { int o = __offset(18); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public uint ODEMBFLHJGG { get { int o = __offset(20); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }

  public static Offset<OBKDFBANMPH> CreateOBKDFBANMPH(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      int OFMGALJGDAO = 0,
      uint CFLMCGOJJJD = 0,
      int ADCLAGBHDBC = 0,
      int AEAKMMJLLDK = 0,
      int ODBPKGJPLMD = 0,
      int KJFEBMBHKOC = 0,
      int HHGNAFHNHEK = 0,
      uint ODEMBFLHJGG = 0) {
    builder.StartObject(9);
    OBKDFBANMPH.AddODEMBFLHJGG(builder, ODEMBFLHJGG);
    OBKDFBANMPH.AddHHGNAFHNHEK(builder, HHGNAFHNHEK);
    OBKDFBANMPH.AddKJFEBMBHKOC(builder, KJFEBMBHKOC);
    OBKDFBANMPH.AddODBPKGJPLMD(builder, ODBPKGJPLMD);
    OBKDFBANMPH.AddAEAKMMJLLDK(builder, AEAKMMJLLDK);
    OBKDFBANMPH.AddADCLAGBHDBC(builder, ADCLAGBHDBC);
    OBKDFBANMPH.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    OBKDFBANMPH.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    OBKDFBANMPH.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return OBKDFBANMPH.EndOBKDFBANMPH(builder);
  }

  public static void StartOBKDFBANMPH(FlatBufferBuilder builder) { builder.StartObject(9); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(1, OFMGALJGDAO, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, uint CFLMCGOJJJD) { builder.AddUint(2, CFLMCGOJJJD, 0); }
  public static void AddADCLAGBHDBC(FlatBufferBuilder builder, int ADCLAGBHDBC) { builder.AddInt(3, ADCLAGBHDBC, 0); }
  public static void AddAEAKMMJLLDK(FlatBufferBuilder builder, int AEAKMMJLLDK) { builder.AddInt(4, AEAKMMJLLDK, 0); }
  public static void AddODBPKGJPLMD(FlatBufferBuilder builder, int ODBPKGJPLMD) { builder.AddInt(5, ODBPKGJPLMD, 0); }
  public static void AddKJFEBMBHKOC(FlatBufferBuilder builder, int KJFEBMBHKOC) { builder.AddInt(6, KJFEBMBHKOC, 0); }
  public static void AddHHGNAFHNHEK(FlatBufferBuilder builder, int HHGNAFHNHEK) { builder.AddInt(7, HHGNAFHNHEK, 0); }
  public static void AddODEMBFLHJGG(FlatBufferBuilder builder, uint ODEMBFLHJGG) { builder.AddUint(8, ODEMBFLHJGG, 0); }
  public static Offset<OBKDFBANMPH> EndOBKDFBANMPH(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<OBKDFBANMPH>(o);
  }
};

