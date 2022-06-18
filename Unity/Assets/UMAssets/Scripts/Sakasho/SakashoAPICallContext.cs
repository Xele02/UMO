
public class SakashoAPICallContext
{
    public delegate bool CancelAPICallDelegate(int callId);

	public const int CALL_ID_VOID = 0;
	private static bool initialized; // 0x0
	private static SakashoAPICallContext.CancelAPICallDelegate cancelAPICallDelegate; // 0x4

	public int CallId { get; set; } // 0x8

	// // RVA: 0x30784A0 Offset: 0x30784A0 VA: 0x30784A0
	public SakashoAPICallContext(int callId)
    {
        CallId = callId;
    }

	// // RVA: 0x30784D0 Offset: 0x30784D0 VA: 0x30784D0
	public static void Initialize(SakashoAPICallContext.CancelAPICallDelegate cancelAPICallDelegate)
	{
		if(initialized)
			return;
		initialized = true;
		SakashoAPICallContext.cancelAPICallDelegate = cancelAPICallDelegate;
	}

	// // RVA: 0x307855C Offset: 0x307855C VA: 0x307855C
	// public static void Finish() { }

	// // RVA: 0x30785CC Offset: 0x30785CC VA: 0x30785CC
	public bool CancelAPICall()
    {
        UnityEngine.Debug.LogError("TODO");
        return false;
    }

	// // RVA: 0x3078AF4 Offset: 0x3078AF4 VA: 0x3078AF4
	// public bool IsCancellable() { }
}
