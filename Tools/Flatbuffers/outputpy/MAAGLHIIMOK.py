# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class MAAGLHIIMOK(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsMAAGLHIIMOK(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = MAAGLHIIMOK()
        x.Init(buf, n + offset)
        return x

    # MAAGLHIIMOK
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # MAAGLHIIMOK
    def AGOIMGHMGOH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

    # MAAGLHIIMOK
    def KJFEBMBHKOC(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def MAAGLHIIMOKStart(builder): builder.StartObject(2)
def MAAGLHIIMOKAddAGOIMGHMGOH(builder, AGOIMGHMGOH): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(AGOIMGHMGOH), 0)
def MAAGLHIIMOKAddKJFEBMBHKOC(builder, KJFEBMBHKOC): builder.PrependInt32Slot(1, KJFEBMBHKOC, 0)
def MAAGLHIIMOKEnd(builder): return builder.EndObject()
