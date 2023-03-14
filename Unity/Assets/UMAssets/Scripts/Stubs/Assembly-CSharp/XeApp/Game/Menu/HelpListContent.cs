using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class HelpListContent : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private HelpListElemBase m_elemUi;
	}
}
