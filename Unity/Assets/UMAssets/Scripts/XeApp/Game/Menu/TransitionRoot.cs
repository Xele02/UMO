using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using XeApp.Game.Common;
using System;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public interface TransitionArgs
	{}

	public class TransitionRoot : MonoBehaviour
	{
		public class MenuTransitionControl
		{
			public enum TransitionType
			{
				None = 0,
				Move = 1,
				Call = 2,
				Return = 3,
				Mount = 4,
			}

			private struct LoadPlaceData
			{
				public TransitionList.Type from; // 0x0
				public TransitionList.Type to; // 0x4

				// RVA: 0x7FA7FC Offset: 0x7FA7FC VA: 0x7FA7FC
				public LoadPlaceData(TransitionList.Type from, TransitionList.Type to)
				{
					this.from = from;
					this.to = to;
				}
			}

			private struct TipsPlaceData
			{
				public TransitionList.Type from; // 0x0
				public TransitionList.Type to; // 0x4
				public byte count; // 0x8
				public MenuScene.MenuSceneCamebackInfo.CamBackUnityScene camBackUnityScene; // 0xC

				// RVA: 0x7FA808 Offset: 0x7FA808 VA: 0x7FA808
				public TipsPlaceData(TransitionList.Type from, TransitionList.Type to, byte count)
				{
					this.from = from;
					this.to = to;
					this.count = count;
					camBackUnityScene = MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None;
				}

				// RVA: 0x7FA820 Offset: 0x7FA820 VA: 0x7FA820
				public TipsPlaceData(TransitionList.Type from, TransitionList.Type to, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene camBackUnityScene, byte count)
				{
					this.from = from;
					this.to = to;
					this.count = count;
					this.camBackUnityScene = camBackUnityScene;
				}
			}

			public class BundleName : IComparable<BundleName>
			{

				public string bundlePath { get; private set; } // 0x8
				public string textureBundlePath { get; private set; } // 0xC
				public string prefabName { get; private set; } // 0x10

				// RVA: 0xA41DC0 Offset: 0xA41DC0 VA: 0xA41DC0
				private BundleName(string bundleName, string prefabName, string textureBundlePath)
				{
					this.bundlePath = bundleName;
					this.prefabName = prefabName;
					this.textureBundlePath = textureBundlePath;
				}

				// // RVA: 0xA38E6C Offset: 0xA38E6C VA: 0xA38E6C
				public static TransitionRoot.MenuTransitionControl.BundleName Create(string bundleName, string prefabName)
				{
					return new BundleName(bundleName, prefabName, string.Empty);
				}

				// // RVA: 0xA38F04 Offset: 0xA38F04 VA: 0xA38F04
				public static TransitionRoot.MenuTransitionControl.BundleName Create(string bundleName, string prefabName, string textureBundlePath)
				{
					return new BundleName(bundleName, prefabName, textureBundlePath);
				}

				// RVA: 0xA41DF0 Offset: 0xA41DF0 VA: 0xA41DF0 Slot: 4
				int System.IComparable<XeApp.Game.Menu.TransitionRoot.MenuTransitionControl.BundleName>.CompareTo(TransitionRoot.MenuTransitionControl.BundleName other)
				{
					return bundlePath.CompareTo(other.bundlePath);
				}
			}
			protected class PrefabSwitchInfo
			{
				public TransitionList.Type targetType { get; private set; } // 0x8
				public int thresholdMasterVersion { get; private set; } // 0xC
				public string prefabName { get; private set; } // 0x10

				// RVA: 0xA39FE0 Offset: 0xA39FE0 VA: 0xA39FE0
				public PrefabSwitchInfo(TransitionList.Type targetType, int masterVersion, string prefabName)
				{
					this.targetType = targetType;
					this.thresholdMasterVersion = masterVersion;
					this.prefabName = prefabName;
				}
			}


			private readonly string[] prefabName = new string[113] {
					"Menu/Prefab/UI_CommonMenu",
					"Menu/Prefab/UI_Title",
					"Menu/Prefab/UI_Home",
					"Menu/Prefab/UI_SeriesSelect",
					"Menu/Prefab/UI_StorySelect",
					"Menu/Prefab/UI_MusicSelect",
					"Layout/sel_list/UI_GuestList",
					"Menu/Prefab/UI_TeamSelect",
					"", "", "",
					"Debug/UI_DebugLiveCardSelect",
					"Menu/Prefab/UI_GuestList",
					"Layout/sel_list/UI_GuestList",
					"Menu/Prefab/UI_LoginBonus",
					"Menu/Prefab/UI_OptionMenu",
					"Debug/UI_DebugSceneSelect",
					"Menu/Prefab/UI_FrienMenu",
					"Menu/Prefab/UI_FriendList",
					"Menu/Prefab/UI_PresentList",
					"Layout/sel_card/DivaList",
					"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
					"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
					"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
					"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
					"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
				}; // 0x8
			private readonly TransitionRoot.MenuTransitionControl.BundleName[] assetBundleNames = new BundleName[113] {
					BundleName.Create("", ""),
					BundleName.Create("ly/000.xab", "UI_Title"),
					BundleName.Create("ly/006.xab", "UI_Home"),
					BundleName.Create("", ""),
					BundleName.Create("ly/011.xab", "UI_StorySelect"),
					BundleName.Create("ly/038.xab", "UI_MusicSelect"),
					BundleName.Create("ly/039.xab", "UI_GuestList"),
					BundleName.Create("ly/013.xab", "UI_CheckDeck"),
					BundleName.Create("ly/020.xab", "UI_Result"),
					BundleName.Create("", ""),
					BundleName.Create("ly/012.xab", "UI_SettingMenu"),
					BundleName.Create("", ""),
					BundleName.Create("ly/013.xab", "UI_SetDeck"),
					BundleName.Create("", ""),
					BundleName.Create("ly/001.xab", "UI_LoginBonus"),
					BundleName.Create("ly/009.xab", "UI_OptionMenu"),
					BundleName.Create("ly/014.xab", "UI_SceneSelectListWindow", "ly/tx/014.xab"),
					BundleName.Create("ly/054.xab", "UI_FriendMenuScene"),
					BundleName.Create("ly/039.xab", "UI_FriendList"),
					BundleName.Create("ly/039.xab", "UI_PresentList"),
					BundleName.Create("ly/014.xab", "UI_DivaList", "ly/tx/014.xab"),
					BundleName.Create("", ""),
					BundleName.Create("ly/014.xab", "UI_DivaSettingList", "ly/tx/014.xab"),
					BundleName.Create("ly/014.xab", "UI_SceneAbilityReleaseListWindow", "ly/tx/014.xab"),
					BundleName.Create("ly/066.xab", "UI_GachaList"),
					BundleName.Create("ly/067.xab", "UI_GachaMain"),
					BundleName.Create("", ""),
					BundleName.Create("ly/017.xab", "UI_DivaGrowth"),
					BundleName.Create("ly/019.xab", "UI_SceneGrowth"),
					BundleName.Create("ly/013.xab", "UI_DetailDeck", "ly/tx/013.xab"),
					BundleName.Create("ly/044.xab", "UI_CostumeSelect"),
					BundleName.Create("ly/129.xab", "UI_ValkyrieSelect"),
					BundleName.Create("ly/129.xab", "UI_ValkyrieViewMode"),
					BundleName.Create("ly/039.xab", "UI_RegularRankingList"),
					BundleName.Create("ly/039.xab", "UI_EventRankingList"),
					BundleName.Create("ly/044.xab", "UI_DivaViewMode"),
					BundleName.Create("ly/038.xab", "UI_EventMusicSelect"),
					BundleName.Create("ly/052.xab", "UI_EpisodeSelect"),
					BundleName.Create("ly/052.xab", "UI_EpisodeDetail"),
					BundleName.Create("ly/039.xab", "UI_EpisodeItemSelect"),
					BundleName.Create("ly/039.xab", "UI_FriendAcceptList"),
					BundleName.Create("ly/039.xab", "UI_FriendRequestList"),
					BundleName.Create("ly/039.xab", "UI_FriendSearch"),
					BundleName.Create("ly/059.xab", "UI_Quest"),
					BundleName.Create("ly/059.xab", "UI_QuestSelect"),
					BundleName.Create("ly/050.xab", "UI_SNS"),
					BundleName.Create("ly/071.xab", "UI_ProfilMenu"),
					BundleName.Create("ly/076.xab", "UI_DegreeSelectScene"),
					BundleName.Create("ly/038.xab", "UI_MissionEventScene"),
					BundleName.Create("", ""),
					BundleName.Create("", ""),
					BundleName.Create("ly/084.xab", "UI_UnlockDivaScene"),
					BundleName.Create("ly/085.xab", "UI_UnlockCostumeScene"),
					BundleName.Create("ly/086.xab", "UI_UnlockValkyrieScene"),
					BundleName.Create("ly/090.xab", "UI_HelpList"),
					BundleName.Create("ly/038.xab", "UI_EventBattle"),
					BundleName.Create("ly/013.xab", "UI_SimulationLiveDeck", "ly/tx/013.xab"),
					BundleName.Create("ly/105.xab", "UI_SimulationResultScene"),
					BundleName.Create("ly/106.xab", "UI_Shop"),
					BundleName.Create("ly/106.xab", "UI_ShopProduct"),
					BundleName.Create("ly/112.xab", "UI_NewYearEvent"),
					BundleName.Create("ly/113.xab", "UI_GachaBox"),
					BundleName.Create("ly/117.xab", "UI_EventStory"),
					BundleName.Create("", ""),
					BundleName.Create("ly/118.xab", "UI_GachaBox"),
					BundleName.Create("ly/119.xab", "UI_Campaign"),
					BundleName.Create("ly/120.xab", "UI_CampaignRoulette"),
					BundleName.Create("ly/123.xab", "UI_CheckNewCostume"),
					BundleName.Create("ly/124.xab", "UI_CheckNewValkyrie"),
					BundleName.Create("dr/ep/cmn.xab", "EpisodeAppealScene"),
					BundleName.Create("ly/117.xab", "UI_NewYearEventStory"),
					BundleName.Create("ly/128.xab", "UI_CostumeUpgrade"),
					BundleName.Create("ly/128.xab", "UI_CostumeUpgradeItemSelect"),
					BundleName.Create("ly/139.xab", "UI_offerSelectScene"),
					BundleName.Create("ly/140.xab", "UI_OfferFormationScene"),
					BundleName.Create("ly/141.xab", "UI_OfferTransformation"),
					BundleName.Create("ly/142.xab", "UI_OfferValkyrieSelect"),
					BundleName.Create("ly/145.xab", "UI_OfferResult"),
					BundleName.Create("ly/151.xab", "UI_BingoRewardSelectScene"),
					BundleName.Create("ly/152.xab", "UI_Bingo"),
					BundleName.Create("ly/199.xab", "UI_LobbyMainScene"),
					BundleName.Create("ly/199.xab", "UI_LobbyMissionScene"),
					BundleName.Create("ly/199.xab", "UI_LobbyGroupSelectScene"),
					BundleName.Create("", ""),
					BundleName.Create("", ""),
					BundleName.Create("ly/199.xab", "UI_LobbySelectGroupSearchScene"),
					BundleName.Create("ly/200.xab", "UI_RaidScene"),
					BundleName.Create("ly/201.xab", "UI_Decoration"),
					BundleName.Create("ly/205.xab", "UI_ValkyrieTuneUp"),
					BundleName.Create("ly/200.xab", "UI_RaidMvpCandidates"),
					BundleName.Create("ly/200.xab", "UI_RaidActSelect"),
					BundleName.Create("ly/200.xab", "UI_RaidReward"),
					BundleName.Create("ly/201.xab", "UI_DecorationBast"),
					BundleName.Create("ly/206.xab", "UI_DecoStampMaker"),
					BundleName.Create("ly/201.xab", "UI_DecorationVisitList"),
					BundleName.Create("ly/201.xab", "UI_DecorationStore"),
					BundleName.Create("ly/201.xab", "UI_DecorationBastStorage"),
					BundleName.Create("ly/200.xab", "UI_McrsCannon"),
					BundleName.Create("ly/199.xab", "UI_LobbyLobbyMembersListScene"),
					BundleName.Create("ly/201.xab", "UI_DecorationVisit"),
					BundleName.Create("ly/212.xab", "UI_DecoChatScene"),
					BundleName.Create("ly/039.xab", "UI_FriendBlockList"),
					BundleName.Create("ly/111.xab", "UI_MusicRateScene"),
					BundleName.Create("ly/155.xab", "UI_GachaMain2"),
					BundleName.Create("ly/014.xab", "UI_SceneAssistListWindow", "ly/tx/014.xab"),
					BundleName.Create("ly/014.xab", "UI_SceneHomeBgWindow", "ly/tx/014.xab"),
					BundleName.Create("", ""),
					BundleName.Create("ly/038.xab", "UI_EventGoDiva"),
					BundleName.Create("ly/013.xab", "UI_GoDivaCheckDeck", "ly/tx/013.xab"),
					BundleName.Create("ly/039.xab", "UI_DivaTotalRankingScene"),
					BundleName.Create("ly/013.xab", "UI_GoDivaDetailDeck"),
					BundleName.Create("ly/081.xab", "UI_GakuyaScene"),
					BundleName.Create("ly/081.xab", "UI_GakuyaDivaViewScene")
				}; // 0xC
			private List<TransitionRoot.MenuTransitionControl.PrefabSwitchInfo> prefabSwitchTable = new List<PrefabSwitchInfo>(); // 0x10
			private static readonly int[] sceneGroupCategoryBgmId = new int[20] {
				BgmPlayer.MENU_BGM_ID_BASE + 2,
				BgmPlayer.MENU_BGM_ID_BASE,
				BgmPlayer.MENU_BGM_ID_BASE,
				BgmPlayer.MENU_BGM_ID_BASE + 1,
				BgmPlayer.MENU_BGM_ID_BASE + 3,
				BgmPlayer.MENU_BGM_ID_BASE,
				BgmPlayer.MENU_BGM_ID_BASE + 10,
				BgmPlayer.MENU_BGM_ID_BASE + 6,
				BgmPlayer.MENU_BGM_ID_BASE + 7,
				BgmPlayer.MENU_BGM_ID_BASE,
				BgmPlayer.MENU_BGM_ID_BASE + 5,
				BgmPlayer.MENU_BGM_ID_BASE + 8,
				BgmPlayer.MENU_BGM_ID_BASE,
				BgmPlayer.MENU_BGM_ID_BASE + 7,
				BgmPlayer.MENU_BGM_ID_BASE + 24,
				BgmPlayer.MENU_BGM_ID_BASE + 26,
				BgmPlayer.MENU_BGM_ID_BASE + 27,
				BgmPlayer.MENU_BGM_ID_BASE,
				BgmPlayer.MENU_BGM_ID_BASE,
				BgmPlayer.MENU_BGM_ID_BASE + 25
			} ; // 0x0
			private BgControl m_bgControl; // 0x14
			private MenuFooterControl m_menuBarControl; // 0x18
			private MenuHeaderControl m_titleBarControl; // 0x1C
			private GameObject m_uiRootObject; // 0x20
			private Font m_font; // 0x24
			// private HelpButton m_helpButton; // 0x28
			// private SceneStack m_transitionStack = new SceneStack(); // 0x2C
			// private TransitionRoot m_currentRoot; // 0x30
			// private TransitionInfo m_current = new TransitionInfo(); // 0x34
			// private TransitionInfo m_next; // 0x38
			// private TransitionRoot.MenuTransitionControl.TransitionType m_transitionType; // 0x3C
			// private bool m_isRequestSave; // 0x40
			// private bool m_remainDivaOneTimeFlag; // 0x41
			// private bool m_isStoryNewIconCashe; // 0x42
			// private IndexableDictionary<int, TransitionRoot> m_instanceCacheDict = new IndexableDictionary<int, TransitionRoot>(0); // 0x44
			// private Dictionary<SceneGroupCategory, MenuButtonAnim.ButtonType> m_groupCategoryButtonTypeMap = new Dictionary<SceneGroupCategory, MenuButtonAnim.ButtonType>() {
			//	{ 2, 0 }, { 3, 1}, {4, 0}, {19, 2}, { 5, 3}, { 6, 4}, { 7, 6 }, { 10, 5 }, { 11, 3 }, { 9, 3 }, {12, 3 }, { 18, 3}
			//}; // 0x48
			// [CompilerGeneratedAttribute] // RVA: 0x66A020 Offset: 0x66A020 VA: 0x66A020
			// private bool <DirtyChangeScene>k__BackingField; // 0x4C
			// [CompilerGeneratedAttribute] // RVA: 0x66A030 Offset: 0x66A030 VA: 0x66A030
			// private bool <IsTransition>k__BackingField; // 0x4D
			// [CompilerGeneratedAttribute] // RVA: 0x66A040 Offset: 0x66A040 VA: 0x66A040
			// private bool <StopTransition>k__BackingField; // 0x4E
			// private List<NewMarkIcon> m_newMarkIconList = new List<NewMarkIcon>(32); // 0x50
			// [CompilerGeneratedAttribute] // RVA: 0x66A050 Offset: 0x66A050 VA: 0x66A050
			public UnityAction<SceneGroupCategory, SceneGroupCategory> ChangeGroupCategoryListener; // 0x54
			private TransitionTreeObject treeObject; // 0x58
			// private List<TransitionList.Type> m_enableDivaModelTransitionName = new List<TransitionList.Type>() {
			//	14, 2, 105, 8, 35, 111, 112
			//}; // 0x5C
			// private List<TransitionList.Type> m_notAutoLoadDiva = new List<TransitionList.Type>() { 30, 35 }; // 0x60
			// private Dictionary<TransitionList.Type, float[]> m_divaAdjustPosition = new Dictionary<TransitionList.Type, float[]>() {
			//	{ 12, new float[2] {1.0f, 1.5f} }
			//}; // 0x64
			// private Dictionary<TransitionList.Type, Vector3> m_divaCameraRotation = new Dictionary<TransitionList.Type, Vector3>() {
				// { -2, new Vector3(0, -170, 0) },
				// { 2, new Vector3(0, -180, 0) },
				// { 105, new Vector3(0, -180, 0) },
				// { 111, new Vector3( 0, -178, 0 ) },
				// { 112, new Vector3(0, -178, 0) }
			// }; // 0x68
			// private readonly float[] m_baseAspect = new float[2] { 1.777778f, 1.333333f }; // 0x6C
			private static readonly TransitionRoot.MenuTransitionControl.LoadPlaceData[] loadPlaceList = new LoadPlaceData[16] {
				new LoadPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.COSTUME_SELECT),
				new LoadPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.VALKYRIE_SELECT),
				new LoadPlaceData(TransitionList.Type.SETTING_MENU, TransitionList.Type.VALKYRIE_TUNEUP),
				new LoadPlaceData(TransitionList.Type.HOME, TransitionList.Type.RAID),
				new LoadPlaceData(TransitionList.Type.LOBBY_MAIN, TransitionList.Type.RAID),
				new LoadPlaceData(TransitionList.Type.MUSIC_SELECT, TransitionList.Type.RAID),
				new LoadPlaceData(TransitionList.Type.QUEST_SELECT, TransitionList.Type.RAID),
				new LoadPlaceData(TransitionList.Type.RAID, TransitionList.Type.HOME),
				new LoadPlaceData(TransitionList.Type.HOME, TransitionList.Type.LOBBY_MAIN),
				new LoadPlaceData(TransitionList.Type.DECO, TransitionList.Type.LOBBY_MAIN),
				new LoadPlaceData(TransitionList.Type.RAID, TransitionList.Type.LOBBY_MAIN),
				new LoadPlaceData(TransitionList.Type.MUSIC_SELECT, TransitionList.Type.LOBBY_MAIN),
				new LoadPlaceData(TransitionList.Type.LOBBY_GROUP_SELECT, TransitionList.Type.LOBBY_MAIN),
				new LoadPlaceData(TransitionList.Type.LOBBY_MAIN, TransitionList.Type.HOME),
				new LoadPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.DECO),
				new LoadPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.DECO_VISIT)
			}; // 0x4
			private static readonly TransitionRoot.MenuTransitionControl.TipsPlaceData[] tipsPlaceList = new TipsPlaceData[40] {
				new TipsPlaceData(TransitionList.Type.LOGIN_BONUS, TransitionList.Type.HOME, 3),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.LOGIN_BONUS, 3),
				new TipsPlaceData(TransitionList.Type.PRESENT_LIST, TransitionList.Type.HOME, 0),
				new TipsPlaceData(TransitionList.Type.FRIEND_MENU, TransitionList.Type.HOME, 0),
				new TipsPlaceData(TransitionList.Type.TEAM_SELECT, TransitionList.Type.STORY_SELECT, 0),
				new TipsPlaceData(TransitionList.Type.UNLOCK_COSTUME, TransitionList.Type.QUEST, 0),
				new TipsPlaceData(TransitionList.Type.UNLOCK_COSTUME, TransitionList.Type.QUEST_SELECT, 0),
				new TipsPlaceData(TransitionList.Type.GACHA_CHECK_NEW_COSTUME, TransitionList.Type.GACHA_2, 0),
				new TipsPlaceData(TransitionList.Type.GACHA_CHECK_NEW_VALKYRIE, TransitionList.Type.GACHA_2, 0),
				new TipsPlaceData(TransitionList.Type.MUSIC_SELECT, TransitionList.Type.EVENT_MUSIC_SELECT, 0),
				new TipsPlaceData(TransitionList.Type.MUSIC_SELECT, TransitionList.Type.EVENT_QUEST, 0),
				new TipsPlaceData(TransitionList.Type.MUSIC_SELECT, TransitionList.Type.EVENT_BATTLE, 0),
				new TipsPlaceData(TransitionList.Type.EVENT_MUSIC_SELECT, TransitionList.Type.MUSIC_SELECT, 0),
				new TipsPlaceData(TransitionList.Type.EVENT_QUEST, TransitionList.Type.MUSIC_SELECT, 0),
				new TipsPlaceData(TransitionList.Type.EVENT_BATTLE, TransitionList.Type.MUSIC_SELECT, 0),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.EVENT_MUSIC_SELECT, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.Adv, 0),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.EVENT_QUEST, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.Adv, 0),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.EVENT_BATTLE, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.Adv, 0),
				new TipsPlaceData(TransitionList.Type.VALKYRIE_TUNEUP, TransitionList.Type.SETTING_MENU, 0),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.HOME, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.SETTING_MENU, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.VALKYRIE_SELECT, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.COSTUME_SELECT, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.STORY_SELECT, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.MUSIC_SELECT, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.GACHA_2, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.OPTION_MENU, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.QUEST, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.EVENT_MUSIC_SELECT, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.EVENT_QUEST, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.EVENT_BATTLE, 1),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.VALKYRIE_TUNEUP, 1),
				new TipsPlaceData(TransitionList.Type.QUEST, TransitionList.Type.EPISODE_SELECT, 1),
				new TipsPlaceData(TransitionList.Type.QUEST, TransitionList.Type.SCENE_ABILITY_RELEASE_LIST, 1),
				new TipsPlaceData(TransitionList.Type.QUEST, TransitionList.Type.TEAM_EDIT, 1),
				new TipsPlaceData(TransitionList.Type.QUEST, TransitionList.Type.PRESENT_LIST, 1),
				new TipsPlaceData(TransitionList.Type.RAID_ACT_SELECT, TransitionList.Type.RAID, 0),
				new TipsPlaceData(TransitionList.Type.UNDEFINED, TransitionList.Type.RAID, 1),
				new TipsPlaceData(TransitionList.Type.RAID, TransitionList.Type.LOBBY_MAIN, 1),
				new TipsPlaceData(TransitionList.Type.RAID, TransitionList.Type.MUSIC_SELECT, 1)
			}; // 0x8
			// private Dictionary<int, TransitionRoot.MenuTransitionControl.CacheCategory> CacheDictionary = new Dictionary<int, TransitionRoot.MenuTransitionControl.CacheCategory>() {
			// 	{ 0, new CacheCategory() { m_category = 0, m_sceneName = new TransitionList.Type[1] { 1 } } },
			// 	{ 1, new CacheCategory() { m_category = 1, m_sceneName = new TransitionList.Type[1] { 14 } } },
			// 	{ 2, new CacheCategory() { m_category = 2, m_sceneName = new TransitionList.Type[14] { 729A3B652FA78347219ADB86867340A3872A98B3 } } },
			// 	{ 3, new CacheCategory() { m_category = 3, m_sceneName = new TransitionList.Type[19] { EE61DEC5FB4E6F251027AB466EC7789F53C7B3B4 } } },
			// 	{ 4, new CacheCategory() { m_category = 4, m_sceneName = new TransitionList.Type[20] { C4B8254896B2C024CE5B7376E873D418D2F90178 } } },
			// 	{ 5, new CacheCategory() { m_category = 5, m_sceneName = new TransitionList.Type[23] { 0A788BCB4AC0564BC8139E9BC6B4934F985CC49E } } },
			// 	{ 7, new CacheCategory() { m_category = 7, m_sceneName = new TransitionList.Type[4] { BE1A05888053C30C2BB7FF3B3582E7C0C5950699 } } },
			// 	{ 8, new CacheCategory() { m_category = 8, m_sceneName = new TransitionList.Type[1] { 8 } } },
			// 	{ 6, new CacheCategory() { m_category = 6, m_sceneName = new TransitionList.Type[1] { 103 } } },
			// 	{ 9, new CacheCategory() { m_category = 9, m_sceneName = new TransitionList.Type[2] { 43, 44 } } },
			// 	{ 11, new CacheCategory() { m_category = 11, m_sceneName = new TransitionList.Type[2] { 87, 87 } } }
			// }; // 0x70

			// // Properties
			// public bool DirtyChangeScene { get; set; }
			// public bool IsTransition { get; set; }
			// public bool StopTransition { get; set; }
			// public MenuHeaderControl MenuHeader { get; }
			// public MenuFooterControl MenuFooter { get; }
			// public HelpButton HelpButton { get; }
			// private List<TransitionTreeObject.SceneRoot> SceneDirectory { get; }
			// public BgControl bgControl { get; }

			// // Methods

			// [CompilerGeneratedAttribute] // RVA: 0x6C8AEC Offset: 0x6C8AEC VA: 0x6C8AEC
			// // RVA: 0xA31458 Offset: 0xA31458 VA: 0xA31458
			// public bool get_DirtyChangeScene() { }

			// [CompilerGeneratedAttribute] // RVA: 0x6C8AFC Offset: 0x6C8AFC VA: 0x6C8AFC
			// // RVA: 0xA31460 Offset: 0xA31460 VA: 0xA31460
			// private void set_DirtyChangeScene(bool value) { }

			// [CompilerGeneratedAttribute] // RVA: 0x6C8B0C Offset: 0x6C8B0C VA: 0x6C8B0C
			// // RVA: 0xA31468 Offset: 0xA31468 VA: 0xA31468
			// public bool get_IsTransition() { }

			// [CompilerGeneratedAttribute] // RVA: 0x6C8B1C Offset: 0x6C8B1C VA: 0x6C8B1C
			// // RVA: 0xA31470 Offset: 0xA31470 VA: 0xA31470
			// private void set_IsTransition(bool value) { }

			// [CompilerGeneratedAttribute] // RVA: 0x6C8B2C Offset: 0x6C8B2C VA: 0x6C8B2C
			// // RVA: 0xA31478 Offset: 0xA31478 VA: 0xA31478
			// public bool get_StopTransition() { }

			// [CompilerGeneratedAttribute] // RVA: 0x6C8B3C Offset: 0x6C8B3C VA: 0x6C8B3C
			// // RVA: 0xA31480 Offset: 0xA31480 VA: 0xA31480
			// public void set_StopTransition(bool value) { }

			// // RVA: 0xA31488 Offset: 0xA31488 VA: 0xA31488
			// public MenuHeaderControl get_MenuHeader() { }

			// // RVA: 0xA31490 Offset: 0xA31490 VA: 0xA31490
			// public MenuFooterControl get_MenuFooter() { }

			// // RVA: 0xA31498 Offset: 0xA31498 VA: 0xA31498
			// public HelpButton get_HelpButton() { }

			// [CompilerGeneratedAttribute] // RVA: 0x6C8B4C Offset: 0x6C8B4C VA: 0x6C8B4C
			// // RVA: 0xA314A0 Offset: 0xA314A0 VA: 0xA314A0
			// public void add_ChangeGroupCategoryListener(UnityAction<SceneGroupCategory, SceneGroupCategory> value) { }

			// [CompilerGeneratedAttribute] // RVA: 0x6C8B5C Offset: 0x6C8B5C VA: 0x6C8B5C
			// // RVA: 0xA315AC Offset: 0xA315AC VA: 0xA315AC
			// public void remove_ChangeGroupCategoryListener(UnityAction<SceneGroupCategory, SceneGroupCategory> value) { }

			// // RVA: 0xA316B8 Offset: 0xA316B8 VA: 0xA316B8
			// private List<TransitionTreeObject.SceneRoot> get_SceneDirectory() { }

			// // RVA: 0xA316E4 Offset: 0xA316E4 VA: 0xA316E4
			public MenuTransitionControl(GameObject bgRoot, GameObject uiRoot, Font font, TransitionTreeObject tto)
			{
				m_bgControl = new BgControl(bgRoot);
				m_titleBarControl = new MenuHeaderControl(uiRoot);
				m_menuBarControl = new MenuFooterControl(uiRoot);
				m_uiRootObject = uiRoot;
				m_font = font;
				treeObject = tto;
			}

			// // RVA: 0xA38FFC Offset: 0xA38FFC VA: 0xA38FFC
			// public void Move(SceneGroupCategory category, TransitionList.Type nextTransition, TransitionArgs args, bool isFading = True) { }

			// // RVA: 0xA39000 Offset: 0xA39000 VA: 0xA39000
			// public void Mount(TransitionUniqueId uniqueId, TransitionArgs args, bool isFading = True, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene cambackUnityScene = 0) { }

			// // RVA: 0xA39334 Offset: 0xA39334 VA: 0xA39334
			// public void MountWithFade(TransitionUniqueId uniqueId, TransitionArgs args, bool isFading = True, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene cambackUnityScene = 0) { }

			// // RVA: 0xA39364 Offset: 0xA39364 VA: 0xA39364
			// public void Call(TransitionList.Type next, TransitionArgs args, bool isFading = True) { }

			// // RVA: 0xA3966C Offset: 0xA3966C VA: 0xA3966C
			// public void Return(bool isFading = True) { }

			// // RVA: 0xA39384 Offset: 0xA39384 VA: 0xA39384
			// private void ChangeCall(TransitionList.Type nextTransition, bool isFading = True, TransitionArgs args) { }

			// // RVA: 0xA39030 Offset: 0xA39030 VA: 0xA39030
			// private void ChangeMount(TransitionUniqueId uniqueId, bool isFading = True, TransitionArgs args, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene camBackUnityScene = 0, bool isForceFading = False) { }

			// // RVA: 0xA396F4 Offset: 0xA396F4 VA: 0xA396F4
			// private TransitionTreeObject.SceneTree FindTransitionTree(TransitionTreeObject.SceneRoot root, Func<TransitionTreeObject.SceneTree, bool> comp) { }

			// // RVA: 0xA399CC Offset: 0xA399CC VA: 0xA399CC
			// public GameObject GetCurrentBg() { }

			// // RVA: 0xA399F8 Offset: 0xA399F8 VA: 0xA399F8
			// public BgControl get_bgControl() { }

			// // RVA: 0xA39A00 Offset: 0xA39A00 VA: 0xA39A00
			// public TransitionInfo GetCurrentScene() { }

			// // RVA: 0xA39A08 Offset: 0xA39A08 VA: 0xA39A08
			// public TransitionInfo GetNextScene() { }

			// // RVA: 0xA39A10 Offset: 0xA39A10 VA: 0xA39A10
			// public TransitionRoot GetCurrentTransitionRoot() { }

			// // RVA: 0xA39A18 Offset: 0xA39A18 VA: 0xA39A18
			// public bool OnPushReturnButton() { }

			// // RVA: 0xA39A4C Offset: 0xA39A4C VA: 0xA39A4C
			// public void ClearDirtyChangeScene() { }

			// // RVA: 0xA39A58 Offset: 0xA39A58 VA: 0xA39A58
			// public int GetDefaultBgmId(SceneGroupCategory category) { }

			// [IteratorStateMachineAttribute] // RVA: 0x6C8B6C Offset: 0x6C8B6C VA: 0x6C8B6C
			// // RVA: 0xA39B1C Offset: 0xA39B1C VA: 0xA39B1C
			// public IEnumerator Initialize(MonoBehaviour mb, UnityAction action) { }

			// [IteratorStateMachineAttribute] // RVA: 0x6C8BE4 Offset: 0x6C8BE4 VA: 0x6C8BE4
			// // RVA: 0xA39BFC Offset: 0xA39BFC VA: 0xA39BFC
			// private IEnumerator Co_LoadHelpButton(UnityAction finish) { }

			// // RVA: 0xA39CC4 Offset: 0xA39CC4 VA: 0xA39CC4
			// private void SetupPrefabSwitchTable() { }

			// [IteratorStateMachineAttribute] // RVA: 0x6C8C5C Offset: 0x6C8C5C VA: 0x6C8C5C
			// // RVA: 0xA3A010 Offset: 0xA3A010 VA: 0xA3A010
			// private IEnumerator DeleteCache(SceneCacheCategory cacheCategory) { }

			// [IteratorStateMachineAttribute] // RVA: 0x6C8CD4 Offset: 0x6C8CD4 VA: 0x6C8CD4
			// // RVA: 0xA3A0BC Offset: 0xA3A0BC VA: 0xA3A0BC
			// private IEnumerator RegisterCache(SceneCacheCategory cacheCategory, TransitionList.Type transitionName) { }

			// [IteratorStateMachineAttribute] // RVA: 0x6C8D4C Offset: 0x6C8D4C VA: 0x6C8D4C
			// // RVA: 0xA3A184 Offset: 0xA3A184 VA: 0xA3A184
			// public IEnumerator ExitTransition() { }

			// [IteratorStateMachineAttribute] // RVA: 0x6C8DC4 Offset: 0x6C8DC4 VA: 0x6C8DC4
			// // RVA: 0xA3A230 Offset: 0xA3A230 VA: 0xA3A230
			// public IEnumerator DestroyTransion() { }

			// [IteratorStateMachineAttribute] // RVA: 0x6C8E3C Offset: 0x6C8E3C VA: 0x6C8E3C
			// // RVA: 0xA3A2DC Offset: 0xA3A2DC VA: 0xA3A2DC
			// public IEnumerator ChangeTransition() { }

			// // RVA: 0xA3A388 Offset: 0xA3A388 VA: 0xA3A388
			// private string GetPrefabName(TransitionList.Type transitionName) { }

			// // RVA: 0xA3A56C Offset: 0xA3A56C VA: 0xA3A56C
			// private bool TryGetRoot(SceneCacheCategory category, TransitionList.Type name, out TransitionRoot root) { }

			// // RVA: 0xA3A5F4 Offset: 0xA3A5F4 VA: 0xA3A5F4
			// private float CalcDivaPositionX(float min, float max) { }

			// // RVA: 0xA3A708 Offset: 0xA3A708 VA: 0xA3A708
			// private bool IsShiftIdleAnimation(TransitionList.Type current, TransitionList.Type next) { }

			// // RVA: 0xA3A754 Offset: 0xA3A754 VA: 0xA3A754
			// private bool RevivalStack(TransitionTreeObject.SceneRoot root, TransitionTreeObject.SceneTree tree, TransitionUniqueId uniqueId) { }

			// // RVA: 0xA3AC58 Offset: 0xA3AC58 VA: 0xA3AC58
			// private void RevivalStack() { }

			// // RVA: 0xA3ADFC Offset: 0xA3ADFC VA: 0xA3ADFC
			// public static void UpdateMenuNewIcon(TransitionList.Type nextTransition, TransitionList.Type prevTransition) { }

			// // RVA: 0xA3B1C0 Offset: 0xA3B1C0 VA: 0xA3B1C0
			// public void SetFooterMenuButtonDisable(MenuFooterControl.Button button) { }

			// // RVA: 0xA3B1F4 Offset: 0xA3B1F4 VA: 0xA3B1F4
			// public void SetFooterMenuButtonEnable(MenuFooterControl.Button button) { }

			// // RVA: 0xA3B228 Offset: 0xA3B228 VA: 0xA3B228
			// public void SetMenuContentButtonEnable() { }

			// // RVA: 0xA3B300 Offset: 0xA3B300 VA: 0xA3B300
			// public void SetHeaderMenuButtonDisable(MenuHeaderControl.Button button) { }

			// // RVA: 0xA3B334 Offset: 0xA3B334 VA: 0xA3B334
			// public void SetHeaderMenuButtonEnable(MenuHeaderControl.Button button) { }

			// // RVA: 0xA3B368 Offset: 0xA3B368 VA: 0xA3B368
			// public void SetMenuContentButtonDisable() { }

			// // RVA: 0xA3B440 Offset: 0xA3B440 VA: 0xA3B440
			// public void SetHelpButtonEnable() { }

			// // RVA: 0xA3B4F4 Offset: 0xA3B4F4 VA: 0xA3B4F4
			// public void SetHelpButtonDisable() { }

			// // RVA: 0xA3B5A8 Offset: 0xA3B5A8 VA: 0xA3B5A8
			// public void ApplyPlayerStatus(IFBCGCCJBHI playerStatus) { }

			// // RVA: 0xA3B5DC Offset: 0xA3B5DC VA: 0xA3B5DC
			// public void SaveRequest() { }

			// // RVA: 0xA3B688 Offset: 0xA3B688 VA: 0xA3B688
			// public void RemainDivaOneTime() { }

			// // RVA: 0xA3B694 Offset: 0xA3B694 VA: 0xA3B694
			// public void SaveStack(SceneStack stack) { }

			// // RVA: 0xA3B6C8 Offset: 0xA3B6C8 VA: 0xA3B6C8
			// public void LoadStack(SceneStack stack) { }

			// // RVA: 0xA3B6FC Offset: 0xA3B6FC VA: 0xA3B6FC
			// public void PushStack() { }

			// // RVA: 0xA3B9A0 Offset: 0xA3B9A0 VA: 0xA3B9A0
			// private void OnChangeGroupCategory(SceneGroupCategory prevCategory, SceneGroupCategory nextCategory) { }

			// // RVA: 0xA3BA1C Offset: 0xA3BA1C VA: 0xA3BA1C
			// public Vector3 GetDivaCameraRotByScene(TransitionList.Type type) { }

			// // RVA: 0xA3BB18 Offset: 0xA3BB18 VA: 0xA3BB18
			// public bool CanShowNowLoading(TransitionList.Type from, TransitionList.Type to) { }

			// // RVA: 0xA3BDA4 Offset: 0xA3BDA4 VA: 0xA3BDA4
			public bool CanShowTips(TransitionList.Type from, TransitionList.Type to, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene camBackUnityScene, out int count)
			{
				count = 0;
				UnityEngine.Debug.LogError("TODO");
				return false;
			}

			// [CompilerGeneratedAttribute] // RVA: 0x6C8EB4 Offset: 0x6C8EB4 VA: 0x6C8EB4
			// // RVA: 0xA3D408 Offset: 0xA3D408 VA: 0xA3D408
			// private void <Co_LoadHelpButton>b__72_0(GameObject instance) { }
		}

		public const float FADE_TIME = 0.1f;
		public TransitionList.Type m_transitionName; // 0xC
		private GameObject m_bgRoot; // 0x10
		private TransitionArgs m_args; // 0x14
		private TransitionArgs m_args_return; // 0x18
		private TransitionList.Type m_prevTransition; // 0x1C
		private TransitionList.Type m_parentTransition; // 0x20
		private TransitionRoot.MenuTransitionControl.TransitionType m_transitionType; // 0x24
		private Graphic[] m_graphicObjects; // 0x2C
		private List<ButtonBase> m_buttons = new List<ButtonBase>(32); // 0x30
		private List<ScrollRect> m_scrollRect = new List<ScrollRect>(32); // 0x34
		private List<SwaipTouch> m_swaipTouches = new List<SwaipTouch>(3); // 0x38
		private Canvas[] m_canvases; // 0x3C
		private int m_inputStateCount; // 0x40
		private bool m_isAutoFade = true; // 0x44

		// public TransitionList.Type TransitionName { get; } 0xA7FEC0
		// public GameObject bgRoot { get; set; } 0xA9D73C 0xA9D744
		// public TransitionArgs Args { get; set; } 0xA83E84 0xA9D74C
		// public TransitionArgs ArgsReturn { get; set; } 0xA9D754 0xA9D75C
		// public TransitionList.Type PrevTransition { get; } 0xA7FEC8
		// public TransitionList.Type ParentTransition { get; } 0xA9D764
		// public TransitionRoot.MenuTransitionControl.TransitionType TransitionType { get; } 0xA9D76C
		// public bool IsRequestGotoTitle { get; set; } // 0x28
		// public bool IsReady { get; protected set; } // 0x29
		// public int InputStateCount { get; } 0xA9D78C
		// public bool AutoFadeFlag { get; set; } 0xA9D794 0xA9D79C

		// RVA: 0xA80A84 Offset: 0xA80A84 VA: 0xA80A84 Slot: 4
		protected virtual void Awake()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// RVA: 0xA80B40 Offset: 0xA80B40 VA: 0xA80B40 Slot: 5
		protected virtual void Start()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// RVA: 0xA9D7A4 Offset: 0xA9D7A4 VA: 0xA9D7A4 Slot: 6
		protected virtual void OnEnable()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// RVA: 0xA9D7A8 Offset: 0xA9D7A8 VA: 0xA9D7A8 Slot: 7
		protected virtual void OnDisable()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xA9D7AC Offset: 0xA9D7AC VA: 0xA9D7AC Slot: 8
		// protected virtual void OnStartEnterTitleHeader() { }

		// // RVA: 0xA9D7B0 Offset: 0xA9D7B0 VA: 0xA9D7B0 Slot: 9
		// protected virtual void OnStartEnterAnimation() { }

		// // RVA: 0xA9D7B4 Offset: 0xA9D7B4 VA: 0xA9D7B4 Slot: 10
		// protected virtual bool IsEndEnterAnimation() { }

		// // RVA: 0xA9D7BC Offset: 0xA9D7BC VA: 0xA9D7BC Slot: 11
		// protected virtual void OnStartExitTitleHeader() { }

		// // RVA: 0xA9D7C0 Offset: 0xA9D7C0 VA: 0xA9D7C0 Slot: 12
		// protected virtual void OnStartExitAnimation() { }

		// // RVA: 0xA9D7C4 Offset: 0xA9D7C4 VA: 0xA9D7C4 Slot: 13
		// protected virtual bool IsEndExitAnimation() { }

		// // RVA: 0xA9D7CC Offset: 0xA9D7CC VA: 0xA9D7CC Slot: 14
		// protected virtual void OnDestoryScene() { }

		// // RVA: 0xA9D7D0 Offset: 0xA9D7D0 VA: 0xA9D7D0 Slot: 15
		// protected virtual void OnDeleteCache() { }

		// // RVA: 0xA9D7D4 Offset: 0xA9D7D4 VA: 0xA9D7D4 Slot: 16
		// protected virtual void OnPreSetCanvas() { }

		// // RVA: 0xA8553C Offset: 0xA8553C VA: 0xA8553C Slot: 17
		// protected virtual bool IsEndPreSetCanvas() { }

		// // RVA: 0xA9D7D8 Offset: 0xA9D7D8 VA: 0xA9D7D8 Slot: 18
		// protected virtual void OnPostSetCanvas() { }

		// // RVA: 0xA85780 Offset: 0xA85780 VA: 0xA85780 Slot: 19
		// protected virtual bool IsEndPostSetCanvas() { }

		// // RVA: 0xA9D7DC Offset: 0xA9D7DC VA: 0xA9D7DC Slot: 20
		// protected virtual bool OnBgmStart() { }

		// // RVA: 0xA9D7E4 Offset: 0xA9D7E4 VA: 0xA9D7E4 Slot: 21
		// protected virtual void OnOpenScene() { }

		// // RVA: 0xA9D7E8 Offset: 0xA9D7E8 VA: 0xA9D7E8 Slot: 22
		// protected virtual bool IsEndOpenScene() { }

		// // RVA: 0xA9D7F0 Offset: 0xA9D7F0 VA: 0xA9D7F0 Slot: 23
		// protected virtual void OnActivateScene() { }

		// // RVA: 0xA9D7F4 Offset: 0xA9D7F4 VA: 0xA9D7F4 Slot: 24
		// protected virtual bool IsEndActivateScene() { }

		// // RVA: 0xA9D7FC Offset: 0xA9D7FC VA: 0xA9D7FC Slot: 25
		// protected virtual void OnTutorial() { }

		// // RVA: 0xA9D800 Offset: 0xA9D800 VA: 0xA9D800 Slot: 26
		// protected virtual bool OnPushReturnButton() { }

		// // RVA: 0xA9D808 Offset: 0xA9D808 VA: 0xA9D808 Slot: 27
		// protected virtual TransitionArgs GetCallArgs() { }

		// // RVA: 0xA917EC Offset: 0xA917EC VA: 0xA917EC Slot: 28
		// protected virtual TransitionArgs GetCallArgsReturn() { }

		// // RVA: 0xA9D810 Offset: 0xA9D810 VA: 0xA9D810
		// protected void GotoTitle() { }

		// // RVA: 0xA9D81C Offset: 0xA9D81C VA: 0xA9D81C Slot: 29
		// protected virtual void InputEnable() { }

		// // RVA: 0xA9DD34 Offset: 0xA9DD34 VA: 0xA9DD34
		// public void InputEnable(string objName, string parentName = "") { }

		// // RVA: 0xA9E600 Offset: 0xA9E600 VA: 0xA9E600
		// public ButtonBase FindButton(string objName, string parentName = "") { }

		// // RVA: 0xA9E728 Offset: 0xA9E728 VA: 0xA9E728
		// private bool ObjectFindFunc(Transform ts, string name, string parentName) { }

		// // RVA: 0xA9E8B4 Offset: 0xA9E8B4 VA: 0xA9E8B4 Slot: 30
		// protected virtual void InputDisable() { }

		// // RVA: 0xA9ED10 Offset: 0xA9ED10 VA: 0xA9ED10
		// public void InputDisable(string objName) { }

		// // RVA: 0xA9F5B0 Offset: 0xA9F5B0 VA: 0xA9F5B0
		// protected void ResetButton() { }

		// // RVA: 0xA9DC88 Offset: 0xA9DC88 VA: 0xA9DC88
		// private void ListupInputObjects() { }

		// // RVA: 0xA9F728 Offset: 0xA9F728 VA: 0xA9F728
		// protected void ShowCanvas() { }

		// // RVA: 0xA9F8F8 Offset: 0xA9F8F8 VA: 0xA9F8F8
		// protected void HideCanvas() { }

		// // RVA: 0xA9F880 Offset: 0xA9F880 VA: 0xA9F880
		// private void ListupCanvas() { }

		// // RVA: 0xA9FA50 Offset: 0xA9FA50 VA: 0xA9FA50
		// protected bool CheckTutorialFunc(TutorialConditionId conditionId) { }
	}
}
