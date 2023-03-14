using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingBulletPool : ShootingTask
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private int m_createNum;
		public ShootingBullet m_taskObject;
	}
}
