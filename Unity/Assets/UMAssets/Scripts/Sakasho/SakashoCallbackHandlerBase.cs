
public abstract class SakashoCallbackHandlerBase : ISakashoCallbackHandler
{
	private int callbackId; // 0x8

	// RVA: 0x3078D98 Offset: 0x3078D98 VA: 0x3078D98
	public SakashoCallbackHandlerBase(int callbackId)
    {
        this.callbackId = callbackId;
    }

	// RVA: -1 Offset: -1 Slot: 5
	public abstract void Callback(string message);

	// // RVA: 0x3078DB8 Offset: 0x3078DB8 VA: 0x3078DB8
	// protected void RemoveCallback() { }
}
