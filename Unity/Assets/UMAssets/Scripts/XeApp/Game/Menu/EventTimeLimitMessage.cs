using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EventTimeLimitMessage : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_text; // 0x14
		private AbsoluteLayout m_layout; // 0x18
		private bool m_isShow; // 0x1C

		// RVA: 0xB9D228 Offset: 0xB9D228 VA: 0xB9D228 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout = layout.FindViewByExId("root_sel_music_eve_end_sw_sel_music_eve_end_inout_anim") as AbsoluteLayout;
			ClearLoadedCallback();
			Loaded();
			return true;
		}

		// // RVA: 0xB9D30C Offset: 0xB9D30C VA: 0xB9D30C
		public void TryEnter(bool isCounting)
		{
			if(!m_isShow)
				Enter(isCounting);
		}

		// // RVA: 0xB9D450 Offset: 0xB9D450 VA: 0xB9D450
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0xB9D31C Offset: 0xB9D31C VA: 0xB9D31C
		public void Enter(bool isCounting)
		{
			m_isShow = true;
			m_text.text = MessageManager.Instance.GetMessage("menu", isCounting ? "music_event_counting" : "music_event_end");
			m_layout.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0xB9D460 Offset: 0xB9D460 VA: 0xB9D460
		public void Leave()
		{
			m_isShow = false;
			m_layout.StartChildrenAnimGoStop("st_stop", "st_out");
		}

		// RVA: 0xB9D4F4 Offset: 0xB9D4F4 VA: 0xB9D4F4
		public void Hide()
		{
			m_isShow = false;
			m_layout.StartChildrenAnimGoStop("st_out");
		}

		// // RVA: 0xB9D578 Offset: 0xB9D578 VA: 0xB9D578
		public bool IsPlaying()
		{
			return m_layout.IsPlayingChildren();
		}
	}
}
