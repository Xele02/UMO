using UnityEngine.EventSystems;

namespace XeApp.Game.Menu
{
	public class PopupSortMenu : UIBehaviour
	{
		public enum SortPlace
		{
			None = -1,
			Diva = 0,
			SceneSelect = 1,
			Costume = 2,
			Unit = 3,
			SceneList = 4,
			AssistList = 5,
			EpsiodeSelect = 6,
			VisitList = 7,
			DecoShopList = 8,
			DecoInteriorList = 9,
			FriendList = 10,
			GuestSelect = 11,
			SentRequestList = 12,
			PendingList = 13,
			LobbyMemberList = 14,
			Max = 15,
		}

	}
}
