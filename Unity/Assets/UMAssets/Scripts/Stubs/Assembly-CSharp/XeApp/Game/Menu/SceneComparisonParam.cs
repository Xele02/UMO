using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SceneComparisonParam : ComparisonParamBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}

		protected override void UpdateSkillText(int pos, int index)
		{
			UnityEngine.Debug.LogError("Implement");
		}

		public override void InitializeDecoration()
		{
			UnityEngine.Debug.LogError("Implement");
		}

		public override void ReleaseDecoration()
		{
			UnityEngine.Debug.LogError("Implement");
		}

		public override void UpdateDecoration(DisplayType type)
		{
			UnityEngine.Debug.LogError("Implement");
		}

		[SerializeField]
		private ComparisonNotesInfo[] m_notesInfo;
	}
}
