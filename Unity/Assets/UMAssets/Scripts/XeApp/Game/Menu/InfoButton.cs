using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using System;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class InfoButton : ActionButton
	{
		public Action<int> OnClickButton; // 0x80
		[SerializeField]
		private Text[] m_textPage; // 0x84

		public int pageNum { get; private set; } // 0x88
		public int pageMax { get; private set; } // 0x8C

		// RVA: 0x13DDF4C Offset: 0x13DDF4C VA: 0x13DDF4C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			AddOnClickCallback(() =>
			{
				//0x13DE124
				pageNum++;
				if (pageNum > pageMax)
					pageNum = 1;
				if (OnClickButton != null)
					OnClickButton(pageNum);
				SetPage(pageNum, pageMax);
			});
			SetPage(1, 1);
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x13DE00C Offset: 0x13DE00C VA: 0x13DE00C
		public void SetPage(int num, int max)
		{
			m_textPage[0].text = pageNum.ToString();
			m_textPage[1].text = pageMax.ToString();
		}
	}
}
