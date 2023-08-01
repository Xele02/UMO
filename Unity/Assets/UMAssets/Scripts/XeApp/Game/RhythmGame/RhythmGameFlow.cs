using System;
using System.Collections.Generic;
using XeApp.Game.Common;
using static XeApp.Game.Common.GameSetupData;

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
			TodoLogger.LogError(0, "ChangeErrorToTilteStatus");
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
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
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
						teamInfo.danceDivaList[i].SetPositionId(basaraPos);
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
								teamInfo.danceDivaList[i].SetPositionId(freePos);
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
				wavId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(musicInfo.storyMusicId).KEFGPJBKAOD_WavId;
			}
			PNGOLKLFFLH p = new PNGOLKLFFLH();
			p.KHEKNNFCAOI_Init(teamInfo.prismValkyrieId, 0, 0);

			List<MusicDirectionParamBase.ConditionSetting> settingList = new List<MusicDirectionParamBase.ConditionSetting>();
			MusicDirectionParamBase.ConditionSetting cond = new MusicDirectionParamBase.ConditionSetting(teamInfo.danceDivaList[0].prismDivaId, teamInfo.danceDivaList[0].prismCostumeModelId, teamInfo.prismValkyrieId, p.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId, teamInfo.danceDivaList[0].positionId);
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
						cond = new MusicDirectionParamBase.ConditionSetting(teamInfo.danceDivaList[i + 1].prismDivaId, teamInfo.danceDivaList[i + 1].prismCostumeModelId, teamInfo.prismValkyrieId, p.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId, teamInfo.danceDivaList[i + 1].positionId);
						settingList.Add(cond);
					}
				}
				else
				{
					rhythmGameResource.subDivaResource[i] = null;
				}
			}
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				rhythmGameResource.LoadSpecialDirectionResource(DbMusicInfo.KKPAHLMJKIH_WavId, stageDivaNum, settingList);
			}
			else
			{
				rhythmGameResource.LoadSpecialResourceFor2DMode(DbMusicInfo.KKPAHLMJKIH_WavId, stageDivaNum, settingList);
			}
			ChangeWaitLoadingSpecialResourceStatus();
		}

		// // RVA: 0xDC80E4 Offset: 0xDC80E4 VA: 0xDC80E4
		private void WaitLoadingSpecialResource()
		{
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
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
			TeamInfo team = Database.Instance.gameSetup.teamInfo;
			MusicInfo music = Database.Instance.gameSetup.musicInfo;
			int forceDivaVoice = Database.Instance.gameSetup.ForceDivaVoice();
			int forcePilotVoice = Database.Instance.gameSetup.ForcePilotVoice();
			int divaNum = music.onStageDivaNum;
			int musicId = music.prismMusicId;
			EONOEHOKBEB_Music musicInfoDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(musicId);
			int wavId = musicInfoDb.KKPAHLMJKIH_WavId;
			BJPLLEBHAGO_DivaInfo divaInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId);
			List<int> prime = new List<int>();
			for (int i = 0; i < Database.Instance.gameSetup.musicInfo.onStageDivaNum; i++)
			{
				prime.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(Database.Instance.gameSetup.teamInfo.danceDivaList[i].prismDivaId).IDDHKOEFJFB_BodyId);
			}
			int stageId = 0;
			if (music.isFreeMode)
			{
				stageId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(Database.Instance.gameSetup.musicInfo.freeMusicId).KEFGPJBKAOD_WavId;
			}
			else
			{
				stageId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(Database.Instance.gameSetup.musicInfo.storyMusicId).KEFGPJBKAOD_WavId;
			}

			PNGOLKLFFLH p = new PNGOLKLFFLH();
			p.KHEKNNFCAOI_Init(team.prismValkyrieId, 0, 0);
			int pilotId = p.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId;
			int intro = musicInfoDb.EECJONKNHNK_ValkyrieIntro;
			int introSky = musicInfoDb.MNEFKDDCEHE_ValkyrieIntroSky;
			int battle = musicInfoDb.DMKCGNMOCCH_ValkyrieBattle;

			isBgmSoundLoaded = false;
			gamePlayer.bgmPlayer.RequestChangeCueSheet(wavId, () =>
			{
				isBgmSoundLoaded = true;
			});
			isGameSESoundLoaded = false;
			SoundManager.Instance.RequestEntryRhythmGameCueSheet(() =>
			{
				isGameSESoundLoaded = true;
			}, Database.Instance.gameSetup.ForceNoteSe());
			isDivaSoundLoaded = false;
			if (forceDivaVoice < 1)
			{
				SoundManager.Instance.voDiva.RequestChangeCueSheet(Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId, () =>
				{
					isDivaSoundLoaded = true;
				});
			}
			else
			{
				SoundManager.Instance.voDiva.RequestChangeCueSheetForReplacement(forceDivaVoice, () =>
				{
					isDivaSoundLoaded = true;
				});
			}
			IsRareBreak = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.GOFAPKBNNCL_HasRareSceneWithCostumeForDivaUnlocked(Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId);
			if(IsRareBreak)
			{
				isDivaCosSoundLoaded = false;
				SoundManager.Instance.voDivaCos.RequestChangeCueSheetSole(Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId, () =>
				{
					isDivaCosSoundLoaded = true;
				});
			}
			isPilotSoundLoaded = false;
			if(forcePilotVoice < 1)
			{
				SoundManager.Instance.voPilot.RequestChangeCueSheet(pilotId, () =>
				{
					isPilotSoundLoaded = true;
				});
			}
			else
			{
				SoundManager.Instance.voPilot.RequestChangeCueSheetForReplacement(forcePilotVoice, () =>
				{
					isPilotSoundLoaded = true;
				});
			}
			SoundManager.Instance.sePlayerCheer.RequestChangeCueSheet();
			int enemyId = music.enemyInfo.EJNIMIAPJFJ_Id;
			if(rhythmGameResource.paramResource.m_paramEnemy.Check(Database.Instance.gameSetup, ref enemyId))
			{
				int prevLS = music.enemyInfo.EDLACELKJIK_LiveSkill;
				int prevCS = music.enemyInfo.NJOPIPNGANO_CS;
				music.enemyInfo.ODDIHGPONFL_Copy(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OPFBEAJJMJB_Enemy.CKADCLJDCJK_EnemyList[enemyId - 1]);
				music.enemyInfo.EDLACELKJIK_LiveSkill = prevLS;
				music.enemyInfo.NJOPIPNGANO_CS = prevCS;
			}
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				rhythmGameResource.paramResource.m_paramIntro.Check(Database.Instance.gameSetup, ref intro, ref introSky);
				rhythmGameResource.paramResource.m_paramBattle.Check(Database.Instance.gameSetup, ref battle);
				rhythmGameResource.LoadUITextureResouces();
				rhythmGameResource.divaResource.LoadBasicResource(Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId,
																	Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismCostumeModelId,
																	Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismCostumeColorId);
				rhythmGameResource.divaResource.LoadFacialResource(Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId, wavId,
																		Database.Instance.gameSetup.musicInfo.onStageDivaNum);
				rhythmGameResource.divaResource.LoadMusicAnimationResource(wavId, GameManager.Instance.GetMultipleDanceOverridePrimeId(prime),
																		Database.Instance.gameSetup.teamInfo.danceDivaList[0].positionId,
																		Database.Instance.gameSetup.musicInfo.onStageDivaNum,
																		Database.Instance.gameSetup.teamInfo.danceDivaList[0].prismDivaId);
				rhythmGameResource.cameraResource.LoadResource(wavId, GameManager.Instance.GetMultipleDanceOverridePrimeId(prime), Database.Instance.gameSetup.musicInfo.onStageDivaNum);
				rhythmGameResource.stageResources.LoadResouces(stageId, rhythmGameResource.GetSpecialStageResourceId);
				rhythmGameResource.valkyrieResource.LoadResources(Database.Instance.gameSetup.teamInfo.prismValkyrieId, introSky, battle);
				rhythmGameResource.musicIntroResource.LoadResources(intro, introSky, Database.Instance.gameSetup.teamInfo.prismValkyrieId);
				rhythmGameResource.valkyrieModeResource.LoadResources(battle, Database.Instance.gameSetup.teamInfo.prismValkyrieId);
				rhythmGameResource.musicBoneSpringResource[0].LoadMusicResouces(wavId, GameManager.Instance.GetMultipleDanceOverridePrimeId(prime),
												Database.Instance.gameSetup.musicInfo.onStageDivaNum, Database.Instance.gameSetup.musicInfo.onStageDivaNum > 1 ? Database.Instance.gameSetup.teamInfo.danceDivaList[0].positionId : 0);
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GPKILPOLNKO())
				{
					rhythmGameResource.divaModeResource.LoadResources(wavId, GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CBLEFELBNDN_GetVideoQuality(), rhythmGameResource.GetSpecialDirectionMovieId);
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
				rhythmGameResource.LoadAllResourceFor2DMode(introSky, battle);
			}
			ChangeWaitLoadingDataStatus();
		}

		// // RVA: 0xDC9D94 Offset: 0xDC9D94 VA: 0xDC9D94
		private void WaitLoadingData()
		{
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CIGAPPFDFKL_Is3D)
			{
				if (!rhythmGameResource.is3DModeAllResoucesLoaded)
					return;
			}
			else
			{
				if (!rhythmGameResource.is2DModeAllResoucesLoaded)
					return;
			}
			if (isBgmSoundLoaded && isGameSESoundLoaded && isDivaSoundLoaded && (!IsRareBreak || isDivaCosSoundLoaded) && isPilotSoundLoaded
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
			if(uiController.Hud.IsWarmupEnd())
			{
				GameSaveStart();
			}
		}

		// // RVA: 0xDCA0E4 Offset: 0xDCA0E4 VA: 0xDCA0E4
		private void GameSaveStart()
		{
			isGameSaveEnd = false;
			isGameSaveError = false;
			JGEOBNENMAH.HHCJCDFCLOB.CNNNAAACEHE_GameStartSave(false, () =>
			{
				//0xDCA510
				isGameSaveEnd = true;
			}, () =>
			{
				//0xDCA51C
				isGameSaveEnd = true;
				isGameSaveError = true;
			});
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
			uiController.BeginCompleteAnim(this.ChangeNextSceneStatus, gamePlayer.CalcComboRank(), gamePlayer.setting_mv.m_enable);
			updater = null;
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
	}
}
