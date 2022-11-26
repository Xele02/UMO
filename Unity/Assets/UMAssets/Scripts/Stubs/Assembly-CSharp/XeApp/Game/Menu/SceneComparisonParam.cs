using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SceneComparisonParam : ComparisonParamBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private ComparisonNotesInfo[] m_notesInfo;
	}
}
