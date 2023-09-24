using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.MiniGame
{
	public class ShootingStageData : ScriptableObject
	{
		[Serializable]
		public class SettingEnemyData
		{
			public ShootingStageData.StageEnemyType type;
			public Vector3 pos;
			public float emersionTime;
			public ShootingStageData.StageItemType itemType;
		}

		[Serializable]
		public class SettingItemData
		{
			public ShootingStageData.StageItemType type;
			public Vector3 pos;
			public float emersionTime;
		}

		public enum StageItemType
		{
			None = 0,
			Kyururu = 1,
		}

		public enum StageEnemyType
		{
			None = 0,
			TrackingEnemy = 1,
			StraightPlayerFireEnemy = 2,
			BossEnemy = 3,
			UpDownEnemy = 4,
			StraightFireEnemy = 5,
			LaserEnemy = 6,
			StraightEnemy = 7,
			UpDownFireEnemy = 8,
			SummonEnemy = 9,
		}

		public List<ShootingStageData.SettingEnemyData> m_settingEnemyDatas;
		public List<ShootingStageData.SettingItemData> m_settingItemDatas;
	}
}
