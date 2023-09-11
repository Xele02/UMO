using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingItemPool : ShootingTask, ShootingPoolMethod<ShootingItem>
	{
		[SerializeField]
		private int m_createNum; // 0x10
		public ShootingItem m_taskObject; // 0x14
		private ShootingTaskManager m_taskManager; // 0x18

		public ShootingResulData ResulData { get; set; } // 0x1C
		public ShootingCollisionManager CollisionManager { get; set; } // 0x20
		public RectTransform MainScreen { get; set; } // 0x24

		// RVA: 0x1CFF920 Offset: 0x1CFF920 VA: 0x1CFF920 Slot: 11
		public override void OnAwake()
		{
			OnActive();
			m_taskManager.OnAwake();
		}

		// RVA: 0x1CFF958 Offset: 0x1CFF958 VA: 0x1CFF958 Slot: 12
		public override void OnStart()
		{
			m_taskManager.OnStart();
		}

		//// RVA: 0x1CFF984 Offset: 0x1CFF984 VA: 0x1CFF984 Slot: 13
		//public override void Initialize() { }

		//// RVA: 0x1CFF9B0 Offset: 0x1CFF9B0 VA: 0x1CFF9B0 Slot: 14
		//public override void Pause() { }

		//// RVA: 0x1CFF9DC Offset: 0x1CFF9DC VA: 0x1CFF9DC Slot: 15
		//public override void UnPause() { }

		// RVA: 0x1CFFA08 Offset: 0x1CFFA08 VA: 0x1CFFA08 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_taskManager.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFFA3C Offset: 0x1CFFA3C VA: 0x1CFFA3C Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			m_taskManager.OnLateUpdate(elapsedTime);
		}

		// RVA: 0x1CFF0E8 Offset: 0x1CFF0E8 VA: 0x1CFF0E8 Slot: 19
		public ShootingItem Alloc()
		{
			for(int i = 0; i < m_taskManager.TaskList.Count; i++)
			{
				if (!m_taskManager.TaskList[i].IsStatus(TaskStatus.Active))
					return m_taskManager.TaskList[i] as ShootingItem;
			}
			Create(1);
			ShootingItem s = m_taskManager.TaskList[m_taskManager.TaskList.Count - 1] as ShootingItem;
			s.OnAwake();
			s.OnStart();
			return s;
		}

		// RVA: 0x1CFFA70 Offset: 0x1CFFA70 VA: 0x1CFFA70 Slot: 21
		public void Create(int craateNum)
		{
			for(int i = 0; i < craateNum; i++)
			{
				ShootingItem s = Instantiate(m_taskObject);
				s.transform.SetParent(transform, false);
				s.ResulData = ResulData;
				s.CollisionManager = CollisionManager;
				s.MainScreen = MainScreen;
				s.name += i.ToString();
				m_taskManager.AddTask(s);
			}
		}

		// RVA: 0x1CFF6D4 Offset: 0x1CFF6D4 VA: 0x1CFF6D4 Slot: 22
		public void Create()
		{
			m_taskManager = new ShootingTaskManager(m_createNum);
			Create(m_createNum);
		}

		//// RVA: 0x1CFFC64 Offset: 0x1CFFC64 VA: 0x1CFFC64 Slot: 23
		//public void Dispose() { }

		//// RVA: 0x1CFFE34 Offset: 0x1CFFE34 VA: 0x1CFFE34 Slot: 20
		//public void Free() { }
	}
}
