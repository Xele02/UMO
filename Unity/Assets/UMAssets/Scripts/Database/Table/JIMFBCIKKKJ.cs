// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class JIMFBCIKKKJ : Table {
  public static JIMFBCIKKKJ GetRootAsJIMFBCIKKKJ(ByteBuffer _bb) { return GetRootAsJIMFBCIKKKJ(_bb, new JIMFBCIKKKJ()); }
  public static JIMFBCIKKKJ GetRootAsJIMFBCIKKKJ(ByteBuffer _bb, JIMFBCIKKKJ obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public JIMFBCIKKKJ __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int COPFAKAHEMN { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int OFMGALJGDAO { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int CFLMCGOJJJD { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int JAOFIDGEIGE { get { int o = __offset(10); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int FHHFICHAABG { get { int o = __offset(12); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int HAHMOLPJPCG { get { int o = __offset(14); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int NJLJEKDBPCH { get { int o = __offset(16); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int MAOAGDBDBIB { get { int o = __offset(18); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int BPMBFFDNMDD { get { int o = __offset(20); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int HOENDPOGFIO { get { int o = __offset(22); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int PELKLPGCMFN { get { int o = __offset(24); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<JIMFBCIKKKJ> CreateJIMFBCIKKKJ(FlatBufferBuilder builder,
      int COPFAKAHEMN = 0,
      int OFMGALJGDAO = 0,
      int CFLMCGOJJJD = 0,
      int JAOFIDGEIGE = 0,
      int FHHFICHAABG = 0,
      int HAHMOLPJPCG = 0,
      int NJLJEKDBPCH = 0,
      int MAOAGDBDBIB = 0,
      int BPMBFFDNMDD = 0,
      int HOENDPOGFIO = 0,
      int PELKLPGCMFN = 0) {
    builder.StartObject(11);
    JIMFBCIKKKJ.AddPELKLPGCMFN(builder, PELKLPGCMFN);
    JIMFBCIKKKJ.AddHOENDPOGFIO(builder, HOENDPOGFIO);
    JIMFBCIKKKJ.AddBPMBFFDNMDD(builder, BPMBFFDNMDD);
    JIMFBCIKKKJ.AddMAOAGDBDBIB(builder, MAOAGDBDBIB);
    JIMFBCIKKKJ.AddNJLJEKDBPCH(builder, NJLJEKDBPCH);
    JIMFBCIKKKJ.AddHAHMOLPJPCG(builder, HAHMOLPJPCG);
    JIMFBCIKKKJ.AddFHHFICHAABG(builder, FHHFICHAABG);
    JIMFBCIKKKJ.AddJAOFIDGEIGE(builder, JAOFIDGEIGE);
    JIMFBCIKKKJ.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    JIMFBCIKKKJ.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    JIMFBCIKKKJ.AddCOPFAKAHEMN(builder, COPFAKAHEMN);
    return JIMFBCIKKKJ.EndJIMFBCIKKKJ(builder);
  }

  public static void StartJIMFBCIKKKJ(FlatBufferBuilder builder) { builder.StartObject(11); }
  public static void AddCOPFAKAHEMN(FlatBufferBuilder builder, int COPFAKAHEMN) { builder.AddInt(0, COPFAKAHEMN, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(1, OFMGALJGDAO, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, int CFLMCGOJJJD) { builder.AddInt(2, CFLMCGOJJJD, 0); }
  public static void AddJAOFIDGEIGE(FlatBufferBuilder builder, int JAOFIDGEIGE) { builder.AddInt(3, JAOFIDGEIGE, 0); }
  public static void AddFHHFICHAABG(FlatBufferBuilder builder, int FHHFICHAABG) { builder.AddInt(4, FHHFICHAABG, 0); }
  public static void AddHAHMOLPJPCG(FlatBufferBuilder builder, int HAHMOLPJPCG) { builder.AddInt(5, HAHMOLPJPCG, 0); }
  public static void AddNJLJEKDBPCH(FlatBufferBuilder builder, int NJLJEKDBPCH) { builder.AddInt(6, NJLJEKDBPCH, 0); }
  public static void AddMAOAGDBDBIB(FlatBufferBuilder builder, int MAOAGDBDBIB) { builder.AddInt(7, MAOAGDBDBIB, 0); }
  public static void AddBPMBFFDNMDD(FlatBufferBuilder builder, int BPMBFFDNMDD) { builder.AddInt(8, BPMBFFDNMDD, 0); }
  public static void AddHOENDPOGFIO(FlatBufferBuilder builder, int HOENDPOGFIO) { builder.AddInt(9, HOENDPOGFIO, 0); }
  public static void AddPELKLPGCMFN(FlatBufferBuilder builder, int PELKLPGCMFN) { builder.AddInt(10, PELKLPGCMFN, 0); }
  public static Offset<JIMFBCIKKKJ> EndJIMFBCIKKKJ(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<JIMFBCIKKKJ>(o);
  }
};

