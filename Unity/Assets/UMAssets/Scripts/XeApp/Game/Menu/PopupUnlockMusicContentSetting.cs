
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupUnlockMusicContentSetting : PopupSetting // TypeDefIndex: 14589
	{
		public Action closeAction; // 0x38

		public PopupUnlock.UnlockInfo UnlockInfo { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x115EAB4
		public override string BundleName { get { return "ly/047.xab"; } } //0x115EB10
		public override string AssetName { get { return "root_pop_music_ul_layout_root"; } } //0x115EB6C
		public override bool IsAssetBundle { get { return true; } } //0x115EBC8
		public override bool IsPreload { get { return false; } } //0x115EBD0
		public override GameObject Content { get { return m_content; } } //0x115EBD8

		//// RVA: 0x115EBE0 Offset: 0x115EBE0 VA: 0x115EBE0
		//public void SetContent(GameObject obj) { }
	}
}
