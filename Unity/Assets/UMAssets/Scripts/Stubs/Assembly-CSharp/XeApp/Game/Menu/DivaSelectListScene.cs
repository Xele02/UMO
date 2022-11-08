using UnityEngine;

namespace XeApp.Game.Menu
{
	public class DivaSelectListScene : TransitionRoot
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private ListSortButtonGroup m_sortGroupButton;
		[SerializeField]
		private DivaSelectList m_divaSelectList;
	}
}
