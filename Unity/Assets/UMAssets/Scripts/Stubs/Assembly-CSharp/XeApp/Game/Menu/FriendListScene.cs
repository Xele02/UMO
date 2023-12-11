using System.Collections;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class FriendListScene : FriendListSceneBase
	{
		private static readonly SortItem[] s_sortTypeList = new SortItem[12]
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Rarity, SortItem.Level,
			SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.LastPlayDate, SortItem.PlayerRunk
		}; // 0x0

		//protected override SortItem[] sortTypeList { get; } 0xBAA838
		protected override SortItem defaultSortType { get { return SortItem.LastPlayDate; } } //0xBAA8C4
		protected override PopupSortMenu.SortPlace sortPlace { get { return PopupSortMenu.SortPlace.FriendList; } } //0xBAA8CC
		protected override ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList sortSaveData { get { return GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.IDFGCPNELIA_FriendList; } } //0xBAA8D4
		protected override GuestListWindow.CounterStyle listCounterSyle { get { return GuestListWindow.CounterStyle.Fraction; } } //0xBAA9BC
		protected override int listCounterCount { get { return friendManager.AIIOKIHEPDP_FriendCount; } } //0xBAA9C4
		protected override int listCounterMax { get { return friendManager.JPEIBHJIHPI_FriendLimit; } } //0xBAA9F4

		// RVA: 0xBAAA24 Offset: 0xBAAA24 VA: 0xBAAA24 Slot: 41
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
			friendNotFoundMessage = bk.GetMessageByLabel("friend_list_not_found");
			friendAllFilteredMessage = "";
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetButtonStyle(FriendListElem.ButtonStyle.FriendList);
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

		// RVA: 0xBAB0E8 Offset: 0xBAB0E8 VA: 0xBAB0E8 Slot: 42
		protected override void Release()
		{
			ReleaseDecos();
		}

		//// RVA: 0xBAB0EC Offset: 0xBAB0EC VA: 0xBAB0EC
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			if(value != 3)
			{
				if (value != 1)
					return;
				ShowFriendReleasePopup(m_friendInfoList[content.Index]);
			}
			else
			{
				JumpToProfile(m_friendInfoList[content.Index].friend, ProfilMenuLayout.ButtonType.None);
			}
		}

		//// RVA: 0xBAAF14 Offset: 0xBAAF14 VA: 0xBAAF14
		private void SearchFriend()
		{
			friends.Clear();
			m_windowUi.SetMessageVisible(false);
			MenuScene.Instance.RaycastDisable();
			ConnectStart();
			friendManager.POEDEMPINCH(() =>
			{
				//0xBAB728
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
				//0xBAB8BC
				ConnectEnd();
				MenuScene.Instance.RaycastEnable();
			}, (CACGCMBKHDI_Request error) =>
			{
				//0xBAB96C
				ConnectEnd();
				NetErrorToTitle();
				MenuScene.Instance.RaycastEnable();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DFF7C Offset: 0x6DFF7C VA: 0x6DFF7C
		//// RVA: 0xBAB5D0 Offset: 0xBAB5D0 VA: 0xBAB5D0
		private IEnumerator OnSuccessSearchFriend()
		{
			//0xBABA64
			m_friendInfoAllList.Clear();
			for(int i = 0; i < friends.Count; i++)
			{
				FriendListInfo f = new FriendListInfo((short)i, true, friends[i]);
				m_friendInfoAllList.Add(f);
				f.TryInstall();
			}
			yield return null;
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			List<int> l = new List<int>(m_friendInfoAllList.Count);
			for(int i = 0; i < m_friendInfoAllList.Count; i++)
			{
				if(m_friendInfoAllList[i].IsNew)
				{
					l.Add(m_friendInfoAllList[i].playerId);
				}
			}
			if(l.Count > 0)
			{
				ConnectStart();
				friendManager.EICNBEKECJG(l, () =>
				{
					//0xBABA24
					ConnectEnd();
				}, (CACGCMBKHDI_Request error) =>
				{
					//0xBABA38
					ConnectEnd();
				}, (CACGCMBKHDI_Request error) =>
				{
					//0xBABA4C
					ConnectEnd();
					NetErrorToTitle();
				});
				while (IsConnecting())
					yield return null;
			}
			//LAB_00babf00
			SortFriendList();
			UpdateListCounter();
			MenuScene.Instance.RaycastEnable();
		}

		// RVA: 0xBAB67C Offset: 0xBAB67C VA: 0xBAB67C Slot: 44
		protected override void OnNetRequestSuccess()
		{
			if (lastNetType != NetType.FriendRelease)
				return;
			SearchFriend();
		}
	}
}
