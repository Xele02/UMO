
namespace XeApp.Game.Common
{
    public class FreeCategoryId
    {
        public enum Type
        {
            None = 0,
            Macross = 1,
            Seven = 2,
            Frontia = 3,
            Delta = 4,
            Event = 5,
            Other = 6,
            Num = 7,
            Illegal = 8,
        }

        public static int ArrayNum { get { return 6; } } //0x1C14B44
    }
}
