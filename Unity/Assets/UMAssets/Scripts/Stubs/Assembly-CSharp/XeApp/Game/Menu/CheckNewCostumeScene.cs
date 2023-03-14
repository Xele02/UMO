using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CheckNewCostumeScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private ScriptableObject m_CameraParam;
	}
}
