# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class HHKGAENKODC(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsHHKGAENKODC(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = HHKGAENKODC()
        x.Init(buf, n + offset)
        return x

    # HHKGAENKODC
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # HHKGAENKODC
    def EJBHJLJKIBI(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # HHKGAENKODC
    def EJBHJLJKIBILength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # HHKGAENKODC
    def FANEHEDBCBF(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # HHKGAENKODC
    def FANEHEDBCBFLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # HHKGAENKODC
    def IHCDJMMMHDL(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # HHKGAENKODC
    def IHCDJMMMHDLLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # HHKGAENKODC
    def AEAHJAHOBMM(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # HHKGAENKODC
    def AEAHJAHOBMMLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # HHKGAENKODC
    def FGOPOABBIPB(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # HHKGAENKODC
    def FGOPOABBIPBLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # HHKGAENKODC
    def MMPGEHLNGBE(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # HHKGAENKODC
    def MMPGEHLNGBELength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def HHKGAENKODCStart(builder): builder.StartObject(6)
def HHKGAENKODCAddEJBHJLJKIBI(builder, EJBHJLJKIBI): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(EJBHJLJKIBI), 0)
def HHKGAENKODCStartEJBHJLJKIBIVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HHKGAENKODCAddFANEHEDBCBF(builder, FANEHEDBCBF): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(FANEHEDBCBF), 0)
def HHKGAENKODCStartFANEHEDBCBFVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HHKGAENKODCAddIHCDJMMMHDL(builder, IHCDJMMMHDL): builder.PrependUOffsetTRelativeSlot(2, flatbuffers.number_types.UOffsetTFlags.py_type(IHCDJMMMHDL), 0)
def HHKGAENKODCStartIHCDJMMMHDLVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HHKGAENKODCAddAEAHJAHOBMM(builder, AEAHJAHOBMM): builder.PrependUOffsetTRelativeSlot(3, flatbuffers.number_types.UOffsetTFlags.py_type(AEAHJAHOBMM), 0)
def HHKGAENKODCStartAEAHJAHOBMMVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HHKGAENKODCAddFGOPOABBIPB(builder, FGOPOABBIPB): builder.PrependUOffsetTRelativeSlot(4, flatbuffers.number_types.UOffsetTFlags.py_type(FGOPOABBIPB), 0)
def HHKGAENKODCStartFGOPOABBIPBVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HHKGAENKODCAddMMPGEHLNGBE(builder, MMPGEHLNGBE): builder.PrependUOffsetTRelativeSlot(5, flatbuffers.number_types.UOffsetTFlags.py_type(MMPGEHLNGBE), 0)
def HHKGAENKODCStartMMPGEHLNGBEVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HHKGAENKODCEnd(builder): return builder.EndObject()