using System;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyBossCharacter : ShootingEnemyCharacter
	{
		[Serializable]
		public class PhaseData01
		{
			public int changePhaseHp;
			public ShootingEnemySummon summonData;
			public int fireNum;
			public float[] intervalTime;
		}

		[Serializable]
		public class PhaseData02
		{
			public int changePhaseHp;
			public ShootingEnemySummon summonData;
			public int fireNum;
			public float radiationInterval;
			public int radiationCountMax;
			public float[] intervalTime;
		}

		[Serializable]
		public class PhaseData03
		{
			public int changePhaseHp;
			public ShootingEnemySummon summonData;
			public float angleSpeed;
			public float moveRadius;
			public int fireNum;
			public float radiationInterval;
			public int radiationCountMax;
			public float[] intervalTime;
		}

		[SerializeField]
		private PhaseData01 m_phase01;
		[SerializeField]
		private PhaseData02 m_phase02;
		[SerializeField]
		private PhaseData03 m_phase03;
		[SerializeField]
		private float m_waitPahseTimeMax;
		[SerializeField]
		public float m_entryLength;
		public GameObject[] laserPos;
		[SerializeField]
		private float m_laserTimeMax;
	}
}
