using System;
using System.Collections;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LiveBeforeSceneBaseUnit5 : TransitionRoot
	{
		private struct PrefabCacheParam
		{
			public string prefabName; // 0x0
			public int count; // 0x4

			// RVA: 0x7FCACC Offset: 0x7FCACC VA: 0x7FCACC
			//public void .ctor(string prefabName, int count) { }
		}

		protected bool m_isGotoGame; // 0x45
		private static readonly LiveBeforeSceneBaseUnit5.PrefabCacheParam[] m_prefabCacheParams = new LiveBeforeSceneBaseUnit5.PrefabCacheParam[15] {
			new PrefabCacheParam() { prefabName="SetDeckHeadButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitStatus", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckValkyrieButton", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitInfoChangeButton", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitInfo_Select", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckMusicInfo", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckPlayButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitSetListButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitSetCloseButton", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitSetSelectButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitInfo_Edit", count=2 },
			new PrefabCacheParam() { prefabName="SetDeckLoadSaveButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckPrismSettingButtons", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckUnitInfo_SLive", count=1 },
			new PrefabCacheParam() { prefabName="SetDeckStatusWindow", count=1 }
		}; // 0x0
		protected AOJGDNFAIJL_PrismData.AMIECPBIALP m_prismData = new AOJGDNFAIJL_PrismData.AMIECPBIALP(); // 0x48
		// private AOJGDNFAIJL.AMIECPBIALP m_prismLogDiffData = new AOJGDNFAIJL.AMIECPBIALP(); // 0x4C
		private PopupMvModeSelectListSetting m_prismPopupSetting = new PopupMvModeSelectListSetting(); // 0x50
		// private List<int> m_lackDivaIds = new List<int>(); // 0x54
		// private AOJGDNFAIJL.AMIECPBIALP m_prismOriginalData = new AOJGDNFAIJL.AMIECPBIALP(); // 0x58
		// private TextPopupSetting m_textSetPrizmPopup = new TextPopupSetting(); // 0x5C
		// private PopupMvModeLackDivaSetting m_lackDivaSetting = new PopupMvModeLackDivaSetting(); // 0x60

		protected DFKGGBMFFGB_PlayerInfo m_playerData { get { return GameManager.Instance.ViewPlayerData; } } //0x1547368

		// [IteratorStateMachineAttribute] // RVA: 0x72E4B4 Offset: 0x72E4B4 VA: 0x72E4B4
		// // RVA: 0x1547404 Offset: 0x1547404 VA: 0x1547404
		protected IEnumerator CreateUGUIObjectCache()
		{
			//0x154B8E8
			yield return AssetBundleManager.LoadUnionAssetBundle("ly/013.xab");
			int loadCount = 0;
			int reqCount = 0;
			for(int i = 0; i < m_prefabCacheParams.Length; i++)
			{
				if(!GameManager.Instance.LayoutObjectCache.IsLoadedObject(m_prefabCacheParams[i].prefabName))
				{
					this.StartCoroutineWatched(GameManager.Instance.LayoutObjectCache.CreateUGUI("ly/013.xab", m_prefabCacheParams[i].prefabName, null, m_prefabCacheParams[i].count, () =>
					{
						//0x154A604
						loadCount++;
					}));
					reqCount++;
				}
			}
			while (loadCount < reqCount)
				yield return null;
			AssetBundleManager.UnloadAssetBundle("ly/013.xab", false);
		}

		// // RVA: 0x15474B0 Offset: 0x15474B0 VA: 0x15474B0 Slot: 15
		protected override void OnDeleteCache()
		{
			if (!IsDifferHomeDivaModel(m_playerData.DPLBHAIKPGL_GetTeam(false), Database.Instance.gameSetup.teamInfo, m_isGotoGame))
			{
				return;
			}
			MenuScene.Instance.divaManager.Release(true);
		}

		// // RVA: 0x154760C Offset: 0x154760C VA: 0x154760C
		protected bool IsDifferHomeDivaModel(JLKEOGLJNOD_TeamInfo unitData, GameSetupData.TeamInfo teamInfo, bool isGotoGame)
		{
			if(!isGotoGame)
			{
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId == 0)
				{
					if(unitData.BCJEAJPLGMB_MainDivas[0] != null)
					{
						if (unitData.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId != MenuScene.Instance.divaManager.DivaId)
							return true;
						if (unitData.BCJEAJPLGMB_MainDivas[0].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId != MenuScene.Instance.divaManager.ModelId)
							return true;
						return unitData.BCJEAJPLGMB_MainDivas[0].EKFONBFDAAP_ColorId != MenuScene.Instance.divaManager.ColorId;
					}
				}
				else
				{
					for(int i = 0; i < unitData.BCJEAJPLGMB_MainDivas.Count; i++)
					{
						if (unitData.BCJEAJPLGMB_MainDivas[i] != null)
						{
							if (unitData.BCJEAJPLGMB_MainDivas[i].AHHJLDLAPAN_DivaId == MenuScene.Instance.divaManager.DivaId)
							{
								if (unitData.BCJEAJPLGMB_MainDivas[i].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId != MenuScene.Instance.divaManager.ModelId)
									return true;
								if (unitData.BCJEAJPLGMB_MainDivas[0].EKFONBFDAAP_ColorId != MenuScene.Instance.divaManager.ColorId)
									return true;
							}
						}
					}
				}
				return false;
			}
			if (teamInfo.divaList[0].prismDivaId != MenuScene.Instance.divaManager.DivaId)
				return true;
			if (teamInfo.divaList[0].prismCostumeModelId != MenuScene.Instance.divaManager.ModelId)
				return true;
			return teamInfo.divaList[0].prismCostumeColorId != MenuScene.Instance.divaManager.ColorId;
		}

		// // RVA: 0x1547C0C Offset: 0x1547C0C VA: 0x1547C0C
		protected void AdvanceGame(StatusData teamUnitStatus, DFKGGBMFFGB_PlayerInfo playerData, EAJCBFGKKFA_FriendInfo friendData, LimitOverStatusData limitOverData, bool isSkip, int ticketCount, long consumeTime, JGEOBNENMAH.NEDILFPPCJF log, bool isNotUpdateProfile)
		{
			if (MenuScene.CheckDatelineAndAssetUpdate())
				return;
			GameSetupData.MusicInfo mi = Database.Instance.gameSetup.musicInfo;
			if (MenuScene.Instance.TryMusicPeriod(mi.LimitTime, mi.EventUniqueId, mi.gameEventType, mi.IsMvMode, MenuScene.MusicPeriodMess.TeamSelect))
				return;
			Database.Instance.gameSetup.ForcePrismSetting();
			JGEOBNENMAH.EDHCNKBMLGI h = new JGEOBNENMAH.EDHCNKBMLGI();
			h.GHBPLHBNMBK_FreeMusicId = mi.freeMusicId;
			h.KLCIIHKFPPO_StoryMusicId = mi.storyMusicId;
			h.AKNELONELJK_Difficulty = (int)mi.difficultyType;
			h.LFGNLKKFOCD_IsLine6 = mi.IsLine6Mode;
			h.OALJNDABDHK = playerData.DPLBHAIKPGL_GetTeam(mi.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva);
			h.NHPGGBCKLHC_FriendData = friendData;
			h.MNNHHJBBICA_GameEventType = (int)mi.gameEventType;
			h.MFJKNCACBDG_OpenEventType = (int)mi.openEventType;
			h.ENMGODCHGAC_Log = log;
			h.OEILJHENAHN_PlayEventType = (int)mi.playEventType;
			h.OBOPMHBPCFE_MvMode = mi.IsMvMode;
			h.FMBLKADNICN_MvTimeLimit = mi.mvLimitTime;
			h.PMCGHPOGLGM_IsSkip = isSkip;
			h.KAIPAEILJHO_TicketCount = ticketCount;
			h.IEMFPDGIAHG = 0;
			h.CEPCBJHNMJA_IsNotUpdateProfile = isNotUpdateProfile;
			if(mi.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				IKDICBBFBMI_EventBase evt = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB(mi.EventUniqueId);
				if(evt != null)
				{
					TodoLogger.Log(0, "Event");
				}
			}
			if(mi.openEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
			{
				IKDICBBFBMI_EventBase evt = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB(KGCNCBOKCBA.GNENJEHKMHD.KPMNPGKKFJG, false);
				if(evt != null)
				{
					TodoLogger.Log(0, "Event");
				}
				mi.ClearEventType();
				h.MNNHHJBBICA_GameEventType = (int)mi.gameEventType;
				h.MFJKNCACBDG_OpenEventType = (int)mi.openEventType;
			}
			MenuScene.Instance.InputDisable();
			JGEOBNENMAH.HHCJCDFCLOB.OLDDILMKJND(h, () =>
			{
				//0x154A614
				if(isSkip)
				{
					if(mi.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
					{
						TodoLogger.Log(0, "Event");
					}
					else
					{
						CIOECGOMILE.HHCJCDFCLOB.GJACBNJHDHI(ticketCount, consumeTime);
					}
				}
				m_isGotoGame = true;
				GameManager.Instance.SelectedGuestData = null;
				MenuScene.Instance.GotoRhythmGame(isSkip, ticketCount, isNotUpdateProfile);
			}, () =>
			{
				//0x154A934
				TodoLogger.Log(0, "AdvanceGame Fail");
			}, () =>
			{
				//0x154A0D0
				TodoLogger.Log(0, "AdvanceGame Fail");
			}, () =>
			{
				//0x154A47C
				TodoLogger.Log(0, "AdvanceGame Fail");
			}, () =>
			{
				//0x154A518
				TodoLogger.Log(0, "AdvanceGame Fail");
			}, (NHCDBBBMFFG status) =>
			{
				//0x154ACB4
				TodoLogger.Log(0, "AdvanceGame Fail");
			});
		}

		// // RVA: 0x15487BC Offset: 0x15487BC VA: 0x15487BC
		protected void UpdatePrismData(int musicId, GameSetupData.MusicInfo musicInfo)
		{
			m_prismData.OBKGEDCKHHE(musicId, 1 < musicInfo.onStageDivaNum);
		}

		// // RVA: 0x1548820 Offset: 0x1548820 VA: 0x1548820
		protected void SetupPrismPopupSetting()
		{
			MessageBank bank = MessageManager.Instance.GetBank("menu");
			m_prismPopupSetting.WindowSize = SizeType.Large;
			m_prismPopupSetting.SetParent(transform);
			m_prismPopupSetting.Buttons = new ButtonInfo[2];
			m_prismPopupSetting.Buttons[0].Label = PopupButton.ButtonLabel.Cancel;
			m_prismPopupSetting.Buttons[0].Type = PopupButton.ButtonType.Negative;
			m_prismPopupSetting.Buttons[1].Label = PopupButton.ButtonLabel.Ok;
			m_prismPopupSetting.Buttons[1].Type = PopupButton.ButtonType.Positive;

			TodoLogger.Log(0, "finish SetupPrismPopupSetting");

			/*m_textSetPrizmPopup.WindowSize = SizeType.Middle;
			m_textSetPrizmPopup.SetParent(transform);
			m_textSetPrizmPopup.TitleText = bank.GetMessageByLabel("popup_set_prizm_title");
			m_textSetPrizmPopup.Text = bank.GetMessageByLabel("popup_set_prizm_choice");
			m_textSetPrizmPopup.Buttons = new ButtonInfo[2];
			m_textSetPrizmPopup.Buttons[0].Label = PopupButton.ButtonLabel.Cancel;
			m_textSetPrizmPopup.Buttons[0].Type = PopupButton.ButtonType.Negative;
			m_textSetPrizmPopup.Buttons[1].Label = PopupButton.ButtonLabel.Ok;
			m_textSetPrizmPopup.Buttons[1].Type = PopupButton.ButtonType.Positive;*/

			//m_lackDivaSetting

		}

		// // RVA: 0x1548D74 Offset: 0x1548D74 VA: 0x1548D74
		protected void ShowPrismSelectPopup(PopupMvModeSelectListContent.SelectTarget target, int divaSlotNumber, int musicId, GameSetupData.MusicInfo musicInfo, bool isSimulation, Action onOK, Action onEnd)
		{
			m_prismPopupSetting.SelectTarget = target;
			m_prismPopupSetting.SelectIndex = divaSlotNumber;
			m_prismPopupSetting.TitleText = MessageManager.Instance.GetMessage("menu", string.Format("mvmode_setting_popuptitle_{0:D3}", (int)target));
			m_prismPopupSetting.MusicId = musicId;
			PopupWindowManager.Show(m_prismPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) => {
				//0x154B570
				if(type == PopupButton.ButtonType.Positive)
				{
					PopupMvModeSelectListContent pcontent = control.Content as PopupMvModeSelectListContent;
					if(pcontent != null)
					{
						pcontent.Apply();
						SendPrismChangeLog(musicId, musicInfo, isSimulation);
						UpdatePrismData(musicId, musicInfo);
						if(onOK != null)
							onOK();
					}
				}
			}, null, null, null, true, true, false, null, () => {
				//0x154B718
				if(onEnd != null)
					onEnd();
			}, null, null, null);
		}

		// // RVA: 0x15490A0 Offset: 0x15490A0 VA: 0x15490A0
		// protected bool OriginalPrizmApply(int musicId, GameSetupData.MusicInfo musicInfo) { }

		// // RVA: 0x15494A0 Offset: 0x15494A0 VA: 0x15494A0
		// private void ShowOriginalPrismSettingFailurePopup(List<int> divaIds) { }

		// // RVA: 0x1549668 Offset: 0x1549668 VA: 0x1549668
		// protected void ShowOriginalPrismSettingPopup(int musicId, GameSetupData.MusicInfo musicInfo, bool isSimulation, Action okCallBack) { }

		// // RVA: 0x1549810 Offset: 0x1549810 VA: 0x1549810
		protected static bool CheckExistOriginalSetting(AOJGDNFAIJL_PrismData.AMIECPBIALP prismData)
		{
			return prismData.CPGGFKAINHH();
		}

		// // RVA: 0x154983C Offset: 0x154983C VA: 0x154983C
		private void SendPrismChangeLog(int musicId, GameSetupData.MusicInfo musicInfo, bool isSimulation)
		{
			TodoLogger.Log(0, "SendPrismChangeLog");
		}
	}
}
