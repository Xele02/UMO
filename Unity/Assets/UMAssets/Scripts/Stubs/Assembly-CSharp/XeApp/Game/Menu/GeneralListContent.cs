using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class GeneralListContent : SwapScrollListContent
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private GeneralListElemBase m_elemUi;
	}
}
