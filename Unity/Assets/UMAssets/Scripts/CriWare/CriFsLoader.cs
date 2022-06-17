using System;

public class CriFsLoader : CriDisposable
{
    public enum Status
    {
        Stop = 0,
        Loading = 1,
        Complete = 2,
        Error = 3,
    }

	private IntPtr handle; // 0x18
	// private GCHandle dstGch; // 0x1C
	// private GCHandle srcGch; // 0x20

	// // RVA: 0x29483A8 Offset: 0x29483A8 VA: 0x29483A8
	public CriFsLoader()
	{
		if(!CriFsPlugin.IsLibraryInitialized())
		{
			new Exception("CriFsPlugin is not initialized.");
		}
		handle = IntPtr.Zero;
		criFsLoader_Create(out handle);
		if(handle == IntPtr.Zero)
		{
			new Exception("criFsLoader_Create() failed.");
		}
		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Fs);
	}

	// // RVA: 0x2948884 Offset: 0x2948884 VA: 0x2948884 Slot: 5
	public override void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	// // RVA: 0x2948914 Offset: 0x2948914 VA: 0x2948914
	private void Dispose(bool disposing)
	{
		CriDisposableObjectManager.Unregister(this);
		//if(handle != IntPtr.Zero)
		{
			criFsLoader_Destroy(this);
		}
	}

	// // RVA: 0x29485BC Offset: 0x29485BC VA: 0x29485BC
	public void Load(CriFsBinder binder, string path, long fileOffset, long loadSize, byte[] buffer)
	{
		criFsLoader_Load(this, binder, path, fileOffset, loadSize, buffer, buffer.Length);
	}

	// // RVA: 0x2948C94 Offset: 0x2948C94 VA: 0x2948C94
	// public void LoadById(CriFsBinder binder, int id, long fileOffset, long loadSize, byte[] buffer) { }

	// // RVA: 0x2948EC8 Offset: 0x2948EC8 VA: 0x2948EC8
	// public void LoadWithoutDecompression(CriFsBinder binder, string path, long fileOffset, long loadSize, byte[] buffer) { }

	// // RVA: 0x2949104 Offset: 0x2949104 VA: 0x2949104
	// public void LoadWithoutDecompressionById(CriFsBinder binder, int id, long fileOffset, long loadSize, byte[] buffer) { }

	// // RVA: 0x294931C Offset: 0x294931C VA: 0x294931C
	// public void DecompressData(long srcSize, byte[] srcBuffer, long dstSize, byte[] dstBuffer) { }

	// // RVA: 0x2947FB8 Offset: 0x2947FB8 VA: 0x2947FB8
	// public void Stop() { }

	// // RVA: 0x29486A0 Offset: 0x29486A0 VA: 0x29486A0
	public CriFsLoader.Status GetStatus()
	{
		CriFsLoader.Status status;
		criFsLoader_GetStatus(this, out status);
		return status;
	}

	// // RVA: 0x294853C Offset: 0x294853C VA: 0x294853C
	public void SetReadUnitSize(int unit_size)
	{
		UnityEngine.Debug.LogWarning("TODO SetReadUnitSize");
	}

	// // RVA: 0x29497CC Offset: 0x29497CC VA: 0x29497CC Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0x2948778 Offset: 0x2948778 VA: 0x2948778
	private static /*extern */int criFsLoader_Create(out IntPtr loader)
	{
		return ExternLib.LibCriWare.criFsLoader_Create(out loader);
	}

	// // RVA: 0x2948A18 Offset: 0x2948A18 VA: 0x2948A18
	private static /*extern*/ int criFsLoader_Destroy(/*IntPtr*/CriFsLoader loader)
	{
		return ExternLib.LibCriWare.criFsLoader_Destroy(loader);
	}

	// // RVA: 0x2948B28 Offset: 0x2948B28 VA: 0x2948B28
	private static /*extern*/ int criFsLoader_Load(/*IntPtr*/CriFsLoader loader, /*IntPtr*/CriFsBinder binder, string path, long offset, long load_size, /*IntPtr*/byte[] buffer, long buffer_size)
	{
		return ExternLib.LibCriWare.criFsLoader_Load(loader, binder, path, offset, load_size, buffer, buffer_size);
	}

	// // RVA: 0x2948D78 Offset: 0x2948D78 VA: 0x2948D78
	// private static extern int criFsLoader_LoadById(IntPtr loader, IntPtr binder, int id, long offset, long load_size, IntPtr buffer, long buffer_size) { }

	// // RVA: 0x29494C0 Offset: 0x29494C0 VA: 0x29494C0
	// private static extern int criFsLoader_Stop(IntPtr loader) { }

	// // RVA: 0x29495C8 Offset: 0x29495C8 VA: 0x29495C8
	private static /*extern*/ int criFsLoader_GetStatus(/*IntPtr*/CriFsLoader loader, out CriFsLoader.Status status)
	{
		return ExternLib.LibCriWare.criFsLoader_GetStatus(loader, out status);
	}

	// // RVA: 0x29496E0 Offset: 0x29496E0 VA: 0x29496E0
	// private static extern int criFsLoader_SetReadUnitSize(IntPtr loader, long unit_size) { }

	// // RVA: 0x2948FB0 Offset: 0x2948FB0 VA: 0x2948FB0
	// private static extern int criFsLoader_LoadWithoutDecompression(IntPtr loader, IntPtr binder, string path, long offset, long load_size, IntPtr buffer, long buffer_size) { }

	// // RVA: 0x29491E8 Offset: 0x29491E8 VA: 0x29491E8
	// private static extern int criFsLoader_LoadWithoutDecompressionById(IntPtr loader, IntPtr binder, int id, long offset, long load_size, IntPtr buffer, long buffer_size) { }

	// // RVA: 0x29493B0 Offset: 0x29493B0 VA: 0x29493B0
	// private static extern int criFsLoader_DecompressData(IntPtr loader, IntPtr src, long src_size, IntPtr dst, long dst_size) { }
}
