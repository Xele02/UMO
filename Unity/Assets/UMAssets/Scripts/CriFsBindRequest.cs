
public class CriFsBindRequest : CriFsRequest
{
    public enum BindType
    {
        Cpk = 0,
        Directory = 1,
        File = 2,
    }

	// [CompilerGeneratedAttribute] // RVA: 0x634B14 Offset: 0x634B14 VA: 0x634B14
	// private string <path>k__BackingField; // 0x28
	// [CompilerGeneratedAttribute] // RVA: 0x634B24 Offset: 0x634B24 VA: 0x634B24
	// private uint <bindId>k__BackingField; // 0x2C

	public string path { get; set; }
	public uint bindId { get; set; }

	// [CompilerGeneratedAttribute] // RVA: 0x6362B8 Offset: 0x6362B8 VA: 0x6362B8
	// // RVA: 0x2943FC4 Offset: 0x2943FC4 VA: 0x2943FC4
	// public string get_path() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6362C8 Offset: 0x6362C8 VA: 0x6362C8
	// // RVA: 0x2943FCC Offset: 0x2943FCC VA: 0x2943FCC
	// private void set_path(string value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6362D8 Offset: 0x6362D8 VA: 0x6362D8
	// // RVA: 0x2943FD4 Offset: 0x2943FD4 VA: 0x2943FD4
	// public uint get_bindId() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6362E8 Offset: 0x6362E8 VA: 0x6362E8
	// // RVA: 0x2943FDC Offset: 0x2943FDC VA: 0x2943FDC
	// private void set_bindId(uint value) { }

	// // RVA: 0x2943FE4 Offset: 0x2943FE4 VA: 0x2943FE4
	// public void .ctor(CriFsBindRequest.BindType type, CriFsBinder targetBinder, CriFsBinder srcBinder, string path) { }

	// // RVA: 0x2944354 Offset: 0x2944354 VA: 0x2944354 Slot: 6
	// public override void Stop() { }

	// // RVA: 0x2944358 Offset: 0x2944358 VA: 0x2944358 Slot: 8
	// public override void Update() { }

	// // RVA: 0x29444CC Offset: 0x29444CC VA: 0x29444CC Slot: 7
	// protected override void Dispose(bool disposing) { }
}
