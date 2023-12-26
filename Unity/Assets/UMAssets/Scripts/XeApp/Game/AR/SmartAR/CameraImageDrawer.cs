
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace smartar
{
    public class CameraImageDrawer : IDisposable
    {
        private enum RenderEventID
        {
            Start = 1001,
            Draw = 1002,
            Draw2 = 1003,
        }

        public IntPtr self_; // 0x8

        // RVA: 0x20BF34C Offset: 0x20BF34C VA: 0x20BF34C
        public CameraImageDrawer(Smart smart)
        {
            self_ = sarSmartar_SarCameraImageDrawer_SarCameraImageDrawer(smart.self_);
        }

        // RVA: 0x20BF480 Offset: 0x20BF480 VA: 0x20BF480 Slot: 1
        ~CameraImageDrawer() 
        {
            Dispose();
        }

        // RVA: 0x20BF4E4 Offset: 0x20BF4E4 VA: 0x20BF4E4 Slot: 4
        public void Dispose()
        {
            if(self_ != IntPtr.Zero)
            {
                sarSmartar_SarCameraImageDrawer_sarDelete(self_);
                self_ = IntPtr.Zero;
            }
        }

        // // RVA: 0x20BF644 Offset: 0x20BF644 VA: 0x20BF644
        // public int SetDrawRange(float x1, float y1, float x2, float y2) { }

        // // RVA: 0x20BF778 Offset: 0x20BF778 VA: 0x20BF778
        // public int SetRotation(Rotation rotation) { }

        // // RVA: 0x20BF878 Offset: 0x20BF878 VA: 0x20BF878
        public int SetFlipX(bool flipX)
        {
            return sarSmartar_SarCameraImageDrawer_sarSetFlipX(self_, flipX);
        }

        // // RVA: 0x20BF974 Offset: 0x20BF974 VA: 0x20BF974
        public int SetFlipY(bool flipY)
        {
            return sarSmartar_SarCameraImageDrawer_sarSetFlipY(self_, flipY);
        }

        // // RVA: 0x20BFA74 Offset: 0x20BFA74 VA: 0x20BFA74
        public int Start()
        {
            GL.IssuePluginEvent(GetRenderEventFunc(), 1001);
            GL.InvalidateState();
            return 0;
        }

        // RVA: 0x20BFB5C Offset: 0x20BFB5C VA: 0x20BFB5C
        public int Stop()
        {
            return sarSmartar_SarCameraImageDrawer_sarStop(self_);
        }

        // // RVA: 0x20BFC50 Offset: 0x20BFC50 VA: 0x20BFC50
        // public int Draw(Image image) { }

        // // RVA: 0x20BFD90 Offset: 0x20BFD90 VA: 0x20BFD90
        // public int Draw(Image image, Rect rect) { }

        // // RVA: 0x20BF388 Offset: 0x20BF388 VA: 0x20BF388
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarCameraImageDrawer_SarCameraImageDrawer(IntPtr smart);

        // // RVA: 0x20BF558 Offset: 0x20BF558 VA: 0x20BF558
        [DllImport("smartar")]
        private static extern void sarSmartar_SarCameraImageDrawer_sarDelete(IntPtr self);

        // // RVA: 0x20BF668 Offset: 0x20BF668 VA: 0x20BF668
        // private static extern int sarSmartar_SarCameraImageDrawer_sarSetDrawRange(IntPtr self, float x1, float y1, float x2, float y2) { }

        // // RVA: 0x20BF780 Offset: 0x20BF780 VA: 0x20BF780
        // private static extern int sarSmartar_SarCameraImageDrawer_sarSetRotation(IntPtr self, Rotation rotation) { }

        // // RVA: 0x20BF880 Offset: 0x20BF880 VA: 0x20BF880
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraImageDrawer_sarSetFlipX(IntPtr self, bool flipX);

        // // RVA: 0x20BF980 Offset: 0x20BF980 VA: 0x20BF980
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraImageDrawer_sarSetFlipY(IntPtr self, bool flipY);

        // // RVA: 0x20BFEF0 Offset: 0x20BFEF0 VA: 0x20BFEF0
        // private static extern int sarSmartar_SarCameraImageDrawer_sarStart(IntPtr self) { }

        // // RVA: 0x20BFB68 Offset: 0x20BFB68 VA: 0x20BFB68
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraImageDrawer_sarStop(IntPtr self);

        // // RVA: 0x20BFFE0 Offset: 0x20BFFE0 VA: 0x20BFFE0
        // private static extern int sarSmartar_SarCameraImageDrawer_sarDraw(IntPtr self, IntPtr image) { }

        // // RVA: 0x20C00D0 Offset: 0x20C00D0 VA: 0x20C00D0
        // private static extern int sarSmartar_SarCameraImageDrawer_sarDraw2(IntPtr self, IntPtr image, ref Rect rect) { }

        // // RVA: 0x20BFAA0 Offset: 0x20BFAA0 VA: 0x20BFAA0
        [DllImport("smartar")]
        private static extern IntPtr GetRenderEventFunc();

        // // RVA: 0x20BFCA0 Offset: 0x20BFCA0 VA: 0x20BFCA0
        // private static extern int sarSmartar_SarCameraImageDrawer_sarSetDrawData(ref Image image) { }

        // // RVA: 0x20BFDF8 Offset: 0x20BFDF8 VA: 0x20BFDF8
        // private static extern int sarSmartar_SarCameraImageDrawer_sarSetDrawData2(ref Image image, ref Rect rect) { }
    }
}