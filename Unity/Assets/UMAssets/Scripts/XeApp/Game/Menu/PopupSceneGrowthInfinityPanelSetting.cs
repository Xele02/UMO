
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupSceneGrowthInfinityPanelSetting : PopupSetting
	{
		public short UnlockCount { get; set; } // 0x34
		public short StockCount { get; set; } // 0x36
		public short EpisodeUnit { get; set; } // 0x38
		//public MNDAMOGGJBJ.MNDGNJLBANB Reason { get; set; } // 0x3C
		public override string PrefabPath { get { return ""; } } //0x11475A4
		public override string BundleName { get { return "ly/019.xab"; } } //0x1147600
		public override string AssetName { get { return "root_pop_end_release_layout_root"; } } //0x114765C
		public override bool IsPreload { get { return true; } } //0x11476B8
		public override bool IsAssetBundle { get { return true; } } //0x11476C0
		public override GameObject Content { get { return m_content; } } //0x11476C8
	}
}
