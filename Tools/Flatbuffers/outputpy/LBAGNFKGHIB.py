# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class LBAGNFKGHIB(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsLBAGNFKGHIB(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = LBAGNFKGHIB()
        x.Init(buf, n + offset)
        return x

    # LBAGNFKGHIB
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # LBAGNFKGHIB
    def CNOBKOPJGPL(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .AAHHDFJLDIO import AAHHDFJLDIO
            obj = AAHHDFJLDIO()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # LBAGNFKGHIB
    def CNOBKOPJGPLLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # LBAGNFKGHIB
    def MDOIDBIGFJI(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .LFDPEDHPEKC import LFDPEDHPEKC
            obj = LFDPEDHPEKC()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # LBAGNFKGHIB
    def MDOIDBIGFJILength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def LBAGNFKGHIBStart(builder): builder.StartObject(2)
def LBAGNFKGHIBAddCNOBKOPJGPL(builder, CNOBKOPJGPL): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(CNOBKOPJGPL), 0)
def LBAGNFKGHIBStartCNOBKOPJGPLVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def LBAGNFKGHIBAddMDOIDBIGFJI(builder, MDOIDBIGFJI): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(MDOIDBIGFJI), 0)
def LBAGNFKGHIBStartMDOIDBIGFJIVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def LBAGNFKGHIBEnd(builder): return builder.EndObject()
