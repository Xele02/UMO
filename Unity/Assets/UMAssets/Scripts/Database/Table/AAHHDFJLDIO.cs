// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class AAHHDFJLDIO : Table {
  public static AAHHDFJLDIO GetRootAsAAHHDFJLDIO(ByteBuffer _bb) { return GetRootAsAAHHDFJLDIO(_bb, new AAHHDFJLDIO()); }
  public static AAHHDFJLDIO GetRootAsAAHHDFJLDIO(ByteBuffer _bb, AAHHDFJLDIO obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public AAHHDFJLDIO __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public int BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public string IIDCFMHCPLJ { get { int o = __offset(6); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetIIDCFMHCPLJBytes() { return __vector_as_arraysegment(6); }
  public int DKMLEDJJFOI { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public string GHHPIICJHDB { get { int o = __offset(10); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetGHHPIICJHDBBytes() { return __vector_as_arraysegment(10); }
  public string IJKHPPCHPGK { get { int o = __offset(12); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetIJKHPPCHPGKBytes() { return __vector_as_arraysegment(12); }
  public int CLEEFGNMCEL { get { int o = __offset(14); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int LPJPOOHJKAE { get { int o = __offset(16); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int NJLJEKDBPCH { get { int o = __offset(18); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int IPHMJNCEPIJ { get { int o = __offset(20); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int JBAHJKKJPEG { get { int o = __offset(22); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int OIMEOBNAAHH { get { int o = __offset(24); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int EOHDEKFEONI { get { int o = __offset(26); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public string LCMOIMEFAHI { get { int o = __offset(28); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetLCMOIMEFAHIBytes() { return __vector_as_arraysegment(28); }
  public int PELKLPGCMFN { get { int o = __offset(30); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int GetIDKJOALBKAA(int j) { int o = __offset(32); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int IDKJOALBKAALength { get { int o = __offset(32); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetIDKJOALBKAABytes() { return __vector_as_arraysegment(32); }
  public int GetAFDJJJOJBMO(int j) { int o = __offset(34); return o != 0 ? bb.GetInt(__vector(o) + j * 4) : (int)0; }
  public int AFDJJJOJBMOLength { get { int o = __offset(34); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetAFDJJJOJBMOBytes() { return __vector_as_arraysegment(34); }
  public int MCPMLMHKKOP { get { int o = __offset(36); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int BPMBFFDNMDD { get { int o = __offset(38); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<AAHHDFJLDIO> CreateAAHHDFJLDIO(FlatBufferBuilder builder,
      int BBPHAPFBFHK = 0,
      StringOffset IIDCFMHCPLJOffset = default(StringOffset),
      int DKMLEDJJFOI = 0,
      StringOffset GHHPIICJHDBOffset = default(StringOffset),
      StringOffset IJKHPPCHPGKOffset = default(StringOffset),
      int CLEEFGNMCEL = 0,
      int LPJPOOHJKAE = 0,
      int NJLJEKDBPCH = 0,
      int IPHMJNCEPIJ = 0,
      int JBAHJKKJPEG = 0,
      int OIMEOBNAAHH = 0,
      int EOHDEKFEONI = 0,
      StringOffset LCMOIMEFAHIOffset = default(StringOffset),
      int PELKLPGCMFN = 0,
      VectorOffset IDKJOALBKAAOffset = default(VectorOffset),
      VectorOffset AFDJJJOJBMOOffset = default(VectorOffset),
      int MCPMLMHKKOP = 0,
      int BPMBFFDNMDD = 0) {
    builder.StartObject(18);
    AAHHDFJLDIO.AddBPMBFFDNMDD(builder, BPMBFFDNMDD);
    AAHHDFJLDIO.AddMCPMLMHKKOP(builder, MCPMLMHKKOP);
    AAHHDFJLDIO.AddAFDJJJOJBMO(builder, AFDJJJOJBMOOffset);
    AAHHDFJLDIO.AddIDKJOALBKAA(builder, IDKJOALBKAAOffset);
    AAHHDFJLDIO.AddPELKLPGCMFN(builder, PELKLPGCMFN);
    AAHHDFJLDIO.AddLCMOIMEFAHI(builder, LCMOIMEFAHIOffset);
    AAHHDFJLDIO.AddEOHDEKFEONI(builder, EOHDEKFEONI);
    AAHHDFJLDIO.AddOIMEOBNAAHH(builder, OIMEOBNAAHH);
    AAHHDFJLDIO.AddJBAHJKKJPEG(builder, JBAHJKKJPEG);
    AAHHDFJLDIO.AddIPHMJNCEPIJ(builder, IPHMJNCEPIJ);
    AAHHDFJLDIO.AddNJLJEKDBPCH(builder, NJLJEKDBPCH);
    AAHHDFJLDIO.AddLPJPOOHJKAE(builder, LPJPOOHJKAE);
    AAHHDFJLDIO.AddCLEEFGNMCEL(builder, CLEEFGNMCEL);
    AAHHDFJLDIO.AddIJKHPPCHPGK(builder, IJKHPPCHPGKOffset);
    AAHHDFJLDIO.AddGHHPIICJHDB(builder, GHHPIICJHDBOffset);
    AAHHDFJLDIO.AddDKMLEDJJFOI(builder, DKMLEDJJFOI);
    AAHHDFJLDIO.AddIIDCFMHCPLJ(builder, IIDCFMHCPLJOffset);
    AAHHDFJLDIO.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return AAHHDFJLDIO.EndAAHHDFJLDIO(builder);
  }

  public static void StartAAHHDFJLDIO(FlatBufferBuilder builder) { builder.StartObject(18); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, int BBPHAPFBFHK) { builder.AddInt(0, BBPHAPFBFHK, 0); }
  public static void AddIIDCFMHCPLJ(FlatBufferBuilder builder, StringOffset IIDCFMHCPLJOffset) { builder.AddOffset(1, IIDCFMHCPLJOffset.Value, 0); }
  public static void AddDKMLEDJJFOI(FlatBufferBuilder builder, int DKMLEDJJFOI) { builder.AddInt(2, DKMLEDJJFOI, 0); }
  public static void AddGHHPIICJHDB(FlatBufferBuilder builder, StringOffset GHHPIICJHDBOffset) { builder.AddOffset(3, GHHPIICJHDBOffset.Value, 0); }
  public static void AddIJKHPPCHPGK(FlatBufferBuilder builder, StringOffset IJKHPPCHPGKOffset) { builder.AddOffset(4, IJKHPPCHPGKOffset.Value, 0); }
  public static void AddCLEEFGNMCEL(FlatBufferBuilder builder, int CLEEFGNMCEL) { builder.AddInt(5, CLEEFGNMCEL, 0); }
  public static void AddLPJPOOHJKAE(FlatBufferBuilder builder, int LPJPOOHJKAE) { builder.AddInt(6, LPJPOOHJKAE, 0); }
  public static void AddNJLJEKDBPCH(FlatBufferBuilder builder, int NJLJEKDBPCH) { builder.AddInt(7, NJLJEKDBPCH, 0); }
  public static void AddIPHMJNCEPIJ(FlatBufferBuilder builder, int IPHMJNCEPIJ) { builder.AddInt(8, IPHMJNCEPIJ, 0); }
  public static void AddJBAHJKKJPEG(FlatBufferBuilder builder, int JBAHJKKJPEG) { builder.AddInt(9, JBAHJKKJPEG, 0); }
  public static void AddOIMEOBNAAHH(FlatBufferBuilder builder, int OIMEOBNAAHH) { builder.AddInt(10, OIMEOBNAAHH, 0); }
  public static void AddEOHDEKFEONI(FlatBufferBuilder builder, int EOHDEKFEONI) { builder.AddInt(11, EOHDEKFEONI, 0); }
  public static void AddLCMOIMEFAHI(FlatBufferBuilder builder, StringOffset LCMOIMEFAHIOffset) { builder.AddOffset(12, LCMOIMEFAHIOffset.Value, 0); }
  public static void AddPELKLPGCMFN(FlatBufferBuilder builder, int PELKLPGCMFN) { builder.AddInt(13, PELKLPGCMFN, 0); }
  public static void AddIDKJOALBKAA(FlatBufferBuilder builder, VectorOffset IDKJOALBKAAOffset) { builder.AddOffset(14, IDKJOALBKAAOffset.Value, 0); }
  public static VectorOffset CreateIDKJOALBKAAVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartIDKJOALBKAAVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddAFDJJJOJBMO(FlatBufferBuilder builder, VectorOffset AFDJJJOJBMOOffset) { builder.AddOffset(15, AFDJJJOJBMOOffset.Value, 0); }
  public static VectorOffset CreateAFDJJJOJBMOVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static void StartAFDJJJOJBMOVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddMCPMLMHKKOP(FlatBufferBuilder builder, int MCPMLMHKKOP) { builder.AddInt(16, MCPMLMHKKOP, 0); }
  public static void AddBPMBFFDNMDD(FlatBufferBuilder builder, int BPMBFFDNMDD) { builder.AddInt(17, BPMBFFDNMDD, 0); }
  public static Offset<AAHHDFJLDIO> EndAAHHDFJLDIO(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<AAHHDFJLDIO>(o);
  }
};
