using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

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
			TodoLogger.LogError(0, "Start");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x726434 Offset: 0x726434 VA: 0x726434
		//// RVA: 0xC3B0C0 Offset: 0xC3B0C0 VA: 0xC3B0C0
		//private IEnumerator InitializeLayoutCoroutine() { }

		//// RVA: 0xC3B16C Offset: 0xC3B16C VA: 0xC3B16C
		//private void CallBackUnitSetting() { }

		//// RVA: 0xC3B274 Offset: 0xC3B274 VA: 0xC3B274
		//private void CallBackEpisodeSelect() { }

		//// RVA: 0xC3B374 Offset: 0xC3B374 VA: 0xC3B374
		//private void CallBackAbilityRelease() { }

		//// RVA: 0xC3B494 Offset: 0xC3B494 VA: 0xC3B494
		//private void CallBackDivaSetting() { }

		//// RVA: 0xC3B5B4 Offset: 0xC3B5B4 VA: 0xC3B5B4
		//private void CallBackCostumeUpgrade() { }

		//// RVA: 0xC3B980 Offset: 0xC3B980 VA: 0xC3B980
		//public void CallBackValkyrieTuneUp() { }

		// RVA: 0xC3C3E0 Offset: 0xC3C3E0 VA: 0xC3C3E0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			TodoLogger.LogError(0, "OnPreSetCanvas");
		}

		// RVA: 0xC3C638 Offset: 0xC3C638 VA: 0xC3C638 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			TodoLogger.LogError(0, "IsEndPreSetCanvas");
			return true;
		}

		// RVA: 0xC3C640 Offset: 0xC3C640 VA: 0xC3C640 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			TodoLogger.LogError(0, "IsEndPostSetCanvas");
			return true;
		}

		// RVA: 0xC3C648 Offset: 0xC3C648 VA: 0xC3C648 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			TodoLogger.LogError(0, "OnStartEnterAnimation");
		}

		// RVA: 0xC3C790 Offset: 0xC3C790 VA: 0xC3C790 Slot: 23
		protected override void OnActivateScene()
		{
			TodoLogger.LogError(0, "OnActivateScene");
		}

		//// RVA: 0xC3C6E4 Offset: 0xC3C6E4 VA: 0xC3C6E4
		//private void SettingCostumeUpgradeBotton() { }

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
		//private void SettingValkyrieTuneUpButton() { }

		// RVA: 0xC3C840 Offset: 0xC3C840 VA: 0xC3C840 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			TodoLogger.LogError(0, "IsEndEnterAnimation");
			return true;
		}

		// RVA: 0xC3C870 Offset: 0xC3C870 VA: 0xC3C870 Slot: 12
		protected override void OnStartExitAnimation()
		{
			TodoLogger.LogError(0, "OnStartExitAnimation");
		}

		// RVA: 0xC3C8FC Offset: 0xC3C8FC VA: 0xC3C8FC Slot: 13
		protected override bool IsEndExitAnimation()
		{
			TodoLogger.LogError(0, "IsEndExitAnimation");
			return true;
		}

		// RVA: 0xC3C92C Offset: 0xC3C92C VA: 0xC3C92C Slot: 25
		protected override void OnTutorial()
		{
			TodoLogger.LogError(0, "OnTutorial");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7264AC Offset: 0x7264AC VA: 0x7264AC
		//// RVA: 0xC3C7B4 Offset: 0xC3C7B4 VA: 0xC3C7B4
		//private IEnumerator Co_OnTutorial() { }
	}
}
