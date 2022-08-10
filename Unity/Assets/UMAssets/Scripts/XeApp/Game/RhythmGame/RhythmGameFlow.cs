using System;
using System.Collections.Generic;
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
			currentStatus = Status.WaitLoadingResource;
			updater = this.WaitLoadingResource;
		}

		// // RVA: 0xDC69B4 Offset: 0xDC69B4 VA: 0xDC69B4
		public void ChangeWaitDownloadingSpecialResourceStatus()
		{
			currentStatus = Status.WaitDownloadingSpecial;
			updater = this.WaitDownloadingSpecialResource;
		}

		// // RVA: 0xDC6A44 Offset: 0xDC6A44 VA: 0xDC6A44
		public void ChangeWaitLoadingSpecialResourceStatus()
		{
			currentStatus = Status.WaitLoadingSpecialResource;
			updater = this.WaitLoadingSpecialResource;
		}

		// // RVA: 0xDC6AD4 Offset: 0xDC6AD4 VA: 0xDC6AD4
		public void ChangeWaitDownloadingDataStatus()
		{
			currentStatus = Status.WaitDownloadingData;
			updater = this.WaitDownloadingData;
		}

		// // RVA: 0xDC6B64 Offset: 0xDC6B64 VA: 0xDC6B64
		public void ChangeWaitLoadingDataStatus()
		{
			currentStatus = Status.WaitLoadingData;
			updater = this.WaitLoadingData;
		}

		// // RVA: 0xDC6BF4 Offset: 0xDC6BF4 VA: 0xDC6BF4
		public void ChangeSetTextureStatus()
		{
			currentStatus = Status.SetTexture;
			updater = this.SetStatusDivaTexture;
		}

		// // RVA: 0xDC6C84 Offset: 0xDC6C84 VA: 0xDC6C84
		// public void ChangeWarmupStatus() { }

		// // RVA: 0xDC6D14 Offset: 0xDC6D14 VA: 0xDC6D14
		public void ChangeGameStatus()
		{
			currentStatus = Status.Game;
			updater = this.BeginRhythmGame;
		}

		// // RVA: 0xDC6DA4 Offset: 0xDC6DA4 VA: 0xDC6DA4
		public void ChangeEndGameStatus()
		{
			currentStatus = Status.EndGame;
			updater = this.BeginCompleteAnim;
		}

		// // RVA: 0xDC6E34 Offset: 0xDC6E34 VA: 0xDC6E34
		public void ChangeNextSceneStatus()
		{
			currentStatus = Status.NextScene;
			rhythmGameEndedAction();
		}

		// // RVA: 0xDC6E68 Offset: 0xDC6E68 VA: 0xDC6E68
		public void ChangeErrorToTilteStatus()
		{
			TodoLogger.Log(0, "ChangeErrorToTilteStatus");
		}

		// // RVA: 0xDC6E9C Offset: 0xDC6E9C VA: 0xDC6E9C
		private void SetupGameData()
		{
			currentStatus = Status.WaitDownloadingMaster;
			updater = this.WaitDownloadingMaster;
		}

		// // RVA: 0xDC6EA0 Offset: 0xDC6EA0 VA: 0xDC6EA0
		private void WaitDownloadingMaster()
		{
			GameSetupData gameSetup = Database.Instance.gameSetup;
			int stageDivaNum = gameSetup.musicInfo.onStageDivaNum;
			int musicId = gameSetup.musicInfo.prismMusicId;
			Difficulty.Type difficulty = gameSetup.musicInfo.difficultyType;
			bool line6Mode = gameSetup.musicInfo.IsLine6Mode;
			rhythmGameResource.paramResource.LoadResource();
			rhythmGameResource.musicData.LoadData(musicId, (int)difficulty, stageDivaNum, line6Mode);
			ChangeWaitLoadingStatus();
		}

		// // RVA: 0xDC7128 Offset: 0xDC7128 VA: 0xDC7128
		private void WaitLoadingResource()
		{
			if(GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				if (!rhythmGameResource.is3DModeMusicDataResoucesLoaded)
					return;
			}
			else
			{
				if (!rhythmGameResource.is2DModeMusicDataResoucesLoaded)
					return;
			}
			ChangeWaitDownloadingSpecialResourceStatus();
		}

		// // RVA: 0xDC726C Offset: 0xDC726C VA: 0xDC726C
		private void WaitDownloadingSpecialResource()
		{
			GameSetupData.TeamInfo teamInfo = Database.Instance.gameSetup.teamInfo;
			GameSetupData.MusicInfo musicInfo = Database.Instance.gameSetup.musicInfo;
			int stageDivaNum = musicInfo.onStageDivaNum;
			MusicDirectionParamBase musicParam = rhythmGameResource.musicData.musicParam;
			int basaraPos = musicParam.basaraPositionId;
			int pos = basaraPos;
			if (stageDivaNum - 1 > 0)
			{
				int freePos = 0;
				for(int i = 0; i < stageDivaNum; i++)
				{
					if(teamInfo.danceDivaList[i].prismDivaId == 9)
					{
						if (teamInfo.danceDivaList[i].positionId == basaraPos)
							break;
						freePos = teamInfo.danceDivaList[i].positionId;
						teamInfo.danceDivaList[i].positionId = basaraPos;
					}
				}
				if(freePos != 0)
				{
					for(int i = 0; i < stageDivaNum; i++)
					{
						if (teamInfo.danceDivaList[i].prismDivaId != 9)
						{
							if(teamInfo.danceDivaList[i].positionId == basaraPos)
							{
								teamInfo.danceDivaList[i].positionId = freePos;
								break;
							}
						}
					}
				}
			}
			EONOEHOKBEB_Music DbMusicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(musicInfo.prismMusicId);
			int wavId = 0;
			if(musicInfo.isFreeMode)
			{
				wavId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(musicInfo.freeMusicId).KEFGPJBKAOD_WavId;
			}
			else
			{
				wavId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ(musicInfo.storyMusicId).KEFGPJBKAOD;
			}
			PNGOLKLFFLH p = new PNGOLKLFFLH();
			p.KHEKNNFCAOI_Init(teamInfo.prismValkyrieId, 0, 0);

			List<MusicDirectionParamBase.ConditionSetting> settingList = new List<MusicDirectionParamBase.ConditionSetting>();
			MusicDirectionParamBase.ConditionSetting cond = new MusicDirectionParamBase.ConditionSetting(teamInfo.danceDivaList[0].prismDivaId, teamInfo.danceDivaList[0].prismCostumeModelId, teamInfo.prismValkyrieId, p.OPBPKNHIPPE.PFGJJLGLPAC, teamInfo.danceDivaList[0].positionId);
			settingList.Add(cond);
			int cnt = 0;
			for(int i = 0; i < 4; i++)
			{
				if (rhythmGameResource.subDivaResource.Count <= i) break;
				if(cnt < stageDivaNum - 1)
				{
					if(teamInfo.danceDivaList[i + 1].prismDivaId == 0)
					{
						rhythmGameResource.subDivaResource[i] = null;
					}
					else
					{
						cond = new MusicDirectionParamBase.ConditionSetting(teamInfo.danceDivaList[i + 1].prismDivaId, teamInfo.danceDivaList[i + 1].prismCostumeModelId, teamInfo.prismValkyrieId, p.OPBPKNHIPPE.PFGJJLGLPAC, teamInfo.danceDivaList[i + 1].positionId);
						settingList.Add(cond);
					}
				}
				else
				{
					rhythmGameResource.subDivaResource[i] = null;
				}
			}
			if(GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				rhythmGameResource.LoadSpecialDirectionResource(DbMusicInfo.KKPAHLMJKIH_WavId, stageDivaNum, settingList);
			}
			else
			{
				rhythmGameResource.LoadSpecialResourceFor2DMode(DbMusicInfo.KKPAHLMJKIH_WavId, stageDivaNum, settingList);
			}
			ChangeWaitLoadingSpecialResourceStatus();
			TodoLogger.Log(0, "check WaitDownloadingSpecialResource");
		}

		// // RVA: 0xDC80E4 Offset: 0xDC80E4 VA: 0xDC80E4
		private void WaitLoadingSpecialResource()
		{
			if (GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				if (!rhythmGameResource.is3DModeSpecialResoucesLoaded)
					return;
			}
			else
			{
				if (!rhythmGameResource.is2DModeSpecialResoucesLoaded)
					return;
			}
			ChangeWaitDownloadingDataStatus();
		}

		// // RVA: 0xDC8228 Offset: 0xDC8228 VA: 0xDC8228
		private void WaitDownloadingData()
		{

			TodoLogger.Log(0, "WaitDownloadingData");
			int wavId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(Database.Instance.gameSetup.musicInfo.prismMusicId).KKPAHLMJKIH_WavId;

			isPilotSoundLoaded = true;
			isDivaSoundLoaded = true;
			isBgmSoundLoaded = true;
			isGameSESoundLoaded = true;
			isDivaCosSoundLoaded = true;
			// setup ennemy info

			if (GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				int intro = 0, introSky = 0;
				rhythmGameResource.paramResource.m_paramIntro.Check(Database.Instance.gameSetup, ref intro, ref introSky);
				int battle = 0;
				rhythmGameResource.paramResource.m_paramBattle.Check(Database.Instance.gameSetup, ref battle);
				rhythmGameResource.LoadUITextureResouces();
				rhythmGameResource.divaResource.LoadBasicResource(Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId,
																	Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismCostumeModelId,
																	Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismCostumeColorId);
				rhythmGameResource.divaResource.LoadFacialResource(Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId, wavId,
																		Database.Instance.gameSetup.musicInfo.onStageDivaNum);
				List<int> prime = new List<int>();
				for(int i = 0; i < Database.Instance.gameSetup.musicInfo.onStageDivaNum; i++)
				{
					prime.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK(Database.Instance.gameSetup.teamInfo.danceDivaList[i].prismDivaId).IDDHKOEFJFB);
				}
				rhythmGameResource.divaResource.LoadMusicAnimationResource(wavId, GameManager.Instance.GetMultipleDanceOverridePrimeId(prime),
																		Database.Instance.gameSetup.teamInfo.danceDivaList[0].positionId,
																		Database.Instance.gameSetup.musicInfo.onStageDivaNum,
																		Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId);
				rhythmGameResource.cameraResource.LoadResource(wavId, GameManager.Instance.GetMultipleDanceOverridePrimeId(prime), Database.Instance.gameSetup.musicInfo.onStageDivaNum);
				int stageId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(Database.Instance.gameSetup.musicInfo.freeMusicId).KEFGPJBKAOD_WavId;
				// todo story stageid
				rhythmGameResource.stageResources.LoadResouces(stageId, rhythmGameResource.GetSpecialStageResourceId);
				rhythmGameResource.valkyrieResource.LoadResources(Database.Instance.gameSetup.teamInfo.prismValkyrieId, introSky, battle);
				rhythmGameResource.musicIntroResource.LoadResources(intro, introSky, Database.Instance.gameSetup.teamInfo.prismValkyrieId);
				rhythmGameResource.valkyrieModeResource.LoadResources(battle, Database.Instance.gameSetup.teamInfo.prismValkyrieId);
				rhythmGameResource.musicBoneSpringResource[0].LoadMusicResouces(wavId, GameManager.Instance.GetMultipleDanceOverridePrimeId(prime),
												Database.Instance.gameSetup.musicInfo.onStageDivaNum, Database.Instance.gameSetup.musicInfo.onStageDivaNum > 1 ? Database.Instance.gameSetup.teamInfo.danceDivaList[0].positionId : 0);
				if(GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.GPKILPOLNKO())
				{
					rhythmGameResource.divaModeResource.LoadResources(wavId, GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.CBLEFELBNDN_GetQuality(), rhythmGameResource.GetSpecialDirectionMovieId);
				}
				for(int i = 0; i < 4 && i < rhythmGameResource.subDivaResource.Count; i++)
				{
					if(i < Database.Instance.gameSetup.musicInfo.onStageDivaNum - 1)
					{
						if (Database.Instance.gameSetup.teamInfo.danceDivaList[i + 1].prismDivaId == 0)
							rhythmGameResource.subDivaResource[i] = null;
						else
						{
							rhythmGameResource.subDivaResource[i].LoadBasicResource(Database.Instance.gameSetup.teamInfo.danceDivaList[i + 1].prismDivaId,
																	Database.Instance.gameSetup.teamInfo.danceDivaList[i + 1].prismCostumeModelId,
																	Database.Instance.gameSetup.teamInfo.danceDivaList[i + 1].prismCostumeColorId);
							rhythmGameResource.subDivaResource[i].LoadFacialResource(Database.Instance.gameSetup.teamInfo.danceDivaList[i + 1].prismDivaId, wavId,
																					Database.Instance.gameSetup.musicInfo.onStageDivaNum);
							rhythmGameResource.subDivaResource[i].LoadMusicAnimationResource(wavId, GameManager.Instance.GetMultipleDanceOverridePrimeId(prime),
																					Database.Instance.gameSetup.teamInfo.danceDivaList[i + 1].positionId,
																					Database.Instance.gameSetup.musicInfo.onStageDivaNum,
																					Database.Instance.gameSetup.teamInfo.danceDivaList[i + 1].prismDivaId);
							rhythmGameResource.musicBoneSpringResource[i + 1].LoadMusicResouces(wavId, GameManager.Instance.GetMultipleDanceOverridePrimeId(prime),
															Database.Instance.gameSetup.musicInfo.onStageDivaNum, Database.Instance.gameSetup.teamInfo.danceDivaList[i + 1].positionId);
						}
					}
					else
					{
						rhythmGameResource.subDivaResource[i] = null;
					}
				}
			}
			else
			{
				//2d mode
			}

			ChangeWaitLoadingDataStatus();
		}

		// // RVA: 0xDC9D94 Offset: 0xDC9D94 VA: 0xDC9D94
		private void WaitLoadingData()
		{
			if (GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				if (!rhythmGameResource.is3DModeAllResoucesLoaded)
					return;
			}
			else
			{
				if (!rhythmGameResource.is2DModeAllResoucesLoaded)
					return;
			}
			if (isBgmSoundLoaded && isGameSESoundLoaded && isDivaSoundLoaded && !IsRareBreak && isDivaCosSoundLoaded && isPilotSoundLoaded
				&& SoundManager.Instance.sePlayerCheer.IsLoaded() && FacialNameDatabase.isInitialized)
			{
				rhythmGameLoadedAction();
				ChangeSetTextureStatus();
			}
		}

		// // RVA: 0xDC9FD8 Offset: 0xDC9FD8 VA: 0xDC9FD8
		private void SetStatusDivaTexture()
		{
			currentStatus = Status.Warmup;
			updater = this.WaitWarmup;
		}

		// // RVA: 0xDC9FDC Offset: 0xDC9FDC VA: 0xDC9FDC
		private void WaitWarmup()
		{
			TodoLogger.Log(0, "WaitWarmup hud");
			//if(uiController.Hud.IsWarmupEnd())
			{
				GameSaveStart();
			}
		}

		// // RVA: 0xDCA0E4 Offset: 0xDCA0E4 VA: 0xDCA0E4
		private void GameSaveStart()
		{
			isGameSaveEnd = false;
			isGameSaveError = false;
			{
				TodoLogger.Log(0, "GameSaveStart");
				isGameSaveEnd = true;
			}
			updater = this.WaitGameSave;
		}

		// // RVA: 0xDCA250 Offset: 0xDCA250 VA: 0xDCA250
		private void WaitGameSave()
		{
			if(isGameSaveEnd)
			{
				if(isGameSaveError)
				{
					ChangeErrorToTilteStatus();
					updater = null;
					return;
				}
				ChangeGameStatus();
			}
		}

		// // RVA: 0xDCA294 Offset: 0xDCA294 VA: 0xDCA294
		private void BeginRhythmGame()
		{
			rhythmGameBeginedAction();
			updater = this.UpdateRhythmGame;
		}

		// // RVA: 0xDCA33C Offset: 0xDCA33C VA: 0xDCA33C
		private void UpdateRhythmGame()
		{
			if(gamePlayer.IsRhythmGamePlayerEnd())
			{
				updater = null;
				ChangeEndGameStatus();
			}
		}

		// // RVA: 0xDCA384 Offset: 0xDCA384 VA: 0xDCA384
		private void BeginCompleteAnim()
		{
			TodoLogger.Log(0, "BeginCompleteAnim");
			updater = null;
			ChangeNextSceneStatus(); // called in RhythmGameUIController$$BeginCompleteAnim
		}

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
