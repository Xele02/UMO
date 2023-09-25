using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEffectManager : ShootingTask
	{
		public List<ShootingEffectPool> m_effectPool; // 0x10
		private List<ShootingEffectPool> m_effectPoolList = new List<ShootingEffectPool>(); // 0x14
		private ShootingTaskManager m_taskManager; // 0x18

		//// RVA: 0x1CF5854 Offset: 0x1CF5854 VA: 0x1CF5854
		public void Play(EffectId effectId, Transform trans)
		{
			for(int i = 0; i < m_effectPoolList.Count; i++)
			{
				if(m_effectPoolList[i].m_taskObject.GetId == effectId)
				{
					ShootingEffect eff = m_effectPoolList[i].Alloc();
					eff.Play(trans);
				}
			}
		}

		//// RVA: 0x1CF5C30 Offset: 0x1CF5C30 VA: 0x1CF5C30 Slot: 11
		public override void OnAwake()
		{
			OnActive();
			for(int i = 0; i < m_effectPool.Count; i++)
			{
				ShootingEffectPool p = Instantiate(m_effectPool[i]);
				p.Create();
				p.transform.SetParent(transform, false);
				m_effectPoolList.Add(p);
			}
			m_taskManager = new ShootingTaskManager();
			for(int i = 0; i < m_effectPoolList.Count; i++)
			{
				m_taskManager.AddTask(m_effectPoolList[i]);
			}
			m_taskManager.OnAwake();
		}

		//// RVA: 0x1CF5F8C Offset: 0x1CF5F8C VA: 0x1CF5F8C Slot: 12
		public override void OnStart()
		{
			m_taskManager.OnStart();
		}

		//// RVA: 0x1CF5FB8 Offset: 0x1CF5FB8 VA: 0x1CF5FB8 Slot: 13
		public override void Initialize()
		{
			OnActive();
			m_taskManager.Initialize();
		}

		//// RVA: 0x1CF5FF0 Offset: 0x1CF5FF0 VA: 0x1CF5FF0 Slot: 14
		public override void Pause()
		{
			m_taskManager.Pause();
		}

		//// RVA: 0x1CF601C Offset: 0x1CF601C VA: 0x1CF601C Slot: 15
		public override void UnPause()
		{
			m_taskManager.UnPause();
		}

		//// RVA: 0x1CF6048 Offset: 0x1CF6048 VA: 0x1CF6048 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_taskManager.OnUpdate(elapsedTime);
		}

		//// RVA: 0x1CF607C Offset: 0x1CF607C VA: 0x1CF607C Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			m_taskManager.OnLateUpdate(elapsedTime);
		}
	}
}
