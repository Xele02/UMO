
namespace XeApp.Game.Common
{
    public class GameAttribute
    {
		public enum Type
		{
			None = 0,
			Yellow = 1,
			Red = 2,
			Blue = 3,
			All = 4,
			Num = 5,
		}
        public static int ArrayNum { 
            get
            {
                // 0xE95CF4
                return 4;
            }
            set
            {
                // 0xE95CFC
                return;
            } 
        }
    }
}