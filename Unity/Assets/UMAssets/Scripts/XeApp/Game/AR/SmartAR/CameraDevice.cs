
using System;
using System.Runtime.InteropServices;

namespace smartar
{
    public class CameraDevice : IDisposable
    {
        private delegate void CameraImageListenerDelegate(IntPtr imageHolder, ulong timestamp);
        private delegate void CameraShutterListenerDelegate();
        private delegate void CameraAutoAdjustListenerDelegate(bool success);
        private delegate void CameraErrorListenerDelegate(int error);

        private class MonoPInvokeCallbackAttribute : Attribute
        {
            protected Type type; // 0x8

            // RVA: 0x20BF054 Offset: 0x20BF054 VA: 0x20BF054
            public MonoPInvokeCallbackAttribute(Type t)
            {
                type = t;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ProxyListeners
        {
            public IntPtr videoImageListener_; // 0x0
            public IntPtr stillImageListener_; // 0x4
            public IntPtr shutterListener_; // 0x8
            public IntPtr autoFocusListener_; // 0xC
            public IntPtr autoExposureListener_; // 0x10
            public IntPtr autoWhiteBalanceListener_; // 0x14
            public IntPtr cameraErrorListener_; // 0x18
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ProxyListenerDelegates
        {
            public IntPtr videoImageListenerDelegate_; // 0x0
            public IntPtr stillImageListenerDelegate_; // 0x4
            public IntPtr shutterListenerDelegate_; // 0x8
            public IntPtr autoFocusListenerDelegate_; // 0xC
            public IntPtr autoExposureListenerDelegate_; // 0x10
            public IntPtr autoWhiteBalanceListenerDelegate_; // 0x14
            public IntPtr cameraErrorListenerDelegate_; // 0x18
        }

        public const int INVALID_CAMERA_ID = -1;
        public IntPtr self_; // 0x8
        private static CameraDevice thisObj_; // 0x0
        private CameraDevice.ProxyListenerDelegates proxyListenerDelegates_; // 0xC
        private CameraDevice.ProxyListeners proxyListeners_; // 0x28
        private CameraImageListener videoImageListener_; // 0x44
        private CameraImageListener stillImageListener_; // 0x48
        private CameraShutterListener shutterListener_; // 0x4C
        private CameraAutoAdjustListener autoFocusListener_; // 0x50
        private CameraAutoAdjustListener autoExposureListener_; // 0x54
        private CameraAutoAdjustListener autoWhiteBalanceListener_; // 0x58
        private CameraErrorListener cameraErrorListener_; // 0x5C
        private ImageHolder imageHolder_ = new ImageHolder(IntPtr.Zero); // 0x60

        // RVA: 0x20B8428 Offset: 0x20B8428 VA: 0x20B8428
        public CameraDevice(Smart smart, bool forceOldAndroidAPI = false) { }

        // RVA: 0x20B88B4 Offset: 0x20B88B4 VA: 0x20B88B4
        public CameraDevice(Smart smart, int cameraId, bool forceOldAndroidAPI = false) { }

        // RVA: 0x20B892C Offset: 0x20B892C VA: 0x20B892C
        public CameraDevice(Smart smart, int cameraId, IntPtr nativeDevice, bool forceOldAndroidAPI = false) { }

        // RVA: 0x20B84D4 Offset: 0x20B84D4 VA: 0x20B84D4
        private CameraDevice()
        {
            thisObj_ = this;
            proxyListenerDelegates_.videoImageListenerDelegate_ = Marshal.GetFunctionPointerForDelegate(new CameraImageListenerDelegate(OnVideoImage));
            proxyListenerDelegates_.stillImageListenerDelegate_ = Marshal.GetFunctionPointerForDelegate(new CameraImageListenerDelegate(OnStillImage));
            proxyListenerDelegates_.shutterListenerDelegate_ = Marshal.GetFunctionPointerForDelegate(new CameraShutterListenerDelegate(OnShutter));
            proxyListenerDelegates_.autoFocusListenerDelegate_ = Marshal.GetFunctionPointerForDelegate(new CameraAutoAdjustListenerDelegate(OnAutoFocus));
            proxyListenerDelegates_.autoExposureListenerDelegate_ = Marshal.GetFunctionPointerForDelegate(new CameraAutoAdjustListenerDelegate(OnAutoExposure));
            proxyListenerDelegates_.autoWhiteBalanceListenerDelegate_ = Marshal.GetFunctionPointerForDelegate(new CameraAutoAdjustListenerDelegate(OnAutoWhiteBalance));
            proxyListenerDelegates_.cameraErrorListenerDelegate_ = Marshal.GetFunctionPointerForDelegate(new CameraErrorListenerDelegate(OnError));
            sarSmartar_SarCameraDeviceProxyListeners_sarCreate(ref proxyListenerDelegates_, out proxyListeners_);            
        }

        // RVA: 0x20B8C64 Offset: 0x20B8C64 VA: 0x20B8C64 Slot: 1
        ~CameraDevice()
        {
            Dispose();
        }

        // RVA: 0x20B8CC8 Offset: 0x20B8CC8 VA: 0x20B8CC8 Slot: 4
        public void Dispose()
        {
            if(self_ == IntPtr.Zero)
                return;
            sarSmartar_SarCameraDevice_sarDelete(self_);
            self_ = IntPtr.Zero;
            sarSmartar_SarCameraDeviceProxyListeners_sarDelete(ref proxyListeners_);
            thisObj_ = null;
        }

        [MonoPInvokeCallbackAttribute(typeof(CameraImageListenerDelegate))] // RVA: 0x5E07F4 Offset: 0x5E07F4 VA: 0x5E07F4
        // // RVA: 0x20B7A38 Offset: 0x20B7A38 VA: 0x20B7A38
        private static void OnVideoImage(IntPtr imageHolder, ulong timestamp)
        {
            thisObj_.imageHolder_.self_ = imageHolder;
            thisObj_.videoImageListener_.OnImage(thisObj_.imageHolder_, timestamp);
            thisObj_.imageHolder_.self_ = IntPtr.Zero;
        }

        [MonoPInvokeCallbackAttribute(typeof(CameraImageListenerDelegate))] // RVA: 0x5E086C Offset: 0x5E086C VA: 0x5E086C
        // // RVA: 0x20B7C3C Offset: 0x20B7C3C VA: 0x20B7C3C
        private static void OnStillImage(IntPtr imageHolder, ulong timestamp) 
        {
            thisObj_.imageHolder_.self_ = imageHolder;
            thisObj_.stillImageListener_.OnImage(thisObj_.imageHolder_, timestamp);
            thisObj_.imageHolder_.self_ = IntPtr.Zero;
        }

        [MonoPInvokeCallbackAttribute(typeof(CameraShutterListenerDelegate))] // RVA: 0x5E08E4 Offset: 0x5E08E4 VA: 0x5E08E4
        // // RVA: 0x20B7E40 Offset: 0x20B7E40 VA: 0x20B7E40
        private static void OnShutter()
        {
            thisObj_.shutterListener_.OnShutter();
        }

        [MonoPInvokeCallbackAttribute(typeof(CameraAutoAdjustListenerDelegate))] // RVA: 0x5E095C Offset: 0x5E095C VA: 0x5E095C
        // // RVA: 0x20B7F68 Offset: 0x20B7F68 VA: 0x20B7F68
        private static void OnAutoFocus(bool success)
        {
            thisObj_.autoFocusListener_.OnAutoAdjust(success);
        }

        [MonoPInvokeCallbackAttribute(typeof(CameraAutoAdjustListenerDelegate))] // RVA: 0x5E09D4 Offset: 0x5E09D4 VA: 0x5E09D4
        // // RVA: 0x20B8098 Offset: 0x20B8098 VA: 0x20B8098
        private static void OnAutoExposure(bool success)
        {
            thisObj_.autoExposureListener_.OnAutoAdjust(success);
        }

        [MonoPInvokeCallbackAttribute(typeof(CameraAutoAdjustListenerDelegate))] // RVA: 0x5E0A4C Offset: 0x5E0A4C VA: 0x5E0A4C
        // // RVA: 0x20B81C8 Offset: 0x20B81C8 VA: 0x20B81C8
        private static void OnAutoWhiteBalance(bool success)
        {
            thisObj_.autoWhiteBalanceListener_.OnAutoAdjust(success);
        }

        [MonoPInvokeCallbackAttribute(typeof(CameraErrorListenerDelegate))] // RVA: 0x5E0AC4 Offset: 0x5E0AC4 VA: 0x5E0AC4
        // // RVA: 0x20B82F8 Offset: 0x20B82F8 VA: 0x20B82F8
        private static void OnError(int error)
        {
            thisObj_.cameraErrorListener_.OnError(error);
        }

        // // RVA: 0x20B8B68 Offset: 0x20B8B68 VA: 0x20B8B68
        [DllImport("smartar")]
        private static extern void sarSmartar_SarCameraDeviceProxyListeners_sarCreate(ref ProxyListenerDelegates delegates, out ProxyListeners listeners);

        // // RVA: 0x20B8E78 Offset: 0x20B8E78 VA: 0x20B8E78
        [DllImport("smartar")]
        private static extern void sarSmartar_SarCameraDeviceProxyListeners_sarDelete(ref ProxyListeners listeners);

        // // RVA: 0x20B8F6C Offset: 0x20B8F6C VA: 0x20B8F6C
        // public int SetNativeVideoOutput(IntPtr nativeVideoOutput) { }

        // // RVA: 0x20B90F4 Offset: 0x20B90F4 VA: 0x20B90F4
        // public int SetVideoImageListener(CameraImageListener listener, Smart smart) { }

        // // RVA: 0x20B92B4 Offset: 0x20B92B4 VA: 0x20B92B4
        public int SetVideoImageSize(int width, int height)
        {
            return sarSmartar_SarCameraDevice_sarSetVideoImageSize(self_, width, height);
        }

        // // RVA: 0x20B9448 Offset: 0x20B9448 VA: 0x20B9448
        // public int SetVideoImageFormat(ImageFormat format) { }

        // // RVA: 0x20B95D4 Offset: 0x20B95D4 VA: 0x20B95D4
        // public int SetVideoImageFpsRange(float min, float max) { }

        // // RVA: 0x20B976C Offset: 0x20B976C VA: 0x20B976C
        public int SetStillImageListener(CameraImageListener listener)
        {
            stillImageListener_ = listener;
            return sarSmartar_SarCameraDevice_sarSetStillImageListener(self_, listener == null ? IntPtr.Zero : proxyListeners_.stillImageListener_);
        }

        // // RVA: 0x20B9904 Offset: 0x20B9904 VA: 0x20B9904
        // public int SetStillImageSize(int width, int height) { }

        // // RVA: 0x20B9A98 Offset: 0x20B9A98 VA: 0x20B9A98
        // public int SetStillImageFormat(ImageFormat format) { }

        // // RVA: 0x20B9C24 Offset: 0x20B9C24 VA: 0x20B9C24
        // public int SetShutterListener(CameraShutterListener listener) { }

        // // RVA: 0x20B9DBC Offset: 0x20B9DBC VA: 0x20B9DBC
        public int SetFocusMode(FocusMode mode)
        {
            return sarSmartar_SarCameraDevice_sarSetFocusMode(self_, mode);
        }

        // // RVA: 0x20B9F3C Offset: 0x20B9F3C VA: 0x20B9F3C
        // public int SetFocusAreas(CameraArea[] areas) { }

        // // RVA: 0x20BA0E4 Offset: 0x20BA0E4 VA: 0x20BA0E4
        // public int SetExposureMode(ExposureMode mode) { }

        // // RVA: 0x20BA268 Offset: 0x20BA268 VA: 0x20BA268
        // public int SetExposureAreas(CameraArea[] areas) { }

        // // RVA: 0x20BA410 Offset: 0x20BA410 VA: 0x20BA410
        // public int SetFlashMode(FlashMode mode) { }

        // // RVA: 0x20BA594 Offset: 0x20BA594 VA: 0x20BA594
        // public int SetWhiteBalanceMode(WhiteBalanceMode mode) { }

        // // RVA: 0x20BA71C Offset: 0x20BA71C VA: 0x20BA71C
        // public int SetSceneMode(SceneMode mode) { }

        // // RVA: 0x20BA89C Offset: 0x20BA89C VA: 0x20BA89C
        public int SetAutoFocusListener(CameraAutoAdjustListener listener)
        {
            autoFocusListener_ = listener;
            return sarSmartar_SarCameraDevice_sarSetAutoFocusListener(self_, listener == null ? IntPtr.Zero : proxyListeners_.autoFocusListener_);
        }

        // // RVA: 0x20BAA34 Offset: 0x20BAA34 VA: 0x20BAA34
        public int SetAutoExposureListener(CameraAutoAdjustListener listener)
        {
            autoExposureListener_ = listener;
            return sarSmartar_SarCameraDevice_sarSetAutoExposureListener(self_, listener == null ? IntPtr.Zero : proxyListeners_.autoExposureListener_);
        }

        // // RVA: 0x20BABD0 Offset: 0x20BABD0 VA: 0x20BABD0
        public int SetAutoWhiteBalanceListener(CameraAutoAdjustListener listener)
        {
            autoWhiteBalanceListener_ = listener;
            return sarSmartar_SarCameraDevice_sarSetAutoWhiteBalanceListener(self_, listener == null ? IntPtr.Zero : proxyListeners_.autoWhiteBalanceListener_);
        }

        // // RVA: 0x20BAD74 Offset: 0x20BAD74 VA: 0x20BAD74
        public int SetCameraErrorListener(CameraErrorListener listener)
        {
            cameraErrorListener_ = listener;
            return sarSmartar_SarCameraDevice_sarSetCameraErrorListener(self_, listener == null ? IntPtr.Zero : proxyListeners_.cameraErrorListener_);
        }

        // // RVA: 0x20BAF10 Offset: 0x20BAF10 VA: 0x20BAF10
        // public int SetOwningNativeDevice(bool isOwning) { }

        // // RVA: 0x20BB09C Offset: 0x20BB09C VA: 0x20BB09C
        public static int GetDefaultCameraId(Smart smart, Facing facing, out int cameraId, bool forceOldAndroidAPI = false)
        {
            return sarSmartar_SarCameraDevice_sarGetDefaultCameraId(smart.self_, facing, out cameraId, forceOldAndroidAPI);
        }

        // // RVA: 0x20BB25C Offset: 0x20BB25C VA: 0x20BB25C
        // public int GetSupportedVideoImageSize(Size[] sizes) { }

        // // RVA: 0x20BB414 Offset: 0x20BB414 VA: 0x20BB414
        // public int GetSupportedVideoImageFormat(ImageFormat[] formats) { }

        // // RVA: 0x20BB5CC Offset: 0x20BB5CC VA: 0x20BB5CC
        // public int GetSupportedVideoImageFpsRange(CameraFpsRange[] ranges) { }

        // // RVA: 0x20BB788 Offset: 0x20BB788 VA: 0x20BB788
        // public int GetSupportedStillImageSize(Size[] sizes) { }

        // // RVA: 0x20BB93C Offset: 0x20BB93C VA: 0x20BB93C
        // public int GetSupportedStillImageFormat(ImageFormat[] formats) { }

        // // RVA: 0x20BBAF4 Offset: 0x20BBAF4 VA: 0x20BBAF4
        public int GetSupportedFocusMode(FocusMode[] modes)
        {
            return sarSmartar_SarCameraDevice_sarGetSupportedFocusMode(self_, modes, modes.Length);
        }

        // // RVA: 0x20BBCA4 Offset: 0x20BBCA4 VA: 0x20BBCA4
        // public int GetMaxNumFocusAreas() { }

        // // RVA: 0x20BBE1C Offset: 0x20BBE1C VA: 0x20BBE1C
        // public int GetSupportedFlashMode(FlashMode[] modes) { }

        // // RVA: 0x20BBFCC Offset: 0x20BBFCC VA: 0x20BBFCC
        // public int GetSupportedExposureMode(ExposureMode[] modes) { }

        // // RVA: 0x20BC180 Offset: 0x20BC180 VA: 0x20BC180
        // public int GetMaxNumExposureAreas() { }

        // // RVA: 0x20BC300 Offset: 0x20BC300 VA: 0x20BC300
        // public int GetSupportedWhiteBalanceMode(WhiteBalanceMode[] modes) { }

        // // RVA: 0x20BC4B4 Offset: 0x20BC4B4 VA: 0x20BC4B4
        // public int GetSupportedSceneMode(SceneMode[] modes) { }

        // // RVA: 0x20BC664 Offset: 0x20BC664 VA: 0x20BC664
        public int GetDeviceInfo(CameraDeviceInfo info)
        {
            return sarSmartar_SarCameraDevice_sarGetDeviceInfo(self_, info.self_);
        }

        // // RVA: 0x20BC7FC Offset: 0x20BC7FC VA: 0x20BC7FC
        // public int GetFovY(out float fovy, float heightRatio = 1) { }

        // // RVA: 0x20BC9C0 Offset: 0x20BC9C0 VA: 0x20BC9C0
        // public int GetFovY(out float fovy, float heightRatio, out bool calibrated) { }

        // // RVA: 0x20BCA64 Offset: 0x20BCA64 VA: 0x20BCA64
        public int GetFacing(out Facing facing)
        {
            return sarSmartar_SarCameraDevice_sarGetFacing(self_, out facing);
        }

        // // RVA: 0x20BCBE0 Offset: 0x20BCBE0 VA: 0x20BCBE0
        public int GetRotation(out Rotation rotation)
        {
            return sarSmartar_SarCameraDevice_sarGetRotation(self_, out rotation);
        }

        // // RVA: 0x20BCD64 Offset: 0x20BCD64 VA: 0x20BCD64
        // public int GetNativeDevice(out IntPtr nativeDevice) { }

        // // RVA: 0x20BCEE8 Offset: 0x20BCEE8 VA: 0x20BCEE8
        public int Start()
        {
            return sarSmartar_SarCameraDevice_sarStart(self_);
        }

        // // RVA: 0x20BD054 Offset: 0x20BD054 VA: 0x20BD054
        public int Stop()
        {
            return sarSmartar_SarCameraDevice_sarStop(self_);
        }

        // // RVA: 0x20BD1BC Offset: 0x20BD1BC VA: 0x20BD1BC
        // public int CaptureStillImage() { }

        // // RVA: 0x20BD330 Offset: 0x20BD330 VA: 0x20BD330
        // public int RunAutoFocus() { }

        // // RVA: 0x20BD4A4 Offset: 0x20BD4A4 VA: 0x20BD4A4
        // public int RunAutoExposure() { }

        // // RVA: 0x20BD618 Offset: 0x20BD618 VA: 0x20BD618
        // public int RunAutoWhiteBalance() { }

        // // RVA: 0x20BD794 Offset: 0x20BD794 VA: 0x20BD794
        public int GetImageSensorRotation(out Rotation rotation)
        {
            return sarSmartar_SarCameraDevice_sarGetImageSensorRotation(self_, out rotation);
        }

        // // RVA: 0x20BD920 Offset: 0x20BD920 VA: 0x20BD920
        public int GetAndroidCameraAPIFeature(out int apiLevel, out int hwFeature) 
        {
            return sarSmartar_SarCameraDevice_sarGetAndroidCameraAPIFeature(self_, out apiLevel, out hwFeature);
        }

        // // RVA: 0x20BDAC4 Offset: 0x20BDAC4 VA: 0x20BDAC4
        public bool IsAndroidCamera2Available(Smart smart, bool isFront, out int apiLevel, out int hwFeature)
        {
            return sarSmartar_SarCameraDevice_sarIsAndroidCamera2Available(smart.self_, isFront, out apiLevel, out hwFeature);
        }

        // // RVA: 0x20B87C0 Offset: 0x20B87C0 VA: 0x20B87C0
        // private static extern IntPtr sarSmartar_SarCameraDevice_SarCameraDevice(IntPtr smart, bool forceOldAndroidAPI = False) { }

        // // RVA: 0x20B89F0 Offset: 0x20B89F0 VA: 0x20B89F0
        // private static extern IntPtr sarSmartar_SarCameraDevice_SarCameraDevice2(IntPtr smart, int cameraId, IntPtr nativeDevice, bool forceOldAndroidAPI = False) { }

        // // RVA: 0x20B8D90 Offset: 0x20B8D90 VA: 0x20B8D90
        [DllImport("smartar")]
        private static extern void sarSmartar_SarCameraDevice_sarDelete(IntPtr self);

        // // RVA: 0x20B8FF8 Offset: 0x20B8FF8 VA: 0x20B8FF8
        // private static extern int sarSmartar_SarCameraDevice_sarSetNativeVideoOutput(IntPtr self, IntPtr nativeVideoOutput) { }

        // // RVA: 0x20B91B0 Offset: 0x20B91B0 VA: 0x20B91B0
        // private static extern int sarSmartar_SarCameraDevice_sarSetVideoImageListener(IntPtr self, IntPtr listener, IntPtr smart) { }

        // // RVA: 0x20B9348 Offset: 0x20B9348 VA: 0x20B9348
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarSetVideoImageSize(IntPtr self, int width, int height);

        // // RVA: 0x20B94D8 Offset: 0x20B94D8 VA: 0x20B94D8
        // private static extern int sarSmartar_SarCameraDevice_sarSetVideoImageFormat(IntPtr self, ImageFormat format) { }

        // // RVA: 0x20B9668 Offset: 0x20B9668 VA: 0x20B9668
        // private static extern int sarSmartar_SarCameraDevice_sarSetVideoImageFpsRange(IntPtr self, float min, float max) { }

        // // RVA: 0x20B9808 Offset: 0x20B9808 VA: 0x20B9808
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarSetStillImageListener(IntPtr self, IntPtr listener);

        // // RVA: 0x20B9998 Offset: 0x20B9998 VA: 0x20B9998
        // private static extern int sarSmartar_SarCameraDevice_sarSetStillImageSize(IntPtr self, int width, int height) { }

        // // RVA: 0x20B9B28 Offset: 0x20B9B28 VA: 0x20B9B28
        // private static extern int sarSmartar_SarCameraDevice_sarSetStillImageFormat(IntPtr self, ImageFormat format) { }

        // // RVA: 0x20B9CC0 Offset: 0x20B9CC0 VA: 0x20B9CC0
        // private static extern int sarSmartar_SarCameraDevice_sarSetShutterListener(IntPtr self, IntPtr listener) { }

        // // RVA: 0x20B9E48 Offset: 0x20B9E48 VA: 0x20B9E48
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarSetFocusMode(IntPtr self, FocusMode mode);

        // // RVA: 0x20B9FE0 Offset: 0x20B9FE0 VA: 0x20B9FE0
        // private static extern int sarSmartar_SarCameraDevice_sarSetFocusAreas(IntPtr self, CameraArea[] areas, int numAreas) { }

        // // RVA: 0x20BA170 Offset: 0x20BA170 VA: 0x20BA170
        // private static extern int sarSmartar_SarCameraDevice_sarSetExposureMode(IntPtr self, ExposureMode mode) { }

        // // RVA: 0x20BA308 Offset: 0x20BA308 VA: 0x20BA308
        // private static extern int sarSmartar_SarCameraDevice_sarSetExposureAreas(IntPtr self, CameraArea[] areas, int numAreas) { }

        // // RVA: 0x20BA4A0 Offset: 0x20BA4A0 VA: 0x20BA4A0
        // private static extern int sarSmartar_SarCameraDevice_sarSetFlashMode(IntPtr self, FlashMode mode) { }

        // // RVA: 0x20BA620 Offset: 0x20BA620 VA: 0x20BA620
        // private static extern int sarSmartar_SarCameraDevice_sarSetWhiteBalanceMode(IntPtr self, WhiteBalanceMode mode) { }

        // // RVA: 0x20BA7A8 Offset: 0x20BA7A8 VA: 0x20BA7A8
        // private static extern int sarSmartar_SarCameraDevice_sarSetSceneMode(IntPtr self, SceneMode mode) { }

        // // RVA: 0x20BA938 Offset: 0x20BA938 VA: 0x20BA938
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarSetAutoFocusListener(IntPtr self, IntPtr listener);

        // // RVA: 0x20BAAD0 Offset: 0x20BAAD0 VA: 0x20BAAD0
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarSetAutoExposureListener(IntPtr self, IntPtr listener);

        // // RVA: 0x20BAC70 Offset: 0x20BAC70 VA: 0x20BAC70
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarSetAutoWhiteBalanceListener(IntPtr self, IntPtr listener);

        // // RVA: 0x20BAE10 Offset: 0x20BAE10 VA: 0x20BAE10
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarSetCameraErrorListener(IntPtr self, IntPtr listener);

        // // RVA: 0x20BAFA0 Offset: 0x20BAFA0 VA: 0x20BAFA0
        // private static extern int sarSmartar_SarCameraDevice_sarSetOwningNativeDevice(IntPtr self, bool isOwning) { }

        // // RVA: 0x20BB150 Offset: 0x20BB150 VA: 0x20BB150
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarGetDefaultCameraId(IntPtr smart, Facing facing, out int cameraId, bool forceOldAndroidAPI = false);

        // // RVA: 0x20BB300 Offset: 0x20BB300 VA: 0x20BB300
        // private static extern int sarSmartar_SarCameraDevice_sarGetSupportedVideoImageSize(IntPtr self, Size[] sizes, int maxSizes) { }

        // // RVA: 0x20BB4B8 Offset: 0x20BB4B8 VA: 0x20BB4B8
        // private static extern int sarSmartar_SarCameraDevice_sarGetSupportedVideoImageFormat(IntPtr self, ImageFormat[] formats, int maxFormats) { }

        // // RVA: 0x20BB670 Offset: 0x20BB670 VA: 0x20BB670
        // private static extern int sarSmartar_SarCameraDevice_sarGetSupportedVideoImageFpsRange(IntPtr self, CameraFpsRange[] ranges, int maxRanges) { }

        // // RVA: 0x20BB828 Offset: 0x20BB828 VA: 0x20BB828
        // private static extern int sarSmartar_SarCameraDevice_sarGetSupportedStillImageSize(IntPtr self, Size[] sizes, int maxSizes) { }

        // // RVA: 0x20BB9E0 Offset: 0x20BB9E0 VA: 0x20BB9E0
        // private static extern int sarSmartar_SarCameraDevice_sarGetSupportedStillImageFormat(IntPtr self, ImageFormat[] formats, int maxFormats) { }

        // // RVA: 0x20BBB98 Offset: 0x20BBB98 VA: 0x20BBB98
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarGetSupportedFocusMode(IntPtr self, FocusMode[] modes, int maxModes);

        // // RVA: 0x20BBD28 Offset: 0x20BBD28 VA: 0x20BBD28
        // private static extern int sarSmartar_SarCameraDevice_sarGetMaxNumFocusAreas(IntPtr self) { }

        // // RVA: 0x20BBEC0 Offset: 0x20BBEC0 VA: 0x20BBEC0
        // private static extern int sarSmartar_SarCameraDevice_sarGetSupportedFlashMode(IntPtr self, FlashMode[] modes, int maxModes) { }

        // // RVA: 0x20BC070 Offset: 0x20BC070 VA: 0x20BC070
        // private static extern int sarSmartar_SarCameraDevice_sarGetSupportedExposureMode(IntPtr self, ExposureMode[] modes, int maxModes) { }

        // // RVA: 0x20BC208 Offset: 0x20BC208 VA: 0x20BC208
        // private static extern int sarSmartar_SarCameraDevice_sarGetMaxNumExposureAreas(IntPtr self) { }

        // // RVA: 0x20BC3A0 Offset: 0x20BC3A0 VA: 0x20BC3A0
        // private static extern int sarSmartar_SarCameraDevice_sarGetSupportedWhiteBalanceMode(IntPtr self, WhiteBalanceMode[] modes, int maxModes) { }

        // // RVA: 0x20BC558 Offset: 0x20BC558 VA: 0x20BC558
        // private static extern int sarSmartar_SarCameraDevice_sarGetSupportedSceneMode(IntPtr self, SceneMode[] modes, int maxModes) { }

        // // RVA: 0x20BC708 Offset: 0x20BC708 VA: 0x20BC708
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarGetDeviceInfo(IntPtr self, IntPtr info);

        // // RVA: 0x20BC8A8 Offset: 0x20BC8A8 VA: 0x20BC8A8
        // private static extern int sarSmartar_SarCameraDevice_sarGetFovY(IntPtr self, out float fovy, float heightRatio, out bool calibrated) { }

        // // RVA: 0x20BCAF0 Offset: 0x20BCAF0 VA: 0x20BCAF0
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarGetFacing(IntPtr self, out Facing facing);

        // // RVA: 0x20BCC70 Offset: 0x20BCC70 VA: 0x20BCC70
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarGetRotation(IntPtr self, out Rotation rotation);

        // // RVA: 0x20BCDF0 Offset: 0x20BCDF0 VA: 0x20BCDF0
        // private static extern int sarSmartar_SarCameraDevice_sarGetNativeDevice(IntPtr self, out IntPtr nativeDevice) { }

        // // RVA: 0x20BCF70 Offset: 0x20BCF70 VA: 0x20BCF70
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarStart(IntPtr self);

        // // RVA: 0x20BD0D8 Offset: 0x20BD0D8 VA: 0x20BD0D8
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarStop(IntPtr self);

        // // RVA: 0x20BD240 Offset: 0x20BD240 VA: 0x20BD240
        // private static extern int sarSmartar_SarCameraDevice_sarCaptureStillImage(IntPtr self) { }

        // // RVA: 0x20BD3B8 Offset: 0x20BD3B8 VA: 0x20BD3B8
        // private static extern int sarSmartar_SarCameraDevice_sarRunAutoFocus(IntPtr self) { }

        // // RVA: 0x20BD528 Offset: 0x20BD528 VA: 0x20BD528
        // private static extern int sarSmartar_SarCameraDevice_sarRunAutoExposure(IntPtr self) { }

        // // RVA: 0x20BD6A0 Offset: 0x20BD6A0 VA: 0x20BD6A0
        // private static extern int sarSmartar_SarCameraDevice_sarRunAutoWhiteBalance(IntPtr self) { }

        // // RVA: 0x20BD820 Offset: 0x20BD820 VA: 0x20BD820
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarGetImageSensorRotation(IntPtr self, out Rotation rotation);

        // // RVA: 0x20BD9B8 Offset: 0x20BD9B8 VA: 0x20BD9B8
        [DllImport("smartar")]
        private static extern int sarSmartar_SarCameraDevice_sarGetAndroidCameraAPIFeature(IntPtr self, out int apiLevel, out int hwFeature);

        // // RVA: 0x20BDB78 Offset: 0x20BDB78 VA: 0x20BDB78
        [DllImport("smartar")]
        private static extern bool sarSmartar_SarCameraDevice_sarIsAndroidCamera2Available(IntPtr smart, bool isFront, out int apiLevel, out int hwFeature);
    }
}