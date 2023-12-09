
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupVariousInfoSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x11647FC
		public override string BundleName { get { return "ly/009.xab"; } } //0x1164858
		public override string AssetName { get { return "root_option_popup_layout_root"; } } //0x11648B4
		public override bool IsAssetBundle { get { return true; } } //0x1164910
		public override bool IsPreload { get { return false; } } //0x1164918
		public override GameObject Content { get { return m_content; } } //0x1164920

		//// RVA: 0x1164928 Offset: 0x1164928 VA: 0x1164928
		//public void SetContent(GameObject obj) { }
	}
}
