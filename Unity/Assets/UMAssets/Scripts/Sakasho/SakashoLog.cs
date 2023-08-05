using SakashoSystemCallback;

public class SakashoLog : SakashoAPIBase
{
	// // RVA: 0x2BCAF20 Offset: 0x2BCAF20 VA: 0x2BCAF20
	// private static SakashoAPICallContext SendLogInternal(SakashoLogData[] logData, bool useNewEndpoint, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BCB384 Offset: 0x2BCB384 VA: 0x2BCB384
	// public static SakashoAPICallContext SendLog(string label, string jsonData, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2BCB4E0 Offset: 0x2BCB4E0 VA: 0x2BCB4E0
	public static SakashoAPICallContext SendLog(SakashoLogData[] logData, OnSuccess onSuccess, OnError onError)
    {
        TodoLogger.LogError(0, "TODO");
        return null;
    }

	// RVA: 0x2BCB508 Offset: 0x2BCB508 VA: 0x2BCB508
	// private static extern int SakashoLogSendLogInternal(int callbackId, string json) { }
}
