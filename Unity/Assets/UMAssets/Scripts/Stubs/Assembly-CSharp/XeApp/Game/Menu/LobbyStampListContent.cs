using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LobbyStampListContent : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private LobbyStampItem m_elemUi;
	}
}
