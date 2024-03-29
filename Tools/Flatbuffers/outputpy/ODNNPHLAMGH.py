# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class ODNNPHLAMGH(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsODNNPHLAMGH(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = ODNNPHLAMGH()
        x.Init(buf, n + offset)
        return x

    # ODNNPHLAMGH
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # ODNNPHLAMGH
    def AMGOKLNCCPH(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .FIMKNOFPMLA import FIMKNOFPMLA
            obj = FIMKNOFPMLA()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # ODNNPHLAMGH
    def AMGOKLNCCPHLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def ODNNPHLAMGHStart(builder): builder.StartObject(1)
def ODNNPHLAMGHAddAMGOKLNCCPH(builder, AMGOKLNCCPH): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(AMGOKLNCCPH), 0)
def ODNNPHLAMGHStartAMGOKLNCCPHVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def ODNNPHLAMGHEnd(builder): return builder.EndObject()
