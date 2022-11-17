using System;
using System.Runtime.InteropServices;

namespace CriWare
{
	public class CriAtomExAcb : CriDisposable
	{
		private IntPtr handle; // 0x18
		private GCHandle dataHandle; // 0x1C

		public IntPtr nativeHandle {get {return this.handle;} } //0x2889A88
		public bool isAvailable {get {return this.handle != IntPtr.Zero;} } // 0x2889A90

		// // RVA: 0x287DC4C Offset: 0x287DC4C VA: 0x287DC4C
		public static CriAtomExAcb LoadAcbFile(CriFsBinder binder, string acbPath, string awbPath)
		{
			bool isCorrectVersion = CriWare.Common.CheckBinaryVersionCompatibility();
			if (isCorrectVersion == false) {
				return null;
			}

			IntPtr handle = criAtomExAcb_LoadAcbFile(
				binder, acbPath, binder, awbPath, IntPtr.Zero, 0);
			if (handle == IntPtr.Zero) {
				return null;
			}
			return new CriAtomExAcb(handle, null);
		}

		// // RVA: 0x287DD60 Offset: 0x287DD60 VA: 0x287DD60
		// public static CriAtomExAcb LoadAcbData(byte[] acbData, CriFsBinder awbBinder, string awbPath) { }

		// // RVA: 0x2889EB4 Offset: 0x2889EB4 VA: 0x2889EB4 Slot: 5
		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// // RVA: 0x2889F44 Offset: 0x2889F44 VA: 0x2889F44
		private void Dispose(bool disposing)
		{
			CriDisposableObjectManager.Unregister(this);

			if (this.isAvailable) {
				criAtomExAcb_Release(this.handle);
				this.handle = IntPtr.Zero;
			}

			if (disposing && this.dataHandle.IsAllocated) {
				this.dataHandle.Free();
			}
		}

		// // RVA: 0x288A130 Offset: 0x288A130 VA: 0x288A130
		// public bool Exists(string cueName) { }

		// // RVA: 0x288A280 Offset: 0x288A280 VA: 0x288A280
		// public bool Exists(int cueId) { }

		// // RVA: 0x288A3A8 Offset: 0x288A3A8 VA: 0x288A3A8
		public bool GetCueInfo(string cueName, out CriAtomEx.CueInfo info)
		{
			return criAtomExAcb_GetCueInfoByName(this.handle, cueName, out info);
		}

		// // RVA: 0x288A6DC Offset: 0x288A6DC VA: 0x288A6DC
		// public bool GetCueInfo(int cueId, out CriAtomEx.CueInfo info) { }

		// // RVA: 0x288A9EC Offset: 0x288A9EC VA: 0x288A9EC
		// public bool GetCueInfoByIndex(int index, out CriAtomEx.CueInfo info) { }

		// // RVA: 0x288AD00 Offset: 0x288AD00 VA: 0x288AD00
		// public CriAtomEx.CueInfo[] GetCueInfoList() { }

		// // RVA: 0x288AEEC Offset: 0x288AEEC VA: 0x288AEEC
		// public bool GetWaveFormInfo(string cueName, out CriAtomEx.WaveformInfo info) { }

		// // RVA: 0x288B228 Offset: 0x288B228 VA: 0x288B228
		// public bool GetWaveFormInfo(int cueId, out CriAtomEx.WaveformInfo info) { }

		// // RVA: 0x288B53C Offset: 0x288B53C VA: 0x288B53C
		// public int GetNumCuePlaying(string name) { }

		// // RVA: 0x288B660 Offset: 0x288B660 VA: 0x288B660
		// public int GetNumCuePlaying(int id) { }

		// // RVA: 0x288B758 Offset: 0x288B758 VA: 0x288B758
		// public int GetBlockIndex(string cueName, string blockName) { }

		// // RVA: 0x288B890 Offset: 0x288B890 VA: 0x288B890
		// public int GetBlockIndex(int cueId, string blockName) { }

		// // RVA: 0x288B9AC Offset: 0x288B9AC VA: 0x288B9AC
		// public int GetNumUsableAisacControls(string cueName) { }

		// // RVA: 0x288BAD4 Offset: 0x288BAD4 VA: 0x288BAD4
		// public int GetNumUsableAisacControls(int cueId) { }

		// // RVA: 0x288BBD4 Offset: 0x288BBD4 VA: 0x288BBD4
		// public bool GetUsableAisacControl(string cueName, int index, out CriAtomEx.AisacControlInfo info) { }

		// // RVA: 0x288BF20 Offset: 0x288BF20 VA: 0x288BF20
		// public bool GetUsableAisacControl(int cueId, int index, out CriAtomEx.AisacControlInfo info) { }

		// // RVA: 0x288C240 Offset: 0x288C240 VA: 0x288C240
		// public CriAtomEx.AisacControlInfo[] GetUsableAisacControlList(string cueName) { }

		// // RVA: 0x288C328 Offset: 0x288C328 VA: 0x288C328
		// public CriAtomEx.AisacControlInfo[] GetUsableAisacControlList(int cueId) { }

		// // RVA: 0x288C410 Offset: 0x288C410 VA: 0x288C410
		// public void ResetCueTypeState(string cueName) { }

		// // RVA: 0x288C524 Offset: 0x288C524 VA: 0x288C524
		// public void ResetCueTypeState(int cueId) { }

		// // RVA: 0x288C61C Offset: 0x288C61C VA: 0x288C61C
		// public void AttachAwbFile(CriFsBinder awb_binder, string awb_path, string awb_name) { }

		// // RVA: 0x288C800 Offset: 0x288C800 VA: 0x288C800
		// public void DetachAwbFile(string awb_name) { }

		// // RVA: 0x288C930 Offset: 0x288C930 VA: 0x288C930
		// public bool IsReadyToRelease() { }

		// // RVA: 0x288CA40 Offset: 0x288CA40 VA: 0x288CA40
		// public float GetLoadProgress() { }

		// // RVA: 0x288CA48 Offset: 0x288CA48 VA: 0x288CA48
		// public void Decrypt(ulong key, ulong nonce) { }

		// RVA: 0x2889C64 Offset: 0x2889C64 VA: 0x2889C64
		internal CriAtomExAcb(IntPtr handle, GCHandle? dataHandle)
		{
			this.handle = handle;
			if (dataHandle.HasValue) {
				this.dataHandle = dataHandle.Value;
			}
			CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
		}

		// // RVA: 0x288CB08 Offset: 0x288CB08 VA: 0x288CB08 Slot: 1
		// protected override void Finalize() { }

		// // RVA: 0x2889AF0 Offset: 0x2889AF0 VA: 0x2889AF0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern IntPtr criAtomExAcb_LoadAcbFile(IntPtr acb_binder, string acb_path,
			IntPtr awb_binder, string awb_path, IntPtr work, int work_size);
		#endif
		private static IntPtr criAtomExAcb_LoadAcbFile(CriFsBinder acb_binder, string acb_path, CriFsBinder awb_binder, string awb_path, IntPtr work, int work_size)
		{
		#if UNITY_ANDROID
			IntPtr binderHandle = (acb_binder != null) ? acb_binder.nativeHandle : IntPtr.Zero;
			IntPtr handle = criAtomExAcb_LoadAcbFile(
				binderHandle, acb_path, binderHandle, awb_path, IntPtr.Zero, 0);
		#else
			IntPtr handle = ExternLib.LibCriWare.criAtomExAcb_LoadAcbFile(acb_binder, acb_path, awb_binder, awb_path, work, work_size);
		#endif
			return handle;
		}

		// // RVA: 0x2889D58 Offset: 0x2889D58 VA: 0x2889D58
		// private static extern IntPtr criAtomExAcb_LoadAcbData(IntPtr acb_data, int acb_data_size, IntPtr awb_binder, string awb_path, IntPtr work, int work_size) { }

		// // RVA: 0x288A020 Offset: 0x288A020 VA: 0x288A020
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExAcb_Release(IntPtr acb_hn);
		#else
		private static void criAtomExAcb_Release(IntPtr acb_hn)
		{
			ExternLib.LibCriWare.criAtomExAcb_Release(acb_hn);
		}
		#endif

		// // RVA: 0x288ADD8 Offset: 0x288ADD8 VA: 0x288ADD8
		// private static extern int criAtomExAcb_GetNumCues(IntPtr acb_hn) { }

		// // RVA: 0x288A288 Offset: 0x288A288 VA: 0x288A288
		// private static extern bool criAtomExAcb_ExistsId(IntPtr acb_hn, int id) { }

		// // RVA: 0x288A138 Offset: 0x288A138 VA: 0x288A138
		// private static extern bool criAtomExAcb_ExistsName(IntPtr acb_hn, string name) { }

		// // RVA: 0x288BAE0 Offset: 0x288BAE0 VA: 0x288BAE0
		// private static extern int criAtomExAcb_GetNumUsableAisacControlsById(IntPtr acb_hn, int id) { }

		// // RVA: 0x288B9B8 Offset: 0x288B9B8 VA: 0x288B9B8
		// private static extern int criAtomExAcb_GetNumUsableAisacControlsByName(IntPtr acb_hn, string name) { }

		// // RVA: 0x288C138 Offset: 0x288C138 VA: 0x288C138
		// private static extern bool criAtomExAcb_GetUsableAisacControlById(IntPtr acb_hn, int id, ushort index, IntPtr info) { }

		// // RVA: 0x288BDF0 Offset: 0x288BDF0 VA: 0x288BDF0
		// private static extern bool criAtomExAcb_GetUsableAisacControlByName(IntPtr acb_hn, string name, ushort index, IntPtr info) { }

		// // RVA: 0x288B440 Offset: 0x288B440 VA: 0x288B440
		// private static extern bool criAtomExAcb_GetWaveformInfoById(IntPtr acb_hn, int id, IntPtr waveform_info) { }

		// // RVA: 0x288B108 Offset: 0x288B108 VA: 0x288B108
		// private static extern bool criAtomExAcb_GetWaveformInfoByName(IntPtr acb_hn, string name, IntPtr waveform_info) { }

		// // RVA: 0x288A5C0 Offset: 0x288A5C0 VA: 0x288A5C0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern bool criAtomExAcb_GetCueInfoByName(IntPtr acb_hn, string name, IntPtr info);
		#endif
		private static bool criAtomExAcb_GetCueInfoByName(IntPtr acb_hn, string name, out CriAtomEx.CueInfo info)
		{
		#if UNITY_ANDROID
			using (var mem = new CriStructMemory<CriAtomEx.CueInfo>()) {
				bool result = criAtomExAcb_GetCueInfoByName(acb_hn, name, mem.ptr);
				info = new CriAtomEx.CueInfo(mem.bytes, 0);
				return result;
			}
		#else
			return ExternLib.LibCriWare.criAtomExAcb_GetCueInfoByName(acb_hn, name, out info);
		#endif
		}

		// // RVA: 0x288A8F8 Offset: 0x288A8F8 VA: 0x288A8F8
		// private static extern bool criAtomExAcb_GetCueInfoById(IntPtr acb_hn, int id, IntPtr info) { }

		// // RVA: 0x288AC08 Offset: 0x288AC08 VA: 0x288AC08
		// private static extern bool criAtomExAcb_GetCueInfoByIndex(IntPtr acb_hn, int index, IntPtr info) { }

		// // RVA: 0x288B548 Offset: 0x288B548 VA: 0x288B548
		// private static extern int criAtomExAcb_GetNumCuePlayingCountByName(IntPtr acb_hn, string name) { }

		// // RVA: 0x288B668 Offset: 0x288B668 VA: 0x288B668
		// private static extern int criAtomExAcb_GetNumCuePlayingCountById(IntPtr acb_hn, int id) { }

		// // RVA: 0x288B898 Offset: 0x288B898 VA: 0x288B898
		// private static extern int criAtomExAcb_GetBlockIndexById(IntPtr acb_hn, int id, string block_name) { }

		// // RVA: 0x288B760 Offset: 0x288B760 VA: 0x288B760
		// private static extern int criAtomExAcb_GetBlockIndexByName(IntPtr acb_hn, string name, string block_name) { }

		// // RVA: 0x288C418 Offset: 0x288C418 VA: 0x288C418
		// private static extern void criAtomExAcb_ResetCueTypeStateByName(IntPtr acb_hn, string name) { }

		// // RVA: 0x288C530 Offset: 0x288C530 VA: 0x288C530
		// private static extern void criAtomExAcb_ResetCueTypeStateById(IntPtr acb_hn, int id) { }

		// // RVA: 0x288C6C8 Offset: 0x288C6C8 VA: 0x288C6C8
		// private static extern void criAtomExAcb_AttachAwbFile(IntPtr acb_hn, IntPtr awb_binder, string awb_path, string awb_name, IntPtr work, int work_size) { }

		// // RVA: 0x288C830 Offset: 0x288C830 VA: 0x288C830
		// private static extern void criAtomExAcb_DetachAwbFile(IntPtr acb_hn, string awb_name) { }

		// // RVA: 0x288C958 Offset: 0x288C958 VA: 0x288C958
		// private static extern bool criAtomExAcb_IsReadyToRelease(IntPtr acb_hn) { }

	}
}
