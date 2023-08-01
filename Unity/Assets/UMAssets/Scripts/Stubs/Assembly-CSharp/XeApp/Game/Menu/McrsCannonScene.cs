using UnityEngine;

namespace XeApp.Game.Menu
{
	public class McrsCannonScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private MacrossCannon m_mcrsCannonPrefab;
		[SerializeField]
		private McrsCannonShakeObject m_mcrsCannonShakePrefab;
	}
}
