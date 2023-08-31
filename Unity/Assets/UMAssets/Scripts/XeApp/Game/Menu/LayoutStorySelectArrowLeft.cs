using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutStorySelectArrowLeft : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_root; // 0x14

		//// RVA: 0x194CA58 Offset: 0x194CA58 VA: 0x194CA58
		//public void SetStatus() { }

		// RVA: 0x194CA5C Offset: 0x194CA5C VA: 0x194CA5C
		public void Reset()
		{
			return;
		}

		//// RVA: 0x194CA60 Offset: 0x194CA60 VA: 0x194CA60
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x194CA98 Offset: 0x194CA98 VA: 0x194CA98
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x194CAD0 Offset: 0x194CAD0 VA: 0x194CAD0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
