using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

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
		//private AssistItem m_assistItem; // 0x20
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
		//public SortItem SortItem { get; set; } 0x1149B04 0x1149B0C 
		//public AssistItem AssistItem { get; set; } 0x1149B14 0x1149B1C
		public static List<SortItem> UnitSortItem { get { return UnitSortItemList; } } //0x1149B24 
		public static List<SortItem> UnitDivaSortItem { get { return UnitDivaSortItemList; } }  //0x1149BB0
		//public static List<SortItem> SceneSortItem { get; } 0x1149C3C
		//public static List<SortItem> MusicSelectSortItem { get; } 0x1149CC8
		//public static List<SortItem> ShopSortItem { get; } 0x1149D54
		
		//// RVA: 0x1149DE0 Offset: 0x1149DE0 VA: 0x1149DE0
		//public static string GetMsg_SortItem(SortItem a_item) { }

		//// RVA: 0x1149F0C Offset: 0x1149F0C VA: 0x1149F0C
		//public uint GetRarityFilter() { }

		//// RVA: 0x1149F14 Offset: 0x1149F14 VA: 0x1149F14
		//public uint GetAttributeFilter() { }

		//// RVA: 0x1149F1C Offset: 0x1149F1C VA: 0x1149F1C
		//public uint GetSeriaseFilter() { }

		//// RVA: 0x1149F24 Offset: 0x1149F24 VA: 0x1149F24
		//public uint GetCenterSkillFilter() { }

		//// RVA: 0x1149F2C Offset: 0x1149F2C VA: 0x1149F2C
		//public uint GetCompatibleFilter() { }

		//// RVA: 0x1149F34 Offset: 0x1149F34 VA: 0x1149F34
		//public uint GetInteriorFilter() { }

		//// RVA: 0x1149F3C Offset: 0x1149F3C VA: 0x1149F3C
		private void Awake()
		{
			TodoLogger.Log(0, "PopupSortMenu Awake");
		}

		//// RVA: 0x114A514 Offset: 0x114A514 VA: 0x114A514 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			TodoLogger.Log(0, "PopupSortMenu Initialize");
		}

		//// RVA: 0x114B054 Offset: 0x114B054 VA: 0x114B054 Slot: 18
		public bool IsScrollable()
		{
			TodoLogger.Log(0, "PopupSortMenu IsScrollable");
			return false;
		}

		//// RVA: 0x114AFBC Offset: 0x114AFBC VA: 0x114AFBC
		//private bool IsFriendSort() { }

		//// RVA: 0x114B08C Offset: 0x114B08C VA: 0x114B08C Slot: 19
		public void Show()
		{
			TodoLogger.Log(0, "PopupSortMenu Show");
		}

		//// RVA: 0x114B114 Offset: 0x114B114 VA: 0x114B114 Slot: 20
		public void Hide()
		{
			TodoLogger.Log(0, "PopupSortMenu Hide");
		}

		//// RVA: 0x114B14C Offset: 0x114B14C VA: 0x114B14C Slot: 21
		public bool IsReady()
		{
			TodoLogger.Log(0, "PopupSortMenu IsReady");
			return true;
		}

		//// RVA: 0x114B1EC Offset: 0x114B1EC VA: 0x114B1EC Slot: 22
		public void CallOpenEnd()
		{
			TodoLogger.Log(0, "PopupSortMenu CallOpenEnd");
		}

		//// RVA: 0x114B1F0 Offset: 0x114B1F0 VA: 0x114B1F0
		//private void OnChangeSort(int index) { }

		//// RVA: 0x114B2EC Offset: 0x114B2EC VA: 0x114B2EC
		//private void OnChangeAssist(int index) { }

		//// RVA: 0x114B2F4 Offset: 0x114B2F4 VA: 0x114B2F4
		//private void OnChangeRareFilter(uint bit) { }

		//// RVA: 0x114B2FC Offset: 0x114B2FC VA: 0x114B2FC
		//private void OnChangeAttributeFilter(uint bit) { }

		//// RVA: 0x114B304 Offset: 0x114B304 VA: 0x114B304
		//private void OnChangeSeriesFilter(uint bit) { }

		//// RVA: 0x114AFF8 Offset: 0x114AFF8 VA: 0x114AFF8
		//private uint ReverseSeriesBit(uint bit) { }

		//// RVA: 0x114B33C Offset: 0x114B33C VA: 0x114B33C
		//private void OnChangeCenterSkillFilter(uint bit) { }

		//// RVA: 0x114B344 Offset: 0x114B344 VA: 0x114B344
		//private void OnChangeCompatibleCheck(bool isOn) { }

		//// RVA: 0x114B34C Offset: 0x114B34C VA: 0x114B34C
		//private void OnChangeCompatibleDivaFilter(uint bit) { }

		//// RVA: 0x114B4C8 Offset: 0x114B4C8 VA: 0x114B4C8
		//private void OnChangeInteriorFilter(uint bit) { }

		//// RVA: 0x114B4D0 Offset: 0x114B4D0 VA: 0x114B4D0
		//public void ApplyLocalSaveData(ref ILDKBCLAFPB.IJDOCJCLAIL localSaveData) { }

		//// RVA: 0x114B9A0 Offset: 0x114B9A0 VA: 0x114B9A0
		//private void ApplyFriendSortParam(ILDKBCLAFPB.IJDOCJCLAIL.MMALELPFEBH friendProperty) { }

		//// RVA: 0x114BA5C Offset: 0x114BA5C VA: 0x114BA5C
		//public static bool IsHaveFilterOn(bool have, uint flags) { }

		//// RVA: 0x114BB20 Offset: 0x114BB20 VA: 0x114BB20
		//public static bool IsRarityFilterOn(int rare, uint flags) { }

		//// RVA: 0x114BBC4 Offset: 0x114BBC4 VA: 0x114BBC4
		public static bool IsAttributeFilterOn(int attr, uint flags)
		{
			if(flags != 0)
			{
				return (flags & 1) << (attr - 1) != 0;
			}
			return true;
		}

		//// RVA: 0x114BC68 Offset: 0x114BC68 VA: 0x114BC68
		public static bool IsSerializeFilterOn(int seriase, uint flags)
		{
			if(flags != 0)
			{
				return (flags & 1) << (seriase - 1) != 0;
			}
			return true;
		}

		//// RVA: 0x114BD0C Offset: 0x114BD0C VA: 0x114BD0C
		//public static bool IsCompatibleFilterOn(int divaBit, uint flags) { }

		//// RVA: 0x114BD28 Offset: 0x114BD28 VA: 0x114BD28
		//public static bool IsNotesFilterOn(int notes, uint flags) { }

		//// RVA: 0x114BD58 Offset: 0x114BD58 VA: 0x114BD58
		public static bool IsSkillRankFilterOn(int skillRank, int skillRank2, uint flags)
		{
			if(flags != 0)
			{
				return ((flags & 1) << skillRank - 1) != 0 || ((flags & 1) << skillRank2 - 1) != 0;
			}
			return true;
		}

		//// RVA: 0x114BD94 Offset: 0x114BD94 VA: 0x114BD94
		//public static bool IsSkillRankFilterOn(int skillRank, int skillRank2, uint flags, bool isCenterSkill, GCIJNCFDNON scene, EEDKAACNBBG musicData) { }

		//// RVA: 0x114BEEC Offset: 0x114BEEC VA: 0x114BEEC
		//public static bool IsSkillRangeFilterOn(int skillRange, uint flags) { }

		//// RVA: 0x114BF18 Offset: 0x114BF18 VA: 0x114BF18
		//public static bool IsInteriorTypeFilterOn(int interiorType, uint flags) { }

		//// RVA: 0x114BFBC Offset: 0x114BFBC VA: 0x114BFBC
		//public static bool IsCenterSkillFilterOn(GCIJNCFDNON scene, ulong flags) { }

		//// RVA: 0x114C748 Offset: 0x114C748 VA: 0x114C748
		//public static bool IsActiveSkillFilterOn(GCIJNCFDNON scene, ulong flags) { }

		//// RVA: 0x114CC6C Offset: 0x114CC6C VA: 0x114CC6C
		//public static bool IsLiveSkillFilterOn(GCIJNCFDNON scene, ulong flags) { }

		//// RVA: 0x114D304 Offset: 0x114D304 VA: 0x114D304
		//public static bool IsMusicLevelFilter(int levelMin, int levelMax, IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		//// RVA: 0x114D450 Offset: 0x114D450 VA: 0x114D450
		public static bool IsAllRewardAchievedFilter(List<FPGEMAIAMBF.LOIJICNJMKA> rewards)
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
