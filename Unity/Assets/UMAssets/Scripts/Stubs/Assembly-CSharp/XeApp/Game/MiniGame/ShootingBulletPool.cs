using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingBulletPool : ShootingTask
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private int m_createNum;
		public ShootingBullet m_taskObject;
	}
}
