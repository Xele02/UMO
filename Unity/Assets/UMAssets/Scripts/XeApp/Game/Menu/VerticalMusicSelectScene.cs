using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;
using XeSys;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectScene : VerticalMusicSelectSceneBase
	{
		// private static readonly FreeCategoryId.Type[] MUSIC_LIST_TYPE = new FreeCategoryId.Type[5] {5F2E96BE9C0A28A18AE1C50C5298E42BB9EC26E0}; // 0x0
		// private VerticalMusicSelectUISapporter m_musicSelectUISapporter = new VerticalMusicSelectUISapporter(); // 0xB0
		// private List<VerticalMusicDataList> m_originalMusicDataList = new List<VerticalMusicDataList>(); // 0xB4
		// private List<VerticalMusicDataList> m_originalEventMusicDataList = new List<VerticalMusicDataList>(); // 0xB8
		// private VerticalMusicDataList m_filterMusicDataList = new VerticalMusicDataList(); // 0xBC
		// private VerticalMusicDataList m_filterMusicEventDataList = new VerticalMusicDataList(); // 0xC0
		// private bool m_isListScroll; // 0xC4
		// private bool m_isChangeBg; // 0xC5
		// private bool m_isEndMyRankRequest; // 0xC6
		// private bool m_showScoreRankingPopup; // 0xC7
		// public static readonly MusicSelectConsts.SeriesType[] CategoryToSeriesType = new MusicSelectConsts.SeriesType[7] {B21C1224684EAD6057E0D535F5E726DA8EDD5779}; // 0x4
		// private bool m_isBgCached; // 0xCC
		// private bool m_isScoreRankingPopup; // 0xCD
		// private bool m_isScoreEventTimeLimit; // 0xCE
		// private bool m_isListEmptyByFilter; // 0xCF
		// private int m_eventIndex; // 0xD0
		// private int m_pickupFreeMusicId; // 0xD4
		// private FreeCategoryId.Type m_pickupFreeCategoryId; // 0xD8
		// private OHCAABOMEOF.KGOGMKMBCPP m_currentEventType; // 0xDC
		// private VerticalMusicSelecChoiceMusicListTab.MusicTab m_musicTab; // 0xE0
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
		// private LayoutEventGoDivaFeverLimit m_feverLimit; // 0x11C
		// private static readonly int newSeriesBgIdDiff = 6; // 0x8
		// private static readonly int eventCategoryId = 5; // 0xC
		// private static readonly int[] CategoryToNewSeriesBgId = new int[7] { -1, newSeriesBgIdDiff+4, newSeriesBgIdDiff+3, newSeriesBgIdDiff+2, newSeriesBgIdDiff+1, newSeriesBgIdDiff+eventCategoryId, newSeriesBgIdDiff+6 }; // 0x10
		// private static readonly int[] SeriesToNewSeriesBgId = new int[6] { -1, newSeriesBgIdDiff+1, newSeriesBgIdDiff+2, newSeriesBgIdDiff+3, newSeriesBgIdDiff+4, newSeriesBgIdDiff+6 }; // 0x14
		// private static readonly int noMusicCategoryId = CategoryToNewSeriesBgId[6] + 1; // 0x18

		// private VerticalMusicSelectSortOrder.SortOrder sortOrder { get; } 0xBE5B30
		// protected override IBJAKJJICBC selectMusicData { get; } 0xBE5B5C
		// protected override VerticalMusicDataList.MusicListData selectMusicListData { get; } 0xBE5C04
		// protected override Difficulty.Type diff { get; } 0xBE5C90
		// protected override MusicSelectConsts.SeriesType series { get; } 0xBE5CBC
		// protected override int list_no { get; set; } // 0xC8
		// protected override int musicListCount { get; } 0xBE5CF8 0xBE5D00
		// protected override VerticalMusicDataList currentMusicList { get; } 0xBE5D14
		// protected override List<VerticalMusicDataList> originalMusicList { get; } 0xBE5D2C
		// protected override bool isLine6Mode { get; } 0xBE5D34
		// private bool m_isLine6Mode { get; set; } 0xBE5D7C 0xBE5D58
		// private List<VerticalMusicDataList> currentOriginalMusicDataList { get; } 0xBE5DA4

		// [IteratorStateMachineAttribute] // RVA: 0x6F5EAC Offset: 0x6F5EAC VA: 0x6F5EAC
		// // RVA: 0xBE5DBC Offset: 0xBE5DBC VA: 0xBE5DBC Slot: 42
		//protected override IEnumerator Co_OnPreSetCanvas()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//	yield break;
		//}

		// [IteratorStateMachineAttribute] // RVA: 0x6F5F24 Offset: 0x6F5F24 VA: 0x6F5F24
		// // RVA: 0xBE5E44 Offset: 0xBE5E44 VA: 0xBE5E44
		// private IEnumerator Co_SetupBg(BgType bgType, int bgId, bool isFade, Action endCallBack) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F5F9C Offset: 0x6F5F9C VA: 0x6F5F9C
		// // RVA: 0xBE5F30 Offset: 0xBE5F30 VA: 0xBE5F30 Slot: 43
		//protected override IEnumerator Co_OnPostSetCanvas()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//	yield break;
		//}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6014 Offset: 0x6F6014 VA: 0x6F6014
		// // RVA: 0xBE5FB8 Offset: 0xBE5FB8 VA: 0xBE5FB8 Slot: 44
		//protected override IEnumerator Co_ActivateScene()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//	yield break;
		//}

		// [IteratorStateMachineAttribute] // RVA: 0x6F608C Offset: 0x6F608C VA: 0x6F608C
		// // RVA: 0xBE6040 Offset: 0xBE6040 VA: 0xBE6040
		private IEnumerator Co_ShowScoreRankingPopup()
		{
			UnityEngine.Debug.LogError("TODO !!!");
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
			UnityEngine.Debug.LogError("TODO !!!");
			yield break;
		}

		// RVA: 0xBE61C0 Offset: 0xBE61C0 VA: 0xBE61C0 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		// RVA: 0xBE63FC Offset: 0xBE63FC VA: 0xBE63FC Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			UnityEngine.Debug.LogError("TODO !!!");
			return false;
		}

		// RVA: 0xBE65C8 Offset: 0xBE65C8 VA: 0xBE65C8 Slot: 12
		protected override void OnStartExitAnimation()
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		// RVA: 0xBE683C Offset: 0xBE683C VA: 0xBE683C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			UnityEngine.Debug.LogError("TODO !!!");
			return false;
		}

		// RVA: 0xBE6A30 Offset: 0xBE6A30 VA: 0xBE6A30 Slot: 20
		protected override bool OnBgmStart()
		{
			UnityEngine.Debug.LogError("TODO !!!");
			return true;
		}

		// RVA: 0xBE6AFC Offset: 0xBE6AFC VA: 0xBE6AFC Slot: 47
		protected override void OnUpdate()
		{
			return;
		}

		// RVA: 0xBE6B00 Offset: 0xBE6B00 VA: 0xBE6B00 Slot: 48
		//protected override void ReleaseScene()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// RVA: 0xBE6BA0 Offset: 0xBE6BA0 VA: 0xBE6BA0 Slot: 49
		//protected override void ReleaseCache()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// RVA: 0xBE6C68 Offset: 0xBE6C68 VA: 0xBE6C68 Slot: 50
		//protected override void OnInputDisable()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// RVA: 0xBE6CAC Offset: 0xBE6CAC VA: 0xBE6CAC Slot: 51
		//protected override void OnInputEnable()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// RVA: 0xBE6CF0 Offset: 0xBE6CF0 VA: 0xBE6CF0 Slot: 55
		//protected override int GetDanceDivaCount()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//	return 0;
		//}

		// // RVA: 0xBE6D18 Offset: 0xBE6D18 VA: 0xBE6D18
		// protected void TryInstall(StringBuilder bundleName, VerticalMusicDataList musicList) { }

		// // RVA: 0xBE7054 Offset: 0xBE7054 VA: 0xBE7054
		// private void SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType type) { }

		// // RVA: 0xBE7164 Offset: 0xBE7164 VA: 0xBE7164
		// public void SetPlayButton(VerticalMusicDataList.MusicListData musicListData) { }

		// // RVA: 0xBE7438 Offset: 0xBE7438 VA: 0xBE7438
		// public void SetSimulationButton(VerticalMusicDataList.MusicListData musicListData) { }

		// // RVA: 0xBE7728 Offset: 0xBE7728 VA: 0xBE7728
		// public void SetMusicDetailRemainTime(long remainTime, VerticalMusicSelectMusicDetail.MusicRemainTimeType remainTimeType, LimitTimeWatcher.OnEndCallback endCallback) { }

		// // RVA: 0xBE7758 Offset: 0xBE7758 VA: 0xBE7758
		// public void SetTicketDropIcon(int ticketId) { }

		// // RVA: 0xBE7818 Offset: 0xBE7818 VA: 0xBE7818
		// private void SetCreateMusicList() { }

		// // RVA: 0xBE87B4 Offset: 0xBE87B4 VA: 0xBE87B4
		// public void SelectAprilFoolFocus() { }

		// // RVA: 0xBE8AE8 Offset: 0xBE8AE8 VA: 0xBE8AE8
		// private int GetMinigameListNo(int minigameId) { }

		// // RVA: 0xBE8C6C Offset: 0xBE8C6C VA: 0xBE8C6C
		// private void SelectArgsFocus(MusicSelectArgs args) { }

		// // RVA: 0xBE97AC Offset: 0xBE97AC VA: 0xBE97AC
		// private bool CheckShowEventBanner(OHCAABOMEOF.KGOGMKMBCPP eventType) { }

		// // RVA: 0xBE97F0 Offset: 0xBE97F0 VA: 0xBE97F0
		// private void ApplyEventInfo() { }

		// // RVA: 0xBEA28C Offset: 0xBEA28C VA: 0xBEA28C
		// private void OnClickEventBanner() { }

		// // RVA: 0xBEA808 Offset: 0xBEA808 VA: 0xBEA808 Slot: 52
		//protected override void ApplyCommonInfo()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// RVA: 0xBEAA40 Offset: 0xBEAA40 VA: 0xBEAA40 Slot: 53
		//protected override void ApplyMusicInfo()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// // RVA: 0xBEBC94 Offset: 0xBEBC94 VA: 0xBEBC94
		// private int GetChangeBgId(VerticalMusicDataList.MusicListData musicListData) { }

		// // RVA: 0xBEBF44 Offset: 0xBEBF44 VA: 0xBEBF44 Slot: 54
		//protected override void DelayedApplyMusicInfo()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// RVA: 0xBEC300 Offset: 0xBEC300 VA: 0xBEC300 Slot: 59
		//protected override void OnDecideCurrentMusic(ref VerticalMusicSelectSceneBase.MusicDecideInfo info)
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// // RVA: 0xBEAACC Offset: 0xBEAACC VA: 0xBEAACC
		// private void ApplyMusicInfoNone() { }

		// // RVA: 0xBEAC3C Offset: 0xBEAC3C VA: 0xBEAC3C
		// private void ApplyMusicInfoEventEntrance() { }

		// // RVA: 0xBEB120 Offset: 0xBEB120 VA: 0xBEB120
		// private void ApplyMusicInfoNormal() { }

		// // RVA: 0xBEC304 Offset: 0xBEC304 VA: 0xBEC304
		// private void SetListNo(int no) { }

		// // RVA: 0xBEC314 Offset: 0xBEC314 VA: 0xBEC314 Slot: 57
		//protected override void OnClickDifficultyButton(int index)
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// // RVA: 0xBEC918 Offset: 0xBEC918 VA: 0xBEC918
		// private void OnClickSeriesButton(int index) { }

		// // RVA: 0xBEC9A4 Offset: 0xBEC9A4 VA: 0xBEC9A4
		// protected void OnClickUnitButton(int index) { }

		// // RVA: 0xBECA44 Offset: 0xBECA44 VA: 0xBECA44
		// private void ListChangeItemCallBack(int index) { }

		// // RVA: 0xBECA7C Offset: 0xBECA7C VA: 0xBECA7C
		// private void ListClipItemCallBack() { }

		// // RVA: 0xBECA8C Offset: 0xBECA8C VA: 0xBECA8C
		// private void OnScrollStartEvent() { }

		// // RVA: 0xBECB3C Offset: 0xBECB3C VA: 0xBECB3C
		// private void OnScrollEndEvent() { }

		// // RVA: 0xBECBEC Offset: 0xBECBEC VA: 0xBECBEC
		// private void OnClickLine6Button() { }

		// // RVA: 0xBECFD4 Offset: 0xBECFD4 VA: 0xBECFD4 Slot: 56
		//protected override void OnApplyUnitLiveButtonSetting(bool isUnit)
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// // RVA: 0xBEAA10 Offset: 0xBEAA10 VA: 0xBEAA10
		// private void SetMusicTab(VerticalMusicSelecChoiceMusicListTab.MusicTab type) { }

		// // RVA: 0xBE97A4 Offset: 0xBE97A4 VA: 0xBE97A4
		// private void SetMusicTab(bool isEvent) { }

		// // RVA: 0xBED05C Offset: 0xBED05C VA: 0xBED05C
		// private void OnClickMusicTabButton(bool isNormal) { }

		// // RVA: 0xBED3D0 Offset: 0xBED3D0 VA: 0xBED3D0
		// private void OnClickJacketButton() { }

		// // RVA: 0xBED824 Offset: 0xBED824 VA: 0xBED824
		// private void OnClickClozeJacketButton() { }

		// // RVA: 0xBED9AC Offset: 0xBED9AC VA: 0xBED9AC
		// private void OnClickJacketImageButton(int freeMusicId) { }

		// // RVA: 0xBEDC78 Offset: 0xBEDC78 VA: 0xBEDC78
		// private void OnClickSmallBigButton(VerticalMusicSelectSortOrder.SortOrder sortOrder) { }

		// // RVA: 0xBEDD10 Offset: 0xBEDD10 VA: 0xBEDD10
		// private void SetSmallBigOrderButtonEnable() { }

		// // RVA: 0xBEDD4C Offset: 0xBEDD4C VA: 0xBEDD4C
		// private void SetSeriesButtonEnable() { }

		// // RVA: 0xBEDD88 Offset: 0xBEDD88 VA: 0xBEDD88
		// private void MusicDataListSort() { }

		// // RVA: 0xBEE154 Offset: 0xBEE154 VA: 0xBEE154
		// private int MusicDataListSortCb(VerticalMusicDataList.MusicListData left, VerticalMusicDataList.MusicListData right) { }

		// // RVA: 0xBEE6D8 Offset: 0xBEE6D8 VA: 0xBEE6D8
		// private int EventMusicDataListSortCb(VerticalMusicDataList.MusicListData left, VerticalMusicDataList.MusicListData right) { }

		// // RVA: 0xBEE8C0 Offset: 0xBEE8C0 VA: 0xBEE8C0
		// private bool IsFilter() { }

		// // RVA: 0xBEEA68 Offset: 0xBEEA68 VA: 0xBEEA68
		// private void SetMusicFilterButton() { }

		// // RVA: 0xBEEAA8 Offset: 0xBEEAA8 VA: 0xBEEAA8
		// private void SetMusicFilterButtonEnable() { }

		// // RVA: 0xBEEAE0 Offset: 0xBEEAE0 VA: 0xBEEAE0
		// private void SetMusicFilterSortText() { }

		// // RVA: 0xBEEBC4 Offset: 0xBEEBC4 VA: 0xBEEBC4
		// private void CheckListEmptyByFilter() { }

		// // RVA: 0xBED2FC Offset: 0xBED2FC VA: 0xBED2FC
		// private void SetFreeMusicIdByListNo(int freeMusicId, OHCAABOMEOF.KGOGMKMBCPP gameEventType) { }

		// // RVA: 0xBEC3C0 Offset: 0xBEC3C0 VA: 0xBEC3C0
		// private void OnChangeFilter() { }

		// // RVA: 0xBEEC50 Offset: 0xBEEC50 VA: 0xBEEC50
		// private void OnClickFilterButton() { }

		// // RVA: 0xBEEE70 Offset: 0xBEEE70 VA: 0xBEEE70
		// private bool CheckMatchFilterFunc(VerticalMusicDataList.MusicListData musicListData, int series, long currentTime) { }

		// // RVA: 0xBEF1E8 Offset: 0xBEF1E8 VA: 0xBEF1E8
		// private bool CheckMusicFilter_Series(int series, IBJAKJJICBC musicData) { }

		// // RVA: 0xBEF238 Offset: 0xBEF238 VA: 0xBEF238
		// private bool CheckMusicFilter_MusicAttr(int filterBit, IBJAKJJICBC musicData) { }

		// // RVA: 0xBEF2F4 Offset: 0xBEF2F4 VA: 0xBEF2F4
		// private bool CheckMusicFilter_Combo(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xBEF460 Offset: 0xBEF460 VA: 0xBEF460
		// private bool CheckMusicFilter_Reward(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty, bool isLine6Mode) { }

		// // RVA: 0xBEF690 Offset: 0xBEF690 VA: 0xBEF690
		// private bool CheckMusicFilter_Unit(int filterBit, IBJAKJJICBC musicData) { }

		// // RVA: 0xBEF7A8 Offset: 0xBEF7A8 VA: 0xBEF7A8
		// private bool CheckMusicFilter_MusicBookMark(int index, IBJAKJJICBC musicData) { }

		// // RVA: 0xBEF7F4 Offset: 0xBEF7F4 VA: 0xBEF7F4
		// private bool CheckMusicFilter_MusicUnlock(int filterBit, bool isOpen) { }

		// // RVA: 0xBEF814 Offset: 0xBEF814 VA: 0xBEF814
		// private bool CheckMusicFilter_MusicRange(int filterBit, MusicSelectConsts.MusicTimeType timeType) { }

		// // RVA: 0xBEF84C Offset: 0xBEF84C VA: 0xBEF84C
		// private bool IsCanDoUnitHelp() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F61F4 Offset: 0x6F61F4 VA: 0x6F61F4
		// // RVA: 0xBF00B8 Offset: 0xBF00B8 VA: 0xBF00B8
		// private void <Co_OnPreSetCanvas>b__63_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6204 Offset: 0x6F6204 VA: 0x6F6204
		// // RVA: 0xBF00C4 Offset: 0xBF00C4 VA: 0xBF00C4
		// private void <Co_OnPostSetCanvas>b__70_0(int index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6214 Offset: 0x6F6214 VA: 0x6F6214
		// // RVA: 0xBF00FC Offset: 0xBF00FC VA: 0xBF00FC
		// private void <Co_OnPostSetCanvas>b__70_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6224 Offset: 0x6F6224 VA: 0x6F6224
		// // RVA: 0xBF010C Offset: 0xBF010C VA: 0xBF010C
		// private void <Co_OnPostSetCanvas>b__70_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6234 Offset: 0x6F6234 VA: 0x6F6234
		// // RVA: 0xBF01A0 Offset: 0xBF01A0 VA: 0xBF01A0
		// private void <Co_OnPostSetCanvas>b__70_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6244 Offset: 0x6F6244 VA: 0x6F6244
		// // RVA: 0xBF01F0 Offset: 0xBF01F0 VA: 0xBF01F0
		// private void <Co_OnPostSetCanvas>b__70_4() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6254 Offset: 0x6F6254 VA: 0x6F6254
		// // RVA: 0xBF0240 Offset: 0xBF0240 VA: 0xBF0240
		// private void <Co_OnPostSetCanvas>b__70_5() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6264 Offset: 0x6F6264 VA: 0x6F6264
		// // RVA: 0xBF02C4 Offset: 0xBF02C4 VA: 0xBF02C4
		// private void <Co_OnPostSetCanvas>b__70_6() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6274 Offset: 0x6F6274 VA: 0x6F6274
		// // RVA: 0xBF02C8 Offset: 0xBF02C8 VA: 0xBF02C8
		// private void <Co_OnPostSetCanvas>b__70_7() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6284 Offset: 0x6F6284 VA: 0x6F6284
		// // RVA: 0xBF02CC Offset: 0xBF02CC VA: 0xBF02CC
		// private void <Co_OnPostSetCanvas>b__70_8(int index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6294 Offset: 0x6F6294 VA: 0x6F6294
		// // RVA: 0xBF02D0 Offset: 0xBF02D0 VA: 0xBF02D0
		// private void <Co_OnPostSetCanvas>b__70_9() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62A4 Offset: 0x6F62A4 VA: 0x6F62A4
		// // RVA: 0xBF036C Offset: 0xBF036C VA: 0xBF036C
		// private void <Co_OnPostSetCanvas>b__70_10() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62B4 Offset: 0x6F62B4 VA: 0x6F62B4
		// // RVA: 0xBF0370 Offset: 0xBF0370 VA: 0xBF0370
		// private void <Co_OnPostSetCanvas>b__70_11() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62C4 Offset: 0x6F62C4 VA: 0x6F62C4
		// // RVA: 0xBF0378 Offset: 0xBF0378 VA: 0xBF0378
		// private void <Co_OnPostSetCanvas>b__70_12() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62D4 Offset: 0x6F62D4 VA: 0x6F62D4
		// // RVA: 0xBF0380 Offset: 0xBF0380 VA: 0xBF0380
		// private void <Co_OnPostSetCanvas>b__70_13(int index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62E4 Offset: 0x6F62E4 VA: 0x6F62E4
		// // RVA: 0xBF0390 Offset: 0xBF0390 VA: 0xBF0390
		// private void <Co_OnPostSetCanvas>b__70_14() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62F4 Offset: 0x6F62F4 VA: 0x6F62F4
		// // RVA: 0xBF0394 Offset: 0xBF0394 VA: 0xBF0394
		// private void <Co_OnPostSetCanvas>b__70_15(int index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6304 Offset: 0x6F6304 VA: 0x6F6304
		// // RVA: 0xBF0404 Offset: 0xBF0404 VA: 0xBF0404
		// private void <Co_OnPostSetCanvas>b__70_16() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6314 Offset: 0x6F6314 VA: 0x6F6314
		// // RVA: 0xBF046C Offset: 0xBF046C VA: 0xBF046C
		// private void <Co_OnPostSetCanvas>b__70_17(bool isSimulation) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6324 Offset: 0x6F6324 VA: 0x6F6324
		// // RVA: 0xBF04E0 Offset: 0xBF04E0 VA: 0xBF04E0
		// private void <Co_OnPostSetCanvas>b__70_18(bool isSimulation) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6334 Offset: 0x6F6334 VA: 0x6F6334
		// // RVA: 0xBF0554 Offset: 0xBF0554 VA: 0xBF0554
		// private void <Co_OnPostSetCanvas>b__70_19() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6344 Offset: 0x6F6344 VA: 0x6F6344
		// // RVA: 0xBF05C0 Offset: 0xBF05C0 VA: 0xBF05C0
		// private void <Co_OnPostSetCanvas>b__70_20() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6354 Offset: 0x6F6354 VA: 0x6F6354
		// // RVA: 0xBF0628 Offset: 0xBF0628 VA: 0xBF0628
		// private void <Co_OnPostSetCanvas>b__70_21(bool index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6364 Offset: 0x6F6364 VA: 0x6F6364
		// // RVA: 0xBF0698 Offset: 0xBF0698 VA: 0xBF0698
		// private void <Co_OnPostSetCanvas>b__70_22() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6374 Offset: 0x6F6374 VA: 0x6F6374
		// // RVA: 0xBF06B8 Offset: 0xBF06B8 VA: 0xBF06B8
		// private void <Co_OnPostSetCanvas>b__70_23(int freeMusicId) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6384 Offset: 0x6F6384 VA: 0x6F6384
		// // RVA: 0xBF06BC Offset: 0xBF06BC VA: 0xBF06BC
		// private void <Co_OnPostSetCanvas>b__70_24() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6394 Offset: 0x6F6394 VA: 0x6F6394
		// // RVA: 0xBF06C0 Offset: 0xBF06C0 VA: 0xBF06C0
		// private void <Co_OnPostSetCanvas>b__70_25(int index, SwapScrollListContent content) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F63A4 Offset: 0x6F63A4 VA: 0x6F63A4
		// // RVA: 0xBF0888 Offset: 0xBF0888 VA: 0xBF0888
		// private void <Co_OnPostSetCanvas>b__70_26() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F63B4 Offset: 0x6F63B4 VA: 0x6F63B4
		// // RVA: 0xBF0894 Offset: 0xBF0894 VA: 0xBF0894
		// private void <Co_OnPostSetCanvas>b__70_27() { }

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
