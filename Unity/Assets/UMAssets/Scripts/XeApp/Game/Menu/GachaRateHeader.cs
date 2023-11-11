using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class GachaRateHeader : GachaRateElemBase
	{
		[SerializeField]
		private Text m_headerTitle; // 0x24
		[SerializeField]
		private Text m_listTitle; // 0x28
		[SerializeField]
		private List<Text> m_s6Percents; // 0x2C
		[SerializeField]
		private List<Text> m_s5Percents; // 0x30
		[SerializeField]
		private List<Text> m_s4Percents; // 0x34
		[SerializeField]
		private List<Text> m_s3Percents; // 0x38
		[SerializeField]
		private List<Text> m_s2Percents; // 0x3C
		[SerializeField]
		private List<Text> m_s1Percents; // 0x40
		[SerializeField]
		private List<float> m_elemHeights; // 0x44
		private AbsoluteLayout m_animStyleTable; // 0x48
		private AbsoluteLayout[] m_animStarTable; // 0x4C
		private int m_style; // 0x50

		public override float elemHeight { get {
				if(m_style > 0)
				{
					return m_elemHeights[m_style - 1];
				}
				return 0;
			} } //0xEE49C0

		// RVA: 0xEE4A50 Offset: 0xEE4A50 VA: 0xEE4A50
		public void SetStyle(int style)
		{
			switch(style)
			{
				case 1:
					m_animStyleTable.StartChildrenAnimGoStop("01");
					break;
				case 2:
					m_animStyleTable.StartChildrenAnimGoStop("02");
					break;
				case 3:
					m_animStyleTable.StartChildrenAnimGoStop("03");
					break;
				case 4:
					m_animStyleTable.StartChildrenAnimGoStop("04");
					break;
				case 5:
					m_animStyleTable.StartChildrenAnimGoStop("05");
					break;
				case 6:
					m_animStyleTable.StartChildrenAnimGoStop("06");
					break;
				default:
					break;
			}
			m_style = style;
		}

		// RVA: 0xEE4BBC Offset: 0xEE4BBC VA: 0xEE4BBC
		public void SetHeaderTitle(string title)
		{
			m_headerTitle.text = title;
		}

		// RVA: 0xEE4BF8 Offset: 0xEE4BF8 VA: 0xEE4BF8
		public void SetPercent(int index, int starNum, string percent)
		{
			List<Text> t = null;
			switch(starNum)
			{
				case 1:
					t = m_s1Percents;
					break;
				case 2:
					t = m_s2Percents;
					break;
				case 3:
					t = m_s3Percents;
					break;
				case 4:
					t = m_s4Percents;
					break;
				case 5:
					t = m_s5Percents;
					break;
				case 6:
					t = m_s6Percents;
					break;
				default:
					break;
			}
			for(int i = 0; i < t.Count; i++)
			{
				t[i].text = percent;
			}
			m_animStarTable[index].StartChildrenAnimGoStop(starNum.ToString("D2"));
		}

		// RVA: 0xEE4DF4 Offset: 0xEE4DF4 VA: 0xEE4DF4
		public void SetListTitle(string title)
		{
			m_listTitle.text = title;
		}

		// RVA: 0xEE4E30 Offset: 0xEE4E30 VA: 0xEE4E30 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_animStyleTable = layout.FindViewById("swtbl_rarity_announce") as AbsoluteLayout;
			m_animStarTable = new AbsoluteLayout[6];
			m_animStarTable[0] = layout.FindViewById("swtbl_list_rarity2_1") as AbsoluteLayout;
			m_animStarTable[1] = layout.FindViewById("swtbl_list_rarity2_2") as AbsoluteLayout;
			m_animStarTable[2] = layout.FindViewById("swtbl_list_rarity2_3") as AbsoluteLayout;
			m_animStarTable[3] = layout.FindViewById("swtbl_list_rarity2_4") as AbsoluteLayout;
			m_animStarTable[4] = layout.FindViewById("swtbl_list_rarity2_5") as AbsoluteLayout;
			m_animStarTable[5] = layout.FindViewById("swtbl_list_rarity2_6") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
