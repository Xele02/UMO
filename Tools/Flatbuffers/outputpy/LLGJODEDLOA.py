# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class LLGJODEDLOA(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsLLGJODEDLOA(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = LLGJODEDLOA()
        x.Init(buf, n + offset)
        return x

    # LLGJODEDLOA
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # LLGJODEDLOA
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # LLGJODEDLOA
    def GAGNCJEKOLL(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # LLGJODEDLOA
    def GAGNCJEKOLLLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # LLGJODEDLOA
    def GPCCCOAHKAE(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # LLGJODEDLOA
    def GPCCCOAHKAELength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def LLGJODEDLOAStart(builder): builder.StartObject(3)
def LLGJODEDLOAAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependUint32Slot(0, BBPHAPFBFHK, 0)
def LLGJODEDLOAAddGAGNCJEKOLL(builder, GAGNCJEKOLL): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(GAGNCJEKOLL), 0)
def LLGJODEDLOAStartGAGNCJEKOLLVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def LLGJODEDLOAAddGPCCCOAHKAE(builder, GPCCCOAHKAE): builder.PrependUOffsetTRelativeSlot(2, flatbuffers.number_types.UOffsetTFlags.py_type(GPCCCOAHKAE), 0)
def LLGJODEDLOAStartGPCCCOAHKAEVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def LLGJODEDLOAEnd(builder): return builder.EndObject()
