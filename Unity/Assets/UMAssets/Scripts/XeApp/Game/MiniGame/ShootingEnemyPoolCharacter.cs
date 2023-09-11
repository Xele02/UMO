using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyPoolCharacter : ShootingTask, ShootingPoolMethod<ShootingEnemyCharacter>
	{
		[SerializeField]
		private int m_createNum; // 0x10
		public ShootingEnemyCharacter m_taskObject; // 0x14
		private ShootingTaskManager m_taskManager; // 0x18

		public ShootingCollisionManager CollisionManager { get; set; } // 0x1C
		public ShootingBulletManager BulletManager { get; set; } // 0x20
		public ShootingPlayerCharacter Player { get; set; } // 0x24
		public RectTransform MainScreen { get; set; } // 0x28
		public ShootingResulData ResulData { get; set; } // 0x2C
		public ShootingEffectManager EffectManager { get; set; } // 0x30
		public ShootingSoundManager SoundManager { get; set; } // 0x34
		public ShootingItemManager ItemManager { get; set; } // 0x38
		public ShootingEnemyManager EnemyManager { get; set; } // 0x3C

		// RVA: 0x1CFBB90 Offset: 0x1CFBB90 VA: 0x1CFBB90 Slot: 11
		public override void OnAwake()
		{
			OnActive();
			m_taskManager.OnAwake();
		}

		// RVA: 0x1CFBBC8 Offset: 0x1CFBBC8 VA: 0x1CFBBC8 Slot: 12
		public override void OnStart()
		{
			m_taskManager.OnStart();
		}

		//// RVA: 0x1CFBBF4 Offset: 0x1CFBBF4 VA: 0x1CFBBF4 Slot: 13
		//public override void Initialize() { }

		//// RVA: 0x1CFBC2C Offset: 0x1CFBC2C VA: 0x1CFBC2C Slot: 14
		//public override void Pause() { }

		//// RVA: 0x1CFBC58 Offset: 0x1CFBC58 VA: 0x1CFBC58 Slot: 15
		//public override void UnPause() { }

		// RVA: 0x1CFBC84 Offset: 0x1CFBC84 VA: 0x1CFBC84 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_taskManager.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFBCB8 Offset: 0x1CFBCB8 VA: 0x1CFBCB8 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			m_taskManager.OnLateUpdate(elapsedTime);
		}

		// RVA: 0x1CFAE44 Offset: 0x1CFAE44 VA: 0x1CFAE44 Slot: 19
		public ShootingEnemyCharacter Alloc()
		{
			for(int i = 0; i < m_taskManager.TaskList.Count; i++)
			{
				if (!m_taskManager.TaskList[i].IsStatus(TaskStatus.Active))
				{
					m_taskManager.TaskList[i].OnActive();
					return m_taskManager.TaskList[i] as ShootingEnemyCharacter;
				}
			}
			Create(1);
			ShootingEnemyCharacter s = m_taskManager.TaskList[m_taskManager.TaskList.Count - 1] as ShootingEnemyCharacter;
			s.OnAwake();
			s.OnStart();
			return s;
		}

		// RVA: 0x1CFBCEC Offset: 0x1CFBCEC VA: 0x1CFBCEC Slot: 21
		public void Create(int createNum)
		{
			for(int i = 0; i < createNum; i++)
			{
				ShootingEnemyCharacter s = Instantiate(m_taskObject);
				s.CollisionManager = CollisionManager;
				s.BulletManager = BulletManager;
				s.Player = Player;
				s.MainScreen = MainScreen;
				s.ResulData = ResulData;
				s.EffectManager = EffectManager;
				s.SoundManager = SoundManager;
				s.ItemManager = ItemManager;
				s.EnemyManager = EnemyManager;
				s.transform.SetParent(transform, false);
				s.gameObject.SetActive(false);
				m_taskManager.AddTask(s);
			}
		}

		// RVA: 0x1CFB538 Offset: 0x1CFB538 VA: 0x1CFB538 Slot: 22
		public void Create()
		{
			m_taskManager = new ShootingTaskManager(m_createNum);
			Create(m_createNum);
		}

		//// RVA: 0x1CFBF54 Offset: 0x1CFBF54 VA: 0x1CFBF54 Slot: 23
		//public void Dispose() { }

		//// RVA: 0x1CFC124 Offset: 0x1CFC124 VA: 0x1CFC124 Slot: 20
		//public void Free() { }
	}
}
