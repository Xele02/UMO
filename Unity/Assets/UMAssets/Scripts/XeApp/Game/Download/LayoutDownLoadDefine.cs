namespace XeApp.Game.DownLoad
{
	public class LayoutDownLoadDefine
	{
		public enum DirectionType // TypeDefIndex: 8128
		{
			None = -1,
			Left = 0,
			Right = 1,
			Num = 2,
		}

		public class ViewDivaProfileData
		{
			public int id; // 0x8
			public string age = null; // 0xC
			public string birthday = null; // 0x10
			public string birthplace = null; // 0x14
			public string favorite = null; // 0x18
			public string description = ""; // 0x1C
		}

		public static readonly int DEFAULT_DIVA; // 0x0
	}
}
