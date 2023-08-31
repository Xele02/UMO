using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutStorySelectArrowRight : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_root; // 0x14

		//// RVA: 0x194CBC4 Offset: 0x194CBC4 VA: 0x194CBC4
		//public void SetStatus() { }

		// RVA: 0x194CBC8 Offset: 0x194CBC8 VA: 0x194CBC8
		public void Reset()
		{
			return;
		}

		//// RVA: 0x194CBCC Offset: 0x194CBCC VA: 0x194CBCC
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x194CC04 Offset: 0x194CC04 VA: 0x194CC04
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x194CC3C Offset: 0x194CC3C VA: 0x194CC3C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
