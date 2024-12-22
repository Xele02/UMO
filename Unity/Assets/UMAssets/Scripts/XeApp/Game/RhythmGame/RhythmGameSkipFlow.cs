using System;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameSkipFlow
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
		private RhythmGameSkipPlayer gamePlayer; // 0x18
		private Action rhythmGameBeginedAction; // 0x1C
		private Action rhythmGameEndedAction; // 0x20
		private Action errorToTitleAction; // 0x24
		private Difficulty.Type difficluty; // 0x28
		private bool isGameSESoundLoaded; // 0x2C
		private bool isDivaSoundLoaded; // 0x2D
		private bool isPilotSoundLoaded; // 0x2E
		private bool isGameSaveEnd; // 0x2F
		private bool isGameSaveError; // 0x30
		private Action updater; // 0x34

		//public Status status { get; private set; } 0xBFF090 0xBFF098

		// RVA: 0xBFF0A0 Offset: 0xBFF0A0 VA: 0xBFF0A0
		public RhythmGameSkipFlow(RhythmGameResource resouce, Action rhythmGameLoadedAction, Difficulty.Type difficluty, Action rhythmGameBeginedAction, RhythmGameSkipPlayer gamePlayer, RhythmGameUIController uiController, Action rhythmGameEndedAction, Action errorToTitleAction)
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

		//// RVA: 0xBFF0FC Offset: 0xBFF0FC VA: 0xBFF0FC
		public void ChangeSetupGameDataStatus()
		{
			currentStatus = Status.SetupGameData;
			updater = SetupGameData;
		}

		//// RVA: 0xBFF18C Offset: 0xBFF18C VA: 0xBFF18C
		//public void ChangeWaitDownloadingMasterStatus() { }

		//// RVA: 0xBFF21C Offset: 0xBFF21C VA: 0xBFF21C
		public void ChangeWaitLoadingStatus()
		{
			currentStatus = Status.WaitLoadingResource;
			updater = WaitLoadingResource;
		}

		//// RVA: 0xBFF2AC Offset: 0xBFF2AC VA: 0xBFF2AC
		public void ChangeGameStatus()
		{
			currentStatus = Status.Game;
			updater = BeginRhythmGame;
		}

		//// RVA: 0xBFF33C Offset: 0xBFF33C VA: 0xBFF33C
		public void ChangeEndGameStatus()
		{
			currentStatus = Status.EndGame;
			updater = BeginCompleteAnim;
		}

		//// RVA: 0xBFF3CC Offset: 0xBFF3CC VA: 0xBFF3CC
		public void ChangeNextSceneStatus()
		{
			currentStatus = Status.NextScene;
			rhythmGameEndedAction();
		}

		//// RVA: 0xBFF400 Offset: 0xBFF400 VA: 0xBFF400
		public void ChangeErrorToTilteStatus()
		{
			currentStatus = Status.ErrorToTitle;
			errorToTitleAction();
		}

		//// RVA: 0xBFF434 Offset: 0xBFF434 VA: 0xBFF434
		private void SetupGameData()
		{
			currentStatus = Status.WaitDownloadingMaster;
			updater = WaitDownloadingMaster;
		}

		//// RVA: 0xBFF438 Offset: 0xBFF438 VA: 0xBFF438
		private void WaitDownloadingMaster()
		{
			rhythmGameResource.musicData.LoadData(Database.Instance.gameSetup.musicInfo.prismMusicId, (int)Database.Instance.gameSetup.musicInfo.difficultyType, Database.Instance.gameSetup.musicInfo.onStageDivaNum, Database.Instance.gameSetup.musicInfo.IsLine6Mode);
			ChangeWaitLoadingStatus();
		}

		//// RVA: 0xBFF604 Offset: 0xBFF604 VA: 0xBFF604
		private void WaitLoadingResource()
		{
			if(rhythmGameResource.musicData.isAllLoaded)
			{
				rhythmGameLoadedAction();
				GameSaveStart();
			}
		}

		//// RVA: 0xBFF678 Offset: 0xBFF678 VA: 0xBFF678
		private void GameSaveStart()
		{
			isGameSaveEnd = false;
			isGameSaveError = false;
			JGEOBNENMAH.HHCJCDFCLOB.CNNNAAACEHE_GameStartSave(true, () =>
			{
				//0xBFF9A4
				isGameSaveEnd = true;
			}, () =>
			{
				//0xBFF9B0
				isGameSaveEnd = true;
				isGameSaveError = true;
			});
			updater = WaitGameSave;
		}

		//// RVA: 0xBFF7E4 Offset: 0xBFF7E4 VA: 0xBFF7E4
		private void WaitGameSave()
		{
			if (!isGameSaveEnd)
				return;
			if(isGameSaveError)
			{
				ChangeErrorToTilteStatus();
				updater = null;
			}
			else
			{
				ChangeGameStatus();
			}
		}

		//// RVA: 0xBFF828 Offset: 0xBFF828 VA: 0xBFF828
		private void BeginRhythmGame()
		{
			rhythmGameBeginedAction();
			updater = UpdateRhythmGame;
		}

		//// RVA: 0xBFF8D0 Offset: 0xBFF8D0 VA: 0xBFF8D0
		private void UpdateRhythmGame()
		{
			if (!gamePlayer.IsRhythmGamePlayerEnd())
				return;
			updater = null;
			ChangeEndGameStatus();
		}

		//// RVA: 0xBFF974 Offset: 0xBFF974 VA: 0xBFF974
		private void BeginCompleteAnim()
		{
			ChangeNextSceneStatus();
			updater = null;
		}

		//// RVA: 0xBFF990 Offset: 0xBFF990 VA: 0xBFF990
		public void OnUpdate()
		{
			if (updater != null)
				updater();
		}
	}
}
