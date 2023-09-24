using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyManager : ShootingTask
	{
		public List<ShootingEnemyPoolCharacter> m_enemyPoolObj; // 0x10
		private List<ShootingEnemyPoolCharacter> m_enemyPoolList = new List<ShootingEnemyPoolCharacter>(); // 0x14
		private ShootingTaskManager m_taskManager; // 0x18

		public ShootingCollisionManager CollisionManager { get; set; } // 0x1C
		public ShootingBulletManager BulletManager { get; set; } // 0x20
		public ShootingPlayerCharacter Player { get; set; } // 0x24
		public RectTransform MainScreen { get; set; } // 0x28
		public ShootingResulData ResulData { get; set; } // 0x2C
		public ShootingEffectManager EffectManager { get; set; } // 0x30
		public ShootingSoundManager SoundManager { get; set; } // 0x34
		public ShootingItemManager ItemManager { get; set; } // 0x38

		//// RVA: 0x1CF6ABC Offset: 0x1CF6ABC VA: 0x1CF6ABC
		public void SetEnemy(ShootingStageData.SettingEnemyData data)
		{
			for(int i = 0; i < m_enemyPoolList.Count; i++)
			{
				if(m_enemyPoolList[i].m_taskObject.GetEnemyType() == data.type)
				{
					ShootingEnemyCharacter s = m_enemyPoolList[i].Alloc();
					s.SetEnemy(data);
				}
			}
		}

		// RVA: 0x1CFB128 Offset: 0x1CFB128 VA: 0x1CFB128 Slot: 11
		public override void OnAwake()
		{
			OnActive();
			for(int i = 0; i < m_enemyPoolObj.Count; i++)
			{
				ShootingEnemyPoolCharacter s = Instantiate(m_enemyPoolObj[i]);
				s.CollisionManager = CollisionManager;
				s.BulletManager = BulletManager;
				s.Player = Player;
				s.MainScreen = MainScreen;
				s.ResulData = ResulData;
				s.EffectManager = EffectManager;
				s.SoundManager = SoundManager;
				s.EnemyManager = this;
				s.ItemManager = ItemManager;
				s.Create();
				s.transform.SetParent(transform, false);
				m_enemyPoolList.Add(s);
			}
			m_taskManager = new ShootingTaskManager();
			for(int i = 0; i < m_enemyPoolList.Count; i++)
			{
				m_taskManager.AddTask(m_enemyPoolList[i]);
			}
			m_taskManager.OnAwake();
		}

		// RVA: 0x1CFB5BC Offset: 0x1CFB5BC VA: 0x1CFB5BC Slot: 12
		public override void OnStart()
		{
			m_taskManager.OnStart();
		}

		//// RVA: 0x1CFB5E8 Offset: 0x1CFB5E8 VA: 0x1CFB5E8 Slot: 13
		public override void Initialize()
		{
			OnActive();
			m_taskManager.Initialize();
		}

		//// RVA: 0x1CFB620 Offset: 0x1CFB620 VA: 0x1CFB620 Slot: 14
		public override void Pause()
		{
			m_taskManager.Pause();
		}

		//// RVA: 0x1CFB64C Offset: 0x1CFB64C VA: 0x1CFB64C Slot: 15
		public override void UnPause()
		{
			m_taskManager.UnPause();
		}

		// RVA: 0x1CFB678 Offset: 0x1CFB678 VA: 0x1CFB678 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_taskManager.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFB6AC Offset: 0x1CFB6AC VA: 0x1CFB6AC Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			m_taskManager.OnLateUpdate(elapsedTime);
		}
	}
}
