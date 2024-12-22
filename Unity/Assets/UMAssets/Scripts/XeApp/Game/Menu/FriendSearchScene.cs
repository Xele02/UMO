using mcrs;
using System;
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
		protected override SortItem defaultSortType { get { new NotImplementedException(); return SortItem.None; } } //0xED89E0
		protected override PopupSortMenu.SortPlace sortPlace { get { new NotImplementedException(); return PopupSortMenu.SortPlace.None; } } //0xED8A68
		protected override ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList sortSaveData { get { new NotImplementedException(); return null; } } //0xED8AF0
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
			//0xEDAECC
			bool isDone = false;
			bool isError = false;
			m_isWaitPreSetCanvas = true;
			friendManager.CKJHFFHFPLH_GetFriends(() =>
			{
				//0xEDAB70
				isDone = true;
			}, (CACGCMBKHDI_Request action) =>
			{
				//0xEDAB7C
				isDone = true;
				isError = true;
			}, (CACGCMBKHDI_Request action) =>
			{
				//0xEDAB88
				isDone = true;
				isError = true;
			});
			while (!isDone)
				yield return null;
			m_isWaitPreSetCanvas = false;
			if (isError)
				GotoTitle();
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
		private void OnClickPopupCopyButton(string myId)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			ClipboardSupport.CopyText(myId);
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_myid_copy_title"), SizeType.Small, bk.GetMessageByLabel("popup_myid_copy_msg"), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true), null, null, null, null);
		}

		//// RVA: 0xED991C Offset: 0xED991C VA: 0xED991C
		private void OnClickPopupSearchButton(string searchId)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(int.TryParse(searchId, out m_searchId))
			{
				PopupWindowManager.Close(null, () =>
				{
					//0xEDA79C
					if(m_searchId == m_myId)
					{
						m_buttonRuntime.SetReloadButtonLock(true);
						ShowSearchingMySelfPopup();
					}
					else
					{
						m_buttonRuntime.SetReloadButtonLock(false);
						SearchFriend(m_searchId);
					}
				});
			}
			else
			{
				m_searchId = -1;
			}
		}

		//// RVA: 0xED9A54 Offset: 0xED9A54 VA: 0xED9A54
		private void OnClickSearchButton()
		{
			ShowFriendSearchPopup();
		}

		//// RVA: 0xED9EC0 Offset: 0xED9EC0 VA: 0xED9EC0
		private void SearchFriend(int searchId)
		{
			MenuScene.Instance.InputDisable();
			friends.Clear();
			m_windowUi.SetMessageVisible(false);
			ConnectStart();
			friendManager.LJMOBJNEHPM(searchId, () =>
			{
				//0xEDA804
				ConnectEnd();
				for(int i = 0; i < friendManager.BFDEHIANFOG.Count; i++)
				{
					EAJCBFGKKFA_FriendInfo data = new EAJCBFGKKFA_FriendInfo();
					data.KHEKNNFCAOI(friendManager.BFDEHIANFOG[i]);
					friends.Add(data);
				}
				this.StartCoroutineWatched(OnSuccessSearchFriend());
			}, (CACGCMBKHDI_Request error) =>
			{
				//0xEDA99C
				ConnectEnd();
				OnFailedSearchFriend();
				MenuScene.Instance.InputEnable();
			}, (CACGCMBKHDI_Request error) =>
			{
				//0xEDAA50
				ConnectEnd();
				NetErrorToTitle();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E0614 Offset: 0x6E0614 VA: 0x6E0614
		//// RVA: 0xEDA0A0 Offset: 0xEDA0A0 VA: 0xEDA0A0
		private IEnumerator OnSuccessSearchFriend()
		{
			//0xEDB1E0
			m_friendInfoAllList.Clear();
			for(int i = 0; i < friends.Count; i++)
			{
				FriendListInfo info = new FriendListInfo((short)i, true, friends[i]);
				if(ParentTransition == TransitionList.Type.DECO)
				{
					if(friendManager.AONMOEOHFGP_TargetPlayerIds != null)
					{
						if(friendManager.PDEACDHIJJJ_IsFriend(info.playerId))
						{
							info.friend.PDIPANKOKOL_FriendType = IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend;
						}
					}
				}
				m_friendInfoAllList.Add(info);
				info.TryInstall();
			}
			yield return null;
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			SortFriendList();
			m_searchId = -1;
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0xEDA14C Offset: 0xEDA14C VA: 0xEDA14C
		private void OnFailedSearchFriend()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(
				bk.GetMessageByLabel("popup_friend_search_not_found_title"), SizeType.Small, 
				bk.GetMessageByLabel("popup_friend_search_not_found_msg"), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				}, false, true
			), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xEDAA74
				m_friendInfoAllList.Clear();
				SortFriendList();
			}, null, null, null);
		}

		//// RVA: 0xED9A58 Offset: 0xED9A58 VA: 0xED9A58
		private void ShowFriendSearchPopup()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_searchIdPopupSetting.TitleText = bk.GetMessageByLabel("popup_friend_search_title");
			m_searchIdPopupSetting.SetParent(transform);
			m_searchIdPopupSetting.WindowSize = SizeType.Middle;
			m_searchIdPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			m_searchIdPopupSetting.myId = m_myId.ToString();
			if (m_searchId < 0)
			{
				m_searchIdPopupSetting.friendId = "";
			}
			else
			{
				m_searchIdPopupSetting.friendId = m_searchId.ToString();
			}
			m_searchIdPopupSetting.friendIdPlaceholder = bk.GetMessageByLabel("popup_friend_search_placeholder");
			m_searchIdPopupSetting.onClickCopyButton = OnClickPopupCopyButton;
			m_searchIdPopupSetting.onClickSearchButton = OnClickPopupSearchButton;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			PopupWindowManager.Show(m_searchIdPopupSetting, null, null, null, null);
		}

		//// RVA: 0xEDA3C8 Offset: 0xEDA3C8 VA: 0xEDA3C8
		private void ShowSearchingMySelfPopup()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_friend_search_myself_title"), SizeType.Small, bk.GetMessageByLabel("popup_friend_search_myself_msg"), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Negative }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xEDAAF8
					ShowFriendSearchPopup();
				}, null, null, null);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E068C Offset: 0x6E068C VA: 0x6E068C
		// RVA: 0xEDA644 Offset: 0xEDA644 VA: 0xEDA644 Slot: 43
		protected override IEnumerator Co_LoadBothLayout(string bundleName)
		{
			int bundleLoadCount;
			XeSys.FontInfo font;
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
		protected override void OnNetRequestSuccess()
		{
			//lastNetType
		}
	}
}
