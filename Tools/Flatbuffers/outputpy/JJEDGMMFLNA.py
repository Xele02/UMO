# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class JJEDGMMFLNA(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsJJEDGMMFLNA(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = JJEDGMMFLNA()
        x.Init(buf, n + offset)
        return x

    # JJEDGMMFLNA
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # JJEDGMMFLNA
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # JJEDGMMFLNA
    def OFMGALJGDAO(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # JJEDGMMFLNA
    def CFLMCGOJJJD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # JJEDGMMFLNA
    def GKNBEHEMMFH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # JJEDGMMFLNA
    def MJOCIHPPKNO(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # JJEDGMMFLNA
    def NJLJEKDBPCH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # JJEDGMMFLNA
    def MAOAGDBDBIB(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(16))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def JJEDGMMFLNAStart(builder): builder.StartObject(7)
def JJEDGMMFLNAAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependInt32Slot(0, BBPHAPFBFHK, 0)
def JJEDGMMFLNAAddOFMGALJGDAO(builder, OFMGALJGDAO): builder.PrependInt32Slot(1, OFMGALJGDAO, 0)
def JJEDGMMFLNAAddCFLMCGOJJJD(builder, CFLMCGOJJJD): builder.PrependInt32Slot(2, CFLMCGOJJJD, 0)
def JJEDGMMFLNAAddGKNBEHEMMFH(builder, GKNBEHEMMFH): builder.PrependInt32Slot(3, GKNBEHEMMFH, 0)
def JJEDGMMFLNAAddMJOCIHPPKNO(builder, MJOCIHPPKNO): builder.PrependInt32Slot(4, MJOCIHPPKNO, 0)
def JJEDGMMFLNAAddNJLJEKDBPCH(builder, NJLJEKDBPCH): builder.PrependInt32Slot(5, NJLJEKDBPCH, 0)
def JJEDGMMFLNAAddMAOAGDBDBIB(builder, MAOAGDBDBIB): builder.PrependInt32Slot(6, MAOAGDBDBIB, 0)
def JJEDGMMFLNAEnd(builder): return builder.EndObject()
