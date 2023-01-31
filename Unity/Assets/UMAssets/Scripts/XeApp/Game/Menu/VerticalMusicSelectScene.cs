using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Common.View;
using XeApp.Game.MusicSelect;
using XeSys;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectScene : VerticalMusicSelectSceneBase
	{
		private static readonly FreeCategoryId.Type[] MUSIC_LIST_TYPE = new FreeCategoryId.Type[5]
			{FreeCategoryId.Type.Macross, FreeCategoryId.Type.Seven, FreeCategoryId.Type.Frontia, FreeCategoryId.Type.Delta, FreeCategoryId.Type.Other}; // 0x0
		private VerticalMusicSelectUISapporter m_musicSelectUISapporter = new VerticalMusicSelectUISapporter(); // 0xB0
		private List<VerticalMusicDataList> m_originalMusicDataList = new List<VerticalMusicDataList>(); // 0xB4
		private List<VerticalMusicDataList> m_originalEventMusicDataList = new List<VerticalMusicDataList>(); // 0xB8
		private VerticalMusicDataList m_filterMusicDataList = new VerticalMusicDataList(); // 0xBC
		private VerticalMusicDataList m_filterMusicEventDataList = new VerticalMusicDataList(); // 0xC0
		// private bool m_isListScroll; // 0xC4
		private bool m_isChangeBg; // 0xC5
		 private bool m_isEndMyRankRequest; // 0xC6
		 private bool m_showScoreRankingPopup; // 0xC7
		public static readonly MusicSelectConsts.SeriesType[] CategoryToSeriesType = new MusicSelectConsts.SeriesType[7] { 
			MusicSelectConsts.SeriesType.All,
			MusicSelectConsts.SeriesType.First,
			MusicSelectConsts.SeriesType.Seven,
			MusicSelectConsts.SeriesType.Frontia,
			MusicSelectConsts.SeriesType.Delta,
			MusicSelectConsts.SeriesType.All,
			MusicSelectConsts.SeriesType.Other
		 }; // 0x4
		private bool m_isBgCached; // 0xCC
		private bool m_isScoreRankingPopup; // 0xCD
		private bool m_isScoreEventTimeLimit; // 0xCE
		private bool m_isListEmptyByFilter; // 0xCF
		private int m_eventIndex; // 0xD0
		private int m_pickupFreeMusicId; // 0xD4
		private FreeCategoryId.Type m_pickupFreeCategoryId; // 0xD8
		// private OHCAABOMEOF.KGOGMKMBCPP m_currentEventType; // 0xDC
		private VerticalMusicSelecChoiceMusicListTab.MusicTab m_musicTab; // 0xE0
		private VerticalMusicSelectMusicList m_musicList; // 0xE4
		private VerticalMusicSelectMusicDetail m_musicDetail; // 0xE8
		private VerticalMusicSelectUtaRate m_utaRate; // 0xEC
		private VerticalMusicSelectEventBanner m_eventBanner; // 0xF0
		private VerticalMusicSelectEventItem m_eventItem; // 0xF4
		private VerticalMusicSelectDifficultyButtonGroup m_difficultyButtonGroup; // 0xF8
		private VerticalMusicSelectSeriesButtonGroup m_seriesButtonGroup; // 0xFC
		private VerticalMusicSelecLine6Button m_line6Button; // 0x100
		private VerticalMusicSelctSimulationButton m_simulationButton; // 0x104
		private VerticalMusicSelectPlayButton m_playButton; // 0x108
		private VerticalMusicSelecChoiceMusicListTab m_choiceMusicTab; // 0x10C
		private MusicJecketScrollView m_jacketScroll; // 0x110
		private VerticalMusicSelectMusicFilterButton m_filterButton; // 0x114
		private VerticalMusicSelectSortOrder m_orderButton; // 0x118
		private LayoutEventGoDivaFeverLimit m_feverLimit; // 0x11C
		private static readonly int newSeriesBgIdDiff = 6; // 0x8
		private static readonly int eventCategoryId = 5; // 0xC
		private static readonly int[] CategoryToNewSeriesBgId = new int[7] { -1, newSeriesBgIdDiff+4, newSeriesBgIdDiff+3, newSeriesBgIdDiff+2, newSeriesBgIdDiff+1, newSeriesBgIdDiff+eventCategoryId, newSeriesBgIdDiff+6 }; // 0x10
		private static readonly int[] SeriesToNewSeriesBgId = new int[6] { -1, newSeriesBgIdDiff+1, newSeriesBgIdDiff+2, newSeriesBgIdDiff+3, newSeriesBgIdDiff+4, newSeriesBgIdDiff+6 }; // 0x14
		private static readonly int noMusicCategoryId = CategoryToNewSeriesBgId[6] + 1; // 0x18

		private VerticalMusicSelectSortOrder.SortOrder sortOrder { get { return m_musicSelectUISapporter.sortOrder; } } //0xBE5B30
		protected override IBJAKJJICBC selectMusicData { get {
				VerticalMusicDataList.MusicListData musicData = currentMusicList.Get(list_no, isLine6Mode, false);
				if (musicData != null)
					return musicData.ViewMusic;
				return null;
		} } //0xBE5B5C
		protected override VerticalMusicDataList.MusicListData selectMusicListData { get {
			return currentMusicList.Get(list_no, isLine6Mode, false);
		} } //0xBE5C04
		protected override Difficulty.Type diff { get { return m_musicSelectUISapporter.difficulty; } } //0xBE5C90
		protected override MusicSelectConsts.SeriesType series { get { return m_musicSelectUISapporter.series; } } //0xBE5CBC
		protected override int list_no { get; set; } // 0xC8
		protected override int musicListCount { get { return 2; } } //0xBE5CF8
		// RVA: 0xBE5D00 Offset: 0xBE5D00 VA: 0xBE5D00 Slot: 37
		protected override VerticalMusicDataList GetMusicList(int i)
		{
			return i == 0 ? m_filterMusicDataList : m_filterMusicEventDataList;
		}
		protected override VerticalMusicDataList currentMusicList { get { 
			if(m_musicTab == 0)
				return m_filterMusicDataList;
			return m_filterMusicEventDataList;
		} } //0xBE5D14
		// protected override List<VerticalMusicDataList> originalMusicList { get; } 0xBE5D2C
		protected override bool isLine6Mode { get { return m_musicSelectUISapporter.isLine6Mode; } } //0xBE5D34
		private bool m_isLine6Mode { get { return m_musicSelectUISapporter.isLine6Mode;  } set { m_musicSelectUISapporter.isLine6Mode = value; } } //0xBE5D7C 0xBE5D58
		// private List<VerticalMusicDataList> currentOriginalMusicDataList { get; } 0xBE5DA4

		// [IteratorStateMachineAttribute] // RVA: 0x6F5EAC Offset: 0x6F5EAC VA: 0x6F5EAC
		// // RVA: 0xBE5DBC Offset: 0xBE5DBC VA: 0xBE5DBC Slot: 42
		protected override IEnumerator Co_OnPreSetCanvas()
		{
			//0xAC6148
			GameManager.Instance.SetFPS(60);
			MusicSelectArgs args = Args as MusicSelectArgs;
			if(args == null)
			{
				m_isLine6Mode = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.LMPCJJKHHPA_Is6LineMode();
			}
			else
			{
				TodoLogger.Log(0, "Args != null");
			}
			long currentTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI, false);
			m_musicSelectUISapporter.SetUp(m_musicList, m_musicDetail, m_utaRate, m_eventBanner, m_difficultyButtonGroup, m_seriesButtonGroup, m_playButton, m_simulationButton, m_orderButton, m_eventCtrl, m_unitLiveLocalSaveData, m_line6Button, m_choiceMusicTab);
			SetCreateMusicList();
			CrateFilterDataList(m_filterMusicDataList, m_originalMusicDataList, 0, currentTime, (VerticalMusicDataList.MusicListData s, int c, long f) => {
				//0xAC28DC
				return true;
			});
			CrateFilterDataList(m_filterMusicEventDataList, m_originalEventMusicDataList, 0, currentTime, (VerticalMusicDataList.MusicListData s, int c, long f) => {
				//0xAC28E4
				return true;
			});
			bool isEvent = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.OAALFANHEHL_IsEventTab();
			int songId;
			OHCAABOMEOF.KGOGMKMBCPP_EventType eventType;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.FKJBADIPKHK_GetSelectedSong(isEvent, out songId, out eventType);

			m_musicTab = VerticalMusicSelecChoiceMusicListTab.MusicTab.Normal;

			if(isEvent)
				m_musicTab = VerticalMusicSelecChoiceMusicListTab.MusicTab.Event;
			
			m_isEndPresetCanvas = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("mv_player_level", 5) <= 
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;

			m_simulationButton.SetTicketNum(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket);
			Database.Instance.bonusData.ClearEpisodeBonus();
			if(m_pickupFreeMusicId > 0)
				songId = m_pickupFreeMusicId;
			if(IsCanDoUnitHelp())
			{
				TodoLogger.Log(0, "IsCanDoUnitHelp");
			}
			if(!SelectUnitDanceFocus(out m_pickupFreeMusicId, out m_pickupFreeCategoryId, ref m_musicSelectUISapporter.isLine6Mode, false, 0))
			{
				SelectAprilFoolFocus();
			}
			m_musicSelectUISapporter.SetSmallBigOrder(!GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.CFNMCFDDOJO() ? VerticalMusicSelectSortOrder.SortOrder.Big : VerticalMusicSelectSortOrder.SortOrder.Small);
			SelectArgsFocus(args);
			ApplyEventInfo();
			List<VerticalMusicDataList.MusicListData> musicList = currentMusicList.GetList(isLine6Mode, false);
			m_musicList.SetMusicDataList(musicList, list_no, (int)diff);
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("ct/mc/{0:D3}.xab",0);
			for(int i = 0; i < m_originalMusicDataList.Count; i++)
			{
				TryInstall(str, m_originalMusicDataList[i]);
			}
			for(int i = 0; i < m_originalEventMusicDataList.Count; i++)
			{
				TryInstall(str, m_originalEventMusicDataList[i]);
			}
			m_isChangeBg = false;
			StartCoroutine(Co_SetupBg(BgType.VerticalMusic, GetChangeBgId(selectMusicListData), false, () => {
				//0xBF00B8
				m_isChangeBg = true;
			}));

			while(!m_isChangeBg)
				yield return null;
			m_musicSelectUISapporter.eventStatus = m_eventStatus;
			m_isEndPresetCanvas = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F5F24 Offset: 0x6F5F24 VA: 0x6F5F24
		// // RVA: 0xBE5E44 Offset: 0xBE5E44 VA: 0xBE5E44
		private IEnumerator Co_SetupBg(BgType bgType, int bgId, bool isFade, Action endCallBack)
		{
			BgControl bgControl;
			//0xAC807C
			if (!m_isBgCached)
			{
				bgControl = MenuScene.Instance.BgControl;
				for(int i = 0; i < VerticalMusicSelectScene.CategoryToNewSeriesBgId.Length; i++)
				{
					if((int)VerticalMusicSelectScene.CategoryToNewSeriesBgId[i] > -1)
					{
						yield return bgControl.CacheBg(BgType.VerticalMusic, (int)CategoryToNewSeriesBgId[i]);
					}
				}
				yield return bgControl.CacheBg(BgType.VerticalMusic, noMusicCategoryId);
			}
			m_isBgCached = true;
			yield return Co_ChangeBg(bgType, bgId, endCallBack, isFade);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F5F9C Offset: 0x6F5F9C VA: 0x6F5F9C
		// // RVA: 0xBE5F30 Offset: 0xBE5F30 VA: 0xBE5F30 Slot: 43
		protected override IEnumerator Co_OnPostSetCanvas()
		{
			//0xAC51E4
			m_isEndPostSetCanvas = false;
			m_musicList.OnUpdateCenter = (int index) =>
			{
				//0xBF00C4
				list_no = index;
				ApplyMusicInfo();
			};
			m_musicList.OnUpdateClip = () =>
			{
				//0xBF00FC
				DelayedApplyMusicInfo();
			};
			m_musicList.MusicScrollView.CenterItem.OnRewardButtonClickListener = () =>
			{
				//0xBF010C
				OnClickRewardButton(this.OpenRewardWindow);
			};
			m_musicList.MusicScrollView.CenterItem.OnMusicInfoButtonClickListener = () =>
			{
				//0xBF01A0
				TodoLogger.LogNotImplemented("OnMusicInfoButtonClickListener");
			};
			m_musicList.MusicScrollView.CenterItem.OnEnemyInfoButtonClickListener = () =>
			{
				//0xBF01F0
				TodoLogger.LogNotImplemented("OnEnemyInfoButtonClickListener");
			};
			m_musicList.MusicScrollView.CenterItem.OnRankingButtonClickListener = () =>
			{
				//0xBF0240
				TodoLogger.LogNotImplemented("OnRankingButtonClickListener");
			};
			m_musicList.MusicScrollView.OnScrollStartEvent.RemoveAllListeners();
			m_musicList.MusicScrollView.OnScrollStartEvent.AddListener(() =>
			{
				//0xBF02C4
				OnScrollStartEvent();
			});
			m_musicList.MusicScrollView.OnScrollEndEvent.RemoveAllListeners();
			m_musicList.MusicScrollView.OnScrollEndEvent.AddListener(() =>
			{
				//0xBF02C8
				OnScrollEndEvent();
			});
			m_musicDetail.OnUnitButtonClickListener = (int index) =>
			{
				//0xBF02CC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_musicSelectUISapporter.SetUnitButton(index, selectMusicData);
			};
			m_musicDetail.OnMusicBookMarkButtonClickListener = () =>
			{
				//0xBF02D0
				TodoLogger.LogNotImplemented("OnMusicBookMarkButtonClickListener");
			};
			m_musicDetail.OnJacketButtonClickListener = () =>
			{
				//0xBF036C
				TodoLogger.LogNotImplemented("OnJacketButtonClickListener");
			};
			m_musicDetail.OnEventDetailClickListener = () =>
			{
				//0xBF0370
				TodoLogger.LogNotImplemented("OnEventDetailClickListener");
			};
			m_musicDetail.OnEventRewardClickListener = () =>
			{
				//0xBF0378
				TodoLogger.LogNotImplemented("OnEventRewardClickListener");
			};
			m_difficultyButtonGroup.OnButtonClickListener = (int index) =>
			{
				//0xBF0380
				OnClickDifficultyButton(index);
			};
			m_filterButton.OnClickButtonListener = () =>
			{
				//0xBF0390
				TodoLogger.LogNotImplemented("m_filterButton OnClickButtonListener");
			};
			m_seriesButtonGroup.OnButtonClickListener = (int index) =>
			{
				//0xBF0394
				m_musicList.MusicScrollView.SetPosition(list_no);
				OnClickSeriesButton(index);
			};
			m_line6Button.OnClickButtonListener = () =>
			{
				//0xBF0404
				m_musicList.MusicScrollView.SetPosition(list_no);
				OnClickLine6Button();
			};
			m_simulationButton.OnClickButtonListener = (bool isSimulation) =>
			{
				//0xBF046C
				m_musicList.MusicScrollView.SetPosition(list_no);
				OnClickPlayButton(isSimulation);
			};
			m_playButton.OnClicButtonListener = (bool isSimulation) =>
			{
				//0xBF04E0
				m_musicList.MusicScrollView.SetPosition(list_no);
				OnClickPlayButton(isSimulation);
			};
			m_utaRate.onClickButton = () =>
			{
				//0xBF0554
				TodoLogger.LogNotImplemented("m_utaRate onClickButton");
			};
			m_eventBanner.OnButtonClickListener = () =>
			{
				//0xBF05C0
				TodoLogger.LogNotImplemented("m_eventBanner OnButtonClickListener");
			};
			m_choiceMusicTab.OnButtonClickListener = (bool index) =>
			{
				m_musicList.MusicScrollView.SetPosition(list_no);
				OnClickMusicTabButton(index);
			};
			m_orderButton.OnClickButtonListener = () =>
			{
				//0xBF0698
				TodoLogger.LogNotImplemented("m_orderButton OnClickButtonListener");
			};
			m_jacketScroll.OnClickJacketButtonListener = (int freeMusicId) =>
			{
				//0xBF06B8
				TodoLogger.LogNotImplemented("m_jacketScroll OnClickJacketButtonListener");
			};
			m_jacketScroll.OnClickCloseButtonListener = () =>
			{
				//0xBF06BC
				TodoLogger.LogNotImplemented("m_jacketScroll OnClickCloseButtonListener");
			};
			m_jacketScroll.scrollList.OnUpdateItem.RemoveAllListeners();
			m_jacketScroll.scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0xBF06C0
				TodoLogger.LogNotImplemented("m_jacketScroll scrollList OnUpdateItem");
			});
			m_musicList.MusicScrollView.ScrollEnable(true);
			ApplyCommonInfo();
			OnChangeFilter();
			m_isEndMyRankRequest = false;
			JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LFOBIPKFOEF(OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN, 0, () =>
			{
				//0xBF0888
				m_isEndMyRankRequest = true;
			}, () =>
			{
				//0xBF0894
				m_isEndMyRankRequest = true;
				m_showScoreRankingPopup = false;
				GotoTitle();
			});
			while (!m_isEndMyRankRequest)
				yield return null;


			TodoLogger.Log(0, "fix that, where is m_isEndPostSetCanvas = true really set ?");
			m_isEndPostSetCanvas = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6014 Offset: 0x6F6014 VA: 0x6F6014
		// // RVA: 0xBE5FB8 Offset: 0xBE5FB8 VA: 0xBE5FB8 Slot: 44
		protected override IEnumerator Co_ActivateScene()
		{
			//0xAC2CE0
			m_isEndActivateScene = false;
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				MenuScene.Instance.InputDisable();
				yield return Co_ShowScoreRankingPopup();
				MenuScene.Instance.InputEnable();
			}
			TodoLogger.Log(0, "DirtyChangeScene stuff");
			m_isEndActivateScene = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F608C Offset: 0x6F608C VA: 0x6F608C
		// // RVA: 0xBE6040 Offset: 0xBE6040 VA: 0xBE6040
		private IEnumerator Co_ShowScoreRankingPopup()
		{
			TodoLogger.Log(0, "Co_ShowScoreRankingPopup");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6104 Offset: 0x6F6104 VA: 0x6F6104
		// // RVA: 0xBE60C8 Offset: 0xBE60C8 VA: 0xBE60C8 Slot: 45
		protected override IEnumerator Co_LoadResourceOnAwake()
		{
			//0xAC3C08
			Font systemFont = GameManager.Instance.GetSystemFont();
			StringBuilder bundleName = new StringBuilder();
			bundleName.Set("ly/038.xab");
			int bundleCount = 0;

			AssetBundleLoadUGUIOperationBase uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectMusicDetail");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF08B4
				instance.transform.SetParent(transform, false);
				m_musicDetail = instance.GetComponentInChildren<VerticalMusicSelectMusicDetail>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectMusicList");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF0984
				instance.transform.SetParent(transform, false);
				m_musicList = instance.GetComponentInChildren<VerticalMusicSelectMusicList>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectUtaRate");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF0A54
				instance.transform.SetParent(transform, false);
				m_utaRate = instance.GetComponentInChildren<VerticalMusicSelectUtaRate>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectDifficulty");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF0B24
				instance.transform.SetParent(transform, false);
				m_difficultyButtonGroup = instance.GetComponentInChildren<VerticalMusicSelectDifficultyButtonGroup>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectLine6Button");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF0BF4
				instance.transform.SetParent(transform, false);
				m_line6Button = instance.GetComponentInChildren<VerticalMusicSelecLine6Button>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectEventItem");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF0CC4
				instance.transform.SetParent(transform, false);
				m_eventItem = instance.GetComponentInChildren<VerticalMusicSelectEventItem>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectSimulationButton");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF0D94
				instance.transform.SetParent(transform, false);
				m_simulationButton = instance.GetComponentInChildren<VerticalMusicSelctSimulationButton>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectPlayButton");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF0E64
				instance.transform.SetParent(transform, false);
				m_playButton = instance.GetComponentInChildren<VerticalMusicSelectPlayButton>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelecChoiceMusicListTab");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF0F34
				instance.transform.SetParent(transform, false);
				m_choiceMusicTab = instance.GetComponentInChildren<VerticalMusicSelecChoiceMusicListTab>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "AllSelect");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF1004
				instance.transform.SetParent(transform, false);
				instance.SetActive(false);
				m_jacketScroll = instance.GetComponentInChildren<MusicJecketScrollView>();
			});
			bundleCount++;

			GameObject baseContent = null;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "AllSelectJuketButton");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xAC2BC4
				baseContent = instance;
				MusicJacketScrollItem item = instance.GetComponentInChildren<MusicJacketScrollItem>();
				item.SetVisible(false);
				m_jacketScroll.scrollList.AddScrollObject(item);
			});
			bundleCount++;

			for (int i = m_jacketScroll.scrollList.ScrollObjectCount - 1; i != 0; i--)
			{
				m_jacketScroll.scrollList.AddScrollObject(UnityEngine.Object.Instantiate<GameObject>(baseContent).GetComponentInChildren<SwapScrollListContent>());
			}

			m_jacketScroll.scrollList.Apply();
			m_jacketScroll.scrollList.SetContentEscapeMode(true);
			m_jacketScroll.Initialize();

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectFilterButton");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF1114
				instance.transform.SetParent(transform, false);
				m_filterButton = instance.GetComponentInChildren<VerticalMusicSelectMusicFilterButton>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectSeries");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF11E4
				instance.transform.SetParent(transform, false);
				m_seriesButtonGroup = instance.GetComponentInChildren<VerticalMusicSelectSeriesButtonGroup > ();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectSortOrderButton");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF12B4
				instance.transform.SetParent(transform, false);
				m_orderButton = instance.GetComponentInChildren<VerticalMusicSelectSortOrder>();
			});
			bundleCount++;

			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "VerticalMusicSelectEventBunner");
			yield return uguiOp;
			yield return uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xBF1384
				instance.transform.SetParent(transform, false);
				m_eventBanner = instance.GetComponentInChildren<VerticalMusicSelectEventBanner>();
			});
			bundleCount++;

			for(int i = 0; i < bundleCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F617C Offset: 0x6F617C VA: 0x6F617C
		// // RVA: 0xBE6150 Offset: 0xBE6150 VA: 0xBE6150 Slot: 46
		protected override IEnumerator Co_WaitForLoaded()
		{
			//0xAC89A0
			yield return null;
		}

		// RVA: 0xBE61C0 Offset: 0xBE61C0 VA: 0xBE61C0 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_musicList.Enter();
			m_musicDetail.Enter();
			m_utaRate.Enter();
			m_difficultyButtonGroup.Enter();
			m_seriesButtonGroup.Enter();
			m_eventBanner.Enter();
			m_eventItem.Enter();
			m_filterButton.Enter();
			m_line6Button.Enter();
			m_simulationButton.Enter();
			m_choiceMusicTab.Enter();
			m_playButton.Enter();
			m_orderButton.Enter();
			MenuScene.Instance.LobbyButtonControl.Setup(HomeLobbyButtonController.Type.DOWN);
		}

		// RVA: 0xBE63FC Offset: 0xBE63FC VA: 0xBE63FC Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_musicList.IsPlaying() && !m_musicDetail.IsPlaying() && !m_utaRate.IsPlaying() && !m_difficultyButtonGroup.IsPlaying() && !m_eventBanner.IsPlaying() && 
				!m_eventItem.IsPlaying() && !m_filterButton.IsPlaying() && !m_line6Button.IsPlaying() && !m_simulationButton.IsPlaying() && !m_choiceMusicTab.IsPlaying() && 
				!m_playButton.IsPlaying() && !m_orderButton.IsPlaying();
		}

		// RVA: 0xBE65C8 Offset: 0xBE65C8 VA: 0xBE65C8 Slot: 12
		protected override void OnStartExitAnimation()
		{
			TodoLogger.Log(0, "!!!");
		}

		// RVA: 0xBE683C Offset: 0xBE683C VA: 0xBE683C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			TodoLogger.Log(0, "!!!");
			return true;
		}

		// RVA: 0xBE6A30 Offset: 0xBE6A30 VA: 0xBE6A30 Slot: 20
		protected override bool OnBgmStart()
		{
			TodoLogger.Log(0, "!!!");
			return base.OnBgmStart();
		}

		// RVA: 0xBE6AFC Offset: 0xBE6AFC VA: 0xBE6AFC Slot: 47
		protected override void OnUpdate()
		{
			return;
		}

		// RVA: 0xBE6B00 Offset: 0xBE6B00 VA: 0xBE6B00 Slot: 48
		protected override void ReleaseScene()
		{
			TodoLogger.Log(0, "!!!");
		}

		// RVA: 0xBE6BA0 Offset: 0xBE6BA0 VA: 0xBE6BA0 Slot: 49
		protected override void ReleaseCache()
		{
			TodoLogger.Log(0, "!!!");
		}

		// RVA: 0xBE6C68 Offset: 0xBE6C68 VA: 0xBE6C68 Slot: 50
		//protected override void OnInputDisable()
		//{
		//	TodoLogger.Log(0, "!!!");
		//}

		// RVA: 0xBE6CAC Offset: 0xBE6CAC VA: 0xBE6CAC Slot: 51
		//protected override void OnInputEnable()
		//{
		//	TodoLogger.Log(0, "!!!");
		//}

		// RVA: 0xBE6CF0 Offset: 0xBE6CF0 VA: 0xBE6CF0 Slot: 55
		protected override int GetDanceDivaCount()
		{
			return m_musicDetail.GetDanceNum();
		}

		// // RVA: 0xBE6D18 Offset: 0xBE6D18 VA: 0xBE6D18
		protected void TryInstall(StringBuilder bundleName, VerticalMusicDataList musicList)
		{
			TodoLogger.Log(0, "TryInstall !!!");
		}

		// // RVA: 0xBE7054 Offset: 0xBE7054 VA: 0xBE7054
		private void SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType type)
		{
			switch(type)
			{
				case VerticalMusicSelectPlayButton.PlayButtonType.PlayEn:
					m_playButton.SetPlayButtonType(VerticalMusicSelectPlayButton.PlayButtonType.PlayEn);
					break;
				case VerticalMusicSelectPlayButton.PlayButtonType.Play:
					m_playButton.SetPlayButtonType(VerticalMusicSelectPlayButton.PlayButtonType.Play);
					break;
				case VerticalMusicSelectPlayButton.PlayButtonType.Event:
					m_playButton.SetPlayButtonType(VerticalMusicSelectPlayButton.PlayButtonType.Event);
					break;
				case VerticalMusicSelectPlayButton.PlayButtonType.Download:
					m_playButton.SetPlayButtonType(VerticalMusicSelectPlayButton.PlayButtonType.Download);
					break;
				case VerticalMusicSelectPlayButton.PlayButtonType.Release:
					m_playButton.SetPlayButtonType(VerticalMusicSelectPlayButton.PlayButtonType.Release);
					break;
				case VerticalMusicSelectPlayButton.PlayButtonType.Story:
					m_playButton.SetPlayButtonType(VerticalMusicSelectPlayButton.PlayButtonType.Story);
					break;
				default:
					return;
			}
		}

		// // RVA: 0xBE7164 Offset: 0xBE7164 VA: 0xBE7164
		public void SetPlayButton(VerticalMusicDataList.MusicListData musicListData)
		{
			m_playButton.SetEnable(true);
			if(musicListData.IsSimulation)
			{
				if (openSimulationLive && !musicListData.ViewMusic.IFNPBIJEPBO_IsDlded)
				{
					SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType.Download);
				}
				else
				{
					m_playButton.SetEnable(false);
				}
			}
			else
			{
				if(musicListData.ViewMusic.BNIAJAKIAJC_IsEventMinigame)
				{
					SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType.Play);
				}
				else if(musicListData.ViewMusic.AJGCPCMLGKO_IsEvent)
				{
					SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType.Event);
				}
				else if(musicListData.IsUnlockable && !musicListData.IsOpen)
				{
					SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType.Story);
				}
				else if(!musicListData.IsOpen)
				{
					SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType.Release);
				}
				else if(!musicListData.ViewMusic.IFNPBIJEPBO_IsDlded)
				{
					SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType.Download);
				}
				else
				{
					SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType.PlayEn);
				}
			}
			if(m_scoreEventCtrl != null)
			{
				if(musicListData.ViewMusic.LEBDMNIGOJB)
				{
					if (m_isScoreEventTimeLimit)
						return;
					m_playButton.SetButtonEnable(false);
				}
			}
		}

		// // RVA: 0xBE7438 Offset: 0xBE7438 VA: 0xBE7438
		public void SetSimulationButton(VerticalMusicDataList.MusicListData musicListData)
		{
			VerticalMusicSelctSimulationButton.ButtonState state;
			m_simulationButton.SetEnable(true);
			if(!musicListData.ViewMusic.BNIAJAKIAJC_IsEventMinigame && !musicListData.ViewMusic.AJGCPCMLGKO_IsEvent)
			{
				if(!musicListData.IsOpen)
				{
					if(!musicListData.IsSimulation)
					{
						if(openSimulationLive)
						{
							state = VerticalMusicSelctSimulationButton.ButtonState.Disable;
						}
						else
						{
							state = VerticalMusicSelctSimulationButton.ButtonState.Lock;
						}
					}
					else if(musicListData.ViewMusic.IFNPBIJEPBO_IsDlded || !openSimulationLive)
					{
						state = VerticalMusicSelctSimulationButton.ButtonState.Lock;
					}
					else
					{
						state = VerticalMusicSelctSimulationButton.ButtonState.Disable;
					}
				}
				else
				{
					if (!musicListData.ViewMusic.IFNPBIJEPBO_IsDlded)
					{
						if(openSimulationLive)
						{
							state = VerticalMusicSelctSimulationButton.ButtonState.Disable;
						}
						else
						{
							state = VerticalMusicSelctSimulationButton.ButtonState.Lock;
						}
					}
					else if(openSimulationLive || RuntimeSettings.CurrentSettings.ForceSimulationOpen)
					{
						state = VerticalMusicSelctSimulationButton.ButtonState.Open;
					}
					else
					{
						state = VerticalMusicSelctSimulationButton.ButtonState.Lock;
					}
				}
				m_simulationButton.SetButtonState(state);
			}
			else
			{
				m_simulationButton.SetEnable(false);
			}
			if(m_scoreEventCtrl != null)
			{
				if(musicListData.ViewMusic.LEBDMNIGOJB)
				{
					if(m_isScoreEventTimeLimit)
					{
						m_simulationButton.SetButtonState(VerticalMusicSelctSimulationButton.ButtonState.Disable);
					}
				}
			}
		}

		// // RVA: 0xBE7728 Offset: 0xBE7728 VA: 0xBE7728
		// public void SetMusicDetailRemainTime(long remainTime, VerticalMusicSelectMusicDetail.MusicRemainTimeType remainTimeType, LimitTimeWatcher.OnEndCallback endCallback) { }

		// // RVA: 0xBE7758 Offset: 0xBE7758 VA: 0xBE7758
		// public void SetTicketDropIcon(int ticketId) { }

		// // RVA: 0xBE7818 Offset: 0xBE7818 VA: 0xBE7818
		private void SetCreateMusicList()
		{
			long date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int lastMusicId = GetLastStoryFreeMusicId();
			int song_Thresold = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("verticalmusicselect_music_type_threshold", 96000);
			m_originalMusicDataList.Clear();
			m_originalEventMusicDataList.Clear();
			for(int i = 0; i < eventCategoryId; i++)
			{
				List<IBJAKJJICBC> l = IBJAKJJICBC.FKDIMODKKJD((int)MUSIC_LIST_TYPE[i], date, true, false, false, false);
				List<IBJAKJJICBC> viewMusicDataList = IBJAKJJICBC.FKDIMODKKJD((int)MUSIC_LIST_TYPE[i], date, true, false, false, true);
				List<VerticalMusicDataList.MusicListData> list1 = VerticalMusicDataList.CreateMusicListData(l, m_eventCtrl, false, song_Thresold, lastMusicId);
				List<VerticalMusicDataList.MusicListData> list2 = VerticalMusicDataList.CreateMusicListData(viewMusicDataList, m_eventCtrl, true, song_Thresold, lastMusicId);
				VerticalMusicDataList datalist = new VerticalMusicDataList();
				UnityEngine.Debug.Log("m_originalMusicDataList add 1 "+list1.Count);
				datalist.AddList(list1, false, false);
				UnityEngine.Debug.Log("m_originalMusicDataList add 1 "+list2.Count);
				datalist.AddList(list2, true, false);
				datalist.AddList(new List<VerticalMusicDataList.MusicListData>(), false, true);
				datalist.AddList(new List<VerticalMusicDataList.MusicListData>(), true, true);
				m_originalMusicDataList.Add(datalist);
			}
			List<IBJAKJJICBC> l2 = IBJAKJJICBC.FKDIMODKKJD(5, date, true, false, false, false);
			List<IBJAKJJICBC> l3 = IBJAKJJICBC.FKDIMODKKJD(5, date, true, false, false, true);
			List<IBJAKJJICBC> l4 = IBJAKJJICBC.LIENJMIJMIE(date, false);
			List<IBJAKJJICBC> l5 = new List<IBJAKJJICBC>();
			foreach(IBJAKJJICBC a in l4)
			{
				bool diff = true;
				foreach (IBJAKJJICBC b in l2)
				{
					diff &= a.GHBPLHBNMBK_FreeMusicId != b.GHBPLHBNMBK_FreeMusicId;
				}
				if (diff)
					l5.Add(a);
			}
			l2.AddRange(l5);

			l4 = IBJAKJJICBC.LIENJMIJMIE(date, true);
			l5 = new List<IBJAKJJICBC>();
			foreach (IBJAKJJICBC a in l4)
			{
				bool diff = true;
				foreach (IBJAKJJICBC b in l3)
				{
					diff &= a.GHBPLHBNMBK_FreeMusicId != b.GHBPLHBNMBK_FreeMusicId;
				}
				if (diff)
					l5.Add(a);
			}
			l3.AddRange(l5);

			List<VerticalMusicDataList.MusicListData> list3 = VerticalMusicDataList.CreateMusicListData(l2, m_eventCtrl, false, song_Thresold, lastMusicId);
			List<VerticalMusicDataList.MusicListData> list4 = VerticalMusicDataList.CreateMusicListData(l3, m_eventCtrl, false, song_Thresold, lastMusicId);

			VerticalMusicDataList datalist2 = new VerticalMusicDataList();
			UnityEngine.Debug.Log("m_originalMusicDataList add 2 "+list3.Count);
			datalist2.AddList(list3, false, false);
			UnityEngine.Debug.Log("m_originalMusicDataList add 2 "+list4.Count);
			datalist2.AddList(list4, true, false);
			datalist2.AddList(new List<VerticalMusicDataList.MusicListData>(), false, true);
			datalist2.AddList(new List<VerticalMusicDataList.MusicListData>(), true, true);
			m_originalMusicDataList.Add(datalist2);
		}

		// // RVA: 0xBE87B4 Offset: 0xBE87B4 VA: 0xBE87B4
		public void SelectAprilFoolFocus()
		{
			TodoLogger.Log(0, "SelectAprilFoolFocus!!!");
		}

		// // RVA: 0xBE8AE8 Offset: 0xBE8AE8 VA: 0xBE8AE8
		private int GetMinigameListNo(int minigameId)
		{
			TodoLogger.Log(0, "GetMinigameListNo");
			return 0;
		}

		// // RVA: 0xBE8C6C Offset: 0xBE8C6C VA: 0xBE8C6C
		private void SelectArgsFocus(MusicSelectArgs args)
		{
			ILDKBCLAFPB.APLMBKKCNKC_Select.GADJIIFFPFI_NewLive save = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive;
			m_musicSelectUISapporter.isLine6Mode = save.LMPCJJKHHPA_Is6LineMode();
			OHCAABOMEOF.KGOGMKMBCPP_EventType gameEventType = 0;
			int songId = 0;
			save.FKJBADIPKHK_GetSelectedSong(save.OAALFANHEHL_IsEventTab(), out songId, out gameEventType);
			if(m_pickupFreeMusicId > 0)
			{
				songId = m_pickupFreeMusicId;
			}
			m_musicTab = VerticalMusicSelecChoiceMusicListTab.MusicTab.Normal;
			MusicSelectConsts.SeriesType series = save.GPAJHMLOPNP_GetSeries();
			Difficulty.Type diff = save.FFACBDAJJJP_GetDifficulty();
			if (m_pickupFreeCategoryId == 0)
			{
				if(m_pickupFreeMusicId > 0)
				{
					series = MusicSelectConsts.SeriesType.All;
				}
				if (save.OAALFANHEHL_IsEventTab() && m_pickupFreeMusicId < 1)
					m_musicTab = VerticalMusicSelecChoiceMusicListTab.MusicTab.Event;
			}
			else
			{
				series = MusicSelectConsts.SeriesType.All;
				if(m_pickupFreeCategoryId == FreeCategoryId.Type.Event)
				{
					m_musicSelectUISapporter.isLine6Mode = false;
					m_musicTab = VerticalMusicSelecChoiceMusicListTab.MusicTab.Event;
					series = save.GPAJHMLOPNP_GetSeries();
				}
			}
			SetMusicTab(m_musicTab);
			int select_index = 0;
			if(args == null || !args.hasSelection)
			{
				if(gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB)
				{
					select_index = GetMinigameListNo(songId);
				}
				else
				{
					select_index = currentMusicList.FindIndex(songId, gameEventType, m_musicSelectUISapporter.isLine6Mode, false);
					if (select_index < 0)
						select_index = 0;
				}
			}
			else
			{
				TodoLogger.Log(0, "SelectArgsFocus when args");
			}
			list_no = select_index;
			save.HJHBGHMNGKL_SetDifficulty(diff);
			save.GJDEHJBAMNH_SetSeries(series);
			save.ABGEMNAHALF_SetIsEventTab(m_musicTab == VerticalMusicSelecChoiceMusicListTab.MusicTab.Event);
			save.ACGKEJKPFIA_SetSelectedSong(m_musicTab == VerticalMusicSelecChoiceMusicListTab.MusicTab.Event, songId, gameEventType);
			m_musicSelectUISapporter.SetSeries(series);
			m_musicSelectUISapporter.SetDiffity(diff);
			m_musicSelectUISapporter.SetLineTypeToggle(m_musicSelectUISapporter.isLine6Mode);
			SetMusicTab(m_musicTab);
		}

		// // RVA: 0xBE97AC Offset: 0xBE97AC VA: 0xBE97AC
		// private bool CheckShowEventBanner(OHCAABOMEOF.KGOGMKMBCPP eventType) { }

		// // RVA: 0xBE97F0 Offset: 0xBE97F0 VA: 0xBE97F0
		private void ApplyEventInfo()
		{
			m_eventId = 0;
			m_eventIndex = -1;
			m_eventTicketId = 0;
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_eventBanner.SetType(VerticalMusicSelectEventBanner.ButtonType.Disable);
			m_eventItem.SetEnable(false);
			IKDICBBFBMI_EventBase eventInfo = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG, KGCNCBOKCBA.GNENJEHKMHD.BCKENOKGLIJ);
			if(eventInfo != null)
			{
				TodoLogger.Log(0, "ApplyEventInfo");
			}
			if(m_eventCtrl != null)
			{
				TodoLogger.Log(0, "ApplyEventInfo");
			}
			if(m_feverLimit != null)
			{
				m_feverLimit.SetOnOff(false);
			}
			m_scoreEventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI);
			if(m_scoreEventCtrl != null)
			{
				TodoLogger.Log(0, "ApplyEventInfo");
			}
		}

		// // RVA: 0xBEA28C Offset: 0xBEA28C VA: 0xBEA28C
		// private void OnClickEventBanner() { }

		// // RVA: 0xBEA808 Offset: 0xBEA808 VA: 0xBEA808 Slot: 52
		protected override void ApplyCommonInfo()
		{
			m_eventBanner.SetMusicEventRemainPrefix(MessageManager.Instance.GetBank("menu").GetMessageByLabel("music_event_remain_prefix_01"));
			m_eventBanner.ChangeEventBanner(m_eventId);
			GHLGEECLCMH data = new GHLGEECLCMH();
			data.KHEKNNFCAOI(null, null);
			m_musicSelectUISapporter.SetUtaRateIcon(data.LLNHMMBFPMA_ScoreRatingRanking);
			m_musicSelectUISapporter.SetUtaRateRating(data.ECMFBEHEGEH_UtaRateTotal);
			SetMusicTab(m_musicTab);
		}

		// RVA: 0xBEAA40 Offset: 0xBEAA40 VA: 0xBEAA40 Slot: 53
		protected override void ApplyMusicInfo()
		{
			if (listIsEmpty)
				ApplyMusicInfoNone();
			else
			{
				if (selectMusicData.AJGCPCMLGKO_IsEvent || selectMusicData.BNIAJAKIAJC_IsEventMinigame)
					ApplyMusicInfoEventEntrance();
				else
					ApplyMusicInfoNormal();
			}
		}

		// // RVA: 0xBEBC94 Offset: 0xBEBC94 VA: 0xBEBC94
		private int GetChangeBgId(VerticalMusicDataList.MusicListData musicListData)
		{
			if(listIsEmpty)
			{
				return noMusicCategoryId;
			}
			if (musicListData.IsHighLevel)
			{
				return SeriesToNewSeriesBgId[selectMusicData.AIHCEGFANAM_Serie];
			}
			else
			{
				if(musicListData.ViewMusic.DEPGBBJMFED_CategoryId == 0)
				{
					return CategoryToNewSeriesBgId[5];
				}
				return CategoryToNewSeriesBgId[selectMusicData.DEPGBBJMFED_CategoryId];
			}
		}

		// // RVA: 0xBEBF44 Offset: 0xBEBF44 VA: 0xBEBF44 Slot: 54
		protected override void DelayedApplyMusicInfo()
		{
			ApplyMusic();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.GJDEHJBAMNH_SetSeries(series);
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.HJHBGHMNGKL_SetDifficulty(diff);
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.BKFOJBAGDHN_SetIsSmallOrder(sortOrder == VerticalMusicSelectSortOrder.SortOrder.Small);
			VerticalMusicSelecChoiceMusicListTab.MusicTab musicTab = m_musicTab;
			int songId = 0;
			OHCAABOMEOF.KGOGMKMBCPP_EventType eventType = 0;
			if (!listIsEmpty)
			{
				if(selectMusicData.BNIAJAKIAJC_IsEventMinigame)
				{
					songId = selectMusicData.NOKBLCDMLPP_MinigameEventInfo.OOCBPMNHLPM_MusicId;
					eventType = selectMusicData.NOKBLCDMLPP_MinigameEventInfo.HIDHLFCBIDE_EventCategory;
				}
				else
				{
					songId = freeMusicId;
					eventType = (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_EventType;
				}
			}
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.ACGKEJKPFIA_SetSelectedSong(musicTab != VerticalMusicSelecChoiceMusicListTab.MusicTab.Normal, songId, eventType);
			StartCoroutine(Co_ChangeBg(BgType.VerticalMusic, GetChangeBgId(selectMusicListData), null, true));
		}

		// RVA: 0xBEC300 Offset: 0xBEC300 VA: 0xBEC300 Slot: 59
		protected override void OnDecideCurrentMusic(ref MusicDecideInfo info)
		{
			return;
		}

		// // RVA: 0xBEAACC Offset: 0xBEAACC VA: 0xBEAACC
		private void ApplyMusicInfoNone()
		{
			VerticalMusicSelectUISapporter.MusicInfoStyle style = VerticalMusicSelectUISapporter.MusicInfoStyle.NoneFilter;
			if(!m_isListEmptyByFilter && listIsEmpty)
			{
				if (isLine6Mode)
					style = VerticalMusicSelectUISapporter.MusicInfoStyle.None6Line;
			}
			m_difficultyButtonGroup.SetEnable(true);
			m_musicSelectUISapporter.SetMusicInfoStyle(style);
			m_musicSelectUISapporter.SetJacketAttr(0, true);
			m_musicSelectUISapporter.SetWeeklyEventCountEmptyEnable(false);
			m_musicSelectUISapporter.SetMusicTime(null, false);
			m_musicSelectUISapporter.SetDetailEventType(false, VerticalMusicSelectMusicDetail.MusicRemainTimeType.Other, true);
			m_musicDetail.EventCountingEnable(false);
			SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType.Play);
		}

		// // RVA: 0xBEAC3C Offset: 0xBEAC3C VA: 0xBEAC3C
		private void ApplyMusicInfoEventEntrance()
		{
			TodoLogger.Log(0, "ApplyMusicInfoEventEntrance");
		}

		// // RVA: 0xBEB120 Offset: 0xBEB120 VA: 0xBEB120
		private void ApplyMusicInfoNormal()
		{
			m_musicDetail.EventCountingEnable(false);
			m_difficultyButtonGroup.SetEnable(true);
			m_musicSelectUISapporter.SetWeeklyEventCountEmptyEnable(false);
			if (selectMusicData == null)
				return;
			if (selectMusicData.MGJKEJHEBPO_DiffInfos.Count == 0)
				return;
			VerticalMusicSelectUISapporter.MusicInfoStyle infoStyle = VerticalMusicSelectUISapporter.MusicInfoStyle.Music;
			if (!selectMusicListData.IsSimulation && !selectMusicListData.IsOpen)
			{
				infoStyle = VerticalMusicSelectUISapporter.MusicInfoStyle.Lock;
				if (selectMusicListData.IsUnlockable)
					infoStyle = VerticalMusicSelectUISapporter.MusicInfoStyle.Unlockable;
			}
			else
			{
				infoStyle = selectMusicListData.IsSimulation ? VerticalMusicSelectUISapporter.MusicInfoStyle.SLlive : VerticalMusicSelectUISapporter.MusicInfoStyle.Music;
			}
			if(selectMusicData.FGKMJHKLGLD)
			{
				if(selectMusicListData.IsHighLevel)
				{
					m_musicSelectUISapporter.SetDiffity(Difficulty.Type.Extreme);
				}
			}
			m_musicSelectUISapporter.SetMusicInfoStyle(infoStyle);
			SetPlayButton(selectMusicListData);
			SetSimulationButton(selectMusicListData);
			m_musicSelectUISapporter.SetEnergy(selectMusicData);
			m_musicSelectUISapporter.SetEnemyData(selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData);
			m_musicSelectUISapporter.SetMusicJacketNew(selectMusicData);
			m_musicSelectUISapporter.SetMusicJacket(selectMusicData.JNCPEGJGHOG_JacketId);
			m_musicSelectUISapporter.SetMusicLevel(selectMusicData);
			if(selectMusicListData.IsOpen)
			{
				if(!selectMusicListData.IsSimulation)
				{
					m_musicSelectUISapporter.SetMusicScore(selectMusicData);
					m_musicSelectUISapporter.SetMusicTime(selectMusicListData.MusicTimeStr, true);
					m_musicSelectUISapporter.SetMusicUtaRating(selectMusicData.AKAPOCOIECA(), selectMusicData.DEPGBBJMFED_CategoryId != 5);
				}
			}
			m_musicSelectUISapporter.SetupRewardStat(selectMusicData);
			m_musicSelectUISapporter.SetRewardMark(selectMusicData, false);
			m_musicSelectUISapporter.SetDifftatus(selectMusicListData);
			m_musicSelectUISapporter.SetUnitButton(selectMusicData, !selectMusicListData.IsOpen);
			m_musicSelectUISapporter.SetBookMark(m_musicTab == 0, ViewBookMarkMusicData.KNKGEALPDGF(selectMusicData.DLAEJOBELBH_MusicId));
			m_musicSelectUISapporter.SetLineTypeToggle(m_musicSelectUISapporter.isLine6Mode);
			m_musicSelectUISapporter.SetJacketAttr(selectMusicData.FKDCCLPGKDK_JacketAttr, true);
			if(selectMusicData.LHONOILACFL_IsWeeklyEvent)
			{
				m_musicSelectUISapporter.SetDetailEventType(true, VerticalMusicSelectMusicDetail.MusicRemainTimeType.Weekly, true);
				m_musicSelectUISapporter.SetWeeklyEventCount(selectMusicData.MOJMEFIENDM_WeeklyEventCount);
				m_musicSelectUISapporter.SetWeeklyItem(selectMusicData);
				ApplyRemainTime(m_musicDetail, selectMusicData.NKEIFPPGNLH_WeeklyendTime, VerticalMusicSelectMusicDetail.MusicRemainTimeType.Weekly, null);
				m_musicSelectUISapporter.SetWeeklyEventCountEmptyEnable(selectMusicData.MOJMEFIENDM_WeeklyEventCount < 1);
				return;
			}
			if(m_scoreEventCtrl != null && selectMusicData.LEBDMNIGOJB)
			{
				if(m_isScoreEventTimeLimit != false)
				{
					m_musicSelectUISapporter.SetScoreRankingNum(0);
					m_musicSelectUISapporter.SetDetailEventType(true, VerticalMusicSelectMusicDetail.MusicRemainTimeType.ScoreRanking, false);
					ApplyRemainTime(m_musicDetail, m_scoreEventCtrl.DPJCPDKALGI, VerticalMusicSelectMusicDetail.MusicRemainTimeType.ScoreRanking, null);
					m_musicDetail.EventCountingEnable(true);
					return;
				}
				m_musicSelectUISapporter.SetDetailEventType(true, VerticalMusicSelectMusicDetail.MusicRemainTimeType.ScoreRanking, true);
				ApplyRemainTime(m_musicDetail, m_scoreEventCtrl.DPJCPDKALGI, VerticalMusicSelectMusicDetail.MusicRemainTimeType.ScoreRanking, null);
				return;
			}
			if(selectMusicData.FGKMJHKLGLD)
			{
				if(selectMusicListData.IsHighLevel)
				{
					m_musicSelectUISapporter.SetJacketAttr(selectMusicData.FKDCCLPGKDK_JacketAttr, false);
					m_difficultyButtonGroup.SetEnable(false);
					ApplyRemainTime(m_musicDetail, selectMusicListData.AprilFoolEndTime, VerticalMusicSelectMusicDetail.MusicRemainTimeType.HighLevel, null);
					m_musicSelectUISapporter.SetDetailEventType(true, VerticalMusicSelectMusicDetail.MusicRemainTimeType.HighLevel, true);
					return;
				}
				ApplyRemainTime(m_musicDetail, selectMusicListData.AprilFoolEndTime, VerticalMusicSelectMusicDetail.MusicRemainTimeType.Other, null);
				m_musicSelectUISapporter.SetDetailEventType(true, VerticalMusicSelectMusicDetail.MusicRemainTimeType.Other, true);
			}
			else
			{
				if(selectMusicListData.IsSimulation)
				{
					if(selectMusicListData.ViewMusic.EKANGPODCEP_EventId != m_eventCtrl.PGIIDPEGGPI || !m_isEventTimeLimit)
					{
						ApplyRemainTime(m_musicDetail, selectMusicData.ALMOMLMCHNA_OtherEndTime, VerticalMusicSelectMusicDetail.MusicRemainTimeType.Other, null);
						m_musicSelectUISapporter.SetDetailEventType(true, VerticalMusicSelectMusicDetail.MusicRemainTimeType.Other, true);
						return;
					}
					m_musicDetail.EventCountingEnable(true);
				}
				m_musicSelectUISapporter.SetDetailEventType(false, VerticalMusicSelectMusicDetail.MusicRemainTimeType.Other, true);
			}
		}

		// // RVA: 0xBEC304 Offset: 0xBEC304 VA: 0xBEC304
		// private void SetListNo(int no) { }

		// // RVA: 0xBEC314 Offset: 0xBEC314 VA: 0xBEC314 Slot: 57
		protected override void OnClickDifficultyButton(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_musicSelectUISapporter.SetDiffity((Difficulty.Type)index);
			m_musicList.ChangeDifficult(index);
			OnChangeFilter();
		}

		// // RVA: 0xBEC918 Offset: 0xBEC918 VA: 0xBEC918
		private void OnClickSeriesButton(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_musicSelectUISapporter.SetSeries((MusicSelectConsts.SeriesType)index);
			OnChangeFilter();
		}

		// // RVA: 0xBEC9A4 Offset: 0xBEC9A4 VA: 0xBEC9A4
		// protected void OnClickUnitButton(int index) { }

		// // RVA: 0xBECA44 Offset: 0xBECA44 VA: 0xBECA44
		// private void ListChangeItemCallBack(int index) { }

		// // RVA: 0xBECA7C Offset: 0xBECA7C VA: 0xBECA7C
		// private void ListClipItemCallBack() { }

		// // RVA: 0xBECA8C Offset: 0xBECA8C VA: 0xBECA8C
		private void OnScrollStartEvent()
		{
			m_playButton.SetInputEnable(false);
			m_simulationButton.SetInputEnable(false);
			m_difficultyButtonGroup.SetInputEnable(false);
			m_choiceMusicTab.SetToggleEnable(false);
			m_line6Button.SetButtonEnable(false);
		}

		// // RVA: 0xBECB3C Offset: 0xBECB3C VA: 0xBECB3C
		private void OnScrollEndEvent()
		{
			m_playButton.SetInputEnable(true);
			m_simulationButton.SetInputEnable(true);
			m_difficultyButtonGroup.SetInputEnable(true);
			m_choiceMusicTab.SetToggleEnable(true);
			m_line6Button.SetButtonEnable(true);
		}

		// // RVA: 0xBECBEC Offset: 0xBECBEC VA: 0xBECBEC
		private void OnClickLine6Button()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			int selectFreeMusicId = 0;
			OHCAABOMEOF.KGOGMKMBCPP_EventType selectEventCategory = 0;
			if(selectMusicData != null)
			{
				if(selectMusicData.BNIAJAKIAJC_IsEventMinigame)
				{
					selectFreeMusicId = selectMusicData.NOKBLCDMLPP_MinigameEventInfo.OOCBPMNHLPM_MusicId;
					selectEventCategory = selectMusicData.NOKBLCDMLPP_MinigameEventInfo.HIDHLFCBIDE_EventCategory;
				}
				else
				{
					selectFreeMusicId = selectMusicData.GHBPLHBNMBK_FreeMusicId;
					selectEventCategory = (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_EventType;
				}
			}
			m_musicSelectUISapporter.isLine6Mode = !m_musicSelectUISapporter.isLine6Mode;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.HPDBEKAGKOD_SetIsLine6Mode(m_musicSelectUISapporter.isLine6Mode);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			StartCoroutine(m_musicList.Co_UpdateAnim(() =>
			{
				//0xAC29B8
				SetFreeMusicIdByListNo(selectFreeMusicId, selectEventCategory);
				m_musicSelectUISapporter.SetDiffity(diff);
				m_musicSelectUISapporter.SetLineTypeToggle(isLine6Mode);
				OnChangeFilter();
			}));
		}

		// // RVA: 0xBECFD4 Offset: 0xBECFD4 VA: 0xBECFD4 Slot: 56
		//protected override void OnApplyUnitLiveButtonSetting(bool isUnit)
		//{
		//	TodoLogger.Log(0, "!!!");
		//}

		// // RVA: 0xBEAA10 Offset: 0xBEAA10 VA: 0xBEAA10
		private void SetMusicTab(VerticalMusicSelecChoiceMusicListTab.MusicTab type)
		{
			m_choiceMusicTab.SetMusicListTab(type);
		}

		// // RVA: 0xBE97A4 Offset: 0xBE97A4 VA: 0xBE97A4
		// private void SetMusicTab(bool isEvent) { }

		// // RVA: 0xBED05C Offset: 0xBED05C VA: 0xBED05C
		private void OnClickMusicTabButton(bool isNormal)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_musicTab = isNormal ? VerticalMusicSelecChoiceMusicListTab.MusicTab.Normal : VerticalMusicSelecChoiceMusicListTab.MusicTab.Event;
			SetMusicTab(m_musicTab);
			int songId;
			OHCAABOMEOF.KGOGMKMBCPP_EventType eventType;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.FKJBADIPKHK_GetSelectedSong(m_musicTab == VerticalMusicSelecChoiceMusicListTab.MusicTab.Event, out songId, out eventType);
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ADHMDONLHLJ_NewLive.ABGEMNAHALF_SetIsEventTab(m_musicTab == VerticalMusicSelecChoiceMusicListTab.MusicTab.Event);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			SetFreeMusicIdByListNo(songId, eventType);
			StartCoroutine(m_musicList.Co_UpdateAnim(this.OnChangeFilter));
		}

		// // RVA: 0xBED3D0 Offset: 0xBED3D0 VA: 0xBED3D0
		// private void OnClickJacketButton() { }

		// // RVA: 0xBED824 Offset: 0xBED824 VA: 0xBED824
		// private void OnClickClozeJacketButton() { }

		// // RVA: 0xBED9AC Offset: 0xBED9AC VA: 0xBED9AC
		// private void OnClickJacketImageButton(int freeMusicId) { }

		// // RVA: 0xBEDC78 Offset: 0xBEDC78 VA: 0xBEDC78
		// private void OnClickSmallBigButton(VerticalMusicSelectSortOrder.SortOrder sortOrder) { }

		// // RVA: 0xBEDD10 Offset: 0xBEDD10 VA: 0xBEDD10
		private void SetSmallBigOrderButtonEnable()
		{
			m_musicSelectUISapporter.SetSmallBigOrderEnable(m_musicTab == VerticalMusicSelecChoiceMusicListTab.MusicTab.Normal);
		}

		// // RVA: 0xBEDD4C Offset: 0xBEDD4C VA: 0xBEDD4C
		private void SetSeriesButtonEnable()
		{
			m_musicSelectUISapporter.SetSeriesButtonEnable(m_musicTab == VerticalMusicSelecChoiceMusicListTab.MusicTab.Normal);
		}

		// // RVA: 0xBEDD88 Offset: 0xBEDD88 VA: 0xBEDD88
		private void MusicDataListSort()
		{
			var list1 = m_filterMusicDataList.GetList(false, false);
			var list2 = m_filterMusicDataList.GetList(true, false);
			list1.Sort(this.MusicDataListSortCb);
			list2.Sort(this.MusicDataListSortCb);
			if (sortOrder == VerticalMusicSelectSortOrder.SortOrder.Big)
			{
				list1.Reverse();
				list2.Reverse();
			}
			list1 = m_filterMusicEventDataList.GetList(false, false);
			list2 = m_filterMusicEventDataList.GetList(true, false);
			list1.Sort(this.EventMusicDataListSortCb);
			list2.Sort(this.EventMusicDataListSortCb);
		}

		// // RVA: 0xBEE154 Offset: 0xBEE154 VA: 0xBEE154
		private int MusicDataListSortCb(VerticalMusicDataList.MusicListData left, VerticalMusicDataList.MusicListData right)
		{
			TodoLogger.Log(0, "MusicDataListSortCb");
			return left.ViewMusic.DLAEJOBELBH_MusicId.CompareTo(right.ViewMusic.DLAEJOBELBH_MusicId);
		}

		// // RVA: 0xBEE6D8 Offset: 0xBEE6D8 VA: 0xBEE6D8
		private int EventMusicDataListSortCb(VerticalMusicDataList.MusicListData left, VerticalMusicDataList.MusicListData right)
		{
			TodoLogger.Log(0, "EventMusicDataListSortCb");
			return left.ViewMusic.DLAEJOBELBH_MusicId.CompareTo(right.ViewMusic.DLAEJOBELBH_MusicId);
		}

		// // RVA: 0xBEE8C0 Offset: 0xBEE8C0 VA: 0xBEE8C0
		private bool IsFilter()
		{
			ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.CLBMCCEEDGE_VerticalMusicSelect data = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect;
			if ((data.ALGFGPCPGFK_filterRange | data.AONOGHPAENH_filterMusicUnLock | data.DPDBMECAIIO_NumUnitsFilterBits | data.JJNLEPEKNDO_ComboFilterBits | data.EOCPIGDIFNB_MusicAttrFilterBits | data.PGMJCBIHNHK_RewardFilterBits) != 0)
				return true;
			return data.GONLKIDILLH_BookmarkIndex != 0;
		}

		// // RVA: 0xBEEA68 Offset: 0xBEEA68 VA: 0xBEEA68
		private void SetMusicFilterButton()
		{
			m_filterButton.SetButtonStatus(IsFilter() ? VerticalMusicSelectMusicFilterButton.ButtonStatusType.FilterOn : VerticalMusicSelectMusicFilterButton.ButtonStatusType.FilterOff);
		}

		// // RVA: 0xBEEAA8 Offset: 0xBEEAA8 VA: 0xBEEAA8
		private void SetMusicFilterButtonEnable()
		{
			m_filterButton.SetButtonEnable(m_musicTab == VerticalMusicSelecChoiceMusicListTab.MusicTab.Normal);
		}

		// // RVA: 0xBEEAE0 Offset: 0xBEEAE0 VA: 0xBEEAE0
		private void SetMusicFilterSortText()
		{
			return;
		}

		// // RVA: 0xBEEBC4 Offset: 0xBEEBC4 VA: 0xBEEBC4
		private void CheckListEmptyByFilter()
		{
			m_isListEmptyByFilter = false;
			if(IsFilter())
			{
				m_isListEmptyByFilter = currentMusicList.GetCount(m_musicSelectUISapporter.isLine6Mode, false) == 0;
			}
		}

		// // RVA: 0xBED2FC Offset: 0xBED2FC VA: 0xBED2FC
		private void SetFreeMusicIdByListNo(int freeMusicId, OHCAABOMEOF.KGOGMKMBCPP_EventType gameEventType)
		{
			if(!listIsEmpty)
			{
				if(gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB)
				{
					list_no = GetMinigameListNo(freeMusicId);
				}
				else
				{
					list_no = currentMusicList.FindIndex(freeMusicId, m_musicSelectUISapporter.isLine6Mode, false);
				}
				if (list_no < 1)
					list_no = 0;
				return;
			}
			list_no = 0;
		}

		// // RVA: 0xBEC3C0 Offset: 0xBEC3C0 VA: 0xBEC3C0
		private void OnChangeFilter()
		{
			int freeMusicId = 0;
			OHCAABOMEOF.KGOGMKMBCPP_EventType gameEventType = 0;
			if(!listIsEmpty)
			{
				if(selectMusicData != null)
				{
					if(selectMusicData.BNIAJAKIAJC_IsEventMinigame)
					{
						freeMusicId = selectMusicData.NOKBLCDMLPP_MinigameEventInfo.OOCBPMNHLPM_MusicId;
						gameEventType = selectMusicData.NOKBLCDMLPP_MinigameEventInfo.HIDHLFCBIDE_EventCategory;
					}
					else
					{
						freeMusicId = selectMusicData.GHBPLHBNMBK_FreeMusicId;
						gameEventType = (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_EventType;
					}
				}
			}
			SetMusicFilterButton();
			SetMusicFilterButtonEnable();
			SetMusicFilterSortText();
			SetSmallBigOrderButtonEnable();
			SetSeriesButtonEnable();
			long currentTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			CrateFilterDataList(m_filterMusicDataList, m_originalMusicDataList, (int)VerticalMusicSelectSeriesButtonGroup.CONVERT_SERIES_LIST[(int)series], currentTime, this.CheckMatchFilterFunc);
			CrateFilterDataList(m_filterMusicEventDataList, m_originalEventMusicDataList, 0, currentTime, (VerticalMusicDataList.MusicListData s, int c, long f) =>
			{
				//0xAC29A8
				return true;
			});
			CheckListEmptyByFilter();
			MusicDataListSort();
			SetFreeMusicIdByListNo(freeMusicId, gameEventType);
			m_musicList.SetMusicDataList(currentMusicList.GetList(isLine6Mode, false), list_no, (int)diff);
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
		}

		// // RVA: 0xBEEC50 Offset: 0xBEEC50 VA: 0xBEEC50
		// private void OnClickFilterButton() { }

		// // RVA: 0xBEEE70 Offset: 0xBEEE70 VA: 0xBEEE70
		private bool CheckMatchFilterFunc(VerticalMusicDataList.MusicListData musicListData, int series, long currentTime)
		{
			if(m_musicTab != VerticalMusicSelecChoiceMusicListTab.MusicTab.Event)
			{
				if(!musicListData.ViewMusic.KDAJEGNBOFJ)
				{
					ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.CLBMCCEEDGE_VerticalMusicSelect data = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect;
					if(CheckMusicFilter_Series(series, musicListData.ViewMusic) && CheckMusicFilter_MusicAttr(data.EOCPIGDIFNB_MusicAttrFilterBits, musicListData.ViewMusic) &&
						CheckMusicFilter_Combo(data.JJNLEPEKNDO_ComboFilterBits, musicListData.ViewMusic, diff) && CheckMusicFilter_Reward(data.PGMJCBIHNHK_RewardFilterBits, musicListData.ViewMusic, diff, m_musicSelectUISapporter.isLine6Mode) &&
						CheckMusicFilter_Unit(data.DPDBMECAIIO_NumUnitsFilterBits, musicListData.ViewMusic) && CheckMusicFilter_MusicBookMark(data.GONLKIDILLH_BookmarkIndex, musicListData.ViewMusic))
					{
						if(data.AONOGHPAENH_filterMusicUnLock != 0)
						{
							if ((data.AONOGHPAENH_filterMusicUnLock & 1) == 0 || (data.AONOGHPAENH_filterMusicUnLock & 2) == 0)
								return false;
							bool res = data.ALGFGPCPGFK_filterRange == 0 || ((int)musicListData.TimeType & data.ALGFGPCPGFK_filterRange) == 0;
							if((data.ALGFGPCPGFK_filterRange & 2) != 0)
							{
								if (musicListData.TimeType == MusicSelectConsts.MusicTimeType.Short)
									res = true;
							}
							return res;
						}
					}
				}
			}
			return true;
		}

		// // RVA: 0xBEF1E8 Offset: 0xBEF1E8 VA: 0xBEF1E8
		private bool CheckMusicFilter_Series(int series, IBJAKJJICBC musicData)
		{
			return musicData.AIHCEGFANAM_Serie == series;
		}

		// // RVA: 0xBEF238 Offset: 0xBEF238 VA: 0xBEF238
		private bool CheckMusicFilter_MusicAttr(int filterBit, IBJAKJJICBC musicData)
		{
			if(filterBit != 0)
			{
				return PopupSortMenu.IsAttributeFilterOn(musicData.FKDCCLPGKDK_JacketAttr, (uint)filterBit);
			}
			return true;
		}

		// // RVA: 0xBEF2F4 Offset: 0xBEF2F4 VA: 0xBEF2F4
		private bool CheckMusicFilter_Combo(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			if(filterBit != 0)
			{
				if((filterBit & 1) != 0)
				{
					if (musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].LCOHGOIDMDF_ComboRank > 0)
						return false;
				}
				if ((filterBit & 2) == 0)
					return true;
				else
				{
					if (musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].LCOHGOIDMDF_ComboRank >= 2)
						return false;
				}
			}
			return true;
		}

		// // RVA: 0xBEF460 Offset: 0xBEF460 VA: 0xBEF460
		private bool CheckMusicFilter_Reward(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty, bool isLine6Mode)
		{
			if(filterBit != 0)
			{
				FPGEMAIAMBF_RewardData data = new FPGEMAIAMBF_RewardData();
				data.JMHCEMHPPCM(musicData.GHBPLHBNMBK_FreeMusicId, (int)difficulty, isLine6Mode, musicData.MNNHHJBBICA_EventType);
				if((filterBit & 1) != 0)
				{
					if (PopupSortMenu.IsAllRewardAchievedFilter(data.PDONJHCHBAE_ScoreReward))
						return false;
				}
				if((filterBit & 2) != 0)
				{
					if (PopupSortMenu.IsAllRewardAchievedFilter(data.HFPMKBAANFO_ComboReward))
						return false;
				}
				if ((filterBit & 4) == 0)
					return true;
				else
				{
					if (PopupSortMenu.IsAllRewardAchievedFilter(data.IOCLNNCJFKA_ClearReward))
						return false;
				}
			}
			return true;
		}

		// // RVA: 0xBEF690 Offset: 0xBEF690 VA: 0xBEF690
		private bool CheckMusicFilter_Unit(int filterBit, IBJAKJJICBC musicData)
		{
			if(filterBit != 0)
			{
				bool res = false;
				bool val = musicData.PNKKJEABNFF(0);
				if((filterBit & 1) != 0)
				{
					res = musicData.BENDFLDLIAG_IsAvaiableForNumDiva(1);
				}
				if((filterBit & 2) != 0)
				{
					res |= val && musicData.BENDFLDLIAG_IsAvaiableForNumDiva(2);
				}
				if ((filterBit & 4) != 0)
				{
					res |= val && musicData.BENDFLDLIAG_IsAvaiableForNumDiva(3);
				}
				if ((filterBit & 8) != 0)
				{
					res |= val && musicData.BENDFLDLIAG_IsAvaiableForNumDiva(5);
				}
				return res;
			}
			return true;
		}

		// // RVA: 0xBEF7A8 Offset: 0xBEF7A8 VA: 0xBEF7A8
		private bool CheckMusicFilter_MusicBookMark(int index, IBJAKJJICBC musicData)
		{
			if (index == 0)
				return true;
			return ViewBookMarkMusicData.KNKGEALPDGF(musicData.DLAEJOBELBH_MusicId, index - 1);
		}

		// // RVA: 0xBEF7F4 Offset: 0xBEF7F4 VA: 0xBEF7F4
		// private bool CheckMusicFilter_MusicUnlock(int filterBit, bool isOpen) { }

		// // RVA: 0xBEF814 Offset: 0xBEF814 VA: 0xBEF814
		// private bool CheckMusicFilter_MusicRange(int filterBit, MusicSelectConsts.MusicTimeType timeType) { }

		// // RVA: 0xBEF84C Offset: 0xBEF84C VA: 0xBEF84C
		private bool IsCanDoUnitHelp()
		{
			TodoLogger.Log(0, "IsCanDoUnitHelp");
			return false;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6F61F4 Offset: 0x6F61F4 VA: 0x6F61F4
		// // RVA: 0xBF00B8 Offset: 0xBF00B8 VA: 0xBF00B8
		// private void <Co_OnPreSetCanvas>b__63_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F63C4 Offset: 0x6F63C4 VA: 0x6F63C4
		// // RVA: 0xBF08A4 Offset: 0xBF08A4 VA: 0xBF08A4
		// private void <Co_ActivateScene>b__71_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F63D4 Offset: 0x6F63D4 VA: 0x6F63D4
		// // RVA: 0xBF08AC Offset: 0xBF08AC VA: 0xBF08AC
		// private void <Co_ActivateScene>b__71_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F64C4 Offset: 0x6F64C4 VA: 0x6F64C4
		// // RVA: 0xBF1454 Offset: 0xBF1454 VA: 0xBF1454
		// private void <ApplyEventInfo>b__97_0(long current, long limit, long remain) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F64D4 Offset: 0x6F64D4 VA: 0x6F64D4
		// // RVA: 0xBF1480 Offset: 0xBF1480 VA: 0xBF1480
		// private void <OnClickClozeJacketButton>b__121_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F64E4 Offset: 0x6F64E4 VA: 0x6F64E4
		// // RVA: 0xBF152C Offset: 0xBF152C VA: 0xBF152C
		// private void <OnClickJacketImageButton>b__122_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F64F4 Offset: 0x6F64F4 VA: 0x6F64F4
		// // RVA: 0xBF15D8 Offset: 0xBF15D8 VA: 0xBF15D8
		// private void <OnClickFilterButton>b__136_0(PopupFilterSortUGUI content) { }
	}
}
