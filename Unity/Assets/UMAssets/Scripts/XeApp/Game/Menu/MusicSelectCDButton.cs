using XeApp.Game.Common;
using UnityEngine;
using System;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDButton : ActionButton
	{
		[SerializeField]
		private int m_pageOffset; // 0x80

		public Action<int> onSelectButton { private get; set; } // 0x84

		// // RVA: 0x166C290 Offset: 0x166C290 VA: 0x166C290
		// private void OnClick() { }

		// RVA: 0x166C300 Offset: 0x166C300 VA: 0x166C300 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout MusicSelectCDButton");
			return true;
		}
	}
}
