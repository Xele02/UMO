using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingItemManager : ShootingTask
	{
		public List<ShootingItemPool> m_itemPoolObj; // 0x10
		private List<ShootingItemPool> m_itemPoolList = new List<ShootingItemPool>(); // 0x14
		private ShootingTaskManager m_taskManager; // 0x18

		public ShootingResulData ResulData { get; set; } // 0x1C
		public ShootingCollisionManager CollisionManager { get; set; } // 0x20
		public RectTransform MainScreen { get; set; } // 0x24

		//// RVA: 0x1CF6BF4 Offset: 0x1CF6BF4 VA: 0x1CF6BF4
		public void SetItem(ShootingStageData.StageItemType itemType, Vector3 pos)
		{
			for(int i = 0; i < m_itemPoolList.Count; i++)
			{
				if(m_itemPoolList[i].m_taskObject.GetItemType() == itemType)
				{
					ShootingItem s = m_itemPoolList[i].Alloc();
					s.SetItem(pos);
				}
			}
		}

		// RVA: 0x1CFF394 Offset: 0x1CFF394 VA: 0x1CFF394 Slot: 11
		public override void OnAwake()
		{
			OnActive();
			for(int i = 0; i < m_itemPoolObj.Count; i++)
			{
				ShootingItemPool s = Instantiate(m_itemPoolObj[i]);
				s.ResulData = ResulData;
				s.CollisionManager = CollisionManager;
				s.MainScreen = MainScreen;
				s.Create();
				s.transform.SetParent(transform, false);
				m_itemPoolList.Add(s);
			}
			m_taskManager = new ShootingTaskManager();
			for(int i = 0; i < m_itemPoolList.Count; i++)
			{
				m_taskManager.AddTask(m_itemPoolList[i]);
			}
			m_taskManager.OnAwake();
		}

		//// RVA: 0x1CFF758 Offset: 0x1CFF758 VA: 0x1CFF758 Slot: 14
		//public override void Pause() { }

		//// RVA: 0x1CFF784 Offset: 0x1CFF784 VA: 0x1CFF784 Slot: 15
		//public override void UnPause() { }

		// RVA: 0x1CFF7B0 Offset: 0x1CFF7B0 VA: 0x1CFF7B0 Slot: 12
		public override void OnStart()
		{
			m_taskManager.OnStart();
		}

		//// RVA: 0x1CFF7DC Offset: 0x1CFF7DC VA: 0x1CFF7DC Slot: 13
		//public override void Initialize() { }

		// RVA: 0x1CFF814 Offset: 0x1CFF814 VA: 0x1CFF814 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_taskManager.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFF848 Offset: 0x1CFF848 VA: 0x1CFF848 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			m_taskManager.OnUpdate(elapsedTime);
		}
	}
}
