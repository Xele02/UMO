using UnityEngine;

public class CriAtomTransceiver : CriMonoBehaviour
{
	[SerializeField]
	private CriAtomRegion regionOnStart;
	[SerializeField]
	private bool useDedicatedInput;
	[SerializeField]
	private GameObject dedicatedInput;
	[SerializeField]
	private float outputVolume;
	[SerializeField]
	private float directAudioRadius;
	[SerializeField]
	private float crossFadeDistance;
	[SerializeField]
	private float coneInsideAngle;
	[SerializeField]
	private float coneOutsideAngle;
	[SerializeField]
	private float coneOutsideVolume;
	[SerializeField]
	private float transceiverRadius;
	[SerializeField]
	private float interiorDistance;
	[SerializeField]
	public float minAttenuation;
	[SerializeField]
	public float maxAttenuation;
	[SerializeField]
	private string globalAisacName;
	[SerializeField]
	private float maxAngleAisacDelta;
	[SerializeField]
	private string distanceAisacControlId;
	[SerializeField]
	private string listenerAzimuthAisacControlId;
	[SerializeField]
	private string listenerElevationAisacControlId;
	[SerializeField]
	private string outputAzimuthAisacControlId;
	[SerializeField]
	private string outputElevationAisacControlId;
}
