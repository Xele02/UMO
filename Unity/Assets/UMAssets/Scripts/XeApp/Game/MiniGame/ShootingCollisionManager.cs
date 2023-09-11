using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingCollisionManager : ShootingTask
	{
		private List<ShootingCollision> m_playerCollisons = new List<ShootingCollision>(); // 0x10
		private List<ShootingCollision> m_otherCollisons = new List<ShootingCollision>(); // 0x14


		//// RVA: 0x1CF3064 Offset: 0x1CF3064 VA: 0x1CF3064
		public void AddCollision(ShootingCollision collisionObj)
		{
			if (!collisionObj.m_isPlayerCol)
				m_otherCollisons.Add(collisionObj);
			else
				m_playerCollisons.Add(collisionObj);
		}

		//// RVA: 0x1CF3240 Offset: 0x1CF3240 VA: 0x1CF3240
		public void EraseCollision(ShootingCollision collisionObj)
		{
			if (!collisionObj.m_isPlayerCol)
				m_otherCollisons.Remove(collisionObj);
			else
				m_playerCollisons.Remove(collisionObj);
		}

		// RVA: 0x1CF4B3C Offset: 0x1CF4B3C VA: 0x1CF4B3C Slot: 11
		public override void OnAwake()
		{
			OnActive();
			for (int i = 0; i < m_playerCollisons.Count; i++)
			{
				m_playerCollisons[i].OnAwake();
			}
			for(int i = 0; i < m_otherCollisons.Count; i++)
			{
				m_otherCollisons[i].OnAwake();
			}
		}

		// RVA: 0x1CF4CD4 Offset: 0x1CF4CD4 VA: 0x1CF4CD4 Slot: 12
		public override void OnStart()
		{
			for(int i = 0; i < m_playerCollisons.Count; i++)
			{
				m_playerCollisons[i].OnStart();
			}
			for(int i = 0; i < m_otherCollisons.Count; i++)
			{
				m_otherCollisons[i].OnStart();
			}
		}

		//// RVA: 0x1CF4E20 Offset: 0x1CF4E20 VA: 0x1CF4E20 Slot: 13
		//public override void Initialize() { }

		//// RVA: 0x1CF4ED0 Offset: 0x1CF4ED0 VA: 0x1CF4ED0 Slot: 14
		//public override void Pause() { }

		//// RVA: 0x1CF501C Offset: 0x1CF501C VA: 0x1CF501C Slot: 15
		//public override void UnPause() { }

		// RVA: 0x1CF5168 Offset: 0x1CF5168 VA: 0x1CF5168 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_otherCollisons.Sort((ShootingCollision a, ShootingCollision b) =>
			{
				//0x1CF568C
				return (int)(a.m_pos.x - b.m_pos.x);
			});
			for(int i = 0; i < m_playerCollisons.Count; i++)
			{
				ShootingCollision c = m_playerCollisons[i];
				for(int j = 0; j < m_otherCollisons.Count; j++)
				{
					if(!m_otherCollisons[i].Owner.IsStatus(TaskStatus.Dead))
					{
						if(Vector2.Distance(c.m_pos, m_otherCollisons[i].m_pos) < c.m_radius + m_otherCollisons[i].m_radius)
						{
							c.HitCallBack(m_otherCollisons[i]);
							m_otherCollisons[i].HitCallBack(c);
						}
						if (c.Owner.IsStatus(TaskStatus.Dead))
							break;
					}
				}
			}
		}

		// RVA: 0x1CF5568 Offset: 0x1CF5568 VA: 0x1CF5568 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			return;
		}
	}
}
