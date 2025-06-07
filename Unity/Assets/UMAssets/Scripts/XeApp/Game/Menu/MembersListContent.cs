using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MembersListContent : SwapScrollListContent
	{
		[SerializeField]
		private MembersListElemBase m_elemUi; // 0x20

		// RVA: -1 Offset: -1
		public T GetElemUI<T>() where T : MembersListElemBase
		{
			return m_elemUi as T;
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x209205C Offset: 0x209205C VA: 0x209205C
		|-MembersListContent.GetElemUI<object>
		|-MembersListContent.GetElemUI<MembersListElem>
		*/

	}
}
