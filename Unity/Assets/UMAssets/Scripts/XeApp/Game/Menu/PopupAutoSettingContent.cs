using mcrs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

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
		private static readonly int[,] SimpleDivaSlotAccessTable = new int[2, 8] {
			{ 1, 0, 2, 0, 0, 1, 1, 1 }, {2, 1, 0, 2, 1, 2, 2, 2 }
		}; // 0x0
		private static readonly int[,] NormalDivaSlotAccessTable = new int[2, 8] {
			{ 1, 0, 2, 0, 0, 1, 0, 2 }, {1, 1, 1, 2, 2, 1, 2, 2 }
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
				ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.AFLMHBMBNBO/*48*/, 2, false);
			}
		}

		//// RVA: 0x133331C Offset: 0x133331C VA: 0x133331C
		//private void ListupScene(DFKGGBMFFGB playerData) { }

		//// RVA: 0x133392C Offset: 0x133392C VA: 0x133392C
		//private void SetMainSlot(JLKEOGLJNOD unitData, DFKGGBMFFGB playerData, bool isGoDiva) { }

		//// RVA: 0x133498C Offset: 0x133498C VA: 0x133498C
		//private void SetMainSlotIntimacy(JLKEOGLJNOD unitData, DFKGGBMFFGB playerData, bool isGoDiva) { }

		//// RVA: 0x1334E84 Offset: 0x1334E84 VA: 0x1334E84
		//private void NormalSetSubSlots(JLKEOGLJNOD unitData, DFKGGBMFFGB playerData, bool isGoDiva) { }

		//// RVA: 0x1333F6C Offset: 0x1333F6C VA: 0x1333F6C
		//private void SimpleSetSubSlots(JLKEOGLJNOD unitData, DFKGGBMFFGB playerData, bool isGoDiva) { }

		//// RVA: 0x13370BC Offset: 0x13370BC VA: 0x13370BC
		//private void SetSlot(PopupAutoSettingContent.SlotType slotType, int sceneListIndex, DFKGGBMFFGB playerData, FFHPBEPOMAK divaData, bool isGoDiva) { }

		//// RVA: 0x1337F34 Offset: 0x1337F34 VA: 0x1337F34
		//private void SimplePickupCompatibleScene(ref List<PopupAutoSettingContent.SortParam> pickupList, FFHPBEPOMAK divaData, List<GCIJNCFDNON> sceneList, List<PopupAutoSettingContent.SortParam> sceneSortList, JLKEOGLJNOD unitData) { }

		//// RVA: 0x133840C Offset: 0x133840C VA: 0x133840C
		//private void SimplePickupCompatibleScene2(ref List<PopupAutoSettingContent.SortParam> pickupList, FFHPBEPOMAK divaData, List<GCIJNCFDNON> sceneList, List<PopupAutoSettingContent.SortParam> sceneSortList, JLKEOGLJNOD unitData) { }

		//// RVA: 0x1336CB4 Offset: 0x1336CB4 VA: 0x1336CB4
		//private void NormalPickupCompatibleScene(ref List<PopupAutoSettingContent.SortParam> pickupList, FFHPBEPOMAK divaData, List<GCIJNCFDNON> sceneList, List<PopupAutoSettingContent.SortParam> sceneSortList) { }

		//// RVA: 0x13388DC Offset: 0x13388DC VA: 0x13388DC
		//private int SortFunc(PopupAutoSettingContent.SortParam left, PopupAutoSettingContent.SortParam right) { }

		//// RVA: 0x133893C Offset: 0x133893C VA: 0x133893C
		//private int SimpleSortFunc1(PopupAutoSettingContent.SortParam left, PopupAutoSettingContent.SortParam right) { }

		//// RVA: 0x1338DAC Offset: 0x1338DAC VA: 0x1338DAC
		//private int SimpleSortFunc2(PopupAutoSettingContent.SortParam left, PopupAutoSettingContent.SortParam right) { }

		//// RVA: 0x1338AC4 Offset: 0x1338AC4 VA: 0x1338AC4
		//private int[] GetSimpleWeightList(PopupAutoSettingContent.SortParam sortParam) { }

		//// RVA: 0x1335CE0 Offset: 0x1335CE0 VA: 0x1335CE0
		//private void NormalPickupCenterSkill(List<GCIJNCFDNON> sceneList) { }

		//// RVA: 0x1337608 Offset: 0x1337608 VA: 0x1337608
		//private JJOELIOGMKK InitViewIntimacyData(int divaId = 0) { }

		//// RVA: 0x1335250 Offset: 0x1335250 VA: 0x1335250
		//private void SimplePickupCenterSkill(List<GCIJNCFDNON> sceneList, int sortType) { }

		//// RVA: 0x13361D8 Offset: 0x13361D8 VA: 0x13361D8
		//private void PickupIntimacyCenterSkill(JLKEOGLJNOD unitData, List<GCIJNCFDNON> sceneList, int sortType, bool isGoDiva) { }

		//// RVA: 0x13376D8 Offset: 0x13376D8 VA: 0x13376D8
		//private void PickupLiveSkill(List<GCIJNCFDNON> sceneList, JLKEOGLJNOD viewUnitData) { }

		//// RVA: 0x1338F48 Offset: 0x1338F48 VA: 0x1338F48
		//private GameAttribute.Type ConvCenterSkillAttr(PopupAutoSettingContent.AttributePriority selectMusicAttr) { }

		//// RVA: 0x133903C Offset: 0x133903C VA: 0x133903C
		//private int ScoreWeightCalculate(GCIJNCFDNON sceneData, PPGHMBNIAEC liveSkill, int sortSceneIndex, int liveSkillIndex, JJOELIOGMKK viewIntimacy) { }

		//// RVA: 0x1338F64 Offset: 0x1338F64 VA: 0x1338F64
		//private bool IsSimplePickCenterSkill(KFCIIMBBNCD pattern, int sortType) { }

		//// RVA: 0x1339884 Offset: 0x1339884 VA: 0x1339884
		//private bool IsSimplePickCenterSkill1(KFCIIMBBNCD pattern) { }

		//// RVA: 0x13398C0 Offset: 0x13398C0 VA: 0x13398C0
		//private bool IsSimplePickCenterSkill2(KFCIIMBBNCD pattern) { }

		//// RVA: 0x13398F8 Offset: 0x13398F8 VA: 0x13398F8
		//private bool IsSimplePickCenterSkill3(KFCIIMBBNCD pattern) { }

		//// RVA: 0x1339008 Offset: 0x1339008 VA: 0x1339008
		//private bool IsLiveSkillScore(SkillBuffEffect.Type type) { }

		//// RVA: 0x1339860 Offset: 0x1339860 VA: 0x1339860
		//private bool IsLiveSkillHeal(SkillBuffEffect.Type type) { }

		//// RVA: 0x1339874 Offset: 0x1339874 VA: 0x1339874
		//private bool IsLiveSkillCombo(SkillBuffEffect.Type type) { }
	}
}
