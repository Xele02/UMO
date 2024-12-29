
using smartar;
using UnityEngine;

public class LandmarkEffector : LandmarkEffectorBase
{
	private SmartARController smartARController_; // 0xA0
	private SmartAREffector smartAREffector_; // 0xA4
	private TargetEffector targetEffector_; // 0xA8

	// // RVA: 0xB48888 Offset: 0xB48888 VA: 0xB48888
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
                    targetEffector_ = transform.GetComponentInParent<TargetEffector>();
                    if(targetEffector_ == null)
                    {
                        TargetEffector[] sar3 = (TargetEffector[])FindObjectsOfType(typeof(TargetEffector));
                        if(sar3 != null && sar3.Length != 0)
                            targetEffector_ = sar3[0];
                    }
                }
            }
        }
    }

	// RVA: 0xB48C3C Offset: 0xB48C3C VA: 0xB48C3C Slot: 4
	protected override void Start()
    {
        DoEnable();
        base.Start();
    }

	// RVA: 0xB48D10 Offset: 0xB48D10 VA: 0xB48D10 Slot: 5
	protected override void OnGUI()
    {
        DoEnable();
    }

	// RVA: 0xB48D18 Offset: 0xB48D18 VA: 0xB48D18
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

	// RVA: 0xB4A028 Offset: 0xB4A028 VA: 0xB4A028 Slot: 12
	protected override void Update() 
    {
        return;
    }

	// // RVA: 0xB4A02C Offset: 0xB4A02C VA: 0xB4A02C Slot: 6
	protected override void GetResult(ref RecognitionResult result)
    {
        result = targetEffector_.result_;
    }

	// // RVA: 0xB4A060 Offset: 0xB4A060 VA: 0xB4A060 Slot: 7
	protected override Rotation GetScreenRotation()
    {
        return smartAREffector_.GetScreenRotation();
    }

	// // RVA: 0xB4A094 Offset: 0xB4A094 VA: 0xB4A094 Slot: 9
	protected override bool IsFlipX()
    {
        return smartARController_.isFlipX_;
    }

	// // RVA: 0xB4A0B8 Offset: 0xB4A0B8 VA: 0xB4A0B8 Slot: 10
	protected override bool IsFlipY()
    {
        return smartARController_.isFlipY_;
    }

	// // RVA: 0xB4A0DC Offset: 0xB4A0DC VA: 0xB4A0DC Slot: 8
	protected override Rotation GetCameraRotation()
    {
        return smartARController_.cameraRotation_;
    }

	// // RVA: 0xB4A100 Offset: 0xB4A100 VA: 0xB4A100 Slot: 11
	protected override void SetPose(Transform transformObject, RecognitionResult result, smartar.Vector3 rotPosition)
    {
        Transform t = SmartAREffectorBase.GetLastRecognizedTransform();
        if(t != null)
        {
            if(SmartAREffectorBase.IsLastRecognizedGameObject(targetEffector_.gameObject))
            {
                smartAREffector_.setPose(transformObject, result, rotPosition);
                transformObject.position = transformObject.position - t.position;
            }
            else
            {
                if(smartAREffector_.UseFrontCamera())
                {
                    smartAREffector_.GetImageSensorRotation();
                }
                GameObject g = new GameObject();
                smartar.Vector3 z = new smartar.Vector3();
                z.x_ = 0;
                z.y_ = 0;
                z.z_ = 0;
                smartAREffector_.setPose(g.transform, result, z);
                g.transform.rotation = t.rotation * UnityEngine.Quaternion.Inverse(g.transform.rotation);
                g.transform.position = g.transform.rotation * g.transform.position;
                transformObject.position = t.position - g.transform.position;
                transformObject.rotation = g.transform.rotation;
                Destroy(g);
            }
        }
    }
}
