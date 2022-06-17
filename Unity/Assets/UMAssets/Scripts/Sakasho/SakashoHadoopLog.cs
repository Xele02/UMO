using SakashoSystemCallback;

public class SakashoHadoopLog : SakashoAPIBase
{
	// RVA: 0x2BC6754 Offset: 0x2BC6754 VA: 0x2BC6754
	public static SakashoAPICallContext SendLogToHadoop(SakashoHadoopLogData[] logData, OnSuccess onSuccess, OnError onError)
    {
        UnityEngine.Debug.LogError("TODO");
        return null;
    }

	// RVA: 0x2BC6B48 Offset: 0x2BC6B48 VA: 0x2BC6B48
	// private static extern int SakashoHadoopLogSendLogToHadoop(int callbackId, string json) { }
}
