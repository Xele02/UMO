using System.Collections.Generic;

namespace XeApp.Game.MiniGame
{
	public class ShootingEmersionManager : ShootingTask
	{
		public class EmersionData
		{
			public List<ShootingStageData.SettingEnemyData> enemyData; // 0x8
			public List<bool> isEnemyEemersion = new List<bool>(); // 0xC
			public List<ShootingStageData.SettingItemData> itemData; // 0x10
			public List<bool> isItemEemersion = new List<bool>(); // 0x14
		}

		private EmersionData m_emersionData = new EmersionData(); // 0x10
		private float m_elapsedTime; // 0x14
		private bool isReady; // 0x18

		public ShootingEnemyManager EnemyManager { get; set; } // 0x1C
		public ShootingItemManager ItemManager { get; set; } // 0x20
		public int StageNum { get; set; } // 0x24
		//public bool IsReady { get; } 0x1CEEDDC

		//[IteratorStateMachineAttribute] // RVA: 0x6B18A0 Offset: 0x6B18A0 VA: 0x6B18A0
		//// RVA: 0x1CF6624 Offset: 0x1CF6624 VA: 0x1CF6624
		//public IEnumerator SetStageData() { }

		// RVA: 0x1CF66D0 Offset: 0x1CF66D0 VA: 0x1CF66D0 Slot: 11
		public override void OnAwake()
		{
			OnActive();
		}

		//// RVA: 0x1CF66D8 Offset: 0x1CF66D8 VA: 0x1CF66D8 Slot: 12
		public override void OnStart()
		{
			return;
		}

		//// RVA: 0x1CF66DC Offset: 0x1CF66DC VA: 0x1CF66DC Slot: 13
		//public override void Initialize() { }

		//// RVA: 0x1CF6718 Offset: 0x1CF6718 VA: 0x1CF6718 Slot: 14
		//public override void Pause() { }

		//// RVA: 0x1CF671C Offset: 0x1CF671C VA: 0x1CF671C Slot: 15
		//public override void UnPause() { }

		// RVA: 0x1CF6720 Offset: 0x1CF6720 VA: 0x1CF6720 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_elapsedTime += elapsedTime;
			for(int i = 0; i < m_emersionData.enemyData.Count; i++)
			{
				if(!m_emersionData.isEnemyEemersion[i])
				{
					if(m_emersionData.enemyData[i].emersionTime <= m_elapsedTime)
					{
						EnemyManager.SetEnemy(m_emersionData.enemyData[i]);
						m_emersionData.isEnemyEemersion[i] = true;
					}
				}
			}
			for(int i = 0; i < m_emersionData.itemData.Count; i++)
			{
				if(!m_emersionData.isItemEemersion[i])
				{
					if(m_emersionData.itemData[i].emersionTime <= m_elapsedTime)
					{
						ItemManager.SetItem(m_emersionData.itemData[i].type, m_emersionData.itemData[i].pos);
						m_emersionData.isItemEemersion[i] = true;
					}
				}
			}
		}

		// RVA: 0x1CF6D30 Offset: 0x1CF6D30 VA: 0x1CF6D30 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			return;
		}
	}
}
