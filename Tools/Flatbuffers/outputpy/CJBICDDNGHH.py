# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class CJBICDDNGHH(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsCJBICDDNGHH(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = CJBICDDNGHH()
        x.Init(buf, n + offset)
        return x

    # CJBICDDNGHH
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # CJBICDDNGHH
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # CJBICDDNGHH
    def LPJPOOHJKAE(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # CJBICDDNGHH
    def MOMCBJDJDIA(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # CJBICDDNGHH
    def IMCIIPLKCNO(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # CJBICDDNGHH
    def NJLJEKDBPCH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # CJBICDDNGHH
    def MAOAGDBDBIB(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # CJBICDDNGHH
    def CFLMCGOJJJD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(16))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # CJBICDDNGHH
    def OFMGALJGDAO(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(18))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # CJBICDDNGHH
    def EJPEFOELHFD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(20))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # CJBICDDNGHH
    def IIDCFMHCPLJ(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(22))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

    # CJBICDDNGHH
    def GJEJFAJHBME(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(24))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def CJBICDDNGHHStart(builder): builder.StartObject(11)
def CJBICDDNGHHAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependUint32Slot(0, BBPHAPFBFHK, 0)
def CJBICDDNGHHAddLPJPOOHJKAE(builder, LPJPOOHJKAE): builder.PrependUint32Slot(1, LPJPOOHJKAE, 0)
def CJBICDDNGHHAddMOMCBJDJDIA(builder, MOMCBJDJDIA): builder.PrependInt32Slot(2, MOMCBJDJDIA, 0)
def CJBICDDNGHHAddIMCIIPLKCNO(builder, IMCIIPLKCNO): builder.PrependInt32Slot(3, IMCIIPLKCNO, 0)
def CJBICDDNGHHAddNJLJEKDBPCH(builder, NJLJEKDBPCH): builder.PrependUint32Slot(4, NJLJEKDBPCH, 0)
def CJBICDDNGHHAddMAOAGDBDBIB(builder, MAOAGDBDBIB): builder.PrependUint32Slot(5, MAOAGDBDBIB, 0)
def CJBICDDNGHHAddCFLMCGOJJJD(builder, CFLMCGOJJJD): builder.PrependUint32Slot(6, CFLMCGOJJJD, 0)
def CJBICDDNGHHAddOFMGALJGDAO(builder, OFMGALJGDAO): builder.PrependInt32Slot(7, OFMGALJGDAO, 0)
def CJBICDDNGHHAddEJPEFOELHFD(builder, EJPEFOELHFD): builder.PrependInt32Slot(8, EJPEFOELHFD, 0)
def CJBICDDNGHHAddIIDCFMHCPLJ(builder, IIDCFMHCPLJ): builder.PrependUOffsetTRelativeSlot(9, flatbuffers.number_types.UOffsetTFlags.py_type(IIDCFMHCPLJ), 0)
def CJBICDDNGHHAddGJEJFAJHBME(builder, GJEJFAJHBME): builder.PrependInt32Slot(10, GJEJFAJHBME, 0)
def CJBICDDNGHHEnd(builder): return builder.EndObject()
