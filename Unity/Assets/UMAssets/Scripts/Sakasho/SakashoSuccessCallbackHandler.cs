using SakashoSystemCallback;

public class SakashoSuccessCallbackHandler : SakashoCallbackHandlerBase
{
	private OnSuccess onSuccess; // 0xC

	// RVA: 0x3079808 Offset: 0x3079808 VA: 0x3079808
	public SakashoSuccessCallbackHandler(int callbackId, OnSuccess onSuccess) : base(callbackId)
    {
        this.onSuccess = onSuccess;
    }

	// RVA: 0x3081E44 Offset: 0x3081E44 VA: 0x3081E44 Slot: 5
	public override void Callback(string message)
    {
        UnityEngine.Debug.LogError("TODO");
    }
}
