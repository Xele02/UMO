using System;

namespace CriWare
{

	public class CriAtomExAsrRack : CriDisposable
	{
		public struct Config
		{
			public float serverFrequency;
			public int numBuses;
			public int outputChannels;
			public int outputSamplingRate;
			public CriAtomEx.SoundRendererType soundRendererType;
			public int outputRackId;
		}

		public struct PlatformConfig
		{
			public byte reserved;
		}


		// public const int defaultRackId = 0;
		// private int _rackId; // 0x18

		// public int rackId { get; }
		// public static CriAtomExAsrRack.Config defaultConfig { get; }

		// // RVA: 0x2896E8C Offset: 0x2896E8C VA: 0x2896E8C
		public CriAtomExAsrRack(CriAtomExAsrRack.Config config, CriAtomExAsrRack.PlatformConfig platformConfig)
		{
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "TODO");
		}

		// // RVA: 0x2897124 Offset: 0x2897124 VA: 0x2897124
		// public static string GetAppliedDspBusSnapshotName(int rackId) { }

		// // RVA: 0x28972C0 Offset: 0x28972C0 VA: 0x28972C0
		// public CriAtomExAsrRack.PerformanceInfo GetPerformanceInfo() { }

		// // RVA: 0x2897494 Offset: 0x2897494 VA: 0x2897494
		// public static CriAtomExAsrRack.PerformanceInfo GetPerformanceInfoByRackId(int rackId = 0) { }

		// // RVA: 0x28974E8 Offset: 0x28974E8 VA: 0x28974E8
		// public void ResetPerformanceMonitor() { }

		// // RVA: 0x28975DC Offset: 0x28975DC VA: 0x28975DC
		// public static void ResetPerformanceMonitorByRackId(int rackId = 0) { }

		// // RVA: 0x28975E0 Offset: 0x28975E0 VA: 0x28975E0 Slot: 5
		public override void Dispose()
		{
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "TODO");
		}

		// // RVA: 0x28977D0 Offset: 0x28977D0 VA: 0x28977D0
		// public int get_rackId() { }

		// // RVA: 0x28977D8 Offset: 0x28977D8 VA: 0x28977D8
		// public static CriAtomExAsrRack.Config get_defaultConfig() { }

		// // RVA: 0x289785C Offset: 0x289785C VA: 0x289785C Slot: 1
		// protected override void Finalize() { }

		// // RVA: 0x2897018 Offset: 0x2897018 VA: 0x2897018
		// private static extern int CRIWAREE210EEA8(in CriAtomExAsrRack.Config config, in CriAtomExAsrRack.PlatformConfig platformConfig) { }

		// // RVA: 0x28976B8 Offset: 0x28976B8 VA: 0x28976B8
		// private static extern void criAtomExAsrRack_Destroy(int rackId) { }

		// // RVA: 0x28978D0 Offset: 0x28978D0 VA: 0x28978D0
		// private static extern void criAtomExAsrRack_AttachDspBusSetting(int rackId, string setting, IntPtr work, int workSize) { }

		// // RVA: 0x28979F0 Offset: 0x28979F0 VA: 0x28979F0
		// private static extern void criAtomExAsrRack_DetachDspBusSetting(int rackId) { }

		// // RVA: 0x28971D0 Offset: 0x28971D0 VA: 0x28971D0
		// private static extern IntPtr criAtomExAsrRack_GetAppliedDspBusSnapshotName(int rackId) { }

		// // RVA: 0x2897AD8 Offset: 0x2897AD8 VA: 0x2897AD8
		// private static extern void criAtomExAsrRack_ApplyDspBusSnapshot(int rackId, string snapshotName, int timeMs) { }

		// // RVA: 0x28973A8 Offset: 0x28973A8 VA: 0x28973A8
		// private static extern void criAtomExAsrRack_GetPerformanceInfo(int rackId, out CriAtomExAsrRack.PerformanceInfo perfInfo) { }

		// // RVA: 0x28974F0 Offset: 0x28974F0 VA: 0x28974F0
		// private static extern void criAtomExAsrRack_ResetPerformanceMonitor(int rackId) { }
	}
}
