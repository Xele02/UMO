
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	internal class PopupDetailValkyrieSetting : PopupSetting
	{
		public PNGOLKLFFLH ViewValkyrieData { get; set; } // 0x34
		public NHDJHOPLMDE ViewValkyrieAbilityData { get; set; } // 0x38
		public override bool IsPreload { get { return true; } } //0xF80FE8
		public override bool IsAssetBundle { get { return true; } } //0xF80FF0
		public override string PrefabPath { get { return ""; } } //0xF80FF8
		public override string BundleName { get { return "ly/102.xab"; } } //0xF81054
		public override string AssetName { get { return "root_pop_detail_valkyrie_layout_root"; } } //0xF810B0
		public override GameObject Content { get { return m_content; } } //0xF8110C
	}
}
