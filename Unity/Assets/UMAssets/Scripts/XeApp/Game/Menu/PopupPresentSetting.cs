
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupPresentSetting : PopupSetting
	{
		public int itemId { get; set; } // 0x34
		public string itemName { get; set; } // 0x38
		public string itemDetail { get; set; } // 0x3C
		public override string PrefabPath { get { return ""; } } //0x1611404
		public override string BundleName { get { return "ly/116.xab"; } } //0x1611460
		public override string AssetName { get { return "root_pre_pop_01_layout_root"; } } //0x16114BC
		public override bool IsAssetBundle { get { return true; } } //0x1611518
		public override bool IsPreload { get { return false; } } //0x1611520
		public override GameObject Content { get { return m_content; } } //0x1611528

		//// RVA: 0x1611530 Offset: 0x1611530 VA: 0x1611530
		//public void SetContent(GameObject obj) { }
	}
}
