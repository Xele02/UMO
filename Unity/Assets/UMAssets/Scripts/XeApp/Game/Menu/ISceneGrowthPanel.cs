using UnityEngine;

namespace XeApp.Game.Menu
{
		public enum GrowthPanelType
		{
			Normal = 0,
			Infinity = 1,
		}

	public interface ISceneGrowthPanel
	{
		GrowthPanelType PanelType { get; } // Slot: 0
		Transform transform { get; } // Slot: 1

		//// RVA: -1 Offset: -1 Slot: 2
		//void Wait();

		//// RVA: -1 Offset: -1 Slot: 3
		void Expand();

		//// RVA: -1 Offset: -1 Slot: 4
		void PlayUnLockAnime();

		//// RVA: -1 Offset: -1 Slot: 5
		void PlayExpandAnime();

		//// RVA: -1 Offset: -1 Slot: 6
		//void ConnectEffect(GameObject eff);

		//// RVA: -1 Offset: -1 Slot: 7
		//GameObject DisConnectEffect(Transform parent);

		//// RVA: -1 Offset: -1 Slot: 8
		void ShowLoopEffect();

		//// RVA: -1 Offset: -1 Slot: 9
		void StopLoopEffect();
	}
}
