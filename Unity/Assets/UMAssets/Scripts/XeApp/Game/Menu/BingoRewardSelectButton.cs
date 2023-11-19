using XeApp.Game.Common;
using UnityEngine;
using System;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class BingoRewardSelectButton : ActionButton
	{
		[SerializeField]
		private int m_pageOffset; // 0x80

		public Action<int> onSelectButton { private get; set; } // 0x84

		//// RVA: 0x10A1C8C Offset: 0x10A1C8C VA: 0x10A1C8C
		private void OnClick()
		{
			if (onSelectButton != null)
				onSelectButton(m_pageOffset);
		}

		// RVA: 0x10A1CFC Offset: 0x10A1CFC VA: 0x10A1CFC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			AddOnClickCallback(OnClick);
			Loaded();
			return true;
		}
	}
}
