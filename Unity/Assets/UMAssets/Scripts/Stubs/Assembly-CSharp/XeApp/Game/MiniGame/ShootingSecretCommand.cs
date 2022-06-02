using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingSecretCommand : MonoBehaviour
	{
		public enum Command
		{
			None = -1,
			Up = 0,
			Down = 1,
			Right = 2,
			Left = 3,
			Shot = 4,
		}

		[SerializeField]
		private Command[] m_secretCommand;
		[SerializeField]
		private float m_secretResetTimeMax;
	}
}
