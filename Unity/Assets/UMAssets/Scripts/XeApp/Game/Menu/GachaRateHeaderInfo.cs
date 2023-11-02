
namespace XeApp.Game.Menu
{ 
	public class GachaRateHeaderInfo : GachaRateInfo
	{
		public bool isLimited; // 0x8
		public string headerTitle; // 0xC
		public string s6Percent; // 0x10
		public string s5Percent; // 0x14
		public string s4Percent; // 0x18
		public string s3Percent; // 0x1C
		public string s2Percent; // 0x20
		public string s1Percent; // 0x24
		public string listTitle; // 0x28

		//public override int typeId { get; } 0xEE558C  Slot: 4
		//public bool IsRare5Only { get; } 0xEE559C
		//public bool IsRare2Less { get; } 0xEE55D0
	}
}
