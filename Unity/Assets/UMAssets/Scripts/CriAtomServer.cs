using System;

public class CriAtomServer : CriMonoBehaviour
{
	private static CriAtomServer _instance; // 0x0
	public Action<bool> onApplicationPausePreProcess; // 0x1C
	public Action<bool> onApplicationPausePostProcess; // 0x20
	public static bool KeepPlayingSoundOnPause; // 0x4

	public static CriAtomServer instance { get; }

	// // RVA: 0x28B5140 Offset: 0x28B5140 VA: 0x28B5140
	// public static CriAtomServer get_instance() { }

	// // RVA: 0x28B3254 Offset: 0x28B3254 VA: 0x28B3254
	// public static void CreateInstance() { }

	// // RVA: 0x28B3484 Offset: 0x28B3484 VA: 0x28B3484
	// public static void DestroyInstance() { }

	// // RVA: 0x28B51D0 Offset: 0x28B51D0 VA: 0x28B51D0
	// private void Awake() { }

	// // RVA: 0x28B5324 Offset: 0x28B5324 VA: 0x28B5324 Slot: 4
	// protected override void OnEnable() { }

	// // RVA: 0x28B532C Offset: 0x28B532C VA: 0x28B532C Slot: 5
	// protected override void OnDisable() { }

	// // RVA: 0x28B5454 Offset: 0x28B5454 VA: 0x28B5454 Slot: 6
	// public override void CriInternalUpdate() { }

	// // RVA: 0x28B5458 Offset: 0x28B5458 VA: 0x28B5458 Slot: 7
	// public override void CriInternalLateUpdate() { }

	// // RVA: 0x28B545C Offset: 0x28B545C VA: 0x28B545C
	// private void OnApplicationPause(bool appPause) { }

	// // RVA: 0x28B5460 Offset: 0x28B5460 VA: 0x28B5460
	// private void ProcessApplicationPause(bool appPause) { }

	// // RVA: 0x28B552C Offset: 0x28B552C VA: 0x28B552C
	// public void .ctor() { }

	// // RVA: 0x28B5534 Offset: 0x28B5534 VA: 0x28B5534
	// private static void .cctor() { }
}
