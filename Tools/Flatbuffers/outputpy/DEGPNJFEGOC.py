# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class DEGPNJFEGOC(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsDEGPNJFEGOC(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = DEGPNJFEGOC()
        x.Init(buf, n + offset)
        return x

    # DEGPNJFEGOC
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # DEGPNJFEGOC
    def BBPHAPFBFHK(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # DEGPNJFEGOC
    def ODBPKGJPLMD(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

    # DEGPNJFEGOC
    def KJFEBMBHKOC(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(8))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Uint32Flags, o + self._tab.Pos)
        return 0

def DEGPNJFEGOCStart(builder): builder.StartObject(3)
def DEGPNJFEGOCAddBBPHAPFBFHK(builder, BBPHAPFBFHK): builder.PrependUint32Slot(0, BBPHAPFBFHK, 0)
def DEGPNJFEGOCAddODBPKGJPLMD(builder, ODBPKGJPLMD): builder.PrependUint32Slot(1, ODBPKGJPLMD, 0)
def DEGPNJFEGOCAddKJFEBMBHKOC(builder, KJFEBMBHKOC): builder.PrependUint32Slot(2, KJFEBMBHKOC, 0)
def DEGPNJFEGOCEnd(builder): return builder.EndObject()
