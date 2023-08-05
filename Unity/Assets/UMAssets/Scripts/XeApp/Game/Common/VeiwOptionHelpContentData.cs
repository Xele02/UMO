
namespace XeApp.Game.Common
{ 
	public class VeiwOptionHelpContentData
	{
		public enum ContentType
		{
			Help = 0,
			Wiki = 1,
		}

		public enum ConditionId
		{
			None = 0,
			HighScoreRate = 1,
			VopClearCount = 2,
		}

		public enum ConditionOperation
		{
			None = 0,
			GreaterEqual = 1,
		}

		public ContentType contentType; // 0x8
		public int helpId; // 0xC
		public string wikiURL; // 0x10
		public string contentName; // 0x14

		//// RVA: 0xD309F4 Offset: 0xD309F4 VA: 0xD309F4
		//public void InitHelp(int helpId, string name) { }

		//// RVA: 0xD30A08 Offset: 0xD30A08 VA: 0xD30A08
		//public void InitWiki(string url, string name) { }
	}
}
