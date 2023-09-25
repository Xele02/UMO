using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingGameSceneState : MonoBehaviour
	{
		public enum GameSceneState
		{
			None = 0,
			Title = 1,
			MainScene = 2,
			GameOver = 3,
			GameClear = 4,
			Result = 5,
			Retry = 6,
		}
 
		public enum GameMainState
		{
			None = 0,
			Normal = 1,
			BossEntry = 2,
			BossMain = 3,
		}

		public static GameSceneState SceneState { get; set; }  // 0x0
		public static GameMainState MainSceneState { get; set; } // 0x4

		// RVA: 0x1CFE798 Offset: 0x1CFE798 VA: 0x1CFE798
		private void Awake()
		{
			SceneState = GameSceneState.None;
			MainSceneState = GameMainState.None;
		}
	}
}
