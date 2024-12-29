
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
#if UNITY_ANDROID && !UNITY_EDITOR
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
#else
                m_CaptureImageName = string.Format("{0}/capture_image_{1}.bmp", m_CaptureImagePath, DateTime.Now.ToString("d-MM-yyyy-HH-mm-ss-f"));
                byte[] bitmapData = new byte[size];
                Marshal.Copy(im.pixels_, bitmapData, 0, size);
                File.WriteAllBytes(m_CaptureImageName, bitmapData);
#endif
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

    public enum ARList
    {
        None,
        AR010002, AR010003, AR010004, AR010005, AR010006, AR010007, AR010008, AR010009, AR010010, AR010011, // OK
        AR010017, AR010018, // OK
        AR020022, // OK
        AR010023, // OK
        AR030024, AR030025, AR030026, AR030027, // OK
        AR050028,   
        AR060029,
        AR070030, // OK
        AR080031,
        AR090032, AR090033, AR090034, AR090035, AR090036, AR090037,
        AR100038, AR100039,
        AR110040,
        AR120041, AR120042, AR120043, AR120044, AR120045, AR120046, AR120047,
        AR130048, AR130049, AR130050, AR130051, AR130052, AR130053, AR130054, AR130055, AR130056, AR130057, // OK
        AR140058,
        AR150059
    }
    public ARList ARName = ARList.None;

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
        //UMO
        miscSettings.showLandmarks = true;
        //UMO
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
#if UNITY_ANDROID && !UNITY_EDITOR
            int apiLevel = 0;
            int hwFeature = -1;
            androidCameraFeature.androidCanUseNewAPI_ = cameraDevice_.IsAndroidCamera2Available(smart_, isFront_, out apiLevel, out hwFeature);
            cameraDevice_.GetAndroidCameraAPIFeature(out apiLevel, out hwFeature);
            androidCameraFeature.androidCameraApiLevel_ = apiLevel;
            androidCameraFeature.androidCameraHwFeature_ = hwFeature;
#endif
            if(cameraDeviceSettings.videoImageSize.x != 0 && cameraDeviceSettings.videoImageSize.y != 0)
            {
                cameraDevice_.SetVideoImageSize((int)cameraDeviceSettings.videoImageSize.x, (int)cameraDeviceSettings.videoImageSize.y);
            }
            ConfigCameraDevice(cameraDeviceSettings, true);
            isFlipX_ = false;
            isFlipY_ = false;
            if(isFront_)
            {
#if UNITY_ANDROID && !UNITY_EDITOR
                if(cameraRotation_ == Rotation.ROTATION_90 || cameraRotation_ == Rotation.ROTATION_0)
                    isFlipX_ = true;
                else
                    isFlipY_ = true;
#endif
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
#if !UNITY_EDITOR
        GL.IssuePluginEvent(GetRenderEventFunc(), 0);
#endif
    }
#if UNITY_EDITOR
    UnityEngine.Vector3 mousePrevPos = new UnityEngine.Vector3(0, 0, 0);
#endif
	// RVA: 0x12F36D4 Offset: 0x12F36D4 VA: 0x12F36D4 Slot: 16
	protected virtual void Update()
    {
        if(smartInitFailed_)
            return;
        DoEnable();
        if(self_ == IntPtr.Zero)
            return;
        GetComponent<Camera>().fieldOfView = sarSmartar_SarSmartARController_sarGetFovy(self_);
#if UNITY_EDITOR
        if(UnityEngine.Input.mouseScrollDelta.x != 0)
        {
            camDist += UnityEngine.Input.mouseScrollDelta.x;
        }
        if(Input.GetMouseButtonDown(0))
        {
            mousePrevPos = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            UnityEngine.Vector2 diff = mousePrevPos - Input.mousePosition;
            camRot.x += diff.x * 0.1f;
            camRot.x = camRot.x % 360;
            camRot.y += diff.y * 0.1f;
            camRot.y = Mathf.Clamp(camRot.y, -90, 90);
            mousePrevPos = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            mousePrevPos = UnityEngine.Vector3.zero;
        }
#endif
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
#if !UNITY_EDITOR
                GL.IssuePluginEvent(GetRenderEventFunc(), 0);
#endif
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
                    sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawInitPointData(self_, landmarkDrawer_.self_, ref m2, r.initPoints_, r.numInitPoints_);
                }
                if(SystemInfo.graphicsDeviceType != UnityEngine.Rendering.GraphicsDeviceType.Metal)
                {
#if !UNITY_EDITOR
                    GL.IssuePluginEvent(GetRenderEventFunc(), 3001);
#endif
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

#if UNITY_EDITOR
    public UnityEngine.Vector3 camRot = new UnityEngine.Vector3(0, 45, 0);
    public float camDist = 0.4f;
    public UnityEngine.Vector3 camTargetOffset = new UnityEngine.Vector3(0, 0.1f, 0);
#endif

	// // RVA: 0x12F48F0 Offset: 0x12F48F0 VA: 0x12F48F0 Slot: 15
	protected override int CallNativeGetResult(IntPtr self, IntPtr target, ref RecognitionResult result)
    {
        if(self_ != IntPtr.Zero)
        {
#if UNITY_EDITOR
            if(target.ToInt64() == ARName.ToString().GetHashCode())
            {
                result.isRecognized_ = true;
                result.position_ = new smartar.Vector3();
                
                /*result.position_.x_ = -0.001869183f;
                result.position_.y_ = -0.2094777f;
                result.position_.z_ = 0.294562f;
                result.rotation_.x_ = 0.6534966f;
                result.rotation_.y_ = -0.6714854f;
                result.rotation_.z_ = -0.2386414f;
                result.rotation_.w_ = 0.2551467f;*/
                //UnityEngine.Quaternion camRot_ = UnityEngine.Quaternion.Euler(180, camRot.x, 90 - camRot.y);
                UnityEngine.Vector3 camPos = UnityEngine.Quaternion.Euler(0, camRot.x, camRot.y) * new UnityEngine.Vector3(1, 0, 0) * camDist;
                //UnityEngine.Vector3 camPos2 = camRot_ * new UnityEngine.Vector3(1, 0, 0) * camDist;
                UnityEngine.Vector3 v1 = UnityEngine.Quaternion.LookRotation(camTargetOffset - camPos, UnityEngine.Vector3.up).eulerAngles;
                UnityEngine.Quaternion q = UnityEngine.Quaternion.Euler(180, v1.y - 270, 90 - v1.x);
                //UnityEngine.Debug.LogError(camPos+" "+camTargetOffset+" "+camRot_+" "+camPos2+" "+camRot_.eulerAngles+" "+v1+" "+q+" "+q.eulerAngles);
                result.position_.x_ = camPos.x;
                result.position_.y_ = camPos.z;
                result.position_.z_ = camPos.y;
                result.rotation_.x_ = q.x;
                result.rotation_.y_ = q.z;
                result.rotation_.z_ = q.y;
                result.rotation_.w_ = q.w;

                result.targetTrackingState_ = TargetTrackingState.TARGET_TRACKING_STATE_TRACKING;
                result.sceneMappingState_ = SceneMappingState.SCENE_MAPPING_STATE_IDLE;
            }
            else
            {
                result.isRecognized_ = false;
            }
            return 0;
#endif
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
        UnityEngine.Quaternion q = new UnityEngine.Quaternion(rotRotation.x_ , rotRotation.z_, rotRotation.y_, rotRotation.w_) * new UnityEngine.Quaternion(0, Mathf.Sin(f1), 0, Mathf.Cos(f1));
        rotRotation.x_ = q.x;
        rotRotation.y_ = q.z;
        rotRotation.z_ = q.y;
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
#if UNITY_EDITOR
    private static IntPtr sarSmartar_SarSmartARController_sarDoCreate(ref SmartARControllerBase.CreateParam param, bool workerThreadEnabled, bool isPreviewOnly)
    {
        return new IntPtr(1);
    }
#else
    [DllImport("smartar")]
	private static extern IntPtr sarSmartar_SarSmartARController_sarDoCreate(ref SmartARControllerBase.CreateParam param, bool workerThreadEnabled, bool isPreviewOnly);
#endif

	// // RVA: 0x12F2428 Offset: 0x12F2428 VA: 0x12F2428
#if UNITY_EDITOR
    private static void sarSmartar_SarSmartARController_sarDoDestroy(IntPtr self)
    {
    }
#else
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarDoDestroy(IntPtr self);
#endif

	// // RVA: 0x12F1D40 Offset: 0x12F1D40 VA: 0x12F1D40
#if UNITY_EDITOR
    private static int sarSmartar_SarSmartARController_sarDoEnable(IntPtr self, IntPtr cameraDevice, IntPtr sensorDevice)
    {
        return 0;
    }
#else
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarDoEnable(IntPtr self, IntPtr cameraDevice, IntPtr sensorDevice);
#endif

	// // RVA: 0x12F2008 Offset: 0x12F2008 VA: 0x12F2008
#if UNITY_EDITOR
    private static int sarSmartar_SarSmartARController_sarDoDisable(IntPtr self)
    {
        return 0;
    }
#else
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarDoDisable(IntPtr self);
#endif

	// // RVA: 0x12F26B0 Offset: 0x12F26B0 VA: 0x12F26B0
#if UNITY_EDITOR
    private static int sarSmartar_SarSmartARController_sarSuspendWorkerThread(IntPtr self)
    {
        return 0;
    }
#else
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarSuspendWorkerThread(IntPtr self);
#endif

	// // RVA: 0x12F27D8 Offset: 0x12F27D8 VA: 0x12F27D8
#if UNITY_EDITOR
    private static int sarSmartar_SarSmartARController_sarResumeWorkerThread(IntPtr self)
    {
        return 0;
    }
#else
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarResumeWorkerThread(IntPtr self);
#endif

	// // RVA: 0x12F52B0 Offset: 0x12F52B0 VA: 0x12F52B0
	// private static extern int sarSmartar_SarSmartARController_sarDoDraw(IntPtr self, int width, int height, bool showCameraImage) { }

	// // RVA: 0x12F4800 Offset: 0x12F4800 VA: 0x12F4800
#if UNITY_EDITOR
    private static int sarSmartar_SarSmartARController_sarDoEndFrame(IntPtr self)
    {
        return 0;
    }
#else
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarDoEndFrame(IntPtr self);
#endif

	// // RVA: 0x12F4978 Offset: 0x12F4978 VA: 0x12F4978
#if UNITY_EDITOR
    private static int sarSmartar_SarSmartARController_sarGetResult(IntPtr self, IntPtr target, ref RecognitionResult result)
    {
        return 0;
    }
#else
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarGetResult(IntPtr self, IntPtr target, ref RecognitionResult result);
#endif

	// // RVA: 0x12F37A8 Offset: 0x12F37A8 VA: 0x12F37A8
#if UNITY_EDITOR
    private static float sarSmartar_SarSmartARController_sarGetFovy(IntPtr self)
    {
        return 30;
    }
#else
    [DllImport("smartar")]
	private static extern float sarSmartar_SarSmartARController_sarGetFovy(IntPtr self);
#endif

	// // RVA: 0x12F4290 Offset: 0x12F4290 VA: 0x12F4290
#if UNITY_EDITOR
    private static Matrix44 sarSmartar_SarSmartARController_sarGetInitPointMatrix(IntPtr self)
    {
        return new Matrix44();
    }
#else
    [DllImport("smartar")]
	public static extern Matrix44 sarSmartar_SarSmartARController_sarGetInitPointMatrix(IntPtr self);
#endif

	// // RVA: 0x12F40F0 Offset: 0x12F40F0 VA: 0x12F40F0
#if UNITY_EDITOR
    private static void sarSmartar_SarSmartARController_sarAdjustPose(IntPtr self, ref smartar.Vector3 fromPosition, ref smartar.Quaternion fromRotation, out smartar.Vector3 toPosition, out smartar.Quaternion toRotation)
    {
        toPosition = new smartar.Vector3();
        toRotation = new smartar.Quaternion();
    }
#else
    [DllImport("smartar")]
	public static extern void sarSmartar_SarSmartARController_sarAdjustPose(IntPtr self, ref smartar.Vector3 fromPosition, ref smartar.Quaternion fromRotation, out smartar.Vector3 toPosition, out smartar.Quaternion toRotation);
#endif

	// // RVA: 0x12F53B8 Offset: 0x12F53B8 VA: 0x12F53B8
#if UNITY_EDITOR
    private static void sarSmartar_SarSmartARController_sarRunWorkerThread(IntPtr self)
    {
    }
#else
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarRunWorkerThread(IntPtr self);
#endif

	// // RVA: 0x12F2330 Offset: 0x12F2330 VA: 0x12F2330
#if UNITY_EDITOR
    private static void sarSmartar_SarSmartARController_sarFinishWorkerThread(IntPtr self)
    {
    }
#else
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarFinishWorkerThread(IntPtr self);
#endif

	// // RVA: 0x12F0888 Offset: 0x12F0888 VA: 0x12F0888
#if UNITY_EDITOR
    static ulong camFrameCount = 0;
    private static ulong sarSmartar_SarSmartARController_sarGetCameraFrameCount(IntPtr self)
    {
        return camFrameCount++;
    }
#else
    [DllImport("smartar")]
	private static extern ulong sarSmartar_SarSmartARController_sarGetCameraFrameCount(IntPtr self);
#endif

	// // RVA: 0x12F0A68 Offset: 0x12F0A68 VA: 0x12F0A68
	// private static extern ulong sarSmartar_SarSmartARController_sarGetRecogCount(IntPtr self, int index) { }

	// // RVA: 0x12F0C50 Offset: 0x12F0C50 VA: 0x12F0C50
	// private static extern ulong sarSmartar_SarSmartARController_sarGetRecogTime(IntPtr self, int index) { }

	// // RVA: 0x12F06F0 Offset: 0x12F06F0 VA: 0x12F06F0
	// private static extern void sarSmartar_SarSmartARController_sarSetTriangulateMasks(IntPtr self, Triangle2[] masks, int numMasks) { }

	// // RVA: 0x12F4EC8 Offset: 0x12F4EC8 VA: 0x12F4EC8
	// private static extern void sarSmartar_SarSmartARController_sarGetImage(IntPtr self, IntPtr image, out ulong timestamp) { }

	// // RVA: 0x12F3618 Offset: 0x12F3618 VA: 0x12F3618
#if UNITY_EDITOR
    private static IntPtr GetRenderEventFunc()
    {
        return IntPtr.Zero;
    }
#else
    [DllImport("smartar")]
	private static extern IntPtr GetRenderEventFunc();
#endif

	// // RVA: 0x12F4390 Offset: 0x12F4390 VA: 0x12F4390
#if UNITY_EDITOR
    private static int sarSmartar_SarSmartARController_sarSetDrawData(int width, int height, bool showCameraImage)
    {
        return 0;
    }
#else
    [DllImport("smartar")]
	private static extern int sarSmartar_SarSmartARController_sarSetDrawData(int width, int height, bool showCameraImage);
#endif

	// // RVA: 0x12F4490 Offset: 0x12F4490 VA: 0x12F4490
#if UNITY_EDITOR
    private static void sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawLandmarkData(IntPtr self, IntPtr landmark_self, ref Matrix44 pmvMatrix, IntPtr landmarks, int numLandmarks)
    {
    }
#else
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawLandmarkData(IntPtr self, IntPtr landmark_self, ref Matrix44 pmvMatrix, IntPtr landmarks, int numLandmarks);
#endif

	// // RVA: 0x12F4580 Offset: 0x12F4580 VA: 0x12F4580
#if UNITY_EDITOR
    private static void sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawNodePointData(IntPtr self, IntPtr landmark_self, ref Matrix44 pmvMatrix, IntPtr nodePoints, int numNodePoints)
    {
    }
#else
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawNodePointData(IntPtr self, IntPtr landmark_self, ref Matrix44 pmvMatrix, IntPtr nodePoints, int numNodePoints);
#endif

	// // RVA: 0x12F4670 Offset: 0x12F4670 VA: 0x12F4670
#if UNITY_EDITOR
    private static void sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawInitPointData(IntPtr self, IntPtr landmark_self, ref Matrix44 imageMatrix, IntPtr initPoints, int numInitPoints)
    {
    }
#else
    [DllImport("smartar")]
	private static extern void sarSmartar_SarSmartARController_sarSetLandmarkDrawerDrawInitPointData(IntPtr self, IntPtr landmark_self, ref Matrix44 imageMatrix, IntPtr initPoints, int numInitPoints);
#endif

	// // RVA: 0x12F3408 Offset: 0x12F3408 VA: 0x12F3408
	// private static extern void sarSmartar_SarSmartARController_sarChangeRecognitionMode(IntPtr self, ref SmartARControllerBase.CreateParam param, bool workerThreadEnabled, bool isPreviewOnly) { }

	// [CompilerGeneratedAttribute] // RVA: 0x5DD17C Offset: 0x5DD17C VA: 0x5DD17C
	// // RVA: 0x12F56E0 Offset: 0x12F56E0 VA: 0x12F56E0
	// private void <reCreateRecognizer>b__59_0() { }
}
