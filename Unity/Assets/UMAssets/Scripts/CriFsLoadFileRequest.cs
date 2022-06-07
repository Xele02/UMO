
public class CriFsLoadFileRequest : CriFsRequest
{
    private enum Phase
    {
        Stop = 0,
        Bind = 1,
        Load = 2,
        Done = 3,
        Error = 4,
    }

	// [CompilerGeneratedAttribute] // RVA: 0x634AA4 Offset: 0x634AA4 VA: 0x634AA4
	// private string <path>k__BackingField; // 0x28
	// [CompilerGeneratedAttribute] // RVA: 0x634AB4 Offset: 0x634AB4 VA: 0x634AB4
	// private byte[] <bytes>k__BackingField; // 0x2C
	private CriFsLoadFileRequest.Phase phase; // 0x30
	private CriFsBinder refBinder; // 0x34
	private CriFsBinder newBinder; // 0x38
	private uint bindId; // 0x3C
	private CriFsLoader loader; // 0x40
	private int readUnitSize; // 0x44
	private long fileSize; // 0x48

	public string path { get; set; }
	public byte[] bytes { get; set; }

	// // RVA: 0x2947D90 Offset: 0x2947D90 VA: 0x2947D90
	// public void .ctor(CriFsBinder srcBinder, string path, CriFsRequest.DoneDelegate doneDelegate, int readUnitSize) { }

	// // RVA: 0x2947EC4 Offset: 0x2947EC4 VA: 0x2947EC4 Slot: 7
	// protected override void Dispose(bool disposing) { }

	// // RVA: 0x2947F98 Offset: 0x2947F98 VA: 0x2947F98 Slot: 6
	public override void Stop()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x2948024 Offset: 0x2948024 VA: 0x2948024 Slot: 8
	// public override void Update() { }

	// // RVA: 0x2948070 Offset: 0x2948070 VA: 0x2948070
	// private void UpdateBinder() { }

	// // RVA: 0x29480E0 Offset: 0x29480E0 VA: 0x29480E0
	// private void UpdateLoader() { }

	// // RVA: 0x29482D4 Offset: 0x29482D4 VA: 0x29482D4
	// private void OnError() { }
}
