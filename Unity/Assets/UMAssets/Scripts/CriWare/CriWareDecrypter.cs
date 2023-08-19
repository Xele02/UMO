using System;
using System.Runtime.InteropServices;
using AOT;

public class CriWareDecrypter
{
	private static ulong temporalStorage; // 0x0

	// // RVA: 0x2BA94BC Offset: 0x2BA94BC VA: 0x2BA94BC
	public static bool Initialize(CriWareDecrypterConfig config)
    {
		return Initialize(config.key, config.authenticationFile, config.enableAtomDecryption, config.enableManaDecryption);
    }

	// // RVA: 0x2BA95B4 Offset: 0x2BA95B4 VA: 0x2BA95B4
	public static bool Initialize(string key, string authenticationFile, bool enableAtomDecryption, bool enableManaDecryption)
    {
		if(CriFsPlugin.IsLibraryInitialized())
		{
			if(CriWare.Common.CheckBinaryVersionCompatibility())
			{
				ulong v = 0xd47eb533aef7e5;
				if(key.Length != 0)
				{
					v = System.Convert.ToUInt64(key) ^ 0xd47eb533aef7e5;
				}
				if(CriWare.Common.IsStreamingAssetsPath(authenticationFile))
				{
					System.IO.Path.Combine(CriWare.Common.streamingAssetsPath, authenticationFile);
				}
				temporalStorage = v;
				CRIWARE385C9322(enableAtomDecryption, enableManaDecryption, CallbackFromNative, IntPtr.Zero);
				temporalStorage = 0;
				return true;
			}
		}
        return false;
    }

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate ulong CallbackFromNativeDelegate(IntPtr ptr1);
	
	[MonoPInvokeCallback(typeof(CallbackFromNativeDelegate))] // RVA: 0x636464 Offset: 0x636464 VA: 0x636464
	// // RVA: 0x2BA9430 Offset: 0x2BA9430 VA: 0x2BA9430
	private static ulong CallbackFromNative(IntPtr ptr1)
	{
		return temporalStorage;
	}

	// // RVA: 0x2BA9878 Offset: 0x2BA9878 VA: 0x2BA9878

#if UNITY_ANDROID
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	public static extern int CRIWARE385C9322(bool enable_atom_decryption, bool enable_mana_decryption, CriWareDecrypter.CallbackFromNativeDelegate func, IntPtr obj);
#else
	public static int CRIWARE385C9322(bool enable_atom_decryption, bool enable_mana_decryption, CriWareDecrypter.CallbackFromNativeDelegate func, IntPtr obj)
	{
		return 0;
	}
#endif
}
