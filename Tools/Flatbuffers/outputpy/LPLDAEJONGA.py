# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class LPLDAEJONGA(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsLPLDAEJONGA(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = LPLDAEJONGA()
        x.Init(buf, n + offset)
        return x

    # LPLDAEJONGA
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # LPLDAEJONGA
    def DGCEKGHCAKJ(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .GCFDBLLEKED import GCFDBLLEKED
            obj = GCFDBLLEKED()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # LPLDAEJONGA
    def DGCEKGHCAKJLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # LPLDAEJONGA
    def FJNMMFMGMKK(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .FOLCOOKNNKO import FOLCOOKNNKO
            obj = FOLCOOKNNKO()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # LPLDAEJONGA
    def FJNMMFMGMKKLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def LPLDAEJONGAStart(builder): builder.StartObject(2)
def LPLDAEJONGAAddDGCEKGHCAKJ(builder, DGCEKGHCAKJ): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(DGCEKGHCAKJ), 0)
def LPLDAEJONGAStartDGCEKGHCAKJVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def LPLDAEJONGAAddFJNMMFMGMKK(builder, FJNMMFMGMKK): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(FJNMMFMGMKK), 0)
def LPLDAEJONGAStartFJNMMFMGMKKVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def LPLDAEJONGAEnd(builder): return builder.EndObject()
