// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class GGALCNFLIBP : Table {
  public static GGALCNFLIBP GetRootAsGGALCNFLIBP(ByteBuffer _bb) { return GetRootAsGGALCNFLIBP(_bb, new GGALCNFLIBP()); }
  public static GGALCNFLIBP GetRootAsGGALCNFLIBP(ByteBuffer _bb, GGALCNFLIBP obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public GGALCNFLIBP __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint CFLMCGOJJJD { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public string NNKLANONDOM { get { int o = __offset(8); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetNNKLANONDOMBytes() { return __vector_as_arraysegment(8); }
  public uint NBMJDIEAMAB { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public string GMMOOPMEKKG { get { int o = __offset(12); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetGMMOOPMEKKGBytes() { return __vector_as_arraysegment(12); }
  public uint KGOFDIKBIHE { get { int o = __offset(14); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint ALPALMJMJJK { get { int o = __offset(16); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint NJLJEKDBPCH { get { int o = __offset(18); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint MAOAGDBDBIB { get { int o = __offset(20); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint AIIPAPCLGGO { get { int o = __offset(22); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint NCADHENBLDB { get { int o = __offset(24); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint NFAOINKHBIG { get { int o = __offset(26); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint PMEGAJICHMB { get { int o = __offset(28); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public string DKAFKOABCJA { get { int o = __offset(30); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetDKAFKOABCJABytes() { return __vector_as_arraysegment(30); }
  public int OFMGALJGDAO { get { int o = __offset(32); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int PEGBGEGKCGA { get { int o = __offset(34); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int GOOHAMCBHAE { get { int o = __offset(36); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int LECDAEGCIMH { get { int o = __offset(38); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public uint PMFELBFGCJG { get { int o = __offset(40); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }

  public static Offset<GGALCNFLIBP> CreateGGALCNFLIBP(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      uint CFLMCGOJJJD = 0,
      StringOffset NNKLANONDOMOffset = default(StringOffset),
      uint NBMJDIEAMAB = 0,
      StringOffset GMMOOPMEKKGOffset = default(StringOffset),
      uint KGOFDIKBIHE = 0,
      uint ALPALMJMJJK = 0,
      uint NJLJEKDBPCH = 0,
      uint MAOAGDBDBIB = 0,
      uint AIIPAPCLGGO = 0,
      uint NCADHENBLDB = 0,
      uint NFAOINKHBIG = 0,
      uint PMEGAJICHMB = 0,
      StringOffset DKAFKOABCJAOffset = default(StringOffset),
      int OFMGALJGDAO = 0,
      int PEGBGEGKCGA = 0,
      int GOOHAMCBHAE = 0,
      int LECDAEGCIMH = 0,
      uint PMFELBFGCJG = 0) {
    builder.StartObject(19);
    GGALCNFLIBP.AddPMFELBFGCJG(builder, PMFELBFGCJG);
    GGALCNFLIBP.AddLECDAEGCIMH(builder, LECDAEGCIMH);
    GGALCNFLIBP.AddGOOHAMCBHAE(builder, GOOHAMCBHAE);
    GGALCNFLIBP.AddPEGBGEGKCGA(builder, PEGBGEGKCGA);
    GGALCNFLIBP.AddOFMGALJGDAO(builder, OFMGALJGDAO);
    GGALCNFLIBP.AddDKAFKOABCJA(builder, DKAFKOABCJAOffset);
    GGALCNFLIBP.AddPMEGAJICHMB(builder, PMEGAJICHMB);
    GGALCNFLIBP.AddNFAOINKHBIG(builder, NFAOINKHBIG);
    GGALCNFLIBP.AddNCADHENBLDB(builder, NCADHENBLDB);
    GGALCNFLIBP.AddAIIPAPCLGGO(builder, AIIPAPCLGGO);
    GGALCNFLIBP.AddMAOAGDBDBIB(builder, MAOAGDBDBIB);
    GGALCNFLIBP.AddNJLJEKDBPCH(builder, NJLJEKDBPCH);
    GGALCNFLIBP.AddALPALMJMJJK(builder, ALPALMJMJJK);
    GGALCNFLIBP.AddKGOFDIKBIHE(builder, KGOFDIKBIHE);
    GGALCNFLIBP.AddGMMOOPMEKKG(builder, GMMOOPMEKKGOffset);
    GGALCNFLIBP.AddNBMJDIEAMAB(builder, NBMJDIEAMAB);
    GGALCNFLIBP.AddNNKLANONDOM(builder, NNKLANONDOMOffset);
    GGALCNFLIBP.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    GGALCNFLIBP.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return GGALCNFLIBP.EndGGALCNFLIBP(builder);
  }

  public static void StartGGALCNFLIBP(FlatBufferBuilder builder) { builder.StartObject(19); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, uint CFLMCGOJJJD) { builder.AddUint(1, CFLMCGOJJJD, 0); }
  public static void AddNNKLANONDOM(FlatBufferBuilder builder, StringOffset NNKLANONDOMOffset) { builder.AddOffset(2, NNKLANONDOMOffset.Value, 0); }
  public static void AddNBMJDIEAMAB(FlatBufferBuilder builder, uint NBMJDIEAMAB) { builder.AddUint(3, NBMJDIEAMAB, 0); }
  public static void AddGMMOOPMEKKG(FlatBufferBuilder builder, StringOffset GMMOOPMEKKGOffset) { builder.AddOffset(4, GMMOOPMEKKGOffset.Value, 0); }
  public static void AddKGOFDIKBIHE(FlatBufferBuilder builder, uint KGOFDIKBIHE) { builder.AddUint(5, KGOFDIKBIHE, 0); }
  public static void AddALPALMJMJJK(FlatBufferBuilder builder, uint ALPALMJMJJK) { builder.AddUint(6, ALPALMJMJJK, 0); }
  public static void AddNJLJEKDBPCH(FlatBufferBuilder builder, uint NJLJEKDBPCH) { builder.AddUint(7, NJLJEKDBPCH, 0); }
  public static void AddMAOAGDBDBIB(FlatBufferBuilder builder, uint MAOAGDBDBIB) { builder.AddUint(8, MAOAGDBDBIB, 0); }
  public static void AddAIIPAPCLGGO(FlatBufferBuilder builder, uint AIIPAPCLGGO) { builder.AddUint(9, AIIPAPCLGGO, 0); }
  public static void AddNCADHENBLDB(FlatBufferBuilder builder, uint NCADHENBLDB) { builder.AddUint(10, NCADHENBLDB, 0); }
  public static void AddNFAOINKHBIG(FlatBufferBuilder builder, uint NFAOINKHBIG) { builder.AddUint(11, NFAOINKHBIG, 0); }
  public static void AddPMEGAJICHMB(FlatBufferBuilder builder, uint PMEGAJICHMB) { builder.AddUint(12, PMEGAJICHMB, 0); }
  public static void AddDKAFKOABCJA(FlatBufferBuilder builder, StringOffset DKAFKOABCJAOffset) { builder.AddOffset(13, DKAFKOABCJAOffset.Value, 0); }
  public static void AddOFMGALJGDAO(FlatBufferBuilder builder, int OFMGALJGDAO) { builder.AddInt(14, OFMGALJGDAO, 0); }
  public static void AddPEGBGEGKCGA(FlatBufferBuilder builder, int PEGBGEGKCGA) { builder.AddInt(15, PEGBGEGKCGA, 0); }
  public static void AddGOOHAMCBHAE(FlatBufferBuilder builder, int GOOHAMCBHAE) { builder.AddInt(16, GOOHAMCBHAE, 0); }
  public static void AddLECDAEGCIMH(FlatBufferBuilder builder, int LECDAEGCIMH) { builder.AddInt(17, LECDAEGCIMH, 0); }
  public static void AddPMFELBFGCJG(FlatBufferBuilder builder, uint PMFELBFGCJG) { builder.AddUint(18, PMFELBFGCJG, 0); }
  public static Offset<GGALCNFLIBP> EndGGALCNFLIBP(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GGALCNFLIBP>(o);
  }
};

