// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class EMCHOIHFOHN : Table {
  public static EMCHOIHFOHN GetRootAsEMCHOIHFOHN(ByteBuffer _bb) { return GetRootAsEMCHOIHFOHN(_bb, new EMCHOIHFOHN()); }
  public static EMCHOIHFOHN GetRootAsEMCHOIHFOHN(ByteBuffer _bb, EMCHOIHFOHN obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public EMCHOIHFOHN __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint IPCBHGGLEJA { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public int CIOGNKLHPDE { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public uint NABLNBMACHL { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GetENFCBLPNAFO(int j) { int o = __offset(10); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int ENFCBLPNAFOLength { get { int o = __offset(10); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetENFCBLPNAFOBytes() { return __vector_as_arraysegment(10); }
  public uint LMKLPPINLOK { get { int o = __offset(12); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GetLGJDLFJCCLK(int j) { int o = __offset(14); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int LGJDLFJCCLKLength { get { int o = __offset(14); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetLGJDLFJCCLKBytes() { return __vector_as_arraysegment(14); }
  public uint LIGDKLEFBNM { get { int o = __offset(16); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GetBMICKLAGCCD(int j) { int o = __offset(18); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int BMICKLAGCCDLength { get { int o = __offset(18); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetBMICKLAGCCDBytes() { return __vector_as_arraysegment(18); }
  public uint JKONGPGFPNN { get { int o = __offset(20); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint DGMDFCHIBKD { get { int o = __offset(22); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GetDINDMDCKMCP(int j) { int o = __offset(24); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int DINDMDCKMCPLength { get { int o = __offset(24); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetDINDMDCKMCPBytes() { return __vector_as_arraysegment(24); }
  public uint EJNIJBKBNGE { get { int o = __offset(26); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint GetEBDOOBOFLFM(int j) { int o = __offset(28); return o != 0 ? bb.GetUint(__vector(o) + j * 4) : (uint)0; }
  public int EBDOOBOFLFMLength { get { int o = __offset(28); return o != 0 ? __vector_len(o) : 0; } }
  public ArraySegment<byte>? GetEBDOOBOFLFMBytes() { return __vector_as_arraysegment(28); }
  public uint OBAOICIEFHO { get { int o = __offset(30); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint FLNOLLMJOKE { get { int o = __offset(32); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint KHLNIPBFCNK { get { int o = __offset(34); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint EOHDEKFEONI { get { int o = __offset(36); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint FHKGIFCFEPI { get { int o = __offset(38); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint DMEMJNAEDHP { get { int o = __offset(40); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public int MBBCOAFGCJL { get { int o = __offset(42); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int AFIBPDNHCNC { get { int o = __offset(44); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public uint BKKAFNHOJFE { get { int o = __offset(46); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint PGKFEHHDIBH { get { int o = __offset(48); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }

  public static Offset<EMCHOIHFOHN> CreateEMCHOIHFOHN(FlatBufferBuilder builder,
      uint IPCBHGGLEJA = 0,
      int CIOGNKLHPDE = 0,
      uint NABLNBMACHL = 0,
      VectorOffset ENFCBLPNAFOOffset = default(VectorOffset),
      uint LMKLPPINLOK = 0,
      VectorOffset LGJDLFJCCLKOffset = default(VectorOffset),
      uint LIGDKLEFBNM = 0,
      VectorOffset BMICKLAGCCDOffset = default(VectorOffset),
      uint JKONGPGFPNN = 0,
      uint DGMDFCHIBKD = 0,
      VectorOffset DINDMDCKMCPOffset = default(VectorOffset),
      uint EJNIJBKBNGE = 0,
      VectorOffset EBDOOBOFLFMOffset = default(VectorOffset),
      uint OBAOICIEFHO = 0,
      uint FLNOLLMJOKE = 0,
      uint KHLNIPBFCNK = 0,
      uint EOHDEKFEONI = 0,
      uint FHKGIFCFEPI = 0,
      uint DMEMJNAEDHP = 0,
      int MBBCOAFGCJL = 0,
      int AFIBPDNHCNC = 0,
      uint BKKAFNHOJFE = 0,
      uint PGKFEHHDIBH = 0) {
    builder.StartObject(23);
    EMCHOIHFOHN.AddPGKFEHHDIBH(builder, PGKFEHHDIBH);
    EMCHOIHFOHN.AddBKKAFNHOJFE(builder, BKKAFNHOJFE);
    EMCHOIHFOHN.AddAFIBPDNHCNC(builder, AFIBPDNHCNC);
    EMCHOIHFOHN.AddMBBCOAFGCJL(builder, MBBCOAFGCJL);
    EMCHOIHFOHN.AddDMEMJNAEDHP(builder, DMEMJNAEDHP);
    EMCHOIHFOHN.AddFHKGIFCFEPI(builder, FHKGIFCFEPI);
    EMCHOIHFOHN.AddEOHDEKFEONI(builder, EOHDEKFEONI);
    EMCHOIHFOHN.AddKHLNIPBFCNK(builder, KHLNIPBFCNK);
    EMCHOIHFOHN.AddFLNOLLMJOKE(builder, FLNOLLMJOKE);
    EMCHOIHFOHN.AddOBAOICIEFHO(builder, OBAOICIEFHO);
    EMCHOIHFOHN.AddEBDOOBOFLFM(builder, EBDOOBOFLFMOffset);
    EMCHOIHFOHN.AddEJNIJBKBNGE(builder, EJNIJBKBNGE);
    EMCHOIHFOHN.AddDINDMDCKMCP(builder, DINDMDCKMCPOffset);
    EMCHOIHFOHN.AddDGMDFCHIBKD(builder, DGMDFCHIBKD);
    EMCHOIHFOHN.AddJKONGPGFPNN(builder, JKONGPGFPNN);
    EMCHOIHFOHN.AddBMICKLAGCCD(builder, BMICKLAGCCDOffset);
    EMCHOIHFOHN.AddLIGDKLEFBNM(builder, LIGDKLEFBNM);
    EMCHOIHFOHN.AddLGJDLFJCCLK(builder, LGJDLFJCCLKOffset);
    EMCHOIHFOHN.AddLMKLPPINLOK(builder, LMKLPPINLOK);
    EMCHOIHFOHN.AddENFCBLPNAFO(builder, ENFCBLPNAFOOffset);
    EMCHOIHFOHN.AddNABLNBMACHL(builder, NABLNBMACHL);
    EMCHOIHFOHN.AddCIOGNKLHPDE(builder, CIOGNKLHPDE);
    EMCHOIHFOHN.AddIPCBHGGLEJA(builder, IPCBHGGLEJA);
    return EMCHOIHFOHN.EndEMCHOIHFOHN(builder);
  }

  public static void StartEMCHOIHFOHN(FlatBufferBuilder builder) { builder.StartObject(23); }
  public static void AddIPCBHGGLEJA(FlatBufferBuilder builder, uint IPCBHGGLEJA) { builder.AddUint(0, IPCBHGGLEJA, 0); }
  public static void AddCIOGNKLHPDE(FlatBufferBuilder builder, int CIOGNKLHPDE) { builder.AddInt(1, CIOGNKLHPDE, 0); }
  public static void AddNABLNBMACHL(FlatBufferBuilder builder, uint NABLNBMACHL) { builder.AddUint(2, NABLNBMACHL, 0); }
  public static void AddENFCBLPNAFO(FlatBufferBuilder builder, VectorOffset ENFCBLPNAFOOffset) { builder.AddOffset(3, ENFCBLPNAFOOffset.Value, 0); }
  public static VectorOffset CreateENFCBLPNAFOVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartENFCBLPNAFOVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddLMKLPPINLOK(FlatBufferBuilder builder, uint LMKLPPINLOK) { builder.AddUint(4, LMKLPPINLOK, 0); }
  public static void AddLGJDLFJCCLK(FlatBufferBuilder builder, VectorOffset LGJDLFJCCLKOffset) { builder.AddOffset(5, LGJDLFJCCLKOffset.Value, 0); }
  public static VectorOffset CreateLGJDLFJCCLKVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartLGJDLFJCCLKVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddLIGDKLEFBNM(FlatBufferBuilder builder, uint LIGDKLEFBNM) { builder.AddUint(6, LIGDKLEFBNM, 0); }
  public static void AddBMICKLAGCCD(FlatBufferBuilder builder, VectorOffset BMICKLAGCCDOffset) { builder.AddOffset(7, BMICKLAGCCDOffset.Value, 0); }
  public static VectorOffset CreateBMICKLAGCCDVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartBMICKLAGCCDVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddJKONGPGFPNN(FlatBufferBuilder builder, uint JKONGPGFPNN) { builder.AddUint(8, JKONGPGFPNN, 0); }
  public static void AddDGMDFCHIBKD(FlatBufferBuilder builder, uint DGMDFCHIBKD) { builder.AddUint(9, DGMDFCHIBKD, 0); }
  public static void AddDINDMDCKMCP(FlatBufferBuilder builder, VectorOffset DINDMDCKMCPOffset) { builder.AddOffset(10, DINDMDCKMCPOffset.Value, 0); }
  public static VectorOffset CreateDINDMDCKMCPVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartDINDMDCKMCPVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddEJNIJBKBNGE(FlatBufferBuilder builder, uint EJNIJBKBNGE) { builder.AddUint(11, EJNIJBKBNGE, 0); }
  public static void AddEBDOOBOFLFM(FlatBufferBuilder builder, VectorOffset EBDOOBOFLFMOffset) { builder.AddOffset(12, EBDOOBOFLFMOffset.Value, 0); }
  public static VectorOffset CreateEBDOOBOFLFMVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static void StartEBDOOBOFLFMVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddOBAOICIEFHO(FlatBufferBuilder builder, uint OBAOICIEFHO) { builder.AddUint(13, OBAOICIEFHO, 0); }
  public static void AddFLNOLLMJOKE(FlatBufferBuilder builder, uint FLNOLLMJOKE) { builder.AddUint(14, FLNOLLMJOKE, 0); }
  public static void AddKHLNIPBFCNK(FlatBufferBuilder builder, uint KHLNIPBFCNK) { builder.AddUint(15, KHLNIPBFCNK, 0); }
  public static void AddEOHDEKFEONI(FlatBufferBuilder builder, uint EOHDEKFEONI) { builder.AddUint(16, EOHDEKFEONI, 0); }
  public static void AddFHKGIFCFEPI(FlatBufferBuilder builder, uint FHKGIFCFEPI) { builder.AddUint(17, FHKGIFCFEPI, 0); }
  public static void AddDMEMJNAEDHP(FlatBufferBuilder builder, uint DMEMJNAEDHP) { builder.AddUint(18, DMEMJNAEDHP, 0); }
  public static void AddMBBCOAFGCJL(FlatBufferBuilder builder, int MBBCOAFGCJL) { builder.AddInt(19, MBBCOAFGCJL, 0); }
  public static void AddAFIBPDNHCNC(FlatBufferBuilder builder, int AFIBPDNHCNC) { builder.AddInt(20, AFIBPDNHCNC, 0); }
  public static void AddBKKAFNHOJFE(FlatBufferBuilder builder, uint BKKAFNHOJFE) { builder.AddUint(21, BKKAFNHOJFE, 0); }
  public static void AddPGKFEHHDIBH(FlatBufferBuilder builder, uint PGKFEHHDIBH) { builder.AddUint(22, PGKFEHHDIBH, 0); }
  public static Offset<EMCHOIHFOHN> EndEMCHOIHFOHN(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<EMCHOIHFOHN>(o);
  }
};

