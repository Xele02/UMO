
using System;
using System.Runtime.InteropServices;

namespace smartar
{
    public class CameraDeviceInfo : IDisposable
    {
        public IntPtr self_; // 0x8

        // RVA: 0x20BF074 Offset: 0x20BF074 VA: 0x20BF074
        public CameraDeviceInfo()
        {
            self_ = sarSmartar_SarCameraDeviceInfo_SarCameraDeviceInfo();
        }

        // RVA: 0x20BF184 Offset: 0x20BF184 VA: 0x20BF184 Slot: 1
        ~CameraDeviceInfo()
        {
            Dispose();
        }

        // RVA: g0x20BF1E8 Offset: 0x20BF1E8 VA: 0x20BF1E8 Slot: 4
        public void Dispose()
        {
            if(self_ != IntPtr.Zero)
            {
                sarSmartar_SarCameraDeviceInfo_sarDelete(self_);
                self_ = IntPtr.Zero;
            }
        }

        // RVA: 0x20BF098 Offset: 0x20BF098 VA: 0x20BF098
#if UNITY_EDITOR
        private static IntPtr sarSmartar_SarCameraDeviceInfo_SarCameraDeviceInfo()
        {
            return IntPtr.Zero;
        }
#else
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarCameraDeviceInfo_SarCameraDeviceInfo();
#endif

        // RVA: 0x20BF260 Offset: 0x20BF260 VA: 0x20BF260
#if UNITY_EDITOR
        private static void sarSmartar_SarCameraDeviceInfo_sarDelete(IntPtr self)
        {
        }
#else
        [DllImport("smartar")]
        private static extern void sarSmartar_SarCameraDeviceInfo_sarDelete(IntPtr self);
#endif
    }
}