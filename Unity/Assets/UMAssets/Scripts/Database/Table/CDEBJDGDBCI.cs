// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class CDEBJDGDBCI : Table {
  public static CDEBJDGDBCI GetRootAsCDEBJDGDBCI(ByteBuffer _bb) { return GetRootAsCDEBJDGDBCI(_bb, new CDEBJDGDBCI()); }
  public static CDEBJDGDBCI GetRootAsCDEBJDGDBCI(ByteBuffer _bb, CDEBJDGDBCI obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public CDEBJDGDBCI __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint KGJOEPEIDMO { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint EKJOIJJOKGE { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint JMFEAOOLOEG { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint FOOEBKAHMCM { get { int o = __offset(12); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint ADBLMDKLCEA { get { int o = __offset(14); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint EIAIGCOIECH { get { int o = __offset(16); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }

  public static Offset<CDEBJDGDBCI> CreateCDEBJDGDBCI(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      uint KGJOEPEIDMO = 0,
      uint EKJOIJJOKGE = 0,
      uint JMFEAOOLOEG = 0,
      uint FOOEBKAHMCM = 0,
      uint ADBLMDKLCEA = 0,
      uint EIAIGCOIECH = 0) {
    builder.StartObject(7);
    CDEBJDGDBCI.AddEIAIGCOIECH(builder, EIAIGCOIECH);
    CDEBJDGDBCI.AddADBLMDKLCEA(builder, ADBLMDKLCEA);
    CDEBJDGDBCI.AddFOOEBKAHMCM(builder, FOOEBKAHMCM);
    CDEBJDGDBCI.AddJMFEAOOLOEG(builder, JMFEAOOLOEG);
    CDEBJDGDBCI.AddEKJOIJJOKGE(builder, EKJOIJJOKGE);
    CDEBJDGDBCI.AddKGJOEPEIDMO(builder, KGJOEPEIDMO);
    CDEBJDGDBCI.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return CDEBJDGDBCI.EndCDEBJDGDBCI(builder);
  }

  public static void StartCDEBJDGDBCI(FlatBufferBuilder builder) { builder.StartObject(7); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddKGJOEPEIDMO(FlatBufferBuilder builder, uint KGJOEPEIDMO) { builder.AddUint(1, KGJOEPEIDMO, 0); }
  public static void AddEKJOIJJOKGE(FlatBufferBuilder builder, uint EKJOIJJOKGE) { builder.AddUint(2, EKJOIJJOKGE, 0); }
  public static void AddJMFEAOOLOEG(FlatBufferBuilder builder, uint JMFEAOOLOEG) { builder.AddUint(3, JMFEAOOLOEG, 0); }
  public static void AddFOOEBKAHMCM(FlatBufferBuilder builder, uint FOOEBKAHMCM) { builder.AddUint(4, FOOEBKAHMCM, 0); }
  public static void AddADBLMDKLCEA(FlatBufferBuilder builder, uint ADBLMDKLCEA) { builder.AddUint(5, ADBLMDKLCEA, 0); }
  public static void AddEIAIGCOIECH(FlatBufferBuilder builder, uint EIAIGCOIECH) { builder.AddUint(6, EIAIGCOIECH, 0); }
  public static Offset<CDEBJDGDBCI> EndCDEBJDGDBCI(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<CDEBJDGDBCI>(o);
  }
};

