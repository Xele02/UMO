
namespace XeApp.Game.Common
{ 
	public class ItemRarity
	{
		public enum Type
		{
			None = 0,
			Star1 = 1,
			Star2 = 2,
			Star3 = 3,
			Star4 = 4,
			Star5 = 5,
			Num = 6,
		}

		public static int ArrayNum { get { return 5; } private set { return; } } //0x1102CC0 0x1102CC8
	}
}
