using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEffectPool : ShootingTask
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private int m_createNum;
		public ShootingEffect m_taskObject;
	}
}
