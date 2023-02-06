
namespace SecureLib
{
    public class SecureLibAPI
    {
        // // RVA: 0x2E71710 Offset: 0x2E71710 VA: 0x2E71710
        // private static extern void __sl_sau() { }

        // // RVA: 0x2E717F8 Offset: 0x2E717F8 VA: 0x2E717F8
        // private static extern bool __sl_dr() { }

        // // RVA: 0x2E718E8 Offset: 0x2E718E8 VA: 0x2E718E8
        // private static extern bool __sl_djd() { }

        // // RVA: 0x2E719D8 Offset: 0x2E719D8 VA: 0x2E719D8
        // private static extern bool __sl_de() { }

        // // RVA: 0x2E71AC8 Offset: 0x2E71AC8 VA: 0x2E71AC8
        // private static extern string __sl_gsi() { }

        // // RVA: 0x2E71BC8 Offset: 0x2E71BC8 VA: 0x2E71BC8
        // private static extern string __sl_gdi() { }

        // // RVA: 0x2E71CC8 Offset: 0x2E71CC8 VA: 0x2E71CC8
        // private static extern string __sl_gslhs() { }

        // // RVA: 0x2E71DD0 Offset: 0x2E71DD0 VA: 0x2E71DD0
        // private static extern bool __sl_cslt(string wl) { }

        // // RVA: 0x2E71EF4 Offset: 0x2E71EF4 VA: 0x2E71EF4
        static SecureLibAPI()
		{
            TodoLogger.Log(TodoLogger.SecureLibAPI, "SecureLibAPI.SecureLibAPI");
		}

        // // RVA: 0x2E71EF8 Offset: 0x2E71EF8 VA: 0x2E71EF8
        public static bool isRooted()
        {
            TodoLogger.Log(TodoLogger.SecureLibAPI, "SecureLibAPI.isRooted");
            return false;
        }

        // // RVA: 0x2E71F70 Offset: 0x2E71F70 VA: 0x2E71F70
        public static bool isDebuggerAttachedJava()
        {
            TodoLogger.Log(TodoLogger.SecureLibAPI, "SecureLibAPI.isDebuggerAttachedJava");
            return false;
        }

        // // RVA: 0x2E71FE8 Offset: 0x2E71FE8 VA: 0x2E71FE8
        public static bool isDebuggerAttachedNative()
        {
            TodoLogger.Log(TodoLogger.SecureLibAPI, "SecureLibAPI.isDebuggerAttachedNative");
            return false;
        }

        // // RVA: 0x2E71FF0 Offset: 0x2E71FF0 VA: 0x2E71FF0
        public static void denyDebuggerAttach()
        {
            return;
        }

        // // RVA: 0x2E71FF4 Offset: 0x2E71FF4 VA: 0x2E71FF4
        public static bool isEmulator()
        {
            TodoLogger.Log(TodoLogger.SecureLibAPI, "SecureLibAPI.isEmulator");
            return false;
        }

        // // RVA: 0x2E7206C Offset: 0x2E7206C VA: 0x2E7206C
        // public static string getSignature() { }

        // // RVA: 0x2E720E4 Offset: 0x2E720E4 VA: 0x2E720E4
        // public static string getApkSha1Digest() { }

        // // RVA: 0x2E7215C Offset: 0x2E7215C VA: 0x2E7215C
        // public static string getCodeDigest() { }

        // // RVA: 0x2E721D4 Offset: 0x2E721D4 VA: 0x2E721D4
        // public static bool checkCodeDigest(string whiteList) { }

        // // RVA: 0x2E72254 Offset: 0x2E72254 VA: 0x2E72254
        // public static bool isHooked() { }
    }
}
