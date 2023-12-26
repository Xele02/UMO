
using System;
using System.Runtime.InteropServices;
using smartar;
using UnityEngine;

public abstract class InitPointEffectorBase : MonoBehaviour
{
    private struct initPointPos
    {
        public uint id_; // 0x0
        public UnityEngine.Vector2 adjustedScreenPos_; // 0x4
    }

	public Texture image; // 0xC
	public bool showInitPoint; // 0x10
	public bool showInitPointId; // 0x11
	private IntPtr initPointBuffer_ = IntPtr.Zero; // 0x14
	private RecognitionResult result_; // 0x18
	private GUIStyle style_; // 0x90
	private GUIStyleState styleState_; // 0x94
	private initPointPos[] initPointIDs_ = new initPointPos[Recognizer.MAX_NUM_INITIALIZATION_POINTS]; // 0x98

	// RVA: 0x151F214 Offset: 0x151F214 VA: 0x151F214
	private void Awake() { }

	// RVA: 0x151E0D4 Offset: 0x151E0D4 VA: 0x151E0D4 Slot: 4
	protected virtual void Start() { }

	// RVA: 0x151E240 Offset: 0x151E240 VA: 0x151E240 Slot: 5
	protected virtual void OnGUI() { }

	// // RVA: -1 Offset: -1 Slot: 6
	protected abstract void GetResult(ref RecognitionResult result);

	// // RVA: -1 Offset: -1 Slot: 7
	protected abstract UnityEngine.Vector2 GetVideoSize();

	// // RVA: -1 Offset: -1 Slot: 8
	protected abstract bool UseFrontCamera();

	// // RVA: -1 Offset: -1 Slot: 9
	protected abstract Rotation GetImageSensorRotation();

	// RVA: 0x151E6C0 Offset: 0x151E6C0 VA: 0x151E6C0 Slot: 10
	protected virtual void Update()
    {
        if(showInitPoint || showInitPointId)
        {
            GetResult(ref result_);
            if(result_.initPoints_ != IntPtr.Zero && result_.numInitPoints_ > 0)
            {
                IntPtr p = result_.initPoints_;
                for(int i = 0; i < result_.numInitPoints_; i++)
                {
                    InitPoint ip = (InitPoint)Marshal.PtrToStructure(p, typeof(InitPoint));
                    UnityEngine.Vector2 v1 = GetVideoSize();
                    UnityEngine.Vector2 v2;
                    if(Screen.width < Screen.height)
                    {
                        v2 = new UnityEngine.Vector2(Screen.height, Screen.width);
                    }
                    else
                    {
                        v2 = new UnityEngine.Vector2(Screen.width, Screen.height);
                    }
                    float f = v2.x / v1.x;
                    initPointIDs_[i].adjustedScreenPos_.x = f * ip.position_.x_;
                    initPointIDs_[i].adjustedScreenPos_.y = f * ip.position_.y_ - (f * v1.y - v2.y) * 0.5f;
                    if(UseFrontCamera())
                    {
                        initPointIDs_[i].adjustedScreenPos_.x = v2.x - initPointIDs_[i].adjustedScreenPos_.x;
                        if(GetImageSensorRotation() == Rotation.ROTATION_90)
                        {
                            initPointIDs_[i].adjustedScreenPos_.x = v2.x - initPointIDs_[i].adjustedScreenPos_.x;
                            initPointIDs_[i].adjustedScreenPos_.y = v2.y - initPointIDs_[i].adjustedScreenPos_.y;
                        }
                    }
                    if(Screen.orientation == ScreenOrientation.LandscapeRight)
                    {
                        initPointIDs_[i].adjustedScreenPos_.x = v2.x - initPointIDs_[i].adjustedScreenPos_.x;
                        initPointIDs_[i].adjustedScreenPos_.y = v2.y - initPointIDs_[i].adjustedScreenPos_.y;
                    }
                    else if(Screen.orientation == ScreenOrientation.PortraitUpsideDown)
                    {
                        float f2 = initPointIDs_[i].adjustedScreenPos_.x;
                        initPointIDs_[i].adjustedScreenPos_.x = v2.y - initPointIDs_[i].adjustedScreenPos_.y;
                        initPointIDs_[i].adjustedScreenPos_.y = f2;
                    }
                    else if(Screen.orientation == ScreenOrientation.Portrait)
                    {
                        float f2 = initPointIDs_[i].adjustedScreenPos_.x;
                        initPointIDs_[i].adjustedScreenPos_.x = initPointIDs_[i].adjustedScreenPos_.y;
                        initPointIDs_[i].adjustedScreenPos_.y = v2.x - f2;
                    }
                    p += Marshal.SizeOf(ip);
                }
            }
        }
    }
}
