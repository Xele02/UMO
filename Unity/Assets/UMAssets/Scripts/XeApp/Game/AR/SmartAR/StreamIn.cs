
using System;

namespace smartar
{
    public abstract class StreamIn
    {
        public IntPtr self_; // 0x8

        // // RVA: -1 Offset: -1 Slot: 4
        // public abstract uint Read(byte[] buf, uint size);

        // RVA: -1 Offset: -1 Slot: 5
        public abstract void Close();
    }
}