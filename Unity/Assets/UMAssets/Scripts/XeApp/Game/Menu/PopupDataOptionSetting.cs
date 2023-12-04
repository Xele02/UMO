
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDataOptionSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x1345A04
		public override string BundleName { get { return "ly/009.xab"; } } //0x1345A60
		public override string AssetName { get { return "root_option_pop_data_dl_layout_root"; } } //0x1345ABC
		public override bool IsAssetBundle { get { return true; } } //0x1345B18
		public override bool IsPreload { get { return false; } } //0x1345B20
		public override GameObject Content { get { return m_content; } } //0x1345B28
		public Action<PopupWindowControl> OnClickBunchInstall { get; set; } // 0x34

		//// RVA: 0x1345B30 Offset: 0x1345B30 VA: 0x1345B30
		//public void SetContent(GameObject obj) { }
	}
}
