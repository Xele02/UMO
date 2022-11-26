using UnityEngine;
using System;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemySummonData : MonoBehaviour
	{
		[Serializable]
		public class SummonEnemyData
		{
			public ShootingStageData.StageEnemyType enemytype;
			public ShootingStageData.StageItemType dropItemType;
		}

		public SummonEnemyData[] enemyData;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
