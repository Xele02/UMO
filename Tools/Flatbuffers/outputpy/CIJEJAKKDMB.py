# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class CIJEJAKKDMB(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsCIJEJAKKDMB(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = CIJEJAKKDMB()
        x.Init(buf, n + offset)
        return x

    # CIJEJAKKDMB
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # CIJEJAKKDMB
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # CIJEJAKKDMB
    def CFLMCGOJJJD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # CIJEJAKKDMB
    def KJFEBMBHKOC(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # CIJEJAKKDMB
    def IBDFJIDNDJH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # CIJEJAKKDMB
    def GLIIHLOLPEF(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # CIJEJAKKDMB
    def KMEODDMBHHE(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def CIJEJAKKDMBStart(builder): builder.StartObject(6)
def CIJEJAKKDMBAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependUint32Slot(0, BBPHAPFBFHK, 0)
def CIJEJAKKDMBAddCFLMCGOJJJD(builder, CFLMCGOJJJD): builder.PrependUint32Slot(1, CFLMCGOJJJD, 0)
def CIJEJAKKDMBAddKJFEBMBHKOC(builder, KJFEBMBHKOC): builder.PrependUint32Slot(2, KJFEBMBHKOC, 0)
def CIJEJAKKDMBAddIBDFJIDNDJH(builder, IBDFJIDNDJH): builder.PrependInt32Slot(3, IBDFJIDNDJH, 0)
def CIJEJAKKDMBAddGLIIHLOLPEF(builder, GLIIHLOLPEF): builder.PrependInt32Slot(4, GLIIHLOLPEF, 0)
def CIJEJAKKDMBAddKMEODDMBHHE(builder, KMEODDMBHHE): builder.PrependInt32Slot(5, KMEODDMBHHE, 0)
def CIJEJAKKDMBEnd(builder): return builder.EndObject()