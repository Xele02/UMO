using System.Linq;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvSeparatorLayout : FlexibleListItemLayout
	{
		private Text m_text; // 0x18

		// RVA: 0x114689C Offset: 0x114689C VA: 0x114689C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_text = txts.Where((Text x) =>
			{
				//0x1146B84
				return x.name.Contains("required_pt");
			}).FirstOrDefault();
			Loaded();
			return true;
		}

		// RVA: 0x1146A3C Offset: 0x1146A3C VA: 0x1146A3C
		public void SetRunk(string text)
		{
			if(m_text != null)
				m_text.text = text;
		}
	}
}
