# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class ILOKJEKGMOB(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsILOKJEKGMOB(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = ILOKJEKGMOB()
        x.Init(buf, n + offset)
        return x

    # ILOKJEKGMOB
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # ILOKJEKGMOB
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # ILOKJEKGMOB
    def GJEJFAJHBME(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # ILOKJEKGMOB
    def KAOBJENOMHF(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # ILOKJEKGMOB
    def DALJDMJEJGE(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # ILOKJEKGMOB
    def JJPIKBCKLGF(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # ILOKJEKGMOB
    def ENPKFDIPGPF(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # ILOKJEKGMOB
    def CFLMCGOJJJD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(16))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # ILOKJEKGMOB
    def DLJEENDFNDB(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(18))
        if o != 0:
            a = self._tab.Vector(o)
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, a + flatbuffers.number_types.UOffsetTFlags.py_type(j * 4))
        return 0

    # ILOKJEKGMOB
    def DLJEENDFNDBLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(18))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # ILOKJEKGMOB
    def OFMGALJGDAO(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(20))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # ILOKJEKGMOB
    def MPIHPCJAHGA(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(22))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # ILOKJEKGMOB
    def GBJKMHDILHH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(24))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def ILOKJEKGMOBStart(builder): builder.StartObject(11)
def ILOKJEKGMOBAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependUint32Slot(0, BBPHAPFBFHK, 0)
def ILOKJEKGMOBAddGJEJFAJHBME(builder, GJEJFAJHBME): builder.PrependUint32Slot(1, GJEJFAJHBME, 0)
def ILOKJEKGMOBAddKAOBJENOMHF(builder, KAOBJENOMHF): builder.PrependUint32Slot(2, KAOBJENOMHF, 0)
def ILOKJEKGMOBAddDALJDMJEJGE(builder, DALJDMJEJGE): builder.PrependUint32Slot(3, DALJDMJEJGE, 0)
def ILOKJEKGMOBAddJJPIKBCKLGF(builder, JJPIKBCKLGF): builder.PrependUint32Slot(4, JJPIKBCKLGF, 0)
def ILOKJEKGMOBAddENPKFDIPGPF(builder, ENPKFDIPGPF): builder.PrependUint32Slot(5, ENPKFDIPGPF, 0)
def ILOKJEKGMOBAddCFLMCGOJJJD(builder, CFLMCGOJJJD): builder.PrependUint32Slot(6, CFLMCGOJJJD, 0)
def ILOKJEKGMOBAddDLJEENDFNDB(builder, DLJEENDFNDB): builder.PrependUOffsetTRelativeSlot(7, flatbuffers.number_types.UOffsetTFlags.py_type(DLJEENDFNDB), 0)
def ILOKJEKGMOBStartDLJEENDFNDBVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def ILOKJEKGMOBAddOFMGALJGDAO(builder, OFMGALJGDAO): builder.PrependInt32Slot(8, OFMGALJGDAO, 0)
def ILOKJEKGMOBAddMPIHPCJAHGA(builder, MPIHPCJAHGA): builder.PrependUint32Slot(9, MPIHPCJAHGA, 0)
def ILOKJEKGMOBAddGBJKMHDILHH(builder, GBJKMHDILHH): builder.PrependInt32Slot(10, GBJKMHDILHH, 0)
def ILOKJEKGMOBEnd(builder): return builder.EndObject()