using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace CriWare
{

	public class CriAtomEx3dSource : CriDisposable
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct Config
		{
			public bool enableVoicePriorityDecay;   // 0x0
			public uint randomPositionListMaxLength; // 0x4
			#if !UNITY_ANDROID
			public CriAtomSource source;
			#endif

			// RVA: 0x81C838 Offset: 0x81C838 VA: 0x81C838
			public Config(bool enableVoicePriorityDecay, uint randomPositionListMaxLength, CriAtomSource source) {
				this.enableVoicePriorityDecay = enableVoicePriorityDecay;
				this.randomPositionListMaxLength = randomPositionListMaxLength;
				#if !UNITY_ANDROID
				this.source = source;
				#endif
			}
		}

		private uint currentRandomPositionListMaxLength; // 0x18
		private IntPtr handle; // 0x1C

		public IntPtr nativeHandle { get {return this.handle;} } // 0x2886A88

		// // RVA: 0x2886650 Offset: 0x2886650 VA: 0x2886650
		public CriAtomEx3dSource(CriAtomSource source, bool enableVoicePriorityDecay = false, uint randomPositionListMaxLength = 0)
		{
			Config config = new Config(enableVoicePriorityDecay, randomPositionListMaxLength, source);
			this.handle = criAtomEx3dSource_Create(ref config, IntPtr.Zero, 0);
			CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
			this.currentRandomPositionListMaxLength = randomPositionListMaxLength;
		}

		// // RVA: 0x2886878 Offset: 0x2886878 VA: 0x2886878 Slot: 5
		public override void Dispose()
		{
			this.Dispose(true);
		}

		// // RVA: 0x2886880 Offset: 0x2886880 VA: 0x2886880
		private void Dispose(bool disposing)
		{
			CriDisposableObjectManager.Unregister(this);

			if (this.handle != IntPtr.Zero) {
				criAtomEx3dSource_Destroy(this.handle);
				this.handle = IntPtr.Zero;
			}

			if (disposing) {
				GC.SuppressFinalize(this);
			}
		}

		// // RVA: 0x2886A90 Offset: 0x2886A90 VA: 0x2886A90
		public void Update()
		{
			criAtomEx3dSource_Update(this.handle);
		}

		// // RVA: 0x2886BB0 Offset: 0x2886BB0 VA: 0x2886BB0
		// public void ResetParameters() { }

		// // RVA: 0x2886C9C Offset: 0x2886C9C VA: 0x2886C9C
		public void SetPosition(float x, float y, float z)
		{
			CriAtomEx.NativeVector position;
			position.x = x;
			position.y = y;
			position.z = z;
			criAtomEx3dSource_SetPosition(this.handle, ref position);
		}

		// // RVA: 0x2886DA8 Offset: 0x2886DA8 VA: 0x2886DA8
		public void SetVelocity(float x, float y, float z)
		{
			CriAtomEx.NativeVector velocity;
			velocity.x = x;
			velocity.y = y;
			velocity.z = z;
			criAtomEx3dSource_SetVelocity(this.handle, ref velocity);
		}

		// // RVA: 0x2886EB8 Offset: 0x2886EB8 VA: 0x2886EB8
		public void SetOrientation(Vector3 front, Vector3 top)
		{
			CriAtomEx.NativeVector src_front;
			src_front.x = front.x;
			src_front.y = front.y;
			src_front.z = front.z;
			CriAtomEx.NativeVector src_top;
			src_top.x = top.x;
			src_top.y = top.y;
			src_top.z = top.z;
			criAtomEx3dSource_SetOrientation(this.handle, ref src_front, ref src_top);
		}

		// [ObsoleteAttribute] // RVA: 0x635DE0 Offset: 0x635DE0 VA: 0x635DE0
		// // RVA: 0x2886FEC Offset: 0x2886FEC VA: 0x2886FEC
		// public void SetConeOrientation(float x, float y, float z) { }

		// // RVA: 0x2887100 Offset: 0x2887100 VA: 0x2887100
		// public void SetConeParameter(float insideAngle, float outsideAngle, float outsideVolume) { }

		// // RVA: 0x288721C Offset: 0x288721C VA: 0x288721C
		// public void SetMinMaxDistance(float minDistance, float maxDistance) { }

		// // RVA: 0x2887328 Offset: 0x2887328 VA: 0x2887328
		// public void SetInteriorPanField(float sourceRadius, float interiorDistance) { }

		// // RVA: 0x2887428 Offset: 0x2887428 VA: 0x2887428
		// public void SetDopplerFactor(float dopplerFactor) { }

		// // RVA: 0x288751C Offset: 0x288751C VA: 0x288751C
		// public void SetVolume(float volume) { }

		// // RVA: 0x288760C Offset: 0x288760C VA: 0x288760C
		// public void SetMaxAngleAisacDelta(float maxDelta) { }

		// // RVA: 0x2887708 Offset: 0x2887708 VA: 0x2887708
		// public void SetAttenuationDistanceSetting(bool flag) { }

		// // RVA: 0x2887808 Offset: 0x2887808 VA: 0x2887808
		// public bool GetAttenuationDistanceSetting() { }

		// // RVA: 0x2887908 Offset: 0x2887908 VA: 0x2887908
		public void SetRandomPositionConfig(CriAtomEx.Randomize3dConfig? config)
		{
			if (config.HasValue) {
				if (config.Value.CalculationType == CriAtomEx.Randomize3dCalcType.None) {
					criAtomEx3dSource_SetRandomPositionConfig(this.handle, IntPtr.Zero);
				} else {
					var tempConfig = config.Value;
					criAtomEx3dSource_SetRandomPositionConfig(this.handle, ref tempConfig);
				}
			} else {
				criAtomEx3dSource_SetRandomPositionConfig(this.handle, IntPtr.Zero);
			}
		}

		// // RVA: 0x2887C10 Offset: 0x2887C10 VA: 0x2887C10
		// public void SetRandomPositionList(Vector3[] positionList) { }

		// // RVA: 0x2887ED8 Offset: 0x2887ED8 VA: 0x2887ED8
		public void Set3dRegion(CriAtomEx3dRegion region3d)
		{
			IntPtr region3dHandle = (region3d == null) ? IntPtr.Zero : region3d.nativeHandle;
			criAtomEx3dSource_Set3dRegionHn(this.handle, region3dHandle);
		}

		// // RVA: 0x2888028 Offset: 0x2888028 VA: 0x2888028
		// public void SetListenerBasedElevationAngleAisacControlId(ushort aisacControlId) { }

		// // RVA: 0x2888138 Offset: 0x2888138 VA: 0x2888138
		// public void SetSourceBasedElevationAngleAisacControlId(ushort aisacControlId) { }

		// // RVA: 0x2888248 Offset: 0x2888248 VA: 0x2888248 Slot: 1
		// protected override void Finalize() { }

		// // RVA: 0x2886730 Offset: 0x2886730 VA: 0x2886730
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern IntPtr criAtomEx3dSource_Create(ref Config config, IntPtr work, int work_size);
		#else
		private static IntPtr criAtomEx3dSource_Create(ref CriAtomEx3dSource.Config config, IntPtr work, int work_size)
		{
			return ExternLib.LibCriWare.criAtomEx3dSource_Create(ref config, work, work_size);
		}
		#endif

		// // RVA: 0x2886970 Offset: 0x2886970 VA: 0x2886970
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx3dSource_Destroy(IntPtr ex_3d_source);
		#else
		private static void criAtomEx3dSource_Destroy(IntPtr ex_3d_source)
		{
			ExternLib.LibCriWare.criAtomEx3dSource_Destroy(ex_3d_source);
		}
		#endif

		// // RVA: 0x2886A98 Offset: 0x2886A98 VA: 0x2886A98
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx3dSource_Update(IntPtr ex_3d_source);
		#else
		private static void criAtomEx3dSource_Update(IntPtr ex_3d_source)
		{
			ExternLib.LibCriWare.criAtomEx3dSource_Update(ex_3d_source);
		}
		#endif

		// // RVA: 0x2886BB8 Offset: 0x2886BB8 VA: 0x2886BB8
		// private static extern void criAtomEx3dSource_ResetParameters(IntPtr ex_3d_source) { }

		// // RVA: 0x2886CC0 Offset: 0x2886CC0 VA: 0x2886CC0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx3dSource_SetPosition(IntPtr ex_3d_source, ref CriAtomEx.NativeVector position);
		#else
		private static void criAtomEx3dSource_SetPosition(IntPtr ex_3d_source, ref CriAtomEx.NativeVector position)
		{
			ExternLib.LibCriWare.criAtomEx3dSource_SetPosition(ex_3d_source, ref position);
		}
		#endif

		// // RVA: 0x2886DD0 Offset: 0x2886DD0 VA: 0x2886DD0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx3dSource_SetVelocity(IntPtr ex_3d_source, ref CriAtomEx.NativeVector velocity);
		#else
		private static void criAtomEx3dSource_SetVelocity(IntPtr ex_3d_source, ref CriAtomEx.NativeVector velocity)
		{
			ExternLib.LibCriWare.criAtomEx3dSource_SetVelocity(ex_3d_source, ref velocity);
		}
		#endif

		// // RVA: 0x2886EF8 Offset: 0x2886EF8 VA: 0x2886EF8
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx3dSource_SetOrientation(IntPtr ex_3d_source, ref CriAtomEx.NativeVector front, ref CriAtomEx.NativeVector top);
		#else
		private static void criAtomEx3dSource_SetOrientation(IntPtr ex_3d_source, ref CriAtomEx.NativeVector front, ref CriAtomEx.NativeVector top)
		{
			ExternLib.LibCriWare.criAtomEx3dSource_SetOrientation(ex_3d_source, ref front, ref top);
		}
		#endif

		// // RVA: 0x2887010 Offset: 0x2887010 VA: 0x2887010
		// private static extern void criAtomEx3dSource_SetConeOrientation(IntPtr ex_3d_source, ref CriAtomEx.NativeVector cone_orient) { }

		// // RVA: 0x2887120 Offset: 0x2887120 VA: 0x2887120
		// private static extern void criAtomEx3dSource_SetConeParameter(IntPtr ex_3d_source, float inside_angle, float outside_angle, float outside_volume) { }

		// // RVA: 0x2887228 Offset: 0x2887228 VA: 0x2887228
		// private static extern void criAtomEx3dSource_SetMinMaxAttenuationDistance(IntPtr ex_3d_source, float min_distance, float max_distance) { }

		// // RVA: 0x2887330 Offset: 0x2887330 VA: 0x2887330
		// private static extern void criAtomEx3dSource_SetInteriorPanField(IntPtr ex_3d_source, float source_radius, float interior_distance) { }

		// // RVA: 0x2887430 Offset: 0x2887430 VA: 0x2887430
		// private static extern void criAtomEx3dSource_SetDopplerFactor(IntPtr ex_3d_source, float doppler_factor) { }

		// // RVA: 0x2887528 Offset: 0x2887528 VA: 0x2887528
		// private static extern void criAtomEx3dSource_SetVolume(IntPtr ex_3d_source, float volume) { }

		// // RVA: 0x2887618 Offset: 0x2887618 VA: 0x2887618
		// private static extern void criAtomEx3dSource_SetMaxAngleAisacDelta(IntPtr ex_3d_source, float max_delta) { }

		// // RVA: 0x2887710 Offset: 0x2887710 VA: 0x2887710
		// private static extern void criAtomEx3dSource_SetAttenuationDistanceSetting(IntPtr ex_3d_source, bool flag) { }

		// // RVA: 0x2887810 Offset: 0x2887810 VA: 0x2887810
		// private static extern bool criAtomEx3dSource_GetAttenuationDistanceSetting(IntPtr ex_3d_source) { }

		// // RVA: 0x2887AE8 Offset: 0x2887AE8 VA: 0x2887AE8
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx3dSource_SetRandomPositionConfig(IntPtr ex_3d_source, ref CriAtomEx.Randomize3dConfig config);
		#else
		private static void criAtomEx3dSource_SetRandomPositionConfig(IntPtr ex_3d_source, ref CriAtomEx.Randomize3dConfig config)
		{
			ExternLib.LibCriWare.criAtomEx3dSource_SetRandomPositionConfig(ex_3d_source, ref config);
		}
		#endif

		// // RVA: 0x2887A10 Offset: 0x2887A10 VA: 0x2887A10
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx3dSource_SetRandomPositionConfig(IntPtr ex_3d_source, IntPtr config);
		#else
		private static void criAtomEx3dSource_SetRandomPositionConfig(IntPtr ex_3d_source, IntPtr config)
		{
			ExternLib.LibCriWare.criAtomEx3dSource_SetRandomPositionConfig(ex_3d_source, config);
		}
		#endif

		// // RVA: 0x2887DD8 Offset: 0x2887DD8 VA: 0x2887DD8
		// private static extern void criAtomEx3dSource_SetRandomPositionList(IntPtr ex_3d_source, CriAtomEx.NativeVector[] position_list, uint length) { }

		// // RVA: 0x2887F40 Offset: 0x2887F40 VA: 0x2887F40
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomEx3dSource_Set3dRegionHn(IntPtr ex_3d_source, IntPtr ex_3d_region);
		#else
		private static void criAtomEx3dSource_Set3dRegionHn(IntPtr ex_3d_source, IntPtr ex_3d_region)
		{
			ExternLib.LibCriWare.criAtomEx3dSource_Set3dRegionHn(ex_3d_source, ex_3d_region);
		}
		#endif

		// // RVA: 0x2888030 Offset: 0x2888030 VA: 0x2888030
		// private static extern void criAtomEx3dSource_SetListenerBasedElevationAngleAisacControlId(IntPtr ex_3d_source, ushort aisac_control_id) { }

		// // RVA: 0x2888140 Offset: 0x2888140 VA: 0x2888140
		// private static extern void criAtomEx3dSource_SetSourceBasedElevationAngleAisacControlId(IntPtr ex_3d_source, ushort aisac_control_id) { }
	}
}