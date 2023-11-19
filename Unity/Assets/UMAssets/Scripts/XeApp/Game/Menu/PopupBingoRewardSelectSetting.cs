
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupBingoRewardSelectSetting : PopupSetting
	{
		public int sceneId; // 0x34
		public int rare; // 0x38
		public string select_msg; // 0x3C

		public override string PrefabPath { get { return ""; } } //0x133B664
		public override string BundleName { get { return "ly/153.xab"; } } //0x133B6C0
		public override string AssetName { get { return "root_pop_bingo_rwd_select_layout_root"; } } //0x133B71C
		public override bool IsAssetBundle { get { return true; } } //0x133B778
		public override bool IsPreload { get { return false; } } //0x133B780
		public override GameObject Content { get { return m_content; } } //0x133B788

		//// RVA: 0x133B790 Offset: 0x133B790 VA: 0x133B790
		//public void SetContent(GameObject obj) { }
	}
}
