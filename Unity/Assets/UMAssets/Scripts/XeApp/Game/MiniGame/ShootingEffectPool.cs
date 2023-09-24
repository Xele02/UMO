using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEffectPool : ShootingTask, ShootingPoolMethod<ShootingEffect>
	{
		[SerializeField]
		private int m_createNum; // 0x10
		public ShootingEffect m_taskObject; // 0x14
		private ShootingTaskManager m_taskManager; // 0x18

		// RVA: 0x1CF613C Offset: 0x1CF613C VA: 0x1CF613C Slot: 11
		public override void OnAwake()
		{
			OnActive();
			m_taskManager.OnAwake();
		}

		//// RVA: 0x1CF6174 Offset: 0x1CF6174 VA: 0x1CF6174 Slot: 12
		public override void OnStart()
		{
			m_taskManager.OnStart();
		}

		//// RVA: 0x1CF61A0 Offset: 0x1CF61A0 VA: 0x1CF61A0 Slot: 13
		public override void Initialize()
		{
			OnActive();
			m_taskManager.Initialize();
		}

		//// RVA: 0x1CF61D8 Offset: 0x1CF61D8 VA: 0x1CF61D8 Slot: 14
		public override void Pause()
		{
			m_taskManager.Pause();
		}

		//// RVA: 0x1CF6204 Offset: 0x1CF6204 VA: 0x1CF6204 Slot: 15
		public override void UnPause()
		{
			m_taskManager.UnPause();
		}

		//// RVA: 0x1CF6230 Offset: 0x1CF6230 VA: 0x1CF6230 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_taskManager.OnUpdate(elapsedTime);
		}

		//// RVA: 0x1CF6264 Offset: 0x1CF6264 VA: 0x1CF6264 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			m_taskManager.OnLateUpdate(elapsedTime);
		}

		//// RVA: 0x1CF5984 Offset: 0x1CF5984 VA: 0x1CF5984 Slot: 19
		public ShootingEffect Alloc()
		{
			for (int i = 0; i < m_taskManager.TaskList.Count; i++)
			{
				if(!m_taskManager.TaskList[i].IsStatus(TaskStatus.Active))
				{
					return m_taskManager.TaskList[i] as ShootingEffect;
				}
			}
			Create(1);
			ShootingEffect s = m_taskManager.TaskList[m_taskManager.TaskList.Count - 1] as ShootingEffect;
			s.OnAwake();
			s.OnStart();
			return s;
		}

		//// RVA: 0x1CF6298 Offset: 0x1CF6298 VA: 0x1CF6298 Slot: 21
		public void Create(int createNum)
		{
			for (int i = 0; i < createNum; i++)
			{
				ShootingEffect t = Instantiate(m_taskObject);
				t.transform.SetParent(transform, false);
				t.name += i.ToString();
				m_taskManager.AddTask(t);
			}
		}

		//// RVA: 0x1CF5F08 Offset: 0x1CF5F08 VA: 0x1CF5F08 Slot: 22
		public void Create()
		{
			m_taskManager = new ShootingTaskManager(m_createNum);
			Create(m_createNum);
		}

		//// RVA: 0x1CF6438 Offset: 0x1CF6438 VA: 0x1CF6438 Slot: 23
		//public void Dispose() { }

		//// RVA: 0x1CF6608 Offset: 0x1CF6608 VA: 0x1CF6608 Slot: 20
		//public void Free() { }
	}
}
