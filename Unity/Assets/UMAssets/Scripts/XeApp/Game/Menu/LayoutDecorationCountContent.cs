using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationCountContent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_message; // 0x14
		[SerializeField]
		private Text m_decoCount; // 0x18
		private AbsoluteLayout m_rootLayout; // 0x1C

		// RVA: 0x19EDB98 Offset: 0x19EDB98 VA: 0x19EDB98 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x19EDBB0 Offset: 0x19EDBB0 VA: 0x19EDBB0
		public void UpdateContent(int decoCount)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_decoCount.text = string.Format(bk.GetMessageByLabel("pop_deco_item_count"), decoCount);
			m_message.text = bk.GetMessageByLabel("pop_deco_item_content");
		}
	}
}
