# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class JIIFKJGKCNM(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsJIIFKJGKCNM(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = JIIFKJGKCNM()
        x.Init(buf, n + offset)
        return x

    # JIIFKJGKCNM
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # JIIFKJGKCNM
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # JIIFKJGKCNM
    def JNFHLJCMAAA(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Int32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # JIIFKJGKCNM
    def JNFHLJCMAAALength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def JIIFKJGKCNMStart(builder): builder.StartObject(2)
def JIIFKJGKCNMAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependUint32Slot(0, BBPHAPFBFHK, 0)
def JIIFKJGKCNMAddJNFHLJCMAAA(builder, JNFHLJCMAAA): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(JNFHLJCMAAA), 0)
def JIIFKJGKCNMStartJNFHLJCMAAAVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def JIIFKJGKCNMEnd(builder): return builder.EndObject()
