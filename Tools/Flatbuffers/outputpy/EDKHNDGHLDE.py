# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class EDKHNDGHLDE(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsEDKHNDGHLDE(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = EDKHNDGHLDE()
        x.Init(buf, n + offset)
        return x

    # EDKHNDGHLDE
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # EDKHNDGHLDE
    def MCJNHPMBPIJ(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # EDKHNDGHLDE
    def MGJKFKDICGC(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def EDKHNDGHLDEStart(builder): builder.StartObject(2)
def EDKHNDGHLDEAddMCJNHPMBPIJ(builder, MCJNHPMBPIJ): builder.PrependInt32Slot(0, MCJNHPMBPIJ, 0)
def EDKHNDGHLDEAddMGJKFKDICGC(builder, MGJKFKDICGC): builder.PrependInt32Slot(1, MGJKFKDICGC, 0)
def EDKHNDGHLDEEnd(builder): return builder.EndObject()
