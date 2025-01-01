
using smartar;
using UnityEngine;
using XeApp.Game.RhythmGame;

public abstract class SmartAREffectorBase : MonoBehaviour
{
	[HideInInspector]
	public float nearClipPlane_; // 0xC
	[SerializeField]
	protected float _transformScaleFactor = 100; // 0x10
	protected static Transform lastRecognizedTransform_; // 0x0
	protected static GameObject lastRecognizedObject_; // 0x4

	// // RVA: 0x12FACFC Offset: 0x12FACFC VA: 0x12FACFC
	public static Transform GetLastRecognizedTransform()
    {
        return lastRecognizedTransform_;
    }

	// // RVA: 0x12FA19C Offset: 0x12FA19C VA: 0x12FA19C
	public static void ClearLastRecognized()
    { 
        lastRecognizedTransform_ = null;
        lastRecognizedObject_ = null;
    }

	// // RVA: 0x12F9F88 Offset: 0x12F9F88 VA: 0x12F9F88
	public static bool IsLastRecognizedGameObject(GameObject gameObject)
    {
        if(lastRecognizedObject_ != null)
        {
            if(gameObject != null)
            {
                return lastRecognizedObject_.GetInstanceID() == gameObject.GetInstanceID();
            }
        }
        return false;
    }

	// RVA: 0x12F925C Offset: 0x12F925C VA: 0x12F925C Slot: 4
	protected virtual void Awake()
    {
        nearClipPlane_ = _transformScaleFactor * 20;
    }

	// // RVA: 0x12FA138 Offset: 0x12FA138 VA: 0x12FA138
	protected void setPose(Transform transformObject, RecognitionResult result)
    {
        smartar.Vector3 v = new smartar.Vector3();
        v.x_ = 0;
        v.y_ = 0;
        v.z_ = 0;
        setPose(transformObject, result, v);
    }

	// // RVA: 0x12FAD88 Offset: 0x12FAD88 VA: 0x12FAD88
	public void setPose(Transform transformObject, RecognitionResult result, smartar.Vector3 landmarkPos)
    {
        smartar.Vector3 rotP;
        smartar.Quaternion rotQ;
        callAdjustPose(result.position_, result.rotation_, out rotP, out rotQ);
        transformObject.rotation = UnityEngine.Quaternion.identity;
        transformObject.RotateAround(UnityEngine.Vector3.zero, UnityEngine.Vector3.right, -90);
        UnityEngine.Quaternion q = new UnityEngine.Quaternion(rotQ.x_, rotQ.z_, rotQ.y_, rotQ.w_);
        float a;
        UnityEngine.Vector3 a2;
        q.ToAngleAxis(out a, out a2);
        transformObject.RotateAround(UnityEngine.Vector3.zero, a2, a);
        transformObject.position = new UnityEngine.Vector3(rotP.x_ + landmarkPos.x_, rotP.z_ + landmarkPos.z_, rotP.y_ + landmarkPos.y_) * nearClipPlane_;
        ARDebugScreen.Instance.AddText(ARDebugScreen.TextType.EffectorTranform, 
            "setPose : rotP : "+rotP.x_+" "+rotP.y_+" "+rotP.z_+"\n"+
            "rotQ : "+rotQ.x_+" "+rotQ.y_+" "+rotQ.z_+" "+rotQ.w_+"\n"+
            "a2 : "+a2+"\n"+"a : "+a+"\n"+
            "pos : "+transformObject.position+"\n"+
            "rot : "+transformObject.rotation
        );
    }

	// // RVA: -1 Offset: -1 Slot: 5
	protected abstract void callAdjustPose(smartar.Vector3 srcPosition, smartar.Quaternion srcRotation, out smartar.Vector3 rotPosition, out smartar.Quaternion rotRotation);

	// RVA: -1 Offset: -1 Slot: 6
	protected abstract void Update();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract Rotation GetCameraRotation();

	// // RVA: -1 Offset: -1 Slot: 8
	public abstract Rotation GetScreenRotation();

	// // RVA: -1 Offset: -1 Slot: 9
	public abstract Rotation GetImageSensorRotation();

	// // RVA: -1 Offset: -1 Slot: 10
	public abstract bool IsFlipX();

	// // RVA: -1 Offset: -1 Slot: 11
	public abstract bool IsFlipY();

	// // RVA: -1 Offset: -1 Slot: 12
	public abstract bool UseFrontCamera();
}
