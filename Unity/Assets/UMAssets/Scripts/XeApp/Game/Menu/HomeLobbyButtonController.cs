using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using System;
using System.Collections;
using XeApp.Core;
using XeSys;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Menu
{
	public class HomeLobbyButtonController : MonoBehaviour
	{
		public enum Type
		{
			UP = 0,
			DOWN = 1,
		}
		public HomeLobbyButton m_lobbyTabBtn; // 0xC
		public HomeLobbySceneButton m_lobbySceneBtn; // 0x10
		public List<ButtonBase> m_listBtn = new List<ButtonBase>(); // 0x14
		public Action OnPreLoadAnnounce; // 0x18
		public Action OnStartAnnounce; // 0x1C
		public Action OnEndAnnounce; // 0x20
		public Action OnStartTutorial; // 0x24
		public Action OnEndTutorial; // 0x28
		private HomeLobbyAnnounce m_layoutLobbyAnnounce; // 0x2C
		private bool m_EnableShow; // 0x30
		private int m_cnt_input; // 0x34
		private bool m_IsNewMark; // 0x38
		private bool m_IsNewMarkEffect; // 0x39
		private bool m_IsInitialize; // 0x3A
		private Coroutine m_coroutine; // 0x3C

		// [IteratorStateMachineAttribute] // RVA: 0x6E28CC Offset: 0x6E28CC VA: 0x6E28CC
		// RVA: 0x966720 Offset: 0x966720 VA: 0x966720
		public IEnumerator Co_LoadLayout(GameObject a_ui_root)
		{
			//0x96A520
			yield return Co.R(Co_LoadTabButtonData(a_ui_root));
			yield return Co.R(Co_LoadSceneButtonData(a_ui_root));
			m_lobbyTabBtn.Wait();
			m_lobbySceneBtn.Wait();
			m_lobbyTabBtn.onTabClickButton = OnLobbyTabButton;
			m_lobbySceneBtn.onSceneClickButton = OnClickChangeLobbySceneButton;
			m_lobbySceneBtn.onHideClickButton = OnLobbySceneButtonHide;
			m_listBtn.Clear();
			m_listBtn.AddRange(m_lobbyTabBtn.gameObject.GetComponentsInChildren<ButtonBase>(true));
			m_listBtn.AddRange(m_lobbySceneBtn.gameObject.GetComponentsInChildren<ButtonBase>(true));
		}

		// RVA: 0x9667E8 Offset: 0x9667E8 VA: 0x9667E8
		public void Setup(Type a_type = Type.DOWN)
		{
			if(m_IsInitialize)
			{
				m_EnableShow = false;
				m_lobbyTabBtn.Wait();
				m_lobbySceneBtn.Wait();
				UpdatePresentment();
				NKOBMDPHNGP_EventRaidLobby ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_EventRaidLobby;
				if(ev != null)
				{
					if(ev.KINIOEOOCAA_GetPhase(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()) != NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.HJNNKCMLGFL_0)
					{
						m_lobbyTabBtn.SetNewIcon(m_IsNewMark, m_IsNewMarkEffect);
						m_lobbyTabBtn.SetType(a_type);
						m_lobbySceneBtn.SetType(a_type);
						SetAsLastSibling();
						m_EnableShow = true;
						Show(false);
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E2944 Offset: 0x6E2944 VA: 0x6E2944
		// // RVA: 0x967008 Offset: 0x967008 VA: 0x967008
		public IEnumerator Co_CheckNewMark(Action OnError)
		{
			NKOBMDPHNGP_EventRaidLobby t_raid_lobby_ctrl;

			//0x969A8C
			if (!m_IsInitialize)
				yield break;
			m_IsNewMark = false;
			m_IsNewMarkEffect = false;

			PKNOKJNLPOE_EventRaid t_raid_ctrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as PKNOKJNLPOE_EventRaid;
			if (t_raid_ctrl != null)
			{
				bool IsDone = false;
				bool IsError = false;
				t_raid_ctrl.AMBHKLLAJID((int _bossNum, int _newBossNum) =>
				{
					//0x969340
					IsDone = true;
					if(t_raid_ctrl.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
						return;
					m_IsNewMark |= _newBossNum > 0;
				}, () =>
				{
					//0x969400
					IsDone = true;
					IsError = true;
				});
				//LAB_00969d6c
				while(!IsDone)
					yield return null;
				if(IsError)
				{
					if(OnError != null)
						OnError();
					else
						MenuScene.Instance.GotoTitle();
					yield break;
				}
			}
			t_raid_lobby_ctrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_EventRaidLobby;
			if(t_raid_lobby_ctrl != null)
			{
				bool IsDone = false;
				bool IsError = false;
				t_raid_lobby_ctrl.KMCAIFKIFHM(() =>
				{
					//0x969414
					IsDone = true;
				}, () =>
				{
					//0x969420
					IsDone = true;
					IsError = true;
				});
				//LAB_00969dd0
				while(!IsDone)
					yield return null;
				if(IsError)
				{
					if(OnError != null)
						OnError();
					else
						MenuScene.Instance.GotoTitle();
					yield break;
				}
			}
			t_raid_lobby_ctrl = null;
			if(t_raid_ctrl != null && t_raid_lobby_ctrl != null)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				if(t_raid_lobby_ctrl.KINIOEOOCAA_GetPhase(t) == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now)
				{
					m_IsNewMark |= !t_raid_ctrl.LDMOBKMEKMD();
					m_IsNewMarkEffect = false;
					//LAB_0096a28c
				}
			}
			//LAB_0096a28c
			if (!m_lobbyTabBtn.IsLoaded())
				yield break;
			m_lobbyTabBtn.SetNewIcon(m_IsNewMark, m_IsNewMarkEffect);
		}

		// // RVA: 0x966FCC Offset: 0x966FCC VA: 0x966FCC
		public void Show(bool isEnd = false)
		{
			if (!m_EnableShow)
				return;
			m_lobbyTabBtn.Show(isEnd);
		}

		// // RVA: 0x9670D0 Offset: 0x9670D0 VA: 0x9670D0
		public void Hide(bool isEnd = false)
		{
			if(!m_EnableShow)
				return;
			m_lobbyTabBtn.Hide(isEnd);
			m_lobbySceneBtn.Hide(isEnd);
		}

		// // RVA: 0x967244 Offset: 0x967244 VA: 0x967244
		public void Wait()
		{
			if (!m_IsInitialize)
				return;
			m_lobbyTabBtn.Wait();
			m_lobbySceneBtn.Wait();
		}

		// // RVA: 0x967298 Offset: 0x967298 VA: 0x967298
		public void EnableButton(bool a_enable)
		{
			if(m_IsInitialize)
			{
				if(a_enable)
				{
					m_cnt_input--;
					if (m_cnt_input > 0)
						return;
					m_cnt_input = 0;
				}
				else
				{
					m_cnt_input++;
				}
				for(int i = 0; i < m_listBtn.Count; i++)
				{
					m_listBtn[i].IsInputOff = !a_enable;
				}
			}
		}

		// // RVA: 0x966F30 Offset: 0x966F30 VA: 0x966F30
		public void SetAsLastSibling()
		{
			if(!m_IsInitialize)
				return;
			m_lobbyTabBtn.transform.SetAsLastSibling();
			m_lobbySceneBtn.transform.SetAsLastSibling();
		}

		// // RVA: 0x9673B8 Offset: 0x9673B8 VA: 0x9673B8
		public void TransitionLobbyMain()
		{
			if(!m_IsInitialize)
				return;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			if(evLobby != null)
			{
                NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase phase = evLobby.KINIOEOOCAA_GetPhase(t);
                if (phase > NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.HJNNKCMLGFL_0 && phase < NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End)
				{
					int adv = 0;
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
					{
						adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("mcrslobby_first_adv_id", 0);
					}
					if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(adv))
					{
                        GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData advData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(adv);
						if(advData == null)
							advData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(1);
						if(advData != null)
						{
							//LAB_00967bc4
							Database.Instance.advResult.Setup("Menu", TransitionUniqueId.HOME_LOBBYGROUPSELECT, new AdvSetupParam());
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(adv);
							Database.Instance.advSetup.Setup(advData.KKPPFAHFOJI_FileId);
							MenuScene.Instance.GotoAdventure(true);
							MenuScene.Instance.InputDisable();
							return;
						}
                    }
					if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsMcrsLobby) || !evLobby.EHLFBIEGDDF())
					{
						MenuScene.Instance.Call(TransitionList.Type.LOBBY_GROUP_SELECT, null, true);
						return;
					}
					EventLobbyArgs arg = new EventLobbyArgs();
					arg.IsMyLobby = true;
					arg.playerId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
					ILCCJNDFFOB.HHCJCDFCLOB.LHCHBHPHLCP(1);
					//LAB_00967a24
					MenuScene.Instance.Mount(TransitionUniqueId.HOME_LOBBYMAIN, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					return;
				}
				if(phase != NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End)
				{
					return;
				}
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsMcrsLobby) && evLobby.EHLFBIEGDDF())
				{
					EventLobbyArgs arg = new EventLobbyArgs();
					arg.IsMyLobby = true;
					arg.playerId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
					ILCCJNDFFOB.HHCJCDFCLOB.LHCHBHPHLCP(1);
					//LAB_00967a24
					MenuScene.Instance.Mount(TransitionUniqueId.HOME_LOBBYMAIN, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					return;
				}
				EnableButton(false);
				Show_PopupNotAffiliationRaidEnd(null, () =>
				{
					//0x969294
					EnableButton(true);
				}, NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End);
				return;
			}
			Show_PopupNotAffiliationRaidEnd(null, () =>
			{
				//0x96929C
				EnableButton(true);
			}, NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End);
		}

		// // RVA: 0x9682F0 Offset: 0x9682F0 VA: 0x9682F0
		public void RequestInitRaidLobby(IMCBBOAFION onSuccess, DJBHIFLHJLK onErrorToTitle)
		{
			this.StartCoroutineWatched(InitRaidLobby(onSuccess, onErrorToTitle));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E29BC Offset: 0x6E29BC VA: 0x6E29BC
		// // RVA: 0x968314 Offset: 0x968314 VA: 0x968314
		public IEnumerator InitRaidLobby(IMCBBOAFION onSuccess, DJBHIFLHJLK onErrorToTitle)
		{
			//0x96BEFC
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
			if (ev == null)
			{
				if (onSuccess != null)
					onSuccess();
				yield break;
			}
			bool done = false;
			ev.ADACMHAHHKC_PreSetupEventHome(() =>
			{
				//0x96943C
				done = true;
				if(onSuccess != null)
					onSuccess();
			}, () =>
			{
				//0x9694A8
				done = true;
				if(onErrorToTitle != null)
					onErrorToTitle();
			});
			while(!done)
				yield return null;
		}

		// // RVA: 0x9683DC Offset: 0x9683DC VA: 0x9683DC
		public bool CheckLobbyAnnounce()
		{
			if (!m_IsInitialize)
				return false;
			if(!GameManager.Instance.IsTutorial && m_coroutine == null)
			{
				NKOBMDPHNGP_EventRaidLobby ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_EventRaidLobby;
				if(ev != null)
				{
                    NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase phase = ev.KINIOEOOCAA_GetPhase(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
					if(phase != NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.HJNNKCMLGFL_0 && phase != NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End)
					{
						if(!ev.ANOPCGFIMEJ())
						{
							return !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsMcrsLobby);
						}
						else
						{
							return true;
						}
					}
                }
			}
			return false;
		}

		// // RVA: 0x9686FC Offset: 0x9686FC VA: 0x9686FC
		public bool TryLobbyAnnounce()
		{
			if(!CheckLobbyAnnounce())
				return false;
			m_coroutine = this.StartCoroutineWatched(Co_LobbyAnnounce());
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E2A34 Offset: 0x6E2A34 VA: 0x6E2A34
		// // RVA: 0x968740 Offset: 0x968740 VA: 0x968740
		private IEnumerator Co_LobbyAnnounce()
		{
			NKOBMDPHNGP_EventRaidLobby controller; // 0x18
			NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase phase; // 0x1C
			float volume; // 0x20

			//0x96B3E4
			if(!m_IsInitialize)
				yield break;
			GameManager.Instance.CloseSnsNotice();
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.RaycastDisable();
			controller = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			phase = controller.CHDNDNMHJHI_GetPhase();
			yield return Co.R(Co_LoadLobbyAnnounce(phase, m_lobbyTabBtn.transform.parent));
			volume = SoundManager.Instance.GetCategoryVolume(SoundManager.CategoryId.MENU_BGM);
			SoundManager.Instance.SetCategoryVolume(SoundManager.CategoryId.MENU_BGM, 0);
			bool done = false;
			m_layoutLobbyAnnounce.StartAnim(() =>
			{
				//0x96951C
				done = true;
			});
			yield return null;
			if(OnStartAnnounce != null)
				OnStartAnnounce();
			while(!done)
				yield return null;
			Destroy(m_layoutLobbyAnnounce.gameObject);
			m_layoutLobbyAnnounce = null;
			SoundManager.Instance.SetCategoryVolume(SoundManager.CategoryId.MENU_BGM, volume);
			if(phase == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now)
			{
				yield return Co.R(Co_ShowTutorial_81());
			}
			controller.EGIHAHOCKPK();
			MenuScene.SaveRequest();
			MenuScene.Instance.RaycastEnable();
			MenuScene.Instance.InputEnable();
			bool isTutorial = false;
			yield return Co.R(TutorialProc.Co_McrsLobby(this, () =>
			{
				//0x969528
				isTutorial = true;
				if(OnStartTutorial != null)
					OnStartTutorial();
				MenuScene.Instance.InputDisable();
			}));
			if(isTutorial)
			{
				if(OnEndTutorial != null)
					OnEndTutorial();
				MenuScene.Instance.InputEnable();
			}
			if(OnEndAnnounce != null)
				OnEndAnnounce();
			m_coroutine = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E2AAC Offset: 0x6E2AAC VA: 0x6E2AAC
		// // RVA: 0x9687EC Offset: 0x9687EC VA: 0x9687EC
		private IEnumerator Co_ShowTutorial_81()
		{
			//0x96BBC8
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine((TutorialConditionId conditionId) =>
			{
				//0x969320
				return conditionId == TutorialConditionId.Condition81;
			}));
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.RaycastEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E2B24 Offset: 0x6E2B24 VA: 0x6E2B24
		// // RVA: 0x968880 Offset: 0x968880 VA: 0x968880
		private IEnumerator Co_LoadLobbyAnnounce(NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase phase, Transform parent)
		{
			string bundleName; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24

			//0x96A950
			bundleName = "";
			string assetName = "";
			if(phase == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now)
			{
				bundleName = "ly/210.xab";
				assetName = "root_emergency2_01_layout_root";
			}
			else if(phase == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before)
			{
				bundleName = "ly/209.xab";
				assetName = "root_emergency_01_layout_root";
			}
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x96962C
				instance.transform.SetParent(parent, false);
				instance.transform.SetAsLastSibling();
				m_layoutLobbyAnnounce = instance.GetComponent<HomeLobbyAnnounce>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E2B9C Offset: 0x6E2B9C VA: 0x6E2B9C
		// // RVA: 0x968960 Offset: 0x968960 VA: 0x968960
		private IEnumerator Co_LoadTabButtonData(GameObject a_ui_root)
		{
			string _lyName; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20

			//0x96B048
			_lyName = "ly/202.xab";
			operation = AssetBundleManager.LoadLayoutAsync(_lyName, "root_cmn_lobby_tb_layout_root");
			yield return operation;
			yield return operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x96974C
				m_lobbyTabBtn = instance.GetComponent<HomeLobbyButton>();
				if(m_lobbyTabBtn != null)
				{
					m_lobbyTabBtn.transform.SetParent(a_ui_root.transform, false);
				}
			});
			AssetBundleManager.UnloadAssetBundle(_lyName, false);
			yield return null;
			while (!m_lobbyTabBtn.IsLoaded())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E2C14 Offset: 0x6E2C14 VA: 0x6E2C14
		// // RVA: 0x968A28 Offset: 0x968A28 VA: 0x968A28
		private IEnumerator Co_LoadSceneButtonData(GameObject a_ui_root)
		{
			string _lyName; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20

			//0x96ACAC
			_lyName = "ly/202.xab";
			operation = AssetBundleManager.LoadLayoutAsync(_lyName, "root_cmn_lobby_btn_layout_root");
			yield return operation;
			yield return operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x9698C4
				m_lobbySceneBtn = instance.GetComponent<HomeLobbySceneButton>();
				if(m_lobbySceneBtn != null)
				{
					m_lobbySceneBtn.transform.SetParent(a_ui_root.transform, false);
				}
			});
			AssetBundleManager.UnloadAssetBundle(_lyName, false);
			yield return null;
			while (!m_lobbySceneBtn.IsLoaded())
				yield return null;
		}

		// // RVA: 0x966B74 Offset: 0x966B74 VA: 0x966B74
		private void UpdatePresentment()
		{
			NKOBMDPHNGP_EventRaidLobby ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_EventRaidLobby;
			if(ev != null)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
                NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase phase = ev.KINIOEOOCAA_GetPhase(t);
                if (phase == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End)
				{
					m_lobbySceneBtn.SetRaidBattleHeld(HomeLobbySceneButton.eHeldType.eAfter);
					m_lobbySceneBtn.SetRaidBattleText(HomeLobbySceneButton.eHeldType.eAfter, ev.PIFFFLDOJKJ_GetDayAfter(t));
				}
				else if(phase == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.ECAAJMPLIPG_2_Now)
				{
					m_lobbySceneBtn.SetRaidBattleHeld(HomeLobbySceneButton.eHeldType.eNow);
					m_lobbySceneBtn.SetRaidBattleText(HomeLobbySceneButton.eHeldType.eNow, ev.MKACADAOPEI_GetDayNow(t));
				}
				else if(phase == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.KJNKFFJBPIH_1_Before)
				{
					m_lobbySceneBtn.SetRaidBattleHeld(HomeLobbySceneButton.eHeldType.eBefore);
					m_lobbySceneBtn.SetRaidBattleText(HomeLobbySceneButton.eHeldType.eBefore, ev.IICHMBONEIE_GetDayBefore(t));
				}
			}
		}

		// // RVA: 0x968EF8 Offset: 0x968EF8 VA: 0x968EF8
		private void OnLobbyTabButton()
		{
			if(!m_lobbyTabBtn.IsShow())
				return;
			if(TryLobbyAnnounce())
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_lobbyTabBtn.Hide(false);
			m_lobbySceneBtn.Show(false);
		}

		// // RVA: 0x9690D0 Offset: 0x9690D0 VA: 0x9690D0
		private void OnLobbySceneButtonHide()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_002);
			m_lobbyTabBtn.Show(false);
			m_lobbySceneBtn.Hide(false);
		}

		// // RVA: 0x96916C Offset: 0x96916C VA: 0x96916C
		private void OnClickChangeLobbySceneButton()
		{
			if(!m_lobbySceneBtn.IsShow())
				return;
			UpdatePresentment();
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			TransitionLobbyMain();
		}

		// // RVA: 0x967EBC Offset: 0x967EBC VA: 0x967EBC
		public static void Show_PopupNotAffiliationRaidEnd(Action transitionCallback, Action endCallback, NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase phase = NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End)
		{
			TextPopupSetting s = new TextPopupSetting();
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			if(phase == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.OLCLJKOKJCD_3_End || phase == NKOBMDPHNGP_EventRaidLobby.FIPGKDJHKCH_Phase.HJNNKCMLGFL_0)
			{
				s.TitleText = "";
				s.Text = MessageManager.Instance.GetMessage("menu", "home_lobby_button_popup_raid_end");
				s.IsCaption = false;
				PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
				{
					//0x969A34
					if(endCallback != null)
						endCallback();
				}, null, null, null, true, true, false);
			}
			else
			{
				s.TitleText = MessageManager.Instance.GetMessage("menu", "pop_not_belong_lobby_transition_title");
				s.Text = MessageManager.Instance.GetMessage("menu", "pop_not_belong_lobby_transition_desc");
				PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
				{
					//0x969A48
					if(t == PopupButton.ButtonType.Positive && transitionCallback != null)
						transitionCallback();
					if(endCallback != null)
						endCallback();
				}, null, null, null, true, true, false);
			}
		}
	}
}
