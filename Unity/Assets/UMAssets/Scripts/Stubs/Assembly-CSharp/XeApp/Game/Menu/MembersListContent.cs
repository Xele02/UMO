using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MembersListContent : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private MembersListElemBase m_elemUi;
	}
}
