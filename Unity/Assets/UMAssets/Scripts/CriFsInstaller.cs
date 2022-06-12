using System;

public class CriFsInstaller : CriDisposable
{
    public enum Status
    {
        Stop = 0,
        Busy = 1,
        Complete = 2,
        Error = 3,
    }

    private enum CopyPolicy
    {
        Always = 0
    }

	private byte[] installBuffer; // 0x18
	// private GCHandle installBufferGch; // 0x1C
	private IntPtr handle; // 0x20

	// // RVA: 0x2946AC0 Offset: 0x2946AC0 VA: 0x2946AC0
	// public void .ctor() { }

	// // RVA: 0x29471D0 Offset: 0x29471D0 VA: 0x29471D0 Slot: 5
	public override void Dispose()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x2947260 Offset: 0x2947260 VA: 0x2947260
	// private void Dispose(bool disposing) { }

	// // RVA: 0x2946C58 Offset: 0x2946C58 VA: 0x2946C58
	// public void Copy(CriFsBinder binder, string srcPath, string dstPath, int installBufferSize) { }

	// // RVA: 0x2946940 Offset: 0x2946940 VA: 0x2946940
	// public void Stop() { }

	// // RVA: 0x2946F88 Offset: 0x2946F88 VA: 0x2946F88
	// public CriFsInstaller.Status GetStatus() { }

	// // RVA: 0x2946EF4 Offset: 0x2946EF4 VA: 0x2946EF4
	// public float GetProgress() { }

	// // RVA: 0x29478D4 Offset: 0x29478D4 VA: 0x29478D4
	public static void ExecuteMain()
    {
        criFsInstaller_ExecuteMain();
    }

	// // RVA: 0x29479AC Offset: 0x29479AC VA: 0x29479AC Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0x29478D8 Offset: 0x29478D8 VA: 0x29478D8
	private static /*extern */int criFsInstaller_ExecuteMain()
    {
        return ExternLib.LibCriWare.criFsInstaller_ExecuteMain();
    }

	// // RVA: 0x29470B8 Offset: 0x29470B8 VA: 0x29470B8
	// private static extern int criFsInstaller_Create(out IntPtr installer, CriFsInstaller.CopyPolicy option) { }

	// // RVA: 0x2947338 Offset: 0x2947338 VA: 0x2947338
	// private static extern int criFsInstaller_Destroy(IntPtr installer) { }

	// // RVA: 0x2947450 Offset: 0x2947450 VA: 0x2947450
	// private static extern int criFsInstaller_Copy(IntPtr installer, IntPtr binder, string src_path, string dst_path, IntPtr buffer, long buffer_size) { }

	// // RVA: 0x29475C0 Offset: 0x29475C0 VA: 0x29475C0
	// private static extern int criFsInstaller_Stop(IntPtr installer) { }

	// // RVA: 0x29476D0 Offset: 0x29476D0 VA: 0x29476D0
	// private static extern int criFsInstaller_GetStatus(IntPtr installer, out CriFsInstaller.Status status) { }

	// // RVA: 0x29477F0 Offset: 0x29477F0 VA: 0x29477F0
	// private static extern int criFsInstaller_GetProgress(IntPtr installer, out float progress) { }
}