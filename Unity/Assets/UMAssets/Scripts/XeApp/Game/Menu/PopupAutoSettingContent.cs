using mcrs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupAutoSettingContent : UIBehaviour, IPopupContent
	{
		public enum Place
		{
			UnitEdit = 0,
			UnitSelect = 1,
		}

		private enum PlayStyle
		{
			Score = 0,
			Life = 1,
			Combo = 2,
			Max = 3,
		}

		private enum StatusPriority
		{
			Total = 0,
			Soul = 1,
			Voice = 2,
			Charm = 3,
			Life = 4,
			Support = 5,
			Fold = 6,
			Luck = 7,
		}

		private enum AttributePriority
		{
			All = 0,
			Attr1 = 1,
			Attr2 = 2,
			Attr3 = 3,
			Max = 4,
		}

		private enum SlotType
		{
			Main = 0,
			Sub1 = 1,
			Sub2 = 2,
			Max = 3,
		}

		private enum PriorityPriority
		{
			Score = 0,
			Life = 1,
			Combo = 2,
			Max = 3,
		}

		private enum AutoMode
		{
			Simple = 0,
			Normal = 1,
		}

		private struct SortParam
		{
			public int sceneListIndex; // 0x0
			public int sceneAttribute; // 0x4
			public int sceneId; // 0x8
			public int weight; // 0xC
			public int[] skillWeight; // 0x10
			public int total; // 0x14
			public StatusData status; // 0x18
			public int excelentRate; // 0x1C
			public int luck; // 0x20
		}

		private readonly Color m_enableColor = Color.red; // 0xC
		private readonly Color m_disableColor = Color.white; // 0x1C
		private static readonly int[,] SimpleDivaSlotAccessTable = new int[8, 2] {
			{ 1, 0 }, { 2, 0 }, {0, 1 }, {1, 1 }, {2, 1 }, {0, 2 }, {1, 2 }, {2, 2 }
		}; // 0x0
		private static readonly int[,] NormalDivaSlotAccessTable = new int[8, 2] {
			{ 1, 0 }, {2, 0 }, {0, 1 }, {0, 2 }, {1, 1 }, {1, 2 }, {2, 1 }, {2, 2 }
		}; // 0x4
		private const int CompatibleAttributeRate = 130;
		private int currentSetDivaSlot; // 0x2C
		private List<SortParam> m_sortSceneList = new List<SortParam>(1000); // 0x50
		private List<SortParam> m_pickUpList = new List<SortParam>(1000); // 0x54
		private List<SortParam> m_temporaryList = new List<SortParam>(1000); // 0x58
		private List<SortParam> m_intimacyList = new List<SortParam>(1000); // 0x5C
		private AutoSettingPanel m_autoSettingPanel; // 0x60
		private SimpleAutoSettingPanel m_simpleAutoSettingPanel; // 0x64
		private KLBKPANJCPL_Score m_scoreMasterInfo; // 0x68
		private JJOELIOGMKK_DivaIntimacyInfo[] m_viewIntimacyData = new JJOELIOGMKK_DivaIntimacyInfo[3]; // 0x6C
		private int m_centerEffectValue; // 0x70

		public int SelectMusicAttribute { get; private set; } // 0x30
		public int MusicAttribute { get; private set; } // 0x34
		public int SelectMusicSeries { get; private set; } // 0x38
		public int SelectStatus { get; private set; } // 0x3C
		public int SelectMusicID { get; private set; } // 0x40
		public bool IsKeepCenterSkill { get; private set; } // 0x44
		public bool IsCompatibleDiva { get; private set; } // 0x45
		public int SelectPriority { get; private set; } // 0x48
		public bool IsSimpleAutoSet { get; private set; } // 0x4C
		public Transform Parent { get; private set; } // 0x74

		// RVA: 0x1332180 Offset: 0x1332180 VA: 0x1332180
		private void Awake()
		{
			m_autoSettingPanel = GetComponentInChildren<AutoSettingPanel>(true);
			m_autoSettingPanel.OnSelectAttribute.AddListener(OnSelectMusicAttribute);
			m_autoSettingPanel.OnSelectStatus.AddListener(OnSelectStatus);
			m_autoSettingPanel.OnSelectCenterSkill.AddListener(OnToggleCenterSkill);
			m_autoSettingPanel.OnSelectCompatibleDiva.AddListener(OnToggleCompatibleDiva);
			m_simpleAutoSettingPanel = GetComponentInChildren<SimpleAutoSettingPanel>(true);
			m_simpleAutoSettingPanel.OnSelectAttrEvent.AddListener(OnSelectMusicAttribute);
			m_simpleAutoSettingPanel.OnSelectStyleEvent.AddListener(OnSelectPlayStyle);
			IsSimpleAutoSet = true;
		}

		// RVA: 0x133258C Offset: 0x133258C VA: 0x133258C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupAutoSettingContentSetting s = setting as PopupAutoSettingContentSetting;
			IsSimpleAutoSet = true;
			SelectMusicSeries = s.MusicSeries;
			SelectMusicID = s.MusicID;
			s.TabCallBack = (PopupTabButton.ButtonLabel label) =>
			{
				//0x1339C30
				ChangeToggleAutoType(label == PopupTabButton.ButtonLabel.NormalAutoSet ? 1 : 0);
			};
			GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			Parent = setting.m_parent;
			m_scoreMasterInfo = s.ScoreInfo;
			if(m_scoreMasterInfo == null)
			{
				m_scoreMasterInfo = new KLBKPANJCPL_Score();
				m_scoreMasterInfo.MCMIPODICAN_length = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("default_autoset_music_length1", 100000);
				m_scoreMasterInfo.NLKEBAOBJCM_Cb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("default_autoset_full_combo1", 200);
				m_scoreMasterInfo.OABPNBLPHHP_ValkStartTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("default_autoset_valkyrie_start_time1", 60000);
				m_scoreMasterInfo.GIABDDFGHOK_DivaStartTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("default_autoset_diva_start_time1", 76000);
				m_scoreMasterInfo.JJBOEMOJPEC_DivaNote = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("default_autoset_diva_note1", 50);
				m_simpleAutoSettingPanel.AttributeGroup.gameObject.SetActive(true);
			}
			else
			{
				m_simpleAutoSettingPanel.AttributeGroup.gameObject.SetActive(false);
			}
			SelectMusicAttribute = 0;
			IsCompatibleDiva = true;
			MusicAttribute = s.Place != Place.UnitEdit ? s.MusicAttribute : 0;
			m_autoSettingPanel.AttributeButtonGruop.SelectGroupButton(SelectMusicAttribute);
			m_simpleAutoSettingPanel.AttributeGroup.SelectGroupButton(SelectMusicAttribute);
			SelectStatus = 0;
			m_autoSettingPanel.StatusButtonGruop.SelectGroupButton(SelectStatus);
			SelectPriority = 0;
			m_simpleAutoSettingPanel.StyleGroup.SelectGroupButton(SelectPriority);
			if (!IsKeepCenterSkill)
				m_autoSettingPanel.KeepCenterSkillToggle.SetOff();
			else
				m_autoSettingPanel.KeepCenterSkillToggle.SetOn();
			if (IsCompatibleDiva)
				m_autoSettingPanel.CompatibleDivaToggle.SetOn();
			else
				m_autoSettingPanel.CompatibleDivaToggle.SetOff();
			ChangeToggleAutoType(IsSimpleAutoSet ? 0 : 1);
		}

		// RVA: 0x1332EF0 Offset: 0x1332EF0 VA: 0x1332EF0 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1332EF8 Offset: 0x1332EF8 VA: 0x1332EF8 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1332F30 Offset: 0x1332F30 VA: 0x1332F30 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1332F68 Offset: 0x1332F68 VA: 0x1332F68 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1332F70 Offset: 0x1332F70 VA: 0x1332F70 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0x1332D1C Offset: 0x1332D1C VA: 0x1332D1C
		private void ChangeToggleAutoType(int index)
		{
			SelectMusicAttribute = MusicAttribute > 3 ? 0 : MusicAttribute;
			if(index == 0)
			{
				IsSimpleAutoSet = true;
				m_simpleAutoSettingPanel.AttributeGroup.SelectGroupButton(SelectMusicAttribute);
				m_simpleAutoSettingPanel.gameObject.SetActive(true);
				m_autoSettingPanel.gameObject.SetActive(false);
			}
			else
			{
				IsSimpleAutoSet = false;
				m_autoSettingPanel.AttributeButtonGruop.SelectGroupButton(SelectMusicAttribute);
				m_simpleAutoSettingPanel.gameObject.SetActive(false);
				m_autoSettingPanel.gameObject.SetActive(true);
			}
		}

		//// RVA: 0x1332F74 Offset: 0x1332F74 VA: 0x1332F74
		private void OnSelectMusicAttribute(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			SelectMusicAttribute = index;
		}

		//// RVA: 0x1332FD8 Offset: 0x1332FD8 VA: 0x1332FD8
		private void OnSelectStatus(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			SelectStatus = index;
		}

		//// RVA: 0x133303C Offset: 0x133303C VA: 0x133303C
		private void OnSelectPlayStyle(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			SelectPriority = index;
		}

		//// RVA: 0x13330A0 Offset: 0x13330A0 VA: 0x13330A0
		private void OnToggleCenterSkill(bool isOn)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			IsKeepCenterSkill = isOn;
		}

		//// RVA: 0x1333104 Offset: 0x1333104 VA: 0x1333104
		private void OnToggleCompatibleDiva(bool isOn)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			IsCompatibleDiva = isOn;
		}

		//// RVA: 0x1333168 Offset: 0x1333168 VA: 0x1333168
		public void ApplyAutoSetting(JLKEOGLJNOD_TeamInfo unitData, DFKGGBMFFGB_PlayerInfo playerData, bool isGoDiva)
		{
			if(IsSimpleAutoSet && SelectMusicID != 0)
			{
				SelectMusicAttribute = MusicAttribute;
			}
			ListupScene(playerData);
			if (m_sortSceneList.Count == 0)
				return;
			SetMainSlot(unitData, playerData, isGoDiva);
			if(!IsSimpleAutoSet)
			{
				NormalSetSubSlots(unitData, playerData, isGoDiva);
			}
			else
			{
				m_sortSceneList.AddRange(m_intimacyList);
				SimpleSetSubSlots(unitData, playerData, isGoDiva);
				SetMainSlotIntimacy(unitData, playerData, isGoDiva);
			}
			if(unitData != null)
			{
				unitData.HCDGELDHFHB();
				ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.AFLMHBMBNBO_48/*48*/, 2, false);
			}
		}

		//// RVA: 0x133331C Offset: 0x133331C VA: 0x133331C
		private void ListupScene(DFKGGBMFFGB_PlayerInfo playerData)
		{
			m_sortSceneList.Clear();
			m_intimacyList.Clear();
			for(int i = 0; i < playerData.OPIBAPEGCLA_Scenes.Count; i++)
			{
				MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[playerData.OPIBAPEGCLA_Scenes[i].BCCHOBPJJKE_SceneId - 1];
				if(dbScene.PPEGAKEIEGM_En == 2)
				{
					if(playerData.OPIBAPEGCLA_Scenes[i].CGKAEMGLHNK_IsUnlocked())
					{
						if(!playerData.OPIBAPEGCLA_Scenes[i].MCCIFLKCNKO_Feed)
						{
							int[] li = new int[3];
							AEKDNMPPOJN a = new AEKDNMPPOJN();
							a.KHEKNNFCAOI(playerData.OPIBAPEGCLA_Scenes[i].JKGFBFPIMGA_Rarity, playerData.OPIBAPEGCLA_Scenes[i].MKHFCGPJPFI_LimitOverCount, playerData.OPIBAPEGCLA_Scenes[i].MJBODMOLOBC_Luck);
							m_sortSceneList.Add(new SortParam()
							{
								sceneListIndex = i,
								sceneAttribute = playerData.OPIBAPEGCLA_Scenes[i].JGJFIJOCPAG_SceneAttr,
								sceneId = playerData.OPIBAPEGCLA_Scenes[i].BCCHOBPJJKE_SceneId,
								weight = 0,
								skillWeight = li,
								total = 0,
								status = playerData.OPIBAPEGCLA_Scenes[i].CMCKNKKCNDK_Status,
								excelentRate = a.OBMGLMLCGJC_ExcellentRate,
								luck = playerData.OPIBAPEGCLA_Scenes[i].MJBODMOLOBC_Luck
							});
						}
					}
				}
			}
		}

		//// RVA: 0x133392C Offset: 0x133392C VA: 0x133392C
		private void SetMainSlot(JLKEOGLJNOD_TeamInfo unitData, DFKGGBMFFGB_PlayerInfo playerData, bool isGoDiva)
		{
			if(!IsSimpleAutoSet)
			{
				NormalPickupCenterSkill(playerData.OPIBAPEGCLA_Scenes);
				m_sortSceneList.Sort(SortFunc);
			}
			else
			{
				if (m_sortSceneList.IsEmpty())
					return;
				SimplePickupCenterSkill(playerData.OPIBAPEGCLA_Scenes, 0);
				m_sortSceneList.Sort(SimpleSortFunc2);
				if(m_sortSceneList[0].weight != 0)
				{
					m_centerEffectValue = m_sortSceneList[0].weight;
				}
				else
				{
					SimplePickupCenterSkill(playerData.OPIBAPEGCLA_Scenes, 1);
					m_sortSceneList.Sort(SimpleSortFunc2);
				}
			}
			if(unitData.BCJEAJPLGMB_MainDivas[0] != null)
			{
				if(!IsKeepCenterSkill || IsSimpleAutoSet)
				{
					playerData.OPIBAPEGCLA_Scenes[m_sortSceneList[0].sceneListIndex].CADENLBDAEB_New = false;
					playerData.OPIBAPEGCLA_Scenes[m_sortSceneList[0].sceneListIndex].LEHDLBJJBNC_SetNotNew();
					if(isGoDiva)
					{
						unitData.BCJEAJPLGMB_MainDivas[0].ODFBCANBLIJ(playerData.OPIBAPEGCLA_Scenes[m_sortSceneList[0].sceneListIndex]);
					}
					else
					{
						unitData.BCJEAJPLGMB_MainDivas[0].OKDIEDCGODF(playerData.OPIBAPEGCLA_Scenes[m_sortSceneList[0].sceneListIndex].BCCHOBPJJKE_SceneId, false, playerData.HJBAALOOKMO, null);
					}
				}
				if(unitData.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId > 0)
				{
					int i = 0;
					for (; i < m_sortSceneList.Count; i++)
					{
						if (m_sortSceneList[i].sceneListIndex == unitData.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId - 1)
						{
							m_sortSceneList.RemoveAt(i);
						}
					}
				}
			}
		}

		//// RVA: 0x133498C Offset: 0x133498C VA: 0x133498C
		private void SetMainSlotIntimacy(JLKEOGLJNOD_TeamInfo unitData, DFKGGBMFFGB_PlayerInfo playerData, bool isGoDiva)
		{
			if(!m_intimacyList.IsEmpty())
			{
				PickupIntimacyCenterSkill(unitData, playerData.OPIBAPEGCLA_Scenes, 0, isGoDiva);
				m_intimacyList.Sort(SimpleSortFunc2);
				if(unitData.BCJEAJPLGMB_MainDivas[0] != null)
				{
					if(m_centerEffectValue < m_intimacyList[0].weight)
					{
						if(!IsKeepCenterSkill || IsSimpleAutoSet)
						{
							playerData.OPIBAPEGCLA_Scenes[m_intimacyList[0].sceneListIndex].CADENLBDAEB_New = false;
							playerData.OPIBAPEGCLA_Scenes[m_intimacyList[0].sceneListIndex].LEHDLBJJBNC_SetNotNew();
							if(isGoDiva)
							{
								unitData.BCJEAJPLGMB_MainDivas[0].ODFBCANBLIJ(playerData.OPIBAPEGCLA_Scenes[m_intimacyList[0].sceneListIndex]);
							}
							else
							{
								unitData.BCJEAJPLGMB_MainDivas[0].OKDIEDCGODF(playerData.OPIBAPEGCLA_Scenes[m_intimacyList[0].sceneListIndex].BCCHOBPJJKE_SceneId, false, playerData.HJBAALOOKMO, null);
							}
						}
						if(unitData.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId > 0)
						{
							for(int i = 0; i < m_intimacyList.Count; i++)
							{
								if(m_intimacyList[i].sceneId - 1 == m_intimacyList[i].sceneListIndex)
								{
									m_intimacyList.RemoveAt(i);
									break;
								}
							}
						}
					}
				}
			}
		}

		//// RVA: 0x1334E84 Offset: 0x1334E84 VA: 0x1334E84
		private void NormalSetSubSlots(JLKEOGLJNOD_TeamInfo unitData, DFKGGBMFFGB_PlayerInfo playerData, bool isGoDiva)
		{
			m_sortSceneList.Sort(SortFunc);
			for(int i = 0; i < NormalDivaSlotAccessTable.GetLength(0); i++)
			{
				if(NormalDivaSlotAccessTable[i, 0] > -1)
				{
					FFHPBEPOMAK_DivaInfo d = unitData.BCJEAJPLGMB_MainDivas[NormalDivaSlotAccessTable[i, 0]];
					if(d != null)
					{
						NormalPickupCompatibleScene(ref m_pickUpList, d, playerData.OPIBAPEGCLA_Scenes, m_sortSceneList);
						if (m_pickUpList.Count == 0)
							return;
						SetSlot((SlotType)NormalDivaSlotAccessTable[i, 1], m_pickUpList[0].sceneListIndex, playerData, d, isGoDiva);
					}
				}
			}
		}

		//// RVA: 0x1333F6C Offset: 0x1333F6C VA: 0x1333F6C
		private void SimpleSetSubSlots(JLKEOGLJNOD_TeamInfo unitData, DFKGGBMFFGB_PlayerInfo playerData, bool isGoDiva)
		{
			for(int i = 0; i < 3; i++)
			{
				if(unitData.BCJEAJPLGMB_MainDivas[i] != null)
				{
					m_viewIntimacyData[i] = InitViewIntimacyData(unitData.BCJEAJPLGMB_MainDivas[i].AHHJLDLAPAN_DivaId);
				}
			}
			PickupLiveSkill(playerData.OPIBAPEGCLA_Scenes, unitData);
			List<SortParam> l = new List<SortParam>();
			for(int i = 0; i < SimpleDivaSlotAccessTable.GetLength(0); i++)
			{
				if(SimpleDivaSlotAccessTable[i, 0] > -1)
				{
					FFHPBEPOMAK_DivaInfo d = unitData.BCJEAJPLGMB_MainDivas[SimpleDivaSlotAccessTable[i, 0]];
					if (d != null)
					{
						SimplePickupCompatibleScene(ref m_pickUpList, d, playerData.OPIBAPEGCLA_Scenes, m_sortSceneList, unitData);
						if (m_pickUpList.Count == 0)
							break;
						SetSlot((SlotType)SimpleDivaSlotAccessTable[i, 1], m_pickUpList[0].sceneListIndex, playerData, d, isGoDiva);
						l.Add(m_pickUpList[0]);
					}
				}
			}
			if(m_sortSceneList.Count != 0)
			{
				for(int i = 0; i < l.Count; i++)
				{
					if (SimpleDivaSlotAccessTable[i, 0] > -1)
					{
						FFHPBEPOMAK_DivaInfo d = unitData.BCJEAJPLGMB_MainDivas[SimpleDivaSlotAccessTable[i, 0]];
						if (d != null)
						{
							SimplePickupCompatibleScene2(ref m_pickUpList, d, playerData.OPIBAPEGCLA_Scenes, m_sortSceneList, unitData);
							if (m_pickUpList.Count == 0)
								return;
							if (l[i].skillWeight[SimpleDivaSlotAccessTable[i, 1]] < m_pickUpList[0].skillWeight[SimpleDivaSlotAccessTable[i, 1]])
							{
								SetSlot((SlotType)SimpleDivaSlotAccessTable[i, 1], m_pickUpList[0].sceneListIndex, playerData, d, isGoDiva);
								m_sortSceneList.Add(l[i]);
							}
						}
					}
				}
			}
		}

		//// RVA: 0x13370BC Offset: 0x13370BC VA: 0x13370BC
		private void SetSlot(SlotType slotType, int sceneListIndex, DFKGGBMFFGB_PlayerInfo playerData, FFHPBEPOMAK_DivaInfo divaData, bool isGoDiva)
		{
			if (slotType == SlotType.Main)
			{
				playerData.OPIBAPEGCLA_Scenes[sceneListIndex].CADENLBDAEB_New = false;
				playerData.OPIBAPEGCLA_Scenes[sceneListIndex].LEHDLBJJBNC_SetNotNew();
				if (isGoDiva)
				{
					divaData.ODFBCANBLIJ(playerData.OPIBAPEGCLA_Scenes[sceneListIndex]);
				}
				else
				{
					divaData.OKDIEDCGODF(playerData.OPIBAPEGCLA_Scenes[sceneListIndex].BCCHOBPJJKE_SceneId, false, playerData.HJBAALOOKMO, null);
				}
			}
			else
			{
				int slotIndex = (int)slotType - 1;
				if(slotIndex < 2)
				{
					playerData.OPIBAPEGCLA_Scenes[sceneListIndex].CADENLBDAEB_New = false;
					playerData.OPIBAPEGCLA_Scenes[sceneListIndex].LEHDLBJJBNC_SetNotNew();
					if (isGoDiva)
					{
						divaData.GOEDGNGDMCN(playerData.OPIBAPEGCLA_Scenes[sceneListIndex], slotIndex);
					}
					else
					{
						divaData.IFFMDJHENHB(slotIndex, playerData.OPIBAPEGCLA_Scenes[sceneListIndex].BCCHOBPJJKE_SceneId, false, playerData.HJBAALOOKMO, null);
					}
				}
			}
			int idx = m_sortSceneList.FindIndex((SortParam value) =>
			{
				//0x1339C40
				return value.sceneListIndex == sceneListIndex;
			});
			m_sortSceneList.RemoveAt(idx);
			idx = m_intimacyList.FindIndex((SortParam value) =>
			{
				//0x1339C54
				return value.sceneListIndex == sceneListIndex;
			});
			if (idx != -1)
				m_intimacyList.RemoveAt(idx);
		}

		//// RVA: 0x1337F34 Offset: 0x1337F34 VA: 0x1337F34
		private void SimplePickupCompatibleScene(ref List<SortParam> pickupList, FFHPBEPOMAK_DivaInfo divaData, List<GCIJNCFDNON_SceneInfo> sceneList, List<SortParam> sceneSortList, JLKEOGLJNOD_TeamInfo unitData)
		{
			pickupList.Clear();
			m_temporaryList.Clear();
			for(int i = 0; i < sceneSortList.Count; i++)
			{
				SortParam sp = sceneSortList[i];
				if (!sceneList[sceneSortList[i].sceneListIndex].DCLLIDMKNGO_IsDivaCompatible(divaData.AHHJLDLAPAN_DivaId) || sceneSortList[i].skillWeight[currentSetDivaSlot] == 0)
				{
					sp.skillWeight[currentSetDivaSlot] = 0;
					m_temporaryList.Add(sp);
				}
				else
				{
					sp.weight = 4 - sceneList[sceneSortList[i].sceneListIndex].EMPEHJLBIKC(unitData);
					pickupList.Add(sp);
				}
			}
			pickupList.Sort(SimpleSortFunc2);
			m_temporaryList.Sort(SimpleSortFunc2);
			pickupList.AddRange(m_temporaryList);
		}

		//// RVA: 0x133840C Offset: 0x133840C VA: 0x133840C
		private void SimplePickupCompatibleScene2(ref List<SortParam> pickupList, FFHPBEPOMAK_DivaInfo divaData, List<GCIJNCFDNON_SceneInfo> sceneList, List<SortParam> sceneSortList, JLKEOGLJNOD_TeamInfo unitData)
		{
			pickupList.Clear();
			m_temporaryList.Clear();
			for(int i = 0; i < sceneSortList.Count; i++)
			{
				if(sceneList[sceneSortList[i].sceneListIndex].DCLLIDMKNGO_IsDivaCompatible(divaData.AHHJLDLAPAN_DivaId))
				{
					pickupList.Add(sceneSortList[i]);
				}
				else
				{
					SortParam sp = sceneSortList[i];
					sp.skillWeight[currentSetDivaSlot] = 0;
					m_temporaryList.Add(sp);
				}
			}
			pickupList.Sort(SimpleSortFunc1);
			m_temporaryList.Sort(SimpleSortFunc1);
			pickupList.AddRange(m_temporaryList);
		}

		//// RVA: 0x1336CB4 Offset: 0x1336CB4 VA: 0x1336CB4
		private void NormalPickupCompatibleScene(ref List<SortParam> pickupList, FFHPBEPOMAK_DivaInfo divaData, List<GCIJNCFDNON_SceneInfo> sceneList, List<SortParam> sceneSortList)
		{
			pickupList.Clear();
			m_temporaryList.Clear();
			for (int i = 0; i < sceneSortList.Count; i++)
			{
				if(!IsCompatibleDiva)
				{
					pickupList.Add(sceneSortList[i]);
				}
				else if(sceneList[sceneSortList[i].sceneListIndex].DCLLIDMKNGO_IsDivaCompatible(divaData.AHHJLDLAPAN_DivaId))
				{
					pickupList.Add(sceneSortList[i]);
				}
				else
				{
					m_temporaryList.Add(sceneSortList[i]);
				}
			}
			pickupList.Sort(SortFunc);
			if(IsCompatibleDiva)
			{
				m_temporaryList.Sort(SortFunc);
				pickupList.AddRange(m_temporaryList);
			}
		}

		//// RVA: 0x13388DC Offset: 0x13388DC VA: 0x13388DC
		private int SortFunc(SortParam left, SortParam right)
		{
			int res = right.weight - left.weight;
			if(res == 0)
			{
				res = right.total - left.total;
				if(res == 0)
				{
					if(SelectMusicAttribute > 0 && (left.sceneAttribute != SelectMusicAttribute || right.sceneAttribute != SelectMusicAttribute))
					{
						res = 1;
						if (left.sceneAttribute == SelectMusicAttribute)
							res = -1;
						if (left.sceneAttribute == SelectMusicAttribute || right.sceneAttribute == SelectMusicAttribute)
							return res;
					}
					return left.sceneId - right.sceneId;
				}
			}
			return res;
		}

		//// RVA: 0x133893C Offset: 0x133893C VA: 0x133893C
		private int SimpleSortFunc1(SortParam left, SortParam right)
		{
			int[] l1 = GetSimpleWeightList(left);
			int[] l2 = GetSimpleWeightList(right);
			int res = right.skillWeight[currentSetDivaSlot] - left.skillWeight[currentSetDivaSlot];
			if(res == 0)
			{
				for(int i = 0; i < 10; i++)
				{
					res = l2[i] - l1[i];
					if (res != 0)
						return res;
				}
			}
			return res;
		}

		//// RVA: 0x1338DAC Offset: 0x1338DAC VA: 0x1338DAC
		private int SimpleSortFunc2(SortParam left, SortParam right)
		{
			int[] l1 = GetSimpleWeightList(left);
			int[] l2 = GetSimpleWeightList(right);
			int res = right.skillWeight[currentSetDivaSlot] - left.skillWeight[currentSetDivaSlot];
			if (res == 0)
			{
				res = right.weight - left.weight;
				if (res == 0)
				{
					for (int i = 0; i < 10; i++)
					{
						res = l2[i] - l1[i];
						if (res != 0)
							return res;
					}
				}
			}
			return res;
		}

		//// RVA: 0x1338AC4 Offset: 0x1338AC4 VA: 0x1338AC4
		private int[] GetSimpleWeightList(SortParam sortParam)
		{
			int[] res = new int[10];
			if(SelectPriority == 1)
			{
				res[0] = sortParam.status.life;
				res[1] = sortParam.total;
				res[2] = sortParam.excelentRate;
				res[3] = sortParam.status.soul;
				res[4] = sortParam.status.vocal;
				res[5] = sortParam.status.charm;
			}
			else
			{
				res[0] = sortParam.total;
				res[1] = sortParam.excelentRate;
				res[2] = sortParam.status.soul;
				res[3] = sortParam.status.vocal;
				res[4] = sortParam.status.charm;
				res[5] = sortParam.status.life;
			}
			res[6] = sortParam.status.support;
			res[7] = sortParam.status.fold;
			res[8] = sortParam.luck;
			res[9] = sortParam.sceneId;
			return res;
		}

		//// RVA: 0x1335CE0 Offset: 0x1335CE0 VA: 0x1335CE0
		private void NormalPickupCenterSkill(List<GCIJNCFDNON_SceneInfo> sceneList)
		{
			for(int i = 0; i < m_sortSceneList.Count; i++)
			{
				GCIJNCFDNON_SceneInfo scene = sceneList[m_sortSceneList[i].sceneListIndex];
				int total = scene.CMCKNKKCNDK_Status.Total;
				int a;
				bool b;
				switch(SelectStatus)
				{
					case 0:
						a = scene.CMCKNKKCNDK_Status.Total;
						b = true;
						break;
					case 1:
						a = scene.CMCKNKKCNDK_Status.soul;
						b = true;
						break;
					case 2:
						a = scene.CMCKNKKCNDK_Status.vocal;
						b = true;
						break;
					case 3:
						a = scene.CMCKNKKCNDK_Status.charm;
						b = true;
						break;
					case 4:
						a = scene.CMCKNKKCNDK_Status.life;
						b = false;
						break;
					case 5:
						a = scene.CMCKNKKCNDK_Status.support;
						b = false;
						break;
					case 6:
						a = scene.CMCKNKKCNDK_Status.fold;
						b = false;
						break;
					case 7:
						a = scene.MJBODMOLOBC_Luck;
						b = false;
						break;
					default:
						a = 0;
						b = false;
						break;
				}
				if(SelectMusicAttribute == scene.JGJFIJOCPAG_SceneAttr)
				{
					if(b)
					{
						a = (a * 130) / 100;
					}
					total = (total * 130) / 100;
				}
				SortParam sp = m_sortSceneList[i];
				sp.total = total;
				sp.weight = a;
				m_sortSceneList[i] = sp;
			}
		}

		//// RVA: 0x1337608 Offset: 0x1337608 VA: 0x1337608
		private JJOELIOGMKK_DivaIntimacyInfo InitViewIntimacyData(int divaId = 0)
		{
			JJOELIOGMKK_DivaIntimacyInfo data = new JJOELIOGMKK_DivaIntimacyInfo();
			data.KHEKNNFCAOI(divaId);
			if (data.AHHJLDLAPAN_DivaId == 0)
				return null;
			data.HCDGELDHFHB(false);
			return data;
		}

		//// RVA: 0x1335250 Offset: 0x1335250 VA: 0x1335250
		private void SimplePickupCenterSkill(List<GCIJNCFDNON_SceneInfo> sceneList, int sortType)
		{
			List<int> removeSceneIdList = new List<int>();
			for(int i = 0; i < m_sortSceneList.Count; i++)
			{
				int skillId = sceneList[m_sortSceneList[i].sceneListIndex].MEOOLHNNMHL_GetCenterSkillId(false, MusicAttribute, SelectMusicSeries);
				if(skillId > 0)
				{
					if (SelectMusicID == 0)
					{
						if (sceneList[m_sortSceneList[i].sceneListIndex].FCGHOLNFDDF_HasCenterSkillCondMusicAttr(null, false))
						{
							if ((int)sceneList[m_sortSceneList[i].sceneListIndex].NNOLHKHJPFJ_GetCenterSkillMusicAttr(null, false) != (SelectMusicAttribute < 4 ? new int[4] { 4, 1, 2, 3 }[SelectMusicAttribute] : 0))
							{
								continue;
							}
						}
						if (sceneList[m_sortSceneList[i].sceneListIndex].IFBJBPEBAFH_HasCenterSkillCondSerie(null, false))
						{
							continue;
						}
					}
					else
					{
						if (!(sceneList[m_sortSceneList[i].sceneListIndex].KAFAAPEBCPD_IsMatchCenterSkillMusicAttr(SelectMusicAttribute) && sceneList[m_sortSceneList[i].sceneListIndex].JDAEAJNJBGI_IsMatchCenterSkillSerie(SelectMusicID)))
						{
							continue;
						}
					}
					//LAB_013355a4
					HBDCPGLAPHH skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[skillId - 1];
					KFCIIMBBNCD info = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[skill.HEKHODDJHAO_P1 - 1];
					bool b = false;
					int skillValue = 0;
					int effectType = 0;
					if (skill.HEKHODDJHAO_P1 > 0)
					{
						b = IsSimplePickCenterSkill(info, sortType);
						effectType = info.BBFKKANELFP_EffectType;
						if (effectType != 1)
							effectType = 0;
						if (b)
						{
							skillValue = info.KCOHMHFBDKF_ValueByLevel[sceneList[m_sortSceneList[i].sceneListIndex].DDEDANKHHPN_SkillLevel - 1];
							b = true;
						}
					}
					if (skill.AKGNPLBDKLN_P2 > 0)
					{
						KFCIIMBBNCD info2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[skill.AKGNPLBDKLN_P2 - 1];
						if (IsSimplePickCenterSkill(info2, sortType))
						{
							if (info2.KCOHMHFBDKF_ValueByLevel[sceneList[m_sortSceneList[i].sceneListIndex].DDEDANKHHPN_SkillLevel - 1] > info.KCOHMHFBDKF_ValueByLevel[sceneList[m_sortSceneList[i].sceneListIndex].DDEDANKHHPN_SkillLevel - 1])
							{
								skillValue = info2.KCOHMHFBDKF_ValueByLevel[sceneList[m_sortSceneList[i].sceneListIndex].DDEDANKHHPN_SkillLevel - 1];
							}
						}
						b = true;
					}
					if (b)
					{
						//LAB_01335908
						if (SelectMusicAttribute == sceneList[m_sortSceneList[i].sceneListIndex].JGJFIJOCPAG_SceneAttr)
						{
							skillValue = skillValue * 130 / 100;
						}
					}
					SortParam sp = m_sortSceneList[i];
					sp.weight = skillValue;
					sp.total = sceneList[m_sortSceneList[i].sceneListIndex].CMCKNKKCNDK_Status.Total;
					if (SelectMusicAttribute == sceneList[m_sortSceneList[i].sceneListIndex].JGJFIJOCPAG_SceneAttr)
						sp.total = sp.total * 130 / 100;
					m_sortSceneList[i] = sp;
					if (effectType != 0)
					{
						removeSceneIdList.Add(sp.sceneId);
						m_intimacyList.Add(sp);
					}
				}
			}
			for(int i = 0; i < removeSceneIdList.Count; i++)
			{
				m_sortSceneList.RemoveAll((SortParam x) =>
				{
					//0x1339C68
					return removeSceneIdList[i] == x.sceneId;
				});
			}
		}

		//// RVA: 0x13361D8 Offset: 0x13361D8 VA: 0x13361D8
		private void PickupIntimacyCenterSkill(JLKEOGLJNOD_TeamInfo unitData, List<GCIJNCFDNON_SceneInfo> sceneList, int sortType, bool isGoDiva)
		{
			if(unitData.BCJEAJPLGMB_MainDivas[0] != null)
			{
				int currentMainSceneId = unitData.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId;
				for(int i = 0; i < m_intimacyList.Count; i++)
				{
					int centerSkill = sceneList[m_intimacyList[i].sceneListIndex].MEOOLHNNMHL_GetCenterSkillId(false, MusicAttribute, SelectMusicSeries);
					if(centerSkill > 0)
					{
						if (SelectMusicID == 0)
						{
							if (sceneList[m_intimacyList[i].sceneListIndex].FCGHOLNFDDF_HasCenterSkillCondMusicAttr(null, false))
							{
								if ((int)sceneList[m_intimacyList[i].sceneListIndex].NNOLHKHJPFJ_GetCenterSkillMusicAttr(null, false) != (SelectMusicAttribute < 4 ? new int[4] { 4, 1, 2, 3 }[SelectMusicAttribute] : 0))
									continue;
							}
							if (!sceneList[m_intimacyList[i].sceneListIndex].IFBJBPEBAFH_HasCenterSkillCondSerie(null, false))
							{
								;
							}
							else
								continue;
						}
						else
						{
							if (sceneList[m_intimacyList[i].sceneListIndex].KAFAAPEBCPD_IsMatchCenterSkillMusicAttr(SelectMusicAttribute))
							{
								if (sceneList[m_intimacyList[i].sceneListIndex].JDAEAJNJBGI_IsMatchCenterSkillSerie(SelectMusicID))
								{
									;
								}
								else
									continue;
							}
							else
								continue;
						}
						//LAB_01336578
						HBDCPGLAPHH skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[centerSkill - 1];
						KFCIIMBBNCD info = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[skill.HEKHODDJHAO_P1 - 1];
						if(isGoDiva)
						{
							unitData.BCJEAJPLGMB_MainDivas[0].ODFBCANBLIJ(sceneList[m_intimacyList[i].sceneListIndex]);
						}
						else
						{
							unitData.BCJEAJPLGMB_MainDivas[0].OKDIEDCGODF(sceneList[m_intimacyList[i].sceneListIndex].BCCHOBPJJKE_SceneId, false, null, null);
						}
						int val = 0;
						int skillLevel = sceneList[m_intimacyList[i].sceneListIndex].DDEDANKHHPN_SkillLevel;
						if (skill.HEKHODDJHAO_P1 > 0)
						{
							if(info.BBFKKANELFP_EffectType == 1)
							{
								FOKHDKJJOFB_EffectByNumDiva eff = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EFJFIIPIMOO_GetEffectValue(info.KCOHMHFBDKF_ValueByLevel[skillLevel - 1]);
								val = eff.NANNGLGOFKH_Value[skillLevel - 1]
										* CMMKCEPBIHI.FPJIKEFIJOL_GetNumValidSceneForDivas(eff.FDBOPFEOENF_DivaFlag, unitData) + eff.NNDBJGDFEEM_Min;
							}
						}
						if(skill.AKGNPLBDKLN_P2 > 0)
						{
							KFCIIMBBNCD info2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[skill.AKGNPLBDKLN_P2 - 1];
							if (info2.BBFKKANELFP_EffectType == 1)
							{
								FOKHDKJJOFB_EffectByNumDiva eff = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EFJFIIPIMOO_GetEffectValue(info2.KCOHMHFBDKF_ValueByLevel[skillLevel - 1]);
								int val2 = eff.NANNGLGOFKH_Value[skillLevel - 1]
										* CMMKCEPBIHI.FPJIKEFIJOL_GetNumValidSceneForDivas(eff.FDBOPFEOENF_DivaFlag, unitData) + eff.NNDBJGDFEEM_Min;
								if(val < val2)
								{
									val = info.KCOHMHFBDKF_ValueByLevel[skillLevel - 1];
								}
							}
						}
						if (SelectMusicAttribute == sceneList[m_intimacyList[i].sceneListIndex].JGJFIJOCPAG_SceneAttr)
							val = val * 130 / 100;
						SortParam sp = m_intimacyList[i];
						sp.weight = val;
						sp.total = sceneList[m_intimacyList[i].sceneListIndex].CMCKNKKCNDK_Status.Total;
						if (SelectMusicAttribute == sceneList[m_intimacyList[i].sceneListIndex].JGJFIJOCPAG_SceneAttr)
							sp.total = sp.total * 130 / 100;
						m_intimacyList[i] = sp;
					}
				}
			}
		}

		//// RVA: 0x13376D8 Offset: 0x13376D8 VA: 0x13376D8
		private void PickupLiveSkill(List<GCIJNCFDNON_SceneInfo> sceneList, JLKEOGLJNOD_TeamInfo viewUnitData)
		{
			if(IsSimpleAutoSet)
			{
				for(int i = 0; i < m_sortSceneList.Count; i++)
				{
					int id = sceneList[m_sortSceneList[i].sceneListIndex].FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
					if (id > 0)
					{
						SortParam sp = m_sortSceneList[i];
						if (sceneList[m_sortSceneList[i].sceneListIndex].PKPCDAAHJGP_HasLiveSkillCondMusic())
						{
							if(!(SelectMusicID != 0 && sceneList[m_sortSceneList[i].sceneListIndex].ADDCCPKEFOC_IsMatchLiveSkillMusic(SelectMusicID)))
							{
								continue;
							}
						}
						//LAB_01337924
						if(sceneList[m_sortSceneList[i].sceneListIndex].JEDMBJEICBB_IsLiveSkillMatchAttr(SelectMusicID, false))
						{
							sp.skillWeight = new int[3];
							PPGHMBNIAEC skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[id - 1];
							for(int j = 0; j < skill.EGLDFPILJLG_SkillBuffEffect.Length; j++)
							{
								for(int k = 0; k < 3; k++)
								{
									currentSetDivaSlot = k;
									if(SelectPriority == 2)
									{
										if(skill.EGLDFPILJLG_SkillBuffEffect[j] == 4)
										{
											sp.skillWeight[k] += skill.PHAGNOHBMCM_DurationByIndexAndLevel[sceneList[m_sortSceneList[i].sceneListIndex].AADFFCIDJCB_LiveSkillLevel - 1, j];
										}
									}
									else if(SelectPriority == 1)
									{
										if ((skill.EGLDFPILJLG_SkillBuffEffect[j] | 8) == 10)
										{
											sp.skillWeight[k] += skill.NKGHBKFMFCI_BuffValueByIndexAndLevel[sceneList[m_sortSceneList[i].sceneListIndex].AADFFCIDJCB_LiveSkillLevel - 1, j];
										}
									}
									else if(SelectPriority == 0)
									{
										int t = skill.EGLDFPILJLG_SkillBuffEffect[j];
										if ((t < 19 && ((1 << t) & 0x40202U) != 0) ||
											(t >= 19 && t < 21)
											)
										{
											sp.skillWeight[k] += ScoreWeightCalculate(sceneList[m_sortSceneList[i].sceneListIndex], skill, 0, j, m_viewIntimacyData[k]);
										}
									}
								}
							}
							for(int j = 0; j < 3; j++)
							{
								if(SelectMusicAttribute == sceneList[m_sortSceneList[i].sceneListIndex].JGJFIJOCPAG_SceneAttr)
								{
									sp.skillWeight[j] = sp.skillWeight[j] * 130 / 100;
								}
							}
							sp.total = sceneList[m_sortSceneList[i].sceneListIndex].CMCKNKKCNDK_Status.Total;
							if (SelectMusicAttribute == sceneList[m_sortSceneList[i].sceneListIndex].JGJFIJOCPAG_SceneAttr)
								sp.total = sp.total * 130 / 100;
							m_sortSceneList[i] = sp;
						}
					}
				}
			}
		}

		//// RVA: 0x1338F48 Offset: 0x1338F48 VA: 0x1338F48
		//private GameAttribute.Type ConvCenterSkillAttr(PopupAutoSettingContent.AttributePriority selectMusicAttr) { }

		//// RVA: 0x133903C Offset: 0x133903C VA: 0x133903C
		private int ScoreWeightCalculate(GCIJNCFDNON_SceneInfo sceneData, PPGHMBNIAEC liveSkill, int sortSceneIndex, int liveSkillIndex, JJOELIOGMKK_DivaIntimacyInfo viewIntimacy)
		{
			int maxlen = 0;
			int duration = liveSkill.PHAGNOHBMCM_DurationByIndexAndLevel[sceneData.AADFFCIDJCB_LiveSkillLevel - 1, liveSkillIndex];
			int value = liveSkill.NKGHBKFMFCI_BuffValueByIndexAndLevel[sceneData.AADFFCIDJCB_LiveSkillLevel - 1, liveSkillIndex];
			int eff = liveSkill.EGLDFPILJLG_SkillBuffEffect[liveSkillIndex];
			if (eff < 18)
			{
				if (eff != 1 && eff != 9)
					return 0;
				if(liveSkill.CPNAGMFCIJK_TriggerType >= 5 && liveSkill.CPNAGMFCIJK_TriggerType < 7)
				{
					maxlen = m_scoreMasterInfo.MCMIPODICAN_length;
					duration = m_scoreMasterInfo.GIABDDFGHOK_DivaStartTime;
				}
				else
				{
					if(liveSkill.CPNAGMFCIJK_TriggerType != 4)
					{
						if(liveSkill.CPNAGMFCIJK_TriggerType != 7)
						{
							return duration * value;
						}
						duration *= m_scoreMasterInfo.MCMIPODICAN_length / liveSkill.LFGFBMJNBKN_ConfigValue[sceneData.AADFFCIDJCB_LiveSkillLevel - 1] * 1000;
						if (duration * 1000 - m_scoreMasterInfo.MCMIPODICAN_length > 0)
							duration = duration - (m_scoreMasterInfo.MCMIPODICAN_length / 1000);
						return duration * value;
					}
					maxlen = m_scoreMasterInfo.MCMIPODICAN_length;
					duration = m_scoreMasterInfo.OABPNBLPHHP_ValkStartTime;
				}
				return (maxlen - duration) / 1000 * value;
			}
			if(eff == 20)
			{
				if (viewIntimacy == null)
					return 0;
				EHGAHMIBPIB skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.HJGDBBPDHON(value);
				value = skill.KCOHMHFBDKF_Value1[sceneData.AADFFCIDJCB_LiveSkillLevel - 1];
				int[] value2 = skill.HLMMBNCIIAC_Value2;
				return Mathf.Min(viewIntimacy.HEKJGCMNJAB_CurrentLevel / value * value2[sceneData.AADFFCIDJCB_LiveSkillLevel - 1], skill.DOOGFEGEKLG_ValueMax) * duration;
			}
			if(eff == 19)
			{
				EHGAHMIBPIB skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.HJGDBBPDHON(value);
				value = skill.KCOHMHFBDKF_Value1[sceneData.AADFFCIDJCB_LiveSkillLevel - 1];
				int[] value2 = skill.HLMMBNCIIAC_Value2;
				return Mathf.Min(100 / value * value2[sceneData.AADFFCIDJCB_LiveSkillLevel - 1], skill.DOOGFEGEKLG_ValueMax) * duration;
			}
			if(eff != 18)
			{
				return 0;
			}
			int mul = 0;
			if (liveSkill.CPNAGMFCIJK_TriggerType == 6 || liveSkill.CPNAGMFCIJK_TriggerType == 9)
				mul = m_scoreMasterInfo.NLKEBAOBJCM_Cb - m_scoreMasterInfo.JJBOEMOJPEC_DivaNote;
			return value * duration * Mathf.Max(mul / IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("skill_combo_bonus_value0", 0), 0);
		}

		//// RVA: 0x1338F64 Offset: 0x1338F64 VA: 0x1338F64
		private bool IsSimplePickCenterSkill(KFCIIMBBNCD pattern, int sortType)
		{
			if(sortType == 1)
			{
				if (SelectMusicID != 0)
					return IsSimplePickCenterSkill3(pattern);
				if (pattern.INDDJNMPONH_ModifierType >= 4 && pattern.INDDJNMPONH_ModifierType < 7)
					return true;
				return false;
			}
			else
			{
				if(sortType == 0)
				{
					if (pattern.INDDJNMPONH_ModifierType == 3)
						return pattern.GJLFANGDGCL_CenterSkillTarget == 1;
				}
				return false;
			}
		}

		//// RVA: 0x1339884 Offset: 0x1339884 VA: 0x1339884
		//private bool IsSimplePickCenterSkill1(KFCIIMBBNCD pattern) { }

		//// RVA: 0x13398C0 Offset: 0x13398C0 VA: 0x13398C0
		//private bool IsSimplePickCenterSkill2(KFCIIMBBNCD pattern) { }

		//// RVA: 0x13398F8 Offset: 0x13398F8 VA: 0x13398F8
		private bool IsSimplePickCenterSkill3(KFCIIMBBNCD pattern)
		{
			switch(SelectMusicAttribute)
			{
				case 0:
					if (pattern.INDDJNMPONH_ModifierType != 3)
						return false;
					return pattern.GJLFANGDGCL_CenterSkillTarget >= 6 && pattern.GJLFANGDGCL_CenterSkillTarget < 9;
				case 1:
					if (pattern.INDDJNMPONH_ModifierType != 3)
						return false;
					return pattern.GJLFANGDGCL_CenterSkillTarget == 6;
				case 2:
					if (pattern.INDDJNMPONH_ModifierType != 3)
						return false;
					return pattern.GJLFANGDGCL_CenterSkillTarget == 7;
				case 3:
					if (pattern.INDDJNMPONH_ModifierType != 3)
						return false;
					return pattern.GJLFANGDGCL_CenterSkillTarget == 8;
			}
			return false;
		}

		//// RVA: 0x1339008 Offset: 0x1339008 VA: 0x1339008
		//private bool IsLiveSkillScore(SkillBuffEffect.Type type) { }

		//// RVA: 0x1339860 Offset: 0x1339860 VA: 0x1339860
		//private bool IsLiveSkillHeal(SkillBuffEffect.Type type) { }

		//// RVA: 0x1339874 Offset: 0x1339874 VA: 0x1339874
		//private bool IsLiveSkillCombo(SkillBuffEffect.Type type) { }
	}
}
