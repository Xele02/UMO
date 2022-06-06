namespace XeSys
{
	public class FileLoadInfo
	{
		// [CompilerGeneratedAttribute] // RVA: 0x652B5C Offset: 0x652B5C VA: 0x652B5C
		// private string <path>k__BackingField; // 0x8
		// [CompilerGeneratedAttribute] // RVA: 0x652B6C Offset: 0x652B6C VA: 0x652B6C
		// private int <pathHashCode>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x652B7C Offset: 0x652B7C VA: 0x652B7C
		// private FileResultObject <resultObject>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x652B8C Offset: 0x652B8C VA: 0x652B8C
		// private FileLoadedPostProcess <succeededCallback>k__BackingField; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x652B9C Offset: 0x652B9C VA: 0x652B9C
		// private FileLoadedPostProcess <failedCallback>k__BackingField; // 0x18
		// [CompilerGeneratedAttribute] // RVA: 0x652BAC Offset: 0x652BAC VA: 0x652BAC
		// private LBHFILLFAGA <request>k__BackingField; // 0x1C

		public string path { get; set; }
		public int pathHashCode { get; set; }
		public FileResultObject resultObject { get; set; }
		private FileLoadedPostProcess succeededCallback { get; set; }
		private FileLoadedPostProcess failedCallback { get; set; }
		public LBHFILLFAGA request { get; set; }

		// // RVA: 0x203A11C Offset: 0x203A11C VA: 0x203A11C
		public FileLoadInfo(string path, FileLoadedPostProcess succeeded, FileLoadedPostProcess failed, LBHFILLFAGA req)
		{
		}

		// // RVA: 0x203A184 Offset: 0x203A184 VA: 0x203A184
		// public bool Succeeded(FileResultObject fro) { }

		// // RVA: 0x203A9F0 Offset: 0x203A9F0 VA: 0x203A9F0
		// public bool Failed(FileResultObject fro) { }
	}
}
