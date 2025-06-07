using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LobbyMissionArgs : TransitionArgs
	{
		public NKOBMDPHNGP_EventRaidLobby cont; // 0x8
	}

	public class LobbyMissionScene : TransitionRoot
	{
		private class LobbyQuestInfo : AKIIJBEJOEP
		{
			private int stat_; // 0x94
			private int count_; // 0x98

			public int stat { get { return stat_ ^ FBGGEFFJJHB; } set { stat_ = value ^ FBGGEFFJJHB; } } //0xD15538 0xD19654
			public int count { get { return count_ ^ FBGGEFFJJHB; } set { count_ = value ^ FBGGEFFJJHB; } } //0xD15528 0xD19664

			// RVA: 0xD14A0C Offset: 0xD14A0C VA: 0xD14A0C
			public LobbyQuestInfo(AKIIJBEJOEP src, int stat, int count)
			{
				FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
				this.stat = stat;
				this.count = count;
				PPFNGGCBJKC_Id = src.PPFNGGCBJKC_Id;
				GBJFNGCDKPM_Type = src.GBJFNGCDKPM_Type;
				PPEGAKEIEGM_Enabled = src.PPEGAKEIEGM_Enabled;
				FEMMDNIELFC_Desc = src.FEMMDNIELFC_Desc;
				BGBJPGEIEDE_DescBalloon = src.BGBJPGEIEDE_DescBalloon;
				JOPOPMLFINI = src.JOPOPMLFINI;
				LMPPENOILPF = src.LMPPENOILPF;
				KIJAPOFAGPN_ItemId = src.KIJAPOFAGPN_ItemId;
				JDLJPNMLFID_ItemCount = src.JDLJPNMLFID_ItemCount;
				EILKGEADKGH = src.EILKGEADKGH;
				HHIBBHFHENH_NextStepId = src.HHIBBHFHENH_NextStepId;
				KJBGCLPMLCG_Start = src.KJBGCLPMLCG_Start;
				GJFPFFBAKGK_End = src.GJFPFFBAKGK_End;
				DGMIADAEGAI_TargetDifficultyType = src.DGMIADAEGAI_TargetDifficultyType;
				HBJJCDIMOPO_TargetMusicConditionId = src.HBJJCDIMOPO_TargetMusicConditionId;
				HMOJCCPIPBP_TargetMusicType = src.HMOJCCPIPBP_TargetMusicType;
				FHILEEHDDKN_TargetUnitConditionId = src.FHILEEHDDKN_TargetUnitConditionId;
				FAHLEOKHBGH_TargetUnitConditionValue = src.FAHLEOKHBGH_TargetUnitConditionValue;
				NAPODHGLKAJ_TargetUnitType = src.NAPODHGLKAJ_TargetUnitType;
				DEIEONIILLJ_ClearConditionId = src.DEIEONIILLJ_ClearConditionId;
				JAFIPGKNCAA = src.JAFIPGKNCAA;
				JJECMJFDEEP_ClearConditionValue = src.JJECMJFDEEP_ClearConditionValue;
				JJALDEPKCIJ = src.JJALDEPKCIJ;
				GLDIGCJNOBO_ClearCount = src.GLDIGCJNOBO_ClearCount;
				HJNLDPMJFLB = src.HJNLDPMJFLB;
				HDAMBOOCIAA_ClearType = src.HDAMBOOCIAA_ClearType;
				OOLNFBFBONH = src.OOLNFBFBONH;
				HPAOAKMKCMA_Slt2 = src.HPAOAKMKCMA_Slt2;
				IKJAAKEINHC_Slt = src.IKJAAKEINHC_Slt;
			}
		}

		private LobbyCoopMissionWindow m_lobbyMission; // 0x48
		private List<FKMOKDCJFEN> m_questViewList; // 0x4C
		private bool m_isInitialized; // 0x50
		private NKOBMDPHNGP_EventRaidLobby m_lobbyController; // 0x54
		private bool IsGetQuestDate; // 0x58
		private Action OnReceiveCallback; // 0x5C
		private List<LobbyQuestInfo> m_missionDataList = new List<LobbyQuestInfo>(); // 0x60
		private LDEBIBGHCGD_EventRaidLobby.NBGDKOACGLM m_lobbyEventSetting = new LDEBIBGHCGD_EventRaidLobby.NBGDKOACGLM(); // 0x64

		// RVA: 0xD1411C Offset: 0xD1411C VA: 0xD1411C Slot: 4
		protected override void Awake()
		{
			base.Awake();
			IsReady = true;
		}

		// RVA: 0xD14144 Offset: 0xD14144 VA: 0xD14144 Slot: 16
		protected override void OnPreSetCanvas()
		{
			IsGetQuestDate = true;
			base.OnPreSetCanvas();
			LobbyMissionArgs arg = Args as LobbyMissionArgs;
			if(arg != null)
				m_lobbyController = arg.cont;
		}

		// RVA: 0xD14210 Offset: 0xD14210 VA: 0xD14210 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return base.IsEndPreSetCanvas();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EAABC Offset: 0x6EAABC VA: 0x6EAABC
		// // RVA: 0xD14218 Offset: 0xD14218 VA: 0xD14218
		private IEnumerator Co_Initialize()
		{
			//0xD1770C
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.LobbyMain, -1, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			yield return Co.R(LayoutSetting());
		}

		// RVA: 0xD142C4 Offset: 0xD142C4 VA: 0xD142C4 Slot: 18
		protected override void OnPostSetCanvas()
		{
			m_isInitialized = false;
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0xD142F4 Offset: 0xD142F4 VA: 0xD142F4 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isInitialized;
		}

		// RVA: 0xD142FC Offset: 0xD142FC VA: 0xD142FC Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(m_lobbyMission != null)
				m_lobbyMission.Enter();
		}

		// RVA: 0xD143B0 Offset: 0xD143B0 VA: 0xD143B0 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return base.IsEndEnterAnimation();
		}

		// RVA: 0xD143B8 Offset: 0xD143B8 VA: 0xD143B8 Slot: 12
		protected override void OnStartExitAnimation()
		{
			if(m_lobbyMission != null)
				m_lobbyMission.Leave();
		}

		// RVA: 0xD1446C Offset: 0xD1446C VA: 0xD1446C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_lobbyMission.IsPlaying();
		}

		// RVA: 0xD1449C Offset: 0xD1449C VA: 0xD1449C Slot: 14
		protected override void OnDestoryScene()
		{
			m_missionDataList.Clear();
			base.OnDestoryScene();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EAB34 Offset: 0x6EAB34 VA: 0x6EAB34
		// // RVA: 0xD14514 Offset: 0xD14514 VA: 0xD14514
		private IEnumerator LayoutSetting()
		{
			//0xD183A8
			bool isSuccess = false;
			bool isDone = false;
			m_lobbyController.KMCAIFKIFHM(() =>
			{
				//0xD17430
				isDone = true;
				isSuccess = true;
			}, () =>
			{
				//0xD1743C
				isDone = true;
				GotoTitle();
			});
			while(!isDone)
				yield return null;
			if(isSuccess)
			{
				yield return Co.R(Co_LoadLayOutData());
				LDEBIBGHCGD_EventRaidLobby d = m_lobbyController.FJLIDJJAGOM();
				long start = 0;
				long end = 0;
				if(d != null)
				{
					m_lobbyEventSetting = d.NGHKJOEDLIP;
					start = m_lobbyEventSetting.CJPMLAIFCDL_LobbyStart;
					end = m_lobbyEventSetting.KCBGBFMGHPA_End;
				}
				m_lobbyMission.SetLimitTime(start, end);
				QuestSort();
				QuestListUpdate();
				m_lobbyMission.OnClickItemIcon = OnClickItemIcon;
				m_lobbyMission.OnClickMissionChallenge = OnClickChallenge;
				m_lobbyMission.OnClickMissionReceive = OnClickReceive;
				m_lobbyMission.SetActionButton();
			}
			m_isInitialized = true;
			yield return null;
        }

		// // RVA: 0xD145C0 Offset: 0xD145C0 VA: 0xD145C0
		private void QuestSort()
		{
            List<IKCGAJKCPFN> quests = m_lobbyController.OLDFFDMPEBM_Quests;
            List<AKIIJBEJOEP> mission = m_lobbyController.MHGAHHPGGAE_GetMisions();
			m_missionDataList.Clear();
			for(int i = 0; i < mission.Count; i++)
			{
				IKCGAJKCPFN q = quests.Find((IKCGAJKCPFN x) =>
				{
					//0xD17470
					return mission[i].PPFNGGCBJKC_Id == x.PPFNGGCBJKC_Id;
				});
				if(q != null)
				{
					LobbyQuestInfo info = new LobbyQuestInfo(mission[i], q.EALOBDHOCHP_Stat, q.HMFFHLPNMPH_Count);
					m_missionDataList.Add(info);
				}
			}
			m_missionDataList.Sort((LobbyQuestInfo a, LobbyQuestInfo b) =>
			{
				//0xD17340
				if(a.stat != b.stat)
				{
					if(a.stat == 3)
					{
						if(b.stat != 3)
							return 1;
					}
					else if(a.stat == 2)
					{
						if(b.stat != 2)
							return -1;
					}
					else if(a.stat == 1 && b.stat == 2)
						return 1;
				}
				return a.EILKGEADKGH.CompareTo(b.EILKGEADKGH);
			});
			if(RuntimeSettings.CurrentSettings.UnlimitedEvent)
			{
				// in unlimited all mission are active, but we can only display 3. So display the first 3 not finished
				if(m_missionDataList.Count > 3)
					m_missionDataList = m_missionDataList.GetRange(0, 3);
			}
        }

		// // RVA: 0xD15088 Offset: 0xD15088 VA: 0xD15088
		public void QuestListUpdate()
		{
			for(int i = 0; i < m_missionDataList.Count; i++)
			{
				m_lobbyMission.SetGauge(i, m_missionDataList[i].count, m_missionDataList[i].GLDIGCJNOBO_ClearCount);
				m_lobbyMission.SettingTimer(m_missionDataList[i].GJFPFFBAKGK_End, i);
				m_lobbyMission.SetDesc(i, m_missionDataList[i].FEMMDNIELFC_Desc);
				m_lobbyMission.SetItemIcon(i, m_missionDataList[i].KIJAPOFAGPN_ItemId);
				m_lobbyMission.SetQuentConpCont(i, m_missionDataList[i].count, m_missionDataList[i].GLDIGCJNOBO_ClearCount);
				m_lobbyMission.SetButtonState(i, m_missionDataList[i].stat);
				m_lobbyMission.SetItemCount(i, m_missionDataList[i].JDLJPNMLFID_ItemCount);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EABAC Offset: 0x6EABAC VA: 0x6EABAC
		// // RVA: 0xD15548 Offset: 0xD15548 VA: 0xD15548
		private IEnumerator Co_LoadLayOutData()
		{
			StringBuilder bundleName; // 0x14
			FontInfo systemFont; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C

			//0xD178F8
			if(m_lobbyMission == null)
			{
				bundleName = new StringBuilder(64);
				systemFont = GameManager.Instance.GetSystemFont();
				bundleName.Set("ly/203.xab");
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_que_01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0xD171D0
					instance.transform.SetParent(transform, false);
					m_lobbyMission = instance.GetComponent<LobbyCoopMissionWindow>();
					m_lobbyMission.MissionButtonAnimaitonType(1);
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
				bundleName = null;
				systemFont = null;
				operation = null;
			}
			//LAB_00d17b50
			m_lobbyMission.Hide();
		}

		// // RVA: 0xD155F4 Offset: 0xD155F4 VA: 0xD155F4
		public void OnClickChallenge(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			OnClickChallenge(ILLPDLODANB.HNHNHHCBLDE(m_missionDataList[index], m_lobbyController), m_missionDataList[index].JJECMJFDEEP_ClearConditionValue, m_missionDataList[index]);
		}

		// // RVA: 0xD16AF0 Offset: 0xD16AF0 VA: 0xD16AF0
		public void OnClickReceive(int index)
		{
			if(QuestUtility.IsCrossDateline())
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			GameManager.Instance.StartCoroutineWatched(ConnectQuestReceive(index));
		}

		// // RVA: 0xD16CD8 Offset: 0xD16CD8 VA: 0xD16CD8
		public void OnClickItemIcon(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.ShowItemDetail(m_missionDataList[index].KIJAPOFAGPN_ItemId, m_missionDataList[index].JDLJPNMLFID_ItemCount, null);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EAC24 Offset: 0x6EAC24 VA: 0x6EAC24
		// // RVA: 0xD16C30 Offset: 0xD16C30 VA: 0xD16C30
		private IEnumerator ConnectQuestReceive(int index)
		{
			LobbyQuestInfo questMs; // 0x20
			int itemId; // 0x24
			int itemCount; // 0x28

			//0xD17CD4
			if(m_lobbyController == null)
				yield break;
			if(MenuScene.CheckDatelineAndAssetUpdate())
				yield break;
			questMs = m_missionDataList[index];
			itemId = questMs.KIJAPOFAGPN_ItemId;
			itemCount = questMs.JDLJPNMLFID_ItemCount;
			MFDJIFIIPJD m = new MFDJIFIIPJD();
			m.KHEKNNFCAOI(itemId, itemCount);
			bool cancel = false;
			yield return Co.R(QuestUtility.PopupItemPossessionLimit(m, (bool isOk) =>
			{
				//0xD17580
				if(!isOk)
					cancel = true;
			}));
			if(cancel)
				yield break;
			MenuScene.Instance.RaycastDisable();
			List<int> l = new List<int>();
			l.Add(questMs.PPFNGGCBJKC_Id);
			bool done = false;
			bool err = false;
			FKMOKDCJFEN.JKBOOMAPOBL(FKMOKDCJFEN.MEDJADCKPKH.CCDOBDNDPIL_2_Event, l, questMs.JOPOPMLFINI, (List<int> _list, bool limit) =>
			{
				//0xD17560
				done = true;
			}, () =>
			{
				//0xD1756C
				done = true;
				err = true;
			}, false);
			while(!done)
				yield return null;
			MenuScene.Instance.RaycastEnable();
			if(!err)
			{
				GameManager.Instance.ResetViewPlayerData();
				m_lobbyMission.SetButtonState(index, 3);
				yield return Co.R(PopupReceive(index, itemId, itemCount));
			}
		}

		// // RVA: 0xD15740 Offset: 0xD15740 VA: 0xD15740
		private void OnClickChallenge(BKANGIKIEML.NODKLJHEAJB sceneType, int conditionId, LobbyQuestInfo questInfo)
		{
			if(MenuScene.Instance == null)
				return;
			switch(sceneType)
			{
				case BKANGIKIEML.NODKLJHEAJB.DOEHLCLBCNN_1:
					MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.DJPFJGKGOOF_2:
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.PAAIHBHJJMM_3:
					MenuScene.Instance.Mount(TransitionUniqueId.STORYSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.EKHDECEEFFJ_4:
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_EPISODESELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.MGJDKBFHDML_5:
					MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.HBIPNFMLLBF_6:
				case BKANGIKIEML.NODKLJHEAJB.OEFNIAKHGKD_7:
				case BKANGIKIEML.NODKLJHEAJB.MLINGAKKDEP_8:
				case BKANGIKIEML.NODKLJHEAJB.GONENLHJLCJ_9:
				case BKANGIKIEML.NODKLJHEAJB.AGCMIOFBFMG_10:
				case BKANGIKIEML.NODKLJHEAJB.BBAEIHMIFFI_11:
				{
					MusicSelectArgs arg = new MusicSelectArgs();
					arg.SetSelection((FreeCategoryId.Type)((int)sceneType - 5));
					MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				}
				case BKANGIKIEML.NODKLJHEAJB.OBDLOMGHHED_12:
				{
						MusicSelectArgs arg = null;
                        List<IBJAKJJICBC> l = IBJAKJJICBC.FKDIMODKKJD(5, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), true, false, false, false);
						for(int i = 0; i < l.Count; i++)
						{
							if(l[i].LHONOILACFL_IsWeeklyEvent)
							{
								if(l[i].BELHFPMBAPJ_WeekPlay < l[i].JOJNGDPHOKG_WeeklyMax)
								{
									if(l[i].GHBPLHBNMBK_FreeMusicId > 0)
									{
										arg = new MusicSelectArgs();
										arg.SetSelection(l[i].GHBPLHBNMBK_FreeMusicId);
										break;
									}
								}
							}
						}
                        MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				}
				default:
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.FNILHIFGOCE_15:
					TransitToFreeMusic(conditionId);
					break;
				case BKANGIKIEML.NODKLJHEAJB.LINKBPIPHAK_17:
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
					{
						long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						for(int j = 1; j <= 6; j++)
						{
                            List<IBJAKJJICBC> l = IBJAKJJICBC.FKDIMODKKJD(j, t, true, false, false, false);
							List<KEODKEGFDLD_FreeMusicInfo> freeMusicList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas.FindAll((KEODKEGFDLD_FreeMusicInfo _) =>
							{
								//0xD17590
								return conditionId == _.DLAEJOBELBH_MusicId;
							});
							for(int i = 0; i < freeMusicList.Count; i++)
							{
								IBJAKJJICBC ib = l.Find((IBJAKJJICBC _) =>
								{
									//0xD175D4
									return _.GHBPLHBNMBK_FreeMusicId == freeMusicList[i].GHBPLHBNMBK_FreeMusicId;
								});
								if(ib != null)
								{
									TransitToFreeMusic(ib.GHBPLHBNMBK_FreeMusicId);
									return;
								}
							}
                        }
					}
					TransitToFreeMusic(0);
					break;
				case BKANGIKIEML.NODKLJHEAJB.ANBJBLLMHMB_18:
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
					{
                        List<int> l = IBJAKJJICBC.CJHOOLJFGFB();
						l.Sort();
                        OHCAABOMEOF.KGOGMKMBCPP_EventType type = JGEOBNENMAH.HHCJCDFCLOB.NNABDGKFEMK_EventType;
						if(type == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0 && JGEOBNENMAH.HHCJCDFCLOB.PFHMFKKDMBM_FreeMusicId > 0)
						{
							l.Insert(0, JGEOBNENMAH.HHCJCDFCLOB.PFHMFKKDMBM_FreeMusicId);
						}
						for(int i = 0; i < l.Count; i++)
						{
                            KEODKEGFDLD_FreeMusicInfo fm = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[i]);
							if(fm.DEPGBBJMFED_CategoryId != 5)
							{
                                EONOEHOKBEB_Music mi = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fm.DLAEJOBELBH_MusicId);
								if(questInfo.HBJJCDIMOPO_TargetMusicConditionId == mi.FKDCCLPGKDK_Ma)
								{
									TransitToFreeMusic(l[i]);
									return;
								}
                            }
                        }
                    }
					TransitToFreeMusic(0);
					break;
				case BKANGIKIEML.NODKLJHEAJB.OBBOJKJAHIE_20:
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_TEAMEDIT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.ADNIADMMBPM_21:
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_SCENEABILITYRELEASELIST, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.GFCAMHABJIC_22:
					MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU_PROFIL, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.ICAPJDDJIEA_23:
					MenuScene.Instance.Mount(TransitionUniqueId.HOME_PRESENTLIST, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.IJMFEGLNDFI_30:
				{
					OptionMenuScene.OptionMenuArgs arg = new OptionMenuScene.OptionMenuArgs();
					arg.openSnsLink = true;
					MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				}
				case BKANGIKIEML.NODKLJHEAJB.HGOGFPOCKFA_31:
					QuestUtility.ShowSNS();
					break;
				case BKANGIKIEML.NODKLJHEAJB.DFEBFNNJMBM_32:
					MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.KBHGPMNGALJ_33:
				{
					CostumeChangeDivaArgs arg = new CostumeChangeDivaArgs();
					arg.DivaId = 1;
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_TEAMEDIT_COSTUMESELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				}
				case BKANGIKIEML.NODKLJHEAJB.LJILBHPMPOG_34:
					MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU_SHOP, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.NHIOLMNADIO_35:
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.OCNIBCBBLAA_36:
					MenuScene.Instance.Mount(KDHGBOOECKC.HHCJCDFCLOB != null ? KDHGBOOECKC.HHCJCDFCLOB.OOFNEPBLPEA() : TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.LEHHJINPFHA_37:
					if(!MOEALEGLGCH.CDOCOLOKCJK())
					{
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					else
					{
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_COSTUMEUPGRADE, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.HHFLHPFJMPN_39:
					MenuScene.Instance.Mount(TransitionUniqueId.HOME_GAKUYA, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.PKHEABDDHKB_40:
				{
					int a;
					bool b;
					HNDLICBDEMI.FMLGCFKNKIA_GetDecoPlayerLevelAndEnabled(out a, out b);
					if(!b)
					{
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					else
					{
						MenuScene.Instance.Mount(TransitionUniqueId.DECO, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				}
				case BKANGIKIEML.NODKLJHEAJB.JDCENDOKKIE_41:
				{
					if(!SettingMenuPanel.IsValkyrieTuneUpUnlock())
					{
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					else
					{
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_VALKYRIETUNEUP, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				}
			}
		}

		// // RVA: 0xD16EB0 Offset: 0xD16EB0 VA: 0xD16EB0
		private void TransitToFreeMusic(int freeMusicId)
		{
			MusicSelectArgs arg = new MusicSelectArgs();
			if(freeMusicId < 1)
			{
				MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
			else
			{
				arg.SetSelection(freeMusicId);
				MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EAC9C Offset: 0x6EAC9C VA: 0x6EAC9C
		// // RVA: 0xD17028 Offset: 0xD17028 VA: 0xD17028
		private IEnumerator PopupReceive(int index, int itemId, int itemCount)
		{
			//0xD188D8
			MenuScene.Instance.RaycastDisable();
			MFDJIFIIPJD m = new MFDJIFIIPJD();
			m.KHEKNNFCAOI(itemId, itemCount);
			if(m.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				bool popupWait = true;
				yield return Co.R(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Quest, () =>
				{
					//0xD176FC
					popupWait = false;
				}, false));
				while(popupWait)
					yield return null;
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupQuestRewardSetting s = new PopupQuestRewardSetting();
				s.ItemInfo = m;
				s.TitleText = bk.GetMessageByLabel("popup_quest_reward_title");
				s.WindowSize = SizeType.Small;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				bool popupWait = true;
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xD17424
					return;
				}, null, null, null, true, true, false, () =>
				{
					//0xD176E4
					popupWait = false;
					return true;
				});
				while(popupWait)
					yield return null;
			}
			//LAB_00d18eb8
			if(OnReceiveCallback != null)
				OnReceiveCallback();
			KBAGKBIBGPM_EventRaidLobby.JAIFDODKMIA saveLobby = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PJCMHDEJLGF_EventRaidLobby.FBCJICEPLED[m_lobbyEventSetting.MOEKELIIDEO_SaveIdx];
			saveLobby.NNMPGOAGEOL_Quests[m_missionDataList[index].PPFNGGCBJKC_Id - 1].EALOBDHOCHP_Stat = 3;
			CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.JCHLONCMPAJ();
			StringBuilder str = new StringBuilder();
			str.Append(saveLobby.NNMPGOAGEOL_Quests[index].PPFNGGCBJKC_Id);
			str.Append(':');
			CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.PCDOEIFMLHG_10, str.ToString());
			CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, itemId, itemCount, null, 0);
			GameManager.Instance.ResetViewPlayerData();
			bool IsDone = false;
			bool IsError = false;
			MenuScene.Save(() =>
			{
				//0xD176C4
				IsDone = true;
			}, () =>
			{
				//0xD176D0
				IsDone = true;
				IsError = true;
			});
			while(!IsDone)
				yield return null;
			if(IsError)
			{
				MenuScene.Instance.GotoTitle();
			}
			QuestUtility.RemoveBackButton();
			MenuScene.Instance.RaycastEnable();
			QuestSort();
			QuestListUpdate();
		}
	}
}
