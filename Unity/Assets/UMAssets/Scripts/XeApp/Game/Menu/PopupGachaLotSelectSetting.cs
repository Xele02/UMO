
using System;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGachaLotSelectSetting : PopupSetting
	{
		public List<BEPHBEGDFFK.DMBKENKBIJD> ProductInfos { get; set; } // 0x34
		public Action<BEPHBEGDFFK.DMBKENKBIJD> OnClickButton { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x17A1DC8
		public override string BundleName { get { return "ly/069.xab"; } } //0x17A1E24
		public override string AssetName { get { return "root_gacha_pop03_layout_root"; } } //0x17A1E80
		public override bool IsAssetBundle { get { return true; } } //0x17A1EDC
		public override bool IsPreload { get { return false; } } //0x17A1EE4
	}
}
