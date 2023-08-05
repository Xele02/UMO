using UnityEngine;

namespace XeApp.Game.Menu
{
	public class DivaListScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private ListSortButtonGroup m_listSortButton;
		[SerializeField]
		private DivaList m_divaList;
	}
}
