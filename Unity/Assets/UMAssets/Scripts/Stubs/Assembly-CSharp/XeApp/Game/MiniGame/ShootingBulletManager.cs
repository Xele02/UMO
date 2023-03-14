using System.Collections.Generic;

namespace XeApp.Game.MiniGame
{
	public class ShootingBulletManager : ShootingTask
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		public List<ShootingBulletPool> m_bulletPoolObj;
	}
}
