# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class PAEHJMNAOKB(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsPAEHJMNAOKB(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = PAEHJMNAOKB()
        x.Init(buf, n + offset)
        return x

    # PAEHJMNAOKB
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # PAEHJMNAOKB
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # PAEHJMNAOKB
    def IALIGIAJJGP(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # PAEHJMNAOKB
    def FKGLOPMFMCP(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # PAEHJMNAOKB
    def LAONNJLHPCF(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # PAEHJMNAOKB
    def BNDAHALMIPE(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def PAEHJMNAOKBStart(builder): builder.StartObject(5)
def PAEHJMNAOKBAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependInt32Slot(0, BBPHAPFBFHK, 0)
def PAEHJMNAOKBAddIALIGIAJJGP(builder, IALIGIAJJGP): builder.PrependInt32Slot(1, IALIGIAJJGP, 0)
def PAEHJMNAOKBAddFKGLOPMFMCP(builder, FKGLOPMFMCP): builder.PrependInt32Slot(2, FKGLOPMFMCP, 0)
def PAEHJMNAOKBAddLAONNJLHPCF(builder, LAONNJLHPCF): builder.PrependInt32Slot(3, LAONNJLHPCF, 0)
def PAEHJMNAOKBAddBNDAHALMIPE(builder, BNDAHALMIPE): builder.PrependInt32Slot(4, BNDAHALMIPE, 0)
def PAEHJMNAOKBEnd(builder): return builder.EndObject()
