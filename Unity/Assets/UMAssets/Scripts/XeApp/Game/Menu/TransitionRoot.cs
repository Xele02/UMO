using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using XeApp.Game.Common;
using System;
using UnityEngine.Events;
using System.Collections;
using XeApp.Core;
using XeSys;
using XeApp.Game.Tutorial;

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
			private HelpButton m_helpButton; // 0x28
			private SceneStack m_transitionStack = new SceneStack(); // 0x2C
			private TransitionRoot m_currentRoot; // 0x30
			private TransitionInfo m_current = new TransitionInfo(); // 0x34
			private TransitionInfo m_next; // 0x38
			private TransitionRoot.MenuTransitionControl.TransitionType m_transitionType; // 0x3C
			private bool m_isRequestSave; // 0x40
			private bool m_remainDivaOneTimeFlag; // 0x41
			// private bool m_isStoryNewIconCashe; // 0x42
			private IndexableDictionary<int, TransitionRoot> m_instanceCacheDict = new IndexableDictionary<int, TransitionRoot>(0); // 0x44
			private Dictionary<SceneGroupCategory, MenuButtonAnim.ButtonType> m_groupCategoryButtonTypeMap = new Dictionary<SceneGroupCategory, MenuButtonAnim.ButtonType>() {
				{ SceneGroupCategory.CONTINUATION, MenuButtonAnim.ButtonType.HOME }, 
				{ SceneGroupCategory.FORMATION, MenuButtonAnim.ButtonType.SETTING}, 
				{ SceneGroupCategory.STORY, MenuButtonAnim.ButtonType.HOME}, 
				{ SceneGroupCategory.VOP, MenuButtonAnim.ButtonType.VOP}, 
				{ SceneGroupCategory.FREE, MenuButtonAnim.ButtonType.LIVE}, 
				{ SceneGroupCategory.GACHA, MenuButtonAnim.ButtonType.GACHA}, 
				{ SceneGroupCategory.OPTION, MenuButtonAnim.ButtonType.MENU }, 
				{ SceneGroupCategory.QUEST, MenuButtonAnim.ButtonType.QUEST }, 
				{ SceneGroupCategory.EVENT_QUEST, MenuButtonAnim.ButtonType.LIVE }, 
				{ SceneGroupCategory.EVENT_MUISC, MenuButtonAnim.ButtonType.LIVE }, 
				{ SceneGroupCategory.EVENT_BATTLE, MenuButtonAnim.ButtonType.LIVE }, 
				{ SceneGroupCategory.EVENT_GODIVA, MenuButtonAnim.ButtonType.LIVE}
			}; // 0x48
			private List<NewMarkIcon> m_newMarkIconList = new List<NewMarkIcon>(32); // 0x50
			// [CompilerGeneratedAttribute] // RVA: 0x66A050 Offset: 0x66A050 VA: 0x66A050
			public UnityAction<SceneGroupCategory, SceneGroupCategory> ChangeGroupCategoryListener; // 0x54
			private TransitionTreeObject treeObject; // 0x58
			private List<TransitionList.Type> m_enableDivaModelTransitionName = new List<TransitionList.Type>() {
				TransitionList.Type.LOGIN_BONUS, 
				TransitionList.Type.HOME, 
				TransitionList.Type.HOME_BG_SELECT, 
				TransitionList.Type.RESULT, 
				TransitionList.Type.COSTUME_VIEW_MODE, 
				TransitionList.Type.GAKUYA, 
				TransitionList.Type.GAKUYA_DIVA_VIEW
			}; // 0x5C
			private List<TransitionList.Type> m_notAutoLoadDiva = new List<TransitionList.Type>()
			{ 
				TransitionList.Type.COSTUME_SELECT,
				TransitionList.Type.COSTUME_VIEW_MODE
			}; // 0x60
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

			public bool DirtyChangeScene { get; private set; } // 0x4C
			public bool IsTransition { get; private set; } // 0x4D
			// public bool StopTransition { get; set; } // 0x4E
			public MenuHeaderControl MenuHeader { get { return m_titleBarControl; } } // 0xA31488
			public MenuFooterControl MenuFooter { get { return m_menuBarControl; } } //0xA31490
			public HelpButton HelpButton { get { return m_helpButton; } }// 0xA31498
			// private List<TransitionTreeObject.SceneRoot> SceneDirectory { get; } 0xA316B8
			// public BgControl bgControl { get; } 0xA399F8

			// [CompilerGeneratedAttribute] // RVA: 0x6C8B4C Offset: 0x6C8B4C VA: 0x6C8B4C
			// // RVA: 0xA314A0 Offset: 0xA314A0 VA: 0xA314A0
			// public void add_ChangeGroupCategoryListener(UnityAction<SceneGroupCategory, SceneGroupCategory> value) { }

			// [CompilerGeneratedAttribute] // RVA: 0x6C8B5C Offset: 0x6C8B5C VA: 0x6C8B5C
			// // RVA: 0xA315AC Offset: 0xA315AC VA: 0xA315AC
			// public void remove_ChangeGroupCategoryListener(UnityAction<SceneGroupCategory, SceneGroupCategory> value) { }

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
			public void Mount(TransitionUniqueId uniqueId, TransitionArgs args, bool isFading = true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene cambackUnityScene = 0)
			{
				ChangeMount(uniqueId,false,args,cambackUnityScene,false);
			}

			// // RVA: 0xA39334 Offset: 0xA39334 VA: 0xA39334
			public void MountWithFade(TransitionUniqueId uniqueId, TransitionArgs args, bool isFading = true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene cambackUnityScene = 0)
			{
				ChangeMount(uniqueId,false,args,cambackUnityScene,true);
			}

			// // RVA: 0xA39364 Offset: 0xA39364 VA: 0xA39364
			// public void Call(TransitionList.Type next, TransitionArgs args, bool isFading = True) { }

			// // RVA: 0xA3966C Offset: 0xA3966C VA: 0xA3966C
			// public void Return(bool isFading = True) { }

			// // RVA: 0xA39384 Offset: 0xA39384 VA: 0xA39384
			// private void ChangeCall(TransitionList.Type nextTransition, bool isFading = True, TransitionArgs args) { }

			// // RVA: 0xA39030 Offset: 0xA39030 VA: 0xA39030
			private void ChangeMount(TransitionUniqueId uniqueId, bool isFading = true, TransitionArgs args = null, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene camBackUnityScene = 0, bool isForceFading = false)
			{
				UnityEngine.Debug.Log("Scene mount "+uniqueId.ToString());
				int group = (int)uniqueId >> 16;
				TransitionTreeObject.SceneRoot root = treeObject.Find((TransitionTreeObject.SceneRoot x) => {
					//0xA3D6C8
					return (int)x.m_category == group;
				});
				if(root != null)
				{
					TransitionTreeObject.SceneTree sceneTree = FindTransitionTree(root, (TransitionTreeObject.SceneTree x) => {
						//0xA3D700
						return x.m_uniquId == (int)uniqueId;
					});
					if(sceneTree != null)
					{
						TransitionInfo info = new TransitionInfo();
						info.name = sceneTree.m_sceneName;
						info.groupCategory = (SceneGroupCategory)group;
						info.fadeId = sceneTree.m_FadeId;
						info.cacheCategory = sceneTree.m_cacheCategory;
						info.titleLabel = sceneTree.m_titleLabel;
						info.descId = sceneTree.m_descId;
						info.bgType = sceneTree.m_bgType;
						info.uniqueId = (int)uniqueId;
						info.isForceFading = isForceFading;
						info.camBackUnityScene = camBackUnityScene;
						m_next = info;
						info.args = args;
						m_transitionType = TransitionType.Mount;
						DirtyChangeScene = true;
					}
				}
			}

			// // RVA: 0xA396F4 Offset: 0xA396F4 VA: 0xA396F4
			private TransitionTreeObject.SceneTree FindTransitionTree(TransitionTreeObject.SceneRoot root, Func<TransitionTreeObject.SceneTree, bool> comp)
			{
				for(int i = 0; i < root.list.Count; i++)
				{
					if(comp(root.list[i]))
					{
						return root.list[i];
					}
				}
				return null;
			}

			// // RVA: 0xA399CC Offset: 0xA399CC VA: 0xA399CC
			// public GameObject GetCurrentBg() { }

			// // RVA: 0xA39A00 Offset: 0xA39A00 VA: 0xA39A00
			// public TransitionInfo GetCurrentScene() { }

			// // RVA: 0xA39A08 Offset: 0xA39A08 VA: 0xA39A08
			// public TransitionInfo GetNextScene() { }

			// // RVA: 0xA39A10 Offset: 0xA39A10 VA: 0xA39A10
			// public TransitionRoot GetCurrentTransitionRoot() { }

			// // RVA: 0xA39A18 Offset: 0xA39A18 VA: 0xA39A18
			// public bool OnPushReturnButton() { }

			// // RVA: 0xA39A4C Offset: 0xA39A4C VA: 0xA39A4C
			public void ClearDirtyChangeScene()
			{
				DirtyChangeScene = false;
			}

			// // RVA: 0xA39A58 Offset: 0xA39A58 VA: 0xA39A58
			// public int GetDefaultBgmId(SceneGroupCategory category) { }

			// [IteratorStateMachineAttribute] // RVA: 0x6C8B6C Offset: 0x6C8B6C VA: 0x6C8B6C
			// // RVA: 0xA39B1C Offset: 0xA39B1C VA: 0xA39B1C
			public IEnumerator Initialize(MonoBehaviour mb, UnityAction action)
			{
				//0xA410DC
				int loadCount = 0;
				mb.StartCoroutine(m_bgControl.Load(() => {
					//0xA3D740
					loadCount++;
				}));
				mb.StartCoroutine(m_menuBarControl.Load(m_font, () => {
					//0xA3D750
					loadCount++;
				}));
				mb.StartCoroutine(m_titleBarControl.Load(mb, m_font, () => {
					//0xA3D760
					loadCount++;
				}));
				mb.StartCoroutine(Co_LoadHelpButton(() => {
					//0xA3D770
					loadCount++;
				}));
				SetupPrefabSwitchTable();
				while(loadCount < 4)
					yield return null;
				if(action != null)
				{
					action();
				}
			}

			// [IteratorStateMachineAttribute] // RVA: 0x6C8BE4 Offset: 0x6C8BE4 VA: 0x6C8BE4
			// // RVA: 0xA39BFC Offset: 0xA39BFC VA: 0xA39BFC
			private IEnumerator Co_LoadHelpButton(UnityAction finish)
			{
				//0xA4067C
				AssetBundleLoadLayoutOperationBase op = AssetBundleManager.LoadLayoutAsync("ly/092.xab", "roo_cmn_help_question_btn_layout_root");
				yield return op;
				yield return op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) => {
					//0xA3D408;
					instance.transform.SetParent(m_uiRootObject.transform, false);
					m_helpButton = instance.GetComponent<HelpButton>();
				});
				if(finish != null)
					finish();
				AssetBundleManager.UnloadAssetBundle("ly/092.xab");
			}

			// // RVA: 0xA39CC4 Offset: 0xA39CC4 VA: 0xA39CC4
			private void SetupPrefabSwitchTable()
			{
				prefabSwitchTable.Clear();
				PEBFNABDJDI p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND.GDEKCOOBLMA;
				for(int i = 0; i < assetBundleNames.Length; i++)
				{
					if(p.LMBIOEDHNHB.ContainsKey(assetBundleNames[i].prefabName))
					{
						BIJMLAPNMAB b = p.LMBIOEDHNHB[assetBundleNames[i].prefabName];
						PrefabSwitchInfo info = new PrefabSwitchInfo((TransitionList.Type)i, b.AEMLILCNODL, b.OIPCKOBNHJL);
						prefabSwitchTable.Add(info);
					}
				}
			}

			// [IteratorStateMachineAttribute] // RVA: 0x6C8C5C Offset: 0x6C8C5C VA: 0x6C8C5C
			// // RVA: 0xA3A010 Offset: 0xA3A010 VA: 0xA3A010
			private IEnumerator DeleteCache(SceneCacheCategory cacheCategory)
			{
				//0xA40948
				for(int i = 0; i < m_instanceCacheDict.Count; i++)
				{
					int key = m_instanceCacheDict.GetKey(i);
					if(!string.IsNullOrEmpty(assetBundleNames[key].bundlePath))
					{
						AssetBundleManager.UnloadAssetBundle(assetBundleNames[key].bundlePath);
					}
					m_instanceCacheDict[key].OnDeleteCache();
					UnityEngine.Object.Destroy(m_instanceCacheDict[key].gameObject);
				}
				m_instanceCacheDict.Clear();
				yield break;
			}

			// [IteratorStateMachineAttribute] // RVA: 0x6C8CD4 Offset: 0x6C8CD4 VA: 0x6C8CD4
			// // RVA: 0xA3A0BC Offset: 0xA3A0BC VA: 0xA3A0BC
			private IEnumerator RegisterCache(SceneCacheCategory cacheCategory, TransitionList.Type transitionName)
			{
				// private TransitionRoot <root>5__2; // 0x20
				// private TransitionRoot.MenuTransitionControl.BundleName <assetBundle>5__3; // 0x24
				// private ResourcesManager <resourceManager>5__4; // 0x28
				// private AssetBundleLoadLayoutOperationBase <operation>5__5; // 0x2C
				//0xA414D4
				UnityEngine.Debug.Log("Enter RegisterCache");
				GameObject instance = null;
				TransitionRoot root = null;
				TransitionRoot.MenuTransitionControl.BundleName assetBundle = assetBundleNames[(int)transitionName];
				if(!string.IsNullOrEmpty(assetBundle.bundlePath))
				{
					if(!string.IsNullOrEmpty(assetBundle.textureBundlePath))
					{
						yield return AssetBundleManager.LoadUnionAssetBundle(assetBundleNames[(int)transitionName].textureBundlePath);
						//to 3
					}
					// goto LAB_00a41be4
					AssetBundleLoadLayoutOperationBase operation = AssetBundleManager.LoadLayoutAsync(assetBundle.bundlePath, GetPrefabName(transitionName));
					yield return operation;
					yield return operation.InitializeLayoutCoroutine(m_font, (GameObject layout) => {
						//0xA3D788
						instance = layout;
					});
					instance.SetActive(true);
					root = instance.GetComponent<TransitionRoot>();
					while(!root.IsReady)
						yield return null;
					AssetBundleManager.UnloadAssetBundle(assetBundle.bundlePath, false);
					operation = null;
				}
				else
				{
					ResourcesManager resourceManager = ResourcesManager.Instance;
					FileResultObject rObject = null;
					resourceManager.Request(prefabName[(int)transitionName], (FileResultObject fo) => {
						//0xA3D798
						rObject = fo;
						return true;
					});
					resourceManager.Load();
					yield return null;
					while(resourceManager.isLoading)
						yield return null;
					instance = UnityEngine.Object.Instantiate<GameObject>(rObject.unityObject as GameObject);
					root = instance.GetComponent<TransitionRoot>();
					while(!root.IsReady)
						yield return null;
				}
				//LAB_00a41aa4:
				root.transform.SetParent(m_uiRootObject.transform, false);
				root.gameObject.SetActive(false);
				m_instanceCacheDict.Add((int)transitionName, root);
				UnityEngine.Debug.Log("Exit RegisterCache");
			}

			// [IteratorStateMachineAttribute] // RVA: 0x6C8D4C Offset: 0x6C8D4C VA: 0x6C8D4C
			// // RVA: 0xA3A184 Offset: 0xA3A184 VA: 0xA3A184
			// public IEnumerator ExitTransition() { }

			// [IteratorStateMachineAttribute] // RVA: 0x6C8DC4 Offset: 0x6C8DC4 VA: 0x6C8DC4
			// // RVA: 0xA3A230 Offset: 0xA3A230 VA: 0xA3A230
			// public IEnumerator DestroyTransion() { }

			// [IteratorStateMachineAttribute] // RVA: 0x6C8E3C Offset: 0x6C8E3C VA: 0x6C8E3C
			// // RVA: 0xA3A2DC Offset: 0xA3A2DC VA: 0xA3A2DC
			public IEnumerator ChangeTransition()
			{
				// private TransitionList.Type <prevTransition>5__2; // 0x18
				// private MenuHeaderControl <header>5__3; // 0x1C
				// private TransitionRoot <exitRoot>5__4; // 0x20
				// private bool <isCacheChange>5__5; // 0x24
				// private bool <isGroupChange>5__6; // 0x25
				// private bool <isFading>5__7; // 0x26
				// private TransitionList.Type <lastSceneName>5__8; // 0x28
				// private bool <isDivaActivate>5__9; // 0x2C
				// private bool <isNotAutoLoad>5__10; // 0x2D
				// private ButtonBase <onButton>5__11; // 0x30
				// private MenuDivaManager <divaManager>5__12; // 0x34
				//0xA3D91C
				TransitionList.Type prevTransition = TransitionList.Type.UNDEFINED;
				bool isSaveError = false;
				if(m_isRequestSave)
				{
					UnityEngine.Debug.LogError("TODO request save");
				}
				DirtyChangeScene = false;
				IsTransition = true;
				MenuScene.Instance.InputDisable();
				MenuScene.Instance.RaycastDisable();
				MenuHeaderControl header = MenuScene.Instance.HeaderMenu;
				if(header != null)
				{
					if(header.MenuTop != null)
					{
						//to1
						while(header.MenuTop.IsPlayingMiniWindow())
							yield return null;
						header.MenuTop.LeaveMiniWindow();
					}
				}
				TransitionRoot exitRoot = m_currentRoot;
				if(m_currentRoot != null)
				{
					ButtonBase onButton = exitRoot.m_buttons.Find((ButtonBase _) => {
						//0xA3D598
						return _.IsPlaying();
					});
					if(onButton != null)
					{
						while(onButton.IsPlaying())
							yield return null;
					}
				}
				if(m_transitionType == TransitionType.Call)
				{
					PushStack();
				}
				else if(m_transitionType == TransitionType.Return)
				{
					SceneStackInfo prev = m_transitionStack.Pop();
					m_next.cacheCategory = prev.cacheCategory;
					m_next.groupCategory = prev.groupCategory;
					m_next.name = prev.name;
					m_next.fadeId = prev.fadeId;
					m_next.titleLabel = prev.titleLabel;
					m_next.descId = prev.descId;
					m_next.bgmId = prev.bgmId;
					m_next.bgType = prev.bgType;
					m_next.bgId = prev.bgId;
					m_next.bgAttr = prev.bgAttr;
					m_next.args = prev.args;
					m_next.uniqueId = prev.uniqueId;
					m_next.args_return = null;
					if(m_currentRoot != null)
					{
						m_next.args_return = m_currentRoot.GetCallArgsReturn();
					}
				}
				else if(m_transitionType == TransitionType.Mount)
				{
					m_transitionStack.Clear();
					RevivalStack();
					if(m_transitionStack.Count > 0)
					{
						if(m_next.bgType == BgType.Undefined)
						{
							m_next.bgType = m_transitionStack.GetTop().bgType;
						}
					}
				}
				if(exitRoot != null)
				{
					exitRoot.OnStartExitTitleHeader();
					exitRoot.OnStartExitAnimation();
					prevTransition = exitRoot.TransitionName;
					m_helpButton.TryHide(m_next.name);
					while(!exitRoot.IsEndExitAnimation())
						yield return null;
				}
				bool isCacheChange = m_current.cacheCategory != m_next.cacheCategory;
				bool isGroupChange = m_current.groupCategory != m_next.groupCategory;
				bool isFading = false;
				if(m_current.fadeId == m_next.fadeId && !isCacheChange)
				{
					isFading = m_next.isForceFading;
				}
				else
				{
					isFading = true;
				}

				if(isFading)
				{
					bool canShowNowLoading = CanShowNowLoading(prevTransition, m_next.name);
					GameManager.Instance.fullscreenFader.Fade(0.1f, Color.black);
					if(canShowNowLoading || isCacheChange)
					{
						GameManager.Instance.NowLoading.Show();
					}
				}
				while(GameManager.Instance.fullscreenFader.isFading)
					yield return null;
				if(isFading)
				{
					int tipsCount = 0;
					if(CanShowTips(prevTransition, m_next.name, m_next.camBackUnityScene, out tipsCount) && tipsCount > 0)
					{
						TipsControl.Instance.Show(tipsCount);
						yield return TipsControl.Instance.WaitLoadingYield;
						while(TipsControl.Instance.isPlayingAnime())
							yield return null;
					}
				}
				if(isGroupChange)
				{
					OnChangeGroupCategory(m_current.groupCategory, m_next.groupCategory);
				}
				if(prevTransition == TransitionList.Type.TITLE || prevTransition == TransitionList.Type.UNDEFINED)
				{
					MenuScene.Instance.InitializePlayerStatusData();
				}
				// to 7
				yield return null;
				m_newMarkIconList.ForEach((NewMarkIcon _) => {
					//0xA3D5CC
					_.Release();
				});
				m_newMarkIconList.Clear();
				while(CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI)
					yield return null;
				if(isSaveError)
				{
					isSaveError = false;
					IsTransition = false;
					yield break;
				}
				if(m_currentRoot != null)
				{
					m_currentRoot.OnDestoryScene();
					m_currentRoot.gameObject.SetActive(false);
				}
				if(isCacheChange)
				{
					yield return DeleteCache(SceneCacheCategory.TITLE);
					// to 9
					yield return Resources.UnloadUnusedAssets();
					// to 10
				}
				if(!TryGetRoot(0, m_next.name, out m_currentRoot))
				{
					yield return RegisterCache(SceneCacheCategory.TITLE, m_next.name);
					// to 11
					m_currentRoot = m_instanceCacheDict[(int)m_next.name];
				}
				m_currentRoot.Args = m_next.args;
				m_currentRoot.ArgsReturn = m_next.args_return;
				m_currentRoot.m_prevTransition = prevTransition;
				m_currentRoot.m_transitionType = m_transitionType;
				m_currentRoot.gameObject.SetActive(true);
				m_currentRoot.HideCanvas();
				m_currentRoot.transform.SetParent(null, false);
				m_currentRoot.m_parentTransition = TransitionList.Type.UNDEFINED;
				if(m_transitionStack.GetTop() != null)
				{
					m_currentRoot.m_parentTransition = m_transitionStack.GetTop().name;
				}
				if(!isFading)
				{
					m_bgControl.ReserveFade(0.1f, Color.black);
				}
				yield return m_bgControl.ChangeBgCoroutine(m_next.bgType, m_next.bgId, m_next.groupCategory, m_next.name, m_next.bgAttr);
				// to 12
				TransitionList.Type lastSceneName = TransitionList.Type.NUM;
				if(m_current != null)
					lastSceneName = m_current.name;
				m_next.args = null;
				m_current = m_next;
				m_currentRoot.ResetButton();
				yield return null;
				// to 13
				m_currentRoot.OnPreSetCanvas();
				// to 14
				while(!m_currentRoot.IsEndPreSetCanvas())
					yield return null;
				// to 15
				yield return null;
				m_currentRoot.transform.SetParent(m_uiRootObject.transform, false);
				m_currentRoot.ShowCanvas();
				m_titleBarControl.Show(m_next.name, (TransitionUniqueId)m_next.uniqueId, m_next.titleLabel, m_next.groupCategory, m_next.descId, m_transitionStack.Count > 0);
				bool isDivaActivate = m_enableDivaModelTransitionName.Contains(m_next.name);
				if(m_remainDivaOneTimeFlag)
				{
					if(m_enableDivaModelTransitionName.Contains(lastSceneName))
						isDivaActivate = true;
				}
				bool isNotAutoLoad  = m_notAutoLoadDiva.Contains(m_next.name);
				if(isDivaActivate)
				{
					if(!GameManager.Instance.divaResource.isMenuAllLoaded && !isNotAutoLoad)
					{
						UnityEngine.Debug.LogError("TODO Load diva menu");
						//L777
						// to 16
					}
					// to 17
					UnityEngine.Debug.LogError("TODO Load diva menu");
				}
				m_remainDivaOneTimeFlag = false;
				bool idleDivaModel = false;
				if(lastSceneName != TransitionList.Type.GACHA_CHECK_NEW_COSTUME && 
				(lastSceneName != TransitionList.Type.GAKUYA && m_current.name != TransitionList.Type.HOME) && 
				(lastSceneName != TransitionList.Type.COSTUME_SELECT && m_current.name != TransitionList.Type.COSTUME_VIEW_MODE) &&
				(lastSceneName != TransitionList.Type.COSTUME_VIEW_MODE && m_current.name != TransitionList.Type.COSTUME_SELECT))
				{
					idleDivaModel = true;
				}
				bool activeDivaModel = false;
				if(m_next.name == TransitionList.Type.HOME || m_next.name == TransitionList.Type.HOME_BG_SELECT)
				{
					UnityEngine.Debug.LogError("TODO check activate diva");
					//L876
				}
				else
				{
					activeDivaModel = true;
				}
				MenuScene.Instance.SetActiveDivaModel(activeDivaModel && isDivaActivate, idleDivaModel);
				bool divaActivated = false;
				if(isDivaActivate)
				{
					UnityEngine.Debug.LogError("TODO setup diva");
					divaActivated = isDivaActivate;
				}
				if((isNotAutoLoad || divaActivated) == false)
				{
					//nothing
				}
				else
				{
					UnityEngine.Debug.LogError("TODO setup cam");
				}
				m_currentRoot.OnPostSetCanvas();
				while(!m_currentRoot.IsEndPostSetCanvas())
					yield return null;
				MenuButtonAnim.ButtonType buttonType = MenuButtonAnim.ButtonType.NONE;
				if(!m_groupCategoryButtonTypeMap.TryGetValue(m_next.groupCategory, out buttonType))
				{
					buttonType = MenuButtonAnim.ButtonType.NONE;
				}
				m_menuBarControl.Show(m_next.name, (TransitionUniqueId)m_next.uniqueId, buttonType, isFading);
				if(m_currentRoot.IsRequestGotoTitle)
				{
					MenuScene.Instance.GotoTitle();
					yield break;
				}
				if(m_currentRoot.AutoFadeFlag)
				{
					if(isFading)
					{
						TipsControl.Instance.Close();
						while(TipsControl.Instance.isPlayingAnime())
							yield return null;
					}
					GameManager.Instance.NowLoading.Hide();
					GameManager.Instance.fullscreenFader.Fade(0.1f, 0.0f);
				}
				m_currentRoot.OnStartEnterTitleHeader();
				m_currentRoot.OnStartEnterAnimation();
				m_helpButton.TryShow(m_next.name);
				if(!m_currentRoot.OnBgmStart())
				{
					if(m_transitionType == TransitionType.Return)
					{
						UnityEngine.Debug.LogError("TODO Play bgm Sound");
					}
					else
					{
						UnityEngine.Debug.LogError("TODO Play bgm Sound");
					}
					UnityEngine.Debug.LogError("TODO Play bgm Sound");
				}
				UnityEngine.Debug.LogError("TODO Play bgm Sound");
				//LAB_00a401d4
				while(GameManager.Instance.fullscreenFader.isFading)
					yield return null;
				while(!m_currentRoot.IsEndEnterAnimation())
					yield return null;
				IsTransition = false;
				UpdateMenuNewIcon(m_next.name, prevTransition);
				m_currentRoot.OnOpenScene();
				while(!m_currentRoot.IsEndOpenScene())
					yield return null;
				yield return TutorialManager.TryShowTutorialCoroutine(m_currentRoot.CheckTutorialFunc);
				//to 0x17
				MenuScene.Instance.InputEnable();
				MenuScene.Instance.RaycastEnable();
				m_currentRoot.OnActivateScene();
				// to 0x18
				while(!m_currentRoot.IsEndActivateScene())
					yield return null;
				if(GameManager.Instance.IsTutorial)
				{
					m_currentRoot.OnTutorial();
				}
				m_currentRoot.Args = null;
				m_currentRoot.ArgsReturn = null;
			}

			// // RVA: 0xA3A388 Offset: 0xA3A388 VA: 0xA3A388
			private string GetPrefabName(TransitionList.Type transitionName)
			{
				PrefabSwitchInfo info = prefabSwitchTable.Find((PrefabSwitchInfo p) => {
					//0xA3D8A0
					return p.targetType == transitionName;
				});
				if(info != null)
				{
					if(info.thresholdMasterVersion < 1)
						return info.prefabName;
					else if(info.thresholdMasterVersion <= DIHHCBACKGG.IEFOPDOOLOK)
						return info.prefabName;
				}
				return assetBundleNames[(int)transitionName].prefabName;
			}

			// // RVA: 0xA3A56C Offset: 0xA3A56C VA: 0xA3A56C
			private bool TryGetRoot(SceneCacheCategory category, TransitionList.Type name, out TransitionRoot root)
			{
				return m_instanceCacheDict.TryGetValue((int)name, out root);
			}

			// // RVA: 0xA3A5F4 Offset: 0xA3A5F4 VA: 0xA3A5F4
			// private float CalcDivaPositionX(float min, float max) { }

			// // RVA: 0xA3A708 Offset: 0xA3A708 VA: 0xA3A708
			// private bool IsShiftIdleAnimation(TransitionList.Type current, TransitionList.Type next) { }

			// // RVA: 0xA3A754 Offset: 0xA3A754 VA: 0xA3A754
			private bool RevivalStack(TransitionTreeObject.SceneRoot root, TransitionTreeObject.SceneTree tree, TransitionUniqueId uniqueId)
			{
				if(tree.m_uniquId != (int)uniqueId)
				{
					int bgmId;
					if(m_transitionStack.Count == 0)
					{
						bgmId = sceneGroupCategoryBgmId[(int)m_next.groupCategory];
					}
					else
					{
						bgmId = m_transitionStack.GetTop().bgmId;
					}
					BgType bgType = tree.m_bgType;
					if(bgType == BgType.Undefined)
					{
						if(m_transitionStack.Count == 0)
						{
							bgType = BgType.Undefined;
						}
						else
						{
							bgType = m_transitionStack.GetTop().bgType;
						}
					}
					SceneStackInfo info = new SceneStackInfo();
					info.groupCategory = m_next.groupCategory;
					info.cacheCategory = tree.m_cacheCategory;
					info.fadeId = tree.m_FadeId;
					info.name = tree.m_sceneName;
					info.titleLabel = tree.m_titleLabel;
					info.bgmId = bgmId;
					info.descId = tree.m_descId;
					info.bgId = -1;
					info.bgType = bgType;
					info.uniqueId = tree.m_uniquId;
					m_transitionStack.Push(info);
					if(tree.m_childIndex > -1)
					{
						if(RevivalStack(root, root.list[tree.m_childIndex], uniqueId))
						{
							return true;
						}
						for(int i = root.list[tree.m_childIndex].m_siblingIndex; i > -1; i = root.list[i].m_siblingIndex)
						{
							if(RevivalStack(root, root.list[i], uniqueId))
								return true;
						}
					}
					m_transitionStack.Pop();
					return false;
				}
				return true;
			}

			// // RVA: 0xA3AC58 Offset: 0xA3AC58 VA: 0xA3AC58
			private void RevivalStack()
			{
				int group = m_next.uniqueId >> 0x10;
				TransitionTreeObject.SceneRoot root = treeObject.List.Find((TransitionTreeObject.SceneRoot category) => {
					//0xA3D8E0
					return (int)category.m_category == group;
				});
				RevivalStack(root, root.list[0], (TransitionUniqueId)root.list[0].m_uniquId);
			}

			// // RVA: 0xA3ADFC Offset: 0xA3ADFC VA: 0xA3ADFC
			public static void UpdateMenuNewIcon(TransitionList.Type nextTransition, TransitionList.Type prevTransition)
			{
				UnityEngine.Debug.LogError("TODO UpdateMenuNewIcon");
			}

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
			public void ApplyPlayerStatus(IFBCGCCJBHI playerStatus)
			{
				m_titleBarControl.ApplyPlayerStatus(playerStatus);
			}

			// // RVA: 0xA3B5DC Offset: 0xA3B5DC VA: 0xA3B5DC
			// public void SaveRequest() { }

			// // RVA: 0xA3B688 Offset: 0xA3B688 VA: 0xA3B688
			// public void RemainDivaOneTime() { }

			// // RVA: 0xA3B694 Offset: 0xA3B694 VA: 0xA3B694
			// public void SaveStack(SceneStack stack) { }

			// // RVA: 0xA3B6C8 Offset: 0xA3B6C8 VA: 0xA3B6C8
			// public void LoadStack(SceneStack stack) { }

			// // RVA: 0xA3B6FC Offset: 0xA3B6FC VA: 0xA3B6FC
			public void PushStack()
			{
				SceneStackInfo stack = new SceneStackInfo();
				stack.cacheCategory = m_current.cacheCategory;
				stack.groupCategory = m_current.groupCategory;
				stack.name = m_current.name;
				stack.fadeId = m_current.fadeId;
				stack.titleLabel = m_current.titleLabel;
				stack.descId = m_current.descId;
				stack.bgmId = SoundManager.Instance.bgmPlayer.currentBgmId;
				stack.bgType = m_bgControl.GetCurrentType();
				stack.bgAttr = (int)m_bgControl.GetCurrentAttr();
				stack.storyBgParam = m_bgControl.OutputStoryBgParam(m_current.groupCategory == SceneGroupCategory.STORY);
				stack.args = m_currentRoot.GetCallArgs();
				stack.uniqueId = m_current.uniqueId;
				m_transitionStack.Push(stack);
			}

			// // RVA: 0xA3B9A0 Offset: 0xA3B9A0 VA: 0xA3B9A0
			private void OnChangeGroupCategory(SceneGroupCategory prevCategory, SceneGroupCategory nextCategory)
			{
				if(ChangeGroupCategoryListener != null)
					ChangeGroupCategoryListener(prevCategory, nextCategory);
			}

			// // RVA: 0xA3BA1C Offset: 0xA3BA1C VA: 0xA3BA1C
			// public Vector3 GetDivaCameraRotByScene(TransitionList.Type type) { }

			// // RVA: 0xA3BB18 Offset: 0xA3BB18 VA: 0xA3BB18
			public bool CanShowNowLoading(TransitionList.Type from, TransitionList.Type to)
			{
				for(int i = 0; i < loadPlaceList.Length; i++)
				{
					if((loadPlaceList[i].from == TransitionList.Type.UNDEFINED || loadPlaceList[i].from == from) &&
						loadPlaceList[i].to == to)
					{
						return true;
					}
				}
				return false;
			}

			// // RVA: 0xA3BDA4 Offset: 0xA3BDA4 VA: 0xA3BDA4
			public bool CanShowTips(TransitionList.Type from, TransitionList.Type to, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene camBackUnityScene, out int count)
			{
				count = 0;
				UnityEngine.Debug.LogError("TODO");
				return false;
			}
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

		public TransitionList.Type TransitionName { get { return m_transitionName; } } //0xA7FEC0
		// public GameObject bgRoot { get; set; } 0xA9D73C 0xA9D744
		public TransitionArgs Args { get { return m_args; } set { m_args = value; } } //0xA83E84 0xA9D74C
		public TransitionArgs ArgsReturn { get { return m_args_return; } set { m_args_return = value; } } //0xA9D754 0xA9D75C
		// public TransitionList.Type PrevTransition { get; } 0xA7FEC8
		// public TransitionList.Type ParentTransition { get; } 0xA9D764
		// public TransitionRoot.MenuTransitionControl.TransitionType TransitionType { get; } 0xA9D76C
		public bool IsRequestGotoTitle { get; set; } // 0x28
		public bool IsReady { get; protected set; } // 0x29
		// public int InputStateCount { get; } 0xA9D78C
		public bool AutoFadeFlag { get { return m_isAutoFade; } set { m_isAutoFade = value; } }// 0xA9D794 0xA9D79C

		// RVA: 0xA80A84 Offset: 0xA80A84 VA: 0xA80A84 Slot: 4
		protected virtual void Awake()
		{
			IsReady = false;
		}

		// RVA: 0xA80B40 Offset: 0xA80B40 VA: 0xA80B40 Slot: 5
		protected virtual void Start()
		{
			return;
		}

		// RVA: 0xA9D7A4 Offset: 0xA9D7A4 VA: 0xA9D7A4 Slot: 6
		protected virtual void OnEnable()
		{
			return;
		}

		// RVA: 0xA9D7A8 Offset: 0xA9D7A8 VA: 0xA9D7A8 Slot: 7
		protected virtual void OnDisable()
		{
			return;
		}

		// // RVA: 0xA9D7AC Offset: 0xA9D7AC VA: 0xA9D7AC Slot: 8
		protected virtual void OnStartEnterTitleHeader()
		{
			return;
		}

		// // RVA: 0xA9D7B0 Offset: 0xA9D7B0 VA: 0xA9D7B0 Slot: 9
		protected virtual void OnStartEnterAnimation()
		{
			return;
		}

		// // RVA: 0xA9D7B4 Offset: 0xA9D7B4 VA: 0xA9D7B4 Slot: 10
		protected virtual bool IsEndEnterAnimation()
		{
			return true;
		}

		// // RVA: 0xA9D7BC Offset: 0xA9D7BC VA: 0xA9D7BC Slot: 11
		protected virtual void OnStartExitTitleHeader()
		{
			return;
		}

		// // RVA: 0xA9D7C0 Offset: 0xA9D7C0 VA: 0xA9D7C0 Slot: 12
		protected virtual void OnStartExitAnimation()
		{
			return;
		}

		// // RVA: 0xA9D7C4 Offset: 0xA9D7C4 VA: 0xA9D7C4 Slot: 13
		protected virtual bool IsEndExitAnimation()
		{
			return true;
		}

		// // RVA: 0xA9D7CC Offset: 0xA9D7CC VA: 0xA9D7CC Slot: 14
		protected virtual void OnDestoryScene()
		{
			return;
		}

		// // RVA: 0xA9D7D0 Offset: 0xA9D7D0 VA: 0xA9D7D0 Slot: 15
		protected virtual void OnDeleteCache()
		{
			return;
		}

		// // RVA: 0xA9D7D4 Offset: 0xA9D7D4 VA: 0xA9D7D4 Slot: 16
		protected virtual void OnPreSetCanvas()
		{
			return;
		}

		// // RVA: 0xA8553C Offset: 0xA8553C VA: 0xA8553C Slot: 17
		protected virtual bool IsEndPreSetCanvas()
		{
			return !GameManager.Instance.SceneIconCache.IsLoading() &&
					!GameManager.Instance.DivaIconCache.IsLoading() && 
					!GameManager.Instance.ValkyrieIconCache.IsLoading();
		}

		// // RVA: 0xA9D7D8 Offset: 0xA9D7D8 VA: 0xA9D7D8 Slot: 18
		protected virtual void OnPostSetCanvas()
		{
			return;
		}

		// // RVA: 0xA85780 Offset: 0xA85780 VA: 0xA85780 Slot: 19
		protected virtual bool IsEndPostSetCanvas()
		{
			return true;
		}

		// // RVA: 0xA9D7DC Offset: 0xA9D7DC VA: 0xA9D7DC Slot: 20
		protected virtual bool OnBgmStart()
		{
			return false;
		}

		// // RVA: 0xA9D7E4 Offset: 0xA9D7E4 VA: 0xA9D7E4 Slot: 21
		protected virtual void OnOpenScene()
		{
			return;
		}

		// // RVA: 0xA9D7E8 Offset: 0xA9D7E8 VA: 0xA9D7E8 Slot: 22
		protected virtual bool IsEndOpenScene()
		{
			return true;
		}

		// // RVA: 0xA9D7F0 Offset: 0xA9D7F0 VA: 0xA9D7F0 Slot: 23
		protected virtual void OnActivateScene()
		{
			return;
		}

		// // RVA: 0xA9D7F4 Offset: 0xA9D7F4 VA: 0xA9D7F4 Slot: 24
		protected virtual bool IsEndActivateScene()
		{
			return true;
		}

		// // RVA: 0xA9D7FC Offset: 0xA9D7FC VA: 0xA9D7FC Slot: 25
		protected virtual void OnTutorial()
		{
			return;
		}

		// // RVA: 0xA9D800 Offset: 0xA9D800 VA: 0xA9D800 Slot: 26
		// protected virtual bool OnPushReturnButton() { }

		// // RVA: 0xA9D808 Offset: 0xA9D808 VA: 0xA9D808 Slot: 27
		protected virtual TransitionArgs GetCallArgs()
		{
			return null;
		}

		// // RVA: 0xA917EC Offset: 0xA917EC VA: 0xA917EC Slot: 28
		protected virtual TransitionArgs GetCallArgsReturn()
		{
			return null;
		}

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
		protected void ResetButton()
		{
			GetComponentsInChildren<ButtonBase>(true, m_buttons);
			m_buttons.ForEach((ButtonBase button) => {
				//0xA310D4
				button.SetOff();
			});
		}

		// // RVA: 0xA9DC88 Offset: 0xA9DC88 VA: 0xA9DC88
		// private void ListupInputObjects() { }

		// // RVA: 0xA9F728 Offset: 0xA9F728 VA: 0xA9F728
		protected void ShowCanvas()
		{
			ListupCanvas();
			if(m_canvases == null)
				return;
			Array.ForEach(m_canvases, (Canvas _) => {
				//0xA31108
				_.enabled = true;
			});
		}

		// // RVA: 0xA9F8F8 Offset: 0xA9F8F8 VA: 0xA9F8F8
		protected void HideCanvas()
		{
			ListupCanvas();
			if(m_canvases == null)
				return;
			Array.ForEach(m_canvases, (Canvas _) => {
				//0xA31138
				_.enabled = false;
			});
		}

		// // RVA: 0xA9F880 Offset: 0xA9F880 VA: 0xA9F880
		private void ListupCanvas()
		{
			if(m_canvases != null)
				return;
			m_canvases = GetComponentsInChildren<Canvas>(true);
		}

		// // RVA: 0xA9FA50 Offset: 0xA9FA50 VA: 0xA9FA50
		protected bool CheckTutorialFunc(TutorialConditionId conditionId)
		{
			UnityEngine.Debug.LogError("TODO CheckTutorialFunc");
			return false;
		}
	}
}
