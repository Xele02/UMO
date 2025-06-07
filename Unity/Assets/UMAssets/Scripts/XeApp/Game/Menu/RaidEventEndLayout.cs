using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidEventEndLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_infoText1; // 0x14
		private AbsoluteLayout m_layoutMain; // 0x18
		private bool m_isShow; // 0x1C

		// RVA: 0x1BCF9CC Offset: 0x1BCF9CC VA: 0x1BCF9CC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = false;
			m_layoutMain = layout.FindViewByExId("root_sel_music_raid_boss_end_cc_sw_sel_music_raid_boss_end_cc_anim") as AbsoluteLayout;
			Hide();
			m_infoText1.text = JpStringLiterals.StringLiteral_19875;
			Loaded();
			return true;
		}

		// // RVA: 0x1BCFBC0 Offset: 0x1BCFBC0 VA: 0x1BCFBC0
		// public void SetText1(string str) { }

		// // RVA: 0x1BCFBFC Offset: 0x1BCFBFC VA: 0x1BCFBFC
		// public void Show() { }

		// RVA: 0x1BCFB38 Offset: 0x1BCFB38 VA: 0x1BCFB38
		public void Hide()
		{
			m_isShow = false;
			m_layoutMain.StartChildrenAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x1BCFC84 Offset: 0x1BCFC84 VA: 0x1BCFC84
		public void Enter()
		{
			if(!m_isShow)
			{
				m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// // RVA: 0x1BCFD24 Offset: 0x1BCFD24 VA: 0x1BCFD24
		public void Leave()
		{
			if(m_isShow)
			{
				m_layoutMain.StartChildrenAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}

		// // RVA: 0x1BCFDC4 Offset: 0x1BCFDC4 VA: 0x1BCFDC4
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}
	}
}
