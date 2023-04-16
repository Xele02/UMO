
namespace XeApp.Game.Common
{
    public class LastGameUnlockStatus
    {
        public enum TypeBit
        {
            LN_First_4 = 1,
            LN_First_6 = 2,
            DF_NORMAL_4 = 8,
            DF_HARD_4 = 16,
            DF_HARD_6 = 32,
            DF_VERY_HARD_4 = 64,
            DF_VERY_HARD_6 = 128,
            DF_EXTREME_4 = 256,
            UL_LINE_6 = 1024,
            LIVE_SKIP_First_4 = 2048,
            LIVE_SKIP_First_6 = 4096,
        }

        public const TypeBit LN_ALL = (TypeBit)3;
        public const TypeBit DF_LINE4_ALL = (TypeBit)88;
        public const TypeBit DF_LINE6_ALL = (TypeBit)160;
        public const TypeBit DF_ALL = (TypeBit)248;
        public const TypeBit DIFFICULTY_ALL = (TypeBit)1275;
        public const TypeBit LIVE_SKIP_ALL = (TypeBit)6144;
    }
}