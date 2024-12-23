
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace smartar
{
    public class LearnedImageTarget : Target, IDisposable
    {
        // RVA: 0x20C1AB8 Offset: 0x20C1AB8 VA: 0x20C1AB8
        public LearnedImageTarget(Smart smart, StreamIn stream, string customerID, string customerKey)
        {
            self_ = sarSmartar_SarLearnedImageTarget_SarLearnedImageTarget(smart.self_, stream.self_, customerID, customerKey);
        }

        // RVA: 0x20C1C74 Offset: 0x20C1C74 VA: 0x20C1C74 Slot: 1
        ~LearnedImageTarget()
        {
            Dispose();
        }

        // // RVA: 0x20C1D4C Offset: 0x20C1D4C VA: 0x20C1D4C
        // public int getConstructorError() { }

        // RVA: 0x20C1CD8 Offset: 0x20C1CD8 VA: 0x20C1CD8 Slot: 5
        public void Dispose()
        {
            if(self_ != IntPtr.Zero)
            {
                sarSmartar_SarLearnedImageTarget_sarDelete(self_);
                self_ = IntPtr.Zero;
            }
        }

        // // RVA: 0x20C1F3C Offset: 0x20C1F3C VA: 0x20C1F3C Slot: 4
        public override int GetPhysicalSize(out smartar.Vector2 size)
        {
            return sarSmartar_SarLearnedImageTarget_sarGetPhysicalSize(self_, out size);
        }

        // // RVA: 0x20C1B28 Offset: 0x20C1B28 VA: 0x20C1B28
#if UNITY_EDITOR
        private static IntPtr sarSmartar_SarLearnedImageTarget_SarLearnedImageTarget(IntPtr smart, IntPtr stream, string customerID, string customerKey)
        {
            return IntPtr.Zero;
        }
#else
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarLearnedImageTarget_SarLearnedImageTarget(IntPtr smart, IntPtr stream, string customerID, string customerKey);
#endif

        // // RVA: 0x20C1E50 Offset: 0x20C1E50 VA: 0x20C1E50
#if UNITY_EDITOR
        private static void sarSmartar_SarLearnedImageTarget_sarDelete(IntPtr self)
        {
        }
#else
        [DllImport("smartar")]
        private static extern void sarSmartar_SarLearnedImageTarget_sarDelete(IntPtr self);
#endif

        // // RVA: 0x20C1D58 Offset: 0x20C1D58 VA: 0x20C1D58
        // private static extern int sarSmartar_SarLearnedImageTarget_sarGetConstructorError(IntPtr self) { }

        // // RVA: 0x20C1F48 Offset: 0x20C1F48 VA: 0x20C1F48
#if UNITY_EDITOR
        private static int sarSmartar_SarLearnedImageTarget_sarGetPhysicalSize(IntPtr self, out smartar.Vector2 size)
        {
            size = new smartar.Vector2();
            size.x_ = 1;
            size.y_ = 1;
            return 0;
        }
#else
        [DllImport("smartar")]
        private static extern int sarSmartar_SarLearnedImageTarget_sarGetPhysicalSize(IntPtr self, out smartar.Vector2 size);
#endif
    }
}