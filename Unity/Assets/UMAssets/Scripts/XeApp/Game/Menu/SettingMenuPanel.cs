using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using System.Collections;
using XeApp.Game.Tutorial;
using mcrs;

namespace XeApp.Game.Menu
{
	public class SettingMenuPanel : TransitionRoot
	{
		public enum ButtonName
		{
			UnitSetting = 0,
			DivaList = 1,
			SceneList = 2,
			EpisodeList = 3,
			Max = 4,
		}

		[SerializeField]
		private ActionButton[] m_menuButtons; // 0x48
		[SerializeField]
		private SettingMenuRuntime m_settingMenu; // 0x4C
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x50
		private AbsoluteLayout m_rootAbs; // 0x54
		private TeamEditSceneArgs m_teamEditSceneArgs = new TeamEditSceneArgs(); // 0x58
		private AbsoluteLayout m_costumeUpgradeLock; // 0x5C
		private AbsoluteLayout m_valkyrieTuneUpLock; // 0x60

		// RVA: 0xC3B074 Offset: 0xC3B074 VA: 0xC3B074
		private void Start()
		{
			m_teamEditSceneArgs.Mode = UnitWindowConstant.DispMode.Unit;
			this.StartCoroutineWatched(InitializeLayoutCoroutine());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x726434 Offset: 0x726434 VA: 0x726434
		//// RVA: 0xC3B0C0 Offset: 0xC3B0C0 VA: 0xC3B0C0
		private IEnumerator InitializeLayoutCoroutine()
		{
			//0xC3D044
			if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.OANJBOPLCKP_IsUnit5Enabled())
			{
				TodoLogger.LogError(0, "InitializeLayoutUnitSetting");
				//yield return Co.R(LayoutObjectCacheUtility.InitializeLayoutUnitSetting());
				yield return null;
			}
			while (!m_settingMenu.IsLoaded())
				yield return null;
			m_rootAbs = m_runtime.Layout.FindViewByExId("root_setting_menu_setting_menu") as AbsoluteLayout;
			m_costumeUpgradeLock = m_runtime.Layout.FindViewByExId("sw_s_m_btn_05_anim_swtbl_s_m_btn_lock") as AbsoluteLayout;
			m_valkyrieTuneUpLock = m_runtime.Layout.FindViewByExId("sw_s_m_btn_06_anim_swtbl_s_m_btn_lock") as AbsoluteLayout;
			m_menuButtons[0].AddOnClickCallback(CallBackUnitSetting);
			m_menuButtons[1].AddOnClickCallback(CallBackEpisodeSelect);
			m_menuButtons[2].AddOnClickCallback(CallBackDivaSetting);
			m_menuButtons[3].AddOnClickCallback(CallBackAbilityRelease);
			m_menuButtons[4].AddOnClickCallback(CallBackCostumeUpgrade);
			m_menuButtons[5].AddOnClickCallback(CallBackValkyrieTuneUp);
			IsReady = true;
		}

		//// RVA: 0xC3B16C Offset: 0xC3B16C VA: 0xC3B16C
		private void CallBackUnitSetting()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Call(TransitionList.Type.TEAM_EDIT, m_teamEditSceneArgs, true);
		}

		//// RVA: 0xC3B274 Offset: 0xC3B274 VA: 0xC3B274
		private void CallBackEpisodeSelect()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.Call(TransitionList.Type.EPISODE_SELECT, null, true);
		}

		//// RVA: 0xC3B374 Offset: 0xC3B374 VA: 0xC3B374
		private void CallBackAbilityRelease()
		{
			TodoLogger.LogNotImplemented("CallBackAbilityRelease");
		}

		//// RVA: 0xC3B494 Offset: 0xC3B494 VA: 0xC3B494
		private void CallBackDivaSetting()
		{
			TodoLogger.LogNotImplemented("CallBackDivaSetting");
		}

		//// RVA: 0xC3B5B4 Offset: 0xC3B5B4 VA: 0xC3B5B4
		private void CallBackCostumeUpgrade()
		{
			TodoLogger.LogNotImplemented("CallBackCostumeUpgrade");
		}

		//// RVA: 0xC3B980 Offset: 0xC3B980 VA: 0xC3B980
		public void CallBackValkyrieTuneUp()
		{
			TodoLogger.LogNotImplemented("CallBackValkyrieTuneUp");
		}

		// RVA: 0xC3C3E0 Offset: 0xC3C3E0 VA: 0xC3C3E0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			GameManager.Instance.ViewPlayerData.NJHBALJBFDK();
			m_rootAbs.StartChildrenAnimGoStop("st_out");
			m_settingMenu.UpdateContent(GameManager.Instance.ViewPlayerData);
			MenuScene.Instance.StatusWindowControl.ResetHistory();
		}

		// RVA: 0xC3C638 Offset: 0xC3C638 VA: 0xC3C638 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return true;
		}

		// RVA: 0xC3C640 Offset: 0xC3C640 VA: 0xC3C640 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return true;
		}

		// RVA: 0xC3C648 Offset: 0xC3C648 VA: 0xC3C648 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			SettingCostumeUpgradeBotton();
			SettingValkyrieTuneUpButton();
			m_rootAbs.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0xC3C790 Offset: 0xC3C790 VA: 0xC3C790 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnTutorial());
		}

		//// RVA: 0xC3C6E4 Offset: 0xC3C6E4 VA: 0xC3C6E4
		private void SettingCostumeUpgradeBotton()
		{
			m_costumeUpgradeLock.StartChildrenAnimGoStop(MOEALEGLGCH.CDOCOLOKCJK() ? 1 : 0, MOEALEGLGCH.CDOCOLOKCJK() ? 1 : 0);
		}

		// RVA: 0xC3C260 Offset: 0xC3C260 VA: 0xC3C260
		public static bool IsValkyrieTuneUpUnlock()
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
				{
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("valkyrietuneup_player_level", 0) <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
				}
			}
			return false;
		}

		//// RVA: 0xC3C73C Offset: 0xC3C73C VA: 0xC3C73C
		private void SettingValkyrieTuneUpButton()
		{
			m_valkyrieTuneUpLock.StartChildrenAnimGoStop(IsValkyrieTuneUpUnlock() ? 1 : 0, IsValkyrieTuneUpUnlock() ? 1 : 0);
		}

		// RVA: 0xC3C840 Offset: 0xC3C840 VA: 0xC3C840 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_rootAbs.IsPlayingChildren();
		}

		// RVA: 0xC3C870 Offset: 0xC3C870 VA: 0xC3C870 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_rootAbs.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0xC3C8FC Offset: 0xC3C8FC VA: 0xC3C8FC Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_rootAbs.IsPlayingChildren();
		}

		// RVA: 0xC3C92C Offset: 0xC3C92C VA: 0xC3C92C Slot: 25
		protected override void OnTutorial()
		{
			TodoLogger.LogError(0, "OnTutorial");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7264AC Offset: 0x7264AC VA: 0x7264AC
		//// RVA: 0xC3C7B4 Offset: 0xC3C7B4 VA: 0xC3C7B4
		private IEnumerator Co_OnTutorial()
		{
			//0xC3CC8C
			if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.MLBBKNLPBBD_IsTutoDone(1) && MOEALEGLGCH.CDOCOLOKCJK() && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.MLBBKNLPBBD_IsTutoDone(0))
			{
				yield return Co.R(TutorialProc.Co_CostumeUpgrade(EBFLJMOCLNA_Costume.NDOPBOCEPJO.CAPLNONHNCO/*1*/, m_menuButtons[4], BasicTutorialMessageId.Id_CostumeUpgradeMenu, InputLimitButton.Delegate, TutorialPointer.Direction.Normal));
			}
			else
			{
				if(IsValkyrieTuneUpUnlock() && !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsValkyrieUpgrade))
				{
					yield return Co.R(TutorialProc.Co_ValkyrieUpgrade(m_menuButtons[5], BasicTutorialMessageId.Id_ValkyrieUpgradeMenu, InputLimitButton.Delegate, TutorialPointer.Direction.Normal, null, null));
				}
			}
		}
	}
}
