# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class POLDFBLCDFN(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsPOLDFBLCDFN(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = POLDFBLCDFN()
        x.Init(buf, n + offset)
        return x

    # POLDFBLCDFN
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # POLDFBLCDFN
    def DNIDLBOLLGH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # POLDFBLCDFN
    def KMKKKKNNFGB(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # POLDFBLCDFN
    def KMKKKKNNFGBLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # POLDFBLCDFN
    def NDOLMCLBIBF(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # POLDFBLCDFN
    def NDOLMCLBIBFLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def POLDFBLCDFNStart(builder): builder.StartObject(3)
def POLDFBLCDFNAddDNIDLBOLLGH(builder, DNIDLBOLLGH): builder.PrependInt32Slot(0, DNIDLBOLLGH, 0)
def POLDFBLCDFNAddKMKKKKNNFGB(builder, KMKKKKNNFGB): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(KMKKKKNNFGB), 0)
def POLDFBLCDFNStartKMKKKKNNFGBVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def POLDFBLCDFNAddNDOLMCLBIBF(builder, NDOLMCLBIBF): builder.PrependUOffsetTRelativeSlot(2, flatbuffers.number_types.UOffsetTFlags.py_type(NDOLMCLBIBF), 0)
def POLDFBLCDFNStartNDOLMCLBIBFVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def POLDFBLCDFNEnd(builder): return builder.EndObject()
