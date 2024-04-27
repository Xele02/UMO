using System.Collections;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class FriendRequestListScene : FriendListSceneBase
	{
		private static readonly SortItem[] s_sortTypeList = new SortItem[14]
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Rarity, SortItem.Level,
			SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.LastPlayDate, 
			SortItem.PlayerRunk, SortItem.Request, SortItem.HighScoreRating
		}; // 0x0

		//protected override SortItem[] sortTypeList { get; } 0xED76AC
		protected override SortItem defaultSortType { get { return SortItem.Request; } } //0xED7738
		protected override PopupSortMenu.SortPlace sortPlace { get { return PopupSortMenu.SortPlace.SentRequestList; } } //0xED7740
		protected override ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList sortSaveData { get { return GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.EJAJGGKHALM_SentRequestList; } } //0xED7748
		protected override GuestListWindow.CounterStyle listCounterSyle { get { return GuestListWindow.CounterStyle.Count; } } //0xED7830
		protected override int listCounterCount { get { return friendManager.PPCNLKHHMFK_NumSentRequest; } } //0xED7838
		//protected override bool listCounterLimitOver { get; } 0xED786C
		protected override string cautionMessage { get { return MessageManager.Instance.GetMessage("menu", "friend_caution_request"); } } //0xED78A0

		// RVA: 0xED793C Offset: 0xED793C VA: 0xED793C Slot: 41
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
			friendNotFoundMessage = bk.GetMessageByLabel("friend_request_not_found");
			friendAllFilteredMessage = "";
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetButtonStyle(FriendListElem.ButtonStyle.RequestList);
			}
			InitializeStatusChange();
			if(CheckTransitByReturn())
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

		// RVA: 0xED8038 Offset: 0xED8038 VA: 0xED8038 Slot: 42
		protected override void Release()
		{
			ReleaseDecos();
		}

		//// RVA: 0xED8040 Offset: 0xED8040 VA: 0xED8040
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			if(value != 3)
			{
				if (value != 1)
					return;
				ShowFriendRequestCancelPopup(m_friendInfoList[content.Index]);
			}
			else
			{
				JumpToProfile(m_friendInfoList[content.Index].friend, ProfilMenuLayout.ButtonType.None);
			}
		}

		//// RVA: 0xED7E5C Offset: 0xED7E5C VA: 0xED7E5C
		private void SearchFriend()
		{
			friends.Clear();
			m_windowUi.SetMessageVisible(false);
			MenuScene.Instance.RaycastDisable();
			ConnectStart();
			friendManager.GJODIMMDJHJ(() =>
			{
				//0xED82A4
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
				//0xED843C
				ConnectEnd();
				MenuScene.Instance.RaycastEnable();
			}, (CACGCMBKHDI_Request error) =>
			{
				//0xED84E8
				ConnectEnd();
				NetErrorToTitle();
				MenuScene.Instance.RaycastEnable();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E04A4 Offset: 0x6E04A4 VA: 0x6E04A4
		//// RVA: 0xED8130 Offset: 0xED8130 VA: 0xED8130
		private IEnumerator OnSuccessSearchFriend()
		{
			//0xED85A4
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

		// RVA: 0xED81DC Offset: 0xED81DC VA: 0xED81DC Slot: 44
		protected override void OnNetRequestSuccess()
		{
			if (lastNetType != NetType.FriendRequestCancel)
				return;
			SearchFriend();
		}
	}
}
