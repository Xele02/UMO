
using System;
using System.Runtime.InteropServices;
using XeApp.Game.Menu;

namespace smartar
{
    public class FileStreamIn : StreamIn, IDisposable
    {
        // RVA: 0x20C0700 Offset: 0x20C0700 VA: 0x20C0700
        public FileStreamIn(Smart smart, string filePath)
        {
            self_ = sarSmartar_SarFileStreamIn_SarFileStreamIn(smart.self_, filePath);
        }

        // RVA: 0x20C0858 Offset: 0x20C0858 VA: 0x20C0858 Slot: 1
        ~FileStreamIn()
        {
            Dispose();
        }

        // RVA: 0x20C08BC Offset: 0x20C08BC VA: 0x20C08BC Slot: 6
        public void Dispose()
        {
            if(self_ != IntPtr.Zero)
            {
                sarSmartar_SarFileStreamIn_sarDelete(self_);
                self_ = IntPtr.Zero;
            }
        }

        // // RVA: 0x20C0A18 Offset: 0x20C0A18 VA: 0x20C0A18 Slot: 4
        // public override uint Read(byte[] buf, uint size) { }

        // RVA: 0x20C0B1C Offset: 0x20C0B1C VA: 0x20C0B1C Slot: 5
        public override void Close()
        {
            Dispose();
        }

        // // RVA: 0x20C0740 Offset: 0x20C0740 VA: 0x20C0740
#if UNITY_EDITOR
        private static IntPtr sarSmartar_SarFileStreamIn_SarFileStreamIn(IntPtr smart, string filePath)
        {
            return IntPtr.Zero;
        }
#else
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarFileStreamIn_SarFileStreamIn(IntPtr smart, string filePath);
#endif

        // // RVA: 0x20C0A20 Offset: 0x20C0A20 VA: 0x20C0A20
        // private static extern uint sarSmartar_SarFileStreamIn_sarRead(IntPtr self, byte[] buf, uint size) { }

        // // RVA: 0x20C0930 Offset: 0x20C0930 VA: 0x20C0930
#if UNITY_EDITOR
        private static void sarSmartar_SarFileStreamIn_sarDelete(IntPtr self)
        {
        }
#else
        [DllImport("smartar")]
        private static extern void sarSmartar_SarFileStreamIn_sarDelete(IntPtr self);
#endif
    }
}