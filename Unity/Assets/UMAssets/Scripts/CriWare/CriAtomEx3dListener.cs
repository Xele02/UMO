public class CriAtomEx3dListener : CriDisposable
{
	// private IntPtr handle; // 0x18

	// public IntPtr nativeHandle { get; }

	// // RVA: 0x2884CEC Offset: 0x2884CEC VA: 0x2884CEC
	// public void .ctor() { }

	// // RVA: 0x2884E94 Offset: 0x2884E94 VA: 0x2884E94 Slot: 5
	public override void Dispose()
    {
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0x2884E9C Offset: 0x2884E9C VA: 0x2884E9C
	// private void Dispose(bool disposing) { }

	// // RVA: 0x288506C Offset: 0x288506C VA: 0x288506C
	// public IntPtr get_nativeHandle() { }

	// // RVA: 0x2885074 Offset: 0x2885074 VA: 0x2885074
	// public void Update() { }

	// // RVA: 0x28851BC Offset: 0x28851BC VA: 0x28851BC
	// public void ResetParameters() { }

	// // RVA: 0x288530C Offset: 0x288530C VA: 0x288530C
	// public void SetPosition(float x, float y, float z) { }

	// // RVA: 0x28854A0 Offset: 0x28854A0 VA: 0x28854A0
	// public void SetVelocity(float x, float y, float z) { }

	// // RVA: 0x2885638 Offset: 0x2885638 VA: 0x2885638
	// public void SetOrientation(float fx, float fy, float fz, float ux, float uy, float uz) { }

	// [ObsoleteAttribute] // RVA: 0x635D90 Offset: 0x635D90 VA: 0x635D90
	// // RVA: 0x2885804 Offset: 0x2885804 VA: 0x2885804
	// public void SetDistanceFactor(float distanceFactor) { }

	// // RVA: 0x28859E4 Offset: 0x28859E4 VA: 0x28859E4
	// public void SetDopplerMultiplier(float dopplerMultiplier) { }

	// // RVA: 0x2885AB0 Offset: 0x2885AB0 VA: 0x2885AB0
	// public void SetFocusPoint(float x, float y, float z) { }

	// // RVA: 0x2885C4C Offset: 0x2885C4C VA: 0x2885C4C
	// public void SetDistanceFocusLevel(float distanceFocusLevel) { }

	// // RVA: 0x2885DB4 Offset: 0x2885DB4 VA: 0x2885DB4
	// public void SetDirectionFocusLevel(float directionFocusLevel) { }

	// // RVA: 0x2885F1C Offset: 0x2885F1C VA: 0x2885F1C
	// public void Set3dRegion(CriAtomEx3dRegion region3d) { }

	// // RVA: 0x2886094 Offset: 0x2886094 VA: 0x2886094 Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0x2884DA8 Offset: 0x2884DA8 VA: 0x2884DA8
	// private static extern IntPtr criAtomEx3dListener_Create(ref CriAtomEx3dListener.Config config, IntPtr work, int work_size) { }

	// // RVA: 0x2884F90 Offset: 0x2884F90 VA: 0x2884F90
	// private static extern void criAtomEx3dListener_Destroy(IntPtr ex_3d_listener) { }

	// // RVA: 0x28850E0 Offset: 0x28850E0 VA: 0x28850E0
	// private static extern void criAtomEx3dListener_Update(IntPtr ex_3d_listener) { }

	// // RVA: 0x2885228 Offset: 0x2885228 VA: 0x2885228
	// private static extern void criAtomEx3dListener_ResetParameters(IntPtr ex_3d_listener) { }

	// // RVA: 0x28853B8 Offset: 0x28853B8 VA: 0x28853B8
	// private static extern void criAtomEx3dListener_SetPosition(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector position) { }

	// // RVA: 0x2885550 Offset: 0x2885550 VA: 0x2885550
	// private static extern void criAtomEx3dListener_SetVelocity(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector velocity) { }

	// // RVA: 0x2885710 Offset: 0x2885710 VA: 0x2885710
	// private static extern void criAtomEx3dListener_SetOrientation(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector front, ref CriAtomEx.NativeVector top) { }

	// // RVA: 0x2886100 Offset: 0x2886100 VA: 0x2886100
	// private static extern void criAtomEx3dListener_SetDistanceFactor(IntPtr ex_3d_listener, float distance_factor) { }

	// // RVA: 0x28858F0 Offset: 0x28858F0 VA: 0x28858F0
	// private static extern void criAtomEx3dListener_SetDopplerMultiplier(IntPtr ex_3d_listener, float doppler_multiplier) { }

	// // RVA: 0x2885B60 Offset: 0x2885B60 VA: 0x2885B60
	// private static extern void criAtomEx3dListener_SetFocusPoint(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector focus_point) { }

	// // RVA: 0x2885CC0 Offset: 0x2885CC0 VA: 0x2885CC0
	// private static extern void criAtomEx3dListener_SetDistanceFocusLevel(IntPtr ex_3d_listener, float distance_focus_level) { }

	// // RVA: 0x2885E28 Offset: 0x2885E28 VA: 0x2885E28
	// private static extern void criAtomEx3dListener_SetDirectionFocusLevel(IntPtr ex_3d_listener, float direction_focus_level) { }

	// // RVA: 0x2885FA8 Offset: 0x2885FA8 VA: 0x2885FA8
	// private static extern void criAtomEx3dListener_Set3dRegionHn(IntPtr ex_3d_listener, IntPtr ex_3d_region) { }
}
