# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class CNLOCJHENHP(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsCNLOCJHENHP(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = CNLOCJHENHP()
        x.Init(buf, n + offset)
        return x

    # CNLOCJHENHP
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # CNLOCJHENHP
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # CNLOCJHENHP
    def KOEFBBACOMJ(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .GHBCOHFGDMM import GHBCOHFGDMM
            obj = GHBCOHFGDMM()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # CNLOCJHENHP
    def KOEFBBACOMJLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def CNLOCJHENHPStart(builder): builder.StartObject(2)
def CNLOCJHENHPAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependUint32Slot(0, BBPHAPFBFHK, 0)
def CNLOCJHENHPAddKOEFBBACOMJ(builder, KOEFBBACOMJ): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(KOEFBBACOMJ), 0)
def CNLOCJHENHPStartKOEFBBACOMJVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def CNLOCJHENHPEnd(builder): return builder.EndObject()
