# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class HACLELJLADO(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsHACLELJLADO(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = HACLELJLADO()
        x.Init(buf, n + offset)
        return x

    # HACLELJLADO
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # HACLELJLADO
    def DECLAPPHHLJ(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .DGBGJKKIACN import DGBGJKKIACN
            obj = DGBGJKKIACN()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # HACLELJLADO
    def DECLAPPHHLJLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # HACLELJLADO
    def CMMCFMNDNAG(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .BKIKCJIAIIO import BKIKCJIAIIO
            obj = BKIKCJIAIIO()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # HACLELJLADO
    def CMMCFMNDNAGLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # HACLELJLADO
    def NIIBHCNIBKJ(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .OJJCFKMBCCG import OJJCFKMBCCG
            obj = OJJCFKMBCCG()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # HACLELJLADO
    def NIIBHCNIBKJLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # HACLELJLADO
    def HKEKGDIIMHO(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .EEJBHCCHCGC import EEJBHCCHCGC
            obj = EEJBHCCHCGC()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # HACLELJLADO
    def HKEKGDIIMHOLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # HACLELJLADO
    def NJJINHMIOHN(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .HAPBICPAMDF import HAPBICPAMDF
            obj = HAPBICPAMDF()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # HACLELJLADO
    def NJJINHMIOHNLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # HACLELJLADO
    def NPFBHGKLIOM(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .MINCDLJOALM import MINCDLJOALM
            obj = MINCDLJOALM()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # HACLELJLADO
    def NPFBHGKLIOMLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(14))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def HACLELJLADOStart(builder): builder.StartObject(6)
def HACLELJLADOAddDECLAPPHHLJ(builder, DECLAPPHHLJ): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(DECLAPPHHLJ), 0)
def HACLELJLADOStartDECLAPPHHLJVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HACLELJLADOAddCMMCFMNDNAG(builder, CMMCFMNDNAG): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(CMMCFMNDNAG), 0)
def HACLELJLADOStartCMMCFMNDNAGVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HACLELJLADOAddNIIBHCNIBKJ(builder, NIIBHCNIBKJ): builder.PrependUOffsetTRelativeSlot(2, flatbuffers.number_types.UOffsetTFlags.py_type(NIIBHCNIBKJ), 0)
def HACLELJLADOStartNIIBHCNIBKJVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HACLELJLADOAddHKEKGDIIMHO(builder, HKEKGDIIMHO): builder.PrependUOffsetTRelativeSlot(3, flatbuffers.number_types.UOffsetTFlags.py_type(HKEKGDIIMHO), 0)
def HACLELJLADOStartHKEKGDIIMHOVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HACLELJLADOAddNJJINHMIOHN(builder, NJJINHMIOHN): builder.PrependUOffsetTRelativeSlot(4, flatbuffers.number_types.UOffsetTFlags.py_type(NJJINHMIOHN), 0)
def HACLELJLADOStartNJJINHMIOHNVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HACLELJLADOAddNPFBHGKLIOM(builder, NPFBHGKLIOM): builder.PrependUOffsetTRelativeSlot(5, flatbuffers.number_types.UOffsetTFlags.py_type(NPFBHGKLIOM), 0)
def HACLELJLADOStartNPFBHGKLIOMVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def HACLELJLADOEnd(builder): return builder.EndObject()
