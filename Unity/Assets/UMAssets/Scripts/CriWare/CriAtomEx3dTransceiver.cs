using System;
using System.Runtime.InteropServices;

namespace CriWare
{

	public class CriAtomEx3dTransceiver : CriDisposable
	{
		// private IntPtr handle; // 0x18

		// public IntPtr nativeHandle { get; }

		// RVA: 0x28882B0 Offset: 0x28882B0 VA: 0x28882B0
		public CriAtomEx3dTransceiver()
		{
			TodoLogger.LogError(0, "TODO");
		}

		// // RVA: 0x2888460 Offset: 0x2888460 VA: 0x2888460 Slot: 5
		public override void Dispose()
		{
			TodoLogger.LogError(0, "TODO");
		}

		// // RVA: 0x2888468 Offset: 0x2888468 VA: 0x2888468
		// private void Dispose(bool disposing) { }

		// // RVA: 0x2888638 Offset: 0x2888638 VA: 0x2888638
		// public IntPtr get_nativeHandle() { }

		// // RVA: 0x2888640 Offset: 0x2888640 VA: 0x2888640
		public void Update()
		{
			TodoLogger.LogError(0, "TODO");
		}

		// // RVA: 0x2888728 Offset: 0x2888728 VA: 0x2888728
		// public void SetInputPosition(Vector3 position) { }

		// // RVA: 0x2888840 Offset: 0x2888840 VA: 0x2888840
		// public void SetOutputPosition(Vector3 position) { }

		// // RVA: 0x288895C Offset: 0x288895C VA: 0x288895C
		// public void SetInputOrientation(Vector3 front, Vector3 top) { }

		// // RVA: 0x2888A9C Offset: 0x2888A9C VA: 0x2888A9C
		// public void SetOutputOrientation(Vector3 front, Vector3 top) { }

		// // RVA: 0x2888BDC Offset: 0x2888BDC VA: 0x2888BDC
		// public void SetOutputConeParameter(float insideAngle, float outsideAngle, float outsideVolume) { }

		// // RVA: 0x2888D00 Offset: 0x2888D00 VA: 0x2888D00
		// public void SetOutputMinMaxDistance(float minDistance, float maxDistance) { }

		// // RVA: 0x2888E14 Offset: 0x2888E14 VA: 0x2888E14
		// public void SetOutputInteriorPanField(float radius, float interiorDistance) { }

		// // RVA: 0x2888F24 Offset: 0x2888F24 VA: 0x2888F24
		// public void SetInputCrossFadeField(float directAudioRadius, float crossfadeDistance) { }

		// // RVA: 0x2889030 Offset: 0x2889030 VA: 0x2889030
		// public void SetOutputVolume(float volume) { }

		// // RVA: 0x2889128 Offset: 0x2889128 VA: 0x2889128
		// public void AttachAisac(string globalAisacName) { }

		// // RVA: 0x2889238 Offset: 0x2889238 VA: 0x2889238
		// public void DetachAisac(string globalAisacName) { }

		// // RVA: 0x2889348 Offset: 0x2889348 VA: 0x2889348
		// public void SetMaxAngleAisacDelta(float maxDelta) { }

		// // RVA: 0x2889448 Offset: 0x2889448 VA: 0x2889448
		// public void SetDistanceAisacControlId(ushort aisacControlId) { }

		// // RVA: 0x288954C Offset: 0x288954C VA: 0x288954C
		// public void SetListenerBasedAzimuthAngleAisacControlId(ushort aisacControlId) { }

		// // RVA: 0x288962C Offset: 0x288962C VA: 0x288962C
		// public void SetListenerBasedElevationAngleAisacControlId(ushort aisacControlId) { }

		// // RVA: 0x288970C Offset: 0x288970C VA: 0x288970C
		// public void SetTransceiverOutputBasedAzimuthAngleAisacControlId(ushort aisacControlId) { }

		// // RVA: 0x28897EC Offset: 0x28897EC VA: 0x28897EC
		// public void SetTransceiverOutputBasedElevationAngleAisacControlId(ushort aisacControlId) { }

		// // RVA: 0x28898CC Offset: 0x28898CC VA: 0x28898CC
		// public void Set3dRegion(CriAtomEx3dRegion region3d) { }

		// // RVA: 0x2889A20 Offset: 0x2889A20 VA: 0x2889A20 Slot: 1
		// protected override void Finalize() { }
	}

	public class CriAtomEx3dRegion : CriDisposable
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct Config
		{
			public int reserved;  // 0x0
		}
		private IntPtr handle = IntPtr.Zero; // 0x18

		public IntPtr nativeHandle { get { return this.handle; } } // 0x2885F9C

		// Methods

		// RVA: 0x28861F0 Offset: 0x28861F0 VA: 0x28861F0
		public CriAtomEx3dRegion()
		{
			Config config = new Config();
			this.handle = UnsafeNativeMethods.criAtomEx3dRegion_Create(ref config, IntPtr.Zero, 0);
			CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
		}

		// RVA: 0x28863D8 Offset: 0x28863D8 VA: 0x28863D8 Slot: 5
		public override void Dispose()
		{
			this.Dispose(true);
		}

		// RVA: 0x28863E0 Offset: 0x28863E0 VA: 0x28863E0
		private void Dispose(bool disposing)
		{
			CriDisposableObjectManager.Unregister(this);

			if (this.handle != IntPtr.Zero) {
				UnsafeNativeMethods.criAtomEx3dRegion_Destroy(this.handle);
				this.handle = IntPtr.Zero;
			}

			if (disposing) {
				GC.SuppressFinalize(this);
			}
		}

		// RVA: 0x28865E8 Offset: 0x28865E8 VA: 0x28865E8 Slot: 1
		~CriAtomEx3dRegion()
		{
			this.Dispose(false);
		}
 
		private static class UnsafeNativeMethods
		{
			// RVA: 0x28862B0 Offset: 0x28862B0 VA: 0x28862B0
			#if UNITY_ANDROID
			[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
			internal static extern IntPtr criAtomEx3dRegion_Create(ref Config config, IntPtr work, int work_size);
			#else
			internal static IntPtr criAtomEx3dRegion_Create(ref CriAtomEx3dRegion.Config config, IntPtr work, int work_size)
			{
				return ExternLib.LibCriWare.criAtomEx3dRegion_Create(ref config, work, work_size);
			}
			#endif

			// RVA: 0x28864D0 Offset: 0x28864D0 VA: 0x28864D0
			#if UNITY_ANDROID
			[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
			internal static extern void criAtomEx3dRegion_Destroy(IntPtr ex_3d_region);
			#else
			internal static void criAtomEx3dRegion_Destroy(IntPtr ex_3d_region)
			{
				ExternLib.LibCriWare.criAtomEx3dRegion_Destroy(ex_3d_region);
			}
			#endif
		}

	}

}
