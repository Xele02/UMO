using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingBulletPool : ShootingTask
	{
		[SerializeField]
		private int m_createNum;
		public ShootingBullet m_taskObject;
	}
}
