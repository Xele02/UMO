using System;
using System.Collections;
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
		//public static bool CanAutoSettingNavi() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AEDA8 Offset: 0x6AEDA8 VA: 0x6AEDA8
		//// RVA: 0xE49F64 Offset: 0xE49F64 VA: 0xE49F64
		public static IEnumerator Co_TutorialAutoUnitSetting(ButtonBase autoSettingButton, Func<bool> waitAutoSettingWindowFunc)
		{
			TodoLogger.LogError(0, "Co_TutorialAutoUnitSetting");
			yield return null;
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
		//public static IEnumerator Co_TutorialUnit5(ButtonBase unitInfoChangeButton) { }

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
					if(f != null && f.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.CADDNFIKDLG_3/*3*/)
						return true;
				}
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AEE98 Offset: 0x6AEE98 VA: 0x6AEE98
		//// RVA: 0xE4A4C0 Offset: 0xE4A4C0 VA: 0xE4A4C0
		public static IEnumerator Co_BeginnerMissionLiveClear(MusicSelectCDSelect cdSelect, MusicScrollView musicScrollView)
		{
			TodoLogger.LogError(0, "Co_BeginnerMissionLiveClear");
			yield return null;
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
			TodoLogger.LogError(0, "Co_CostumeUpgrade");
			yield return null;
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
			TodoLogger.LogError(0, "Co_ValkyrieUpgrade");
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
			TodoLogger.LogError(0, "Co_Decolture");
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
			TodoLogger.LogError(0, "Co_BeginnerMissionLiveClearMissionList");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF2D0 Offset: 0x6AF2D0 VA: 0x6AF2D0
		//// RVA: 0xE4AEB8 Offset: 0xE4AEB8 VA: 0xE4AEB8
		public static IEnumerator Co_MusicOpenMission()
		{
			TodoLogger.LogError(0, "Co_MusicOpenMission");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF348 Offset: 0x6AF348 VA: 0x6AF348
		//// RVA: 0xE4AF28 Offset: 0xE4AF28 VA: 0xE4AF28
		//public static IEnumerator Co_MusicOpenMissionPollingHideCursor() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF3C0 Offset: 0x6AF3C0 VA: 0x6AF3C0
		//// RVA: 0xE4AF98 Offset: 0xE4AF98 VA: 0xE4AF98
		public static IEnumerator Co_PlateGrowth(ActionButton button)
		{
			TodoLogger.LogError(0, "Co_PlateGrowth");
			yield return null;
		}

		//// RVA: 0xE4B020 Offset: 0xE4B020 VA: 0xE4B020
		public static bool CanDivaSelect(int missionId)
		{
			TodoLogger.LogError(0, "CanDivaSelect");
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AF438 Offset: 0x6AF438 VA: 0x6AF438
		//// RVA: 0xE4B22C Offset: 0xE4B22C VA: 0xE4B22C
		//public static IEnumerator Co_DivaSelect(StayButton button) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF4B0 Offset: 0x6AF4B0 VA: 0x6AF4B0
		//// RVA: 0xE4B2D8 Offset: 0xE4B2D8 VA: 0xE4B2D8
		//public static IEnumerator Co_DivaSelect(UGUIStayButton button) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF528 Offset: 0x6AF528 VA: 0x6AF528
		//// RVA: 0xE4B384 Offset: 0xE4B384 VA: 0xE4B384
		//private static IEnumerator Co_DivaSelectMain(ButtonBase button) { }

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
		//public static bool CanDivaSelectAfter(int missionId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF618 Offset: 0x6AF618 VA: 0x6AF618
		//// RVA: 0xE4B708 Offset: 0xE4B708 VA: 0xE4B708
		//public static IEnumerator Co_DivaSlectAfter() { }

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
			TodoLogger.LogError(0, "Tutorial Co_AssistSelect");
			yield break;
		}

		//// RVA: 0xE4BC54 Offset: 0xE4BC54 VA: 0xE4BC54
		//public static bool IsUnlockTutorialInRank() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AF708 Offset: 0x6AF708 VA: 0x6AF708
		//// RVA: 0xE4BEEC Offset: 0xE4BEEC VA: 0xE4BEEC
		//public static IEnumerator Co_GuideToHomePopup() { }
	}
}
