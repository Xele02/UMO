# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class BANGFGHKPNP(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsBANGFGHKPNP(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = BANGFGHKPNP()
        x.Init(buf, n + offset)
        return x

    # BANGFGHKPNP
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # BANGFGHKPNP
    def AGOIMGHMGOH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

    # BANGFGHKPNP
    def KJFEBMBHKOC(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.Get(flatbuffers.number_types.Int32Flags, o + self._tab.Pos)
        return 0

def BANGFGHKPNPStart(builder): builder.StartObject(2)
def BANGFGHKPNPAddAGOIMGHMGOH(builder, AGOIMGHMGOH): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(AGOIMGHMGOH), 0)
def BANGFGHKPNPAddKJFEBMBHKOC(builder, KJFEBMBHKOC): builder.PrependInt32Slot(1, KJFEBMBHKOC, 0)
def BANGFGHKPNPEnd(builder): return builder.EndObject()