using XeApp.Game.Common;
using UnityEngine;
using System;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	internal class CostumeUpgradeCostumeButton : ActionButton
	{
		[SerializeField]
		private int m_offset; // 0x80

		public Action<int> onSelectButton { private get; set; } // 0x84

		//// RVA: 0x16E90A0 Offset: 0x16E90A0 VA: 0x16E90A0
		private new void OnClick()
		{
			if (onSelectButton != null)
				onSelectButton(m_offset);
		}

		// RVA: 0x16E9110 Offset: 0x16E9110 VA: 0x16E9110 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			AddOnClickCallback(OnClick);
			Loaded();
			return true;
		}
	}
}
