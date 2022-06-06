
public class CriFsRequest : CriDisposable
{
    public delegate void DoneDelegate(CriFsRequest request);
    
	// [CompilerGeneratedAttribute] // RVA: 0x634A64 Offset: 0x634A64 VA: 0x634A64
	// private CriFsRequest.DoneDelegate <doneDelegate>k__BackingField; // 0x18
	// [CompilerGeneratedAttribute] // RVA: 0x634A74 Offset: 0x634A74 VA: 0x634A74
	// private bool <isDone>k__BackingField; // 0x1C
	// [CompilerGeneratedAttribute] // RVA: 0x634A84 Offset: 0x634A84 VA: 0x634A84
	// private string <error>k__BackingField; // 0x20
	// [CompilerGeneratedAttribute] // RVA: 0x634A94 Offset: 0x634A94 VA: 0x634A94
	// private bool <isDisposed>k__BackingField; // 0x24

	public CriFsRequest.DoneDelegate doneDelegate { get; set; }
	public bool isDone { get; set; }
	public string error { get; set; }
	public bool isDisposed { get; set; }

	// // RVA: 0x294AEF8 Offset: 0x294AEF8 VA: 0x294AEF8 Slot: 5
	// public override void Dispose() { }

	// // RVA: 0x294AFA8 Offset: 0x294AFA8 VA: 0x294AFA8 Slot: 6
	// public virtual void Stop() { }

	// // RVA: 0x294AFAC Offset: 0x294AFAC VA: 0x294AFAC
	// public YieldInstruction WaitForDone(MonoBehaviour mb) { }

	// // RVA: 0x294B070 Offset: 0x294B070 VA: 0x294B070 Slot: 7
	// protected virtual void Dispose(bool disposing) { }

	// // RVA: 0x294B074 Offset: 0x294B074 VA: 0x294B074 Slot: 8
	// public virtual void Update() { }

	// // RVA: 0x29444B0 Offset: 0x29444B0 VA: 0x29444B0
	// protected void Done() { }

	// [IteratorStateMachineAttribute] // RVA: 0x636160 Offset: 0x636160 VA: 0x636160
	// // RVA: 0x294AFE4 Offset: 0x294AFE4 VA: 0x294AFE4
	// private IEnumerator CheckDone() { }

	// // RVA: 0x294B8C0 Offset: 0x294B8C0 VA: 0x294B8C0 Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0x2944168 Offset: 0x2944168 VA: 0x2944168
	// public void .ctor() { }
}