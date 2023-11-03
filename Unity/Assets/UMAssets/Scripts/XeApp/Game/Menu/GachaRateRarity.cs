using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class GachaRateRarity : GachaRateElemBase
	{
		[SerializeField]
		private List<Text> m_percents; // 0x24
		private AbsoluteLayout m_animStarNum; // 0x28

		// RVA: 0xEE6308 Offset: 0xEE6308 VA: 0xEE6308
		public void SetPercent(string percent)
		{
			for(int i = 0; i < m_percents.Count; i++)
			{
				m_percents[i].text = percent;
			}
		}

		// RVA: 0xEE63F4 Offset: 0xEE63F4 VA: 0xEE63F4
		public void SetStarNum(int starNum)
		{
			m_animStarNum.StartChildrenAnimGoStop(starNum.ToString("D2"));
		}

		// RVA: 0xEE6490 Offset: 0xEE6490 VA: 0xEE6490 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_animStarNum = layout.FindViewByExId("sw_list_Coordinate01_swtbl_list_rarity") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
