using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEffectPool : ShootingTask
	{
		[SerializeField]
		private int m_createNum;
		public ShootingEffect m_taskObject;
	}
}
