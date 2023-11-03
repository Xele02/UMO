
namespace XeApp.Game.Menu
{ 
	public class GachaRateRarityInfo : GachaRateInfo
	{
		public int starNum; // 0x8
		public string percent; // 0xC

		public override int typeId { get { return 1; } } //0xEE6588  Slot: 4
	}
}
