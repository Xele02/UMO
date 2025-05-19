using System;
using System.Collections;
using System.Collections.Generic;
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
		private static readonly PrefabCacheParam[] m_prefabCacheParams = new PrefabCacheParam[15] {
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
		private AOJGDNFAIJL_PrismData.AMIECPBIALP m_prismLogDiffData = new AOJGDNFAIJL_PrismData.AMIECPBIALP(); // 0x4C
		private PopupMvModeSelectListSetting m_prismPopupSetting = new PopupMvModeSelectListSetting(); // 0x50
		private List<int> m_lackDivaIds = new List<int>(); // 0x54
		private AOJGDNFAIJL_PrismData.AMIECPBIALP m_prismOriginalData = new AOJGDNFAIJL_PrismData.AMIECPBIALP(); // 0x58
		private TextPopupSetting m_textSetPrizmPopup = new TextPopupSetting(); // 0x5C
		private PopupMvModeLackDivaSetting m_lackDivaSetting = new PopupMvModeLackDivaSetting(); // 0x60

		protected DFKGGBMFFGB_PlayerInfo m_playerData { get { return GameManager.Instance.ViewPlayerData; } } //0x1547368

		// [IteratorStateMachineAttribute] // RVA: 0x72E4B4 Offset: 0x72E4B4 VA: 0x72E4B4
		// // RVA: 0x1547404 Offset: 0x1547404 VA: 0x1547404
		protected IEnumerator CreateUGUIObjectCache()
		{
			//0x154B8E8
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle("ly/013.xab"));
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
				IKDICBBFBMI_EventBase evt = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(mi.EventUniqueId);
				if(evt != null)
				{
					h.IEMFPDGIAHG = (evt as HAEDCCLHEMN_EventBattle).MDBIEKEFNJG();
				}
			}
			if(mi.openEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
			{
				IKDICBBFBMI_EventBase evt = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.KPMNPGKKFJG, false);
				if(evt != null)
				{
					TodoLogger.LogError(TodoLogger.EventCollection_1, "Event");
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
						PKNOKJNLPOE_EventRaid evRaid = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(mi.EventUniqueId) as PKNOKJNLPOE_EventRaid;
						if(evRaid == null || !(evRaid.CFLEMFADGLG_AttackType == JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.CCAPCGPIIPF_1 || evRaid.CFLEMFADGLG_AttackType == JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.LPNPLGJJCPC_2))
						{
							CIOECGOMILE.HHCJCDFCLOB.GJACBNJHDHI(ticketCount, consumeTime);
						}
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
				string str = "popup_stamina_title_00";
				string str2 = "popup_stamina_text_00";
				if(mi.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
				{
					str = "popup_ap_title_00";
					str2 = "popup_ap_text_00";
				}
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("str")
					, SizeType.Small, bk.GetMessageByLabel(str2), new ButtonInfo[1] 
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, true
				), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x154A034
					MenuScene.Instance.InputEnable();
				}, null, null, null);
			}, () =>
			{
				//0x154A0D0
				MenuScene.Instance.InputEnable();
				PopupWindowManager.Show(PopupWindowManager.CreateMessageBankTextContent("menu", "popup_event_end_title", "game_play_event_end_attain", SizeType.Small, new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x154A3C4
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}, null, null, null);
			}, () =>
			{
				//0x154A47C
				MenuScene.Instance.GotoTitle();
			}, () =>
			{
				//0x154A518
				MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				MenuScene.Instance.InputEnable();
			}, (NHCDBBBMFFG status) =>
			{
				//0x154ACB4
				TextPopupSetting s = new TextPopupSetting();
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				UnityEngine.Debug.LogWarning("StringLiteral_18271" + status.ToString());
				if(status == NHCDBBBMFFG.NFDONDKDHPK_3_Escaped)
				{
					s.SetParent(transform);
					s.WindowSize = SizeType.Small;
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					s.TitleText = bk.GetMessageByLabel("pop_raid_escaped01_title");
					s.Text = bk.GetMessageByLabel("pop_raid_escaped01_text");
					PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x154B468
						MenuScene.Instance.Mount(mi.returnTransitionUniqueId, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
						MenuScene.Instance.InputEnable();
					}, null, null, null);
				}
				else if(status != NHCDBBBMFFG.OPNEOJEGDJB_2_Dead)
				{
					MenuScene.Instance.Mount(mi.returnTransitionUniqueId, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					MenuScene.Instance.InputEnable();
				}
				else
				{
					s.SetParent(transform);
					s.WindowSize = SizeType.Small;
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					s.TitleText = bk.GetMessageByLabel("pop_raid_defeated_title");
					s.Text = bk.GetMessageByLabel("pop_raid_defeated_text");
					PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x154B360
						MenuScene.Instance.Mount(mi.returnTransitionUniqueId, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
						MenuScene.Instance.InputEnable();
					}, null, null, null);
				}
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

			m_textSetPrizmPopup.WindowSize = SizeType.Middle;
			m_textSetPrizmPopup.SetParent(transform);
			m_textSetPrizmPopup.TitleText = bank.GetMessageByLabel("popup_set_prizm_title");
			m_textSetPrizmPopup.Text = bank.GetMessageByLabel("popup_set_prizm_choice");
			m_textSetPrizmPopup.Buttons = new ButtonInfo[2];
			m_textSetPrizmPopup.Buttons[0].Label = PopupButton.ButtonLabel.Cancel;
			m_textSetPrizmPopup.Buttons[0].Type = PopupButton.ButtonType.Negative;
			m_textSetPrizmPopup.Buttons[1].Label = PopupButton.ButtonLabel.Ok;
			m_textSetPrizmPopup.Buttons[1].Type = PopupButton.ButtonType.Positive;

			m_lackDivaSetting.WindowSize = SizeType.Middle;
			m_lackDivaSetting.SetParent(transform);
			m_lackDivaSetting.TitleText = bank.GetMessageByLabel("popup_set_prizm_lackdiva_titile");
			m_lackDivaSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
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
		protected bool OriginalPrizmApply(int musicId, GameSetupData.MusicInfo musicInfo)
		{
			m_prismOriginalData.OBKGEDCKHHE(musicId, 1 < musicInfo.onStageDivaNum);
			AOJCMPIBFHD originalPrism = m_prismOriginalData.OOKAOFJBCFD();
			m_lackDivaIds.Clear();
			bool res = false;
			for(int i = 0; i < originalPrism.OFGIOBGAJPA; i++)
			{
				FFHPBEPOMAK_DivaInfo f = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Find((FFHPBEPOMAK_DivaInfo x) =>
				{
					//0x154B72C
					return x.AHHJLDLAPAN_DivaId == originalPrism.AHHJLDLAPAN[i];
				});
				int id = 0;
				if(f == null || !f.FJODMPGPDDD_DivaHave)
				{
					m_lackDivaIds.Add(originalPrism.AHHJLDLAPAN[i]);
					res = true;
				}
				else
				{
					id = f.AHHJLDLAPAN_DivaId;
				}
				m_prismOriginalData.EKACMEKEJLP(m_prismData, id, i);
			}
			m_prismOriginalData.LMAAILCIFLF_ApplyInSave();
			return res;
		}

		// // RVA: 0x15494A0 Offset: 0x15494A0 VA: 0x15494A0
		private void ShowOriginalPrismSettingFailurePopup(List<int> divaIds)
		{
			m_lackDivaSetting.DivaIds = divaIds;
			PopupWindowManager.Show(m_lackDivaSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x154A5F8
				return;
			}, null, null, null);
		}

		// // RVA: 0x1549668 Offset: 0x1549668 VA: 0x1549668
		protected void ShowOriginalPrismSettingPopup(int musicId, GameSetupData.MusicInfo musicInfo, bool isSimulation, Action okCallBack)
		{
			PopupWindowManager.Show(m_textSetPrizmPopup, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x154B7C4
				if (type == PopupButton.ButtonType.Positive && okCallBack != null)
				{
					bool b = OriginalPrizmApply(musicId, musicInfo);
					SendPrismChangeLog(musicId, musicInfo, isSimulation);
					UpdatePrismData(musicId, musicInfo);
					okCallBack();
					if(b)
					{
						ShowOriginalPrismSettingFailurePopup(m_lackDivaIds);
					}
				}
			}, null, null, null);
		}

		// // RVA: 0x1549810 Offset: 0x1549810 VA: 0x1549810
		protected static bool CheckExistOriginalSetting(AOJGDNFAIJL_PrismData.AMIECPBIALP prismData)
		{
			return prismData.CPGGFKAINHH();
		}

		// // RVA: 0x154983C Offset: 0x154983C VA: 0x154983C
		private void SendPrismChangeLog(int musicId, GameSetupData.MusicInfo musicInfo, bool isSimulation)
		{
			m_prismLogDiffData.OBKGEDCKHHE(musicId, musicInfo.onStageDivaNum > 1);
			ILCCJNDFFOB.HHCJCDFCLOB.CBKENDJIBDM(isSimulation ? "S-LIVE" : JpStringLiterals.StringLiteral_18280, musicId,
				m_prismData.FBGAKINEIPG ? 1 : 0, m_prismData.OMNDNNFANCK_PrismDivaIds, m_prismData.DLPIKHDNIIE_PrismCostumeIds, 
				m_prismData.FBAGIDFLHHI_PrismValkyrieId, m_prismLogDiffData.FBGAKINEIPG ? 1 : 0, m_prismLogDiffData.OMNDNNFANCK_PrismDivaIds, 
				m_prismLogDiffData.DLPIKHDNIIE_PrismCostumeIds, m_prismLogDiffData.FBAGIDFLHHI_PrismValkyrieId);
		}
	}
}
