using XeSys.Gfx;
using XeApp.Game.Adv;
using UnityEngine;
using System.Collections;
using XeApp.Game.Common;
using mcrs;

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
		public IEnumerator Co_ProcMessage(string message)
		{
			//0x981CDC
			m_message.StartMessage(message, m_messageSpeed, null);
			m_dirtySendMessage = false;
			m_sendMessageAccept = true;
			while(m_message.IsPlay())
			{
				if(m_dirtySendMessage)
				{
					m_message.Skip();
				}
				m_dirtySendMessage = false;
				yield return null;
			}
			ShowSendCursor();
			while(!m_dirtySendMessage)
			{
				yield return null;
			}
			m_dirtySendMessage = false;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_ADV_TOUCH);
			HideSendCursor();
			m_sendMessageAccept = false;
		}

		//// RVA: 0x98118C Offset: 0x98118C VA: 0x98118C
		public void MessageClear()
		{
			m_message.StartMessage("", 0, null);
		}

		//// RVA: 0x980FA0 Offset: 0x980FA0 VA: 0x980FA0
		public void Show()
		{
			m_rootAnim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x981100 Offset: 0x981100 VA: 0x981100
		public void Hide()
		{
			m_rootAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x98102C Offset: 0x98102C VA: 0x98102C
		public bool IsPlaying()
		{
			return m_rootAnim.IsPlayingChildren();
		}

		//// RVA: 0x981BBC Offset: 0x981BBC VA: 0x981BBC
		private void ShowSendCursor()
		{
			m_sendCursorAnim.StartChildrenAnimLoop("logo_act_01", "loen_act_01");
		}

		//// RVA: 0x981C48 Offset: 0x981C48 VA: 0x981C48
		private void HideSendCursor()
		{
			m_sendCursorAnim.StartChildrenAnimGoStop("st_non");
		}

		//// RVA: 0x97FCA8 Offset: 0x97FCA8 VA: 0x97FCA8
		public void OnSendMessage()
		{
			if (m_sendMessageAccept)
				m_dirtySendMessage = true;
		}
	}
}
