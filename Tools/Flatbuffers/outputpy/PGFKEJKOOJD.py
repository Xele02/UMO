# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class PGFKEJKOOJD(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsPGFKEJKOOJD(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = PGFKEJKOOJD()
        x.Init(buf, n + offset)
        return x

    # PGFKEJKOOJD
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # PGFKEJKOOJD
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # PGFKEJKOOJD
    def CFLMCGOJJJD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # PGFKEJKOOJD
    def NJLJEKDBPCH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # PGFKEJKOOJD
    def MAOAGDBDBIB(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

def PGFKEJKOOJDStart(builder): builder.StartObject(4)
def PGFKEJKOOJDAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependUint32Slot(0, BBPHAPFBFHK, 0)
def PGFKEJKOOJDAddCFLMCGOJJJD(builder, CFLMCGOJJJD): builder.PrependUint32Slot(1, CFLMCGOJJJD, 0)
def PGFKEJKOOJDAddNJLJEKDBPCH(builder, NJLJEKDBPCH): builder.PrependUint32Slot(2, NJLJEKDBPCH, 0)
def PGFKEJKOOJDAddMAOAGDBDBIB(builder, MAOAGDBDBIB): builder.PrependUint32Slot(3, MAOAGDBDBIB, 0)
def PGFKEJKOOJDEnd(builder): return builder.EndObject()
