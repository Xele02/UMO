namespace XeApp.Game.Common
{
	public class Difficulty
	{
		public enum Type
		{
			Easy = 0,
			Normal = 1,
			Hard = 2,
			VeryHard = 3,
			Extreme = 4,
			Num = 5,
			Illegal = 6,
		}

		public static readonly string[] Name = new string[5] { "EASY", "NORMAL", "HARD", "VERY HARD", "EXTREME" }; // 0x0
	}
}
