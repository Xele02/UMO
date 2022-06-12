using System;

public class CriFsWebInstaller : CriDisposable
{
    public enum Status
    {
        Stop = 0,
        Busy = 1,
        Complete = 2,
        Error = 3,
    }

    public enum Error
    {
        None = 0,
        Timeout = 1,
        Memory = 2,
        LocalFs = 3,
        DNS = 4,
        Connection = 5,
        SSL = 6,
        HTTP = 7,
        Internal = 8,
    }

    public struct StatusInfo
    {
        public CriFsWebInstaller.Status status; // 0x0
        public CriFsWebInstaller.Error error; // 0x4
        public int httpStatusCode; // 0x8
        public long contentsSize; // 0x10
        public long receivedSize; // 0x18
    }

    public struct ModuleConfig
    {
        public uint numInstallers; // 0x0
        public string proxyHost; // 0x4
        public ushort proxyPort; // 0x8
        public string userAgent; // 0xC
        public uint inactiveTimeoutSec; // 0x10
        public bool allowInsecureSSL; // 0x14
        public bool crcEnabled; // 0x15
        public CriFsWebInstaller.ModulePlatformConfig platformConfig; // 0x16
    }

    public struct ModulePlatformConfig
    {
        public byte reserved; // 0x0

        public static CriFsWebInstaller.ModulePlatformConfig defaultConfig { get; }

        // RVA: 0x294DE24 Offset: 0x294DE24 VA: 0x294DE24
        // public static CriFsWebInstaller.ModulePlatformConfig get_defaultConfig() { }
    }

	// [CompilerGeneratedAttribute] // RVA: 0x634B44 Offset: 0x634B44 VA: 0x634B44
	// private static bool <isInitialized>k__BackingField; // 0x0
	// [CompilerGeneratedAttribute] // RVA: 0x634B54 Offset: 0x634B54 VA: 0x634B54
	// private static bool <isCrcEnabled>k__BackingField; // 0x1
	public const int InvalidHttpStatusCode = -1;
	public const long InvalidContentsSize = -1;
	private IntPtr handle; // 0x18

	public static bool isInitialized { get; set; }
	public static bool isCrcEnabled { get; set; }
	public static CriFsWebInstaller.ModuleConfig defaultModuleConfig { get; }

	// [CompilerGeneratedAttribute] // RVA: 0x636318 Offset: 0x636318 VA: 0x636318
	// // RVA: 0x294C3FC Offset: 0x294C3FC VA: 0x294C3FC
	// public static bool get_isInitialized() { }

	// [CompilerGeneratedAttribute] // RVA: 0x636328 Offset: 0x636328 VA: 0x636328
	// // RVA: 0x294DD34 Offset: 0x294DD34 VA: 0x294DD34
	// private static void set_isInitialized(bool value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x636338 Offset: 0x636338 VA: 0x636338
	// // RVA: 0x294DC04 Offset: 0x294DC04 VA: 0x294DC04
	// public static bool get_isCrcEnabled() { }

	// [CompilerGeneratedAttribute] // RVA: 0x636348 Offset: 0x636348 VA: 0x636348
	// // RVA: 0x294DD98 Offset: 0x294DD98 VA: 0x294DD98
	// private static void set_isCrcEnabled(bool value) { }

	// // RVA: 0x294DDFC Offset: 0x294DDFC VA: 0x294DDFC
	// public static CriFsWebInstaller.ModuleConfig get_defaultModuleConfig() { }

	// // RVA: 0x294D7A4 Offset: 0x294D7A4 VA: 0x294D7A4
	public CriFsWebInstaller()
    {
        UnityEngine.Debug.LogWarning("TODO CriFsWebInstaller()");
    }

	// // RVA: 0x294DF48 Offset: 0x294DF48 VA: 0x294DF48 Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0x294E0CC Offset: 0x294E0CC VA: 0x294E0CC Slot: 5
	public override void Dispose()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x294D8BC Offset: 0x294D8BC VA: 0x294D8BC
	// public void Copy(string url, string dstPath) { }

	// // RVA: 0x294D728 Offset: 0x294D728 VA: 0x294D728
	// public void Stop() { }

	// // RVA: 0x294DB28 Offset: 0x294DB28 VA: 0x294DB28
	public CriFsWebInstaller.StatusInfo GetStatusInfo()
    {
        CriFsWebInstaller.StatusInfo st;
        if(handle != null)
        {
            criFsWebInstaller_GetStatusInfo(handle, out st);
        }
        else
        {
            st = new CriFsWebInstaller.StatusInfo();
            st.contentsSize = -1;
            st.receivedSize = 0;
            st.httpStatusCode = 0;
            st.status = Status.Stop;
            st.error = Error.None;
        }
        return st;
    }

	// // RVA: 0x294DC68 Offset: 0x294DC68 VA: 0x294DC68
	// public bool GetCRC32(out uint ret_val) { }

	// // RVA: 0x294E59C Offset: 0x294E59C VA: 0x294E59C
	// public static void InitializeModule(CriFsWebInstaller.ModuleConfig config) { }

	// // RVA: 0x294E8A4 Offset: 0x294E8A4 VA: 0x294E8A4
	// public static void FinalizeModule() { }

	// // RVA: 0x294C460 Offset: 0x294C460 VA: 0x294C460
	public static void ExecuteMain()
    {
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0x294EC08 Offset: 0x294EC08 VA: 0x294EC08
	// public static bool SetRequestHeader(string field, string value) { }

	// // RVA: 0x294DFB0 Offset: 0x294DFB0 VA: 0x294DFB0
	// private void Dispose(bool disposing) { }

	// // RVA: 0x294E798 Offset: 0x294E798 VA: 0x294E798
	// private static extern int criFsWebInstaller_Initialize(in CriFsWebInstaller.ModuleConfig config) { }

	// // RVA: 0x294EA58 Offset: 0x294EA58 VA: 0x294EA58
	// private static extern int criFsWebInstaller_Finalize() { }

	// // RVA: 0x294EB30 Offset: 0x294EB30 VA: 0x294EB30
	// private static extern int criFsWebInstaller_ExecuteMain() { }

	// // RVA: 0x294DE30 Offset: 0x294DE30 VA: 0x294DE30
	// private static extern int criFsWebInstaller_Create(out IntPtr installer) { }

	// // RVA: 0x294ED50 Offset: 0x294ED50 VA: 0x294ED50
	// private static extern int criFsWebInstaller_Destroy(IntPtr installer) { }

	// // RVA: 0x294E160 Offset: 0x294E160 VA: 0x294E160
	// private static extern int criFsWebInstaller_Copy(IntPtr installer, string url, string dstPath) { }

	// // RVA: 0x294E2B8 Offset: 0x294E2B8 VA: 0x294E2B8
	// private static extern int criFsWebInstaller_Stop(IntPtr installer) { }

	// // RVA: 0x294E3D0 Offset: 0x294E3D0 VA: 0x294E3D0
	private static /*extern */int criFsWebInstaller_GetStatusInfo(IntPtr installer, out CriFsWebInstaller.StatusInfo status)
    {
        UnityEngine.Debug.LogError("TODO");
        status = new CriFsWebInstaller.StatusInfo();
        return 0;
    }

	// // RVA: 0x294E4B8 Offset: 0x294E4B8 VA: 0x294E4B8
	// private static extern int criFsWebInstaller_GetCRC32(IntPtr installer, out uint crc32) { }

	// // RVA: 0x294EC28 Offset: 0x294EC28 VA: 0x294EC28
	// private static extern int criFsWebInstaller_SetRequestHeader(string field, string value) { }
}
