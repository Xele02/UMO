# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class EBDJIPDILLC(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsEBDJIPDILLC(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = EBDJIPDILLC()
        x.Init(buf, n + offset)
        return x

    # EBDJIPDILLC
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # EBDJIPDILLC
    def BIDEEFOGFCG(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .EJMDBHGILEI import EJMDBHGILEI
            obj = EJMDBHGILEI()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # EBDJIPDILLC
    def BIDEEFOGFCGLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def EBDJIPDILLCStart(builder): builder.StartObject(1)
def EBDJIPDILLCAddBIDEEFOGFCG(builder, BIDEEFOGFCG): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(BIDEEFOGFCG), 0)
def EBDJIPDILLCStartBIDEEFOGFCGVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def EBDJIPDILLCEnd(builder): return builder.EndObject()
