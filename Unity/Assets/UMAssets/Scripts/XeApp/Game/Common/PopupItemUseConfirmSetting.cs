
using UnityEngine;

namespace XeApp.Game.Common
{ 
	public class PopupItemUseConfirmSetting : PopupSetting
	{
		public int TypeItemId { get; set; } // 0x34
		public int Cost { get; set; } // 0x38
		public int OwnCount { get; set; } // 0x3C
		public int Period { get; set; } // 0x40
		public string OverrideText { get; set; } // 0x44
		public string OverrideCaution_1 { get; set; } // 0x48
		public string OverrideCaution_2 { get; set; } // 0x4C
		public bool HideDetail { get; set; } // 0x50
		public bool HideUseNum { get; set; } // 0x51
		public override bool IsPreload { get { return true; } } //0x1BADAAC
		public override bool IsAssetBundle { get { return true; } } //0x1BADAB4
		public override string PrefabPath { get { return ""; } } //0x1BADABC
		public override string BundleName { get { return "ly/216.xab"; } } // 0x1BADB18
		public override string AssetName { get { return "root_pop_rerity_layout_root"; } } //0x1BADB74
		public override GameObject Content { get { return m_content; } } //0x1BADBD0
	}
}
