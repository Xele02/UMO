
using System;
using System.Runtime.InteropServices;

namespace smartar
{
    public class ScreenDevice : IDisposable
    {
        public IntPtr self_; // 0x8

        // RVA: 0x2B47870 Offset: 0x2B47870 VA: 0x2B47870
        public ScreenDevice(Smart smart) 
        {
            self_ = sarSmartar_SarScreenDevice_SarScreenDevice(smart.self_);
        }

        // RVA: 0x2B47994 Offset: 0x2B47994 VA: 0x2B47994 Slot: 1
        ~ScreenDevice()
        {
            Dispose();
        }

        // RVA: 0x2B479F8 Offset: 0x2B479F8 VA: 0x2B479F8 Slot: 4
        public void Dispose()
        {
            if(self_ != IntPtr.Zero)
            {
                sarSmartar_SarScreenDevice_sarDelete(self_);
                self_ = IntPtr.Zero;
            }
        }

        // // RVA: 0x2B47B58 Offset: 0x2B47B58 VA: 0x2B47B58
        public int GetRotation(out Rotation rotation)
        {
            return sarSmartar_SarScreenDevice_sarGetRotation(self_, out rotation);
        }

        // // RVA: 0x2B478A8 Offset: 0x2B478A8 VA: 0x2B478A8
#if UNITY_EDITOR
        private static IntPtr sarSmartar_SarScreenDevice_SarScreenDevice(IntPtr self)
        {
            return IntPtr.Zero;
        }
#else
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarScreenDevice_SarScreenDevice(IntPtr self);
#endif

        // // RVA: 0x2B47A70 Offset: 0x2B47A70 VA: 0x2B47A70
#if UNITY_EDITOR
        private static void sarSmartar_SarScreenDevice_sarDelete(IntPtr self)
        {
        }
#else
        [DllImport("smartar")]
        private static extern void sarSmartar_SarScreenDevice_sarDelete(IntPtr self);
#endif

        // // RVA: 0x2B47B60 Offset: 0x2B47B60 VA: 0x2B47B60
#if UNITY_EDITOR
        private static int sarSmartar_SarScreenDevice_sarGetRotation(IntPtr self, out Rotation rotation)
        {
            rotation = Rotation.ROTATION_0;
            return 0;
        }
#else
        [DllImport("smartar")]
        private static extern int sarSmartar_SarScreenDevice_sarGetRotation(IntPtr self, out Rotation rotation);
#endif
    }
}