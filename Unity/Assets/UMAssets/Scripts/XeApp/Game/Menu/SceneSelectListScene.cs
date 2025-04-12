using System;
using System.Collections;
using System.Collections.Generic;
using mcrs;
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
		private FFHPBEPOMAK_DivaInfo m_divaData; // 0x68
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
		private EAJCBFGKKFA_FriendInfo m_friendPlayerData; // 0xA0
		private EEDKAACNBBG_MusicData m_musicBaseData; // 0xA4
		private EJKBKMBJMGL_EnemyData m_enemyData; // 0xA8
		private Difficulty.Type m_difficulty; // 0xAC
		private EEMGHIINEHN m_assistViewData; // 0xB0
		private int m_assistPageIndex; // 0xB4
		private int m_assistSlotIndex; // 0xB8
		private bool m_isHomeSceneBg; // 0xBC
		private bool m_isGoDivaEvent; // 0xBD

		private DFKGGBMFFGB_PlayerInfo PlayerData { get { return GameManager.Instance.ViewPlayerData; } } //0x1380250

		// RVA: 0x13802EC Offset: 0x13802EC VA: 0x13802EC Slot: 5
		protected override void Start()
		{
			this.StartCoroutineWatched(InitializeCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72E0C4 Offset: 0x72E0C4 VA: 0x72E0C4
		// // RVA: 0x1380398 Offset: 0x1380398 VA: 0x1380398
		private IEnumerator Co_SceneSortButtonLayout(string bundleName, XeSys.FontInfo font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0xA5869C
			if(m_transitionName == TransitionList.Type.SCENE_ABILITY_RELEASE_LIST)
				yield break;
			if(m_sortButtonGroup != null)
				yield break;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_card_btn_layout_root");
			yield return Co.R(operation);
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
				//0x138794C
				instance.transform.SetParent(transform, false);
				m_sortButtonGroup = instance.GetComponentInChildren<ListSortButtonGroup>(true);
				m_sortButtonGroup.SortPlace = m_sortPlace;
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			operation = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72E13C Offset: 0x72E13C VA: 0x72E13C
		// // RVA: 0x1380454 Offset: 0x1380454 VA: 0x1380454
		private IEnumerator Co_SelectWindowLayout(string bundleName, XeSys.FontInfo font)
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
			yield return Co.R(operation);
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) => {
				//0x1387A48
				instance.transform.SetParent(transform, false);
				m_equipmentScene = instance.GetComponentInChildren<EquipmentScene>(true);
				m_sceneSelectList = instance.GetComponentInChildren<SceneSelectList>(true);
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			operation = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72E1B4 Offset: 0x72E1B4 VA: 0x72E1B4
		// // RVA: 0x1380310 Offset: 0x1380310 VA: 0x1380310
		private IEnumerator InitializeCoroutine()
		{
			string bundleName; // 0x14
			XeSys.FontInfo systemFont; // 0x18

			//0xA58CBC
			bundleName = "ly/014.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle(bundleName));
			yield return Co.R(Co_SelectWindowLayout(bundleName, systemFont));
			yield return Co.R(Co_SceneSortButtonLayout(bundleName, systemFont));
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
				yield return this.StartCoroutineWatched(m_sceneSelectList.LoadScrollObjectCoroutine(TransitionName));
			}

			IsReady = true;
		}

		// // RVA: 0x1380510 Offset: 0x1380510 VA: 0x1380510
		private void OnOpenPopupLimitOverList()
		{
			PopupLimitOverList.Show(PlayerData, m_order, PlayerData.OPIBAPEGCLA_Scenes, m_sceneIndexList, m_isBeginner, 0, () =>
			{
				//0x1387B68
				if(MenuScene.Instance != null)
				{
					if(!MenuScene.Instance.IsTransition())
					{
						m_sceneSelectList.UpdateContent(PlayerData, m_divaData, m_musicBaseData != null ? m_musicBaseData.DLAEJOBELBH_MusicId : 0, PlayerData.OPIBAPEGCLA_Scenes, m_sceneIndexList, m_selectedSceneId, UnitWindowConstant.SortItemToDisplayType[(int)m_sortType], m_dispRowCount, m_transitionName, false);
					}
				}
			});
		}

		// // RVA: 0x1380624 Offset: 0x1380624 VA: 0x1380624
		// private void ReturnScene() { }

		// // RVA: 0x13806CC Offset: 0x13806CC VA: 0x13806CC
		private void Listup(uint rarityFilterBit = 4294967295, uint attributeFilterBit = 4294967295, uint seriaseFilterBit = 4294967295, uint compatibleFilterBit = 4294967295, uint lskillRangeFilerBit = 4294967295, uint cskillRankFilerBit = 4294967295, uint askillRankFilerBit = 4294967295, uint lskillRankFilerBit = 4294967295, ulong cskillFilerBit = 18446744073709551615, ulong askillFilerBit = 18446744073709551615, ulong lskillFilerBit = 18446744073709551615, uint notesFilterBit = 4294967295, int episodeId = 0, bool isBonus = false, int rarityRestriction = -1)
		{
			m_sceneIndexList.Clear();
			MLIBEPGADJH_Scene sceneDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene;
			if(m_transitionName == TransitionList.Type.HOME_BG_SELECT || 
				m_transitionName == TransitionList.Type.ASSIST_SELECT ||
				m_transitionName == TransitionList.Type.SCENE_SELECT)
			{
				m_sceneIndexList.Add(-1);
			}
			for(int i = 0; i < PlayerData.OPIBAPEGCLA_Scenes.Count; i++)
			{
				GCIJNCFDNON_SceneInfo scene = PlayerData.OPIBAPEGCLA_Scenes[i];
				if(sceneDb.FGNJBMPDBLO_IsSceneValid(scene.BCCHOBPJJKE_SceneId))
				{
					if(scene.CGKAEMGLHNK_IsUnlocked(true))
					{
						if(episodeId == 0)
						{
							if(!scene.MCCIFLKCNKO_Feed)
							{
								if(isBonus)
								{
									if(Database.Instance.bonusData.EffectiveEpisodeBonus.Find((IKDICBBFBMI_EventBase.GNPOABJANKO x) => {
										//0xA56EB4
										return scene.KELFCMEOPPM_EpisodeId == x.KELFCMEOPPM_EpisodeId;
									}) == null)
									{
										continue;
									}
								}
								if(PopupSortMenu.IsRarityFilterOn(scene.EKLIPGELKCL_SceneRarity, rarityFilterBit) && 
									PopupSortMenu.IsAttributeFilterOn(scene.JGJFIJOCPAG_SceneAttr, attributeFilterBit) && 
									PopupSortMenu.IsSerializeFilterOn((int)scene.AIHCEGFANAM_SceneSeries, seriaseFilterBit) && 
									PopupSortMenu.IsCompatibleFilterOn(scene.AOLIJKMIJJE_DivaCompatible, compatibleFilterBit) && 
									PopupSortMenu.IsNotesFilterOn(scene.IGPMJPPAILL_Note, notesFilterBit) && 
									PopupSortMenu.IsSkillRangeFilterOn(scene.BJJNCCGPBGN, lskillRangeFilerBit) && 
									PopupSortMenu.IsSkillRankFilterOn(scene.DHEFMEGKKDN_CenterSkillRank, scene.FFDCGHDNDFJ_CenterSkillRank2, cskillRankFilerBit, true, scene, m_musicBaseData) &&
									PopupSortMenu.IsSkillRankFilterOn(scene.BEKGEAMJGEN_ActiveSkillRank, scene.BEKGEAMJGEN_ActiveSkillRank, askillRankFilerBit) && 
									PopupSortMenu.IsSkillRankFilterOn(scene.OAHMFMJIENM_LiveSkillRank, scene.ELNJADBILOM_LiveSkillRank2, lskillRankFilerBit, false, scene, m_musicBaseData) && 
									PopupSortMenu.IsCenterSkillFilterOn(scene, cskillFilerBit) &&
									PopupSortMenu.IsActiveSkillFilterOn(scene, askillFilerBit) && 
									PopupSortMenu.IsLiveSkillFilterOn(scene, lskillFilerBit)
								)
								{
									if(m_rarityRestriction > 0)
									{
										if(scene.JKGFBFPIMGA_Rarity < m_rarityRestriction)
											continue;
									}
									m_sceneIndexList.Add(i);
								}
							}
						}
						else
						{
							if(episodeId == scene.KELFCMEOPPM_EpisodeId)
							{
								m_sceneIndexList.Add(i);
							}
						}
					}
				}
			}
		}

		// // RVA: 0x1381204 Offset: 0x1381204 VA: 0x1381204
		private void SortImpl()
		{
			if(!m_isCallEpisodeList)
			{
				m_sceneIndexList.Sort(DefaultSortCb);
			}
			else
			{
				m_sceneIndexList.Sort(EpisodeSortCb);
			}
		}

		// // RVA: 0x138131C Offset: 0x138131C VA: 0x138131C
		private int DefaultSortCb(int left, int right)
		{
			if (left < 0)
				return -1;
			if (right < 0)
				return 1;
			GCIJNCFDNON_SceneInfo lscene = PlayerData.OPIBAPEGCLA_Scenes[left];
			GCIJNCFDNON_SceneInfo rscene = PlayerData.OPIBAPEGCLA_Scenes[right];
			long leftVal = 0;
			long rightVal = 0;
			if (m_sortType <= SortItem.UtaRate)
			{
				switch (m_sortType)
				{
					case SortItem.Total:
						leftVal = lscene.CMCKNKKCNDK_Status.Total;
						rightVal = rscene.CMCKNKKCNDK_Status.Total;
						break;
					case SortItem.Soul:
						leftVal = lscene.CMCKNKKCNDK_Status.soul;
						rightVal = rscene.CMCKNKKCNDK_Status.soul;
						break;
					case SortItem.Voice:
						leftVal = lscene.CMCKNKKCNDK_Status.vocal;
						rightVal = rscene.CMCKNKKCNDK_Status.vocal;
						break;
					case SortItem.Charm:
						leftVal = lscene.CMCKNKKCNDK_Status.charm;
						rightVal = rscene.CMCKNKKCNDK_Status.charm;
						break;
					case SortItem.Get:
						leftVal = lscene.NPHOIEOPIJO;
						rightVal = rscene.NPHOIEOPIJO;
						break;
					case SortItem.Rarity:
						leftVal = lscene.EKLIPGELKCL_SceneRarity;
						rightVal = rscene.EKLIPGELKCL_SceneRarity;
						break;
					case SortItem.Level:
						leftVal = lscene.CIEOBFIIPLD_SceneLevel;
						rightVal = rscene.CIEOBFIIPLD_SceneLevel;
						break;
					case SortItem.Life:
						leftVal = lscene.CMCKNKKCNDK_Status.life;
						rightVal = rscene.CMCKNKKCNDK_Status.life;
						break;
					case SortItem.Luck:
						leftVal = lscene.MJBODMOLOBC_Luck;
						rightVal = rscene.MJBODMOLOBC_Luck;
						break;
					case SortItem.Support:
						leftVal = lscene.CMCKNKKCNDK_Status.support;
						rightVal = rscene.CMCKNKKCNDK_Status.support;
						break;
					case SortItem.Fold:
						leftVal = lscene.CMCKNKKCNDK_Status.fold;
						rightVal = rscene.CMCKNKKCNDK_Status.fold;
						break;
					case SortItem.RecoveryNotes:
					case SortItem.ItemNotes:
					case SortItem.ScoreUpNotes:
					case SortItem.SupportNotes:
					case SortItem.FoldNotes:
						leftVal = lscene.CMCKNKKCNDK_Status.spNoteExpected[(int)m_sortType - 10];
						rightVal = rscene.CMCKNKKCNDK_Status.spNoteExpected[(int)m_sortType - 10];
						break;
					default:
						break;
					case SortItem.ActiveSkill:
						if (lscene.HGONFBDIBPM_ActiveSkillId < 1)
							left = 0;
						else
							left = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[lscene.HGONFBDIBPM_ActiveSkillId - 1].GIEFBAHPMMM;
						if (rscene.HGONFBDIBPM_ActiveSkillId < 1)
							right = 0;
						else
							right = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[rscene.HGONFBDIBPM_ActiveSkillId - 1].GIEFBAHPMMM;
						break;
					case SortItem.LiveSkill:
						int id = lscene.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
						if (id < 1)
							left = 0;
						else
							left = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[id - 1].GIEFBAHPMMM;
						id = rscene.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
						if (id < 1)
							right = 0;
						else
							right = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[id - 1].GIEFBAHPMMM;
						break;
					case SortItem.Episode:
						leftVal = lscene.KELFCMEOPPM_EpisodeId;
						rightVal = rscene.KELFCMEOPPM_EpisodeId;
						break;
					case SortItem.SecretBoard:
						leftVal = lscene.JPIPENJGGDD_NumBoard;
						rightVal = rscene.JPIPENJGGDD_NumBoard;
						break;
					case SortItem.LuckyLeaf:
						leftVal = lscene.MKHFCGPJPFI_LimitOverCount;
						rightVal = rscene.MKHFCGPJPFI_LimitOverCount;
						break;
					case SortItem.NotesExpectation:
						leftVal = lscene.KMFADKEKPOM_Nx;
						rightVal = rscene.KMFADKEKPOM_Nx;
						break;
				}
			}
			int res = (int)(leftVal - rightVal);
			if(res == 0)
			{
				res = GetSameEvaluationValue2(lscene, rscene);
				if (res == 0)
				{
					return GetSameEvaluationValue3(lscene, rscene);
				}
			}
			else
			{
				if (res < 0)
					res = -1;
				else
					res = 1;
			}
			if (m_order != 0)
				res = -res;
			return res;
		}

		// // RVA: 0x1382008 Offset: 0x1382008 VA: 0x1382008
		private int EpisodeSortCb(int left, int right)
		{
			GCIJNCFDNON_SceneInfo lscene = PlayerData.OPIBAPEGCLA_Scenes[left];
			GCIJNCFDNON_SceneInfo rscene = PlayerData.OPIBAPEGCLA_Scenes[right];
			return GetSameEvaluationValue(lscene, rscene);
		}

		// // RVA: 0x1382140 Offset: 0x1382140 VA: 0x1382140
		private int GetSameEvaluationValue(GCIJNCFDNON_SceneInfo left, GCIJNCFDNON_SceneInfo right)
		{
			return SortMenuWindow.GetSameEvaluationValue(left, right);
		}

		// // RVA: 0x1381EF0 Offset: 0x1381EF0 VA: 0x1381EF0
		private int GetSameEvaluationValue2(GCIJNCFDNON_SceneInfo left, GCIJNCFDNON_SceneInfo right)
		{
			return SortMenuWindow.SortSecondPriority(left, right);
		}

		// // RVA: 0x1381F7C Offset: 0x1381F7C VA: 0x1381F7C
		private int GetSameEvaluationValue3(GCIJNCFDNON_SceneInfo left, GCIJNCFDNON_SceneInfo right)
		{
			return SortMenuWindow.SortThirdPriority(left, right);
		}

		// // RVA: 0x13821CC Offset: 0x13821CC VA: 0x13821CC
		private void AttachScene(int slot, FFHPBEPOMAK_DivaInfo divaData, GCIJNCFDNON_SceneInfo sceneData)
		{
			if(slot == 0)
			{
				divaData.OKDIEDCGODF(sceneData.BCCHOBPJJKE_SceneId, false, PlayerData.HJBAALOOKMO, PlayerData.POJLFHIAGID);
			}
			else
			{
				divaData.IFFMDJHENHB(slot - 1, sceneData.BCCHOBPJJKE_SceneId, false, PlayerData.HJBAALOOKMO, PlayerData.POJLFHIAGID);
			}
		}

		// // RVA: 0x1382318 Offset: 0x1382318 VA: 0x1382318
		private void DetachScene(int slot, FFHPBEPOMAK_DivaInfo divaData)
		{
			if(slot != 0)
				divaData.BCEJOOCGBFG(slot - 1, false);
			else
				divaData.MNBNLONEDPF(false);
		}

		// // RVA: 0x138236C Offset: 0x138236C VA: 0x138236C
		private void AttachSceneGodiva(int slot, FFHPBEPOMAK_DivaInfo divaData, JLKEOGLJNOD_TeamInfo unitData, GCIJNCFDNON_SceneInfo sceneData)
		{
			unitData.FLFBBPLPNMO(sceneData, slot, m_selectedDivaSlotIndex);
		}

		// // RVA: 0x13823BC Offset: 0x13823BC VA: 0x13823BC
		private void DetachSceneGoDiva(int slot, FFHPBEPOMAK_DivaInfo divaData)
		{
			if(slot != 0)
			{
				divaData.GIGDKIHBDHB(null, slot - 1, true);
			}
			else
			{
				divaData.CJBBDBGDFKJ(null, true);
			}
		}

		// // RVA: 0x1382428 Offset: 0x1382428 VA: 0x1382428
		private void AttachAssist(int page, int slot, EEMGHIINEHN assistData, GCIJNCFDNON_SceneInfo sceneData)
		{
			assistData.CLFGOPNDGNL_SetScene(sceneData, page, slot);
		}

		// // RVA: 0x1382478 Offset: 0x1382478 VA: 0x1382478
		private void DetachAssist(int page, int slot, EEMGHIINEHN assistData)
		{
			assistData.NODLMHKAGFD_RemoveScene(page, slot);
		}

		// // RVA: 0x13824B4 Offset: 0x13824B4 VA: 0x13824B4
		// private int GetEquSceneId(int selectedSlot, FFHPBEPOMAK divaData) { }

		// // RVA: 0x1382560 Offset: 0x1382560 VA: 0x1382560
		private void ShowComparisonPopupWindow(GCIJNCFDNON_SceneInfo beforeScene, GCIJNCFDNON_SceneInfo afterScene, FFHPBEPOMAK_DivaInfo diva)
		{
			if(afterScene != null)
			{
				afterScene.CADENLBDAEB_New = false;
			}
			Action ac = null;
			if(GameManager.Instance.IsTutorial)
				ac = SetTutorialPopupDecide;

			m_sceneComparisonPopupSetting.Buttons = new ButtonInfo[2] {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_sceneComparisonPopupSetting.AfterScene = afterScene;
			m_sceneComparisonPopupSetting.BeforeScene = beforeScene;
			m_sceneComparisonPopupSetting.PlayerData = PlayerData;
			m_sceneComparisonPopupSetting.DivaData = diva;
			m_sceneComparisonPopupSetting.SceneSlotIndex = m_selectedEquipmentSlotIndex;
			m_sceneComparisonPopupSetting.DivaSlot = m_selectedDivaSlotIndex;
			m_sceneComparisonPopupSetting.FriendPlayerData = m_friendPlayerData;
			m_sceneComparisonPopupSetting.MusicBaseData = m_musicBaseData;
			m_sceneComparisonPopupSetting.EnemyData = m_enemyData;
			m_sceneComparisonPopupSetting.Difficulty = m_difficulty;
			m_sceneComparisonPopupSetting.SetParent(transform);
			m_sceneComparisonPopupSetting.IsGoDiva = m_isGoDivaEvent;
			PopupWindowManager.Show(m_sceneComparisonPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) => {
				//0xA56F08
				if(type != PopupButton.ButtonType.Negative)
				{
					int musicId = 0;
					if(m_musicBaseData != null)
					{
						musicId = m_musicBaseData.DLAEJOBELBH_MusicId;
					}
					DisplayType displayType;
					UnitWindowConstant.SortItemToDisplayType.TryGetValue((int)m_sortType, out displayType);
					if(m_assistViewData == null)
					{
						if(!m_isGoDivaEvent)
						{
							if(afterScene == null)
							{
								DetachScene(m_selectedEquipmentSlotIndex, diva);
							}
							else
							{
								AttachScene(m_selectedEquipmentSlotIndex, diva, afterScene);
							}
							m_equipmentScene.UpdateContent(PlayerData, diva, IsCenterDiva(), musicId, false);
							m_equipmentScene.SelectSlot(m_selectedEquipmentSlotIndex);
							m_equipmentScene.ChangeIcon(PlayerData, diva, displayType, IsCenterDiva(), false);
							diva.HCDGELDHFHB();
							PlayerData.DPLBHAIKPGL_GetTeam(false).HCDGELDHFHB();
							m_sceneSelectList.UpdateRemoveButton(m_divaData, m_selectedEquipmentSlotIndex);
							if(m_musicBaseData != null)
							{
								CMMKCEPBIHI.EFCNOOFFMIL(PlayerData, m_friendPlayerData, m_musicBaseData, m_enemyData, m_difficulty, Database.Instance.gameSetup.musicInfo.IsLine6Mode, m_isGoDivaEvent);
							}
							m_sceneSelectList.UpdateScore(m_musicBaseData);
							if(!GameManager.Instance.IsTutorial)
							{
								ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.AFLMHBMBNBO_48, 2, false);
							}
							ILCCJNDFFOB.HHCJCDFCLOB.KHMDGNKEFOD(JpStringLiterals.StringLiteral_15651, 0, false, false, 1);
						}
						else
						{
							if(afterScene == null)
							{
								DetachSceneGoDiva(m_selectedEquipmentSlotIndex, diva);
							}
							else
							{
								AttachSceneGodiva(m_selectedEquipmentSlotIndex, diva, PlayerData.DPLBHAIKPGL_GetTeam(true), afterScene);
							}
							m_equipmentScene.UpdateContent(PlayerData, diva, IsCenterDiva(), musicId, true);
							m_equipmentScene.SelectSlot(m_selectedEquipmentSlotIndex);
							m_equipmentScene.ChangeIcon(PlayerData, diva, displayType, IsCenterDiva(), true);
							PlayerData.DPLBHAIKPGL_GetTeam(true).HCDGELDHFHB();
							m_sceneSelectList.UpdateRemoveButton(m_divaData, m_selectedEquipmentSlotIndex);
							if(m_musicBaseData != null)
							{
								CMMKCEPBIHI.EFCNOOFFMIL(PlayerData, m_friendPlayerData, m_musicBaseData, m_enemyData, m_difficulty, Database.Instance.gameSetup.musicInfo.IsLine6Mode, m_isGoDivaEvent);
							}
							m_sceneSelectList.UpdateScore(m_musicBaseData);
							if(!GameManager.Instance.IsTutorial)
							{
								ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.AFLMHBMBNBO_48, 2, false);
							}
							ILCCJNDFFOB.HHCJCDFCLOB.KHMDGNKEFOD(JpStringLiterals.StringLiteral_15651, 0, false, true, diva.AHHJLDLAPAN_DivaId);
						}
					}
					else
					{
						if (afterScene == null)
							DetachAssist(m_assistPageIndex, m_assistSlotIndex, m_assistViewData);
						else
							AttachAssist(m_assistPageIndex, m_assistSlotIndex, m_assistViewData, afterScene);
						GCIJNCFDNON_SceneInfo scene = m_assistViewData.ELBLMMPEKPH_GetAssistScene(m_assistPageIndex, m_assistSlotIndex);
						m_equipmentScene.UpdateAssistContent(PlayerData, scene, m_assistSlotIndex);
						m_equipmentScene.SelectSlot(0);
						m_equipmentScene.ChangeIcon(scene, displayType, 0);
						m_sceneSelectList.UpdateRemoveButton(scene);
						MenuScene.Instance.Return(true);
					}
					m_sceneSelectList.UpdateRegion();
					m_sceneSelectList.UpdateScore();
				}
			}, null, null, ac);
		}

		// // RVA: 0x1382B50 Offset: 0x1382B50 VA: 0x1382B50
		private void ShowSelectHomeBgPopupWindow(SceneSelectHomeBgLayout.SetBgType bgType, GCIJNCFDNON_SceneInfo sceneData)
		{
			m_sceneSelectHomeBgSetting.BgType = bgType;
			m_sceneSelectHomeBgSetting.SceneData = sceneData;
			m_sceneSelectHomeBgSetting.HomeBgSceneData = JKHEOEEPBMJ.AIEDAEPONAB_GetHomeSceneInfo(PlayerData);
			PopupWindowManager.Show(m_sceneSelectHomeBgSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xA57FFC
				if(label == PopupButton.ButtonLabel.Ok)
				{
					int sceneId = 0;
					int evolveId = 0;
					if(m_sceneSelectHomeBgSetting.BgType == SceneSelectHomeBgLayout.SetBgType.Evole || m_sceneSelectHomeBgSetting.BgType == SceneSelectHomeBgLayout.SetBgType.EvoleOnly || m_sceneSelectHomeBgSetting.BgType == SceneSelectHomeBgLayout.SetBgType.Undeveloped)
					{
						sceneId = m_sceneSelectHomeBgSetting.SceneSelectHomeBgLayout.SceneData.BCCHOBPJJKE_SceneId;
						evolveId = m_sceneSelectHomeBgSetting.SceneSelectHomeBgLayout.SceneEvolveId;
					}
					JKHEOEEPBMJ.NDFFOBHACPE_SetHomeSceneId(sceneId, evolveId);
					m_equipmentScene.UpdateHomeBgSceneContent(sceneData, evolveId);
					m_equipmentScene.SelectSlot(0);
					m_sceneSelectList.UpdateRemoveButton(sceneData);
				}
				m_sceneSelectList.UpdateRegion();
			}, null, null, null);
		}

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
				m_sceneSelectList.UpdateRemoveButton(m_assistViewData.ELBLMMPEKPH_GetAssistScene(m_assistPageIndex, m_assistSlotIndex));
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
					m_equipmentScene.UpdateAssistContent(PlayerData, m_assistViewData.ELBLMMPEKPH_GetAssistScene(m_assistPageIndex, m_assistSlotIndex), m_assistSlotIndex);
					m_equipmentScene.SelectSlot(0);
					m_equipmentScene.ChangeIcon(m_assistViewData.ELBLMMPEKPH_GetAssistScene(m_assistPageIndex, m_assistSlotIndex), type, 0);
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
									this.StartCoroutineWatched(TutorialProc.Co_PlateGrowth(button));
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
										BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.Delegate, () =>
										{
											//0xA585D0
											GameManager.Instance.RemovePushBackButtonHandler(dymmyBackHandler);
										}, () =>
										{
											//0xA5845C
											return button;
										}, TutorialPointer.Direction.Normal);
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
			if(BasicTutorialManager.Instance.GetRecoveryPoint() != ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint.BNLDNJNMFMC_6)
			{
				BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.Scene, null, null);
			}
			else
			{
				BasicTutorialManager.Instance.ShowMessageWindow(BasicTutorialMessageId.Id_PlateSelected, () =>
				{
					//0xA56B70
					Database.Instance.advSetup.Setup(3);
					MenuScene.Instance.GotoAdventure(false);
				}, null);
			}
		}

		// RVA: 0x1385C64 Offset: 0x1385C64 VA: 0x1385C64
		private void SetTutorialPopupDecide()
		{
			BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.PopupPositiveButton, () =>
			{
				//0xA56C5C
				BasicTutorialManager.Instance.ShowMessageWindow(BasicTutorialMessageId.Id_PlateSelected, () =>
				{
					//0xA56DC0
					Database.Instance.advSetup.Setup(3);
					MenuScene.Instance.GotoAdventure(false);
				}, null);
			}, null, TutorialPointer.Direction.Down);
		}

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
			m_selectedSceneId = 0;
			m_sortType = item;
			m_order = (uint)order;
			m_isBonus = isBonus;
			Sort(isBonus, false);
			DisplayType dt = 0;
			bool b = UnitWindowConstant.SortItemToDisplayType.TryGetValue((int)m_sortType, out dt);
			CheckSkillIconType(PlayerData.DPLBHAIKPGL_GetTeam(), m_divaData);
			m_sceneSelectList.UpdateContent(PlayerData, m_divaData, m_musicBaseData != null ? m_musicBaseData.DLAEJOBELBH_MusicId : 0, PlayerData.OPIBAPEGCLA_Scenes, m_sceneIndexList, m_selectedSceneId, dt, m_dispRowCount, m_transitionName, m_isGoDivaEvent);
			if(m_musicBaseData != null)
			{
				CMMKCEPBIHI.EFCNOOFFMIL(PlayerData, m_friendPlayerData, m_musicBaseData, m_enemyData, m_difficulty, Database.Instance.gameSetup.musicInfo.IsLine6Mode, m_isGoDivaEvent);
			}
			m_sceneSelectList.UpdateScore(m_musicBaseData);
			if(m_equipmentScene != null)
			{
				if(m_assistViewData == null)
				{
					if(!m_isHomeSceneBg)
					{
						m_equipmentScene.ChangeIcon(PlayerData, m_divaData, dt, m_selectedDivaSlotIndex == 0, m_isGoDivaEvent);
					}
				}
				else
				{
					m_equipmentScene.ChangeIcon(m_assistViewData.ELBLMMPEKPH_GetAssistScene(m_assistPageIndex, m_assistSlotIndex), dt, 0);
				}
			}
			if(TransitionName == TransitionList.Type.SCENE_SELECT)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.LNFFKCDNCPN_sceneSelectSortItem = (int)m_sortType;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CIDJJBFGHIE_sceneSelectSortOrder = (int)m_order;
			}
			else if(TransitionName == TransitionList.Type.ASSIST_SELECT)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.NCDOLBOHGFN_sceneAssistSortItem = (int)m_sortType;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.OGFJPNKICGI_sceneAssistSortOrder = (int)m_order;
			}
			else if(TransitionName == TransitionList.Type.HOME_BG_SELECT)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GIDCHFBCBML_SelectHomeBG.EILKGEADKGH_Order = (int)m_order;
			}
			else
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GEAECNMDMHH_sceneListSortItem = (int)m_sortType;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CLKCCJJJPLB_sceneListSortOrder = (int)m_order;
			}
		}

		// // RVA: 0x1384A14 Offset: 0x1384A14 VA: 0x1384A14
		private void Sort(bool isBonus, bool isPlateMission = false)
		{
			uint rarityFilterBit;
			uint attributeFilterBit;
			uint seriaseFilterBit;
			uint compatibleFilterBit;
			uint lskillRangeFilerBit;
			uint cskillRankFilerBit;
			uint askillRankFilerBit;
			uint lskillRankFilerBit;
			ulong cskillFilerBit;
			ulong askillFilerBit;
			ulong lskillFilerBit;
			uint notesFilterBit;

			if(!isPlateMission)
			{
				ILDKBCLAFPB.IJDOCJCLAIL_SortProprty sortProp = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty;

				if(TransitionName == TransitionList.Type.SCENE_SELECT)
				{
					rarityFilterBit = (uint)sortProp.FFAKMECDMFC_sceneSelectRarityFilter;
					attributeFilterBit = (uint)sortProp.LMPKAPBCIFD_sceneSelectAttributeFilter;
					seriaseFilterBit = (uint)sortProp.MNNCLIFBAOA_sceneSelectSeriaseFilter;
					cskillRankFilerBit = (uint)sortProp.BPFPFOJNFLC_sceneSelectCenterSkillRankFilter;
					compatibleFilterBit = (uint)sortProp.NPFGKBKKCFL_sceneSelectCompatibleFilter;
					cskillFilerBit = (ulong)sortProp.IHECEFMGKHO_sceneSelectCenterSkillFilter;
					askillFilerBit = (ulong)sortProp.POJHGOJDOND_sceneSelectActiveSkillFilter;
					lskillFilerBit = (ulong)sortProp.OCKOEPFNGJG_sceneSelectLiveSkillFilter;
					notesFilterBit = (uint)sortProp.DMKHBHDGABG_sceneSelectNotesExpectedFilter;
					lskillRangeFilerBit = (uint)sortProp.IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter;
					askillRankFilerBit = (uint)sortProp.BIBBAIFCGLD_sceneSelectActiveSkillRankFilter;
					lskillRankFilerBit = (uint)sortProp.AIPJDIPBDEA_sceneSelectLiveSkillRankFilter;
					if(sortProp.JACFDEKLDCK_isCompatibleDivaCheck > 0)
					{
						compatibleFilterBit = (uint)(1 << (m_divaData.AHHJLDLAPAN_DivaId - 1));
					}
				}
				else if(TransitionName == TransitionList.Type.HOME_BG_SELECT)
				{
					seriaseFilterBit = (uint)sortProp.GIDCHFBCBML_SelectHomeBG.HBEFGKLLMEC_FilterSeries;
					notesFilterBit = 0;
					lskillFilerBit = 0;
					rarityFilterBit = (uint)sortProp.GIDCHFBCBML_SelectHomeBG.PLNMMHPILLO_FilterRarity;
					askillRankFilerBit = 0;
					cskillRankFilerBit = 0;
					askillFilerBit = 0;
					cskillFilerBit = 0;
					lskillRankFilerBit = 0;
					lskillRangeFilerBit = 0;
					compatibleFilterBit = 0;
					attributeFilterBit = 0;
				}
				else if(TransitionName == TransitionList.Type.ASSIST_SELECT)
				{
					attributeFilterBit = (uint)(m_assistSlotIndex == 0 ? sortProp.OFFBGLDDBHC_sceneAssistAttributeFilter : 1 << (m_assistSlotIndex - 1));
					seriaseFilterBit = (uint)sortProp.POPIEDDJGBA_sceneAssistSeriaseFilter;
					notesFilterBit = (uint)sortProp.GJFPKDOBIPH_sceneAssistCenterSkillFilter;
					lskillFilerBit = 0;
					rarityFilterBit = 0;
					askillRankFilerBit = 0;
					cskillRankFilerBit = 0;
					askillFilerBit = 0;
					cskillFilerBit = 0;
					lskillRankFilerBit = 0;
					lskillRangeFilerBit = 0;
					compatibleFilterBit = 0;
				}
				else
				{
					rarityFilterBit = (uint)sortProp.HMJNAGNIEJB_sceneListRarityFilter;
					attributeFilterBit = (uint)sortProp.HFGAILIOFAN_sceneListAttributeFilter;
					seriaseFilterBit = (uint)sortProp.AKFPHKLCHAA_sceneListSeriaseFilter;
					cskillRankFilerBit = (uint)sortProp.MECEGIJIGBN_sceneListCenterSkillRankFilter;
					compatibleFilterBit = (uint)sortProp.PHCEMKLNJLH_sceneListCompatibleFilter;
					lskillRangeFilerBit = (uint)sortProp.LALFKJDFPOD_sceneListLiveSkillRangeFilter;
					askillRankFilerBit = (uint)sortProp.ALFGELGDIGC_sceneListActiveSkillRankFilter;
					lskillRankFilerBit = (uint)sortProp.HKFPBAFALHO_sceneListLiveSkillRankFilter;
					cskillFilerBit = (ulong)sortProp.IOBABMJPAAE_sceneListCenterSkillFilter;
					askillFilerBit = (ulong)sortProp.GIPNFAFFNLF_sceneListActiveSkillFilter;
					lskillFilerBit = (ulong)sortProp.BOMCDAIEFLN_sceneListLiveSkillFilter;
					notesFilterBit = (uint)sortProp.MCJBFHMJECO_sceneListNotesExpectedFilter;
				}
			}
			else
			{
				attributeFilterBit = 0;
				seriaseFilterBit = 0;
				notesFilterBit = 0;
				lskillFilerBit = 0;
				rarityFilterBit = 0;
				askillRankFilerBit = 0;
				cskillRankFilerBit = 0;
				askillFilerBit = 0;
				cskillFilerBit = 0;
				lskillRankFilerBit = 0;
				lskillRangeFilerBit = 0;
				compatibleFilterBit = 0;
			}

			Listup(rarityFilterBit, attributeFilterBit, seriaseFilterBit, compatibleFilterBit, lskillRangeFilerBit, cskillRankFilerBit, askillRankFilerBit, lskillRankFilerBit, cskillFilerBit, askillFilerBit, lskillFilerBit, notesFilterBit, m_episodeId, isBonus);
			SortImpl();
		}

		// // RVA: 0x1386738 Offset: 0x1386738 VA: 0x1386738
		// private uint MakeAssistAttributeBit(ILDKBCLAFPB.IJDOCJCLAIL saveData) { }

		// // RVA: 0x138677C Offset: 0x138677C VA: 0x138677C
		private void OnSelectListScene(int listIndex)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			GCIJNCFDNON_SceneInfo sceneInfo = PlayerData.OPIBAPEGCLA_Scenes[m_sceneIndexList[listIndex]];
			if(TransitionName == TransitionList.Type.SCENE_SELECT)
			{
				GCIJNCFDNON_SceneInfo beforeScene = null;
				if(m_selectedEquipmentSlotIndex == 0)
				{
					if(m_divaData.FGFIBOBAPIA_SceneId > 0)
					{
						beforeScene = PlayerData.OPIBAPEGCLA_Scenes[m_divaData.FGFIBOBAPIA_SceneId - 1];
					}
				}
				else
				{
					if(m_divaData.DJICAKGOGFO_SubSceneIds[m_selectedEquipmentSlotIndex - 1] > 0)
					{
						beforeScene = PlayerData.OPIBAPEGCLA_Scenes[m_divaData.DJICAKGOGFO_SubSceneIds[m_selectedEquipmentSlotIndex - 1] - 1];
					}
				}
				ShowComparisonPopupWindow(beforeScene, sceneInfo, m_divaData);
			}
			else if(TransitionName == TransitionList.Type.ASSIST_SELECT)
			{
				GCIJNCFDNON_SceneInfo beforeScene = m_assistViewData.ELBLMMPEKPH_GetAssistScene(m_assistPageIndex, m_assistSlotIndex);
				if(beforeScene.BCCHOBPJJKE_SceneId < 1)
					beforeScene = null;
				ShowComparisonPopupWindow(beforeScene, sceneInfo, null);
			}
			else if(TransitionName == TransitionList.Type.HOME_BG_SELECT)
			{
				SceneSelectHomeBgLayout.SetBgType bgType = SceneSelectHomeBgLayout.SetBgType.EvoleOnly;
				if(!sceneInfo.JOKJBMJBLBB_Single)
				{
					bgType = SceneSelectHomeBgLayout.SetBgType.Evole;
					if(sceneInfo.CGIELKDLHGE_GetEvolveId() == 1)
						bgType = SceneSelectHomeBgLayout.SetBgType.Undeveloped;
				}
				ShowSelectHomeBgPopupWindow(bgType, sceneInfo);
			}
			else
			{
				sceneInfo.CADENLBDAEB_New = false;
				sceneInfo.LEHDLBJJBNC_SetNotNew();
				m_selectedSceneId = sceneInfo.BCCHOBPJJKE_SceneId;
				MenuScene.Instance.Call(TransitionList.Type.SCENE_GROWTH, new SceneGrowthSceneArgs(sceneInfo, m_isBeginner), true);
			}
		}

		// // RVA: 0x1386BFC Offset: 0x1386BFC VA: 0x1386BFC
		private void OnRemoveScene()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(m_assistViewData == null && m_isHomeSceneBg)
			{
				RemoveHomeBgPopupWindow();
			}
			else
			{
				RemoveScenePopupWindow();
			}
		}

		// // RVA: 0x1386C84 Offset: 0x1386C84 VA: 0x1386C84
		private void RemoveScenePopupWindow()
		{
			if(m_assistViewData == null)
			{
				ShowComparisonPopupWindow(PlayerData.OPIBAPEGCLA_Scenes[(m_selectedEquipmentSlotIndex == 0 ? m_divaData.FGFIBOBAPIA_SceneId : m_divaData.DJICAKGOGFO_SubSceneIds[m_selectedEquipmentSlotIndex - 1]) - 1], null, m_divaData);
			}
			else
			{
				ShowComparisonPopupWindow(m_assistViewData.ELBLMMPEKPH_GetAssistScene(m_assistPageIndex, m_assistSlotIndex), null, m_divaData);
			}
		}

		// // RVA: 0x1386DEC Offset: 0x1386DEC VA: 0x1386DEC
		private void RemoveHomeBgPopupWindow()
		{
			CGFNKMNBNBN tmp;
			ShowSelectHomeBgPopupWindow(CGFNKMNBNBN.CLBDFPACPKE(MenuScene.Instance.EnterToHomeTime, out tmp) ? SceneSelectHomeBgLayout.SetBgType.LimitBg : SceneSelectHomeBgLayout.SetBgType.Default, null);
		}

		// // RVA: 0x1386EC0 Offset: 0x1386EC0 VA: 0x1386EC0
		private void OnShowListSceneStatus(int listIndex)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			bool isFriend = m_assistViewData != null || m_isHomeSceneBg;
            GCIJNCFDNON_SceneInfo scene = PlayerData.OPIBAPEGCLA_Scenes[m_sceneIndexList[listIndex]];
            m_selectedSceneId = scene.BCCHOBPJJKE_SceneId;
			MenuScene.Instance.ShowSceneStatusPopupWindow(scene, PlayerData, false, TransitionName, UpdateListItem, isFriend, isFriend, SceneStatusParam.PageSave.Player, false);
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
					m_equipmentScene.ChangeIcon(m_assistViewData.ELBLMMPEKPH_GetAssistScene(m_assistPageIndex, m_assistSlotIndex), type, 0);
				}
			}
		}

		// // RVA: 0x1387310 Offset: 0x1387310 VA: 0x1387310
		private void OnSelectEquipmentScene(int equipmentSlotIndex)
		{
			if(m_selectedEquipmentSlotIndex == equipmentSlotIndex)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_selectedEquipmentSlotIndex = equipmentSlotIndex;
			m_equipmentScene.SelectSlot(equipmentSlotIndex);
			m_sceneSelectList.UpdateRemoveButton(m_divaData, m_selectedEquipmentSlotIndex);
			m_sceneSelectList.SetSelectedSlot(m_selectedEquipmentSlotIndex);
		}

		// // RVA: 0x13873F4 Offset: 0x13873F4 VA: 0x13873F4
		private void OnShowEquipmentSceneStatus(int equipmentSlotIndex)
		{
			bool isFriend = false;
			GCIJNCFDNON_SceneInfo scene = null;
			if(m_assistViewData == null)
			{
				if(!m_isHomeSceneBg)
				{
					if(!m_isGoDivaEvent)
					{
						if(equipmentSlotIndex == 0)
						{
							isFriend = false;
							scene = PlayerData.OPIBAPEGCLA_Scenes[m_divaData.FGFIBOBAPIA_SceneId - 1];
						}
						else
						{
							isFriend = false;
							scene = PlayerData.OPIBAPEGCLA_Scenes[m_divaData.DJICAKGOGFO_SubSceneIds[equipmentSlotIndex - 1] - 1];
						}
					}
					else
					{
						if(equipmentSlotIndex == 0)
						{
							isFriend = false;
							scene = PlayerData.OPIBAPEGCLA_Scenes[m_divaData.FGFIBOBAPIA_SceneId - 1];
						}
						else
						{
							isFriend = false;
							scene = PlayerData.OPIBAPEGCLA_Scenes[m_divaData.DJICAKGOGFO_SubSceneIds[equipmentSlotIndex - 1] - 1];
						}
					}
				}
				else
				{
					isFriend = true;
					scene = JKHEOEEPBMJ.AIEDAEPONAB_GetHomeSceneInfo(PlayerData);
				}
			}
			else
			{
				isFriend = true;
				scene = m_assistViewData.ELBLMMPEKPH_GetAssistScene(m_assistPageIndex, m_assistSlotIndex);
			}
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_selectedSceneId = scene.BCCHOBPJJKE_SceneId;
			MenuScene.Instance.ShowSceneStatusPopupWindow(scene, PlayerData, false, TransitionList.Type.SCENE_SELECT, UpdateListItem, isFriend, isFriend, SceneStatusParam.PageSave.Player, false);
		}

		// // RVA: 0x1386670 Offset: 0x1386670 VA: 0x1386670
		private SceneIconScrollContent.SkillIconType CheckSkillIconType(JLKEOGLJNOD_TeamInfo unitData, FFHPBEPOMAK_DivaInfo diva)
		{
			if(diva != null)
			{
				if(unitData.BCJEAJPLGMB_MainDivas[0] != null)
				{
					if(unitData.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId != diva.AHHJLDLAPAN_DivaId)
					{
						return SceneIconScrollContent.SkillIconType.Live;
					}
					return SceneIconScrollContent.SkillIconType.Active;
				}
			}
			return SceneIconScrollContent.SkillIconType.None;
		}

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
		private bool IsCenterDiva()
		{
			return m_selectedDivaSlotIndex == 0;
		}
	}
}
