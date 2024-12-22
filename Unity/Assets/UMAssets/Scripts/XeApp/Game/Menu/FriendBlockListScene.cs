using System.Collections;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class FriendBlockListScene : FriendListSceneBase
	{
		private static readonly SortItem[] s_sortTypeList = new SortItem[14]
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm,
			SortItem.Rarity, SortItem.Level, SortItem.Life, SortItem.Support,
			SortItem.Fold, SortItem.Luck, SortItem.LastPlayDate, SortItem.PlayerRunk,
			SortItem.Request, SortItem.HighScoreRating
		}; // 0x0
		private int m_now; // 0xA8
		private int m_max; // 0xAC

		//protected override SortItem[] sortTypeList { get; } 0xBA519C
		protected override SortItem defaultSortType { get { return SortItem.Request; } } //0xBA5228
		protected override PopupSortMenu.SortPlace sortPlace { get { return PopupSortMenu.SortPlace.SentRequestList; } } //0xBA5230
		protected override ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList sortSaveData { get { return GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.EJAJGGKHALM_SentRequestList; } }  //0xBA5238
		protected override GuestListWindow.CounterStyle listCounterSyle { get { return GuestListWindow.CounterStyle.Fraction; } } //0xBA5320
		protected override int listCounterCount { get { return m_now; } } //0xBA5328
		protected override int listCounterMax { get { return m_max; } } //0xBA5330

		// RVA: 0xBA5338 Offset: 0xBA5338 VA: 0xBA5338 Slot: 41
		protected override void Initialize()
		{
			InitializeDecos();
			InitializeSortSetting();
			m_buttonRuntime.ChangePreset(GeneralListButtonRuntime.Preset.BlockList);
			m_buttonRuntime.onClickSortButton = OnClickSortButton;
			m_buttonRuntime.onClickOrderButton = OnClickOrderButton;
			OnChangeSortType();
			OnChangeSortOrder();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_windowUi.SetMessageVisible(false);
			friendNotFoundMessage = bk.GetMessageByLabel("blocklist_empty_text");
			friendAllFilteredMessage = "";
			for (int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetButtonStyle(FriendListElem.ButtonStyle.BlockList);
				m_elems[i].ChangeStatus(true, false);
				m_elems[i].SetParamTable(SortItem.LastPlayDate);
			}
			m_scrollList.SetItemCount(0);
			m_scrollList.VisibleRegionUpdate();
			m_now = 0;
			m_max = friendManager.OKDGKAHNBPP();
			SearchFriend();
		}

		// RVA: 0xBA5CA8 Offset: 0xBA5CA8 VA: 0xBA5CA8 Slot: 42
		protected override void Release()
		{
			ReleaseDecos();
		}

		//// RVA: 0xBA5CAC Offset: 0xBA5CAC VA: 0xBA5CAC
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			if (value != 1)
				return;
			this.StartCoroutineWatched(Co_ReleaseBlackList(1, content));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DFD7C Offset: 0x6DFD7C VA: 0x6DFD7C
		//// RVA: 0xBA5CDC Offset: 0xBA5CDC VA: 0xBA5CDC
		private IEnumerator Co_ReleaseBlackList(int value, SwapScrollListContent content)
		{
			FriendListInfo friendInfo; // 0x20
			MessageBank t_bank; // 0x24

			//0xBA624C
			MenuScene.Instance.RaycastDisable();
			friendInfo = m_friendInfoList[content.Index];
			t_bank = MessageManager.Instance.GetBank("menu");
			PopupButton.ButtonType t_type = PopupButton.ButtonType.Negative;
			bool t_loop = true;
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = t_bank.GetMessageByLabel("pop_block_remove_ask_title");
			s.Text = string.Format(t_bank.GetMessageByLabel("pop_block_remove_ask_text"), friendInfo.friend.LBODHBDOMGK_Name);
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0xBA6200
				t_loop = false;
				t_type = t;
			}, null, null, null);
			while(t_loop)
				yield return null;
			if(t_type == PopupButton.ButtonType.Positive)
			{
				int t_result = 0;
				ConnectStart();
				friendManager.CIBLHBAMIJO(friendInfo.playerId, () =>
				{
					//0xBA6224
					t_result = 1;
				}, (CACGCMBKHDI_Request error) =>
				{
					//0xBA6230
					t_result = 2;
				}, (CACGCMBKHDI_Request error) =>
				{
					//0xBA623C
					t_result = 3;
				});
				while (t_result == 0)
					yield return null;
				if(t_result == 1)
				{
					t_loop = true;
					s = new TextPopupSetting();
					s.TitleText = t_bank.GetMessageByLabel("pop_block_remove_done_title");
					s.Text = string.Format(t_bank.GetMessageByLabel("pop_block_remove_deon_text"), friendInfo.friend.LBODHBDOMGK_Name);
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
					{
						//0xBA6210
						t_loop = false;
					}, null, null, null);
					while(t_loop)
						yield return null;
					SearchFriend();
				}
				else
				{
					if(t_result == 2)
					{
						ConnectEnd();
					}
					else
					{
						if (t_result == 3)
							NetErrorToTitle();
					}
				}
			}
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xBA5AD4 Offset: 0xBA5AD4 VA: 0xBA5AD4
		private void SearchFriend()
		{
			friends.Clear();
			m_windowUi.SetMessageVisible(false);
			MenuScene.Instance.RaycastDisable();
			ConnectStart();
			friendManager.EGFNFKJOMIM(() =>
			{
				//0xBA5EFC
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
				//0xBA6090
				ConnectEnd();
				MenuScene.Instance.RaycastEnable();
			}, (CACGCMBKHDI_Request error) =>
			{
				//0xBA6140
				ConnectEnd();
				NetErrorToTitle();
				MenuScene.Instance.RaycastEnable();
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DFDF4 Offset: 0x6DFDF4 VA: 0x6DFDF4
		//// RVA: 0xBA5DA4 Offset: 0xBA5DA4 VA: 0xBA5DA4
		private IEnumerator OnSuccessSearchFriend()
		{
			//0xBA6DA4
			m_friendInfoAllList.Clear();
			for(int i = 0; i < friends.Count; i++)
			{
				FriendListInfo info = new FriendListInfo((short)i, true, friends[i]);
				m_friendInfoAllList.Add(info);
				info.TryInstall();
			}
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			m_now = friends.Count;
			SortFriendList();
			UpdateListCounter();
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xBA5E50 Offset: 0xBA5E50 VA: 0xBA5E50 Slot: 44
		protected override void OnNetRequestSuccess()
		{
			if (((int)lastNetType & 0xfffffffe) != 1)
				return;
			SearchFriend();
		}
	}
}
