# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class PMEKDNKBNBI(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsPMEKDNKBNBI(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = PMEKDNKBNBI()
        x.Init(buf, n + offset)
        return x

    # PMEKDNKBNBI
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # PMEKDNKBNBI
    def APMIOOKCLFI(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # PMEKDNKBNBI
    def EINIBCEFPPL(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

    # PMEKDNKBNBI
    def CFLMCGOJJJD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def PMEKDNKBNBIStart(builder): builder.StartObject(3)
def PMEKDNKBNBIAddAPMIOOKCLFI(builder, APMIOOKCLFI): builder.PrependInt32Slot(0, APMIOOKCLFI, 0)
def PMEKDNKBNBIAddEINIBCEFPPL(builder, EINIBCEFPPL): builder.PrependInt32Slot(1, EINIBCEFPPL, 0)
def PMEKDNKBNBIAddCFLMCGOJJJD(builder, CFLMCGOJJJD): builder.PrependInt32Slot(2, CFLMCGOJJJD, 0)
def PMEKDNKBNBIEnd(builder): return builder.EndObject()
