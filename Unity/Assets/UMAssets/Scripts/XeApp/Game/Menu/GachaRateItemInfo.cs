
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class GachaRateItemInfo : GachaRateInfo
	{
		public GameAttribute.Type attribute; // 0x8
		public string name; // 0xC
		public string percent; // 0x10
		public bool pickup; // 0x14

		//public override int typeId { get; } 0xEE5890  Slot: 4
	}
}
