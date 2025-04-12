using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupSortMenu : UIBehaviour, IPopupContent
	{
		public enum SortPlace
		{
			None = -1,
			Diva = 0,
			SceneSelect = 1,
			Costume = 2,
			Unit = 3,
			SceneList = 4,
			AssistList = 5,
			EpsiodeSelect = 6,
			VisitList = 7,
			DecoShopList = 8,
			DecoInteriorList = 9,
			FriendList = 10,
			GuestSelect = 11,
			SentRequestList = 12,
			PendingList = 13,
			LobbyMemberList = 14,
			Max = 15,
		}
		
		private RectTransform m_rectTransform; // 0x10
		private SortMenuWindow m_sortMenuWindow; // 0x14
		private PopupSortMenu.SortPlace m_sortPlace; // 0x18
		private SortItem m_sortItem; // 0x1C
		private AssistItem m_assistItem; // 0x20
		private uint m_rarityButtonStateBit; // 0x24
		private uint m_attributeButtonStateBit; // 0x28
		private uint m_seriaseButtonStateBit; // 0x2C
		private uint m_centerSkillButtonStateBit; // 0x30
		private uint m_compatibleButtonStateBit; // 0x34
		private uint m_interiorButtonStateBit; // 0x38
		private bool m_isCompatibleDiva = true; // 0x3C
		private readonly Color EnableButtonColor = Color.white; // 0x40
		private readonly Color DisableButtonColor = Color.gray; // 0x50
		private const int SortButtonMax = 16;
		private static readonly List<SortItem> SceneSortItemList = new List<SortItem>() {
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Level, 
			SortItem.Rarity, SortItem.Get, SortItem.Episode, SortItem.SecretBoard, SortItem.LuckyLeaf, SortItem.NotesExpectation
		}; // 0x0
		private static readonly List<SortItem> SceneGrowthSortItem = new List<SortItem>()
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Level,
			SortItem.Rarity, SortItem.ActiveSkill, SortItem.LiveSkill, SortItem.Get, SortItem.Episode, SortItem.SecretBoard, SortItem.LuckyLeaf
		}; // 0x4
		private static readonly List<SortItem> AssistSortItem = new List<SortItem>()
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Level,
			SortItem.Rarity, SortItem.Episode, SortItem.LuckyLeaf
		}; // 0x8
		private static readonly List<SortItem> UnitSortItemList = new List<SortItem>()
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Level,
			SortItem.Skill, SortItem.Episode
		}; // 0xC
		private static readonly List<SortItem> UnitDivaSortItemList = new List<SortItem>()
		{
			SortItem.Total, SortItem.Level, SortItem.MusicExp
		}; // 0x10
		private static readonly List<SortItem> FriendList = new List<SortItem>()
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Level,
			SortItem.Rarity, SortItem.None, SortItem.None, SortItem.LastPlayDate, SortItem.PlayerRunk, SortItem.HighScoreRating
		}; // 0x14
		private static readonly List<SortItem> GuestList = new List<SortItem>()
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Level,
			SortItem.Rarity, SortItem.Episode, SortItem.LuckyLeaf
		}; // 0x18
		private static readonly List<SortItem> SentPendingList = new List<SortItem>()
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Level,
			SortItem.Rarity, SortItem.None, SortItem.None, SortItem.LastPlayDate, SortItem.PlayerRunk, SortItem.HighScoreRating, SortItem.Request
		}; // 0x1C
		private static readonly List<SortItem> EpisodeSortList = new List<SortItem>()
		{
			SortItem.EpisodeNo, SortItem.EpisodePoint, SortItem.DivaAndValkyrie
		}; // 0x20
		private static readonly List<SortItem> VisitSortList = new List<SortItem>()
		{
			SortItem.LastPlayDate, SortItem.PlayerRunk, SortItem.FanNum
		}; // 0x24
		private static readonly List<SortItem> LobbyMemberList = new List<SortItem>()
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Level,
			SortItem.Rarity, SortItem.None, SortItem.None, SortItem.LastPlayDate, SortItem.MainCannnonPower, SortItem.Fan
		}; // 0x28
		private static readonly List<SortItem> MusicSelectSortList = new List<SortItem>()
		{
			SortItem.Default, SortItem.MusicLevel, SortItem.HighScore, SortItem.UtaRate, SortItem.ClearNum, SortItem.NotesNum, SortItem.MusicLength
		}; // 0x2C
		private static readonly List<SortItem> ShopSortItemList = new List<SortItem>()
		{
			SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Level,
			SortItem.Rarity, SortItem.Episode, SortItem.NotesExpectation
		}; // 0x30
		private static readonly List<SortItem>[] SortItemTable = new List<SortItem>[15]
		{
			new List<SortItem>()
			{
				SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold, SortItem.Luck, SortItem.Level
			},
			SceneSortItemList,
			new List<SortItem>()
			{
				SortItem.Total, SortItem.Soul, SortItem.Voice, SortItem.Charm, SortItem.Life, SortItem.Support, SortItem.Fold
			},
			UnitSortItemList,
			SceneGrowthSortItem,
			AssistSortItem,
			EpisodeSortList,
			VisitSortList,
			new List<SortItem>(),
			new List<SortItem>(),
			FriendList,
			GuestList,
			SentPendingList,
			SentPendingList,
			LobbyMemberList
		}; // 0x34
		private static readonly string[] MsgTbl_SortItem = new string[48] {
			"popup_sort_item_total",
			"popup_sort_item_soul",
			"popup_sort_item_voice",
			"popup_sort_item_charm",
			"popup_sort_item_get",
			"popup_sort_item_rarity",
			"popup_sort_item_level",
			"popup_sort_item_life",
			"popup_sort_item_luck",
			"popup_sort_item_support",
			"popup_sort_item_fold",
			"popup_sort_item_recovery_notes",
			"popup_sort_item_item_notes",
			"popup_sort_item_scoreup_notes",
			"popup_sort_item_support_notes",
			"popup_sort_item_fold_notes",
			"popup_sort_item_last_playdate",
			"popup_sort_item_player_runk",
			"popup_sort_item_request",
			"popup_sort_item_skill",
			"popup_sort_item_active_skill",
			"popup_sort_item_live_skill",
			"popup_sort_item_episode",
			"popup_sort_item_secret_board",
			"popup_sort_item_highscorerating",
			"popup_sort_item_fannum",
			"popup_sort_item_episodeno",
			"popup_sort_item_diva_and_valkyrie",
			"popup_sort_item_episode_point",
			"popup_sort_item_lucky_leaf",
			"popup_sort_item_main_cannnon_power",
			"popup_sort_item_fan",
			"popup_sort_item_furniture",
			"popup_sort_item_ornament",
			"popup_sort_item_rug",
			"popup_sort_item_rack",
			"popup_sort_item_other",
			"popup_sort_item_filter",
			"popup_sort_item_music_exp",
			"popup_sort_item_diva_and_valkyrie_and_bg",
			"popup_sort_item_default",
			"popup_sort_item_musiclevel",
			"popup_sort_item_highscore",
			"popup_sort_item_utarate",
			"popup_sort_item_clearnum",
			"popup_sort_item_notesnum",
			"popup_sort_item_musiclength",
			"popup_sort_item_notes_expectation"
		}; // 0x38

		public Transform Parent { get; private set; } // 0xC
		public SortItem SortItem { get { return m_sortItem; } set { m_sortItem = value; } } //0x1149B04 0x1149B0C 
		public AssistItem AssistItem { get { return m_assistItem; } set { m_assistItem = value; } } //0x1149B14 0x1149B1C
		public static List<SortItem> UnitSortItem { get { return UnitSortItemList; } } //0x1149B24 
		public static List<SortItem> UnitDivaSortItem { get { return UnitDivaSortItemList; } }  //0x1149BB0
		public static List<SortItem> SceneSortItem { get { return SceneSortItemList; } } //0x1149C3C
		public static List<SortItem> MusicSelectSortItem { get { return MusicSelectSortList; } }//0x1149CC8
		public static List<SortItem> ShopSortItem { get { return ShopSortItemList; } } //0x1149D54
		
		//// RVA: 0x1149DE0 Offset: 0x1149DE0 VA: 0x1149DE0
		public static string GetMsg_SortItem(SortItem a_item)
		{
			return MessageManager.Instance.GetBank("menu").GetMessageByLabel(MsgTbl_SortItem[(int)a_item]);
		}

		//// RVA: 0x1149F0C Offset: 0x1149F0C VA: 0x1149F0C
		public uint GetRarityFilter()
		{
			return m_rarityButtonStateBit;
		}

		//// RVA: 0x1149F14 Offset: 0x1149F14 VA: 0x1149F14
		public uint GetAttributeFilter()
		{
			return m_attributeButtonStateBit;
		}

		//// RVA: 0x1149F1C Offset: 0x1149F1C VA: 0x1149F1C
		public uint GetSeriaseFilter()
		{
			return m_seriaseButtonStateBit;
		}

		//// RVA: 0x1149F24 Offset: 0x1149F24 VA: 0x1149F24
		public uint GetCenterSkillFilter()
		{
			return m_centerSkillButtonStateBit;
		}

		//// RVA: 0x1149F2C Offset: 0x1149F2C VA: 0x1149F2C
		//public uint GetCompatibleFilter() { }

		//// RVA: 0x1149F34 Offset: 0x1149F34 VA: 0x1149F34
		public uint GetInteriorFilter()
		{
			return m_interiorButtonStateBit;
		}

		//// RVA: 0x1149F3C Offset: 0x1149F3C VA: 0x1149F3C
		private void Awake()
		{
			m_sortMenuWindow = GetComponent<SortMenuWindow>();
			m_sortMenuWindow.PushSortButtonEvent.AddListener(OnChangeSort);
			m_sortMenuWindow.PushAssistButtonEvent.AddListener(OnChangeAssist);
			m_sortMenuWindow.PushRareButtonEvent.AddListener(OnChangeRareFilter);
			m_sortMenuWindow.PushAttributeButtonEvent.AddListener(OnChangeAttributeFilter);
			m_sortMenuWindow.PushSeriesButtonEvent.AddListener(OnChangeSeriesFilter);
			m_sortMenuWindow.PushCenterSkillButtonEvent.AddListener(OnChangeCenterSkillFilter);
			m_sortMenuWindow.PushDivaButtonEvent.AddListener(OnChangeCompatibleDivaFilter);
			m_sortMenuWindow.PushCompatibleDivaButtonEvent.AddListener(OnChangeCompatibleCheck);
			m_sortMenuWindow.PushInteriorButtonEvent.AddListener(OnChangeInteriorFilter);
			m_rectTransform = transform as RectTransform;
		}

		//// RVA: 0x114A514 Offset: 0x114A514 VA: 0x114A514 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupSortMenuSetting s = setting as PopupSortMenuSetting;
			m_rectTransform.anchoredPosition = new Vector2(0, 0);
			Parent = setting.m_parent;
			m_sortPlace = s.SortPlace;
			m_isCompatibleDiva = s.IsCompatibleDiva;
			int f = 0;
			if(SortItemTable[(int)m_sortPlace].Count < 1)
			{
				for(int i = 0; i < 16; i++)
				{
					m_sortMenuWindow.SetSortButtonDisable(i, (int)m_sortPlace > 9);
				}
			}
			else
			{
				int i = 0;
				for(; i < SortItemTable[(int)m_sortPlace].Count; i++)
				{
					if(SortItemTable[(int)m_sortPlace][i] == SortItem.None)
					{
						m_sortMenuWindow.SetSortButtonDisable(i, (int)m_sortPlace > 9);
					}
					else
					{
						m_sortMenuWindow.SetSortLabel(i, SortItemTable[(int)m_sortPlace][i], (int)m_sortPlace > 9);
						m_sortMenuWindow.SetSortButtonEnable(i, (int)m_sortPlace > 9);
					}
					if(SortItemTable[(int)m_sortPlace][i] == s.SortItem)
						f = i;
				}
				for(; i < 16; i++)
				{
					m_sortMenuWindow.SetSortButtonDisable(i, (int)m_sortPlace > 9);
				}
			}
			m_sortMenuWindow.SetSortTitle(m_sortPlace == SortPlace.Unit ? SortMenuWindow.SortTitle.Status : SortMenuWindow.SortTitle.Sort);
			m_sortItem = s.SortItem;
			m_assistItem = s.AssistItem;
			m_sortMenuWindow.SetSelectSortButton(f, (int)m_sortPlace > 9);
			if(m_sortPlace == SortPlace.GuestSelect)
			{
				m_sortMenuWindow.ShowAssistSelectFilter();
				m_sortMenuWindow.SetAssistSlotLabel();
				m_sortMenuWindow.SetSelectAssistButton(GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GDMIGCCMEEF_GuestSelect.NPEEPPCPEPE_assistItem);
				m_seriaseButtonStateBit = s.SeriaseFilter;
				m_sortMenuWindow.SetFilterButton(SortMenuWindow.FilterType.Series, ((m_seriaseButtonStateBit & 2) << 1) | (m_seriaseButtonStateBit & 16) | ((m_seriaseButtonStateBit & 1) << 3) | ((m_seriaseButtonStateBit >> 1) & 2) | ((m_seriaseButtonStateBit << 28) >> 31));
				m_centerSkillButtonStateBit = s.CenterSkillFilter;
				m_sortMenuWindow.SetFilterButton(SortMenuWindow.FilterType.CenterSkill, s.CenterSkillFilter);
			}
			else if(m_sortPlace == SortPlace.AssistList)
			{
				m_sortMenuWindow.ShowAssistEditFilter(s.SelectedAttrId);
				m_attributeButtonStateBit = s.AttributeFilter;
				m_sortMenuWindow.SetFilterButton(SortMenuWindow.FilterType.Attribute, s.AttributeFilter);
				m_seriaseButtonStateBit = s.SeriaseFilter;
				m_sortMenuWindow.SetFilterButton(SortMenuWindow.FilterType.Series, ((m_seriaseButtonStateBit & 2) << 1) | (m_seriaseButtonStateBit & 16) | ((m_seriaseButtonStateBit & 1) << 3) | ((m_seriaseButtonStateBit >> 1) & 2) | ((m_seriaseButtonStateBit << 28) >> 31));
				m_centerSkillButtonStateBit = s.CenterSkillFilter;
				m_sortMenuWindow.SetFilterButton(SortMenuWindow.FilterType.CenterSkill, s.CenterSkillFilter);
			}
			else if(m_sortPlace == SortPlace.SceneSelect || m_sortPlace == SortPlace.SceneList || (int)m_sortPlace > 9)
			{
				m_sortMenuWindow.ShowFilter(m_sortPlace == SortPlace.SceneSelect, (int)m_sortPlace > 9);
				m_sortMenuWindow.SetDivaButtonIcon(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas);
				m_rarityButtonStateBit = s.RarityFilter;
				m_sortMenuWindow.SetFilterButton(SortMenuWindow.FilterType.Rare, s.RarityFilter);
				m_attributeButtonStateBit = s.AttributeFilter;
				m_sortMenuWindow.SetFilterButton(SortMenuWindow.FilterType.Attribute, s.AttributeFilter);
				m_seriaseButtonStateBit = s.SeriaseFilter;
				m_sortMenuWindow.SetFilterButton(SortMenuWindow.FilterType.Series, ((m_seriaseButtonStateBit & 2) << 1) | (m_seriaseButtonStateBit & 16) | ((m_seriaseButtonStateBit & 1) << 3) | ((m_seriaseButtonStateBit >> 1) & 2) | ((m_seriaseButtonStateBit << 28) >> 31));
				m_compatibleButtonStateBit = s.CompatibleFilter;
				m_sortMenuWindow.SetDivaFilterButton(s.CompatibleFilter);
				m_sortMenuWindow.SelectedDivaId(s.SelectedDivaId);
				m_sortMenuWindow.SetCompatibleDivaButtonState(m_isCompatibleDiva);
			}
			else if(((int)m_sortPlace & 0xfffffffe) == 8)
			{
				m_sortMenuWindow.ShowDecoFilter(m_sortPlace == SortPlace.DecoInteriorList);
				m_sortMenuWindow.SetDivaButtonIcon(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas);
				m_seriaseButtonStateBit = s.SeriaseFilter;
				m_sortMenuWindow.SetFilterButton(SortMenuWindow.FilterType.Series, ((m_seriaseButtonStateBit & 2) << 1) | (m_seriaseButtonStateBit & 16) | ((m_seriaseButtonStateBit & 1) << 3) | ((m_seriaseButtonStateBit >> 1) & 2) | ((m_seriaseButtonStateBit << 28) >> 31));
				if(m_sortPlace != SortPlace.DecoInteriorList)
					return;
				m_interiorButtonStateBit = s.InteriorFilter;
				m_sortMenuWindow.SetFilterButton(SortMenuWindow.FilterType.Interior, m_interiorButtonStateBit);
			}
			else
			{
				m_sortMenuWindow.HideFilter();
			}
		}

		//// RVA: 0x114B054 Offset: 0x114B054 VA: 0x114B054 Slot: 18
		public bool IsScrollable()
		{
			return m_sortPlace == SortPlace.SceneSelect || 
				m_sortPlace == SortPlace.SceneList || 
				m_sortPlace == SortPlace.AssistList || 
				(int)m_sortPlace > 9;
		}

		//// RVA: 0x114AFBC Offset: 0x114AFBC VA: 0x114AFBC
		//private bool IsFriendSort() { }

		//// RVA: 0x114B08C Offset: 0x114B08C VA: 0x114B08C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			m_rectTransform.anchoredPosition = new Vector2(0, 0);
		}

		//// RVA: 0x114B114 Offset: 0x114B114 VA: 0x114B114 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		//// RVA: 0x114B14C Offset: 0x114B14C VA: 0x114B14C Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		//// RVA: 0x114B1EC Offset: 0x114B1EC VA: 0x114B1EC Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0x114B1F0 Offset: 0x114B1F0 VA: 0x114B1F0
		private void OnChangeSort(int index)
		{
			m_sortItem = SortItemTable[(int)m_sortPlace][index];
		}

		//// RVA: 0x114B2EC Offset: 0x114B2EC VA: 0x114B2EC
		private void OnChangeAssist(int index)
		{
			m_assistItem = (AssistItem)index;
		}

		//// RVA: 0x114B2F4 Offset: 0x114B2F4 VA: 0x114B2F4
		private void OnChangeRareFilter(uint bit)
		{
			m_rarityButtonStateBit = bit;
		}

		//// RVA: 0x114B2FC Offset: 0x114B2FC VA: 0x114B2FC
		private void OnChangeAttributeFilter(uint bit)
		{
			m_attributeButtonStateBit = bit;
		}

		//// RVA: 0x114B304 Offset: 0x114B304 VA: 0x114B304
		private void OnChangeSeriesFilter(uint bit)
		{
			m_seriaseButtonStateBit = (bit & 2) << 1 | bit & 0x10 | (bit & 1) << 3 | ((bit >> 1) & 2) | (bit << 0x1c) >> 0x1f;
		}

		//// RVA: 0x114AFF8 Offset: 0x114AFF8 VA: 0x114AFF8
		//private uint ReverseSeriesBit(uint bit) { }

		//// RVA: 0x114B33C Offset: 0x114B33C VA: 0x114B33C
		private void OnChangeCenterSkillFilter(uint bit)
		{
			m_centerSkillButtonStateBit = bit;
		}

		//// RVA: 0x114B344 Offset: 0x114B344 VA: 0x114B344
		private void OnChangeCompatibleCheck(bool isOn)
		{
			m_isCompatibleDiva = isOn;
		}

		//// RVA: 0x114B34C Offset: 0x114B34C VA: 0x114B34C
		private void OnChangeCompatibleDivaFilter(uint bit)
		{
			m_compatibleButtonStateBit = 0;
			for(int i = 0; i < GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Count; i++)
			{
				if((bit & (1 << i)) != 0)
				{
					m_compatibleButtonStateBit |= (byte)(1 << (GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId - 1));
				}
			}
		}

		//// RVA: 0x114B4C8 Offset: 0x114B4C8 VA: 0x114B4C8
		private void OnChangeInteriorFilter(uint bit)
		{
			m_interiorButtonStateBit = bit;
		}

		//// RVA: 0x114B4D0 Offset: 0x114B4D0 VA: 0x114B4D0
		public void ApplyLocalSaveData(ref ILDKBCLAFPB.IJDOCJCLAIL_SortProprty localSaveData)
		{
			switch(m_sortPlace)
			{
				case PopupSortMenu.SortPlace.Diva:
					localSaveData.ONPAMDMIEKM_divaSortItem = (int)m_sortItem;
					break;
				case PopupSortMenu.SortPlace.SceneSelect:
					localSaveData.LNFFKCDNCPN_sceneSelectSortItem = (int)m_sortItem;
					localSaveData.FFAKMECDMFC_sceneSelectRarityFilter = (int)m_rarityButtonStateBit;
					localSaveData.LMPKAPBCIFD_sceneSelectAttributeFilter = (int)m_attributeButtonStateBit;
					localSaveData.MNNCLIFBAOA_sceneSelectSeriaseFilter = (int)m_seriaseButtonStateBit;
					localSaveData.NPFGKBKKCFL_sceneSelectCompatibleFilter = (int)m_compatibleButtonStateBit;
					localSaveData.JACFDEKLDCK_isCompatibleDivaCheck = m_isCompatibleDiva ? 1 : 0;
					localSaveData.IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter = 0;
					localSaveData.AIPJDIPBDEA_sceneSelectLiveSkillRankFilter = 0;
					localSaveData.OCKOEPFNGJG_sceneSelectLiveSkillFilter = 0;
					localSaveData.BPFPFOJNFLC_sceneSelectCenterSkillRankFilter = 0;
					localSaveData.IHECEFMGKHO_sceneSelectCenterSkillFilter = 0;
					localSaveData.BIBBAIFCGLD_sceneSelectActiveSkillRankFilter = 0;
					localSaveData.POJHGOJDOND_sceneSelectActiveSkillFilter = 0;
					break;
				case PopupSortMenu.SortPlace.Costume:
					localSaveData.MDJMAEEONKK_costumeSortItem = (int)m_sortItem;
					break;
				case PopupSortMenu.SortPlace.Unit:
					localSaveData.LEAPMNHODPJ_unitWindowDispItem = (int)m_sortItem;
					break;
				case PopupSortMenu.SortPlace.SceneList:
					localSaveData.GEAECNMDMHH_sceneListSortItem = (int)m_sortItem;
					localSaveData.HMJNAGNIEJB_sceneListRarityFilter = (int)m_rarityButtonStateBit;
					localSaveData.HFGAILIOFAN_sceneListAttributeFilter = (int)m_attributeButtonStateBit;
					localSaveData.AKFPHKLCHAA_sceneListSeriaseFilter = (int)m_seriaseButtonStateBit;
					localSaveData.PHCEMKLNJLH_sceneListCompatibleFilter = (int)m_compatibleButtonStateBit;
					localSaveData.LALFKJDFPOD_sceneListLiveSkillRangeFilter = 0;
					localSaveData.HKFPBAFALHO_sceneListLiveSkillRankFilter = 0;
					localSaveData.BOMCDAIEFLN_sceneListLiveSkillFilter = 0;
					localSaveData.MECEGIJIGBN_sceneListCenterSkillRankFilter = 0;
					localSaveData.IOBABMJPAAE_sceneListCenterSkillFilter = 0;
					localSaveData.ALFGELGDIGC_sceneListActiveSkillRankFilter = 0;
					localSaveData.GIPNFAFFNLF_sceneListActiveSkillFilter = 0;
					break;
				case PopupSortMenu.SortPlace.AssistList:
					localSaveData.NCDOLBOHGFN_sceneAssistSortItem = (int)m_sortItem;
					localSaveData.OFFBGLDDBHC_sceneAssistAttributeFilter = (int)m_attributeButtonStateBit;
					localSaveData.POPIEDDJGBA_sceneAssistSeriaseFilter = (int)m_seriaseButtonStateBit;
					localSaveData.GJFPKDOBIPH_sceneAssistCenterSkillFilter = (int)m_centerSkillButtonStateBit;
					break;
				case PopupSortMenu.SortPlace.EpsiodeSelect:
				case PopupSortMenu.SortPlace.VisitList:
					break;
				case PopupSortMenu.SortPlace.DecoShopList:
					localSaveData.MOOHKFCHJPO_shopListSeriaseFilter = (int)m_seriaseButtonStateBit;
					break;
				case PopupSortMenu.SortPlace.DecoInteriorList:
					localSaveData.MOOHKFCHJPO_shopListSeriaseFilter = (int)m_seriaseButtonStateBit;
					localSaveData.PJDCJKHMNNM_interiorListFilter = (int)m_interiorButtonStateBit;
					break;
				case PopupSortMenu.SortPlace.FriendList:
					ApplyFriendSortParam(localSaveData.IDFGCPNELIA_FriendList);
					break;
				case PopupSortMenu.SortPlace.GuestSelect:
					ApplyFriendSortParam(localSaveData.GDMIGCCMEEF_GuestSelect);
					break;
				case PopupSortMenu.SortPlace.SentRequestList:
					ApplyFriendSortParam(localSaveData.EJAJGGKHALM_SentRequestList);
					break;
				case PopupSortMenu.SortPlace.PendingList:
					ApplyFriendSortParam(localSaveData.DOKBEPGKNJK_PendingList);
					break;
				case PopupSortMenu.SortPlace.LobbyMemberList:
					ApplyFriendSortParam(localSaveData.ACCNCHJBDHM_UserList);
					break;
			}
		}

		//// RVA: 0x114B9A0 Offset: 0x114B9A0 VA: 0x114B9A0
		private void ApplyFriendSortParam(ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList friendProperty)
		{
			friendProperty.LHPDCGNKPHD_sortItem = (int)m_sortItem;
			friendProperty.NPEEPPCPEPE_assistItem = (int)m_assistItem;
			friendProperty.ACCHOFLOOEC_filter = (int)m_rarityButtonStateBit;
			friendProperty.BOFFOHHLLFG_attributeFilter = (int)m_attributeButtonStateBit;
			friendProperty.BBIIHLNBHDE_seriaseFilter = (int)m_seriaseButtonStateBit;
			friendProperty.LKPCKPJGJKN_centerSkillFilter = (int)m_centerSkillButtonStateBit;
		}

		//// RVA: 0x114BA5C Offset: 0x114BA5C VA: 0x114BA5C
		public static bool IsHaveFilterOn(bool have, uint flags)
		{
			if(flags != 0)
			{
				return (flags & (1 << (have ? 0 : 1))) != 0;
			}
			return true;
		}

		//// RVA: 0x114BB20 Offset: 0x114BB20 VA: 0x114BB20
		public static bool IsRarityFilterOn(int rare, uint flags)
		{
			if(flags != 0)
			{
				return (flags & (1 << (rare - 1))) != 0;
			}
			return true;
		}

		//// RVA: 0x114BBC4 Offset: 0x114BBC4 VA: 0x114BBC4
		public static bool IsAttributeFilterOn(int attr, uint flags)
		{
			if(flags != 0)
			{
				return (flags & (1 << (attr - 1))) != 0;
			}
			return true;
		}

		//// RVA: 0x114BC68 Offset: 0x114BC68 VA: 0x114BC68
		public static bool IsSerializeFilterOn(int seriase, uint flags)
		{
			if(flags != 0)
			{
				return (flags & (1 << (seriase - 1))) != 0;
			}
			return true;
		}

		//// RVA: 0x114BD0C Offset: 0x114BD0C VA: 0x114BD0C
		public static bool IsCompatibleFilterOn(int divaBit, uint flags)
		{
			return flags == 0 || (flags & divaBit) != 0;
		}

		//// RVA: 0x114BD28 Offset: 0x114BD28 VA: 0x114BD28
		public static bool IsNotesFilterOn(int notes, uint flags)
		{
			if(flags != 0)
			{
				return ((notes == 0 ? 32 : 1 << (notes - 1)) & flags) != 0;
			}
			return true;
		}

		//// RVA: 0x114BD58 Offset: 0x114BD58 VA: 0x114BD58
		public static bool IsSkillRankFilterOn(int skillRank, int skillRank2, uint flags)
		{
			if(flags != 0)
			{
				return ((flags & (1 << skillRank - 1))) != 0 || ((flags & (1 << skillRank2 - 1))) != 0;
			}
			return true;
		}

		//// RVA: 0x114BD94 Offset: 0x114BD94 VA: 0x114BD94
		public static bool IsSkillRankFilterOn(int skillRank, int skillRank2, uint flags, bool isCenterSkill, GCIJNCFDNON_SceneInfo scene, EEDKAACNBBG_MusicData musicData)
		{
			int s2 = 1 << (skillRank2 - 1);
			int s1 = 1 << (skillRank - 1);
			if(musicData == null)
			{
				if(flags == 0)
					return true;
				if((s1 & flags) != 0)
					return true;
			}
			else
			{
				int jacketAttr = musicData.FKDCCLPGKDK_JacketAttr;
				int serie = musicData.AIHCEGFANAM_Serie;
				int a = 0;
				int b = 0;
				if(isCenterSkill)
				{
					a = scene.MEOOLHNNMHL_GetCenterSkillId(false, jacketAttr, serie);
					b = scene.MEOOLHNNMHL_GetCenterSkillId(true, 0, 0);
				}
				else
				{
					a = scene.FILPDDHMKEJ_GetLiveSkillId(false, jacketAttr, serie);
					b = scene.FILPDDHMKEJ_GetLiveSkillId(true, 0, 0);
				}
				if(flags == 0)
					return true;
				if(a != b)
					s2 = s1;
				if(a < 1)
					s2 = s1;
			}
			return (s2 & flags) != 0;
		}

		//// RVA: 0x114BEEC Offset: 0x114BEEC VA: 0x114BEEC
		public static bool IsSkillRangeFilterOn(int skillRange, uint flags)
		{
			return flags == 0 || (flags & (1 << (skillRange - 1))) != 0;
		}

		//// RVA: 0x114BF18 Offset: 0x114BF18 VA: 0x114BF18
		public static bool IsInteriorTypeFilterOn(int interiorType, uint flags)
		{
			if(flags != 0)
			{
				return (flags & (1 << interiorType - 1)) != 0;
			}
			return true;
		}

		//// RVA: 0x114BFBC Offset: 0x114BFBC VA: 0x114BFBC
		public static bool IsCenterSkillFilterOn(GCIJNCFDNON_SceneInfo scene, ulong flags)
		{
			if(flags == 0)
				return true;
			int skillId = scene.MEOOLHNNMHL_GetCenterSkillId(true, 0, 0);
			if(skillId != 0)
			{
				int cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.NHGMDOIBNDE.Count;
				HBDCPGLAPHH skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[skillId - 1];
				int[] a1 = new int[2]
				{
					skill.HEKHODDJHAO_P1,
					skill.AKGNPLBDKLN_P2
				};
				if(cnt > 0)
				{
					for(int i = 0; i < cnt; i++)
					{
						BNHOEENHMDF t = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.NHGMDOIBNDE[i];
						ulong bit = (ulong)1 << t.MKDDOJOADMF;
						if((bit & flags) != 0)
						{
							//LAB_0114c658
							for(int j = 0; j < t.NNDGIAEFMOG.Count; j++)
							{
								bool b = false;
								AFLHKMDNHID a = t.NNDGIAEFMOG[j];
								for(int k = 0; k < a1.Length; k++)
								{
									if(a1[k] < 1)
									{
										if(a.INDDJNMPONH[k] != 0)
											b = true;
										if(a.GJLFANGDGCL[k] != 0)
											b = true;
										if(a.OAFPGJLCNFM[k] != 0)
											b = true;
									}
									else
									{
										KFCIIMBBNCD dataK = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[a1[k] - 1];
										if(dataK.INDDJNMPONH_ModifierType != a.INDDJNMPONH[k])
											b = true;
										if(dataK.GJLFANGDGCL_CenterSkillTarget != a.GJLFANGDGCL[k])
											b = true;
										if(dataK.OAFPGJLCNFM_CenterSkillCondition != a.OAFPGJLCNFM[k])
											b = true;
									}
								}
								if(!b)
									return true;
							}
						}
					}
				}
			}
			return false;
		}

		//// RVA: 0x114C748 Offset: 0x114C748 VA: 0x114C748
		public static bool IsActiveSkillFilterOn(GCIJNCFDNON_SceneInfo scene, ulong flags)
		{
			if (flags == 0)
				return true;
			if(scene.HGONFBDIBPM_ActiveSkillId != 0)
			{
				CDNKOFIELMK skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[scene.HGONFBDIBPM_ActiveSkillId - 1];
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.OEELDELPIIP.Count; i++)
				{
					HCDIOPEOGEE h = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.OEELDELPIIP[i];
					ulong bit = (ulong)1 << h.MKDDOJOADMF;
					if((bit & flags) != 0)
					{
						for (int j = 0; j < h.NNDGIAEFMOG.Count; j++)
						{
							CCINPCJDFJG c = h.NNDGIAEFMOG[j];
							bool b = false;
							for(int k = 0; k < skill.EGLDFPILJLG_BuffEffectType.Length; k++)
							{
								if(skill.EGLDFPILJLG_BuffEffectType[k] != c.EGLDFPILJLG[k])
								{
									b = true;
									break;
								}
							}
							for(int k = 0; k < skill.FPMFEKIPFPI_DurationType.Length; k++)
							{
								if (skill.FPMFEKIPFPI_DurationType[k] != c.FPMFEKIPFPI[k])
								{
									b = true;
									break;
								}
							}
							if (!b)
								return true;
						}
					}
				}
			}
			return false;
		}

		//// RVA: 0x114CC6C Offset: 0x114CC6C VA: 0x114CC6C
		public static bool IsLiveSkillFilterOn(GCIJNCFDNON_SceneInfo scene, ulong flags)
		{
			if (flags == 0)
				return true;
			int id = scene.FILPDDHMKEJ_GetLiveSkillId(true, 0, 0);
			if(id != 0)
			{
				PPGHMBNIAEC skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[id - 1];
				for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.GAGNFDHGJGC.Count; i++)
				{
					DNIDPGDJCOG d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.GAGNFDHGJGC[i];
					ulong bit = (ulong)1 << d.MKDDOJOADMF;
					if ((bit & flags) != 0)
					{
						for(int j = 0; j < d.NNDGIAEFMOG.Count; j++)
						{
							FCNGHAJPMEA f = d.NNDGIAEFMOG[j];
							bool b = f.NEHDLDEHFCD != skill.FLJHGGKIOJH_SkillType;
							for(int k = 0; k < skill.EGLDFPILJLG_SkillBuffEffect.Length; k++)
							{
								if(skill.EGLDFPILJLG_SkillBuffEffect[k] != f.EGLDFPILJLG[k])
								{
									b = true;
									break;
								}
							}
							for (int k = 0; k < skill.FPMFEKIPFPI_DurationType.Length; k++)
							{
								if (skill.FPMFEKIPFPI_DurationType[k] != f.FPMFEKIPFPI[k])
								{
									b = true;
									break;
								}
							}
							bool b2 = skill.CEFHDLLAPDH_MusicIdCond > 0;
							if (f.CEFHDLLAPDH < 1)
								b2 = skill.CEFHDLLAPDH_MusicIdCond == 0;
							bool b3 = false;
							if(f.BHADMHLIFMM < 1)
							{
								b3 = false;
								TodoLogger.LogError(TodoLogger.ToCheck, "Check test");
								if(scene.AOLIJKMIJJE_DivaCompatible < 2)
								{
									b3 = true;
								}
							}
							else
							{
								b3 = f.BHADMHLIFMM < scene.AOLIJKMIJJE_DivaCompatible;
							}
							if (!(b || f.CPNAGMFCIJK != skill.CPNAGMFCIJK_TriggerType || !b2 || f.NFIBKOACELP != skill.NFIBKOACELP_Attr || b3))
								return true;
						}
					}
				}
			}
			return false;
		}

		//// RVA: 0x114D304 Offset: 0x114D304 VA: 0x114D304
		public static bool IsMusicLevelFilter(int levelMin, int levelMax, IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			int pt = musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].CIEOBFIIPLD;
			return pt >= levelMin && pt <= levelMax;
		}

		//// RVA: 0x114D450 Offset: 0x114D450 VA: 0x114D450
		public static bool IsAllRewardAchievedFilter(List<FPGEMAIAMBF_RewardData.LOIJICNJMKA> rewards)
		{
			foreach(var r in rewards)
			{
				if (r.CMCKNKKCNDK_Achieved == 0)
					return false;
			}
			return true;
		}

		//// RVA: 0x114BAFC Offset: 0x114BAFC VA: 0x114BAFC
		//private static bool IsFilterOn(int bitIndex, uint flags) { }

		//// RVA: 0x114C6FC Offset: 0x114C6FC VA: 0x114C6FC
		//private static bool IsFilterOn(int bitIndex, ulong flags) { }
	}
}
