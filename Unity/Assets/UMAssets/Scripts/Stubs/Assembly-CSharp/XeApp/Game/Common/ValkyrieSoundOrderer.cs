using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieSoundOrderer : EventSoundOrdererBase
	{
		public enum ShootType
		{
			Machinegun = 0,
			Beam = 1,
			Sniper = 2,
			SoundWave = 3,
		}

		[SerializeField]
		private ShootType m_fighterShootType;
		[SerializeField]
		private ShootType m_gerwalkShootType;
		[SerializeField]
		private ShootType m_battroidShootType;
	}
}
