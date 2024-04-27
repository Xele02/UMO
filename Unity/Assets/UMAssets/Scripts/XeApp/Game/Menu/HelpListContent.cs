using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class HelpListContent : SwapScrollListContent
	{
		[SerializeField]
		private HelpListElemBase m_elemUi; // 0x20

		// RVA: -1 Offset: -1
		public T GetElemUI<T>() where T : HelpListElemBase
		{
			return m_elemUi as T;
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x2091FA4 Offset: 0x2091FA4 VA: 0x2091FA4
		|-HelpListContent.GetElemUI<object>
		|-HelpListContent.GetElemUI<HelpListElemShort>
		*/
	}
}
