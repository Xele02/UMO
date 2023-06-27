
using UnityEngine;

namespace XeApp.Game.Common
{ 
	public class PopupItemRarityUpConfirmSetting : PopupSetting
	{
		public int SceneId { get; set; } // 0x34
		public override bool IsPreload { get { return true; } } //0x1BAAFB4
		public override bool IsAssetBundle { get { return true; } } //0x1BAAFBC
		public override string PrefabPath { get { return ""; } } //0x1BAAFC4
		public override string BundleName { get { return "ly/019.xab"; } } //0x1BAB020
		public override string AssetName { get { return "root_pop_rerity2_layout_root"; } } //0x1BAB07C
		public override GameObject Content { get { return m_content; } } //0x1BAB0D8
	}
}
