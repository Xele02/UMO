using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EventBattleScene : MusicSelectSceneBase
	{
		private MusicSelectEventInfo m_eventInfo; // 0xF8
		private MusicSelectBattleInfo m_battleInfo; // 0xFC
		private MusicSelectBattleMatch m_battleMatch; // 0x100
		private MusicSelectBattleLimit m_battleLimit; // 0x104
		private MusicSelectBattleExButton m_battleExButton; // 0x108
		private MusicSelectBattleExGauge m_battleExGauge; // 0x10C
		private EventTimeLimitMessage m_timeLimitMessage; // 0x110
		private MusicSelectLineButton m_lineButton; // 0x114
		private LayoutPopupExBattleScore m_ExBattleScore; // 0x118
		private LayoutPopupExBattleScoreTotal m_ExBattleScoreTotal; // 0x11C
		private LayoutBattleClassListWindow m_battleClassSelect; // 0x120
		private MusicDataList m_musicList; // 0x124
		private DivaIconDecoration m_selfDivaDeco; // 0x128
		private DivaIconDecoration m_rivalDivaDeco; // 0x12C
		private SceneIconDecoration m_selfSceneDeco; // 0x130
		private SceneIconDecoration m_rivalSceneDeco; // 0x134
		private bool m_isEventChecked; // 0x138
		private bool m_isMatched; // 0x139
		private bool m_isClassSelected; // 0x13A
		private ConfigMenu m_gameSettingMenu; // 0x13C

		protected override int musicListCount { get { return 1; } } //0xF0F120
		protected override MusicDataList currentMusicList { get {  return m_musicList;} } //0xF0F130
		// protected override bool scrollIsClamp { get; } 0xF0F138

		// // RVA: 0xF0F128 Offset: 0xF0F128 VA: 0xF0F128 Slot: 32
		protected override MusicDataList GetMusicList(int i)
		{
			return m_musicList;
		}

		// RVA: 0xF0F140 Offset: 0xF0F140 VA: 0xF0F140 Slot: 5
		protected override void Start()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene Start");
		}

		// RVA: 0xF0F14C Offset: 0xF0F14C VA: 0xF0F14C Slot: 16
		protected override void OnPreSetCanvas()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene OnPreSetCanvas");
		}

		// RVA: 0xF0F2A0 Offset: 0xF0F2A0 VA: 0xF0F2A0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene IsEndPreSetCanvas");
			return true;
		}

		// RVA: 0xF0F480 Offset: 0xF0F480 VA: 0xF0F480 Slot: 20
		protected override bool OnBgmStart()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene OnBgmStart");
			return true;
		}

		// RVA: 0xF0F4FC Offset: 0xF0F4FC VA: 0xF0F4FC Slot: 9
		protected override void OnStartEnterAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene OnStartEnterAnimation");
		}

		// RVA: 0xF0F770 Offset: 0xF0F770 VA: 0xF0F770 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene IsEndEnterAnimation");
			return true;
		}

		// RVA: 0xF0F964 Offset: 0xF0F964 VA: 0xF0F964 Slot: 12
		protected override void OnStartExitAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene OnStartExitAnimation");
		}

		// RVA: 0xF0FB20 Offset: 0xF0FB20 VA: 0xF0FB20 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene IsEndExitAnimation");
			return true;
		}

		// RVA: 0xF0FD14 Offset: 0xF0FD14 VA: 0xF0FD14 Slot: 51
		// protected override void OnDecideCurrentMusic() { }

		// RVA: 0xF0FEA4 Offset: 0xF0FEA4 VA: 0xF0FEA4 Slot: 15
		protected override void OnDeleteCache()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene OnDeleteCache");
		}

		// RVA: 0xF0FF9C Offset: 0xF0FF9C VA: 0xF0FF9C Slot: 14
		protected override void OnDestoryScene()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene OnDestoryScene");
		}

		// RVA: 0xF0FFD4 Offset: 0xF0FFD4 VA: 0xF0FFD4 Slot: 35
		protected override void CheckTryInstall()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene CheckTryInstall");
		}

		// // RVA: 0xF0FFD8 Offset: 0xF0FFD8 VA: 0xF0FFD8
		// private void TryInstall() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EDB9C Offset: 0x6EDB9C VA: 0x6EDB9C
		// // RVA: 0xF100B4 Offset: 0xF100B4 VA: 0xF100B4
		private IEnumerator Co_Save()
		{
			//0x1060678
			MenuScene.Instance.RaycastDisable();
			bool done = false;
			bool err = false;
			MenuScene.Save(() =>
			{
				//0x105603C
				done = true;
			}, () =>
			{
				//0x1056048
				done = true; // Fix umo
				err = true;
			});
			while(!done)
				yield return null;
			MenuScene.Instance.RaycastEnable();
			if(err)
			{
				MenuScene.Instance.GotoTitle();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDC14 Offset: 0x6EDC14 VA: 0x6EDC14
		// // RVA: 0xF10124 Offset: 0xF10124 VA: 0xF10124 Slot: 36
		protected override IEnumerator Co_Initialize()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene CheckTryInstall");
			yield break;
		}

		// RVA: 0xF101AC Offset: 0xF101AC VA: 0xF101AC Slot: 38
		protected override PlayButtonWrapper CreatePlayButtonWrapper()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene CreatePlayButtonWrapper");
			return null;
		}

		// RVA: 0xF1022C Offset: 0xF1022C VA: 0xF1022C Slot: 39
		protected override void Release()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene Release");
		}

		// RVA: 0xF10300 Offset: 0xF10300 VA: 0xF10300 Slot: 40
		protected override void SetupViewMusicData()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene SetupViewMusicData");
		}

		// RVA: 0xF10450 Offset: 0xF10450 VA: 0xF10450 Slot: 41
		protected override void ApplyBasicInfo()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "MusicSelectScene* ApplyBasicInfo");
		}

		// RVA: 0xF1048C Offset: 0xF1048C VA: 0xF1048C Slot: 42
		protected override void ApplyMusicListInfo()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "MusicSelectScene* ApplyMusicListInfo");
		}

		// RVA: 0xF104F4 Offset: 0xF104F4 VA: 0xF104F4 Slot: 44
		protected override void DelayedApplyMusicInfo()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene DelayedApplyMusicInfo");
		}

		// RVA: 0xF10658 Offset: 0xF10658 VA: 0xF10658 Slot: 46
		// protected override void ApplyMusicInfoBasic(IBJAKJJICBC musicData) { }

		// // RVA: 0xF117A8 Offset: 0xF117A8 VA: 0xF117A8
		// private void ApplyEventInfo() { }

		// RVA: 0xF121FC Offset: 0xF121FC VA: 0xF121FC Slot: 52
		// protected override void LeaveForScrollStart() { }

		// RVA: 0xF12254 Offset: 0xF12254 VA: 0xF12254 Slot: 53
		// protected override void EnterForScrollEnd() { }

		// RVA: 0xF122AC Offset: 0xF122AC VA: 0xF122AC Slot: 54
		// protected override void OnChangedDifficulty() { }

		// // RVA: 0xF123E4 Offset: 0xF123E4 VA: 0xF123E4
		// private void InitializeDecos() { }

		// // RVA: 0xF10280 Offset: 0xF10280 VA: 0xF10280
		// private void ReleaseDecos() { }

		// // RVA: 0xF108D8 Offset: 0xF108D8 VA: 0xF108D8
		private void ApplyBattleInfo(IBJAKJJICBC musicData)
		{
			HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
			{
				bool isKira = false;
				int sceneId = 0;
				int rank = 0;
				GCIJNCFDNON_SceneInfo scene = null;
				if(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId > 0)
				{
					sceneId = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId;
					scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[sceneId - 1];
					rank = scene.CGIELKDLHGE_GetEvolveId();
					isKira = scene.MBMFJILMOBP_IsKira();
				}
				m_battleInfo.ApplySelfTitle(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName);
				GameManager.Instance.DivaIconCache.Load(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId, 
					GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, 
					GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].EKFONBFDAAP_ColorId, m_battleInfo.ApplySelfDivaIcon);
				GameManager.Instance.SceneIconCache.Load(sceneId, rank, (IiconTexture texture) =>
				{
					//0x10560AC
					m_battleInfo.ApplySelfSceneIcon(texture, isKira);
				});
				m_selfDivaDeco.SetActive(true);
				m_selfDivaDeco.Change(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0], GameManager.Instance.ViewPlayerData, DisplayType.Level);
				m_selfSceneDeco.SetActive(true);
				m_selfSceneDeco.Change(scene, DisplayType.Level);
			}
			{
				bool isKira = false;
				int sceneId = 0;
				int rank = 0;
				if(musicData.DACLONHOFLA.AFBMEMCHJCL_Scene != null)
				{
					sceneId = musicData.DACLONHOFLA.AFBMEMCHJCL_Scene.BCCHOBPJJKE_SceneId;
					rank = musicData.DACLONHOFLA.AFBMEMCHJCL_Scene.CGIELKDLHGE_GetEvolveId();
					isKira = musicData.DACLONHOFLA.AFBMEMCHJCL_Scene.MBMFJILMOBP_IsKira();
				}
				int str = musicData.DACLONHOFLA.BHCIFFILAKJ_Str;
				if(str > 2)
					str = 3;
				ev.ECFNKBGDJCA(list_no, musicData.DACLONHOFLA.OIPCCBHIKIA_RivalIdx, musicData.DACLONHOFLA.BHCIFFILAKJ_Str);
				m_battleInfo.ApplyRivalRank((MusicSelectBattleInfo.RivalRankType)musicData.DACLONHOFLA.BHCIFFILAKJ_Str);
				m_battleInfo.ApplyRivalTitle(musicData.DACLONHOFLA.OPFGFINHFCE_Name);
				m_battleInfo.ApplyRivalScore(ev.HOJNMALLCME_GetClassMaxScore(musicData.DACLONHOFLA.BHCIFFILAKJ_Str, 0));
				GameManager.Instance.DivaIconCache.Load(musicData.DACLONHOFLA.FDBOPFEOENF_RivalData.AHHJLDLAPAN_DivaId, 
					musicData.DACLONHOFLA.FDBOPFEOENF_RivalData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, 
					musicData.DACLONHOFLA.FDBOPFEOENF_RivalData.EKFONBFDAAP_ColorId, m_battleInfo.ApplyRivalDivaIcon);
				GameManager.Instance.SceneIconCache.Load(sceneId, rank, (IiconTexture texture) =>
				{
					//0x1056110
					m_battleInfo.ApplyRivalSceneIcon(texture, isKira);
				});
				m_rivalDivaDeco.SetActive(true);
				m_rivalDivaDeco.Change(musicData.DACLONHOFLA.FDBOPFEOENF_RivalData, DisplayType.Level);
				m_rivalSceneDeco.SetActive(true);
				m_rivalSceneDeco.Change(musicData.DACLONHOFLA.AFBMEMCHJCL_Scene, DisplayType.Level);
				m_battleExGauge.Setup(ev.HEOGGKBILIA_GetCurrentClassEmblemId(), ev.NJDPMDCIFBP_GetResultPoint(musicData.DACLONHOFLA.BHCIFFILAKJ_Str, true), ev.NJDPMDCIFBP_GetResultPoint(musicData.DACLONHOFLA.BHCIFFILAKJ_Str, false), ev.GGBNNMCLDMO_GetExPoint(), 100);
				if(m_eventTicketId < 1)
				{
					m_battleInfo.SetDropIconType(false);
				}
				else
				{
					m_battleInfo.SetDropIconType(true);
					GameManager.Instance.ItemTextureCache.Load(m_eventTicketId, m_battleInfo.ApplyDropItemIcon);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDC8C Offset: 0x6EDC8C VA: 0x6EDC8C
		// // RVA: 0xF0F218 Offset: 0xF0F218 VA: 0xF0F218
		// private IEnumerator Co_PreSetCanvas() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EDD04 Offset: 0x6EDD04 VA: 0x6EDD04
		// // RVA: 0xF125B0 Offset: 0xF125B0 VA: 0xF125B0 Slot: 55
		protected override IEnumerator Co_LoadLayout()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene Co_LoadLayout");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDD7C Offset: 0x6EDD7C VA: 0x6EDD7C
		// // RVA: 0xF12638 Offset: 0xF12638 VA: 0xF12638 Slot: 56
		protected override IEnumerator Co_WaitForLoaded()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene Co_WaitForLoaded");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDDF4 Offset: 0x6EDDF4 VA: 0x6EDDF4
		// // RVA: 0xF126C0 Offset: 0xF126C0 VA: 0xF126C0 Slot: 57
		protected override IEnumerator Co_WaitForAnimEnd(Action onEnd)
		{
			//0x1062C20
			while(m_eventInfo.IsPlaying())
				yield return null;
			while(m_battleInfo.IsPlaying())
				yield return null;
			while(m_battleLimit.IsPlaying())
				yield return null;
			while(m_battleExButton.IsPlaying())
				yield return null;
			while(m_battleExGauge.IsPlaying())
				yield return null;
			while(m_battleClassSelect.IsPlaying())
				yield return null;
			yield return Co.R(base.Co_WaitForAnimEnd(onEnd));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDE6C Offset: 0x6EDE6C VA: 0x6EDE6C
		// // RVA: 0xF12764 Offset: 0xF12764 VA: 0xF12764 Slot: 37
		protected override IEnumerator Co_OnActivateScene()
		{
			//0x105E5C4
			m_isEndActivateScene = false;
			if(m_isEventTimeLimit)
			{
				m_isEndActivateScene = true;
				yield break;
			}
			MenuScene.Instance.RaycastDisable();
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_ShowReciveLoginAchievement());
			}
			if(!MenuScene.Instance.DirtyChangeScene && m_isShowFirstHelp)
			{
				yield return Co.R(Co_ShowHelp());
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_Show_LoginBonusPopup(null));
			}
			if(!MenuScene.Instance.DirtyChangeScene && TutorialProc.CanBeginnerMissionLiveClearLiveHelp())
			{
				MenuScene.Instance.RaycastEnable();
				yield return Co.R(TutorialProc.Co_BeginnerMissionLiveClear(m_cdSelect, null));
				MenuScene.SaveRequest();
				//LAB_0105eb84
				m_isEndActivateScene = true;
				yield break;
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(KDHGBOOECKC.HHCJCDFCLOB.LOCAIBNPKDL_IsPlayerLevelOk() && !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MLBBKNLPBBD_HasShowTuto(BOPFPIHGJMD.PDLKAKEABDP.EILIAPKFCEO_0))
				{
					MenuScene.Instance.RaycastEnable();
					yield return Co.R(TutorialProc.Co_OffeReleaseTutorial(InputLimitButton.VOP, MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.VOP), () =>
					{
						//0x1055EA4
						return;
					}, BasicTutorialMessageId.Id_OfferRelease, true, m_cdSelect, null));
					//LAB_0105eb84
					m_isEndActivateScene = true;
					yield break;
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(SettingMenuPanel.IsValkyrieTuneUpUnlock() && !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(Common.GPFlagConstant.ID.IsValkyrieUpgrade))
				{
					MenuScene.Instance.RaycastEnable();
					yield return Co.R(TutorialProc.Co_ValkyrieUpgrade(MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Setting), BasicTutorialMessageId.Id_ValkyrieUpgradeHome, InputLimitButton.Setting, TutorialPointer.Direction.Down, m_cdSelect, null));
					//LAB_0105eb84
					m_isEndActivateScene = true;
					yield break;
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_CheckUnlock(null));
			}
			m_isEndActivateScene = true;
			PMFBBLGPLLJ p = new PMFBBLGPLLJ();
			p.KHEKNNFCAOI();
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_UnlockedClass(p));
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_Matching());
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(CanDoUnitDanceFocus(false))
				{
					yield return Co.R(TryShowUnitDanceTutorial());
				}
				yield return Co.R(TryShowExRivalTutorial());
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				AddNotice(() =>
				{
					//0xF1382C
					CheckSnsNotice();
				});
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				AddNotice(() =>
				{
					//0xF13834
					CheckOfferNotice();
				});
			}
			ShowNotice();
			MenuScene.Instance.RaycastEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDEE4 Offset: 0x6EDEE4 VA: 0x6EDEE4
		// // RVA: 0xF127EC Offset: 0xF127EC VA: 0xF127EC
		private IEnumerator Co_UnlockedClass(PMFBBLGPLLJ viewSelectData)
		{
			MessageBank msgBank; // 0x1C
			List<IHGLIHBAOII> list; // 0x20

			//0x1061854
			msgBank = MessageManager.Instance.GetBank("menu");
			list = viewSelectData.LHDNIHOAMFH(0, 0);
			if(list.Count > 0)
			{
				string s2;
				if(list.Count < 3)
				{
					s2 = msgBank.GetMessageByLabel("music_event_battle_class_get_emblem_01");
				}
				else
				{
					s2 = msgBank.GetMessageByLabel("music_event_battle_class_get_emblem_02");
				}
				PopupItemGetSetting s = new PopupItemGetSetting();
				s.TitleText = msgBank.GetMessageByLabel("popup_ar_marker_emblem_title");
				s.WindowSize = Common.SizeType.Middle;
				s.ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem, list[1].MDPKLNFFDBO_EmblemId);
				s.ItemContent = RichTextUtility.MakeColorTagString(string.Format(s2, list[1].GIDPPGJPOJA), SystemTextColor.NormalColor);
				s.IsPresentBox = false;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Type = PopupButton.ButtonType.Positive, Label = PopupButton.ButtonLabel.Ok }
				};
				bool isClosed = false;
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1055EA8
					return;
				}, null, null, null, true, true, false, null, () =>
				{
					//0x10572EC
					isClosed = true;
				}, (PopupWindowControl.SeType seType) =>
				{
					//0x1055EAC
					if(seType != PopupWindowControl.SeType.WindowOpen)
						return false;
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_004);
					return true;
				});
				yield return new WaitWhile(() =>
				{
					//0x10572F8
					return !isClosed;
				});
				yield return Co.R(Co_Save());
				bool isChallengeNewClass = false;
				HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
				if(list.Count > 0)
				{
					if(list[0].GIDPPGJPOJA != ev.KKMFHMGIIKN_GetCls())
					{
						PopupClassUnlockSetting s4 = new PopupClassUnlockSetting();
						s4.View = list[0];
						s4.WindowSize = SizeType.Small;
						s4.IsCaption = false;
						isClosed = false;
						s4.Buttons = new ButtonInfo[2]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Challenge, Type = PopupButton.ButtonType.Positive },
						};
						PopupWindowManager.Show(s4, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0x10572D4
							if(label == PopupButton.ButtonLabel.Challenge)
								isChallengeNewClass = true;
						}, null, null, null, true, true, false, null, () =>
						{
							//0x1057314
							isClosed = true;
						}, (PopupWindowControl.SeType seType) =>
						{
							//0x1055F18
							if(seType != PopupWindowControl.SeType.WindowOpen)
								return false;
							SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_004);
							return true;
						});
						yield return new WaitWhile(() =>
						{
							//0x1057320
							return !isClosed;
						});
						if(IsEventEndChallengePeriod)
						{
							TextPopupSetting s3 = PopupWindowManager.CrateTextContent(msgBank.GetMessageByLabel("popup_event_end_title"), SizeType.Small, msgBank.GetMessageByLabel("popup_event_end_text_3"), 
								new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } }, false, true);
							PopupWindowManager.Show(s3, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
							{
								//0x1055F84
								return;
							}, null, null, null, true, true, false);
							//LAB_01061fd0
						}
						//LAB_01061fd0
					}
					//LAB_01061fd0
				}
				//LAB_01061fd0
				if(!IsEventEndChallengePeriod)
				{
					if(isChallengeNewClass)
					{
						yield return Co.R(Co_ChallengeNewClass(viewSelectData));
					}
					if(!m_isClassSelected)
					{
						MenuScene.Instance.RaycastEnable();
						yield return Co.R(Co_SelectClass(viewSelectData));
						MenuScene.Instance.RaycastDisable();
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDF5C Offset: 0x6EDF5C VA: 0x6EDF5C
		// // RVA: 0xF12890 Offset: 0xF12890 VA: 0xF12890
		private IEnumerator Co_SelectClass(PMFBBLGPLLJ viewSelectData)
		{
			//0x10609F4
			MenuScene.Instance.RaycastDisable();
			m_battleClassSelect.Setup(viewSelectData, true);
			m_eventInfo.TryEnter();
			m_battleClassSelect.TryEnter();
			MenuScene.Instance.HelpButton.TryEnter();
			m_musicInfo.TryLeave();
			m_battleInfo.TryLeave();
			m_buttonSet.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_battleExButton.TryLeave();
			m_battleExGauge.TryLeave();
			m_lineButton.TryLeave();
			MenuScene.Instance.HeaderMenu.Leave(false);
			while(m_battleClassSelect.IsPlaying())
				yield return null;
			while(m_eventInfo.IsPlaying())
				yield return null;
			while(m_musicInfo.IsPlaying())
				yield return null;
			while(m_battleInfo.IsPlaying())
				yield return null;
			while(m_buttonSet.IsPlaying())
				yield return null;
			while(m_cdSelect.IsPlaying())
				yield return null;
			while(m_battleExButton.IsPlaying())
				yield return null;
			while(m_battleExGauge.IsPlaying())
				yield return null;
			while(m_lineButton.IsPlaying())
				yield return null;
			MenuScene.Instance.RaycastEnable();
			ChangeTrialMusic(m_eventCtrl.EDNMFMBLCGF_GetWavId());
			bool isClosed = false;
			bool isUpdate = false;
			m_battleClassSelect.OnSelectEvent = (IHGLIHBAOII viewClassData) =>
			{
				//0x105733C
				if(MenuScene.CheckDatelineAndAssetUpdate())
					isUpdate = true;
				HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
				ev.HGCIBMLAAMI_SetClsAndResetExPoint(viewClassData.AIMCAJDBNOI);
				isClosed = true;
			};
			yield return new WaitWhile(() =>
			{
				//0x1057550
				return !isClosed;
			});
			m_battleClassSelect.TryLeave();
			while(isUpdate)
				yield return null;
			m_isMatched = false;
			yield return Co.R(Co_Matching());
			m_musicInfo.TryEnter();
			m_battleInfo.TryEnter();
			m_buttonSet.TryEnter();
			m_cdSelect.TryEnter();
			m_cdArrow.TryEnter();
			m_battleExButton.TryEnter();
			m_battleExGauge.TryEnter();
			if(currentMusicList.GetCount(true, false) > 0)
			{
				m_lineButton.TryEnter(m_isLine6Mode);
			}
			MenuScene.Instance.HelpButton.TryEnter();
			MenuScene.Instance.HeaderMenu.Enter(false);
			while(m_battleClassSelect.IsPlaying())
				yield return null;
			while(m_musicInfo.IsPlaying())
				yield return null;
			while(m_battleInfo.IsPlaying())
				yield return null;
			while(m_buttonSet.IsPlaying())
				yield return null;
			while(m_cdSelect.IsPlaying())
				yield return null;
			while(m_battleExButton.IsPlaying())
				yield return null;
			while(m_battleExGauge.IsPlaying())
				yield return null;
			while(m_lineButton.IsPlaying())
				yield return null;
			if(CanDoUnitDanceFocus(false))
			{
				yield return Co.R(TryShowUnitDanceTutorial());
			}
			yield return Co.R(TryShowExRivalTutorial());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDFD4 Offset: 0x6EDFD4 VA: 0x6EDFD4
		// // RVA: 0xF12934 Offset: 0xF12934 VA: 0xF12934
		private IEnumerator Co_ChallengeNewClass(PMFBBLGPLLJ viewSelectData)
		{
			//0x1058098
			m_eventInfo.TryLeave();
			m_musicInfo.TryLeave();
			m_battleInfo.TryLeave();
			m_buttonSet.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_battleExButton.TryLeave();
			m_battleExGauge.TryLeave();
			MenuScene.Instance.HelpButton.TryLeave();
			MenuScene.Instance.HeaderMenu.Leave(false);
			while(m_eventInfo.IsPlaying())
				yield return null;
			while(m_musicInfo.IsPlaying())
				yield return null;
			while(m_battleInfo.IsPlaying())
				yield return null;
			while(m_buttonSet.IsPlaying())
				yield return null;
			while(m_cdSelect.IsPlaying())
				yield return null;
			while(m_battleExButton.IsPlaying())
				yield return null;
			while(m_battleExGauge.IsPlaying())
				yield return null;
			if(MenuScene.CheckDatelineAndAssetUpdate())
			{
				while(true)
					yield return null;
			}
			List<IHGLIHBAOII> l = viewSelectData.KBHCHFDAHGL();
			int v = 0;
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].MNAKKLEJBFG_IsUnlocked)
				{
					v = l[i].AIMCAJDBNOI;
					break;
				}
			}
			HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
			ev.HGCIBMLAAMI_SetClsAndResetExPoint(v);
			m_isMatched = false;
			yield return Co.R(Co_Matching());
			m_eventInfo.TryEnter();
			m_musicInfo.TryEnter();
			m_battleInfo.TryEnter();
			m_buttonSet.TryEnter();
			m_cdSelect.TryEnter();
			m_cdArrow.TryEnter();
			m_battleExButton.TryEnter();
			m_battleExGauge.TryEnter();
			MenuScene.Instance.HelpButton.TryEnter();
			MenuScene.Instance.HeaderMenu.Enter(false);
			while(m_eventInfo.IsPlaying())
				yield return null;
			while(m_musicInfo.IsPlaying())
				yield return null;
			while(m_battleInfo.IsPlaying())
				yield return null;
			while(m_buttonSet.IsPlaying())
				yield return null;
			while(m_cdSelect.IsPlaying())
				yield return null;
			while(m_battleExButton.IsPlaying())
				yield return null;
			while(m_battleExGauge.IsPlaying())
				yield return null;
			if(CanDoUnitDanceFocus(false))
			{
				yield return Co.R(TryShowUnitDanceTutorial());
			}
			yield return Co.R(TryShowExRivalTutorial());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EE04C Offset: 0x6EE04C VA: 0x6EE04C
		// // RVA: 0xF129D8 Offset: 0xF129D8 VA: 0xF129D8
		private IEnumerator Co_Matching()
		{
			//0x105D73C
			if(m_isMatched)
				yield break;
			m_battleMatch.Enter();
			MenuScene.Instance.HelpButton.TryLeave();
			MenuScene.Instance.HeaderMenu.Leave(false);
			MenuScene.Instance.FooterMenu.Leave(false);
			bool done = false;
			bool err = false;
			(m_eventCtrl as HAEDCCLHEMN_EventBattle).MPPGMNOOGIL_Matching(() =>
			{
				//0x105756C
				done = true;
			}, () =>
			{
				//0x1057578
				done = true;
				err = true;
			});
			while(m_battleMatch.IsPlaying())
				yield return null;
			m_battleMatch.Active();
			while(!done)
				yield return null;
			if(err)
			{
				MenuScene.Instance.InputEnable();
				MenuScene.Instance.GotoTitle();
				yield break;
			}
			m_isMatched = true;
			m_battleMatch.Leave();
			while(m_battleMatch.IsPlaying())
				yield return null;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			List<IBJAKJJICBC> l = IBJAKJJICBC.EHNABCEGAHO(t, false, false);
			m_musicList = new MusicDataList(l, IBJAKJJICBC.EHNABCEGAHO(t, false, true));
			OverrideEnemySkill();
			m_isLine6Mode = false;
			m_lineButton.SetUnlock(IBJAKJJICBC.KGJJCAKCMLO());
			m_lineButton.SetUnlockNumber(IBJAKJJICBC.POPLHDKHIIM());
			yield return this.StartCoroutineWatched(Co_BattleAssetDownLoad(l));
			MenuScene.Instance.HelpButton.TryEnter();
			MenuScene.Instance.HeaderMenu.Enter(false);
			MenuScene.Instance.FooterMenu.Enter(false);
			m_initParam.isDisableBattleEventIntermediateResult = !GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KPFAFLBICLA_IsNotBattleEventInfo;
			diff = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.MFFAIIDJPBL_BattleEvent.FFACBDAJJJP_GetDifficulty();
			list_no = 0;
			int fmid = 0;
			FreeCategoryId.Type cat = FreeCategoryId.Type.None;
			if(SelectUnitDanceFocus(out fmid, out cat, ref m_isLine6Mode, false, OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle))
			{
				int idx = m_musicList.FindIndex(fmid, false, false);
				if(idx > -1)
					list_no = idx;
			}
			ApplyMusicListInfo();
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
			ApplyBattleInfo(selectMusicData);
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			m_musicInfo.TryEnter();
			m_eventInfo.TryEnter();
			m_cdSelect.TryEnter();
			m_cdArrow.TryEnter();
			m_buttonSet.TryEnter();
			m_battleInfo.TryEnter();
			m_battleExButton.TryEnter();
			m_battleExGauge.TryEnter();
			if(currentMusicList.GetCount(true, false) > 0)
			{
				m_lineButton.TryEnter(m_isLine6Mode);
			}
			yield return Co.R(Co_WaitForAnimEnd(() =>
			{
				//0x1055F88
				return;
			}));
		}

		// // RVA: 0xF12A60 Offset: 0xF12A60 VA: 0xF12A60
		// private void OnClickExBattleScore() { }

		// // RVA: 0xF12C28 Offset: 0xF12C28 VA: 0xF12C28
		private void OverrideEnemySkill()
		{
			IBJAKJJICBC.BDNIEPMOHDI(m_musicList.GetList(false, false));
			IBJAKJJICBC.BDNIEPMOHDI(m_musicList.GetList(true, false));
		}

		// // RVA: 0xF12C98 Offset: 0xF12C98 VA: 0xF12C98
		// private void OnClickSelectClassButton() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE0C4 Offset: 0x6EE0C4 VA: 0x6EE0C4
		// // RVA: 0xF12D9C Offset: 0xF12D9C VA: 0xF12D9C
		// private IEnumerator Co_OpenBattleEventPopup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE13C Offset: 0x6EE13C VA: 0x6EE13C
		// // RVA: 0xF12E24 Offset: 0xF12E24 VA: 0xF12E24
		// private IEnumerator Co_ConfirmSelectClass(Action<bool> onEnd) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE1B4 Offset: 0x6EE1B4 VA: 0x6EE1B4
		// // RVA: 0xF12EC8 Offset: 0xF12EC8 VA: 0xF12EC8
		protected IEnumerator TryShowExRivalTutorial()
		{
			//0x10634C0
			if(CheckExRivalHelpFunc())
			{
				HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
				if(ev != null && ev.GCNAICGAEPF_GetExRivalHelpId() != 0)
				{
					MenuScene.Instance.RaycastDisable();
					MenuScene.Instance.InputDisable();
					yield return this.StartCoroutineWatched(TutorialManager.ShowTutorial(ev.GCNAICGAEPF_GetExRivalHelpId(), () =>
					{
						//0x1057780
						ev.MJKEIBCDFJB_SetExRivalTutoShown();
						MenuScene.Instance.InputEnable();
						MenuScene.Instance.RaycastEnable();
					}));
				}
			}
		}

		// // RVA: 0xF12F50 Offset: 0xF12F50 VA: 0xF12F50
		private bool CheckExRivalHelpFunc()
		{
			HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
			if(ev != null)
			{
				if(!ev.LDIMNGFBKHL_GetExRivalTutoShown())
				{
					for(int i = 0; i < musicListCount; i++)
					{
						for(int j = 0; j < GetMusicList(i).GetCount(false, false); j++)
						{
							IBJAKJJICBC m = GetMusicList(i).Get(j, false, false);
							if(m != null && m.DACLONHOFLA != null && m.DACLONHOFLA.BHCIFFILAKJ_Str > 2)
								return true;
						}
					}
				}
			}
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EE22C Offset: 0x6EE22C VA: 0x6EE22C
		// // RVA: 0xF13108 Offset: 0xF13108 VA: 0xF13108
		private IEnumerator Co_BattleAssetDownLoad(List<IBJAKJJICBC> musicList)
		{
			//0x1057910
			for(int i = 0; i < musicList.Count; i++)
			{
				GameManager.Instance.DivaIconCache.TryInstall(musicList[i].DACLONHOFLA.FDBOPFEOENF_RivalData.AHHJLDLAPAN_DivaId,
					musicList[i].DACLONHOFLA.FDBOPFEOENF_RivalData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, 
					musicList[i].DACLONHOFLA.FDBOPFEOENF_RivalData.EKFONBFDAAP_ColorId);
				if(musicList[i].DACLONHOFLA.AFBMEMCHJCL_Scene != null)
				{
					GameManager.Instance.SceneIconCache.TryInstall(musicList[i].DACLONHOFLA.AFBMEMCHJCL_Scene.BCCHOBPJJKE_SceneId, 
						musicList[i].DACLONHOFLA.AFBMEMCHJCL_Scene.CGIELKDLHGE_GetEvolveId());
				}
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(MusicJacketTextureCache.MakeJacketTexturePath(musicList[i].JNCPEGJGHOG_JacketId));
			}
			GameManager.Instance.DivaIconCache.TryInstall(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId,
				GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId,
				GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].EKFONBFDAAP_ColorId);
            FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0];
            if (diva.FGFIBOBAPIA_SceneId > 0)
			{
				GameManager.Instance.SceneIconCache.TryInstall(diva.FGFIBOBAPIA_SceneId, 
					GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[diva.FGFIBOBAPIA_SceneId - 1].CGIELKDLHGE_GetEvolveId());
			}
			yield return null;
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
        }

		// // RVA: 0xF13190 Offset: 0xF13190 VA: 0xF13190
		// protected void OnChangeLineMode(int style) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE2A4 Offset: 0x6EE2A4 VA: 0x6EE2A4
		// // RVA: 0xF134C8 Offset: 0xF134C8 VA: 0xF134C8
		// private IEnumerator Co_ChangeLineMode(int freeMusicId, int strength, Action callback) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE31C Offset: 0x6EE31C VA: 0x6EE31C
		// // RVA: 0xF135A4 Offset: 0xF135A4 VA: 0xF135A4
		// private void <ApplyMusicInfoBasic>b__48_0(long current, long limit, long remain) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE32C Offset: 0x6EE32C VA: 0x6EE32C
		// // RVA: 0xF135D0 Offset: 0xF135D0 VA: 0xF135D0
		// private void <ApplyEventInfo>b__49_0(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE33C Offset: 0x6EE33C VA: 0x6EE33C
		// // RVA: 0xF1362C Offset: 0xF1362C VA: 0xF1362C
		// private void <ApplyEventInfo>b__49_2(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE34C Offset: 0x6EE34C VA: 0x6EE34C
		// // RVA: 0xF13660 Offset: 0xF13660 VA: 0xF13660
		// private void <ApplyEventInfo>b__49_1(long current, long limit, long remain) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE35C Offset: 0x6EE35C VA: 0x6EE35C
		// [DebuggerHiddenAttribute] // RVA: 0x6EE35C Offset: 0x6EE35C VA: 0x6EE35C
		// // RVA: 0xF13814 Offset: 0xF13814 VA: 0xF13814
		// private void <>n__0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE38C Offset: 0x6EE38C VA: 0x6EE38C
		// [DebuggerHiddenAttribute] // RVA: 0x6EE38C Offset: 0x6EE38C VA: 0x6EE38C
		// // RVA: 0xF1381C Offset: 0xF1381C VA: 0xF1381C
		// private IEnumerator <>n__1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE3BC Offset: 0x6EE3BC VA: 0x6EE3BC
		// [DebuggerHiddenAttribute] // RVA: 0x6EE3BC Offset: 0x6EE3BC VA: 0x6EE3BC
		// // RVA: 0xF13824 Offset: 0xF13824 VA: 0xF13824
		// private IEnumerator <>n__2(Action onEnd) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE40C Offset: 0x6EE40C VA: 0x6EE40C
		// // RVA: 0xF1383C Offset: 0xF1383C VA: 0xF1383C
		// private void <OnClickExBattleScore>b__65_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE41C Offset: 0x6EE41C VA: 0x6EE41C
		// // RVA: 0xF13B9C Offset: 0xF13B9C VA: 0xF13B9C
		// private void <OnClickExBattleScore>b__65_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE42C Offset: 0x6EE42C VA: 0x6EE42C
		// // RVA: 0xF13BC8 Offset: 0xF13BC8 VA: 0xF13BC8
		// private void <OnClickExBattleScore>b__65_1(EMGOCNMMPHC view) { }
	}
}
