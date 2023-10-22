using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSpItemLevelupContent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_message; // 0x14
		[SerializeField]
		private Text m_currentLevel; // 0x18
		[SerializeField]
		private Text m_nextLevel; // 0x1C
		private AbsoluteLayout m_rootLayout; // 0x20

		// RVA: 0x18BA6E4 Offset: 0x18BA6E4 VA: 0x18BA6E4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rootLayout = layout.FindViewByExId("root_deco_pop_m_02_01_sw_pop_m_02_01_all") as AbsoluteLayout;
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x18BA7BC Offset: 0x18BA7BC VA: 0x18BA7BC
		public void UpdateContent(int currentLevel, int itemId)
		{
			int a = 2;
			if(KDKFHGHGFEK.KKDMFKGMHLD(currentLevel + 1))
				a = 3;
			m_rootLayout.StartChildrenAnimGoStop(a.ToString("00"));
			m_message.text = string.Format(MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_levelup"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId));
			m_currentLevel.text = currentLevel.ToString();
			m_nextLevel.text = (currentLevel + 1).ToString();
		}
	}
}
