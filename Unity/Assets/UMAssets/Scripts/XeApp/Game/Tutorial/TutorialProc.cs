using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeApp.Game.MusicSelect;

namespace XeApp.Game.Tutorial
{
	public enum InputLimitButton
	{
		None = -1,
		CmnBack = 0,
		GachaList = 1,
		GachaBuy = 2,
		GachaReturn = 3,
		Setting = 4,
		UnitSetting = 5,
		MainScene = 6,
		Scene = 7,
		PopupPositiveButton = 8,
		SnsRoomButton = 9,
		VOP = 10,
		Mission = 11,
		LobbyTab = 12,
		LobbyScene = 13,
		Delegate = 14,
	}

	public class TutorialProc
	{
		public const int PlateGrowthBeginnerMissionId = 5;
		public const int BeginnerMissionMusicId = 4;
		private const int LiveClearBeginnerMissionId = 1;
		private const int BeginnerMissionDivaSelectMissionId = 4;
		private const int HavePlateCount = 3;

		//// RVA: 0xE49B54 Offset: 0xE49B54 VA: 0xE49B54
		public static bool CanAutoSettingHelp()
		{
			if (RuntimeSettings.CurrentSettings.ForceTutoSkip)
				return false;
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsAutoSetting))
			{
				if(QuestUtility.m_beginnerViewList.Count != 0)
				{
					if(!GameManager.Instance.IsTutorial)
					{
						FKMOKDCJFEN f = QuestUtility.m_beginnerViewList.Find((FKMOKDCJFEN x) =>
						{
							//0xE4BFFC
							return x.CMEJFJFOIIJ_QuestId == 1;
						});
						if(f != null)
						{
							return f.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ_1;
						}
					}
				}
			}
			return false;
		}

		//// RVA: 0xE49E78 Offset: 0xE49E78 VA: 0xE49E78
		public static bool CanAutoSettingNavi()
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.IGJAAIEAJPB_GetNumUnlockedScene() > 2;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AEDA8 Offset: 0x6AEDA8 VA: 0x6AEDA8
		//// RVA: 0xE49F64 Offset: 0xE49F64 VA: 0xE49F64
		public static IEnumerator Co_TutorialAutoUnitSetting(ButtonBase autoSettingButton, Func<bool> waitAutoSettingWindowFunc)
		{
			BasicTutorialManager mrg; // 0x1C
			BasicTutorialMessageId messageId; // 0x20
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x24

			//0x1914604
			bool isWait = true;
			if(!CanAutoSettingNavi())
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsAutoSetting, true);
				MenuScene.Instance.InputDisable();
				isWait = true;
				MenuScene.Save(() =>
				{
					//0xE4C4A4
					isWait = false;
				}, null);
				while(isWait)
					yield return null;
				MenuScene.Instance.InputEnable();
			}
			else
			{
				MenuScene.Instance.InputDisable();
				mrg = BasicTutorialManager.Instance;
				isWait = true;
				mrg.PreLoadResource(() =>
				{
					//0xE4C4B0
					isWait = false;
				}, true);
				while(isWait)
					yield return null;
				messageId = BasicTutorialMessageId.Id_UnitAutoSetting1;
				yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
				MenuScene.Instance.InputEnable();
				dymmyBackHandler = () =>
				{
					//0xE4C028
					return;
				};
				GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
				isWait = true;
				mrg.ShowMessageWindow(messageId, () =>
				{
					//0xE4C4BC
					isWait = false;
				}, null);
				while(isWait)
					yield return null;
				ILLPDLODANB.IHKAKFFAGPC(ILLPDLODANB.LOEGALDKHPL.AFLMHBMBNBO_48);
				isWait = true;
				mrg.SetInputLimit(InputLimitButton.Delegate, () =>
				{
					//0xE4C4C8
					isWait = false;
				}, () =>
				{
					//0xE4C4D4
					return autoSettingButton;
				}, TutorialPointer.Direction.UP);
				while(isWait)
					yield return null;
				if(waitAutoSettingWindowFunc != null)
				{
					while(!waitAutoSettingWindowFunc())
						yield return null;
				}
				isWait = true;
				mrg.SetInputLimit(InputLimitButton.PopupPositiveButton, () =>
				{
					//0xE4C4DC
					isWait = false;
				}, null, TutorialPointer.Direction.Down);
				while(isWait)
					yield return null;
				messageId = BasicTutorialMessageId.Id_UnitAutoSetting2;
				isWait = true;
				mrg.ShowMessageWindow(messageId, () =>
				{
					//0xE4C4E8
					isWait = false;
				}, null);
				while(isWait)
					yield return null;
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsAutoSetting, true);
				ILLPDLODANB.ILOGJDALEOO();
				MenuScene.Instance.InputDisable();
				isWait = true;
				MenuScene.Save(() =>
				{
					//0xE4C4F4
					isWait = false;
				}, null);
				while(isWait)
					yield return null;
				MenuScene.Instance.InputEnable();
				GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
			}
		}

		//// RVA: 0xE4A008 Offset: 0xE4A008 VA: 0xE4A008
		public static bool CanUnit5Help(GameSetupData.MusicInfo musicInfo)
		{
			if (RuntimeSettings.CurrentSettings.ForceTutoSkip)
				return false;
			if (musicInfo == null || CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsUnit5Help) || musicInfo.onStageDivaNum < 4)
				return false;
			return !GameManager.Instance.IsTutorial;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AEE20 Offset: 0x6AEE20 VA: 0x6AEE20
		//// RVA: 0xE4A170 Offset: 0xE4A170 VA: 0xE4A170
		public static IEnumerator Co_TutorialUnit5(ButtonBase unitInfoChangeButton)
		{
			BasicTutorialManager mrg; // 0x18
			BasicTutorialMessageId messageId; // 0x1C
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x20

			//0x191536C
			bool isWait = true;
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			mrg = BasicTutorialManager.Instance;
			isWait = true;
			mrg.PreLoadResource(() =>
			{
				//0xE4C508
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			messageId = BasicTutorialMessageId.Id_Unit5Help1;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C02C
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C514
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			isWait = true;
			mrg.SetInputLimit(InputLimitButton.Delegate, () =>
			{
				//0xE4C520
				isWait = false;
			}, () =>
			{
				//0xE4C52C
				return unitInfoChangeButton;
			}, TutorialPointer.Direction.UP);
			while(isWait)
				yield return null;
			isWait = true;
			messageId = BasicTutorialMessageId.Id_Unit5Help2;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C534
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsUnit5Help, true);
			MenuScene.Instance.InputEnable();
			isWait = true;
			MenuScene.Save(() =>
			{
				//0xE4C540
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			MenuScene.Instance.InputEnable();
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//// RVA: 0xE4A1F8 Offset: 0xE4A1F8 VA: 0xE4A1F8
		public static bool CanBeginnerMissionLiveClearLiveHelp()
		{
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsBeginnerLiveMission))
			{
				if(QuestUtility.m_beginnerViewList.Count != 0)
				{
					FKMOKDCJFEN f = QuestUtility.m_beginnerViewList.Find((FKMOKDCJFEN x) => {
						//0xE4C030
						return x.CMEJFJFOIIJ_QuestId == 1;
					});
					if(f != null && f.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved)
						return true;
				}
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AEE98 Offset: 0x6AEE98 VA: 0x6AEE98
		//// RVA: 0xE4A4C0 Offset: 0xE4A4C0 VA: 0xE4A4C0
		public static IEnumerator Co_BeginnerMissionLiveClear(MusicSelectCDSelect cdSelect, MusicScrollView musicScrollView)
		{
			BasicTutorialManager mrg; // 0x1C
			BasicTutorialMessageId messageId; // 0x20
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x24

			//0xE4CD74
			MenuScene.Instance.InputDisable();
			mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			mrg.PreLoadResource(() =>
			{
				//0xE4C0F8
				isWait = false;
			}, false);
			while(isWait)
				yield return null;
			messageId = BasicTutorialMessageId.Id_LiveClear1;
			yield return mrg.PreDownLoadTextureResource(messageId);
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C05C
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			if(cdSelect != null)
			{
				cdSelect.ScrollDisable();
			}
			if(musicScrollView != null)
			{
				musicScrollView.ScrollEnable(false);
			}
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C104
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			isWait = true;
			mrg.SetInputLimit(InputLimitButton.Mission, () =>
			{
				//0xE4C110
				isWait = false;
			}, null, TutorialPointer.Direction.Down);
			while(isWait)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AEF10 Offset: 0x6AEF10 VA: 0x6AEF10
		//// RVA: 0xE4A588 Offset: 0xE4A588 VA: 0xE4A588
		public static IEnumerator Co_OffeReleaseTutorial(InputLimitButton inputLimitButton, ButtonBase button, Action act, BasicTutorialMessageId messageId, bool IsInputLimit = true, MusicSelectCDSelect cdSelect = null, MusicScrollView musicScrollView = null)
		{
			BasicTutorialManager mrg;
			GameManager.PushBackButtonHandler dymmyBackHandler;

			//0x19121B0
			MenuScene.Instance.RaycastDisable();
			BasicTutorialManager.Initialize();
			mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			mrg.PreLoadResource(() => {
				//0xE4C124
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			yield return mrg.PreDownLoadTextureResource(messageId);
			MenuScene.Instance.RaycastEnable();
			dymmyBackHandler = () => {
				//0xE4C060
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			if(cdSelect != null)
				cdSelect.ScrollDisable();
			if(musicScrollView != null)
				musicScrollView.ScrollEnable(false);
			isWait = true;
			mrg.ShowMessageWindow(messageId, () => {
				//0xE4C130
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			if(!IsInputLimit)
			{
				act();
				isWait = false;
			}
			else
			{
				isWait = true;
				mrg.SetInputLimit(inputLimitButton, () => {
					//0xE4C13C
					act();
					isWait = false;
				}, () => {
					//0xE4C174
					return button;
				}, TutorialPointer.Direction.Down);
			}
			while(isWait)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AEF88 Offset: 0x6AEF88 VA: 0x6AEF88
		//// RVA: 0xE4A6AC Offset: 0xE4A6AC VA: 0xE4A6AC
		public static IEnumerator Co_CostumeUpgrade(EBFLJMOCLNA_Costume.NDOPBOCEPJO type, ButtonBase button, BasicTutorialMessageId messageId, InputLimitButton limitButton = InputLimitButton.None, TutorialPointer.Direction direction = TutorialPointer.Direction.Normal)
		{
			if (RuntimeSettings.CurrentSettings.ForceTutoSkip)
				yield break;
			EBFLJMOCLNA_Costume pd; // 0x28
			BasicTutorialManager mrg; // 0x2C
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x30

			//0xE4DC20
			pd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume;
			if(pd.MLBBKNLPBBD_IsTutoDone((int)type))
				yield break;
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			mrg.PreLoadResource(() =>
			{
				//0xE4C184
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C064
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C190
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			if(button != null)
			{
				isWait = true;
				mrg.SetInputLimit(limitButton, () =>
				{
					//0xE4C19C
					isWait = false;
				}, () =>
				{
					//0xE4C1A8
					return button;
				}, direction);
				while(isWait)
					yield return null;
			}
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
			pd.ILMPHFPFLJE_SetTutoStatus((int)type, true);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF000 Offset: 0x6AF000 VA: 0x6AF000
		//// RVA: 0xE4A7C4 Offset: 0xE4A7C4 VA: 0xE4A7C4
		public static IEnumerator Co_ValkyrieUpgrade(ButtonBase button, BasicTutorialMessageId messageId, InputLimitButton limitButton = InputLimitButton.None, TutorialPointer.Direction direction = TutorialPointer.Direction.Normal, MusicSelectCDSelect cdSelect = null, MusicScrollView musicScrollView = null)
		{
			BasicTutorialManager mrg;
			GameManager.PushBackButtonHandler dymmyBackHandler;

			//0x1915D2C
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsValkyrieUpgrade))
				yield break;
			if(RuntimeSettings.CurrentSettings.ForceTutoSkip)
				yield break;
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			mrg.PreLoadResource(() =>
			{
				//0xE4C1B8
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C068
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			if(cdSelect != null)
			{
				cdSelect.ScrollDisable();
			}
			if(musicScrollView != null)
			{
				musicScrollView.ScrollEnable(false);
			}
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C1C4
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			if(button != null)
			{
				isWait = true;
				BasicTutorialManager.Instance.SetInputLimit(limitButton, () =>
				{
					//0xE4C1D0
					isWait = false;
				}, () =>
				{
					//0xE4C1DC
					return button;
				}, direction);
				while(isWait)
					yield return null;
			}
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF078 Offset: 0x6AF078 VA: 0x6AF078
		//// RVA: 0xE4A8D0 Offset: 0xE4A8D0 VA: 0xE4A8D0
		//public static IEnumerator Co_McrsLobby(HomeLobbyButtonController lobbyCtrl, Action proc) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF0F0 Offset: 0x6AF0F0 VA: 0x6AF0F0
		//// RVA: 0xE4A974 Offset: 0xE4A974 VA: 0xE4A974
		//public static IEnumerator Co_RaidFromMcrsLobby(ButtonBase button) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF168 Offset: 0x6AF168 VA: 0x6AF168
		//// RVA: 0xE4A9FC Offset: 0xE4A9FC VA: 0xE4A9FC
		public static IEnumerator Co_Decolture(ButtonBase button, Action proc)
		{
			BasicTutorialManager mrg; // 0x1C
			BasicTutorialMessageId messageId; // 0x20
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x24

			//0xE4E414
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsDecolture))
				yield break;
			if(proc != null)
				proc();
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			mrg.PreLoadResource(() =>
			{
				//0xE4C258
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			messageId = BasicTutorialMessageId.Id_Decolture;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C074
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C264
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			if(button != null)
			{
				isWait = true;
				mrg.SetInputLimit(InputLimitButton.Delegate, () =>
				{
					//0xE4C270
					isWait = false;
				}, () =>
				{
					//0xE4C27C
					return button;
				}, TutorialPointer.Direction.UP);
				while(isWait)
					yield return null;
			}
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF1E0 Offset: 0x6AF1E0 VA: 0x6AF1E0
		//// RVA: 0xE4AAC4 Offset: 0xE4AAC4 VA: 0xE4AAC4
		//public static IEnumerator Co_RaidUseFoldRadar(ButtonBase button, Func<bool> waitPopupWindowFunc, IEnumerator popupItemGetColoutine, Func<int> waitRaidBossEncountFunc) { }

		//// RVA: 0xE4AB98 Offset: 0xE4AB98 VA: 0xE4AB98
		public static bool CanBeginnerMissionLiveClearMissionList(TransitionList.Type prevType)
		{
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsBeginnerLiveMission))
			{
				if (prevType < TransitionList.Type.EPISODE_SELECT)
				{
					if (prevType != TransitionList.Type.HOME && prevType != TransitionList.Type.MUSIC_SELECT && prevType != TransitionList.Type.EVENT_MUSIC_SELECT)
						return false;

				}
				else if (prevType != TransitionList.Type.EVENT_QUEST && prevType != TransitionList.Type.EVENT_GODIVA && prevType != TransitionList.Type.EVENT_BATTLE)
					return false;
				FKMOKDCJFEN f = QuestUtility.m_beginnerViewList.Find((FKMOKDCJFEN x) =>
				{
					//0xE4C07C
					return x.CMEJFJFOIIJ_QuestId == 1;
				});
				if (f != null && f.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved)
					return true;
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF258 Offset: 0x6AF258 VA: 0x6AF258
		//// RVA: 0xE4AE24 Offset: 0xE4AE24 VA: 0xE4AE24
		public static IEnumerator Co_BeginnerMissionLiveClearMissionList()
		{
			BasicTutorialManager mrg; // 0x14
			BasicTutorialMessageId messageId; // 0x18
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x1C

			//0xE4D4AC
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			mrg.PreLoadResource(() =>
			{
				//0xE4C2D8
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			messageId = BasicTutorialMessageId.Id_LiveClear2;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C0A8
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C2E4
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsBeginnerLiveMission, true);
			MenuScene.Instance.InputDisable();
			isWait = true;
			MenuScene.Save(() =>
			{
				//0xE4C2F0
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			MenuScene.Instance.InputEnable();
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF2D0 Offset: 0x6AF2D0 VA: 0x6AF2D0
		//// RVA: 0xE4AEB8 Offset: 0xE4AEB8 VA: 0xE4AEB8
		public static IEnumerator Co_MusicOpenMission()
		{
			BasicTutorialManager mrg; // 0x14
			BasicTutorialMessageId messageId; // 0x18
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x1C

			//0x19118E8
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			mrg.PreLoadResource(() =>
			{
				//0xE4C304
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			messageId = BasicTutorialMessageId.Id_MusicOpen;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C0AC
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C310
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			mrg.ShowCursor(CursorPosition.MissionMenuButton);
			MenuScene.Instance.InputDisable();
			yield return new WaitForSeconds(0.5f);
			MenuScene.Instance.InputEnable();
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF348 Offset: 0x6AF348 VA: 0x6AF348
		//// RVA: 0xE4AF28 Offset: 0xE4AF28 VA: 0xE4AF28
		//public static IEnumerator Co_MusicOpenMissionPollingHideCursor() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF3C0 Offset: 0x6AF3C0 VA: 0x6AF3C0
		//// RVA: 0xE4AF98 Offset: 0xE4AF98 VA: 0xE4AF98
		public static IEnumerator Co_PlateGrowth(ActionButton button)
		{
			BasicTutorialManager mrg; // 0x18
			BasicTutorialMessageId messageId; // 0x1C
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x20

			//0x19129E0
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			mrg.PreLoadResource(() =>
			{
				//0xE4C324
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			messageId = BasicTutorialMessageId.Id_SceneGrowth;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C0B0
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C330
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			isWait = true;
			mrg.SetInputLimit(InputLimitButton.Delegate, () =>
			{
				//0xE4C33C
				isWait = false;
			}, () =>
			{
				//0xE4C348
				return button;
			}, TutorialPointer.Direction.Normal);
			while(isWait)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//// RVA: 0xE4B020 Offset: 0xE4B020 VA: 0xE4B020
		public static bool CanDivaSelect(int missionId)
		{
			if(missionId > 0)
			{
				if(QuestUtility.m_beginnerViewList.Count != 0)
				{
					if(missionId == 4)
					{
						FKMOKDCJFEN q = QuestUtility.m_beginnerViewList.Find((FKMOKDCJFEN x) =>
						{
							//0xE4C350
							return x.CMEJFJFOIIJ_QuestId == missionId;
						});
						if(q != null && q.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ_1)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF438 Offset: 0x6AF438 VA: 0x6AF438
		//// RVA: 0xE4B22C Offset: 0xE4B22C VA: 0xE4B22C
		//public static IEnumerator Co_DivaSelect(StayButton button) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF4B0 Offset: 0x6AF4B0 VA: 0x6AF4B0
		//// RVA: 0xE4B2D8 Offset: 0xE4B2D8 VA: 0xE4B2D8
		public static IEnumerator Co_DivaSelect(UGUIStayButton button)
		{
			//0xE4ECF4
			button.ClearOnStayCallback();
			yield return Co.R(Co_DivaSelectMain(button));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF528 Offset: 0x6AF528 VA: 0x6AF528
		//// RVA: 0xE4B384 Offset: 0xE4B384 VA: 0xE4B384
		private static IEnumerator Co_DivaSelectMain(ButtonBase button)
		{
			BasicTutorialManager mrg; // 0x18
			BasicTutorialMessageId messageId; // 0x1C
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x20

			//0xE4F520
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			mrg.PreLoadResource(() =>
			{
				//0xE4C390
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			messageId = BasicTutorialMessageId.Id_DivaSelect1;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C0B4
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C39C
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			isWait = true;
			mrg.SetInputLimit(InputLimitButton.Delegate, () =>
			{
				//0xE4C3A8
				isWait = false;
			}, () =>
			{
				//0xE4C3B4
				return button;
			}, TutorialPointer.Direction.Normal);
			while(isWait)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF5A0 Offset: 0x6AF5A0 VA: 0x6AF5A0
		//// RVA: 0xE4B430 Offset: 0xE4B430 VA: 0xE4B430
		public static IEnumerator Co_DivaSelectList(StayButton button, Func<bool> waitFunc)
		{
			if (RuntimeSettings.CurrentSettings.ForceTutoSkip)
				yield break;
			GameManager.PushBackButtonHandler dymmyBackHandler;
			//0xE4EE00
			button.ClearOnStayCallback();
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			bool isWait = true;
			BasicTutorialManager.Instance.PreLoadResource(() =>
			{
				//0xE4C3C4
				isWait = false;
			}, true);
			while (isWait)
				yield return null;
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C0B8
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			isWait = true;
			BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.Delegate, () =>
			{
				//0xE4C3D0
				isWait = false;
			}, () =>
			{
				//0xE4C3DC
				return button;
			}, TutorialPointer.Direction.Normal);
			while (isWait)
				yield return null;
			if (waitFunc != null)
			{
				while (!waitFunc())
					yield return null;
			}
			isWait = true;
			BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.PopupPositiveButton, () =>
			{
				//0xE4C3E4
				isWait = false;
			}, null, TutorialPointer.Direction.Down);
			while (isWait)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//// RVA: 0xE4B4F8 Offset: 0xE4B4F8 VA: 0xE4B4F8
		public static bool CanDivaSelectAfter(int missionId)
		{
			if(missionId > 0)
			{
				if(QuestUtility.m_beginnerViewList.Count != 0)
				{
					if(missionId == 4)
					{
						FKMOKDCJFEN q = QuestUtility.m_beginnerViewList.Find((FKMOKDCJFEN x) =>
						{
							//0xE4C3F0
							return x.CMEJFJFOIIJ_QuestId == missionId;
						});
						if(q != null && q.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF618 Offset: 0x6AF618 VA: 0x6AF618
		//// RVA: 0xE4B708 Offset: 0xE4B708 VA: 0xE4B708
		public static IEnumerator Co_DivaSlectAfter()
		{
			BasicTutorialManager mrg; // 0x14
			BasicTutorialMessageId messageId; // 0x18
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x1C

			//0xE4FBE0
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			bool isWait = true;
			mrg = BasicTutorialManager.Instance;
			mrg.PreLoadResource(() =>
			{
				//0xE4C430
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			messageId = BasicTutorialMessageId.Id_DivaSelect2;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C0BC
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C43C
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			if(!TutorialManager.IsAlreadyTutorial(TutorialConditionId.Condition30))
			{
				yield return Co.R(TutorialManager.ShowTutorial(30, null));
			}
			//LAB_00e50054
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
		}

		//// RVA: 0xE4B79C Offset: 0xE4B79C VA: 0xE4B79C
		public static bool CanBeginnerAssistSelect()
		{
			if (RuntimeSettings.CurrentSettings.ForceTutoSkip)
				return false;
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsSelectAssist))
			{
				if (!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsAutoSetting))
				{
					return true;
				}
				if(QuestUtility.m_beginnerViewList.Count != 0)
				{
					FKMOKDCJFEN f = QuestUtility.m_beginnerViewList.Find((FKMOKDCJFEN x) =>
					{
						//0xE4C0C0
						return x.CMEJFJFOIIJ_QuestId == 1;
					});
					if (f != null)
					{
						if(f.CMCKNKKCNDK_Status != FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ_1)
							return false;
						return true;
					}
				}
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF690 Offset: 0x6AF690 VA: 0x6AF690
		//// RVA: 0xE4BBA8 Offset: 0xE4BBA8 VA: 0xE4BBA8
		public static IEnumerator Co_AssistSelect(ActionButton button)
		{
			BasicTutorialManager mrg; // 0x18
			BasicTutorialMessageId messageId; // 0x1C
			GameManager.PushBackButtonHandler dymmyBackHandler; // 0x20

			//0xE4C550
			MenuScene.Instance.InputDisable();
			BasicTutorialManager.Initialize();
			mrg = BasicTutorialManager.Instance;
			bool isWait = true;
			mrg.PreLoadResource(() =>
			{
				//0xE4C450
				isWait = false;
			}, true);
			while(isWait)
				yield return null;
			messageId = BasicTutorialMessageId.Id_AssistSelect;
			yield return Co.R(mrg.PreDownLoadTextureResource(messageId));
			MenuScene.Instance.InputEnable();
			dymmyBackHandler = () =>
			{
				//0xE4C0EC
				return;
			};
			GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
			isWait = true;
			mrg.ShowMessageWindow(messageId, () =>
			{
				//0xE4C45C
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
			isWait = true;
			mrg.SetInputLimit(InputLimitButton.Delegate, () =>
			{
				//0xE4C468
				isWait = false;
			}, () =>
			{
				//0xE4C474
				return button;
			}, TutorialPointer.Direction.Normal);
			while(isWait)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsSelectAssist, true);
			isWait = true;
			MenuScene.Save(() =>
			{
				//0xE4C47C
				isWait = false;
			}, null);
			while(isWait)
				yield return null;
		}

		//// RVA: 0xE4BC54 Offset: 0xE4BC54 VA: 0xE4BC54
		//public static bool IsUnlockTutorialInRank() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF708 Offset: 0x6AF708 VA: 0x6AF708
		//// RVA: 0xE4BEEC Offset: 0xE4BEEC VA: 0xE4BEEC
		//public static IEnumerator Co_GuideToHomePopup() { }
	}
}
