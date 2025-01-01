
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace smartar
{
    public class LandmarkDrawer : IDisposable
    {
        private enum RenderEventID
        {
            Start = 2001,
        }

        public IntPtr self_; // 0x8

        // RVA: 0x20C11F8 Offset: 0x20C11F8 VA: 0x20C11F8
        public LandmarkDrawer(Smart smart)
        {
            self_ = sarSmartar_SarLandmarkDrawer_SarLandmarkDrawer(smart.self_);
        }

        // RVA: 0x20C1320 Offset: 0x20C1320 VA: 0x20C1320 Slot: 1
        ~LandmarkDrawer()
        {
            Dispose();
        }

        // RVA: 0x20C1384 Offset: 0x20C1384 VA: 0x20C1384 Slot: 4
        public void Dispose()
        {
            if(self_ != IntPtr.Zero)
            {
                sarSmartar_SarLandmarkDrawer_sarDelete(self_);
                self_ = IntPtr.Zero;
            }
        }

        // // RVA: 0x20C14E0 Offset: 0x20C14E0 VA: 0x20C14E0
        public int Start()
        {
#if !UNITY_EDITOR
            GL.IssuePluginEvent(GetRenderEventFunc(), 2001);
#endif
            GL.InvalidateState();
            return 0;
        }

        // // RVA: 0x20C15C4 Offset: 0x20C15C4 VA: 0x20C15C4
        public int Stop()
        {
            return sarSmartar_SarLandmarkDrawer_sarStop(self_);
        }

        // // RVA: 0x20C1230 Offset: 0x20C1230 VA: 0x20C1230
#if UNITY_EDITOR
        private IntPtr sarSmartar_SarLandmarkDrawer_SarLandmarkDrawer(IntPtr smart)
        {
            return IntPtr.Zero;
        }
#else
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarLandmarkDrawer_SarLandmarkDrawer(IntPtr smart);
#endif

        // // RVA: 0x20C13F8 Offset: 0x20C13F8 VA: 0x20C13F8
#if UNITY_EDITOR
        private void sarSmartar_SarLandmarkDrawer_sarDelete(IntPtr self)
        {
        }
#else
        [DllImport("smartar")]
        private static extern void sarSmartar_SarLandmarkDrawer_sarDelete(IntPtr self);
#endif

        // // RVA: 0x20C16B8 Offset: 0x20C16B8 VA: 0x20C16B8
        // private static extern int sarSmartar_SarLandmarkDrawer_sarStart(IntPtr self) { }

        // // RVA: 0x20C15D0 Offset: 0x20C15D0 VA: 0x20C15D0
#if UNITY_EDITOR
        private int sarSmartar_SarLandmarkDrawer_sarStop(IntPtr self)
        {
            return 0;
        }
#else
        [DllImport("smartar")]
        private static extern int sarSmartar_SarLandmarkDrawer_sarStop(IntPtr self);
#endif

        // // RVA: 0x20C17A0 Offset: 0x20C17A0 VA: 0x20C17A0
        // private static extern int sarSmartar_SarLandmarkDrawer_sarDrawLandmarks(IntPtr self, ref Matrix44 pmvMatrix, IntPtr landmarks, int numLandmarks) { }

        // // RVA: 0x20C18A8 Offset: 0x20C18A8 VA: 0x20C18A8
        // private static extern int sarSmartar_SarLandmarkDrawer_sarDrawNodePoints(IntPtr self, ref Matrix44 pmvMatrix, IntPtr nodePoints, int numNodePoints) { }

        // // RVA: 0x20C19B0 Offset: 0x20C19B0 VA: 0x20C19B0
        // private static extern int sarSmartar_SarLandmarkDrawer_sarDrawInitPoints(IntPtr self, ref Matrix44 imageMatrix, IntPtr initPoints, int numInitPoints) { }

        // // RVA: 0x20C1508 Offset: 0x20C1508 VA: 0x20C1508
#if UNITY_EDITOR
        private IntPtr GetRenderEventFunc()
        {
            return IntPtr.Zero;
        }
#else
        [DllImport("smartar")]
        private static extern IntPtr GetRenderEventFunc();
#endif
    }
}