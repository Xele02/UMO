using XeSys.Gfx;
using XeApp.Game.Adv;
using UnityEngine;

namespace XeApp.Game.DownLoad
{
	public class LayoutQuestionaryMessWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private AdvMessage m_message; // 0x14
		[SerializeField]
		private float m_messageSpeed = 0.025f; // 0x18
		private bool m_dirtySendMessage; // 0x1C
		private bool m_sendMessageAccept; // 0x1D
		private AbsoluteLayout m_rootAnim; // 0x20
		private AbsoluteLayout m_sendCursorAnim; // 0x24

		// RVA: 0x9819DC Offset: 0x9819DC VA: 0x9819DC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rootAnim = layout.FindViewByExId("root_cmn_euq_window_chara_sw_cmn_eup_win_f_anim") as AbsoluteLayout;
			m_sendCursorAnim = layout.FindViewByExId("sw_cmn_eup_win_f_sw_cmn_enq_next_arr_anim") as AbsoluteLayout;
			m_message.Text.text = "";
			ClearLoadedCallback();
			Loaded();
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B5C98 Offset: 0x6B5C98 VA: 0x6B5C98
		//// RVA: 0x981058 Offset: 0x981058 VA: 0x981058
		//public IEnumerator Co_ProcMessage(string message) { }

		//// RVA: 0x98118C Offset: 0x98118C VA: 0x98118C
		//public void MessageClear() { }

		//// RVA: 0x980FA0 Offset: 0x980FA0 VA: 0x980FA0
		//public void Show() { }

		//// RVA: 0x981100 Offset: 0x981100 VA: 0x981100
		//public void Hide() { }

		//// RVA: 0x98102C Offset: 0x98102C VA: 0x98102C
		//public bool IsPlaying() { }

		//// RVA: 0x981BBC Offset: 0x981BBC VA: 0x981BBC
		//private void ShowSendCursor() { }

		//// RVA: 0x981C48 Offset: 0x981C48 VA: 0x981C48
		//private void HideSendCursor() { }

		//// RVA: 0x97FCA8 Offset: 0x97FCA8 VA: 0x97FCA8
		public void OnSendMessage()
		{
			if (m_sendMessageAccept)
				m_dirtySendMessage = true;
		}
	}
}
