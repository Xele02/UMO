using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationWin01Pos : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_deco_win_01_pos_layout_root"; // 0x0
		[SerializeField]
		private Text m_text; // 0x14
		private AbsoluteLayout m_base; // 0x18
		private bool IsEnter; // 0x1C
		private int m_rest; // 0x20
		private int m_max; // 0x24

		// RVA: 0x18C13EC Offset: 0x18C13EC VA: 0x18C13EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = layout.FindViewById("sw_deco_win_pos_03_all_anim") as AbsoluteLayout;
			return true;
		}

		// RVA: 0x18C14B8 Offset: 0x18C14B8 VA: 0x18C14B8
		public void SettingPostRest(int rest)
		{
			m_rest = rest;
			UpdateText();
		}

		// RVA: 0x18C159C Offset: 0x18C159C VA: 0x18C159C
		public void SettingPostMax(int max)
		{
			m_max = max;
			UpdateText();
		}

		// // RVA: 0x18C14C0 Offset: 0x18C14C0 VA: 0x18C14C0
		private void UpdateText()
		{
			m_text.text = string.Format(JpStringLiterals.StringLiteral_16775, m_rest, m_max);
		}

		// RVA: 0x18C15A4 Offset: 0x18C15A4 VA: 0x18C15A4
		public void Enter()
		{
			if(IsEnter)
				return;
			IsEnter = true;
			m_base.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x18C1644 Offset: 0x18C1644 VA: 0x18C1644
		public void Leave()
		{
			if(!IsEnter)
				return;
			IsEnter = false;
			m_base.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x18C16E4 Offset: 0x18C16E4 VA: 0x18C16E4
		public void Hide()
		{
			m_base.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// RVA: 0x18C1764 Offset: 0x18C1764 VA: 0x18C1764
		public bool IsPlayingEnd()
		{
			return !m_base.IsPlaying();
		}
	}
}
