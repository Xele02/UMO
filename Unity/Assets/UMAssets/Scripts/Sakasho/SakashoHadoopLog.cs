using SakashoSystemCallback;
using System.Collections;

public class SakashoHadoopLog : SakashoAPIBase
{
	// RVA: 0x2BC6754 Offset: 0x2BC6754 VA: 0x2BC6754
	public static SakashoAPICallContext SendLogToHadoop(SakashoHadoopLogData[] logData, OnSuccess onSuccess, OnError onError)
    {
		Hashtable hash = new Hashtable();
		ArrayList ar = null;
		if (logData != null)
		{
			ar = new ArrayList();
			for(int i = 0; i < logData.Length; i++)
			{
				Hashtable h = null;
				if(logData[i] != null)
				{
					h = new Hashtable();
					if(logData[i].EventId != null)
					{
						h["eventId"] = logData[i].EventId;
					}
					if(logData[i].JsonData != null)
					{
						h["jsonData"] = logData[i].JsonData;
					}
				}
				ar.Add(h);
			}
		}
		hash[logData] = ar;

		int callID = Call(SakashoHadoopLogSendLogToHadoop, "", onSuccess, onError);
        return new SakashoAPICallContext(callID);
    }

	// RVA: 0x2BC6B48 Offset: 0x2BC6B48 VA: 0x2BC6B48
	private static /*extern */int SakashoHadoopLogSendLogToHadoop(int callbackId, string json)
    {
        return ExternLib.LibSakasho.SakashoHadoopLogSendLogToHadoop(callbackId, json);
    }
}
