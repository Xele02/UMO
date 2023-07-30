using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.RhythmAdjust
{
	public class LayoutRhythmAdjustTutorialConfirmWindow : LayoutUGUIScriptBase
	{
		public enum ButtonType
		{
			None = 0,
			ReAdjust = 1,
			NoProblem = 2,
		}

		[SerializeField]
		private ActionButton[] m_buttons; // 0x14
		[SerializeField]
		private AbsoluteLayout m_windowAnimeLayout; // 0x18
		//[CompilerGeneratedAttribute] // RVA: 0x66294C Offset: 0x66294C VA: 0x66294C
		public UnityAction<ButtonType> ButtonHandler; // 0x1C

		// RVA: 0xF5C44C Offset: 0xF5C44C VA: 0xF5C44C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_buttons[0].AddOnClickCallback(() =>
			{
				//0xF5C99C
				OnPushButton(ButtonType.ReAdjust);
			});
			m_buttons[1].AddOnClickCallback(() =>
			{
				//0xF5C9A4
				OnPushButton(ButtonType.NoProblem);
			});
			m_windowAnimeLayout = layout.FindViewByExId("root_sel_note_adjust_pop_sw_sel_note_adjust_pop_transition_anim") as AbsoluteLayout;
			m_windowAnimeLayout.StartChildrenAnimGoStop("st_out");
			ClearLoadedCallback();
			return true;
		}

		// // RVA: 0xF5B4AC Offset: 0xF5B4AC VA: 0xF5B4AC
		// public void Open(UnityAction endCb) { }

		// // RVA: 0xF5B510 Offset: 0xF5B510 VA: 0xF5B510
		// public void Close(UnityAction endCb) { }

		// // RVA: 0xF5B6E0 Offset: 0xF5B6E0 VA: 0xF5B6E0
		public bool IsReady()
		{
			LayoutUGUIRuntime[] runtimes = GetComponentsInChildren<LayoutUGUIRuntime>();
			for(int i = 0; i < runtimes.Length; i++)
			{
				if(!runtimes[i].IsReady)
					return false;
			}
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B09C8 Offset: 0x6B09C8 VA: 0x6B09C8
		// // RVA: 0xF5C668 Offset: 0xF5C668 VA: 0xF5C668
		// private IEnumerator Co_Open(UnityAction endCb) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B0A40 Offset: 0x6B0A40 VA: 0x6B0A40
		// // RVA: 0xF5C710 Offset: 0xF5C710 VA: 0xF5C710
		// private IEnumerator Co_Close(UnityAction endCb) { }

		// // RVA: 0xF5C7F8 Offset: 0xF5C7F8 VA: 0xF5C7F8
		private void OnPushButton(ButtonType type)
		{
			ButtonHandler(type);
		}

		// // RVA: 0xF5C86C Offset: 0xF5C86C VA: 0xF5C86C
		// private void ButtonDisable() { }

		// // RVA: 0xF5C900 Offset: 0xF5C900 VA: 0xF5C900
		// private void ButtonEnable() { }

		// // RVA: 0xF5B5D4 Offset: 0xF5B5D4 VA: 0xF5B5D4
		// public void PerformClickCancel() { }
	}
}
