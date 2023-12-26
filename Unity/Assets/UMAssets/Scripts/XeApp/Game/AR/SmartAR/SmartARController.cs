
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using smartar;
using UnityEngine;

public class SmartARController : SmartARControllerBase
{
    [Serializable]
    public class CameraDeviceSettings
    {
        public int cameraId; // 0x8
        public UnityEngine.Vector2 videoImageSize = new UnityEngine.Vector2(0, 0); // 0xC
        public FocusMode focusMode = FocusMode.FOCUS_MODE_CONTINUOUS_AUTO_VIDEO; // 0x14
    }

    [Serializable]
    public class MiscSettings
    {
        public bool showCameraPreview = true; // 0x8
        public bool showLandmarks; // 0x9
    }

    public class AndroidCameraFeature
    {
        public int androidCameraApiLevel_; // 0x8
        public int androidCameraHwFeature_ = -1; // 0xC
        public bool androidCanUseNewAPI_; // 0x10
    }

    public class StillImageListener : CameraImageListener
    {
        private string m_CaptureImageName; // 0x8
        private string m_CaptureImagePath; // 0xC
        private Smart m_Smart; // 0x10

        // RVA: 0x12F1EB0 Offset: 0x12F1EB0 VA: 0x12F1EB0
        public StillImageListener(string captureImagePath, Smart smart)
        {
            m_CaptureImagePath = captureImagePath;
            m_Smart = smart;
        }

        // // RVA: 0x12F56F8 Offset: 0x12F56F8 VA: 0x12F56F8 Slot: 5
        public virtual void OnImage(ImageHolder imageHolder, ulong timestamp)
        {
            m_CaptureImageName = string.Format("{0}/capture_image_{1}.jpg", m_CaptureImagePath, DateTime.Now.ToString("d-MM-yyyy-HH-mm-ss-f"));
            int size = imageHolder.getImageSizeInBytes();
            if(size > 0)
            {
                Image im = new Image();
                im.pixels_ = Marshal.AllocHGlobal(size);
                imageHolder.getImage(ref im, size, m_Smart);
                AndroidJavaObject o1 = new AndroidJavaObject("android.os.StatFs", new object[] { Application.temporaryCachePath });
                long l1 = o1.Call<long>("getAvailableBlocksLong", Array.Empty<object>());
                long l2 = o1.Call<long>("getBlockSizeLong");
                if(size < l1 * l2)
                {
                    byte[] dst = new byte[size];
                    Marshal.Copy(im.pixels_, dst, 0, size);
                    File.WriteAllBytes(m_CaptureImageName, dst);
                    AndroidJavaObject o2 = new AndroidJavaObject("com.sony.smartar.unsupportedutils.UnsupportedUtils", Array.Empty<object>());
                    string s = o2.CallStatic<string>("moveToExternalDir", new object[1] { m_CaptureImageName });
                    if(!string.IsNullOrEmpty(s))
                    {
                        o2.CallStatic("scanCaptureImage", new object[1] { s });
                    }
                    o2.Dispose();
                }
                Marshal.FreeHGlobal(im.pixels_);
            }
        }
    }

    public class AutoFocusListener : CameraAutoAdjustListener
    {
        // // RVA: 0x12F56EC Offset: 0x12F56EC VA: 0x12F56EC Slot: 5
        public virtual void OnAutoAdjust(bool success)
        {
            return;
        }
    }

    public class AutoExposureListener : CameraAutoAdjustListener
    {
        // // RVA: 0x12F56E8 Offset: 0x12F56E8 VA: 0x12F56E8 Slot: 5
        public virtual void OnAutoAdjust(bool success)
        {
            return;
        }
    }

    public class AutoWhiteBalanceListener : CameraAutoAdjustListener
    {
        // // RVA: 0x12F56F0 Offset: 0x12F56F0 VA: 0x12F56F0 Slot: 5
        public virtual void OnAutoAdjust(bool success)
        {
            return;
        }
    }

    public class CameraErrorListener : smartar.CameraErrorListener
    {
        // // RVA: 0x12F56F4 Offset: 0x12F56F4 VA: 0x12F56F4 Slot: 5
        public virtual void OnError(int error)
        {
            return;
        }
    }

	[SerializeField]
	private CameraDeviceSettings cameraDeviceSettings = new CameraDeviceSettings(); // 0x6C
	[SerializeField]
	private MiscSettings miscSettings = new MiscSettings(); // 0x70
	protected bool isTriangulateMaskChanged; // 0x74
	private bool forceOldAndroidCameraAPI_; // 0x75
	private AndroidCameraFeature androidCameraFeature = new AndroidCameraFeature(); // 0x78
	[HideInInspector]
	public CameraDevice cameraDevice_; // 0x7C
	[HideInInspector]
	public SensorDevice sensorDevice_; // 0x80
	[HideInInspector]
	public ScreenDevice screenDevice_; // 0x84
	[HideInInspector]
	public CameraImageDrawer cameraImageDrawer_; // 0x88
	[HideInInspector]
	public bool isFlipX_; // 0x8C
	[HideInInspector]
	public bool isFlipY_; // 0x8D
	[HideInInspector]
	public Rotation cameraRotation_; // 0x90
	private bool isFront_; // 0x94
	private float drawTimeSec_; // 0x98
	private float drawStartTimeSec_; // 0x9C
	protected SmartARController.StillImageListener mStillImageListener; // 0xA0
	protected SmartARController.AutoFocusListener mAutoFocusListener; // 0xA4
	protected SmartARController.AutoExposureListener mAutoExposureListener; // 0xA8
	protected SmartARController.AutoWhiteBalanceListener mAutoWhiteBalanceListener; // 0xAC
	protected SmartARController.CameraErrorListener mCameraErrorListener; // 0xB0

	public SmartARController.CameraDeviceSettings cameraDeviceSettings_ { get { return cameraDeviceSettings; } set { ConfigCameraDevice(value, false); } } //0x12F0370 0x12F0378
	// public SmartARController.MiscSettings miscSettings_ { get; set; } 0x12F0688 0x12F0690
	// public override Triangle2[] triangulateMasks_ { get; set; } 0x12F06A0 0x12F0800
	// public SmartARController.AndroidCameraFeature androidCameraFeature_ { get; } 0x12F0808
	public ulong cameraFrameCount_ { get { 
        if(self_ != IntPtr.Zero)
            return sarSmartar_SarSmartARController_sarGetCameraFrameCount(self_);
        return 0;
     } } //0x12F0810
	// public override ulong[] recogCount_ { get; } 0x12F0980
	// public override ulong[] recogTime_ { get; } 0x12F0B64
	// public ulong drawCount_ { get; } 0x12F0D48
	// public ulong drawTime_ { get; } 0x12F0D60

	// // RVA: 0x12F0D84 Offset: 0x12F0D84 VA: 0x12F0D84
	// public bool changeAndroidCameraAPI(out int apiLevel, out int hwFeature, out bool canChangeNewAPI) { }

	// // RVA: 0x12F0E60 Offset: 0x12F0E60 VA: 0x12F0E60
	// public void getAndroidCameraFeature(out int apiLevel, out int hwFeature, out bool canChangeNewAPI) { }

	// // RVA: 0x12F0380 Offset: 0x12F0380 VA: 0x12F0380
	private void ConfigCameraDevice(CameraDeviceSettings newSettings, bool creating)
    {
        if(creating)
        {
            FocusMode[] modes = new FocusMode[32];
            int a = cameraDevice_.GetSupportedFocusMode(modes);
            modes = new ArraySegment<FocusMode>(modes, 0, a).Array;
            if(((ICollection<FocusMode>)modes).Contains(newSettings.focusMode))
            {
                cameraDevice_.SetFocusMode(newSettings.focusMode);
            }
            cameraDeviceSettings = newSettings;
        }
        else
        {
            if(newSettings.cameraId == cameraDeviceSettings.cameraId && newSettings.videoImageSize == cameraDeviceSettings.videoImageSize)
            {
                if(newSettings.focusMode != cameraDeviceSettings.focusMode)
                {
                    FocusMode[] modes = new FocusMode[32];
                    int a = cameraDevice_.GetSupportedFocusMode(modes);
                    modes = new ArraySegment<FocusMode>(modes, 0, a).Array;
                    if(((ICollection<FocusMode>)modes).Contains(newSettings.focusMode))
                    {
                        cameraDevice_.SetFocusMode(newSettings.focusMode);
                    }
                }
                cameraDeviceSettings = newSettings;
            }
            else
            {
                cameraDeviceSettings = newSettings;
                if(enabled_)
                {
                    DoDisable();
                    DoEnable();
                }
            }
        }
    }

	// // RVA: 0x12F0698 Offset: 0x12F0698 VA: 0x12F0698
	// private void ConfigMisc(SmartARController.MiscSettings newSettings, bool creating) { }

	// RVA: 0x12F0EF4 Offset: 0x12F0EF4 VA: 0x12F0EF4 Slot: 8
	protected override void DoCreate()
    {
        base.DoCreate();
        cameraImageDrawer_ = new CameraImageDrawer(smart_);
        screenDevice_ = new ScreenDevice(smart_);
        CreateParam p = new CreateParam();
        p.smart_ = smart_.self_;
        p.recognizer_ = recognizer_.self_;
        p.screenDevice_ = screenDevice_.self_;
        p.cameraImageDrawer_ = cameraImageDrawer_.self_;
        self_ = sarSmartar_SarSmartARController_sarDoCreate(ref p, numWorkerThreads_ > 0, PreviewOnly);
        if(self_ != IntPtr.Zero)
        {
            workerThreads_ = null;
            if(numWorkerThreads_ > 0)
            {
                workerThreads_ = new Thread[numWorkerThreads_];
                for(int i = 0; i < numWorkerThreads_; i++)
                {
                    workerThreads_[i] = new Thread(() =>
                    {
                        //0x12F56D8
                        sarSmartar_SarSmartARController_sarRunWorkerThread(self_);
                    });
                    workerThreads_[i].Start();
                }
            }
            started_ = true;
        }
    }

	// // RVA: 0x12F14CC Offset: 0x12F14CC VA: 0x12F14CC Slot: 9
	protected override void DoEnable()
    {
        if(!enabled_ && !smartInitFailed_ && self_ != IntPtr.Zero)
        {
            sensorDevice_ = new SensorDevice(smart_);
            SensorDeviceInfo info = new SensorDeviceInfo();
            sensorDevice_.GetDeviceInfo(info);
            recognizer_.SetSensorDeviceInfo(info);
            cameraDevice_ = new CameraDevice(smart_, cameraDeviceSettings.cameraId, forceOldAndroidCameraAPI_);
            cameraDevice_.GetRotation(out cameraRotation_);
            int camId;
            CameraDevice.GetDefaultCameraId(smart_, Facing.FACING_FRONT, out camId, forceOldAndroidCameraAPI_);
            isFront_ = false;
            if(camId != -1 && cameraDeviceSettings.cameraId == camId)
                isFront_ = true;
            int apiLevel = 0;
            int hwFeature = -1;
            androidCameraFeature.androidCanUseNewAPI_ = cameraDevice_.IsAndroidCamera2Available(smart_, isFront_, out apiLevel, out hwFeature);
            cameraDevice_.GetAndroidCameraAPIFeature(out apiLevel, out hwFeature);
            androidCameraFeature.androidCameraApiLevel_ = apiLevel;
            androidCameraFeature.androidCameraHwFeature_ = hwFeature;
            if(cameraDeviceSettings.videoImageSize.x != 0 && cameraDeviceSettings.videoImageSize.y != 0)
            {
                cameraDevice_.SetVideoImageSize((int)cameraDeviceSettings.videoImageSize.x, (int)cameraDeviceSettings.videoImageSize.y);
            }
            ConfigCameraDevice(cameraDeviceSettings, true);
            isFlipX_ = false;
            isFlipY_ = false;
            if(isFront_)
            {
                if(cameraRotation_ == Rotation.ROTATION_90 || cameraRotation_ == Rotation.ROTATION_0)
                    isFlipX_ = true;
                else
                    isFlipY_ = true;
                Rotation rot;
                cameraDevice_.GetImageSensorRotation(out rot);
                if(rot == Rotation.ROTATION_90 && isFront_)
                {
                    //??
                    cameraRotation_ = (Rotation)(((int)cameraRotation_ + 180) % 360);
                }
            }
            cameraImageDrawer_.SetFlipX(isFlipX_);
            cameraImageDrawer_.SetFlipY(isFlipY_);
            CameraDeviceInfo camInfo = new CameraDeviceInfo();
            cameraDevice_.GetDeviceInfo(camInfo);
            recognizer_.SetCameraDeviceInfo(camInfo);
            sarSmartar_SarSmartARController_sarDoEnable(self_, cameraDevice_.self_, sensorDevice_.self_);
            mStillImageListener = new StillImageListener(createCaptureImagePath(), smart_);
            if(mAutoFocusListener == null)
                mAutoFocusListener = new AutoFocusListener();
            if(mAutoExposureListener == null)
                mAutoExposureListener = new AutoExposureListener();
            if(mAutoWhiteBalanceListener == null)
                mAutoWhiteBalanceListener = new AutoWhiteBalanceListener();
            if(mCameraErrorListener == null)
                mCameraErrorListener = new CameraErrorListener();
            cameraDevice_.SetStillImageListener(mStillImageListener);
            cameraDevice_.SetAutoFocusListener(mAutoFocusListener);
            cameraDevice_.SetAutoExposureListener(mAutoExposureListener);
            cameraDevice_.SetAutoWhiteBalanceListener(mAutoWhiteBalanceListener);
            cameraDevice_.SetCameraErrorListener(mCameraErrorListener);
            cameraImageDrawer_.Start();
            landmarkDrawer_.Start();
            cameraDevice_.Start();
            sensorDevice_.Start();
            Camera c = GetComponent<Camera>();
            if(c.clearFlags != CameraClearFlags.Depth && c.clearFlags != CameraClearFlags.Nothing)
            {
                c.clearFlags = CameraClearFlags.Depth;
            }
            enabled_ = true;
        }
    }

	// // RVA: 0x12F1EF8 Offset: 0x12F1EF8 VA: 0x12F1EF8
	// public void DoEnable2() { }

	// RVA: 0x12F1F08 Offset: 0x12F1F08 VA: 0x12F1F08 Slot: 10
	protected override void DoDisable()
    {
        if(sensorDevice_ != null)
        {
            sensorDevice_.Stop();
            sensorDevice_.Dispose();
            sensorDevice_ = null;
        }
        if(cameraDevice_ != null)
        {
            cameraDevice_.Stop();
            cameraDevice_.Dispose();
            cameraDevice_ = null;
        }
        if(cameraImageDrawer_ != null)
            cameraImageDrawer_.Stop();
        if(self_ != IntPtr.Zero)
            sarSmartar_SarSmartARController_sarDoDisable(self_);
        base.DoDisable();
    }

	// RVA: 0x12F216C Offset: 0x12F216C VA: 0x12F216C Slot: 11
	protected override void DoDestroy()
    {
        if(workerThreads_ != null && workerThreads_.Length != 0)
        {
            if(self_ != IntPtr.Zero)
                sarSmartar_SarSmartARController_sarFinishWorkerThread(self_);
            for(int i = 0; i < workerThreads_.Length; i++)
            {
                workerThreads_[i].Join();
                workerThreads_[i] = null;
            }
            workerThreads_ = null;
        }
        if(self_ != IntPtr.Zero)
        {
            sarSmartar_SarSmartARController_sarDoDestroy(self_);
            self_ = IntPtr.Zero;
        }
        if(screenDevice_ != null)
        {
            screenDevice_.Dispose();
            screenDevice_ = null;
        }
        if(sensorDevice_ != null)
        {
            sensorDevice_.Dispose();
            sensorDevice_ = null;
        }
        if(cameraImageDrawer_ != null)
        {
            cameraImageDrawer_.Dispose();
            cameraImageDrawer_ = null;
        }
        base.DoDestroy();
    }

	// // RVA: 0x12F2634 Offset: 0x12F2634 VA: 0x12F2634 Slot: 12
	public override void resetController()
    {
        if(self_ != IntPtr.Zero)
        {
            sarSmartar_SarSmartARController_sarSuspendWorkerThread(self_);
            base.resetController();
            sarSmartar_SarSmartARController_sarResumeWorkerThread(self_);
        }
    }

	// // RVA: 0x12F28D0 Offset: 0x12F28D0 VA: 0x12F28D0
	// public void reCreateRecognizer(RecognitionMode recognitionMode, SceneMappingInitMode sceneMappingInitMode = 0, bool isPreviewOnly = False, bool useWorkerThreadAfterRecreate = True) { }

	// // RVA: 0x12F351C Offset: 0x12F351C VA: 0x12F351C
	public void StopController()
    {
        if(self_ != IntPtr.Zero)
        {
            sarSmartar_SarSmartARController_sarSuspendWorkerThread(self_);
            base.resetController();
        }
    }

	// // RVA: 0x12F3590 Offset: 0x12F3590 VA: 0x12F3590
	public void RestartController()
    {
        if(self_ != IntPtr.Zero)
        {
            sarSmartar_SarSmartARController_sarResumeWorkerThread(self_);
        }
    }

	// RVA: 0x12F35FC Offset: 0x12F35FC VA: 0x12F35FC
	private void Start()
    {
        GL.IssuePluginEvent(GetRenderEventFunc(), 0);
    }

	// RVA: 0x12F36D4 Offset: 0x12F36D4 VA: 0x12F36D4 Slot: 16
	protected virtual void Update()
    {
        if(smartInitFailed_)
            return;
        DoEnable();
        if(self_ == IntPtr.Zero)
            return;
        GetComponent<Camera>().fieldOfView = sarSmartar_SarSmartARController_sarGetFovy(self_);
    }

	// RVA: 0x12F3894 Offset: 0x12F3894 VA: 0x12F3894
	private void OnPreRender()
    {
        if(!smartInitFailed_ && self_ != IntPtr.Zero)
        {
            Camera c = GetComponent<Camera>();
            if(c != null)
            {
                drawStartTimeSec_ = Time.realtimeSinceStartup;
                GL.IssuePluginEvent(GetRenderEventFunc(), 0);
                GL.InvalidateState();
                if(!miscSettings.showLandmarks || PreviewOnly)
                {
                    sarSmartar_SarSmartARController_sarSetDrawData(Screen.width, Screen.height, miscSettings.showCameraPreview);
                }
                else
                {
                    RecognitionResult r = new RecognitionResult();
                    GetResult(null, ref r);
                    smartar.Vector3 pos;
                    smartar.Quaternion rot;
                    sarSmartar_SarSmartARController_sarAdjustPose(self_, ref r.position_, ref r.rotation_, out pos, out rot);
                    Matrix44 m;
                    Utility.convertPose2Matrix(pos, rot, out m);
                    Matrix44 proj = getProjMatrix();
                    Matrix44 m2 = sarSmartar_SarSmartARController_sarGetInitPointMatrix(self_);
                    m = proj * m;
                    sarSmartar_SarSmartARController_sarSetDrawData(Screen.width, Screen.height, miscSettings.showCameraPreview);
                    sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawLandmarkData(self_, landmarkDrawer_.self_, ref m, r.landmarks_, r.numLandmarks_);
                    sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawNodePointData(self_, landmarkDrawer_.self_, ref m, r.nodePoints_, r.numNodePoints_);
                    sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawInitPointData(self_, landmarkDrawer_.self_, ref m, r.initPoints_, r.numInitPoints_);
                }
                if(SystemInfo.graphicsDeviceType != UnityEngine.Rendering.GraphicsDeviceType.Metal)
                {
                    GL.IssuePluginEvent(GetRenderEventFunc(), 3001);
                    GL.InvalidateState();
                }
            }
        }
    }

	// RVA: 0x12F475C Offset: 0x12F475C VA: 0x12F475C
	private void OnPostRender()
    {
        if(!smartInitFailed_ && self_ != IntPtr.Zero)
        {
            sarSmartar_SarSmartARController_sarDoEndFrame(self_);
            drawTimeSec_ = drawTimeSec_ + (Time.realtimeSinceStartup - drawStartTimeSec_);
        }
    }

	// // RVA: 0x12F48F0 Offset: 0x12F48F0 VA: 0x12F48F0 Slot: 15
	protected override int CallNativeGetResult(IntPtr self, IntPtr target, ref RecognitionResult result)
    {
        if(self_ != IntPtr.Zero)
        {
            return sarSmartar_SarSmartARController_sarGetResult(self_, target, ref result);
        }
        return Error.ERROR_INVALID_POINTER;
    }

	// // RVA: 0x12F4ADC Offset: 0x12F4ADC VA: 0x12F4ADC
	public static void adjustPose(Rotation cameraRotation, Rotation screenRotation, bool isFlipX, bool isFlipY, smartar.Vector3 srcPosition, smartar.Quaternion srcRotation, out smartar.Vector3 rotPosition, out smartar.Quaternion rotRotation)
    {
        Rotation r = (Rotation)((cameraRotation + 360 - screenRotation) % 360);
        rotPosition = srcPosition;
        rotRotation = srcRotation;
        if(isFlipX)
        {
            rotPosition.x_ = -rotPosition.x_;
            srcRotation.z_ = -rotRotation.z_;
            rotRotation.y_ = -rotRotation.y_;
            rotRotation.z_ = srcRotation.z_;
        }
        if(isFlipY)
        {
            rotPosition.y_ = -rotPosition.y_;
            srcRotation.z_ = -rotRotation.z_;
            rotRotation.x_ = -rotRotation.x_;
            rotRotation.z_ = srcRotation.z_;
        }
        float f1;
        if(r == Rotation.ROTATION_0)
            return;
        else if(r == Rotation.ROTATION_90)
        {
            f1 = 0.7853982f;
        }
        else if(r == Rotation.ROTATION_180)
        {
            f1 = 1.570796f;
        }
        else if(r == Rotation.ROTATION_270)
        {
            f1 = 2.356194f;
        }
        else
        {
            throw new InvalidOperationException("unexpected value: " + r);
        }
        UnityEngine.Quaternion q = new UnityEngine.Quaternion(rotRotation.x_ , rotRotation.y_, rotRotation.z_, rotRotation.w_) * new UnityEngine.Quaternion(0, Mathf.Sin(f1), 0, Mathf.Cos(f1));
        rotRotation.x_ = q.x;
        rotRotation.y_ = q.y;
        rotRotation.z_ = q.z;
        rotRotation.w_ = q.w;
    }

	// // RVA: 0x12F4E20 Offset: 0x12F4E20 VA: 0x12F4E20
	// public void getImage(IntPtr image, out ulong timestamp) { }

	// // RVA: 0x12F4FC4 Offset: 0x12F4FC4 VA: 0x12F4FC4
	// public float getFovyFromSmartAR() { }

	// // RVA: 0x12F5034 Offset: 0x12F5034 VA: 0x12F5034
	public void getCameraId(Facing facing, out int cameraId)
    {
        if(smart_ != null)
        {
            CameraDevice.GetDefaultCameraId(smart_, facing, out cameraId, forceOldAndroidCameraAPI_);
            return;
        }
        cameraId = -1;
    }

	// // RVA: 0x12F5100 Offset: 0x12F5100 VA: 0x12F5100
	public Matrix44 getProjMatrix()
    {
        return Utility.setPerspectiveM(GetComponent<Camera>().fieldOfView, Screen.width * 1.0f / Screen.height, 0.01f, 100);
    }

	// // RVA: 0x12F51E4 Offset: 0x12F51E4 VA: 0x12F51E4 Slot: 13
	// public override int saveSceneMap(StreamOut stream) { }

	// // RVA: 0x12F1E3C Offset: 0x12F1E3C VA: 0x12F1E3C
	private string createCaptureImagePath()
    {
        switch(Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.LinuxEditor:
                return Application.dataPath;
            default:
                return null;
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.Android:
                return Application.persistentDataPath;
        }
    }

	// // RVA: 0x12F5234 Offset: 0x12F5234 VA: 0x12F5234
	// public void SetUseWorkerThread(bool useWorkerThread) { }

	// // RVA: 0x12F52A0 Offset: 0x12F52A0 VA: 0x12F52A0
	// public void suspendWorkerThread() { }

	// // RVA: 0x12F52A8 Offset: 0x12F52A8 VA: 0x12F52A8
	// public void resumeWorkerThread() { }

	// // RVA: 0x12F13D0 Offset: 0x12F13D0 VA: 0x12F13D0
    [DllImport("smartar")]
	private static extern IntPtr sarSmartar_SarSmartARController_sarDoCreate(ref SmartARControllerBase.CreateParam param, bool workerThreadEnabled, bool isPreviewOnly);

	// // RVA: 0x12F2428 Offset: 0x12F2428 VA: 0x12F2428
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarDoDestroy(IntPtr self);

	// // RVA: 0x12F1D40 Offset: 0x12F1D40 VA: 0x12F1D40
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarDoEnable(IntPtr self, IntPtr cameraDevice, IntPtr sensorDevice);

	// // RVA: 0x12F2008 Offset: 0x12F2008 VA: 0x12F2008
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarDoDisable(IntPtr self);

	// // RVA: 0x12F26B0 Offset: 0x12F26B0 VA: 0x12F26B0
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarSuspendWorkerThread(IntPtr self);

	// // RVA: 0x12F27D8 Offset: 0x12F27D8 VA: 0x12F27D8
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarResumeWorkerThread(IntPtr self);

	// // RVA: 0x12F52B0 Offset: 0x12F52B0 VA: 0x12F52B0
	// private static extern int sarSmartar_SarSmartARController_sarDoDraw(IntPtr self, int width, int height, bool showCameraImage) { }

	// // RVA: 0x12F4800 Offset: 0x12F4800 VA: 0x12F4800
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarDoEndFrame(IntPtr self);

	// // RVA: 0x12F4978 Offset: 0x12F4978 VA: 0x12F4978
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarGetResult(IntPtr self, IntPtr target, ref RecognitionResult result);

	// // RVA: 0x12F37A8 Offset: 0x12F37A8 VA: 0x12F37A8
    [DllImport("smartar")]
	private static extern float sarSmartar_SarSmartARController_sarGetFovy(IntPtr self);

	// // RVA: 0x12F4290 Offset: 0x12F4290 VA: 0x12F4290
    [DllImport("smartar")]
	public static extern Matrix44 sarSmartar_SarSmartARController_sarGetInitPointMatrix(IntPtr self);

	// // RVA: 0x12F40F0 Offset: 0x12F40F0 VA: 0x12F40F0
    [DllImport("smartar")]
	public static extern void sarSmartar_SarSmartARController_sarAdjustPose(IntPtr self, ref smartar.Vector3 fromPosition, ref smartar.Quaternion fromRotation, out smartar.Vector3 toPosition, out smartar.Quaternion toRotation);

	// // RVA: 0x12F53B8 Offset: 0x12F53B8 VA: 0x12F53B8
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarRunWorkerThread(IntPtr self);

	// // RVA: 0x12F2330 Offset: 0x12F2330 VA: 0x12F2330
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarFinishWorkerThread(IntPtr self);

	// // RVA: 0x12F0888 Offset: 0x12F0888 VA: 0x12F0888
    [DllImport("smartar")]
	private static extern ulong sarSmartar_SarSmartARController_sarGetCameraFrameCount(IntPtr self);

	// // RVA: 0x12F0A68 Offset: 0x12F0A68 VA: 0x12F0A68
	// private static extern ulong sarSmartar_SarSmartARController_sarGetRecogCount(IntPtr self, int index) { }

	// // RVA: 0x12F0C50 Offset: 0x12F0C50 VA: 0x12F0C50
	// private static extern ulong sarSmartar_SarSmartARController_sarGetRecogTime(IntPtr self, int index) { }

	// // RVA: 0x12F06F0 Offset: 0x12F06F0 VA: 0x12F06F0
	// private static extern void sarSmartar_SarSmartARController_sarSetTriangulateMasks(IntPtr self, Triangle2[] masks, int numMasks) { }

	// // RVA: 0x12F4EC8 Offset: 0x12F4EC8 VA: 0x12F4EC8
	// private static extern void sarSmartar_SarSmartARController_sarGetImage(IntPtr self, IntPtr image, out ulong timestamp) { }

	// // RVA: 0x12F3618 Offset: 0x12F3618 VA: 0x12F3618
    [DllImport("smartar")]
	private static extern IntPtr GetRenderEventFunc();

	// // RVA: 0x12F4390 Offset: 0x12F4390 VA: 0x12F4390
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarSetDrawData(int width, int height, bool showCameraImage);

	// // RVA: 0x12F4490 Offset: 0x12F4490 VA: 0x12F4490
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawLandmarkData(IntPtr self, IntPtr landmark_self, ref Matrix44 pmvMatrix, IntPtr landmarks, int numLandmarks);

	// // RVA: 0x12F4580 Offset: 0x12F4580 VA: 0x12F4580
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawNodePointData(IntPtr self, IntPtr landmark_self, ref Matrix44 pmvMatrix, IntPtr nodePoints, int numNodePoints);

	// // RVA: 0x12F4670 Offset: 0x12F4670 VA: 0x12F4670
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawInitPointData(IntPtr self, IntPtr landmark_self, ref Matrix44 imageMatrix, IntPtr initPoints, int numInitPoints);

	// // RVA: 0x12F3408 Offset: 0x12F3408 VA: 0x12F3408
	// private static extern void sarSmartar_SarSmartARController_sarChangeRecognitionMode(IntPtr self, ref SmartARControllerBase.CreateParam param, bool workerThreadEnabled, bool isPreviewOnly) { }

	// [CompilerGeneratedAttribute] // RVA: 0x5DD17C Offset: 0x5DD17C VA: 0x5DD17C
	// // RVA: 0x12F56E0 Offset: 0x12F56E0 VA: 0x12F56E0
	// private void <reCreateRecognizer>b__59_0() { }
}
