using System.Collections.Generic;

namespace XeApp.Game.MiniGame
{
	public class ShootingTaskManager : ShootingTaskMethod
	{
		private List<ShootingTask> m_taskList; // 0x8
		private List<ShootingTask> m_taskActiveList; // 0xC

		public List<ShootingTask> TaskList { get { return m_taskList; } } //0xC91E4C

		// RVA: 0xC91CF8 Offset: 0xC91CF8 VA: 0xC91CF8
		public ShootingTaskManager()
		{
			m_taskList = new List<ShootingTask>();
			m_taskActiveList = new List<ShootingTask>();
		}

		// RVA: 0xC91D9C Offset: 0xC91D9C VA: 0xC91D9C
		public ShootingTaskManager(int capacity)
		{
			m_taskList = new List<ShootingTask>(capacity);
			m_taskActiveList = new List<ShootingTask>(capacity);
		}

		// RVA: 0xC91E54 Offset: 0xC91E54 VA: 0xC91E54 Slot: 4
		public void OnAwake()
		{
			for(int i = 0; i < m_taskList.Count; i++)
			{
				m_taskList[i].OnAwake();
			}
		}

		//// RVA: 0xC91F38 Offset: 0xC91F38 VA: 0xC91F38 Slot: 5
		public void OnStart()
		{
			for(int i = 0; i < m_taskList.Count; i++)
			{
				m_taskList[i].OnStart();
			}
		}

		//// RVA: 0xC9201C Offset: 0xC9201C VA: 0xC9201C Slot: 6
		//public void Initialize() { }

		//// RVA: 0xC92100 Offset: 0xC92100 VA: 0xC92100
		public void CreateActiveTaskList()
		{
			m_taskActiveList.Clear();
			for(int i = 0; i < m_taskList.Count; i++)
			{
				if(m_taskList[i].IsStatus(ShootingTask.TaskStatus.Active))
				{
					m_taskActiveList.Add(m_taskList[i]);
				}
			}
		}

		//// RVA: 0xC92240 Offset: 0xC92240 VA: 0xC92240 Slot: 7
		//public void Pause() { }

		//// RVA: 0xC9232C Offset: 0xC9232C VA: 0xC9232C Slot: 8
		//public void UnPause() { }

		// RVA: 0xC92418 Offset: 0xC92418 VA: 0xC92418 Slot: 9
		public void OnUpdate(float elapsedTime)
		{
			CreateActiveTaskList();
			for (int i = 0; i < m_taskActiveList.Count; i++)
			{
				m_taskActiveList[i].OnUpdate(elapsedTime);
			}
		}

		// RVA: 0xC9250C Offset: 0xC9250C VA: 0xC9250C Slot: 10
		public void OnLateUpdate(float elapsedTime)
		{
			for(int i = 0; i < m_taskActiveList.Count; i++)
			{
				m_taskActiveList[i].OnLateUpdate(elapsedTime);
			}
		}

		// RVA: 0xC925F8 Offset: 0xC925F8 VA: 0xC925F8
		public void AddTask(ShootingTask task)
		{
			if (m_taskList.Contains(task))
				return;
			m_taskList.Add(task);
		}

		//// RVA: 0xC926B0 Offset: 0xC926B0 VA: 0xC926B0
		//public void RemoveTask(ShootingTask task) { }

		//// RVA: 0xC92730 Offset: 0xC92730 VA: 0xC92730
		//public void Clear() { }

		//// RVA: 0xC927A8 Offset: 0xC927A8 VA: 0xC927A8
		//public void AllSleep() { }
	}
}
