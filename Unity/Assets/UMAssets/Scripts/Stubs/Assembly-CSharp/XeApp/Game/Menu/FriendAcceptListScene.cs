using System.Collections;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class FriendAcceptListScene : FriendListSceneBase
	{
		private static readonly SortItem[] s_sortTypeList = new SortItem[14]
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm,
			SortItem.Rarity, SortItem.Level, SortItem.Life, SortItem.Support,
			SortItem.Fold, SortItem.Luck, SortItem.LastPlayDate, SortItem.PlayerRunk,
			SortItem.Request, SortItem.HighScoreRating
		}; // 0x0

		//protected override SortItem[] sortTypeList { get; } 0xBA18EC
		protected override SortItem defaultSortType { get { return SortItem.Request; } } //0xBA1978
		protected override PopupSortMenu.SortPlace sortPlace { get { return PopupSortMenu.SortPlace.PendingList; } } //0xBA1980
		protected override ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList sortSaveData { get { return GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.DOKBEPGKNJK_PendingList; } } //0xBA1988
		protected override GuestListWindow.CounterStyle listCounterSyle { get { return GuestListWindow.CounterStyle.Count; } } //0xBA1A70
		protected override int listCounterCount { get { return friendManager.LIEOOJCODFH_NumFriendRequest; } } //0xBA1A78
		//protected override bool listCounterLimitOver { get; } 0xBA1B44
		protected override string cautionMessage { get { return MessageManager.Instance.GetMessage("menu", "friend_caution_request"); } } //0xBA1B74

		// RVA: 0xBA1C10 Offset: 0xBA1C10 VA: 0xBA1C10 Slot: 41
		protected override void Initialize()
		{
			InitializeDecos();
			InitializeSortSetting();
			m_buttonRuntime.ChangePreset(GeneralListButtonRuntime.Preset.FriendList);
			m_buttonRuntime.onClickSortButton = OnClickSortButton;
			m_buttonRuntime.onClickOrderButton = OnClickOrderButton;
			OnChangeSortType();
			OnChangeSortOrder();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_windowUi.SetMessageVisible(false);
			friendNotFoundMessage = bk.GetMessageByLabel("friend_accept_not_found");
			friendAllFilteredMessage = "";
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetButtonStyle(FriendListElem.ButtonStyle.AcceptList);
			}
			InitializeStatusChange();
			if(PrevTransition == TransitionList.Type.PROFIL)
			{
				m_scrollList.VisibleRegionUpdate();
				UpdateListCounter();
			}
			else
			{
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
				SearchFriend();
			}
		}

		// RVA: 0xBA2E58 Offset: 0xBA2E58 VA: 0xBA2E58 Slot: 42
		protected override void Release()
		{
			ReleaseDecos();
		}

		//// RVA: 0xBA3000 Offset: 0xBA3000 VA: 0xBA3000
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			if(value != 3)
			{
				if(value == 1)
				{
					ShowFriendRejectPopup(m_friendInfoList[content.Index]);
				}
				else if(value == 0)
				{
					ShowFriendAcceptPopup(m_friendInfoList[content.Index]);
				}
			}
			else
			{
				JumpToProfile(m_friendInfoList[content.Index].friend, ProfilMenuLayout.ButtonType.None);
			}
		}

		//// RVA: 0xBA2C84 Offset: 0xBA2C84 VA: 0xBA2C84
		private void SearchFriend()
		{
			friends.Clear();
			m_windowUi.SetMessageVisible(false);
			MenuScene.Instance.RaycastDisable();
			ConnectStart();
			friendManager.IJGADKKPAGJ(() =>
			{
				//0xBA3D80
				ConnectEnd();
				for(int i = 0; i < friendManager.BFDEHIANFOG.Count; i++)
				{
					EAJCBFGKKFA_FriendInfo f = new EAJCBFGKKFA_FriendInfo();
					f.KHEKNNFCAOI(friendManager.BFDEHIANFOG[i]);
					friends.Add(f);
				}
				this.StartCoroutineWatched(OnSuccessSearchFriend());
			}, (CACGCMBKHDI_Request error) =>
			{
				//0xBA3F28
				ConnectEnd();
				MenuScene.Instance.RaycastEnable();
			}, (CACGCMBKHDI_Request error) =>
			{
				//0xBA3FD8
				ConnectEnd();
				NetErrorToTitle();
				MenuScene.Instance.RaycastEnable();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DFC84 Offset: 0x6DFC84 VA: 0x6DFC84
		//// RVA: 0xBA3A80 Offset: 0xBA3A80 VA: 0xBA3A80
		private IEnumerator OnSuccessSearchFriend()
		{
			//0xBA41A0
			m_friendInfoAllList.Clear();
			for(int i = 0; i < friends.Count; i++)
			{
				FriendListInfo f = new FriendListInfo((short)i, true, friends[i]);
				m_friendInfoAllList.Add(f);
				f.TryInstall();
			}
			yield return null;
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			SortFriendList();
			UpdateListCounter();
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xBA3B2C Offset: 0xBA3B2C VA: 0xBA3B2C Slot: 44
		protected override void OnNetRequestSuccess()
		{
			if(((int)lastNetType & 0xfffffffe) != 2)
				return;
			SearchFriend();
		}
	}
}
