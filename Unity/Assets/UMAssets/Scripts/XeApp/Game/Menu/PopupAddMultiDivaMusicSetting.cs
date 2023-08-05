
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupAddMultiDivaMusicSetting : PopupSetting // TypeDefIndex: 14275
	{
		public PopupUnlock.UnlockInfo UnlockInfo { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x1330E00
		public override string BundleName { get { return "ly/125.xab"; } } //0x1330E5C
		public override string AssetName { get { return "root_pop_music_ul_unit_layout_root"; } } //0x1330EB8
		public override bool IsAssetBundle { get { return true; } } //0x1330F14
		public override bool IsPreload { get { return false; } } //0x1330F1C
		public override GameObject Content { get { return m_content; } } //0x1330F24

		//// RVA: 0x1330F2C Offset: 0x1330F2C VA: 0x1330F2C
		//public void SetContent(GameObject obj) { }
	}
}
