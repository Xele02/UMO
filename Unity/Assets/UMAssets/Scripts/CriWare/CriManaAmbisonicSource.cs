
namespace CriWare
{
	public class CriManaAmbisonicSource : CriMonoBehaviour
	{
		// private CriAtomEx3dSource atomEx3DsourceForAmbisonics; // 0x1C
		// private Vector3 ambisonicSourceOrientationFront; // 0x20
		// private Vector3 ambisonicSourceOrientationTop; // 0x2C
		// private Vector3 lastEulerOfAmbisonicSource; // 0x38

		// // RVA: 0x2961024 Offset: 0x2961024 VA: 0x2961024 Slot: 6
		public override void CriInternalUpdate()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x2961114 Offset: 0x2961114 VA: 0x2961114 Slot: 7
		public override void CriInternalLateUpdate()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x2961118 Offset: 0x2961118 VA: 0x2961118 Slot: 4
		protected override void OnEnable()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x2961308 Offset: 0x2961308 VA: 0x2961308
		// private void ForceUpdateAmbisonicSourceOrientation() { }

		// // RVA: 0x2961028 Offset: 0x2961028 VA: 0x2961028
		// private void UpdateAmbisonicSourceOrientation() { }

		// // RVA: 0x29613E0 Offset: 0x29613E0 VA: 0x29613E0
		// private void RoatateAmbisonicSourceOrientationByTransformOfChild(ref Vector3 input_euler) { }
	}
}