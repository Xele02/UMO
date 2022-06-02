using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingItemPool : ShootingTask
	{
		[SerializeField]
		private int m_createNum;
		public ShootingItem m_taskObject;
	}
}
