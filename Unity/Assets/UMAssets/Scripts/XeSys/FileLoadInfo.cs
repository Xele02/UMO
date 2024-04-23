namespace XeSys
{
	public class FileLoadInfo
	{
		public string path { get; private set; } // 0x8
		public int pathHashCode { get; private set; } // 0xC
		public FileResultObject resultObject { get; private set; } // 0x10
		private FileLoadedPostProcess succeededCallback { get; set; } // 0x14
		private FileLoadedPostProcess failedCallback { get; set; } // 0x18
		public LBHFILLFAGA request { get; private set; } // 0x1C

		// // RVA: 0x203A11C Offset: 0x203A11C VA: 0x203A11C
		public FileLoadInfo(string path, FileLoadedPostProcess succeeded, FileLoadedPostProcess failed, LBHFILLFAGA req)
		{
			this.path = path;
			pathHashCode = path.GetHashCode();
			resultObject = null;
			succeededCallback = succeeded;
			failedCallback = failed;
			request = req;
		}

		// // RVA: 0x203A184 Offset: 0x203A184 VA: 0x203A184
		public bool Succeeded(FileResultObject fro)
		{
			resultObject = fro;
			if(succeededCallback != null)
				return succeededCallback(fro);
			return true;
		}

		// // RVA: 0x203A9F0 Offset: 0x203A9F0 VA: 0x203A9F0
		public bool Failed(FileResultObject fro)
		{
			resultObject = fro;
			if(failedCallback != null)
				return failedCallback(fro);
			return true;
		}
	}
}
