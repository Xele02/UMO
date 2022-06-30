using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class MenuFooterControl
	{
		// private GameObject m_root; // 0x8
		// private GameObject m_instance; // 0xC
		// private MenuBarPrefab m_menuBar; // 0x10
		// private ActionButton[] m_actionButtons; // 0x14
		// private LayoutUGUIHitOnly[] m_buttons; // 0x18
		// private int[] m_buttonBlockCount; // 0x1C
		// private HGOAIGFPCBC m_QuestbadgeData; // 0x20
		// private IIMBAOGHCIG m_HomebadgeData; // 0x24
		// private List<TransitionUniqueId> m_disableMenuBarUniqueScene; // 0x28
		// private List<TransitionList.Type> m_disableMenuBarScene; // 0x2C
		// private static readonly MenuButtonAnim.ButtonType[] ToButtonType = new MenuButtonAnim.ButtonType[7] { 6, 5, 4, 3, 2, 1, 0 }; // 0x0

		// public MenuBarPrefab MenuBar { get; } 0xED0D08

		// RVA: 0xED0D10 Offset: 0xED0D10 VA: 0xED0D10
		public MenuFooterControl(GameObject root)
		{
			UnityEngine.Debug.LogError("TODO MenuFooterControl");
		}

		// // RVA: 0xED1F34 Offset: 0xED1F34 VA: 0xED1F34
		// public bool CheckDisableFooter(TransitionInfo info) { }

		// // RVA: 0xED20EC Offset: 0xED20EC VA: 0xED20EC
		public void Show(TransitionList.Type transitionName, TransitionUniqueId uniqueId, MenuButtonAnim.ButtonType selectedButton, bool isFading)
		{
			UnityEngine.Debug.LogError("TODO footer Show");
		}

		// // RVA: 0xED2390 Offset: 0xED2390 VA: 0xED2390
		// public void Enter(bool isFading = False) { }

		// // RVA: 0xED2448 Offset: 0xED2448 VA: 0xED2448
		// public void Leave(bool isFading = False) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C75D4 Offset: 0x6C75D4 VA: 0x6C75D4
		// RVA: 0xED2500 Offset: 0xED2500 VA: 0xED2500
		public IEnumerator Load(Font font, UnityAction action)
		{
			UnityEngine.Debug.LogError("TODO MenuFooterControl Load");
			action();
			yield break;
		}

		// // RVA: 0xED25BC Offset: 0xED25BC VA: 0xED25BC
		public void Initialize()
		{
			UnityEngine.Debug.LogError("TODO MenuFooterControl Initialize");
		}

		// // RVA: 0xED25E4 Offset: 0xED25E4 VA: 0xED25E4
		// public void Release() { }

		// // RVA: 0xED25F8 Offset: 0xED25F8 VA: 0xED25F8
		// public bool IsPlaying() { }

		// // RVA: 0xED2620 Offset: 0xED2620 VA: 0xED2620
		// public void SelectedButton(MenuButtonAnim.ButtonType buttonType) { }

		// // RVA: 0xED2650 Offset: 0xED2650 VA: 0xED2650
		// public void NotSelectButtonAll() { }

		// // RVA: 0xED2678 Offset: 0xED2678 VA: 0xED2678
		// public void SetButtonDisable(MenuFooterControl.Button bit) { }

		// // RVA: 0xED2768 Offset: 0xED2768 VA: 0xED2768
		// public void SetButtonEnable(MenuFooterControl.Button bit) { }

		// // RVA: 0xED28D4 Offset: 0xED28D4 VA: 0xED28D4
		// public ButtonBase FindButton(MenuFooterControl.Button bit) { }

		// // RVA: 0xED29D4 Offset: 0xED29D4 VA: 0xED29D4
		// public void SetButtonNew(MenuFooterControl.Button bit, bool isNew) { }

		// // RVA: 0xED3160 Offset: 0xED3160 VA: 0xED3160
		// public void SetOfferUnlockRank() { }

		// // RVA: 0xED33D4 Offset: 0xED33D4 VA: 0xED33D4
		// public bool IsShow() { }


		// [CompilerGeneratedAttribute] // RVA: 0x6C764C Offset: 0x6C764C VA: 0x6C764C
		// // RVA: 0xED3528 Offset: 0xED3528 VA: 0xED3528
		// private void <Load>b__19_0(MenuBarPrefab instance) { }
	}
}
