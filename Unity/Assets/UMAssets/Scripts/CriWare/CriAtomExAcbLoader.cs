using System;
using System.Runtime.InteropServices;

namespace CriWare
{
	public class CriAtomExAcbLoader : CriDisposable
	{
		public enum Status
		{
			Stop = 0,
			Loading = 1,
			Complete = 2,
			Error = 3,
		}


		private IntPtr handle; // 0x18
		private Nullable<GCHandle> gch; // 0x1C

		// // RVA: 0x287F648 Offset: 0x287F648 VA: 0x287F648
		// public static CriAtomExAcbLoader LoadAcbFileAsync(CriFsBinder binder, string acbPath, string awbPath, bool loadAwbOnMemory = False) { }

		// // RVA: 0x287EE48 Offset: 0x287EE48 VA: 0x287EE48
		// public static CriAtomExAcbLoader LoadAcbDataAsync(byte[] acbData, CriFsBinder awbBinder, string awbPath, bool loadAwbOnMemory = False) { }

		// // RVA: 0x287EFE0 Offset: 0x287EFE0 VA: 0x287EFE0
		// public CriAtomExAcbLoader.Status GetStatus() { }

		// // RVA: 0x287EFE8 Offset: 0x287EFE8 VA: 0x287EFE8
		// public CriAtomExAcb MoveAcb() { }

		// // RVA: 0x288D3DC Offset: 0x288D3DC VA: 0x288D3DC Slot: 5
		public override void Dispose()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x288D46C Offset: 0x288D46C VA: 0x288D46C
		// private void Dispose(bool disposing) { }

		// // RVA: 0x288CFC8 Offset: 0x288CFC8 VA: 0x288CFC8
		private CriAtomExAcbLoader(IntPtr handle, Nullable<GCHandle> dataHandle)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x288D68C Offset: 0x288D68C VA: 0x288D68C Slot: 1
		// protected override void Finalize() { }

		// // RVA: 0x288CD60 Offset: 0x288CD60 VA: 0x288CD60
		// private static extern IntPtr criAtomExAcbLoader_Create(in CriAtomExAcbLoader.LoaderConfig config) { }

		// // RVA: 0x288D5B0 Offset: 0x288D5B0 VA: 0x288D5B0
		// private static extern void criAtomExAcbLoader_Destroy(IntPtr acb_loader) { }

		// // RVA: 0x288CE80 Offset: 0x288CE80 VA: 0x288CE80
		// private static extern bool criAtomExAcbLoader_LoadAcbFileAsync(IntPtr acb_loader, IntPtr acb_binder, string acb_path, IntPtr awb_binder, string awb_path) { }

		// // RVA: 0x288D0E8 Offset: 0x288D0E8 VA: 0x288D0E8
		// private static extern bool criAtomExAcbLoader_LoadAcbDataAsync(IntPtr acb_loader, IntPtr acb_data, int acb_size, IntPtr awb_binder, string awb_path) { }

		// // RVA: 0x288D218 Offset: 0x288D218 VA: 0x288D218
		// private static extern CriAtomExAcbLoader.Status criAtomExAcbLoader_GetStatus(IntPtr acb_loader) { }

		// // RVA: 0x288D6F8 Offset: 0x288D6F8 VA: 0x288D6F8
		// private static extern bool criAtomExAcbLoader_WaitForCompletion(IntPtr acb_loader) { }

		// // RVA: 0x288D2F8 Offset: 0x288D2F8 VA: 0x288D2F8
		// private static extern IntPtr criAtomExAcbLoader_MoveAcbHandle(IntPtr acb_loader) { }
	}
}