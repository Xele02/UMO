using System;
using System.Collections;
using System.Text;
using mcrs;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class FriendMenuScene : TransitionRoot
	{
		private FriendMenuRuntime m_menuUi; // 0x48
		private StringBuilder m_stringBuilder = new StringBuilder(32); // 0x4C
		private bool m_isInitialized; // 0x50

		// RVA: 0xED58FC Offset: 0xED58FC VA: 0xED58FC Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0xED59B8 Offset: 0xED59B8 VA: 0xED59B8 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_menuUi.Hide();
			Initialize();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.PNNHEOOJBFI_TutorialGeneralFlags.EDEDFDDIOKO_SetTrue(1);
		}

		// RVA: 0xED5CA0 Offset: 0xED5CA0 VA: 0xED5CA0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_isInitialized && base.IsEndPreSetCanvas();
		}

		// RVA: 0xED5CB8 Offset: 0xED5CB8 VA: 0xED5CB8 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{ 
			m_menuUi.transform.SetAsLastSibling();
			return base.IsEndPostSetCanvas();
		}

		// RVA: 0xED5D14 Offset: 0xED5D14 VA: 0xED5D14 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_menuUi.Enter();
		}

		// RVA: 0xED5D3C Offset: 0xED5D3C VA: 0xED5D3C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_menuUi.IsPlaying() && base.IsEndEnterAnimation();
		}

		// RVA: 0xED5D80 Offset: 0xED5D80 VA: 0xED5D80 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_menuUi.Leave();
		}

		// RVA: 0xED5DA8 Offset: 0xED5DA8 VA: 0xED5DA8 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_menuUi.IsPlaying() && base.IsEndExitAnimation();
		}

		// RVA: 0xED5DEC Offset: 0xED5DEC VA: 0xED5DEC Slot: 14
		protected override void OnDestoryScene()
		{
			return;
		}

		// // RVA: 0xED5AF4 Offset: 0xED5AF4 VA: 0xED5AF4
		private void Initialize()
		{
			m_isInitialized = false;
			m_menuUi.onClickFriendListButton = OnClickFriendList;
			m_menuUi.onClickRequestListButton = OnClickRequestList;
			m_menuUi.onClickAcceptListButton = OnClickAcceptList;
			m_menuUi.onClickFriendSearchButton = OnClickPlayerSearch;
			this.StartCoroutineWatched(Co_SearchFriend());
		}

		// // RVA: 0xED5DF0 Offset: 0xED5DF0 VA: 0xED5DF0
		// private void Release() { }

		// // RVA: 0xED5DF4 Offset: 0xED5DF4 VA: 0xED5DF4
		// private void SearchFriend() { }

		// // RVA: 0xED5EA4 Offset: 0xED5EA4 VA: 0xED5EA4
		private void OnClickFriendList()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Call(TransitionList.Type.FRIEND_LIST, null, true);
		}

		// // RVA: 0xED5FA4 Offset: 0xED5FA4 VA: 0xED5FA4
		private void OnClickRequestList()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Call(TransitionList.Type.FRIEND_REQUEST_LIST, null, true);
		}

		// // RVA: 0xED60A4 Offset: 0xED60A4 VA: 0xED60A4
		private void OnClickAcceptList()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Call(TransitionList.Type.FRIEND_ACCEPT_LIST, null, true);
		}

		// // RVA: 0xED61A4 Offset: 0xED61A4 VA: 0xED61A4
		private void OnClickPlayerSearch()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Call(TransitionList.Type.FRIEND_SEARCH, null, true);
		}

		// // RVA: 0xED62A4 Offset: 0xED62A4 VA: 0xED62A4
		private void OnNetRequestError(CACGCMBKHDI_Request error)
		{
			return;
		}

		// // RVA: 0xED62A8 Offset: 0xED62A8 VA: 0xED62A8
		private void OnNetRequestErrorToTitle(CACGCMBKHDI_Request error)
		{
			if(MenuScene.Instance.IsTransition())
				GotoTitle();
			else
				MenuScene.Instance.GotoTitle();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DC3AC Offset: 0x6DC3AC VA: 0x6DC3AC
		// // RVA: 0xED592C Offset: 0xED592C VA: 0xED592C
		private IEnumerator Co_LoadResources()
		{
			//0xED69CC
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DC424 Offset: 0x6DC424 VA: 0x6DC424
		// // RVA: 0xED63D4 Offset: 0xED63D4 VA: 0xED63D4
		private IEnumerator Co_LoadLayout()
		{
			Font font; // 0x14
			string bundleName; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C

			//0xED66A0
			font = GameManager.Instance.GetSystemFont();
			bundleName = "ly/054.xab";
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "UI_FriendMenu");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xED65CC
				instance.transform.SetParent(transform, false);
				m_menuUi = instance.GetComponent<FriendMenuRuntime>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while(!m_menuUi.IsLoaded())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DC49C Offset: 0x6DC49C VA: 0x6DC49C
		// // RVA: 0xED5E18 Offset: 0xED5E18 VA: 0xED5E18
		private IEnumerator Co_SearchFriend()
		{
			PIGBKEIAMPE_FriendManager friendManager;

			//0xED6AF4
			MenuScene.Instance.InputDisable();
			m_menuUi.SetupFriendList("", "", true, "");
			m_menuUi.SetupRequestList("");
			m_menuUi.SetupAcceptlList("", true, "");
			friendManager = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager;
			friendManager.POEDEMPINCH(null, OnNetRequestError, OnNetRequestErrorToTitle);
			yield return this.StartCoroutineWatched(Co_WaitForConnection(null));
			friendManager.HHDGOABFEPC_GetFriendLimit(null, OnNetRequestErrorToTitle, false);
			yield return this.StartCoroutineWatched(Co_WaitForConnection(null));
			m_stringBuilder.SetFormat("/{0}", friendManager.JPEIBHJIHPI_FriendLimit);
			m_menuUi.SetupFriendList(friendManager.AIIOKIHEPDP_FriendCount.ToString(), m_stringBuilder.ToString(), true, friendManager.NMOJPDCBGMK_NumFriendNoFav.ToString());
			friendManager.MEJHFCBFPED_GetSentRequests(null, OnNetRequestErrorToTitle, false);
			yield return this.StartCoroutineWatched(Co_WaitForConnection(null));
			if(friendManager.EMBDPGBMCBF_HasMoreSentRequest)
			{
				m_stringBuilder.SetFormat("<color={0}>{1}+</color>", SystemTextColor.ImportantColor, friendManager.PPCNLKHHMFK_NumSentRequest);
			}
			else
			{
				m_stringBuilder.SetFormat("{0}", friendManager.PPCNLKHHMFK_NumSentRequest);
			}
			m_menuUi.SetupRequestList(m_stringBuilder.ToString());
			friendManager.PFJBNPIBFMO_GetReceivedRequests(null, OnNetRequestErrorToTitle, false);
			yield return this.StartCoroutineWatched(Co_WaitForConnection(null));
			if(friendManager.BKEOKNIEHII_HasMoreReceivedRequest)
			{
				m_stringBuilder.SetFormat("<color={0}>{1}+</color>", SystemTextColor.ImportantColor, friendManager.LIEOOJCODFH_NumFriendRequest);
			}
			else
			{
				m_stringBuilder.SetFormat("{0}", friendManager.LIEOOJCODFH_NumFriendRequest);
			}
			m_menuUi.SetupAcceptlList(m_stringBuilder.ToString(), true, friendManager.JCOBBOMCENL_NumNewRequests.ToString());
			MenuScene.Instance.InputEnable();
			m_isInitialized = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DC514 Offset: 0x6DC514 VA: 0x6DC514
		// // RVA: 0xED64A0 Offset: 0xED64A0 VA: 0xED64A0
		private IEnumerator Co_WaitForConnection(Action onEnd)
		{
			PIGBKEIAMPE_FriendManager friendManager;

			//0xED74E4
			friendManager = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager;
			while(!friendManager.PLOOEECNHFB_IsDone)
				yield return null;
			if(onEnd != null)
				onEnd();
		}
	}
}
