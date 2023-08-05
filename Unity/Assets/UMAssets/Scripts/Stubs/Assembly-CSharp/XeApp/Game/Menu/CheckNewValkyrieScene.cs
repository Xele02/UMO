using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CheckNewValkyrieScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private ScriptableObject m_CameraParam;
		public bool IsAnimEnd;
	}
}
