using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingItemPool : ShootingTask
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private int m_createNum;
		public ShootingItem m_taskObject;
	}
}
