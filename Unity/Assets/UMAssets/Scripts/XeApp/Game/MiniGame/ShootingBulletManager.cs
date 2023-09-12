using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingBulletManager : ShootingTask
	{
		public List<ShootingBulletPool> m_bulletPoolObj; // 0x10
		private List<ShootingBulletPool> m_bulletPoolList = new List<ShootingBulletPool>(); // 0x14
		private ShootingTaskManager m_taskManager; // 0x18

		public ShootingCollisionManager CollisionManager { get; set; } // 0x1C
		public RectTransform MainScreen { get; set; } // 0x20

		//// RVA: 0x1CF378C Offset: 0x1CF378C VA: 0x1CF378C
		public void ShotBullet(BulletId bulletId, Transform transform, Vector3 move)
		{
			for(int i = 0; i < m_bulletPoolList.Count; i++)
			{
				if(m_bulletPoolList[i].m_taskObject.GetId == bulletId)
				{
					ShootingBullet b = m_bulletPoolList[i].Alloc();
					b.SetBullet(transform, move);
				}
			}
		}

		//// RVA: 0x1CF3B84 Offset: 0x1CF3B84 VA: 0x1CF3B84
		//public void MultipleShotBullet(BulletId bulletId, Transform transform, Vector3 targetPos, float angle, int fireNum) { }

		// RVA: 0x1CF3DF8 Offset: 0x1CF3DF8 VA: 0x1CF3DF8 Slot: 11
		public override void OnAwake()
		{
			OnActive();
			for(int i = 0; i < m_bulletPoolObj.Count; i++)
			{
				ShootingBulletPool p = Instantiate(m_bulletPoolObj[i]);
				p.CollisionManager = CollisionManager;
				p.MainScreen = MainScreen;
				p.Create();
				p.transform.SetParent(transform, false);
				m_bulletPoolList.Add(p);
			}
			m_taskManager = new ShootingTaskManager();
			for(int i = 0; i < m_bulletPoolList.Count; i++)
			{
				m_taskManager.AddTask(m_bulletPoolList[i]);
			}
			m_taskManager.OnAwake();
		}

		// RVA: 0x1CF4198 Offset: 0x1CF4198 VA: 0x1CF4198 Slot: 12
		public override void OnStart()
		{
			m_taskManager.OnStart();
		}

		//// RVA: 0x1CF41C4 Offset: 0x1CF41C4 VA: 0x1CF41C4 Slot: 13
		public override void Initialize()
		{
			OnActive();
			m_taskManager.Initialize();
		}

		//// RVA: 0x1CF41FC Offset: 0x1CF41FC VA: 0x1CF41FC Slot: 14
		public override void Pause()
		{
			m_taskManager.Pause();
		}

		//// RVA: 0x1CF4228 Offset: 0x1CF4228 VA: 0x1CF4228 Slot: 15
		public override void UnPause()
		{
			m_taskManager.UnPause();
		}

		// RVA: 0x1CF4254 Offset: 0x1CF4254 VA: 0x1CF4254 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_taskManager.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CF4288 Offset: 0x1CF4288 VA: 0x1CF4288 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			m_taskManager.OnLateUpdate(elapsedTime);
		}
	}
}
