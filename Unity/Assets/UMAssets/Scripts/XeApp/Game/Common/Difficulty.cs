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

		public static readonly string[] Name; // 0x0

		// RVA: 0xE6CF94 Offset: 0xE6CF94 VA: 0xE6CF94
		static Difficulty()
		{
			UnityEngine.Debug.LogError("TODO");
		}
	}
}
