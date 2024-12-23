
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace smartar
{
    public class SceneMapTarget : Target, IDisposable
    {
        // RVA: 0x2B4745C Offset: 0x2B4745C VA: 0x2B4745C
        public SceneMapTarget(Smart smart, StreamIn stream)
        {
            self_ = sarSmartar_SarSceneMapTarget_SarSceneMapTarget(smart.self_, stream.self_);
        }

        // RVA: 0x2B475B0 Offset: 0x2B475B0 VA: 0x2B475B0 Slot: 1
        ~SceneMapTarget()
        {
            Dispose();
        }

        // RVA: 0x2B47614 Offset: 0x2B47614 VA: 0x2B47614 Slot: 5
        public void Dispose()
        {
            if(self_ != IntPtr.Zero)
            {
                sarSmartar_SarSceneMapTarget_sarDelete(self_);
                self_ = IntPtr.Zero;
            }
        }

        // // RVA: 0x2B47770 Offset: 0x2B47770 VA: 0x2B47770 Slot: 4
        public override int GetPhysicalSize(out smartar.Vector2 size)
        {
            return sarSmartar_SarSceneMapTarget_sarGetPhysicalSize(self_, out size);
        }

        // // RVA: 0x2B474B8 Offset: 0x2B474B8 VA: 0x2B474B8
#if UNITY_EDITOR
        private static IntPtr sarSmartar_SarSceneMapTarget_SarSceneMapTarget(IntPtr smart, IntPtr stream)
        {
            return IntPtr.Zero;
        }
#else
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarSceneMapTarget_SarSceneMapTarget(IntPtr smart, IntPtr stream);
#endif

        // // RVA: 0x2B47688 Offset: 0x2B47688 VA: 0x2B47688
#if UNITY_EDITOR
        private static void sarSmartar_SarSceneMapTarget_sarDelete(IntPtr self)
        {
        }
#else
        [DllImport("smartar")]
        private static extern void sarSmartar_SarSceneMapTarget_sarDelete(IntPtr self);
#endif

        // // RVA: 0x2B47778 Offset: 0x2B47778 VA: 0x2B47778
#if UNITY_EDITOR
        private static int sarSmartar_SarSceneMapTarget_sarGetPhysicalSize(IntPtr self, out smartar.Vector2 size)
        {
            size = new Vector2();
            size.x_ = 1;
            size.y_ = 1;
            return 0;
        }
#else
        [DllImport("smartar")]
        private static extern int sarSmartar_SarSceneMapTarget_sarGetPhysicalSize(IntPtr self, out smartar.Vector2 size);
#endif
    }
}