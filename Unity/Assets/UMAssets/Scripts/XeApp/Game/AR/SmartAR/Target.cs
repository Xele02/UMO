
using System;

namespace smartar
{
    public abstract class Target
    {
        public IntPtr self_; // 0x8

        // RVA: -1 Offset: -1 Slot: 4
        public abstract int GetPhysicalSize(out smartar.Vector2 size);
    }
}