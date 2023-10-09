using mcrs;
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class FriendSearchScene : FriendListSceneBase
	{
		private int m_myId = -1; // 0xA8
		private int m_searchId = -1; // 0xAC
		private bool m_isWaitPreSetCanvas; // 0xB0
		private PlayerSearchPopupSetting m_searchIdPopupSetting = new PlayerSearchPopupSetting(); // 0xB4

		//private bool IsDecoVisit { get; } 0xED8934
		//protected override SortItem[] sortTypeList { get; } 0xED8958
		//protected override SortItem defaultSortType { get; } 0xED89E0
		//protected override PopupSortMenu.SortPlace sortPlace { get; } 0xED8A68
		//protected override ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH sortSaveData { get; } 0xED8AF0
		protected override GuestListWindow.CounterStyle listCounterSyle { get { return GuestListWindow.CounterStyle.None; } } //0xED8B78
		protected override bool emptyButtonLock { get { return false; } } //0xED8B80

		// RVA: 0xED8B88 Offset: 0xED8B88 VA: 0xED8B88 Slot: 41
		protected override void Initialize()
		{
			InitializeDecos();
			m_buttonRuntime.ChangePreset(GeneralListButtonRuntime.Preset.FriendSearch);
			m_buttonRuntime.onClickSearchButton = OnClickSearchButton;
			m_isWaitPreSetCanvas = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_windowUi.SetMessageVisible(false);
			m_windowUi.SetCounterStyle(listCounterSyle);
			friendNotFoundMessage = bk.GetMessageByLabel("friend_search_not_found");
			friendAllFilteredMessage = "";
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetButtonStyle(ParentTransition == TransitionList.Type.DECO ? FriendListElem.ButtonStyle.PlayerSearchDecoVisit : FriendListElem.ButtonStyle.PlayerSearch);
			}
			if(CheckTransitByReturn())
			{
				InitializeStatusChange();
				m_scrollList.VisibleRegionUpdate();
				UpdateListCounter();
			}
			else
			{
				m_windowUi.SetMessageVisible(true);
				m_windowUi.SetMessage(bk.GetMessageByLabel("friend_search_ready"));
				InitializeStatusChange();
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
				m_searchId = -1;
				if (ParentTransition == TransitionList.Type.DECO)
					this.StartCoroutineWatched(Co_ReceiveFriendPlayerIdList());
			}
			m_myId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
		}

		// RVA: 0xED9234 Offset: 0xED9234 VA: 0xED9234 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !m_isWaitPreSetCanvas && base.IsEndPreSetCanvas();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E059C Offset: 0x6E059C VA: 0x6E059C
		//// RVA: 0xED91A8 Offset: 0xED91A8 VA: 0xED91A8
		private IEnumerator Co_ReceiveFriendPlayerIdList()
		{
			TodoLogger.LogError(0, "Co_ReceiveFriendPlayerIdList");
			yield return null;
		}

		// RVA: 0xED926C Offset: 0xED926C VA: 0xED926C Slot: 42
		protected override void Release()
		{
			ReleaseDecos();
		}

		//// RVA: 0xED9274 Offset: 0xED9274 VA: 0xED9274
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			FriendListInfo info = m_friendInfoList[content.Index];
			if (value == 3)
				JumpToProfile(info.friend, ParentTransition == TransitionList.Type.DECO ? ProfilMenuLayout.ButtonType.Fan : ProfilMenuLayout.ButtonType.None);
			else if(value == 0)
			{
				if (ParentTransition == TransitionList.Type.DECO)
					Visit(info);
				else
					ShowFriendRequestPopup(info);
			}
		}

		//// RVA: 0xED93A0 Offset: 0xED93A0 VA: 0xED93A0
		protected void Visit(FriendListInfo info)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			VisitDecoSceneArgs arg = new VisitDecoSceneArgs();
			arg.friendData = info.friend;
			if(friendManager.PDEACDHIJJJ_IsFriend(arg.friendData.MLPEHNBNOGD_Id))
			{
				arg.friendData.PCEGKKLKFNO.LHMDABPNDDH_Type = IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend;
				arg.friendData.PDIPANKOKOL_FriendType = IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend;
			}
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_16095, info.playerId);
			ILCCJNDFFOB.HHCJCDFCLOB.PFBIHCIFFKM(arg.friendData.MLPEHNBNOGD_Id, friendManager.PDEACDHIJJJ_IsFriend(arg.friendData.MLPEHNBNOGD_Id), true, 0);
			MenuScene.Instance.MountWithFade(TransitionUniqueId.DECO_DECOVISIT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		//// RVA: 0xED9694 Offset: 0xED9694 VA: 0xED9694
		//private void OnClickPopupCopyButton(string myId) { }

		//// RVA: 0xED991C Offset: 0xED991C VA: 0xED991C
		//private void OnClickPopupSearchButton(string searchId) { }

		//// RVA: 0xED9A54 Offset: 0xED9A54 VA: 0xED9A54
		private void OnClickSearchButton()
		{
			TodoLogger.LogNotImplemented("OnClickSearchButton");
		}

		//// RVA: 0xED9EC0 Offset: 0xED9EC0 VA: 0xED9EC0
		//private void SearchFriend(int searchId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E0614 Offset: 0x6E0614 VA: 0x6E0614
		//// RVA: 0xEDA0A0 Offset: 0xEDA0A0 VA: 0xEDA0A0
		//private IEnumerator OnSuccessSearchFriend() { }

		//// RVA: 0xEDA14C Offset: 0xEDA14C VA: 0xEDA14C
		//private void OnFailedSearchFriend() { }

		//// RVA: 0xED9A58 Offset: 0xED9A58 VA: 0xED9A58
		//private void ShowFriendSearchPopup() { }

		//// RVA: 0xEDA3C8 Offset: 0xEDA3C8 VA: 0xEDA3C8
		//private void ShowSearchingMySelfPopup() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E068C Offset: 0x6E068C VA: 0x6E068C
		// RVA: 0xEDA644 Offset: 0xEDA644 VA: 0xEDA644 Slot: 43
		protected override IEnumerator Co_LoadBothLayout(string bundleName)
		{
			int bundleLoadCount;
			Font font;
			AssetBundleLoadLayoutOperationBase operation;

			//0xEDAB98
			bundleLoadCount = 0;
			font = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(m_searchIdPopupSetting.BundleName, m_searchIdPopupSetting.AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xEDAAFC
				m_searchIdPopupSetting.SetContent(instance);
				m_searchIdPopupSetting.SetParent(transform);
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
		}

		//// RVA: 0xEDA70C Offset: 0xEDA70C VA: 0xEDA70C Slot: 44
		//protected override void OnNetRequestSuccess() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E0704 Offset: 0x6E0704 VA: 0x6E0704
		//// RVA: 0xEDA79C Offset: 0xEDA79C VA: 0xEDA79C
		//private void <OnClickPopupSearchButton>b__25_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E0714 Offset: 0x6E0714 VA: 0x6E0714
		//// RVA: 0xEDA804 Offset: 0xEDA804 VA: 0xEDA804
		//private void <SearchFriend>b__27_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E0724 Offset: 0x6E0724 VA: 0x6E0724
		//// RVA: 0xEDA99C Offset: 0xEDA99C VA: 0xEDA99C
		//private void <SearchFriend>b__27_1(CACGCMBKHDI error) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E0734 Offset: 0x6E0734 VA: 0x6E0734
		//// RVA: 0xEDAA50 Offset: 0xEDAA50 VA: 0xEDAA50
		//private void <SearchFriend>b__27_2(CACGCMBKHDI error) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E0744 Offset: 0x6E0744 VA: 0x6E0744
		//// RVA: 0xEDAA74 Offset: 0xEDAA74 VA: 0xEDAA74
		//private void <OnFailedSearchFriend>b__29_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E0754 Offset: 0x6E0754 VA: 0x6E0754
		//// RVA: 0xEDAAF8 Offset: 0xEDAAF8 VA: 0xEDAAF8
		//private void <ShowSearchingMySelfPopup>b__31_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }
	}
}
