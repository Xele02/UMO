using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEffectPool : ShootingTask
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private int m_createNum;
		public ShootingEffect m_taskObject;
	}
}
