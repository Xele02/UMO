using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using System;
using System.Collections;

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
			UnityEngine.Debug.LogError("TODO LobbyButton Co_LoadLayout");
			yield break;
		}

		// RVA: 0x9667E8 Offset: 0x9667E8 VA: 0x9667E8
		public void Setup(HomeLobbyButtonController.Type a_type = Type.DOWN)
		{
			UnityEngine.Debug.LogError("TODO LobbyButton Setup");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E2944 Offset: 0x6E2944 VA: 0x6E2944
		// // RVA: 0x967008 Offset: 0x967008 VA: 0x967008
		public IEnumerator Co_CheckNewMark(Action OnError)
		{
			UnityEngine.Debug.LogError("TODO LobbyButton Co_CheckNewMark");
			yield break;
		}

		// // RVA: 0x966FCC Offset: 0x966FCC VA: 0x966FCC
		// public void Show(bool isEnd = False) { }

		// // RVA: 0x9670D0 Offset: 0x9670D0 VA: 0x9670D0
		public void Hide(bool isEnd = false)
		{
			UnityEngine.Debug.LogError("TODO LobbyButton Hide");
		}

		// // RVA: 0x967244 Offset: 0x967244 VA: 0x967244
		// public void Wait() { }

		// // RVA: 0x967298 Offset: 0x967298 VA: 0x967298
		// public void EnableButton(bool a_enable) { }

		// // RVA: 0x966F30 Offset: 0x966F30 VA: 0x966F30
		// public void SetAsLastSibling() { }

		// // RVA: 0x9673B8 Offset: 0x9673B8 VA: 0x9673B8
		// public void TransitionLobbyMain() { }

		// // RVA: 0x9682F0 Offset: 0x9682F0 VA: 0x9682F0
		public void RequestInitRaidLobby(IMCBBOAFION onSuccess, DJBHIFLHJLK onErrorToTitle)
		{
			UnityEngine.Debug.LogError("TODO LobbyButton RequestInitRaidLobby");
			onSuccess();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E29BC Offset: 0x6E29BC VA: 0x6E29BC
		// // RVA: 0x968314 Offset: 0x968314 VA: 0x968314
		// public IEnumerator InitRaidLobby(IMCBBOAFION onSuccess, DJBHIFLHJLK onErrorToTitle) { }

		// // RVA: 0x9683DC Offset: 0x9683DC VA: 0x9683DC
		public bool CheckLobbyAnnounce()
		{
			UnityEngine.Debug.LogError("TODO CheckLobbyAnnounce");
			return false;
		}

		// // RVA: 0x9686FC Offset: 0x9686FC VA: 0x9686FC
		// public bool TryLobbyAnnounce() { }

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
		// private IEnumerator Co_LoadTabButtonData(GameObject a_ui_root) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E2C14 Offset: 0x6E2C14 VA: 0x6E2C14
		// // RVA: 0x968A28 Offset: 0x968A28 VA: 0x968A28
		// private IEnumerator Co_LoadSceneButtonData(GameObject a_ui_root) { }

		// // RVA: 0x966B74 Offset: 0x966B74 VA: 0x966B74
		// private void UpdatePresentment() { }

		// // RVA: 0x968EF8 Offset: 0x968EF8 VA: 0x968EF8
		// private void OnLobbyTabButton() { }

		// // RVA: 0x9690D0 Offset: 0x9690D0 VA: 0x9690D0
		// private void OnLobbySceneButtonHide() { }

		// // RVA: 0x96916C Offset: 0x96916C VA: 0x96916C
		// private void OnClickChangeLobbySceneButton() { }

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
