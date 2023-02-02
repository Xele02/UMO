public class CriWareDecrypter
{
	private static ulong temporalStorage; // 0x0

	// // RVA: 0x2BA94BC Offset: 0x2BA94BC VA: 0x2BA94BC
	public static bool Initialize(CriWareDecrypterConfig config)
    {
        TodoLogger.Log(0, "TODO");
        return false;
    }

	// // RVA: 0x2BA95B4 Offset: 0x2BA95B4 VA: 0x2BA95B4
	public static bool Initialize(string key, string authenticationFile, bool enableAtomDecryption, bool enableManaDecryption)
    {
        TodoLogger.Log(TodoLogger.CriWareDecrypter, "CriWareDecrypter.Initialize");
        return false;
    }

	// [MonoPInvokeCallbackAttribute] // RVA: 0x636464 Offset: 0x636464 VA: 0x636464
	// // RVA: 0x2BA9430 Offset: 0x2BA9430 VA: 0x2BA9430
	// private static ulong CallbackFromNative(IntPtr ptr1) { }

	// // RVA: 0x2BA9878 Offset: 0x2BA9878 VA: 0x2BA9878
	// public static extern int CRIWARE385C9322(bool enable_atom_decryption, bool enable_mana_decryption, CriWareDecrypter.CallbackFromNativeDelegate func, IntPtr obj) { }
}
