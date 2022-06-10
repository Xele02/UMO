
namespace XeApp.Game.Common
{
    public static class BgmConstant
    {
        public static class Name
        {
            public static readonly int Title; // 0x0
            public static readonly int Prologue1; // 0x4
            public static readonly int Prologue2; // 0x8
            public static readonly int DownLoad; // 0xC

            // RVA: 0xE609AC Offset: 0xE609AC VA: 0xE609AC
            // private static void .cctor() { }
        }

        public const float TutorialDownLoadBgmVolume = 0.6f;
        public const float TutorialBgmChangeVolumeTime = 0.4f;
        public const float TutorialDownLoadBgmFadeOutTime = 0.4f;
    }
}
