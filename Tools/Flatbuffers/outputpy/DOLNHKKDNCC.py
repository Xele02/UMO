# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class DOLNHKKDNCC(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsDOLNHKKDNCC(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = DOLNHKKDNCC()
        x.Init(buf, n + offset)
        return x

    # DOLNHKKDNCC
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # DOLNHKKDNCC
    def FPOHCPNHGMN(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .KKJKDONIHBM import KKJKDONIHBM
            obj = KKJKDONIHBM()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # DOLNHKKDNCC
    def FPOHCPNHGMNLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def DOLNHKKDNCCStart(builder): builder.StartObject(1)
def DOLNHKKDNCCAddFPOHCPNHGMN(builder, FPOHCPNHGMN): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(FPOHCPNHGMN), 0)
def DOLNHKKDNCCStartFPOHCPNHGMNVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def DOLNHKKDNCCEnd(builder): return builder.EndObject()