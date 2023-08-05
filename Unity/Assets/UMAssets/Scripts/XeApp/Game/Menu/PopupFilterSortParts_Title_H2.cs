using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_Title_H2 : PopupFilterSortPartsBase
	{
		[SerializeField]
		private Text m_title_text; // 0x1C

		// RVA: 0x1C8CEFC Offset: 0x1C8CEFC VA: 0x1C8CEFC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}

		// // RVA: 0x1C8CF14 Offset: 0x1C8CF14 VA: 0x1C8CF14
		public void SetTitle(string a_title)
		{
			m_title_text.text = a_title;
		}
	}
}
