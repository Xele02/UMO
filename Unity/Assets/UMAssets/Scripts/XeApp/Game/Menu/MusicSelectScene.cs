using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MusicSelectScene : MusicSelectSceneBase
	{
		protected LayoutEventGoDivaFeverLimit m_feverLimit; // 0xFC
		private MusicSelectSeriesInfo m_seriesInfo; // 0x100
		protected MusicSelectSLiveButton m_sliveButton; // 0x104
		protected MusicSelectSLiveItem m_sliveItem; // 0x108
		protected MusicSelectLineButton m_lineButton; // 0x10C
		protected MusicSelectMusicFilterButton m_filterButton; // 0x110
		private List<MusicDataList> m_originalMusicDataList = new List<MusicDataList>(5); // 0x114
		private List<MusicDataList> m_filteredMusicDataList = new List<MusicDataList>(5); // 0x118
		private bool m_isBgCached; // 0x11C
		private bool m_isEndRaidLobbyRequest; // 0x11D
		private bool m_isEndMyRankRequest; // 0x11E
		private bool m_showScoreRankingPopup; // 0x11F
		private bool m_isShowBanner; // 0x120
		private int m_pickupFreeMusicId; // 0x124
		// private int m_addRegularMusicMver; // 0x128
		private FreeCategoryId.Type m_pickupFreeCategoryId; // 0x12C
		// private const int BASIC_LIVE = 0;
		// private const int SIMULATION_LIVE = 1;
		private static readonly int[] s_categoryToSeries = new int[7] { -1, 4, 3, 2, 1, 5, 6 }; // 0x0

		// private MusicSelectArgs myArgs { get; set; } // 0xF8
		// private bool hasMyArgs { get; } 0x167F17C
		protected override int musicListCount { get { return m_filteredMusicDataList.Count; } } //0x167F18C
		protected override MusicDataList currentMusicList { get { return m_filteredMusicDataList[categoryId - 1]; } } //0x167F284
		public int categoryId { get; set; } // 0x130

		// // RVA: 0x167F204 Offset: 0x167F204 VA: 0x167F204 Slot: 32
		protected override MusicDataList GetMusicList(int i)
		{
			return m_filteredMusicDataList[i];
		}

		// RVA: 0x167F314 Offset: 0x167F314 VA: 0x167F314 Slot: 16
		protected override void OnPreSetCanvas()
		{
			if(Args != null)
			{
				TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnPreSetCanvas with args");
			}
			else
			{
				m_isLine6Mode = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.LMPCJJKHHPA_IsLine6();
			}
			m_pickupFreeMusicId = 0;
			m_pickupFreeCategoryId = 0;
			if(IsCanDoUnitHelp())
			{
				TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnPreSetCanvas IsCanDoUnitHelp");
			}
			if(!SelectUnitDanceFocus(out m_pickupFreeMusicId, out m_pickupFreeCategoryId, ref m_isLine6Mode, false, OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0))
			{
				TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnPreSetCanvas !SelectUnitDanceFocus");
			}
			SetupViewMusicData();
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("server_time_auto_update", 0) > 0)
			{
				NKGJPJPHLIF.DPCCNOCAHGC = false;
			}
			this.StartCoroutineWatched(Co_SetupBg());
			bool changeUi = true;
			MenuScene.Instance.LobbyButtonControl.OnStartTutorial = () => {
				//0x1685B28
				TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnPreSetCanvas");
			};
			MenuScene.Instance.LobbyButtonControl.OnEndAnnounce = () => {
				//0x1685B34
				TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnPreSetCanvas");
			};
			base.OnPreSetCanvas();
		}

		// RVA: 0x168019C Offset: 0x168019C VA: 0x168019C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(!m_isBgCached || isBgChanging)
				return false;
			m_musicInfo.Hide();
			m_cdSelect.Hide();
			m_cdArrow.Hide();
			m_buttonSet.Hide();
			m_eventBanner.Hide();
			m_feverLimit.Hide();
			m_sliveButton.Hide();
			m_sliveItem.Hide();
			m_musicRate.Hide();
			m_lineButton.Hide();
			m_filterButton.Hide();
			return base.IsEndPreSetCanvas();
		}

		// RVA: 0x1680318 Offset: 0x1680318 VA: 0x1680318 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_musicInfo.Enter();
			m_cdSelect.Enter();
			m_cdArrow.Enter();
			m_buttonSet.Enter();
			m_seriesInfo.Enter();
			m_sliveButton.Enter();
			if(!m_isSimulationLive)
			{
				m_musicRate.Enter();
				if(MenuScene.Instance.LobbyButtonControl.CheckLobbyAnnounce() && OHCAABOMEOF.BPJMGICFPBJ(m_eventId) == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid/*11*/)
				{
					m_isShowBanner = true;
				}
				else
				{
					m_eventBanner.TryEnter();
					m_feverLimit.TryEnter();
				}
				m_filterButton.Enter();
			}
			else
			{
				m_sliveItem.Enter();
			}
			m_lineButton.SetUnlock(IBJAKJJICBC.KGJJCAKCMLO());
			m_lineButton.SetUnlockNumber(IBJAKJJICBC.POPLHDKHIIM());
			m_lineButton.Enter(m_isLine6Mode);
			ApplyFilterButtonStatus();
			MenuScene.Instance.LobbyButtonControl.Setup(HomeLobbyButtonController.Type.DOWN);
		}

		// RVA: 0x16806BC Offset: 0x16806BC VA: 0x16806BC Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_musicInfo.IsPlaying() && !m_cdSelect.IsPlaying() && !m_cdArrow.IsPlaying() && !m_buttonSet.IsPlaying() &&
				!m_eventBanner.IsPlaying() && !m_feverLimit.IsPlaying() && !m_musicRate.IsPlaying() && 
				! m_seriesInfo.IsPlaying() && !m_sliveButton.IsPlaying() && !m_lineButton.IsPlaying() && 
				!m_filterButton.IsPlaying();
		}

		// RVA: 0x1680864 Offset: 0x1680864 VA: 0x1680864 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_musicInfo.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_buttonSet.TryLeave();
			m_sliveItem.TryLeave();
			m_musicRate.TryLeave();
			m_eventBanner.TryLeave();
			m_feverLimit.TryLeave();
			m_lineButton.TryLeave();
			m_filterButton.TryLeave();
			m_seriesInfo.TryLeave();
			m_sliveButton.TryLeave();
			MenuScene.Instance.LobbyButtonControl.Hide(false);
		}

		// RVA: 0x1680AD0 Offset: 0x1680AD0 VA: 0x1680AD0 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_musicInfo.IsPlaying() && !m_cdSelect.IsPlaying() && !m_cdArrow.IsPlaying() && !m_buttonSet.IsPlaying() &&
				!m_eventBanner.IsPlaying() && !m_feverLimit.IsPlaying() && !m_musicRate.IsPlaying() && 
				! m_seriesInfo.IsPlaying() && !m_sliveButton.IsPlaying() && !m_lineButton.IsPlaying() && 
				!m_filterButton.IsPlaying();
		}

		// RVA: 0x1680C78 Offset: 0x1680C78 VA: 0x1680C78 Slot: 15
		protected override void OnDeleteCache()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnDeleteCache");
			base.OnDeleteCache();
		}

		// RVA: 0x1680D4C Offset: 0x1680D4C VA: 0x1680D4C Slot: 14
		protected override void OnDestoryScene()
		{
			MenuScene.Instance.LobbyButtonControl.OnEndTutorial = null;
			MenuScene.Instance.LobbyButtonControl.OnEndAnnounce = null;
			base.OnDestoryScene();
		}

		// RVA: 0x1680E58 Offset: 0x1680E58 VA: 0x1680E58 Slot: 35
		protected override void CheckTryInstall()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "CheckTryInstall");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F3824 Offset: 0x6F3824 VA: 0x6F3824
		// // RVA: 0x1680FA0 Offset: 0x1680FA0 VA: 0x1680FA0 Slot: 36
		protected override IEnumerator Co_Initialize()
		{
			//0xF3526C
			m_isInitialized = false;
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("server_time_auto_update", 0) > 1)
			{
				NKGJPJPHLIF.DPCCNOCAHGC = true;
			}
			bool isError = false;
			yield return Co.R(MenuScene.Instance.LobbyButtonControl.Co_CheckNewMark(() => {
				//0x1685BD0
				isError = true;
			}));
			if(isError)
			{
				GotoTitle();
				m_isInitialized = true;
			}
			m_isEndRaidLobbyRequest = false;
			MenuScene.Instance.LobbyButtonControl.RequestInitRaidLobby(() => {
				//0x1685BDC
				m_isEndRaidLobbyRequest = true;
			}, () => {
				//0x1685C04
				m_isEndRaidLobbyRequest = true;
				GotoTitle();
			});
			while(!m_isEndRaidLobbyRequest)
				yield return null;
			m_isEndMyRankRequest = false;
			JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LFOBIPKFOEF(OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore/*4*/, 0, () => {
				//0x1685C50
				m_isEndMyRankRequest = true;
			}, () => {
				//0x1685C78
				m_isEndMyRankRequest = true;
				m_showScoreRankingPopup = false;
				GotoTitle();
			});
			while(!m_isEndMyRankRequest)
				yield return null;
			
			m_cdSelect.transform.SetAsLastSibling();
			m_cdArrow.transform.SetAsLastSibling();
			m_musicInfo.transform.SetAsLastSibling();
			m_seriesInfo.transform.SetAsLastSibling();
			m_buttonSet.transform.SetAsLastSibling();
			m_eventBanner.transform.SetAsLastSibling();
			m_feverLimit.transform.SetAsLastSibling();
			m_sliveButton.transform.SetAsLastSibling();
			m_sliveItem.transform.SetAsLastSibling();
			m_musicRate.transform.SetAsLastSibling();
			m_lineButton.transform.SetAsLastSibling();
			m_filterButton.transform.SetAsLastSibling();
			m_musicInfo.onChangedDifficulty = this.OnSelectedDifficulty;
			m_seriesInfo.onChangedSeries = this.OnChangedSeries;
			m_cdSelect.onClickEventDetailButton = this.OnClickEventDetailButton;
			m_cdSelect.onClickFlowButton = this.OnClickFlowButton;
			m_cdSelect.onSelectionChanged = this.OnSelectionChanged;
			m_cdSelect.onScrollRepeated = this.OnScrollRepeated;
			m_cdSelect.onScrollStarted = this.OnScrollStarted;
			m_cdSelect.onScrollUpdated = this.OnScrollUpdated;
			m_cdSelect.onScrollEnded = this.OnScrollEnded;
			m_cdSelect.onClickPlayButton = this.OnClickPlayButton;
			m_buttonSet.onClickRankingButton = this.OnClickRankingButton;
			m_buttonSet.onClickRewardButton = this.OnClickRewardButton;
			m_buttonSet.onClickDetailButton = this.OnClickDetailButton;
			m_buttonSet.onClickEventRankingButton = this.OnClickEventRankingButton;
			m_buttonSet.onClickEventRewardButton = this.OnClickEventRewardButton;
			m_buttonSet.onClickEnemyInfoButton = this.OnClickEnemyInfoButton;
			m_eventBanner.onClickBanner = this.OnClickEventBanner;
			m_sliveButton.onClickButton = this.OnChangeLiveMode;
			m_lineButton.onClickButton = this.OnChangeLineMode;
			m_filterButton.OnClickButtonListener = this.OnClickMusicFilterButton;
			m_musicInfo.MakeCache();
			m_cdSelect.MakeCache();
			m_sliveButton.SetOptionStyle(m_isSimulationLive ? MusicSelectSLiveButton.Style.SimulationLive : MusicSelectSLiveButton.Style.BasicLive);
			m_sliveButton.SetUnlockRank(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("mv_player_level", 5));
			MessageBank menuBank = MessageManager.Instance.GetBank("menu");
			m_musicInfo.SetNoInfoMessage(menuBank.GetMessageByLabel("music_not_exist_text_00"), menuBank.GetMessageByLabel("music_not_exist_line6_text_00"));
			ApplyBasicInfo();
			ApplyMusicListInfo();
			ApplyMusicInfo();
			ApplyEventInfo();
			m_sliveItem.ItemIconHide();
			GameManager.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket/*16*/,1), (IiconTexture image) => {
				//0x1685CE0
				m_sliveItem.SetIcon(image);
			});
			m_sliveItem.SetCount(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket);
			MenuScene.Instance.FooterMenu.NotSelectButtonAll();
			MenuScene.Instance.FooterMenu.SelectedButton(MenuButtonAnim.ButtonType.LIVE);
			Database.Instance.bonusData.ClearEpisodeBonus();
			m_isInitialized = true;
		}

		// // RVA: 0x1681028 Offset: 0x1681028 VA: 0x1681028 Slot: 39
		protected override void Release()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "Release");
		}

		// // RVA: 0x1681070 Offset: 0x1681070 VA: 0x1681070 Slot: 40
		protected override void SetupViewMusicData()
		{
			m_originalMusicDataList.Clear();
			long val = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 1; i < 7; i++)
			{
				List<IBJAKJJICBC> viewList = IBJAKJJICBC.FKDIMODKKJD(i, val, false, false, false, false);
				List<IBJAKJJICBC> view6LineList = IBJAKJJICBC.FKDIMODKKJD(i, val, false, false, false, true);
				List<IBJAKJJICBC> viewSimulationList = viewList;
				List<IBJAKJJICBC> view6LineSimulationList = view6LineList;
				if(i == 5)
				{
					viewSimulationList = IBJAKJJICBC.LIENJMIJMIE(val, false);
					view6LineSimulationList = IBJAKJJICBC.LIENJMIJMIE(val, true);
				}

				m_originalMusicDataList.Add(new MusicDataList(viewList, view6LineList, viewSimulationList, view6LineSimulationList));
			}

			CreateFilteredMusicDataList(m_filteredMusicDataList, m_originalMusicDataList, val, (IBJAKJJICBC m, long ct) => {
				//0x16859E4
				return true;
			});
			Difficulty.Type difficulty = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.FFACBDAJJJP_GetDifficulty();
			FreeCategoryId.Type categoryId = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.OGJDBPMKJKE_GetCategoryId();
			int curMusicId = 0;
			OHCAABOMEOF.KGOGMKMBCPP_EventType eventType = 0;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.FKJBADIPKHK_GetSelectionForCategory(
				categoryId,
				out curMusicId, out eventType
			);
			int mId = m_pickupFreeMusicId;
			if(mId > 0)
				curMusicId = mId;
			if(m_pickupFreeCategoryId != 0)
				categoryId = m_pickupFreeCategoryId;
			int musicDataIdx = 0;
			MusicSelectArgs mArgs = Args as MusicSelectArgs;
			if(mArgs == null || !mArgs.hasSelection)
			{
				if(categoryId == 0)
					categoryId = FreeCategoryId.Type.Macross/*1*/;
				diff = difficulty;
				musicDataIdx = m_filteredMusicDataList[(int)categoryId - 1].FindIndex(curMusicId, eventType, m_isLine6Mode, m_isSimulationLive);

				if(musicDataIdx < 0)
				{
					musicDataIdx = 0;
				}
				list_no = musicDataIdx;
			}
			else
			{
				TodoLogger.LogError(TodoLogger.OldMusicSelect, "init  with args");
				//L230
			}
			//LAB_016819f8:
			ReviseDifficulty();
			OnChangeMusicFilter(false);
			m_eventId = 0;
			m_eventIndex = 0;
			m_eventTicketId = 0;
			NKOBMDPHNGP_EventRaidLobby d = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby/*13*/, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_EventRaidLobby;
			bool b = false;
			if(d == null)
			{
				b = false;
			}
			else
			{
				if(d.AKNOOLKMEGJ())
				{
					m_eventTicketId = NKOBMDPHNGP_EventRaidLobby.ADPMLOEOAFD();
				}
			}
			m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6/*6*/, false);
			if(m_eventCtrl == null)
			{
				if(m_eventBanner != null)
				{
					m_eventBanner.SetStyle(MusicSelectEventBanner.Style.Enable);
				}
			}
			else
			{
				TodoLogger.LogError(TodoLogger.OldMusicSelect, "init event music");
			}
			if(m_feverLimit != null)
			{
				m_feverLimit.SetOnOff(false);
			}
			m_scoreEventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6/*6*/);
			if(m_scoreEventCtrl != null)
			{
				TodoLogger.LogError(TodoLogger.OldMusicSelect, "init score event music");
			}
		}

		// RVA: 0x1682928 Offset: 0x1682928 VA: 0x1682928 Slot: 41
		protected override void ApplyBasicInfo()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectScene* ApplyBasicInfo");
		}

		// RVA: 0x1682A58 Offset: 0x1682A58 VA: 0x1682A58 Slot: 42
		protected override void ApplyMusicListInfo()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectScene* ApplyMusicListInfo");
			base.ApplyMusicListInfo();
		}

		// // RVA: 0x1682BAC Offset: 0x1682BAC VA: 0x1682BAC Slot: 44
		protected override void DelayedApplyMusicInfo()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "DelayedApplyMusicInfo");
		}

		// // RVA: 0x1682DA0 Offset: 0x1682DA0 VA: 0x1682DA0
		private void ApplyEventInfo()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectScene* ApplyEventInfo");
		}

		// // RVA: 0x1682EE0 Offset: 0x1682EE0 VA: 0x1682EE0 Slot: 52
		protected override void LeaveForScrollStart()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectScene* LeaveForScrollStart");
		}

		// RVA: 0x1682F18 Offset: 0x1682F18 VA: 0x1682F18 Slot: 53
		// protected override void EnterForScrollEnd() { }

		// // RVA: 0x1682F50 Offset: 0x1682F50 VA: 0x1682F50
		private bool IsFilter()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "IsFilter");
			return false;
		}

		// // RVA: 0x168326C Offset: 0x168326C VA: 0x168326C
		// private void CheckListEpmtyByFilter() { }

		// // RVA: 0x16832F8 Offset: 0x16832F8 VA: 0x16832F8
		// private bool CheckMatchMusicFilter(IBJAKJJICBC musicData, long currentTime) { }

		// // RVA: 0x16836A4 Offset: 0x16836A4 VA: 0x16836A4
		// private bool CheckMusicFilter_MusicLevel(int levelMin, int levelMax, IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0x168374C Offset: 0x168374C VA: 0x168374C
		// private bool CheckMusicFilter_MusicAttr(int filterBit, IBJAKJJICBC musicData) { }

		// // RVA: 0x1683808 Offset: 0x1683808 VA: 0x1683808
		// private bool CheckMusicFilter_Combo(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0x1683974 Offset: 0x1683974 VA: 0x1683974
		// private bool CheckMusicFilter_Reward(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty, bool isLine6Mode) { }

		// // RVA: 0x1683BA4 Offset: 0x1683BA4 VA: 0x1683BA4
		// private bool CheckMusicFilter_Unit(int filterBit, IBJAKJJICBC musicData) { }

		// // RVA: 0x1683CBC Offset: 0x1683CBC VA: 0x1683CBC
		private void OnClickMusicFilterButton()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnClickMusicFilterButton");
		}

		// // RVA: 0x168264C Offset: 0x168264C VA: 0x168264C
		private void OnChangeMusicFilter(bool applyDisplay)
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnChangeMusicFilter");
		}

		// // RVA: 0x168067C Offset: 0x168067C VA: 0x168067C
		private void ApplyFilterButtonStatus()
		{
			m_filterButton.SetButtonStatus(IsFilter() == true ? MusicSelectMusicFilterButton.ButtonStatusType.FilterOn : MusicSelectMusicFilterButton.ButtonStatusType.FilterOff);
		}

		// // RVA: 0x1683FAC Offset: 0x1683FAC VA: 0x1683FAC Slot: 54
		protected override void OnChangedDifficulty()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnChangedDifficulty");
		}

		// // RVA: 0x1683F30 Offset: 0x1683F30 VA: 0x1683F30
		// private void OnChangedSeries(FreeCategoryId.Type seriesId, int initListNo) { }

		// // RVA: 0x168417C Offset: 0x168417C VA: 0x168417C
		private void OnChangedSeries(FreeCategoryId.Type seriesId)
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnChangedSeries");
		}

		// // RVA: 0x16828E4 Offset: 0x16828E4 VA: 0x16828E4
		// private bool CheckShowEventBanner(OHCAABOMEOF.KGOGMKMBCPP eventType) { }

		// // RVA: 0x168439C Offset: 0x168439C VA: 0x168439C
		protected void OnChangeLiveMode(int mode)
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnChangeLiveMode");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F389C Offset: 0x6F389C VA: 0x6F389C
		// // RVA: 0x168459C Offset: 0x168459C VA: 0x168459C
		// private IEnumerator Co_ChangeLiveMode(Action callback) { }

		// // RVA: 0x1684664 Offset: 0x1684664 VA: 0x1684664
		protected void OnChangeLineMode(int style)
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnChangeLineMode");
		}

		// // RVA: 0x1684928 Offset: 0x1684928 VA: 0x1684928
		private void OnClickEventBanner()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "OnClickEventBanner");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F3914 Offset: 0x6F3914 VA: 0x6F3914
		// // RVA: 0x1680114 Offset: 0x1680114 VA: 0x1680114
		private IEnumerator Co_SetupBg()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "Co_SetupBg");
			m_isBgCached = true;
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F398C Offset: 0x6F398C VA: 0x6F398C
		// // RVA: 0x16840F0 Offset: 0x16840F0 VA: 0x16840F0
		// private IEnumerator Co_ChangeBg() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F3A04 Offset: 0x6F3A04 VA: 0x6F3A04
		// // RVA: 0x1684A64 Offset: 0x1684A64 VA: 0x1684A64 Slot: 55
		protected override IEnumerator Co_LoadLayout()
		{
			// private StringBuilder <bundleName>5__2; // 0x14
			// private Font <systemFont>5__3; // 0x18
			// private int <bundleLoadCount>5__4; // 0x1C
			// private AssetBundleLoadLayoutOperationBase <lytOp>5__5; // 0x20
			// private AssetBundleLoadUGUIOperationBase <uguiOp>5__6; // 0x24
			//0xF368D0
			StringBuilder bundleName = new StringBuilder();
			XeSys.FontInfo systemFont = GameManager.Instance.GetSystemFont();
			int bundleLoadCount = 0;
			bundleName.Set("ly/038.xab");
			AssetBundleLoadLayoutOperationBase lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicInfo");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x1684F88
				instance.transform.SetParent(transform, false);
				m_musicInfo = instance.GetComponent<MusicSelectMusicInfo>();
			}));
			bundleLoadCount++;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_SeriesInfo");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x1685058
				instance.transform.SetParent(transform, false);
				m_seriesInfo = instance.GetComponent<MusicSelectSeriesInfo>();
			}));
			bundleLoadCount++;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicCD");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x1685128
				instance.transform.SetParent(transform, false);
				m_cdSelect = instance.GetComponent<MusicSelectCDSelect>();
			}));
			bundleLoadCount++;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicCDArrow");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x16851F8
				instance.transform.SetParent(transform, false);
				m_cdArrow = instance.GetComponent<MusicSelectCDArrow>();
			}));
			bundleLoadCount++;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_ButtonSet");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x16852C8
				instance.transform.SetParent(transform, false);
				m_buttonSet = instance.GetComponent<MusicSelectButtonSet>();
			}));
			bundleLoadCount++;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventBanner");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x1685398
				instance.transform.SetParent(transform, false);
				m_eventBanner = instance.GetComponent<MusicSelectEventBanner>();
			}));
			bundleLoadCount++;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_SLiveButton");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x1685468
				instance.transform.SetParent(transform, false);
				m_sliveButton = instance.GetComponent<MusicSelectSLiveButton>();
			}));
			bundleLoadCount++;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_SLiveItem");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x1685538
				instance.transform.SetParent(transform, false);
				m_sliveItem = instance.GetComponent<MusicSelectSLiveItem>();
			}));
			bundleLoadCount++;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicRate");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x1685608
				instance.transform.SetParent(transform, false);
				m_musicRate = instance.GetComponent<MusicSelectMusicRate>();
			}));
			bundleLoadCount++;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_LineButton");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x16856D8
				instance.transform.SetParent(transform, false);
				m_lineButton = instance.GetComponent<MusicSelectLineButton>();
			}));
			bundleLoadCount++;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UGUI_FilterButton");
			yield return lytOp;
			yield return lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x16857A8
				instance.transform.SetParent(transform, false);
				m_filterButton = instance.GetComponent<MusicSelectMusicFilterButton>();
			});
			bundleLoadCount++;

			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			
			bundleName.Set("ly/224.xab");
			bundleLoadCount = 0;

			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_me3_fever_limit_layout_root");
			yield return Co.R(lytOp);
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) => {
				//0x1685878
				instance.transform.SetParent(transform, false);
				m_feverLimit = instance.GetComponent<LayoutEventGoDivaFeverLimit>();
			}));
			bundleLoadCount++;

			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F3A7C Offset: 0x6F3A7C VA: 0x6F3A7C
		// // RVA: 0x1684AEC Offset: 0x1684AEC VA: 0x1684AEC Slot: 56
		protected override IEnumerator Co_WaitForLoaded()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F3AF4 Offset: 0x6F3AF4 VA: 0x6F3AF4
		// // RVA: 0x1684B74 Offset: 0x1684B74 VA: 0x1684B74 Slot: 57
		protected override IEnumerator Co_WaitForAnimEnd(Action onEnd)
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "TODO Co_WaitForAnimEnd");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F3B6C Offset: 0x6F3B6C VA: 0x6F3B6C
		// // RVA: 0x1684C18 Offset: 0x1684C18 VA: 0x1684C18 Slot: 37
		protected override IEnumerator Co_OnActivateScene()
		{
			//0xF379A4
			m_isEndActivateScene = false;
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				TodoLogger.LogError(TodoLogger.OldMusicSelect, "Co_OnActivateScene display & check unlock");
			}
			
			m_isEndActivateScene = true;
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F3BE4 Offset: 0x6F3BE4 VA: 0x6F3BE4
		// // RVA: 0x1684CA0 Offset: 0x1684CA0 VA: 0x1684CA0
		// private IEnumerator Co_ShowScoreRankingPopup() { }

		// // RVA: 0x167FE5C Offset: 0x167FE5C VA: 0x167FE5C
		private bool IsCanDoUnitHelp()
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "IsCanDoUnitHelp");
			return false;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6F3C6C Offset: 0x6F3C6C VA: 0x6F3C6C
		// // RVA: 0x1684E98 Offset: 0x1684E98 VA: 0x1684E98
		// private void <ApplyMusicListInfo>b__44_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F3C7C Offset: 0x6F3C7C VA: 0x6F3C7C
		// // RVA: 0x1684F58 Offset: 0x1684F58 VA: 0x1684F58
		// private void <ApplyEventInfo>b__46_0(IiconTexture image) { }

		// [DebuggerHiddenAttribute] // RVA: 0x6F3D4C Offset: 0x6F3D4C VA: 0x6F3D4C
		// [CompilerGeneratedAttribute] // RVA: 0x6F3D4C Offset: 0x6F3D4C VA: 0x6F3D4C
		// // RVA: 0x1685948 Offset: 0x1685948 VA: 0x1685948
		// private IEnumerator <>n__0() { }

		// [DebuggerHiddenAttribute] // RVA: 0x6F3D7C Offset: 0x6F3D7C VA: 0x6F3D7C
		// [CompilerGeneratedAttribute] // RVA: 0x6F3D7C Offset: 0x6F3D7C VA: 0x6F3D7C
		// // RVA: 0x1685950 Offset: 0x1685950 VA: 0x1685950
		// private IEnumerator <>n__1(Action onEnd) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F3DAC Offset: 0x6F3DAC VA: 0x6F3DAC
		// // RVA: 0x1685958 Offset: 0x1685958 VA: 0x1685958
		// private void <Co_OnActivateScene>b__76_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F3DBC Offset: 0x6F3DBC VA: 0x6F3DBC
		// // RVA: 0x1685960 Offset: 0x1685960 VA: 0x1685960
		// private void <Co_OnActivateScene>b__76_1() { }
	}
}
