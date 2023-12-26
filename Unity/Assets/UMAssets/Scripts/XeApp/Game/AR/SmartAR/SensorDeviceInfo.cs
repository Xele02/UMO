
using System;
using System.Runtime.InteropServices;

namespace smartar
{
    public class SensorDeviceInfo : IDisposable
    {
        public IntPtr self_; // 0x8

        // RVA: 0x2B49394 Offset: 0x2B49394 VA: 0x2B49394
        public SensorDeviceInfo()
        {
            self_ = sarSmartar_SarSensorDeviceInfo_SarSensorDeviceInfo();
        }

        // RVA: 0x2B494A4 Offset: 0x2B494A4 VA: 0x2B494A4 Slot: 1
        ~SensorDeviceInfo()
        {
            Dispose();
        }

        // RVA: 0x2B49508 Offset: 0x2B49508 VA: 0x2B49508 Slot: 4
        public void Dispose()
        {
            if(self_ != IntPtr.Zero)
            {
                sarSmartar_SarSensorDeviceInfo_sarDelete(self_);
                self_ = IntPtr.Zero;
            }
        }

        // // RVA: 0x2B493B8 Offset: 0x2B493B8 VA: 0x2B493B8
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarSensorDeviceInfo_SarSensorDeviceInfo();

        // // RVA: 0x2B49580 Offset: 0x2B49580 VA: 0x2B49580
        [DllImport("smartar")]
        private static extern void sarSmartar_SarSensorDeviceInfo_sarDelete(IntPtr self);
    }
}