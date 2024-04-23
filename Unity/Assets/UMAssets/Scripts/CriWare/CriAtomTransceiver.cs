using UnityEngine;

namespace CriWare
{
	// [AddComponentMenu] // RVA: 0x6327DC Offset: 0x6327DC VA: 0x6327DC
	// [DisallowMultipleComponent] // RVA: 0x6327DC Offset: 0x6327DC VA: 0x6327DC
	public class CriAtomTransceiver : CriMonoBehaviour
	{
		[SerializeField] // RVA: 0x6347EC Offset: 0x6347EC VA: 0x6347EC
		private CriAtomRegion regionOnStart; // 0x44
		[SerializeField] // RVA: 0x6347FC Offset: 0x6347FC VA: 0x6347FC
		private bool useDedicatedInput; // 0x48
		[SerializeField] // RVA: 0x63480C Offset: 0x63480C VA: 0x63480C
		private GameObject dedicatedInput; // 0x4C
		[SerializeField] // RVA: 0x63481C Offset: 0x63481C VA: 0x63481C
		// [RangeAttribute] // RVA: 0x63481C Offset: 0x63481C VA: 0x63481C
		private float outputVolume; // 0x50
		[SerializeField] // RVA: 0x634854 Offset: 0x634854 VA: 0x634854
		private float directAudioRadius; // 0x54
		[SerializeField] // RVA: 0x634864 Offset: 0x634864 VA: 0x634864
		private float crossFadeDistance; // 0x58
		[SerializeField] // RVA: 0x634874 Offset: 0x634874 VA: 0x634874
		// [RangeAttribute] // RVA: 0x634874 Offset: 0x634874 VA: 0x634874
		private float coneInsideAngle; // 0x5C
		[SerializeField] // RVA: 0x6348B0 Offset: 0x6348B0 VA: 0x6348B0
		// [RangeAttribute] // RVA: 0x6348B0 Offset: 0x6348B0 VA: 0x6348B0
		private float coneOutsideAngle; // 0x60
		[SerializeField] // RVA: 0x6348EC Offset: 0x6348EC VA: 0x6348EC
		// [RangeAttribute] // RVA: 0x6348EC Offset: 0x6348EC VA: 0x6348EC
		private float coneOutsideVolume; // 0x64
		[SerializeField] // RVA: 0x634924 Offset: 0x634924 VA: 0x634924
		private float transceiverRadius; // 0x68
		[SerializeField] // RVA: 0x634934 Offset: 0x634934 VA: 0x634934
		private float interiorDistance; // 0x6C
		[SerializeField] // RVA: 0x634944 Offset: 0x634944 VA: 0x634944
		public float minAttenuation; // 0x70
		[SerializeField] // RVA: 0x634954 Offset: 0x634954 VA: 0x634954
		public float maxAttenuation; // 0x74
		[SerializeField] // RVA: 0x634964 Offset: 0x634964 VA: 0x634964
		private string globalAisacName; // 0x78
		[SerializeField] // RVA: 0x634974 Offset: 0x634974 VA: 0x634974
		private float maxAngleAisacDelta; // 0x7C
		[SerializeField] // RVA: 0x634984 Offset: 0x634984 VA: 0x634984
		private string distanceAisacControlId; // 0x80
		[SerializeField] // RVA: 0x634994 Offset: 0x634994 VA: 0x634994
		private string listenerAzimuthAisacControlId; // 0x84
		[SerializeField] // RVA: 0x6349A4 Offset: 0x6349A4 VA: 0x6349A4
		private string listenerElevationAisacControlId; // 0x88
		[SerializeField] // RVA: 0x6349B4 Offset: 0x6349B4 VA: 0x6349B4
		private string outputAzimuthAisacControlId; // 0x8C
		[SerializeField] // RVA: 0x6349C4 Offset: 0x6349C4 VA: 0x6349C4
		private string outputElevationAisacControlId; // 0x90
		// public bool inspectorAisacSettingFoldout; // 0x94
		// private bool isInitialized; // 0x95
		// private bool dedicatedInputNotSetWarned; // 0x96
		// private CriAtomRegion currentRegion; // 0x98

		// public CriAtomEx3dTransceiver transceiverHn { get; protected set; } // 0x1C
		// public Vector3 inputPos { get; private set; } // 0x20
		// public Vector3 inputFront { get; private set; } // 0x2C
		// public Vector3 inputUp { get; private set; } // 0x38
		// public CriAtomRegion region3d { get; set; } 0x28B6FE0 0x28B6FE8

		// // RVA: 0x28B711C Offset: 0x28B711C VA: 0x28B711C
		private void Awake()
		{
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "TODO");
		}

		// // RVA: 0x28B712C Offset: 0x28B712C VA: 0x28B712C
		private void Start()
		{
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "TODO");
		}

		// // RVA: 0x28B71CC Offset: 0x28B71CC VA: 0x28B71CC Slot: 4
		protected override void OnEnable()
		{
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "TODO");
		}

		// // RVA: 0x28B71F8 Offset: 0x28B71F8 VA: 0x28B71F8
		private void OnDestroy()
		{
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "TODO");
		}

		// // RVA: 0x28B7208 Offset: 0x28B7208 VA: 0x28B7208 Slot: 8
		// protected virtual void InternalInitialize() { }

		// // RVA: 0x28B72B0 Offset: 0x28B72B0 VA: 0x28B72B0 Slot: 9
		// protected virtual void InternalFinalize() { }

		// // RVA: 0x28B7360 Offset: 0x28B7360 VA: 0x28B7360 Slot: 10
		// protected virtual void InitializeParameters() { }

		// // RVA: 0x28B7BE8 Offset: 0x28B7BE8 VA: 0x28B7BE8 Slot: 6
		public override void CriInternalUpdate()
		{
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "TODO");
		}

		// // RVA: 0x28B7BEC Offset: 0x28B7BEC VA: 0x28B7BEC Slot: 7
		public override void CriInternalLateUpdate()
		{
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "TODO");
		}

		// // RVA: 0x28B7414 Offset: 0x28B7414 VA: 0x28B7414
		// private void ApplyCurrentPosition() { }

		// // RVA: 0x28B78C4 Offset: 0x28B78C4 VA: 0x28B78C4
		// private void ApplyParameters() { }

		// // RVA: 0x28B7C04 Offset: 0x28B7C04 VA: 0x28B7C04
		// private void TrySetAisacControlId(string strId, CriAtomTransceiver.SetControlIdMethod callback) { }

		// // RVA: 0x28B81C0 Offset: 0x28B81C0 VA: 0x28B81C0
		public CriAtomTransceiver()
		{
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "TODO");
		}
	}
}
