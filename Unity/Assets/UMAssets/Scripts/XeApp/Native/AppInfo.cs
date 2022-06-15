
namespace XeApp.Native
{
    public class AppInfo
    {
        private static bool initialized; // 0x0
        private static string appVersion_; // 0x4
        private static string buildVersion_; // 0x8
        private static string buildOption_ = ""; // 0xC
        private static int secureVer_; // 0x10
        private static bool isExistCopyAsset_; // 0x14
        private static int abiType_; // 0x18
        private static string map_url = ""; // 0x1C

        // public static string appVersion { get; }
        public static string buildVersion { get {
            if(!initialized)
                Init();
            return buildVersion_;
        } } // get_buildVersion 0x2F94200
        // public static int secureVer { get; }
        // public static string buildType { get; }
        public static string buildOption { get {
            if(!initialized)
                Init();
            return buildOption_;
        } } // get_buildOption 0x2F94458
        // public static bool isExistCopyAsset { get; }
        // public static int abiType { get; }

        // // RVA: 0x2F93D48 Offset: 0x2F93D48 VA: 0x2F93D48
        // public static string get_appVersion() { }

        // // RVA: 0x2F942F8 Offset: 0x2F942F8 VA: 0x2F942F8
        // public static int get_secureVer() { }

        // // RVA: 0x2F943FC Offset: 0x2F943FC VA: 0x2F943FC
        // public static string get_buildType() { }

        // // RVA: 0x2F94550 Offset: 0x2F94550 VA: 0x2F94550
        // public static bool get_isExistCopyAsset() { }

        // // RVA: 0x2F93E50 Offset: 0x2F93E50 VA: 0x2F93E50
        private static void Init()
        {
            // Game is searching info in android AppManifest. This is the values for apk 5.3.1 :
            //"jp.co.xeen.xeapp.AppVersion"
            //"getVersionName"
            //Context var0 = UnityPlayer.currentActivity.getApplicationContext();
            //var2 = var0.getPackageManager().getPackageInfo(var0.getPackageName(), 0).versionName;
            appVersion_ = "5.3.1";

            //"getVersionCode"
            //var0 = var1.getPackageManager().getPackageInfo(var1.getPackageName(), 0).versionCode;
            buildVersion_ = "487";

            //"getMetaData"
            //var0 = var1.getPackageManager().getApplicationInfo(var1.getPackageName(), 128).metaData.getString(var0);
            //ANALYTICS_OPTION
            buildOption_ = "x7sH1ipz";

            secureVer_ = 487 ^ 0x856225;

            //"img/cp.png"
            //"isExistAssets"
            //var6 = var3.getAssets().open(var0);
            isExistCopyAsset_ = false;
            
            abiType_ = xedec_get_abi_type();

            initialized = true;
        }

        // // RVA: 0x2F94748 Offset: 0x2F94748 VA: 0x2F94748
        // private static AndroidJavaObject GetPackageInfo() { }

        // // RVA: 0x2F94A74 Offset: 0x2F94A74 VA: 0x2F94A74
        // public static string GetMapParam() { }

        // // RVA: 0x2F94BE8 Offset: 0x2F94BE8 VA: 0x2F94BE8
        // public static void ClearMapParam() { }

        // // RVA: 0x2F94C84 Offset: 0x2F94C84 VA: 0x2F94C84
        // public static void SetMapParam(string url) { }

        // // RVA: 0x2F94D14 Offset: 0x2F94D14 VA: 0x2F94D14
        // public static int get_abiType() { }

        // // RVA: 0x2F94648 Offset: 0x2F94648 VA: 0x2F94648
        private static /*extern*/ int xedec_get_abi_type()
        {
            UnityEngine.Debug.LogWarning("TODO xedec_get_abi_type");
            return 0;
        }
    }
}