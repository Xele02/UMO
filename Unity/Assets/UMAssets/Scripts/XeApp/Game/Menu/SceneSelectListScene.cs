using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using static XeApp.Game.Menu.ListSortButtonGroup;

namespace XeApp.Game.Menu
{
	public class SceneSelectListScene : TransitionRoot
	{
		[SerializeField]
		private EquipmentScene m_equipmentScene; // 0x48
		[SerializeField]
		private SceneSelectList m_sceneSelectList; // 0x4C
		[SerializeField]
		private ListSortButtonGroup m_sortButtonGroup; // 0x50
		[SerializeField]
		private PopupSortMenu.SortPlace m_sortPlace = PopupSortMenu.SortPlace.None; // 0x54
		[SerializeField]
		private PopupFilterSort.Scene m_popupFilterSortScene = PopupFilterSort.Scene.None; // 0x58
		private SceneComparisonPopupSetting m_sceneComparisonPopupSetting; // 0x5C
		private SceneSelectHomeBgSetting m_sceneSelectHomeBgSetting; // 0x60
		private PopupLimitOverList m_limitOverList; // 0x64
		private FFHPBEPOMAK m_divaData; // 0x68
		private PIGBBNDPPJC m_episodeData = new PIGBBNDPPJC(); // 0x6C
		private int m_selectedEquipmentSlotIndex; // 0x70
		private int m_selectedDivaSlotIndex; // 0x74
		private int m_selectedSceneId; // 0x78
		private int m_episodeId; // 0x7C
		private int m_missionId; // 0x80
		private bool m_isBeginner; // 0x84
		private const int EpisodeMissionSceneId = 1;
		private const int BeginnerMissionSceneId = 3;
		private const int EquipmentMaxSlotCount = 3;
		private const int RemoveButtonId = -1;
		private const int ListRowCount = 4;
		private const int ListColumnCount = 4;
		private const DisplayType DefaultDisplayType = 0;
		private const SortItem DefaultSortItem = 0;
		private List<int> m_sceneIndexList = new List<int>(); // 0x88
		private SortItem m_sortType; // 0x8C
		private uint m_order = (uint)ListSortButtonGroup.DefaultSortOrder; // 0x90
		private bool m_isCallEpisodeList; // 0x94
		private bool m_isBonus; // 0x95
		private bool m_isEnableBonus; // 0x96
		private int m_dispRowCount = 3; // 0x98
		private int m_rarityRestriction = -1; // 0x9C
		private EAJCBFGKKFA m_friendPlayerData; // 0xA0
		private EEDKAACNBBG m_musicBaseData; // 0xA4
		private EJKBKMBJMGL_EnemyData m_enemyData; // 0xA8
		private Difficulty.Type m_difficulty; // 0xAC
		private EEMGHIINEHN m_assistViewData; // 0xB0
		private int m_assistPageIndex; // 0xB4
		private int m_assistSlotIndex; // 0xB8
		private bool m_isHomeSceneBg; // 0xBC
		private bool m_isGoDivaEvent; // 0xBD

		private DFKGGBMFFGB PlayerData { get { return GameManager.Instance.ViewPlayerData; } } //0x1380250

		// RVA: 0x13802EC Offset: 0x13802EC VA: 0x13802EC Slot: 5
		protected override void Start()
		{
			StartCoroutine(InitializeCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72E0C4 Offset: 0x72E0C4 VA: 0x72E0C4
		// // RVA: 0x1380398 Offset: 0x1380398 VA: 0x1380398
		private IEnumerator Co_SceneSortButtonLayout(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xA5869C
			if(m_transitionName == TransitionList.Type.SCENE_ABILITY_RELEASE_LIST)
				yield break;
			if(m_sortButtonGroup != null)
				yield break;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_card_btn_layout_root");
			yield return operation;
			yield return operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
				//0x138794C
				instance.transform.SetParent(transform, false);
				m_sortButtonGroup = instance.GetComponentInChildren<ListSortButtonGroup>(true);
				m_sortButtonGroup.SortPlace = m_sortPlace;
			});
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			operation = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72E13C Offset: 0x72E13C VA: 0x72E13C
		// // RVA: 0x1380454 Offset: 0x1380454 VA: 0x1380454
		private IEnumerator Co_SelectWindowLayout(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;
			//0xA58980
			if(m_transitionName != TransitionList.Type.ASSIST_SELECT && 
				m_transitionName != TransitionList.Type.HOME_BG_SELECT &&
				m_transitionName != TransitionList.Type.SCENE_SELECT)
			{
				yield break;
			}
			if(m_equipmentScene != null)
				yield break;
			if(m_sceneSelectList != null)
				yield break;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_window01_layout_root");
			yield return operation;
			yield return operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
				//0x1387A48
				instance.transform.SetParent(transform, false);
				m_equipmentScene = instance.GetComponentInChildren<EquipmentScene>(true);
				m_sceneSelectList = instance.GetComponentInChildren<SceneSelectList>(true);
			});
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			operation = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72E1B4 Offset: 0x72E1B4 VA: 0x72E1B4
		// // RVA: 0x1380310 Offset: 0x1380310 VA: 0x1380310
		private IEnumerator InitializeCoroutine()
		{
			string bundleName; // 0x14
			Font systemFont; // 0x18

			//0xA58CBC
			bundleName = "ly/014.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co_SelectWindowLayout(bundleName, systemFont);
			yield return Co_SceneSortButtonLayout(bundleName, systemFont);
			if(m_transitionName == TransitionList.Type.ASSIST_SELECT ||
				m_transitionName == TransitionList.Type.SCENE_SELECT)
			{
				m_sceneComparisonPopupSetting = new SceneComparisonPopupSetting();
				m_sceneComparisonPopupSetting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_title_02");
				m_sceneComparisonPopupSetting.WindowSize = SizeType.Large;
				m_sceneComparisonPopupSetting.SetParent(transform);
			}
			if(m_transitionName == TransitionList.Type.HOME_BG_SELECT)
			{
				m_sceneSelectHomeBgSetting = new SceneSelectHomeBgSetting();
				m_sceneSelectHomeBgSetting.TitleText = MessageManager.Instance.GetMessage("menu", "popup_homebg_title");
				m_sceneSelectHomeBgSetting.WindowSize = SizeType.Middle;
				m_sceneSelectHomeBgSetting.Buttons = new ButtonInfo[2] {
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				m_sceneSelectHomeBgSetting.SetParent(transform);
			}
			if(m_sceneSelectList != null)
			{
				while(!m_sceneSelectList.IsLoaded())
					yield return null;
				yield return StartCoroutine(m_sceneSelectList.LoadScrollObjectCoroutine(TransitionName));
			}
			IsReady = true;
		}

		// // RVA: 0x1380510 Offset: 0x1380510 VA: 0x1380510
		private void OnOpenPopupLimitOverList()
		{
			TodoLogger.LogNotImplemented("OnOpenPopupLimitOverList");
		}

		// // RVA: 0x1380624 Offset: 0x1380624 VA: 0x1380624
		// private void ReturnScene() { }

		// // RVA: 0x13806CC Offset: 0x13806CC VA: 0x13806CC
		// private void Listup(uint rarityFilterBit = 4294967295, uint attributeFilterBit = 4294967295, uint seriaseFilterBit = 4294967295, uint compatibleFilterBit = 4294967295, uint lskillRangeFilerBit = 4294967295, uint cskillRankFilerBit = 4294967295, uint askillRankFilerBit = 4294967295, uint lskillRankFilerBit = 4294967295, ulong cskillFilerBit = 18446744073709551615, ulong askillFilerBit = 18446744073709551615, ulong lskillFilerBit = 18446744073709551615, uint notesFilterBit = 4294967295, int episodeId = 0, bool isBonus = False, int rarityRestriction = -1) { }

		// // RVA: 0x1381204 Offset: 0x1381204 VA: 0x1381204
		// private void SortImpl() { }

		// // RVA: 0x138131C Offset: 0x138131C VA: 0x138131C
		// private int DefaultSortCb(int left, int right) { }

		// // RVA: 0x1382008 Offset: 0x1382008 VA: 0x1382008
		// private int EpisodeSortCb(int left, int right) { }

		// // RVA: 0x1382140 Offset: 0x1382140 VA: 0x1382140
		// private int GetSameEvaluationValue(GCIJNCFDNON left, GCIJNCFDNON right) { }

		// // RVA: 0x1381EF0 Offset: 0x1381EF0 VA: 0x1381EF0
		// private int GetSameEvaluationValue2(GCIJNCFDNON left, GCIJNCFDNON right) { }

		// // RVA: 0x1381F7C Offset: 0x1381F7C VA: 0x1381F7C
		// private int GetSameEvaluationValue3(GCIJNCFDNON left, GCIJNCFDNON right) { }

		// // RVA: 0x13821CC Offset: 0x13821CC VA: 0x13821CC
		// private void AttachScene(int slot, FFHPBEPOMAK divaData, GCIJNCFDNON sceneData) { }

		// // RVA: 0x1382318 Offset: 0x1382318 VA: 0x1382318
		// private void DetachScene(int slot, FFHPBEPOMAK divaData) { }

		// // RVA: 0x138236C Offset: 0x138236C VA: 0x138236C
		// private void AttachSceneGodiva(int slot, FFHPBEPOMAK divaData, JLKEOGLJNOD unitData, GCIJNCFDNON sceneData) { }

		// // RVA: 0x13823BC Offset: 0x13823BC VA: 0x13823BC
		// private void DetachSceneGoDiva(int slot, FFHPBEPOMAK divaData) { }

		// // RVA: 0x1382428 Offset: 0x1382428 VA: 0x1382428
		// private void AttachAssist(int page, int slot, EEMGHIINEHN assistData, GCIJNCFDNON sceneData) { }

		// // RVA: 0x1382478 Offset: 0x1382478 VA: 0x1382478
		// private void DetachAssist(int page, int slot, EEMGHIINEHN assistData) { }

		// // RVA: 0x13824B4 Offset: 0x13824B4 VA: 0x13824B4
		// private int GetEquSceneId(int selectedSlot, FFHPBEPOMAK divaData) { }

		// // RVA: 0x1382560 Offset: 0x1382560 VA: 0x1382560
		// private void ShowComparisonPopupWindow(GCIJNCFDNON beforeScene, GCIJNCFDNON afterScene, FFHPBEPOMAK diva) { }

		// // RVA: 0x1382B50 Offset: 0x1382B50 VA: 0x1382B50
		// private void ShowSelectHomeBgPopupWindow(SceneSelectHomeBgLayout.SetBgType bgType, GCIJNCFDNON sceneData) { }

		// RVA: 0x1382D3C Offset: 0x1382D3C VA: 0x1382D3C Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_missionId = 0;
			m_isBeginner = false;
			m_rarityRestriction = -1;
			m_isHomeSceneBg = false;
			bool isPlateMission = false;
			if(Args != null)
			{
				if(Args is EpisodeSceneListArgs)
				{
					EpisodeSceneListArgs eArgs = Args as EpisodeSceneListArgs;
					m_selectedEquipmentSlotIndex = -1;
					m_selectedDivaSlotIndex = -1;
					m_divaData = null;
					m_episodeId = eArgs.episodeId;
					m_assistViewData = null;
					m_assistPageIndex = 0;
					m_assistSlotIndex = 0;
					isPlateMission = false;
					m_isEnableBonus = false;
					m_isBeginner = eArgs.isFromBeginner;
					m_isGoDivaEvent = false;
					m_isBonus = false;
					m_selectedSceneId = 0;
					m_isCallEpisodeList = 0 < m_episodeId;
				}
				else if(Args is AssistSelectArgs)
				{
					AssistSelectArgs eArgs = Args as AssistSelectArgs;
					m_selectedDivaSlotIndex = -1;
					m_selectedEquipmentSlotIndex = -1;
					m_divaData = null;
					m_episodeId = 0;
					m_isEnableBonus = 0 < Database.Instance.bonusData.EffectiveEpisodeBonus.Count;
					m_assistViewData = eArgs.viewData;
					m_assistPageIndex = eArgs.pageIndex;
					isPlateMission = false;
					m_isGoDivaEvent = false;
					m_assistSlotIndex = eArgs.slotIndex;
					m_isBonus = false;
					m_selectedSceneId = 0;
					m_isCallEpisodeList = 0 < m_episodeId;
				}
				else if(Args is HomeBgSceneSelectArg)
				{
					HomeBgSceneSelectArg eArgs = Args as HomeBgSceneSelectArg;
					isPlateMission = false;
					m_selectedEquipmentSlotIndex = -1;
					m_selectedDivaSlotIndex = -1;
					m_divaData = null;
					m_episodeId = 0;
					m_assistViewData = null;
					m_assistPageIndex = 0;
					m_assistSlotIndex = 0;
					m_isEnableBonus = false;
					m_isHomeSceneBg = true;
					m_rarityRestriction = JKHEOEEPBMJ.DGGEAHIKPBB;
					m_isBonus = false;
					m_selectedSceneId = 0;
					m_isCallEpisodeList = 0 < m_episodeId;
				}
				else if(Args is SceneListArgs)
				{
					SceneListArgs eArgs = Args as SceneListArgs;
					m_isBeginner = eArgs.IsFromBiginner;
					isPlateMission = m_isBeginner;
					m_missionId = eArgs.MissionId;
					m_episodeId = 0;
					m_assistViewData = null;
					m_assistPageIndex = 0;
					m_assistSlotIndex = 0;
					m_isEnableBonus = false;
					m_isGoDivaEvent = false;
					m_isBonus = false;
					m_selectedSceneId = 0;
					m_isCallEpisodeList = 0 < m_episodeId;
				}
				else if(Args is TeamSelectSceneListArgs)
				{
					TeamSelectSceneListArgs eArgs = Args as TeamSelectSceneListArgs;
					m_selectedEquipmentSlotIndex = eArgs.defaultSelectScene;
					m_selectedDivaSlotIndex = eArgs.divaSlotIndex;
					m_divaData = eArgs.divaData;
					isPlateMission = false;
					m_episodeId = 0;
					m_assistViewData = null;
					m_assistPageIndex = 0;
					m_assistSlotIndex = 0;
					m_isEnableBonus = 0 < Database.Instance.bonusData.EffectiveEpisodeBonus.Count;
					m_isGoDivaEvent = eArgs.isGoDiva;
					m_friendPlayerData = eArgs.friendPlayerData;
					m_musicBaseData = eArgs.musicBaseData;
					m_enemyData = eArgs.enemyData;
					m_difficulty = eArgs.difficulty;
					m_isBonus = false;
					m_selectedSceneId = 0;
					m_isCallEpisodeList = 0 < m_episodeId;
				}
			}
			else
			{
				isPlateMission = false;
				m_missionId = 0;
				m_isBeginner = false;
				m_episodeId = 0;
				m_assistViewData = null;
				m_assistPageIndex = 0;
				m_assistSlotIndex = 0;
				m_isEnableBonus = false;
				m_isGoDivaEvent = false;
				m_isBonus = false;
				m_selectedSceneId = 0;
				m_isCallEpisodeList = 0 < m_episodeId;
			}
			m_sortButtonGroup.OnSortButton(m_popupFilterSortScene);
			m_sortButtonGroup.OnListSortEvent.RemoveAllListeners();
			m_sortButtonGroup.OnListSortEvent.AddListener(OnSortEvent);
			m_sortButtonGroup.OnLimitOverListEvent.RemoveAllListeners();
			m_sortButtonGroup.OnLimitOverListEvent.AddListener(OnOpenPopupLimitOverList);
			int val = 0;
			if(MenuScene.Instance.GetCurrentScene().uniqueId <  (int)TransitionUniqueId.SETTINGMENU_DIVASETTINGLIST_SCENESELECT)
			{
				if(MenuScene.Instance.GetCurrentScene().uniqueId != (int)TransitionUniqueId.SETTINGMENU_TEAMEDIT_DIVASELECTLIST_SCENESELECT)
				{
					val = 16;
					if(MenuScene.Instance.GetCurrentScene().uniqueId != ((int)TransitionUniqueId.SETTINGMENU | val))
					{
						m_sortButtonGroup.SetVisibleLimitOverListButton(false);
					}
				}
			}
			else if(MenuScene.Instance.GetCurrentScene().uniqueId != (int)TransitionUniqueId.SETTINGMENU_DIVASETTINGLIST_SCENESELECT)
			{
				val = 58;
				if(MenuScene.Instance.GetCurrentScene().uniqueId != ((int)TransitionUniqueId.SETTINGMENU | val))
				{
					m_sortButtonGroup.SetVisibleLimitOverListButton(false);
				}
			}
			if(TransitionName == TransitionList.Type.SCENE_SELECT)
			{
				m_sortButtonGroup.SelectedDivaId = m_divaData.AHHJLDLAPAN_DivaId;
			}
			if(TransitionName == TransitionList.Type.ASSIST_SELECT)
			{
				m_sortButtonGroup.SelectedAttrId = m_assistSlotIndex;
			}
			m_sceneSelectList.OnSelectSceneEvent.RemoveAllListeners();
			m_sceneSelectList.OnSelectSceneEvent.AddListener(OnSelectListScene);
			m_sceneSelectList.OnRemoveSceneEvent.RemoveAllListeners();
			m_sceneSelectList.OnRemoveSceneEvent.AddListener(OnRemoveScene);
			SetDefaultSortParamFromLocalSave();
			if(isPlateMission)
			{
				m_sortType = SortItem.Get;
				m_order = 0;
			}
			Sort(m_isBonus, isPlateMission);
			m_sortButtonGroup.UpdateContent(m_sortType, (SortOrder)m_order, m_isBonus, m_isEnableBonus);
			m_dispRowCount = m_equipmentScene == null ? 3 : 2;
			if(m_isBeginner)
			{
				int sceneId = 1;
				if(m_missionId == 5)
					sceneId = 3;
				if(m_sceneIndexList.FindIndex((int x) => {
					//0xA5829C
					return PlayerData.OPIBAPEGCLA_Scenes[x].BCCHOBPJJKE_SceneId == sceneId;
				}) < 0)
					return;
				m_selectedSceneId = sceneId;
			}
			DisplayType type;
			UnitWindowConstant.SortItemToDisplayType.TryGetValue((int)m_sortType, out type);
			m_sceneSelectList.DivaSlot = m_selectedDivaSlotIndex;
			m_sceneSelectList.InitializeDecoration();
			m_sceneSelectList.OnShowSceneStatusEvent.RemoveAllListeners();
			m_sceneSelectList.OnShowSceneStatusEvent.AddListener(OnShowListSceneStatus);
			int musicId = m_musicBaseData != null ? m_musicBaseData.DLAEJOBELBH_MusicId : 0;
			m_sceneSelectList.UpdateContent(PlayerData, m_divaData, musicId, PlayerData.OPIBAPEGCLA_Scenes, 
				m_sceneIndexList, m_selectedSceneId, type, m_dispRowCount, m_transitionName, m_isGoDivaEvent);
			if(m_assistViewData == null)
			{
				if(!m_isHomeSceneBg)
				{
					m_sceneSelectList.UpdateRemoveButton(m_divaData, m_selectedEquipmentSlotIndex);
				}
				else
				{
					m_sceneSelectList.UpdateRemoveButton(JKHEOEEPBMJ.AIEDAEPONAB_GetHomeSceneInfo(PlayerData));
				}
			}
			else
			{
				m_sceneSelectList.UpdateRemoveButton(m_assistViewData.ELBLMMPEKPH(m_assistPageIndex, m_assistSlotIndex));
			}
			m_sceneSelectList.SetSelectedSlot(m_selectedEquipmentSlotIndex);
			if(m_musicBaseData != null)
			{
				CMMKCEPBIHI.EFCNOOFFMIL(PlayerData, m_friendPlayerData, m_musicBaseData, m_enemyData, m_difficulty, Database.Instance.gameSetup.musicInfo.IsLine6Mode, m_isGoDivaEvent);
			}
			m_sceneSelectList.UpdateScore(m_musicBaseData);
			if(m_equipmentScene != null)
			{
				m_equipmentScene.OnSelectSlotEvent.RemoveAllListeners();
				m_equipmentScene.OnSelectSlotEvent.AddListener(OnSelectEquipmentScene);
				m_equipmentScene.OnShowSceneStatusEvent.RemoveAllListeners();
				m_equipmentScene.OnShowSceneStatusEvent.AddListener(OnShowEquipmentSceneStatus);
				m_equipmentScene.InitializeDecoration();
				if(m_assistViewData == null)
				{
					if(!m_isHomeSceneBg)
					{
						if(!m_isGoDivaEvent)
						{
							m_equipmentScene.UpdateContent(PlayerData, m_divaData, m_selectedDivaSlotIndex == 0, musicId, false);
							m_equipmentScene.SelectSlot(m_selectedEquipmentSlotIndex);
							m_equipmentScene.ChangeIcon(PlayerData, m_divaData, type, m_selectedDivaSlotIndex == 0, false);
						}
						else
						{
							m_equipmentScene.UpdateContent(PlayerData, m_divaData, m_selectedDivaSlotIndex == 0, musicId, true);
							m_equipmentScene.SelectSlot(m_selectedEquipmentSlotIndex);
							m_equipmentScene.ChangeIcon(PlayerData, m_divaData, type, m_selectedDivaSlotIndex == 0, true);
						}
					}
					else
					{
						m_equipmentScene.UpdateHomeBgSceneContent(JKHEOEEPBMJ.AIEDAEPONAB_GetHomeSceneInfo(PlayerData), JKHEOEEPBMJ.HDLMKFFMGEP_GetHomeSceneEvolveId());
						m_equipmentScene.SelectSlot(0);
					}
				}
				else
				{
					m_equipmentScene.UpdateAssistContent(PlayerData, m_assistViewData.ELBLMMPEKPH(m_assistPageIndex, m_assistSlotIndex), m_assistSlotIndex);
					m_equipmentScene.SelectSlot(0);
					m_equipmentScene.ChangeIcon(m_assistViewData.ELBLMMPEKPH(m_assistPageIndex, m_assistSlotIndex), type, 0);
				}
			}
			m_sceneSelectList.SetWait();
			GameManager.Instance.SceneIconCache.TryInstall(PlayerData);
		}

		// RVA: 0x13850A0 Offset: 0x13850A0 VA: 0x13850A0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(!KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
			{
				return base.IsEndPreSetCanvas();
			}
			return false;
		}

		// RVA: 0x1385158 Offset: 0x1385158 VA: 0x1385158 Slot: 21
		protected override void OnOpenScene()
		{
			MenuScene.Instance.TryShowPopupWindow(this, PlayerData, m_musicBaseData, false, TransitionName, UpdateListItem);
		}

		// RVA: 0x1385268 Offset: 0x1385268 VA: 0x1385268 Slot: 14
		protected override void OnDestoryScene()
		{
			if(m_equipmentScene != null)
			{
				m_equipmentScene.ReleaseDecoration();
			}
			m_sceneSelectList.ReleaseDecoration();
		}

		// RVA: 0x1385338 Offset: 0x1385338 VA: 0x1385338 Slot: 15
		protected override void OnDeleteCache()
		{
			m_sceneComparisonPopupSetting = null;
			m_sceneSelectHomeBgSetting = null;
		}

		// RVA: 0x1385348 Offset: 0x1385348 VA: 0x1385348 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_sceneSelectList.Show();
			if(!m_isCallEpisodeList)
			{
				m_sortButtonGroup.Show();
				m_sceneSelectList.HideEpisodePoint();
			}
			else
			{
				m_sceneSelectList.ShowEpisodePoint();
				m_episodeData.KHEKNNFCAOI(m_episodeId);
				m_sceneSelectList.SetEpisodePoint(m_episodeData.ABLHIAEDJAI_CurrentPoint, m_episodeData.DMHDNKILKGI_MaxPoint);
			}
		}

		// RVA: 0x1385460 Offset: 0x1385460 VA: 0x1385460 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_sortButtonGroup.IsPlaying() && !m_sceneSelectList.IsPlaying();
		}

		// RVA: 0x13854BC Offset: 0x13854BC VA: 0x13854BC Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_sceneSelectList.Hide();
			if(!m_isCallEpisodeList)
			{
				m_sortButtonGroup.Hide();
			}
		}

		// RVA: 0x1385514 Offset: 0x1385514 VA: 0x1385514 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_sortButtonGroup.IsPlaying() && !m_sceneSelectList.IsPlaying();
		}

		// RVA: 0x1385570 Offset: 0x1385570 VA: 0x1385570 Slot: 23
		protected override void OnActivateScene()
		{
			if(m_isBeginner)
			{
				int sceneId = m_missionId == 5 ? 3 : 1;
				int idx = m_sceneIndexList.FindIndex((int x) => {
					//0xA58380
					return PlayerData.OPIBAPEGCLA_Scenes[x].BCCHOBPJJKE_SceneId == sceneId;
				});
				if(idx > -1)
				{
					for(int i = 0; i < m_sceneSelectList.Scroll.ScrollObjectCount; i++)
					{
						if(m_sceneSelectList.Scroll.ScrollObjects[i].Index == idx)
						{
							if(i > -1)
							{
								StayButton button = m_sceneSelectList.Scroll.ScrollObjects[i].GetComponentInChildren<StayButton>(true);
								button.ClearOnStayCallback();
								if(m_missionId == 5)
								{
									StartCoroutine(TutorialProc.Co_PlateGrowth(button));
									m_isBeginner = false;
								}
								else
								{
									GameManager.PushBackButtonHandler dymmyBackHandler = () => {
										//0xA56B6C
										return;
									};
									GameManager.Instance.AddPushBackButtonHandler(dymmyBackHandler);
									BasicTutorialManager.Instance.ShowMessageWindow(BasicTutorialMessageId.Id_EpisodeMission2, () => {
										//0xA5846C
										TodoLogger.Log(0, "Tutorial");
									}, null);
								}
							}
							return;
						}
					}
				}
			}
		}

		// RVA: 0x1385A84 Offset: 0x1385A84 VA: 0x1385A84 Slot: 25
		protected override void OnTutorial()
		{
			TodoLogger.Log(0, "Tutorial");
		}

		// RVA: 0x1385C64 Offset: 0x1385C64 VA: 0x1385C64
		// private void SetTutorialPopupDecide() { }

		// // RVA: 0x13844DC Offset: 0x13844DC VA: 0x13844DC
		private void SetDefaultSortParamFromLocalSave()
		{
			if(!m_isCallEpisodeList)
			{
				if(TransitionName == TransitionList.Type.SCENE_SELECT)
				{
					m_sortType = (SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.LNFFKCDNCPN_sceneSelectSortItem;
					m_order = (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CIDJJBFGHIE_sceneSelectSortOrder;
				}
				else if(TransitionName == TransitionList.Type.ASSIST_SELECT)
				{
					m_sortType = (SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.NCDOLBOHGFN_sceneAssistSortItem;
					m_order = (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.OGFJPNKICGI_sceneAssistSortOrder;
				}
				else if(TransitionName == TransitionList.Type.HOME_BG_SELECT)
				{
					m_sortType = SortItem.Rarity;
					m_order = (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GIDCHFBCBML_SelectHomeBG.EILKGEADKGH_Order;
				}
				else
				{
					m_sortType = (SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GEAECNMDMHH_sceneListSortItem;
					m_order = (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CLKCCJJJPLB_sceneListSortOrder;
				}
			}
			else
			{
				m_sortType = SortItem.Level;
				m_order = 1;
			}
			if(!UnitWindowConstant.SortItemToDisplayType.ContainsKey((int)m_sortType))
			{
				m_sortType = SortItem.Total;
			}
		}

		// // RVA: 0x1385DD0 Offset: 0x1385DD0 VA: 0x1385DD0
		private void OnSortEvent(SortItem item, ListSortButtonGroup.SortOrder order, bool isBonus)
		{
			TodoLogger.LogNotImplemented("OnSortEvent");
		}

		// // RVA: 0x1384A14 Offset: 0x1384A14 VA: 0x1384A14
		private void Sort(bool isBonus, bool isPlateMission = false)
		{
			TodoLogger.Log(0, "Sort");
		}

		// // RVA: 0x1386738 Offset: 0x1386738 VA: 0x1386738
		// private uint MakeAssistAttributeBit(ILDKBCLAFPB.IJDOCJCLAIL saveData) { }

		// // RVA: 0x138677C Offset: 0x138677C VA: 0x138677C
		private void OnSelectListScene(int listIndex)
		{
			TodoLogger.LogNotImplemented("OnSelectListScene");
		}

		// // RVA: 0x1386BFC Offset: 0x1386BFC VA: 0x1386BFC
		private void OnRemoveScene()
		{
			TodoLogger.LogNotImplemented("OnRemoveScene");
		}

		// // RVA: 0x1386C84 Offset: 0x1386C84 VA: 0x1386C84
		// private void RemoveScenePopupWindow() { }

		// // RVA: 0x1386DEC Offset: 0x1386DEC VA: 0x1386DEC
		// private void RemoveHomeBgPopupWindow() { }

		// // RVA: 0x1386EC0 Offset: 0x1386EC0 VA: 0x1386EC0
		private void OnShowListSceneStatus(int listIndex)
		{
			TodoLogger.LogNotImplemented("OnShowListSceneStatus");
		}

		// // RVA: 0x13870E4 Offset: 0x13870E4 VA: 0x13870E4
		private void UpdateListItem()
		{
			m_sceneSelectList.UpdateRegion();
			if(m_equipmentScene != null)
			{
				DisplayType type;
				UnitWindowConstant.SortItemToDisplayType.TryGetValue((int)m_sortType, out type);
				if(m_divaData != null)
				{
					m_equipmentScene.ChangeIcon(PlayerData, m_divaData, type, m_selectedEquipmentSlotIndex == 0, m_isGoDivaEvent);
				}
				if(m_assistViewData != null)
				{
					m_equipmentScene.ChangeIcon(m_assistViewData.ELBLMMPEKPH(m_assistPageIndex, m_assistSlotIndex), type, 0);
				}
			}
		}

		// // RVA: 0x1387310 Offset: 0x1387310 VA: 0x1387310
		private void OnSelectEquipmentScene(int equipmentSlotIndex)
		{
			TodoLogger.LogNotImplemented("OnSelectEquipmentScene");
		}

		// // RVA: 0x13873F4 Offset: 0x13873F4 VA: 0x13873F4
		private void OnShowEquipmentSceneStatus(int equipmentSlotIndex)
		{
			TodoLogger.LogNotImplemented("OnShowEquipmentSceneStatus");
		}

		// // RVA: 0x1386670 Offset: 0x1386670 VA: 0x1386670
		// private SceneIconScrollContent.SkillIconType CheckSkillIconType(JLKEOGLJNOD unitData, FFHPBEPOMAK diva) { }

		// RVA: 0x1387780 Offset: 0x1387780 VA: 0x1387780 Slot: 28
		protected override TransitionArgs GetCallArgsReturn()
		{
			if(PrevTransition == TransitionList.Type.PROFIL)
			{
				ProfilDateArgs res = new ProfilDateArgs();
				res.infoType = ProfilMenuLayout.InfoType.ASSIST;
				res.isShowMyProfil = true;
				return res;
			}
			return base.GetCallArgsReturn();
		}

		// // RVA: 0x138508C Offset: 0x138508C VA: 0x138508C
		// private bool IsCenterDiva() { }

		// [CompilerGeneratedAttribute] // RVA: 0x72E24C Offset: 0x72E24C VA: 0x72E24C
		// // RVA: 0x1387B68 Offset: 0x1387B68 VA: 0x1387B68
		// private void <OnOpenPopupLimitOverList>b__47_0() { }
	}
}
