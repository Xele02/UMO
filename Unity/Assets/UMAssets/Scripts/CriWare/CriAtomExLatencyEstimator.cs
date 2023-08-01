
public static class CriAtomExLatencyEstimator
{
    public enum Status
    {
        Stop = 0,
        Processing = 1,
        Done = 2,
        Error = 3,
    }

    public struct EstimatorInfo
    {
        public CriAtomExLatencyEstimator.Status status; // 0x0
        public uint estimated_latency; // 0x4
    }

	// // RVA: 0x289B3F0 Offset: 0x289B3F0 VA: 0x289B3F0
	public static void InitializeModule()
	{
		TodoLogger.LogError(TodoLogger.CriAtomExLatencyEstimator, "CriAtomExLatencyEstimator.InitializeModule");
	}

	// // RVA: 0x289B4DC Offset: 0x289B4DC VA: 0x289B4DC
	public static void FinalizeModule()
	{
        TodoLogger.LogError(TodoLogger.CriAtomExLatencyEstimator, "CriAtomExLatencyEstimator.FinalizeModule");
    }

	// // RVA: 0x289B5C4 Offset: 0x289B5C4 VA: 0x289B5C4
	public static EstimatorInfo GetCurrentInfo()
    {
#if UNITY_ANDROID
		TodoLogger.Log(5, "CriAtomExLatencyEstimator GetCurrentInfo");
		return new EstimatorInfo();
#else
		EstimatorInfo info = new EstimatorInfo();
		info.status = Status.Done;
		info.estimated_latency = 0;
		return info;
#endif
	}

	// // RVA: 0x289B3F8 Offset: 0x289B3F8 VA: 0x289B3F8
	// private static extern void criAtomLatencyEstimator_Initialize_ANDROID() { }

	// // RVA: 0x289B4E0 Offset: 0x289B4E0 VA: 0x289B4E0
	// private static extern void criAtomLatencyEstimator_Finalize_ANDROID() { }

	// // RVA: 0x289B5D8 Offset: 0x289B5D8 VA: 0x289B5D8
	// private static extern CriAtomExLatencyEstimator.EstimatorInfo criAtomLatencyEstimator_GetCurrentInfo_ANDROID() { }
}
