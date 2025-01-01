
using smartar;
using UnityEngine;

public class InitPointEffector : InitPointEffectorBase
{
	private SmartARController smartARController_; // 0x9C
	private SmartAREffector smartAREffector_; // 0xA0
	private TargetEffector targetEffector_; // 0xA4

	// // RVA: 0x151DD04 Offset: 0x151DD04 VA: 0x151DD04
	private void DoEnable()
    {
        if(smartARController_ == null)
        {
            SmartARController[] sar = (SmartARController[])FindObjectsOfType(typeof(SmartARController));
            if(sar != null && sar.Length != 0)
                smartARController_ = sar[0];
            if(smartAREffector_ == null)
            {
                SmartAREffector[] sar2 = (SmartAREffector[])FindObjectsOfType(typeof(SmartAREffector));
                if(sar2 != null && sar2.Length != 0)
                    smartAREffector_ = sar2[0];
                if(targetEffector_ == null)
                {
                    TargetEffector[] tar = (TargetEffector[])FindObjectsOfType(typeof(TargetEffector));
                    if(tar != null && tar.Length != 0)
                        targetEffector_ = tar[0];
                }
            }
        }
    }

	// RVA: 0x151E0B8 Offset: 0x151E0B8 VA: 0x151E0B8 Slot: 4
	protected override void Start()
    {
        DoEnable();
        base.Start();
    }

	// RVA: 0x151E224 Offset: 0x151E224 VA: 0x151E224 Slot: 5
	protected override void OnGUI()
    {
        DoEnable();
        base.OnGUI();
    }

	// RVA: 0x151E57C Offset: 0x151E57C VA: 0x151E57C
	public void UpdateContents()
    {
        if(smartARController_ != null)
        {
            if(smartAREffector_ != null)
            {
                if(!smartARController_.enabled_)
                    return;
                if(!smartARController_.smart_.isConstructorFailed())
                {
                    base.Update();
                }
            }
        }
    }

	// RVA: 0x151F014 Offset: 0x151F014 VA: 0x151F014 Slot: 10
	protected override void Update() 
    {
        return;
    }

	// RVA: 0x151F018 Offset: 0x151F018 VA: 0x151F018 Slot: 6
	protected override void GetResult(ref RecognitionResult result)
    {
        result = targetEffector_.result_;
    }

	// RVA: 0x151F04C Offset: 0x151F04C VA: 0x151F04C Slot: 7
	protected override UnityEngine.Vector2 GetVideoSize()
    { 
        return smartARController_.cameraDeviceSettings_.videoImageSize;
    }

	// RVA: 0x151F09C Offset: 0x151F09C VA: 0x151F09C Slot: 8
	protected override bool UseFrontCamera()
    {
        Facing f;
        smartARController_.cameraDevice_.GetFacing(out f);
        return f == Facing.FACING_FRONT;
    }

	// RVA: 0x151F0FC Offset: 0x151F0FC VA: 0x151F0FC Slot: 9
	protected override Rotation GetImageSensorRotation()
    {
        Rotation r = Rotation.ROTATION_0;
#if UNITY_ANDROID && !UNITY_EDITOR
        smartARController_.cameraDevice_.GetImageSensorRotation(out r);
#endif
        return r;
    }
}
