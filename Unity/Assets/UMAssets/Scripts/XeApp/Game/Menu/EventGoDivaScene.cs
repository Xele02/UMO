using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Menu.EventGoDiva;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EventGoDivaScene : EventMusicSelectSceneBase
	{
		private enum PageType
		{
			None = 0,
			DivaStatus = 1,
			DivaView = 2,
			EventHome = 3,
			MusicSelect = 4,
			EventEnd = 5,
			Num = 6,
		}

		private enum MusicReselectPopupType
		{
			None = 0,
			CountLimit = 1,
			TimeLimit = 2,
			Num = 3,
		}

		private class MusicPosInfo
		{
			public FreeCategoryId.Type categoryId; // 0x8
			public int musicListNo; // 0xC

			// public int categoryIndex { get; }0x13B1054

			// RVA: 0x13B1060 Offset: 0x13B1060 VA: 0x13B1060
			public MusicPosInfo(FreeCategoryId.Type categoryId, int musicListNo)
			{
				this.categoryId = categoryId;
				this.musicListNo = musicListNo;
			}

			// RVA: 0x13B1088 Offset: 0x13B1088 VA: 0x13B1088
			public MusicPosInfo(int categoryIndex, int musicListNo)
			{
				categoryId = (FreeCategoryId.Type)(categoryIndex + 1);
				this.musicListNo = musicListNo;
			}
		}

		private enum BonusItemStatus
		{
			CanUse = 0,
			NotHave = 1,
			DailyLimit = 2,
			OnFever = 3,
			OnBonus = 4,
		}

		private class PlayButton : PlayButtonWrapper
		{
			public override MusicSelectCDSelect baseUI { get; protected set; } // 0x8

			// RVA: 0x13B10C4 Offset: 0x13B10C4 VA: 0x13B10C4
			public PlayButton(MusicSelectCDSelect ui)
			{
				baseUI = ui;
			}

			// RVA: 0x13B10F8 Offset: 0x13B10F8 VA: 0x13B10F8 Slot: 6
			public override void Enter(bool immediate/* = False*/)
			{
				baseUI.EnterPlayButton(immediate);
			}

			// RVA: 0x13B113C Offset: 0x13B113C VA: 0x13B113C Slot: 7
			public override void Leave(bool immediate/* = False*/)
			{
				baseUI.LeavePlayButton(immediate);
			}

			// RVA: 0x13B1180 Offset: 0x13B1180 VA: 0x13B1180 Slot: 8
			public override void SetDisable(bool disable)
			{
				baseUI.SetPlayButtonDisable(disable);
			}

			// RVA: 0x13B11C4 Offset: 0x13B11C4 VA: 0x13B11C4 Slot: 9
			public override void SetType(Type type)
			{
				switch(type)
				{
					case Type.PlayEn:
					case Type.Play:
					case Type.Event:
					case Type.Live:
					case Type.Ok:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Ok);
						break;
					case Type.Download:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Download);
						break;
				}
			}

			// RVA: 0x13B1264 Offset: 0x13B1264 VA: 0x13B1264 Slot: 10
			public override void SetNeedEnergy(int en)
			{
				baseUI.SetNeedEnergy(en);
			}
		}

		public static bool IsViewedBonusOpenPopup = false; // 0x0
		public static bool IsViewedBonusClosePopup = true; // 0x1
		protected MusicSelectEventBanner m_eventBanner; // 0xA4
		protected LayoutEventGoDivaFeverLimit m_feverLimit; // 0xA8
		private LayoutEventGoDivaEventInfo m_eventInfo; // 0xAC
		private LayoutEventGoDivaDivaSelectButton m_selectDiva; // 0xB0
		private LayoutEventGoDivaDivaDecideButton m_decideDiva; // 0xB4
		private LayoutEventGoDivaViewControlButton m_viewControl; // 0xB8
		private LayoutEventGoDivaRadarChart m_radarChart; // 0xBC
		private LayoutEventGoDivaMusicInfo m_eventMusicInfo; // 0xC0
		private MusicSelectButtonSet m_buttonSet; // 0xC4
		private MusicSelectMusicRate m_musicRate; // 0xC8
		private MusicSelectSeriesInfo m_seriesInfo; // 0xCC
		private MusicSelectCDSelect m_cdSelect; // 0xD0
		private MusicSelectCDArrow m_cdArrow; // 0xD4
		private MusicSelectMusicInfo m_musicInfo; // 0xD8
		private MusicSelectLineButton m_lineButton; // 0xDC
		private MusicSelectMusicFilterButton m_filterButton; // 0xE0
		private MusicSelectUISupporter m_musicSelectSupporter = new MusicSelectUISupporter(); // 0xE4
		private PlayButtonWrapper m_playButtonUI; // 0xE8
		private EventTimeLimitMessage m_timeLimitMessage; // 0xEC
		private PageType m_firstPageType; // 0xF0
		private PageType m_currentPageType; // 0xF4
		private bool[] m_pageShownFlags = new bool[6]; // 0xF8
		private bool m_isDivaSelected; // 0xFC
		private BBOPDOIIOGM m_eventGoDivaData; // 0x100
		private EventHelpInfo m_eventHelpInfo; // 0x104
		private Camera m_divaCamera; // 0x10C
		private EventGoDivaCamera m_godivaCamera; // 0x110
		private bool m_isLoadingDiva; // 0x114
		private List<bool> m_divaRankingRequestedFlags; // 0x118
		private bool m_isUpdatingDivaRanking; // 0x11C
		private bool m_isInActionDivaAsyncUpdate; // 0x11D
		private int m_requestAsyncUpdateDivaId; // 0x120
		private bool m_needAppliedMusicSelectSave; // 0x124
		private MusicReselectPopupType m_requestMusicReselectPopupType; // 0x128
		private LimitTimeWatcher m_feverTimeWatcher = new LimitTimeWatcher(); // 0x12C
		private bool m_isInFeverTime; // 0x130
		private long m_feverTimeEnableTime; // 0x138
		private long m_feverTimeRemainTime; // 0x140
		private bool m_isCallGotoTitle; // 0x148
		private StringBuilder m_stringBuilder = new StringBuilder(); // 0x14C
		private int m_divaId; // 0x150
		private GameObject m_loadingEffectPrefab; // 0x154
		private GameObject m_loadingEffectInstance; // 0x158
		private List<MusicDataList> m_originalMusicLists = new List<MusicDataList>(5); // 0x15C
		private List<MusicDataList> m_filteredMusicLists = new List<MusicDataList>(5); // 0x160
		private FreeCategoryId.Type m_musicCategoryId; // 0x164
		private static readonly string[] MusicReselectPopupTextNames = new string[3]
		{
			"", "pop_godiva_music_reselect_text_count_limit", "pop_godiva_music_reselect_text"
		}; // 0x4

		// private bool IsGotoTitle { get; } 0x1063CBC
		private int m_musicListNo { get { return m_musicSelectSupporter.listNo; } set { m_musicSelectSupporter.SetListNo(value);} } //0x1063CE0 0x1063D0C
		private bool m_isLine6Mode { get { return m_musicSelectSupporter.isLine6Mode; } set { m_musicSelectSupporter.isLine6Mode = value; } } //0x1063D40 0x1063D64
		protected override int list_no { get { return m_musicSelectSupporter.listNo; } } //0x1063D8C
		protected override Difficulty.Type diff { get { return m_musicSelectSupporter.difficulty; } } //0x1063D90
		protected override int musicListCount { get { return m_filteredMusicLists.Count; } } //0x1063DBC
		protected override MusicDataList currentMusicList { get { return GetMusicList((int)m_musicCategoryId - 1); } } //0x1063EB4
		protected override bool isLine6ModeFlag { get { return m_musicSelectSupporter.isLine6Mode; } } //0x1063ECC

		// // RVA: 0x1063E34 Offset: 0x1063E34 VA: 0x1063E34 Slot: 34
		protected override MusicDataList GetMusicList(int index)
		{
			return m_filteredMusicLists[index];
		}

		// // RVA: 0x1063EF0 Offset: 0x1063EF0 VA: 0x1063EF0 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(!m_isEventTimeLimit)
				EnterPage(m_firstPageType);
		}

		// // RVA: 0x1063FCC Offset: 0x1063FCC VA: 0x1063FCC Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !IsPlayingPageAnim();
		}

		// // RVA: 0x1064298 Offset: 0x1064298 VA: 0x1064298 Slot: 12
		protected override void OnStartExitAnimation()
		{
			if(m_isEventTimeLimit)
				return;
			if(m_loadingEffectInstance != null)
				Destroy(m_loadingEffectInstance);
			LeavePage();
		}

		// // RVA: 0x106474C Offset: 0x106474C VA: 0x106474C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !IsPlayingPageAnim();
		}

		// // [IteratorStateMachineAttribute] // RVA: 0x6F050C Offset: 0x6F050C VA: 0x6F050C
		// // RVA: 0x1064760 Offset: 0x1064760 VA: 0x1064760 Slot: 37
		protected override IEnumerator Co_LoadLayoutOnAwake()
		{
			StringBuilder bundleName; // 0x14
			FontInfo systemFont; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOp; // 0x20
			AssetBundleLoadUGUIOperationBase uguiOp; // 0x24
			AssetBundleLoadAssetOperation prefOp; // 0x28
			string assetName; // 0x2C
			AssetBundleLoadAllAssetOperationBase operation; // 0x30

			//0x1073D1C
			bundleName = new StringBuilder();
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/038.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventBanner");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10701E0
				instance.transform.SetParent(transform, false);
				m_eventBanner = instance.GetComponent<MusicSelectEventBanner>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_ButtonSet");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10702B0
				instance.transform.SetParent(transform, false);
				m_buttonSet = instance.GetComponent<MusicSelectButtonSet>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicRate");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070380
				instance.transform.SetParent(transform, false);
				m_musicRate = instance.GetComponent<MusicSelectMusicRate>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_SeriesInfo");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070450
				instance.transform.SetParent(transform, false);
				m_seriesInfo = instance.GetComponent<MusicSelectSeriesInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicCD");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070520
				instance.transform.SetParent(transform, false);
				m_cdSelect = instance.GetComponent<MusicSelectCDSelect>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicCDArrow");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10705F0
				instance.transform.SetParent(transform, false);
				m_cdArrow = instance.GetComponent<MusicSelectCDArrow>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicInfo");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10706C0
				instance.transform.SetParent(transform, false);
				m_musicInfo = instance.GetComponent<MusicSelectMusicInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_LineButton");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070790
				instance.transform.SetParent(transform, false);
				m_lineButton = instance.GetComponent<MusicSelectLineButton>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "UGUI_FilterButton");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070860
				instance.transform.SetParent(transform, false);
				m_filterButton = instance.GetComponent<MusicSelectMusicFilterButton>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventEnd");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070930
				instance.transform.SetParent(transform, false);
				m_timeLimitMessage = instance.GetComponent<EventTimeLimitMessage>();
			}));
			bundleLoadCount++;
			prefOp = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), "EventGoDivaCamera", typeof(GameObject));
			yield return prefOp;
			GameObject obj = Instantiate(prefOp.GetAsset<GameObject>());
			obj.transform.SetParent(transform, false);
			obj.GetComponent<Camera>().enabled = false;
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			bundleName.Set("ly/224.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_me3_fever_limit_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070A00
				instance.transform.SetParent(transform, false);
				m_feverLimit = instance.GetComponent<LayoutEventGoDivaFeverLimit>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_me3_info_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070AD0
				instance.transform.SetParent(transform, false);
				m_eventInfo = instance.GetComponent<LayoutEventGoDivaEventInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_me3_diva_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070BA0
				instance.transform.SetParent(transform, false);
				m_selectDiva = instance.GetComponent<LayoutEventGoDivaDivaSelectButton>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_me3_btn_sel_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070C70
				instance.transform.SetParent(transform, false);
				m_decideDiva = instance.GetComponent<LayoutEventGoDivaDivaDecideButton>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_me3_btn_icon_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070D40
				instance.transform.SetParent(transform, false);
				m_viewControl = instance.GetComponent<LayoutEventGoDivaViewControlButton>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_me3_rader_chart_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070E10
				instance.transform.SetParent(transform, false);
				m_radarChart = instance.GetComponent<LayoutEventGoDivaRadarChart>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_me3_music_info_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1070EE0
				instance.transform.SetParent(transform, false);
				m_eventMusicInfo = instance.GetComponent<LayoutEventGoDivaMusicInfo>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_playButtonUI = new PlayButton(m_cdSelect);
			bundleName.Set("ef/cmn.xab");
			assetName = "model_loading";
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			m_loadingEffectPrefab = operation.GetAsset<GameObject>(assetName);
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			for(int i = 0; i < 6; i++)
			{
				m_pageShownFlags[i] = false;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0584 Offset: 0x6F0584 VA: 0x6F0584
		// // RVA: 0x106480C Offset: 0x106480C VA: 0x106480C Slot: 38
		protected override IEnumerator Co_WaitForLoaded()
		{
			//0x13AF1A8
			while(m_eventBanner == null || !m_eventBanner.IsLoaded())
				yield return null;
			while(m_feverLimit == null || !m_feverLimit.IsLoaded())
				yield return null;
			while(m_eventInfo == null || !m_eventInfo.IsLoaded())
				yield return null;
			while(m_selectDiva == null || !m_selectDiva.IsLoaded())
				yield return null;
			while(m_decideDiva == null || !m_decideDiva.IsLoaded())
				yield return null;
			while(m_viewControl == null || !m_viewControl.IsLoaded())
				yield return null;
			while(m_radarChart == null || !m_radarChart.IsLoaded())
				yield return null;
			while(m_eventMusicInfo == null || !m_eventMusicInfo.IsLoaded())
				yield return null;
			while(m_buttonSet == null || !m_buttonSet.IsLoaded())
				yield return null;
			while(m_musicRate == null || !m_musicRate.IsLoaded())
				yield return null;
			while(m_seriesInfo == null || !m_seriesInfo.IsLoaded())
				yield return null;
			while(m_cdSelect == null || !m_cdSelect.IsLoaded())
				yield return null;
			while(m_cdArrow == null || !m_cdArrow.IsLoaded())
				yield return null;
			while(m_musicInfo == null || !m_musicInfo.IsLoaded())
				yield return null;
			while(m_lineButton == null || !m_lineButton.IsLoaded())
				yield return null;
			while(m_filterButton == null)
				yield return null;
			while(m_timeLimitMessage == null || !m_timeLimitMessage.IsLoaded())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F05FC Offset: 0x6F05FC VA: 0x6F05FC
		// // RVA: 0x1064894 Offset: 0x1064894 VA: 0x1064894 Slot: 39
		protected override IEnumerator Co_OnPreSetCanvas()
		{
			//0x13AD884
			EventMusicSelectSceneArgs arg = Args as EventMusicSelectSceneArgs;
			EventMusicSelectSceneArgs argR = ArgsReturn as EventMusicSelectSceneArgs;
			if(arg != null && arg.isFromRhythmGame)
				m_isLine6Mode = arg.isLine6Mode;
			else if(argR != null)
				m_isLine6Mode = argR.isLine6Mode;
			else
				m_isLine6Mode = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.LMPCJJKHHPA_IsLine6();
			GameManager.Instance.SelectedGuestData = null;
			m_eventGoDivaData = new BBOPDOIIOGM();
			m_eventGoDivaData.KHEKNNFCAOI();
			m_originalMusicLists = m_eventGoDivaData.IPJKJBBDFKC;
			if(m_originalMusicLists.Count < 1)
			{
				m_originalMusicLists = new List<MusicDataList>();
				for(int i = 0; i < 6; i++)
				{
					if(i + 1 == 5)
						continue;
					m_originalMusicLists.Add(new MusicDataList(IBJAKJJICBC.GCCBCAKFJMF(i + 1, 0, 0, false), IBJAKJJICBC.GCCBCAKFJMF(i + 1, 0, 0, true)));
				}
			}
			if(PrevTransition == TransitionList.Type.MUSIC_SELECT)
			{
				m_currentPageType = PageType.None;
				for(int i = 0; i < m_pageShownFlags.Length; i++)
				{
					m_pageShownFlags[i] = false;
				}
			}
			if(m_currentPageType != PageType.None)
			{
				CreateDefaultMusicList();
				ApplyFilterButtonStatus();
			}
			else
			{
				m_musicSelectSupporter.SetDifficulty(m_eventGoDivaData.FCHBEILHFBC_Difficulty);
				m_divaId = m_eventGoDivaData.EPCHEDJFAON_SelDiva;
				if(m_divaId < 1)
				{
					m_isDivaSelected = false;
					m_divaId = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId;
				}
				else
				{
					m_isDivaSelected = true;
				}
				m_needAppliedMusicSelectSave = true;
				CreateDefaultMusicList();
				if((!m_isDivaSelected || m_musicSelectSupporter.IsEventEndChallengePeriod) && EventMusicSelect())
				{
					;
				}
				else
				{
					RandomMusicSelect(false, Difficulty.Type.Illegal, false);
				}
			}
			//LAB_013ae0f0
			bool isBgChanging = false;
			if(MenuScene.Instance.BgControl.GetCurrentType() != BgType.MusicEvent)
			{
				isBgChanging = true;
				this.StartCoroutineWatched(Co_ChangeBg(BgType.MusicEvent, m_eventId, () =>
				{
					//0x1071DE0
					isBgChanging = false;
				}));
			}
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("ct/mc/{0:D3}.xab", 0);
			TryInstall(str);
			for(int i = 0; i < m_originalMusicLists.Count; i++)
			{
				TryInstallMusicPict(str, m_originalMusicLists[i], m_isLine6Mode);
			}
			foreach(var d in m_eventGoDivaData.NBIGLBMHEDC_Divas)
			{
				GameManager.Instance.DivaIconCache.TryInstall(d.AHHJLDLAPAN_DivaId, d.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, d.EKFONBFDAAP_ColorId);
			}
			foreach(var d in m_eventGoDivaData.NJIKMDFPNDH)
			{
				GameManager.Instance.ItemTextureCache.TryInstall(d.GLCLFMGPMAN_ItemId, 0);
			}
			SetDivaCamera();
			m_loadingEffectInstance = Instantiate(m_loadingEffectPrefab, new Vector3(0, 0, 0), m_loadingEffectPrefab.transform.rotation);
			m_loadingEffectInstance.SetActive(false);
			while(isBgChanging)
				yield return null;
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			m_eventBanner.Hide();
			m_feverLimit.Hide();
			m_eventInfo.Hide();
			m_selectDiva.Hide();
			m_decideDiva.Hide();
			m_viewControl.Hide();
			m_radarChart.Hide();
			m_eventMusicInfo.Hide();
			m_buttonSet.Hide();
			m_musicRate.Hide();
			m_seriesInfo.Hide();
			m_cdSelect.Hide();
			m_cdArrow.Hide();
			m_musicInfo.Hide();
			m_lineButton.Hide();
			m_filterButton.Hide();
			m_timeLimitMessage.Hide();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0674 Offset: 0x6F0674 VA: 0x6F0674
		// // RVA: 0x106491C Offset: 0x106491C VA: 0x106491C Slot: 40
		protected override IEnumerator Co_OnPostSetCanvas()
		{
			//0x13AB9FC
			bool isError = false;
			NetProcessSetting info = new NetProcessSetting();
			info.AddRankingRequest(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, m_divaId - 1);
			int cnt = m_eventGoDivaData.NBIGLBMHEDC_Divas.Count;
			m_divaRankingRequestedFlags = new List<bool>(cnt);
			for(int i = 0; i < cnt; i++)
			{
				m_divaRankingRequestedFlags.Add(i == m_divaId - 1);
			}
			if(m_divaRankingRequestedFlags.Count < 1)
			{
				cnt = System.Math.Max(1, m_divaId);
				m_divaRankingRequestedFlags = new List<bool>(cnt);
				for(int i = 0; i < cnt; i++)
				{
					m_divaRankingRequestedFlags.Add(m_divaId - 1 == i);
				}
			}
			yield return Co.R(PreEnterNetProcess(info, () =>
			{
				//0x1071DF4
				isError = true;
			}));
			if(isError)
			{
				GotoTitle();
				yield break;
			}
			yield return Co.R(Co_LoadDivaModel(m_divaId, false, false));
			SetupEventHelpInfo(ref m_eventHelpInfo, m_eventCtrl);
			m_cdSelect.transform.SetAsLastSibling();
			m_cdArrow.transform.SetAsLastSibling();
			m_musicRate.transform.SetAsLastSibling();
			m_musicInfo.transform.SetAsLastSibling();
			m_eventMusicInfo.transform.SetAsLastSibling();
			m_buttonSet.transform.SetAsLastSibling();
			m_eventBanner.transform.SetAsLastSibling();
			m_seriesInfo.transform.SetAsLastSibling();
			m_eventInfo.transform.SetAsLastSibling();
			m_radarChart.transform.SetAsLastSibling();
			m_selectDiva.transform.SetAsLastSibling();
			m_decideDiva.transform.SetAsLastSibling();
			m_viewControl.transform.SetAsLastSibling();
			m_timeLimitMessage.transform.SetAsLastSibling();
			m_feverLimit.transform.SetAsLastSibling();
			m_lineButton.transform.SetAsLastSibling();
			m_filterButton.transform.SetAsLastSibling();
			m_eventInfo.OnClickStatusDetailButtonListener = OnClockStatusDetailButton;
			m_decideDiva.OnClickCostumeChangeListener = OnClickCostumeChangeButton;
			m_decideDiva.OnClickOKListener = OnClickDivaSelectOKButton;
			m_eventMusicInfo.OnClickChangeDivaButtonListener = OnClickChangeDivaButton;
			m_eventMusicInfo.OnClickChangeMusicButtonListener = OnClickChangeMusicButton;
			m_eventMusicInfo.OnClickRandomMusicButtonListener = OnClickRandomMusicButton;
			m_eventMusicInfo.OnClickUseBonusItemButtonListener = OnClickUseBonusItemButton;
			m_eventMusicInfo.OnClickPlayButtonListener = OnClickPlayButton;
			m_musicSelectSupporter.Setup(m_musicInfo, m_cdSelect, m_cdArrow, m_playButtonUI, m_eventCtrl, m_unitLiveLocalSaveData, 
				ApplyMusicInfoBasic, OnWebViewClose, OnNetErrorToTitle, LeaveForScrollStart, EnterForScrollEnd, DelayedApplyMusicInfo);
			m_musicSelectSupporter.OnApplyMusicInfoNoneListener = () =>
			{
				//0x1071E00
				m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.None, false, false, false, false);
			};
			m_musicSelectSupporter.OnApplyMusicInfoExEventListener = (IBJAKJJICBC musicData) =>
			{
				//0x1071E60
				m_buttonSet.SetEventRankingCountin(false);
				m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.None, false, false, false, false);
			};
			m_musicSelectSupporter.OnApplyMusicInfoLiveEntranceListener = (IBJAKJJICBC musicData) =>
			{
				//0x1071EFC
				m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.None, false, false, false, false);
			};
			m_musicSelectSupporter.OnApplyMusicInfoNormalListener = OnApplyMusicInfoNormal;
			m_musicSelectSupporter.GetLiveEntranceMessageListener = null;
			m_musicSelectSupporter.OnChangedDifficultyListener = () =>
			{
				//0x1071F5C
				OnChangeMusicFilter(diff);
			};
			m_musicSelectSupporter.eventTicketId = m_eventTicketId;
			m_seriesInfo.onChangedSeries = OnChangedSeries;
			m_cdSelect.onClickPlayButton = OnClickMusicSelectPlayButton;
			m_buttonSet.onClickRankingButton = () =>
			{
				//0x1071FB0
				OnClickRankingButton(selectMusicData);
			};
			m_buttonSet.onClickRewardButton = () =>
			{
				//0x1071FE4
				OnClickRewardButton(OpenRewardWindow);
			};
			m_buttonSet.onClickDetailButton = () =>
			{
				//0x1072078
				OnClickDetailButton(this, selectMusicData, diff);
			};
			m_buttonSet.onClickEventRankingButton = () =>
			{
				//0x10720E8
				OnClickEventRankingButton(selectMusicData, m_eventCtrl.HIDHLFCBIDE_EventType, m_eventStatus, m_eventId, m_eventCtrl, m_divaId);
			};
			m_buttonSet.onClickEventRewardButton = () =>
			{
				//0x1072214
				OnClickEventRewardButton(this, selectMusicData, m_eventCtrl.HIDHLFCBIDE_EventType, m_eventStatus, m_eventId, m_eventCtrl);
			};
			m_buttonSet.onClickStoryButton = () =>
			{
				//0x1072324
				OnClickStoryButton(selectMusicData, m_eventCtrl.HIDHLFCBIDE_EventType, m_eventStatus, m_eventId, m_eventCtrl);
			};
			m_buttonSet.onClickMissionButton = () =>
			{
				//0x1072430
				OnClickMissionButton(selectMusicData, m_eventCtrl.HIDHLFCBIDE_EventType, m_eventStatus, m_eventId, m_eventCtrl);
			};
			m_buttonSet.onClickEnemyInfoButton = () =>
			{
				//0x107253C
				OnClickEnemyInfoButton(this, selectMusicData, diff);
			};
			m_lineButton.onClickButton = OnChangeLineMode;
			m_filterButton.OnClickButtonListener = OnClickFilterButton;
			m_musicInfo.MakeCache();
			m_cdSelect.MakeCache();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_musicInfo.SetNoInfoMessage(bk.GetMessageByLabel("music_not_exist_text_00"), bk.GetMessageByLabel("music_not_exist_line6_text_00"));
			if(m_musicSelectSupporter.IsEventEndChallengePeriod)
			{
				m_isLine6Mode = false;
				CreateDefaultMusicList();
				for(int i = 0; i < m_filteredMusicLists.Count; i++)
				{
					List<IBJAKJJICBC> l = m_filteredMusicLists[i].GetList(m_isLine6Mode, false);
					if(l != null && l.Count > 0)
					{
						m_musicCategoryId = (FreeCategoryId.Type)(i + 1);
						m_musicListNo = 0;
					}
				}
			}
			m_firstPageType = PageType.EventEnd;
			if(!m_musicSelectSupporter.IsEventEndChallengePeriod)
				m_firstPageType = m_currentPageType;
			if(m_currentPageType == PageType.None)
			{
				m_firstPageType = PageType.DivaStatus;
				if(m_isDivaSelected)
					m_firstPageType = PageType.EventHome;
			}
			yield return Co.R(OnPreEnterPage(m_firstPageType, GotoTitle));
			ApplyBasicInfo();
			ApplyEventCommonInfo();
			ApplyDivaInfo(false, GotoTitle, true);
			ApplyMusicListInfo();
			ApplyMusicInfo();
			Database.Instance.bonusData.SetEpisodeBonus(m_eventCtrl.LMDENICBIIB_GetEpisodesBonusList(0, 0));
			while(m_selectDiva.IsLoadingDivaIcon)
				yield return null;
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F06EC Offset: 0x6F06EC VA: 0x6F06EC
		// // RVA: 0x10649A4 Offset: 0x10649A4 VA: 0x10649A4 Slot: 41
		protected override IEnumerator Co_OnActivateScene()
		{
			//0x13A9424
			MenuScene.Instance.RaycastDisable();
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_ShowReciveLoginAchievement(m_eventCtrl));
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(m_eventHelpInfo.isShowFirstHelp)
				{
					yield return Co.R(Co_ShowHelp(this, m_eventHelpInfo));
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene && TutorialProc.CanBeginnerMissionLiveClearLiveHelp())
			{
				MenuScene.Instance.RaycastEnable();
				yield return Co.R(TutorialProc.Co_BeginnerMissionLiveClear(m_cdSelect, null));
				MenuScene.SaveRequest();
				yield break;
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(KDHGBOOECKC.HHCJCDFCLOB.LOCAIBNPKDL_IsPlayerLevelOk() && !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MLBBKNLPBBD_HasShowTuto(BOPFPIHGJMD.PDLKAKEABDP.EILIAPKFCEO_0))
				{
					MenuScene.Instance.RaycastEnable();
					yield return Co.R(TutorialProc.Co_OffeReleaseTutorial(InputLimitButton.VOP, MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.VOP), () =>
					{
						//0x10713D0
						return;
					}, BasicTutorialMessageId.Id_OfferRelease, true, m_cdSelect, null));
					yield break;
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(SettingMenuPanel.IsValkyrieTuneUpUnlock() && !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsValkyrieUpgrade))
				{
					MenuScene.Instance.RaycastEnable();
					yield return Co.R(TutorialProc.Co_ValkyrieUpgrade(MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Setting), BasicTutorialMessageId.Id_ValkyrieUpgradeHome, 
						InputLimitButton.Setting, TutorialPointer.Direction.Down, m_cdSelect, null));
					yield break;
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_CheckUnlock(null));
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(OnEnterPage(m_currentPageType));
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				AddNotice(() =>
				{
					//0x10713D4
					CheckSnsNotice();
				});
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				AddNotice(() =>
				{
					//0x10713DC
					CheckOfferNotice();
				});
			}
			ShowNotice();
			MenuScene.Instance.RaycastEnable();
		}

		// // RVA: 0x1064A2C Offset: 0x1064A2C VA: 0x1064A2C Slot: 42
		protected override void OnUpdate()
		{
			m_musicSelectSupporter.Update();
			m_feverTimeWatcher.Update();
		}

		// // RVA: 0x1064A7C Offset: 0x1064A7C VA: 0x1064A7C Slot: 43
		protected override void ReleaseScene()
		{
			m_musicInfo.ReleaseCache();
			m_cdSelect.ReleaseCache();
			ClearDivaCamera();
			MenuScene.Instance.divaManager.Release(true);
		}

		// // RVA: 0x1064D20 Offset: 0x1064D20 VA: 0x1064D20 Slot: 44
		protected override void ReleaseCache()
		{
			MenuScene.Instance.BgControl.DestroyCacheBg();
		}

		// // RVA: 0x1064DDC Offset: 0x1064DDC VA: 0x1064DDC Slot: 45
		protected override void OnInputDisable()
		{
			if(m_cdSelect != null)
				m_cdSelect.ScrollDisable();
		}

		// // RVA: 0x1064E90 Offset: 0x1064E90 VA: 0x1064E90 Slot: 46
		protected override void OnInputEnable()
		{
			if(InputStateCount > 0)
				return;
			if(m_cdSelect != null)
				m_cdSelect.ScrollEnable();
		}

		// // RVA: 0x1064F5C Offset: 0x1064F5C VA: 0x1064F5C Slot: 47
		protected override void OnEventControlerSetuped(IKDICBBFBMI_EventBase eventCtrl, int eventId, KGCNCBOKCBA.GNENJEHKMHD_EventStatus eventStatus, bool isEventTimeLimit)
		{
			m_musicSelectSupporter.eventId = eventId;
			m_musicSelectSupporter.eventStatus = eventStatus;
			m_musicSelectSupporter.isEventTimeLimit = isEventTimeLimit;
		}

		// // RVA: 0x1064FC0 Offset: 0x1064FC0 VA: 0x1064FC0
		private bool IsBonusOpen(MANPIONIGNO_EventGoDiva.IBNAEKMCIEO bonusInfo)
		{
			return bonusInfo.NOEFINFEMBM > 0 || bonusInfo.PKDAEFIGMLI > 0 || bonusInfo.DGAELGEJPNA > 0;
		}

		// // RVA: 0x106504C Offset: 0x106504C VA: 0x106504C
		private bool IsAnyBonusOpen()
		{
			foreach(var d in m_eventGoDivaData.GEGAEDDGNMA_Bonuses)
			{
				if(IsBonusOpen(d))
					return true;
			}
			return false;
		}

		// // RVA: 0x10651C8 Offset: 0x10651C8 VA: 0x10651C8
		// private void GetMusicExpAndType(IBJAKJJICBC musicData, Difficulty.Type difficulty, long currentTime, out ExpType outExpType, out int outExp) { }

		// // RVA: 0x106531C Offset: 0x106531C VA: 0x106531C
		private int GetMusicExp(IBJAKJJICBC musicData, Difficulty.Type difficulty, long currentTime, ExpType expType)
		{
			int res = 0;
			int type = 0;
			switch(expType)
			{
				case ExpType.Soul:
				case ExpType.All:
					type = 0;
					res = m_eventGoDivaData.APFJJLFMIGN(musicData.GHBPLHBNMBK_FreeMusicId, (int)difficulty, currentTime);
					break;
				case ExpType.Voice:
					type = 1;
					res = m_eventGoDivaData.PKGGEBBLJIN(musicData.GHBPLHBNMBK_FreeMusicId, (int)difficulty, currentTime);
					break;
				case ExpType.Charm:
					type = 2;
					res = m_eventGoDivaData.HLDLLGJIIJJ(musicData.GHBPLHBNMBK_FreeMusicId, (int)difficulty, currentTime);
					break;
			}
			if(musicData.OGHOPBAKEFE_IsEventSpecial && IsAnyBonusOpen())
			{
				res = 0;
				if(m_eventGoDivaData.HODCLEPALGP(type) > 1)
				{
					return m_eventGoDivaData.OCLKNJELBFO(musicData.GHBPLHBNMBK_FreeMusicId, (int)difficulty);
				}
			}
			return res;
		}

		// // RVA: 0x1065224 Offset: 0x1065224 VA: 0x1065224
		private ExpType GetMusicExpType(IBJAKJJICBC musicData, Difficulty.Type difficulty, long currentTime)
		{
			int v1 = GetMusicExp(musicData, difficulty, currentTime, ExpType.Soul);
			int v2 = GetMusicExp(musicData, difficulty, currentTime, ExpType.Voice);
			int v3 = GetMusicExp(musicData, difficulty, currentTime, ExpType.Charm);
			if(v1 < 1 && (v1 < 1 || v2 < 1 || v3 < 1) && v2 < 1)
			{
				if(v3 < 1)
					return ExpType.None;
				return ExpType.Charm;
			}
			ExpType res = ExpType.All;
			if(v1 < 1 || v2 < 1 || v3 < 1)
			{
				res = ExpType.Soul;
			}
			if(v1 < 1 && (v1 < 1 || v2 < 1 || v3 < 1))
			{
				res = ExpType.Voice;
			}
			return res;
		}

		// // RVA: 0x1065558 Offset: 0x1065558 VA: 0x1065558
		private void EnterDivaStatusPage()
		{
			m_eventBanner.TryEnter();
			m_feverLimit.TryEnter();
			m_eventInfo.TryEnter();
			m_selectDiva.TryEnter();
			m_decideDiva.TryEnter();
			m_viewControl.TryEnter();
			m_radarChart.TryEnter();
			MenuScene.Instance.divaManager.SetEnableRenderer(true);
			if(m_divaCamera != null)
				m_divaCamera.enabled = true;
			m_eventMusicInfo.TryLeave();
			m_buttonSet.TryLeave();
			m_musicRate.TryLeave();
			m_seriesInfo.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_musicInfo.TryLeave();
			m_lineButton.TryLeave();
			m_filterButton.TryLeave();
			m_timeLimitMessage.TryLeave();
			MenuScene.Instance.FooterMenu.Leave(false);
		}

		// // RVA: 0x1065920 Offset: 0x1065920 VA: 0x1065920
		private void EnterDivaViewPage()
		{
			m_eventBanner.TryEnter();
			m_feverLimit.TryEnter();
			m_eventInfo.TryEnter();
			m_viewControl.TryEnter();
			m_radarChart.TryEnter();
			MenuScene.Instance.divaManager.SetEnableRenderer(true);
			if(m_divaCamera != null)
				m_divaCamera.enabled = true;
			m_selectDiva.TryLeave();
			m_decideDiva.TryLeave();
			m_eventMusicInfo.TryLeave();
			m_buttonSet.TryLeave();
			m_musicRate.TryLeave();
			m_seriesInfo.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_musicInfo.TryLeave();
			m_lineButton.TryLeave();
			m_filterButton.TryLeave();
			m_timeLimitMessage.TryLeave();
			MenuScene.Instance.FooterMenu.Leave(false);
		}

		// // RVA: 0x1065CE8 Offset: 0x1065CE8 VA: 0x1065CE8
		private void EnterEventHomePage()
		{
			m_eventBanner.TryEnter();
			m_feverLimit.TryEnter();
			m_eventInfo.TryEnter();
			m_eventMusicInfo.TryEnter();
			m_buttonSet.TryEnter();
			MenuScene.Instance.divaManager.SetEnableRenderer(true);
			if(m_divaCamera != null)
				m_divaCamera.enabled = true;
			MenuScene.Instance.FooterMenu.Enter(false);
			m_selectDiva.TryLeave();
			m_decideDiva.TryLeave();
			m_viewControl.TryLeave();
			m_radarChart.TryLeave();
			m_musicRate.TryLeave();
			m_seriesInfo.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_musicInfo.TryLeave();
			m_lineButton.TryLeave();
			m_filterButton.TryLeave();
			m_timeLimitMessage.TryLeave();
		}

		// // RVA: 0x10660B0 Offset: 0x10660B0 VA: 0x10660B0
		private void EnterMusicSelectPage()
		{
			m_eventBanner.TryEnter();
			m_feverLimit.TryEnter();
			m_buttonSet.TryEnter();
			m_musicRate.TryEnter();
			m_seriesInfo.TryEnter();
			m_cdSelect.TryEnter();
			m_cdArrow.TryEnter();
			m_musicInfo.TryEnter();
			foreach(var m in m_originalMusicLists)
			{
				int cnt = m.GetCount(true, false);
				if(cnt > 0)
				{
					m_lineButton.SetUnlock(IBJAKJJICBC.KGJJCAKCMLO());
					m_lineButton.SetUnlockNumber(cnt);
					m_lineButton.TryEnter(m_musicSelectSupporter.isLine6Mode);
					break;
				}
			}
			m_filterButton.TryEnter();
			MenuScene.Instance.FooterMenu.Enter(false);
			m_eventInfo.TryLeave();
			m_selectDiva.TryLeave();
			m_decideDiva.TryLeave();
			m_viewControl.TryLeave();
			m_radarChart.TryLeave();
			m_eventMusicInfo.TryLeave();
			m_timeLimitMessage.TryLeave();
			MenuScene.Instance.divaManager.SetEnableRenderer(false);
			if(m_divaCamera != null)
				m_divaCamera.enabled = false;
		}

		// // RVA: 0x1066610 Offset: 0x1066610 VA: 0x1066610
		private void EnterEventEndPage()
		{
			m_eventBanner.TryEnter();
			m_eventInfo.TryEnter();
			m_selectDiva.TryEnter();
			m_buttonSet.TryEnter();
			m_timeLimitMessage.TryEnter(m_musicSelectSupporter.IsEventCounting);
			MenuScene.Instance.FooterMenu.Enter(false);
			m_feverLimit.TryEnter();
			m_decideDiva.TryLeave();
			m_viewControl.TryLeave();
			m_radarChart.TryLeave();
			m_eventMusicInfo.TryLeave();
			m_musicRate.TryLeave();
			m_seriesInfo.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_musicInfo.TryLeave();
			m_lineButton.TryLeave();
			m_filterButton.TryLeave();
			MenuScene.Instance.divaManager.SetEnableRenderer(false);
			if(m_divaCamera != null)
				m_divaCamera.enabled = false;
		}

		// // RVA: 0x1064384 Offset: 0x1064384 VA: 0x1064384
		private void LeavePage()
		{
			m_eventBanner.TryLeave();
			m_feverLimit.TryLeave();
			m_eventInfo.TryLeave();
			m_selectDiva.TryLeave();
			m_decideDiva.TryLeave();
			m_viewControl.TryLeave();
			m_radarChart.TryLeave();
			m_eventMusicInfo.TryLeave();
			m_buttonSet.TryLeave();
			m_musicRate.TryLeave();
			m_seriesInfo.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_musicInfo.TryLeave();
			m_lineButton.TryLeave();
			m_filterButton.TryLeave();
			m_timeLimitMessage.TryLeave();
			MenuScene.Instance.divaManager.SetEnableRenderer(false);
			if(m_divaCamera != null)
				m_divaCamera.enabled = false;
			MenuScene.Instance.FooterMenu.Leave(false);
		}

		// // RVA: 0x1063FE0 Offset: 0x1063FE0 VA: 0x1063FE0
		private bool IsPlayingPageAnim()
		{
			return m_eventBanner.IsPlaying() || m_feverLimit.IsPlaying() || m_eventInfo.IsPlaying() || m_selectDiva.IsPlaying() ||
				m_decideDiva.IsPlaying() || m_viewControl.IsPlaying() || m_radarChart.IsPlaying() || m_eventMusicInfo.IsPlaying() || 
				m_buttonSet.IsPlaying() || m_musicRate.IsPlaying() || m_seriesInfo.IsPlaying() || m_cdSelect.IsPlaying() || m_cdArrow.IsPlaying() || 
				m_musicInfo.IsPlaying() || m_lineButton.IsPlaying() || m_filterButton.IsPlaying() || m_timeLimitMessage.IsPlaying();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0764 Offset: 0x6F0764 VA: 0x6F0764
		// // RVA: 0x10669D4 Offset: 0x10669D4 VA: 0x10669D4
		private IEnumerator Co_WaitForAnimEnd(Action onEnd)
		{
			//0x13AF05C
			while(IsPlayingPageAnim())
				yield return null;
			if(onEnd != null)
				onEnd();
		}

		// // RVA: 0x1066A78 Offset: 0x1066A78 VA: 0x1066A78
		private void SetDivaCamera()
		{
			m_divaCamera = GetComponentInChildren<Camera>();
			if(m_divaCamera != null)
			{
				MenuScene.Instance.divaManager.GetComponentInChildren<Camera>().enabled = false;
				m_divaCamera.transform.SetParent(MenuScene.Instance.divaManager.transform, false);
				m_godivaCamera = m_divaCamera.GetComponent<EventGoDivaCamera>();
			}
		}

		// // RVA: 0x1064B88 Offset: 0x1064B88 VA: 0x1064B88
		private void ClearDivaCamera()
		{
			if(m_divaCamera != null)
			{
				MenuScene.Instance.divaManager.GetComponentInChildren<Camera>().enabled = true;
				m_divaCamera.transform.SetParent(transform, false);
				m_divaCamera = null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F07DC Offset: 0x6F07DC VA: 0x6F07DC
		// // RVA: 0x1066C90 Offset: 0x1066C90 VA: 0x1066C90
		private IEnumerator Co_LoadDivaModel(int divaId, bool isVisible, bool useLoadingEffect)
		{
			//0x1073660
			while(m_isUpdatingDivaRanking)
				yield return null;
			if(IsRequestGotoTitle || m_isCallGotoTitle)
				yield break;
			m_isLoadingDiva = true;
			MenuScene.Instance.divaManager.SetActive(false, true);
			if(useLoadingEffect)
			{
				m_loadingEffectInstance.SetActive(true);
			}
			MenuScene.Instance.divaManager.Release(true);
			yield return Resources.UnloadUnusedAssets();
			MenuScene.Instance.divaManager.Load(divaId, GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[divaId - 1].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, 
				GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[divaId - 1].EKFONBFDAAP_ColorId, DivaResource.MenuFacialType.Home, false);
			while(MenuScene.Instance.divaManager.IsLoading)
				yield return null;
			m_godivaCamera.SetDiva(divaId);
			MenuScene.Instance.divaManager.OnIdle("");
			yield return new WaitForSeconds(0.1f);
			if(useLoadingEffect)
			{
				m_loadingEffectInstance.SetActive(false);
			}
			if(isVisible)
			{
				MenuScene.Instance.divaManager.SetEnableRenderer(true);
			}
			m_isLoadingDiva = false;
		}

		// // RVA: 0x1066D88 Offset: 0x1066D88 VA: 0x1066D88
		private void ApplyEventCommonInfo()
		{
			m_eventBanner.SetStyle(m_musicSelectSupporter.IsEventEndChallengePeriod ? MusicSelectEventBanner.Style.Enable : MusicSelectEventBanner.Style.Period);
			m_eventBanner.ChangeEventBanner(m_eventId);
			m_bannerTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
			{
				//0x1070FB0
				ApplyEventBannerRemainTime(m_eventBanner, remain, true);
			};
			m_bannerTimeWatcher.onEndCallback = null;
			m_bannerTimeWatcher.WatchStart(m_eventCtrl.DPJCPDKALGI_End1, true);
			if(m_eventCtrl.MNDFBBMNJGN_IsUsingTicket)
			{
				m_cdSelect.EventTicketEnable(false);
				GameManager.Instance.ItemTextureCache.Load(m_eventCtrl.JKIADEKHGLC_TicketItemId, (IiconTexture image) =>
				{
					//0x1070FE0
					m_cdSelect.EventTicketEnable(true);
					m_cdSelect.SetEventTicketIcon(image);
					m_eventBanner.SetEventTicket(image);
				});
			}
			ApplyFeverTimeStatus();
			m_eventInfo.SetTotalPoint(m_eventGoDivaData.AHOKAPCGJMA_Point);
			m_eventInfo.SetStatusItemsVisible(!m_musicSelectSupporter.IsEventEndChallengePeriod);
			if(m_eventGoDivaData.NJIKMDFPNDH.Count > 0 && !m_musicSelectSupporter.IsEventEndChallengePeriod)
			{
				m_eventInfo.SetNextPoint(m_eventGoDivaData.EIIOAPILKCP_MissingPoint);
				m_eventInfo.SetNextRewardTexture(m_eventGoDivaData.NJIKMDFPNDH[0].GLCLFMGPMAN_ItemId);
			}
			else
			{
				m_eventInfo.SetNextPointInvalid();
				m_eventInfo.SetNextRewardTextureInvalid();
			}
			for(int i = 0; i < m_eventGoDivaData.NBIGLBMHEDC_Divas.Count; i++)
			{
				m_selectDiva.SetDivaIcon(m_eventGoDivaData.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId - 1, m_eventGoDivaData.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId, 
					!m_eventGoDivaData.NBIGLBMHEDC_Divas[i].FFKMJNHFFFL_Costume.FJODMPGPDDD_Possessed ? 1 : m_eventGoDivaData.NBIGLBMHEDC_Divas[i].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, 
					!m_eventGoDivaData.NBIGLBMHEDC_Divas[i].FFKMJNHFFFL_Costume.FJODMPGPDDD_Possessed ? 0 : m_eventGoDivaData.NBIGLBMHEDC_Divas[i].EKFONBFDAAP_ColorId, 
					!m_eventGoDivaData.NBIGLBMHEDC_Divas[i].FFKMJNHFFFL_Costume.FJODMPGPDDD_Possessed);
			}
			m_selectDiva.SetSelecting(m_divaId - 1);
		}

		// // RVA: 0x1067428 Offset: 0x1067428 VA: 0x1067428
		private void ApplyFeverTimeStatus()
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(m_eventGoDivaData.GNDOGPBIGIL_GetCurrentBonusRate(t) > 0)
			{
				if(!m_musicSelectSupporter.IsEventEndChallengePeriod)
				{
					m_isInFeverTime = true;
					m_feverTimeEnableTime = t;
					m_feverTimeWatcher.onElapsedCallback = OnFeverTimeElapsed;
					m_feverTimeWatcher.onEndCallback = OnFeverTimeFinish;
					long end = m_eventGoDivaData.KBKGHDFBHAP_GetBonusEndTime(t);
					m_feverTimeWatcher.WatchStart(end, false);
					m_feverTimeRemainTime = end - t;
					m_feverLimit.SetOnOff(true);
					m_feverLimit.SetLimitText(MakeFeverTimeRemainText(m_feverTimeRemainTime));
					return;
				}
			}
			m_feverTimeRemainTime = 0;
			m_isInFeverTime = false;
			m_feverLimit.SetOnOff(false);
		}

		// // RVA: 0x10678B0 Offset: 0x10678B0 VA: 0x10678B0
		private void OnFeverTimeElapsed(long currentTime, long limitTime, long remainTime)
		{
			m_feverTimeEnableTime = currentTime;
			m_feverTimeRemainTime = remainTime;
			m_feverLimit.SetLimitText(MakeFeverTimeRemainText(remainTime));
		}

		// // RVA: 0x1067910 Offset: 0x1067910 VA: 0x1067910
		private void OnFeverTimeFinish(long currentTime)
		{
			ApplyFeverTimeStatus();
			ApplyBonusAndLotsStatus(selectMusicData);
		}

		// // RVA: 0x106774C Offset: 0x106774C VA: 0x106774C
		private string MakeFeverTimeRemainText(long remainTime)
		{
			m_stringBuilder.Set(MessageManager.Instance.GetMessage("menu", "event_godiva_remain_time_prefix"));
			int d, h, m, s;
			MusicSelectSceneBase.ExtractRemainTime((int)remainTime, out d, out h, out m, out s);
			m_stringBuilder.Append(MusicSelectSceneBase.MakeRemainTime(0, h + d * 24, m, s));
			return m_stringBuilder.ToString();
		}

		// // RVA: 0x1067D18 Offset: 0x1067D18 VA: 0x1067D18
		private void ApplyDivaInfo(bool isSelecting, Action GotoTitleFunc, bool isModelEnable/* = True*/)
		{
			m_eventInfo.SetDivaName(m_divaId);
			if(!m_musicSelectSupporter.IsEventEndChallengePeriod)
			{
				m_eventInfo.SetRankingInfo(0, 0, false);
			}
			else
			{
				if(m_musicSelectSupporter.IsEventCounting)
				{
					m_eventInfo.SetRankingInfoCounting(0, false);
				}
				else
				{
					m_eventInfo.SetRankingInfoFinish(0, 0, false);
				}
			}
			int godiva_max_level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("godiva_max_level", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA());
			godiva_max_level = Mathf.Min(godiva_max_level, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA());
			FFHPBEPOMAK_DivaInfo.CLKBDNBMJCO d;
			if(m_divaId <= m_eventGoDivaData.NBIGLBMHEDC_Divas.Count && m_eventGoDivaData.NBIGLBMHEDC_Divas[m_divaId - 1].IHANGGCHPAL != null)
			{
				d = m_eventGoDivaData.NBIGLBMHEDC_Divas[m_divaId - 1].IHANGGCHPAL;
			}
			else
			{
				d = new FFHPBEPOMAK_DivaInfo.CLKBDNBMJCO();
				d.KHEKNNFCAOI(m_divaId);
			}
			m_eventInfo.SetStatusValue(LayoutEventGoDivaEventInfo.StatusType.Soul, d.KAMIJDBFGDB_EvSoLevel, godiva_max_level, m_eventGoDivaData.GGOHAGALIGB_GetDivaSoulExp(m_divaId), m_eventGoDivaData.DFONMIHHAGB_GetDivaSoulMExp(m_divaId), true);
			m_eventInfo.SetStatusValue(LayoutEventGoDivaEventInfo.StatusType.Voice, d.BPEFIIEPJBM_EvVoLevel, godiva_max_level, m_eventGoDivaData.DFKNGEIBBAJ_GetDivaVoiceExp(m_divaId), m_eventGoDivaData.LPGFBLBEJNF_GetDivaVoiceMExp(m_divaId), true);
			m_eventInfo.SetStatusValue(LayoutEventGoDivaEventInfo.StatusType.Charm, d.DNFEEOODOBF_EvChLevel, godiva_max_level, m_eventGoDivaData.HDGGPOIHMPF_GetDivaCharmExp(m_divaId), m_eventGoDivaData.GIAJCLKEONO_GetDivaCharmMExp(m_divaId), true);
			m_selectDiva.SetSelecting(m_divaId - 1);
			m_radarChart.SetMaxStatusValues(godiva_max_level, godiva_max_level, godiva_max_level);
			m_radarChart.SetStatus(d.KAMIJDBFGDB_EvSoLevel, d.BPEFIIEPJBM_EvVoLevel, d.DNFEEOODOBF_EvChLevel);
			if(isSelecting)
			{
				m_requestAsyncUpdateDivaId = m_divaId;
				if(m_isInActionDivaAsyncUpdate)
					return;
				this.StartCoroutineWatched(Co_DivaAsyncUpdate(GotoTitleFunc, isModelEnable));
			}
			else
			{
				this.StartCoroutineWatched(Co_ApplyDivaInfoRanking(m_divaId, GotoTitleFunc));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0854 Offset: 0x6F0854 VA: 0x6F0854
		// // RVA: 0x1068454 Offset: 0x1068454 VA: 0x1068454
		private IEnumerator Co_DivaAsyncUpdate(Action GotoTitleFunc, bool isModelEnable)
		{
			int divaId;

			//0x10734A4
			m_isInActionDivaAsyncUpdate = true;
			divaId = 0;
			while(m_requestAsyncUpdateDivaId != 0 && m_requestAsyncUpdateDivaId != divaId)
			{
				divaId = m_requestAsyncUpdateDivaId;
				m_requestAsyncUpdateDivaId = 0;
				yield return Co.R(Co_ApplyDivaInfoRanking(divaId, GotoTitleFunc));
				if(isModelEnable)
					yield return Co.R(Co_LoadDivaModel(divaId, true, true));
			}
			m_isInActionDivaAsyncUpdate = false;
			m_requestAsyncUpdateDivaId = 0;
		}

		// // RVA: 0x10685F4 Offset: 0x10685F4 VA: 0x10685F4
		private void ApplyDivaInfoRanking(int divaId)
		{
			MANPIONIGNO_EventGoDiva ev = m_eventCtrl as MANPIONIGNO_EventGoDiva;
			if(m_musicSelectSupporter.IsEventEndChallengePeriod)
			{
				if(m_musicSelectSupporter.IsEventCounting)
				{
					m_eventInfo.SetRankingInfoCounting(ev.AFCIIKDOMHN_GetCurrentScore(divaId), ev.CDINKAANIAA_Rank[divaId - 1] > 0);
				}
				else
				{
					m_eventInfo.SetRankingInfoFinish(ev.AFCIIKDOMHN_GetCurrentScore(divaId), ev.CDINKAANIAA_Rank[divaId - 1], ev.CDINKAANIAA_Rank[divaId - 1] > 0);
				}
			}
			else
			{
				m_eventInfo.SetRankingInfo(ev.AFCIIKDOMHN_GetCurrentScore(divaId), ev.CDINKAANIAA_Rank[divaId - 1], ev.CDINKAANIAA_Rank[divaId - 1] > 0);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F08CC Offset: 0x6F08CC VA: 0x6F08CC
		// // RVA: 0x1068514 Offset: 0x1068514 VA: 0x1068514
		private IEnumerator Co_ApplyDivaInfoRanking(int divaId, Action GotoTitleFunc)
		{
			//0x10725B0
			m_isUpdatingDivaRanking = true;
			if(!m_divaRankingRequestedFlags[divaId - 1])
			{
				bool done = false;
				bool err = false;
				JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LFOBIPKFOEF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, divaId - 1, () =>
				{
					//0x1071498
					done = true;
				}, () =>
				{
					//0x10714A4
					done = true;
					err = true;
				}, false);
				while(!done)
					yield return null;
				if(err)
				{
					m_isUpdatingDivaRanking = false;
					GotoTitleFunc();
					yield break;
				}
				m_divaRankingRequestedFlags[divaId - 1] = true;
			}
			//LAB_01072890
			ApplyDivaInfoRanking(divaId);
			m_isUpdatingDivaRanking = false;
		}

		// // RVA: 0x1068824 Offset: 0x1068824 VA: 0x1068824
		private void ApplyEventMusicInfo(IBJAKJJICBC musicData, Difficulty.Type difficulty, bool is6LineMode)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
            ExpType expType = GetMusicExpType(musicData, difficulty, t);
            int expValue = GetMusicExp(musicData, difficulty, t, expType);
			float m = 0;
			for(int i = 0; i < 3; i++)
			{
				m = System.Math.Max(m, m_eventGoDivaData.HODCLEPALGP(i));
			}
			m_eventMusicInfo.SetMusicInfo(musicData, difficulty, is6LineMode, expType, expValue, IsAnyBonusOpen(), m);
			m_eventMusicInfo.SetPlayButton(musicData, difficulty);
        }

		// // RVA: 0x106793C Offset: 0x106793C VA: 0x106793C
		private void ApplyBonusAndLotsStatus(IBJAKJJICBC musicData)
		{
			int v = 0;
			LayoutEventGoDivaMusicInfo.BonusStatusType v2 = LayoutEventGoDivaMusicInfo.BonusStatusType.None;
			foreach(var d in m_eventGoDivaData.GEGAEDDGNMA_Bonuses)
			{
				if(IsBonusOpen(d))
				{
					if(d.CGHNCPEKOCK)
					{
						v = m_eventGoDivaData.DDDKOKOPCGG() + 1;
						v2 = LayoutEventGoDivaMusicInfo.BonusStatusType.Daily;
						break;
					}
					v = 1;
					v2 = LayoutEventGoDivaMusicInfo.BonusStatusType.Normal;
				}
			}
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_eventMusicInfo.SetBonusLotsStatus(musicData.OGHOPBAKEFE_IsEventSpecial ? v2 : (v2 == LayoutEventGoDivaMusicInfo.BonusStatusType.Daily ? LayoutEventGoDivaMusicInfo.BonusStatusType.Hide : LayoutEventGoDivaMusicInfo.BonusStatusType.None), 
				v2 != 0 ? 100 : Mathf.Min(100, m_eventGoDivaData.GNDOGPBIGIL_GetCurrentBonusRate(t) + m_eventGoDivaData.AFGCEMJEOJL_Rate),
				v, CheckBonusItemStatus(t) != BonusItemStatus.NotHave, true);
		}

		// // RVA: 0x1068A8C Offset: 0x1068A8C VA: 0x1068A8C
		private void ApplyDivaStatusPage()
		{
			m_viewControl.OnClickControlListener = OnClickDivaViewButton;
			m_viewControl.SetButtonType(LayoutEventGoDivaViewControlButton.ButtonType.Hide);
			m_selectDiva.OnClickDivaIconListener = OnClickDivaSelectIcon;
			m_selectDiva.SetMode(LayoutEventGoDivaDivaSelectButton.ModeType.WithExplain);
		}

		// // RVA: 0x1068BCC Offset: 0x1068BCC VA: 0x1068BCC
		private void ApplyDivaViewPage()
		{
			m_viewControl.OnClickControlListener = OnClickDivaViewEndButton;
			m_viewControl.SetButtonType(LayoutEventGoDivaViewControlButton.ButtonType.Show);
		}

		// // RVA: 0x1068C8C Offset: 0x1068C8C VA: 0x1068C8C
		private void ApplyEventHomePage()
		{
			m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.GoDivaEvent, false, false, false, false);
			ApplyMusicListInfo();
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
		}

		// // RVA: 0x1068D18 Offset: 0x1068D18 VA: 0x1068D18
		private void ApplyMusicSelectPage()
		{
			ApplyMusicInfo();
		}

		// // RVA: 0x1068D28 Offset: 0x1068D28 VA: 0x1068D28
		private void ApplyEventEndPage()
		{
			m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.GoDivaEventEnd, false, false, false, false);
			m_buttonSet.SetEventRankingCountin(m_musicSelectSupporter.IsEventCounting);
			m_buttonSet.SetBadge(MusicSelectOptionButton.OptionType.EvMission, m_musicSelectSupporter.IsReceiveMission());
			m_buttonSet.SetBadge(MusicSelectOptionButton.OptionType.EvStory, m_musicSelectSupporter.IsNewStory());
			m_selectDiva.OnClickDivaIconListener = OnClickDivaSelectIconForEventEndPage;
			m_selectDiva.SetMode(LayoutEventGoDivaDivaSelectButton.ModeType.IconOnly);
		}

		// // RVA: 0x1063F1C Offset: 0x1063F1C VA: 0x1063F1C
		private void EnterPage(PageType type)
		{
			m_currentPageType = type;
			switch(type)
			{
				case PageType.DivaStatus:
					ApplyDivaStatusPage();
					EnterDivaStatusPage();
					break;
				case PageType.DivaView:
					ApplyDivaViewPage();
					EnterDivaViewPage();
					break;
				case PageType.EventHome:
					ApplyEventHomePage();
					EnterEventHomePage();
					break;
				case PageType.MusicSelect:
					ApplyMusicSelectPage();
					EnterMusicSelectPage();
					break;
				case PageType.EventEnd:
					ApplyEventEndPage();
					EnterEventEndPage();
					break;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0944 Offset: 0x6F0944 VA: 0x6F0944
		// // RVA: 0x1068F14 Offset: 0x1068F14 VA: 0x1068F14
		private IEnumerator OnPreEnterPage(PageType pageType, Action GotoTitleFunc)
		{
			//0x13B0AA4
			if(pageType == PageType.MusicSelect)
			{
				OnChangeMusicFilter(diff);
				ApplyFilterButtonStatus();
			}
			else if(pageType == PageType.EventHome)
			{
				if(!m_pageShownFlags[(int)pageType])
				{
					yield return Co.R(Co_Initialize_LoginBonusPopup(m_eventCtrl, GotoTitleFunc));
					m_eventGoDivaData.KHEKNNFCAOI();
					ApplyEventCommonInfo();
					if(!m_needAppliedMusicSelectSave)
						yield break;
					CreateEventHomeFilterd();
					ApplyFilterButtonStatus();
					if(m_eventGoDivaData.LEABGOOMOHI_FId < 1)
					{
						if(!EventMusicSelect())
							RandomMusicSelect(false, Difficulty.Type.Illegal, true);
					}
					else
					{
						FreeCategoryId.Type cat = FreeCategoryId.Type.None;
						int listNo = 0;
						if(!SearchMusic(m_originalMusicLists, out cat, out listNo, m_eventGoDivaData.LEABGOOMOHI_FId, false))
							m_requestMusicReselectPopupType = MusicReselectPopupType.TimeLimit;
						RandomMusicSelect(false, Difficulty.Type.Illegal, true);
					}
					//LAB_013b0da8
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.HPDBEKAGKOD_SetIsLine6(m_isLine6Mode);
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				}
				else
				{
					CreateEventHomeFilterd();
					ApplyFilterButtonStatus();
					if(m_eventGoDivaData.LEABGOOMOHI_FId < 1)
						yield break;
					FreeCategoryId.Type cat = FreeCategoryId.Type.None;
					int listNo = 0;
					if(!SearchMusic(m_filteredMusicLists, out cat, out listNo, m_eventGoDivaData.LEABGOOMOHI_FId, m_isLine6Mode))
						yield break;
					m_musicCategoryId = cat;
					m_musicListNo = listNo;
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F09BC Offset: 0x6F09BC VA: 0x6F09BC
		// // RVA: 0x1068FD0 Offset: 0x1068FD0 VA: 0x1068FD0
		private IEnumerator OnEnterPage(PageType pageType)
		{
			//0x13AFCE8
			if(pageType == PageType.MusicSelect)
			{
				yield return Co.R(TutorialManager.TryShowTutorialCoroutine(PrivateCheckTutorialFunc));
			}
			else if(pageType == PageType.EventHome)
			{
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					yield return Co.R(Co_Show_LoginBonusPopup(null));
				}
				yield return Co.R(TutorialManager.TryShowTutorialCoroutine(PrivateCheckTutorialFunc));
				bool waitPopup = false;
				if(IsAnyBonusOpen())
				{
					if(!IsViewedBonusOpenPopup)
					{
						waitPopup = true;
						ShowPopupBonusOpen(GetEventMusicData(), () =>
						{
							//0x1071060
							EventMusicSelect();
							GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.HPDBEKAGKOD_SetIsLine6(m_musicSelectSupporter.isLine6Mode);
							GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
							ApplyMusicListInfo();
							ApplyMusicInfo();
							DelayedApplyMusicInfo();
							m_requestMusicReselectPopupType = MusicReselectPopupType.None;
						}, () =>
						{
							//0x10714B8
							IsViewedBonusOpenPopup = true;
							IsViewedBonusClosePopup = false;
							waitPopup = false;
						});
					}
				}
				else
				{
					bool isHiddenBonusClosePopup = m_eventGoDivaData.EKJKEJJKEEK_HideBonusClosePopupFlag;
					if(!IsViewedBonusClosePopup && !isHiddenBonusClosePopup)
					{
						waitPopup = true;
						ShowPopupBonusClose((bool isCheckHidden) =>
						{
							//0x10715B4
							SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
							isHiddenBonusClosePopup = isCheckHidden;
						}, () =>
						{
							//0x1071618
							IsViewedBonusClosePopup = true;
							m_eventGoDivaData.EKJKEJJKEEK_HideBonusClosePopupFlag = isHiddenBonusClosePopup;
							waitPopup = false;
						});
					}
				}
				while(waitPopup)
					yield return null;
				bool needReSelect = false;
				if(!listIsEmpty)
				{
					if(selectMusicData.LHONOILACFL_IsWeeklyEvent)
					{
						if(selectMusicData.MOJMEFIENDM_WeeklyEventCount < 1)
						{
							m_requestMusicReselectPopupType = MusicReselectPopupType.CountLimit;
							needReSelect = true;
						}
					}
				}
				else
				{
					m_requestMusicReselectPopupType = MusicReselectPopupType.TimeLimit;
					needReSelect = true;
				}
				if(m_requestMusicReselectPopupType != MusicReselectPopupType.None)
				{
					waitPopup = true;
					ShowPopupMusicReSelect(m_requestMusicReselectPopupType, () =>
					{
						//0x107156C
						if(needReSelect)
						{
							RandomMusicSelectAndApply();
							waitPopup = false;
						}
					});
					while(waitPopup)
						yield return null;
					while(m_eventMusicInfo.IsLoadingJacket)
						yield return null;
					m_requestMusicReselectPopupType = MusicReselectPopupType.None;
				}
				m_eventGoDivaData.LEABGOOMOHI_FId = selectMusicData.GHBPLHBNMBK_FreeMusicId;
			}
			//LAB_013b0474
			m_pageShownFlags[(int)pageType] = true;
		}

		// // RVA: 0x1069074 Offset: 0x1069074 VA: 0x1069074
		private bool PrivateCheckTutorialFunc(TutorialConditionId conditionId)
		{
			if(!GameManager.Instance.IsTutorial)
			{
				if(conditionId == TutorialConditionId.Condition95)
				{
					if(m_currentPageType == PageType.EventHome)
					{
                        CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = (m_eventCtrl as MANPIONIGNO_EventGoDiva).CLELOGKMNCE_GetEventSaveData();
						if(saveEv != null && saveEv.PFPGHILKGIG_BnsCnt < 1 && saveEv.JHKKAKJCJOF_Bns2 < 1)
							return true;
                    }
				}
				else if(conditionId == TutorialConditionId.Condition94)
				{
					if(m_currentPageType == PageType.EventHome)
					{
						int v = m_eventGoDivaData.GNDOGPBIGIL_GetCurrentBonusRate(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						int v2 = (m_eventCtrl as MANPIONIGNO_EventGoDiva).AELBIEDNPGB_GetTicketCount(null);
						if(v <= 0 && v2 < 1)
						{
							return false;
						}
						return true;
					}
				}
				else if(conditionId == TutorialConditionId.Condition93)
				{
					return m_currentPageType == PageType.MusicSelect;
				}
			}
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0A34 Offset: 0x6F0A34 VA: 0x6F0A34
		// // RVA: 0x10693E8 Offset: 0x10693E8 VA: 0x10693E8
		private IEnumerator Co_ChangePage(PageType nextPage)
		{
			//0x1073160
			MenuScene.Instance.InputDisable();
			m_buttonSet.TryLeave();
			yield return Co.R(OnPreEnterPage(nextPage, OnNetErrorToTitle));
			while(m_buttonSet.IsPlaying())
				yield return null;
			EnterPage(nextPage);
			while(IsPlayingPageAnim())
				yield return null;
			yield return Co.R(OnEnterPage(nextPage));
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x10694B0 Offset: 0x10694B0 VA: 0x10694B0
		private void ShowPopupBonusOpen(IBJAKJJICBC musicData, Action onChangeMusic, Action onClosePopup)
		{
			PopupEventGoDivaBonusOpenSetting s = new PopupEventGoDivaBonusOpenSetting();
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.ThisMusicPlay, Type = PopupButton.ButtonType.Positive }
			};
			s.WindowSize = SizeType.Small;
			s.IsCaption = false;
			s.m_musicData = musicData;
			s.m_godivaData = m_eventGoDivaData;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0x1071720
				if(type == PopupButton.ButtonType.Positive && onChangeMusic != null)
					onChangeMusic();
				if(onClosePopup != null)
					onClosePopup();
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x10697DC Offset: 0x10697DC VA: 0x10697DC
		private void ShowPopupBonusClose(Action<bool> onClickCheckBox, Action onClosePopup)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupEventGoDivaBonusCloseSetting s = new PopupEventGoDivaBonusCloseSetting();
			s.TitleText = bk.GetMessageByLabel("pop_godiva_bonus_close_title");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.WindowSize = SizeType.Small;
			s.IsCaption = true;
			s.OnClickCheckBoxHiddenListener = onClickCheckBox;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0x1071760
				if(onClosePopup != null)
					onClosePopup();
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x1069AFC Offset: 0x1069AFC VA: 0x1069AFC
		private void ShowPopupMusicReSelect(MusicReselectPopupType popupType, Action onClosePopup)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_godiva_music_reselect_title");
			s.Text = bk.GetMessageByLabel(MusicReselectPopupTextNames[(int)popupType]);
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0x1071774
				if(onClosePopup != null)
					onClosePopup();
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x1069E6C Offset: 0x1069E6C VA: 0x1069E6C
		private void ShowPopupAskUseBonusItem(Action<int> onUseItem)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			MANPIONIGNO_EventGoDiva ev = m_eventCtrl as MANPIONIGNO_EventGoDiva;
			LNELCMNJPIC_EventGoDiva dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
			int fever_ticket_rate = 0;
			if(dbEv != null)
				fever_ticket_rate = dbEv.LPJLEHAJADA("fever_ticket_rate", 0);
			int currentRate = m_eventGoDivaData.AFGCEMJEOJL_Rate;
			int nextRate = System.Math.Min(100, currentRate + fever_ticket_rate);
			int tkt = ev.AELBIEDNPGB_GetTicketCount(null);
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_godiva_bonusitem_title");
			s.Text = string.Format(bk.GetMessageByLabel("pop_godiv_bonusitem_ask_use_text"), new object[6]
			{
				fever_ticket_rate, currentRate, nextRate, tkt, tkt - 1, ev.CACFIGAPLDH_GetDailyUse()
			});
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.UsedItem, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0x1071788
				if(type != PopupButton.ButtonType.Positive)
					return;
				if(onUseItem != null)
					onUseItem(nextRate - currentRate);
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x106A6E8 Offset: 0x106A6E8 VA: 0x106A6E8
		private void ShowPopupUseBonusItem(int bonusRate)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_godiva_bonusitem_title");
			s.Text = string.Format(bk.GetMessageByLabel("pop_godiv_bonusitem_use_text"), bonusRate);
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0x10713E4
				return;
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x106AA70 Offset: 0x106AA70 VA: 0x106AA70
		private void ShowPopupCanNotUseBonusItem(BonusItemStatus bonusItemStatus)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_godiva_bonusitem_limit_title");
			s.Text = bk.GetMessageByLabel(bonusItemStatus == BonusItemStatus.OnFever ? "pop_godiva_bonusitem_limit_on_fever" : (bonusItemStatus == BonusItemStatus.OnBonus ? "pop_godiva_bonusitem_limit_on_bonus" : "pop_godiva_bonusitem_limit_daily_cnt"));
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0x10713E8
				return;
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x106ADEC Offset: 0x106ADEC VA: 0x106ADEC
		private void ShowPopupBonusRemind(Action onChangeMusic, Action onClosePopup)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_godiva_bonus_remind_title");
			s.Text = bk.GetMessageByLabel("popup_godiva_bonus_remind_text");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.StayPlay, Type = PopupButton.ButtonType.Other },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0x1071810
				if(type == PopupButton.ButtonType.Positive && onChangeMusic != null)
					onChangeMusic();
				if(onClosePopup != null)
					onClosePopup();
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x106B164 Offset: 0x106B164 VA: 0x106B164
		private bool CheckMatchMusicFilter(IBJAKJJICBC musicData, long currentTime)
		{
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.FPMABHADHBB_EventGoDiva saveData = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.IMEBBACHPAN_EventGoDiva;
			int music_level_limitmin = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmin", 1);
			int music_level_limitmax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmax", 25);
			int min = saveData.KHAJGNDEPMG_FilterMusicLevelMin;
			if(min == 0)
				min = music_level_limitmin;
			int max = saveData.IKFKKJLBBBN_FilterMusicLevelMax;
			if(max == 0)
				max = music_level_limitmax;
			if(CheckMusicFilter_MusicLevel(min, max, musicData, diff) && 
				CheckMusicFilter_MusicAttr(saveData.EOCPIGDIFNB_FilterMusicAttr, musicData) && 
				CheckMusicFilter_Combo(saveData.JJNLEPEKNDO_FilterCombo, musicData, diff) && 
				CheckMusicFilter_Reward(saveData.PGMJCBIHNHK_FilterReward, musicData, diff, m_musicSelectSupporter.isLine6Mode) && 
				CheckMusicFilter_MusicExp(saveData.MENIBLFBNLC_FilterMusicExp, musicData, diff, currentTime))
			{
				return true;
			}
			return false;
        }

		// // RVA: 0x106BAE0 Offset: 0x106BAE0 VA: 0x106BAE0
		private bool CheckMatchEventHomeMusicExpFilter(IBJAKJJICBC musicData, long currentTime, bool isRandom)
		{
			if(isRandom || (m_eventGoDivaData.LEABGOOMOHI_FId != musicData.DLAEJOBELBH_MusicId && !musicData.OGHOPBAKEFE_IsEventSpecial))
			{
				return CheckMusicFilter_MusicExp(GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.IMEBBACHPAN_EventGoDiva.MENIBLFBNLC_FilterMusicExp, musicData, diff, currentTime);
			}
			return true;
		}

		// // RVA: 0x106BCA8 Offset: 0x106BCA8 VA: 0x106BCA8
		private bool CheckMatchEventHomeFilter(IBJAKJJICBC musicData, long currentTime)
		{
			return CheckMatchEventHomeMusicExpFilter(musicData, currentTime, false);
		}

		// // RVA: 0x106BCC8 Offset: 0x106BCC8 VA: 0x106BCC8
		// private bool CheckMatchEventHomeFilter(IBJAKJJICBC musicData, long currentTime, bool isRandom) { }

		// // RVA: 0x106BCE8 Offset: 0x106BCE8 VA: 0x106BCE8
		private void CreateFilterdMusicList()
		{
			MusicSelectSceneBase.CreateFilteredMusicDataList(m_filteredMusicLists, m_originalMusicLists, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), CheckMatchMusicFilter);
		}

		// // RVA: 0x106BE34 Offset: 0x106BE34 VA: 0x106BE34
		private void CreateEventHomeFilterd()
		{
			MusicSelectSceneBase.CreateFilteredMusicDataList(m_filteredMusicLists, m_originalMusicLists, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), CheckMatchEventHomeFilter);
		}

		// // RVA: 0x106BF80 Offset: 0x106BF80 VA: 0x106BF80
		private void CreateDefaultMusicList()
		{
			MusicSelectSceneBase.CreateFilteredMusicDataList(m_filteredMusicLists, m_originalMusicLists, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), (IBJAKJJICBC m, long ct) =>
			{
				//0x10713EC
				return true;
			});
		}

		// // RVA: 0x106B534 Offset: 0x106B534 VA: 0x106B534
		private bool CheckMusicFilter_MusicLevel(int levelMin, int levelMax, IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			return PopupSortMenu.IsMusicLevelFilter(levelMin, levelMax, musicData, difficulty);
		}

		// // RVA: 0x106B5DC Offset: 0x106B5DC VA: 0x106B5DC
		private bool CheckMusicFilter_MusicAttr(int filterBit, IBJAKJJICBC musicData)
		{
			return filterBit == 0 || PopupSortMenu.IsAttributeFilterOn(musicData.FKDCCLPGKDK_JacketAttr, (uint)filterBit);
		}

		// // RVA: 0x106B698 Offset: 0x106B698 VA: 0x106B698
		private bool CheckMusicFilter_Combo(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			if(filterBit == 0)
				return true;
			if((filterBit & 1) != 0)
			{
				if(musicData.MGJKEJHEBPO_DiffInfos[(int)diff].LCOHGOIDMDF_ComboRank > 0)
					return false;
			}
			if((filterBit & 2) == 0)
				return true;
			return musicData.MGJKEJHEBPO_DiffInfos[(int)diff].LCOHGOIDMDF_ComboRank < 2;
		}

		// // RVA: 0x106B804 Offset: 0x106B804 VA: 0x106B804
		private bool CheckMusicFilter_Reward(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty, bool isLine6Mode)
		{
			if(filterBit == 0)
				return true;
			if(!musicData.OGHOPBAKEFE_IsEventSpecial)
			{
				FPGEMAIAMBF_RewardData f = new FPGEMAIAMBF_RewardData();
				f.JMHCEMHPPCM(musicData.GHBPLHBNMBK_FreeMusicId, (int)difficulty, isLine6Mode, musicData.MNNHHJBBICA_GameEventType);
				if((filterBit & 1) != 0)
				{
					if(PopupSortMenu.IsAllRewardAchievedFilter(f.PDONJHCHBAE_ScoreReward))
						return false;
				}
				if((filterBit & 2) != 0)
				{
					if(PopupSortMenu.IsAllRewardAchievedFilter(f.HFPMKBAANFO_ComboReward))
						return false;
				}
				if((filterBit & 4) != 0)
				{
					if(PopupSortMenu.IsAllRewardAchievedFilter(f.IOCLNNCJFKA_ClearReward))
						return false;
				}
				return true;
			}
			return false;
		}

		// // RVA: 0x106BA5C Offset: 0x106BA5C VA: 0x106BA5C
		private bool CheckMusicFilter_MusicExp(int filterFlag, IBJAKJJICBC musicData, Difficulty.Type difficulty, long currentTime)
		{
			if(filterFlag != 0)
			{
				switch(GetMusicExpType(musicData, difficulty, currentTime))
				{
					case ExpType.Soul:
						return (filterFlag & 1) != 0;
					case ExpType.Voice:
						return (filterFlag & 2) != 0;
					case ExpType.Charm:
						return (filterFlag & 4) != 0;
				}
				return false;
			}
			return true;
		}

		// // RVA: 0x106C168 Offset: 0x106C168 VA: 0x106C168
		private bool SearchMusic(List<MusicDataList> musicLists, out FreeCategoryId.Type outCategoryId, out int outListNo, int targetFreeMusicId, bool isLine6Mode)
		{
			for(int i = 0; i < musicLists.Count; i++)
			{
				int idx = musicLists[i].FindIndex(targetFreeMusicId, isLine6Mode, false);
				if(idx >= 0)
				{
					outCategoryId = (FreeCategoryId.Type)(i + 1);
					outListNo = idx;
					return true;
				}
			}
			outCategoryId = FreeCategoryId.Type.Delta;
			outListNo = 0;
			return false;
		}

		// // RVA: 0x106C288 Offset: 0x106C288 VA: 0x106C288
		private IBJAKJJICBC GetEventMusicData()
		{
			foreach(var m in m_originalMusicLists)
			{
				foreach(var n in m.GetList(false, false))
				{
					if(n.OGHOPBAKEFE_IsEventSpecial)
					{
						return n;
					}
				}
			}
			return null;
		}

		// // RVA: 0x106C604 Offset: 0x106C604 VA: 0x106C604
		private bool SearchEventMusic(out FreeCategoryId.Type outCategoryId, out int outMusicListNo, bool is6LineMode)
		{
			outCategoryId = FreeCategoryId.Type.Event;
			outMusicListNo = 0;
			for(int i = 0; i < m_filteredMusicLists.Count; i++)
			{
                List<IBJAKJJICBC> l = m_filteredMusicLists[i].GetList(is6LineMode, false);
                for (int j = 0; j < l.Count; j++)
				{
					if(l[j].OGHOPBAKEFE_IsEventSpecial)
					{
						outCategoryId = (FreeCategoryId.Type)i + 1;
						outMusicListNo = j;
						return true;
					}
				}
			}
			return false;
		}

		// // RVA: 0x106C7D4 Offset: 0x106C7D4 VA: 0x106C7D4
		private bool EventMusicSelect()
		{
			if(GetEventMusicData() == null)
				return false;
			if(InternalEventMusicSelect())
				return true;
			CreateDefaultMusicList();
			return InternalEventMusicSelect();
		}

		// // RVA: 0x106C820 Offset: 0x106C820 VA: 0x106C820
		private bool InternalEventMusicSelect()
		{
			FreeCategoryId.Type cat;
			int id;
			if(SearchEventMusic(out cat, out id, m_musicSelectSupporter.isLine6Mode))
			{
				m_musicCategoryId = cat;
				m_musicListNo = id;
			}
			else
			{
				if(!m_musicSelectSupporter.isLine6Mode)
					return false;
				if(!SearchEventMusic(out cat, out id, false))
					return false;
				m_musicCategoryId = cat;
				m_musicListNo = id;
				m_musicSelectSupporter.isLine6Mode = false;
			}
			return true;
		}

		// // RVA: 0x106C910 Offset: 0x106C910 VA: 0x106C910
		private List<MusicPosInfo> CreateMusicPosInfoList(bool is6LineMode, bool downloadedOnly, Difficulty.Type difficulty)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			List<MusicPosInfo> res = new List<MusicPosInfo>();
			for(int i = 0; i < m_filteredMusicLists.Count; i++)
			{
                List<IBJAKJJICBC> l2 = m_filteredMusicLists[i].GetList(is6LineMode, false);
				for(int j = 0; j < l2.Count; j++)
				{
					if(!downloadedOnly || l2[j].IFNPBIJEPBO_IsDlded)
					{
						if(l2[j].LHONOILACFL_IsWeeklyEvent)
						{
							if(l2[j].MOJMEFIENDM_WeeklyEventCount < 1)
								continue;
						}
						if(difficulty == Difficulty.Type.Illegal || ((int)difficulty < l2[j].MGJKEJHEBPO_DiffInfos.Count && !l2[j].MGJKEJHEBPO_DiffInfos[(int)difficulty].POOMOBGPCNE_IsLocked))
						{
							//LAB_0106cc44
							if(CheckMatchEventHomeMusicExpFilter(l2[j], t, true))
							{
								res.Add(new MusicPosInfo(i, j));
							}
						}
					}
				}
            }
			return res;
		}

		// // RVA: 0x106CD5C Offset: 0x106CD5C VA: 0x106CD5C
		private List<MusicPosInfo> CreateMusicPosInfoList(bool downloadedOnly, Difficulty.Type difficulty)
		{
			List<MusicPosInfo> l = CreateMusicPosInfoList(m_musicSelectSupporter.isLine6Mode, downloadedOnly, difficulty);
			if(l.IsEmpty())
			{
				if(m_musicSelectSupporter.isLine6Mode)
				{
					l = CreateMusicPosInfoList(false, downloadedOnly, difficulty);
					if(!l.IsEmpty())
					{
						m_musicSelectSupporter.isLine6Mode = false;
					}
				}
			}
			return l;
		}

		// // RVA: 0x106CE7C Offset: 0x106CE7C VA: 0x106CE7C
		private bool RandomMusicSelect(bool downloadedOnly, Difficulty.Type difficulty/* = 6*/, bool isSaveSelectMusic/* = True*/)
		{
			m_musicCategoryId = FreeCategoryId.Type.Delta;
			m_musicListNo = 0;
			List<MusicPosInfo> l = CreateMusicPosInfoList(downloadedOnly, difficulty);
			if(l.IsEmpty())
			{
				CreateDefaultMusicList();
				l = CreateMusicPosInfoList(downloadedOnly, difficulty);
			}
			if(!l.IsEmpty())
			{
				int v = UnityEngine.Random.Range(0, l.Count);
				m_musicCategoryId = l[v].categoryId;
				m_musicListNo = l[v].musicListNo;
				if(isSaveSelectMusic)
					m_eventGoDivaData.LEABGOOMOHI_FId = selectMusicData.GHBPLHBNMBK_FreeMusicId;
				return true;
			}
			return false;
		}

		// // RVA: 0x106D090 Offset: 0x106D090 VA: 0x106D090
		private void RandomMusicSelectAndApply()
		{
			RandomMusicSelect(false, diff, true);
			m_eventGoDivaData.FCHBEILHFBC_Difficulty = diff;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.HPDBEKAGKOD_SetIsLine6(m_musicSelectSupporter.isLine6Mode);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			ApplyMusicListInfo();
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
		}

		// // RVA: 0x106D2AC Offset: 0x106D2AC VA: 0x106D2AC
		// private void OverrideEnemySkill() { }

		// // RVA: 0x106D2B0 Offset: 0x106D2B0 VA: 0x106D2B0
		protected void ApplyBasicInfo()
		{
			ApplyBasicInfo(m_cdSelect, m_cdArrow, m_eventBanner, m_musicRate);
		}

		// // RVA: 0x106D2E4 Offset: 0x106D2E4 VA: 0x106D2E4 Slot: 48
		protected override void ApplyMusicListInfo()
		{
			if(m_isEndPostSetCanvas)
			{
				m_seriesInfo.ChangeSelectedTab(m_musicCategoryId, false);
				MenuScene.Instance.InputDisable();
				this.StartCoroutineWatched(Co_WaitForAnimEnd(() =>
				{
					//0x1071220
					MenuScene.Instance.InputEnable();
					m_seriesInfo.ResetLockTabs();
				}));
			}
			else
			{
				m_seriesInfo.ChangeSelectedTab(m_musicCategoryId, true);
			}
			m_musicSelectSupporter.ApplyMusicListInfo(currentMusicList);
		}

		// // RVA: 0x106D468 Offset: 0x106D468 VA: 0x106D468
		private void ApplyMusicInfoBasic(IBJAKJJICBC musicData)
		{
			MusicSelectUISupporter.ApplyTicletDropIcon(m_cdSelect, m_eventTicketId);
			m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.None, false);
			m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.None, false);
		}

		// // RVA: 0x106D4E4 Offset: 0x106D4E4 VA: 0x106D4E4
		private void OnApplyMusicInfoNormal(IBJAKJJICBC musicData, MusicSelectUISupporter.ApplyInfoData applyData)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_playButtonUI.SetupUnitLive(null, null);
            ExpType expType = GetMusicExpType(musicData, diff, t);
            m_cdSelect.SetEventGoDivaExpType(expType);
			m_cdSelect.ApplyEventGoDivaExp(GetMusicExp(musicData, diff, t, expType));
			if(musicData.OGHOPBAKEFE_IsEventSpecial)
			{
				m_cdSelect.EnableEventGoDivaRanking(true);
				m_cdSelect.ApplyEventGoDivaRank(m_eventCtrl.CDINKAANIAA_Rank[m_divaId - 1]);
				float m = 0;
				for(int i = 0; i < 3; i++)
				{
					m = System.Math.Max(m, m_eventGoDivaData.HODCLEPALGP(i));
				}
				m_cdSelect.EnableEventGoDivaExpBonus(IsAnyBonusOpen());
				m_cdSelect.ApplyEventGoDivaExpBonus(m);
			}
			else
			{
				m_cdSelect.EnableEventGoDivaRanking(false);
				m_cdSelect.EnableEventGoDivaExpBonus(false);
			}
			if(m_currentPageType == PageType.MusicSelect)
			{
				m_buttonSet.SetOptionStyle(applyData.buttonSetStyle, applyData.withoutRanking, applyData.withoutReward, applyData.withoutEvRanking, applyData.withoutMission);
			}
			m_buttonSet.SetEventRankingCountin(applyData.isEventCounting);
			m_buttonSet.SetEnemyHasSkill(applyData.enemyHasSkill);
			m_buttonSet.SetBadge(MusicSelectOptionButton.OptionType.EvMission, applyData.isReceiveMission);
			m_buttonSet.SetBadge(MusicSelectOptionButton.OptionType.EvStory, applyData.isNewStory);
			ApplyEventMusicInfo(musicData, diff, m_musicSelectSupporter.isLine6Mode);
			ApplyBonusAndLotsStatus(musicData);
		}

		// // RVA: 0x106DA2C Offset: 0x106DA2C VA: 0x106DA2C
		private void OnWebViewClose()
		{
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x106DAC8 Offset: 0x106DAC8 VA: 0x106DAC8
		private void OnNetErrorToTitle()
		{
			m_isCallGotoTitle = true;
			MenuScene.Instance.GotoTitle();
		}

		// // RVA: 0x106DB70 Offset: 0x106DB70 VA: 0x106DB70
		private void LeaveForScrollStart()
		{
			if(m_buttonSet != null)
				m_buttonSet.Leave();
			m_seriesInfo.TryLeave();
		}

		// // RVA: 0x106DC44 Offset: 0x106DC44 VA: 0x106DC44
		private void EnterForScrollEnd()
		{
			if(m_buttonSet != null)
				m_buttonSet.Enter();
			m_seriesInfo.TryEnter();
		}

		// // RVA: 0x106DD18 Offset: 0x106DD18 VA: 0x106DD18 Slot: 49
		protected override void ApplyMusicInfo()
		{
			m_musicSelectSupporter.ApplyMusicInfo();
		}

		// // RVA: 0x106DD44 Offset: 0x106DD44 VA: 0x106DD44 Slot: 50
		protected override void DelayedApplyMusicInfo()
		{
			if(m_isEventTimeLimit)
				return;
			m_musicSelectSupporter.ApplyBGM();
			if(listIsEmpty)
				return;
			m_eventGoDivaData.ADPFOJMHFMH_SetFreeMusicId(m_musicCategoryId, selectMusicData.GHBPLHBNMBK_FreeMusicId);
		}

		// // RVA: 0x106DDF8 Offset: 0x106DDF8 VA: 0x106DDF8 Slot: 51
		protected override void OnApplyUnitLiveButtonSetting(bool isUnit)
		{
			m_playButtonUI.SetupUnitLive(selectMusicData, m_unitLiveLocalSaveData);
		}

		// // RVA: 0x106DE4C Offset: 0x106DE4C VA: 0x106DE4C
		private void OnClockStatusDetailButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowGoDivaStatusDetail(m_eventGoDivaData.NBIGLBMHEDC_Divas[m_divaId - 1], null);
		}

		// // RVA: 0x106DF98 Offset: 0x106DF98 VA: 0x106DF98
		private void OnClickDivaSelectIcon(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_divaId = index + 1;
			ApplyDivaInfo(true, OnNetErrorToTitle, true);
			this.StartCoroutineWatched(Co_OnClickDivaSelectIcon());
		}

		// // RVA: 0x106E130 Offset: 0x106E130 VA: 0x106E130
		private void OnClickDivaSelectIconForEventEndPage(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_divaId = index + 1;
			m_eventGoDivaData.EPCHEDJFAON_SelDiva = m_divaId;
			ApplyDivaInfo(true, OnNetErrorToTitle, false);
			this.StartCoroutineWatched(Co_OnClickDivaSelectIcon());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0AAC Offset: 0x6F0AAC VA: 0x6F0AAC
		// // RVA: 0x106E0A8 Offset: 0x106E0A8 VA: 0x106E0A8
		private IEnumerator Co_OnClickDivaSelectIcon()
		{
			//0x13AA388
			MenuScene.Instance.InputDisable();
			m_selectDiva.InputEnable();
			while(m_isInActionDivaAsyncUpdate)
				yield return null;
			while(m_isUpdatingDivaRanking)
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x106E264 Offset: 0x106E264 VA: 0x106E264
		private void OnClickCostumeChangeButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(!CheckEventLimit(selectMusicData, m_eventCtrl.HIDHLFCBIDE_EventType, m_eventStatus, m_eventId))
			{
				MenuScene.Instance.Call(TransitionList.Type.COSTUME_SELECT, new CostumeChangeDivaArgs() { DivaId = m_divaId, is_godiva = false }, true);
			}
		}

		// // RVA: 0x106E440 Offset: 0x106E440 VA: 0x106E440
		private void OnClickDivaSelectOKButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_eventGoDivaData.EPCHEDJFAON_SelDiva = m_divaId;
			m_isDivaSelected = true;
			this.StartCoroutineWatched(Co_OnClickDivaSelectOKButton());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0B24 Offset: 0x6F0B24 VA: 0x6F0B24
		// // RVA: 0x106E4E4 Offset: 0x106E4E4 VA: 0x106E4E4
		private IEnumerator Co_OnClickDivaSelectOKButton()
		{
			//0x13AA618
			MenuScene.Instance.InputDisable();
			bool done = false;
			bool err = false;
			MenuScene.Save(() =>
			{
				//0x1071858
				done = true;
			}, () =>
			{
				//0x1071864
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(err)
			{
				OnNetErrorToTitle();
				MenuScene.Instance.InputEnable();
				yield break;
			}
			MenuScene.Instance.InputEnable();
			yield return Co.R(Co_ChangePage(PageType.EventHome));
		}

		// // RVA: 0x106E56C Offset: 0x106E56C VA: 0x106E56C
		private void OnClickDivaViewButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_ChangePage(PageType.DivaView));
		}

		// // RVA: 0x106E5E4 Offset: 0x106E5E4 VA: 0x106E5E4
		private void OnClickDivaViewEndButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_ChangePage(PageType.DivaStatus));
		}

		// // RVA: 0x106E65C Offset: 0x106E65C VA: 0x106E65C
		private void OnClickChangeDivaButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_ChangePage(PageType.DivaStatus));
		}

		// // RVA: 0x106E6D4 Offset: 0x106E6D4 VA: 0x106E6D4
		private void OnClickChangeMusicButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_ChangePage(PageType.MusicSelect));
		}

		// // RVA: 0x106E74C Offset: 0x106E74C VA: 0x106E74C
		private void OnClickRandomMusicButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_OnClickRandomMusicButton());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0B9C Offset: 0x6F0B9C VA: 0x6F0B9C
		// // RVA: 0x106E7C0 Offset: 0x106E7C0 VA: 0x106E7C0
		private IEnumerator Co_OnClickRandomMusicButton()
		{
			//0x13AB7AC
			MenuScene.Instance.InputDisable();
			RandomMusicSelectAndApply();
			while(m_eventMusicInfo.IsLoadingJacket)
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x106E848 Offset: 0x106E848 VA: 0x106E848
		private void OnClickUseBonusItemButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(CheckEventLimit(selectMusicData, m_eventCtrl.HIDHLFCBIDE_EventType, m_eventStatus, m_eventId))
				return;
            BonusItemStatus bonus = CheckBonusItemStatus(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			if(bonus != BonusItemStatus.CanUse)
			{
				ShowPopupCanNotUseBonusItem(bonus);
				return;
			}
			ShowPopupAskUseBonusItem((int bonusRate) =>
			{
				//0x10712E0
				long l;
				m_eventGoDivaData.HHAGNMOIENH_UseFeverTicket(out l);
				ApplyFeverTimeStatus();
				ApplyBonusAndLotsStatus(selectMusicData);
				ShowPopupUseBonusItem(bonusRate);
			});
        }

		// // RVA: 0x106EA84 Offset: 0x106EA84 VA: 0x106EA84
		private BonusItemStatus CheckBonusItemStatus(long currentTime)
		{
			MANPIONIGNO_EventGoDiva ev = m_eventCtrl as MANPIONIGNO_EventGoDiva;
			if(ev.AELBIEDNPGB_GetTicketCount(null) < 1)
				return BonusItemStatus.NotHave;
			else if(ev.CACFIGAPLDH_GetDailyUse() < 1)
				return BonusItemStatus.DailyLimit;
			else if(ev.GNDOGPBIGIL_GetCurrentBonusRate(currentTime) > 0)
				return BonusItemStatus.OnFever;
			else if(IsAnyBonusOpen())
				return BonusItemStatus.OnBonus;
			else 
				return BonusItemStatus.CanUse;
		}

		// // RVA: 0x1068A64 Offset: 0x1068A64 VA: 0x1068A64
		// private bool CheckIsShowBonusItem(long currentTime) { }

		// // RVA: 0x106EBB8 Offset: 0x106EBB8 VA: 0x106EBB8
		// private bool CheckCanUseBonusItem(long currentTime) { }

		// // RVA: 0x106EBE0 Offset: 0x106EBE0 VA: 0x106EBE0
		private void OnChangedSeries(FreeCategoryId.Type seriesId, int initListNo)
		{
			if(isExistSelectMusicData)
			{
				m_eventGoDivaData.ADPFOJMHFMH_SetFreeMusicId(m_musicCategoryId, selectMusicData.GHBPLHBNMBK_FreeMusicId);
			}
			m_musicCategoryId = seriesId;
			m_musicListNo = initListNo;
			CheckListEpmtyByFilter();
			ApplyMusicListInfo();
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
		}

		// // RVA: 0x106ED74 Offset: 0x106ED74 VA: 0x106ED74
		private void OnChangedSeries(FreeCategoryId.Type seriesId)
		{
			int idx = m_filteredMusicLists[(int)seriesId - 1].FindIndex(m_eventGoDivaData.DGCPCBFDAPC_GetFreeMusicId(seriesId), m_musicSelectSupporter.isLine6Mode, false);
			OnChangedSeries(seriesId, idx > 0 ? idx : 0 );
		}

		// // RVA: 0x106EE8C Offset: 0x106EE8C VA: 0x106EE8C
		private void OnClickMusicSelectPlayButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(Co_OnClickOkButton());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0C14 Offset: 0x6F0C14 VA: 0x6F0C14
		// // RVA: 0x106EF00 Offset: 0x106EF00 VA: 0x106EF00
		private IEnumerator Co_OnClickOkButton()
		{
			//0x13AA9F4
			if(CheckEventLimit(selectMusicData, m_eventCtrl.HIDHLFCBIDE_EventType, m_eventStatus, m_eventId))
				yield break;
			if(!selectMusicData.IFNPBIJEPBO_IsDlded)
			{
				DownloadCurrentMusic();
				yield break;
			}
			if(selectMusicData.LHONOILACFL_IsWeeklyEvent && selectMusicData.MOJMEFIENDM_WeeklyEventCount < 1)
			{
				bool isClose = false;
				OpenWeekRecoveryWindow(selectMusicData, (int recovery) =>
				{
					//0x1071878
					isClose = true;
					selectMusicData.IEBGBOBPJMB(recovery);
					ApplyMusicInfo();
					IBJAKJJICBC ib = currentMusicList.Find(selectMusicData.GHBPLHBNMBK_FreeMusicId, !m_musicSelectSupporter.isLine6Mode, false);
					if(ib != null)
						ib.IEBGBOBPJMB(recovery);
				}, () =>
				{
					//0x10719F4
					isClose = true;
				});
				//LAB_013aaa80
				while(!isClose)
					yield return null;
			}
			else
			{
				m_eventGoDivaData.FCHBEILHFBC_Difficulty = diff;
				m_eventGoDivaData.LEABGOOMOHI_FId = selectMusicData.GHBPLHBNMBK_FreeMusicId;
				m_eventGoDivaData.ADPFOJMHFMH_SetFreeMusicId(m_musicCategoryId, selectMusicData.GHBPLHBNMBK_FreeMusicId);
				ApplyEventMusicInfo(selectMusicData, diff, m_isLine6Mode);
				ApplyBonusAndLotsStatus(selectMusicData);
				this.StartCoroutineWatched(Co_ChangePage(PageType.EventHome));
			}
		}

		// // RVA: 0x106EF88 Offset: 0x106EF88 VA: 0x106EF88
		protected void OnChangeLineMode(int style)
		{
			MenuScene.Instance.RaycastDisable();
			if(style == 1)
			{
				m_musicSelectSupporter.isLine6Mode = true;
			}
			else if(style == 0)
			{
				m_musicSelectSupporter.isLine6Mode = false;
			}
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.HPDBEKAGKOD_SetIsLine6(m_musicSelectSupporter.isLine6Mode);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			this.StartCoroutineWatched(Co_ChangeLiveMode(() =>
			{
				//0x10713F4
				MenuScene.Instance.RaycastEnable();
			}));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0C8C Offset: 0x6F0C8C VA: 0x6F0C8C
		// // RVA: 0x106F27C Offset: 0x106F27C VA: 0x106F27C
		private IEnumerator Co_ChangeLiveMode(Action callback)
		{
			bool isPlaying;

			//0x1072974
			m_musicInfo.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_buttonSet.TryLeave();
			m_seriesInfo.TryLeave();
			MenuScene.Instance.HelpButton.TryLeave();
			m_filterButton.TryLeave();
			m_musicRate.TryLeave();
			isPlaying = true;
			while(isPlaying)
			{
				isPlaying = m_musicInfo.IsPlaying() || m_cdSelect.IsPlaying() || m_cdArrow.IsPlaying() || m_buttonSet.IsPlaying() || m_musicRate.IsPlaying() || m_seriesInfo.IsPlaying() || m_filterButton.IsPlaying();
				yield return null;
			}
			OnChangedSeries(m_musicCategoryId);
			OnChangeMusicFilter(diff);
			ApplyBasicInfo(m_cdSelect, m_cdArrow, m_eventBanner, m_musicRate);
			m_musicInfo.TryEnter();
			m_cdSelect.TryEnter();
			m_cdArrow.TryEnter();
			m_buttonSet.TryEnter();
			m_seriesInfo.TryEnter();
			MenuScene.Instance.HelpButton.TryEnter();
			m_filterButton.TryEnter();
			MenuScene.Instance.LobbyButtonControl.CheckLobbyAnnounce();
			OHCAABOMEOF.BPJMGICFPBJ(m_eventId);
			m_musicRate.TryEnter();
			isPlaying = true;
			while(isPlaying)
			{
				isPlaying = m_musicInfo.IsPlaying() || m_cdSelect.IsPlaying() || m_cdArrow.IsPlaying() || m_buttonSet.IsPlaying() || m_musicRate.IsPlaying() || m_seriesInfo.IsPlaying() || m_filterButton.IsPlaying();
				yield return null;
			}
			if(callback != null)
				callback();
		}

		// // RVA: 0x106F344 Offset: 0x106F344 VA: 0x106F344
		private bool IsFilter()
		{
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.FPMABHADHBB_EventGoDiva saveData = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.IMEBBACHPAN_EventGoDiva;
			int music_level_limitmin = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmin", 1);
			int music_level_limitmax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmax", 25);
			return !((saveData.KHAJGNDEPMG_FilterMusicLevelMin == 0 || saveData.KHAJGNDEPMG_FilterMusicLevelMin == music_level_limitmin)
				&& (saveData.IKFKKJLBBBN_FilterMusicLevelMax == 0 || saveData.IKFKKJLBBBN_FilterMusicLevelMax == music_level_limitmax)
				&& saveData.EOCPIGDIFNB_FilterMusicAttr == 0 && saveData.JJNLEPEKNDO_FilterCombo == 0 && saveData.JGOJDHFAHHE_FilterScoreRank == 0 && 
					saveData.PGMJCBIHNHK_FilterReward == 0 && saveData.MENIBLFBNLC_FilterMusicExp == 0);
        }

		// // RVA: 0x106F660 Offset: 0x106F660 VA: 0x106F660
		private void ApplyFilterButtonStatus()
		{
			m_filterButton.SetButtonStatus(IsFilter() ? MusicSelectMusicFilterButton.ButtonStatusType.FilterOn : MusicSelectMusicFilterButton.ButtonStatusType.FilterOff);
		}

		// // RVA: 0x106ECB8 Offset: 0x106ECB8 VA: 0x106ECB8
		private void CheckListEpmtyByFilter()
		{
			if(IsFilter())
			{
				m_musicSelectSupporter.listIsEmptyByFilter = currentMusicList.GetCount(m_musicSelectSupporter.isLine6Mode, false) == 0;				
			}
			else
			{
				m_musicSelectSupporter.listIsEmptyByFilter = false;
			}
		}

		// // RVA: 0x106F6A4 Offset: 0x106F6A4 VA: 0x106F6A4
		private void OnClickFilterButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			PopupFilterSortUGUIInitParam initParam = new PopupFilterSortUGUIInitParam();
			initParam.SetGoDivaMusicSelectParam(diff, m_musicSelectSupporter.isLine6Mode, true);
			MenuScene.Instance.ShowSortWindow(initParam, (PopupFilterSortUGUI content) =>
			{
				//0x1071A00
				ApplyFilterButtonStatus();
				OnChangeMusicFilter(initParam.GoDivaMusicSelectParam.Difficulty);
			}, null);
		}

		// // RVA: 0x106F930 Offset: 0x106F930 VA: 0x106F930
		private void OnChangeMusicFilter(Difficulty.Type difficulty)
		{
			m_musicSelectSupporter.SetDifficulty(difficulty);
			int gameEventType = 0;
			int freeMusicId = 0;
			if(!listIsEmpty)
			{
				freeMusicId = selectMusicData.GHBPLHBNMBK_FreeMusicId;
				gameEventType = selectMusicData.MNNHHJBBICA_GameEventType;
			}
			CreateFilterdMusicList();
			CheckListEpmtyByFilter();
			int initListNo = 0;
			if(currentMusicList != null)
			{
				int v = currentMusicList.FindIndex(freeMusicId, (OHCAABOMEOF.KGOGMKMBCPP_EventType)gameEventType, m_musicSelectSupporter.isLine6Mode, false);
				if(v > 0)
					initListNo = v;
			}
			OnChangedSeries(m_musicCategoryId, initListNo);
		}

		// // RVA: 0x106FA9C Offset: 0x106FA9C VA: 0x106FA9C Slot: 52
		protected override int GetDanceDivaCount()
		{
			return 1;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F0D04 Offset: 0x6F0D04 VA: 0x6F0D04
		// // RVA: 0x106FAA4 Offset: 0x106FAA4 VA: 0x106FAA4 Slot: 53
		protected override IEnumerator OnPreDecideMusicCheck(IBJAKJJICBC musicData, Action onDecideCancel)
		{
			//0x13B07A4
			if(!IsAnyBonusOpen())
				yield break;
			if(musicData.OGHOPBAKEFE_IsEventSpecial)
				yield break;
			bool isWait = true;
			ShowPopupBonusRemind(() =>
			{
				//0x1071A98
				onDecideCancel();
				EventMusicSelect();
				ApplyMusicListInfo();
				ApplyMusicInfo();
				DelayedApplyMusicInfo();
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.HPDBEKAGKOD_SetIsLine6(m_musicSelectSupporter.isLine6Mode);
				m_eventGoDivaData.FCHBEILHFBC_Difficulty = diff;
				m_eventGoDivaData.LEABGOOMOHI_FId = selectMusicData.GHBPLHBNMBK_FreeMusicId;
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			}, () =>
			{
				//0x1071DCC
				isWait = false;
			});
			while(isWait)
				yield return null;
		}

		// // RVA: 0x106FB60 Offset: 0x106FB60 VA: 0x106FB60 Slot: 54
		protected override bool CurrentMusicDecideProcess(Action cancelCallback, MKIKFJKPEHK viewBoostData, int selectIndex/* = 0*/)
		{
			return m_musicSelectSupporter.CurrentMusicDecideProcess(cancelCallback, OnClickPlayButton, DecideCurrentMusic, viewBoostData, selectIndex);
		}

		// // RVA: 0x106FC5C Offset: 0x106FC5C VA: 0x106FC5C Slot: 55
		protected override void OnDecideCurrentMusic(ref MusicDecideInfo info)
		{
			m_feverTimeWatcher.WatchStop();
			if(!m_isInFeverTime)
				info.overrideCurrentTime = 0;
			else
				info.overrideCurrentTime = m_feverTimeEnableTime;
		}

		// // RVA: 0x106FCAC Offset: 0x106FCAC VA: 0x106FCAC Slot: 56
		protected override bool OnInitializeLoginBonusPopup(EKLNMHFCAOI.FKGCBLHOOCL_Category itemType, int itemCount, TicketGainedPopupSetting popupSetting)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
			{
				popupSetting.title = string.Format(bk.GetMessageByLabel("popup_event_login_item02_title_msg"), itemCount);
				popupSetting.label01 = bk.GetMessageByLabel("popup_event_login_item02_label00_msg");
				popupSetting.label02 = bk.GetMessageByLabel("popup_event_login_item02_label01_msg");
				popupSetting.layoutType = 1;
				return true;
			}
			return false;
		}
	}
}
