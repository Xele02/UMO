
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupSceneGrowthSetting : PopupSetting
	{
		//public MNDAMOGGJBJ ViewGrowItemData { get; set; } // 0x34
		//public MNDAMOGGJBJ.MNDGNJLBANB Reason { get; set; } // 0x38
		public bool IsValidate { get; set; } // 0x3C
		public override string PrefabPath { get { return ""; } } //0x1147700
		public override string BundleName { get { return "ly/019.xab"; } } //0x114775C
		public override string AssetName { get { return "root_pop_mask_item_layout_root"; } } //0x11477B8
		public override bool IsPreload { get { return true; } } //0x1147814
		public override bool IsAssetBundle { get { return true; } } //0x114781C
		public override GameObject Content { get { return m_content; } } //0x1147824
	}
}
