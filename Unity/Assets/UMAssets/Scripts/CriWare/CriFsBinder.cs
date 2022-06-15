
using System;

public class CriFsBinder : CriDisposable
{
	public enum Status
	{
		None = 0,
		Analyze = 1,
		Complete = 2,
		Unbind = 3,
		Removed = 4,
		Invalid = 5,
		Error = 6,
	}
	
	private IntPtr handle; // 0x18

	public IntPtr nativeHandle { get; }

	// // RVA: 0x2944550 Offset: 0x2944550 VA: 0x2944550
	public CriFsBinder()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x294486C Offset: 0x294486C VA: 0x294486C Slot: 5
	public override void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	// // RVA: 0x29448FC Offset: 0x29448FC VA: 0x29448FC
	private void Dispose(bool disposing)
	{ 
		CriDisposableObjectManager.Unregister(this);
		//if(handle != IntPtr.Zero)
		{
			criFsBinder_Destroy(this);
		}
	}

	// // RVA: 0x2944170 Offset: 0x2944170 VA: 0x2944170
	// public uint BindCpk(CriFsBinder srcBinder, string path) { }

	// // RVA: 0x294421C Offset: 0x294421C VA: 0x294421C
	// public uint BindDirectory(CriFsBinder srcBinder, string path) { }

	// // RVA: 0x29442C8 Offset: 0x29442C8 VA: 0x29442C8
	public uint BindFile(CriFsBinder srcBinder, string path)
	{
		uint bindId;
		criFsBinder_BindFile(/*handle*/this, /*srcBinder.nativeHandle*/srcBinder, path, IntPtr.Zero, 0, out bindId);
		return bindId;
	}

	// // RVA: 0x2944EC4 Offset: 0x2944EC4 VA: 0x2944EC4
	// public uint BindFileSection(CriFsBinder srcBinder, string path, ulong offset, int size, string sectionName) { }

	// // RVA: 0x29450E8 Offset: 0x29450E8 VA: 0x29450E8
	public static void Unbind(uint bindId)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x2944400 Offset: 0x2944400 VA: 0x2944400
	public static CriFsBinder.Status GetStatus(uint bindId)
	{
		if(CriFsPlugin.IsLibraryInitialized())
		{
			Status status;
			criFsBinder_GetStatus(bindId, out status);
			return status;
		}
		return Status.Removed;
	}

	// // RVA: 0x29453A0 Offset: 0x29453A0 VA: 0x29453A0
	public long GetFileSize(string path)
	{
		long size = 0;
		criFsBinder_GetFileSize(this, path, out size);
		return size;
	}

	// // RVA: 0x2945598 Offset: 0x2945598 VA: 0x2945598
	// public long GetFileSize(int id) { }

	// // RVA: 0x2945734 Offset: 0x2945734 VA: 0x2945734
	// public bool GetContentsFileInfo(string path, out CriFsBinder.ContentsFileInfo info) { }

	// // RVA: 0x2945CF4 Offset: 0x2945CF4 VA: 0x2945CF4
	// public bool GetContentsFileInfo(int id, out CriFsBinder.ContentsFileInfo info) { }

	// // RVA: 0x294600C Offset: 0x294600C VA: 0x294600C
	// public static bool GetContentsFileInfoByIndex(uint bindId, int index, int numFiles, out CriFsBinder.ContentsFileInfo[] info) { }

	// // RVA: 0x29464E8 Offset: 0x29464E8 VA: 0x29464E8
	// public static int GetNumContentsFiles(uint bindId) { }

	// // RVA: 0x29465F4 Offset: 0x29465F4 VA: 0x29465F4
	// public static void SetPriority(uint bindId, int priority) { }

	// // RVA: 0x2944AB4 Offset: 0x2944AB4 VA: 0x2944AB4
	// public IntPtr get_nativeHandle() { }

	// // RVA: 0x29467A4 Offset: 0x29467A4 VA: 0x29467A4 Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0x2944760 Offset: 0x2944760 VA: 0x2944760
	// private static extern uint criFsBinder_Create(out IntPtr binder) { }

	// // RVA: 0x29449A8 Offset: 0x29449A8 VA: 0x29449A8
	private static /*extern */uint criFsBinder_Destroy(/*IntPtr*/CriFsBinder binder)
	{
		return ExternLib.LibCriWare.criFsBinder_Destroy(binder);
	}

	// // RVA: 0x2944AC0 Offset: 0x2944AC0 VA: 0x2944AC0
	// private static extern uint criFsBinder_BindCpk(IntPtr binder, IntPtr srcBinder, string path, IntPtr work, int worksize, out uint bindId) { }

	// // RVA: 0x2944C10 Offset: 0x2944C10 VA: 0x2944C10
	// private static extern uint criFsBinder_BindDirectory(IntPtr binder, IntPtr srcBinder, string path, IntPtr work, int worksize, out uint bindId) { }

	// // RVA: 0x2944D70 Offset: 0x2944D70 VA: 0x2944D70
	private static /*extern*/ uint criFsBinder_BindFile(/*IntPtr*/CriFsBinder binder, /*IntPtr*/CriFsBinder srcBinder, string path, IntPtr work, int worksize, out uint bindId)
	{
		return ExternLib.LibCriWare.criFsBinder_BindFile(binder,  srcBinder, path, work, worksize, out bindId);
	}

	// // RVA: 0x2944F90 Offset: 0x2944F90 VA: 0x2944F90
	// private static extern uint criFsBinder_BindFileSection(IntPtr binder, IntPtr srcBinder, string path, ulong offset, int size, string sectionName, IntPtr work, int worksize, out uint bindId) { }

	// // RVA: 0x2945178 Offset: 0x2945178 VA: 0x2945178
	// private static extern int criFsBinder_Unbind(uint bindId) { }

	// // RVA: 0x2945288 Offset: 0x2945288 VA: 0x2945288
	private static /*extern*/ int criFsBinder_GetStatus(uint bindId, out CriFsBinder.Status status)
	{
		return ExternLib.LibCriWare.criFsBinder_GetStatus(bindId, out status);
	}

	// // RVA: 0x2945450 Offset: 0x2945450 VA: 0x2945450
	private static /*extern*/ int criFsBinder_GetFileSize(/*IntPtr*/CriFsBinder binder, string path, out long size)
	{
		return ExternLib.LibCriWare.criFsBinder_GetFileSize(binder, path, out size);
	}

	// // RVA: 0x2945648 Offset: 0x2945648 VA: 0x2945648
	// private static extern int criFsBinder_GetFileSizeById(IntPtr binder, int id, out long size) { }

	// // RVA: 0x2946688 Offset: 0x2946688 VA: 0x2946688
	// private static extern int criFsBinder_SetPriority(uint bindId, int priority) { }

	// // RVA: 0x2945958 Offset: 0x2945958 VA: 0x2945958
	// private static extern int criFsBinder_GetContentsFileInfo(IntPtr binder, string path, IntPtr info) { }

	// // RVA: 0x2945F18 Offset: 0x2945F18 VA: 0x2945F18
	// private static extern int criFsBinder_GetContentsFileInfoById(IntPtr binder, int id, IntPtr info) { }

	// // RVA: 0x29463E8 Offset: 0x29463E8 VA: 0x29463E8
	// private static extern int criFsBinder_GetContentsFileInfoByIndex(uint id, int index, IntPtr info, int num) { }

	// // RVA: 0x29464F0 Offset: 0x29464F0 VA: 0x29464F0
	// private static extern int CRIWARE254CAE54(uint id) { }
}
