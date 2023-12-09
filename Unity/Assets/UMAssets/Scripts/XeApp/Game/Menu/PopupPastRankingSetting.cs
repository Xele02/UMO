using System;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupPastRankingSetting : PopupSetting
	{
		public int ScoreRankingIconId { get; set; } // 0x34
		public int EventRankingIconId { get; set; } // 0x38
		public Action OnClickScoreRanking { get; set; } // 0x3C
		public Action OnClickEventRanking { get; set; } // 0x40
		public override string PrefabPath { get { return ""; } } //0x160A638
		public override string BundleName { get { return "ly/009.xab"; } } //0x160A694
		public override string AssetName { get { return "PopupPastRanking"; } } //0x160A6F0
		public override bool IsAssetBundle { get { return true; } } //0x160A74C
		public override bool IsPreload { get { return false; } } //0x160A754
	}
}
