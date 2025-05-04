using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LobbyMembersListWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_windowMessage; // 0x14
		[SerializeField]
		private Text m_countValues; // 0x18
		[SerializeField]
		private Text m_groupName; // 0x1C
		private AbsoluteLayout m_windowBase; // 0x20

		// RVA: 0xD13CF0 Offset: 0xD13CF0 VA: 0xD13CF0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowBase = layout.FindViewById("sw_lb_window_anim") as AbsoluteLayout;
			SetEnable(false);
			Loaded();
			return true;
		}

		// // RVA: 0xD13E08 Offset: 0xD13E08 VA: 0xD13E08
		public void Enter()
		{
			m_windowBase.StartAllAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0xD13E94 Offset: 0xD13E94 VA: 0xD13E94
		public void Leave()
		{
			m_windowBase.StartAllAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0xD13F20 Offset: 0xD13F20 VA: 0xD13F20
		// public void Show() { }

		// // RVA: 0xD13F24 Offset: 0xD13F24 VA: 0xD13F24
		// public void Hide() { }

		// // RVA: 0xD13FA4 Offset: 0xD13FA4 VA: 0xD13FA4
		// public void SetMessage(string message) { }

		// // RVA: 0xD13DD4 Offset: 0xD13DD4 VA: 0xD13DD4
		public void SetEnable(bool _enable)
		{
			m_windowMessage.enabled = _enable;
		}

		// // RVA: 0xD13FE0 Offset: 0xD13FE0 VA: 0xD13FE0
		public void SetMemberListCount(string _num)
		{
			if(m_countValues != null)
				m_countValues.text = _num;
		}

		// // RVA: 0xD140A4 Offset: 0xD140A4 VA: 0xD140A4
		public bool GetIsPlaying()
		{
			return m_windowBase.IsPlayingAll();
		}

		// // RVA: 0xD140D0 Offset: 0xD140D0 VA: 0xD140D0
		public void SetWindowGroupName(string _group)
		{
			m_groupName.text = _group;
		}
	}
}
