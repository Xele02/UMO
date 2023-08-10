using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutSkillUpAnimation : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_layoutroot; // 0x14

		// RVA: 0x194A558 Offset: 0x194A558 VA: 0x194A558
		private void Start()
		{
			return;
		}

		// RVA: 0x194A55C Offset: 0x194A55C VA: 0x194A55C
		private void Update()
		{
			return;
		}

		// RVA: 0x194A560 Offset: 0x194A560 VA: 0x194A560
		public void EnterEffect()
		{
			m_layoutroot.StartChildrenAnimGoStop("go_act_01", "st_act_01");
		}

		// RVA: 0x194A5EC Offset: 0x194A5EC VA: 0x194A5EC
		public void EnterWord()
		{
			m_layoutroot.StartChildrenAnimGoStop("go_act_02", "st_act_02");
		}

		// RVA: 0x194A678 Offset: 0x194A678 VA: 0x194A678
		public bool IsPlaying()
		{
			return m_layoutroot.IsPlayingChildren();
		}

		// RVA: 0x194A6A4 Offset: 0x194A6A4 VA: 0x194A6A4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			m_layoutroot = layout.FindViewByExId("sw_sel_val_abi_lvup_layout_root") as AbsoluteLayout;
			return true;
		}
	}
}
