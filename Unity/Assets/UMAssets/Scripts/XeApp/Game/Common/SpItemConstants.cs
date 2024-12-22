namespace XeApp.Game.Common
{
	public class SpItemConstants
	{
		public enum SpItemId
		{
			Item001 = 1,
			Item002 = 2,
			Item003 = 3,
			Dummy004 = 4,
			Dummy005 = 5,
			CannonGaugeItem = 6,
			RaidMedal = 7,
			DecoPoint = 8,
			RareUpStarParts = 9,
			SecretBoardParts = 10,
			LimitOverItem25Parts = 11,
			LimitOverItem26Parts = 12,
			_LiveSkipTicket = 13,
			LotteryTicketf = 14,
			PlateShopTicket = 15,
			PlateShopTicket2 = 16,
			_maxId = 17,
		}


		// RVA: 0x139CAA8 Offset: 0x139CAA8 VA: 0x139CAA8
		public static int MakeItemId(SpItemId spItemId)
		{
			return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, (int)spItemId);
		}
	}
}
