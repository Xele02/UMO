using UnityEngine;
using System;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemySummonData : MonoBehaviour
	{
		[Serializable]
		public class SummonEnemyData
		{
			//[TooltipAttribute] // RVA: 0x663C20 Offset: 0x663C20 VA: 0x663C20
			public ShootingStageData.StageEnemyType enemytype; // 0x8
			//[TooltipAttribute] // RVA: 0x663C5C Offset: 0x663C5C VA: 0x663C5C
			public ShootingStageData.StageItemType dropItemType; // 0xC
		}
		
		//[HeaderAttribute] // RVA: 0x663BD8 Offset: 0x663BD8 VA: 0x663BD8
		public SummonEnemyData[] enemyData; // 0xC
	}
}
