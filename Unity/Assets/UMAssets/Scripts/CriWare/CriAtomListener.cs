using UnityEngine;

namespace CriWare
{

	// [AddComponentMenu] // RVA: 0x6326C4 Offset: 0x6326C4 VA: 0x6326C4
	public class CriAtomListener : CriMonoBehaviour
	{
		[SerializeField] // RVA: 0x63465C Offset: 0x63465C VA: 0x63465C
		private CriAtomRegion regionOnStart; // 0x20
		public bool activateListenerOnEnable; // 0x24
		// private static List<CriAtomListener> listenersList = new List<CriAtomListener>(); // 0x0
		private static CriAtomEx3dListener dummyNativeListener; // 0x4
		// private Vector3 lastPosition; // 0x28
		// private CriAtomRegion currentRegion; // 0x34
		// private bool _isActive = true; // 0x38

		public CriAtomEx3dListener nativeListener { get; protected set; } // 0x1C
		// public bool isActive { get; set; } 0x28AEA10 0x28AEA18
		// public CriAtomRegion region3d { get; set; } 0x28AED04 0x28AED0C

		// // RVA: 0x28AE7FC Offset: 0x28AE7FC VA: 0x28AE7FC
		public static void CreateDummyNativeListener()
		{
			if (dummyNativeListener == null) {
				dummyNativeListener = new CriAtomEx3dListener();
			}
		}

		// // RVA: 0x28AE8F4 Offset: 0x28AE8F4 VA: 0x28AE8F4
		public static void DestroyDummyNativeListener()
		{
			if (dummyNativeListener != null) {
				dummyNativeListener.Dispose();
				dummyNativeListener = null;
			}
		}

		// // RVA: 0x28AEE48 Offset: 0x28AEE48 VA: 0x28AEE48
		private void Awake()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x28AEFE8 Offset: 0x28AEFE8 VA: 0x28AEFE8
		private void Start()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x28AF088 Offset: 0x28AF088 VA: 0x28AF088 Slot: 4
		protected override void OnEnable()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x28AF2B8 Offset: 0x28AF2B8 VA: 0x28AF2B8 Slot: 5
		protected override void OnDisable()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x28AF2DC Offset: 0x28AF2DC VA: 0x28AF2DC
		private void OnDestroy()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x28AF440 Offset: 0x28AF440 VA: 0x28AF440 Slot: 6
		public override void CriInternalUpdate()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x28AF444 Offset: 0x28AF444 VA: 0x28AF444 Slot: 7
		public override void CriInternalLateUpdate()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x28AEAB8 Offset: 0x28AEAB8 VA: 0x28AEAB8
		// private void UpdatePosition() { }

		// // RVA: 0x28AF0AC Offset: 0x28AF0AC VA: 0x28AF0AC
		// public void ActivateListener(bool exclusive = True) { }
	}
}