# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class GAJBGNNNHCP(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsGAJBGNNNHCP(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = GAJBGNNNHCP()
        x.Init(buf, n + offset)
        return x

    # GAJBGNNNHCP
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # GAJBGNNNHCP
    def PHGKBJDEJKI(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # GAJBGNNNHCP
    def PHGKBJDEJKILength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # GAJBGNNNHCP
    def OOFMHMCDPEM(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # GAJBGNNNHCP
    def OOFMHMCDPEMLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # GAJBGNNNHCP
    def GEJGMBBCFEE(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def GAJBGNNNHCPStart(builder): builder.StartObject(3)
def GAJBGNNNHCPAddPHGKBJDEJKI(builder, PHGKBJDEJKI): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(PHGKBJDEJKI), 0)
def GAJBGNNNHCPStartPHGKBJDEJKIVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def GAJBGNNNHCPAddOOFMHMCDPEM(builder, OOFMHMCDPEM): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(OOFMHMCDPEM), 0)
def GAJBGNNNHCPStartOOFMHMCDPEMVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def GAJBGNNNHCPAddGEJGMBBCFEE(builder, GEJGMBBCFEE): builder.PrependInt32Slot(2, GEJGMBBCFEE, 0)
def GAJBGNNNHCPEnd(builder): return builder.EndObject()
