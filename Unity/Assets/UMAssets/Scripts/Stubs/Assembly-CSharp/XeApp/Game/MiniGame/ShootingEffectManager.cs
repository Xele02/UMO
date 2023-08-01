using System.Collections.Generic;

namespace XeApp.Game.MiniGame
{
	public class ShootingEffectManager : ShootingTask
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public List<ShootingEffectPool> m_effectPool;
	}
}
