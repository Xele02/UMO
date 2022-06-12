
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

	private CriFsLoadFileRequest.Phase phase; // 0x30
	private CriFsBinder refBinder; // 0x34
	private CriFsBinder newBinder; // 0x38
	private uint bindId; // 0x3C
	private CriFsLoader loader; // 0x40
	private int readUnitSize; // 0x44
	private long fileSize; // 0x48

	public string path { get; set; } // 0x28
	public byte[] bytes { get; set; } // 0x2C

	// // RVA: 0x2947D90 Offset: 0x2947D90 VA: 0x2947D90
	public CriFsLoadFileRequest(CriFsBinder srcBinder, string path, CriFsRequest.DoneDelegate doneDelegate, int readUnitSize)
	{
		this.doneDelegate = doneDelegate;
		this.path = path;
		this.readUnitSize = readUnitSize;
		if(srcBinder == null)
		{
			CriFsBinder binder = new CriFsBinder();
			refBinder = binder;
			newBinder = binder;
			bindId = binder.BindFile(null, path);
			phase = CriFsLoadFileRequest.Phase.Bind;
		}
		else
		{
			refBinder = srcBinder;
			newBinder = null;
			fileSize = srcBinder.GetFileSize(path);
			phase = CriFsLoadFileRequest.Phase.Load;
			if(fileSize < 0)
				phase = CriFsLoadFileRequest.Phase.Error;
		}
		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Fs);
	}

	// // RVA: 0x2947EC4 Offset: 0x2947EC4 VA: 0x2947EC4 Slot: 7
	// protected override void Dispose(bool disposing) { }

	// // RVA: 0x2947F98 Offset: 0x2947F98 VA: 0x2947F98 Slot: 6
	public override void Stop()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x2948024 Offset: 0x2948024 VA: 0x2948024 Slot: 8
	public override void Update()
	{
		if(phase == CriFsLoadFileRequest.Phase.Bind)
		{
			UpdateBinder();
		}
		if(phase == CriFsLoadFileRequest.Phase.Load)
		{
			UpdateLoader();
		}
		if(phase != CriFsLoadFileRequest.Phase.Error)
			return;

		OnError();
	}

	// // RVA: 0x2948070 Offset: 0x2948070 VA: 0x2948070
	private void UpdateBinder()
	{
		CriFsBinder.Status status = CriFsBinder.GetStatus(bindId);
		if(status == CriFsBinder.Status.Analyze)
		{
			return;
		}
		fileSize = -1;
		if(status == CriFsBinder.Status.Complete)
		{
			fileSize = refBinder.GetFileSize(path);
		}
		phase = CriFsLoadFileRequest.Phase.Error;
		if(fileSize >= 0)
			phase = CriFsLoadFileRequest.Phase.Load;
	}

	// // RVA: 0x29480E0 Offset: 0x29480E0 VA: 0x29480E0
	private void UpdateLoader()
	{
		if(loader == null)
		{
			loader = new CriFsLoader();
			loader.SetReadUnitSize(readUnitSize);
			bytes = new byte[fileSize];
			loader.Load(refBinder, path, 0, fileSize, bytes);
		}
		CriFsLoader.Status status = loader.GetStatus();
		if(status == CriFsLoader.Status.Error)
		{
			phase = CriFsLoadFileRequest.Phase.Error;
		}
		else if(status != CriFsLoader.Status.Loading)
		{
			if(phase == CriFsLoadFileRequest.Phase.Stop)
				bytes = null;
			phase = CriFsLoadFileRequest.Phase.Done;
			loader.Dispose();
			if(newBinder != null)
				newBinder.Dispose();
			isDone = true;
			if(doneDelegate != null)
				doneDelegate(this);
		}
	}

	// // RVA: 0x29482D4 Offset: 0x29482D4 VA: 0x29482D4
	private void OnError()
	{
		bytes = null;
		refBinder = null;
		error = "Error occurred.";
		if(newBinder != null)
		{
			newBinder.Dispose();
			newBinder = null;
		}
		if(loader != null)
		{
			loader.Dispose();
			loader = null;
		}
		isDone = true;
		phase = CriFsLoadFileRequest.Phase.Done;
		if(doneDelegate != null)
			doneDelegate(this);
	}
}
