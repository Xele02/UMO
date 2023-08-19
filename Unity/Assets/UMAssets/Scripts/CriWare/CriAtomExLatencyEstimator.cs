
using System.Runtime.InteropServices;

public static class CriAtomExLatencyEstimator
{
    public enum Status
    {
        Stop = 0,
        Processing = 1,
        Done = 2,
        Error = 3,
    }

	[StructLayout(LayoutKind.Sequential)]
    public struct EstimatorInfo
    {
        public CriAtomExLatencyEstimator.Status status; // 0x0
        public uint estimated_latency; // 0x4
    }

	// // RVA: 0x289B3F0 Offset: 0x289B3F0 VA: 0x289B3F0
	public static void InitializeModule()
	{
	#if !UNITY_EDITOR && UNITY_ANDROID
		criAtomLatencyEstimator_Initialize_ANDROID();
	#endif
	}

	// // RVA: 0x289B4DC Offset: 0x289B4DC VA: 0x289B4DC
	public static void FinalizeModule()
	{
	#if !UNITY_EDITOR && UNITY_ANDROID
		criAtomLatencyEstimator_Finalize_ANDROID();
	#endif
    }

	// // RVA: 0x289B5C4 Offset: 0x289B5C4 VA: 0x289B5C4
	public static EstimatorInfo GetCurrentInfo()
    {
#if UNITY_ANDROID
		return criAtomLatencyEstimator_GetCurrentInfo_ANDROID();
#else
		EstimatorInfo info = new EstimatorInfo();
		info.status = Status.Done;
		info.estimated_latency = 0;
		return info;
#endif
	}

	// // RVA: 0x289B3F8 Offset: 0x289B3F8 VA: 0x289B3F8
#if UNITY_ANDROID
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomLatencyEstimator_Initialize_ANDROID();
#else
	private static void criAtomLatencyEstimator_Initialize_ANDROID()
	{
		
	}
#endif

	// // RVA: 0x289B4E0 Offset: 0x289B4E0 VA: 0x289B4E0
#if UNITY_ANDROID
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomLatencyEstimator_Finalize_ANDROID();
#else
	private static void criAtomLatencyEstimator_Finalize_ANDROID()
	{

	}
#endif

	// // RVA: 0x289B5D8 Offset: 0x289B5D8 VA: 0x289B5D8
#if UNITY_ANDROID
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern EstimatorInfo criAtomLatencyEstimator_GetCurrentInfo_ANDROID();
#else
	private static CriAtomExLatencyEstimator.EstimatorInfo criAtomLatencyEstimator_GetCurrentInfo_ANDROID()
	{
		return new CriAtomExLatencyEstimator.EstimatorInfo();
	}
#endif
}
