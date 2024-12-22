using System.Collections;
using Sakasho.JSON;
using SakashoSystemCallback;

public class SakashoLog : SakashoAPIBase
{
	// // RVA: 0x2BCAF20 Offset: 0x2BCAF20 VA: 0x2BCAF20
	private static SakashoAPICallContext SendLogInternal(SakashoLogData[] logData, bool useNewEndpoint, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if(logData != null)
		{
			l = new ArrayList();
			for(int i = 0; i < logData.Length; i++)
			{
				Hashtable h2 = null;
				if(logData[i] != null)
				{
					h2 = new Hashtable();
					if(logData[i].Label != null)
					{
						h2["label"] = logData[i].Label;
					}
					if(logData[i].JsonData != null)
					{
						h2["jsonData"] = logData[i].JsonData;
					}
				}
				l.Add(h2);
			}
		}
		h["logData"] = l;
		h["useNewEndpoint"] = useNewEndpoint;
		return new SakashoAPICallContext(Call(SakashoLogSendLogInternal, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2BCB384 Offset: 0x2BCB384 VA: 0x2BCB384
	// public static SakashoAPICallContext SendLog(string label, string jsonData, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2BCB4E0 Offset: 0x2BCB4E0 VA: 0x2BCB4E0
	public static SakashoAPICallContext SendLog(SakashoLogData[] logData, OnSuccess onSuccess, OnError onError)
    {
        return SendLogInternal(logData, true, onSuccess, onError);
    }

	// RVA: 0x2BCB508 Offset: 0x2BCB508 VA: 0x2BCB508
	private static int SakashoLogSendLogInternal(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoLogSendLogInternal(callbackId, json);
	}
}
