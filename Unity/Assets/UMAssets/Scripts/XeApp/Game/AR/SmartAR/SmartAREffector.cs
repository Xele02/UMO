
using smartar;
using UnityEngine;

public class SmartAREffector : SmartAREffectorBase
{
	[HideInInspector]
	public SmartARController smartARController_; // 0x14
	private TargetEffector[] targetEffectors_; // 0x18

	// RVA: 0x12F9108 Offset: 0x12F9108 VA: 0x12F9108
	public void SetTargetEffectors(TargetEffector[] effectors)
	{
		targetEffectors_ = effectors;
	}

	// // RVA: 0x12F9110 Offset: 0x12F9110 VA: 0x12F9110
	public void RecreateTargetEffector()
	{
		targetEffectors_ = FindObjectsOfType<TargetEffector>();
	}

	// RVA: 0x12F91A0 Offset: 0x12F91A0 VA: 0x12F91A0 Slot: 4
	protected override void Awake()
	{
		smartARController_ = FindObjectOfType<SmartARController>();
		RecreateTargetEffector();
		base.Awake();
	}

	// RVA: 0x12F9270 Offset: 0x12F9270 VA: 0x12F9270 Slot: 6
	protected override void Update()
	{
		if(smartARController_ != null)
		{
			if(smartARController_.enabled_)
			{
				if(!smartARController_.smart_.isConstructorFailed() && targetEffectors_ != null)
				{
					for(int i = 0; i < targetEffectors_.Length; i++)
					{
						if(targetEffectors_[i] != null)
						{
							smartARController_.GetResult(targetEffectors_[i].targetID, ref targetEffectors_[i].result_);
							if(!targetEffectors_[i].result_.isRecognized_)
							{
								if(IsLastRecognizedGameObject(targetEffectors_[i].gameObject))
								{
									ClearLastRecognized();
								}
							}
							else
							{
								if(lastRecognizedObject_ != null && !IsLastRecognizedGameObject(targetEffectors_[i].gameObject))
								{
									GameObject g = new GameObject();
									setPose(g.transform, targetEffectors_[i].result_);
									g.transform.rotation = lastRecognizedTransform_.rotation * UnityEngine.Quaternion.Inverse(g.transform.rotation);
									g.transform.position = g.transform.rotation * g.transform.position;
									targetEffectors_[i].transform.position = lastRecognizedTransform_.transform.position - g.transform.position;
									targetEffectors_[i].transform.rotation = g.transform.rotation;
									Destroy(g);
								}
								else
								{
									targetEffectors_[i].transform.position = UnityEngine.Vector3.zero;
									targetEffectors_[i].transform.rotation = UnityEngine.Quaternion.identity;
									setPose(smartARController_.transform, targetEffectors_[i].result_);
									lastRecognizedTransform_ = smartARController_.transform;
									lastRecognizedObject_ = targetEffectors_[i].gameObject;
								}
								targetEffectors_[i].UpdateContents();
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0x12FA648 Offset: 0x12FA648 VA: 0x12FA648 Slot: 5
	protected override void callAdjustPose(smartar.Vector3 srcPosition, smartar.Quaternion srcRotation, out smartar.Vector3 rotPosition, out smartar.Quaternion rotRotation)
	{
		SmartARController.adjustPose(GetCameraRotation(), GetScreenRotation(), IsFlipX(), IsFlipY(), srcPosition, srcRotation, out rotPosition, out rotRotation);
	}

	// // RVA: 0x12FA708 Offset: 0x12FA708 VA: 0x12FA708 Slot: 7
	public override Rotation GetCameraRotation() 
	{
		Rotation r = Rotation.ROTATION_0;
		if(smartARController_ != null)
		{
			smartARController_.cameraDevice_.GetRotation(out r);
			Facing f;
			smartARController_.cameraDevice_.GetFacing(out f);
			if(f == Facing.FACING_FRONT)
			{
				Rotation r2;
				smartARController_.cameraDevice_.GetImageSensorRotation(out r2);
				if(r2 == Rotation.ROTATION_90)
				{
					r = (Rotation)(((int)r + 180) % 360);
				}
			}
		}
		return r;
	}

	// // RVA: 0x12FA8B0 Offset: 0x12FA8B0 VA: 0x12FA8B0 Slot: 8
	public override Rotation GetScreenRotation()
	{
		Rotation r = Rotation.ROTATION_0;
		smartARController_.screenDevice_.GetRotation(out r);
		return r;
	}

	// // RVA: 0x12FA908 Offset: 0x12FA908 VA: 0x12FA908 Slot: 9
	public override Rotation GetImageSensorRotation()
	{
		if(smartARController_ != null)
		{
			Rotation r;
			smartARController_.cameraDevice_.GetImageSensorRotation(out r);
			return r;
		}
		return Rotation.ROTATION_0;
	}

	// // RVA: 0x12FA9F4 Offset: 0x12FA9F4 VA: 0x12FA9F4 Slot: 10
	public override bool IsFlipX()
	{
		return smartARController_ != null && smartARController_.isFlipX_;
	}

	// // RVA: 0x12FAAB0 Offset: 0x12FAAB0 VA: 0x12FAAB0 Slot: 11
	public override bool IsFlipY()
	{
		return smartARController_ != null && smartARController_.isFlipY_;
	}

	// // RVA: 0x12FAB6C Offset: 0x12FAB6C VA: 0x12FAB6C Slot: 12
	public override bool UseFrontCamera()
	{
		if(smartARController_ != null)
		{
			Facing f;
			smartARController_.cameraDevice_.GetFacing(out f);
			return f == Facing.FACING_FRONT;
		}
		return false;
	}
}
