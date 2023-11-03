
namespace XeApp.Game.Menu
{
	public class GachaRateEpDetailInfo : GachaRateInfo
	{
		public int episodeId; // 0x8
		public string episodeContent; // 0xC

		public override int typeId { get { return 4; } } //0xEE451C  Slot: 4
	}
}
