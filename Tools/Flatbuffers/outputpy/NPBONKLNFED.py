# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class NPBONKLNFED(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsNPBONKLNFED(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = NPBONKLNFED()
        x.Init(buf, n + offset)
        return x

    # NPBONKLNFED
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # NPBONKLNFED
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # NPBONKLNFED
    def OFMGALJGDAO(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # NPBONKLNFED
    def CFLMCGOJJJD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # NPBONKLNFED
    def LMLNKHMPOIG(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # NPBONKLNFED
    def ODBPKGJPLMD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # NPBONKLNFED
    def HMNFFFLCANH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # NPBONKLNFED
    def JHAMBKOEJPL(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(16))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # NPBONKLNFED
    def MJHPFNPCLBD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(18))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # NPBONKLNFED
    def JDKBBEIBJBD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(20))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def NPBONKLNFEDStart(builder): builder.StartObject(9)
def NPBONKLNFEDAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependInt32Slot(0, BBPHAPFBFHK, 0)
def NPBONKLNFEDAddOFMGALJGDAO(builder, OFMGALJGDAO): builder.PrependInt32Slot(1, OFMGALJGDAO, 0)
def NPBONKLNFEDAddCFLMCGOJJJD(builder, CFLMCGOJJJD): builder.PrependUint32Slot(2, CFLMCGOJJJD, 0)
def NPBONKLNFEDAddLMLNKHMPOIG(builder, LMLNKHMPOIG): builder.PrependUint32Slot(3, LMLNKHMPOIG, 0)
def NPBONKLNFEDAddODBPKGJPLMD(builder, ODBPKGJPLMD): builder.PrependUint32Slot(4, ODBPKGJPLMD, 0)
def NPBONKLNFEDAddHMNFFFLCANH(builder, HMNFFFLCANH): builder.PrependInt32Slot(5, HMNFFFLCANH, 0)
def NPBONKLNFEDAddJHAMBKOEJPL(builder, JHAMBKOEJPL): builder.PrependInt32Slot(6, JHAMBKOEJPL, 0)
def NPBONKLNFEDAddMJHPFNPCLBD(builder, MJHPFNPCLBD): builder.PrependInt32Slot(7, MJHPFNPCLBD, 0)
def NPBONKLNFEDAddJDKBBEIBJBD(builder, JDKBBEIBJBD): builder.PrependInt32Slot(8, JDKBBEIBJBD, 0)
def NPBONKLNFEDEnd(builder): return builder.EndObject()
