// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class NACHIDBHKDO : Table {
  public static NACHIDBHKDO GetRootAsNACHIDBHKDO(ByteBuffer _bb) { return GetRootAsNACHIDBHKDO(_bb, new NACHIDBHKDO()); }
  public static NACHIDBHKDO GetRootAsNACHIDBHKDO(ByteBuffer _bb, NACHIDBHKDO obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public NACHIDBHKDO __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint FIDHINJIOAD { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint HOENDPOGFIO { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint ECFLMBOLCAA { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint DHFDNBDDLLO { get { int o = __offset(12); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint AEAKMMJLLDK { get { int o = __offset(14); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint OADMJNEOKLC { get { int o = __offset(16); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint MIBINPGCPPK { get { int o = __offset(18); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GLIIHLOLPEF { get { int o = __offset(20); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint KMEODDMBHHE { get { int o = __offset(22); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint JBAHJKKJPEG { get { int o = __offset(24); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint ADCLAGBHDBC { get { int o = __offset(26); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint ECLKGKLMLBK { get { int o = __offset(28); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint EBBBDFADIPN { get { int o = __offset(30); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint OFMGALJGDAO { get { int o = __offset(32); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public int FKLNFLAFBDH { get { int o = __offset(34); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<NACHIDBHKDO> CreateNACHIDBHKDO(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      uint FIDHINJIOAD = 0,
      uint HOENDPOGFIO = 0,
      uint ECFLMBOLCAA = 0,
      uint DHFDNBDDLLO = 0,
      uint AEAKMMJLLDK = 0,
      uint OADMJNEOKLC = 0,
      uint MIBINPGCPPK = 0,
      uint GLIIHLOLPEF = 0,
      uint KMEODDMBHHE = 0,
      uint JBAHJKKJPEG = 0,
      uint ADCLAGBHDBC = 0,
      uint ECLKGKLMLBK = 0,
      uint EBBBDFADIPN = 0,
      uint OFMGALJGDAO = 0,
      int FKLNFLAFBDH = 0) {
    builder.StartObject(16);
    NACHIDBHKDO.AddFKLNFLAFBDH(builder, FKLNFLAFBDH);
    NACHIDBHKDO.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    NACHIDBHKDO.AddEBBBDFADIPN(builder, EBBBDFADIPN);
    NACHIDBHKDO.AddECLKGKLMLBK(builder, ECLKGKLMLBK);
    NACHIDBHKDO.AddADCLAGBHDBC(builder, ADCLAGBHDBC);
    NACHIDBHKDO.AddJBAHJKKJPEG(builder, JBAHJKKJPEG);
    NACHIDBHKDO.AddKMEODDMBHHE(builder, KMEODDMBHHE);
    NACHIDBHKDO.AddGLIIHLOLPEF(builder, GLIIHLOLPEF);
    NACHIDBHKDO.AddMIBINPGCPPK(builder, MIBINPGCPPK);
    NACHIDBHKDO.AddOADMJNEOKLC(builder, OADMJNEOKLC);
    NACHIDBHKDO.AddAEAKMMJLLDK(builder, AEAKMMJLLDK);
    NACHIDBHKDO.AddDHFDNBDDLLO(builder, DHFDNBDDLLO);
    NACHIDBHKDO.AddECFLMBOLCAA(builder, ECFLMBOLCAA);
    NACHIDBHKDO.AddHOENDPOGFIO(builder, HOENDPOGFIO);
    NACHIDBHKDO.AddFIDHINJIOAD(builder, FIDHINJIOAD);
    NACHIDBHKDO.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return NACHIDBHKDO.EndNACHIDBHKDO(builder);
  }

  public static void StartNACHIDBHKDO(FlatBufferBuilder builder) { builder.StartObject(16); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddFIDHINJIOAD(FlatBufferBuilder builder, uint FIDHINJIOAD) { builder.AddUint(1, FIDHINJIOAD, 0); }
  public static void AddHOENDPOGFIO(FlatBufferBuilder builder, uint HOENDPOGFIO) { builder.AddUint(2, HOENDPOGFIO, 0); }
  public static void AddECFLMBOLCAA(FlatBufferBuilder builder, uint ECFLMBOLCAA) { builder.AddUint(3, ECFLMBOLCAA, 0); }
  public static void AddDHFDNBDDLLO(FlatBufferBuilder builder, uint DHFDNBDDLLO) { builder.AddUint(4, DHFDNBDDLLO, 0); }
  public static void AddAEAKMMJLLDK(FlatBufferBuilder builder, uint AEAKMMJLLDK) { builder.AddUint(5, AEAKMMJLLDK, 0); }
  public static void AddOADMJNEOKLC(FlatBufferBuilder builder, uint OADMJNEOKLC) { builder.AddUint(6, OADMJNEOKLC, 0); }
  public static void AddMIBINPGCPPK(FlatBufferBuilder builder, uint MIBINPGCPPK) { builder.AddUint(7, MIBINPGCPPK, 0); }
  public static void AddGLIIHLOLPEF(FlatBufferBuilder builder, uint GLIIHLOLPEF) { builder.AddUint(8, GLIIHLOLPEF, 0); }
  public static void AddKMEODDMBHHE(FlatBufferBuilder builder, uint KMEODDMBHHE) { builder.AddUint(9, KMEODDMBHHE, 0); }
  public static void AddJBAHJKKJPEG(FlatBufferBuilder builder, uint JBAHJKKJPEG) { builder.AddUint(10, JBAHJKKJPEG, 0); }
  public static void AddADCLAGBHDBC(FlatBufferBuilder builder, uint ADCLAGBHDBC) { builder.AddUint(11, ADCLAGBHDBC, 0); }
  public static void AddECLKGKLMLBK(FlatBufferBuilder builder, uint ECLKGKLMLBK) { builder.AddUint(12, ECLKGKLMLBK, 0); }
  public static void AddEBBBDFADIPN(FlatBufferBuilder builder, uint EBBBDFADIPN) { builder.AddUint(13, EBBBDFADIPN, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, uint OFMGALJGDAO) { builder.AddUint(14, OFMGALJGDAO, 0); }
  public static void AddFKLNFLAFBDH(FlatBufferBuilder builder, int FKLNFLAFBDH) { builder.AddInt(15, FKLNFLAFBDH, 0); }
  public static Offset<NACHIDBHKDO> EndNACHIDBHKDO(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<NACHIDBHKDO>(o);
  }
};

