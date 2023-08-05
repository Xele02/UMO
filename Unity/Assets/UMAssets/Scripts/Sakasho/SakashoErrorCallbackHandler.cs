using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoErrorCallbackHandler : SakashoCallbackHandlerBase
{
	private OnError onError; // 0xC

	// RVA: 0x3079830 Offset: 0x3079830 VA: 0x3079830
	public SakashoErrorCallbackHandler(int callbackId, OnError onError) : base(callbackId)
    {
        this.onError = onError;
    }

	// // RVA: 0x3080D8C Offset: 0x3080D8C VA: 0x3080D8C
	private static SakashoError jsonToSakashoError(string json)
	{
		Hashtable h = MiniJSON.jsonDecode(json) as Hashtable;
		double code = (double)h["responseCode"];
		string jsonData = (string)h["responseBodyJSON"];
		return new SakashoError((int)code, jsonData);
	}

	// RVA: 0x3081054 Offset: 0x3081054 VA: 0x3081054 Slot: 5
	public override void Callback(string message)
    {
		RemoveCallback();
		if (onError == null)
			return;
		SakashoCallbackRegistry.RunOnMainThread(() =>
		{
			//0x3081178
			onError(jsonToSakashoError(message));
		});
	}
}
