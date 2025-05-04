using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class RaidHelpCompletionScrollItem : SwapScrollListContent
	{
		private Text m_helperListText; // 0x20

		// RVA: 0x1BD0F8C Offset: 0x1BD0F8C VA: 0x1BD0F8C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_helperListText = GetComponentInChildren<Text>(true);
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		// RVA: 0x1BD08B0 Offset: 0x1BD08B0 VA: 0x1BD08B0
		public void UpdateContent(PKNOKJNLPOE_EventRaid.ECICDAPCMJG helper)
		{
			m_helperListText.text = helper.LBODHBDOMGK;
		}
	}
}
