
namespace XeApp
{
    public sealed class AppEnv
    {
        public enum ExtraRomType
        {
            Normal = 0,
            CBT = 1,
            Presentation = 2,
        }

        public enum LetterBoxDirection
        {
            TopBottom = 0,
            LeftRight = 1,
            Count = 2,
        }

        public enum RegionType
        {
            Japan = 0,
            Count = 1,
        }

        public enum BuildType
        {
            Production = 0,
            Develop = 1,
            Count = 2,
        }

        public enum ActionServerType
        {
            name = 0,
            Count = 1,
        }

        public enum FileServerType
        {
            name = 0,
            Count = 1,
        }

        public enum PaymentServerType
        {
            name = 0,
            Count = 1,
        }

        public enum SakashoConnectTargetType
        {
            develop = 0,
            preview = 1,
            server_private = 2,
            release = 3,
            Count = 4,
        }

        public static bool isForceCBT = false; // 0x0
        public static bool isForcePresentation = false; // 0x1
        public const long BuildTime = 1492080904;
        public const float BaseWidth = 1184;
        public const float BaseHeight = 792;
        public static LetterBoxDirection letterBoxDirection = LetterBoxDirection.TopBottom; // 0x4
        private static RegionType mRegion = RegionType.Japan; // 0x8
        private static BuildType mBuild = BuildType.Develop; // 0xC
        private static ActionServerType mActionServerType = ActionServerType.name; // 0x10
        public static string[] actionServerUrl = new string[1] { "url" }; // 0x14
        private static FileServerType mFileServerType = FileServerType.name; // 0x18
        public static string[] fileServerUrl = new string[1] { "url" }; // 0x1C
        private static PaymentServerType mPaymentServerType = PaymentServerType.name; // 0x20
        public static string[] paymentServerUrl = new string[1] { "url" }; // 0x24
        private static SakashoConnectTargetType mSakashoConnectTargetType = SakashoConnectTargetType.develop; // 0x28
        public static readonly string[] sakashoConnectTargetType = new string[4] { "develop", "preview", "server_private", "release" }; // 0x2C

        public static RegionType Region { get { return mRegion; } set { mRegion = value; } } //0xE0C998 0xE0CA24
        public static BuildType Build { get { return mBuild; } set { mBuild = value; } } //0xE0CAB4 0xE0CB40
        public static ActionServerType actionServerType { get { return mActionServerType; } set { mActionServerType = value; } } //0xE0C80C 0xE0CBD0
        public static FileServerType fileServerType { get { return mFileServerType; } set { mFileServerType = value; } } //0xE0C6B8 0xE0CC60
        public static PaymentServerType paymentServerType { get { return mPaymentServerType; } set { mPaymentServerType = value; } } //0xE0CCF0 0xE0CD7C
        public static SakashoConnectTargetType SakashoConnectTarget { get { return mSakashoConnectTargetType; } set { mSakashoConnectTargetType = value; } } //0xE0CE0C 0xE0CE98

        // // RVA: 0xE0C4E0 Offset: 0xE0C4E0 VA: 0xE0C4E0
        // public static string GetStreamingAssetFilePath(string filename) { }

        // // RVA: 0xE0C550 Offset: 0xE0C550 VA: 0xE0C550
        // public static string GetStorageFilePath(string filename) { }

        // // RVA: 0xE0C5E0 Offset: 0xE0C5E0 VA: 0xE0C5E0
        // public static string GetFileServerUrl(string filename) { }

        // // RVA: 0xE0C744 Offset: 0xE0C744 VA: 0xE0C744
        // public static string GetActionRootUrl() { }

        // // RVA: 0xE0C898 Offset: 0xE0C898 VA: 0xE0C898
        public static SakashoConnectTargetType GetSakashoConnectTarget()
        {
            return SakashoConnectTargetType.release;
        }

        // // RVA: 0xE0C8A0 Offset: 0xE0C8A0 VA: 0xE0C8A0
        // public static AppEnv.ExtraRomType GetExtraRomType() { }

        // // RVA: 0xE0C8A8 Offset: 0xE0C8A8 VA: 0xE0C8A8
        public static bool IsCBT()
		{
			return false;
		}

        // // RVA: 0xE0C920 Offset: 0xE0C920 VA: 0xE0C920
        public static bool IsPresentation()
        {
            return false;
        }
    }
}
