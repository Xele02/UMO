using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingBulletPool : ShootingTask, ShootingPoolMethod<ShootingBullet>
	{
		[SerializeField]
		private int m_createNum; // 0x10
		public ShootingBullet m_taskObject; // 0x14
		private ShootingTaskManager m_taskManager; // 0x18

		public RectTransform MainScreen { get; set; } // 0x1C
		public ShootingCollisionManager CollisionManager { get; set; } // 0x20

		// RVA: 0x1CF4358 Offset: 0x1CF4358 VA: 0x1CF4358 Slot: 11
		public override void OnAwake()
		{
			OnActive();
			m_taskManager.OnAwake();
		}

		// RVA: 0x1CF4390 Offset: 0x1CF4390 VA: 0x1CF4390 Slot: 12
		public override void OnStart()
		{
			m_taskManager.OnStart();
		}

		//// RVA: 0x1CF43BC Offset: 0x1CF43BC VA: 0x1CF43BC Slot: 13
		//public override void Initialize() { }

		//// RVA: 0x1CF43F4 Offset: 0x1CF43F4 VA: 0x1CF43F4 Slot: 14
		//public override void Pause() { }

		//// RVA: 0x1CF4420 Offset: 0x1CF4420 VA: 0x1CF4420 Slot: 15
		//public override void UnPause() { }

		// RVA: 0x1CF444C Offset: 0x1CF444C VA: 0x1CF444C Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_taskManager.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CF4480 Offset: 0x1CF4480 VA: 0x1CF4480 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			m_taskManager.OnLateUpdate(elapsedTime);
		}

		//// RVA: 0x1CF38D8 Offset: 0x1CF38D8 VA: 0x1CF38D8 Slot: 19
		public ShootingBullet Alloc()
		{
			for(int i = 0; i < m_taskManager.TaskList.Count; i++)
			{
				ShootingBullet s2 = m_taskManager.TaskList[i] as ShootingBullet;
				if (!s2.IsStatus(TaskStatus.Active))
					return s2;
			}
			Create(1);
			ShootingBullet s = m_taskManager.TaskList[m_taskManager.TaskList.Count - 1] as ShootingBullet;
			s.OnAwake();
			s.OnStart();
			return s;
		}

		// RVA: 0x1CF44B4 Offset: 0x1CF44B4 VA: 0x1CF44B4 Slot: 21
		public void Create(int createNum)
		{
			for(int i = 0; i < createNum; i++)
			{
				ShootingBullet b = Instantiate(m_taskObject);
				b.CollisionManager = CollisionManager;
				b.MainScreen = MainScreen;
				b.transform.SetParent(transform, false);
				b.name += i.ToString();
				m_taskManager.AddTask(b);
			}
		}

		// RVA: 0x1CF4114 Offset: 0x1CF4114 VA: 0x1CF4114 Slot: 22
		public void Create()
		{
			m_taskManager = new ShootingTaskManager(m_createNum);
			Create(m_createNum);
		}

		//// RVA: 0x1CF468C Offset: 0x1CF468C VA: 0x1CF468C Slot: 23
		//public void Dispose() { }

		//// RVA: 0x1CF485C Offset: 0x1CF485C VA: 0x1CF485C Slot: 20
		//public void Free() { }
	}
}
