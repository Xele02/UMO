
namespace XeApp.Game.Menu
{
	public class ViewOfferGetItem
	{
		public enum ItemType
		{
			CONFIRM = 0,
			GREATERARE = 1,
			RARE = 2,
			NOMAL = 3,
			NUM = 4,
		}

		private const int MaxItemNum = 26;
		public int itemId = -1; // 0x8
		public int itemNum = -1; // 0xC
		public int bonusNum = -1; // 0x10
		public ItemType itemType = ItemType.NOMAL; // 0x14
	}
}
