using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class GeneralListContent : SwapScrollListContent
	{
		[SerializeField]
		private GeneralListElemBase m_elemUi; // 0x20

		// RVA: -1 Offset: -1
		public T GetElemUI<T>() where T : GeneralListElemBase
		{
			return m_elemUi as T;
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x2091EEC Offset: 0x2091EEC VA: 0x2091EEC
		|-GeneralListContent.GetElemUI<object>
		|-GeneralListContent.GetElemUI<FriendListElem>
		|-GeneralListContent.GetElemUI<GuestListElem>
		|-GeneralListContent.GetElemUI<PresentListElem>
		|-GeneralListContent.GetElemUI<RankingListElemBase>
		*/
	}
}
