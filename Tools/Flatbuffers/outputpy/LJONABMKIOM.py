# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class LJONABMKIOM(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsLJONABMKIOM(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = LJONABMKIOM()
        x.Init(buf, n + offset)
        return x

    # LJONABMKIOM
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # LJONABMKIOM
    def BNFLNMGOJCM(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # LJONABMKIOM
    def BPODDGNIDBG(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.String(a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return ""

    # LJONABMKIOM
    def BPODDGNIDBGLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def LJONABMKIOMStart(builder): builder.StartObject(2)
def LJONABMKIOMAddBNFLNMGOJCM(builder, BNFLNMGOJCM): builder.PrependInt32Slot(0, BNFLNMGOJCM, 0)
def LJONABMKIOMAddBPODDGNIDBG(builder, BPODDGNIDBG): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(BPODDGNIDBG), 0)
def LJONABMKIOMStartBPODDGNIDBGVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def LJONABMKIOMEnd(builder): return builder.EndObject()
