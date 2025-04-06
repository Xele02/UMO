using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using System;
using System.Collections;
using XeApp.Core;

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
		// private HomeLobbyAnnounce m_layoutLobbyAnnounce; // 0x2C
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
				IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
				if(ev != null)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LobbyButton Setup Event");
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
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LobbyButton Co_CheckNewMark");
			}
			t_raid_lobby_ctrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_EventRaidLobby;
			if(t_raid_lobby_ctrl != null)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LobbyButton Co_CheckNewMark 2");
			}
			t_raid_lobby_ctrl = null;
			if(t_raid_ctrl != null && t_raid_lobby_ctrl != null)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LobbyButton Co_CheckNewMark 3");
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
		// public void SetAsLastSibling() { }

		// // RVA: 0x9673B8 Offset: 0x9673B8 VA: 0x9673B8
		public void TransitionLobbyMain()
		{
			if(!m_IsInitialize)
				return;
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LobbyButton TransitionLobbyMain");
		}

		// // RVA: 0x9682F0 Offset: 0x9682F0 VA: 0x9682F0
		public void RequestInitRaidLobby(IMCBBOAFION onSuccess, DJBHIFLHJLK onErrorToTitle)
		{
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LobbyButton RequestInitRaidLobby");
			onSuccess();
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
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "InitRaidLobby");
		}

		// // RVA: 0x9683DC Offset: 0x9683DC VA: 0x9683DC
		public bool CheckLobbyAnnounce()
		{
			if (!m_IsInitialize)
				return false;
			if(!GameManager.Instance.IsTutorial && m_coroutine == null)
			{
				IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
				if(ev != null)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event CheckLobbyAnnounce");
				}
			}
			return false;
		}

		// // RVA: 0x9686FC Offset: 0x9686FC VA: 0x9686FC
		public bool TryLobbyAnnounce()
		{
			if(!CheckLobbyAnnounce())
				return false;
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "TryLobbyAnnounce");
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E2A34 Offset: 0x6E2A34 VA: 0x6E2A34
		// // RVA: 0x968740 Offset: 0x968740 VA: 0x968740
		// private IEnumerator Co_LobbyAnnounce() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E2AAC Offset: 0x6E2AAC VA: 0x6E2AAC
		// // RVA: 0x9687EC Offset: 0x9687EC VA: 0x9687EC
		// private IEnumerator Co_ShowTutorial_81() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E2B24 Offset: 0x6E2B24 VA: 0x6E2B24
		// // RVA: 0x968880 Offset: 0x968880 VA: 0x968880
		// private IEnumerator Co_LoadLobbyAnnounce(NKOBMDPHNGP.FIPGKDJHKCH phase, Transform parent) { }

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
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
			if(ev != null)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "UpdatePresentment event");
			}
		}

		// // RVA: 0x968EF8 Offset: 0x968EF8 VA: 0x968EF8
		private void OnLobbyTabButton()
		{
			TodoLogger.LogNotImplemented("HomeLobbyButtonController.OnLobbyTabButton");
		}

		// // RVA: 0x9690D0 Offset: 0x9690D0 VA: 0x9690D0
		private void OnLobbySceneButtonHide()
		{
			TodoLogger.LogNotImplemented("HomeLobbyButtonController.OnLobbySceneButtonHide");
		}

		// // RVA: 0x96916C Offset: 0x96916C VA: 0x96916C
		private void OnClickChangeLobbySceneButton()
		{
			TodoLogger.LogNotImplemented("HomeLobbyButtonController.OnClickChangeLobbySceneButton");
		}

		// // RVA: 0x967EBC Offset: 0x967EBC VA: 0x967EBC
		// public static void Show_PopupNotAffiliationRaidEnd(Action transitionCallback, Action endCallback, NKOBMDPHNGP.FIPGKDJHKCH phase = 3) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6E2C8C Offset: 0x6E2C8C VA: 0x6E2C8C
		// // RVA: 0x969294 Offset: 0x969294 VA: 0x969294
		// private void <TransitionLobbyMain>b__23_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6E2C9C Offset: 0x6E2C9C VA: 0x6E2C9C
		// // RVA: 0x96929C Offset: 0x96929C VA: 0x96929C
		// private void <TransitionLobbyMain>b__23_0() { }
	}
}
