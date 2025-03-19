using System.Linq;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvRaidSeparatorLayout : FlexibleListItemLayout
	{
		private Text m_text; // 0x18

		// RVA: 0x1A7C19C Offset: 0x1A7C19C VA: 0x1A7C19C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_text = GetComponentsInChildren<Text>(true).Where((Text x) =>
			{
				//0x1A7C3C0
				return x.name.Contains("required_pt");
			}).FirstOrDefault();
			Loaded();
			return true;
		}

		// // RVA: 0x1A6975C Offset: 0x1A6975C VA: 0x1A6975C
		// public void SetBossName(string text) { }
	}
}
