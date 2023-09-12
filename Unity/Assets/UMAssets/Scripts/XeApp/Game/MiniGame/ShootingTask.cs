using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public abstract class ShootingTask : MonoBehaviour, ShootingTaskMethod
	{
		public enum TaskStatus
		{
			Active = 0,
			Dead = 1,
		}

		private uint m_status; // 0xC

		//// RVA: -1 Offset: -1 Slot: 11
		public abstract void OnAwake();

		//// RVA: -1 Offset: -1 Slot: 12
		public abstract void OnStart();

		//// RVA: -1 Offset: -1 Slot: 13
		public abstract void Initialize();

		//// RVA: -1 Offset: -1 Slot: 14
		public abstract void Pause();

		//// RVA: -1 Offset: -1 Slot: 15
		public abstract void UnPause();

		//// RVA: -1 Offset: -1 Slot: 16
		public abstract void OnUpdate(float elapsedTime);

		//// RVA: -1 Offset: -1 Slot: 17
		public abstract void OnLateUpdate(float elapsedTime);

		//// RVA: 0xC8F32C Offset: 0xC8F32C VA: 0xC8F32C
		public void OnActive()
		{
			SetStatus(TaskStatus.Active);
			gameObject.SetActive(true);
		}

		//// RVA: 0xC8FB44 Offset: 0xC8FB44 VA: 0xC8FB44 Slot: 18
		public virtual void OnSleep()
		{
			m_status = 0;
			gameObject.SetActive(false);
		}

		//// RVA: 0xC8DD68 Offset: 0xC8DD68 VA: 0xC8DD68
		public void SetStatus(TaskStatus status)
		{
			m_status |= (uint)(1 << (int)status);
		}

		//// RVA: 0xC91CE0 Offset: 0xC91CE0 VA: 0xC91CE0
		//public void ClearStatus(ShootingTask.TaskStatus status) { }

		//// RVA: 0xC91CD4 Offset: 0xC91CD4 VA: 0xC91CD4
		//public void AllClearStatus() { }

		//// RVA: 0xC8EA74 Offset: 0xC8EA74 VA: 0xC8EA74
		public bool IsStatus(TaskStatus status)
		{
			return (m_status & (1 << (int)status)) != 0;
		}
	}
}
