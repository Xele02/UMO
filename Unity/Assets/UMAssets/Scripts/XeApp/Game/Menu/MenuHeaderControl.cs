using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class MenuHeaderControl
	{
		private GameObject m_root; // 0x8
		private GameObject m_userInfoInstance; // 0xC
		private GameObject m_menuStackInstance; // 0x10
		private CommonMenuTop m_userInfo; // 0x14
		// private CommonMenuStack m_menuStack; // 0x18
		// private List<LayoutUGUIHitOnly> m_buttons = new List<LayoutUGUIHitOnly>(); // 0x1C
		private int[] m_buttonBlockCount; // 0x20
		// private UnityEvent m_onChargeMoneyEvent = new UnityEvent(); // 0x24
		private List<TransitionUniqueId> m_disableTitleBarUniqueScene = new List<TransitionUniqueId>(); // 0x28
		private List<TransitionList.Type> m_disableTitleBarScene = new List<TransitionList.Type>() {
			TransitionList.Type.TITLE,
			TransitionList.Type.LOGIN_BONUS,
			TransitionList.Type.RESULT,
			TransitionList.Type.MUSIC_SELECT,
			TransitionList.Type.MODEL_VIEW_MODE,
			TransitionList.Type.COSTUME_VIEW_MODE,
			TransitionList.Type.EVENT_MUSIC_SELECT,
			TransitionList.Type.SNS,
			TransitionList.Type.HOME,
			TransitionList.Type.HOME_BG_SELECT,
			TransitionList.Type.EVENT_QUEST,
			TransitionList.Type.UNLOCK_DIVA,
			TransitionList.Type.UNLOCK_COSTUME,
			TransitionList.Type.UNLOCK_VALKYRIE,
			TransitionList.Type.EVENT_BATTLE,
			TransitionList.Type.SIMULATIONLIVE_RESULT,
			TransitionList.Type.NEW_YEAR_EVENT,
			TransitionList.Type.GACHA_BOX,
			TransitionList.Type.GACHA_BOX_QUEST,
			TransitionList.Type.CAMPAIGN,
			TransitionList.Type.CAMPAIGN_ROULETTE,
			TransitionList.Type.GACHA_CHECK_NEW_COSTUME,
			TransitionList.Type.GACHA_CHECK_NEW_VALKYRIE,
			TransitionList.Type.EPISODE_APPEAL,
			TransitionList.Type.NEW_YEAR_EVENT_STORY,
			TransitionList.Type.OFFER_RESULT,
			TransitionList.Type.LOBBY_MAIN,
			TransitionList.Type.LOBBY_GROUP_SELECT,
			TransitionList.Type.LOBBY_GROUP_SEARCH,
			TransitionList.Type.DECO,
			TransitionList.Type.DECO_VISIT,
			TransitionList.Type.DECO_BAST,
			TransitionList.Type.RAID,
			TransitionList.Type.RAID_REWARD,
			TransitionList.Type.RAID_ACT_SELECT,
			TransitionList.Type.RAID_MCRS_CANNON,
			TransitionList.Type.DECO_VISIT,
			TransitionList.Type.DECO_CHAT,
			TransitionList.Type.MUSIC_RATE,
			TransitionList.Type.GACHA_2,
			TransitionList.Type.GAKUYA,
			TransitionList.Type.GAKUYA_DIVA_VIEW
		}; // 0x2C
		private List<TransitionUniqueId> m_disableBackButtonUniqueScene = new List<TransitionUniqueId>(); // 0x30
		private List<TransitionList.Type> m_disableBackButtonScene = new List<TransitionList.Type>() {
			TransitionList.Type.TITLE,
			TransitionList.Type.LOGIN_BONUS,
			TransitionList.Type.RESULT,
			TransitionList.Type.MODEL_VIEW_MODE,
			TransitionList.Type.COSTUME_VIEW_MODE,
			TransitionList.Type.SNS,
			TransitionList.Type.HOME_BG_SELECT,
			TransitionList.Type.UNLOCK_DIVA,
			TransitionList.Type.UNLOCK_COSTUME,
			TransitionList.Type.UNLOCK_VALKYRIE,
			TransitionList.Type.SIMULATIONLIVE_RESULT,
			TransitionList.Type.NEW_YEAR_EVENT,
			TransitionList.Type.CAMPAIGN,
			TransitionList.Type.CAMPAIGN_ROULETTE,
			TransitionList.Type.GACHA_CHECK_NEW_COSTUME,
			TransitionList.Type.GACHA_CHECK_NEW_VALKYRIE,
			TransitionList.Type.EPISODE_APPEAL,
			TransitionList.Type.OFFER_RESULT,
			TransitionList.Type.DECO,
			TransitionList.Type.DECO_BAST,
			TransitionList.Type.DECO_VISIT,
			TransitionList.Type.RAID_REWARD,
			TransitionList.Type.RAID_MCRS_CANNON,
			TransitionList.Type.DECO_VISIT,
			TransitionList.Type.LOBBY_MAIN,
			TransitionList.Type.LOBBY_GROUP_SELECT,
			TransitionList.Type.GAKUYA,
			TransitionList.Type.GAKUYA_DIVA_VIEW
		}; // 0x34
		private List<TransitionUniqueId> m_disableUserInfoUniqueScene = new List<TransitionUniqueId>()
		{
			TransitionUniqueId.HOME_RAID_RAIDACTSELECT_QUESTSELECT,
			TransitionUniqueId.HOME_RAID_RAIDACTSELECT_QUESTSELECT_UNLOCKCOSTUME,
			TransitionUniqueId.HOME_RAID_RAIDACTSELECT_QUESTSELECT_UNLOCKVALKYRIE,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_RAIDACTSELECT_QUESTSELECT,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_RAIDACTSELECT_QUESTSELECT_UNLOCKCOSTUME,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_RAIDACTSELECT_QUESTSELECT_UNLOCKVALKYRIE,
			TransitionUniqueId.MUSICSELECT_RAID_RAIDACTSELECT_QUESTSELECT,
			TransitionUniqueId.MUSICSELECT_RAID_RAIDACTSELECT_QUESTSELECT_UNLOCKCOSTUME,
			TransitionUniqueId.MUSICSELECT_RAID_RAIDACTSELECT_QUESTSELECT_UNLOCKVALKYRIE,
			TransitionUniqueId.HOME_RAID_PROFIL,
			TransitionUniqueId.HOME_RAID_EVENTRANKING_PROFIL,
			TransitionUniqueId.HOME_RAID_RAIDACTSELECT_RAIDMVP_PROFIL,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_PROFIL,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_EVENTRANKING_PROFIL,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_RAIDACTSELECT_RAIDMVP_PROFIL,
			TransitionUniqueId.MUSICSELECT_RAID_PROFIL,
			TransitionUniqueId.MUSICSELECT_RAID_EVENTRANKING_PROFIL,
			TransitionUniqueId.MUSICSELECT_RAID_RAIDACTSELECT_RAIDMVP_PROFIL,
			TransitionUniqueId.HOME_RAID_RAIDREWARD_RAIDMVP_PROFIL,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_RAIDREWARD_RAIDMVP_PROFIL,
			TransitionUniqueId.MUSICSELECT_RAID_RAIDREWARD_RAIDMVP_PROFIL,
			TransitionUniqueId.RESULT_RAIDMVP_PROFIL,
			TransitionUniqueId.HOME_HOMEBGSELECT,
			TransitionUniqueId.HOME_RAID_QUESTSELECT,
			TransitionUniqueId.HOME_RAID_QUESTSELECT_UNLOCKCOSTUME,
			TransitionUniqueId.HOME_RAID_QUESTSELECT_UNLOCKVALKYRIE,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_QUESTSELECT,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_QUESTSELECT_UNLOCKCOSTUME,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_QUESTSELECT_UNLOCKVALKYRIE,
			TransitionUniqueId.MUSICSELECT_RAID_QUESTSELECT,
			TransitionUniqueId.MUSICSELECT_RAID_QUESTSELECT_UNLOCKCOSTUME,
			TransitionUniqueId.MUSICSELECT_RAID_QUESTSELECT_UNLOCKVALKYRIE,
			TransitionUniqueId.HOME_RAID_SHOPPRODUCT,
			TransitionUniqueId.HOME_LOBBYMAIN_RAID_SHOPPRODUCT,
			TransitionUniqueId.MUSICSELECT_RAID_SHOPPRODUCT,
			TransitionUniqueId.DECO_DECOVISIT_DECOCHAT_PROFIL,
			TransitionUniqueId.DECO_DECOCHAT_PROFIL,
			TransitionUniqueId.DECO_FRIENDSEARCH_PROFIL,
			TransitionUniqueId.DECO_LOBBYGROUPSELECT_LOBBYGROUPSEARCH_PROFIL,
			TransitionUniqueId.HOME_LOBBYGROUPSELECT_LOBBYGROUPSEARCH_PROFIL,
			TransitionUniqueId.MUSICSELECT_LOBBYGROUPSELECT_LOBBYGROUPSEARCH_PROFIL,
			TransitionUniqueId.MUSICRATE,
			TransitionUniqueId.MUSICSELECT_MUSICRATE,
			TransitionUniqueId.EVENTQUEST_MUSICRATE,
			TransitionUniqueId.EVENTGODIVA_MUSICRATE
		}; // 0x38
		private List<TransitionList.Type> m_disableUserInfo = new List<TransitionList.Type>() {
			TransitionList.Type.TITLE,
			TransitionList.Type.LOGIN_BONUS,
			TransitionList.Type.RESULT,
			TransitionList.Type.HOME,
			TransitionList.Type.TEAM_EDIT,
			TransitionList.Type.TEAM_SELECT,
			TransitionList.Type.DIVA_SELECT_LIST,
			TransitionList.Type.DIVA_SETTING_LIST,
			TransitionList.Type.DIVA_GROWTH_CONF,
			TransitionList.Type.SCENE_SELECT,
			TransitionList.Type.SCENE_GROWTH,
			TransitionList.Type.SCENE_ABILITY_RELEASE_LIST,
			TransitionList.Type.SAVE_UNIT_DETAIL,
			TransitionList.Type.FRIEND_SELECT,
			TransitionList.Type.MODEL_VIEW_MODE,
			TransitionList.Type.REGULAR_RANKING,
			TransitionList.Type.EVENT_RANKING,
			TransitionList.Type.COSTUME_SELECT,
			TransitionList.Type.COSTUME_VIEW_MODE,
			TransitionList.Type.FRIEND_LIST,
			TransitionList.Type.FRIEND_REQUEST_LIST,
			TransitionList.Type.FRIEND_ACCEPT_LIST,
			TransitionList.Type.FRIEND_SEARCH,
			TransitionList.Type.SNS,
			TransitionList.Type.UNLOCK_DIVA,
			TransitionList.Type.UNLOCK_COSTUME,
			TransitionList.Type.UNLOCK_VALKYRIE,
			TransitionList.Type.SIMULATIONLIVE_SETTING,
			TransitionList.Type.SIMULATIONLIVE_RESULT,
			TransitionList.Type.NEW_YEAR_EVENT,
			TransitionList.Type.GACHA_BOX,
			TransitionList.Type.GACHA_BOX_QUEST,
			TransitionList.Type.EPISODE_SELECT,
			TransitionList.Type.EPISODE_DETAIL,
			TransitionList.Type.EPISODE_ITEM_SELECT,
			TransitionList.Type.CAMPAIGN,
			TransitionList.Type.CAMPAIGN_ROULETTE,
			TransitionList.Type.GACHA_CHECK_NEW_COSTUME,
			TransitionList.Type.GACHA_CHECK_NEW_VALKYRIE,
			TransitionList.Type.EPISODE_APPEAL,
			TransitionList.Type.NEW_YEAR_EVENT_STORY,
			TransitionList.Type.OFFER_SELECT,
			TransitionList.Type.OFFER_FORMATION,
			TransitionList.Type.OFFER_TRANSFORMATION,
			TransitionList.Type.OFFER_VALKYRIESELECT,
			TransitionList.Type.OFFER_RESULT,
			TransitionList.Type.LOBBY_MAIN,
			TransitionList.Type.LOBBY_MISSION,
			TransitionList.Type.LOBBY_GROUP_SELECT,
			TransitionList.Type.LOBBY_GROUP_SEARCH,
			TransitionList.Type.DECO,
			TransitionList.Type.DECO_BAST,
			TransitionList.Type.DECO_STAMP,
			TransitionList.Type.DECO_VISIT_LIST,
			TransitionList.Type.DECO_VISIT,
			TransitionList.Type.DECO_XAOS_STORE,
			TransitionList.Type.DECO_BAST_STORAGE,
			TransitionList.Type.RAID,
			TransitionList.Type.RAID_REWARD,
			TransitionList.Type.RAID_ACT_SELECT,
			TransitionList.Type.RAID_MCRS_CANNON,
			TransitionList.Type.RAID_MVP,
			TransitionList.Type.LOBBY_MEMBER,
			TransitionList.Type.DECO_CHAT,
			TransitionList.Type.GACHA_2,
			TransitionList.Type.ASSIST_SELECT,
			TransitionList.Type.HOME_BG_SELECT,
			TransitionList.Type.GODIVA_TEAM_SELECT,
			TransitionList.Type.DIVA_RANKING,
			TransitionList.Type.GODIVA_SAVE_UNIT_DETAIL,
			TransitionList.Type.GAKUYA,
			TransitionList.Type.GAKUYA_DIVA_VIEW
		}; // 0x3C
		private string[] assetBundleName = new string[4] { "ly/004.xab", "UI_MenuTop", "ly/034.xab", "UI_MenuStack" }; // 0x40

		public CommonMenuTop MenuTop { get { return m_userInfo; } } //0xB26CA4
		// public CommonMenuStack MenuStack { get; } 0xB26CAC
		// public UnityEvent OnChargeMoney { get; } 0xB26CB4

		// // RVA: 0xB26CBC Offset: 0xB26CBC VA: 0xB26CBC
		public MenuHeaderControl(GameObject root)
		{
			m_root = root;
		}

		// // RVA: 0xB28E7C Offset: 0xB28E7C VA: 0xB28E7C
		// public bool CheckDisableUserInfo(TransitionInfo info) { }

		// // RVA: 0xB2903C Offset: 0xB2903C VA: 0xB2903C
		public void Show(TransitionList.Type transitionName, TransitionUniqueId uniqueId, CommonMenuStackLabel.LabelType labelType, SceneGroupCategory group, int descId, bool isVisibleBackButton)
		{
			UnityEngine.Debug.LogError("TODO Menu Header Show");
		}

		// // RVA: 0xB29640 Offset: 0xB29640 VA: 0xB29640
		// public void SetActive(bool active) { }

		// // RVA: 0xB29754 Offset: 0xB29754 VA: 0xB29754
		// public void Enter(bool isFading = False) { }

		// // RVA: 0xB29810 Offset: 0xB29810 VA: 0xB29810
		// public void Leave(bool isFading = False) { }

		// // RVA: 0xB298CC Offset: 0xB298CC VA: 0xB298CC
		// public bool IsPlaying() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C76AC Offset: 0x6C76AC VA: 0x6C76AC
		// // RVA: 0xB298F8 Offset: 0xB298F8 VA: 0xB298F8
		public IEnumerator Load(MonoBehaviour mb, Font font, UnityAction action)
		{
			UnityEngine.Debug.LogError("TODO MenuHeaderControl Load");
			action();
			yield break;
		}

		// // RVA: 0xB299F0 Offset: 0xB299F0 VA: 0xB299F0
		// public void SetButtonDisable(MenuHeaderControl.Button bit) { }

		// // RVA: 0xB29B2C Offset: 0xB29B2C VA: 0xB29B2C
		// public void SetButtonEnable(MenuHeaderControl.Button bit) { }

		// // RVA: 0xB29CE4 Offset: 0xB29CE4 VA: 0xB29CE4
		// public ButtonBase FindButton(MenuHeaderControl.Button bit) { }

		// // RVA: 0xB29DF4 Offset: 0xB29DF4 VA: 0xB29DF4
		// public bool IsEnableBack() { }

		// // RVA: 0xB29E8C Offset: 0xB29E8C VA: 0xB29E8C
		public void ApplyPlayerStatus(IFBCGCCJBHI playerStatus)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xB2A28C Offset: 0xB2A28C VA: 0xB2A28C
		// private void OnClickRecovEne() { }

		// // RVA: 0xB2ABA4 Offset: 0xB2ABA4 VA: 0xB2ABA4
		// private void OnClickChargeMoney() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C7724 Offset: 0x6C7724 VA: 0x6C7724
		// // RVA: 0xB2B010 Offset: 0xB2B010 VA: 0xB2B010
		// private void <Load>b__30_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C7734 Offset: 0x6C7734 VA: 0x6C7734
		// // RVA: 0xB2B0D8 Offset: 0xB2B0D8 VA: 0xB2B0D8
		// private void <OnClickChargeMoney>b__37_0() { }

	}
}
