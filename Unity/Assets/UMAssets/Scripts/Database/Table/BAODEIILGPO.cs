// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class BAODEIILGPO : Table {
  public static BAODEIILGPO GetRootAsBAODEIILGPO(ByteBuffer _bb) { return GetRootAsBAODEIILGPO(_bb, new BAODEIILGPO()); }
  public static BAODEIILGPO GetRootAsBAODEIILGPO(ByteBuffer _bb, BAODEIILGPO obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public BAODEIILGPO __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string IIDCFMHCPLJ { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public ArraySegment<byte>? GetIIDCFMHCPLJBytes() { return __vector_as_arraysegment(4); }
  public int OGJMNHLILJG { get { int o = __offset(6); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public int IPHMJNCEPIJ { get { int o = __offset(8); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }

  public static Offset<BAODEIILGPO> CreateBAODEIILGPO(FlatBufferBuilder builder,
      StringOffset IIDCFMHCPLJOffset = default(StringOffset),
      int OGJMNHLILJG = 0,
      int IPHMJNCEPIJ = 0) {
    builder.StartObject(3);
    BAODEIILGPO.AddIPHMJNCEPIJ(builder, IPHMJNCEPIJ);
    BAODEIILGPO.AddOGJMNHLILJG(builder, OGJMNHLILJG);
    BAODEIILGPO.AddIIDCFMHCPLJ(builder, IIDCFMHCPLJOffset);
    return BAODEIILGPO.EndBAODEIILGPO(builder);
  }

  public static void StartBAODEIILGPO(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddIIDCFMHCPLJ(FlatBufferBuilder builder, StringOffset IIDCFMHCPLJOffset) { builder.AddOffset(0, IIDCFMHCPLJOffset.Value, 0); }
  public static void AddOGJMNHLILJG(FlatBufferBuilder builder, int OGJMNHLILJG) { builder.AddInt(1, OGJMNHLILJG, 0); }
  public static void AddIPHMJNCEPIJ(FlatBufferBuilder builder, int IPHMJNCEPIJ) { builder.AddInt(2, IPHMJNCEPIJ, 0); }
  public static Offset<BAODEIILGPO> EndBAODEIILGPO(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<BAODEIILGPO>(o);
  }
};
