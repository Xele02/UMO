using System;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameFlow
	{
		public enum Status
		{
			Default = 0,
			SetupGameData = 1,
			WaitDownloadingMaster = 2,
			WaitLoadingResource = 3,
			WaitDownloadingSpecial = 4,
			WaitLoadingSpecialResource = 5,
			WaitDownloadingData = 6,
			WaitLoadingData = 7,
			SetTexture = 8,
			Warmup = 9,
			Game = 10,
			EndGame = 11,
			NextScene = 12,
			ErrorToTitle = 13,
		}

		private Status currentStatus; // 0x8
		private RhythmGameResource rhythmGameResource; // 0xC
		private RhythmGameUIController uiController; // 0x10
		private Action rhythmGameLoadedAction; // 0x14
		private RhythmGamePlayer gamePlayer; // 0x18
		private Action rhythmGameBeginedAction; // 0x1C
		private Action rhythmGameEndedAction; // 0x20
		private Action errorToTitleAction; // 0x24
		private Difficulty.Type difficluty; // 0x28
		private bool isBgmSoundLoaded; // 0x2C
		private bool isGameSESoundLoaded; // 0x2D
		private bool isDivaSoundLoaded; // 0x2E
		private bool isPilotSoundLoaded; // 0x2F
		private bool isGameSaveEnd; // 0x30
		private bool isGameSaveError; // 0x31
		private Action updater; // 0x34
		private bool isDivaCosSoundLoaded; // 0x39

		public Status status { get { return currentStatus; } set { currentStatus = value; } }
		public bool IsRareBreak { get; set; }  // 0x38

		// // RVA: 0xDC67A8 Offset: 0xDC67A8 VA: 0xDC67A8
		public RhythmGameFlow(RhythmGameResource resouce, Action rhythmGameLoadedAction, Difficulty.Type difficluty, Action rhythmGameBeginedAction, RhythmGamePlayer gamePlayer, RhythmGameUIController uiController, Action rhythmGameEndedAction, Action errorToTitleAction)
		{
			currentStatus = Status.Default;
			rhythmGameResource = resouce;
			this.uiController = uiController;
			this.rhythmGameLoadedAction = rhythmGameLoadedAction;
			this.gamePlayer = gamePlayer;
			this.rhythmGameBeginedAction = rhythmGameBeginedAction;
			this.rhythmGameEndedAction = rhythmGameEndedAction;
			this.errorToTitleAction = errorToTitleAction;
			this.difficluty = difficluty;
			ChangeSetupGameDataStatus();
		}

		// // RVA: 0xDC6804 Offset: 0xDC6804 VA: 0xDC6804
		public void ChangeSetupGameDataStatus()
		{
			currentStatus = Status.SetupGameData;
			updater = this.SetupGameData;
		}

		// // RVA: 0xDC6894 Offset: 0xDC6894 VA: 0xDC6894
		// public void ChangeWaitDownloadingMasterStatus() { }

		// // RVA: 0xDC6924 Offset: 0xDC6924 VA: 0xDC6924
		public void ChangeWaitLoadingStatus()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xDC69B4 Offset: 0xDC69B4 VA: 0xDC69B4
		// public void ChangeWaitDownloadingSpecialResourceStatus() { }

		// // RVA: 0xDC6A44 Offset: 0xDC6A44 VA: 0xDC6A44
		// public void ChangeWaitLoadingSpecialResourceStatus() { }

		// // RVA: 0xDC6AD4 Offset: 0xDC6AD4 VA: 0xDC6AD4
		// public void ChangeWaitDownloadingDataStatus() { }

		// // RVA: 0xDC6B64 Offset: 0xDC6B64 VA: 0xDC6B64
		// public void ChangeWaitLoadingDataStatus() { }

		// // RVA: 0xDC6BF4 Offset: 0xDC6BF4 VA: 0xDC6BF4
		// public void ChangeSetTextureStatus() { }

		// // RVA: 0xDC6C84 Offset: 0xDC6C84 VA: 0xDC6C84
		// public void ChangeWarmupStatus() { }

		// // RVA: 0xDC6D14 Offset: 0xDC6D14 VA: 0xDC6D14
		// public void ChangeGameStatus() { }

		// // RVA: 0xDC6DA4 Offset: 0xDC6DA4 VA: 0xDC6DA4
		// public void ChangeEndGameStatus() { }

		// // RVA: 0xDC6E34 Offset: 0xDC6E34 VA: 0xDC6E34
		// public void ChangeNextSceneStatus() { }

		// // RVA: 0xDC6E68 Offset: 0xDC6E68 VA: 0xDC6E68
		// public void ChangeErrorToTilteStatus() { }

		// // RVA: 0xDC6E9C Offset: 0xDC6E9C VA: 0xDC6E9C
		private void SetupGameData()
		{
			currentStatus = Status.WaitDownloadingMaster;
			updater = this.WaitDownloadingMaster;
		}

		// // RVA: 0xDC6EA0 Offset: 0xDC6EA0 VA: 0xDC6EA0
		private void WaitDownloadingMaster()
		{
			GameSetupData gameSetup = XeSys.SingletonBehaviour<Database>.Instance.gameSetup;
			int stageDivaNum = gameSetup.musicInfo.onStageDivaNum;
			int musicId = gameSetup.musicInfo.prismMusicId;
			Difficulty.Type difficulty = gameSetup.musicInfo.difficultyType;
			bool line6Mode = gameSetup.musicInfo.IsLine6Mode;
			rhythmGameResource.paramResource.LoadResource();
			rhythmGameResource.musicData.LoadData(musicId, (int)difficulty, stageDivaNum, line6Mode);
			ChangeWaitLoadingStatus();
		}

		// // RVA: 0xDC7128 Offset: 0xDC7128 VA: 0xDC7128
		// private void WaitLoadingResource() { }

		// // RVA: 0xDC726C Offset: 0xDC726C VA: 0xDC726C
		// private void WaitDownloadingSpecialResource() { }

		// // RVA: 0xDC80E4 Offset: 0xDC80E4 VA: 0xDC80E4
		// private void WaitLoadingSpecialResource() { }

		// // RVA: 0xDC8228 Offset: 0xDC8228 VA: 0xDC8228
		// private void WaitDownloadingData() { }

		// // RVA: 0xDC9D94 Offset: 0xDC9D94 VA: 0xDC9D94
		// private void WaitLoadingData() { }

		// // RVA: 0xDC9FD8 Offset: 0xDC9FD8 VA: 0xDC9FD8
		// private void SetStatusDivaTexture() { }

		// // RVA: 0xDC9FDC Offset: 0xDC9FDC VA: 0xDC9FDC
		// private void WaitWarmup() { }

		// // RVA: 0xDCA0E4 Offset: 0xDCA0E4 VA: 0xDCA0E4
		// private void GameSaveStart() { }

		// // RVA: 0xDCA250 Offset: 0xDCA250 VA: 0xDCA250
		// private void WaitGameSave() { }

		// // RVA: 0xDCA294 Offset: 0xDCA294 VA: 0xDCA294
		// private void BeginRhythmGame() { }

		// // RVA: 0xDCA33C Offset: 0xDCA33C VA: 0xDCA33C
		// private void UpdateRhythmGame() { }

		// // RVA: 0xDCA384 Offset: 0xDCA384 VA: 0xDCA384
		// private void BeginCompleteAnim() { }

		// // RVA: 0xDCA4A8 Offset: 0xDCA4A8 VA: 0xDCA4A8
		public void OnUpdate()
		{
			if(updater != null)
				updater();
		}

		// [CompilerGeneratedAttribute] // RVA: 0x7440FC Offset: 0x7440FC VA: 0x7440FC
		// // RVA: 0xDCA4BC Offset: 0xDCA4BC VA: 0xDCA4BC
		// private void <WaitDownloadingData>b__44_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x74410C Offset: 0x74410C VA: 0x74410C
		// // RVA: 0xDCA4C8 Offset: 0xDCA4C8 VA: 0xDCA4C8
		// private void <WaitDownloadingData>b__44_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x74411C Offset: 0x74411C VA: 0x74411C
		// // RVA: 0xDCA4D4 Offset: 0xDCA4D4 VA: 0xDCA4D4
		// private void <WaitDownloadingData>b__44_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x74412C Offset: 0x74412C VA: 0x74412C
		// // RVA: 0xDCA4E0 Offset: 0xDCA4E0 VA: 0xDCA4E0
		// private void <WaitDownloadingData>b__44_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x74413C Offset: 0x74413C VA: 0x74413C
		// // RVA: 0xDCA4EC Offset: 0xDCA4EC VA: 0xDCA4EC
		// private void <WaitDownloadingData>b__44_4() { }

		// [CompilerGeneratedAttribute] // RVA: 0x74414C Offset: 0x74414C VA: 0x74414C
		// // RVA: 0xDCA4F8 Offset: 0xDCA4F8 VA: 0xDCA4F8
		// private void <WaitDownloadingData>b__44_5() { }

		// [CompilerGeneratedAttribute] // RVA: 0x74415C Offset: 0x74415C VA: 0x74415C
		// // RVA: 0xDCA504 Offset: 0xDCA504 VA: 0xDCA504
		// private void <WaitDownloadingData>b__44_6() { }

		// [CompilerGeneratedAttribute] // RVA: 0x74416C Offset: 0x74416C VA: 0x74416C
		// // RVA: 0xDCA510 Offset: 0xDCA510 VA: 0xDCA510
		// private void <GameSaveStart>b__48_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x74417C Offset: 0x74417C VA: 0x74417C
		// // RVA: 0xDCA51C Offset: 0xDCA51C VA: 0xDCA51C
		// private void <GameSaveStart>b__48_1() { }
	}
}
