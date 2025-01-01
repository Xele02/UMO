
using System;

namespace smartar
{
    public class SensorState
    {
        public IntPtr self_; // 0x8

        // RVA: 0x2B48024 Offset: 0x2B48024 VA: 0x2B48024
        public SensorState(IntPtr self)
        {
            self_ = self;
        }

        // RVA: 0x2B4966C Offset: 0x2B4966C VA: 0x2B4966C Slot: 1
        ~SensorState()
        {
            self_ = IntPtr.Zero;
        }

        // // RVA: 0x2B49710 Offset: 0x2B49710 VA: 0x2B49710
        // public void Release() { }

        // // RVA: 0x2B49764 Offset: 0x2B49764 VA: 0x2B49764
        // public void getData(byte[] buffer, int offset) { }

        // // RVA: 0x2B49814 Offset: 0x2B49814 VA: 0x2B49814
        // public static int getDataSize() { }

        // // RVA: 0x2B49818 Offset: 0x2B49818 VA: 0x2B49818
        // private static extern int sarSmartar_SarSensorState_sarGetDataSize() { }
    }
}