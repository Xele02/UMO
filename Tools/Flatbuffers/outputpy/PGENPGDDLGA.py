# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class PGENPGDDLGA(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsPGENPGDDLGA(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = PGENPGDDLGA()
        x.Init(buf, n + offset)
        return x

    # PGENPGDDLGA
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # PGENPGDDLGA
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # PGENPGDDLGA
    def MCJNHPMBPIJ(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # PGENPGDDLGA
    def MGJKFKDICGC(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def PGENPGDDLGAStart(builder): builder.StartObject(3)
def PGENPGDDLGAAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependInt32Slot(0, BBPHAPFBFHK, 0)
def PGENPGDDLGAAddMCJNHPMBPIJ(builder, MCJNHPMBPIJ): builder.PrependInt32Slot(1, MCJNHPMBPIJ, 0)
def PGENPGDDLGAAddMGJKFKDICGC(builder, MGJKFKDICGC): builder.PrependInt32Slot(2, MGJKFKDICGC, 0)
def PGENPGDDLGAEnd(builder): return builder.EndObject()
