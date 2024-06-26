# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class FDEDPMKCNLB(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsFDEDPMKCNLB(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = FDEDPMKCNLB()
        x.Init(buf, n + offset)
        return x

    # FDEDPMKCNLB
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # FDEDPMKCNLB
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # FDEDPMKCNLB
    def OFMGALJGDAO(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # FDEDPMKCNLB
    def CFLMCGOJJJD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # FDEDPMKCNLB
    def NJLJEKDBPCH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # FDEDPMKCNLB
    def MAOAGDBDBIB(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # FDEDPMKCNLB
    def EOLOEKNHBGK(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # FDEDPMKCNLB
    def EOLOEKNHBGKLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # FDEDPMKCNLB
    def DHFIMBLLAMO(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(16))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # FDEDPMKCNLB
    def DHFIMBLLAMOLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(16))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def FDEDPMKCNLBStart(builder): builder.StartObject(7)
def FDEDPMKCNLBAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependInt32Slot(0, BBPHAPFBFHK, 0)
def FDEDPMKCNLBAddOFMGALJGDAO(builder, OFMGALJGDAO): builder.PrependInt32Slot(1, OFMGALJGDAO, 0)
def FDEDPMKCNLBAddCFLMCGOJJJD(builder, CFLMCGOJJJD): builder.PrependInt32Slot(2, CFLMCGOJJJD, 0)
def FDEDPMKCNLBAddNJLJEKDBPCH(builder, NJLJEKDBPCH): builder.PrependInt32Slot(3, NJLJEKDBPCH, 0)
def FDEDPMKCNLBAddMAOAGDBDBIB(builder, MAOAGDBDBIB): builder.PrependInt32Slot(4, MAOAGDBDBIB, 0)
def FDEDPMKCNLBAddEOLOEKNHBGK(builder, EOLOEKNHBGK): builder.PrependUOffsetTRelativeSlot(5, flatbuffers.number_types.UOffsetTFlags.py_type(EOLOEKNHBGK), 0)
def FDEDPMKCNLBStartEOLOEKNHBGKVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def FDEDPMKCNLBAddDHFIMBLLAMO(builder, DHFIMBLLAMO): builder.PrependUOffsetTRelativeSlot(6, flatbuffers.number_types.UOffsetTFlags.py_type(DHFIMBLLAMO), 0)
def FDEDPMKCNLBStartDHFIMBLLAMOVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def FDEDPMKCNLBEnd(builder): return builder.EndObject()
