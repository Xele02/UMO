
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUnlockDifficultySetting : PopupSetting
	{
		public PopupUnlock.UnlockInfo UnlockInfo { get; set; } // 0x34
		public Action closeAction { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x115DD94
		public override string BundleName { get { return "ly/058.xab"; } } //0x115DDF0
		public override string AssetName { get { return "root_pop_dif_ul_layout_root"; } } //0x115DE4C
		public override bool IsAssetBundle { get { return true; } } //0x115DEA8
		public override bool IsPreload { get { return false; } } //0x115DEB0
		public override GameObject Content { get { return m_content; } } //0x115DEB8

		//// RVA: 0x115DEC0 Offset: 0x115DEC0 VA: 0x115DEC0
		//public void SetContent(GameObject obj) { }
	}
}
