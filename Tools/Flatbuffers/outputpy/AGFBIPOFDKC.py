# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class AGFBIPOFDKC(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsAGFBIPOFDKC(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = AGFBIPOFDKC()
        x.Init(buf, n + offset)
        return x

    # AGFBIPOFDKC
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # AGFBIPOFDKC
    def CILHGCNPEFO(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # AGFBIPOFDKC
    def CFLMCGOJJJD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # AGFBIPOFDKC
    def IDHMHHMGAHM(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

    # AGFBIPOFDKC
    def EKKCGKJJOFN(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

    # AGFBIPOFDKC
    def OLFHCANIOKL(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

    # AGFBIPOFDKC
    def ENOJILKGDPM(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

    # AGFBIPOFDKC
    def EOKIODCFLMP(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(16))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # AGFBIPOFDKC
    def CMHHLIAFHEB(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(18))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # AGFBIPOFDKC
    def ADJFMDNEKEB(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(20))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # AGFBIPOFDKC
    def HDJFOAJOFKC(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(22))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def AGFBIPOFDKCStart(builder): builder.StartObject(10)
def AGFBIPOFDKCAddCILHGCNPEFO(builder, CILHGCNPEFO): builder.PrependInt32Slot(0, CILHGCNPEFO, 0)
def AGFBIPOFDKCAddCFLMCGOJJJD(builder, CFLMCGOJJJD): builder.PrependInt32Slot(1, CFLMCGOJJJD, 0)
def AGFBIPOFDKCAddIDHMHHMGAHM(builder, IDHMHHMGAHM): builder.PrependUOffsetTRelativeSlot(2, flatbuffers.number_types.UOffsetTFlags.py_type(IDHMHHMGAHM), 0)
def AGFBIPOFDKCAddEKKCGKJJOFN(builder, EKKCGKJJOFN): builder.PrependUOffsetTRelativeSlot(3, flatbuffers.number_types.UOffsetTFlags.py_type(EKKCGKJJOFN), 0)
def AGFBIPOFDKCAddOLFHCANIOKL(builder, OLFHCANIOKL): builder.PrependUOffsetTRelativeSlot(4, flatbuffers.number_types.UOffsetTFlags.py_type(OLFHCANIOKL), 0)
def AGFBIPOFDKCAddENOJILKGDPM(builder, ENOJILKGDPM): builder.PrependUOffsetTRelativeSlot(5, flatbuffers.number_types.UOffsetTFlags.py_type(ENOJILKGDPM), 0)
def AGFBIPOFDKCAddEOKIODCFLMP(builder, EOKIODCFLMP): builder.PrependInt32Slot(6, EOKIODCFLMP, 0)
def AGFBIPOFDKCAddCMHHLIAFHEB(builder, CMHHLIAFHEB): builder.PrependInt32Slot(7, CMHHLIAFHEB, 0)
def AGFBIPOFDKCAddADJFMDNEKEB(builder, ADJFMDNEKEB): builder.PrependInt32Slot(8, ADJFMDNEKEB, 0)
def AGFBIPOFDKCAddHDJFOAJOFKC(builder, HDJFOAJOFKC): builder.PrependInt32Slot(9, HDJFOAJOFKC, 0)
def AGFBIPOFDKCEnd(builder): return builder.EndObject()
