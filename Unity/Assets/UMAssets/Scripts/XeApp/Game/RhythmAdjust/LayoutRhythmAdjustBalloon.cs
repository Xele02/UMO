using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.RhythmAdjust
{
	public class LayoutRhythmAdjustBalloon : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_Anim; // 0x14
		private bool m_IsShowBalloon = true; // 0x18

		// RVA: 0xF5C05C Offset: 0xF5C05C VA: 0xF5C05C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Anim = layout.FindViewByExId("root_sel_note_adjust_balloon_sw_sel_note_adjust_balloon_transition_anim") as AbsoluteLayout;
			GetComponentInChildren<Text>(true).text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("rhythm_adjust_balloon_text");
			Loaded();
			return true;
		}

		// // RVA: 0xF5C1F4 Offset: 0xF5C1F4 VA: 0xF5C1F4
		// public bool IsReady() { }

		// // RVA: 0xF5B2BC Offset: 0xF5B2BC VA: 0xF5B2BC
		public void ChangeMode(LayoutRhythmAdjust.ModeType mode)
		{
			if (mode == LayoutRhythmAdjust.ModeType.ADJUST)
				Enter();
			else if (mode == LayoutRhythmAdjust.ModeType.CHECK)
				Leave();
		}

		// // RVA: 0xF5C290 Offset: 0xF5C290 VA: 0xF5C290
		public void Enter()
		{
			if (m_IsShowBalloon)
				return;
			m_Anim.StartChildrenAnimGoStop("go_in", "st_in");
			m_IsShowBalloon = true;
		}

		// // RVA: 0xF5B1C4 Offset: 0xF5B1C4 VA: 0xF5B1C4
		public void Leave()
		{
			if (!m_IsShowBalloon)
				return;
			m_Anim.StartChildrenAnimGoStop("go_out", "st_out");
			m_IsShowBalloon = false;
		}
	}
}
