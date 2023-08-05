public class StorageSupport
{
	// // RVA: 0x2E72264 Offset: 0x2E72264 VA: 0x2E72264
	public static bool IsAvailableStorage()
    {
		int avaiable = GetAvailableStorageSizeMB();
		if (avaiable > -1)
			return avaiable > 49;
        return true;
    }

	// // RVA: 0x2E72290 Offset: 0x2E72290 VA: 0x2E72290
	public static int GetAvailableStorageSizeMB()
	{
#if UNITY_ANDROID
		TodoLogger.Log(TodoLogger.StorageSupport, "GetAvailableStorageSizeMB");
#endif
		return 10000;
	}

	// // RVA: 0x2E723D0 Offset: 0x2E723D0 VA: 0x2E723D0
	// public static bool FileExists(string path) { }

	// // RVA: 0x2E72490 Offset: 0x2E72490 VA: 0x2E72490
	// public static bool DirectoryExists(string path) { }

	// // RVA: 0x2E723E8 Offset: 0x2E723E8 VA: 0x2E723E8
	// public static int GetStat(string path) { }

	// // RVA: 0x2E72498 Offset: 0x2E72498 VA: 0x2E72498
	// private static extern int xedec_stat(IntPtr path, int path_len) { }

	// // RVA: 0x2E725A0 Offset: 0x2E725A0 VA: 0x2E725A0
	// private static extern int xedec_get_files(IntPtr path, int len, IntPtr resultBuf, int resultBufSize) { }

	// // RVA: 0x2E726BC Offset: 0x2E726BC VA: 0x2E726BC
	// public static string[] GetFilesAllDirectory(string path) { }
}
