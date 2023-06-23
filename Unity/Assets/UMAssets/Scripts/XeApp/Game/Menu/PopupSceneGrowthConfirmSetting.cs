
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupSceneGrowthConfirmSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x1147430
		public override string BundleName { get { return "ly/019.xab"; } } //0x114748C
		public override string AssetName { get { return "root_pop_mask_ability_layout_root"; } } //0x11474E8
		public override bool IsPreload { get { return true; } } //0x1147544
		public override bool IsAssetBundle { get { return true; } } //0x114754C
		public override GameObject Content { get { return m_content; } } //0x1147554
	}
}
