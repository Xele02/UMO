# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class EDNGOONFHEO(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsEDNGOONFHEO(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = EDNGOONFHEO()
        x.Init(buf, n + offset)
        return x

    # EDNGOONFHEO
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # EDNGOONFHEO
    def OPBPOOKODJK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            x = self._tab.Indirect(o + self._tab.Pos)
            from .CLPHCGNHCGC import CLPHCGNHCGC
            obj = CLPHCGNHCGC()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # EDNGOONFHEO
    def NJJINHMIOHN(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .MBMMPMLDACB import MBMMPMLDACB
            obj = MBMMPMLDACB()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # EDNGOONFHEO
    def NJJINHMIOHNLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # EDNGOONFHEO
    def NPFBHGKLIOM(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .CLLJHAIJMHD import CLLJHAIJMHD
            obj = CLLJHAIJMHD()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # EDNGOONFHEO
    def NPFBHGKLIOMLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # EDNGOONFHEO
    def HHBHEKNMBHF(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .IONNGNNIKOG import IONNGNNIKOG
            obj = IONNGNNIKOG()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # EDNGOONFHEO
    def HHBHEKNMBHFLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(10))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

    # EDNGOONFHEO
    def AAAINBAEOFD(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .PAEHJMNAOKB import PAEHJMNAOKB
            obj = PAEHJMNAOKB()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # EDNGOONFHEO
    def AAAINBAEOFDLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(12))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def EDNGOONFHEOStart(builder): builder.StartObject(5)
def EDNGOONFHEOAddOPBPOOKODJK(builder, OPBPOOKODJK): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(OPBPOOKODJK), 0)
def EDNGOONFHEOAddNJJINHMIOHN(builder, NJJINHMIOHN): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(NJJINHMIOHN), 0)
def EDNGOONFHEOStartNJJINHMIOHNVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def EDNGOONFHEOAddNPFBHGKLIOM(builder, NPFBHGKLIOM): builder.PrependUOffsetTRelativeSlot(2, flatbuffers.number_types.UOffsetTFlags.py_type(NPFBHGKLIOM), 0)
def EDNGOONFHEOStartNPFBHGKLIOMVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def EDNGOONFHEOAddHHBHEKNMBHF(builder, HHBHEKNMBHF): builder.PrependUOffsetTRelativeSlot(3, flatbuffers.number_types.UOffsetTFlags.py_type(HHBHEKNMBHF), 0)
def EDNGOONFHEOStartHHBHEKNMBHFVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def EDNGOONFHEOAddAAAINBAEOFD(builder, AAAINBAEOFD): builder.PrependUOffsetTRelativeSlot(4, flatbuffers.number_types.UOffsetTFlags.py_type(AAAINBAEOFD), 0)
def EDNGOONFHEOStartAAAINBAEOFDVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def EDNGOONFHEOEnd(builder): return builder.EndObject()
