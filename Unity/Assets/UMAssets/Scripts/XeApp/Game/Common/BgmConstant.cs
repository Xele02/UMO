
namespace XeApp.Game.Common
{
    public static class BgmConstant
    {
        public static class Name
        {
            public static readonly int Title = BgmPlayer.MENU_BGM_ID_BASE + 2; // 0x0
            public static readonly int Prologue1 = BgmPlayer.PROLOGUE_BGM + 1; // 0x4
            public static readonly int Prologue2 = BgmPlayer.PROLOGUE_BGM + 2; // 0x8
            public static readonly int DownLoad = BgmPlayer.MENU_BGM_ID_BASE + 9; // 0xC
        }

        public const float TutorialDownLoadBgmVolume = 0.6f;
        public const float TutorialBgmChangeVolumeTime = 0.4f;
        public const float TutorialDownLoadBgmFadeOutTime = 0.4f;
    }
}
