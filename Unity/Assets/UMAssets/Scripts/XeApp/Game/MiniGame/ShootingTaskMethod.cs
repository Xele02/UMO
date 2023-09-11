
namespace XeApp.Game.MiniGame
{
	internal interface ShootingTaskMethod
	{
		// RVA: -1 Offset: -1 Slot: 0
		void OnAwake();

		//// RVA: -1 Offset: -1 Slot: 1
		void OnStart();

		//// RVA: -1 Offset: -1 Slot: 2
		//public abstract void Initialize();

		//// RVA: -1 Offset: -1 Slot: 3
		//public abstract void Pause();

		//// RVA: -1 Offset: -1 Slot: 4
		//public abstract void UnPause();

		// RVA: -1 Offset: -1 Slot: 5
		void OnUpdate(float elapsedTime);

		// RVA: -1 Offset: -1 Slot: 6
		void OnLateUpdate(float elapsedTime);
	}
}
