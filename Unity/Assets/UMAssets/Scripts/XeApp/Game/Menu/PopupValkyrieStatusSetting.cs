
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	internal class PopupValkyrieStatusSetting : PopupSetting
	{
		public PNGOLKLFFLH ViewValkyrieData { get; set; } // 0x34
		public NHDJHOPLMDE ViewValkyrieAbilityData { get; set; } // 0x38
		public override bool IsPreload { get { return true; } } //0x11625A8
		public override bool IsAssetBundle { get { return true; } } //0x11625B0
		public override string PrefabPath { get { return ""; } } //0x11625B8
		public override string BundleName { get { return "ly/013.xab"; } } //0x1162614
		public override string AssetName { get { return "root_valkyrie_detail_layout_root"; } } //0x1162670
		public override GameObject Content { get { return m_content; } } //0x11626CC
	}
}
