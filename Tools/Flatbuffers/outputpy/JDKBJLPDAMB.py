# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class JDKBJLPDAMB(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsJDKBJLPDAMB(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = JDKBJLPDAMB()
        x.Init(buf, n + offset)
        return x

    # JDKBJLPDAMB
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # JDKBJLPDAMB
    def PIIOHCJFHBD(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .LDOCPAKMACI import LDOCPAKMACI
            obj = LDOCPAKMACI()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # JDKBJLPDAMB
    def PIIOHCJFHBDLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def JDKBJLPDAMBStart(builder): builder.StartObject(1)
def JDKBJLPDAMBAddPIIOHCJFHBD(builder, PIIOHCJFHBD): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(PIIOHCJFHBD), 0)
def JDKBJLPDAMBStartPIIOHCJFHBDVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def JDKBJLPDAMBEnd(builder): return builder.EndObject()
