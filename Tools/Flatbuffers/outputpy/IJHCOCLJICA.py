# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class IJHCOCLJICA(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsIJHCOCLJICA(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = IJHCOCLJICA()
        x.Init(buf, n + offset)
        return x

    # IJHCOCLJICA
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # IJHCOCLJICA
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # IJHCOCLJICA
    def OFMGALJGDAO(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # IJHCOCLJICA
    def CFLMCGOJJJD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # IJHCOCLJICA
    def LPJPOOHJKAE(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # IJHCOCLJICA
    def HOENDPOGFIO(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # IJHCOCLJICA
    def IINNLHJJLHD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # IJHCOCLJICA
    def ODBPKGJPLMD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(16))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # IJHCOCLJICA
    def PJEDCALAIFP(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(18))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # IJHCOCLJICA
    def KCEANJAMDBD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(20))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def IJHCOCLJICAStart(builder): builder.StartObject(9)
def IJHCOCLJICAAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependUint32Slot(0, BBPHAPFBFHK, 0)
def IJHCOCLJICAAddOFMGALJGDAO(builder, OFMGALJGDAO): builder.PrependInt32Slot(1, OFMGALJGDAO, 0)
def IJHCOCLJICAAddCFLMCGOJJJD(builder, CFLMCGOJJJD): builder.PrependUint32Slot(2, CFLMCGOJJJD, 0)
def IJHCOCLJICAAddLPJPOOHJKAE(builder, LPJPOOHJKAE): builder.PrependUint32Slot(3, LPJPOOHJKAE, 0)
def IJHCOCLJICAAddHOENDPOGFIO(builder, HOENDPOGFIO): builder.PrependUint32Slot(4, HOENDPOGFIO, 0)
def IJHCOCLJICAAddIINNLHJJLHD(builder, IINNLHJJLHD): builder.PrependUint32Slot(5, IINNLHJJLHD, 0)
def IJHCOCLJICAAddODBPKGJPLMD(builder, ODBPKGJPLMD): builder.PrependUint32Slot(6, ODBPKGJPLMD, 0)
def IJHCOCLJICAAddPJEDCALAIFP(builder, PJEDCALAIFP): builder.PrependInt32Slot(7, PJEDCALAIFP, 0)
def IJHCOCLJICAAddKCEANJAMDBD(builder, KCEANJAMDBD): builder.PrependInt32Slot(8, KCEANJAMDBD, 0)
def IJHCOCLJICAEnd(builder): return builder.EndObject()
