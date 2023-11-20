
using System.Collections.Generic;

namespace XeApp.Game.Menu
{ 
	public class ViewOfferCompensation
	{
		public List<ViewOfferGetItem> ItemList = new List<ViewOfferGetItem>(); // 0x8
		public int Confirm; // 0xC
		public int Rare; // 0x10
		public int Nomal; // 0x14
		public bool IsBonus; // 0x18
		public int BonusNum; // 0x1C
		public int UCNum; // 0x20
		public bool IsGreatSuccess; // 0x24

		// RVA: 0x1CE5BD0 Offset: 0x1CE5BD0 VA: 0x1CE5BD0
		public static ViewOfferCompensation CreateList(BOPFPIHGJMD.MLBMHDCCGHI offerType, int offerId)
		{
			ViewOfferCompensation res = new ViewOfferCompensation();
			KDHGBOOECKC.CBJJINJDFDC d = KDHGBOOECKC.HHCJCDFCLOB.IKENGGJIJJO();
			if(d != null)
			{
				for(int i = 0; i < d.ENEHOPNDNAF.Count; i++)
				{
					ViewOfferGetItem item = new ViewOfferGetItem();
					item.itemId = d.ENEHOPNDNAF[i].PPFNGGCBJKC_Id;
					item.itemNum = d.ENEHOPNDNAF[i].BFINGCJHOHI_Cnt;
					item.bonusNum = d.ENEHOPNDNAF[i].DKHIHHMOIKM_BonusNum;
					item.itemType = (ViewOfferGetItem.ItemType)d.ENEHOPNDNAF[i].INDDJNMPONH_Type;
					res.ItemList.Add(item);
				}
				res.UCNum = d.CMMNABJIKOH_UCNum;
				res.IsBonus = d.KKBAGBFOPIJ_IsBonus;
				res.BonusNum = d.FLIEFMMPKHF_BonusNum;
				res.IsGreatSuccess = d.JLDJAOCIIIG_IsGreatSuccess;
				res.Confirm = d.OKDOMNJHGNF_Confirm;
				res.Rare = d.MFNCONLNBPB_Rare;
				res.Nomal = d.OOEFNNNFOLF_Nomal;
			}
			return res;
		}
	}
}
